Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports bv.common.Enums

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

            FillDataset(cmd, ds, TableCaseLog)
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
    End Function


    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
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
            InitRow(r)
            .Rows.Add(r)
        End With
        Return r
    End Function
    Public Sub InitRow(ByVal dataRow As DataRow)
        dataRow("idfVetCaseLog") = NewIntID()
        dataRow("datCaseLogDate") = DateTime.Now
        dataRow("idfPerson") = model.Core.EidssUserContext.User.EmployeeID
    End Sub
End Class
