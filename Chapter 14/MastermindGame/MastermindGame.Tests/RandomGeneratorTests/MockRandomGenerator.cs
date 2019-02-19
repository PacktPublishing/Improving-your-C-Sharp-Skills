using System.Collections.Generic;

namespace MastermindGame.Tests
{
    public class MockRandomGenerator : IRandomGenerator
    {
        private readonly List<int> _numbers;
        private List<int>.Enumerator _numbersEnumerator;

        private readonly List<char> _letters;
        private List<char>.Enumerator _lettersEnumerator;

        private const char NullChar = '\0';

        public MockRandomGenerator(List<int> numbers = null, List<char> letters = null)
        {
            _numbers = numbers ?? new List<int>();
            _numbersEnumerator = _numbers.GetEnumerator();

            _letters = letters ?? new List<char>();
            _lettersEnumerator = _letters.GetEnumerator();
        }

        public int Number(int min, int max)
        {
            var result = Number(max);

            return result < min ? min : result;
        }

        public int Number(int max = 100)
        {
            _numbersEnumerator.MoveNext();
            var result = _numbersEnumerator.Current;

            return result > max ? max : result;
        }

        public void SetNumbers(params int[] args)
        {
            _numbers.AddRange(args);
            _numbersEnumerator = _numbers.GetEnumerator();
        }

        public int Letter(char min, char max)
        {
            var result = Letter(max);

            return result < min ? min : result;
        }

        public char Letter(char max = 'Z')
        {
            _lettersEnumerator.MoveNext();
            var result = _lettersEnumerator.Current;
            result = result == NullChar ? 'A' : result;

            return result > max ? max : result;
        }

        public void SetLetters(params char[] args)
        {
            _letters.AddRange(args);
            _lettersEnumerator = _letters.GetEnumerator();
        }

        char IRandomGenerator.Letter(char min, char max)
        {
            throw new System.NotImplementedException();
        }
    }
}
