Imports System.Data
Imports System.Data.Common
Imports bv.common.db.Core

Public Class HumanCaseDiagnosisChangeReason_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "HumanCase"
    End Sub

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            m_ID = ID 
            m_IsNewObject = True
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
        Return Nothing
    End Function

    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal post_Type As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        Return True
    End Function

End Class
