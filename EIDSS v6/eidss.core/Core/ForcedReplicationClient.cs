using System;
using System.Data;
using BLToolkit.Data.DataProvider;
using bv.common.Diagnostics;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Enums;
using System.Threading;

namespace eidss.model.Core
{

    public class ForcedReplicationClient
    {
        private static bool m_StdReplicationRequested;
        private static readonly object m_SyncObject = new object();
        private readonly Timer m_DelayedReplicationTimer;
        private static ForcedReplicationClient m_Instance;
        private ConnectionCredentials m_ConnectionCredentials;
        private object m_UserID;
        private long m_SiteID;
        public static ForcedReplicationClient Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new ForcedReplicationClient() { RoutineJobName = "Dummy" };//RoutineJobName is mandatory for replication starting
                return m_Instance;
            }
            set { m_Instance = value; }

        }
        public ForcedReplicationClient(ConnectionCredentials credentials = null, string clientID = null)
        {
            m_DelayedReplicationTimer = new Timer(StartReplication, null,
                                Timeout.Infinite,
                                Timeout.Infinite);
            //initialize EIDSS shared variables here because they are called from other thread
            //where EidssUserContext and EidssSiteContext are not initialized
            m_UserID = EidssUserContext.User.ID;
            m_SiteID = EidssSiteContext.Instance.RealSiteID;
            if (Utils.IsEmpty(clientID))
                m_ClientID = ModelUserContext.ClientID;
            else
                m_ClientID = clientID;
            if(credentials!=null)
                DbManagerFactory.SetSqlFactory(credentials.ConnectionString);
            SubscribeToEvent((long) EventType.ForcedReplicationConfirmed);
            SubscribeToEvent((long) EventType.ForcedReplicationExpired);

        }
        public bool IsNotificationService { get; set; }
        public string RoutineJobName { get; set; }
        private string m_ClientID;

        private DbManagerProxy GetDbManager()
        {
                return DbManagerFactory.Factory.Create(ModelUserContext.Instance);
        }
        public bool SubscribeToEvent(long idfsEventTypeId)
        {
            using (DbManagerProxy manager = GetDbManager())
            {
                try
                {
                    manager.SetSpCommand("dbo.spEventLog_SubscribeToEvent",
                                          manager.Parameter("@idfClientID", m_ClientID),
                                          manager.Parameter("@idfsEventTypeID", idfsEventTypeId)
                                                 ).ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Dbg.Debug("event subscription is fail: {0}", ex);
                    return false;
                }
            }
        }

        public DataRow[] GetReplicationEvents()
        {
            using (DbManagerProxy manager = GetDbManager())
            {
                try
                {
                    var dt = manager.SetSpCommand("dbo.spEventLog_SelectNewEvents",
                                          manager.Parameter("@LangID", ModelUserContext.CurrentLanguage),
                                          manager.Parameter("@ClientID", m_ClientID),
                                          manager.Parameter("@IsNotificationClient", false)
                                                 ).ExecuteDataTable();
                    return  dt.Select(string.Format("ISNULL(idfUserID, 0) = {0} and idfsEventTypeID in ({1},{2})", EidssUserContext.User.ID,
                              (long)EventType.ForcedReplicationConfirmed, (long)EventType.ForcedReplicationExpired));
                }
                catch (Exception ex)
                {
                    Dbg.Debug("event subscription is fail: {0}", ex);
                    return null;
                }
            }
        }


        public bool StartReplication()
        {
            if (EidssSiteContext.Instance.RealSiteType == SiteType.CDR)
            {
                return true;
            }
            if (RoutineJobName == null && Utils.IsEmpty(Config.GetSetting("RoutineJobName")))
            {
                return true;
            }
            lock (m_SyncObject)
            {
                if (!m_StdReplicationRequested)
                {
                    m_StdReplicationRequested = true;
                    Dbg.ConditionalDebug(DebugDetalizationLevel.Low,
                                         "replication client put replication request to buffer for object at {0}",
                                         DateTime.Now);
                    m_DelayedReplicationTimer.Change(1000, 1000);
                }
            }
            return true;
        }

        private void StartReplication(object state)
        {
            lock (m_SyncObject)
            {
                m_DelayedReplicationTimer.Change(Timeout.Infinite, Timeout.Infinite);
                Dbg.ConditionalDebug(DebugDetalizationLevel.Low, "delayed replication event occured");
                if (m_StdReplicationRequested)
                {
                    CreateClientEvent(EventType.ReplicationRequestedByUser, -1);
                    if (!IsNotificationService && EidssSiteContext.Instance.RealSiteType != SiteType.CDR )
                    {
                        CheckNotificationService();
                    }
                }
                m_StdReplicationRequested = false;
            }
        }

        private void CheckNotificationService()
        {
            using (DbManagerProxy manager = GetDbManager())
            {
                try
                {
                    var dt = manager.SetSpCommand("dbo.spEventLog_IsNtfyServiceRunning",
                                          manager.Parameter("@idfsClient", m_ClientID)
                                                 ).ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Dbg.Debug("event subscription is fail: {0}", ex);
                }
            }
        }

        private void CreateClientEvent(EventType eventType, object objectId)
        {
            Dbg.ConditionalDebug(DebugDetalizationLevel.Low,
                                 "replication client raise replication event for object at {0}", DateTime.Now);

            using (DbManagerProxy manager = GetDbManager())
            {
                try
                {
                    manager.SetSpCommand("dbo.spEventLog_CreateNewEvent",
                                          manager.Parameter("@idfsEventTypeID", Convert.ToInt64(eventType)),
                                          manager.Parameter("@idfObjectID", objectId),
                                          manager.Parameter("@strInformationString", DBNull.Value),
                                          manager.Parameter("@strNote", DBNull.Value),
                                          manager.Parameter("@ClientID", m_ClientID),
                                          manager.Parameter("@datEventDatatime",DateTime.Now),
                                          manager.Parameter("@intProcessed", 0),
                                          manager.Parameter("@idfUserID", m_UserID),
                                          manager.Parameter(ParameterDirection.InputOutput, "@EventID", DBNull.Value, DbType.Int64),
                                          manager.Parameter("@idfsSite", m_SiteID),
                                          manager.Parameter("@idfsDiagnosis", DBNull.Value)
                                                 ).ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Dbg.Debug("event creation fail: {0}", ex);
                }
            }
            
        }

    }
}

