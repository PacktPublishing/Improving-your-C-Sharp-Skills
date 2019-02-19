using System;
using SpeakerMeet.Services.Interfaces;

namespace SpeakerMeet.Services.Tests.Fakes
{
    public class FakeGravatarService : IGravatarService
    {
        public bool GetGravatarCalled { get; set; }
        public bool WithEmailCalled { get; set; }
        public string CalledWith { get; set; }

        public void GetGravatar()
        {
            GetGravatarCalled = true;
        }

        public string GetGravatar(string emailAddress)
        {
            WithEmailCalled = true;
            CalledWith = emailAddress;

            return System.Reflection.MethodBase.GetCurrentMethod().Name;
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
