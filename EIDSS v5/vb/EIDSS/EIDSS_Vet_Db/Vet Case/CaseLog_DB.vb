Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Public Class CaseLog_DB

    Inherits BaseDbService
    Public Sub New()
        ObjectName = "CaseLog"
    End Sub
    Public Const TableCaseLog As String = "CaseLog"
    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        If ID Is Nothing Then
            Throw New Exception("CaseLog_DB service must be initialized with NOT NULL case ID")
        End If
        Dim ds As New DataSet

        Try
            Dim cmd As IDbCommand = CreateSPCommand("spVetCaseLog_SelectDetail")
            AddParam(cmd, "@idfCase", ID)

            Dim da As DbDataAdapter = CreateAdapter(cmd)
            da.Fill(ds, TableCaseLog)
            CorrectTable(ds.Tables(TableCaseLog), TableCaseLog)
            m_ID = ID

            ds.EnforceConstraints = False
            ClearColumnsAttibutes(ds)
            'Init default values
            Return ds
        Catch ex As Exception
            m_error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
        Return Nothing
    End Function


    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal post_Type As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            Dim params As New Dictionary(Of String, Object)
            params.Add("@idfVetCase", m_ID)
            ExecPostProcedure("spVetCaseLog_Post", ds.Tables(TableCaseLog), Connection, transaction, params)
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function
    Public Function AddLogRecord(ByVal ds As DataSet) As DataRow
        Dim r As DataRow
        With ds.Tables(TableCaseLog)
            ds.EnforceConstraints = False
            r = .NewRow()
            r("idfVetCaseLog") = NewIntID()
            r("datCaseLogDate") = DateTime.Now
            r("idfPerson") = EIDSS.model.Core.EidssUserContext.User.EmployeeID
            'r("blnClosed") = 0
            .Rows.Add(r)
        End With
        Return r
    End Function

End Class
