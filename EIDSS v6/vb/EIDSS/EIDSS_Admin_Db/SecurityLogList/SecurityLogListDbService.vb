Public Class SecurityLogListDbService
    Inherits BaseDbService

    Public Overrides Function PostDetail(ByVal ds As System.Data.DataSet, ByVal postType As Integer, Optional ByVal transaction As System.Data.IDbTransaction = Nothing) As Boolean
        Return MyBase.PostDetail(ds, PostType, transaction)
    End Function

    Public Sub New()
        ObjectName = "SecurityLog"
    End Sub

End Class
