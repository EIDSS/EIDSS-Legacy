Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports System.ComponentModel
Imports EIDSS.model.Enums

Public Class AgeForSpeciesDetail

    Dim AgeForSpeciesDbService As AgeForSpecies_DB
    Private m_Helper As ReferenceEditorHelper
    Friend WithEvents RefView As DataView
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AgeForSpeciesDbService = New AgeForSpecies_DB

        DbService = AgeForSpeciesDbService
        AuditObject = New AuditObject(EIDSSAuditObject.daoSpeciesTypeToAnimalAge, AuditTable.trtSpeciesTypeToAnimalAge)
        m_Helper = New ReferenceEditorHelper(AnimalAgeGrid, Nothing, "idfsAnimalAge", "idfsAnimalAge")
        m_Helper.ReferenceTable = "AgeForSpecies"
        m_Helper.KeyField = "idfSpeciesTypeToAnimalAge"
        m_Helper.MasterTable = "SpeciesType"
        m_Helper.MasterKeyField = "idfsSpeciesType"
        PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.Reference
        If Not EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.DeletePermission( _
                                        EIDSS.model.Enums.EIDSSPermissionObject.Reference)) Then
            btnDelete.Enabled = False
        End If
        AnimalAgeView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        AddHandler OnBeforePost, AddressOf ReferenceEditorHelper.BeforePost

    End Sub


#Region "Main form interface"
    Private Shared m_Parent As Control
    Public Shared Sub Register(ByVal ParentControl As System.Windows.Forms.Control)
        m_Parent = ParentControl
        Dim category As MenuAction = MenuActionManager.Instance.FindAction("MenuConfiguration", MenuActionManager.Instance.System, 960)
        Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, category, "MenuAgeForSpecies", 970, False, model.Enums.MenuIconsSmall.ReferenceMatrix, -1)
        ma.BeginGroup = True
        ma.SelectPermission = PermissionHelper.SelectPermission(EIDSS.model.Enums.EIDSSPermissionObject.Reference)
        ma.Name = "btnAgeForSpecies"
    End Sub

    Public Shared Sub ShowMe()
        BaseFormManager.ShowNormal(New AgeForSpeciesDetail, Nothing)
        'BaseForm.ShowModal(New Test_For_DiseaseDetail)
    End Sub
#End Region

    Protected Overrides Sub DefineBinding()
        m_DoDeleteAfterNo = False
        RefView = m_Helper.BindView(baseDataSet, True)
        RefView.Sort = "intOrder"
        Core.LookupBinder.BindBaseLookup(cbSpeciesType, baseDataSet, "SpeciesType.idfsSpeciesType", db.BaseReferenceType.rftSpeciesList, HACode.Livestock, AddressOf Core.LookupBinder.AddLivestockSpecies)
        eventManager.AttachDataHandler("SpeciesType.idfsSpeciesType", AddressOf m_Helper.RefType_Changed)
        eventManager.AttachDataHandler("AgeForSpecies.idfsAnimalAge", AddressOf Age_Changed)

        Core.LookupBinder.BindBaseRepositoryLookup(cbAnimalAgeMatrix, db.BaseReferenceType.rftAnimalAgeList, True)

        eventManager.Cascade("SpeciesType.idfsSpeciesType")

    End Sub

    Private Sub Age_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        Dim order As String = LookupCache.GetLookupValue(e.Value, db.BaseReferenceType.rftAnimalAgeList, "intOrder")
        Dim result As Integer
        If (Integer.TryParse(order, result)) Then
            e.Row("intOrder") = result
            e.Row.EndEdit()
        End If
    End Sub

    Public Overrides Function HasChanges() As Boolean
        Return Not baseDataSet.Tables("AgeForSpecies").GetChanges() Is Nothing
    End Function

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        m_Helper.DeleteRow()
    End Sub

    Private Sub DerivativeView_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles AnimalAgeView.ValidateRow
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
                If Not eidss.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.DeletePermission( _
                                                        eidss.model.Enums.EIDSSPermissionObject.Reference)) Then
                    btnDelete.Visible = True
                    btnDelete.Enabled = False
                End If
                If Not eidss.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission( _
                                                        eidss.model.Enums.EIDSSPermissionObject.Reference)) Then
                    If Not RefView Is Nothing Then RefView.AllowNew = False
                End If
                If Not eidss.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.UpdatePermission( _
                                                        eidss.model.Enums.EIDSSPermissionObject.Reference)) Then
                    If Not RefView Is Nothing Then RefView.AllowEdit = False
                End If
            End If
        End Set
    End Property

End Class
