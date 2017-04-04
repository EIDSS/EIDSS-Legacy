Imports bv.winclient.Core
Imports EIDSS.model.Enums

Public Class SiteActivationServerDetail

    Inherits BaseDetailForm

    Dim SiteActivationServerDbService As SiteActivationServer_DB
    Friend WithEvents lbSiteCode As System.Windows.Forms.Label
    Friend WithEvents txtSiteCode As DevExpress.XtraEditors.TextEdit
    Dim permissionsWindow As BaseDetailPanel

#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()


        'This call is required by the Windows Form Designer.
        InitializeComponent()
        If BaseSettings.ScanFormsMode Then
            Return
        End If
        Me.TabCtrl.TabPages.Remove(Me.tpNotification)
        Me.TabCtrl.TabPages.Remove(Me.tpReplication)

        'Add any initialization after the InitializeComponent() call
        SiteActivationServerDbService = New SiteActivationServer_DB

        DbService = SiteActivationServerDbService
        AuditObject = New AuditObject(EIDSSAuditObject.daoSite, AuditTable.tstSite)
        Me.PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.EIDSSSite


        Dim permissions As StandardAccessPermissions = New StandardAccessPermissions(EIDSS.model.Enums.EIDSSPermissionObject.DataAccess)
        If permissions.CanSelect Then
            Dim dummy As Object
            dummy = ClassLoader.LoadClass("ObjectAccessPanel")
            If (Not dummy Is Nothing) Then
                permissionsWindow = CType(dummy, BaseDetailPanel)
            End If
            'Set required property "ObjectType"
            Dim pi As System.Reflection.PropertyInfo
            pi = permissionsWindow.GetType().GetProperty("ObjectType")
            pi.SetValue(permissionsWindow, ObjectType.Site, Nothing)

            Me.RegisterChildObject(permissionsWindow, RelatedPostOrder.PostLast)

            Me.tpPermissions.Controls.Add(permissionsWindow)
            permissionsWindow.Parent = Me.tpPermissions
            permissionsWindow.Visible = True
            permissionsWindow.Dock = DockStyle.Fill
        Else
            Me.TabCtrl.TabPages.Remove(Me.tpPermissions)
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
    Friend WithEvents TabCtrl As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tpGeneral As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents lblCountry As System.Windows.Forms.Label
    Friend WithEvents txtServerName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblServerName As System.Windows.Forms.Label
    Friend WithEvents cbSiteType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtSiteName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblSiteNameAndType As System.Windows.Forms.Label
    Friend WithEvents cbOrganization As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblOffice As System.Windows.Forms.Label
    Friend WithEvents txtSiteID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblSiteID As System.Windows.Forms.Label
    Friend WithEvents cbCountry As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents tpReplication As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tpNotification As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents lblParentSite As System.Windows.Forms.Label
    Friend WithEvents cbParentSite As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblChildSiteList As System.Windows.Forms.Label
    Friend WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnRemove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gcChildSiteList As DevExpress.XtraGrid.GridControl
    Friend WithEvents ChildSiteListView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gcolSiteID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolSite_Type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolAbbr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolParentSiteID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolSite_Relation As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolSite_Relation_Type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbChildSite As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents gcolRC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcNotificationTo As DevExpress.XtraGrid.GridControl
    Friend WithEvents NotificationToView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gcolNToSite_Relation As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolNToParentSiteID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolNToSiteID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbNotificationToSite As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents gcolNToSite_Relation_Type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolNToSite_Type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolNToAbbr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolNToName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolNToRC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnNToRemove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnNToAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblNotificationTo As System.Windows.Forms.Label
    Friend WithEvents btnNFromRemove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnNFromAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblNotificationFrom As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents gcNotificationFrom As DevExpress.XtraGrid.GridControl
    Friend WithEvents NotificationFromView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gcolNFromSite_Relation As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolNFromRelativeSiteID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolNFromSiteID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolNFromSite_Relation_Type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolNFromSite_Type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolNFromAbbr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolNFromName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolNFromRC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbNotificationFromSite As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents tpPermissions As DevExpress.XtraTab.XtraTabPage

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SiteActivationServerDetail))
        Me.TabCtrl = New DevExpress.XtraTab.XtraTabControl()
        Me.tpGeneral = New DevExpress.XtraTab.XtraTabPage()
        Me.txtSiteCode = New DevExpress.XtraEditors.TextEdit()
        Me.txtServerName = New DevExpress.XtraEditors.TextEdit()
        Me.cbSiteType = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtSiteName = New DevExpress.XtraEditors.TextEdit()
        Me.cbOrganization = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtSiteID = New DevExpress.XtraEditors.TextEdit()
        Me.cbCountry = New DevExpress.XtraEditors.LookUpEdit()
        Me.lbSiteCode = New System.Windows.Forms.Label()
        Me.lblCountry = New System.Windows.Forms.Label()
        Me.lblServerName = New System.Windows.Forms.Label()
        Me.lblSiteNameAndType = New System.Windows.Forms.Label()
        Me.lblOffice = New System.Windows.Forms.Label()
        Me.lblSiteID = New System.Windows.Forms.Label()
        Me.tpReplication = New DevExpress.XtraTab.XtraTabPage()
        Me.gcChildSiteList = New DevExpress.XtraGrid.GridControl()
        Me.ChildSiteListView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gcolSite_Relation = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolParentSiteID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolSiteID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbChildSite = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.gcolSite_Relation_Type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolSite_Type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolAbbr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolRC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.btnRemove = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.lblChildSiteList = New System.Windows.Forms.Label()
        Me.cbParentSite = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblParentSite = New System.Windows.Forms.Label()
        Me.tpNotification = New DevExpress.XtraTab.XtraTabPage()
        Me.gcNotificationFrom = New DevExpress.XtraGrid.GridControl()
        Me.NotificationFromView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gcolNFromSite_Relation = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolNFromRelativeSiteID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolNFromSiteID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbNotificationFromSite = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.gcolNFromSite_Relation_Type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolNFromSite_Type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolNFromAbbr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolNFromName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolNFromRC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnNFromRemove = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNFromAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.lblNotificationFrom = New System.Windows.Forms.Label()
        Me.btnNToRemove = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNToAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.lblNotificationTo = New System.Windows.Forms.Label()
        Me.gcNotificationTo = New DevExpress.XtraGrid.GridControl()
        Me.NotificationToView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gcolNToSite_Relation = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolNToParentSiteID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolNToSiteID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbNotificationToSite = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.gcolNToSite_Relation_Type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolNToSite_Type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolNToAbbr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolNToName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolNToRC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.tpPermissions = New DevExpress.XtraTab.XtraTabPage()
        CType(Me.TabCtrl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabCtrl.SuspendLayout()
        Me.tpGeneral.SuspendLayout()
        CType(Me.txtSiteCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtServerName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSiteType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSiteName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbOrganization.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSiteID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCountry.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpReplication.SuspendLayout()
        CType(Me.gcChildSiteList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChildSiteListView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbChildSite, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbParentSite.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpNotification.SuspendLayout()
        CType(Me.gcNotificationFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NotificationFromView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbNotificationFromSite, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcNotificationTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NotificationToView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbNotificationToSite, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(SiteActivationServerDetail), resources)
        'Form Is Localizable: True
        '
        'TabCtrl
        '
        resources.ApplyResources(Me.TabCtrl, "TabCtrl")
        Me.TabCtrl.Name = "TabCtrl"
        Me.TabCtrl.SelectedTabPage = Me.tpGeneral
        Me.TabCtrl.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tpGeneral, Me.tpReplication, Me.tpNotification, Me.tpPermissions})
        '
        'tpGeneral
        '
        Me.tpGeneral.Controls.Add(Me.txtSiteCode)
        Me.tpGeneral.Controls.Add(Me.txtServerName)
        Me.tpGeneral.Controls.Add(Me.cbSiteType)
        Me.tpGeneral.Controls.Add(Me.txtSiteName)
        Me.tpGeneral.Controls.Add(Me.cbOrganization)
        Me.tpGeneral.Controls.Add(Me.txtSiteID)
        Me.tpGeneral.Controls.Add(Me.cbCountry)
        Me.tpGeneral.Controls.Add(Me.lbSiteCode)
        Me.tpGeneral.Controls.Add(Me.lblCountry)
        Me.tpGeneral.Controls.Add(Me.lblServerName)
        Me.tpGeneral.Controls.Add(Me.lblSiteNameAndType)
        Me.tpGeneral.Controls.Add(Me.lblOffice)
        Me.tpGeneral.Controls.Add(Me.lblSiteID)
        Me.tpGeneral.Name = "tpGeneral"
        resources.ApplyResources(Me.tpGeneral, "tpGeneral")
        '
        'txtSiteCode
        '
        resources.ApplyResources(Me.txtSiteCode, "txtSiteCode")
        Me.txtSiteCode.Name = "txtSiteCode"
        Me.txtSiteCode.Tag = "{K}"
        '
        'txtServerName
        '
        resources.ApplyResources(Me.txtServerName, "txtServerName")
        Me.txtServerName.Name = "txtServerName"
        Me.txtServerName.Tag = "{M}"
        '
        'cbSiteType
        '
        resources.ApplyResources(Me.cbSiteType, "cbSiteType")
        Me.cbSiteType.Name = "cbSiteType"
        Me.cbSiteType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSiteType.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbSiteType.Tag = "{KM}"
        '
        'txtSiteName
        '
        resources.ApplyResources(Me.txtSiteName, "txtSiteName")
        Me.txtSiteName.Name = "txtSiteName"
        Me.txtSiteName.Tag = "{KM}"
        '
        'cbOrganization
        '
        resources.ApplyResources(Me.cbOrganization, "cbOrganization")
        Me.cbOrganization.Name = "cbOrganization"
        Me.cbOrganization.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbOrganization.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines)), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbOrganization.Properties.Buttons1"), DevExpress.XtraEditors.Controls.ButtonPredefines)), New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.cbOrganization.Tag = "{M}"
        '
        'txtSiteID
        '
        resources.ApplyResources(Me.txtSiteID, "txtSiteID")
        Me.txtSiteID.Name = "txtSiteID"
        Me.txtSiteID.Tag = "{K}"
        '
        'cbCountry
        '
        resources.ApplyResources(Me.cbCountry, "cbCountry")
        Me.cbCountry.Name = "cbCountry"
        Me.cbCountry.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbCountry.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbCountry.Tag = "{M}"
        '
        'lbSiteCode
        '
        resources.ApplyResources(Me.lbSiteCode, "lbSiteCode")
        Me.lbSiteCode.Name = "lbSiteCode"
        '
        'lblCountry
        '
        resources.ApplyResources(Me.lblCountry, "lblCountry")
        Me.lblCountry.Name = "lblCountry"
        '
        'lblServerName
        '
        resources.ApplyResources(Me.lblServerName, "lblServerName")
        Me.lblServerName.Name = "lblServerName"
        '
        'lblSiteNameAndType
        '
        resources.ApplyResources(Me.lblSiteNameAndType, "lblSiteNameAndType")
        Me.lblSiteNameAndType.Name = "lblSiteNameAndType"
        '
        'lblOffice
        '
        resources.ApplyResources(Me.lblOffice, "lblOffice")
        Me.lblOffice.Name = "lblOffice"
        '
        'lblSiteID
        '
        resources.ApplyResources(Me.lblSiteID, "lblSiteID")
        Me.lblSiteID.Name = "lblSiteID"
        '
        'tpReplication
        '
        Me.tpReplication.Controls.Add(Me.gcChildSiteList)
        Me.tpReplication.Controls.Add(Me.btnRemove)
        Me.tpReplication.Controls.Add(Me.btnAdd)
        Me.tpReplication.Controls.Add(Me.lblChildSiteList)
        Me.tpReplication.Controls.Add(Me.cbParentSite)
        Me.tpReplication.Controls.Add(Me.lblParentSite)
        Me.tpReplication.Name = "tpReplication"
        resources.ApplyResources(Me.tpReplication, "tpReplication")
        '
        'gcChildSiteList
        '
        resources.ApplyResources(Me.gcChildSiteList, "gcChildSiteList")
        Me.gcChildSiteList.MainView = Me.ChildSiteListView
        Me.gcChildSiteList.Name = "gcChildSiteList"
        Me.gcChildSiteList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbChildSite})
        Me.gcChildSiteList.TabStop = False
        Me.gcChildSiteList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ChildSiteListView, Me.GridView1})
        '
        'ChildSiteListView
        '
        Me.ChildSiteListView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gcolSite_Relation, Me.gcolParentSiteID, Me.gcolSiteID, Me.gcolSite_Relation_Type, Me.gcolSite_Type, Me.gcolAbbr, Me.gcolName, Me.gcolRC})
        Me.ChildSiteListView.GridControl = Me.gcChildSiteList
        resources.ApplyResources(Me.ChildSiteListView, "ChildSiteListView")
        Me.ChildSiteListView.Name = "ChildSiteListView"
        Me.ChildSiteListView.OptionsNavigation.AutoFocusNewRow = True
        Me.ChildSiteListView.OptionsView.ShowGroupPanel = False
        '
        'gcolSite_Relation
        '
        resources.ApplyResources(Me.gcolSite_Relation, "gcolSite_Relation")
        Me.gcolSite_Relation.FieldName = "idfSiteRelation"
        Me.gcolSite_Relation.Name = "gcolSite_Relation"
        '
        'gcolParentSiteID
        '
        resources.ApplyResources(Me.gcolParentSiteID, "gcolParentSiteID")
        Me.gcolParentSiteID.FieldName = "idfsParentSite"
        Me.gcolParentSiteID.Name = "gcolParentSiteID"
        '
        'gcolSiteID
        '
        Me.gcolSiteID.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolSiteID, "gcolSiteID")
        Me.gcolSiteID.ColumnEdit = Me.cbChildSite
        Me.gcolSiteID.FieldName = "idfsRelativeSite"
        Me.gcolSiteID.Name = "gcolSiteID"
        '
        'cbChildSite
        '
        resources.ApplyResources(Me.cbChildSite, "cbChildSite")
        Me.cbChildSite.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbChildSite.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbChildSite.Name = "cbChildSite"
        '
        'gcolSite_Relation_Type
        '
        resources.ApplyResources(Me.gcolSite_Relation_Type, "gcolSite_Relation_Type")
        Me.gcolSite_Relation_Type.FieldName = "idfsSiteRelationType"
        Me.gcolSite_Relation_Type.Name = "gcolSite_Relation_Type"
        '
        'gcolSite_Type
        '
        Me.gcolSite_Type.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolSite_Type, "gcolSite_Type")
        Me.gcolSite_Type.FieldName = "idfsSiteType"
        Me.gcolSite_Type.Name = "gcolSite_Type"
        Me.gcolSite_Type.OptionsColumn.AllowFocus = False
        '
        'gcolAbbr
        '
        Me.gcolAbbr.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolAbbr, "gcolAbbr")
        Me.gcolAbbr.FieldName = "OfficeAbbreviation"
        Me.gcolAbbr.Name = "gcolAbbr"
        Me.gcolAbbr.OptionsColumn.AllowFocus = False
        '
        'gcolName
        '
        Me.gcolName.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolName, "gcolName")
        Me.gcolName.FieldName = "OfficeName"
        Me.gcolName.Name = "gcolName"
        Me.gcolName.OptionsColumn.AllowFocus = False
        '
        'gcolRC
        '
        resources.ApplyResources(Me.gcolRC, "gcolRC")
        Me.gcolRC.FieldName = "idfsRC"
        Me.gcolRC.Name = "gcolRC"
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8})
        Me.GridView1.GridControl = Me.gcChildSiteList
        resources.ApplyResources(Me.GridView1, "GridView1")
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsNavigation.AutoFocusNewRow = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        resources.ApplyResources(Me.GridColumn1, "GridColumn1")
        Me.GridColumn1.FieldName = "idfSiteRelation"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        resources.ApplyResources(Me.GridColumn2, "GridColumn2")
        Me.GridColumn2.FieldName = "idfsParentSite"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn3
        '
        resources.ApplyResources(Me.GridColumn3, "GridColumn3")
        Me.GridColumn3.ColumnEdit = Me.RepositoryItemLookUpEdit1
        Me.GridColumn3.FieldName = "idfsRelativeSite"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'RepositoryItemLookUpEdit1
        '
        resources.ApplyResources(Me.RepositoryItemLookUpEdit1, "RepositoryItemLookUpEdit1")
        Me.RepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryItemLookUpEdit1.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryItemLookUpEdit1.Name = "RepositoryItemLookUpEdit1"
        '
        'GridColumn4
        '
        resources.ApplyResources(Me.GridColumn4, "GridColumn4")
        Me.GridColumn4.FieldName = "idfsSiteRelationType"
        Me.GridColumn4.Name = "GridColumn4"
        '
        'GridColumn5
        '
        resources.ApplyResources(Me.GridColumn5, "GridColumn5")
        Me.GridColumn5.FieldName = "idfsSiteType"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowFocus = False
        '
        'GridColumn6
        '
        resources.ApplyResources(Me.GridColumn6, "GridColumn6")
        Me.GridColumn6.FieldName = "OfficeAbbreviation"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowFocus = False
        '
        'GridColumn7
        '
        resources.ApplyResources(Me.GridColumn7, "GridColumn7")
        Me.GridColumn7.FieldName = "OfficeName"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowFocus = False
        '
        'GridColumn8
        '
        resources.ApplyResources(Me.GridColumn8, "GridColumn8")
        Me.GridColumn8.FieldName = "idfsRC"
        Me.GridColumn8.Name = "GridColumn8"
        '
        'btnRemove
        '
        resources.ApplyResources(Me.btnRemove, "btnRemove")
        Me.btnRemove.Name = "btnRemove"
        '
        'btnAdd
        '
        resources.ApplyResources(Me.btnAdd, "btnAdd")
        Me.btnAdd.Name = "btnAdd"
        '
        'lblChildSiteList
        '
        resources.ApplyResources(Me.lblChildSiteList, "lblChildSiteList")
        Me.lblChildSiteList.Name = "lblChildSiteList"
        '
        'cbParentSite
        '
        resources.ApplyResources(Me.cbParentSite, "cbParentSite")
        Me.cbParentSite.Name = "cbParentSite"
        Me.cbParentSite.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbParentSite.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbParentSite.Properties.NullText = resources.GetString("cbParentSite.Properties.NullText")
        '
        'lblParentSite
        '
        resources.ApplyResources(Me.lblParentSite, "lblParentSite")
        Me.lblParentSite.Name = "lblParentSite"
        '
        'tpNotification
        '
        Me.tpNotification.Controls.Add(Me.gcNotificationFrom)
        Me.tpNotification.Controls.Add(Me.GroupBox2)
        Me.tpNotification.Controls.Add(Me.btnNFromRemove)
        Me.tpNotification.Controls.Add(Me.btnNFromAdd)
        Me.tpNotification.Controls.Add(Me.lblNotificationFrom)
        Me.tpNotification.Controls.Add(Me.btnNToRemove)
        Me.tpNotification.Controls.Add(Me.btnNToAdd)
        Me.tpNotification.Controls.Add(Me.lblNotificationTo)
        Me.tpNotification.Controls.Add(Me.gcNotificationTo)
        Me.tpNotification.Name = "tpNotification"
        resources.ApplyResources(Me.tpNotification, "tpNotification")
        '
        'gcNotificationFrom
        '
        resources.ApplyResources(Me.gcNotificationFrom, "gcNotificationFrom")
        Me.gcNotificationFrom.MainView = Me.NotificationFromView
        Me.gcNotificationFrom.Name = "gcNotificationFrom"
        Me.gcNotificationFrom.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbNotificationFromSite})
        Me.gcNotificationFrom.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.NotificationFromView})
        '
        'NotificationFromView
        '
        Me.NotificationFromView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gcolNFromSite_Relation, Me.gcolNFromRelativeSiteID, Me.gcolNFromSiteID, Me.gcolNFromSite_Relation_Type, Me.gcolNFromSite_Type, Me.gcolNFromAbbr, Me.gcolNFromName, Me.gcolNFromRC})
        Me.NotificationFromView.GridControl = Me.gcNotificationFrom
        resources.ApplyResources(Me.NotificationFromView, "NotificationFromView")
        Me.NotificationFromView.Name = "NotificationFromView"
        Me.NotificationFromView.OptionsNavigation.AutoFocusNewRow = True
        Me.NotificationFromView.OptionsView.ShowGroupPanel = False
        '
        'gcolNFromSite_Relation
        '
        resources.ApplyResources(Me.gcolNFromSite_Relation, "gcolNFromSite_Relation")
        Me.gcolNFromSite_Relation.FieldName = "idfSiteRelation"
        Me.gcolNFromSite_Relation.Name = "gcolNFromSite_Relation"
        '
        'gcolNFromRelativeSiteID
        '
        resources.ApplyResources(Me.gcolNFromRelativeSiteID, "gcolNFromRelativeSiteID")
        Me.gcolNFromRelativeSiteID.FieldName = "idfsRelativeSite"
        Me.gcolNFromRelativeSiteID.Name = "gcolNFromRelativeSiteID"
        '
        'gcolNFromSiteID
        '
        Me.gcolNFromSiteID.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolNFromSiteID, "gcolNFromSiteID")
        Me.gcolNFromSiteID.ColumnEdit = Me.cbNotificationFromSite
        Me.gcolNFromSiteID.FieldName = "idfsParentSite"
        Me.gcolNFromSiteID.Name = "gcolNFromSiteID"
        '
        'cbNotificationFromSite
        '
        resources.ApplyResources(Me.cbNotificationFromSite, "cbNotificationFromSite")
        Me.cbNotificationFromSite.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbNotificationFromSite.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbNotificationFromSite.Name = "cbNotificationFromSite"
        '
        'gcolNFromSite_Relation_Type
        '
        resources.ApplyResources(Me.gcolNFromSite_Relation_Type, "gcolNFromSite_Relation_Type")
        Me.gcolNFromSite_Relation_Type.FieldName = "idfsSiteRelationType"
        Me.gcolNFromSite_Relation_Type.Name = "gcolNFromSite_Relation_Type"
        '
        'gcolNFromSite_Type
        '
        Me.gcolNFromSite_Type.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolNFromSite_Type, "gcolNFromSite_Type")
        Me.gcolNFromSite_Type.FieldName = "idfsSiteType"
        Me.gcolNFromSite_Type.Name = "gcolNFromSite_Type"
        Me.gcolNFromSite_Type.OptionsColumn.AllowFocus = False
        '
        'gcolNFromAbbr
        '
        Me.gcolNFromAbbr.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolNFromAbbr, "gcolNFromAbbr")
        Me.gcolNFromAbbr.FieldName = "OfficeAbbreviation"
        Me.gcolNFromAbbr.Name = "gcolNFromAbbr"
        Me.gcolNFromAbbr.OptionsColumn.AllowFocus = False
        '
        'gcolNFromName
        '
        Me.gcolNFromName.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolNFromName, "gcolNFromName")
        Me.gcolNFromName.FieldName = "OfficeName"
        Me.gcolNFromName.Name = "gcolNFromName"
        Me.gcolNFromName.OptionsColumn.AllowFocus = False
        '
        'gcolNFromRC
        '
        resources.ApplyResources(Me.gcolNFromRC, "gcolNFromRC")
        Me.gcolNFromRC.FieldName = "idfsRC"
        Me.gcolNFromRC.Name = "gcolNFromRC"
        '
        'GroupBox2
        '
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'btnNFromRemove
        '
        resources.ApplyResources(Me.btnNFromRemove, "btnNFromRemove")
        Me.btnNFromRemove.Name = "btnNFromRemove"
        '
        'btnNFromAdd
        '
        resources.ApplyResources(Me.btnNFromAdd, "btnNFromAdd")
        Me.btnNFromAdd.Name = "btnNFromAdd"
        '
        'lblNotificationFrom
        '
        resources.ApplyResources(Me.lblNotificationFrom, "lblNotificationFrom")
        Me.lblNotificationFrom.Name = "lblNotificationFrom"
        '
        'btnNToRemove
        '
        resources.ApplyResources(Me.btnNToRemove, "btnNToRemove")
        Me.btnNToRemove.Name = "btnNToRemove"
        '
        'btnNToAdd
        '
        resources.ApplyResources(Me.btnNToAdd, "btnNToAdd")
        Me.btnNToAdd.Name = "btnNToAdd"
        '
        'lblNotificationTo
        '
        resources.ApplyResources(Me.lblNotificationTo, "lblNotificationTo")
        Me.lblNotificationTo.Name = "lblNotificationTo"
        '
        'gcNotificationTo
        '
        resources.ApplyResources(Me.gcNotificationTo, "gcNotificationTo")
        Me.gcNotificationTo.MainView = Me.NotificationToView
        Me.gcNotificationTo.Name = "gcNotificationTo"
        Me.gcNotificationTo.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbNotificationToSite})
        Me.gcNotificationTo.TabStop = False
        Me.gcNotificationTo.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.NotificationToView})
        '
        'NotificationToView
        '
        Me.NotificationToView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gcolNToSite_Relation, Me.gcolNToParentSiteID, Me.gcolNToSiteID, Me.gcolNToSite_Relation_Type, Me.gcolNToSite_Type, Me.gcolNToAbbr, Me.gcolNToName, Me.gcolNToRC})
        Me.NotificationToView.GridControl = Me.gcNotificationTo
        resources.ApplyResources(Me.NotificationToView, "NotificationToView")
        Me.NotificationToView.Name = "NotificationToView"
        Me.NotificationToView.OptionsNavigation.AutoFocusNewRow = True
        Me.NotificationToView.OptionsView.ShowGroupPanel = False
        '
        'gcolNToSite_Relation
        '
        resources.ApplyResources(Me.gcolNToSite_Relation, "gcolNToSite_Relation")
        Me.gcolNToSite_Relation.FieldName = "idfSiteRelation"
        Me.gcolNToSite_Relation.Name = "gcolNToSite_Relation"
        '
        'gcolNToParentSiteID
        '
        resources.ApplyResources(Me.gcolNToParentSiteID, "gcolNToParentSiteID")
        Me.gcolNToParentSiteID.FieldName = "idfsParentSite"
        Me.gcolNToParentSiteID.Name = "gcolNToParentSiteID"
        '
        'gcolNToSiteID
        '
        Me.gcolNToSiteID.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolNToSiteID, "gcolNToSiteID")
        Me.gcolNToSiteID.ColumnEdit = Me.cbNotificationToSite
        Me.gcolNToSiteID.FieldName = "idfsRelativeSite"
        Me.gcolNToSiteID.Name = "gcolNToSiteID"
        '
        'cbNotificationToSite
        '
        resources.ApplyResources(Me.cbNotificationToSite, "cbNotificationToSite")
        Me.cbNotificationToSite.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbNotificationToSite.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbNotificationToSite.Name = "cbNotificationToSite"
        '
        'gcolNToSite_Relation_Type
        '
        resources.ApplyResources(Me.gcolNToSite_Relation_Type, "gcolNToSite_Relation_Type")
        Me.gcolNToSite_Relation_Type.FieldName = "idfsSiteRelationType"
        Me.gcolNToSite_Relation_Type.Name = "gcolNToSite_Relation_Type"
        '
        'gcolNToSite_Type
        '
        Me.gcolNToSite_Type.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolNToSite_Type, "gcolNToSite_Type")
        Me.gcolNToSite_Type.FieldName = "idfsSiteType"
        Me.gcolNToSite_Type.Name = "gcolNToSite_Type"
        Me.gcolNToSite_Type.OptionsColumn.AllowFocus = False
        '
        'gcolNToAbbr
        '
        Me.gcolNToAbbr.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolNToAbbr, "gcolNToAbbr")
        Me.gcolNToAbbr.FieldName = "OfficeAbbreviation"
        Me.gcolNToAbbr.Name = "gcolNToAbbr"
        Me.gcolNToAbbr.OptionsColumn.AllowFocus = False
        '
        'gcolNToName
        '
        Me.gcolNToName.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolNToName, "gcolNToName")
        Me.gcolNToName.FieldName = "OfficeName"
        Me.gcolNToName.Name = "gcolNToName"
        Me.gcolNToName.OptionsColumn.AllowFocus = False
        '
        'gcolNToRC
        '
        resources.ApplyResources(Me.gcolNToRC, "gcolNToRC")
        Me.gcolNToRC.FieldName = "idfsRC"
        Me.gcolNToRC.Name = "gcolNToRC"
        '
        'tpPermissions
        '
        Me.tpPermissions.Name = "tpPermissions"
        resources.ApplyResources(Me.tpPermissions, "tpPermissions")
        '
        'SiteActivationServerDetail
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.TabCtrl)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "A14"
        Me.HelpTopicID = "EIDSS_sites"
        Me.KeyFieldName = "idfsSite"
        Me.LeftIcon = Global.EIDSS.My.Resources.Resources.EIDSS_Site_135_
        Me.Name = "SiteActivationServerDetail"
        Me.ObjectName = "SiteActivationServer"
        Me.ShowDeleteButton = False
        Me.Sizable = True
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "SiteActivationServer"
        Me.Controls.SetChildIndex(Me.TabCtrl, 0)
        CType(Me.TabCtrl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabCtrl.ResumeLayout(False)
        Me.tpGeneral.ResumeLayout(False)
        CType(Me.txtSiteCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtServerName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSiteType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSiteName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbOrganization.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSiteID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCountry.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpReplication.ResumeLayout(False)
        CType(Me.gcChildSiteList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChildSiteListView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbChildSite, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbParentSite.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpNotification.ResumeLayout(False)
        CType(Me.gcNotificationFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NotificationFromView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbNotificationFromSite, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcNotificationTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NotificationToView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbNotificationToSite, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub


#End Region


    Public ReadOnly Property SiteID() As Long
        Get
            If baseDataSet.Tables("SiteActivationServer").Rows.Count = 0 OrElse baseDataSet.Tables("SiteActivationServer").Rows(0)("idfsSite") Is DBNull.Value Then
                Return 0
            End If
            Return CLng(baseDataSet.Tables(0).Rows(0)("idfsSite"))
        End Get
    End Property


    Protected Overrides Sub DefineBinding()
        txtSiteID.DataBindings.Add("EditValue", baseDataSet, "SiteActivationServer.idfsSite")
        Core.LookupBinder.BindTextEdit(txtSiteCode, baseDataSet, "SiteActivationServer.strSiteID")
        Core.LookupBinder.BindTextEdit(txtSiteName, baseDataSet, "SiteActivationServer.strSiteName")
        Core.LookupBinder.BindTextEdit(txtServerName, baseDataSet, "SiteActivationServer.strServerName")
        Core.LookupBinder.BindBaseLookup(cbSiteType, baseDataSet, "SiteActivationServer.idfsSiteType", db.BaseReferenceType.rftSiteType)
        Core.LookupBinder.BindCountryLookup(cbCountry, baseDataSet, "SiteActivationServer.idfsCountry")
        Core.LookupBinder.BindOrganizationLookup(cbOrganization, baseDataSet, "SiteActivationServer.idfOffice", HACode.None)
        'BindReplication()
        'BindNotification()

    End Sub

    'The code below belongs to parent/child relations processing doesn't work in the current version
    'All functionality related with parent/child is skipped in the DBService too

    Private Sub BindReplication()
        cbParentSite.Enabled = True
        btnAdd.Enabled = True
        btnRemove.Enabled = True
        If SiteID > 0 Then

            Core.LookupBinder.BindSiteLookup(cbParentSite, baseDataSet, "Parent_Site_Relation.idfsParentSite")

            If baseDataSet.Tables.Contains("Child_Site_Relation") Then
                If gcChildSiteList.DataSource Is Nothing Then
                    gcChildSiteList.DataSource = New DataView(baseDataSet.Tables("Child_Site_Relation"))
                End If

                CType(gcChildSiteList.DataSource, DataView).RowFilter = _
                    String.Format("idfsParentSite = {0} And idfsSiteRelationType = {1}", SiteID, CLng(SiteRelationType.Subordinated))

                Core.LookupBinder.BindSiteRepositoryLookup(cbChildSite)
            End If
        Else
            cbParentSite.Properties.DataSource = Nothing
            cbParentSite.Enabled = False
            gcChildSiteList.DataSource = Nothing
            btnAdd.Enabled = False
            btnRemove.Enabled = False
        End If
    End Sub

    Private Sub BindNotification()
        btnNToAdd.Enabled = True
        btnNToRemove.Enabled = True
        btnNFromAdd.Enabled = True
        btnNFromRemove.Enabled = True
        If SiteID > 0 Then
            If baseDataSet.Tables.Contains("NotificationTo") Then
                If gcNotificationTo.DataSource Is Nothing Then
                    gcNotificationTo.DataSource = New DataView(baseDataSet.Tables("NotificationTo"))
                End If
                CType(gcNotificationTo.DataSource, DataView).RowFilter = _
                    String.Format("idfsParentSite = {0} And idfsSiteRelationType = {1}", SiteID, CLng(SiteRelationType.NotificationTo))
                Core.LookupBinder.BindSiteRepositoryLookup(cbNotificationToSite)
            End If
            If baseDataSet.Tables.Contains("NotificationFrom") Then
                If gcNotificationFrom.DataSource Is Nothing Then
                    gcNotificationFrom.DataSource = New DataView(baseDataSet.Tables("NotificationFrom"))
                End If
                CType(gcNotificationFrom.DataSource, DataView).RowFilter = _
                    String.Format("idfsRelativeSite = {0} And idfsSiteRelationType = {1}", SiteID, CLng(SiteRelationType.NotificationTo))
                Core.LookupBinder.BindSiteRepositoryLookup(cbNotificationFromSite)
            End If
        Else
            gcNotificationTo.DataSource = Nothing
            btnNToAdd.Enabled = False
            btnNToRemove.Enabled = False
            gcNotificationFrom.DataSource = Nothing
            btnNFromAdd.Enabled = False
            btnNFromRemove.Enabled = False
        End If
    End Sub


    'Private Sub txtSiteID_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSiteID.EditValueChanged
    '    BindReplication()
    '    If Not CurParentRow Is Nothing Then
    '        CurParentRow("idfsRelativeSite") = txtSiteID.EditValue
    '    End If
    '    BindNotification()
    'End Sub

    Dim CurChildSiteID As Object = Nothing

    Private Sub ChildSiteListView_CellValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles ChildSiteListView.CellValueChanging
        If (Not gcChildSiteList.DataSource Is Nothing) Then
            If e.Column Is gcolSiteID Then
                CurChildSiteID = e.Value
                Dim SiteLookupRow As DataRow = Nothing
                If (Not ChildSiteListView.GetDataRow(e.RowHandle) Is Nothing) AndAlso _
                   (Not ChildSiteListView.IsNewItemRow(e.RowHandle)) Then
                    Dim ChildRow As DataRow = ChildSiteListView.GetDataRow(e.RowHandle)
                    If (Not e.Value Is Nothing) AndAlso (Not e.Value Is DBNull.Value) Then
                        SiteLookupRow = LookupCache.GetLookupRow(e.Value, LookupTables.Site.ToString)
                        If (ChildRow("idfSiteRelation") Is Nothing) OrElse _
                           (ChildRow("idfSiteRelation") Is DBNull.Value) Then
                            ChildRow("idfSiteRelation") = BaseDbService.NewIntID 'txtSiteID.Text + CType(e.Value, String)
                        End If
                        ChildRow("idfsSiteType") = SiteLookupRow("idfsSiteType")
                        ChildRow("OfficeAbbreviation") = SiteLookupRow("OfficeAbbreviation")
                        ChildRow("OfficeName") = SiteLookupRow("OfficeName")
                    Else
                        ChildRow("idfsSiteType") = DBNull.Value
                        ChildRow("OfficeAbbreviation") = DBNull.Value
                        ChildRow("OfficeName") = DBNull.Value
                    End If
                ElseIf ChildSiteListView.IsNewItemRow(e.RowHandle) AndAlso (Not NewChildRow Is Nothing) Then
                    If (Not e.Value Is Nothing) AndAlso (Not e.Value Is DBNull.Value) Then
                        SiteLookupRow = LookupCache.GetLookupRow(e.Value, LookupTables.Site.ToString)
                        'NewChildRow("idfSiteRelation") = BaseDbService.NewIntID 'txtSiteID.Text + CType(e.Value, String)
                        NewChildRow("idfsSiteType") = SiteLookupRow("idfsSiteType")
                        NewChildRow("OfficeAbbreviation") = SiteLookupRow("OfficeAbbreviation")
                        NewChildRow("OfficeName") = SiteLookupRow("OfficeName")
                    Else
                        NewChildRow("idfsSiteType") = DBNull.Value
                        NewChildRow("OfficeAbbreviation") = DBNull.Value
                        NewChildRow("OfficeName") = DBNull.Value
                    End If
                    ChildSiteListView.RefreshRow(e.RowHandle)
                End If
                ChildSiteListView.RefreshEditor(True)
                If Not SiteLookupRow Is Nothing AndAlso Not SiteLookupRow.Table Is Nothing Then
                    Dim dt As DataTable = SiteLookupRow.Table
                    DbDisposeHelper.DisposeTable(dt)
                End If
            End If
        End If
    End Sub

    Dim NewChildRow As DataRowView = Nothing

    Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If (Not gcChildSiteList.DataSource Is Nothing) AndAlso _
           ((Not ChildSiteListView.IsNewItemRow(ChildSiteListView.FocusedRowHandle)) OrElse _
            Not ((ChildSiteListView.GetDataRow(ChildSiteListView.FocusedRowHandle).Item("idfsRelativeSite") Is Nothing) OrElse _
                 (ChildSiteListView.GetDataRow(ChildSiteListView.FocusedRowHandle).Item("idfsRelativeSite") Is DBNull.Value))) Then
            NewChildRow = CType(gcChildSiteList.DataSource, DataView).AddNew()
            NewChildRow("idfSiteRelation") = BaseDbService.NewIntID()
            NewChildRow("idfsParentSite") = SiteID
            NewChildRow("idfsSiteRelationType") = CLng(SiteRelationType.Subordinated)
        End If
    End Sub

    Dim OkToRemove As Boolean = True

    Private Sub btnRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If OkToRemove Then
            If (Not gcChildSiteList.DataSource Is Nothing) AndAlso _
               ((Not ChildSiteListView.GetDataRow(ChildSiteListView.FocusedRowHandle) Is Nothing) OrElse _
                (ChildSiteListView.IsNewItemRow(ChildSiteListView.FocusedRowHandle))) Then
                ChildSiteListView.DeleteRow(ChildSiteListView.FocusedRowHandle)
            End If
        End If
        NewChildRow = Nothing
        OkToRemove = True
    End Sub

    Private Function CheckParentSite(ByVal ParentSiteID As Long, ByVal SiteID As Long, ByVal ChildSiteList As DataTable) As Boolean
        Dim res As Boolean = True
        If ParentSiteID > 0 AndAlso SiteID > 0 Then
            If ParentSiteID = SiteID Then
                res = False
            Else
                If (Not ChildSiteList Is Nothing) AndAlso (ChildSiteList.Rows.Count > 0) Then
                    Dim i As Integer = 0
                    While res AndAlso (i < ChildSiteList.Rows.Count)
                        If ChildSiteList.Rows(i).RowState <> DataRowState.Deleted Then
                            Dim CurSiteID As Long = _
                                CLng(ChildSiteList.Rows(i).Item("idfsRelativeSite"))
                            If CurSiteID <> ParentSiteID Then
                                res = CheckParentSite(ParentSiteID, SiteID, SiteActivationServerDbService.GetChildSiteList(CurSiteID))
                            End If
                        End If
                        i = i + 1
                    End While
                End If
                DbDisposeHelper.DisposeTable(ChildSiteList)
            End If
        End If
        Return res
    End Function

    Private Function CheckChildSite(ByVal ChildSiteID As Long, ByVal SiteID As Long, ByVal ParentSiteID As Long) As Boolean
        Dim res As Boolean = True
        If ChildSiteID > 0 AndAlso SiteID > 0 Then
            If (ChildSiteID = SiteID) OrElse _
               (SiteActivationServerDbService.GetParentSite(ChildSiteID) <> SiteID) Then
                res = False
            Else
                If ParentSiteID > 0 Then
                    If ParentSiteID = ChildSiteID Then
                        res = False
                    Else
                        res = CheckChildSite(ChildSiteID, SiteID, SiteActivationServerDbService.GetParentSite(ParentSiteID))
                    End If
                End If
            End If
        End If
        Return res
    End Function

    Private Sub ChildSiteListView_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles ChildSiteListView.ValidateRow
        e.Valid = True
        Dim curRow As DataRow = ChildSiteListView.GetDataRow(e.RowHandle)
        If (curRow("idfsRelativeSite") Is DBNull.Value) Then
            Dim NullMsg As New EIDSSErrorMessage("errEmptySiteID", "Column 'Site ID' is empty.")
            e.ErrorText = NullMsg.Text
            e.Valid = False
        End If
        If e.Valid Then
            Dim ChildSiteID As Long = 0
            If Not Utils.IsEmpty(CurChildSiteID) Then
                ChildSiteID = CType(CurChildSiteID, Long)
            End If
            Dim ParentSiteID As Long = 0
            If Not Utils.IsEmpty(cbParentSite.EditValue) Then
                ParentSiteID = CType(cbParentSite.EditValue, Long)
            End If
            Dim RelSiteList As DataTable = baseDataSet.Tables("Child_Site_Relation")
            Dim relationID As Long = -1
            If Not curRow("idfSiteRelation") Is DBNull.Value Then
                relationID = CLng(curRow("idfSiteRelation"))
            End If
            'Dim max As Integer = 2
            'If ChildSiteListView.IsNewItemRow(e.RowHandle) Then max = 1
            'Dim num As Integer = 0
            'Dim i As Integer = 0
            'While (i < RelSiteList.Rows.Count) AndAlso (num < max)
            '    If (RelSiteList.Rows(i).RowState <> DataRowState.Deleted) AndAlso _
            '       (ChildSiteID = CType(RelSiteList.Rows(i).Item("idfsRelativeSite"), Long)) Then num = num + 1
            '    i = i + 1
            'End While
            'If num = max Then
            If RelSiteList.Select(String.Format("idfsRelativeSite = {0} and idfSiteRelation <> {1}", ChildSiteID, relationID)).Length > 0 Then
                Dim DoubleMsg As New EIDSSErrorMessage("errDoubleRelativeSite", "This site is already relative for current site.")
                e.ErrorText = DoubleMsg.Text
                e.Valid = False
            ElseIf Not CheckChildSite(ChildSiteID, SiteID, ParentSiteID) Then
                Dim msg As New EIDSSErrorMessage("errWrongRelativeSite", "This site can't be relative for current site.")
                e.ErrorText = msg.Text
                e.Valid = False
            End If
        End If
    End Sub

    Private Sub ChildSiteListView_InvalidRowException(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles ChildSiteListView.InvalidRowException
        If (Me.ActiveControl Is Me.btnRemove) Then
            OkToRemove = False
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.Ignore
        Else
            If ChildSiteListView.IsNewItemRow(e.RowHandle) Then
                'Dim row As DataRow = ChildSiteListView.GetDataRow(e.RowHandle)
                If (ChildSiteListView.GetFocusedRowCellValue("idfsRelativeSite") Is Nothing) OrElse _
                   (ChildSiteListView.GetFocusedRowCellValue("idfsRelativeSite") Is DBNull.Value) Then
                    NewChildRow = Nothing
                    e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.Ignore
                End If
            End If
        End If
    End Sub

    Private Sub ChildSiteListView_RowUpdated(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles ChildSiteListView.RowUpdated
        NewChildRow = Nothing
    End Sub

    Dim CurParentRow As DataRow = Nothing

    Private Sub cbParentSite_EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cbParentSite.EditValueChanging
        Dim OkToCancel As Boolean = False
        If Not Utils.IsEmpty(e.NewValue) Then
            Dim ParentSiteID As Long = CLng(e.NewValue)
            Dim ChildSiteList As DataTable = baseDataSet.Tables("Child_Site_Relation")
            If Not CheckParentSite(ParentSiteID, SiteID, ChildSiteList) Then
                ErrorForm.ShowWarning("errWrongParentSite")
                OkToCancel = True
            Else
                Dim i As Integer = 0
                While (i < baseDataSet.Tables("Parent_Site_Relation").Rows.Count) AndAlso _
                      (baseDataSet.Tables("Parent_Site_Relation").Rows(i).RowState = DataRowState.Deleted)
                    i = i + 1
                End While
                If i = baseDataSet.Tables("Parent_Site_Relation").Rows.Count Then
                    Dim row As DataRow = baseDataSet.Tables("Parent_Site_Relation").NewRow
                    row("idfSiteRelation") = BaseDbService.NewIntID
                    row("idfsSiteRelationType") = CLng(SiteRelationType.Subordinated)
                    If Not Utils.IsEmpty(baseDataSet.Tables("SiteActivationServer").Rows(0)("idfsSite")) Then
                        row("idfsRelativeSite") = baseDataSet.Tables("SiteActivationServer").Rows(0)("idfsSite")
                    End If
                    baseDataSet.EnforceConstraints = False
                    baseDataSet.Tables("Parent_Site_Relation").Rows.Add(row)
                    CurParentRow = row
                Else
                    CurParentRow = baseDataSet.Tables("Parent_Site_Relation").Rows(i)
                End If
            End If
        ElseIf (Not e.OldValue Is Nothing) AndAlso (Not e.OldValue Is DBNull.Value) Then
            CurParentRow.Delete()
        End If
        e.Cancel = OkToCancel
    End Sub


    Dim CurNToSiteID As Object = Nothing

    Private Sub NotificationToView_CellValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles NotificationToView.CellValueChanging
        If (Not gcNotificationTo.DataSource Is Nothing) Then
            If e.Column Is gcolNToSiteID Then
                CurNToSiteID = e.Value
                Dim SiteLookupRow As DataRow = Nothing
                If (Not NotificationToView.GetDataRow(e.RowHandle) Is Nothing) AndAlso _
                   (Not NotificationToView.IsNewItemRow(e.RowHandle)) Then
                    Dim NToRow As DataRow = NotificationToView.GetDataRow(e.RowHandle)
                    If (Not e.Value Is Nothing) AndAlso (Not e.Value Is DBNull.Value) Then
                        SiteLookupRow = LookupCache.GetLookupRow(e.Value, LookupTables.Site.ToString)
                        If (NToRow("idfSiteRelation") Is Nothing) OrElse _
                           (NToRow("idfSiteRelation") Is DBNull.Value) Then
                            NToRow("idfSiteRelation") = BaseDbService.NewIntID
                        End If
                        NToRow("idfsSiteType") = SiteLookupRow("idfsSiteType")
                        NToRow("OfficeAbbreviation") = SiteLookupRow("OfficeAbbreviation")
                        NToRow("OfficeName") = SiteLookupRow("OfficeName")
                    Else
                        NToRow("idfsSiteType") = DBNull.Value
                        NToRow("OfficeAbbreviation") = DBNull.Value
                        NToRow("OfficeName") = DBNull.Value
                    End If
                ElseIf NotificationToView.IsNewItemRow(e.RowHandle) AndAlso (Not NewNToRow Is Nothing) Then
                    If (Not e.Value Is Nothing) AndAlso (Not e.Value Is DBNull.Value) Then
                        SiteLookupRow = LookupCache.GetLookupRow(e.Value, LookupTables.Site.ToString)
                        'NewNToRow("idfSiteRelation") = BaseDbService.NewIntID
                        NewNToRow("idfsSiteType") = SiteLookupRow("idfsSiteType")
                        NewNToRow("OfficeAbbreviation") = SiteLookupRow("OfficeAbbreviation")
                        NewNToRow("OfficeName") = SiteLookupRow("OfficeName")
                    Else
                        NewNToRow("idfsSiteType") = DBNull.Value
                        NewNToRow("OfficeAbbreviation") = DBNull.Value
                        NewNToRow("OfficeName") = DBNull.Value
                    End If
                    NotificationToView.RefreshRow(e.RowHandle)
                End If
                NotificationToView.RefreshEditor(True)
                If Not SiteLookupRow Is Nothing AndAlso Not SiteLookupRow.Table Is Nothing Then
                    Dim dt As DataTable = SiteLookupRow.Table
                    DbDisposeHelper.DisposeTable(dt)
                End If
            End If
        End If
    End Sub

    Dim NewNToRow As DataRowView = Nothing

    Private Sub btnNToAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNToAdd.Click
        If (Not gcNotificationTo.DataSource Is Nothing) AndAlso _
           ((Not NotificationToView.IsNewItemRow(NotificationToView.FocusedRowHandle)) OrElse _
            Not ((NotificationToView.GetDataRow(NotificationToView.FocusedRowHandle).Item("idfsRelativeSite") Is Nothing) OrElse _
                 (NotificationToView.GetDataRow(NotificationToView.FocusedRowHandle).Item("idfsRelativeSite") Is DBNull.Value))) Then
            NewNToRow = CType(gcNotificationTo.DataSource, DataView).AddNew()
            NewNToRow("idfSiteRelation") = BaseDbService.NewIntID
            NewNToRow("idfsParentSite") = SiteID
            NewNToRow("idfsSiteRelationType") = CLng(SiteRelationType.NotificationTo)
        End If
    End Sub

    Dim OkToNToRemove As Boolean = True

    Private Sub btnNToRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNToRemove.Click
        If OkToNToRemove Then
            If (Not gcNotificationTo.DataSource Is Nothing) AndAlso _
               ((Not NotificationToView.GetDataRow(NotificationToView.FocusedRowHandle) Is Nothing) OrElse _
                (NotificationToView.IsNewItemRow(NotificationToView.FocusedRowHandle))) Then
                NotificationToView.DeleteRow(NotificationToView.FocusedRowHandle)
            End If
        End If
        NewNToRow = Nothing
        OkToNToRemove = True
    End Sub

    Private Sub NotificationToView_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles NotificationToView.ValidateRow
        e.Valid = True
        Dim curRow As DataRow = NotificationToView.GetDataRow(e.RowHandle)
        If Utils.IsEmpty(curRow("idfsRelativeSite")) Then
            Dim NullMsg As New EIDSSErrorMessage("errEmptySiteID", "Column 'Site ID' is empty.")
            e.ErrorText = NullMsg.Text
            e.Valid = False
        End If
        If e.Valid Then
            Dim NToSiteID As Long = 0
            If Not Utils.IsEmpty(CurNToSiteID) Then
                NToSiteID = CLng(CurNToSiteID)
            End If
            Dim NToSiteList As DataTable = baseDataSet.Tables("NotificationTo")
            'Dim max As Integer = 2
            'If NotificationToView.IsNewItemRow(e.RowHandle) Then max = 1
            'Dim num As Integer = 0
            'Dim i As Integer = 0
            'While (i < NToSiteList.Rows.Count) AndAlso (num < max)
            '    If (NToSiteList.Rows(i).RowState <> DataRowState.Deleted) AndAlso _
            '       (NToSiteID = CType(NToSiteList.Rows(i).Item("idfsRelativeSite"), String)) Then num = num + 1
            '    i = i + 1
            'End While
            'If num = max Then
            Dim relationID As Long = -1
            If Not curRow("idfSiteRelation") Is DBNull.Value Then
                relationID = CLng(curRow("idfSiteRelation"))
            End If
            If NToSiteList.Select(String.Format("idfsRelativeSite = {0} and idfSiteRelation <> {1}", NToSiteID, relationID)).Length > 0 Then
                Dim DoubleMsg As New EIDSSErrorMessage("errDoubleRelativeSite", "This site is already relative for current site.")
                e.ErrorText = DoubleMsg.Text
                e.Valid = False
            ElseIf NToSiteID = SiteID Then
                Dim msg As New EIDSSErrorMessage("errWrongRelativeSite", "Site can't be relative for itself.")
                e.ErrorText = msg.Text
                e.Valid = False
            End If
        End If
    End Sub

    Private Sub NotificationToView_InvalidRowException(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles NotificationToView.InvalidRowException
        If (Me.ActiveControl Is Me.btnNToRemove) Then
            OkToNToRemove = False
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.Ignore
        Else
            If NotificationToView.IsNewItemRow(e.RowHandle) Then
                Dim row As DataRow = NotificationToView.GetDataRow(e.RowHandle)
                If (row("idfsRelativeSite") Is Nothing) OrElse _
                   (row("idfsRelativeSite") Is DBNull.Value) Then
                    NewNToRow = Nothing
                    e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.Ignore
                End If
            End If
        End If
    End Sub

    Private Sub NotificationToView_RowUpdated(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles NotificationToView.RowUpdated
        NewNToRow = Nothing
    End Sub


    Dim CurNFromSiteID As Object = Nothing

    Private Sub NotificationFromView_CellValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles NotificationFromView.CellValueChanging
        If (Not gcNotificationFrom.DataSource Is Nothing) Then
            If e.Column Is gcolNFromSiteID Then
                CurNFromSiteID = e.Value
                Dim SiteLookupRow As DataRow = Nothing
                If (Not NotificationFromView.GetDataRow(e.RowHandle) Is Nothing) AndAlso _
                   (Not NotificationFromView.IsNewItemRow(e.RowHandle)) Then
                    Dim NFromRow As DataRow = NotificationFromView.GetDataRow(e.RowHandle)
                    If (Not e.Value Is Nothing) AndAlso (Not e.Value Is DBNull.Value) Then
                        SiteLookupRow = LookupCache.GetLookupRow(e.Value, LookupTables.Site.ToString)
                        If (NFromRow("idfSiteRelation") Is Nothing) OrElse _
                           (NFromRow("idfSiteRelation") Is DBNull.Value) Then
                            NFromRow("idfSiteRelation") = BaseDbService.NewIntID
                        End If
                        NFromRow("idfsSiteType") = SiteLookupRow("idfsSiteType")
                        NFromRow("OfficeAbbreviation") = SiteLookupRow("OfficeAbbreviation")
                        NFromRow("OfficeName") = SiteLookupRow("OfficeName")
                    Else
                        NFromRow("idfsSiteType") = DBNull.Value
                        NFromRow("OfficeAbbreviation") = DBNull.Value
                        NFromRow("OfficeName") = DBNull.Value
                    End If
                ElseIf NotificationFromView.IsNewItemRow(e.RowHandle) AndAlso (Not NewNFromRow Is Nothing) Then
                    If (Not e.Value Is Nothing) AndAlso (Not e.Value Is DBNull.Value) Then
                        SiteLookupRow = LookupCache.GetLookupRow(e.Value, LookupTables.Site.ToString)
                        'NewNFromRow("idfSiteRelation") = BaseDbService.NewIntID
                        NewNFromRow("idfsSiteType") = SiteLookupRow("idfsSiteType")
                        NewNFromRow("OfficeAbbreviation") = SiteLookupRow("OfficeAbbreviation")
                        NewNFromRow("OfficeName") = SiteLookupRow("OfficeName")
                    Else
                        NewNFromRow("idfsSiteType") = DBNull.Value
                        NewNFromRow("OfficeAbbreviation") = DBNull.Value
                        NewNFromRow("OfficeName") = DBNull.Value
                    End If
                    NotificationFromView.RefreshRow(e.RowHandle)
                End If
                NotificationFromView.RefreshEditor(True)
                If Not SiteLookupRow Is Nothing AndAlso Not SiteLookupRow.Table Is Nothing Then
                    Dim dt As DataTable = SiteLookupRow.Table
                    DbDisposeHelper.DisposeTable(dt)
                End If
            End If
        End If
    End Sub

    Dim NewNFromRow As DataRowView = Nothing

    Private Sub btnNFromAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNFromAdd.Click
        If (Not gcNotificationFrom.DataSource Is Nothing) AndAlso _
           ((Not NotificationFromView.IsNewItemRow(NotificationFromView.FocusedRowHandle)) OrElse _
            Not ((NotificationFromView.GetDataRow(NotificationFromView.FocusedRowHandle).Item("idfsParentSite") Is Nothing) OrElse _
                 (NotificationFromView.GetDataRow(NotificationFromView.FocusedRowHandle).Item("idfsParentSite") Is DBNull.Value))) Then
            NewNFromRow = CType(gcNotificationFrom.DataSource, DataView).AddNew()
            NewNFromRow("idfSiteRelation") = BaseDbService.NewIntID
            NewNFromRow("idfsRelativeSite") = SiteID
            NewNFromRow("idfsSiteRelationType") = CLng(SiteRelationType.NotificationTo)
        End If
    End Sub

    Dim OkToNFromRemove As Boolean = True

    Private Sub btnNFromRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNFromRemove.Click
        If OkToNFromRemove Then
            If (Not gcNotificationFrom.DataSource Is Nothing) AndAlso _
               ((Not NotificationFromView.GetDataRow(NotificationFromView.FocusedRowHandle) Is Nothing) OrElse _
                (NotificationFromView.IsNewItemRow(NotificationFromView.FocusedRowHandle))) Then
                NotificationFromView.DeleteRow(NotificationFromView.FocusedRowHandle)
            End If
        End If
        NewNFromRow = Nothing
        OkToNFromRemove = True
    End Sub

    Private Sub NotificationFromView_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles NotificationFromView.ValidateRow
        e.Valid = True
        Dim curRow As DataRow = NotificationFromView.GetDataRow(e.RowHandle)
        If Utils.IsEmpty(curRow("idfsParentSite")) Then
            Dim NullMsg As New EIDSSErrorMessage("errEmptySiteID", "Column 'Site ID' is empty.")
            e.ErrorText = NullMsg.Text
            e.Valid = False
        End If
        If e.Valid Then
            Dim NFromSiteID As Long = 0
            If Not Utils.IsEmpty(CurNFromSiteID) Then
                NFromSiteID = CLng(CurNFromSiteID)
            End If
            Dim NFromSiteList As DataTable = baseDataSet.Tables("NotificationFrom")
            'Dim max As Integer = 2
            'If NotificationFromView.IsNewItemRow(e.RowHandle) Then max = 1
            'Dim num As Integer = 0
            'Dim i As Integer = 0
            'While (i < NFromSiteList.Rows.Count) AndAlso (num < max)
            '    If (NFromSiteList.Rows(i).RowState <> DataRowState.Deleted) AndAlso _
            '       (NFromSiteID = CType(NFromSiteList.Rows(i).Item("idfsParentSite"), String)) Then num = num + 1
            '    i = i + 1
            'End While
            'If num = max Then
            Dim relationID As Long = -1
            If Not curRow("idfSiteRelation") Is DBNull.Value Then
                relationID = CLng(curRow("idfSiteRelation"))
            End If
            If NFromSiteList.Select(String.Format("idfsParentSite = {0} and idfSiteRelation <> {1}", NFromSiteID, relationID)).Length > 0 Then
                Dim DoubleMsg As New EIDSSErrorMessage("errDoubleParentSite", "This site is already parent for current site.")
                e.ErrorText = DoubleMsg.Text
                e.Valid = False
            ElseIf NFromSiteID = SiteID Then
                Dim msg As New EIDSSErrorMessage("errWrongRelativeSite", "Site can't be relative for itself.")
                e.ErrorText = msg.Text
                e.Valid = False
            End If
        End If
    End Sub

    Private Sub NotificationFromView_InvalidRowException(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) Handles NotificationFromView.InvalidRowException
        If (Me.ActiveControl Is Me.btnNFromRemove) Then
            OkToNFromRemove = False
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.Ignore
        Else
            If NotificationFromView.IsNewItemRow(e.RowHandle) Then
                Dim row As DataRow = NotificationFromView.GetDataRow(e.RowHandle)
                If Utils.IsEmpty(row("idfsParentSite")) Then
                    NewNFromRow = Nothing
                    e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.Ignore
                End If
            End If
        End If
    End Sub

    Private Sub NotificationFromView_RowUpdated(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles NotificationFromView.RowUpdated
        NewNFromRow = Nothing
    End Sub

    Public Overrides Function GetChildKey(ByVal child As IRelatedObject) As Object
        'Return Me.GetCurrentRow().Item("idfsSite")
        Return Me.DbService.ID
    End Function

End Class
