Imports System.Data
Imports System.Data.Common

Public Class AgeForSpecies_DB
    Inherits BaseDbService

    Public Sub New()
        ObjectName = "AgeForSpecies"
        Me.UseDatasetCopyInPost = False
    End Sub

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spAgeForSpecies_SelectDetail")
            Dim da As DbDataAdapter = CreateAdapter(cmd, False)
            da.Fill(ds, "AgeForSpecies")
            CorrectTable(ds.Tables(0), "AgeForSpecies")
            CorrectTable(ds.Tables(1), "SpeciesType")
            ClearColumnsAttibutes(ds)
            ds.Tables(0).Columns("idfSpeciesTypeToAnimalAge").AutoIncrement = True
            ds.Tables(0).Columns("idfSpeciesTypeToAnimalAge").AutoIncrementSeed = -1
            ds.Tables(0).Columns("idfSpeciesTypeToAnimalAge").AutoIncrementStep = -1
            m_ID = ID
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function

    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal PostType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            ExecPostProcedure("spAgeForSpecies_Post", ds.Tables(0), db.Core.ConnectionManager.DefaultInstance.Connection, transaction)
            db.Core.LookupCache.NotifyChange("rftAnimalAgeList", transaction)
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function

End Class
