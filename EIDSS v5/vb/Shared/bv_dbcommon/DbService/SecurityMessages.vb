Imports bv.common.Core

Public Class SecurityMessages

    Public Shared Function GetLoginErrorMessage(ByVal code As Long) As ErrorMessage
        Select Case code
            Case 1
                Return New ErrorMessage("ErrEmptyUserLogin", "User login can't be empty")
            Case 2
                Return New ErrorMessage("ErrUserNotFound", "User with such login/password is not found.")
            Case 3
                Return New ErrorMessage("ErrLowClientVersion", "The application version doesn't correspond to database version. Please install the latest application version.")
            Case 4
                Return New ErrorMessage("ErrLowDatabaseVersion", "The application requires the newest database version. Please upgrade your database to latest database version.")
            Case 5
                Return New ErrorMessage("ErrIncorrectDatabaseVersion", "The database version is absent or in incorrect format. Please upgrade your database to latest database version.")
            Case 6
                Return New ErrorMessage("ErrLoginIsLocked", "Login is locked. Try to login again through some time period.")
            Case 7
                Return New ErrorMessage("ErrInvalidParameter", "Invalid parameter specified.")
            Case 8
                Return New ErrorMessage("ErrPasswordPolicy", "Unable to update the password. The value provided for the new password does not meet the length, complexity, or history requirement.")
            Case 9
                Return New ErrorMessage("ErrPasswordExpired", "Your password is expired. Please change your password.")
            Case Else
                Return New ErrorMessage(StandardError.UnprocessedError)
        End Select
    End Function

    Public Shared Function GetDBErrorMessage(ByRef exSql As System.Data.SqlClient.SqlException) As ErrorMessage
        Dim Err As ErrorMessage = Nothing
        Select Case exSql.Number
            Case 15211
                Return New ErrorMessage(StandardError.InvalidOldPassword, exSql)
            Case 18456
                Return New ErrorMessage(StandardError.InvalidLogin, exSql)
            Case 4060
                Err = New ErrorMessage("errDatabaseNotFound", "Cannot open database '{0}' on server '{1}'. Check the correctness of database name.", exSql, ConnectionManager.DefaultInstance.SQLDatabase, ConnectionManager.DefaultInstance.SQLServer)
                Return Err
            Case 8144
                Err = New ErrorMessage("errSQLLoginError", "Cannot connect to SQL server. Check the correctness of SQL connection parameters in the SQL Server tab or SQL server accessibility.")
                Err.Exception = exSql
                Dbg.Debug("error during login:{0}", exSql.ToString())
                Return Err
            Case Else
                If Utils.IsEmpty(exSql.Server) Then
                    Err = New ErrorMessage("errSqlServerNotFound", "Cannot connect to SQL server '{0}'. Check the correctness of SQL server name or SQL server accessibility.", exSql, ConnectionManager.DefaultInstance.SQLServer)
                Else
                    Err = New ErrorMessage("errSQLLoginError", "Cannot connect to SQL server. Check the correctness of SQL connection parameters in the SQL Server tab or SQL server accessibility.", exSql)
                End If
                Return Err
        End Select
    End Function

End Class
