Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports EIDSS.model.Resources

Public Class ActionDetail

    Inherits BaseDetailList
    Dim ReferenceDbService As Action_DB
    Friend WithEvents RefView As DataView
    Private m_Helper As ReferenceEditorHelper
    Public Sub New()
        MyBase.New()


        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        ReferenceDbService = New Action_DB

        DbService = ReferenceDbService
        AuditObject = New Core.EIDSSAuditObject(EIDSSAuditObject.daoReference, AuditTable.trtBaseReference)
        Me.PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.Reference
        'CheckEdits = New ArrayList

        m_Helper = New ReferenceEditorHelper(gcReference, gcolTranslatedValue, "strDefault,name", "strDefault,name")
        If Not EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.DeletePermission( _
                                EIDSS.model.Enums.EIDSSPermissionObject.Reference)) Then
            btnDelete.Enabled = False
        End If
        gcolEnglishValue.ColumnEdit = ReferenceEditorHelper.EnglishValueEditor
        AddHandler OnBeforePost, AddressOf ReferenceEditorHelper.BeforePost
    End Sub

#Region "Main form interface"
    Private Shared m_Parent As Control
    Public Shared Sub Register(ByVal ParentControl As System.Windows.Forms.Control)
        m_Parent = ParentControl
        Dim category As MenuAction = MenuActionManager.Instance.FindAction("MenuReferencies", MenuActionManager.Instance.System, 960)
        Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, category, "MenuActionReferenceEditor", 920, False, model.Enums.MenuIconsSmall.References, -1)
        ma.SelectPermission = PermissionHelper.SelectPermission(EIDSS.model.Enums.EIDSSPermissionObject.Reference)
        ma.Name = "btnActionReferenceEditor"
    End Sub

    Public Shared Sub ShowMe()
        BaseFormManager.ShowNormal(New ActionDetail, Nothing)
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
            baseDataSet.Tables("MasterReferenceType").Rows(0)("idfsReferenceType") = CLng(StartUpParameters("ReferenceType"))
            'cbRefType.EditValue = CLng(StartUpParameters("ReferenceType"))
            cbRefType.Enabled = False
        End If

        Core.LookupBinder.BindReprositoryHACodeLookup(pceHACode, baseDataSet.Tables("HACodes").DefaultView, gvReference)
        eventManager.Cascade("MasterReferenceType.idfsReferenceType")
    End Sub
    Public Overrides Function HasChanges() As Boolean
        Return Not baseDataSet.Tables("BaseReference").GetChanges() Is Nothing
    End Function

    Private Sub RefType_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        m_Helper.RefType_Changed(sender, e)
        If Utils.IsEmpty(e.Value) Then 'rftProphilacticActionList
            m_Helper.CanDeleteProc = Nothing
        ElseIf CLng(e.Value) = 19000074 Then 'rftProphilacticActionList
            m_Helper.CanDeleteProc = "spProphylacticAction_CanDelete"
        ElseIf CLng(e.Value) = 19000079 Then 'rftSanitaryActionList
            m_Helper.CanDeleteProc = "spSanitaryAction_CanDelete"
        Else
            m_Helper.CanDeleteProc = Nothing
        End If
        'Dim view As DataView = CType(sender, DataTable).DataSet.Tables("BaseReference").DefaultView
        'If Not Utils.IsEmpty(e.Value) Then
        '    view.RowFilter = String.Format("idfsReferenceType = {0}", e.Value)
        'Else
        '    view.RowFilter = String.Format("idfsReferenceType = {0}", -1)
        'End If
        'If Not EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission( _
        '                                        EIDSSPermissionObject.Reference)) Then
        '    view.AllowNew = False
        'End If
        'If Not EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.UpdatePermission( _
        '                                        EIDSSPermissionObject.Reference)) Then
        '    view.AllowEdit = False
        'End If
        'If Not EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.DeletePermission( _
        '                                        EIDSSPermissionObject.Reference)) Then
        '    view.AllowDelete = False
        'Else
        '    view.AllowDelete = True
        'End If

        'If Utils.IsEmpty(cbRefType.EditValue) Then
        '    Me.gvReference.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        'Else
        '    Me.gvReference.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        'End If
    End Sub


    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        m_Helper.DeleteRow()
    End Sub


    Private Sub gvReference_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles gvReference.ValidateRow
        m_Helper.ValidateRow(e)
    End Sub


    Public Overrides Property [ReadOnly]() As Boolean
        Get
            Return MyBase.ReadOnly
        End Get
        Set(ByVal value As Boolean)
            MyBase.ReadOnly = value
            If value Then
                btnDelete.Visible = False
            Else
                If Not EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.DeletePermission( _
                                                        EIDSS.model.Enums.EIDSSPermissionObject.Reference)) Then
                    btnDelete.Visible = True
                    btnDelete.Enabled = False
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
