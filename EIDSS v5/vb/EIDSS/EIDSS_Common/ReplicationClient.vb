Imports bv.common.db.Core
Imports bv.common.Diagnostics
Imports bv.common.Configuration
Imports bv.common.Core

Public Class ReplicationClient
    Dim m_EventLog As EIDSS_EventLog

    Public Sub New(Optional ByVal credentials As ConnectionCredentials = Nothing, Optional ByVal ClientID As String = Nothing)
        m_EventLog = New EIDSS_EventLog(credentials, ClientID)
    End Sub

    Private Shared m_StdReplicationSourceObjectID As Object = Nothing
    Private Shared m_NtfyReplicationSourceObjectID As Object = Nothing
    Private Shared m_StdReplicationRequested As Boolean = False
    Private Shared m_NtfyReplicationRequested As Boolean = False
    Private Shared m_SyncObject As Object = New Object
    Private m_timer As New Threading.Timer(AddressOf StartReplication, Nothing, Threading.Timeout.Infinite, Threading.Timeout.Infinite)
    Public Function StartReplication(ByVal RepType As ReplicationType, ByVal SourceObjectID As Object, Optional ByVal UserID As Object = Nothing, Optional ByVal WaitResults As Boolean = False, Optional ByVal IdleHandler As EventHandler = Nothing) As Boolean
        If RepType = ReplicationType.Notification AndAlso ReferenceJobName Is Nothing AndAlso Utils.IsEmpty(Config.GetSetting("ReferenceJobName")) Then
            Return True
        End If
        If RepType = ReplicationType.Regular AndAlso RoutineJobName Is Nothing AndAlso Utils.IsEmpty(Config.GetSetting("RoutineJobName")) Then
            Return True
        End If
        SyncLock m_SyncObject
            If RepType = ReplicationType.Notification Then
                If Not m_StdReplicationRequested Then
                    m_StdReplicationSourceObjectID = SourceObjectID
                    m_StdReplicationRequested = True
                    Dbg.ConditionalDebug(DebugDetalizationLevel.Low, "replication client put replication request to buffer for object {0} at {1}", SourceObjectID, DateTime.Now())
                    m_timer.Change(1000, 1000)
                End If
            Else
                If Not m_NtfyReplicationRequested Then
                    m_NtfyReplicationSourceObjectID = SourceObjectID
                    m_NtfyReplicationRequested = True
                    Dbg.ConditionalDebug(DebugDetalizationLevel.Low, "replication client put replication request to buffer for object {0} at {1}", SourceObjectID, DateTime.Now())
                    m_timer.Change(1000, 1000)
                End If
            End If
        End SyncLock
        Return True
    End Function
    Private Sub StartReplication(ByVal state As Object)
        SyncLock m_SyncObject
            m_timer.Change(Threading.Timeout.Infinite, Threading.Timeout.Infinite)
            Dbg.ConditionalDebug(DebugDetalizationLevel.Low, "delayed replication event occured")
            If m_StdReplicationRequested Then
                Dbg.ConditionalDebug(DebugDetalizationLevel.Low, "replication client raise replication event for object {0} at {1}", m_StdReplicationSourceObjectID, DateTime.Now())
                Dim id As Object = m_EventLog.CreateEvent(EventType.ReplicationRequestedByUser, m_StdReplicationSourceObjectID)
            End If
            If m_NtfyReplicationRequested Then
                Dbg.ConditionalDebug(DebugDetalizationLevel.Low, "replication client raise replication event for object {0} at {1}", m_NtfyReplicationSourceObjectID, DateTime.Now())
                Dim id As Object = m_EventLog.CreateEvent(EventType.NotificationReplicationRequest, m_NtfyReplicationSourceObjectID)
            End If
            m_StdReplicationSourceObjectID = Nothing
            m_StdReplicationRequested = False
            m_NtfyReplicationSourceObjectID = Nothing
            m_NtfyReplicationRequested = False
        End SyncLock
    End Sub
    Private Shared m_ReferenceJobName As String
    Public Property ReferenceJobName() As String
        Get
            Return m_ReferenceJobName
        End Get
        Set(ByVal value As String)
            m_ReferenceJobName = value
        End Set
    End Property
    Private Shared m_RoutineJobName As String
    Public Property RoutineJobName() As String
        Get
            Return m_RoutineJobName
        End Get
        Set(ByVal value As String)
            m_RoutineJobName = value
        End Set
    End Property
End Class
