using System.Linq;
using System.Security.Cryptography;
using System.Text;
using SpeakerMeet.DTO;
using SpeakerMeet.Repositories.Interfaces;

namespace SpeakerMeet.Services
{
    public class UserProfileService
    {
        private readonly IRepository<UserProfileDto> _repository;

        public UserProfileService(IRepository<UserProfileDto> repository)
        {
            _repository = repository;
        }

        public UserProfileDto GetUserProfile(string username)
        {
            return _repository.GetAll().FirstOrDefault(u => u.Username == username);
        }

        public bool IsUserPasswordValid(UserProfileDto profile, string password)
        {
            // Now we have the same code in production code as we do in our tests.
            var hash = SHA512.Create().ComputeHash(Encoding.ASCII.GetBytes(password));

            return profile.PasswordHash.SequenceEqual(hash);
        }
    }
}
