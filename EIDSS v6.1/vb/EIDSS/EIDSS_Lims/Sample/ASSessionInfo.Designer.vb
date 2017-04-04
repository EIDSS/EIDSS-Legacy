<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ASSessionInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ASSessionInfo))
        Me.lbCampaignName = New System.Windows.Forms.Label()
        Me.lbCampaignType = New System.Windows.Forms.Label()
        Me.lbCampaignID = New System.Windows.Forms.Label()
        Me.txtCampaignName = New DevExpress.XtraEditors.TextEdit()
        Me.txtCampaignType = New DevExpress.XtraEditors.TextEdit()
        Me.txtCampaignID = New DevExpress.XtraEditors.TextEdit()
        CType(Me.txtCampaignName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCampaignType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCampaignID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(ASSessionInfo), resources)
        'Form Is Localizable: True
        '
        'lbCampaignName
        '
        resources.ApplyResources(Me.lbCampaignName, "lbCampaignName")
        Me.lbCampaignName.Name = "lbCampaignName"
        '
        'lbCampaignType
        '
        resources.ApplyResources(Me.lbCampaignType, "lbCampaignType")
        Me.lbCampaignType.Name = "lbCampaignType"
        '
        'lbCampaignID
        '
        resources.ApplyResources(Me.lbCampaignID, "lbCampaignID")
        Me.lbCampaignID.Name = "lbCampaignID"
        '
        'txtCampaignName
        '
        resources.ApplyResources(Me.txtCampaignName, "txtCampaignName")
        Me.txtCampaignName.Name = "txtCampaignName"
        Me.txtCampaignName.Properties.AccessibleDescription = resources.GetString("txtCampaignName.Properties.AccessibleDescription")
        Me.txtCampaignName.Properties.AccessibleName = resources.GetString("txtCampaignName.Properties.AccessibleName")
        Me.txtCampaignName.Properties.Appearance.GradientMode = CType(resources.GetObject("txtCampaignName.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtCampaignName.Properties.Appearance.Image = CType(resources.GetObject("txtCampaignName.Properties.Appearance.Image"), System.Drawing.Image)
        Me.txtCampaignName.Properties.Appearance.Options.UseFont = True
        Me.txtCampaignName.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("txtCampaignName.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtCampaignName.Properties.AppearanceDisabled.Image = CType(resources.GetObject("txtCampaignName.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.txtCampaignName.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtCampaignName.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("txtCampaignName.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtCampaignName.Properties.AppearanceFocused.Image = CType(resources.GetObject("txtCampaignName.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.txtCampaignName.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtCampaignName.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("txtCampaignName.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtCampaignName.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("txtCampaignName.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.txtCampaignName.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtCampaignName.Properties.AutoHeight = CType(resources.GetObject("txtCampaignName.Properties.AutoHeight"), Boolean)
        Me.txtCampaignName.Properties.Mask.AutoComplete = CType(resources.GetObject("txtCampaignName.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtCampaignName.Properties.Mask.BeepOnError = CType(resources.GetObject("txtCampaignName.Properties.Mask.BeepOnError"), Boolean)
        Me.txtCampaignName.Properties.Mask.EditMask = resources.GetString("txtCampaignName.Properties.Mask.EditMask")
        Me.txtCampaignName.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtCampaignName.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtCampaignName.Properties.Mask.MaskType = CType(resources.GetObject("txtCampaignName.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtCampaignName.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtCampaignName.Properties.Mask.PlaceHolder"), Char)
        Me.txtCampaignName.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtCampaignName.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtCampaignName.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtCampaignName.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtCampaignName.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtCampaignName.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtCampaignName.Properties.NullValuePrompt = resources.GetString("txtCampaignName.Properties.NullValuePrompt")
        Me.txtCampaignName.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtCampaignName.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.txtCampaignName.Tag = "{R}"
        '
        'txtCampaignType
        '
        resources.ApplyResources(Me.txtCampaignType, "txtCampaignType")
        Me.txtCampaignType.Name = "txtCampaignType"
        Me.txtCampaignType.Properties.AccessibleDescription = resources.GetString("txtCampaignType.Properties.AccessibleDescription")
        Me.txtCampaignType.Properties.AccessibleName = resources.GetString("txtCampaignType.Properties.AccessibleName")
        Me.txtCampaignType.Properties.Appearance.GradientMode = CType(resources.GetObject("txtCampaignType.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtCampaignType.Properties.Appearance.Image = CType(resources.GetObject("txtCampaignType.Properties.Appearance.Image"), System.Drawing.Image)
        Me.txtCampaignType.Properties.Appearance.Options.UseFont = True
        Me.txtCampaignType.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("txtCampaignType.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtCampaignType.Properties.AppearanceDisabled.Image = CType(resources.GetObject("txtCampaignType.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.txtCampaignType.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtCampaignType.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("txtCampaignType.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtCampaignType.Properties.AppearanceFocused.Image = CType(resources.GetObject("txtCampaignType.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.txtCampaignType.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtCampaignType.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("txtCampaignType.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtCampaignType.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("txtCampaignType.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.txtCampaignType.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtCampaignType.Properties.AutoHeight = CType(resources.GetObject("txtCampaignType.Properties.AutoHeight"), Boolean)
        Me.txtCampaignType.Properties.Mask.AutoComplete = CType(resources.GetObject("txtCampaignType.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtCampaignType.Properties.Mask.BeepOnError = CType(resources.GetObject("txtCampaignType.Properties.Mask.BeepOnError"), Boolean)
        Me.txtCampaignType.Properties.Mask.EditMask = resources.GetString("txtCampaignType.Properties.Mask.EditMask")
        Me.txtCampaignType.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtCampaignType.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtCampaignType.Properties.Mask.MaskType = CType(resources.GetObject("txtCampaignType.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtCampaignType.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtCampaignType.Properties.Mask.PlaceHolder"), Char)
        Me.txtCampaignType.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtCampaignType.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtCampaignType.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtCampaignType.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtCampaignType.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtCampaignType.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtCampaignType.Properties.NullValuePrompt = resources.GetString("txtCampaignType.Properties.NullValuePrompt")
        Me.txtCampaignType.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtCampaignType.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.txtCampaignType.Tag = "{R}"
        '
        'txtCampaignID
        '
        resources.ApplyResources(Me.txtCampaignID, "txtCampaignID")
        Me.txtCampaignID.Name = "txtCampaignID"
        Me.txtCampaignID.Properties.AccessibleDescription = resources.GetString("txtCampaignID.Properties.AccessibleDescription")
        Me.txtCampaignID.Properties.AccessibleName = resources.GetString("txtCampaignID.Properties.AccessibleName")
        Me.txtCampaignID.Properties.Appearance.GradientMode = CType(resources.GetObject("txtCampaignID.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtCampaignID.Properties.Appearance.Image = CType(resources.GetObject("txtCampaignID.Properties.Appearance.Image"), System.Drawing.Image)
        Me.txtCampaignID.Properties.Appearance.Options.UseFont = True
        Me.txtCampaignID.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("txtCampaignID.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtCampaignID.Properties.AppearanceDisabled.Image = CType(resources.GetObject("txtCampaignID.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.txtCampaignID.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtCampaignID.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("txtCampaignID.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtCampaignID.Properties.AppearanceFocused.Image = CType(resources.GetObject("txtCampaignID.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.txtCampaignID.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtCampaignID.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("txtCampaignID.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtCampaignID.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("txtCampaignID.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.txtCampaignID.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtCampaignID.Properties.AutoHeight = CType(resources.GetObject("txtCampaignID.Properties.AutoHeight"), Boolean)
        Me.txtCampaignID.Properties.Mask.AutoComplete = CType(resources.GetObject("txtCampaignID.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtCampaignID.Properties.Mask.BeepOnError = CType(resources.GetObject("txtCampaignID.Properties.Mask.BeepOnError"), Boolean)
        Me.txtCampaignID.Properties.Mask.EditMask = resources.GetString("txtCampaignID.Properties.Mask.EditMask")
        Me.txtCampaignID.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtCampaignID.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtCampaignID.Properties.Mask.MaskType = CType(resources.GetObject("txtCampaignID.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtCampaignID.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtCampaignID.Properties.Mask.PlaceHolder"), Char)
        Me.txtCampaignID.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtCampaignID.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtCampaignID.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtCampaignID.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtCampaignID.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtCampaignID.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtCampaignID.Properties.NullValuePrompt = resources.GetString("txtCampaignID.Properties.NullValuePrompt")
        Me.txtCampaignID.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtCampaignID.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.txtCampaignID.Tag = "{R}"
        '
        'ASSessionInfo
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtCampaignID)
        Me.Controls.Add(Me.txtCampaignType)
        Me.Controls.Add(Me.txtCampaignName)
        Me.Controls.Add(Me.lbCampaignID)
        Me.Controls.Add(Me.lbCampaignType)
        Me.Controls.Add(Me.lbCampaignName)
        Me.Name = "ASSessionInfo"
        CType(Me.txtCampaignName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCampaignType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCampaignID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbCampaignName As System.Windows.Forms.Label
    Friend WithEvents lbCampaignType As System.Windows.Forms.Label
    Friend WithEvents lbCampaignID As System.Windows.Forms.Label
    Friend WithEvents txtCampaignName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCampaignType As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCampaignID As DevExpress.XtraEditors.TextEdit
End Class
