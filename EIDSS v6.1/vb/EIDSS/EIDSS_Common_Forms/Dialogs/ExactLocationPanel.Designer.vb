<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExactLocationPanel
    Inherits bv.common.win.BaseDetailPanel

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExactLocationPanel))
        Me.btnMAP = New DevExpress.XtraEditors.SimpleButton()
        Me.seLongitude = New DevExpress.XtraEditors.SpinEdit()
        Me.seLatitude = New DevExpress.XtraEditors.SpinEdit()
        Me.lblLongitude = New System.Windows.Forms.Label()
        CType(Me.seLongitude.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seLatitude.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(ExactLocationPanel), resources)
        'Form Is Localizable: True
        '
        'btnMAP
        '
        resources.ApplyResources(Me.btnMAP, "btnMAP")
        Me.btnMAP.Image = CType(resources.GetObject("btnMAP.Image"), System.Drawing.Image)
        Me.btnMAP.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnMAP.Name = "btnMAP"
        '
        'seLongitude
        '
        resources.ApplyResources(Me.seLongitude, "seLongitude")
        Me.seLongitude.Name = "seLongitude"
        Me.seLongitude.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.seLongitude.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seLongitude.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seLongitude.Properties.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.seLongitude.Properties.Mask.EditMask = resources.GetString("seLongitude.Properties.Mask.EditMask")
        Me.seLongitude.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("seLongitude.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.seLongitude.Properties.MaxValue = New Decimal(New Integer() {180, 0, 0, 0})
        Me.seLongitude.Properties.MinValue = New Decimal(New Integer() {180, 0, 0, -2147483648})
        Me.seLongitude.Properties.ValidateOnEnterKey = True
        '
        'seLatitude
        '
        resources.ApplyResources(Me.seLatitude, "seLatitude")
        Me.seLatitude.Name = "seLatitude"
        Me.seLatitude.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.seLatitude.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seLatitude.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seLatitude.Properties.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.seLatitude.Properties.Mask.EditMask = resources.GetString("seLatitude.Properties.Mask.EditMask")
        Me.seLatitude.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("seLatitude.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.seLatitude.Properties.MaxValue = New Decimal(New Integer() {89, 0, 0, 0})
        Me.seLatitude.Properties.MinValue = New Decimal(New Integer() {89, 0, 0, -2147483648})
        '
        'lblLongitude
        '
        resources.ApplyResources(Me.lblLongitude, "lblLongitude")
        Me.lblLongitude.Name = "lblLongitude"
        '
        'ExactLocationPanel
        '
        Me.Controls.Add(Me.lblLongitude)
        Me.Controls.Add(Me.seLongitude)
        Me.Controls.Add(Me.seLatitude)
        Me.Controls.Add(Me.btnMAP)
        Me.Name = "ExactLocationPanel"
        resources.ApplyResources(Me, "$this")
        CType(Me.seLongitude.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seLatitude.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnMAP As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents seLongitude As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents seLatitude As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lblLongitude As System.Windows.Forms.Label

    Dim LocationDbService As ExactLocation_DB
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LocationDbService = New ExactLocation_DB
        DbService = LocationDbService
        AddHandler Me.AfterLoadData, AddressOf AfterLoading
        AddHandler Me.OnBeforePost, AddressOf BeforePost
    End Sub

End Class
