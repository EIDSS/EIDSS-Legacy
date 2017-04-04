Imports System.Data
Imports bv.common.Enums

Public Class StatisticType_DB
    Inherits BaseDbService

    Public Sub New()
        ObjectName = "BaseReference"
        UseDatasetCopyInPost = False
    End Sub
    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spStatisticType_SelectDetail")
            AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)

            FillDataset(cmd, ds, "BaseReference")
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
    End Function

    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            ExecPostProcedure("spStatisticType_Post", ds.Tables("BaseReference"), Connection, transaction)
            db.Core.LookupCache.NotifyChange("rftStatisticDataType", transaction)
            db.Core.LookupCache.NotifyChange("rftStatisticPeriodType", transaction)
            db.Core.LookupCache.NotifyChange("rftStatisticAreaType", transaction)

        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function
End Class
