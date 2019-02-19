using SpeakerMeet.Exceptions;
using SpeakerMeet.Services.Tests.Factories;
using SpeakerMeet.Services.Tests.Fakes;
using Xunit;

namespace SpeakerMeet.Services.Tests.SpeakerServiceTests
{
    [Trait("Category", "SpeakerService")]
    public class Get
    {
        private readonly FakeRepository _fakeRepository;
        private readonly FakeGravatarService _fakeGravatarService;

        public Get()
        {
            _fakeRepository = new FakeRepository();
            _fakeGravatarService = new FakeGravatarService();
        }

        [Theory]
        [InlineData(1, "Joshua")]
        [InlineData(2, "Bill")]
        [InlineData(3, "Suzie")]
        public void ItReturnsSpeakerFromRepository(int id, string name)
        {
            // Arrange
            var expectedSpeaker = SpeakerFactory.Create(_fakeRepository, id, name);
            var service = new SpeakerService(_fakeRepository, _fakeGravatarService);

            // Act
            var actualSpeaker = service.Get(expectedSpeaker.Id);

            // Assert
            Assert.True(_fakeRepository.GetCalled);
            Assert.Equal(expectedSpeaker.Id, actualSpeaker.Id);
            Assert.Equal(expectedSpeaker.Name, actualSpeaker.Name);
        }

        [Fact]
        public void GivenSpeakerNotFoundThenSpeakerNotFoundException()
        {
            // Arrange
            var service = new SpeakerService(_fakeRepository, _fakeGravatarService);

            // Act
            var exception = Record.Exception(() => service.Get(-1));

            // Assert
            Assert.IsAssignableFrom<SpeakerNotFoundException>(exception);
        }

        [Fact]
        public void GivenSpeakerIsDeletedThenSpeakerNotException()
        {
            // Arrange
            var expectedSpeaker = SpeakerFactory.Create(_fakeRepository).IsDeleted();
            var service = new SpeakerService(_fakeRepository, _fakeGravatarService);

            // Act
            var exception = Record.Exception(() => service.Get(expectedSpeaker.Id));

            // Assert
            Assert.IsAssignableFrom<SpeakerNotFoundException>(exception);
        }

        [Fact]
        public void GivenSpeakerIsDeletedThenSpeakerNotFoundException()
        {
            // Arrange
            var expectedSpeaker = SpeakerFactory.Create(_fakeRepository).IsDeleted();
            var service = new SpeakerService(_fakeRepository, _fakeGravatarService);

            // Act
            var exception = Record.Exception(() => service.Get(expectedSpeaker.Id));

            // Assert
            Assert.IsAssignableFrom<SpeakerNotFoundException>(exception);
        }

        [Fact]
        public void GivenSpeakerReturnsSpeakerWithProperties()
        {
            // Arrange
            var expectedSpeaker = SpeakerFactory.Create(_fakeRepository);
            var service = new SpeakerService(_fakeRepository, _fakeGravatarService);

            // Act
            var speaker = service.Get(1);

            // Assert
            Assert.Equal(expectedSpeaker.Id, speaker.Id);
            Assert.Equal(expectedSpeaker.Name, speaker.Name);
        }

        [Fact]
        public void ItCallsRepository()
        {
            // Arrange
            var expectedSpeaker = SpeakerFactory.Create(_fakeRepository);
            var service = new SpeakerService(_fakeRepository, _fakeGravatarService);

            // Act
            service.Get(expectedSpeaker.Id);

            // Assert
            Assert.True(_fakeRepository.GetCalled);
        }

        [Fact]
        public void ItReturnsSpeakerFromRepository()
        {
            // Arrange
            var fakeRepository = new FakeRepository();
            var expectedSpeaker = SpeakerFactory.Create(fakeRepository, 2, "Bill");
            var service = new SpeakerService(fakeRepository, _fakeGravatarService);

            // Act
            var actualSpeaker = service.Get(expectedSpeaker.Id);

            // Assert
            Assert.True(fakeRepository.GetCalled);
            Assert.Equal(expectedSpeaker.Id, actualSpeaker.Id);
            Assert.Equal(expectedSpeaker.Name, actualSpeaker.Name);
        }

        [Fact]
        public void ItCallsGravatarService()
        {
            // Arrange
            var expectedSpeaker = SpeakerFactory.Create(_fakeRepository);
            var service = new SpeakerService(_fakeRepository, _fakeGravatarService);

            // Act
            service.Get(expectedSpeaker.Id);

            // Assert
            Assert.True(_fakeGravatarService.WithEmailCalled);
        }

        [Fact]
        public void ItCallsGravatarServiceWithEmail()
        {
            // Arrange
            var expectedSpeaker = SpeakerFactory.Create(_fakeRepository, emailAddress: "example@test.com");
            var service = new SpeakerService(_fakeRepository, _fakeGravatarService);

            // Act
            service.Get(expectedSpeaker.Id);

            // Assert
            Assert.True(_fakeGravatarService.WithEmailCalled);
            Assert.Equal(expectedSpeaker.EmailAddress, _fakeGravatarService.CalledWith);
        }

        [Fact]
        public void GivenGravatarServiceThenItSetsGravatar()
        {
            // Arrange
            var expectedSpeaker = SpeakerFactory.Create(_fakeRepository);
            var service = new SpeakerService(_fakeRepository, _fakeGravatarService);

            // Act
            var actualSpeaker = service.Get(expectedSpeaker.Id);
            var expectedGravatar = _fakeGravatarService.GetGravatar(expectedSpeaker.EmailAddress);

            // Assert
            Assert.True(_fakeGravatarService.WithEmailCalled);
            Assert.Equal(expectedSpeaker.Id, actualSpeaker.Id);
            Assert.Equal(expectedSpeaker.Name, actualSpeaker.Name);
            Assert.Equal(expectedGravatar, actualSpeaker.Gravatar);
        }
    }
}