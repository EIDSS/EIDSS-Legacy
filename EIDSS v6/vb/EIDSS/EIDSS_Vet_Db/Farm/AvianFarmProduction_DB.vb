Imports System.Data
Imports System.Data.Common
Imports bv.common.Enums

Public Class AvianFarmProduction_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "AvianFarmProduction"
    End Sub

    Public Const TableFarm As String = "AvianFarmProduction"


    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        If ID Is Nothing Then
            Throw New Exception("AvianFarmProduction_DB service must be initialized with NOT NULL farm ID")
        End If
        Dim ds As New DataSet
        Try

            Dim cmd As IDbCommand = CreateSPCommand("spAvianFarmProduction_SelectDetail")


            AddParam(cmd, "@idfFarm", ID)

            Dim FarmDetail_Adapter As DbDataAdapter = CreateAdapter(cmd, False)

            FarmDetail_Adapter.Fill(ds, TableFarm)
            CorrectTable(ds.Tables(0), TableFarm)

            ClearColumnsAttibutes(ds)

            ds.EnforceConstraints = False
            If ds.Tables(TableFarm).Rows.Count = 0 Then
                Dim r As DataRow = ds.Tables(TableFarm).NewRow
                r("idfFarm") = ID
                ds.Tables(TableFarm).Rows.Add(r)
            End If

            m_ID = ID
            Return ds
        Catch ex As Exception
            m_error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function
    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            ExecPostProcedure("spAvianFarmProduction_Post", ds.Tables(TableFarm), Connection, transaction)
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function

End Class
