Imports bv.common.db
Imports bv.winclient.Core
Imports System.ComponentModel
Imports eidss.model.Core
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors
Imports bv.winclient.BasePanel
Imports bv.winclient.Layout
Imports EIDSS.model.Enums
Imports EIDSS.model.Resources

Public Class LabTestDetail

    Inherits BaseDetailForm

    Dim LabTestDbService As LabTest_DB

#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()


        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        LabTestDbService = New LabTest_DB

        DbService = LabTestDbService
        AuditObject = New Core.EIDSSAuditObject(EIDSSAuditObject.daoTest, AuditTable.tlbTesting)
        Me.PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.Test

        Me.RegisterChildObject(Me.ffTestDetails, RelatedPostOrder.PostLast)
        'Dim dblCS As New FlexibleForm_DB(ffLabTestDetails)
        'Me.RegisterChildObject(ffLabTestDetail, RelatedPostOrder.PostLast)

        ' FLEX GRID EXAMPLE
        'Me.RegisterChildObject(fgTestGrid, RelatedPostOrder.PostLast)
        ' FLEX GRID EXAMPLE

        Me.Sizable = False
        Me.m_RelatedLists = New String() {"LabTestListItem", "LabBatchListItem", "LabSampleLogBookListItem", "LabSampleLogBookMyPrefListItem"}
        Me.btnAmend.Visible = EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSS.model.Enums.EIDSSPermissionObject.CanAmendTest))

        If (Not BaseSettings.LabSimplifiedMode) Then
            For Each btn As EditorButton In txtBatchID.Properties.Buttons
                btn.Enabled = False
            Next
        End If


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

    Private components As System.ComponentModel.IContainer


    'NOTE: The following procedure is required by the Windows Form Designer

    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents tcTest As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tpGeneral As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tpTestDetail As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents lbTestName As System.Windows.Forms.Label
    Friend WithEvents lbTestCategory As System.Windows.Forms.Label
    Friend WithEvents lbTestStatus As System.Windows.Forms.Label
    Friend WithEvents lbTestedBy As System.Windows.Forms.Label
    Friend WithEvents lbTestStartedDate As System.Windows.Forms.Label
    Friend WithEvents lbTestResult As System.Windows.Forms.Label
    Friend WithEvents cbTestedBy As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents dtExecutionDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cbOrganization As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lbLaboratory As System.Windows.Forms.Label
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents PopupMenu1 As DevExpress.XtraBars.PopupMenu
    Friend WithEvents bbiTestResults As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbiResultNotofication As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PopUpButton1 As bv.common.win.PopUpButton
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents lbCaseID As System.Windows.Forms.Label
    Friend WithEvents lbBatchID As System.Windows.Forms.Label
    Friend WithEvents lbTestDiagnosis As System.Windows.Forms.Label
    Friend WithEvents txtBatchID As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents ffTestDetails As EIDSS.FlexibleForms.FFPresenter
    Friend WithEvents txtSessionID As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents lbSessionID As System.Windows.Forms.Label
    Friend WithEvents txtComments As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents lbComments As System.Windows.Forms.Label
    Friend WithEvents cbTestResult As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cbTestStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cbTestDiagnosiis As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cbTestCategory As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cbTestName As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cbValidatedBy As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lbValidatedBy As System.Windows.Forms.Label
    Friend WithEvents dtTestConcludedDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lbTestConcludedDate As System.Windows.Forms.Label
    Friend WithEvents lbResultEnterdBy As System.Windows.Forms.Label
    Friend WithEvents tpSampleDetail As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents txtParty As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lPartyType As System.Windows.Forms.Label
    Friend WithEvents dtCollectedDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lbCollectedDate As System.Windows.Forms.Label
    Friend WithEvents txtSampleBarcode As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents lbSampleID As System.Windows.Forms.Label
    Friend WithEvents txtSampleType As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbSampleType As System.Windows.Forms.Label
    Friend WithEvents tpAmendmentHistory As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents btnAmend As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtResultEnteredBy As DevExpress.XtraEditors.TextEdit
    Friend WithEvents AmendmentGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents AmendmentView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colAmendmentDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPerson As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrganization As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNewTestResult As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colReasonOfAmendment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lblOriginalTestResult As System.Windows.Forms.Label
    Friend WithEvents txtOriginalTestResult As System.Windows.Forms.TextBox
    Friend WithEvents txtCaseID As DevExpress.XtraEditors.ButtonEdit

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LabTestDetail))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.tcTest = New DevExpress.XtraTab.XtraTabControl()
        Me.tpGeneral = New DevExpress.XtraTab.XtraTabPage()
        Me.cbTestName = New DevExpress.XtraEditors.LookUpEdit()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.bbiTestResults = New DevExpress.XtraBars.BarButtonItem()
        Me.bbiResultNotofication = New DevExpress.XtraBars.BarButtonItem()
        Me.cbTestCategory = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbTestDiagnosiis = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbTestStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbTestResult = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtComments = New DevExpress.XtraEditors.MemoEdit()
        Me.cbTestedBy = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtResultEnteredBy = New DevExpress.XtraEditors.TextEdit()
        Me.dtExecutionDate = New DevExpress.XtraEditors.DateEdit()
        Me.dtTestConcludedDate = New DevExpress.XtraEditors.DateEdit()
        Me.cbValidatedBy = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtBatchID = New DevExpress.XtraEditors.ButtonEdit()
        Me.cbOrganization = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtCaseID = New DevExpress.XtraEditors.ButtonEdit()
        Me.txtSessionID = New DevExpress.XtraEditors.ButtonEdit()
        Me.lbValidatedBy = New System.Windows.Forms.Label()
        Me.lbTestConcludedDate = New System.Windows.Forms.Label()
        Me.lbResultEnterdBy = New System.Windows.Forms.Label()
        Me.lbComments = New System.Windows.Forms.Label()
        Me.lbSessionID = New System.Windows.Forms.Label()
        Me.lbBatchID = New System.Windows.Forms.Label()
        Me.lbCaseID = New System.Windows.Forms.Label()
        Me.lbLaboratory = New System.Windows.Forms.Label()
        Me.lbTestResult = New System.Windows.Forms.Label()
        Me.lbTestStartedDate = New System.Windows.Forms.Label()
        Me.lbTestedBy = New System.Windows.Forms.Label()
        Me.lbTestStatus = New System.Windows.Forms.Label()
        Me.lbTestDiagnosis = New System.Windows.Forms.Label()
        Me.lbTestCategory = New System.Windows.Forms.Label()
        Me.lbTestName = New System.Windows.Forms.Label()
        Me.tpTestDetail = New DevExpress.XtraTab.XtraTabPage()
        Me.ffTestDetails = New EIDSS.FlexibleForms.FFPresenter()
        Me.tpSampleDetail = New DevExpress.XtraTab.XtraTabPage()
        Me.txtSampleType = New DevExpress.XtraEditors.TextEdit()
        Me.lbSampleType = New System.Windows.Forms.Label()
        Me.txtParty = New DevExpress.XtraEditors.TextEdit()
        Me.lPartyType = New System.Windows.Forms.Label()
        Me.dtCollectedDate = New DevExpress.XtraEditors.DateEdit()
        Me.lbCollectedDate = New System.Windows.Forms.Label()
        Me.txtSampleBarcode = New DevExpress.XtraEditors.ButtonEdit()
        Me.lbSampleID = New System.Windows.Forms.Label()
        Me.tpAmendmentHistory = New DevExpress.XtraTab.XtraTabPage()
        Me.txtOriginalTestResult = New System.Windows.Forms.TextBox()
        Me.lblOriginalTestResult = New System.Windows.Forms.Label()
        Me.AmendmentGrid = New DevExpress.XtraGrid.GridControl()
        Me.AmendmentView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colAmendmentDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPerson = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrganization = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNewTestResult = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colReasonOfAmendment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PopupMenu1 = New DevExpress.XtraBars.PopupMenu()
        Me.PopUpButton1 = New bv.common.win.PopUpButton()
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.btnAmend = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.tcTest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcTest.SuspendLayout()
        Me.tpGeneral.SuspendLayout()
        CType(Me.cbTestName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTestCategory.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTestDiagnosiis.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTestStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTestResult.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComments.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTestedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtResultEnteredBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtExecutionDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtExecutionDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTestConcludedDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTestConcludedDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbValidatedBy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBatchID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbOrganization.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCaseID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSessionID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpTestDetail.SuspendLayout()
        Me.tpSampleDetail.SuspendLayout()
        CType(Me.txtSampleType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtParty.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtCollectedDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtCollectedDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSampleBarcode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpAmendmentHistory.SuspendLayout()
        CType(Me.AmendmentGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AmendmentView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tcTest
        '
        resources.ApplyResources(Me.tcTest, "tcTest")
        Me.tcTest.Name = "tcTest"
        Me.tcTest.SelectedTabPage = Me.tpGeneral
        Me.tcTest.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tpGeneral, Me.tpTestDetail, Me.tpSampleDetail, Me.tpAmendmentHistory})
        '
        'tpGeneral
        '
        Me.tpGeneral.Controls.Add(Me.cbTestName)
        Me.tpGeneral.Controls.Add(Me.cbTestCategory)
        Me.tpGeneral.Controls.Add(Me.cbTestDiagnosiis)
        Me.tpGeneral.Controls.Add(Me.cbTestStatus)
        Me.tpGeneral.Controls.Add(Me.cbTestResult)
        Me.tpGeneral.Controls.Add(Me.txtComments)
        Me.tpGeneral.Controls.Add(Me.cbTestedBy)
        Me.tpGeneral.Controls.Add(Me.txtResultEnteredBy)
        Me.tpGeneral.Controls.Add(Me.dtExecutionDate)
        Me.tpGeneral.Controls.Add(Me.dtTestConcludedDate)
        Me.tpGeneral.Controls.Add(Me.cbValidatedBy)
        Me.tpGeneral.Controls.Add(Me.txtBatchID)
        Me.tpGeneral.Controls.Add(Me.cbOrganization)
        Me.tpGeneral.Controls.Add(Me.txtCaseID)
        Me.tpGeneral.Controls.Add(Me.txtSessionID)
        Me.tpGeneral.Controls.Add(Me.lbValidatedBy)
        Me.tpGeneral.Controls.Add(Me.lbTestConcludedDate)
        Me.tpGeneral.Controls.Add(Me.lbResultEnterdBy)
        Me.tpGeneral.Controls.Add(Me.lbComments)
        Me.tpGeneral.Controls.Add(Me.lbSessionID)
        Me.tpGeneral.Controls.Add(Me.lbBatchID)
        Me.tpGeneral.Controls.Add(Me.lbCaseID)
        Me.tpGeneral.Controls.Add(Me.lbLaboratory)
        Me.tpGeneral.Controls.Add(Me.lbTestResult)
        Me.tpGeneral.Controls.Add(Me.lbTestStartedDate)
        Me.tpGeneral.Controls.Add(Me.lbTestedBy)
        Me.tpGeneral.Controls.Add(Me.lbTestStatus)
        Me.tpGeneral.Controls.Add(Me.lbTestDiagnosis)
        Me.tpGeneral.Controls.Add(Me.lbTestCategory)
        Me.tpGeneral.Controls.Add(Me.lbTestName)
        Me.tpGeneral.Name = "tpGeneral"
        resources.ApplyResources(Me.tpGeneral, "tpGeneral")
        '
        'cbTestName
        '
        resources.ApplyResources(Me.cbTestName, "cbTestName")
        Me.cbTestName.MenuManager = Me.BarManager1
        Me.cbTestName.Name = "cbTestName"
        Me.cbTestName.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTestName.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbTestName.Tag = "{K}"
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbiTestResults, Me.bbiResultNotofication})
        Me.BarManager1.MaxItemId = 2
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        resources.ApplyResources(Me.barDockControlTop, "barDockControlTop")
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        resources.ApplyResources(Me.barDockControlBottom, "barDockControlBottom")
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        resources.ApplyResources(Me.barDockControlLeft, "barDockControlLeft")
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        resources.ApplyResources(Me.barDockControlRight, "barDockControlRight")
        '
        'bbiTestResults
        '
        resources.ApplyResources(Me.bbiTestResults, "bbiTestResults")
        Me.bbiTestResults.Id = 0
        Me.bbiTestResults.Name = "bbiTestResults"
        '
        'bbiResultNotofication
        '
        resources.ApplyResources(Me.bbiResultNotofication, "bbiResultNotofication")
        Me.bbiResultNotofication.Id = 1
        Me.bbiResultNotofication.Name = "bbiResultNotofication"
        '
        'cbTestCategory
        '
        resources.ApplyResources(Me.cbTestCategory, "cbTestCategory")
        Me.cbTestCategory.MenuManager = Me.BarManager1
        Me.cbTestCategory.Name = "cbTestCategory"
        Me.cbTestCategory.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTestCategory.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbTestCategory.Tag = "{K}"
        '
        'cbTestDiagnosiis
        '
        resources.ApplyResources(Me.cbTestDiagnosiis, "cbTestDiagnosiis")
        Me.cbTestDiagnosiis.MenuManager = Me.BarManager1
        Me.cbTestDiagnosiis.Name = "cbTestDiagnosiis"
        Me.cbTestDiagnosiis.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTestDiagnosiis.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbTestDiagnosiis.Tag = "{K}"
        '
        'cbTestStatus
        '
        resources.ApplyResources(Me.cbTestStatus, "cbTestStatus")
        Me.cbTestStatus.MenuManager = Me.BarManager1
        Me.cbTestStatus.Name = "cbTestStatus"
        Me.cbTestStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTestStatus.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbTestStatus.Tag = "{M}"
        '
        'cbTestResult
        '
        resources.ApplyResources(Me.cbTestResult, "cbTestResult")
        Me.cbTestResult.MenuManager = Me.BarManager1
        Me.cbTestResult.Name = "cbTestResult"
        Me.cbTestResult.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTestResult.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbTestResult.Tag = ""
        '
        'txtComments
        '
        resources.ApplyResources(Me.txtComments, "txtComments")
        Me.txtComments.MenuManager = Me.BarManager1
        Me.txtComments.Name = "txtComments"
        '
        'cbTestedBy
        '
        resources.ApplyResources(Me.cbTestedBy, "cbTestedBy")
        Me.cbTestedBy.Name = "cbTestedBy"
        Me.cbTestedBy.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTestedBy.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbTestedBy.Properties.NullText = resources.GetString("cbTestedBy.Properties.NullText")
        Me.cbTestedBy.Tag = "{R}"
        '
        'txtResultEnteredBy
        '
        resources.ApplyResources(Me.txtResultEnteredBy, "txtResultEnteredBy")
        Me.txtResultEnteredBy.MenuManager = Me.BarManager1
        Me.txtResultEnteredBy.Name = "txtResultEnteredBy"
        Me.txtResultEnteredBy.Tag = "{R}"
        '
        'dtExecutionDate
        '
        resources.ApplyResources(Me.dtExecutionDate, "dtExecutionDate")
        Me.dtExecutionDate.Name = "dtExecutionDate"
        Me.dtExecutionDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtExecutionDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("dtExecutionDate.Properties.Buttons1"), CType(resources.GetObject("dtExecutionDate.Properties.Buttons2"), Integer), CType(resources.GetObject("dtExecutionDate.Properties.Buttons3"), Boolean), CType(resources.GetObject("dtExecutionDate.Properties.Buttons4"), Boolean), CType(resources.GetObject("dtExecutionDate.Properties.Buttons5"), Boolean), CType(resources.GetObject("dtExecutionDate.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("dtExecutionDate.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, resources.GetString("dtExecutionDate.Properties.Buttons8"), CType(resources.GetObject("dtExecutionDate.Properties.Buttons9"), Object), CType(resources.GetObject("dtExecutionDate.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("dtExecutionDate.Properties.Buttons11"), Boolean))})
        Me.dtExecutionDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtExecutionDate.Tag = "{R}"
        '
        'dtTestConcludedDate
        '
        resources.ApplyResources(Me.dtTestConcludedDate, "dtTestConcludedDate")
        Me.dtTestConcludedDate.Name = "dtTestConcludedDate"
        Me.dtTestConcludedDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtTestConcludedDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("dtTestConcludedDate.Properties.Buttons1"), CType(resources.GetObject("dtTestConcludedDate.Properties.Buttons2"), Integer), CType(resources.GetObject("dtTestConcludedDate.Properties.Buttons3"), Boolean), CType(resources.GetObject("dtTestConcludedDate.Properties.Buttons4"), Boolean), CType(resources.GetObject("dtTestConcludedDate.Properties.Buttons5"), Boolean), CType(resources.GetObject("dtTestConcludedDate.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("dtTestConcludedDate.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, resources.GetString("dtTestConcludedDate.Properties.Buttons8"), CType(resources.GetObject("dtTestConcludedDate.Properties.Buttons9"), Object), CType(resources.GetObject("dtTestConcludedDate.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("dtTestConcludedDate.Properties.Buttons11"), Boolean))})
        Me.dtTestConcludedDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtTestConcludedDate.Tag = "{R}"
        '
        'cbValidatedBy
        '
        resources.ApplyResources(Me.cbValidatedBy, "cbValidatedBy")
        Me.cbValidatedBy.Name = "cbValidatedBy"
        Me.cbValidatedBy.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbValidatedBy.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbValidatedBy.Properties.NullText = resources.GetString("cbValidatedBy.Properties.NullText")
        Me.cbValidatedBy.Tag = "{R}"
        '
        'txtBatchID
        '
        resources.ApplyResources(Me.txtBatchID, "txtBatchID")
        Me.txtBatchID.MenuManager = Me.BarManager1
        Me.txtBatchID.Name = "txtBatchID"
        Me.txtBatchID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtBatchID.Tag = "{R}"
        '
        'cbOrganization
        '
        resources.ApplyResources(Me.cbOrganization, "cbOrganization")
        Me.cbOrganization.Name = "cbOrganization"
        Me.cbOrganization.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbOrganization.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbOrganization.Properties.NullText = resources.GetString("cbOrganization.Properties.NullText")
        Me.cbOrganization.Tag = "{R}"
        '
        'txtCaseID
        '
        resources.ApplyResources(Me.txtCaseID, "txtCaseID")
        Me.txtCaseID.MenuManager = Me.BarManager1
        Me.txtCaseID.Name = "txtCaseID"
        Me.txtCaseID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtCaseID.Tag = "{R}"
        '
        'txtSessionID
        '
        resources.ApplyResources(Me.txtSessionID, "txtSessionID")
        Me.txtSessionID.MenuManager = Me.BarManager1
        Me.txtSessionID.Name = "txtSessionID"
        Me.txtSessionID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtSessionID.Tag = "{R}"
        '
        'lbValidatedBy
        '
        resources.ApplyResources(Me.lbValidatedBy, "lbValidatedBy")
        Me.lbValidatedBy.Name = "lbValidatedBy"
        '
        'lbTestConcludedDate
        '
        resources.ApplyResources(Me.lbTestConcludedDate, "lbTestConcludedDate")
        Me.lbTestConcludedDate.Name = "lbTestConcludedDate"
        '
        'lbResultEnterdBy
        '
        resources.ApplyResources(Me.lbResultEnterdBy, "lbResultEnterdBy")
        Me.lbResultEnterdBy.Name = "lbResultEnterdBy"
        '
        'lbComments
        '
        resources.ApplyResources(Me.lbComments, "lbComments")
        Me.lbComments.Name = "lbComments"
        '
        'lbSessionID
        '
        resources.ApplyResources(Me.lbSessionID, "lbSessionID")
        Me.lbSessionID.Name = "lbSessionID"
        '
        'lbBatchID
        '
        resources.ApplyResources(Me.lbBatchID, "lbBatchID")
        Me.lbBatchID.Name = "lbBatchID"
        '
        'lbCaseID
        '
        resources.ApplyResources(Me.lbCaseID, "lbCaseID")
        Me.lbCaseID.Name = "lbCaseID"
        '
        'lbLaboratory
        '
        resources.ApplyResources(Me.lbLaboratory, "lbLaboratory")
        Me.lbLaboratory.Name = "lbLaboratory"
        '
        'lbTestResult
        '
        resources.ApplyResources(Me.lbTestResult, "lbTestResult")
        Me.lbTestResult.Name = "lbTestResult"
        '
        'lbTestStartedDate
        '
        resources.ApplyResources(Me.lbTestStartedDate, "lbTestStartedDate")
        Me.lbTestStartedDate.Name = "lbTestStartedDate"
        '
        'lbTestedBy
        '
        resources.ApplyResources(Me.lbTestedBy, "lbTestedBy")
        Me.lbTestedBy.Name = "lbTestedBy"
        '
        'lbTestStatus
        '
        resources.ApplyResources(Me.lbTestStatus, "lbTestStatus")
        Me.lbTestStatus.Name = "lbTestStatus"
        '
        'lbTestDiagnosis
        '
        resources.ApplyResources(Me.lbTestDiagnosis, "lbTestDiagnosis")
        Me.lbTestDiagnosis.Name = "lbTestDiagnosis"
        '
        'lbTestCategory
        '
        resources.ApplyResources(Me.lbTestCategory, "lbTestCategory")
        Me.lbTestCategory.Name = "lbTestCategory"
        '
        'lbTestName
        '
        resources.ApplyResources(Me.lbTestName, "lbTestName")
        Me.lbTestName.Name = "lbTestName"
        '
        'tpTestDetail
        '
        Me.tpTestDetail.Controls.Add(Me.ffTestDetails)
        Me.tpTestDetail.Name = "tpTestDetail"
        resources.ApplyResources(Me.tpTestDetail, "tpTestDetail")
        '
        'ffTestDetails
        '
        resources.ApplyResources(Me.ffTestDetails, "ffTestDetails")
        Me.ffTestDetails.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.ffTestDetails.DelayedLoadingNeeded = False
        Me.ffTestDetails.DynamicParameterEnabled = False
        Me.ffTestDetails.FormID = Nothing
        Me.ffTestDetails.HelpTopicID = Nothing
        Me.ffTestDetails.IsStatusReadOnly = False
        Me.ffTestDetails.KeyFieldName = Nothing
        Me.ffTestDetails.MultiSelect = False
        Me.ffTestDetails.Name = "ffTestDetails"
        Me.ffTestDetails.ObjectName = Nothing
        Me.ffTestDetails.SectionTableCaptionsIsVisible = True
        Me.ffTestDetails.Status = bv.common.win.FormStatus.Draft
        Me.ffTestDetails.TableName = Nothing
        '
        'tpSampleDetail
        '
        Me.tpSampleDetail.Controls.Add(Me.txtSampleType)
        Me.tpSampleDetail.Controls.Add(Me.lbSampleType)
        Me.tpSampleDetail.Controls.Add(Me.txtParty)
        Me.tpSampleDetail.Controls.Add(Me.lPartyType)
        Me.tpSampleDetail.Controls.Add(Me.dtCollectedDate)
        Me.tpSampleDetail.Controls.Add(Me.lbCollectedDate)
        Me.tpSampleDetail.Controls.Add(Me.txtSampleBarcode)
        Me.tpSampleDetail.Controls.Add(Me.lbSampleID)
        Me.tpSampleDetail.Name = "tpSampleDetail"
        resources.ApplyResources(Me.tpSampleDetail, "tpSampleDetail")
        '
        'txtSampleType
        '
        resources.ApplyResources(Me.txtSampleType, "txtSampleType")
        Me.txtSampleType.Name = "txtSampleType"
        Me.txtSampleType.Tag = "{R}"
        '
        'lbSampleType
        '
        resources.ApplyResources(Me.lbSampleType, "lbSampleType")
        Me.lbSampleType.Name = "lbSampleType"
        '
        'txtParty
        '
        resources.ApplyResources(Me.txtParty, "txtParty")
        Me.txtParty.Name = "txtParty"
        Me.txtParty.Tag = "{R}"
        '
        'lPartyType
        '
        resources.ApplyResources(Me.lPartyType, "lPartyType")
        Me.lPartyType.Name = "lPartyType"
        '
        'dtCollectedDate
        '
        resources.ApplyResources(Me.dtCollectedDate, "dtCollectedDate")
        Me.dtCollectedDate.Name = "dtCollectedDate"
        Me.dtCollectedDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtCollectedDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("dtCollectedDate.Properties.Buttons1"), CType(resources.GetObject("dtCollectedDate.Properties.Buttons2"), Integer), CType(resources.GetObject("dtCollectedDate.Properties.Buttons3"), Boolean), CType(resources.GetObject("dtCollectedDate.Properties.Buttons4"), Boolean), CType(resources.GetObject("dtCollectedDate.Properties.Buttons5"), Boolean), CType(resources.GetObject("dtCollectedDate.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("dtCollectedDate.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject3, resources.GetString("dtCollectedDate.Properties.Buttons8"), CType(resources.GetObject("dtCollectedDate.Properties.Buttons9"), Object), CType(resources.GetObject("dtCollectedDate.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("dtCollectedDate.Properties.Buttons11"), Boolean))})
        Me.dtCollectedDate.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never
        Me.dtCollectedDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtCollectedDate.Tag = "{R}"
        '
        'lbCollectedDate
        '
        resources.ApplyResources(Me.lbCollectedDate, "lbCollectedDate")
        Me.lbCollectedDate.Name = "lbCollectedDate"
        '
        'txtSampleBarcode
        '
        resources.ApplyResources(Me.txtSampleBarcode, "txtSampleBarcode")
        Me.txtSampleBarcode.Name = "txtSampleBarcode"
        Me.txtSampleBarcode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtSampleBarcode.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtSampleBarcode.Properties.Buttons1"), CType(resources.GetObject("txtSampleBarcode.Properties.Buttons2"), Integer), CType(resources.GetObject("txtSampleBarcode.Properties.Buttons3"), Boolean), CType(resources.GetObject("txtSampleBarcode.Properties.Buttons4"), Boolean), CType(resources.GetObject("txtSampleBarcode.Properties.Buttons5"), Boolean), CType(resources.GetObject("txtSampleBarcode.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), Global.EIDSS.My.Resources.Resources.Search, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject4, resources.GetString("txtSampleBarcode.Properties.Buttons7"), CType(resources.GetObject("txtSampleBarcode.Properties.Buttons8"), Object), CType(resources.GetObject("txtSampleBarcode.Properties.Buttons9"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtSampleBarcode.Properties.Buttons10"), Boolean)), New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtSampleBarcode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txtSampleBarcode.Tag = "[en]{R}"
        '
        'lbSampleID
        '
        resources.ApplyResources(Me.lbSampleID, "lbSampleID")
        Me.lbSampleID.Name = "lbSampleID"
        '
        'tpAmendmentHistory
        '
        Me.tpAmendmentHistory.Controls.Add(Me.txtOriginalTestResult)
        Me.tpAmendmentHistory.Controls.Add(Me.lblOriginalTestResult)
        Me.tpAmendmentHistory.Controls.Add(Me.AmendmentGrid)
        Me.tpAmendmentHistory.Name = "tpAmendmentHistory"
        resources.ApplyResources(Me.tpAmendmentHistory, "tpAmendmentHistory")
        '
        'txtOriginalTestResult
        '
        resources.ApplyResources(Me.txtOriginalTestResult, "txtOriginalTestResult")
        Me.txtOriginalTestResult.Name = "txtOriginalTestResult"
        '
        'lblOriginalTestResult
        '
        resources.ApplyResources(Me.lblOriginalTestResult, "lblOriginalTestResult")
        Me.lblOriginalTestResult.Name = "lblOriginalTestResult"
        '
        'AmendmentGrid
        '
        resources.ApplyResources(Me.AmendmentGrid, "AmendmentGrid")
        Me.AmendmentGrid.MainView = Me.AmendmentView
        Me.AmendmentGrid.MenuManager = Me.BarManager1
        Me.AmendmentGrid.Name = "AmendmentGrid"
        Me.AmendmentGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.AmendmentView})
        '
        'AmendmentView
        '
        Me.AmendmentView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colAmendmentDate, Me.colPerson, Me.colOrganization, Me.colNewTestResult, Me.colReasonOfAmendment})
        Me.AmendmentView.GridControl = Me.AmendmentGrid
        Me.AmendmentView.Name = "AmendmentView"
        Me.AmendmentView.OptionsBehavior.Editable = False
        Me.AmendmentView.OptionsView.ShowGroupExpandCollapseButtons = False
        Me.AmendmentView.OptionsView.ShowGroupPanel = False
        '
        'colAmendmentDate
        '
        resources.ApplyResources(Me.colAmendmentDate, "colAmendmentDate")
        Me.colAmendmentDate.FieldName = "datAmendmentDate"
        Me.colAmendmentDate.Name = "colAmendmentDate"
        '
        'colPerson
        '
        resources.ApplyResources(Me.colPerson, "colPerson")
        Me.colPerson.FieldName = "strName"
        Me.colPerson.Name = "colPerson"
        '
        'colOrganization
        '
        resources.ApplyResources(Me.colOrganization, "colOrganization")
        Me.colOrganization.FieldName = "strOffice"
        Me.colOrganization.Name = "colOrganization"
        '
        'colNewTestResult
        '
        resources.ApplyResources(Me.colNewTestResult, "colNewTestResult")
        Me.colNewTestResult.FieldName = "strNewTestResult"
        Me.colNewTestResult.Name = "colNewTestResult"
        '
        'colReasonOfAmendment
        '
        resources.ApplyResources(Me.colReasonOfAmendment, "colReasonOfAmendment")
        Me.colReasonOfAmendment.FieldName = "strReason"
        Me.colReasonOfAmendment.Name = "colReasonOfAmendment"
        '
        'PopupMenu1
        '
        Me.PopupMenu1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbiTestResults), New DevExpress.XtraBars.LinkPersistInfo(Me.bbiResultNotofication)})
        Me.PopupMenu1.Manager = Me.BarManager1
        Me.PopupMenu1.Name = "PopupMenu1"
        '
        'PopUpButton1
        '
        resources.ApplyResources(Me.PopUpButton1, "PopUpButton1")
        Me.PopUpButton1.ButtonType = bv.common.win.PopUpButton.PopUpButtonStyles.Reports
        Me.PopUpButton1.Name = "PopUpButton1"
        Me.PopUpButton1.PopUpMenu = Me.ContextMenu1
        Me.PopUpButton1.Tag = "{Immovable}{AlwaysEditable}"
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        resources.ApplyResources(Me.MenuItem1, "MenuItem1")
        '
        'btnAmend
        '
        resources.ApplyResources(Me.btnAmend, "btnAmend")
        Me.btnAmend.Name = "btnAmend"
        Me.btnAmend.Tag = "{AlwaysEditable}"
        '
        'LabTestDetail
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.btnAmend)
        Me.Controls.Add(Me.tcTest)
        Me.Controls.Add(Me.PopUpButton1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.FormID = "L04"
        Me.HelpTopicID = "lab_tests_list"
        Me.KeyFieldName = "idfTesting"
        Me.LeftIcon = CType(resources.GetObject("$this.LeftIcon"), System.Drawing.Image)
        Me.Name = "LabTestDetail"
        Me.ObjectName = "LabTest"
        Me.ShowDeleteButton = False
        Me.TableName = "Testing"
        Me.Controls.SetChildIndex(Me.barDockControlTop, 0)
        Me.Controls.SetChildIndex(Me.barDockControlBottom, 0)
        Me.Controls.SetChildIndex(Me.barDockControlRight, 0)
        Me.Controls.SetChildIndex(Me.barDockControlLeft, 0)
        Me.Controls.SetChildIndex(Me.cmdOk, 0)
        Me.Controls.SetChildIndex(Me.PopUpButton1, 0)
        Me.Controls.SetChildIndex(Me.tcTest, 0)
        Me.Controls.SetChildIndex(Me.btnAmend, 0)
        CType(Me.tcTest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tcTest.ResumeLayout(False)
        Me.tpGeneral.ResumeLayout(False)
        CType(Me.cbTestName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTestCategory.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTestDiagnosiis.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTestStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTestResult.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComments.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTestedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtResultEnteredBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtExecutionDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtExecutionDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtTestConcludedDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtTestConcludedDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbValidatedBy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBatchID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbOrganization.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCaseID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSessionID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpTestDetail.ResumeLayout(False)
        Me.tpSampleDetail.ResumeLayout(False)
        CType(Me.txtSampleType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtParty.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtCollectedDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtCollectedDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSampleBarcode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpAmendmentHistory.ResumeLayout(False)
        Me.tpAmendmentHistory.PerformLayout()
        CType(Me.AmendmentGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AmendmentView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub


#End Region



    Public Overrides Function GetChildKey(ByVal child As IRelatedObject) As Object

        Return MyBase.GetChildKey(child)
    End Function
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property IsMultiTest As Boolean
        Get
            If LabTestDbService Is Nothing Then
                Return False
            End If
            Return LabTestDbService.IsMultiTest
        End Get
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property SimpleEditMode As Boolean
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property SampleID As Object

        Get
            If Not LabTestDbService Is Nothing Then
                Return LabTestDbService.SampleID
            End If
            Return Nothing
        End Get
        Set(ByVal value As Object)
            LabTestDbService.SampleID = value
        End Set
    End Property


    Protected Overrides Sub DefineBinding()
        Dim haCode As Object = baseDataSet.Tables(LabTest_DB.TableTest).Rows(0)("intHACode")
        If (haCode Is DBNull.Value) Then
            haCode = EIDSS.HACode.None
        End If
        Core.LookupBinder.BindBaseLookup(cbTestName, baseDataSet, LabTest_DB.TableTest + ".idfsTestType", db.BaseReferenceType.rftTestType, CType(haCode, EIDSS.HACode))
        Core.LookupBinder.BindBaseLookup(cbTestCategory, baseDataSet, LabTest_DB.TableTest + ".idfsTestForDiseaseType", db.BaseReferenceType.rftTestForDiseaseType)

        Core.LookupBinder.BindDiagnosisLookup(cbTestDiagnosiis, baseDataSet, LabTest_DB.TableTest + ".idfsDiagnosis", False)
        cbTestDiagnosiis.Properties.DataSource = baseDataSet.Tables(LabTest_DB.TableDiagnosis).DefaultView
        Core.LookupBinder.BindBaseLookup(cbTestStatus, baseDataSet, LabTest_DB.TableTest + ".idfsTestStatus", db.BaseReferenceType.rftActivityStatus, False)

        If IsMultiTest Then
            CType(cbTestStatus.Properties.DataSource, DataView).RowFilter = String.Format("idfsReference in ({0}, {1})", CLng(model.Enums.TestStatus.Completed), CLng(model.Enums.TestStatus.Undefined))
        End If
        Core.LookupBinder.BindTestResultLookup(cbTestResult, baseDataSet, LabTest_DB.TableTest + ".idfsTestResult", "idfsTestType = -1")
        Core.LookupBinder.BindTextEdit(txtComments, baseDataSet, LabTest_DB.TableTest + ".strNote")

        Core.LookupBinder.BindPersonLookup(cbTestedBy, baseDataSet, LabTest_DB.TableTest + ".idfTestedByPerson")
        Core.LookupBinder.BindTextEdit(txtResultEnteredBy, baseDataSet, LabTest_DB.TableTest + ".ResultEnteredByPerson")
        Core.LookupBinder.BindDateEdit(dtExecutionDate, baseDataSet, LabTest_DB.TableTest + ".datStartedDate")
        Core.LookupBinder.BindDateEdit(dtTestConcludedDate, baseDataSet, LabTest_DB.TableTest + ".datConcludedDate")
        Core.LookupBinder.BindPersonLookup(cbValidatedBy, baseDataSet, LabTest_DB.TableTest + ".idfValidatedByPerson")

        txtBatchID.DataBindings.Add("EditValue", baseDataSet, LabTest_DB.TableTest + ".BatchTestCode")
        Core.LookupBinder.BindOrganizationLookup(cbOrganization, baseDataSet, LabTest_DB.TableTest + ".idfTestedByOffice")
        txtCaseID.DataBindings.Add("EditValue", baseDataSet, LabTest_DB.TableTest + ".strCaseID")

        txtSessionID.DataBindings.Add("EditValue", baseDataSet, LabTest_DB.TableTest + ".SessionID")

        txtSampleBarcode.DataBindings.Add("EditValue", baseDataSet, LabTest_DB.TableSample + ".strBarcode")
        txtSampleType.DataBindings.Add("EditValue", baseDataSet, LabTest_DB.TableSample + ".SpecimenType")
        Core.LookupBinder.BindDateEdit(dtCollectedDate, baseDataSet, LabTest_DB.TableSample + ".datFieldCollectionDate")
        If (CLng(CaseType.Human).Equals(baseDataSet.Tables(LabTest_DB.TableTest).Rows(0)("idfsCaseType"))) Then
            Core.LookupBinder.BindPersonalDataTextEdit(txtParty, baseDataSet, LabTest_DB.TableSample + ".strPartyName", PersonalDataGroup.Human_PersonName, False)
        Else
            Core.LookupBinder.BindTextEdit(txtParty, baseDataSet, LabTest_DB.TableSample + ".strPartyName")
        End If

        AmendmentGrid.DataSource = baseDataSet.Tables(LabTest_DB.TableAmendment).DefaultView

        eventManager.AttachDataHandler(LabTest_DB.TableTest + ".idfsTestResult", AddressOf TestResultChanged)
        eventManager.AttachDataHandler(LabTest_DB.TableTest + ".idfsTestStatus", AddressOf TestStatusChanged)
        eventManager.AttachDataHandler(LabTest_DB.TableTest + ".idfsTestType", AddressOf TestTypeChanged)

        If (Me.State And BusinessObjectState.NewObject) > 0 Then
            CType(cbTestName.Tag, TagHelper).IsMandatory = True
            SetControlMandatoryState(cbTestName)
            CType(cbTestCategory.Tag, TagHelper).IsMandatory = True
            SetControlMandatoryState(cbTestCategory)
            'CType(cbTestDiagnosiis.Tag, TagHelper).IsMandatory = True
            cbTestDiagnosiis.Tag = "{M}"
            SetControlMandatoryState(cbTestDiagnosiis)
        Else
            CType(cbTestName.Tag, TagHelper).IsReadOnly = True
            SetControlReadOnly(cbTestName, True, False)
            CType(cbTestCategory.Tag, TagHelper).IsReadOnly = True
            SetControlReadOnly(cbTestCategory, True, False)
            cbTestDiagnosiis.Tag = "{R}"
            SetControlReadOnly(cbTestDiagnosiis, True, False)
            If (IsMultiTest) Then
                For Each ctl As Control In Me.tpGeneral.Controls
                    If ctl.DataBindings.Count > 0 AndAlso LabTestDbService.ReadOnlyFields.IndexOf(ctl.DataBindings(0).BindingMemberInfo.BindingField) >= 0 Then
                        If (TypeOf (ctl.Tag) Is TagHelper) Then
                            CType(ctl.Tag, TagHelper).IsReadOnly = True
                        Else
                            ctl.Tag = "{R}"
                        End If
                        SetControlReadOnly(ctl, True, False)
                    End If
                Next
                For Each field As String In LabTestDbService.ReadOnlyFields
                Next
                btnAmend.Visible = False
                PopUpButton1.Visible = False
                tcTest.TabPages.Remove(tpAmendmentHistory)
                tcTest.TabPages.Remove(tpSampleDetail)
            End If
        End If
        eventManager.Cascade(LabTest_DB.TableTest + ".idfsTestStatus")
        eventManager.Cascade(LabTest_DB.TableTest + ".idfsTestType")
        m_BaseReadOnly = [ReadOnly]
        CheckFormState()

    End Sub
    Private m_BaseReadOnly As Boolean 'stored readonly state that was set externally
    Private Sub CheckFormState()
        Dim isReadOnly As Boolean = IsTestReadOnly()
        If isReadOnly <> [ReadOnly] Then
            [ReadOnly] = isReadOnly
        End If
        If baseDataSet.Tables(LabTest_DB.TableTest).Rows.Count > 0 Then
            SetAmendmentButtonState(baseDataSet.Tables(LabTest_DB.TableTest).Rows(0))
        End If
    End Sub
    Sub TestTypeChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        If Not (cbTestResult.Properties.DataSource Is Nothing) Then
            Dim testType As Object = e.Value
            If (Utils.IsEmpty(testType)) Then testType = -1
            If (Utils.IsEmpty(e.Row("idfsTestResult"))) Then
                CType(cbTestResult.Properties.DataSource, DataView).RowFilter = String.Format("intRowStatus = 0 and idfsTestType = {0}", testType)
            Else
                CType(cbTestResult.Properties.DataSource, DataView).RowFilter = String.Format("(intRowStatus = 0 or idfsReference = {1}) and idfsTestType = {0}", testType, e.Row("idfsTestResult"))
            End If
        End If
        ShowFF()
    End Sub
    Sub TestResultChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        If e.Value Is DBNull.Value Then
            e.Row("idfResultEnteredByPerson") = DBNull.Value
            e.Row("idfResultEnteredByOffice") = DBNull.Value
            e.Row("ResultEnteredByPerson") = DBNull.Value
            e.Row.EndEdit()
        Else
            If Not e.Row("idfResultEnteredByPerson").Equals(EIDSS.model.Core.EidssUserContext.User.EmployeeID) Then
                e.Row("idfResultEnteredByPerson") = EIDSS.model.Core.EidssUserContext.User.EmployeeID
                e.Row("ResultEnteredByPerson") = EIDSS.model.Core.EidssUserContext.User.FullName
                e.Row("idfResultEnteredByOffice") = EIDSS.model.Core.EidssUserContext.User.OrganizationID
                e.Row.EndEdit()
            End If

        End If
    End Sub

    Function IsTestReadOnly() As Boolean
        Dim row As DataRow = baseDataSet.Tables(LabTest_DB.TableTest).Rows(0)
        If (Not Utils.IsEmpty(row("idfBatchTest"))) Then
            Return True
        End If
        If (row("idfsTestStatus").Equals(CLng(TestStatus.Completed)) OrElse row("idfsTestStatus").Equals(CLng(TestStatus.Amended))) Then
            Return True
        End If
        Return False

    End Function

    Sub AppendLine(ByRef s As String, ByVal val As Object)
        If val Is DBNull.Value OrElse val.ToString().Trim.Length = 0 Then Return
        If s.Length = 0 Then
            s += val.ToString()
        Else
            s += ", " + val.ToString()
        End If
    End Sub


    Private Sub txtSampleBarcode_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtSampleBarcode.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then
            Dim r As DataRow = baseDataSet.Tables(LabTest_DB.TableTest).Rows(0)
            Dim ContainerID As Object = r("idfContainer")
            BaseFormManager.ShowModal(New SampleDetail, FindForm, ContainerID, Nothing, Nothing)
        End If
    End Sub


#Region "Flexible Form Support"

    '--------- Flexible Form
    Private Function SelectTemplate(ByVal strTestType As String) As String
        Dim r As DataRow = GetCurrentRow()
        Dim err As ErrorMessage = Nothing
        Dim st, stCountry As String

        If strTestType = "" Then
            strTestType = "?"
        End If

        stCountry = EIDSS.model.Core.EidssSiteContext.Instance.CountryID.ToString  'BaseDbService.ExecScalar("select idfsCountry from Site where idfsSite = dbo.fnSiteID()", LabTestDbService.Connection, err).ToString

        st = LabTestDbService.GetFFTemplate("ftyTestDetails", strTestType + "," + stCountry)

        Return st


    End Function

    Private Sub ShowFF()
        If (IsMultiTest) Then
            ffTestDetails.ShowFlexibleFormGroupEditing(LabTestDbService.Observations, FFType.TestDetails)
        Else
            Dim row As DataRow = baseDataSet.Tables("LabTest").Rows(0)
            LabUtils.ShowFF(Me.ffTestDetails, row("idfsTestType"), row, FFType.TestDetails)
        End If


    End Sub

    '--------- Flexible Form

#End Region

#Region "Reports"

    'Private Function SelectTemplateCS(ByVal strTType As String) As String
    '    Dim dt As DataTable
    '    Dim err As ErrorMessage
    '    Dim st, strD As String


    '    Dim r As DataRow = GetCurrentRow()
    '    r.Item("idfsTest_Type").ToString()

    '    If strTType = "" Then
    '        strD = cbTestType.EditValue.ToString
    '    Else
    '        strD = strTType
    '    End If

    '    ' Select Template
    '    '!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!11



    '    Try
    '        ' st = LabTestDbService.ExecScalar("select dbo.fn_FFGetTemplateByControlParam('" + st + "','" + "fftLabTestsDetails" + "')", LabTestDbService.Connection, err).ToString
    '        'st = GetMaterialType()

    '        'Select Case st 'GetMaterialType()
    '        '    Case "pttHuman"
    '        '        st = LabTestDbService.ExecScalar("select dbo.fn_FFGetTemplateByControlParam('" + strD + "','" + "fftLabTestsDetails" + "')", LabTestDbService.Connection, err).ToString
    '        '    Case "pttAnimal"
    '        '        st = LabTestDbService.ExecScalar("select dbo.fn_FFGetTemplateByControlParam('" + strD + "','" + "ftyVet_Lab_Test_Details" + "')", LabTestDbService.Connection, err).ToString
    '        '    Case Else
    '        st = LabTestDbService.ExecScalar("select dbo.fn_FFGetTemplateByControlParam('" + strD + "','" + "fftLabTestsDetails" + "')", LabTestDbService.Connection, err).ToString
    '        'End Select

    '    Catch ex As Exception
    '        err = New ErrorMessage(StandardError.FillDatasetError, ex)
    '        Return Nothing
    '    End Try

    '    Return st

    'End Function


    'TR
    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        If baseDataSet Is Nothing OrElse baseDataSet.Tables.Count = 0 Then
            Return
        End If

        Dim r As DataRow = GetCurrentRow()

        If Post(PostType.FinalPosting) Then

            'stT = SelectTemplate(r.Item("idfsTest_Type").ToString)
            'Dim ObservationID As Long = CType(baseDataSet.Tables(LabTest_DB.TableTest).Rows(0)("idfObservation"), Long)
            Dim testId As Long = CType(r("idfTesting"), Long)
            Dim observationID As Long = CType(r("idfObservation"), Long)
            Dim typeID As Long = CType(r("idfsTestType"), Long)
            EidssSiteContext.ReportFactory.LimTestResult(testId, observationID, typeID)
            'DVDoc.Show_LIM_TestResults(bv.model.Model.Core.ModelUserContext.CurrentLanguage, r("idfActivity").ToString(), stT, ObservationID)
        End If


    End Sub

    'RN
    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'no report needed (Show_HUM_TestResultNotification)
        Throw New NotImplementedException("Report Show_HUM_TestResultNotification is not implemented")

        'Dim r As DataRow = GetCurrentRow()
        'Dim stT As String

        'stT = SelectTemplate(r.Item("idfsTest_Type").ToString)
        'DVDoc.Show_HUM_TestResultNotification(bv.model.Model.Core.ModelUserContext.CurrentLanguage, r("idfActivity").ToString(), stT)

    End Sub

    'Private Sub PopupMenu1_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles PopupMenu1.Popup
    '    Dim r As DataRow = GetCurrentRow()
    '    If LabTestDbService.GetHACode(r("idfActivity").ToString()) <> 2 Then
    '        MenuItem2.Enabled = False
    '    End If
    'End Sub

#End Region
    Dim LinkedTestResultsView As DataView
    Dim TestResultsView As DataView

    Dim m_Updating As Boolean = False
    Private Sub dtExecutionDate_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtExecutionDate.EditValueChanged
        If m_Updating OrElse Loading OrElse Not Created Then Return
        m_Updating = True
        m_Updating = False
    End Sub


    Private Sub txtBatchID_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtBatchID.ButtonClick
        Dim batch As Object = baseDataSet.Tables(LabTest_DB.TableTest).Rows(0)("idfBatchTest")
        If Utils.IsEmpty(batch) Then Exit Sub
        BaseFormManager.ShowModal(New BatchDetail(), FindForm, batch, Nothing, Nothing)
    End Sub

    Private Sub txtCaseID_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtCaseID.ButtonClick, txtSessionID.ButtonClick
        LabUtils.ShowCase(FindForm(), baseDataSet.Tables(LabTest_DB.TableTest).Rows(0), sender Is Me.txtSessionID)
    End Sub

    Private Sub LabTestDetail_AfterLoadData(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.AfterLoadData
        ShowFF()
        RefreshOriginalTestResult()
    End Sub
    Private Sub RefreshOriginalTestResult()
        Dim rows As DataRow() = baseDataSet.Tables(LabTest_DB.TableAmendment).Select("datAmendmentDate = min(datAmendmentDate)")
        If rows.Length > 0 Then
            txtOriginalTestResult.Text = LookupCache.GetLookupValue(rows(0)("idfsOldTestResult"), db.BaseReferenceType.rftTestResult, "name")
        Else
            txtOriginalTestResult.Text = LookupCache.GetLookupValue(baseDataSet.Tables(LabTest_DB.TableTest).Rows(0)("idfsTestResult"), db.BaseReferenceType.rftTestResult, "name")
        End If
    End Sub

    Private Sub TestStatusChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        Dim rdonly As Boolean = [ReadOnly] OrElse _
            Not (e.Value.Equals(CLng(TestStatus.Completed)) OrElse _
                 e.Value.Equals(CLng(TestStatus.InProgress)) OrElse _
                 e.Value.Equals(CLng(TestStatus.Amended)))
        ApplyControlState(cbTestResult, ControlState.Normal)
        ApplyControlState(cbTestedBy, ControlState.Normal)
        ApplyControlState(dtExecutionDate, ControlState.Normal)
        ApplyControlState(dtTestConcludedDate, ControlState.Normal)
        ApplyControlState(cbValidatedBy, ControlState.Normal)
        SetControlReadOnly(cbTestResult, rdonly, False)
        SetControlReadOnly(txtComments, rdonly, False)
        SetControlReadOnly(cbTestedBy, rdonly, False)
        SetControlReadOnly(dtExecutionDate, rdonly, False)
        SetControlReadOnly(dtTestConcludedDate, rdonly, False)
        SetControlReadOnly(cbValidatedBy, rdonly, False)
        If e.Value.Equals(CLng(TestStatus.Amended)) Then
            SetControlReadOnly(cbTestStatus, rdonly, False)
        End If
        Me.ffTestDetails.ReadOnly = rdonly
        ShowFF()
        If (e.Value Is DBNull.Value OrElse _
            e.Value.Equals(CLng(model.Enums.TestStatus.Undefined))) AndAlso Not e.Value.Equals(e.OldValue) Then
            e.Row("idfsTestResult") = DBNull.Value
            e.Row("strNote") = DBNull.Value
            e.Row("idfTestedByPerson") = DBNull.Value
            e.Row("idfTestedByOffice") = DBNull.Value
            e.Row("idfValidatedByOffice") = DBNull.Value
            e.Row("idfValidatedByPerson") = DBNull.Value
            e.Row("datStartedDate") = DBNull.Value
            e.Row("datConcludedDate") = DBNull.Value
            eventManager.Cascade(LabTest_DB.TableTest + ".idfsTestResult")
        End If
        If Not rdonly Then
            If (e.Value.Equals(CLng(model.Enums.TestStatus.Completed))) Then
                'cbTestResult.Tag = "{M}"
                SetMandatory(cbTestResult)
                'cbTestedBy.Tag = "{M}"
                SetMandatory(cbTestedBy)
                'dtExecutionDate.Tag = "{M}"
                SetMandatory(dtExecutionDate)
                'dtTestConcludedDate.Tag = "{M}"
                SetMandatory(dtTestConcludedDate)
                'cbValidatedBy.Tag = "{M}"
                SetMandatory(cbValidatedBy)
            Else
                'cbTestResult.Tag = Nothing
                ApplyControlState(cbTestResult, ControlState.Normal)
                ApplyControlState(cbTestedBy, ControlState.Normal)
                ApplyControlState(dtExecutionDate, ControlState.Normal)
                ApplyControlState(dtTestConcludedDate, ControlState.Normal)
                ApplyControlState(cbValidatedBy, ControlState.Normal)
                'LayoutCorrector.SetStyleController(cbTestResult, LayoutCorrector.DropDownStyleController)
                ''cbTestedBy.Tag = Nothing
                'LayoutCorrector.SetStyleController(cbTestedBy, LayoutCorrector.DropDownStyleController)
                ''dtExecutionDate.Tag = Nothing
                'LayoutCorrector.SetStyleController(dtExecutionDate, LayoutCorrector.EditorStyleController)
                ''dtTestConcludedDate.Tag = Nothing
                'LayoutCorrector.SetStyleController(dtTestConcludedDate, LayoutCorrector.EditorStyleController)
                ''cbValidatedBy.Tag = Nothing
                'LayoutCorrector.SetStyleController(cbValidatedBy, LayoutCorrector.DropDownStyleController)

            End If
        End If
        SetAmendmentButtonState(e.Row)
    End Sub
    Private Sub SetAmendmentButtonState(row As DataRow)
        btnAmend.Enabled = Not m_BaseReadOnly AndAlso Not row Is Nothing AndAlso row.HasVersion(DataRowVersion.Original) AndAlso _
            (row("idfsTestStatus", DataRowVersion.Original).Equals(CLng(TestStatus.Completed)) OrElse _
                            row("idfsTestStatus", DataRowVersion.Original).Equals(CLng(TestStatus.Amended)))

    End Sub
    Private Sub SetMandatory(ctl As BaseControl)
        If (TypeOf (ctl.Tag) Is TagHelper) Then
            CType(ctl.Tag, TagHelper).IsMandatory = True
            SetControlReadOnly(ctl, False, False)
        Else
            ctl.Tag = "{M}"
        End If
        SetControlMandatoryState(ctl)
    End Sub

    Private Sub cbTestedBy_QueryCloseUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbTestedBy.QueryCloseUp, cbValidatedBy.QueryCloseUp
        CType(CType(sender, LookUpEdit).Properties.DataSource, DataView).RowFilter = ""
    End Sub

    Private Sub cbTestedBy_QueryPopUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbTestedBy.QueryPopUp, cbValidatedBy.QueryPopUp
        CType(CType(sender, LookUpEdit).Properties.DataSource, DataView).RowFilter = String.Format("idfOffice = {0} and intRowStatus = 0", EIDSS.model.Core.EidssUserContext.User.OrganizationID)
    End Sub

    Private Sub cbTestStatus_EditValueChanging(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cbTestStatus.EditValueChanging
        If (e.NewValue.Equals(CLng(model.Enums.TestStatus.Amended))) Then
            e.Cancel = True
        ElseIf (e.NewValue.Equals(CLng(model.Enums.TestStatus.Undefined))) Then
            If (MessageForm.Show(EidssMessages.Get("msgConfirmTestStatusToUndefined"), "", MessageBoxButtons.YesNo) = DialogResult.No) Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private m_AmendmentRow As DataRow = Nothing
    Private Sub btnAmend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAmend.Click
        Dim id As Object = Nothing
        Dim amendmentForm As New AmendmentDetail()
        amendmentForm.TestType = CLng(IIf(baseDataSet.Tables(LabTest_DB.TableTest).Rows(0)("idfsTestType") Is DBNull.Value, -1, baseDataSet.Tables(LabTest_DB.TableTest).Rows(0)("idfsTestType")))
        amendmentForm.AmendmentRow = m_AmendmentRow
        amendmentForm.OldTestResult = CLng(baseDataSet.Tables(LabTest_DB.TableTest).Rows(0)("idfsTestResult"))
        If (bv.winclient.BasePanel.BaseFormManager.ShowModal(amendmentForm, FindForm, id, Nothing, Nothing)) Then
            If m_AmendmentRow Is Nothing Then
                m_AmendmentRow = baseDataSet.Tables(LabTest_DB.TableAmendment).NewRow
                m_AmendmentRow("idfTestAmendmentHistory") = BaseDbService.NewIntID
                m_AmendmentRow("idfTesting") = GetKey()
                m_AmendmentRow("idfAmendByOffice") = EIDSS.model.Core.EidssUserContext.User.OrganizationID
                m_AmendmentRow("idfAmendByPerson") = EIDSS.model.Core.EidssUserContext.User.EmployeeID
                m_AmendmentRow("strOffice") = LookupCache.GetLookupValue(EIDSS.model.Core.EidssUserContext.User.OrganizationID, LookupTables.Organization, "name")
                m_AmendmentRow("strName") = EIDSS.model.Core.EidssUserContext.User.FullName

                m_AmendmentRow("datAmendmentDate") = DateTime.Now
                m_AmendmentRow("idfsOldTestResult") = baseDataSet.Tables(LabTest_DB.TableTest).Rows(0)("idfsTestResult")
                m_AmendmentRow("strOldTestResult") = LookupCache.GetLookupValue(baseDataSet.Tables(LabTest_DB.TableTest).Rows(0)("idfsTestResult"), db.BaseReferenceType.rftTestResult, "name")
                Dim rows As DataRow() = baseDataSet.Tables(LabTest_DB.TableAmendment).Select("datAmendmentDate = max(datAmendmentDate)")
                If rows.Length > 0 Then
                    m_AmendmentRow("strOldNote") = rows(0)("strNewNote")
                End If

                baseDataSet.Tables(LabTest_DB.TableAmendment).Rows.Add(m_AmendmentRow)
            End If
            m_AmendmentRow("idfsNewTestResult") = amendmentForm.cbNewTestResult.EditValue
            m_AmendmentRow("strNewTestResult") = amendmentForm.cbNewTestResult.Text
            m_AmendmentRow("strReason") = amendmentForm.txtReasonForChange.EditValue
            baseDataSet.Tables(LabTest_DB.TableTest).Rows(0)("idfsTestResult") = amendmentForm.cbNewTestResult.EditValue
            baseDataSet.Tables(LabTest_DB.TableTest).Rows(0)("idfsTestStatus") = CLng(TestStatus.Amended)
            baseDataSet.Tables(LabTest_DB.TableTest).Rows(0).EndEdit()
            ForcePost = True
            If Post(PostType.IntermediatePosting) Then
                m_AmendmentRow = Nothing
            End If
            ForcePost = False
        End If
    End Sub

    Private Sub cbTestStatus_QueryCloseUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbTestStatus.QueryCloseUp
        CType(Me.cbTestStatus.Properties.DataSource, DataView).RowFilter = Nothing
    End Sub

    Private Sub cbTestStatus_QueryPopUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbTestStatus.QueryPopUp
        CType(Me.cbTestStatus.Properties.DataSource, DataView).RowFilter = "idfsReference in (10001001, 10001003, 10001005)"
    End Sub
    Public Overrides Function Post(Optional ByVal postType As bv.common.PostType = bv.common.PostType.FinalPosting) As Boolean
        Dim res As Boolean = MyBase.Post(postType)
        If res AndAlso IsMultiTest AndAlso (baseDataSet.Tables(LabTest_DB.TableTest).Rows(0)("idfsTestStatus").Equals(CLng(model.Enums.TestStatus.Completed))) Then
            [ReadOnly] = True
        End If
        Return res
    End Function
    Public Overrides Function ValidateData() As Boolean
        If Not MyBase.ValidateData() Then
            Return False
        End If
        Dim row As DataRow = baseDataSet.Tables(LabTest_DB.TableTest).Rows(0)
        If Not bv.winclient.Core.WinUtils.CompareDates(row("datStartedDate"), row("datConcludedDate"), "datBatchStartDate_ConcludedDate_msgId") Then
            dtTestConcludedDate.Focus()
            Return False
        End If

        If Not bv.winclient.Core.WinUtils.CompareDates(row("datCreationDate"), row("datStartedDate"), "datAccessionDate_BatchStartDate_msgId") Then
            dtExecutionDate.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub LabTestDetail_OnAfterPost(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.OnAfterPost
        CheckFormState()
        RefreshOriginalTestResult()
    End Sub
End Class
