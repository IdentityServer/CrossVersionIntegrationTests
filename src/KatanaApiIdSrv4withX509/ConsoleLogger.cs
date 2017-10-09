using Microsoft.Owin.Logging;
using System;
using System.Diagnostics;

namespace KatanaApi
{
    internal class ConsoleLoggerFactory : ILoggerFactory
    {
        public ILogger Create(string name)
        {
            return new ConsoleLogger();
        }

        private class ConsoleLogger : ILogger
        {
            public bool WriteCore(TraceEventType eventType, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
            {
                Console.WriteLine(formatter(state, exception));

                return true;
            }
        }
    }
}