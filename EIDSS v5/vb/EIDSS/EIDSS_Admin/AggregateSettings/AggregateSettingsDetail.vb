Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports EIDSS.model.Enums

Public Class AggregateSettingsDetail

    Inherits BaseDetailList
    Dim AggregateSettingsDbService As AggregateSettings_DB

#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()


        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        AggregateSettingsDbService = New AggregateSettings_DB

        DbService = AggregateSettingsDbService
        AuditObject = New Core.EIDSSAuditObject(EIDSSAuditObject.daoAgregateHumanSettings, AuditTable.tstAggrSetting)
        Me.PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.AggregateSettings
        If Not Permissions.CanUpdate Then
            Me.ReadOnly = True
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
    Friend WithEvents SettingsGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents SettingsView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colCaseType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbCaseType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colAdminUnit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbAdminUnit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colTimeUnit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbTimeUnit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit


    'Required by the Windows Form Designer

    Private components As System.ComponentModel.IContainer


    'NOTE: The following procedure is required by the Windows Form Designer

    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AggregateSettingsDetail))
        Me.SettingsGrid = New DevExpress.XtraGrid.GridControl()
        Me.SettingsView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCaseType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbCaseType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colAdminUnit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbAdminUnit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colTimeUnit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbTimeUnit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        CType(Me.SettingsGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SettingsView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCaseType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbAdminUnit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTimeUnit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SettingsGrid
        '
        resources.ApplyResources(Me.SettingsGrid, "SettingsGrid")
        Me.SettingsGrid.MainView = Me.SettingsView
        Me.SettingsGrid.Name = "SettingsGrid"
        Me.SettingsGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbCaseType, Me.cbAdminUnit, Me.cbTimeUnit})
        Me.SettingsGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.SettingsView})
        '
        'SettingsView
        '
        Me.SettingsView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCaseType, Me.colAdminUnit, Me.colTimeUnit})
        Me.SettingsView.GridControl = Me.SettingsGrid
        Me.SettingsView.Name = "SettingsView"
        Me.SettingsView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.SettingsView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.SettingsView.OptionsCustomization.AllowFilter = False
        Me.SettingsView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.SettingsView.OptionsView.ShowGroupPanel = False
        '
        'colCaseType
        '
        resources.ApplyResources(Me.colCaseType, "colCaseType")
        Me.colCaseType.ColumnEdit = Me.cbCaseType
        Me.colCaseType.FieldName = "idfsAggrCaseType"
        Me.colCaseType.Name = "colCaseType"
        Me.colCaseType.OptionsColumn.AllowEdit = False
        Me.colCaseType.OptionsColumn.AllowFocus = False
        Me.colCaseType.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.colCaseType.OptionsColumn.ReadOnly = True
        Me.colCaseType.OptionsColumn.ShowInCustomizationForm = False
        '
        'cbCaseType
        '
        Me.cbCaseType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbCaseType.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbCaseType.DropDownRows = 4
        Me.cbCaseType.Name = "cbCaseType"
        Me.cbCaseType.ReadOnly = True
        '
        'colAdminUnit
        '
        resources.ApplyResources(Me.colAdminUnit, "colAdminUnit")
        Me.colAdminUnit.ColumnEdit = Me.cbAdminUnit
        Me.colAdminUnit.FieldName = "idfsStatisticAreaType"
        Me.colAdminUnit.Name = "colAdminUnit"
        '
        'cbAdminUnit
        '
        resources.ApplyResources(Me.cbAdminUnit, "cbAdminUnit")
        Me.cbAdminUnit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbAdminUnit.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbAdminUnit.Name = "cbAdminUnit"
        '
        'colTimeUnit
        '
        resources.ApplyResources(Me.colTimeUnit, "colTimeUnit")
        Me.colTimeUnit.ColumnEdit = Me.cbTimeUnit
        Me.colTimeUnit.FieldName = "idfsStatisticPeriodType"
        Me.colTimeUnit.Name = "colTimeUnit"
        '
        'cbTimeUnit
        '
        resources.ApplyResources(Me.cbTimeUnit, "cbTimeUnit")
        Me.cbTimeUnit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTimeUnit.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbTimeUnit.Name = "cbTimeUnit"
        '
        'AggregateSettingsDetail
        '
        Me.Appearance.BackColor = CType(resources.GetObject("AggregateSettingsDetail.Appearance.BackColor"), System.Drawing.Color)
        Me.Appearance.Options.UseBackColor = True
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.SettingsGrid)
        Me.FormID = "H07"
        Me.HelpTopicID = "AggregateSettingsForm"
        Me.LeftIcon = Global.EIDSS.My.Resources.Resources.Aggregate_Settings__large__54_
        Me.Name = "AggregateSettingsDetail"
        Me.ObjectName = "AggregateSettings"
        Me.ShowDeleteButton = False
        Me.SingleInstance = True
        Me.Sizable = True
        Me.TableName = "AggregateSettings"
        Me.Controls.SetChildIndex(Me.cmdOk, 0)
        Me.Controls.SetChildIndex(Me.SettingsGrid, 0)
        CType(Me.SettingsGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SettingsView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCaseType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbAdminUnit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTimeUnit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region

#Region "Main form interface"
    Private Shared m_Parent As Control
    Public Shared Sub Register(ByVal ParentControl As System.Windows.Forms.Control)
        m_Parent = ParentControl
        Dim category As MenuAction = MenuActionManager.Instance.FindAction("MenuConfiguration", MenuActionManager.Instance.System, 960)
        Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, category, "MenuAggregateSettings", 1015, False, MenuIconsSmall.AggregateSettings, -1)
        ma.Name = "btnAggregateSettings"
        ma.SelectPermission = PermissionHelper.SelectPermission(EIDSS.model.Enums.EIDSSPermissionObject.AggregateSettings)
    End Sub

    Public Shared Sub ShowMe()
        BaseFormManager.ShowNormal(New AggregateSettingsDetail, Nothing)
        'BaseForm.ShowModal(New AggregateSettingsDetail)
    End Sub
#End Region

    Protected Overrides Sub DefineBinding()
        SettingsGrid.DataSource = baseDataSet.Tables("AggregateSettings")
        Core.LookupBinder.BindBaseRepositoryLookup(cbCaseType, bv.common.db.BaseReferenceType.rftAggregateCaseType, False)
        Core.LookupBinder.BindBaseRepositoryLookup(cbAdminUnit, bv.common.db.BaseReferenceType.rftStatisticAreaType, False)
        Core.LookupBinder.BindBaseRepositoryLookup(cbTimeUnit, bv.common.db.BaseReferenceType.rftStatisticPeriodType, False)
    End Sub

End Class
