using System;
using System.Linq;
using Xunit;

namespace MastermindGame.Tests
{
    public class WriteLineTests
    {
        [Fact]
        public void ItCanBeWrittenTo()
        {
            var inout = new MockInputOutput();

            // Act
            inout.WriteLine("Text");
        }

        [Fact]
        public void WrittenTextCanBeRetrieved()
        {
            // Arrange
            var inout = new MockInputOutput();
            inout.WriteLine("Text");

            // Act
            var writtenText = inout.OutFeed;

            // Assert
            Assert.Single(writtenText);
            Assert.Equal("Text" + Environment.NewLine, writtenText.First());
        }

        [Fact]
        public void ItCanWriteABlankLine()
        {
            // Arrange
            var inout = new MockInputOutput();

            // Act
            inout.WriteLine();

            // Assert
            Assert.Single(inout.OutFeed);
            Assert.Equal(Environment.NewLine, inout.OutFeed.First());
        }
    }
}