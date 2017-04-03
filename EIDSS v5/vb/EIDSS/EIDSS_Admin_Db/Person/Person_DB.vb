Imports System.Data
'Imports System.Data.SqlClient
Imports System.Data.Common
Imports bv.common.db.Core
Imports bv.common.Core
Imports EIDSS.model.Core.Security
Imports bv.common.db.Security

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

            Dim PersonDetail_Adapter As DbDataAdapter = CreateAdapter(cmd, False)

            PersonDetail_Adapter.Fill(ds, TablePerson)
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
            'cmd = CreateSPCommand("spPasswordPolicy_List")
            'CreateAdapter(cmd, False).Fill(ds, TablePolicy)
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function

    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal PostType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
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
                        Me.m_Error = SecurityMessages.GetLoginErrorMessage(res)
                        Return False
                    End If
                Next
            End If
            'Add any other posting here if needed
            ' Alexander - Oct 2008
            'If (Utils.IsPACS) Then
            '    SetPasswordExpiration(ds.Tables(TableUser).Rows(0), transaction)
            'End If
            bv.common.db.Core.LookupCache.NotifyChange("Person", transaction, ID)

            'SecurityCache_DB.NewUser(UserID)

        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function


    Public Function SetLogin(ByVal ds As DataSet, ByVal login As String, ByVal passowrd As String) As Boolean
        If ds.Tables(Person_DB.TableUser).Rows.Count = 0 Then
            Dim r As DataRow = ds.Tables(Person_DB.TableUser).NewRow
            r.BeginEdit()
            r("idfUserID") = NewIntID()
            r("idfPerson") = ID
            r("idfsSite") = EIDSS.model.Core.EidssSiteContext.Instance.SiteID
            r("strAccountName") = login
            r("strPassword") = passowrd
            r.EndEdit()
            ds.Tables(Person_DB.TableUser).Rows.Add(r)
        Else
            Dim r As DataRow = ds.Tables(Person_DB.TableUser).Rows(0)
            r.BeginEdit()
            r("strAccountName") = login
            r("strPassword") = passowrd
            r.EndEdit()
        End If
        Return True
    End Function

    Public Sub DeleteLogin(ByVal ds As DataSet)
        If ds.Tables(Person_DB.TableUser).Rows.Count > 0 Then
            For i As Integer = ds.Tables(Person_DB.TableUser).Rows.Count - 1 To 0
                If ds.Tables(Person_DB.TableUser).Rows(i).RowState <> DataRowState.Deleted Then
                    ds.Tables(Person_DB.TableUser).Rows(i).Delete()
                End If
            Next
        End If
    End Sub
    '0 - no such login
    '1 - empty UserName/organization
    '2 - login exists
    '-1 - db error
    Public Function ValidateLogin(ByVal login As String) As Integer
        Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("dbo.spLogin_Validate", Connection)
        BaseDbService.AddParam(cmd, "@idfPerson", ID)
        BaseDbService.AddParam(cmd, "@UserName", login)
        BaseDbService.AddParam(cmd, "@Result", 0, ParameterDirection.Output)
        m_Error = ExecCommand(cmd, Connection)
        If m_Error Is Nothing Then
            Return CInt(BaseDbService.GetParamValue(cmd, "@Result"))
        Else
            Return -1
        End If
    End Function

    '0 - no such login
    '1 - empty UserName/organization
    '2 - login exists
    '-1 - db error
    Public Function ValidateLogin(ByVal Employee As Object, ByVal Site As Object, ByVal login As String) As Integer
        Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("dbo.spLogin_Validate", Connection)
        BaseDbService.AddParam(cmd, "@idfPerson", Employee)
        BaseDbService.AddParam(cmd, "@idfsSite", Site)
        BaseDbService.AddParam(cmd, "@strAccountName", login)
        BaseDbService.AddParam(cmd, "@Result", 0, ParameterDirection.Output)
        m_Error = ExecCommand(cmd, Connection)
        If m_Error Is Nothing Then
            Return CInt(BaseDbService.GetParamValue(cmd, "@Result"))
        Else
            Return -1
        End If
    End Function


    Public Sub SetPasswordExpiration(ByVal dr As DataRow, Optional ByVal transaction As IDbTransaction = Nothing)

        Dim UserID As Integer = CType(dr("idfUserID"), Integer)
        Dim UserMustChange As Boolean = CType(dr("MustChangePassword"), Boolean)
        Dim ExpirMonths As Integer = CType(dr("intExpirationPeriod"), Integer)
        SetPasswordExpiration(UserID, ExpirMonths, UserMustChange, transaction)
    End Sub

    Public Sub SetPasswordExpiration(ByVal UserID As Integer, ByVal UserMustChange As Boolean)
        SetPasswordExpiration(UserID, -1, UserMustChange)
    End Sub

    Sub SetPasswordExpiration(ByVal UserID As Integer, ByVal ExpirMonths As Integer, ByVal UserMustChange As Boolean, Optional ByVal transaction As IDbTransaction = Nothing)

        Dim ExpirationDate As DateTime

        If (ExpirMonths = 0) Then
            ExpirMonths = 12 * 100 ' Pass Never Expired ;)
            ExpirationDate = New DateTime(2100, 1, 1)
        Else
            ExpirationDate = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddMonths(ExpirMonths)
        End If

        If (UserMustChange) Then ExpirationDate = DateTime.Now()


        Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spPerson_SetPasswordExpiration", Connection)
        BaseDbService.AddParam(cmd, "@UserID", UserID)
        BaseDbService.AddParam(cmd, "@ExpirationDate", ExpirationDate)

        If (ExpirMonths > -1) Then ' do not change ExpirationPerion if ExpirMonths= -1
            BaseDbService.AddParam(cmd, "@ExpirationPeriod", ExpirMonths)
        End If



        BaseDbService.ExecCommand(cmd, Connection, transaction, True)

    End Sub




    Public Sub GetPasswordExpiration(ByVal EmployeeID As Object, ByVal LoginName As String, ByRef ExpirationDate As DateTime)

        ExpirationDate = New DateTime(2100, 1, 1)

        Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spPerson_CheckNeedChangePassword", Connection)
        BaseDbService.AddParam(cmd, "@EmployeeID", EmployeeID)
        BaseDbService.AddParam(cmd, "@LoginName", LoginName)
        Dim dt As DataTable = BaseDbService.ExecTable(cmd)

        If (dt.Rows.Count = 0) Then Return

        If (IsDBNull(dt.Rows(0)("ExpirationDate")) = False) Then
            ExpirationDate = CType(dt.Rows(0)("ExpirationDate"), DateTime)
        End If

    End Sub




    Public Function IsPasswordAlreadyUsed(ByVal EmployeeID As Object, ByVal Password As String) As Boolean

        Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spPerson_CheckPasswordReuse", Connection)
        BaseDbService.AddParam(cmd, "@EmployeeID", EmployeeID)
        BaseDbService.AddParam(cmd, "@Password", Password)
        Dim dt As DataTable = BaseDbService.ExecTable(cmd)

        Dim IsExists As Boolean = CType(dt.Rows(0)("IsExists"), Boolean)

        Return IsExists

    End Function


    Private Function GetSecurityQuestion(ByVal UserID As Object, ByVal Login As String, ByVal SiteName As String) As DataRow

        Dim IsExists As Boolean = False

        Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spPerson_GetSecurityQuestion", Connection)
        If (UserID Is Nothing) Then
            BaseDbService.AddParam(cmd, "@Login", Login)
            BaseDbService.AddParam(cmd, "@SiteName", SiteName)
        Else
            BaseDbService.AddParam(cmd, "@UserID", UserID)
        End If

        Dim dt As DataTable = BaseDbService.ExecTable(cmd)

        If (dt.Rows.Count = 0) Then Return Nothing

        Return dt.Rows(0)

    End Function


    Public Function GetSecurityQuestion(ByVal UserID As Object) As DataRow
        Return GetSecurityQuestion(UserID, "", "")
    End Function

    Public Function GetSecurityQuestion(ByVal Login As String, ByVal SiteName As String) As DataRow
        Return GetSecurityQuestion(Nothing, Login, SiteName)
    End Function


    Public Sub UpdatePassword(ByVal EmployeeID As Object, ByVal Password As String, ByVal Question As String, ByVal Answer As String)

        Dim IsExists As Boolean = False

        Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spPerson_UpdatePassword", Connection)
        BaseDbService.AddParam(cmd, "@UserID", EmployeeID)
        BaseDbService.AddParam(cmd, "@Password", Password)
        BaseDbService.AddParam(cmd, "@Question", Question)
        BaseDbService.AddParam(cmd, "@Answer", Answer)

        BaseDbService.ExecCommand(cmd, Connection, Nothing, True)

    End Sub


End Class
