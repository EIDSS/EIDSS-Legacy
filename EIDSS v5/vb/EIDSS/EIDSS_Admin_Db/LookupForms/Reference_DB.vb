Imports System.Data
Imports System.Data.Common
Imports bv.common.db.Core

Public Class Reference_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "BaseReference"
        Me.UseDatasetCopyInPost = False
    End Sub

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spBaseReference_SelectDetail")
            StoredProcParamsCache.CreateParameters(cmd)
            Dim ReferenceDetail_Adapter As DbDataAdapter = CreateAdapter(cmd, False)
            ReferenceDetail_Adapter.Fill(ds)
            CorrectTable(ds.Tables(0), "BaseReference")
            CorrectTable(ds.Tables(1), "ReferenceType")
            CorrectTable(ds.Tables(2), "HACodes")
            CorrectTable(ds.Tables(3), "MasterReferenceType")
            ds.Tables("MasterReferenceType").Columns(0).ReadOnly = False
            ds.Tables("BaseReference").Columns("idfsBaseReference").AutoIncrement = True
            ds.Tables("BaseReference").Columns("idfsBaseReference").AutoIncrementSeed = -1
            ds.Tables("BaseReference").Columns("idfsBaseReference").AutoIncrementStep = -1
            ds.Tables("BaseReference").Columns("intRowStatus").DefaultValue = 0
            For Each col As DataColumn In ds.Tables("BaseReference").Columns
                col.ReadOnly = False
            Next
            m_ID = ID
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
        Return Nothing
    End Function


    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal PostType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            Dim ChangedTables As New Collections.Generic.Dictionary(Of String, Boolean)
            Dim dt As DataTable = ds.Tables("BaseReference").GetChanges()
            If dt Is Nothing Then
                Return True
            End If
            For Each row As DataRow In dt.Rows
                If row.RowState = DataRowState.Deleted Then
                    If row.HasVersion(DataRowVersion.Original) Then
                        ChangedTables(CType(row("idfsReferenceType", DataRowVersion.Original), BaseReferenceType).ToString) = True
                    Else
                        bv.common.Diagnostics.Dbg.Fail("enexpected row version during row deleting")
                    End If
                Else
                    ChangedTables(CType(row("idfsReferenceType"), BaseReferenceType).ToString) = True
                End If
            Next
            ExecPostProcedure("spBaseReference_Post", ds.Tables("BaseReference"), Connection, transaction)
            For Each tableName As String In ChangedTables.Keys
                bv.common.db.Core.LookupCache.NotifyChange(tableName, transaction)
            Next
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function

End Class
