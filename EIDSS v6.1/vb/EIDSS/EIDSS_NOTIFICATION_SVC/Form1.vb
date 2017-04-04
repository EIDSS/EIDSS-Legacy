Imports bv.common
Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "
    Private m_EmsSrv As New ServiceBase
    Private m_CdrSrv As New ServiceBase
    Private CdrConnectionString As String = "Persist Security Info=False;User ID=sa;Initial Catalog=EIDSS_Beta_3;Data Source=bv-gdr-02;Password="
    Private EmsConnectionString As String = "Persist Security Info=False;User ID=sa;Initial Catalog=EIDSS_Beta_4;Data Source=bv-gdr-02;Password="
    Dim CdrSettings As New EIDSS_SettingsService
    Dim EmsSettings As New EIDSS_SettingsService
    Dim CdrServer As String = "bv-gdr-02"
    Dim EmsServer As String = "bv-gdr-02"
    Dim CdrDatabase As String = "EIDSS_BETA_3"
    Dim EmsDatabase As String = "EIDSS_BETA_4"
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        GlobalSettings.CurrentLanguage = "en"
        bv.common.db.Core.ConnectionManager.Create("..\app.config")
        bv.common.AppStructure.Init("eidss*.dll", ".")
        bv.common.db.Core.AuditManager.EventLog = EIDSS.EIDSS_EventLog.Instance
        GlobalSettings.CountryID = EIDSSSettings.CountryID
        m_CdrSrv.Start(1, "..\app.config")
        Try
            Me.Text = EIDSSSettings.SiteID + "-" + EIDSSSettings.SiteType
        Catch ex As Exception

        End Try


    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        m_CdrSrv.Finish()
        m_EmsSrv.Finish()
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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(16, 24)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(144, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Server Site Activation"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(16, 24)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(136, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Client Site Activation"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(16, 64)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(152, 23)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Start Notification"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(360, 456)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Location = New System.Drawing.Point(384, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(360, 456)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "GroupBox2"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(752, 493)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        'Dim bf As bv.common.win.BaseForm = New SiteActivationServerList
        'bf.DbService.CreateConnection(CdrConnectionString)
        'bv.common.win.BaseForm.ShowClient(bf, Nothing)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Dim siteID As Object = EmsSettings.Item("SiteID")
        'Dim bf As bv.common.win.BaseForm = New SiteActivationClientDetail
        'bf.DbService.CreateConnection(EmsConnectionString)
        'bv.common.win.BaseForm.ShowNormal(bf, siteID)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim CaseID As Guid = New Tests.NotificationTest().CreateVetCase(0)

        'Dim rc As New ReplicationClient
        'rc.StartReplication(ReplicationType.Regular, Nothing)
        'Dim rc As New ReplicationController
        'rc.StartReplicating()
        'rc.StartJob("bv-gdr-02", "BV-GDR-02-EIDSS_Beta_2-EIDSS_Beta_2_Notificati-BV-GDR-02-EIDSS_Beta_3- 0")
    End Sub
End Class

