using Xunit;

namespace SpeakerMeet.DTO.Tests
{
    public class UserProfileDtoTests
    {
        [Fact]
        public void ItExists()
        {
            var dto = new UserProfileDto();
        }

        [Fact]
        public void ItHasAnId()
        {
            // Arrange
            var dto = new UserProfileDto();
            dto.Id = 1;

            // Act
            // Assert
            Assert.Equal(1, dto.Id);
        }
    }
}
