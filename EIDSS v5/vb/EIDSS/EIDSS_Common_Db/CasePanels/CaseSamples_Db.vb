Imports System.Data
Imports System.Data.Common

Public Class CaseSamples_Db
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "CaseSamples"
    End Sub

    Public Const TableSamples As String = "CaseSamples"
    Public Const TableCaseActivity As String = "CaseActivity"
    Public Const TableSamplesToCollect As String = "SamplesToCollect"
    Public Const TableVectorSamplesToCollect As String = "VectorSamplesToCollect"

    'Public Const TableCollectedByEmployeeLookup As String = "CollectedByLookup"
    'Public Const TableRegisteredByEmployeeLookup As String = "RegisteredByLookup"
    'Public Const TablePartyLink As String = "PartyLink"
    'Public Const TableContainers As String = "Containers"

    Public Overrides Function GetDetail(ByVal ID As Object) As System.Data.DataSet

        If ID Is Nothing Then
            Return New DataSet
            'Throw New Exception("CaseSamplesDetail service must be initialized with NOT NULL case ID")
        End If
        Dim ds As New DataSet

        Try

            Dim cmd As IDbCommand

            ' SELECT
            cmd = CreateSPCommand("spCaseSamples_SelectDetail")
            AddParam(cmd, "@idfCase", ID)
            AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)

            Dim SamplesAdapter As DbDataAdapter = CreateAdapter(cmd)

            'Fill the main object table
            SamplesAdapter.Fill(ds, TableSamples)
            CorrectTable(ds.Tables(0), TableSamples)
            CorrectTable(ds.Tables(1), TableCaseActivity)
            CorrectTable(ds.Tables(2), TableSamplesToCollect)
            CorrectTable(ds.Tables(3), TableVectorSamplesToCollect)
            ClearColumnsAttibutes(ds)
            TimeUtils.UTC2Local(ds.Tables(TableSamples), "datAccession")
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
        Return Nothing
    End Function

   

    Private Sub ModifyCase(ByVal ds As DataSet, Optional ByVal transaction As IDbTransaction = Nothing)
        ' when creating epi/cs for vet case, ds.Tables(TableCaseActivity) sometimes doesn't has any row
        ' Note: Dirty fix. 
        If (ds.Tables.Contains(TableCaseActivity) = False) Then Exit Sub
        If ds.HasChanges() Then
            Dim row As DataRow = ds.Tables(TableCaseActivity).Rows(0)
            'If row.RowState = DataRowState.Unchanged Then Exit Sub
            Dim command As IDbCommand = CreateSPCommand("spLabSampleReceive_ModifyCase", Connection, transaction)
            AddParam(command, "@idfCase", Me.ID, ParameterDirection.Input)
            AddParam(command, "@strSampleNotes", row("strSampleNotes"), ParameterDirection.Input)
            command.ExecuteNonQuery()
        End If
    End Sub

    Public Overrides Function PostDetail(ByVal ds As System.Data.DataSet, ByVal PostType As Integer, Optional ByVal transaction As System.Data.IDbTransaction = Nothing) As Boolean
        If ds Is Nothing OrElse ds.Tables.Count = 0 Then Return True
        If IgnoreChanges Then Return True
        'Dim dsCopy As DataSet = ds.Copy()
        'SetReadonlyState(ds, True)
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
                    AddParam(cmd, "@idfsSpecimenType", row("idfsSpecimenType"))
                    AddParam(cmd, "@idfParty", row("idfParty"))
                    AddParam(cmd, "@idfCase", row("idfCase"))
                    AddParam(cmd, "@idfMonitoringSession", row("idfMonitoringSession"))
                    AddParam(cmd, "@idfVectorSurveillanceSession", row("idfVectorSurveillanceSession"))
                    AddParam(cmd, "@datFieldCollectionDate", row("datFieldCollectionDate"))
                    AddParam(cmd, "@datFieldSentDate", row("datFieldSentDate"))
                    AddParam(cmd, "@idfFieldCollectedByOffice", row("idfFieldCollectedByOffice"))
                    AddParam(cmd, "@idfFieldCollectedByPerson", row("idfFieldCollectedByPerson"))
                    AddParam(cmd, "@idfTesting", row("idfTesting"))
                    AddParam(cmd, "@idfSendToOffice", row("idfSendToOffice"))
                    If (row.Table.Columns.Contains("idfsBirdStatus")) Then
                        AddParam(cmd, "@idfsBirdStatus", row("idfsBirdStatus"))
                    Else
                        AddTypedParam(cmd, "@idfsBirdStatus", SqlDbType.BigInt)
                    End If
                    cmd.ExecuteNonQuery()
                    Dim id As Object = GetParamValue(cmd, "@idfMaterial")
                    If Not row("idfMaterial").Equals(id) Then
                        row("idfMaterial") = id
                    End If
                ElseIf row.RowState = DataRowState.Modified Then
                    Dim cmd As IDbCommand = CreateSPCommand("spLabSample_Update", Connection, transaction)
                    AddParam(cmd, "@idfMaterial", row("idfMaterial"))
                    AddParam(cmd, "@strFieldBarcode", row("strFieldBarcode"))
                    AddParam(cmd, "@idfsSpecimenType", row("idfsSpecimenType"))
                    AddParam(cmd, "@idfParty", row("idfParty"))
                    AddParam(cmd, "@datFieldCollectionDate", row("datFieldCollectionDate"))
                    AddParam(cmd, "@datFieldSentDate", row("datFieldSentDate"))
                    AddParam(cmd, "@idfFieldCollectedByOffice", row("idfFieldCollectedByOffice"))
                    AddParam(cmd, "@idfFieldCollectedByPerson", row("idfFieldCollectedByPerson"))
                    AddParam(cmd, "@idfTesting", row("idfTesting"))
                    AddParam(cmd, "@idfSendToOffice", row("idfSendToOffice"))
                    If (row.Table.Columns.Contains("idfsBirdStatus")) Then
                        AddParam(cmd, "@idfsBirdStatus", row("idfsBirdStatus"))
                    Else
                        AddTypedParam(cmd, "@idfsBirdStatus", SqlDbType.BigInt)
                    End If
                    cmd.ExecuteNonQuery()
                ElseIf row.RowState = DataRowState.Deleted Then
                    Dim cmd As IDbCommand = CreateSPCommand("spLabSample_Delete", Connection, transaction)
                    AddParam(cmd, "@idfMaterial", row("idfMaterial", DataRowVersion.Original))
                    cmd.ExecuteNonQuery()
                End If
            Next

            Me.ModifyCase(ds, transaction)
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
    Public Sub DeleteSample(ByVal ds As DataSet, ByVal SampleID As Object)
        ' Delete Material Row
        Dim row As DataRow = ds.Tables(TableSamples).Rows.Find(SampleID)
        If Not row Is Nothing Then
            row.Delete()
        End If
    End Sub

    Public Sub DeletePartySamples(ByVal ds As DataSet, ByVal PartyID As Object)
        Dim partyLinkView As DataView = New DataView(ds.Tables(TableSamples))
        partyLinkView.RowFilter = String.Format("idfParty='{0}'", PartyID.ToString)
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
        Dim value As DataTable
        Dim errMsg As ErrorMessage = Nothing

        Dim cmd As IDbCommand = CreateSPCommand("spLabSample_SampleTypeFilter", ConnectionManager.DefaultInstance.Connection)

        AddParam(cmd, "@idfCase", ID)
        AddParam(cmd, "@idfsSpeciesType", speciesType)

        value = ExecTable(cmd)

        Return value
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
End Class
