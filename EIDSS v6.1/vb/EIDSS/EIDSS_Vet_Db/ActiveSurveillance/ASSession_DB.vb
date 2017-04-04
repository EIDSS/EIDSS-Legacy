Imports bv.common.db.Core
Imports System.Collections.Generic
Imports bv.common.Core
Imports bv.common.Configuration
Imports EIDSS.model.Core
Imports EIDSS.model.Enums
Imports bv.common.Enums
Imports System.Data.SqlClient
Imports System.Threading

Public Class ASSession_DB
    Inherits BaseDbService
    Public Const TableSession As String = "AsSession"
    Public Const TableDiagnosis As String = "Diagnosis"
    Public Const TableCampaignDiagnosis As String = "CampaignDiagnosis"
    Public Const TableFarms As String = "Farms"
    Public Const TableFarmsTree As String = "FarmsTree"
    Public Const TableAnimals As String = "Animals"
    Public Const TableActions As String = "Actions"
    Public Const TableSpecies As String = "Species"
    Public Const TableCases As String = "Cases"
    Public Sub New()
        ObjectName = "AsSession"
        UseDatasetCopyInPost = False
    End Sub

    Private m_TableView As Boolean = False
    Public Property TableView As Boolean
        Get
            Return m_TableView

        End Get
        Set(value As Boolean)
            m_TableView = value
        End Set
    End Property
    Public Overrides Function GetDetail(ByVal ID As Object) As System.Data.DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spASSession_SelectDetail")
            AddParam(cmd, "@idfMonitoringSession", ID)

            FillDataset(cmd, ds, TableSession)
            CorrectTable(ds.Tables(0), TableSession)
            CorrectTable(ds.Tables(1), TableDiagnosis)
            CorrectTable(ds.Tables(2), TableFarms)
            CorrectTable(ds.Tables(3), TableFarmsTree)
            CorrectTable(ds.Tables(4), TableAnimals)
            CorrectTable(ds.Tables(5), TableActions)
            Dim ds1 As DataSet
            If ds.Tables(TableSession).Rows.Count > 0 Then
                ds1 = PopulateCampaignData(ds.Tables(TableSession).Rows(0)("idfCampaign"))
            Else
                ds1 = PopulateCampaignData(DBNull.Value)
            End If
            ds.Tables.Add(ds1.Tables(1).Copy())
            CorrectTable(ds.Tables(6), TableCampaignDiagnosis)
            If ID Is Nothing Then
                ID = NewIntID()
                Dim r As DataRow = ds.Tables(TableSession).NewRow
                r("idfMonitoringSession") = ID
                r("strMonitoringSessionID") = "(new)"
                r("idfsMonitoringSessionStatus") = CLng(ASSessionStatus.Open)
                r("idfsSite") = model.Core.EidssSiteContext.Instance.SiteID
                r("idfPersonEnteredBy") = model.Core.EidssUserContext.User.EmployeeID
                r("datEnteredDate") = DateTime.Now
                r("idfsCountry") = model.Core.EidssSiteContext.Instance.CountryID
                ds.Tables(TableSession).Rows.Add(r)
                ds.EnforceConstraints = False
                m_IsNewObject = True
            Else
                m_IsNewObject = False
            End If
            m_ID = ID
            ds.Tables(TableDiagnosis).Columns("idfMonitoringSession").DefaultValue = ID
            Dim order As Object = ds.Tables(TableDiagnosis).Compute("max(intOrder)", "")
            If Utils.IsEmpty(order) Then
                order = 0
            Else
                order = CInt(order) + 1
            End If
            cmd = CreateSPCommand("spASSession_SelectSpecies", Connection)
            AddParam(cmd, "@idfMonitoringSession", ID)
            AddParam(cmd, "@LangID", EidssUserContext.CurrentLanguage)
            FillDataset(cmd, ds, TableSpecies)
            CorrectTable(ds.Tables(TableSpecies), TableSpecies)
            ds.Tables(TableSpecies).Columns.Add("name")
            ds.Tables(TableSpecies).Columns("name").Expression = "strHerdCode + ' / ' + strSpeciesName "
            RefreshCaseInfo(ds, Nothing)
            ClearColumnsAttibutes(ds)
            ds.Tables(TableFarms).Columns("idfFarm").AutoIncrement = True
            ds.Tables(TableFarms).Columns("idfFarm").AutoIncrementSeed = -1
            ds.Tables(TableFarms).Columns("idfFarm").AutoIncrementStep = -1
            ds.Tables(TableActions).Columns("idfMonitoringSessionAction").AutoIncrement = True
            ds.Tables(TableActions).Columns("idfMonitoringSessionAction").AutoIncrementSeed = -1
            ds.Tables(TableActions).Columns("idfMonitoringSessionAction").AutoIncrementStep = -1
            ds.Tables(TableDiagnosis).Columns("idfMonitoringSessionToDiagnosis").AutoIncrementSeed = -1
            ds.Tables(TableDiagnosis).Columns("idfMonitoringSessionToDiagnosis").AutoIncrementStep = -1
            ds.Tables(TableDiagnosis).Columns("idfMonitoringSessionToDiagnosis").AutoIncrement = True
            ds.Tables(TableDiagnosis).Columns("intOrder").AutoIncrementSeed = CInt(order)
            ds.Tables(TableDiagnosis).Columns("intOrder").AutoIncrementStep = 1
            ds.Tables(TableDiagnosis).Columns("intOrder").AutoIncrement = True

            Return ds

        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function
    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            If IsNewObject Then
                m_IsNewObject = False
                AddEvent(EventType.AsSessionCreatedLocal, , False)
            ElseIf ds.Tables(TableSession).Rows.Count > 0 Then
                Dim r As DataRow = ds.Tables(TableSession).Rows(0)
                If r.HasVersion(DataRowVersion.Original) Then
                    If (Not r("idfsMonitoringSessionStatus").Equals(r("idfsMonitoringSessionStatus", DataRowVersion.Original))) AndAlso r("idfsMonitoringSessionStatus", DataRowVersion.Original).Equals(CLng(ASSessionStatus.Closed)) Then
                        AddEvent(EventType.ClosedAsSessionReopenedLocal, , False)
                    End If
                End If
            End If
            ExecPostProcedure("spASSession_Post", ds.Tables(TableSession), Connection, transaction)
            ExecPostProcedure("spASSessionDiagnosis_Post", ds.Tables(TableDiagnosis), Connection, transaction)
            ExecPostProcedure("spASSessionFarms_Post", ds.Tables(TableFarms), Connection, transaction)
            ExecPostProcedure("spASFarmTree_Post", ds.Tables(TableFarmsTree), Connection, transaction)
            ExecPostProcedure("spASSessionAnimals_Post", ds.Tables(TableAnimals), Connection, transaction)
            ExecPostProcedure("spAsSessionAction_Post", ds.Tables(TableActions), Connection, transaction)
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
    Private Sub PostFarmTreeInTransaction(ds As DataSet, farmID As Object, repeatAfterDeadLock As Boolean)
        If (Connection.State <> ConnectionState.Open) Then
            Connection.Open()
        End If
        Dim transaction As IDbTransaction = Connection.BeginTransaction
        Try
            Dim filter As String = String.Format("idfFarm = {0}", farmID)
            ExecPostProcedure("spASSessionFarms_Post", ds.Tables(TableFarms), Connection, transaction, , , filter)
            Dim rows As DataRow() = ds.Tables(TableFarms).Select(filter)
            For Each row As DataRow In rows
                row.SetModified()
            Next
            ExecPostProcedure("spASFarmTree_Post", ds.Tables(TableFarmsTree), Connection, transaction, , , filter)
            rows = ds.Tables(TableFarmsTree).Select(filter)
            For Each row As DataRow In rows
                row.SetModified()
            Next
            transaction.Commit()
        Catch ex As SqlException
            transaction.Rollback()
            If (ex.Number = 1205 AndAlso repeatAfterDeadLock) Then
                Thread.Sleep(BaseSettings.DeadlockDelay)
                PostFarmTreeInTransaction(ds, farmID, False)
                Return
            End If
            Throw
        Finally
            Connection.Close()
        End Try
    End Sub

    Public Function PostFarmTree(ds As DataSet, farmID As Object) As Boolean

        If ds Is Nothing Then Return True
        SyncLock (Connection)
            Try
                PostFarmTreeInTransaction(ds, farmID, True)
            Catch ex As Exception
                m_Error = New ErrorMessage(StandardError.PostError, ex)
                Return False
            End Try
            Return True
        End SyncLock
    End Function
    Public Function PopulateCampaignData(ByVal campaignID As Object) As DataSet
        Dim cmd As IDbCommand = CreateSPCommand("spASSession_PopulateCampaignData")
        AddParam(cmd, "@idfCampaign", campaignID)
        Try
            Dim ds As DataSet = ExecDataSet(cmd)
            Return ds
        Catch ex As Exception
            m_Error = New EIDSSErrorMessage(StandardError.StoredProcedureError, ex)
            Return Nothing
        End Try
    End Function
    Public Function IsCampaignContainsDiagnosis(ByVal diagnosisID As Object, ByVal campaignID As Object) As Boolean
        If Utils.IsEmpty(campaignID) OrElse Utils.IsEmpty(diagnosisID) Then
            Return True
        End If
        Dim cmd As IDbCommand = CreateSPCommand("spASCampaign_ContainsDiagnosis")
        StoredProcParamsCache.CreateParameters(cmd)
        SetParam(cmd, "@idfCampaign", campaignID)
        SetParam(cmd, "@idfsDiagnosis", diagnosisID)
        ExecCommand(cmd, cmd.Connection, , True)
        Dim ret As Object = GetParamValue(cmd, "@RETURN_VALUE")
        If Not Utils.IsEmpty(ret) AndAlso ret.Equals(1) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function PopulateFarmTreeData(ByVal farmID As Object, ByVal targetFarmID As Object) As DataTable
        Try
            Return BaseFarmTree_DB.PopulateFarmTreeData(farmID, targetFarmID, HACode.Livestock)
        Catch ex As Exception
            m_Error = New EIDSSErrorMessage(StandardError.StoredProcedureError, ex)
            Return Nothing
        End Try
    End Function
    Public Shared Function CreateRootFarmCopy(ByVal rootFarmID As Object, sessionID As Object) As Object
        Dim cmd As IDbCommand = CreateSPCommand("spFarm_CopyRootToNormal", ConnectionManager.DefaultInstance.Connection)
        StoredProcParamsCache.CreateParameters(cmd)
        SetParam(cmd, "@idfRootFarm", rootFarmID)
        SetParam(cmd, "@idfMonitoringSession", sessionID)
        'SetParam(cmd, "@blnCopyFramTree", True)
        ExecCommand(cmd, ConnectionManager.DefaultInstance.Connection, Nothing, True)
        Return GetParamValue(cmd, "@idfTargetFarm")
    End Function
    Public Shared Function DeleteRootFarmCopy(ByVal farmID As Object) As Boolean
        Dim cmd As IDbCommand = CreateSPCommand("spFarm_Delete", ConnectionManager.DefaultInstance.Connection)
        StoredProcParamsCache.CreateParameters(cmd)
        SetParam(cmd, "@ID", farmID)
        ExecCommand(cmd, ConnectionManager.DefaultInstance.Connection, Nothing, True)
        Return True
    End Function

    Public Function PopulateFarmData(ByVal farmID As Object) As DataTable
        Dim cmd As IDbCommand = CreateSPCommand("spASSession_PopulateFarmData")
        AddParam(cmd, "@idfFarm", farmID)
        Try
            Dim dt As New DataTable
            FillTable(cmd, dt)
            CorrectTable(dt, TableFarms)
            Return dt
        Catch ex As Exception
            m_Error = New EIDSSErrorMessage(StandardError.StoredProcedureError, ex)
            Return Nothing
        End Try
    End Function
    Public Sub MergeFarmData(ByVal row As DataRow, ByVal table As DataTable)
        If Not table Is Nothing AndAlso table.Rows.Count > 0 Then
            MergeFarmData(row, table.Rows(0))
        End If
    End Sub
    Public Sub MergeFarmData(ByVal targetRow As DataRow, ByVal sourceRow As DataRow)
        If sourceRow("idfRootFarm") Is DBNull.Value AndAlso Not sourceRow("idfFarm").Equals(targetRow("idfFarm")) Then
            targetRow("idfRootFarm") = sourceRow("idfFarm")
        Else
            targetRow("idfRootFarm") = sourceRow("idfRootFarm")
        End If
        targetRow("strFarmCode") = sourceRow("strFarmCode")
        targetRow("strNationalName") = sourceRow("strNationalName")
        If (sourceRow.Table.Columns.Contains("strOwnerName")) Then
            targetRow("strOwnerName") = sourceRow("strOwnerName")
        Else
            targetRow("strOwnerName") = Utils.Join(" ", New Object() {sourceRow("strLastName"), sourceRow("strFirstName"), sourceRow("strSecondName")})
        End If
        targetRow("idfsOwnershipStructure") = sourceRow("idfsOwnershipStructure")
        targetRow("idfsLivestockProductionType") = sourceRow("idfsLivestockProductionType")
        targetRow("idfMonitoringSession") = m_ID
    End Sub

    Public Function AddASFarm(ByVal sourceRow As DataRow, ByVal ds As DataSet) As DataRow
        Dim newRow As DataRow = ds.Tables(TableFarms).NewRow
        newRow("idfFarm") = sourceRow("idfFarm")
        MergeFarmData(newRow, sourceRow)
        ds.Tables(TableFarms).Rows.Add(newRow)
        Return newRow
    End Function

    Public Function AddHerd(ByVal row As DataRow) As DataRow
        Dim newRow As DataRow = row.Table.NewRow
        newRow("idfParty") = NewIntID()
        newRow("idfsPartyType") = CLng(PartyType.Herd)
        newRow("idfParentParty") = row("idfParty")
        newRow("idfMonitoringSession") = m_ID
        newRow("strName") = GetNewVirtualBarcode(row.Table, "strName")
        newRow("idfFarm") = row("idfFarm")
        row.Table.Rows.Add(newRow)
        Return newRow
    End Function
    Public Function AddHerdSpieces(ByVal row As DataRow) As DataRow
        Dim newRow As DataRow = row.Table.NewRow
        newRow("idfParty") = NewIntID()
        newRow("idfsPartyType") = CLng(PartyType.Species)
        newRow("idfParentParty") = row("idfParty")
        newRow("idfMonitoringSession") = m_ID
        newRow("idfFarm") = row("idfFarm")
        row.Table.Rows.Add(newRow)
        Return newRow
    End Function
    Public Function AddAnimal(ByVal speciesRow As DataRow, Optional ByVal animalAge As Object = Nothing, Optional ByVal animalGender As Object = Nothing, Optional ByVal animalCode As Object = Nothing, Optional farmCode As Object = Nothing) As DataRow
        Dim animalTable As DataTable = speciesRow.Table.DataSet.Tables(TableAnimals)
        Dim newRow As DataRow = animalTable.NewRow
        newRow("idfAnimal") = NewIntID()
        newRow("idfSpecies") = speciesRow("idfParty")
        newRow("idfsSpeciesType") = CLng(speciesRow("strName"))
        newRow("idfMonitoringSession") = m_ID
        If Not animalAge Is Nothing Then
            newRow("idfsAnimalAge") = animalAge
        End If
        If Not animalGender Is Nothing Then
            newRow("idfsAnimalGender") = animalGender
        End If
        If Not animalCode Is Nothing Then
            newRow("strAnimalCode") = animalCode
        Else
            newRow("strAnimalCode") = GetNewVirtualBarcode(animalTable, "strAnimalCode")
        End If
        If Not farmCode Is Nothing Then
            newRow("strFarmCode") = farmCode
        End If
        animalTable.Rows.Add(newRow)
        Return newRow
    End Function

    Private Function CreateCaseInTransaction(cmd As IDbCommand, ByRef result As Integer, repeatAfterDeadLock As Boolean) As Long()
        If cmd.Connection.State <> ConnectionState.Open Then
            cmd.Connection.Open()
        End If
        Dim transaction As IDbTransaction = cmd.Connection.BeginTransaction
        Try
            cmd.Transaction = transaction
            cmd.ExecuteNonQuery()
            transaction.Commit()
            transaction = Nothing
            result = CInt(GetParamValue(cmd, "@RETURN_VALUE"))
            Dim caseList As String() = Utils.Str(GetParamValue(cmd, "@CasesList")).Split(","c)
            If caseList.Length > 0 AndAlso caseList(0) <> "" Then
                Return Array.ConvertAll(caseList, New Converter(Of String, Long)(AddressOf ToLong))
            Else
                Return New Long() {}
            End If
        Catch e As SqlException
            If Not transaction Is Nothing Then
                If Not transaction.Connection Is Nothing Then
                    transaction.Rollback()
                End If
            End If
            If (e.Number = 1205) AndAlso repeatAfterDeadLock Then
                Thread.Sleep(BaseSettings.DeadlockDelay)
                Return CreateCaseInTransaction(cmd, result, False)
            End If
            Throw
        Finally
            Connection.Close()
        End Try
    End Function

    Public Function CreateCase(ByVal farmID As Long, ByRef result As Integer) As Long()
        Dim cmd As IDbCommand = CreateSPCommand("spASSession_CreateCase")
        StoredProcParamsCache.CreateParameters(cmd)
        SetParam(cmd, "@idfFarm", farmID)
        SetParam(cmd, "@idfPersonEnteredBy", model.Core.EidssUserContext.User.EmployeeID)
        SyncLock Connection
            Try
                Return CreateCaseInTransaction(cmd, result, True)
            Catch ex As Exception
                m_Error = New ErrorMessage(StandardError.PostError, ex)
                Return Nothing
            End Try
        End SyncLock
    End Function
    Private Function ToLong(ByVal str As String) As Long
        Return CLng(str)
    End Function
    Public Sub CreateAnimalCopy(ByVal animalRow As DataRow, ByVal samplesList As DataView, ByVal copyCount As Integer)
        While copyCount > 0
            Dim newAnimalRow As DataRow = animalRow.Table.NewRow
            newAnimalRow("idfAnimal") = NewIntID()
            newAnimalRow("idfSpecies") = animalRow("idfSpecies")
            newAnimalRow("idfsSpeciesType") = animalRow("idfsSpeciesType")
            newAnimalRow("idfMonitoringSession") = m_ID
            newAnimalRow("idfsAnimalAge") = animalRow("idfsAnimalAge")
            newAnimalRow("idfsAnimalGender") = animalRow("idfsAnimalGender")
            newAnimalRow("strColor") = animalRow("strColor")
            newAnimalRow("strFarmCode") = animalRow("strFarmCode")
            newAnimalRow("strAnimalCode") = GetNewVirtualBarcode(animalRow.Table, "strAnimalCode")
            animalRow.Table.Rows.Add(newAnimalRow)
            For Each sampleRow As DataRowView In samplesList
                Dim newSampleRow As DataRow = samplesList.Table.NewRow
                newSampleRow("idfMaterial") = NewIntID()
                newSampleRow("idfsSampleType") = sampleRow("idfsSampleType")
                newSampleRow("idfParty") = newAnimalRow("idfAnimal")
                newSampleRow("idfMonitoringSession") = m_ID
                newSampleRow("datFieldCollectionDate") = sampleRow("datFieldCollectionDate")
                samplesList.Table.Rows.Add(newSampleRow)
            Next
            copyCount -= 1
        End While

    End Sub

    Public Function AddActionRecord(ByVal ds As DataSet) As DataRow
        Dim r As DataRow
        With ds.Tables(TableActions)
            ds.EnforceConstraints = False
            r = .NewRow()
            InitActionRow(r)
            .Rows.Add(r)
        End With
        Return r
    End Function
    Public Sub InitActionRow(ByVal row As DataRow)
        row("idfMonitoringSession") = m_ID
        row("datActionDate") = DateTime.Now
        row("idfPersonEnteredBy") = model.Core.EidssUserContext.User.EmployeeID
        row("idfsMonitoringSessionActionStatus") = CLng(AsSessionActionStatus.Open)
    End Sub

    Public Function ValidateNewSpecies(ByVal row As DataRow, ByVal speciesName As String) As Boolean
        If Not CLng(PartyType.Species).Equals(row("idfsPartyType")) Then Return True
        If row.Table.Select(String.Format("idfParentParty={0} and strName='{1}' and idfParty<>{2}", row("idfParentParty"), speciesName, row("idfParty"))).Length > 0 Then
            Return False
        End If
        Return True
    End Function
    Public Shared Sub PopulateFarmSpecies(speciesTable As DataTable, sourceFarmId As Object)
        Dim cmd As IDbCommand = CreateSPCommand("spASSession_SelectSpecies", ConnectionManager.DefaultInstance.Connection)
        AddTypedParam(cmd, "@idfMonitoringSession", SqlDbType.BigInt)
        AddParam(cmd, "@idfFarm", sourceFarmId)
        AddParam(cmd, "@LangID", EidssUserContext.CurrentLanguage)
        Using dt As New DataTable
            FillTable(cmd, dt)
            speciesTable.Merge(dt)
        End Using
    End Sub

    Sub RefreshCaseInfo(ds As DataSet, testValidationTable As DataTable)
        Dim cmd As IDbCommand = CreateSPCommand("spASSessionCases_SelectDetail", ConnectionManager.DefaultInstance.Connection)
        AddParam(cmd, "@idfMonitoringSession", ID)
        AddParam(cmd, "@LangID", EidssUserContext.CurrentLanguage)
        If (ds.Tables.Contains(TableCases)) Then
            Using dt As New DataTable
                FillTable(cmd, dt)
                CorrectTable(dt, TableCases)
                ds.Merge(dt)
            End Using
        Else
            FillDataset(cmd, ds, TableCases)
            CorrectTable(ds.Tables(TableCases), )
        End If
        If testValidationTable Is Nothing Then
            Return
        End If
        cmd = CreateSPCommand("[spCaseTestsValidation_SelectDetail]", ConnectionManager.DefaultInstance.Connection)
        AddParam(cmd, "@idfCase", ID)
        AddParam(cmd, "@LangID", EidssUserContext.CurrentLanguage)
        Using dt As New DataTable
            FillTable(cmd, dt)
            CorrectTable(dt)
            For Each row As DataRow In testValidationTable.Rows
                Dim r As DataRow = dt.Rows.Find(row("idfTestValidation"))
                If (Not r Is Nothing AndAlso Not r("blnCaseCreated").Equals(row("blnCaseCreated"))) Then
                    row("blnCaseCreated") = r("blnCaseCreated")
                End If
            Next
        End Using

    End Sub
    Private ReadOnly m_FarmsToDelete As New List(Of Long)
    Public ReadOnly Property FarmsToDelete As List(Of Long)
        Get
            Return m_FarmsToDelete
        End Get
    End Property
    Public Shared Function ValidateDiagnosis(ByVal table As DataTable, ByVal idfCampaign As Object) As Boolean
        If Utils.IsEmpty(idfCampaign) Then
            Return True
        End If
        Dim cmd As IDbCommand = CreateSPCommand("spAsSession_ValidateDiagnosisRecord", ConnectionManager.DefaultInstance.Connection)
        StoredProcParamsCache.CreateParameters(cmd)
        SetParam(cmd, "@idfCampaign", idfCampaign)
        For Each row As DataRow In table.Rows
            If row.RowState = DataRowState.Deleted OrElse row.RowState = DataRowState.Unchanged Then
                Continue For
            End If
            If Not ValidateDiagnosisRow(cmd, row, idfCampaign, False) Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Shared Function ValidateDiagnosisRow(ByVal row As DataRow, ByVal idfCampaign As Object, validateUnchangedRow As Boolean) As Boolean
        If Utils.IsEmpty(idfCampaign) Then
            Return True
        End If
        Dim cmd As IDbCommand = CreateSPCommand("spAsSession_ValidateDiagnosisRecord", ConnectionManager.DefaultInstance.Connection)
        StoredProcParamsCache.CreateParameters(cmd)
        Return ValidateDiagnosisRow(cmd, row, idfCampaign, validateUnchangedRow)
    End Function

    Private Shared Function ValidateDiagnosisRow(cmd As IDbCommand, ByVal row As DataRow, ByVal idfCampaign As Object, validateUnchangedRow As Boolean) As Boolean
        SetParam(cmd, "@idfCampaign", idfCampaign)
        If row.RowState = DataRowState.Deleted OrElse (Not validateUnchangedRow AndAlso row.RowState = DataRowState.Unchanged) Then
            Return True
        End If
        SetParam(cmd, "@idfsDiagnosis", row("idfsDiagnosis"))
        SetParam(cmd, "@idfsSpeciesType", row("idfsSpeciesType"))
        SetParam(cmd, "@idfsSampleType", row("idfsSampleType"))
        ExecCommand(cmd, ConnectionManager.DefaultInstance.Connection, Nothing, True)
        If CInt(GetParamValue(cmd, "@RETURN_VALUE")) = 0 Then
            Return False
        End If
        Return True
    End Function
End Class
