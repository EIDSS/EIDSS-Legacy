<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VetAggregateActionDetail
    Inherits bv.common.win.BaseDetailForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VetAggregateActionDetail))
        Me.PopUpButton1 = New bv.common.win.PopUpButton()
        Me.cmRep = New System.Windows.Forms.ContextMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.AggregateHeader1 = New EIDSS.AggregateHeader()
        Me.xtcDetailInfo = New DevExpress.XtraTab.XtraTabControl()
        Me.xtpDiagnosticAction = New DevExpress.XtraTab.XtraTabPage()
        Me.lbDiagnosticFormTemplate = New DevExpress.XtraEditors.LabelControl()
        Me.cbDiagnosticFormTemplate = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbDiagnosticMatrixVersion = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.lbDiagnosticMatrixVersion = New DevExpress.XtraEditors.LabelControl()
        Me.fgDiagnosticAction = New EIDSS.FlexibleForms.FFPresenter()
        Me.lbNoDiagnosticActionMatrix = New DevExpress.XtraEditors.LabelControl()
        Me.xtpProphilacticAction = New DevExpress.XtraTab.XtraTabPage()
        Me.lbProphylacticFormTemplate = New DevExpress.XtraEditors.LabelControl()
        Me.cbProphylacticFormTemplate = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbProphylacticMatrixVersion = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.lbProphylacticMatrixVersion = New DevExpress.XtraEditors.LabelControl()
        Me.fgProphylacticAction = New EIDSS.FlexibleForms.FFPresenter()
        Me.lbNoProphylacticActionMatrix = New DevExpress.XtraEditors.LabelControl()
        Me.xtpSanitaryAction = New DevExpress.XtraTab.XtraTabPage()
        Me.lbSanitaryFormTemplate = New DevExpress.XtraEditors.LabelControl()
        Me.cbSanitaryFormTemplate = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbSanitaryMatrixVersion = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.lbSanitaryMatrixVersion = New DevExpress.XtraEditors.LabelControl()
        Me.fgSanitaryAction = New EIDSS.FlexibleForms.FFPresenter()
        Me.lbNoSanitaryActionMatrix = New DevExpress.XtraEditors.LabelControl()
        CType(Me.xtcDetailInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.xtcDetailInfo.SuspendLayout()
        Me.xtpDiagnosticAction.SuspendLayout()
        CType(Me.cbDiagnosticFormTemplate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDiagnosticMatrixVersion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.xtpProphilacticAction.SuspendLayout()
        CType(Me.cbProphylacticFormTemplate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbProphylacticMatrixVersion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.xtpSanitaryAction.SuspendLayout()
        CType(Me.cbSanitaryFormTemplate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSanitaryMatrixVersion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(VetAggregateActionDetail), resources)
        'Form Is Localizable: True
        '
        'PopUpButton1
        '
        resources.ApplyResources(Me.PopUpButton1, "PopUpButton1")
        Me.PopUpButton1.ButtonType = bv.common.win.PopUpButton.PopUpButtonStyles.Reports
        Me.PopUpButton1.Name = "PopUpButton1"
        Me.PopUpButton1.PopUpMenu = Me.cmRep
        Me.PopUpButton1.Tag = "{Immovable}{AlwaysEditable}"
        '
        'cmRep
        '
        Me.cmRep.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        resources.ApplyResources(Me.MenuItem1, "MenuItem1")
        '
        'AggregateHeader1
        '
        resources.ApplyResources(Me.AggregateHeader1, "AggregateHeader1")
        Me.AggregateHeader1.FormID = Nothing
        Me.AggregateHeader1.HelpTopicID = Nothing
        Me.AggregateHeader1.KeyFieldName = "idfAggrCase"
        Me.AggregateHeader1.MultiSelect = False
        Me.AggregateHeader1.Name = "AggregateHeader1"
        Me.AggregateHeader1.ObjectName = "AggregateHeader"
        Me.AggregateHeader1.TableName = "AggregateHeader"
        '
        'xtcDetailInfo
        '
        resources.ApplyResources(Me.xtcDetailInfo, "xtcDetailInfo")
        Me.xtcDetailInfo.Name = "xtcDetailInfo"
        Me.xtcDetailInfo.SelectedTabPage = Me.xtpDiagnosticAction
        Me.xtcDetailInfo.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.xtpDiagnosticAction, Me.xtpProphilacticAction, Me.xtpSanitaryAction})
        '
        'xtpDiagnosticAction
        '
        Me.xtpDiagnosticAction.Controls.Add(Me.lbDiagnosticFormTemplate)
        Me.xtpDiagnosticAction.Controls.Add(Me.cbDiagnosticFormTemplate)
        Me.xtpDiagnosticAction.Controls.Add(Me.cbDiagnosticMatrixVersion)
        Me.xtpDiagnosticAction.Controls.Add(Me.lbDiagnosticMatrixVersion)
        Me.xtpDiagnosticAction.Controls.Add(Me.fgDiagnosticAction)
        Me.xtpDiagnosticAction.Controls.Add(Me.lbNoDiagnosticActionMatrix)
        Me.xtpDiagnosticAction.Name = "xtpDiagnosticAction"
        resources.ApplyResources(Me.xtpDiagnosticAction, "xtpDiagnosticAction")
        '
        'lbDiagnosticFormTemplate
        '
        resources.ApplyResources(Me.lbDiagnosticFormTemplate, "lbDiagnosticFormTemplate")
        Me.lbDiagnosticFormTemplate.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.lbDiagnosticFormTemplate.Name = "lbDiagnosticFormTemplate"
        '
        'cbDiagnosticFormTemplate
        '
        resources.ApplyResources(Me.cbDiagnosticFormTemplate, "cbDiagnosticFormTemplate")
        Me.cbDiagnosticFormTemplate.Name = "cbDiagnosticFormTemplate"
        Me.cbDiagnosticFormTemplate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDiagnosticFormTemplate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        '
        'cbDiagnosticMatrixVersion
        '
        resources.ApplyResources(Me.cbDiagnosticMatrixVersion, "cbDiagnosticMatrixVersion")
        Me.cbDiagnosticMatrixVersion.Name = "cbDiagnosticMatrixVersion"
        Me.cbDiagnosticMatrixVersion.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDiagnosticMatrixVersion.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        '
        'lbDiagnosticMatrixVersion
        '
        resources.ApplyResources(Me.lbDiagnosticMatrixVersion, "lbDiagnosticMatrixVersion")
        Me.lbDiagnosticMatrixVersion.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.lbDiagnosticMatrixVersion.Name = "lbDiagnosticMatrixVersion"
        '
        'fgDiagnosticAction
        '
        resources.ApplyResources(Me.fgDiagnosticAction, "fgDiagnosticAction")
        Me.fgDiagnosticAction.DelayedLoadingNeeded = False
        Me.fgDiagnosticAction.DynamicParameterEnabled = False
        Me.fgDiagnosticAction.FormID = Nothing
        Me.fgDiagnosticAction.HelpTopicID = Nothing
        Me.fgDiagnosticAction.KeyFieldName = Nothing
        Me.fgDiagnosticAction.MultiSelect = False
        Me.fgDiagnosticAction.Name = "fgDiagnosticAction"
        Me.fgDiagnosticAction.ObjectName = Nothing
        Me.fgDiagnosticAction.SectionTableCaptionsIsVisible = True
        Me.fgDiagnosticAction.TableName = Nothing
        '
        'lbNoDiagnosticActionMatrix
        '
        Me.lbNoDiagnosticActionMatrix.Appearance.ForeColor = CType(resources.GetObject("lbNoDiagnosticActionMatrix.Appearance.ForeColor"), System.Drawing.Color)
        Me.lbNoDiagnosticActionMatrix.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lbNoDiagnosticActionMatrix.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        resources.ApplyResources(Me.lbNoDiagnosticActionMatrix, "lbNoDiagnosticActionMatrix")
        Me.lbNoDiagnosticActionMatrix.Name = "lbNoDiagnosticActionMatrix"
        '
        'xtpProphilacticAction
        '
        Me.xtpProphilacticAction.Controls.Add(Me.lbProphylacticFormTemplate)
        Me.xtpProphilacticAction.Controls.Add(Me.cbProphylacticFormTemplate)
        Me.xtpProphilacticAction.Controls.Add(Me.cbProphylacticMatrixVersion)
        Me.xtpProphilacticAction.Controls.Add(Me.lbProphylacticMatrixVersion)
        Me.xtpProphilacticAction.Controls.Add(Me.fgProphylacticAction)
        Me.xtpProphilacticAction.Controls.Add(Me.lbNoProphylacticActionMatrix)
        Me.xtpProphilacticAction.Name = "xtpProphilacticAction"
        resources.ApplyResources(Me.xtpProphilacticAction, "xtpProphilacticAction")
        '
        'lbProphylacticFormTemplate
        '
        resources.ApplyResources(Me.lbProphylacticFormTemplate, "lbProphylacticFormTemplate")
        Me.lbProphylacticFormTemplate.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.lbProphylacticFormTemplate.Name = "lbProphylacticFormTemplate"
        '
        'cbProphylacticFormTemplate
        '
        resources.ApplyResources(Me.cbProphylacticFormTemplate, "cbProphylacticFormTemplate")
        Me.cbProphylacticFormTemplate.Name = "cbProphylacticFormTemplate"
        Me.cbProphylacticFormTemplate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbProphylacticFormTemplate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        '
        'cbProphylacticMatrixVersion
        '
        resources.ApplyResources(Me.cbProphylacticMatrixVersion, "cbProphylacticMatrixVersion")
        Me.cbProphylacticMatrixVersion.Name = "cbProphylacticMatrixVersion"
        Me.cbProphylacticMatrixVersion.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbProphylacticMatrixVersion.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        '
        'lbProphylacticMatrixVersion
        '
        resources.ApplyResources(Me.lbProphylacticMatrixVersion, "lbProphylacticMatrixVersion")
        Me.lbProphylacticMatrixVersion.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.lbProphylacticMatrixVersion.Name = "lbProphylacticMatrixVersion"
        '
        'fgProphylacticAction
        '
        resources.ApplyResources(Me.fgProphylacticAction, "fgProphylacticAction")
        Me.fgProphylacticAction.DelayedLoadingNeeded = False
        Me.fgProphylacticAction.DynamicParameterEnabled = False
        Me.fgProphylacticAction.FormID = Nothing
        Me.fgProphylacticAction.HelpTopicID = Nothing
        Me.fgProphylacticAction.KeyFieldName = Nothing
        Me.fgProphylacticAction.MultiSelect = False
        Me.fgProphylacticAction.Name = "fgProphylacticAction"
        Me.fgProphylacticAction.ObjectName = Nothing
        Me.fgProphylacticAction.SectionTableCaptionsIsVisible = True
        Me.fgProphylacticAction.TableName = Nothing
        '
        'lbNoProphylacticActionMatrix
        '
        Me.lbNoProphylacticActionMatrix.Appearance.ForeColor = CType(resources.GetObject("lbNoProphylacticActionMatrix.Appearance.ForeColor"), System.Drawing.Color)
        Me.lbNoProphylacticActionMatrix.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lbNoProphylacticActionMatrix.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        resources.ApplyResources(Me.lbNoProphylacticActionMatrix, "lbNoProphylacticActionMatrix")
        Me.lbNoProphylacticActionMatrix.Name = "lbNoProphylacticActionMatrix"
        '
        'xtpSanitaryAction
        '
        Me.xtpSanitaryAction.Controls.Add(Me.lbSanitaryFormTemplate)
        Me.xtpSanitaryAction.Controls.Add(Me.cbSanitaryFormTemplate)
        Me.xtpSanitaryAction.Controls.Add(Me.cbSanitaryMatrixVersion)
        Me.xtpSanitaryAction.Controls.Add(Me.lbSanitaryMatrixVersion)
        Me.xtpSanitaryAction.Controls.Add(Me.fgSanitaryAction)
        Me.xtpSanitaryAction.Controls.Add(Me.lbNoSanitaryActionMatrix)
        Me.xtpSanitaryAction.Name = "xtpSanitaryAction"
        resources.ApplyResources(Me.xtpSanitaryAction, "xtpSanitaryAction")
        '
        'lbSanitaryFormTemplate
        '
        resources.ApplyResources(Me.lbSanitaryFormTemplate, "lbSanitaryFormTemplate")
        Me.lbSanitaryFormTemplate.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.lbSanitaryFormTemplate.Name = "lbSanitaryFormTemplate"
        '
        'cbSanitaryFormTemplate
        '
        resources.ApplyResources(Me.cbSanitaryFormTemplate, "cbSanitaryFormTemplate")
        Me.cbSanitaryFormTemplate.Name = "cbSanitaryFormTemplate"
        Me.cbSanitaryFormTemplate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSanitaryFormTemplate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        '
        'cbSanitaryMatrixVersion
        '
        resources.ApplyResources(Me.cbSanitaryMatrixVersion, "cbSanitaryMatrixVersion")
        Me.cbSanitaryMatrixVersion.Name = "cbSanitaryMatrixVersion"
        Me.cbSanitaryMatrixVersion.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSanitaryMatrixVersion.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        '
        'lbSanitaryMatrixVersion
        '
        resources.ApplyResources(Me.lbSanitaryMatrixVersion, "lbSanitaryMatrixVersion")
        Me.lbSanitaryMatrixVersion.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.lbSanitaryMatrixVersion.Name = "lbSanitaryMatrixVersion"
        '
        'fgSanitaryAction
        '
        resources.ApplyResources(Me.fgSanitaryAction, "fgSanitaryAction")
        Me.fgSanitaryAction.DelayedLoadingNeeded = False
        Me.fgSanitaryAction.DynamicParameterEnabled = False
        Me.fgSanitaryAction.FormID = Nothing
        Me.fgSanitaryAction.HelpTopicID = Nothing
        Me.fgSanitaryAction.KeyFieldName = Nothing
        Me.fgSanitaryAction.MultiSelect = False
        Me.fgSanitaryAction.Name = "fgSanitaryAction"
        Me.fgSanitaryAction.ObjectName = Nothing
        Me.fgSanitaryAction.SectionTableCaptionsIsVisible = True
        Me.fgSanitaryAction.TableName = Nothing
        '
        'lbNoSanitaryActionMatrix
        '
        Me.lbNoSanitaryActionMatrix.Appearance.ForeColor = CType(resources.GetObject("lbNoSanitaryActionMatrix.Appearance.ForeColor"), System.Drawing.Color)
        Me.lbNoSanitaryActionMatrix.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lbNoSanitaryActionMatrix.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        resources.ApplyResources(Me.lbNoSanitaryActionMatrix, "lbNoSanitaryActionMatrix")
        Me.lbNoSanitaryActionMatrix.Name = "lbNoSanitaryActionMatrix"
        '
        'VetAggregateActionDetail
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.xtcDetailInfo)
        Me.Controls.Add(Me.AggregateHeader1)
        Me.Controls.Add(Me.PopUpButton1)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "V12"
        Me.HelpTopicID = "VC_V12"
        Me.KeyFieldName = "idfAggrCase"
        Me.LeftIcon = Global.EIDSS.My.Resources.Resources.Vet_Aggregate_Actions_Entry__large_
        Me.MinHeight = 600
        Me.MinimumSize = New System.Drawing.Size(1000, 600)
        Me.MinWidth = 1000
        Me.Name = "VetAggregateActionDetail"
        Me.ObjectName = "VetAggregateAction"
        Me.ShowDeleteButton = False
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "AggregateHeader"
        Me.Controls.SetChildIndex(Me.PopUpButton1, 0)
        Me.Controls.SetChildIndex(Me.AggregateHeader1, 0)
        Me.Controls.SetChildIndex(Me.xtcDetailInfo, 0)
        CType(Me.xtcDetailInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.xtcDetailInfo.ResumeLayout(False)
        Me.xtpDiagnosticAction.ResumeLayout(False)
        CType(Me.cbDiagnosticFormTemplate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDiagnosticMatrixVersion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.xtpProphilacticAction.ResumeLayout(False)
        CType(Me.cbProphylacticFormTemplate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbProphylacticMatrixVersion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.xtpSanitaryAction.ResumeLayout(False)
        CType(Me.cbSanitaryFormTemplate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSanitaryMatrixVersion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PopUpButton1 As bv.common.win.PopUpButton
    Friend WithEvents cmRep As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents AggregateHeader1 As EIDSS.AggregateHeader
    Friend WithEvents xtcDetailInfo As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents xtpDiagnosticAction As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents xtpProphilacticAction As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents fgDiagnosticAction As EIDSS.FlexibleForms.FFPresenter
    Friend WithEvents fgProphylacticAction As EIDSS.FlexibleForms.FFPresenter
    Friend WithEvents xtpSanitaryAction As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents fgSanitaryAction As EIDSS.FlexibleForms.FFPresenter
    Friend WithEvents lbNoDiagnosticActionMatrix As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbNoSanitaryActionMatrix As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbNoProphylacticActionMatrix As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbSanitaryMatrixVersion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbDiagnosticMatrixVersion As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents cbSanitaryMatrixVersion As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents cbProphylacticMatrixVersion As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents lbDiagnosticMatrixVersion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbProphylacticMatrixVersion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbSanitaryFormTemplate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbSanitaryFormTemplate As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lbDiagnosticFormTemplate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbDiagnosticFormTemplate As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lbProphylacticFormTemplate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbProphylacticFormTemplate As DevExpress.XtraEditors.LookUpEdit

End Class
