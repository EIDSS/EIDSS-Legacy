Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Reflection
Imports System.Runtime.Remoting
Imports bv.common.Configuration
Imports bv.common.Core
Imports eidss.remoting

Public Class RemotingClient
    Private Shared eventManager As IRemoteServer
    Private Shared ServerUrl As String
    Public Shared Sub Init()
        Try
            Dim chan As New TcpChannel()
            ChannelServices.RegisterChannel(chan, False)
        Catch ex As Exception
            bv.common.Trace.WriteLine(ex)
        End Try
    End Sub

    Public Shared Function ShowEventDetail(ByVal EventID As Object) As Boolean
        Try
            If StartServerProcess(EventID) = False Then
                Return True
            End If
            If eventManager Is Nothing Then
                eventManager = CType(Activator.GetObject(GetType(IRemoteServer), RemoteEventManager.RemoteURL), IRemoteServer)
                bv.common.Diagnostics.Dbg.Debug("remoting object is activated with remote url {0}", RemoteEventManager.RemoteURL)
            End If
            eventManager.ShowEventDetail(EventID)
            Return True
        Catch ex As Exception
            eventManager = Nothing 'CType(Activator.GetObject(GetType(EIDSS_Remoting.IServer), "tcp://localhost:4001/RemotingServer"), EIDSS_Remoting.IServer)
            bv.common.Trace.WriteLine(ex)
            Return False
        End Try
    End Function

    Private Shared Function StartServerProcess(Optional ByVal EventID As Object = Nothing) As Boolean
        Dim ServerFileName As String = BaseSettings.ServerPath
        If ServerFileName = "" Then
            ServerFileName = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\eidss.main.exe"
        End If
        Dim ServerWorkingDir As String = System.IO.Path.GetDirectoryName(ServerFileName)
        If System.Diagnostics.Process.GetProcessesByName("eidss.main").Length = 0 AndAlso System.Diagnostics.Process.GetProcessesByName("eidss.main.vshost").Length = 0 Then
            eventManager = Nothing 'we start new process so should reinitialize eventManager
            Dim pi As New System.Diagnostics.Process
            pi.StartInfo.FileName = ServerFileName
            pi.StartInfo.WorkingDirectory = ServerWorkingDir
            If Not EventID Is Nothing Then
                pi.StartInfo.Arguments = "\e" + EventID.ToString
            End If
            bv.common.Trace.WriteLine(bv.common.Trace.Kind.Info, "eidss is started with command line: {0}", Utils.Str(pi.StartInfo.Arguments))
            pi.Start()
            System.Threading.Thread.Sleep(1000)
            Return False
        End If
        Return True
    End Function


End Class
