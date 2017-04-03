Imports System.Data
Imports System.ComponentModel
Imports EIDSS.model.Resources
Imports bv.winclient.Core
Imports bv.winclient.Localization
Imports bv.common.Resources

Public Class VaccinationPanel
    Inherits bv.common.win.BaseDetailPanel

#Region " Windows Form Designer generated code "
    Public VaccinationDbService As Vaccination_DB

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        VaccinationDbService = New Vaccination_DB
        DbService = VaccinationDbService

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnAddDiagnosis As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDeleteDiagnosis As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents redTxtDiseaseCode As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents cbDiseaseName As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cbBasisForDiagnosis As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cbDiagnosedBy As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cbDiagnosisType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colDiseaseName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents VaccinationGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents DiagnosesView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents VaccinationGroup As DevExpress.XtraEditors.GroupControl
    Friend WithEvents colVaccinationDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents dtVaccnationDate As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents colVaccinationType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cbRoute As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colManufacturer As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNumberOfVaccinated As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLotNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtNumberOfVaccianted As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents colComment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtNotes As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents colSpecies As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbSpecies As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colRouteAdministered As DevExpress.XtraGrid.Columns.GridColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VaccinationPanel))
        Me.VaccinationGroup = New DevExpress.XtraEditors.GroupControl()
        Me.VaccinationGrid = New DevExpress.XtraGrid.GridControl()
        Me.DiagnosesView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colDiseaseName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbDiseaseName = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colSpecies = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbSpecies = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colVaccinationType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colRouteAdministered = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbRoute = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colVaccinationDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.dtVaccnationDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.colManufacturer = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLotNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNumberOfVaccinated = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtNumberOfVaccianted = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.colComment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtNotes = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.cbDiagnosisType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.redTxtDiseaseCode = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.cbBasisForDiagnosis = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.cbDiagnosedBy = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.btnAddDiagnosis = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDeleteDiagnosis = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.VaccinationGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.VaccinationGroup.SuspendLayout()
        CType(Me.VaccinationGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DiagnosesView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDiseaseName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSpecies, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbRoute, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtVaccnationDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtVaccnationDate.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumberOfVaccianted, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNotes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDiagnosisType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.redTxtDiseaseCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbBasisForDiagnosis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDiagnosedBy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'VaccinationGroup
        '
        Me.VaccinationGroup.Appearance.BackColor = CType(resources.GetObject("VaccinationGroup.Appearance.BackColor"), System.Drawing.Color)
        Me.VaccinationGroup.Appearance.Options.UseBackColor = True
        Me.VaccinationGroup.AppearanceCaption.Font = CType(resources.GetObject("VaccinationGroup.AppearanceCaption.Font"), System.Drawing.Font)
        Me.VaccinationGroup.AppearanceCaption.Options.UseFont = True
        Me.VaccinationGroup.Controls.Add(Me.VaccinationGrid)
        Me.VaccinationGroup.Controls.Add(Me.btnAddDiagnosis)
        Me.VaccinationGroup.Controls.Add(Me.btnDeleteDiagnosis)
        resources.ApplyResources(Me.VaccinationGroup, "VaccinationGroup")
        Me.VaccinationGroup.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.VaccinationGroup.LookAndFeel.UseDefaultLookAndFeel = False
        Me.VaccinationGroup.Name = "VaccinationGroup"
        '
        'VaccinationGrid
        '
        resources.ApplyResources(Me.VaccinationGrid, "VaccinationGrid")
        Me.VaccinationGrid.MainView = Me.DiagnosesView
        Me.VaccinationGrid.Name = "VaccinationGrid"
        Me.VaccinationGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.dtVaccnationDate, Me.cbDiagnosisType, Me.redTxtDiseaseCode, Me.cbDiseaseName, Me.cbBasisForDiagnosis, Me.cbDiagnosedBy, Me.cbType, Me.cbRoute, Me.txtNumberOfVaccianted, Me.txtNotes, Me.cbSpecies})
        Me.VaccinationGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.DiagnosesView})
        '
        'DiagnosesView
        '
        Me.DiagnosesView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colDiseaseName, Me.colSpecies, Me.colVaccinationType, Me.colRouteAdministered, Me.colVaccinationDate, Me.colManufacturer, Me.colLotNumber, Me.colNumberOfVaccinated, Me.colComment})
        Me.DiagnosesView.GridControl = Me.VaccinationGrid
        resources.ApplyResources(Me.DiagnosesView, "DiagnosesView")
        Me.DiagnosesView.Name = "DiagnosesView"
        Me.DiagnosesView.OptionsCustomization.AllowFilter = False
        Me.DiagnosesView.OptionsDetail.AllowExpandEmptyDetails = True
        Me.DiagnosesView.OptionsNavigation.AutoFocusNewRow = True
        Me.DiagnosesView.OptionsNavigation.EnterMoveNextColumn = True
        Me.DiagnosesView.OptionsView.ShowGroupPanel = False
        '
        'colDiseaseName
        '
        Me.colDiseaseName.AppearanceHeader.Font = CType(resources.GetObject("colDiseaseName.AppearanceHeader.Font"), System.Drawing.Font)
        Me.colDiseaseName.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colDiseaseName, "colDiseaseName")
        Me.colDiseaseName.ColumnEdit = Me.cbDiseaseName
        Me.colDiseaseName.FieldName = "idfsDiagnosis"
        Me.colDiseaseName.Name = "colDiseaseName"
        '
        'cbDiseaseName
        '
        resources.ApplyResources(Me.cbDiseaseName, "cbDiseaseName")
        Me.cbDiseaseName.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDiseaseName.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbDiseaseName.Name = "cbDiseaseName"
        '
        'colSpecies
        '
        resources.ApplyResources(Me.colSpecies, "colSpecies")
        Me.colSpecies.ColumnEdit = Me.cbSpecies
        Me.colSpecies.FieldName = "idfSpecies"
        Me.colSpecies.Name = "colSpecies"
        '
        'cbSpecies
        '
        resources.ApplyResources(Me.cbSpecies, "cbSpecies")
        Me.cbSpecies.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSpecies.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbSpecies.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbSpecies.Columns"), resources.GetString("cbSpecies.Columns1")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbSpecies.Columns2"), resources.GetString("cbSpecies.Columns3"))})
        Me.cbSpecies.DisplayMember = "HerdSpecies"
        Me.cbSpecies.Name = "cbSpecies"
        Me.cbSpecies.ValueMember = "idfSpecies"
        '
        'colVaccinationType
        '
        Me.colVaccinationType.AppearanceHeader.Font = CType(resources.GetObject("colVaccinationType.AppearanceHeader.Font"), System.Drawing.Font)
        Me.colVaccinationType.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colVaccinationType, "colVaccinationType")
        Me.colVaccinationType.ColumnEdit = Me.cbType
        Me.colVaccinationType.FieldName = "idfsVaccinationType"
        Me.colVaccinationType.Name = "colVaccinationType"
        '
        'cbType
        '
        resources.ApplyResources(Me.cbType, "cbType")
        Me.cbType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbType.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbType.Name = "cbType"
        '
        'colRouteAdministered
        '
        Me.colRouteAdministered.AppearanceHeader.Font = CType(resources.GetObject("colRouteAdministered.AppearanceHeader.Font"), System.Drawing.Font)
        Me.colRouteAdministered.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colRouteAdministered, "colRouteAdministered")
        Me.colRouteAdministered.ColumnEdit = Me.cbRoute
        Me.colRouteAdministered.FieldName = "idfsVaccinationRoute"
        Me.colRouteAdministered.Name = "colRouteAdministered"
        '
        'cbRoute
        '
        resources.ApplyResources(Me.cbRoute, "cbRoute")
        Me.cbRoute.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbRoute.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbRoute.Name = "cbRoute"
        '
        'colVaccinationDate
        '
        Me.colVaccinationDate.AppearanceHeader.Font = CType(resources.GetObject("colVaccinationDate.AppearanceHeader.Font"), System.Drawing.Font)
        Me.colVaccinationDate.AppearanceHeader.Options.UseFont = True
        resources.ApplyResources(Me.colVaccinationDate, "colVaccinationDate")
        Me.colVaccinationDate.ColumnEdit = Me.dtVaccnationDate
        Me.colVaccinationDate.FieldName = "datVaccinationDate"
        Me.colVaccinationDate.Name = "colVaccinationDate"
        '
        'dtVaccnationDate
        '
        resources.ApplyResources(Me.dtVaccnationDate, "dtVaccnationDate")
        Me.dtVaccnationDate.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtVaccnationDate.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtVaccnationDate.HideSelection = False
        Me.dtVaccnationDate.Name = "dtVaccnationDate"
        Me.dtVaccnationDate.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        '
        'colManufacturer
        '
        resources.ApplyResources(Me.colManufacturer, "colManufacturer")
        Me.colManufacturer.FieldName = "strManufacturer"
        Me.colManufacturer.Name = "colManufacturer"
        '
        'colLotNumber
        '
        resources.ApplyResources(Me.colLotNumber, "colLotNumber")
        Me.colLotNumber.FieldName = "strLotNumber"
        Me.colLotNumber.Name = "colLotNumber"
        '
        'colNumberOfVaccinated
        '
        resources.ApplyResources(Me.colNumberOfVaccinated, "colNumberOfVaccinated")
        Me.colNumberOfVaccinated.ColumnEdit = Me.txtNumberOfVaccianted
        Me.colNumberOfVaccinated.FieldName = "intNumberVaccinated"
        Me.colNumberOfVaccinated.Name = "colNumberOfVaccinated"
        '
        'txtNumberOfVaccianted
        '
        resources.ApplyResources(Me.txtNumberOfVaccianted, "txtNumberOfVaccianted")
        Me.txtNumberOfVaccianted.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtNumberOfVaccianted.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtNumberOfVaccianted.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtNumberOfVaccianted.IsFloatValue = False
        Me.txtNumberOfVaccianted.Mask.EditMask = resources.GetString("txtNumberOfVaccianted.Mask.EditMask")
        Me.txtNumberOfVaccianted.MaxValue = New Decimal(New Integer() {100000000, 0, 0, 0})
        Me.txtNumberOfVaccianted.Name = "txtNumberOfVaccianted"
        '
        'colComment
        '
        resources.ApplyResources(Me.colComment, "colComment")
        Me.colComment.ColumnEdit = Me.txtNotes
        Me.colComment.FieldName = "strNote"
        Me.colComment.Name = "colComment"
        '
        'txtNotes
        '
        resources.ApplyResources(Me.txtNotes, "txtNotes")
        Me.txtNotes.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtNotes.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtNotes.MaxLength = 2000
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ShowIcon = False
        '
        'cbDiagnosisType
        '
        resources.ApplyResources(Me.cbDiagnosisType, "cbDiagnosisType")
        Me.cbDiagnosisType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDiagnosisType.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbDiagnosisType.Name = "cbDiagnosisType"
        '
        'redTxtDiseaseCode
        '
        resources.ApplyResources(Me.redTxtDiseaseCode, "redTxtDiseaseCode")
        Me.redTxtDiseaseCode.Name = "redTxtDiseaseCode"
        Me.redTxtDiseaseCode.ReadOnly = True
        '
        'cbBasisForDiagnosis
        '
        resources.ApplyResources(Me.cbBasisForDiagnosis, "cbBasisForDiagnosis")
        Me.cbBasisForDiagnosis.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbBasisForDiagnosis.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbBasisForDiagnosis.Name = "cbBasisForDiagnosis"
        '
        'cbDiagnosedBy
        '
        resources.ApplyResources(Me.cbDiagnosedBy, "cbDiagnosedBy")
        Me.cbDiagnosedBy.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDiagnosedBy.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbDiagnosedBy.Name = "cbDiagnosedBy"
        Me.cbDiagnosedBy.PopupWidth = 300
        '
        'btnAddDiagnosis
        '
        resources.ApplyResources(Me.btnAddDiagnosis, "btnAddDiagnosis")
        Me.btnAddDiagnosis.Image = Global.eidss.My.Resources.Resources.add
        Me.btnAddDiagnosis.Name = "btnAddDiagnosis"
        '
        'btnDeleteDiagnosis
        '
        resources.ApplyResources(Me.btnDeleteDiagnosis, "btnDeleteDiagnosis")
        Me.btnDeleteDiagnosis.Image = Global.eidss.My.Resources.Resources.Delete_Remove
        Me.btnDeleteDiagnosis.Name = "btnDeleteDiagnosis"
        '
        'VaccinationPanel
        '
        Me.Controls.Add(Me.VaccinationGroup)
        Me.Name = "VaccinationPanel"
        resources.ApplyResources(Me, "$this")
        CType(Me.VaccinationGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.VaccinationGroup.ResumeLayout(False)
        CType(Me.VaccinationGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DiagnosesView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDiseaseName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSpecies, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbRoute, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtVaccnationDate.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtVaccnationDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumberOfVaccianted, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNotes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDiagnosisType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.redTxtDiseaseCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbBasisForDiagnosis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDiagnosedBy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Protected Overrides Sub DefineBinding()
        VaccinationGrid.DataSource = baseDataSet.Tables(Vaccination_DB.TableVaccination)
        If Me.CaseKind = CaseType.Avian Then
            Core.LookupBinder.BindDiagnosisHACodeRepositoryLookup(Me.cbDiseaseName, LookupTables.AvianStandardDiagnosis)
        Else
            Core.LookupBinder.BindDiagnosisHACodeRepositoryLookup(Me.cbDiseaseName, LookupTables.LivestockStandardDiagnosis)
        End If
        Core.LookupBinder.BindBaseRepositoryLookup(Me.cbType, BaseReferenceType.rftVaccinationType, True)
        Core.LookupBinder.BindBaseRepositoryLookup(Me.cbRoute, BaseReferenceType.rftVaccinationRoute, True)
        If [ReadOnly] Then
            btnAddDiagnosis.Enabled = False
            btnDeleteDiagnosis.Enabled = False
        End If
    End Sub
    Public Event DiagnosisChanged()

    Private Sub btnAddDiagnosis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddDiagnosis.Click
        DataEventManager.Flush()

        If Not IsRowValid(, True) Then
            Return
        End If

        Dim row As DataRow = VaccinationDbService.AddVacciation(baseDataSet)
        DxControlsHelper.SetRowHandleForDataRow(DiagnosesView, row, "idfVaccination")
    End Sub

    Private Sub btnDeleteDiagnosis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteDiagnosis.Click
        Dim nRow As Integer = CType(VaccinationGrid.FocusedView, DevExpress.XtraGrid.Views.Base.ColumnView).FocusedRowHandle
        If (nRow < 0) Then
            Return
        Else
            If (MessageForm.Show(EidssMessages.Get("mbDeleteVaccination", "Delete selected Vaccination?"), EidssMessages.Get("mbConfirmation", "Confirmation"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes) Then
                Dim row As DataRow = DiagnosesView.GetDataRow(nRow)
                If Not row Is Nothing Then
                    row.Delete()
                End If
            End If
        End If

    End Sub
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property SpeciesList() As Object
        Get
            Return cbSpecies.DataSource
        End Get
        Set(ByVal Value As Object)
            cbSpecies.DataSource = Value
        End Set
    End Property
    Private m_CaseKind As CaseType = CaseType.Livestock
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Property CaseKind() As CaseType
        Get
            Return m_CaseKind
        End Get
        Set(ByVal Value As CaseType)
            m_CaseKind = Value
        End Set
    End Property
    Public Function CanDeleteParty(ByVal partyID As Object) As Boolean
        If Utils.IsEmpty(partyID) Then Return False
        For Each row As DataRow In baseDataSet.Tables(Vaccination_DB.TableVaccination).Rows
            If row.RowState <> DataRowState.Deleted Then
                If row("idfSpecies").Equals(partyID) Then
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

    Public Overrides Function ValidateData() As Boolean
        Return ValidateGridData(True)
    End Function

    Public Function ValidateGridData(ByVal ShowError As Boolean) As Boolean
        'For i As Integer = 0 To DiagnosesView.RowCount - 1
        If Me.DiagnosesView.FocusedRowHandle >= 0 Then
            If Not IsRowValid(DiagnosesView.FocusedRowHandle, ShowError) Then
                If ShowError Then VaccinationGrid.Select()
                Return False
            End If
        End If
        'Next
        Return True
    End Function

    Private Function IsRowValid(Optional ByVal index As Integer = -1, Optional ByVal showError As Boolean = True) As Boolean
        If index = -1 Then index = DiagnosesView.FocusedRowHandle
        If index < 0 Then Return True
        Dim row As DataRow = DiagnosesView.GetDataRow(index)

        If row Is Nothing Then Return True
        Dim msg As String = ""
        If row("datVaccinationDate") Is DBNull.Value Then
            If showError Then
                msg += String.Format(BvMessages.Get("ErrMandatoryFieldRequired", "The field {0} is mandatory. You must enter data to this field before form saving"), DiagnosesView.Columns("datVaccinationDate").Caption) + vbCrLf
                ErrorForm.ShowWarningDirect(msg)
                DiagnosesView.FocusedColumn = colVaccinationDate
                DiagnosesView.FocusedRowHandle = index
            End If
            Return False
        End If

        If showError Then
            If Not bv.winclient.Core.WinUtils.CompareDates(row("datVaccinationDate"), DateTime.Today, "datVaccinationDate_CurrentDate_msgId") Then
                Return False
            End If
        Else
            If Not bv.winclient.Core.WinUtils.CompareDates(row("datVaccinationDate"), DateTime.Today) Then
                Return False
            End If
        End If

        Return True
    End Function
    Dim m_Updating As Boolean
    Private Sub DiagnosesView_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DiagnosesView.FocusedRowChanged
        If Loading OrElse m_Updating Then Return
        m_Updating = True
        Try
            If e.PrevFocusedRowHandle >= 0 AndAlso IsRowValid(e.PrevFocusedRowHandle) = False Then
                DiagnosesView.FocusedRowHandle = e.PrevFocusedRowHandle
                Return
            End If
        Finally
            m_Updating = False
        End Try
    End Sub

End Class
