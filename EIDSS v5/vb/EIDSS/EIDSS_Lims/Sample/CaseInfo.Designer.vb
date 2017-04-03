<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CaseInfo
    Inherits BaseDetailPanel

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CaseInfo))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.txtFieldID = New DevExpress.XtraEditors.TextEdit()
        Me.lbLocalID = New System.Windows.Forms.Label()
        Me.txtCaseID = New DevExpress.XtraEditors.ButtonEdit()
        Me.lbCaseID = New System.Windows.Forms.Label()
        Me.HumanCaseInfo = New EIDSS.HumanCaseInfo()
        Me.VetCaseInfo = New EIDSS.VetCaseInfo()
        CType(Me.txtFieldID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCaseID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtFieldID
        '
        resources.ApplyResources(Me.txtFieldID, "txtFieldID")
        Me.txtFieldID.Name = "txtFieldID"
        Me.txtFieldID.Properties.Appearance.Options.UseFont = True
        Me.txtFieldID.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtFieldID.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtFieldID.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtFieldID.Properties.AutoHeight = CType(resources.GetObject("txtFieldID.Properties.AutoHeight"), Boolean)
        Me.txtFieldID.Properties.Mask.EditMask = resources.GetString("txtFieldID.Properties.Mask.EditMask")
        Me.txtFieldID.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtFieldID.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtFieldID.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtFieldID.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtFieldID.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtFieldID.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtFieldID.Tag = "{R}"
        '
        'lbLocalID
        '
        resources.ApplyResources(Me.lbLocalID, "lbLocalID")
        Me.lbLocalID.Name = "lbLocalID"
        '
        'txtCaseID
        '
        resources.ApplyResources(Me.txtCaseID, "txtCaseID")
        Me.txtCaseID.Name = "txtCaseID"
        Me.txtCaseID.Properties.AutoHeight = CType(resources.GetObject("txtCaseID.Properties.AutoHeight"), Boolean)
        Me.txtCaseID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtCaseID.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtCaseID.Properties.Buttons1"), CType(resources.GetObject("txtCaseID.Properties.Buttons2"), Integer), CType(resources.GetObject("txtCaseID.Properties.Buttons3"), Boolean), CType(resources.GetObject("txtCaseID.Properties.Buttons4"), Boolean), CType(resources.GetObject("txtCaseID.Properties.Buttons5"), Boolean), CType(resources.GetObject("txtCaseID.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), Global.EIDSS.My.Resources.Resources.Browse5, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, resources.GetString("txtCaseID.Properties.Buttons7"), CType(resources.GetObject("txtCaseID.Properties.Buttons8"), Object), CType(resources.GetObject("txtCaseID.Properties.Buttons9"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtCaseID.Properties.Buttons10"), Boolean)), New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtCaseID.Properties.Mask.EditMask = resources.GetString("txtCaseID.Properties.Mask.EditMask")
        Me.txtCaseID.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtCaseID.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtCaseID.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtCaseID.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtCaseID.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtCaseID.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtCaseID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'lbCaseID
        '
        resources.ApplyResources(Me.lbCaseID, "lbCaseID")
        Me.lbCaseID.Name = "lbCaseID"
        '
        'HumanCaseInfo
        '
        resources.ApplyResources(Me.HumanCaseInfo, "HumanCaseInfo")
        Me.HumanCaseInfo.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.HumanCaseInfo.FormID = Nothing
        Me.HumanCaseInfo.HelpTopicID = Nothing
        Me.HumanCaseInfo.IsStatusReadOnly = False
        Me.HumanCaseInfo.KeyFieldName = Nothing
        Me.HumanCaseInfo.MultiSelect = False
        Me.HumanCaseInfo.Name = "HumanCaseInfo"
        Me.HumanCaseInfo.ObjectName = Nothing
        Me.HumanCaseInfo.Status = bv.common.win.FormStatus.Draft
        Me.HumanCaseInfo.TableName = Nothing
        Me.HumanCaseInfo.UseParentDataset = True
        '
        'VetCaseInfo
        '
        resources.ApplyResources(Me.VetCaseInfo, "VetCaseInfo")
        Me.VetCaseInfo.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.VetCaseInfo.FormID = Nothing
        Me.VetCaseInfo.HelpTopicID = Nothing
        Me.VetCaseInfo.IsStatusReadOnly = False
        Me.VetCaseInfo.KeyFieldName = Nothing
        Me.VetCaseInfo.MultiSelect = False
        Me.VetCaseInfo.Name = "VetCaseInfo"
        Me.VetCaseInfo.ObjectName = Nothing
        Me.VetCaseInfo.Status = bv.common.win.FormStatus.Draft
        Me.VetCaseInfo.TableName = Nothing
        Me.VetCaseInfo.UseParentDataset = True
        '
        'CaseInfo
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtFieldID)
        Me.Controls.Add(Me.lbLocalID)
        Me.Controls.Add(Me.txtCaseID)
        Me.Controls.Add(Me.lbCaseID)
        Me.Controls.Add(Me.HumanCaseInfo)
        Me.Controls.Add(Me.VetCaseInfo)
        Me.Name = "CaseInfo"
        CType(Me.txtFieldID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCaseID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtFieldID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbLocalID As System.Windows.Forms.Label
    Friend WithEvents txtCaseID As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents lbCaseID As System.Windows.Forms.Label
    Private WithEvents VetCaseInfo As EIDSS.VetCaseInfo
    Private WithEvents HumanCaseInfo As EIDSS.HumanCaseInfo
End Class
