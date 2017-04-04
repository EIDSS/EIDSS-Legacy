Imports System.Data
Imports System.Data.Common
Imports bv.common.db.Core
Imports EIDSS.model.Resources
Imports bv.common.Enums

Public Class RepositoryScheme_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "RepositoryScheme"
    End Sub
    Public Const TableFreezer As String = "tlbFreezer"
    Public Const TableSubdivision As String = "tlbFreezerSubdivision"
    Dim m_RepositorySchemeDetailAdapter As DbDataAdapter
    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spRepositoryScheme_SelectDetail")
            AddParam(cmd, "@idfFreezer", ID, m_Error)
            If Not m_Error Is Nothing Then
                Return Nothing
            End If

            m_RepositorySchemeDetailAdapter = CreateAdapter(cmd, True)


            FillDataset(m_RepositorySchemeDetailAdapter, ds, TableFreezer)

            ClearColumnsAttibutes(ds)

            Dim freezerDTable As DataTable

            freezerDTable = ds.Tables(TableFreezer)
            CorrectTable(ds.Tables(1), TableSubdivision, "idfSubdivision")

            ds.Relations.Add(TableSubdivision, _
                freezerDTable.Columns("idfFreezer"), _
                ds.Tables(1).Columns("idfFreezer"))

            ds.Relations.Add("SubdivisionTree", _
                ds.Tables(1).Columns("idfSubdivision"), _
                ds.Tables(1).Columns("idfParentSubdivision"))


            If ID Is Nothing Then
                m_IsNewObject = True
                ID = NewIntID()
                Dim r As DataRow = ds.Tables(TableFreezer).NewRow
                r("idfFreezer") = ID
                ds.Tables(TableFreezer).Rows.Add(r)
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
        Dim cmd As IDbCommand = Nothing
        Try
            'Dim LocationDetail_Adapter As DbDataAdapter = CreateAdapter(ds.Tables(TableLocation), "Lab_Location", Connection, True, transaction)
            Dim freezerSubdivisionDetailAdapter As DbDataAdapter = CreateAdapter(ds.Tables(TableSubdivision), "tlbFreezerSubdivision", Connection, True, transaction)
            DeleteRec(Nothing, freezerSubdivisionDetailAdapter, ds.Tables(TableSubdivision).GetChanges(DataRowState.Deleted), transaction)

            Update(m_RepositorySchemeDetailAdapter, ds.GetChanges(DataRowState.Deleted), TableFreezer, transaction)
            Update(m_RepositorySchemeDetailAdapter, ds.GetChanges(DataRowState.Added Or DataRowState.Modified), TableFreezer, transaction)

            Update(freezerSubdivisionDetailAdapter, ds.GetChanges(DataRowState.Added Or DataRowState.Modified), TableSubdivision, transaction)
            Dim subdivision As DataTable = ds.Tables(TableSubdivision).GetChanges()
            If Not (subdivision Is Nothing) Then
                For Each row As DataRow In subdivision.Rows

                    cmd = CreateSPCommand("spFreezerSubdivision_Validate", Connection, transaction)
                    If row.RowState = DataRowState.Added OrElse row.RowState = DataRowState.Modified Then
                        AddParam(cmd, "@idfSubdivision", row("idfSubdivision"))
                        ExecCommand(cmd, cmd.Connection, transaction, True)
                    End If
                    If row.RowState = DataRowState.Deleted Then
                        AddParam(cmd, "@idfSubdivision", row("idfSubdivision", DataRowVersion.Original))
                        AddParam(cmd, "@intCapacity", 0)
                        ExecCommand(cmd, cmd.Connection, transaction, True)
                    End If
                Next
            End If

            LookupCache.NotifyChange("Freezer", transaction)
        Catch ex As SqlClient.SqlException
            m_Error = HandleError.ErrorMessage(ex)
            If ex.Number = 50000 And ex.Class = 16 AndAlso Not cmd Is Nothing Then
                If (ex.Message = "msgCanNotDecreaseLocationVial") Then
                    m_Error = New ErrorMessage()
                    m_Error.Kind = ErrorKind.NotificationError
                    m_Error.Text = String.Format(EidssMessages.Get(ex.Message), GetParamValue(cmd, "@intStored"), GetParamValue(cmd, "@intCapacity"))
                End If
            End If
            Return False
        Catch ex As Exception
            m_Error = HandleError.ErrorMessage(ex)
            Return False
        End Try
        Return True
    End Function

    Protected Overridable Sub DeleteRec(ByVal dRow As DataRow, ByVal adapter As DbDataAdapter, ByVal dTable As DataTable, Optional ByVal transaction As IDbTransaction = Nothing)
        Dim tempDrow As DataRow
        If DTable Is Nothing Then Exit Sub
        DTable.RejectChanges()
        Dim dView As DataView = New DataView(DTable)

        While DTable.Rows.Count > 0
            Dim i As Integer
            For i = 0 To DTable.Rows.Count - 1
                tempDrow = DTable.Rows(i)
                dView.RowFilter = "idfParentSubdivision = '" + tempDrow("idfSubdivision").ToString() + "'"
                If dView.Count = 0 Then tempDrow.Delete()
            Next
            ApplyTransaction(adapter, transaction)
            adapter.Update(DTable)
        End While

    End Sub

    Public Shared Function CopySubdivsionRow(ByVal dRow As DataRow, Optional ByVal freezerID As Object = Nothing) As DataRow
        Dim ds As DataSet = dRow.Table.DataSet
        Dim subdivDTable As DataTable = ds.Tables(TableSubdivision)
        If FreezerID Is Nothing Then
            FreezerID = dRow("idfFreezer")
        End If
        Dim newDRow As DataRow = subdivDTable.NewRow()
        Dim tempChildDrow, tempNewChildRow As DataRow
        newDRow("idfSubdivision") = NewIntID()
        newDRow("idfFreezer") = FreezerID
        newDRow("strNameChars") = dRow("strNameChars")
        newDRow("idfParentSubdivision") = dRow("idfParentSubdivision")
        newDRow("idfsSubdivisionType") = dRow("idfsSubdivisionType")
        newDRow("intCapacity") = dRow("intCapacity")
        newDRow("strNote") = dRow("strNote")
        subdivDTable.Rows.Add(newDRow)
        For Each tempChildDrow In dRow.GetChildRows("SubdivisionTree")
            tempNewChildRow = CopySubdivsionRow(tempChildDrow, FreezerID)
            tempNewChildRow.SetParentRow(newDRow, ds.Relations("SubdivisionTree"))
        Next
        Return (newDRow)
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
