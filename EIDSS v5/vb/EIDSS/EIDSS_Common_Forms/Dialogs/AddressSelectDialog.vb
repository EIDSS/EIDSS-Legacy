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
        Me.AuditObject  = New Core.EIDSSAuditObject(EIDSSAuditObject.daoGeoLocation, AuditTable.tlbGeoLocation)
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AddressSelectDialog))
        Me.AddressLookup = New EIDSS.AddressLookup
        Me.SuspendLayout()
        '
        'AddressLookup
        '
        Me.AddressLookup.AccessibleDescription = resources.GetString("AddressLookup.AccessibleDescription")
        Me.AddressLookup.AccessibleName = resources.GetString("AddressLookup.AccessibleName")
        Me.AddressLookup.Anchor = CType(resources.GetObject("AddressLookup.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.AddressLookup.AutoScroll = CType(resources.GetObject("AddressLookup.AutoScroll"), Boolean)
        Me.AddressLookup.AutoScrollMargin = CType(resources.GetObject("AddressLookup.AutoScrollMargin"), System.Drawing.Size)
        Me.AddressLookup.AutoScrollMinSize = CType(resources.GetObject("AddressLookup.AutoScrollMinSize"), System.Drawing.Size)
        Me.AddressLookup.BackColor = System.Drawing.SystemColors.Control
        Me.AddressLookup.BackgroundImage = CType(resources.GetObject("AddressLookup.BackgroundImage"), System.Drawing.Image)
        Me.AddressLookup.CanExpand = True
        Me.AddressLookup.Caption = resources.GetString("AddressLookup.Caption")
        Me.AddressLookup.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.AddressLookup.Dock = CType(resources.GetObject("AddressLookup.Dock"), System.Windows.Forms.DockStyle)
        Me.AddressLookup.Enabled = CType(resources.GetObject("AddressLookup.Enabled"), Boolean)
        Me.AddressLookup.Font = CType(resources.GetObject("AddressLookup.Font"), System.Drawing.Font)
        Me.AddressLookup.FormID = "C02"
        Me.AddressLookup.HelpTopicID = Nothing
        Me.AddressLookup.ImeMode = CType(resources.GetObject("AddressLookup.ImeMode"), System.Windows.Forms.ImeMode)
        Me.AddressLookup.KeyFieldName = Nothing
        Me.AddressLookup.Location = CType(resources.GetObject("AddressLookup.Location"), System.Drawing.Point)
        Me.AddressLookup.LookupLayout = bv.common.win.LookupFormLayout.Group
        Me.AddressLookup.MultiSelect = False
        Me.AddressLookup.Name = "AddressLookup"
        Me.AddressLookup.ObjectName = Nothing
        Me.AddressLookup.PopupEditHeight = 200
        Me.AddressLookup.RightToLeft = CType(resources.GetObject("AddressLookup.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.AddressLookup.Size = CType(resources.GetObject("AddressLookup.Size"), System.Drawing.Size)
        Me.AddressLookup.State = bv.common.BusinessObjectState.None
        Me.AddressLookup.Status = bv.common.win.FormStatus.Draft
        Me.AddressLookup.TabIndex = CType(resources.GetObject("AddressLookup.TabIndex"), Integer)
        Me.AddressLookup.TableName = Nothing
        Me.AddressLookup.UseParentBackColor = True
        Me.AddressLookup.Visible = CType(resources.GetObject("AddressLookup.Visible"), Boolean)
        '
        'AddressSelectDialog
        '
        Me.AccessibleDescription = resources.GetString("$this.AccessibleDescription")
        Me.AccessibleName = resources.GetString("$this.AccessibleName")
        Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
        Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
        Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.Caption = resources.GetString("$this.Caption")
        Me.Controls.Add(Me.AddressLookup)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.Name = "AddressSelectDialog"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.Size = CType(resources.GetObject("$this.Size"), System.Drawing.Size)
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
