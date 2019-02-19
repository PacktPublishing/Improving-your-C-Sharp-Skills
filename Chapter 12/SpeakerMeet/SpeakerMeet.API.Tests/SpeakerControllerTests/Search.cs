using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SpeakerMeet.API.Controllers;
using SpeakerMeet.DTO;
using SpeakerMeet.Services.Interfaces;
using Xunit;

namespace SpeakerMeet.API.Tests.SpeakerControllerTests
{
    public class Search
    {
        private readonly SpeakerController _controller;
        private static Mock<ISpeakerService> _speakerServiceMock;
        private readonly List<Speaker> _speakers;

        public Search()
        {
            _speakers = new List<Speaker> { new Speaker
            {
                Name = "test"
            } };

            // define the mock
            _speakerServiceMock = new Mock<ISpeakerService>();

            // when search is called, return list of speakers containing speaker
            _speakerServiceMock.Setup(x => x.Search(It.IsAny<string>()))
                .Returns(() => _speakers);

            // pass mock object as ISpeakerService
            _controller = new SpeakerController(_speakerServiceMock.Object);
        }

        [Fact]
        public void ItReturnsCollectionOfSpeakers()
        {
            // Arrange
            // Act
            var result = _controller.Search("Jos") as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.IsType<List<Speaker>>(result.Value);
        }

        [Fact(Skip = "No longer needed")]
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

        [Theory(Skip = "No longer needed")]
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

        [Fact(Skip = "No longer needed")]
        public void GivenNoMatchThenEmptyCollection()
        {
            // Arrange
            // Act
            var result = _controller.Search("ZZZ") as OkObjectResult;

            // Assert
            var speakers = ((IEnumerable<Speaker>)result.Value).ToList();
            Assert.Equal(0, speakers.Count);
        }

        [Fact(Skip = "No longer needed")]
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

        [Fact(Skip = "No longer needed")]
        public void ItAcceptsInterface()
        {
            // Arrange 
            ISpeakerService testSpeakerService = new TestSpeakerService();

            // Act
            var controller = new SpeakerController(testSpeakerService);

            // Assert
            Assert.NotNull(controller);
        }

        [Fact(Skip = "No longer needed")]
        public void ItCallsSearchServiceOnce()
        {
            // Arrange
            // Act
            _controller.Search("jos");

            // Assert
            _speakerServiceMock.Verify(mock => mock.Search(It.IsAny<string>()),
                Times.Once());
        }

        [Fact]
        public void GivenSearchStringThenSpeakerServiceSearchCalledWithString()
        {
            // Arrange
            var searchString = "jos";

            // Act
            _controller.Search(searchString);

            // Assert
            _speakerServiceMock.Verify(mock => mock.Search(searchString),
                Times.Once());
        }

        [Fact]
        public void GivenSpeakerServiceThenResultsReturned()
        {
            // Arrange
            var searchString = "jos";

            // Act 
            var result = _controller.Search(searchString) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            var speakers = ((IEnumerable<Speaker>)result.Value).ToList();
            Assert.Equal(_speakers, speakers);
        }
    }
}
