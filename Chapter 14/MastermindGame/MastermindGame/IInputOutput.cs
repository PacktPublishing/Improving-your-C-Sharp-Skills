namespace MastermindGame
{
    public interface IInputOutput
    {
        void Write(string text, params object[] args);
        void WriteLine(string text = null);
        char Read();
        string ReadLine();
    }
}