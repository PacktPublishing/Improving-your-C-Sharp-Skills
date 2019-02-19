using System;

namespace ToDoApp.Tests
{
    internal class DescriptionRequiredException : Exception
    {
        public DescriptionRequiredException() : base("Todo description is required")
        {

        }
    }
}