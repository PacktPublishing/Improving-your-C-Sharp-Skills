using Microsoft.AspNetCore.Mvc;
using Moq;
using SpeakerMeet.API.Controllers;
using SpeakerMeet.DTO;
using SpeakerMeet.Exceptions;
using SpeakerMeet.Services.Interfaces;
using Xunit;

namespace SpeakerMeet.API.Tests.SpeakerControllerTests
{
    [Trait("Category", "SpeakerController")]
    public class Get
    {
        private readonly SpeakerController _controller;
        private static Mock<ISpeakerService> _speakerServiceMock;
        private readonly SpeakerDetail _speaker;

        public Get()
        {
            _speaker = new SpeakerDetail
            {
                Name = "Speaker"
            };

            _speakerServiceMock = new Mock<ISpeakerService>();
            _speakerServiceMock.Setup(x => x.Get(It.IsAny<int>()))
                .Returns(() => _speaker);
            _speakerServiceMock.Setup(x => x.Get(-1))
                .Returns(() => throw new SpeakerNotFoundException(-1));

            _controller = new SpeakerController(_speakerServiceMock.Object);
        }

        [Fact]
        public void ItAcceptsInteger()
        {
            // Arrange
            // Act
            _controller.Get(1);
        }

        [Fact]
        public void ItReturnsOkObjectResult()
        {
            // Arrange
            // Act
            var result = _controller.Get(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void ItReturnsSpeakerDetail()
        {
            // Arrange
            // Act
            var result = _controller.Get(1) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.IsType<SpeakerDetail>(result.Value);
        }

        [Fact]
        public void ItCallsGetServiceOnce()
        {
            // Arrange
            // Act
            _controller.Get(1);

            // Assert
            _speakerServiceMock.Verify(mock => mock.Get(It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public void ItCallsGetServiceWithProvidedId()
        {
            // Arrange
            const int id = 1;

            // Act
            _controller.Get(id);

            // Assert
            _speakerServiceMock.Verify(mock => mock.Get(id), Times.Once());
        }

        [Fact]
        public void GivenSpeakerServiceThenResultsReturned()
        {
            // Arrange
            // Act
            var result = _controller.Get(1) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            var speaker = ((SpeakerDetail)result.Value);
            Assert.Equal(_speaker, speaker);
        }

        [Fact]
        public void GivenSpeakerNotFoundExceptionThenNotFoundObjectResult()
        {
            // Arrange
            // Act
            var result = _controller.Get(-1);

            // Assert
            Assert.IsAssignableFrom<NotFoundObjectResult>(result);
        }

        [Fact]
        public void GivenSpeakerNotFoundExceptionThenMessageReturned()
        {
            // Arrange
            // Act
            var result = _controller.Get(-1) as NotFoundObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Speaker -1 not found.", result.Value);
        }
    }
}
