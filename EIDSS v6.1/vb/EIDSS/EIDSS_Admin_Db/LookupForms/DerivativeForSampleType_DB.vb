Imports System.Data
Imports System.Data.Common
Imports EIDSS.model.Enums
Imports bv.common.Enums

Public Class DerivativeForSampleType_DB
    Inherits BaseDbService

    Public Sub New()
        ObjectName = "DerivativeForSampleType"
    End Sub

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spDerivativeForSampleType_SelectDetail")
            FillDataset(cmd, ds, "DerivativeForSampleType")
            CorrectTable(ds.Tables(0), "DerivativeForSampleType")
            CorrectTable(ds.Tables(1), "SampleType")
            ds.Tables("SampleType").Columns(0).ReadOnly = False
            ClearColumnsAttibutes(ds)
            ds.Tables(0).Columns("idfDerivativeForSampleType").AutoIncrement = True
            ds.Tables(0).Columns("idfDerivativeForSampleType").AutoIncrementSeed = -1
            ds.Tables(0).Columns("idfDerivativeForSampleType").AutoIncrementStep = -1
            m_ID = ID
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function

    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            BaseDbService.ExecPostProcedure("spDerivativeForSampleType_Post", ds.Tables(0), db.Core.ConnectionManager.DefaultInstance.Connection, transaction)
            'bv.common.db.Core.LookupCache.NotifyChange("Test_Type", transaction)
            AddEvent(EventType.MatrixChanged, "DerivativeForSampleType", False)
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function

End Class
