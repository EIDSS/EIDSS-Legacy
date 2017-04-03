Imports System.Data
Imports System.Data.Common
Imports bv.common.db.Core
Imports bv.common.Core
Imports bv.common.Enums

Public Class FarmPanel_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "Farm"
    End Sub

    Public Const TableFarm As String = "Farm"


    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try

            Dim cmd As IDbCommand = CreateSPCommand("spFarmPanel_SelectDetail")


            AddParam(cmd, "@idfFarm", ID)

            Dim FarmDetail_Adapter As DbDataAdapter = CreateAdapter(cmd, False)

            FarmDetail_Adapter.Fill(ds, TableFarm)
            CorrectTable(ds.Tables(0), TableFarm)
            ClearColumnsAttibutes(ds)
            If ID Is Nothing Then
                ID = NewIntID()
            End If
            If ds.Tables(TableFarm).Rows.Count = 0 Then
                Dim r As DataRow = ds.Tables(TableFarm).NewRow
                r("idfFarm") = ID
                r("strFarmCode") = GetNewVirtualBarcode(ds.Tables(TableFarm), "strFarmCode")
                r("idfFarmAddress") = NewIntID()
                r("idfOwner") = NewIntID()
                r("blnRootFarm") = m_IsRootFarm
                If Not m_IsRootFarm Then
                    r("idfRootFarm") = NewIntID()
                End If
                ds.EnforceConstraints = False
                ds.Tables(TableFarm).Rows.Add(r)
                ForceTableChanges(ds.Tables(TableFarm))
            End If
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
            If ds Is Nothing Then Return True
            Dim row As DataRow = ds.Tables(TableFarm).Rows(0)
            ExecPostProcedure("spFarmPanel_Post", ds.Tables(TableFarm), Connection, transaction)
            If row.RowState = DataRowState.Added OrElse _
                row.RowState = DataRowState.Deleted OrElse _
                (row.HasVersion(DataRowVersion.Original) AndAlso _
                 (Utils.Str(row("strOwnerFirstName", DataRowVersion.Original)) <> Utils.Str(row("strOwnerFirstName")) OrElse _
                   Utils.Str(row("strOwnerMiddleName", DataRowVersion.Original)) <> Utils.Str(row("strOwnerMiddleName")) OrElse _
                   Utils.Str(row("strOwnerLastName", DataRowVersion.Original)) <> Utils.Str(row("strOwnerLastName")) OrElse _
                    Utils.Str(row("idfOwner", DataRowVersion.Original)) <> Utils.Str(row("idfOwner")))) Then
                If row.RowState = DataRowState.Deleted AndAlso row.HasVersion(DataRowVersion.Original) Then
                    LookupCache.NotifyChange("Human", transaction, row("idfOwner", DataRowVersion.Original))
                Else
                    LookupCache.NotifyChange("Human", transaction, row("idfOwner"))
                End If
            End If

        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function

    Public Sub SetOwner(ByVal ds As DataSet, ByVal Owner_ID As Object, ByVal OwnerName As String, ByVal OwnerFirstName As String, ByVal OwnerMiddleName As String, ByVal OwnerLastName As String)
        If ds.Tables(TableFarm).Rows.Count > 0 Then
            If Not Owner_ID.Equals(ds.Tables(TableFarm).Rows(0)("idfRootOwner")) Then
                ds.Tables(TableFarm).Rows(0)("idfOwner") = BaseDbService.NewIntID
            End If
            ds.Tables(TableFarm).Rows(0)("idfRootOwner") = Owner_ID
            ds.Tables(TableFarm).Rows(0)("strFullName") = OwnerName
            ds.Tables(TableFarm).Rows(0)("strOwnerFirstName") = OwnerFirstName
            ds.Tables(TableFarm).Rows(0)("strOwnerMiddleName") = OwnerMiddleName
            ds.Tables(TableFarm).Rows(0)("strOwnerLastName") = OwnerLastName
            ds.Tables(TableFarm).Rows(0).EndEdit()
        End If
    End Sub

    Public Function DeleteFarmOwnerLink(ByVal ds As DataSet) As Boolean
        If ds.Tables(TableFarm).Rows.Count > 0 Then
            ds.Tables(TableFarm).Rows(0)("idfRootOwner") = DBNull.Value
            ds.Tables(TableFarm).Rows(0)("idfOwner") = DBNull.Value
            ds.Tables(TableFarm).Rows(0)("strFullName") = DBNull.Value
            ds.Tables(TableFarm).Rows(0)("strOwnerFirstName") = DBNull.Value
            ds.Tables(TableFarm).Rows(0)("strOwnerMiddleName") = DBNull.Value
            ds.Tables(TableFarm).Rows(0)("strOwnerLastName") = DBNull.Value
            ds.Tables(TableFarm).Rows(0).EndEdit()
        End If
    End Function
    Private m_IsRootFarm As Boolean
    Public Property IsRootFarm As Boolean
        Get
            Return m_IsRootFarm
        End Get
        Set(value As Boolean)
            m_IsRootFarm = value
        End Set
    End Property

End Class
