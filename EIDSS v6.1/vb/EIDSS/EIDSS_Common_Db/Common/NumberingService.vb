Imports System.Data
Public Class NumberingService
    Inherits BaseDbService
    'Public Shared Function GetNextNumber(ByVal aObjectType As NumberingObject, ByVal connection1 As IDbConnection, ByRef err As ErrorMessage, Optional ByVal transaction As IDbTransaction = Nothing) As String
    '    Return GetNextNumber(aObjectType, connection1, err, transaction)
    'End Function

    Public Shared Function GetNextNumber(ByVal aObjectType As NumberingObject, ByVal connection1 As IDbConnection, ByRef err As ErrorMessage, Optional ByVal transaction As IDbTransaction = Nothing) As String
        Dim cmd As IDbCommand = CreateSPCommand("spGetNextNumber", connection1)
        AddParam(cmd, "@NextNumberName", CLng(aObjectType))
        AddTypedParam(cmd, "@NextNumberValue", SqlDbType.NVarChar, 200, ParameterDirection.Output)
        AddTypedParam(cmd, "@InstallationSite", SqlDbType.BigInt)
        err = ExecCommand(cmd, connection1, transaction)
        If err Is Nothing Then
            Dim s As Object = GetParam(cmd, "@NextNumberValue")
            If Not s Is Nothing AndAlso Not CType(s, IDbDataParameter).Value Is DBNull.Value Then Return CType(s, IDbDataParameter).Value.ToString()
        End If
        Return Nothing
    End Function

    Public Function GetNextNumber(ByVal aObjectType As NumberingObject, Optional ByVal transaction As IDbTransaction = Nothing) As String
        Return GetNextNumber(aObjectType, Connection, m_Error, transaction)
    End Function
End Class
