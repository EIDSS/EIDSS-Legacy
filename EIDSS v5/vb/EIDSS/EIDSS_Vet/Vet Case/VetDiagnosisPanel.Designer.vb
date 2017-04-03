<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VetDiagnosisPanel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VetDiagnosisPanel))
        Me.pnDiagnosis = New DevExpress.XtraEditors.GroupControl
        Me.dtFinalDiagnosisDate = New DevExpress.XtraEditors.DateEdit
        Me.txtFinalDiagnosisOIECode = New DevExpress.XtraEditors.TextEdit
        Me.cbFinalDiagnosis = New DevExpress.XtraEditors.LookUpEdit
        Me.lbFinalDiagnosis = New DevExpress.XtraEditors.LabelControl
        Me.dtTentativeDiagnosis3Date = New DevExpress.XtraEditors.DateEdit
        Me.txtTentativeDiagnosis3OIECode = New DevExpress.XtraEditors.TextEdit
        Me.cbTentativeDiagnosis3 = New DevExpress.XtraEditors.LookUpEdit
        Me.lbTentativeDiagnosis3 = New DevExpress.XtraEditors.LabelControl
        Me.dtTentativeDiagnosis2Date = New DevExpress.XtraEditors.DateEdit
        Me.txtTentativeDiagnosis2OIECode = New DevExpress.XtraEditors.TextEdit
        Me.cbTentativeDiagnosis2 = New DevExpress.XtraEditors.LookUpEdit
        Me.lbTentativeDiagnosis2 = New DevExpress.XtraEditors.LabelControl
        Me.dtTentativeDiagnosis1Date = New DevExpress.XtraEditors.DateEdit
        Me.txtTentativeDiagnosis1OIECode = New DevExpress.XtraEditors.TextEdit
        Me.cbTentativeDiagnosis1 = New DevExpress.XtraEditors.LookUpEdit
        Me.lbTentativeDiagnosis1 = New DevExpress.XtraEditors.LabelControl
        CType(Me.pnDiagnosis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnDiagnosis.SuspendLayout()
        CType(Me.dtFinalDiagnosisDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFinalDiagnosisDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFinalDiagnosisOIECode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbFinalDiagnosis.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTentativeDiagnosis3Date.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTentativeDiagnosis3Date.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTentativeDiagnosis3OIECode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTentativeDiagnosis3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTentativeDiagnosis2Date.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTentativeDiagnosis2Date.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTentativeDiagnosis2OIECode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTentativeDiagnosis2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTentativeDiagnosis1Date.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTentativeDiagnosis1Date.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTentativeDiagnosis1OIECode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTentativeDiagnosis1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnDiagnosis
        '
        Me.pnDiagnosis.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.pnDiagnosis.Appearance.Options.UseBackColor = True
        Me.pnDiagnosis.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.pnDiagnosis.AppearanceCaption.Options.UseFont = True
        Me.pnDiagnosis.Controls.Add(Me.dtFinalDiagnosisDate)
        Me.pnDiagnosis.Controls.Add(Me.txtFinalDiagnosisOIECode)
        Me.pnDiagnosis.Controls.Add(Me.cbFinalDiagnosis)
        Me.pnDiagnosis.Controls.Add(Me.lbFinalDiagnosis)
        Me.pnDiagnosis.Controls.Add(Me.dtTentativeDiagnosis3Date)
        Me.pnDiagnosis.Controls.Add(Me.txtTentativeDiagnosis3OIECode)
        Me.pnDiagnosis.Controls.Add(Me.cbTentativeDiagnosis3)
        Me.pnDiagnosis.Controls.Add(Me.lbTentativeDiagnosis3)
        Me.pnDiagnosis.Controls.Add(Me.dtTentativeDiagnosis2Date)
        Me.pnDiagnosis.Controls.Add(Me.txtTentativeDiagnosis2OIECode)
        Me.pnDiagnosis.Controls.Add(Me.cbTentativeDiagnosis2)
        Me.pnDiagnosis.Controls.Add(Me.lbTentativeDiagnosis2)
        Me.pnDiagnosis.Controls.Add(Me.dtTentativeDiagnosis1Date)
        Me.pnDiagnosis.Controls.Add(Me.txtTentativeDiagnosis1OIECode)
        Me.pnDiagnosis.Controls.Add(Me.cbTentativeDiagnosis1)
        Me.pnDiagnosis.Controls.Add(Me.lbTentativeDiagnosis1)
        resources.ApplyResources(Me.pnDiagnosis, "pnDiagnosis")
        Me.pnDiagnosis.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.pnDiagnosis.LookAndFeel.UseDefaultLookAndFeel = False
        Me.pnDiagnosis.Name = "pnDiagnosis"
        Me.pnDiagnosis.TabStop = True
        '
        'dtFinalDiagnosisDate
        '
        Me.dtFinalDiagnosisDate.EditValue = Nothing
        resources.ApplyResources(Me.dtFinalDiagnosisDate, "dtFinalDiagnosisDate")
        Me.dtFinalDiagnosisDate.Name = "dtFinalDiagnosisDate"
        Me.dtFinalDiagnosisDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtFinalDiagnosisDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtFinalDiagnosisDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        '
        'txtFinalDiagnosisOIECode
        '
        resources.ApplyResources(Me.txtFinalDiagnosisOIECode, "txtFinalDiagnosisOIECode")
        Me.txtFinalDiagnosisOIECode.Name = "txtFinalDiagnosisOIECode"
        Me.txtFinalDiagnosisOIECode.Properties.ReadOnly = True
        '
        'cbFinalDiagnosis
        '
        resources.ApplyResources(Me.cbFinalDiagnosis, "cbFinalDiagnosis")
        Me.cbFinalDiagnosis.Name = "cbFinalDiagnosis"
        Me.cbFinalDiagnosis.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbFinalDiagnosis.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        '
        'lbFinalDiagnosis
        '
        resources.ApplyResources(Me.lbFinalDiagnosis, "lbFinalDiagnosis")
        Me.lbFinalDiagnosis.Name = "lbFinalDiagnosis"
        '
        'dtTentativeDiagnosis3Date
        '
        Me.dtTentativeDiagnosis3Date.EditValue = Nothing
        resources.ApplyResources(Me.dtTentativeDiagnosis3Date, "dtTentativeDiagnosis3Date")
        Me.dtTentativeDiagnosis3Date.Name = "dtTentativeDiagnosis3Date"
        Me.dtTentativeDiagnosis3Date.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtTentativeDiagnosis3Date.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtTentativeDiagnosis3Date.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        '
        'txtTentativeDiagnosis3OIECode
        '
        resources.ApplyResources(Me.txtTentativeDiagnosis3OIECode, "txtTentativeDiagnosis3OIECode")
        Me.txtTentativeDiagnosis3OIECode.Name = "txtTentativeDiagnosis3OIECode"
        Me.txtTentativeDiagnosis3OIECode.Properties.ReadOnly = True
        '
        'cbTentativeDiagnosis3
        '
        resources.ApplyResources(Me.cbTentativeDiagnosis3, "cbTentativeDiagnosis3")
        Me.cbTentativeDiagnosis3.Name = "cbTentativeDiagnosis3"
        Me.cbTentativeDiagnosis3.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTentativeDiagnosis3.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        '
        'lbTentativeDiagnosis3
        '
        resources.ApplyResources(Me.lbTentativeDiagnosis3, "lbTentativeDiagnosis3")
        Me.lbTentativeDiagnosis3.Name = "lbTentativeDiagnosis3"
        '
        'dtTentativeDiagnosis2Date
        '
        Me.dtTentativeDiagnosis2Date.EditValue = Nothing
        resources.ApplyResources(Me.dtTentativeDiagnosis2Date, "dtTentativeDiagnosis2Date")
        Me.dtTentativeDiagnosis2Date.Name = "dtTentativeDiagnosis2Date"
        Me.dtTentativeDiagnosis2Date.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtTentativeDiagnosis2Date.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtTentativeDiagnosis2Date.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        '
        'txtTentativeDiagnosis2OIECode
        '
        resources.ApplyResources(Me.txtTentativeDiagnosis2OIECode, "txtTentativeDiagnosis2OIECode")
        Me.txtTentativeDiagnosis2OIECode.Name = "txtTentativeDiagnosis2OIECode"
        Me.txtTentativeDiagnosis2OIECode.Properties.ReadOnly = True
        '
        'cbTentativeDiagnosis2
        '
        resources.ApplyResources(Me.cbTentativeDiagnosis2, "cbTentativeDiagnosis2")
        Me.cbTentativeDiagnosis2.Name = "cbTentativeDiagnosis2"
        Me.cbTentativeDiagnosis2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTentativeDiagnosis2.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        '
        'lbTentativeDiagnosis2
        '
        resources.ApplyResources(Me.lbTentativeDiagnosis2, "lbTentativeDiagnosis2")
        Me.lbTentativeDiagnosis2.Name = "lbTentativeDiagnosis2"
        '
        'dtTentativeDiagnosis1Date
        '
        Me.dtTentativeDiagnosis1Date.EditValue = Nothing
        resources.ApplyResources(Me.dtTentativeDiagnosis1Date, "dtTentativeDiagnosis1Date")
        Me.dtTentativeDiagnosis1Date.Name = "dtTentativeDiagnosis1Date"
        Me.dtTentativeDiagnosis1Date.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtTentativeDiagnosis1Date.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtTentativeDiagnosis1Date.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        '
        'txtTentativeDiagnosis1OIECode
        '
        resources.ApplyResources(Me.txtTentativeDiagnosis1OIECode, "txtTentativeDiagnosis1OIECode")
        Me.txtTentativeDiagnosis1OIECode.Name = "txtTentativeDiagnosis1OIECode"
        Me.txtTentativeDiagnosis1OIECode.Properties.ReadOnly = True
        '
        'cbTentativeDiagnosis1
        '
        resources.ApplyResources(Me.cbTentativeDiagnosis1, "cbTentativeDiagnosis1")
        Me.cbTentativeDiagnosis1.Name = "cbTentativeDiagnosis1"
        Me.cbTentativeDiagnosis1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTentativeDiagnosis1.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        '
        'lbTentativeDiagnosis1
        '
        resources.ApplyResources(Me.lbTentativeDiagnosis1, "lbTentativeDiagnosis1")
        Me.lbTentativeDiagnosis1.Name = "lbTentativeDiagnosis1"
        '
        'VetDiagnosisPanel
        '
        Me.Controls.Add(Me.pnDiagnosis)
        Me.KeyFieldName = "idfCase"
        Me.Name = "VetDiagnosisPanel"
        Me.ObjectName = "VetCase"
        resources.ApplyResources(Me, "$this")
        Me.TableName = "VetCase"
        CType(Me.pnDiagnosis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnDiagnosis.ResumeLayout(False)
        CType(Me.dtFinalDiagnosisDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFinalDiagnosisDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFinalDiagnosisOIECode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbFinalDiagnosis.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtTentativeDiagnosis3Date.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtTentativeDiagnosis3Date.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTentativeDiagnosis3OIECode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTentativeDiagnosis3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtTentativeDiagnosis2Date.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtTentativeDiagnosis2Date.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTentativeDiagnosis2OIECode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTentativeDiagnosis2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtTentativeDiagnosis1Date.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtTentativeDiagnosis1Date.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTentativeDiagnosis1OIECode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTentativeDiagnosis1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnDiagnosis As DevExpress.XtraEditors.GroupControl

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        InitCustomMandatoryFields()
        VetDiagnosisDbService = New VetCase_DB
        DbService = VetDiagnosisDbService

    End Sub
    Friend WithEvents txtTentativeDiagnosis1OIECode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cbTentativeDiagnosis1 As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lbTentativeDiagnosis1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dtFinalDiagnosisDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtFinalDiagnosisOIECode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cbFinalDiagnosis As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lbFinalDiagnosis As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dtTentativeDiagnosis3Date As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtTentativeDiagnosis3OIECode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cbTentativeDiagnosis3 As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lbTentativeDiagnosis3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dtTentativeDiagnosis2Date As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtTentativeDiagnosis2OIECode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cbTentativeDiagnosis2 As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lbTentativeDiagnosis2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dtTentativeDiagnosis1Date As DevExpress.XtraEditors.DateEdit
End Class
