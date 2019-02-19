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
    }
}