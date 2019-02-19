using SpeakerMeet.Services.Interfaces;
using Xunit;

namespace SpeakerMeet.Services.Tests.GravatarServiceTests
{
    [Trait("Category", "Integration")]
    public class GetGravatar
    {
        [Fact]
        public void ItHasGetGravatarMethod()
        {
            // Arrange
            IGravatarService gravatarService = new GravatarService();

            // Act
            gravatarService.GetGravatar("example@test.com");
        }

        [Fact]
        public void GivenEmailAddressThenGravatarReturned()
        {
            // Arrange
            IGravatarService gravatarService = new GravatarService();

            // Act
            var actual = gravatarService.GetGravatar("example@test.com");

            // Assert
            Assert.Equal("http://www.gravatar.com/avatar/29e3f53ee49fae541ee0f48fb712c231", actual);
        }
    }
}
