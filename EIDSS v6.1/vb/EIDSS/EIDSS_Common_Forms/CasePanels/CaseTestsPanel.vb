Imports System.ComponentModel
Imports eidss.model.Core
Imports eidss.Core
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Repository
Imports eidss.FlexibleForms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports bv.common.Core
Imports bv.winclient.Core
Imports eidss.model.Resources
Imports bv.winclient.BasePanel
Imports System.Collections.Generic
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.Utils
Imports bv.common.Resources
Imports bv.winclient.Localization
Imports EIDSS.model.Enums
Imports bv.common.Enums
Imports bv.common.win.Validators

Public Class CaseTestsPanel
    Inherits BaseDetailPanel
    Public Event OnTestsCollectionChanged As RowCollectionChangedHandler

    Dim CaseTestsDbService As CaseTestsDetail_Db
    Friend WithEvents cbPersonLookup As RepositoryItemLookUpEdit
    Friend WithEvents RepositoryItemCheckEdit1 As RepositoryItemCheckEdit
    Friend WithEvents cbRuleInLookup As RepositoryItemLookUpEdit
    Friend WithEvents ffLabTestDetails As FFPresenter
    Friend WithEvents PopUpButton2 As PopUpButton
    Friend WithEvents colSampleID As GridColumn
    Friend WithEvents colDiagnosis As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAmendment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents chkHasAmendment As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents btnDeleteTest As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAddTest As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbSample As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cbTestType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cbTestResult As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cbTestCategory As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cbTestStatus As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cbTestDiagnosis As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colFarmID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SplitContainerControl1 As SplitContainerControl
    Friend WithEvents ToolTipController1 As DevExpress.Utils.ToolTipController
    'Private ValidationView As DataView
    'Private OnlyCompleted As Boolean = True
    Private m_CanDeleteTest As Boolean
    Friend WithEvents dtDateEdit As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents dtDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents grpExternalOrganization As DevExpress.XtraEditors.GroupControl
    Friend WithEvents dtDateReceived As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lbDateReceived As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtExtEmployee As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbExtEmployee As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbExtOrganization As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lbExtOrganization As DevExpress.XtraEditors.LabelControl
    Friend WithEvents colFarmID1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAnimalID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSpecies As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCaseCreated As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents chkCaseCreated As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents colLabSampleIdV As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSampleTypeV As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFieldSampleIdV As DevExpress.XtraGrid.Columns.GridColumn
    Private m_CanAddTest As Boolean
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'OnlyCompleted = Completed
        'This call is required by the Windows Form Designer.
        DebugTimer.Start("CaseTestsPanel Constructor")

        InitializeComponent()
        If WinUtils.IsComponentInDesignMode(Me) Then
            DebugTimer.Stop()
            Return
        End If

        'Add any initialization after the InitializeComponent() call
        CaseTestsDbService = New CaseTestsDetail_Db()
        DbService = CaseTestsDbService
        ' Flexible Form

        'Dim fid As New BaseFlexibleForm.FFID
        'fid.TableName = "Activity_Parameters"
        'ffLabTestDetails.FFIdent = fid

        'Dim dbl As New FlexibleForm_DB(ffLabTestDetails)
        'Dim dbl As New FlexibleForm_DB
        'RegisterChildObject(ffLabTestDetails, RelatedPostOrder.PostLast)
        If (Not WinUtils.IsComponentInDesignMode(Me)) Then
            Dim _
                validate As StandardAccessPermissions = _
                    New StandardAccessPermissions(eidss.model.Enums.EIDSSPermissionObject.CanValidateTestInterpretation)
            Me.colValidated.OptionsColumn.AllowEdit = validate.CanExecute
            Me.colCommentValidated.OptionsColumn.AllowEdit = validate.CanExecute
            Dim testPermissions As StandardAccessPermissions = _
                    New StandardAccessPermissions(eidss.model.Enums.EIDSSPermissionObject.CanAddTestResults)
            btnAddTest.Enabled = testPermissions.CanExecute
            m_CanDeleteTest = testPermissions.CanExecute
            m_CanAddTest = testPermissions.CanExecute
        End If
        Me.colAmendment.OptionsColumn.ReadOnly = True
        Me.colAmendment.OptionsColumn.AllowEdit = False
        'AddHandler CaseTestsDbService.OnBeforePost, AddressOf CaseTestsPanel_OnBeforePost
        Me.ffLabTestDetails.ReadOnly = True
        AddHandler OnBeforePost, AddressOf BeforePost
        DebugTimer.Stop()

        miCaseTests.Visible = EIDSS.model.Reports.BaseMenuReportRegistrator.IsPaperFormAllowed("LimTest")
    End Sub
    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents colTestBarcode As GridColumn
    Friend WithEvents colTestName As GridColumn
    Friend WithEvents colFieldID As GridColumn
    Friend WithEvents colTestResult As GridColumn
    Friend WithEvents TestGrid As GridControl
    Friend WithEvents TestGridView As GridView
    Friend WithEvents pnTests As GroupControl
    Friend WithEvents chkConfirmed As RepositoryItemCheckEdit
    Friend WithEvents chkRequested As RepositoryItemCheckEdit
    Friend WithEvents colSampleType As GridColumn
    Friend WithEvents colDateTested As GridColumn
    Friend WithEvents colDepartment As GridColumn
    Friend WithEvents cmReports As ContextMenu
    Friend WithEvents colAnimal As GridColumn
    Friend WithEvents colTestType As GridColumn
    Friend WithEvents colTestStatus As GridColumn
    Friend WithEvents pnValidation As GroupControl
    Friend WithEvents cmdDelete As SimpleButton
    Friend WithEvents ValidationGrid As GridControl
    Friend WithEvents ValidationGridView As GridView
    Friend WithEvents cmdNew As SimpleButton
    Friend WithEvents colDiseaseV As GridColumn
    Friend WithEvents colTestNameV As GridColumn
    Friend WithEvents colTestTypeV As GridColumn
    Friend WithEvents colRule As GridColumn
    Friend WithEvents colCommentInterpreted As GridColumn
    Friend WithEvents colDateInterpreted As GridColumn
    Friend WithEvents colPersonInterpreted As GridColumn
    Friend WithEvents colValidated As GridColumn
    Friend WithEvents colCommentValidated As GridColumn
    Friend WithEvents colDateValidated As GridColumn
    Friend WithEvents colPersonValidated As GridColumn
    Friend WithEvents cbDisease As RepositoryItemLookUpEdit
    Friend WithEvents cbTestNameLookup As RepositoryItemLookUpEdit
    Friend WithEvents cbTestTypeLookup As RepositoryItemLookUpEdit
    Friend WithEvents txtMemo As RepositoryItemMemoExEdit
    Friend WithEvents miCaseTests As MenuItem

    <DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CaseTestsPanel))
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.pnTests = New DevExpress.XtraEditors.GroupControl()
        Me.grpExternalOrganization = New DevExpress.XtraEditors.GroupControl()
        Me.dtDateReceived = New DevExpress.XtraEditors.DateEdit()
        Me.lbDateReceived = New DevExpress.XtraEditors.LabelControl()
        Me.txtExtEmployee = New DevExpress.XtraEditors.TextEdit()
        Me.lbExtEmployee = New DevExpress.XtraEditors.LabelControl()
        Me.cbExtOrganization = New DevExpress.XtraEditors.LookUpEdit()
        Me.lbExtOrganization = New DevExpress.XtraEditors.LabelControl()
        Me.btnDeleteTest = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAddTest = New DevExpress.XtraEditors.SimpleButton()
        Me.ffLabTestDetails = New EIDSS.FlexibleForms.FFPresenter()
        Me.TestGrid = New DevExpress.XtraGrid.GridControl()
        Me.TestGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colSampleID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFieldID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbSample = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colSampleType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTestBarcode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTestName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbTestType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colTestResult = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbTestResult = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colDateTested = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.dtDateEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.colDepartment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFarmID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAnimal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTestType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbTestCategory = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colTestStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDiagnosis = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbTestDiagnosis = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colAmendment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.chkHasAmendment = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.cbTestStatus = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ToolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
        Me.pnValidation = New DevExpress.XtraEditors.GroupControl()
        Me.PopUpButton2 = New bv.winclient.Core.PopUpButton(Me.components)
        Me.cmReports = New System.Windows.Forms.ContextMenu()
        Me.miCaseTests = New System.Windows.Forms.MenuItem()
        Me.cmdDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.ValidationGrid = New DevExpress.XtraGrid.GridControl()
        Me.ValidationGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colFarmID1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAnimalID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSpecies = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDiseaseV = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbDisease = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colTestNameV = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbTestNameLookup = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colTestTypeV = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbTestTypeLookup = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colLabSampleIdV = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSampleTypeV = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFieldSampleIdV = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRule = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbRuleInLookup = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colCommentInterpreted = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtMemo = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.colDateInterpreted = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.dtDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.colPersonInterpreted = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbPersonLookup = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colValidated = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colCommentValidated = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDateValidated = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPersonValidated = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCaseCreated = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.chkCaseCreated = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.cmdNew = New DevExpress.XtraEditors.SimpleButton()
        Me.chkConfirmed = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.chkRequested = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.pnTests, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnTests.SuspendLayout()
        CType(Me.grpExternalOrganization, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpExternalOrganization.SuspendLayout()
        CType(Me.dtDateReceived.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDateReceived.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtExtEmployee.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbExtOrganization.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TestGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TestGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSample, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTestType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTestResult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDateEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTestCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTestDiagnosis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkHasAmendment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTestStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnValidation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnValidation.SuspendLayout()
        CType(Me.ValidationGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValidationGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDisease, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTestNameLookup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTestTypeLookup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbRuleInLookup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMemo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbPersonLookup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCaseCreated, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkConfirmed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkRequested, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(CaseTestsPanel), resources)
        'Form Is Localizable: True
        '
        'SplitContainerControl1
        '
        resources.ApplyResources(Me.SplitContainerControl1, "SplitContainerControl1")
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.pnTests)
        resources.ApplyResources(Me.SplitContainerControl1.Panel1, "SplitContainerControl1.Panel1")
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.pnValidation)
        resources.ApplyResources(Me.SplitContainerControl1.Panel2, "SplitContainerControl1.Panel2")
        Me.SplitContainerControl1.SplitterPosition = 247
        '
        'pnTests
        '
        Me.pnTests.Appearance.BackColor = CType(resources.GetObject("pnTests.Appearance.BackColor"), System.Drawing.Color)
        Me.pnTests.Appearance.Options.UseBackColor = True
        Me.pnTests.Appearance.Options.UseFont = True
        Me.pnTests.AppearanceCaption.Options.UseFont = True
        Me.pnTests.Controls.Add(Me.grpExternalOrganization)
        Me.pnTests.Controls.Add(Me.btnDeleteTest)
        Me.pnTests.Controls.Add(Me.btnAddTest)
        Me.pnTests.Controls.Add(Me.ffLabTestDetails)
        Me.pnTests.Controls.Add(Me.TestGrid)
        resources.ApplyResources(Me.pnTests, "pnTests")
        Me.pnTests.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.pnTests.LookAndFeel.UseDefaultLookAndFeel = False
        Me.pnTests.Name = "pnTests"
        '
        'grpExternalOrganization
        '
        resources.ApplyResources(Me.grpExternalOrganization, "grpExternalOrganization")
        Me.grpExternalOrganization.Controls.Add(Me.dtDateReceived)
        Me.grpExternalOrganization.Controls.Add(Me.lbDateReceived)
        Me.grpExternalOrganization.Controls.Add(Me.txtExtEmployee)
        Me.grpExternalOrganization.Controls.Add(Me.lbExtEmployee)
        Me.grpExternalOrganization.Controls.Add(Me.cbExtOrganization)
        Me.grpExternalOrganization.Controls.Add(Me.lbExtOrganization)
        Me.grpExternalOrganization.Name = "grpExternalOrganization"
        '
        'dtDateReceived
        '
        resources.ApplyResources(Me.dtDateReceived, "dtDateReceived")
        Me.dtDateReceived.Name = "dtDateReceived"
        Me.dtDateReceived.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtDateReceived.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtDateReceived.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        '
        'lbDateReceived
        '
        Me.lbDateReceived.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        resources.ApplyResources(Me.lbDateReceived, "lbDateReceived")
        Me.lbDateReceived.Name = "lbDateReceived"
        '
        'txtExtEmployee
        '
        resources.ApplyResources(Me.txtExtEmployee, "txtExtEmployee")
        Me.txtExtEmployee.Name = "txtExtEmployee"
        '
        'lbExtEmployee
        '
        Me.lbExtEmployee.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        resources.ApplyResources(Me.lbExtEmployee, "lbExtEmployee")
        Me.lbExtEmployee.Name = "lbExtEmployee"
        '
        'cbExtOrganization
        '
        resources.ApplyResources(Me.cbExtOrganization, "cbExtOrganization")
        Me.cbExtOrganization.Name = "cbExtOrganization"
        Me.cbExtOrganization.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbExtOrganization.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        '
        'lbExtOrganization
        '
        Me.lbExtOrganization.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        resources.ApplyResources(Me.lbExtOrganization, "lbExtOrganization")
        Me.lbExtOrganization.Name = "lbExtOrganization"
        '
        'btnDeleteTest
        '
        resources.ApplyResources(Me.btnDeleteTest, "btnDeleteTest")
        Me.btnDeleteTest.Appearance.Options.UseFont = True
        Me.btnDeleteTest.Image = Global.EIDSS.My.Resources.Resources.Delete_Remove
        Me.btnDeleteTest.Name = "btnDeleteTest"
        '
        'btnAddTest
        '
        resources.ApplyResources(Me.btnAddTest, "btnAddTest")
        Me.btnAddTest.Appearance.Options.UseFont = True
        Me.btnAddTest.Image = Global.EIDSS.My.Resources.Resources.add
        Me.btnAddTest.Name = "btnAddTest"
        '
        'ffLabTestDetails
        '
        resources.ApplyResources(Me.ffLabTestDetails, "ffLabTestDetails")
        Me.ffLabTestDetails.Appearance.BackColor = CType(resources.GetObject("ffLabTestDetails.Appearance.BackColor"), System.Drawing.Color)
        Me.ffLabTestDetails.Appearance.Options.UseBackColor = True
        Me.ffLabTestDetails.DelayedLoadingNeeded = False
        Me.ffLabTestDetails.DynamicParameterEnabled = False
        Me.ffLabTestDetails.FormID = Nothing
        Me.ffLabTestDetails.HelpTopicID = Nothing
        Me.ffLabTestDetails.KeyFieldName = Nothing
        Me.ffLabTestDetails.MultiSelect = False
        Me.ffLabTestDetails.Name = "ffLabTestDetails"
        Me.ffLabTestDetails.ObjectName = Nothing
        Me.ffLabTestDetails.SectionTableCaptionsIsVisible = True
        Me.ffLabTestDetails.TableName = Nothing
        Me.ffLabTestDetails.UseParentBackColor = True
        '
        'TestGrid
        '
        resources.ApplyResources(Me.TestGrid, "TestGrid")
        Me.TestGrid.Cursor = System.Windows.Forms.Cursors.Default
        Me.TestGrid.EmbeddedNavigator.Appearance.Options.UseFont = True
        Me.TestGrid.MainView = Me.TestGridView
        Me.TestGrid.Name = "TestGrid"
        Me.TestGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.chkHasAmendment, Me.cbSample, Me.cbTestType, Me.cbTestDiagnosis, Me.cbTestCategory, Me.cbTestStatus, Me.cbTestResult, Me.dtDateEdit})
        Me.TestGrid.ToolTipController = Me.ToolTipController1
        Me.TestGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.TestGridView})
        '
        'TestGridView
        '
        Me.TestGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colSampleID, Me.colFieldID, Me.colSampleType, Me.colTestBarcode, Me.colTestName, Me.colTestResult, Me.colDateTested, Me.colDepartment, Me.colFarmID, Me.colAnimal, Me.colTestType, Me.colTestStatus, Me.colDiagnosis, Me.colAmendment})
        Me.TestGridView.GridControl = Me.TestGrid
        resources.ApplyResources(Me.TestGridView, "TestGridView")
        Me.TestGridView.Name = "TestGridView"
        Me.TestGridView.OptionsBehavior.AutoPopulateColumns = False
        Me.TestGridView.OptionsBehavior.Editable = False
        Me.TestGridView.OptionsCustomization.AllowFilter = False
        Me.TestGridView.OptionsNavigation.EnterMoveNextColumn = True
        Me.TestGridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.TestGridView.OptionsView.ShowGroupPanel = False
        '
        'colSampleID
        '
        resources.ApplyResources(Me.colSampleID, "colSampleID")
        Me.colSampleID.FieldName = "strBarcode"
        Me.colSampleID.Name = "colSampleID"
        Me.colSampleID.OptionsColumn.AllowEdit = False
        Me.colSampleID.OptionsColumn.ReadOnly = True
        '
        'colFieldID
        '
        resources.ApplyResources(Me.colFieldID, "colFieldID")
        Me.colFieldID.ColumnEdit = Me.cbSample
        Me.colFieldID.FieldName = "idfMaterial"
        Me.colFieldID.Name = "colFieldID"
        '
        'cbSample
        '
        resources.ApplyResources(Me.cbSample, "cbSample")
        Me.cbSample.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSample.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbSample.Name = "cbSample"
        '
        'colSampleType
        '
        resources.ApplyResources(Me.colSampleType, "colSampleType")
        Me.colSampleType.FieldName = "strSampleName"
        Me.colSampleType.Name = "colSampleType"
        Me.colSampleType.OptionsColumn.AllowEdit = False
        Me.colSampleType.OptionsColumn.ReadOnly = True
        '
        'colTestBarcode
        '
        resources.ApplyResources(Me.colTestBarcode, "colTestBarcode")
        Me.colTestBarcode.FieldName = "strBatchCode"
        Me.colTestBarcode.Name = "colTestBarcode"
        Me.colTestBarcode.OptionsColumn.AllowEdit = False
        Me.colTestBarcode.OptionsColumn.ReadOnly = True
        '
        'colTestName
        '
        resources.ApplyResources(Me.colTestName, "colTestName")
        Me.colTestName.ColumnEdit = Me.cbTestType
        Me.colTestName.FieldName = "idfsTestName"
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
        Me.colTestResult.FieldName = "idfsTestResult"
        Me.colTestResult.Name = "colTestResult"
        '
        'cbTestResult
        '
        resources.ApplyResources(Me.cbTestResult, "cbTestResult")
        Me.cbTestResult.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTestResult.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbTestResult.Name = "cbTestResult"
        '
        'colDateTested
        '
        resources.ApplyResources(Me.colDateTested, "colDateTested")
        Me.colDateTested.ColumnEdit = Me.dtDateEdit
        Me.colDateTested.FieldName = "datConcludedDate"
        Me.colDateTested.Name = "colDateTested"
        '
        'dtDateEdit
        '
        resources.ApplyResources(Me.dtDateEdit, "dtDateEdit")
        Me.dtDateEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtDateEdit.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtDateEdit.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtDateEdit.Name = "dtDateEdit"
        '
        'colDepartment
        '
        resources.ApplyResources(Me.colDepartment, "colDepartment")
        Me.colDepartment.FieldName = "DepartmentName"
        Me.colDepartment.Name = "colDepartment"
        Me.colDepartment.OptionsColumn.AllowEdit = False
        Me.colDepartment.OptionsColumn.ReadOnly = True
        '
        'colFarmID
        '
        resources.ApplyResources(Me.colFarmID, "colFarmID")
        Me.colFarmID.FieldName = "strFarmCode"
        Me.colFarmID.Name = "colFarmID"
        Me.colFarmID.OptionsColumn.AllowEdit = False
        Me.colFarmID.OptionsColumn.FixedWidth = True
        '
        'colAnimal
        '
        resources.ApplyResources(Me.colAnimal, "colAnimal")
        Me.colAnimal.FieldName = "AnimalName"
        Me.colAnimal.Name = "colAnimal"
        Me.colAnimal.OptionsColumn.AllowEdit = False
        Me.colAnimal.OptionsColumn.ReadOnly = True
        '
        'colTestType
        '
        resources.ApplyResources(Me.colTestType, "colTestType")
        Me.colTestType.ColumnEdit = Me.cbTestCategory
        Me.colTestType.FieldName = "idfsTestCategory"
        Me.colTestType.Name = "colTestType"
        '
        'cbTestCategory
        '
        resources.ApplyResources(Me.cbTestCategory, "cbTestCategory")
        Me.cbTestCategory.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTestCategory.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbTestCategory.Name = "cbTestCategory"
        '
        'colTestStatus
        '
        resources.ApplyResources(Me.colTestStatus, "colTestStatus")
        Me.colTestStatus.FieldName = "TestStatus"
        Me.colTestStatus.Name = "colTestStatus"
        Me.colTestStatus.OptionsColumn.ReadOnly = True
        '
        'colDiagnosis
        '
        resources.ApplyResources(Me.colDiagnosis, "colDiagnosis")
        Me.colDiagnosis.ColumnEdit = Me.cbTestDiagnosis
        Me.colDiagnosis.FieldName = "idfsDiagnosis"
        Me.colDiagnosis.Name = "colDiagnosis"
        '
        'cbTestDiagnosis
        '
        resources.ApplyResources(Me.cbTestDiagnosis, "cbTestDiagnosis")
        Me.cbTestDiagnosis.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTestDiagnosis.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbTestDiagnosis.Name = "cbTestDiagnosis"
        '
        'colAmendment
        '
        resources.ApplyResources(Me.colAmendment, "colAmendment")
        Me.colAmendment.ColumnEdit = Me.chkHasAmendment
        Me.colAmendment.FieldName = "intHasAmendment"
        Me.colAmendment.Name = "colAmendment"
        Me.colAmendment.OptionsColumn.AllowMove = False
        Me.colAmendment.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        '
        'chkHasAmendment
        '
        resources.ApplyResources(Me.chkHasAmendment, "chkHasAmendment")
        Me.chkHasAmendment.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
        Me.chkHasAmendment.ImageIndexChecked = 0
        Me.chkHasAmendment.Images = Me.ImageList1
        Me.chkHasAmendment.Name = "chkHasAmendment"
        Me.chkHasAmendment.ValueChecked = 1
        Me.chkHasAmendment.ValueUnchecked = 0
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "history.gif")
        '
        'cbTestStatus
        '
        resources.ApplyResources(Me.cbTestStatus, "cbTestStatus")
        Me.cbTestStatus.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTestStatus.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbTestStatus.Name = "cbTestStatus"
        '
        'ToolTipController1
        '
        '
        'pnValidation
        '
        Me.pnValidation.Appearance.BackColor = CType(resources.GetObject("pnValidation.Appearance.BackColor"), System.Drawing.Color)
        Me.pnValidation.Appearance.Options.UseBackColor = True
        Me.pnValidation.Appearance.Options.UseFont = True
        Me.pnValidation.AppearanceCaption.Options.UseFont = True
        Me.pnValidation.Controls.Add(Me.PopUpButton2)
        Me.pnValidation.Controls.Add(Me.cmdDelete)
        Me.pnValidation.Controls.Add(Me.ValidationGrid)
        Me.pnValidation.Controls.Add(Me.cmdNew)
        resources.ApplyResources(Me.pnValidation, "pnValidation")
        Me.pnValidation.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.pnValidation.LookAndFeel.UseDefaultLookAndFeel = False
        Me.pnValidation.Name = "pnValidation"
        '
        'PopUpButton2
        '
        resources.ApplyResources(Me.PopUpButton2, "PopUpButton2")
        Me.PopUpButton2.ButtonType = bv.winclient.Core.PopUpButton.PopUpButtonStyles.Reports
        Me.PopUpButton2.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Show
        Me.PopUpButton2.ImageIndex = 0
        Me.PopUpButton2.Name = "PopUpButton2"
        Me.PopUpButton2.PopUpMenu = Me.cmReports
        Me.PopUpButton2.Tag = "{Immovable}{alwayseditable}"
        '
        'cmReports
        '
        Me.cmReports.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miCaseTests})
        '
        'miCaseTests
        '
        Me.miCaseTests.Index = 0
        resources.ApplyResources(Me.miCaseTests, "miCaseTests")
        '
        'cmdDelete
        '
        resources.ApplyResources(Me.cmdDelete, "cmdDelete")
        Me.cmdDelete.Appearance.Options.UseFont = True
        Me.cmdDelete.Image = Global.EIDSS.My.Resources.Resources.Delete_Remove
        Me.cmdDelete.Name = "cmdDelete"
        '
        'ValidationGrid
        '
        resources.ApplyResources(Me.ValidationGrid, "ValidationGrid")
        Me.ValidationGrid.Cursor = System.Windows.Forms.Cursors.Default
        Me.ValidationGrid.EmbeddedNavigator.Appearance.Options.UseFont = True
        Me.ValidationGrid.MainView = Me.ValidationGridView
        Me.ValidationGrid.Name = "ValidationGrid"
        Me.ValidationGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbTestTypeLookup, Me.cbTestNameLookup, Me.cbDisease, Me.txtMemo, Me.cbPersonLookup, Me.RepositoryItemCheckEdit1, Me.cbRuleInLookup, Me.dtDateEdit1, Me.chkCaseCreated})
        Me.ValidationGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ValidationGridView})
        '
        'ValidationGridView
        '
        Me.ValidationGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colFarmID1, Me.colAnimalID, Me.colSpecies, Me.colDiseaseV, Me.colTestNameV, Me.colTestTypeV, Me.colLabSampleIdV, Me.colSampleTypeV, Me.colFieldSampleIdV, Me.colRule, Me.colCommentInterpreted, Me.colDateInterpreted, Me.colPersonInterpreted, Me.colValidated, Me.colCommentValidated, Me.colDateValidated, Me.colPersonValidated, Me.colCaseCreated})
        Me.ValidationGridView.GridControl = Me.ValidationGrid
        resources.ApplyResources(Me.ValidationGridView, "ValidationGridView")
        Me.ValidationGridView.Name = "ValidationGridView"
        Me.ValidationGridView.OptionsBehavior.AutoPopulateColumns = False
        Me.ValidationGridView.OptionsCustomization.AllowFilter = False
        Me.ValidationGridView.OptionsNavigation.EnterMoveNextColumn = True
        Me.ValidationGridView.OptionsView.RowAutoHeight = True
        Me.ValidationGridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.ValidationGridView.OptionsView.ShowGroupPanel = False
        '
        'colFarmID1
        '
        resources.ApplyResources(Me.colFarmID1, "colFarmID1")
        Me.colFarmID1.FieldName = "strFarmCode"
        Me.colFarmID1.Name = "colFarmID1"
        Me.colFarmID1.OptionsColumn.AllowEdit = False
        Me.colFarmID1.OptionsColumn.AllowFocus = False
        Me.colFarmID1.OptionsColumn.ReadOnly = True
        Me.colFarmID1.OptionsColumn.TabStop = False
        '
        'colAnimalID
        '
        resources.ApplyResources(Me.colAnimalID, "colAnimalID")
        Me.colAnimalID.FieldName = "AnimalID"
        Me.colAnimalID.Name = "colAnimalID"
        Me.colAnimalID.OptionsColumn.AllowEdit = False
        Me.colAnimalID.OptionsColumn.AllowFocus = False
        Me.colAnimalID.OptionsColumn.ReadOnly = True
        Me.colAnimalID.OptionsColumn.TabStop = False
        '
        'colSpecies
        '
        resources.ApplyResources(Me.colSpecies, "colSpecies")
        Me.colSpecies.FieldName = "Species"
        Me.colSpecies.Name = "colSpecies"
        Me.colSpecies.OptionsColumn.AllowEdit = False
        Me.colSpecies.OptionsColumn.AllowFocus = False
        Me.colSpecies.OptionsColumn.ReadOnly = True
        Me.colSpecies.OptionsColumn.TabStop = False
        '
        'colDiseaseV
        '
        resources.ApplyResources(Me.colDiseaseV, "colDiseaseV")
        Me.colDiseaseV.ColumnEdit = Me.cbDisease
        Me.colDiseaseV.FieldName = "idfsDiagnosis"
        Me.colDiseaseV.Name = "colDiseaseV"
        Me.colDiseaseV.OptionsColumn.AllowEdit = False
        Me.colDiseaseV.OptionsColumn.ReadOnly = True
        '
        'cbDisease
        '
        resources.ApplyResources(Me.cbDisease, "cbDisease")
        Me.cbDisease.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDisease.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbDisease.Name = "cbDisease"
        Me.cbDisease.Tag = "dutStandartCase"
        '
        'colTestNameV
        '
        resources.ApplyResources(Me.colTestNameV, "colTestNameV")
        Me.colTestNameV.ColumnEdit = Me.cbTestNameLookup
        Me.colTestNameV.FieldName = "idfTesting"
        Me.colTestNameV.Name = "colTestNameV"
        Me.colTestNameV.OptionsColumn.AllowEdit = False
        '
        'cbTestNameLookup
        '
        resources.ApplyResources(Me.cbTestNameLookup, "cbTestNameLookup")
        Me.cbTestNameLookup.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTestNameLookup.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbTestNameLookup.DisplayMember = "TestName"
        Me.cbTestNameLookup.Name = "cbTestNameLookup"
        Me.cbTestNameLookup.ValueMember = "idfTesting"
        '
        'colTestTypeV
        '
        resources.ApplyResources(Me.colTestTypeV, "colTestTypeV")
        Me.colTestTypeV.ColumnEdit = Me.cbTestTypeLookup
        Me.colTestTypeV.FieldName = "idfTesting"
        Me.colTestTypeV.Name = "colTestTypeV"
        Me.colTestTypeV.OptionsColumn.AllowEdit = False
        '
        'cbTestTypeLookup
        '
        resources.ApplyResources(Me.cbTestTypeLookup, "cbTestTypeLookup")
        Me.cbTestTypeLookup.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTestTypeLookup.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbTestTypeLookup.DisplayMember = "TestCategoryName"
        Me.cbTestTypeLookup.Name = "cbTestTypeLookup"
        Me.cbTestTypeLookup.ValueMember = "idfTesting"
        '
        'colLabSampleIdV
        '
        resources.ApplyResources(Me.colLabSampleIdV, "colLabSampleIdV")
        Me.colLabSampleIdV.FieldName = "strBarcode"
        Me.colLabSampleIdV.Name = "colLabSampleIdV"
        Me.colLabSampleIdV.OptionsColumn.AllowEdit = False
        Me.colLabSampleIdV.OptionsColumn.ReadOnly = True
        '
        'colSampleTypeV
        '
        resources.ApplyResources(Me.colSampleTypeV, "colSampleTypeV")
        Me.colSampleTypeV.FieldName = "strSampleName"
        Me.colSampleTypeV.Name = "colSampleTypeV"
        Me.colSampleTypeV.OptionsColumn.AllowEdit = False
        Me.colSampleTypeV.OptionsColumn.ReadOnly = True
        '
        'colFieldSampleIdV
        '
        Me.colFieldSampleIdV.FieldName = "strFieldBarcode"
        Me.colFieldSampleIdV.Name = "colFieldSampleIdV"
        Me.colFieldSampleIdV.OptionsColumn.AllowEdit = False
        Me.colFieldSampleIdV.OptionsColumn.ReadOnly = True
        resources.ApplyResources(Me.colFieldSampleIdV, "colFieldSampleIdV")
        '
        'colRule
        '
        resources.ApplyResources(Me.colRule, "colRule")
        Me.colRule.ColumnEdit = Me.cbRuleInLookup
        Me.colRule.FieldName = "idfsInterpretedStatus"
        Me.colRule.Name = "colRule"
        Me.colRule.UnboundType = DevExpress.Data.UnboundColumnType.[Boolean]
        '
        'cbRuleInLookup
        '
        resources.ApplyResources(Me.cbRuleInLookup, "cbRuleInLookup")
        Me.cbRuleInLookup.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbRuleInLookup.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbRuleInLookup.Name = "cbRuleInLookup"
        '
        'colCommentInterpreted
        '
        resources.ApplyResources(Me.colCommentInterpreted, "colCommentInterpreted")
        Me.colCommentInterpreted.ColumnEdit = Me.txtMemo
        Me.colCommentInterpreted.FieldName = "strInterpretedComment"
        Me.colCommentInterpreted.Name = "colCommentInterpreted"
        '
        'txtMemo
        '
        Me.txtMemo.MaxLength = 200
        Me.txtMemo.Name = "txtMemo"
        Me.txtMemo.ShowIcon = False
        '
        'colDateInterpreted
        '
        resources.ApplyResources(Me.colDateInterpreted, "colDateInterpreted")
        Me.colDateInterpreted.ColumnEdit = Me.dtDateEdit1
        Me.colDateInterpreted.FieldName = "datInterpretationDate"
        Me.colDateInterpreted.Name = "colDateInterpreted"
        Me.colDateInterpreted.OptionsColumn.AllowEdit = False
        '
        'dtDateEdit1
        '
        resources.ApplyResources(Me.dtDateEdit1, "dtDateEdit1")
        Me.dtDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtDateEdit1.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtDateEdit1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtDateEdit1.Name = "dtDateEdit1"
        '
        'colPersonInterpreted
        '
        resources.ApplyResources(Me.colPersonInterpreted, "colPersonInterpreted")
        Me.colPersonInterpreted.ColumnEdit = Me.cbPersonLookup
        Me.colPersonInterpreted.FieldName = "idfInterpretedByPerson"
        Me.colPersonInterpreted.Name = "colPersonInterpreted"
        Me.colPersonInterpreted.OptionsColumn.AllowEdit = False
        '
        'cbPersonLookup
        '
        resources.ApplyResources(Me.cbPersonLookup, "cbPersonLookup")
        Me.cbPersonLookup.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbPersonLookup.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbPersonLookup.DisplayMember = "FullName"
        Me.cbPersonLookup.Name = "cbPersonLookup"
        Me.cbPersonLookup.ValueMember = "idfPerson"
        '
        'colValidated
        '
        resources.ApplyResources(Me.colValidated, "colValidated")
        Me.colValidated.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.colValidated.FieldName = "blnValidateStatus"
        Me.colValidated.Name = "colValidated"
        Me.colValidated.UnboundType = DevExpress.Data.UnboundColumnType.[Boolean]
        '
        'RepositoryItemCheckEdit1
        '
        resources.ApplyResources(Me.RepositoryItemCheckEdit1, "RepositoryItemCheckEdit1")
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'colCommentValidated
        '
        resources.ApplyResources(Me.colCommentValidated, "colCommentValidated")
        Me.colCommentValidated.ColumnEdit = Me.txtMemo
        Me.colCommentValidated.FieldName = "strValidateComment"
        Me.colCommentValidated.Name = "colCommentValidated"
        '
        'colDateValidated
        '
        resources.ApplyResources(Me.colDateValidated, "colDateValidated")
        Me.colDateValidated.ColumnEdit = Me.dtDateEdit1
        Me.colDateValidated.FieldName = "datValidationDate"
        Me.colDateValidated.Name = "colDateValidated"
        Me.colDateValidated.OptionsColumn.AllowEdit = False
        '
        'colPersonValidated
        '
        resources.ApplyResources(Me.colPersonValidated, "colPersonValidated")
        Me.colPersonValidated.ColumnEdit = Me.cbPersonLookup
        Me.colPersonValidated.FieldName = "idfValidatedByPerson"
        Me.colPersonValidated.Name = "colPersonValidated"
        Me.colPersonValidated.OptionsColumn.AllowEdit = False
        '
        'colCaseCreated
        '
        resources.ApplyResources(Me.colCaseCreated, "colCaseCreated")
        Me.colCaseCreated.ColumnEdit = Me.chkCaseCreated
        Me.colCaseCreated.FieldName = "blnCaseCreated"
        Me.colCaseCreated.Name = "colCaseCreated"
        Me.colCaseCreated.OptionsColumn.AllowEdit = False
        Me.colCaseCreated.OptionsColumn.AllowFocus = False
        Me.colCaseCreated.OptionsColumn.ReadOnly = True
        Me.colCaseCreated.OptionsColumn.TabStop = False
        '
        'chkCaseCreated
        '
        resources.ApplyResources(Me.chkCaseCreated, "chkCaseCreated")
        Me.chkCaseCreated.Name = "chkCaseCreated"
        '
        'cmdNew
        '
        resources.ApplyResources(Me.cmdNew, "cmdNew")
        Me.cmdNew.Appearance.Options.UseFont = True
        Me.cmdNew.Image = Global.EIDSS.My.Resources.Resources.add
        Me.cmdNew.Name = "cmdNew"
        '
        'chkConfirmed
        '
        Me.chkConfirmed.Appearance.Options.UseFont = True
        Me.chkConfirmed.AppearanceDisabled.Options.UseFont = True
        Me.chkConfirmed.AppearanceFocused.Options.UseFont = True
        Me.chkConfirmed.AppearanceReadOnly.Options.UseFont = True
        resources.ApplyResources(Me.chkConfirmed, "chkConfirmed")
        Me.chkConfirmed.Name = "chkConfirmed"
        Me.chkConfirmed.ValueChecked = 1
        Me.chkConfirmed.ValueUnchecked = 0
        '
        'chkRequested
        '
        Me.chkRequested.Appearance.Options.UseFont = True
        Me.chkRequested.AppearanceDisabled.Options.UseFont = True
        Me.chkRequested.AppearanceFocused.Options.UseFont = True
        Me.chkRequested.AppearanceReadOnly.Options.UseFont = True
        resources.ApplyResources(Me.chkRequested, "chkRequested")
        Me.chkRequested.Name = "chkRequested"
        Me.chkRequested.ValueChecked = 1
        Me.chkRequested.ValueUnchecked = 0
        '
        'CaseTestsPanel
        '
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.KeyFieldName = "idfActivity"
        Me.Name = "CaseTestsPanel"
        Me.ObjectName = "CaseTest"
        resources.ApplyResources(Me, "$this")
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "Testing"
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.pnTests, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnTests.ResumeLayout(False)
        CType(Me.grpExternalOrganization, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpExternalOrganization.ResumeLayout(False)
        CType(Me.dtDateReceived.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtDateReceived.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtExtEmployee.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbExtOrganization.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TestGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TestGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSample, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTestType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTestResult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtDateEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTestCategory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTestDiagnosis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkHasAmendment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTestStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnValidation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnValidation.ResumeLayout(False)
        CType(Me.ValidationGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValidationGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDisease, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTestNameLookup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTestTypeLookup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbRuleInLookup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMemo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbPersonLookup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCaseCreated, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkConfirmed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkRequested, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim m_IsAsSessionTest As Boolean
    Public Sub SetColumnsVisibility(showFarmID As Boolean, showAnimalID As Boolean, showSpecies As Boolean, showCaseCreated As Boolean)
        If (showFarmID) Then
            colFarmID.Visible = True
            colFarmID.VisibleIndex = 4
            HACode = HACode.Livestock
        End If
        colFarmID1.Visible = showFarmID
        colAnimalID.Visible = showAnimalID
        colSpecies.Visible = showSpecies
        colCaseCreated.Visible = showCaseCreated
        m_IsAsSessionTest = showCaseCreated
        colAnimalID.Caption = EidssFields.Get("strAnimalCode")
        colSpecies.Caption = EidssFields.Get("strSpecies")
        AddHandler Me.OnAfterPost, AddressOf SetButtonStateAfterPost
    End Sub

    Private Sub SetButtonStateAfterPost(ByVal sender As Object, ByVal e As EventArgs)
        UpdateButtons()
    End Sub

    Protected Overrides Sub DefineBinding()
        If Me.DesignMode OrElse baseDataSet Is Nothing OrElse baseDataSet.Tables.Count = 0 Then Return
        Me.ValidationGrid.DataSource = baseDataSet.Tables(CaseTestsDetail_Db.TableValidation)

        Me.cbTestNameLookup.DataSource = baseDataSet.Tables(CaseTestsDetail_Db.TableTests)
        Me.cbTestTypeLookup.DataSource = baseDataSet.Tables(CaseTestsDetail_Db.TableTests)

        If (HACode And EIDSS.HACode.Human) = EIDSS.HACode.Human Then
            LookupBinder.BindDiagnosisHACodeRepositoryLookup(cbDisease, LookupTables.HumanStandardDiagnosis, True)
            LookupBinder.BindDiagnosisHACodeRepositoryLookup(cbTestDiagnosis, LookupTables.HumanStandardDiagnosis, True)
            LookupBinder.BindOrganizationLookup(cbExtOrganization, baseDataSet, CaseTestsDetail_Db.TableTests + ".idfPerformedByOffice", HACode.None)
            LookupBinder.BindDateEdit(dtDateReceived, baseDataSet, CaseTestsDetail_Db.TableTests + ".datReceivedDate")
            LookupBinder.BindTextEdit(txtExtEmployee, baseDataSet, CaseTestsDetail_Db.TableTests + ".strContactPerson")
            SplitContainerControl1.Panel1.MinSize = 247
        Else
            If ((HACode And HACode.Avian) = EIDSS.HACode.Avian) Then
                LookupBinder.BindDiagnosisHACodeRepositoryLookup(cbDisease, LookupTables.AvianStandardDiagnosis, True)
                LookupBinder.BindDiagnosisHACodeRepositoryLookup(cbTestDiagnosis, LookupTables.AvianStandardDiagnosis, True)
            Else
                LookupBinder.BindDiagnosisHACodeRepositoryLookup(cbDisease, LookupTables.LivestockStandardDiagnosis, True)
                LookupBinder.BindDiagnosisHACodeRepositoryLookup(cbTestDiagnosis, LookupTables.LivestockStandardDiagnosis, True)
            End If
        End If
        LookupBinder.RemoveDefaultFilterHandlers(cbTestDiagnosis)
        LookupBinder.BindBaseRepositoryLookup(Me.cbTestCategory, db.BaseReferenceType.rftTestCategory)
        LookupBinder.BindTestResultRepositoryLookup(Me.cbTestResult)
        LookupBinder.BindBaseRepositoryLookup(Me.cbTestStatus, db.BaseReferenceType.rftTestStatus)
        LookupBinder.BindBaseRepositoryLookup(Me.cbTestType, db.BaseReferenceType.rftTestName, HACode)
        BindSamplesLookup()
        LookupBinder.BindPersonRepositoryLookup(Me.cbPersonLookup)
        LookupBinder.BindBaseRepositoryLookup(cbRuleInLookup, db.BaseReferenceType.rftRuleInValue, EIDSS.HACode.All, False)
        eventManager.AttachDataHandler(CaseTestsDetail_Db.TableTests + ".idfMaterial", AddressOf SampleChanged)
        eventManager.AttachDataHandler(CaseTestsDetail_Db.TableTests + ".idfsTestName", AddressOf TestTypeChanged)
        eventManager.AttachDataHandler(CaseTestsDetail_Db.TableTests + ".datConcludedDate", AddressOf DateTestConcludedChanged)

        TestGridView.OptionsBehavior.Editable = True
        Me.TestGrid.DataSource = New DataView(baseDataSet.Tables(CaseTestsDetail_Db.TableTests))
        AddHandler CType(TestGrid.DataSource, DataView).ListChanged, AddressOf RaiseTestListChangeEvent
        If (HACode And HACode.Human) <> 0 Then
            colFieldSampleIdV.Caption = EidssFields.Get("strFieldBarcodeLocal")
        Else
            colFieldSampleIdV.Caption = EidssFields.Get("strFieldBarcodeField")
        End If
        colLabSampleIdV.Caption = EidssFields.Get("strLabBarcode")
        colSampleTypeV.Caption = EidssFields.Get("strSampleName")

        UpdateButtons()
    End Sub
    Sub BeforePost(ByVal sender As Object, ByVal e As EventArgs)
        'Bug 13081:
        'Sometimes by some unclear reason testRow("idfMaterial") is not changed from CaseTestsDetail_Db.UnknownMaterial to new id during SampleChanged event
        'This is some workaround for this problem
        'Before post all incorrec values of testRow("idfMaterial") are changed to id of unknown sample
        Dim sampleRow As DataRow() = CType(cbSample.DataSource, DataView).Table.Select(String.Format("idfsSampleType = {0}", CLng(SampleTypeEnum.Unknown)))
        If (sampleRow.Length > 0) Then
            Dim unknownMaterialId As Object = sampleRow(0)("idfMaterial")
            If CaseTestsDetail_Db.UnknownMaterial.Equals(unknownMaterialId) Then
                unknownMaterialId = BaseDbService.NewIntID()
                sampleRow(0)("idfMaterial") = unknownMaterialId
                sampleRow(0).EndEdit()
            End If
            Dim unknownMaterialTests As DataRow() = baseDataSet.Tables(CaseTestsDetail_Db.TableTests).Select(String.Format("idfMaterial = {0}", CaseTestsDetail_Db.UnknownMaterial))
            For Each testRow As DataRow In unknownMaterialTests
                testRow("idfMaterial") = unknownMaterialId
                testRow.EndEdit()
            Next
        End If

    End Sub

    Private Sub RaiseTestListChangeEvent(ByVal sender As Object, ByVal e As ListChangedEventArgs)
        Dim view As DataView = CType(sender, DataView)
        If (e.ListChangedType = ListChangedType.ItemAdded) Then
            Dim row As DataRow = view(e.NewIndex).Row
            Dim args As New DataRowEventArgs(row)
            RaiseEvent OnTestsCollectionChanged(Me, args)
        End If
    End Sub


    Private Sub DateTestConcludedChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        e.Row("datStartedDate") = e.Value
    End Sub

    Private Sub TestTypeChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        If e.Row("idfsTestResult") Is DBNull.Value Then
            Return
        End If
        Dim filter As String = GetTestResultFilter(e.Value, DBNull.Value) + String.Format("and  idfsReference = {0}", e.Row("idfsTestResult"))
        If (CType(cbTestResult.DataSource, DataView).Table.Select(filter).Length = 0) Then
            e.Row("idfsTestResult") = DBNull.Value
            e.Row.EndEdit()
        End If
    End Sub

    Private Sub BindSamplesLookup()
        cbSample.Columns.Clear()
        cbSample.PopupWidth = 400
        If (HACode And EIDSS.HACode.Human) = EIDSS.HACode.Human Then
            Me.colFieldID.Caption = EidssFields.Get("strFieldBarcodeLocal", "Local Sample ID")
            cbSample.Columns.AddRange(New LookUpColumnInfo() { _
                New LookUpColumnInfo("strFieldBarcode", EidssFields.Get("strFieldBarcodeLocal", "Local Sample ID"), 80), _
                New LookUpColumnInfo("strSampleName", EidssFields.Get("strSampleName", "Sample Type"), 240), _
                New LookUpColumnInfo("datFieldCollectionDate", EidssFields.Get("datCollectionDate", "Collection Date"), 80, FormatType.DateTime, "d", True, HorzAlignment.Default)})

        ElseIf ((HACode And HACode.Avian) = EIDSS.HACode.Avian) Then
            Me.colFieldID.Caption = EidssFields.Get("strFieldBarcodeField", "Field Sample ID")
            cbSample.Columns.AddRange(New LookUpColumnInfo() { _
                New LookUpColumnInfo("strFieldBarcode", EidssFields.Get("strFieldBarcodeField", "Field Sample ID"), 80), _
                 New LookUpColumnInfo("SpeciesName", EidssFields.Get("strSpeciesType", "Species"), 80)})

        Else
            Me.colFieldID.Caption = EidssFields.Get("strFieldBarcodeField", "Field Sample ID")
            cbSample.Columns.AddRange(New LookUpColumnInfo() { _
               New LookUpColumnInfo("strFieldBarcode", EidssFields.Get("strFieldBarcodeField", "Field Sample ID"), 80), _
               New LookUpColumnInfo("strAnimalCode", EidssFields.Get("strAnimalCode", "Animal ID"), 80), _
               New LookUpColumnInfo("SpeciesName", EidssFields.Get("strSpeciesType", "Species"), 100)})

        End If
        LookupBinder.SetDataSource(cbSample, Nothing, "strFieldBarcode", "idfMaterial", AddressOf cbSample_SetFilter, AddressOf LookupBinder.ClearDefaultFilter)
    End Sub

    Public Sub RefreshTests(ByVal oldSampleID As Object, ByVal newSampleID As Object)
        If Utils.IsEmpty(oldSampleID) Then ' new sample is created, do nothing
            Return
        End If
        For Each testRow As DataRow In baseDataSet.Tables(CaseTestsDetail_Db.TableTests).Select(String.Format("idfMaterial = {0}", newSampleID))
            SampleChanged(Nothing, New DataFieldChangeEventArgs(testRow, baseDataSet.Tables(CaseTestsDetail_Db.TableTests).Columns("idfMaterial"), newSampleID, oldSampleID))
            If (HACode And HACode.Livestock) = HACode.Livestock Then
                For Each validationRow As DataRow In baseDataSet.Tables(CaseTestsDetail_Db.TableValidation).Select(String.Format("idfTesting = {0}", testRow("idfTesting")))
                    Dim sampleRow As DataRow() = CType(cbSample.DataSource, DataView).Table.Select(String.Format("idfMaterial = {0}", newSampleID))
                    If sampleRow.Length = 0 Then Return
                    validationRow("AnimalID") = sampleRow(0)("AnimalName")
                Next
            End If
        Next
    End Sub

    Private Sub SampleChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        If Utils.IsEmpty(e.Value) Then Return
        Dim sampleRow As DataRow() = CType(cbSample.DataSource, DataView).Table.Select(String.Format("idfMaterial = {0}", e.Value))
        If sampleRow.Length = 0 Then Return
        e.Row("strSampleName") = sampleRow(0)("strSampleName")
        e.Row("datFieldCollectionDate") = sampleRow(0)("datFieldCollectionDate")
        e.Row("strFieldBarcode") = sampleRow(0)("strFieldBarcode")
        If (HACode And HACode.Human) = HACode.Human Then
            If (sampleRow(0)("idfsSampleType").Equals(CLng(SampleTypeEnum.Unknown))) AndAlso sampleRow(0)("idfMaterial").Equals(CaseTestsDetail_Db.UnknownMaterial) Then
                sampleRow(0).SetAdded()
                e.Row("idfMaterial") = BaseDbService.NewIntID()
                sampleRow(0)("idfMaterial") = e.Row("idfMaterial")
            End If
        ElseIf ((HACode And HACode.Avian) = HACode.Avian) Then
            e.Row("AnimalName") = sampleRow(0)("AnimalName")
            e.Row("Species") = sampleRow(0)("SpeciesName")
        Else
            e.Row("AnimalName") = sampleRow(0)("AnimalName")
            e.Row("Species") = sampleRow(0)("SpeciesName")
            e.Row("strFarmCode") = sampleRow(0)("strFarmCode")
        End If
        SetExtOrganizationVisibility(Nothing)
        e.Row.EndEdit()
    End Sub

    Private Sub SetExtOrganizationVisibility(testRow As DataRow)
        If testRow Is Nothing Then
            testRow = TestGridView.GetFocusedDataRow()
        End If
        grpExternalOrganization.Visible = IsTestWithUnknownSample(testRow)
        If (grpExternalOrganization.Visible) Then
            LocateControlRow(cbExtOrganization, testRow)
            LocateControlRow(txtExtEmployee, testRow)
            LocateControlRow(dtDateReceived, testRow)
        End If
    End Sub

    Public Sub LocateControlRow(ByVal ctl As Control, ByRef row As DataRow)
        'Dim row1 As DataRow = FindRow(table, aKey, KeyFieldName)
        If ctl.DataBindings.Count > 0 Then
            If Not (ctl.DataBindings(0).BindingManagerBase Is Nothing) Then
                Dim table As DataTable = Me.baseDataSet.Tables(CaseTestsDetail_Db.TableTests)
                For i As Integer = 0 To table.Rows.Count - 1
                    If row Is table.Rows(i) Then
                        ctl.DataBindings(0).BindingManagerBase.Position = i
                        'Return row
                    End If
                Next
            End If
        End If
    End Sub


    Private Function IsTestWithUnknownSample(testRow As DataRow) As Boolean
        If testRow Is Nothing OrElse cbSample.DataSource Is Nothing Then
            Return False
        End If
        Dim sampleRow As DataRow() = CType(cbSample.DataSource, DataView).Table.Select(String.Format("idfMaterial = {0}", IIf(Utils.IsEmpty(testRow("idfMaterial")), -1, testRow("idfMaterial"))))
        If sampleRow.Length = 0 Then Return False
        Return sampleRow(0)("idfsSampleType").Equals(CLng(SampleTypeEnum.Unknown))
    End Function
    'Private Function MakeRuleTable() As DataTable
    '    Dim table As DataTable = New DataTable
    '    table.Columns.Add("status", GetType(Long))
    '    table.Columns.Add("name", GetType(String))
    '    Dim row As DataRow = table.NewRow
    '    row("status") = 10100002
    '    row("name") = EidssMessages.Get("LabTestRuleOut", "Rule Out")
    '    table.Rows.Add(row)
    '    row = table.NewRow
    '    row("status") = 10100001
    '    row("name") = EidssMessages.Get("LabTestRuleIn", "Rule In")
    '    table.Rows.Add(row)
    '    Return table
    'End Function

    Private m_HACode As HACode = HACode.Livestock

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property HACode() As HACode
        Get
            Return m_HACode
        End Get
        Set(ByVal Value As HACode)
            If (Value And HACode.Human) = HACode.Human Then colAnimal.Visible = False
            If (Value And (HACode.Avian Or HACode.Livestock)) <> 0 Then
                colTestBarcode.Visible = False
                colDepartment.Visible = False
                If (Value And HACode.Livestock) <> 0 Then
                    colAnimal.Caption = EidssFields.Get("strAnimalCode")
                Else
                    colAnimal.Caption = EidssFields.Get("strSpecies")
                End If
            End If
            m_HACode = Value
            If Not CaseTestsDbService Is Nothing Then
                CaseTestsDbService.HACode = m_HACode
            End If
        End Set
    End Property

    Private m_DiseaseID As Long = -1

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public WriteOnly Property DiagnosisID() As Long
        Set(ByVal Value As Long)
            If m_DiseaseID <> Value Then
                m_DiseaseID = Value
                'If CaseTestsDbService.PopulateTestsToPerform(baseDataSet, Value) = False Then
                'ErrorForm.ShowError(CaseTestsDbService.LastError)
                'End If
            End If
        End Set
    End Property
    Private m_DiagnosesList() As Long
    Private m_DiagnosisFilter As String
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public WriteOnly Property DiagnosisList() As Long()
        Set(ByVal Value As Long())
            m_DiagnosesList = Value
            m_DiagnosisFilter = ""
            For Each d As String In m_DiagnosesList
                If m_DiagnosisFilter = "" Then
                    m_DiagnosisFilter = d.ToString
                Else
                    m_DiagnosisFilter += "," + d.ToString
                End If


            Next
        End Set
    End Property

    Sub ShowTestDetails(ByVal TestIndex As Integer)
        ShowFF()
        SetExtOrganizationVisibility(TestGridView.GetDataRow(TestIndex))
    End Sub


    Dim m_ShowPopupImmediatly As Boolean = False

    Private Sub TestGridView_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles TestGridView.CellValueChanged
        UpdateButtons(False)
    End Sub




    Private Sub TestGridView_ShowingEditor(ByVal sender As Object, ByVal e As CancelEventArgs) _
        Handles TestGridView.ShowingEditor
        If TestGridView.FocusedColumn Is colAmendment Then
            e.Cancel = True
            Return
        End If
        If TestGridView.FocusedColumn Is colSampleID Then
            e.Cancel = True
            Return
        End If
        Dim row As DataRow = TestGridView.GetFocusedDataRow
        If Not row Is Nothing Then
            If (baseDataSet.Tables(CaseTestsDetail_Db.TableValidation).Select(String.Format("idfTesting = {0}", row("idfTesting")), Nothing, DataViewRowState.CurrentRows).Length > 0) Then
                e.Cancel = True
                Return
            End If
            If (Not row("blnNonLaboratoryTest").Equals(True)) Then
                e.Cancel = True
                Return
            End If
        End If

    End Sub

    Private Sub TestGridView_ShownEditor(ByVal sender As Object, ByVal e As EventArgs) Handles TestGridView.ShownEditor
        If Me.Created = False Then
            Return
        End If
        If _
            Not TestGridView.ActiveEditor Is Nothing AndAlso TypeOf (TestGridView.ActiveEditor) Is LookUpEdit AndAlso _
            m_ShowPopupImmediatly Then
            CType(TestGridView.ActiveEditor, LookUpEdit).ShowPopup()
            m_ShowPopupImmediatly = False
        End If
    End Sub

    Function GetSpecimenName(ByVal row As DataRow) As String
        Dim str As String = ""
        If Not row Is Nothing Then
            If Utils.Str(row("strBarcode")) <> "" Then
                str = Utils.Str(row("strSampleName")) + ", " + Utils.Str(row("strBarcode"))
            Else
                str = Utils.Str(row("strSampleName"))
            End If
        End If
        Return str
    End Function

    Private Function GetCurrentTestRow() As DataRow
        If TestGridView.RowCount = 0 Then Return Nothing
        Return TestGridView.GetDataRow(TestGridView.FocusedRowHandle)
    End Function

    Public WriteOnly Property SamplesView() As DataView
        Set(ByVal value As DataView)
            If Not value.Table Is Nothing AndAlso value.Table.Columns.Contains("intOrder") Then
                value.Sort = "intOrder"
            End If
            cbSample.DataSource = value
        End Set
    End Property
    Dim m_Updating As Boolean = False

    Private Sub TestGridView_FocusedRowChanged(ByVal sender As Object, ByVal e As FocusedRowChangedEventArgs) _
        Handles TestGridView.FocusedRowChanged
        If WinUtils.IsComponentInDesignMode(Me) Then
            Return
        End If
        'If Loading OrElse m_Updating Then Return
        If m_Updating Then Return
        m_Updating = True
        Try
            If _
                e.PrevFocusedRowHandle <> GridControl.InvalidRowHandle AndAlso e.PrevFocusedRowHandle <> GridControl.NewItemRowHandle AndAlso _
                IsTestRowValid(e.PrevFocusedRowHandle) = False Then
                TestGridView.FocusedRowHandle = e.PrevFocusedRowHandle
                Return
            End If
            ShowTestDetails(e.FocusedRowHandle)
        Finally
            UpdateButtons()
            m_Updating = False
        End Try
    End Sub

#Region "Flexible Form Support"

    '--------- Flexible Form

    '    Private Function SelectTemplate (ByVal strTestType As String) As String
    '        Dim r As DataRow = GetCurrentRow()
    '        Dim err As ErrorMessage = Nothing
    '        Dim st, stCountry As String

    '        If strTestType = "" Then
    '            strTestType = "?"
    '        End If

    '        stCountry = EIDSS.model.Core.EidssSiteContext.Instance.CountryID.ToString
    ''BaseDbService.ExecScalar("select idfsCountry from Site where idfsSite = dbo.fnSiteID()", CaseTestsDbService.Connection, err).ToString

    '        st = CaseTestsDbService.GetFFTemplate ("ftyTestDetails", strTestType + "," + stCountry)

    '        'If (Me.HACode And HACode.Animal) <> 0 Then
    '        '    st = CaseTestsDbService.GetFFTemplate("ftyVet_Lab_Test_Details", strTestType + "," + stCountry)
    '        'Else
    '        '    st = CaseTestsDbService.GetFFTemplate("fftLabTestsDetails", strTestType + "," + stCountry)
    '        'End If

    '        Return st

    '    End Function

    'Private Function SelectTemplate() As String
    '    Dim err As ErrorMessage
    '    Dim testType As String
    '    Dim row As DataRow = GetCurrentTestRow()
    '    testType = Utils.Str(row("idfsTest_Type"), "Unknown")
    '    Try
    '        Return Me.CaseTestsDbService.ExecScalar(String.Format("select dbo.fn_FFGetTemplateByControlParam('{0}','fftLabTestsDetails')", testType), CaseTestsDbService.Connection, err).ToString
    '    Catch ex As Exception
    '        ErrorForm.ShowError(ex)
    '        Return Nothing
    '    End Try
    'End Function
    Private m_LastFFObjectId As Object = Nothing

    Private Sub ShowFF()
        ''kletkin
        'Exit Sub
        'Dim stTemplate As String ' Different forms for Different Test Types
        'Dim HACode As Integer ' Different forms for Animals and Humans
        ''---- Save
        ''If (Not m_LastFFObjectId Is Nothing) Then
        ''    ffLabTestDetails.SaveData()
        ''End If

        Dim row As DataRow = GetCurrentTestRow()
        Dim obs As Object = Nothing
        If Not (row Is Nothing) Then
            obs = row("idfObservation")
        End If

        If Utils.IsEmpty(obs) OrElse Utils.IsEmpty(row.Item("idfsTestName")) OrElse row("blnNonLaboratoryTest").Equals(True) Then
            ffLabTestDetails.Visible = False
        Else
            ffLabTestDetails.ShowFlexibleFormByDeterminant(CType(row.Item("idfsTestName"), Long), CType(obs, Long), _
                                                          FFType.TestDetails)
            ffLabTestDetails.Visible = True
        End If

        'stTemplate = 
        'If Not Utils.IsEmpty(stTemplate) Then
        '    'ffLabTestDetails.FFObjectID.ObjectId = m_LastFFObjectId
        '    ffLabTestDetails.RefreshFlexForm(stTemplate, m_LastFFObjectId, "Activity_Parameters", "")
        'Else
        '    m_LastFFObjectId = Nothing
        '    ffLabTestDetails.ClearFForm()
        'End If
        'ffLabTestDetails.Visible = True

    End Sub

    '--------- Flexible Form

#End Region

    Public Overrides Function GetChildKey(ByVal child As IRelatedObject) As Object
        If child Is Me.ffLabTestDetails Then
            Return Nothing
        End If
        Return MyBase.GetChildKey(child)
    End Function

    Public Function HasTests() As Boolean
        Return baseDataSet.Tables(CaseTestsDetail_Db.TableTests).Rows.Count > 0
    End Function


    Public Overrides Function ValidateData() As Boolean
        For i As Integer = 0 To Me.TestGridView.RowCount - 1
            If IsTestRowValid(i, True) = False Then
                Return False
            End If
        Next
        For i As Integer = 0 To Me.ValidationGridView.RowCount - 1
            If IsValidationRowValid(i, True) = False Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Function IsValidationRowValid(Optional ByVal index As Integer = -1, Optional ByVal showError As Boolean = True) _
        As Boolean
        If index = GridControl.InvalidRowHandle Then index = Me.ValidationGridView.FocusedRowHandle
        'If index < 0 Then Return True
        Dim row As DataRow = Me.ValidationGridView.GetDataRow(index)

        If row Is Nothing Then Return True
        Dim IsValid As Boolean = True
        Dim msg As String = ""
        If Utils.IsEmpty(row("idfsDiagnosis")) Then
            If showError Then
                msg += StandardErrorHelper.Error(StandardError.Mandatory, colDiseaseV.Caption) + vbCrLf
                ErrorForm.ShowWarningDirect(msg)
            End If
            Return False
        End If
        If Utils.IsEmpty(row("idfsInterpretedStatus")) Then
            If showError Then
                msg += StandardErrorHelper.Error(StandardError.Mandatory, colRule.Caption) + vbCrLf
                ErrorForm.ShowWarningDirect(msg)
            End If
            Return False
        End If

        Return True
    End Function
    Private Class FieldCaptionPair
        Property FieldName As String
        Property FieldCaption As String
        Public Sub New(ByVal aFieldName As String, ByVal aFieldCaption As String)
            FieldName = aFieldName
            FieldCaption = aFieldCaption
        End Sub
    End Class
    Private m_TestMandatoryFields As New List(Of FieldCaptionPair)
    Private Sub InitManadatoryFields()
        If (m_TestMandatoryFields.Count = 0) Then
            m_TestMandatoryFields.AddRange({New FieldCaptionPair("idfMaterial", colFieldID.Caption), _
                                            New FieldCaptionPair("idfsDiagnosis", colDiagnosis.Caption), _
                                            New FieldCaptionPair("idfsTestName", colTestName.Caption), _
                                            New FieldCaptionPair("idfsTestResult", colTestResult.Caption)})
        End If
    End Sub

    Private Function IsTestRowValid(Optional ByVal index As Integer = -1, Optional ByVal showError As Boolean = True) _
        As Boolean
        Dim row As DataRow
        If (index >= 0) Then
            row = TestGridView.GetDataRow(index)
        Else
            row = Me.TestGridView.GetFocusedDataRow
        End If
        If row Is Nothing Then Return True
        If Not row("blnNonLaboratoryTest").Equals(True) Then
            Return True
        End If
        Dim msg As String = ""
        InitManadatoryFields()
        For Each f As FieldCaptionPair In m_TestMandatoryFields
            If Utils.IsEmpty(row(f.FieldName)) Then
                If showError Then
                    WinUtils.ShowMandatoryError(f.FieldCaption)
                End If
                Return False
            End If

        Next
        If Not DateValidator Is Nothing Then
            Return DateValidator.Validate(row, showError)
        Else
            Return True
        End If

    End Function
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property DisableTestAdding As Boolean

    Public Sub UpdateButtons(Optional showError As Boolean = False)
        ''kletkin
        TestGridView.OptionsBehavior.Editable = Not [ReadOnly]
        EnableRowAdding((Not [ReadOnly] AndAlso m_CanAddTest AndAlso Not DisableTestAdding AndAlso IsTestRowValid(, showError)))
        Dim testRow As DataRow = TestGridView.GetFocusedDataRow()
        If testRow Is Nothing Then
            btnDeleteTest.Enabled = False
            cmdNew.Enabled = False
            Me.cmdDelete.Enabled = False
            Return
        End If
        btnDeleteTest.Enabled = Not [ReadOnly] AndAlso m_CanDeleteTest AndAlso TestGridView.FocusedRowHandle >= 0 _
            AndAlso testRow("blnNonLaboratoryTest").Equals(True) _
            AndAlso Not testRow("blnReadOnly").Equals(True) _
            AndAlso baseDataSet.Tables(CaseTestsDetail_Db.TableValidation).Select(String.Format("idfTesting = {0}", testRow("idfTesting"))).Length = 0


        'cmdTestDetail.Enabled = Not [ReadOnly] AndAlso TestGridView.FocusedRowHandle >= 0
        'cbStatus.Enabled = Not [ReadOnly] AndAlso TestGridView.FocusedRowHandle >= 0 AndAlso IsTestRowValid(TestGridView.FocusedRowHandle, False)
        Dim canNew As Boolean = False
        If TestGridView.SelectedRowsCount > 0 Then
            If (testRow("idfsTestStatus").Equals(CLng(TestStatus.Finalized)) _
                    OrElse testRow("idfsTestStatus").Equals(CLng(TestStatus.Amended))) _
                    AndAlso IsTestRowValid(TestGridView.FocusedRowHandle, False) Then
                canNew = True
                If ValidationGridView.FocusedRowHandle <> GridControl.InvalidRowHandle Then
                    canNew = IsValidationRowValid(ValidationGridView.FocusedRowHandle, False)
                End If
            End If
        End If
        cmdNew.Enabled = canNew AndAlso (Not [ReadOnly]) AndAlso EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(eidss.model.Enums.EIDSSPermissionObject.CanValidateTestResult))



        Dim validationRow As DataRow = ValidationGridView.GetFocusedDataRow()
        Dim canDelete As Boolean = Not validationRow Is Nothing AndAlso validationRow.RowState = DataRowState.Added
        cmdDelete.Enabled = canDelete

    End Sub

    Public Function HasSample(ByVal sampleID As Object) As Boolean
        'If Utils.IsEmpty(sampleID) Then Return False
        'For Each row As DataRow In baseDataSet.Tables(CaseTestsDetail_Db.TableTests).Rows
        '    If row.RowState <> DataRowState.Deleted Then
        '        If row("idfMaterial").Equals(sampleID) Then
        '            Return True
        '        End If
        '    End If
        'Next
        Return False
    End Function

    Private Sub miCaseTests_Click(ByVal sender As Object, ByVal e As EventArgs) Handles miCaseTests.Click
        If baseDataSet Is Nothing OrElse baseDataSet.Tables.Count = 0 Then
            Return
        End If
        If CType(ParentObject, BaseForm).Post(PostType.FinalPosting) Then
            Dim id As Long = CType(DbService.ID, Long)
            Dim table As DataTable = Me.baseDataSet.Tables(CaseTestsDetail_Db.TableTests)

            EidssSiteContext.ReportFactory.LimTest(id, Me.HACode = eidss.HACode.Human)
        End If
    End Sub

    Private Sub PopUpButton2_BeforePopup(ByVal sender As Object, ByVal e As System.EventArgs) Handles PopUpButton2.BeforePopup
        If TestGridView.RowCount > 0 Then
            miCaseTests.Enabled = True
        Else
            miCaseTests.Enabled = False
        End If
    End Sub

    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Overrides Property [ReadOnly]() As Boolean
        Get
            Return MyBase.ReadOnly
        End Get
        Set(ByVal value As Boolean)
            MyBase.ReadOnly = value
            Me.ffLabTestDetails.ReadOnly = True
            UpdateButtons()
        End Set
    End Property

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDelete.Click
        Me.ValidationGridView.DeleteSelectedRows()
    End Sub

    Private Sub btnNew_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNew.Click
        If Me.TestGridView.FocusedRowHandle = GridControl.InvalidRowHandle Then Exit Sub
        Dim test As DataRow = Me.TestGridView.GetDataRow(Me.TestGridView.FocusedRowHandle)
        Dim table As DataTable = Me.baseDataSet.Tables(CaseTestsDetail_Db.TableValidation)
        Dim row As DataRow = table.NewRow
        row("idfTesting") = test("idfTesting")
        row("idfsDiagnosis") = test("idfsDiagnosis")
        row("idfTestValidation") = BaseDbService.NewIntID()
        row("blnCaseCreated") = False
        test("TestName") = LookupCache.GetLookupValue(test("idfsTestName"), db.BaseReferenceType.rftTestName, "name")
        test("TestCategoryName") = LookupCache.GetLookupValue(test("idfsTestCategory"), db.BaseReferenceType.rftTestCategory, "name")
        row("AnimalID") = test("AnimalName")
        row("Species") = test("Species")
        row("strFarmCode") = test("strFarmCode")
        row("strBarcode") = test("strBarcode")
        row("strFieldBarcode") = test("strFieldBarcode")
        row("strSampleName") = test("strSampleName")
        table.Rows.Add(row)
        Me.ValidationGridView.FocusedRowHandle = Me.ValidationGridView.RowCount - 1
        ValidationGridView.Focus()
    End Sub

    Private Sub ValidationGridView_FocusedRowChanged(ByVal sender As Object, ByVal e As FocusedRowChangedEventArgs) _
        Handles ValidationGridView.FocusedRowChanged
        If _
            e.PrevFocusedRowHandle <> GridControl.InvalidRowHandle AndAlso _
            IsTestRowValid(e.PrevFocusedRowHandle) = False Then
            Me.ValidationGridView.FocusedRowHandle = e.PrevFocusedRowHandle
        Else
            UpdateButtons()
        End If
    End Sub

    Private Sub ValidationGridView_CellValueChanging(ByVal sender As Object, ByVal e As CellValueChangedEventArgs) _
        Handles ValidationGridView.CellValueChanging
        Dim row As DataRow = Me.ValidationGridView.GetDataRow(e.RowHandle)
        If e.Column Is Me.colRule Then
            row("datInterpretationDate") = DateTime.Now
            row("idfInterpretedByPerson") = eidss.model.Core.EidssUserContext.User.EmployeeID
            Me.ValidationGridView.RefreshRow(e.RowHandle)
        End If
        If e.Column Is Me.colValidated Then
            If Utils.IsEmpty(e.Value) OrElse CType(e.Value, Boolean) = False Then
                row("datValidationDate") = DBNull.Value
                row("idfValidatedByPerson") = DBNull.Value
            Else
                row("datValidationDate") = DateTime.Now
                row("idfValidatedByPerson") = eidss.model.Core.EidssUserContext.User.EmployeeID
            End If
            Me.ValidationGridView.RefreshRow(e.RowHandle)
        End If
    End Sub



    Private Function GetAmendedRowUnderMouse(ByVal e As System.Windows.Forms.MouseEventArgs) As DataRow
        Dim hi As GridHitInfo = TestGridView.CalcHitInfo(e.Location)
        If hi.InRowCell AndAlso hi.Column.FieldName = "intHasAmendment" Then
            Dim row As DataRow = TestGridView.GetDataRow(hi.RowHandle)
            If Not row Is Nothing AndAlso Not Utils.IsEmpty(row("intHasAmendment")) AndAlso CInt(row("intHasAmendment")) = 1 Then
                Return row
            End If
        End If
        Return Nothing
    End Function
    Private Sub TestGridView_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles TestGridView.MouseMove
        If Not GetAmendedRowUnderMouse(e) Is Nothing Then
            Cursor = Cursors.Hand
        Else
            Cursor = Cursors.Default
        End If

    End Sub

    Private Sub TestGridView_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TestGridView.MouseUp
        If LockHandler() Then
            Try
                Dim row As DataRow = GetAmendedRowUnderMouse(e)

                If Not row Is Nothing Then
                    Dim form As IApplicationForm = CType(ClassLoader.LoadClass("LabTestAmendmentHistoryPanel"), IApplicationForm)
                    Dim id As Object = row("idfTesting")
                    BaseFormManager.ShowModal(form, FindForm(), id, Nothing, Nothing, 900, 500)
                End If

            Catch
                Throw
            Finally
                UnlockHandler()
            End Try
        End If

    End Sub

    Public Sub CreateTestForSample(ByVal fieldSampleID As String)
        If (String.IsNullOrEmpty(fieldSampleID)) Then
            Return
        End If
        If Not m_CanAddTest Then
            Return
        End If
        Dim sampleRows As DataRow() = CType(cbSample.DataSource, DataView).Table.Select(String.Format("strFieldBarcode='{0}'", fieldSampleID))
        If sampleRows.Length > 0 Then
            Dim testRow As DataRow = CaseTestsDbService.CreateTest(baseDataSet, m_DiseaseID)
            testRow("strSampleName") = sampleRows(0)("strSampleName")
            testRow("AnimalName") = sampleRows(0)("AnimalName")
            testRow("strFarmCode") = sampleRows(0)("strFarmCode")
            testRow("idfMaterial") = sampleRows(0)("idfMaterial")
            testRow.EndEdit()
            DxControlsHelper.SetRowHandleForDataRow(TestGridView, testRow, "idfTesting")
            TestGridView.FocusedColumn = colTestName
            m_ShowPopupImmediatly = True
            TestGrid.Select()
            Application.DoEvents()
            TestGridView.ShowEditor()
        Else
            ErrorForm.ShowMessageDirect(EidssMessages.Get("ErrFieldSampleIDNotFound"))
        End If
    End Sub
    Private Sub btnAddTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddTest.Click
        If Not IsTestRowValid(TestGridView.FocusedRowHandle) Then
            Return
        End If
        Dim row As DataRow = CaseTestsDbService.CreateTest(baseDataSet, m_DiseaseID)
        DxControlsHelper.SetRowHandleForDataRow(TestGridView, row, "idfTesting")
        TestGridView.FocusedColumn = colFieldID
        m_ShowPopupImmediatly = True
        TestGrid.Select()
        Application.DoEvents()
        TestGridView.ShowEditor()
        Dim args As New DataRowEventArgs(row)
        RaiseEvent OnTestsCollectionChanged(Me, args)

    End Sub

    Private Sub btnDeleteTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteTest.Click

        Dim row As DataRow = TestGridView.GetFocusedDataRow
        If Not row Is Nothing Then
            If Not CanDeleteTest(row) Then
                ErrorForm.ShowMessage("msgCantDeleteRecord", "The record can't be deleted")
                Return
            End If
            If (WinUtils.ConfirmDelete) Then
                row.Delete()
                Dim args As New DataRowEventArgs(row)
                RaiseEvent OnTestsCollectionChanged(Me, args)
            End If
        End If
    End Sub
    Private Function CanDeleteTest(ByVal row As DataRow) As Boolean
        'only non laboratory tests can be deleted
        If Utils.IsEmpty(row("blnNonLaboratoryTest")) OrElse CBool(row("blnNonLaboratoryTest")) = False Then
            Return False
        End If
        If Not Utils.IsEmpty(row("blnReadOnly")) AndAlso CBool(row("blnReadOnly")) Then
            Return False
        End If
        Dim testID As Object = row("idfTesting")
        If Utils.IsEmpty(testID) Then
            testID = -1
        End If
        'The record only can be deleted if the selected test result wasn’t interpreted
        If baseDataSet.Tables(CaseTestsDetail_Db.TableValidation).Select(String.Format("idfTesting = {0}", testID)).Length > 0 Then
            Return False
        End If
        Return True
    End Function
    Private defSampleFilter As String = ""

    Private Sub cbSample_QueryCloseUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbSample.QueryCloseUp
        If cbSample.DataSource Is Nothing Then Return
        CType(cbSample.DataSource, DataView).RowFilter = defSampleFilter

    End Sub
    Private Sub cbSample_SetFilter(ByVal sender As Object, ByVal e As EventArgs)
        If cbSample.DataSource Is Nothing Then Return
        LookupBinder.SetDefaultFilter(CType(sender, LookUpEdit), "not idfMaterial is null", True)
    End Sub

    Private Sub cbSample_QueryPopUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbSample.QueryPopUp
        If CType(cbSample.DataSource, DataView).Count = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub cbTestResult_QueryCloseUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbTestResult.QueryCloseUp
        CType(Me.cbTestResult.DataSource, DataView).RowFilter = ""
    End Sub

    Private Sub cbTestResult_QueryPopUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbTestResult.QueryPopUp
        Dim row As DataRow = TestGridView.GetFocusedDataRow
        If Not row Is Nothing Then
            CType(Me.cbTestResult.DataSource, DataView).RowFilter = GetTestResultFilter(row("idfsTestName"), row("idfsTestResult"))
        Else
            CType(Me.cbTestResult.DataSource, DataView).RowFilter = GetTestResultFilter(DBNull.Value, DBNull.Value)
        End If
    End Sub

    Private Function GetTestResultFilter(testType As Object, currentTestResult As Object) As String
        If testType Is DBNull.Value Then
            Return "idfsTestName = -1"
        ElseIf Not currentTestResult Is DBNull.Value Then
            Return String.Format("((intRowStatus = 0 or idfsReference = {1}) and idfsTestName = {0}) or idfsReference = {2}", testType, currentTestResult, LookupCache.EmptyLineKey)
        Else
            Return String.Format("(intRowStatus = 0 and idfsTestName = {0}) or idfsReference = {1}", testType, LookupCache.EmptyLineKey)
        End If

    End Function
    Private Sub cbTestDiagnosis_QueryCloseUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbTestDiagnosis.QueryCloseUp
        CType(Me.cbTestDiagnosis.DataSource, DataView).RowFilter = ""
    End Sub

    Private Sub cbTestDiagnosis_QueryPopUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbTestDiagnosis.QueryPopUp
        If Not Utils.IsEmpty(m_DiagnosisFilter) Then
            CType(Me.cbTestDiagnosis.DataSource, DataView).RowFilter = String.Format("idfsDiagnosis in ({0})", m_DiagnosisFilter)
        Else
            CType(Me.cbTestDiagnosis.DataSource, DataView).RowFilter = String.Format("idfsDiagnosis = {0}", m_DiseaseID)
        End If
    End Sub



    Private Sub CaseTestsPanel_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        SplitContainerControl1.SplitterPosition = CInt(SplitContainerControl1.Height / 2)
    End Sub

    Public Function CanDeleteSample(ByVal sampleID As Object) As Boolean
        If Utils.IsEmpty(sampleID) Then Return False
        For Each row As DataRow In baseDataSet.Tables(CaseTestsDetail_Db.TableTests).Rows
            If row.RowState <> DataRowState.Deleted Then
                If row("idfMaterial").Equals(sampleID) Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Function HasCompletedTest() As Boolean
        For Each row As DataRow In baseDataSet.Tables(CaseTestsDetail_Db.TableTests).Rows
            If row.RowState <> DataRowState.Deleted Then
                If row("idfsTestStatus").Equals(CLng(model.Enums.TestStatus.Finalized)) Then
                    Return True
                End If
            End If
        Next
        Return False
    End Function


    Private Sub ToolTipController1_GetActiveObjectInfo(ByVal sender As System.Object, ByVal e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController1.GetActiveObjectInfo
        Dim ev As New MouseEventArgs(Windows.Forms.MouseButtons.Left, 1, e.ControlMousePosition.X, e.ControlMousePosition.Y, 1)
        Dim row As DataRow = GetAmendedRowUnderMouse(ev)
        If Not row Is Nothing Then
            e.Info = New ToolTipControlInfo("Amend", colAmendment.ToolTip)
        End If
        'If (e.Info Is Nothing) Then
        '    Dim hi As GridHitInfo = TestGridView.CalcHitInfo(ev.Location)
        '    If hi.InColumn Then
        '        e.Info = New ToolTipControlInfo(hi.Column, hi.Column.Caption)
        '    End If

        'End If
    End Sub
    Public Sub SetMainTestForSample(idfTesting As Object, idfMaterial As Object)
        If (Utils.IsEmpty(idfMaterial) OrElse Utils.IsEmpty(idfTesting)) Then
            Return
        End If
        For Each row As DataRow In baseDataSet.Tables(CaseTestsDetail_Db.TableTests).Select(String.Format("idfMaterial = {0}", idfMaterial))
            If (row("idfTesting").Equals(idfTesting)) Then
                row("blnIsMainSampleTest") = True
            ElseIf Not row("blnIsMainSampleTest") Is DBNull.Value Then
                row("blnIsMainSampleTest") = DBNull.Value
            End If
        Next
    End Sub

    Private Sub CaseTestsPanel_VisibleChanged(sender As Object, e As System.EventArgs) Handles Me.VisibleChanged
        If Visible Then
            ShowTestDetails(TestGridView.FocusedRowHandle)
        End If
    End Sub

    Public ReadOnly Property Grid As GridControl
        Get
            Return Me.TestGrid
        End Get
    End Property
    Public Property DateValidator As DateChainValidator
    Protected Overrides Sub RegisterValidators()
        DateValidator = New DateChainValidator(Me, TestGrid, CaseTestsDetail_Db.TableTests, "datConcludedDate", colDateTested.Caption, , , "idfMaterial={0}", True, "idfMaterial", AddressOf UpdateButtons)
    End Sub
    Private Sub TestGridView_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles TestGridView.InitNewRow
        Dim row As DataRow = TestGridView.GetDataRow(e.RowHandle)
        CaseTestsDbService.InitTestRow(row, m_DiseaseID)
        Dim args As New DataRowEventArgs(row)
        RaiseEvent OnTestsCollectionChanged(Me, args)
    End Sub


    Public Sub EnableRowAdding(enable As Boolean)
        If (TestGridView.FocusedRowHandle = GridControl.NewItemRowHandle) Then
            Return
        End If
        If (Not enable) Then
            TestGridView.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        Else
            TestGridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top
        End If
    End Sub

    Public Function AsSessionCanCreateCase(farmCode As String) As Boolean
        If (String.IsNullOrEmpty(farmCode)) Then
            Return False
        End If
        Return baseDataSet.Tables(CaseTestsDetail_Db.TableValidation).Select(String.Format( _
            "ISNULL(idfsInterpretedStatus,0) = 10104001 and ISNULL(blnValidateStatus,0) = 1 and ISNULL(blnCaseCreated,0)=0 and strFarmCode = '{0}'", farmCode)).Length > 0
    End Function
    Private ReadOnly Property TestGridLayoutName As String
        Get
            If (HACode And HACode.Livestock) > 0 Then
                If m_IsAsSessionTest Then
                    Return "AsSession_Tests"
                Else
                    Return "LivestockCase_Tests"
                End If
            ElseIf (HACode And HACode.Avian) > 0 Then
                Return "AvianCase_Tests"
            Else
                Return "HumanCase_Tests"
            End If
        End Get
    End Property
    Private ReadOnly Property ValidationGridLayoutName As String
        Get
            If (HACode And HACode.Livestock) > 0 Then
                If m_IsAsSessionTest Then
                    Return "AsSession_TestsValidation"
                Else
                    Return "LivestockCase_TestsValidation"
                End If
            ElseIf (HACode And HACode.Avian) > 0 Then
                Return "AvianCase_TestsValidation"
            Else
                Return "HumanCase_TestsValidation"
            End If
        End Get
    End Property
    Protected Overrides Sub SaveGridLayouts()
        TestGridView.SaveGridLayout(TestGridLayoutName)
        ValidationGridView.SaveGridLayout(ValidationGridLayoutName)
    End Sub
    'Local Sample ID, Sample Type, Test Name, Test Diagnosis, Result Date, Test Status, Result/Observation
    'Diagnosis, Test Name, Rule Out/Rule In, Validated (Y/N)
    Protected Overrides Sub LoadGridLayouts()
        TestGridView.InitXtraGridCustomization(New String() {"strFieldBarcode", "strSampleName", "idfsTestName", "idfsDiagnosis", "datConcludedDate", "TestStatus", "idfsTestResult"})
        ValidationGridView.InitXtraGridCustomization(New String() {"idfsDiagnosis", "TestName", "idfsInterpretedStatus", "blnValidateStatus", "datConcludedDate"})
        TestGridView.LoadGridLayout(TestGridLayoutName)
        ValidationGridView.LoadGridLayout(ValidationGridLayoutName)
    End Sub

End Class
