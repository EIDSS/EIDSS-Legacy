Public Class BarcodeButton

    Public ReadOnly Property ButtonCaption() As String
        Get
            Return Me.btnBarcodes.Text
        End Get
        ''  Set(ByVal value As String)
        ''      btnBarcodes.Text = value
        ''  End Set
    End Property

    Public Event ButtonPressed()

    Private Sub btnBarcodes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBarcodes.Click
        RaiseEvent ButtonPressed()
    End Sub
End Class
