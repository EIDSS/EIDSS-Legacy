Imports System.ComponentModel
Imports System.Configuration.Install

<RunInstaller(True)> Public Class NtfyServiceInstaller
    Inherits System.Configuration.Install.Installer

#Region " Component Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Installer overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ServiceInstaller1 As System.ServiceProcess.ServiceInstaller
    Friend WithEvents ServiceProcessInstaller1 As System.ServiceProcess.ServiceProcessInstaller
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ServiceInstaller1 = New System.ServiceProcess.ServiceInstaller()
        Me.ServiceProcessInstaller1 = New System.ServiceProcess.ServiceProcessInstaller()
        '
        'ServiceInstaller1
        '
        Me.ServiceInstaller1.DisplayName = "EIDSS 4.0 Notification Service"
        Me.ServiceInstaller1.ServiceName = "EIDSS40_Ntfy"
        Me.ServiceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Automatic
        '
        'ServiceProcessInstaller1
        '
        Me.ServiceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.NetworkService
        Me.ServiceProcessInstaller1.Password = Nothing
        Me.ServiceProcessInstaller1.Username = Nothing
        '
        'NtfyServiceInstaller
        '
        Me.Installers.AddRange(New System.Configuration.Install.Installer() {Me.ServiceInstaller1, Me.ServiceProcessInstaller1})

    End Sub

#End Region

End Class
