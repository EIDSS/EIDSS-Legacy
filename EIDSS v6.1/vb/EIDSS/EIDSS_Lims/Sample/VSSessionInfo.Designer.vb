<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VSSessionInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VSSessionInfo))
        Me.lbRegion = New System.Windows.Forms.Label()
        Me.lbRayon = New System.Windows.Forms.Label()
        Me.lbSettlement = New System.Windows.Forms.Label()
        Me.txtRegion = New DevExpress.XtraEditors.TextEdit()
        Me.txtRayon = New DevExpress.XtraEditors.TextEdit()
        Me.txtSettlement = New DevExpress.XtraEditors.TextEdit()
        CType(Me.txtRegion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRayon.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSettlement.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(VSSessionInfo), resources)
        'Form Is Localizable: True
        '
        'lbRegion
        '
        resources.ApplyResources(Me.lbRegion, "lbRegion")
        Me.lbRegion.Name = "lbRegion"
        '
        'lbRayon
        '
        resources.ApplyResources(Me.lbRayon, "lbRayon")
        Me.lbRayon.Name = "lbRayon"
        '
        'lbSettlement
        '
        resources.ApplyResources(Me.lbSettlement, "lbSettlement")
        Me.lbSettlement.Name = "lbSettlement"
        '
        'txtRegion
        '
        resources.ApplyResources(Me.txtRegion, "txtRegion")
        Me.txtRegion.Name = "txtRegion"
        Me.txtRegion.Properties.AccessibleDescription = resources.GetString("txtRegion.Properties.AccessibleDescription")
        Me.txtRegion.Properties.AccessibleName = resources.GetString("txtRegion.Properties.AccessibleName")
        Me.txtRegion.Properties.Appearance.FontSizeDelta = CType(resources.GetObject("txtRegion.Properties.Appearance.FontSizeDelta"), Integer)
        Me.txtRegion.Properties.Appearance.FontStyleDelta = CType(resources.GetObject("txtRegion.Properties.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtRegion.Properties.Appearance.GradientMode = CType(resources.GetObject("txtRegion.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtRegion.Properties.Appearance.Image = CType(resources.GetObject("txtRegion.Properties.Appearance.Image"), System.Drawing.Image)
        Me.txtRegion.Properties.Appearance.Options.UseFont = True
        Me.txtRegion.Properties.AppearanceDisabled.FontSizeDelta = CType(resources.GetObject("txtRegion.Properties.AppearanceDisabled.FontSizeDelta"), Integer)
        Me.txtRegion.Properties.AppearanceDisabled.FontStyleDelta = CType(resources.GetObject("txtRegion.Properties.AppearanceDisabled.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtRegion.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("txtRegion.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtRegion.Properties.AppearanceDisabled.Image = CType(resources.GetObject("txtRegion.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.txtRegion.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtRegion.Properties.AppearanceFocused.FontSizeDelta = CType(resources.GetObject("txtRegion.Properties.AppearanceFocused.FontSizeDelta"), Integer)
        Me.txtRegion.Properties.AppearanceFocused.FontStyleDelta = CType(resources.GetObject("txtRegion.Properties.AppearanceFocused.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtRegion.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("txtRegion.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtRegion.Properties.AppearanceFocused.Image = CType(resources.GetObject("txtRegion.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.txtRegion.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtRegion.Properties.AppearanceReadOnly.FontSizeDelta = CType(resources.GetObject("txtRegion.Properties.AppearanceReadOnly.FontSizeDelta"), Integer)
        Me.txtRegion.Properties.AppearanceReadOnly.FontStyleDelta = CType(resources.GetObject("txtRegion.Properties.AppearanceReadOnly.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtRegion.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("txtRegion.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtRegion.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("txtRegion.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.txtRegion.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtRegion.Properties.AutoHeight = CType(resources.GetObject("txtRegion.Properties.AutoHeight"), Boolean)
        Me.txtRegion.Properties.Mask.AutoComplete = CType(resources.GetObject("txtRegion.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtRegion.Properties.Mask.BeepOnError = CType(resources.GetObject("txtRegion.Properties.Mask.BeepOnError"), Boolean)
        Me.txtRegion.Properties.Mask.EditMask = resources.GetString("txtRegion.Properties.Mask.EditMask")
        Me.txtRegion.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtRegion.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtRegion.Properties.Mask.MaskType = CType(resources.GetObject("txtRegion.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtRegion.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtRegion.Properties.Mask.PlaceHolder"), Char)
        Me.txtRegion.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtRegion.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtRegion.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtRegion.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtRegion.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtRegion.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtRegion.Properties.NullValuePrompt = resources.GetString("txtRegion.Properties.NullValuePrompt")
        Me.txtRegion.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtRegion.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.txtRegion.Tag = "{R}"
        '
        'txtRayon
        '
        resources.ApplyResources(Me.txtRayon, "txtRayon")
        Me.txtRayon.Name = "txtRayon"
        Me.txtRayon.Properties.AccessibleDescription = resources.GetString("txtRayon.Properties.AccessibleDescription")
        Me.txtRayon.Properties.AccessibleName = resources.GetString("txtRayon.Properties.AccessibleName")
        Me.txtRayon.Properties.Appearance.FontSizeDelta = CType(resources.GetObject("txtRayon.Properties.Appearance.FontSizeDelta"), Integer)
        Me.txtRayon.Properties.Appearance.FontStyleDelta = CType(resources.GetObject("txtRayon.Properties.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtRayon.Properties.Appearance.GradientMode = CType(resources.GetObject("txtRayon.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtRayon.Properties.Appearance.Image = CType(resources.GetObject("txtRayon.Properties.Appearance.Image"), System.Drawing.Image)
        Me.txtRayon.Properties.Appearance.Options.UseFont = True
        Me.txtRayon.Properties.AppearanceDisabled.FontSizeDelta = CType(resources.GetObject("txtRayon.Properties.AppearanceDisabled.FontSizeDelta"), Integer)
        Me.txtRayon.Properties.AppearanceDisabled.FontStyleDelta = CType(resources.GetObject("txtRayon.Properties.AppearanceDisabled.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtRayon.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("txtRayon.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtRayon.Properties.AppearanceDisabled.Image = CType(resources.GetObject("txtRayon.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.txtRayon.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtRayon.Properties.AppearanceFocused.FontSizeDelta = CType(resources.GetObject("txtRayon.Properties.AppearanceFocused.FontSizeDelta"), Integer)
        Me.txtRayon.Properties.AppearanceFocused.FontStyleDelta = CType(resources.GetObject("txtRayon.Properties.AppearanceFocused.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtRayon.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("txtRayon.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtRayon.Properties.AppearanceFocused.Image = CType(resources.GetObject("txtRayon.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.txtRayon.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtRayon.Properties.AppearanceReadOnly.FontSizeDelta = CType(resources.GetObject("txtRayon.Properties.AppearanceReadOnly.FontSizeDelta"), Integer)
        Me.txtRayon.Properties.AppearanceReadOnly.FontStyleDelta = CType(resources.GetObject("txtRayon.Properties.AppearanceReadOnly.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtRayon.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("txtRayon.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtRayon.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("txtRayon.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.txtRayon.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtRayon.Properties.AutoHeight = CType(resources.GetObject("txtRayon.Properties.AutoHeight"), Boolean)
        Me.txtRayon.Properties.Mask.AutoComplete = CType(resources.GetObject("txtRayon.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtRayon.Properties.Mask.BeepOnError = CType(resources.GetObject("txtRayon.Properties.Mask.BeepOnError"), Boolean)
        Me.txtRayon.Properties.Mask.EditMask = resources.GetString("txtRayon.Properties.Mask.EditMask")
        Me.txtRayon.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtRayon.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtRayon.Properties.Mask.MaskType = CType(resources.GetObject("txtRayon.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtRayon.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtRayon.Properties.Mask.PlaceHolder"), Char)
        Me.txtRayon.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtRayon.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtRayon.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtRayon.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtRayon.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtRayon.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtRayon.Properties.NullValuePrompt = resources.GetString("txtRayon.Properties.NullValuePrompt")
        Me.txtRayon.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtRayon.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.txtRayon.Tag = "{R}"
        '
        'txtSettlement
        '
        resources.ApplyResources(Me.txtSettlement, "txtSettlement")
        Me.txtSettlement.Name = "txtSettlement"
        Me.txtSettlement.Properties.AccessibleDescription = resources.GetString("txtSettlement.Properties.AccessibleDescription")
        Me.txtSettlement.Properties.AccessibleName = resources.GetString("txtSettlement.Properties.AccessibleName")
        Me.txtSettlement.Properties.Appearance.FontSizeDelta = CType(resources.GetObject("txtSettlement.Properties.Appearance.FontSizeDelta"), Integer)
        Me.txtSettlement.Properties.Appearance.FontStyleDelta = CType(resources.GetObject("txtSettlement.Properties.Appearance.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtSettlement.Properties.Appearance.GradientMode = CType(resources.GetObject("txtSettlement.Properties.Appearance.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtSettlement.Properties.Appearance.Image = CType(resources.GetObject("txtSettlement.Properties.Appearance.Image"), System.Drawing.Image)
        Me.txtSettlement.Properties.Appearance.Options.UseFont = True
        Me.txtSettlement.Properties.AppearanceDisabled.FontSizeDelta = CType(resources.GetObject("txtSettlement.Properties.AppearanceDisabled.FontSizeDelta"), Integer)
        Me.txtSettlement.Properties.AppearanceDisabled.FontStyleDelta = CType(resources.GetObject("txtSettlement.Properties.AppearanceDisabled.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtSettlement.Properties.AppearanceDisabled.GradientMode = CType(resources.GetObject("txtSettlement.Properties.AppearanceDisabled.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtSettlement.Properties.AppearanceDisabled.Image = CType(resources.GetObject("txtSettlement.Properties.AppearanceDisabled.Image"), System.Drawing.Image)
        Me.txtSettlement.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtSettlement.Properties.AppearanceFocused.FontSizeDelta = CType(resources.GetObject("txtSettlement.Properties.AppearanceFocused.FontSizeDelta"), Integer)
        Me.txtSettlement.Properties.AppearanceFocused.FontStyleDelta = CType(resources.GetObject("txtSettlement.Properties.AppearanceFocused.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtSettlement.Properties.AppearanceFocused.GradientMode = CType(resources.GetObject("txtSettlement.Properties.AppearanceFocused.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtSettlement.Properties.AppearanceFocused.Image = CType(resources.GetObject("txtSettlement.Properties.AppearanceFocused.Image"), System.Drawing.Image)
        Me.txtSettlement.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtSettlement.Properties.AppearanceReadOnly.FontSizeDelta = CType(resources.GetObject("txtSettlement.Properties.AppearanceReadOnly.FontSizeDelta"), Integer)
        Me.txtSettlement.Properties.AppearanceReadOnly.FontStyleDelta = CType(resources.GetObject("txtSettlement.Properties.AppearanceReadOnly.FontStyleDelta"), System.Drawing.FontStyle)
        Me.txtSettlement.Properties.AppearanceReadOnly.GradientMode = CType(resources.GetObject("txtSettlement.Properties.AppearanceReadOnly.GradientMode"), System.Drawing.Drawing2D.LinearGradientMode)
        Me.txtSettlement.Properties.AppearanceReadOnly.Image = CType(resources.GetObject("txtSettlement.Properties.AppearanceReadOnly.Image"), System.Drawing.Image)
        Me.txtSettlement.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtSettlement.Properties.AutoHeight = CType(resources.GetObject("txtSettlement.Properties.AutoHeight"), Boolean)
        Me.txtSettlement.Properties.Mask.AutoComplete = CType(resources.GetObject("txtSettlement.Properties.Mask.AutoComplete"), DevExpress.XtraEditors.Mask.AutoCompleteType)
        Me.txtSettlement.Properties.Mask.BeepOnError = CType(resources.GetObject("txtSettlement.Properties.Mask.BeepOnError"), Boolean)
        Me.txtSettlement.Properties.Mask.EditMask = resources.GetString("txtSettlement.Properties.Mask.EditMask")
        Me.txtSettlement.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtSettlement.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtSettlement.Properties.Mask.MaskType = CType(resources.GetObject("txtSettlement.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtSettlement.Properties.Mask.PlaceHolder = CType(resources.GetObject("txtSettlement.Properties.Mask.PlaceHolder"), Char)
        Me.txtSettlement.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtSettlement.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtSettlement.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtSettlement.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtSettlement.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("txtSettlement.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.txtSettlement.Properties.NullValuePrompt = resources.GetString("txtSettlement.Properties.NullValuePrompt")
        Me.txtSettlement.Properties.NullValuePromptShowForEmptyValue = CType(resources.GetObject("txtSettlement.Properties.NullValuePromptShowForEmptyValue"), Boolean)
        Me.txtSettlement.Tag = "{R}"
        '
        'VSSessionInfo
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtSettlement)
        Me.Controls.Add(Me.txtRayon)
        Me.Controls.Add(Me.txtRegion)
        Me.Controls.Add(Me.lbSettlement)
        Me.Controls.Add(Me.lbRayon)
        Me.Controls.Add(Me.lbRegion)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.Name = "VSSessionInfo"
        Me.Status = bv.common.win.FormStatus.Draft
        CType(Me.txtRegion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRayon.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSettlement.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbRegion As System.Windows.Forms.Label
    Friend WithEvents lbRayon As System.Windows.Forms.Label
    Friend WithEvents lbSettlement As System.Windows.Forms.Label
    Friend WithEvents txtRegion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtRayon As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSettlement As DevExpress.XtraEditors.TextEdit
End Class
