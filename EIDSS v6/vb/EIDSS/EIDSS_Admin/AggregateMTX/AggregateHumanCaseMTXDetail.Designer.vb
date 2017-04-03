<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AggregateHumanCaseMTXDetail
    Inherits EIDSS.AggregateMatrixBase

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AggregateHumanCaseMTXDetail))
        Me.pnMatrix = New DevExpress.XtraEditors.GroupControl()
        Me.gcMTX = New DevExpress.XtraGrid.GridControl()
        Me.gvMTX = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gcolDiagnosis = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbDiagnosis = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.gcolICD10Code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbSpecies = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.cbICD10Code = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        CType(Me.pnMatrix, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnMatrix.SuspendLayout()
        CType(Me.gcMTX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvMTX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDiagnosis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSpecies, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbICD10Code, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(AggregateHumanCaseMTXDetail), resources)
        'Form Is Localizable: True
        '
        'pnMatrix
        '
        Me.pnMatrix.Controls.Add(Me.gcMTX)
        resources.ApplyResources(Me.pnMatrix, "pnMatrix")
        Me.pnMatrix.Name = "pnMatrix"
        '
        'gcMTX
        '
        resources.ApplyResources(Me.gcMTX, "gcMTX")
        Me.gcMTX.MainView = Me.gvMTX
        Me.gcMTX.Name = "gcMTX"
        Me.gcMTX.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbDiagnosis, Me.cbSpecies, Me.cbICD10Code})
        Me.gcMTX.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvMTX})
        '
        'gvMTX
        '
        Me.gvMTX.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gcolDiagnosis, Me.gcolICD10Code})
        Me.gvMTX.GridControl = Me.gcMTX
        resources.ApplyResources(Me.gvMTX, "gvMTX")
        Me.gvMTX.Name = "gvMTX"
        Me.gvMTX.OptionsCustomization.AllowFilter = False
        Me.gvMTX.OptionsCustomization.AllowGroup = False
        Me.gvMTX.OptionsCustomization.AllowSort = False
        Me.gvMTX.OptionsNavigation.AutoFocusNewRow = True
        Me.gvMTX.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.gvMTX.OptionsView.ShowGroupPanel = False
        '
        'gcolDiagnosis
        '
        Me.gcolDiagnosis.AppearanceHeader.Font = CType(resources.GetObject("gcolDiagnosis.AppearanceHeader.Font"), System.Drawing.Font)
        Me.gcolDiagnosis.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolDiagnosis, "gcolDiagnosis")
        Me.gcolDiagnosis.ColumnEdit = Me.cbDiagnosis
        Me.gcolDiagnosis.FieldName = "idfsDiagnosis"
        Me.gcolDiagnosis.Name = "gcolDiagnosis"
        Me.gcolDiagnosis.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
        '
        'cbDiagnosis
        '
        resources.ApplyResources(Me.cbDiagnosis, "cbDiagnosis")
        Me.cbDiagnosis.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDiagnosis.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbDiagnosis.Name = "cbDiagnosis"
        '
        'gcolICD10Code
        '
        resources.ApplyResources(Me.gcolICD10Code, "gcolICD10Code")
        Me.gcolICD10Code.FieldName = "strIDC10"
        Me.gcolICD10Code.Name = "gcolICD10Code"
        Me.gcolICD10Code.OptionsColumn.AllowEdit = False
        Me.gcolICD10Code.OptionsColumn.ReadOnly = True
        Me.gcolICD10Code.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
        '
        'cbSpecies
        '
        resources.ApplyResources(Me.cbSpecies, "cbSpecies")
        Me.cbSpecies.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSpecies.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbSpecies.Name = "cbSpecies"
        '
        'cbICD10Code
        '
        resources.ApplyResources(Me.cbICD10Code, "cbICD10Code")
        Me.cbICD10Code.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbICD10Code.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbICD10Code.Name = "cbICD10Code"
        '
        'AggregateHumanCaseMTXDetail
        '
        Me.Appearance.Font = CType(resources.GetObject("AggregateHumanCaseMTXDetail.Appearance.Font"), System.Drawing.Font)
        Me.Appearance.Options.UseFont = True
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.pnMatrix)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "A15"
        Me.HelpTopicID = "Human_Aggregate_Case_Matrix_Ed"
        Me.KeyFieldName = "idfHumanCaseMtx"
        Me.LeftIcon = Global.eidss.My.Resources.Resources.Reference_Matrix__large__46_
        Me.Name = "AggregateHumanCaseMTXDetail"
        Me.ObjectName = "HumanAggregateCaseMatrix"
        Me.ShowDeleteButton = False
        Me.Status = bv.common.win.FormStatus.Draft
        Me.Controls.SetChildIndex(Me.pnMatrix, 0)
        CType(Me.pnMatrix, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnMatrix.ResumeLayout(False)
        CType(Me.gcMTX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvMTX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDiagnosis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSpecies, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbICD10Code, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnMatrix As DevExpress.XtraEditors.GroupControl
    Friend WithEvents gcMTX As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvMTX As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gcolDiagnosis As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbDiagnosis As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents gcolICD10Code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbSpecies As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cbICD10Code As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit

End Class
