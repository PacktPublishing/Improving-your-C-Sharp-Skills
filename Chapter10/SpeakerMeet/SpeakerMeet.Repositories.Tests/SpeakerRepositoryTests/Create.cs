using System.Linq;
using SpeakerMeet.Models;
using Xunit;

namespace SpeakerMeet.Repositories.Tests.SpeakerRepositoryTests
{
    [Trait("Category", "SpeakerRepository")]
    public class Create
    {
        private readonly TestableSpeakerRepository _repo;

        public Create()
        {
            _repo = new TestableSpeakerRepository();
        }

        [Fact]
        public void ItHasCreateMethod()
        {
            // Act
            var result = _repo.Create(new Speaker());
        }

        [Fact]
        public void ItAddsASpeakerToTheRepository()
        {
            // Arrange
            // Act
            var result = _repo.Create(new Speaker());

            // Assert
            Assert.Equal(1, _repo.SpeakersCollection.Count);
        }

        [Fact]
        public void ItAssignsUniqueIdsToEachSpeaker()
        {
            // Arrange
            // Act
            var speaker1 = _repo.Create(new Speaker());
            var speaker2 = _repo.Create(new Speaker());

            // Assert
            Assert.NotEqual(speaker1.Id, speaker2.Id);
        }

        [Fact]
        public void ItReturnsANewSpeaker()
        {
            // Arrange
            var speaker = new Speaker { Id = 0 };

            // Act
            var result = _repo.Create(speaker);

            // Assert
            Assert.Equal(0, speaker.Id);
        }

        [Fact]
        public void ItProtectsAgainstObjectChangesAfterCreation()
        {
            // Arrange
            var speaker = _repo.Create(new Speaker());

            // Act
            speaker.Name = "test name";

            // Audit
            var result = _repo.SpeakersCollection.First();

            // Assert
            Assert.NotEqual("test name", result.Name);
        }
    }
}
