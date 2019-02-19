using System.Linq;
using SpeakerMeet.Models;
using Xunit;

namespace SpeakerMeet.Repositories.Tests.SpeakerRepositoryTests
{
    [Trait("Category", "SpeakerRepository")]
    public class GetAll
    {
        [Fact]
        public void ItHasGetAllMethod()
        {
            // Arrange  
            var repo = new SpeakerRepository();

            // Act
            var result = repo.GetAll();
        }

        [Fact]
        public void ItReturnsNoSpeakersWhenThereAreNoSpeakers()
        {
            // Arrange
            var repo = new SpeakerRepository();

            // Act
            var result = repo.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IQueryable<Speaker>>(result);
            Assert.Equal(0, result.Count());
        }

        [Fact]
        public void ItReturnsASingleSpeakerWhenOnlyOneSpeakerExists()
        {
            // Arrange
            var repo = new SpeakerRepository();
            repo.Create(new Speaker { Name = "Test Speaker" });

            // Act
            // Act
            var result = repo.GetAll().ToList();

            // Assert
            Assert.Single(result);
            Assert.Equal("Test Speaker", result.First().Name);
        }

        [Fact]
        public void ItReturnsManySpeakersWhenManySpeakersExists()
        {
            // Arrange
            var repo = new SpeakerRepository();
            repo.Create(new Speaker());
            repo.Create(new Speaker());
            repo.Create(new Speaker());

            // Act
            var result = repo.GetAll().ToList();

            // Assert
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void ItProtectsAgainstObjectChanges()
        {
            // Arrange
            var repo = new SpeakerRepository();
            repo.Create(new Speaker { Name = "Test Name" });
            var speakers = repo.GetAll().ToList();
            speakers.First().Name = "New Name";

            // Act
            var result = repo.GetAll();

            // Assert
            Assert.NotEqual(speakers.First().Name, result.First().Name);
        }
    }
}
