using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SpeakerMeet.Models;
using SpeakerMeet.Repositories.Interfaces;

namespace SpeakerMeet.Services.Tests.Fakes
{
    public class FakeRepository : IRepository<Speaker>
    {
        public List<Speaker> Speakers = new List<Speaker>();

        public bool GetCalled { get; set; }
        public bool GetAllCalled { get; private set; }

        public Speaker Get(Func<Speaker, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Speaker> GetAll()
        {
            GetAllCalled = true;
            return Speakers.AsQueryable();
        }

        public Speaker Save(Speaker item)
        {
            throw new NotImplementedException();
        }

        public IRepository<Speaker> Include(Expression<Func<Speaker, object>> path)
        {
            throw new NotImplementedException();
        }

        public Speaker Update(Speaker speaker)
        {
            throw new NotImplementedException();
        }

        public void Delete(Speaker entity)
        {
            throw new NotImplementedException();
        }

        public Speaker Create(Speaker entity)
        {
            throw new NotImplementedException();
        }

        public Speaker Get(int id)
        {
            GetCalled = true;
            return Speakers.Find(x => x.Id == id);
        }
    }
}