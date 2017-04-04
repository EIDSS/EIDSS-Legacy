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
using eidss.model.Enums;

namespace NotificationsSvc.Tests
{
    [TestClass]
    public class NotificationTests
    {
        private string m_DirToConfigFile;
        private string m_ConfigFile;
        private const string m_NameSlvlConfigFile = "EIDSS60_Ntfy.exe - slvl.config";
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
                string.Format("{0}\\EIDSS60_Ntfy.exe.config", m_DirToConfigFile);

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
            CheckEvent(EventType.HumanCaseCreatedLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_HumanCaseDiagnosisChange_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.HumanCaseDiagnosisChangedLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_HumanCaseClassificationChange_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.HumanCaseClassificationChangedLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_HumanCaseTestResultRegistration_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.HumanTestResultRegistrationLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_HumanCaseTestResultAmendment_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.HumanTestResultAmendmentLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_HumanCaseReopened_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.ClosedHumanCaseReopenedLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_NewOutbreak_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.OutbreakCreatedLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_OutbreakNewHumanCaseAddition_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.NewHumanCaseAddedToOutbreakLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_OutbreakNewVetCaseAddition_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.NewVetCaseAddedToOutbreakLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_OutbreakNewVsSessionAddition_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.NewVsSessionAddedToOutbreakLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_OutbreakStatusChange_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.OutbreakStatusChangedLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_OutbreakPrimaryCaseChange_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.OutbreakPrimaryCaseChangedLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_NewVetCase_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.VetCaseCreatedLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_VetCaseDiagnosisChange_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.VetCaseDiagnosisChangedLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_VetCaseClassificationChange_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.VetCaseClassificationChangedLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_VetCaseFieldTestResultRegistration_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.VetCaseFieldTestResultRegistrationLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_VetCaseTestResultRegistration_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.VetCaseTestResultRegistrationLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_VetCaseTestResultAmendment_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.VetCaseTestResultAmendmentLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_VetCaseReopened_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.ClosedVetCaseReopenedLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_VsSession_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.VsSessionCreatedLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_VsSessionDiagnosisDetection_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.VsSessionNewDiagnosisLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_VsSessionFieldTestResultRegistration_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.VsSessionFieldTestResultRegistrationLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_VsSessionTestResultRegistration_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.VsSessionTestResultRegistrationLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_VsSessionTestResultAmendment_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.VsSessionTestResultAmendmentLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_AsCampaign_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.AsCampaignCreatedLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_AsSession_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.AsSessionCreatedLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_AsCampaignStatusChange_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.AsCampaignStatusChangedLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_AsSessionReopened_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.ClosedAsSessionReopenedLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_AsSessionTestResultRegistration_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.AsSessionTestResultRegistrationLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_AsSessionTestResultAmendment_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.AsSessionTestResultAmendmentLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_HumanAggregateCase_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.HumanAggregateCaseCreatedLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_HumanAggregateCaseChange_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.HumanAggregateCaseChangedLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_VetAggregateCase_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.VetAggregateCaseCreatedLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_VetAggregateCaseChange_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.VetAggregateCaseChangedLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_VetAggregateAction_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.VetAggregateActionCreatedLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_VetAggregateActionChange_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.VetAggregateActionChangedLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_NewSampleTransferInLocal_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.NewSampleTransferInLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_TestResultForSampleTransferredOut_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.TestResultForSampleTransferredOut);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_BssForm_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.BssFormLocal);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_BssAggregateForm_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.BssAggregateFormLocal);
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
        public void Event_RaiseReferenceCacheChange_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.RaiseReferenceCacheChange);
            eventProcessor.EventOccured -= OnEventOccured;
            eventProcessor.Stop();
        }

        [TestMethod]
        public void Event_MatrixChange_Test()
        {
            EventProcessor eventProcessor = new EventProcessor(m_ConfigFile);
            eventProcessor.EventOccured += OnEventOccured;
            eventProcessor.Listen();
            CheckEvent(EventType.MatrixChanged);
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
            CheckEvent(EventType.AVRLayoutPublishedLocal);
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
            CheckReplication(EventType.HumanCaseCreatedLocal);
        }
        [TestMethod]
        public void Replication_NewVetCase_Test()
        {
            CheckReplication(EventType.VetCaseCreatedLocal);
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
                case EventType.HumanCaseCreatedLocal:
                    CheckNotificationEvent(NotificationType.HumanCase, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.HumanCaseDiagnosisChangedLocal:
                    CheckNotificationEvent(NotificationType.HumanCaseDiagnosisChange, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.HumanCaseClassificationChangedLocal:
                    CheckNotificationEvent(NotificationType.HumanCaseClassificationChange, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.HumanTestResultRegistrationLocal:
                    CheckNotificationEvent(NotificationType.HumanCaseTestResultRegistration, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.HumanTestResultAmendmentLocal:
                    CheckNotificationEvent(NotificationType.HumanCaseTestResultAmendment, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.ClosedHumanCaseReopenedLocal:
                    CheckNotificationEvent(NotificationType.HumanCaseReopened, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.OutbreakCreatedLocal:
                    CheckNotificationEvent(NotificationType.Outbreak, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.NewHumanCaseAddedToOutbreakLocal:
                    CheckNotificationEvent(NotificationType.OutbreakNewHumanCaseAddition, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.NewVetCaseAddedToOutbreakLocal:
                    CheckNotificationEvent(NotificationType.OutbreakNewVetCaseAddition, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.NewVsSessionAddedToOutbreakLocal:
                    CheckNotificationEvent(NotificationType.OutbreakNewVsSessionAddition, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.OutbreakStatusChangedLocal:
                    CheckNotificationEvent(NotificationType.OutbreakStatusChange, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.OutbreakPrimaryCaseChangedLocal:
                    CheckNotificationEvent(NotificationType.OutbreakPrimaryCaseChange, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.VetCaseCreatedLocal:
                    CheckNotificationEvent(NotificationType.VetCase, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.VetCaseDiagnosisChangedLocal:
                    CheckNotificationEvent(NotificationType.VetCaseDiagnosisChange, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.VetCaseClassificationChangedLocal:
                    CheckNotificationEvent(NotificationType.VetCaseClassificationChange, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.VetCaseFieldTestResultRegistrationLocal:
                    CheckNotificationEvent(NotificationType.VetCaseFieldTestResultRegistration, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.VetCaseTestResultRegistrationLocal:
                    CheckNotificationEvent(NotificationType.VetCaseTestResultRegistration, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.VetCaseTestResultAmendmentLocal:
                    CheckNotificationEvent(NotificationType.VetCaseTestResultAmendment, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.ClosedVetCaseReopenedLocal:
                    CheckNotificationEvent(NotificationType.VetCaseReopened, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.VsSessionCreatedLocal:
                    CheckNotificationEvent(NotificationType.VsSession, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.VsSessionNewDiagnosisLocal:
                    CheckNotificationEvent(NotificationType.VsSessionDiagnosisDetection, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.VsSessionFieldTestResultRegistrationLocal:
                    CheckNotificationEvent(NotificationType.VsSessionFieldTestResultRegistration, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.VsSessionTestResultRegistrationLocal:
                    CheckNotificationEvent(NotificationType.VsSessionTestResultRegistration, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.VsSessionTestResultAmendmentLocal:
                    CheckNotificationEvent(NotificationType.VsSessionTestResultAmendment, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.AsCampaignCreatedLocal:
                    CheckNotificationEvent(NotificationType.AsCampaign, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.AsSessionCreatedLocal:
                    CheckNotificationEvent(NotificationType.AsSession, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.AsCampaignStatusChangedLocal:
                    CheckNotificationEvent(NotificationType.AsCampaignStatusChange, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.ClosedAsSessionReopenedLocal:
                    CheckNotificationEvent(NotificationType.AsSessionReopened, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.AsSessionTestResultRegistrationLocal:
                    CheckNotificationEvent(NotificationType.AsSessionTestResultRegistration, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.AsSessionTestResultAmendmentLocal:
                    CheckNotificationEvent(NotificationType.AsSessionTestResultAmendment, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.HumanAggregateCaseCreatedLocal:
                    CheckNotificationEvent(NotificationType.HumanAggregateCase, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.HumanAggregateCaseChangedLocal:
                    CheckNotificationEvent(NotificationType.HumanAggregateCaseChange, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.VetAggregateCaseCreatedLocal:
                    CheckNotificationEvent(NotificationType.VetAggregateCase, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.VetAggregateCaseChangedLocal:
                    CheckNotificationEvent(NotificationType.VetAggregateCaseChange, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.VetAggregateActionCreatedLocal:
                    CheckNotificationEvent(NotificationType.VetAggregateAction, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.VetAggregateActionChangedLocal:
                    CheckNotificationEvent(NotificationType.VetAggregateActionChange, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.NewSampleTransferIn:
                    CheckNotificationEvent(NotificationType.NewSampleTransferIn, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.TestResultForSampleTransferredOut:
                    CheckNotificationEvent(NotificationType.TestResultForSampleTransferredOut, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.BssFormLocal:
                    CheckNotificationEvent(NotificationType.BssForm, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.BssAggregateFormLocal:
                    CheckNotificationEvent(NotificationType.BssAggregateForm, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.SettlementChanged:
                    CheckNotificationEvent(NotificationType.SettlementChanged, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.AVRLayoutPublishedLocal:
                    CheckNotificationEvent(NotificationType.AVRLayoutUpdate, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.AVRLayoutShared:
                    CheckNotificationEvent(NotificationType.AVRLayoutUpdate, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.AggregateSettingsChanged:
                    CheckNotificationEvent(NotificationType.AggregateSettingsChange, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.SecurityPolicyChanged:
                    CheckNotificationEvent(NotificationType.SecurityPolicyChange, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.FFUNITemplateChanged:
                    CheckNotificationEvent(NotificationType.FFTemplateChange, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.FFDeterminantChanged:
                    CheckNotificationEvent(NotificationType.FFTemplateDeterminantChange, m_EventObjectId, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.ReferenceTableChanged:
                    CheckNotificationEvent(NotificationType.ReferenceTableChanged, DBNull.Value, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.RaiseReferenceCacheChange:
                    CheckNotificationEvent(NotificationType.RaiseReferenceCacheChange, DBNull.Value, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.MatrixChanged:
                    CheckNotificationEvent(NotificationType.MatrixChange, DBNull.Value, m_EventObjectId.ToString(), notificationid);
                    break;
                case EventType.ReplicationRequestedByUser:
                    m_EventReplicationReceived = true;//for replication tests
                    break;
            }
            Dbg.Debug("After CheckNotificationEvent for event {0}.", m_EventType);

            // Check that we received event of the waited type and for waited object
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
            eventService.IsNotificationService = true;
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

            eventService.CreateEvent(eventType, m_EventObjectId, null, null, EidssUserContext.User.ID, null);
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
                case EventType.HumanCaseCreatedLocal:
                case EventType.HumanCaseDiagnosisChangedLocal:
                case EventType.HumanCaseClassificationChangedLocal:
                case EventType.HumanTestResultRegistrationLocal:
                case EventType.HumanTestResultAmendmentLocal:
                case EventType.ClosedHumanCaseReopenedLocal:
                    sql = "Select Top 1 idfHumanCase from dbo.tlbHumanCase";
                    break;
                case EventType.OutbreakCreatedLocal:
                case EventType.NewHumanCaseAddedToOutbreakLocal:
                case EventType.NewVetCaseAddedToOutbreakLocal:
                case EventType.NewVsSessionAddedToOutbreakLocal:
                case EventType.OutbreakStatusChangedLocal:
                case EventType.OutbreakPrimaryCaseChangedLocal:
                    sql = "Select Top 1 idfOutbreak from dbo.tlbOutbreak";
                    break;
                case EventType.VetCaseCreatedLocal:
                case EventType.VetCaseDiagnosisChangedLocal:
                case EventType.VetCaseClassificationChangedLocal:
                case EventType.VetCaseFieldTestResultRegistrationLocal:
                case EventType.VetCaseTestResultRegistrationLocal:
                case EventType.VetCaseTestResultAmendmentLocal:
                case EventType.ClosedVetCaseReopenedLocal:
                    sql = "Select Top 1 idfVetCase from dbo.tlbVetCase";
                    break;
                case EventType.VsSessionCreatedLocal:
                case EventType.VsSessionNewDiagnosisLocal:
                case EventType.VsSessionFieldTestResultRegistrationLocal:
                case EventType.VsSessionTestResultRegistrationLocal:
                case EventType.VsSessionTestResultAmendmentLocal:
                    sql = "Select Top 1 idfVectorSurveillanceSession from dbo.tlbVectorSurveillanceSession";
                    break;
                case EventType.AsCampaignCreatedLocal:
                case EventType.AsCampaignStatusChangedLocal:
                    sql = "Select Top 1 idfCampaign from dbo.tlbCampaign";
                    break;
                case EventType.AsSessionCreatedLocal:
                case EventType.ClosedAsSessionReopenedLocal:
                case EventType.AsSessionTestResultRegistrationLocal:
                case EventType.AsSessionTestResultAmendmentLocal:
                    sql = "Select Top 1 idfMonitoringSession from dbo.tlbMonitoringSession";
                    break;
                case EventType.HumanAggregateCaseCreatedLocal:
                case EventType.HumanAggregateCaseChangedLocal:
                case EventType.VetAggregateCaseCreatedLocal:
                case EventType.VetAggregateCaseChangedLocal:
                case EventType.VetAggregateActionCreatedLocal:
                case EventType.VetAggregateActionChangedLocal:
                    sql = "Select Top 1 idfAggrCase from dbo.tlbAggrCase";
                    break;
                case EventType.NewSampleTransferInLocal:
                    sql = "Select Top 1 idfTransferOut from dbo.tlbTransferOUT";
                    break;
                case EventType.TestResultForSampleTransferredOut:
                    sql = "Select Top 1 idfTesting from dbo.tlbTesting";
                    break;
                case EventType.BssFormLocal:
                    sql = "Select Top 1 idfBasicSyndromicSurveillance from dbo.tlbBasicSyndromicSurveillance";
                    break;
                case EventType.BssAggregateFormLocal:
                    sql = "Select Top 1 idfAggregateHeader from dbo.tlbBasicSyndromicSurveillanceAggregateHeader";
                    break;
                case EventType.SettlementChanged:
                    sql = "Select Top 1 idfsGISBaseReference from dbo.gisBaseReference";
                    break;
                case EventType.AVRLayoutPublishedLocal:
                    sql = "Select Top 1 idfsLayout from dbo.tasglLayout";
                    break;
                case EventType.ReferenceTableChanged:
                case EventType.RaiseReferenceCacheChange:
                    return "SpeciesTypeDetail";
                case EventType.MatrixChanged:
                    return "Diagnosis2DiagnosisAgeGroupMasterDetail";
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
            int i = 40;
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
