Imports bv.common
Imports bv.common.Configuration
Imports bv.common.Core
Imports EIDSS.model.Core
Imports eidss.model.Enums
Imports System.Collections.Generic
'for tests only
Public Class IdEventArgs
    Inherits EventArgs
    Public Id As Long
    Public Sub New(ByVal id As Long)
        Me.Id = id
    End Sub
End Class
Public Delegate Sub NotificationForReplicationCreatedHandler(ByVal sender As Object, ByVal e As IdEventArgs)

Public Class EventProcessor

    Protected m_MaxEventNumber As Integer = 0
    Protected m_EidssEventLog As EidssEventLog
    Public Event EventOccured As ServiceBase.DataRowEvent
    Private ReadOnly m_NotificationManager As NotificationManager
    Private ReadOnly m_Credentials As ConnectionCredentials
    Private ReadOnly m_ConfigFile As String
    Protected m_ServiceConfig As ServiceConfiguration
    'for tests only
    Public Event NotificationForReplicationCreated As NotificationForReplicationCreatedHandler
    Public ReadOnly Property RoutineJobName() As String
        Get
            If Not m_ServiceConfig Is Nothing Then
                Return m_ServiceConfig.RoutineJobName
            End If
            Return Nothing
        End Get
    End Property
    Public ReadOnly Property Database() As String
        Get
            If Not m_EidssEventLog Is Nothing Then
                Return m_EidssEventLog.Connection.Database
            End If
            Return Nothing
        End Get
    End Property

    'Public ReadOnly Property Connection() As IDbConnection
    '    Get
    '        If Not m_DBService Is Nothing Then
    '           Return m_DBService.Connection
    '        End If
    '        Return Nothing
    '    End Get
    'End Property
    Public Sub New(Optional ByVal configFile As String = Nothing)
        m_Credentials = New ConnectionCredentials(configFile)
        m_ConfigFile = configFile
        m_ServiceConfig = New ServiceConfiguration(configFile)
        m_ServiceConfig.ReadConfiguration()

        'm_DBService = New EmNotify_DB(m_credentials, m_ServiceConfig.ClientID)
        m_EidssEventLog = New EidssEventLog(m_Credentials, m_ServiceConfig.ClientID)
        m_EidssEventLog.IsNotificationService = True
        m_NotificationManager = New NotificationManager(m_Credentials, m_ServiceConfig)
        If m_NotificationManager Is Nothing OrElse Not m_NotificationManager.IsValid Then
            Throw New Exception("Notification manager is not initialized correctly")
        End If
    End Sub
    Public Sub Listen()
        AddHandler m_EidssEventLog.EventOccured, AddressOf WorkerProc
        m_EidssEventLog.Listen()
        Trace.WriteLine(Trace.Kind.Info, "Ntfy_Start: Event log listener is started on database {0}.", m_Credentials.SQLDatabase)
    End Sub
    Public Sub [Stop]()
        m_EidssEventLog.Stop()
        RemoveHandler m_EidssEventLog.EventOccured, AddressOf WorkerProc
        Trace.WriteLine(Trace.Kind.Info, "Ntfy_Start: Event log listener is stopped on database {0}.", m_Credentials.SQLDatabase)
    End Sub
    Public Sub SkipExistingEvents()
        m_EidssEventLog.GetEvents()
    End Sub
    Public Sub WorkerProc(ByVal dt As DataTable)
        If Not m_NotificationManager.IsValid Then
            Return
        End If
        Dim dataView As New DataView(dt)
        dataView.RowFilter = "intProcessed<>1"
        For i As Integer = dataView.Count - 1 To 0 Step -1 'dt contains all events in desc order, so we should reverse processing
            ProcessEvent(dataView(i).Row)
        Next

    End Sub
    Private Shared ReadOnly m_Event2Notification As New Dictionary(Of EventType, NotificationType)
    Private Shared ReadOnly Property Event2Notification As Dictionary(Of EventType, NotificationType)
        Get
            SyncLock m_Event2Notification
                If m_Event2Notification.Count = 0 Then
                    m_Event2Notification.Add(EventType.HumanCaseCreatedLocal, NotificationType.HumanCase)
                    m_Event2Notification.Add(EventType.HumanCaseDiagnosisChangedLocal, NotificationType.HumanCaseDiagnosisChange)
                    m_Event2Notification.Add(EventType.HumanCaseClassificationChangedLocal, NotificationType.HumanCaseClassificationChange)
                    m_Event2Notification.Add(EventType.HumanTestResultRegistrationLocal, NotificationType.HumanCaseTestResultRegistration)
                    m_Event2Notification.Add(EventType.HumanTestResultAmendmentLocal, NotificationType.HumanCaseTestResultAmendment)
                    m_Event2Notification.Add(EventType.ClosedHumanCaseReopenedLocal, NotificationType.HumanCaseReopened)
                    m_Event2Notification.Add(EventType.OutbreakCreatedLocal, NotificationType.Outbreak)
                    m_Event2Notification.Add(EventType.NewHumanCaseAddedToOutbreakLocal, NotificationType.OutbreakNewHumanCaseAddition)
                    m_Event2Notification.Add(EventType.NewVetCaseAddedToOutbreakLocal, NotificationType.OutbreakNewVetCaseAddition)
                    m_Event2Notification.Add(EventType.NewVsSessionAddedToOutbreakLocal, NotificationType.OutbreakNewVsSessionAddition)
                    m_Event2Notification.Add(EventType.OutbreakStatusChangedLocal, NotificationType.OutbreakStatusChange)
                    m_Event2Notification.Add(EventType.OutbreakPrimaryCaseChangedLocal, NotificationType.OutbreakPrimaryCaseChange)
                    m_Event2Notification.Add(EventType.VetCaseCreatedLocal, NotificationType.VetCase)
                    m_Event2Notification.Add(EventType.VetCaseDiagnosisChangedLocal, NotificationType.VetCaseDiagnosisChange)
                    m_Event2Notification.Add(EventType.VetCaseClassificationChangedLocal, NotificationType.VetCaseClassificationChange)
                    m_Event2Notification.Add(EventType.VetCaseFieldTestResultRegistrationLocal, NotificationType.VetCaseFieldTestResultRegistration)
                    m_Event2Notification.Add(EventType.VetCaseTestResultRegistrationLocal, NotificationType.VetCaseTestResultRegistration)
                    m_Event2Notification.Add(EventType.VetCaseTestResultAmendmentLocal, NotificationType.VetCaseTestResultAmendment)
                    m_Event2Notification.Add(EventType.ClosedVetCaseReopenedLocal, NotificationType.VetCaseReopened)
                    m_Event2Notification.Add(EventType.VsSessionCreatedLocal, NotificationType.VsSession)
                    m_Event2Notification.Add(EventType.VsSessionNewDiagnosisLocal, NotificationType.VsSessionDiagnosisDetection)
                    m_Event2Notification.Add(EventType.VsSessionFieldTestResultRegistrationLocal, NotificationType.VsSessionFieldTestResultRegistration)
                    m_Event2Notification.Add(EventType.VsSessionTestResultRegistrationLocal, NotificationType.VsSessionTestResultRegistration)
                    m_Event2Notification.Add(EventType.VsSessionTestResultAmendmentLocal, NotificationType.VsSessionTestResultAmendment)
                    m_Event2Notification.Add(EventType.AsCampaignCreatedLocal, NotificationType.AsCampaign)
                    m_Event2Notification.Add(EventType.AsSessionCreatedLocal, NotificationType.AsSession)
                    m_Event2Notification.Add(EventType.AsCampaignStatusChangedLocal, NotificationType.AsCampaignStatusChange)
                    m_Event2Notification.Add(EventType.ClosedAsSessionReopenedLocal, NotificationType.AsSessionReopened)
                    m_Event2Notification.Add(EventType.AsSessionTestResultRegistrationLocal, NotificationType.AsSessionTestResultRegistration)
                    m_Event2Notification.Add(EventType.AsSessionTestResultAmendmentLocal, NotificationType.AsSessionTestResultAmendment)
                    m_Event2Notification.Add(EventType.HumanAggregateCaseCreatedLocal, NotificationType.HumanAggregateCase)
                    m_Event2Notification.Add(EventType.HumanAggregateCaseChangedLocal, NotificationType.HumanAggregateCaseChange)
                    m_Event2Notification.Add(EventType.VetAggregateCaseCreatedLocal, NotificationType.VetAggregateCase)
                    m_Event2Notification.Add(EventType.VetAggregateCaseChangedLocal, NotificationType.VetAggregateCaseChange)
                    m_Event2Notification.Add(EventType.VetAggregateActionCreatedLocal, NotificationType.VetAggregateAction)
                    m_Event2Notification.Add(EventType.VetAggregateActionChangedLocal, NotificationType.VetAggregateActionChange)
                    m_Event2Notification.Add(EventType.NewSampleTransferInLocal, NotificationType.NewSampleTransferIn)
                    m_Event2Notification.Add(EventType.TestResultForSampleTransferredIn, NotificationType.TestResultForSampleTransferredOut)
                    m_Event2Notification.Add(EventType.BssFormLocal, NotificationType.BssForm)
                    m_Event2Notification.Add(EventType.BssAggregateFormLocal, NotificationType.BssAggregateForm)

                    m_Event2Notification.Add(EventType.AVRLayoutPublishedLocal, NotificationType.AVRLayoutPublish)
                    m_Event2Notification.Add(EventType.AVRLayoutUnpublishedLocal, NotificationType.AVRLayoutUnpublished)
                    m_Event2Notification.Add(EventType.AVRLayoutFolderPublishedLocal, NotificationType.AVRLayoutFolderPublished)
                    m_Event2Notification.Add(EventType.AVRLayoutFolderUnpublishedLocal, NotificationType.AVRLayoutFolderUnpublished)
                    m_Event2Notification.Add(EventType.AVRQueryPublishedLocal, NotificationType.AVRQueryPublished)
                    m_Event2Notification.Add(EventType.AVRQueryUnpublishedLocal, NotificationType.AVRQueryUnpublished)
                    m_Event2Notification.Add(EventType.SettlementChanged, NotificationType.SettlementChanged)
                    m_Event2Notification.Add(EventType.AggregateSettingsChanged, NotificationType.AggregateSettingsChange)
                    m_Event2Notification.Add(EventType.SecurityPolicyChanged, NotificationType.SecurityPolicyChange)
                    m_Event2Notification.Add(EventType.FFUNITemplateChanged, NotificationType.FFTemplateChange)
                    m_Event2Notification.Add(EventType.FFDeterminantChanged, NotificationType.FFTemplateDeterminantChange)
                    m_Event2Notification.Add(EventType.ReferenceTableChanged, NotificationType.ReferenceTableChanged)
                    m_Event2Notification.Add(EventType.RaiseReferenceCacheChange, NotificationType.RaiseReferenceCacheChange)
                    m_Event2Notification.Add(EventType.MatrixChanged, NotificationType.MatrixChange)
                    m_Event2Notification.Add(EventType.ReplicationRequestedByUser, NotificationType.StartForcedReplication)

                End If
                Return m_Event2Notification
            End SyncLock
        End Get
    End Property

    Friend Sub ProcessEvent(ByVal row As DataRow)
        Dim tempEventType As EventType
        Dim accociatedObjectID As Long = 0
        Dim idfUserID As Object = row("idfUserID")
        Dim startReplication As Boolean = True
        Dim diagnosisId As Object = row("idfsDiagnosis")
        Dim sourceSiteID As Object = row("idfsSite")
        Dim loginSiteID As Object = row("idfsLoginSite")
        'for tests only
        Dim id As Object

        If Not row("intProcessed") Is DBNull.Value AndAlso CInt(row("intProcessed")) = 2 Then
            startReplication = False
        End If
        If Not row.IsNull("idfsEventTypeID") Then
            'Dim UseStandardReplication As Boolean = Not m_ServiceConfig.UseRoutineReplication Is Nothing AndAlso m_ServiceConfig.UseRoutineReplication = "True"
            If Not row.IsNull("idfObjectID") AndAlso TypeOf (row("idfObjectID")) Is Long Then
                accociatedObjectID = CType(row("idfObjectID"), Long)
            End If
            Try
                tempEventType = CType(row("idfsEventTypeID"), EventType)
                TraceMe("Ntfy_ProcessEvent: event of type EventType {0} for object {1} is occured. Event ID: {2}", tempEventType.ToString, accociatedObjectID.ToString, row("idfEventID").ToString)
            Catch ex As Exception
                TraceMe("Ntfy_ProcessEvent error: {0}", ex.ToString)
                Return
            End Try

            Select Case tempEventType
                Case EventType.AVRLayoutPublishedLocal, _
                    EventType.AVRLayoutFolderPublishedLocal, _
                    EventType.AVRQueryPublishedLocal, _
                    EventType.SettlementChanged, _
                    EventType.FFUNITemplateChanged, _
                    EventType.FFDeterminantChanged
                    If accociatedObjectID <> 0 Then
                        id = m_NotificationManager.CreateNotification(Event2Notification(tempEventType), accociatedObjectID, Nothing, sourceSiteID, loginSiteID)
                        RaiseEvent EventOccured(m_Credentials.SQLServer, row, id)
                    End If
                    m_EidssEventLog.MarkAsProcessed(row("idfEventID"))
                Case EventType.AVRLayoutUnpublishedLocal, _
                     EventType.AVRQueryUnpublishedLocal, _
                     EventType.AVRLayoutFolderUnpublishedLocal
                    If Not Utils.IsEmpty(row("strNote")) Then
                        'idfObjectID contains local object id (thisis needed to display local object during event showing)
                        'but we must unpublish global object, that is already deleted by unpublish procedure. 
                        'To go around this problem we temporary save global object id to strNote field that doesn't currently use
                        'TODO: in the next version create special bigint field to store global object id for unpublishing
                        accociatedObjectID = CLng(row("strNote"))
                        id = m_NotificationManager.CreateNotification(Event2Notification(tempEventType), accociatedObjectID, Nothing, sourceSiteID, loginSiteID)
                        RaiseEvent EventOccured(m_Credentials.SQLServer, row, id)
                    End If
                Case EventType.AggregateSettingsChanged, _
                    EventType.SecurityPolicyChanged
                    id = m_NotificationManager.CreateNotification(Event2Notification(tempEventType), Nothing, Nothing, sourceSiteID, loginSiteID)
                    RaiseEvent EventOccured(m_Credentials.SQLServer, row, id)

                Case EventType.ReplicationRequestedByUser
                    If (accociatedObjectID = CLng(ReplicationType.ForcedReplication)) Then
                        id = m_NotificationManager.CreateNotification(Event2Notification(tempEventType), accociatedObjectID, Nothing, sourceSiteID, loginSiteID, row("idfUserID"))
                        If Not id Is Nothing Then
                            ReplicationController.StartForcedReplication(CLng(id), CLng(id), True, Utils.ToLong(row("idfUserID")))
                            RaiseEvent EventOccured(m_Credentials.SQLServer, row, id)
                        End If
                    Else
                        'Dim controller As New ReplicationController(m_Credentials, m_ConfigFile)
                        ReplicationController.StartCompleteReplication(True)
                    End If
                    m_EidssEventLog.MarkAsProcessed(row("idfEventID"))
                Case EventType.ReferenceTableChanged, _
                    EventType.RaiseReferenceCacheChange, _
                    EventType.MatrixChanged
                    If Not row.IsNull("strInformationString") Then
                        id = m_NotificationManager.CreateNotification(Event2Notification(tempEventType), row("strInformationString"), Nothing, sourceSiteID, loginSiteID)
                        RaiseEvent EventOccured(m_Credentials.SQLServer, row, id)
                    End If
                    m_EidssEventLog.MarkAsProcessed(row("idfEventID"))
                    'ѕравильно ли обрабатываютс€ эти событи€???
                Case EventType.AVRLayoutShared, _
                     EventType.ReplicationFailed, _
                     EventType.ReplicationRetrying, _
                     EventType.ReplicationStarted, _
                     EventType.ReplicationSucceeded, _
                     EventType.NotificationServiceIsNotRunning
                    m_EidssEventLog.MarkAsProcessed(row("idfEventID"))
                    RaiseEvent EventOccured(m_Credentials.SQLServer, row, accociatedObjectID)
                Case Else
                    If (Event2Notification.ContainsKey(tempEventType)) Then
                        If accociatedObjectID <> 0 Then
                            id = m_NotificationManager.CreateNotification(Event2Notification(tempEventType), accociatedObjectID, diagnosisId, sourceSiteID, loginSiteID)
                            RaiseEvent EventOccured(m_Credentials.SQLServer, row, id)
                            'for tests only
                            If (startReplication) Then
                                RaiseEvent NotificationForReplicationCreated(Me, New IdEventArgs(CType(id, Long)))
                            End If
                        End If
                        m_EidssEventLog.MarkAsProcessed(row("idfEventID"))
                    Else
                        RaiseEvent EventOccured(m_Credentials.SQLServer, row, accociatedObjectID)
                    End If
            End Select
        End If
    End Sub
    Private Sub TraceMe(ByVal message As String, ByVal ParamArray params() As String)
        Trace.WriteLine(Trace.Kind.Info, String.Format("Server " & m_Credentials.SQLServer & "-" & message, params))
    End Sub

End Class
