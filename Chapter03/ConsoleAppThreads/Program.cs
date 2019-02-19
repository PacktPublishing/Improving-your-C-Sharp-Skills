using System;
using System.Threading;

namespace ConsoleAppThreads
{
    class Program
    {

        static volatile bool isActive = true; 

        static void Main(string[] args)
        {
            //new Thread(new ThreadStart(ExecuteLongRunningOperation)).Start();


            //new Thread(new ParameterizedThreadStart(ExecuteLongRunningOperation)).Start(1000);
            
            int workerThreads;
            int completionPortThreads;
            ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);
            Console.WriteLine("Total threads are {workerThreads} , completion thread {completionPortThreads}");
                
            ThreadPool.QueueUserWorkItem(ExecuteLongRunningOperation, 1000);
            Console.Read();
        //   Thread.Sleep(1000);
         //  isActive = false;
            //IService service = new EmailService("Email");
          //  new Thread(new ParameterizedThreadStart(RunBackgroundService)).Start(service);
        }
        //static void ExecuteLongRunningOperation()
        //{
        //    Thread.Sleep(100000);
        //    Console.WriteLine("Operation completed successfully");
        //}


        static void ExecuteLongRunningOperation(object milliseconds)
        {

            Thread.Sleep((int)milliseconds);
            Console.WriteLine("Thread is executed");
            //while (isActive)
            //{
            //    //Do some other operation
            //    Console.WriteLine("Operation completed successfully");
            //}
        }


        static void RunBackgroundService(Object service)
        {
            var a = Thread.CurrentThread.ExecutionContext;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            ((IService)service).Execute(); //Long running task
        }

    }



    public class EmailService : IService
    {
        public string Name { get; set; }
        public void Execute() => throw new NotImplementedException();

        public EmailService(string name)
        {
            this.Name = name;
        }
    }
}
