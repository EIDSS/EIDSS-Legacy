Imports System.Data
Imports System.Data.Common

Public Class Farm_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "Farm"
    End Sub

    Public Const TableFarm As String = "Farm"

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try

            Dim cmd As IDbCommand = CreateSPCommand("spFarm_SelectDetail")

            AddParam(cmd, "@idfFarm", ID)
            Dim da As DbDataAdapter = CreateAdapter(cmd, False)
            da.Fill(ds, TableFarm)
            CorrectTable(ds.Tables(0), TableFarm)
            ClearColumnsAttibutes(ds)
            ds.EnforceConstraints = False

            If ID Is Nothing Then
                ID = NewIntID()
            End If
            If ds.Tables(TableFarm).Rows.Count = 0 Then
                Dim r As DataRow = ds.Tables(TableFarm).NewRow
                r("idfFarm") = ID
                r("blnIsAvian") = 0
                r("blnIsLivestock") = 0
                ds.EnforceConstraints = False
                ds.Tables(TableFarm).Rows.Add(r)
                ForceTableChanges(ds.Tables(TableFarm))
                m_IsNewObject = True
            End If
            ClearColumnsAttibutes(ds)
            m_ID = ID
            Return ds
        Catch ex As Exception
            m_error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function
    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal PostType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            ExecPostProcedure("spFarm_Post", ds.Tables(TableFarm), Connection, transaction)
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function

End Class
