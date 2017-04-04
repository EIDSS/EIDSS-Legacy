using System;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;

namespace eidss.model.Trace
{
    /// <summary>
    ///     Listener for output log to debug window
    /// </summary>
    [ConfigurationElementType(typeof (CustomTraceListenerData))]
    public class TraceTraceListener : CustomTraceListener
    {
        public override void TraceData
            (TraceEventCache eventCache, string source, TraceEventType eventType, int id,
             object data)
        {
            if (data is LogEntry && Formatter != null)
            {
                var logEntry = data as LogEntry;
                logEntry.TimeStamp = DateTime.Now;

                Console.ForegroundColor = GetConsoleColor(logEntry.LoggedSeverity);
                WriteLine(Formatter.Format(logEntry));
                Console.ForegroundColor = ConsoleColor.Gray;
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

        private static ConsoleColor GetConsoleColor(string severity)
        {
            switch (severity)
            {
                case "Critical":
                    return ConsoleColor.DarkRed;
                case "Error":
                    return ConsoleColor.Red;
                case "Warning":
                    return ConsoleColor.DarkYellow;
                case "Information":
                    return ConsoleColor.Gray;
                default:
                    return ConsoleColor.DarkGreen;
            }
        }
    }
}