using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SpeakerMeet.Repositories.Interfaces;

namespace SpeakerMeet.Repositories
{
    public class InMemoryRepository<T> : IRepository<T> where T : IIdentity
    {
        protected readonly IList<T> Entities = new List<T>();
        protected int CurrentId;

        public T Get(int id)
        {
            var entity = Entities.SingleOrDefault(e => e.Id == id);

            if (entity != null)
            {
                entity = CloneEntity(entity);
            }

            return entity;
        }

        public T Get(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<T> GetAll()
        {
            return Entities.Select(CloneEntity).AsQueryable();
        }

        public virtual T Create(T entity)
        {
            var newEntity = CloneEntity(entity);
            newEntity.Id = ++CurrentId;
            Entities.Add(newEntity);

            return CloneEntity(newEntity);
        }

        public T Update(T entity)
        {
            var oldEntity = Entities.FirstOrDefault(s => s.Id == entity.Id);
            var index = Entities.IndexOf(oldEntity);

            if (index == -1)
            {
                throw new Exceptions.EntityNotFoundException(entity.Id);
            }

            Entities[index] = CloneEntity(entity);

            return CloneEntity(entity);
        }

        public IRepository<T> Include(Expression<Func<T, object>> path)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(T item)
        {
            throw new NotImplementedException($"Delete is not available for {typeof(T).Name}");
        }

        protected virtual T CloneEntity(T entity)
        {
            return entity;
        }
    }
}
