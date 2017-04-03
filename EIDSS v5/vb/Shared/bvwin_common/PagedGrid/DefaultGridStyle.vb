Public Class DefaultGridStyle
    Implements IGridStyle

    Public Sub ApplyStyle(ByVal grid As System.Windows.Forms.DataGrid) Implements IGridStyle.ApplyStyle
        grid.CaptionBackColor = System.Drawing.Color.Gainsboro
        grid.CaptionVisible = False
        grid.HeaderForeColor = System.Drawing.Color.Black
        'grid.BackColor = ApplicationLayout.GridBackColor
        'grid.Font = ApplicationLayout.DefaultFont
        'Dim style As DataGridTableStyle = grid.TableStyles(0)
        'style.AlternatingBackColor = ApplicationLayout.GridAlterantiveBackColor
        'style.BackColor = ApplicationLayout.GridBackColor
        'style.GridLineColor = ApplicationLayout.GridHeaderBackColor
        'style.HeaderBackColor = ApplicationLayout.GridHeaderBackColor
        'style.HeaderForeColor = ApplicationLayout.ControlForeColor
    End Sub

    Public Sub ApplyTableStyle(ByVal style As DataGridTableStyle) Implements IGridStyle.ApplyTableStyle
        style.AlternatingBackColor = System.Drawing.SystemColors.Info
        style.GridLineColor = System.Drawing.Color.Gainsboro
        style.HeaderBackColor = System.Drawing.Color.Gainsboro
        style.HeaderForeColor = System.Drawing.Color.Black
    End Sub
End Class
