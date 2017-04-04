Imports System.Data
Imports bv.common.Core
Imports bv.common.db.Security
Imports bv.common.Enums

Public Class Person_DB
    Inherits BaseDbService

    Public Const TablePerson As String = "Person"
    Public Const TableUser As String = "UserTable"
    Public Const PersonKeyFieldName As String = "idfPerson"



    Public Sub New()
        ObjectName = "Person"
    End Sub


    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spPerson_SelectDetail")
            AddParam(cmd, "@idfPerson", ID)
            AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)

            FillDataset(cmd, ds, TablePerson)
            CorrectTable(ds.Tables(0), TablePerson)
            CorrectTable(ds.Tables(1), TableUser)
            ClearColumnsAttibutes(ds)
            ds.EnforceConstraints = False
            If ID Is Nothing Then
                ID = NewIntID()
                Dim r As DataRow = ds.Tables(TablePerson).NewRow
                r(PersonKeyFieldName) = ID
                ds.Tables(TablePerson).Rows.Add(r)
                m_IsNewObject = True
            End If
            m_ID = ID

            Dim dbs As BaseDbService = New SecurityPolicy_DB
            ds.Merge(dbs.GetDetail(Nothing))

            Dim t As DataTable = ds.Tables(TableUser)
            t.Columns.Add("idfsSite1", GetType(Long), "idfsSite")
            t.Columns.Add("idfsSite2", GetType(Long), "idfsSite")
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function

    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            Dim changes As DataTable = ds.Tables(TableUser).GetChanges(DataRowState.Added Or DataRowState.Modified)
            ExecPostProcedure("spPerson_Post", ds.Tables(TablePerson), Connection, transaction)
            ExecPostProcedure("spUser_Post", ds.Tables(TableUser), Connection, transaction)

            If Not (changes Is Nothing) Then
                For Each row As DataRow In changes.Rows
                    Dim pass As Object = row("strPassword")
                    If Utils.IsEmpty(pass) Then Continue For
                    Dim manager As New SecurityManager2()
                    Dim res As Integer = manager.SetPassword( _
                        row("idfUserID"), _
                        Utils.Str(pass), _
                        Connection, _
                        transaction)
                    If (res <> 0) Then
                        m_Error = SecurityMessages.GetLoginErrorMessage(res)
                        Return False
                    End If
                Next
            End If
            db.Core.LookupCache.NotifyChange("Person", transaction, ID)
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function


    Public Function SetLogin(ByVal ds As DataSet, ByVal login As String, ByVal passowrd As String) As Boolean
        If ds.Tables(TableUser).Rows.Count = 0 Then
            Dim r As DataRow = ds.Tables(TableUser).NewRow
            r.BeginEdit()
            r("idfUserID") = NewIntID()
            r("idfPerson") = ID
            r("idfsSite") = model.Core.EidssSiteContext.Instance.SiteID
            r("strAccountName") = login
            r("strPassword") = passowrd
            r.EndEdit()
            ds.Tables(TableUser).Rows.Add(r)
        Else
            Dim r As DataRow = ds.Tables(TableUser).Rows(0)
            r.BeginEdit()
            r("strAccountName") = login
            r("strPassword") = passowrd
            r.EndEdit()
        End If
        Return True
    End Function

    Public Sub DeleteLogin(ByVal ds As DataSet)
        If ds.Tables(TableUser).Rows.Count > 0 Then
            For i As Integer = ds.Tables(TableUser).Rows.Count - 1 To 0
                If ds.Tables(TableUser).Rows(i).RowState <> DataRowState.Deleted Then
                    ds.Tables(TableUser).Rows(i).Delete()
                End If
            Next
        End If
    End Sub
    '0 - no such login
    '1 - empty UserName/organization
    '2 - login exists
    '-1 - db error
    Public Function ValidateLogin(ByVal login As String) As Integer
        Dim cmd As IDbCommand = CreateSPCommand("dbo.spLogin_Validate", Connection)
        AddParam(cmd, "@idfPerson", ID)
        AddParam(cmd, "@UserName", login)
        AddParam(cmd, "@Result", 0, ParameterDirection.Output)
        m_Error = ExecCommand(cmd, Connection)
        If m_Error Is Nothing Then
            Return CInt(GetParamValue(cmd, "@Result"))
        Else
            Return -1
        End If
    End Function

    '0 - no such login
    '1 - empty UserName/organization
    '2 - login exists
    '-1 - db error
    Public Function ValidateLogin(ByVal employee As Object, ByVal site As Object, ByVal login As String) As Integer
        Dim cmd As IDbCommand = CreateSPCommand("dbo.spLogin_Validate", Connection)
        AddParam(cmd, "@idfPerson", employee)
        AddParam(cmd, "@idfsSite", site)
        AddParam(cmd, "@strAccountName", login)
        AddParam(cmd, "@Result", 0, ParameterDirection.Output)
        m_Error = ExecCommand(cmd, Connection)
        If m_Error Is Nothing Then
            Return CInt(GetParamValue(cmd, "@Result"))
        Else
            Return -1
        End If
    End Function


    Public Sub SetPasswordExpiration(ByVal dr As DataRow, Optional ByVal transaction As IDbTransaction = Nothing)

        Dim userID As Integer = CType(dr("idfUserID"), Integer)
        Dim userMustChange As Boolean = CType(dr("MustChangePassword"), Boolean)
        Dim expirMonths As Integer = CType(dr("intExpirationPeriod"), Integer)
        SetPasswordExpiration(userID, expirMonths, userMustChange, transaction)
    End Sub

    Public Sub SetPasswordExpiration(ByVal userID As Integer, ByVal userMustChange As Boolean)
        SetPasswordExpiration(userID, -1, userMustChange)
    End Sub

    Sub SetPasswordExpiration(ByVal userID As Integer, ByVal expirMonths As Integer, ByVal userMustChange As Boolean, Optional ByVal transaction As IDbTransaction = Nothing)

        Dim expirationDate As DateTime

        If (expirMonths = 0) Then
            expirMonths = 12 * 100 ' Pass Never Expired ;)
            expirationDate = New DateTime(2100, 1, 1)
        Else
            expirationDate = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddMonths(expirMonths)
        End If

        If (userMustChange) Then expirationDate = DateTime.Now()


        Dim cmd As IDbCommand = CreateSPCommand("spPerson_SetPasswordExpiration", Connection)
        AddParam(cmd, "@UserID", userID)
        AddParam(cmd, "@ExpirationDate", expirationDate)

        If (expirMonths > -1) Then ' do not change ExpirationPerion if ExpirMonths= -1
            AddParam(cmd, "@ExpirationPeriod", expirMonths)
        End If



        ExecCommand(cmd, Connection, transaction, True)

    End Sub




    Public Sub GetPasswordExpiration(ByVal employeeID As Object, ByVal loginName As String, ByRef expirationDate As DateTime)

        expirationDate = New DateTime(2100, 1, 1)

        Dim cmd As IDbCommand = CreateSPCommand("spPerson_CheckNeedChangePassword", Connection)
        AddParam(cmd, "@EmployeeID", employeeID)
        AddParam(cmd, "@LoginName", loginName)
        Dim dt As New DataTable
        FillTable(cmd, dt)
        If (dt.Rows.Count = 0) Then Return

        If (IsDBNull(dt.Rows(0)("ExpirationDate")) = False) Then
            expirationDate = CType(dt.Rows(0)("ExpirationDate"), DateTime)
        End If

    End Sub




    Public Function IsPasswordAlreadyUsed(ByVal employeeID As Object, ByVal password As String) As Boolean

        Dim cmd As IDbCommand = CreateSPCommand("spPerson_CheckPasswordReuse", Connection)
        AddParam(cmd, "@EmployeeID", employeeID)
        AddParam(cmd, "@Password", password)
        Dim dt As DataTable = ExecTable(cmd)
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            Return False
        End If
        Dim isExists As Boolean = CType(dt.Rows(0)("IsExists"), Boolean)

        Return isExists

    End Function


    Private Function GetSecurityQuestion(ByVal userID As Object, ByVal login As String, ByVal siteName As String) As DataRow

        Dim cmd As IDbCommand = CreateSPCommand("spPerson_GetSecurityQuestion", Connection)
        If (userID Is Nothing) Then
            AddParam(cmd, "@Login", login)
            AddParam(cmd, "@SiteName", siteName)
        Else
            AddParam(cmd, "@UserID", userID)
        End If

        Dim dt As DataTable = ExecTable(cmd)

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then Return Nothing
        Return dt.Rows(0)
    End Function


    Public Function GetSecurityQuestion(ByVal userID As Object) As DataRow
        Return GetSecurityQuestion(userID, "", "")
    End Function

    Public Function GetSecurityQuestion(ByVal login As String, ByVal siteName As String) As DataRow
        Return GetSecurityQuestion(Nothing, login, siteName)
    End Function


    Public Sub UpdatePassword(ByVal employeeID As Object, ByVal password As String, ByVal question As String, ByVal answer As String)

        Dim cmd As IDbCommand = CreateSPCommand("spPerson_UpdatePassword", Connection)
        AddParam(cmd, "@UserID", employeeID)
        AddParam(cmd, "@Password", password)
        AddParam(cmd, "@Question", question)
        AddParam(cmd, "@Answer", answer)

        ExecCommand(cmd, Connection, Nothing, True)

    End Sub


End Class
