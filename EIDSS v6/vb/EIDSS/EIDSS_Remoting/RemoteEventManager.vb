Imports System.Runtime.InteropServices
Imports System.Reflection
Imports bv.common.Configuration

Public Delegate Sub ShowEventDetailHandler(ByVal EventID As Object)
<InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
Public Interface IRemoteServer
    Sub ShowEventDetail(ByVal EventId As Object)
    Property MainForm() As Object

End Interface

Public Class RemoteEventManager
    Inherits MarshalByRefObject
    Implements IRemoteServer
    Private Shared m_Timer As System.Timers.Timer
    Private Shared m_EventsQueue As New Queue
    Public Const Uri As String = "EIDSS_RemotingServer"

    Public Sub New()
        Console.WriteLine("RemoteEventManager activated")
    End Sub
    Private Shared m_Singleton As New RemoteEventManager
    Public Shared ReadOnly Property Singleton() As RemoteEventManager
        Get
            Return m_Singleton
        End Get
    End Property


    Public Sub ShowEventDetail(ByVal EventID As Object) Implements IRemoteServer.ShowEventDetail
        If m_Timer Is Nothing Then
            m_Timer = New System.Timers.Timer
            AddHandler m_Timer.Elapsed, AddressOf Timer_Elapsed
        End If
        m_EventsQueue.Enqueue(EventID)
        m_Timer.Start()
    End Sub

    Private Sub Timer_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)
        m_Timer.Stop()
        Dim EventID As Object = Nothing
        If m_EventsQueue.Count > 0 Then
            EventID = m_EventsQueue.Dequeue()
        End If
        If Not EventID Is Nothing Then
            Dim mi As Reflection.MethodInfo
            mi = Singleton.MainForm.GetType().GetMethod("ShowEventDetail")
            If Not mi Is Nothing Then
                Dim d As [Delegate] = _
                    [Delegate].CreateDelegate(GetType(ShowEventDetailHandler), Singleton.MainForm, mi)
                'We should call ShowEventDetail in the thread of main application, 
                'to do this use Invoke method of main application form
                CType(Singleton.MainForm, System.Windows.Forms.Control).Invoke(d, New Object() {EventID})
            End If
        End If
        If m_EventsQueue.Count > 0 Then
            m_Timer.Start()
        End If
    End Sub


    Private m_MainForm As Object
    Public Property MainForm() As Object Implements IRemoteServer.MainForm
        Get
            Return m_MainForm
        End Get
        Set(ByVal value As Object)
            m_MainForm = value
        End Set
    End Property

    Public Shared ReadOnly Property RemoteURL() As String
        Get
            Return String.Format("tcp://localhost:{0}/{1}", TcpPort, Uri)
        End Get
    End Property
    Private Shared m_port As Integer = 0
    Private Shared m_defaultPort As Integer = 4001
    Public Shared ReadOnly Property TcpPort() As Integer
        Get
            If m_port = 0 Then
                m_port = BaseSettings.TcpPort
            End If
            Return m_port
        End Get
    End Property
End Class

