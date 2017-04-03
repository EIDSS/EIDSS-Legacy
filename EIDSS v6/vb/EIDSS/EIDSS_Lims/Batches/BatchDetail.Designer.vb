<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BatchDetail
    Inherits bv.common.win.BaseDetailForm

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BatchDetail))
        Me.tbBatchID = New DevExpress.XtraEditors.TextEdit()
        Me.lBatchID = New System.Windows.Forms.Label()
        Me.cbTestType = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gridTests = New DevExpress.XtraGrid.GridControl()
        Me.TestsView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colSequence = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colActivityCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSampleID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDiagnosis = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbDiagnosis = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colSpecimenType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCategory = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbTestCategory = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colTestType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTestResult = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbTestResult = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colResultEnteredBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbResultEnteredBy = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.cbTestedBy = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbValidatedBy = New DevExpress.XtraEditors.LookUpEdit()
        Me.dtDateTested = New DevExpress.XtraEditors.DateEdit()
        Me.dtDateValidated = New DevExpress.XtraEditors.DateEdit()
        Me.cbOrganization = New DevExpress.XtraEditors.LookUpEdit()
        Me.btAddTests = New DevExpress.XtraEditors.SimpleButton()
        Me.btDelTest = New DevExpress.XtraEditors.SimpleButton()
        Me.btCloseBatch = New DevExpress.XtraEditors.SimpleButton()
        Me.btUP = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.FFBatchDetails = New EIDSS.FlexibleForms.FFPresenter()
        Me.gbTestRunDetails = New System.Windows.Forms.GroupBox()
        Me.gbTestDetails = New System.Windows.Forms.GroupBox()
        Me.FFTestDetails = New EIDSS.FlexibleForms.FFPresenter()
        Me.PopUpButton1 = New bv.common.win.PopUpButton()
        Me.cmReports = New System.Windows.Forms.ContextMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSamplesSearchAdvanced = New DevExpress.XtraEditors.TextEdit()
        Me.btnSampleSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.txtScannedBarcode = New DevExpress.XtraEditors.TextEdit()
        Me.btnAddGroupResult = New DevExpress.XtraEditors.SimpleButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnAddTestByBarcode = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.tbBatchID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTestType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridTests, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TestsView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDiagnosis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTestCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTestResult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbResultEnteredBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTestedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbValidatedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDateTested.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDateTested.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDateValidated.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDateValidated.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbOrganization.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTestRunDetails.SuspendLayout()
        Me.gbTestDetails.SuspendLayout()
        CType(Me.txtSamplesSearchAdvanced.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtScannedBarcode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(BatchDetail), resources)
        'Form Is Localizable: True
        '
        'tbBatchID
        '
        resources.ApplyResources(Me.tbBatchID, "tbBatchID")
        Me.tbBatchID.Name = "tbBatchID"
        Me.tbBatchID.Tag = "{R}"
        '
        'lBatchID
        '
        resources.ApplyResources(Me.lBatchID, "lBatchID")
        Me.lBatchID.Name = "lBatchID"
        '
        'cbTestType
        '
        resources.ApplyResources(Me.cbTestType, "cbTestType")
        Me.cbTestType.Name = "cbTestType"
        Me.cbTestType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTestType.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbTestType.Properties.NullText = resources.GetString("cbTestType.Properties.NullText")
        Me.cbTestType.Tag = "{M}"
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
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'gridTests
        '
        resources.ApplyResources(Me.gridTests, "gridTests")
        Me.gridTests.MainView = Me.TestsView
        Me.gridTests.Name = "gridTests"
        Me.gridTests.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbTestResult, Me.cbDiagnosis, Me.cbTestCategory, Me.cbResultEnteredBy})
        Me.gridTests.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.TestsView})
        '
        'TestsView
        '
        Me.TestsView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colSequence, Me.colActivityCode, Me.colSampleID, Me.colDiagnosis, Me.colSpecimenType, Me.colCategory, Me.colTestType, Me.colTestResult, Me.colResultEnteredBy})
        Me.TestsView.GridControl = Me.gridTests
        Me.TestsView.Name = "TestsView"
        Me.TestsView.OptionsCustomization.AllowFilter = False
        Me.TestsView.OptionsCustomization.AllowSort = False
        Me.TestsView.OptionsNavigation.EnterMoveNextColumn = True
        Me.TestsView.OptionsSelection.MultiSelect = True
        Me.TestsView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.TestsView.OptionsView.ShowGroupPanel = False
        '
        'colSequence
        '
        resources.ApplyResources(Me.colSequence, "colSequence")
        Me.colSequence.FieldName = "intTestNumber"
        Me.colSequence.Name = "colSequence"
        Me.colSequence.OptionsColumn.AllowEdit = False
        '
        'colActivityCode
        '
        resources.ApplyResources(Me.colActivityCode, "colActivityCode")
        Me.colActivityCode.FieldName = "strActivityCode"
        Me.colActivityCode.Name = "colActivityCode"
        Me.colActivityCode.OptionsColumn.AllowEdit = False
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
        Me.colDiagnosis.ColumnEdit = Me.cbDiagnosis
        Me.colDiagnosis.FieldName = "idfsDiagnosis"
        Me.colDiagnosis.Name = "colDiagnosis"
        '
        'cbDiagnosis
        '
        resources.ApplyResources(Me.cbDiagnosis, "cbDiagnosis")
        Me.cbDiagnosis.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDiagnosis.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbDiagnosis.Name = "cbDiagnosis"
        '
        'colSpecimenType
        '
        resources.ApplyResources(Me.colSpecimenType, "colSpecimenType")
        Me.colSpecimenType.FieldName = "strSampleName"
        Me.colSpecimenType.Name = "colSpecimenType"
        Me.colSpecimenType.OptionsColumn.AllowEdit = False
        '
        'colCategory
        '
        resources.ApplyResources(Me.colCategory, "colCategory")
        Me.colCategory.ColumnEdit = Me.cbTestCategory
        Me.colCategory.FieldName = "idfsTestCategory"
        Me.colCategory.Name = "colCategory"
        '
        'cbTestCategory
        '
        resources.ApplyResources(Me.cbTestCategory, "cbTestCategory")
        Me.cbTestCategory.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTestCategory.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbTestCategory.Name = "cbTestCategory"
        '
        'colTestType
        '
        resources.ApplyResources(Me.colTestType, "colTestType")
        Me.colTestType.FieldName = "TestName"
        Me.colTestType.Name = "colTestType"
        Me.colTestType.OptionsColumn.AllowEdit = False
        '
        'colTestResult
        '
        resources.ApplyResources(Me.colTestResult, "colTestResult")
        Me.colTestResult.ColumnEdit = Me.cbTestResult
        Me.colTestResult.FieldName = "idfsTestResult"
        Me.colTestResult.Name = "colTestResult"
        '
        'cbTestResult
        '
        resources.ApplyResources(Me.cbTestResult, "cbTestResult")
        Me.cbTestResult.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTestResult.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbTestResult.DisplayMember = "Name"
        Me.cbTestResult.Name = "cbTestResult"
        Me.cbTestResult.ValueMember = "idfsReference"
        '
        'colResultEnteredBy
        '
        resources.ApplyResources(Me.colResultEnteredBy, "colResultEnteredBy")
        Me.colResultEnteredBy.ColumnEdit = Me.cbResultEnteredBy
        Me.colResultEnteredBy.FieldName = "idfResultEnteredByPerson"
        Me.colResultEnteredBy.Name = "colResultEnteredBy"
        Me.colResultEnteredBy.OptionsColumn.AllowEdit = False
        Me.colResultEnteredBy.OptionsColumn.ReadOnly = True
        '
        'cbResultEnteredBy
        '
        resources.ApplyResources(Me.cbResultEnteredBy, "cbResultEnteredBy")
        Me.cbResultEnteredBy.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbResultEnteredBy.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbResultEnteredBy.Name = "cbResultEnteredBy"
        '
        'cbTestedBy
        '
        resources.ApplyResources(Me.cbTestedBy, "cbTestedBy")
        Me.cbTestedBy.Name = "cbTestedBy"
        Me.cbTestedBy.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTestedBy.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbTestedBy.Properties.NullText = resources.GetString("cbTestedBy.Properties.NullText")
        Me.cbTestedBy.Tag = ""
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'cbValidatedBy
        '
        resources.ApplyResources(Me.cbValidatedBy, "cbValidatedBy")
        Me.cbValidatedBy.Name = "cbValidatedBy"
        Me.cbValidatedBy.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbValidatedBy.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbValidatedBy.Properties.NullText = resources.GetString("cbValidatedBy.Properties.NullText")
        Me.cbValidatedBy.Tag = ""
        '
        'dtDateTested
        '
        resources.ApplyResources(Me.dtDateTested, "dtDateTested")
        Me.dtDateTested.Name = "dtDateTested"
        Me.dtDateTested.Properties.AutoHeight = CType(resources.GetObject("dtDateTested.Properties.AutoHeight"), Boolean)
        Me.dtDateTested.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtDateTested.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtDateTested.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtDateTested.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtDateTested.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtDateTested.Properties.Mask.SaveLiteral = CType(resources.GetObject("dtDateTested.Properties.Mask.SaveLiteral"), Boolean)
        Me.dtDateTested.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtDateTested.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtDateTested.Tag = ""
        '
        'dtDateValidated
        '
        resources.ApplyResources(Me.dtDateValidated, "dtDateValidated")
        Me.dtDateValidated.Name = "dtDateValidated"
        Me.dtDateValidated.Properties.AutoHeight = CType(resources.GetObject("dtDateValidated.Properties.AutoHeight"), Boolean)
        Me.dtDateValidated.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtDateValidated.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtDateValidated.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtDateValidated.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtDateValidated.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtDateValidated.Properties.Mask.SaveLiteral = CType(resources.GetObject("dtDateValidated.Properties.Mask.SaveLiteral"), Boolean)
        Me.dtDateValidated.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtDateValidated.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtDateValidated.Tag = ""
        '
        'cbOrganization
        '
        resources.ApplyResources(Me.cbOrganization, "cbOrganization")
        Me.cbOrganization.Name = "cbOrganization"
        Me.cbOrganization.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbOrganization.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbOrganization.Properties.NullText = resources.GetString("cbOrganization.Properties.NullText")
        Me.cbOrganization.Tag = "{R}"
        '
        'btAddTests
        '
        Me.btAddTests.Image = Global.EIDSS.My.Resources.Resources.add
        resources.ApplyResources(Me.btAddTests, "btAddTests")
        Me.btAddTests.Name = "btAddTests"
        '
        'btDelTest
        '
        Me.btDelTest.Image = Global.EIDSS.My.Resources.Resources.Delete_Remove
        resources.ApplyResources(Me.btDelTest, "btDelTest")
        Me.btDelTest.Name = "btDelTest"
        '
        'btCloseBatch
        '
        Me.btCloseBatch.Image = Global.EIDSS.My.Resources.Resources.Close
        resources.ApplyResources(Me.btCloseBatch, "btCloseBatch")
        Me.btCloseBatch.Name = "btCloseBatch"
        '
        'btUP
        '
        Me.btUP.Image = CType(resources.GetObject("btUP.Image"), System.Drawing.Image)
        Me.btUP.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        resources.ApplyResources(Me.btUP, "btUP")
        Me.btUP.Name = "btUP"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Image = CType(resources.GetObject("SimpleButton2.Image"), System.Drawing.Image)
        Me.SimpleButton2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        resources.ApplyResources(Me.SimpleButton2, "SimpleButton2")
        Me.SimpleButton2.Name = "SimpleButton2"
        '
        'FFBatchDetails
        '
        resources.ApplyResources(Me.FFBatchDetails, "FFBatchDetails")
        Me.FFBatchDetails.DelayedLoadingNeeded = False
        Me.FFBatchDetails.DynamicParameterEnabled = False
        Me.FFBatchDetails.FormID = Nothing
        Me.FFBatchDetails.HelpTopicID = Nothing
        Me.FFBatchDetails.KeyFieldName = Nothing
        Me.FFBatchDetails.MultiSelect = False
        Me.FFBatchDetails.Name = "FFBatchDetails"
        Me.FFBatchDetails.ObjectName = Nothing
        Me.FFBatchDetails.SectionTableCaptionsIsVisible = True
        Me.FFBatchDetails.TableName = Nothing
        '
        'gbTestRunDetails
        '
        Me.gbTestRunDetails.Controls.Add(Me.FFBatchDetails)
        resources.ApplyResources(Me.gbTestRunDetails, "gbTestRunDetails")
        Me.gbTestRunDetails.Name = "gbTestRunDetails"
        Me.gbTestRunDetails.TabStop = False
        '
        'gbTestDetails
        '
        Me.gbTestDetails.Controls.Add(Me.FFTestDetails)
        resources.ApplyResources(Me.gbTestDetails, "gbTestDetails")
        Me.gbTestDetails.Name = "gbTestDetails"
        Me.gbTestDetails.TabStop = False
        '
        'FFTestDetails
        '
        resources.ApplyResources(Me.FFTestDetails, "FFTestDetails")
        Me.FFTestDetails.DelayedLoadingNeeded = False
        Me.FFTestDetails.DynamicParameterEnabled = False
        Me.FFTestDetails.FormID = Nothing
        Me.FFTestDetails.HelpTopicID = Nothing
        Me.FFTestDetails.KeyFieldName = Nothing
        Me.FFTestDetails.MultiSelect = False
        Me.FFTestDetails.Name = "FFTestDetails"
        Me.FFTestDetails.ObjectName = Nothing
        Me.FFTestDetails.SectionTableCaptionsIsVisible = True
        Me.FFTestDetails.TableName = Nothing
        '
        'PopUpButton1
        '
        Me.PopUpButton1.ButtonType = bv.common.win.PopUpButton.PopUpButtonStyles.Reports
        Me.PopUpButton1.ImageIndex = 0
        resources.ApplyResources(Me.PopUpButton1, "PopUpButton1")
        Me.PopUpButton1.Name = "PopUpButton1"
        Me.PopUpButton1.PopUpMenu = Me.cmReports
        Me.PopUpButton1.Tag = "{Immovable}{AlwaysEditable}"
        '
        'cmReports
        '
        Me.cmReports.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        resources.ApplyResources(Me.MenuItem1, "MenuItem1")
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'txtSamplesSearchAdvanced
        '
        resources.ApplyResources(Me.txtSamplesSearchAdvanced, "txtSamplesSearchAdvanced")
        Me.txtSamplesSearchAdvanced.Name = "txtSamplesSearchAdvanced"
        '
        'btnSampleSearch
        '
        resources.ApplyResources(Me.btnSampleSearch, "btnSampleSearch")
        Me.btnSampleSearch.Image = Global.EIDSS.My.Resources.Resources.Search
        Me.btnSampleSearch.Name = "btnSampleSearch"
        '
        'txtScannedBarcode
        '
        resources.ApplyResources(Me.txtScannedBarcode, "txtScannedBarcode")
        Me.txtScannedBarcode.Name = "txtScannedBarcode"
        '
        'btnAddGroupResult
        '
        Me.btnAddGroupResult.Image = Global.EIDSS.My.Resources.Resources.add
        resources.ApplyResources(Me.btnAddGroupResult, "btnAddGroupResult")
        Me.btnAddGroupResult.Name = "btnAddGroupResult"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'btnAddTestByBarcode
        '
        Me.btnAddTestByBarcode.Image = Global.EIDSS.My.Resources.Resources.add
        resources.ApplyResources(Me.btnAddTestByBarcode, "btnAddTestByBarcode")
        Me.btnAddTestByBarcode.Name = "btnAddTestByBarcode"
        '
        'BatchDetail
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cbTestedBy)
        Me.Controls.Add(Me.cbValidatedBy)
        Me.Controls.Add(Me.dtDateTested)
        Me.Controls.Add(Me.dtDateValidated)
        Me.Controls.Add(Me.btnAddTestByBarcode)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnAddGroupResult)
        Me.Controls.Add(Me.txtScannedBarcode)
        Me.Controls.Add(Me.btnSampleSearch)
        Me.Controls.Add(Me.txtSamplesSearchAdvanced)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PopUpButton1)
        Me.Controls.Add(Me.gbTestDetails)
        Me.Controls.Add(Me.gbTestRunDetails)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.btUP)
        Me.Controls.Add(Me.btDelTest)
        Me.Controls.Add(Me.btCloseBatch)
        Me.Controls.Add(Me.btAddTests)
        Me.Controls.Add(Me.lBatchID)
        Me.Controls.Add(Me.gridTests)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbOrganization)
        Me.Controls.Add(Me.cbTestType)
        Me.Controls.Add(Me.tbBatchID)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "L22"
        Me.HelpTopicID = "lab_l22"
        Me.LeftIcon = CType(resources.GetObject("$this.LeftIcon"), System.Drawing.Image)
        Me.Name = "BatchDetail"
        Me.ObjectName = "LabBatch"
        Me.Status = bv.common.win.FormStatus.Draft
        Me.Controls.SetChildIndex(Me.tbBatchID, 0)
        Me.Controls.SetChildIndex(Me.cbTestType, 0)
        Me.Controls.SetChildIndex(Me.cbOrganization, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.gridTests, 0)
        Me.Controls.SetChildIndex(Me.lBatchID, 0)
        Me.Controls.SetChildIndex(Me.btAddTests, 0)
        Me.Controls.SetChildIndex(Me.btCloseBatch, 0)
        Me.Controls.SetChildIndex(Me.btDelTest, 0)
        Me.Controls.SetChildIndex(Me.btUP, 0)
        Me.Controls.SetChildIndex(Me.SimpleButton2, 0)
        Me.Controls.SetChildIndex(Me.gbTestRunDetails, 0)
        Me.Controls.SetChildIndex(Me.gbTestDetails, 0)
        Me.Controls.SetChildIndex(Me.PopUpButton1, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.txtSamplesSearchAdvanced, 0)
        Me.Controls.SetChildIndex(Me.btnSampleSearch, 0)
        Me.Controls.SetChildIndex(Me.txtScannedBarcode, 0)
        Me.Controls.SetChildIndex(Me.btnAddGroupResult, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.btnAddTestByBarcode, 0)
        Me.Controls.SetChildIndex(Me.dtDateValidated, 0)
        Me.Controls.SetChildIndex(Me.dtDateTested, 0)
        Me.Controls.SetChildIndex(Me.cbValidatedBy, 0)
        Me.Controls.SetChildIndex(Me.cbTestedBy, 0)
        CType(Me.tbBatchID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTestType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridTests, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TestsView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDiagnosis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTestCategory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTestResult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbResultEnteredBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTestedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbValidatedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtDateTested.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtDateTested.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtDateValidated.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtDateValidated.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbOrganization.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTestRunDetails.ResumeLayout(False)
        Me.gbTestDetails.ResumeLayout(False)
        CType(Me.txtSamplesSearchAdvanced.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtScannedBarcode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbBatchID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lBatchID As System.Windows.Forms.Label
    Friend WithEvents cbTestType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gridTests As DevExpress.XtraGrid.GridControl
    Friend WithEvents TestsView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cbTestedBy As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbValidatedBy As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents dtDateTested As DevExpress.XtraEditors.DateEdit
    Friend WithEvents dtDateValidated As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cbOrganization As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents colActivityCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTestType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTestResult As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSampleID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSpecimenType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbTestResult As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colDiagnosis As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btAddTests As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btDelTest As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btCloseBatch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btUP As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents FFBatchDetails As EIDSS.FlexibleForms.FFPresenter
    Friend WithEvents gbTestRunDetails As System.Windows.Forms.GroupBox
    Friend WithEvents gbTestDetails As System.Windows.Forms.GroupBox
    Friend WithEvents FFTestDetails As EIDSS.FlexibleForms.FFPresenter
    Friend WithEvents PopUpButton1 As bv.common.win.PopUpButton
    Friend WithEvents cmReports As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents colSequence As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtSamplesSearchAdvanced As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnSampleSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtScannedBarcode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnAddGroupResult As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnAddTestByBarcode As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbDiagnosis As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cbTestCategory As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colResultEnteredBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbResultEnteredBy As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit

End Class
