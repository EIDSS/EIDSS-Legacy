Imports System.ComponentModel
Imports EIDSS.model.Enums
Imports DevExpress.XtraGrid

Public MustInherit Class GenericReferenceDetail


    Protected Overridable ReadOnly Property ReferenceDbService() As BaseDbService
        Get
            Throw New Exception("property is not implemented")
        End Get
    End Property
    Protected Overridable ReadOnly Property CanDeleteProc() As String
        Get
            Throw New Exception("property is not implemented")
        End Get
    End Property
    Protected Overridable ReadOnly Property MainCaption() As String
        Get
            Throw New Exception("property is not implemented")
        End Get
    End Property
    Protected Overridable ReadOnly Property CodeCaption() As String
        Get
            Throw New Exception("property is not implemented")
        End Get
    End Property
    Protected Overridable ReadOnly Property CodeField() As String
        Get
            Throw New Exception("property is not implemented")
        End Get
    End Property

    Protected Overridable ReadOnly Property HACodeMask() As Integer
        Get
            If (Not StartUpParameters Is Nothing AndAlso StartUpParameters.ContainsKey("HACodeMask")) Then
                Return CInt(StartUpParameters("HACodeMask"))
            End If
            Return HACode.Avian Or HACode.Human Or HACode.Livestock
        End Get
    End Property

    Protected Overridable ReadOnly Property MandatoryFields() As String
        Get
            Return "strDefault,name"
        End Get
    End Property

    Friend WithEvents RefView As DataView
    Private m_Helper As ReferenceEditorHelper
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call

        DbService = ReferenceDbService
        AuditObject = New AuditObject(EIDSSAuditObject.daoReference, AuditTable.trtBaseReference)
        Me.PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.Reference
        'CheckEdits = New ArrayList

        m_Helper = New ReferenceEditorHelper(gcReference, gcolTranslatedValue, MandatoryFields, "strDefault,name")
        m_Helper.CanDeleteProc = CanDeleteProc
        If Not EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.DeletePermission( _
                                EIDSS.model.Enums.EIDSSPermissionObject.Reference)) Then
            btnDelete.Enabled = False
        End If
        gcolEnglishValue.ColumnEdit = ReferenceEditorHelper.EnglishValueEditor
        AddHandler OnBeforePost, AddressOf ReferenceEditorHelper.BeforePost

        Me.gcolCode.FieldName = CodeField
        Me.gcolCode.Caption = CodeCaption
        Me.Caption = MainCaption
        gcolHACode.SortMode = ColumnSortMode.DisplayText

    End Sub


    Protected Overrides Sub DefineBinding()
        m_DoDeleteAfterNo = False
        RefView = m_Helper.BindView(baseDataSet, False)
        Core.LookupBinder.BindReprositoryHACodeLookup(pceHACode, baseDataSet.Tables("HACodes").DefaultView, gvReference, HACodeMask)
    End Sub

    Public Overrides Function HasChanges() As Boolean
        Return Not baseDataSet.Tables("BaseReference").GetChanges() Is Nothing
    End Function


    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        m_Helper.DeleteRow()
    End Sub


    Private Sub gvReference_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles gvReference.ValidateRow
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
