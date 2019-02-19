namespace MastermindGame
{
    public interface IRandomGenerator
    {
        int Number(int max = 100);
        int Number(int min, int max);
        char Letter(char max = 'Z');
        char Letter(char min, char max);
    }
}