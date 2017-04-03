Imports System.Data
Imports System.Data.Common

Public Class SiteActivationClient_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "SiteActivationClient"
    End Sub

    Dim SiteActivationClientDetail_Adapter As DbDataAdapter
    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spSiteActivationClient_SelectDetail")
            AddParam(cmd, "@SiteID", ID, m_Error)
            If Not m_Error Is Nothing Then
                Return Nothing
            End If
            SiteActivationClientDetail_Adapter = CreateAdapter(cmd, True)
            'Add more detail adapters here
            'Fill lookup tables here if needed

            'Fill the main object table
            SiteActivationClientDetail_Adapter.Fill(ds, "SiteActivationClient")
            If ID Is Nothing Then
                Dim r As DataRow = ds.Tables("SiteActivationClient").NewRow
                ds.EnforceConstraints = False
                ds.Tables("SiteActivationClient").Rows.Add(r)
            End If
            m_ID = ID
            Return ds
        Catch ex As Exception
            m_error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
        Return Nothing
    End Function
    
    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal PostType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        Return True
        'If ds Is Nothing Then Return True
        'Try
        '    Update(SiteActivationClientDetail_Adapter, ds, "SiteActivationClient", transaction)
        '    'Add any other posting here if needed
        'Catch ex As Exception
        '    m_Error = New ErrorMessage(StandardError.PostError, ex)
        '    Return False
        'End Try
        'Return True
    End Function

End Class
