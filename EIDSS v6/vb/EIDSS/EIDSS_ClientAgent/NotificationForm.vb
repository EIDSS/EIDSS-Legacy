Imports bv.common.win
Imports System.Threading
Imports System.Globalization
Imports bv.common.Configuration
Imports bv.common.Core
Imports bv.winclient.Core
Imports eidss.model.Core
Imports bv.winclient.Localization

Public Class NotificationForm
    Inherits BaseTaskBarForm
    Private Shared m_Instance As NotificationForm
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ShowEventsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PlaySoundForAlertsToolMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colSiteID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRegion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRayon As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDiagnosis As DevExpress.XtraGrid.Columns.GridColumn
    Private ds As New DataSet

#Region " Windows Form Designer generated code "

    Public Sub New()

        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitFonts()
        MyBase.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        m_Instance = Me
        SupportedLanguages.Clear()
        For Each key As String In Localizer.SupportedLanguages.Keys
            SupportedLanguages.Add(key)
        Next
        SetCaption()
        PlaySoundForAlertsToolMenuItem.Checked = BaseSettings.PlaySoundForAlerts
        Visible = False
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            bv.common.db.Core.DbDisposeHelper.DisposeDataset(ds)
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
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClear As DevExpress.XtraEditors.SimpleButton
    '<System.Diagnostics.DebuggerStepThrough()> _
    Friend WithEvents colEventName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colUser As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEventTime As DevExpress.XtraGrid.Columns.GridColumn
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NotificationForm))
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colEventName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colUser = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEventTime = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSiteID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRegion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRayon = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDiagnosis = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.btnView = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClear = New DevExpress.XtraEditors.SimpleButton()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip()
        Me.ShowEventsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlaySoundForAlertsToolMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        resources.ApplyResources(Me.btnClose, "btnClose")
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnClose.Name = "btnClose"
        '
        'GridControl1
        '
        resources.ApplyResources(Me.GridControl1, "GridControl1")
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colEventName, Me.colUser, Me.colEventTime, Me.colSiteID, Me.colRegion, Me.colRayon, Me.colDiagnosis})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.AutoPopulateColumns = False
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsCustomization.AllowColumnMoving = False
        Me.GridView1.OptionsCustomization.AllowGroup = False
        Me.GridView1.OptionsCustomization.AllowRowSizing = True
        Me.GridView1.OptionsCustomization.AllowSort = False
        Me.GridView1.OptionsFilter.AllowColumnMRUFilterList = False
        Me.GridView1.OptionsFilter.AllowMRUFilterList = False
        Me.GridView1.OptionsMenu.EnableColumnMenu = False
        Me.GridView1.OptionsMenu.EnableFooterMenu = False
        Me.GridView1.OptionsMenu.EnableGroupPanelMenu = False
        Me.GridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'colEventName
        '
        Me.colEventName.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colEventName, "colEventName")
        Me.colEventName.FieldName = "EventName"
        Me.colEventName.Name = "colEventName"
        Me.colEventName.OptionsFilter.AllowAutoFilter = False
        Me.colEventName.OptionsFilter.AllowFilter = False
        '
        'colUser
        '
        Me.colUser.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colUser, "colUser")
        Me.colUser.FieldName = "TargetUser"
        Me.colUser.Name = "colUser"
        '
        'colEventTime
        '
        resources.ApplyResources(Me.colEventTime, "colEventTime")
        Me.colEventTime.DisplayFormat.FormatString = "G"
        Me.colEventTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colEventTime.FieldName = "datEventDatatime"
        Me.colEventTime.Name = "colEventTime"
        Me.colEventTime.OptionsFilter.AllowAutoFilter = False
        Me.colEventTime.OptionsFilter.AllowFilter = False
        '
        'colSiteID
        '
        resources.ApplyResources(Me.colSiteID, "colSiteID")
        Me.colSiteID.FieldName = "strHASCsiteID"
        Me.colSiteID.Name = "colSiteID"
        '
        'colRegion
        '
        resources.ApplyResources(Me.colRegion, "colRegion")
        Me.colRegion.FieldName = "strRegion"
        Me.colRegion.Name = "colRegion"
        '
        'colRayon
        '
        resources.ApplyResources(Me.colRayon, "colRayon")
        Me.colRayon.FieldName = "strRayon"
        Me.colRayon.Name = "colRayon"
        '
        'colDiagnosis
        '
        resources.ApplyResources(Me.colDiagnosis, "colDiagnosis")
        Me.colDiagnosis.FieldName = "strDiagnosis"
        Me.colDiagnosis.Name = "colDiagnosis"
        '
        'btnView
        '
        resources.ApplyResources(Me.btnView, "btnView")
        Me.btnView.Name = "btnView"
        '
        'btnClear
        '
        resources.ApplyResources(Me.btnClear, "btnClear")
        Me.btnClear.Appearance.Options.UseFont = True
        Me.btnClear.Name = "btnClear"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowEventsToolStripMenuItem, Me.PlaySoundForAlertsToolMenuItem, Me.ExitToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        resources.ApplyResources(Me.ContextMenuStrip1, "ContextMenuStrip1")
        '
        'ShowEventsToolStripMenuItem
        '
        Me.ShowEventsToolStripMenuItem.Name = "ShowEventsToolStripMenuItem"
        resources.ApplyResources(Me.ShowEventsToolStripMenuItem, "ShowEventsToolStripMenuItem")
        '
        'PlaySoundForAlertsToolMenuItem
        '
        Me.PlaySoundForAlertsToolMenuItem.CheckOnClick = True
        Me.PlaySoundForAlertsToolMenuItem.Name = "PlaySoundForAlertsToolMenuItem"
        resources.ApplyResources(Me.PlaySoundForAlertsToolMenuItem, "PlaySoundForAlertsToolMenuItem")
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        resources.ApplyResources(Me.ExitToolStripMenuItem, "ExitToolStripMenuItem")
        '
        'NotificationForm
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnClose)
        Me.HelpTopicId = "Replication_Alerts_2"
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NotificationForm"
        Me.ShowInTaskbar = False
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Shared Sub ShowNotifications()
        If m_Instance Is Nothing Then
            m_Instance = New NotificationForm
        End If
        m_Instance.ShowMe()
    End Sub

    Public Shared Function IsVisible() As Boolean
        If m_Instance Is Nothing Then
            Return False
        End If
        If Not m_Instance.NotifyIcon1.Visible Then
            m_Instance.NotifyIcon1.Visible = True
        End If
        If WindowsAPI.IsIconic(m_Instance.Handle) Then
            Return False
        End If
        If m_Instance.WindowState = FormWindowState.Minimized Then Return False
        If WindowsAPI.IsWindowOverapped(m_Instance.Handle) Then
            Return False
        End If
        Return m_Instance.Visible AndAlso m_Instance.Left > 0
    End Function

    Public Shared Sub QueueNotification(ByVal dt As DataTable)
        If m_Instance Is Nothing Then
            m_Instance = New NotificationForm
        End If
        m_Instance.GridControl1.BeginUpdate()
        m_Instance.ds.Merge(dt)
        Dim playSound As Boolean = dt.Rows.Count > 0 AndAlso m_Instance.PlaySoundForAlertsToolMenuItem.Checked
        If m_Instance.GridControl1.DataSource Is Nothing AndAlso m_Instance.ds.Tables.Count > 0 Then
            Dim dw As New DataView(m_Instance.ds.Tables(0))
            dw.Sort = "idfEventID DESC"
            m_Instance.GridControl1.DataSource = dw
            CType(m_Instance.GridControl1.MainView, DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle = 0
        End If
        m_Instance.GridControl1.EndUpdate()
        If playSound Then
            System.Media.SystemSounds.Exclamation.Play()
            'Dim System.Media.SoundPlayer player as new System.Media.SoundPlayer("c:\mywavfile.wav")
            'player.Play()
        End If
    End Sub


    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowEventsToolStripMenuItem.Click
        MyBase.ShowMe()
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        MyBase.Finish()
    End Sub


    Private Sub GridControl1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridControl1.DoubleClick, btnView.Click
        Dim row As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        If Not row Is Nothing Then 'AndAlso Not row("idfObjectID") Is DBNull.Value 
            Dim EventID As Object = row("idfEventID")
            RemotingClient.ShowEventDetail(EventID)
        End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ds.Clear()
    End Sub
    Dim SupportedLanguages As New ArrayList
    Dim CurrentLangIndex As Integer = -1
    Function GetNextLanguage() As String
        Dim cnt As Integer = SupportedLanguages.Count
        If CurrentLangIndex = -1 Then
            For i As Integer = 0 To cnt - 1
                If SupportedLanguages(i).ToString() = bv.model.Model.Core.ModelUserContext.CurrentLanguage Then
                    CurrentLangIndex = i
                    Exit For
                End If
            Next
        End If
        If CurrentLangIndex < cnt - 1 Then
            CurrentLangIndex += 1
        Else
            CurrentLangIndex = 0
        End If
        Return SupportedLanguages(CurrentLangIndex).ToString
    End Function

    Private Sub NotificationForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Windows.Forms.Keys.F2 And e.Shift = True Then
            ResetLanguage(GetNextLanguage)
        End If
        If e.Shift AndAlso e.Control Then
            If e.KeyCode = Keys.E Then
                SetEnglishLanguage()
            ElseIf e.KeyCode = Keys.R Then
                SetRussianLanguage()
            ElseIf e.KeyCode = Keys.A Then
                If Localizer.SupportedLanguages.ContainsKey(Localizer.lngAzLat) Then
                    SetAzeriLanguageLat()
                Else
                    SetArmenianLanguage()
                End If
            ElseIf e.KeyCode = Keys.G Then
                SetGeorgianLanguage()
            ElseIf e.KeyCode = Keys.K Then
                SetKazakhLanguage()
            ElseIf e.KeyCode = Keys.I Then
                SetIraqLanguage()
            ElseIf e.KeyCode = Keys.L Then
                SetLaosLanguage()
            ElseIf e.KeyCode = Keys.V Then
                SetVietnamLanguage()
            ElseIf e.KeyCode = Keys.U Then
                If Localizer.SupportedLanguages.ContainsKey(Localizer.lngUk) Then
                    SetUkrainianLanguage()
                Else
                    SetUzbekLanguageCyr()
                End If
            End If
        End If
        If e.KeyCode = Keys.F1 Then
            Help2.ShowHelp(Me, bv.winclient.Core.WinClientContext.HelpNames(bv.model.Model.Core.ModelUserContext.CurrentLanguage).ToString, "ClientAgent")
        End If
    End Sub
    Public Shared Sub SetLanguage(ByVal LangID As String)
        If Not m_Instance Is Nothing Then
            m_Instance.ResetLanguage(LangID)
        End If

    End Sub

    Private Sub InitFonts()
        WinClientContext.InitFont()
        DxControlsHelper.InitXtraGridAppearance(Me.GridControl1, False)
        DxControlsHelper.InitAppearance(Me.btnClear.Appearance)
        DxControlsHelper.InitAppearance(Me.btnClose.Appearance)
        DxControlsHelper.InitAppearance(Me.btnView.Appearance)
        Font = bv.winclient.Core.WinClientContext.CurrentFont
        Me.ContextMenuStrip1.Font = bv.winclient.Core.WinClientContext.CurrentFont
    End Sub

    Sub ResetLanguage(ByVal LangID As String)
        If Localizer.SupportedLanguages.ContainsKey(LangID) = False Then Exit Sub
        If bv.model.Model.Core.ModelUserContext.CurrentLanguage = LangID Then
            Exit Sub
        End If
        bv.model.Model.Core.ModelUserContext.CurrentLanguage = LangID
        LangID = Localizer.SupportedLanguages(LangID).ToString
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(LangID)
        Thread.CurrentThread.CurrentCulture = New CultureInfo(LangID)
        bv.common.db.Core.LookupCache.Init(True)
        Dim Location1 As Point = Me.Location
        Dim dataSource As Object = GridControl1.DataSource
        Me.SuspendLayout()
        'Dim ShowForm As Boolean = Me.Visible
        'Me.Visible = False
        While Controls.Count > 0
            Controls(0).Dispose()
        End While
        'Me.ContextMenu1.Dispose()
        'Me.MenuItem1.Dispose()
        'Me.MenuItem2.Dispose()

        Me.InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NotificationForm))
        InitFonts()
        Me.ContextMenuStrip1.Font = bv.winclient.Core.WinClientContext.CurrentFont
        MyBase.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        SetCaption()
        Location = Location1
        Dim rect As Rectangle = Submain.GetNotificationAreaRect()
        Dim screenRect As Rectangle = Screen.GetWorkingArea(rect)
        Left = rect.Right - Width
        Top = rect.Top - Height
        If Not dataSource Is Nothing Then
            CType(dataSource, DataView).Table.Columns("EventName").ReadOnly = False
            CType(dataSource, DataView).Table.Columns("strDiagnosis").ReadOnly = False
            CType(dataSource, DataView).Table.Columns("strRegion").ReadOnly = False
            CType(dataSource, DataView).Table.Columns("strRayon").ReadOnly = False
            For Each r As DataRowView In CType(dataSource, DataView)
                r("EventName") = TranslateEventName(r("idfsEventTypeID"))
                r("strDiagnosis") = TranslateDiagnosis(r("idfsDiagnosis"))
                r("strRegion") = TranslateRegion(r("idfsRegion"))
                r("strRayon") = TranslateRayon(r("idfsRayon"))
            Next
        End If
        GridControl1.DataSource = dataSource
        'If ShowForm Then
        '    Me.Visible = True
        'End If
        Me.ResumeLayout()
        WinUtils.SwitchInputLanguage()
        UserConfigWriter.Instance.SetItem("DefaultLanguage", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
        UserConfigWriter.Instance.Save()
        If Not PopupMessage.Instance Is Nothing Then
            PopupMessage.Instance.Close()
        End If
    End Sub
    Private Sub SetCaption()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NotificationForm))
        Me.Text = GetCaption(resources.GetString("$this.Text"))
        resources = New System.ComponentModel.ComponentResourceManager(GetType(BaseTaskBarForm))
        MyBase.NotifyIcon1.Text = GetCaption(resources.GetString("NotifyIcon1.Text"))
    End Sub
    Private Function GetCaption(baseName As String) As String
        Dim suffix As String = Config.GetSetting("CaptionSuffix")
        If (String.IsNullOrEmpty(suffix)) Then
            Return baseName
        End If
        Return String.Format("{0} - {1}", baseName, suffix)
    End Function

    Private Function TranslateEventName(ByVal eventTypeID As Object) As String
        Return bv.common.db.Core.LookupCache.GetLookupValue(eventTypeID, BaseReferenceType.rftEventType, "name")
    End Function
    Private Function TranslateRayon(ByVal rayonID As Object) As String
        Return bv.common.db.Core.LookupCache.GetLookupValue(rayonID, LookupTables.Rayon, "strRayonName")
    End Function
    Private Function TranslateRegion(ByVal regionID As Object) As String
        Return bv.common.db.Core.LookupCache.GetLookupValue(regionID, LookupTables.Region, "strRegionName")
    End Function
    Private Function TranslateDiagnosis(ByVal rayonID As Object) As String
        Return bv.common.db.Core.LookupCache.GetLookupValue(rayonID, LookupTables.StandardDiagnosis, "name")
    End Function
    Private Sub SetEnglishLanguage()
        ResetLanguage(Localizer.lngEn)
    End Sub
    Private Sub SetRussianLanguage()
        ResetLanguage(Localizer.lngRu)
    End Sub
    Private Sub SetGeorgianLanguage()
        ResetLanguage(Localizer.lngGe)
    End Sub
    Private Sub SetKazakhLanguage()
        ResetLanguage(Localizer.lngKz)
    End Sub
    Private Sub SetUzbekLanguageCyr()
        ResetLanguage(Localizer.lngUzCyr)
    End Sub
    Private Sub SetUzbekLanguageLat()
        ResetLanguage(Localizer.lngUzLat)
    End Sub
    'Private Sub SetAzeriLanguageCyr()
    '    ResetLanguage(Localizer.lngAzCyr)
    'End Sub
    Private Sub SetAzeriLanguageLat()
        ResetLanguage(Localizer.lngAzLat)
    End Sub
    Private Sub SetUkrainianLanguage()
        ResetLanguage(Localizer.lngUk)
    End Sub
    Private Sub SetArmenianLanguage()
        ResetLanguage(Localizer.lngAr)
    End Sub
    Private Sub SetIraqLanguage()
        ResetLanguage(Localizer.lngIraq)
    End Sub
    Private Sub SetLaosLanguage()
        ResetLanguage(Localizer.lngLaos)
    End Sub
    Private Sub SetVietnamLanguage()
        ResetLanguage(Localizer.lngVietnam)
    End Sub

    Private Sub NotificationForm_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        SecurityLog.WriteToEventLogDB(Nothing, model.Enums.SecurityAuditEvent.ProcessStop, True, Nothing, Nothing, "EIDSS Client Agent is stopped", model.Enums.SecurityAuditProcessType.ClientAgent)
    End Sub

    Private Sub PlaySoundForAlertsToolMenuItem_Click(sender As Object, e As EventArgs) Handles PlaySoundForAlertsToolMenuItem.Click
        UserConfigWriter.Instance.SetItem("PlaySoundForAlerts", IIf(PlaySoundForAlertsToolMenuItem.Checked, "true", "false").ToString())
        UserConfigWriter.Instance.Save()
    End Sub
End Class


