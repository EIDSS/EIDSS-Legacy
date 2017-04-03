Imports System.ComponentModel
Public Class PopUpButton
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents btnButton As DevExpress.XtraEditors.SimpleButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PopUpButton))
        Me.btnButton = New DevExpress.XtraEditors.SimpleButton
        Me.SuspendLayout()
        '
        'btnButton
        '
        resources.ApplyResources(Me.btnButton, "btnButton")
        Me.btnButton.Image = CType(resources.GetObject("btnButton.Image"), System.Drawing.Image)
        Me.btnButton.ImageIndex = 0
        Me.btnButton.Name = "btnButton"
        '
        'PopUpButton
        '
        Me.Controls.Add(Me.btnButton)
        Me.Name = "PopUpButton"
        resources.ApplyResources(Me, "$this")
        Me.ResumeLayout(False)

    End Sub


#End Region
    Public Event BeforePopup As EventHandler
    Private Sub btnButton_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnButton.Click
        'Dim p As System.Drawing.Point
        'Dim height As Integer
        If Not PopUpMenu Is Nothing Then
            'p = btnButton.PointToScreen(btnButton.Location)

            'For Each it In PopUpMenu.ItemLinks
            '    height = height + it.Item.Height()
            'Next

            'p.Y = p.Y - CType(height / 2, Integer)
            'PopUpMenu.Show(Me, New System.Drawing.Point(0, 0))
            RaiseEvent BeforePopup(PopUpMenu, EventArgs.Empty)
            Dim menu As New PopupMenuWrapper(Me.PopUpMenu)
            menu.ShowPopup(Control.MousePosition)
        End If

    End Sub

    Public Enum PopUpButtonStyles
        Reports = 0
    End Enum

    Private prpButtonType As PopUpButtonStyles = PopUpButtonStyles.Reports
    Public Property ButtonType() As PopUpButtonStyles
        Get
            Return prpButtonType
        End Get
        Set(ByVal Value As PopUpButtonStyles)
            Select Case Value
                Case PopUpButtonStyles.Reports
                    prpButtonType = Value
                    btnButton.ImageIndex = 0
            End Select
        End Set
    End Property
    '<Browsable(True), Localizable(True), DefaultValue("Reports...")> _
    'Public Property ButtonText() As String
    '    Get
    '        Return btnButton.Text
    '    End Get
    '    Set(ByVal Value As String)
    '        btnButton.Text = Value
    '    End Set
    'End Property

    Private WithEvents prpPopUpMenu As ContextMenu 'DevExpress.XtraBars.PopupMenu
    Public Property PopUpMenu() As ContextMenu 'DevExpress.XtraBars.PopupMenu
        Get
            Return prpPopUpMenu
        End Get
        Set(ByVal Value As ContextMenu) 'DevExpress.XtraBars.PopupMenu)
            prpPopUpMenu = Value
        End Set
    End Property


    ReadOnly Property IsDesignerHosted() As Boolean
        Get
            If (Me.DesignMode = True) Then Return True
            If (System.Diagnostics.Process.GetCurrentProcess().ProcessName = "devenv") Then Return True
            Dim ctrl As Control = Me
            While (ctrl Is Nothing = False)
                If (ctrl.Site Is Nothing) Then Return False
                If (ctrl.Site.DesignMode = True) Then Return True
                ctrl = ctrl.Parent
            End While
            Return False

        End Get
    End Property




    Private Sub PopUpButton_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If (Me.IsDesignerHosted = False) Then
            'If (Utils.IsPACS) Then
            '    Me.btnButton.Text = "Print"
            'End If
        End If
    End Sub
End Class
