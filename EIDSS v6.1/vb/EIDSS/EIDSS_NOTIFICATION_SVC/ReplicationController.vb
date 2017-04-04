Imports bv.common
Imports bv.common.Diagnostics
Imports bv.common.db.Core
Imports bv.common.db
Imports bv.common.Core
Imports bv.common.Configuration
Imports EIDSS.model.Core
Imports EIDSS.model.Enums
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.SqlClient

Public Class ReplicationController

    Protected m_ServiceConfig As ServiceConfiguration
    Protected m_EidssEventLog As EidssEventLog
    Private ReadOnly m_Credentials As ConnectionCredentials
    Private Shared ReadOnly m_SyncObject As Object = New Object
    Private Shared m_StartDelayedReplication As Boolean
    Private Shared ReadOnly m_ReplicationTimer As New Threading.Timer(AddressOf StartReplicationAsync, Nothing, 0, BaseSettings.DelayedReplicationPeriod)

    Private Shared ReadOnly m_ForcedReplicationQueue As New List(Of ForcedReplicationItem)
    Private Shared m_ForcedReplicationTimer As Threading.Timer
    Private Shared m_AdminConnectionManager As ConnectionManager
    Private Shared m_Instance As ReplicationController
    Public Shared ReadOnly Property Instance As ReplicationController
        Get
            Return m_Instance
        End Get
    End Property
    Public Shared Sub Init(Optional ByVal credentials As ConnectionCredentials = Nothing, Optional ByVal configFile As String = Nothing)
        m_AdminConnectionManager = Nothing
        m_ForcedReplicationTimer = Nothing
        m_Instance = New ReplicationController(credentials, configFile)
    End Sub

    Private Class ForcedReplicationItem
        Public Sub New(id As Long, aSourceNotificationId As Long, aCreateEvent As Boolean, aUserId As Long)
            NotificationId = id
            SourceNotificationId = aSourceNotificationId
            StartDate = DateTime.MinValue
            CreateEvent = aCreateEvent
            UserId = aUserId
        End Sub
        Public Property NotificationId As Long
        Public Property SourceNotificationId As Long
        Public Property StartDate As DateTime
        Public Property CreateEvent As Boolean
        Public Property UserId As Long
    End Class

    Public Sub New(Optional ByVal credentials As ConnectionCredentials = Nothing, Optional ByVal configFile As String = Nothing)
        If credentials Is Nothing Then
            m_Credentials = New ConnectionCredentials()
        Else
            m_Credentials = credentials
        End If
        m_ServiceConfig = New ServiceConfiguration(configFile)
        m_ServiceConfig.ReadConfiguration()
        m_EidssEventLog = New EidssEventLog(m_Credentials, m_ServiceConfig.ClientID)
        If (m_AdminConnectionManager Is Nothing) Then
            m_AdminConnectionManager = ConnectionManager.Create(credentials.SQLServer, String.Format("{0}_Admin", credentials.SQLDatabase), credentials.SQLUser, credentials.SQLPassword, credentials.SQLConnectionString)
            m_AdminConnectionManager.UseContext = False
        End If
        If (m_ForcedReplicationTimer Is Nothing) Then
            m_ForcedReplicationTimer = New Threading.Timer(AddressOf StartForcedReplicationAsyncShared, Nothing, 1000, EidssSiteContext.Instance.ForcedReplicationPeriod)
        End If
    End Sub

    Private Shared Sub StartReplicationAsync(ByVal state As Object)
        SyncLock m_SyncObject
            If m_StartDelayedReplication Then
                m_StartDelayedReplication = False
                m_ReplicationTimer.Change(Threading.Timeout.Infinite, Threading.Timeout.Infinite)

                Dbg.ConditionalDebug(DebugDetalizationLevel.Low, "Delayed replication is starting")
                Instance.RunReplicationJob(Instance.m_ServiceConfig.RoutineJobName)
                'm_ReplicationTimer.Change(0, BaseSettings.DelayedReplicationPeriod)
            End If
        End SyncLock
    End Sub
    Private Shared Sub StartForcedReplicationAsyncShared(ByVal state As Object)
        If (Not Instance Is Nothing) Then
            Instance.StartForcedReplicationAsync(state)
        End If
    End Sub
    Private Sub StartForcedReplicationAsync(ByVal state As Object)
        SyncLock m_SyncObject
            Dim newItems As List(Of ForcedReplicationItem)
            SyncLock m_ForcedReplicationQueue
                newItems = m_ForcedReplicationQueue.AsEnumerable().Where(Function(c) c.StartDate = DateTime.MinValue).ToList()
            End SyncLock
            If newItems.Count > 0 Then
                Dbg.ConditionalDebug(DebugDetalizationLevel.Low, "Forced replication is starting")
                If (JobAccessor.Instance.IsJobRuning(m_ServiceConfig.RoutineJobName)) Then 'if job is running already, try to start it when it is finished
                    m_ForcedReplicationTimer.Change(1000, EidssSiteContext.Instance.ForcedReplicationPeriod)
                    Return
                Else
                    m_ForcedReplicationTimer.Change(Threading.Timeout.Infinite, Threading.Timeout.Infinite)
                    'mark all new replication requests with current timestamp
                    For Each item As ForcedReplicationItem In newItems
                        item.StartDate = DateTime.Now
                        CreateAdminReplicationNotification(item.NotificationId)
                    Next
                End If
            End If
            If m_ForcedReplicationQueue.Count > 0 Then
                RunReplicationJob(m_ServiceConfig.RoutineJobName)
                'remove expired replication requests from queue
                m_ForcedReplicationTimer.Change(EidssSiteContext.Instance.ForcedReplicationPeriod, EidssSiteContext.Instance.ForcedReplicationPeriod)
            End If
        End SyncLock
        Dim expiredItems As List(Of ForcedReplicationItem)
        SyncLock m_ForcedReplicationQueue
            expiredItems = m_ForcedReplicationQueue.AsEnumerable().Where(Function(c) c.StartDate.AddMinutes(EidssSiteContext.Instance.ForcedReplicationExpirationPeriod) < DateTime.Now).ToList()
        End SyncLock
        For Each item As ForcedReplicationItem In expiredItems
            ExpireForcedReplication(item, item.CreateEvent)
        Next
    End Sub

    Public Shared Sub ConfirmForcedReplication(idfNotification As Long, createConfirmEvent As Boolean, targetUserId As Long)
        SyncLock m_ForcedReplicationQueue
            If Not Instance Is Nothing Then
                Dim items As List(Of ForcedReplicationItem) = m_ForcedReplicationQueue.AsEnumerable().Where(Function(c) c.SourceNotificationId = idfNotification).ToList()
                If items.Count > 0 Then
                    Dbg.Debug("confirmation of forced replication is come for notification {0}", idfNotification)
                    Dbg.Debug("notifications in queue count is {0}, show confirmation = {1}", items.Count, createConfirmEvent)
                    items.All(Function(c) m_ForcedReplicationQueue.Remove(c))
                    If (createConfirmEvent) Then
                        Dbg.Debug("Creating forced replication confirmation event")
                        Instance.CreateEvent(EventType.ForcedReplicationConfirmed, items(0).SourceNotificationId, items(0).UserId)
                    End If

                End If
            End If
        End SyncLock
    End Sub
    Public Shared Sub ExpireForcedReplication(idfNotification As Long, createEvent As Boolean)
        If m_ForcedReplicationQueue.AsEnumerable().Count(Function(c) c.NotificationId = idfNotification) > 0 Then
            ExpireForcedReplication(m_ForcedReplicationQueue.AsEnumerable().FirstOrDefault(Function(c) c.NotificationId = idfNotification), createEvent)
        End If
    End Sub
    Private Shared Sub ExpireForcedReplication(item As ForcedReplicationItem, createEvent As Boolean)
        SyncLock m_ForcedReplicationQueue
            If Not Instance Is Nothing Then
                m_ForcedReplicationQueue.Remove(item)
                If (createEvent) Then
                    Instance.CreateEvent(EventType.ForcedReplicationExpired, item.SourceNotificationId, item.UserId)
                End If
            End If
        End SyncLock
    End Sub

    Private Shared Sub CreateAdminReplicationNotification(notificationId As Long)
        Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spCreateReplicationNotification", m_AdminConnectionManager.Connection)
        BaseDbService.AddParam(cmd, "@idfNotification", notificationId)
        BaseDbService.ExecCommand(cmd, cmd.Connection)
        Trace.WriteLine(Trace.Kind.Info, "Replication Controller: notification {0} created in admin database {1}, tstReplicateDataNotification table.", notificationId.ToString(), cmd.Connection.Database)
    End Sub

    Public Sub CreateEvent(ByVal e As EventType, ByVal objectID As Object, targetUser As Long)
        If e <> EventType.None Then
            m_EidssEventLog.CreateEvent(e, objectID, Nothing, , targetUser)
        End If
    End Sub
    Public Sub CheckFiltration()
        If (BaseSettings.RecalcFiltration) Then
            DebugTimer.Start("spFiltered_CheckEventMass")
            Try
                Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spFiltered_CheckEventMass", ConnectionManager.DefaultInstance.Connection)
                StoredProcParamsCache.CreateParameters(cmd)
                BaseDbService.ExecCommand(cmd, cmd.Connection)
            Catch ex As Exception
                Trace.WriteLine(Trace.Kind.Error, "spFiltered_CheckEventMass error:{0}", ex.ToString)
            Finally
                DebugTimer.Stop()
            End Try
        End If

    End Sub
    Private Function RunReplicationJob(ByVal jobName As String) As Integer
        If Utils.IsEmpty(jobName) Then
            Dbg.Debug("Job Name is not defined")
            Return 1
        End If
        If EidssSiteContext.Instance.RealSiteType = SiteType.CDR Then
            Dbg.Debug("replication can't be started on CDR")
            Return 1
        End If

        Return JobAccessor.Instance.RunReplicationJob(jobName, Me)

    End Function
    Public Shared Sub StartCompleteReplication(delayedReplication As Boolean)
        If Utils.IsEmpty(Instance.m_ServiceConfig.RoutineJobName) Then
            Dbg.Debug("Routine Job Name is not defined")
            Return
        End If
        If EidssSiteContext.Instance.RealSiteType = SiteType.CDR Then
            Dbg.Debug("replication can't be started on CDR")
        End If
        SyncLock m_SyncObject
            If (m_StartDelayedReplication = True AndAlso Not delayedReplication) Then
                Return 'do nothing if delayed replication is started already
            End If
            m_StartDelayedReplication = True
            If (Not delayedReplication) Then
                m_ReplicationTimer.Change(0, 0)
            Else
                m_ReplicationTimer.Change(BaseSettings.DelayedReplicationPeriod, BaseSettings.DelayedReplicationPeriod)
            End If
        End SyncLock
    End Sub
    Public Shared Sub StartForcedReplication(notificationId As Long, sourceNotificationId As Long, createEvent As Boolean, userId As Long)
        SyncLock m_ForcedReplicationQueue
            m_ForcedReplicationQueue.Add(New ForcedReplicationItem(notificationId, sourceNotificationId, createEvent, userId))
        End SyncLock
        m_ForcedReplicationTimer.Change(1000, EidssSiteContext.Instance.ForcedReplicationPeriod)
    End Sub
End Class
