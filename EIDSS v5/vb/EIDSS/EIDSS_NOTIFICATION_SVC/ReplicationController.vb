Imports bv.common
Imports bv.common.Diagnostics
Imports bv.common.db.Core
Imports bv.common.db
Imports bv.common.Core
Imports bv.common.Configuration

Public Class ReplicationController
    Public Const CompleteReplicationGuid As String = "C0000000-0000-0000-0000-000000000000"
    'Public Const NotificationReplicationGuid As String = "F0000000-0000-0000-0000-000000000000"
    'Public Const ReferenceReplicationGuid As String = "D0000000-0000-0000-0000-000000000000"
    Protected m_ServiceConfig As ServiceConfiguration
    Protected m_eventLog As EIDSS_EventLog
    Private m_LocalServerName As String
    Private m_credentials As ConnectionCredentials
    Private Shared m_NtfyReplicationSourceObjectID As Object = Nothing
    Private Shared m_NtfyReplicationRequested As Boolean = False
    Private Shared m_SyncObject As Object = New Object
    'Private m_timer As New Threading.Timer(AddressOf StartNotificationReplicationByTimer, Nothing, Threading.Timeout.Infinite, Threading.Timeout.Infinite)

    Public Sub New(Optional ByVal credentials As ConnectionCredentials = Nothing, Optional ByVal configFile As String = Nothing)
        If credentials Is Nothing Then
            m_credentials = New ConnectionCredentials()
        Else
            m_credentials = credentials
        End If
        m_ServiceConfig = New ServiceConfiguration(configFile)
        m_ServiceConfig.ReadConfiguration()
        m_eventLog = New EIDSS_EventLog(m_credentials, m_ServiceConfig.ClientID)
        m_LocalServerName = credentials.SQLServer
    End Sub

    'Private Sub StartNotificationReplicationByTimer(ByVal state As Object)
    '    SyncLock m_SyncObject
    '        m_timer.Change(Threading.Timeout.Infinite, Threading.Timeout.Infinite)
    '        If m_NtfyReplicationRequested Then
    '            Dbg.ConditionalDebug(DebugDetalizationLevel.Low, "replication controller raise replication event for object {0}", DateTime.Now())
    '            StartCompleteReplication()
    '            StartNotificationReplication(m_ServiceConfig.EmergencyJobName, m_NtfyReplicationSourceObjectID) 'm_ServiceConfig.EmergencySubscriptionName
    '            m_NtfyReplicationRequested = False
    '            m_NtfyReplicationSourceObjectID = Nothing
    '        End If
    '    End SyncLock
    'End Sub

    'Public Overridable Sub StartNotificationReplication(ByVal SourceObjectID As Object)
    '    SyncLock m_SyncObject
    '        If Not m_NtfyReplicationRequested Then
    '            Dbg.ConditionalDebug(DebugDetalizationLevel.Low, "replication controller put replication request to buffer for object {0} at {1}", SourceObjectID, DateTime.Now())
    '            m_NtfyReplicationSourceObjectID = SourceObjectID
    '            m_NtfyReplicationRequested = True
    '            m_timer.Change(1000, 1000)
    '        End If
    '    End SyncLock
    'End Sub

    Public Sub CreateEvent(ByVal e As EventType, ByVal objectID As Object)
        If e <> EventType.DefaultEventType Then
            m_eventLog.CreateEvent(e, objectID)
        End If
    End Sub
    Public Sub CheckFiltration()
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

    End Sub
    Private Function RunJob(ByVal jobName As String, ByVal sourceObjectID As Object) As Integer
        If Utils.IsEmpty(jobName) Then
            Dbg.Debug("Job Name is not defined")
            Return 1
        End If
        Dim i As Integer = m_ServiceConfig.RetryAttemptsCount
        CheckFiltration()
        'CreateEvent(EventType.ReplicationStarted, sourceObjectID)
        Dim res As Integer

        While i > 0
            If i <> m_ServiceConfig.RetryAttemptsCount Then
                CreateEvent(EventType.ReplicationRetrying, sourceObjectID)
            End If
            res = JobAccessor.Instance.RunJob(jobName, Me)
            If res = 0 Then
                Exit While
            End If

            System.Threading.Thread.Sleep(m_ServiceConfig.RetryInterval)
            i -= 1
        End While

        'If i > 0 AndAlso res = 0 Then
        '    CreateEvent(SuccessEvent, SourceObjectID)
        '    Return 0
        'Else
        '    CreateEvent(FailedEvent, SourceObjectID)
        '    Return 2
        'End If

    End Function
    'Public Overridable Sub StartNotificationReplication(ByVal ReplicationName As String, ByVal SourceObjectID As Object)
    '    RunJob(ReplicationName, SourceObjectID, EventType.OutbreakNotificationSending, EventType.OutbreakNotificationRetrying, EventType.OutbreakNotificationFail, EventType.OutbreakNotificationSucceeded)
    'End Sub
    Public Overridable Sub StartCompleteReplication()
        'If Utils.IsEmpty(m_ServiceConfig.ReferenceJobName) Then
        '    Dbg.Debug("Reference Job Name is not defined")
        '    Return
        'End If
        If Utils.IsEmpty(m_ServiceConfig.RoutineJobName) Then
            Dbg.Debug("Routine Job Name is not defined")
            Return
        End If
        'If RunJob(m_ServiceConfig.ReferenceJobName, ReferenceReplicationGuid, EventType.ReplicationStarted, EventType.ReplicationRetrying, EventType.ReplicationFailed, EventType.DefaultEventType) <> 0 Then
        '    Return
        'End If
        If RunJob(m_ServiceConfig.RoutineJobName, CompleteReplicationGuid) <> 0 Then
            Return
        End If
        'StartNotificationReplication(m_ServiceConfig.EmergencyJobName, NotificationReplicationGuid)


        'Dim i As Integer = m_ServiceConfig.RetryAttemptsCount

        'm_eventLog.CreateEvent(EventType.evtReplicationStarted, CompleteReplicationGuid)
        'Dim res As Integer

        'While i > 0
        '    res = Replicate(m_ServiceConfig.ReferenceJobName)
        '    If res > 0 Then
        '        Exit While
        '    End If

        '    System.Threading.Thread.Sleep(m_ServiceConfig.RetryInterval)

        '    m_eventLog.CreateEvent(EventType.evtReplicationRetrying, ReferenceReplicationGuid)

        '    i -= 1
        'End While
        'If i <= 0 OrElse res <> 3 Then
        '    m_eventLog.CreateEvent(EventType.evtReplicationFailed, ReferenceReplicationGuid)

        '    If i <= 0 Then
        '        Dbg.Debug("Reference replication retry count is exceeded", res)
        '    Else
        '        Dbg.Debug("Reference replication failed with result {0}", res)
        '    End If
        '    Return
        'End If
        'i = m_ServiceConfig.RetryAttemptsCount
        'While i > 0
        '    res = Replicate(m_ServiceConfig.RoutineJobName)
        '    If res > 0 Then
        '        Exit While
        '    End If

        '    System.Threading.Thread.Sleep(m_ServiceConfig.RetryInterval)
        '    m_eventLog.CreateEvent(EventType.evtReplicationRetrying, CompleteReplicationGuid)
        '    i -= 1
        'End While

        'If i > 0 Then
        '    If res = 3 Then
        '        m_eventLog.CreateEvent(EventType.evtReplicationSucceeded, CompleteReplicationGuid)
        '        'The notification replication is to initiate notification replication in the upperlevel server if needed
        '        StartNotificationReplication(m_ServiceConfig.EmergencyJobName, ReplicationType.Notification) 'm_ServiceConfig.EmergencySubscriptionName
        '    ElseIf res = 0 OrElse res = 1 Then
        '        m_eventLog.CreateEvent(EventType.evtReplicationFailed, CompleteReplicationGuid)
        '        Dbg.Debug("Complete replication failed with result {0}", res)
        '    Else
        '        Dbg.Fail("Unexpected replication result. Returned value is {0}", res)
        '    End If
        'Else
        '    m_eventLog.CreateEvent(EventType.evtReplicationFailed, CompleteReplicationGuid)
        '    Dbg.Debug("Complete replication retry count is exceeded", res)
        'End If


    End Sub

    'Return results:
    ' 3 - Repliciation is succeded
    ' 2 - 0 replication is in progress
    ' 1 - Replication can't be started
    ' 0 - Replication error, replication should be repeated
    'Protected Function ReplicateDirectly(ByVal PublicationName As String) As Integer
    '    Return ReplicateSpecific(PublicationName, _
    '                            m_ServiceConfig.UpperLevelServerName, _
    '                            m_ServiceConfig.PublisherDatabase, _
    '                            m_LocalServerName, _
    '                            m_ServiceConfig.SubscriberDatabase)

    'End Function


    'Return results:
    ' 3 - Repliciation is succeded
    ' 2 - 0 replication is in progress
    ' 1 - Replication can't be started
    ' 0 - Replication error, replication should be repeated
    'Protected Function ReplicateSpecific(ByVal PublicationName As String, ByVal ParentServerName As String, ByVal ParentDatabaseName As String, ByVal LocalServerName As String, ByVal DatabaseName As String) As Integer
    '    Dim RetRes As Boolean = True
    '    If Utils.IsEmpty(PublicationName) OrElse Utils.IsEmpty(ParentServerName) OrElse Utils.IsEmpty(ParentDatabaseName) OrElse Utils.IsEmpty(LocalServerName) OrElse Utils.IsEmpty(LocalServerName) Then
    '        Return 1
    '    End If
    '    Dim MC As SQLMERGXLib.SQLMerge = New SQLMERGXLib.SQLMergeClass
    '    AddHandler MC.Status, AddressOf ReplStatus

    '    MC.Publisher = ParentServerName
    '    MC.PublisherDatabase = ParentDatabaseName
    '    MC.Publication = PublicationName
    '    MC.PublisherSecurityMode = SQLMERGXLib.SECURITY_TYPE.DB_AUTHENTICATION
    '    'MC.PublisherNetwork = SQLMERGXLib.NETWORK_TYPE.TCPIP_SOCKETS
    '    'MC.PublisherAddress = m_ServiceConfig.UpperLevelServerNetworkName
    '    MC.PublisherLogin = ServiceConfiguration.UserName
    '    MC.PublisherPassword = ServiceConfiguration.Password

    '    MC.Distributor = ParentServerName
    '    MC.DistributorSecurityMode = SQLMERGXLib.SECURITY_TYPE.DB_AUTHENTICATION
    '    'MC.DistributorNetwork = SQLMERGXLib.NETWORK_TYPE.TCPIP_SOCKETS
    '    'MC.DistributorAddress = m_ServiceConfig.UpperLevelServerNetworkName
    '    MC.DistributorLogin = ServiceConfiguration.UserName
    '    MC.DistributorPassword = ServiceConfiguration.Password

    '    MC.Subscriber = LocalServerName
    '    MC.SubscriberDatabase = DatabaseName
    '    MC.SubscriberSecurityMode = SQLMERGXLib.SECURITY_TYPE.DB_AUTHENTICATION
    '    MC.SubscriberLogin = ServiceConfiguration.UserName
    '    MC.SubscriberPassword = ServiceConfiguration.Password
    '    MC.SubscriptionType = SQLMERGXLib.SUBSCRIPTION_TYPE.PULL
    '    MC.SubscriptionPriorityType = SQLMERGXLib.SUBSCRIPTION_PRIORITY_TYPE.GLOBAL_PRIORITY


    '    Try
    '        Trace.WriteLine(Trace.Kind.Info, "EIDSS_NtfyRplStart: Replication " + PublicationName + " is started")
    '        MC.Initialize()

    '        MC.Run()

    '        RetRes = (MC.ErrorRecords.Count = 0)

    '        MC.Terminate()
    '        Trace.WriteLine(Trace.Kind.Info, "EIDSS_NtfyRplFinished: Replication " + PublicationName + " is finished")
    '        If RetRes Then
    '            Return 3
    '        Else
    '            Return 0
    '        End If
    '    Catch Except As Exception
    '        Trace.WriteLine(Trace.Kind.Error, "EIDSS_Ntfy: Replication " + PublicationName + " is failed", Except)
    '        Return 0
    '    End Try

    '    Return 0
    'End Function


    'Protected Overridable Function ReplStatus(ByVal Message As String, ByVal Percent As Integer) As SQLMERGXLib.STATUS_RETURN_CODE

    'End Function
    'Return results:
    '3 - job is performed successfully
    '2 - job is started already
    '1 - job can't be started by any reason
    '0 - error during job execution
    Private Shared started_job As New Hashtable
    'Public Overridable Function StartJob(ByVal serverName As String, ByVal JobName As String) As Integer
    '    If Utils.IsEmpty(serverName) OrElse Utils.IsEmpty(JobName) Then
    '        Trace.WriteLine(Trace.Kind.Error, "EIDSS_Ntfy: Job " + JobName + " is not started, the server name or job name is not defined")
    '        Return 1
    '    End If
    '    Dim RetRes As Boolean = False
    '    Dim mainServer As Smo.Server = Nothing
    '    Dim mainDatabase As Smo.Database = Nothing
    '    If started_job.ContainsKey(JobName) AndAlso Not started_job(JobName) Is Nothing Then
    '        Trace.WriteLine(Trace.Kind.Error, "EIDSS_Ntfy: Job " + JobName + " is already started on server " + serverName)
    '        Return 2
    '    End If
    '    started_job(JobName) = 1
    '    'TODO: Fix this later
    '    Dim builder As New SqlConnectionStringBuilder()
    '    builder.DataSource = serverName
    '    builder.InitialCatalog = "master"
    '    builder.UserID = ConnectionManager.DefaultInstance.SQLUser ' ServiceConfiguration.UserName
    '    builder.Password = ConnectionManager.DefaultInstance.SQLPassword ' ServiceConfiguration.Password
    '    Dim sqlConn As New System.Data.SqlClient.SqlConnection(builder.ConnectionString)
    '    sqlConn.Open()
    '    Dim mainConnection As New Microsoft.SqlServer.Management.Common.ServerConnection(sqlConn)

    '    Try
    '        mainServer = New Smo.Server(mainConnection)
    '        'If mainServer.JobServer.j <> SQLDMO.SQLDMO_SVCSTATUS_TYPE.SQLDMOSvc_Running Then
    '        '    mainServer.JobServer.Start()
    '        'End If

    '        Dim sqlJob As Smo.Agent.Job = Nothing
    '        For Each job As Smo.Agent.Job In mainServer.JobServer.Jobs
    '            If job.Name = JobName Then
    '                sqlJob = job
    '                Exit For
    '            End If
    '        Next
    '        If Not sqlJob Is Nothing Then
    '            If RunJobSync(sqlJob, Nothing) Then
    '                Trace.WriteLine(Trace.Kind.Info, "EIDSS_Ntfy:  Job " + JobName + " is suceeded.")
    '                Return 3
    '            Else
    '                Return 0
    '            End If
    '        Else
    '            Trace.WriteLine(Trace.Kind.Error, "EIDSS_Ntfy: Job " + JobName + " is not found. on server " + serverName)
    '            Return 1
    '        End If
    '    Catch Except As Exception
    '        Trace.WriteLine(Trace.Kind.Error, "EIDSS_Ntfy: Job " + JobName + " is failed.", Except)
    '        Return 0
    '    Finally
    '        started_job(JobName) = Nothing
    '    End Try
    'End Function

    'Public Shared Function RunJobSync(ByVal sqlJob As Smo.Agent.Job, Optional ByVal IdleHander As EventHandler = Nothing) As Boolean
    '    Dim result As DataTable
    '    Dim nIndex As Integer
    '    Dim nLastStartTime As DateTime
    '    sqlJob.Refresh()
    '    For j As Integer = 0 To sqlJob.JobSteps.Count - 1
    '        Dim [step] As Smo.Agent.JobStep = sqlJob.JobSteps.Item(j)
    '        [step].RetryAttempts = 1
    '    Next
    '    While JobExecutionStatus.Idle = sqlJob.CurrentRunStatus
    '        nLastStartTime = sqlJob.LastRunDate
    '        Try
    '            sqlJob.Start()
    '            Exit While
    '        Catch ex As Exception
    '            Dbg.Debug("job {0} is failed. Source {1}. HiperLink: {2}. {3}", sqlJob.Name, ex.Source, ex.HelpLink, ex.Message)
    '            'Return False
    '        End Try
    '        System.Threading.Thread.Sleep(100)
    '        sqlJob.Refresh()
    '    End While
    '    While (sqlJob.CurrentRunRetryAttempt < 1)
    '        sqlJob.Refresh()
    '        If (nLastStartTime <> sqlJob.LastRunDate) Then
    '            Exit While
    '        End If
    '        If Not IdleHander Is Nothing Then
    '            IdleHander(Nothing, EventArgs.Empty)
    '        End If
    '    End While
    '    result = sqlJob.EnumHistory()
    '    If (Not result Is Nothing) Then
    '        Dim status As JobOutcome
    '        Dim jobName As String
    '        Dim jobMessage As String
    '        While (result.Rows.Count = 0)
    '            If Not IdleHander Is Nothing Then
    '                IdleHander(Nothing, EventArgs.Empty)
    '            End If
    '            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3))
    '        End While
    '        For nIndex = 0 To result.Rows.Count - 1
    '            Dbg.Debug("Job history row {0}", nIndex)
    '            For i As Integer = 0 To result.Columns.Count - 1
    '                Dbg.Debug("{0} - {1}: {2}", i, result.Columns(i).ColumnName, result.Rows(nIndex)(i))
    '            Next

    '            ' Job name
    '            jobName = result.Rows(nIndex)("JobName").ToString
    '            ' Message
    '            jobMessage = result.Rows(nIndex)("Message").ToString
    '            ' Status
    '            status = CType(result.Rows(nIndex)("RunStatus"), JobOutcome)
    '            If status = JobOutcome.Succeeded Then
    '                Exit For
    '            End If
    '            ' Make message
    '            If (status = JobOutcome.Failed OrElse status = 2) Then
    '                Trace.WriteLine(Trace.Kind.Warning, "job {0} is failed. {1} {2}", jobName, jobMessage, status.ToString())
    '                Return False
    '            End If
    '        Next
    '    End If
    '    Return True
    'End Function

    'Public Shared Function IsSqlAgentExist(ByVal cn As SqlClient.SqlConnection) As Boolean
    '    Try
    '        If cn.State <> ConnectionState.Open Then
    '            cn.Open()
    '        End If
    '        Dim mainConnection As New Microsoft.SqlServer.Management.Common.ServerConnection(cn)
    '        Dim server As New Server(mainConnection)
    '        Dim name As String = server.JobServer.Name
    '        Dbg.Debug("job server name:{0}", name)
    '    Catch ex As UnsupportedFeatureException
    '        Dbg.Debug("{0}", ex)
    '        Return False
    '    Catch e As Exception
    '        Dbg.Debug("{0}", e)
    '        Return True
    '    Finally
    '        If cn.State <> ConnectionState.Closed Then
    '            cn.Close()
    '        End If
    '    End Try
    '    Return True
    'End Function

End Class
