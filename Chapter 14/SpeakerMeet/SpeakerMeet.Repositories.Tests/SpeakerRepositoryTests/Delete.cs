using SpeakerMeet.Models;
using SpeakerMeet.Repositories.Interfaces;
using Xunit;

namespace SpeakerMeet.Repositories.Tests.SpeakerRepositoryTests
{
    [Trait("Category", "SpeakerRepository")]
    public class Delete
    {
        [Fact]
        public void ItHasDeleteMethod()
        {
            // Arrange
            IRepository<Speaker> repo = new SpeakerRepository();
            var speaker = new Speaker();

            // Act
            repo.Delete(speaker);
        }

        [Fact]
        public void ItMarksTheGivenSpeakerAsDeleted()
        {
            // Arrange
            var repo = new SpeakerRepository();
            var speaker = repo.Create(new Speaker { Name = "Test Name" });

            // Act
            repo.Delete(speaker);

            // Audit
            var result = repo.Get(speaker.Id);

            // Assert
            Assert.True(result.IsDeleted);
        }

        [Fact]
        public void ItDoesNothingWhenDeletingANonexistingSpeaker()
        {
            // Arrange
            var repo = new SpeakerRepository();
            var speaker = new Speaker();

            // Act
            var result = Record.Exception(() => repo.Delete(speaker));

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void ItProtectsAgainstPassedObjectChanges()
        {
            // Arrange
            var repo = new SpeakerRepository();
            var speaker = repo.Create(new Speaker { Name = "Test Name" });

            // Act
            repo.Delete(speaker);

            // Assert
            Assert.False(speaker.IsDeleted);
        }
    }
}
