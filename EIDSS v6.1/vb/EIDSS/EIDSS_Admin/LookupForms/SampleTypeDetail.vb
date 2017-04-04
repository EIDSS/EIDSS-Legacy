Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports EIDSS.model.Resources

Public Class SampleTypeDetail

    Inherits GenericReferenceDetail

    Public Sub New()
        MyBase.New()
        Me.gvReference.OptionsCustomization.AllowFilter = False
        HelpTopicID = "Sample_Type_Reference_Editor"
        Me.FormID = "A28"
    End Sub


    Protected Overrides ReadOnly Property ReferenceDbService() As BaseDbService
        Get
            Return New SampleType_DB
        End Get
    End Property
    Protected Overrides ReadOnly Property CanDeleteProc() As String
        Get
            Return "spSampleTypeReference_CanDelete"
        End Get
    End Property
    Protected Overrides ReadOnly Property MainCaption() As String
        Get
            Return EidssMessages.Get("lblSampleTypeMainCaption") '"Sample Type Reference Editor"
        End Get
    End Property
    Protected Overrides ReadOnly Property CodeCaption() As String
        Get
            Return EidssMessages.Get("lblSampleTypeCodeCaption") '"Code"
        End Get
    End Property
    Protected Overrides ReadOnly Property CodeField() As String
        Get
            Return "strSampleCode"
        End Get
    End Property

#Region "Main form interface"
    Private Shared m_Parent As Control
    Public Shared Sub Register(ByVal ParentControl As System.Windows.Forms.Control)
        m_Parent = ParentControl
        Dim category As MenuAction = MenuActionManager.Instance.FindAction("MenuReferencies", MenuActionManager.Instance.System, 950)
        Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, category, "MenuSampleTypeReferenceEditor", 930, False, model.Enums.MenuIconsSmall.References, -1)
        ma.SelectPermission = PermissionHelper.SelectPermission(EIDSS.model.Enums.EIDSSPermissionObject.Reference)
        ma.Name = "btnSampleTypeReferenceEditor"
    End Sub

    Public Shared Sub ShowMe()
        BaseFormManager.ShowNormal(New SampleTypeDetail, Nothing)
    End Sub
#End Region

    Protected Overrides ReadOnly Property HACodeMask() As Integer
        Get
            Return HACode.Avian Or HACode.Human Or HACode.Livestock Or HACode.Vector
        End Get
    End Property
End Class
