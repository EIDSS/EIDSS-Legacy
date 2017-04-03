Public Class LookupCacheDataView
    Inherits DataView
    Public Sub New(table As DataTable)
        MyBase.New(table)
        DefaultFilter = String.Empty
    End Sub
    Public Property DefaultFilter As String
    Public Property ClonedView As DataView

End Class
