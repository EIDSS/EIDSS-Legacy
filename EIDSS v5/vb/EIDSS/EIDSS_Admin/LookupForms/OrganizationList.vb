Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports EIDSS.model.Enums

Public Class OrganizationList
    Inherits BasePagedXtraListForm
    Dim OrganizationDbService As Organization_DB

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        OrganizationDbService = New Organization_DB
        DbService = OrganizationDbService
        AuditObject = New Core.EIDSSAuditObject(EIDSSAuditObject.daoOrganization, AuditTable.tlbOffice)
        Me.PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.Organization
        LookupTableNames = New String() {"Organization", "Person"}

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
    Friend WithEvents colAbbriviation As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAddress As DevExpress.XtraGrid.Columns.GridColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OrganizationList))
        Me.colAbbriviation = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAddress = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SuspendLayout()
        '
        'colAbbriviation
        '
        resources.ApplyResources(Me.colAbbriviation, "colAbbriviation")
        Me.colAbbriviation.FieldName = "name"
        Me.colAbbriviation.Name = "colAbbriviation"
        '
        'colName
        '
        resources.ApplyResources(Me.colName, "colName")
        Me.colName.FieldName = "FullName"
        Me.colName.Name = "colName"
        '
        'colAddress
        '
        resources.ApplyResources(Me.colAddress, "colAddress")
        Me.colAddress.FieldName = "Address"
        Me.colAddress.Name = "colAddress"
        '
        'OrganizationList
        '
        resources.ApplyResources(Me, "$this")
        Me.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colAbbriviation, Me.colName, Me.colAddress})
        Me.FormID = "A06"
        Me.HelpTopicID = "OrganizationDetailForm"
        Me.KeyFieldName = "idfInstitution"
        Me.LeftIcon = Global.EIDSS.My.Resources.Resources.Organizations_List__large__60_
        Me.Name = "OrganizationList"
        Me.ObjectName = "Organization"
        Me.TableName = "Organization"
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Main form interface"
    Private Shared m_Parent As Control
    Public Shared Sub OldRegister(ByVal ParentControl As System.Windows.Forms.Control)
        m_Parent = ParentControl
        Dim category As MenuAction = MenuActionManager.Instance.FindAction("MenuAdministration", MenuActionManager.Instance.System, 970, MenuIconsSmall.Administration, -1)
        Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, category, "MenuOrganizations", 478, False, MenuIconsSmall.OrganizationsList, MenuIcons.OrganizationsList)
        ma.SelectPermission = PermissionHelper.SelectPermission(EIDSS.model.Enums.EIDSSPermissionObject.Organization)
        ma.Name = "btnOrganization"
    End Sub

    Public Shared Sub ShowMe()
        BaseFormManager.ShowClient(New OrganizationList, m_Parent, Nothing)
    End Sub
#End Region

#Region "BaseListForm Overridable metods"
    Public Overrides Function CreateDetailForm() As BaseForm
        Return New OrganizationDetail
    End Function

    Protected Overrides Sub DefineBinding()
        MyBase.DefineBinding()
        Me.colAbbriviation.VisibleIndex = 1
        'Me.colAbbriviation.SortIndex = 1
        'Me.colAbbriviation.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
        Me.colName.VisibleIndex = 2
        Me.colAddress.VisibleIndex = 3
    End Sub

#End Region

End Class
