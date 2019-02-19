enum LogLevel
{
  None = 0,
  Error = 1,
  Warning = 2,
  Success = 3,
  Info = 4
}

interface ILogger
{
  void Log(LogLevel type, string message);
}

class DummyLogger: ILogger
{ 
  public void Log(LogLevel type, string message)
  {
    // Do Nothing
  }       
}
