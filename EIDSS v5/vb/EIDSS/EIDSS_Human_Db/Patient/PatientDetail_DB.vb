Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports bv.common.db.Core

Public Class PatientDetail_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "Patient"
    End Sub

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            If ID Is Nothing Then
                ID = NewIntID()
            End If

            If ds.Tables.Contains(Patient_DB.tlbHuman) AndAlso _
               (ds.Tables(Patient_DB.tlbHuman).Rows.Count > 0) Then
                ds.Tables(Patient_DB.tlbHuman).Rows(0)("idfHuman") = ID
            Else
                ds.Tables.Add(Patient_DB.tlbHuman)
                ds.Tables(Patient_DB.tlbHuman).Columns.Add("idfHuman", GetType(System.Int64))
                ds.Tables(Patient_DB.tlbHuman).PrimaryKey = _
                    New DataColumn() {ds.Tables(Patient_DB.tlbHuman).Columns("idfHuman")}
                Dim r As DataRow = ds.Tables(Patient_DB.tlbHuman).NewRow
                r("idfHuman") = ID
                ds.Tables(Patient_DB.tlbHuman).Rows.Add(r)
            End If

            m_ID = ID
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
        Return Nothing
    End Function

    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal PostType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        Return True
    End Function


    Public Overrides Function CanDelete(ByVal ID As Object, Optional ByVal aObjectName As String = Nothing, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        Return MyBase.CanDelete(ID, "PatientActual", transaction)
    End Function

    Public Overrides Function Delete(ByVal ID As Object, ByVal transaction As IDbTransaction) As Boolean
        Dim cmd As IDbCommand = CreateSPCommand("spPatientActual_Delete", Connection, transaction)
        StoredProcParamsCache.CreateParameters(cmd)
        CType(cmd.Parameters(0), SqlParameter).Value = ID
        m_Error = ExecCommand(cmd, Connection, transaction)
        Return m_Error Is Nothing
    End Function

End Class
