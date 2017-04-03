Imports bv.common.win
Imports bv.winclient.Core
Imports EIDSS.model.Resources
Imports bv.common.Enums

Public Class LoginDetail

    'Private Policy As New PasswordPolicy
    Private MinPasswordLength As Integer = 5

    Protected Init As DataSet
    Private MultiSite As Boolean = New StandardAccessPermissions(EIDSS.model.Enums.EIDSSPermissionObject.CreateLoginRemotely).CanExecute
    'Protected Employee As Object

    Protected Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Dim singleChar As Char = Me.txtPassword.Properties.PasswordChar
        Me.txtPassword.Properties.NullText = New String(singleChar, 10)
        Me.txtConfirmPassword.Properties.NullText = New String(singleChar, 10)

        Me.txtPassword.Properties.NullValuePrompt = New String(singleChar, 10)
        Me.txtConfirmPassword.Properties.NullValuePrompt = New String(singleChar, 10)
        'Me.DbService = New Login_DB
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Public Sub New(ByRef ds As DataSet)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Init = ds
        Dim singleChar As Char = Me.txtPassword.Properties.PasswordChar
        Me.txtPassword.Properties.NullText = New String(singleChar, 10)
        Me.txtConfirmPassword.Properties.NullText = New String(singleChar, 10)

        MinPasswordLength = SecurityPolicy_DB.PasswordMinimumLength(Init)

        'Me.txtPassword.Properties.NullValuePrompt = New String(singleChar, 10)
        'Me.txtConfirmPassword.Properties.NullValuePrompt = New String(singleChar, 10)
        'Me.DbService = New Login_DB

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Protected Overrides Sub DefineBinding()
        baseDataSet = Init
        Core.LookupBinder.BindSiteLookup(Me.LookUpEdit1, Init, "UserTable.idfsSite")

        If Me.MultiSite Then
            If Not Init.Tables("UserTable").Rows(0).RowState = DataRowState.Added Then 'existing login is edited
                LookUpEdit1.Enabled = False
                'CType(LookUpEdit1.Properties.DataSource, DataView).RowFilter = String.Format("idfsSite={0}", Init.Tables("UserTable").Rows(0)("idfsSite"))
            Else
                Dim ds As DataSet = CType(StartUpParameters("Dataset"), DataSet)
                Dim filter As String = ""
                For Each r As DataRow In ds.Tables("UserTable").Rows
                    If r.RowState = DataRowState.Deleted Then Continue For
                    Dim site As String = r("idfsSite").ToString
                    If filter <> "" Then
                        filter += ","
                    End If
                    filter += site
                Next
                If filter <> "" Then
                    CType(LookUpEdit1.Properties.DataSource, DataView).RowFilter = String.Format("not idfsSite in ({0})", filter)
                End If
                Init.Tables("UserTable").Rows(0)("idfsSite") = CType(LookUpEdit1.Properties.DataSource, DataView)(0)("idfsSite")
            End If
        Else
            LookUpEdit1.Enabled = False
            Init.Tables("UserTable").Rows(0)("idfsSite") = EIDSS.model.Core.EidssSiteContext.Instance.SiteID
            'CType(LookUpEdit1.Properties.DataSource, DataView).RowFilter = String.Format("idfsSite={0}", EIDSS.model.Core.EidssSiteContext.Instance.SiteID)
        End If
        For Each btn As DevExpress.XtraEditors.Controls.EditorButton In Me.LookUpEdit1.Properties.Buttons
            If btn.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete Then btn.Visible = False
        Next
        'If .Count >= 2 Then Me.LookUpEdit1.Properties.Buttons(1).Visible = False
        Core.LookupBinder.BindTextEdit(txtUserLogin, Init, "UserTable.strAccountName")
        'Core.LookupBinder.BindTextEdit(txtPassword, Init, "UserTable.strPassword")
        'txtConfirmPassword.EditValue = Init.Tables("UserTable").Rows(0)("strPassword")
        txtPassword.EditValue = Nothing
        txtConfirmPassword.EditValue = Nothing
        'txtPassword.StyleController = MyBase.MandatoryFieldStyleController
        'txtConfirmPassword.StyleController = MyBase.MandatoryFieldStyleController
        'Me.txtPassword.Tag = Nothing
        'Me.txtConfirmPassword.Tag = Nothing
        'Me.txtPassword.StyleController = Me.txtUserLogin.StyleController
        'Me.txtConfirmPassword.StyleController = Me.txtUserLogin.StyleController

        eventManager.AttachDataHandler("UserTable.idfsSite", AddressOf Site_Changed)
        eventManager.Cascade("UserTable.idfsSite")
    End Sub

    Public Overrides Function Post(Optional ByVal postType As PostType = PostType.FinalPosting) As Boolean
        DataEventManager.Flush()
        If HasChanges() = False Then Return True
        Dim DefaultResult As DialogResult = DialogResult.Yes
        FindForm.BringToFront()
        m_PromptResult = SavePromptDialog(DefaultResult)
        If (m_ClosingMode = ClosingMode.Cancel) Then
            Return m_PromptResult = DialogResult.Yes
        End If
        If m_PromptResult = DialogResult.No Then
            Return False
        End If
        RaiseBeforeValidatingEvent()
        If ValidateData() = False Then
            m_PromptResult = DialogResult.Cancel
            Return False
        Else
            m_PromptResult = DialogResult.Yes
        End If
        Return True

    End Function

    Public Overrides Function ValidateData() As Boolean
        'Dim res As Boolean = MyBase.ValidateData()
        'If Not res Then Return False

        If txtUserLogin.Text.Length = 0 Then
            ErrorForm.ShowMessage("msgEmptyLogin", "Login is not defined.")
            txtUserLogin.Select()
            Return False
        End If

        If (txtPassword.Text <> txtConfirmPassword.Text) Then
            ErrorForm.ShowMessage("msgPasswordNotTheSame", "Confirm password is incorrect.")
            txtConfirmPassword.Select()
            Return False
        End If

        Dim row As DataRow = Init.Tables("UserTable").Rows(0)
        If row.RowState = DataRowState.Added Then
            If (Utils.IsEmpty(Me.txtPassword.EditValue)) Then
                ErrorForm.ShowWarningFormat("msgPasswordTooShort", "Password should contain at least {0} characters", MinPasswordLength.ToString)
                Me.txtPassword.Select()
                Return False
            End If
        End If
        If Not (Utils.IsEmpty(Me.txtPassword.EditValue)) Then
            Dim pass As String = Me.txtPassword.EditValue.ToString()
            If pass.Length < MinPasswordLength Then
                ErrorForm.ShowWarningFormat("msgPasswordTooShort", "Password should contain at least {0} characters", MinPasswordLength.ToString)
                Me.txtPassword.Select()
                Return False
            End If

            If Not SecurityPolicy_DB.ValidatePassword(pass, Me.baseDataSet) Then
                Dim err As ErrorMessage = SecurityMessages.GetLoginErrorMessage(8)
                ErrorForm.ShowError(err.Text, err.Exception)
                Return False
            End If

            row("strPassword") = pass
        End If


        Dim PersonDBService As Person_DB = New Person_DB
        Dim result As Integer
        result = PersonDBService.ValidateLogin(row("idfPerson"), row("idfsSite"), row("strAccountName").ToString)
        Select Case result
            Case 1
                ErrorForm.ShowMessage("msgEmptyLogin", "Login is not defined")
            Case 2
                ErrorForm.ShowWarning("msgLoginExist", "User with such login exists already. Please choose other login name.")
            Case -1
                Dim err As ErrorMessage = PersonDBService.LastError
                ErrorForm.ShowErrorDirect(err.Text, err.Exception)
        End Select
        If result <> 0 Then
            txtUserLogin.Select()
            Return False
        End If

        Return True
    End Function

    Private Sub Site_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        'If (Utils.Str(e.Value, "a") = Utils.Str(e.Row("idfsSite"), "b")) Then Exit Sub
        'Dim siteRow As DataRow = LookupCache.GetLookupRow(e.Value, LookupTables.Site.ToString)
        'e.Row("strSiteID") = siteRow("strSiteID")
        'e.Row("strSiteName") = siteRow("strSiteName")
        'e.Row("strSiteType") = siteRow("strSiteType")
    End Sub

    Public Overrides Function HasChanges() As Boolean
        Return MyBase.HasChanges() OrElse Not Utils.IsEmpty(Me.txtPassword.EditValue) OrElse Not Utils.IsEmpty(Me.txtUserLogin)
    End Function

End Class