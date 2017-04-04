Imports eidss.model.Core
Imports bv.common.Core
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports bv.common.Enums
Imports eidss.model.Resources

Public Class AsSessionTableVew_DB
    Inherits BaseDbService
    Public Const TableFarmTableView As String = "FarmTableView"
    Public Const TableSpecies As String = "Species"
    Public Const TableAnimals As String = "Animals"
    Public Const NewAnimalID As Long = -100L

    Public Sub New()
        ObjectName = "AsSessionTableView"
        'Me.UseDatasetCopyInPost = False
    End Sub

    Public Overrides Function GetDetail(ByVal ID As Object) As System.Data.DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spASSessionTableView_SelectDetail")
            AddParam(cmd, "@idfMonitoringSession", ID)
            AddParam(cmd, "@LangID", EidssUserContext.CurrentLanguage)

            FillDataset(cmd, ds, TableFarmTableView)
            CorrectTable(ds.Tables(0), TableFarmTableView)
            CorrectTable(ds.Tables(1), TableSpecies)
            CorrectTable(ds.Tables(2), TableAnimals)
            ClearColumnsAttibutes(ds)
            ds.Tables(TableFarmTableView).Columns("id").AutoIncrement = True
            ds.Tables(TableFarmTableView).Columns("id").AutoIncrementSeed = -1
            ds.Tables(TableFarmTableView).Columns("id").AutoIncrementStep = -1
            ds.Tables(TableFarmTableView).Columns("AnimalName").Expression = "strAnimalCode"
            AddNewAnimalRow(ds.Tables(2))
            m_ID = ID
            Return ds

        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function
    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            ExecPostProcedure("spASSessionTableView_Post", ds.Tables(TableFarmTableView), Connection, transaction, , , , AddressOf TableVewRowUpdated, True)
            If m_FarmsToDelete.Count > 0 Then
                Dim cmd As IDbCommand = CreateSPCommandWithParams("spFarm_Delete", transaction)
                For Each idfFarm As Long In m_FarmsToDelete
                    SetParam(cmd, "@ID", idfFarm)
                    ExecCommand(cmd, Connection, transaction, True)
                Next
                m_FarmsToDelete.Clear()
            End If
            If m_FarmsToUnlink.Count > 0 Then
                Dim cmd As IDbCommand = CreateSPCommandWithParams("spASFarm_Unlink", transaction)
                For Each idfFarm As Long In m_FarmsToUnlink
                    SetParam(cmd, "@idfFarm", idfFarm)
                    ExecCommand(cmd, Connection, transaction, True)
                Next
                m_FarmsToUnlink.Clear()
            End If
            'Delete animal that are not related with any table view record
            Dim animalRows As DataRow() = ds.Tables(TableAnimals).Select()
            For Each animalRow As DataRow In animalRows
                If animalRow.RowState <> DataRowState.Deleted Then
                    If animalRow("idfAnimal") Is DBNull.Value OrElse ds.Tables(TableFarmTableView).Select(String.Format("idfAnimal = {0}", animalRow("idfAnimal"))).Length = 0 Then
                        animalRow.Delete()
                    End If
                End If
            Next
            animalRows = ds.Tables(TableAnimals).Select("", Nothing, DataViewRowState.Deleted)
            For Each animalRow As DataRow In animalRows
                ExecPostProcedure("spASSessionAnimals_Post", animalRow, Connection, transaction, , True)
            Next
            UpdateAnimalsView(ds)

        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function
    Private Sub TableVewRowUpdated(sender As Object, e As SqlRowUpdatedEventArgs)
        If e.StatementType = StatementType.Delete Then
            e.Status = UpdateStatus.Continue
        End If

    End Sub
    Public Function InitNewTableViewRow(row As DataRow) As DataRow
        row("idfMonitoringSession") = ID
        row("idfFarm") = NewIntID()
        row("strFarmCode") = "(new)"
        row("blnNewFarm") = 1
        row("Used") = 0
        Return row
    End Function
    Public Sub UpdateAnimalsView(ds As DataSet)
        ds.Tables(TableAnimals).Clear()
        AddNewAnimalRow(ds.Tables(TableAnimals))
        For Each row As DataRow In ds.Tables(TableFarmTableView).Rows
            If row.RowState <> DataRowState.Deleted Then
                UpdateAnimalsView(ds, row, Nothing)
            End If
        Next
    End Sub

    Private Function AddNewAnimalRow(t As DataTable) As DataRow
        Dim row As DataRow = t.NewRow()
        row("idfAnimal") = NewAnimalID
        row("strAnimalCode") = EidssMessages.Get("newAnimalRecord ")
        t.Rows.InsertAt(row, 0)
        Return row
    End Function

    Public Sub UpdateAnimalsView(ds As DataSet, row As DataRow, oldAnimalID As Object)
        If (row("idfAnimal") Is DBNull.Value) Then
            Return
        End If
        Dim animalRow As DataRow = ds.Tables(TableAnimals).Rows.Find(row("idfAnimal"))
        If animalRow Is Nothing Then
            animalRow = ds.Tables(TableAnimals).NewRow
            animalRow("idfAnimal") = row("idfAnimal")
            ds.Tables(TableAnimals).Rows.Add(animalRow)
        End If
        For Each col As DataColumn In animalRow.Table.Columns
            If col.ColumnName <> "idfAnimal" AndAlso row.Table.Columns.Contains(col.ColumnName) Then
                animalRow(col.ColumnName) = row(col.ColumnName)
            End If
        Next
        animalRow.EndEdit()
        DeleteAnimal(ds, oldAnimalID)
        ds.Tables(TableAnimals).AcceptChanges()
    End Sub
    Public Sub DeleteAnimal(ds As DataSet, animalID As Object)
        If Not Utils.IsEmpty(animalID) AndAlso ds.Tables(TableFarmTableView).Select(String.Format("idfAnimal = {0}", animalID)).Length() = 0 Then
            Dim animalRow As DataRow = ds.Tables(TableAnimals).Rows.Find(animalID)
            If Not animalRow Is Nothing Then
                animalRow.Delete()
            End If
        End If

    End Sub
    Private ReadOnly m_FarmsToDelete As New List(Of Long)
    Public ReadOnly Property FarmsToDelete As List(Of Long)
        Get
            Return m_FarmsToDelete
        End Get
    End Property
    Private ReadOnly m_FarmsToUnlink As New List(Of Long)
    Public ReadOnly Property FarmsToUnlink As List(Of Long)
        Get
            Return m_FarmsToUnlink
        End Get
    End Property
End Class
