using SpeakerMeet.Repositories.Interfaces;

namespace SpeakerMeet.DTO
{
    public class UserLogonDto : IIdentity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}
