Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports EIDSS.model.Core
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports EIDSS.model.Resources
Imports bv.common.Resources
Imports EIDSS.model.Enums
Imports bv.model.Model.Core


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
    Friend WithEvents btnAddVetCase As DevExpress.XtraEditors.SimpleButton


#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()


        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        OutbreakDbService = New Outbreak_DB

        DbService = OutbreakDbService
        AuditObject = New Core.EIDSSAuditObject(EIDSSAuditObject.daoOutbreak, AuditTable.tlbOutbreak)
        LookupTableNames = New String() {"Outbreak"}
        PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.Outbreak

        RegisterChildObject(Me.cbGeoLocation, RelatedPostOrder.PostFirst)
        txtNote.PopupFormSize = New Drawing.Size(Me.NotesGrid.Width, 300)
        m_HideVetSettlement = EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement)
        m_HideVetAddress = EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details)
        m_HideVetLocation = EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Coordinates)
        m_HideFarmOwnerName = m_HideVetSettlement OrElse m_HideVetAddress
        m_HidePatientName = EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_PersonName)
        m_HideHumanSettlement = EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_CurrentResidence_Settlement)
        m_HideHumanAddress = EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_CurrentResidence_Details)

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
    Friend WithEvents btnAddHumanCase As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnViewCaseDetails As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnRemove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents lblDisease As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents dtpStartDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents PopUpButton1 As bv.common.win.PopUpButton
    Friend WithEvents cbDiagnosis As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents lblOutbreak_Status As System.Windows.Forms.Label
    Friend WithEvents cbOutbreak_Status As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents gvCaseList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gcolCaseDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolCaseStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gbRelatedCaseReports As System.Windows.Forms.GroupBox
    Friend WithEvents lblOutbreakID As System.Windows.Forms.Label
    Friend WithEvents txtOutbreakID As DevExpress.XtraEditors.TextEdit

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OutbreakDetail))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim TagHelper1 As bv.common.win.TagHelper = New bv.common.win.TagHelper()
        Me.cbDiagnosis = New DevExpress.XtraEditors.LookUpEdit()
        Me.dtpEndDate = New DevExpress.XtraEditors.DateEdit()
        Me.gbRelatedCaseReports = New System.Windows.Forms.GroupBox()
        Me.btnMarkAsPrimary = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAddVetCase = New DevExpress.XtraEditors.SimpleButton()
        Me.gcCaseList = New DevExpress.XtraGrid.GridControl()
        Me.gvCaseList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gcolCaseID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolCaseType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolDisease = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolCaseDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolCaseStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolLocation = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolAddress = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolPatientName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.btnRemove = New DevExpress.XtraEditors.SimpleButton()
        Me.btnViewCaseDetails = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAddHumanCase = New DevExpress.XtraEditors.SimpleButton()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.dtpStartDate = New DevExpress.XtraEditors.DateEdit()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.lblDisease = New System.Windows.Forms.Label()
        Me.cbOutbreak_Status = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblOutbreak_Status = New System.Windows.Forms.Label()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.PopUpButton1 = New bv.common.win.PopUpButton()
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
        CType(Me.cbDiagnosis.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpEndDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpEndDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbRelatedCaseReports.SuspendLayout()
        CType(Me.gcCaseList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvCaseList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpStartDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpStartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.dtNoteDate.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbNotePerson, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        '
        'cbDiagnosis
        '
        resources.ApplyResources(Me.cbDiagnosis, "cbDiagnosis")
        Me.cbDiagnosis.Name = "cbDiagnosis"
        Me.cbDiagnosis.Properties.AccessibleDescription = resources.GetString("cbDiagnosis.Properties.AccessibleDescription")
        Me.cbDiagnosis.Properties.AccessibleName = resources.GetString("cbDiagnosis.Properties.AccessibleName")
        Me.cbDiagnosis.Properties.AutoHeight = CType(resources.GetObject("cbDiagnosis.Properties.AutoHeight"), Boolean)
        Me.cbDiagnosis.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDiagnosis.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbDiagnosis.Properties.NullText = resources.GetString("cbDiagnosis.Properties.NullText")
        Me.cbDiagnosis.Properties.NullValuePrompt = resources.GetString("cbDiagnosis.Properties.NullValuePrompt")
        Me.cbDiagnosis.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbDiagnosis.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        '
        'dtpEndDate
        '
        resources.ApplyResources(Me.dtpEndDate, "dtpEndDate")
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Properties.AccessibleDescription = resources.GetString("dtpEndDate.Properties.AccessibleDescription")
        Me.dtpEndDate.Properties.AccessibleName = resources.GetString("dtpEndDate.Properties.AccessibleName")
        Me.dtpEndDate.Properties.Appearance.GradientMode = CType(resources.GetObject("dtpEndDate.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpEndDate.Properties.Appearance.Image = CType(resources.GetObject("dtpEndDate.Properties.Appearance.Image"), System.Drawing.Image)
        Me.dtpEndDate.Properties.Appearance.Options.UseFont = True
        Me.dtpEndDate.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("dtpEndDate.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpEndDate.Properties.AppearanceDisabled.Image = CType(resources.GetObject("dtpEndDate.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.dtpEndDate.Properties.AppearanceDisabled.Options.UseFont = True
        Me.dtpEndDate.Properties.AppearanceDropDown.GradientMode = CType(resources.GetObject("dtpEndDate.Properties.AppearanceDropDown.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpEndDate.Properties.AppearanceDropDown.Image = CType(resources.GetObject("dtpEndDate.Properties.AppearanceDropDown.Image"), System.Drawing.Image)
        Me.dtpEndDate.Properties.AppearanceDropDown.Options.UseFont = True
        Me.dtpEndDate.Properties.AppearanceDropDownHeader.GradientMode = CType(resources.GetObject("dtpEndDate.Properties.AppearanceDropDownHeader.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpEndDate.Properties.AppearanceDropDownHeader.Image = CType(resources.GetObject("dtpEndDate.Properties.AppearanceDropDownHeader.Image"), System.Drawing.Image)
        Me.dtpEndDate.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.dtpEndDate.Properties.AppearanceDropDownHeaderHighlight.GradientMode = CType(resources.GetObject("dtpEndDate.Properties.AppearanceDropDownHeaderHighlight.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpEndDate.Properties.AppearanceDropDownHeaderHighlight.Image = CType(resources.GetObject("dtpEndDate.Properties.AppearanceDropDownHeaderHighlight.Image"), System.Drawing.Image)
        Me.dtpEndDate.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = True
        Me.dtpEndDate.Properties.AppearanceDropDownHighlight.GradientMode = CType(resources.GetObject("dtpEndDate.Properties.AppearanceDropDownHighlight.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpEndDate.Properties.AppearanceDropDownHighlight.Image = CType(resources.GetObject("dtpEndDate.Properties.AppearanceDropDownHighlight.Image"), System.Drawing.Image)
        Me.dtpEndDate.Properties.AppearanceDropDownHighlight.Options.UseFont = True
        Me.dtpEndDate.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("dtpEndDate.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpEndDate.Properties.AppearanceFocused.Image = CType(resources.GetObject("dtpEndDate.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.dtpEndDate.Properties.AppearanceFocused.Options.UseFont = True
        Me.dtpEndDate.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("dtpEndDate.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpEndDate.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("dtpEndDate.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.dtpEndDate.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.dtpEndDate.Properties.AppearanceWeekNumber.GradientMode = CType(resources.GetObject("dtpEndDate.Properties.AppearanceWeekNumber.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpEndDate.Properties.AppearanceWeekNumber.Image = CType(resources.GetObject("dtpEndDate.Properties.AppearanceWeekNumber.Image"), System.Drawing.Image)
        Me.dtpEndDate.Properties.AppearanceWeekNumber.Options.UseFont = True
        Me.dtpEndDate.Properties.AutoHeight = CType(resources.GetObject("dtpEndDate.Properties.AutoHeight"), Boolean)
        Me.dtpEndDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtpEndDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtpEndDate.Properties.Mask.AutoComplete = CType(resources.GetObject("dtpEndDate.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.dtpEndDate.Properties.Mask.BeepOnError = CType(resources.GetObject("dtpEndDate.Properties.Mask.BeepOnError"), Boolean)
        Me.dtpEndDate.Properties.Mask.EditMask = resources.GetString("dtpEndDate.Properties.Mask.EditMask")
        Me.dtpEndDate.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtpEndDate.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtpEndDate.Properties.Mask.MaskType = CType(resources.GetObject("dtpEndDate.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtpEndDate.Properties.Mask.PlaceHolder = CType(resources.GetObject("dtpEndDate.Properties.Mask.PlaceHolder"), Char)
        Me.dtpEndDate.Properties.Mask.SaveLiteral = CType(resources.GetObject("dtpEndDate.Properties.Mask.SaveLiteral"), Boolean)
        Me.dtpEndDate.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtpEndDate.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtpEndDate.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("dtpEndDate.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.dtpEndDate.Properties.NullValuePrompt = resources.GetString("dtpEndDate.Properties.NullValuePrompt")
        Me.dtpEndDate.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("dtpEndDate.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.dtpEndDate.Properties.VistaTimeProperties.AccessibleDescription = resources.GetString("dtpEndDate.Properties.VistaTimeProperties.AccessibleDescription")
        Me.dtpEndDate.Properties.VistaTimeProperties.AccessibleName = resources.GetString("dtpEndDate.Properties.VistaTimeProperties.AccessibleName")
        Me.dtpEndDate.Properties.VistaTimeProperties.AutoHeight = CType(resources.GetObject("dtpEndDate.Properties.VistaTimeProperties.AutoHeight"), Boolean)
        Me.dtpEndDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtpEndDate.Properties.VistaTimeProperties.Mask.AutoComplete = CType(resources.GetObject("dtpEndDate.Properties.VistaTimeProperties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.dtpEndDate.Properties.VistaTimeProperties.Mask.BeepOnError = CType(resources.GetObject("dtpEndDate.Properties.VistaTimeProperties.Mask.BeepOnError"), Boolean)
        Me.dtpEndDate.Properties.VistaTimeProperties.Mask.EditMask = resources.GetString("dtpEndDate.Properties.VistaTimeProperties.Mask.EditMask")
        Me.dtpEndDate.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtpEndDate.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtpEndDate.Properties.VistaTimeProperties.Mask.MaskType = CType(resources.GetObject("dtpEndDate.Properties.VistaTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtpEndDate.Properties.VistaTimeProperties.Mask.PlaceHolder = CType(resources.GetObject("dtpEndDate.Properties.VistaTimeProperties.Mask.PlaceHolder"), Char)
        Me.dtpEndDate.Properties.VistaTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("dtpEndDate.Properties.VistaTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.dtpEndDate.Properties.VistaTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtpEndDate.Properties.VistaTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtpEndDate.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("dtpEndDate.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.dtpEndDate.Properties.VistaTimeProperties.NullValuePrompt = resources.GetString("dtpEndDate.Properties.VistaTimeProperties.NullValuePrompt")
        Me.dtpEndDate.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("dtpEndDate.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue"), Boolean)
        '
        'gbRelatedCaseReports
        '
        resources.ApplyResources(Me.gbRelatedCaseReports, "gbRelatedCaseReports")
        Me.gbRelatedCaseReports.Controls.Add(Me.btnMarkAsPrimary)
        Me.gbRelatedCaseReports.Controls.Add(Me.btnAddVetCase)
        Me.gbRelatedCaseReports.Controls.Add(Me.gcCaseList)
        Me.gbRelatedCaseReports.Controls.Add(Me.btnRemove)
        Me.gbRelatedCaseReports.Controls.Add(Me.btnViewCaseDetails)
        Me.gbRelatedCaseReports.Controls.Add(Me.btnAddHumanCase)
        Me.gbRelatedCaseReports.Name = "gbRelatedCaseReports"
        Me.gbRelatedCaseReports.TabStop = False
        '
        'btnMarkAsPrimary
        '
        resources.ApplyResources(Me.btnMarkAsPrimary, "btnMarkAsPrimary")
        Me.btnMarkAsPrimary.Appearance.GradientMode = CType(resources.GetObject("btnMarkAsPrimary.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.btnMarkAsPrimary.Appearance.Image = CType(resources.GetObject("btnMarkAsPrimary.Appearance.Image"), System.Drawing.Image)
        Me.btnMarkAsPrimary.Appearance.Options.UseTextOptions = True
        Me.btnMarkAsPrimary.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.btnMarkAsPrimary.Name = "btnMarkAsPrimary"
        '
        'btnAddVetCase
        '
        resources.ApplyResources(Me.btnAddVetCase, "btnAddVetCase")
        Me.btnAddVetCase.Appearance.GradientMode = CType(resources.GetObject("btnAddVetCase.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.btnAddVetCase.Appearance.Image = CType(resources.GetObject("btnAddVetCase.Appearance.Image"), System.Drawing.Image)
        Me.btnAddVetCase.Appearance.Options.UseTextOptions = True
        Me.btnAddVetCase.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.btnAddVetCase.Image = CType(resources.GetObject("btnAddVetCase.Image"), System.Drawing.Image)
        Me.btnAddVetCase.Name = "btnAddVetCase"
        '
        'gcCaseList
        '
        resources.ApplyResources(Me.gcCaseList, "gcCaseList")
        Me.gcCaseList.EmbeddedNavigator.AccessibleDescription = resources.GetString("gcCaseList.EmbeddedNavigator.AccessibleDescription")
        Me.gcCaseList.EmbeddedNavigator.AccessibleName = resources.GetString("gcCaseList.EmbeddedNavigator.AccessibleName")
        Me.gcCaseList.EmbeddedNavigator.AllowHtmlTextInToolTip = CType(resources.GetObject("gcCaseList.EmbeddedNavigator.AllowHtmlTextInToolTip"), DevExpress.Utils.DefaultBoolean)
        Me.gcCaseList.EmbeddedNavigator.Anchor = CType(resources.GetObject("gcCaseList.EmbeddedNavigator.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.gcCaseList.EmbeddedNavigator.BackgroundImage = CType(resources.GetObject("gcCaseList.EmbeddedNavigator.BackgroundImage"), System.Drawing.Image)
        Me.gcCaseList.EmbeddedNavigator.BackgroundImageLayout = CType(resources.GetObject("gcCaseList.EmbeddedNavigator.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.gcCaseList.EmbeddedNavigator.ImeMode = CType(resources.GetObject("gcCaseList.EmbeddedNavigator.ImeMode"), System.Windows.Forms.ImeMode)
        Me.gcCaseList.EmbeddedNavigator.TextLocation = CType(resources.GetObject("gcCaseList.EmbeddedNavigator.TextLocation"), DevExpress.XtraEditors.NavigatorButtonsTextLocation)
        Me.gcCaseList.EmbeddedNavigator.ToolTip = resources.GetString("gcCaseList.EmbeddedNavigator.ToolTip")
        Me.gcCaseList.EmbeddedNavigator.ToolTipIconType = CType(resources.GetObject("gcCaseList.EmbeddedNavigator.ToolTipIconType"), DevExpress.Utils.ToolTipIconType)
        Me.gcCaseList.EmbeddedNavigator.ToolTipTitle = resources.GetString("gcCaseList.EmbeddedNavigator.ToolTipTitle")
        GridLevelNode1.RelationName = "Level1"
        Me.gcCaseList.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.gcCaseList.MainView = Me.gvCaseList
        Me.gcCaseList.Name = "gcCaseList"
        Me.gcCaseList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvCaseList})
        '
        'gvCaseList
        '
        resources.ApplyResources(Me.gvCaseList, "gvCaseList")
        Me.gvCaseList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gcolCaseID, Me.gcolCaseType, Me.gcolDisease, Me.gcolCaseDate, Me.gcolCaseStatus, Me.gcolLocation, Me.gcolAddress, Me.gcolPatientName})
        Me.gvCaseList.GridControl = Me.gcCaseList
        Me.gvCaseList.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gvCaseList.Name = "gvCaseList"
        Me.gvCaseList.OptionsBehavior.Editable = False
        Me.gvCaseList.OptionsView.ShowFooter = True
        Me.gvCaseList.OptionsView.ShowGroupPanel = False
        '
        'gcolCaseID
        '
        Me.gcolCaseID.AppearanceHeader.GradientMode = CType(resources.GetObject("gcolCaseID.AppearanceHeader.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.gcolCaseID.AppearanceHeader.Image = CType(resources.GetObject("gcolCaseID.AppearanceHeader.Image"), System.Drawing.Image)
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
        Me.gcolDisease.AppearanceHeader.GradientMode = CType(resources.GetObject("gcolDisease.AppearanceHeader.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.gcolDisease.AppearanceHeader.Image = CType(resources.GetObject("gcolDisease.AppearanceHeader.Image"), System.Drawing.Image)
        Me.gcolDisease.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolDisease, "gcolDisease")
        Me.gcolDisease.FieldName = "strDiagnosis"
        Me.gcolDisease.Name = "gcolDisease"
        '
        'gcolCaseDate
        '
        Me.gcolCaseDate.AppearanceHeader.GradientMode = CType(resources.GetObject("gcolCaseDate.AppearanceHeader.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.gcolCaseDate.AppearanceHeader.Image = CType(resources.GetObject("gcolCaseDate.AppearanceHeader.Image"), System.Drawing.Image)
        Me.gcolCaseDate.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolCaseDate, "gcolCaseDate")
        Me.gcolCaseDate.FieldName = "datEnteredDate"
        Me.gcolCaseDate.Name = "gcolCaseDate"
        '
        'gcolCaseStatus
        '
        Me.gcolCaseStatus.AppearanceHeader.GradientMode = CType(resources.GetObject("gcolCaseStatus.AppearanceHeader.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.gcolCaseStatus.AppearanceHeader.Image = CType(resources.GetObject("gcolCaseStatus.AppearanceHeader.Image"), System.Drawing.Image)
        Me.gcolCaseStatus.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolCaseStatus, "gcolCaseStatus")
        Me.gcolCaseStatus.FieldName = "strCaseStatus"
        Me.gcolCaseStatus.Name = "gcolCaseStatus"
        Me.gcolCaseStatus.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(CType(resources.GetObject("gcolCaseStatus.Summary"), DevExpress.Data.SummaryItemType), resources.GetString("gcolCaseStatus.Summary1"), resources.GetString("gcolCaseStatus.Summary2"))})
        '
        'gcolLocation
        '
        Me.gcolLocation.AppearanceHeader.GradientMode = CType(resources.GetObject("gcolLocation.AppearanceHeader.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.gcolLocation.AppearanceHeader.Image = CType(resources.GetObject("gcolLocation.AppearanceHeader.Image"), System.Drawing.Image)
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
        'btnAddHumanCase
        '
        resources.ApplyResources(Me.btnAddHumanCase, "btnAddHumanCase")
        Me.btnAddHumanCase.Appearance.GradientMode = CType(resources.GetObject("btnAddHumanCase.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.btnAddHumanCase.Appearance.Image = CType(resources.GetObject("btnAddHumanCase.Appearance.Image"), System.Drawing.Image)
        Me.btnAddHumanCase.Appearance.Options.UseTextOptions = True
        Me.btnAddHumanCase.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.btnAddHumanCase.Image = CType(resources.GetObject("btnAddHumanCase.Image"), System.Drawing.Image)
        Me.btnAddHumanCase.Name = "btnAddHumanCase"
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
        Me.dtpStartDate.Properties.AccessibleDescription = resources.GetString("dtpStartDate.Properties.AccessibleDescription")
        Me.dtpStartDate.Properties.AccessibleName = resources.GetString("dtpStartDate.Properties.AccessibleName")
        Me.dtpStartDate.Properties.Appearance.GradientMode = CType(resources.GetObject("dtpStartDate.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpStartDate.Properties.Appearance.Image = CType(resources.GetObject("dtpStartDate.Properties.Appearance.Image"), System.Drawing.Image)
        Me.dtpStartDate.Properties.Appearance.Options.UseFont = True
        Me.dtpStartDate.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("dtpStartDate.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpStartDate.Properties.AppearanceDisabled.Image = CType(resources.GetObject("dtpStartDate.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.dtpStartDate.Properties.AppearanceDisabled.Options.UseFont = True
        Me.dtpStartDate.Properties.AppearanceDropDown.GradientMode = CType(resources.GetObject("dtpStartDate.Properties.AppearanceDropDown.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpStartDate.Properties.AppearanceDropDown.Image = CType(resources.GetObject("dtpStartDate.Properties.AppearanceDropDown.Image"), System.Drawing.Image)
        Me.dtpStartDate.Properties.AppearanceDropDown.Options.UseFont = True
        Me.dtpStartDate.Properties.AppearanceDropDownHeader.GradientMode = CType(resources.GetObject("dtpStartDate.Properties.AppearanceDropDownHeader.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpStartDate.Properties.AppearanceDropDownHeader.Image = CType(resources.GetObject("dtpStartDate.Properties.AppearanceDropDownHeader.Image"), System.Drawing.Image)
        Me.dtpStartDate.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.dtpStartDate.Properties.AppearanceDropDownHeaderHighlight.GradientMode = CType(resources.GetObject("dtpStartDate.Properties.AppearanceDropDownHeaderHighlight.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpStartDate.Properties.AppearanceDropDownHeaderHighlight.Image = CType(resources.GetObject("dtpStartDate.Properties.AppearanceDropDownHeaderHighlight.Image"), System.Drawing.Image)
        Me.dtpStartDate.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = True
        Me.dtpStartDate.Properties.AppearanceDropDownHighlight.GradientMode = CType(resources.GetObject("dtpStartDate.Properties.AppearanceDropDownHighlight.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpStartDate.Properties.AppearanceDropDownHighlight.Image = CType(resources.GetObject("dtpStartDate.Properties.AppearanceDropDownHighlight.Image"), System.Drawing.Image)
        Me.dtpStartDate.Properties.AppearanceDropDownHighlight.Options.UseFont = True
        Me.dtpStartDate.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("dtpStartDate.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpStartDate.Properties.AppearanceFocused.Image = CType(resources.GetObject("dtpStartDate.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.dtpStartDate.Properties.AppearanceFocused.Options.UseFont = True
        Me.dtpStartDate.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("dtpStartDate.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpStartDate.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("dtpStartDate.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.dtpStartDate.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.dtpStartDate.Properties.AppearanceWeekNumber.GradientMode = CType(resources.GetObject("dtpStartDate.Properties.AppearanceWeekNumber.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.dtpStartDate.Properties.AppearanceWeekNumber.Image = CType(resources.GetObject("dtpStartDate.Properties.AppearanceWeekNumber.Image"), System.Drawing.Image)
        Me.dtpStartDate.Properties.AppearanceWeekNumber.Options.UseFont = True
        Me.dtpStartDate.Properties.AutoHeight = CType(resources.GetObject("dtpStartDate.Properties.AutoHeight"), Boolean)
        Me.dtpStartDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtpStartDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtpStartDate.Properties.Mask.AutoComplete = CType(resources.GetObject("dtpStartDate.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.dtpStartDate.Properties.Mask.BeepOnError = CType(resources.GetObject("dtpStartDate.Properties.Mask.BeepOnError"), Boolean)
        Me.dtpStartDate.Properties.Mask.EditMask = resources.GetString("dtpStartDate.Properties.Mask.EditMask")
        Me.dtpStartDate.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtpStartDate.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtpStartDate.Properties.Mask.MaskType = CType(resources.GetObject("dtpStartDate.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtpStartDate.Properties.Mask.PlaceHolder = CType(resources.GetObject("dtpStartDate.Properties.Mask.PlaceHolder"), Char)
        Me.dtpStartDate.Properties.Mask.SaveLiteral = CType(resources.GetObject("dtpStartDate.Properties.Mask.SaveLiteral"), Boolean)
        Me.dtpStartDate.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtpStartDate.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtpStartDate.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("dtpStartDate.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.dtpStartDate.Properties.NullValuePrompt = resources.GetString("dtpStartDate.Properties.NullValuePrompt")
        Me.dtpStartDate.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("dtpStartDate.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.dtpStartDate.Properties.VistaTimeProperties.AccessibleDescription = resources.GetString("dtpStartDate.Properties.VistaTimeProperties.AccessibleDescription")
        Me.dtpStartDate.Properties.VistaTimeProperties.AccessibleName = resources.GetString("dtpStartDate.Properties.VistaTimeProperties.AccessibleName")
        Me.dtpStartDate.Properties.VistaTimeProperties.AutoHeight = CType(resources.GetObject("dtpStartDate.Properties.VistaTimeProperties.AutoHeight"), Boolean)
        Me.dtpStartDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtpStartDate.Properties.VistaTimeProperties.Mask.AutoComplete = CType(resources.GetObject("dtpStartDate.Properties.VistaTimeProperties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.dtpStartDate.Properties.VistaTimeProperties.Mask.BeepOnError = CType(resources.GetObject("dtpStartDate.Properties.VistaTimeProperties.Mask.BeepOnError"), Boolean)
        Me.dtpStartDate.Properties.VistaTimeProperties.Mask.EditMask = resources.GetString("dtpStartDate.Properties.VistaTimeProperties.Mask.EditMask")
        Me.dtpStartDate.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtpStartDate.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtpStartDate.Properties.VistaTimeProperties.Mask.MaskType = CType(resources.GetObject("dtpStartDate.Properties.VistaTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtpStartDate.Properties.VistaTimeProperties.Mask.PlaceHolder = CType(resources.GetObject("dtpStartDate.Properties.VistaTimeProperties.Mask.PlaceHolder"), Char)
        Me.dtpStartDate.Properties.VistaTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("dtpStartDate.Properties.VistaTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.dtpStartDate.Properties.VistaTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtpStartDate.Properties.VistaTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtpStartDate.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("dtpStartDate.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.dtpStartDate.Properties.VistaTimeProperties.NullValuePrompt = resources.GetString("dtpStartDate.Properties.VistaTimeProperties.NullValuePrompt")
        Me.dtpStartDate.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("dtpStartDate.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue"), Boolean)
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
        'cbOutbreak_Status
        '
        resources.ApplyResources(Me.cbOutbreak_Status, "cbOutbreak_Status")
        Me.cbOutbreak_Status.Name = "cbOutbreak_Status"
        Me.cbOutbreak_Status.Properties.AccessibleDescription = resources.GetString("cbOutbreak_Status.Properties.AccessibleDescription")
        Me.cbOutbreak_Status.Properties.AccessibleName = resources.GetString("cbOutbreak_Status.Properties.AccessibleName")
        Me.cbOutbreak_Status.Properties.AutoHeight = CType(resources.GetObject("cbOutbreak_Status.Properties.AutoHeight"), Boolean)
        Me.cbOutbreak_Status.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbOutbreak_Status.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbOutbreak_Status.Properties.NullText = resources.GetString("cbOutbreak_Status.Properties.NullText")
        Me.cbOutbreak_Status.Properties.NullValuePrompt = resources.GetString("cbOutbreak_Status.Properties.NullValuePrompt")
        Me.cbOutbreak_Status.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("cbOutbreak_Status.Properties.NullValuePromptShowForEmptyValue"), Boolean)
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
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem3})
        resources.ApplyResources(Me.ContextMenu1, "ContextMenu1")
        '
        'MenuItem3
        '
        resources.ApplyResources(Me.MenuItem3, "MenuItem3")
        Me.MenuItem3.Index = 0
        '
        'PopUpButton1
        '
        resources.ApplyResources(Me.PopUpButton1, "PopUpButton1")
        Me.PopUpButton1.ButtonType = bv.common.win.PopUpButton.PopUpButtonStyles.Reports
        Me.PopUpButton1.Name = "PopUpButton1"
        Me.PopUpButton1.PopUpMenu = Me.ContextMenu1
        Me.PopUpButton1.TabStop = False
        Me.PopUpButton1.Tag = "{Immovable}{AlwaysEditable}"
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
        Me.txtOutbreakID.Properties.AccessibleDescription = resources.GetString("txtOutbreakID.Properties.AccessibleDescription")
        Me.txtOutbreakID.Properties.AccessibleName = resources.GetString("txtOutbreakID.Properties.AccessibleName")
        Me.txtOutbreakID.Properties.AutoHeight = CType(resources.GetObject("txtOutbreakID.Properties.AutoHeight"), Boolean)
        Me.txtOutbreakID.Properties.Mask.AutoComplete = CType(resources.GetObject("txtOutbreakID.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtOutbreakID.Properties.Mask.BeepOnError = CType(resources.GetObject("txtOutbreakID.Properties.Mask.BeepOnError"), Boolean)
        Me.txtOutbreakID.Properties.Mask.EditMask = resources.GetString("txtOutbreakID.Properties.Mask.EditMask")
        Me.txtOutbreakID.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtOutbreakID.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtOutbreakID.Properties.Mask.MaskType = CType(resources.GetObject("txtOutbreakID.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtOutbreakID.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtOutbreakID.Properties.Mask.PlaceHolder"), Char)
        Me.txtOutbreakID.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtOutbreakID.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtOutbreakID.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtOutbreakID.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtOutbreakID.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtOutbreakID.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtOutbreakID.Properties.NullValuePrompt = resources.GetString("txtOutbreakID.Properties.NullValuePrompt")
        Me.txtOutbreakID.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtOutbreakID.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.txtOutbreakID.TabStop = False
        Me.txtOutbreakID.Tag = "[en]"
        '
        'cbGeoLocation
        '
        resources.ApplyResources(Me.cbGeoLocation, "cbGeoLocation")
        Me.cbGeoLocation.Appearance.BackColor = CType(resources.GetObject("cbGeoLocation.Appearance.BackColor"), System.Drawing.Color)
        Me.cbGeoLocation.Appearance.GradientMode = CType(resources.GetObject("cbGeoLocation.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.cbGeoLocation.Appearance.Image = CType(resources.GetObject("cbGeoLocation.Appearance.Image"), System.Drawing.Image)
        Me.cbGeoLocation.Appearance.Options.UseBackColor = True
        Me.cbGeoLocation.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.cbGeoLocation.FormID = Nothing
        Me.cbGeoLocation.HelpTopicID = Nothing
        Me.cbGeoLocation.IsLocationChanged = False
        Me.cbGeoLocation.IsStatusReadOnly = False
        Me.cbGeoLocation.KeyFieldName = Nothing
        Me.cbGeoLocation.LookupLayout = bv.common.win.LookupFormLayout.DropDownList
        Me.cbGeoLocation.MultiSelect = False
        Me.cbGeoLocation.Name = "cbGeoLocation"
        Me.cbGeoLocation.ObjectName = Nothing
        Me.cbGeoLocation.Status = bv.common.win.FormStatus.Draft
        Me.cbGeoLocation.TableName = Nothing
        TagHelper1.Binder = Nothing
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
        TagHelper1.StringTag = ""
        TagHelper1.Tag = Nothing
        Me.cbGeoLocation.Tag = TagHelper1
        '
        'txtDescription
        '
        resources.ApplyResources(Me.txtDescription, "txtDescription")
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Properties.AccessibleDescription = resources.GetString("txtDescription.Properties.AccessibleDescription")
        Me.txtDescription.Properties.AccessibleName = resources.GetString("txtDescription.Properties.AccessibleName")
        Me.txtDescription.Properties.NullValuePrompt = resources.GetString("txtDescription.Properties.NullValuePrompt")
        Me.txtDescription.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtDescription.Properties.NullValuePromptShowForEmptyValue"), Boolean)
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
        resources.ApplyResources(Me.tbGeneralInfo, "tbGeneralInfo")
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
        '
        'txtPrimaryCase
        '
        resources.ApplyResources(Me.txtPrimaryCase, "txtPrimaryCase")
        Me.txtPrimaryCase.Name = "txtPrimaryCase"
        Me.txtPrimaryCase.Properties.AccessibleDescription = resources.GetString("txtPrimaryCase.Properties.AccessibleDescription")
        Me.txtPrimaryCase.Properties.AccessibleName = resources.GetString("txtPrimaryCase.Properties.AccessibleName")
        Me.txtPrimaryCase.Properties.AutoHeight = CType(resources.GetObject("txtPrimaryCase.Properties.AutoHeight"), Boolean)
        Me.txtPrimaryCase.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtPrimaryCase.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtPrimaryCase.Properties.Mask.AutoComplete = CType(resources.GetObject("txtPrimaryCase.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtPrimaryCase.Properties.Mask.BeepOnError = CType(resources.GetObject("txtPrimaryCase.Properties.Mask.BeepOnError"), Boolean)
        Me.txtPrimaryCase.Properties.Mask.EditMask = resources.GetString("txtPrimaryCase.Properties.Mask.EditMask")
        Me.txtPrimaryCase.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtPrimaryCase.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtPrimaryCase.Properties.Mask.MaskType = CType(resources.GetObject("txtPrimaryCase.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtPrimaryCase.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtPrimaryCase.Properties.Mask.PlaceHolder"), Char)
        Me.txtPrimaryCase.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtPrimaryCase.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtPrimaryCase.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtPrimaryCase.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtPrimaryCase.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtPrimaryCase.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtPrimaryCase.Properties.NullValuePrompt = resources.GetString("txtPrimaryCase.Properties.NullValuePrompt")
        Me.txtPrimaryCase.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtPrimaryCase.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.txtPrimaryCase.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'lbPrimaryCase
        '
        resources.ApplyResources(Me.lbPrimaryCase, "lbPrimaryCase")
        Me.lbPrimaryCase.Name = "lbPrimaryCase"
        '
        'tbNotes
        '
        resources.ApplyResources(Me.tbNotes, "tbNotes")
        Me.tbNotes.Controls.Add(Me.btnDeleteNote)
        Me.tbNotes.Controls.Add(Me.NotesGrid)
        Me.tbNotes.Name = "tbNotes"
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
        Me.NotesGrid.EmbeddedNavigator.AccessibleDescription = resources.GetString("NotesGrid.EmbeddedNavigator.AccessibleDescription")
        Me.NotesGrid.EmbeddedNavigator.AccessibleName = resources.GetString("NotesGrid.EmbeddedNavigator.AccessibleName")
        Me.NotesGrid.EmbeddedNavigator.AllowHtmlTextInToolTip = CType(resources.GetObject("NotesGrid.EmbeddedNavigator.AllowHtmlTextInToolTip"), DevExpress.Utils.DefaultBoolean)
        Me.NotesGrid.EmbeddedNavigator.Anchor = CType(resources.GetObject("NotesGrid.EmbeddedNavigator.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.NotesGrid.EmbeddedNavigator.BackgroundImage = CType(resources.GetObject("NotesGrid.EmbeddedNavigator.BackgroundImage"), System.Drawing.Image)
        Me.NotesGrid.EmbeddedNavigator.BackgroundImageLayout = CType(resources.GetObject("NotesGrid.EmbeddedNavigator.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.NotesGrid.EmbeddedNavigator.ImeMode = CType(resources.GetObject("NotesGrid.EmbeddedNavigator.ImeMode"), System.Windows.Forms.ImeMode)
        Me.NotesGrid.EmbeddedNavigator.TextLocation = CType(resources.GetObject("NotesGrid.EmbeddedNavigator.TextLocation"), DevExpress.XtraEditors.NavigatorButtonsTextLocation)
        Me.NotesGrid.EmbeddedNavigator.ToolTip = resources.GetString("NotesGrid.EmbeddedNavigator.ToolTip")
        Me.NotesGrid.EmbeddedNavigator.ToolTipIconType = CType(resources.GetObject("NotesGrid.EmbeddedNavigator.ToolTipIconType"), DevExpress.Utils.ToolTipIconType)
        Me.NotesGrid.EmbeddedNavigator.ToolTipTitle = resources.GetString("NotesGrid.EmbeddedNavigator.ToolTipTitle")
        Me.NotesGrid.MainView = Me.NotesView
        Me.NotesGrid.Name = "NotesGrid"
        Me.NotesGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.txtNote, Me.dtNoteDate, Me.cbNotePerson})
        Me.NotesGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.NotesView})
        '
        'NotesView
        '
        resources.ApplyResources(Me.NotesView, "NotesView")
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
        resources.ApplyResources(Me.txtNote, "txtNote")
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
        '
        'dtNoteDate
        '
        resources.ApplyResources(Me.dtNoteDate, "dtNoteDate")
        Me.dtNoteDate.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtNoteDate.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtNoteDate.Mask.AutoComplete = CType(resources.GetObject("dtNoteDate.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.dtNoteDate.Mask.BeepOnError = CType(resources.GetObject("dtNoteDate.Mask.BeepOnError"), Boolean)
        Me.dtNoteDate.Mask.EditMask = resources.GetString("dtNoteDate.Mask.EditMask")
        Me.dtNoteDate.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtNoteDate.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtNoteDate.Mask.MaskType = CType(resources.GetObject("dtNoteDate.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtNoteDate.Mask.PlaceHolder = CType(resources.GetObject("dtNoteDate.Mask.PlaceHolder"), Char)
        Me.dtNoteDate.Mask.SaveLiteral = CType(resources.GetObject("dtNoteDate.Mask.SaveLiteral"), Boolean)
        Me.dtNoteDate.Mask.ShowPlaceHolders = CType(resources.GetObject("dtNoteDate.Mask.ShowPlaceHolders"), Boolean)
        Me.dtNoteDate.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("dtNoteDate.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.dtNoteDate.Name = "dtNoteDate"
        Me.dtNoteDate.VistaTimeProperties.AccessibleDescription = resources.GetString("dtNoteDate.VistaTimeProperties.AccessibleDescription")
        Me.dtNoteDate.VistaTimeProperties.AccessibleName = resources.GetString("dtNoteDate.VistaTimeProperties.AccessibleName")
        Me.dtNoteDate.VistaTimeProperties.AutoHeight = CType(resources.GetObject("dtNoteDate.VistaTimeProperties.AutoHeight"), Boolean)
        Me.dtNoteDate.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dtNoteDate.VistaTimeProperties.Mask.AutoComplete = CType(resources.GetObject("dtNoteDate.VistaTimeProperties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.dtNoteDate.VistaTimeProperties.Mask.BeepOnError = CType(resources.GetObject("dtNoteDate.VistaTimeProperties.Mask.BeepOnError"), Boolean)
        Me.dtNoteDate.VistaTimeProperties.Mask.EditMask = resources.GetString("dtNoteDate.VistaTimeProperties.Mask.EditMask")
        Me.dtNoteDate.VistaTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtNoteDate.VistaTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtNoteDate.VistaTimeProperties.Mask.MaskType = CType(resources.GetObject("dtNoteDate.VistaTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtNoteDate.VistaTimeProperties.Mask.PlaceHolder = CType(resources.GetObject("dtNoteDate.VistaTimeProperties.Mask.PlaceHolder"), Char)
        Me.dtNoteDate.VistaTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("dtNoteDate.VistaTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.dtNoteDate.VistaTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtNoteDate.VistaTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtNoteDate.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("dtNoteDate.VistaTimeProperties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.dtNoteDate.VistaTimeProperties.NullValuePrompt = resources.GetString("dtNoteDate.VistaTimeProperties.NullValuePrompt")
        Me.dtNoteDate.VistaTimeProperties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("dtNoteDate.VistaTimeProperties.NullValuePromptShowForEmptyValue"), Boolean)
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
        Me.Controls.Add(Me.PopUpButton1)
        Me.FormID = "C11"
        Me.HelpTopicID = "outbreak_details"
        Me.KeyFieldName = "idfOutbreak"
        Me.LeftIcon = CType(resources.GetObject("$this.LeftIcon"), System.Drawing.Image)
        Me.Name = "OutbreakDetail"
        Me.ObjectName = "Outbreak"
        Me.TableName = "Outbreak"
        Me.Controls.SetChildIndex(Me.cmdOk, 0)
        Me.Controls.SetChildIndex(Me.PopUpButton1, 0)
        Me.Controls.SetChildIndex(Me.tcOutbreak, 0)
        CType(Me.cbDiagnosis.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpEndDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpEndDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbRelatedCaseReports.ResumeLayout(False)
        CType(Me.gcCaseList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvCaseList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpStartDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpStartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.dtNoteDate.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
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
        Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Create, "MenuNewOutbreak", 415)
        ma.ShowInToolbar = False
        ma.SmallIconIndex = MenuIconsSmall.Outbreak
        ma.Name = "btnNewOutbreak"
        ma.Order = 415
        ma.SelectPermission = PermissionHelper.InsertPermission(EIDSS.model.Enums.EIDSSPermissionObject.Outbreak)
        ma = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals, "ToolbarNewOutbreak", 206)
        ma.ShowInToolbar = True
        ma.ShowInMenu = False
        ma.BigIconIndex = MenuIcons.NewOutBreak
        ma.Name = "btnNewOutbreak1"
        ma.Order = 206
        ma.SelectPermission = PermissionHelper.InsertPermission(EIDSS.model.Enums.EIDSSPermissionObject.Outbreak)
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
    Public Overrides Function ValidateData() As Boolean
        If Not baseDataSet.Tables("Outbreak").Rows(0)("datStartDate") Is DBNull.Value AndAlso _
            Not baseDataSet.Tables("Outbreak").Rows(0)("datFinishDate") Is DBNull.Value Then
            Dim StartDate As Date = CDate(baseDataSet.Tables("Outbreak").Rows(0)("datStartDate"))
            Dim FinishDate As Date = CDate(baseDataSet.Tables("Outbreak").Rows(0)("datFinishDate"))
            If StartDate.CompareTo(FinishDate) >= 0 Then
                win.ErrorForm.ShowWarningDirect(EidssMessages.Get("Start date_End date"))
                Return False
            End If
        End If
        Return MyBase.ValidateData()
    End Function

    Private CanAddViewRemove As Boolean = True

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

        Core.LookupBinder.BindDiagnosisLookup(cbDiagnosis, baseDataSet, "Outbreak.idfsDiagnosis")
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
        btnAddHumanCase.Enabled = CanAddViewRemove And New StandardAccessPermissions(EIDSSPermissionObject.HumanCase).CanSelect
        btnAddVetCase.Enabled = CanAddViewRemove And New StandardAccessPermissions(EIDSSPermissionObject.VetCase).CanSelect
        btnRemove.Enabled = CanAddViewRemove
        btnDeleteNote.Enabled = CanAddViewRemove
        btnViewCaseDetails.Enabled = CanAddViewRemove
        'gcCaseList.Enabled = CanAddViewRemove
        If (Not StartUpParameters Is Nothing) AndAlso (StartUpParameters.ContainsKey("ReadOnly")) AndAlso (TypeOf (StartUpParameters("ReadOnly")) Is Boolean) AndAlso (Me.ReadOnly <> CBool(StartUpParameters("ReadOnly"))) Then
            Me.ReadOnly = CBool(StartUpParameters("ReadOnly"))
        End If

    End Sub


    Private Sub btnHumanAddCase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddHumanCase.Click
        Dim humanCase As IObject
        humanCase = BaseFormManager.ShowForSelection(CType(ClassLoader.LoadClass("HumanCaseListPanel"), IBaseListPanel), FindForm, , 1024, 800)
        If Not humanCase Is Nothing Then
            If OutbreakDbService.CanCaseBeAddedToOutbreak(humanCase.GetValue("idfCase")) = True Then
                If OutbreakDbService.IsCaseInOutbreak(humanCase.GetValue("idfCase"), OutbreakDbService.ID) = True Then
                    Dim dlgRes As DialogResult = MessageForm.Show(EidssMessages.Get("msgCaseInOutbreak", "Remove this case from another outbreak?"), BvMessages.Get("Confirmation"), MessageBoxButtons.YesNoCancel)
                    If dlgRes = DialogResult.Yes Then
                        AddHumanCase(humanCase)
                    End If
                Else
                    AddHumanCase(humanCase)
                End If
            Else
                MessageForm.Show(EidssMessages.Get("mbCannotAddCaseToOutbreak", "It is impossible to add this case because it is marked as not related to any outbreak."))
            End If
        End If
    End Sub
    Private Sub btnAddVetCase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddVetCase.Click
        Dim vetCase As IObject
        vetCase = BaseFormManager.ShowForSelection(CType(ClassLoader.LoadClass("VetCaseListPanel"), IBaseListPanel), FindForm, , 1024, 800)
        If Not vetCase Is Nothing Then
            If OutbreakDbService.IsCaseInOutbreak(vetCase.GetValue("idfCase"), OutbreakDbService.ID) = True Then
                Dim dlgRes As DialogResult = MessageForm.Show(EidssMessages.Get("msgCaseInOutbreak", "Remove this case from another outbreak?"), BvMessages.Get("Confirmation"), MessageBoxButtons.YesNoCancel)
                If dlgRes = DialogResult.Yes Then
                    AddVetCase(vetCase)
                End If
            Else
                AddVetCase(vetCase)
            End If
        End If
    End Sub


    Private Function FocusedCaseRowHandle(ByVal TempDRow As DataRow) As Integer
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

    Private Function CaseExists(ByVal CaseDRow As DataRow) As Boolean
        Dim CaseListDTable As DataTable = baseDataSet.Tables("CaseList")
        Dim TempDRow As DataRow = CaseListDTable.Rows.Find(CaseDRow("idfCase"))
        Return Not ((TempDRow Is Nothing) OrElse (TempDRow.RowState = DataRowState.Deleted))
    End Function

    Private Sub AddHumanCase(ByVal humanCase As IObject)
        Dim CaseListDTable As DataTable = baseDataSet.Tables("CaseList")
        Dim row As DataRow = CaseListDTable.Rows.Find(humanCase.GetValue("idfCase"))
        If (row Is Nothing) OrElse (row.RowState = DataRowState.Deleted) Then
            row = CaseListDTable.NewRow()
            row("idfCase") = humanCase.GetValue("idfCase")
            row("datEnteredDate") = humanCase.GetValue("datEnteredDate")
            row("strCaseID") = humanCase.GetValue("strCaseID")
            row("idfsCaseType") = CLng(CaseType.Human)
            row("idfGeoLocation") = humanCase.GetValue("idfGeoLocation")
            row("idfAddress") = humanCase.GetValue("idfAddress")
            row("strGeoLocation") = EIDSS_DbUtils.GetGeoLocaionString(CLng(humanCase.GetValue("idfGeoLocation")))
            row("strAddress") = EIDSS_DbUtils.GetAddressString(humanCase.GetValue("idfAddress"))
            row("strDiagnosis") = humanCase.GetValue("DiagnosisName")
            row("strCaseStatus") = humanCase.GetValue("CaseStatusName")
            row("idfOutbreak") = GetKey()
            row("Confirmed") = IIf(350000000.Equals(humanCase.GetValue("idfsCaseStatus")), 1, 0)
            row("strPatientName") = humanCase.GetValue("PatientName")
            CaseListDTable.Rows.Add(row)
            If baseDataSet.Tables("CaseList").DefaultView.Count = 1 AndAlso baseDataSet.Tables("Outbreak").Rows(0)("idfsDiagnosis") Is DBNull.Value Then
                baseDataSet.Tables("Outbreak").Rows(0)("idfsDiagnosis") = humanCase.GetValue("idfsDiagnosis")
                baseDataSet.Tables("Outbreak").Rows(0).EndEdit()
            End If
            CopyLocation(humanCase.GetValue("idfGeoLocation"), humanCase.GetValue("idfAddress"))


            OutbreakDbService.RefreshCaseInfo(baseDataSet, row("idfCase"))

        Else
            gvCaseList.FocusedRowHandle = FocusedCaseRowHandle(row)
        End If
    End Sub

    Private Sub AddVetCase(ByVal vetCase As IObject)
        Dim CaseListDTable As DataTable = baseDataSet.Tables("CaseList")
        Dim row As DataRow = CaseListDTable.Rows.Find(vetCase.GetValue("idfCase"))
        If (row Is Nothing) OrElse (row.RowState = DataRowState.Deleted) Then
            row = CaseListDTable.NewRow()
            row("idfCase") = vetCase.GetValue("idfCase")
            row("datEnteredDate") = vetCase.GetValue("datEnteredDate")
            row("strCaseID") = vetCase.GetValue("strCaseID")
            row("idfsCaseType") = vetCase.GetValue("idfsCaseType")
            row("idfGeoLocation") = vetCase.GetValue("idfGeoLocation")
            row("idfAddress") = vetCase.GetValue("idfAddress")
            row("strGeoLocation") = EIDSS_DbUtils.GetGeoLocaionString(vetCase.GetValue("idfGeoLocation"))
            row("strAddress") = EIDSS_DbUtils.GetAddressString(vetCase.GetValue("idfAddress"))
            row("strDiagnosis") = vetCase.GetValue("DiagnosisName")
            row("strCaseStatus") = vetCase.GetValue("CaseClassificationName")
            row("Confirmed") = IIf(350000000.Equals(vetCase.GetValue("idfsCaseStatus")), 1, 0)
            row("idfOutbreak") = GetKey()
            CaseListDTable.Rows.Add(row)
            If baseDataSet.Tables("CaseList").DefaultView.Count = 1 AndAlso baseDataSet.Tables("Outbreak").Rows(0)("idfsDiagnosis") Is DBNull.Value Then
                baseDataSet.Tables("Outbreak").Rows(0)("idfsDiagnosis") = IIf(vetCase.GetValue("idfsDiagnosis") Is Nothing, DBNull.Value, vetCase.GetValue("idfsDiagnosis"))
                baseDataSet.Tables("Outbreak").Rows(0).EndEdit()
            End If
            CopyLocation(vetCase.GetValue("idfGeoLocation"), vetCase.GetValue("idfAddress"))

            OutbreakDbService.RefreshCaseInfo(baseDataSet, row("idfCase"))

        Else
            gvCaseList.FocusedRowHandle = FocusedCaseRowHandle(row)
        End If
    End Sub

    Private Sub btnRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If BindingContext(baseDataSet, "CaseList").Count > 0 Then
            Dim row As DataRowView = CType(BindingContext(baseDataSet, "CaseList").Current, DataRowView)
            If Not row Is Nothing Then
                If WinUtils.ConfirmMessage(EidssMessages.Get("msgRemoveCaseFromOutbreak", "Remove case from outbreak?"), EidssMessages.Get("msgRemoveConfirmation", "Remove confirnmation?")) Then
                    If (Utils.Str(row("idfCase")) = Utils.Str(baseDataSet.Tables("Outbreak").Rows(0)("idfPrimaryCase"))) Then
                        ClearPrimaryCase()
                    End If
                    row.Delete()
                End If
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
        Dim frmCase As BaseForm = Nothing
        Select Case CType(row("idfsCaseType"), CaseType)
            Case CaseType.Human
                frmCase = CType(ClassLoader.LoadClass("HumanCaseDetail"), bv.common.win.BaseForm)
                frmCase.GetType.GetProperty("ShowNavigators", GetType(Boolean)).SetValue(frmCase, False, Nothing)
            Case CaseType.Livestock
                frmCase = CType(ClassLoader.LoadClass("VetCaseLiveStockDetail"), bv.common.win.BaseForm)
            Case CaseType.Avian
                frmCase = CType(ClassLoader.LoadClass("VetCaseAvianDetail"), bv.common.win.BaseForm)
        End Select
        If frmCase Is Nothing Then
            Return
        End If
        'BaseFormManager.ShowModal_ReadOnly(frmCase, FindForm, caseID, Nothing, Nothing)
        If (Not BaseFormManager.FindFormByID(frmCase.GetType(), caseID) Is Nothing) Then
            BaseFormManager.ShowModal_ReadOnly(frmCase, FindForm, caseID, Nothing, Nothing)
        Else
            RefreshCaseInfo = BaseFormManager.ShowModal(frmCase, FindForm, caseID, Nothing, Nothing)
        End If
        If RefreshCaseInfo Then
            OutbreakDbService.RefreshCaseInfo(baseDataSet, caseID)
            RefreshPrimaryCaseInfo(row)
        End If

    End Sub

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

    Public Overrides Function GetChildKey(ByVal child As bv.common.win.IRelatedObject) As Object
        If child Is cbGeoLocation Then
            Return baseDataSet.Tables("Outbreak").Rows(0)("idfGeoLocation")
        End If
        Return MyBase.GetChildKey(child)
    End Function

    Private Sub CopyLocation(ByVal idfGeoLocation As Object, ByVal idfAddress As Object)
        If baseDataSet.Tables("CaseList").DefaultView.Count = 1 AndAlso (Utils.Str(cbGeoLocation.DisplayText) = "") Then
            Dim oldLocation As Object = cbGeoLocation.ID
            cbGeoLocation.LoadData(idfGeoLocation)
            cbGeoLocation.baseDataSet.Tables("GeoLocation").Rows(0)("idfGeoLocation") = oldLocation
            If Utils.Str(cbGeoLocation.DisplayText) = "" Then 'case location is not defined, populate address Country, Region, Rayon into location
                cbGeoLocation.LoadData(idfAddress)
                cbGeoLocation.baseDataSet.Tables("GeoLocation").Rows(0)("idfGeoLocation") = oldLocation
                cbGeoLocation.baseDataSet.Tables("GeoLocation").Rows(0)("idfsGeoLocationType") = CLng(GeoLocationType.ExactPoint)
                'do not copy coordinates from address
                cbGeoLocation.baseDataSet.Tables("GeoLocation").Rows(0)("dblLongitude") = DBNull.Value
                cbGeoLocation.baseDataSet.Tables("GeoLocation").Rows(0)("dblLatitude") = DBNull.Value
            End If
            If CLng(CaseType.Human).Equals(baseDataSet.Tables("CaseList").Rows(0)("idfsCaseType")) Then
                If m_HideHumanSettlement Then
                    cbGeoLocation.baseDataSet.Tables("GeoLocation").Rows(0)("idfsSettlement") = DBNull.Value
                End If
            Else
                If m_HideVetSettlement Then
                    cbGeoLocation.baseDataSet.Tables("GeoLocation").Rows(0)("idfsSettlement") = DBNull.Value
                End If
                If m_HideVetLocation Then
                    cbGeoLocation.baseDataSet.Tables("GeoLocation").Rows(0)("dblLongitude") = DBNull.Value
                    cbGeoLocation.baseDataSet.Tables("GeoLocation").Rows(0)("dblLatitude") = DBNull.Value
                End If
            End If
            'cbGeoLocation.baseDataSet.Tables("GeoLocation").Rows(0).EndEdit()
            cbGeoLocation.RefreshDisplayText()
        End If

    End Sub

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

    Private Sub btnMarkAsPrimary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMarkAsPrimary.Click
        If BindingContext(baseDataSet, "CaseList").Count > 0 Then
            Dim row As DataRowView = CType(BindingContext(baseDataSet, "CaseList").Current, DataRowView)
            If Not row Is Nothing Then
                Dim CaseID As Object = row("idfCase")
                baseDataSet.Tables("Outbreak").Rows(0)("idfPrimaryCase") = CaseID
                RefreshPrimaryCaseInfo(row.Row)
            End If
        End If

    End Sub

    Private Sub RefreshPrimaryCaseInfo(caseRow As DataRow)
        If (Not baseDataSet.Tables("Outbreak").Rows(0)("idfPrimaryCase") Is DBNull.Value) Then
            If (baseDataSet.Tables("Outbreak").Rows(0)("idfPrimaryCase").Equals(caseRow("idfCase"))) Then
                baseDataSet.Tables("Outbreak").Rows(0)("strPrimaryCase") = Utils.Join(", ", New String() {Utils.Str(caseRow("strCaseID")), Utils.Str(caseRow("strDiagnosis"))})
                baseDataSet.Tables("Outbreak").Rows(0).EndEdit()
            End If
        End If
    End Sub
    Private Sub txtPrimaryCase_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtPrimaryCase.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then
            Me.Enabled = False
            Dim CaseID As Object = baseDataSet.Tables("Outbreak").Rows(0)("idfPrimaryCase")
            ShowCaseDetail(CaseID)
            Me.Enabled = True
        ElseIf e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete Then
            ClearPrimaryCase()
        End If

    End Sub
    Private Sub ClearPrimaryCase()
        baseDataSet.Tables("Outbreak").Rows(0)("idfPrimaryCase") = DBNull.Value
        baseDataSet.Tables("Outbreak").Rows(0)("strPrimaryCase") = DBNull.Value
    End Sub
    Public Overrides Sub UpdateButtonsState(ByVal sender As Object, ByVal e As System.EventArgs)
        btnAddHumanCase.Enabled = Not [ReadOnly] AndAlso CanAddViewRemove And New StandardAccessPermissions(EIDSSPermissionObject.HumanCase).CanSelect
        btnAddVetCase.Enabled = Not [ReadOnly] AndAlso CanAddViewRemove And New StandardAccessPermissions(EIDSSPermissionObject.VetCase).CanSelect
        btnRemove.Enabled = Not [ReadOnly] AndAlso CanAddViewRemove
        btnDeleteNote.Enabled = Not [ReadOnly] AndAlso CanAddViewRemove
        btnViewCaseDetails.Enabled = Not [ReadOnly] AndAlso CanAddViewRemove
        btnMarkAsPrimary.Enabled = Not [ReadOnly] AndAlso gvCaseList.FocusedRowHandle >= 0
        txtPrimaryCase.Properties.Buttons(0).Enabled = CanAddViewRemove AndAlso Not Utils.IsEmpty(txtPrimaryCase.EditValue)
    End Sub

End Class
