using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace JobScheduler.cs
{
    public class JobExecutor
    {
        const int _waitTimeInMillis = 10 * 60 * 1000;
        private ArrayList _jobs = null;

        private static JobExecutor _instance = null;
        private static object _syncRoot = new object();

        public static JobExecutor Instance
        {
            get
            {
                lock (_syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new JobExecutor();
                    }
                }
                return _instance;
            }
        }

        private JobExecutor()
        {
            IsIdle = true;
            IsAlive = true;
            _jobs = new ArrayList();
        }


        private Boolean IsIdle { get; set; }
        public Boolean IsAlive { get; set; }


        /// <summary>
        /// Will be called from the external thread
        /// </summary>
        /// <param name="jobList"></param>
        public void AddJobItems(List<Job> jobList)
        {
            lock (_jobs)
            {
                foreach (Job job in jobList)
                {
                    _jobs.Add(job);
                }
                Monitor.PulseAll(_jobs);
            }
        }

        /// <summary>
        /// This method will run continously and checks for new jobs after every 10 minutes unless 
        /// gets trigger through Monitor.PulseAll form the AddJobItems
        /// </summary>
        public void CheckandExecuteJobBatch()
        {
            lock (_jobs)
            {
                while (IsAlive)
                {
                    if (_jobs == null || _jobs.Count <= 0)
                    {
                        IsIdle = true;
                        Console.WriteLine("Now waiting for new jobs");
                        Monitor.Wait(_jobs, _waitTimeInMillis);
                    }
                    else
                    {
                        IsIdle = false;
                        ExecuteJob();
                    }
                }
            }
        }

        /// <summary>
        /// Execute the job added in the Job list 
        /// </summary>
        private void ExecuteJob()
        {
            for(int i=0;i< _jobs.Count;i++)
            {
                Job job = (Job)_jobs[i];
                //Execute the job;
                job.DoSomething();
                //Remove the Job from the Jobs list
                _jobs.Remove(job);
                i--;
            }
        }
    }
    
}
