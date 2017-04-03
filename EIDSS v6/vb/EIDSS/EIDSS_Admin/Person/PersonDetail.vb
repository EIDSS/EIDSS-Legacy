Imports bv.common.Objects
Imports DevExpress.XtraTab
Imports bv.winclient.Core
Imports bv.winclient.BasePanel
Imports System.Collections.Generic
Imports EIDSS.model.Enums

Public Class PersonDetail
    Inherits BaseDetailForm
    Dim PersonDbService As Person_DB
    Dim MultiSite As Boolean = New StandardAccessPermissions(EIDSS.model.Enums.EIDSSPermissionObject.CreateLoginRemotely).CanExecute
    Friend WithEvents cmdNewLogin As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdDeleteLogin As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents UsersGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colLogin As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSite As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSiteType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSiteName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbSiteID As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cbSiteType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cbSiteName As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents UsersGrid As DevExpress.XtraGrid.GridControl
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        PersonDbService = New Person_DB
        DbService = PersonDbService
        AuditObject = New AuditObject(EIDSSAuditObject.daoEmployee, AuditTable.tlbEmployee)
        Me.PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.Person
        LookupTableNames = New String() {"Person"}
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
    Friend WithEvents tbPerson As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents TabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents cbOrganization As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbRank As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMiddleName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFirstName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtLastName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbLoginInfo As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents cbDepartment As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cmdEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PersonDetail))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject5 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject6 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.tbPerson = New DevExpress.XtraTab.XtraTabControl()
        Me.TabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.txtFirstName = New DevExpress.XtraEditors.TextEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMiddleName = New DevExpress.XtraEditors.TextEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLastName = New DevExpress.XtraEditors.TextEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbOrganization = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbDepartment = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbRank = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbLoginInfo = New DevExpress.XtraTab.XtraTabPage()
        Me.cmdDeleteLogin = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdNewLogin = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.UsersGrid = New DevExpress.XtraGrid.GridControl()
        Me.UsersGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colSite = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbSiteID = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colSiteType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbSiteType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colSiteName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbSiteName = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colLogin = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.tbPerson, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbPerson.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.txtFirstName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMiddleName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLastName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbOrganization.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDepartment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbRank.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbLoginInfo.SuspendLayout()
        CType(Me.UsersGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UsersGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSiteID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSiteType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSiteName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(PersonDetail), resources)
        'Form Is Localizable: True
        '
        'tbPerson
        '
        resources.ApplyResources(Me.tbPerson, "tbPerson")
        Me.tbPerson.Appearance.Font = CType(resources.GetObject("tbPerson.Appearance.Font"), System.Drawing.Font)
        Me.tbPerson.Appearance.Options.UseFont = True
        Me.tbPerson.AppearancePage.Header.Font = CType(resources.GetObject("tbPerson.AppearancePage.Header.Font"), System.Drawing.Font)
        Me.tbPerson.AppearancePage.Header.Options.UseFont = True
        Me.tbPerson.AppearancePage.HeaderActive.Font = CType(resources.GetObject("tbPerson.AppearancePage.HeaderActive.Font"), System.Drawing.Font)
        Me.tbPerson.AppearancePage.HeaderActive.Options.UseFont = True
        Me.tbPerson.AppearancePage.HeaderDisabled.Font = CType(resources.GetObject("tbPerson.AppearancePage.HeaderDisabled.Font"), System.Drawing.Font)
        Me.tbPerson.AppearancePage.HeaderDisabled.Options.UseFont = True
        Me.tbPerson.AppearancePage.HeaderHotTracked.Font = CType(resources.GetObject("tbPerson.AppearancePage.HeaderHotTracked.Font"), System.Drawing.Font)
        Me.tbPerson.AppearancePage.HeaderHotTracked.Options.UseFont = True
        Me.tbPerson.AppearancePage.PageClient.Font = CType(resources.GetObject("tbPerson.AppearancePage.PageClient.Font"), System.Drawing.Font)
        Me.tbPerson.AppearancePage.PageClient.Options.UseFont = True
        Me.tbPerson.Name = "tbPerson"
        Me.tbPerson.SelectedTabPage = Me.TabPage1
        Me.tbPerson.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.TabPage1, Me.tbLoginInfo})
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
        Me.TabPage1.Controls.Add(Me.txtFirstName)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txtMiddleName)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtLastName)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.cbOrganization)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.cbDepartment)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.cbRank)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Name = "TabPage1"
        resources.ApplyResources(Me.TabPage1, "TabPage1")
        '
        'txtFirstName
        '
        resources.ApplyResources(Me.txtFirstName, "txtFirstName")
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Properties.Appearance.Font = CType(resources.GetObject("txtFirstName.Properties.Appearance.Font"), System.Drawing.Font)
        Me.txtFirstName.Properties.Appearance.Options.UseFont = True
        Me.txtFirstName.Properties.AppearanceDisabled.Font = CType(resources.GetObject("txtFirstName.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.txtFirstName.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtFirstName.Properties.AppearanceFocused.Font = CType(resources.GetObject("txtFirstName.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.txtFirstName.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtFirstName.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("txtFirstName.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.txtFirstName.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtFirstName.Tag = "{M}"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'txtMiddleName
        '
        resources.ApplyResources(Me.txtMiddleName, "txtMiddleName")
        Me.txtMiddleName.Name = "txtMiddleName"
        Me.txtMiddleName.Properties.Appearance.Font = CType(resources.GetObject("txtMiddleName.Properties.Appearance.Font"), System.Drawing.Font)
        Me.txtMiddleName.Properties.Appearance.Options.UseFont = True
        Me.txtMiddleName.Properties.AppearanceDisabled.Font = CType(resources.GetObject("txtMiddleName.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.txtMiddleName.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtMiddleName.Properties.AppearanceFocused.Font = CType(resources.GetObject("txtMiddleName.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.txtMiddleName.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtMiddleName.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("txtMiddleName.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.txtMiddleName.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtMiddleName.Tag = ""
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'txtLastName
        '
        resources.ApplyResources(Me.txtLastName, "txtLastName")
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Properties.Appearance.Font = CType(resources.GetObject("txtLastName.Properties.Appearance.Font"), System.Drawing.Font)
        Me.txtLastName.Properties.Appearance.Options.UseFont = True
        Me.txtLastName.Properties.AppearanceDisabled.Font = CType(resources.GetObject("txtLastName.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.txtLastName.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtLastName.Properties.AppearanceFocused.Font = CType(resources.GetObject("txtLastName.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.txtLastName.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtLastName.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("txtLastName.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.txtLastName.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtLastName.Tag = "{M}"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'cbOrganization
        '
        resources.ApplyResources(Me.cbOrganization, "cbOrganization")
        Me.cbOrganization.Name = "cbOrganization"
        Me.cbOrganization.Properties.Appearance.Font = CType(resources.GetObject("cbOrganization.Properties.Appearance.Font"), System.Drawing.Font)
        Me.cbOrganization.Properties.Appearance.Options.UseFont = True
        Me.cbOrganization.Properties.AppearanceDisabled.Font = CType(resources.GetObject("cbOrganization.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.cbOrganization.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbOrganization.Properties.AppearanceDropDown.Font = CType(resources.GetObject("cbOrganization.Properties.AppearanceDropDown.Font"), System.Drawing.Font)
        Me.cbOrganization.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbOrganization.Properties.AppearanceDropDownHeader.Font = CType(resources.GetObject("cbOrganization.Properties.AppearanceDropDownHeader.Font"), System.Drawing.Font)
        Me.cbOrganization.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbOrganization.Properties.AppearanceFocused.Font = CType(resources.GetObject("cbOrganization.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.cbOrganization.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbOrganization.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("cbOrganization.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.cbOrganization.Properties.AppearanceReadOnly.Options.UseFont = True
        resources.ApplyResources(SerializableAppearanceObject1, "SerializableAppearanceObject1")
        SerializableAppearanceObject1.Options.UseFont = True
        Me.cbOrganization.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbOrganization.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbOrganization.Properties.Buttons1"), CType(resources.GetObject("cbOrganization.Properties.Buttons2"), Integer), CType(resources.GetObject("cbOrganization.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbOrganization.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbOrganization.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbOrganization.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbOrganization.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, resources.GetString("cbOrganization.Properties.Buttons8"), CType(resources.GetObject("cbOrganization.Properties.Buttons9"), Object), CType(resources.GetObject("cbOrganization.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbOrganization.Properties.Buttons11"), Boolean))})
        Me.cbOrganization.Properties.NullText = resources.GetString("cbOrganization.Properties.NullText")
        Me.cbOrganization.Tag = "{M}"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'cbDepartment
        '
        resources.ApplyResources(Me.cbDepartment, "cbDepartment")
        Me.cbDepartment.Name = "cbDepartment"
        Me.cbDepartment.Properties.Appearance.Font = CType(resources.GetObject("cbDepartment.Properties.Appearance.Font"), System.Drawing.Font)
        Me.cbDepartment.Properties.Appearance.Options.UseFont = True
        Me.cbDepartment.Properties.AppearanceDisabled.Font = CType(resources.GetObject("cbDepartment.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.cbDepartment.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbDepartment.Properties.AppearanceDropDown.Font = CType(resources.GetObject("cbDepartment.Properties.AppearanceDropDown.Font"), System.Drawing.Font)
        Me.cbDepartment.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbDepartment.Properties.AppearanceDropDownHeader.Font = CType(resources.GetObject("cbDepartment.Properties.AppearanceDropDownHeader.Font"), System.Drawing.Font)
        Me.cbDepartment.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbDepartment.Properties.AppearanceFocused.Font = CType(resources.GetObject("cbDepartment.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.cbDepartment.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbDepartment.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("cbDepartment.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.cbDepartment.Properties.AppearanceReadOnly.Options.UseFont = True
        resources.ApplyResources(SerializableAppearanceObject2, "SerializableAppearanceObject2")
        SerializableAppearanceObject2.Options.UseFont = True
        Me.cbDepartment.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDepartment.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbDepartment.Properties.Buttons1"), CType(resources.GetObject("cbDepartment.Properties.Buttons2"), Integer), CType(resources.GetObject("cbDepartment.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbDepartment.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbDepartment.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbDepartment.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbDepartment.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, resources.GetString("cbDepartment.Properties.Buttons8"), CType(resources.GetObject("cbDepartment.Properties.Buttons9"), Object), CType(resources.GetObject("cbDepartment.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbDepartment.Properties.Buttons11"), Boolean))})
        Me.cbDepartment.Properties.NullText = resources.GetString("cbDepartment.Properties.NullText")
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'cbRank
        '
        resources.ApplyResources(Me.cbRank, "cbRank")
        Me.cbRank.Name = "cbRank"
        Me.cbRank.Properties.Appearance.Font = CType(resources.GetObject("cbRank.Properties.Appearance.Font"), System.Drawing.Font)
        Me.cbRank.Properties.Appearance.Options.UseFont = True
        Me.cbRank.Properties.AppearanceDisabled.Font = CType(resources.GetObject("cbRank.Properties.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.cbRank.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbRank.Properties.AppearanceDropDown.Font = CType(resources.GetObject("cbRank.Properties.AppearanceDropDown.Font"), System.Drawing.Font)
        Me.cbRank.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbRank.Properties.AppearanceDropDownHeader.Font = CType(resources.GetObject("cbRank.Properties.AppearanceDropDownHeader.Font"), System.Drawing.Font)
        Me.cbRank.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbRank.Properties.AppearanceFocused.Font = CType(resources.GetObject("cbRank.Properties.AppearanceFocused.Font"), System.Drawing.Font)
        Me.cbRank.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbRank.Properties.AppearanceReadOnly.Font = CType(resources.GetObject("cbRank.Properties.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.cbRank.Properties.AppearanceReadOnly.Options.UseFont = True
        resources.ApplyResources(SerializableAppearanceObject3, "SerializableAppearanceObject3")
        SerializableAppearanceObject3.Options.UseFont = True
        Me.cbRank.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbRank.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbRank.Properties.Buttons1"), CType(resources.GetObject("cbRank.Properties.Buttons2"), Integer), CType(resources.GetObject("cbRank.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbRank.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbRank.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbRank.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbRank.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject3, resources.GetString("cbRank.Properties.Buttons8"), CType(resources.GetObject("cbRank.Properties.Buttons9"), Object), CType(resources.GetObject("cbRank.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbRank.Properties.Buttons11"), Boolean))})
        Me.cbRank.Properties.NullText = resources.GetString("cbRank.Properties.NullText")
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'tbLoginInfo
        '
        Me.tbLoginInfo.Appearance.Header.Font = CType(resources.GetObject("tbLoginInfo.Appearance.Header.Font"), System.Drawing.Font)
        Me.tbLoginInfo.Appearance.Header.Options.UseFont = True
        Me.tbLoginInfo.Appearance.HeaderActive.Font = CType(resources.GetObject("tbLoginInfo.Appearance.HeaderActive.Font"), System.Drawing.Font)
        Me.tbLoginInfo.Appearance.HeaderActive.Options.UseFont = True
        Me.tbLoginInfo.Appearance.HeaderDisabled.Font = CType(resources.GetObject("tbLoginInfo.Appearance.HeaderDisabled.Font"), System.Drawing.Font)
        Me.tbLoginInfo.Appearance.HeaderDisabled.Options.UseFont = True
        Me.tbLoginInfo.Appearance.HeaderHotTracked.Font = CType(resources.GetObject("tbLoginInfo.Appearance.HeaderHotTracked.Font"), System.Drawing.Font)
        Me.tbLoginInfo.Appearance.HeaderHotTracked.Options.UseFont = True
        Me.tbLoginInfo.Appearance.PageClient.Font = CType(resources.GetObject("tbLoginInfo.Appearance.PageClient.Font"), System.Drawing.Font)
        Me.tbLoginInfo.Appearance.PageClient.Options.UseFont = True
        Me.tbLoginInfo.Controls.Add(Me.cmdDeleteLogin)
        Me.tbLoginInfo.Controls.Add(Me.cmdNewLogin)
        Me.tbLoginInfo.Controls.Add(Me.cmdEdit)
        Me.tbLoginInfo.Controls.Add(Me.UsersGrid)
        Me.tbLoginInfo.Name = "tbLoginInfo"
        resources.ApplyResources(Me.tbLoginInfo, "tbLoginInfo")
        '
        'cmdDeleteLogin
        '
        resources.ApplyResources(Me.cmdDeleteLogin, "cmdDeleteLogin")
        Me.cmdDeleteLogin.Appearance.Font = CType(resources.GetObject("cmdDeleteLogin.Appearance.Font"), System.Drawing.Font)
        Me.cmdDeleteLogin.Appearance.Options.UseFont = True
        Me.cmdDeleteLogin.Name = "cmdDeleteLogin"
        '
        'cmdNewLogin
        '
        resources.ApplyResources(Me.cmdNewLogin, "cmdNewLogin")
        Me.cmdNewLogin.Appearance.Font = CType(resources.GetObject("cmdNewLogin.Appearance.Font"), System.Drawing.Font)
        Me.cmdNewLogin.Appearance.Options.UseFont = True
        Me.cmdNewLogin.Name = "cmdNewLogin"
        '
        'cmdEdit
        '
        resources.ApplyResources(Me.cmdEdit, "cmdEdit")
        Me.cmdEdit.Appearance.Font = CType(resources.GetObject("cmdEdit.Appearance.Font"), System.Drawing.Font)
        Me.cmdEdit.Appearance.Options.UseFont = True
        Me.cmdEdit.Name = "cmdEdit"
        '
        'UsersGrid
        '
        Me.UsersGrid.EmbeddedNavigator.Appearance.Font = CType(resources.GetObject("UsersGrid.EmbeddedNavigator.Appearance.Font"), System.Drawing.Font)
        Me.UsersGrid.EmbeddedNavigator.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.UsersGrid, "UsersGrid")
        Me.UsersGrid.MainView = Me.UsersGridView
        Me.UsersGrid.Name = "UsersGrid"
        Me.UsersGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbSiteID, Me.cbSiteType, Me.cbSiteName})
        Me.UsersGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.UsersGridView})
        '
        'UsersGridView
        '
        Me.UsersGridView.Appearance.ColumnFilterButton.Font = CType(resources.GetObject("UsersGridView.Appearance.ColumnFilterButton.Font"), System.Drawing.Font)
        Me.UsersGridView.Appearance.ColumnFilterButtonActive.Font = CType(resources.GetObject("UsersGridView.Appearance.ColumnFilterButtonActive.Font"), System.Drawing.Font)
        Me.UsersGridView.Appearance.CustomizationFormHint.Font = CType(resources.GetObject("UsersGridView.Appearance.CustomizationFormHint.Font"), System.Drawing.Font)
        Me.UsersGridView.Appearance.DetailTip.Font = CType(resources.GetObject("UsersGridView.Appearance.DetailTip.Font"), System.Drawing.Font)
        Me.UsersGridView.Appearance.Empty.Font = CType(resources.GetObject("UsersGridView.Appearance.Empty.Font"), System.Drawing.Font)
        Me.UsersGridView.Appearance.EvenRow.Font = CType(resources.GetObject("UsersGridView.Appearance.EvenRow.Font"), System.Drawing.Font)
        Me.UsersGridView.Appearance.FilterCloseButton.Font = CType(resources.GetObject("UsersGridView.Appearance.FilterCloseButton.Font"), System.Drawing.Font)
        Me.UsersGridView.Appearance.FilterPanel.Font = CType(resources.GetObject("UsersGridView.Appearance.FilterPanel.Font"), System.Drawing.Font)
        Me.UsersGridView.Appearance.FixedLine.Font = CType(resources.GetObject("UsersGridView.Appearance.FixedLine.Font"), System.Drawing.Font)
        Me.UsersGridView.Appearance.FocusedCell.Font = CType(resources.GetObject("UsersGridView.Appearance.FocusedCell.Font"), System.Drawing.Font)
        Me.UsersGridView.Appearance.FocusedRow.Font = CType(resources.GetObject("UsersGridView.Appearance.FocusedRow.Font"), System.Drawing.Font)
        Me.UsersGridView.Appearance.FooterPanel.Font = CType(resources.GetObject("UsersGridView.Appearance.FooterPanel.Font"), System.Drawing.Font)
        Me.UsersGridView.Appearance.GroupButton.Font = CType(resources.GetObject("UsersGridView.Appearance.GroupButton.Font"), System.Drawing.Font)
        Me.UsersGridView.Appearance.GroupFooter.Font = CType(resources.GetObject("UsersGridView.Appearance.GroupFooter.Font"), System.Drawing.Font)
        Me.UsersGridView.Appearance.GroupPanel.Font = CType(resources.GetObject("UsersGridView.Appearance.GroupPanel.Font"), System.Drawing.Font)
        Me.UsersGridView.Appearance.GroupRow.Font = CType(resources.GetObject("UsersGridView.Appearance.GroupRow.Font"), System.Drawing.Font)
        Me.UsersGridView.Appearance.HeaderPanel.Font = CType(resources.GetObject("UsersGridView.Appearance.HeaderPanel.Font"), System.Drawing.Font)
        Me.UsersGridView.Appearance.HideSelectionRow.Font = CType(resources.GetObject("UsersGridView.Appearance.HideSelectionRow.Font"), System.Drawing.Font)
        Me.UsersGridView.Appearance.HorzLine.Font = CType(resources.GetObject("UsersGridView.Appearance.HorzLine.Font"), System.Drawing.Font)
        Me.UsersGridView.Appearance.OddRow.Font = CType(resources.GetObject("UsersGridView.Appearance.OddRow.Font"), System.Drawing.Font)
        Me.UsersGridView.Appearance.Preview.Font = CType(resources.GetObject("UsersGridView.Appearance.Preview.Font"), System.Drawing.Font)
        Me.UsersGridView.Appearance.Row.Font = CType(resources.GetObject("UsersGridView.Appearance.Row.Font"), System.Drawing.Font)
        Me.UsersGridView.Appearance.RowSeparator.Font = CType(resources.GetObject("UsersGridView.Appearance.RowSeparator.Font"), System.Drawing.Font)
        Me.UsersGridView.Appearance.SelectedRow.Font = CType(resources.GetObject("UsersGridView.Appearance.SelectedRow.Font"), System.Drawing.Font)
        Me.UsersGridView.Appearance.TopNewRow.Font = CType(resources.GetObject("UsersGridView.Appearance.TopNewRow.Font"), System.Drawing.Font)
        Me.UsersGridView.Appearance.VertLine.Font = CType(resources.GetObject("UsersGridView.Appearance.VertLine.Font"), System.Drawing.Font)
        Me.UsersGridView.Appearance.ViewCaption.Font = CType(resources.GetObject("UsersGridView.Appearance.ViewCaption.Font"), System.Drawing.Font)
        Me.UsersGridView.AppearancePrint.EvenRow.Font = CType(resources.GetObject("UsersGridView.AppearancePrint.EvenRow.Font"), System.Drawing.Font)
        Me.UsersGridView.AppearancePrint.FilterPanel.Font = CType(resources.GetObject("UsersGridView.AppearancePrint.FilterPanel.Font"), System.Drawing.Font)
        Me.UsersGridView.AppearancePrint.FooterPanel.Font = CType(resources.GetObject("UsersGridView.AppearancePrint.FooterPanel.Font"), System.Drawing.Font)
        Me.UsersGridView.AppearancePrint.GroupFooter.Font = CType(resources.GetObject("UsersGridView.AppearancePrint.GroupFooter.Font"), System.Drawing.Font)
        Me.UsersGridView.AppearancePrint.GroupRow.Font = CType(resources.GetObject("UsersGridView.AppearancePrint.GroupRow.Font"), System.Drawing.Font)
        Me.UsersGridView.AppearancePrint.HeaderPanel.Font = CType(resources.GetObject("UsersGridView.AppearancePrint.HeaderPanel.Font"), System.Drawing.Font)
        Me.UsersGridView.AppearancePrint.Lines.Font = CType(resources.GetObject("UsersGridView.AppearancePrint.Lines.Font"), System.Drawing.Font)
        Me.UsersGridView.AppearancePrint.OddRow.Font = CType(resources.GetObject("UsersGridView.AppearancePrint.OddRow.Font"), System.Drawing.Font)
        Me.UsersGridView.AppearancePrint.Preview.Font = CType(resources.GetObject("UsersGridView.AppearancePrint.Preview.Font"), System.Drawing.Font)
        Me.UsersGridView.AppearancePrint.Row.Font = CType(resources.GetObject("UsersGridView.AppearancePrint.Row.Font"), System.Drawing.Font)
        Me.UsersGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colSite, Me.colSiteType, Me.colSiteName, Me.colLogin})
        Me.UsersGridView.GridControl = Me.UsersGrid
        Me.UsersGridView.Name = "UsersGridView"
        Me.UsersGridView.OptionsBehavior.Editable = False
        Me.UsersGridView.OptionsView.ShowGroupPanel = False
        '
        'colSite
        '
        Me.colSite.AppearanceCell.Font = CType(resources.GetObject("colSite.AppearanceCell.Font"), System.Drawing.Font)
        Me.colSite.AppearanceHeader.Font = CType(resources.GetObject("colSite.AppearanceHeader.Font"), System.Drawing.Font)
        resources.ApplyResources(Me.colSite, "colSite")
        Me.colSite.ColumnEdit = Me.cbSiteID
        Me.colSite.FieldName = "idfsSite"
        Me.colSite.Name = "colSite"
        '
        'cbSiteID
        '
        Me.cbSiteID.Appearance.Font = CType(resources.GetObject("cbSiteID.Appearance.Font"), System.Drawing.Font)
        Me.cbSiteID.Appearance.Options.UseFont = True
        Me.cbSiteID.AppearanceDisabled.Font = CType(resources.GetObject("cbSiteID.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.cbSiteID.AppearanceDisabled.Options.UseFont = True
        Me.cbSiteID.AppearanceDropDown.Font = CType(resources.GetObject("cbSiteID.AppearanceDropDown.Font"), System.Drawing.Font)
        Me.cbSiteID.AppearanceDropDown.Options.UseFont = True
        Me.cbSiteID.AppearanceDropDownHeader.Font = CType(resources.GetObject("cbSiteID.AppearanceDropDownHeader.Font"), System.Drawing.Font)
        Me.cbSiteID.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbSiteID.AppearanceFocused.Font = CType(resources.GetObject("cbSiteID.AppearanceFocused.Font"), System.Drawing.Font)
        Me.cbSiteID.AppearanceFocused.Options.UseFont = True
        Me.cbSiteID.AppearanceReadOnly.Font = CType(resources.GetObject("cbSiteID.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.cbSiteID.AppearanceReadOnly.Options.UseFont = True
        resources.ApplyResources(Me.cbSiteID, "cbSiteID")
        resources.ApplyResources(SerializableAppearanceObject4, "SerializableAppearanceObject4")
        SerializableAppearanceObject4.Options.UseFont = True
        Me.cbSiteID.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSiteID.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbSiteID.Buttons1"), CType(resources.GetObject("cbSiteID.Buttons2"), Integer), CType(resources.GetObject("cbSiteID.Buttons3"), Boolean), CType(resources.GetObject("cbSiteID.Buttons4"), Boolean), CType(resources.GetObject("cbSiteID.Buttons5"), Boolean), CType(resources.GetObject("cbSiteID.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbSiteID.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject4, resources.GetString("cbSiteID.Buttons8"), CType(resources.GetObject("cbSiteID.Buttons9"), Object), CType(resources.GetObject("cbSiteID.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbSiteID.Buttons11"), Boolean))})
        Me.cbSiteID.Name = "cbSiteID"
        '
        'colSiteType
        '
        Me.colSiteType.AppearanceCell.Font = CType(resources.GetObject("colSiteType.AppearanceCell.Font"), System.Drawing.Font)
        Me.colSiteType.AppearanceHeader.Font = CType(resources.GetObject("colSiteType.AppearanceHeader.Font"), System.Drawing.Font)
        resources.ApplyResources(Me.colSiteType, "colSiteType")
        Me.colSiteType.ColumnEdit = Me.cbSiteType
        Me.colSiteType.FieldName = "idfsSite1"
        Me.colSiteType.Name = "colSiteType"
        '
        'cbSiteType
        '
        Me.cbSiteType.Appearance.Font = CType(resources.GetObject("cbSiteType.Appearance.Font"), System.Drawing.Font)
        Me.cbSiteType.Appearance.Options.UseFont = True
        Me.cbSiteType.AppearanceDisabled.Font = CType(resources.GetObject("cbSiteType.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.cbSiteType.AppearanceDisabled.Options.UseFont = True
        Me.cbSiteType.AppearanceDropDown.Font = CType(resources.GetObject("cbSiteType.AppearanceDropDown.Font"), System.Drawing.Font)
        Me.cbSiteType.AppearanceDropDown.Options.UseFont = True
        Me.cbSiteType.AppearanceDropDownHeader.Font = CType(resources.GetObject("cbSiteType.AppearanceDropDownHeader.Font"), System.Drawing.Font)
        Me.cbSiteType.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbSiteType.AppearanceFocused.Font = CType(resources.GetObject("cbSiteType.AppearanceFocused.Font"), System.Drawing.Font)
        Me.cbSiteType.AppearanceFocused.Options.UseFont = True
        Me.cbSiteType.AppearanceReadOnly.Font = CType(resources.GetObject("cbSiteType.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.cbSiteType.AppearanceReadOnly.Options.UseFont = True
        resources.ApplyResources(Me.cbSiteType, "cbSiteType")
        resources.ApplyResources(SerializableAppearanceObject5, "SerializableAppearanceObject5")
        SerializableAppearanceObject5.Options.UseFont = True
        Me.cbSiteType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSiteType.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbSiteType.Buttons1"), CType(resources.GetObject("cbSiteType.Buttons2"), Integer), CType(resources.GetObject("cbSiteType.Buttons3"), Boolean), CType(resources.GetObject("cbSiteType.Buttons4"), Boolean), CType(resources.GetObject("cbSiteType.Buttons5"), Boolean), CType(resources.GetObject("cbSiteType.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbSiteType.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject5, resources.GetString("cbSiteType.Buttons8"), CType(resources.GetObject("cbSiteType.Buttons9"), Object), CType(resources.GetObject("cbSiteType.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbSiteType.Buttons11"), Boolean))})
        Me.cbSiteType.Name = "cbSiteType"
        '
        'colSiteName
        '
        Me.colSiteName.AppearanceCell.Font = CType(resources.GetObject("colSiteName.AppearanceCell.Font"), System.Drawing.Font)
        Me.colSiteName.AppearanceHeader.Font = CType(resources.GetObject("colSiteName.AppearanceHeader.Font"), System.Drawing.Font)
        resources.ApplyResources(Me.colSiteName, "colSiteName")
        Me.colSiteName.ColumnEdit = Me.cbSiteName
        Me.colSiteName.FieldName = "idfsSite2"
        Me.colSiteName.Name = "colSiteName"
        '
        'cbSiteName
        '
        Me.cbSiteName.Appearance.Font = CType(resources.GetObject("cbSiteName.Appearance.Font"), System.Drawing.Font)
        Me.cbSiteName.Appearance.Options.UseFont = True
        Me.cbSiteName.AppearanceDisabled.Font = CType(resources.GetObject("cbSiteName.AppearanceDisabled.Font"), System.Drawing.Font)
        Me.cbSiteName.AppearanceDisabled.Options.UseFont = True
        Me.cbSiteName.AppearanceDropDown.Font = CType(resources.GetObject("cbSiteName.AppearanceDropDown.Font"), System.Drawing.Font)
        Me.cbSiteName.AppearanceDropDown.Options.UseFont = True
        Me.cbSiteName.AppearanceDropDownHeader.Font = CType(resources.GetObject("cbSiteName.AppearanceDropDownHeader.Font"), System.Drawing.Font)
        Me.cbSiteName.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbSiteName.AppearanceFocused.Font = CType(resources.GetObject("cbSiteName.AppearanceFocused.Font"), System.Drawing.Font)
        Me.cbSiteName.AppearanceFocused.Options.UseFont = True
        Me.cbSiteName.AppearanceReadOnly.Font = CType(resources.GetObject("cbSiteName.AppearanceReadOnly.Font"), System.Drawing.Font)
        Me.cbSiteName.AppearanceReadOnly.Options.UseFont = True
        resources.ApplyResources(Me.cbSiteName, "cbSiteName")
        resources.ApplyResources(SerializableAppearanceObject6, "SerializableAppearanceObject6")
        SerializableAppearanceObject6.Options.UseFont = True
        Me.cbSiteName.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSiteName.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbSiteName.Buttons1"), CType(resources.GetObject("cbSiteName.Buttons2"), Integer), CType(resources.GetObject("cbSiteName.Buttons3"), Boolean), CType(resources.GetObject("cbSiteName.Buttons4"), Boolean), CType(resources.GetObject("cbSiteName.Buttons5"), Boolean), CType(resources.GetObject("cbSiteName.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbSiteName.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject6, resources.GetString("cbSiteName.Buttons8"), CType(resources.GetObject("cbSiteName.Buttons9"), Object), CType(resources.GetObject("cbSiteName.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbSiteName.Buttons11"), Boolean))})
        Me.cbSiteName.Name = "cbSiteName"
        '
        'colLogin
        '
        Me.colLogin.AppearanceCell.Font = CType(resources.GetObject("colLogin.AppearanceCell.Font"), System.Drawing.Font)
        Me.colLogin.AppearanceHeader.Font = CType(resources.GetObject("colLogin.AppearanceHeader.Font"), System.Drawing.Font)
        resources.ApplyResources(Me.colLogin, "colLogin")
        Me.colLogin.FieldName = "strAccountName"
        Me.colLogin.Name = "colLogin"
        '
        'PersonDetail
        '
        Me.Appearance.Font = CType(resources.GetObject("PersonDetail.Appearance.Font"), System.Drawing.Font)
        Me.Appearance.Options.UseFont = True
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.tbPerson)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "A09"
        Me.HelpTopicID = "Persons_List"
        Me.KeyFieldName = "idfPerson"
        Me.LeftIcon = Global.EIDSS.My.Resources.Resources.Employee_128_
        Me.Name = "PersonDetail"
        Me.ObjectName = "Person"
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "Person"
        Me.Controls.SetChildIndex(Me.tbPerson, 0)
        CType(Me.tbPerson, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbPerson.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.txtFirstName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMiddleName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLastName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbOrganization.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDepartment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbRank.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbLoginInfo.ResumeLayout(False)
        CType(Me.UsersGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UsersGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSiteID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSiteType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSiteName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Overrides Sub DefineBinding()
        Try

            ' Lookup_Db.FillSiteLookup(Me.baseDataSet)

            If (EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSS.model.Enums.EIDSSPermissionObject.User)) = False) Then
                Me.tbPerson.TabPages.Remove(tbLoginInfo)
            End If
            'Person binding
            If Not StartUpParameters Is Nothing AndAlso StartUpParameters.ContainsKey("OrganizationID") AndAlso Utils.ToLong(StartUpParameters("OrganizationID")) > 0 Then
                baseDataSet.Tables(Person_DB.TablePerson).Rows(0)("idfInstitution") = StartUpParameters("OrganizationID")
                cbOrganization.Enabled = False
            End If
            'TextBox binding template
            Core.LookupBinder.BindTextEdit(txtFirstName, baseDataSet, Person_DB.TablePerson + ".strFirstName")
            Core.LookupBinder.BindTextEdit(txtMiddleName, baseDataSet, Person_DB.TablePerson + ".strSecondName")
            Core.LookupBinder.BindTextEdit(txtLastName, baseDataSet, Person_DB.TablePerson + ".strFamilyName")

            'Combobox binding template
            Core.LookupBinder.BindOrganizationLookup(cbOrganization, baseDataSet, Person_DB.TablePerson + ".idfInstitution", HACode.None)
            Core.LookupBinder.BindDepartmentLookup(cbDepartment, baseDataSet, Person_DB.TablePerson + ".idfDepartment")
            Core.LookupBinder.BindBaseLookup(cbRank, baseDataSet, Person_DB.TablePerson + ".idfsStaffPosition", db.BaseReferenceType.rftPosition, True, True)
            SetDepartmentFilter()
            eventManager.AttachDataHandler(Person_DB.TablePerson + ".idfInstitution", AddressOf Organization_Changed)

            Core.LookupBinder.BindSiteRepositoryLookup(Me.cbSiteID, False)
            Core.LookupBinder.BindSiteRepositoryLookup(Me.cbSiteType, False)
            Me.cbSiteType.DisplayMember = "strSiteType"
            Core.LookupBinder.BindSiteRepositoryLookup(Me.cbSiteName, False)
            Me.cbSiteName.DisplayMember = "strSiteName"

            If (MultiSite) Then
                Me.UsersGrid.DataSource = baseDataSet.Tables("UserTable")
            Else
                Me.UsersGrid.DataSource = New DataView(baseDataSet.Tables("UserTable"), "idfsSite=" + EIDSS.model.Core.EidssSiteContext.Instance.SiteID.ToString, Nothing, DataViewRowState.CurrentRows)
            End If
            UpdateLoginState()

        Catch e As Exception
            Dbg.Debug(e.Message)
        End Try

    End Sub

    Private Sub UpdateLoginState()
        Dim selected As Boolean = UsersGridView.FocusedRowHandle >= 0
        Dim unassignedSitesExist As Boolean = Me.baseDataSet.Tables("UserTable").Rows.Count < LookupCache.Get(LookupTables.Site).Count

        If Me.MultiSite Then
            cmdNewLogin.Enabled = unassignedSitesExist And EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission(EIDSS.model.Enums.EIDSSPermissionObject.User))
        Else
            cmdNewLogin.Enabled = (Me.UsersGridView.RowCount = 0)
        End If
        cmdEdit.Enabled = selected And EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.UpdatePermission(EIDSS.model.Enums.EIDSSPermissionObject.User))
        cmdDeleteLogin.Enabled = selected And EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.DeletePermission(EIDSS.model.Enums.EIDSSPermissionObject.User))
        Exit Sub
    End Sub
    Private Function TableNotDelRowCount(ByVal Table As DataTable) As Integer
        Dim res As Integer = 0
        For Each r As DataRow In Table.Rows
            If r.RowState <> DataRowState.Deleted Then
                res = res + 1
            End If
        Next
        Return res
    End Function

    Private Function TableNotDelRowHandle(ByVal Table As DataTable) As Integer
        Dim res As Integer = 0
        If TableNotDelRowCount(Table) > 0 Then
            While res < Table.Rows.Count AndAlso Table.Rows(res).RowState = DataRowState.Deleted
                res = res + 1
            End While
            If res = Table.Rows.Count Then res = -1
        Else
            res = -1
        End If
        Return res
    End Function


    Private Sub Organization_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        SetDepartmentFilter()
    End Sub

    Sub SetDepartmentFilter()
        If cbDepartment.Properties.DataSource Is Nothing Then Exit Sub
        Dim dw As DataView = CType(cbDepartment.Properties.DataSource, DataView)
        Dim organization As Object = -1
        If Not Utils.IsEmpty(baseDataSet.Tables(Person_DB.TablePerson).Rows(0)("idfInstitution")) Then
            organization = baseDataSet.Tables(Person_DB.TablePerson).Rows(0)("idfInstitution")
        End If
        dw.RowFilter = String.Format("idfInstitution={0}", organization)
    End Sub

    Private Function LoginExists() As Boolean
        Return baseDataSet.Tables("UserTable").Rows.Count > 0
    End Function

    Public Overrides Function ValidateData() As Boolean
        Dim curTab As XtraTabPage = Me.tbPerson.SelectedTabPage
        Me.SuspendLayout()
        For Each tab As XtraTabPage In tbPerson.TabPages
            Me.tbPerson.SelectedTabPage = tab
            If Not MyBase.ValidateData() Then
                Return False
            End If
        Next
        Me.tbPerson.SelectedTabPage = curTab
        Me.ResumeLayout()
        Return True
    End Function

    Private Sub cmdDeleteLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteLogin.Click
        Dim selection As Integer() = Me.UsersGridView.GetSelectedRows()
        If selection Is Nothing OrElse selection.Length = 0 Then Exit Sub
        If WinUtils.ConfirmDelete() Then
            Me.UsersGridView.DeleteSelectedRows()
            UpdateLoginState()
        End If
    End Sub

    Private Function ShowLogin(ByRef original As DataRow) As Boolean
        Using ds As New DataSet
            Dim originalTable As DataTable = Me.baseDataSet.Tables("UserTable")
            Dim users As DataTable = originalTable.Clone
            ds.Tables.Add(users)
            ds.Tables.Add(Me.baseDataSet.Tables(SecurityPolicy_DB.Table).Copy)
            ds.Tables.Add(Me.baseDataSet.Tables(SecurityPolicy_DB.Alphabet).Copy)
            ds.EnforceConstraints = False

            Dim row As DataRow = users.NewRow
            If original Is Nothing Then
                'sites = Me.CreateSiteTable()
                row("idfUserID") = BaseDbService.NewIntID
                row("idfPerson") = Me.DbService.ID
            Else
                row.ItemArray = original.ItemArray
            End If
            users.Rows.Add(row)

            If Not (original Is Nothing) Then ds.AcceptChanges()
            Dim startupParams As New Dictionary(Of String, Object)
            startupParams.Add("Dataset", baseDataSet)
            Dim loginForm As New LoginDetail(ds)
            loginForm.StartUpParameters = startupParams

            If BaseFormManager.ShowModal(loginForm, Me) = False Then
                DbDisposeHelper.ClearDataset(ds)
                Exit Function
            End If

            If original Is Nothing Then
                originalTable.Rows.Add(row.ItemArray)
            Else
                For Each col As DataColumn In row.Table.Columns
                    If Utils.IsEmpty(col.Expression) Then original(col.ColumnName) = row(col.ColumnName)
                Next
            End If
            UpdateLoginState()
        End Using
    End Function


    Private Sub cmdNewLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNewLogin.Click
        Me.ShowLogin(Nothing)
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        Dim selection As Integer() = Me.UsersGridView.GetSelectedRows()
        If selection Is Nothing OrElse selection.Length = 0 Then Exit Sub
        Dim original As DataRow = Me.UsersGridView.GetDataRow(selection(0))
        Me.ShowLogin(original)
    End Sub

    Private Sub PersonDetail_AfterLoadData(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.AfterLoadData
        If Not StartUpParameters Is Nothing AndAlso StartUpParameters.ContainsKey("OrganizationID") AndAlso Utils.ToLong(StartUpParameters("OrganizationID")) > 0 Then
            cbOrganization.Enabled = False
        End If
    End Sub

    Private Sub GridView1_SelectionChanged(ByVal sender As System.Object, ByVal e As DevExpress.Data.SelectionChangedEventArgs) Handles UsersGridView.SelectionChanged
        Me.UpdateLoginState()
    End Sub

    Private Sub GridView1_DblClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsersGridView.DoubleClick
        cmdEdit_Click(Nothing, Nothing)
    End Sub
End Class
