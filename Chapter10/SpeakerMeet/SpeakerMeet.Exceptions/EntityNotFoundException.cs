using System;

namespace SpeakerMeet.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(int entityId) : base($"Entity with Id:{entityId} not found.") { }
    }
}