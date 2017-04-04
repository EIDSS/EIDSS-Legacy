Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Columns
Imports System.Drawing
Imports EIDSS.model.Core
Imports DevExpress.XtraEditors.Controls
Imports EIDSS.Core
Imports bv.winclient.BasePanel
Imports bv.model.Model.Core
Imports bv.winclient.Core
Imports EIDSS.model.Resources
Imports System.ComponentModel
Imports bv.winclient.Localization
Imports System.Collections.Generic
Imports System.Linq
Imports EIDSS.model.Schema
Imports EIDSS.model.Enums
Imports DevExpress.XtraGrid.Views.Grid
Imports bv.common.win.Validators
Imports bv.common.Enums
Imports DevExpress.Utils
Imports bv.common.Resources
Imports DevExpress.XtraGrid.Localization


Namespace ActiveSurveillance

    Public Class AsSessionTableViewPanel
        Private ReadOnly m_TableViewService As AsSessionTableVew_DB

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()
            m_TableViewService = New AsSessionTableVew_DB
            DbService = m_TableViewService
        End Sub
        Private Sub SetFarmPermissions()
            For Each btn As EditorButton In txtFarmID.Buttons
                If (btn.Kind = ButtonPredefines.Ellipsis) Then 'AndAlso EidssUserContext.User.HasPermission(PermissionHelper.UpdatePermission(EIDSSPermissionObject.AccessToFarmData))
                    btn.Visible = (TableView.FocusedRowHandle >= 0) _
                                    OrElse (TableView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission(EIDSSPermissionObject.AccessToFarmData)))
                ElseIf (btn.Kind = ButtonPredefines.Glyph) Then
                    btn.Visible = EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.AccessToFarmData))
                End If
            Next
        End Sub
        Protected Overrides Sub DefineBinding()
            TableViewGrid.DataSource = baseDataSet.Tables(AsSessionTableVew_DB.TableFarmTableView)
            LookupBinder.BindBaseRepositoryLookup(cbAnimalSex, db.BaseReferenceType.rftAnimalSex, HACode.Livestock, False)
            LookupBinder.BindAnimalAgeRepositoryLookup(cbAnimalAge, False)
            LookupBinder.BindBaseRepositoryLookup(cbSpecies, db.BaseReferenceType.rftSpeciesList, False)
            cbSpecies.ValueMember = "idfSpecies"
            cbSpecies.DisplayMember = "strSpeciesName"
            cbSpecies.DataSource = SpeciesList
            LookupBinder.BindSampleRepositoryLookup(cbSampleType, HACode.Livestock, False)
            cbAnimalCode.DataSource = baseDataSet.Tables(AsSessionTableVew_DB.TableAnimals).DefaultView
            AddHandler cbAnimalCode.View.CustomDrawCell, AddressOf DrawLinkToAnimalRow
            cbAnimalCode.View.OptionsView.ShowVerticalLines = DefaultBoolean.False
            cbAnimalCode.PopupFormWidth = 500
            LookupBinder.AddLookupClosedHandler(cbAnimalCode)
            'AnimalsGrid.DataSource = baseDataSet.Tables(AsSessionTableVew_DB.TableAnimals).DefaultView
            LookupBinder.BindBaseRepositoryLookup(cbAnimalSex1, db.BaseReferenceType.rftAnimalSex, HACode.Livestock, False)
            LookupBinder.BindBaseRepositoryLookup(cbAnimalAge1, db.BaseReferenceType.rftAnimalAgeList, False)
            LookupBinder.BindOrganizationRepositoryLookup(cbSentToOffice, HACode.Livestock Or HACode.Avian)
            eventManager.AttachDataHandler(AsSessionTableVew_DB.TableFarmTableView + ".idfSpecies", AddressOf SpeciesChanged)
            eventManager.AttachDataHandler(AsSessionTableVew_DB.TableFarmTableView + ".idfsSampleType", AddressOf SampleTypeChanged)
            eventManager.AttachDataHandler(AsSessionTableVew_DB.TableFarmTableView + ".idfAnimal", AddressOf AnimalChanged)
            eventManager.AttachDataHandler(AsSessionTableVew_DB.TableFarmTableView + ".strColor", AddressOf AnimalChanged)
            eventManager.AttachDataHandler(AsSessionTableVew_DB.TableFarmTableView + ".idfsAnimalAge", AddressOf AnimalChanged)
            eventManager.AttachDataHandler(AsSessionTableVew_DB.TableFarmTableView + ".idfsAnimalGender", AddressOf AnimalChanged)
            eventManager.AttachDataHandler(AsSessionTableVew_DB.TableFarmTableView + ".strName", AddressOf AnimalChanged)
            eventManager.AttachDataHandler(AsSessionTableVew_DB.TableFarmTableView + ".strDescription", AddressOf AnimalChanged)
            UpdateTotals()
            AddHandler baseDataSet.Tables(AsSessionTableVew_DB.TableFarmTableView).TableNewRow, AddressOf RowAdded
            AddHandler baseDataSet.Tables(AsSessionTableVew_DB.TableFarmTableView).RowDeleted, AddressOf RowDeleted
            AddHandler baseDataSet.Tables(AsSessionTableVew_DB.TableFarmTableView).RowChanged, AddressOf RowDeleted
            cbFilteredSampleTypeEditor.Columns.Add(cbSampleType.Columns(0))
            Core.LookupBinder.SetDataSource(cbFilteredSampleTypeEditor, Nothing, "name", "idfsReference", Nothing, Nothing)
            'LookupBinder.RemoveDefaultFilterHandlers(cbFilteredSampleTypeEditor)
            SetFarmPermissions()
        End Sub



        Private Sub DrawLinkToAnimalRow(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs)
            If e.RowHandle = 0 Then
                If e.Column.Name = "colAnimalID1" Then
                    Using f As New Font(WinClientContext.CurrentFont, FontStyle.Bold Or FontStyle.Italic)
                        Dim textSize As SizeF = e.Graphics.MeasureString(e.DisplayText, f)
                        Dim x As Integer = CInt((e.Graphics.ClipBounds.Width - textSize.Width) / 2)
                        If (x < 0) Then
                            x = 0
                        End If
                        If e.Appearance.ForeColor <> Color.Black Then
                            e.Graphics.DrawString(e.DisplayText, f, e.Cache.GetSolidBrush(Color.White), e.Bounds.Location.X + x, e.Bounds.Location.Y + 2)
                        Else
                            e.Graphics.DrawString(e.DisplayText, f, e.Cache.GetSolidBrush(Color.Gray), e.Bounds.Location.X + x, e.Bounds.Location.Y + 2)
                        End If
                    End Using
                End If
                e.Handled = True
            End If
        End Sub

        Private Sub SetDefaultSample(row As DataRow)
            Dim sampleType As Object = AsSession.GetDefaultSample(row("idfsSpeciesType"))
            If Not Utils.IsEmpty(sampleType) Then
                If (Utils.IsEmpty(row("idfMaterial"))) Then
                    row("idfMaterial") = BaseDbService.NewIntID()
                End If
                row("idfsSampleType") = sampleType
                row.EndEdit()
            End If
        End Sub

        Private Sub RowAdded(ByVal sender As Object, ByVal e As DataTableNewRowEventArgs)
            UpdateTotals()
        End Sub
        Private Sub RowDeleted(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
            UpdateTotals()
        End Sub

        Private Sub UpdateTotals()
            txtSamplesQtyTotal.EditValue = baseDataSet.Tables(AsSessionTableVew_DB.TableFarmTableView).Compute("count(idfMaterial)", "not idfMaterial is null")
            txtAnimalsQtyTotal.EditValue = baseDataSet.Tables(AsSessionTableVew_DB.TableAnimals).Select(String.Format("idfAnimal<>{0}", AsSessionTableVew_DB.NewAnimalID), Nothing, DataViewRowState.CurrentRows).Length '.Compute("count(idfAnimal)", Nothing)
        End Sub

        Private Sub txtFarmCode_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtFarmID.ButtonClick
            Dim row As DataRow = TableView.GetDataRow(TableView.FocusedRowHandle)
            If (row Is Nothing) Then
                TableView.ShowEditor()
                If TableView.ActiveEditor IsNot Nothing Then
                    TableView.ActiveEditor.IsModified = True
                End If
                'TableView.SetRowCellValue(TableView.FocusedRowHandle, TableView.Columns("strFarmCode"), "(new)")
                While (row Is Nothing)
                    Application.DoEvents()
                    row = TableView.GetDataRow(TableView.FocusedRowHandle)
                End While
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
                    If True.Equals(row("blnNewFarm")) Then
                        row("blnNewFarm") = False
                    Else
                        defaultSpeciesType = DBNull.Value 'we shall populate default species/sample for new farms only
                    End If

                    row.EndEdit()
                    InvalidateFarmIDColumn()
                    ASSession_DB.PopulateFarmSpecies(SpeciesList.Table, id)
                    PopulateDefaultSpecies(row)
                End If

            ElseIf e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph Then
SelectFarm:
                Dim farmList As IBaseListPanel = AsSession.CreateFarmSelectionForm()

                Dim rootFarm As IObject = BaseFormManager.ShowForSelection(farmList, FindForm())
                If Not rootFarm Is Nothing Then

                    Dim id As Long = FindFarm(row("id"), Utils.Str(rootFarm.GetValue("strFarmCode")))
                    If id <= 0 Then
                        If (AsSession.ValidateAddress(CType(rootFarm, FarmListItem)) = False) Then
                            If (Not WinUtils.ConfirmMessage(EidssMessages.Get("msgAddressIsOutOfBoundaries"))) Then
                                GoTo SelectFarm
                            End If
                        End If
                        id = CLng(ASSession_DB.CreateRootFarmCopy(rootFarm.Key, m_TableViewService.ID))
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
                    ElseIf m_TableViewService.FarmsToUnlink.Contains(id) Then
                        m_TableViewService.FarmsToUnlink.Remove(id)
                    End If

                    row("idfFarm") = id
                    row("blnNewFarm") = False
                    row("idfFarmActual") = rootFarm.Key
                    row("strFarmCode") = Utils.Str(rootFarm.GetValue("strFarmCode"))
                    row.EndEdit()
                    InvalidateFarmIDColumn()

                    ASSession_DB.PopulateFarmSpecies(SpeciesList.Table, id)
                    PopulateDefaultSpecies(row)
                End If
            End If
        End Sub
        Private Sub PopulateDefaultSpecies(row As DataRow)
            If row("idfSpecies") Is DBNull.Value Then
                Dim rows As DataRow() = SpeciesList.Table.Select(String.Format("idfFarm = {0}", row("idfFarm")))
                If (rows.Length = 1) Then
                    row("idfSpecies") = rows(0)("idfSpecies")
                    row("idfsSpeciesType") = rows(0)("idfsReference")
                    row("SpeciesName") = rows(0)("name")
                    row.EndEdit()
                    DataEventManager.Flush()
                    InvalidateColumn(colSpecies)
                    InvalidateColumn(colAnimalID)
                End If
            End If
        End Sub
        Private Sub InvalidateColumn(col As GridColumn)
            TableView.HideEditor()
            TableView.FocusedColumn = colSampleType
            Application.DoEvents()
            TableView.FocusedColumn = col

        End Sub

        Private Sub InvalidateFarmIDColumn()
            InvalidateColumn(colFarmID)
        End Sub

        Public Function FindFarmByCode(ByVal recordId As Object, ByVal farmCode As String) As Long
            Dim filter As String
            If Utils.IsEmpty(recordId) Then
                filter = String.Format("strFarmCode = '{0}'", farmCode)
            Else
                filter = String.Format("strFarmCode = '{0}' and id <> '{1}'", farmCode, recordId)
            End If
            Dim rows As DataRow() = baseDataSet.Tables(AsSessionTableVew_DB.TableFarmTableView).Select(filter)
            If rows.Length > 0 Then
                Return CLng(rows(0)("idfFarm"))
            End If
            Return 0
        End Function
        Public Function FindFarmById(ByVal recordId As Object, ByVal farmId As Long) As Long
            Dim filter As String
            If Utils.IsEmpty(recordId) Then
                filter = String.Format("idfFarm = '{0}'", farmId)
            Else
                filter = String.Format("idfFarm = '{0}' and id <> '{1}'", farmId, recordId)
            End If
            Dim rows As DataRow() = baseDataSet.Tables(AsSessionTableVew_DB.TableFarmTableView).Select(filter)
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
        Private Function FindFarm(ByVal recordId As Object, ByVal farmCode As String) As Long
            Return AsSession.FindFarm(recordId, farmCode)
        End Function
        Private Function FindFarm(ByVal recordId As Object, ByVal farmId As Long) As Long
            Return AsSession.FindFarm(recordId, farmId)
        End Function
        Private Function CanDeleteSample(ByVal row As DataRow) As Boolean

            If row.RowState <> DataRowState.Added AndAlso Utils.Str(row("Used")) = "1" Then
                Return False
            End If
            If CaseSamples_Db.CheckAccessIn(CLng(row("idfMaterial"))) = False Then
                Return False
            End If
            If Not AsSession.CanDeleteSample(row("idfMaterial")) Then
                Return False
            End If
            Return True
        End Function
        Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
            Dim r As DataRow = TableView.GetFocusedDataRow()
            If Not r Is Nothing AndAlso WinUtils.ConfirmDelete Then
                If (Not Utils.IsEmpty(r("idfMaterial"))) Then
                    If Not CanDeleteSample(r) Then
                        ErrorForm.ShowMessage("msgCantDeleteRecord", "The record can't be deleted")
                        Return
                    End If
                End If
                Dim idfFarm As Long = FindFarm(r("id"), CLng(r("idfFarm")))
                If idfFarm <= 0 AndAlso Not m_TableViewService.FarmsToDelete.Contains(CLng(r("idfFarm"))) Then
                    m_TableViewService.FarmsToDelete.Add(CLng(r("idfFarm")))
                Else 'other instanse of farm exists in session
                    idfFarm = FindFarmById(r("id"), CLng(r("idfFarm")))
                    If idfFarm <= 0 Then 'other instance of farm exists on summary tab only, in this case we should unlink farm from session
                        m_TableViewService.FarmsToUnlink.Add(CLng(r("idfFarm")))
                    End If
                End If
                Dim idfAnimal As Object = r("idfAnimal")
                r.Delete()
                If Utils.IsEmpty(idfAnimal) Then Return
                Dim cnt As Object = baseDataSet.Tables(AsSessionTableVew_DB.TableFarmTableView).Compute("count(idfAnimal)", String.Format("idfAnimal={0}", idfAnimal))
                If Not cnt Is Nothing AndAlso CInt(cnt) = 0 Then
                    Dim animalRow As DataRow = baseDataSet.Tables(AsSessionTableVew_DB.TableAnimals).Rows.Find(idfAnimal)
                    If Not animalRow Is Nothing Then
                        animalRow.Delete()
                    End If
                End If
                UpdateTotals()
            End If

        End Sub


        Private Sub TableView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles TableView.FocusedRowChanged
            SetFarmPermissions()
        End Sub


        Private Sub TableView_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles TableView.InitNewRow
            Dim row As DataRow = TableView.GetDataRow(e.RowHandle)
            m_TableViewService.InitNewTableViewRow(row)
        End Sub
        Private Sub AsSessionTableView_OnAfterPost(ByVal sender As Object, ByVal e As EventArgs) Handles Me.OnAfterPost
            If Not sender Is Me Then
                Return
            End If
            For Each row As DataRow In baseDataSet.Tables(AsSessionTableVew_DB.TableFarmTableView).Rows
                row("blnNewFarm") = False
                row.AcceptChanges()
            Next
        End Sub

        Private Sub cbAnimalSpecies_QueryPopUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbSpecies.QueryPopUp
            If Not cbSpecies.DataSource Is Nothing Then
                Dim row As DataRow = TableView.GetFocusedDataRow()
                CType(cbSpecies.DataSource, DataView).RowFilter = String.Format("idfFarm = {0}", row("idfFarm")) + GetSessionSpeciesFilter()
            End If
        End Sub
        Private Sub cbAnimalSpecies_CloseUp(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.CloseUpEventArgs) Handles cbSpecies.CloseUp
            If Not cbSpecies.DataSource Is Nothing Then
                CType(cbSpecies.DataSource, DataView).RowFilter = ""
            End If
        End Sub

        Private Sub TableViewView_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TableView.ShowingEditor
            Dim row As DataRow = TableView.GetFocusedDataRow()
            If (TableView.FocusedColumn Is colFarmID) AndAlso Not row Is Nothing Then
                SetFarmPermissions()
                If Not Utils.IsEmpty("idfSpecies") Then
                    DxControlsHelper.SetButtonEditButtonVisibility(txtFarmID, ButtonPredefines.Glyph, False)
                End If
                Return
            End If

            If (Not row Is Nothing AndAlso True.Equals(row("Used"))) AndAlso _
                (TableView.FocusedColumn Is colSpecies OrElse TableView.FocusedColumn Is colAnimalID OrElse TableView.FocusedColumn Is colCollectionDate OrElse TableView.FocusedColumn Is colFieldSampleID OrElse TableView.FocusedColumn Is colSampleType OrElse TableView.FocusedColumn Is colSentToOffice) Then
                e.Cancel = True
                Return
            End If
            If (TableView.FocusedColumn Is colFarmID) AndAlso Not row Is Nothing AndAlso Not Utils.IsEmpty("idfSpecies") Then
                SetFarmPermissions()
                DxControlsHelper.SetButtonEditButtonVisibility(txtFarmID, ButtonPredefines.Glyph, False)
                Return
            End If

            If Not TableView.FocusedColumn Is colFarmID AndAlso Utils.Str(TableView.GetFocusedRowCellValue("strFarmCode")) = "" Then
                e.Cancel = True
                Return
            End If
            If Not TableView.FocusedColumn Is colFarmID AndAlso Not TableView.FocusedColumn Is colSpecies AndAlso Utils.IsEmpty(TableView.GetFocusedRowCellValue("idfSpecies")) Then
                e.Cancel = True
                Return
            End If
            If Not TableView.FocusedColumn Is colFarmID AndAlso Not TableView.FocusedColumn Is colSpecies AndAlso Not TableView.FocusedColumn Is colAnimalID AndAlso Utils.IsEmpty(TableView.GetFocusedRowCellValue("idfAnimal")) Then
                e.Cancel = True
                Return
            End If
            If (TableView.FocusedColumn Is colFieldSampleID OrElse TableView.FocusedColumn Is colCollectionDate OrElse TableView.FocusedColumn Is colSentToOffice) AndAlso Utils.IsEmpty(TableView.GetFocusedRowCellValue("idfsSampleType")) Then
                e.Cancel = True
            End If
        End Sub

        Private Function IsRowValid(row As DataRow, ByRef errMsg As String) As Boolean
            If row("idfAnimal") Is DBNull.Value Then
                If FindFarmByCode(row("id"), Utils.Str(row("strFarmCode"))) > 0 Then
                    errMsg = EidssMessages.Get("errAsSessionFarmExists", "The selected farm is included to session already. Please define unique animal/sample for this record or select another farm.")
                    Return False
                End If
            ElseIf row("idfsSampleType") Is DBNull.Value Then
                If baseDataSet.Tables(AsSessionTableVew_DB.TableFarmTableView).Select(String.Format("idfAnimal={0} and id<>'{1}' and idfsSampleType is null", Utils.Str(row("idfAnimal")), Utils.Str(row("id")))).Length > 0 Then
                    errMsg = EidssMessages.Get("errAsSessionAnimalExists", "This animal is included to session already. Please define sample for this animal or select another animal.")
                    Return False
                End If
            Else
                If Not Utils.IsEmpty(row("strFieldBarcode")) Then
                    If baseDataSet.Tables(AsSessionTableVew_DB.TableFarmTableView).Select(String.Format("idfAnimal={0} and id<>'{1}' and idfsSampleType={2} and strFieldBarcode = '{3}' ", Utils.Str(row("idfAnimal")), Utils.Str(row("id")), row("idfsSampleType"), row("strFieldBarcode"))).Length > 0 Then
                        errMsg = EidssMessages.Get("errAsSessionSampleExists", "The record with this animal having the same Sample Type And Field Sample ID is included to session already. Please enter unique sample parametes for this animal or select another animal.")
                        Return False
                    End If
                End If
                If (Not CollectionDateValidator.Validate(row, False)) Then
                    errMsg = CollectionDateValidator.ErrorMessage
                    Return False
                End If
                If Not AsSession.ValidateCollectionDate(row("datFieldCollectionDate"), errMsg) Then
                    Return False
                End If
                If (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.AsSessionSample_SentTo) AndAlso _
                    Not True.Equals(row("Used")) AndAlso Utils.IsEmpty(row("idfSendToOffice"))) Then
                    errMsg = StandardErrorHelper.Error(StandardError.Mandatory, colSentToOffice.Caption)
                    Return False
                End If
            End If
            Return True
        End Function
        Private Sub TableView_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles TableView.ValidateRow
            Dim row As DataRowView = CType(e.Row, DataRowView)
            Dim errMsg As String = String.Empty

            If (row("blnNewFarm").Equals(True)) Then
                e.Valid = True
                TableView.CancelUpdateCurrentRow()
                'e.ErrorText = EidssMessages.Get("msgFarmIsNotDefined", "Some mandatory farm attributes are not defined. Press <...> button to edit farm or select other farm.")
            Else
                e.Valid = IsRowValid(row.Row, errMsg)
                If (Not e.Valid) Then
                    e.ErrorText = errMsg
                End If
            End If

            'ElseIf row("idfAnimal") Is DBNull.Value Then
            'If FindFarmByCode(row("id"), Utils.Str(row("strFarmCode"))) > 0 Then
            '    e.Valid = False
            '    e.ErrorText = EidssMessages.Get("errAsSessionFarmExists", "The selected farm is included to session already. Please define unique animal/sample for this record or select another farm.")
            'End If
            'ElseIf row("idfsSampleType") Is DBNull.Value Then
            'If baseDataSet.Tables(AsSessionTableVew_DB.TableFarmTableView).Select(String.Format("idfAnimal={0} and id<>'{1}' and idfsSampleType is null", Utils.Str(row("idfAnimal")), Utils.Str(row("id")))).Length > 0 Then
            '    e.Valid = False
            '    e.ErrorText = EidssMessages.Get("errAsSessionAnimalExists", "This animal is included to session already. Please define sample for this animal or select another animal.")
            'End If
            'Else
            'If Not Utils.IsEmpty(row("strFieldBarcode")) Then
            '    If baseDataSet.Tables(AsSessionTableVew_DB.TableFarmTableView).Select(String.Format("idfAnimal={0} and id<>'{1}' and idfsSampleType={2} and strFieldBarcode = '{3}' ", Utils.Str(row("idfAnimal")), Utils.Str(row("id")), row("idfsSampleType"), row("strFieldBarcode"))).Length > 0 Then
            '        e.Valid = False
            '        e.ErrorText = EidssMessages.Get("errAsSessionSampleExists", "The record with this animal having the same Sample Type And Field Sample ID is included to session already. Please enter unique sample parametes for this animal or select another animal.")
            '        Return
            '    End If
            'End If
            'If (Not CollectionDateValidator.Validate(CType(e.Row, DataRowView).Row, False)) Then
            '    e.Valid = False
            '    e.ErrorText = CollectionDateValidator.ErrorMessage
            '    Return
            'End If
            'If Not AsSession.ValidateCollectionDate(row("datFieldCollectionDate")) Then
            '    e.Valid = False
            '    e.ErrorText = EidssMessages.Get("AsSession.SummaryItem.datCollectionDate_msgId")
            'End If
            'End If
        End Sub

        Private Sub cbAnimalCode_CloseUp(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.CloseUpEventArgs) Handles cbAnimalCode.CloseUp
            baseDataSet.Tables(AsSessionTableVew_DB.TableAnimals).DefaultView.RowFilter = ""
        End Sub


        Private Sub cbAnimalCode_ProcessNewValue(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs) Handles cbAnimalCode.ProcessNewValue
            Dim row As DataRow = TableView.GetFocusedDataRow
            If Not e.DisplayValue.Equals(row("strAnimalCode")) Then
                BeginUpdate()
                Try
                    Dim animalRow As DataRow = baseDataSet.Tables(AsSessionTableVew_DB.TableAnimals).Rows.Find(row("idfAnimal"))
                    If Not animalRow Is Nothing Then
                        animalRow("strAnimalCode") = e.DisplayValue
                    End If
                    row("strAnimalCode") = e.DisplayValue
                    row.EndEdit()

                    Dim rows As DataRow() = baseDataSet.Tables(AsSessionTableVew_DB.TableFarmTableView).Select(String.Format("idfAnimal={0} and id<>'{1}'", row("idfAnimal"), row("id")))
                    For Each r As DataRow In rows
                        r("strAnimalCode") = e.DisplayValue
                        r.EndEdit()
                    Next


                Finally
                    EndUpdate()
                End Try
                e.Handled = True
            End If
        End Sub




        Private Sub cbAnimalID_QueryPopUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbAnimalCode.QueryPopUp
            Dim row As DataRow = TableView.GetFocusedDataRow
            baseDataSet.Tables(AsSessionTableVew_DB.TableAnimals).DefaultView.RowFilter = String.Format("(idfFarm = {0} and idfsSpeciesType={1}) or idfAnimal={2}", row("idfFarm"), row("idfsSpeciesType"), AsSessionTableVew_DB.NewAnimalID)
            DxControlsHelper.SetRowHandleForDataRow(AnimalDropdownView, row, "idfAnimal")
        End Sub
        Private Sub cbAnimalID_QueryCloseUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbAnimalCode.QueryCloseUp
            'Dim row As DataRow = AnimalDropdownView.GetFocusedDataRow
            'baseDataSet.Tables(AsSessionTableVew_DB.TableAnimals).DefaultView.RowFilter = ""
            'DxControlsHelper.SetRowHandleForDataRow(AnimalDropdownView, row, "idfAnimal")
            'Dim animalRow As DataRow = AnimalsView.GetFocusedDataRow
            'Dim row As DataRow = TableView.GetFocusedDataRow
            'Dim oldAnimalID As Object = row("idfAnimal")
            'If Not animalRow Is Nothing AndAlso Not animalRow("idfAnimal").Equals(row("idfAnimal")) Then
            '    For Each col As DataColumn In animalRow.Table.Columns
            '        row(col.ColumnName) = animalRow(col.ColumnName)
            '    Next
            '    row.EndEdit()
            '    TableView.SetFocusedRowModified()
            '    If baseDataSet.Tables(AsSessionTableVew_DB.TableFarmTableView).Select(String.Format("idfAnimal = {0}", oldAnimalID)).Length = 0 Then
            '        row = baseDataSet.Tables(AsSessionTableVew_DB.TableAnimals).Rows.Find(oldAnimalID)
            '        If (Not row Is Nothing) Then
            '            row.Delete()
            '            'row.AcceptChanges()
            '            baseDataSet.Tables(AsSessionTableVew_DB.TableAnimals).AcceptChanges()
            '        End If
            '    End If
            'End If
        End Sub
        'Private Sub AnimalsView_Click(sender As Object, e As System.EventArgs) Handles AnimalsView.Click
        '    If Not cbAnimalID.PopupControl.OwnerEdit Is Nothing Then
        '        cbAnimalID.PopupControl.OwnerEdit.ClosePopup()
        '    End If
        'End Sub

        Private Sub CreateNewAnimal(row As DataRow)
            row("idfAnimal") = BaseDbService.NewIntID
            row("strAnimalCode") = BaseDbService.GetNewVirtualBarcode(baseDataSet.Tables(AsSessionTableVew_DB.TableFarmTableView), "strAnimalCode")
            row.EndEdit()
        End Sub
        Private Sub SpeciesChanged(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
            BeginUpdate()
            Try
                'If e.Row("idfAnimal") Is DBNull.Value Then
                Dim oldAnimalID As Object = e.Row("idfAnimal")
                If (Utils.IsEmpty(oldAnimalID)) Then
                    CreateNewAnimal(e.Row)
                End If
                'TableView.SetFocusedRowModified()
                'End If
                Dim speciesRow As DataRow = baseDataSet.Tables(AsSessionTableVew_DB.TableSpecies).Rows.Find(e.Row("idfSpecies"))
                If speciesRow Is Nothing AndAlso Not SpeciesList Is Nothing Then
                    speciesRow = SpeciesList.Table.Rows.Find(e.Row("idfSpecies"))
                End If
                If Not speciesRow Is Nothing Then
                    e.Row("idfsSpeciesType") = speciesRow("idfsReference")
                    e.Row("SpeciesName") = speciesRow("name")
                End If
                ' and idfSpecies<>{1}, e.Row("idfSpecies")
                Dim animalRows As DataRow() = baseDataSet.Tables(AsSessionTableVew_DB.TableFarmTableView).Select(String.Format("idfAnimal = {0} ", e.Row("idfAnimal")))
                Dim isCurrentAgeValid As Boolean = Not e.Row("idfsAnimalAge") Is DBNull.Value AndAlso _
                                   (CType(cbAnimalAge.DataSource, DataView)).Table.Select( _
                                                                                          String.Format("idfsSpeciesType = {0} and idfsReference = {1}", e.Row("idfsSpeciesType"), e.Row("idfsAnimalAge")) _
                                                                                          ).Length > 0

                For Each row As DataRow In animalRows
                    row("idfSpecies") = e.Row("idfSpecies")
                    row("idfsSpeciesType") = e.Row("idfsSpeciesType")
                    If Not isCurrentAgeValid Then
                        row("idfsAnimalAge") = DBNull.Value
                    End If
                    row.EndEdit()
                Next
                SetDefaultSample(e.Row)
                UpdateAnimalsView(e.Row, oldAnimalID)
                UpdateTotals()

            Finally
                EndUpdate()
            End Try
        End Sub

        Private Sub AnimalChanged(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
            If Not m_BindingDefined Then Return
            BeginUpdate()
            Dim animalRow As DataRow = baseDataSet.Tables(AsSessionTableVew_DB.TableAnimals).Rows.Find(e.Row("idfAnimal"))

            Try
                If (e.Column.ColumnName = "idfAnimal") Then
                    'UpdateAnimalsView(e.Row, e.OldValue)
                    Dim oldAnimalID As Object = e.OldValue
                    If Not animalRow Is Nothing AndAlso Not animalRow("idfAnimal").Equals(e.OldValue) Then
                        For Each col As DataColumn In animalRow.Table.Columns
                            e.Row(col.ColumnName) = animalRow(col.ColumnName)
                        Next
                        e.Row.EndEdit()
                    End If
                    m_TableViewService.DeleteAnimal(baseDataSet, oldAnimalID)
                    Return
                End If
                Dim rows As DataRow() = baseDataSet.Tables(AsSessionTableVew_DB.TableFarmTableView).Select(String.Format("idfAnimal={0} and id<>'{1}'", e.Row("idfAnimal"), e.Row("id")))
                For Each row As DataRow In rows
                    row(e.Column.ColumnName) = e.Row(e.Column.ColumnName)
                    row.EndEdit()
                Next
                If Not animalRow Is Nothing Then
                    animalRow(e.Column.ColumnName) = e.Row(e.Column.ColumnName)
                End If
                'TableView.SetFocusedRowModified()
                'UpdateAnimalsView(e.Row, e.OldValue)

            Finally
                UpdateTotals()
                EndUpdate()
            End Try

        End Sub
        Private Sub SampleTypeChanged(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
            If Not Utils.IsEmpty(e.Row("idfsSampleType")) Then
                If e.Row("idfMaterial") Is DBNull.Value Then
                    e.Row("idfMaterial") = BaseDbService.NewIntID
                End If
                e.Row("strSampleName") = LookupCache.GetLookupValue(e.Row("idfsSampleType"), db.BaseReferenceType.rftSampleType, "name")
            Else
                e.Row("idfMaterial") = DBNull.Value
            End If
            e.Row.EndEdit()
            'TableView.SetFocusedRowModified()
            UpdateTotals()
        End Sub

        Public Overrides Sub UpdateButtonsState(ByVal sender As Object, ByVal e As EventArgs)
            Dim row As DataRow = TableView.GetFocusedDataRow
            If Not row Is Nothing AndAlso TableView.FocusedRowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then
                btnCopyAnimal.Enabled = Not [ReadOnly] AndAlso Not row("idfAnimal") Is DBNull.Value
                btnDelete.Enabled = Not [ReadOnly]
            Else
                btnCopyAnimal.Enabled = False
                btnDelete.Enabled = False
            End If
            txtAnimalCopyCount.Enabled = btnCopyAnimal.Enabled
        End Sub


        Private Sub btnCopyAnimal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCopyAnimal.Click
            BeginUpdate()
            Try
                Dim row As DataRow = TableView.GetFocusedDataRow
                If row Is Nothing Then
                    Return
                End If
                Dim copyRows As DataRow() = baseDataSet.Tables(AsSessionTableVew_DB.TableFarmTableView).Select(String.Format("idfAnimal={0}", row("idfAnimal")))
                Dim count As Integer = CInt(txtAnimalCopyCount.EditValue)
                While count > 0
                    Dim animalCode As String = BaseDbService.GetNewVirtualBarcode(baseDataSet.Tables(AsSessionTableVew_DB.TableFarmTableView), "strAnimalCode")
                    Dim animalID As Object = BaseDbService.NewIntID
                    For Each copyRow As DataRow In copyRows
                        Dim newRow As DataRow = baseDataSet.Tables(AsSessionTableVew_DB.TableFarmTableView).NewRow
                        newRow("idfFarm") = copyRow("idfFarm")
                        newRow("strFarmCode") = copyRow("strFarmCode")
                        newRow("idfFarmActual") = copyRow("idfFarmActual")
                        newRow("idfsSpeciesType") = copyRow("idfsSpeciesType")
                        newRow("idfHerd") = copyRow("idfHerd")
                        newRow("strHerdCode") = copyRow("strHerdCode")
                        newRow("idfAnimal") = animalID
                        newRow("idfsAnimalAge") = copyRow("idfsAnimalAge")
                        newRow("idfsAnimalGender") = copyRow("idfsAnimalGender")
                        newRow("strAnimalCode") = animalCode
                        newRow("idfSpecies") = copyRow("idfSpecies")
                        If Not copyRow("idfMaterial") Is DBNull.Value Then
                            newRow("idfMaterial") = BaseDbService.NewIntID
                        End If
                        newRow("idfsSampleType") = copyRow("idfsSampleType")
                        newRow("datFieldCollectionDate") = copyRow("datFieldCollectionDate")
                        newRow("blnNewFarm") = copyRow("blnNewFarm")
                        newRow("idfMonitoringSession") = m_TableViewService.ID 'copyRow("idfMonitoringSession")
                        newRow("SpeciesName") = copyRow("SpeciesName")
                        newRow("strSampleName") = copyRow("strSampleName")
                        newRow("idfSendToOffice") = copyRow("idfSendToOffice")
                        newRow("Used") = 0
                        baseDataSet.Tables(AsSessionTableVew_DB.TableFarmTableView).Rows.Add(newRow)
                    Next
                    count -= 1
                End While

            Finally
                EndUpdate()
            End Try
            m_TableViewService.UpdateAnimalsView(baseDataSet)
            UpdateTotals()
        End Sub

        Private Sub UpdateAnimalsView(ByVal row As DataRow, ByVal oldAnimalID As Object)
            m_TableViewService.UpdateAnimalsView(baseDataSet, row, oldAnimalID)
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
        Private Function GetSessionSpeciesFilter() As String
            Dim filter As String = AsSession.GetSpeciesFilter(True)
            If Not Utils.IsEmpty(filter) Then
                Return " and " + filter
            End If
            Return ""
        End Function

        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property SamplesList() As DataView
            Get
                Dim view As New DataView(baseDataSet.Tables(AsSessionTableVew_DB.TableFarmTableView))
                view.RowFilter = "not idfMaterial is null"
                Return view
            End Get
        End Property
        Public Function ContainsSpeciesType(ByVal speciesType As Long) As Boolean
            Return baseDataSet.Tables(AsSessionTableVew_DB.TableFarmTableView).Select(String.Format("idfsSpeciesType = {0}", speciesType)).Length > 0
        End Function
        Public Overrides Function ValidateData() As Boolean
            If Not AsSession.TableViewMode Then
                Return True
            End If
            If MyBase.ValidateData() = False Then
                Return False
            End If
            For Each row As DataRow In baseDataSet.Tables(AsSessionTableVew_DB.TableFarmTableView).Rows
                If row.RowState = DataRowState.Deleted OrElse row.RowState = DataRowState.Detached Then
                    Continue For
                End If
                Dim errMsg As String = String.Empty
                If (Not IsRowValid(row, errMsg)) Then
                    ErrorForm.ShowMessageDirect(errMsg)
                    Return False
                End If
            Next
            If HasDuplicates(baseDataSet.Tables(AsSessionTableVew_DB.TableFarmTableView).AsEnumerable()) Then
                MessageForm.Show(EidssMessages.Get("AsSession.DetailsTableView.DuplicateSample"))
                Return False
            End If
            Return True
        End Function
        Private Function HasDuplicates(ByVal samples As IEnumerable(Of DataRow)) As Boolean
            Dim hash As New HashSet(Of DataRow)(New SampleComparer())
            Return samples.Any(Function(sample) Not hash.Add(sample))
        End Function

        Public Property CollectionDateValidator As DateChainValidator
        Protected Overrides Sub RegisterValidators()
            CollectionDateValidator = New DateChainValidator(Me, TableViewGrid, AsSessionTableVew_DB.TableFarmTableView, "datFieldCollectionDate", colCollectionDate.Caption, , , , True)
        End Sub

        Public cbFilteredSampleTypeEditor As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Private m_FilteredSamplesDataset As DataSet
        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public WriteOnly Property FilteredSamplesDataset As DataSet
            Set(value As DataSet)
                m_FilteredSamplesDataset = value
            End Set
        End Property

        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public Property FilterSamplesBydiagnosis As Boolean
        Private m_cbAnimalCode As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit
        Private m_SamplesView As DataView
        Private Sub TableView_CustomRowCellEditForEditing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles TableView.CustomRowCellEditForEditing
            Dim row As DataRow = TableView.GetDataRow(e.RowHandle)
            If (e.Column Is colAnimalID) Then
                If m_cbAnimalCode Is Nothing Then
                    m_cbAnimalCode = CType(cbAnimalCode.Clone(), DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit)
                    m_cbAnimalCode.DataSource = New DataView(baseDataSet.Tables(AsSessionTableVew_DB.TableAnimals))
                End If
                If (Not row Is Nothing AndAlso Not Utils.IsEmpty(row("idfSpecies"))) Then
                    CType(m_cbAnimalCode.DataSource, DataView).RowFilter = String.Format("idfSpecies = {0} or idfAnimal = {1}", TableView.GetDataRow(e.RowHandle)("idfSpecies"), AsSessionTableVew_DB.NewAnimalID)
                Else
                    CType(m_cbAnimalCode.DataSource, DataView).RowFilter = "0=1"
                End If
                e.RepositoryItem = m_cbAnimalCode
                Return
            End If
            If Not (e.Column Is colSampleType) Then Exit Sub
            Dim filter As String = AsSession.GetSpeciesSamplesFilter(row("idfsSpeciesType"), FilterSamplesBydiagnosis)
            If Not Utils.IsEmpty(filter) Then
                If (m_SamplesView Is Nothing) Then
                    m_SamplesView = New DataView(CType(cbSampleType.DataSource, DataView).Table)
                End If
                cbFilteredSampleTypeEditor.DataSource = m_SamplesView
                Dim curSampleType As Object = row("idfsSampleType")
                If Utils.IsEmpty(curSampleType) Then
                    curSampleType = -1L
                End If
                CType(cbFilteredSampleTypeEditor.DataSource, DataView).RowFilter = String.Format("idfsReference = {0} or idfsReference = {1} or idfsReference in {2}", LookupCache.EmptyLineKey, curSampleType, filter)
                e.RepositoryItem = cbFilteredSampleTypeEditor
                Return
            End If
            'If m_FilteredSamplesDataset Is Nothing OrElse FilterSamplesBydiagnosis = False Then Exit Sub
            'If m_FilteredSamplesDataset.Tables.Contains(CaseSamples_Db.TableFiltered) Then
            '    cbFilteredSampleTypeEditor.DataSource = m_FilteredSamplesDataset.Tables(CaseSamples_Db.TableFiltered)
            'Else
            '    cbFilteredSampleTypeEditor.DataSource = cbSampleType.DataSource
            'End If
            'e.RepositoryItem = cbFilteredSampleTypeEditor
        End Sub
        <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public Overrides Property [ReadOnly]() As Boolean
            Get
                Return MyBase.ReadOnly
            End Get
            Set(ByVal Value As Boolean)
                MyBase.ReadOnly = Value
                If Value Then
                    TableView.OptionsView.NewItemRowPosition = NewItemRowPosition.None
                Else
                    TableView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top
                End If
            End Set
        End Property


        Public Class SampleComparer
            Implements IEqualityComparer(Of DataRow)

            Public Overloads Function Equals(
                ByVal x As DataRow,
                ByVal y As DataRow
                ) As Boolean Implements IEqualityComparer(Of DataRow).Equals

                ' Check whether the compared objects reference the same data.
                If x Is y Then Return True
                If x.RowState = DataRowState.Deleted OrElse x.RowState = DataRowState.Detached OrElse y.RowState = DataRowState.Deleted OrElse y.RowState = DataRowState.Detached Then
                    Return False
                End If

                'Check whether any of the compared objects is null.
                If x Is Nothing OrElse y Is Nothing Then Return False
                If Utils.IsEmpty(x("strFieldBarcode")) OrElse Utils.IsEmpty(x("strFieldBarcode")) Then Return False

                ' Check whether the products' properties are equal.
                Return x("idfAnimal").Equals(y("idfAnimal")) AndAlso x("idfsSampleType").Equals(y("idfsSampleType")) AndAlso x("strFieldBarcode").Equals(y("strFieldBarcode"))
            End Function

            Public Overloads Function GetHashCode(ByVal sample As DataRow) As Integer Implements IEqualityComparer(Of DataRow).GetHashCode
                ' Check whether the object is null.
                If sample Is Nothing Then Return 0
                If sample.RowState = DataRowState.Deleted OrElse sample.RowState = DataRowState.Detached Then
                    Return 0
                End If
                ' Get hash code for the Name field if it is not null.
                Return sample("idfAnimal").GetHashCode() Xor sample("idfsSampleType").GetHashCode() Xor sample("strFieldBarcode").GetHashCode()
            End Function


        End Class

        Private Sub cbAnimalCode_EditValueChanging(sender As Object, e As ChangingEventArgs) Handles cbAnimalCode.EditValueChanging
            If AsSessionTableVew_DB.NewAnimalID.Equals(e.NewValue) Then
                Dim row As DataRow = TableView.GetFocusedDataRow()
                CreateNewAnimal(row)
                e.NewValue = row("idfAnimal")
                UpdateAnimalsView(row, e.OldValue)
            End If
        End Sub
        Public Function CanDeleteSpecies(speciesId As Object) As Boolean
            If (Utils.IsEmpty(speciesId)) Then
                Return True
            End If
            Return baseDataSet.Tables(AsSessionTableVew_DB.TableFarmTableView).Select(String.Format("idfSpecies = {0} and not idfAnimal is null", speciesId)).Length = 0
        End Function
        Public Function CanDeleteHerd(herdId As Object) As Boolean
            If (Utils.IsEmpty(herdId)) Then
                Return True
            End If
            Return baseDataSet.Tables(AsSessionTableVew_DB.TableFarmTableView).Select(String.Format("idfHerd = {0} and not idfAnimal is null", herdId)).Length = 0
        End Function

        Private Sub TableView_InvalidRowException(sender As Object, e As InvalidRowExceptionEventArgs) Handles TableView.InvalidRowException
            e.ExceptionMode = ExceptionMode.NoAction
            If (MessageForm.Show(String.Format(EidssMessages.Get("msgGenericTwoValuesFormat"), e.ErrorText, XtraStrings.Get("GridStringId.ColumnViewExceptionMessage", "")), e.WindowCaption, MessageBoxButtons.YesNo) = DialogResult.No) Then
                m_TableViewService.DeleteAnimal(baseDataSet, CType(e.Row, DataRowView)("idfAnimal"))
                CType(e.Row, DataRowView).CancelEdit()
                UpdateTotals()
                TableView.FocusedColumn = TableView.Columns(0)
            End If
        End Sub
        Protected Overrides Sub SaveGridLayouts()
            TableView.SaveGridLayout("AsSession_TableView")
        End Sub
        Protected Overrides Sub LoadGridLayouts()
            TableView.InitXtraGridCustomization(New String() {"strFarmCode", "idfSpecies", "idfAnimal", "idfsSampleType", "strFieldBarcode", "datFieldCollectionDate", "idfSendToOffice"})
            TableView.LoadGridLayout("AsSession_TableView")
        End Sub
    End Class
End Namespace
