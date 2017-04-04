Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports bv.common.Configuration
Imports bv.common.Core

Namespace Core
    Public Class StoredProcParamsCache
        Private Shared ReadOnly m_Cache As Dictionary(Of String, DataTable) = New Dictionary(Of String, DataTable)

        Private Shared Function CreateItem(ByVal name As String, ByVal conn As IDbConnection, ByVal trans As IDbTransaction) As DataTable
            Dim command As IDbCommand = BaseDbService.CreateCommand("select * from INFORMATION_SCHEMA.PARAMETERS where SPECIFIC_NAME = '" + name + "'", conn, trans)
            command.CommandTimeout = BaseSettings.SqlCommandTimeout
            Dim table As DataTable = New DataTable
            Dbg.Debug("Receiving parameters for procedure {0}.Working thread ID - {1}, name - {2}", name, Threading.Thread.CurrentThread.ManagedThreadId, Threading.Thread.CurrentThread.Name)
            SyncLock command.Connection
                Try
                    BaseDbService.FillTable(command, table)
                    Dbg.Debug("Parameters for procedure {0} are received. Parameters count - {1}", name, table.Rows.Count)
                Catch ex As Exception
                    Dbg.Debug("Error during retreving procedure {0} parameters. Working thread ID - {1}, name - {2}", name, Threading.Thread.CurrentThread.ManagedThreadId, Threading.Thread.CurrentThread.Name)
                    Dbg.Trace()
                    Throw
                End Try
            End SyncLock

            For Each row As DataRow In table.Rows
                row("PARAMETER_NAME") = Utils.Str(row("PARAMETER_NAME")) '.ToLowerInvariant
                Dbg.Debug("    {0}", row("PARAMETER_NAME"))
            Next
            Return table
        End Function

        Private Shared Function Item(ByVal name As String, ByVal conn As IDbConnection, ByVal trans As IDbTransaction) As DataTable
            SyncLock m_Cache
                If m_Cache.ContainsKey(name) Then
                    Return m_Cache.Item(name)
                End If
                Dim table As DataTable = CreateItem(name, conn, trans)
                m_Cache.Add(name, table)
                Return table
            End SyncLock
        End Function

        Public Shared Sub ClearCache()
            SyncLock m_Cache
                m_Cache.Clear()
            End SyncLock
        End Sub

        Private Shared ReadOnly m_PredefinedParmaNames As List(Of String) = New List(Of String)(New String() {"@ID", "@LangID"})
        Private Shared Function CreateParameter(ByVal row As DataRow) As SqlParameter
            Dim param As SqlParameter = New SqlParameter()
            Dim paramName As String = row.Item("PARAMETER_NAME").ToString() '.ToLowerInvariant
            If m_PredefinedParmaNames.Contains(paramName) Then
                param.ParameterName = paramName
            Else
                param.ParameterName = row.Item("PARAMETER_NAME").ToString()
            End If

            Select Case row.Item("PARAMETER_MODE").ToString()
                Case "IN"
                    param.Direction = ParameterDirection.Input
                Case "INOUT"
                    param.Direction = ParameterDirection.InputOutput
                    param.Value = DBNull.Value
                Case Else
                    param.Direction = ParameterDirection.Input
            End Select

            Select Case row.Item("DATA_TYPE").ToString()
                Case "nvarchar"
                    'param.DbType = DbType.String
                    param.SqlDbType = SqlDbType.NVarChar
                Case "datetime"
                    'param.DbType = DbType.DateTime
                    param.SqlDbType = SqlDbType.DateTime
                Case "bit"
                    'param.DbType = DbType.Boolean
                    param.SqlDbType = SqlDbType.Bit
                Case "money"
                    'param.DbType = DbType.Decimal
                    param.SqlDbType = SqlDbType.Money
                Case "float"
                    'param.DbType = DbType.Double
                    param.SqlDbType = SqlDbType.Float
                Case "int"
                    'param.DbType = DbType.Int32
                    param.SqlDbType = SqlDbType.Int
                Case "bigint"
                    'param.DbType = DbType.Int32
                    param.SqlDbType = SqlDbType.BigInt
                Case "uniqueidentifier"
                    param.SqlDbType = SqlDbType.UniqueIdentifier
            End Select

            If Not IsDBNull(row.Item("CHARACTER_MAXIMUM_LENGTH")) Then
                param.Size = Convert.ToInt32(row.Item("CHARACTER_MAXIMUM_LENGTH"))
            End If
            param.Value = DBNull.Value

            Return param
        End Function

        Private Shared Function CreateReturnParameter() As IDataParameter
            Dim resultParam As SqlParameter = New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
            resultParam.Direction = ParameterDirection.ReturnValue
            Return resultParam
        End Function

        Public Shared Sub CreateParameters(ByVal cmd As IDbCommand, Optional ByVal paramValues As Dictionary(Of String, Object) = Nothing)
            Dim splitNames As String() = cmd.CommandText.Split("."c)
            Dim tbl As DataTable = Item(splitNames(splitNames.Length - 1), cmd.Connection, cmd.Transaction)
            For Each row As DataRow In tbl.Rows
                Dim param As SqlParameter = CreateParameter(row)
                If Not paramValues Is Nothing AndAlso paramValues.ContainsKey(param.ParameterName) AndAlso Not Utils.IsEmpty(paramValues(param.ParameterName)) Then
                    param.Value = paramValues(param.ParameterName)
                End If
                cmd.Parameters.Add(param)
                If param.ParameterName = "@LangID" Then
                    param.Value = model.Model.Core.ModelUserContext.CurrentLanguage
                End If
            Next
            cmd.Parameters.Add(CreateReturnParameter())
        End Sub
        Public Shared Function Contains(ByVal procName As String) As Boolean
            Dim splitNames As String() = procName.Split("."c)
            Return m_Cache.ContainsKey(splitNames(splitNames.Length - 1))
        End Function
        Public Shared Sub InitMultiThreadProcedures(ByVal procList As String())
            Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("", ConnectionManager.DefaultInstance.Connection)
            For Each proc As String In procList
                cmd.CommandText = proc
                CreateParameters(cmd, Nothing)
            Next
        End Sub
    End Class
End Namespace
