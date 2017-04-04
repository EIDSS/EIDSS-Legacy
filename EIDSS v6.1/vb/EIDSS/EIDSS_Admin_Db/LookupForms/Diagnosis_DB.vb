Imports System.Data
Imports System.Data.Common
Imports bv.common.db.Core
Imports EIDSS.model.Enums
Imports bv.common.Enums

Public Class Diagnosis_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "Reference"
        Me.UseDatasetCopyInPost = False
    End Sub

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spDiagnosisReference_SelectDetail")
            StoredProcParamsCache.CreateParameters(cmd)
            FillDataset(cmd, ds, "BaseReference")
            CorrectTable(ds.Tables(0), "BaseReference")
            CorrectTable(ds.Tables(1), "HACodes")
            ds.Tables("BaseReference").Columns("idfsBaseReference").AutoIncrement = True
            ds.Tables("BaseReference").Columns("idfsBaseReference").AutoIncrementSeed = -1
            ds.Tables("BaseReference").Columns("idfsBaseReference").AutoIncrementStep = -1
            ClearColumnsAttibutes(ds)
            ds.EnforceConstraints = False
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function

    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            ExecPostProcedure("spDiagnosisReference_Post", ds.Tables("BaseReference"), Connection, transaction)
            LookupCache.NotifyChange("Diagnosis", transaction)
            AddEvent(EventType.ReferenceTableChanged, "DiagnosisReferenceDetail", False)

        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function
    Public Function CanClearHACode(ByVal row As DataRow, ByVal code As HACode) As Boolean
        Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spDiagnosis_CanClearHACode", ConnectionManager.DefaultInstance.Connection)
        StoredProcParamsCache.CreateParameters(cmd)
        BaseDbService.SetParam(cmd, "@id", row("idfsBaseReference"))
        BaseDbService.SetParam(cmd, "@HACodeFlag", CInt(code))
        ExecCommand(cmd, cmd.Connection, Nothing, True)
        If CType(BaseDbService.GetParamValue(cmd, "@Result"), Boolean) = False Then
            Return False
        End If
        Return True
    End Function
End Class
