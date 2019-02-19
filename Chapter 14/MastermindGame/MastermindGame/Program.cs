namespace MastermindGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new RandomGenerator();
            var inout = new ConsoleInputOutput();
            var game = new Mastermind(inout, rand);

            var password = args.Length > 0 ? args[0] : null;
            game.Play(password);

            inout.WriteLine("Press any key to quit.");
            inout.Read();
        }
    }
}