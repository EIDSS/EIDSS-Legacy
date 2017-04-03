<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VetAggregateCaseDetail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VetAggregateCaseDetail))
        Me.gbDiseaseList = New System.Windows.Forms.GroupBox()
        Me.cbMatrixVersion = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.lbFormTemplate = New DevExpress.XtraEditors.LabelControl()
        Me.cbFormTemplate = New DevExpress.XtraEditors.LookUpEdit()
        Me.lbMatrixVersion = New DevExpress.XtraEditors.LabelControl()
        Me.fgAggregateData = New EIDSS.FlexibleForms.FFPresenter()
        Me.lbNoVetCaseMatrix = New DevExpress.XtraEditors.LabelControl()
        Me.PopUpButton1 = New bv.common.win.PopUpButton()
        Me.cmRep = New System.Windows.Forms.ContextMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.AggregateHeader1 = New EIDSS.AggregateHeader()
        Me.gbDiseaseList.SuspendLayout()
        CType(Me.cbMatrixVersion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbFormTemplate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(VetAggregateCaseDetail), resources)
        'Form Is Localizable: True
        '
        'gbDiseaseList
        '
        resources.ApplyResources(Me.gbDiseaseList, "gbDiseaseList")
        Me.gbDiseaseList.Controls.Add(Me.cbMatrixVersion)
        Me.gbDiseaseList.Controls.Add(Me.lbFormTemplate)
        Me.gbDiseaseList.Controls.Add(Me.cbFormTemplate)
        Me.gbDiseaseList.Controls.Add(Me.lbMatrixVersion)
        Me.gbDiseaseList.Controls.Add(Me.fgAggregateData)
        Me.gbDiseaseList.Controls.Add(Me.lbNoVetCaseMatrix)
        Me.gbDiseaseList.Name = "gbDiseaseList"
        Me.gbDiseaseList.TabStop = False
        '
        'cbMatrixVersion
        '
        resources.ApplyResources(Me.cbMatrixVersion, "cbMatrixVersion")
        Me.cbMatrixVersion.Name = "cbMatrixVersion"
        Me.cbMatrixVersion.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbMatrixVersion.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        '
        'lbFormTemplate
        '
        resources.ApplyResources(Me.lbFormTemplate, "lbFormTemplate")
        Me.lbFormTemplate.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.lbFormTemplate.Name = "lbFormTemplate"
        '
        'cbFormTemplate
        '
        resources.ApplyResources(Me.cbFormTemplate, "cbFormTemplate")
        Me.cbFormTemplate.Name = "cbFormTemplate"
        Me.cbFormTemplate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbFormTemplate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        '
        'lbMatrixVersion
        '
        resources.ApplyResources(Me.lbMatrixVersion, "lbMatrixVersion")
        Me.lbMatrixVersion.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.lbMatrixVersion.Name = "lbMatrixVersion"
        '
        'fgAggregateData
        '
        resources.ApplyResources(Me.fgAggregateData, "fgAggregateData")
        Me.fgAggregateData.DelayedLoadingNeeded = False
        Me.fgAggregateData.DynamicParameterEnabled = False
        Me.fgAggregateData.FormID = Nothing
        Me.fgAggregateData.HelpTopicID = Nothing
        Me.fgAggregateData.KeyFieldName = Nothing
        Me.fgAggregateData.MultiSelect = False
        Me.fgAggregateData.Name = "fgAggregateData"
        Me.fgAggregateData.ObjectName = Nothing
        Me.fgAggregateData.SectionTableCaptionsIsVisible = True
        Me.fgAggregateData.TableName = Nothing
        '
        'lbNoVetCaseMatrix
        '
        Me.lbNoVetCaseMatrix.Appearance.ForeColor = CType(resources.GetObject("lbNoVetCaseMatrix.Appearance.ForeColor"), System.Drawing.Color)
        Me.lbNoVetCaseMatrix.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lbNoVetCaseMatrix.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        resources.ApplyResources(Me.lbNoVetCaseMatrix, "lbNoVetCaseMatrix")
        Me.lbNoVetCaseMatrix.Name = "lbNoVetCaseMatrix"
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
        'VetAggregateCaseDetail
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.AggregateHeader1)
        Me.Controls.Add(Me.PopUpButton1)
        Me.Controls.Add(Me.gbDiseaseList)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "V10"
        Me.HelpTopicID = "VC_V10"
        Me.KeyFieldName = "idfAggrCase"
        Me.LeftIcon = Global.EIDSS.My.Resources.Resources.Vet_Aggregate_Entry__large_
        Me.MinHeight = 600
        Me.MinimumSize = New System.Drawing.Size(1000, 600)
        Me.MinWidth = 1000
        Me.Name = "VetAggregateCaseDetail"
        Me.ObjectName = "VetAggregateCase"
        Me.ShowDeleteButton = False
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "AggregateHeader"
        Me.Controls.SetChildIndex(Me.gbDiseaseList, 0)
        Me.Controls.SetChildIndex(Me.PopUpButton1, 0)
        Me.Controls.SetChildIndex(Me.AggregateHeader1, 0)
        Me.gbDiseaseList.ResumeLayout(False)
        CType(Me.cbMatrixVersion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbFormTemplate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbDiseaseList As System.Windows.Forms.GroupBox
    Friend WithEvents PopUpButton1 As bv.common.win.PopUpButton
    Friend WithEvents cmRep As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents AggregateHeader1 As EIDSS.AggregateHeader
    Friend WithEvents fgAggregateData As EIDSS.FlexibleForms.FFPresenter
    Friend WithEvents lbNoVetCaseMatrix As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbMatrixVersion As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents lbMatrixVersion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbFormTemplate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbFormTemplate As DevExpress.XtraEditors.LookUpEdit
End Class
