using System;
using GravatarHelper.NetStandard;
using SpeakerMeet.Services.Interfaces;

namespace SpeakerMeet.Services
{
    public class GravatarService : IGravatarService
    {
        public string GetGravatar(string emailAddress)
        {
            return Gravatar.GetGravatarImageUrl(emailAddress);
        }

        public string GetGravatar(string emailAddress, int size)
        {
            throw new NotImplementedException();
        }

        public string GetGravatar(string emailAddress, int size, string rating)
        {
            throw new NotImplementedException();
        }

        public string GetGravatar(string emailAddress, int size, string rating, string imageType)
        {
            throw new NotImplementedException();
        }
    }
}
