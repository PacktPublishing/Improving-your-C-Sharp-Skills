using SpeakerMeet.Models;
using SpeakerMeet.Services.Tests.Fakes;

namespace SpeakerMeet.Services.Tests.Factories
{
    public static class SpeakerFactory
    {
        public static Speaker Create(FakeRepository fakeRepository, int id = 1, string name = "Joshua", string location = "Springfield, IL", string emailAddress = "example@test.com")
        {
            var speaker = new Speaker
            {
                Id = id,
                Name = name,
                Location = location,
            };

            fakeRepository.Speakers.Add(speaker);

            return speaker;
        }

        public static Speaker IsDeleted(this Speaker speaker)
        {
            speaker.IsDeleted = true;

            return speaker;
        }
    }
}