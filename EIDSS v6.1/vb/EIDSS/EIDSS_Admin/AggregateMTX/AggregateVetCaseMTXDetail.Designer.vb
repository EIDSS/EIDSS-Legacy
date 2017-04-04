<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AggregateVetCaseMTXDetail
    Inherits AggregateMatrixBase



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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AggregateVetCaseMTXDetail))
        Me.gcMTX = New DevExpress.XtraGrid.GridControl()
        Me.gvMTX = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gcolID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolDiagnosis = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbDiagnosis = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.gcolICD10Code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolSpecies = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbSpecies = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.cbICD10Code = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.pnMatrix = New DevExpress.XtraEditors.GroupControl()
        CType(Me.gcMTX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvMTX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDiagnosis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSpecies, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbICD10Code, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnMatrix, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnMatrix.SuspendLayout()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(AggregateVetCaseMTXDetail), resources)
        'Form Is Localizable: True
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
        Me.gvMTX.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gcolID, Me.gcolDiagnosis, Me.gcolICD10Code, Me.gcolSpecies})
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
        'gcolID
        '
        Me.gcolID.AppearanceHeader.Font = CType(resources.GetObject("gcolID.AppearanceHeader.Font"), System.Drawing.Font)
        Me.gcolID.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolID, "gcolID")
        Me.gcolID.FieldName = "idfAggregatedVetCaseMTXRow"
        Me.gcolID.Name = "gcolID"
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
        Me.gcolICD10Code.FieldName = "strOIECode"
        Me.gcolICD10Code.Name = "gcolICD10Code"
        Me.gcolICD10Code.OptionsColumn.AllowEdit = False
        Me.gcolICD10Code.OptionsColumn.ReadOnly = True
        Me.gcolICD10Code.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
        '
        'gcolSpecies
        '
        Me.gcolSpecies.AppearanceHeader.Font = CType(resources.GetObject("gcolSpecies.AppearanceHeader.Font"), System.Drawing.Font)
        Me.gcolSpecies.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolSpecies, "gcolSpecies")
        Me.gcolSpecies.ColumnEdit = Me.cbSpecies
        Me.gcolSpecies.FieldName = "idfsSpeciesType"
        Me.gcolSpecies.Name = "gcolSpecies"
        Me.gcolSpecies.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
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
        'pnMatrix
        '
        resources.ApplyResources(Me.pnMatrix, "pnMatrix")
        Me.pnMatrix.Controls.Add(Me.gcMTX)
        Me.pnMatrix.Name = "pnMatrix"
        '
        'AggregateVetCaseMTXDetail
        '
        Me.Appearance.Font = CType(resources.GetObject("AggregateVetCaseMTXDetail.Appearance.Font"), System.Drawing.Font)
        Me.Appearance.Options.UseFont = True
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.pnMatrix)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "A11"
        Me.HelpTopicID = "Vet_Aggregate_Case_Matrix_Edit"
        Me.KeyFieldName = "idfAggrVetCaseMTX"
        Me.LeftIcon = Global.EIDSS.My.Resources.Resources.Reference_Matrix__large__46_
        Me.Name = "AggregateVetCaseMTXDetail"
        Me.ObjectName = "AggregateVetCaseMTX"
        Me.ShowDeleteButton = False
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "AggregateVetCaseMatrix"
        Me.Controls.SetChildIndex(Me.pnMatrix, 0)
        CType(Me.gcMTX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvMTX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDiagnosis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSpecies, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbICD10Code, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnMatrix, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnMatrix.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gcMTX As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvMTX As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gcolID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolDiagnosis As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolSpecies As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbDiagnosis As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents gcolICD10Code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbSpecies As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cbICD10Code As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents pnMatrix As DevExpress.XtraEditors.GroupControl
End Class
