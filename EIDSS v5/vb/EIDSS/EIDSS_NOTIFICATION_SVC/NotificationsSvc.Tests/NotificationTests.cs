using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using EIDSS;
using bv.common.Core;
using bv.common.db.Core;
using bv.common.db;
using bv.common.Diagnostics;
using bv.model.Model.Core;
using eidss.model.Core;
using System.Threading;
using bv.common;
using System.Data.Common;
using bv.common.Configuration;
using bv.model.BLToolkit;

namespace NotificationsSvc.Tests
{
    [TestClass]
    public class NotificationTests
    {
        private string m_DirToConfigFile;
        private string m_ConfigFile;
        private const string m_NameSlvlConfigFile = "EIDSS40_Ntfy.exe - slvl.config";
        [TestInitialize]
        public void Init()
        {
            ClassLoader.Init("bv_common.dll", null);
            ClassLoader.Init("bvdb_common.dll", null);
            ClassLoader.Init("eidss_common.dll", null);
            ClassLoader.Init("eidss_db.dll", null);

            string dir = GetExecutingPath();
            m_DirToConfigFile = string.Format("{0}..\\..\\..\\..\\..\\..\\eidss.main\\bin\\debug", dir);
            // для tlvl - базы
            m_ConfigFile = //@"c:\Projects\EIDSS4\DevelopersBranch\eidss.main\bin\Debug\EIDSS40_Ntfy.exe.config";
                string.Format("{0}\\EIDSS40_Ntfy.exe.config", m_DirToConfigFile);

            // нужно для запуска репликации с tlvl на slvl
            ConnectionCredentials credentials = new ConnectionCredentials(m_ConfigFile);
            JobAccessor.Instance = new JobAccessor(credentials.SQLServer, credentials.SQLUser, credentials.SQLPassword);

            ConnectionManager.Create(m_ConfigFile);
            DbManagerFactory.SetSqlFactory(ConnectionManager.DefaultInstance.Connection.ConnectionString);
            var config = new ConfigWriter(null,m_ConfigFile);
            config.Read(m_ConfigFile);
            ModelUserContext.ClientID = config.GetItem("ClientID");
            EidssUserContext.Init();
            EidssUserContext.User.LoginName = "ntfy";

            StoredProcParamsCache.InitMultiThreadProcedures(new string[] { "spNotification_Create", "spEventLog_IsSubscribed", "spGetSiteInfo", "spAudit_CreateNewEvent" });


            //m_Service = new ServiceBase();
            //m_Service.Start(0, file);
            //int res =
            //    ClientAccessor.SecurityManager.LogIn(BaseSettings.DefaultOrganization, BaseSettings.DefaultUser,
            //                                          BaseSettings.DefaultPassword, null, null, null, null, false);
            //if (res != 0)
            //    throw (new Exception("login failed"));
        }
        [TestMethod]
        public void Event_NewHumanCase_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.NewHumanCase);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_NewVetCase_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.NewVetCase);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_NewTestResult_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.NewTestResult);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_NewOutbreak_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.NewOutbreak);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_CaseDiseaseChange_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.CaseDiseaseChange);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_CaseStatusChange_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.CaseStatusChange);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_ReferenceTableChanged_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.ReferenceTableChanged);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_NotificationReplicationRequest_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.NotificationReplicationRequest);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_ReplicationRequestedByUser_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.ReplicationRequestedByUser);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_SettlementChanged_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.SettlementChanged);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_AVRLayoutUpdate_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.AVRLayoutUpdate);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        private EmNotify_DB m_NotificationService;
        [TestMethod]
        public void NotificationProcessorInitTest()
        {
            // для slvl - базы
            EmNotifyLstn notivicationListener = new EmNotifyLstn(string.Format("{0}\\{1}", m_DirToConfigFile, m_NameSlvlConfigFile));
            m_NotificationService = new EmNotify_DB(null, "12345");
            m_NotificationService.SiteID = 6;
        }

        private long m_NotificationId;
        [TestMethod]
        public void Replication_NewHumanCase_Test()
        {
            CheckReplication(EventType.NewHumanCase);
        }
        [TestMethod]
        public void Replication_NewVetCase_Test()
        {
            CheckReplication(EventType.NewVetCase);
        }
        [TestMethod]
        public void FiltrationCall_Test()
        {
            var ntfy = new EmNotifyLstn(m_ConfigFile);
            ntfy.Listen();
            Thread.Sleep(1000);
            ntfy.Stop();
            Assert.AreEqual(1, ntfy.FiltrationRecalcCount);
        }
        private void CheckReplication(EventType eventType)
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);//for work with tlvl database
            // для slvl - базы
            EmNotifyLstn notivicationListener = new EmNotifyLstn(string.Format("{0}\\{1}", m_DirToConfigFile, m_NameSlvlConfigFile));//for work with slvl database
            CheckReplicationName(eventProcessor.Database, eventProcessor.RoutineJobName, notivicationListener.Connection.Database);

            //  we are on tlvl side

            //begin
            eventProcessor.EventOccured += OnEventOccured;
            m_NotificationId = 0;
            m_EventReplicationReceived = false;
            eventProcessor.NotificationForReplicationCreated += OnNotificationForReplicationCreated;
            eventProcessor.Listen();

            CheckEvent(eventType, CreateEventObjectID);
            // check if event to begin replication was created
            WaitForEvent(ref m_EventReplicationReceived, String.Format("event ReplicationRequestedByUser or NotificationReplicationRequest wasn't received for object {0}", m_EventObjectId), 500);

            //end
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.NotificationForReplicationCreated -= OnNotificationForReplicationCreated;
            eventProcessor.Stop();

            //  we are on slvl side

            //begin
            notivicationListener.NotificationReceived += OnNotificationReceived;
            notivicationListener.Listen();

            // Check if we got notification on the slvl database
            CheckReplicatedNotification(m_EventObjectId);
            // Check if we got Object on the slvl database
            CheckReceivedObject(m_EventObjectId);

            //end
            notivicationListener.NotificationReceived -= OnNotificationReceived;
            notivicationListener.Stop();
        }


        private void OnEventOccured(object sender, DataRow row, object notificationid)
        {
            switch ((EventType)((long)row["idfsEventTypeID"]))
            {
                case EventType.NewHumanCase:
                    CheckNotificationEvent(NotificationType.HumanCase, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.NewVetCase:
                    CheckNotificationEvent(NotificationType.VetCase, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.NewTestResult:
                    CheckNotificationEvent(NotificationType.TestResultsReceived, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.NewOutbreak:
                    CheckNotificationEvent(NotificationType.Outbreak, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.CaseDiseaseChange:
                    CheckNotificationEvent(NotificationType.CaseDiagnosisChangedNotification, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.CaseStatusChange:
                    CheckNotificationEvent(NotificationType.CaseStatusChangedNotification, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.SettlementChanged:
                    CheckNotificationEvent(NotificationType.SettlementChanged, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.AVRLayoutUpdate:
                    CheckNotificationEvent(NotificationType.AVRLayoutUpdate, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.ReferenceTableChanged:
                    CheckNotificationEvent(NotificationType.ReferenceTableChanged, DBNull.Value, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.NotificationReplicationRequest:
                case EventType.ReplicationRequestedByUser:
                    m_EventReplicationReceived = true;
                    break;
            }
            Dbg.Debug("After CheckNotificationEvent for event {0}.", m_EventType);

            if (((long)m_EventType).Equals(row["idfsEventTypeID"]) &&
                ((m_EventObjectId is long && m_EventObjectId.Equals(row["idfObjectID"])) ||
                 (m_EventObjectId is string && m_EventObjectId.Equals(row["strInformationString"]))))
                 m_EventReceived = true;
         }

        private void OnNotificationForReplicationCreated(object sender, IdEventArgs args)
        {
            m_NotificationId = args.Id;
        }

        private EventType m_EventType;
        private object m_EventObjectId;
        private bool m_EventReceived;
        private bool m_EventReplicationReceived;
        delegate object GetObjectOfType(EventType type);
        private void CheckEvent(EventType eventType)
        {
            CheckEvent(eventType, GetEventObjectID);
        }
        private void CheckEvent(EventType eventType, GetObjectOfType getObject)
        {
            Event_DB eventService = new Event_DB();
            eventService.SubscribeToAllEvents();
            m_EventType = eventType;
            m_EventObjectId = getObject(eventType);
            if (m_EventObjectId == null)
            {
                Dbg.Debug("no objects for event {0} exist in the database {1}.", eventType, eventService.Connection.Database);
                return;
            }
            m_EventReceived = false;
            // receive all previous events
            eventService.GetClientEvents();

            eventService.CreateEvent(eventType, m_EventObjectId, EidssUserContext.User.ID, null);
            WaitForEvent(ref m_EventReceived, String.Format("event {0} wasn't created for object {1}.", eventType, m_EventObjectId), 500);
        }

        private bool m_NotificationForReplicationReceived;
        private void OnNotificationReceived(object sender, DataRow row, object objectid)
        {
            if (m_NotificationId.Equals(row["idfNotification"]))
                m_NotificationForReplicationReceived = true;
        }

        private void CheckReplicatedNotification(object objectID)
        {
            m_NotificationForReplicationReceived = false;
            WaitForEvent(ref m_NotificationForReplicationReceived, String.Format("Notification {0} wasn't received for object {1} after replication.", m_NotificationId, objectID), 15000);
        }

        private static object GetEventObjectID(EventType eventType)
        {
            string sql;
            switch (eventType)
            {
                case EventType.CaseDiseaseChange:
                case EventType.CaseStatusChange:
                    sql = "Select Top 1 idfCase from dbo.tlbCase";
                    break;
                case EventType.NewVetCase:
                    sql = "Select Top 1 idfCase from dbo.tlbCase Where idfsCaseType = 10012003 OR idfsCaseType = 10012004";
                    break;
                case EventType.NewHumanCase:
                    sql = "Select Top 1 idfCase from dbo.tlbCase Where idfsCaseType = 10012001";
                    break;
                case EventType.NewOutbreak:
                    sql = "Select Top 1 idfOutbreak from dbo.tlbOutbreak";
                    break;
                case EventType.NewTestResult:
                    sql = "Select Top 1 idfTesting from dbo.tlbTesting";
                    break;
                case EventType.SettlementChanged:
                    sql = "Select Top 1 idfsGISBaseReference from dbo.gisBaseReference";
                    break;
                case EventType.AVRLayoutUpdate:
                    sql = "Select Top 1 idfsLayout from dbo.tasglLayout";
                    break;
                case EventType.ReferenceTableChanged:
                    return "tlbHuman";
                default:
                    return (long)0;
            }
            ErrorMessage err = null;
            object id = BaseDbService.ExecScalar(sql, ConnectionManager.DefaultInstance.Connection, ref err, null, true);
            if (Utils.IsEmpty(id))
                return null;
            return (long)id;
        }

        private static object CreateEventObjectID(EventType eventType)
        {
            string sql;
            switch (eventType)
            {
                case EventType.NewVetCase:
                    sql = "exec dbo.spTest_CreateVetCase 1";//"Select Top 1 idfCase from dbo.tlbCase Where idfsCaseType = 10012003 OR idfsCaseType = 10012004";
                    break;
                case EventType.NewHumanCase:
                    sql = "exec dbo.spTest_CreateHumanCase";//"Select Top 1 idfCase from dbo.tlbCase Where idfsCaseType = 10012001";
                    break;
                case EventType.CaseDiseaseChange:
                case EventType.CaseStatusChange:
                case EventType.NewOutbreak:
                case EventType.NewTestResult:
                case EventType.SettlementChanged:
                case EventType.AVRLayoutUpdate:
                case EventType.ReferenceTableChanged:
                    return (long)0;
                default:
                    return (long)0;
            }
            ErrorMessage err = null;
            object id = BaseDbService.ExecScalar(sql, ConnectionManager.DefaultInstance.Connection, ref err, null, true);
            if (Utils.IsEmpty(id))
                return null;
            return (long)id;
        }

        private static void CheckNotificationEvent(NotificationType type, object objectID, string data, object notificationID)
        {
            DbDataAdapter da = BaseDbService.CreateAdapter("SELECT TOP 1 * FROM tstNotification where idfNotification=" + notificationID,
                                                           ConnectionManager.DefaultInstance.Connection, false, null);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                dt = new DataTable();
                da = BaseDbService.CreateAdapter("SELECT TOP 1 * FROM tstNotificationShared where idfNotificationShared=" + notificationID,
                                                           ConnectionManager.DefaultInstance.Connection, false, null);
                da.Fill(dt);
            }
            Assert.IsTrue(dt.Rows.Count == 1, "no notification record is created during event processing");
            Assert.AreEqual((long)type, dt.Rows[0]["idfsNotificationType"], "incorrect notification type");
            Assert.AreEqual(objectID, dt.Rows[0]["idfNotificationObject"], "incorrect Object ID");
            Assert.AreEqual(data, dt.Rows[0]["strPayload"], "incorrect notification data");
            Assert.AreEqual(EidssSiteContext.Instance.SiteID, dt.Rows[0]["idfsSite"], "incorrect source site ID");
        }

        private static void CheckReceivedObject(object objectID)
        {
            DbDataAdapter da = BaseDbService.CreateAdapter("SELECT TOP 1 * FROM tlbCase where idfCase=" + objectID,
                                                           ConnectionManager.DefaultInstance.Connection, false, null);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Assert.IsTrue(dt.Rows.Count == 1, "notification object was not received during replication along with notification");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetExecutingPath()
        {
            DirectoryInfo appDir;

            Assembly asm = Assembly.GetExecutingAssembly();
            if (!asm.GetName().Name.StartsWith("nunit"))
            {
                appDir = new DirectoryInfo(Path.GetDirectoryName(GetAssemblyLocation(asm)));
                return string.Format("{0}\\", appDir.FullName);
            }
            asm = Assembly.GetCallingAssembly();
            appDir = new DirectoryInfo(Path.GetDirectoryName(GetAssemblyLocation(asm)));
            return String.Format("{0}\\", appDir.FullName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="asm"></param>
        /// <returns></returns>
        private static string GetAssemblyLocation(Assembly asm)
        {
            if (asm.CodeBase.StartsWith("file:///"))
            {
                return asm.CodeBase.Substring(8).Replace("/", "\\");
            }
            return asm.Location;
        }
        /*
        [TestMethod]
        public void NSStart()
        {
            //var configs = Directory.GetFiles(GetExecutingPath(), "EIDSS40_Ntfy*.config");
            //Assert.IsTrue(configs.Length > 0);
            var sb = new ServiceBase();
            string file = @"c:\Projects\EIDSS4\DevelopersBranch\eidss.main\bin\Debug\EIDSS40_Ntfy.exe.config";
            sb.Start(0, file);
        }
        */


        private static void CheckReplicationName(string tlvldatabase, string routineJobName, string slvldatabase)
        {
            Assert.IsNotNull(tlvldatabase, "Database Name in config file for tlvl database is empty.");
            Assert.AreNotEqual("", tlvldatabase, "Database Name in config file for tlvl database is empty.");

            Assert.IsNotNull(routineJobName, "Routine Job Name in config file for tlvl database is empty.");
            Assert.AreNotEqual("", routineJobName, "Routine Job Name in config file for tlvl database is empty.");

            Assert.IsNotNull(slvldatabase, "Database Name in config file for slvl database is empty.");
            Assert.AreNotEqual("", slvldatabase, "Database Name in config file for slvl database is empty.");

            Assert.AreNotEqual(tlvldatabase, slvldatabase, "Databases Names in config files for tlvl and slvl databases are equal.");

            MatchCollection coll = Regex.Matches(routineJobName, "[^-]+");
            Assert.IsFalse(coll.Count < 5, "Routine Job Name in config file for tlvl database has wrong pattern.");

            Assert.AreEqual(tlvldatabase, coll[4].ToString(), "tlvl database name in Routine Job Name is wrong. Must be " + tlvldatabase);
            Assert.AreEqual(slvldatabase, coll[1].ToString(), "slvl database name in Routine Job Name is wrong. Must be " + slvldatabase);
        }

        private static void WaitForEvent(ref bool eventRec, string message, int period)
        {
            int i = 20;
            while (!eventRec && i > 0)
            {
                Thread.Sleep(period);
                i--;
            }
            if (i == 0)
            {
                Assert.Fail(message);
            }
        }
    }
}
