Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Public Class Organization_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "Organization"
    End Sub


    Dim Department_Adapter As DbDataAdapter
    Dim Address_Adapter As DbDataAdapter
    Dim NameTranslation_Adapter As DbDataAdapter
    Dim DepNameTranslation_Adapter As DbDataAdapter
    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spOrganization_SelectDetail")
            Dim strID As String = Convert.ToString(ID)
            AddParam(cmd, "@idfOffice", ID)
            AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
            Dim OrganizationDetail_Adapter As DbDataAdapter = CreateAdapter(cmd) ', True)

            OrganizationDetail_Adapter.Fill(ds, "Organization")
            CorrectTable(ds.Tables(0), "Organization")
            CorrectTable(ds.Tables(1), "Departments")
            ds.EnforceConstraints = False
            If ID Is Nothing Then
                Dim r As DataRow = ds.Tables("Organization").NewRow
                ID = NewIntID()
                r("idfOffice") = ID
                ds.Tables("Organization").Rows.Add(r)
            End If
            If ds.Tables("Organization").Rows(0)("idfLocation") Is DBNull.Value Then
                ds.Tables("Organization").Rows(0)("idfLocation") = NewIntID()
                ForceTableChanges(ds.Tables("Organization"))
            End If
            ds.Tables("Organization").Columns("EnglishName").ReadOnly = False
            ds.Tables("Organization").Columns("name").ReadOnly = False
            ds.Tables("Organization").Columns("FullName").ReadOnly = False
            ds.Tables("Organization").Columns("EnglishFullName").ReadOnly = False
            ds.Tables("Departments").Columns("Name").ReadOnly = False
            ds.Tables("Departments").Columns("idfOrganization").ReadOnly = False
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
            ExecPostProcedure("spOrganization_Post", ds.Tables("Organization"), Connection, transaction, params)
            ExecPostProcedure("spDepartment_Post", ds.Tables("Departments"), Connection, transaction, params)

            bv.common.db.Core.LookupCache.NotifyChange("Organization", transaction, Nothing)
            bv.common.db.Core.LookupCache.NotifyChange("Department", transaction, Nothing)
            bv.common.db.Core.LookupCache.NotifyChange("Person", transaction, Nothing)
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function


    Public Overrides Function BeforePost(ByVal ds As System.Data.DataSet, ByVal PostType As Integer) As Boolean
        For Each r As DataRow In ds.Tables("Departments").Rows
            If r.RowState = DataRowState.Added AndAlso r("idfDepartment") Is DBNull.Value Then
                r("idfDepartment") = NewIntID()
                r("idfOrganization") = ds.Tables("Organization").Rows(0)("idfOffice")
            End If
        Next
        Return True
    End Function
End Class
