using System;

namespace SpeakerMeet.Exceptions
{
    public class SpeakerNotFoundException : Exception
    {
        public SpeakerNotFoundException(int id) : base($"Speaker {id} not found.")
        {
        }
    }
}
