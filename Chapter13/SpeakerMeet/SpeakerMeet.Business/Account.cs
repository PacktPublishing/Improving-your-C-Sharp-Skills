using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using SpeakerMeet.Repositories.Interfaces;

namespace SpeakerMeet.Business
{
    public class Account
    {
        private readonly IRepository<UserCredentials> _repository;

        public Account(IRepository<UserCredentials> repository)
        {
            _repository = repository;
        }

        public string Logon(string username, string password)
        {
            var user = _repository.GetAll().FirstOrDefault(u => u.Username == username);

            var hash = SHA512.Create().ComputeHash(Encoding.ASCII.GetBytes(password ?? ""));

            if (user == null || !user.PasswordHash.SequenceEqual(hash))
            {
                throw new InvalidUsernameOrPasswordException();
            }

            return GenerateAccessKey(user);
        }

        protected virtual string GenerateAccessKey(UserCredentials userCredentials)
        {
            // Here we would need to actually generate an access token
            return "DefaultKey";
        }
    }

    public class InvalidUsernameOrPasswordException : Exception
    {
        public InvalidUsernameOrPasswordException() : base("Invalid Username or Password")
        {
        }
    }
}
