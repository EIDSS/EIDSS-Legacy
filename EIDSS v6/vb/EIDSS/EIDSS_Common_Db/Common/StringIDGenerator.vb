Imports System.Text
Public Class StringIDGenerator
    Public Const MAX_ID_LEN As Integer = 36
    Public Shared Function Create(ByVal strSource As String, ByVal strPrefix As String, ByVal view As DataView) As String
        Dim strRet As New StringBuilder(strPrefix)
        Dim i As Integer = 0
        For i = 0 To strSource.Length - 1
            Dim c As Char = strSource.Chars(i)
            If strRet.Length < MAX_ID_LEN AndAlso Char.IsLetterOrDigit(c) Then
                strRet.Append(c)
            End If
        Next
        Dim ID As String = strRet.ToString
        If view Is Nothing Then
            Return ID
        End If
        Dim origID As String = ID
        i = 1
        While Not IsUniqueID(ID, view, Nothing) OrElse Not IsUniqueID_InDB(ID)
            If origID.Length + i.ToString.Length <= MAX_ID_LEN Then
                ID = origID & i
            Else
                ID = origID.Substring(0, MAX_ID_LEN - i.ToString.Length) & i
            End If
            i += 1
        End While
        Return ID
    End Function
    Public Shared Function IsUniqueID(ByVal strID As String, ByVal view As DataView, ByVal sourceRow As DataRow) As Boolean
        Return IsUniqueID(strID, view.Table, sourceRow)
    End Function
    Public Shared Function IsUniqueID(ByVal strID As String, ByVal dt As DataTable, ByVal sourceRow As DataRow) As Boolean
        Dim row As DataRow = dt.Rows.Find(strID)
        If row Is Nothing OrElse (sourceRow IsNot Nothing AndAlso row Is sourceRow) Then Return True
        Return False
    End Function
    Public Shared Function IsUniqueID_InDB(ByVal strID As String, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        Dim cmd As IDbCommand = BaseDbService.CreateCommand("Select idfsBaseReference from BaseReference Where idfsBaseReference=@idfsBaseReference", ConnectionManager.DefaultInstance.Connection, transaction)
        BaseDbService.AddParam(cmd, "@idfsBaseReference", strID)
        SyncLock cmd.Connection
            If cmd.Connection.State <> ConnectionState.Open Then
                cmd.Connection.Open()
            End If
            Using reader As IDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                If reader.Read() Then
                    Return False
                End If
            End Using
        End SyncLock
        Return True
    End Function


End Class
