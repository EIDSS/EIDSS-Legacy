Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports bv.common.db.Core
Imports bv.common.Core

Public Class VetFarmTree_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "VetFarmTree"
    End Sub


    Public Const TableFarmTree As String = "VetFarmTree"
    Public Const UndefinedSpecies As Long = 947220000000

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        If ID Is Nothing Then
            Throw New Exception("VetFarmTree service must be initialized with NOT NULL case ID")
        End If

        Try
            Dim cmd As IDbCommand = CreateSPCommand("spVetFarmTree_SelectDetail")
            AddParam(cmd, "@idfCase", ID)

            Dim da As DbDataAdapter = CreateAdapter(cmd)
            da.Fill(ds)
            CorrectTable(ds.Tables(0), TableFarmTree)
            ClearColumnsAttibutes(ds)
            ds.EnforceConstraints = False
            m_ID = ID
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function


    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal post_Type As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            ds.EnforceConstraints = False
            ExecPostProcedure("spVetFarmTree_Post", ds.Tables(TableFarmTree), Connection, transaction, , "idfsPartyType DESC")
            ' Dim cmd As IDbCommand = CreateSPCommand("spFarmTree_CopyToRoot")
            'cmd.Transaction = transaction
            'StoredProcParamsCache.CreateParameters(cmd)
            'SetParam(cmd, "@HACode", CInt(HACode))
            'Dim rows As DataRow() = ds.Tables(TableFarmTree).Select(String.Format("idfsPartyType={0}", CLng(PartyType.Farm)))
            'SetParam(cmd, "@idfSourceFarm", rows(0)("idfParty"))
            'cmd.ExecuteNonQuery()
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function

    Public Sub ChangeFarm(ByVal ds As DataSet, ByVal sourceFarmID As Object, ByVal targetFarmID As Object, ByVal FarmIdCode As String)
        Using dt As DataTable = PopulateFarmTreeData(sourceFarmID, targetFarmID)
            If dt Is Nothing Then
                Return
            End If
            Dim rows As DataRow() = ds.Tables(TableFarmTree).Select(String.Format("idfsPartyType<>{0}", CLng(PartyType.Farm)))
            For Each row As DataRow In rows
                row.Delete()
            Next
            rows = ds.Tables(TableFarmTree).Select(String.Format("idfsPartyType = {0}", CLng(PartyType.Farm)))
            For Each row As DataRow In rows
                row.Delete()
                If row.HasVersion(DataRowVersion.Original) Then
                    row.AcceptChanges()
                End If
            Next
            If Not dt Is Nothing Then
                For Each row As DataRow In dt.Rows
                    Dim newRow As DataRow = ds.Tables(TableFarmTree).NewRow
                    For Each col As DataColumn In dt.Columns
                        If ds.Tables(TableFarmTree).Columns.Contains(col.ColumnName) Then
                            newRow(col.ColumnName) = row(col)
                        End If
                    Next
                    If Not PartyType.Herd.Equals(row("idfsPartyType")) Then
                        newRow("idfObservation") = NewIntID()
                    End If
                    newRow("idfCase") = m_ID
                    ds.Tables(TableFarmTree).Rows.Add(newRow)
                Next
            End If
        End Using
        If ds.Tables(TableFarmTree).Rows.Count = 0 Then
            Dim row As DataRow = ds.Tables(TableFarmTree).NewRow
            row("idfParty") = targetFarmID
            row("strName") = FarmIdCode
            row("idfCase") = m_ID
            row("idfsPartyType") = CLng(PartyType.Farm)
            row("idfObservation") = NewIntID()
            ds.Tables(TableFarmTree).Rows.Add(row)
        End If
        If ds.Tables(TableFarmTree).Rows.Count = 1 Then
            Dim herdRow As DataRow = AddHerd(ds.Tables(TableFarmTree).Rows(0))
            Dim spieciesRow As DataRow = AddHerdSpieces(herdRow)
            spieciesRow("strName") = Utils.Str(UndefinedSpecies) '"splUndefined"
            Return
        End If
    End Sub
    Public Function PopulateFarmTreeData(ByVal FarmID As Object, ByVal targetFarmID As Object) As DataTable
        Try
            Return (BaseFarmTree_DB.PopulateFarmTreeData(FarmID, targetFarmID, HACode))
        Catch ex As Exception
            m_Error = New EIDSSErrorMessage(StandardError.StoredProcedureError, ex)
            Return Nothing
        End Try
    End Function

    Public Function AddHerd(ByVal row As DataRow) As DataRow
        Dim newRow As DataRow = row.Table.NewRow
        newRow("idfParty") = NewIntID()
        newRow("idfsPartyType") = CLng(PartyType.Herd)
        newRow("idfParentParty") = row("idfParty")
        newRow("idfCase") = m_ID
        newRow("strName") = GetNewVirtualBarcode(row.Table, "strName")
        row.Table.Rows.Add(newRow)
        Return newRow
    End Function
    Public Function AddHerdSpieces(ByVal row As DataRow) As DataRow
        Dim newRow As DataRow = row.Table.NewRow
        newRow("idfParty") = NewIntID()
        newRow("idfsPartyType") = CLng(PartyType.Species)
        newRow("idfParentParty") = row("idfParty")
        newRow("idfCase") = m_ID
        newRow("idfObservation") = NewIntID()
        row.Table.Rows.Add(newRow)
        Return newRow
    End Function

    Public Function ValidateNewSpecies(ByVal row As DataRow, ByVal SpeciesName As String) As Boolean
        If Not CLng(PartyType.Species).Equals(row("idfsPartyType")) Then Return True
        If row.Table.Select(String.Format("idfParentParty={0} and strName='{1}' and idfParty<>{2}", row("idfParentParty"), SpeciesName, row("idfParty"))).Length > 0 Then
            Return False
        End If
        Return True
    End Function
    Private m_FarmSpieces As DataTable = New DataTable
    Private m_HACode As HACode = EIDSS.HACode.Livestock Or EIDSS.HACode.Avian Or EIDSS.HACode.Avian
    Public Property HACode() As HACode
        Get
            Return m_HACode
        End Get
        Set(ByVal value As HACode)
            m_HACode = value
        End Set
    End Property
End Class
