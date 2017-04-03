Imports System.Data
Imports System.Data.Common

Public Class NextNumbers_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "NextNumbers"
    End Sub

    Dim NextNumbersDetail_Adapter As DbDataAdapter
    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spNextNumbers_SelectDetail")
            AddParam(cmd, "@idfsNumberName", ID)
            AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
            NextNumbersDetail_Adapter = CreateAdapter(cmd, False)

            NextNumbersDetail_Adapter.Fill(ds, "NextNumbers")
            ds.Tables("NextNumbers").Columns("strObjectName").ReadOnly = False

            If ds.Tables("NextNumbers").Rows.Count = 0 Then
                Dim r As DataRow = ds.Tables("NextNumbers").NewRow
                r("idfsNumberName") = ID
                r("intYear") = Now.Year
                r("intNumberValue") = 0
                r("blnUsePrefix") = 1
                r("blnUseSiteID") = 1
                r("blnUseYear") = 1
                r("blnUseHACSCodeSite") = 0
                r("blnUseAlphaNumericValue") = 1
                ds.Tables("NextNumbersValue").Rows.Add(r)
            End If
            m_ID = ID
            Return ds
        Catch ex As Exception
            m_error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function
    
    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal PostType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            ExecPostProcedure("spNextNumbers_Post", ds.Tables("NextNumbers"), Connection, transaction)
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        Finally
            ds.Tables("NextNumbers").Columns("strObjectName").ReadOnly = False
            ds.Tables("NextNumbers").Columns("intYear").ReadOnly = False
        End Try
        Return True
    End Function

End Class
