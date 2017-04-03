<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BarcodeButton
    Inherits System.Windows.Forms.UserControl

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BarcodeButton))
        Me.btnBarcodes = New DevExpress.XtraEditors.SimpleButton
        Me.SuspendLayout()
        '
        'btnBarcodes
        '
        Me.btnBarcodes.Appearance.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnBarcodes.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.btnBarcodes, "btnBarcodes")
        Me.btnBarcodes.Image = Global.bv.common.win.My.Resources.Resources.Print_Barcodes1
        Me.btnBarcodes.Name = "btnBarcodes"
        '
        'BarcodeButton
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnBarcodes)
        Me.Name = "BarcodeButton"
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents btnBarcodes As DevExpress.XtraEditors.SimpleButton

End Class
