using System.Linq;
using Xunit;

namespace MastermindGame.Tests
{
    public class WriteTests
    {
        [Fact]
        public void ItCanBeWrittenTo()
        {
            var inout = new MockInputOutput();

            // Act
            inout.Write("Text");
        }

        [Fact]
        public void WrittenTextCanBeRetrieved()
        {
            // Arrange
            var inout = new MockInputOutput();
            inout.Write("Text");

            // Act    
            var writtenText = inout.OutFeed;

            // Assert
            Assert.Single(writtenText);
            Assert.Equal("Text", writtenText.First());
        }
    }
}