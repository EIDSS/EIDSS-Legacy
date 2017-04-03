Imports eidss.model.Core
Imports System.Data.Common
Imports bv.common.Core
Imports System.Collections.Generic
Imports System.Data.SqlClient

Public Class AsSessionTableVew_DB
    Inherits BaseDbService
    Public Const TableFarmTableView As String = "FarmTableView"
    Public Const TableSpecies As String = "Species"
    Public Const TableAnimals As String = "Animals"

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

            Dim da As DbDataAdapter = CreateAdapter(cmd)
            da.Fill(ds, TableFarmTableView)
            CorrectTable(ds.Tables(0), TableFarmTableView)
            CorrectTable(ds.Tables(1), TableSpecies)
            CorrectTable(ds.Tables(2), TableAnimals)
            ClearColumnsAttibutes(ds)
            ds.Tables(TableFarmTableView).Columns("id").AutoIncrement = True
            ds.Tables(TableFarmTableView).Columns("id").AutoIncrementSeed = -1
            ds.Tables(TableFarmTableView).Columns("id").AutoIncrementStep = -1
            ds.Tables(TableFarmTableView).Columns("AnimalName").Expression = "strAnimalCode"
            m_ID = ID
            Return ds

        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function
    Public Overrides Function PostDetail(ByVal ds As System.Data.DataSet, ByVal PostType As Integer, Optional ByVal transaction As System.Data.IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            ExecPostProcedure("spASSessionTableView_Post", ds.Tables(TableFarmTableView), Connection, transaction, , , , AddressOf TableVewRowUpdated)
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
    Private incIndex As Integer = 0
    Public Function InitNewTableViewRow(row As DataRow) As DataRow
        'incIndex -= 1
        'row("id") = incIndex
        row("idfMonitoringSession") = ID
        row("idfFarm") = BaseDbService.NewIntID
        row("strFarmCode") = "(new)"
        row("blnNewFarm") = 1
        row("Used") = 0
        Return row
    End Function
    Public Sub UpdateAnimalsView(ds As DataSet)
        ds.Tables(AsSessionTableVew_DB.TableAnimals).Clear()
        For Each row As DataRow In ds.Tables(AsSessionTableVew_DB.TableFarmTableView).Rows
            If row.RowState <> DataRowState.Deleted Then
                UpdateAnimalsView(ds, row, Nothing)
            End If
        Next
    End Sub

    Public Sub UpdateAnimalsView(ds As DataSet, row As DataRow, oldAnimalID As Object)
        Dim animalRow As DataRow = ds.Tables(AsSessionTableVew_DB.TableAnimals).Rows.Find(row("idfAnimal"))
        If animalRow Is Nothing Then
            animalRow = ds.Tables(AsSessionTableVew_DB.TableAnimals).NewRow
            animalRow("idfAnimal") = row("idfAnimal")
            ds.Tables(AsSessionTableVew_DB.TableAnimals).Rows.Add(animalRow)
        End If
        For Each col As DataColumn In animalRow.Table.Columns
            If col.ColumnName <> "idfAnimal" AndAlso row.Table.Columns.Contains(col.ColumnName) Then
                animalRow(col.ColumnName) = row(col.ColumnName)
            End If
        Next
        animalRow.EndEdit()
        If Not Utils.IsEmpty(oldAnimalID) AndAlso row.Table.Select(String.Format("idfAnimal = {0}", oldAnimalID)).Length() = 0 Then
            animalRow = ds.Tables(AsSessionTableVew_DB.TableAnimals).Rows.Find(oldAnimalID)
            If Not animalRow Is Nothing Then
                animalRow.Delete()
            End If
        End If
        ds.Tables(AsSessionTableVew_DB.TableAnimals).AcceptChanges()
    End Sub
    Private m_FarmsToDelete As New List(Of Long)
    Public ReadOnly Property FarmsToDelete As List(Of Long)
        Get
            Return m_FarmsToDelete
        End Get
    End Property
    Private m_FarmsToUnlink As New List(Of Long)
    Public ReadOnly Property FarmsToUnlink As List(Of Long)
        Get
            Return m_FarmsToUnlink
        End Get
    End Property
End Class
