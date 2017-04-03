Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Public Class VetCaseAnimals_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "VetCaseAnimals"
    End Sub
    Public Const TableVetCaseAnimals As String = "VetCaseAnimals"
    Dim AnimalsAdapter As DbDataAdapter
    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        If ID Is Nothing Then
            Throw New Exception("VetCaseAnimals_DB service must be initialized with NOT NULL case ID")
        End If
        Dim ds As New DataSet

        Try
            Dim cmd As IDbCommand = CreateSPCommand("spVetCaseAnimals_SelectDetail")
            AddParam(cmd, "@idfCase", ID)
            AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)

            AnimalsAdapter = CreateAdapter(cmd)
            AnimalsAdapter.Fill(ds, TableVetCaseAnimals)
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


    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal post_Type As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
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

    Public Function NewAnimal(ByVal ds As DataSet, ByVal HertPartyID As Object) As DataRow
        Dim row As DataRow = ds.Tables(TableVetCaseAnimals).NewRow
        row("idfAnimal") = NewIntID()
        row("idfHerd") = HertPartyID
        row("strAnimalCode") = GetNewVirtualBarcode(ds.Tables(TableVetCaseAnimals), "strAnimalCode")
        ds.Tables(TableVetCaseAnimals).Rows.Add(row)
        Return row
    End Function
    Public Sub Clear(ByVal ds As DataSet)
        ds.Tables(TableVetCaseAnimals).Clear()
        ds.AcceptChanges()
    End Sub

    Public Overrides Function CanDelete(ByVal ID As Object, Optional ByVal aObjectName As String = Nothing, Optional ByVal transaction As System.Data.IDbTransaction = Nothing) As Boolean
        Return MyBase.CanDelete(ID, "Animal", transaction)
    End Function



End Class
