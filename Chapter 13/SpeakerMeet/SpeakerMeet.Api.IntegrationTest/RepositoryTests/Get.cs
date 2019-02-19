using System;
using Microsoft.EntityFrameworkCore;
using SpeakerMeet.Models;
using SpeakerMeet.Repositories;
using Xunit;

namespace SpeakerMeet.Api.IntegrationTest.RepositoryTests
{
    [Collection("Repository")]
    [Trait("Category", "Integration")]
    public class Get
    {
        private readonly DbContextOptions<SpeakerMeetContext> _options;

        public Get()
        {
            _options = new DbContextOptionsBuilder<SpeakerMeetContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using (var context = new SpeakerMeetContext(_options))
            {
                context.Speakers.Add(new Speaker { Id = 1, Name = "Test", Location = "Location" });
                context.SaveChanges();
            }
        }

        [Fact]
        public void GivenSpeakerNotFoundThenSpeakerNull()
        {
            using (var context = new SpeakerMeetContext(_options))
            {
                // Arrange
                var repository = new Repository<Speaker>(context);

                // Act
                var speaker = repository.Get(-1);

                // Assert
                Assert.Null(speaker);
            }
        }

        [Fact]
        public void GivenSpeakerFoundThenSpeakerReturned()
        {
            using (var context = new SpeakerMeetContext(_options))
            {
                // Arrange
                var repository = new Repository<Speaker>(context);

                // Act
                var speaker = repository.Get(1);

                // Assert
                Assert.NotNull(speaker);
                Assert.IsAssignableFrom<Speaker>(speaker);
            }
        }
    }
}
