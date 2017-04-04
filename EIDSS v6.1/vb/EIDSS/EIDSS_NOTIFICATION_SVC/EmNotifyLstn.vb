Imports bv.common
Imports bv.common.db
Imports bv.common.db.Core
Imports bv.common.Core
Imports bv.common.Configuration
Imports System.Timers
Imports EIDSS.model.Core
Imports EIDSS.model.Enums
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Threading

Public Class EmNotifyLstn
    Protected m_ServiceConfig As ServiceConfiguration
    Protected m_DbService As EmNotify_DB
    Protected m_WaitingRequestsQueue As New Hashtable
    Public Event NotificationReceived As ServiceBase.DataRowEvent
    Protected m_EidssEventLog As EidssEventLog
    Private ReadOnly m_ConfigFileName As String
    Private ReadOnly m_SiteType As SiteType
    Private ReadOnly m_Credentials As ConnectionCredentials
    Private m_NotificationListenTmr As Timers.Timer
    Private ReadOnly m_ForcedReplicationThreads As New List(Of Thread)
    Private ReadOnly m_AdminConnectionManager As ConnectionManager

    Public ReadOnly Property Connection() As IDbConnection
        Get
            If Not m_DbService Is Nothing Then
                Return m_DbService.Connection
            End If
            Return Nothing
        End Get
    End Property

    Public Sub New(Optional ByVal configFile As String = Nothing)
        m_Credentials = New ConnectionCredentials(configFile)
        m_ConfigFileName = configFile
        m_ServiceConfig = New ServiceConfiguration(configFile)
        m_ServiceConfig.ReadConfiguration()
        m_DbService = New EmNotify_DB(m_Credentials, m_ServiceConfig.ClientID)
        m_EidssEventLog = New EidssEventLog(m_Credentials, m_ServiceConfig.ClientID)
        Dim siteService As Object = ClassLoader.LoadClass("EIDSS_SiteService")
        siteService.GetType.GetProperty("SiteConnection").SetValue(siteService, m_DbService.Connection, Nothing)
        m_SiteType = CType(siteService.GetType.GetMethod("GetRealSiteTypeEnum").Invoke(siteService, Nothing), SiteType)
        m_AdminConnectionManager = ConnectionManager.Create(m_Credentials.SQLServer, String.Format("{0}_Admin", m_Credentials.SQLDatabase), m_Credentials.SQLUser, m_Credentials.SQLPassword, m_Credentials.SQLConnectionString)
    End Sub
    Private m_Listening As Boolean
    Private ReadOnly m_ListeningLock As New Object
    Public Sub Listen()
        If m_NotificationListenTmr Is Nothing Then
            m_NotificationListenTmr = New Timers.Timer
        End If
        m_NotificationListenTmr.AutoReset = False
        AddHandler m_NotificationListenTmr.Elapsed, AddressOf WorkerProc
        m_NotificationListenTmr.Interval = m_ServiceConfig.PollRate
        m_NotificationListenTmr.Start()
        SyncLock m_ListeningLock
            m_Listening = True
        End SyncLock
        Trace.WriteLine(Trace.Kind.Info, "Ntfy_Start: Notify listener is started on database {0}.", m_Credentials.SQLDatabase)
    End Sub

    Public Sub [Stop]()
        If Not m_NotificationListenTmr Is Nothing Then m_NotificationListenTmr.Stop()
        SyncLock m_ListeningLock
            m_Listening = False
        End SyncLock
        Dim i As Integer = 100
        While i > 0
            SyncLock m_ForcedReplicationThreads
                If m_ForcedReplicationThreads.Count = 0 Then
                    Exit While
                End If
            End SyncLock
            Thread.Sleep(200)
            i -= 1
        End While
        Trace.WriteLine(Trace.Kind.Info, "Ntfy_Start: Notify listener is stopped on database {0}.", m_Credentials.SQLDatabase)
    End Sub
    Private Sub WorkerProc(ByVal sender As Object, ByVal e As ElapsedEventArgs)
        CType(sender, Timers.Timer).Stop()
        Try
            If m_DbService.GetNotificationsCount() > 0 Then
                ProcessNotification()
            End If
        Catch ex As Exception
            Trace.WriteLine(Trace.Kind.Error, "Ntfy_Listener.WorkerProc", ex)
        Finally
            CType(sender, Timers.Timer).Interval = m_ServiceConfig.PollRate
            CType(sender, Timers.Timer).Start()
        End Try

    End Sub

    Protected Overridable Sub ProcessNotification()
        Dim ds As DataSet = m_DbService.GetNotifications()
        If ds Is Nothing OrElse ds.Tables("Notification") Is Nothing Then
            Return
        End If
        Dim row As DataRow

        Dim postResult As Boolean
        Dim shouldTransitNotification As Boolean = False
        TraceMe("Ntfy_ProcessNotification:" & ds.Tables("Notification").Rows.Count & " notification received on database " & m_Credentials.SQLDatabase)
        For Each row In ds.Tables("Notification").Rows
            If ShouldProcess(row) Then
                postResult = False
                Dim ntfyType As NotificationType = CType(row("idfsNotificationType"), NotificationType)
                TraceMe("Ntfy_ProcessNotification: Data to post is received id={0}, notification type={1}", Utils.Str(row("idfNotification")), ntfyType.ToString())
                Select Case ntfyType
                    Case NotificationType.HumanCase, _
                         NotificationType.HumanCaseDiagnosisChange, _
                         NotificationType.HumanCaseClassificationChange, _
                         NotificationType.HumanCaseTestResultRegistration, _
                         NotificationType.HumanCaseTestResultAmendment, _
                         NotificationType.HumanCaseReopened, _
                         NotificationType.Outbreak, _
                         NotificationType.OutbreakNewHumanCaseAddition, _
                         NotificationType.OutbreakNewVetCaseAddition, _
                         NotificationType.OutbreakNewVsSessionAddition, _
                         NotificationType.OutbreakStatusChange, _
                         NotificationType.OutbreakPrimaryCaseChange, _
                         NotificationType.VetCase, _
                         NotificationType.VetCaseDiagnosisChange, _
                         NotificationType.VetCaseClassificationChange, _
                         NotificationType.VetCaseFieldTestResultRegistration, _
                         NotificationType.VetCaseTestResultRegistration, _
                         NotificationType.VetCaseTestResultAmendment, _
                         NotificationType.VetCaseReopened, _
                         NotificationType.VsSession, _
                         NotificationType.VsSessionDiagnosisDetection, _
                         NotificationType.VsSessionFieldTestResultRegistration, _
                         NotificationType.VsSessionTestResultRegistration, _
                         NotificationType.VsSessionTestResultAmendment, _
                         NotificationType.AsCampaign, _
                         NotificationType.AsSession, _
                         NotificationType.AsCampaignStatusChange, _
                         NotificationType.AsSessionReopened, _
                         NotificationType.AsSessionTestResultRegistration, _
                         NotificationType.AsSessionTestResultAmendment, _
                         NotificationType.HumanAggregateCase, _
                         NotificationType.HumanAggregateCaseChange, _
                         NotificationType.VetAggregateCase, _
                         NotificationType.VetAggregateCaseChange, _
                         NotificationType.VetAggregateActionChange, _
                         NotificationType.VetAggregateAction, _
                         NotificationType.SettlementChanged, _
                         NotificationType.AVRLayoutPublish, _
                         NotificationType.AVRLayoutUnpublished, _
                         NotificationType.AVRLayoutFolderPublished, _
                         NotificationType.AVRLayoutFolderUnpublished, _
                         NotificationType.AVRQueryPublished, _
                         NotificationType.AVRQueryUnpublished, _
                         NotificationType.FFTemplateChange, _
                         NotificationType.FFTemplateDeterminantChange, _
                         NotificationType.NewSampleTransferIn, _
                         NotificationType.TestResultForSampleTransferredOut, _
                         NotificationType.BssForm, _
                         NotificationType.BssAggregateForm
                        postResult = Not row.IsNull("idfNotificationObject")
                    Case NotificationType.ReferenceTableChanged, _
                         NotificationType.RaiseReferenceCacheChange, _
                         NotificationType.AggregateSettingsChange, _
                         NotificationType.SecurityPolicyChange, _
                         NotificationType.MatrixChange
                        postResult = Not row.IsNull("strPayload")
                    Case NotificationType.StartForcedReplication, _
                         NotificationType.ForcedReplicationConfirmed
                        postResult = Not row.IsNull("idfNotificationObject")

                End Select
                If postResult Then
                    CreateReceiveEvent(row)
                Else
                    TraceMe("Ntfy_ProcessNotification:No data to post. Notification type is {0}.", ntfyType.ToString)
                End If
            End If
            If ShouldTransit(row) Then
                shouldTransitNotification = True
            End If
        Next
        If shouldTransitNotification Then
            'Dim controller As New ReplicationController(m_Credentials, m_ConfigFileName)
            ReplicationController.StartCompleteReplication(True)
        End If

    End Sub

    Protected Function ShouldTransit(ByVal notificationRow As DataRow) As Boolean
        If (notificationRow("idfsNotificationType") Is DBNull.Value) _
            OrElse m_SiteType <> SiteType.EMS OrElse Not True.Equals(notificationRow("blnChildNotification")) Then 'transit only notifications that come from child 3rd level site
            Return False
        End If
        Dim nfType As NotificationType = CType(notificationRow("idfsNotificationType"), NotificationType)
        Select Case nfType
            Case NotificationType.HumanCase, _
                NotificationType.HumanCaseClassificationChange, _
                NotificationType.HumanCaseDiagnosisChange, _
                NotificationType.HumanCaseReopened, _
                NotificationType.HumanCaseTestResultAmendment, _
                NotificationType.HumanCaseTestResultRegistration, _
                NotificationType.Outbreak, _
                NotificationType.OutbreakNewHumanCaseAddition, _
                NotificationType.OutbreakNewVetCaseAddition, _
                NotificationType.OutbreakNewVsSessionAddition, _
                NotificationType.OutbreakPrimaryCaseChange, _
                NotificationType.OutbreakStatusChange, _
                NotificationType.VetCase, _
                NotificationType.VetCaseClassificationChange, _
                NotificationType.VetCaseDiagnosisChange, _
                NotificationType.VetCaseFieldTestResultRegistration, _
                NotificationType.VetCaseReopened, _
                NotificationType.VetCaseTestResultAmendment, _
                NotificationType.VetCaseTestResultRegistration
                Return True
            Case Else
                Return False
        End Select
    End Function

    Protected Function ShouldProcess(ByVal notificationRow As DataRow) As Boolean

        If m_DbService.SiteID.Equals(notificationRow("idfsSite")) OrElse notificationRow("intProcessed").Equals(1) Then
            Return False
        End If
        Return True
    End Function

    Private Shared ReadOnly m_Notification2RemoteEvent As New Dictionary(Of NotificationType, EventType)
    Public Shared ReadOnly Property Notification2RemoteEvent As Dictionary(Of NotificationType, EventType)
        Get
            SyncLock m_Notification2RemoteEvent
                If m_Notification2RemoteEvent.Count = 0 Then
                    m_Notification2RemoteEvent.Add(NotificationType.HumanCase, EventType.HumanCaseCreatedRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.HumanCaseDiagnosisChange, EventType.HumanCaseDiagnosisChangedRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.HumanCaseClassificationChange, EventType.HumanCaseClassificationChangedRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.HumanCaseTestResultRegistration, EventType.HumanTestResultRegistrationRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.HumanCaseTestResultAmendment, EventType.HumanTestResultAmendmentRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.HumanCaseReopened, EventType.ClosedHumanCaseReopenedRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.Outbreak, EventType.OutbreakCreatedRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.OutbreakNewHumanCaseAddition, EventType.NewHumanCaseAddedToOutbreakRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.OutbreakNewVetCaseAddition, EventType.NewVetCaseAddedToOutbreakRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.OutbreakNewVsSessionAddition, EventType.NewVsSessionAddedToOutbreakRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.OutbreakStatusChange, EventType.OutbreakStatusChangedRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.OutbreakPrimaryCaseChange, EventType.OutbreakPrimaryCaseChangedRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.VetCase, EventType.VetCaseCreatedRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.VetCaseDiagnosisChange, EventType.VetCaseDiagnosisChangedRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.VetCaseClassificationChange, EventType.VetCaseClassificationChangedRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.VetCaseFieldTestResultRegistration, EventType.VetCaseFieldTestResultRegistrationRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.VetCaseTestResultRegistration, EventType.VetCaseTestResultRegistrationRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.VetCaseTestResultAmendment, EventType.VetCaseTestResultAmendmentRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.VetCaseReopened, EventType.ClosedVetCaseReopenedRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.VsSession, EventType.VsSessionCreatedRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.VsSessionDiagnosisDetection, EventType.VsSessionNewDiagnosisRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.VsSessionFieldTestResultRegistration, EventType.VsSessionFieldTestResultRegistrationRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.VsSessionTestResultRegistration, EventType.VsSessionTestResultRegistrationRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.VsSessionTestResultAmendment, EventType.VsSessionTestResultAmendmentRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.AsCampaign, EventType.AsCampaignCreatedRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.AsSession, EventType.AsSessionCreatedRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.AsCampaignStatusChange, EventType.AsCampaignStatusChangedRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.AsSessionReopened, EventType.ClosedAsSessionReopenedRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.AsSessionTestResultRegistration, EventType.AsSessionTestResultRegistrationRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.AsSessionTestResultAmendment, EventType.AsSessionTestResultAmendmentRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.HumanAggregateCase, EventType.HumanAggregateCaseCreatedRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.HumanAggregateCaseChange, EventType.HumanAggregateCaseChangedRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.VetAggregateCase, EventType.VetAggregateCaseCreatedRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.VetAggregateCaseChange, EventType.VetAggregateCaseChangedRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.VetAggregateAction, EventType.VetAggregateActionCreatedRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.VetAggregateActionChange, EventType.VetAggregateActionChangedRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.BssForm, EventType.BssFormRemote)
                    m_Notification2RemoteEvent.Add(NotificationType.BssAggregateForm, EventType.BssAggregateFormRemote)
                End If
                Return m_Notification2RemoteEvent
            End SyncLock
        End Get
    End Property

    Protected Overridable Sub CreateReceiveEvent(ByVal notificationRow As DataRow)
        Dim objectID As Long = 0
        Dim sourceSiteID As Object = notificationRow("idfsSite")
        Dim loginSiteID As Object = Utils.ToLong(notificationRow("strMaintenanceFlag"))
        If 0L.Equals(loginSiteID) Then
            loginSiteID = sourceSiteID
        End If
        Dim eventID As Object = Nothing
        Dim ntfyType As NotificationType = CType(notificationRow("idfsNotificationType"), NotificationType)
        If (notificationRow("idfsTargetSiteType") Is DBNull.Value AndAlso notificationRow("idfsTargetSite") Is DBNull.Value) OrElse _
            (Not notificationRow("idfsTargetSiteType") Is DBNull.Value AndAlso notificationRow("idfsTargetSiteType").Equals(CLng(m_SiteType))) OrElse _
            (Not notificationRow("idfsTargetSite") Is DBNull.Value AndAlso m_DbService.SiteID.Equals(notificationRow("idfsTargetSite"))) _
            Then
            If Not notificationRow.IsNull("idfNotificationObject") Then
                objectID = CLng(notificationRow("idfNotificationObject"))
            End If

            If (Notification2RemoteEvent.ContainsKey(ntfyType)) Then
                If objectID > 0 Then
                    Dim diagnosisId As Long = 0L
                    Long.TryParse(Utils.Str(notificationRow("strPayload")), diagnosisId)
                    eventID = m_EidssEventLog.CreateEvent(Notification2RemoteEvent(ntfyType), objectID, diagnosisId, loginSiteID)
                End If
                RaiseEvent NotificationReceived(m_Credentials.SQLServer, notificationRow, eventID)
            Else
                Select Case ntfyType
                    Case NotificationType.SettlementChanged
                        If ProcessSettlement(objectID) Then
                            eventID = 1
                        End If
                        RaiseEvent NotificationReceived(m_Credentials.SQLServer, notificationRow, Nothing)
                    Case NotificationType.AVRLayoutPublish, _
                             NotificationType.AVRLayoutUnpublished, _
                             NotificationType.AVRLayoutFolderPublished, _
                             NotificationType.AVRLayoutFolderUnpublished, _
                             NotificationType.AVRQueryPublished, _
                             NotificationType.AVRQueryUnpublished
                        If Not ProcessAvrNotification(ntfyType, objectID, loginSiteID, eventID) Then
                            Exit Sub
                        End If
                        RaiseEvent NotificationReceived(m_Credentials.SQLServer, notificationRow, eventID)
                    Case NotificationType.AggregateSettingsChange
                        eventID = m_EidssEventLog.CreateProcessedEvent(EventType.AggregateSettingsChanged, Nothing, 1, Nothing, loginSiteID)
                        RaiseEvent NotificationReceived(m_Credentials.SQLServer, notificationRow, eventID)
                    Case NotificationType.SecurityPolicyChange
                        eventID = m_EidssEventLog.CreateProcessedEvent(EventType.SecurityPolicyChanged, Nothing, 1, Nothing, loginSiteID)
                        RaiseEvent NotificationReceived(m_Credentials.SQLServer, notificationRow, eventID)
                    Case NotificationType.FFTemplateChange
                        If objectID > 0 Then
                            eventID = m_EidssEventLog.CreateProcessedEvent(EventType.FFUNITemplateChanged, objectID, 1, Nothing, loginSiteID)
                        End If
                        RaiseEvent NotificationReceived(m_Credentials.SQLServer, notificationRow, eventID)
                    Case NotificationType.FFTemplateDeterminantChange
                        If objectID > 0 Then
                            eventID = m_EidssEventLog.CreateProcessedEvent(EventType.FFDeterminantChanged, objectID, 1, Nothing, loginSiteID)
                        End If
                        RaiseEvent NotificationReceived(m_Credentials.SQLServer, notificationRow, eventID)
                    Case NotificationType.NewSampleTransferIn
                        If objectID > 0 Then
                            eventID = m_EidssEventLog.CreateProcessedEvent(EventType.NewSampleTransferIn, objectID, 1, Nothing, loginSiteID)
                        End If
                        RaiseEvent NotificationReceived(m_Credentials.SQLServer, notificationRow, eventID)
                    Case NotificationType.TestResultForSampleTransferredOut
                        If objectID > 0 Then
                            eventID = m_EidssEventLog.CreateProcessedEvent(EventType.TestResultForSampleTransferredOut, objectID, 1, Nothing)
                        End If
                        RaiseEvent NotificationReceived(m_Credentials.SQLServer, notificationRow, eventID)
                    Case NotificationType.ReferenceTableChanged
                        Dim lookupTable As String = Utils.Str(notificationRow("strPayLoad"))
                        If lookupTable <> "" Then
                            eventID = m_EidssEventLog.CreateProcessedEvent(EventType.ReferenceTableChanged, lookupTable, 1, Nothing, loginSiteID)
                        End If
                        RaiseEvent NotificationReceived(m_Credentials.SQLServer, notificationRow, eventID)
                    Case NotificationType.RaiseReferenceCacheChange
                        Dim lookupTable As String = Utils.Str(notificationRow("strPayLoad"))
                        If lookupTable <> "" Then
                            eventID = m_EidssEventLog.CreateProcessedEvent(EventType.RaiseReferenceCacheChange, lookupTable, 1, Nothing, loginSiteID)
                        End If
                        RaiseEvent NotificationReceived(m_Credentials.SQLServer, notificationRow, eventID)
                    Case NotificationType.MatrixChange
                        Dim nameEditorForm As String = Utils.Str(notificationRow("strPayLoad"))
                        If nameEditorForm <> "" Then
                            eventID = m_EidssEventLog.CreateProcessedEvent(EventType.MatrixChanged, nameEditorForm, 1, Nothing, loginSiteID)
                        End If
                        RaiseEvent NotificationReceived(m_Credentials.SQLServer, notificationRow, eventID)
                    Case NotificationType.StartForcedReplication
                        Dim thrd As New Thread(AddressOf ProcessForcedReplicationNotification)
                        SyncLock (m_ForcedReplicationThreads)
                            m_ForcedReplicationThreads.Add(thrd)
                        End SyncLock
                        thrd.Start(notificationRow)
                        eventID = 1
                        RaiseEvent NotificationReceived(m_Credentials.SQLServer, notificationRow, Nothing)
                    Case NotificationType.ForcedReplicationConfirmed
                        'ObjectId contains site Id that initiated forced replication
                        Dim targetSiteId As Long = Utils.ToLong(notificationRow("idfsTargetSite"))
                        Dim targetUserId As Long = Utils.ToLong(notificationRow("idfTargetUserID"))
                        Dim sourceNotificationId As Long = Utils.ToLong(notificationRow("strPayLoad"))
                        ReplicationController.ConfirmForcedReplication(sourceNotificationId, objectID = targetSiteId, targetUserId)
                        If (objectID <> targetSiteId) Then 'forced replication was sent from tlvl level, sent confirmation notification there
                            m_DbService.CreateNotification(NotificationType.ForcedReplicationConfirmed, objectID, 0, sourceNotificationId.ToString, m_DbService.SiteID, m_DbService.SiteID, objectID)
                        End If
                        eventID = 1
                        RaiseEvent NotificationReceived(m_Credentials.SQLServer, notificationRow, Nothing)
                    Case Else
                        eventID = 1
                        RaiseEvent NotificationReceived(m_Credentials.SQLServer, notificationRow, Nothing)
                End Select
            End If
            TraceMe("Ntfy_CreateReceiveEvent: Notification Event of type {0} for object {1} for notification {2} is created", ntfyType.ToString, Utils.Str(objectID), CStr(notificationRow("idfNotification")))
        Else
            eventID = 1 'mark all events sent to other sites as processed
        End If
        If (Not Utils.IsEmpty(eventID)) Then
            m_DbService.MarkProcessed(CType(notificationRow("idfNotification"), Long))
        End If
    End Sub
    Private Function WaitForReplicationEnd(notificationId As Long) As Boolean
        Dim startTime As DateTime = DateTime.Now
        Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spIsReplicationForNotificationFinished", m_AdminConnectionManager.Connection)
        BaseDbService.AddParam(cmd, "@idfNotification", notificationId)
        BaseDbService.AddParam(cmd, "@Result", 0, ParameterDirection.Output)
        Dim res As Integer = 0
        While res = 0 AndAlso startTime.AddMinutes(EidssSiteContext.Instance.ForcedReplicationExpirationPeriod) > DateTime.Now
            SyncLock m_ListeningLock
                If (m_Listening = False) Then
                    Return False
                End If
            End SyncLock
            BaseDbService.ExecCommand(cmd, cmd.Connection)
            res = CInt(BaseDbService.GetParamValue(cmd, "@Result"))
            If (res = 0) Then
                Thread.Sleep(5000)
            End If
        End While
        If (res = 0) Then
            ReplicationController.ExpireForcedReplication(notificationId, False)
        End If
        Return res = 1
    End Function

    'Async method for replication notification processing
    Private Sub ProcessForcedReplicationNotification(ByVal data As Object)
        'NotificationType.StartForcedReplication is created by user replication request or by this method
        'in the first case strPayLoad is empty and sourceNotificationId is taken from idfNotification field
        'if notification is created on slvl by this method, strPayLoad must contain the id of initial notification
        'idfNotificationObject always contains the idfsSite of site where replication was requested by user
        'Notification is always sent to parent site and must be processed on it only
        Try

            Dim notificationRow As DataRow = CType(data, DataRow)
            Dim sourceNotificationId As Long = Utils.ToLong(notificationRow("strPayLoad"))
            If sourceNotificationId = 0 Then
                sourceNotificationId = Utils.ToLong(notificationRow("idfNotification"))
            End If
            'In all cases we should wait until replication related with notification will be finished
            If Not WaitForReplicationEnd(sourceNotificationId) Then
                Return
            End If

            Dim sourceSiteID As Long = Utils.ToLong(notificationRow("idfNotificationObject"))
            Dim userID As Long = Utils.ToLong(notificationRow("idfUserID"))
            Dim targetUserID As Long = Utils.ToLong(notificationRow("idfTargetUserID"))
            If (targetUserID = 0) Then
                targetUserID = userID
            End If

            TraceMe("Ntfy_ProcessForcedReplicationNotification: id=" & sourceNotificationId & ", sourceSiteID=" & sourceSiteID & ", targetSiteID=" & Utils.ToLong(notificationRow("idfsTargetSite")))

            If m_SiteType = SiteType.CDR Then 'On CDR level we should wait until 
                Dim filtrationJobName As String = String.Format("cfrd{0}", m_Credentials.SQLDatabase)
                While JobAccessor.Instance.IsJobRuning(filtrationJobName)
                    Thread.Sleep(5000)
                    SyncLock m_ListeningLock
                        If (m_Listening = False) Then
                            Return
                        End If
                    End SyncLock

                End While
                If (JobAccessor.Instance.RunFiltrationJob(filtrationJobName, ReplicationController.Instance) = 0) Then
                    m_DbService.CreateNotification(NotificationType.ForcedReplicationConfirmed, sourceSiteID, 0, sourceNotificationId.ToString, m_DbService.SiteID, m_DbService.SiteID, notificationRow("idfsSite"), , targetUserID)
                Else
                    TraceMe("Ntfy_ProcessForcedReplicationNotification: Filtration job ended with error")
                End If
            Else 'on the SLVL level we should transit notification to CDR
                Dim targetSiteID As Object = EmNotify_DB.GetParentSite(CLng(m_DbService.SiteID))
                Dim id As Object = Nothing
                If (Utils.IsEmpty(targetSiteID)) Then
                    TraceMe("{0} site {1} have no parent site", m_SiteType.ToString(), sourceSiteID.ToString())
                Else
                    id = m_DbService.CreateNotification(NotificationType.StartForcedReplication, CLng(sourceSiteID), 0, sourceNotificationId.ToString(), m_DbService.SiteID, m_DbService.SiteID, targetSiteID, , userID)
                End If
                If Not id Is Nothing Then
                    ReplicationController.StartForcedReplication(CLng(id), sourceNotificationId, False, userID)
                End If

            End If
        Finally
            SyncLock (m_ForcedReplicationThreads)
                If (m_ForcedReplicationThreads.Contains(Thread.CurrentThread)) Then
                    m_ForcedReplicationThreads.Remove(Thread.CurrentThread)
                End If
            End SyncLock
        End Try
    End Sub


    Private Function ProcessSettlement(ByVal settlementID As Long) As Boolean
        Dim cmd As IDbCommand = m_DbService.CreateSPCommand("spGisSetWKBSettlement")
        BaseDbService.SetParam(cmd, "@idfsGeoObject", settlementID)
        Dim transaction As IDbTransaction
        SyncLock Connection
            If Connection.State <> ConnectionState.Open Then
                Connection.Open()
            End If
            transaction = Connection.BeginTransaction
            Try
                cmd.Transaction = transaction
                cmd.ExecuteNonQuery()
                transaction.Commit()
                transaction = Nothing
                Return True
            Catch ex As Exception
                TraceMe("ProcessSettlement: error during settlement updating, settlement id = {0}, error : {1}", settlementID.ToString, ex.ToString)
                Return False
            Finally
                If Not transaction Is Nothing Then
                    If Not transaction.Connection Is Nothing Then
                        transaction.Rollback()
                    End If
                    If cmd.Connection.State = ConnectionState.Open Then
                        cmd.Connection.Close()
                    End If
                End If
            End Try
        End SyncLock
    End Function

    Private Function ProcessAvrNotification(ByVal ntfyType As NotificationType, ByVal objectID As Long, ByVal sourceSiteID As Object, ByRef eventId As Object) As Boolean
        Dim procName As String = Nothing
        Dim receiveEvent As EventType = EventType.None
        Select Case ntfyType
            Case NotificationType.AVRLayoutPublish
                procName = "spAsLayoutCopyPublished"
                receiveEvent = EventType.AVRLayoutPublishedRemote
            Case NotificationType.AVRLayoutUnpublished
                procName = "spAsLayoutRemovePublishing"
                receiveEvent = EventType.AVRLayoutUnpublishedRemote
            Case NotificationType.AVRLayoutFolderPublished
                procName = "spAsFolderCopyPublished"
                receiveEvent = EventType.AVRLayoutFolderPublishedRemote
            Case NotificationType.AVRLayoutFolderUnpublished
                procName = "spAsFolderRemovePublishing"
                receiveEvent = EventType.AVRLayoutFolderUnpublishedRemote
            Case NotificationType.AVRQueryPublished
                procName = "spAsQueryCopyPublished"
                receiveEvent = EventType.AVRQueryPublishedRemote
            Case NotificationType.AVRQueryUnpublished
                procName = "spAsQueryRemovePublishing"
                receiveEvent = EventType.AVRQueryUnpublishedRemote
        End Select

        Dim cmd As IDbCommand = m_DbService.CreateSPCommand(procName)
        StoredProcParamsCache.CreateParameters(cmd)
        CType(cmd.Parameters(0), SqlParameter).Value = objectID
        Dim localObjectId As Object = DBNull.Value
        If (cmd.Parameters.Count > 1) Then
            CType(cmd.Parameters(1), SqlParameter).Value = localObjectId
        End If
        Dim transaction As IDbTransaction = Nothing

        SyncLock Connection
            If Connection.State <> ConnectionState.Open Then
                Connection.Open()
            End If
            Try
                transaction = Connection.BeginTransaction()
                cmd.Transaction = transaction
                cmd.ExecuteNonQuery()
                Dim result As Integer = CInt(BaseDbService.GetParamValue(cmd, "@RETURN_VALUE"))
                If result = 0 Then
                    If (cmd.Parameters.Count > 1) Then
                        localObjectId = CType(cmd.Parameters(1), SqlParameter).Value
                    End If
                    If receiveEvent <> EventType.None AndAlso Not localObjectId Is DBNull.Value Then
                        eventId = m_EidssEventLog.CreateProcessedEvent(receiveEvent, localObjectId, 1, DBNull.Value, sourceSiteID, , transaction)
                    End If
                    transaction.Commit()
                    transaction = Nothing
                    Return True
                End If
            Catch ex As Exception
                TraceMe("ProcessAvrNotification: error during AVR publishing, operation type = {0}, object id = {1}, error : {2}", ntfyType.ToString(), objectID.ToString, ex.ToString)
                Return False
            Finally
                If Not transaction Is Nothing Then
                    If Not transaction.Connection Is Nothing Then
                        transaction.Rollback()
                    End If
                End If
                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
            End Try
        End SyncLock

    End Function

    Private ReadOnly Property Server() As String
        Get
            If Not m_DbService.Connection Is Nothing Then
                Return CType(m_DbService.Connection, SqlConnection).DataSource
            Else
                Return ""
            End If
        End Get
    End Property
    Private Sub TraceMe(ByVal message As String, ByVal ParamArray params() As String)
        Trace.WriteLine(Trace.Kind.Info, String.Format("Server " & Server & "-" & message, params))
    End Sub
End Class
