Public Class PostEventArgs
    Inherits EventArgs
    Public Sub New(ByVal aPostType As Integer, ByVal aCancel As Boolean, Optional ByVal aTransaction As IDbTransaction = Nothing)
        Me.PostType = aPostType
        Me.Cancel = aCancel
        Me.Transaction = aTransaction
    End Sub 'New
    Public PostType As Integer
    Public Cancel As Boolean
    Public Transaction As IDbTransaction
End Class
Public Delegate Sub PostHandler(ByVal sender As Object, ByVal e As PostEventArgs)

Public Class DataRowEventArgs
    Inherits EventArgs
    Public Sub New(ByVal aRow As DataRow)
        Me.Row = aRow
        Me.Cancel = False
    End Sub 'New
    Public Row As DataRow
    Public Cancel As Boolean
End Class

Public Delegate Sub RowCollectionChangedHandler(ByVal sender As Object, ByVal e As DataRowEventArgs)

