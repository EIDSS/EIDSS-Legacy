Public Class SessionInfo

    Public Sub New()

        InitializeComponent()
        Me.DbService = New BaseDbService

        Me.UseParentDataset = True

        Me.RegisterChildObject(Me.ASSessionInfo, RelatedPostOrder.SkipPost)
        Me.RegisterChildObject(Me.VSSessionInfo, RelatedPostOrder.SkipPost)

    End Sub

    Public Sub ShowPanel(ByVal HACode As HACode)
        Me.ASSessionInfo.Visible = (HACode And EIDSS.HACode.Livestock) <> 0
        Me.VSSessionInfo.Visible = (HACode And EIDSS.HACode.Vector) <> 0
        If (HACode And EIDSS.HACode.Livestock) <> 0 Then
            Me.Height = Me.ASSessionInfo.Bottom
        Else
            Me.Height = Me.VSSessionInfo.Bottom
        End If
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

End Class