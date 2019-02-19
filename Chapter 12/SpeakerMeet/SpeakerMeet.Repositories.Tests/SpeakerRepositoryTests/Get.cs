using SpeakerMeet.Exceptions;
using SpeakerMeet.Models;
using Xunit;

namespace SpeakerMeet.Repositories.Tests.SpeakerRepositoryTests
{
    [Trait("Category", "SpeakerRepository")]
    public class Get
    {
        private readonly SpeakerRepository _repo;

        public Get()
        {
            _repo = new SpeakerRepository();
        }

        [Fact]
        public void ItHasGetMethod()
        {
            // Arrange
            // Act
            var result = _repo.Get(0);
        }

        [Fact(Skip = "Replaced in favor of null object")]
        public void ItThrowsWhenSpeakerIsNotFound()
        {
            // Arrange
            // Act
            var result = Record.Exception(() => _repo.Get(-1));

            // Assert
            Assert.IsType<SpeakerNotFoundException>(result.GetBaseException());
        }

        [Fact(Skip = "Can't fail")]
        public void ItReturnsNullWhenNotFound()
        {
            // Arrange
            // Act
            var result = _repo.Get(-1);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void ItReturnsASpeakerWhenFound()
        {
            // Arrange
            var speaker = _repo.Create(new Speaker { Name = "Test Speaker" });

            // Act
            var result = _repo.Get(speaker.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Speaker", result.Name);
        }

        [Fact]
        public void ItProtectsAgainstObjectChanges()
        {
            // Arrange
            var speaker = _repo.Create(new Speaker { Name = "Test Speaker" });
            var retrievedSpeaker = _repo.Get(speaker.Id);
            retrievedSpeaker.Name = "New Speaker Name";

            // Act
            var result = _repo.Get(speaker.Id);

            // Assert
            Assert.NotEqual(retrievedSpeaker.Name, result.Name);
        }
    }
}
