Imports System.Threading
Imports bv.common.Configuration

Public Enum NotificationMode
    NoWait
    WaitReplaySync
    WaitReplayAsync
End Enum
Public Class NotificationManager
    Shared timer As System.Threading.Timer
    Shared NotificationRequestsQueue As New ArrayList
    Protected m_DBService As EmNotify_DB
    Private m_ReplicationClient As ReplicationClient
    Private m_credentials As ConnectionCredentials
    Private m_Config As ServiceConfiguration

    Class NotificationEntry
        Public Type As NotificationType
        Public sourceID As Long
        Public waitMode As NotificationMode
        Public AttemptsCount As Integer
        Public UserID As Object
        Const MinAttemptsCount As Integer = 4
        Public ReadOnly Property PoolInterval() As Integer
            Get
                If AttemptsCount < MinAttemptsCount Then
                    If waitMode = NotificationMode.WaitReplaySync Then
                        Return 3000
                    Else
                        Return 10000
                    End If
                Else
                    If waitMode = NotificationMode.WaitReplaySync Then
                        waitMode = NotificationMode.WaitReplayAsync
                        Return 10000
                    Else
                        Return 30000
                    End If
                End If

            End Get
        End Property
        Public Sub New(ByVal aType As NotificationType, ByVal aSourceID As Long, ByVal aWaitMode As NotificationMode, ByVal aUserID As Object)
            Type = aType
            sourceID = aSourceID
            waitMode = aWaitMode
            UserID = aUserID
        End Sub
    End Class

    Public Sub New(Optional ByVal credentials As ConnectionCredentials = Nothing, Optional ByVal config As ServiceConfiguration = Nothing)

        If credentials Is Nothing Then
            m_credentials = New ConnectionCredentials()
        Else
            m_credentials = credentials
        End If
        If config Is Nothing Then
            config = New ServiceConfiguration()
        End If
        m_Config = config
        m_DBService = New EmNotify_DB(m_credentials, m_Config.ClientID)
        m_ReplicationClient = New ReplicationClient(m_credentials, m_Config.ClientID)
        m_ReplicationClient.ReferenceJobName = m_Config.ReferenceJobName
        m_ReplicationClient.RoutineJobName = m_Config.RoutineJobName
        'Dim m_SiteService As EIDSS_SiteService
        'm_SiteService.SiteConnection = m_DBService.Connection

        'm_MaxEventNumber = GetMaxNumber(EIDSS.EIDSS_EventLog.GetEvents())
    End Sub

    Public ReadOnly Property IsValid As Boolean
        Get
            Return Not m_DBService Is Nothing AndAlso m_DBService.IsValid
        End Get
    End Property
    Public Function CreateNotification(ByVal aType As NotificationType, ByVal Data As Object, ByVal User As Object, ByVal startReplication As Boolean, Optional ByVal waitType As NotificationMode = NotificationMode.NoWait) As Object
        Dim Id As Object = Nothing
        'If TargetSite Is DBNull.Value Then
        '    TargetSite = Nothing
        'End If
        Dim SourceObjectId As Object = Nothing
        Select Case aType
            Case NotificationType.HumanCase
                SourceObjectId = CType(Data, Long)
                Id = CreateNewHumanCaseNotification(CType(Data, Long))
            Case NotificationType.VetCase
                SourceObjectId = CType(Data, Long)
                Id = CreateNewVetCaseNotification(CType(Data, Long))
                'Case NotificationType.notNewSiteNumberRange
                '    Id = CreateNewSiteNumberRangeRequest(CType(Data, SiteType))
            Case NotificationType.Outbreak
                SourceObjectId = CType(Data, Long)
                Id = CreateNewOutbreakNotification(CType(Data, Long))
                'Case NotificationType.notActivationRequest
                '    Id = CreateActivationRequest(CType(Data, String))
                'Case NotificationType.notActivationCode
                '    Id = CreateActivationCode(CType(TargetSite, String), CType(Data, String))
            Case NotificationType.CaseDiagnosisChangedNotification, NotificationType.CaseStatusChangedNotification
                SourceObjectId = CType(Data, Long)
                Id = CreateCaseChangedNotification(CType(Data, Long), aType)
            Case NotificationType.TestResultsReceived
                SourceObjectId = CType(Data, Long)
                Id = m_DBService.CreateNotification(NotificationType.TestResultsReceived, CLng(SourceObjectId), 0, SourceObjectId.ToString)
            Case NotificationType.ReferenceTableChanged
                Id = m_DBService.CreateNotification(aType, 0, 0, Data.ToString)
            Case NotificationType.AVRLayoutUpdate
                Id = m_DBService.CreateNotification(aType, CType(Data, Long), 0, Data.ToString)
            Case NotificationType.SettlementChanged
                Id = m_DBService.CreateNotification(aType, CType(Data, Long), 0, Data.ToString)
        End Select
        If Not Id Is Nothing AndAlso startReplication AndAlso _
                    Not aType.Equals(NotificationType.ReferenceTableChanged) AndAlso _
                    Not aType.Equals(NotificationType.AVRLayoutUpdate) AndAlso _
                    Not aType.Equals(NotificationType.SettlementChanged) Then
            Dbg.Debug("ReplicationClient.StartReplication {0}, {1}", SourceObjectId, User)
            m_ReplicationClient.StartReplication(ReplicationType.Notification, SourceObjectId, User)
            If waitType <> NotificationMode.NoWait Then
                Dbg.Debug("waitType <> NotificationMode.NoWait")
                WaitForAnswer(New NotificationEntry(aType, CType(Id, Long), waitType, User))
            End If
        End If
        Return Id
    End Function


    Private Sub WaitForAnswer(ByVal entry As NotificationEntry)
        If timer Is Nothing Then
            timer = New System.Threading.Timer(New TimerCallback(AddressOf CheckQueue), Nothing, 3000, 3000)
        End If
        Dim myEnumerator As System.Collections.IEnumerator = _
           NotificationRequestsQueue.GetEnumerator()
        Dim interval As Integer = entry.PoolInterval
        While myEnumerator.MoveNext()
            If interval > CType(myEnumerator.Current, NotificationEntry).PoolInterval Then
                interval = CType(myEnumerator.Current, NotificationEntry).PoolInterval
            End If
        End While
        timer.Change(interval, interval)
        NotificationRequestsQueue.Add(entry)
    End Sub

    Private Sub CheckQueue(ByVal state As [Object])
        If NotificationRequestsQueue.Count > 0 Then
            Dim UserID As Object = CType(NotificationRequestsQueue(0), NotificationEntry).UserID
            m_ReplicationClient.StartReplication(ReplicationType.Notification, Nothing, UserID)
        Else
            timer.Dispose()
            timer = Nothing
        End If

    End Sub

    Public Sub RemoveFromQueue(ByVal ntfyType As NotificationType)
        For i As Integer = NotificationRequestsQueue.Count - 1 To 0 Step -1
            If CType(NotificationRequestsQueue(i), NotificationEntry).Type = ntfyType Then
                NotificationRequestsQueue.RemoveAt(i)
            End If
        Next
    End Sub

    Public Sub RemoveFromQueue(ByVal id As Guid)
        For i As Integer = NotificationRequestsQueue.Count - 1 To 0 Step -1
            If CType(NotificationRequestsQueue(i), NotificationEntry).sourceID.Equals(id) Then
                NotificationRequestsQueue.RemoveAt(i)
            End If
        Next
    End Sub
    Private Function CreateNewHumanCaseNotification(ByVal CaseID As Long) As Object
        Return m_DBService.CreateNotification(NotificationType.HumanCase, CaseID, 0, CaseID.ToString)
    End Function
    Private Function CreateNewVetCaseNotification(ByVal CaseID As Long) As Object
        Return m_DBService.CreateNotification(NotificationType.VetCase, CaseID, 0, CaseID.ToString)
    End Function
    Private Function CreateNewOutbreakNotification(ByVal OutbreakID As Long) As Object
        Return m_DBService.CreateNotification(NotificationType.Outbreak, OutbreakID, 0, OutbreakID.ToString)
    End Function

    Private Function CreateCaseChangedNotification(ByVal CaseID As Long, ByVal ntfType As NotificationType) As Object
        Return m_DBService.CreateNotification(ntfType, CaseID, 0, CaseID.ToString)
    End Function

End Class
