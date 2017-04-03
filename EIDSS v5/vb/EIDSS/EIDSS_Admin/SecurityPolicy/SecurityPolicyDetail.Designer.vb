<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SecurityPolicyDetail
    Inherits BaseDetailForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SecurityPolicyDetail))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPasswordAge = New DevExpress.XtraEditors.SpinEdit()
        Me.txtPasswordHistory = New DevExpress.XtraEditors.SpinEdit()
        Me.txtLockoutPeriod = New DevExpress.XtraEditors.SpinEdit()
        Me.txtMinimumLength = New DevExpress.XtraEditors.SpinEdit()
        Me.txtLockThreshold = New DevExpress.XtraEditors.SpinEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.txtDescription = New DevExpress.XtraEditors.LabelControl()
        Me.chkPasswordComplexity = New DevExpress.XtraEditors.CheckEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtInactivityTimeout = New DevExpress.XtraEditors.SpinEdit()
        CType(Me.txtPasswordAge.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPasswordHistory.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLockoutPeriod.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMinimumLength.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLockThreshold.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.chkPasswordComplexity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.txtInactivityTimeout.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'txtPasswordAge
        '
        resources.ApplyResources(Me.txtPasswordAge, "txtPasswordAge")
        Me.txtPasswordAge.Name = "txtPasswordAge"
        Me.txtPasswordAge.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtPasswordAge.Properties.IsFloatValue = False
        Me.txtPasswordAge.Properties.Mask.EditMask = resources.GetString("txtPasswordAge.Properties.Mask.EditMask")
        Me.txtPasswordAge.Properties.MaxValue = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtPasswordAge.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtPasswordHistory
        '
        resources.ApplyResources(Me.txtPasswordHistory, "txtPasswordHistory")
        Me.txtPasswordHistory.Name = "txtPasswordHistory"
        Me.txtPasswordHistory.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtPasswordHistory.Properties.EditFormat.FormatString = "D"
        Me.txtPasswordHistory.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPasswordHistory.Properties.IsFloatValue = False
        Me.txtPasswordHistory.Properties.Mask.EditMask = resources.GetString("txtPasswordHistory.Properties.Mask.EditMask")
        Me.txtPasswordHistory.Properties.MaxValue = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'txtLockoutPeriod
        '
        resources.ApplyResources(Me.txtLockoutPeriod, "txtLockoutPeriod")
        Me.txtLockoutPeriod.Name = "txtLockoutPeriod"
        Me.txtLockoutPeriod.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtLockoutPeriod.Properties.IsFloatValue = False
        Me.txtLockoutPeriod.Properties.Mask.EditMask = resources.GetString("txtLockoutPeriod.Properties.Mask.EditMask")
        Me.txtLockoutPeriod.Properties.MaxValue = New Decimal(New Integer() {100, 0, 0, 0})
        Me.txtLockoutPeriod.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtMinimumLength
        '
        resources.ApplyResources(Me.txtMinimumLength, "txtMinimumLength")
        Me.txtMinimumLength.Name = "txtMinimumLength"
        Me.txtMinimumLength.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtMinimumLength.Properties.IsFloatValue = False
        Me.txtMinimumLength.Properties.Mask.EditMask = resources.GetString("txtMinimumLength.Properties.Mask.EditMask")
        Me.txtMinimumLength.Properties.MaxValue = New Decimal(New Integer() {100, 0, 0, 0})
        Me.txtMinimumLength.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtLockThreshold
        '
        resources.ApplyResources(Me.txtLockThreshold, "txtLockThreshold")
        Me.txtLockThreshold.Name = "txtLockThreshold"
        Me.txtLockThreshold.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtLockThreshold.Properties.EditFormat.FormatString = "N00"
        Me.txtLockThreshold.Properties.IsFloatValue = False
        Me.txtLockThreshold.Properties.Mask.EditMask = resources.GetString("txtLockThreshold.Properties.Mask.EditMask")
        Me.txtLockThreshold.Properties.MaxValue = New Decimal(New Integer() {100, 0, 0, 0})
        Me.txtLockThreshold.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'GroupControl2
        '
        resources.ApplyResources(Me.GroupControl2, "GroupControl2")
        Me.GroupControl2.Controls.Add(Me.txtDescription)
        Me.GroupControl2.Controls.Add(Me.chkPasswordComplexity)
        Me.GroupControl2.Controls.Add(Me.Label6)
        Me.GroupControl2.Controls.Add(Me.Label1)
        Me.GroupControl2.Controls.Add(Me.Label3)
        Me.GroupControl2.Controls.Add(Me.Label4)
        Me.GroupControl2.Controls.Add(Me.txtPasswordAge)
        Me.GroupControl2.Controls.Add(Me.txtPasswordHistory)
        Me.GroupControl2.Controls.Add(Me.txtMinimumLength)
        Me.GroupControl2.Name = "GroupControl2"
        '
        'txtDescription
        '
        resources.ApplyResources(Me.txtDescription, "txtDescription")
        Me.txtDescription.Name = "txtDescription"
        '
        'chkPasswordComplexity
        '
        resources.ApplyResources(Me.chkPasswordComplexity, "chkPasswordComplexity")
        Me.chkPasswordComplexity.Name = "chkPasswordComplexity"
        Me.chkPasswordComplexity.Properties.Caption = resources.GetString("chkPasswordComplexity.Properties.Caption")
        Me.chkPasswordComplexity.Properties.GlyphAlignment = CType(resources.GetObject("chkPasswordComplexity.Properties.GlyphAlignment"), DevExpress.Utils.HorzAlignment)
        Me.chkPasswordComplexity.Properties.ValueChecked = 1
        Me.chkPasswordComplexity.Properties.ValueUnchecked = 0
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'GroupControl1
        '
        resources.ApplyResources(Me.GroupControl1, "GroupControl1")
        Me.GroupControl1.Controls.Add(Me.Label7)
        Me.GroupControl1.Controls.Add(Me.txtInactivityTimeout)
        Me.GroupControl1.Controls.Add(Me.Label2)
        Me.GroupControl1.Controls.Add(Me.txtLockoutPeriod)
        Me.GroupControl1.Controls.Add(Me.Label5)
        Me.GroupControl1.Controls.Add(Me.txtLockThreshold)
        Me.GroupControl1.Name = "GroupControl1"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'txtInactivityTimeout
        '
        resources.ApplyResources(Me.txtInactivityTimeout, "txtInactivityTimeout")
        Me.txtInactivityTimeout.Name = "txtInactivityTimeout"
        Me.txtInactivityTimeout.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtInactivityTimeout.Properties.IsFloatValue = False
        Me.txtInactivityTimeout.Properties.Mask.EditMask = resources.GetString("txtInactivityTimeout.Properties.Mask.EditMask")
        Me.txtInactivityTimeout.Properties.MaxValue = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtInactivityTimeout.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'SecurityPolicyDetail
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.FormID = "C03"
        Me.HelpTopicID = "SecurityPolicy"
        Me.LeftIcon = Global.EIDSS.My.Resources.Resources.Security_Policy__large__24_
        Me.Name = "SecurityPolicyDetail"
        Me.ShowDeleteButton = False
        Me.SingleInstance = True
        Me.Controls.SetChildIndex(Me.cmdOk, 0)
        Me.Controls.SetChildIndex(Me.GroupControl1, 0)
        Me.Controls.SetChildIndex(Me.GroupControl2, 0)
        CType(Me.txtPasswordAge.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPasswordHistory.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLockoutPeriod.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMinimumLength.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLockThreshold.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.chkPasswordComplexity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.txtInactivityTimeout.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPasswordAge As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtPasswordHistory As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtLockoutPeriod As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtMinimumLength As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtLockThreshold As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkPasswordComplexity As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtInactivityTimeout As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtDescription As DevExpress.XtraEditors.LabelControl
End Class
