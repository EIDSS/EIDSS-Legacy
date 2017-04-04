Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports System.ComponentModel
Imports EIDSS.model.Enums

Public Class DerivativeForSampleType

    Dim DerivativeForSampleTypeDbService As DerivativeForSampleType_DB
    Private m_Helper As ReferenceEditorHelper
    Friend WithEvents RefView As DataView
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        DerivativeForSampleTypeDbService = New DerivativeForSampleType_DB

        DbService = DerivativeForSampleTypeDbService
        AuditObject = New AuditObject(EIDSSAuditObject.daoDerivativeForSampleType, AuditTable.trtDerivativeForSampleType)
        m_Helper = New ReferenceEditorHelper(DerivativeGrid, Nothing, "idfsDerivativeType", "idfsDerivativeType")
        m_Helper.ReferenceTable = "DerivativeForSampleType"
        m_Helper.KeyField = "idfDerivativeForSampleType"
        m_Helper.MasterTable = "SampleType"
        m_Helper.MasterKeyField = "idfsSampleType"
        PermissionObject = eidss.model.Enums.EIDSSPermissionObject.Reference
        If Not EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.DeletePermission( _
                                        EIDSS.model.Enums.EIDSSPermissionObject.Reference)) Then
            btnDelete.Enabled = False
        End If
        DerivativeView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        AddHandler OnBeforePost, AddressOf ReferenceEditorHelper.BeforePost

    End Sub


#Region "Main form interface"
    Private Shared m_Parent As Control
    Public Shared Sub Register(ByVal ParentControl As System.Windows.Forms.Control)
        m_Parent = ParentControl
        Dim category As MenuAction = MenuActionManager.Instance.FindAction("MenuConfiguration", MenuActionManager.Instance.System, 960)
        Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, category, "MenuDerivativeForSampleType", 971, False, model.Enums.MenuIconsSmall.ReferenceMatrix, -1)
        ma.SelectPermission = PermissionHelper.SelectPermission(eidss.model.Enums.EIDSSPermissionObject.Reference)
        ma.Name = "btnDerivativeForSampleType"
    End Sub

    Public Shared Sub ShowMe()
        BaseFormManager.ShowNormal(New DerivativeForSampleType, Nothing)
        'BaseForm.ShowModal(New Test_For_DiseaseDetail)
    End Sub
#End Region

    Protected Overrides Sub DefineBinding()
        m_DoDeleteAfterNo = False
        RefView = m_Helper.BindView(baseDataSet, True)

        Core.LookupBinder.BindSampleLookup(cbSampleType, baseDataSet, "SampleType.idfsSampleType", True)
        eventManager.AttachDataHandler("SampleType.idfsSampleType", AddressOf m_Helper.RefType_Changed)

        Core.LookupBinder.BindSampleRepositoryLookup(cbDerivativeType, HACode.All, True, False)

        eventManager.Cascade("SampleType.idfsSampleType")

    End Sub
    Public Overrides Function HasChanges() As Boolean
        Return Not baseDataSet.Tables("DerivativeForSampleType").GetChanges() Is Nothing
    End Function

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        m_Helper.DeleteRow()
    End Sub

    Private Sub DerivativeView_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DerivativeView.ValidateRow
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
