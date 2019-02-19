namespace HelloWorld
{
    public class MessageUtility
    {
        private readonly ITimeManager _timeManager;

        public MessageUtility(ITimeManager timeManager)
        {
            _timeManager = timeManager;
        }

        public string GetMessage()
        {
            if (_timeManager.Now.Hour < 12)
                return "Good morning";
            if (_timeManager.Now.Hour <= 18)
                return "Good afternoon";
            return "Good evening";
        }
    }
}
