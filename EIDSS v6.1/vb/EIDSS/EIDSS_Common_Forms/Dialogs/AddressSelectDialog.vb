Imports EIDSS.model.Enums

Public Class AddressSelectDialog
    Inherits bv.common.win.BaseDetailForm

    Dim AddressDBService As AddressSelectDialog_DB
    Protected m_id As Object

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        Me.InitializeComponent()
        Me.ObjectName = "AddressSelectDialog"
        Me.AddressDBService = New AddressSelectDialog_DB
        Me.DbService = Me.AddressDBService
        Me.AuditObject = New AuditObject(EIDSSAuditObject.daoGeoLocation, AuditTable.tlbGeoLocation)
        Me.RegisterChildObject(Me.AddressLookup, RelatedPostOrder.PostFirst)

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
    Friend WithEvents AddressLookup As EIDSS.AddressLookup
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddressSelectDialog))
        Me.AddressLookup = New EIDSS.AddressLookup()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(AddressSelectDialog), resources)
        'Form Is Localizable: True
        '
        'AddressLookup
        '
        resources.ApplyResources(Me.AddressLookup, "AddressLookup")
        Me.AddressLookup.Appearance.BackColor = CType(resources.GetObject("AddressLookup.Appearance.BackColor"), System.Drawing.Color)
        Me.AddressLookup.Appearance.Options.UseBackColor = True
        Me.AddressLookup.CanExpand = True
        Me.AddressLookup.DCManager = Nothing
        Me.AddressLookup.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.AddressLookup.FormID = "C02"
        Me.AddressLookup.HelpTopicID = Nothing
        Me.AddressLookup.KeyFieldName = Nothing
        Me.AddressLookup.LookupLayout = bv.common.win.LookupFormLayout.Group
        Me.AddressLookup.MandatoryFields = EIDSS.AddressMandatoryFieldsType.None
        Me.AddressLookup.MultiSelect = False
        Me.AddressLookup.Name = "AddressLookup"
        Me.AddressLookup.ObjectName = Nothing
        Me.AddressLookup.PopupEditHeight = 200
        Me.AddressLookup.Status = bv.common.win.FormStatus.Draft
        Me.AddressLookup.TableName = Nothing
        Me.AddressLookup.UseParentBackColor = True
        '
        'AddressSelectDialog
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.AddressLookup)
        Me.Name = "AddressSelectDialog"
        Me.Controls.SetChildIndex(Me.AddressLookup, 0)
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Public Overrides Sub Merge(ByVal ds As DataSet)
    '   Me.baseDataSet.Merge(ds)
    'End Sub

    Public Overrides Function GetChildKey(ByVal child As IRelatedObject) As Object
        Return Me.AddressDBService.ID
    End Function

    Public ReadOnly Property ID() As Object
        Get
            Return Me.AddressDBService.ID
        End Get
    End Property
    Public ReadOnly Property DisplayText() As Object
        Get
            Return Me.AddressLookup.DisplayText
        End Get
    End Property

    Public Overrides Function GetKey(Optional ByVal aTableName As String = Nothing, Optional ByVal aKeyFieldName As String = Nothing) As Object
        Return Me.AddressDBService.ID
    End Function
End Class
