Imports System.Data
Imports System.Data.Common
Imports bv.common.db.Core

Public Class RepositoryScheme_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "RepositoryScheme"
    End Sub
    Public Const TableFreezer As String = "tlbFreezer"
    Public Const TableSubdivision As String = "tlbFreezerSubdivision"
    'Public Const TableLocation As String = "Location"
    Dim RepositorySchemeDetail_Adapter As DbDataAdapter
    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spRepositoryScheme_SelectDetail")
            AddParam(cmd, "@idfFreezer", ID, m_Error)
            If Not m_Error Is Nothing Then
                Return Nothing
            End If

            RepositorySchemeDetail_Adapter = CreateAdapter(cmd, True)

            'm_Error = Lookup_Db.FillBaseLookup(ds, BaseReferenceType.rftStorageType, Connection)
            'TODO: check if rftLabLocType is not used indeed
            'm_Error = Lookup_Db.FillBaseLookup(ds, BaseReferenceType.rftLabLocType, Connection)
            'm_Error = Lookup_Db.FillBaseLookup(ds, BaseReferenceType.rftSubdivisionType, Connection)
            'If Not m_Error Is Nothing Then
            'Return Nothing
            'End If

            RepositorySchemeDetail_Adapter.Fill(ds, TableFreezer)
            Dim dataTable As DataTable = ds.Tables(TableFreezer)

            ClearColumnsAttibutes(ds)

            Dim FreezerDTable As DataTable
            Dim SubdivisionDTable As DataTable
            'Dim LocationDTable As DataTable

            FreezerDTable = ds.Tables(TableFreezer)

            SubdivisionDTable = ds.Tables(TableFreezer & 1)
            SubdivisionDTable.TableName = TableSubdivision
            SubdivisionDTable.PrimaryKey = New DataColumn() {SubdivisionDTable.Columns("idfSubdivision")}

            'LocationDTable = ds.Tables(TableFreezer & 2)
            'LocationDTable.TableName = TableLocation
            'LocationDTable.PrimaryKey = New DataColumn() {LocationDTable.Columns("idfLocationID")}

            ds.Relations.Add(TableSubdivision, _
                FreezerDTable.Columns("idfFreezer"), _
                SubdivisionDTable.Columns("idfFreezer"))

            'ds.Relations.Add("SubdivisionLocation", _
            'SubdivisionDTable.Columns("idfsSubdivisionID"), _
            'LocationDTable.Columns("idfsSubdivisionID"))

            ds.Relations.Add("SubdivisionTree", _
                SubdivisionDTable.Columns("idfSubdivision"), _
                SubdivisionDTable.Columns("idfParentSubdivision"))


            'Process the new object creation
            'It is assumed that if ID is nothing we should return 
            'the dataset containing empty row related with the mai obiect

            If ID Is Nothing Then
                m_IsNewObject = True
                ID = NewIntID()
                Dim r As DataRow = ds.Tables(TableFreezer).NewRow
                r("idfFreezer") = ID
                ''''''''r("idfsSite") = EIDSS.model.Core.EidssSiteContext.Instance.SiteID
                ds.Tables(TableFreezer).Rows.Add(r)
            End If

            m_ID = ID
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
        Return Nothing
    End Function

    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal PostType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            'Dim LocationDetail_Adapter As DbDataAdapter = CreateAdapter(ds.Tables(TableLocation), "Lab_Location", Connection, True, transaction)
            Dim FreezerSubdivisionDetail_Adapter As DbDataAdapter = CreateAdapter(ds.Tables(TableSubdivision), "tlbFreezerSubdivision", Connection, True, transaction)
            'Update(LocationDetail_Adapter, ds.GetChanges(DataRowState.Deleted), TableLocation, transaction)
            DeleteRec(Nothing, FreezerSubdivisionDetail_Adapter, ds.Tables(TableSubdivision).GetChanges(DataRowState.Deleted), transaction)
            'Update(FreezerSubdivisionDetail_Adapter, ds.GetChanges(DataRowState.Deleted), TableSubdivision, transaction)

            Update(RepositorySchemeDetail_Adapter, ds.GetChanges(DataRowState.Deleted), TableFreezer, transaction)
            Update(RepositorySchemeDetail_Adapter, ds.GetChanges(DataRowState.Added Or DataRowState.Modified), TableFreezer, transaction)

            Update(FreezerSubdivisionDetail_Adapter, ds.GetChanges(DataRowState.Added Or DataRowState.Modified), TableSubdivision, transaction)
            'Update(LocationDetail_Adapter, ds.GetChanges(DataRowState.Added Or DataRowState.Modified), TableLocation, transaction)
            Dim subdivision As DataTable = ds.Tables(TableSubdivision).GetChanges()
            If Not (subdivision Is Nothing) Then
                For Each row As DataRow In subdivision.Rows

                    Dim cmd As IDbCommand = CreateSPCommand("spFreezerSubdivision_Validate", Connection, transaction)
                    If row.RowState = DataRowState.Added OrElse row.RowState = DataRowState.Modified Then
                        AddParam(cmd, "@idfSubdivision", row("idfSubdivision"))
                        cmd.ExecuteNonQuery()
                    End If
                    If row.RowState = DataRowState.Deleted Then
                        AddParam(cmd, "@idfSubdivision", row("idfSubdivision", DataRowVersion.Original))
                        AddParam(cmd, "@intCapacity", 0)
                        cmd.ExecuteNonQuery()
                    End If
                Next
            End If

            db.Core.LookupCache.NotifyChange("Freezer", transaction)

        Catch ex As Exception
            m_Error = HandleError.ErrorMessage(ex)
            Return False
        End Try
        Return True
    End Function

    Protected Overridable Sub DeleteRec(ByVal DRow As DataRow, ByVal Adapter As DbDataAdapter, ByVal DTable As DataTable, Optional ByVal transaction As IDbTransaction = Nothing)
        Dim TempDrow As DataRow
        If DTable Is Nothing Then Exit Sub
        DTable.RejectChanges()
        Dim DView As DataView = New DataView(DTable)

        While DTable.Rows.Count > 0
            Dim i As Integer = 0
            For i = 0 To DTable.Rows.Count - 1
                TempDrow = DTable.Rows(i)
                DView.RowFilter = "idfParentSubdivision = '" + TempDrow("idfSubdivision").ToString() + "'"
                If DView.Count = 0 Then TempDrow.Delete()
            Next
            ApplyTransaction(Adapter, transaction)
            Adapter.Update(DTable)
        End While

    End Sub

    Public Shared Function CopySubdivsionRow(ByVal DRow As DataRow, Optional ByVal FreezerID As Object = Nothing) As DataRow
        Dim ds As DataSet = DRow.Table.DataSet
        Dim SubdivDTable As DataTable = ds.Tables(RepositoryScheme_DB.TableSubdivision)
        'Dim LocationDTable As DataTable = ds.Tables(RepositoryScheme_DB.TableLocation)
        If FreezerID Is Nothing Then
            FreezerID = DRow("idfFreezer")
        End If
        Dim NewDRow As DataRow = SubdivDTable.NewRow()
        Dim TempChildDrow, TempNewChildRow As DataRow
        NewDRow("idfSubdivision") = BaseDbService.NewIntID()
        NewDRow("idfFreezer") = FreezerID
        NewDRow("strNameChars") = DRow("strNameChars")
        NewDRow("idfParentSubdivision") = DRow("idfParentSubdivision")
        NewDRow("idfsSubdivisionType") = DRow("idfsSubdivisionType")
        NewDRow("intCapacity") = DRow("intCapacity")
        NewDRow("strNote") = DRow("strNote")
        'NewDRow("blnMovable") = DRow("blnMovable")
        ''''NewDRow("idfsSite") = EIDSS.model.Core.EidssSiteContext.Instance.SiteID
        SubdivDTable.Rows.Add(NewDRow)
        For Each TempChildDrow In DRow.GetChildRows("SubdivisionTree")
            TempNewChildRow = CopySubdivsionRow(TempChildDrow, FreezerID)
            TempNewChildRow.SetParentRow(NewDRow, ds.Relations("SubdivisionTree"))
        Next
        Return (NewDRow)
    End Function

    Public Function ValidateFreezerName(idfFreezer As Long, strFreezerName As String, Optional transaction As DbTransaction = Nothing) As Boolean
        Dim cmd As IDbCommand = CreateSPCommand("spFreezer_ValidateName", transaction)
        StoredProcParamsCache.CreateParameters(cmd)
        SetParam(cmd, "@idfFreezer", idfFreezer)
        SetParam(cmd, "@strFreezerName", strFreezerName)
        ExecCommand(cmd, Connection, transaction, True)
        Return 1.Equals(GetParamValue(cmd, "@RETURN_VALUE"))
    End Function

End Class
