using System;
using System.Collections.Generic;
using System.Linq;
using SpeakerMeet.DTO;
using SpeakerMeet.Exceptions;
using SpeakerMeet.Repositories.Interfaces;
using SpeakerMeet.Services.Interfaces;

namespace SpeakerMeet.Services
{
    public class SpeakerService : ISpeakerService
    {
        private readonly IRepository<Models.Speaker> _repository;
        private readonly IGravatarService _gravatarService;

        public SpeakerService(IRepository<Models.Speaker> repository, IGravatarService gravatarService)
        {
            _repository = repository;
            _gravatarService = gravatarService;
        }

        public IEnumerable<Speaker> Search(string searchString)
        {
            var speakers = _repository.GetAll()
                .Where(x => x.Name.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)).ToList();

            return speakers.Select(x => new Speaker
            {
                Id = x.Id,
                Name = x.Name,
                Location = x.Location,
            });
        }

        public IEnumerable<SpeakerSummary> GetAll()
        {
            var speakers = _repository.GetAll();

            return speakers
                .Where(x => !x.IsDeleted)
                .Select(speaker => new SpeakerSummary
                {
                    Id = speaker.Id,
                    Name = speaker.Name,
                    Location = speaker.Location
                });
        }

        public SpeakerDetail Get(int id)
        {
            var speaker = _repository.Get(id);

            if (speaker == null || speaker.IsDeleted || !speaker.IsActive)
            {
                throw new SpeakerNotFoundException(id);
            }

            var gravatar = _gravatarService.GetGravatar(speaker.EmailAddress);

            return new SpeakerDetail
            {
                Id = speaker.Id,
                Name = speaker.Name,
                Location = speaker.Location,
                Gravatar = gravatar
            };
        }
    }
}