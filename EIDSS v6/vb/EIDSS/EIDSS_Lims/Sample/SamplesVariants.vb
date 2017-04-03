Imports bv.winclient.Core
Imports EIDSS.model.Core
Imports EIDSS.model.Resources
Imports System.Collections.Generic
Imports System.Linq
Imports EIDSS.model.Enums

Public Class SamplesVariants
    Private VariantsTable As DataTable

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        AuditObject = New AuditObject(EIDSSAuditObject.daoSample, AuditTable.tlbMaterial)
        PermissionObject = model.Enums.EIDSSPermissionObject.Sample
        DbService = New SamplesVariants_DB

        Dim modes As ArrayList = New ArrayList
        modes.Add(New DictionaryEntry(0, EidssMessages.Get("strCreateAliquote", "Create Aliquot")))
        modes.Add(New DictionaryEntry(1, EidssMessages.Get("strCreateDerivative", "Create Derivative")))

        cbVariantMode.Properties.DataSource = modes
    End Sub

    Protected Overrides Sub DefineBinding()

        MyBase.DefineBinding()

        cbSampleOriginal.DataSource = baseDataSet.Tables("Original")
        Core.LookupBinder.BindSampleRepositoryLookup(cbNewSampleType, HACode.All, False)
        Dim derivatives As New DataView(baseDataSet.Tables("Derivatives"))
        derivatives.RowFilter = "idfsSampleType=-1"
        cbSampleTypeNew.Properties.DataSource = derivatives

        Core.LookupBinder.BindDepartmentRepositoryLookup(cbDepartment)
        VariantsTable = baseDataSet.Tables("Variant") '.Clone
        VariantGrid.DataSource = VariantsTable

        OriginalGrid.DataSource = baseDataSet.Tables("Original")

        cbVariantMode.EditValue = 0

        LabUtils.BindFreezerLocation(cbLocation)

    End Sub

    Private Function CloneRow(ByVal parentRow As DataRow, ByRef transaction As IDbTransaction) As DataRow
        Dim row As DataRow = VariantsTable.NewRow()
        For Each col As DataColumn In row.Table.Columns
            If parentRow.Table.Columns.Contains(col.ColumnName) Then row(col.ColumnName) = parentRow(col.ColumnName)
        Next
        row("idfParentMaterial") = parentRow("idfMaterial")
        row("idfMaterial") = BaseDbService.NewIntID(transaction)
        row("idfInDepartment") = DBNull.Value
        row("idfSubdivision") = DBNull.Value
        row("Path") = DBNull.Value
        row("strNote") = DBNull.Value
        Return row
    End Function

    Private Sub btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnApply.Click
        Dim newItems As Integer = CType(SpinEdit1.EditValue, Integer)
        If newItems = 0 OrElse OriginalGridView.SelectedRowsCount = 0 Then Return
        m_RefereshParentForm = True
        SyncLock DbService.Connection
            Try
                If DbService.Connection.State <> ConnectionState.Open Then DbService.Connection.Open()
                Dim transaction As IDbTransaction = DbService.Connection.BeginTransaction
                Using (transaction)
                    For Each rowHandle As Integer In OriginalGridView.GetSelectedRows()
                        Dim parentRow As DataRow = OriginalGridView.GetDataRow(rowHandle)

                        Dim total As Integer = 0
                        If Not Utils.IsEmpty(parentRow("NewItems")) Then total = CType(parentRow("NewItems"), Integer)
                        If cbVariantMode.EditValue.ToString = "0" Then
                            total += CreateVariants(parentRow, "A", newItems, transaction)
                        Else
                            total += CreateVariants(parentRow, "D", newItems, transaction)
                        End If
                        parentRow("NewItems") = total
                        parentRow.AcceptChanges()
                    Next
                    transaction.Commit()
                End Using
            Catch ex As Exception
                Throw
            Finally
                DbService.Connection.Close()
            End Try
        End SyncLock
    End Sub

    Private Sub OriginalGridView_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles OriginalGridView.FocusedRowChanged
        Dim row As DataRow = OriginalGridView.GetDataRow(e.FocusedRowHandle)
        If row Is Nothing Then Exit Sub
        cbSampleTypeNew.EditValue = Nothing
        CType(cbSampleTypeNew.Properties.DataSource, DataView).RowFilter = "idfsSampleType=" + row("idfsSampleType").ToString()
    End Sub



    Private Sub CreateAliquote(ByVal row As DataRow, ByVal transaction As IDbTransaction)
        Dim command As IDbCommand = BaseDbService.CreateSPCommand("spLabSampleAliquote_Create", DbService.Connection, transaction)
        BaseDbService.AddParam(command, "@idfMaterial", row("idfMaterial"), ParameterDirection.Input)
        BaseDbService.AddParam(command, "@idfParentMaterial", row("idfParentMaterial"), ParameterDirection.Input)
        BaseDbService.AddParam(command, "@strBarcode", row("strBarcode"), ParameterDirection.Input)
        command.ExecuteNonQuery()
    End Sub

    Private Function CreateVariants(ByVal parentRow As DataRow, variantType As String, ByVal newItems As Integer, ByVal transaction As IDbTransaction) As Integer
        If variantType = "D" AndAlso Utils.IsEmpty(cbSampleTypeNew.EditValue) Then
            Return 0
        End If
        Dim count As Integer = 0
        Dim command As IDbCommand = BaseDbService.CreateSPCommand("spGetNextSampleVariantNumber", DbService.Connection, transaction)
        BaseDbService.AddParam(command, "@idfMaterial", parentRow("idfMaterial"), ParameterDirection.Input)
        BaseDbService.AddParam(command, "@variantType", variantType, ParameterDirection.Input)
        BaseDbService.AddTypedParam(command, "@NextNumberValue", SqlDbType.NVarChar, 1000, ParameterDirection.Output)

        For i As Integer = 0 To newItems - 1
            BaseDbService.ExecCommand(command, DbService.Connection, transaction, True)
            Dim result As Object = BaseDbService.GetParamValue(command, "@NextNumberValue")
            Dim row As DataRow = CloneRow(parentRow, transaction)
            row("strBarcode") = result.ToString()
            If (variantType = "A") Then
                CreateAliquote(row, transaction)
            ElseIf variantType = "D" Then
                row("idfsSampleType") = cbSampleTypeNew.EditValue
                CreateDerivative(row, transaction)
            End If
            VariantsTable.Rows.Add(row)
            row.AcceptChanges()
            count = count + 1
        Next
        'Dim result As Object = BaseDbService.GetParamValue(command, "@NextNumberValue")
        'Dim barcodes As String() = CType(result, String).Split(New Char() {","c})
        'For Each barcode As String In barcodes
        '    If barcode.Length = 0 Then Continue For
        '    Dim row As DataRow = CloneRow(parentRow, transaction)
        '    row("strBarcode") = barcode
        '    CreateAliquote(row, transaction)
        '    VariantsTable.Rows.Add(row)
        '    row.AcceptChanges()
        '    count = count + 1
        'Next
        If count < newItems Then
            ErrorForm.ShowWarningDirect(EidssMessages.Get("ErrMaximumAliquot", "Can't create aliquot. Maximum aliquot number (36) is exceeded."))
        End If
        Return count
    End Function


    Private Function CreateAliquotes(ByVal parentRow As DataRow, ByVal newItems As Integer, ByVal transaction As IDbTransaction) As Integer
        Dim count As Integer = 0
        Dim command As IDbCommand = BaseDbService.CreateSPCommand("spGetNextSampleVariantNumber", DbService.Connection, transaction)
        BaseDbService.AddParam(command, "@idfMaterial", parentRow("idfMaterial"), ParameterDirection.Input)
        BaseDbService.AddParam(command, "@variantType", "A", ParameterDirection.Input)
        BaseDbService.AddTypedParam(command, "@NextNumberValue", SqlDbType.NVarChar, 1000, ParameterDirection.Output)

        For i As Integer = 0 To newItems - 1
            BaseDbService.ExecCommand(command, DbService.Connection, transaction, True)
            Dim result As Object = BaseDbService.GetParamValue(command, "@NextNumberValue")
            Dim row As DataRow = CloneRow(parentRow, transaction)
            row("strBarcode") = result.ToString()
            CreateAliquote(row, transaction)
            VariantsTable.Rows.Add(row)
            row.AcceptChanges()
            count = count + 1
        Next
        'Dim result As Object = BaseDbService.GetParamValue(command, "@NextNumberValue")
        'Dim barcodes As String() = CType(result, String).Split(New Char() {","c})
        'For Each barcode As String In barcodes
        '    If barcode.Length = 0 Then Continue For
        '    Dim row As DataRow = CloneRow(parentRow, transaction)
        '    row("strBarcode") = barcode
        '    CreateAliquote(row, transaction)
        '    VariantsTable.Rows.Add(row)
        '    row.AcceptChanges()
        '    count = count + 1
        'Next
        If count < newItems Then
            ErrorForm.ShowWarningDirect(EidssMessages.Get("ErrMaximumAliquot", "Can't create aliquot. Maximum aliquot number (36) is exceeded."))
        End If
        Return count
    End Function

    Private Function CreateDerivatives(ByVal parentRow As DataRow, ByVal newItems As Integer, ByVal transaction As IDbTransaction) As Integer
        'create derivative
        Dim type As Object = cbSampleTypeNew.EditValue
        If type Is Nothing Then Exit Function
        While newItems > 0
            Dim row As DataRow = CloneRow(parentRow, transaction)
            row("idfsSampleType") = type
            CreateDerivative(row, transaction)
            VariantsTable.Rows.Add(row)
            row.AcceptChanges()
            newItems -= 1
        End While
        Return newItems
    End Function


    Private Sub CreateDerivative(ByVal row As DataRow, ByVal transaction As IDbTransaction)
        'row("strBarcode") = NumberingService.GetNextNumber(NumberingObject.Sample, DbService.Connection, Nothing, transaction)
        Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spLabSampleDerivative_Create", DbService.Connection, transaction)
        BaseDbService.AddParam(cmd, "@idfMaterial", row("idfMaterial"), ParameterDirection.Input)
        BaseDbService.AddParam(cmd, "@idfParentMaterial", row("idfParentMaterial"), ParameterDirection.Input)
        BaseDbService.AddParam(cmd, "@idfsSampleType", row("idfsSampleType"), ParameterDirection.Input)
        BaseDbService.AddParam(cmd, "@strBarcode", row("strBarcode"), ParameterDirection.Input)
        cmd.ExecuteNonQuery()
    End Sub

    Public Overrides Function GetKey(Optional ByVal aTableName As String = Nothing, Optional ByVal aKeyFieldName As String = Nothing) As Object
        Return 0
    End Function

    Private Sub cbVariantMode_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbVariantMode.EditValueChanged
        cbSampleTypeNew.Enabled = (cbVariantMode.EditValue.ToString = "1")
    End Sub
    Public Overrides Function GetSelectedRows() As DataRow()
        Dim selRowsInxexes As Integer() = VariantGridView.GetSelectedRows()
        If (selRowsInxexes Is Nothing OrElse selRowsInxexes.Length = 0) AndAlso VariantGridView.FocusedRowHandle >= 0 Then
            selRowsInxexes = New Integer() {VariantGridView.FocusedRowHandle}
        End If
        If selRowsInxexes Is Nothing Then Return Nothing
        ' creating an empty list
        Dim rows(selRowsInxexes.Length - 1) As DataRow
        ' adding selected rows to the list
        Dim I As Integer
        Dim k As Integer = 0
        For I = 0 To selRowsInxexes.Length - 1
            If (selRowsInxexes(I) >= 0) Then
                rows(k) = (VariantGridView.GetDataRow(selRowsInxexes(I)))
                k += 1
            End If
        Next
        If k = 0 Then Return Nothing
        Return rows
    End Function

    Private Sub BarcodePressed()
        ' Barcode printing  printing for sample
        Dim rows As DataRow() = GetSelectedRows()
        If rows Is Nothing Then Exit Sub


        Dim objects As List(Of Long) = (From row In rows Select CType(row("idfMaterial"), Long)).ToList()
        Const typeId As Long = CType(NumberingObject.Sample, Long)

        EidssSiteContext.BarcodeFactory.ShowPreview(typeId, objects)
    End Sub


    Private Sub SamplesVariants_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler btnBarcodes.ButtonPressed, AddressOf BarcodePressed

    End Sub
    Public Overrides Sub UpdateButtonsState(ByVal sender As Object, ByVal e As EventArgs)
        btnApply.Enabled = SpinEdit1.Value > 0 AndAlso CBool((cbVariantMode.EditValue.ToString = "0" OrElse Not Utils.IsEmpty(cbSampleTypeNew.EditValue)))
    End Sub
End Class
