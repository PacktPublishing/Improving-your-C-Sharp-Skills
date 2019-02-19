using SpeakerMeet.DTO;
using SpeakerMeet.Services.Interfaces;

namespace SpeakerMeet.API.Tests.LogonControllerTests
{
    internal class FakeLogonService : ILogonService
    {
        public bool IsLogonValid(LoginAttempt attempt)
        {
            return attempt != null &&
                   attempt.Username == "ValidUser@email.com" &&
                   attempt.Password == "ValidPassword";
        }
    }
}
