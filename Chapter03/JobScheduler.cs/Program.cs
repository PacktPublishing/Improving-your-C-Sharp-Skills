using System;
using System.Collections.Generic;
using System.Threading;

namespace JobScheduler.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread jobThread = new Thread(new ThreadStart(ExecuteJobExecutor));
            jobThread.Start();

            //Starting three Threads add jobs time to time;
            Thread thread1 = new Thread(new ThreadStart(ExecuteThread1));           
            Thread thread2 = new Thread(new ThreadStart(ExecuteThread2));
            Thread thread3 = new Thread(new ThreadStart(ExecuteThread3));
            thread2.Start();
            thread1.Start();
            thread3.Start();

            Console.Read();
        }

        private static void ExecuteThread1()
        {
            Thread.Sleep(5000);
            List<Job> jobs = new List<Job>();
            jobs.Add(new Job() { JobID = 11, JobName = "Thread 1 Job 1" });
            jobs.Add(new Job() { JobID = 12, JobName = "Thread 1 Job 2" });
            jobs.Add(new Job() { JobID = 13, JobName = "Thread 1 Job 3" });
            JobExecutor.Instance.AddJobItems(jobs);
        }
        private static void ExecuteThread2()
        {
            Thread.Sleep(5000);
            List<Job> jobs = new List<Job>();
            jobs.Add(new Job() { JobID = 21, JobName = "Thread 2 Job 1" });
            jobs.Add(new Job() { JobID = 22, JobName = "Thread 2 Job 2" });
            jobs.Add(new Job() { JobID = 23, JobName = "Thread 2 Job 3" });
            JobExecutor.Instance.AddJobItems(jobs);
        }
        private static void ExecuteThread3()
        {
            Thread.Sleep(5000);
            List<Job> jobs = new List<Job>();
            jobs.Add(new Job() { JobID = 31, JobName = "Thread 3 Job 1" });
            jobs.Add(new Job() { JobID = 32, JobName = "Thread 3 Job 2" });
            jobs.Add(new Job() { JobID = 33, JobName = "Thread 3 Job 3" });
            JobExecutor.Instance.AddJobItems(jobs);
        }
       
      

        public static void ExecuteJobExecutor()
        {
            JobExecutor.Instance.IsAlive = true;
            JobExecutor.Instance.CheckandExecuteJobBatch();
        }
    }
}
