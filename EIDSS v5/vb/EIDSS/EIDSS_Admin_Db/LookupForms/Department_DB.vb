Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Public Class Department_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "Department"
    End Sub

    Dim DepartmentDetail_Adapter As DbDataAdapter
    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand
            cmd = CreateSPCommand("spDepartment_SelectDetail")
            AddParam(cmd, "@idfDepartment", ID)
            AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)

            DepartmentDetail_Adapter = CreateAdapter(cmd, False)
            DepartmentDetail_Adapter.Fill(ds, "Department")
            'Process the new object creation
            'It is assumed that if ID is nothing we should return 
            'the dataset containing empty row related with the mai obiect
            If ID Is Nothing Then
                Dim r As DataRow = ds.Tables("Department").NewRow()
                ID = NewIntID()
                r("idfDepartment") = ID
                ds.EnforceConstraints = False
                ds.Tables("Department").Rows.Add(r)
            End If
            ds.Tables("Department").Columns("Name").ReadOnly = False
            ds.Tables("Department").Columns("DefaultName").ReadOnly = False
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
            Dim params As New Dictionary(Of String, Object)
            params.Add("@idfsCountry", EIDSS.model.Core.EidssSiteContext.Instance.CountryID)
            ExecPostProcedure("spDepartment_Post", ds.Tables("Department"), Connection, transaction, params)
            bv.common.db.Core.LookupCache.NotifyChange("Organization", transaction, ID)
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function

End Class
