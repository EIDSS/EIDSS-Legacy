Imports bv.common.win
Imports bv.winclient.Core
Imports bv.common.Configuration

Public Class BaseTaskBarForm
    Inherits DevExpress.XtraEditors.XtraForm
#Region "Decalrations"

    Private AnimationDisabled As Boolean = False
    Friend WithEvents DefaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
    Private Shared systemShutdown As Boolean = False
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        Me.DefaultLookAndFeel1.LookAndFeel.SkinName = BaseSettings.SkinName '"Money Twins"

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        Me.NotifyIcon1.Dispose()
        GC.Collect()
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
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BaseTaskBarForm))
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.DefaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
        Me.SuspendLayout()
        '
        'NotifyIcon1
        '
        resources.ApplyResources(Me.NotifyIcon1, "NotifyIcon1")
        '
        'BaseTaskBarForm
        '
        resources.ApplyResources(Me, "$this")
        Me.Name = "BaseTaskBarForm"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.ShowInTaskbar = True
    End Sub


    Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
        Try

            If (systemShutdown = True) Then

                e.Cancel = False
            Else
                e.Cancel = True
                'Me.AnimateWindow()
                Me.Visible = False
            End If
        Catch ex As Exception
        End Try

        MyBase.OnClosing(e)

    End Sub

    Protected Overrides Sub OnClosed(ByVal e As System.EventArgs)
        Me.NotifyIcon1.Visible = False
        Me.NotifyIcon1.Icon.Dispose()
        Me.NotifyIcon1.Dispose()
        MyBase.OnClosed(e)
    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        ' Once the program recieves WM_QUERYENDSESSION message, set the boolean systemShutdown.
        If (m.Msg = WindowsAPI.WM_QUERYENDSESSION) Then
            systemShutdown = True
        End If
        MyBase.WndProc(m)
    End Sub
    Private m_ForceWindowShowing As Boolean = False


    Protected Sub DefaultAction(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.DoubleClick
        ShowMe()
    End Sub


    Protected Sub Finish()
        Application.Exit()
    End Sub


    Public Sub ShowMe()
        If Me.Visible = False Then
            m_ForceWindowShowing = True
            Me.Activate()
            Me.Visible = True
        End If
        If (Me.WindowState = FormWindowState.Minimized) Then
            Me.WindowState = FormWindowState.Normal
        End If
        Submain.ShowNotificationForm(Me)
        If PopupMessage.Instance.Visible Then
            PopupMessage.Instance.Hide()
        End If
    End Sub

End Class


