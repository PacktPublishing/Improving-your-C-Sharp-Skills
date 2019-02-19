using Xunit;

namespace MastermindGame.Tests
{
    public class ReadLineTests
    {
        [Fact]
        public void ItCanBeReadFrom()
        {
            var inout = new MockInputOutput();
            inout.InFeed.Enqueue("Test");

            // Act
            var input = inout.ReadLine();
        }

        [Fact]
        public void ProvidedInputCanBeRetrieved()
        {
            // Arrange
            var inout = new MockInputOutput();
            inout.InFeed.Enqueue("Test");

            // Act
            var input = inout.ReadLine();

            // Assert
            Assert.Equal("Test", input);
        }

        [Fact]
        public void ProvidedInputCanBeRetrievedInSuccession()
        {
            // Arrange
            var inout = new MockInputOutput();
            inout.InFeed.Enqueue("Test 1");
            inout.InFeed.Enqueue("Test 2");

            // Act
            var input1 = inout.ReadLine();
            var input2 = inout.ReadLine();

            // Assert
            Assert.Equal("Test 1", input1);
            Assert.Equal("Test 2", input2);
        }
    }
}
