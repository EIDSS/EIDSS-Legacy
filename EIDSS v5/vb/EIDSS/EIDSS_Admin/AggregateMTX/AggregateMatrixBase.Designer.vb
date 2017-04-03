<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AggregateMatrixBase
    Inherits bv.common.win.BaseDetailList

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AggregateMatrixBase))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.btnDown = New DevExpress.XtraEditors.SimpleButton()
        Me.btnUp = New DevExpress.XtraEditors.SimpleButton()
        Me.btnActivateVersion = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNewVersion = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDeleteVersion = New DevExpress.XtraEditors.SimpleButton()
        Me.cbSelectVersion = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.lbSelectVersion = New DevExpress.XtraEditors.LabelControl()
        Me.dtVersionDate = New DevExpress.XtraEditors.DateEdit()
        Me.lbVersionDate = New DevExpress.XtraEditors.LabelControl()
        Me.txtVersionName = New DevExpress.XtraEditors.TextEdit()
        Me.lbVersionName = New DevExpress.XtraEditors.LabelControl()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.pnMatrixVersion = New DevExpress.XtraEditors.GroupControl()
        CType(Me.cbSelectVersion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtVersionDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtVersionDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVersionName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnMatrixVersion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnMatrixVersion.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnDown
        '
        Me.btnDown.Appearance.Options.UseFont = True
        Me.btnDown.Image = Global.eidss.My.Resources.Resources.doun
        resources.ApplyResources(Me.btnDown, "btnDown")
        Me.btnDown.Name = "btnDown"
        '
        'btnUp
        '
        Me.btnUp.Appearance.Options.UseFont = True
        Me.btnUp.Image = Global.eidss.My.Resources.Resources.up
        resources.ApplyResources(Me.btnUp, "btnUp")
        Me.btnUp.Name = "btnUp"
        '
        'btnActivateVersion
        '
        resources.ApplyResources(Me.btnActivateVersion, "btnActivateVersion")
        Me.btnActivateVersion.Appearance.Options.UseFont = True
        Me.btnActivateVersion.Name = "btnActivateVersion"
        '
        'btnNewVersion
        '
        resources.ApplyResources(Me.btnNewVersion, "btnNewVersion")
        Me.btnNewVersion.Appearance.Options.UseFont = True
        Me.btnNewVersion.Image = Global.eidss.My.Resources.Resources.add
        Me.btnNewVersion.Name = "btnNewVersion"
        '
        'btnDeleteVersion
        '
        resources.ApplyResources(Me.btnDeleteVersion, "btnDeleteVersion")
        Me.btnDeleteVersion.Appearance.Options.UseFont = True
        Me.btnDeleteVersion.Image = Global.eidss.My.Resources.Resources.Delete_Remove
        Me.btnDeleteVersion.Name = "btnDeleteVersion"
        '
        'cbSelectVersion
        '
        resources.ApplyResources(Me.cbSelectVersion, "cbSelectVersion")
        Me.cbSelectVersion.Name = "cbSelectVersion"
        Me.cbSelectVersion.Properties.Appearance.Options.UseFont = True
        Me.cbSelectVersion.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbSelectVersion.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbSelectVersion.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbSelectVersion.Properties.AppearanceReadOnly.Options.UseFont = True
        SerializableAppearanceObject1.Options.UseFont = True
        Me.cbSelectVersion.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSelectVersion.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbSelectVersion.Properties.Buttons1"), CType(resources.GetObject("cbSelectVersion.Properties.Buttons2"), Integer), CType(resources.GetObject("cbSelectVersion.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbSelectVersion.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbSelectVersion.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbSelectVersion.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbSelectVersion.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, resources.GetString("cbSelectVersion.Properties.Buttons8"), CType(resources.GetObject("cbSelectVersion.Properties.Buttons9"), Object), CType(resources.GetObject("cbSelectVersion.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbSelectVersion.Properties.Buttons11"), Boolean))})
        '
        'lbSelectVersion
        '
        Me.lbSelectVersion.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lbSelectVersion.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbSelectVersion.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        resources.ApplyResources(Me.lbSelectVersion, "lbSelectVersion")
        Me.lbSelectVersion.Name = "lbSelectVersion"
        '
        'dtVersionDate
        '
        resources.ApplyResources(Me.dtVersionDate, "dtVersionDate")
        Me.dtVersionDate.Name = "dtVersionDate"
        Me.dtVersionDate.Properties.Appearance.Options.UseFont = True
        Me.dtVersionDate.Properties.AppearanceDisabled.Options.UseFont = True
        Me.dtVersionDate.Properties.AppearanceDropDown.Options.UseFont = True
        Me.dtVersionDate.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.dtVersionDate.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = True
        Me.dtVersionDate.Properties.AppearanceDropDownHighlight.Options.UseFont = True
        Me.dtVersionDate.Properties.AppearanceFocused.Options.UseFont = True
        Me.dtVersionDate.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.dtVersionDate.Properties.AppearanceWeekNumber.Options.UseFont = True
        SerializableAppearanceObject2.Options.UseFont = True
        Me.dtVersionDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtVersionDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("dtVersionDate.Properties.Buttons1"), CType(resources.GetObject("dtVersionDate.Properties.Buttons2"), Integer), CType(resources.GetObject("dtVersionDate.Properties.Buttons3"), Boolean), CType(resources.GetObject("dtVersionDate.Properties.Buttons4"), Boolean), CType(resources.GetObject("dtVersionDate.Properties.Buttons5"), Boolean), CType(resources.GetObject("dtVersionDate.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("dtVersionDate.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, resources.GetString("dtVersionDate.Properties.Buttons8"), CType(resources.GetObject("dtVersionDate.Properties.Buttons9"), Object), CType(resources.GetObject("dtVersionDate.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("dtVersionDate.Properties.Buttons11"), Boolean))})
        Me.dtVersionDate.Properties.VistaTimeProperties.Appearance.Options.UseFont = True
        Me.dtVersionDate.Properties.VistaTimeProperties.AppearanceDisabled.Options.UseFont = True
        Me.dtVersionDate.Properties.VistaTimeProperties.AppearanceFocused.Options.UseFont = True
        Me.dtVersionDate.Properties.VistaTimeProperties.AppearanceReadOnly.Options.UseFont = True
        SerializableAppearanceObject3.Options.UseFont = True
        Me.dtVersionDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtVersionDate.Properties.VistaTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("dtVersionDate.Properties.VistaTimeProperties.Buttons1"), CType(resources.GetObject("dtVersionDate.Properties.VistaTimeProperties.Buttons2"), Integer), CType(resources.GetObject("dtVersionDate.Properties.VistaTimeProperties.Buttons3"), Boolean), CType(resources.GetObject("dtVersionDate.Properties.VistaTimeProperties.Buttons4"), Boolean), CType(resources.GetObject("dtVersionDate.Properties.VistaTimeProperties.Buttons5"), Boolean), CType(resources.GetObject("dtVersionDate.Properties.VistaTimeProperties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("dtVersionDate.Properties.VistaTimeProperties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject3, resources.GetString("dtVersionDate.Properties.VistaTimeProperties.Buttons8"), CType(resources.GetObject("dtVersionDate.Properties.VistaTimeProperties.Buttons9"), Object), CType(resources.GetObject("dtVersionDate.Properties.VistaTimeProperties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("dtVersionDate.Properties.VistaTimeProperties.Buttons11"), Boolean))})
        '
        'lbVersionDate
        '
        Me.lbVersionDate.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lbVersionDate.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbVersionDate.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        resources.ApplyResources(Me.lbVersionDate, "lbVersionDate")
        Me.lbVersionDate.Name = "lbVersionDate"
        '
        'txtVersionName
        '
        resources.ApplyResources(Me.txtVersionName, "txtVersionName")
        Me.txtVersionName.Name = "txtVersionName"
        Me.txtVersionName.Properties.Appearance.Options.UseFont = True
        Me.txtVersionName.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtVersionName.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtVersionName.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtVersionName.Tag = "{M}"
        '
        'lbVersionName
        '
        Me.lbVersionName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lbVersionName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lbVersionName.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        resources.ApplyResources(Me.lbVersionName, "lbVersionName")
        Me.lbVersionName.Name = "lbVersionName"
        '
        'btnDelete
        '
        Me.btnDelete.Appearance.Options.UseFont = True
        Me.btnDelete.Image = Global.eidss.My.Resources.Resources.Delete_Remove
        resources.ApplyResources(Me.btnDelete, "btnDelete")
        Me.btnDelete.Name = "btnDelete"
        '
        'pnMatrixVersion
        '
        resources.ApplyResources(Me.pnMatrixVersion, "pnMatrixVersion")
        Me.pnMatrixVersion.Appearance.Options.UseFont = True
        Me.pnMatrixVersion.AppearanceCaption.Options.UseFont = True
        Me.pnMatrixVersion.Controls.Add(Me.dtVersionDate)
        Me.pnMatrixVersion.Controls.Add(Me.txtVersionName)
        Me.pnMatrixVersion.Controls.Add(Me.lbVersionDate)
        Me.pnMatrixVersion.Controls.Add(Me.btnActivateVersion)
        Me.pnMatrixVersion.Controls.Add(Me.btnNewVersion)
        Me.pnMatrixVersion.Controls.Add(Me.btnDeleteVersion)
        Me.pnMatrixVersion.Controls.Add(Me.cbSelectVersion)
        Me.pnMatrixVersion.Controls.Add(Me.lbSelectVersion)
        Me.pnMatrixVersion.Controls.Add(Me.lbVersionName)
        Me.pnMatrixVersion.Name = "pnMatrixVersion"
        '
        'AggregateMatrixBase
        '
        Me.Appearance.Options.UseFont = True
        Me.Controls.Add(Me.pnMatrixVersion)
        Me.Controls.Add(Me.btnUp)
        Me.Controls.Add(Me.btnDown)
        Me.Controls.Add(Me.btnDelete)
        Me.Name = "AggregateMatrixBase"
        Me.SingleInstance = True
        resources.ApplyResources(Me, "$this")
        Me.TableName = "AggregateMatrix"
        Me.Controls.SetChildIndex(Me.cmdOk, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.btnDown, 0)
        Me.Controls.SetChildIndex(Me.btnUp, 0)
        Me.Controls.SetChildIndex(Me.pnMatrixVersion, 0)
        CType(Me.cbSelectVersion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtVersionDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtVersionDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVersionName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnMatrixVersion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnMatrixVersion.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnDown As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnUp As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnActivateVersion As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnNewVersion As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDeleteVersion As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbSelectVersion As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents lbSelectVersion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dtVersionDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lbVersionDate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtVersionName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbVersionName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pnMatrixVersion As DevExpress.XtraEditors.GroupControl

End Class
