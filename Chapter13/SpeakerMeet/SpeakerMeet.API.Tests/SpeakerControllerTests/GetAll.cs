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
    [Collection("SpeakerController")]
    [Trait("Category", "SpeakerController")]
    public class GetAll
    {
        private readonly SpeakerController _controller;
        private static Mock<ISpeakerService> _speakerServiceMock;
        private readonly List<SpeakerSummary> _speakers;

        public GetAll()
        {
            _speakers = new List<SpeakerSummary> { new SpeakerSummary
            {
                Name = "test"
            } };

            _speakerServiceMock = new Mock<ISpeakerService>();
            _speakerServiceMock.Setup(x => x.GetAll())
                .Returns(() => _speakers);

            _controller = new SpeakerController(_speakerServiceMock.Object);
        }

        [Fact]
        public void ItReturnsOkObjectResult()
        {
            // Arrange
            // Act
            var result = _controller.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void ItReturnsCollectionOfSpeakerSummary()
        {
            // Arrange
            // Act
            var result = _controller.GetAll() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.IsAssignableFrom<IEnumerable<SpeakerSummary>>(result.Value);
        }

        [Fact]
        public void ItCallsGetAllServiceOnce()
        {
            // Arrange
            // Act
            _controller.GetAll();

            // Assert
            _speakerServiceMock.Verify(mock => mock.GetAll(), Times.Once());
        }

        [Fact]
        public void GivenSpeakerServiceThenResultsReturned()
        {
            // Arrange
            // Act
            var result = _controller.GetAll() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            var speakers = ((IEnumerable<SpeakerSummary>)result.Value).ToList();
            Assert.Equal(_speakers, speakers);
        }
    }
}
