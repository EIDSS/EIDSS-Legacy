Imports eidss.model.Core
Imports EIDSS.model.Resources

Public Class SamplesVariants
    'Private Class VariantParam
    '    Public mode As Integer
    '    Public count As Integer
    '    Public id As Integer
    '    Public type As Object
    '    Public Sub New(ByVal m As Integer, ByVal c As Integer, ByVal t As Object)
    '        mode = m
    '        count = c
    '        type = t
    '    End Sub
    '    Public Sub New(ByVal m As Integer, ByVal c As Integer, ByVal t As Integer)
    '        mode = m
    '        count = c
    '        id = t
    '    End Sub
    'End Class
    Private id As Long
    Private VariantsParams As Hashtable = New Hashtable
    Private VariantsTable As DataTable

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.AuditObject = New AuditObject(EIDSSAuditObject.daoSample, AuditTable.tlbMaterial)
        Me.PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.Sample
        Me.DbService = New SamplesVariants_DB

        Dim modes As ArrayList = New ArrayList
        modes.Add(New DictionaryEntry(0, EidssMessages.Get("strCreateAliquote", "Create Aliquot")))
        modes.Add(New DictionaryEntry(1, EidssMessages.Get("strCreateDerivative", "Create Derivative")))

        Me.cbVariantMode.Properties.DataSource = modes
    End Sub

    Protected Overrides Sub DefineBinding()

        'StartUpParameters.


        MyBase.DefineBinding()



        Me.cbSampleOriginal.DataSource = Me.baseDataSet.Tables("Original")
        'Me.cbSampleOriginal.ValueMember = "idfContainer"
        'Me.cbSampleOriginal.DisplayMember = "strBarcode"

        Core.LookupBinder.BindSampleRepositoryLookup(cbNewSampleType, HACode.All, False)
        Dim derivatives As New DataView(Me.baseDataSet.Tables("Derivatives"))
        derivatives.RowFilter = "idfsSampleType=-1"
        cbSampleTypeNew.Properties.DataSource = derivatives

        Core.LookupBinder.BindDepartmentRepositoryLookup(cbDepartment)
        'CType(cbDepartment.DataSource, DataView).RowFilter = "idfInstitution=" + EIDSS.model.Core.EidssSiteContext.Instance.OrganizationID.ToString()
        'Me.colSpecimenType.ColumnEdit = Me.cbSampleTypeNew.Properties

        VariantsTable = Me.baseDataSet.Tables("Variant") '.Clone
        Me.VariantGrid.DataSource = VariantsTable

        Me.OriginalGrid.DataSource = Me.baseDataSet.Tables("Original")

        'cbVariantMode_SelectedIndexChanged(Nothing, Nothing)
        Me.cbVariantMode.EditValue = 0

        LabUtils.BindFreezerLocation(Me.cbLocation)

        'cbDepartment.Columns.Clear()
        'cbDepartment.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() { _
        'New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", EidssMessages.Get("colName", "Name"), 200, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near)} _
        ')
        'cbDepartment.DataSource = Me.baseDataSet.Tables("DepartmentLookup")


        'Dim table As DataTable = Me.OriginalSamples.Clone
        'table.TableName = "Sample"
        'Me.baseDataSet.Tables.Add(table)
    End Sub

    Private Function CloneRow(ByVal parentRow As DataRow, ByRef transaction As IDbTransaction) As DataRow
        Dim row As DataRow = Me.VariantsTable.NewRow()
        For Each col As DataColumn In row.Table.Columns
            If parentRow.Table.Columns.Contains(col.ColumnName) Then row(col.ColumnName) = parentRow(col.ColumnName)
        Next
        'row("idfParentMaterial") = parentRow("idfMaterial")
        'row("idfRootParentMaterial") = parentRow("idfMaterial")
        row("idfParentContainer") = parentRow("idfContainer")
        'row("idfRootParentContainer") = row("idfRootParentContainer")
        row("idfContainer") = BaseDbService.NewIntID(transaction)
        row("idfInDepartment") = DBNull.Value
        row("idfSubdivision") = DBNull.Value
        row("Path") = DBNull.Value
        row("strNote") = DBNull.Value
        Return row
    End Function

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        'Dim parent As Object = parentRow("idfMaterial")
        'Dim table As DataTable = Me.VariantsTable 'Me.baseDataSet.Tables("Variant")
        Dim newItems As Integer = CType(Me.SpinEdit1.EditValue, Integer)
        If newItems = 0 OrElse Me.OriginalGridView.SelectedRowsCount = 0 Then Return
        Me.m_RefereshParentForm = True
        'Dim parentContainer As Object = parentRow("idfContainer")
        SyncLock DbService.Connection
            Try
                If DbService.Connection.State <> ConnectionState.Open Then DbService.Connection.Open()
                Dim transaction As IDbTransaction = DbService.Connection.BeginTransaction
                Using (transaction)
                    For Each handle As Integer In Me.OriginalGridView.GetSelectedRows()
                        Dim parentRow As DataRow = Me.OriginalGridView.GetDataRow(handle)

                        Dim total As Integer = 0
                        If Not Utils.IsEmpty(parentRow("NewItems")) Then total = CType(parentRow("NewItems"), Integer)
                        If Me.cbVariantMode.EditValue.ToString = "0" Then
                            total += Me.CreateAliquotes(parentRow, newItems, transaction)
                        Else
                            total += Me.CreateDerivatives(parentRow, newItems, transaction)
                        End If
                        parentRow("NewItems") = total
                        parentRow.AcceptChanges()
                    Next
                    transaction.Commit()
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                'Me.baseDataSet.AcceptChanges()
                DbService.Connection.Close()
            End Try
        End SyncLock
    End Sub

    Private Shared Function GetHACode(ByVal row As DataRow) As HACode
        If row("idfsActivity_Type").ToString = "actHumanCase" Then Return EIDSS.HACode.Human
        If row("intCaseType").ToString = "1" Then Return EIDSS.HACode.Avian
        If row("intCaseType").ToString = "0" Then Return EIDSS.HACode.Livestock
    End Function

    Private Sub OriginalGridView_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles OriginalGridView.FocusedRowChanged
        Dim row As DataRow = Me.OriginalGridView.GetDataRow(e.FocusedRowHandle)
        If row Is Nothing Then Exit Sub
        Me.cbSampleTypeNew.EditValue = Nothing
        CType(Me.cbSampleTypeNew.Properties.DataSource, DataView).RowFilter = "idfsSampleType=" + row("idfsSpecimenType").ToString()
    End Sub

    Private Sub PutDAO(ByRef ID As Object, ByRef type As EIDSSAuditObject, ByRef transaction As IDbTransaction, ByRef EventID As Object)
        '''''''
        Exit Sub
        'Dim command As IDbCommand = BaseDbService.CreateSPCommand("spAudit_CreateNewEvent", DbService.Connection, transaction)
        'BaseDbService.AddParam(command, "@idfsDataAuditEventType", AuditEventType.daeCreate, ParameterDirection.Input)
        'BaseDbService.AddParam(command, "@idfsDataAuditObjectType ", type, ParameterDirection.Input)
        ''BaseDbService.AddParam(command, "@strMainObjectTable", "Container", ParameterDirection.Input)
        'BaseDbService.AddParam(command, "@strMainObjectTable", Nothing, ParameterDirection.Input)
        'BaseDbService.AddParam(command, "@idfsMainObject", ID, ParameterDirection.Input)
        'BaseDbService.AddParam(command, "@strReason", Nothing, ParameterDirection.Input)
        'BaseDbService.AddParam(command, "@idfDataAuditEvent", EIDSS.model.Core.EidssUserContext.User.EmployeeID, ParameterDirection.Output)
        'command.ExecuteNonQuery()
        'EventID = BaseDbService.GetParamValue(command, "@idfDataAuditEvent")
    End Sub

    Private Sub ClearDAO(ByRef transaction As IDbTransaction, ByRef EventID As Object)
        ''''''''
        Exit Sub
        'Dim command As IDbCommand = BaseDbService.CreateSPCommand("[spClearContextData]", DbService.Connection, transaction)
        'BaseDbService.AddParam(command, "@ClearEventID", False, ParameterDirection.Input)
        'BaseDbService.AddParam(command, "@ClearDataAuditEvent", True, ParameterDirection.Input)
        'command.ExecuteNonQuery()
        'command = BaseDbService.CreateSPCommand("dbo.spFiltered_CheckEvent", DbService.Connection, transaction)
        'BaseDbService.AddParam(command, "@event", EventID)
        'command.ExecuteNonQuery()
    End Sub

    Private Sub CreateAliquote(ByVal row As DataRow, ByVal transaction As IDbTransaction)
        Dim EventID As Object = Nothing
        PutDAO(row("idfContainer"), EIDSSAuditObject.daoAliquote, transaction, EventID)
        Dim command As IDbCommand = BaseDbService.CreateSPCommand("spLabSampleAliquote_Create", DbService.Connection, transaction)
        'BaseDbService.AddParam(command, "@idfMaterial", row("idfMaterial"), ParameterDirection.Input)
        BaseDbService.AddParam(command, "@idfContainer", row("idfContainer"), ParameterDirection.Input)
        BaseDbService.AddParam(command, "@idfParentContainer", row("idfParentContainer"), ParameterDirection.Input)
        'BaseDbService.AddParam(command, "@idfRootParentContainer", row("idfRootParentContainer"), ParameterDirection.Input)
        BaseDbService.AddParam(command, "@strBarcode", row("strBarcode"), ParameterDirection.Input)
        'BaseDbService.AddParam(command, "@idfOffice", EIDSS.model.Core.EidssUserContext.User.OrganizationID, ParameterDirection.Input)
        'BaseDbService.AddParam(command, "@idfEmployee", EIDSS.model.Core.EidssUserContext.User.EmployeeID, ParameterDirection.Input)
        command.ExecuteNonQuery()
        ClearDAO(transaction, EventID)
    End Sub

    Private Function CreateAliquotes(ByVal parentRow As DataRow, ByVal newItems As Integer, ByVal transaction As IDbTransaction) As Integer
        Dim count As Integer = 0
        'Dim parent As Object = parentRow("idfContainer")
        Dim command As IDbCommand = BaseDbService.CreateSPCommand("spGetNextAliquotNumber", DbService.Connection, transaction)
        BaseDbService.AddParam(command, "@idfContainer", parentRow("idfContainer"), ParameterDirection.Input)
        BaseDbService.AddParam(command, "@AliquotQty", newItems, ParameterDirection.Input)
        BaseDbService.AddTypedParam(command, "@NextNumberValue", SqlDbType.NVarChar, 1000, ParameterDirection.Output)
        BaseDbService.ExecCommand(command, DbService.Connection, transaction, True)
        Dim result As Object = BaseDbService.GetParamValue(command, "@NextNumberValue")
        Dim barcodes As String() = CType(result, String).Split(New Char() {","c})
        'For i As Integer = 0 To newItems
        For Each barcode As String In barcodes
            If barcode.Length = 0 Then Continue For
            Dim row As DataRow = CloneRow(parentRow, transaction)
            row("strBarcode") = barcode 'barcodes(i - 1)
            CreateAliquote(row, transaction)
            VariantsTable.Rows.Add(row)
            row.AcceptChanges()
            count = count + 1
        Next
        If count < newItems Then
            ErrorForm.ShowWarningDirect(EidssMessages.Get("ErrMaximumAliquot", "Can't create aliquot. Maximum aliquot number (36) is exceeded."))
        End If
        Return count
    End Function

    Private Function CreateDerivatives(ByVal parentRow As DataRow, ByVal newItems As Integer, ByVal transaction As IDbTransaction) As Integer
        'create derivative
        'Dim parent As Object = parentRow("idfContainer")
        Dim type As Object = Me.cbSampleTypeNew.EditValue
        If type Is Nothing Then Exit Function
        For i As Integer = 1 To newItems
            Dim row As DataRow = CloneRow(parentRow, transaction)
            row("idfsSpecimenType") = type
            Me.CreateDerivative(row, transaction)
            VariantsTable.Rows.Add(row)
            row.AcceptChanges()
        Next
        Return newItems
    End Function


    Private Sub CreateDerivative(ByVal row As DataRow, ByVal transaction As IDbTransaction)
        Dim EventID As Object = Nothing
        PutDAO(row("idfContainer"), EIDSSAuditObject.daoDerivative, transaction, EventID)
        'Dim material As Long = BaseDbService.NewIntID
        'row("idfMaterial") = BaseDbService.NewIntID
        'row("idfRootParentContainer") = row("idfContainer")
        row("strBarcode") = NumberingService.GetNextNumber(NumberingObject.Specimen, DbService.Connection, Nothing, transaction)

        'Dim command As IDbCommand = BaseDbService.CreateSPCommand("spLabSample_Create", DbService.Connection, transaction)
        'BaseDbService.AddParam(command, "@idfMaterial", row("idfMaterial"), ParameterDirection.Input)
        'BaseDbService.AddParam(command, "@idfParentMaterial", parent, ParameterDirection.Input)
        'BaseDbService.AddParam(command, "@idfRootParentMaterial", row("idfRootParentMaterial"), ParameterDirection.Input)
        'BaseDbService.AddParam(command, "@strFieldBarcode", row("strFieldBarcode"), ParameterDirection.Input)
        'BaseDbService.AddParam(command, "@idfActivity", row("idfActivity"), ParameterDirection.Input)
        'BaseDbService.AddParam(command, "@idfsMaterial_Type", "mttLivingObject", ParameterDirection.Input)
        'If row("idfsActivity_Type").ToString = "actHumanCase" Then
        'BaseDbService.AddParam(command, "@idfsMaterial_Responsibility_Type", "mrtHumanSample", ParameterDirection.Input)
        'Else
        'BaseDbService.AddParam(command, "@idfsMaterial_Responsibility_Type", "mrtAnimalSample", ParameterDirection.Input)
        'End If
        'BaseDbService.AddParam(command, "@idfsSpecimenType", row("idfsSpecimenType"), ParameterDirection.Input)
        'BaseDbService.AddParam(command, "@idfParty", row("idfParty"), ParameterDirection.Input)
        'BaseDbService.AddParam(command, "@datFieldCollectedDate", DBNull.Value, ParameterDirection.Input)
        'BaseDbService.AddParam(command, "@datFieldSentDate", DateTime.Now, ParameterDirection.Input)
        'BaseDbService.AddParam(command, "@idfFieldCollectedByOffice", EIDSS.model.Core.EidssUserContext.User.OrganizationID, ParameterDirection.Input)
        'BaseDbService.AddParam(command, "@idfFieldCollectedByPerson", EIDSS.model.Core.EidssUserContext.User.EmployeeID, ParameterDirection.Input)
        'command.ExecuteNonQuery()

        Dim Command As IDbCommand = BaseDbService.CreateSPCommand("spLabSampleDerivative_Create", DbService.Connection, transaction)
        BaseDbService.AddParam(Command, "@idfContainer", row("idfContainer"), ParameterDirection.Input)
        BaseDbService.AddParam(Command, "@idfParentContainer", row("idfParentContainer"), ParameterDirection.Input)
        BaseDbService.AddParam(Command, "@idfMaterial", row("idfContainer"), ParameterDirection.Input)
        'BaseDbService.AddParam(Command, "@idfMaterialSource", row("idfMaterialParent"), ParameterDirection.Input)
        BaseDbService.AddParam(Command, "@idfsSpecimenType", row("idfsSpecimenType"), ParameterDirection.Input)
        'BaseDbService.AddParam(command, "@idfContainerSource", row("idfContainerParent"), ParameterDirection.Input)
        BaseDbService.AddParam(Command, "@strBarcode", row("strBarcode"), ParameterDirection.Input)
        'BaseDbService.AddParam(command, "@idfOffice", EIDSS.model.Core.EidssUserContext.User.OrganizationID, ParameterDirection.Input)
        'BaseDbService.AddParam(command, "@idfEmployee", EIDSS.model.Core.EidssUserContext.User.EmployeeID, ParameterDirection.Input)
        Command.ExecuteNonQuery()
        ClearDAO(transaction, EventID)
    End Sub

    Public Overrides Function GetKey(Optional ByVal aTableName As String = Nothing, Optional ByVal aKeyFieldName As String = Nothing) As Object
        Return 0
    End Function

    'Private Sub btnLocation_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles btnLocation.ButtonClick
    '    Dim row As DataRow = Me.VariantGridView.GetDataRow(Me.VariantGridView.FocusedRowHandle)
    '    'Dim selected As DataRow() = Nothing
    '    'Try
    '    '    Dim FreezerTree As BaseForm = New EIDSS.FreezerTree()
    '    '    selected = BaseForm.ShowForMultiSelection(FreezerTree, row("idfsSubdivision"), Me)
    '    'Catch ex As Exception
    '    'End Try
    '    'If Not selected Is Nothing Then
    '    '    Me.VariantGridView.EditingValue = selected(0)("Path")
    '    '    row("idfsSubdivision") = selected(0)("idfsSubdivision")
    '    'End If
    '    Me.VariantGridView.EditingValue = LabUtils.ChangeLocation(FindForm, row)
    'End Sub

    Private Sub cbVariantMode_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbVariantMode.EditValueChanged
        Me.cbSampleTypeNew.Enabled = (Me.cbVariantMode.EditValue.ToString = "1")
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
        Dim rows As DataRow() = Me.GetSelectedRows()
        Dim row As DataRow
        If rows Is Nothing Then Exit Sub

        Dim typeId As Long = CType(NumberingObject.Specimen, Long)
        For Each row In rows
            Dim objectId As Long = CType(row("idfContainer"), Long)
            EidssSiteContext.BarcodeFactory.ShowPreview(typeId, objectId)

        Next

    End Sub


    Private Sub SamplesVariants_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        AddHandler btnBarcodes.ButtonPressed, AddressOf BarcodePressed

    End Sub
    Public Overrides Sub UpdateButtonsState(ByVal sender As Object, ByVal e As System.EventArgs)
        btnApply.Enabled = SpinEdit1.Value > 0 AndAlso CBool(IIf(cbVariantMode.EditValue.ToString = "0", True, Not Utils.IsEmpty(cbSampleTypeNew.EditValue)))
    End Sub
End Class
