Imports EIDSS.model.Core
Imports bv.common.Diagnostics
Imports System.Data.Common
Imports bv.common.Core
Imports System.Collections.Generic
Imports bv.common.Enums

Public Class AsSummary_DB
    Inherits BaseDbService
    Public Const TableAsSummary As String = "AsSummary"
    Public Const TableAsSummarySamples As String = "AsSummarySamples"
    Public Const TableAsSummaryDiagnosis As String = "AsSummaryDiagnosis"
    Public Const TableSpecies As String = "Species"
    Public Overrides Function GetDetail(ID As Object) As System.Data.DataSet
        Dim ds As New DataSet
        Dbg.Assert(Not ID Is Nothing, "AS session ID is not defined for AS summary")
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spASSessionSummary_SelectDetail", Connection)
            AddParam(cmd, "@idfMonitoringSession", ID)
            AddParam(cmd, "@LangID", EidssUserContext.CurrentLanguage)
            Dim da As DbDataAdapter = CreateAdapter(cmd, False)
            da.Fill(ds, TableAsSummary)
            CorrectTable(ds.Tables(0), TableAsSummary)

            'Create empty samples table. It will be filled with data later if needed
            cmd = CreateSPCommand("spASSessionSummarySamples_SelectDetail", Connection)
            AddParam(cmd, "@idfMonitoringSessionSummary", DBNull.Value)
            AddParam(cmd, "@LangID", EidssUserContext.CurrentLanguage)
            da = CreateAdapter(cmd, False)
            'If (ds.Tables(TableAsSummary).Rows.Count > 0) Then
            '    For Each row As DataRow In ds.Tables(TableAsSummary).Rows
            '        SetParam(cmd, "@idfMonitoringSessionSummary", row("idfMonitoringSessionSummary"))
            '        da.Fill(ds, TableAsSummarySamples)
            '    Next
            'Else
            da.Fill(ds, TableAsSummarySamples)
            'End If
            CorrectTable(ds.Tables(1), TableAsSummarySamples, "id")

            'Create empty diagnosis table. It will be filled with data later if needed
            cmd = CreateSPCommand("spASSessionSummaryDiagnosis_SelectDetail", Connection)
            da = CreateAdapter(cmd, False)
            AddParam(cmd, "@idfMonitoringSessionSummary", DBNull.Value)
            AddParam(cmd, "@LangID", EidssUserContext.CurrentLanguage)
            If (ds.Tables(TableAsSummary).Rows.Count > 0) Then
                For Each row As DataRow In ds.Tables(TableAsSummary).Rows
                    SetParam(cmd, "@idfMonitoringSessionSummary", row("idfMonitoringSessionSummary"))
                    If (ds.Tables.Contains(TableAsSummaryDiagnosis)) Then
                        Using dt As New DataTable
                            da.Fill(dt)
                            CorrectTable(dt, TableAsSummaryDiagnosis, "id")
                            ds.Tables(TableAsSummaryDiagnosis).Merge(dt)
                        End Using
                    Else
                        da.Fill(ds, TableAsSummaryDiagnosis)
                        CorrectTable(ds.Tables(2), TableAsSummaryDiagnosis, "id")
                    End If
                Next
            Else
                da.Fill(ds, TableAsSummaryDiagnosis)
                CorrectTable(ds.Tables(2), TableAsSummaryDiagnosis, "id")
            End If
            ClearColumnsAttibutes(ds)
            ds.Tables(1).AcceptChanges()
            ds.Tables(2).AcceptChanges()
            m_ID = ID

            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try

    End Function

    Private Sub CorrectRelatedSummaryTable(summaryTable As DataTable, table As DataTable)

        Dim rows() As DataRow = table.Select()
        For Each dataRow As DataRow In rows
            If (summaryTable.Rows.Find(dataRow("idfMonitoringSessionSummary")) Is Nothing) Then
                dataRow.Delete()
            End If
        Next
    End Sub
    Public Overrides Function PostDetail(ds As System.Data.DataSet, postType As Integer, Optional transaction As System.Data.IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            CorrectRelatedSummaryTable(ds.Tables(TableAsSummary), ds.Tables(TableAsSummarySamples))
            CorrectRelatedSummaryTable(ds.Tables(TableAsSummary), ds.Tables(TableAsSummaryDiagnosis))
            ExecPostProcedure("spASSessionSummary_Post", ds.Tables(TableAsSummary), Connection, transaction)
            ExecPostProcedure("spASSessionSummarySample_Post", ds.Tables(TableAsSummarySamples), Connection, transaction)
            ExecPostProcedure("spASSessionSummaryDiagnosis_Post", ds.Tables(TableAsSummaryDiagnosis), Connection, transaction)
            If m_FarmsToDelete.Count > 0 Then
                Dim cmd As IDbCommand = CreateSPCommandWithParams("spFarm_Delete", transaction)
                For Each idfFarm As Long In m_FarmsToDelete
                    SetParam(cmd, "@ID", idfFarm)
                    ExecCommand(cmd, Connection, transaction, True)
                Next
                m_FarmsToDelete.Clear()
            End If
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function

    Public Function NewSummaryRecord(ds As DataSet, diagnosisView As DataView) As DataRow
        Dim row As DataRow = ds.Tables(TableAsSummary).NewRow
        InitNewSummaryRow(ds, diagnosisView, row)
        ds.Tables(TableAsSummary).Rows.Add(row)
        Return row
    End Function
    Public Function InitNewSummaryRow(ds As DataSet, diagnosisView As DataView, row As DataRow) As DataRow
        row("idfMonitoringSessionSummary") = NewIntID()
        row("idfMonitoringSession") = ID
        row("idfFarm") = BaseDbService.NewIntID
        row("strFarmCode") = "(new)"
        row("blnNewFarm") = True
        'For Each d As DataRowView In diagnosisView
        '    If ds.Tables(TableAsSummaryDiagnosis).Select(String.Format("idfsDiagnosis = {0}", d("idfsDiagnosis"))).Length > 0 Then
        '        Continue For
        '    End If
        '    Dim diagnosisRow As DataRow = ds.Tables(TableAsSummaryDiagnosis).NewRow
        '    diagnosisRow("id") = String.Format("{0}.{1}", row("idfMonitoringSessionSummary"), d("idfsDiagnosis"))
        '    diagnosisRow("idfsDiagnosis") = d("idfsDiagnosis")
        '    diagnosisRow("name") = bv.common.db.Core.LookupCache.GetLookupValue(d("idfsDiagnosis"), LookupTables.LivestockStandardDiagnosis, "name")
        '    diagnosisRow("idfMonitoringSessionSummary") = row("idfMonitoringSessionSummary")
        '    ds.Tables(TableAsSummaryDiagnosis).Rows.Add(diagnosisRow)
        '    diagnosisRow.AcceptChanges()
        'Next
        Return row
    End Function

    Public Function GetSamples(ds As DataSet, summaryID As Object) As DataView
        Dim view As DataView = ds.Tables(TableAsSummarySamples).DefaultView
        view.RowFilter = String.Format("idfMonitoringSessionSummary = {0}", summaryID)
        If (view.Count > 0) Then
            Return view
        End If
        Dim cmd As IDbCommand = CreateSPCommand("spASSessionSummarySamples_SelectDetail", Connection)
        AddParam(cmd, "@idfMonitoringSessionSummary", summaryID)
        AddParam(cmd, "@LangID", EidssUserContext.CurrentLanguage)
        Dim da As DbDataAdapter = CreateAdapter(cmd, False)
        da.Fill(ds, TableAsSummarySamples)
        ClearColumnsAttibutes(ds)
        Return view
    End Function


    Public Function GetDiagnosis(ByVal ds As DataSet, ByVal summaryRow As DataRow, ByVal diagnosisView As DataView) As DataView

        Dim view As DataView = ds.Tables(TableAsSummaryDiagnosis).DefaultView
        view.RowFilter = String.Format("idfMonitoringSessionSummary = {0}", summaryRow("idfMonitoringSessionSummary"))
        If (Utils.IsEmpty(summaryRow("idfsSpeciesType"))) Then
            diagnosisView.RowFilter = String.Format("idfsSpeciesType is null")
        Else
            diagnosisView.RowFilter = String.Format("idfsSpeciesType is null or idfsSpeciesType = {0}", summaryRow("idfsSpeciesType"))
        End If
        diagnosisView.RowFilter = String.Format("idfsSpeciesType is null or idfsSpeciesType = {0}", summaryRow("idfsSpeciesType"))
        Using diagnosisTable As DataTable = diagnosisView.ToTable(True, "idfsDiagnosis")
            diagnosisTable.PrimaryKey = {diagnosisTable.Columns(0)}
            For i As Integer = view.Count - 1 To 0 Step -1
                If diagnosisTable.Rows.Find(view(i)("idfsDiagnosis")) Is Nothing Then
                    view.Delete(i)
                End If
            Next
            view.EndInit()
            For Each d As DataRow In diagnosisTable.Rows
                If ds.Tables(TableAsSummaryDiagnosis).Select(String.Format("idfsDiagnosis = {0} and idfMonitoringSessionSummary ={1} ", d("idfsDiagnosis"), summaryRow("idfMonitoringSessionSummary"))).Length > 0 Then
                    Continue For
                End If
                Dim diagnosisRow As DataRow = ds.Tables(TableAsSummaryDiagnosis).NewRow
                diagnosisRow("id") = String.Format("{0}.{1}", summaryRow("idfMonitoringSessionSummary"), d("idfsDiagnosis"))
                diagnosisRow("idfsDiagnosis") = d("idfsDiagnosis")
                diagnosisRow("name") = db.Core.LookupCache.GetLookupValue(d("idfsDiagnosis"), LookupTables.LivestockStandardDiagnosis, "name")
                diagnosisRow("idfMonitoringSessionSummary") = summaryRow("idfMonitoringSessionSummary")
                ds.Tables(TableAsSummaryDiagnosis).Rows.Add(diagnosisRow)
                diagnosisRow.AcceptChanges()
            Next
        End Using
        diagnosisView.RowFilter = ""
        Return view
    End Function
    Private m_FarmsToDelete As New List(Of Long)
    Public ReadOnly Property FarmsToDelete As List(Of Long)
        Get
            Return m_FarmsToDelete
        End Get
    End Property

End Class
