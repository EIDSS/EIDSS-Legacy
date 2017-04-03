Imports bv.model.BLToolkit
Imports bv.common
Imports bv.common.Diagnostics
Imports bv.common.Configuration
Imports eidss.model.Core
Imports System.IO
Imports bv.common.Core

Public Class ServiceBase

    Private m_NotificationListenWorker As EmNotifyLstn
    Private m_Subscribed As Boolean = False
    Private m_EventProcessor As EventProcessor
    Private m_ClientID As String
    Private m_ConfigFile As String
    Private m_TymerType As Integer
    Private m_Credentials As ConnectionCredentials
    Private m_TimerServiceAlive As Timers.Timer = Nothing
    Public Delegate Sub DataRowEvent(ByVal sender As Object, ByVal row As DataRow, ByVal objectId As Object)
    Private m_Started As Boolean = False
    Private m_RestartTmr As Timers.Timer
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="enabled"></param>
    ''' <remarks></remarks>
    Private Sub ConnectionsEnabled(ByVal enabled As Boolean)
        If (enabled) Then
            m_NotificationListenWorker.Listen()
            m_EventProcessor.Listen()
        Else
            m_NotificationListenWorker.Stop()
            m_EventProcessor.Stop()
        End If
    End Sub

    Public Sub SubscribeToAllEvents()
        If Not m_Subscribed Then
            Dim tempDb As New EmNotify_DB(m_Credentials, m_ClientID)
            m_Subscribed = tempDb.SubscribeToAllEvents()
            Try
                Dim g As Guid = New Guid(tempDb.ClientID)
            Catch ex As Exception

                Trace.WriteLine(Trace.Kind.Warning, "Incorrect clientID:{0}", Utils.Str(tempDb.ClientID))
            End Try
            tempDb = Nothing
        End If
    End Sub
    'Public ReadOnly Property Connection() As IDbConnection
    '   Get
    '       If Not m_EventProcessor Is Nothing Then
    '           Return m_EventProcessor.Connection
    '       End If
    '       Return Nothing
    '   End Get
    'End Property
    Public ReadOnly Property ServerName() As String
        Get
            Return m_Credentials.SQLServer
        End Get
    End Property
    Private Sub TestConnection()
        Using cn As New SqlClient.SqlConnection(m_Credentials.ConnectionString)
            cn.Open()
            cn.Close()
        End Using
    End Sub
    Private m_LastRestartError As String

    Private m_UpdateMessenger As AUM.UpdateMessenger

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property UpdateMessenger() As AUM.UpdateMessenger
        Get
            Return m_UpdateMessenger
        End Get
    End Property

    Private m_CanRunApplication As Boolean
    Private Const AppCode As String = "ns"

    Public Sub OnTimerServiceAlive(ByVal sender As Object, ByVal e As Timers.ElapsedEventArgs)
        'refresh: service still alive
        If Not UpdateMessenger.CanConnect() Then Return
        UpdateMessenger.CreateRunningApps(EidssUserContext.ClientID, AppCode)
        Dim isNotUpdateNow As Boolean = UpdateMessenger.CanRunApplication(EidssUserContext.ClientID, AppCode)
        If (m_CanRunApplication <> isNotUpdateNow) Then
            ConnectionsEnabled(isNotUpdateNow)
            m_CanRunApplication = isNotUpdateNow
        End If
    End Sub

    Public Sub OnTimerUpdate(ByVal sender As Object, ByVal e As Timers.ElapsedEventArgs)
        'CheckForUpdates()
    End Sub

    Private Sub CheckForUpdates()
        'Check for updates
        Try
            Dim dir As String = Utils.GetExecutingPath()
            Dim updaterFilename As String = Path.Combine(dir, "bvupdater.exe")
            Dim updaterDllFilename As String = Path.Combine(dir, "BVUpdate.dll")
            If File.Exists(updaterFilename) And File.Exists(updaterDllFilename) Then

                Using process As Process = New Process()

                    process.StartInfo = New ProcessStartInfo(updaterFilename)
                    process.StartInfo.Arguments = String.Format("\u \pns \a{0} \c{1} \s:""{2}""", Utils.Str(EidssUserContext.User.ID), EidssUserContext.ClientID, dir)
                    process.StartInfo.CreateNoWindow = True
                    process.StartInfo.ErrorDialog = False
                    process.StartInfo.RedirectStandardError = True
                    process.StartInfo.RedirectStandardInput = True
                    process.StartInfo.RedirectStandardOutput = True
                    process.StartInfo.UseShellExecute = False
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                    process.Start()
                    'do some other things while you wait... 
                    Threading.Thread.Sleep(10000) ' simulate doing other things... 
                    process.StandardInput.WriteLine("exit") 'tell console to exit 
                    If Not (process.HasExited) Then
                        process.WaitForExit(120000) 'give 2 minutes for process to finish 
                        If Not (process.HasExited) Then process.Kill() 'took too long, kill it off 
                    End If
                End Using
            End If

        Catch ex As Exception
            Dbg.Debug("CheckForUpdates {0}", ex.ToString)
        End Try
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="timerType"></param>
    ''' <param name="configFile"></param>
    ''' <remarks></remarks>
    Public Function Start(Optional ByVal timerType As Integer = 0, Optional ByVal configFile As String = Nothing) As Boolean
        SecurityLog.AppName = "EIDSS Notification Service"

        Dim serviceConfig As ServiceConfiguration = Nothing
        Try
            Trace.WriteLine(Trace.Kind.Info, "Notification Service is starting")
            m_ConfigFile = configFile
            m_TymerType = timerType
            m_Credentials = New ConnectionCredentials(configFile)

            serviceConfig = New ServiceConfiguration(configFile)
            serviceConfig.ReadConfiguration()
            TestConnection()
            DbManagerFactory.SetSqlFactory(m_Credentials.ConnectionString)
            If Utils.Str(serviceConfig.ClientID) = "" Then
                m_ClientID = EidssUserContext.ClientID
            Else
                m_ClientID = serviceConfig.ClientID
            End If
            SubscribeToAllEvents()
            m_NotificationListenWorker = New EmNotifyLstn(configFile)
            m_NotificationListenWorker.Listen()
            JobAccessor.Instance = New JobAccessor(m_Credentials.SQLServer, m_Credentials.SQLUser, m_Credentials.SQLPassword)
            Trace.WriteLine(Trace.Kind.Info, "Ntfy_Start: Notification listener is started for database {0}\{1}", m_Credentials.SQLServer, m_Credentials.SQLDatabase)
            m_EventProcessor = New EventProcessor(configFile)
            m_EventProcessor.Listen()

            'AUM messenger init
            m_UpdateMessenger = New AUM.UpdateMessenger(m_Credentials)

            'set record from journal
            If (UpdateMessenger.CanConnect()) Then
                If Not (UpdateMessenger.CanRunApplication(EidssUserContext.ClientID, AppCode)) Then Return False
                UpdateMessenger.CreateRunningApps(EidssUserContext.ClientID, AppCode)
            End If
            m_CanRunApplication = True

            'create timer, which refresh service alive status
            m_TimerServiceAlive = UpdateMessenger.CreateTimerListener()
            AddHandler m_TimerServiceAlive.Elapsed, AddressOf OnTimerServiceAlive
            m_TimerServiceAlive.Start()

            m_Started = True
            EidssUserContext.User.IsAuthenticated = True
            Trace.WriteLine(Trace.Kind.Info, "Notification Service is started successfully")
        Catch ex As Exception
            EidssUserContext.User.IsAuthenticated = False
            Dim actualException As Exception = ex
            If Not ex.InnerException Is Nothing Then
                actualException = ex.InnerException
            End If
            Dim errorText As String
            If TypeOf (actualException) Is SqlClient.SqlException Then
                errorText = CType(actualException, SqlClient.SqlException).ErrorCode.ToString
            Else
                errorText = actualException.Message
            End If
            If m_LastRestartError <> errorText Then
                Trace.WriteLine(Trace.Kind.Error, "Notification Service start fault:", actualException)
                Trace.WriteLine(Trace.Kind.Info, "Notification Service start is not started for database {0}\{1} and user {2}", m_Credentials.SQLServer, m_Credentials.SQLDatabase, m_Credentials.SQLUser)
            Else
                Trace.WriteLine(Trace.Kind.Info, "Notification Service start is not started for database {0}\{1} and user {2}", m_Credentials.SQLServer, m_Credentials.SQLDatabase, m_Credentials.SQLUser)
            End If
            m_LastRestartError = errorText
            Finish()
            m_Started = False
            If m_RestartTmr Is Nothing Then
                m_RestartTmr = New Timers.Timer
            End If
            m_RestartTmr.AutoReset = False
            AddHandler m_RestartTmr.Elapsed, AddressOf RestartProc
            If serviceConfig IsNot Nothing Then
                m_RestartTmr.Interval = serviceConfig.RestartInterval
            Else
                m_RestartTmr.Interval = 30000
            End If
            m_RestartTmr.Start()
        End Try
        Return True
    End Function
    Public Sub Finish()
        ' Add code here to perform any tear-down necessary to stop your service.
        If Not m_NotificationListenWorker Is Nothing Then
            m_NotificationListenWorker.Stop()
        End If
        If Not m_EventProcessor Is Nothing Then
            m_EventProcessor.Stop()
        End If
        If Not m_EventProcessor Is Nothing AndAlso Not m_OnEventOccured Is Nothing Then
            RemoveHandler m_EventProcessor.EventOccured, m_OnEventOccured
        End If
        If Not m_NotificationListenWorker Is Nothing AndAlso Not m_OnNotificationReceived Is Nothing Then
            RemoveHandler m_NotificationListenWorker.NotificationReceived, m_OnNotificationReceived
        End If
        'delete record from journal
        If Not UpdateMessenger Is Nothing Then
            UpdateMessenger.DeleteRunningApps(EidssUserContext.ClientID, AppCode)
        End If
    End Sub
    Private m_OnNotificationReceived As DataRowEvent
    Public Property OnNotificationReceived() As DataRowEvent
        Get
            Return m_OnNotificationReceived
        End Get
        Set(ByVal value As DataRowEvent)
            m_OnNotificationReceived = value
            If Not m_NotificationListenWorker Is Nothing AndAlso Not m_OnNotificationReceived Is Nothing Then
                AddHandler m_NotificationListenWorker.NotificationReceived, m_OnNotificationReceived
            End If
        End Set
    End Property
    Private m_OnEventOccured As DataRowEvent

    Public Property OnEventOccured() As DataRowEvent
        Get
            Return m_OnEventOccured
        End Get
        Set(ByVal value As DataRowEvent)
            m_OnEventOccured = value
            If Not m_EventProcessor Is Nothing AndAlso Not m_OnEventOccured Is Nothing Then
                AddHandler m_EventProcessor.EventOccured, m_OnEventOccured
            End If
        End Set
    End Property

    Public Sub SkipExistingEvents()
        If Not m_EventProcessor Is Nothing Then
            m_EventProcessor.SkipExistingEvents()
        End If
    End Sub
    Private Sub RestartProc(ByVal sender As Object, ByVal e As Timers.ElapsedEventArgs)
        RemoveHandler CType(sender, Timers.Timer).Elapsed, AddressOf RestartProc
        If m_Started Then
            Return
        End If
        CType(sender, Timers.Timer).Stop()
        MemoryManager.Flush(True)
        EidssUserContext.User.IsAuthenticated = False
        Start(m_TymerType, m_ConfigFile)
    End Sub


End Class
