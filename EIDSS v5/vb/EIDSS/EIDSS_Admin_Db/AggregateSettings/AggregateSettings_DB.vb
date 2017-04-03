Imports System.Data
Imports System.Data.Common

Public Class AggregateSettings_DB
    Inherits BaseDbService

    Public Sub New()
        ObjectName = "AggregateSettings"
    End Sub


    Public Overrides Function GetDetail(ByVal ID As Object) As System.Data.DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand

            cmd = CreateSPCommand("spAggregateSettings_SelectDetail")
            AddParam(cmd, "@idfsAggrCaseType", DBNull.Value)
            Dim da As DbDataAdapter = CreateAdapter(cmd)
            'Fill the main object table
            da.Fill(ds, "AggregateSettings")
            ClearColumnsAttibutes(ds)
            m_ID = ID
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function

    Public Overrides Function PostDetail(ByVal ds As System.Data.DataSet, ByVal PostType As Integer, Optional ByVal transaction As System.Data.IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try

            ExecPostProcedure("spAggregateSettings_Post", ds.Tables("AggregateSettings"), Connection, transaction)
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function
End Class
