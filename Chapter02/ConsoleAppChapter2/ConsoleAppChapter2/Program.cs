using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Filters;
using BenchmarkDotNet.Running;
using System;
using System.Threading.Tasks;

namespace ConsoleAppChapter2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task t = new Task(execute);
            //t.Start();
            //t.Wait();
            var config = ManualConfig.Create(DefaultConfig.Instance);
            config.Add(new DisjunctionFilter(new NameFilter(name => name.Contains("Recursive"))));
            BenchmarkRunner.Run<TestBenchmark>(config);
            Console.Read();
        }

        private static void execute() {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
            }
        }
    }


    //[Config(typeof(Config))]
    public class TestBenchmark
    {

        //private class Config : ManualConfig
        //{
        //    // We will benchmark ONLY method with names with names (which contains "A" OR "1") AND (have length < 3)
        //    public Config()
        //    {
        //        Add(new DisjunctionFilter(
        //            new NameFilter(name => name.Contains("Recursive"))
        //        )); 
                
        //    }
        //}

        [Params(10,20,30)]
        public int Len { get; set; }
        
        [Benchmark]
        public  void Fibonacci()
        {
            int a = 0, b = 1, c = 0;
            Console.Write("{0} {1}", a, b);

            for (int i = 2; i < Len; i++)
            {
                c = a + b;
                Console.Write(" {0}", c);
                a = b;
                b = c;
            }
        }

        [Benchmark]
        public  void FibonacciRecursive()
        {
            
            Fibonacci_Recursive(0, 1, 1, Len);
        }

        private void Fibonacci_Recursive(int a, int b, int counter, int len)
        {
            if (counter <= len)
            {
                Console.Write("{0} ", a);
                Fibonacci_Recursive(b, a + b, counter + 1, len);
            }
        }

    }
}
