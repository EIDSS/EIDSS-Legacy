Imports System.Drawing
Imports eidss.model.Core
Imports EIDSS.model.Resources
Imports bv.model.Model.Core
Imports System.Collections.Generic
Imports bv.winclient.BasePanel
Imports System.Linq
Imports EIDSS.model.Enums
Imports bv.winclient.Core
Imports bv.winclient.Localization
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class BatchDetail

    Dim BatcheDbService As Batches_DB
    Dim Completed As Boolean = False

    Public Sub New()
        MyBase.New()


        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        BatcheDbService = New Batches_DB

        DbService = BatcheDbService
        AuditObject = New Core.EIDSSAuditObject(EIDSSAuditObject.daoBatchTest, AuditTable.tlbBatchTest)
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

    End Sub

    Public AddedTests As IObject() = Nothing

    Public Overrides Function HasChanges() As Boolean
        If (State And BusinessObjectState.NewObject) <> 0 Then
            Return True
        End If
        Return MyBase.HasChanges()
    End Function

#Region "Flex Form Support"

    'Private Function SelectTemplateTestRun(Optional ByVal strTestType As String = "") As String
    '    Exit Function
    '    Dim err As ErrorMessage = Nothing
    '    Dim st As String = ""
    '    Dim drBatchDetail As DataRow = baseDataSet.Tables(Batches_DB.TableBatchDetail).Rows(0)
    '    'Me.FFTestRunDetails.ShowFlexibleForm(Me.FFT

    '    ' Means we didn't call it during TestType value change
    '    If strTestType = "" Then
    '        If drBatchDetail("idfsFFormTemplateID").ToString.Length <> 0 Then
    '            st = drBatchDetail("idfsFFormTemplateID").ToString
    '            Return st
    '        Else
    '            strTestType = "?"
    '        End If
    '    End If

    '    Try
    '        'stCountry = BaseDbService.ExecScalar("select idfsCountry from Site where idfsSite = dbo.fnSiteID()", HumanCaseDbService.Connection, err).ToString
    '        st = BatcheDbService.GetFFTemplate("ftyTestRun", strTestType) ' + "," + stCountry)
    '    Catch ex As Exception
    '        err = New ErrorMessage(StandardError.FillDatasetError, ex)
    '        st = ""
    '    End Try

    '    ''drBatchDetail("idfsFFormTemplateID") = st
    '    Return st
    'End Function

    Private Function SelectTemplateTest(Optional ByRef dr As DataRowView = Nothing, Optional ByVal strTestType As String = "") As Object
        Dim err As ErrorMessage = Nothing
        Dim stCountry As String
        Dim st As Object
        st = DBNull.Value

        stCountry = EIDSS.model.Core.EidssSiteContext.Instance.CountryID.ToString

        ' Means we didn't call it during TestType value change
        If strTestType = "" Then
            If Not dr Is Nothing Then
                If dr("idfsFFormTemplateID").ToString.Length <> 0 Then
                    st = dr("idfsFFormTemplateID").ToString
                    Return st
                Else
                    strTestType = "?"
                End If
            Else
                strTestType = "?"
            End If
        End If

        Try
            'stCountry = BaseDbService.ExecScalar("select idfsCountry from Site where idfsSite = dbo.fnSiteID()", HumanCaseDbService.Connection, err).ToString
            st = BatcheDbService.GetFFTemplate("ftyTestDetails", strTestType + "," + stCountry)
        Catch ex As Exception
            err = New ErrorMessage(StandardError.FillDatasetError, ex)
            st = DBNull.Value
        End Try

        If (Not dr Is Nothing) AndAlso dr.DataView.AllowEdit Then
            dr("idfsTemplate") = st
        End If

        Return st
    End Function

#End Region


    Protected Overrides Sub DefineBinding()

        Core.LookupBinder.BindBaseLookup(cbTestType, baseDataSet, Batches_DB.TableBatchDetail + ".idfsTestType", bv.common.db.BaseReferenceType.rftTestType)
        Core.LookupBinder.BindTestResultRepositoryLookup(Me.cbTestResult, True)
        'Core.LookupBinder.BindStandardDiagnosisRepositoryLookup(cbDiagnosis, HACode.HumanAnimal Or HACode.Vector Or HACode.Avian Or HACode.Livestock)
        Core.LookupBinder.BindDiagnosisHACodeRepositoryLookup(cbDiagnosis, LookupTables.StandardDiagnosis, False, False)
        Core.LookupBinder.BindBaseRepositoryLookup(cbTestCategory, bv.common.db.BaseReferenceType.rftTestForDiseaseType, False)
        Core.LookupBinder.BindPersonRepositoryLookup(cbResultEnteredBy)
        eventManager.AttachDataHandler(Batches_DB.TestsList + ".idfsDiagnosis", AddressOf DiagnosisChanged)
        eventManager.AttachDataHandler(Batches_DB.TestsList + ".idfsTestResult", AddressOf TestResultChanged)


        eventManager.AttachDataHandler(Batches_DB.TableBatchDetail + ".idfsTestType", AddressOf TestTypeChanged)
        Dim drBatchDetail As DataRow = baseDataSet.Tables(Batches_DB.TableBatchDetail).Rows(0)

        Core.LookupBinder.BindTextEdit(tbBatchID, baseDataSet, Batches_DB.TableBatchDetail + ".strBarcode")

        Dim OrganizationID As Object = EIDSS.model.Core.EidssSiteContext.Instance.OrganizationID

        If (IsDBNull(drBatchDetail("idfPerformedByOffice"))) Then
            drBatchDetail("idfPerformedByOffice") = EIDSS.model.Core.EidssSiteContext.Instance.OrganizationID
        Else
            OrganizationID = drBatchDetail("idfPerformedByOffice")
        End If

        Core.LookupBinder.BindOrganizationLookup(cbOrganization, baseDataSet, Batches_DB.TableBatchDetail + ".idfPerformedByOffice")

        Core.LookupBinder.BindDateEdit(dtDateTested, baseDataSet, Batches_DB.TableBatchDetail + ".datPerformedDate")
        Core.LookupBinder.BindDateEdit(dtDateValidated, baseDataSet, Batches_DB.TableBatchDetail + ".datValidatedDate")

        Core.LookupBinder.BindPersonLookup(Me.cbTestedBy, baseDataSet, Batches_DB.TableBatchDetail + ".idfPerformedByPerson")
        Core.LookupBinder.BindPersonLookup(Me.cbValidatedBy, baseDataSet, Batches_DB.TableBatchDetail + ".idfValidatedByPerson")


        '-----------------------------------------------------
        ' load tests
        Dim dtTests As DataTable = baseDataSet.Tables(Batches_DB.TestsList)
        If (Not Me.AddedTests Is Nothing AndAlso Me.AddedTests.Length > 0) Then
            drBatchDetail("idfsTestType") = Me.AddedTests(0).GetValue("idfsTestType")
            AddTestsToBatchInMem(Me.AddedTests)
            Me.AddedTests = Nothing
        End If

        fixEmptyTestOrderNumber(dtTests)

        Dim dv As DataView = New DataView(dtTests)
        dv.Sort = "intTestNumber,idfTesting"

        gridTests.DataSource = dv
        ReMakeOrderNumbers()

        Me.ShowBatchFF()
        Me.ShowTestFF()

        Core.LookupBinder.SetPersonFilter(drBatchDetail, "idfPerformedByOffice", cbTestedBy)
        Core.LookupBinder.SetPersonFilter(drBatchDetail, "idfPerformedByOffice", cbValidatedBy)

        ' test completed => ReadOnly mode
        If drBatchDetail("idfsBatchStatus").Equals(CLng(BatchStatusEnum.Completed)) Then
            Completed = True
            HideEditButtons()
        End If

        Me.ReflectStatus()

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

    Private Sub btAddTests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAddTests.Click

        If (CheckBatchType() = False) Then Return

        Dim BatchID As Long = CType(DbService.ID, Long)

        Dim SelectTestsForBatchForm As IBaseListPanel = GetTestsForm(BatchID, Me.cbTestType.EditValue.ToString())


        Dim selTests As IList(Of IObject) = BaseFormManager.ShowForMultiSelection(SelectTestsForBatchForm, FindForm)
        If Not selTests Is Nothing AndAlso selTests.Count > 0 Then
            AddTestsToBatchInMem(selTests.ToArray())
            Me.gridTests.Refresh()
            ReMakeOrderNumbers()
            ReflectStatus()
        End If


    End Sub

    Sub AddTestsToBatchInMem(ByRef AddedTests As IObject())

        If (AddedTests Is Nothing OrElse AddedTests.Length = 0) Then Return

        Dim ExistTests As DataTable = baseDataSet.Tables(Batches_DB.TestsList)

        For Each Added As IObject In AddedTests
            Dim tstStatus As Long? = CType(Added.GetValue("idfsTestStatus"), Long?)
            If (tstStatus.HasValue AndAlso Not CLng(TestStatus.Undefined).Equals(tstStatus.Value)) Then
                Continue For
            End If
            Dim IsDuplicated As Boolean = IsTestExists(ExistTests, Added)

            If (IsDuplicated) Then Continue For
            AddNewTest(ExistTests, Added)
        Next


        gridTests.DataSource = ExistTests
    End Sub



    Sub AddTestsToBatchInMem(ByRef AddedTests As DataRow())

        If (AddedTests Is Nothing OrElse AddedTests.Length = 0) Then Return

        Dim ExistTests As DataTable = baseDataSet.Tables(Batches_DB.TestsList)

        For Each Added As DataRow In AddedTests
            Dim tstStatus As Object = Added("idfsTestStatus")
            If (Not Utils.IsEmpty(tstStatus) AndAlso Not CLng(TestStatus.Undefined).Equals(tstStatus)) Then
                Continue For
            End If
            Dim IsDuplicated As Boolean = IsTestExists(ExistTests, Added)
            If (IsDuplicated) Then Continue For
            AddNewTest(ExistTests, Added)
        Next


        gridTests.DataSource = ExistTests
    End Sub

    Function CheckBatchType() As Boolean
        If (Me.cbTestType.EditValue.ToString() = "") Then
            bv.winclient.Core.MessageForm.Show(EidssMessages.Get("msgBatchSelectType", "Select Test Name first"))
            Return False
        End If

        Return True
    End Function

    Function IsTestExists(ByRef ExistTests As DataTable, ByRef AddedTest As DataRow) As Boolean

        Dim Filter As String = String.Format("idfTesting='{0}'", AddedTest("idfTesting").ToString())
        Dim Dublicates As DataRow() = ExistTests.Select(Filter, "", DataViewRowState.Deleted)

        If (Dublicates.Length = 0) Then Return False

        Dublicates(0).RejectChanges()
        Return True
    End Function

    Function IsTestExists(ByRef ExistTests As DataTable, ByRef AddedTest As IObject) As Boolean

        Dim Filter As String = String.Format("idfTesting='{0}'", AddedTest.GetValue("idfTesting").ToString())
        Dim Dublicates As DataRow() = ExistTests.Select(Filter, "", DataViewRowState.Deleted)

        If (Dublicates.Length = 0) Then Return False

        Dublicates(0).RejectChanges()
        Return True
    End Function

    Sub AddNewTest(ByRef ExistTests As DataTable, ByRef AddedTest As DataRow)
        Try

            Dim newrow As DataRow = ExistTests.NewRow()

            ' copy Data 
            For i As Integer = 0 To ExistTests.Columns.Count - 1
                Dim col As String = ExistTests.Columns(i).ColumnName
                If AddedTest.Table.Columns.Contains(col) Then
                    newrow(col) = AddedTest(col)
                End If

            Next
            newrow("intTestNumber") = Integer.MaxValue
            ExistTests.Rows.Add(newrow)
        Catch e As ConstraintException
        End Try

    End Sub
    ' TODO
    Sub AddNewTest(ByRef ExistTests As DataTable, ByRef AddedTest As IObject)
        Try

            Dim newrow As DataRow = ExistTests.NewRow()

            ' copy Data 
            For i As Integer = 0 To ExistTests.Columns.Count - 1
                Dim col As String = ExistTests.Columns(i).ColumnName
                Dim val As Object = AddedTest.GetValue(col)
                If val Is Nothing Then
                    newrow(col) = DBNull.Value
                Else
                    newrow(col) = val
                End If
            Next

            newrow("intTestNumber") = Integer.MaxValue

            ExistTests.Rows.Add(newrow)
        Catch e As ConstraintException
        End Try
    End Sub

    <CLSCompliant(False)> _
    Function GetTestsForm(ByVal BatchID As Long, ByVal TestType As String) As IBaseListPanel

        Dim SelectTestsForBatchForm As Object
        SelectTestsForBatchForm = ClassLoader.LoadClass("TestListPanel")
        If SelectTestsForBatchForm Is Nothing Then
            Return Nothing
        End If
        ReflectionHelper.SetProperty(SelectTestsForBatchForm, "FormID", "L15")

        Dim gridView As DevExpress.XtraGrid.Views.Grid.GridView = CType(SelectTestsForBatchForm, IBaseListPanel).Grid.GridView
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In gridView.Columns
            col.Visible = False
        Next
        gridView.Columns("strBarcode").Visible = True
        gridView.Columns("DiagnosisName").Visible = True
        gridView.Columns("SpecimenType").Visible = True
        gridView.Columns("TestType").Visible = True
        gridView.Columns("CaseID").Visible = True
        gridView.Columns("HumanName").Visible = True
        gridView.Columns("strFieldBarcode").Visible = True

        Dim filter As New FilterParams
        filter.Add("idfsTestType", "=", TestType)
        filter.Add("idfsTestStatus", "=", CInt(BatchStatusEnum.Undefined))
        filter.Add("BatchTestIsNull", "", Nothing)
        'Dim Filter As String = _
        '            String.Format(" idfsTestType={0} " + _
        '                          " and idfBatchTest is null and idfsTestStatus = 10001005", TestType, BatchID.ToString()) '10001005 = Undefined
        ReflectionHelper.SetProperty(SelectTestsForBatchForm, "StaticFilter", filter)
        ReflectionHelper.SetProperty(SelectTestsForBatchForm, "SearchPanelVisible", False)
        Return CType(SelectTestsForBatchForm, IBaseListPanel)

    End Function


    Private Sub btDelTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDelTest.Click
        Me.TestsView.DeleteSelectedRows()
        ReMakeOrderNumbers()
        ReflectStatus()
    End Sub

    Private m_ClosedInCurrentSession As Boolean
    Private Sub btCloseBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCloseBatch.Click

        If (ValidateData() = False) Then
            m_PromptResult = DialogResult.Cancel

        Else
            If Me.TestsView.RowCount = 0 Then Return
            ' 1 check all tests
            If (ValidateTestsStatus() = False) Then Return
            If (ValidateBatch() = False) Then Return

            If (AskConfirmation() = False) Then Return
            baseDataSet.Tables(Batches_DB.TableBatchDetail).Rows(0)("idfsBatchStatus") = CLng(BatchStatusEnum.Completed)
            Completed = True
            m_ClosedInCurrentSession = True
            HideEditButtons()
        End If

    End Sub

    Function ValidateBatch() As Boolean
        Dim maxAccessionDate As DateTime? = _
         (From test In Me.baseDataSet.Tables(Batches_DB.TestsList) Where test.RowState <> DataRowState.Deleted AndAlso test.RowState <> DataRowState.Detached AndAlso Not (test.Field(Of Nullable(Of DateTime))("datAccession") Is Nothing)
            Select test.Field(Of DateTime?)("datAccession")).Min

        If maxAccessionDate Is Nothing Then
            bv.common.win.ErrorForm.ShowMessage("errBatchEmptyAccessionDate", "Some tests in batch are related with samples that was not accessioned.")
            Return False

        End If
        Return True
    End Function
    Private Function ValidateMandatoryField(ByVal ctl As Control, ByVal fieldName As String) As Boolean
        If Utils.IsEmpty(baseDataSet.Tables(Batches_DB.TableBatchDetail).Rows(0)(fieldName)) Then
            MyBase.ShowErrorAtValidateMandatoryFields(ctl)
            Return False
        End If
        Return True
    End Function


    Function ValidateTestsStatus() As Boolean
        ' 1 check all tests
        Dim TestsOfBatch As DataTable = baseDataSet.Tables(Batches_DB.TestsList)
        For Each dr As DataRow In TestsOfBatch.Rows
            If (dr.RowState = DataRowState.Deleted) Then Continue For
            If (IsDBNull(dr("idfsTestResult"))) Then
                MessageForm.Show(EidssMessages.Get("msgTestsNotHaveResults", "Not all tests have result."))
                Return False
            End If
        Next
        Return True
    End Function

    Function AskConfirmation() As Boolean
        Dim question As String = EidssMessages.Get("msgBatch_CloseBatch", "Do you want to finalize batch?")
        Dim caption As String = EidssMessages.Get("mbConfirmation", "Confirmation")

        Dim result As DialogResult = MessageForm.Show(question, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        Return (result = DialogResult.Yes)

    End Function

    Sub HideEditButtons()
        If Not Completed Then Return
        Me.btCloseBatch.Enabled = False
        Me.TestsView.OptionsBehavior.ReadOnly = True
        Me.TestsView.OptionsBehavior.Editable = False
        btnAddTestByBarcode.Enabled = False
        txtScannedBarcode.Enabled = False
        btnAddGroupResult.Enabled = False
        btAddTests.Enabled = False
        btDelTest.Enabled = False
        Me.FFTestDetails.ReadOnly = True
        Me.FFBatchDetails.ReadOnly = True

        For Each ctrl As Control In Controls
            If ctrl.Top <= Me.gridTests.Top And ctrl.Right <= Me.gridTests.Right Then
                If TypeOf (ctrl) Is DevExpress.XtraEditors.BaseControl Then
                    If (ctrl Is cbValidatedBy OrElse ctrl Is cbTestedBy OrElse ctrl Is dtDateTested OrElse ctrl Is dtDateValidated) Then
                        If m_ClosedInCurrentSession Then
                            ApplyControlState(CType(ctrl, DevExpress.XtraEditors.BaseControl), ControlState.Mandatory)
                            Continue For
                        End If
                    End If
                    Me.ApplyControlState(CType(ctrl, DevExpress.XtraEditors.BaseControl), ControlState.ReadOnly)
                End If
            End If
        Next
    End Sub


#Region "Reorder Tests"

    Private Sub btUP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btUP.Click
        MoveSelected(-1)
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        MoveSelected(1)
    End Sub


    Sub MoveSelected(ByVal Direction As Integer)
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(Me.gridTests.DefaultView, DevExpress.XtraGrid.Views.Grid.GridView)

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
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(Me.gridTests.DefaultView, DevExpress.XtraGrid.Views.Grid.GridView)

        'Dim ht As New Hashtable
        Dim orders As New System.Collections.Generic.Dictionary(Of Object, Integer)

        For i As Integer = 0 To view.RowCount - 1
            'Dim dr As DataRowView = 
            'Dim strNum As String = String.Format("{0:000}", i)
            orders(view.GetDataRow(i)("idfTesting")) = i
        Next

        Dim dtData As DataTable = baseDataSet.Tables(Batches_DB.TestsList)
        For i As Integer = 0 To dtData.Rows.Count - 1
            Dim row As DataRow = dtData.Rows(i)
            If row.RowState = DataRowState.Deleted Then Continue For
            'Dim NumPos As String = ht(row("idfTesting")).ToString()
            Dim order As Integer = orders(row("idfTesting"))
            If Utils.Str(order) <> Utils.Str(row("intTestNumber")) Then
                row("intTestNumber") = order
            End If
        Next

        'For i As Integer = 0 To dtData.Rows.Count - 1
        '    Dim NumPos As String = ht(dtData.Rows(i)("idfActivity")).ToString()
        '    dtData.Rows(i)("strTestNumber") = NumPos
        'Next

    End Sub

#End Region



    Private Sub GridView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestsView.DoubleClick

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
        Dim filled As Boolean = Me.TestsView.RowCount > 0
        cbTestType.Properties.ReadOnly = filled
        For Each btn As DevExpress.XtraEditors.Controls.EditorButton In cbTestType.Properties.Buttons
            btn.Enabled = Not filled
        Next
        gbTestDetails.Visible = filled
        Me.btCloseBatch.Enabled = filled AndAlso Not Completed
    End Sub

    Private Sub TestTypeChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        ShowBatchFF()
    End Sub
    Private Sub DiagnosisChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)

        Dim testCategory As Object = DBNull.Value
        If Not Utils.IsEmpty(e.Value) Then
            testCategory = LabTest_DB.GetDefaultTestCategory(CLng(e.Value), CLng(e.Row("idfsTestType")))
        End If
        e.Row("idfsTestForDiseaseType") = testCategory
    End Sub
    Private Sub TestResultChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        If Utils.IsEmpty(e.Value) Then
            e.Row("idfResultEnteredByPerson") = DBNull.Value
        Else
            e.Row("idfResultEnteredByPerson") = EIDSS.model.Core.EidssUserContext.User.EmployeeID
        End If
        e.Row.EndEdit()
    End Sub
    Private Sub ShowBatchFF()
        Dim row As DataRow = Me.baseDataSet.Tables(Batches_DB.TableBatchDetail).Rows(0)
        Dim type As Object = row("idfsTestType")
        LabUtils.ShowFF(Me.FFBatchDetails, type, row, FFType.TestRun)
        If Not (Me.cbTestResult.DataSource Is Nothing) Then
            If (Utils.IsEmpty(type)) Then type = "-1"
            CType(Me.cbTestResult.DataSource, DataView).RowFilter = String.Format("idfsTestType = {0} and intRowStatus = 0", type)
        End If
    End Sub

    Private Sub ShowTestFF()
        If (Me.baseDataSet.Tables(Batches_DB.TableBatchDetail).Rows.Count > 0) Then
            Dim row As DataRow = Me.baseDataSet.Tables(Batches_DB.TableBatchDetail).Rows(0)
            Dim type As Object = row("idfsTestType")
            LabUtils.ShowFF(Me.FFTestDetails, type, TestsView.GetDataRow(TestsView.FocusedRowHandle), FFType.TestDetails)
        End If
    End Sub

    Private Sub btnSampleSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSampleSearch.Click

        If Me.gridTests.DataSource Is Nothing Then Exit Sub

        Dim viewMain As DataView

        If TypeOf gridTests.DataSource Is DataTable Then
            Dim dt As DataTable = CType(Me.gridTests.DataSource, DataTable)
            viewMain = dt.AsDataView
        ElseIf TypeOf gridTests.DataSource Is DataView Then

            Dim view As DataView = CType(Me.gridTests.DataSource, DataView)
            viewMain = view
        Else
            Exit Sub
        End If


        If Not (viewMain.Table.Rows.Count = 0) Then
            viewMain.Sort = "strBarcode"

            Dim dataRow As Integer = viewMain.Find(txtSamplesSearchAdvanced.Text())


            If (dataRow >= 0) Then

                Dim view2 As DevExpress.XtraGrid.Views.Grid.GridView = CType(Me.gridTests.Views(0), DevExpress.XtraGrid.Views.Grid.GridView)
                Dim d As DataRow = viewMain(dataRow).Row
                DxControlsHelper.SetRowHandleForDataRow(view2, d, "idfTesting")

                view2.ClearSelection()

                view2.SelectRow(view2.FocusedRowHandle)

            Else
                viewMain.Sort = "intTestNumber,idfTesting"

                MessageForm.Show(EidssMessages.Get("ErrFieldSampleIDNotFound", "Sample is not found."))
            End If
        End If

    End Sub

#Region "REPORTS"

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        If baseDataSet Is Nothing OrElse baseDataSet.Tables.Count = 0 Then
            Return
        End If

        Dim drBatchDetail As DataRow = baseDataSet.Tables(Batches_DB.TableBatchDetail).Rows(0)
        If Post(PostType.FinalPosting) Then
            Dim id As Long = CType(DbService.ID, Long)
            Dim typeID As Long = CType(drBatchDetail("idfsTestType"), Long)
            EidssSiteContext.ReportFactory.LimBatchTest(id, typeID)
        End If
    End Sub

#End Region
    Protected Overrides Sub AfterLoad()
        MyBase.AfterLoad()
        Me.ShowBatchFF()
        Me.ShowTestFF()
    End Sub
    Protected Sub AfterPost(ByVal sender As Object, ByVal e As EventArgs)
        m_ClosedInCurrentSession = False
        HideEditButtons()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub btnAddGroupResult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddGroupResult.Click
        Dim form As New BatchSelectTestResult


        Dim startupParams As New Dictionary(Of String, Object)
        startupParams.Add("idfsTestType", baseDataSet.Tables(Batches_DB.TableBatchDetail).Rows(0)("idfsTestType"))

        Dim id As Object = Nothing
        CType(form, IApplicationForm).StartUpParameters = startupParams
        If BaseFormManager.ShowModal(CType(form, IApplicationForm), FindForm, id, Nothing, startupParams, Nothing, Nothing) Then
            Dim result As Object = form.LookUpTestResult.EditValue
            Dim selectedRows As Integer() = TestsView.GetSelectedRows()
            For Each row As DataRow In From i In selectedRows Select TestsView.GetDataRow(i)
                row("idfsTestResult") = result
                row("idfResultEnteredByPerson") = model.Core.EidssUserContext.User.EmployeeID
            Next
        End If
    End Sub
    Private m_SampleDiagnosis As New Dictionary(Of Long, String)
    Private Sub SearchByBarcode(ByVal barcode As String)
        If (CheckBatchType() = False) Then Return

        Dim batchRow As DataRow = Me.baseDataSet.Tables(Batches_DB.TableBatchDetail).Rows(0)
        Dim ds As DataSet = BatcheDbService.SelectTestsBySampleID(CLng(batchRow("idfsTestType")), barcode)
        If ds.Tables(Batches_DB.TestsList).Rows.Count > 0 Then
            Dim sourceRow As DataRow = ds.Tables(Batches_DB.TestsList).Rows(0)
            Dim rows As DataRow()
            If CLng(sourceRow("idfTesting")) = -1 Then
                Dim testRow As DataRow = ds.Tables(Batches_DB.TestsList).Rows(0)
                testRow("idfTesting") = BaseDbService.NewIntID()
                testRow("idfContainer") = sourceRow("idfContainer")
                testRow("idfsTestType") = sourceRow("idfsTestType")
                testRow("idfsTestForDiseaseType") = DBNull.Value
                testRow("idfsDiagnosis") = ds.Tables("DefaultDiagnosis").Rows(0)("idfsDiagnosis")
                testRow("idfObservation") = 0
                rows = New DataRow() {testRow}

                Dim diagnosisList As String = ""
                For Each row As DataRow In ds.Tables("Diagnosis").Rows
                    If diagnosisList = "" Then
                        diagnosisList = Utils.Str(row("idfsDiagnosis"), "0")
                    Else
                        diagnosisList += "," + Utils.Str(row("idfsDiagnosis"), "0")
                    End If
                Next
                If m_SampleDiagnosis.ContainsKey(CLng(sourceRow("idfContainer"))) Then
                    m_SampleDiagnosis(CLng(sourceRow("idfContainer"))) = diagnosisList
                Else
                    m_SampleDiagnosis.Add(CLng(sourceRow("idfContainer")), diagnosisList)
                End If
            Else
                rows = ds.Tables(Batches_DB.TestsList).Select("")
            End If
            AddTestsToBatchInMem(rows)

            Me.gridTests.Refresh()
            ReMakeOrderNumbers()
            ReflectStatus()
        Else
            MessageForm.Show(EidssMessages.Get("ErrFieldSampleIDNotFound", "Sample is not found."))
        End If
        Application.DoEvents()
        txtScannedBarcode.Focus()

    End Sub

    Private Sub btnAddTestByBarcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddTestByBarcode.Click

        SearchByBarcode(txtScannedBarcode.Text)

    End Sub

    Private Sub txtScannedBarcode_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScannedBarcode.EditValueChanged
        If txtScannedBarcode.Text.Contains("\n") Then
            SearchByBarcode(txtScannedBarcode.Text.Replace("\n", ""))
        End If
    End Sub

    Private Sub txtScannedBarcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtScannedBarcode.KeyDown
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
        If (Utils.IsEmpty(row("idfContainer")) OrElse CLng(row("idfContainer")) <= 0) Then
            'Show editor for diagnosis and category if they are empty
            If (TestsView.FocusedColumn Is colDiagnosis AndAlso Utils.IsEmpty(row("idfsDiagnosis"))) Then
                Return
            End If
            If (TestsView.FocusedColumn Is colCategory AndAlso Utils.IsEmpty(row("idfsTestForDiseaseType"))) Then
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
            If (IsDBNull(dr("idfsTestForDiseaseType"))) Then
                MessageForm.Show(EidssMessages.Get("msgTestsNotHaveCategory", "Not all tests have category."))
                Return False
            End If
        Next
        If (Completed) Then
            Dim maxAccessionDate As DateTime? = _
             (From test In Me.baseDataSet.Tables(Batches_DB.TestsList) Where test.RowState <> DataRowState.Deleted AndAlso test.RowState <> DataRowState.Detached AndAlso Not (test.Field(Of Nullable(Of DateTime))("datAccession") Is Nothing)
                Select test.Field(Of DateTime?)("datAccession")).Min

            Dim BatchTable As DataTable = baseDataSet.Tables(Batches_DB.TableBatchDetail)

            Dim datConcludedDate As DateTime = CType(BatchTable.Rows(0).Item("datValidatedDate"), DateTime)
            Dim datStartedDate As DateTime = CType(BatchTable.Rows(0).Item("datPerformedDate"), DateTime)

            If datConcludedDate < datStartedDate Then
                bv.common.win.ErrorForm.ShowMessageDirect(EidssMessages.Get("datBatchStartDate_ConcludedDate_msgId"))
                Return False
            End If

            If datStartedDate < (maxAccessionDate.Value.Date) Then
                bv.common.win.ErrorForm.ShowMessageDirect(EidssMessages.Get("datAccessionDate_BatchStartDate_msgId"))
                Return False
            End If

        End If
        Return True
    End Function

    Private Sub cbDiagnosis_QueryCloseUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbDiagnosis.QueryCloseUp
        CType(cbDiagnosis.DataSource, DataView).RowFilter = ""
    End Sub

    Private Sub cbDiagnosis_QueryPopUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbDiagnosis.QueryPopUp
        Dim row As DataRow = TestsView.GetFocusedDataRow
        If (Utils.IsEmpty(row("idfContainer")) OrElse CLng(row("idfContainer")) > 0) Then
            CType(cbDiagnosis.DataSource, DataView).RowFilter = String.Format("idfsDiagnosis in ({0})", m_SampleDiagnosis(CLng(row("idfContainer"))))
        End If
    End Sub
    Public Overrides Sub UpdateButtonsState(ByVal sender As Object, ByVal e As System.EventArgs)
        btnAddGroupResult.Enabled = Not Completed AndAlso TestsView.SelectedRowsCount > 0
        btDelTest.Enabled = Not Completed AndAlso TestsView.SelectedRowsCount > 0
        btnSampleSearch.Enabled = Not Utils.IsEmpty(txtSamplesSearchAdvanced.Text)
        btnAddTestByBarcode.Enabled = Not Completed AndAlso Not Utils.IsEmpty(txtScannedBarcode.Text)
    End Sub



End Class

