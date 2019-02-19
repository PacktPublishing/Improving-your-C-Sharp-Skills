using System;
using Xunit;

namespace HelloWorld
{
    public class HelloWorldTests
    {
        [Theory]
        [InlineData(12)]
        [InlineData(13)]
        [InlineData(14)]
        [InlineData(15)]
        [InlineData(16)]
        [InlineData(17)]
        [InlineData(18)]
        [InlineData(19)]
        [InlineData(20)]
        [InlineData(21)]
        [InlineData(22)]
        [InlineData(23)]
        public void GivenAfternoon_ThenAfternoonMessage(int hour)
        {
            // Arrange
            var afternoonTime = new TestTimeManager();
            afternoonTime.SetDateTime(new DateTime(2017, 7, 13, hour, 0, 0));
            var messageUtility = new MessageUtility(afternoonTime);

            // Act
            var message = messageUtility.GetMessage();

            // Assert
            Assert.Equal("Good afternoon", message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(11)]
        public void GivenMorning_ThenMorningMessage(int hour)
        {
            // Arrange
            var morningTime = new TestTimeManager();
            morningTime.SetDateTime(new DateTime(2017, 7, 13, hour, 0, 0));
            var messageUtility = new MessageUtility(morningTime);

            // Act
            var message = messageUtility.GetMessage();

            // Assert
            Assert.Equal("Good morning", message);
        }
    }
}
