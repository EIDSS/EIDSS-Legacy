Imports System.Reflection
Imports bv.common.db.Core
Imports System.Threading
Imports bv.common.Core
Imports bv.common.Configuration
Imports bv.common.Diagnostics

Public Class EIDSS_EventLog
    Implements bv.common.Core.IEventLog
    Private EventDbService As Object
    'Private EventTimer As System.Windows.Forms.Timer
    'Private s_EventTimer As System.Timers.Timer
    Private timer As System.Threading.Timer

    Private m_ClientID As String
    Public Shared Wait As Boolean
    Public Shared m_Instance As EIDSS_EventLog
    Public Shared ReadOnly Property Instance() As EIDSS_EventLog
        Get
            If m_Instance Is Nothing Then
                m_Instance = New EIDSS_EventLog
            End If
            Return m_Instance
        End Get
    End Property
    'Dim m_timerType As Integer = 0
    'Public Property TimerType() As Integer
    '    Get
    '        Return m_timerType
    '    End Get
    '    Set(ByVal Value As Integer)
    '        m_timerType = Value
    '    End Set
    'End Property
    Public Sub New(Optional ByVal credentials As ConnectionCredentials = Nothing, Optional ByVal clientID As String = Nothing)
        EventDbService = ClassLoader.LoadClass("Event_DB")
        If Not clientID Is Nothing Then
            Dim pi As PropertyInfo = EventDbService.GetType().GetProperty("ClientID", BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.Static)
            pi.SetValue(EventDbService, clientID, Nothing)
            m_ClientID = clientID
        End If

        If Not credentials Is Nothing Then
            Dim mi As MethodInfo = GetDbServiceMethod("NewConnection")
            mi.Invoke(EventDbService, New Object() {credentials.SQLServer, credentials.SQLDatabase, credentials.SQLUser, credentials.SQLPassword, credentials.SQLConnectionString})
        End If
        'Dim siteID As String = EIDSS.model.Core.EidssSiteContext.Instance.SiteID
    End Sub
    Private Const delayInterval As Integer = 500
    Private Const periodInterval As Integer = 500
    Public Sub Listen()
        If timer Is Nothing Then
            timer = New System.Threading.Timer(New TimerCallback(AddressOf CheckEvents), Nothing, 0, 0)
        End If
        timer.Change(delayInterval, periodInterval)

        'If m_timerType = 1 Then
        '    If EventTimer Is Nothing Then
        '        EventTimer = New System.Windows.Forms.Timer
        '        EventTimer.Stop()
        '        EventTimer.Interval = ListenInterval
        '        AddHandler EventTimer.Tick, AddressOf Timer_Elapsed
        '    End If
        '    EventTimer.Start()
        'Else
        '    If s_EventTimer Is Nothing Then
        '        s_EventTimer = New System.Timers.Timer
        '        s_EventTimer.Stop()
        '        s_EventTimer.Interval = ListenInterval
        '        AddHandler s_EventTimer.Elapsed, AddressOf Timer_Elapsed
        '    End If
        '    s_EventTimer.Start()
        'End If

    End Sub
    Public Sub [Stop]()
        'If m_timerType = 1 Then
        '    EventTimer.Stop()
        '    RemoveHandler EventTimer.Tick, AddressOf Timer_Elapsed
        '    EventTimer.Dispose()
        '    EventTimer = Nothing
        'Else
        '    s_EventTimer.Stop()
        '    RemoveHandler s_EventTimer.Elapsed, AddressOf Timer_Elapsed
        '    s_EventTimer.Dispose()
        '    s_EventTimer = Nothing
        'End If
        timer.Change(Timeout.Infinite, Timeout.Infinite)
    End Sub

    Public Event EventOccured(ByVal dt As DataTable)
    Private Function GetDbServiceMethod(ByVal methodName As String) As MethodInfo
        If EventDbService Is Nothing Then
            EventDbService = ClassLoader.LoadClass("Event_DB")
        End If
        If Not EventDbService Is Nothing Then
            Dim mi As MethodInfo = EventDbService.GetType().GetMethod(methodName, BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.Static)
            Return mi
        End If
        Return Nothing
    End Function
    Private Function GetDbServiceProperty(ByVal propertyName As String) As PropertyInfo
        If EventDbService Is Nothing Then
            EventDbService = ClassLoader.LoadClass("Event_DB")
        End If
        If Not EventDbService Is Nothing Then
            Dim pi As PropertyInfo = EventDbService.GetType().GetProperty(propertyName, BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.Static)
            Return pi
        End If
        Return Nothing
    End Function
    Public Function IsSubscribed() As Boolean
        Dim mi As MethodInfo = GetDbServiceMethod("IsSubscribed")
        Return CType(mi.Invoke(EventDbService, Nothing), Boolean)
    End Function
    Public Function SubscribeToAllEvents() As Boolean
        Dim mi As MethodInfo = GetDbServiceMethod("SubscribeToAllEvents")
        Return CType(mi.Invoke(EventDbService, Nothing), Boolean)
    End Function
    Public Function CreateEvent(ByVal EventTypeID As System.Enum, ByVal ObjectID As Object, Optional ByVal UserID As Object = Nothing, Optional ByVal transaction As System.Data.IDbTransaction = Nothing) As Object Implements bv.common.Core.IEventLog.CreateEvent
        Dim mi As MethodInfo = GetDbServiceMethod("CreateEvent")
        Return mi.Invoke(EventDbService, New Object() {EventTypeID, ObjectID, UserID, transaction})
    End Function

    Public Function CreateProcessedEvent(ByVal EventTypeID As System.Enum, ByVal ObjectID As Object, ByVal Processed As Integer, Optional ByVal UserID As Object = Nothing, Optional ByVal transaction As System.Data.IDbTransaction = Nothing) As Object Implements bv.common.Core.IEventLog.CreateProcessedEvent
        Dim mi As MethodInfo = GetDbServiceMethod("CreateProcessedEvent")
        Return mi.Invoke(EventDbService, New Object() {EventTypeID, ObjectID, Processed, UserID, transaction})
    End Function

    Public Function MarkAsProcessed(ByVal EventID As Object, Optional ByVal transaction As IDbTransaction = Nothing) As Object
        Dim mi As MethodInfo = GetDbServiceMethod("MarkAsProcessed")
        Return mi.Invoke(EventDbService, New Object() {EventID, transaction})
    End Function

    Public Function MarkAsProcessedBatch(ByVal EventTypeID As System.Enum, Optional ByVal transaction As IDbTransaction = Nothing) As Object
        Dim mi As MethodInfo = GetDbServiceMethod("MarkAsProcessedBatch")
        Return mi.Invoke(EventDbService, New Object() {EventTypeID, transaction})
    End Function

    Public Function WaitForProcessing(ByVal EventID As Object, Optional ByVal IdleHandler As EventHandler = Nothing) As Boolean
        Dim mi As MethodInfo = GetDbServiceMethod("WaitForProcessing")
        Return CType(mi.Invoke(EventDbService, New Object() {EventID, IdleHandler}), Boolean)
    End Function
    Public Function CreateEventAndWait(ByVal et As EventType, ByVal ObjectID As Object, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        Dim mi As MethodInfo = GetDbServiceMethod("CreateEvent")
        Dim id As Object = mi.Invoke(EventDbService, New Object() {et, ObjectID, transaction})
        If id Is Nothing Then
            Return False
        End If
    End Function

    Public Function CreateEventForNewRecord(ByVal et As EventType, ByVal dt As DataTable, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If (Not dt.Rows Is Nothing AndAlso dt.Rows.Count > 0 AndAlso dt.Rows(0).RowState = DataRowState.Added) Then
            Dim ObjectID As Object
            If dt.PrimaryKey.Length = 1 Then
                ObjectID = dt.Rows(0)(dt.PrimaryKey(0).ColumnName)
                Return Not CreateEvent(et, ObjectID, transaction) Is Nothing
            End If
        End If
        Return False
    End Function

    Private Shared m_ListenInterval As Integer = 5000
    Public Shared Property ListenInterval() As Integer
        Get
            Return m_ListenInterval
        End Get
        Set(ByVal Value As Integer)
            m_ListenInterval = Value
        End Set
    End Property


    Function GetEvents() As DataTable
        Dim mi As MethodInfo = GetDbServiceMethod("GetClientEvents")
        Dim dt As Object = mi.Invoke(EventDbService, Nothing)
        Return CType(dt, DataTable)
    End Function
    Public Property IsNotificationService() As Boolean
        Get
            Dim pi As PropertyInfo = GetDbServiceProperty("IsNotificationService")
            Return CType(pi.GetValue(EventDbService, Nothing), Boolean)
        End Get
        Set(ByVal value As Boolean)
            Dim pi As PropertyInfo = GetDbServiceProperty("IsNotificationService")
            pi.SetValue(EventDbService, value, Nothing)
        End Set
    End Property
    Private Sub CheckEvents(ByVal state As [Object])
        timer.Change(Timeout.Infinite, Timeout.Infinite)
        Try
            Dim dt As DataTable = GetEvents()
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                RaiseEvent EventOccured(dt)
            End If
        Catch ex As Exception
            Dbg.WriteLine("error during event checking: {0}", ex.ToString())
        Finally
            timer.Change(delayInterval, periodInterval)
        End Try

    End Sub

    'Sub Timer_Elapsed(ByVal sender As Object, ByVal e As System.EventArgs)

    '    Try
    '        EventTimer.Stop()
    '        Dim dt As DataTable = GetEvents()
    '        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
    '            RaiseEvent EventOccured(dt)
    '        End If
    '    Catch ex As Exception
    '        Throw
    '    Finally
    '        If Not EventTimer Is Nothing Then
    '            EventTimer.Start()
    '        End If
    '    End Try
    'End Sub

    'Sub Timer_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)
    '    Try
    '        s_EventTimer.Stop()
    '        Dim dt As DataTable = GetEvents()
    '        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
    '            RaiseEvent EventOccured(dt)
    '        End If
    '    Catch ex As Exception
    '        Throw
    '    Finally
    '        If Not s_EventTimer Is Nothing Then
    '            s_EventTimer.Start()
    '        End If
    '    End Try
    'End Sub
    Public ReadOnly Property Connection() As IDbConnection
        Get
            If Not EventDbService Is Nothing Then
                Dim pi As PropertyInfo = EventDbService.GetType().GetProperty("Connection", BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.Static)
                Dim cn As Object = pi.GetValue(EventDbService, Nothing)
                If Not cn Is Nothing Then
                    Return CType(cn, IDbConnection)
                End If
            End If
            Return Nothing
        End Get
    End Property

    Public Sub CheckNotificationService(Optional ByVal transaction As System.Data.IDbTransaction = Nothing) Implements bv.common.Core.IEventLog.CheckNotificationService
        Dim mi As MethodInfo = GetDbServiceMethod("CheckNotificationService")
        mi.Invoke(EventDbService, New Object() {transaction})
    End Sub

    Public Sub StartReplication() Implements bv.common.Core.IEventLog.StartReplication
        CreateEvent(EventType.ReplicationRequestedByUser, Nothing)
    End Sub
End Class
