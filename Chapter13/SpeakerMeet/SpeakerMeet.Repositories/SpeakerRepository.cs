using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SpeakerMeet.Exceptions;
using SpeakerMeet.Models;
using SpeakerMeet.Repositories.Interfaces;

namespace SpeakerMeet.Repositories
{
    public class SpeakerRepository : IRepository<Speaker>
    {
        private int _currentId;
        protected readonly IList<Speaker> Speakers = new List<Speaker>();

        public Speaker Create(Speaker speaker)
        {
            var newSpeaker = CloneSpeaker(speaker);

            newSpeaker.Id = ++_currentId;

            Speakers.Add(newSpeaker);

            return CloneSpeaker(newSpeaker);
        }

        public Speaker Get(int id)
        {
            var speaker = Speakers.SingleOrDefault(s => s.Id == id);

            if (speaker != null)
            {
                speaker = CloneSpeaker(speaker);
            }

            return speaker;
        }

        public Speaker Get(Func<Speaker, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Speaker> GetAll()
        {
            return Speakers.Select(CloneSpeaker).AsQueryable();
        }

        public Speaker Update(Speaker speaker)
        {
            var oldSpeaker = Speakers.FirstOrDefault(s => s.Id == speaker.Id);
            var index = Speakers.IndexOf(oldSpeaker);

            if (index == -1)
            {
                throw new SpeakerNotFoundException(speaker.Id);
            }

            Speakers[index] = CloneSpeaker(speaker);

            return CloneSpeaker(speaker);
        }

        public IRepository<Speaker> Include(Expression<Func<Speaker, object>> path)
        {
            throw new NotImplementedException();
        }

        public void Delete(Speaker speaker)
        {
            speaker = CloneSpeaker(speaker);
            speaker.IsDeleted = true;

            try
            {
                Update(speaker);
            }
            catch (SpeakerNotFoundException ex)
            {
                // We can assume non-existing speakers are deleted
            }
        }

        private Speaker CloneSpeaker(Speaker speaker)
        {
            return new Speaker
            {
                Id = speaker.Id,
                Name = speaker.Name,
                Location = speaker.Location,
                IsDeleted = speaker.IsDeleted
            };
        }
    }
}
