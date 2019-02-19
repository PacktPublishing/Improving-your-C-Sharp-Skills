using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleAppThreads
{
    public class Job
    {

        int _jobDone;
        object _lock = new object();

        public void IncrementJobCounter(int number)
        {
            Monitor.Enter(_lock);
            _jobDone += number;
            Monitor.Exit(_lock);
        }

    }
}
