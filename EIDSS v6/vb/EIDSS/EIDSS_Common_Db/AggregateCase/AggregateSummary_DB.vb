Imports System.Collections.Generic
Imports System.Data.Common

Public Class AggregateSummary_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "AggregateSummary"
    End Sub
    Public Shared Function FindAggregateCase(ByVal caseType As AggregateCaseType, ByVal startDate As DateTime, ByVal finishDate As DateTime, ByVal adminUnit As Long) As Long
        Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spAggregateCaseExists", ConnectionManager.DefaultInstance.Connection)
        Dim params As New Dictionary(Of String, Object)
        params.Add("@StartDate", startDate)
        params.Add("@FinishDate", finishDate)
        params.Add("@AdminUnit", adminUnit)
        params.Add("@AggrCaseType", caseType)
        StoredProcParamsCache.CreateParameters(cmd, params)
        BaseDbService.ExecCommand(cmd, cmd.Connection)
        If CBool(BaseDbService.GetParamValue(cmd, "@RETURN_VALUE")) = True Then
            Return CLng(BaseDbService.GetParamValue(cmd, "@CaseID"))
        End If
        Return -1
    End Function

    Public Shared Function GetAggregateCaseStartupParameters(ByVal adminUnit As Long, ByVal startDate As DateTime, ByVal finishDate As DateTime) As Dictionary(Of String, Object)
        Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spAggregateCase_GetStartupParameters", ConnectionManager.DefaultInstance.Connection)
        Dim params As New Dictionary(Of String, Object)
        params.Add("@idfsAdminUnit", adminUnit)
        params.Add("@datStartDate", startDate)
        params.Add("@datFinishDate", finishDate)
        StoredProcParamsCache.CreateParameters(cmd, params)
        Dim startupParams As New Dictionary(Of String, Object)
        Dim da As DbDataAdapter = BaseDbService.CreateAdapter(cmd)
        Using dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count = 0 Then
                Return Nothing
            End If
            Dim row As DataRow = dt.Rows(0)
            For Each col As DataColumn In dt.Columns
                If (Not row(col) Is DBNull.Value) Then
                    startupParams.Add(col.ColumnName, row(col))
                End If
            Next
        End Using
        If startupParams.Count > 0 Then
            Return startupParams
        End If
        Return Nothing
    End Function

    Public Shared Function GetObservationsList(ByVal AggrXml As String, ByVal formType As FFType) As List(Of Long)
        Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spAggregateCaseSummary_GetObservationsList", ConnectionManager.DefaultInstance.Connection)
        Dim params As New Dictionary(Of String, Object)
        params.Add("@AggrXml", AggrXml)
        params.Add("@FormType", formType)
        StoredProcParamsCache.CreateParameters(cmd, params)
        Dim da As DbDataAdapter = BaseDbService.CreateAdapter(cmd)
        Using dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count = 0 Then
                Return Nothing
            End If
            Dim observations As New List(Of Long)
            For Each row As DataRow In dt.Rows
                If Not row("idfObservation") Is DBNull.Value Then
                    observations.Add(CLng(row("idfObservation")))
                End If
            Next
            Return observations
        End Using
        Return Nothing
    End Function

    Public Shared Sub RefreshAggregateSettings(ByVal ds As DataSet, ByVal caseType As AggregateCaseType)
        If ds.Tables.Contains(AggregateHeader_DB.TableSettings) = False Then
            Return
        End If
        Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spAggregateSettings_SelectDetail", ConnectionManager.DefaultInstance.Connection)
        BaseDbService.AddParam(cmd, "@idfsAggrCaseType", caseType)
        Dim dt As DataTable = ds.Tables(AggregateHeader_DB.TableSettings)
        Dim da As DbDataAdapter = BaseDbService.CreateAdapter(cmd)
        dt.Clear()
        da.Fill(dt)
    End Sub
End Class
