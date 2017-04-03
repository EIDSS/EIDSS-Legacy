Imports bv.common.Resources
Imports bv.winclient.Layout
Imports bv.winclient.Core

Public Class AboutForm
    Inherits BvForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        HelpTopicId = Help2.HomePage
        'Add any initialization after the InitializeComponent() call
        'lbAppName.Text = Application.ProductName
        lbVersionNumber.Text = Application.ProductVersion
        lbCopyright.Text = BvMessages.Get("msgEIDSSCopyright")
        LayoutCorrector.ApplySystemFont(Me)

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Friend WithEvents lbCopyright As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbVersionNumber As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbVersion As DevExpress.XtraEditors.LabelControl

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnOk As DevExpress.XtraEditors.SimpleButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutForm))
        Me.btnOk = New DevExpress.XtraEditors.SimpleButton()
        Me.lbCopyright = New DevExpress.XtraEditors.LabelControl()
        Me.lbVersionNumber = New DevExpress.XtraEditors.LabelControl()
        Me.lbVersion = New DevExpress.XtraEditors.LabelControl()
        Me.SuspendLayout()
        '
        'btnOk
        '
        resources.ApplyResources(Me.btnOk, "btnOk")
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.Name = "btnOk"
        '
        'lbCopyright
        '
        resources.ApplyResources(Me.lbCopyright, "lbCopyright")
        Me.lbCopyright.Appearance.Font = CType(resources.GetObject("lbCopyright.Appearance.Font"), System.Drawing.Font)
        Me.lbCopyright.Appearance.ForeColor = CType(resources.GetObject("lbCopyright.Appearance.ForeColor"), System.Drawing.Color)
        Me.lbCopyright.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lbCopyright.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbCopyright.Name = "lbCopyright"
        '
        'lbVersionNumber
        '
        resources.ApplyResources(Me.lbVersionNumber, "lbVersionNumber")
        Me.lbVersionNumber.Appearance.Font = CType(resources.GetObject("lbVersionNumber.Appearance.Font"), System.Drawing.Font)
        Me.lbVersionNumber.Appearance.ForeColor = CType(resources.GetObject("lbVersionNumber.Appearance.ForeColor"), System.Drawing.Color)
        Me.lbVersionNumber.Name = "lbVersionNumber"
        '
        'lbVersion
        '
        resources.ApplyResources(Me.lbVersion, "lbVersion")
        Me.lbVersion.Appearance.Font = CType(resources.GetObject("lbVersion.Appearance.Font"), System.Drawing.Font)
        Me.lbVersion.Appearance.ForeColor = CType(resources.GetObject("lbVersion.Appearance.ForeColor"), System.Drawing.Color)
        Me.lbVersion.Name = "lbVersion"
        '
        'AboutForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.None
        Me.BackgroundImageStore = CType(resources.GetObject("$this.BackgroundImageStore"), System.Drawing.Image)
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.lbCopyright)
        Me.Controls.Add(Me.lbVersionNumber)
        Me.Controls.Add(Me.lbVersion)
        Me.Controls.Add(Me.btnOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AboutForm"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public Shared Sub ShowMe()
        Using frm As New AboutForm
            frm.ShowDialog()
        End Using
    End Sub

End Class
