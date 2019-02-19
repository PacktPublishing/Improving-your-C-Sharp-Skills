using System.Net;
using Microsoft.AspNetCore.Mvc;
using SpeakerMeet.API.Controllers;
using SpeakerMeet.DTO;
using SpeakerMeet.Services.Interfaces;
using Xunit;

namespace SpeakerMeet.API.Tests.LogonControllerTests
{
    public class Post
    {
        private readonly ILogonService _logonService;

        public Post()
        {
            _logonService = new FakeLogonService();
        }

        [Fact]
        public void ItExists()
        {
            // Arrange
            var controller = new LogonController(_logonService);

            // Act
            var response = controller.Post(null);
        }

        [Fact]
        public void ItReturnsAnIActionResult()
        {
            // Arrange
            var controller = new LogonController(_logonService);

            // Act
            var response = controller.Post(null);

            // Assert
            Assert.IsAssignableFrom<IActionResult>(response);
        }

        [Fact]
        public void ItReturnsUnauthorizedForInvalidUser()
        {
            // Arrange
            var controller = new LogonController(_logonService);
            var attempt = new LoginAttempt
            {
                Username = "InvalidUser@email.com",
                Password = "BadPassword"
            };

            // Act
            var response = (ObjectResult)controller.Post(attempt);

            // Assert
            Assert.NotNull(response.StatusCode);
            Assert.Equal(HttpStatusCode.Unauthorized, (HttpStatusCode)response.StatusCode);
        }

        [Fact]
        public void ItReturnsOkForValidUser()
        {
            // Arrange
            var controller = new LogonController(_logonService);
            var attempt = new LoginAttempt
            {
                Username = "ValidUser@email.com",
                Password = "ValidPassword"
            };

            // Act
            var response = (ObjectResult)controller.Post(attempt);

            // Assert
            Assert.NotNull(response.StatusCode);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
        }

        [Fact]
        public void ItReturnsUnauthorizedForInvalidPassword()
        {
            // Arrange
            var controller = new LogonController(_logonService);
            var attempt = new LoginAttempt
            {
                Username = "ValidUser@email.com",
                Password = "InvalidPassword"
            };

            // Act
            var response = (ObjectResult)controller.Post(attempt);

            // Assert
            Assert.NotNull(response.StatusCode);
            Assert.Equal(HttpStatusCode.Unauthorized, (HttpStatusCode)response.StatusCode);
        }

        [Fact]
        public void ItReturnsSuccessfulLogonMessageWhenSuccessful()
        {
            // Arrange
            var controller = new LogonController(_logonService);
            var attempt = new LoginAttempt
            {
                Username = "ValidUser@email.com",
                Password = "ValidPassword"
            };

            // Act
            var response = (ObjectResult)controller.Post(attempt);

            // Assert
            Assert.Equal("Logon Successful", response.Value);
        }

        [Fact]
        public void ItReturnsUnauthorizedLogonMessageWhenUnauthorized()
        {
            // Arrange
            var controller = new LogonController(_logonService);
            var attempt = new LoginAttempt
            {
                Username = "InvalidUser@email.com",
                Password = "Password"
            };

            // Act
            var response = (ObjectResult)controller.Post(attempt);

            // Assert
            Assert.Equal("Username or Password invalid", response.Value);
        }
    }
}
