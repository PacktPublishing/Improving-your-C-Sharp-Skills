using System.Collections.Generic;
using SpeakerMeet.DTO;
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
    public class GetAll : IClassFixture<ContextFixture>
    {
        private readonly IRepository<Speaker> _repository;
        private readonly IGravatarService _gravatarService;

        public GetAll(ContextFixture fixture)
        {
            _repository = new Repository<Speaker>(fixture.Context);
            _gravatarService = new GravatarService();
        }

        [Fact]
        public void ItExists()
        {
            var speakerService = new SpeakerService(_repository, _gravatarService);
        }

        [Fact]
        public void ItReturnsCollectionOfSpeakerSummary()
        {
            // Arrange
            var speakerService = new SpeakerService(_repository, _gravatarService);

            // Act
            var speakers = speakerService.GetAll();

            // Assert
            Assert.NotNull(speakers);
            Assert.IsAssignableFrom<IEnumerable<SpeakerSummary>>(speakers);
        }
    }
}
