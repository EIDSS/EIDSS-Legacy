Imports System.Threading
Imports System.Diagnostics
Imports System.Security.AccessControl


Public Class OneInstanceApp
#Region "Decalrations"
    Private Shared m_mutex As Mutex = Nothing
    Private Shared sharedMemory As MemoryMappedFile

#End Region
    Public Shared Function Run(ByVal activateFirstInstance As Boolean, Optional ByRef showMessage As Boolean = True) As Boolean
        'если в данный момент происходит обновление посредством AUM, то стартовать нельзя
        Dim mutexUpdateNow As Mutex
        Dim alone As Boolean
        Const mutexText As String = "aumupdatenow"
        Trace.WriteLine(Trace.Kind.Info, "aum mutex checking...")
        Try
            mutexUpdateNow = Mutex.OpenExisting(mutexText, MutexRights.FullControl)
            alone = False
        Catch ex As WaitHandleCannotBeOpenedException
            'не найден, можно продолжать работу
            alone = True
        Catch ex As UnauthorizedAccessException
            alone = False
        End Try

        Trace.WriteLine(Trace.Kind.Info, String.Format("aum mutex alone={0}", alone))

        If Not (alone) Then
            showMessage = False
            Trace.WriteLine(Trace.Kind.Info, "EIDSS now exit because aum (bvupdater) is running")
            Return False
        End If

        Dim res As Boolean = False
        Dim newMutexCreated As Boolean = False
        Dim mutexName As String = Process.GetCurrentProcess().MainModule.ModuleName.ToLower(Globalization.CultureInfo.InvariantCulture)
        Dim ver As FileVersionInfo = Process.GetCurrentProcess().MainModule.FileVersionInfo
        mutexName += ver.FileMajorPart.ToString
        If BaseSettings.OneInstanceMethod.ToLowerInvariant = "client" Then
            mutexName += GlobalSettings.ClientID
        ElseIf BaseSettings.OneInstanceMethod.ToLowerInvariant = "user" Then
            mutexName += Environment.UserName
        End If
        Trace.WriteLine(Trace.Kind.Info, "trying to create mutex:" + mutexName)
        Try
            m_mutex = New Mutex(False, mutexName, newMutexCreated)
        Catch ex As Exception
            Trace.WriteLine(Trace.Kind.Error, "error during mutex {0} creation :{1}.", mutexName, ex.ToString)
            'ErrorForm.ShowError(StandardError.UnprocessedError, ex)
            Application.Exit()
        End Try

        If (newMutexCreated) Then
            Trace.WriteLine(Trace.Kind.Info, "new mutex is created:" + mutexName)
            Return True
        Else
            Trace.WriteLine(Trace.Kind.Info, "mutex with name " + mutexName + " exits already")
            If Not activateFirstInstance Then
                Return False
            End If
            Dim mainWindowHandle As System.IntPtr = GetMainWindowHandle()
            If mainWindowHandle.Equals(IntPtr.Zero) = False Then
                If (WindowsAPI.IsIconic(mainWindowHandle)) Then
                    WindowsAPI.ShowWindow(mainWindowHandle, WindowsAPI.SW_RESTORE)
                Else
                    WindowsAPI.SetForegroundWindow(mainWindowHandle)
                End If
            End If
        End If
        Return res
    End Function
    Public Shared Sub RegisterMainWindowHandle(ByVal frm As Form)
        Return

    End Sub


    Public Shared Function GetMainWindowHandle() As System.IntPtr

        Dim processName As String = Process.GetCurrentProcess().MainModule.ModuleName.ToLower(Globalization.CultureInfo.InvariantCulture)
        processName = processName.Substring(0, processName.IndexOf(".exe"))
        Dim processes As System.Diagnostics.Process() = System.Diagnostics.Process.GetProcessesByName(processName)
        Trace.WriteLine(Trace.Kind.Info, "retrieving window handle for process:" + processName)

        'Loop through the running processes in with the same name 

        Dim p As Process
        Dim current As Process = Process.GetCurrentProcess()

        For Each p In processes
            'Ignore the current process 
            If p.MainModule.FileName <> current.MainModule.FileName Then
                Trace.WriteLine(Trace.Kind.Info, "process " + processName + " is found")
                Return p.MainWindowHandle
            End If
        Next
        Trace.WriteLine(Trace.Kind.Info, "process " + processName + " is not found")
        Return Nothing
    End Function 'RunningInstance  

End Class
