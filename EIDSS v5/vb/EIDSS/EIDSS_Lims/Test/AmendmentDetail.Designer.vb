<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AmendmentDetail
    Inherits bv.common.win.BaseDetailForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AmendmentDetail))
        Me.lbReasonForChange = New DevExpress.XtraEditors.LabelControl()
        Me.lbNewTestResult = New DevExpress.XtraEditors.LabelControl()
        Me.cbNewTestResult = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtReasonForChange = New DevExpress.XtraEditors.TextEdit()
        CType(Me.cbNewTestResult.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtReasonForChange.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        '
        'lbReasonForChange
        '
        Me.lbReasonForChange.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbReasonForChange.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        resources.ApplyResources(Me.lbReasonForChange, "lbReasonForChange")
        Me.lbReasonForChange.Name = "lbReasonForChange"
        '
        'lbNewTestResult
        '
        Me.lbNewTestResult.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbNewTestResult.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        resources.ApplyResources(Me.lbNewTestResult, "lbNewTestResult")
        Me.lbNewTestResult.Name = "lbNewTestResult"
        '
        'cbNewTestResult
        '
        resources.ApplyResources(Me.cbNewTestResult, "cbNewTestResult")
        Me.cbNewTestResult.Name = "cbNewTestResult"
        Me.cbNewTestResult.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbNewTestResult.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbNewTestResult.Tag = "{M}"
        '
        'txtReasonForChange
        '
        resources.ApplyResources(Me.txtReasonForChange, "txtReasonForChange")
        Me.txtReasonForChange.Name = "txtReasonForChange"
        Me.txtReasonForChange.Tag = "{M}"
        '
        'AmendmentDetail
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.txtReasonForChange)
        Me.Controls.Add(Me.cbNewTestResult)
        Me.Controls.Add(Me.lbReasonForChange)
        Me.Controls.Add(Me.lbNewTestResult)
        Me.FormID = "L23"
        Me.HelpTopicID = "lab_tests_amend"
        Me.IgnoreAudit = True
        Me.Name = "AmendmentDetail"
        Me.ShowDeleteButton = False
        Me.ShowSaveButton = False
        Me.Controls.SetChildIndex(Me.lbNewTestResult, 0)
        Me.Controls.SetChildIndex(Me.cmdOk, 0)
        Me.Controls.SetChildIndex(Me.lbReasonForChange, 0)
        Me.Controls.SetChildIndex(Me.cbNewTestResult, 0)
        Me.Controls.SetChildIndex(Me.txtReasonForChange, 0)
        CType(Me.cbNewTestResult.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtReasonForChange.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbReasonForChange As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbNewTestResult As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbNewTestResult As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtReasonForChange As DevExpress.XtraEditors.TextEdit

End Class
