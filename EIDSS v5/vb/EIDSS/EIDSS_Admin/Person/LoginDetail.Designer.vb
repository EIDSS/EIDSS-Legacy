<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginDetail
    Inherits bv.common.win.BaseDetailForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginDetail))
        Me.txtConfirmPassword = New DevExpress.XtraEditors.TextEdit()
        Me.lbConfirmPassword = New System.Windows.Forms.Label()
        Me.txtPassword = New DevExpress.XtraEditors.TextEdit()
        Me.lbPassword = New System.Windows.Forms.Label()
        Me.txtUserLogin = New DevExpress.XtraEditors.TextEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbSite = New System.Windows.Forms.Label()
        Me.LookUpEdit1 = New DevExpress.XtraEditors.LookUpEdit()
        CType(Me.txtConfirmPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUserLogin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtConfirmPassword
        '
        resources.ApplyResources(Me.txtConfirmPassword, "txtConfirmPassword")
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.Properties.AutoHeight = CType(resources.GetObject("txtConfirmPassword.Properties.AutoHeight"), Boolean)
        Me.txtConfirmPassword.Properties.Mask.EditMask = resources.GetString("txtConfirmPassword.Properties.Mask.EditMask")
        Me.txtConfirmPassword.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtConfirmPassword.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtConfirmPassword.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtConfirmPassword.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtConfirmPassword.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtConfirmPassword.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtConfirmPassword.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmPassword.Tag = "{M}"
        '
        'lbConfirmPassword
        '
        resources.ApplyResources(Me.lbConfirmPassword, "lbConfirmPassword")
        Me.lbConfirmPassword.Name = "lbConfirmPassword"
        '
        'txtPassword
        '
        resources.ApplyResources(Me.txtPassword, "txtPassword")
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Properties.AutoHeight = CType(resources.GetObject("txtPassword.Properties.AutoHeight"), Boolean)
        Me.txtPassword.Properties.Mask.EditMask = resources.GetString("txtPassword.Properties.Mask.EditMask")
        Me.txtPassword.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtPassword.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtPassword.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtPassword.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtPassword.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtPassword.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtPassword.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Tag = "{M}"
        '
        'lbPassword
        '
        resources.ApplyResources(Me.lbPassword, "lbPassword")
        Me.lbPassword.Name = "lbPassword"
        '
        'txtUserLogin
        '
        resources.ApplyResources(Me.txtUserLogin, "txtUserLogin")
        Me.txtUserLogin.Name = "txtUserLogin"
        Me.txtUserLogin.Properties.AutoHeight = CType(resources.GetObject("txtUserLogin.Properties.AutoHeight"), Boolean)
        Me.txtUserLogin.Properties.Mask.EditMask = resources.GetString("txtUserLogin.Properties.Mask.EditMask")
        Me.txtUserLogin.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtUserLogin.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtUserLogin.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtUserLogin.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtUserLogin.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtUserLogin.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtUserLogin.Properties.MaxLength = 200
        Me.txtUserLogin.Tag = "{M}"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'lbSite
        '
        resources.ApplyResources(Me.lbSite, "lbSite")
        Me.lbSite.Name = "lbSite"
        '
        'LookUpEdit1
        '
        resources.ApplyResources(Me.LookUpEdit1, "LookUpEdit1")
        Me.LookUpEdit1.Name = "LookUpEdit1"
        Me.LookUpEdit1.Properties.AutoHeight = CType(resources.GetObject("LookUpEdit1.Properties.AutoHeight"), Boolean)
        Me.LookUpEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("LookUpEdit1.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.LookUpEdit1.Tag = "{M}"
        '
        'LoginDetail
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LookUpEdit1)
        Me.Controls.Add(Me.lbSite)
        Me.Controls.Add(Me.txtConfirmPassword)
        Me.Controls.Add(Me.lbConfirmPassword)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.lbPassword)
        Me.Controls.Add(Me.txtUserLogin)
        Me.Controls.Add(Me.Label7)
        Me.FormID = "A31"
        Me.HelpTopicID = " EmployeeDetailForm"
        Me.LeftIcon = Global.EIDSS.My.Resources.Resources.User_Login_129_1_
        Me.Name = "LoginDetail"
        Me.ShowDeleteButton = False
        Me.ShowSaveButton = False
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.txtUserLogin, 0)
        Me.Controls.SetChildIndex(Me.lbPassword, 0)
        Me.Controls.SetChildIndex(Me.txtPassword, 0)
        Me.Controls.SetChildIndex(Me.lbConfirmPassword, 0)
        Me.Controls.SetChildIndex(Me.txtConfirmPassword, 0)
        Me.Controls.SetChildIndex(Me.lbSite, 0)
        Me.Controls.SetChildIndex(Me.LookUpEdit1, 0)
        CType(Me.txtConfirmPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUserLogin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtConfirmPassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbConfirmPassword As System.Windows.Forms.Label
    Friend WithEvents txtPassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbPassword As System.Windows.Forms.Label
    Friend WithEvents txtUserLogin As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbSite As System.Windows.Forms.Label
    Friend WithEvents LookUpEdit1 As DevExpress.XtraEditors.LookUpEdit
End Class
