using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace EIDSS.Reports.Service.Trace
{
    public class TraceHelper
    {
        private readonly string m_Category = "EIDSS.Reports";

        public TraceHelper()
        {
        }

        public TraceHelper(string category)
        {
            if (string.IsNullOrEmpty(category.Trim()))
            {
                throw new ArgumentException("category should be not empty string");
            }
            m_Category = category;
        }

        public string Category
        {
            get { return m_Category; }
        }

        public void TraceCritical(Exception e)
        {
            TraceCritical(e, new Dictionary<string, object>());
        }

        public void TraceCritical(Exception e, Dictionary<string, object> extendedProperties)
        {
            TraceCritical(e, extendedProperties, e.Message);
        }

        public void TraceCritical
            (Exception e, Dictionary<string, object> extendedProperties, string title,
             params object[] args)
        {
            extendedProperties.Add("Exception", SerializeException(e));
            Trace(TraceEventType.Critical, extendedProperties, e.Message, title + " (" + e.Message + ")",
                  args);
        }

        public void TraceError(Exception e)
        {
            TraceError(e, new Dictionary<string, object>());
        }

        public void TraceError(string title, string message, params object[] args)
        {
            Trace(TraceEventType.Error, new Dictionary<string, object>(), title, message, args);
        }

        public void TraceError(Exception e, Dictionary<string, object> extendedProperties)
        {
            TraceError(e, extendedProperties, e.Message);
        }

        public void TraceError
            (Exception e, Dictionary<string, object> extendedProperties, string title,
             params object[] args)
        {
            extendedProperties.Add("Exception", SerializeException(e));
            Trace(TraceEventType.Error, extendedProperties, e.Message, title, args);
        }

        public void Trace(string title, string message, params object[] args)
        {
            Trace(TraceEventType.Verbose, new Dictionary<string, object>(), title, message, args);
        }

        public void Trace
            (Dictionary<string, object> extendedProperties, string title, string message,
             params object[] args)
        {
            Trace(TraceEventType.Verbose, extendedProperties, title, message, args);
        }

        public void TraceInfo
            (Dictionary<string, object> extendedProperties, string title, string message,
             params object[] args)
        {
            Trace(TraceEventType.Information, extendedProperties, title, message, args);
        }

        public void TraceInfo(string title, string message, params object[] args)
        {
            Trace(TraceEventType.Information, new Dictionary<string, object>(), title, message, args);
        }

        public void TraceWarning(string title, string message, params object[] args)
        {
            Trace(TraceEventType.Warning, new Dictionary<string, object>(), title, message, args);
        }

        public void Trace
            (TraceEventType severity, Dictionary<string, object> extendedProperties, string title,
             string message, params object[] args)
        {
            var logEntry = new LogEntry();
            try
            {
                logEntry.Message = (args.Length > 0) ? string.Format(message, args) : message;
            }
            catch (FormatException ex)
            {
                logEntry.Message = "Cannot format log message " + message + ex;
                logEntry.Severity = TraceEventType.Error;
            }
            logEntry.EventId = 1;
            logEntry.Title = title;
            logEntry.Severity = severity;
            logEntry.Categories = new[] {Category};
            logEntry.ExtendedProperties = extendedProperties;
            logEntry.TimeStamp = DateTime.Now;

            Logger.Write(logEntry);
        }

        public string SerializeException(Exception ex)
        {
            string ret;
            using (var sr = new StringWriter())
            {
                var formatter = new TextExceptionFormatter(sr, ex);
                formatter.Format();
                ret = sr.ToString();
            }
            return ret;
        }
    }
}