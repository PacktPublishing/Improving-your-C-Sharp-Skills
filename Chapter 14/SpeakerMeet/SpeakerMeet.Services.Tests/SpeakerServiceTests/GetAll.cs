using System.Collections.Generic;
using System.Linq;
using SpeakerMeet.DTO;
using SpeakerMeet.Services.Interfaces;
using SpeakerMeet.Services.Tests.Factories;
using SpeakerMeet.Services.Tests.Fakes;
using Xunit;

namespace SpeakerMeet.Services.Tests.SpeakerServiceTests
{
    [Collection("SpeakerService")]
    [Trait("Category", "SpeakerService")]
    [Trait("Category", "SpeakerSummary")]
    public class GetAll
    {
        private readonly SpeakerService _speakerService;
        private readonly FakeRepository _fakeRepository;
        private readonly IGravatarService _fakeGravatarService;

        public GetAll()
        {
            _fakeRepository = new FakeRepository();
            _fakeGravatarService = new FakeGravatarService();
            SpeakerFactory.Create(_fakeRepository);

            _speakerService = new SpeakerService(_fakeRepository, _fakeGravatarService);
        }

        [Fact]
        public void ItReturnsCollectionOfSpeakerSummary()
        {
            // Arrange
            // Act
            var speakers = _speakerService.GetAll();

            // Assert
            Assert.NotNull(speakers);
            Assert.IsAssignableFrom<IEnumerable<SpeakerSummary>>(speakers);
        }

        [Fact]
        public void ItReturnsAllSpeakers()
        {
            // Arrange
            // Act
            var speakers = _speakerService.GetAll();

            // Assert
            Assert.NotNull(speakers);
            Assert.IsAssignableFrom<IEnumerable<SpeakerSummary>>(speakers);
            Assert.Equal(_fakeRepository.Speakers.Count, speakers.Count());
        }

        [Fact]
        public void ItReturnsAllSpeakersWithProperties()
        {
            // Arrange
            // Act
            var speakers = _speakerService.GetAll().ToList();

            // Assert
            Assert.NotNull(speakers);
            Assert.IsAssignableFrom<IEnumerable<SpeakerSummary>>(speakers);

            for (var i = 0; i < speakers.Count; i++)
            {
                Assert.NotNull(_fakeRepository.Speakers[i].Name);
                Assert.Equal(_fakeRepository.Speakers[i].Name, speakers[i].Name);
                Assert.NotNull(_fakeRepository.Speakers[i].Id);
                Assert.Equal(_fakeRepository.Speakers[i].Id, speakers[i].Id);
                Assert.NotNull(_fakeRepository.Speakers[i].Location);
                Assert.Equal(_fakeRepository.Speakers[i].Location, speakers[i].Location);
            }
        }

        [Fact]
        public void GivenSpeakerIsDeletedSpeakerIsNotReturned()
        {
            // Arrange
            var fakeRepository = new FakeRepository();
            SpeakerFactory.Create(fakeRepository).IsDeleted();
            var speakerService = new SpeakerService(fakeRepository, _fakeGravatarService);

            // Act
            var speakers = speakerService.GetAll().ToList();

            // Assert
            Assert.NotNull(speakers);
            Assert.IsAssignableFrom<IEnumerable<SpeakerSummary>>(speakers);
            Assert.Equal(0, speakers.Count);
        }
    }
}