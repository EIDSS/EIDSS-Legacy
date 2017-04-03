Imports System.Runtime.InteropServices

Public Class WindowsAPI
    Public Const SW_HIDE As Integer = 0
    Public Const SW_MAX As Integer = 10
    Public Const SW_MAXIMIZE As Integer = 3
    Public Const SW_MINIMIZE As Integer = 6
    Public Const SW_NORMAL As Integer = 1
    Public Const SW_RESTORE As Integer = 9
    Public Const SW_SHOW As Integer = 5
    Public Const SW_SHOWDEFAULT As Integer = 10
    Public Const SW_SHOWMAXIMIZED As Integer = 3
    Public Const SW_SHOWMINIMIZED As Integer = 2
    Public Const SW_SHOWMINNOACTIVE As Integer = 7
    Public Const SW_SHOWNA As Integer = 8
    Public Const SW_SHOWNOACTIVATE As Integer = 4
    Public Const SW_SHOWNORMAL As Integer = 1
    Public Const WM_QUERYENDSESSION As Integer = &H11
    Public Const GW_HWNDPREV As Integer = 3

    Public Sub New()
    End Sub

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure RECT

        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
        Public Overrides Function ToString() As String
            Return ("Left :" + left.ToString() + "," + "Top :" + top.ToString() + "," + "Right :" + right.ToString() + "," + "Bottom :" + bottom.ToString())
        End Function
    End Structure

    <DllImport("user32.dll", EntryPoint:="FindWindowEx", CharSet:=CharSet.Auto)> _
     Public Shared Function FindWindowEx( _
                        ByVal hwndParent As IntPtr, _
                        ByVal hwndChildAfter As IntPtr, _
                        <MarshalAs(UnmanagedType.LPTStr)> ByVal _
                        lpszClass As String, _
                        <MarshalAs(UnmanagedType.LPTStr)> ByVal _
                        lpszWindow As String) As IntPtr

    End Function


    <DllImport("user32.dll", EntryPoint:="GetWindowRect", CharSet:=CharSet.Auto)> _
    Public Shared Function GetWindowRect(ByVal hwnd As IntPtr, ByRef lpRect As RECT) As Boolean
    End Function
    <DllImport("User32.dll", CharSet:=CharSet.Auto)> _
    Public Shared Function GetWindowDC(ByVal hWnd As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
           Public Shared Function ReleaseDC(ByVal hWnd As IntPtr, ByVal hDC As IntPtr) As Integer
    End Function
    <DllImport("Winspool.drv", CharSet:=CharSet.Auto)> _
    Public Shared Function SetDefaultPrinter(ByVal pszPrinter As String) As Boolean
    End Function
    <DllImport("User32.dll", EntryPoint:="ShowWindow", CharSet:=CharSet.Auto)> _
    Public Shared Function ShowWindow(ByVal hWnd As IntPtr, ByVal nCmdShow As Integer) As Boolean
    End Function

    <DllImport("User32.dll", EntryPoint:="UpdateWindow", CharSet:=CharSet.Auto)> _
    Public Shared Function UpdateWindow(ByVal hWnd As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll", EntryPoint:="IsIconic", CharSet:=CharSet.Auto)> _
    Public Shared Function IsIconic(ByVal hWnd As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll", EntryPoint:="SetForegroundWindow", CharSet:=CharSet.Auto)> _
    Public Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll", EntryPoint:="DrawAnimatedRects", CharSet:=CharSet.Auto)> _
    Private Shared Function DrawAnimatedRects(ByVal hwnd As IntPtr, ByVal idAni As Integer, ByRef lprcFrom As RECT, ByRef lprcTo As RECT) As Boolean
    End Function

    <DllImport("user32.dll", EntryPoint:="GetWindow", CharSet:=CharSet.Auto)> _
    Private Shared Function GetWindow(ByVal hwnd As IntPtr, ByVal uCmd As Integer) As IntPtr
    End Function
    <DllImport("user32.dll", EntryPoint:="IntersectRect", CharSet:=CharSet.Auto)> _
    Private Shared Function IntersectRect(ByRef rDest As RECT, ByRef rSrc1 As RECT, ByRef rSrc2 As RECT) As Boolean
    End Function

    <DllImport("user32.dll", EntryPoint:="IsWindowVisible", CharSet:=CharSet.Auto)> _
    Private Shared Function IsWindowVisible(ByVal hwnd As IntPtr) As Boolean
    End Function

    Public Shared Function IsWindowOverapped(ByVal hWnd As IntPtr) As Boolean
        'Start from the current window and use the GetWindow()
        'function to move through the previous window handles.
        ' 
        Dim myRect As RECT
        If hWnd.Equals(IntPtr.Zero) Then
            Return False
        End If
        Dim DestRect As RECT, OtherRect As RECT
        Dim hPrevWnd As IntPtr, hNextWnd As IntPtr
        hPrevWnd = hWnd
        While True
            hNextWnd = WindowsAPI.GetWindow(hPrevWnd, GW_HWNDPREV)
            If hNextWnd.Equals(IntPtr.Zero) = True Then
                Exit While
            End If
            'Get the window rectangle dimensions of the window that
            'is higher Z-Order than the application's window.
            GetWindowRect(hNextWnd, OtherRect)
            'Get the window rectangle dimensions of the window that
            'Check to see if this window is visible and if intersects
            'with the rectangle of the application's window. If it does,
            'call MessageBeep(). This intersection is an area of this
            'application's window that is not visible.
            If IsWindowVisible(hNextWnd) AndAlso IntersectRect(DestRect, myRect, OtherRect) Then
                Return True
            End If
            hPrevWnd = hNextWnd
        End While
        Return False
    End Function

    <DllImport("User32.dll")> _
    Public Shared Function GetAsyncKeyState(ByVal vKey As Integer) As Integer
    End Function
    <DllImport("User32.dll")> _
    Public Shared Function GetKeyState(ByVal vKey As Integer) As Integer
    End Function

End Class
