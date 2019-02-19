using Xunit;

namespace MastermindGame.Tests
{
    public class ReadTests
    {
        [Fact]
        public void ItCanBeReadFrom()
        {
            var inout = new MockInputOutput();
            inout.InFeed.Enqueue("T");

            // Act
            var input = inout.Read();
        }

        [Fact]
        public void ProvidedInputCanBeRetrieved()
        {
            // Arrange
            var inout = new MockInputOutput();
            inout.InFeed.Enqueue("T");

            // Act
            var input = inout.Read();

            // Assert
            Assert.Equal('T', input);
        }

        [Fact]
        public void ProvidedInputCanBeRetrievedInSuccession()
        {
            // Arrange
            var inout = new MockInputOutput();
            inout.InFeed.Enqueue("T");
            inout.InFeed.Enqueue("E");

            // Act
            var input1 = inout.Read();
            var input2 = inout.Read();

            // Assert
            Assert.Equal('T', input1);
            Assert.Equal('E', input2);
        }
    }
}