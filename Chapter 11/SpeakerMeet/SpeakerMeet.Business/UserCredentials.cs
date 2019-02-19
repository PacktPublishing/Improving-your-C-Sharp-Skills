using SpeakerMeet.Repositories.Interfaces;

namespace SpeakerMeet.Business
{
    public class UserCredentials : IIdentity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}
