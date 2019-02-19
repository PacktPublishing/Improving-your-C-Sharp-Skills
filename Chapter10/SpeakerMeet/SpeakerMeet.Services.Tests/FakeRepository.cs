using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SpeakerMeet.Repositories.Interfaces;

namespace SpeakerMeet.Services.Tests
{
    public class FakeRepository<T> : IRepository<T> where T : IIdentity
    {
        private int _identityCounter;
        public IList<T> DataSet { get; set; } = new List<T>();

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public T Get(Func<T, bool> predicate)
        {
            return GetAll().Where(predicate).FirstOrDefault();
        }

        public IQueryable<T> GetAll()
        {
            return DataSet.AsQueryable();
        }

        public IRepository<T> Include(Expression<Func<T, object>> path)
        {
            // Nothing to do here since this function is for EntityFramework
            // We are using Linq to Objects so there is not need for Include
            return this;
        }

        public void Delete(T item)
        {
            throw new NotImplementedException();
        }

        public T Create(T item)
        {
            item.Id = ++_identityCounter;
            DataSet.Add(item);
            return item;
        }

        public T Update(T item)
        {
            var found = Get(x => x.Id == item.Id);

            if (found == null)
            {
                throw new KeyNotFoundException($"Item with Id {item.Id} not found!");
            }

            DataSet.Remove(found);
            DataSet.Add(item);

            return item;
        }
    }
}