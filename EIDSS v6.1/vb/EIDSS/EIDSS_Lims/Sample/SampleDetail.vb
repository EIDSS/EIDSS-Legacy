Imports bv.winclient.BasePanel
Imports System.Collections.Generic
Imports bv.winclient.Core
Imports EIDSS.Core
Imports EIDSS.model.Core
Imports EIDSS.model.Resources
Imports bv.common.Resources
Imports bv.winclient.Localization
Imports EIDSS.model.Enums
Imports DevExpress.XtraGrid
Imports bv.common.Enums
Imports bv.common.win.Validators
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class SampleDetail

    Inherits BaseDetailForm

    Dim SampleDbService As Sample_DB
    Dim cbCaseCurrentDiagnosis As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit

    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents LookUpEdit1 As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents LookUpEdit2 As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtSampleID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblMaterialType As System.Windows.Forms.Label
    Friend WithEvents txtSpecimenType As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tpTransfer As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents datToDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtToSampleID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtToID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cbToInstitution As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtFromSampleID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFromID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents datFromDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cbFromInstitution As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents tpTests As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TestGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents TestGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colTestName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbTestType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbCategory As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colDiagnosis As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbDiagnosis As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colBatch As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDateTested As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbStatus As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colResult As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbTestResult As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colDateReceived As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colContactPerson As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents tpGeneral As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtSessionID As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents txtNote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtParentID As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents cbLocation As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbCollectedByOrganization As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbCollectedByPerson As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbDepartment As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbPartyInfo As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPartyInfo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCaseID As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCaseType As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents btnSelectTest As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDeleteTest As DevExpress.XtraEditors.SimpleButton
    Private ReadOnly m_CanDeleteTest As Boolean
    Friend WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lbDestructionMethod As System.Windows.Forms.Label
    Friend WithEvents cbDestructionMethod As DevExpress.XtraEditors.LookUpEdit
    Private m_CanAddTest As Boolean
    Friend WithEvents colDateTestStarted As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents dtDateTestStarted As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents colTestedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbTestedBy As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colResultEnteredBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbResultEnteredBy As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colValidatedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbValidatedBy As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colComments As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtComments As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents colResultReceivedFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbResultReceivedFrom As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents txtAccessionInComment As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents lbAccessionInComment As System.Windows.Forms.Label
    Private m_CanFinalizeTest As Boolean
#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()


        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        SampleDbService = New Sample_DB

        DbService = SampleDbService
        AuditObject = New AuditObject(EIDSSAuditObject.daoSample, AuditTable.tlbMaterial)
        Me.PermissionObject = EIDSSPermissionObject.Sample

        Me.m_RelatedLists = New String() {"LabSampleListItem"}
        m_CanAddTest = Not [ReadOnly] AndAlso EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission(EIDSSPermissionObject.Test))
        m_CanDeleteTest = Not [ReadOnly] AndAlso EidssUserContext.User.HasPermission(PermissionHelper.DeletePermission(EIDSSPermissionObject.Test))
        btnSelectTest.Enabled = m_CanAddTest
        m_CanFinalizeTest = Not [ReadOnly] AndAlso EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.CanFinalizeLabTest))
        ValidationProcedureName = "spLabSample_Validate"

        MenuItem1.Visible = eidss.model.Reports.BaseMenuReportRegistrator.IsPaperFormAllowed("LimSample")
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
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents PopUpButton1 As bv.winclient.Core.PopUpButton

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SampleDetail))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.PopUpButton1 = New bv.winclient.Core.PopUpButton(Me.components)
        Me.Label14 = New System.Windows.Forms.Label()
        Me.LookUpEdit1 = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.LookUpEdit2 = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtSampleID = New DevExpress.XtraEditors.TextEdit()
        Me.lblMaterialType = New System.Windows.Forms.Label()
        Me.txtSpecimenType = New DevExpress.XtraEditors.TextEdit()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tpTransfer = New DevExpress.XtraTab.XtraTabPage()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.datToDate = New DevExpress.XtraEditors.DateEdit()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtToSampleID = New DevExpress.XtraEditors.TextEdit()
        Me.txtToID = New DevExpress.XtraEditors.TextEdit()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cbToInstitution = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtFromSampleID = New DevExpress.XtraEditors.TextEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFromID = New DevExpress.XtraEditors.TextEdit()
        Me.datFromDate = New DevExpress.XtraEditors.DateEdit()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cbFromInstitution = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.tpTests = New DevExpress.XtraTab.XtraTabPage()
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSelectTest = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDeleteTest = New DevExpress.XtraEditors.SimpleButton()
        Me.TestGrid = New DevExpress.XtraGrid.GridControl()
        Me.TestGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colTestName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbTestType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colCategory = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbCategory = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colDiagnosis = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbDiagnosis = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colBatch = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDateTestStarted = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.dtDateTestStarted = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.colDateTested = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbStatus = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colResult = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbTestResult = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colTestedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbTestedBy = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colResultEnteredBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbResultEnteredBy = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colValidatedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbValidatedBy = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colComments = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtComments = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.colResultReceivedFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbResultReceivedFrom = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colDateReceived = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colContactPerson = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.tpGeneral = New DevExpress.XtraTab.XtraTabPage()
        Me.txtAccessionInComment = New DevExpress.XtraEditors.MemoEdit()
        Me.lbAccessionInComment = New System.Windows.Forms.Label()
        Me.lbDestructionMethod = New System.Windows.Forms.Label()
        Me.cbDestructionMethod = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSessionID = New DevExpress.XtraEditors.ButtonEdit()
        Me.txtNote = New DevExpress.XtraEditors.MemoEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtParentID = New DevExpress.XtraEditors.ButtonEdit()
        Me.cbLocation = New DevExpress.XtraEditors.LookUpEdit()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbCollectedByOrganization = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbCollectedByPerson = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbDepartment = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbPartyInfo = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPartyInfo = New DevExpress.XtraEditors.TextEdit()
        Me.txtCaseID = New DevExpress.XtraEditors.ButtonEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCaseType = New DevExpress.XtraEditors.TextEdit()
        Me.TabControl1 = New DevExpress.XtraTab.XtraTabControl()
        CType(Me.LookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookUpEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSampleID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSpecimenType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpTransfer.SuspendLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.datToDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datToDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtToSampleID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtToID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbToInstitution.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.txtFromSampleID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFromID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datFromDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datFromDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbFromInstitution.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpTests.SuspendLayout()
        CType(Me.TestGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TestGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTestType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDiagnosis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDateTestStarted, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDateTestStarted.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTestResult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTestedBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbResultEnteredBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbValidatedBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbResultReceivedFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpGeneral.SuspendLayout()
        CType(Me.txtAccessionInComment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDestructionMethod.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSessionID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtParentID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbLocation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.cbCollectedByOrganization.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCollectedByPerson.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDepartment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPartyInfo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCaseID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCaseType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(SampleDetail), resources)
        'Form Is Localizable: True
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
        'PopUpButton1
        '
        resources.ApplyResources(Me.PopUpButton1, "PopUpButton1")
        Me.PopUpButton1.ButtonType = bv.winclient.Core.PopUpButton.PopUpButtonStyles.Reports
        Me.PopUpButton1.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Show
        Me.PopUpButton1.ImageIndex = 0
        Me.PopUpButton1.Name = "PopUpButton1"
        Me.PopUpButton1.PopUpMenu = Me.ContextMenu1
        Me.PopUpButton1.Tag = "{Immovable}{AlwaysEditable}"
        '
        'Label14
        '
        resources.ApplyResources(Me.Label14, "Label14")
        Me.Label14.Name = "Label14"
        '
        'LookUpEdit1
        '
        resources.ApplyResources(Me.LookUpEdit1, "LookUpEdit1")
        Me.LookUpEdit1.Name = "LookUpEdit1"
        Me.LookUpEdit1.Properties.AutoHeight = CType(resources.GetObject("LookUpEdit1.Properties.AutoHeight"), Boolean)
        Me.LookUpEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("LookUpEdit1.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.LookUpEdit1.Properties.NullText = resources.GetString("LookUpEdit1.Properties.NullText")
        Me.LookUpEdit1.Tag = "{R}"
        '
        'Label15
        '
        resources.ApplyResources(Me.Label15, "Label15")
        Me.Label15.Name = "Label15"
        '
        'LookUpEdit2
        '
        resources.ApplyResources(Me.LookUpEdit2, "LookUpEdit2")
        Me.LookUpEdit2.Name = "LookUpEdit2"
        Me.LookUpEdit2.Properties.AutoHeight = CType(resources.GetObject("LookUpEdit2.Properties.AutoHeight"), Boolean)
        Me.LookUpEdit2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("LookUpEdit2.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.LookUpEdit2.Properties.NullText = resources.GetString("LookUpEdit2.Properties.NullText")
        Me.LookUpEdit2.Tag = "{R}"
        '
        'txtSampleID
        '
        resources.ApplyResources(Me.txtSampleID, "txtSampleID")
        Me.txtSampleID.Name = "txtSampleID"
        Me.txtSampleID.Tag = "[en]{R}"
        '
        'lblMaterialType
        '
        resources.ApplyResources(Me.lblMaterialType, "lblMaterialType")
        Me.lblMaterialType.Name = "lblMaterialType"
        '
        'txtSpecimenType
        '
        resources.ApplyResources(Me.txtSpecimenType, "txtSpecimenType")
        Me.txtSpecimenType.Name = "txtSpecimenType"
        Me.txtSpecimenType.Tag = "{R}"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Name = "Label10"
        '
        'tpTransfer
        '
        Me.tpTransfer.Controls.Add(Me.GroupControl3)
        Me.tpTransfer.Controls.Add(Me.GroupControl2)
        Me.tpTransfer.Name = "tpTransfer"
        resources.ApplyResources(Me.tpTransfer, "tpTransfer")
        '
        'GroupControl3
        '
        resources.ApplyResources(Me.GroupControl3, "GroupControl3")
        Me.GroupControl3.Controls.Add(Me.datToDate)
        Me.GroupControl3.Controls.Add(Me.Label21)
        Me.GroupControl3.Controls.Add(Me.Label13)
        Me.GroupControl3.Controls.Add(Me.txtToSampleID)
        Me.GroupControl3.Controls.Add(Me.txtToID)
        Me.GroupControl3.Controls.Add(Me.Label18)
        Me.GroupControl3.Controls.Add(Me.cbToInstitution)
        Me.GroupControl3.Controls.Add(Me.Label19)
        Me.GroupControl3.Name = "GroupControl3"
        '
        'datToDate
        '
        resources.ApplyResources(Me.datToDate, "datToDate")
        Me.datToDate.Name = "datToDate"
        Me.datToDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("datToDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.datToDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.datToDate.Tag = "{R}"
        '
        'Label21
        '
        resources.ApplyResources(Me.Label21, "Label21")
        Me.Label21.Name = "Label21"
        '
        'Label13
        '
        resources.ApplyResources(Me.Label13, "Label13")
        Me.Label13.Name = "Label13"
        '
        'txtToSampleID
        '
        resources.ApplyResources(Me.txtToSampleID, "txtToSampleID")
        Me.txtToSampleID.Name = "txtToSampleID"
        Me.txtToSampleID.Tag = "{R}"
        '
        'txtToID
        '
        resources.ApplyResources(Me.txtToID, "txtToID")
        Me.txtToID.Name = "txtToID"
        Me.txtToID.Tag = "{R}"
        '
        'Label18
        '
        resources.ApplyResources(Me.Label18, "Label18")
        Me.Label18.Name = "Label18"
        '
        'cbToInstitution
        '
        resources.ApplyResources(Me.cbToInstitution, "cbToInstitution")
        Me.cbToInstitution.Name = "cbToInstitution"
        Me.cbToInstitution.Properties.AutoHeight = CType(resources.GetObject("cbToInstitution.Properties.AutoHeight"), Boolean)
        Me.cbToInstitution.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbToInstitution.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbToInstitution.Properties.NullText = resources.GetString("cbToInstitution.Properties.NullText")
        Me.cbToInstitution.Tag = "{R}"
        '
        'Label19
        '
        resources.ApplyResources(Me.Label19, "Label19")
        Me.Label19.Name = "Label19"
        '
        'GroupControl2
        '
        resources.ApplyResources(Me.GroupControl2, "GroupControl2")
        Me.GroupControl2.Controls.Add(Me.Label20)
        Me.GroupControl2.Controls.Add(Me.txtFromSampleID)
        Me.GroupControl2.Controls.Add(Me.Label7)
        Me.GroupControl2.Controls.Add(Me.txtFromID)
        Me.GroupControl2.Controls.Add(Me.datFromDate)
        Me.GroupControl2.Controls.Add(Me.Label16)
        Me.GroupControl2.Controls.Add(Me.cbFromInstitution)
        Me.GroupControl2.Controls.Add(Me.Label17)
        Me.GroupControl2.Name = "GroupControl2"
        '
        'Label20
        '
        resources.ApplyResources(Me.Label20, "Label20")
        Me.Label20.Name = "Label20"
        '
        'txtFromSampleID
        '
        resources.ApplyResources(Me.txtFromSampleID, "txtFromSampleID")
        Me.txtFromSampleID.Name = "txtFromSampleID"
        Me.txtFromSampleID.Tag = "{R}"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'txtFromID
        '
        resources.ApplyResources(Me.txtFromID, "txtFromID")
        Me.txtFromID.Name = "txtFromID"
        Me.txtFromID.Tag = "{R}"
        '
        'datFromDate
        '
        resources.ApplyResources(Me.datFromDate, "datFromDate")
        Me.datFromDate.Name = "datFromDate"
        Me.datFromDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("datFromDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.datFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.datFromDate.Tag = "{R}"
        '
        'Label16
        '
        resources.ApplyResources(Me.Label16, "Label16")
        Me.Label16.Name = "Label16"
        '
        'cbFromInstitution
        '
        resources.ApplyResources(Me.cbFromInstitution, "cbFromInstitution")
        Me.cbFromInstitution.Name = "cbFromInstitution"
        Me.cbFromInstitution.Properties.AutoHeight = CType(resources.GetObject("cbFromInstitution.Properties.AutoHeight"), Boolean)
        Me.cbFromInstitution.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbFromInstitution.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbFromInstitution.Properties.NullText = resources.GetString("cbFromInstitution.Properties.NullText")
        Me.cbFromInstitution.Tag = "{R}"
        '
        'Label17
        '
        resources.ApplyResources(Me.Label17, "Label17")
        Me.Label17.Name = "Label17"
        '
        'tpTests
        '
        Me.tpTests.Controls.Add(Me.btnAdd)
        Me.tpTests.Controls.Add(Me.btnSelectTest)
        Me.tpTests.Controls.Add(Me.btnDeleteTest)
        Me.tpTests.Controls.Add(Me.TestGrid)
        Me.tpTests.Name = "tpTests"
        resources.ApplyResources(Me.tpTests, "tpTests")
        '
        'btnAdd
        '
        Me.btnAdd.Image = Global.eidss.My.Resources.Resources.add
        resources.ApplyResources(Me.btnAdd, "btnAdd")
        Me.btnAdd.Name = "btnAdd"
        '
        'btnSelectTest
        '
        Me.btnSelectTest.Image = Global.eidss.My.Resources.Resources.add
        resources.ApplyResources(Me.btnSelectTest, "btnSelectTest")
        Me.btnSelectTest.Name = "btnSelectTest"
        '
        'btnDeleteTest
        '
        Me.btnDeleteTest.Image = Global.eidss.My.Resources.Resources.Delete_Remove
        resources.ApplyResources(Me.btnDeleteTest, "btnDeleteTest")
        Me.btnDeleteTest.Name = "btnDeleteTest"
        '
        'TestGrid
        '
        resources.ApplyResources(Me.TestGrid, "TestGrid")
        Me.TestGrid.Cursor = System.Windows.Forms.Cursors.Default
        Me.TestGrid.MainView = Me.TestGridView
        Me.TestGrid.Name = "TestGrid"
        Me.TestGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbTestType, Me.cbCategory, Me.cbTestResult, Me.cbStatus, Me.cbDiagnosis, Me.dtDateTestStarted, Me.cbTestedBy, Me.cbResultEnteredBy, Me.cbValidatedBy, Me.txtComments, Me.cbResultReceivedFrom})
        Me.TestGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.TestGridView, Me.GridView1})
        '
        'TestGridView
        '
        Me.TestGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colTestName, Me.colCategory, Me.colDiagnosis, Me.colBatch, Me.colDateTestStarted, Me.colDateTested, Me.colStatus, Me.colResult, Me.colTestedBy, Me.colResultEnteredBy, Me.colValidatedBy, Me.colComments, Me.colResultReceivedFrom, Me.colDateReceived, Me.colContactPerson})
        Me.TestGridView.GridControl = Me.TestGrid
        resources.ApplyResources(Me.TestGridView, "TestGridView")
        Me.TestGridView.Name = "TestGridView"
        Me.TestGridView.OptionsCustomization.AllowFilter = False
        Me.TestGridView.OptionsNavigation.EnterMoveNextColumn = True
        Me.TestGridView.OptionsView.ColumnAutoWidth = False
        Me.TestGridView.OptionsView.ShowGroupPanel = False
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
        'colCategory
        '
        resources.ApplyResources(Me.colCategory, "colCategory")
        Me.colCategory.ColumnEdit = Me.cbCategory
        Me.colCategory.FieldName = "idfsTestCategory"
        Me.colCategory.Name = "colCategory"
        '
        'cbCategory
        '
        resources.ApplyResources(Me.cbCategory, "cbCategory")
        Me.cbCategory.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbCategory.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbCategory.Name = "cbCategory"
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
        'colBatch
        '
        resources.ApplyResources(Me.colBatch, "colBatch")
        Me.colBatch.FieldName = "BatchTestCode"
        Me.colBatch.Name = "colBatch"
        Me.colBatch.OptionsColumn.AllowEdit = False
        '
        'colDateTestStarted
        '
        resources.ApplyResources(Me.colDateTestStarted, "colDateTestStarted")
        Me.colDateTestStarted.ColumnEdit = Me.dtDateTestStarted
        Me.colDateTestStarted.FieldName = "datStartedDate"
        Me.colDateTestStarted.Name = "colDateTestStarted"
        '
        'dtDateTestStarted
        '
        resources.ApplyResources(Me.dtDateTestStarted, "dtDateTestStarted")
        Me.dtDateTestStarted.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtDateTestStarted.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtDateTestStarted.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtDateTestStarted.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtDateTestStarted.Name = "dtDateTestStarted"
        '
        'colDateTested
        '
        resources.ApplyResources(Me.colDateTested, "colDateTested")
        Me.colDateTested.FieldName = "datConcludedDate"
        Me.colDateTested.Name = "colDateTested"
        '
        'colStatus
        '
        Me.colStatus.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colStatus, "colStatus")
        Me.colStatus.ColumnEdit = Me.cbStatus
        Me.colStatus.FieldName = "idfsTestStatus"
        Me.colStatus.Name = "colStatus"
        '
        'cbStatus
        '
        resources.ApplyResources(Me.cbStatus, "cbStatus")
        Me.cbStatus.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbStatus.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbStatus.Name = "cbStatus"
        '
        'colResult
        '
        resources.ApplyResources(Me.colResult, "colResult")
        Me.colResult.ColumnEdit = Me.cbTestResult
        Me.colResult.FieldName = "idfsTestResult"
        Me.colResult.Name = "colResult"
        '
        'cbTestResult
        '
        resources.ApplyResources(Me.cbTestResult, "cbTestResult")
        Me.cbTestResult.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTestResult.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbTestResult.Name = "cbTestResult"
        '
        'colTestedBy
        '
        resources.ApplyResources(Me.colTestedBy, "colTestedBy")
        Me.colTestedBy.ColumnEdit = Me.cbTestedBy
        Me.colTestedBy.FieldName = "idfTestedByPerson"
        Me.colTestedBy.Name = "colTestedBy"
        '
        'cbTestedBy
        '
        resources.ApplyResources(Me.cbTestedBy, "cbTestedBy")
        Me.cbTestedBy.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTestedBy.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbTestedBy.Name = "cbTestedBy"
        '
        'colResultEnteredBy
        '
        resources.ApplyResources(Me.colResultEnteredBy, "colResultEnteredBy")
        Me.colResultEnteredBy.ColumnEdit = Me.cbResultEnteredBy
        Me.colResultEnteredBy.FieldName = "idfResultEnteredByPerson"
        Me.colResultEnteredBy.Name = "colResultEnteredBy"
        '
        'cbResultEnteredBy
        '
        resources.ApplyResources(Me.cbResultEnteredBy, "cbResultEnteredBy")
        Me.cbResultEnteredBy.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbResultEnteredBy.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbResultEnteredBy.Name = "cbResultEnteredBy"
        '
        'colValidatedBy
        '
        resources.ApplyResources(Me.colValidatedBy, "colValidatedBy")
        Me.colValidatedBy.ColumnEdit = Me.cbValidatedBy
        Me.colValidatedBy.FieldName = "idfValidatedByPerson"
        Me.colValidatedBy.Name = "colValidatedBy"
        '
        'cbValidatedBy
        '
        resources.ApplyResources(Me.cbValidatedBy, "cbValidatedBy")
        Me.cbValidatedBy.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbValidatedBy.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbValidatedBy.Name = "cbValidatedBy"
        '
        'colComments
        '
        resources.ApplyResources(Me.colComments, "colComments")
        Me.colComments.ColumnEdit = Me.txtComments
        Me.colComments.FieldName = "strNote"
        Me.colComments.Name = "colComments"
        '
        'txtComments
        '
        resources.ApplyResources(Me.txtComments, "txtComments")
        Me.txtComments.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtComments.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtComments.Name = "txtComments"
        Me.txtComments.ShowIcon = False
        '
        'colResultReceivedFrom
        '
        resources.ApplyResources(Me.colResultReceivedFrom, "colResultReceivedFrom")
        Me.colResultReceivedFrom.ColumnEdit = Me.cbResultReceivedFrom
        Me.colResultReceivedFrom.FieldName = "idfPerformedByOffice"
        Me.colResultReceivedFrom.Name = "colResultReceivedFrom"
        '
        'cbResultReceivedFrom
        '
        resources.ApplyResources(Me.cbResultReceivedFrom, "cbResultReceivedFrom")
        Me.cbResultReceivedFrom.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbResultReceivedFrom.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbResultReceivedFrom.Name = "cbResultReceivedFrom"
        '
        'colDateReceived
        '
        resources.ApplyResources(Me.colDateReceived, "colDateReceived")
        Me.colDateReceived.FieldName = "datReceivedDate"
        Me.colDateReceived.Name = "colDateReceived"
        Me.colDateReceived.OptionsColumn.AllowEdit = False
        '
        'colContactPerson
        '
        resources.ApplyResources(Me.colContactPerson, "colContactPerson")
        Me.colContactPerson.FieldName = "strContactPerson"
        Me.colContactPerson.Name = "colContactPerson"
        Me.colContactPerson.OptionsColumn.AllowEdit = False
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.TestGrid
        Me.GridView1.Name = "GridView1"
        '
        'tpGeneral
        '
        Me.tpGeneral.Controls.Add(Me.txtAccessionInComment)
        Me.tpGeneral.Controls.Add(Me.lbAccessionInComment)
        Me.tpGeneral.Controls.Add(Me.lbDestructionMethod)
        Me.tpGeneral.Controls.Add(Me.cbDestructionMethod)
        Me.tpGeneral.Controls.Add(Me.Label11)
        Me.tpGeneral.Controls.Add(Me.txtSessionID)
        Me.tpGeneral.Controls.Add(Me.txtNote)
        Me.tpGeneral.Controls.Add(Me.Label1)
        Me.tpGeneral.Controls.Add(Me.txtParentID)
        Me.tpGeneral.Controls.Add(Me.cbLocation)
        Me.tpGeneral.Controls.Add(Me.GroupControl1)
        Me.tpGeneral.Controls.Add(Me.Label2)
        Me.tpGeneral.Controls.Add(Me.cbDepartment)
        Me.tpGeneral.Controls.Add(Me.Label3)
        Me.tpGeneral.Controls.Add(Me.Label4)
        Me.tpGeneral.Controls.Add(Me.lbPartyInfo)
        Me.tpGeneral.Controls.Add(Me.Label5)
        Me.tpGeneral.Controls.Add(Me.txtPartyInfo)
        Me.tpGeneral.Controls.Add(Me.txtCaseID)
        Me.tpGeneral.Controls.Add(Me.Label6)
        Me.tpGeneral.Controls.Add(Me.txtCaseType)
        Me.tpGeneral.Name = "tpGeneral"
        resources.ApplyResources(Me.tpGeneral, "tpGeneral")
        '
        'txtAccessionInComment
        '
        resources.ApplyResources(Me.txtAccessionInComment, "txtAccessionInComment")
        Me.txtAccessionInComment.Name = "txtAccessionInComment"
        Me.txtAccessionInComment.Tag = "{R}"
        '
        'lbAccessionInComment
        '
        resources.ApplyResources(Me.lbAccessionInComment, "lbAccessionInComment")
        Me.lbAccessionInComment.Name = "lbAccessionInComment"
        '
        'lbDestructionMethod
        '
        resources.ApplyResources(Me.lbDestructionMethod, "lbDestructionMethod")
        Me.lbDestructionMethod.Name = "lbDestructionMethod"
        '
        'cbDestructionMethod
        '
        resources.ApplyResources(Me.cbDestructionMethod, "cbDestructionMethod")
        Me.cbDestructionMethod.Name = "cbDestructionMethod"
        Me.cbDestructionMethod.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDestructionMethod.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbDestructionMethod.Properties.NullText = resources.GetString("cbDestructionMethod.Properties.NullText")
        Me.cbDestructionMethod.Tag = "{R}"
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        '
        'txtSessionID
        '
        resources.ApplyResources(Me.txtSessionID, "txtSessionID")
        Me.txtSessionID.Name = "txtSessionID"
        Me.txtSessionID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtSessionID.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtSessionID.Properties.Buttons1"), CType(resources.GetObject("txtSessionID.Properties.Buttons2"), Integer), CType(resources.GetObject("txtSessionID.Properties.Buttons3"), Boolean), CType(resources.GetObject("txtSessionID.Properties.Buttons4"), Boolean), CType(resources.GetObject("txtSessionID.Properties.Buttons5"), Boolean), CType(resources.GetObject("txtSessionID.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("txtSessionID.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, resources.GetString("txtSessionID.Properties.Buttons8"), resources.GetString("txtSessionID.Properties.Buttons9"), CType(resources.GetObject("txtSessionID.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtSessionID.Properties.Buttons11"), Boolean))})
        Me.txtSessionID.Tag = "{R}"
        '
        'txtNote
        '
        resources.ApplyResources(Me.txtNote, "txtNote")
        Me.txtNote.Name = "txtNote"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'txtParentID
        '
        resources.ApplyResources(Me.txtParentID, "txtParentID")
        Me.txtParentID.Name = "txtParentID"
        Me.txtParentID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtParentID.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtParentID.Properties.Buttons1"), CType(resources.GetObject("txtParentID.Properties.Buttons2"), Integer), CType(resources.GetObject("txtParentID.Properties.Buttons3"), Boolean), CType(resources.GetObject("txtParentID.Properties.Buttons4"), Boolean), CType(resources.GetObject("txtParentID.Properties.Buttons5"), Boolean), CType(resources.GetObject("txtParentID.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("txtParentID.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, resources.GetString("txtParentID.Properties.Buttons8"), resources.GetString("txtParentID.Properties.Buttons9"), CType(resources.GetObject("txtParentID.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtParentID.Properties.Buttons11"), Boolean))})
        Me.txtParentID.Tag = "{R}"
        '
        'cbLocation
        '
        resources.ApplyResources(Me.cbLocation, "cbLocation")
        Me.cbLocation.Name = "cbLocation"
        Me.cbLocation.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbLocation.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        '
        'GroupControl1
        '
        resources.ApplyResources(Me.GroupControl1, "GroupControl1")
        Me.GroupControl1.Controls.Add(Me.Label9)
        Me.GroupControl1.Controls.Add(Me.cbCollectedByOrganization)
        Me.GroupControl1.Controls.Add(Me.Label8)
        Me.GroupControl1.Controls.Add(Me.cbCollectedByPerson)
        Me.GroupControl1.Name = "GroupControl1"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'cbCollectedByOrganization
        '
        resources.ApplyResources(Me.cbCollectedByOrganization, "cbCollectedByOrganization")
        Me.cbCollectedByOrganization.Name = "cbCollectedByOrganization"
        Me.cbCollectedByOrganization.Properties.AutoHeight = CType(resources.GetObject("cbCollectedByOrganization.Properties.AutoHeight"), Boolean)
        Me.cbCollectedByOrganization.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbCollectedByOrganization.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbCollectedByOrganization.Properties.NullText = resources.GetString("cbCollectedByOrganization.Properties.NullText")
        Me.cbCollectedByOrganization.Tag = "{R}"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'cbCollectedByPerson
        '
        resources.ApplyResources(Me.cbCollectedByPerson, "cbCollectedByPerson")
        Me.cbCollectedByPerson.Name = "cbCollectedByPerson"
        Me.cbCollectedByPerson.Properties.AutoHeight = CType(resources.GetObject("cbCollectedByPerson.Properties.AutoHeight"), Boolean)
        Me.cbCollectedByPerson.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbCollectedByPerson.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbCollectedByPerson.Properties.NullText = resources.GetString("cbCollectedByPerson.Properties.NullText")
        Me.cbCollectedByPerson.Tag = "{R}"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'cbDepartment
        '
        resources.ApplyResources(Me.cbDepartment, "cbDepartment")
        Me.cbDepartment.Name = "cbDepartment"
        Me.cbDepartment.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDepartment.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbDepartment.Properties.NullText = resources.GetString("cbDepartment.Properties.NullText")
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'lbPartyInfo
        '
        resources.ApplyResources(Me.lbPartyInfo, "lbPartyInfo")
        Me.lbPartyInfo.Name = "lbPartyInfo"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'txtPartyInfo
        '
        resources.ApplyResources(Me.txtPartyInfo, "txtPartyInfo")
        Me.txtPartyInfo.Name = "txtPartyInfo"
        Me.txtPartyInfo.Tag = "[en]{R}"
        '
        'txtCaseID
        '
        resources.ApplyResources(Me.txtCaseID, "txtCaseID")
        Me.txtCaseID.Name = "txtCaseID"
        Me.txtCaseID.Properties.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        Me.txtCaseID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtCaseID.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtCaseID.Properties.Buttons1"), CType(resources.GetObject("txtCaseID.Properties.Buttons2"), Integer), CType(resources.GetObject("txtCaseID.Properties.Buttons3"), Boolean), CType(resources.GetObject("txtCaseID.Properties.Buttons4"), Boolean), CType(resources.GetObject("txtCaseID.Properties.Buttons5"), Boolean), CType(resources.GetObject("txtCaseID.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("txtCaseID.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject3, resources.GetString("txtCaseID.Properties.Buttons8"), resources.GetString("txtCaseID.Properties.Buttons9"), CType(resources.GetObject("txtCaseID.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtCaseID.Properties.Buttons11"), Boolean))})
        Me.txtCaseID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txtCaseID.Tag = "{R}"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'txtCaseType
        '
        resources.ApplyResources(Me.txtCaseType, "txtCaseType")
        Me.txtCaseType.Name = "txtCaseType"
        Me.txtCaseType.Tag = "{R}"
        '
        'TabControl1
        '
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedTabPage = Me.tpGeneral
        Me.TabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tpGeneral, Me.tpTests, Me.tpTransfer})
        '
        'SampleDetail
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.PopUpButton1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.txtSampleID)
        Me.Controls.Add(Me.txtSpecimenType)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lblMaterialType)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "L02"
        Me.HelpTopicID = "edit_sample"
        Me.KeyFieldName = "idfMaterial"
        Me.LeftIcon = Global.eidss.My.Resources.Resources.Sample_large
        Me.Name = "SampleDetail"
        Me.ObjectName = "Sample"
        Me.ShowDeleteButton = False
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "Material"
        Me.Controls.SetChildIndex(Me.lblMaterialType, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.txtSpecimenType, 0)
        Me.Controls.SetChildIndex(Me.txtSampleID, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.PopUpButton1, 0)
        CType(Me.LookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookUpEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSampleID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSpecimenType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpTransfer.ResumeLayout(False)
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.datToDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datToDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtToSampleID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtToID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbToInstitution.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.txtFromSampleID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFromID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datFromDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datFromDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbFromInstitution.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpTests.ResumeLayout(False)
        CType(Me.TestGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TestGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTestType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCategory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDiagnosis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtDateTestStarted.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtDateTestStarted, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTestResult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTestedBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbResultEnteredBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbValidatedBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbResultReceivedFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpGeneral.ResumeLayout(False)
        CType(Me.txtAccessionInComment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDestructionMethod.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSessionID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtParentID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbLocation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.cbCollectedByOrganization.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCollectedByPerson.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDepartment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPartyInfo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCaseID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCaseType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub


#End Region


    Protected Sub TestTypeHandler(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        e.Row("idfsTestResult") = DBNull.Value
        TestGridView.UpdateCurrentRow()
    End Sub
    Protected Sub TestStatusChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        Dim status As TestStatus = TestStatus.NotStarted
        If Not e.Value Is DBNull.Value Then
            status = CType(e.Row("idfsTestStatus"), TestStatus)
        End If
        Select Case status
            Case TestStatus.NotStarted
                e.Row("idfsTestCategory") = DBNull.Value
                e.Row("idfsTestResult") = DBNull.Value
                e.Row("idfBatchTest") = DBNull.Value
                e.Row("BatchTestCode") = DBNull.Value
                e.Row("idfsDiagnosis") = DBNull.Value
                e.Row("datStartedDate") = DBNull.Value
                e.Row("datConcludedDate") = DBNull.Value
                e.Row("blnExternalTest") = DBNull.Value
                e.Row("idfResultEnteredByOffice") = DBNull.Value
                e.Row("idfResultEnteredByPerson") = DBNull.Value
                e.Row("idfValidatedByOffice") = DBNull.Value
                e.Row("idfValidatedByPerson") = DBNull.Value
                e.Row("idfTestedByOffice") = DBNull.Value
                e.Row("idfTestedByPerson") = DBNull.Value
                e.Row("datReceivedDate") = DBNull.Value
                e.Row("strContactPerson") = DBNull.Value
                e.Row("idfPerformedByOffice") = DBNull.Value
            Case TestStatus.InProcess
                e.Row("idfsTestResult") = DBNull.Value
                SetValueIfNull(e.Row, "datStartedDate", DateTime.Today)
                e.Row("idfTestedByOffice") = EidssSiteContext.Instance.OrganizationID
                SetValueIfNull(e.Row, "idfTestedByPerson", EidssUserContext.User.EmployeeID)
                e.Row("idfResultEnteredByOffice") = DBNull.Value
                e.Row("idfResultEnteredByPerson") = DBNull.Value
                e.Row("idfValidatedByOffice") = DBNull.Value
                e.Row("idfValidatedByPerson") = DBNull.Value
                e.Row("datReceivedDate") = DBNull.Value
                e.Row("strContactPerson") = DBNull.Value
                e.Row("idfPerformedByOffice") = DBNull.Value
            Case TestStatus.Preliminary
                SetValueIfNull(e.Row, "datStartedDate", DateTime.Today)
                SetValueIfNull(e.Row, "datConcludedDate", DateTime.Today)
                e.Row("idfTestedByOffice") = EidssSiteContext.Instance.OrganizationID
                SetValueIfNull(e.Row, "idfTestedByPerson", EidssUserContext.User.EmployeeID)
                e.Row("idfResultEnteredByOffice") = EidssSiteContext.Instance.OrganizationID
                SetValueIfNull(e.Row, "idfResultEnteredByPerson", EidssUserContext.User.EmployeeID)
                e.Row("idfValidatedByOffice") = DBNull.Value
                e.Row("idfValidatedByPerson") = DBNull.Value
                e.Row("datReceivedDate") = DBNull.Value
                e.Row("strContactPerson") = DBNull.Value
                e.Row("idfPerformedByOffice") = DBNull.Value
            Case TestStatus.Finalized
                If Not btnAdd.Visible Then 'initilize fields for non external tests only
                    SetValueIfNull(e.Row, "datStartedDate", DateTime.Today)
                    e.Row("datConcludedDate") = DateTime.Today
                    e.Row("idfTestedByOffice") = EidssSiteContext.Instance.OrganizationID
                    SetValueIfNull(e.Row, "idfTestedByPerson", EidssUserContext.User.EmployeeID)
                    e.Row("idfResultEnteredByOffice") = EidssSiteContext.Instance.OrganizationID
                    SetValueIfNull(e.Row, "idfResultEnteredByPerson", EidssUserContext.User.EmployeeID)
                    e.Row("idfValidatedByOffice") = EidssSiteContext.Instance.OrganizationID
                    e.Row("idfValidatedByPerson") = EidssUserContext.User.EmployeeID
                    e.Row("datReceivedDate") = DBNull.Value
                    e.Row("strContactPerson") = DBNull.Value
                    e.Row("idfPerformedByOffice") = DBNull.Value
                End If
        End Select
        TestGridView.UpdateCurrentRow()
        e.Row.EndEdit()
    End Sub
    Protected Sub TestResultChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        If (e.Row("idfsTestResult") Is DBNull.Value) Then
            e.Row("idfResultEnteredByOffice") = DBNull.Value
            e.Row("idfResultEnteredByPerson") = DBNull.Value
        ElseIf Not btnAdd.Visible Then
            e.Row("idfResultEnteredByOffice") = EidssSiteContext.Instance.OrganizationID
            e.Row("idfResultEnteredByPerson") = EidssUserContext.User.EmployeeID
        End If
    End Sub

    Private Sub SetValueIfNull(row As DataRow, fieldName As String, val As Object)
        If (Utils.IsEmpty(row(fieldName))) Then
            row(fieldName) = val
        End If
    End Sub
    Private Sub DefineTransferPage()
        LookupBinder.BindOrganizationLookup(cbFromInstitution, baseDataSet, Sample_DB.TableTransferFrom + ".idfSendFromOffice", HACode.None)
        If baseDataSet.Tables(Sample_DB.TableTransferFrom).Rows.Count > 0 Then
            Dim row As DataRow = baseDataSet.Tables(Sample_DB.TableTransferFrom).Rows(0)
            txtFromID.EditValue = row("strBarcode")
            txtFromSampleID.EditValue = row("MaterialBarcode")
            datFromDate.EditValue = baseDataSet.Tables(Sample_DB.TableSample).Rows(0)("datAccession")
        End If

        LookupBinder.BindOrganizationLookup(cbToInstitution, baseDataSet, Sample_DB.TableTransferTo + ".idfSendToOffice", HACode.None)
        If baseDataSet.Tables(Sample_DB.TableTransferTo).Rows.Count > 0 Then
            Dim row As DataRow = baseDataSet.Tables(Sample_DB.TableTransferTo).Rows(0)
            txtToID.EditValue = row("strBarcode")
            txtToSampleID.EditValue = row("MaterialBarcode")
            datToDate.EditValue = row("datSendDate")
        End If
        If baseDataSet.Tables(Sample_DB.TableTransferFrom).Rows.Count + baseDataSet.Tables(Sample_DB.TableTransferTo).Rows.Count = 0 Then
            TabControl1.TabPages.Remove(tpTransfer)
        End If
    End Sub

    Protected Sub DefineTestsPage()
        LookupBinder.BindBaseRepositoryLookup(cbTestType, db.BaseReferenceType.rftTestName)
        LookupBinder.BindBaseRepositoryLookup(cbCategory, db.BaseReferenceType.rftTestCategory, False)
        LookupBinder.BindBaseRepositoryLookup(cbStatus, db.BaseReferenceType.rftTestStatus, False)
        CType(cbStatus.DataSource, LookupCacheDataView).DefaultFilter = String.Format("idfsReference in ({0}, {1}, {2}, {3})", CLng(TestStatus.Finalized), CLng(TestStatus.InProcess), CLng(TestStatus.NotStarted), CLng(TestStatus.Preliminary))
        LookupBinder.BindTestResultRepositoryLookup(cbTestResult)
        LookupBinder.BindPersonRepositoryLookup(cbTestedBy)
        CType(cbTestedBy.DataSource, LookupCacheDataView).DefaultFilter = String.Format("idfOffice = {0}", EidssUserContext.User.OrganizationID)
        LookupBinder.BindPersonRepositoryLookup(cbValidatedBy)
        cbValidatedBy.Buttons.Clear()
        CType(cbValidatedBy.DataSource, LookupCacheDataView).DefaultFilter = String.Format("idfOffice = {0}", EidssUserContext.User.OrganizationID)
        LookupBinder.BindPersonRepositoryLookup(cbResultEnteredBy)
        CType(cbResultEnteredBy.DataSource, LookupCacheDataView).DefaultFilter = String.Format("idfOffice = {0}", EidssUserContext.User.OrganizationID)
        cbResultEnteredBy.Buttons.Clear()
        LookupBinder.BindOrganizationRepositoryLookup(cbResultReceivedFrom, HACode.All)
        TestGrid.DataSource = baseDataSet.Tables(Sample_DB.TableTest)
        LookupBinder.BindDiagnosisHACodeRepositoryLookup(cbDiagnosis, LookupTables.StandardDiagnosis, False, False)
        'LookupBinder.BindBaseGridRepositoryLookup(cbDiagnosis, db.BaseReferenceType.rftDiagnosis, HACode.All)


        'LookupBinder.BindDiagnosisHACodeRepositoryLookup(cbCaseCurrentDiagnosis, LookupTables.StandardDiagnosis, False, False)
        LookupBinder.BindBaseGridRepositoryLookup(cbCaseCurrentDiagnosis, db.BaseReferenceType.rftDiagnosis, HACode.All, "idfsDiagnosis")
        AddHandler cbCaseCurrentDiagnosis.View.CustomDrawCell, AddressOf DrawVetCaseFinalDiagnosis
        cbCaseCurrentDiagnosis.DataSource = New DataView(baseDataSet.Tables(Sample_DB.TableDiagnosis))
        eventManager.AttachDataHandler(Sample_DB.TableTest + ".idfsDiagnosis", AddressOf TestDiagnosisChanged)
        eventManager.AttachDataHandler(Sample_DB.TableTest + ".idfsTestName", AddressOf TestTypeHandler)
        eventManager.AttachDataHandler(Sample_DB.TableTest + ".idfsTestResult", AddressOf TestResultChanged)
        eventManager.AttachDataHandler(Sample_DB.TableTest + ".idfsTestStatus", AddressOf TestStatusChanged)
        'eventManager.AttachDataHandler(Sample_DB.TableTest + ".datConcludedDate", AddressOf ConcludedDateChanged)

    End Sub


    Private Sub TestDiagnosisChanged(sender As Object, e As DataFieldChangeEventArgs)
        Dim row As DataRow = baseDataSet.Tables(Sample_DB.TableDiagnosis).Rows.Find(e.Value)
        If (Not row Is Nothing) Then
            e.Row("blnFinalDiagnosis") = row("blnFinalDiagnosis")
        End If
    End Sub

    'Private Sub ConcludedDateChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
    '    e.Row("datStartedDate") = e.Row("datConcludedDate")
    'End Sub

    ReadOnly Property AccessoryCode As HACode
        Get
            If (baseDataSet Is Nothing OrElse baseDataSet.Tables.Count = 0 OrElse baseDataSet.Tables(Sample_DB.TableSample).Rows.Count = 0) Then
                Return HACode.All
            End If
            Return CType(baseDataSet.Tables(Sample_DB.TableSample).Rows(0)("intHaCode"), HACode)
        End Get
    End Property

    Protected Overrides Sub DefineBinding()
        Try

            Dim sampleStatusId As Object = baseDataSet.Tables(Sample_DB.TableSample).Rows(0)("idfsSampleStatus")
            Dim sampleEnabled As Boolean = CLng(SampleStatus.Accessioned).Equals(sampleStatusId)
            btnSelectTest.Enabled = m_CanAddTest AndAlso sampleEnabled

            LookupBinder.BindDepartmentLookup(cbDepartment, baseDataSet, Sample_DB.TableSample + ".idfInDepartment", True, String.Format("idfInstitution = {0}", EidssSiteContext.Instance.OrganizationID))
            'Dim departmentView As DataView = CType(cbDepartment.Properties.DataSource, DataView)
            'If (sampleEnabled) Then
            '    departmentView.RowFilter = String.Format("idfInstitution = {0}", EidssSiteContext.Instance.OrganizationID)
            'Else
            'departmentView.RowFilter = String.Format("idfInstitution = {0} or idfDepartment=-1", EidssSiteContext.Instance.OrganizationID)
            'End If


            txtSpecimenType.DataBindings.Add("EditValue", baseDataSet, Sample_DB.TableSample + ".strSampleName")

            LookupBinder.BindTextEdit(txtSampleID, baseDataSet, Sample_DB.TableSample + ".strBarcode")
            txtParentID.DataBindings.Add("EditValue", baseDataSet, Sample_DB.TableSample + ".strParentBarcode")
            Dim id As Object = baseDataSet.Tables(Sample_DB.TableSample).Rows(0)("idfParentMaterial")
            If Utils.IsEmpty(id) Then txtParentID.Properties.Buttons.Clear()

            LookupBinder.BindOrganizationLookup(cbCollectedByOrganization, baseDataSet, Sample_DB.TableSample + ".idfFieldCollectedByOffice", HACode.None)
            LookupBinder.BindPersonLookup(cbCollectedByPerson, baseDataSet, Sample_DB.TableSample + ".idfFieldCollectedByPerson", HACode.All)
            LookupBinder.BindTextEdit(txtAccessionInComment, baseDataSet, Sample_DB.TableSample + ".strCondition")
            LookupBinder.BindTextEdit(txtNote, baseDataSet, Sample_DB.TableSample + ".strNote")
            txtCaseID.EditValue = CreateCaseDescription()
            If (Utils.IsEmpty(txtCaseID.EditValue)) Then
                txtCaseID.Properties.Buttons.Clear()
            End If
            txtSessionID.EditValue = CreateMonitoringSessionDescription()
            If Utils.IsEmpty(txtSessionID.EditValue) Then
                txtSessionID.Properties.Buttons.Clear()
            End If
            txtPartyInfo.EditValue = LabUtils.GetPatientInfo(baseDataSet.Tables(Sample_DB.TableSample).Rows(0)) 'CreatePatientDescription()

            txtCaseType.DataBindings.Add("EditValue", baseDataSet, Sample_DB.TableSample + ".CaseType")
            LabUtils.BindFreezerLocation(cbLocation, baseDataSet, Sample_DB.TableSample + ".idfSubdivision")

            LookupBinder.BindBaseLookup(cbDestructionMethod, baseDataSet, Sample_DB.TableSample + ".idfsDestructionMethod", db.BaseReferenceType.rftDestructionMethod, False)
            SetDestructionMethodVisiblity(baseDataSet.Tables(Sample_DB.TableSample).Rows(0)("idfsSampleStatus"))
            'bind tests
            DefineTestsPage()
            DefineTransferPage()

            Dim transferred As Boolean = False
            If baseDataSet.Tables(Sample_DB.TableTransferTo).Rows.Count = 1 Then
                transferred = Utils.IsEmpty(baseDataSet.Tables(Sample_DB.TableTransferTo).Rows(0)("idfsSite"))
            End If
            btnAdd.Visible = transferred
            btnSelectTest.Visible = Not transferred
            If (transferred) Then
                colDateReceived.OptionsColumn.AllowEdit = True
                colDateReceived.OptionsColumn.ReadOnly = False
                colContactPerson.OptionsColumn.AllowEdit = True
                colContactPerson.OptionsColumn.ReadOnly = False
                btnAdd.Width = btnAdd.CalcBestSize().Width
                btnAdd.Left = btnDeleteTest.Left - btnAdd.Width - 8
            End If

            If Not sampleEnabled Then
                SetControlReadOnly(cbLocation, True, False)
                SetControlReadOnly(cbDepartment, True, False)
            End If
            UpdateTestButtons()
        Catch e As Exception
            ErrorForm.ShowError(StandardError.FillDatasetError, e)
        End Try

    End Sub

    Private Sub DrawVetCaseFinalDiagnosis(sender As Object, e As RowCellCustomDrawEventArgs)
        Dim row As DataRow = CType(sender, GridView).GetDataRow(e.RowHandle)
        If True.Equals(row("blnFinalDiagnosis")) Then
            e.Appearance.Font = WinClientContext.CurrentBoldFont
        End If
    End Sub

    Private Sub SetDestructionMethodVisiblity(sampleStatusId As Object)
        Dim show As Boolean = CLng(SampleStatus.RoutineDestruction).Equals(sampleStatusId) OrElse CLng(SampleStatus.Destroyed).Equals(sampleStatusId)
        cbDestructionMethod.Visible = show
        lbDestructionMethod.Visible = show
    End Sub
    Function CreateMonitoringSessionDescription() As String
        Dim row As DataRow = baseDataSet.Tables(0).Rows(0)
        Dim ret As String = Utils.Str(row("SessionDiagnosisName"))
        If ret.Length > 0 Then ret = ", " + ret
        ret = Utils.Str(row("strMonitoringSessionID")) + ret
        Return ret
    End Function

    Function CreateCaseDescription() As String
        Dim row As DataRow = baseDataSet.Tables(0).Rows(0)
        Dim ret As String = Utils.Str(row("DiagnosisName"))
        If ret.Length > 0 Then ret = ", " + ret
        ret = Utils.Str(row("strCaseID")) + ret
        Return ret
    End Function

    Sub AppendLine(ByRef s As String, ByVal val As Object)
        If val Is DBNull.Value OrElse val.ToString().Trim.Length = 0 Then Return
        If s.Length = 0 Then
            s += val.ToString()
        Else
            s += ", " + val.ToString()
        End If
    End Sub


    Private Sub txtCaseID_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtCaseID.ButtonClick, txtSessionID.ButtonClick
        If (LockHandler()) Then
            Try

                If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then
                    LabUtils.ShowCase(FindForm, baseDataSet.Tables(Sample_DB.TableSample).Rows(0), sender Is txtSessionID)
                End If

            Finally
                UnlockHandler()
            End Try
        End If
    End Sub


    Private Sub MenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MenuItem1.Click
        If baseDataSet Is Nothing OrElse baseDataSet.Tables.Count = 0 Then
            Return
        End If
        If Post(PostType.FinalPosting) Then
            EidssSiteContext.ReportFactory.LimSample(CType(SampleDbService.ID, Long))
        End If
    End Sub


    Private Sub txtParentID_ButtonPressed(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtParentID.ButtonPressed
        Dim id As Object = baseDataSet.Tables(Sample_DB.TableSample).Rows(0)("idfParentMaterial")
        If Utils.IsEmpty(id) Then Exit Sub

        BaseFormManager.ShowNormal_ReadOnly(New SampleDetail, id)
    End Sub

    Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Dim row As DataRow = CreateNewTest()
        If row Is Nothing Then
            Return
        End If
        row("idfsTestStatus") = TestStatus.Finalized
        row("datStartedDate") = DateTime.Today
        row("datConcludedDate") = DateTime.Today
        row("blnExternalTest") = True
        row("idfResultEnteredByOffice") = DBNull.Value
        row("idfResultEnteredByPerson") = DBNull.Value
        row("idfValidatedByOffice") = DBNull.Value
        row("idfValidatedByPerson") = DBNull.Value
        row("idfTestedByOffice") = DBNull.Value
        row("idfTestedByPerson") = DBNull.Value
        row("datReceivedDate") = DateTime.Today
        row("idfPerformedByOffice") = baseDataSet.Tables(Sample_DB.TableTransferTo).Rows(0)("idfSendToOffice")
        row.EndEdit()
    End Sub

    Public Overrides Function ValidateData() As Boolean
        For index As Integer = 0 To TestGridView.RowCount - 1
            Dim rowHandle As Integer = TestGridView.GetRowHandle(index)
            If Not Utils.IsEmpty(GetTestRowValidationErrorField(rowHandle, True)) Then
                TestGridView.FocusedRowHandle = rowHandle
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub TestGridView_CellValueChanged(sender As Object, e As Views.Base.CellValueChangedEventArgs) Handles TestGridView.CellValueChanged
        If e.Column Is colDateTested Then
            TestGridView.PostEditor()
            Dim row As DataRow = TestGridView.GetFocusedDataRow()
            If (Not row Is Nothing AndAlso row.RowState = DataRowState.Unchanged) Then
                row.SetModified()
            End If
            GetTestRowValidationErrorField(-1, True)
        End If
    End Sub

    Private Sub TestGridView_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles TestGridView.FocusedRowChanged
        If e.PrevFocusedRowHandle <> GridControl.InvalidRowHandle AndAlso Not Utils.IsEmpty(GetTestRowValidationErrorField(e.PrevFocusedRowHandle)) Then
            TestGridView.FocusedRowHandle = e.PrevFocusedRowHandle
        End If
        UpdateTestButtons()
    End Sub

    Private Sub UpdateTestButtons()
        Dim row As DataRow = TestGridView.GetFocusedDataRow
        If Not row Is Nothing Then
            btnDeleteTest.Enabled = m_CanDeleteTest AndAlso row("idfBatchTest") Is DBNull.Value AndAlso ( _
                row("idfsTestStatus") Is DBNull.Value _
                OrElse CLng(row("idfsTestStatus")) = CLng(TestStatus.NotStarted) _
                OrElse CLng(row("idfsTestStatus")) = CLng(TestStatus.InProcess))
        Else
            btnDeleteTest.Enabled = False
        End If

    End Sub

    Private Function IsTestRowEditable(row As DataRow) As Boolean
        If row Is Nothing Then
            Return False
        End If
        If (row("idfsTestStatus") Is DBNull.Value) Then
            Return True
        End If
        Dim tstStatus As Long = CLng(row("idfsTestStatus"))
        If ((tstStatus = CLng(TestStatus.Finalized) AndAlso Not (row.RowState = DataRowState.Added OrElse row.RowState = DataRowState.Modified)) OrElse tstStatus = CLng(TestStatus.Amended)) Then
            Return False
        End If
        If tstStatus = CLng(TestStatus.InProcess) Then
            Return row("idfBatchTest") Is DBNull.Value
        End If
        If (TestGridView.FocusedColumn Is colResult) OrElse (TestGridView.FocusedColumn Is colDateTested) Then
            Return ((tstStatus = CLng(TestStatus.Finalized) AndAlso (row.RowState = DataRowState.Added OrElse row.RowState = DataRowState.Modified)) OrElse tstStatus = CLng(TestStatus.InProcess))
        End If
        Return True
    End Function
    Private Sub TestGridView_ShowingEditor(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TestGridView.ShowingEditor
        If TestGridView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then Exit Sub
        Dim row As DataRow = TestGridView.GetFocusedDataRow()
        If (row Is Nothing OrElse Not Utils.IsEmpty(row("idfBatchTest"))) Then
            e.Cancel = True
            Return
        End If

        Dim isNewRow As Boolean = (row.RowState = DataRowState.Added) OrElse (row.HasVersion(DataRowVersion.Original) AndAlso Not row("idfsTestStatus", DataRowVersion.Original).Equals(row("idfsTestStatus")))
        Dim status As TestStatus = TestStatus.NotStarted
        If Not Utils.IsEmpty(row("idfsTestStatus")) Then
            status = CType(row("idfsTestStatus"), TestStatus)
        End If
        Select Case status
            Case TestStatus.NotStarted
                If TestGridView.FocusedColumn Is colTestName _
                    OrElse TestGridView.FocusedColumn Is colDiagnosis Then
                    e.Cancel = Not isNewRow
                ElseIf Not TestGridView.FocusedColumn Is colStatus AndAlso Not TestGridView.FocusedColumn Is colCategory Then
                    e.Cancel = True
                End If
            Case TestStatus.InProcess
                e.Cancel = Not (TestGridView.FocusedColumn Is colStatus _
                    OrElse TestGridView.FocusedColumn Is colDiagnosis _
                    OrElse TestGridView.FocusedColumn Is colResult _
                    OrElse TestGridView.FocusedColumn Is colDateTested _
                    OrElse TestGridView.FocusedColumn Is colDateTestStarted _
                    OrElse TestGridView.FocusedColumn Is colTestedBy _
                    OrElse TestGridView.FocusedColumn Is colCategory _
                    OrElse TestGridView.FocusedColumn Is colComments)
            Case TestStatus.Preliminary
                e.Cancel = Not (TestGridView.FocusedColumn Is colStatus _
                    OrElse TestGridView.FocusedColumn Is colResult _
                    OrElse TestGridView.FocusedColumn Is colDiagnosis _
                    OrElse TestGridView.FocusedColumn Is colDateTested _
                    OrElse TestGridView.FocusedColumn Is colDateTestStarted _
                    OrElse TestGridView.FocusedColumn Is colTestedBy _
                    OrElse TestGridView.FocusedColumn Is colCategory _
                    OrElse TestGridView.FocusedColumn Is colComments)
            Case TestStatus.Finalized
                If True.Equals(row("blnExternalTest")) Then
                    e.Cancel = Not isNewRow OrElse (TestGridView.FocusedColumn Is colStatus _
                        OrElse TestGridView.FocusedColumn Is colValidatedBy _
                        OrElse TestGridView.FocusedColumn Is colBatch _
                        OrElse TestGridView.FocusedColumn Is colResultEnteredBy)
                    'OrElse TestGridView.FocusedColumn Is colCategory _
                Else
                    e.Cancel = Not (TestGridView.FocusedColumn Is colComments)
                    If isNewRow AndAlso e.Cancel = True Then
                        e.Cancel = Not (TestGridView.FocusedColumn Is colStatus _
                            OrElse TestGridView.FocusedColumn Is colDiagnosis _
                            OrElse TestGridView.FocusedColumn Is colResult _
                            OrElse TestGridView.FocusedColumn Is colDateTested _
                            OrElse TestGridView.FocusedColumn Is colCategory _
                            OrElse TestGridView.FocusedColumn Is colTestedBy)
                    End If
                End If
                If e.Cancel = True AndAlso GetTestRowValidationErrorField(TestGridView.FocusedRowHandle, False) = TestGridView.FocusedColumn.FieldName Then
                    e.Cancel = False
                End If

        End Select
        Return
    End Sub


    Private Sub TestGridView_CustomRowCellEditForEditing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles TestGridView.CustomRowCellEditForEditing
        If (e.Column Is colDiagnosis) Then
            e.RepositoryItem = cbCaseCurrentDiagnosis
        End If
    End Sub

    Private Function CreateNewTest() As DataRow
        If Not Utils.IsEmpty(GetTestRowValidationErrorField()) Then Return Nothing
        Dim sampleRow As DataRow = baseDataSet.Tables(Sample_DB.TableSample).Rows(0)

        Dim table As DataTable = baseDataSet.Tables(Sample_DB.TableTest)
        Dim row As DataRow = table.NewRow()
        row("idfTesting") = BaseDbService.NewIntID()
        row("idfsTestStatus") = TestStatus.NotStarted
        row("idfObservation") = BaseDbService.NewIntID
        row("idfMaterial") = GetKey()
        row("blnNonLaboratoryTest") = 0
        If Not sampleRow("idfCase") Is DBNull.Value Then
            row("idfsDiagnosis") = sampleRow("idfsShowDiagnosis")
        ElseIf Not sampleRow("idfMonitoringSession") Is DBNull.Value AndAlso _
            baseDataSet.Tables(Sample_DB.TableDiagnosis).Rows.Count > 0 Then
            row("idfsDiagnosis") = baseDataSet.Tables(Sample_DB.TableDiagnosis).Rows(0)("idfsDiagnosis")
        End If
        row("idfTestedByOffice") = EidssSiteContext.Instance.OrganizationID
        table.Rows.Add(row)
        DxControlsHelper.SetRowHandleForDataRow(TestGridView, row, "idfTesting")
        TestGridView.FocusedColumn = colTestName
        Return row
    End Function

    Private Sub btnSelectTest_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnSelectTest.Click
        CreateNewTest()
    End Sub
    Private Class FieldCaptionPair
        Property FieldName As String
        Property FieldCaption As String
        Public Sub New(ByVal aFieldName As String, ByVal aFieldCaption As String)
            FieldName = aFieldName
            FieldCaption = aFieldCaption
        End Sub
    End Class
    Private ReadOnly m_TestMandatoryFields As New List(Of FieldCaptionPair)
    Private Sub InitManadatoryFields()
        If (m_TestMandatoryFields.Count = 0) Then
            m_TestMandatoryFields.AddRange({
                                            New FieldCaptionPair("idfsTestName", colTestName.Caption), _
                                            New FieldCaptionPair("idfsDiagnosis", colDiagnosis.Caption), _
                                            New FieldCaptionPair("idfsTestStatus", colStatus.Caption), _
                                            New FieldCaptionPair("datStartedDate", colDateTestStarted.Caption), _
                                            New FieldCaptionPair("datConcludedDate", colDateTested.Caption), _
                                            New FieldCaptionPair("datReceivedDate", colDateReceived.Caption), _
                                            New FieldCaptionPair("idfTestedByPerson", colTestedBy.Caption), _
                                            New FieldCaptionPair("strContactPerson", colContactPerson.Caption), _
                                            New FieldCaptionPair("idfPerformedByOffice", colResultReceivedFrom.Caption), _
                                            New FieldCaptionPair("idfsTestResult", colResult.Caption) _
                                            })
            'New FieldCaptionPair("idfsTestCategory", colCategory.Caption), _
        End If
    End Sub
    Private Function ShouldValidateField(ByVal fieldName As String, ByVal row As DataRow) As Boolean
        If Utils.IsEmpty(row("idfsTestStatus")) OrElse row("idfsTestStatus").Equals(CLng(TestStatus.NotStarted)) OrElse row("idfsTestStatus").Equals(CLng(TestStatus.InProcess)) Then
            Return fieldName = "idfsTestName" OrElse fieldName = "idfsDiagnosis"
        ElseIf row("idfsTestStatus").Equals(CLng(TestStatus.Preliminary)) Then
            Return fieldName = "idfsTestName" OrElse fieldName = "idfsDiagnosis" OrElse fieldName = "idfsTestResult" OrElse fieldName = "datStartedDate" OrElse fieldName = "datConcludedDate"
        ElseIf row("idfsTestStatus").Equals(CLng(TestStatus.Finalized)) Then
            If (btnAdd.Visible) Then
                Return fieldName = "idfsTestName" OrElse fieldName = "idfsDiagnosis" OrElse fieldName = "idfsTestResult" OrElse fieldName = "datStartedDate" OrElse fieldName = "datConcludedDate" OrElse fieldName = "datReceivedDate" OrElse fieldName = "strContactPerson" OrElse fieldName = "idfPerformedByOffice"
            Else
                Return fieldName = "idfsTestName" OrElse fieldName = "idfsDiagnosis" OrElse fieldName = "idfsTestResult" OrElse fieldName = "datStartedDate" OrElse fieldName = "datConcludedDate" OrElse fieldName = "idfTestedByPerson"
            End If
        End If
        If fieldName = "idfsTestResult" OrElse fieldName = "datConcludedDate" Then
            Return row("idfsTestStatus").Equals(CLng(TestStatus.Finalized)) OrElse row("idfsTestStatus").Equals(CLng(TestStatus.Preliminary))
        End If
        If fieldName = "datReceivedDate" Then
            Return True.Equals(row("blnExternalTest"))
        End If
        Return True
    End Function
    Private Function GetTestRowValidationErrorField(Optional ByVal index As Integer = -1, Optional ByVal showError As Boolean = True) _
        As String

        Dim row As DataRow
        If (index >= 0) Then
            row = TestGridView.GetDataRow(index)
        Else
            row = TestGridView.GetFocusedDataRow
        End If
        'If Not IsTestRowEditable(row) Then
        '    Return True
        'End If
        If row Is Nothing Then Return String.Empty
        InitManadatoryFields()
        For Each f As FieldCaptionPair In m_TestMandatoryFields
            If Not ShouldValidateField(f.FieldName, row) Then
                Continue For
            End If
            If Utils.IsEmpty(row(f.FieldName)) Then
                If showError Then
                    WinUtils.ShowMandatoryError(f.FieldCaption)
                    TestGridView.FocusedColumn = TestGridView.Columns(f.FieldName)
                End If
                Return f.FieldName
            End If

        Next
        If Not m_ConcludeDateValidator.Validate(row, showError) Then
            If (Not m_ConcludeDateValidator.ErrorItem1 Is Nothing) AndAlso (Not TestGridView.Columns.ColumnByFieldName(m_ConcludeDateValidator.ErrorItem1.FieldName) Is Nothing) Then
                Return m_ConcludeDateValidator.ErrorItem1.FieldName
            End If
            If (Not m_ConcludeDateValidator.ErrorItem2 Is Nothing) AndAlso (Not TestGridView.Columns.ColumnByFieldName(m_ConcludeDateValidator.ErrorItem2.FieldName) Is Nothing) Then
                Return m_ConcludeDateValidator.ErrorItem2.FieldName
            End If
            Return "1" 'any nonempty string
        End If
        Return String.Empty
    End Function


    Private Sub btnDeleteTest_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDeleteTest.Click
        Dim row As DataRow = TestGridView.GetFocusedDataRow
        If row Is Nothing Then Return
        If (Not DbService.CanDelete(row("idfTesting"), "LabTest")) Then
            ErrorForm.ShowMessage("msgCantDeleteRecord", "The record can't be deleted")
            Return
        End If
        If WinUtils.ConfirmMessage(EidssMessages.Get("msgDeleteTest", "Test will be deleted. Delete Test?"), BvMessages.Get("titleDeleteTest", "Delete Test")) Then
            row.Delete()
        End If
    End Sub

    Private Sub cbStatus_QueryCloseUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbStatus.QueryCloseUp
        CType(cbStatus.DataSource, DataView).RowFilter = Nothing
    End Sub

    Private Sub cbStatus_QueryPopUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbStatus.QueryPopUp
        CType(cbStatus.DataSource, DataView).RowFilter = String.Format("idfsReference in ({0}, {1}, {2})", CLng(TestStatus.Finalized), CLng(TestStatus.InProcess), CLng(TestStatus.NotStarted))
    End Sub
    Private m_ConcludeDateValidator As DateChainValidator

    Protected Overrides Sub RegisterValidators()
        Dim rootDate As New DateChainValidator(Me, Nothing, Sample_DB.TableSample, "datFieldCollectionDate", EidssFields.Get("datFieldCollectionDate"), , , , False)
        Dim item As ChainValidator(Of DateTime) = rootDate.AddChild(New DateChainValidator(Me, Nothing, Sample_DB.TableSample, "datAccession", EidssFields.Get("datAccession"), , , , False))
        m_ConcludeDateValidator = New DateChainValidator(Me, TestGrid, Sample_DB.TableTest, "datStartedDate", colDateTestStarted.Caption, , , , True, , AddressOf UpdateTestButtons)
        item.AddChild(m_ConcludeDateValidator)
        item = New DateChainValidator(Me, TestGrid, Sample_DB.TableTest, "datConcludedDate", colDateTested.Caption, , , , True, , AddressOf UpdateTestButtons)
        m_ConcludeDateValidator.AddChild(item)
        item.AddChild(New DateChainValidator(Me, TestGrid, Sample_DB.TableTest, "datReceivedDate", colDateReceived.Caption, , , , True, , AddressOf UpdateTestButtons))
        rootDate.RegisterValidator(Me)
    End Sub

    Private Sub cbTestStatus_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cbStatus.EditValueChanging
        If Not m_CanFinalizeTest AndAlso CLng(TestStatus.Finalized).Equals(e.NewValue) Then
            ErrorForm.ShowWarning("msgNoExecutePermission")
            e.Cancel = True
        End If
    End Sub
    Public Overrides Sub ShowHelp()
        If (TabControl1.SelectedTabPage Is tpGeneral) Then
            ShowHelp("general_tab_of_sample")
        ElseIf (TabControl1.SelectedTabPage Is tpTests) Then
            ShowHelp("test_tab_of_sample")
        ElseIf (TabControl1.SelectedTabPage Is tpTransfer) Then
            ShowHelp("general_tab_of_sample")
        End If
    End Sub
    Public Overrides Sub UpdateButtonsState(ByVal sender As Object, ByVal e As EventArgs)
        ShowLocationButtons(Not [ReadOnly] AndAlso Not baseDataSet Is Nothing _
                            AndAlso Not baseDataSet.Tables(Sample_DB.TableSample) Is Nothing _
                            AndAlso baseDataSet.Tables(Sample_DB.TableSample).Rows.Count > 0 _
                            AndAlso Not Utils.IsEmpty(baseDataSet.Tables(Sample_DB.TableSample).Rows(0)("idfSubdivision")))

    End Sub

    Private Sub ShowLocationButtons(ByVal aVisible As Boolean)
        DxControlsHelper.SetButtonEditButtonVisibility(cbLocation, ButtonPredefines.Delete, aVisible)
    End Sub


    Private Sub TestGridView_CustomDrawCell(sender As Object, e As Views.Base.RowCellCustomDrawEventArgs) Handles TestGridView.CustomDrawCell
        If (e.Column.FieldName = "idfsDiagnosis") Then
            Dim row As DataRow = TestGridView.GetDataRow(e.RowHandle)
            If True.Equals(row("blnFinalDiagnosis")) Then
                e.Appearance.Font = WinClientContext.CurrentBoldFont
            End If
        End If
    End Sub
    Protected Overrides Sub SaveGridLayouts()
        TestGridView.SaveGridLayout("LabSample_Tests")
    End Sub
    Protected Overrides Sub LoadGridLayouts()
        'Test Name, Test Diagnosis, Test Status, Result, Date test Started, Result Date, Tested By, Results Entered By, Results Received From, Date Results Received, Contact Person
        TestGridView.InitXtraGridCustomization(New String() {"idfsTestName", "idfsDiagnosis", "idfsTestStatus", "idfsTestResult", "datStartedDate", "datConcludedDate", "idfTestedByPerson", "idfResultEnteredByPerson", "idfPerformedByOffice", "datReceivedDate", "strContactPerson"})
        TestGridView.LoadGridLayout("LabSample_Tests")
    End Sub
End Class
