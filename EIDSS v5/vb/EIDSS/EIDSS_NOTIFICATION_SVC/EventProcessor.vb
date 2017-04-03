Imports bv.common
Imports System.Text.RegularExpressions
Imports bv.common.db.Core
Imports bv.common.Configuration

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

    'Protected m_DBService As EmNotify_DB
    Protected m_MaxEventNumber As Integer = 0
    Protected m_EventLog As EIDSS_EventLog
    Public Event EventOccured As ServiceBase.DataRowEvent
    Private m_NotificationManager As NotificationManager
    Private m_credentials As ConnectionCredentials
    Private m_ConfigFile As String
    Protected m_ServiceConfig As ServiceConfiguration
    Private m_SiteID As Long 'if >0 indicates that initialization was performed correctly
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
            If Not m_EventLog Is Nothing Then
                Return m_EventLog.Connection.Database
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
    Public Sub New(Optional ByVal ConfigFile As String = Nothing)
        m_credentials = New ConnectionCredentials(ConfigFile)
        m_ConfigFile = ConfigFile
        m_ServiceConfig = New ServiceConfiguration(ConfigFile)
        m_ServiceConfig.ReadConfiguration()

        'm_DBService = New EmNotify_DB(m_credentials, m_ServiceConfig.ClientID)
        m_EventLog = New EIDSS_EventLog(m_credentials, m_ServiceConfig.ClientID)
        m_EventLog.IsNotificationService = True
        m_NotificationManager = New NotificationManager(m_credentials, m_ServiceConfig)
        If m_NotificationManager Is Nothing OrElse Not m_NotificationManager.IsValid Then
            Throw New Exception("Notification manager is not initialized correctly")
        End If
    End Sub
    Public Sub Listen()
        AddHandler m_EventLog.EventOccured, AddressOf WorkerProc
        m_EventLog.Listen()
        Trace.WriteLine(Trace.Kind.Info, "Ntfy_Start: Event log listener is started on database {0}.", m_credentials.SQLDatabase)
    End Sub
    Public Sub [Stop]()
        m_EventLog.Stop()
        RemoveHandler m_EventLog.EventOccured, AddressOf WorkerProc
        Trace.WriteLine(Trace.Kind.Info, "Ntfy_Start: Event log listener is stopped on database {0}.", m_credentials.SQLDatabase)
    End Sub
    Public Sub SkipExistingEvents()
        m_EventLog.GetEvents()
    End Sub
    Public Sub WorkerProc(ByVal dt As DataTable)
        If Not m_NotificationManager.IsValid Then
            Return
        End If
        Dim tempDV As New DataView(dt)
        'tempDV.Sort = "intRowNum"
        tempDV.RowFilter = "intProcessed<>1"

        Dim tempDRow As DataRow
        Dim I As Integer

        'm_ServiceConfig.ReadConfiguration()

        For I = tempDV.Count - 1 To 0 Step -1 'dt contains all events in desc order, so we should reverse processing
            tempDRow = tempDV(I).Row

            ProcessEvent(tempDRow)

            'If I = tempDV.Count - 1 Then m_MaxEventNumber = I
        Next

    End Sub

    Friend Function ProcessEvent(ByVal DRow As DataRow) As Boolean
        Dim RetRes As Boolean = False
        Dim tempEventType As EventType
        Dim AccociatedObjectID As Long = 0
        Dim idfUserID As Object = DRow("idfUserID")
        Dim StartReplication As Boolean = True
        'for tests only
        Dim Id As Object = Nothing

        If Not DRow("intProcessed") Is DBNull.Value AndAlso CInt(DRow("intProcessed")) = 2 Then
            StartReplication = False
        End If
        If Not DRow.IsNull("idfsEventTypeID") Then
            'Dim UseStandardReplication As Boolean = Not m_ServiceConfig.UseRoutineReplication Is Nothing AndAlso m_ServiceConfig.UseRoutineReplication = "True"
            If Not DRow.IsNull("idfObjectID") AndAlso TypeOf (DRow("idfObjectID")) Is Long Then
                AccociatedObjectID = CType(DRow("idfObjectID"), Long)
            End If
            Try
                tempEventType = CType(DRow("idfsEventTypeID"), EventType)
                TraceMe("Ntfy_ProcessEvent: event of type EventType {0} for object {1} is occured. Event num: {2}", tempEventType.ToString, AccociatedObjectID.ToString, DRow("intRowNum").ToString)
            Catch ex As Exception
                TraceMe("Ntfy_ProcessEvent error: {0}", ex.ToString)
                Return False
            End Try
            Select Case tempEventType
                Case EventType.NewHumanCase
                    If AccociatedObjectID <> 0 Then
                        Id = m_NotificationManager.CreateNotification(NotificationType.HumanCase, AccociatedObjectID, idfUserID, StartReplication, Nothing)
                        RaiseEvent EventOccured(m_credentials.SQLServer, DRow, Id)
                        'for tests only
                        If (StartReplication) Then
                            RaiseEvent NotificationForReplicationCreated(Me, New IdEventArgs(CType(Id, Long)))
                        End If
                    End If
                    m_EventLog.MarkAsProcessed(DRow("idfEventID"))
                Case EventType.NewVetCase
                    If AccociatedObjectID <> 0 Then
                        Id = m_NotificationManager.CreateNotification(NotificationType.VetCase, AccociatedObjectID, idfUserID, StartReplication, Nothing)
                        RaiseEvent EventOccured(m_credentials.SQLServer, DRow, Id)
                        'for tests only
                        If (StartReplication) Then
                            RaiseEvent NotificationForReplicationCreated(Me, New IdEventArgs(CType(Id, Long)))
                        End If
                    End If
                    m_EventLog.MarkAsProcessed(DRow("idfEventID"))
                Case EventType.NewOutbreak
                    If AccociatedObjectID <> 0 Then
                        Id = m_NotificationManager.CreateNotification(NotificationType.Outbreak, AccociatedObjectID, idfUserID, StartReplication, Nothing)
                        RaiseEvent EventOccured(m_credentials.SQLServer, DRow, Id)
                        'for tests only
                        If (StartReplication) Then
                            RaiseEvent NotificationForReplicationCreated(Me, New IdEventArgs(CType(Id, Long)))
                        End If
                    End If
                    m_EventLog.MarkAsProcessed(DRow("idfEventID"))
                Case EventType.CaseDiseaseChange
                    If AccociatedObjectID <> 0 Then
                        Id = m_NotificationManager.CreateNotification(NotificationType.CaseDiagnosisChangedNotification, AccociatedObjectID, idfUserID, StartReplication, Nothing)
                        RaiseEvent EventOccured(m_credentials.SQLServer, DRow, Id)
                        'for tests only
                        If (StartReplication) Then
                            RaiseEvent NotificationForReplicationCreated(Me, New IdEventArgs(CType(Id, Long)))
                        End If
                    End If
                    m_EventLog.MarkAsProcessed(DRow("idfEventID"))
                Case EventType.CaseStatusChange
                    If AccociatedObjectID <> 0 Then
                        Id = m_NotificationManager.CreateNotification(NotificationType.CaseStatusChangedNotification, AccociatedObjectID, idfUserID, StartReplication, Nothing)
                        RaiseEvent EventOccured(m_credentials.SQLServer, DRow, Id)
                        'for tests only
                        If (StartReplication) Then
                            RaiseEvent NotificationForReplicationCreated(Me, New IdEventArgs(CType(Id, Long)))
                        End If
                    End If
                    m_EventLog.MarkAsProcessed(DRow("idfEventID"))
                Case EventType.NewTestResult
                    If AccociatedObjectID <> 0 Then
                        Id = m_NotificationManager.CreateNotification(NotificationType.TestResultsReceived, AccociatedObjectID, idfUserID, StartReplication, Nothing)
                        RaiseEvent EventOccured(m_credentials.SQLServer, DRow, Id)
                        'for tests only
                        If (StartReplication) Then
                            RaiseEvent NotificationForReplicationCreated(Me, New IdEventArgs(CType(Id, Long)))
                        End If
                    End If
                    m_EventLog.MarkAsProcessed(DRow("idfEventID"))
                Case EventType.NewTestAmendment
                    If AccociatedObjectID <> 0 Then
                        Id = m_NotificationManager.CreateNotification(NotificationType.TestAmendment, AccociatedObjectID, idfUserID, StartReplication, Nothing)
                        RaiseEvent EventOccured(m_credentials.SQLServer, DRow, Id)
                        'for tests only
                        If (StartReplication) Then
                            RaiseEvent NotificationForReplicationCreated(Me, New IdEventArgs(CType(Id, Long)))
                        End If
                    End If
                    m_EventLog.MarkAsProcessed(DRow("idfEventID"))
                Case EventType.AVRLayoutUpdate
                    If AccociatedObjectID <> 0 Then
                        Id = m_NotificationManager.CreateNotification(NotificationType.AVRLayoutUpdate, AccociatedObjectID, idfUserID, False, Nothing)
                        RaiseEvent EventOccured(m_credentials.SQLServer, DRow, Id)
                    End If
                    m_EventLog.MarkAsProcessed(DRow("idfEventID"))
                Case EventType.SettlementChanged
                    If AccociatedObjectID <> 0 Then
                        Id = m_NotificationManager.CreateNotification(NotificationType.SettlementChanged, AccociatedObjectID, idfUserID, False, Nothing)
                        RaiseEvent EventOccured(m_credentials.SQLServer, DRow, Id)
                    End If
                    m_EventLog.MarkAsProcessed(DRow("idfEventID"))
                Case EventType.NotificationReplicationRequest
                    RaiseEvent EventOccured(m_credentials.SQLServer, DRow, Nothing)
                    Dim RCtrlr As New ReplicationController(m_credentials, m_ConfigFile)
                    'RCtrlr.StartNotificationReplication(AccociatedObjectID)
                    RCtrlr.StartCompleteReplication()
                    m_EventLog.MarkAsProcessedBatch(EventType.NotificationReplicationRequest)
                Case EventType.ReplicationRequestedByUser
                    RaiseEvent EventOccured(m_credentials.SQLServer, DRow, Nothing)
                    Dim RCtrlr As New ReplicationController(m_credentials, m_ConfigFile)
                    RCtrlr.StartCompleteReplication()
                    m_EventLog.MarkAsProcessedBatch(EventType.ReplicationRequestedByUser)
                Case EventType.ReferenceTableChanged
                    If Not DRow.IsNull("strInformationString") Then
                        Id = m_NotificationManager.CreateNotification(NotificationType.ReferenceTableChanged, DRow("strInformationString"), idfUserID, False, Nothing)
                        RaiseEvent EventOccured(m_credentials.SQLServer, DRow, Id)
                    End If
                    m_EventLog.MarkAsProcessed(DRow("idfEventID"))
                Case Else
                    RaiseEvent EventOccured(m_credentials.SQLServer, DRow, AccociatedObjectID)
            End Select
        End If

        Return RetRes
    End Function
    Private Sub TraceMe(ByVal Message As String, ByVal ParamArray params() As String)
        Trace.WriteLine(Trace.Kind.Info, String.Format("Server " & m_credentials.SQLServer & "-" & Message, params))
    End Sub

End Class
