using Microsoft.EntityFrameworkCore;
using SpeakerMeet.Models;
using SpeakerMeet.Repositories;
using Xunit;
using Speaker = SpeakerMeet.DTO.Speaker;
using System.Linq;

namespace SpeakerMeet.Api.IntegrationTest.RepositoryTests
{
    [Collection("Repository")]
    [Trait("Category", "Integration")]
    public class GetAll
    {
        private readonly DbContextOptions<SpeakerMeetContext> _options;

        public GetAll()
        {
            _options = new DbContextOptionsBuilder<SpeakerMeetContext>()
                .UseInMemoryDatabase("SpeakerMeetInMemory")
                .Options;
        }

        [Fact]
        public void ItExists()
        {
            var options = new DbContextOptionsBuilder<SpeakerMeetContext>()
                .UseInMemoryDatabase("SpeakerMeetInMemory")
                .Options;

            var context = new SpeakerMeetContext(options);

            var repository = new Repository<Speaker>(context);
        }

        [Fact]
        public void GivenSpeakersThenQueryableSpeakersReturned()
        {
            using (var context = new SpeakerMeetContext(_options))
            {
                // Arrange
                var repository = new Repository<Speaker>(context);

                // Act
                var speakers = repository.GetAll();

                // Assert
                Assert.NotNull(speakers);
                Assert.IsAssignableFrom<IQueryable<Speaker>>(speakers);
            }
        }
    }
}
