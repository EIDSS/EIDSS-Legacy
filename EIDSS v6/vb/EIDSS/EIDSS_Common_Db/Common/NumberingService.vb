Imports System.Data
Imports System.Data.Common
Imports bv.common.Enums

Public Class NumberingService
    Inherits BaseDbService
    Public Shared Function GetNextNumber(ByVal aObjectType As NumberingObject, ByVal Connection1 As IDbConnection, ByRef m_Error As ErrorMessage, Optional ByVal transaction As IDbTransaction = Nothing) As String
        Return GetNextNumber(aObjectType, eidss.model.Core.EidssSiteContext.Instance.RealSiteID, Connection1, m_Error, transaction)
    End Function

    Public Shared Function GetNextNumber(ByVal aObjectType As NumberingObject, ByVal SiteID As Object, ByVal Connection1 As IDbConnection, ByRef m_Error As ErrorMessage, Optional ByVal transaction As IDbTransaction = Nothing) As String
        Dim cmd As IDbCommand = CreateSPCommand("spGetNextNumber", Connection1)
        AddParam(cmd, "@NextNumberName", CLng(aObjectType))
        AddTypedParam(cmd, "@NextNumberValue", SqlDbType.NVarChar, 200, ParameterDirection.Output)
        AddTypedParam(cmd, "@InstallationSite", SqlDbType.BigInt)
        m_Error = ExecCommand(cmd, Connection1, transaction)
        If m_Error Is Nothing Then
            Dim s As Object = GetParam(cmd, "@NextNumberValue")
            If Not s Is Nothing AndAlso Not CType(s, IDbDataParameter).Value Is DBNull.Value Then Return CType(s, IDbDataParameter).Value.ToString()
        End If
        Return Nothing
    End Function

    Public Function GetNextNumber(ByVal aObjectType As NumberingObject, Optional ByVal transaction As IDbTransaction = Nothing) As String
        Return GetNextNumber(aObjectType, Connection, m_Error, transaction)
    End Function
    Public Function SetNextNumber(ByVal dt As DataTable, ByVal aObjectType As NumberingObject, ByVal FieldName As String, Optional ByVal transaction As IDbTransaction = Nothing) As String
        For Each r As DataRow In dt.Rows
            If r.RowState <> DataRowState.Deleted AndAlso r.RowState <> DataRowState.Detached Then
                If dt.Columns.Contains(FieldName) AndAlso (r(FieldName) Is DBNull.Value OrElse r(FieldName).ToString = "") Then
                    Dim ns As New NumberingService
                    Dim code As String = ns.GetNextNumber(aObjectType, transaction)
                    If Not code Is Nothing Then
                        r.BeginEdit()
                        r(FieldName) = code
                        r.EndEdit()
                    End If
                End If
            End If
        Next

        Return GetNextNumber(aObjectType, Connection, m_Error, transaction)
    End Function

    Public Function GetNextNumberRange(ByVal aObjectType As NumberingObject, ByVal Count As Integer, Optional ByVal transaction As IDbTransaction = Nothing, Optional ByVal dt As DataTable = Nothing) As DataTable
        SyncLock Connection
            Dim InternalTransaction As Boolean = False
            Dim st As ConnectionState = Connection.State
            If transaction Is Nothing Then
                If Connection.State <> ConnectionState.Open Then Connection.Open()
                transaction = Connection.BeginTransaction
                InternalTransaction = True
            End If
            Try
                Dim cmd As IDbCommand = CreateSPCommand("spGetNextNumberRange")
                cmd.Transaction = transaction
                If AddParam(cmd, "@NextNumberName", CLng(aObjectType), m_Error) Is Nothing Then Return Nothing
                If AddParam(cmd, "@Count", Count, m_Error) Is Nothing Then Return Nothing
                ' If ObjectName = VialNumberName Then
                If AddParam(cmd, "@InstallationSite", EIDSS.model.Core.EidssSiteContext.Instance.SiteID, m_Error) Is Nothing Then Return Nothing
                'Else
                'If AddTypedParam(cmd, "@InstallationSite", SqlDbType.NVarChar, 3, m_Error, ParameterDirection.Output) Is Nothing Then Return Nothing
                'End If
                Dim da As DbDataAdapter = CreateAdapter(cmd)
                If dt Is Nothing Then
                    dt = New DataTable
                End If
                da.Fill(dt)
                If InternalTransaction Then
                    transaction.Commit()
                    transaction = Nothing
                End If
                Return dt
            Catch ex As Exception
                m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
                If InternalTransaction Then
                    transaction.Rollback()
                    transaction = Nothing
                End If
                Return Nothing
            Finally
                If InternalTransaction And st = ConnectionState.Closed Then
                    Connection.Close()
                End If
            End Try
        End SyncLock
        Return Nothing
    End Function


End Class
