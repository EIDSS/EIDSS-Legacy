Public Class CaseInfo

    Public Sub New()

        InitializeComponent()
        Me.DbService = New BaseDbService

        Me.UseParentDataset = True

        Me.RegisterChildObject(Me.HumanCaseInfo, RelatedPostOrder.SkipPost)
        Me.RegisterChildObject(Me.VetCaseInfo, RelatedPostOrder.SkipPost)

    End Sub

    Public Sub ShowPanel(ByVal aHACode As HACode)
        Me.HumanCaseInfo.Visible = (aHACode And HACode.Human) <> 0
        Me.VetCaseInfo.Visible = (aHACode And HACode.Avian) <> 0 OrElse (aHACode And HACode.Livestock) <> 0
        If (aHACode And HACode.Human) <> 0 Then
            Me.Height = Me.HumanCaseInfo.Bottom
        Else
            Me.Height = Me.VetCaseInfo.Bottom
        End If
    End Sub

End Class
