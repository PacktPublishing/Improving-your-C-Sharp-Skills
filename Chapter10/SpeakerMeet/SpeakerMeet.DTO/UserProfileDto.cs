using SpeakerMeet.Repositories.Interfaces;

namespace SpeakerMeet.DTO
{
    public class UserProfileDto : IIdentity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}
