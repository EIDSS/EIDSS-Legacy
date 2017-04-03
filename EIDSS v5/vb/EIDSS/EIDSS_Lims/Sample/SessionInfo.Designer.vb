<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SessionInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SessionInfo))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.lbSessionID = New System.Windows.Forms.Label()
        Me.txtCaseID = New DevExpress.XtraEditors.ButtonEdit()
        Me.txtSessionStatus = New DevExpress.XtraEditors.TextEdit()
        Me.lbSessionStatus = New System.Windows.Forms.Label()
        Me.ASSessionInfo = New EIDSS.ASSessionInfo()
        Me.VSSessionInfo = New EIDSS.VSSessionInfo()
        CType(Me.txtCaseID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSessionStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbSessionID
        '
        resources.ApplyResources(Me.lbSessionID, "lbSessionID")
        Me.lbSessionID.Name = "lbSessionID"
        '
        'txtCaseID
        '
        resources.ApplyResources(Me.txtCaseID, "txtCaseID")
        Me.txtCaseID.Name = "txtCaseID"
        Me.txtCaseID.Properties.AutoHeight = CType(resources.GetObject("txtCaseID.Properties.AutoHeight"), Boolean)
        Me.txtCaseID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtCaseID.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtCaseID.Properties.Buttons1"), CType(resources.GetObject("txtCaseID.Properties.Buttons2"), Integer), CType(resources.GetObject("txtCaseID.Properties.Buttons3"), Boolean), CType(resources.GetObject("txtCaseID.Properties.Buttons4"), Boolean), CType(resources.GetObject("txtCaseID.Properties.Buttons5"), Boolean), CType(resources.GetObject("txtCaseID.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), Global.eidss.My.Resources.Resources.Browse5, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, resources.GetString("txtCaseID.Properties.Buttons7"), CType(resources.GetObject("txtCaseID.Properties.Buttons8"), Object), CType(resources.GetObject("txtCaseID.Properties.Buttons9"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtCaseID.Properties.Buttons10"), Boolean)), New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtCaseID.Properties.Mask.EditMask = resources.GetString("txtCaseID.Properties.Mask.EditMask")
        Me.txtCaseID.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtCaseID.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtCaseID.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtCaseID.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtCaseID.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtCaseID.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtCaseID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'txtSessionStatus
        '
        resources.ApplyResources(Me.txtSessionStatus, "txtSessionStatus")
        Me.txtSessionStatus.Name = "txtSessionStatus"
        Me.txtSessionStatus.Properties.Appearance.Options.UseFont = True
        Me.txtSessionStatus.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtSessionStatus.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtSessionStatus.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtSessionStatus.Properties.AutoHeight = CType(resources.GetObject("txtSessionStatus.Properties.AutoHeight"), Boolean)
        Me.txtSessionStatus.Properties.Mask.EditMask = resources.GetString("txtSessionStatus.Properties.Mask.EditMask")
        Me.txtSessionStatus.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtSessionStatus.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtSessionStatus.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtSessionStatus.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtSessionStatus.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtSessionStatus.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtSessionStatus.Tag = "{R}"
        '
        'lbSessionStatus
        '
        resources.ApplyResources(Me.lbSessionStatus, "lbSessionStatus")
        Me.lbSessionStatus.Name = "lbSessionStatus"
        '
        'ASSessionInfo
        '
        resources.ApplyResources(Me.ASSessionInfo, "ASSessionInfo")
        Me.ASSessionInfo.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.ASSessionInfo.FormID = Nothing
        Me.ASSessionInfo.HelpTopicID = Nothing
        Me.ASSessionInfo.IsStatusReadOnly = False
        Me.ASSessionInfo.KeyFieldName = Nothing
        Me.ASSessionInfo.MultiSelect = False
        Me.ASSessionInfo.Name = "ASSessionInfo"
        Me.ASSessionInfo.ObjectName = Nothing
        Me.ASSessionInfo.Status = bv.common.win.FormStatus.Draft
        Me.ASSessionInfo.TableName = Nothing
        Me.ASSessionInfo.UseParentDataset = True
        '
        'VSSessionInfo
        '
        resources.ApplyResources(Me.VSSessionInfo, "VSSessionInfo")
        Me.VSSessionInfo.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.VSSessionInfo.FormID = Nothing
        Me.VSSessionInfo.HelpTopicID = Nothing
        Me.VSSessionInfo.IsStatusReadOnly = False
        Me.VSSessionInfo.KeyFieldName = Nothing
        Me.VSSessionInfo.MultiSelect = False
        Me.VSSessionInfo.Name = "VSSessionInfo"
        Me.VSSessionInfo.ObjectName = Nothing
        Me.VSSessionInfo.Status = bv.common.win.FormStatus.Draft
        Me.VSSessionInfo.TableName = Nothing
        Me.VSSessionInfo.UseParentDataset = True
        '
        'SessionInfo
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtSessionStatus)
        Me.Controls.Add(Me.lbSessionStatus)
        Me.Controls.Add(Me.txtCaseID)
        Me.Controls.Add(Me.lbSessionID)
        Me.Controls.Add(Me.ASSessionInfo)
        Me.Controls.Add(Me.VSSessionInfo)
        Me.Name = "SessionInfo"
        CType(Me.txtCaseID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSessionStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbSessionID As System.Windows.Forms.Label
    Private WithEvents VSSessionInfo As EIDSS.VSSessionInfo
    Private WithEvents ASSessionInfo As EIDSS.ASSessionInfo
    Friend WithEvents txtCaseID As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents txtSessionStatus As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbSessionStatus As System.Windows.Forms.Label
End Class
