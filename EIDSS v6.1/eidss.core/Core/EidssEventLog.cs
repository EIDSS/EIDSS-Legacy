using System;

using System.Data;
using System.Reflection;
using System.Threading;
using bv.common.Core;
using bv.common.Configuration;
using bv.common.Diagnostics;
using eidss.model.Enums;

namespace eidss.model.Core
{
    public class EidssEventLog : IEventLog
    {
        private object m_EventDbService;
        private Timer m_Timer;
        public static bool Wait { get; set; }
        public static EidssEventLog m_Instance;

        public static EidssEventLog Instance
        {
            get { return m_Instance ?? (m_Instance = new EidssEventLog()); }
        }

        public EidssEventLog(ConnectionCredentials credentials = null, string clientID = null)
        {
            m_EventDbService = ClassLoader.LoadClass("Event_DB");
            if ((clientID != null))
            {
                PropertyInfo pi = m_EventDbService.GetType()
                                                .GetProperty("ClientID",
                                                             BindingFlags.Public | BindingFlags.Instance |
                                                             BindingFlags.Static);
                pi.SetValue(m_EventDbService, clientID, null);
            }

            if ((credentials != null))
            {
                MethodInfo mi = GetDbServiceMethod("NewConnection");
                mi.Invoke(m_EventDbService, new object[]
                    {
                        credentials.SQLServer,
                        credentials.SQLDatabase,
                        credentials.SQLUser,
                        credentials.SQLPassword,
                        credentials.SQLConnectionString
                    });
            }
            //Dim siteID As String = EIDSS.model.Core.EidssSiteContext.Instance.SiteID
        }

        private const int DelayInterval = 500;
        private int m_PeriodInterval = 500;

        public void Listen()
        {
            m_PeriodInterval = BaseSettings.EventLogListenInterval;
            if (m_Timer == null)
            {
                m_Timer = new Timer(CheckEvents, null, 0, 0);
            }
            m_Timer.Change(DelayInterval, m_PeriodInterval);
        }

        public void Stop()
        {
            m_Timer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        public event EventOccuredEventHandler EventOccured;

        public delegate void EventOccuredEventHandler(DataTable dt);

        private MethodInfo GetDbServiceMethod(string methodName)
        {
            if (m_EventDbService == null)
            {
                m_EventDbService = ClassLoader.LoadClass("Event_DB");
            }
            if ((m_EventDbService != null))
            {
                MethodInfo mi = m_EventDbService.GetType()
                                              .GetMethod(methodName,
                                                         BindingFlags.Public | BindingFlags.Instance |
                                                         BindingFlags.Static);
                return mi;
            }
            return null;
        }

        private PropertyInfo GetDbServiceProperty(string propertyName)
        {
            if (m_EventDbService == null)
            {
                m_EventDbService = ClassLoader.LoadClass("Event_DB");
            }
            if ((m_EventDbService != null))
            {
                PropertyInfo pi = m_EventDbService.GetType()
                                                .GetProperty(propertyName,
                                                             BindingFlags.Public | BindingFlags.Instance |
                                                             BindingFlags.Static);
                return pi;
            }
            return null;
        }

        public bool IsSubscribed()
        {
            MethodInfo mi = GetDbServiceMethod("IsSubscribed");
            return Convert.ToBoolean(mi.Invoke(m_EventDbService, null));
        }

        public bool SubscribeToAllEvents()
        {
            MethodInfo mi = GetDbServiceMethod("SubscribeToAllEvents");
            return Convert.ToBoolean(mi.Invoke(m_EventDbService, null));
        }
        public bool SubscribeToEvent(long idfsEventTypeId)
        {
            MethodInfo mi = GetDbServiceMethod("SubscribeToEvent");
            return Convert.ToBoolean(mi.Invoke(m_EventDbService, new[] { (object)idfsEventTypeId }));
        }

        public object CreateEvent
            (Enum eventTypeID, object objectID, object diagnosisID, object siteID = null, object userID = null,
             IDbTransaction transaction = null)
        {
            MethodInfo mi = GetDbServiceMethod("CreateEvent");
            //ByVal et As EventType, ByVal objectID As Object, diagnosisID As Object, Optional siteID As Object = Nothing, Optional ByVal userID As Object = Nothing, Optional ByVal transaction As IDbTransaction = Nothing
            return mi.Invoke(m_EventDbService, new[]
                {
                    eventTypeID,
                    objectID,
                    diagnosisID,
                    siteID,
                    userID,
                    transaction
                });
        }

        public object CreateProcessedEvent
            (Enum eventTypeID, object objectID, int processed, object diagnosisID, object siteID = null,
             object userID = null, IDbTransaction transaction = null, string strNote = null)
        {
            MethodInfo mi = GetDbServiceMethod("CreateProcessedEvent");
            return mi.Invoke(m_EventDbService, new[]
                {
                    eventTypeID,
                    objectID,
                    processed,
                    diagnosisID,
                    siteID,
                    userID,
                    transaction,
                    strNote
                });
        }

        public object MarkAsProcessed(object eventID, IDbTransaction transaction = null)
        {
            MethodInfo mi = GetDbServiceMethod("MarkAsProcessed");
            return mi.Invoke(m_EventDbService, new[]
                {
                    eventID,
                    transaction
                });
        }

        public object MarkAsProcessedBatch(Enum eventTypeID, IDbTransaction transaction = null)
        {
            MethodInfo mi = GetDbServiceMethod("MarkAsProcessedBatch");
            return mi.Invoke(m_EventDbService, new object[]
                {
                    eventTypeID,
                    transaction
                });
        }

        public bool WaitForProcessing(object eventID, EventHandler idleHandler = null)
        {
            MethodInfo mi = GetDbServiceMethod("WaitForProcessing");
            return Convert.ToBoolean(mi.Invoke(m_EventDbService, new[]
                {
                    eventID,
                    idleHandler
                }));
        }

        private static int m_ListenInterval = 5000;

        public static int ListenInterval
        {
            get { return m_ListenInterval; }
            set { m_ListenInterval = value; }
        }


        public DataTable GetEvents()
        {
            MethodInfo mi = GetDbServiceMethod("GetClientEvents");
            object dt = mi.Invoke(m_EventDbService, null);
            return (DataTable)dt;
        }

        public bool IsNotificationService
        {
            get
            {
                PropertyInfo pi = GetDbServiceProperty("IsNotificationService");
                return Convert.ToBoolean(pi.GetValue(m_EventDbService, null));
            }
            set
            {
                PropertyInfo pi = GetDbServiceProperty("IsNotificationService");
                pi.SetValue(m_EventDbService, value, null);
            }
        }

        private void CheckEvents(Object state)
        {
            m_Timer.Change(Timeout.Infinite, Timeout.Infinite);
            try
            {
                DataTable dt = GetEvents();
                if ((dt != null) && dt.Rows.Count > 0)
                {
                    if (EventOccured != null)
                    {
                        EventOccured(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Dbg.WriteLine("error during event checking: {0}", ex.ToString());
            }
            finally
            {
                m_Timer.Change(DelayInterval, m_PeriodInterval);
            }

        }

        public IDbConnection Connection
        {
            get
            {
                if ((m_EventDbService != null))
                {
                    PropertyInfo pi = m_EventDbService.GetType()
                                                    .GetProperty("Connection",
                                                                 BindingFlags.Public | BindingFlags.Instance |
                                                                 BindingFlags.Static);
                    object cn = pi.GetValue(m_EventDbService, null);
                    if ((cn != null))
                    {
                        return (IDbConnection)cn;
                    }
                }
                return null;
            }
        }

        public void CheckNotificationService(IDbTransaction transaction = null)
        {
            MethodInfo mi = GetDbServiceMethod("CheckNotificationService");
            mi.Invoke(m_EventDbService, new object[] { transaction });
        }

        public void StartReplication()
        {
            CreateEvent(EventType.ReplicationRequestedByUser, null, null);
        }
    }
}


