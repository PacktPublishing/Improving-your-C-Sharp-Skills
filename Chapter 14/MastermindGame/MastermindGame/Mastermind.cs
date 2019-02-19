using System;
using System.Linq;

namespace MastermindGame
{
    public class Mastermind
    {
        private readonly IInputOutput _inout;
        private readonly IRandomGenerator _random;

        private int _tries;

        public Mastermind(IInputOutput inout, IRandomGenerator random)
        {
            _inout = inout;
            _random = random;
        }

        public void Play(string password = null)
        {
            password = password ?? CreateRandomPassword();
            var correctPositions = 0;

            while (correctPositions != 4)
            {
                correctPositions = GuessPasswordAndCheck(password);
            }

            _inout.WriteLine("Congratulations you guessed the password in " + _tries + " tries.");
        }

        private int GuessPasswordAndCheck(string password)
        {
            var guess = Guess();
            return Check(guess, password);
        }

        private int Check(string guess, string password)
        {
            var checkResult = "";

            Times(4, x => {
                if (guess[x] == password[x])
                {
                    checkResult += "+";
                }
                else if (password.Contains(guess[x]))
                {
                    checkResult += "-";
                }
            });

            _inout.WriteLine(checkResult);
            return checkResult.Count(c => c == '+');
        }

        private string CreateRandomPassword()
        {
            var password = new[] { 'A', 'A', 'A', 'A' };

            Times(4, x => password[x] = _random.Letter());

            return new string(password);
        }

        private static void Times(int count, Action<int> act)
        {
            for (var index = 0; index < count; index++)
            {
                act(index);
            }
        }

        private string Guess()
        {
            _tries = _tries + 1;

            _inout.Write("Take a guess: ");
            var guess = _inout.ReadLine();

            if (guess.Length == 4)
            {
                return guess.ToUpper();
            }

            // Password guess was wrong size - Error Message
            _inout.WriteLine("Password length is 4.");
            return Guess();
        }
    }
}