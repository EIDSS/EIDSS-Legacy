Imports EIDSS.model.Enums
Imports bv.common.Enums

Public Class LocationSelectDialog
    Inherits bv.common.win.BaseDetailForm

    Protected m_id As Object
    Dim LocationDBService As LocationSelectDialog_DB
#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        Me.InitializeComponent()
        Me.ObjectName = "GeoLocation"
        Me.LocationDBService = New LocationSelectDialog_DB
        Me.DbService = Me.LocationDBService
        AuditObject = New AuditObject(EIDSSAuditObject.daoGeoLocation, AuditTable.tlbGeoLocation)

        MyBase.RegisterChildObject(Me.LocationLookup, RelatedPostOrder.PostFirst)

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
    Friend WithEvents LocationLookup As EIDSS.LocationLookup
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LocationSelectDialog))
        Me.LocationLookup = New EIDSS.LocationLookup()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(LocationSelectDialog), resources)
        'Form Is Localizable: True
        '
        'LocationLookup
        '
        resources.ApplyResources(Me.LocationLookup, "LocationLookup")
        Me.LocationLookup.Appearance.BackColor = CType(resources.GetObject("LocationLookup.Appearance.BackColor"), System.Drawing.Color)
        Me.LocationLookup.Appearance.Options.UseBackColor = True
        Me.LocationLookup.DCManager = Nothing
        Me.LocationLookup.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.LocationLookup.FormID = "C03"
        Me.LocationLookup.HelpTopicID = Nothing
        Me.LocationLookup.IsLocationChanged = False
        Me.LocationLookup.KeyFieldName = Nothing
        Me.LocationLookup.LookupLayout = bv.common.win.LookupFormLayout.Group
        Me.LocationLookup.MultiSelect = False
        Me.LocationLookup.Name = "LocationLookup"
        Me.LocationLookup.ObjectName = Nothing
        Me.LocationLookup.Status = bv.common.win.FormStatus.Draft
        Me.LocationLookup.TableName = Nothing
        Me.LocationLookup.UseParentBackColor = True
        '
        'LocationSelectDialog
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.LocationLookup)
        Me.FormID = "C14"
        Me.HelpTopicID = "GeoLocationForm"
        Me.Name = "LocationSelectDialog"
        Me.Controls.SetChildIndex(Me.LocationLookup, 0)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public ReadOnly Property GetLocationDataSet() As DataSet
        Get
            If (Not Me.LocationLookup Is Nothing) AndAlso (Not Me.LocationLookup.baseDataSet Is Nothing) Then
                Return Me.LocationLookup.baseDataSet
            End If
            Return Nothing
        End Get
    End Property

    Public Overrides Function GetChildKey(ByVal child As IRelatedObject) As Object
        Return Me.LocationDBService.ID
        'Return m_id
    End Function

    Protected Overrides Sub DefineBinding()
        Me.LocationLookup.StartUpParameters = Me.StartUpParameters
        MyBase.DefineBinding()
    End Sub

    Private Function PostInSearchMode(Optional ByVal PostType As PostType = PostType.FinalPosting) As Boolean
        If UseFormStatus = True AndAlso Status = FormStatus.Demo OrElse [ReadOnly] Then
            Return True
        End If
        If DbService Is Nothing Then Return True
        DataEventManager.Flush()
        If Not HasChanges() Then Return True

        If (PostType And PostType.IntermediatePosting) = 0 Then
            Dim DefaultResult As DialogResult = DialogResult.Yes
            If m_ClosingMode <> ClosingMode.Ok Then
                DefaultResult = DialogResult.No
            End If
            m_PromptResult = DefaultResult
            If m_PromptResult = DialogResult.No Then Return True
            RaiseBeforeValidatingEvent()
            If ValidateData() = False Then
                m_PromptResult = DialogResult.Cancel
                Return False
            Else
                m_PromptResult = DialogResult.Yes
            End If
        End If

        If (PostType And PostType.IntermediatePosting) <> 0 Then
            m_State = BusinessObjectState.EditObject Or (m_State And BusinessObjectState.IntermediateObject)
            m_WasSaved = True
        End If
        If (PostType And PostType.FinalPosting) <> 0 Then
            m_State = BusinessObjectState.EditObject
            SaveInitialChanges()
            For Each child As IRelatedObject In m_ChildForms
                If TypeOf (child) Is BaseForm Then
                    CType(child, BaseForm).SaveInitialChanges()
                End If
            Next
            m_WasSaved = False
            m_WasPosted = True
        End If
        Return True
    End Function

    Public Overrides Function Post(Optional ByVal postType As PostType = PostType.FinalPosting) As Boolean
        If (Not Me.StartUpParameters Is Nothing) AndAlso (Me.StartUpParameters.ContainsKey("IsSearchMode")) AndAlso _
           (TypeOf (Me.StartUpParameters("IsSearchMode")) Is Boolean) AndAlso _
           CBool(Me.StartUpParameters("IsSearchMode")) Then Return PostInSearchMode(postType)
        If MyBase.Post(postType) AndAlso MyBase.m_PromptResult <> DialogResult.Cancel Then
            Me.LocationLookup.IsLocationChanged = False
            Return True
        End If
        Return False
    End Function

    Public ReadOnly Property ID() As Object
        Get
            'Return m_id
            Return Me.LocationDBService.ID
        End Get
    End Property

    Public ReadOnly Property DisplayText() As String
        Get
            If (Me.LocationLookup Is Nothing) Then Return ""
            Return Me.LocationLookup.DisplayText
        End Get
    End Property

    Public Function LocationDisplayText() As String
        If (Me.LocationLookup Is Nothing) Then Return ""
        Return Me.LocationLookup.LocationDisplayText()
    End Function

    Public Overrides Function GetKey(Optional ByVal aTableName As String = Nothing, Optional ByVal aKeyFieldName As String = Nothing) As Object
        Return Me.LocationDBService.ID
    End Function

    'Private m_ShowAddress As Boolean = True
    '<System.ComponentModel.Browsable(True), System.ComponentModel.DefaultValue(True)> _
    'Public Property ShowAddress() As Boolean
    '    Get
    '        Return m_ShowAddress
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        m_ShowAddress = Value
    '        Me.LocationLookup.ShowAddress = Value
    '    End Set
    'End Property

    Private m_ShowRelativePoint As Boolean = True
    <System.ComponentModel.Browsable(True), System.ComponentModel.DefaultValue(True)> _
    Public Property ShowRelativePoint() As Boolean
        Get
            Return m_ShowRelativePoint
        End Get
        Set(ByVal Value As Boolean)
            m_ShowRelativePoint = Value
            Me.LocationLookup.ShowRelativePoint = Value
        End Set
    End Property
End Class
