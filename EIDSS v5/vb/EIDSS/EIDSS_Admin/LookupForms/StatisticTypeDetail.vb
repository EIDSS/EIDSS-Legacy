Imports bv.winclient.BasePanel
Imports bv.winclient.Core

Public Class StatisticTypeDetail
    Inherits BaseDetailList

    Dim StatisticTypeDbService As StatisticType_DB
    Friend WithEvents RefView As DataView
    Friend WithEvents gcolRelatedWithAgeGroup As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents chkRelatedWithAgeGroup As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Private m_Helper As ReferenceEditorHelper
#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()


        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        StatisticTypeDbService = New StatisticType_DB

        DbService = StatisticTypeDbService
        AuditObject = New Core.EIDSSAuditObject(EIDSSAuditObject.daoStatisticType, AuditTable.trtBaseReference)
        Me.PermissionObject = eidss.model.Enums.EIDSSPermissionObject.Reference
        m_Helper = New ReferenceEditorHelper(gcStatisticType, gcolSetnName, "strDefault,name,idfsStatisticPeriodType,idfsStatisticAreaType", "strDefault,name")
        If Permissions.CanInsert Then
            StatisticTypeView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Else
            StatisticTypeView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        End If
        StatisticTypeView.OptionsBehavior.Editable = Permissions.CanUpdate()

        If Not EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.DeletePermission( _
                                        EIDSS.model.Enums.EIDSSPermissionObject.Reference)) Then
            btnDelete.Enabled = False
        End If
        gcolDefName.ColumnEdit = ReferenceEditorHelper.EnglishValueEditor
        AddHandler OnBeforePost, AddressOf ReferenceEditorHelper.BeforePost

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
    Friend WithEvents gcStatisticType As DevExpress.XtraGrid.GridControl
    Friend WithEvents StatisticTypeView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblStatisticType As System.Windows.Forms.Label
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gcolDefName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolSetnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolReference_Type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbReference_Type As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents gcolPeriodType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbStatistic_Period_Type As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents gcolAreaType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbStatistic_Area_Type As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StatisticTypeDetail))
        Me.gcStatisticType = New DevExpress.XtraGrid.GridControl()
        Me.StatisticTypeView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gcolDefName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolSetnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolReference_Type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbReference_Type = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.gcolRelatedWithAgeGroup = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.chkRelatedWithAgeGroup = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.gcolPeriodType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbStatistic_Period_Type = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.gcolAreaType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbStatistic_Area_Type = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.lblStatisticType = New System.Windows.Forms.Label()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.gcStatisticType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatisticTypeView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbReference_Type, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkRelatedWithAgeGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbStatistic_Period_Type, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbStatistic_Area_Type, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gcStatisticType
        '
        resources.ApplyResources(Me.gcStatisticType, "gcStatisticType")
        Me.gcStatisticType.MainView = Me.StatisticTypeView
        Me.gcStatisticType.Name = "gcStatisticType"
        Me.gcStatisticType.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbReference_Type, Me.cbStatistic_Period_Type, Me.cbStatistic_Area_Type, Me.chkRelatedWithAgeGroup})
        Me.gcStatisticType.TabStop = False
        Me.gcStatisticType.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.StatisticTypeView})
        '
        'StatisticTypeView
        '
        Me.StatisticTypeView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gcolDefName, Me.gcolSetnName, Me.gcolReference_Type, Me.gcolRelatedWithAgeGroup, Me.gcolPeriodType, Me.gcolAreaType})
        Me.StatisticTypeView.GridControl = Me.gcStatisticType
        resources.ApplyResources(Me.StatisticTypeView, "StatisticTypeView")
        Me.StatisticTypeView.Name = "StatisticTypeView"
        Me.StatisticTypeView.OptionsCustomization.AllowFilter = False
        Me.StatisticTypeView.OptionsNavigation.AutoFocusNewRow = True
        Me.StatisticTypeView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.StatisticTypeView.OptionsView.ShowGroupPanel = False
        '
        'gcolDefName
        '
        Me.gcolDefName.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolDefName, "gcolDefName")
        Me.gcolDefName.FieldName = "strDefault"
        Me.gcolDefName.Name = "gcolDefName"
        '
        'gcolSetnName
        '
        Me.gcolSetnName.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolSetnName, "gcolSetnName")
        Me.gcolSetnName.FieldName = "name"
        Me.gcolSetnName.Name = "gcolSetnName"
        '
        'gcolReference_Type
        '
        Me.gcolReference_Type.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolReference_Type, "gcolReference_Type")
        Me.gcolReference_Type.ColumnEdit = Me.cbReference_Type
        Me.gcolReference_Type.FieldName = "idfsReferenceType"
        Me.gcolReference_Type.Name = "gcolReference_Type"
        '
        'cbReference_Type
        '
        resources.ApplyResources(Me.cbReference_Type, "cbReference_Type")
        Me.cbReference_Type.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbReference_Type.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbReference_Type.Name = "cbReference_Type"
        '
        'gcolRelatedWithAgeGroup
        '
        resources.ApplyResources(Me.gcolRelatedWithAgeGroup, "gcolRelatedWithAgeGroup")
        Me.gcolRelatedWithAgeGroup.ColumnEdit = Me.chkRelatedWithAgeGroup
        Me.gcolRelatedWithAgeGroup.FieldName = "blnRelatedWithAgeGroup"
        Me.gcolRelatedWithAgeGroup.Name = "gcolRelatedWithAgeGroup"
        '
        'chkRelatedWithAgeGroup
        '
        resources.ApplyResources(Me.chkRelatedWithAgeGroup, "chkRelatedWithAgeGroup")
        Me.chkRelatedWithAgeGroup.Name = "chkRelatedWithAgeGroup"
        Me.chkRelatedWithAgeGroup.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'gcolPeriodType
        '
        Me.gcolPeriodType.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolPeriodType, "gcolPeriodType")
        Me.gcolPeriodType.ColumnEdit = Me.cbStatistic_Period_Type
        Me.gcolPeriodType.FieldName = "idfsStatisticPeriodType"
        Me.gcolPeriodType.Name = "gcolPeriodType"
        '
        'cbStatistic_Period_Type
        '
        resources.ApplyResources(Me.cbStatistic_Period_Type, "cbStatistic_Period_Type")
        Me.cbStatistic_Period_Type.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbStatistic_Period_Type.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbStatistic_Period_Type.Name = "cbStatistic_Period_Type"
        '
        'gcolAreaType
        '
        Me.gcolAreaType.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.gcolAreaType, "gcolAreaType")
        Me.gcolAreaType.ColumnEdit = Me.cbStatistic_Area_Type
        Me.gcolAreaType.FieldName = "idfsStatisticAreaType"
        Me.gcolAreaType.Name = "gcolAreaType"
        '
        'cbStatistic_Area_Type
        '
        resources.ApplyResources(Me.cbStatistic_Area_Type, "cbStatistic_Area_Type")
        Me.cbStatistic_Area_Type.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbStatistic_Area_Type.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbStatistic_Area_Type.Name = "cbStatistic_Area_Type"
        '
        'lblStatisticType
        '
        resources.ApplyResources(Me.lblStatisticType, "lblStatisticType")
        Me.lblStatisticType.Name = "lblStatisticType"
        '
        'btnDelete
        '
        resources.ApplyResources(Me.btnDelete, "btnDelete")
        Me.btnDelete.Image = Global.eidss.My.Resources.Resources.Delete_Remove
        Me.btnDelete.Name = "btnDelete"
        '
        'StatisticTypeDetail
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.lblStatisticType)
        Me.Controls.Add(Me.gcStatisticType)
        Me.FormID = "A05"
        Me.HelpTopicID = "AggregateStatisticTypesForm"
        Me.KeyFieldName = "idfsBaseReference"
        Me.LeftIcon = Global.eidss.My.Resources.Resources.Reference_Book__large__41_
        Me.Name = "StatisticTypeDetail"
        Me.ObjectName = "BaseReference"
        Me.ShowDeleteButton = False
        Me.SingleInstance = True
        Me.Sizable = True
        Me.TableName = "BaseReference"
        Me.Controls.SetChildIndex(Me.cmdOk, 0)
        Me.Controls.SetChildIndex(Me.gcStatisticType, 0)
        Me.Controls.SetChildIndex(Me.lblStatisticType, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        CType(Me.gcStatisticType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatisticTypeView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbReference_Type, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkRelatedWithAgeGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbStatistic_Period_Type, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbStatistic_Area_Type, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

#Region "Main form interface"
    Private Shared m_Parent As Control
    Public Shared Sub Register(ByVal ParentControl As System.Windows.Forms.Control)
        m_Parent = ParentControl
        Dim category As MenuAction = MenuActionManager.Instance.FindAction("MenuReferencies", MenuActionManager.Instance.System, 950)
        Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, category, "MenuStatisticTypeEditor", 950, False, model.Enums.MenuIconsSmall.References, -1)
        ma.SelectPermission = PermissionHelper.SelectPermission(eidss.model.Enums.EIDSSPermissionObject.Reference)
        ma.Name = "btnStatisticTypeEditor"
    End Sub

    Public Shared Sub ShowMe()
        BaseFormManager.ShowNormal(New StatisticTypeDetail, Nothing)
        'BaseForm.ShowModal(New StatisticTypeDetail)
    End Sub
#End Region


    Protected Overrides Sub DefineBinding()
        m_DoDeleteAfterNo = False
        Core.LookupBinder.BindBaseRepositoryLookup(cbReference_Type, BaseReferenceType.rftReferenceTypeName, HACode.All, False, True)
        Core.LookupBinder.BindBaseRepositoryLookup(cbStatistic_Period_Type, BaseReferenceType.rftStatisticPeriodType, HACode.All, False)
        Core.LookupBinder.BindBaseRepositoryLookup(cbStatistic_Area_Type, BaseReferenceType.rftStatisticAreaType, HACode.All, False)
        CType(cbReference_Type.DataSource, DataView).RowFilter = "idfsReference=19000043 or idfsReference=19000086 " 'human Sex, Species
        RefView = m_Helper.BindView(baseDataSet, False)
    End Sub
    Private Sub cmdDeleteRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        m_Helper.DeleteRow()
    End Sub

    Private Sub StatisticTypeView_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles StatisticTypeView.ValidateRow
        m_Helper.ValidateRow(e)
    End Sub

End Class
