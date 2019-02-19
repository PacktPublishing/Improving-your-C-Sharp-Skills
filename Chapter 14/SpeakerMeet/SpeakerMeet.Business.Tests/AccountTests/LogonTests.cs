using System.Security.Cryptography;
using System.Text;
using SpeakerMeet.Services.Tests;
using Xunit;

namespace SpeakerMeet.Business.Tests.AccountTests
{
    public class LogonTests
    {
        private readonly string _accessKey;
        private readonly Account _account;

        public LogonTests()
        {
            _accessKey = "GrantedAccessKey";
            var repository = new FakeRepository<UserCredentials>();
            _account = new AccountTestDouble(repository);

            repository.DataSet.Add(new UserCredentials
            {
                Username = "ValidUser@email.com",
                PasswordHash = SHA512.Create().ComputeHash(Encoding.ASCII.GetBytes("ValidPassword"))
            });
        }

        [Fact]
        public void GivenAnInvalidUsername()
        {
            // Arrange/Given
            var username = "InvalidUser@email.com";
            var password = "UnimportantPassword";

            // Act/When
            var exception = Record.Exception(() => _account.Logon(username, password));

            // Assert/Then
            Assert.IsAssignableFrom<InvalidUsernameOrPasswordException>(exception);
            Assert.Equal("Invalid Username or Password", exception.Message);
        }

        [Fact]
        public void GivenAValidUsernameAndPassword()
        {
            // Arrange/Given
            var username = "ValidUser@email.com";
            var password = "ValidPassword";

            // Act/When
            var result = _account.Logon(username, password);

            // Assert/Then
            Assert.IsAssignableFrom<string>(result);
            Assert.Equal(_accessKey, result);
        }

        [Fact]
        public void GivenAnInvalidPassword()
        {
            // Arrange/Given
            var username = "ValidUser@email.com";
            var password = "InvalidPassword";

            // Act/When
            var exception = Record.Exception(() => _account.Logon(username, password));

            // Assert/Then
            Assert.IsAssignableFrom<InvalidUsernameOrPasswordException>(exception);
            Assert.Equal("Invalid Username or Password", exception.Message);
        }
    }
}
