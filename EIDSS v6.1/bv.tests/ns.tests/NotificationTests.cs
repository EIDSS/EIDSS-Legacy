using System;
using System.Globalization;
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
using eidss.model.Enums;

namespace bv.tests.ns.tests
{
    [TestClass]
    public class NotificationTests
    {
        private string m_ConfigFile;
        private object m_ParentSiteId;
        private object m_ChildSiteId;
        private long m_DiagnosisId;
        private long m_NotificationId;
        private static long m_DefaultSiteId;
        private long m_TlvlSite;
        private long m_SlvlSite;
        private long m_CdrSite;
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            ClassLoader.Init("bv_common.dll", null);
            ClassLoader.Init("bvdb_common.dll", null);
            ClassLoader.Init("eidss_common.dll", null);
            ClassLoader.Init("eidss_db.dll", null);
            DbManagerFactory.SetSqlFactory(ConnectionManager.DefaultInstance.Connection.ConnectionString);
        }
        [TestInitialize]
        public void Init()
        {

            string dir = GetExecutingPath();
            // для tlvl - базы
            m_ConfigFile = //@"c:\Projects\EIDSS4\DevelopersBranch\eidss.main\bin\Debug\EIDSS40_Ntfy.exe.config";
                string.Format("{0}\\EIDSS60_Ntfy.exe.config", dir);
            var configWriter = new ConfigWriter();
            configWriter.Read(m_ConfigFile);
            configWriter.SetItem("SQLServer", BaseSettings.SqlServer);
            configWriter.SetItem("SQLDatabase", BaseSettings.SqlDatabase);
            configWriter.SetItem("SQLUser", BaseSettings.SqlUser);
            configWriter.SetItem("SQLPassword", BaseSettings.SqlPassword);
            configWriter.Save();

            // нужно для запуска репликации с tlvl на slvl
            var credentials = new ConnectionCredentials(m_ConfigFile);
            credentials.UseAsyncConnection = true;
            JobAccessor.Instance = new JobAccessor(credentials.SQLServer, credentials.SQLUser, credentials.SQLPassword);

            ConnectionManager.Create(m_ConfigFile);
            DbManagerFactory.SetSqlFactory(ConnectionManager.DefaultInstance.Connection.ConnectionString);
            var config = new ConfigWriter(null, m_ConfigFile);
            config.Read(m_ConfigFile);

            const string sql3 = @"if exists (select * from tstGlobalSiteOptions where strName = N'{0}') 
		       update	tstGlobalSiteOptions 
		            set		strValue = cast(1 as nvarchar(200)),
				            idfsSite = null,
				            intRowStatus = 0
		            where	strName = N'{0}'
	           else
		            insert into	tstGlobalSiteOptions (strName, strValue, idfsSite, intRowStatus)
		            values (N'{0}', 1, null, 0)";
            BaseDbService.ExecSql(string.Format(sql3, "ForcedReplicationExpirationPeriodCdr"), ConnectionManager.DefaultInstance.Connection);
            BaseDbService.ExecSql(string.Format(sql3, "ForcedReplicationExpirationPeriodSlvl"), ConnectionManager.DefaultInstance.Connection);
            BaseDbService.ExecSql(string.Format(sql3, "ForcedReplicationExpirationPeriodTlvl"), ConnectionManager.DefaultInstance.Connection);



            ReplicationController.Init(credentials, m_ConfigFile);
            ModelUserContext.ClientID = config.GetItem("ClientID");
            EidssUserContext.Init();
            EidssUserContext.User.LoginName = "ntfy";
            ErrorMessage err = null;
            EidssUserContext.User.ID = (long)
                            BaseDbService.ExecScalar(
                                "select top 1 idfUserID from tstUserTable where intRowStatus = 0",
                                ConnectionManager.DefaultInstance.Connection, ref err);
            StoredProcParamsCache.InitMultiThreadProcedures(new string[] { "spNotification_Create", "spEventLog_IsSubscribed", "spGetSiteInfo", "spAudit_CreateNewEvent" });
            m_ParentSiteId = EmNotify_DB.GetParentSite(EidssSiteContext.Instance.SiteID);
            m_ChildSiteId = EmNotify_DB.GetChildSite(EidssSiteContext.Instance.SiteID);
            m_DiagnosisId = (long)
                            BaseDbService.ExecScalar(
                                "select top 1 idfsDiagnosis from trtDiagnosis where intRowStatus = 0",
                                ConnectionManager.DefaultInstance.Connection, ref err);


            m_DefaultSiteId = EidssSiteContext.Instance.SiteID;
            try
            {
                m_TlvlSite = (long)BaseDbService.ExecScalar("select top 1 s.idfsSite from tstSite s " +
                                                             "inner join tstCustomizationPackage cp on cp.idfCustomizationPackage = s.idfCustomizationPackage " +
                                                             "inner join tstSite ps on ps.idfsSite = s.idfsParentSite and ps.intRowStatus = 0 " +
                                                             "where s.idfsSiteType = 10085007 and cp.idfsCountry = dbo.fnCurrentCountry() and s.intRowStatus = 0",
                                                                ConnectionManager.DefaultInstance.Connection, ref err);
                m_SlvlSite = (long)EmNotify_DB.GetParentSite(m_TlvlSite);
                m_CdrSite = (long)EmNotify_DB.GetParentSite(m_SlvlSite);
            }
            catch (Exception e)
            {
                Dbg.Debug("There is no chain TlvlSite - SlvlSite - CdrSite in tested database.");
                Trace.WriteLine(Trace.Kind.Info, "There is no chain TlvlSite - SlvlSite - CdrSite in tested database.");
                throw e;
            }
            //Cleanup();
        }
        private void InitSiteDependentSettings(long siteId)
        {
            ChangeSite(siteId);
            EidssSiteContext.Instance.Clear();
            Assert.AreEqual(siteId, EidssSiteContext.Instance.SiteID);
        }
        public void Cleanup()
        {
            const string sql1 = " ALTER      function [dbo].[fnTriggersWork] ()" +
                                " returns bit " +
                                " as" +
                                " begin" +
                                " return 0" +
                                " END";
            const string sql2 = " ALTER      function [dbo].[fnTriggersWork] ()" +
                                " returns bit" +
                                " as" +
                                " begin" +
                                " return 1" +
                                " END";

            const string sql3 = "delete from tstGlobalSiteOptions where strName = N'{0}'";
            BaseDbService.ExecSql(sql1, ConnectionManager.DefaultInstance.Connection);
            BaseDbService.ExecProcedure("spTestNotification_DeleteTempObjects", ConnectionManager.DefaultInstance.Connection);
            BaseDbService.ExecSql(sql2, ConnectionManager.DefaultInstance.Connection);
            BaseDbService.ExecSql(string.Format(sql3, "ForcedReplicationExpirationPeriodCdr"), ConnectionManager.DefaultInstance.Connection);
            BaseDbService.ExecSql(string.Format(sql3, "ForcedReplicationExpirationPeriodSlvl"), ConnectionManager.DefaultInstance.Connection);
            BaseDbService.ExecSql(string.Format(sql3, "ForcedReplicationExpirationPeriodTlvl"), ConnectionManager.DefaultInstance.Connection);
            //ChangeSite(m_DefaultSiteId);
        }

        private readonly EventType[] m_LocalEventsToTest = new EventType[]
            {
                EventType.ClientUILanguageChanged,
                EventType.HumanCaseCreatedLocal,
                EventType.HumanCaseDiagnosisChangedLocal,
                EventType.HumanCaseClassificationChangedLocal,
                EventType.HumanTestResultRegistrationLocal,
                EventType.HumanTestResultAmendmentLocal,
                EventType.ClosedHumanCaseReopenedLocal,
                EventType.OutbreakCreatedLocal,
                EventType.NewHumanCaseAddedToOutbreakLocal,
                EventType.NewVetCaseAddedToOutbreakLocal,
                EventType.NewVsSessionAddedToOutbreakLocal,
                EventType.OutbreakStatusChangedLocal,
                EventType.OutbreakPrimaryCaseChangedLocal,
                EventType.VetCaseCreatedLocal,
                EventType.VetCaseDiagnosisChangedLocal,
                EventType.VetCaseClassificationChangedLocal,
                EventType.VetCaseFieldTestResultRegistrationLocal,
                EventType.VetCaseTestResultRegistrationLocal,
                EventType.VetCaseTestResultAmendmentLocal,
                EventType.ClosedVetCaseReopenedLocal,
                EventType.VsSessionCreatedLocal,
                EventType.VsSessionNewDiagnosisLocal,
                EventType.VsSessionFieldTestResultRegistrationLocal,
                EventType.VsSessionTestResultRegistrationLocal,
                EventType.VsSessionTestResultAmendmentLocal,
                EventType.AsCampaignCreatedLocal,
                EventType.AsSessionCreatedLocal,
                EventType.AsCampaignStatusChangedLocal,
                EventType.ClosedAsSessionReopenedLocal,
                EventType.AsSessionTestResultRegistrationLocal,
                EventType.AsSessionTestResultAmendmentLocal,
                EventType.HumanAggregateCaseCreatedLocal,
                EventType.HumanAggregateCaseChangedLocal,
                EventType.VetAggregateCaseCreatedLocal,
                EventType.VetAggregateCaseChangedLocal,
                EventType.VetAggregateActionCreatedLocal,
                EventType.VetAggregateActionChangedLocal,
                EventType.NewSampleTransferInLocal,
                EventType.TestResultForSampleTransferredIn,
                EventType.BssFormLocal,
                EventType.BssAggregateFormLocal,
                EventType.SettlementChanged,
                //EventType.AVRLayoutPublishedLocal,
                //EventType.AVRLayoutUnpublishedLocal,
                //EventType.AVRLayoutFolderPublishedLocal,
                //EventType.AVRLayoutFolderUnpublishedLocal,
                //EventType.AVRQueryPublishedLocal,
                //EventType.AVRQueryUnpublishedLocal,
                EventType.AggregateSettingsChanged,
                EventType.SecurityPolicyChanged,
                EventType.FFUNITemplateChanged,
                EventType.FFDeterminantChanged,
                EventType.ReferenceTableChanged,
                EventType.RaiseReferenceCacheChange,
                EventType.MatrixChanged,
                EventType.ReplicationRequestedByUser,
                EventType.AVRLayoutShared,
                EventType.ReplicationFailed,
                EventType.ReplicationRetrying,
                EventType.ReplicationStarted, 
                EventType.ReplicationSucceeded,
                EventType.NotificationServiceIsNotRunning

            };



        [TestMethod, Ignore]
        public void Ns_Test()
        {
            try
            {
                TestLocalEvents();
                TestNotifications();
            }
            finally
            {
                Cleanup();
            }
        }

        public void TestLocalEvents()
        {
            var eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            foreach (var e in m_LocalEventsToTest)
            {
                CheckEvent(e);
            }
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        private void ClearNotifications()
        {
            var cmd = BaseDbService.CreateSPCommand("spNotification_SelectUnprocessed",
                                                    ConnectionManager.DefaultInstance.Connection);
            BaseDbService.AddParam(cmd, "@idfsSite", EidssSiteContext.Instance.SiteID);
            var dt = BaseDbService.ExecTable(cmd);
            var cmd1 = BaseDbService.CreateSPCommand("spNotification_Process",
                                                    ConnectionManager.DefaultInstance.Connection);
            BaseDbService.AddTypedParam(cmd1, "@idfNotification", SqlDbType.BigInt);
            foreach (DataRow row in dt.Rows)
            {
                BaseDbService.SetParam(cmd1, "@idfNotification", row["idfNotification"]);
                BaseDbService.ExecCommand(cmd1, cmd1.Connection);
            }

        }
        public void TestNotifications()
        {
            ClearNotifications();
            var notificationsProcessor = new EmNotifyLstn(m_ConfigFile);
            notificationsProcessor.Listen();
            notificationsProcessor.NotificationReceived += OnNotificationReceived;
            //var eventProcessor = new EventProcessor(m_ConfigFile);
            //eventProcessor.EventOccured += OnEventOccured;
            //eventProcessor.Listen();
            foreach (var v in Enum.GetValues(typeof(NotificationType)))
            {

                if ((NotificationType) v == NotificationType.StartForcedReplication ||
                    (NotificationType) v == NotificationType.ForcedReplicationConfirmed ||
                    (NotificationType) v == NotificationType.AVRLayoutFolderPublished ||
                    (NotificationType) v == NotificationType.AVRLayoutFolderUnpublished ||
                    (NotificationType) v == NotificationType.AVRLayoutPublish ||
                    (NotificationType) v == NotificationType.AVRLayoutUnpublished ||
                    (NotificationType) v == NotificationType.AVRQueryPublished ||
                    (NotificationType) v == NotificationType.AVRQueryUnpublished
                    )
                    continue;
                CheckNotification((NotificationType)v);
            }
            //eventProcessor.EventOccured -= OnEventOccured;
            //eventProcessor.Stop();
            notificationsProcessor.Stop();
            notificationsProcessor.NotificationReceived -= OnNotificationReceived;

        }

        [TestMethod, Ignore]
        public void TestAvrNotification()
        {
            ClearNotifications();
            var notificationsProcessor = new EmNotifyLstn(m_ConfigFile);
            notificationsProcessor.Listen();
            notificationsProcessor.NotificationReceived += OnNotificationReceived;
            CheckNotification(NotificationType.AVRQueryPublished);
            notificationsProcessor.Stop();
            notificationsProcessor.NotificationReceived -= OnNotificationReceived;
        }

        [TestMethod]//, Ignore
        public void TestForcedReplicationFail()
        {
            JobAccessor.FromUnitTest = true;

            var eventProcessor = new EventProcessor(m_ConfigFile);
            var notificationsProcessor = new EmNotifyLstn(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            notificationsProcessor.NotificationReceived += OnNotificationReceived;
            notificationsProcessor.Listen();
            ClearNotifications();


            // check variant of failed replication
            JobAccessor.FromUnitTestSuccess = false;

            //!!!create initial event
            CheckEvent(EventType.ReplicationRequestedByUser);

            // imitate replication and catch ReplicationFailed event
            m_EventReplicationFailed = false;

            WaitForEvent(ref m_EventReplicationFailed, String.Format("event {0} wasn't created for site {1}.", EventType.ReplicationFailed, m_TlvlSite), 500);

            //check creating notification about replication in admin database
            //ValidateAdminNotification(m_DiagnosisId);  //- can't check admin database on tfs server

            notificationsProcessor.Stop();
            notificationsProcessor.NotificationReceived -= OnNotificationReceived;
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod, Ignore]//
        public void TestForcedReplicationSuccess()
        {
            JobAccessor.FromUnitTest = true;

            // Clear previous Notifications
            ChangeSite(m_CdrSite);
            ClearNotifications();
            ChangeSite(m_SlvlSite);
            ClearNotifications();
            ChangeSite(m_TlvlSite);
            ClearNotifications();

            var eventProcessor = new EventProcessor(m_ConfigFile);
            var notificationsProcessor = new EmNotifyLstn(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            notificationsProcessor.NotificationReceived += OnNotificationReceived;
            notificationsProcessor.Listen();


            /////////////////////////////////////////////////////////////////////////
            // check variant of started replication
            ClearNotifications();
            JobAccessor.FromUnitTestSuccess = true;

            //!!!create initial event
            CheckEvent(EventType.ReplicationRequestedByUser);

            // imitate replication and catch ReplicationFailed event
            m_EventReplicationStarted = false;
            // fill in admin database log tables entries about replication
            StartReplication(eventProcessor.Database, eventProcessor.Database + "_Admin", eventProcessor.RoutineJobName);
            FinishReplication(eventProcessor.Database, eventProcessor.Database + "_Admin", eventProcessor.RoutineJobName);

            WaitForEvent(ref m_EventReplicationStarted, String.Format("event {0} wasn't created for site {1}.", EventType.ReplicationStarted, m_TlvlSite), 500);

            //check creating notification about replication in admin database
            ValidateAdminNotification(m_NotificationId);


            notificationsProcessor.Stop();
            notificationsProcessor.NotificationReceived -= OnNotificationReceived;
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();

            // check SLVL
            ChangeSite(m_SlvlSite);
            eventProcessor = new EventProcessor(m_ConfigFile);
            notificationsProcessor = new EmNotifyLstn(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            notificationsProcessor.NotificationReceived += OnNotificationReceived;
            notificationsProcessor.Listen();

            WaitForNotification(String.Format("Notification StartForcedReplication was not created for site {0}.", m_SlvlSite), 500);

            //check creating notification about replication in admin database
            ValidateAdminNotification(m_NotificationId);


            m_EventReplicationStarted = false;
            StartReplication(eventProcessor.Database, eventProcessor.Database + "_Admin", eventProcessor.RoutineJobName);
            FinishReplication(eventProcessor.Database, eventProcessor.Database + "_Admin", eventProcessor.RoutineJobName);

            WaitForEvent(ref m_EventReplicationStarted, String.Format("event {0} wasn't created for site {1}.", EventType.ReplicationStarted, m_SlvlSite), 500);

            notificationsProcessor.Stop();
            notificationsProcessor.NotificationReceived -= OnNotificationReceived;
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();

            // check CDR
            ChangeSite(m_CdrSite);
            eventProcessor = new EventProcessor(m_ConfigFile);
            notificationsProcessor = new EmNotifyLstn(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            notificationsProcessor.NotificationReceived += OnNotificationReceived;
            notificationsProcessor.Listen();

            WaitForNotification(String.Format("Notification StartForcedReplication was not created for site {0}.", m_CdrSite), 500);
            ValidateCreationNotification(NotificationType.ForcedReplicationConfirmed, m_NotificationId, EidssSiteContext.Instance.SiteID, m_SlvlSite, m_TlvlSite);

            m_EventReplicationStarted = false;
            StartReplication(eventProcessor.Database, eventProcessor.Database + "_Admin", eventProcessor.RoutineJobName);
            FinishReplication(eventProcessor.Database, eventProcessor.Database + "_Admin", eventProcessor.RoutineJobName);

            //WaitForEvent(ref m_EventReplicationStarted, String.Format("event {0} wasn't created for site {1}.", EventType.ReplicationStarted, m_CdrSite), 500);

            notificationsProcessor.Stop();
            notificationsProcessor.NotificationReceived -= OnNotificationReceived;
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();

        }

        //private void CheckSlvlFrNotification(NotificationType startForcedReplication)
        //{
        //    throw new NotImplementedException();
        //    //CheckNotification(startForcedReplication);
        //}

        private static void ChangeSite(long siteId)
        {
            string sql = string.Format("update tstLocalSiteOptions set strValue = {0} where strName = 'SiteID';" +
                                       "update tstLocalSiteOptions set strValue = (select idfsSiteType from tstSite where idfsSite = {0}) where strName = 'SiteType'",
                                       siteId);
            BaseDbService.ExecSql(sql, ConnectionManager.DefaultInstance.Connection);
            EidssSiteContext.Instance.Clear();
            Assert.AreEqual(siteId, EidssSiteContext.Instance.SiteID);
            Trace.WriteLine(Trace.Kind.Info, String.Format("Test: Site changed to {0}.", siteId));

        }
        private object m_LocalAvrId;
        private void CheckNotification(NotificationType notificationType, bool createNotif = true)
        {
            string notifyData;
            var notifyDb = new EmNotify_DB();
            var objectId = GetNotifcationObjectId(notificationType, out notifyData);
            if (objectId == null && Utils.IsEmpty(notifyData))
            {
                Dbg.Debug("no objects for notification {0} exist in the database {1}.", notificationType, notifyDb.Connection.Database);
                Trace.WriteLine(Trace.Kind.Info, String.Format("Test: no objects for notification {0} exist in the database {1}.", notificationType, notifyDb.Connection.Database));
                return;
            }
            switch (notificationType)
            {
                case NotificationType.AVRLayoutUnpublished:
                case NotificationType.AVRLayoutFolderUnpublished:
                case NotificationType.AVRQueryUnpublished:
                    m_LocalAvrId = getAvrLocalId(notificationType, (long)objectId);
                    break;
            }

            var diagnosisId = GetDiagnosisForNotification(notificationType);
            var siteId = !Utils.IsEmpty(m_ChildSiteId) ? m_ChildSiteId : m_ParentSiteId;

            if (createNotif)
                notifyDb.CreateNotification(notificationType, (long)objectId, diagnosisId, notifyData, siteId, siteId,
                                        EidssSiteContext.Instance.SiteID);
            WaitForNotification(String.Format("notification {0} wasn't created for object {1}.", notificationType, objectId), 500);
        }


        private long GetDiagnosisForNotification(NotificationType notificationType)
        {
            switch (notificationType)
            {
                case NotificationType.HumanCase:
                case NotificationType.HumanCaseDiagnosisChange:
                case NotificationType.HumanCaseClassificationChange:
                case NotificationType.HumanCaseTestResultRegistration:
                case NotificationType.HumanCaseTestResultAmendment:
                case NotificationType.HumanCaseReopened:
                case NotificationType.VetCase:
                case NotificationType.VetCaseClassificationChange:
                case NotificationType.VetCaseDiagnosisChange:
                case NotificationType.VetCaseFieldTestResultRegistration:
                case NotificationType.VetCaseTestResultRegistration:
                case NotificationType.VetCaseTestResultAmendment:
                case NotificationType.VetCaseReopened:
                    return m_DiagnosisId;
                default:
                    return 0;
            }
        }

        private object GetNotifcationObjectId(NotificationType notificationType, out string notifyData)
        {
            var cmd = BaseDbService.CreateSPCommand("spTestNotification_GetObjectID",
                                                    ConnectionManager.DefaultInstance.Connection);
            notifyData = "";
            StoredProcParamsCache.CreateParameters(cmd);
            switch (notificationType)
            {
                case NotificationType.HumanCase:
                case NotificationType.HumanCaseDiagnosisChange:
                case NotificationType.HumanCaseClassificationChange:
                case NotificationType.HumanCaseTestResultRegistration:
                case NotificationType.HumanCaseTestResultAmendment:
                case NotificationType.HumanCaseReopened:
                    BaseDbService.SetParam(cmd, "@objectType", "humancase");
                    notifyData = m_DiagnosisId.ToString(CultureInfo.InvariantCulture);
                    break;
                case NotificationType.Outbreak:
                case NotificationType.OutbreakNewHumanCaseAddition:
                case NotificationType.OutbreakNewVetCaseAddition:
                case NotificationType.OutbreakNewVsSessionAddition:
                case NotificationType.OutbreakStatusChange:
                case NotificationType.OutbreakPrimaryCaseChange:
                    BaseDbService.SetParam(cmd, "@objectType", "outbreak");
                    break;
                case NotificationType.VetCase:
                case NotificationType.VetCaseClassificationChange:
                case NotificationType.VetCaseDiagnosisChange:
                case NotificationType.VetCaseFieldTestResultRegistration:
                case NotificationType.VetCaseTestResultRegistration:
                case NotificationType.VetCaseTestResultAmendment:
                case NotificationType.VetCaseReopened:
                    BaseDbService.SetParam(cmd, "@objectType", "vetcase");
                    notifyData = m_DiagnosisId.ToString(CultureInfo.InvariantCulture);
                    break;
                case NotificationType.VsSession:
                case NotificationType.VsSessionDiagnosisDetection:
                case NotificationType.VsSessionFieldTestResultRegistration:
                case NotificationType.VsSessionTestResultAmendment:
                case NotificationType.VsSessionTestResultRegistration:
                    BaseDbService.SetParam(cmd, "@objectType", "vssession");
                    break;
                case NotificationType.AsCampaign:
                case NotificationType.AsCampaignStatusChange:
                    BaseDbService.SetParam(cmd, "@objectType", "ascampain");
                    break;
                case NotificationType.AsSession:
                case NotificationType.AsSessionReopened:
                case NotificationType.AsSessionTestResultAmendment:
                case NotificationType.AsSessionTestResultRegistration:
                    BaseDbService.SetParam(cmd, "@objectType", "assession");
                    break;
                case NotificationType.HumanAggregateCase:
                case NotificationType.HumanAggregateCaseChange:
                case NotificationType.VetAggregateCase:
                case NotificationType.VetAggregateCaseChange:
                case NotificationType.VetAggregateAction:
                case NotificationType.VetAggregateActionChange:
                    BaseDbService.SetParam(cmd, "@objectType", "aggrcase");
                    break;
                case NotificationType.NewSampleTransferIn:
                    BaseDbService.SetParam(cmd, "@objectType", "transferout");
                    break;
                case NotificationType.TestResultForSampleTransferredOut:
                    BaseDbService.SetParam(cmd, "@objectType", "test");
                    break;
                case NotificationType.BssForm:
                    BaseDbService.SetParam(cmd, "@objectType", "bss");
                    break;
                case NotificationType.BssAggregateForm:
                    BaseDbService.SetParam(cmd, "@objectType", "bssaggr");
                    break;
                case NotificationType.SettlementChanged:
                    BaseDbService.SetParam(cmd, "@objectType", "settlement");
                    break;
                case NotificationType.AVRLayoutPublish:
                    BaseDbService.SetParam(cmd, "@objectType", "layoutToPublish");
                    break;
                case NotificationType.AVRLayoutUnpublished:
                    BaseDbService.SetParam(cmd, "@objectType", "layoutgl");
                    break;
                case NotificationType.AVRLayoutFolderPublished:
                    BaseDbService.SetParam(cmd, "@objectType", "folderToPublish");
                    break;
                case NotificationType.AVRLayoutFolderUnpublished:
                    BaseDbService.SetParam(cmd, "@objectType", "foldergl");
                    break;
                case NotificationType.AVRQueryPublished:
                case NotificationType.AVRQueryUnpublished:
                    BaseDbService.SetParam(cmd, "@objectType", "querygl");
                    break;
                case NotificationType.FFTemplateChange:
                case NotificationType.FFTemplateDeterminantChange:
                    BaseDbService.SetParam(cmd, "@objectType", "fftemplate");
                    break;
                case NotificationType.ReferenceTableChanged:
                case NotificationType.RaiseReferenceCacheChange:
                    notifyData = "SpeciesTypeDetail";
                    return 0L;
                case NotificationType.MatrixChange:
                    notifyData = "Diagnosis2DiagnosisAgeGroupMasterDetail";
                    return 0L;
                case NotificationType.ForcedReplicationConfirmed:
                case NotificationType.StartForcedReplication:
                    return !Utils.IsEmpty(m_ChildSiteId) ? m_ChildSiteId : m_ParentSiteId;
                case NotificationType.SecurityPolicyChange:
                    return 0L;
                default:
                    return 0L;
            }
            ErrorMessage err = null;
            object id = BaseDbService.ExecScalar(cmd, ConnectionManager.DefaultInstance.Connection, ref err, null, true);
            if (Utils.IsEmpty(id))
                return null;
            return (long)id;
        }

        private static long getAvrLocalId(NotificationType type, long publishedId)
        {
            var cmd = BaseDbService.CreateSPCommand("spTestNotification_GetAvrLocalID",
                                                    ConnectionManager.DefaultInstance.Connection);
            BaseDbService.AddParam(cmd, "@notificationType", (long)type);
            BaseDbService.AddParam(cmd, "@globalId", publishedId);
            ErrorMessage errMsg = null;
            var res = BaseDbService.ExecScalar(cmd, ConnectionManager.DefaultInstance.Connection, ref errMsg);
            return Utils.IsEmpty(res) ? 0L : (long)res;
        }
        private static DataRow GetLastNotificationRow()
        {
            string sql = "SELECT Top 1 * from ( " +
"Select		tstNotification.idfNotification, " +
"		idfUserID, " +
"		idfsSite, " +
"		datCreationDate, " +
"		datEnteringDate, " +
"		strPayload, " +
"		idfsNotificationType, " +
"		ISNULL(s.intProcessed,0) AS intProcessed, " +
"		idfsTargetSite, " +
"		idfsTargetSiteType, " +
"		idfTargetUserID, " +
"		idfsNotificationObjectType, " +
"		idfNotificationObject " +
"From		tstNotification " +
"INNER Join	tstNotificationStatus s ON " +
"		s.idfNotification = tstNotification.idfNotification " +
"Where ISNULL(s.intProcessed,0)<>1 and ISNULL(s.intSessionID,0)=0 " +//tstNotification.idfsSite<>dbo.fnSiteID() and 
"UNION ALL " +
"Select	 " +
"		tstNotificationShared.idfNotificationShared as idfNotification,  " +
"		idfUserID,  " +
"		idfsSite,  " +
"		datCreationDate, " +
"		datEnteringDate, " +
"		strPayload,  " +
"		idfsNotificationType, " +
"		ISNULL(s.intProcessed,0) AS intProcessed, " +
"		idfsTargetSite, " +
"		idfsTargetSiteType, " +
"		idfTargetUserID, " +
"		idfsNotificationObjectType, " +
"		idfNotificationObject " +
"From		tstNotificationShared " +
"INNER Join	tstNotificationStatus s ON " +
"		s.idfNotification = tstNotificationShared.idfNotificationShared " +
"Where ISNULL(s.intProcessed,0)<>1 and ISNULL(s.intSessionID,0)=0) as a " +
"order by a.idfNotification desc";//tstNotificationShared.idfsSite<>dbo.fnSiteID() and 
            var cmd = BaseDbService.CreateCommand(sql,
                                                    ConnectionManager.DefaultInstance.Connection);
            var dt = BaseDbService.ExecTable(cmd);
            if (dt.Rows.Count == 0)
                return null;
            return dt.Rows[0];
        }
        private void OnNotificationReceived(object sender, DataRow row, object eventId)
        {
            var type = (NotificationType)((long)row["idfsNotificationType"]);
            var notifyData = Utils.Str(row["strPayLoad"]);
            switch (type)
            {
                case NotificationType.HumanCase:
                case NotificationType.HumanCaseDiagnosisChange:
                case NotificationType.HumanCaseClassificationChange:
                case NotificationType.HumanCaseTestResultRegistration:
                case NotificationType.HumanCaseTestResultAmendment:
                case NotificationType.HumanCaseReopened:
                case NotificationType.VetCase:
                case NotificationType.VetCaseClassificationChange:
                case NotificationType.VetCaseDiagnosisChange:
                case NotificationType.VetCaseFieldTestResultRegistration:
                case NotificationType.VetCaseTestResultRegistration:
                case NotificationType.VetCaseTestResultAmendment:
                case NotificationType.VetCaseReopened:
                    ValidateNotificationProcessing(EmNotifyLstn.Notification2RemoteEvent[type], row["idfNotificationObject"], Utils.Str(row["strPayload"]), string.Empty, eventId);
                    break;
                case NotificationType.Outbreak:
                case NotificationType.OutbreakNewHumanCaseAddition:
                case NotificationType.OutbreakNewVetCaseAddition:
                case NotificationType.OutbreakNewVsSessionAddition:
                case NotificationType.OutbreakStatusChange:
                case NotificationType.OutbreakPrimaryCaseChange:
                case NotificationType.VsSession:
                case NotificationType.VsSessionDiagnosisDetection:
                case NotificationType.VsSessionFieldTestResultRegistration:
                case NotificationType.VsSessionTestResultAmendment:
                case NotificationType.VsSessionTestResultRegistration:
                case NotificationType.AsCampaign:
                case NotificationType.AsCampaignStatusChange:
                case NotificationType.AsSession:
                case NotificationType.AsSessionReopened:
                case NotificationType.AsSessionTestResultAmendment:
                case NotificationType.AsSessionTestResultRegistration:
                case NotificationType.HumanAggregateCase:
                case NotificationType.HumanAggregateCaseChange:
                case NotificationType.VetAggregateCase:
                case NotificationType.VetAggregateCaseChange:
                case NotificationType.VetAggregateAction:
                case NotificationType.VetAggregateActionChange:
                case NotificationType.BssForm:
                case NotificationType.BssAggregateForm:
                    ValidateNotificationProcessing(EmNotifyLstn.Notification2RemoteEvent[type], row["idfNotificationObject"], string.Empty, string.Empty, eventId);
                    break;
                case NotificationType.SettlementChanged:
                    m_NotificationReceived = true;
                    break;
                case NotificationType.AVRLayoutPublish:
                    m_LocalAvrId = getAvrLocalId(type, (long)row["idfNotificationObject"]);
                    ValidateNotificationProcessing(EventType.AVRLayoutPublishedRemote, m_LocalAvrId, string.Empty, string.Empty, eventId);
                    break;
                case NotificationType.AVRLayoutUnpublished:
                    ValidateNotificationProcessing(EventType.AVRLayoutUnpublishedRemote, m_LocalAvrId, string.Empty, string.Empty, eventId);
                    m_NotificationReceived = true;
                    break;
                case NotificationType.AVRLayoutFolderPublished:
                    m_LocalAvrId = getAvrLocalId(type, (long)row["idfNotificationObject"]);
                    ValidateNotificationProcessing(EventType.AVRLayoutFolderPublishedRemote, m_LocalAvrId, string.Empty, string.Empty, eventId);
                    break;
                case NotificationType.AVRLayoutFolderUnpublished:
                    ValidateNotificationProcessing(EventType.AVRLayoutFolderUnpublishedRemote, m_LocalAvrId, string.Empty, string.Empty, eventId);
                    break;
                case NotificationType.AVRQueryPublished:
                    m_LocalAvrId = getAvrLocalId(type, (long)row["idfNotificationObject"]);
                    ValidateNotificationProcessing(EventType.AVRQueryPublishedRemote, m_LocalAvrId, string.Empty, string.Empty, eventId);
                    break;
                case NotificationType.AVRQueryUnpublished:
                    ValidateNotificationProcessing(EventType.AVRQueryUnpublishedRemote, m_LocalAvrId, string.Empty, string.Empty, eventId);
                    break;
                case NotificationType.AggregateSettingsChange:
                    ValidateNotificationProcessing(EventType.AggregateSettingsChanged, DBNull.Value, string.Empty, string.Empty, eventId);
                    break;
                case NotificationType.SecurityPolicyChange:
                    ValidateNotificationProcessing(EventType.SecurityPolicyChanged, DBNull.Value, string.Empty, string.Empty, eventId);
                    break;
                case NotificationType.FFTemplateChange:
                    ValidateNotificationProcessing(EventType.FFUNITemplateChanged, row["idfNotificationObject"], string.Empty, string.Empty, eventId);
                    break;
                case NotificationType.FFTemplateDeterminantChange:
                    ValidateNotificationProcessing(EventType.FFDeterminantChanged, row["idfNotificationObject"], string.Empty, string.Empty, eventId);
                    break;
                case NotificationType.NewSampleTransferIn:
                    ValidateNotificationProcessing(EventType.NewSampleTransferIn, row["idfNotificationObject"], string.Empty, string.Empty, eventId);
                    break;
                case NotificationType.TestResultForSampleTransferredOut:
                    ValidateNotificationProcessing(EventType.TestResultForSampleTransferredOut, row["idfNotificationObject"], string.Empty, string.Empty, eventId);
                    break;
                case NotificationType.ReferenceTableChanged:
                    if (notifyData != "")
                        ValidateNotificationProcessing(EventType.ReferenceTableChanged, DBNull.Value, string.Empty, notifyData, eventId);
                    break;
                case NotificationType.RaiseReferenceCacheChange:
                    if (notifyData != "")
                        ValidateNotificationProcessing(EventType.RaiseReferenceCacheChange, DBNull.Value, string.Empty, notifyData, eventId);
                    break;
                case NotificationType.MatrixChange:
                    if (notifyData != "")
                        ValidateNotificationProcessing(EventType.MatrixChanged, DBNull.Value, string.Empty, notifyData, eventId);
                    break;
                case NotificationType.ForcedReplicationConfirmed:
                    break;
                case NotificationType.StartForcedReplication:
                    ValidateNotificationReplication(row, m_NotificationId, m_TlvlSite);
                    break;
                default:
                    Dbg.Debug("unprocessed notification type {0}", type);
                    Trace.WriteLine(Trace.Kind.Info, String.Format("Test: unprocessed notification type {0}.", type));
                    break;
            }
            m_NotificationReceived = true;
        }
        private void OnSlvlFrNotificationReceived(object sender, DataRow row, object eventId)
        {
            var type = (NotificationType)((long)row["idfsNotificationType"]);
            var notifyData = Utils.Str(row["strPayLoad"]);
            switch (type)
            {
                case NotificationType.ForcedReplicationConfirmed:
                case NotificationType.StartForcedReplication:
                    m_NotificationReceived = true;

                    break;
            }
        }

        //[TestMethod]
        //public void Event_NewHumanCase_Test()
        //{
        //    var eventProcessor = new EventProcessor(m_ConfigFile);
        //    eventProcessor.EventOccured += OnEventOccured;
        //    eventProcessor.Listen();
        //    CheckEvent(EventType.HumanCaseCreatedLocal);
        //    eventProcessor.EventOccured -= OnEventOccured;
        //    eventProcessor.Stop();
        //}



        //private EmNotify_DB m_NotificationService;
        //[TestMethod, Ignore]
        //public void NotificationProcessorInitTest()
        //{
        //    // для slvl - базы
        //    var notivicationListener = new EmNotifyLstn(string.Format("{0}\\{1}", m_DirToConfigFile, m_NameSlvlConfigFile));
        //    m_NotificationService = new EmNotify_DB(null, "12345") { SiteID = 6 };
        //}

        //private long m_NotificationId;
        //[TestMethod, Ignore]
        //public void Replication_NewHumanCase_Test()
        //{
        //    CheckReplication(EventType.HumanCaseCreatedLocal);
        //}
        //[TestMethod, Ignore]
        //public void Replication_NewVetCase_Test()
        //{
        //    CheckReplication(EventType.VetCaseCreatedLocal);
        //}

        //private void CheckReplication(EventType eventType)
        //{
        //    var eventProcessor = new EventProcessor(m_ConfigFile);//for work with tlvl database
        //    // для slvl - базы
        //    EmNotifyLstn notivicationListener = new EmNotifyLstn(string.Format("{0}\\{1}", m_DirToConfigFile, m_NameSlvlConfigFile));//for work with slvl database
        //    CheckReplicationName(eventProcessor.Database, eventProcessor.RoutineJobName, notivicationListener.Connection.Database);

        //    //  we are on tlvl side

        //    //begin
        //    eventProcessor.EventOccured += OnEventOccured;
        //    m_NotificationId = 0;
        //    m_EventReplicationReceived = false;
        //    eventProcessor.NotificationForReplicationCreated += OnNotificationForReplicationCreated;
        //    eventProcessor.Listen();

        //    CheckEvent(eventType, CreateEventObjectID);
        //    // check if event to begin replication was created
        //    WaitForEvent(ref m_EventReplicationReceived, String.Format("event ReplicationRequestedByUser or NotificationReplicationRequest wasn't received for object {0}", m_EventObjectId), 500);

        //    //end
        //    eventProcessor.EventOccured -= OnEventOccured;
        //    eventProcessor.NotificationForReplicationCreated -= OnNotificationForReplicationCreated;
        //    eventProcessor.Stop();

        //    //  we are on slvl side

        //    //begin
        //    notivicationListener.NotificationReceived += OnNotificationReceived;
        //    notivicationListener.Listen();

        //    // Check if we got notification on the slvl database
        //    CheckReplicatedNotification(m_EventObjectId);
        //    // Check if we got Object on the slvl database
        //    CheckReceivedObject(m_EventObjectId);

        //    //end
        //    notivicationListener.NotificationReceived -= OnNotificationReceived;
        //    notivicationListener.Stop();
        //}


        private void OnEventOccured(object sender, DataRow row, object notificationid)
        {
            object globalAvrId;
            switch ((EventType)((long)row["idfsEventTypeID"]))
            {
                case EventType.HumanCaseCreatedLocal:
                    ValidateEventProcessing(NotificationType.HumanCase, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.HumanCaseDiagnosisChangedLocal:
                    ValidateEventProcessing(NotificationType.HumanCaseDiagnosisChange, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.HumanCaseClassificationChangedLocal:
                    ValidateEventProcessing(NotificationType.HumanCaseClassificationChange, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.HumanTestResultRegistrationLocal:
                    ValidateEventProcessing(NotificationType.HumanCaseTestResultRegistration, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.HumanTestResultAmendmentLocal:
                    ValidateEventProcessing(NotificationType.HumanCaseTestResultAmendment, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.ClosedHumanCaseReopenedLocal:
                    ValidateEventProcessing(NotificationType.HumanCaseReopened, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.OutbreakCreatedLocal:
                    ValidateEventProcessing(NotificationType.Outbreak, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.NewHumanCaseAddedToOutbreakLocal:
                    ValidateEventProcessing(NotificationType.OutbreakNewHumanCaseAddition, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.NewVetCaseAddedToOutbreakLocal:
                    ValidateEventProcessing(NotificationType.OutbreakNewVetCaseAddition, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.NewVsSessionAddedToOutbreakLocal:
                    ValidateEventProcessing(NotificationType.OutbreakNewVsSessionAddition, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.OutbreakStatusChangedLocal:
                    ValidateEventProcessing(NotificationType.OutbreakStatusChange, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.OutbreakPrimaryCaseChangedLocal:
                    ValidateEventProcessing(NotificationType.OutbreakPrimaryCaseChange, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.VetCaseCreatedLocal:
                    ValidateEventProcessing(NotificationType.VetCase, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.VetCaseDiagnosisChangedLocal:
                    ValidateEventProcessing(NotificationType.VetCaseDiagnosisChange, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.VetCaseClassificationChangedLocal:
                    ValidateEventProcessing(NotificationType.VetCaseClassificationChange, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.VetCaseFieldTestResultRegistrationLocal:
                    ValidateEventProcessing(NotificationType.VetCaseFieldTestResultRegistration, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.VetCaseTestResultRegistrationLocal:
                    ValidateEventProcessing(NotificationType.VetCaseTestResultRegistration, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.VetCaseTestResultAmendmentLocal:
                    ValidateEventProcessing(NotificationType.VetCaseTestResultAmendment, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.ClosedVetCaseReopenedLocal:
                    ValidateEventProcessing(NotificationType.VetCaseReopened, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.VsSessionCreatedLocal:
                    ValidateEventProcessing(NotificationType.VsSession, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.VsSessionNewDiagnosisLocal:
                    ValidateEventProcessing(NotificationType.VsSessionDiagnosisDetection, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.VsSessionFieldTestResultRegistrationLocal:
                    ValidateEventProcessing(NotificationType.VsSessionFieldTestResultRegistration, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.VsSessionTestResultRegistrationLocal:
                    ValidateEventProcessing(NotificationType.VsSessionTestResultRegistration, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.VsSessionTestResultAmendmentLocal:
                    ValidateEventProcessing(NotificationType.VsSessionTestResultAmendment, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.AsCampaignCreatedLocal:
                    ValidateEventProcessing(NotificationType.AsCampaign, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.AsSessionCreatedLocal:
                    ValidateEventProcessing(NotificationType.AsSession, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.AsCampaignStatusChangedLocal:
                    ValidateEventProcessing(NotificationType.AsCampaignStatusChange, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.ClosedAsSessionReopenedLocal:
                    ValidateEventProcessing(NotificationType.AsSessionReopened, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.AsSessionTestResultRegistrationLocal:
                    ValidateEventProcessing(NotificationType.AsSessionTestResultRegistration, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.AsSessionTestResultAmendmentLocal:
                    ValidateEventProcessing(NotificationType.AsSessionTestResultAmendment, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.HumanAggregateCaseCreatedLocal:
                    ValidateEventProcessing(NotificationType.HumanAggregateCase, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.HumanAggregateCaseChangedLocal:
                    ValidateEventProcessing(NotificationType.HumanAggregateCaseChange, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.VetAggregateCaseCreatedLocal:
                    ValidateEventProcessing(NotificationType.VetAggregateCase, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.VetAggregateCaseChangedLocal:
                    ValidateEventProcessing(NotificationType.VetAggregateCaseChange, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.VetAggregateActionCreatedLocal:
                    ValidateEventProcessing(NotificationType.VetAggregateAction, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.VetAggregateActionChangedLocal:
                    ValidateEventProcessing(NotificationType.VetAggregateActionChange, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.NewSampleTransferIn:
                    ValidateEventProcessing(NotificationType.NewSampleTransferIn, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.TestResultForSampleTransferredIn:
                    ValidateEventProcessing(NotificationType.TestResultForSampleTransferredOut, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.BssFormLocal:
                    ValidateEventProcessing(NotificationType.BssForm, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.BssAggregateFormLocal:
                    ValidateEventProcessing(NotificationType.BssAggregateForm, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.SettlementChanged:
                    ValidateEventProcessing(NotificationType.SettlementChanged, m_EventObjectId, string.Empty, notificationid);
                    break;
                case EventType.AVRLayoutPublishedLocal:
                    globalAvrId = NotificationManager.GetPublisedObjectId(NotificationType.AVRLayoutPublish,
                                                                              (long)m_EventObjectId);
                    ValidateEventProcessing(NotificationType.AVRLayoutPublish, globalAvrId, String.Empty, notificationid);
                    break;
                case EventType.AVRLayoutUnpublishedLocal:
                    globalAvrId = NotificationManager.GetPublisedObjectId(NotificationType.AVRLayoutUnpublished,
                                                                              (long)m_EventObjectId);
                    ValidateEventProcessing(NotificationType.AVRLayoutUnpublished, globalAvrId, String.Empty, notificationid);
                    break;
                case EventType.AVRLayoutFolderPublishedLocal:
                    globalAvrId = NotificationManager.GetPublisedObjectId(NotificationType.AVRLayoutFolderPublished,
                                                                              (long)m_EventObjectId);
                    ValidateEventProcessing(NotificationType.AVRLayoutFolderPublished, globalAvrId, String.Empty, notificationid);
                    break;
                case EventType.AVRLayoutFolderUnpublishedLocal:
                    globalAvrId = NotificationManager.GetPublisedObjectId(NotificationType.AVRLayoutFolderUnpublished,
                                                                              (long)m_EventObjectId);
                    ValidateEventProcessing(NotificationType.AVRLayoutFolderUnpublished, globalAvrId, String.Empty, notificationid);
                    break;
                case EventType.AVRQueryPublishedLocal:
                    globalAvrId = NotificationManager.GetPublisedObjectId(NotificationType.AVRQueryPublished,
                                                                              (long)m_EventObjectId);
                    ValidateEventProcessing(NotificationType.AVRQueryPublished, globalAvrId, String.Empty, notificationid);
                    break;
                case EventType.AVRQueryUnpublishedLocal:
                    globalAvrId = NotificationManager.GetPublisedObjectId(NotificationType.AVRQueryUnpublished,
                                                                              (long)m_EventObjectId);
                    ValidateEventProcessing(NotificationType.AVRQueryUnpublished, globalAvrId, String.Empty, notificationid);
                    break;
                case EventType.AggregateSettingsChanged:
                    ValidateEventProcessing(NotificationType.AggregateSettingsChange, DBNull.Value, String.Empty, notificationid);
                    break;
                case EventType.SecurityPolicyChanged:
                    ValidateEventProcessing(NotificationType.SecurityPolicyChange, DBNull.Value, String.Empty, notificationid);
                    break;
                case EventType.FFUNITemplateChanged:
                    ValidateEventProcessing(NotificationType.FFTemplateChange, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.FFDeterminantChanged:
                    ValidateEventProcessing(NotificationType.FFTemplateDeterminantChange, m_EventObjectId, String.Empty, notificationid);
                    break;
                case EventType.ReferenceTableChanged:
                    ValidateEventProcessing(NotificationType.ReferenceTableChanged, DBNull.Value, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.RaiseReferenceCacheChange:
                    ValidateEventProcessing(NotificationType.RaiseReferenceCacheChange, DBNull.Value, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.MatrixChanged:
                    ValidateEventProcessing(NotificationType.MatrixChange, DBNull.Value, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.ReplicationRequestedByUser:
                    m_EventReplicationReceived = true;//for replication tests
                    m_NotificationId = (long)notificationid; // remember first replication notification for future comparing
                    ValidateEventProcessing(NotificationType.StartForcedReplication, EidssSiteContext.Instance.SiteID, String.Empty, notificationid);
                    break;
                case EventType.ReplicationFailed:
                    m_EventReplicationFailed = true;
                    Assert.AreEqual(EidssSiteContext.Instance.SiteID, row["idfsSite"], "incorrect source site ID");
                    break;
                case EventType.ReplicationStarted:
                    m_EventReplicationStarted = true;
                    Assert.AreEqual(EidssSiteContext.Instance.SiteID, row["idfsSite"], "incorrect source site ID");
                    break;
                case EventType.ForcedReplicationExpired:
                    m_EventReplicationReceived = true;//for replication tests
                    break;
                //Events without notification
                case EventType.AVRLayoutShared:
                case EventType.ReplicationRetrying:
                case EventType.NotificationServiceIsNotRunning:
                case EventType.ClientUILanguageChanged:
                case EventType.ReplicationSucceeded:
                    break;
            }
            Dbg.Debug("After CheckNotificationEvent for event {0}.", m_EventType);
            Trace.WriteLine(Trace.Kind.Info, String.Format("Test: After CheckNotificationEvent for event type {0}, event id = {1}, notification id={2}.", ((EventType)((long)row["idfsEventTypeID"])).ToString(), row["idfEventID"], notificationid));

            // Check that we received event of the waited type and for waited object
            if (((long)m_EventType).Equals(row["idfsEventTypeID"]) &&
                (
                 (m_EventObjectId is ReplicationType && (long)m_EventObjectId == (long)row["idfObjectID"]) ||
                 (m_EventObjectId is long && m_EventObjectId.Equals(row["idfObjectID"])) ||
                 (m_EventObjectId is string && m_EventObjectId.Equals(row["strInformationString"]))
                )
               )
                m_EventReceived = true;
        }

        //private void OnNotificationForReplicationCreated(object sender, IdEventArgs args)
        //{
        //    m_NotificationId = args.Id;
        //}

        private EventType m_EventType;
        private object m_EventObjectId;
        private bool m_EventReceived;
        private bool m_NotificationReceived;
        private bool m_EventReplicationReceived;
        private bool m_EventReplicationFailed;
        private bool m_EventReplicationStarted;
        delegate object GetObjectOfType(EventType type);
        private void CheckEvent(EventType eventType, bool createEvent = true)
        {
            CheckEvent(eventType, GetEventObjectID, createEvent);
        }
        private void CheckEvent(EventType eventType, GetObjectOfType getObject, bool createEvent = true)
        {
            Event_DB eventService = new Event_DB();
            eventService.IsNotificationService = true;
            eventService.SubscribeToAllEvents();
            m_EventType = eventType;
            m_EventObjectId = getObject(eventType);
            if (m_EventObjectId == null)
            {
                Dbg.Debug("no objects for event {0} exist in the database {1}.", eventType, eventService.Connection.Database);
                Trace.WriteLine(Trace.Kind.Info, String.Format("Test: no objects for event {0} exist in the database {1}.", eventType, eventService.Connection.Database));
                return;
            }
            m_EventReceived = false;

            if (createEvent)
            {
                // receive all previous events
                eventService.GetClientEvents();

                eventService.CreateEvent(eventType, m_EventObjectId, null, null, EidssUserContext.User.ID, null);
            }

            WaitForEvent(ref m_EventReceived, String.Format("event {0} wasn't created for object {1}.", eventType, m_EventObjectId), 500);
        }

        //private bool m_NotificationForReplicationReceived;
        //private void OnNotificationReceived(object sender, DataRow row, object objectid)
        //{
        //    if (m_NotificationId.Equals(row["idfNotification"]))
        //        m_NotificationForReplicationReceived = true;
        //}

        //private void CheckReplicatedNotification(object objectID)
        //{
        //    m_NotificationForReplicationReceived = false;
        //    WaitForEvent(ref m_NotificationForReplicationReceived, String.Format("Notification {0} wasn't received for object {1} after replication.", m_NotificationId, objectID), 15000);
        //}

        private static object GetEventObjectID(EventType eventType)
        {
            var cmd = BaseDbService.CreateSPCommand("spTestNotification_GetObjectID",
                                                    ConnectionManager.DefaultInstance.Connection);
            StoredProcParamsCache.CreateParameters(cmd);
            switch (eventType)
            {
                case EventType.HumanCaseCreatedLocal:
                case EventType.HumanCaseDiagnosisChangedLocal:
                case EventType.HumanCaseClassificationChangedLocal:
                case EventType.HumanTestResultRegistrationLocal:
                case EventType.HumanTestResultAmendmentLocal:
                case EventType.ClosedHumanCaseReopenedLocal:
                    BaseDbService.SetParam(cmd, "@objectType", "humancase");
                    break;
                case EventType.OutbreakCreatedLocal:
                case EventType.NewHumanCaseAddedToOutbreakLocal:
                case EventType.NewVetCaseAddedToOutbreakLocal:
                case EventType.NewVsSessionAddedToOutbreakLocal:
                case EventType.OutbreakStatusChangedLocal:
                case EventType.OutbreakPrimaryCaseChangedLocal:
                    BaseDbService.SetParam(cmd, "@objectType", "outbreak");
                    break;
                case EventType.VetCaseCreatedLocal:
                case EventType.VetCaseDiagnosisChangedLocal:
                case EventType.VetCaseClassificationChangedLocal:
                case EventType.VetCaseFieldTestResultRegistrationLocal:
                case EventType.VetCaseTestResultRegistrationLocal:
                case EventType.VetCaseTestResultAmendmentLocal:
                case EventType.ClosedVetCaseReopenedLocal:
                    BaseDbService.SetParam(cmd, "@objectType", "vetcase");
                    break;
                case EventType.VsSessionCreatedLocal:
                case EventType.VsSessionNewDiagnosisLocal:
                case EventType.VsSessionFieldTestResultRegistrationLocal:
                case EventType.VsSessionTestResultRegistrationLocal:
                case EventType.VsSessionTestResultAmendmentLocal:
                    BaseDbService.SetParam(cmd, "@objectType", "vssession");
                    break;
                case EventType.AsCampaignCreatedLocal:
                case EventType.AsCampaignStatusChangedLocal:
                    BaseDbService.SetParam(cmd, "@objectType", "ascampain");
                    break;
                case EventType.AsSessionCreatedLocal:
                case EventType.ClosedAsSessionReopenedLocal:
                case EventType.AsSessionTestResultRegistrationLocal:
                case EventType.AsSessionTestResultAmendmentLocal:
                    BaseDbService.SetParam(cmd, "@objectType", "assession");
                    break;
                case EventType.HumanAggregateCaseCreatedLocal:
                case EventType.HumanAggregateCaseChangedLocal:
                case EventType.VetAggregateCaseCreatedLocal:
                case EventType.VetAggregateCaseChangedLocal:
                case EventType.VetAggregateActionCreatedLocal:
                case EventType.VetAggregateActionChangedLocal:
                    BaseDbService.SetParam(cmd, "@objectType", "aggrcase");
                    break;
                case EventType.NewSampleTransferInLocal:
                    BaseDbService.SetParam(cmd, "@objectType", "transferout");
                    break;
                case EventType.TestResultForSampleTransferredIn:
                    //case EventType.TestResultForSampleTransferredOut:
                    BaseDbService.SetParam(cmd, "@objectType", "test");
                    break;
                case EventType.BssFormLocal:
                    BaseDbService.SetParam(cmd, "@objectType", "bss");
                    break;
                case EventType.BssAggregateFormLocal:
                    BaseDbService.SetParam(cmd, "@objectType", "bssaggr");
                    break;
                case EventType.SettlementChanged:
                    BaseDbService.SetParam(cmd, "@objectType", "settlement");
                    break;
                case EventType.AVRLayoutPublishedLocal:
                case EventType.AVRLayoutUnpublishedLocal:
                case EventType.AVRLayoutShared:
                    BaseDbService.SetParam(cmd, "@objectType", "layout");
                    break;
                case EventType.AVRLayoutFolderPublishedLocal:
                case EventType.AVRLayoutFolderUnpublishedLocal:
                    BaseDbService.SetParam(cmd, "@objectType", "folder");
                    break;
                case EventType.AVRQueryPublishedLocal:
                case EventType.AVRQueryUnpublishedLocal:
                    BaseDbService.SetParam(cmd, "@objectType", "query");
                    break;
                case EventType.FFUNITemplateChanged:
                case EventType.FFDeterminantChanged:
                    BaseDbService.SetParam(cmd, "@objectType", "fftemplate");
                    break;
                case EventType.ReferenceTableChanged:
                case EventType.RaiseReferenceCacheChange:
                    return "SpeciesTypeDetail";
                case EventType.MatrixChanged:
                    return "Diagnosis2DiagnosisAgeGroupMasterDetail";
                case EventType.ClientUILanguageChanged:
                    return "ru";
                case EventType.ReplicationRequestedByUser:
                    return ReplicationType.ForcedReplication;
                case EventType.ReplicationFailed:
                    return null;
                default:
                    return (long)0;
            }
            ErrorMessage err = null;
            object id = BaseDbService.ExecScalar(cmd, ConnectionManager.DefaultInstance.Connection, ref err, null, true);
            if (Utils.IsEmpty(id))
                return null;
            return (long)id;
        }

        private static object CreateEventObjectID(EventType eventType)
        {
            string sql;
            switch (eventType)
            {
                case EventType.VetCaseCreatedLocal:
                    sql = "exec dbo.spTest_CreateVetCase 1";//"Select Top 1 idfCase from dbo.tlbCase Where idfsCaseType = 10012003 OR idfsCaseType = 10012004";
                    break;
                case EventType.HumanCaseCreatedLocal:
                    sql = "exec dbo.spTest_CreateHumanCase";//"Select Top 1 idfCase from dbo.tlbCase Where idfsCaseType = 10012001";
                    break;
                //case EventType.CaseDiseaseChange:
                //case EventType.CaseStatusChange:
                //case EventType.NewOutbreak:
                //case EventType.NewTestResult:
                //case EventType.SettlementChanged:
                //case EventType.AVRLayoutUpdate:
                //case EventType.ReferenceTableChanged:
                //    return (long)0;
                default:
                    return (long)0;
            }
            ErrorMessage err = null;
            object id = BaseDbService.ExecScalar(sql, ConnectionManager.DefaultInstance.Connection, ref err, null, true);
            if (Utils.IsEmpty(id))
                return null;
            return (long)id;
        }

        private static void ValidateAdminNotification(object notificationID)
        {
            DbDataAdapter da = BaseDbService.CreateAdapter(String.Format("SELECT TOP 1 * FROM {0}.dbo.tstReplicateDataNotification where idfNotification={1}", ConnectionManager.DefaultInstance.Connection.Database + "_Admin", notificationID),
                                                           ConnectionManager.DefaultInstance.Connection, false, null);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Assert.IsTrue(dt.Rows.Count == 1, "no notification record in admin base " + ConnectionManager.DefaultInstance.Connection.Database + "_Admin is created during event processing");
            Assert.AreEqual((long)notificationID, dt.Rows[0]["idfNotification"], "incorrect admin notification ident");
        }

        private static void ValidateEventProcessing(NotificationType type, object objectID, string data, object notificationID)
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

        private static void ValidateNotificationProcessing(EventType type, object objectID, string diagnisisId, string informationString, object eventID)
        {
            var da = BaseDbService.CreateAdapter("SELECT TOP 1 * FROM tstEventActive where idfEventID=" + eventID,
                                                           ConnectionManager.DefaultInstance.Connection, false, null);
            var dt = new DataTable();
            da.Fill(dt);
            Assert.IsTrue(dt.Rows.Count == 1, "no event record is created during notification processing");
            Assert.AreEqual((long)type, dt.Rows[0]["idfsEventTypeID"], "incorrect event type");
            Assert.AreEqual(objectID, dt.Rows[0]["idfObjectID"], "incorrect Object ID");
            Assert.AreEqual(diagnisisId, Utils.Str(dt.Rows[0]["idfsDiagnosis"]), "incorrect diagnosis id");
            Assert.AreEqual(informationString, Utils.Str(dt.Rows[0]["strInformationString"]), "incorrect strInformationString");

        }

        private static void ValidateNotificationReplication(DataRow row, long initNotif, long initSite)
        {
            Assert.AreEqual(initSite, row["idfNotificationObject"], "incorrect initial site");
            if (initNotif != (long)row["idfNotification"])
                Assert.AreEqual(initNotif.ToString(), row["strPayload"], "incorrect initial notification ID");
            Assert.AreEqual(EidssSiteContext.Instance.SiteID, row["idfsTargetSite"], "incorrect source site ID");
        }

        private void ValidateCreationNotification(NotificationType notificationType, long obj, long site, long targetsite, long sourcesite)
        {
            var ntf = GetLastNotificationRow();
            Assert.AreEqual((long)notificationType, ntf["idfsNotificationType"], "incorrect notification type");
            Assert.AreEqual(obj.ToString(), ntf["strPayload"], "incorrect source notification ID");
            Assert.AreEqual(site, ntf["idfsSite"], "incorrect notification site");
            Assert.AreEqual(targetsite, ntf["idfsTargetSite"], "incorrect source site");
            Assert.AreEqual(sourcesite, ntf["idfNotificationObject"], "incorrect initial site");
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
            var StartDate = DateTime.Now;
            Trace.WriteLine(Trace.Kind.Info, String.Format("Test: Start wait event"));
            while (!eventRec && StartDate.AddMinutes(EidssSiteContext.Instance.ForcedReplicationExpirationPeriod) > DateTime.Now)
            {
                Thread.Sleep(period);
            }
            if (!eventRec)
            {
                Trace.WriteLine(Trace.Kind.Info, String.Format("Test: Stop wait event"));
                Assert.Fail(message);
            }
            else
            {
                Trace.WriteLine(Trace.Kind.Info, String.Format("Test: Received waited event"));
            }
        }
        private void WaitForNotification(string message, int period)
        {
            m_NotificationReceived = false;
            var StartDate = DateTime.Now;

            while (!m_NotificationReceived && StartDate.AddMinutes(EidssSiteContext.Instance.ForcedReplicationExpirationPeriod) > DateTime.Now)
            {
                Thread.Sleep(period);
            }
            if (!m_NotificationReceived)
            {
                Assert.Fail(message);
            }
        }
        [TestMethod, Ignore]
        public void TestForcedReplicationClient()
        {
            try
            {

                ChangeSite(m_TlvlSite);
                Event_DB eventService = new Event_DB();
                eventService.IsNotificationService = false;
                eventService.SubscribeToAllEvents();
                eventService.GetClientEvents();

                var eventProcessor = new EventProcessor(m_ConfigFile);
                eventProcessor.EventOccured += OnEventOccured;
                eventProcessor.Listen();

                var rc = new ForcedReplicationClient(null, "testClient") { RoutineJobName = "Dummy" };
                rc.StartReplication();
                WaitForEvent(ref m_EventReplicationReceived, String.Format("event {0} wasn't created for object {1}.", EventType.ReplicationRequestedByUser, m_EventObjectId), 500);

                rc.GetReplicationEvents();

                m_ReplicationEventToWait = EventType.ForcedReplicationConfirmed;
                eventService.CreateEvent(m_ReplicationEventToWait, null, null, null, EidssUserContext.User.ID);
                var dr = rc.GetReplicationEvents();
                Assert.IsTrue(dr.Length == 1, "ForcedReplicationConfirmed event is not received for current user");
                Assert.AreEqual(EventType.ForcedReplicationConfirmed, (EventType)dr[0]["idfsEventTypeID"]);

                eventService.CreateEvent(m_ReplicationEventToWait, null, null, null, null);
                dr = rc.GetReplicationEvents();
                Assert.IsTrue(dr.Length == 0, "ForcedReplicationConfirmed event is received for empty user");


                m_ReplicationEventToWait = EventType.ForcedReplicationExpired;
                eventService.CreateEvent(m_ReplicationEventToWait, null, null, null, EidssUserContext.User.ID);
                dr = rc.GetReplicationEvents();
                Assert.IsTrue(dr.Length == 1, "ForcedReplicationExpired event is not received for current user");
                Assert.AreEqual(EventType.ForcedReplicationExpired, (EventType)dr[0]["idfsEventTypeID"]);


                m_ReplicationEventToWait = EventType.ForcedReplicationExpired;
                dr = rc.GetReplicationEvents();
                Assert.IsTrue(dr.Length == 0, "ForcedReplicationExpired event is received for empty user");

            }
            finally
            {
                ChangeSite(m_DefaultSiteId);
            }
        }

        private EventType m_ReplicationEventToWait;
        private void ForcedReplicationEvent(DataTable dt)
        {
            if (m_ReplicationEventToWait == EventType.None)
                return;
            var row = dt.Rows[0];
            if (row["idfsEventTypeID"].Equals((long)m_ReplicationEventToWait))
            {
                m_ReplicationEventToWait = EventType.None;
            }
        }
        private bool WaitForReplicationEvent()
        {
            int i = 3;
            while (i-- > 0)
            {
                if (m_ReplicationEventToWait == EventType.None)
                    return true;
                Thread.Sleep(700);
            }
            return false;
        }

        private void StartReplication(string DBName, string AdminDBName, string ReplicationProcessName)
        {
            const string LogReplicationStartSqlQuery = @"
declare	@DBName nvarchar(50)
set	@DBName = N'{0}'

declare	@AdminDBName nvarchar(50)
set	@AdminDBName = N'{1}'

declare	@ReplicationProcessName nvarchar(200)
set	@ReplicationProcessName = N'{2}'

declare	@idfsSite	bigint
set @idfsSite = 1

declare @admincmd nvarchar(max)

set	@admincmd = N'
IF	EXISTS (SELECT [name] FROM [' + @DBName + N'].sys.objects WHERE [name] = N''tstLocalSiteOptions'' and [type] = N''U'')
	AND EXISTS (SELECT [name] FROM [' + @DBName + N'].sys.objects WHERE [name] = N''tstSite'' and [type] = N''U'')
		select		@idfsSiteOut = s.idfsSite 
		from		[' + @DBName + N'].dbo.tstLocalSiteOptions lso
		inner join  [' + @DBName + N'].dbo.tstSite s 
		on			cast(s.idfsSite as nvarchar(200)) = lso.strValue
					and s.intRowStatus = 0
		where		lso.strName = N''SiteID'' 
'
exec sp_executesql @admincmd, N'@idfsSiteOut bigint OUTPUT', @idfsSiteOut = @idfsSite output

set @admincmd = N''

if @idfsSite is null
	set @idfsSite = 1


if exists   (
select	*
from	master.sys.databases
where	[name] = @AdminDBName
		)
begin

	set		@admincmd = IsNull(N'
declare @idfAttempt bigint 
set @idfAttempt = 0

exec [' + @AdminDBName + N'].dbo.spsysGetNewID @idfAttempt output

if IsNull(@idfAttempt, 0) > 0
begin

	if not exists	(
			select	*
			from	[' + @AdminDBName + N'].dbo.tstCurrentReplicationAttempt
			where	strSource = N''' + replace(@ReplicationProcessName, N'''', N'''''') + N'''
					)
		insert into	[' + @AdminDBName + N'].dbo.tstCurrentReplicationAttempt
		(	strSource,
			idfAttempt
		)
		values
		(	N''' + replace(@ReplicationProcessName, N'''', N'''''') + N''',
			@idfAttempt
		)
	else
		update	[' + @AdminDBName + N'].dbo.tstCurrentReplicationAttempt
		set		idfAttempt = @idfAttempt
		where	strSource = N''' + replace(@ReplicationProcessName, N'''', N'''''') + N'''
					
	insert into	[' + @AdminDBName + N'].dbo.logReplicationAttempt
	(	idfAttempt,
		idfsSite,
		strComputerName,
		strDatabaseName,
		datStart,
		strComment
	)
	values
	(		@idfAttempt,
			' + CAST(@idfsSite as nvarchar(20)) + ',
			N''' + REPLACE(HOST_NAME(), N'''', N'''''') + N''',
			N''' + REPLACE(@DBName, N'''', N'''''') + N''',
			getdate(),
			N''' + replace(@DBName, N'''', N'''''') + ' REPLICATION''
	)

	update	[' + @AdminDBName + N'].dbo.tstReplicateDataNotification
	set		intProcessingStatus = 1
end
', N'')

end
    
if LEN(LTRIM(RTRIM(IsNull(@admincmd, N'')))) > 0
	exec sp_executesql @admincmd
";

            var sql = string.Format(LogReplicationStartSqlQuery, DBName, AdminDBName, ReplicationProcessName);
            ErrorMessage err = null;
            BaseDbService.ExecScalar(sql, ConnectionManager.DefaultInstance.Connection, ref err, null, true);
        }

        private void FinishReplication(string DBName, string AdminDBName, string ReplicationProcessName)
        {
            const string LogReplicationFinishSqlQuery = @"
declare	@DBName nvarchar(50)
set	@DBName = N'{0}'

declare	@AdminDBName nvarchar(50)
set	@AdminDBName = N'{1}'

declare	@ReplicationProcessName nvarchar(200)
set	@ReplicationProcessName = N'{2}'

declare	@intReplicationResult	int
set	@intReplicationResult = 0

declare	@UpdInsDel nvarchar(1500)
declare	@msgReplicationAttempt nvarchar(500)

declare @admincmd nvarchar(max)
set	@admincmd = N''


if	exists   (
		select	*
		from	master.sys.databases
		where	[name] = @AdminDBName
		)
begin



set @admincmd = N''

	if @intReplicationResult = 0
		set @msgReplicationAttempt = N' WITH SUCCESS'
	else
		set @msgReplicationAttempt = N' WITH FAILURE'


	set		@admincmd = IsNull(N'
declare @idfAttempt bigint 
set @idfAttempt = 0

select	@idfAttempt = IsNull(idfAttempt, 0)
from	[' + @AdminDBName + N'].dbo.tstCurrentReplicationAttempt
where	strSource = N''' + replace(@ReplicationProcessName, N'''', N'''''') + N'''

if IsNull(@idfAttempt, 0) > 0
begin
	update	[' + @AdminDBName + N'].dbo.logReplicationAttempt
	set		intReplicationResult = ' + CAST(IsNull(@intReplicationResult, -1) as nvarchar(20)) + N',
			datEnd = getdate(),
			strUpdInsDel = ' + ISNULL(N'N''' + @UpdInsDel + N'''', N'null') + N',
			strComment = strComment + N''' + replace(@msgReplicationAttempt, N'''', N'''''') + N'''
	where	idfAttempt = @idfAttempt
			and strComputerName = N''' + replace(HOST_NAME(), N'''', N'''''') + N'''

	insert into	[' + @AdminDBName + N'].dbo.logNotificationToReplicationAttempt
	(	idfAttempt,
		idfsSite,
		idfNotification
	)
	select		ra.idfAttempt,
				ra.idfsSite,
				rdn.idfNotification
	from		[' + @AdminDBName + N'].dbo.tstReplicateDataNotification rdn
	inner join	[' + @AdminDBName + N'].dbo.logReplicationAttempt ra
	on			ra.idfAttempt = @idfAttempt
				and ra.strComputerName = N''' + replace(HOST_NAME(), N'''', N'''''') + N'''
				and ra.intReplicationResult = 0
	left join	[' + @AdminDBName + N'].dbo.logNotificationToReplicationAttempt n_to_ra
	on			n_to_ra.idfAttempt = @idfAttempt
				and n_to_ra.idfsSite = ra.idfsSite
				and n_to_ra.idfNotification = rdn.idfNotification
	where		rdn.intProcessingStatus = 1
				and n_to_ra.idfAttempt is null

	delete		rdn
	from		[' + @AdminDBName + N'].dbo.tstReplicateDataNotification rdn
	inner join	[' + @AdminDBName + N'].dbo.logReplicationAttempt ra
	on			ra.idfAttempt = @idfAttempt
				and ra.strComputerName = N''' + replace(HOST_NAME(), N'''', N'''''') + N'''
				and ra.intReplicationResult = 0
	inner join	[' + @AdminDBName + N'].dbo.logNotificationToReplicationAttempt n_to_ra
	on			n_to_ra.idfAttempt = @idfAttempt
				and n_to_ra.idfsSite = ra.idfsSite
				and n_to_ra.idfNotification = rdn.idfNotification

	update		[' + @AdminDBName + N'].dbo.tstReplicateDataNotification
	set			intProcessingStatus = 0
end
', N'')
end
    
if LEN(LTRIM(RTRIM(IsNull(@admincmd, N'')))) > 0
	exec sp_executesql @admincmd

if	exists   (
		select	*
		from	master.sys.databases
		where	[name] = @AdminDBName
		)
begin
	set		@admincmd = IsNull(N'
delete from	[' + @AdminDBName + N'].dbo.tstCurrentReplicationAttempt
where		strSource = N''' + replace(@ReplicationProcessName, N'''', N'''''') + N'''

update		[' + @AdminDBName + N'].dbo.tstReplicateDataNotification
set			intProcessingStatus = 0

', N'')
end
    
if LEN(LTRIM(RTRIM(IsNull(@admincmd, N'')))) > 0
	exec sp_executesql @admincmd
";


            BaseDbService.ExecSql(string.Format(LogReplicationFinishSqlQuery, DBName, AdminDBName, ReplicationProcessName), ConnectionManager.DefaultInstance.Connection);
        }
    }
}
