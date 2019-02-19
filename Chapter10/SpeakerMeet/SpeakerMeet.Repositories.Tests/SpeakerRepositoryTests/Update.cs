using SpeakerMeet.Exceptions;
using SpeakerMeet.Models;
using SpeakerMeet.Repositories.Interfaces;
using Xunit;

namespace SpeakerMeet.Repositories.Tests.SpeakerRepositoryTests
{
    [Trait("Category", "SpeakerRepository")]
    public class Update
    {
        [Fact]
        public void ItHasUpdateMethod()
        {
            // Arrange
            IRepository<Speaker> repo = new SpeakerRepository();
            var speaker = repo.Create(new Speaker());

            // Act
            var result = repo.Update(speaker);
        }

        [Fact]
        public void ItUpdatesASpeaker()
        {
            // Arrange
            var repo = new SpeakerRepository();
            var speaker = repo.Create(new Speaker { Name = "Test Name" });
            speaker.Name = "New Name";

            // Act
            var result = repo.Update(speaker);

            // Assert
            Assert.Equal(speaker.Name, result.Name);
        }

        [Fact]
        public void ItUpdatesASpeakerInTheRepository()
        {
            // Arrange
            var repo = new SpeakerRepository();
            var speaker = repo.Create(new Speaker { Name = "Test Name" });
            speaker.Name = "New Name";

            // Act
            var updatedSpeaker = repo.Update(speaker);

            // Audit
            var result = repo.Get(speaker.Id);

            // Assert
            Assert.Equal("New Name", result.Name);
        }

        [Fact]
        public void ItThrowsNotFoundExceptionWhenSpeakerDoesNotExist()
        {
            // Arrange
            var repo = new SpeakerRepository();
            var speaker = new Speaker { Id = 5, Name = "Test Name" };

            // Act
            var result = Record.Exception(() => repo.Update(speaker));

            // Assert
            Assert.IsAssignableFrom<SpeakerNotFoundException>(result.GetBaseException());
        }

        [Fact]
        public void ItProtectsAgainstObjectChanges()
        {
            // Arrange
            var repo = new SpeakerRepository();
            var speaker = repo.Create(new Speaker { Name = "Test Name" });
            speaker.Name = "New Name";
            var updatedSpeaker = repo.Update(speaker);

            // Act
            updatedSpeaker.Name = "Updated Name";

            // Audit
            var result = repo.Get(updatedSpeaker.Id);

            // Assert
            Assert.NotEqual("Updated Name", result.Name);
        }

        [Fact]
        public void ItProtectsAgainstOriginalObjectChanges()
        {
            // Arrange
            var repo = new SpeakerRepository();
            var speaker = repo.Create(new Speaker { Name = "Test Name" });
            speaker.Name = "New Name";
            var updatedSpeaker = repo.Update(speaker);

            // Act
            speaker.Name = "Updated Name";

            // Audit
            var result = repo.Get(updatedSpeaker.Id);

            // Assert
            Assert.NotEqual("Updated Name", result.Name);
        }
    }
}
