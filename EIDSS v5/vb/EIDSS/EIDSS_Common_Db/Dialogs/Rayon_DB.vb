Imports System.Data
Imports System.Data.Common

Public Class Rayon_DB
    Inherits BaseDbService

    Public Sub New()
        ObjectName = "Rayon"
    End Sub

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand
            cmd = CreateSPCommand("spRayon_SelectDetail")
            StoredProcParamsCache.CreateParameters(cmd)
            SetParam(cmd, "@idfsRayon", ID)

            Dim RayonDetailAdapter As DbDataAdapter = CreateAdapter(cmd)
            RayonDetailAdapter.Fill(ds, "Rayon")
            ClearColumnsAttibutes(ds)

            'Process the new object creation
            'It is assumed that if ID is nothing we should return 
            'the dataset containing empty row related with the mai obiect
            If ID Is Nothing Then
                Dim r As DataRow = ds.Tables("Rayon").NewRow()
                ID = NewIntID()
                r("idfsRayon") = ID
                ds.EnforceConstraints = False
                ds.Tables("Rayon").Rows.Add(r)
            End If
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
            BaseDbService.ExecPostProcedure("spRayon_Post", ds.Tables("Rayon"), Connection, transaction)
            bv.common.db.Core.LookupCache.NotifyChange(LookupTables.Rayon.ToString, transaction)
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function
    Public Function FindDuplicate(ByVal row As DataRow) As Integer
        If row Is Nothing Then Return -2
        Return FindDuplicate(Utils.Str(row("idfsRegion")), Utils.Str(row("idfsRayon")), Utils.Str(row("enName")), Utils.Str(row("natName")), bv.model.Model.Core.ModelUserContext.CurrentLanguage)
    End Function
    Public Function FindDuplicate(ByVal idfsRegion As String, ByVal idfsRayon As String, ByVal enName As String, ByVal natName As String, ByVal lng As String) As Integer
        Dim cmd As IDbCommand = CreateSPCommand("spRayon_Validate")
        AddParam(cmd, "@idfsRegion", idfsRegion)
        AddParam(cmd, "@idfsRayon", idfsRayon)
        AddParam(cmd, "@strDefaultName", enName)
        AddParam(cmd, "@strNationalName", natName)
        AddParam(cmd, "@LangID", lng)
        AddParam(cmd, "@Result", 0, ParameterDirection.Output)
        m_Error = ExecCommand(cmd, Connection)
        If Not m_Error Is Nothing Then
            Return -1
        End If
        Dim Result As Object = GetParamValue(cmd, "@Result")
        If Not Utils.IsEmpty(Result) Then
            Return CInt(Result)
        Else
            Return -2
        End If

    End Function
End Class
