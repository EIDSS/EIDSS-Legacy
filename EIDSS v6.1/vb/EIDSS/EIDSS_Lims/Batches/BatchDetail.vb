Imports System.Drawing
Imports EIDSS.model.Core
Imports EIDSS.model.Resources
Imports bv.model.Model.Core
Imports System.Collections.Generic
Imports bv.winclient.BasePanel
Imports System.Linq
Imports EIDSS.model.Enums
Imports bv.winclient.Core
Imports bv.winclient.Localization
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports bv.common.Enums
Imports bv.common.win.Validators

Public Class BatchDetail

    Dim BatcheDbService As Batches_DB
    Dim Completed As Boolean = False
    Private m_CanFinalizeTest As Boolean

    Public Sub New()
        MyBase.New()


        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        BatcheDbService = New Batches_DB

        DbService = BatcheDbService
        AuditObject = New AuditObject(EIDSSAuditObject.daoBatchTest, AuditTable.tlbBatchTest)
        Me.PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.Test

        Me.Permissions = New StandardAccessPermissions( _
                PermissionHelper.SelectPermission(EIDSS.model.Enums.EIDSSPermissionObject.Test), _
                PermissionHelper.InsertPermission(EIDSS.model.Enums.EIDSSPermissionObject.Test), _
                PermissionHelper.UpdatePermission(EIDSS.model.Enums.EIDSSPermissionObject.Test), _
                PermissionHelper.DeletePermission(EIDSS.model.Enums.EIDSSPermissionObject.Test), _
                PermissionHelper.ExecutePermission(EIDSS.model.Enums.EIDSSPermissionObject.DataAccess))

        Me.Sizable = False

        Me.RegisterChildObject(FFBatchDetails, RelatedPostOrder.PostLast)
        Me.RegisterChildObject(FFTestDetails, RelatedPostOrder.PostLast)

        'This code is commented as GAT V4 issue - user with laboratorian rights can't change this field and 
        'Dim validate As StandardAccessPermissions = New StandardAccessPermissions(EIDSS.model.Enums.EIDSSPermissionObject.CanValidateTestResult)
        'If Not validate.CanExecute Then
        '    Me.ApplyControlState(Me.cbValidatedBy, ControlState.ReadOnly)
        '    'Me.ApplyControlState(Me.dtDateValidated, ControlState.ReadOnly)
        'End If
        Me.m_RelatedLists = New String() {"LabTestListItem", "LabBatchListItem"}
        AddHandler OnAfterPost, AddressOf AfterPost
        m_CanFinalizeTest = Not [ReadOnly] AndAlso EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.CanFinalizeLabTest))
        btCloseBatch.Enabled = m_CanFinalizeTest
        ValidationProcedureName = "spLabBatch_Validate"

        MenuItem1.Visible = EIDSS.model.Reports.BaseMenuReportRegistrator.IsPaperFormAllowed("LimBatchTest")
    End Sub

    'Public AddedTests As IObject() = Nothing

    Public Overrides Function HasChanges() As Boolean
        If (State And BusinessObjectState.NewObject) <> 0 Then
            Return True
        End If
        Return MyBase.HasChanges()
    End Function


    Protected Overrides Sub DefineBinding()

        Core.LookupBinder.BindBaseLookup(cbTestType, baseDataSet, Batches_DB.TableBatchDetail + ".idfsTestName", db.BaseReferenceType.rftTestName)
        Core.LookupBinder.BindTestResultRepositoryLookup(cbTestResult, True)
        Core.LookupBinder.BindDiagnosisHACodeRepositoryLookup(cbDiagnosis, LookupTables.StandardDiagnosis, False, False)
        Core.LookupBinder.BindBaseRepositoryLookup(cbTestCategory, db.BaseReferenceType.rftTestCategory, False)
        Core.LookupBinder.BindPersonRepositoryLookup(cbResultEnteredBy)
        eventManager.AttachDataHandler(Batches_DB.TestsList + ".idfsDiagnosis", AddressOf DiagnosisChanged)
        eventManager.AttachDataHandler(Batches_DB.TestsList + ".idfsTestResult", AddressOf TestResultChanged)


        eventManager.AttachDataHandler(Batches_DB.TableBatchDetail + ".idfsTestName", AddressOf TestTypeChanged)
        Dim drBatchDetail As DataRow = baseDataSet.Tables(Batches_DB.TableBatchDetail).Rows(0)

        Core.LookupBinder.BindTextEdit(tbBatchID, baseDataSet, Batches_DB.TableBatchDetail + ".strBarcode")

        If (IsDBNull(drBatchDetail("idfPerformedByOffice"))) Then
            drBatchDetail("idfPerformedByOffice") = EidssSiteContext.Instance.OrganizationID
        End If

        Core.LookupBinder.BindOrganizationLookup(cbOrganization, baseDataSet, Batches_DB.TableBatchDetail + ".idfPerformedByOffice", HACode.None)

        Core.LookupBinder.BindDateEdit(dtDateTested, baseDataSet, Batches_DB.TableBatchDetail + ".datPerformedDate")
        Core.LookupBinder.BindDateEdit(dtDateValidated, baseDataSet, Batches_DB.TableBatchDetail + ".datValidatedDate")

        Core.LookupBinder.BindPersonLookup(cbTestedBy, baseDataSet, Batches_DB.TableBatchDetail + ".idfPerformedByPerson", HACode.All)
        Core.LookupBinder.BindPersonLookup(cbValidatedBy, baseDataSet, Batches_DB.TableBatchDetail + ".idfValidatedByPerson", HACode.All)


        '-----------------------------------------------------
        ' load tests
        Dim dtTests As DataTable = baseDataSet.Tables(Batches_DB.TestsList)
        'If (Not Me.AddedTests Is Nothing AndAlso Me.AddedTests.Length > 0) Then
        '    drBatchDetail("idfsTestName") = Me.AddedTests(0).GetValue("idfsTestName")
        '    AddTestsToBatchInMem(Me.AddedTests)
        '    Me.AddedTests = Nothing
        'End If

        fixEmptyTestOrderNumber(dtTests)

        Dim dv As DataView = New DataView(dtTests)
        dv.Sort = "intTestNumber,idfTesting"

        gridTests.DataSource = dv
        ReMakeOrderNumbers()

        ShowBatchFF()
        ShowTestFF()

        Core.LookupBinder.SetPersonFilter(drBatchDetail, "idfPerformedByOffice", cbTestedBy)
        Core.LookupBinder.SetPersonFilter(drBatchDetail, "idfPerformedByOffice", cbValidatedBy)

        ' test completed => ReadOnly mode
        If drBatchDetail("idfsBatchStatus").Equals(CLng(BatchStatusEnum.Completed)) Then
            Completed = True
            HideEditButtons()
        End If

        ReflectStatus()

    End Sub

    Sub fixEmptyTestOrderNumber(ByRef dtTests As DataTable)
        For i As Integer = 0 To dtTests.Rows.Count - 1
            If (IsDBNull(dtTests.Rows(i)("intTestNumber"))) Then dtTests.Rows(i)("intTestNumber") = 0
        Next

    End Sub

    Private Sub GridView1_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles TestsView.FocusedRowChanged
        If (m_BindingDefined) Then
            ShowTestFF()
        End If
    End Sub

    Private Sub btAddTests_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btAddTests.Click

        If (CheckBatchType() = False) Then Return

        Dim batchID As Long = CType(DbService.ID, Long)

        Dim testsList As IBaseListPanel = GetTestsForm(batchID, cbTestType.EditValue)


        Dim selectedTests As IList(Of IObject) = BaseFormManager.ShowForMultiSelection(testsList, FindForm)
        If Not selectedTests Is Nothing AndAlso selectedTests.Count > 0 Then
            AddTestsToBatchInMem(selectedTests)
            'gridTests.Refresh()
            ReMakeOrderNumbers()
            ReflectStatus()
        End If


    End Sub

    Sub AddTestsToBatchInMem(selectedTests As IList(Of IObject))

        If (selectedTests Is Nothing OrElse selectedTests.Count = 0) Then Return
        'Disable automatic showing of FF duiring FocusChanged event
        'and show test FF explicitly after adding new tests
        'This is workaround for bug 13007
        m_BindingDefined = False
        Try
            For Each test As IObject In selectedTests
                Dim tstStatus As Long? = CType(test.GetValue("idfsTestStatus"), Long?)
                If (tstStatus.HasValue AndAlso Not CLng(TestStatus.NotStarted).Equals(tstStatus.Value)) Then
                    Continue For
                End If
                If (IsTestExists(test.GetValue("idfTesting"))) Then Continue For
                AddNewTest(test)
            Next
            ShowTestFF()
        Finally
            m_BindingDefined = True
        End Try
    End Sub



    Sub AddTestsToBatchInMem(ByRef selectedTests As DataRow())

        If (selectedTests Is Nothing OrElse selectedTests.Length = 0) Then Return
        m_BindingDefined = False
        Try
            For Each test As DataRow In selectedTests
                Dim tstStatus As Object = test("idfsTestStatus")
                If (Not Utils.IsEmpty(tstStatus) AndAlso Not CLng(TestStatus.NotStarted).Equals(tstStatus)) Then
                    Continue For
                End If
                If IsTestExists(test("idfTesting")) Then Continue For
                AddNewTest(test)
            Next
            ShowTestFF()
        Finally
            m_BindingDefined = True
        End Try
    End Sub

    Function CheckBatchType() As Boolean
        If Utils.IsEmpty(cbTestType.EditValue) Then
            MessageForm.Show(EidssMessages.Get("msgBatchSelectType", "Select Test Name first"))
            Return False
        End If
        Return True
    End Function

    ReadOnly Property TestsTable As DataTable
        Get
            If (Not baseDataSet Is Nothing AndAlso baseDataSet.Tables.Contains(Batches_DB.TestsList)) Then
                Return baseDataSet.Tables(Batches_DB.TestsList)
            End If
            Return Nothing
        End Get
    End Property
    Function IsTestExists(ByRef testId As Object) As Boolean
        If (Utils.IsEmpty(testId)) Then
            Return False
        End If
        Dim filter As String = String.Format("idfTesting={0}", testId)
        Dim duplicatedRows As DataRow() = TestsTable.Select(filter)
        If (duplicatedRows.Length = 0) Then Return False
        Return True
    End Function


    Private Sub CopyIObjectValue(targetRow As DataRow, colName As String, source As IObject)
        Dim val As Object = source.GetValue(colName)
        If Not val Is Nothing Then
            targetRow(colName) = val
        End If
    End Sub
    Private Sub CopyDataRowValue(targetRow As DataRow, colName As String, sourceRow As DataRow)
        If sourceRow.Table.Columns.Contains(colName) Then
            targetRow(colName) = sourceRow(colName)
        End If
    End Sub
    Sub AddNewTest(test As Object)
        Dim newRow As DataRow = TestsTable.NewRow()
        ' copy Data 
        For i As Integer = 0 To TestsTable.Columns.Count - 1
            Dim col As String = TestsTable.Columns(i).ColumnName
            If (TypeOf (test) Is IObject) Then
                CopyIObjectValue(newRow, col, CType(test, IObject))
            Else
                CopyDataRowValue(newRow, col, CType(test, DataRow))
            End If
        Next
        newRow("intTestNumber") = Integer.MaxValue
        TestsTable.Rows.Add(newRow)
        DataEventManager.Flush()
    End Sub

    <CLSCompliant(False)> _
    Function GetTestsForm(ByVal batchID As Long, ByVal testNameId As Object) As IBaseListPanel

        Dim selectTestsForBatchForm As Object
        selectTestsForBatchForm = ClassLoader.LoadClass("TestListPanel")
        If selectTestsForBatchForm Is Nothing Then
            Return Nothing
        End If
        ReflectionHelper.SetProperty(selectTestsForBatchForm, "FormID", "L15")

        Dim gridView As DevExpress.XtraGrid.Views.Grid.GridView = CType(selectTestsForBatchForm, IBaseListPanel).Grid.GridView
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In gridView.Columns
            col.Visible = False
        Next
        gridView.Columns("strBarcode").Visible = True
        gridView.Columns("DiagnosisName").Visible = True
        gridView.Columns("strSampleName").Visible = True
        gridView.Columns("TestName").Visible = True
        gridView.Columns("CaseID").Visible = True
        gridView.Columns("HumanName").Visible = True
        gridView.Columns("strFieldBarcode").Visible = True

        Dim filter As New FilterParams
        filter.Add("idfsTestName", "=", CLng(testNameId))
        filter.Add("idfsTestStatus", "=", CLng(TestStatus.NotStarted))
        filter.Add("BatchTestIsNull", "", Nothing)
        ReflectionHelper.SetProperty(selectTestsForBatchForm, "StaticFilter", filter)
        ReflectionHelper.SetProperty(selectTestsForBatchForm, "SearchPanelVisible", False)
        Return CType(selectTestsForBatchForm, IBaseListPanel)

    End Function


    Private Sub btDelTest_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btDelTest.Click
        TestsView.DeleteSelectedRows()
        ReMakeOrderNumbers()
        ReflectStatus()
    End Sub

    Private m_ClosedInCurrentSession As Boolean
    Private Sub btCloseBatch_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btCloseBatch.Click

        If (ValidateData() = False) Then
            m_PromptResult = DialogResult.Cancel

        Else
            If TestsView.RowCount = 0 Then Return
            ' 1 check all tests
            If (ValidateTestsStatus() = False) Then Return
            If (ValidateBatch() = False) Then Return

            If (AskConfirmation() = False) Then Return
            baseDataSet.Tables(Batches_DB.TableBatchDetail).Rows(0)("idfsBatchStatus") = CLng(BatchStatusEnum.Completed)
            baseDataSet.Tables(Batches_DB.TableBatchDetail).Rows(0)("idfValidatedByPerson") = EidssUserContext.User.EmployeeID
            Completed = True
            m_ClosedInCurrentSession = True
            HideEditButtons()
        End If

    End Sub

    Function ValidateBatch() As Boolean
        Dim maxAccessionDate As DateTime? = _
         (From test In baseDataSet.Tables(Batches_DB.TestsList) Where test.RowState <> DataRowState.Deleted AndAlso test.RowState <> DataRowState.Detached AndAlso Not (test.Field(Of Nullable(Of DateTime))("datAccession") Is Nothing)
            Select test.Field(Of DateTime?)("datAccession")).Min

        If maxAccessionDate Is Nothing Then
            ErrorForm.ShowMessage("errBatchEmptyAccessionDate", "Some tests in batch are related with samples that was not accessioned.")
            Return False

        End If
        Return True
    End Function
    'Private Function ValidateMandatoryField(ByVal ctl As Control, ByVal fieldName As String) As Boolean
    '    If Utils.IsEmpty(baseDataSet.Tables(Batches_DB.TableBatchDetail).Rows(0)(fieldName)) Then
    '        MyBase.ShowErrorAtValidateMandatoryFields(ctl)
    '        Return False
    '    End If
    '    Return True
    'End Function


    Function ValidateTestsStatus() As Boolean
        For Each dr As DataRow In TestsTable.Rows
            If (dr.RowState = DataRowState.Deleted OrElse dr.RowState = DataRowState.Detached) Then
                Continue For
            End If
            If (IsDBNull(dr("idfsTestResult"))) Then
                MessageForm.Show(EidssMessages.Get("msgTestsNotHaveResults", "Not all tests have result."))
                Return False
            End If
        Next
        Return True
    End Function

    Function AskConfirmation() As Boolean
        Dim result As DialogResult = MessageForm.Show(EidssMessages.Get("msgBatch_CloseBatch"), EidssMessages.Get("mbConfirmation"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        Return (result = DialogResult.Yes)
    End Function

    Sub HideEditButtons()
        If Not Completed Then Return
        btCloseBatch.Enabled = False
        TestsView.OptionsBehavior.ReadOnly = True
        TestsView.OptionsBehavior.Editable = False
        btnAddTestByBarcode.Enabled = False
        txtScannedBarcode.Enabled = False
        btnAddGroupResult.Enabled = False
        btAddTests.Enabled = False
        btDelTest.Enabled = False
        FFTestDetails.ReadOnly = True
        FFBatchDetails.ReadOnly = True

        For Each ctrl As Control In Controls
            If ctrl.Top <= gridTests.Top And ctrl.Right <= gridTests.Right Then
                If TypeOf (ctrl) Is DevExpress.XtraEditors.BaseControl Then
                    If (ctrl Is cbTestedBy OrElse ctrl Is dtDateTested OrElse ctrl Is dtDateValidated) Then
                        If m_ClosedInCurrentSession Then
                            ApplyControlState(CType(ctrl, DevExpress.XtraEditors.BaseControl), ControlState.Mandatory)
                            Continue For
                        End If
                    End If
                    ApplyControlState(CType(ctrl, DevExpress.XtraEditors.BaseControl), ControlState.ReadOnly)
                End If
            End If
        Next
    End Sub


#Region "Reorder Tests"

    Private Sub btUP_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btUP.Click
        MoveSelected(-1)
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SimpleButton2.Click
        MoveSelected(1)
    End Sub


    Sub MoveSelected(ByVal direction As Integer)
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(gridTests.DefaultView, DevExpress.XtraGrid.Views.Grid.GridView)

        Dim pos As Integer = view.FocusedRowHandle
        If (pos < 0) Then Return
        If (pos + Direction < 0 OrElse (pos + Direction > view.RowCount - 1)) Then Return

        ReMakeOrderNumbers()

        Dim drCurr As DataRowView = CType(view.GetRow(pos), DataRowView)
        Dim drNext As DataRowView = CType(view.GetRow(pos + Direction), DataRowView)

        Dim tmp As Object = drCurr("intTestNumber")
        drCurr("intTestNumber") = drNext("intTestNumber")
        drNext("intTestNumber") = tmp

        view.FocusedRowHandle = pos + Direction

    End Sub


    Sub ReMakeOrderNumbers()

        ' проблема: при изменении позиции сразу же перестраивается порядок, 
        ' поэтому сначала собираем позиции, затем модифицируем данные  
        'Dim ht As New Hashtable
        Dim orders As New Dictionary(Of Object, Integer)

        For i As Integer = 0 To TestsView.RowCount - 1
            orders(TestsView.GetDataRow(i)("idfTesting")) = i
        Next

        For i As Integer = 0 To TestsTable.Rows.Count - 1
            Dim row As DataRow = TestsTable.Rows(i)
            If row.RowState = DataRowState.Deleted Then Continue For
            Dim order As Integer = orders(row("idfTesting"))
            If Utils.Str(order) <> Utils.Str(row("intTestNumber")) Then
                row("intTestNumber") = order
            End If
        Next
    End Sub

#End Region



    Private Sub GridView1_DoubleClick(ByVal sender As System.Object, ByVal e As EventArgs) Handles TestsView.DoubleClick

        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim pt As Point = view.GridControl.PointToClient(MousePosition)
        Dim info As GridHitInfo = view.CalcHitInfo(pt)
        If (info.InRow OrElse info.InRowCell) Then
            Dim pos As Integer = view.FocusedRowHandle
            If (pos < 0) Then Return
            Dim dr As DataRow = CType(view.GetRow(pos), DataRowView).Row
            If (dr Is Nothing) Then Return

            Dim testID As Object = dr("idfTesting")
            If CLng(testID) <= 0 Then
                Return
            End If
            Dim detailForm As New LabTestDetail
            BaseFormManager.ShowModal_ReadOnly(detailForm, FindForm, testID, Nothing, Nothing)
        End If

    End Sub

    Private Sub ReflectStatus()
        Dim filled As Boolean = TestsView.RowCount > 0
        cbTestType.Properties.ReadOnly = filled
        For Each btn As DevExpress.XtraEditors.Controls.EditorButton In cbTestType.Properties.Buttons
            btn.Enabled = Not filled
        Next
        gbTestDetails.Visible = filled
        btCloseBatch.Enabled = filled AndAlso Not Completed
    End Sub

    Private Sub TestTypeChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        ShowBatchFF()
    End Sub
    Private Sub DiagnosisChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        Dim testCategory As Object = DBNull.Value
        If Not Utils.IsEmpty(e.Value) Then
            testCategory = LabTest_DB.GetDefaultTestCategory(CLng(e.Value), CLng(e.Row("idfsTestName")))
        End If
        If (Not Utils.IsEmpty(testCategory)) Then
            e.Row("idfsTestCategory") = testCategory
        End If
    End Sub
    Private Sub TestResultChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        If Utils.IsEmpty(e.Value) Then
            e.Row("idfResultEnteredByPerson") = DBNull.Value
        Else
            e.Row("idfResultEnteredByPerson") = EidssUserContext.User.EmployeeID
        End If
        e.Row.EndEdit()
    End Sub
    Private Sub ShowBatchFF()
        Dim row As DataRow = baseDataSet.Tables(Batches_DB.TableBatchDetail).Rows(0)
        Dim type As Object = row("idfsTestName")
        LabUtils.ShowFF(FFBatchDetails, type, row, FFType.TestRun)
        If Not (cbTestResult.DataSource Is Nothing) Then
            If (Utils.IsEmpty(type)) Then type = "-1"
            CType(cbTestResult.DataSource, DataView).RowFilter = String.Format("idfsTestName = {0} and intRowStatus = 0", type)
        End If
    End Sub

    Private Sub ShowTestFF()
        If (baseDataSet.Tables(Batches_DB.TableBatchDetail).Rows.Count > 0) Then
            Dim row As DataRow = baseDataSet.Tables(Batches_DB.TableBatchDetail).Rows(0)
            Dim type As Object = row("idfsTestName")
            LabUtils.ShowFF(FFTestDetails, type, TestsView.GetDataRow(TestsView.FocusedRowHandle), FFType.TestDetails)
        End If
    End Sub

    Private Sub btnSampleSearch_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnSampleSearch.Click

        If gridTests.DataSource Is Nothing Then Exit Sub

        Dim viewMain As DataView = CType(gridTests.DataSource, DataView)

        If Not (viewMain.Table.Rows.Count = 0) Then
            viewMain.Sort = "strBarcode"

            Dim dataRow As Integer = viewMain.Find(txtSamplesSearchAdvanced.Text())


            If (dataRow >= 0) Then

                Dim d As DataRow = viewMain(dataRow).Row
                DxControlsHelper.SetRowHandleForDataRow(TestsView, d, "idfTesting")

                TestsView.ClearSelection()

                TestsView.SelectRow(TestsView.FocusedRowHandle)
            Else
                viewMain.Sort = "intTestNumber,idfTesting"
                MessageForm.Show(EidssMessages.Get("ErrFieldSampleIDNotFound", "Sample is not found."))
            End If
        End If

    End Sub

#Region "REPORTS"

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles MenuItem1.Click
        If baseDataSet Is Nothing OrElse baseDataSet.Tables.Count = 0 Then
            Return
        End If

        Dim drBatchDetail As DataRow = baseDataSet.Tables(Batches_DB.TableBatchDetail).Rows(0)
        If Post(PostType.FinalPosting) Then
            Dim id As Long = CType(DbService.ID, Long)
            Dim typeID As Long = CType(drBatchDetail("idfsTestName"), Long)
            EidssSiteContext.ReportFactory.LimBatchTest(id, typeID)
        End If
    End Sub

#End Region
    Protected Overrides Sub AfterLoad()
        MyBase.AfterLoad()
        ShowBatchFF()
        ShowTestFF()
    End Sub
    Protected Sub AfterPost(ByVal sender As Object, ByVal e As EventArgs)
        m_ClosedInCurrentSession = False
        HideEditButtons()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub btnAddGroupResult_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnAddGroupResult.Click
        Dim form As New BatchSelectTestResult


        Dim startupParams As New Dictionary(Of String, Object)
        startupParams.Add("idfsTestName", baseDataSet.Tables(Batches_DB.TableBatchDetail).Rows(0)("idfsTestName"))

        Dim id As Object = Nothing
        CType(form, IApplicationForm).StartUpParameters = startupParams
        If BaseFormManager.ShowModal(CType(form, IApplicationForm), FindForm, id, Nothing, startupParams, Nothing, Nothing) Then
            Dim result As Object = form.LookUpTestResult.EditValue
            Dim selectedRows As Integer() = TestsView.GetSelectedRows()
            For Each row As DataRow In From i In selectedRows Select TestsView.GetDataRow(i)
                row("idfsTestResult") = result
                row("idfResultEnteredByPerson") = EidssUserContext.User.EmployeeID
            Next
        End If
    End Sub
    Private ReadOnly m_SampleDiagnosis As New Dictionary(Of Long, String)
    Private Sub SearchByBarcode(ByVal barcode As String)
        If (CheckBatchType() = False) Then Return

        Dim batchRow As DataRow = baseDataSet.Tables(Batches_DB.TableBatchDetail).Rows(0)
        Dim ds As DataSet = BatcheDbService.SelectTestsBySampleID(CLng(batchRow("idfsTestName")), barcode)
        Dim table As DataTable = ds.Tables(Batches_DB.TestsList)
        If table.Rows.Count > 0 Then
            Dim sourceRow As DataRow = table.Rows(0)
            Dim rows As DataRow()
            If CLng(sourceRow("idfTesting")) = -1 Then
                sourceRow("idfTesting") = BaseDbService.NewIntID()
                sourceRow("idfsTestCategory") = DBNull.Value
                sourceRow("idfsDiagnosis") = ds.Tables("DefaultDiagnosis").Rows(0)("idfsDiagnosis")
                sourceRow("idfObservation") = 0
                rows = New DataRow() {sourceRow}
                Dim diagnosisList As String = ""
                For Each row As DataRow In ds.Tables("Diagnosis").Rows
                    If diagnosisList = "" Then
                        diagnosisList = Utils.Str(row("idfsDiagnosis"), "0")
                    Else
                        diagnosisList += "," + Utils.Str(row("idfsDiagnosis"), "0")
                    End If
                Next
                If m_SampleDiagnosis.ContainsKey(CLng(sourceRow("idfMaterial"))) Then
                    m_SampleDiagnosis(CLng(sourceRow("idfMaterial"))) = diagnosisList
                Else
                    m_SampleDiagnosis.Add(CLng(sourceRow("idfMaterial")), diagnosisList)
                End If
            Else
                rows = table.Select("")
            End If
            AddTestsToBatchInMem(rows)

            gridTests.Refresh()
            ReMakeOrderNumbers()
            ReflectStatus()
        Else
            MessageForm.Show(EidssMessages.Get("ErrFieldSampleIDNotFound", "Sample is not found."))
        End If
        Application.DoEvents()
        txtScannedBarcode.Focus()

    End Sub

    Private Sub btnAddTestByBarcode_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnAddTestByBarcode.Click

        SearchByBarcode(txtScannedBarcode.Text)

    End Sub

    Private Sub txtScannedBarcode_EditValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles txtScannedBarcode.EditValueChanged
        If txtScannedBarcode.Text.Contains("\n") Then
            SearchByBarcode(txtScannedBarcode.Text.Replace("\n", ""))
        End If
    End Sub

    Private Sub txtScannedBarcode_KeyDown(ByVal sender As Object, ByVal e As Windows.Forms.KeyEventArgs) Handles txtScannedBarcode.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            SearchByBarcode(txtScannedBarcode.Text)
            e.Handled = True
            e.SuppressKeyPress = True
        End If


    End Sub

    Private Sub GridView1_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TestsView.ShowingEditor
        Dim row As DataRow = TestsView.GetFocusedDataRow
        If (TestsView.FocusedColumn Is colTestResult) Then
            Return
        End If
        If (Utils.IsEmpty(row("idfMaterial")) OrElse CLng(row("idfMaterial")) <= 0) Then
            'Show editor for diagnosis and category if they are empty
            If (TestsView.FocusedColumn Is colDiagnosis AndAlso Utils.IsEmpty(row("idfsDiagnosis"))) Then
                Return
            End If
            If TestsView.FocusedColumn Is colCategory Then
                e.Cancel = Completed AndAlso Not m_ClosedInCurrentSession
                Return
            End If

            e.Cancel = True
        End If

    End Sub

    Public Overrides Function ValidateData() As Boolean
        If Not MyBase.ValidateData() Then
            Return False
        End If

        For Each dr As DataRow In baseDataSet.Tables(Batches_DB.TestsList).Rows
            If (dr.RowState = DataRowState.Deleted) Then Continue For
            If (IsDBNull(dr("idfsDiagnosis"))) Then
                MessageForm.Show(EidssMessages.Get("msgTestsNotHaveDiagnosis", "Not all tests have diagnosis."))
                Return False
            End If
            'If (IsDBNull(dr("idfsTestCategory"))) Then
            '    MessageForm.Show(EidssMessages.Get("msgTestsNotHaveCategory", "Not all tests have category."))
            '    Return False
            'End If
        Next
        Return True 'lower is an old code

        'If (Completed) Then
        '    Dim maxAccessionDate As DateTime? = _
        '     (From test In Me.baseDataSet.Tables(Batches_DB.TestsList) Where test.RowState <> DataRowState.Deleted AndAlso test.RowState <> DataRowState.Detached AndAlso Not (test.Field(Of Nullable(Of DateTime))("datAccession") Is Nothing)
        '        Select test.Field(Of DateTime?)("datAccession")).Min

        '    Dim BatchTable As DataTable = baseDataSet.Tables(Batches_DB.TableBatchDetail)

        '    Dim datConcludedDate As DateTime = CType(BatchTable.Rows(0).Item("datValidatedDate"), DateTime)
        '    Dim datStartedDate As DateTime = CType(BatchTable.Rows(0).Item("datPerformedDate"), DateTime)

        '    If datConcludedDate < datStartedDate Then
        '        bv.common.win.ErrorForm.ShowMessageDirect(EidssMessages.Get("datBatchStartDate_ConcludedDate_msgId"))
        '        Return False
        '    End If

        '    If datStartedDate < (maxAccessionDate.Value.Date) Then
        '        bv.common.win.ErrorForm.ShowMessageDirect(EidssMessages.Get("datAccessionDate_BatchStartDate_msgId"))
        '        Return False
        '    End If

        'End If
        'Return True
    End Function

    Private Sub cbDiagnosis_QueryCloseUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbDiagnosis.QueryCloseUp
        CType(cbDiagnosis.DataSource, DataView).RowFilter = ""
    End Sub

    Private Sub cbDiagnosis_QueryPopUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbDiagnosis.QueryPopUp
        Dim row As DataRow = TestsView.GetFocusedDataRow
        If (Utils.IsEmpty(row("idfMaterial")) OrElse CLng(row("idfMaterial")) > 0) Then
            CType(cbDiagnosis.DataSource, DataView).RowFilter = String.Format("idfsDiagnosis in ({0})", m_SampleDiagnosis(CLng(row("idfMaterial"))))
        End If
    End Sub
    Public Overrides Sub UpdateButtonsState(ByVal sender As Object, ByVal e As EventArgs)
        btnAddGroupResult.Enabled = Not Completed AndAlso TestsView.SelectedRowsCount > 0
        btDelTest.Enabled = Not Completed AndAlso TestsView.SelectedRowsCount > 0
        btnSampleSearch.Enabled = Not Utils.IsEmpty(txtSamplesSearchAdvanced.Text)
        btnAddTestByBarcode.Enabled = Not Completed AndAlso Not Utils.IsEmpty(txtScannedBarcode.Text)
    End Sub

    Dim m_DatesValidator As DateChainValidator

    Protected Overrides Sub RegisterValidators()
        MyBase.RegisterValidators()
        Dim item As ChainValidator(Of DateTime)

        m_DatesValidator = New DateChainValidator(Me, Nothing, Batches_DB.TestsList, "datAccession", EidssFields.Get("datAccession"), , , , True)
        item = m_DatesValidator.AddChild(New DateChainValidator(Me, dtDateTested, Batches_DB.TableBatchDetail, "datPerformedDate", Label11.Text, , , , True))
        item.AddChild(New DateChainValidator(Me, dtDateValidated, Batches_DB.TableBatchDetail, "datValidatedDate", Label3.Text, , , , True))
        m_DatesValidator.RegisterValidator(Me, True)
    End Sub

End Class

