Imports System.Data
Imports System.Data.Common
Imports bv.common.db.Core

Public Class TestForDisease_DB
    Inherits BaseDbService

    Public Sub New()
        ObjectName = "TestForDisease"
    End Sub

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spTestForDisease_SelectDetail")
            Dim da As DbDataAdapter = CreateAdapter(cmd, False)
            da.Fill(ds, "TestForDisease")
            CorrectTable(ds.Tables(0), "TestForDisease")
            CorrectTable(ds.Tables(1), "MasterDiagnosis")
            ds.Tables("MasterDiagnosis").Columns(0).ReadOnly = False
            ClearColumnsAttibutes(ds)
            ds.Tables("TestForDisease").Columns("intRecommendedQty").DefaultValue = 1
            ds.Tables(0).Columns("idfTestForDisease").AutoIncrement = True
            ds.Tables(0).Columns("idfTestForDisease").AutoIncrementSeed = -1
            ds.Tables(0).Columns("idfTestForDisease").AutoIncrementStep = -1
            m_ID = ID
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function

    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal PostType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            BaseDbService.ExecPostProcedure("spTestForDisease_Post", ds.Tables(0), ConnectionManager.DefaultInstance.Connection, transaction)
            'bv.common.db.Core.LookupCache.NotifyChange("Test_Type", transaction)
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function

End Class
