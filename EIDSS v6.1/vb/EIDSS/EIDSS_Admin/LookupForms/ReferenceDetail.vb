Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports System.ComponentModel
Imports eidss.model.Resources
Imports EIDSS.model.Enums
Imports DevExpress.XtraGrid

Public Class ReferenceDetail

    Inherits BaseDetailList

    Dim ReferenceDbService As Reference_DB
    Friend WithEvents RefView As DataView
    Friend WithEvents txtEnglishMask As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Private m_Helper As ReferenceEditorHelper


#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()


        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        ReferenceDbService = New Reference_DB

        DbService = ReferenceDbService
        AuditObject = New AuditObject(EIDSSAuditObject.daoReference, AuditTable.trtBaseReference)
        Me.PermissionObject = eidss.model.Enums.EIDSSPermissionObject.Reference
        m_Helper = New ReferenceEditorHelper(gcReference, colTranslatedValue, "strDefault,name", "strDefault,name")
        m_Helper.CanDeleteProc = "spBaseReference_CanDelete"

        If Not eidss.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.DeletePermission( _
                                        eidss.model.Enums.EIDSSPermissionObject.Reference)) Then
            cmdDeleteRow.Enabled = False
        End If
        GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        colEnglishName.ColumnEdit = ReferenceEditorHelper.EnglishValueEditor
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
    Friend WithEvents lbReferenceType As System.Windows.Forms.Label
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colEnglishName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTranslatedValue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbRefType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents gcReference As DevExpress.XtraGrid.GridControl
    Friend WithEvents cmdDeleteRow As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents colHACode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemPopupContainerEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit
    Friend WithEvents gcolOrder As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents spinOrder As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReferenceDetail))
        Me.cbRefType = New DevExpress.XtraEditors.LookUpEdit()
        Me.lbReferenceType = New System.Windows.Forms.Label()
        Me.gcReference = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colEnglishName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTranslatedValue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colHACode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemPopupContainerEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit()
        Me.gcolOrder = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.spinOrder = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.txtEnglishMask = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.cmdDeleteRow = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.cbRefType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcReference, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemPopupContainerEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spinOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEnglishMask, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(ReferenceDetail), resources)
        'Form Is Localizable: True
        '
        'cbRefType
        '
        resources.ApplyResources(Me.cbRefType, "cbRefType")
        Me.cbRefType.Name = "cbRefType"
        Me.cbRefType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbRefType.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbRefType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbRefType.Properties.Columns"), resources.GetString("cbRefType.Properties.Columns1"))})
        Me.cbRefType.Properties.NullText = resources.GetString("cbRefType.Properties.NullText")
        Me.cbRefType.Tag = "{AlwaysEditable}"
        '
        'lbReferenceType
        '
        resources.ApplyResources(Me.lbReferenceType, "lbReferenceType")
        Me.lbReferenceType.Name = "lbReferenceType"
        '
        'gcReference
        '
        resources.ApplyResources(Me.gcReference, "gcReference")
        Me.gcReference.MainView = Me.GridView1
        Me.gcReference.Name = "gcReference"
        Me.gcReference.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemPopupContainerEdit1, Me.spinOrder, Me.txtEnglishMask})
        Me.gcReference.TabStop = False
        Me.gcReference.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colEnglishName, Me.colTranslatedValue, Me.colHACode, Me.gcolOrder})
        Me.GridView1.GridControl = Me.gcReference
        resources.ApplyResources(Me.GridView1, "GridView1")
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsCustomization.AllowFilter = False
        Me.GridView1.OptionsMenu.EnableColumnMenu = False
        Me.GridView1.OptionsMenu.EnableFooterMenu = False
        Me.GridView1.OptionsMenu.EnableGroupPanelMenu = False
        Me.GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'colEnglishName
        '
        Me.colEnglishName.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colEnglishName, "colEnglishName")
        Me.colEnglishName.FieldName = "strDefault"
        Me.colEnglishName.Name = "colEnglishName"
        '
        'colTranslatedValue
        '
        Me.colTranslatedValue.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colTranslatedValue, "colTranslatedValue")
        Me.colTranslatedValue.FieldName = "name"
        Me.colTranslatedValue.Name = "colTranslatedValue"
        '
        'colHACode
        '
        Me.colHACode.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colHACode, "colHACode")
        Me.colHACode.ColumnEdit = Me.RepositoryItemPopupContainerEdit1
        Me.colHACode.FieldName = "intHACode"
        Me.colHACode.Name = "colHACode"
        '
        'RepositoryItemPopupContainerEdit1
        '
        Me.RepositoryItemPopupContainerEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryItemPopupContainerEdit1.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryItemPopupContainerEdit1.Name = "RepositoryItemPopupContainerEdit1"
        '
        'gcolOrder
        '
        resources.ApplyResources(Me.gcolOrder, "gcolOrder")
        Me.gcolOrder.ColumnEdit = Me.spinOrder
        Me.gcolOrder.FieldName = "intOrder"
        Me.gcolOrder.Name = "gcolOrder"
        Me.gcolOrder.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        '
        'spinOrder
        '
        resources.ApplyResources(Me.spinOrder, "spinOrder")
        Me.spinOrder.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.spinOrder.Name = "spinOrder"
        '
        'txtEnglishMask
        '
        Me.txtEnglishMask.Mask.BeepOnError = CType(resources.GetObject("txtEnglishMask.Mask.BeepOnError"), Boolean)
        Me.txtEnglishMask.Mask.EditMask = resources.GetString("txtEnglishMask.Mask.EditMask")
        Me.txtEnglishMask.Mask.MaskType = CType(resources.GetObject("txtEnglishMask.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtEnglishMask.Name = "txtEnglishMask"
        '
        'cmdDeleteRow
        '
        resources.ApplyResources(Me.cmdDeleteRow, "cmdDeleteRow")
        Me.cmdDeleteRow.Image = Global.EIDSS.My.Resources.Resources.Delete_Remove
        Me.cmdDeleteRow.Name = "cmdDeleteRow"
        '
        'ReferenceDetail
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.gcReference)
        Me.Controls.Add(Me.cmdDeleteRow)
        Me.Controls.Add(Me.lbReferenceType)
        Me.Controls.Add(Me.cbRefType)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "A01"
        Me.HelpTopicID = "Basic_reference_Editor"
        Me.KeyFieldName = "idfsBaseReference"
        Me.LeftIcon = Global.EIDSS.My.Resources.Resources.Reference_Book__large__41_
        Me.Name = "ReferenceDetail"
        Me.ObjectName = "BaseReference"
        Me.ShowDeleteButton = False
        Me.SingleInstance = True
        Me.Sizable = True
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "BaseReference"
        Me.Controls.SetChildIndex(Me.cbRefType, 0)
        Me.Controls.SetChildIndex(Me.lbReferenceType, 0)
        Me.Controls.SetChildIndex(Me.cmdDeleteRow, 0)
        Me.Controls.SetChildIndex(Me.gcReference, 0)
        CType(Me.cbRefType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcReference, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemPopupContainerEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spinOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEnglishMask, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub


#End Region

#Region "Main form interface"
    Private Shared m_Parent As Control
    Public Shared Sub Register(ByVal ParentControl As System.Windows.Forms.Control)
        m_Parent = ParentControl
        Dim category As MenuAction = MenuActionManager.Instance.FindAction("MenuReferencies", MenuActionManager.Instance.System, 950, MenuIconsSmall.References, -1)
        Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, category, "MenuReferenceEditor", 900, False, MenuIconsSmall.References, -1)
        ma.SelectPermission = PermissionHelper.SelectPermission(eidss.model.Enums.EIDSSPermissionObject.Reference)
        ma.Name = "btnReferenceEditor"
    End Sub

    Public Shared Sub ShowMe()
        BaseFormManager.ShowNormal(New ReferenceDetail, Nothing)
        'BaseForm.ShowModal(New ReferenceDetail)
    End Sub
#End Region

    Protected Overrides Sub DefineBinding()
        m_DoDeleteAfterNo = False
        RefView = m_Helper.BindView(baseDataSet, True)
        Me.cbRefType.Properties.DataSource = New DataView(baseDataSet.Tables("ReferenceType"))
        Me.cbRefType.Properties.DisplayMember = "strReferenceTypeName"
        Me.cbRefType.Properties.ValueMember = "idfsReferenceType"
        Me.cbRefType.Properties.Columns(0).Caption = EidssMessages.Get("colReferenceTypeName", "Reference Type Name")
        cbRefType.DataBindings.Add("EditValue", baseDataSet, "MasterReferenceType.idfsReferenceType", False, DataSourceUpdateMode.OnPropertyChanged)
        eventManager.AttachDataHandler("MasterReferenceType.idfsReferenceType", AddressOf RefType_Changed)
        If Not Me.StartUpParameters Is Nothing AndAlso Not Utils.IsEmpty(StartUpParameters("ReferenceType")) Then
            If CType(cbRefType.Properties.DataSource, DataView).Table.Select("idfsReferenceType = " + Utils.Str(CLng(StartUpParameters("ReferenceType")))).Length = 0 Then
                Throw New UserErrorException(EidssMessages.Get("errReferenceIsNotEditable", "This reference type cannot be edited"))
            End If
            baseDataSet.Tables("MasterReferenceType").Rows(0)("idfsReferenceType") = CLng(StartUpParameters("ReferenceType"))
            cbRefType.Enabled = False
        End If
        eventManager.Cascade("MasterReferenceType.idfsReferenceType")

    End Sub

    Public Overrides Function HasChanges() As Boolean
        Return Not baseDataSet.Tables("BaseReference").GetChanges() Is Nothing
    End Function

    Private m_CanDeleteRow As Boolean
    Private Sub RefType_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        m_Helper.RefType_Changed(sender, e)
        Dim refTypeRow As DataRow = baseDataSet.Tables("ReferenceType").Rows.Find(e.Value)
        Dim RestrictionFlag As BaseReferenceKind = BaseReferenceKind.None
        If Not refTypeRow Is Nothing AndAlso Not refTypeRow("intStandard") Is DBNull.Value Then
            RestrictionFlag = CType(refTypeRow("intStandard"), BaseReferenceKind)
        End If
        If (RestrictionFlag And BaseReferenceKind.DisableDeleting) <> 0 Then
            cmdDeleteRow.Enabled = False
        Else
            cmdDeleteRow.Enabled = eidss.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.DeletePermission( _
                                                        eidss.model.Enums.EIDSSPermissionObject.Reference))
        End If
        m_CanDeleteRow = cmdDeleteRow.Enabled
        Dim intHACodeMask As Integer
        If Not refTypeRow Is Nothing AndAlso Not refTypeRow("intHACodeMask") Is DBNull.Value Then
            intHACodeMask = CInt(refTypeRow("intHACodeMask"))
        End If

        colHACode.Visible = intHACodeMask <> 0
        If (RestrictionFlag And BaseReferenceKind.AllowTranslationOnly) <> 0 Then
            colEnglishName.OptionsColumn.AllowEdit = False
            colHACode.OptionsColumn.AllowEdit = False
            gcolOrder.OptionsColumn.AllowEdit = False
        Else
            colEnglishName.OptionsColumn.AllowEdit = True
            colHACode.OptionsColumn.AllowEdit = True
            gcolOrder.OptionsColumn.AllowEdit = True
        End If
        If (colHACode.Visible) Then
            Core.LookupBinder.BindReprositoryHACodeLookup(RepositoryItemPopupContainerEdit1, baseDataSet.Tables("HACodes").DefaultView, GridView1, intHACodeMask)
            colHACode.SortMode = ColumnSortMode.DisplayText
        End If
    End Sub

    Private Sub cmdDeleteRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteRow.Click
        m_Helper.DeleteRow()
    End Sub

    Private Sub GridView1_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        Dim row As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        If Not row Is Nothing Then
            If m_CanDeleteRow = False AndAlso row.RowState = DataRowState.Added Then
                cmdDeleteRow.Enabled = True
            Else
                cmdDeleteRow.Enabled = m_CanDeleteRow
            End If
        End If
    End Sub

    Private Sub GridView1_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView1.InitNewRow
        Dim refType As Object = cbRefType.EditValue
        If (refType Is DBNull.Value) Then
            Return
        End If
        Dim refTypeRow As DataRow = baseDataSet.Tables("ReferenceType").Rows.Find(refType)
        If (Not refTypeRow Is Nothing AndAlso Not refTypeRow("intDefaultHACode") Is DBNull.Value) Then
            Dim row As DataRow = GridView1.GetDataRow(e.RowHandle)
            row("intHACode") = refTypeRow("intDefaultHACode")
        End If
    End Sub

    Private Sub GridView1_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GridView1.ValidateRow
        m_Helper.ValidateRow(e)
    End Sub



    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Overrides Property [ReadOnly]() As Boolean
        Get
            Return MyBase.ReadOnly
        End Get
        Set(ByVal value As Boolean)
            MyBase.ReadOnly = value
            If value Then
                cmdDeleteRow.Visible = False
                If EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission( _
                                                            EIDSS.model.Enums.EIDSSPermissionObject.Reference)) Then
                    CType(gcReference.FocusedView, DevExpress.XtraGrid.Views.Grid.GridView).OptionsBehavior.Editable = True
                End If
            Else
                If Not EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.DeletePermission( _
                                                        EIDSS.model.Enums.EIDSSPermissionObject.Reference)) Then
                    cmdDeleteRow.Visible = True
                    cmdDeleteRow.Enabled = False
                End If
                If Not EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission( _
                                                        EIDSS.model.Enums.EIDSSPermissionObject.Reference)) Then
                    If Not RefView Is Nothing Then RefView.AllowNew = False
                End If
                If Not EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.UpdatePermission( _
                                                        EIDSS.model.Enums.EIDSSPermissionObject.Reference)) Then
                    If Not RefView Is Nothing Then RefView.AllowEdit = False
                End If
            End If
        End Set
    End Property

End Class


