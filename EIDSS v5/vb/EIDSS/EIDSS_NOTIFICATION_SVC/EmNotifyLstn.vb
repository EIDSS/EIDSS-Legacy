Imports bv.common
Imports bv.common.db
Imports bv.common.db.Core
Imports bv.common.Core
Imports bv.common.Configuration
Imports System.Timers

Public Class EmNotifyLstn

    Protected m_ServiceConfig As ServiceConfiguration
    Protected m_DbService As EmNotify_DB
    Protected m_WaitingRequestsQueue As New Hashtable
    Public Event NotificationReceived As ServiceBase.DataRowEvent
    Protected m_EventLog As EIDSS_EventLog
    Private ReadOnly m_ConfigFileName As String
    '  Private m_NotificationManager As NotificationManager
    Private ReadOnly m_SiteType As SiteType
    Private ReadOnly m_Credentials As ConnectionCredentials
    Private ReadOnly m_ConfigWriter As ConfigWriter
    Private m_NotificationListenTmr As Timers.Timer
    Protected m_FiltrationTimer As Timers.Timer

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
        If (m_ConfigFileName Is Nothing) Then
            m_ConfigWriter = ConfigWriter.Instance
        Else
            m_ConfigWriter = New ConfigWriter
        End If
        m_ServiceConfig = New ServiceConfiguration(configFile)
        m_ServiceConfig.ReadConfiguration()
        'm_NotificationManager = New NotificationManager(m_Credentials, m_ServiceConfig)

        m_DbService = New EmNotify_DB(m_Credentials, m_ServiceConfig.ClientID)
        m_EventLog = New EIDSS_EventLog(m_Credentials, m_ServiceConfig.ClientID)
        Dim siteService As Object = ClassLoader.LoadClass("EIDSS_SiteService")
        siteService.GetType.GetProperty("SiteConnection").SetValue(siteService, m_DbService.Connection, Nothing)
        m_SiteType = CType(siteService.GetType.GetMethod("GetSiteTypeEnum").Invoke(siteService, Nothing), SiteType)
    End Sub

    Public Sub Listen()
        If m_NotificationListenTmr Is Nothing Then
            m_NotificationListenTmr = New Timers.Timer
        End If
        m_NotificationListenTmr.AutoReset = False
        AddHandler m_NotificationListenTmr.Elapsed, AddressOf WorkerProc
        m_NotificationListenTmr.Interval = m_ServiceConfig.PollRate
        m_NotificationListenTmr.Start()
        Trace.WriteLine(Trace.Kind.Info, "Ntfy_Start: Notify listener is started on database {0}.", m_Credentials.SQLDatabase)
        If m_FiltrationTimer Is Nothing Then
            m_FiltrationTimer = New Timers.Timer
        End If
        m_FiltrationTimer.AutoReset = False
        AddHandler m_FiltrationTimer.Elapsed, AddressOf FiltrationProc
        m_FiltrationTimer.Interval = 10
        m_FiltrationTimer.Start()
        Trace.WriteLine(Trace.Kind.Info, "Filtration timer is started with interval {0}.", m_ServiceConfig.FiltrationInterval.ToString)
    End Sub
    Public FiltrationRecalcCount As Integer = 0
    Private Sub FiltrationProc(ByVal sender As Object, ByVal e As ElapsedEventArgs)
        CType(sender, Timers.Timer).Stop()
        Try
            Dim controller As New ReplicationController(m_Credentials, m_ConfigFileName)
            controller.CheckFiltration()
            FiltrationRecalcCount += 1
        Catch ex As Exception
            Trace.WriteLine(Trace.Kind.Error, "FiltrationProc", ex)
        Finally
            CType(sender, Timers.Timer).Interval = m_ServiceConfig.FiltrationInterval
            CType(sender, Timers.Timer).Start()
        End Try
    End Sub

    Public Sub [Stop]()
        If Not m_NotificationListenTmr Is Nothing Then m_NotificationListenTmr.Stop()
        Trace.WriteLine(Trace.Kind.Info, "Ntfy_Start: Notify listener is stopped on database {0}.", m_Credentials.SQLDatabase)
        If Not m_FiltrationTimer Is Nothing Then m_FiltrationTimer.Stop()
        Trace.WriteLine(Trace.Kind.Info, "Filtration  timer is stopped")
    End Sub
    Private m_LastFiltrationTime As New DateTime(1900, 1, 1)
    Private Sub WorkerProc(ByVal sender As Object, ByVal e As Timers.ElapsedEventArgs)
        CType(sender, Timers.Timer).Stop()
        Try
            'Ping()
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

        Dim postResult As Boolean = False
        Dim shouldTransitNotification As Boolean = False
        TraceMe("Ntfy_ProcessNotification:" & ds.Tables("Notification").Rows.Count & " notification received on database " & m_Credentials.SQLDatabase)
        For Each row In ds.Tables("Notification").Rows
            If ShouldProcess(row) Then
                postResult = True
                Dim ntfyType As NotificationType = CType(row("idfsNotificationType"), NotificationType)
                If Not row.IsNull("strPayload") Then
                    TraceMe("Ntfy_ProcessNotification: Data to post is received id={0}.", CStr(row("strPayload")))
                    Select Case ntfyType
                        Case NotificationType.HumanCase, NotificationType.VetCase, NotificationType.Outbreak, NotificationType.AVRLayoutUpdate, _
                                NotificationType.CaseDiagnosisChangedNotification, NotificationType.CaseStatusChangedNotification, _
                                NotificationType.TestAmendment, NotificationType.TestResultsReceived
                            postResult = Not row.IsNull("idfNotificationObject")
                        Case NotificationType.ReferenceTableChanged
                            postResult = Not row.IsNull("strPayload")
                    End Select
                Else
                    TraceMe("Ntfy_ProcessNotification:No data to post. Notification type is {0}.", ntfyType.ToString)
                End If
                If postResult Then
                    CreateReceiveEvent(row)
                End If
            End If
            If ShouldTransit(row) Then
                shouldTransitNotification = True
            End If
        Next
        If shouldTransitNotification Then
            Dim controller As New ReplicationController(m_Credentials, m_ConfigFileName)
            controller.StartCompleteReplication()
        End If

    End Sub

    Protected Function ShouldTransit(ByVal notificationRow As DataRow) As Boolean
        If CLng(notificationRow("idfsNotificationType")) = CLng(NotificationType.ReferenceTableChanged) _
                OrElse CLng(notificationRow("idfsNotificationType")) = CLng(NotificationType.SettlementChanged) _
                OrElse CLng(notificationRow("idfsNotificationType")) = CLng(NotificationType.AVRLayoutUpdate) Then
            Return False
        End If
        If (notificationRow("idfsTargetSiteType") Is DBNull.Value AndAlso notificationRow("idfsTargetSite") Is DBNull.Value) Then
            Return True
        End If
        If Not notificationRow("idfsTargetSiteType") Is DBNull.Value AndAlso notificationRow("idfsTargetSiteType").Equals(CLng(m_SiteType)) Then
            Return False
        End If
        If (Not notificationRow("idfsTargetSite") Is DBNull.Value AndAlso m_DbService.SiteID.Equals(notificationRow("idfsTargetSite"))) Then
            Return False
        End If
        Return True
    End Function

    Protected Function ShouldProcess(ByVal notificationRow As DataRow) As Boolean
        If m_DbService.SiteID.Equals(notificationRow("idfsSite")) OrElse notificationRow("intProcessed").Equals(1) Then
            Return False
        End If
        If (notificationRow("idfsTargetSiteType") Is DBNull.Value AndAlso notificationRow("idfsTargetSite") Is DBNull.Value) Then
            Return True
        End If
        If Not notificationRow("idfsTargetSiteType") Is DBNull.Value AndAlso notificationRow("idfsTargetSiteType").Equals(CLng(m_SiteType)) Then
            Return True
        End If
        If (Not notificationRow("idfsTargetSite") Is DBNull.Value AndAlso m_DbService.SiteID.Equals(notificationRow("idfsTargetSite"))) Then
            Return True
        End If
        Return False
    End Function

    Protected Overridable Sub CreateReceiveEvent(ByVal notificationRow As DataRow)
        Dim objectID As Long = 0
        Dim ntfyType As NotificationType = CType(notificationRow("idfsNotificationType"), NotificationType)
        If (notificationRow("idfsTargetSiteType") Is DBNull.Value AndAlso notificationRow("idfsTargetSite") Is DBNull.Value) OrElse _
            (Not notificationRow("idfsTargetSiteType") Is DBNull.Value AndAlso notificationRow("idfsTargetSiteType").Equals(CLng(m_SiteType))) OrElse _
            (Not notificationRow("idfsTargetSite") Is DBNull.Value AndAlso m_DbService.SiteID.Equals(notificationRow("idfsTargetSite"))) _
            Then
            If Not notificationRow.IsNull("idfNotificationObject") Then
                objectID = CLng(notificationRow("idfNotificationObject"))
            End If

            Select Case ntfyType
                Case NotificationType.HumanCase
                    If objectID > 0 Then
                        m_EventLog.CreateEvent(EventType.HumanCaseNotification, objectID)
                        RaiseEvent NotificationReceived(m_Credentials.SQLServer, notificationRow, objectID)
                    End If
                Case NotificationType.VetCase
                    If objectID > 0 Then
                        m_EventLog.CreateEvent(EventType.VetCaseNotification, objectID)
                        RaiseEvent NotificationReceived(m_Credentials.SQLServer, notificationRow, objectID)
                    End If
                Case NotificationType.Outbreak
                    If objectID > 0 Then
                        m_EventLog.CreateEvent(EventType.OutbreakNotificationReceived, objectID)
                        RaiseEvent NotificationReceived(m_Credentials.SQLServer, notificationRow, objectID)
                    End If
                Case NotificationType.CaseDiagnosisChangedNotification
                    If objectID > 0 Then
                        m_EventLog.CreateEvent(EventType.CaseDiseaseChangedNotification, objectID)
                        RaiseEvent NotificationReceived(m_Credentials.SQLServer, notificationRow, objectID)
                    End If
                Case NotificationType.CaseStatusChangedNotification
                    If objectID > 0 Then
                        m_EventLog.CreateEvent(EventType.CaseStatusChangedNotification, objectID)
                        RaiseEvent NotificationReceived(m_Credentials.SQLServer, notificationRow, objectID)
                    End If
                Case NotificationType.TestResultsReceived
                    If objectID > 0 Then
                        m_EventLog.CreateEvent(EventType.TestResultsReceived, objectID)
                        RaiseEvent NotificationReceived(m_Credentials.SQLServer, notificationRow, objectID)
                    End If
                Case NotificationType.TestAmendment
                    If objectID > 0 Then
                        m_EventLog.CreateEvent(EventType.TestAmendmentNotification, objectID)
                        RaiseEvent NotificationReceived(m_Credentials.SQLServer, notificationRow, objectID)
                    End If
                Case NotificationType.ReferenceTableChanged
                    Dim lookupTable As String = Utils.Str(notificationRow("strPayLoad"))
                    If lookupTable <> "" Then
                        m_EventLog.CreateProcessedEvent(EventType.ReferenceTableChanged, lookupTable, 1)
                    End If
                Case NotificationType.AVRLayoutUpdate
                    If Not MakeAVRLayoutLocal(objectID) Then
                        Exit Sub
                    End If
                Case NotificationType.SettlementChanged
                    ProcessSettlement(objectID)
                Case Else
                    RaiseEvent NotificationReceived(m_Credentials.SQLServer, notificationRow, objectID)
            End Select
            TraceMe("Ntfy_CreateReceiveEvent: Notification Event of type {0} for object {1} for notification {2} is created", ntfyType.ToString, Utils.Str(objectID), CStr(notificationRow("idfNotification")))
        End If
        m_DbService.MarkProcessed(CType(notificationRow("idfNotification"), Long))
    End Sub

    Private Sub ProcessSettlement(ByVal settlementID As Long)
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
            Catch ex As Exception
                TraceMe("ProcessSettlement: error during settlement updating, settlement id = {0}, error : {1}", settlementID.ToString, ex.ToString)
            Finally
                If Not transaction Is Nothing Then
                    If Not transaction.Connection Is Nothing Then
                        transaction.Rollback()
                    End If
                    transaction = Nothing
                    If cmd.Connection.State <> ConnectionState.Closed Then
                        cmd.Connection.Close()
                    End If
                End If
            End Try
        End SyncLock
    End Sub

    Private Function MakeAVRLayoutLocal(ByVal layoutID As Long) As Boolean
        Dim cmd As IDbCommand = m_DbService.CreateSPCommand("spAsLayoutMakeLocal")
        StoredProcParamsCache.CreateParameters(cmd)
        BaseDbService.SetParam(cmd, "@idfsLayout", layoutID)
        'Trnasaction is commented because it is called inside procedure
        'Dim transaction As IDbTransaction = Nothing  
        SyncLock Connection
            If Connection.State <> ConnectionState.Open Then
                Connection.Open()
            End If
            'transaction = Connection.BeginTransaction
            Try
                'cmd.Transaction = transaction
                cmd.ExecuteNonQuery()
                Dim result As Integer = CInt(BaseDbService.GetParamValue(cmd, "@RETURN_VALUE"))
                If result = 0 Then
                    'transaction.Commit()
                    'transaction = Nothing
                    Return True
                End If
            Catch ex As Exception
                TraceMe("MakeAVRLayoutLocal: error during layout publishing, layout id = {0}, error : {1}", layoutID.ToString, ex.ToString)

                Return False
            Finally
                'If Not transaction Is Nothing Then
                '    If Not transaction.Connection Is Nothing Then
                '        transaction.Rollback()
                '    End If
                '    transaction = Nothing
                If cmd.Connection.State <> ConnectionState.Closed Then
                    cmd.Connection.Close()
                End If
                'End If
            End Try
        End SyncLock

    End Function

    ' Dim rExp As New Regex("Data\s+Source\s*\=(?<server>[()a-zA-Z0-9]+)[;]*", Text.RegularExpressions.RegexOptions.IgnoreCase)
    Private ReadOnly Property Server() As String
        Get
            If Not m_DbService.Connection Is Nothing Then
                Return CType(m_DbService.Connection, SqlClient.SqlConnection).DataSource
            Else
                Return ""
            End If
        End Get
    End Property
    Private Sub TraceMe(ByVal message As String, ByVal ParamArray params() As String)
        Trace.WriteLine(Trace.Kind.Info, String.Format("Server " & Server & "-" & message, params))
    End Sub
    'Private m_lastPingTime As DateTime = DateTime.Now
    'Private pingInterval As Integer = 0
    'Private pingAddress As String
    'Private pingWritToLog As Boolean = False

    'Private Sub Ping()
    '    Try
    '        If pingInterval = 0 Then
    '            Try
    '                pingInterval = Integer.Parse(m_ConfigWriter.GetItem("PingInterval"))
    '            Catch ex As Exception
    '                pingInterval = 200
    '            End Try
    '            pingAddress = m_ConfigWriter.GetItem("PingAddress")
    '            If m_ConfigWriter.GetItem("PingWriteToLog").ToLowerInvariant = "true" Then
    '                pingWritToLog = True
    '            End If
    '        End If
    '        If Utils.Str(pingAddress) = "" Then
    '            Return
    '        End If

    '        If DateTime.Now.Subtract(m_lastPingTime).TotalSeconds > pingInterval Then

    '            If pingWritToLog Then
    '                Trace.WriteLine(Trace.Kind.Info, "pinging website " + pingAddress + "...")
    '            End If
    '            Dim siteUri As New System.Uri(pingAddress)
    '            Dim webRequest As System.Net.HttpWebRequest = _
    '                CType(System.Net.WebRequest.Create(siteUri), System.Net.HttpWebRequest)
    '            webRequest.CookieContainer = Nothing
    '            'webRequest.KeepAlive = False
    '            'webRequest.Proxy = New System.Net.WebProxy("YourProxySetting")
    '            Dim webResponse As System.Net.HttpWebResponse = CType(webRequest.GetResponse(), System.Net.HttpWebResponse)
    '            'webResponse.Cookies = Nothing
    '            If pingWritToLog Then
    '                Trace.WriteLine(Trace.Kind.Info, "web response status: " + webResponse.StatusCode.ToString)
    '            End If
    '            webResponse.Close()

    '            m_lastPingTime = DateTime.Now
    '        End If
    '    Catch ex As Exception
    '        Trace.WriteLine("ping error:", ex)
    '    End Try
    'End Sub
End Class
