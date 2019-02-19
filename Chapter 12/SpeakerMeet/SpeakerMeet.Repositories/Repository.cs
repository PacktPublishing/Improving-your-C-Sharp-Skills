using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SpeakerMeet.Repositories.Interfaces;

namespace SpeakerMeet.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
            _dbSet = context.Set<T>();
        }

        public T Create(T entity)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public T Get(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public T Update(T speaker)
        {
            throw new NotImplementedException();
        }

        public IRepository<T> Include(Expression<Func<T, object>> path)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }
    }
}