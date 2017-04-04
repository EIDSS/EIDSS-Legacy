Imports EIDSS.model.Core
Imports DevExpress.XtraEditors.Controls
Imports EIDSS.Core
Imports bv.winclient.BasePanel
Imports bv.model.Model.Core
Imports DevExpress.XtraEditors
Imports bv.winclient.Core
Imports System.ComponentModel
Imports System.Collections.Generic
Imports DevExpress.XtraGrid.Columns
Imports EIDSS.model.Resources
Imports EIDSS.model.Enums
Imports EIDSS.model.Schema
Imports bv.common.Resources
Imports DevExpress.XtraGrid.Views.Grid
Imports bv.common.win.Validators
Imports bv.common.Enums
Imports bv.winclient.Localization

Namespace ActiveSurveillance
    Public Class AsSessionSummaryPanel
        Private AsSessionSummaryService As AsSummary_DB
        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            AsSessionSummaryService = New AsSummary_DB
            DbService = AsSessionSummaryService
            btnPasteDiagnosis.Enabled = False
            btnPasteSamples.Enabled = False
        End Sub
        Private Sub SetFarmPermissions()
            For Each btn As EditorButton In txtFarmCode.Buttons
                If (btn.Kind = ButtonPredefines.Ellipsis) Then 'AndAlso EidssUserContext.User.HasPermission(PermissionHelper.UpdatePermission(EIDSSPermissionObject.AccessToFarmData))
                    btn.Visible = (AsSummaryView.FocusedRowHandle >= 0) _
                                    OrElse (AsSummaryView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission(EIDSSPermissionObject.AccessToFarmData)))
                ElseIf (btn.Kind = ButtonPredefines.Glyph) Then
                    btn.Visible = EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.AccessToFarmData))
                End If
            Next
        End Sub
        Protected Overrides Sub DefineBinding()
            AsSummaryGrid.DataSource = baseDataSet.Tables(AsSummary_DB.TableAsSummary)
            LookupBinder.BindBaseRepositoryLookup(cbSex, db.BaseReferenceType.rftAnimalSex, HACode.Livestock, False)
            LookupBinder.BindBaseRepositoryLookup(cbSpecies, db.BaseReferenceType.rftSpeciesList, False)
            cbSpecies.ValueMember = "idfSpecies"
            cbSpecies.DisplayMember = "strSpeciesName"
            cbSpecies.DataSource = SpeciesList
            eventManager.AttachDataHandler(AsSummary_DB.TableAsSummary + ".intSampledAnimalsQty", AddressOf UpdateTotals)
            eventManager.AttachDataHandler(AsSummary_DB.TableAsSummary + ".intSamplesQty", AddressOf UpdateTotals)
            eventManager.AttachDataHandler(AsSummary_DB.TableAsSummary + ".intPositiveAnimalsQty", AddressOf PositiveAnimalsQtyChanged)
            eventManager.AttachDataHandler(AsSummary_DB.TableAsSummary + ".idfSpecies", AddressOf SpeciesChanged)
            eventManager.Cascade(AsSummary_DB.TableAsSummary + ".intSampledAnimalsQty")

            AddHandler baseDataSet.Tables(AsSummary_DB.TableAsSummary).TableNewRow, AddressOf RowAdded
            AddHandler baseDataSet.Tables(AsSummary_DB.TableAsSummary).RowDeleted, AddressOf RowDeleted
            AddHandler baseDataSet.Tables(AsSummary_DB.TableAsSummary).RowChanged, AddressOf RowDeleted
            SetFarmPermissions()
        End Sub

        Private Sub PositiveAnimalsQtyChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
            If (Utils.IsEmpty(e.Value) OrElse CInt(e.Value) <= 0) Then
                Dim rows As DataRow() = baseDataSet.Tables(AsSummary_DB.TableAsSummaryDiagnosis).Select(String.Format(String.Format("idfMonitoringSessionSummary ={0} ", e.Row("idfMonitoringSessionSummary"))))
                For Each row As DataRow In rows
                    If True.Equals(row("blnChecked")) Then
                        row("blnChecked") = False
                    End If
                Next
                MarkCheckListBoxes(Me, DiagnosisList)
            ElseIf CInt(e.Value) > 0 Then
                Dim diagnosis As Object = AsSession.GetDefaultDiagnosis()
                If Not Utils.IsEmpty(diagnosis) Then
                    Dim rows() As DataRow = baseDataSet.Tables(AsSummary_DB.TableAsSummaryDiagnosis).Select(String.Format("idfsDiagnosis = {0} and idfMonitoringSessionSummary = {1} ", diagnosis, e.Row("idfMonitoringSessionSummary")))
                    If rows.Length = 0 Then
                        AsSessionSummaryService.GetDiagnosis(baseDataSet, e.Row, AsSession.baseDataSet.Tables(ASSession_DB.TableDiagnosis).DefaultView)
                        rows = baseDataSet.Tables(AsSummary_DB.TableAsSummaryDiagnosis).Select(String.Format("idfsDiagnosis = {0} and idfMonitoringSessionSummary = {1} ", diagnosis, e.Row("idfMonitoringSessionSummary")))
                    End If
                    If rows.Length = 1 AndAlso Not True.Equals(rows(0)("blnChecked")) Then
                        rows(0)("blnChecked") = True
                        MarkCheckListBoxes(Me, DiagnosisList)
                        Dim focusedCol As GridColumn = AsSummaryView.FocusedColumn
                        InvalidateColumnAsync(colDiagnosis)
                        AsSummaryView.FocusedColumn = focusedCol
                    End If
                End If
            End If
            UpdateTotals()
        End Sub

        Private Sub SpeciesChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
            SetSummarySpeciesType(e.Row, e.Value)
        End Sub

        Private Sub SetSummarySpeciesType(ByVal summaryRow As DataRow, ByVal idfSpecies As Object)
            If Not Utils.IsEmpty(idfSpecies) Then
                Dim row As DataRow = SpeciesList.Table.Rows.Find(idfSpecies)
                If Not row Is Nothing Then
                    summaryRow("idfsSpeciesType") = row("idfsReference")
                    summaryRow("strSpecies") = row("name")
                    Dim sampleType As Object = AsSession.GetDefaultSample(summaryRow("idfsSpeciesType"))
                    If Not Utils.IsEmpty(sampleType) Then
                        Dim view As DataView = AsSessionSummaryService.GetSamples(baseDataSet, summaryRow("idfMonitoringSessionSummary"))
                        view.RowFilter = String.Format("idfsSampleType = {0} and idfMonitoringSessionSummary = {1}", sampleType, summaryRow("idfMonitoringSessionSummary"))
                        If (view.Count = 1) Then
                            view(0)("blnChecked") = True
                            summaryRow("strSamples") = view(0)("name")
                            InvalidateColumn(colSpecies)
                        End If
                    End If
                    Return
                End If

            End If
            summaryRow("idfsSpeciesType") = DBNull.Value
            summaryRow("strSpecies") = DBNull.Value

        End Sub

        Private Sub RowAdded(ByVal sender As Object, ByVal e As DataTableNewRowEventArgs)
            UpdateTotals()
        End Sub
        Private Sub RowDeleted(sender As Object, e As DataRowChangeEventArgs)
            UpdateTotals()
        End Sub

        Private Sub UpdateTotals()
            txtAnimalsQtyTotal.EditValue = baseDataSet.Tables(AsSummary_DB.TableAsSummary).Compute("sum(intSampledAnimalsQty)", Nothing)
            txtSamplesQtyTotal.EditValue = baseDataSet.Tables(AsSummary_DB.TableAsSummary).Compute("sum(intSamplesQty)", Nothing)
            txtPositiveQtyTotal.EditValue = baseDataSet.Tables(AsSummary_DB.TableAsSummary).Compute("sum(intPositiveAnimalsQty)", Nothing)
        End Sub
        Private Sub UpdateTotals(sender As Object, e As DataFieldChangeEventArgs)
            UpdateTotals()
        End Sub

        Private Sub txtFarmCode_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtFarmCode.ButtonClick
            Dim row As DataRow = AsSummaryView.GetDataRow(AsSummaryView.FocusedRowHandle)
            If (row Is Nothing) Then
                AsSummaryView.ShowEditor()
                If AsSummaryView.ActiveEditor IsNot Nothing Then
                    AsSummaryView.ActiveEditor.IsModified = True
                End If
                AsSummaryView.SetRowCellValue(AsSummaryView.FocusedRowHandle, AsSummaryView.Columns("strFarmCode"), "(new)")
                While (row Is Nothing)
                    Application.DoEvents()
                    row = AsSummaryView.GetDataRow(AsSummaryView.FocusedRowHandle)
                End While
                InvalidateColumn(colFarmID)
            End If
            Dim defaultSpeciesType As Object = AsSession.GetDefaultSpeciesType()
            Dim speciesTypeFilter As String = AsSession.GetSpeciesFilter()
            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then
                If row Is Nothing Then
                    Return
                End If
                'Dim IsNewFarm As Boolean = CBool(row("blnNewFarm"))
                Dim id As Object = row("idfFarm") ' IIf(IsNewFarm,row("idfFarmActual"), row("idfFarm")))
                Dim farmDetail As FarmDetail = AsSession.CreateFarmDetailForm()
                Dim startUpParam As Dictionary(Of String, Object) = AsSession.CreateStartupParameters
                If (Not defaultSpeciesType Is DBNull.Value) Then
                    startUpParam("DefaultSpeciesType") = defaultSpeciesType
                End If
                If (Not String.IsNullOrEmpty(speciesTypeFilter)) Then
                    startUpParam("SpeciesTypeFilter") = speciesTypeFilter
                End If
                If BaseFormManager.ShowModal(farmDetail, FindForm(), id, Nothing, startUpParam) Then
                    row("strFarmCode") = farmDetail.FarmPanel.baseDataSet.Tables(0).Rows(0)("strFarmCode")
                    row("idfFarmActual") = farmDetail.FarmPanel.baseDataSet.Tables(0).Rows(0)("idfRootFarm")
                    row("idfFarm") = id
                    row("blnNewFarm") = False
                    row.EndEdit()
                    InvalidateColumn(colFarmID)
                    ASSession_DB.PopulateFarmSpecies(SpeciesList.Table, id)
                    PopulateDefaultSpecies(row, defaultSpeciesType)
                End If
            ElseIf e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph Then
SelectFarm:
                Dim farmList As IBaseListPanel = AsSession.CreateFarmSelectionForm()
                Dim rootFarm As IObject = BaseFormManager.ShowForSelection(farmList, FindForm())
                If Not rootFarm Is Nothing Then
                    Dim id As Long = FindFarm(row("idfMonitoringSessionSummary"), Utils.Str(rootFarm.GetValue("strFarmCode")))
                    If id <= 0 Then
                        If (AsSession.ValidateAddress(CType(rootFarm, FarmListItem)) = False) Then
                            If (Not WinUtils.ConfirmMessage(EidssMessages.Get("msgAddressIsOutOfBoundaries"))) Then
                                GoTo SelectFarm
                            End If
                        End If
                        id = CLng(ASSession_DB.CreateRootFarmCopy(rootFarm.Key, DBNull.Value))
                        Dim farmDetail As FarmDetail = AsSession.CreateFarmDetailForm()
                        Dim startUpParam As New Dictionary(Of String, Object)
                        startUpParam("ShowHerdsTab") = True
                        If (Not defaultSpeciesType Is DBNull.Value) Then
                            startUpParam("DefaultSpeciesType") = defaultSpeciesType
                        End If
                        If (Not String.IsNullOrEmpty(speciesTypeFilter)) Then
                            startUpParam("SpeciesTypeFilter") = speciesTypeFilter
                        End If
                        If Not BaseFormManager.ShowModal(farmDetail, FindForm(), CType(id, Object), Nothing, startUpParam) Then
                            'if user clicked Cancel - we should delete just created farm
                            ASSession_DB.DeleteRootFarmCopy(id)
                            Return
                        End If
                    End If

                    row("idfFarm") = id
                    If True.Equals(row("blnNewFarm")) Then
                        row("blnNewFarm") = False
                    Else
                        defaultSpeciesType = DBNull.Value 'we shall populate default species/sample for new farms only
                    End If
                    row("idfFarmActual") = rootFarm.Key
                    row("strFarmCode") = Utils.Str(rootFarm.GetValue("strFarmCode"))
                    row.EndEdit()
                    InvalidateColumn(colFarmID)
                    ASSession_DB.PopulateFarmSpecies(SpeciesList.Table, id)
                    PopulateDefaultSpecies(row, defaultSpeciesType)
                End If
            End If

        End Sub
        Private Sub PopulateDefaultSpecies(row As DataRow, defaultSpeciesType As Object)
            If row("idfSpecies") Is DBNull.Value AndAlso Not Utils.IsEmpty(defaultSpeciesType) Then
                Dim rows As DataRow() = SpeciesList.Table.Select(String.Format("idfFarm = {0} and idfsReference = {1}", row("idfFarm"), defaultSpeciesType))
                If (rows.Length = 1) Then
                    row("idfSpecies") = rows(0)("idfSpecies")
                    row("idfsSpeciesType") = defaultSpeciesType
                    row("strSpecies") = rows(0)("name")
                    row.EndEdit()
                    SpeciesChanged(Nothing, New DataFieldChangeEventArgs(row, baseDataSet.Tables(AsSummary_DB.TableAsSummary).Columns("idfSpecies"), row("idfSpecies"), DBNull.Value))
                    InvalidateColumn(colSpecies)
                    InvalidateColumn(colSampleType)
                    InvalidateColumn(colSex)
                End If
            End If
        End Sub


        Public Function FindFarmByCode(recordId As Object, farmCode As String) As Long
            Dim filter As String
            If Utils.IsEmpty(recordId) Then
                filter = String.Format("strFarmCode = '{0}'", farmCode)
            Else
                filter = String.Format("strFarmCode = '{0}' and idfMonitoringSessionSummary <> {1}", farmCode, recordId)
            End If
            Dim rows As DataRow() = baseDataSet.Tables(AsSummary_DB.TableAsSummary).Select(filter)
            If rows.Length > 0 Then
                Return CLng(rows(0)("idfFarm"))
            End If
            Return 0
        End Function
        Function FindFarmById(recordId As Object, farmId As Long) As Long
            Dim filter As String
            If Utils.IsEmpty(recordId) Then
                filter = String.Format("idfFarm = '{0}'", farmId)
            Else
                filter = String.Format("idfFarm = '{0}' and idfMonitoringSessionSummary <> {1}", farmId, recordId)
            End If
            Dim rows As DataRow() = baseDataSet.Tables(AsSummary_DB.TableAsSummary).Select(filter)
            If rows.Length > 0 Then
                Return CLng(rows(0)("idfFarm"))
            End If
            Return 0
        End Function
        Private ReadOnly Property AsSession As AsSessionDetail
            Get
                Return CType(FindBaseForm(Me), AsSessionDetail)
            End Get
        End Property
        Private Function FindFarm(recordId As Object, farmCode As String) As Long
            Return AsSession.FindFarm(recordId, farmCode)
        End Function
        Private Function FindFarm(recordId As Object, farmId As Long) As Long
            Return AsSession.FindFarm(recordId, farmId)
        End Function

        Private Sub cbSamples_QueryCloseUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cbSamples.QueryCloseUp
            InvalidateColumnAsync(colSampleType)
        End Sub
        Private Sub cbSamples_QueryPopUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cbSamples.QueryPopUp
            Dim row As DataRow = AsSummaryView.GetFocusedDataRow()
            Dim view As DataView = AsSessionSummaryService.GetSamples(baseDataSet, row("idfMonitoringSessionSummary"))
            Dim filter As String = AsSession.GetSpeciesSamplesFilter(row("idfsSpeciesType"), False)
            If Not Utils.IsEmpty(filter) Then
                view.RowFilter = String.Format("idfMonitoringSessionSummary = {0} and (idfsSampleType in {1} or blnChecked = 1 )", row("idfMonitoringSessionSummary"), filter)
            End If
            SamplesList.DataSource = view
            MarkCheckListBoxes(Me, SamplesList)
        End Sub

        Private Sub cbDiagnosis_QueryCloseUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cbDiagnosis.QueryCloseUp
            InvalidateColumn(colDiagnosis)
        End Sub
        Private Sub cbDiagnosis_QueryPopUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cbDiagnosis.QueryPopUp
            Dim row As DataRow = AsSummaryView.GetFocusedDataRow()
            DiagnosisList.DataSource = AsSessionSummaryService.GetDiagnosis(baseDataSet, row, AsSession.baseDataSet.Tables(ASSession_DB.TableDiagnosis).DefaultView)
            MarkCheckListBoxes(Me, DiagnosisList)
        End Sub

        Private Sub SamplesList_ItemCheck(sender As Object, e As DevExpress.XtraEditors.Controls.ItemCheckEventArgs) Handles SamplesList.ItemCheck
            Dim lst As CheckedListBoxControl = CType(sender, CheckedListBoxControl)
            ItemCheck(lst, "strSamples", e)
        End Sub
        Private Sub DiagnosisList_ItemCheck(sender As Object, e As DevExpress.XtraEditors.Controls.ItemCheckEventArgs) Handles DiagnosisList.ItemCheck
            Dim lst As CheckedListBoxControl = CType(sender, CheckedListBoxControl)
            ItemCheck(lst, "strDiagnosis", e)
        End Sub

        Private Sub ItemCheck(lst As CheckedListBoxControl, boundFieldName As String, e As DevExpress.XtraEditors.Controls.ItemCheckEventArgs)
            Dim dv As DataView = CType(lst.DataSource, DataView)
            dv(e.Index)("blnChecked") = (e.State = CheckState.Checked)
            dv(e.Index).EndEdit()
            Dim displayValue As String = ""
            For Each row As DataRowView In dv
                If Not row("blnChecked") Is DBNull.Value AndAlso CBool(row("blnChecked")) Then
                    If (displayValue <> "") Then
                        displayValue += ", "
                    End If
                    displayValue += row("name").ToString
                End If
            Next
            Dim r As DataRow = AsSummaryView.GetFocusedDataRow()
            r(boundFieldName) = displayValue
            r.EndEdit()

        End Sub
        Public Shared Sub MarkCheckListBoxes(ByVal bf As BaseForm, ByVal lst As CheckedListBoxControl)
            bf.BeginUpdate()
            Dim i As Integer = 0
            If Not lst.DataSource Is Nothing AndAlso CType(lst.DataSource, DataView).Count > 0 Then
                lst.BeginUpdate()
                While Not lst.GetItem(i) Is Nothing
                    Dim row As DataRowView = CType(lst.GetItem(i), DataRowView)
                    lst.SetItemChecked(i, True.Equals(row("blnChecked")))
                    i += 1
                End While
                lst.EndUpdate()
            End If
            bf.EndUpdate()

        End Sub

        Private Sub btnDelete_Click(sender As Object, e As System.EventArgs) Handles btnDelete.Click
            Dim r As DataRow = AsSummaryView.GetFocusedDataRow()
            If Not r Is Nothing AndAlso WinUtils.ConfirmDelete Then
                Dim id As Object = r("idfMonitoringSessionSummary")
                Dim idfFarm As Long = FindFarm(r("idfMonitoringSessionSummary"), CLng(r("idfFarm")))
                If idfFarm <= 0 AndAlso Not AsSessionSummaryService.FarmsToDelete.Contains(CLng(r("idfFarm"))) Then
                    AsSessionSummaryService.FarmsToDelete.Add(CLng(r("idfFarm")))
                End If
                r.Delete()
                Dim rows() As DataRow = baseDataSet.Tables(AsSummary_DB.TableAsSummaryDiagnosis).Select(String.Format("idfMonitoringSessionSummary={0}", id))
                For i As Integer = rows.Length - 1 To 0 Step -1
                    rows(i).Delete()
                Next
            End If

        End Sub

        Private Sub AsSummaryView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles AsSummaryView.FocusedRowChanged
            SetFarmPermissions()
        End Sub


        Private Sub AsSummaryView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles AsSummaryView.InitNewRow
            Dim row As DataRow = AsSummaryView.GetDataRow(e.RowHandle)
            AsSessionSummaryService.InitNewSummaryRow(baseDataSet, AsSession.baseDataSet.Tables(ASSession_DB.TableDiagnosis).DefaultView, row)
        End Sub
        Private Sub ASSessionSummary_OnAfterPost(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.OnAfterPost
            If Not sender Is Me Then
                Return
            End If
            For Each row As DataRow In baseDataSet.Tables(AsSummary_DB.TableAsSummary).Rows
                row("blnNewFarm") = False
                row.AcceptChanges()
            Next
        End Sub

        Private Sub cbAnimalSpecies_QueryPopUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbSpecies.QueryPopUp
            If Not cbSpecies.DataSource Is Nothing Then
                Dim row As DataRow = AsSummaryView.GetFocusedDataRow()
                CType(cbSpecies.DataSource, DataView).RowFilter = String.Format("idfFarm = {0}", row("idfFarm")) + GetSessionSpeciesFilter()
            End If
        End Sub
        Private Sub cbAnimalSpecies_CloseUp(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.CloseUpEventArgs) Handles cbSpecies.CloseUp
            If Not cbSpecies.DataSource Is Nothing Then
                CType(cbSpecies.DataSource, DataView).RowFilter = ""
            End If
        End Sub

        Private Sub AsSummaryView_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles AsSummaryView.ShowingEditor
            If Not AsSummaryView.FocusedColumn Is colFarmID AndAlso Utils.Str(AsSummaryView.GetFocusedRowCellValue("strFarmCode")) = "" Then
                e.Cancel = True
            End If
            If Not AsSummaryView.FocusedColumn Is colSpecies AndAlso Not AsSummaryView.FocusedColumn Is colFarmID AndAlso Utils.Str(AsSummaryView.GetFocusedRowCellValue("idfSpecies")) = "" Then
                e.Cancel = True
            End If
            If AsSummaryView.FocusedColumn Is colDiagnosis AndAlso (Utils.IsEmpty(AsSummaryView.GetFocusedRowCellValue("intPositiveAnimalsQty")) OrElse CInt(AsSummaryView.GetFocusedRowCellValue("intPositiveAnimalsQty")) <= 0) Then
                e.Cancel = True
            End If
        End Sub

        Private m_SpeciesList As DataView
        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(False)> _
        Public Property SpeciesList As DataView
            Get
                Return m_SpeciesList
            End Get
            Set(ByVal value As DataView)
                m_SpeciesList = value
            End Set
        End Property

        Private Sub ClearCheckBoxList(ByVal lst As CheckedListBoxControl)
            If Not lst.DataSource Is Nothing And CType(lst.DataSource, DataView).Count > 0 Then
                For Each row As DataRowView In CType(lst.DataSource, DataView)
                    row("blnChecked") = False
                    row.EndEdit()
                Next
            End If
            MarkCheckListBoxes(Me, lst)
        End Sub

        Private Sub CopyCheckBoxList(ByVal lst As CheckedListBoxControl, ByVal clipboard As List(Of Long), ByVal keyName As String)
            clipboard.Clear()
            If Not lst.DataSource Is Nothing And CType(lst.DataSource, DataView).Count > 0 Then
                For Each row As DataRowView In CType(lst.DataSource, DataView)
                    If (row("blnChecked").Equals(True)) Then
                        clipboard.Add(CLng(row(keyName)))
                    End If
                Next
            End If
        End Sub

        Private Sub PasteToCheckListBox(ByVal lst As CheckedListBoxControl, ByVal clipboard As List(Of Long), ByVal keyName As String)
            If Not lst.DataSource Is Nothing And CType(lst.DataSource, DataView).Count > 0 Then

                For Each row As DataRowView In CType(lst.DataSource, DataView)
                    If (clipboard.IndexOf(CLng(row(keyName))) >= 0) Then
                        row("blnChecked") = True
                    ElseIf row("blnChecked").Equals(True) Then
                        row("blnChecked") = False
                    End If
                Next

            End If
            MarkCheckListBoxes(Me, lst)
        End Sub

        Private m_SamplesClipboard As New List(Of Long)
        Private m_DiagnosisClipboard As New List(Of Long)
        Private Sub btnClearSamples_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearSamples.Click
            ClearCheckBoxList(SamplesList)
        End Sub

        Private Sub btnCopySamples_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopySamples.Click
            CopyCheckBoxList(SamplesList, m_SamplesClipboard, "idfsSampleType")
            btnPasteSamples.Enabled = True
        End Sub

        Private Sub btnPasteSamples_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPasteSamples.Click
            PasteToCheckListBox(SamplesList, m_SamplesClipboard, "idfsSampleType")
        End Sub


        Private Sub btnClearDiagnosis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearDiagnosis.Click
            ClearCheckBoxList(DiagnosisList)
        End Sub

        Private Sub btnCopyDiagnosis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyDiagnosis.Click
            CopyCheckBoxList(DiagnosisList, m_DiagnosisClipboard, "idfsDiagnosis")
            btnPasteDiagnosis.Enabled = True
        End Sub

        Private Sub btnPasteDiagnosis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPasteDiagnosis.Click
            PasteToCheckListBox(DiagnosisList, m_DiagnosisClipboard, "idfsDiagnosis")
        End Sub

        Private Sub btnOkDiagnosis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOkdiagnosis.Click, btnOkSamples.Click
            If Not Me.AsSummaryGrid.FocusedView.ActiveEditor Is Nothing AndAlso TypeOf AsSummaryGrid.FocusedView.ActiveEditor Is PopupContainerEdit AndAlso CType(AsSummaryGrid.FocusedView.ActiveEditor, PopupContainerEdit).IsPopupOpen Then
                CType(AsSummaryGrid.FocusedView.ActiveEditor, PopupContainerEdit).ClosePopup()
            End If

        End Sub
        Delegate Sub InvalidateColumnDelegate(ByVal col As GridColumn)
        Private Sub InvalidateColumnAsync(ByVal col As GridColumn)
            Me.BeginInvoke(New InvalidateColumnDelegate(AddressOf InvalidateColumn), col)
        End Sub

        Private Sub InvalidateColumn(ByVal col As GridColumn)

            AsSummaryView.HideEditor()
            AsSummaryView.FocusedColumn = colSamplesQty
            Application.DoEvents()
            AsSummaryView.FocusedColumn = col

        End Sub
        Private Function GetSessionSpeciesFilter() As String
            Dim filter As String = AsSession.GetSpeciesFilter(True)
            If Not Utils.IsEmpty(filter) Then
                Return " and " + filter
            End If
            Return ""
        End Function

        Public Function ContainsSpeciesType(ByVal speciesType As Long) As Boolean
            Return baseDataSet.Tables(AsSummary_DB.TableAsSummary).Select(String.Format("idfsSpeciesType = {0}", speciesType)).Length > 0
        End Function

        Private Sub AsSummaryView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles AsSummaryView.ValidateRow
            Dim row As DataRowView = CType(e.Row, DataRowView)
            If (row("blnNewFarm").Equals(True)) Then
                e.Valid = False
                e.ErrorText = EidssMessages.Get("msgFarmIsNotDefined", "Some mandatory farm attributes are not defined. Press <...> button to edit farm or select other farm.")
                Return
            End If
            If Utils.IsEmpty(row("idfSpecies")) Then
                e.Valid = False
                e.ErrorText = StandardErrorHelper.Error(StandardError.Mandatory, AsSummaryView.Columns("idfSpecies").Caption)
                Return
            End If
            If (Not CollectionDateValidator.Validate(row.Row, False)) Then
                e.Valid = False
                e.ErrorText = CollectionDateValidator.ErrorMessage
                Return
            End If
            If Not Utils.IsEmpty(row("intPositiveAnimalsQty")) AndAlso Not Utils.IsEmpty(row("intSampledAnimalsQty")) Then
                If CInt(row("intPositiveAnimalsQty")) > CInt(row("intSampledAnimalsQty")) Then
                    e.Valid = False
                    e.ErrorText = String.Format(EidssMessages.Get("ErrUnstrictChainNumeric"), colPositiveQty.Caption, CInt(row("intPositiveAnimalsQty")), colSampledAnimalsQty.Caption, CInt(row("intSampledAnimalsQty")))
                End If

            End If
            If Not Utils.IsEmpty(row("intPositiveAnimalsQty")) AndAlso CInt(row("intPositiveAnimalsQty")) > 0 Then

            End If

            If Not AsSession.ValidateCollectionDate(row("datCollectionDate"), e.ErrorText) Then
                e.Valid = False
            End If
        End Sub
        Public Property CollectionDateValidator As DateChainValidator

        Protected Overrides Sub RegisterValidators()
            CollectionDateValidator = New DateChainValidator(Me, AsSummaryGrid, AsSummary_DB.TableAsSummary, "datCollectionDate", colCollectionDate.Caption, , , , True)
        End Sub
        <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public Overrides Property [ReadOnly]() As Boolean
            Get
                Return MyBase.ReadOnly
            End Get
            Set(ByVal Value As Boolean)
                MyBase.ReadOnly = Value
                If Value Then
                    AsSummaryView.OptionsView.NewItemRowPosition = NewItemRowPosition.None
                Else
                    AsSummaryView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top
                End If
            End Set
        End Property

        Public Function CanDeleteSpecies(speciesId As Object) As Boolean
            If (Utils.IsEmpty(speciesId)) Then
                Return True
            End If
            Return baseDataSet.Tables(AsSummary_DB.TableAsSummary).Select(String.Format("idfSpecies = {0}", speciesId)).Length = 0
        End Function

        'Public Function GetDidtinctedValues() As DataTable
        '    Dim view1 As DataView = New DataView(baseDataSet.Tables(AsSummary_DB.TableAsSummary))
        '    Dim t1 As DataTable = view1.ToTable()
        'End Function
        Protected Overrides Sub SaveGridLayouts()
            AsSummaryView.SaveGridLayout("AsSession_Summary")
        End Sub
        Protected Overrides Sub LoadGridLayouts()
            AsSummaryView.InitXtraGridCustomization(New String() {"strFarmCode", "idfSpecies", "strSamples", "intPositiveAnimalsQty", "strDiagnosis"})
            AsSummaryView.LoadGridLayout("AsSession_Summary")
        End Sub
    End Class
End Namespace
