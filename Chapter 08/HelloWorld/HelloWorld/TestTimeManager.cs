using System;

namespace HelloWorld
{
    public class TestTimeManager : ITimeManager
    {
        public Func<DateTime> CurrentTime = () => DateTime.Now;

        public void SetDateTime(DateTime now)
        {
            CurrentTime = () => now;
        }

        public DateTime Now => CurrentTime();
    }

}
