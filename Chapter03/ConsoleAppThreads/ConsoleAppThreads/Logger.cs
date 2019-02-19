using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppThreads
{
    //public class Logger
    //{
    //    static Logger _logger;

    //    private Logger() { }

    //    public Logger GetInstance()
    //    {
    //        _logger = (_logger == null ? new Logger() : _loggger);
    //        return _logger;
    //    }

    //    public void LogMessage(string str)
    //    {
    //        //Log message into file system
    //    }


    //}


    public class Logger
    {

        private static object syncRoot = new object();
        static Logger _instance;

        private Logger() { }

        public Logger GetInstance()
        {
            if (_instance == null)
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                        _instance = new Logger();
                }
            }
            return _instance;
        }

        public void LogMessage(string str)
        {
            //Log message into file system
        }


    }
}
