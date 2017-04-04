Imports System.Collections.Generic
Imports bv.common.Core

Public Class TimeUtils

    Public Shared Function ValueUTC2Local(ByVal time As Object) As Object
        If Utils.IsEmpty(time) Then Return time
        If (TypeOf (time) Is DateTime) = False Then Return time
        Dim dt As DateTime = CType(time, DateTime)
        Return dt.ToLocalTime()
    End Function

    Public Shared Sub UTC2Local(ByVal table As DataTable, ByVal column As String)
        For Each row As DataRow In table.Rows
            row(column) = ValueUTC2Local(row(column))
        Next
    End Sub

    Public Shared Sub UTC2Local(ByVal table As DataTable)
        Dim columns As List(Of DataColumn) = New List(Of DataColumn)
        For Each column As DataColumn In table.Columns
            If column.DataType Is GetType(DateTime) Then columns.Add(column)
        Next
        If columns.Count = 0 Then Exit Sub
        For Each row As DataRow In table.Rows
            row.BeginEdit()
            For Each col As DataColumn In columns
                row(col) = ValueUTC2Local(row(col))
            Next
            row.EndEdit()
        Next
    End Sub

    Public Shared Sub UTC2Local(ByVal ds As DataSet)
        For Each table As DataTable In ds.Tables
            UTC2Local(table)
        Next
    End Sub



    Public Shared Function Local2UTC(ByVal time As Object) As Object
        If Utils.IsEmpty(time) Then Return time
        If (TypeOf (time) Is DateTime) = False Then Return time
        Return CType(time, DateTime).ToUniversalTime()
    End Function

End Class
