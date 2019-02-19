namespace SpeakerMeet.Services.Interfaces
{
    public interface IGravatarService
    {
        string GetGravatar(string emailAddress);
        string GetGravatar(string emailAddress, int size);
        string GetGravatar(string emailAddress, int size, string rating);
        string GetGravatar(string emailAddress, int size, string rating, string imageType);
    }
}
