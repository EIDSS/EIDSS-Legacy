using System;
using System.Diagnostics;
using eidss.model.Enums;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.common.Diagnostics;

#if MONO
namespace System.Diagnostics
{
    public enum EventLogEntryType
    {
        Error = 1,
        Warning = 2,
        Information = 4,
        SuccessAudit = 8,
        FailureAudit = 16,
    }
}
#endif

namespace eidss.model.Core
{

	public class SecurityLog
	{
		public static bool WriteToEventLogWindows(string entry, string appName, EventLogEntryType eventType, string logName)
			{
#if !MONO
			var objEventLog = new EventLog();
			try
			{
				//Register the App as an Event Source
				if (! EventLog.SourceExists(appName))
				{
					EventLog.CreateEventSource(appName, logName);
				}
				
				objEventLog.Source = appName;
				objEventLog.WriteEntry(entry, eventType);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
#else
		    return true;
#endif
			}
		public static bool WriteToEventLogDB(object userID, SecurityAuditEvent action, bool success, string alternativeMessage, string errString, string description, SecurityAuditProcessType processType)
		{
			if (EidssUserContext.User.IsAuthenticated)
			{

				if (!Utils.IsEmpty(userID))
				{
                    userID = EidssUserContext.User.ID;
				}
                if (Utils.IsEmpty(alternativeMessage))
                {
                    alternativeMessage = string.Format("EIDSS log: action=\'{0}\', process = {1}, success=\'{2}\', user=\'{3}\', error = \'{4}\', description =\'{5}\'",
                                                    action, processType, success, Utils.Str(EidssUserContext.User.Name), Utils.Str(errString), Utils.Str(description));
                }
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    try
                    {
                        manager.SetSpCommand("dbo.spLogSecurityEvent",
                                             manager.Parameter("@idfUserID", userID),
                                             manager.Parameter("@idfsAction", action),
                                             manager.Parameter("@success", success),
                                             manager.Parameter("@strErrorText", errString),
                                             manager.Parameter("@strDescription", description),
                                             manager.Parameter("@idfsProcessType", processType)
                            );
                        manager.CommandTimeout = 2;
                        manager.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        WriteToEventLogWindows(alternativeMessage, AppName, success ? EventLogEntryType.Information : EventLogEntryType.Error, "Application");
                        WriteToEventLogWindows(string.Format("Error during writing security log to database: {0}", e), AppName, EventLogEntryType.Error, "Application");
                        Dbg.Debug("security error writing error: {0}", e.ToString());
                    }
                }
			}
			else
			{
                if (Utils.IsEmpty(alternativeMessage))
                {
                    alternativeMessage = string.Format("{6} log: action=\'{0}\', process = {1}, success=\'{2}\', user=\'{3}\', error = \'{4}\', description =\'{5}\'",
                                                    action.ToString(), processType.ToString(), success, "unknown", errString, description, AppName);
                }
                WriteToEventLogWindows(alternativeMessage, AppName, success?EventLogEntryType.Information:EventLogEntryType.Error, "Application");
			}
			return true;
		}

	    private static string m_AppName = "EIDSS";
        public static string AppName { get { return m_AppName; } set { m_AppName = value; } }
		
		
	}
	
}
