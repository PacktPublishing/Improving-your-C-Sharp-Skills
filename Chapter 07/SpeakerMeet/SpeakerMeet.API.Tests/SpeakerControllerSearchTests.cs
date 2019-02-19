using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SpeakerMeet.API.Controllers;
using Xunit;

namespace SpeakerMeet.API.Tests
{
    public class SpeakerControllerSearchTests
    {
        private readonly SpeakerController _controller;

        public SpeakerControllerSearchTests()
        {
            _controller = new SpeakerController();
        }

        [Fact(Skip="No longer needed")]
        public void ItExists()
        {
            var controller = new SpeakerController();
        }

        [Fact(Skip = "No longer needed")]
        public void ItHasSearch()
        {
            // Arrange
            var controller = new SpeakerController();

            // Act
            controller.Search("Jos");
        }

        [Fact(Skip = "No longer needed")]
        public void ItReturnsOkObjectResult()
        {
            // Arrange
            var controller = new SpeakerController();

            // Act
            var result = controller.Search("Jos");

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void ItReturnsCollectionOfSpeakers()
        {
            // Arrange
            var controller = new SpeakerController();

            // Act
            var result = controller.Search("Jos") as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.IsType<List<Speaker>>(result.Value);
        }

        [Fact]
        public void GivenExactMatchThenOneSpeakerInCollection()
        {
            // Arrange
            // Act
            var result = _controller.Search("Joshua") as OkObjectResult;

            // Assert  
            var speakers = ((IEnumerable<Speaker>)result.Value).ToList();
            Assert.Equal(1, speakers.Count);
            Assert.Equal("Joshua", speakers[0].Name);
        }

        [Theory]
        [InlineData("Joshua")]
        [InlineData("joshua")]
        [InlineData("JoShUa")]
        public void GivenCaseInsensitveMatchThenSpeakerInCollection(string searchString)
        {
            // Arrange
            // Act
            var result = _controller.Search(searchString) as OkObjectResult;

            // Assert
            var speakers = ((IEnumerable<Speaker>)result.Value).ToList();
            Assert.Equal(1, speakers.Count);
            Assert.Equal("Joshua", speakers[0].Name);
        }

        [Fact]
        public void GivenNoMatchThenEmptyCollection()
        {
            // Arrange
            // Act
            var result = _controller.Search("ZZZ") as OkObjectResult;

            // Assert
            var speakers = ((IEnumerable<Speaker>)result.Value).ToList();
            Assert.Equal(0, speakers.Count);
        }

        [Fact]
        public void Given3MatchThenCollectionWith3Speakers()
        {
            // Arrange
            // Act 
            var result = _controller.Search("jos") as OkObjectResult;

            // Assert  
            var speakers = ((IEnumerable<Speaker>)result.Value).ToList();
            Assert.Equal(3, speakers.Count);
            Assert.True(speakers.Any(s => s.Name == "Josh"));
            Assert.True(speakers.Any(s => s.Name == "Joshua"));
            Assert.True(speakers.Any(s => s.Name == "Joseph"));
        }
    }
}
