Imports bv.winclient.BasePanel
Imports System.Collections.Generic
Imports eidss.model.Core
Imports EIDSS.model.Resources
Imports bv.common.Resources
Imports bv.winclient.Localization

Public Class SampleDetail

    Inherits BaseDetailForm

    Dim SampleDbService As Sample_DB
    Dim cbTestResultEditor As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Dim cbCaseCurrentDiagnosis As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit

    'Dim HACaseCode As HACode
    'Dim Type As Long
    'Dim CaseID As Object
    Dim EnableCaseEditing As Boolean = True
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
    Dim EnablePartyEditing As Boolean = True
    Private m_CanDeleteTest As Boolean
    Friend WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
    Private m_CanAddTest As Boolean
#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()


        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        SampleDbService = New Sample_DB

        DbService = SampleDbService
        AuditObject = New AuditObject(EIDSSAuditObject.daoSample, AuditTable.tlbMaterial)
        Me.PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.Sample

        Me.m_RelatedLists = New String() {"LabSampleListItem", "LabSampleLogBookListItem"}
        m_CanAddTest = Not [ReadOnly] AndAlso EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission(EIDSS.model.Enums.EIDSSPermissionObject.Test))
        m_CanDeleteTest = Not [ReadOnly] AndAlso EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.DeletePermission(EIDSS.model.Enums.EIDSSPermissionObject.Test))
        btnSelectTest.Enabled = m_CanAddTest
        '-------
        'Dim dblCS As New FlexibleForm_DB(FFMaterialInfo)
        'Me.RegisterChildObject(FFMaterialInfo, RelatedPostOrder.PostLast)
        'Me.TabControl1.TabPages.Remove(Me.tpContainers)
        'Me.TabControl1.TabPages.Remove(Me.tpTests)

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
    Friend WithEvents ContextMenu2 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents PopUpButton1 As bv.common.win.PopUpButton

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SampleDetail))
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.ContextMenu2 = New System.Windows.Forms.ContextMenu()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.MenuItem5 = New System.Windows.Forms.MenuItem()
        Me.MenuItem6 = New System.Windows.Forms.MenuItem()
        Me.MenuItem7 = New System.Windows.Forms.MenuItem()
        Me.MenuItem8 = New System.Windows.Forms.MenuItem()
        Me.MenuItem9 = New System.Windows.Forms.MenuItem()
        Me.PopUpButton1 = New bv.common.win.PopUpButton()
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
        Me.colDateTested = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbStatus = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colResult = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbTestResult = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colDateReceived = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colContactPerson = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.tpGeneral = New DevExpress.XtraTab.XtraTabPage()
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
        CType(Me.datToDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datToDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtToSampleID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtToID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbToInstitution.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.txtFromSampleID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFromID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datFromDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datFromDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbFromInstitution.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpTests.SuspendLayout()
        CType(Me.TestGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TestGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTestType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDiagnosis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTestResult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpGeneral.SuspendLayout()
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
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        resources.ApplyResources(Me.ContextMenu1, "ContextMenu1")
        '
        'MenuItem1
        '
        resources.ApplyResources(Me.MenuItem1, "MenuItem1")
        Me.MenuItem1.Index = 0
        '
        'ContextMenu2
        '
        Me.ContextMenu2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2, Me.MenuItem3, Me.MenuItem4, Me.MenuItem5, Me.MenuItem6, Me.MenuItem7, Me.MenuItem8, Me.MenuItem9})
        resources.ApplyResources(Me.ContextMenu2, "ContextMenu2")
        '
        'MenuItem2
        '
        resources.ApplyResources(Me.MenuItem2, "MenuItem2")
        Me.MenuItem2.Index = 0
        '
        'MenuItem3
        '
        resources.ApplyResources(Me.MenuItem3, "MenuItem3")
        Me.MenuItem3.Index = 1
        '
        'MenuItem4
        '
        resources.ApplyResources(Me.MenuItem4, "MenuItem4")
        Me.MenuItem4.Index = 2
        '
        'MenuItem5
        '
        resources.ApplyResources(Me.MenuItem5, "MenuItem5")
        Me.MenuItem5.Index = 3
        '
        'MenuItem6
        '
        resources.ApplyResources(Me.MenuItem6, "MenuItem6")
        Me.MenuItem6.Index = 4
        '
        'MenuItem7
        '
        resources.ApplyResources(Me.MenuItem7, "MenuItem7")
        Me.MenuItem7.Index = 5
        '
        'MenuItem8
        '
        resources.ApplyResources(Me.MenuItem8, "MenuItem8")
        Me.MenuItem8.Index = 6
        '
        'MenuItem9
        '
        resources.ApplyResources(Me.MenuItem9, "MenuItem9")
        Me.MenuItem9.Index = 7
        '
        'PopUpButton1
        '
        resources.ApplyResources(Me.PopUpButton1, "PopUpButton1")
        Me.PopUpButton1.ButtonType = bv.common.win.PopUpButton.PopUpButtonStyles.Reports
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
        Me.LookUpEdit1.Properties.AccessibleDescription = resources.GetString("LookUpEdit1.Properties.AccessibleDescription")
        Me.LookUpEdit1.Properties.AccessibleName = resources.GetString("LookUpEdit1.Properties.AccessibleName")
        Me.LookUpEdit1.Properties.AutoHeight = CType(resources.GetObject("LookUpEdit1.Properties.AutoHeight"), Boolean)
        Me.LookUpEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("LookUpEdit1.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.LookUpEdit1.Properties.NullText = resources.GetString("LookUpEdit1.Properties.NullText")
        Me.LookUpEdit1.Properties.NullValuePrompt = resources.GetString("LookUpEdit1.Properties.NullValuePrompt")
        Me.LookUpEdit1.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("LookUpEdit1.Properties.NullValuePromptShowForEmptyValue"), Boolean)
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
        Me.LookUpEdit2.Properties.AccessibleDescription = resources.GetString("LookUpEdit2.Properties.AccessibleDescription")
        Me.LookUpEdit2.Properties.AccessibleName = resources.GetString("LookUpEdit2.Properties.AccessibleName")
        Me.LookUpEdit2.Properties.AutoHeight = CType(resources.GetObject("LookUpEdit2.Properties.AutoHeight"), Boolean)
        Me.LookUpEdit2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("LookUpEdit2.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.LookUpEdit2.Properties.NullText = resources.GetString("LookUpEdit2.Properties.NullText")
        Me.LookUpEdit2.Properties.NullValuePrompt = resources.GetString("LookUpEdit2.Properties.NullValuePrompt")
        Me.LookUpEdit2.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("LookUpEdit2.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.LookUpEdit2.Tag = "{R}"
        '
        'txtSampleID
        '
        resources.ApplyResources(Me.txtSampleID, "txtSampleID")
        Me.txtSampleID.Name = "txtSampleID"
        Me.txtSampleID.Properties.AccessibleDescription = resources.GetString("txtSampleID.Properties.AccessibleDescription")
        Me.txtSampleID.Properties.AccessibleName = resources.GetString("txtSampleID.Properties.AccessibleName")
        Me.txtSampleID.Properties.AutoHeight = CType(resources.GetObject("txtSampleID.Properties.AutoHeight"), Boolean)
        Me.txtSampleID.Properties.Mask.AutoComplete = CType(resources.GetObject("txtSampleID.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtSampleID.Properties.Mask.BeepOnError = CType(resources.GetObject("txtSampleID.Properties.Mask.BeepOnError"), Boolean)
        Me.txtSampleID.Properties.Mask.EditMask = resources.GetString("txtSampleID.Properties.Mask.EditMask")
        Me.txtSampleID.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtSampleID.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtSampleID.Properties.Mask.MaskType = CType(resources.GetObject("txtSampleID.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtSampleID.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtSampleID.Properties.Mask.PlaceHolder"), Char)
        Me.txtSampleID.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtSampleID.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtSampleID.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtSampleID.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtSampleID.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtSampleID.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtSampleID.Properties.NullValuePrompt = resources.GetString("txtSampleID.Properties.NullValuePrompt")
        Me.txtSampleID.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtSampleID.Properties.NullValuePromptShowForEmptyValue"), Boolean)
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
        Me.txtSpecimenType.Properties.AccessibleDescription = resources.GetString("txtSpecimenType.Properties.AccessibleDescription")
        Me.txtSpecimenType.Properties.AccessibleName = resources.GetString("txtSpecimenType.Properties.AccessibleName")
        Me.txtSpecimenType.Properties.AutoHeight = CType(resources.GetObject("txtSpecimenType.Properties.AutoHeight"), Boolean)
        Me.txtSpecimenType.Properties.Mask.AutoComplete = CType(resources.GetObject("txtSpecimenType.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtSpecimenType.Properties.Mask.BeepOnError = CType(resources.GetObject("txtSpecimenType.Properties.Mask.BeepOnError"), Boolean)
        Me.txtSpecimenType.Properties.Mask.EditMask = resources.GetString("txtSpecimenType.Properties.Mask.EditMask")
        Me.txtSpecimenType.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtSpecimenType.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtSpecimenType.Properties.Mask.MaskType = CType(resources.GetObject("txtSpecimenType.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtSpecimenType.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtSpecimenType.Properties.Mask.PlaceHolder"), Char)
        Me.txtSpecimenType.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtSpecimenType.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtSpecimenType.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtSpecimenType.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtSpecimenType.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtSpecimenType.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtSpecimenType.Properties.NullValuePrompt = resources.GetString("txtSpecimenType.Properties.NullValuePrompt")
        Me.txtSpecimenType.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtSpecimenType.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.txtSpecimenType.Tag = "{R}"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Name = "Label10"
        '
        'tpTransfer
        '
        resources.ApplyResources(Me.tpTransfer, "tpTransfer")
        Me.tpTransfer.Controls.Add(Me.GroupControl3)
        Me.tpTransfer.Controls.Add(Me.GroupControl2)
        Me.tpTransfer.Name = "tpTransfer"
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
        Me.datToDate.Properties.AccessibleDescription = resources.GetString("datToDate.Properties.AccessibleDescription")
        Me.datToDate.Properties.AccessibleName = resources.GetString("datToDate.Properties.AccessibleName")
        Me.datToDate.Properties.AutoHeight = CType(resources.GetObject("datToDate.Properties.AutoHeight"), Boolean)
        Me.datToDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("datToDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.datToDate.Properties.Mask.AutoComplete = CType(resources.GetObject("datToDate.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.datToDate.Properties.Mask.BeepOnError = CType(resources.GetObject("datToDate.Properties.Mask.BeepOnError"), Boolean)
        Me.datToDate.Properties.Mask.EditMask = resources.GetString("datToDate.Properties.Mask.EditMask")
        Me.datToDate.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("datToDate.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.datToDate.Properties.Mask.MaskType = CType(resources.GetObject("datToDate.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.datToDate.Properties.Mask.PlaceHolder = CType(resources.GetObject("datToDate.Properties.Mask.PlaceHolder"), Char)
        Me.datToDate.Properties.Mask.SaveLiteral = CType(resources.GetObject("datToDate.Properties.Mask.SaveLiteral"), Boolean)
        Me.datToDate.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("datToDate.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.datToDate.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("datToDate.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.datToDate.Properties.NullValuePrompt = resources.GetString("datToDate.Properties.NullValuePrompt")
        Me.datToDate.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("datToDate.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.datToDate.Properties.VistaTimeProperties.AccessibleDescription = resources.GetString("datToDate.Properties.VistaTimeProperties.AccessibleDescription")
        Me.datToDate.Properties.VistaTimeProperties.AccessibleName = resources.GetString("datToDate.Properties.VistaTimeProperties.AccessibleName")
        Me.datToDate.Properties.VistaTimeProperties.AutoHeight = CType(resources.GetObject("datToDate.Properties.VistaTimeProperties.AutoHeight"), Boolean)
        Me.datToDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.datToDate.Properties.VistaTimeProperties.Mask.AutoComplete = CType(resources.GetObject("datToDate.Properties.VistaTimeProperties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.datToDate.Properties.VistaTimeProperties.Mask.BeepOnError = CType(resources.GetObject("datToDate.Properties.VistaTimeProperties.Mask.BeepOnError"), Boolean)
        Me.datToDate.Properties.VistaTimeProperties.Mask.EditMask = resources.GetString("datToDate.Properties.VistaTimeProperties.Mask.EditMask")
        Me.datToDate.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("datToDate.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.datToDate.Properties.VistaTimeProperties.Mask.MaskType = CType(resources.GetObject("datToDate.Properties.VistaTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.datToDate.Properties.VistaTimeProperties.Mask.PlaceHolder = CType(resources.GetObject("datToDate.Properties.VistaTimeProperties.Mask.PlaceHolder"), Char)
        Me.datToDate.Properties.VistaTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("datToDate.Properties.VistaTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.datToDate.Properties.VistaTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("datToDate.Properties.VistaTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.datToDate.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("datToDate.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.datToDate.Properties.VistaTimeProperties.NullValuePrompt = resources.GetString("datToDate.Properties.VistaTimeProperties.NullValuePrompt")
        Me.datToDate.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("datToDate.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue"), Boolean)
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
        Me.txtToSampleID.Properties.AccessibleDescription = resources.GetString("txtToSampleID.Properties.AccessibleDescription")
        Me.txtToSampleID.Properties.AccessibleName = resources.GetString("txtToSampleID.Properties.AccessibleName")
        Me.txtToSampleID.Properties.AutoHeight = CType(resources.GetObject("txtToSampleID.Properties.AutoHeight"), Boolean)
        Me.txtToSampleID.Properties.Mask.AutoComplete = CType(resources.GetObject("txtToSampleID.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtToSampleID.Properties.Mask.BeepOnError = CType(resources.GetObject("txtToSampleID.Properties.Mask.BeepOnError"), Boolean)
        Me.txtToSampleID.Properties.Mask.EditMask = resources.GetString("txtToSampleID.Properties.Mask.EditMask")
        Me.txtToSampleID.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtToSampleID.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtToSampleID.Properties.Mask.MaskType = CType(resources.GetObject("txtToSampleID.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtToSampleID.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtToSampleID.Properties.Mask.PlaceHolder"), Char)
        Me.txtToSampleID.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtToSampleID.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtToSampleID.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtToSampleID.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtToSampleID.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtToSampleID.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtToSampleID.Properties.NullValuePrompt = resources.GetString("txtToSampleID.Properties.NullValuePrompt")
        Me.txtToSampleID.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtToSampleID.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.txtToSampleID.Tag = "{R}"
        '
        'txtToID
        '
        resources.ApplyResources(Me.txtToID, "txtToID")
        Me.txtToID.Name = "txtToID"
        Me.txtToID.Properties.AccessibleDescription = resources.GetString("txtToID.Properties.AccessibleDescription")
        Me.txtToID.Properties.AccessibleName = resources.GetString("txtToID.Properties.AccessibleName")
        Me.txtToID.Properties.AutoHeight = CType(resources.GetObject("txtToID.Properties.AutoHeight"), Boolean)
        Me.txtToID.Properties.Mask.AutoComplete = CType(resources.GetObject("txtToID.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtToID.Properties.Mask.BeepOnError = CType(resources.GetObject("txtToID.Properties.Mask.BeepOnError"), Boolean)
        Me.txtToID.Properties.Mask.EditMask = resources.GetString("txtToID.Properties.Mask.EditMask")
        Me.txtToID.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtToID.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtToID.Properties.Mask.MaskType = CType(resources.GetObject("txtToID.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtToID.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtToID.Properties.Mask.PlaceHolder"), Char)
        Me.txtToID.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtToID.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtToID.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtToID.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtToID.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtToID.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtToID.Properties.NullValuePrompt = resources.GetString("txtToID.Properties.NullValuePrompt")
        Me.txtToID.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtToID.Properties.NullValuePromptShowForEmptyValue"), Boolean)
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
        Me.cbToInstitution.Properties.AccessibleDescription = resources.GetString("cbToInstitution.Properties.AccessibleDescription")
        Me.cbToInstitution.Properties.AccessibleName = resources.GetString("cbToInstitution.Properties.AccessibleName")
        Me.cbToInstitution.Properties.AutoHeight = CType(resources.GetObject("cbToInstitution.Properties.AutoHeight"), Boolean)
        Me.cbToInstitution.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbToInstitution.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbToInstitution.Properties.NullText = resources.GetString("cbToInstitution.Properties.NullText")
        Me.cbToInstitution.Properties.NullValuePrompt = resources.GetString("cbToInstitution.Properties.NullValuePrompt")
        Me.cbToInstitution.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbToInstitution.Properties.NullValuePromptShowForEmptyValue"), Boolean)
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
        Me.txtFromSampleID.Properties.AccessibleDescription = resources.GetString("txtFromSampleID.Properties.AccessibleDescription")
        Me.txtFromSampleID.Properties.AccessibleName = resources.GetString("txtFromSampleID.Properties.AccessibleName")
        Me.txtFromSampleID.Properties.AutoHeight = CType(resources.GetObject("txtFromSampleID.Properties.AutoHeight"), Boolean)
        Me.txtFromSampleID.Properties.Mask.AutoComplete = CType(resources.GetObject("txtFromSampleID.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtFromSampleID.Properties.Mask.BeepOnError = CType(resources.GetObject("txtFromSampleID.Properties.Mask.BeepOnError"), Boolean)
        Me.txtFromSampleID.Properties.Mask.EditMask = resources.GetString("txtFromSampleID.Properties.Mask.EditMask")
        Me.txtFromSampleID.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtFromSampleID.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtFromSampleID.Properties.Mask.MaskType = CType(resources.GetObject("txtFromSampleID.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtFromSampleID.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtFromSampleID.Properties.Mask.PlaceHolder"), Char)
        Me.txtFromSampleID.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtFromSampleID.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtFromSampleID.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtFromSampleID.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtFromSampleID.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtFromSampleID.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtFromSampleID.Properties.NullValuePrompt = resources.GetString("txtFromSampleID.Properties.NullValuePrompt")
        Me.txtFromSampleID.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtFromSampleID.Properties.NullValuePromptShowForEmptyValue"), Boolean)
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
        Me.txtFromID.Properties.AccessibleDescription = resources.GetString("txtFromID.Properties.AccessibleDescription")
        Me.txtFromID.Properties.AccessibleName = resources.GetString("txtFromID.Properties.AccessibleName")
        Me.txtFromID.Properties.AutoHeight = CType(resources.GetObject("txtFromID.Properties.AutoHeight"), Boolean)
        Me.txtFromID.Properties.Mask.AutoComplete = CType(resources.GetObject("txtFromID.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtFromID.Properties.Mask.BeepOnError = CType(resources.GetObject("txtFromID.Properties.Mask.BeepOnError"), Boolean)
        Me.txtFromID.Properties.Mask.EditMask = resources.GetString("txtFromID.Properties.Mask.EditMask")
        Me.txtFromID.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtFromID.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtFromID.Properties.Mask.MaskType = CType(resources.GetObject("txtFromID.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtFromID.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtFromID.Properties.Mask.PlaceHolder"), Char)
        Me.txtFromID.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtFromID.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtFromID.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtFromID.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtFromID.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtFromID.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtFromID.Properties.NullValuePrompt = resources.GetString("txtFromID.Properties.NullValuePrompt")
        Me.txtFromID.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtFromID.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.txtFromID.Tag = "{R}"
        '
        'datFromDate
        '
        resources.ApplyResources(Me.datFromDate, "datFromDate")
        Me.datFromDate.Name = "datFromDate"
        Me.datFromDate.Properties.AccessibleDescription = resources.GetString("datFromDate.Properties.AccessibleDescription")
        Me.datFromDate.Properties.AccessibleName = resources.GetString("datFromDate.Properties.AccessibleName")
        Me.datFromDate.Properties.AutoHeight = CType(resources.GetObject("datFromDate.Properties.AutoHeight"), Boolean)
        Me.datFromDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("datFromDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.datFromDate.Properties.Mask.AutoComplete = CType(resources.GetObject("datFromDate.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.datFromDate.Properties.Mask.BeepOnError = CType(resources.GetObject("datFromDate.Properties.Mask.BeepOnError"), Boolean)
        Me.datFromDate.Properties.Mask.EditMask = resources.GetString("datFromDate.Properties.Mask.EditMask")
        Me.datFromDate.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("datFromDate.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.datFromDate.Properties.Mask.MaskType = CType(resources.GetObject("datFromDate.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.datFromDate.Properties.Mask.PlaceHolder = CType(resources.GetObject("datFromDate.Properties.Mask.PlaceHolder"), Char)
        Me.datFromDate.Properties.Mask.SaveLiteral = CType(resources.GetObject("datFromDate.Properties.Mask.SaveLiteral"), Boolean)
        Me.datFromDate.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("datFromDate.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.datFromDate.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("datFromDate.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.datFromDate.Properties.NullValuePrompt = resources.GetString("datFromDate.Properties.NullValuePrompt")
        Me.datFromDate.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("datFromDate.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.datFromDate.Properties.VistaTimeProperties.AccessibleDescription = resources.GetString("datFromDate.Properties.VistaTimeProperties.AccessibleDescription")
        Me.datFromDate.Properties.VistaTimeProperties.AccessibleName = resources.GetString("datFromDate.Properties.VistaTimeProperties.AccessibleName")
        Me.datFromDate.Properties.VistaTimeProperties.AutoHeight = CType(resources.GetObject("datFromDate.Properties.VistaTimeProperties.AutoHeight"), Boolean)
        Me.datFromDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.datFromDate.Properties.VistaTimeProperties.Mask.AutoComplete = CType(resources.GetObject("datFromDate.Properties.VistaTimeProperties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.datFromDate.Properties.VistaTimeProperties.Mask.BeepOnError = CType(resources.GetObject("datFromDate.Properties.VistaTimeProperties.Mask.BeepOnError"), Boolean)
        Me.datFromDate.Properties.VistaTimeProperties.Mask.EditMask = resources.GetString("datFromDate.Properties.VistaTimeProperties.Mask.EditMask")
        Me.datFromDate.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("datFromDate.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.datFromDate.Properties.VistaTimeProperties.Mask.MaskType = CType(resources.GetObject("datFromDate.Properties.VistaTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.datFromDate.Properties.VistaTimeProperties.Mask.PlaceHolder = CType(resources.GetObject("datFromDate.Properties.VistaTimeProperties.Mask.PlaceHolder"), Char)
        Me.datFromDate.Properties.VistaTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("datFromDate.Properties.VistaTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.datFromDate.Properties.VistaTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("datFromDate.Properties.VistaTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.datFromDate.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("datFromDate.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.datFromDate.Properties.VistaTimeProperties.NullValuePrompt = resources.GetString("datFromDate.Properties.VistaTimeProperties.NullValuePrompt")
        Me.datFromDate.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("datFromDate.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue"), Boolean)
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
        Me.cbFromInstitution.Properties.AccessibleDescription = resources.GetString("cbFromInstitution.Properties.AccessibleDescription")
        Me.cbFromInstitution.Properties.AccessibleName = resources.GetString("cbFromInstitution.Properties.AccessibleName")
        Me.cbFromInstitution.Properties.AutoHeight = CType(resources.GetObject("cbFromInstitution.Properties.AutoHeight"), Boolean)
        Me.cbFromInstitution.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbFromInstitution.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbFromInstitution.Properties.NullText = resources.GetString("cbFromInstitution.Properties.NullText")
        Me.cbFromInstitution.Properties.NullValuePrompt = resources.GetString("cbFromInstitution.Properties.NullValuePrompt")
        Me.cbFromInstitution.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbFromInstitution.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.cbFromInstitution.Tag = "{R}"
        '
        'Label17
        '
        resources.ApplyResources(Me.Label17, "Label17")
        Me.Label17.Name = "Label17"
        '
        'tpTests
        '
        resources.ApplyResources(Me.tpTests, "tpTests")
        Me.tpTests.Controls.Add(Me.btnAdd)
        Me.tpTests.Controls.Add(Me.btnSelectTest)
        Me.tpTests.Controls.Add(Me.btnDeleteTest)
        Me.tpTests.Controls.Add(Me.TestGrid)
        Me.tpTests.Name = "tpTests"
        '
        'btnAdd
        '
        resources.ApplyResources(Me.btnAdd, "btnAdd")
        Me.btnAdd.Appearance.Font = CType(resources.GetObject("btnAdd.Appearance.Font"), System.Drawing.Font)
        Me.btnAdd.Appearance.GradientMode = CType(resources.GetObject("btnAdd.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.btnAdd.Appearance.Image = CType(resources.GetObject("btnAdd.Appearance.Image"), System.Drawing.Image)
        Me.btnAdd.Appearance.Options.UseFont = True
        Me.btnAdd.Image = Global.EIDSS.My.Resources.Resources.add
        Me.btnAdd.Name = "btnAdd"
        '
        'btnSelectTest
        '
        resources.ApplyResources(Me.btnSelectTest, "btnSelectTest")
        Me.btnSelectTest.Appearance.Font = CType(resources.GetObject("btnSelectTest.Appearance.Font"), System.Drawing.Font)
        Me.btnSelectTest.Appearance.GradientMode = CType(resources.GetObject("btnSelectTest.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.btnSelectTest.Appearance.Image = CType(resources.GetObject("btnSelectTest.Appearance.Image"), System.Drawing.Image)
        Me.btnSelectTest.Appearance.Options.UseFont = True
        Me.btnSelectTest.Image = Global.EIDSS.My.Resources.Resources.add
        Me.btnSelectTest.Name = "btnSelectTest"
        '
        'btnDeleteTest
        '
        resources.ApplyResources(Me.btnDeleteTest, "btnDeleteTest")
        Me.btnDeleteTest.Appearance.Font = CType(resources.GetObject("btnDeleteTest.Appearance.Font"), System.Drawing.Font)
        Me.btnDeleteTest.Appearance.GradientMode = CType(resources.GetObject("btnDeleteTest.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.btnDeleteTest.Appearance.Image = CType(resources.GetObject("btnDeleteTest.Appearance.Image"), System.Drawing.Image)
        Me.btnDeleteTest.Appearance.Options.UseFont = True
        Me.btnDeleteTest.Image = Global.EIDSS.My.Resources.Resources.Delete_Remove
        Me.btnDeleteTest.Name = "btnDeleteTest"
        '
        'TestGrid
        '
        resources.ApplyResources(Me.TestGrid, "TestGrid")
        Me.TestGrid.EmbeddedNavigator.AccessibleDescription = resources.GetString("TestGrid.EmbeddedNavigator.AccessibleDescription")
        Me.TestGrid.EmbeddedNavigator.AccessibleName = resources.GetString("TestGrid.EmbeddedNavigator.AccessibleName")
        Me.TestGrid.EmbeddedNavigator.AllowHtmlTextInToolTip = CType(resources.GetObject("TestGrid.EmbeddedNavigator.AllowHtmlTextInToolTip"), DevExpress.Utils.DefaultBoolean)
        Me.TestGrid.EmbeddedNavigator.Anchor = CType(resources.GetObject("TestGrid.EmbeddedNavigator.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.TestGrid.EmbeddedNavigator.BackgroundImage = CType(resources.GetObject("TestGrid.EmbeddedNavigator.BackgroundImage"), System.Drawing.Image)
        Me.TestGrid.EmbeddedNavigator.BackgroundImageLayout = CType(resources.GetObject("TestGrid.EmbeddedNavigator.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.TestGrid.EmbeddedNavigator.ImeMode = CType(resources.GetObject("TestGrid.EmbeddedNavigator.ImeMode"), System.Windows.Forms.ImeMode)
        Me.TestGrid.EmbeddedNavigator.MaximumSize = CType(resources.GetObject("TestGrid.EmbeddedNavigator.MaximumSize"), System.Drawing.Size)
        Me.TestGrid.EmbeddedNavigator.TextLocation = CType(resources.GetObject("TestGrid.EmbeddedNavigator.TextLocation"), DevExpress.XtraEditors.NavigatorButtonsTextLocation)
        Me.TestGrid.EmbeddedNavigator.ToolTip = resources.GetString("TestGrid.EmbeddedNavigator.ToolTip")
        Me.TestGrid.EmbeddedNavigator.ToolTipIconType = CType(resources.GetObject("TestGrid.EmbeddedNavigator.ToolTipIconType"), DevExpress.Utils.ToolTipIconType)
        Me.TestGrid.EmbeddedNavigator.ToolTipTitle = resources.GetString("TestGrid.EmbeddedNavigator.ToolTipTitle")
        Me.TestGrid.MainView = Me.TestGridView
        Me.TestGrid.Name = "TestGrid"
        Me.TestGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbTestType, Me.cbCategory, Me.cbTestResult, Me.cbStatus, Me.cbDiagnosis})
        Me.TestGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.TestGridView, Me.GridView1})
        '
        'TestGridView
        '
        resources.ApplyResources(Me.TestGridView, "TestGridView")
        Me.TestGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colTestName, Me.colCategory, Me.colDiagnosis, Me.colBatch, Me.colDateTested, Me.colStatus, Me.colResult, Me.colDateReceived, Me.colContactPerson})
        Me.TestGridView.GridControl = Me.TestGrid
        Me.TestGridView.Name = "TestGridView"
        Me.TestGridView.OptionsCustomization.AllowFilter = False
        Me.TestGridView.OptionsNavigation.EnterMoveNextColumn = True
        Me.TestGridView.OptionsView.ShowGroupPanel = False
        '
        'colTestName
        '
        resources.ApplyResources(Me.colTestName, "colTestName")
        Me.colTestName.ColumnEdit = Me.cbTestType
        Me.colTestName.FieldName = "idfsTestType"
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
        Me.colCategory.FieldName = "idfsTestForDiseaseType"
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
        'colDateTested
        '
        resources.ApplyResources(Me.colDateTested, "colDateTested")
        Me.colDateTested.FieldName = "datConcludedDate"
        Me.colDateTested.Name = "colDateTested"
        '
        'colStatus
        '
        Me.colStatus.AppearanceHeader.GradientMode = CType(resources.GetObject("colStatus.AppearanceHeader.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.colStatus.AppearanceHeader.Image = CType(resources.GetObject("colStatus.AppearanceHeader.Image"), System.Drawing.Image)
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
        resources.ApplyResources(Me.GridView1, "GridView1")
        Me.GridView1.GridControl = Me.TestGrid
        Me.GridView1.Name = "GridView1"
        '
        'tpGeneral
        '
        resources.ApplyResources(Me.tpGeneral, "tpGeneral")
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
        Me.txtSessionID.Properties.AccessibleDescription = resources.GetString("txtSessionID.Properties.AccessibleDescription")
        Me.txtSessionID.Properties.AccessibleName = resources.GetString("txtSessionID.Properties.AccessibleName")
        Me.txtSessionID.Properties.AutoHeight = CType(resources.GetObject("txtSessionID.Properties.AutoHeight"), Boolean)
        Me.txtSessionID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtSessionID.Properties.Mask.AutoComplete = CType(resources.GetObject("txtSessionID.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtSessionID.Properties.Mask.BeepOnError = CType(resources.GetObject("txtSessionID.Properties.Mask.BeepOnError"), Boolean)
        Me.txtSessionID.Properties.Mask.EditMask = resources.GetString("txtSessionID.Properties.Mask.EditMask")
        Me.txtSessionID.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtSessionID.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtSessionID.Properties.Mask.MaskType = CType(resources.GetObject("txtSessionID.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtSessionID.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtSessionID.Properties.Mask.PlaceHolder"), Char)
        Me.txtSessionID.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtSessionID.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtSessionID.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtSessionID.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtSessionID.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtSessionID.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtSessionID.Properties.NullValuePrompt = resources.GetString("txtSessionID.Properties.NullValuePrompt")
        Me.txtSessionID.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtSessionID.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.txtSessionID.Tag = "{R}"
        '
        'txtNote
        '
        resources.ApplyResources(Me.txtNote, "txtNote")
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Properties.AccessibleDescription = resources.GetString("txtNote.Properties.AccessibleDescription")
        Me.txtNote.Properties.AccessibleName = resources.GetString("txtNote.Properties.AccessibleName")
        Me.txtNote.Properties.NullValuePrompt = resources.GetString("txtNote.Properties.NullValuePrompt")
        Me.txtNote.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtNote.Properties.NullValuePromptShowForEmptyValue"), Boolean)
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
        Me.txtParentID.Properties.AccessibleDescription = resources.GetString("txtParentID.Properties.AccessibleDescription")
        Me.txtParentID.Properties.AccessibleName = resources.GetString("txtParentID.Properties.AccessibleName")
        Me.txtParentID.Properties.AutoHeight = CType(resources.GetObject("txtParentID.Properties.AutoHeight"), Boolean)
        Me.txtParentID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtParentID.Properties.Mask.AutoComplete = CType(resources.GetObject("txtParentID.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtParentID.Properties.Mask.BeepOnError = CType(resources.GetObject("txtParentID.Properties.Mask.BeepOnError"), Boolean)
        Me.txtParentID.Properties.Mask.EditMask = resources.GetString("txtParentID.Properties.Mask.EditMask")
        Me.txtParentID.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtParentID.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtParentID.Properties.Mask.MaskType = CType(resources.GetObject("txtParentID.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtParentID.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtParentID.Properties.Mask.PlaceHolder"), Char)
        Me.txtParentID.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtParentID.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtParentID.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtParentID.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtParentID.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtParentID.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtParentID.Properties.NullValuePrompt = resources.GetString("txtParentID.Properties.NullValuePrompt")
        Me.txtParentID.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtParentID.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.txtParentID.Tag = "{R}"
        '
        'cbLocation
        '
        resources.ApplyResources(Me.cbLocation, "cbLocation")
        Me.cbLocation.Name = "cbLocation"
        Me.cbLocation.Properties.AccessibleDescription = resources.GetString("cbLocation.Properties.AccessibleDescription")
        Me.cbLocation.Properties.AccessibleName = resources.GetString("cbLocation.Properties.AccessibleName")
        Me.cbLocation.Properties.AutoHeight = CType(resources.GetObject("cbLocation.Properties.AutoHeight"), Boolean)
        Me.cbLocation.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbLocation.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbLocation.Properties.NullValuePrompt = resources.GetString("cbLocation.Properties.NullValuePrompt")
        Me.cbLocation.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbLocation.Properties.NullValuePromptShowForEmptyValue"), Boolean)
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
        Me.cbCollectedByOrganization.Properties.AccessibleDescription = resources.GetString("cbCollectedByOrganization.Properties.AccessibleDescription")
        Me.cbCollectedByOrganization.Properties.AccessibleName = resources.GetString("cbCollectedByOrganization.Properties.AccessibleName")
        Me.cbCollectedByOrganization.Properties.AutoHeight = CType(resources.GetObject("cbCollectedByOrganization.Properties.AutoHeight"), Boolean)
        Me.cbCollectedByOrganization.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbCollectedByOrganization.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbCollectedByOrganization.Properties.NullText = resources.GetString("cbCollectedByOrganization.Properties.NullText")
        Me.cbCollectedByOrganization.Properties.NullValuePrompt = resources.GetString("cbCollectedByOrganization.Properties.NullValuePrompt")
        Me.cbCollectedByOrganization.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbCollectedByOrganization.Properties.NullValuePromptShowForEmptyValue"), Boolean)
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
        Me.cbCollectedByPerson.Properties.AccessibleDescription = resources.GetString("cbCollectedByPerson.Properties.AccessibleDescription")
        Me.cbCollectedByPerson.Properties.AccessibleName = resources.GetString("cbCollectedByPerson.Properties.AccessibleName")
        Me.cbCollectedByPerson.Properties.AutoHeight = CType(resources.GetObject("cbCollectedByPerson.Properties.AutoHeight"), Boolean)
        Me.cbCollectedByPerson.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbCollectedByPerson.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbCollectedByPerson.Properties.NullText = resources.GetString("cbCollectedByPerson.Properties.NullText")
        Me.cbCollectedByPerson.Properties.NullValuePrompt = resources.GetString("cbCollectedByPerson.Properties.NullValuePrompt")
        Me.cbCollectedByPerson.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbCollectedByPerson.Properties.NullValuePromptShowForEmptyValue"), Boolean)
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
        Me.cbDepartment.Properties.AccessibleDescription = resources.GetString("cbDepartment.Properties.AccessibleDescription")
        Me.cbDepartment.Properties.AccessibleName = resources.GetString("cbDepartment.Properties.AccessibleName")
        Me.cbDepartment.Properties.AutoHeight = CType(resources.GetObject("cbDepartment.Properties.AutoHeight"), Boolean)
        Me.cbDepartment.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDepartment.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbDepartment.Properties.NullText = resources.GetString("cbDepartment.Properties.NullText")
        Me.cbDepartment.Properties.NullValuePrompt = resources.GetString("cbDepartment.Properties.NullValuePrompt")
        Me.cbDepartment.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbDepartment.Properties.NullValuePromptShowForEmptyValue"), Boolean)
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
        Me.txtPartyInfo.Properties.AccessibleDescription = resources.GetString("txtPartyInfo.Properties.AccessibleDescription")
        Me.txtPartyInfo.Properties.AccessibleName = resources.GetString("txtPartyInfo.Properties.AccessibleName")
        Me.txtPartyInfo.Properties.AutoHeight = CType(resources.GetObject("txtPartyInfo.Properties.AutoHeight"), Boolean)
        Me.txtPartyInfo.Properties.Mask.AutoComplete = CType(resources.GetObject("txtPartyInfo.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtPartyInfo.Properties.Mask.BeepOnError = CType(resources.GetObject("txtPartyInfo.Properties.Mask.BeepOnError"), Boolean)
        Me.txtPartyInfo.Properties.Mask.EditMask = resources.GetString("txtPartyInfo.Properties.Mask.EditMask")
        Me.txtPartyInfo.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtPartyInfo.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtPartyInfo.Properties.Mask.MaskType = CType(resources.GetObject("txtPartyInfo.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtPartyInfo.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtPartyInfo.Properties.Mask.PlaceHolder"), Char)
        Me.txtPartyInfo.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtPartyInfo.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtPartyInfo.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtPartyInfo.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtPartyInfo.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtPartyInfo.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtPartyInfo.Properties.NullValuePrompt = resources.GetString("txtPartyInfo.Properties.NullValuePrompt")
        Me.txtPartyInfo.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtPartyInfo.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.txtPartyInfo.Tag = "[en]{R}"
        '
        'txtCaseID
        '
        resources.ApplyResources(Me.txtCaseID, "txtCaseID")
        Me.txtCaseID.Name = "txtCaseID"
        Me.txtCaseID.Properties.AccessibleDescription = resources.GetString("txtCaseID.Properties.AccessibleDescription")
        Me.txtCaseID.Properties.AccessibleName = resources.GetString("txtCaseID.Properties.AccessibleName")
        Me.txtCaseID.Properties.AutoHeight = CType(resources.GetObject("txtCaseID.Properties.AutoHeight"), Boolean)
        Me.txtCaseID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtCaseID.Properties.Mask.AutoComplete = CType(resources.GetObject("txtCaseID.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtCaseID.Properties.Mask.BeepOnError = CType(resources.GetObject("txtCaseID.Properties.Mask.BeepOnError"), Boolean)
        Me.txtCaseID.Properties.Mask.EditMask = resources.GetString("txtCaseID.Properties.Mask.EditMask")
        Me.txtCaseID.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtCaseID.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtCaseID.Properties.Mask.MaskType = CType(resources.GetObject("txtCaseID.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtCaseID.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtCaseID.Properties.Mask.PlaceHolder"), Char)
        Me.txtCaseID.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtCaseID.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtCaseID.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtCaseID.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtCaseID.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtCaseID.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtCaseID.Properties.NullValuePrompt = resources.GetString("txtCaseID.Properties.NullValuePrompt")
        Me.txtCaseID.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtCaseID.Properties.NullValuePromptShowForEmptyValue"), Boolean)
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
        Me.txtCaseType.Properties.AccessibleDescription = resources.GetString("txtCaseType.Properties.AccessibleDescription")
        Me.txtCaseType.Properties.AccessibleName = resources.GetString("txtCaseType.Properties.AccessibleName")
        Me.txtCaseType.Properties.AutoHeight = CType(resources.GetObject("txtCaseType.Properties.AutoHeight"), Boolean)
        Me.txtCaseType.Properties.Mask.AutoComplete = CType(resources.GetObject("txtCaseType.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtCaseType.Properties.Mask.BeepOnError = CType(resources.GetObject("txtCaseType.Properties.Mask.BeepOnError"), Boolean)
        Me.txtCaseType.Properties.Mask.EditMask = resources.GetString("txtCaseType.Properties.Mask.EditMask")
        Me.txtCaseType.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtCaseType.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtCaseType.Properties.Mask.MaskType = CType(resources.GetObject("txtCaseType.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtCaseType.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtCaseType.Properties.Mask.PlaceHolder"), Char)
        Me.txtCaseType.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtCaseType.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtCaseType.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtCaseType.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtCaseType.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtCaseType.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtCaseType.Properties.NullValuePrompt = resources.GetString("txtCaseType.Properties.NullValuePrompt")
        Me.txtCaseType.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtCaseType.Properties.NullValuePromptShowForEmptyValue"), Boolean)
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
        Me.KeyFieldName = "idfContainer"
        Me.LeftIcon = Global.EIDSS.My.Resources.Resources.Sample__large_
        Me.Name = "SampleDetail"
        Me.ObjectName = "Sample"
        Me.ShowDeleteButton = False
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "Material"
        Me.Controls.SetChildIndex(Me.cmdOk, 0)
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
        CType(Me.datToDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datToDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtToSampleID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtToID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbToInstitution.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.txtFromSampleID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFromID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datFromDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datFromDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbFromInstitution.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpTests.ResumeLayout(False)
        CType(Me.TestGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TestGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTestType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCategory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDiagnosis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTestResult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpGeneral.ResumeLayout(False)
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



    Protected Sub SetReanOnly(ByVal ctrl As DevExpress.XtraEditors.LookUpEdit)
        For Each btn As DevExpress.XtraEditors.Controls.EditorButton In ctrl.Properties.Buttons
            'btn.
        Next
    End Sub

    Protected Sub TestTypeHandler(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        e.Row("idfsTestResult") = DBNull.Value
        Me.TestGridView.UpdateCurrentRow()
    End Sub
    Protected Sub TestStatusChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        If e.Value Is DBNull.Value OrElse CLng(e.Row("idfsTestStatus")) = CLng(model.Enums.TestStatus.Undefined) Then
            e.Row("idfsTestResult") = DBNull.Value
            Me.TestGridView.UpdateCurrentRow()
        End If
        e.Row.EndEdit()
    End Sub
    Protected Sub TestResultChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        If (e.Row("idfsTestResult") Is DBNull.Value) Then
            e.Row("idfResultEnteredByOffice") = DBNull.Value
            e.Row("idfResultEnteredByPerson") = DBNull.Value
        Else
            e.Row("idfResultEnteredByOffice") = EIDSS.model.Core.EidssSiteContext.Instance.OrganizationID
            e.Row("idfResultEnteredByPerson") = EIDSS.model.Core.EidssUserContext.User.EmployeeID
        End If
    End Sub

    Private Sub DefineTransferPage()
        Core.LookupBinder.BindOrganizationLookup(Me.cbFromInstitution, baseDataSet, Sample_DB.TableTransferFrom + ".idfSendFromOffice")
        If baseDataSet.Tables(Sample_DB.TableTransferFrom).Rows.Count > 0 Then
            Dim row As DataRow = baseDataSet.Tables(Sample_DB.TableTransferFrom).Rows(0)
            Me.txtFromID.EditValue = row("strBarcode")
            Me.txtFromSampleID.EditValue = row("ContainerBarcode")
            Me.datFromDate.EditValue = Me.baseDataSet.Tables(Sample_DB.TableSample).Rows(0)("datCreationDate")
        End If

        Core.LookupBinder.BindOrganizationLookup(Me.cbToInstitution, baseDataSet, Sample_DB.TableTransferTo + ".idfSendToOffice")
        If baseDataSet.Tables(Sample_DB.TableTransferTo).Rows.Count > 0 Then
            Dim row As DataRow = baseDataSet.Tables(Sample_DB.TableTransferTo).Rows(0)
            Me.txtToID.EditValue = row("strBarcode")
            Me.txtToSampleID.EditValue = row("ContainerBarcode")
            Me.datToDate.EditValue = row("datSendDate")
        End If
        If baseDataSet.Tables(Sample_DB.TableTransferFrom).Rows.Count + baseDataSet.Tables(Sample_DB.TableTransferTo).Rows.Count = 0 Then
            Me.TabControl1.TabPages.Remove(Me.tpTransfer)
        End If
    End Sub

    Protected Sub DefineTestsPage()
        Core.LookupBinder.BindBaseRepositoryLookup(Me.cbTestType, BaseReferenceType.rftTestType, AccessoryCode)
        Core.LookupBinder.BindBaseRepositoryLookup(Me.cbCategory, BaseReferenceType.rftTestForDiseaseType, AccessoryCode, False)
        Core.LookupBinder.BindBaseRepositoryLookup(Me.cbStatus, BaseReferenceType.rftActivityStatus, AccessoryCode, False)
        RemoveHandler cbStatus.QueryPopUp, AddressOf Core.LookupBinder.SetDefaultFilter
        RemoveHandler cbStatus.QueryCloseUp, AddressOf Core.LookupBinder.ClearDefaultFilter
        Core.LookupBinder.BindTestResultRepositoryLookup(Me.cbTestResult)
        'Core.LookupBinder.BindTestResultRepositoryLookup(Me.cbTestResultEditor)

        TestGrid.DataSource = baseDataSet.Tables(Sample_DB.TableTest)

        Me.eventManager.AttachDataHandler(Sample_DB.TableTest + ".idfsTestType", AddressOf Me.TestTypeHandler)
        Me.eventManager.AttachDataHandler(Sample_DB.TableTest + ".idfsTestResult", AddressOf Me.TestResultChanged)
        Me.eventManager.AttachDataHandler(Sample_DB.TableTest + ".idfsTestStatus", AddressOf Me.TestStatusChanged)

    End Sub

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

            Dim status As Object = Me.baseDataSet.Tables(Sample_DB.TableSample).Rows(0)("idfsContainerStatus")
            Dim sampleEnabled As Boolean = CLng(ContainerStatus.Accessioned).Equals(status)
            btnSelectTest.Enabled = m_CanAddTest AndAlso sampleEnabled

            Core.LookupBinder.BindDepartmentLookup(Me.cbDepartment, Me.baseDataSet, Sample_DB.TableSample + ".idfInDepartment")
            Dim DepartmentView As DataView = CType(cbDepartment.Properties.DataSource, DataView)
            If (sampleEnabled) Then
                DepartmentView.RowFilter = String.Format("idfInstitution = {0}", EidssSiteContext.Instance.OrganizationID)
            Else
                DepartmentView.RowFilter = String.Format("idfInstitution = {0} or idfDepartment=-1", EidssSiteContext.Instance.OrganizationID)
            End If
            Core.LookupBinder.BindDiagnosisHACodeRepositoryLookup(Me.cbDiagnosis, LookupTables.StandardDiagnosis, False, False)
            'Me.cbDiagnosis.DataSource = Me.baseDataSet.Tables(Sample_DB.TableDiagnosis)


            Core.LookupBinder.BindDiagnosisHACodeRepositoryLookup(Me.cbCaseCurrentDiagnosis, LookupTables.StandardDiagnosis, False, False)
            Me.cbCaseCurrentDiagnosis.DataSource = Me.baseDataSet.Tables(Sample_DB.TableDiagnosis)


            Me.txtSpecimenType.DataBindings.Add("EditValue", baseDataSet, Sample_DB.TableSample + ".SpecimenType")

            Core.LookupBinder.BindTextEdit(txtSampleID, baseDataSet, Sample_DB.TableSample + ".strBarcode")
            txtParentID.DataBindings.Add("EditValue", baseDataSet, Sample_DB.TableSample + ".strParentBarcode")

            Core.LookupBinder.BindOrganizationLookup(cbCollectedByOrganization, baseDataSet, Sample_DB.TableSample + ".idfFieldCollectedByOffice")
            Core.LookupBinder.BindPersonLookup(cbCollectedByPerson, baseDataSet, Sample_DB.TableSample + ".idfFieldCollectedByPerson")
            Core.LookupBinder.BindTextEdit(txtNote, baseDataSet, Sample_DB.TableSample + ".strNote")
            EnableCaseEditing = False
            EnablePartyEditing = False

            If Utils.IsEmpty(StartUpParameters) = False AndAlso StartUpParameters.ContainsKey("PartyID") Then
                EnablePartyEditing = False
            End If
            txtCaseID.EditValue = CreateCaseDescription()
            If (Utils.IsEmpty(txtCaseID.EditValue)) Then
                txtCaseID.Properties.Buttons.Clear()
            End If
            txtSessionID.DataBindings.Add("EditValue", baseDataSet, Sample_DB.TableSample + ".strMonitoringSessionID")
            If Utils.IsEmpty(baseDataSet.Tables(Sample_DB.TableSample).Rows(0)("strMonitoringSessionID")) Then
                txtSessionID.Properties.Buttons.Clear()
            End If
            txtPartyInfo.EditValue = LabUtils.GetPatientInfo(baseDataSet.Tables(Sample_DB.TableSample).Rows(0)) 'CreatePatientDescription()

            txtCaseType.DataBindings.Add("EditValue", baseDataSet, Sample_DB.TableSample + ".CaseType")
            LabUtils.BindFreezerLocation(Me.cbLocation, baseDataSet, Sample_DB.TableSample + ".idfSubdivision")
            'bind tests
            DefineTestsPage()
            DefineTransferPage()

            Dim transferred As Boolean = False
            If baseDataSet.Tables(Sample_DB.TableTransferTo).Rows.Count = 1 Then
                transferred = Utils.IsEmpty(baseDataSet.Tables(Sample_DB.TableTransferTo).Rows(0)("idfsSite"))
            End If
            Me.btnAdd.Visible = transferred
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
                SetControlReadOnly(Me.cbLocation, True, False)
                SetControlReadOnly(Me.cbDepartment, True, False)
            End If
            'm_CanDeleteTest = m_CanDeleteTest AndAlso Not (CLng(ContainerStatus.Destroyed).Equals(status) OrElse CLng(ContainerStatus.Destroy).Equals(status))
            btnDeleteTest.Enabled = m_CanDeleteTest AndAlso baseDataSet.Tables(Sample_DB.TableTest).Rows.Count > 0
        Catch e As Exception
            ErrorForm.ShowError(StandardError.FillDatasetError, e)
        End Try

    End Sub

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
                    LabUtils.ShowCase(FindForm, Me.baseDataSet.Tables(Sample_DB.TableSample).Rows(0), sender Is Me.txtSessionID)
                End If

            Finally
                UnlockHandler()
            End Try
        End If
    End Sub


    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        If baseDataSet Is Nothing OrElse baseDataSet.Tables.Count = 0 Then
            Return
        End If
        If Post(PostType.FinalPosting) Then
            EidssSiteContext.ReportFactory.LimContainerDetails(CType(Me.SampleDbService.ID, Long))
        End If
    End Sub


    Private Sub txtParentID_ButtonPressed(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtParentID.ButtonPressed
        Dim id As Object = Me.baseDataSet.Tables(Sample_DB.TableSample).Rows(0)("idfParentContainer")
        If Utils.IsEmpty(id) Then Exit Sub

        BaseFormManager.ShowNormal(New SampleDetail, id)
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim row As DataRow = CreateNewTest()
        If row Is Nothing Then
            Return
        End If
        row("idfExtBatchTest") = BaseDbService.NewIntID()
        row("idfsTestStatus") = model.Enums.TestStatus.Completed
        row.EndEdit()
    End Sub

    Public Overrides Function ValidateData() As Boolean
        Dim table As DataTable = Me.baseDataSet.Tables(Sample_DB.TableTest)

        'For Each row As DataRow In table.Rows
        For index As Integer = 0 To Me.TestGridView.RowCount - 1
            Dim handle As Integer = Me.TestGridView.GetRowHandle(index)
            If Not IsTestRowValid(handle, True) Then
                Me.TestGridView.FocusedRowHandle = handle
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub TestGridView_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles TestGridView.FocusedRowChanged
        If e.PrevFocusedRowHandle >= 0 AndAlso Not IsTestRowValid(e.PrevFocusedRowHandle) Then
            TestGridView.FocusedRowHandle = e.PrevFocusedRowHandle
        End If
        UpdateTestButtons()
    End Sub

    Private Sub UpdateTestButtons()
        Dim row As DataRow = TestGridView.GetFocusedDataRow
        If Not row Is Nothing Then
            btnDeleteTest.Enabled = m_CanDeleteTest AndAlso row("idfBatchTest") Is DBNull.Value AndAlso ( _
                row("idfsTestStatus") Is DBNull.Value _
                OrElse CLng(row("idfsTestStatus")) = CLng(model.Enums.TestStatus.Undefined) _
                OrElse CLng(row("idfsTestStatus")) = CLng(model.Enums.TestStatus.InProgress))
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
        Dim status As Long = CLng(row("idfsTestStatus"))
        If ((status = CLng(model.Enums.TestStatus.Completed) AndAlso Not (row.RowState = DataRowState.Added OrElse row.RowState = DataRowState.Modified)) OrElse status = CLng(model.Enums.TestStatus.Amended)) Then
            Return False
        End If
        If status = CLng(model.Enums.TestStatus.InProgress) Then
            Return row("idfBatchTest") Is DBNull.Value
        End If
        If (TestGridView.FocusedColumn Is colResult) OrElse (TestGridView.FocusedColumn Is colDateTested) Then
            Return ((status = CLng(model.Enums.TestStatus.Completed) AndAlso (row.RowState = DataRowState.Added OrElse row.RowState = DataRowState.Modified)) OrElse status = CLng(model.Enums.TestStatus.InProgress))
        End If
        Return True
    End Function
    Private Sub TestGridView_ShowingEditor(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TestGridView.ShowingEditor

        If TestGridView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then Exit Sub
        Dim row As DataRow = Me.TestGridView.GetFocusedDataRow()
        e.Cancel = Not IsTestRowEditable(row)
        Return
    End Sub


    Private Sub TestGridView_CustomRowCellEditForEditing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles TestGridView.CustomRowCellEditForEditing
        'If (e.Column Is Me.colResult) Then
        '    CType(cbTestResultEditor.DataSource, DataView).RowFilter = "idfsTestType=" + Utils.Str(TestGridView.GetDataRow(e.RowHandle)("idfsTestType"), "0")
        '    e.RepositoryItem = Me.cbTestResultEditor
        'End If
        If (e.Column Is Me.colDiagnosis) Then
            e.RepositoryItem = Me.cbCaseCurrentDiagnosis
        End If
    End Sub

    Private Function CreateNewTest() As DataRow
        If IsTestRowValid() = False Then Return Nothing
        Dim sampleRow As DataRow = baseDataSet.Tables(Sample_DB.TableSample).Rows(0)

        Dim table As DataTable = Me.baseDataSet.Tables(Sample_DB.TableTest)
        Dim row As DataRow = table.NewRow()
        row("idfTesting") = BaseDbService.NewIntID()
        row("idfsTestStatus") = model.Enums.TestStatus.Undefined
        row("idfObservation") = BaseDbService.NewIntID
        row("idfContainer") = GetKey()
        row("blnNonLaboratoryTest") = 0
        If Not sampleRow("idfCase") Is DBNull.Value Then
            row("idfsDiagnosis") = sampleRow("idfsShowDiagnosis")
        ElseIf Not sampleRow("idfMonitoringSession") Is DBNull.Value AndAlso _
            baseDataSet.Tables(Sample_DB.TableDiagnosis).Rows.Count > 0 Then
            row("idfsDiagnosis") = baseDataSet.Tables(Sample_DB.TableDiagnosis).Rows(0)("idfsDiagnosis")
        End If
        row("idfTestedByOffice") = EIDSS.model.Core.EidssSiteContext.Instance.OrganizationID
        table.Rows.Add(row)
        DxControlsHelper.SetRowHandleForDataRow(TestGridView, row, "idfTesting")
        TestGridView.FocusedColumn = colTestName
        Return row
    End Function

    Private Sub btnSelectTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectTest.Click
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
    Private m_TestMandatoryFields As New List(Of FieldCaptionPair)
    Private Sub InitManadatoryFields()
        If (m_TestMandatoryFields.Count = 0) Then
            m_TestMandatoryFields.AddRange({
                                            New FieldCaptionPair("idfsTestType", colTestName.Caption), _
                                            New FieldCaptionPair("idfsTestForDiseaseType", colCategory.Caption), _
                                            New FieldCaptionPair("idfsDiagnosis", colDiagnosis.Caption), _
                                            New FieldCaptionPair("idfsTestStatus", colStatus.Caption), _
                                            New FieldCaptionPair("datConcludedDate", colDateTested.Caption), _
                                            New FieldCaptionPair("datReceivedDate", colDateReceived.Caption), _
                                            New FieldCaptionPair("idfsTestResult", colResult.Caption) _
                                            })
        End If
    End Sub
    Private Function ShouldValidateField(ByVal fieldName As String, ByVal row As DataRow) As Boolean
        If fieldName = "idfsTestResult" OrElse fieldName = "datConcludedDate" Then
            Return row("idfsTestStatus").Equals(CLng(model.Enums.TestStatus.Completed))
        End If
        If fieldName = "datReceivedDate" Then
            Return Not row("idfExtBatchTest") Is DBNull.Value
        End If
        Return True
    End Function
    Private Function IsTestRowValid(Optional ByVal index As Integer = -1, Optional ByVal showError As Boolean = True) _
        As Boolean

        Dim row As DataRow
        If (index >= 0) Then
            row = TestGridView.GetDataRow(index)
        Else
            row = Me.TestGridView.GetFocusedDataRow
        End If
        If Not IsTestRowEditable(row) Then
            Return True
        End If
        If row Is Nothing Then Return True
        Dim msg As String = ""
        InitManadatoryFields()
        For Each f As FieldCaptionPair In m_TestMandatoryFields
            If Not ShouldValidateField(f.FieldName, row) Then
                Continue For
            End If
            If Utils.IsEmpty(row(f.FieldName)) Then
                If showError Then
                    msg = _
                        String.Format( _
                                       BvMessages.Get("ErrMandatoryFieldRequired", _
                                                           "The field {0} is mandatory. You must enter data to this field before form saving"), _
                                       f.FieldCaption)
                    ErrorForm.ShowWarningDirect(msg)
                    TestGridView.FocusedColumn = TestGridView.Columns(f.FieldName)
                End If
                Return False
            End If

        Next
        If CLng(row("idfsTestStatus")) = CLng(model.Enums.TestStatus.Completed) AndAlso Utils.IsEmpty(row("idfsTestResult")) Then
            If showError Then
                msg = _
                    String.Format( _
                                   BvMessages.Get("ErrMandatoryFieldRequired", _
                                                       "The field {0} is mandatory. You must enter data to this field before form saving"), _
                                   colResult.Caption)
                ErrorForm.ShowWarningDirect(msg)
                TestGridView.FocusedColumn = colResult
            End If
            Return False
        End If
        Return True
    End Function


    Private Sub btnDeleteTest_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeleteTest.Click
        Dim Row As DataRow = TestGridView.GetFocusedDataRow
        If Row Is Nothing Then Return
        If (Not DbService.CanDelete(Row("idfTesting"), "LabTest")) Then
            ErrorForm.ShowMessage("msgCantDeleteRecord", "The record can't be deleted")
            Return
        End If
        If bv.winclient.Core.WinUtils.ConfirmMessage(EidssMessages.Get("msgDeleteTest", "Test will be deleted. Delete Test?"), BvMessages.Get("titleDeleteTest", "Delete Test")) Then
            Row.Delete()
        End If
    End Sub

    Private Sub cbStatus_QueryCloseUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbStatus.QueryCloseUp
        CType(Me.cbStatus.DataSource, DataView).RowFilter = Nothing
    End Sub

    Private Sub cbStatus_QueryPopUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbStatus.QueryPopUp
        CType(Me.cbStatus.DataSource, DataView).RowFilter = "idfsReference in (10001001, 10001003, 10001005)"
    End Sub
End Class
