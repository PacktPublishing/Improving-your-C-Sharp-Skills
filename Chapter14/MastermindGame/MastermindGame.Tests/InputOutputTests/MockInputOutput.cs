using System;
using System.Collections.Generic;
using System.Linq;

namespace MastermindGame.Tests
{
    public class MockInputOutput : IInputOutput
    {
        public List<string> OutFeed { get; set; }
        public Queue<string> InFeed { get; set; }

        public MockInputOutput()
        {
            OutFeed = new List<string>();
            InFeed = new Queue<string>();
        }

        public void Write(string text, params object[] args)
        {
            OutFeed.Add(text);
        }

        public void WriteLine(string text = null)
        {
            OutFeed.Add((text ?? "") + Environment.NewLine);
        }

        public char Read()
        {
            return InFeed.Dequeue().ToCharArray().First();
        }

        public string ReadLine()
        {
            return InFeed.Dequeue();
        }
    }
}