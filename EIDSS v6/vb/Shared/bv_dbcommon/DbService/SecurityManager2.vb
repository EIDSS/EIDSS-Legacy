Imports System.Collections.Generic
Imports bv.common.Core
Imports bv.common.db.Core
Imports System.Data.Common
Imports System.Security.Cryptography
Imports System.Diagnostics
Imports bv.common.Configuration

Namespace Security
    Public Class SecurityManager2
        'Implements ISecurityManager
        'Private m_PermissionName As GetPermissionName

        'Public ReadOnly Property AccessGranted() As Boolean Implements ISecurityManager.AccessGranted
        '    Get
        '        Return Utils.Str(EIDSSUser.Current.EmployeeID) <> ""
        '    End Get
        'End Property

        'Public Function GetPermissions(ByVal userId As Object) As System.Collections.Generic.IDictionary(Of String, Boolean) Implements ISecurityManager.GetPermissions
        '    Dim tok As System.Collections.Generic.Dictionary(Of String, Boolean) = New System.Collections.Generic.Dictionary(Of String, Boolean)
        '    Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spEvaluatePermissions", ConnectionManager.DefaultInstance.Connection, Nothing)
        '    BaseDbService.AddParam(cmd, "@idfEmployee", userId)
        '    Dim da As DbDataAdapter = BaseDbService.CreateAdapter(cmd)
        '    Dim ds As New DataSet
        '    ds.EnforceConstraints = False
        '    da.Fill(ds)
        '    Dim trans As System.Collections.Generic.Dictionary(Of Long, String) = New System.Collections.Generic.Dictionary(Of Long, String)
        '    trans(ObjectOperation.Read) = "Select"
        '    trans(ObjectOperation.Write) = "Update"
        '    trans(ObjectOperation.Create) = "Insert"
        '    trans(ObjectOperation.Delete) = "Delete"
        '    trans(ObjectOperation.Execute) = "Execute"

        '    For Each row As DataRow In ds.Tables(0).Rows
        '        Dim value As Object = row("intPermission")
        '        If value Is DBNull.Value Then Continue For
        '        Dim sf As String
        '        Dim op As Long
        '        sf = CType(CLng(row("idfsSystemFunction")), EIDSSPermissionObject).ToString
        '        op = CType(row("idfsObjectOperation"), Long)
        '        sf += "." + trans(op)
        '        If (CInt(value) = 2) Then
        '            tok(sf) = True
        '        Else
        '            tok(sf) = False
        '        End If
        '    Next

        '    Return tok
        'End Function

        Protected Function PasswordHash(ByVal password As String) As Object
            Return SHA1.Create().ComputeHash(System.Text.UnicodeEncoding.Unicode.GetBytes(password))
        End Function

        'Private Function CalculatePassword(ByRef password As String, ByRef challenge As Byte()) As Object
        '    Dim total As System.Collections.Generic.List(Of Byte) = New List(Of Byte) '.ArrayList = New ArrayList
        '    Dim sha As SHA1 = SHA1.Create()
        '    Dim passwordHash As Byte() = sha.ComputeHash(System.Text.UnicodeEncoding.Unicode.GetBytes(password))

        '    Dim j As Integer = 0
        '    Dim i As Integer
        '    For i = 0 To passwordHash.Length() - 1
        '        Dim current As Byte = passwordHash(i)
        '        current = current Xor challenge(j)
        '        total.Add(current)
        '        j = j + 1
        '        If j >= challenge.Length() Then j = 0
        '    Next
        '    Return sha.ComputeHash(total.ToArray())

        '    'byte[]bytes=
        '    'System.Security.Cryptography.MD5 md=System.Security.Cryptography.MD5.Create();
        '    'byte[] hashed=md.ComputeHash(bytes);

        'End Function

        'Private Function EvaluateHash(ByVal password As String, ByRef hash As Object) As Integer

        '    Dim challenge As Object
        '    Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spLoginChallenge", Nothing, Nothing)
        '    BaseDbService.AddTypedParam(cmd, "@challenge", SqlDbType.VarBinary, 1000, ParameterDirection.Output)
        '    Dim dt As New DataTable
        '    BaseDbService.ExecCommand(cmd, Nothing)
        '    challenge = BaseDbService.GetParamValue(cmd, "@challenge")
        '    If Utils.IsEmpty(challenge) Then Return 2

        '    hash = CalculatePassword(password, CType(challenge, Byte()))

        '    Return 0
        'End Function

        'Private Function CheckVersion() As Integer
        '    Dim cmd As IDbCommand = Nothing
        '    cmd = BaseDbService.CreateSPCommand("spCheckVersion", ConnectionManager.DefaultInstance.Connection, Nothing)
        '    BaseDbService.AddParam(cmd, "@ModuleName", GlobalSettings.AppName)
        '    BaseDbService.AddParam(cmd, "@ModuleVersion", GlobalSettings.Version)
        '    BaseDbService.AddParam(cmd, "@Result", 0, ParameterDirection.Output)
        '    Dim da As DbDataAdapter = BaseDbService.CreateAdapter(cmd)
        '    Dim dt As New DataTable
        '    da.Fill(dt)
        '    Return CInt(BaseDbService.GetParamValue(cmd, "@Result"))
        'End Function

        'Function LogIn _
        '    ( _
        '        ByVal organization As String, _
        '        ByVal userName As String, _
        '        ByVal password As String, _
        '        Optional ByVal SQLServer As String = Nothing, _
        '        Optional ByVal SQLDatabase As String = Nothing, _
        '        Optional ByVal SQLUser As String = Nothing, _
        '        Optional ByVal SQLPassword As String = Nothing, _
        '        Optional ByVal UseLocking As Boolean = True _
        '    ) As Integer Implements ISecurityManager.LogIn

        '    If ConnectionManager.DefaultInstance.Connection Is Nothing _
        '        OrElse Not ConnectionManager.DefaultInstance.SQLServer.Equals(SQLServer) _
        '        OrElse Not ConnectionManager.DefaultInstance.SQLDatabase.Equals(SQLDatabase) _
        '        OrElse Not ConnectionManager.DefaultInstance.SQLUser.Equals(SQLUser) _
        '        OrElse Not ConnectionManager.DefaultInstance.SQLPassword.Equals(SQLPassword) _
        '        Then
        '        ConnectionManager.DefaultInstance.SetCredentials(Nothing, SQLServer, SQLDatabase, SQLUser, SQLPassword)
        '    End If
        '    'ConnectionManager.DefaultInstance.Save()

        '    Dim res As Integer = CheckVersion()
        '    If res <> 0 Then Return res

        '    Dim hash As Object = Nothing
        '    res = EvaluateHash(password, hash)
        '    If (res <> 0) Then Return res

        '    Dim cmd As IDbCommand = Nothing
        '    cmd = BaseDbService.CreateSPCommand("spLoginUser", ConnectionManager.DefaultInstance.Connection, Nothing)
        '    BaseDbService.AddParam(cmd, "@Organization", organization)
        '    BaseDbService.AddParam(cmd, "@UserName", userName)
        '    BaseDbService.AddParam(cmd, "@Password", hash)
        '    BaseDbService.AddParam(cmd, "@Result", 0, ParameterDirection.Output)
        '    Dim da As DbDataAdapter = BaseDbService.CreateAdapter(cmd)
        '    Dim dt As New DataTable
        '    da.Fill(dt)
        '    res = CInt(BaseDbService.GetParamValue(cmd, "@Result"))
        '    If res = 0 Then
        '        ConnectionManager.DefaultInstance.Save()
        '        Dim user As EIDSSUser = EIDSSUser.Current
        '        user.EmployeeID = dt.Rows(0)("idfPerson")
        '        user.FullName = Utils.Str(dt.Rows(0)("strFamilyName")) + " " + Utils.Str(dt.Rows(0)("strFirstName")) + " " + Utils.Str(dt.Rows(0)("strSecondName"))
        '        user.FirstName = Utils.Str(dt.Rows(0)("strFirstName"))
        '        user.SecondName = Utils.Str(dt.Rows(0)("strSecondName"))
        '        user.LastName = Utils.Str(dt.Rows(0)("strFamilyName"))

        '        user.LoginName = userName
        '        user.ID = dt.Rows(0)("idfUserID")
        '        user.Organization = organization
        '        user.OrganizationID = dt.Rows(0)("idfInstitution")

        '        ' alexander Oct 12 2008 
        '        ' Password need for Auto-logout form
        '        'user.Password = password

        '        user.Init(GetPermissions(user.EmployeeID))
        '        'EIDSSUser.Current.ObjectPermissions = GetObjectTypePermissions(EIDSSUser.Current.EmployeeID)
        '        ConfigWriter.Instance.Save()
        '    End If
        '    Return CInt(res)
        'End Function

        'Function ChangePassword _
        '    ( _
        '        ByVal organization As String, _
        '        ByVal userName As String, _
        '        ByVal currentPassword As String, _
        '        ByVal newPassword As String, _
        '        Optional ByVal SQLServer As String = Nothing, _
        '        Optional ByVal SQLDatabase As String = Nothing, _
        '        Optional ByVal SQLUser As String = Nothing, _
        '        Optional ByVal SQLPassword As String = Nothing, _
        '        Optional ByVal UseLocking As Boolean = True _
        '    ) As Integer Implements ISecurityManager.ChangePassword

        '    ConnectionManager.DefaultInstance.SetCredentials(Nothing, SQLServer, SQLDatabase, SQLUser, SQLPassword)

        '    Dim res As Integer = CheckVersion()
        '    If res <> 0 Then Return res

        '    Dim hash As Object = Nothing
        '    res = EvaluateHash(currentPassword, hash)
        '    If (res <> 0) Then Return res

        '    Dim cmd As IDbCommand = Nothing
        '    cmd = BaseDbService.CreateSPCommand("spChangePassword", ConnectionManager.DefaultInstance.Connection, Nothing)
        '    BaseDbService.AddParam(cmd, "@Organization", organization)
        '    BaseDbService.AddParam(cmd, "@UserName", userName)
        '    BaseDbService.AddParam(cmd, "@CurrentPassword", hash)
        '    BaseDbService.AddParam(cmd, "@NewPassword", PasswordHash(newPassword))
        '    BaseDbService.AddTypedParam(cmd, "@Result", SqlDbType.Int, ParameterDirection.Output)
        '    Dim da As DbDataAdapter = BaseDbService.CreateAdapter(cmd)
        '    Dim dt As New DataTable
        '    da.Fill(dt)
        '    res = CType(BaseDbService.GetParamValue(cmd, "@Result"), Integer)

        '    If res = 0 Then
        '        Dim user As EIDSSUser = EIDSSUser.Current
        '        user.EmployeeID = dt.Rows(0)("idfPerson")
        '        user.FullName = Utils.Str(dt.Rows(0)("strFamilyName")) + " " + Utils.Str(dt.Rows(0)("strFirstName")) + " " + Utils.Str(dt.Rows(0)("strSecondName"))
        '        user.FirstName = Utils.Str(dt.Rows(0)("strFirstName"))
        '        user.SecondName = Utils.Str(dt.Rows(0)("strSecondName"))
        '        user.LastName = Utils.Str(dt.Rows(0)("strFamilyName"))

        '        user.LoginName = userName
        '        user.ID = dt.Rows(0)("idfUserID")
        '        user.Organization = organization
        '        user.OrganizationID = dt.Rows(0)("idfInstitution")

        '        ' alexander Oct 12 2008 
        '        ' Password need for Auto-logout form
        '        'user.Password = newPassword

        '        user.Init(GetPermissions(user.EmployeeID))
        '        'EIDSSUser.Current.ObjectPermissions = GetObjectTypePermissions(EIDSSUser.Current.EmployeeID)
        '        ConfigWriter.Instance.Save()
        '    End If
        '    Return res
        'End Function

        Function SetPassword _
    ( _
        ByVal userID As Object, _
        ByVal password As String, _
        ByRef connection As IDbConnection, _
        ByRef transaction As IDbTransaction _
    ) As Integer

            Dim cmd As IDbCommand = Nothing
            cmd = BaseDbService.CreateSPCommand("spSetPassword", connection, transaction)
            BaseDbService.AddParam(cmd, "@UserID", userID)
            BaseDbService.AddParam(cmd, "@Password", PasswordHash(password))
            BaseDbService.AddTypedParam(cmd, "@Result", SqlDbType.Int, ParameterDirection.Output)
            Dim da As DbDataAdapter = BaseDbService.CreateAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            Dim res As Integer = CType(BaseDbService.GetParamValue(cmd, "@Result"), Integer)
            Return res
        End Function


        'Public Sub LogOut() Implements ISecurityManager.LogOut
        '    If Not (Utils.IsEmpty(EIDSSUser.Current.EmployeeID)) Then
        '        SecurityLog.WriteToEventLogDB(CLng(EIDSSUser.Current.ID), SecurityAuditEvent.Logoff, True, "EIDSS user log off") 'EIDSS user log off
        '    End If

        '    Dim user As EIDSSUser = EIDSSUser.Current
        '    user.EmployeeID = Nothing
        '    user.FullName = Nothing
        '    user.LoginName = Nothing
        '    user.ID = Nothing
        '    user.Organization = Nothing
        '    user.OrganizationID = Nothing
        '    user.Init(Nothing)
        'End Sub

    End Class
End Namespace