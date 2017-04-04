Imports System.Data
Imports System.Collections.Generic
Imports bv.common.Enums

Public Class VetCaseAnimals_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "VetCaseAnimals"
    End Sub
    Public Const TableVetCaseAnimals As String = "VetCaseAnimals"
    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        If ID Is Nothing Then
            Throw New Exception("VetCaseAnimals_DB service must be initialized with NOT NULL case ID")
        End If
        Dim ds As New DataSet

        Try
            Dim cmd As IDbCommand = CreateSPCommand("spVetCaseAnimals_SelectDetail")
            AddParam(cmd, "@idfCase", ID)
            AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)

            FillDataset(cmd, ds, TableVetCaseAnimals)
            CorrectTable(ds.Tables(TableVetCaseAnimals), TableVetCaseAnimals)
            ds.Tables(TableVetCaseAnimals).Columns("idfsSpeciesType").DefaultValue = 0
            ds.Tables(TableVetCaseAnimals).Columns("strGender").ReadOnly = False
            ds.Tables(TableVetCaseAnimals).Columns("strSpecies").ReadOnly = False
            ds.EnforceConstraints = False
            m_ID = ID
            'Init default values
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function


    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            Dim params As New Dictionary(Of String, Object)
            params.Add("@idfCase", m_ID)
            ExecPostProcedure("spVetCaseAnimals_Post", ds.Tables(TableVetCaseAnimals), Connection, transaction, params)
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function

    Public Function NewAnimal(ByVal ds As DataSet, ByVal herdPartyID As Object) As DataRow
        Dim row As DataRow = ds.Tables(TableVetCaseAnimals).NewRow
        InitRow(row, herdPartyID, ds.Tables(TableVetCaseAnimals))
        ds.Tables(TableVetCaseAnimals).Rows.Add(row)
        Return row
    End Function
    Public Sub Clear(ByVal ds As DataSet)
        ds.Tables(TableVetCaseAnimals).Clear()
        ds.AcceptChanges()
    End Sub

    Public Overrides Function CanDelete(ByVal aID As Object, Optional ByVal aObjectName As String = Nothing, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        Return MyBase.CanDelete(aID, "Animal", transaction)
    End Function


    Public Sub InitRow(ByVal row As DataRow, ByVal herdPartyID As Object, animalTable As DataTable)
        row("idfAnimal") = NewIntID()
        row("idfHerd") = herdPartyID
        row("strAnimalCode") = GetNewVirtualBarcode(animalTable, "strAnimalCode")
    End Sub
End Class
