Imports bv.winclient.Localization
Imports bv.winclient.Core
Imports bv.common.Resources

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
        AuditObject = New Core.EIDSSAuditObject(EIDSSAuditObject.daoOrganization, AuditTable.tlbOffice)
        LookupTableNames = New String() {"Organization", "Person"}
        Me.PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.Organization
        'lblTranslatedDepartmentName.Text += " (" + GlobalSettings.LanguageName(bv.model.Model.Core.ModelUserContext.CurrentLanguage) + ")"
        'lblNationalAbbreviation.Text += " (" + GlobalSettings.LanguageName(bv.model.Model.Core.ModelUserContext.CurrentLanguage).ToLower + ")"
        'lblNationalName.Text += " (" + GlobalSettings.LanguageName(bv.model.Model.Core.ModelUserContext.CurrentLanguage).ToLower + ")"
        'colNationalDepartmentName.Caption += " (" + GlobalSettings.LanguageName(bv.model.Model.Core.ModelUserContext.CurrentLanguage).ToLower + ")"
        If bv.model.Model.Core.ModelUserContext.CurrentLanguage = Localizer.lngEn Then
            Dim CurTop As Integer = 8
            Dim SmallStep As Integer = 4
            txtEnglishAbbreviation.Enabled = False
            txtEnglishName.Enabled = False
            colEnglishDepartmentName.Visible = False
            lblEnglishAbbreviation.Visible = False
            SetMandatoryFieldVisible(txtEnglishAbbreviation, False)
            CurTop = txtEnglishAbbreviation.Top
            lblNationalAbbreviation.Top = CurTop
            txtNationalAbbreviation.Top = CurTop
            CurTop = CurTop + txtNationalAbbreviation.Height
            SetMandatoryFieldVisible(txtEnglishName, False)
            lblEnglishName.Visible = False
            CurTop = CurTop + SmallStep
            lblNationalName.Top = CurTop
            txtNationalName.Top = CurTop
            CurTop = CurTop + txtNationalName.Height
            CurTop = CurTop + SmallStep
            AddressPanel.Top = CurTop
            CurTop = CurTop + AddressPanel.Height
            CurTop = CurTop - SmallStep
            lblPhone.Top = CurTop
            txtPhone.Top = CurTop
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
    Friend WithEvents DepartmentsView As DevExpress.XtraGrid.Views.Grid.GridView

    '<System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OrganizationDetail))
        Me.TabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.TabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.txtEnglishAbbreviation = New DevExpress.XtraEditors.TextEdit()
        Me.txtNationalAbbreviation = New DevExpress.XtraEditors.TextEdit()
        Me.txtEnglishName = New DevExpress.XtraEditors.TextEdit()
        Me.txtNationalName = New DevExpress.XtraEditors.TextEdit()
        Me.txtPhone = New DevExpress.XtraEditors.TextEdit()
        Me.AddressPanel = New eidss.AddressLookup()
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
        CType(Me.txtEnglishAbbreviation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNationalAbbreviation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEnglishName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNationalName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPhone.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.grdDepartmentList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DepartmentsView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        Me.cmdOk.Appearance.Font = CType(resources.GetObject("cmdOk.Appearance.Font"), System.Drawing.Font)
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
        Me.AddressPanel.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.AddressPanel.FormID = Nothing
        Me.AddressPanel.HelpTopicID = Nothing
        Me.AddressPanel.IsStatusReadOnly = False
        Me.AddressPanel.KeyFieldName = Nothing
        Me.AddressPanel.LookupLayout = bv.common.win.LookupFormLayout.Group
        Me.AddressPanel.MandatoryFields = eidss.AddressMandatoryFieldsType.Rayon
        Me.AddressPanel.MultiSelect = False
        Me.AddressPanel.Name = "AddressPanel"
        Me.AddressPanel.ObjectName = Nothing
        Me.AddressPanel.PopupEditHeight = 200
        Me.AddressPanel.ShowResidenceType = False
        Me.AddressPanel.Status = bv.common.win.FormStatus.Draft
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
        Me.btnDeleteDpt.Image = Global.eidss.My.Resources.Resources.Delete_Remove
        Me.btnDeleteDpt.Name = "btnDeleteDpt"
        '
        'OrganizationDetail
        '
        Me.Appearance.Font = CType(resources.GetObject("OrganizationDetail.Appearance.Font"), System.Drawing.Font)
        Me.Appearance.Options.UseFont = True
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.TabControl1)
        Me.FormID = "A07"
        Me.HelpTopicID = "OrganizationDetailForm"
        Me.KeyFieldName = "idfOffice"
        Me.LeftIcon = Global.eidss.My.Resources.Resources.Organization_130_
        Me.Name = "OrganizationDetail"
        Me.ObjectName = "Organization"
        Me.TableName = "Organization"
        Me.Controls.SetChildIndex(Me.cmdOk, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
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
            Core.LookupBinder.BindTextEdit(txtEnglishAbbreviation, baseDataSet, "Organization.EnglishName")
            Core.LookupBinder.BindTextEdit(txtNationalAbbreviation, baseDataSet, "Organization.name")
            Core.LookupBinder.BindTextEdit(txtNationalName, baseDataSet, "Organization.FullName")
            Core.LookupBinder.BindTextEdit(txtEnglishName, baseDataSet, "Organization.EnglishFullName")
            Core.LookupBinder.BindTextEdit(txtPhone, baseDataSet, "Organization.strContactPhone")
            Me.AddressPanel.DataBindings.Add("ID", baseDataSet, "Organization.idfLocation")

            grdDepartmentList.DataSource = baseDataSet
            grdDepartmentList.DataMember = "Departments"

        Catch e As Exception
            MsgBox(e.Message)
        End Try

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

    Public Overrides Function GetChildKey(ByVal child As bv.common.win.IRelatedObject) As Object
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

End Class
