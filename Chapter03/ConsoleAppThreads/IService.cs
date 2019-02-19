namespace ConsoleAppThreads
{
    public interface IService
    {
        string Name { get; set; }
        void Execute();
    }

    public class Person : IPerson
    {
        public string Name { get; set; }
    }

}