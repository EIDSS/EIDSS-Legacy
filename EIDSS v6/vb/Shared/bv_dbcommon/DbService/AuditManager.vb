Imports bv.common.Core
Imports bv.common.Objects
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient

Namespace Core
    Public Class AuditManager
        Private Shared m_AsyncConnection As IDbConnection
        Private Shared m_AsyncConnectionManager As ConnectionManager
        Private Shared m_DontUseFiltation As Boolean = False
        Public Shared Property DontUseFiltation() As Boolean
            Get
                Return m_DontUseFiltation
            End Get
            Set(ByVal value As Boolean)
                m_DontUseFiltation = True
            End Set
        End Property
        Public Shared ReadOnly Property Connection() As IDbConnection
            Get
                If m_AsyncConnection Is Nothing Then
                    If (Not ConnectionManager.DefaultInstance Is Nothing) Then
                        m_AsyncConnectionManager = ConnectionManager.CreateNew(ConnectionManager.DefaultInstance.SQLServer, _
                                                                               ConnectionManager.DefaultInstance.SQLDatabase, _
                                                                               ConnectionManager.DefaultInstance.SQLUser, _
                                                                               ConnectionManager.DefaultInstance.SQLPassword,
                                                                               ConnectionManager.DefaultInstance.SQLConnectionString)
                        m_AsyncConnectionManager.UseAsyncConnection = True

                    Else
                        m_AsyncConnectionManager = ConnectionManager.CreateNew(True)
                    End If
                    m_AsyncConnection = m_AsyncConnectionManager.Connection
                    ' m_AsyncConnectionManager.Owner = "Audit manager"
                End If
                Return m_AsyncConnection
            End Get
        End Property
        Public Shared Function CreateAuditEvent(ByVal auditData As AuditObject, ByVal transaction As IDbTransaction, Optional ByVal throwExceptionOnError As Boolean = False) As Object
            Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("dbo.spAudit_CreateNewEvent", transaction.Connection, transaction)
            Dim params As New Dictionary(Of String, Object)
            params.Add("@idfsDataAuditEventType", CLng(auditData.EventType))
            params.Add("@idfsDataAuditObjectType", auditData.Name)
            params.Add("@strMainObjectTable", auditData.AuditTable)
            params.Add("@strReason", auditData.Reason)
            If Not Utils.IsEmpty(auditData.Key) Then
                params.Add("@idfsMainObject", auditData.Key)
            End If
            StoredProcParamsCache.CreateParameters(cmd, params)
            BaseDbService.ExecCommand(cmd, transaction.Connection, transaction, throwExceptionOnError)
            auditData.LastAuditEventID = BaseDbService.GetParamValue(cmd, "@idfDataAuditEvent")
            Return auditData.LastAuditEventID
        End Function
        Public Shared Sub ClearAuditContext(ByVal transaction As IDbTransaction, ByVal Connection As IDbConnection)
            Dim cmd As IDbCommand
            If transaction Is Nothing OrElse transaction.Connection Is Nothing Then
                cmd = BaseDbService.CreateSPCommand("dbo.spClearContextData", Connection)
            Else
                cmd = BaseDbService.CreateSPCommand("dbo.spClearContextData", transaction.Connection, transaction)
            End If
            If cmd.Connection Is Nothing Then Return
            Dim params As New Dictionary(Of String, Object)
            params.Add("@ClearEventID", False)
            params.Add("@ClearDataAuditEvent", True)
            StoredProcParamsCache.CreateParameters(cmd, params)
            BaseDbService.ExecCommand(cmd, cmd.Connection, transaction, True)
        End Sub
        'Private Class AsyncAuditData
        '    Public Sub New(ByVal cmd As SqlCommand, ByVal auditData As AuditObject)
        '        Command = cmd
        '        AuditObject = auditData
        '    End Sub
        '    Public Command As SqlCommand
        '    Public AuditObject As AuditObject
        'End Class

        Public Shared Sub StartReplicationAsync(ByVal auditData As AuditObject)
            If auditData Is Nothing Then
                Return
            End If
            If Utils.IsEmpty(auditData.LastAuditEventID) Then
                Return
            End If
            If Not auditData.EventLog Is Nothing Then
                Try
                    auditData.EventLog.CheckNotificationService()
                    auditData.EventLog.StartReplication()
                Catch ex As Exception
                    Dbg.Debug("error during replication after async filtration: {0}", ex.Message)
                    Dbg.Debug("-> table{0}", auditData.Name)
                    Dbg.Debug("->stack trace: {0}", ex.StackTrace.ToString)
                    Dbg.Trace()
                End Try
            End If
        End Sub
        'Private Shared Sub HandleCallback(ByVal result As IAsyncResult)
        '    Dim data As AsyncAuditData = CType(result.AsyncState, AsyncAuditData)
        '    Try
        '        SyncLock m_AsyncConnection
        '            Dim recordAffected As Integer = data.Command.EndExecuteNonQuery(result)
        '            Dbg.Debug("Async filtration is finished for object {0} {1}", data.AuditObject.Name, Utils.Str(data.AuditObject.Key))
        '            If data.Command.Connection.State = ConnectionState.Open Then ' AndAlso s_ExecutingCount > 0 
        '                data.Command.Connection.Close()
        '            End If
        '        End SyncLock

        '    Catch ex As Exception
        '        Dbg.Debug("error during async filtration: {0}", ex.Message)
        '        Dbg.Debug("-> table{0}", data.AuditObject.Name)
        '        Dbg.Debug("->stack trace: {0}", ex.StackTrace.ToString)
        '        Dbg.Trace()
        '    Finally
        '        If Not data.AuditObject.EventLog Is Nothing Then
        '            Try
        '                data.AuditObject.EventLog.CheckNotificationService()
        '                data.AuditObject.EventLog.StartReplication()
        '            Catch ex As Exception
        '                Dbg.Debug("error during replication after async filtration: {0}", ex.Message)
        '                Dbg.Debug("-> table{0}", data.AuditObject.Name)
        '                Dbg.Debug("->stack trace: {0}", ex.StackTrace.ToString)
        '                Dbg.Trace()
        '            End Try
        '        End If
        '    End Try
        'End Sub

    End Class
End Namespace
