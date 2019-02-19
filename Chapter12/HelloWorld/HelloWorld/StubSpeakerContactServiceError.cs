using System;

namespace HelloWorld 
{
    public class StubSpeakerContactServiceError : ISpeakerContactService
    {
        public void MessageSpeaker(string message) 
        {
            throw new UnableToContactSpeakerException();
        }
    }

    public class UnableToContactSpeakerException : Exception
    {
        public UnableToContactSpeakerException() : base("Unable to contact speaker") { }
    }
}
