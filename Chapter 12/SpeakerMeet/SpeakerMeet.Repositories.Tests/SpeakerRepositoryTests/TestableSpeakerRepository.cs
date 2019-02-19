using System.Collections.Generic;
using SpeakerMeet.Models;

namespace SpeakerMeet.Repositories.Tests.SpeakerRepositoryTests
{
    public class TestableSpeakerRepository : InMemorySpeakerRepository
    {
        public IList<Speaker> SpeakersCollection => Entities;
    }
}