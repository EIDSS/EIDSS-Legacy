Imports System.ComponentModel
Imports DevExpress.XtraEditors.Controls

Public Class PagerPanel
    Inherits DevExpress.XtraEditors.XtraUserControl
    Implements ISupportInitialize

    Private m_pagesDirty As Boolean = True
    Private m_initializing As Boolean = False
    Private m_pageCount As Integer = 0
    Private m_visiblePages As Integer = 10
    Private m_currentPage As Integer = 1
    Const LinkWidth As Integer = 24

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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'PagerPanel
        '
        Me.LookAndFeel.SkinName = "Blue"
        Me.Name = "PagerPanel"
        Me.Size = New System.Drawing.Size(320, 20)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Property VisiblePages() As Integer
        Get
            Return m_visiblePages
        End Get
        Set(ByVal Value As Integer)
            If Value <> m_visiblePages Then
                If Value = 0 Then
                    Throw New ArgumentOutOfRangeException("VisiblePages cannot be zero")
                End If
                m_visiblePages = Value
                UpdatePages()
            End If
        End Set
    End Property

    <Browsable(False)> _
    Public Property CurrentPage() As Integer
        Get
            Return m_currentPage
        End Get
        Set(ByVal Value As Integer)
            If Value <> m_currentPage Then
                Dim oldBlock As Integer = (m_currentPage - 1) \ m_visiblePages
                m_currentPage = Value
                If (m_currentPage - 1) \ m_visiblePages <> oldBlock Then
                    UpdatePages()
                End If
                If Not m_initializing Then
                    OnPageChanged(New EventArgs)
                End If
            End If
        End Set
    End Property

    Public Property PageCount() As Integer
        Get
            Return m_pageCount
        End Get
        Set(ByVal Value As Integer)
            m_pageCount = Value
            UpdatePages()
        End Set
    End Property
    Private m_PageSize As Integer = 10
    Public Property PageSize() As Integer
        Get
            Return m_PageSize
        End Get
        Set(ByVal Value As Integer)
            m_PageSize = Value
            UpdatePages()
        End Set
    End Property

    Public Event PageChanged As EventHandler

    Public Sub OnPageChanged(ByVal e As EventArgs)
        RaiseEvent PageChanged(Me, e)
    End Sub

    Private Sub GridPager_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        If m_pagesDirty Then
            UpdatePages()
        End If
    End Sub

    Private Sub LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        If CStr(e.Link.LinkData) = "<" Then
            CurrentPage = CurrentPage - (CurrentPage - 1) Mod m_visiblePages - 1
        ElseIf CStr(e.Link.LinkData) = ">" Then
            CurrentPage = CurrentPage + m_visiblePages - (CurrentPage - 1) Mod m_visiblePages
        Else
            CurrentPage = CType(e.Link.LinkData, Integer)
        End If
    End Sub

    Private Function MakeLink(ByVal link As Object) As Control
        Dim linkLabel As New DevExpress.XtraEditors.HyperLinkEdit
        linkLabel.LookAndFeel.SkinName = Me.LookAndFeel.SkinName
        'linkLabel.LookAndFeel = Drawing.ContentAlignment.MiddleLeft
        Dim LinkText As String = CType(link, String)
        linkLabel.Text = LinkText
        If LinkText = "<" OrElse LinkText = ">" Then
            linkLabel.Text = "..."
        ElseIf CInt(link) = CurrentPage Then
            linkLabel.Enabled = False
        End If
        'linkLabel.Properties.SingleClick = LinkBehavior.HoverUnderline
        'linkLabel.Links(0).LinkData = link
        linkLabel.Properties.SingleClick = True
        linkLabel.EditValue = link
        AddHandler linkLabel.OpenLink, AddressOf OpenLink
        Return linkLabel
    End Function

    Private Sub OpenLink(ByVal sender As Object, ByVal e As OpenLinkEventArgs)
        If CStr(e.EditValue) = "<" Then
            CurrentPage = CurrentPage - (CurrentPage - 1) Mod m_visiblePages - 1
        ElseIf CStr(e.EditValue) = ">" Then
            CurrentPage = CurrentPage + m_visiblePages - (CurrentPage - 1) Mod m_visiblePages
        Else
            CurrentPage = CType(e.EditValue, Integer)
        End If
    End Sub

    Private Sub MakeLinks(ByVal links As ArrayList)
        If links.Count = 0 Then Return
        Dim left As Integer = Width - links.Count * LinkWidth
        Dim link As String
        For Each link In links
            Dim ctl As Control = MakeLink(link)
            ctl.Left = left
            ctl.Top = (Me.Height - ctl.Height) \ 2
            ctl.Width = LinkWidth
            ctl.Anchor = AnchorStyles.Right Or AnchorStyles.Top
            Controls.Add(ctl)
            left += LinkWidth
        Next
    End Sub

    Private Sub UpdatePages()
        If m_initializing Then Return
        Controls.Clear()
        If m_pageCount = 0 Then
            m_currentPage = 1
        ElseIf m_currentPage > m_pageCount Then
            m_currentPage = m_pageCount
        End If

        Dim links As New ArrayList
        Dim I As Integer
        If DesignMode Then
            links.Add("<")
            For I = 10 To 10 + m_visiblePages
                links.Add(CStr(I))
            Next
            links.Add(">")
        ElseIf m_pageCount < 1 Then
            links.Add("1")
        Else
            Dim startFrom As Integer = m_currentPage - (m_currentPage - 1) Mod m_visiblePages
            Dim endAt As Integer = startFrom + m_visiblePages - 1
            If endAt > m_pageCount Then
                endAt = m_pageCount
            End If
            If startFrom > 1 Then
                links.Add("<")
            End If
            For I = startFrom To endAt
                links.Add(CStr(I))
            Next
            If endAt < m_pageCount Then
                links.Add(">")
            End If
        End If
        MakeLinks(links)
        m_pagesDirty = False
    End Sub

    Public Sub BeginInit() Implements System.ComponentModel.ISupportInitialize.BeginInit
        m_initializing = True
    End Sub

    Public Sub EndInit() Implements System.ComponentModel.ISupportInitialize.EndInit
        m_initializing = False
        UpdatePages()
    End Sub
End Class
