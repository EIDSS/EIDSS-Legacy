using System.Diagnostics;

namespace bv.common.Core
{
    public static class WindowsLogHelper
    {
        public static void WriteToEventLogWindows(string message, EventLogEntryType eventLogEntryType)
        {
            using (var eventLog = new EventLog())
            {
                
                try
                {
                    eventLog.Source = "EIDSS";
                    eventLog.WriteEntry(message, eventLogEntryType);
                }
                //писать более некуда
                // ReSharper disable EmptyGeneralCatchClause
                catch
                // ReSharper restore EmptyGeneralCatchClause
                {
                }
            }
        }
    }
}