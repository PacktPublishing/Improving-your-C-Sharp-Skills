using System;

namespace JobScheduler.cs
{
    public class Job
    {

        public int JobID { get; set; }
        public string JobName { get; set; }

        public void DoSomething()
        {
            //Do some task based on Job ID 
            Console.WriteLine("Executed job " + JobID); 
        }
    }
}