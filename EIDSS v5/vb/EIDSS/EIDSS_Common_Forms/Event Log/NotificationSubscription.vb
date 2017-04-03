Imports bv.winclient.BasePanel
Imports bv.winclient.Core

Public Class NotificationSubscriptionDetail
    Inherits bv.common.win.BaseDetailForm
    Dim NotificationSubscriptionDbService As NotificationSubscription_DB

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        NotificationSubscriptionDbService = New NotificationSubscription_DB

        DbService = NotificationSubscriptionDbService
        AuditObject = New Core.EIDSSAuditObject(EIDSSAuditObject.daoNotificationSubscription, AuditTable.tstEventSubscription)
        Me.PermissionObject = eidss.model.Enums.EIDSSPermissionObject.NotificationSubscription

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colEventName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSubscription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SubscriptionGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents btnDSelectAll As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnUnSelectAll As DevExpress.XtraEditors.SimpleButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NotificationSubscriptionDetail))
        Me.SubscriptionGrid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colEventName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSubscription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnDSelectAll = New DevExpress.XtraEditors.SimpleButton()
        Me.btnUnSelectAll = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.SubscriptionGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        '
        'SubscriptionGrid
        '
        resources.ApplyResources(Me.SubscriptionGrid, "SubscriptionGrid")
        Me.SubscriptionGrid.MainView = Me.GridView1
        Me.SubscriptionGrid.Name = "SubscriptionGrid"
        Me.SubscriptionGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.SubscriptionGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colEventName, Me.colSubscription})
        Me.GridView1.GridControl = Me.SubscriptionGrid
        resources.ApplyResources(Me.GridView1, "GridView1")
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'colEventName
        '
        Me.colEventName.AppearanceHeader.Font = CType(resources.GetObject("colEventName.AppearanceHeader.Font"), System.Drawing.Font)
        Me.colEventName.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colEventName, "colEventName")
        Me.colEventName.FieldName = "EventName"
        Me.colEventName.Name = "colEventName"
        Me.colEventName.OptionsColumn.AllowEdit = False
        Me.colEventName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.colEventName.OptionsColumn.ShowInCustomizationForm = False
        Me.colEventName.OptionsFilter.AllowFilter = False
        '
        'colSubscription
        '
        Me.colSubscription.AppearanceHeader.Font = CType(resources.GetObject("colSubscription.AppearanceHeader.Font"), System.Drawing.Font)
        Me.colSubscription.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colSubscription, "colSubscription")
        Me.colSubscription.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.colSubscription.FieldName = "Subscription"
        Me.colSubscription.Name = "colSubscription"
        Me.colSubscription.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.colSubscription.OptionsColumn.ShowInCustomizationForm = False
        Me.colSubscription.OptionsFilter.AllowFilter = False
        '
        'RepositoryItemCheckEdit1
        '
        resources.ApplyResources(Me.RepositoryItemCheckEdit1, "RepositoryItemCheckEdit1")
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        Me.RepositoryItemCheckEdit1.ValueChecked = 1
        Me.RepositoryItemCheckEdit1.ValueUnchecked = 0
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'btnDSelectAll
        '
        resources.ApplyResources(Me.btnDSelectAll, "btnDSelectAll")
        Me.btnDSelectAll.Image = Global.eidss.My.Resources.Resources.Select_All_65_1_
        Me.btnDSelectAll.Name = "btnDSelectAll"
        '
        'btnUnSelectAll
        '
        resources.ApplyResources(Me.btnUnSelectAll, "btnUnSelectAll")
        Me.btnUnSelectAll.Image = Global.eidss.My.Resources.Resources.Unselect_All_65_
        Me.btnUnSelectAll.Name = "btnUnSelectAll"
        '
        'NotificationSubscriptionDetail
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.btnUnSelectAll)
        Me.Controls.Add(Me.btnDSelectAll)
        Me.Controls.Add(Me.SubscriptionGrid)
        Me.Controls.Add(Me.Label1)
        Me.FormID = "S03"
        Me.HelpTopicID = "AlertSubscriptionForm"
        Me.KeyFieldName = "strClient"
        Me.LeftIcon = Global.eidss.My.Resources.Resources.Site_Alerts_Subscriptions__large__20_1_
        Me.Name = "NotificationSubscriptionDetail"
        Me.ObjectName = "Event_Subscription"
        Me.ShowDeleteButton = False
        Me.Sizable = True
        Me.TableName = "Event_Subscription"
        Me.Controls.SetChildIndex(Me.cmdOk, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.SubscriptionGrid, 0)
        Me.Controls.SetChildIndex(Me.btnDSelectAll, 0)
        Me.Controls.SetChildIndex(Me.btnUnSelectAll, 0)
        CType(Me.SubscriptionGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Main form interface"
    Private Shared m_Parent As Control
    Public Shared Sub Register(ByVal ParentControl As System.Windows.Forms.Control)
        m_Parent = ParentControl
        Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.System, "MenuNotificationSubscription", 907, False, model.Enums.MenuIconsSmall.SiteAlertSubscriptions, -1)
        ma.Order = 906
        ma.Name = "btnNotificationSubscription"
        ma.SelectPermission = PermissionHelper.SelectPermission(eidss.model.Enums.EIDSSPermissionObject.NotificationSubscription)
    End Sub

    Public Shared Sub ShowMe()
        BaseFormManager.ShowNormal(New NotificationSubscriptionDetail, 1)
        'BaseForm.ShowModal(New NotificationSubscriptionDetail)
    End Sub
#End Region

    Protected Overrides Sub DefineBinding()
        SubscriptionGrid.DataSource = baseDataSet.Tables(NotificationSubscription_DB.TableEventSubscription)
    End Sub

    Sub SubscribeToAll(ByVal val As Boolean)
        For Each row As DataRow In baseDataSet.Tables(NotificationSubscription_DB.TableEventSubscription).Rows
            If (CType(row("Subscription"), Boolean) <> val) Then
                row("Subscription") = val
            End If
        Next
    End Sub

    Private Sub btnDSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDSelectAll.Click
        SubscribeToAll(True)
    End Sub

    Private Sub btnUnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnSelectAll.Click
        SubscribeToAll(False)
    End Sub
End Class
