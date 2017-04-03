Imports System
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public NotInheritable Class MemoryMappedFile
    Implements IDisposable
    Const FILE_MAP_WRITE As Integer = &H2
    Const FILE_MAP_READ As Integer = &H4
    Private memoryFileHandle As IntPtr
    <DllImport("kernel32.dll", EntryPoint:="OpenFileMapping", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function OpenFileMapping(ByVal dwDesiredAccess As Integer, ByVal bInheritHandle As Boolean, ByVal lpName As String) As IntPtr
    End Function

    <DllImport("Kernel32.dll", EntryPoint:="CreateFileMapping", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function CreateFileMapping(ByVal hFile As Integer, ByVal lpAttributes As IntPtr, ByVal flProtect As Integer, ByVal dwMaximumSizeHigh As Integer, ByVal dwMaximumSizeLow As Integer, ByVal lpName As String) As IntPtr
    End Function

    <DllImport("Kernel32.dll")> _
    Private Shared Function MapViewOfFile(ByVal hFileMappingObject As IntPtr, ByVal dwDesiredAccess As Integer, ByVal dwFileOffsetHigh As Integer, ByVal dwFileOffsetLow As Integer, ByVal dwNumberOfBytesToMap As Integer) As IntPtr
    End Function


    <DllImport("Kernel32.dll", EntryPoint:="UnmapViewOfFile", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function UnmapViewOfFile(ByVal lpBaseAddress As IntPtr) As Boolean
    End Function

    <DllImport("kernel32.dll", EntryPoint:="CloseHandle", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function CloseHandle(ByVal hHandle As IntPtr) As Boolean
    End Function

    <DllImport("kernel32.dll", EntryPoint:="GetLastError", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function GetLastError() As Integer
    End Function

    Public Enum FileAccess
        [ReadOnly] = 2
        ReadWrite = 4
    End Enum

    Private Sub New(ByVal aMemoryFileHandle As IntPtr)
        Me.memoryFileHandle = aMemoryFileHandle
    End Sub
    Public Shared Function CreateMMF(ByVal fileName As String, ByVal access As FileAccess, ByVal size As Integer) As MemoryMappedFile
        If (size < 0) Then
            Throw New ArgumentException("The size parameter should be a number greater than Zero.")
        End If
        Dim memoryFileHandle As IntPtr = CreateFileMapping(&HFFFFFFFF, IntPtr.Zero, access, 0, size, fileName)
        If memoryFileHandle.Equals(IntPtr.Zero) Then
            Throw New SharedMemoryException("Creating Shared Memory failed.")
        End If
        Return New MemoryMappedFile(memoryFileHandle)
    End Function
    Public Shared Function ReadHandle(ByVal fileName As String) As IntPtr
        Dim mappedFileHandle As IntPtr = OpenFileMapping(FileAccess.ReadWrite, False, fileName)
        If mappedFileHandle.Equals(IntPtr.Zero) Then
            Throw New SharedMemoryException("Creating Shared Memory failed.")
        End If

        Dim mappedViewHandle As IntPtr = MapViewOfFile(mappedFileHandle, FILE_MAP_READ, 0, 0, 8)
        If mappedViewHandle.Equals(IntPtr.Zero) Then
            Throw New SharedMemoryException("Creating a view of Shared Memory failed.")
        End If

        Dim windowHandle As IntPtr = Marshal.ReadIntPtr(mappedViewHandle)
        If windowHandle.Equals(IntPtr.Zero) Then
            Throw New ArgumentException("Reading from the specified address in  Shared Memory failed.")
        End If

        UnmapViewOfFile(mappedViewHandle)
        CloseHandle(mappedFileHandle)
        Return windowHandle
    End Function

    Public Sub WriteHandle(ByVal windowHandle As IntPtr)
        Dim mappedViewHandle As IntPtr = MapViewOfFile(memoryFileHandle, FILE_MAP_WRITE, 0, 0, 8)
        If mappedViewHandle.Equals(IntPtr.Zero) Then
            Throw New SharedMemoryException("Creating a view of Shared Memory failed.")
        End If

        Marshal.WriteIntPtr(mappedViewHandle, windowHandle)

        UnmapViewOfFile(mappedViewHandle)
        CloseHandle(mappedViewHandle)
    End Sub



    Public Sub Dispose() Implements System.IDisposable.Dispose
        If (memoryFileHandle.Equals(IntPtr.Zero) = False) Then
            If CloseHandle(memoryFileHandle) Then
                memoryFileHandle = IntPtr.Zero
            End If
        End If
    End Sub

    Public Class SharedMemoryException
        Inherits ApplicationException
        Public Sub New()

        End Sub
        Public Sub New(ByVal message As String)
            MyBase.new(message)
        End Sub
        Public Sub New(ByVal message As String, ByVal inner As Exception)
            MyBase.new(message, inner)
        End Sub
    End Class


End Class
