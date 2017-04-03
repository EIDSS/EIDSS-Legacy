Imports bv.winclient.Core
Imports eidss.model.Resources

Public Class PopupMessage
    Inherits BvForm
    Private Shared m_Instance As PopupMessage
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        m_Instance = Me
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        m_Instance = Nothing
        'Timer1.Stop()
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PopupMessage))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'PopupMessage
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.Label1)
        Me.HelpTopicId = "Replication_Alerts_2"
        Me.Name = "PopupMessage"
        Me.ShowInTaskbar = False
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.Gray
        Me.ResumeLayout(False)

    End Sub

#End Region

    Shared ReadOnly Property Instance() As PopupMessage
        Get
            If m_Instance Is Nothing Then
                m_Instance = New PopupMessage
            End If
            Return m_Instance
        End Get
    End Property
    Public Property Message() As String
        Get
            Return Label1.Text
        End Get
        Set(ByVal Value As String)
            Label1.Text = String.Format(EidssMessages.Get("infoPopupFormat", Value))
        End Set
    End Property
    Private Sub PopupMessage_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        'Timer1.Start()
    End Sub

    Private Sub Timer1_Elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs)
        If Me.Opacity >= 1.0 Then
            'Timer1.Stop()
        Else
            Me.Opacity += 0.1
            Me.Invalidate()
            Application.DoEvents()
        End If
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        NotificationForm.ShowNotifications()
        Close()
    End Sub

    Private Sub PopupMessage_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        m_Instance = Nothing
    End Sub
End Class
