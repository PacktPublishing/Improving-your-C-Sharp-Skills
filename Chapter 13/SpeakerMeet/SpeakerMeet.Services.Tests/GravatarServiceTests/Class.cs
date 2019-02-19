using SpeakerMeet.Services.Interfaces;
using Xunit;

namespace SpeakerMeet.Services.Tests.GravatarServiceTests
{
    public class Class
    {
        [Fact]
        public void ItExists()
        {
            var gravatarService = new GravatarService();
        }

        [Fact]
        public void ItImplementsIGravatarInterface()
        {
            // Arrange
            // Act
            var gravatarService = new GravatarService();

            // Assert
            Assert.IsAssignableFrom<IGravatarService>(gravatarService);
        }
    }
}
