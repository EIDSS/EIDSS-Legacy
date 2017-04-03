Imports bv.winclient.Core
Imports System.Data
Imports DevExpress.XtraEditors.Controls
Imports bv.common.Enums
Imports bv.common.Resources
Imports System.Collections.Generic
Imports System.Linq
Imports bv.winclient.Localization
Imports bv.winclient.BasePanel
Imports EIDSS.model.Resources
Imports bv.common.win.Validators


Public Class CheckInPanel
    Inherits CaseSamplesPanel

    Friend WithEvents Label12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbRegisteredByPerson As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents colMaterialID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLocation As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colComment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDepartmentName As DevExpress.XtraGrid.Columns.GridColumn
    Protected WithEvents btnAccession As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BarcodeButton1 As bv.common.win.BarcodeButton
    Friend WithEvents cbDepartment As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cbLocation As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GroupBox7 As DevExpress.XtraEditors.GroupControl

    Public Const TableFiltered As String = "FilteredByDisease"
    Protected m_CanPrint As Boolean = True
    Protected m_CanSelectTest As Boolean
    Protected WithEvents chkFilterSamples As DevExpress.XtraEditors.CheckEdit
    Protected m_SurveillanceMode As Boolean = False
    Protected WithEvents btnSampleSearch As DevExpress.XtraEditors.SimpleButton
    Protected WithEvents lblSamplesSearch As DevExpress.XtraEditors.LabelControl
    Protected WithEvents txtSamplesSearchAdvanced As DevExpress.XtraEditors.TextEdit 'System.Windows.Forms.TextBox
    Protected WithEvents btnSelectTest As DevExpress.XtraEditors.SimpleButton
    Private CheckinDbService As SamplesCheckIn_DB
    Dim cbSampleTypeEditor As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Private m_SessionType As model.Enums.SessionType
    Friend Property SessionType() As model.Enums.SessionType
        Get
            Return m_SessionType
        End Get
        Set(ByVal value As model.Enums.SessionType)
            m_SessionType = value
            CheckinDbService.SessionType = value
        End Set

    End Property

    Public Sub New()
        MyBase.New()
        InitializeComponent()

        CType(Me.SamplesGrid.MainView, DevExpress.XtraGrid.Views.Grid.GridView).OptionsSelection.MultiSelect = True

        Me.UseParentDataset = True
        'Me.PermissionObject = model.Enums.EIDSSPermissionObject.AccessionIn1

        Try

            Me.colAccessionedDate.OptionsColumn.AllowEdit = True
            Me.colConditionReceived.OptionsColumn.AllowEdit = True
            Me.colSampleCondition.OptionsColumn.AllowEdit = True
            Me.colMaterialID.VisibleIndex = 3
            Me.colMaterialID.OptionsColumn.AllowEdit = True
            Me.SamplesGridView.Columns.Add(colMaterialID)
            Me.SamplesGridView.Columns.Add(colLocation)
            Me.SamplesGridView.Columns.Add(colComment)
            Me.SamplesGridView.Columns.Add(colDepartmentName)
            Me.CheckinDbService = New SamplesCheckIn_DB
            Me.DbService = CheckinDbService
            Me.grpSendToOffice.Visible = False

            ' Me.DbService = New SamplesCheckIn_DB
            m_CanPrint = model.Core.EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(model.Enums.EIDSSPermissionObject.Barcode))
            m_CanSelectTest = New StandardAccessPermissions(model.Enums.EIDSSPermissionObject.Test).CanInsert
            SamplesGrid.Height = chkFilterSamples.Top - SamplesGrid.Top - 8
            SamplesGrid.Width = SamplesGrid.Parent.Width - 16
            SamplesGridView.OptionsView.ColumnAutoWidth = True
            colTestsCount.Visible = True

            ShowNewButton = True
        Catch ex As Exception

        End Try
    End Sub

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CheckInPanel))
        Me.GroupBox7 = New DevExpress.XtraEditors.GroupControl()
        Me.cbRegisteredByPerson = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label12 = New DevExpress.XtraEditors.LabelControl()
        Me.colMaterialID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLocation = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbLocation = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colComment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDepartmentName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbDepartment = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.btnAccession = New DevExpress.XtraEditors.SimpleButton()
        Me.BarcodeButton1 = New bv.common.win.BarcodeButton()
        Me.chkFilterSamples = New DevExpress.XtraEditors.CheckEdit()
        Me.btnSampleSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.lblSamplesSearch = New DevExpress.XtraEditors.LabelControl()
        Me.txtSamplesSearchAdvanced = New DevExpress.XtraEditors.TextEdit()
        Me.btnSelectTest = New DevExpress.XtraEditors.SimpleButton()
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
        CType(Me.GroupBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        CType(Me.cbRegisteredByPerson.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDepartment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkFilterSamples.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSamplesSearchAdvanced.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbCondition
        '
        Me.cbCondition.Appearance.Options.UseFont = True
        Me.cbCondition.AppearanceDisabled.Options.UseFont = True
        Me.cbCondition.AppearanceDropDown.Options.UseFont = True
        Me.cbCondition.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbCondition.AppearanceFocused.Options.UseFont = True
        Me.cbCondition.AppearanceReadOnly.Options.UseFont = True
        '
        'cbAccessionDate
        '
        Me.cbAccessionDate.Appearance.Options.UseFont = True
        Me.cbAccessionDate.AppearanceDisabled.Options.UseFont = True
        Me.cbAccessionDate.AppearanceDropDown.Options.UseFont = True
        Me.cbAccessionDate.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbAccessionDate.AppearanceDropDownHeaderHighlight.Options.UseFont = True
        Me.cbAccessionDate.AppearanceDropDownHighlight.Options.UseFont = True
        Me.cbAccessionDate.AppearanceFocused.Options.UseFont = True
        Me.cbAccessionDate.AppearanceReadOnly.Options.UseFont = True
        Me.cbAccessionDate.AppearanceWeekNumber.Options.UseFont = True
        Me.cbAccessionDate.Mask.EditMask = resources.GetString("cbAccessionDate.Mask.EditMask")
        Me.cbAccessionDate.VistaTimeProperties.Appearance.Options.UseFont = True
        Me.cbAccessionDate.VistaTimeProperties.AppearanceDisabled.Options.UseFont = True
        Me.cbAccessionDate.VistaTimeProperties.AppearanceFocused.Options.UseFont = True
        Me.cbAccessionDate.VistaTimeProperties.AppearanceReadOnly.Options.UseFont = True
        Me.cbAccessionDate.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton()})
        '
        'grpSendToOffice
        '
        Me.grpSendToOffice.Appearance.Options.UseFont = True
        Me.grpSendToOffice.AppearanceCaption.Options.UseFont = True
        '
        'cbSendToOffice
        '
        Me.cbSendToOffice.Properties.Appearance.Options.UseFont = True
        Me.cbSendToOffice.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbSendToOffice.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbSendToOffice.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbSendToOffice.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbSendToOffice.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbSendToOffice.Properties.AutoHeight = CType(resources.GetObject("cbSendToOffice.Properties.AutoHeight"), Boolean)
        '
        'CollectedByGroup
        '
        Me.CollectedByGroup.Appearance.Options.UseFont = True
        Me.CollectedByGroup.AppearanceCaption.Options.UseFont = True
        resources.ApplyResources(Me.CollectedByGroup, "CollectedByGroup")
        '
        'cbCollectedByOrganization
        '
        Me.cbCollectedByOrganization.Properties.Appearance.Options.UseFont = True
        Me.cbCollectedByOrganization.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbCollectedByOrganization.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbCollectedByOrganization.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbCollectedByOrganization.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbCollectedByOrganization.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbCollectedByOrganization.Properties.AutoHeight = CType(resources.GetObject("cbCollectedByOrganization.Properties.AutoHeight"), Boolean)
        resources.ApplyResources(Me.cbCollectedByOrganization, "cbCollectedByOrganization")
        '
        'cbCollectedByPerson
        '
        Me.cbCollectedByPerson.Properties.Appearance.Options.UseFont = True
        Me.cbCollectedByPerson.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbCollectedByPerson.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbCollectedByPerson.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbCollectedByPerson.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbCollectedByPerson.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbCollectedByPerson.Properties.AutoHeight = CType(resources.GetObject("cbCollectedByPerson.Properties.AutoHeight"), Boolean)
        resources.ApplyResources(Me.cbCollectedByPerson, "cbCollectedByPerson")
        '
        'btnNewSpecimen
        '
        Me.btnNewSpecimen.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.btnNewSpecimen, "btnNewSpecimen")
        '
        'btnDeleteSpecimen
        '
        Me.btnDeleteSpecimen.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.btnDeleteSpecimen, "btnDeleteSpecimen")
        '
        'cbAnimalLookup
        '
        Me.cbAnimalLookup.Appearance.Options.UseFont = True
        Me.cbAnimalLookup.AppearanceDisabled.Options.UseFont = True
        Me.cbAnimalLookup.AppearanceDropDown.Options.UseFont = True
        Me.cbAnimalLookup.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbAnimalLookup.AppearanceFocused.Options.UseFont = True
        Me.cbAnimalLookup.AppearanceReadOnly.Options.UseFont = True
        '
        'cbSpecimenType
        '
        Me.cbSpecimenType.Appearance.Options.UseFont = True
        Me.cbSpecimenType.AppearanceDisabled.Options.UseFont = True
        Me.cbSpecimenType.AppearanceDropDown.Options.UseFont = True
        Me.cbSpecimenType.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbSpecimenType.AppearanceFocused.Options.UseFont = True
        Me.cbSpecimenType.AppearanceReadOnly.Options.UseFont = True
        '
        'pnSpecimenDetail
        '
        Me.pnSpecimenDetail.Appearance.BackColor = CType(resources.GetObject("pnSpecimenDetail.Appearance.BackColor"), System.Drawing.Color)
        Me.pnSpecimenDetail.Appearance.Options.UseBackColor = True
        Me.pnSpecimenDetail.Appearance.Options.UseFont = True
        Me.pnSpecimenDetail.AppearanceCaption.Options.UseFont = True
        Me.pnSpecimenDetail.Controls.Add(Me.GroupBox7)
        resources.ApplyResources(Me.pnSpecimenDetail, "pnSpecimenDetail")
        Me.pnSpecimenDetail.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.pnSpecimenDetail.LookAndFeel.UseDefaultLookAndFeel = False
        Me.pnSpecimenDetail.Controls.SetChildIndex(Me.grpSendToOffice, 0)
        Me.pnSpecimenDetail.Controls.SetChildIndex(Me.CollectedByGroup, 0)
        Me.pnSpecimenDetail.Controls.SetChildIndex(Me.GroupBox7, 0)
        '
        'NotesGroup
        '
        Me.NotesGroup.Appearance.BackColor = CType(resources.GetObject("NotesGroup.Appearance.BackColor"), System.Drawing.Color)
        Me.NotesGroup.Appearance.Options.UseBackColor = True
        Me.NotesGroup.Appearance.Options.UseFont = True
        Me.NotesGroup.AppearanceCaption.Options.UseFont = True
        resources.ApplyResources(Me.NotesGroup, "NotesGroup")
        Me.NotesGroup.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.NotesGroup.LookAndFeel.UseDefaultLookAndFeel = False
        '
        'SamplesGroup
        '
        Me.SamplesGroup.Appearance.BackColor = CType(resources.GetObject("SamplesGroup.Appearance.BackColor"), System.Drawing.Color)
        Me.SamplesGroup.Appearance.Options.UseBackColor = True
        Me.SamplesGroup.Appearance.Options.UseFont = True
        Me.SamplesGroup.AppearanceCaption.Options.UseFont = True
        Me.SamplesGroup.Controls.Add(Me.btnSelectTest)
        Me.SamplesGroup.Controls.Add(Me.lblSamplesSearch)
        Me.SamplesGroup.Controls.Add(Me.chkFilterSamples)
        Me.SamplesGroup.Controls.Add(Me.BarcodeButton1)
        Me.SamplesGroup.Controls.Add(Me.btnAccession)
        Me.SamplesGroup.Controls.Add(Me.txtSamplesSearchAdvanced)
        Me.SamplesGroup.Controls.Add(Me.btnSampleSearch)
        Me.SamplesGroup.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.SamplesGroup.LookAndFeel.UseDefaultLookAndFeel = False
        resources.ApplyResources(Me.SamplesGroup, "SamplesGroup")
        Me.SamplesGroup.Controls.SetChildIndex(Me.btnSampleSearch, 0)
        Me.SamplesGroup.Controls.SetChildIndex(Me.txtSamplesSearchAdvanced, 0)
        Me.SamplesGroup.Controls.SetChildIndex(Me.btnAccession, 0)
        Me.SamplesGroup.Controls.SetChildIndex(Me.BarcodeButton1, 0)
        Me.SamplesGroup.Controls.SetChildIndex(Me.chkFilterSamples, 0)
        Me.SamplesGroup.Controls.SetChildIndex(Me.btnNewSpecimen, 0)
        Me.SamplesGroup.Controls.SetChildIndex(Me.btnDeleteSpecimen, 0)
        Me.SamplesGroup.Controls.SetChildIndex(Me.lblSamplesSearch, 0)
        Me.SamplesGroup.Controls.SetChildIndex(Me.btnSelectTest, 0)
        '
        'cbSpecies
        '
        Me.cbSpecies.Appearance.Options.UseFont = True
        Me.cbSpecies.AppearanceDisabled.Options.UseFont = True
        Me.cbSpecies.AppearanceDropDown.Options.UseFont = True
        Me.cbSpecies.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbSpecies.AppearanceFocused.Options.UseFont = True
        Me.cbSpecies.AppearanceReadOnly.Options.UseFont = True
        '
        'cbVectorID
        '
        Me.cbVectorID.Appearance.Options.UseFont = True
        Me.cbVectorID.AppearanceDisabled.Options.UseFont = True
        Me.cbVectorID.AppearanceDropDown.Options.UseFont = True
        Me.cbVectorID.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbVectorID.AppearanceFocused.Options.UseFont = True
        Me.cbVectorID.AppearanceReadOnly.Options.UseFont = True
        '
        'cbVectorType
        '
        Me.cbVectorType.Appearance.Options.UseFont = True
        Me.cbVectorType.AppearanceDisabled.Options.UseFont = True
        Me.cbVectorType.AppearanceDropDown.Options.UseFont = True
        Me.cbVectorType.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbVectorType.AppearanceFocused.Options.UseFont = True
        Me.cbVectorType.AppearanceReadOnly.Options.UseFont = True
        '
        'dtCollectionDate
        '
        Me.dtCollectionDate.Appearance.Options.UseFont = True
        Me.dtCollectionDate.AppearanceDisabled.Options.UseFont = True
        Me.dtCollectionDate.AppearanceDropDown.Options.UseFont = True
        Me.dtCollectionDate.AppearanceDropDownHeader.Options.UseFont = True
        Me.dtCollectionDate.AppearanceDropDownHeaderHighlight.Options.UseFont = True
        Me.dtCollectionDate.AppearanceDropDownHighlight.Options.UseFont = True
        Me.dtCollectionDate.AppearanceFocused.Options.UseFont = True
        Me.dtCollectionDate.AppearanceReadOnly.Options.UseFont = True
        Me.dtCollectionDate.AppearanceWeekNumber.Options.UseFont = True
        Me.dtCollectionDate.VistaTimeProperties.Appearance.Options.UseFont = True
        Me.dtCollectionDate.VistaTimeProperties.AppearanceDisabled.Options.UseFont = True
        Me.dtCollectionDate.VistaTimeProperties.AppearanceFocused.Options.UseFont = True
        Me.dtCollectionDate.VistaTimeProperties.AppearanceReadOnly.Options.UseFont = True
        Me.dtCollectionDate.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton()})
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(CheckInPanel), resources)
        'Form Is Localizable: True
        '
        'GroupBox7
        '
        resources.ApplyResources(Me.GroupBox7, "GroupBox7")
        Me.GroupBox7.AppearanceCaption.Options.UseFont = True
        Me.GroupBox7.Controls.Add(Me.cbRegisteredByPerson)
        Me.GroupBox7.Controls.Add(Me.Label12)
        Me.GroupBox7.Name = "GroupBox7"
        '
        'cbRegisteredByPerson
        '
        resources.ApplyResources(Me.cbRegisteredByPerson, "cbRegisteredByPerson")
        Me.cbRegisteredByPerson.Name = "cbRegisteredByPerson"
        Me.cbRegisteredByPerson.Properties.AutoHeight = CType(resources.GetObject("cbRegisteredByPerson.Properties.AutoHeight"), Boolean)
        Me.cbRegisteredByPerson.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbRegisteredByPerson.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbRegisteredByPerson.Properties.NullText = resources.GetString("cbRegisteredByPerson.Properties.NullText")
        Me.cbRegisteredByPerson.Tag = "{M}"
        '
        'Label12
        '
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.Name = "Label12"
        '
        'colMaterialID
        '
        resources.ApplyResources(Me.colMaterialID, "colMaterialID")
        Me.colMaterialID.FieldName = "strBarcode"
        Me.colMaterialID.Name = "colMaterialID"
        '
        'colLocation
        '
        resources.ApplyResources(Me.colLocation, "colLocation")
        Me.colLocation.ColumnEdit = Me.cbLocation
        Me.colLocation.FieldName = "idfSubdivision"
        Me.colLocation.Name = "colLocation"
        '
        'cbLocation
        '
        Me.cbLocation.Name = "cbLocation"
        '
        'colComment
        '
        resources.ApplyResources(Me.colComment, "colComment")
        Me.colComment.ColumnEdit = Me.memoEdit
        Me.colComment.FieldName = "strNote"
        Me.colComment.Name = "colComment"
        '
        'colDepartmentName
        '
        resources.ApplyResources(Me.colDepartmentName, "colDepartmentName")
        Me.colDepartmentName.ColumnEdit = Me.cbDepartment
        Me.colDepartmentName.FieldName = "idfInDepartment"
        Me.colDepartmentName.Name = "colDepartmentName"
        '
        'cbDepartment
        '
        resources.ApplyResources(Me.cbDepartment, "cbDepartment")
        Me.cbDepartment.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDepartment.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbDepartment.Name = "cbDepartment"
        '
        'btnAccession
        '
        resources.ApplyResources(Me.btnAccession, "btnAccession")
        Me.btnAccession.Image = Global.EIDSS.My.Resources.Resources.Sample_Accession__small_
        Me.btnAccession.Name = "btnAccession"
        '
        'BarcodeButton1
        '
        resources.ApplyResources(Me.BarcodeButton1, "BarcodeButton1")
        Me.BarcodeButton1.Name = "BarcodeButton1"
        '
        'chkFilterSamples
        '
        resources.ApplyResources(Me.chkFilterSamples, "chkFilterSamples")
        Me.chkFilterSamples.Name = "chkFilterSamples"
        Me.chkFilterSamples.Properties.Appearance.Options.UseTextOptions = True
        Me.chkFilterSamples.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkFilterSamples.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.chkFilterSamples.Properties.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkFilterSamples.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.chkFilterSamples.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkFilterSamples.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.chkFilterSamples.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkFilterSamples.Properties.Caption = resources.GetString("chkFilterSamples.Properties.Caption")
        '
        'btnSampleSearch
        '
        Me.btnSampleSearch.Image = Global.EIDSS.My.Resources.Resources.Search
        resources.ApplyResources(Me.btnSampleSearch, "btnSampleSearch")
        Me.btnSampleSearch.Name = "btnSampleSearch"
        Me.btnSampleSearch.Tag = "{Immovable}"
        '
        'lblSamplesSearch
        '
        Me.lblSamplesSearch.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lblSamplesSearch.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        resources.ApplyResources(Me.lblSamplesSearch, "lblSamplesSearch")
        Me.lblSamplesSearch.Name = "lblSamplesSearch"
        '
        'txtSamplesSearchAdvanced
        '
        resources.ApplyResources(Me.txtSamplesSearchAdvanced, "txtSamplesSearchAdvanced")
        Me.txtSamplesSearchAdvanced.Name = "txtSamplesSearchAdvanced"
        '
        'btnSelectTest
        '
        resources.ApplyResources(Me.btnSelectTest, "btnSelectTest")
        Me.btnSelectTest.Name = "btnSelectTest"
        '
        'CheckInPanel
        '
        Me.Appearance.Options.UseFont = True
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.Name = "CheckInPanel"
        resources.ApplyResources(Me, "$this")
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
        CType(Me.GroupBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        CType(Me.cbRegisteredByPerson.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbLocation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDepartment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkFilterSamples.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSamplesSearchAdvanced.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    'Public Sub Bind()
    '    DefineBinding()
    'End Sub


    Protected Overrides Sub DefineBinding()
        If baseDataSet.Tables.Count = 0 Then Exit Sub


        Dim caseRow As DataRow = baseDataSet.Tables(CaseSamples_Db.TableCaseActivity).Rows(0)
        If Not Utils.IsEmpty(caseRow("idfVectorSurveillanceSession")) Then
            HACode = HACode.Vector
            chkFilterSamples.Visible = False
        ElseIf Not Utils.IsEmpty(caseRow("idfMonitoringSession")) Then
            HACode = HACode.Livestock
        Else
            If Not Utils.IsEmpty(caseRow("idfsCaseType")) Then
                Dim type As Long = CType(caseRow("idfsCaseType"), Long)
                If type = CaseType.Avian Then
                    HACode = HACode.Avian
                ElseIf type = CaseType.Livestock Then
                    HACode = HACode.Livestock
                ElseIf type = CaseType.Human Then
                    HACode = HACode.Human
                End If
            End If
        End If


        Core.LookupBinder.BindDepartmentRepositoryLookup(cbDepartment)

        LabUtils.BindFreezerLocation(cbLocation)
        If (HACode = HACode.Vector) Then
            CasePartyList = New DataView(baseDataSet.Tables("VectorPartyList"))
        Else
            CasePartyList = New DataView(baseDataSet.Tables("PartyList"))
        End If
        If (HACode = HACode.Human) Then
            If (baseDataSet.Tables(CaseSamples_Db.TableCaseActivity).Rows.Count > 0) Then
                DefaultPartyID = baseDataSet.Tables(CaseSamples_Db.TableCaseActivity).Rows(0)("idfHuman")
            End If
        End If
        MyBase.DefineBinding()
        'Bind detail panel controls to grid datasource to use current view row as binding source
        'it mast be binded after MyBase.DefineBinding 
        Core.LookupBinder.BindPersonLookup(cbRegisteredByPerson, m_SamplesView, "idfAccesionByPerson", False)
        ShowNewButton = True
        ArrangeButtons(SamplesGroup, btnAccession.Top, "")
        UpdateButtons()
        AddHandler SamplesGridView.CustomColumnDisplayText, AddressOf SamplesGridView_CustomColumnDisplayText
        AddHandler SamplesGridView.CustomRowCellEditForEditing, AddressOf SamplesGridView_CustomRowCellEditForEditing
        AddHandler SamplesGridView.SelectionChanged, AddressOf SamplesGridView_SelectionChanged

        eventManager.AttachDataHandler("CaseSamples.idfsAccessionCondition", AddressOf SampleConditionChanged)

    End Sub

    Private Sub SampleConditionChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        UpdateButtons()
    End Sub

    Overridable Sub btnAccession_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAccession.Click

        Dim selectedRows As Integer() = SamplesGridView.GetSelectedRows()
        If selectedRows Is Nothing OrElse selectedRows.Length = 0 Then
            Return
        End If
        If selectedRows.Length > 1 AndAlso Not WinUtils.ConfirmMessage(String.Format(EidssMessages.Get("msgMultipleSamplesAccession", "{0} samples will be accessioned!"), selectedRows.Length), BvMessages.Get("Confirmation")) Then
            Return
        End If
        For Each rowHandle As Integer In selectedRows

            If rowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then Exit Sub
            Dim data As DataRow = SamplesGridView.GetDataRow(rowHandle)
            If Utils.Str(data("Used")) = "1" Then Exit Sub

            Dim id As Long = CLng(data("idfMaterial"))

            If CheckForExist(id) Then
                AccessionRow(SamplesGridView.GetDataRow(rowHandle))
                Core.LookupBinder.SetPersonFilter(cbRegisteredByPerson)
            Else
                ErrorForm.ShowMessage("msgCantAccessSample", "The sample can't be accessed, because it was deleted")
            End If

        Next
        UpdateButtons()
    End Sub

    Private Function CheckForExist(ByVal id As Long) As Boolean

        Dim sampleCheck As SamplesCheckIn_DB = New SamplesCheckIn_DB()
        Return sampleCheck.CheckForExist(id)

    End Function

    Private Sub AccessionRow(ByRef row As DataRow)

        row("strBarcode") = NumberingService.GetNextNumber(NumberingObject.Sample, DbService.Connection, Nothing)
        row("datAccession") = DateTime.Now
        row("Used") = 1 ' dummy, just to mark sample as accessioned
        row("idfsAccessionCondition") = AccessionCondition.AcceptedGood
        row("strTests") = "0"

        row("idfAccesionByPerson") = model.Core.EidssUserContext.User.EmployeeID
    End Sub



    Public Overrides Function IsCurrentSpecimenRowValid(Optional ByVal index As Integer = -1, Optional ByVal showError As Boolean = True) As Boolean
        If index = -1 Then index = SamplesGridView.FocusedRowHandle
        If index < 0 Then Return True
        Dim row As DataRow = SamplesGridView.GetDataRow(index)

        If row Is Nothing Then Return True

        Dim isValid As Boolean = MyBase.IsCurrentSpecimenRowValid(index, showError)
        If (isValid = False) Then Return False
        If Utils.Str(row("Used")) = "1" AndAlso (Utils.IsEmpty(row("datAccession"))) Then
            If showError Then
                Dim msg As String = String.Format(BvMessages.Get("ErrMandatoryFieldRequired", "The field {0} is mandatory. You must enter data to this field before form saving"), SamplesGridView.Columns("datAccession").Caption)
                ErrorForm.ShowWarningDirect(msg)
            End If
            Return False
        End If
        Dim condition As Object = row("idfsAccessionCondition")
        If Utils.IsEmpty(condition) = False AndAlso (condition.ToString() = AccessionCondition.AcceptedPoor.ToString("d") Or condition.ToString() = AccessionCondition.Rejected.ToString("d")) Then
            If Utils.Str(row("strCondition")).Trim().Length = 0 Then
                SamplesGridView.FocusedColumn = colSampleCondition
                If showError Then
                    Dim msg As String = String.Format(EidssMessages.Get("ErrSampleConditionRequired", "Please enter a comment describing why the {0} is identified as ""{1}"""), colConditionReceived.Caption, SamplesGridView.GetRowCellDisplayText(index, colConditionReceived))
                    ErrorForm.ShowWarningDirect(msg)
                End If
                Return False
            End If
        End If
        If Utils.Str(condition) = AccessionCondition.AcceptedGood.ToString("d") Or Utils.Str(condition) = AccessionCondition.AcceptedPoor.ToString("d") Then
            If Utils.Str(row("strBarcode")).Length = 0 Then
                If showError Then
                    Dim msg As String = String.Format(BvMessages.Get("ErrMandatoryFieldRequired", "The field {0} is mandatory. You must enter data to this field before form saving"), SamplesGridView.Columns("strBarcode").Caption)
                    ErrorForm.ShowErrorDirect(msg)
                End If
                Return False
            End If

            If row.RowState = DataRowState.Added Then
                Using sampleCheck As SamplesCheckIn_DB = New SamplesCheckIn_DB()
                    If sampleCheck.CheckBarcodeForExist(Utils.Str(row("strBarcode"))) = True Then
                        If showError Then
                            Dim msg As String = String.Format(BvMessages.Get("ErrExistingBarcode", "Sample with Lab Sample ID '{0}' already exists in the system. Please enter unique Lab Sample ID value."), Utils.Str(row("strBarcode")))
                            ErrorForm.ShowWarningDirect(msg)
                        End If
                        Return False
                    End If
                End Using
            End If

        End If

        Return isValid 'lower is an old code

    End Function

    Private Sub CheckInPanel_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        ArrangeButtons(SamplesGroup, btnAccession.Top, "")
    End Sub
    Private Sub SamplesCheckIn_OnAfterPost(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.OnAfterPost
        ShowSampleDetails(SamplesGridView.FocusedRowHandle)
    End Sub



    Public Overrides Sub UpdateButtons()
        If Enabled = False Then Exit Sub
        Dim row As DataRow = SamplesGridView.GetDataRow(SamplesGridView.FocusedRowHandle)
        Dim specimenSelected As Boolean = Not row Is Nothing
        btnDeleteSpecimen.Enabled = Not [ReadOnly] AndAlso specimenSelected AndAlso row.RowState = DataRowState.Added
        'btnSelectTest.Enabled = Not [ReadOnly] AndAlso specimenSelected AndAlso m_CanSelectTest

        pnSpecimenDetail.Enabled = specimenSelected
        SetMultiSelectionButtonsState()
        If HACode = HACode.Human Then
            btnNewSpecimen.Enabled = Not [ReadOnly] AndAlso IsCurrentSpecimenRowValid(, False) AndAlso New StandardAccessPermissions(model.Enums.EIDSSPermissionObject.HumanCase).CanSelect 'CanUpdate
        ElseIf (HACode And HACode.Avian And HACode.Livestock) <> 0 AndAlso SessionType = model.Enums.SessionType.None Then
            btnNewSpecimen.Enabled = Not [ReadOnly] AndAlso IsCurrentSpecimenRowValid(, False) AndAlso New StandardAccessPermissions(model.Enums.EIDSSPermissionObject.VetCase).CanSelect 'CanUpdate
        ElseIf (HACode And HACode.Avian And HACode.Livestock) <> 0 AndAlso SessionType = model.Enums.SessionType.AsSession Then
            btnNewSpecimen.Enabled = Not [ReadOnly] AndAlso IsCurrentSpecimenRowValid(, False) AndAlso New StandardAccessPermissions(model.Enums.EIDSSPermissionObject.MonitoringSession).CanSelect 'CanUpdate
        ElseIf (HACode And HACode.Vector) <> 0 AndAlso SessionType = model.Enums.SessionType.VsSession Then
            btnNewSpecimen.Enabled = Not [ReadOnly] AndAlso IsCurrentSpecimenRowValid(, False) AndAlso New StandardAccessPermissions(model.Enums.EIDSSPermissionObject.VsSession).CanSelect 'CanUpdate
        End If
        BarcodeButton1.Enabled = Not [ReadOnly] AndAlso m_CanPrint AndAlso specimenSelected AndAlso Not Utils.IsEmpty(row("strBarcode"))
    End Sub
    Public Overrides Function CreateNewRecord() As DataRow
        Dim row As DataRow = MyBase.CreateNewRecord()
        AccessionRow(row)
        UpdateButtons()
        Return row
    End Function

    Protected Function GetCondition(ByRef row As DataRow) As Long
        Dim condition As Object = row("idfsAccessionCondition")
        If CLng(AccessionCondition.AcceptedGood).Equals(condition) Then
            Return AccessionCondition.AcceptedGood
        ElseIf CLng(AccessionCondition.AcceptedPoor).Equals(condition) Then
            Return AccessionCondition.AcceptedPoor
        Else
            Return AccessionCondition.Rejected
        End If
    End Function

    Protected Overrides Function ShowEditor(ByVal row As DataRow) As Boolean
        If row.RowState <> DataRowState.Added AndAlso row.RowState <> DataRowState.Modified Then Return False
        Dim col As DevExpress.XtraGrid.Columns.GridColumn = SamplesGridView.FocusedColumn
        Dim condition As Long = GetCondition(row)
        If (col Is colLocation OrElse _
            col Is colComment OrElse _
            col Is colTestsCount OrElse _
            col Is colMaterialID OrElse _
            col Is colDepartmentName) AndAlso _
            CLng(AccessionCondition.Rejected).Equals(condition) Then Return False
        If (col Is colConditionReceived AndAlso row.Table.Columns.Contains("strTests") _
            AndAlso Not Utils.IsEmpty(row("strTests")) AndAlso Utils.Str(row("strTests")) <> "0") Then
            Return False
        End If
        If row.RowState = DataRowState.Added Then
            Return True
        End If
        If row.RowState = DataRowState.Modified AndAlso _
            Not (col Is colSpecimenType) AndAlso _
            Not (col Is colSpecimenID) AndAlso _
            Not (col Is colAnimal) AndAlso _
            Not (col Is colSpecies) AndAlso _
            Not (col Is colVectorID) AndAlso _
            Not (col Is colVectorType) AndAlso _
            Not (col Is colCollectionDate) Then
            Return True
        End If
        Return False
    End Function



    Public Overrides Sub ShowSampleDetails(ByVal sampleIndex As Integer)
        MyBase.ShowSampleDetails(sampleIndex)
        Dim row As DataRow = SamplesGridView.GetDataRow(sampleIndex)
        Dim added As Boolean = Not (row Is Nothing) AndAlso row.RowState = DataRowState.Added
        SetLookupReadOnly(cbRegisteredByPerson, added)
        SetLookupReadOnly(cbCollectedByOrganization, added)
        SetLookupReadOnly(cbCollectedByPerson, added)
    End Sub

    Private Sub SamplesGridView_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) 'Handles SamplesGridView.CustomColumnDisplayText
        If WinUtils.IsComponentInDesignMode(Me) Then
            Return
        End If
        Dim row As DataRow = CType(SamplesGridView.DataSource, DataView)(e.ListSourceRowIndex).Row
        'Dim row As DataRow = SamplesGridView.GetDataRow(e.RowHandle)
        If row Is Nothing Then
            Return
        End If
        If GetCondition(row) = AccessionCondition.Rejected AndAlso ( _
            e.Column Is colLocation OrElse _
            e.Column Is colComment OrElse _
            e.Column Is colTestsCount OrElse _
            e.Column Is colDepartmentName OrElse _
            e.Column Is colMaterialID) Then e.DisplayText = ""
    End Sub

    Private Sub SamplesGridView_CustomRowCellEditForEditing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs)

        cbSampleTypeEditor.DataSource = cbSpecimenType.DataSource

        If Not (e.Column Is colSpecimenType) Then Exit Sub
        Dim filter As String
        If (HACode And HACode.Vector) <> 0 Then
            filter = GetSampleFilterForVector(SamplesGridView.GetFocusedDataRow)
        ElseIf chkFilterSamples.Checked = True Then
            filter = GetSampleFilterForDiagnosis(SamplesGridView.GetFocusedDataRow)
        Else
            Exit Sub
        End If

        Dim mainDataView As DataView = CType(cbSpecimenType.DataSource, DataView).Table.Copy().DefaultView '.Table.Rows(0)("idfsReference")
        mainDataView.RowFilter = filter
        mainDataView.Sort = "idfsReference"
        cbSampleTypeEditor.NullText = ""

        cbSampleTypeEditor.DataSource = mainDataView
        cbSampleTypeEditor.DisplayMember = "name"

        cbSampleTypeEditor.ValueMember = "idfsReference"
        Dim column As LookUpColumnInfo = cbSampleTypeEditor.Columns.CreateColumn()
        column.FieldName = "name"
        column.Caption = EidssMessages.Get("colName")

        cbSampleTypeEditor.Columns.Clear()
        cbSampleTypeEditor.Columns.Add(column)

        e.RepositoryItem = cbSampleTypeEditor
    End Sub

    Private Function GetSampleFilterForVector(row As DataRow) As String
        If (row Is Nothing) Then
            Return "0=1"
        End If
        Dim vectorType As Object = row("idfsVectorType")
        If Utils.IsEmpty(vectorType) Then
            Return "0=1"
        End If
        Dim rows As DataRow() = baseDataSet.Tables("SampleToVectorType").Select(String.Format("idfsVectorType = {0}", vectorType))
        Dim filter As String = ""
        For Each r As DataRow In rows
            If (filter = "") Then
                filter = r("idfsSampleType").ToString
            Else
                filter += ", " + r("idfsSampleType").ToString
            End If
        Next
        If filter <> "" Then
            Return String.Format("idfsReference in ({0})", filter)
        Else
            Return "0=1"
        End If
    End Function

    Private Function GetSampleFilterForDiagnosis(row As DataRow) As String
        If (row Is Nothing) Then
            Return "0=1"
        End If
        Dim speciesType As Long = 0
        If (Not row("idfsSpeciesType") Is DBNull.Value) Then
            speciesType = CLng(row("idfsSpeciesType"))
        End If
        Dim filteredDataTable As DataTable = CheckinDbService.GetFilteredCase(speciesType)
        If (filteredDataTable.Rows.Count = 0) Then
            Return "0=1"
        End If
        Dim filter As String = ""

        For Each diag As DataRow In filteredDataTable.Rows
            If filter.Length > 0 Then filter = filter + " OR "
            filter = filter + "idfsReference=" + diag(0).ToString()
        Next
        Return filter
    End Function


    Protected Overridable Sub SearchByBarcode(ByVal barCode As String)
        If Utils.IsEmpty(barCode) Then
            Return
        End If
        If LockHandler() Then
            Try
                Dim view As DataView
                If TypeOf (SamplesGrid.DataSource) Is DataView Then
                    view = CType(SamplesGrid.DataSource, DataView)
                Else
                    view = CType(SamplesGrid.DataSource, DataTable).DefaultView
                End If

                If Not (view.Table.Rows.Count = 0) Then

                    Dim rows As DataRow() = view.Table.Select(String.Format("strFieldBarcode = '{0}'", barCode))

                    If (rows.Length > 0) Then

                        Dim view2 As DevExpress.XtraGrid.Views.Grid.GridView = CType(SamplesGrid.Views(0), DevExpress.XtraGrid.Views.Grid.GridView)
                        Dim d As DataRow = rows(0)
                        DxControlsHelper.SetRowHandleForDataRow(view2, d, "idfMaterial")

                        view2.ClearSelection()

                        view2.SelectRow(view2.FocusedRowHandle)

                    Else
                        MessageForm.Show(EidssMessages.Get("ErrLocalFieldSampleIDNotFound"))
                    End If

                End If

            Catch ex As Exception
                Throw
            Finally
                UnlockHandler()
            End Try
        End If

    End Sub
    Private Sub btnSampleSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSampleSearch.Click
        SearchByBarcode(txtSamplesSearchAdvanced.Text)
    End Sub

    Private Sub btnSelectTest_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSelectTest.Click
        If (RootBaseForm.Post(PostType.FinalPosting) = False) Then
            Return
        End If
        If LockHandler() Then
            Try
                Dim arr As Integer() = CType(SamplesGrid.MainView, DevExpress.XtraGrid.Views.Grid.GridView).GetSelectedRows()
                Dim rowList As List(Of DataRow) = New List(Of DataRow)

                For Each rowIndex As Integer In arr
                    If rowIndex = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then Exit Sub
                    Dim dataRow As DataRow = SamplesGridView.GetDataRow(rowIndex)
                    rowList.Add(dataRow)
                Next
                Dim dlg As AssignTestsList = New AssignTestsList
                Dim rows As Object = rowList
                If rows Is Nothing Then Exit Sub
                BaseFormManager.ShowModal(dlg, FindForm, rows, Nothing, Nothing)
                UpdateButtons()
                Dim testsCount As Integer
                For Each rowIndex As Integer In arr
                    If rowIndex = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then Exit Sub
                    Dim dataRow As DataRow = SamplesGridView.GetDataRow(rowIndex)
                    testsCount = SamplesCheckIn_DB.GetTestCount(CLng(dataRow("idfMaterial")))
                    dataRow("strTests") = testsCount.ToString()
                    dataRow.EndEdit()
                Next
            Catch ex As Exception
                Throw
            Finally
                UnlockHandler()
            End Try
        End If


    End Sub


    Private Sub SamplesGridView_SelectionChanged(ByVal sender As System.Object, ByVal e As EventArgs)
        SetMultiSelectionButtonsState()
    End Sub

    Private Sub txtScannedBarcode_KeyDown(ByVal sender As Object, ByVal e As Windows.Forms.KeyEventArgs) Handles txtSamplesSearchAdvanced.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            SearchByBarcode(txtSamplesSearchAdvanced.Text)
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub


    Private Sub SetMultiSelectionButtonsState()
        Dim selectedRows As Integer() = SamplesGridView.GetSelectedRows()
        If selectedRows Is Nothing Then
            btnAccession.Enabled = False
            btnSelectTest.Enabled = False
        Else
            Dim enableAccession As Boolean = (From rowHandle In selectedRows _
                                              Select SamplesGridView.GetDataRow(rowHandle)).All(Function(row) Not row Is Nothing AndAlso Utils.Str(row("Used")) <> "1")
            btnAccession.Enabled = Not [ReadOnly] AndAlso enableAccession
            Dim enableSelectTest As Boolean = Not (From rowHandle In selectedRows _
                                                   Let selectedRow = SamplesGridView.GetDataRow(rowHandle) _
                                                   Where Not (Utils.Str(selectedRow("Used")) = "1" AndAlso _
                                                    IsCurrentSpecimenRowValid(rowHandle, False) AndAlso _
                                                    Not CLng(AccessionCondition.Rejected).Equals(selectedRow("idfsAccessionCondition")))).Any()
            btnSelectTest.Enabled = Not [ReadOnly] AndAlso enableSelectTest AndAlso m_CanSelectTest
        End If
    End Sub

    Protected Overrides Sub RegisterValidators()
        If baseDataSet.Tables.Count = 0 Then Exit Sub
        If Validators.Count > 0 Then Exit Sub

        MyBase.RegisterValidators()
        Dim rootDate As DateChainValidator
        Dim item As ChainValidator(Of DateTime)

        If (HACode And HACode.Human) = HACode.Human Then
            rootDate = New DateChainValidator(Me, Nothing, CaseSamples_Db.TableCaseActivity, "datDateOfBirth", EidssFields.Get("HumanCase.SearchPanel.datDateofBirth"), , , , , , AddressOf UpdateButtons)
            item = rootDate.AddChild(New DateChainValidator(Me, SamplesGrid, CaseSamples_Db.TableSamples, "datFieldCollectionDate", colCollectionDate.Caption, , , , True, , AddressOf UpdateButtons))
            item = item.AddChild(New DateChainValidator(Me, SamplesGrid, CaseSamples_Db.TableSamples, "datFieldSentDate", EidssFields.Get("datFieldSentDate"), , , , True, , AddressOf UpdateButtons))
            item.AddChild(New DateChainValidator(Me, SamplesGrid, CaseSamples_Db.TableSamples, "datAccession", colAccessionedDate.Caption, , , , True, , AddressOf UpdateButtons))
        Else
            rootDate = New DateChainValidator(Me, SamplesGrid, CaseSamples_Db.TableSamples, "datFieldCollectionDate", colCollectionDate.Caption, , , , True, , AddressOf UpdateButtons)
            rootDate.AddChild(New DateChainValidator(Me, SamplesGrid, CaseSamples_Db.TableSamples, "datAccession", colAccessionedDate.Caption, , , , True, , AddressOf UpdateButtons))
        End If
        rootDate.RegisterValidator(Me, True)
    End Sub

    Private Sub CheckInPanel_VisibleChanged(sender As Object, e As System.EventArgs) Handles Me.VisibleChanged
        If Visible AndAlso colTestsCount.Visible Then
            Me.colTestsCount.VisibleIndex = SamplesGridView.VisibleColumns.Count
        End If
    End Sub
End Class


