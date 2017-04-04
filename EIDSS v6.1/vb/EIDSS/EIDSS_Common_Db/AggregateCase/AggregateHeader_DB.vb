Imports System.Data.Common
Imports System.Collections.Generic

Public Class AggregateHeader_DB
    Inherits BaseDbService

    Public Sub New()
        ObjectName = "AggregateHeader"
    End Sub

    Public Const TableAggregateHeader As String = "AggregateHeader"
    Public Const TableSettings As String = "Settings"

    Public Function AggregateCaseExists(ByVal row As DataRow) As Boolean
        Dim cmd As IDbCommand = CreateSPCommand("spAggregateCaseExists", Connection)
        Dim params As New Dictionary(Of String, Object)
        params.Add("@StartDate", row("datStartDate"))
        params.Add("@FinishDate", row("datFinishDate"))
        params.Add("@AdminUnit", row("idfsAdministrativeUnit"))
        params.Add("@AggrCaseType", row("idfsAggrCaseType"))
        params.Add("@CaseID", row("idfAggrCase"))
        StoredProcParamsCache.CreateParameters(cmd, params)
        BaseDbService.ExecCommand(cmd, Connection)
        Return CBool(GetParamValue(cmd, "@RETURN_VALUE"))
    End Function

End Class
