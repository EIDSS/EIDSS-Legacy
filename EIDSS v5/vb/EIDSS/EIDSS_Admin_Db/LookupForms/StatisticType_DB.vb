Imports System.Data
Imports System.Data.Common
Imports bv.common.db.Core

Public Class StatisticType_DB
    Inherits BaseDbService

    Public Sub New()
        ObjectName = "BaseReference"
        Me.UseDatasetCopyInPost = False
    End Sub
    Public Overrides Function GetDetail(ByVal ID As Object) As System.Data.DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spStatisticType_SelectDetail")
            AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)

            Dim StatisticTypeDetail_Adapter As IDataAdapter = CreateAdapter(cmd)
            StatisticTypeDetail_Adapter.Fill(ds)
            CorrectTable(ds.Tables(0), "BaseReference")
            ds.Tables("BaseReference").Columns("Name").ReadOnly = False
            ds.Tables("BaseReference").Columns("idfsStatisticAreaType").AllowDBNull = True
            ds.Tables("BaseReference").Columns("idfsBaseReference").AutoIncrement = True
            ds.Tables("BaseReference").Columns("idfsBaseReference").AutoIncrementSeed = -1
            ds.Tables("BaseReference").Columns("idfsBaseReference").AutoIncrementStep = -1
            m_ID = ID
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
        Return Nothing
    End Function

    Public Overrides Function PostDetail(ByVal ds As System.Data.DataSet, ByVal PostType As Integer, Optional ByVal transaction As System.Data.IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            ExecPostProcedure("spStatisticType_Post", ds.Tables("BaseReference"), Connection, transaction)
            bv.common.db.Core.LookupCache.NotifyChange("rftStatisticDataType", transaction)
            bv.common.db.Core.LookupCache.NotifyChange("rftStatisticPeriodType", transaction)
            bv.common.db.Core.LookupCache.NotifyChange("rftStatisticAreaType", transaction)

        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function
End Class
