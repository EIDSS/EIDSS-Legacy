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
        Me.txtRegion.Properties.Appearance.Options.UseFont = True
        Me.txtRegion.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtRegion.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtRegion.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtRegion.Properties.AutoHeight = CType(resources.GetObject("txtRegion.Properties.AutoHeight"), Boolean)
        Me.txtRegion.Properties.Mask.EditMask = resources.GetString("txtRegion.Properties.Mask.EditMask")
        Me.txtRegion.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtRegion.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtRegion.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtRegion.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtRegion.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtRegion.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtRegion.Tag = "{R}"
        '
        'txtRayon
        '
        resources.ApplyResources(Me.txtRayon, "txtRayon")
        Me.txtRayon.Name = "txtRayon"
        Me.txtRayon.Properties.Appearance.Options.UseFont = True
        Me.txtRayon.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtRayon.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtRayon.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtRayon.Properties.AutoHeight = CType(resources.GetObject("txtRayon.Properties.AutoHeight"), Boolean)
        Me.txtRayon.Properties.Mask.EditMask = resources.GetString("txtRayon.Properties.Mask.EditMask")
        Me.txtRayon.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtRayon.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtRayon.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtRayon.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtRayon.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtRayon.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtRayon.Tag = "{R}"
        '
        'txtSettlement
        '
        resources.ApplyResources(Me.txtSettlement, "txtSettlement")
        Me.txtSettlement.Name = "txtSettlement"
        Me.txtSettlement.Properties.Appearance.Options.UseFont = True
        Me.txtSettlement.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtSettlement.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtSettlement.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtSettlement.Properties.AutoHeight = CType(resources.GetObject("txtSettlement.Properties.AutoHeight"), Boolean)
        Me.txtSettlement.Properties.Mask.EditMask = resources.GetString("txtSettlement.Properties.Mask.EditMask")
        Me.txtSettlement.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtSettlement.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtSettlement.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtSettlement.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtSettlement.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtSettlement.Properties.Mask.ShowPlaceHolders"), Boolean)
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
        Me.Name = "VSSessionInfo"
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
