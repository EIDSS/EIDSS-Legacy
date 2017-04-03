<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AssignTestsList
    Inherits BaseDetailForm

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AssignTestsList))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TestGrid = New DevExpress.XtraGrid.GridControl()
        Me.TestGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colTestName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTestType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbTestType2 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.cbDiagnosis = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.cmdRemove = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.AssignedGrid = New DevExpress.XtraGrid.GridControl()
        Me.AssignedGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colAssignedSample = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAssignedTestName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAssignedTestType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbTestType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colAssignedDiagnosis = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.ContainerGrid = New DevExpress.XtraGrid.GridControl()
        Me.ContainerGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colSampleID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDiagnosis = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbCaseDiagnosis = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.cbCaseDiagnosisEditor = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colName = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.TestGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TestGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTestType2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDiagnosis.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AssignedGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AssignedGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTestType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.ContainerGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ContainerGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCaseDiagnosis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCaseDiagnosisEditor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        resources.ApplyResources(Me.SplitContainer1, "SplitContainer1")
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TestGrid)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbDiagnosis)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelControl1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmdRemove)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmdAdd)
        Me.SplitContainer1.Panel2.Controls.Add(Me.AssignedGrid)
        '
        'TestGrid
        '
        resources.ApplyResources(Me.TestGrid, "TestGrid")
        Me.TestGrid.MainView = Me.TestGridView
        Me.TestGrid.Name = "TestGrid"
        Me.TestGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbTestType2})
        Me.TestGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.TestGridView})
        '
        'TestGridView
        '
        Me.TestGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colTestName, Me.colTestType})
        Me.TestGridView.GridControl = Me.TestGrid
        Me.TestGridView.Name = "TestGridView"
        Me.TestGridView.OptionsNavigation.EnterMoveNextColumn = True
        Me.TestGridView.OptionsSelection.MultiSelect = True
        Me.TestGridView.OptionsView.ShowGroupPanel = False
        Me.TestGridView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colTestName, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'colTestName
        '
        resources.ApplyResources(Me.colTestName, "colTestName")
        Me.colTestName.FieldName = "TestName"
        Me.colTestName.Name = "colTestName"
        Me.colTestName.OptionsColumn.AllowEdit = False
        '
        'colTestType
        '
        resources.ApplyResources(Me.colTestType, "colTestType")
        Me.colTestType.ColumnEdit = Me.cbTestType2
        Me.colTestType.FieldName = "idfsTestForDiseaseType"
        Me.colTestType.Name = "colTestType"
        Me.colTestType.OptionsColumn.AllowEdit = False
        '
        'cbTestType2
        '
        resources.ApplyResources(Me.cbTestType2, "cbTestType2")
        Me.cbTestType2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTestType2.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbTestType2.DisplayMember = "name"
        Me.cbTestType2.Name = "cbTestType2"
        Me.cbTestType2.ValueMember = "idfsReference"
        '
        'cbDiagnosis
        '
        resources.ApplyResources(Me.cbDiagnosis, "cbDiagnosis")
        Me.cbDiagnosis.Name = "cbDiagnosis"
        Me.cbDiagnosis.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDiagnosis.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbDiagnosis.Properties.NullText = resources.GetString("cbDiagnosis.Properties.NullText")
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LabelControl1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        resources.ApplyResources(Me.LabelControl1, "LabelControl1")
        Me.LabelControl1.Name = "LabelControl1"
        '
        'cmdRemove
        '
        resources.ApplyResources(Me.cmdRemove, "cmdRemove")
        Me.cmdRemove.Image = Global.EIDSS.My.Resources.Resources.Delete_Remove
        Me.cmdRemove.Name = "cmdRemove"
        '
        'cmdAdd
        '
        resources.ApplyResources(Me.cmdAdd, "cmdAdd")
        Me.cmdAdd.Image = Global.EIDSS.My.Resources.Resources.add
        Me.cmdAdd.Name = "cmdAdd"
        '
        'AssignedGrid
        '
        resources.ApplyResources(Me.AssignedGrid, "AssignedGrid")
        Me.AssignedGrid.MainView = Me.AssignedGridView
        Me.AssignedGrid.Name = "AssignedGrid"
        Me.AssignedGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbTestType})
        Me.AssignedGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.AssignedGridView})
        '
        'AssignedGridView
        '
        Me.AssignedGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colAssignedSample, Me.colAssignedTestName, Me.colAssignedTestType, Me.colAssignedDiagnosis})
        Me.AssignedGridView.GridControl = Me.AssignedGrid
        Me.AssignedGridView.Name = "AssignedGridView"
        Me.AssignedGridView.OptionsNavigation.EnterMoveNextColumn = True
        Me.AssignedGridView.OptionsSelection.MultiSelect = True
        Me.AssignedGridView.OptionsView.ShowGroupPanel = False
        '
        'colAssignedSample
        '
        resources.ApplyResources(Me.colAssignedSample, "colAssignedSample")
        Me.colAssignedSample.FieldName = "strBarcode"
        Me.colAssignedSample.Name = "colAssignedSample"
        Me.colAssignedSample.OptionsColumn.ReadOnly = True
        '
        'colAssignedTestName
        '
        resources.ApplyResources(Me.colAssignedTestName, "colAssignedTestName")
        Me.colAssignedTestName.FieldName = "TestName"
        Me.colAssignedTestName.Name = "colAssignedTestName"
        Me.colAssignedTestName.OptionsColumn.AllowEdit = False
        '
        'colAssignedTestType
        '
        resources.ApplyResources(Me.colAssignedTestType, "colAssignedTestType")
        Me.colAssignedTestType.ColumnEdit = Me.cbTestType
        Me.colAssignedTestType.FieldName = "idfsTestForDiseaseType"
        Me.colAssignedTestType.Name = "colAssignedTestType"
        '
        'cbTestType
        '
        resources.ApplyResources(Me.cbTestType, "cbTestType")
        Me.cbTestType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTestType.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbTestType.DisplayMember = "name"
        Me.cbTestType.Name = "cbTestType"
        Me.cbTestType.ValueMember = "idfsReference"
        '
        'colAssignedDiagnosis
        '
        resources.ApplyResources(Me.colAssignedDiagnosis, "colAssignedDiagnosis")
        Me.colAssignedDiagnosis.FieldName = "idfsDiagnosis"
        Me.colAssignedDiagnosis.Name = "colAssignedDiagnosis"
        Me.colAssignedDiagnosis.OptionsColumn.AllowEdit = False
        '
        'SplitContainer2
        '
        resources.ApplyResources(Me.SplitContainer2, "SplitContainer2")
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.ContainerGrid)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer1)
        '
        'ContainerGrid
        '
        resources.ApplyResources(Me.ContainerGrid, "ContainerGrid")
        Me.ContainerGrid.MainView = Me.ContainerGridView
        Me.ContainerGrid.Name = "ContainerGrid"
        Me.ContainerGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbCaseDiagnosis, Me.cbCaseDiagnosisEditor})
        Me.ContainerGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ContainerGridView})
        '
        'ContainerGridView
        '
        Me.ContainerGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colSampleID, Me.colDiagnosis})
        Me.ContainerGridView.GridControl = Me.ContainerGrid
        Me.ContainerGridView.Name = "ContainerGridView"
        Me.ContainerGridView.OptionsNavigation.EnterMoveNextColumn = True
        Me.ContainerGridView.OptionsView.ShowGroupPanel = False
        '
        'colSampleID
        '
        resources.ApplyResources(Me.colSampleID, "colSampleID")
        Me.colSampleID.FieldName = "strBarcode"
        Me.colSampleID.Name = "colSampleID"
        Me.colSampleID.OptionsColumn.AllowEdit = False
        '
        'colDiagnosis
        '
        resources.ApplyResources(Me.colDiagnosis, "colDiagnosis")
        Me.colDiagnosis.ColumnEdit = Me.cbCaseDiagnosis
        Me.colDiagnosis.FieldName = "idfsDiagnosis"
        Me.colDiagnosis.Name = "colDiagnosis"
        '
        'cbCaseDiagnosis
        '
        resources.ApplyResources(Me.cbCaseDiagnosis, "cbCaseDiagnosis")
        Me.cbCaseDiagnosis.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbCaseDiagnosis.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbCaseDiagnosis.Name = "cbCaseDiagnosis"
        '
        'cbCaseDiagnosisEditor
        '
        resources.ApplyResources(Me.cbCaseDiagnosisEditor, "cbCaseDiagnosisEditor")
        Me.cbCaseDiagnosisEditor.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbCaseDiagnosisEditor.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbCaseDiagnosisEditor.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbCaseDiagnosisEditor.Columns"), resources.GetString("cbCaseDiagnosisEditor.Columns1"))})
        Me.cbCaseDiagnosisEditor.DisplayMember = "name"
        Me.cbCaseDiagnosisEditor.Name = "cbCaseDiagnosisEditor"
        Me.cbCaseDiagnosisEditor.ValueMember = "idfsDiagnosis"
        '
        'colName
        '
        resources.ApplyResources(Me.colName, "colName")
        Me.colName.FieldName = "name"
        Me.colName.Name = "colName"
        '
        'AssignTestsList
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer2)
        Me.FormID = "L20"
        Me.HelpTopicID = "TestAssignForm"
        Me.KeyFieldName = "idfsReference"
        Me.LeftIcon = CType(resources.GetObject("$this.LeftIcon"), System.Drawing.Image)
        Me.Name = "AssignTestsList"
        Me.ObjectName = "AssignTests"
        Me.ShowDeleteButton = False
        Me.Sizable = True
        Me.Controls.SetChildIndex(Me.cmdOk, 0)
        Me.Controls.SetChildIndex(Me.SplitContainer2, 0)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.TestGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TestGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTestType2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDiagnosis.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AssignedGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AssignedGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTestType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.ContainerGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ContainerGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCaseDiagnosis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCaseDiagnosisEditor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents colName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbDiagnosis As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents TestGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents TestGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colTestName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents AssignedGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents AssignedGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colAssignedTestName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAssignedTestType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdRemove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbTestType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colTestType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbTestType2 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents ContainerGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents ContainerGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colSampleID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDiagnosis As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbCaseDiagnosis As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colAssignedDiagnosis As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbCaseDiagnosisEditor As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colAssignedSample As DevExpress.XtraGrid.Columns.GridColumn

End Class
