using System;

namespace HelloWorld
{
    public class MockDateTimeService
    {
        public DateTime CurrentDateTime { get; set; } = new DateTime();

        public DateTime UTCNow()
        {
            return CurrentDateTime.ToUniversalTime();
        }
    }
}
