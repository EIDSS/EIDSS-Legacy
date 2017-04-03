Imports System.Data
Imports System.Data.Common
Imports bv.common.db.Core
Imports System.Collections.Generic
Imports bv.common.Core

Public Class BaseFarmTree_DB
    Inherits BaseDbService
    Public Const TableFarmTree As String = "FarmTree"
    Public Const UndefinedSpecies As Long = 947220000000

    Private m_HACode As HACode = EIDSS.HACode.None
    Private m_KeyFieldName As String
    Private m_PostProcedureName As String
    Private m_SelectProcedureName As String


    Public Sub New()
        ObjectName = "FarmTree"
    End Sub

    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Debug.Assert(Not Utils.IsEmpty(ID), "FarmTree service must be initialized with NOT NULL case ID")
        Debug.Assert(Not Utils.IsEmpty(SelectProcedureName), "FarmTree service must be initialized by Select procedure name")
        Debug.Assert(Not Utils.IsEmpty(PostProcedureName), "FarmTree service must be initialized by Post procedure name")
        Debug.Assert(Not Utils.IsEmpty(KeyFieldName), "FarmTree service must be initialized ID parameter name")

        Try
            Dim cmd As IDbCommand = CreateSPCommand(SelectProcedureName)
            StoredProcParamsCache.CreateParameters(cmd)
            SetParam(cmd, "@" + KeyFieldName, ID)
            If cmd.Parameters.Contains("@HACode") Then
                SetParam(cmd, "@HACode", HACode)
            End If
            Dim da As DbDataAdapter = CreateAdapter(cmd)
            da.Fill(ds)
            CorrectTable(ds.Tables(0), TableFarmTree)
            ClearColumnsAttibutes(ds)
            ds.EnforceConstraints = False
            If ds.Tables(TableFarmTree).Rows.Count = 0 Then
                Dim row As DataRow = ds.Tables(TableFarmTree).NewRow
                row("idfParty") = ID
                row("strName") = "(new 1)"
                row("idfsPartyType") = CLng(PartyType.Farm)
                ds.Tables(TableFarmTree).Rows.Add(row)
                ds.Tables(TableFarmTree).AcceptChanges()
            End If
            m_ID = ID
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function

    Protected Property KeyFieldName() As String
        Get
            Return m_KeyFieldName
        End Get
        Set(ByVal value As String)
            m_KeyFieldName = value
        End Set
    End Property

    Protected Property PostProcedureName() As String
        Get
            Return m_PostProcedureName
        End Get
        Set(ByVal value As String)
            m_PostProcedureName = value
        End Set
    End Property

    Protected Property SelectProcedureName() As String
        Get
            Return m_SelectProcedureName
        End Get
        Set(ByVal value As String)
            m_SelectProcedureName = value
        End Set
    End Property


    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal post_Type As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            ExecPostProcedure(PostProcedureName, ds.Tables(TableFarmTree), Connection, transaction)
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function

    Public Function AddHerd(ByVal row As DataRow) As DataRow
        Dim newRow As DataRow = row.Table.NewRow
        newRow("idfParty") = NewIntID()
        newRow("idfsPartyType") = CLng(PartyType.Herd)
        newRow("idfParentParty") = row("idfParty")
        newRow("strName") = GetNewVirtualBarcode(row.Table, "strName")
        AddHerdSpecific(newRow, row)
        row.Table.Rows.Add(newRow)
        Return newRow
    End Function

    Public Overridable Sub AddHerdSpecific(ByVal newRow As DataRow, ByVal sourceRow As DataRow)
        'newRow("idfCase") = m_ID
    End Sub
    Public Function AddHerdSpieces(ByVal row As DataRow) As DataRow
        Dim newRow As DataRow = row.Table.NewRow
        newRow("idfParty") = NewIntID()
        newRow("idfsPartyType") = CLng(PartyType.Species)
        newRow("idfParentParty") = row("idfParty")
        AddHerdSpeciesSpecific(newRow, row)
        row.Table.Rows.Add(newRow)
        Return newRow
    End Function
    Public Overridable Sub AddHerdSpeciesSpecific(ByVal newRow As DataRow, ByVal sourceRow As DataRow)
        'newRow("idfCase") = m_ID
        'newRow("idfObservation") = NewIntID()
    End Sub
    ''' <summary>
    ''' Creates new copy of farm tree data from the farm tree placed in DataTable
    ''' We assume that dt contains farm tree table with the same structure as target farm tree
    ''' Function replaces sourceFarmID with targetFarmID and sets new ID for herds/species and set correct links between tree nodes
    ''' If static additional fields should be set for farm tree copy, they passed in the additionalParams dictionary
    ''' </summary>
    ''' <param name="sourceFarmID">farm ID of source farm that was used for data population</param>
    ''' <param name="targetFarmID">farm ID of target farm</param>
    ''' <param name="haCode "> HACode (lvestock or animal) of farms tree </param>
    ''' <returns>DataTable with new farm tree</returns>
    ''' <remarks>This method should be used when root farm is selected for Veterinary Case or Monitoring Session and we want to create copy of this farm tree related with case/session</remarks>
    Public Shared Function PopulateFarmTreeData(ByVal sourceFarmID As Object, ByVal targetFarmID As Object, ByVal haCode As HACode) As DataTable
        Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spRootFarmTree_SelectDetail", ConnectionManager.DefaultInstance.Connection)
        BaseDbService.AddParam(cmd, "@idfFarm", sourceFarmID)
        AddParam(cmd, "@HACode", haCode)
        Dim dt As New DataTable
        FillTable(cmd, dt)
        CorrectTable(dt)
        dt.Columns("idfParty").ReadOnly = False
        dt.Columns("idfParentParty").ReadOnly = False
        If (sourceFarmID.Equals(targetFarmID)) Then
            Return dt
        End If
        Dim farmRows As DataRow() = dt.Select(String.Format("idfParty = {0}", sourceFarmID))
        For Each row As DataRow In farmRows
            row("idfParty") = targetFarmID
            row.EndEdit()
        Next
        Dim herdRows As DataRow() = dt.Select(String.Format("idfParentParty = {0}", sourceFarmID))
        For Each row As DataRow In herdRows
            row.SetAdded()
            Dim speciesRows As DataRow() = dt.Select(String.Format("idfParentParty = {0}", row("idfParty")))
            row("idfParty") = NewIntID()
            row("idfParentParty") = targetFarmID
            row.EndEdit()
            For Each speciesRow As DataRow In speciesRows
                speciesRow.SetAdded()
                speciesRow("idfParty") = NewIntID()
                speciesRow("idfParentParty") = row("idfParty")
                speciesRow.EndEdit()
            Next
        Next
        Return dt
    End Function
    Public Sub ChangeFarm(ByVal ds As DataSet, ByVal sourceFarmID As Object, ByVal targetFarmID As Object, ByVal FarmIdCode As String)
        If Not Utils.IsEmpty(sourceFarmID) Then
            Using dt As DataTable = PopulateFarmTreeData(sourceFarmID, targetFarmID, HACode)
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
                    row.AcceptChanges()
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
        End If
        If ds.Tables(TableFarmTree).Rows.Count = 0 Then
            Dim row As DataRow = ds.Tables(TableFarmTree).NewRow
            row("idfParty") = targetFarmID
            row("strName") = FarmIdCode
            row("idfsPartyType") = CLng(PartyType.Farm)
            ds.Tables(TableFarmTree).Rows.Add(row)
            Return
        End If
    End Sub

    Public Function ValidateNewSpecies(ByVal row As DataRow, ByVal SpeciesName As String) As Boolean
        If Not CLng(PartyType.Species).Equals(row("idfsPartyType")) Then Return True
        If row.Table.Select(String.Format("idfParentParty={0} and strName='{1}' and idfParty<>{2}", row("idfParentParty"), SpeciesName, row("idfParty"))).Length > 0 Then
            Return False
        End If
        Return True
    End Function

    Public Property HACode() As HACode
        Get
            Return m_HACode
        End Get
        Set(ByVal value As HACode)
            m_HACode = value
        End Set
    End Property
End Class
