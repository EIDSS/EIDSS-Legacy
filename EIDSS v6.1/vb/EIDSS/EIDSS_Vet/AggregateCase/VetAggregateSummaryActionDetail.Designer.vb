<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VetAggregateSummaryActionDetail
    Inherits bv.common.win.BaseDetailForm


    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        AggregateCaseDbService = New VetAggregateSummaryAction_DB

        DbService = AggregateCaseDbService

        PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.AccessToVetAggregateAction
        AggregateSummaryHeader1.CaseType = model.Enums.AggregateCaseType.VetAggregateAction

        'AggregateSummaryHeader1.UseParentDataset = True
        'RegisterChildObject(AggregateSummaryHeader1, RelatedPostOrder.SkipPost)
        'RegisterChildObject(fgDiagnosticAction, RelatedPostOrder.PostLast)
        'RegisterChildObject(fgProphylacticAction, RelatedPostOrder.PostLast)
        'RegisterChildObject(fgSanitaryAction, RelatedPostOrder.PostLast)

        'minYear = 1900
        MenuItem1.Visible = eidss.model.Reports.BaseMenuReportRegistrator.IsPaperFormAllowed("VetAggregateCaseActionsSummary")
    End Sub

    'Public Sub New(ByVal _MinYear As Integer)
    '    MyBase.New()

    '    'This call is required by the Windows Form Designer.
    '    InitializeComponent()
    '    'Add any initialization after the InitializeComponent() call
    '    AggregateCaseDbService = New VetAggregateSummaryAction_DB

    '    DbService = AggregateCaseDbService

    '    PermissionObject = eidss.model.Enums.EIDSSPermissionObject.VetCase

    '    RegisterChildObject(fgDiagnosticAction, RelatedPostOrder.PostLast)
    '    RegisterChildObject(fgProphylacticAction, RelatedPostOrder.PostLast)
    '    RegisterChildObject(fgSanitaryAction, RelatedPostOrder.PostLast)

    '    If (_MinYear) > 0 AndAlso (_MinYear <= Date.Today.Year) Then
    '        minYear = _MinYear
    '    Else
    '        minYear = 1900
    '    End If
    'End Sub

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VetAggregateSummaryActionDetail))
        Me.btnRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.btnViewDetailForm = New DevExpress.XtraEditors.SimpleButton()
        Me.btnShowSummary = New DevExpress.XtraEditors.SimpleButton()
        Me.PopUpButton1 = New bv.winclient.Core.PopUpButton()
        Me.cmRep = New System.Windows.Forms.ContextMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.AggregateSummaryHeader1 = New eidss.winclient.AggregateCase.AggregateSummaryHeader()
        Me.xtcDetailInfo = New DevExpress.XtraTab.XtraTabControl()
        Me.xtpDiagnosticAction = New DevExpress.XtraTab.XtraTabPage()
        Me.fgDiagnosticAction = New EIDSS.FlexibleForms.FFPresenter()
        Me.lbNoDiagnosticActionMatrix = New DevExpress.XtraEditors.LabelControl()
        Me.xtpProphilacticAction = New DevExpress.XtraTab.XtraTabPage()
        Me.fgProphylacticAction = New EIDSS.FlexibleForms.FFPresenter()
        Me.lbNoProphylacticActionMatrix = New DevExpress.XtraEditors.LabelControl()
        Me.xtpSanitaryAction = New DevExpress.XtraTab.XtraTabPage()
        Me.fgSanitaryAction = New EIDSS.FlexibleForms.FFPresenter()
        Me.lbNoSanitaryActionMatrix = New DevExpress.XtraEditors.LabelControl()
        CType(Me.xtcDetailInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.xtcDetailInfo.SuspendLayout()
        Me.xtpDiagnosticAction.SuspendLayout()
        Me.xtpProphilacticAction.SuspendLayout()
        Me.xtpSanitaryAction.SuspendLayout()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(VetAggregateSummaryActionDetail), resources)
        'Form Is Localizable: True
        '
        'btnRefresh
        '
        resources.ApplyResources(Me.btnRefresh, "btnRefresh")
        Me.btnRefresh.Image = Global.EIDSS.My.Resources.Resources.refresh
        Me.btnRefresh.Name = "btnRefresh"
        '
        'btnClose
        '
        resources.ApplyResources(Me.btnClose, "btnClose")
        Me.btnClose.Image = Global.EIDSS.My.Resources.Resources.Close
        Me.btnClose.Name = "btnClose"
        '
        'btnViewDetailForm
        '
        resources.ApplyResources(Me.btnViewDetailForm, "btnViewDetailForm")
        Me.btnViewDetailForm.Image = Global.EIDSS.My.Resources.Resources.View1
        Me.btnViewDetailForm.Name = "btnViewDetailForm"
        '
        'btnShowSummary
        '
        resources.ApplyResources(Me.btnShowSummary, "btnShowSummary")
        Me.btnShowSummary.Name = "btnShowSummary"
        '
        'PopUpButton1
        '
        resources.ApplyResources(Me.PopUpButton1, "PopUpButton1")
        Me.PopUpButton1.ButtonType = bv.winclient.Core.PopUpButton.PopUpButtonStyles.Reports
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
        'AggregateSummaryHeader1
        '
        resources.ApplyResources(Me.AggregateSummaryHeader1, "AggregateSummaryHeader1")
        Me.AggregateSummaryHeader1.CaseType = EIDSS.model.Enums.AggregateCaseType.VetAggregateAction
        Me.AggregateSummaryHeader1.Name = "AggregateSummaryHeader1"
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
        Me.xtpDiagnosticAction.Controls.Add(Me.fgDiagnosticAction)
        Me.xtpDiagnosticAction.Controls.Add(Me.lbNoDiagnosticActionMatrix)
        Me.xtpDiagnosticAction.Name = "xtpDiagnosticAction"
        resources.ApplyResources(Me.xtpDiagnosticAction, "xtpDiagnosticAction")
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
        Me.xtpProphilacticAction.Controls.Add(Me.fgProphylacticAction)
        Me.xtpProphilacticAction.Controls.Add(Me.lbNoProphylacticActionMatrix)
        Me.xtpProphilacticAction.Name = "xtpProphilacticAction"
        resources.ApplyResources(Me.xtpProphilacticAction, "xtpProphilacticAction")
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
        Me.xtpSanitaryAction.Controls.Add(Me.fgSanitaryAction)
        Me.xtpSanitaryAction.Controls.Add(Me.lbNoSanitaryActionMatrix)
        Me.xtpSanitaryAction.Name = "xtpSanitaryAction"
        resources.ApplyResources(Me.xtpSanitaryAction, "xtpSanitaryAction")
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
        'VetAggregateSummaryActionDetail
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.xtcDetailInfo)
        Me.Controls.Add(Me.AggregateSummaryHeader1)
        Me.Controls.Add(Me.PopUpButton1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnViewDetailForm)
        Me.Controls.Add(Me.btnShowSummary)
        Me.Controls.Add(Me.btnRefresh)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "V14"
        Me.HelpTopicID = "VC_V14"
        Me.KeyFieldName = "idfAggrCase"
        Me.LeftIcon = Global.EIDSS.My.Resources.Resources.Vet_Aggregate_Actions_Summary__large__06_
        Me.Name = "VetAggregateSummaryActionDetail"
        Me.ObjectName = "VetAggregateSummaryAction"
        Me.ShowCancelButton = False
        Me.ShowDeleteButton = False
        Me.ShowOkButton = False
        Me.ShowSaveButton = False
        Me.Sizable = True
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "AggregateHeader"
        Me.Controls.SetChildIndex(Me.btnRefresh, 0)
        Me.Controls.SetChildIndex(Me.btnShowSummary, 0)
        Me.Controls.SetChildIndex(Me.btnViewDetailForm, 0)
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.Controls.SetChildIndex(Me.PopUpButton1, 0)
        Me.Controls.SetChildIndex(Me.AggregateSummaryHeader1, 0)
        Me.Controls.SetChildIndex(Me.xtcDetailInfo, 0)
        CType(Me.xtcDetailInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.xtcDetailInfo.ResumeLayout(False)
        Me.xtpDiagnosticAction.ResumeLayout(False)
        Me.xtpProphilacticAction.ResumeLayout(False)
        Me.xtpSanitaryAction.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnViewDetailForm As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnShowSummary As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PopUpButton1 As bv.winclient.Core.PopUpButton
    Friend WithEvents cmRep As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents AggregateSummaryHeader1 As EIDSS.winclient.AggregateCase.AggregateSummaryHeader
    Friend WithEvents xtcDetailInfo As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents xtpDiagnosticAction As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents fgDiagnosticAction As EIDSS.FlexibleForms.FFPresenter
    Friend WithEvents lbNoDiagnosticActionMatrix As DevExpress.XtraEditors.LabelControl
    Friend WithEvents xtpProphilacticAction As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents fgProphylacticAction As EIDSS.FlexibleForms.FFPresenter
    Friend WithEvents lbNoProphylacticActionMatrix As DevExpress.XtraEditors.LabelControl
    Friend WithEvents xtpSanitaryAction As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents fgSanitaryAction As EIDSS.FlexibleForms.FFPresenter
    Friend WithEvents lbNoSanitaryActionMatrix As DevExpress.XtraEditors.LabelControl

End Class
