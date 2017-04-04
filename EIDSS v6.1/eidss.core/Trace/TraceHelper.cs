using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace eidss.model.Trace
{
    public class TraceHelper : ITraceStrategy
    {
        public const string ReportsCategory = "EIDSS.Reports";
        public const string AVRCategory = "EIDSS.AVR";
        public const string HMIS2EIDSSCategory = "EIDSS.HMIS2EIDSS";
        public const string GeneralCategory = "General";
        private readonly string m_Category;

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

        public void TraceError(Exception e, string message)
        {
            TraceError(e, new Dictionary<string, object>(), message);
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

        public void TraceMethodCall(string methodName, string traceTite, params object[] value)
        {
            string parameters = BuildParams(value);
            string message = String.Format("{0}({1})", methodName, parameters);
            Trace(new Dictionary<string, object>(), traceTite, message);
        }

        public void TraceMethodException(Exception ex, string methodName, string traceTite, params object[] value)
        {
            string parameters = BuildParams(value);
            string title = String.Format("{0} - Error while executing method {1}({2})",
                traceTite, methodName, parameters);
            TraceError(ex, new Dictionary<string, object>(), title);
            Exception innerException = ex.InnerException;
            while (innerException != null)
            {
                TraceError(innerException, new Dictionary<string, object>(), title);
                innerException = innerException.InnerException;
            }
        }

        private static string BuildParams(IEnumerable<object> value)
        {
            var paramsBuilder = new StringBuilder();
            if (value != null)
            {
                foreach (object parameter in value)
                {
                    object printableParam = (parameter is IEnumerable<object>)
                        ? BuildParams((IEnumerable<object>) parameter)
                        : parameter ?? "NULL";
                    paramsBuilder.AppendFormat("{0}, ", printableParam);
                }
            }
            return paramsBuilder.ToString();
        }

        private string SerializeException(Exception ex)
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