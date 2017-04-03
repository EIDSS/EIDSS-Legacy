Imports System.Data
Imports System.Data.Common
Imports bv.common
Imports System.Data.SqlClient
Imports System.Threading

Public Class Event_DB
    Inherits BaseDbService
    Private m_ClientID As String
    Public Sub New()
        ObjectName = "Event"
        m_ClientID = EIDSS.model.Core.EidssUserContext.ClientID
    End Sub
    Public Property ClientID() As String
        Get
            If m_ClientID Is Nothing Then
                m_ClientID = EIDSS.model.Core.EidssUserContext.ClientID
            End If
            Return m_ClientID
        End Get
        Set(ByVal Value As String)
            m_ClientID = Value
        End Set
    End Property
    Private m_IsNotificationService As Boolean = False
    Public Property IsNotificationService() As Boolean
        Get
            Return m_IsNotificationService
        End Get
        Set(ByVal value As Boolean)
            m_IsNotificationService = value
        End Set
    End Property
    Const MaxTraceFrequency As Integer = 100
    Dim traceFrequency As Integer = MaxTraceFrequency

    Public Function GetClientEvents() As DataTable
        Try
            Dim dt As New DataTable
            dt.TableName = "EventLog"
            If traceFrequency >= MaxTraceFrequency Then
                Trace.WriteLine(Trace.Kind.Info, String.Format("receiving new events...  Database {0}", Connection.Database))
            End If
            Dim cmd As IDbCommand = CreateSPCommand("spEventLog_SelectNewEvents")
            AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
            AddParam(cmd, "@ClientID", m_ClientID)
            AddParam(cmd, "@IsNotificationClient", IIf(m_IsNotificationService, 1, 0))
            Dim da As DbDataAdapter = CreateAdapter(cmd)
            SyncLock cmd.Connection
                da.Fill(dt)
            End SyncLock
            If traceFrequency >= MaxTraceFrequency Then
                Trace.WriteLine(Trace.Kind.Info, String.Format("{0} events is received. Database {1}.", dt.Rows.Count, Connection.Database))
            End If
            traceFrequency += 1
            If traceFrequency >= MaxTraceFrequency Then
                traceFrequency = 0
            End If
            Return dt
        Catch ex As Exception
            Trace.WriteLine(Trace.Kind.Error, "error during client events receiving:", ex)
            Return Nothing
        End Try
    End Function

    Public Function CreateEvent(ByVal et As EventType, ByVal ObjectID As Object, Optional ByVal userID As Object = Nothing, Optional ByVal transaction As IDbTransaction = Nothing) As Object
        Return CreateProcessedEvent(et, ObjectID, 0, transaction)
    End Function
    Private Function EventObjectExists(ByVal et As EventType, ByVal ObjectID As Object, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        Select Case et
            Case EventType.ReferenceTableChanged, _
                    EventType.NotificationServiceIsNotRunning, _
                    EventType.NotificationReplicationRequest, _
                    EventType.OutbreakNotificationFail, _
                    EventType.OutbreakNotificationRetrying, _
                    EventType.OutbreakNotificationSending, _
                    EventType.OutbreakNotificationSucceeded, _
                    EventType.ReplicationFailed, _
                    EventType.ReplicationRequestedByUser, _
                    EventType.ReplicationRetrying, _
                    EventType.ReplicationStarted, _
                    EventType.ReplicationSucceeded, _
                    EventType.ClientUILanguageChanged
                Return True
            Case Else
                If Utils.IsEmpty(ObjectID) OrElse Not TypeOf (ObjectID) Is Long Then
                    Return True
                End If
                Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spEventLog_EventForObjectExists", ConnectionManager.DefaultInstance.Connection)
                BaseDbService.AddParam(cmd, "@idfsEventTypeID", CLng(et))
                BaseDbService.AddParam(cmd, "@idfObject", ObjectID)
                BaseDbService.AddTypedParam(cmd, "@RETURN_VALUE", SqlDbType.Int, ParameterDirection.ReturnValue)
                Try
                    BaseDbService.ExecCommand(cmd, cmd.Connection, transaction, True)
                Catch ex As Exception
                    Dbg.Debug("error during event [{0}] object check [{1}]: {2}", et.ToString, ObjectID, ex.ToString)
                    Dbg.Debug("    Connection: {0}\{1}, Thread {2}\{3} ", CType(cmd.Connection, SqlConnection).DataSource, cmd.Connection.Database, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.GetHashCode())
                    If Not ex.InnerException Is Nothing Then
                        Dbg.Debug("    Inner exception {0}", ex.InnerException.ToString)
                    End If
                    Return True
                End Try
                If Utils.Str(BaseDbService.GetParamValue(cmd, "@RETURN_VALUE")) = "1" Then
                    Return True
                End If
                Return False
        End Select
    End Function


    Public Function CreateProcessedEvent(ByVal et As EventType, ByVal ObjectID As Object, ByVal Processed As Integer, Optional ByVal userID As Object = Nothing, Optional ByVal transaction As IDbTransaction = Nothing) As Object
        If Not EventObjectExists(et, ObjectID) Then
            Return Nothing
        End If
        Dim cmd As IDbCommand = CreateSPCommand("spEventLog_CreateNewEvent")
        AddParam(cmd, "@idfsEventTypeID", CLng(et))
        If TypeOf ObjectID Is String Then
            AddParam(cmd, "@idfObjectID", DBNull.Value)
            AddParam(cmd, "@strInformationString", Utils.Str(ObjectID))
        Else
            AddParam(cmd, "@idfObjectID", ObjectID)
            AddParam(cmd, "@strInformationString", GetEventDescription(et))
        End If
        AddParam(cmd, "@strNote", GetEventNotes(et))
        AddParam(cmd, "@ClientID", m_ClientID)
        AddParam(cmd, "@intProcessed", Processed)
        If Utils.IsEmpty(userID) Then
            AddTypedParam(cmd, "@idfUserID", SqlDbType.BigInt)
        Else
            AddParam(cmd, "@idfUserID", userID)
        End If
        AddTypedParam(cmd, "@EventID", SqlDbType.BigInt, ParameterDirection.InputOutput)
        m_Error = ExecCommand(cmd, Connection, transaction)
        Trace.WriteLine(Trace.Kind.Info, "Event_DB(clientID {2}):" + "Creating new event of type {0} for object {1}", et.ToString, Utils.Str(ObjectID), EIDSS.model.Core.EidssUserContext.ClientID)
        If m_Error Is Nothing Then
            If (et = EventType.NotificationReplicationRequest OrElse et = EventType.ReplicationRequestedByUser) _
                    AndAlso EIDSS.model.Core.EidssSiteContext.Instance.SiteType <> SiteType.CDR Then
                CheckNotificationService(transaction)
            End If
            Return GetParam(cmd, "@EventID")
        End If
        Return Nothing
    End Function

    Public Sub CheckNotificationService(Optional ByVal transaction As IDbTransaction = Nothing)
        Dim cmd1 As IDbCommand = CreateSPCommand("spEventLog_IsNtfyServiceRunning")
        AddParam(cmd1, "@idfsClient", m_ClientID)
        ExecCommand(cmd1, Connection, transaction)
    End Sub
    Public Function MarkAsProcessed(ByVal EventID As Long, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        Dim cmd As IDbCommand = CreateSPCommand("spEventLog_MarkAsProcessed")
        AddParam(cmd, "@idfsEvent", EventID)
        m_Error = ExecCommand(cmd, Connection, transaction)
        If Not m_Error Is Nothing Then
            Trace.WriteLine(Trace.Kind.Error, "spEventLog_MarkAsProcessed failed:" + m_Error.DetailError)
            Return False
        End If
        Return True
    End Function

    Public Function MarkAsProcessedBatch(ByVal EventTypeID As Long, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        Dim cmd As IDbCommand = CreateSPCommand("spEventLog_MarkAsProcessedBatch")
        AddParam(cmd, "@idfsEventTypeID", EventTypeID)
        m_Error = ExecCommand(cmd, Connection, transaction)
        If Not m_Error Is Nothing Then
            Trace.WriteLine(Trace.Kind.Error, "spEventLog_MarkAsProcessed failed:" + m_Error.DetailError)
            Return False
        End If
        Return True
    End Function

    Public Function WaitForProcessing(ByVal EventID As Long, Optional ByVal IdleHandler As EventHandler = Nothing) As Boolean
        Dim cmd As IDbCommand = CreateSPCommand("spEventLog_CheckProcessed")
        AddParam(cmd, "@idfsEvent", EventID)
        AddParam(cmd, "@intProcessed", 0, ParameterDirection.InputOutput)
        Dim cn As IDbConnection = Connection
        EIDSS_EventLog.Wait = True
        Try
            While True And EIDSS_EventLog.Wait
                m_Error = ExecCommand(cmd, cn)
                If m_Error Is Nothing Then
                    Return False
                End If
                Dim ret As Object = GetParam(cmd, "@intProcessed")
                If Not ret Is Nothing AndAlso CInt(ret) <> 0 Then
                    Return True
                End If
                If Not IdleHandler Is Nothing Then
                    IdleHandler(Nothing, EventArgs.Empty)
                End If
            End While
        Finally
            EIDSS_EventLog.Wait = False
        End Try
        Return True
    End Function
    Public Function GetEventDescription(ByVal et As EventType) As String
        If et = EventType.ClientUILanguageChanged Then
            Return bv.model.Model.Core.ModelUserContext.CurrentLanguage
        End If
        Return ""
    End Function
    Public Function GetEventNotes(ByVal et As EventType) As String
        Return ""
    End Function
    Public Overrides Function GetSelectListSql() As String
        Return String.Format("Select * from fn_Event_SelectList('{0}') Order By datEventDatatime DESC", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
    End Function

    Public Function GetCaseType(ByVal EventId As Object, ByRef idfActivity As Object, ByRef aEventType As EventType) As Long
        Dim cmd As IDbCommand = CreateSPCommand("spEvent_GetCaseType")
        AddParam(cmd, "@idfEventID", EventId)
        AddTypedParam(cmd, "@idfCase", SqlDbType.BigInt, ParameterDirection.Output)
        AddTypedParam(cmd, "@EventType", SqlDbType.BigInt, ParameterDirection.Output)
        AddParam(cmd, "@CaseType", SqlDbType.BigInt, ParameterDirection.Output)
        m_Error = ExecCommand(cmd, Connection)
        If Not m_Error Is Nothing Then
            Return -1
        End If
        Dim param As Object = GetParamValue(cmd, "@EventType")
        If Not Utils.IsEmpty(param) Then
            aEventType = CType([Enum].Parse(GetType(EventType), param.ToString), EventType)
        End If
        idfActivity = GetParamValue(cmd, "@idfCase")
        param = GetParamValue(cmd, "@CaseType")
        Dim CaseType As Integer = 0
        If Not Utils.IsEmpty(param) Then
            CaseType = CInt(param)
        End If
        Return CaseType
    End Function
    Public Function SubscribeToAllEvents() As Boolean
        m_Error = Nothing
        Dim SubscribeToAllCmd As IDbCommand
        SubscribeToAllCmd = CreateSPCommand("spEventLog_SubscribeToAllEvents")
        AddParam(SubscribeToAllCmd, "@idfClientID", m_ClientID)

        m_Error = ExecCommand(SubscribeToAllCmd, SubscribeToAllCmd.Connection)

        If m_Error Is Nothing Then
            Return True
        Else
            Dbg.Debug("event subscriptio is fail: {0}", m_Error.DetailError)
            Return False
        End If
    End Function

    Public Function IsSubscribed() As Boolean
        m_Error = Nothing
        Dim cmd As IDbCommand
        cmd = CreateSPCommand("spEventLog_IsSubscribed")
        StoredProcParamsCache.CreateParameters(cmd)
        SetParam(cmd, "@idfClientID", m_ClientID)
        Dbg.Debug("Checking events subscription for ClientID {0}", m_ClientID)

        Dim objCount As Object = ExecScalar(cmd, cmd.Connection, m_Error)

        If m_Error Is Nothing Then
            If Utils.Dbl(objCount) > 0 Then
                Dbg.Debug("Client {0} is subscribed for notifications", m_ClientID)
                Return True
            Else
                Dbg.Debug("Client {0} is not subscribed for notifications", m_ClientID)
                Return False
            End If
        Else
            Dbg.Debug("Client {0} is not subscribed for notifications because of errors during sp execution", m_ClientID)
            Return False
        End If
    End Function

    Public Function GetRunningReplication() As Long
        Dim err As ErrorMessage = Nothing
        Dim id As Object = BaseDbService.ExecScalar("Select top 1 session_id from  fnGetRunningReplications()", ConnectionManager.DefaultInstance.Connection, err, Nothing, True)
        If (Utils.IsEmpty(ID)) Then
            Return Nothing
        End If
        Return CLng(id)
    End Function

End Class
