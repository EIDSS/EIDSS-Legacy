Imports System.ComponentModel
Imports bv.winclient.Core
Imports bv.winclient.BasePanel
Imports eidss.model.Core
Imports EIDSS.model.Resources
Imports bv.model.Model.Core
Imports EIDSS.model.Enums
Imports bv.common.Enums

Public Class SamplesGroupCheckIn
    Inherits bv.common.win.BaseDetailForm

    Private m_SessionType As eidss.model.Enums.SessionType = eidss.model.Enums.SessionType.None
    Friend WithEvents PopUpButton2 As bv.common.win.PopUpButton
    Friend WithEvents cmAccessionIN As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Public WithEvents GroupCheckInPanel1 As EIDSS.GroupCheckInPanel 'Public, not Friend - for "ScanFormsMode"

#Region " Windows Form Designer generated code "
    <CLSCompliantAttribute(False)>
    Public Sub New(ByVal code As HACode, ByVal sessionType As EIDSS.model.Enums.SessionType)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        Init(code, sessionType)

    End Sub
    Public Sub New()
        MyBase.New()
        InitializeComponent()

    End Sub
    <CLSCompliantAttribute(False)>
    Public Sub Init(ByVal code As HACode, ByVal sessionType As EIDSS.model.Enums.SessionType)
        Me.DbService = New SamplesGroupCheckIn_DB
        AuditObject = New AuditObject(EIDSSAuditObject.daoCheckIn, AuditTable.tlbMaterial)
        m_SessionType = sessionType
        Me.RegisterChildObject(Me.GroupCheckInPanel1)
        AddHandler Me.GroupCheckInPanel1.BarcodeButton1.ButtonPressed, AddressOf BarcodePressed
    End Sub
    Public Overrides Function GetChildKey(ByVal child As IRelatedObject) As Object
        Return GetKey()
    End Function
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
    Friend WithEvents cmSamplesBarcodes As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SamplesGroupCheckIn))
        Me.cmSamplesBarcodes = New System.Windows.Forms.ContextMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.PopUpButton2 = New bv.common.win.PopUpButton()
        Me.cmAccessionIN = New System.Windows.Forms.ContextMenu()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.GroupCheckInPanel1 = New EIDSS.GroupCheckInPanel()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(SamplesGroupCheckIn), resources)
        'Form Is Localizable: True
        '
        'cmSamplesBarcodes
        '
        Me.cmSamplesBarcodes.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        resources.ApplyResources(Me.MenuItem1, "MenuItem1")
        '
        'PopUpButton2
        '
        resources.ApplyResources(Me.PopUpButton2, "PopUpButton2")
        Me.PopUpButton2.ButtonType = bv.common.win.PopUpButton.PopUpButtonStyles.Reports
        Me.PopUpButton2.Name = "PopUpButton2"
        Me.PopUpButton2.PopUpMenu = Me.cmAccessionIN
        Me.PopUpButton2.Tag = "{Immovable}{AlwaysEditable}"
        '
        'cmAccessionIN
        '
        Me.cmAccessionIN.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2})
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 0
        resources.ApplyResources(Me.MenuItem2, "MenuItem2")
        '
        'GroupCheckInPanel1
        '
        resources.ApplyResources(Me.GroupCheckInPanel1, "GroupCheckInPanel1")
        Me.GroupCheckInPanel1.Appearance.Options.UseFont = True
        Me.GroupCheckInPanel1.FormID = Nothing
        Me.GroupCheckInPanel1.HelpTopicID = Nothing
        Me.GroupCheckInPanel1.KeyFieldName = "idfMaterial"
        Me.GroupCheckInPanel1.MultiSelect = False
        Me.GroupCheckInPanel1.Name = "GroupCheckInPanel1"
        Me.GroupCheckInPanel1.ObjectName = "CaseSamples"
        Me.GroupCheckInPanel1.TableName = "Material"
        Me.GroupCheckInPanel1.UseParentDataset = True
        '
        'SamplesGroupCheckIn
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.GroupCheckInPanel1)
        Me.Controls.Add(Me.PopUpButton2)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "L13"
        Me.HelpTopicID = "lab_l13"
        Me.KeyFieldName = "idfMaterial"
        Me.LeftIcon = CType(resources.GetObject("$this.LeftIcon"), System.Drawing.Image)
        Me.Name = "SamplesGroupCheckIn"
        Me.ObjectName = "CaseSamples"
        Me.ShowDeleteButton = False
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "Material"
        Me.Controls.SetChildIndex(Me.PopUpButton2, 0)
        Me.Controls.SetChildIndex(Me.GroupCheckInPanel1, 0)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Overrides Sub DefineBinding()
        Me.GroupCheckInPanel1.ReadOnly = False  '[ReadOnly]
    End Sub


    Public Sub BarcodePressed()
        m_ClosingMode = ClosingMode.None
        '  Barcode printing  for sample
        If Post(PostType.FinalPosting) Then
            Dim row As DataRow = GroupCheckInPanel1.SamplesView.GetDataRow(GroupCheckInPanel1.SamplesView.FocusedRowHandle) 'GetCurrentRow()

            Dim typeId As Long = CType(NumberingObject.Sample, Long)
            Dim objectId As Long = CType(row("idfMaterial"), Long)
            EidssSiteContext.BarcodeFactory.ShowPreview(typeId, objectId)

        End If
    End Sub

    Public Overrides Function HasChanges() As Boolean 'Implements IRelatedObject.HasChanges, IPostable.HasChanges
        Return GroupCheckInPanel1.HasChanges
    End Function

    Public Overrides Function ValidateData() As Boolean
        Return Me.GroupCheckInPanel1.ValidateData()
    End Function


End Class
