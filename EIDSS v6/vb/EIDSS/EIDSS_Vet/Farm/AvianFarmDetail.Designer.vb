<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AvianFarmDetail
    Inherits bv.common.win.BaseDetailPanel

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AvianFarmDetail))
        Me.lbBuldingsQty = New DevExpress.XtraEditors.LabelControl()
        Me.txtBuildingsQty = New DevExpress.XtraEditors.SpinEdit()
        Me.txtBirdsPerBuilding = New DevExpress.XtraEditors.SpinEdit()
        Me.lbBirdsPerBuilding = New DevExpress.XtraEditors.LabelControl()
        CType(Me.txtBuildingsQty.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBirdsPerBuilding.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(AvianFarmDetail), resources)
        'Form Is Localizable: True
        '
        'lbBuldingsQty
        '
        resources.ApplyResources(Me.lbBuldingsQty, "lbBuldingsQty")
        Me.lbBuldingsQty.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.lbBuldingsQty.Name = "lbBuldingsQty"
        '
        'txtBuildingsQty
        '
        resources.ApplyResources(Me.txtBuildingsQty, "txtBuildingsQty")
        Me.txtBuildingsQty.Name = "txtBuildingsQty"
        Me.txtBuildingsQty.Properties.IsFloatValue = False
        Me.txtBuildingsQty.Properties.Mask.EditMask = resources.GetString("txtBuildingsQty.Properties.Mask.EditMask")
        Me.txtBuildingsQty.Properties.Mask.MaskType = CType(resources.GetObject("txtBuildingsQty.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtBuildingsQty.Properties.MaxValue = New Decimal(New Integer() {1000000, 0, 0, 0})
        '
        'txtBirdsPerBuilding
        '
        resources.ApplyResources(Me.txtBirdsPerBuilding, "txtBirdsPerBuilding")
        Me.txtBirdsPerBuilding.Name = "txtBirdsPerBuilding"
        Me.txtBirdsPerBuilding.Properties.IsFloatValue = False
        Me.txtBirdsPerBuilding.Properties.Mask.EditMask = resources.GetString("txtBirdsPerBuilding.Properties.Mask.EditMask")
        Me.txtBirdsPerBuilding.Properties.Mask.MaskType = CType(resources.GetObject("txtBirdsPerBuilding.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtBirdsPerBuilding.Properties.MaxValue = New Decimal(New Integer() {1000000, 0, 0, 0})
        '
        'lbBirdsPerBuilding
        '
        resources.ApplyResources(Me.lbBirdsPerBuilding, "lbBirdsPerBuilding")
        Me.lbBirdsPerBuilding.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.lbBirdsPerBuilding.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.lbBirdsPerBuilding.Name = "lbBirdsPerBuilding"
        '
        'AvianFarmDetail
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtBirdsPerBuilding)
        Me.Controls.Add(Me.lbBirdsPerBuilding)
        Me.Controls.Add(Me.txtBuildingsQty)
        Me.Controls.Add(Me.lbBuldingsQty)
        Me.Name = "AvianFarmDetail"
        CType(Me.txtBuildingsQty.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBirdsPerBuilding.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbBuldingsQty As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtBuildingsQty As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtBirdsPerBuilding As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lbBirdsPerBuilding As DevExpress.XtraEditors.LabelControl

End Class
