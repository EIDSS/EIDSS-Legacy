Imports System.ComponentModel
Imports bv.common.Configuration
Imports EIDSS.model.Core
Imports DevExpress.XtraGrid.Views.Base
Imports EIDSS.model.Enums
Imports EIDSS.model.Resources
Imports bv.winclient.Localization


Public Class HumanCaseSamplesPanel
    Inherits CaseSamplesPanel

    Dim cbTestDropdown As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit '= New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Private TestView As DataView
    Dim cbTestResultDropdown As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit '= New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Private TestResultView As DataView
    Protected WithEvents colSentDate As DevExpress.XtraGrid.Columns.GridColumn
    Protected WithEvents dtSentDate As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Protected WithEvents dtTestDate As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit

    Protected WithEvents colTestDate As DevExpress.XtraGrid.Columns.GridColumn
    Protected WithEvents colTestName As DevExpress.XtraGrid.Columns.GridColumn
    Protected WithEvents colTestResult As DevExpress.XtraGrid.Columns.GridColumn
    Protected WithEvents cbTestType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Protected WithEvents cbTestDate As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Private WithEvents chkFilterSamples As DevExpress.XtraEditors.CheckEdit
    Protected WithEvents cbTestResult As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    'Friend WithEvents dtReceivedDate As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    'Friend WithEvents colSentDate As DevExpress.XtraGrid.Columns.GridColumn
    Public Sub New()
        MyBase.New()
        Me.DbService = New HumanCaseSamplesDetail_DB
        InitializeComponent()
        Me.cbTestDropdown = CType(Me.cbTestType.Clone(), DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)
        CType(Me.SamplesGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SamplesGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SamplesGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.dtSentDate, Me.dtTestDate, Me.cbTestType, Me.cbTestDate, Me.cbTestResult})
        Me.SamplesGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colSentDate, Me.colTestName, Me.colTestResult, Me.colTestDate})
        colSentDate.VisibleIndex = colCollectionDate.VisibleIndex
        colTestName.VisibleIndex = colSampleCondition.VisibleIndex + 2
        colTestResult.VisibleIndex = colSampleCondition.VisibleIndex + 3
        colTestDate.VisibleIndex = colSampleCondition.VisibleIndex + 4
        colCollectedByInstitution.Visible = True
        colCollectedByInstitution.VisibleIndex = colSampleCondition.VisibleIndex + 5
        colCollectedByOfficer.Visible = True
        colCollectedByOfficer.VisibleIndex = colSampleCondition.VisibleIndex + 6
        colSentToOrganization.Visible = True
        colSentToOrganization.VisibleIndex = colSampleCondition.VisibleIndex + 7
        pnSpecimenDetail.Visible = False
        NotesGroup.Left = SamplesGroup.Left
        NotesGroup.Width = SamplesGroup.Width

        CType(Me.SamplesGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SamplesGridView, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HumanCaseSamplesPanel))
        Me.colSentDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.dtSentDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.colTestDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbTestDate = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.dtTestDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.colTestName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbTestType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colTestResult = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbTestResult = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.chkFilterSamples = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.memoEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCondition, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbAccessionDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbAccessionDate.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpSendToOffice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSendToOffice.SuspendLayout()
        CType(Me.cbSendToOffice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCollectedByInstitution, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCollectedByOfficer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSentToOrganization, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CollectedByGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CollectedByGroup.SuspendLayout()
        CType(Me.cbCollectedByOrganization.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCollectedByPerson.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbAnimalLookup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSpecimenType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnSpecimenDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnSpecimenDetail.SuspendLayout()
        CType(Me.NotesGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SamplesGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SamplesGroup.SuspendLayout()
        CType(Me.cbSpecies, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbVectorID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbVectorType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtCollectionDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtCollectionDate.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtSentDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtSentDate.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTestDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTestDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTestDate.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTestType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTestResult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkFilterSamples.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbAccessionDate
        '
        Me.cbAccessionDate.Mask.EditMask = resources.GetString("cbAccessionDate.Mask.EditMask")
        Me.cbAccessionDate.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton()})
        '
        'grpSendToOffice
        '
        Me.grpSendToOffice.AppearanceCaption.Options.UseFont = True
        '
        'cbSendToOffice
        '
        '
        'CollectedByGroup
        '
        Me.CollectedByGroup.AppearanceCaption.Options.UseFont = True
        '
        'cbCollectedByOrganization
        '
        Me.cbCollectedByOrganization.Properties.AutoHeight = CType(resources.GetObject("cbCollectedByOrganization.Properties.AutoHeight"), Boolean)
        '
        'cbCollectedByPerson
        '
        Me.cbCollectedByPerson.Properties.AutoHeight = CType(resources.GetObject("cbCollectedByPerson.Properties.AutoHeight"), Boolean)
        '
        'pnSpecimenDetail
        '
        Me.pnSpecimenDetail.Appearance.BackColor = CType(resources.GetObject("pnSpecimenDetail.Appearance.BackColor"), System.Drawing.Color)
        Me.pnSpecimenDetail.Appearance.Options.UseBackColor = True
        Me.pnSpecimenDetail.AppearanceCaption.Options.UseFont = True
        Me.pnSpecimenDetail.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.pnSpecimenDetail.LookAndFeel.UseDefaultLookAndFeel = False
        '
        'NotesGroup
        '
        Me.NotesGroup.Appearance.BackColor = CType(resources.GetObject("NotesGroup.Appearance.BackColor"), System.Drawing.Color)
        Me.NotesGroup.Appearance.Options.UseBackColor = True
        Me.NotesGroup.AppearanceCaption.Options.UseFont = True
        Me.NotesGroup.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.NotesGroup.LookAndFeel.UseDefaultLookAndFeel = False
        '
        'SamplesGroup
        '
        Me.SamplesGroup.Appearance.BackColor = CType(resources.GetObject("SamplesGroup.Appearance.BackColor"), System.Drawing.Color)
        Me.SamplesGroup.Appearance.Options.UseBackColor = True
        Me.SamplesGroup.AppearanceCaption.Options.UseFont = True
        Me.SamplesGroup.Controls.Add(Me.chkFilterSamples)
        Me.SamplesGroup.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.SamplesGroup.LookAndFeel.UseDefaultLookAndFeel = False
        Me.SamplesGroup.Controls.SetChildIndex(Me.btnNewSpecimen, 0)
        Me.SamplesGroup.Controls.SetChildIndex(Me.chkFilterSamples, 0)
        Me.SamplesGroup.Controls.SetChildIndex(Me.btnDeleteSpecimen, 0)
        '
        'dtCollectionDate
        '
        Me.dtCollectionDate.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton()})
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(HumanCaseSamplesPanel), resources)
        'Form Is Localizable: True
        '
        'colSentDate
        '
        resources.ApplyResources(Me.colSentDate, "colSentDate")
        Me.colSentDate.ColumnEdit = Me.dtSentDate
        Me.colSentDate.FieldName = "datFieldSentDate"
        Me.colSentDate.Name = "colSentDate"
        '
        'dtSentDate
        '
        resources.ApplyResources(Me.dtSentDate, "dtSentDate")
        Me.dtSentDate.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtSentDate.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtSentDate.Name = "dtSentDate"
        Me.dtSentDate.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        '
        'colTestDate
        '
        resources.ApplyResources(Me.colTestDate, "colTestDate")
        Me.colTestDate.ColumnEdit = Me.cbTestDate
        Me.colTestDate.FieldName = "idfMainTest"
        Me.colTestDate.Name = "colTestDate"
        Me.colTestDate.OptionsColumn.AllowEdit = False
        '
        'cbTestDate
        '
        resources.ApplyResources(Me.cbTestDate, "cbTestDate")
        Me.cbTestDate.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTestDate.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbTestDate.DisplayFormat.FormatString = "d"
        Me.cbTestDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.cbTestDate.DisplayMember = "datPerformedDate"
        Me.cbTestDate.Name = "cbTestDate"
        Me.cbTestDate.ValueMember = "idfTesting"
        '
        'dtTestDate
        '
        resources.ApplyResources(Me.dtTestDate, "dtTestDate")
        Me.dtTestDate.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtTestDate.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtTestDate.Name = "dtTestDate"
        Me.dtTestDate.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        '
        'colTestName
        '
        resources.ApplyResources(Me.colTestName, "colTestName")
        Me.colTestName.ColumnEdit = Me.cbTestType
        Me.colTestName.FieldName = "idfMainTest"
        Me.colTestName.Name = "colTestName"
        '
        'cbTestType
        '
        resources.ApplyResources(Me.cbTestType, "cbTestType")
        Me.cbTestType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTestType.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbTestType.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbTestType.Columns"), resources.GetString("cbTestType.Columns1")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbTestType.Columns2"), resources.GetString("cbTestType.Columns3")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbTestType.Columns4"), resources.GetString("cbTestType.Columns5"), CType(resources.GetObject("cbTestType.Columns6"), Integer), CType(resources.GetObject("cbTestType.Columns7"), DevExpress.Utils.FormatType), resources.GetString("cbTestType.Columns8"), CType(resources.GetObject("cbTestType.Columns9"), Boolean), CType(resources.GetObject("cbTestType.Columns10"), DevExpress.Utils.HorzAlignment))})
        Me.cbTestType.DisplayMember = "TestName"
        Me.cbTestType.Name = "cbTestType"
        Me.cbTestType.ValueMember = "idfTesting"
        '
        'colTestResult
        '
        resources.ApplyResources(Me.colTestResult, "colTestResult")
        Me.colTestResult.ColumnEdit = Me.cbTestResult
        Me.colTestResult.FieldName = "idfMainTest"
        Me.colTestResult.Name = "colTestResult"
        Me.colTestResult.OptionsColumn.AllowEdit = False
        '
        'cbTestResult
        '
        resources.ApplyResources(Me.cbTestResult, "cbTestResult")
        Me.cbTestResult.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTestResult.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbTestResult.DisplayMember = "TestResult"
        Me.cbTestResult.Name = "cbTestResult"
        Me.cbTestResult.ValueMember = "idfTesting"
        '
        'chkFilterSamples
        '
        resources.ApplyResources(Me.chkFilterSamples, "chkFilterSamples")
        Me.chkFilterSamples.Name = "chkFilterSamples"
        Me.chkFilterSamples.Properties.Caption = resources.GetString("chkFilterSamples.Properties.Caption")
        '
        'HumanCaseSamplesPanel
        '
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.Name = "HumanCaseSamplesPanel"
        Me.Status = bv.common.win.FormStatus.Draft
        CType(Me.memoEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCondition, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbAccessionDate.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbAccessionDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpSendToOffice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSendToOffice.ResumeLayout(False)
        Me.grpSendToOffice.PerformLayout()
        CType(Me.cbSendToOffice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCollectedByInstitution, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCollectedByOfficer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSentToOrganization, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CollectedByGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CollectedByGroup.ResumeLayout(False)
        Me.CollectedByGroup.PerformLayout()
        CType(Me.cbCollectedByOrganization.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCollectedByPerson.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbAnimalLookup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSpecimenType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnSpecimenDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnSpecimenDetail.ResumeLayout(False)
        CType(Me.NotesGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SamplesGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SamplesGroup.ResumeLayout(False)
        CType(Me.cbSpecies, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbVectorID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbVectorType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtCollectionDate.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtCollectionDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtSentDate.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtSentDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTestDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtTestDate.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtTestDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTestType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTestResult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkFilterSamples.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private ReadOnly Property IsSearchMode() As Boolean
        Get
            Return (Not Me.DbService Is Nothing) AndAlso _
                   (Utils.Str(Me.DbService.ID) = Utils.Str(Utils.SEARCH_MODE_ID))
        End Get
    End Property

    Public Overrides Function Post(Optional ByVal postType As bv.common.Enums.PostType = bv.common.Enums.PostType.FinalPosting) As Boolean
        If IsSearchMode() Then Return True
        Return MyBase.Post(postType)
    End Function

    Public Sub UpdateNotReadOnlyControlView()
        If Not IsSearchMode() Then
            colTestDate.OptionsColumn.AllowEdit = False
            dtTestDate.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never
        End If
    End Sub

    Public Sub UpdateHumanCaseSamplesPanel_View(ByVal btnTop As Integer)
        If btnTop >= 0 Then
            Dim Diff As Integer = btnTop - btnDeleteSpecimen.Top
            btnDeleteSpecimen.Top = btnTop
            Me.SamplesGrid.Top = Me.SamplesGrid.Top + Diff
            Me.SamplesGrid.Height = Me.SamplesGrid.Height - Diff
            UpdateButtons()
        End If
    End Sub

    Protected Overrides Sub DefineBinding()
        If (EidssSiteContext.Instance.IsAzerbaijanCustomization) Then
            colTestDate.Visible = False
            colTestName.Visible = False
            colTestResult.Visible = False
        End If
        If IsSearchMode Then
            colAccessionedDate.OptionsColumn.AllowEdit = True
            colConditionReceived.OptionsColumn.AllowEdit = True
            colSampleCondition.OptionsColumn.AllowEdit = True
            colTestDate.OptionsColumn.AllowEdit = True
            colTestName.OptionsColumn.AllowEdit = True
            colTestResult.OptionsColumn.AllowEdit = True
            Core.LookupBinder.BindBaseRepositoryLookup(cbTestType, db.BaseReferenceType.rftTestName, HACode.All, False)
            Core.LookupBinder.BindTestResultRepositoryLookup(cbTestResult, False)
            colTestName.FieldName = "idfsTestName"
            colTestResult.FieldName = "idfsTestResult"
            colTestDate.FieldName = "datPerformedDate"
            colTestDate.ColumnEdit = Nothing
            TestResultView = New DataView(CType(cbTestResult.DataSource, DataView).Table)
            cbTestResultDropdown = CType(cbTestResult.Clone, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)
            cbTestResultDropdown.DataSource = TestResultView
            'colTestDate.FieldName=
            'dtDateTested.DataBindings.Add("EditValue", baseDataSet, Batches_DB.TableBatchDetail + ".datPerformedDate")
        Else
            Dim table As DataTable = baseDataSet.Tables(HumanCaseSamplesDetail_DB.TableTests)
            TestView = New DataView(table)
            cbTestType.DataSource = table
            cbTestResult.DataSource = table
            cbTestDate.DataSource = table
            If (table.Rows.Find(-1L)) Is Nothing Then
                Dim emptyRow As DataRow = table.NewRow()
                emptyRow("idfTesting") = -1
                table.Rows.InsertAt(emptyRow, 0)
                Core.LookupBinder.AddChangingHandler(cbTestDropdown, AddressOf Core.LookupBinder.OnClear)
            End If
            Core.LookupBinder.SetDataSource(cbTestDropdown, TestView, "TestName", "idfTesting", Nothing, Nothing)
            'cbTestDropdown.DataSource = TestView
            Me.colSpecimenID.Caption = EidssMessages.Get("HumanSampleID", "Local Sample ID")
            If (baseDataSet.Tables(CaseSamples_Db.TableSamples).Select(String.Format("idfsSampleType = {0}", CLng(SampleTypeEnum.Unknown))).Length = 0) Then
                Dim row As DataRow = CaseSamplesDbService.CreateSample(baseDataSet, DefaultPartyID, Nothing, CaseTestsDetail_Db.UnknownMaterial)
                row("idfsSampleType") = CLng(SampleTypeEnum.Unknown)
                row("strSampleName") = LookupCache.GetLookupValue(CLng(SampleTypeEnum.Unknown), BaseReferenceType.rftSampleType, "name")
                row("datFieldCollectionDate") = DBNull.Value
                row("intOrder") = 1
                row.AcceptChanges()
            End If
            chkFilterSamples.Checked = BaseSettings.FilterSamplesByDiagnosis
        End If

        Try
            RemoveHandler SamplesGridView.CustomRowCellEditForEditing, AddressOf HumanSamplesGridView_CustomRowCellEditForEditing
        Finally
            AddHandler SamplesGridView.CustomRowCellEditForEditing, AddressOf HumanSamplesGridView_CustomRowCellEditForEditing
        End Try

        MyBase.DefineBinding()
        cbSampleTypeEditor = CType(cbSpecimenType.Clone(), DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)
        'Try
        '    RemoveHandler dtSentDate.EditValueChanged, AddressOf DateChanged
        'Finally
        '    AddHandler dtSentDate.EditValueChanged, AddressOf DateChanged
        'End Try
        SamplesGridView.ActiveFilter.NonColumnFilter = String.Format("idfsSampleType<>{0}", CLng(SampleTypeEnum.Unknown))
        SamplesGridView.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never
    End Sub

    Protected Overrides Function ShowEditor(ByVal row As DataRow) As Boolean
        If Not row Is Nothing AndAlso (row("idfsSampleType").Equals(CLng(SampleTypeEnum.Unknown))) Then
            Return False
        End If
        If (SamplesGridView.FocusedColumn.Name = Me.colTestName.Name) Then
            Return True
        End If
        If (SamplesGridView.FocusedColumn.Name = Me.colSampleCondition.Name) Then
            Return False
        End If
        Dim ret As Boolean = MyBase.ShowEditor(row)
        If (ret = False) Then Return False
        Return True
    End Function
    Public Delegate Function DateValidationHandler(ByVal sender As System.Object, ByVal isGlobalAction As Boolean, showError As Boolean) As Boolean
    Public Property ValidateDate As DateValidationHandler
    'Public Overrides Function IsCurrentSpecimenRowValid(Optional ByVal index As Integer = -1, Optional ByVal showError As Boolean = True) As Boolean
    '    Return MyBase.IsCurrentSpecimenRowValid(index, showError) 'lower is an old code

    'End Function

    Dim cbSampleTypeEditor As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Private Sub HumanSamplesGridView_CustomRowCellEditForEditing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs)
        If (e.Column Is Me.colSpecimenType) Then 'And Not IsSearchMode 
            If Me.chkFilterSamples.Checked = False Then Exit Sub
            If Me.baseDataSet.Tables.Contains(TableFiltered) Then
                Me.cbSampleTypeEditor.DataSource = Me.baseDataSet.Tables(TableFiltered)
            Else
                Me.cbSampleTypeEditor.DataSource = Me.cbSpecimenType.DataSource
            End If
            e.RepositoryItem = Me.cbSampleTypeEditor
        End If

        If (e.Column Is Me.colTestName) And Not IsSearchMode Then
            Dim row As DataRow = Me.SamplesGridView.GetDataRow(e.RowHandle)
            If row Is Nothing Then
                TestView.RowFilter = "idfMaterial=-1"
            Else
                TestView.RowFilter = "idfTesting = -1 OR ISNULL(idfRootMaterial, idfMaterial)=" + Utils.Str(row("idfRootMaterial"), Utils.Str(row("idfMaterial")))
            End If
            e.RepositoryItem = Me.cbTestDropdown
        End If

        If (e.Column Is Me.colTestResult) And IsSearchMode Then
            Dim row As DataRow = Me.SamplesGridView.GetDataRow(e.RowHandle)
            TestResultView.RowFilter = String.Format("idfsTestName={0} and intRowStatus = 0", Utils.Str(row("idfsTestName"), "-1"))
            e.RepositoryItem = Me.cbTestResultDropdown
            'CType(Me.cbTestResult.DataSource, DataView).RowFilter = "idfsTestName=" + Utils.Str(row("idfsTestName"), "-1")
        End If
    End Sub

    Private Sub cbTestType_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTestType.EditValueChanged
        If Not Me.IsSearchMode Then Exit Sub
        'Me.SamplesGridView.PostEditor()
        Dim row As DataRow = Me.SamplesGridView.GetDataRow(Me.SamplesGridView.FocusedRowHandle)
        row("idfsTestResult") = DBNull.Value
        'CType(Me.cbTestResult.DataSource, DataView).RowFilter = "idfsTestName=" + Utils.Str(row("idfsTestName"), "-1")
    End Sub

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property CollectionDate() As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
        Get
            Return Me.dtCollectionDate
        End Get
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property SentDate() As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
        Get
            Return Me.dtSentDate
        End Get
    End Property
    Private m_CurrentDiagnosis As Long = -1
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public WriteOnly Property CurrentDiagnosis() As Long
        Set(ByVal Value As Long)
            m_CurrentDiagnosis = Value
            Me.PrepareFilteredSamples()
        End Set
    End Property
    Public Const TableFiltered As String = "FilteredByDisease"
    Protected Sub PrepareFilteredSamples()
        If Me.cbSpecimenType.DataSource Is Nothing Then
            Return
        End If
        If m_CurrentDiagnosis < 0 Then
            If Me.baseDataSet.Tables.Contains(TableFiltered) Then
                Me.baseDataSet.Tables.Remove(TableFiltered)
            End If
            Exit Sub
        End If

        Dim ref As DataTable = CType(Me.cbSpecimenType.DataSource, DataView).Table
        Dim table As DataTable
        If Me.baseDataSet.Tables.Contains(TableFiltered) Then
            table = Me.baseDataSet.Tables(TableFiltered)
            table.Rows.Clear()
        Else
            table = ref.Clone()
            table.TableName = TableFiltered
            Me.baseDataSet.Tables.Add(table)
        End If

        Dim Filter As String = String.Format("idfsDiagnosis={0}", m_CurrentDiagnosis)

        Dim view As DataView = New DataView(Me.baseDataSet.Tables(CaseSamples_Db.TableSamplesToCollect))
        view.RowFilter = Filter
        view.Sort = "idfsReference"

        For Each row As DataRow In ref.Rows
            If view.FindRows(row("idfsReference")).Length > 0 Then
                table.Rows.Add(row.ItemArray)
            End If
        Next
        table.AcceptChanges()
    End Sub
    Public Sub MergeTestTable(source As DataTable)
        Dim target As DataTable = baseDataSet.Tables(HumanCaseSamplesDetail_DB.TableTests)
        For Each sRow As DataRow In source.Rows()
            If sRow.RowState = DataViewRowState.Deleted Then
                Continue For
            End If
            sRow.EndEdit()
            If (sRow("idfMaterial") Is DBNull.Value) Then
                Continue For
            End If
            If sRow("idfsTestStatus").Equals(CLng(TestStatus.Finalized)) OrElse sRow("idfsTestStatus").Equals(CLng(TestStatus.Amended)) Then
                Dim tRow As DataRow = target.Rows.Find(sRow("idfTesting"))
                If tRow Is Nothing Then
                    tRow = target.NewRow()
                    tRow("idfTesting") = sRow("idfTesting")
                    tRow("idfMaterial") = sRow("idfMaterial")
                    target.Rows.Add(tRow)
                End If
                If Not tRow("idfsTestName").Equals(sRow("idfsTestName")) Then
                    tRow("idfsTestName") = sRow("idfsTestName")
                    tRow("TestName") = LookupCache.GetLookupValue(sRow("idfsTestName"), BaseReferenceType.rftTestName, "name")
                End If
                If Not tRow("idfsTestResult").Equals(sRow("idfsTestResult")) Then
                    tRow("idfsTestResult") = sRow("idfsTestResult")
                    tRow("TestResult") = LookupCache.GetLookupValue(sRow("idfsTestResult"), BaseReferenceType.rftTestResult, "name")
                End If
                If Not tRow("idfMaterial").Equals(sRow("idfMaterial")) Then
                    tRow("idfMaterial") = sRow("idfMaterial")
                End If
                If Not tRow("datPerformedDate").Equals(sRow("datConcludedDate")) Then
                    tRow("datPerformedDate") = sRow("datConcludedDate")
                End If
                tRow.EndEdit()
            End If
        Next
        target.AcceptChanges()
    End Sub
    Public ReadOnly Property SentDateCaption As String
        Get
            Return colSentDate.Caption
        End Get
    End Property
    Protected Overrides Sub SaveGridLayouts()
        SamplesGridView.SaveGridLayout("HumanCase_Samples")
    End Sub
    Protected Overrides Sub LoadGridLayouts()
        SamplesGridView.InitXtraGridCustomization(New String() {"idfsSampleType", "strFieldBarcode", "datFieldCollectionDate", "datFieldSentDate", "idfSendToOffice"})
        SamplesGridView.LoadGridLayout("HumanCase_Samples")
    End Sub

End Class
