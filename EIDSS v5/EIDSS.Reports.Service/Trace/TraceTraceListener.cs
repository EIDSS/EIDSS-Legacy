using System;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;

namespace EIDSS.Reports.Service.Trace
{

    /// <summary>
    /// Listener for output log to debug window
    /// </summary>
    [ConfigurationElementType(typeof (CustomTraceListenerData))]
    public class TraceTraceListener : CustomTraceListener
    {
        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id,
                                       object data)
        {
            if (data is LogEntry && Formatter != null)
            {
                var logEntry = data as LogEntry;
                logEntry.TimeStamp = DateTime.Now;
                WriteLine(Formatter.Format(logEntry));
            }
            else
            {
                WriteLine(data + "\n");
           } 
        }

        public override void Write(string message)
        {
            Console.Write(message);
        }

        public override void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}