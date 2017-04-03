<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SamplesVariants
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SamplesVariants))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.cbVariantMode = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbSampleTypeNew = New DevExpress.XtraEditors.LookUpEdit()
        Me.OriginalGrid = New DevExpress.XtraGrid.GridControl()
        Me.OriginalGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colSampleID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.btnApply = New DevExpress.XtraEditors.SimpleButton()
        Me.SpinEdit1 = New DevExpress.XtraEditors.SpinEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.VariantGrid = New DevExpress.XtraGrid.GridControl()
        Me.VariantGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colParent = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbSampleOriginal = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colSampleIDNew = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSpecimenType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbNewSampleType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colFunctional = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbDepartment = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colLocation = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbLocation = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colComment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.memoEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.btnLocation = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.btnBarcodes = New bv.common.win.BarcodeButton()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.cbVariantMode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSampleTypeNew.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OriginalGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OriginalGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SpinEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VariantGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VariantGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSampleOriginal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbNewSampleType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDepartment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.memoEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        resources.ApplyResources(Me.SplitContainer1, "SplitContainer1")
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbVariantMode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbSampleTypeNew)
        Me.SplitContainer1.Panel1.Controls.Add(Me.OriginalGrid)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnApply)
        Me.SplitContainer1.Panel1.Controls.Add(Me.SpinEdit1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.VariantGrid)
        '
        'cbVariantMode
        '
        resources.ApplyResources(Me.cbVariantMode, "cbVariantMode")
        Me.cbVariantMode.Name = "cbVariantMode"
        Me.cbVariantMode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbVariantMode.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbVariantMode.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbVariantMode.Properties.Columns"), resources.GetString("cbVariantMode.Properties.Columns1"))})
        Me.cbVariantMode.Properties.DisplayMember = "Value"
        Me.cbVariantMode.Properties.NullText = resources.GetString("cbVariantMode.Properties.NullText")
        Me.cbVariantMode.Properties.ShowHeader = False
        Me.cbVariantMode.Properties.ValueMember = "Key"
        '
        'cbSampleTypeNew
        '
        resources.ApplyResources(Me.cbSampleTypeNew, "cbSampleTypeNew")
        Me.cbSampleTypeNew.Name = "cbSampleTypeNew"
        Me.cbSampleTypeNew.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSampleTypeNew.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbSampleTypeNew.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbSampleTypeNew.Properties.Columns"), resources.GetString("cbSampleTypeNew.Properties.Columns1"))})
        Me.cbSampleTypeNew.Properties.DisplayMember = "name"
        Me.cbSampleTypeNew.Properties.NullText = resources.GetString("cbSampleTypeNew.Properties.NullText")
        Me.cbSampleTypeNew.Properties.ShowHeader = False
        Me.cbSampleTypeNew.Properties.ValueMember = "idfsDerivativeType"
        '
        'OriginalGrid
        '
        resources.ApplyResources(Me.OriginalGrid, "OriginalGrid")
        Me.OriginalGrid.MainView = Me.OriginalGridView
        Me.OriginalGrid.Name = "OriginalGrid"
        Me.OriginalGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.OriginalGridView})
        '
        'OriginalGridView
        '
        Me.OriginalGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colSampleID, Me.GridColumn2})
        Me.OriginalGridView.GridControl = Me.OriginalGrid
        Me.OriginalGridView.Name = "OriginalGridView"
        Me.OriginalGridView.OptionsBehavior.Editable = False
        Me.OriginalGridView.OptionsNavigation.EnterMoveNextColumn = True
        Me.OriginalGridView.OptionsSelection.MultiSelect = True
        Me.OriginalGridView.OptionsView.ShowGroupPanel = False
        '
        'colSampleID
        '
        resources.ApplyResources(Me.colSampleID, "colSampleID")
        Me.colSampleID.FieldName = "strBarcode"
        Me.colSampleID.Name = "colSampleID"
        '
        'GridColumn2
        '
        resources.ApplyResources(Me.GridColumn2, "GridColumn2")
        Me.GridColumn2.FieldName = "NewItems"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'btnApply
        '
        resources.ApplyResources(Me.btnApply, "btnApply")
        Me.btnApply.Image = Global.EIDSS.My.Resources.Resources.add
        Me.btnApply.Name = "btnApply"
        '
        'SpinEdit1
        '
        resources.ApplyResources(Me.SpinEdit1, "SpinEdit1")
        Me.SpinEdit1.Name = "SpinEdit1"
        Me.SpinEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.SpinEdit1.Properties.IsFloatValue = False
        Me.SpinEdit1.Properties.Mask.EditMask = resources.GetString("SpinEdit1.Properties.Mask.EditMask")
        Me.SpinEdit1.Properties.MaxValue = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.SpinEdit1.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'VariantGrid
        '
        resources.ApplyResources(Me.VariantGrid, "VariantGrid")
        Me.VariantGrid.MainView = Me.VariantGridView
        Me.VariantGrid.Name = "VariantGrid"
        Me.VariantGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbSampleOriginal, Me.btnLocation, Me.cbDepartment, Me.cbLocation, Me.memoEdit, Me.cbNewSampleType})
        Me.VariantGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.VariantGridView})
        '
        'VariantGridView
        '
        Me.VariantGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colParent, Me.colSampleIDNew, Me.colSpecimenType, Me.colFunctional, Me.colLocation, Me.colComment})
        Me.VariantGridView.GridControl = Me.VariantGrid
        Me.VariantGridView.Name = "VariantGridView"
        Me.VariantGridView.OptionsNavigation.EnterMoveNextColumn = True
        Me.VariantGridView.OptionsSelection.MultiSelect = True
        Me.VariantGridView.OptionsView.RowAutoHeight = True
        Me.VariantGridView.OptionsView.ShowGroupPanel = False
        '
        'colParent
        '
        resources.ApplyResources(Me.colParent, "colParent")
        Me.colParent.ColumnEdit = Me.cbSampleOriginal
        Me.colParent.FieldName = "idfParentContainer"
        Me.colParent.Name = "colParent"
        Me.colParent.OptionsColumn.AllowEdit = False
        '
        'cbSampleOriginal
        '
        Me.cbSampleOriginal.DisplayMember = "strBarcode"
        Me.cbSampleOriginal.Name = "cbSampleOriginal"
        resources.ApplyResources(Me.cbSampleOriginal, "cbSampleOriginal")
        Me.cbSampleOriginal.ReadOnly = True
        Me.cbSampleOriginal.ValueMember = "idfContainer"
        '
        'colSampleIDNew
        '
        resources.ApplyResources(Me.colSampleIDNew, "colSampleIDNew")
        Me.colSampleIDNew.FieldName = "strBarcode"
        Me.colSampleIDNew.Name = "colSampleIDNew"
        Me.colSampleIDNew.OptionsColumn.AllowEdit = False
        '
        'colSpecimenType
        '
        resources.ApplyResources(Me.colSpecimenType, "colSpecimenType")
        Me.colSpecimenType.ColumnEdit = Me.cbNewSampleType
        Me.colSpecimenType.FieldName = "idfsSpecimenType"
        Me.colSpecimenType.Name = "colSpecimenType"
        Me.colSpecimenType.OptionsColumn.AllowEdit = False
        '
        'cbNewSampleType
        '
        resources.ApplyResources(Me.cbNewSampleType, "cbNewSampleType")
        Me.cbNewSampleType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbNewSampleType.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbNewSampleType.Name = "cbNewSampleType"
        '
        'colFunctional
        '
        resources.ApplyResources(Me.colFunctional, "colFunctional")
        Me.colFunctional.ColumnEdit = Me.cbDepartment
        Me.colFunctional.FieldName = "idfInDepartment"
        Me.colFunctional.Name = "colFunctional"
        '
        'cbDepartment
        '
        resources.ApplyResources(Me.cbDepartment, "cbDepartment")
        Me.cbDepartment.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDepartment.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbDepartment.DisplayMember = "Name"
        Me.cbDepartment.Name = "cbDepartment"
        Me.cbDepartment.ValueMember = "idfDepartment"
        '
        'colLocation
        '
        resources.ApplyResources(Me.colLocation, "colLocation")
        Me.colLocation.ColumnEdit = Me.cbLocation
        Me.colLocation.FieldName = "idfSubdivision"
        Me.colLocation.Name = "colLocation"
        '
        'cbLocation
        '
        resources.ApplyResources(Me.cbLocation, "cbLocation")
        Me.cbLocation.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbLocation.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbLocation.Name = "cbLocation"
        '
        'colComment
        '
        resources.ApplyResources(Me.colComment, "colComment")
        Me.colComment.ColumnEdit = Me.memoEdit
        Me.colComment.FieldName = "strNote"
        Me.colComment.Name = "colComment"
        '
        'memoEdit
        '
        Me.memoEdit.Name = "memoEdit"
        '
        'btnLocation
        '
        resources.ApplyResources(Me.btnLocation, "btnLocation")
        Me.btnLocation.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.btnLocation.Name = "btnLocation"
        Me.btnLocation.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'GridColumn1
        '
        resources.ApplyResources(Me.GridColumn1, "GridColumn1")
        Me.GridColumn1.FieldName = "Path"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'btnBarcodes
        '
        resources.ApplyResources(Me.btnBarcodes, "btnBarcodes")
        Me.btnBarcodes.Name = "btnBarcodes"
        Me.btnBarcodes.Tag = "{AlwaysEditable}"
        '
        'SamplesVariants
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnBarcodes)
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormID = "L06"
        Me.HelpTopicID = "SampleAliquoteForm"
        Me.LeftIcon = CType(resources.GetObject("$this.LeftIcon"), System.Drawing.Image)
        Me.Name = "SamplesVariants"
        Me.ShowCancelButton = False
        Me.ShowDeleteButton = False
        Me.ShowSaveButton = False
        Me.Sizable = True
        Me.Controls.SetChildIndex(Me.cmdOk, 0)
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        Me.Controls.SetChildIndex(Me.btnBarcodes, 0)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.cbVariantMode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSampleTypeNew.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OriginalGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OriginalGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SpinEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VariantGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VariantGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSampleOriginal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbNewSampleType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDepartment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbLocation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.memoEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnLocation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OriginalGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents OriginalGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SpinEdit1 As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents VariantGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents VariantGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents colSampleID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSampleIDNew As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSpecimenType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFunctional As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLocation As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnApply As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbSampleTypeNew As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cbSampleOriginal As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colParent As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnLocation As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents cbDepartment As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cbVariantMode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbLocation As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colComment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents memoEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents cbNewSampleType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents btnBarcodes As bv.common.win.BarcodeButton
End Class
