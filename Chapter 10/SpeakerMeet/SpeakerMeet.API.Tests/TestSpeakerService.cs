using System.Collections.Generic;
using SpeakerMeet.DTO;
using SpeakerMeet.Services.Interfaces;

namespace SpeakerMeet.API.Tests
{
    public class TestSpeakerService : ISpeakerService
    {
        public IEnumerable<Speaker> Search(string searchString)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<SpeakerSummary> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public SpeakerDetail Get(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}