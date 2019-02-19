using System.Linq;
using System.Security.Cryptography;
using System.Text;
using SpeakerMeet.DTO;
using SpeakerMeet.Repositories.Interfaces;
using SpeakerMeet.Services.Interfaces;

namespace SpeakerMeet.Services
{
    public class LogonService : ILogonService
    {
        private readonly IRepository<UserLogonDto> _repository;

        public LogonService(IRepository<UserLogonDto> repository)
        {
            _repository = repository;
        }

        public bool IsLogonValid(LoginAttempt attempt)
        {
            attempt = attempt ?? new LoginAttempt();

            var user = _repository.GetAll().FirstOrDefault(u => u.Username == attempt.Username);

            var hash = SHA512.Create().ComputeHash(Encoding.ASCII.GetBytes(attempt.Password ?? ""));

            return user != null && user.PasswordHash.SequenceEqual(hash);
        }
    }
}
