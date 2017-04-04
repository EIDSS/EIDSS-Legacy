Imports System.Collections.Generic
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports bv.common.Resources
Imports bv.model.Model.Core
Imports EIDSS.model.Core
Imports EIDSS.model.Resources
Imports EIDSS.model.Enums
Imports bv.common.Enums
Imports bv.common.win.Validators
Imports bv.winclient.Localization


Public Class OutbreakDetail
    Inherits BaseDetailForm
    Private m_HideFarmOwnerName As Boolean
    Private m_HideVetSettlement As Boolean
    Private m_HideVetAddress As Boolean
    Private m_HideVetLocation As Boolean
    Private m_HidePatientName As Boolean
    Private m_HideHumanSettlement As Boolean
    Private m_HideHumanAddress As Boolean

    Private OutbreakDbService As Outbreak_DB
    Friend WithEvents cbGeoLocation As EIDSS.LocationLookup
    Friend WithEvents txtDescription As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents lbDescription As System.Windows.Forms.Label
    Friend WithEvents tcOutbreak As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tbGeneralInfo As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tbNotes As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents NotesGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents NotesView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtNote As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents colDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents dtNoteDate As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents colPerson As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbNotePerson As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents btnDeleteNote As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gcolAddress As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnMarkAsPrimary As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gcolPatientName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtPrimaryCase As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents lbPrimaryCase As System.Windows.Forms.Label
    Friend WithEvents gcolSourceOfCaseDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbDiagnosis As DevExpress.XtraEditors.TreeListLookUpEdit
    Friend WithEvents btnAddCaseSession As bv.winclient.Core.PopUpButton


#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()


        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        OutbreakDbService = New Outbreak_DB

        DbService = OutbreakDbService
        AuditObject = New AuditObject(EIDSSAuditObject.daoOutbreak, AuditTable.tlbOutbreak)
        LookupTableNames = New String() {"Outbreak"}
        PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.Outbreak

        cbGeoLocation.DefaultLocationType = GeoLocationType.RelativePoint
        RegisterChildObject(Me.cbGeoLocation, RelatedPostOrder.PostFirst)
        txtNote.PopupFormSize = New Drawing.Size(Me.NotesGrid.Width, 300)
        m_HideVetSettlement = EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement)
        m_HideVetAddress = EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details)
        m_HideVetLocation = EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Coordinates)
        m_HideFarmOwnerName = m_HideVetSettlement OrElse m_HideVetAddress
        m_HidePatientName = EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_PersonName)
        m_HideHumanSettlement = EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_CurrentResidence_Settlement)
        m_HideHumanAddress = EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_CurrentResidence_Details)
        'AddHandler OutbreakDbService.OnBeforePost, AddressOf BeforePost
        ValidationProcedureName = "spOutbreak_Validate"

        MenuItem3.Visible = eidss.model.Reports.BaseMenuReportRegistrator.IsPaperFormAllowed("Outbreak")
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
    Friend WithEvents gcCaseList As DevExpress.XtraGrid.GridControl
    Friend WithEvents gcolCaseID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolCaseType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolDisease As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolLocation As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnViewCaseDetails As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnRemove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents lblDisease As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents dtpStartDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cmReports As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents btnReport As bv.winclient.Core.PopUpButton
    Friend WithEvents cmAddCaseSession As System.Windows.Forms.ContextMenu
    Friend WithEvents miAddHumanCase As System.Windows.Forms.MenuItem
    Friend WithEvents miAddVetCase As System.Windows.Forms.MenuItem
    Friend WithEvents miAddSession As System.Windows.Forms.MenuItem
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents lblOutbreak_Status As System.Windows.Forms.Label
    Friend WithEvents cbOutbreak_Status As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents gvCaseList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gcolCaseDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolCaseStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gbRelatedCaseReports As System.Windows.Forms.GroupBox
    Friend WithEvents lblOutbreakID As System.Windows.Forms.Label
    Friend WithEvents txtOutbreakID As DevExpress.XtraEditors.TextEdit

    '<System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OutbreakDetail))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim TagHelper1 As bv.common.win.TagHelper = New bv.common.win.TagHelper()
        Dim TagHelper2 As bv.common.win.TagHelper = New bv.common.win.TagHelper()
        Me.dtpEndDate = New DevExpress.XtraEditors.DateEdit()
        Me.gbRelatedCaseReports = New System.Windows.Forms.GroupBox()
        Me.btnAddCaseSession = New bv.winclient.Core.PopUpButton()
        Me.cmAddCaseSession = New System.Windows.Forms.ContextMenu()
        Me.miAddHumanCase = New System.Windows.Forms.MenuItem()
        Me.miAddVetCase = New System.Windows.Forms.MenuItem()
        Me.miAddSession = New System.Windows.Forms.MenuItem()
        Me.btnMarkAsPrimary = New DevExpress.XtraEditors.SimpleButton()
        Me.gcCaseList = New DevExpress.XtraGrid.GridControl()
        Me.gvCaseList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gcolCaseID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolCaseType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolDisease = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolCaseDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolSourceOfCaseDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolCaseStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolLocation = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolAddress = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolPatientName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.btnRemove = New DevExpress.XtraEditors.SimpleButton()
        Me.btnViewCaseDetails = New DevExpress.XtraEditors.SimpleButton()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.dtpStartDate = New DevExpress.XtraEditors.DateEdit()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.lblDisease = New System.Windows.Forms.Label()
        Me.cbDiagnosis = New DevExpress.XtraEditors.TreeListLookUpEdit()
        Me.cbOutbreak_Status = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblOutbreak_Status = New System.Windows.Forms.Label()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.cmReports = New System.Windows.Forms.ContextMenu()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.btnReport = New bv.winclient.Core.PopUpButton()
        Me.lblOutbreakID = New System.Windows.Forms.Label()
        Me.txtOutbreakID = New DevExpress.XtraEditors.TextEdit()
        Me.cbGeoLocation = New EIDSS.LocationLookup()
        Me.txtDescription = New DevExpress.XtraEditors.MemoEdit()
        Me.lbDescription = New System.Windows.Forms.Label()
        Me.tcOutbreak = New DevExpress.XtraTab.XtraTabControl()
        Me.tbGeneralInfo = New DevExpress.XtraTab.XtraTabPage()
        Me.txtPrimaryCase = New DevExpress.XtraEditors.ButtonEdit()
        Me.lbPrimaryCase = New System.Windows.Forms.Label()
        Me.tbNotes = New DevExpress.XtraTab.XtraTabPage()
        Me.btnDeleteNote = New DevExpress.XtraEditors.SimpleButton()
        Me.NotesGrid = New DevExpress.XtraGrid.GridControl()
        Me.NotesView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtNote = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.colDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.dtNoteDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.colPerson = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbNotePerson = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        CType(Me.dtpEndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpEndDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbRelatedCaseReports.SuspendLayout()
        CType(Me.gcCaseList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvCaseList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpStartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDiagnosis.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbOutbreak_Status.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOutbreakID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tcOutbreak, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcOutbreak.SuspendLayout()
        Me.tbGeneralInfo.SuspendLayout()
        CType(Me.txtPrimaryCase.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbNotes.SuspendLayout()
        CType(Me.NotesGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NotesView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtNoteDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtNoteDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbNotePerson, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(OutbreakDetail), resources)
        'Form Is Localizable: True
        '
        'dtpEndDate
        '
        resources.ApplyResources(Me.dtpEndDate, "dtpEndDate")
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Properties.Appearance.Options.UseFont = True
        Me.dtpEndDate.Properties.AppearanceDisabled.Options.UseFont = True
        Me.dtpEndDate.Properties.AppearanceDropDown.Options.UseFont = True
        Me.dtpEndDate.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.dtpEndDate.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = True
        Me.dtpEndDate.Properties.AppearanceDropDownHighlight.Options.UseFont = True
        Me.dtpEndDate.Properties.AppearanceFocused.Options.UseFont = True
        Me.dtpEndDate.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.dtpEndDate.Properties.AppearanceWeekNumber.Options.UseFont = True
        Me.dtpEndDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtpEndDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtpEndDate.Properties.CalendarTimeProperties.AutoHeight = CType(resources.GetObject("dtpEndDate.Properties.CalendarTimeProperties.AutoHeight"), Boolean)
        Me.dtpEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtpEndDate.Properties.CalendarTimeProperties.Mask.EditMask = resources.GetString("dtpEndDate.Properties.CalendarTimeProperties.Mask.EditMask")
        Me.dtpEndDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtpEndDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtpEndDate.Properties.CalendarTimeProperties.Mask.MaskType = CType(resources.GetObject("dtpEndDate.Properties.CalendarTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtpEndDate.Properties.CalendarTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("dtpEndDate.Properties.CalendarTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.dtpEndDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtpEndDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        '
        'gbRelatedCaseReports
        '
        resources.ApplyResources(Me.gbRelatedCaseReports, "gbRelatedCaseReports")
        Me.gbRelatedCaseReports.Controls.Add(Me.btnAddCaseSession)
        Me.gbRelatedCaseReports.Controls.Add(Me.btnMarkAsPrimary)
        Me.gbRelatedCaseReports.Controls.Add(Me.gcCaseList)
        Me.gbRelatedCaseReports.Controls.Add(Me.btnRemove)
        Me.gbRelatedCaseReports.Controls.Add(Me.btnViewCaseDetails)
        Me.gbRelatedCaseReports.Name = "gbRelatedCaseReports"
        Me.gbRelatedCaseReports.TabStop = False
        '
        'btnAddCaseSession
        '
        resources.ApplyResources(Me.btnAddCaseSession, "btnAddCaseSession")
        Me.btnAddCaseSession.ButtonType = bv.winclient.Core.PopUpButton.PopUpButtonStyles.Browse
        Me.btnAddCaseSession.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Show
        Me.btnAddCaseSession.ImageIndex = 2
        Me.btnAddCaseSession.Name = "btnAddCaseSession"
        Me.btnAddCaseSession.PopUpMenu = Me.cmAddCaseSession
        '
        'cmAddCaseSession
        '
        Me.cmAddCaseSession.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miAddHumanCase, Me.miAddVetCase, Me.miAddSession})
        '
        'miAddHumanCase
        '
        Me.miAddHumanCase.Index = 0
        resources.ApplyResources(Me.miAddHumanCase, "miAddHumanCase")
        '
        'miAddVetCase
        '
        Me.miAddVetCase.Index = 1
        resources.ApplyResources(Me.miAddVetCase, "miAddVetCase")
        '
        'miAddSession
        '
        Me.miAddSession.Index = 2
        resources.ApplyResources(Me.miAddSession, "miAddSession")
        '
        'btnMarkAsPrimary
        '
        resources.ApplyResources(Me.btnMarkAsPrimary, "btnMarkAsPrimary")
        Me.btnMarkAsPrimary.Appearance.Options.UseTextOptions = True
        Me.btnMarkAsPrimary.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.btnMarkAsPrimary.Name = "btnMarkAsPrimary"
        '
        'gcCaseList
        '
        resources.ApplyResources(Me.gcCaseList, "gcCaseList")
        Me.gcCaseList.Cursor = System.Windows.Forms.Cursors.Default
        Me.gcCaseList.EmbeddedNavigator.Anchor = CType(resources.GetObject("gcCaseList.EmbeddedNavigator.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.gcCaseList.EmbeddedNavigator.BackgroundImageLayout = CType(resources.GetObject("gcCaseList.EmbeddedNavigator.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.gcCaseList.EmbeddedNavigator.ImeMode = CType(resources.GetObject("gcCaseList.EmbeddedNavigator.ImeMode"), System.Windows.Forms.ImeMode)
        Me.gcCaseList.EmbeddedNavigator.TextLocation = CType(resources.GetObject("gcCaseList.EmbeddedNavigator.TextLocation"), DevExpress.XtraEditors.NavigatorButtonsTextLocation)
        Me.gcCaseList.EmbeddedNavigator.ToolTipIconType = CType(resources.GetObject("gcCaseList.EmbeddedNavigator.ToolTipIconType"), DevExpress.Utils.ToolTipIconType)
        GridLevelNode1.RelationName = "Level1"
        Me.gcCaseList.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.gcCaseList.MainView = Me.gvCaseList
        Me.gcCaseList.Name = "gcCaseList"
        Me.gcCaseList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvCaseList})
        '
        'gvCaseList
        '
        Me.gvCaseList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gcolCaseID, Me.gcolCaseType, Me.gcolDisease, Me.gcolCaseDate, Me.gcolSourceOfCaseDate, Me.gcolCaseStatus, Me.gcolLocation, Me.gcolAddress, Me.gcolPatientName})
        Me.gvCaseList.GridControl = Me.gcCaseList
        Me.gvCaseList.Name = "gvCaseList"
        Me.gvCaseList.OptionsBehavior.Editable = False
        Me.gvCaseList.OptionsSelection.MultiSelect = True
        Me.gvCaseList.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gvCaseList.OptionsView.ShowFooter = True
        Me.gvCaseList.OptionsView.ShowGroupPanel = False
        '
        'gcolCaseID
        '
        Me.gcolCaseID.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolCaseID, "gcolCaseID")
        Me.gcolCaseID.FieldName = "strCaseID"
        Me.gcolCaseID.Name = "gcolCaseID"
        Me.gcolCaseID.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(CType(resources.GetObject("gcolCaseID.Summary"), DevExpress.Data.SummaryItemType), resources.GetString("gcolCaseID.Summary1"), resources.GetString("gcolCaseID.Summary2"))})
        '
        'gcolCaseType
        '
        resources.ApplyResources(Me.gcolCaseType, "gcolCaseType")
        Me.gcolCaseType.FieldName = "idfsCaseType"
        Me.gcolCaseType.Name = "gcolCaseType"
        '
        'gcolDisease
        '
        Me.gcolDisease.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolDisease, "gcolDisease")
        Me.gcolDisease.FieldName = "strDiagnosis"
        Me.gcolDisease.Name = "gcolDisease"
        '
        'gcolCaseDate
        '
        Me.gcolCaseDate.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolCaseDate, "gcolCaseDate")
        Me.gcolCaseDate.FieldName = "datEnteredDate"
        Me.gcolCaseDate.Name = "gcolCaseDate"
        '
        'gcolSourceOfCaseDate
        '
        resources.ApplyResources(Me.gcolSourceOfCaseDate, "gcolSourceOfCaseDate")
        Me.gcolSourceOfCaseDate.FieldName = "strSourceOfCaseDate"
        Me.gcolSourceOfCaseDate.Name = "gcolSourceOfCaseDate"
        Me.gcolSourceOfCaseDate.OptionsColumn.ReadOnly = True
        Me.gcolSourceOfCaseDate.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        '
        'gcolCaseStatus
        '
        Me.gcolCaseStatus.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolCaseStatus, "gcolCaseStatus")
        Me.gcolCaseStatus.FieldName = "strCaseStatus"
        Me.gcolCaseStatus.Name = "gcolCaseStatus"
        Me.gcolCaseStatus.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(CType(resources.GetObject("gcolCaseStatus.Summary"), DevExpress.Data.SummaryItemType), resources.GetString("gcolCaseStatus.Summary1"), resources.GetString("gcolCaseStatus.Summary2"))})
        '
        'gcolLocation
        '
        Me.gcolLocation.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolLocation, "gcolLocation")
        Me.gcolLocation.FieldName = "strGeoLocation"
        Me.gcolLocation.Name = "gcolLocation"
        '
        'gcolAddress
        '
        resources.ApplyResources(Me.gcolAddress, "gcolAddress")
        Me.gcolAddress.FieldName = "strAddress"
        Me.gcolAddress.Name = "gcolAddress"
        '
        'gcolPatientName
        '
        resources.ApplyResources(Me.gcolPatientName, "gcolPatientName")
        Me.gcolPatientName.FieldName = "strPatientName"
        Me.gcolPatientName.Name = "gcolPatientName"
        '
        'btnRemove
        '
        resources.ApplyResources(Me.btnRemove, "btnRemove")
        Me.btnRemove.AutoWidthInLayoutControl = True
        Me.btnRemove.Image = Global.EIDSS.My.Resources.Resources.Delete_Remove
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.TabStop = False
        '
        'btnViewCaseDetails
        '
        resources.ApplyResources(Me.btnViewCaseDetails, "btnViewCaseDetails")
        Me.btnViewCaseDetails.Image = Global.EIDSS.My.Resources.Resources.View1
        Me.btnViewCaseDetails.Name = "btnViewCaseDetails"
        Me.btnViewCaseDetails.TabStop = False
        '
        'lblEndDate
        '
        resources.ApplyResources(Me.lblEndDate, "lblEndDate")
        Me.lblEndDate.Name = "lblEndDate"
        '
        'dtpStartDate
        '
        resources.ApplyResources(Me.dtpStartDate, "dtpStartDate")
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Properties.Appearance.Options.UseFont = True
        Me.dtpStartDate.Properties.AppearanceDisabled.Options.UseFont = True
        Me.dtpStartDate.Properties.AppearanceDropDown.Options.UseFont = True
        Me.dtpStartDate.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.dtpStartDate.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = True
        Me.dtpStartDate.Properties.AppearanceDropDownHighlight.Options.UseFont = True
        Me.dtpStartDate.Properties.AppearanceFocused.Options.UseFont = True
        Me.dtpStartDate.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.dtpStartDate.Properties.AppearanceWeekNumber.Options.UseFont = True
        Me.dtpStartDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtpStartDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtpStartDate.Properties.CalendarTimeProperties.AutoHeight = CType(resources.GetObject("dtpStartDate.Properties.CalendarTimeProperties.AutoHeight"), Boolean)
        Me.dtpStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtpStartDate.Properties.CalendarTimeProperties.Mask.EditMask = resources.GetString("dtpStartDate.Properties.CalendarTimeProperties.Mask.EditMask")
        Me.dtpStartDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtpStartDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtpStartDate.Properties.CalendarTimeProperties.Mask.MaskType = CType(resources.GetObject("dtpStartDate.Properties.CalendarTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtpStartDate.Properties.CalendarTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("dtpStartDate.Properties.CalendarTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.dtpStartDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtpStartDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        '
        'lblLocation
        '
        resources.ApplyResources(Me.lblLocation, "lblLocation")
        Me.lblLocation.Name = "lblLocation"
        '
        'lblDisease
        '
        resources.ApplyResources(Me.lblDisease, "lblDisease")
        Me.lblDisease.Name = "lblDisease"
        '
        'cbDiagnosis
        '
        resources.ApplyResources(Me.cbDiagnosis, "cbDiagnosis")
        Me.cbDiagnosis.Name = "cbDiagnosis"
        Me.cbDiagnosis.Properties.AutoExpandAllNodes = False
        Me.cbDiagnosis.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDiagnosis.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbDiagnosis.Properties.Buttons1"), CType(resources.GetObject("cbDiagnosis.Properties.Buttons2"), Integer), CType(resources.GetObject("cbDiagnosis.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbDiagnosis.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbDiagnosis.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbDiagnosis.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbDiagnosis.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, resources.GetString("cbDiagnosis.Properties.Buttons8"), CType(resources.GetObject("cbDiagnosis.Properties.Buttons9"), Object), CType(resources.GetObject("cbDiagnosis.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbDiagnosis.Properties.Buttons11"), Boolean))})
        Me.cbDiagnosis.Tag = "{M}"
        '
        'cbOutbreak_Status
        '
        resources.ApplyResources(Me.cbOutbreak_Status, "cbOutbreak_Status")
        Me.cbOutbreak_Status.Name = "cbOutbreak_Status"
        Me.cbOutbreak_Status.Properties.AutoHeight = CType(resources.GetObject("cbOutbreak_Status.Properties.AutoHeight"), Boolean)
        Me.cbOutbreak_Status.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbOutbreak_Status.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbOutbreak_Status.Properties.NullText = resources.GetString("cbOutbreak_Status.Properties.NullText")
        '
        'lblOutbreak_Status
        '
        resources.ApplyResources(Me.lblOutbreak_Status, "lblOutbreak_Status")
        Me.lblOutbreak_Status.Name = "lblOutbreak_Status"
        '
        'lblStartDate
        '
        resources.ApplyResources(Me.lblStartDate, "lblStartDate")
        Me.lblStartDate.Name = "lblStartDate"
        '
        'cmReports
        '
        Me.cmReports.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem3})
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 0
        resources.ApplyResources(Me.MenuItem3, "MenuItem3")
        '
        'btnReport
        '
        resources.ApplyResources(Me.btnReport, "btnReport")
        Me.btnReport.ButtonType = bv.winclient.Core.PopUpButton.PopUpButtonStyles.Reports
        Me.btnReport.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Show
        Me.btnReport.ImageIndex = 0
        Me.btnReport.Name = "btnReport"
        Me.btnReport.PopUpMenu = Me.cmReports
        Me.btnReport.TabStop = False
        Me.btnReport.Tag = "{Immovable}{AlwaysEditable}"
        '
        'lblOutbreakID
        '
        resources.ApplyResources(Me.lblOutbreakID, "lblOutbreakID")
        Me.lblOutbreakID.Name = "lblOutbreakID"
        '
        'txtOutbreakID
        '
        resources.ApplyResources(Me.txtOutbreakID, "txtOutbreakID")
        Me.txtOutbreakID.Name = "txtOutbreakID"
        Me.txtOutbreakID.Properties.AutoHeight = CType(resources.GetObject("txtOutbreakID.Properties.AutoHeight"), Boolean)
        Me.txtOutbreakID.Properties.Mask.EditMask = resources.GetString("txtOutbreakID.Properties.Mask.EditMask")
        Me.txtOutbreakID.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtOutbreakID.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtOutbreakID.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtOutbreakID.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtOutbreakID.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtOutbreakID.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtOutbreakID.TabStop = False
        Me.txtOutbreakID.Tag = "[en]"
        '
        'cbGeoLocation
        '
        resources.ApplyResources(Me.cbGeoLocation, "cbGeoLocation")
        Me.cbGeoLocation.Appearance.BackColor = CType(resources.GetObject("cbGeoLocation.Appearance.BackColor"), System.Drawing.Color)
        Me.cbGeoLocation.Appearance.Options.UseBackColor = True
        Me.cbGeoLocation.FormID = Nothing
        Me.cbGeoLocation.HelpTopicID = Nothing
        Me.cbGeoLocation.KeyFieldName = Nothing
        Me.cbGeoLocation.MultiSelect = False
        Me.cbGeoLocation.Name = "cbGeoLocation"
        Me.cbGeoLocation.ObjectName = Nothing
        Me.cbGeoLocation.PopupEditMinWidth = 427
        Me.cbGeoLocation.TableName = Nothing
        TagHelper1.Binder = Nothing
        TagHelper1.ClonedView = Nothing
        TagHelper1.ControlLanguage = ""
        TagHelper1.Datasource = Nothing
        TagHelper1.HACodeName = Nothing
        TagHelper1.IntTag = -1
        TagHelper1.IsBarcode = False
        TagHelper1.IsKeyField = False
        TagHelper1.IsMandatory = False
        TagHelper1.IsReadOnly = False
        TagHelper1.LookupTableName = Nothing
        TagHelper1.MandatoryFieldName = Nothing
        TagHelper1.QueryPopupHandler = Nothing
        TagHelper1.StringTag = ""
        TagHelper2.Binder = Nothing
        TagHelper2.ClonedView = Nothing
        TagHelper2.ControlLanguage = ""
        TagHelper2.Datasource = Nothing
        TagHelper2.HACodeName = Nothing
        TagHelper2.IntTag = -1
        TagHelper2.IsBarcode = False
        TagHelper2.IsKeyField = False
        TagHelper2.IsMandatory = False
        TagHelper2.IsReadOnly = False
        TagHelper2.LookupTableName = Nothing
        TagHelper2.MandatoryFieldName = Nothing
        TagHelper2.QueryPopupHandler = Nothing
        TagHelper2.StringTag = ""
        TagHelper2.Tag = Nothing
        TagHelper1.Tag = TagHelper2
        Me.cbGeoLocation.Tag = TagHelper1
        '
        'txtDescription
        '
        resources.ApplyResources(Me.txtDescription, "txtDescription")
        Me.txtDescription.Name = "txtDescription"
        '
        'lbDescription
        '
        resources.ApplyResources(Me.lbDescription, "lbDescription")
        Me.lbDescription.Name = "lbDescription"
        '
        'tcOutbreak
        '
        resources.ApplyResources(Me.tcOutbreak, "tcOutbreak")
        Me.tcOutbreak.Name = "tcOutbreak"
        Me.tcOutbreak.SelectedTabPage = Me.tbGeneralInfo
        Me.tcOutbreak.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tbGeneralInfo, Me.tbNotes})
        '
        'tbGeneralInfo
        '
        Me.tbGeneralInfo.Controls.Add(Me.txtPrimaryCase)
        Me.tbGeneralInfo.Controls.Add(Me.txtDescription)
        Me.tbGeneralInfo.Controls.Add(Me.lbDescription)
        Me.tbGeneralInfo.Controls.Add(Me.cbGeoLocation)
        Me.tbGeneralInfo.Controls.Add(Me.txtOutbreakID)
        Me.tbGeneralInfo.Controls.Add(Me.dtpStartDate)
        Me.tbGeneralInfo.Controls.Add(Me.lblOutbreakID)
        Me.tbGeneralInfo.Controls.Add(Me.gbRelatedCaseReports)
        Me.tbGeneralInfo.Controls.Add(Me.lbPrimaryCase)
        Me.tbGeneralInfo.Controls.Add(Me.lblLocation)
        Me.tbGeneralInfo.Controls.Add(Me.cbDiagnosis)
        Me.tbGeneralInfo.Controls.Add(Me.cbOutbreak_Status)
        Me.tbGeneralInfo.Controls.Add(Me.dtpEndDate)
        Me.tbGeneralInfo.Controls.Add(Me.lblOutbreak_Status)
        Me.tbGeneralInfo.Controls.Add(Me.lblStartDate)
        Me.tbGeneralInfo.Controls.Add(Me.lblEndDate)
        Me.tbGeneralInfo.Controls.Add(Me.lblDisease)
        Me.tbGeneralInfo.Name = "tbGeneralInfo"
        resources.ApplyResources(Me.tbGeneralInfo, "tbGeneralInfo")
        '
        'txtPrimaryCase
        '
        resources.ApplyResources(Me.txtPrimaryCase, "txtPrimaryCase")
        Me.txtPrimaryCase.Name = "txtPrimaryCase"
        Me.txtPrimaryCase.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtPrimaryCase.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtPrimaryCase.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'lbPrimaryCase
        '
        resources.ApplyResources(Me.lbPrimaryCase, "lbPrimaryCase")
        Me.lbPrimaryCase.Name = "lbPrimaryCase"
        '
        'tbNotes
        '
        Me.tbNotes.Controls.Add(Me.btnDeleteNote)
        Me.tbNotes.Controls.Add(Me.NotesGrid)
        Me.tbNotes.Name = "tbNotes"
        resources.ApplyResources(Me.tbNotes, "tbNotes")
        '
        'btnDeleteNote
        '
        resources.ApplyResources(Me.btnDeleteNote, "btnDeleteNote")
        Me.btnDeleteNote.Image = Global.EIDSS.My.Resources.Resources.Delete_Remove
        Me.btnDeleteNote.Name = "btnDeleteNote"
        Me.btnDeleteNote.TabStop = False
        '
        'NotesGrid
        '
        resources.ApplyResources(Me.NotesGrid, "NotesGrid")
        Me.NotesGrid.MainView = Me.NotesView
        Me.NotesGrid.Name = "NotesGrid"
        Me.NotesGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.txtNote, Me.dtNoteDate, Me.cbNotePerson})
        Me.NotesGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.NotesView})
        '
        'NotesView
        '
        Me.NotesView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colNote, Me.colDate, Me.colPerson})
        Me.NotesView.GridControl = Me.NotesGrid
        Me.NotesView.Name = "NotesView"
        Me.NotesView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.NotesView.OptionsView.ShowGroupPanel = False
        '
        'colNote
        '
        resources.ApplyResources(Me.colNote, "colNote")
        Me.colNote.ColumnEdit = Me.txtNote
        Me.colNote.FieldName = "strNote"
        Me.colNote.Name = "colNote"
        '
        'txtNote
        '
        Me.txtNote.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtNote.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtNote.MaxLength = 1999
        Me.txtNote.Name = "txtNote"
        Me.txtNote.ShowIcon = False
        '
        'colDate
        '
        resources.ApplyResources(Me.colDate, "colDate")
        Me.colDate.ColumnEdit = Me.dtNoteDate
        Me.colDate.FieldName = "datNoteDate"
        Me.colDate.Name = "colDate"
        Me.colDate.OptionsColumn.AllowEdit = False
        '
        'dtNoteDate
        '
        resources.ApplyResources(Me.dtNoteDate, "dtNoteDate")
        Me.dtNoteDate.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtNoteDate.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtNoteDate.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtNoteDate.Name = "dtNoteDate"
        '
        'colPerson
        '
        resources.ApplyResources(Me.colPerson, "colPerson")
        Me.colPerson.ColumnEdit = Me.cbNotePerson
        Me.colPerson.FieldName = "idfPerson"
        Me.colPerson.Name = "colPerson"
        '
        'cbNotePerson
        '
        resources.ApplyResources(Me.cbNotePerson, "cbNotePerson")
        Me.cbNotePerson.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbNotePerson.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbNotePerson.Name = "cbNotePerson"
        '
        'OutbreakDetail
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.tcOutbreak)
        Me.Controls.Add(Me.btnReport)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "C11"
        Me.HelpTopicID = "OB_C11"
        Me.KeyFieldName = "idfOutbreak"
        Me.LeftIcon = CType(resources.GetObject("$this.LeftIcon"), System.Drawing.Image)
        Me.Name = "OutbreakDetail"
        Me.ObjectName = "Outbreak"
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "Outbreak"
        Me.Controls.SetChildIndex(Me.btnReport, 0)
        Me.Controls.SetChildIndex(Me.tcOutbreak, 0)
        CType(Me.dtpEndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpEndDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbRelatedCaseReports.ResumeLayout(False)
        CType(Me.gcCaseList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvCaseList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpStartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDiagnosis.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbOutbreak_Status.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOutbreakID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tcOutbreak, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tcOutbreak.ResumeLayout(False)
        Me.tbGeneralInfo.ResumeLayout(False)
        CType(Me.txtPrimaryCase.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbNotes.ResumeLayout(False)
        CType(Me.NotesGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NotesView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtNoteDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtNoteDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbNotePerson, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub


#End Region

#Region "Main form interface"

    Public Shared Sub Register(ByVal ParentControl As System.Windows.Forms.Control)
        If EIDSS.model.Core.EidssSiteContext.Instance.IsReadOnlySite Then
            Return
        End If
        Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Create, "MenuNewOutbreak", 215)
        ma.ShowInToolbar = False
        ma.SmallIconIndex = MenuIconsSmall.Outbreak
        ma.Name = "btnNewOutbreak"
        ma.Group = CInt(MenuGroup.CreateCase)
        ma.SelectPermission = PermissionHelper.InsertPermission(EIDSSPermissionObject.Outbreak)
        'Toolbar menu
        ma = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals, "ToolbarNewOutbreak", 100150)
        ma.ShowInToolbar = True
        ma.ShowInMenu = False
        ma.BigIconIndex = MenuIcons.NewOutBreak
        ma.Name = "btnNewOutbreak1"
        ma.Group = CInt(MenuGroup.ToolbarCreate)
        ma.SelectPermission = PermissionHelper.InsertPermission(EIDSSPermissionObject.Outbreak)
    End Sub

    Public Shared Sub ShowMe()
        BaseFormManager.ShowNormal(New OutbreakDetail, Nothing)
        'BaseForm.ShowModal(New VetCaseLiveStockDetail)
    End Sub
#End Region


#Region "Business Rules"

    ' To allow clear values withot cycling calls
    'Public StopBR As Boolean = False

    'Public Function MinMax_Err(ByVal MinD As Date, ByVal MaxD As Date, ByVal MinDName As String, ByVal MaxDName As String, ByVal AllowBeEqual As Boolean) As Boolean
    '    Dim res As Boolean = False
    '    If Not (MinD = Nothing OrElse MaxD = Nothing) Then
    '        Dim MinMax As MinMaxDate = New MinMaxDate(MinD, MaxD, MinDName, MaxDName, AllowBeEqual)
    '        If Not MinMax.MinMaxOk Then
    '            MinMax.CheckMinMax()
    '            res = True
    '        End If
    '    End If
    '    Return res
    'End Function

    'Public Sub Check_BR(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim OkToCancel As Boolean = False
    '    If (Not StopBR) Then
    '        Dim StartD As Date = Nothing
    '        If Not Utils.IsEmpty(dtpStartDate.EditValue) Then StartD = dtpStartDate.DateTime.Date
    '        Dim EndD As Date = Nothing
    '        If Not Utils.IsEmpty(dtpEndDate.EditValue) Then EndD = dtpEndDate.DateTime.Date

    '        OkToCancel = MinMax_Err(StartD, EndD, "Start date", "End date", False)
    '    End If
    '    If OkToCancel Then CType(sender, DevExpress.XtraEditors.DateEdit).Select()
    'End Sub

    'Public Sub Check_BR(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.Enter Then
    '        Dim OkToCancel As Boolean = False
    '        If (Not StopBR) Then
    '            Dim StartD As Date = Nothing
    '            If Not Utils.IsEmpty(dtpStartDate.EditValue) Then StartD = dtpStartDate.DateTime.Date
    '            Dim EndD As Date = Nothing
    '            If Not Utils.IsEmpty(dtpEndDate.EditValue) Then EndD = dtpEndDate.DateTime.Date

    '            OkToCancel = MinMax_Err(StartD, EndD, "Start date", "End date", False)
    '        End If
    '        If OkToCancel Then CType(sender, DevExpress.XtraEditors.DateEdit).Select()
    '    End If
    'End Sub

#End Region
    'Public Overrides Function ValidateData() As Boolean
    '    Return MyBase.ValidateData() 'lower is an old code

    '    If Not baseDataSet.Tables("Outbreak").Rows(0)("datStartDate") Is DBNull.Value AndAlso _
    '        Not baseDataSet.Tables("Outbreak").Rows(0)("datFinishDate") Is DBNull.Value Then
    '        Dim StartDate As Date = CDate(baseDataSet.Tables("Outbreak").Rows(0)("datStartDate"))
    '        Dim FinishDate As Date = CDate(baseDataSet.Tables("Outbreak").Rows(0)("datFinishDate"))
    '        If StartDate.CompareTo(FinishDate) >= 0 Then
    '            win.ErrorForm.ShowWarningDirect(EidssMessages.Get("Start date_End date"))
    '            Return False
    '        End If
    '    End If
    '    Return MyBase.ValidateData()
    'End Function

    Private CanAddViewRemove As Boolean = True
    Private m_DiagnosisView As DataView
    Protected Overrides Sub DefineBinding()
        'RemoveHandler dtpStartDate.Leave, AddressOf Me.Check_BR
        'RemoveHandler dtpEndDate.Leave, AddressOf Me.Check_BR
        'RemoveHandler dtpStartDate.KeyDown, AddressOf Me.Check_BR
        'RemoveHandler dtpEndDate.KeyDown, AddressOf Me.Check_BR

        'Outbreak binding
        Core.LookupBinder.BindTextEdit(txtOutbreakID, baseDataSet, "Outbreak.strOutbreakID")
        Core.LookupBinder.BindTextEdit(txtDescription, baseDataSet, "Outbreak.strDescription")

        Core.LookupBinder.BindDateEdit(dtpStartDate, baseDataSet, "Outbreak.datStartDate")
        Core.LookupBinder.BindDateEdit(dtpEndDate, baseDataSet, "Outbreak.datFinishDate")

        m_DiagnosisView = Core.LookupBinder.BindDiagnosisTreeLookup(cbDiagnosis, baseDataSet, "Outbreak.idfsDiagnosisOrDiagnosisGroup")
        Core.LookupBinder.BindBaseLookup(cbOutbreak_Status, baseDataSet, "Outbreak.idfsOutbreakStatus", bv.common.db.BaseReferenceType.rftOutbreakStatus, False)
        cbGeoLocation.Bind(baseDataSet, "Outbreak.idfGeoLocation")

        gcCaseList.DataSource = baseDataSet
        gcCaseList.DataMember = "CaseList"

        NotesGrid.DataSource = baseDataSet
        NotesGrid.DataMember = "Notes"
        Core.LookupBinder.BindPersonRepositoryLookup(cbNotePerson)
        Core.LookupBinder.BindTextEdit(txtPrimaryCase, baseDataSet, "Outbreak.strPrimaryCase")


        'StopBR = False


        'AddHandler dtpStartDate.Leave, AddressOf Me.Check_BR
        'AddHandler dtpEndDate.Leave, AddressOf Me.Check_BR

        If (Not StartUpParameters Is Nothing) AndAlso (StartUpParameters.ContainsKey("CanAddViewRemove")) AndAlso (TypeOf (StartUpParameters("CanAddViewRemove")) Is Boolean) Then
            CanAddViewRemove = CBool(StartUpParameters("CanAddViewRemove"))
        End If
        miAddHumanCase.Enabled = CanAddViewRemove AndAlso New StandardAccessPermissions(EIDSSPermissionObject.HumanCase).CanSelect
        miAddVetCase.Enabled = CanAddViewRemove AndAlso New StandardAccessPermissions(EIDSSPermissionObject.VetCase).CanSelect
        miAddSession.Enabled = CanAddViewRemove AndAlso New StandardAccessPermissions(EIDSSPermissionObject.VsSession).CanSelect
        btnAddCaseSession.Enabled = CanAddViewRemove AndAlso New StandardAccessPermissions(EIDSSPermissionObject.VsSession).CanSelect
        btnRemove.Enabled = CanAddViewRemove
        btnDeleteNote.Enabled = CanAddViewRemove
        btnViewCaseDetails.Enabled = CanAddViewRemove
        'gcCaseList.Enabled = CanAddViewRemove
        If (Not StartUpParameters Is Nothing) AndAlso (StartUpParameters.ContainsKey("ReadOnly")) AndAlso (TypeOf (StartUpParameters("ReadOnly")) Is Boolean) AndAlso (Me.ReadOnly <> CBool(StartUpParameters("ReadOnly"))) Then
            Me.ReadOnly = CBool(StartUpParameters("ReadOnly"))
        End If

    End Sub

#Region "Add Case/Session"
    Private Function CreateListPanel(listFormName As String, Optional StaticFilterTip As String = Nothing) As IBaseListPanel
        Dim listPanel As IBaseListPanel = CType(ClassLoader.LoadClass(listFormName), IBaseListPanel)
        Dim initialFilter As New FilterParams
        If Not Utils.IsEmpty(cbDiagnosis.EditValue) Then
            Dim isGroup As Object = Core.LookupBinder.getValue(m_DiagnosisView, CLng(cbDiagnosis.EditValue), "idfsDiagnosisOrDiagnosisGroup", "blnGroup")
            If Not Utils.IsEmpty(isGroup) Then
                If CInt(isGroup) = 0 Then
                    Dim foundGroup As Object = Core.LookupBinder.getValue(m_DiagnosisView, CLng(cbDiagnosis.EditValue), "idfsDiagnosisOrDiagnosisGroup", "idfsDiagnosisGroup")
                    If CLng(foundGroup) = 0 Then
                        initialFilter.Add("idfsDiagnosis", "=", cbDiagnosis.EditValue)
                    Else
                        initialFilter.Add("idfsDiagnosisGroup", "=", CLng(foundGroup))
                    End If
                Else
                    initialFilter.Add("idfsDiagnosisGroup", "=", CLng(cbDiagnosis.EditValue))
                End If
            End If
        End If
        listPanel.InitialSearchFilter = initialFilter
        If (Not String.IsNullOrEmpty(StaticFilterTip)) Then
            Dim staticFilter As New FilterParams
            staticFilter.Add("bWithDiagnosisOnly", "=", 1)
            ReflectionHelper.SetProperty(listPanel, "StaticFilter", staticFilter)
            If listPanel.StartUpParameters Is Nothing Then listPanel.StartUpParameters = New Dictionary(Of String, Object)
            listPanel.StartUpParameters.Add("TipText", EidssMessages.Get(StaticFilterTip))
        End If
        Return listPanel
    End Function
    Private Sub btnHumanAddCase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miAddHumanCase.Click
        Dim caseForm As IBaseListPanel = CreateListPanel("HumanCaseListPanel")

        'Dim caseForm As IBaseListPanel = CType(ClassLoader.LoadClass("HumanCaseListPanel"), IBaseListPanel)
        'Dim filter As New FilterParams
        'If Not Utils.IsEmpty(cbDiagnosis.EditValue) Then
        '    Dim isGroup As Object = Core.LookupBinder.getValue(m_DiagnosisView, CLng(cbDiagnosis.EditValue), "idfsDiagnosisOrDiagnosisGroup", "blnGroup")
        '    If Not Utils.IsEmpty(isGroup) Then
        '        If CInt(isGroup) = 0 Then
        '            Dim foundGroup As Object = Core.LookupBinder.getValue(m_DiagnosisView, CLng(cbDiagnosis.EditValue), "idfsDiagnosisOrDiagnosisGroup", "idfsDiagnosisGroup")
        '            If CLng(foundGroup) = 0 Then
        '                filter.Add("idfsDiagnosis", "=", cbDiagnosis.EditValue)
        '            Else
        '                filter.Add("idfsDiagnosisGroup", "=", CLng(foundGroup))
        '            End If
        '        Else
        '            filter.Add("idfsDiagnosisGroup", "=", CLng(cbDiagnosis.EditValue))
        '        End If
        '    End If
        'End If
        'ReflectionHelper.SetProperty(caseForm, "StaticFilter", filter)


        Dim humanCases As IList(Of IObject) = BaseFormManager.ShowForMultiSelection(caseForm, FindForm, , 1024, 800)
        If Not humanCases Is Nothing Then
            For Each humanCase As IObject In humanCases
                If OutbreakDbService.CanCaseBeAddedToOutbreak(humanCase.GetValue("idfCase")) = True Then
                    If Utils.IsEmpty(cbDiagnosis.EditValue) OrElse CLng(cbDiagnosis.EditValue) < 0 OrElse CheckCaseDiagnosesConnection(cbDiagnosis.EditValue, humanCase.GetValue("idfCase"), humanCase.GetValue("strCaseID")) Then
                        AddHumanCase(humanCase, OutbreakDbService.ID)
                    End If
                Else
                    MessageForm.Show(EidssMessages.Get("mbCannotAddCaseToOutbreak", "It is impossible to add this case because it is marked as not related to any outbreak."))
                End If
            Next
        End If
    End Sub
    Private Sub btnAddVetCase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miAddVetCase.Click
        Dim caseForm As IBaseListPanel = CreateListPanel("VetCaseListPanel", "msgCasesWithDiagnosis")
        'Dim caseForm As IBaseListPanel = CType(ClassLoader.LoadClass("VetCaseListPanel"), IBaseListPanel)
        'Dim filter As New FilterParams
        'If Not Utils.IsEmpty(cbDiagnosis.EditValue) AndAlso CLng(cbDiagnosis.EditValue) > 0 Then
        '    Dim isGroup As Object = Core.LookupBinder.getValue(m_DiagnosisView, CLng(cbDiagnosis.EditValue), "idfsDiagnosisOrDiagnosisGroup", "blnGroup")
        '    If CBool(isGroup) Then
        '        filter.Add("idfsDiagnosisGroup", "=", cbDiagnosis.EditValue)
        '    Else
        '        Dim foundGroup As Object = Core.LookupBinder.getValue(m_DiagnosisView, CLng(cbDiagnosis.EditValue), "idfsDiagnosisOrDiagnosisGroup", "idfsDiagnosisGroup")
        '        If CLng(foundGroup) = 0 Then
        '            filter.Add("idfsDiagnosis", "=", cbDiagnosis.EditValue)
        '        Else
        '            filter.Add("idfsDiagnosisGroup", "=", foundGroup)
        '        End If
        '    End If
        'Else
        '    filter.Add("(idfsDiagnosisGroup is not null or idfsDiagnosis is not null)", "", Nothing)
        'End If
        'ReflectionHelper.SetProperty(caseForm, "StaticFilter", filter)

        'If caseForm.StartUpParameters Is Nothing Then caseForm.StartUpParameters = New Dictionary(Of String, Object)
        'caseForm.StartUpParameters.Add("TipText", EidssMessages.Get("msgCasesWithDiagnosis"))
        Dim vetCases As IList(Of IObject) = BaseFormManager.ShowForMultiSelection(caseForm, FindForm, , 1024, 800)
        If Not vetCases Is Nothing AndAlso vetCases.Count > 0 Then
            For Each vetCase As IObject In vetCases
                If Utils.IsEmpty(cbDiagnosis.EditValue) OrElse CLng(cbDiagnosis.EditValue) < 0 OrElse CheckCaseDiagnosesConnection(cbDiagnosis.EditValue, vetCase.GetValue("idfCase"), vetCase.GetValue("strCaseID")) Then
                    AddVetCase(vetCase, OutbreakDbService.ID)
                End If
            Next
        End If
    End Sub
    Private Sub btnAddSession_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miAddSession.Click
        Dim caseForm As IBaseListPanel = CreateListPanel("VsSessionListPanel", "msgSessionsWithDiagnosis")
        'Dim caseForm As IBaseListPanel = CType(ClassLoader.LoadClass("VsSessionListPanel"), IBaseListPanel)
        'Dim filter As New FilterParams
        'If Not Utils.IsEmpty(cbDiagnosis.EditValue) Then
        '    Dim isGroup As Object = Core.LookupBinder.getValue(m_DiagnosisView, CLng(cbDiagnosis.EditValue), "idfsDiagnosisOrDiagnosisGroup", "blnGroup")
        '    If Not Utils.IsEmpty(isGroup) Then
        '        If CInt(isGroup) = 0 Then
        '            Dim foundGroup As Object = Core.LookupBinder.getValue(m_DiagnosisView, CLng(cbDiagnosis.EditValue), "idfsDiagnosisOrDiagnosisGroup", "idfsDiagnosisGroup")
        '            If CLng(foundGroup) = 0 Then
        '                filter.Add("idfsDiagnosis", "=", cbDiagnosis.EditValue)
        '            Else
        '                filter.Add("idfsDiagnosisGroup", "=", foundGroup)
        '            End If
        '        Else
        '            filter.Add("idfsDiagnosisGroup", "=", cbDiagnosis.EditValue)
        '        End If
        '    End If
        'Else
        '    filter.Add("(idfsDiagnosisGroup is not null or idfsDiagnosis is not null)", "", Nothing)
        'End If
        'ReflectionHelper.SetProperty(caseForm, "StaticFilter", filter)

        'If caseForm.StartUpParameters Is Nothing Then caseForm.StartUpParameters = New Dictionary(Of String, Object)
        'caseForm.StartUpParameters.Add("TipText", EidssMessages.Get("msgSessionsWithDiagnosis"))
        Dim sessions As IList(Of IObject) = BaseFormManager.ShowForMultiSelection(caseForm, FindForm, , 1024, 800)
        If Not sessions Is Nothing AndAlso sessions.Count > 0 Then
            For Each session As IObject In sessions
                If Utils.IsEmpty(cbDiagnosis.EditValue) OrElse CLng(cbDiagnosis.EditValue) < 0 OrElse CheckCaseDiagnosesConnection(cbDiagnosis.EditValue, session.GetValue("idfVectorSurveillanceSession"), session.GetValue("strSessionID")) Then
                    AddSession(session, OutbreakDbService.ID)
                End If
            Next
        End If
    End Sub

    Private Function CheckCaseDiagnosesConnection(ByVal idfsDiagnosisOrDiagnosisGroup As Object, ByVal caseOrSessionId As Object, ByVal caseOrSession As Object) As Boolean
        Dim res As Long = OutbreakDbService.CheckCaseDiagnosesConnection(caseOrSessionId, idfsDiagnosisOrDiagnosisGroup)
        If res = -1 Then Return True
        If res = -2 Then Return True
        If TypeOf (idfsDiagnosisOrDiagnosisGroup) Is Long Then
            Dim outbreakDiagnosis As Object = Core.LookupBinder.getValue(m_DiagnosisView, CLng(idfsDiagnosisOrDiagnosisGroup), "idfsDiagnosisOrDiagnosisGroup", "name")
            If res > 0 Then
                Dim idfsDiagnosisGroup As Object = Core.LookupBinder.getValue(m_DiagnosisView, CLng(idfsDiagnosisOrDiagnosisGroup), "idfsDiagnosisOrDiagnosisGroup", "idfsDiagnosisGroup")
                Dim outbreakGroup As Object = Core.LookupBinder.getValue(m_DiagnosisView, CLng(idfsDiagnosisGroup), "idfsDiagnosisOrDiagnosisGroup", "name")
                Dim caseDiagnosis As Object = Core.LookupBinder.getValue(m_DiagnosisView, res, "idfsDiagnosisOrDiagnosisGroup", "name")
                Dim dlgRes As DialogResult = MessageForm.Show(String.Format(EidssMessages.Get("msgUpOutbreakDiagnosisToGroup", "Outbreak diagnosis {0} and diagnosis of the case/session {1} {2} are not equal, but are included to the same diagnoses group {3}. Do you want to enter {3} as outbreak diagnosis?"), outbreakDiagnosis, caseOrSession, caseDiagnosis, outbreakGroup), BvMessages.Get("Confirmation"), MessageBoxButtons.YesNo)
                If dlgRes = DialogResult.Yes Then
                    cbDiagnosis.EditValue = CLng(idfsDiagnosisGroup)
                    Return True
                Else
                    Return False
                End If
            End If
            MessageForm.Show(String.Format(EidssMessages.Get("msgOutbreakDiagnosisErrorCases", "Case/session {0} cannot be added to the outbreak {1}. Diagnosis of the case/session must be the same as the diagnosis of the outbreak or be included to the diagnoses group of the outbreak. Outbreak’s diagnosis/diagnoses group is {2}."), caseOrSession, baseDataSet.Tables("Outbreak").Rows(0)("strOutbreakID"), outbreakDiagnosis),
                             EidssMessages.Get("ErrErrorFormCaption"), MessageBoxButtons.OK)
        End If
        Return False
    End Function

    Private Function FocusedCaseRowHandle(TempDRow As DataRow) As Integer
        Dim CaseListDTable As DataTable = baseDataSet.Tables("CaseList")
        Dim res As Integer = -1
        If (Not TempDRow Is Nothing) AndAlso (TempDRow.RowState <> DataRowState.Deleted) Then
            res = 0
            While (res < CaseListDTable.Rows.Count) AndAlso (Not CaseListDTable.Rows(res) Is TempDRow)
                res = res + 1
            End While
            If res = CaseListDTable.Rows.Count Then res = -1
        End If
        Return res
    End Function

    Private Sub AddHumanCase(ByVal humanCase As IObject, ByVal o_ID As Object)
        Dim outbreakID As String = OutbreakDbService.IsCaseInOutbreak(humanCase.GetValue("idfCase"), o_ID)
        If outbreakID <> String.Empty Then
            Dim dlgRes As DialogResult = MessageForm.Show(String.Format(EidssMessages.Get("msgCaseInOutbreak", "The case {0} is included in the outbreak {1}. Remove this case from another outbreak?"), humanCase.GetValue("strCaseID"), outbreakID), BvMessages.Get("Confirmation"), MessageBoxButtons.YesNo)
            If dlgRes = DialogResult.Yes Then AddHumanCase(humanCase)
        Else
            AddHumanCase(humanCase)
        End If
    End Sub

    Private Sub AddHumanCase(ByVal humanCase As IObject)
        Dim CaseListDTable As DataTable = baseDataSet.Tables("CaseList")
        Dim row As DataRow = CaseListDTable.Rows.Find(humanCase.GetValue("idfCase"))
        If (row Is Nothing) OrElse (row.RowState = DataRowState.Deleted) Then
            row = CaseListDTable.NewRow()
            row("idfCase") = humanCase.GetValue("idfCase")
            row("datEnteredDate") = humanCase.GetValue("datEnteredDate")
            row("idfsSourceOfCaseSessionDate") = 5
            row("strCaseID") = humanCase.GetValue("strCaseID")
            row("idfsCaseType") = CLng(CaseType.Human)
            row("idfGeoLocation") = humanCase.GetValue("idfGeoLocation")
            row("idfAddress") = humanCase.GetValue("idfAddress")
            row("strGeoLocation") = EIDSS_DbUtils.GetGeoLocaionString(CLng(humanCase.GetValue("idfGeoLocation")))
            row("strAddress") = EIDSS_DbUtils.GetAddressString(humanCase.GetValue("idfAddress"))
            row("strDiagnosis") = humanCase.GetValue("DiagnosisName")
            row("strCaseStatus") = humanCase.GetValue("CaseStatusName")
            row("idfOutbreak") = GetKey()
            row("Confirmed") = IIf(CLng(CaseClassification.Confirmed).Equals(humanCase.GetValue("idfsCaseStatus")), 1, 0)
            row("strPatientName") = humanCase.GetValue("PatientName")
            CaseListDTable.Rows.Add(row)
            If baseDataSet.Tables("CaseList").DefaultView.Count = 1 Then
                If baseDataSet.Tables("Outbreak").Rows(0)("idfsDiagnosisOrDiagnosisGroup") Is DBNull.Value Then
                    baseDataSet.Tables("Outbreak").Rows(0)("idfsDiagnosisOrDiagnosisGroup") = humanCase.GetValue("idfsDiagnosis")
                    baseDataSet.Tables("Outbreak").Rows(0).EndEdit()
                End If
                CopyLocation(humanCase.GetValue("idfGeoLocation"), humanCase.GetValue("idfAddress"))
            End If

            OutbreakDbService.RefreshCaseInfo(baseDataSet, row("idfCase"))

        Else
            gvCaseList.FocusedRowHandle = FocusedCaseRowHandle(row)
        End If
    End Sub

    Private Sub AddVetCase(ByVal vetCase As IObject, ByVal o_ID As Object)
        Dim outbreakID As String = OutbreakDbService.IsCaseInOutbreak(vetCase.GetValue("idfCase"), o_ID)
        If outbreakID <> String.Empty Then
            Dim dlgRes As DialogResult = MessageForm.Show(String.Format(EidssMessages.Get("msgCaseInOutbreak", "The case {0} is included in the outbreak {1}. Remove this case from another outbreak?"), vetCase.GetValue("strCaseID"), outbreakID), BvMessages.Get("Confirmation"), MessageBoxButtons.YesNo)
            If dlgRes = DialogResult.Yes Then AddVetCase(vetCase)
        Else
            AddVetCase(vetCase)
        End If
    End Sub

    Private Sub AddVetCase(ByVal vetCase As IObject)
        Dim CaseListDTable As DataTable = baseDataSet.Tables("CaseList")
        Dim row As DataRow = CaseListDTable.Rows.Find(vetCase.GetValue("idfCase"))
        If (row Is Nothing) OrElse (row.RowState = DataRowState.Deleted) Then
            row = CaseListDTable.NewRow()
            row("idfCase") = vetCase.GetValue("idfCase")
            row("datEnteredDate") = vetCase.GetValue("datEnteredDate")
            row("idfsSourceOfCaseSessionDate") = 14
            row("strCaseID") = vetCase.GetValue("strCaseID")
            row("idfsCaseType") = vetCase.GetValue("idfsCaseType")
            row("idfGeoLocation") = vetCase.GetValue("idfAddress")
            row("idfAddress") = vetCase.GetValue("idfAddress")
            row("strGeoLocation") = EIDSS_DbUtils.GetGeoLocaionString(vetCase.GetValue("idfAddress"))
            row("strAddress") = EIDSS_DbUtils.GetAddressString(vetCase.GetValue("idfAddress"))
            row("strDiagnosis") = vetCase.GetValue("DiagnosisName")
            row("strCaseStatus") = vetCase.GetValue("CaseClassificationName")
            row("Confirmed") = IIf(CLng(CaseClassification.Confirmed).Equals(vetCase.GetValue("idfsCaseStatus")), 1, 0)
            row("idfOutbreak") = GetKey()
            CaseListDTable.Rows.Add(row)
            If baseDataSet.Tables("CaseList").DefaultView.Count = 1 Then
                If baseDataSet.Tables("Outbreak").Rows(0)("idfsDiagnosisOrDiagnosisGroup") Is DBNull.Value Then
                    baseDataSet.Tables("Outbreak").Rows(0)("idfsDiagnosisOrDiagnosisGroup") = IIf(vetCase.GetValue("idfsShowDiagnosis") Is Nothing, DBNull.Value, vetCase.GetValue("idfsShowDiagnosis"))
                    baseDataSet.Tables("Outbreak").Rows(0).EndEdit()
                End If
                CopyLocation(DBNull.Value, vetCase.GetValue("idfAddress"))
            End If

            OutbreakDbService.RefreshCaseInfo(baseDataSet, row("idfCase"))

        Else
            gvCaseList.FocusedRowHandle = FocusedCaseRowHandle(row)
        End If
    End Sub

    Private Sub AddSession(ByVal session As IObject, ByVal o_ID As Object)
        Dim outbreakID As String = OutbreakDbService.IsCaseInOutbreak(session.GetValue("idfCase"), o_ID)
        If outbreakID <> String.Empty Then
            Dim dlgRes As DialogResult = MessageForm.Show(String.Format(EidssMessages.Get("msgSessionInOutbreak", "The session {0} is included in the outbreak {1}. Remove this session from another outbreak?"), session.GetValue("strCaseID"), outbreakID), BvMessages.Get("Confirmation"), MessageBoxButtons.YesNo)
            If dlgRes = DialogResult.Yes Then AddSession(session)
        Else
            AddSession(session)
        End If
    End Sub

    Private Sub AddSession(ByVal session As IObject)
        Dim CaseListDTable As DataTable = baseDataSet.Tables("CaseList")
        Dim row As DataRow = CaseListDTable.Rows.Find(session.GetValue("idfCase"))
        If (row Is Nothing) OrElse (row.RowState = DataRowState.Deleted) Then
            row = CaseListDTable.NewRow()
            row("idfCase") = session.GetValue("idfVectorSurveillanceSession")
            row("datEnteredDate") = session.GetValue("datStartDate")
            row("idfsSourceOfCaseSessionDate") = 15
            row("strCaseID") = session.GetValue("strSessionID")
            row("idfsCaseType") = CLng(CaseType.Vector)
            row("idfGeoLocation") = session.GetValue("idfLocation")
            row("idfAddress") = session.GetValue("idfLocation")
            row("strGeoLocation") = EIDSS_DbUtils.GetGeoLocaionString(CLng(session.GetValue("idfLocation")))
            row("strAddress") = EIDSS_DbUtils.GetAddressString(session.GetValue("idfLocation"))
            row("strDiagnosis") = Utils.Str(session.GetValue("strDiagnoses")).Replace(";", ",")
            row("idfOutbreak") = GetKey()
            row("Confirmed") = 1
            CaseListDTable.Rows.Add(row)
            If baseDataSet.Tables("CaseList").DefaultView.Count = 1 Then
                CopyLocation(session.GetValue("idfLocation"), DBNull.Value)
            End If

            OutbreakDbService.RefreshCaseInfo(baseDataSet, row("idfCase"))

        Else
            gvCaseList.FocusedRowHandle = FocusedCaseRowHandle(row)
        End If
    End Sub

    Private Sub CopyLocation(ByVal idfGeoLocation As Object, ByVal idfAddress As Object)
        If baseDataSet.Tables("CaseList").DefaultView.Count = 1 AndAlso (Utils.Str(cbGeoLocation.DisplayText) = "") Then
            Dim firstRow As DataRowView = baseDataSet.Tables("CaseList").DefaultView(0)
            Dim oldLocation As Object = baseDataSet.Tables("Outbreak").Rows(0)("idfGeoLocation") 'cbGeoLocation.ID
            If (Not Utils.IsEmpty(idfGeoLocation)) Then
                cbGeoLocation.LoadData(idfGeoLocation)
                cbGeoLocation.baseDataSet.Tables("GeoLocation").Rows(0)("idfGeoLocation") = oldLocation
            End If
            If Utils.Str(cbGeoLocation.DisplayText) = "" Then 'case location is not defined, populate address Country, Region, Rayon into location
                cbGeoLocation.ForcedGeolocationType = GeoLocationType.RelativePoint
                cbGeoLocation.LoadData(idfAddress)
                If (Utils.IsEmpty(cbGeoLocation.baseDataSet.Tables("GeoLocation").Rows(0)("idfsSettlement"))) Then
                    cbGeoLocation.baseDataSet.Tables("GeoLocation").Rows(0)("idfsGeoLocationType") = CLng(GeoLocationType.ExactPoint)
                End If
                cbGeoLocation.ForcedGeolocationType = GeoLocationType.Default

                cbGeoLocation.baseDataSet.Tables("GeoLocation").Rows(0)("idfGeoLocation") = oldLocation
                'do not copy coordinates from address
                cbGeoLocation.baseDataSet.Tables("GeoLocation").Rows(0)("dblLongitude") = DBNull.Value
                cbGeoLocation.baseDataSet.Tables("GeoLocation").Rows(0)("dblLatitude") = DBNull.Value
            End If

            If CLng(CaseType.Human).Equals(firstRow("idfsCaseType")) Then
                If m_HideHumanSettlement Then
                    cbGeoLocation.baseDataSet.Tables("GeoLocation").Rows(0)("idfsSettlement") = DBNull.Value
                End If
            ElseIf CLng(CaseType.Livestock).Equals(firstRow("idfsCaseType")) OrElse CLng(CaseType.Avian).Equals(firstRow("idfsCaseType")) Then
                If m_HideVetSettlement Then
                    cbGeoLocation.baseDataSet.Tables("GeoLocation").Rows(0)("idfsSettlement") = DBNull.Value
                End If
                If m_HideVetLocation Then
                    cbGeoLocation.baseDataSet.Tables("GeoLocation").Rows(0)("dblLongitude") = DBNull.Value
                    cbGeoLocation.baseDataSet.Tables("GeoLocation").Rows(0)("dblLatitude") = DBNull.Value
                End If
            End If
            'cbGeoLocation.RefreshDisplayText()
            cbGeoLocation.Bind(baseDataSet, "Outbreak.idfGeoLocation")
        End If

    End Sub
#End Region

    Private Sub btnRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If gvCaseList.SelectedRowsCount() > 0 Then
            If WinUtils.ConfirmMessage(String.Format(EidssMessages.Get("msgRemoveItemsFromOutbreak"), gvCaseList.SelectedRowsCount()), EidssMessages.Get("msgRemoveConfirmation", "Remove confirnmation?")) Then
                Dim Rows As New ArrayList()
                ' Add the selected rows to the list.
                Dim I As Integer
                For I = 0 To gvCaseList.SelectedRowsCount() - 1
                    If (gvCaseList.GetSelectedRows()(I) >= 0) Then
                        Rows.Add(gvCaseList.GetDataRow(gvCaseList.GetSelectedRows()(I)))
                    End If
                Next
                Try
                    gvCaseList.BeginUpdate()
                    For I = 0 To Rows.Count - 1
                        Dim Row As DataRow = CType(Rows(I), DataRow)
                        If (Utils.Str(Row("idfCase")) = Utils.Str(baseDataSet.Tables("Outbreak").Rows(0)("idfPrimaryCaseOrSession"))) Then
                            ClearPrimaryCase()
                        End If
                        Row.Delete()
                    Next
                Finally
                    gvCaseList.EndUpdate()
                End Try

            End If
        End If
    End Sub

    Private Sub btnViewCaseDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnViewCaseDetails.Click
        If BindingContext(baseDataSet, "CaseList").Count > 0 Then
            Me.Enabled = False
            Dim row As DataRowView = CType(BindingContext(baseDataSet, "CaseList").Current, DataRowView)
            Dim caseID As Object = row("idfCase")
            ShowCaseDetail(caseID)
            Me.Enabled = True
        End If

    End Sub

    Private Sub ShowCaseDetail(ByVal caseID As Object)
        If Not CanAddViewRemove Then
            Return
        End If
        Dim RefreshCaseInfo As Boolean = False
        Dim row As DataRow = baseDataSet.Tables("CaseList").Rows.Find(caseID)
        If row Is Nothing Then
            Return
        End If
        Dim detail As IApplicationForm = Nothing
        Select Case CType(row("idfsCaseType"), CaseType)
            Case CaseType.Human
                detail = CType(ClassLoader.LoadClass("HumanCaseDetail"), IApplicationForm)
                ReflectionHelper.SetProperty(detail, "ShowNavigators", False)
            Case CaseType.Livestock
                detail = CType(ClassLoader.LoadClass("VetCaseLiveStockDetail"), IApplicationForm)
            Case CaseType.Avian
                detail = CType(ClassLoader.LoadClass("VetCaseAvianDetail"), IApplicationForm)
            Case CaseType.Vector
                detail = CType(ClassLoader.LoadClass("VsSessionDetail"), IApplicationForm)
        End Select
        If detail Is Nothing Then Return

        If (Not BaseFormManager.FindFormByID(detail.GetType(), caseID) Is Nothing) Then
            BaseFormManager.ShowModal_ReadOnly(detail, FindForm, caseID, Nothing, Nothing)
        Else
            RefreshCaseInfo = BaseFormManager.ShowModal(detail, FindForm, caseID, Nothing, Nothing)
        End If
        If RefreshCaseInfo Then
            OutbreakDbService.RefreshCaseInfo(baseDataSet, caseID)
            RefreshPrimaryCaseInfo(row)
        End If

    End Sub

    Private Sub btnDeleteNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteNote.Click
        If WinUtils.ConfirmDelete = False Then
            Return
        End If
        If BindingContext(baseDataSet, "Notes").Count > 0 Then
            Dim row As DataRowView = CType(BindingContext(baseDataSet, "Notes").Current, DataRowView)
            If Not row Is Nothing Then
                row.Delete()
            End If
        End If

    End Sub

    Private Sub cbDiagnosis_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cbDiagnosis.EditValueChanging
        ' get new diagnosis/diagnoses group
        Dim idfsNewDiagnosis As Object = e.NewValue
        If CLng(idfsNewDiagnosis) > 0 Then

            'check all cases diagnoses to new outbreak diagnosis/group
            Dim CaseListDTable As DataTable = baseDataSet.Tables("CaseList")
            Dim i As Integer = 0
            Dim casesSessionError As String = ""
            Dim casesSessionWarning As String = ""
            While (i < CaseListDTable.Rows.Count)
                Dim row As DataRow = CaseListDTable.Rows(i)
                If (Not row Is Nothing AndAlso row.RowState <> DataRowState.Deleted) Then
                    Dim res As Long = OutbreakDbService.CheckCaseDiagnosesConnection(row("idfCase"), idfsNewDiagnosis)
                    If res > 0 Then
                        If casesSessionWarning <> "" Then casesSessionWarning += ", "
                        casesSessionWarning += CStr(row("strCaseID"))
                    ElseIf res = 0 Then
                        If casesSessionError <> "" Then casesSessionError += ", "
                        casesSessionError += CStr(row("strCaseID"))
                    End If
                End If
                i = i + 1
            End While

            'show error/warning messages
            If casesSessionError <> "" Then
                MessageForm.Show(String.Format(EidssMessages.Get("msgOutbreakDiagnosisErrorCases2", "Diagnosis of the case/session must be the same as the diagnosis of the outbreak or be included to the diagnoses group of the outbreak. Diagnoses of the following cases/sessions do not satisfy the rule: {0}. Change the outbreak’s diagnosis (diagnoses group) or remove these cases/sessions from the outbreak."), casesSessionError), EidssMessages.Get("ErrErrorFormCaption"), MessageBoxButtons.OK)
                'return to previous diagnosis
                e.Cancel = True
            ElseIf casesSessionWarning <> "" Then
                Dim outbreakDiagnosis As Object = Core.LookupBinder.getValue(m_DiagnosisView, CLng(idfsNewDiagnosis), "idfsDiagnosisOrDiagnosisGroup", "name")
                Dim idfsDiagnosisGroup As Object = Core.LookupBinder.getValue(m_DiagnosisView, CLng(idfsNewDiagnosis), "idfsDiagnosisOrDiagnosisGroup", "idfsDiagnosisGroup")
                Dim outbreakGroup As Object = Core.LookupBinder.getValue(m_DiagnosisView, CLng(idfsDiagnosisGroup), "idfsDiagnosisOrDiagnosisGroup", "name")
                Dim dlgRes As DialogResult = MessageForm.Show(String.Format(EidssMessages.Get("msgUpOutbreakDiagnosisToGroup2", "Outbreak diagnosis {0} and diagnosis(-es) of the case(s)/session(s) {1} are not equal, but are included to the same diagnoses group {2}. Do you want to enter {2} as outbreak diagnosis?"), outbreakDiagnosis, casesSessionWarning, outbreakGroup), BvMessages.Get("Confirmation"), MessageBoxButtons.YesNo)
                If dlgRes = DialogResult.Yes Then
                    'up to group of diagnosis
                    e.NewValue = idfsDiagnosisGroup
                Else
                    'return to previous diagnosis
                    e.Cancel = True
                End If
            End If

        End If
    End Sub

#Region "Set/Clear Primary Case"
    Private Sub btnMarkAsPrimary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMarkAsPrimary.Click
        If BindingContext(baseDataSet, "CaseList").Count > 0 Then
            Dim row As DataRowView = CType(BindingContext(baseDataSet, "CaseList").Current, DataRowView)
            If Not row Is Nothing Then
                Dim CaseID As Object = row("idfCase")
                baseDataSet.Tables("Outbreak").Rows(0)("idfPrimaryCaseOrSession") = CaseID
                RefreshPrimaryCaseInfo(row.Row)
            End If
        End If

    End Sub

    Private Sub RefreshPrimaryCaseInfo(caseRow As DataRow)
        If (Not baseDataSet.Tables("Outbreak").Rows(0)("idfPrimaryCaseOrSession") Is DBNull.Value) Then
            If (baseDataSet.Tables("Outbreak").Rows(0)("idfPrimaryCaseOrSession").Equals(caseRow("idfCase"))) Then
                baseDataSet.Tables("Outbreak").Rows(0)("strPrimaryCase") = Utils.Join(", ", New String() {Utils.Str(caseRow("strCaseID")), Utils.Str(caseRow("strDiagnosis"))})
                baseDataSet.Tables("Outbreak").Rows(0).EndEdit()
            End If
        End If
    End Sub
    Private Sub txtPrimaryCase_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtPrimaryCase.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then
            Me.Enabled = False
            Dim CaseID As Object = baseDataSet.Tables("Outbreak").Rows(0)("idfPrimaryCaseOrSession")
            ShowCaseDetail(CaseID)
            Me.Enabled = True
        ElseIf e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete Then
            ClearPrimaryCase()
        End If

    End Sub

    Private Sub ClearPrimaryCase()
        baseDataSet.Tables("Outbreak").Rows(0)("idfPrimaryCaseOrSession") = DBNull.Value
        baseDataSet.Tables("Outbreak").Rows(0)("strPrimaryCase") = DBNull.Value
    End Sub
#End Region

#Region "Reports"

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        '  Dim eidssStat As Object
        '  Dim parArr(1) As Object
        If baseDataSet Is Nothing OrElse baseDataSet.Tables.Count = 0 Then
            Return
        End If

        If Post(PostType.FinalPosting) Then
            '   parArr(0) = bv.model.Model.Core.ModelUserContext.CurrentLanguage
            '   parArr(1) = Me.OutbreakDbService.ID.ToString

            Dim id As Long = CType(Me.OutbreakDbService.ID, Long)
            EidssSiteContext.ReportFactory.Outbreak(id)

            ' eidssStat = ClassLoader.LoadClass("DVDoc")
            'Dim mi As System.Reflection.MethodInfo = eidssStat.GetType().GetMethod("Show_UNI_Outbreak")
            'mi.Invoke(eidssStat, parArr)
        End If
    End Sub

#End Region

#Region "gvCaseList Events"

    Private Sub gvCaseList_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles gvCaseList.CustomDrawCell
        Dim row As DataRow = gvCaseList.GetDataRow(e.RowHandle)
        If (CLng(CaseType.Human).Equals(row("idfsCaseType"))) Then
            If (m_HidePatientName) AndAlso e.Column Is gcolPatientName Then
                e.DisplayText = "*"
            End If
            If m_HideHumanSettlement AndAlso e.Column Is gcolAddress Then
                e.DisplayText = EIDSS_DbUtils.GetPersonalDataAddressString(row("idfAddress"), True)
            ElseIf m_HideHumanAddress AndAlso e.Column Is gcolAddress Then
                e.DisplayText = EIDSS_DbUtils.GetPersonalDataAddressString(row("idfAddress"), False)
            End If

        Else
            If (m_HideFarmOwnerName) AndAlso e.Column Is gcolPatientName Then
                e.DisplayText = "*"
            End If
            If m_HideVetSettlement AndAlso e.Column Is gcolAddress Then
                e.DisplayText = EIDSS_DbUtils.GetPersonalDataAddressString(row("idfAddress"), True)
            ElseIf m_HideVetAddress AndAlso e.Column Is gcolAddress Then
                e.DisplayText = EIDSS_DbUtils.GetPersonalDataAddressString(row("idfAddress"), False)
            End If
            If m_HideVetLocation AndAlso e.Column Is gcolLocation Then
                e.DisplayText = "*"
            End If

        End If
    End Sub


    Private Sub gvCaseList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvCaseList.DoubleClick
        If IsRowClicked(m_LastX, m_LastY) Then
            btnViewCaseDetails_Click(sender, e)
        End If

    End Sub
    Protected Function IsRowClicked(ByVal x As Integer, ByVal y As Integer) As Boolean
        Dim chi As New GridHitInfo()
        chi = gvCaseList.CalcHitInfo(New System.Drawing.Point(x, y))
        Return chi.InRow
    End Function

    Private m_LastX As Integer = -1
    Private m_LastY As Integer = -1
    Private Sub gvCaseList_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gvCaseList.MouseUp
        m_LastX = e.Location.X
        m_LastY = e.Location.Y
    End Sub

    Private Sub gvCaseList_CustomUnboundColumnData(ByVal sender As Object, ByVal e As CustomColumnDataEventArgs) Handles gvCaseList.CustomUnboundColumnData
        Dim row As DataRow = baseDataSet.Tables("CaseList").Rows(e.ListSourceRowIndex)
        If e.Column.FieldName = "strSourceOfCaseDate" AndAlso e.IsGetData AndAlso row.RowState <> DataRowState.Deleted Then
            e.Value = SourceOfCaseSessionDateMapper.Map(CType(row("idfsSourceOfCaseSessionDate"), SourceOfCaseSessionDate))
        End If
    End Sub
#End Region

    Public Overrides Sub BaseForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If Me.ActiveControl Is gcCaseList AndAlso gvCaseList.FocusedRowHandle >= 0 Then
            If e.KeyCode = Keys.Enter Then
                e.Handled = True
                btnViewCaseDetails_Click(gvCaseList, EventArgs.Empty)
                Return
            End If

        End If
        MyBase.BaseForm_KeyDown(sender, e)
    End Sub

    Public Overrides Function GetChildKey(ByVal child As IRelatedObject) As Object
        If child Is cbGeoLocation Then
            Return baseDataSet.Tables("Outbreak").Rows(0)("idfGeoLocation")
        End If
        Return MyBase.GetChildKey(child)
    End Function

    Public Overrides Sub UpdateButtonsState(ByVal sender As Object, ByVal e As System.EventArgs)
        miAddHumanCase.Enabled = Not [ReadOnly] AndAlso CanAddViewRemove And New StandardAccessPermissions(EIDSSPermissionObject.HumanCase).CanSelect
        miAddVetCase.Enabled = Not [ReadOnly] AndAlso CanAddViewRemove And New StandardAccessPermissions(EIDSSPermissionObject.VetCase).CanSelect
        miAddSession.Enabled = Not [ReadOnly] AndAlso CanAddViewRemove And New StandardAccessPermissions(EIDSSPermissionObject.VsSession).CanSelect
        btnRemove.Enabled = Not [ReadOnly] AndAlso CanAddViewRemove
        btnDeleteNote.Enabled = Not [ReadOnly] AndAlso CanAddViewRemove
        btnViewCaseDetails.Enabled = Not [ReadOnly] AndAlso CanAddViewRemove AndAlso gvCaseList.SelectedRowsCount() = 1
        btnMarkAsPrimary.Enabled = Not [ReadOnly] AndAlso gvCaseList.SelectedRowsCount() = 1
        txtPrimaryCase.Properties.Buttons(0).Enabled = CanAddViewRemove AndAlso Not Utils.IsEmpty(txtPrimaryCase.EditValue)
    End Sub

    Protected Overrides Sub RegisterValidators()
        MyBase.RegisterValidators()
        Dim RootDate As New DateChainValidator(Me, dtpStartDate, "Outbreak", "datStartDate", lblStartDate.Text, , , , True)
        RootDate.AddChild(New DateChainValidator(Me, dtpEndDate, "Outbreak", "datFinishDate", lblEndDate.Text, , , , True))

        RootDate.RegisterValidator(Me, True)
    End Sub

    Private Sub OutbreakDetail_AfterLoadData(sender As Object, e As EventArgs) Handles MyBase.AfterLoadData
        If (Not StartUpParameters Is Nothing) Then
            If (StartUpParameters.ContainsKey("idfHumanCase")) AndAlso (TypeOf (StartUpParameters("idfHumanCase")) Is IObject) Then
                AddHumanCase(CType(StartUpParameters("idfHumanCase"), IObject))
            ElseIf (StartUpParameters.ContainsKey("idfVetCase")) AndAlso (TypeOf (StartUpParameters("idfVetCase")) Is IObject) Then
                AddVetCase(CType(StartUpParameters("idfVetCase"), IObject))
            End If
        End If
    End Sub
    Protected Overrides Sub SaveGridLayouts()
        gvCaseList.SaveGridLayout("Outbreak_Cases")
        NotesView.SaveGridLayout("Outbreak_Notes")
    End Sub
    Protected Overrides Sub LoadGridLayouts()
        'Case/Session ID, Case/Session Date, Diagnosis
        gvCaseList.InitXtraGridCustomization(New String() {"strCaseID", "datEnteredDate", "strDiagnosis"})
        gvCaseList.LoadGridLayout("Outbreak_Cases")
        'Note
        NotesView.InitXtraGridCustomization(New String() {"strNote"})
        NotesView.LoadGridLayout("Outbreak_Notes")
    End Sub

End Class
