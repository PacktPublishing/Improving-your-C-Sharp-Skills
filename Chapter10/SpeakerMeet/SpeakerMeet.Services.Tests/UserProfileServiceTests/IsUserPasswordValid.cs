using System.Security.Cryptography;
using System.Text;
using SpeakerMeet.DTO;
using Xunit;

namespace SpeakerMeet.Services.Tests.UserProfileServiceTests
{
    public class IsUserPasswordValid
    {
        private readonly UserProfileService _service;
        private readonly UserProfileDto _profile;

        public IsUserPasswordValid()
        {
            // Arrange
            var repository = new FakeRepository<UserProfileDto>();
            _service = new UserProfileService(repository);
            _profile = new UserProfileDto
            {
                Username = "ValidUser@email.com",
                // This should be an encryption helper utility. Try to write and test a utility to replace this code.
                PasswordHash = SHA512.Create().ComputeHash(Encoding.ASCII.GetBytes("ValidPassword"))
            };

            repository.DataSet.Add(_profile);
        }

        [Fact]
        public void ItReturnsFalseForInvalidPasswords()
        {
            // Act
            var result = _service.IsUserPasswordValid(_profile, "InvalidPassword");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ItReturnsTrueForValidPasswords()
        {
            // Act
            var result = _service.IsUserPasswordValid(_profile, "ValidPassword");

            // Assert
            Assert.True(result);
        }
    }
}
