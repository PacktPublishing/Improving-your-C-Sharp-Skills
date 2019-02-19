using System;
using System.Collections.Generic;
using System.Text;

namespace MastermindGame
{
    public class ConsoleInputOutput : IInputOutput
    {
        public void Write(string text, params object[] args)
        {
            Console.Write(text, args);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public char Read()
        {
            return Console.ReadKey().KeyChar;
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
