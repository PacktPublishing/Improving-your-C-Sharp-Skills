using System;

namespace HelloWorld
{
    public class SpySpeakerContactService : ISpeakerContactService
    {
        public bool MessageSpeakerHasBeenCalled { get; private set; }

        public int MessageSpeakerCallCount { get; private set; }

        public void MessageSpeaker(string message)
        {
            MessageSpeakerHasBeenCalled = true;
            MessageSpeakerCallCount++;
        }
    }
}
