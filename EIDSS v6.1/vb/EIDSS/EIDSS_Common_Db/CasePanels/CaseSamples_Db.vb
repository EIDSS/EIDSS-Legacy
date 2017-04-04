Imports System.Data
Imports bv.common.Enums

Public Class CaseSamples_Db
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "CaseSamples"
    End Sub

    Public Const TableSamples As String = "CaseSamples"
    Public Const TableCaseActivity As String = "CaseActivity"
    Public Const TableSamplesToCollect As String = "SamplesToCollect"
    Public Const TableVectorSamplesToCollect As String = "VectorSamplesToCollect"
    Public Const TableFiltered As String = "FilteredByDisease"

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet

        If ID Is Nothing Then
            Return New DataSet
        End If
        Dim ds As New DataSet

        Try

            Dim cmd As IDbCommand

            ' SELECT
            cmd = CreateSPCommand("spCaseSamples_SelectDetail")
            AddParam(cmd, "@idfCase", ID)
            AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
            FillDataset(cmd, ds, TableSamples)
            CorrectTable(ds.Tables(0), TableSamples)
            CorrectTable(ds.Tables(1), TableCaseActivity)
            CorrectTable(ds.Tables(2), TableSamplesToCollect)
            CorrectTable(ds.Tables(3), TableVectorSamplesToCollect)
            ClearColumnsAttibutes(ds)
            'TimeUtils.UTC2Local(ds.Tables(TableSamples), "datAccession")
            Dim t As DataTable = ds.Tables(TableCaseActivity)
            If (t.Rows.Count = 0) Then
                Dim cs As DataRow = t.NewRow()
                cs("idfVetCase") = ID
                t.Rows.Add(cs)
            End If


            ds.EnforceConstraints = False
            m_ID = ID
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function



    Private Sub ModifyCase(ByVal ds As DataSet, Optional ByVal transaction As IDbTransaction = Nothing)
        ' when creating epi/cs for vet case, ds.Tables(TableCaseActivity) sometimes doesn't has any row
        ' Note: Dirty fix. 
        If (ds.Tables.Contains(TableCaseActivity) = False) Then Exit Sub
        If ds.HasChanges() Then
            Dim row As DataRow = ds.Tables(TableCaseActivity).Rows(0)
            Dim command As IDbCommand = CreateSPCommand("spLabSampleReceive_ModifyCase", Connection, transaction)
            AddParam(command, "@idfCase", ID, ParameterDirection.Input)
            AddParam(command, "@strSampleNotes", row("strSampleNotes"), ParameterDirection.Input)
            ExecCommand(command, command.Connection, transaction, True)
        End If
    End Sub

    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing OrElse ds.Tables.Count = 0 Then Return True
        If IgnoreChanges Then Return True
        Try
            'ExecPostProcedure("spCaseSamples_Post", ds.Tables(TableSamples), Connection, transaction)
            For Each row As DataRow In ds.Tables(TableSamples).Rows
                If row.RowState = DataRowState.Added Then
                    Dim cmd As IDbCommand = CreateSPCommand("spLabSample_Create", Connection, transaction)
                    'AddTypedParam(cmd1, "@Action", SqlDbType.Int)
                    'AddParam(cmd, "@idfCase", m_ID)
                    If (row("idfMaterial") Is DBNull.Value) Then
                        AddTypedParam(cmd, "@idfMaterial", SqlDbType.BigInt, ParameterDirection.InputOutput)
                    Else
                        AddParam(cmd, "@idfMaterial", row("idfMaterial"), ParameterDirection.InputOutput)
                    End If
                    AddParam(cmd, "@strFieldBarcode", row("strFieldBarcode"))
                    AddParam(cmd, "@idfsSampleType", row("idfsSampleType"))
                    AddParam(cmd, "@idfParty", row("idfParty"))
                    AddParam(cmd, "@idfCase", row("idfCase"))
                    AddParam(cmd, "@idfMonitoringSession", row("idfMonitoringSession"))
                    AddParam(cmd, "@idfVectorSurveillanceSession", row("idfVectorSurveillanceSession"))
                    AddParam(cmd, "@datFieldCollectionDate", row("datFieldCollectionDate"))
                    AddParam(cmd, "@datFieldSentDate", row("datFieldSentDate"))
                    AddParam(cmd, "@idfFieldCollectedByOffice", row("idfFieldCollectedByOffice"))
                    AddParam(cmd, "@idfFieldCollectedByPerson", row("idfFieldCollectedByPerson"))
                    AddParam(cmd, "@idfMainTest", row("idfMainTest"))
                    AddParam(cmd, "@idfSendToOffice", row("idfSendToOffice"))
                    If (row.Table.Columns.Contains("idfsBirdStatus")) Then
                        AddParam(cmd, "@idfsBirdStatus", row("idfsBirdStatus"))
                    Else
                        AddTypedParam(cmd, "@idfsBirdStatus", SqlDbType.BigInt)
                    End If
                    ExecCommand(cmd, cmd.Connection, transaction, True)
                    Dim idfMaterial As Object = GetParamValue(cmd, "@idfMaterial")
                    If Not row("idfMaterial").Equals(idfMaterial) Then
                        row("idfMaterial") = idfMaterial
                    End If
                ElseIf row.RowState = DataRowState.Modified Then
                    Dim cmd As IDbCommand = CreateSPCommand("spLabSample_Update", Connection, transaction)
                    AddParam(cmd, "@idfMaterial", row("idfMaterial"))
                    AddParam(cmd, "@strFieldBarcode", row("strFieldBarcode"))
                    AddParam(cmd, "@idfsSampleType", row("idfsSampleType"))
                    AddParam(cmd, "@idfParty", row("idfParty"))
                    AddParam(cmd, "@datFieldCollectionDate", row("datFieldCollectionDate"))
                    AddParam(cmd, "@datFieldSentDate", row("datFieldSentDate"))
                    AddParam(cmd, "@idfFieldCollectedByOffice", row("idfFieldCollectedByOffice"))
                    AddParam(cmd, "@idfFieldCollectedByPerson", row("idfFieldCollectedByPerson"))
                    AddParam(cmd, "@idfMainTest", row("idfMainTest"))
                    AddParam(cmd, "@idfSendToOffice", row("idfSendToOffice"))
                    If (row.Table.Columns.Contains("idfsBirdStatus")) Then
                        AddParam(cmd, "@idfsBirdStatus", row("idfsBirdStatus"))
                    Else
                        AddTypedParam(cmd, "@idfsBirdStatus", SqlDbType.BigInt)
                    End If
                    ExecCommand(cmd, cmd.Connection, transaction, True)
                ElseIf row.RowState = DataRowState.Deleted Then
                    Dim cmd As IDbCommand = CreateSPCommand("spLabSample_Delete", Connection, transaction)
                    AddParam(cmd, "@idfMaterial", row("idfMaterial", DataRowVersion.Original))
                    ExecCommand(cmd, cmd.Connection, transaction, True)
                End If
            Next

            ModifyCase(ds, transaction)
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        Finally
            'DbDisposeHelper.DisposeDataset(dsCopy)
            'SetReadonlyState(ds, False)
        End Try
        Return True
    End Function

    Public Function CreateSample(ByVal ds As DataSet, Optional ByVal partyID As Object = Nothing, Optional ByVal sourceRow As DataRow = Nothing, Optional materialID As Object = Nothing) As DataRow
        Dim materialRow As DataRow = ds.Tables(TableSamples).NewRow()
        InitNewRow(materialRow, partyID, sourceRow, materialID)
        ds.EnforceConstraints = False
        ds.Tables(TableSamples).Rows.Add(materialRow)
        Return materialRow
    End Function


    Public Overridable Sub LinkSample(row As DataRow, parentID As Object)
        row("idfCase") = parentID
    End Sub
    Public Sub DeleteSample(ByVal ds As DataSet, ByVal sampleID As Object)
        ' Delete Material Row
        Dim row As DataRow = ds.Tables(TableSamples).Rows.Find(sampleID)
        If Not row Is Nothing Then
            row.Delete()
        End If
    End Sub

    Public Sub DeletePartySamples(ByVal ds As DataSet, ByVal partyID As Object)
        Dim partyLinkView As DataView = New DataView(ds.Tables(TableSamples))
        partyLinkView.RowFilter = String.Format("idfParty='{0}'", partyID.ToString)
        For Each row As DataRowView In partyLinkView
            DeleteSample(ds, row.Row("idfMaterial"))
        Next
    End Sub

    Public Function CanDeleteSample(ByVal row As DataRow) As Boolean
        If row.RowState <> DataRowState.Added AndAlso Utils.Str(row("Used")) = "1" Then
            Return False
        End If
    End Function
    Public Shared Function CheckAccessIn(ByVal materialId As Long) As Boolean
        Dim value As Object
        Dim errMsg As ErrorMessage = Nothing

        Dim cmd As IDbCommand = CreateSPCommand("spLabSample_CheckAccession", ConnectionManager.DefaultInstance.Connection)
        AddParam(cmd, "@idfMaterial", materialId, ParameterDirection.Input)
        value = ExecScalar(cmd, cmd.Connection, errMsg)
        If (Utils.IsEmpty(value)) Then
            'can delete
            Return True
        Else
            'cannot delete
            Return False
        End If

    End Function
    Public Shared Function CheckAccessionForSpecies(ByVal speciesId As Long) As Boolean
        Dim value As Object
        Dim errMsg As ErrorMessage = Nothing

        Dim cmd As IDbCommand = CreateSPCommand("spLabSample_CheckAccessionForSpecies", ConnectionManager.DefaultInstance.Connection)
        AddParam(cmd, "@idfSpecies", speciesId, ParameterDirection.Input)
        value = ExecScalar(cmd, cmd.Connection, errMsg)
        If Not Utils.IsEmpty(value) AndAlso CLng(value) = 1 Then
            'cannot delete
            Return False
        Else
            'can delete
            Return True
        End If
    End Function


    Public Function GetFilteredCase(ByVal speciesType As Long) As DataTable
        Dim cmd As IDbCommand = CreateSPCommand("spLabSample_SampleTypeFilter", ConnectionManager.DefaultInstance.Connection)

        AddParam(cmd, "@idfCase", ID)
        AddParam(cmd, "@idfsSpeciesType", speciesType)
        Try
            Return ExecTable(cmd)
        Catch ex As Exception
            Dbg.Debug("spLabSample_SampleTypeFilter error: {0}", ex)
            Return Nothing
        End Try
    End Function

    Public Sub InitNewRow(ByVal materialRow As DataRow, partyID As Object, sourceRow As DataRow, Optional materialID As Object = Nothing)
        If materialID Is Nothing Then
            materialRow("idfMaterial") = NewIntID()
        Else
            materialRow("idfMaterial") = materialID
        End If
        LinkSample(materialRow, ID)
        Dim collectionDate As Object = DBNull.Value
        If (Not sourceRow Is Nothing) Then
            collectionDate = sourceRow("datFieldCollectionDate")
            materialRow("idfSendToOffice") = sourceRow("idfSendToOffice")
            materialRow("idfFieldCollectedByPerson") = sourceRow("idfFieldCollectedByPerson")
            materialRow("idfFieldCollectedByOffice") = sourceRow("idfFieldCollectedByOffice")
        End If
        If Utils.IsEmpty(collectionDate) Then
            collectionDate = DateTime.Now.Date
        End If
        materialRow("datFieldCollectionDate") = collectionDate
        If Not Utils.IsEmpty(partyID) Then materialRow("idfParty") = partyID
    End Sub

    Public Shared Sub PrepareFilteredSamples(diagnosisList() As Long, ds As DataSet, samplesList As DataView)

        If diagnosisList Is Nothing OrElse diagnosisList.Length = 0 Then
            If ds.Tables.Contains(TableFiltered) Then
                ds.Tables.Remove(TableFiltered)
            End If
            Exit Sub
        End If

        Dim ref As DataTable = samplesList.Table
        Dim table As DataTable
        If ds.Tables.Contains(TableFiltered) Then
            table = ds.Tables(TableFiltered)
            table.Rows.Clear()
        Else
            table = ref.Clone()
            table.TableName = TableFiltered
            ds.Tables.Add(table)
        End If

        Dim filter As String = ""
        For Each diag As Long In diagnosisList
            If filter.Length > 0 Then filter = filter + " OR "
            filter = filter + "idfsDiagnosis=" + diag.ToString()
        Next

        Dim view As DataView = New DataView(ds.Tables(TableSamplesToCollect))
        view.RowFilter = filter
        view.Sort = "idfsReference"

        For Each row As DataRow In ref.Rows
            If view.FindRows(row("idfsReference")).Length > 0 Then
                table.Rows.Add(row.ItemArray)
            End If
        Next
        table.AcceptChanges()
    End Sub

End Class
