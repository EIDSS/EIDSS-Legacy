Imports bv.common.Diagnostics
Imports System.Collections.Generic
Imports System.Threading
Imports System.Globalization
Imports bv.common.Core
Imports bv.common.Configuration
Imports bv.winclient.Core
Imports bv.winclient.Core.WindowsAPI
Imports bv.model.Model.Core
Imports eidss.model.Resources
Imports eidss.model.Core
Imports bv.model.BLToolkit


Class Submain
    Private Shared m_Started As Boolean = False
    Private Shared m_RestartTimer As Timers.Timer
    Private Shared ReadOnly m_Events As New Queue(Of DataTable)
    Private Shared m_IdleTimer As Windows.Forms.Timer
    <STAThread()> Shared Sub Main()
        Try
            Dim showMessage As Boolean = True
            ConnectionCredentials.DefaultConfigFile = "eidss.main.exe.config"
            If OneInstanceApp.Run(False, showMessage) Then
                SecurityLog.AppName = "EDSS Client Agent"
                DbManagerFactory.SetSqlFactory(New ConnectionCredentials().ConnectionString)
                EidssUserContext.Init()
                'ClassLoader.Init("eidss*.exe", Nothing)
                ClassLoader.Init("eidss_common.dll", Nothing)
                ClassLoader.Init("eidss_db.dll", Nothing)
                DevExpress.UserSkins.BonusSkins.Register()
                Application.EnableVisualStyles()
                'Application.SetCompatibleTextRenderingDefault(False)
                DevExpress.Skins.SkinManager.EnableFormSkins()
                RemotingClient.Init()
                'ConfigWriter.Instance.Read(Nothing)
                'GlobalSettings.Init("EIDSS_Client", "EIDSS Client Agent", "EIDSS_ClientAgent")
                Dim lng As String = BaseSettings.DefaultLanguage
                If Utils.Str(lng) = "" OrElse Not Localizer.SupportedLanguages.ContainsKey(lng) Then
                    lng = Localizer.lngEn
                End If
                bv.model.Model.Core.ModelUserContext.CurrentLanguage = lng
                WinClientContext.ApplicationCaption = EidssMessages.Get("EIDSS_Caption", "Electronic Integrated Disease Surveillance System")
                WinClientContext.Init()
                Thread.CurrentThread.CurrentUICulture = New CultureInfo(Localizer.SupportedLanguages(lng).ToString)
                'EIDSS.model.Core.EidssUserContext.User.SetUser(ServiceConfiguration.UserName, ServiceConfiguration.Password, Nothing, Nothing)
                'EIDSS_EventLog.Instance.TimerType = 1
                AddHandler EIDSS_EventLog.Instance.EventOccured, AddressOf EventOccured
                StartEventLog()
                Dim frm As Form = New NotificationForm
                NotificationForm.IsVisible()
                m_IdleTimer = New Windows.Forms.Timer
                m_IdleTimer.Interval = 1000
                m_IdleTimer.Enabled = True
                AddHandler m_IdleTimer.Tick, AddressOf OnIdle
                SecurityLog.WriteToEventLogDB(Nothing, model.Enums.SecurityAuditEvent.ProcessStart, True, Nothing, Nothing, "EIDSS Client Agent is started", model.Enums.SecurityAuditProcessType.ClientAgent)
                Dbg.Debug("EIDSS Client Agent is started with ClientID {0}", ModelUserContext.ClientID)
                Application.Run(frm)
            Else
                Return
            End If
        Catch ex As Exception
            win.ErrorForm.ShowError(StandardError.UnprocessedError, ex)
            Return
        End Try
    End Sub

    Private Shared Sub OnIdle(ByVal sender As Object, ByVal e As EventArgs)
        m_IdleTimer.Enabled = False
        Try
            Dim dt As DataTable
            SyncLock m_Events
                If m_Events.Count = 0 Then
                    Return
                End If
                dt = m_Events.Dequeue()
            End SyncLock

            Dim info As String = ""
            Dim infoToDisplay As String = ""
            Dim invisibleRows As New List(Of DataRow)
            Dim language As String = ""
            For Each r As DataRow In dt.Rows
                Dbg.ConditionalDebug(DebugDetalizationLevel.EventDebug, "event {0} is received for client {1}", r("idfsEventTypeID"), Utils.Str(r("strClient")))
                Select Case CType(r("idfsEventTypeID"), EventType)
                    Case EventType.NewHumanCase
                        info = EidssMessages.Get("infoNewHumanCase", "New human case is created")
                    Case EventType.NewVetCase
                        info = EidssMessages.Get("infoNewVetCase", "New veterinary case is created")
                    Case EventType.NewOutbreak
                        info = EidssMessages.Get("infoNewOutbreak", "New outbreak notification is created")
                    Case EventType.OutbreakNotificationReceived
                        info = EidssMessages.Get("infoNewOutbreakReceived", "New outbreak notification is received")
                    Case EventType.HumanCaseNotification
                        info = EidssMessages.Get("infoNewHumanCaseReceived", "New human case notification")
                    Case EventType.VetCaseNotification
                        info = EidssMessages.Get("infoNewVetCaseReceived", "New vet case notification")
                        'Case EIDSS.EventType.NewAccessionIn.ToString
                        '    info = EidssMessages.Get("infoNewAccessionIn", "New material accession in info is created")
                        'Case EIDSS.EventType.NewAccessionOut.ToString
                        '    info = EidssMessages.Get("infoNewAccessionOut", "New material accession out info is created")
                    Case EventType.NewTestRequest
                        info = EidssMessages.Get("infoTestRequest", "New test request is created")
                    Case EventType.NewTestResult
                        info = EidssMessages.Get("infoTestResult", "New test results are created")
                    Case EventType.TestResultsReceived
                        info = EidssMessages.Get("infoTestResultReceived", "New test results are received")
                    Case EventType.CaseDiseaseChange, EventType.CaseStatusChange, _
                        EventType.CaseDiseaseChangedNotification, EventType.CaseStatusChangedNotification
                        info = Utils.Str(r("EventName"))
                    Case EventType.ClientUILanguageChanged
                        Dbg.Debug("Language changed event [{0}] is received for client {1}", Utils.Str(r("strInformationString")), Utils.Str(r("strClient")))
                        If Utils.Str(r("strClient")) = EidssUserContext.ClientID Then
                            language = Utils.Str(r("strInformationString"))
                        End If
                        invisibleRows.Add(r)
                    Case EventType.ReferenceTableChanged, EventType.SettlementChanged, EventType.AVRLayoutUpdate
                        invisibleRows.Add(r)
                End Select
                If info <> "" Then
                    infoToDisplay = info
                End If
            Next
            If language <> "" Then
                NotificationForm.SetLanguage(language)
            End If
            If infoToDisplay = "" Then
                infoToDisplay = EidssMessages.Get("infoNewNotificationEvent", "New notification event is received")
            End If
            Dim showNotificationPopup As Boolean = True
            If dt.Rows.Count = invisibleRows.Count Then
                showNotificationPopup = False
            End If
            For Each r As DataRow In invisibleRows
                r.Delete()
            Next
            If Not showNotificationPopup Then
                Return
            End If
            dt.AcceptChanges()
            NotificationForm.QueueNotification(dt)
            ShowPopup(infoToDisplay)
            dt.Clear()
            dt.Dispose()
            MemoryManager.Flush()
        Catch ex As Exception
            Dbg.ConditionalDebug(DebugDetalizationLevel.EventDebug, "Error during client agent idle: {0}", ex.ToString)
        Finally
            m_IdleTimer.Enabled = True
        End Try
    End Sub

    Private Shared Sub EventOccured(ByVal dt As DataTable)
        SyncLock m_Events
            m_Events.Enqueue(dt)
        End SyncLock
    End Sub
    Public Shared Function GetNotificationAreaRect() As Rectangle
        Dim notifyAreaHandle As IntPtr = GetNotificationAreaHandle()
        Dim iconRect As RECT
        If (notifyAreaHandle.Equals(IntPtr.Zero) = False) Then
            If (GetWindowRect(notifyAreaHandle, iconRect) = True) Then
                Return New Rectangle(iconRect.left, iconRect.top, iconRect.right - iconRect.left, iconRect.bottom - iconRect.top)
            End If
        End If
        Return New Rectangle(0, 0, 0, 0)
    End Function

    Public Shared Sub ShowNotificationForm(ByVal frm As Form)
        If frm Is Nothing Then Return
        Dim rect As Rectangle = GetNotificationAreaRect()
        'Dim screenRect As Rectangle = Screen.GetWorkingArea(rect)
        frm.Left = rect.Right - frm.Width
        frm.Top = rect.Top - frm.Height
        frm.Show()
        frm.Activate()
        frm.BringToFront()
        SetForegroundWindow(frm.Handle)
    End Sub
    Private Shared Function GetNotificationAreaHandle() As IntPtr
        Dim hwnd As IntPtr = FindWindowEx(IntPtr.Zero, IntPtr.Zero, "Shell_TrayWnd", Nothing)
        Console.WriteLine("Shell_TrayWnd" + hwnd.ToString())
        hwnd = FindWindowEx(hwnd, IntPtr.Zero, "TrayNotifyWnd", Nothing)
        Console.WriteLine("TrayNotifyWnd" + hwnd.ToString())
        hwnd = FindWindowEx(hwnd, IntPtr.Zero, "SysPager", Nothing)
        Console.WriteLine("SysPager" + hwnd.ToString())
        Return hwnd
    End Function

    Private Shared Sub ShowPopup(Optional ByVal msg As String = "")
        If NotificationForm.IsVisible Then
            NotificationForm.ShowNotifications()
        Else
            PopupMessage.Instance.Message = msg
            ShowNotificationForm(PopupMessage.Instance)
        End If
    End Sub
    Private Shared m_RestartAttemptCount As Integer = 0
    Private Shared Sub StartEventLog()
        Try
            If m_RestartAttemptCount = 0 Then
                bv.common.Trace.WriteLine(bv.common.Trace.Kind.Info, "Starting EventLog listener...")
            End If
            Dbg.Debug("Starting EventLog listener...")

            EIDSS_EventLog.Instance.Connection.Open()
            EIDSS_EventLog.Instance.Listen()
            If Not EIDSS_EventLog.Instance.IsSubscribed() Then
                EIDSS_EventLog.Instance.SubscribeToAllEvents()
            End If
            db.Core.LookupCache.Init(False, False)
            bv.common.Trace.WriteLine(bv.common.Trace.Kind.Info, "EventLog listener is started")
            m_Started = True
            m_RestartAttemptCount = 0
        Catch ex As Exception
            m_Started = False
            If m_RestartAttemptCount = 0 Then
                bv.common.Trace.WriteLine(bv.common.Trace.Kind.Error, "EventLog listener start failed:", ex)
            End If
            Try
                StopEventLog()
                'bv.common.db.Core.LookupCacheListener.Stop()
            Catch ex1 As Exception
                Dbg.Debug("error during EventLog stop:{0}", ex1)
            End Try
            If m_RestartTimer Is Nothing Then
                m_RestartTimer = New Timers.Timer
            End If
            m_RestartTimer.Interval = 30000
            m_RestartTimer.AutoReset = False
            AddHandler m_RestartTimer.Elapsed, AddressOf RestartProc

            m_RestartTimer.Start()
        Finally
            m_RestartAttemptCount += 1
        End Try
    End Sub

    Private Shared Sub StopEventLog()
        Try
            EIDSS_EventLog.Instance.Stop()
        Catch ex As Exception
            Dbg.Debug("error during EventLog stop:{0}", ex)
        End Try
    End Sub

    Public Shared Sub RestartProc(ByVal sender As Object, ByVal e As Timers.ElapsedEventArgs)
        Dbg.Debug("client agent is restarted...")
        RemoveHandler m_RestartTimer.Elapsed, AddressOf RestartProc
        If m_Started Then
            Dbg.Debug("client agent is considered as started already. Quit restart proc")
            Return
        End If
        CType(sender, Timers.Timer).Stop()
        MemoryManager.Flush(True)
        StartEventLog()
    End Sub

End Class
