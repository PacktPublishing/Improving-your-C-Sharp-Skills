using SpeakerMeet.Services.Tests.Fakes;
using Xunit;

namespace SpeakerMeet.Services.Tests.SpeakerServiceTests
{
    public class Class
    {
        [Fact]
        public void ItAcceptsIRepository()
        {
            // Arrange
            var fakeRepository = new FakeRepository();
            var fakeGravatarService = new FakeGravatarService();

            // Act
            var service = new SpeakerService(fakeRepository, fakeGravatarService);

            // Assert
            Assert.NotNull(service);
        }
    }
}
