Imports System.Data
Imports bv.common.Enums

Public Class Vaccination_DB

    Inherits BaseDbService
    Public Sub New()
        ObjectName = "Vaccination"
    End Sub
    Public Const TableVaccination As String = "Vaccination"
    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        If ID Is Nothing Then
            Throw New Exception("Vaccination_DB service must be initialized with NOT NULL case ID")
        End If
        Dim ds As New DataSet

        Try
            Dim cmd As IDbCommand = CreateSPCommand("spVaccination_SelectDetail")
            AddParam(cmd, "@idfCase", ID)

            FillDataset(cmd, ds, TableVaccination)
            CorrectTable(ds.Tables(TableVaccination), TableVaccination)
            ClearColumnsAttibutes(ds)
            m_ID = ID
            ds.EnforceConstraints = False
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function

    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            ExecPostProcedure("spVaccination_Post", ds.Tables(TableVaccination), Connection, transaction)

        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function
    Public Function AddVacciation(ByVal ds As DataSet) As DataRow

        With ds.Tables(TableVaccination)
            ds.EnforceConstraints = False
            Dim r As DataRow
            r = .NewRow()
            InitVacciation(r)
            .Rows.Add(r)
            Return r
        End With

    End Function
    Public Sub InitVacciation(ByVal row As DataRow)
        row("idfVaccination") = NewIntID()
        row("idfVetCase") = m_ID
        row("datVaccinationDate") = DateTime.Today
    End Sub

End Class
