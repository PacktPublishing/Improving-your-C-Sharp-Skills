using SpeakerMeet.DTO;
using SpeakerMeet.Exceptions;
using SpeakerMeet.Repositories;
using SpeakerMeet.Repositories.Interfaces;
using SpeakerMeet.Services;
using SpeakerMeet.Services.Interfaces;
using Xunit;
using Speaker = SpeakerMeet.Models.Speaker;

namespace SpeakerMeet.Api.IntegrationTest.ServiceTests.SpeakerServiceTests
{
    [Collection("Service")]
    [Trait("Category", "Integration")]
    public class Get : IClassFixture<ContextFixture>
    {
        private readonly IRepository<Speaker> _repository;
        private readonly IGravatarService _gravatarService;

        public Get(ContextFixture fixture)
        {
            _repository = new Repository<Speaker>(fixture.Context);
            _gravatarService = new GravatarService();
        }

        [Fact]
        public void GivenSpeakerNotFoundThenSpeakerNotFoundException()
        {
            // Arrange
            var speakerService = new SpeakerService(_repository, _gravatarService);

            // Act
            var exception = Record.Exception(() => speakerService.Get(-1));

            // Assert
            Assert.IsAssignableFrom<SpeakerNotFoundException>(exception);
        }

        [Fact]
        public void GivenSpeakerFoundThenSpeakerDetailReturned()
        {
            // Arrange
            var speakerService = new SpeakerService(_repository, _gravatarService);

            // Act
            var speaker = speakerService.Get(1);

            // Assert
            Assert.NotNull(speaker);
            Assert.IsAssignableFrom<SpeakerDetail>(speaker);
        }
    }
}
