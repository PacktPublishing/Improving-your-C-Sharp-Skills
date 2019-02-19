using System;

namespace MastermindGame
{
    public class RandomGenerator : IRandomGenerator
    {
        private readonly Random _rand;

        public RandomGenerator()
        {
            _rand = new Random();
        }

        public int Number(int max = 100)
        {
            return Number(0, max);
        }

        public int Number(int min, int max)
        {
            return _rand.Next(min, max);
        }

        public char Letter(char max = 'Z')
        {
            return Letter('A', max);
        }

        public char Letter(char min, char max)
        {
            return (char)_rand.Next(min, max);
        }
    }
}
