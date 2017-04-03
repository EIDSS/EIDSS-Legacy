Imports System.ComponentModel
Imports bv.winclient.Core
Imports EIDSS.model.Resources
Imports bv.common.Resources
Imports bv.winclient.Localization

Public Class PensideTestPanel
    Protected Overrides Sub DefineBinding()
        If IsDesignMode() Then Return
        Core.LookupBinder.BindStandardRepositoryLookup(cbTestResult, LookupTables.PensideTestResult, False)
        Core.LookupBinder.RemoveDefaultFilterHandlers(cbTestResult)
        Core.LookupBinder.BindBaseRepositoryLookup(cbTestType, BaseReferenceType.rftPensideTestType, HACode, False)
        'Core.LookupBinder.BindBaseRepositoryLookup(Me.cbSpecies, BaseReferenceType.rftSpeciesList, HACode)
        If Not baseDataSet Is Nothing AndAlso baseDataSet.Tables.Count <> 0 Then
            TestGrid.DataSource = baseDataSet.Tables(PensideTests_Db.TableTests)
        End If
        cbSampleBarcode.Columns(0).Caption = EidssMessages.Get("lblSpecimenType")
        cbSampleBarcode.Columns(1).Caption = EidssMessages.Get("lblFieldSampleID")
        If [ReadOnly] Then
            cmdDeleteTest.Enabled = False
            cmdNew.Enabled = False
            TestGridView.OptionsBehavior.Editable = False
        End If

    End Sub
    Dim m_ShowPopupImmediatly As Boolean
    Private Sub cmdNewTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNew.Click
        If Not IsTestRowValid(TestGridView.FocusedRowHandle) Then
            Return
        End If
        Dim row As DataRow = PensideTestsDbService.CreateTest(baseDataSet)
        DxControlsHelper.SetRowHandleForDataRow(TestGridView, row, "idfPensideTest")
        TestGridView.FocusedColumn = colTestName
        m_ShowPopupImmediatly = True
        TestGrid.Select()
        Application.DoEvents()
        TestGridView.ShowEditor()
    End Sub
    Private Sub cmdDeleteTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteTest.Click
        Dim testRow As DataRow = TestGridView.GetDataRow(TestGridView.FocusedRowHandle)
        If testRow Is Nothing Then Return
        If WinUtils.ConfirmDelete Then
            PensideTestsDbService.DeleteTest(baseDataSet, testRow("idfPensideTest"))
        End If
    End Sub
    Public WriteOnly Property SamplesView() As DataView
        Set(ByVal value As DataView)
            cbSampleBarcode.DataSource = value
        End Set
    End Property
    Private Sub TestGridView_CellValueChanging(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles TestGridView.CellValueChanging
        If Me.Created = False Then
            Return
        End If
        If e.Column Is colSampleBarcode Then
            RefreshSample(e.Value)
        End If

    End Sub

    Private Sub BeforeAcceptChanges(ByVal sender As Object, ByVal e As EventArgs)
        'For i As Integer = 0 To baseDataSet.Tables(PensideTests_Db.TableTests).Rows.Count - 1
        '    Dim testRow As DataRow = baseDataSet.Tables(PensideTests_Db.TableTests).Rows(i)
        '    Dim view As DataView = CType(cbSampleBarcode.DataSource, DataView)
        '    If view Is Nothing Then Return
        '    Dim lookupRow As DataRow = Nothing
        '    If Not Utils.IsEmpty(testRow("idfMaterial")) Then
        '        lookupRow = view.Table.Rows.Find(testRow("idfMaterial"))
        '    End If
        '    If Not lookupRow Is Nothing AndAlso Utils.Str(testRow("AnimalID")) <> Utils.Str(lookupRow("AnimalID")) Then
        '        testRow("idfAnimal") = lookupRow("AnimalID")
        '        testRow.EndEdit()
        '    End If
        'Next
    End Sub


    Private Function GetCurrentTestRow() As DataRow
        If TestGridView.RowCount = 0 Then Return Nothing
        Return TestGridView.GetDataRow(TestGridView.FocusedRowHandle)
    End Function

    Private Sub cbTestResult_CloseUp(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.CloseUpEventArgs) Handles cbTestResult.CloseUp
        CType(cbTestResult.DataSource, DataView).RowFilter = ""
    End Sub
    Private Sub cbTestResult_QueryPopUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbTestResult.QueryPopUp
        Dim view As DataView = CType(cbTestResult.DataSource, DataView)
        'try to display results for current test type
        Dim testType As Object = TestGridView.GetFocusedRowCellValue(colTestName)
        If Not testType Is DBNull.Value Then
            view.RowFilter = String.Format("(idfsPensideTestType = {0} and intRowStatus = 0) or idfRowNumber = {1}", testType, LookupCache.EmptyLineKey)
        Else
            view.RowFilter = String.Format("(idfsPensideTestType = 0 and intRowStatus = 0) or idfRowNumber = {0}", LookupCache.EmptyLineKey) 'display all test results
        End If
        If view.Count = 0 Then
            view.RowFilter = String.Format("(idfsPensideTestType = 0 and intRowStatus = 0) or idfRowNumber = {0}", LookupCache.EmptyLineKey) 'display all test results
        End If
    End Sub
    Public Overrides Function ValidateData() As Boolean
        For i As Integer = 0 To TestGridView.RowCount - 1
            If IsTestRowValid(i, True) = False Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Function IsTestRowValid(Optional ByVal index As Integer = -1, Optional ByVal showError As Boolean = True) As Boolean
        If index = -1 Then index = TestGridView.FocusedRowHandle
        If index < 0 Then Return True
        Dim row As DataRow = TestGridView.GetDataRow(index)

        If row Is Nothing Then Return True
        Dim msg As String = ""
        If row("idfsPensideTestType") Is DBNull.Value Then
            If showError Then
                msg += String.Format(BvMessages.Get("ErrMandatoryFieldRequired", "The field {0} is mandatory. You must enter data to this field before form saving"), TestGridView.Columns("idfsPensideTestType").Caption) + vbCrLf
                ErrorForm.ShowWarningDirect(msg)
            End If
            Return False
        End If
        If row("idfMaterial") Is DBNull.Value Then
            If showError Then
                msg += String.Format(BvMessages.Get("ErrMandatoryFieldRequired", "The field {0} is mandatory. You must enter data to this field before form saving"), TestGridView.Columns("idfMaterial").Caption) + vbCrLf
                ErrorForm.ShowWarningDirect(msg)
            End If
            Return False
        End If
        Return True
    End Function
    Dim m_Updating As Boolean
    Private Sub TestGridView_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles TestGridView.FocusedRowChanged
        If Loading OrElse m_Updating Then Return
        m_Updating = True
        Try
            If e.PrevFocusedRowHandle >= 0 AndAlso IsTestRowValid(e.PrevFocusedRowHandle) = False Then
                TestGridView.FocusedRowHandle = e.PrevFocusedRowHandle
                Return
            End If
        Finally
            m_Updating = False
        End Try
    End Sub
    Private m_HACode As HACode = HACode.Livestock

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property HACode() As HACode
        Get
            Return m_HACode
        End Get
        Set(ByVal Value As HACode)
            m_HACode = Value
            PensideTestsDbService.HACode = Value
            If (m_HACode And EIDSS.HACode.Livestock) <> 0 Then
                Me.colAnimalID.Visible = True
                Me.colSpecies.Visible = False
            Else
                Me.colAnimalID.Visible = False
                Me.colSpecies.Visible = True
            End If
        End Set
    End Property
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property PartyList() As Object
        Get
            If (HACode And HACode.Livestock) <> 0 Then
                Return cbAnimal.DataSource
            ElseIf (HACode And HACode.Avian) <> 0 Then
                Return cbSpecies.DataSource
            End If
            Return Nothing
        End Get
        Set(ByVal Value As Object)
            If (HACode And HACode.Livestock) <> 0 Then
                cbAnimal.DataSource = Value
            ElseIf (HACode And HACode.Avian) <> 0 Then
                cbSpecies.DataSource = Value
            End If
        End Set
    End Property
    Public Function CanDeleteSample(ByVal sampleID As Object) As Boolean
        If Utils.IsEmpty(sampleID) Then Return False
        For Each row As DataRow In baseDataSet.Tables(PensideTests_Db.TableTests).Rows
            If row.RowState <> DataRowState.Deleted Then
                If row("idfMaterial").Equals(sampleID) Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Public Function CanDeleteParty(ByVal partyID As Object) As Boolean
        If Utils.IsEmpty(partyID) Then Return False
        For Each row As DataRow In baseDataSet.Tables(PensideTests_Db.TableTests).Rows
            If row.RowState <> DataRowState.Deleted Then
                If row("idfParty").Equals(partyID) Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function
    Public Function CanDeleteFarmTreeNode(ByVal row As DataRow) As Boolean
        Dim dtype As PartyType = CType(row("idfsPartyType"), PartyType)
        Select Case dtype
            Case PartyType.Farm
                Return False
            Case PartyType.Herd
                Dim speciesView As DataView = New DataView(row.Table)
                speciesView.RowFilter = String.Format("idfParentParty = {0}", row("idfParty").ToString)
                For Each speciesRow As DataRowView In speciesView
                    If Not CanDeleteFarmTreeNode(speciesRow.Row) Then
                        Return False
                    End If
                Next
            Case PartyType.Species
                Return CanDeleteParty(row("idfParty"))
        End Select
        Return True
    End Function
    ''' <summary>
    ''' This method is called if we select new sample for the test  
    ''' and we should update displayed sample information for current test row
    ''' </summary>
    ''' <param name="newSampleID"></param>
    ''' <remarks></remarks>
    Public Sub RefreshSample(ByVal newSampleID As Object)
        Dim view As DataView = CType(cbSampleBarcode.DataSource, DataView)
        If view Is Nothing Then Return
        Dim lookupRow As DataRow = Nothing
        If Not Utils.IsEmpty(newSampleID) Then
            lookupRow = view.Table.Rows.Find(newSampleID)
        End If
        Dim testRow As DataRow = GetCurrentTestRow()
        If Not testRow Is Nothing Then
            UpdateSampleInfo(testRow, lookupRow)
            Return
        End If
    End Sub

    ''' <summary>
    ''' This method is called when we change sample type in the samples panel
    ''' and we should update all tests related with modified sample
    ''' </summary>
    ''' <param name="oldSampleID">
    ''' the original sample ID. We should update all tests, related with this sample
    ''' </param>
    ''' <param name="newSampleID">
    ''' new sample ID, we should update test rows with this sample info
    ''' </param>
    ''' <remarks></remarks>
    Public Sub RefreshTests(ByVal oldSampleID As Object, ByVal newSampleID As Object)
        If Utils.IsEmpty(oldSampleID) Then ' new sample is created, do nothing
            Return
        End If
        Dim view As DataView = CType(cbSampleBarcode.DataSource, DataView)
        If view Is Nothing Then Return
        Dim lookupRow As DataRow = Nothing
        If Not Utils.IsEmpty(newSampleID) Then
            lookupRow = view.Table.Rows.Find(newSampleID)
        End If
        For Each testRow As DataRow In baseDataSet.Tables(PensideTests_Db.TableTests).Rows
            If testRow("idfMaterial").Equals(oldSampleID) Then
                UpdateSampleInfo(testRow, lookupRow)
            End If
        Next
    End Sub

    Private Sub UpdateSampleInfo(ByVal testRow As DataRow, ByVal sampleRow As DataRow)
        If Not sampleRow Is Nothing Then
            testRow("strSpecimenName") = Utils.Str(sampleRow("strSpecimenName"))
            testRow("idfMaterial") = sampleRow("idfMaterial")
            testRow("idfParty") = sampleRow("idfParty")
        Else
            testRow("strSpecimenName") = DBNull.Value
            testRow("idfMaterial") = DBNull.Value
            testRow("idfParty") = DBNull.Value
        End If
        testRow.EndEdit()

    End Sub

End Class
