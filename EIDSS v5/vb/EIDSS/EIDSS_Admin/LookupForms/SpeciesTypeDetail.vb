Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports EIDSS.model.Resources

Public Class SpeciesTypeDetail

    Inherits GenericReferenceDetail

    Public Sub New()
        MyBase.New()
        Me.gvReference.OptionsCustomization.AllowFilter = False

        Me.FormID = "A29"
        HelpTopicID = "Species_type_reference_editor"
    End Sub
    Protected Overrides Sub DefineBinding()
        baseDataSet.Tables("HACodes").DefaultView.RowFilter = String.Format("intHACode<>{0}", CType(HACode.Human, Long))
        MyBase.DefineBinding()
    End Sub

    Protected Overrides ReadOnly Property ReferenceDbService() As BaseDbService
        Get
            Return New SpeciesType_DB
        End Get
    End Property
    Protected Overrides ReadOnly Property CanDeleteProc() As String
        Get
            Return "spSpeciesTypeReference_CanDelete"
        End Get
    End Property
    Protected Overrides ReadOnly Property MainCaption() As String
        Get
            Return EidssMessages.Get("lblSpeciesTypeMainCaption") '"Species Type Reference Editor"
        End Get
    End Property
    Protected Overrides ReadOnly Property CodeCaption() As String
        Get
            Return EidssMessages.Get("lblSpeciesTypeCodeCaption") '"Code"
        End Get
    End Property
    Protected Overrides ReadOnly Property CodeField() As String
        Get
            Return "strCode"
        End Get
    End Property


#Region "Main form interface"
    Private Shared m_Parent As Control
    Public Shared Sub Register(ByVal ParentControl As System.Windows.Forms.Control)
        m_Parent = ParentControl
        Dim category As MenuAction = MenuActionManager.Instance.FindAction("MenuReferencies", MenuActionManager.Instance.System, 950)
        Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, category, "MenuSpeciesTypeReferenceEditor", 940, False, model.Enums.MenuIconsSmall.References, -1)
        ma.SelectPermission = PermissionHelper.SelectPermission(EIDSS.model.Enums.EIDSSPermissionObject.Reference)
        ma.Name = "btnSpeciesTypeReferenceEditor"
    End Sub

    Public Shared Sub ShowMe()
        BaseFormManager.ShowNormal(New SpeciesTypeDetail, Nothing)
    End Sub
#End Region

End Class
