<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BatchSelectTestResult
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BatchSelectTestResult))
        Me.LookUpTestResult = New DevExpress.XtraEditors.LookUpEdit()
        Me.lBatchID = New System.Windows.Forms.Label()
        CType(Me.LookUpTestResult.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        '
        'LookUpTestResult
        '
        resources.ApplyResources(Me.LookUpTestResult, "LookUpTestResult")
        Me.LookUpTestResult.Name = "LookUpTestResult"
        Me.LookUpTestResult.Properties.AccessibleDescription = resources.GetString("LookUpTestResult.Properties.AccessibleDescription")
        Me.LookUpTestResult.Properties.AccessibleName = resources.GetString("LookUpTestResult.Properties.AccessibleName")
        Me.LookUpTestResult.Properties.AutoHeight = CType(resources.GetObject("LookUpTestResult.Properties.AutoHeight"), Boolean)
        Me.LookUpTestResult.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("LookUpTestResult.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.LookUpTestResult.Properties.NullValuePrompt = resources.GetString("LookUpTestResult.Properties.NullValuePrompt")
        Me.LookUpTestResult.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("LookUpTestResult.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.LookUpTestResult.Tag = "{M}"
        '
        'lBatchID
        '
        resources.ApplyResources(Me.lBatchID, "lBatchID")
        Me.lBatchID.Name = "lBatchID"
        '
        'BatchSelectTestResult
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lBatchID)
        Me.Controls.Add(Me.LookUpTestResult)
        Me.FormID = "L26"
        Me.IgnoreAudit = True
        Me.Name = "BatchSelectTestResult"
        Me.ShowDeleteButton = False
        Me.ShowSaveButton = False
        Me.Controls.SetChildIndex(Me.cmdOk, 0)
        Me.Controls.SetChildIndex(Me.LookUpTestResult, 0)
        Me.Controls.SetChildIndex(Me.lBatchID, 0)
        CType(Me.LookUpTestResult.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LookUpTestResult As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lBatchID As System.Windows.Forms.Label
End Class
