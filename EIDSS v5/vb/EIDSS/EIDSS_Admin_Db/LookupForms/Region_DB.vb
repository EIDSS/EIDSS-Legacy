Imports System.Data
Imports System.Data.Common

Public Class Region_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "Region"
    End Sub

    Dim RegionDetail_Adapter As DbDataAdapter
    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spRegion_SelectDetail")
            AddParam(cmd, "@idfRegion", ID, m_Error)
            If Not m_Error Is Nothing Then
                Return Nothing
            End If
            RegionDetail_Adapter = CreateAdapter(cmd, True)
            'Add more detail adapters here
            'Fill lookup tables here if needed

            'Fill the main object table
            RegionDetail_Adapter.Fill(ds, "Region")
            'Fill other object tables here

            'Process the new object creation
            'It is assumed that if ID is nothing we should return 
            'the dataset containing empty row related with the mai obiect
            If ID Is Nothing Then
                Dim r As DataRow = ds.Tables("Region").NewRow
                If ds.Tables("Region").Columns("idfRegion").DataType Is GetType(Guid) Then
	                ID = Guid.NewGuid()
                End If
                ds.EnforceConstraints = False
                ds.Tables("Region").Rows.Add(r)
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
        If ds Is Nothing Then Return True
        Try
            Update(RegionDetail_Adapter, ds, "Region", transaction)
            bv.common.db.Core.LookupCache.NotifyChange("Region", transaction, ID)
            'Add any other posting here if needed
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function

    Public Overrides Function GetSelectListSql() As String
        Return MyBase.GetSelectListSql + " Order By  strCountry_Name, strRegion_Name"
    End Function
End Class
