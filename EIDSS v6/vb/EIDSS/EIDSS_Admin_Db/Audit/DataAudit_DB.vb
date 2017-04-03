Imports System.Data.Common
Imports bv.common.db.Core
Imports bv.common.Enums

Public Class DataAudit_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "DataAudit"
    End Sub

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spDataAudit_SelectDetail")
            AddParam(cmd, "@idfDataAuditEvent", ID)
            AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)

            Dim da As DbDataAdapter = CreateAdapter(cmd, False)
            da.Fill(ds, "DataAudit")
            CorrectTable(ds.Tables(1), "DataAuditDetail")
            m_ID = ID
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function

    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        Return True
    End Function
    Public Function Restore(auditID As Object) As Boolean
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spDataAudit_Restore")
            StoredProcParamsCache.CreateParameters(cmd)
            SetParam(cmd, "@idfDataAuditEvent", auditID)
            SetParam(cmd, "@Print", 0)
            ExecCommand(cmd, Connection, Nothing, True)
            If (CInt(GetParamValue(cmd, "@RETURN_VALUE")) = 0) Then
                Return True
            End If
            Return False
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return False
        End Try

    End Function
    Public Function CanRestore(auditID As Object) As Boolean
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spDataAudit_CanRestore")
            StoredProcParamsCache.CreateParameters(cmd)
            SetParam(cmd, "@ID", auditID)
            ExecCommand(cmd, Connection, Nothing, True)
            If (CBool(GetParamValue(cmd, "@Result")) = True) Then
                Return True
            End If
            Return False
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return False
        End Try

    End Function
End Class
