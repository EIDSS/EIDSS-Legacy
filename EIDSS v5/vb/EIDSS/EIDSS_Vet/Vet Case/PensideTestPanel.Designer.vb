<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PensideTestPanel
    Inherits bv.common.win.BaseDetailPanel

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PensideTestPanel))
        Me.pnPensideTests = New DevExpress.XtraEditors.GroupControl
        Me.cmdDeleteTest = New DevExpress.XtraEditors.SimpleButton
        Me.TestGrid = New DevExpress.XtraGrid.GridControl
        Me.TestGridView = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.colAnimalID = New DevExpress.XtraGrid.Columns.GridColumn
        Me.cbAnimal = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Me.colSpecies = New DevExpress.XtraGrid.Columns.GridColumn
        Me.cbSpecies = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Me.colSampleBarcode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.cbSampleBarcode = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Me.colSampleType = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colTestBarcode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.colTestName = New DevExpress.XtraGrid.Columns.GridColumn
        Me.cbTestType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Me.colTestResult = New DevExpress.XtraGrid.Columns.GridColumn
        Me.cbTestResult = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Me.cbSpecimenID = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Me.dtDateTested = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
        Me.cmdNew = New DevExpress.XtraEditors.SimpleButton
        CType(Me.pnPensideTests, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnPensideTests.SuspendLayout()
        CType(Me.TestGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TestGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbAnimal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSpecies, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSampleBarcode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTestType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTestResult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSpecimenID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDateTested, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDateTested.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnPensideTests
        '
        Me.pnPensideTests.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.pnPensideTests.Appearance.Options.UseBackColor = True
        Me.pnPensideTests.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.pnPensideTests.AppearanceCaption.Options.UseFont = True
        Me.pnPensideTests.Controls.Add(Me.cmdDeleteTest)
        Me.pnPensideTests.Controls.Add(Me.TestGrid)
        Me.pnPensideTests.Controls.Add(Me.cmdNew)
        resources.ApplyResources(Me.pnPensideTests, "pnPensideTests")
        Me.pnPensideTests.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.pnPensideTests.LookAndFeel.UseDefaultLookAndFeel = False
        Me.pnPensideTests.Name = "pnPensideTests"
        '
        'cmdDeleteTest
        '
        resources.ApplyResources(Me.cmdDeleteTest, "cmdDeleteTest")
        Me.cmdDeleteTest.Image = Global.EIDSS.My.Resources.Resources.Delete_Remove
        Me.cmdDeleteTest.Name = "cmdDeleteTest"
        '
        'TestGrid
        '
        resources.ApplyResources(Me.TestGrid, "TestGrid")
        Me.TestGrid.MainView = Me.TestGridView
        Me.TestGrid.Name = "TestGrid"
        Me.TestGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbTestResult, Me.cbSpecimenID, Me.cbSampleBarcode, Me.cbTestType, Me.dtDateTested, Me.cbSpecies, Me.cbAnimal})
        Me.TestGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.TestGridView})
        '
        'TestGridView
        '
        Me.TestGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colAnimalID, Me.colSpecies, Me.colSampleBarcode, Me.colSampleType, Me.colTestBarcode, Me.colTestName, Me.colTestResult})
        Me.TestGridView.GridControl = Me.TestGrid
        resources.ApplyResources(Me.TestGridView, "TestGridView")
        Me.TestGridView.Name = "TestGridView"
        Me.TestGridView.OptionsBehavior.AutoPopulateColumns = False
        Me.TestGridView.OptionsCustomization.AllowFilter = False
        Me.TestGridView.OptionsNavigation.EnterMoveNextColumn = True
        Me.TestGridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.TestGridView.OptionsView.ShowGroupPanel = False
        '
        'colAnimalID
        '
        resources.ApplyResources(Me.colAnimalID, "colAnimalID")
        Me.colAnimalID.ColumnEdit = Me.cbAnimal
        Me.colAnimalID.FieldName = "idfParty"
        Me.colAnimalID.Name = "colAnimalID"
        Me.colAnimalID.OptionsColumn.AllowEdit = False
        Me.colAnimalID.OptionsColumn.AllowFocus = False
        Me.colAnimalID.OptionsColumn.AllowMove = False
        Me.colAnimalID.OptionsColumn.ReadOnly = True
        '
        'cbAnimal
        '
        resources.ApplyResources(Me.cbAnimal, "cbAnimal")
        Me.cbAnimal.DisplayMember = "strAnimalCode"
        Me.cbAnimal.Name = "cbAnimal"
        Me.cbAnimal.ReadOnly = True
        Me.cbAnimal.ValueMember = "idfAnimal"
        '
        'colSpecies
        '
        resources.ApplyResources(Me.colSpecies, "colSpecies")
        Me.colSpecies.ColumnEdit = Me.cbSpecies
        Me.colSpecies.FieldName = "idfParty"
        Me.colSpecies.Name = "colSpecies"
        Me.colSpecies.OptionsColumn.AllowEdit = False
        Me.colSpecies.OptionsColumn.AllowFocus = False
        Me.colSpecies.OptionsColumn.ReadOnly = True
        '
        'cbSpecies
        '
        resources.ApplyResources(Me.cbSpecies, "cbSpecies")
        Me.cbSpecies.DisplayMember = "HerdSpecies"
        Me.cbSpecies.Name = "cbSpecies"
        Me.cbSpecies.ValueMember = "idfSpecies"
        '
        'colSampleBarcode
        '
        resources.ApplyResources(Me.colSampleBarcode, "colSampleBarcode")
        Me.colSampleBarcode.ColumnEdit = Me.cbSampleBarcode
        Me.colSampleBarcode.FieldName = "idfMaterial"
        Me.colSampleBarcode.Name = "colSampleBarcode"
        '
        'cbSampleBarcode
        '
        resources.ApplyResources(Me.cbSampleBarcode, "cbSampleBarcode")
        Me.cbSampleBarcode.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSampleBarcode.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbSampleBarcode.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbSampleBarcode.Columns"), CType(resources.GetObject("cbSampleBarcode.Columns1"), Integer), resources.GetString("cbSampleBarcode.Columns2")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbSampleBarcode.Columns3"), CType(resources.GetObject("cbSampleBarcode.Columns4"), Integer), resources.GetString("cbSampleBarcode.Columns5"))})
        Me.cbSampleBarcode.DisplayMember = "strFieldBarcode"
        Me.cbSampleBarcode.Name = "cbSampleBarcode"
        Me.cbSampleBarcode.ValueMember = "idfMaterial"
        '
        'colSampleType
        '
        resources.ApplyResources(Me.colSampleType, "colSampleType")
        Me.colSampleType.FieldName = "strSpecimenName"
        Me.colSampleType.Name = "colSampleType"
        Me.colSampleType.OptionsColumn.AllowEdit = False
        Me.colSampleType.OptionsColumn.AllowFocus = False
        Me.colSampleType.OptionsColumn.ReadOnly = True
        '
        'colTestBarcode
        '
        resources.ApplyResources(Me.colTestBarcode, "colTestBarcode")
        Me.colTestBarcode.FieldName = "strFieldSampleID"
        Me.colTestBarcode.Name = "colTestBarcode"
        '
        'colTestName
        '
        resources.ApplyResources(Me.colTestName, "colTestName")
        Me.colTestName.ColumnEdit = Me.cbTestType
        Me.colTestName.FieldName = "idfsPensideTestType"
        Me.colTestName.Name = "colTestName"
        '
        'cbTestType
        '
        resources.ApplyResources(Me.cbTestType, "cbTestType")
        Me.cbTestType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTestType.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbTestType.Name = "cbTestType"
        '
        'colTestResult
        '
        resources.ApplyResources(Me.colTestResult, "colTestResult")
        Me.colTestResult.ColumnEdit = Me.cbTestResult
        Me.colTestResult.FieldName = "idfsPensideTestResult"
        Me.colTestResult.Name = "colTestResult"
        '
        'cbTestResult
        '
        resources.ApplyResources(Me.cbTestResult, "cbTestResult")
        Me.cbTestResult.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTestResult.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbTestResult.Name = "cbTestResult"
        '
        'cbSpecimenID
        '
        resources.ApplyResources(Me.cbSpecimenID, "cbSpecimenID")
        Me.cbSpecimenID.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSpecimenID.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbSpecimenID.Name = "cbSpecimenID"
        '
        'dtDateTested
        '
        resources.ApplyResources(Me.dtDateTested, "dtDateTested")
        Me.dtDateTested.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtDateTested.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtDateTested.Name = "dtDateTested"
        Me.dtDateTested.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        '
        'cmdNew
        '
        resources.ApplyResources(Me.cmdNew, "cmdNew")
        Me.cmdNew.Image = Global.EIDSS.My.Resources.Resources.add
        Me.cmdNew.Name = "cmdNew"
        '
        'PensideTestPanel
        '
        Me.Controls.Add(Me.pnPensideTests)
        Me.Name = "PensideTestPanel"
        resources.ApplyResources(Me, "$this")
        CType(Me.pnPensideTests, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnPensideTests.ResumeLayout(False)
        CType(Me.TestGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TestGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbAnimal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSpecies, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSampleBarcode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTestType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTestResult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSpecimenID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtDateTested.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtDateTested, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnPensideTests As DevExpress.XtraEditors.GroupControl
    Friend WithEvents cmdDeleteTest As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TestGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents TestGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colSampleBarcode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbSampleBarcode As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colSampleType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTestBarcode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTestName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbTestType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colTestResult As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbTestResult As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents dtDateTested As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents cbSpecimenID As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cmdNew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents colAnimalID As DevExpress.XtraGrid.Columns.GridColumn

    Dim PensideTestsDbService As PensideTests_Db

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        PensideTestsDbService = New PensideTests_Db
        DbService = PensideTestsDbService
        AddHandler PensideTestsDbService.OnBeforeAcceptChanges, AddressOf BeforeAcceptChanges

    End Sub
    Friend WithEvents colSpecies As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbSpecies As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cbAnimal As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
End Class
