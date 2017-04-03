Imports System.Data
Imports System.Data.Common
Imports bv.common.db.Core

Public Class Action_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "ActionReference"
    End Sub

    Dim ReferenceDetail_Adapter As DbDataAdapter
    Dim ReferenceType_Adapter As DbDataAdapter

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spMeasureReference_SelectDetail")
            StoredProcParamsCache.CreateParameters(cmd)
            'SetParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
            Dim ReferenceDetail_Adapter As DbDataAdapter = CreateAdapter(cmd, False)
            ReferenceDetail_Adapter.Fill(ds)
            CorrectTable(ds.Tables(0), "BaseReference")
            CorrectTable(ds.Tables(1), "ReferenceType")
            CorrectTable(ds.Tables(2), "HACodes")
            CorrectTable(ds.Tables(3), "MasterReferenceType")
            ds.Tables("MasterReferenceType").Columns(0).ReadOnly = False
            ClearColumnsAttibutes(ds)
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


    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal PostType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            ExecPostProcedure("spMeasureReference_Post", ds.Tables("BaseReference"), Connection, transaction)
            bv.common.db.Core.LookupCache.NotifyChange("ProphilacticAction", transaction)
            bv.common.db.Core.LookupCache.NotifyChange("SanitaryAction", transaction)
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function

End Class
