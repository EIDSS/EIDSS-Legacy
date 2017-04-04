Imports System.Data


Public Class HumanCaseSamplesDetail_DB
    'Inherits BaseDbService
    Inherits CaseSamples_Db

    Public Const TableTests As String = "Tests"
    'Dim CaseGuid As Guid = Nothing

    Public Sub New()
        MyBase.New()
        ObjectName = "CaseTest"
    End Sub

    Enum TablesEnum
        Materials = 0
        Tests = 1
        ' PartyParticipation = 2
    End Enum

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        m_ID = ID
        Dim ds As New DataSet()
        Dim cmd As IDbCommand = CreateSPCommand("spHumanCaseSamples_SelectDetail")
        AddParam(cmd, "@idfCase", ID)
        AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
        FillDataset(cmd, ds, TableSamples)
        CorrectTable(ds.Tables(0))
        CorrectTable(ds.Tables(1), TableTests)
        CorrectTable(ds.Tables(2), TableCaseActivity)
        CorrectTable(ds.Tables(3), TableSamplesToCollect)

        ClearColumnsAttibutes(ds)
        'TimeUtils.UTC2Local(ds.Tables(TableSamples), "datAccession")
        'Remove for Search Mode'End If
        Dim t As DataTable = ds.Tables(TableCaseActivity)
        If (t.Rows.Count = 0) Then
            Dim cs As DataRow = t.NewRow()
            cs("idfVetCase") = ID
            t.Rows.Add(cs)
        End If

        For Each col As DataColumn In ds.Tables(TableTests).Columns
            ds.Tables(TableTests).Columns(col.ColumnName).ReadOnly = False
        Next
        Return ds
    End Function

End Class
