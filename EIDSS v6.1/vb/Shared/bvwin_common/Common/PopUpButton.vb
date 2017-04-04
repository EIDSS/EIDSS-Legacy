
' TODO Use bv.winclient.Core.PopUpButton instead

'Imports bv.winclient.Core
'Imports bv.common.Resources
'Imports System.ComponentModel
'Imports DevExpress.XtraEditors

'Public Class PopUpButton
'    Inherits SimpleButton

'#Region " Windows Form Designer generated code "
'    Private m_DefaultText As String
'    Private m_DefaultToolTip As String
'    Public Sub New()
'        MyBase.New()

'        'This call is required by the Windows Form Designer.
'        InitializeComponent()
'        m_DefaultText = Me.Text
'        m_DefaultToolTip = Me.ToolTip

'        'Add any initialization after the InitializeComponent() call
'    End Sub

'    'UserControl overrides dispose to clean up the component list.
'    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
'        If disposing Then
'            If Not (components Is Nothing) Then
'                components.Dispose()
'            End If
'        End If
'        MyBase.Dispose(disposing)
'    End Sub

'    'Required by the Windows Form Designer
'    Private components As System.ComponentModel.IContainer
'    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList

'    'NOTE: The following procedure is required by the Windows Form Designer
'    'It can be modified using the Windows Form Designer.  
'    'Do not modify it using the code editor.

'    <System.Diagnostics.DebuggerStepThrough()>
'    Private Sub InitializeComponent()
'        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PopUpButton))
'        Me.ImageList1 = New System.Windows.Forms.ImageList()
'        Me.SuspendLayout()
'        '
'        'ImageList1
'        '
'        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
'        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
'        Me.ImageList1.Images.SetKeyName(0, "papper form.ico")
'        Me.ImageList1.Images.SetKeyName(1, "Print-Barcodes.ico")
'        Me.ImageList1.Images.SetKeyName(2, "Browse5.png")
'        '
'        'PopUpButton
'        '
'        Me.ImageList = Me.ImageList1
'        resources.ApplyResources(Me, "$this")
'        Me.ResumeLayout(False)

'    End Sub


'#End Region

'    Public Event BeforePopup As EventHandler

'    Private Sub btnButton_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Click
'        If Not PopUpMenu Is Nothing Then
'            RaiseEvent BeforePopup(PopUpMenu, EventArgs.Empty)
'            Dim menu As New PopupMenuWrapper(PopUpMenu)
'            menu.ShowPopup(MousePosition)
'        End If
'    End Sub

'    Public Enum PopUpButtonStyles
'        Reports = 0
'        PrintBarcodes = 1
'        Browse = 2
'    End Enum

'    Private m_PrpButtonType As PopUpButtonStyles = PopUpButtonStyles.Reports

'    Public Property ButtonType() As PopUpButtonStyles
'        Get
'            Return m_PrpButtonType
'        End Get
'        Set(ByVal Value As PopUpButtonStyles)
'            Select Case value
'                Case PopUpButtonStyles.Reports
'                    m_PrpButtonType = value
'                    ImageIndex = 0
'                Case PopUpButtonStyles.PrintBarcodes
'                    m_PrpButtonType = value
'                    ImageIndex = 1
'                    If (Text = m_DefaultText) Then
'                        Text = BvMessages.Get("PrintBarcodes")
'                    End If
'                    If (ToolTip = m_DefaultToolTip) Then
'                        ToolTip = BvMessages.Get("PrintBarcodes")
'                    End If
'                Case PopUpButtonStyles.Browse
'                    m_PrpButtonType = Value
'                    ImageIndex = 2
'                    If (Text = m_DefaultText) Then
'                        Text = BvMessages.Get("AddCaseSession")
'                    End If
'                    If (ToolTip = m_DefaultToolTip) Then
'                        ToolTip = BvMessages.Get("AddCaseSession")
'                    End If
'            End Select
'        End Set
'    End Property
'    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
'    Public Overrides Property Text As String
'        Get
'            Return MyBase.Text
'        End Get
'        Set(value As String)
'            MyBase.Text = value
'        End Set
'    End Property

'    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
'    Public Overrides Property ToolTip As String
'        Get
'            Return MyBase.ToolTip
'        End Get
'        Set(value As String)
'            MyBase.ToolTip = value
'        End Set
'    End Property

'    Private WithEvents prpPopUpMenu As ContextMenu 'DevExpress.XtraBars.PopupMenu
'    Public Property PopUpMenu() As ContextMenu 'DevExpress.XtraBars.PopupMenu
'        Get
'            Return prpPopUpMenu
'        End Get
'        Set(ByVal Value As ContextMenu) 'DevExpress.XtraBars.PopupMenu)
'            prpPopUpMenu = Value
'        End Set
'    End Property

'End Class

