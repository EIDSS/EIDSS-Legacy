Imports System.Runtime.InteropServices
Imports bv.common.Diagnostics
Public Class DebugTimer
    Private Shared m_timerStack As New Stack
    <DllImport("kernel32.dll", EntryPoint:="QueryPerformanceCounter", CharSet:=CharSet.Auto)> _
    Public Shared Function QueryPerformanceCounter(ByRef lpPerformanceCount As Int64) As Boolean
    End Function
    <DllImport("kernel32.dll", EntryPoint:="QueryPerformanceFrequency", CharSet:=CharSet.Auto)> _
    Public Shared Function QueryPerformanceFrequency(ByRef lpFrequency As Int64) As Boolean
    End Function

    Private Class _timer
        Private m_DebugText As String
        Private Shared m_frequency As Int64 = 0
        Private _startTime As Int64
        Private _endTime As Int64
        Private m_Indent As Integer = 0
        Private Function getTimeInterval(ByVal startTime As Int64, ByVal endTime As Int64) As Double
            If (m_frequency = 0) Then
                If QueryPerformanceFrequency(m_frequency) = False Then
                    Return 0
                End If
            End If
            Return (endTime - startTime) / m_frequency
        End Function
        Public Sub New(ByVal debugText As String, ByVal Indent As Integer)
            m_DebugText = debugText
            m_Indent = Indent
            If QueryPerformanceCounter(_startTime) Then
                Dbg.WriteLine("{0}{1} is started at {2:T}", New String(" "c, m_Indent), m_DebugText, DateTime.Now())
            End If
        End Sub
        Public Sub [Stop]()
            If QueryPerformanceCounter(_endTime) Then
                Dbg.WriteLine("{0}{1} is stopped at {2:T}, duration {3}", New String(" "c, m_Indent), m_DebugText, DateTime.Now(), getTimeInterval(_startTime, _endTime))
            End If
        End Sub
        Public Sub [Continue](ByVal debugText As String)
            If debugText Is Nothing Then
                debugText = m_DebugText
            End If
            If QueryPerformanceCounter(_endTime) Then
                Dbg.WriteLine("{0}{1} is contiued at {2:T}, duration {3}", New String(" "c, m_Indent), debugText, DateTime.Now(), getTimeInterval(_startTime, _endTime))
            End If
        End Sub
        Public Function [Time]() As Double
            If QueryPerformanceCounter(_endTime) Then
                Return getTimeInterval(_startTime, _endTime)
            End If
        End Function

    End Class
    Public Shared Sub Start(Optional ByVal debugText As String = Nothing)
#If DEBUG Then
        Dim t As New _timer(debugText, m_timerStack.Count)
        m_timerStack.Push(t)
#End If
    End Sub
    Public Shared Sub Start(ByVal debugText As String, ByVal ParamArray args() As Object)
#If DEBUG Then
        If Not args Is Nothing AndAlso args.Length > 0 Then
            debugText = String.Format(debugText, args)
        End If
        Dim t As New _timer(debugText, m_timerStack.Count)
        m_timerStack.Push(t)
#End If
    End Sub

    Public Shared Sub [Continue](Optional ByVal debugText As String = Nothing)
#If DEBUG Then
        If m_timerStack.Count = 0 Then Return
        Dim t As _timer = CType(m_timerStack.Peek, _timer)
        t.Continue(debugText)
#End If
    End Sub

    Public Shared Sub [Continue](ByVal debugText As String, ByVal ParamArray args() As Object)
#If DEBUG Then
        If Not args Is Nothing AndAlso args.Length > 0 Then
            debugText = String.Format(debugText, args)
        End If
        Dim t As New _timer(debugText, m_timerStack.Count)
        m_timerStack.Push(t)
#End If
    End Sub

    Public Shared Sub [Stop]()
#If DEBUG Then
        If m_timerStack.Count = 0 Then Return
        Dim t As _timer = CType(m_timerStack.Pop, _timer)
        t.Stop()
#End If
    End Sub
    Public Shared Function Time() As Double
#If DEBUG Then
        If m_timerStack.Count = 0 Then Return 0
        Dim t As _timer = CType(m_timerStack.Peek, _timer)
        Return t.Time
#Else
        return 0
#End If
    End Function
End Class
