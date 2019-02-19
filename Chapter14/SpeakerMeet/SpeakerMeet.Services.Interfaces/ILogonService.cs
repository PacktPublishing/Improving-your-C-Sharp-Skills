using SpeakerMeet.DTO;

namespace SpeakerMeet.Services.Interfaces
{
    public interface ILogonService
    {
        bool IsLogonValid(LoginAttempt attempt);
    }
}
