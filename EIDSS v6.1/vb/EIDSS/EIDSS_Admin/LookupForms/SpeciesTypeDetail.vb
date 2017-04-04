Imports bv.winclient.BasePanel
Imports bv.winclient.Core
Imports EIDSS.model.Resources

Public Class SpeciesTypeDetail

    Inherits GenericReferenceDetail

    Public Sub New()
        MyBase.New()
        Me.gvReference.OptionsCustomization.AllowFilter = False

        Me.FormID = "A29"
        HelpTopicID = "Species_Type_Reference_Editor"
    End Sub
    Protected Overrides Sub DefineBinding()
        'baseDataSet.Tables("HACodes").DefaultView.RowFilter = String.Format("intHACode<>{0}", CType(HACode.Human, Integer))
        MyBase.DefineBinding()
        If (HACodeMask And (HACode.Livestock Or HACode.Avian)) = (HACode.Livestock Or HACode.Avian) Then
            RefView.RowFilter = String.Format("intHACode = {0} or intHACode = {1}", CType(HACode.Livestock, Integer), CType(HACode.Avian, Integer))
        ElseIf (HACodeMask And HACode.Livestock) = HACode.Livestock Then
            RefView.RowFilter = String.Format("intHACode = {0}", CType(HACode.Livestock, Integer))
        ElseIf (HACodeMask And HACode.Avian) = HACode.Avian Then
            RefView.RowFilter = String.Format("intHACode = {0}", CType(HACode.Avian, Integer))
        End If
    End Sub
    Protected Overrides ReadOnly Property HACodeMask() As Integer
        Get
            If (Not StartUpParameters Is Nothing AndAlso StartUpParameters.ContainsKey("HACodeMask")) Then
                Return CInt(StartUpParameters("HACodeMask"))
            End If
            Return HACode.Avian Or HACode.Livestock
        End Get
    End Property

    Protected Overrides ReadOnly Property ReferenceDbService() As BaseDbService
        Get
            Return New SpeciesType_DB
        End Get
    End Property
    Protected Overrides ReadOnly Property MandatoryFields() As String
        Get
            Return "strDefault,name,intHACode"
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
