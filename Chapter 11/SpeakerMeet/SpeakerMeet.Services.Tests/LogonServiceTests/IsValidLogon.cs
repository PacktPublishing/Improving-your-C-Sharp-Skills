using System.Security.Cryptography;
using System.Text;
using SpeakerMeet.DTO;
using Xunit;

namespace SpeakerMeet.Services.Tests.LogonServiceTests
{
    public class IsValidLogon
    {
        private readonly LogonService _service;

        public IsValidLogon()
        {
            var repository = new FakeRepository<UserLogonDto>();
            _service = new LogonService(repository);
            var userLogon = new UserLogonDto
            {
                Username = "ValidUser@email.com",
                PasswordHash = SHA512.Create().ComputeHash(Encoding.ASCII.GetBytes("ValidPassword"))
            };

            repository.DataSet.Add(userLogon);
        }

        [Fact]
        public void ItExists()
        {
            var repository = new FakeRepository<UserLogonDto>();
            var service = new LogonService(repository);
            var attempt = new LoginAttempt();

            service.IsLogonValid(attempt);
        }

        [Fact]
        public void ItReturnsTrueForValidAttempt()
        {
            // Arrange
            var attempt = new LoginAttempt
            {
                Username = "ValidUser@email.com",
                Password = "ValidPassword"
            };

            // Act
            var result = _service.IsLogonValid(attempt);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ItReturnsFalseForInvalidUsername()
        {
            // Arrange
            var attempt = new LoginAttempt
            {
                Username = "InvalidUser@email.com",
                Password = "ValidPassword"
            };

            // Act
            var result = _service.IsLogonValid(attempt);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ItReturnsFalseForInvalidPassword()
        {
            // Arrange
            var attempt = new LoginAttempt
            {
                Username = "ValidUser@email.com",
                Password = "InvalidPassword"
            };

            // Act
            var result = _service.IsLogonValid(attempt);

            // Assert
            Assert.False(result);
        }
    }
}
