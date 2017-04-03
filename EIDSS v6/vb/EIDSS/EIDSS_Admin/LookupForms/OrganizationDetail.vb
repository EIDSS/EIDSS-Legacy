Imports bv.winclient.Localization
Imports bv.winclient.Core
Imports bv.common.Resources
Imports EIDSS.model.Enums

Public Class OrganizationDetail

    Inherits BaseDetailForm

    Dim OrganizationDbService As Organization_DB

#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()


        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        OrganizationDbService = New Organization_DB

        DbService = OrganizationDbService
        AddressPanel.IsSharedAddress = True
        AddressPanel.MultilineAddress = True
        AuditObject = New AuditObject(EIDSSAuditObject.daoOrganization, AuditTable.tlbOffice)
        LookupTableNames = New String() {"Organization", "Person"}
        Me.PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.Organization
        'lblTranslatedDepartmentName.Text += " (" + GlobalSettings.LanguageName(bv.model.Model.Core.ModelUserContext.CurrentLanguage) + ")"
        'lblNationalAbbreviation.Text += " (" + GlobalSettings.LanguageName(bv.model.Model.Core.ModelUserContext.CurrentLanguage).ToLower + ")"
        'lblNationalName.Text += " (" + GlobalSettings.LanguageName(bv.model.Model.Core.ModelUserContext.CurrentLanguage).ToLower + ")"
        'colNationalDepartmentName.Caption += " (" + GlobalSettings.LanguageName(bv.model.Model.Core.ModelUserContext.CurrentLanguage).ToLower + ")"
        If bv.model.Model.Core.ModelUserContext.CurrentLanguage = Localizer.lngEn Then
            Dim CurTop As Integer = 8
            Dim SmallStep As Integer = 4
            Dim shift As Integer = 26
            txtEnglishAbbreviation.Enabled = False
            txtEnglishName.Enabled = False
            colEnglishDepartmentName.Visible = False
            lblEnglishAbbreviation.Visible = False
            SetMandatoryFieldVisible(txtEnglishAbbreviation, False)
            lblNationalAbbreviation.Top -= shift
            txtNationalAbbreviation.Top -= shift
            shift += shift
            SetMandatoryFieldVisible(txtEnglishName, False)
            lblEnglishName.Visible = False
            cbAccessory.Top -= shift
            lbAccessory.Top -= shift
            lblNationalName.Top -= shift
            txtNationalName.Top -= shift
            chkForeignAddress.Top -= shift
            AddressPanel.Top -= shift
            lblPhone.Top -= shift
            txtPhone.Top -= shift
        End If
        RegisterChildObject(AddressPanel, RelatedPostOrder.PostFirst)
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
    Friend WithEvents TabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents TabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents grdDepartmentList As DevExpress.XtraGrid.GridControl
    Friend WithEvents btnDeleteDpt As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblPhone As System.Windows.Forms.Label
    Friend WithEvents txtPhone As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtNationalAbbreviation As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblNationalAbbreviation As System.Windows.Forms.Label
    Friend WithEvents txtNationalName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtEnglishName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtEnglishAbbreviation As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblNationalName As System.Windows.Forms.Label
    Friend WithEvents lblEnglishName As System.Windows.Forms.Label
    Friend WithEvents lblEnglishAbbreviation As System.Windows.Forms.Label
    Friend WithEvents colEnglishDepartmentName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNationalDepartmentName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents AddressPanel As eidss.AddressLookup
    Friend WithEvents txtOrganizationID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbOrganizationID As System.Windows.Forms.Label
    Friend WithEvents lbAccessory As System.Windows.Forms.Label
    Friend WithEvents cbAccessory As DevExpress.XtraEditors.PopupContainerEdit
    Friend WithEvents chkForeignAddress As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents DepartmentsView As DevExpress.XtraGrid.Views.Grid.GridView

    '<System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OrganizationDetail))
        Me.TabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.TabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.chkForeignAddress = New DevExpress.XtraEditors.CheckEdit()
        Me.lbAccessory = New System.Windows.Forms.Label()
        Me.cbAccessory = New DevExpress.XtraEditors.PopupContainerEdit()
        Me.txtOrganizationID = New DevExpress.XtraEditors.TextEdit()
        Me.lbOrganizationID = New System.Windows.Forms.Label()
        Me.txtEnglishAbbreviation = New DevExpress.XtraEditors.TextEdit()
        Me.txtNationalAbbreviation = New DevExpress.XtraEditors.TextEdit()
        Me.txtEnglishName = New DevExpress.XtraEditors.TextEdit()
        Me.txtNationalName = New DevExpress.XtraEditors.TextEdit()
        Me.txtPhone = New DevExpress.XtraEditors.TextEdit()
        Me.AddressPanel = New EIDSS.AddressLookup()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.lblNationalName = New System.Windows.Forms.Label()
        Me.lblEnglishName = New System.Windows.Forms.Label()
        Me.lblEnglishAbbreviation = New System.Windows.Forms.Label()
        Me.lblNationalAbbreviation = New System.Windows.Forms.Label()
        Me.TabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.grdDepartmentList = New DevExpress.XtraGrid.GridControl()
        Me.DepartmentsView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colEnglishDepartmentName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNationalDepartmentName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.btnDeleteDpt = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.chkForeignAddress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbAccessory.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOrganizationID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEnglishAbbreviation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNationalAbbreviation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEnglishName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNationalName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPhone.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.grdDepartmentList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DepartmentsView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(OrganizationDetail), resources)
        'Form Is Localizable: True
        '
        'TabControl1
        '
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.Appearance.Font = CType(resources.GetObject("TabControl1.Appearance.Font"), System.Drawing.Font)
        Me.TabControl1.Appearance.Options.UseFont = True
        Me.TabControl1.AppearancePage.Header.Font = CType(resources.GetObject("TabControl1.AppearancePage.Header.Font"), System.Drawing.Font)
        Me.TabControl1.AppearancePage.Header.Options.UseFont = True
        Me.TabControl1.AppearancePage.HeaderActive.Font = CType(resources.GetObject("TabControl1.AppearancePage.HeaderActive.Font"), System.Drawing.Font)
        Me.TabControl1.AppearancePage.HeaderActive.Options.UseFont = True
        Me.TabControl1.AppearancePage.HeaderDisabled.Font = CType(resources.GetObject("TabControl1.AppearancePage.HeaderDisabled.Font"), System.Drawing.Font)
        Me.TabControl1.AppearancePage.HeaderDisabled.Options.UseFont = True
        Me.TabControl1.AppearancePage.HeaderHotTracked.Font = CType(resources.GetObject("TabControl1.AppearancePage.HeaderHotTracked.Font"), System.Drawing.Font)
        Me.TabControl1.AppearancePage.HeaderHotTracked.Options.UseFont = True
        Me.TabControl1.AppearancePage.PageClient.Font = CType(resources.GetObject("TabControl1.AppearancePage.PageClient.Font"), System.Drawing.Font)
        Me.TabControl1.AppearancePage.PageClient.Options.UseFont = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedTabPage = Me.TabPage1
        Me.TabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.TabPage1, Me.TabPage2})
        '
        'TabPage1
        '
        Me.TabPage1.Appearance.Header.Font = CType(resources.GetObject("TabPage1.Appearance.Header.Font"), System.Drawing.Font)
        Me.TabPage1.Appearance.Header.Options.UseFont = True
        Me.TabPage1.Appearance.HeaderActive.Font = CType(resources.GetObject("TabPage1.Appearance.HeaderActive.Font"), System.Drawing.Font)
        Me.TabPage1.Appearance.HeaderActive.Options.UseFont = True
        Me.TabPage1.Appearance.HeaderDisabled.Font = CType(resources.GetObject("TabPage1.Appearance.HeaderDisabled.Font"), System.Drawing.Font)
        Me.TabPage1.Appearance.HeaderDisabled.Options.UseFont = True
        Me.TabPage1.Appearance.HeaderHotTracked.Font = CType(resources.GetObject("TabPage1.Appearance.HeaderHotTracked.Font"), System.Drawing.Font)
        Me.TabPage1.Appearance.HeaderHotTracked.Options.UseFont = True
        Me.TabPage1.Appearance.PageClient.Font = CType(resources.GetObject("TabPage1.Appearance.PageClient.Font"), System.Drawing.Font)
        Me.TabPage1.Appearance.PageClient.Options.UseFont = True
        resources.ApplyResources(Me.TabPage1, "TabPage1")
        Me.TabPage1.Controls.Add(Me.chkForeignAddress)
        Me.TabPage1.Controls.Add(Me.lbAccessory)
        Me.TabPage1.Controls.Add(Me.cbAccessory)
        Me.TabPage1.Controls.Add(Me.txtOrganizationID)
        Me.TabPage1.Controls.Add(Me.lbOrganizationID)
        Me.TabPage1.Controls.Add(Me.txtEnglishAbbreviation)
        Me.TabPage1.Controls.Add(Me.txtNationalAbbreviation)
        Me.TabPage1.Controls.Add(Me.txtEnglishName)
        Me.TabPage1.Controls.Add(Me.txtNationalName)
        Me.TabPage1.Controls.Add(Me.txtPhone)
        Me.TabPage1.Controls.Add(Me.AddressPanel)
        Me.TabPage1.Controls.Add(Me.lblPhone)
        Me.TabPage1.Controls.Add(Me.lblNationalName)
        Me.TabPage1.Controls.Add(Me.lblEnglishName)
        Me.TabPage1.Controls.Add(Me.lblEnglishAbbreviation)
        Me.TabPage1.Controls.Add(Me.lblNationalAbbreviation)
        Me.TabPage1.Name = "TabPage1"
        '
        'chkForeignAddress
        '
        resources.ApplyResources(Me.chkForeignAddress, "chkForeignAddress")
        Me.chkForeignAddress.Name = "chkForeignAddress"
        Me.chkForeignAddress.Properties.Appearance.Options.UseFont = True
        Me.chkForeignAddress.Properties.Appearance.Options.UseTextOptions = True
        Me.chkForeignAddress.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkForeignAddress.Properties.AppearanceDisabled.Options.UseFont = True
        Me.chkForeignAddress.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.chkForeignAddress.Properties.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkForeignAddress.Properties.AppearanceFocused.Options.UseFont = True
        Me.chkForeignAddress.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.chkForeignAddress.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkForeignAddress.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.chkForeignAddress.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.chkForeignAddress.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkForeignAddress.Properties.Caption = resources.GetString("chkForeignAddress.Properties.Caption")
        '
        'lbAccessory
        '
        resources.ApplyResources(Me.lbAccessory, "lbAccessory")
        Me.lbAccessory.Name = "lbAccessory"
        '
        'cbAccessory
        '
        resources.ApplyResources(Me.cbAccessory, "cbAccessory")
        Me.cbAccessory.Name = "cbAccessory"
        Me.cbAccessory.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbAccessory.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbAccessory.Properties.PopupSizeable = False
        Me.cbAccessory.Properties.ShowPopupCloseButton = False
        Me.cbAccessory.Tag = "{M}"
        '
        'txtOrganizationID
        '
        resources.ApplyResources(Me.txtOrganizationID, "txtOrganizationID")
        Me.txtOrganizationID.Name = "txtOrganizationID"
        Me.txtOrganizationID.Properties.Appearance.Font = CType(resources.GetObject("txtOrganizationID.Properties.Appearance.Font"), System.Drawing.Font)
        Me.txtOrganizationID.Properties.Appearance.Options.UseFont = True
        Me.txtOrganizationID.Properties.AppearanceDisabled.Font = CType(resources.GetObject("txtOrganizationID.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.txtOrganizationID.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtOrganizationID.Properties.AppearanceFocused.Font = CType(resources.GetObject("txtOrganizationID.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.txtOrganizationID.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtOrganizationID.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("txtOrganizationID.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.txtOrganizationID.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtOrganizationID.Tag = ""
        '
        'lbOrganizationID
        '
        resources.ApplyResources(Me.lbOrganizationID, "lbOrganizationID")
        Me.lbOrganizationID.Name = "lbOrganizationID"
        '
        'txtEnglishAbbreviation
        '
        resources.ApplyResources(Me.txtEnglishAbbreviation, "txtEnglishAbbreviation")
        Me.txtEnglishAbbreviation.Name = "txtEnglishAbbreviation"
        Me.txtEnglishAbbreviation.Properties.Appearance.Font = CType(resources.GetObject("txtEnglishAbbreviation.Properties.Appearance.Font"), System.Drawing.Font)
        Me.txtEnglishAbbreviation.Properties.Appearance.Options.UseFont = True
        Me.txtEnglishAbbreviation.Properties.AppearanceDisabled.Font = CType(resources.GetObject("txtEnglishAbbreviation.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.txtEnglishAbbreviation.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtEnglishAbbreviation.Properties.AppearanceFocused.Font = CType(resources.GetObject("txtEnglishAbbreviation.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.txtEnglishAbbreviation.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtEnglishAbbreviation.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("txtEnglishAbbreviation.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.txtEnglishAbbreviation.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtEnglishAbbreviation.Tag = "[en]{M}"
        '
        'txtNationalAbbreviation
        '
        resources.ApplyResources(Me.txtNationalAbbreviation, "txtNationalAbbreviation")
        Me.txtNationalAbbreviation.Name = "txtNationalAbbreviation"
        Me.txtNationalAbbreviation.Properties.Appearance.Font = CType(resources.GetObject("txtNationalAbbreviation.Properties.Appearance.Font"), System.Drawing.Font)
        Me.txtNationalAbbreviation.Properties.Appearance.Options.UseFont = True
        Me.txtNationalAbbreviation.Properties.AppearanceDisabled.Font = CType(resources.GetObject("txtNationalAbbreviation.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.txtNationalAbbreviation.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtNationalAbbreviation.Properties.AppearanceFocused.Font = CType(resources.GetObject("txtNationalAbbreviation.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.txtNationalAbbreviation.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtNationalAbbreviation.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("txtNationalAbbreviation.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.txtNationalAbbreviation.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtNationalAbbreviation.Tag = "{M}"
        '
        'txtEnglishName
        '
        resources.ApplyResources(Me.txtEnglishName, "txtEnglishName")
        Me.txtEnglishName.Name = "txtEnglishName"
        Me.txtEnglishName.Properties.Appearance.Font = CType(resources.GetObject("txtEnglishName.Properties.Appearance.Font"), System.Drawing.Font)
        Me.txtEnglishName.Properties.Appearance.Options.UseFont = True
        Me.txtEnglishName.Properties.AppearanceDisabled.Font = CType(resources.GetObject("txtEnglishName.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.txtEnglishName.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtEnglishName.Properties.AppearanceFocused.Font = CType(resources.GetObject("txtEnglishName.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.txtEnglishName.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtEnglishName.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("txtEnglishName.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.txtEnglishName.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtEnglishName.Tag = "[en]{M}"
        '
        'txtNationalName
        '
        resources.ApplyResources(Me.txtNationalName, "txtNationalName")
        Me.txtNationalName.Name = "txtNationalName"
        Me.txtNationalName.Properties.Appearance.Font = CType(resources.GetObject("txtNationalName.Properties.Appearance.Font"), System.Drawing.Font)
        Me.txtNationalName.Properties.Appearance.Options.UseFont = True
        Me.txtNationalName.Properties.AppearanceDisabled.Font = CType(resources.GetObject("txtNationalName.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.txtNationalName.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtNationalName.Properties.AppearanceFocused.Font = CType(resources.GetObject("txtNationalName.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.txtNationalName.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtNationalName.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("txtNationalName.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.txtNationalName.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtNationalName.Tag = "{M}"
        '
        'txtPhone
        '
        resources.ApplyResources(Me.txtPhone, "txtPhone")
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Properties.Appearance.Font = CType(resources.GetObject("txtPhone.Properties.Appearance.Font"), System.Drawing.Font)
        Me.txtPhone.Properties.Appearance.Options.UseFont = True
        Me.txtPhone.Properties.AppearanceDisabled.Font = CType(resources.GetObject("txtPhone.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.txtPhone.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtPhone.Properties.AppearanceFocused.Font = CType(resources.GetObject("txtPhone.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.txtPhone.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtPhone.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("txtPhone.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.txtPhone.Properties.AppearanceReadOnly.Options.UseFont = True
        '
        'AddressPanel
        '
        resources.ApplyResources(Me.AddressPanel, "AddressPanel")
        Me.AddressPanel.Appearance.BackColor = CType(resources.GetObject("AddressPanel.Appearance.BackColor"), System.Drawing.Color)
        Me.AddressPanel.Appearance.Font = CType(resources.GetObject("AddressPanel.Appearance.Font"), System.Drawing.Font)
        Me.AddressPanel.Appearance.Options.UseBackColor = True
        Me.AddressPanel.Appearance.Options.UseFont = True
        Me.AddressPanel.CanExpand = True
        Me.AddressPanel.CaptionWidth = 177
        Me.AddressPanel.FormID = Nothing
        Me.AddressPanel.HelpTopicID = Nothing
        Me.AddressPanel.KeyFieldName = Nothing
        Me.AddressPanel.LookupLayout = bv.common.win.LookupFormLayout.Group
        Me.AddressPanel.MandatoryFields = EIDSS.AddressMandatoryFieldsType.Rayon
        Me.AddressPanel.MultiSelect = False
        Me.AddressPanel.Name = "AddressPanel"
        Me.AddressPanel.ObjectName = Nothing
        Me.AddressPanel.PopupEditHeight = 200
        Me.AddressPanel.PopupEditMinWidth = 400
        Me.AddressPanel.TableName = Nothing
        Me.AddressPanel.UseParentBackColor = True
        '
        'lblPhone
        '
        resources.ApplyResources(Me.lblPhone, "lblPhone")
        Me.lblPhone.Name = "lblPhone"
        '
        'lblNationalName
        '
        resources.ApplyResources(Me.lblNationalName, "lblNationalName")
        Me.lblNationalName.Name = "lblNationalName"
        '
        'lblEnglishName
        '
        resources.ApplyResources(Me.lblEnglishName, "lblEnglishName")
        Me.lblEnglishName.Name = "lblEnglishName"
        '
        'lblEnglishAbbreviation
        '
        resources.ApplyResources(Me.lblEnglishAbbreviation, "lblEnglishAbbreviation")
        Me.lblEnglishAbbreviation.Name = "lblEnglishAbbreviation"
        '
        'lblNationalAbbreviation
        '
        resources.ApplyResources(Me.lblNationalAbbreviation, "lblNationalAbbreviation")
        Me.lblNationalAbbreviation.Name = "lblNationalAbbreviation"
        '
        'TabPage2
        '
        Me.TabPage2.Appearance.Header.Font = CType(resources.GetObject("TabPage2.Appearance.Header.Font"), System.Drawing.Font)
        Me.TabPage2.Appearance.Header.Options.UseFont = True
        Me.TabPage2.Appearance.HeaderActive.Font = CType(resources.GetObject("TabPage2.Appearance.HeaderActive.Font"), System.Drawing.Font)
        Me.TabPage2.Appearance.HeaderActive.Options.UseFont = True
        Me.TabPage2.Appearance.HeaderDisabled.Font = CType(resources.GetObject("TabPage2.Appearance.HeaderDisabled.Font"), System.Drawing.Font)
        Me.TabPage2.Appearance.HeaderDisabled.Options.UseFont = True
        Me.TabPage2.Appearance.HeaderHotTracked.Font = CType(resources.GetObject("TabPage2.Appearance.HeaderHotTracked.Font"), System.Drawing.Font)
        Me.TabPage2.Appearance.HeaderHotTracked.Options.UseFont = True
        Me.TabPage2.Appearance.PageClient.Font = CType(resources.GetObject("TabPage2.Appearance.PageClient.Font"), System.Drawing.Font)
        Me.TabPage2.Appearance.PageClient.Options.UseFont = True
        Me.TabPage2.Controls.Add(Me.grdDepartmentList)
        Me.TabPage2.Controls.Add(Me.btnDeleteDpt)
        Me.TabPage2.Name = "TabPage2"
        resources.ApplyResources(Me.TabPage2, "TabPage2")
        '
        'grdDepartmentList
        '
        resources.ApplyResources(Me.grdDepartmentList, "grdDepartmentList")
        Me.grdDepartmentList.EmbeddedNavigator.Appearance.Font = CType(resources.GetObject("grdDepartmentList.EmbeddedNavigator.Appearance.Font"), System.Drawing.Font)
        Me.grdDepartmentList.EmbeddedNavigator.Appearance.Options.UseFont = True
        Me.grdDepartmentList.MainView = Me.DepartmentsView
        Me.grdDepartmentList.Name = "grdDepartmentList"
        Me.grdDepartmentList.TabStop = False
        Me.grdDepartmentList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.DepartmentsView})
        '
        'DepartmentsView
        '
        Me.DepartmentsView.Appearance.ColumnFilterButton.Font = CType(resources.GetObject("DepartmentsView.Appearance.ColumnFilterButton.Font"), System.Drawing.Font)
        Me.DepartmentsView.Appearance.ColumnFilterButtonActive.Font = CType(resources.GetObject("DepartmentsView.Appearance.ColumnFilterButtonActive.Font"), System.Drawing.Font)
        Me.DepartmentsView.Appearance.CustomizationFormHint.Font = CType(resources.GetObject("DepartmentsView.Appearance.CustomizationFormHint.Font"), System.Drawing.Font)
        Me.DepartmentsView.Appearance.DetailTip.Font = CType(resources.GetObject("DepartmentsView.Appearance.DetailTip.Font"), System.Drawing.Font)
        Me.DepartmentsView.Appearance.Empty.Font = CType(resources.GetObject("DepartmentsView.Appearance.Empty.Font"), System.Drawing.Font)
        Me.DepartmentsView.Appearance.EvenRow.Font = CType(resources.GetObject("DepartmentsView.Appearance.EvenRow.Font"), System.Drawing.Font)
        Me.DepartmentsView.Appearance.FilterCloseButton.Font = CType(resources.GetObject("DepartmentsView.Appearance.FilterCloseButton.Font"), System.Drawing.Font)
        Me.DepartmentsView.Appearance.FilterPanel.Font = CType(resources.GetObject("DepartmentsView.Appearance.FilterPanel.Font"), System.Drawing.Font)
        Me.DepartmentsView.Appearance.FixedLine.Font = CType(resources.GetObject("DepartmentsView.Appearance.FixedLine.Font"), System.Drawing.Font)
        Me.DepartmentsView.Appearance.FocusedCell.Font = CType(resources.GetObject("DepartmentsView.Appearance.FocusedCell.Font"), System.Drawing.Font)
        Me.DepartmentsView.Appearance.FocusedRow.Font = CType(resources.GetObject("DepartmentsView.Appearance.FocusedRow.Font"), System.Drawing.Font)
        Me.DepartmentsView.Appearance.FooterPanel.Font = CType(resources.GetObject("DepartmentsView.Appearance.FooterPanel.Font"), System.Drawing.Font)
        Me.DepartmentsView.Appearance.GroupButton.Font = CType(resources.GetObject("DepartmentsView.Appearance.GroupButton.Font"), System.Drawing.Font)
        Me.DepartmentsView.Appearance.GroupFooter.Font = CType(resources.GetObject("DepartmentsView.Appearance.GroupFooter.Font"), System.Drawing.Font)
        Me.DepartmentsView.Appearance.GroupPanel.Font = CType(resources.GetObject("DepartmentsView.Appearance.GroupPanel.Font"), System.Drawing.Font)
        Me.DepartmentsView.Appearance.GroupRow.Font = CType(resources.GetObject("DepartmentsView.Appearance.GroupRow.Font"), System.Drawing.Font)
        Me.DepartmentsView.Appearance.HeaderPanel.Font = CType(resources.GetObject("DepartmentsView.Appearance.HeaderPanel.Font"), System.Drawing.Font)
        Me.DepartmentsView.Appearance.HideSelectionRow.Font = CType(resources.GetObject("DepartmentsView.Appearance.HideSelectionRow.Font"), System.Drawing.Font)
        Me.DepartmentsView.Appearance.HorzLine.Font = CType(resources.GetObject("DepartmentsView.Appearance.HorzLine.Font"), System.Drawing.Font)
        Me.DepartmentsView.Appearance.OddRow.Font = CType(resources.GetObject("DepartmentsView.Appearance.OddRow.Font"), System.Drawing.Font)
        Me.DepartmentsView.Appearance.Preview.Font = CType(resources.GetObject("DepartmentsView.Appearance.Preview.Font"), System.Drawing.Font)
        Me.DepartmentsView.Appearance.Row.Font = CType(resources.GetObject("DepartmentsView.Appearance.Row.Font"), System.Drawing.Font)
        Me.DepartmentsView.Appearance.RowSeparator.Font = CType(resources.GetObject("DepartmentsView.Appearance.RowSeparator.Font"), System.Drawing.Font)
        Me.DepartmentsView.Appearance.SelectedRow.Font = CType(resources.GetObject("DepartmentsView.Appearance.SelectedRow.Font"), System.Drawing.Font)
        Me.DepartmentsView.Appearance.TopNewRow.Font = CType(resources.GetObject("DepartmentsView.Appearance.TopNewRow.Font"), System.Drawing.Font)
        Me.DepartmentsView.Appearance.VertLine.Font = CType(resources.GetObject("DepartmentsView.Appearance.VertLine.Font"), System.Drawing.Font)
        Me.DepartmentsView.Appearance.ViewCaption.Font = CType(resources.GetObject("DepartmentsView.Appearance.ViewCaption.Font"), System.Drawing.Font)
        Me.DepartmentsView.AppearancePrint.EvenRow.Font = CType(resources.GetObject("DepartmentsView.AppearancePrint.EvenRow.Font"), System.Drawing.Font)
        Me.DepartmentsView.AppearancePrint.FilterPanel.Font = CType(resources.GetObject("DepartmentsView.AppearancePrint.FilterPanel.Font"), System.Drawing.Font)
        Me.DepartmentsView.AppearancePrint.FooterPanel.Font = CType(resources.GetObject("DepartmentsView.AppearancePrint.FooterPanel.Font"), System.Drawing.Font)
        Me.DepartmentsView.AppearancePrint.GroupFooter.Font = CType(resources.GetObject("DepartmentsView.AppearancePrint.GroupFooter.Font"), System.Drawing.Font)
        Me.DepartmentsView.AppearancePrint.GroupRow.Font = CType(resources.GetObject("DepartmentsView.AppearancePrint.GroupRow.Font"), System.Drawing.Font)
        Me.DepartmentsView.AppearancePrint.HeaderPanel.Font = CType(resources.GetObject("DepartmentsView.AppearancePrint.HeaderPanel.Font"), System.Drawing.Font)
        Me.DepartmentsView.AppearancePrint.Lines.Font = CType(resources.GetObject("DepartmentsView.AppearancePrint.Lines.Font"), System.Drawing.Font)
        Me.DepartmentsView.AppearancePrint.OddRow.Font = CType(resources.GetObject("DepartmentsView.AppearancePrint.OddRow.Font"), System.Drawing.Font)
        Me.DepartmentsView.AppearancePrint.Preview.Font = CType(resources.GetObject("DepartmentsView.AppearancePrint.Preview.Font"), System.Drawing.Font)
        Me.DepartmentsView.AppearancePrint.Row.Font = CType(resources.GetObject("DepartmentsView.AppearancePrint.Row.Font"), System.Drawing.Font)
        Me.DepartmentsView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colEnglishDepartmentName, Me.colNationalDepartmentName})
        Me.DepartmentsView.GridControl = Me.grdDepartmentList
        resources.ApplyResources(Me.DepartmentsView, "DepartmentsView")
        Me.DepartmentsView.Name = "DepartmentsView"
        Me.DepartmentsView.OptionsBehavior.AutoPopulateColumns = False
        Me.DepartmentsView.OptionsCustomization.AllowFilter = False
        Me.DepartmentsView.OptionsCustomization.AllowGroup = False
        Me.DepartmentsView.OptionsDetail.EnableMasterViewMode = False
        Me.DepartmentsView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.DepartmentsView.OptionsView.ShowChildrenInGroupPanel = True
        Me.DepartmentsView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.DepartmentsView.OptionsView.ShowGroupPanel = False
        Me.DepartmentsView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colEnglishDepartmentName, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colNationalDepartmentName, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'colEnglishDepartmentName
        '
        Me.colEnglishDepartmentName.AppearanceCell.Font = CType(resources.GetObject("colEnglishDepartmentName.AppearanceCell.Font"), System.Drawing.Font)
        Me.colEnglishDepartmentName.AppearanceHeader.Font = CType(resources.GetObject("colEnglishDepartmentName.AppearanceHeader.Font"), System.Drawing.Font)
        Me.colEnglishDepartmentName.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colEnglishDepartmentName, "colEnglishDepartmentName")
        Me.colEnglishDepartmentName.FieldName = "DefaultName"
        Me.colEnglishDepartmentName.Name = "colEnglishDepartmentName"
        '
        'colNationalDepartmentName
        '
        Me.colNationalDepartmentName.AppearanceCell.Font = CType(resources.GetObject("colNationalDepartmentName.AppearanceCell.Font"), System.Drawing.Font)
        Me.colNationalDepartmentName.AppearanceHeader.Font = CType(resources.GetObject("colNationalDepartmentName.AppearanceHeader.Font"), System.Drawing.Font)
        Me.colNationalDepartmentName.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colNationalDepartmentName, "colNationalDepartmentName")
        Me.colNationalDepartmentName.FieldName = "name"
        Me.colNationalDepartmentName.Name = "colNationalDepartmentName"
        '
        'btnDeleteDpt
        '
        resources.ApplyResources(Me.btnDeleteDpt, "btnDeleteDpt")
        Me.btnDeleteDpt.Appearance.Font = CType(resources.GetObject("btnDeleteDpt.Appearance.Font"), System.Drawing.Font)
        Me.btnDeleteDpt.Appearance.Options.UseFont = True
        Me.btnDeleteDpt.Image = Global.EIDSS.My.Resources.Resources.Delete_Remove
        Me.btnDeleteDpt.Name = "btnDeleteDpt"
        '
        'OrganizationDetail
        '
        Me.Appearance.Font = CType(resources.GetObject("OrganizationDetail.Appearance.Font"), System.Drawing.Font)
        Me.Appearance.Options.UseFont = True
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.TabControl1)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "A07"
        Me.HelpTopicID = "Organisations"
        Me.KeyFieldName = "idfOffice"
        Me.LeftIcon = Global.EIDSS.My.Resources.Resources.Organization_130_
        Me.Name = "OrganizationDetail"
        Me.ObjectName = "Organization"
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "Organization"
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.chkForeignAddress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbAccessory.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOrganizationID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEnglishAbbreviation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNationalAbbreviation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEnglishName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNationalName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPhone.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.grdDepartmentList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DepartmentsView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub


#End Region



    Protected Overrides Sub DefineBinding()
        Try
            If (DbService.IsNewObject AndAlso Not StartUpParameters Is Nothing AndAlso StartUpParameters.ContainsKey("HACode") AndAlso baseDataSet.Tables("Organization").Rows.Count > 0) Then
                baseDataSet.Tables("Organization").Rows(0)("intHACode") = CInt(StartUpParameters("HACode"))
                baseDataSet.Tables("Organization").Rows(0).EndEdit()
            End If
            Core.LookupBinder.BindTextEdit(txtOrganizationID, baseDataSet, "Organization.strOrganizationID")
            Core.LookupBinder.BindTextEdit(txtEnglishAbbreviation, baseDataSet, "Organization.EnglishName")
            Core.LookupBinder.BindTextEdit(txtNationalAbbreviation, baseDataSet, "Organization.name")
            Core.LookupBinder.BindTextEdit(txtNationalName, baseDataSet, "Organization.FullName")
            Core.LookupBinder.BindTextEdit(txtEnglishName, baseDataSet, "Organization.EnglishFullName")
            Core.LookupBinder.BindTextEdit(txtPhone, baseDataSet, "Organization.strContactPhone")
            Core.LookupBinder.BindHACodeLookup(cbAccessory, baseDataSet, "Organization.intHACode", HACode.Human Or HACode.Avian Or HACode.Livestock Or HACode.Vector Or HACode.Syndromic)
            Me.AddressPanel.DataBindings.Add("ID", baseDataSet, "Organization.idfLocation")
            RemoveHandler AddressPanel.AfterLoadData, AddressOf AfterAdressLoad
            AddHandler AddressPanel.AfterLoadData, AddressOf AfterAdressLoad
            grdDepartmentList.DataSource = baseDataSet
            grdDepartmentList.DataMember = "Departments"

        Catch e As Exception
            MsgBox(e.Message)
        End Try

    End Sub

    Private Sub AfterAdressLoad(ByVal sender As Object, ByVal e As EventArgs)
        m_Updating = True
        chkForeignAddress.Checked = AddressPanel.ForeignAddressMode
        m_Updating = False
    End Sub

    Protected Function LocalValidateData() As Boolean
        Dim MandatoryList As Control() = {Me.txtNationalAbbreviation, Me.txtNationalName}
        Dim be As DevExpress.XtraEditors.BaseEdit

        For Each c As Control In MandatoryList
            be = CType(c, DevExpress.XtraEditors.BaseEdit)
            If Not c.Tag Is Nothing AndAlso TypeOf (c.Tag) Is TagHelper Then
                Dim th As TagHelper = CType(c.Tag, TagHelper)
                If th.IsMandatory Then
                    If be.EditValue Is Nothing OrElse _
                            be.EditValue Is DBNull.Value OrElse _
                            (TypeOf (be.EditValue) Is String AndAlso CType(be.EditValue, String).Trim() = "") OrElse _
                            c.Text Is Nothing OrElse c.Text.Trim = "" Then
                        ErrorForm.ShowWarningFormat("ErrMandatoryFieldRequired", "The field {0} is mandatory. You must enter data to this field before form saving", GetControlLabel(c))
                        c.Select()
                        Return False
                    End If
                End If
            End If
        Next

        Return True
    End Function

    Public Overrides Function ValidateData() As Boolean
        'If Not (Me.LocalValidateData()) Then
        '    Return False
        'End If
        Return MyBase.ValidateData()
    End Function



    Private Sub btnNewDept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub btnDeleteDpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteDpt.Click
        If DepartmentsView.FocusedRowHandle < 0 Then
            DepartmentsView.CancelUpdateCurrentRow()
        End If
        If DepartmentsView.RowCount <> 0 AndAlso DepartmentsView.FocusedRowHandle >= 0 Then
            If WinUtils.ConfirmDelete = False Then
                Return
            End If
            DepartmentsView.GetDataRow(DepartmentsView.FocusedRowHandle).Delete()
        End If
    End Sub

    Public Overrides Sub UpdateButtonsState(ByVal sender As Object, ByVal e As System.EventArgs)
        btnDeleteDpt.Enabled = DepartmentsView.FocusedRowHandle >= 0
    End Sub


    Private Sub SetEnglishLanguage(ByVal sender As Object, ByVal e As System.EventArgs)
        TagHelper.SetControlLanguage(CType(sender, Control), Localizer.lngEn)
    End Sub
    Private Sub SetNationalLanguage(ByVal sender As Object, ByVal e As System.EventArgs)
        TagHelper.SetControlLanguage(CType(sender, Control), bv.model.Model.Core.ModelUserContext.CurrentLanguage)
    End Sub

    Private Sub DepartmentsView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DepartmentsView.KeyDown
        If e.KeyCode = Keys.Enter Then
            DepartmentsView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
            DepartmentsView.ShowEditor()
        End If
    End Sub

    Private Sub DepartmentsView_ShownEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DepartmentsView.ShownEditor
        If Not DepartmentsView.ActiveEditor Is Nothing Then
            If DepartmentsView.FocusedColumn Is colEnglishDepartmentName Then
                SystemLanguages.SwitchInputLanguage(Localizer.lngEn)
            Else
                SystemLanguages.SwitchInputLanguage(bv.model.Model.Core.ModelUserContext.CurrentLanguage)
            End If
        End If
    End Sub

    Public Overrides Function GetChildKey(ByVal child As IRelatedObject) As Object
        If child Is Me.AddressPanel Then
            If baseDataSet.Tables("Organization").Rows.Count > 0 AndAlso Not baseDataSet.Tables("Organization").Rows(0)("idfLocation") Is DBNull.Value Then
                Return baseDataSet.Tables("Organization").Rows(0)("idfLocation")
            Else
                Return Nothing
            End If
        End If
        Return Nothing
    End Function

    Private Sub DepartmentsView_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DepartmentsView.ValidateRow
        If colEnglishDepartmentName.Visible AndAlso Utils.IsEmpty(CType(e.Row, DataRowView)("DefaultName")) Then
            e.Valid = False
            e.ErrorText = String.Format(BvMessages.Get("ErrMandatoryFieldRequired", "The field {0} is mandatory. You must enter data to this field before form saving"), colEnglishDepartmentName.Caption)
            Return
        End If
        If colNationalDepartmentName.Visible AndAlso Utils.IsEmpty(CType(e.Row, DataRowView)("Name")) Then
            e.Valid = False
            e.ErrorText = String.Format(BvMessages.Get("ErrMandatoryFieldRequired", "The field {0} is mandatory. You must enter data to this field before form saving"), colNationalDepartmentName.Caption)
            Return
        End If
    End Sub

    Private m_Updating As Boolean
    Private Sub chkForeignAddress_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkForeignAddress.CheckedChanged
        If m_Updating Then
            Return
        End If
        m_Updating = True
        AddressPanel.ForeignAddressMode = chkForeignAddress.Checked
        m_Updating = False

    End Sub
End Class
