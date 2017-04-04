Imports System.Data
Imports System.Data.Common
Imports bv.common.Enums

Public Class SiteActivationClient_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "SiteActivationClient"
    End Sub

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spSiteActivationClient_SelectDetail")
            AddParam(cmd, "@SiteID", ID, m_Error)
            If Not m_Error Is Nothing Then
                Return Nothing
            End If
            FillDataset(cmd, ds, "SiteActivationClient")
            If ID Is Nothing Then
                Dim r As DataRow = ds.Tables("SiteActivationClient").NewRow
                ds.EnforceConstraints = False
                ds.Tables("SiteActivationClient").Rows.Add(r)
            End If
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

End Class
