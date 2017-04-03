Public Class BatchSelectTest_DB
    Inherits BaseDbService

    Public Const TableTestResult As String = "TestResult"

    Public Overrides Function GetDetail(ID As Object) As System.Data.DataSet
        'MyBase.GetDetail(ID)

        Dim ds As New DataSet
        Dim t As New DataTable
        t.Columns.Add(New DataColumn("idfsTestResult"))

        Dim dr As DataRow = t.NewRow

        t.Rows.Add(dr)
        ds.Tables.Add(t)
        dr("idfsTestResult") = 0


        CorrectTable(ds.Tables(0), "TestResult")


        Return ds

    End Function
    Public Overrides Function PostDetail(ds As System.Data.DataSet, PostType As Integer, Optional transaction As System.Data.IDbTransaction = Nothing) As Boolean
        Return True
    End Function


End Class
