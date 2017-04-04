Imports System.ComponentModel
Imports EIDSS.model.Core
Imports System.Globalization
Imports bv.model.BLToolkit
Imports bv.common.db
Imports bv.winclient.Core
Imports EIDSS.Enums
Imports bv.common.Configuration
Imports bv.winclient.BasePanel
Imports System.Collections.Generic
Imports DevExpress.XtraEditors.Controls
Imports EIDSS.model.Resources
Imports bv.common.Resources
Imports EIDSS.model.Enums
Imports bv.model.Model.Core
Imports EIDSS.winclient.Human
Imports EIDSS.model.Schema
Imports DevExpress.XtraEditors
Imports bv.winclient.Layout
Imports bv.common.Enums
Imports bv.common.win.Validators
Imports bv.winclient.Core.TranslationTool
Imports bv.winclient.Localization
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Base

Public Class HumanCaseDetail

    Inherits BaseDetailForm

    Dim HumanCaseDbService As HumanCase_DB

    Private m_FocusOnFirstPage As Boolean = True
    Private m_RefreshNavigator As Boolean = False
    Private bFirstInit As Boolean = True
    Dim ClickDuplicateSearch As Boolean = False
    Dim OkToUpdateDOBAndAge As Boolean = True
    Dim OkToChangeHospStatus As Boolean = True
    Dim OkToChangeAge As Boolean

    Private m_DiagID As Long = -1
    Private m_strInitDiagID As Long = -1
    Private CSObsInSearchMode As Long = 1L
    Private EpiObsInSearchMode As Long = 2L
    Private CaseTestsPanelIDInSearchMode As Object = Guid.NewGuid

    Protected dtGeoLocationName As DataTable
    Friend WithEvents lbCaseStatus As System.Windows.Forms.Label
    Friend WithEvents cbCaseStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents dtFirstAntimicrobialAdminDate As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents txtContactName As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Private dsLocation As DataSet = Nothing
    Friend WithEvents lbTestsConducted As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbTestsConducted As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents chkForeignAddress As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cbReceivedByName As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblReceivedByName As System.Windows.Forms.Label
    Friend WithEvents cbSentByName As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblSentByName As System.Windows.Forms.Label
    Friend WithEvents cbEpidemiologistName As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents dtReportingDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents dtInvestigationStartDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents colComments As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtContactComments As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents chkUseSameAddress As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cbCurrentPatientLocation As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cbEnteredByOrganization As DevExpress.XtraEditors.LookUpEdit
    Private WithEvents cbEnteredByName As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lbEnteredByOrganization As System.Windows.Forms.Label
    Friend WithEvents lbEnteredByName As System.Windows.Forms.Label
    Private WithEvents lbEnteredBy As System.Windows.Forms.Label
    Friend WithEvents txtPersonalID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbPersonalID As System.Windows.Forms.Label
    Friend WithEvents lbPersonalIdType As System.Windows.Forms.Label
    Friend WithEvents txtPersonalIdType As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbFinalCaseClassificationDate As System.Windows.Forms.Label
    Friend WithEvents dtFinalCaseClassificationDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cbGeoLocation As EIDSS.LocationLookup
    'Protected WithEvents SamplesGridView As DevExpress.XtraGrid.Views.Grid.GridView

    Dim cbSampleTypeEditor As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit

#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()
        DebugTimer.Start("human case constructor")
        StopBR = True
        'This call is required by the Windows Form Designer.
        DebugTimer.Start("human case InitializeComponent")
        InitializeComponent()
        DebugTimer.Stop()
        If WinUtils.IsComponentInDesignMode(Me) Then
            Return
        End If
        'Add any initialization after the InitializeComponent() call
        'IDEA5967
        'IDEA5968
        'If EidssSiteContext.Instance.CountryID = CLng(Country.Azerbaijan) Then
        '    dtDiagnosisDate.Tag = "{M}"
        '    PatientInfo.txtAge.Tag = "{M}"
        '    PatientInfo.cbAgeUnits.Tag = "{M}"
        'End If
        HumanCaseDbService = New HumanCase_DB
        AuditObject = New AuditObject(EIDSSAuditObject.daoHumanCase, AuditTable.tlbHumanCase)
        Me.PermissionObject = EIDSS.model.Enums.EIDSSPermissionObject.HumanCase

        If Not EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.UpdatePermission( _
                                                EIDSS.model.Enums.EIDSSPermissionObject.HumanCase)) Then
            Me.cbCaseStatus.Tag = Me.cbCaseStatus.Tag.ToString().Replace("{alwayseditable}", "")
            Me.cbCaseStatus.Enabled = False
        End If
        DbService = HumanCaseDbService
        StopBR = False
        RegisterChildObject(HumanCaseSamplesPanel1, RelatedPostOrder.PostLast)
        RegisterChildObject(CaseTestsPanel1, RelatedPostOrder.PostLast)
        HumanCaseSamplesPanel1.HACode = HACode.Human
        'HumanCaseSamplesPanel1.ValidateDate = AddressOf Check_BR
        HumanCaseSamplesPanel1.RelatedTestsPanel = CaseTestsPanel1
        CaseTestsPanel1.HACode = HACode.Human

        RegisterChildObject(Me.cbGeoLocation, RelatedPostOrder.PostFirst)
        If (Not IsSimplifiedMode) Then
            Me.RegisterChildObject(lpPermanentAddress, RelatedPostOrder.PostFirst)
            Me.RegisterChildObject(FFClinicalSigns, RelatedPostOrder.PostLast)
            Me.RegisterChildObject(ffEpiInvestigations, RelatedPostOrder.PostLast)
        End If
        Me.RegisterChildObject(PatientInfo, RelatedPostOrder.PostFirst)

        FFClinicalSigns.DynamicParameterEnabled = True
        chkForeignAddress.Left = lblPermanentAddress.Left + lblPermanentAddress.Width + 16
        chkUseSameAddress.Left = chkForeignAddress.Left + chkForeignAddress.Width + 16
        chkUseSameAddress.Width = gpDemographicInfo.Width - chkUseSameAddress.Left - 8
        InitCustomMandatoryFields()
        lpPermanentAddress.PersonalDataTypes = New PersonalDataGroup() {PersonalDataGroup.Human_PermanentResidence_Coordinates, PersonalDataGroup.Human_PermanentResidence_Details, PersonalDataGroup.Human_PermanentResidence_Settlement}
        lpEmployerAddress.PersonalDataTypes = New PersonalDataGroup() {PersonalDataGroup.Human_Employer_Details, PersonalDataGroup.Human_Employer_Settlement}

        PatientInfo.HidePersonalData = True
        CaseTestsPanel1.SetColumnsVisibility(False, False, False, False)

        If (EIDSS.model.Reports.BaseMenuReportRegistrator.IsPaperFormAllowed("HumCaseInvestigation")) Then
            Me.cmMenuReports.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miCaseInvestigationForm})
        End If
        If (EIDSS.model.Reports.BaseMenuReportRegistrator.IsPaperFormAllowed("HumUrgentyNotification")) Then
            Me.cmMenuReports.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miNotificationForm})
        End If
        If (EIDSS.model.Reports.BaseMenuReportRegistrator.IsPaperFormAllowed("HumUrgentyNotificationDTRA")) Then
            Me.cmMenuReports.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miNotificationFormDTRA})
        End If
        If (EIDSS.model.Reports.BaseMenuReportRegistrator.IsPaperFormAllowed("HumUrgentyNotificationTanzania")) Then
            Me.cmMenuReports.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miNotificationFormTanzania})
        End If


        SetSimplifiedMode()
        ValidationProcedureName = "spHumanCase_Validate"
        DebugTimer.Stop()


    End Sub
    Public Sub New(ByVal IsSearchMode As Boolean)
        MyBase.New()

        StopBR = True
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        HumanCaseDbService = New HumanCase_DB
        AuditObject = New AuditObject(EIDSSAuditObject.daoHumanCase, AuditTable.tlbHumanCase)
        Me.PermissionObject = eidss.model.Enums.EIDSSPermissionObject.HumanCase

        If Not eidss.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.UpdatePermission( _
                                                eidss.model.Enums.EIDSSPermissionObject.HumanCase)) Then
            Me.cbCaseStatus.Tag = Me.cbCaseStatus.Tag.ToString().Replace("{alwayseditable}", "")
            Me.cbCaseStatus.Enabled = False
        End If

        DbService = HumanCaseDbService
        StopBR = False

        'TODO:/*Search Mode*/ Remove If condition for registering sample panel
        If Not IsSearchMode Then
            RegisterChildObject(HumanCaseSamplesPanel1, RelatedPostOrder.PostLast)
            HumanCaseSamplesPanel1.HACode = HACode.Human
        End If

        If Not IsSearchMode Then
            RegisterChildObject(CaseTestsPanel1, RelatedPostOrder.PostLast)
            CaseTestsPanel1.HACode = HACode.Human
        End If

        Me.RegisterChildObject(PatientInfo, RelatedPostOrder.PostFirst)
        Me.RegisterChildObject(FFClinicalSigns, RelatedPostOrder.PostLast)
        Me.RegisterChildObject(ffEpiInvestigations, RelatedPostOrder.PostLast)

        RegisterChildObject(Me.cbGeoLocation, RelatedPostOrder.PostFirst)
        Me.RegisterChildObject(lpPermanentAddress, RelatedPostOrder.PostFirst)
        lpPermanentAddress.PersonalDataTypes = New PersonalDataGroup() {PersonalDataGroup.Human_PermanentResidence_Coordinates, PersonalDataGroup.Human_PermanentResidence_Details, PersonalDataGroup.Human_PermanentResidence_Settlement}
        lpPermanentAddress.PersonalDataString = ""
        lpEmployerAddress.PersonalDataTypes = New PersonalDataGroup() {PersonalDataGroup.Human_Employer_Details, PersonalDataGroup.Human_Employer_Settlement}
        lpEmployerAddress.PersonalDataString = ""
        PatientInfo.HidePersonalData = True
        PatientInfo.PersonalDataString = ""
        chkForeignAddress.Left = lblPermanentAddress.Left + lblPermanentAddress.Width + 16
        chkUseSameAddress.Left = chkForeignAddress.Left + chkForeignAddress.Width + 16
        chkUseSameAddress.Width = gpDemographicInfo.Width - chkUseSameAddress.Left - 8
        miCaseInvestigationForm.Visible = EIDSS.model.Reports.BaseMenuReportRegistrator.IsPaperFormAllowed("HumUrgentyNotification")
        SetSimplifiedMode()

    End Sub

    'Form overrides dispose to clean up the component list.

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)

        If disposing Then

            If Not (components Is Nothing) Then

                components.Dispose()

            End If
            If dsLocation IsNot Nothing Then
                dsLocation.Dispose()
                dsLocation = Nothing
            End If

        End If

        MyBase.Dispose(disposing)

    End Sub


    'Required by the Windows Form Designer

    Private components As System.ComponentModel.IContainer


    'NOTE: The following procedure is required by the Windows Form Designer

    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents cbNotCollectedReason As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblNotCollectedReason As System.Windows.Forms.Label
    Friend WithEvents cbSpecimenCollected As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblSpecimenCollected As System.Windows.Forms.Label
    Friend WithEvents cbNonNotifiableDiesease As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents PatientInfo As EIDSS.Patient_Info
    Friend WithEvents lpCurrentResidenceAddress As EIDSS.AddressLookup
    Friend WithEvents chbClinicalDiagBasis As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chbLabDiagBasis As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chbEpiDiagBasis As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cbInvOrganization As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblInvOrganization As System.Windows.Forms.Label
    Friend WithEvents lblNotifOrganization As System.Windows.Forms.Label
    Friend WithEvents txtNotifOrganization As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblNotifSentByDate As System.Windows.Forms.Label
    Friend WithEvents txtNotifSentByDate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tpSamples As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents lblAntimicrobialTherapy As System.Windows.Forms.Label
    Friend WithEvents lblAntimicrobialTherapyTable As System.Windows.Forms.Label
    Friend WithEvents HumanCaseSamplesPanel1 As EIDSS.HumanCaseSamplesPanel
    Friend WithEvents btnSearchInBrowseMode As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtPatientAgeUnits As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPatientSex As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtNationality As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtDOB As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtEmployerLastVisit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtLocalIdentifier As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblLocalIdentifier As System.Windows.Forms.Label
    Friend WithEvents txtLocalID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblLocalID As System.Windows.Forms.Label
    Friend WithEvents lblFinalDiagnosis As System.Windows.Forms.Label
    Friend WithEvents txtFinalDiagnosis As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblFinalDiagnosisDate As System.Windows.Forms.Label
    Friend WithEvents dtFinalDiagnosisDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblOutcome As System.Windows.Forms.Label
    Friend WithEvents cbOutcome As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cbOutbreakID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblOutbreakExists As System.Windows.Forms.Label
    Friend WithEvents cbOutbreakExists As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblEpidemiologistsName As System.Windows.Forms.Label
    Friend WithEvents colContactPlace As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbInitialCaseClassification As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblInitialCaseClassification As System.Windows.Forms.Label
    Friend WithEvents lblClinicalDiagnosis As System.Windows.Forms.Label
    Friend WithEvents txtClinicalDiagnosis As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSymptomOnsetDate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblSymptomOnsetDate As System.Windows.Forms.Label
    Friend WithEvents lblInitialClinicalDiagnosis As System.Windows.Forms.Label
    Friend WithEvents lblHospitalization As System.Windows.Forms.Label
    Friend WithEvents txtHospital As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblClinicalComments As System.Windows.Forms.Label
    Friend WithEvents gcAntimicrobialTherapy As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvAntimicrobialTherapy As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnRemoveAntimicrobialTherapy As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gcolAntimicrobialTherapyName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolAntimicrobialTherapyID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolFirstAntimicrobialAdminDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtRegistrationPhone As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblRegistrationPhoneNumber As System.Windows.Forms.Label
    Friend WithEvents lblWorkPhoneNumber As System.Windows.Forms.Label
    Friend WithEvents lpEmployerAddress As eidss.AddressLookup
    Friend WithEvents gcolAntimicrobialTherapyDose As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbAntimicrobialTherapy As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cbOccupation As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblOccupation As System.Windows.Forms.Label
    Friend WithEvents lblDischargeDate As System.Windows.Forms.Label
    Friend WithEvents txtDischargeDate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents colContactInfo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lblHospital As System.Windows.Forms.Label
    Friend WithEvents cbHospitalization As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtWorkPhone As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnClear As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tpCaseInvestigation As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tcCaseInvestigation As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tpDemographic As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tpEpiLinksRiskFactors As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tpCaseClassification As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tpContactsRemarks As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tpCaseSummary As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tpClinicalInformation As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents lblInvestigationStartDate As System.Windows.Forms.Label
    Friend WithEvents txtPatientAge As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblPatientAge As System.Windows.Forms.Label
    Friend WithEvents txtFirstName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtLastName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblLastName As System.Windows.Forms.Label
    Friend WithEvents lblPatronymic As System.Windows.Forms.Label
    Friend WithEvents txtSecondName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblFirstName As System.Windows.Forms.Label
    Friend WithEvents lblDOB As System.Windows.Forms.Label
    Friend WithEvents lblPatientName As System.Windows.Forms.Label
    Friend WithEvents gpDemographicInfo As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lpPermanentAddress As eidss.AddressLookup
    Friend WithEvents lblPermanentAddress As System.Windows.Forms.Label
    Friend WithEvents lblEmployerLastVisit As System.Windows.Forms.Label
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tpGeneral As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents gbCaseData As System.Windows.Forms.Panel
    Friend WithEvents RepItem_slcResponseMeasureType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepItem_slcResult As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepItem_dtpMeasureDate As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents RepItem_slcResponsiblePerson As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbRepSource As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtCaseID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents gvContactPeople As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gcContactPeople As DevExpress.XtraGrid.GridControl
    Friend WithEvents btnAddContact As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents colName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRelationType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cbContactType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepositoryItemDateEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents btnEditContact As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDeleteContact As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents redDateDiagDate As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents redLookupDiagType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents redLookupDiseaseName As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents redTxtDiseaseCode As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents redLookupBaseForDiag As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents redLookupDiagBy As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents cmMenuReports As System.Windows.Forms.ContextMenu
    Friend WithEvents miCaseInvestigationForm As System.Windows.Forms.MenuItem
    Friend WithEvents miNotificationForm As System.Windows.Forms.MenuItem
    Friend WithEvents miNotificationFormDTRA As System.Windows.Forms.MenuItem
    Friend WithEvents miNotificationFormTanzania As System.Windows.Forms.MenuItem

    Friend WithEvents deOnsetDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cbFinalState As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents btnSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbReceivedInst As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents PopUpButton2 As bv.winclient.Core.PopUpButton
    Friend WithEvents cbHospitalizedTo As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents txtAge As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents cbAgeUnits As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents ffEpiInvestigations As eidss.FlexibleForms.FFPresenter
    Friend WithEvents FFClinicalSigns As eidss.FlexibleForms.FFPresenter
    Friend WithEvents TabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tpTests As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents CaseTestsPanel1 As eidss.CaseTestsPanel
    Friend WithEvents bntNextCase As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents bntPreviousCase As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnLastCase As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnFirstCase As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtCaseCount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCaseNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnNewCase As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnNewCase1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtCaseNumber1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCaseCount1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnNextCase1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnLastCase1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnFirstCase1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnPrevCase1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents dtLastVisitToEmployer As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblLastVisitToEmployer As System.Windows.Forms.Label
    Friend WithEvents lblCaseID As System.Windows.Forms.Label
    Friend WithEvents cbDiagnosis As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblDiagnosis As System.Windows.Forms.Label
    Friend WithEvents lblDiagnosisDate As System.Windows.Forms.Label
    Friend WithEvents dtDiagnosisDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblOnsetDate As System.Windows.Forms.Label
    Friend WithEvents lblFinalState As System.Windows.Forms.Label
    Friend WithEvents lblHospitalizedTo As System.Windows.Forms.Label
    Friend WithEvents lblFormCompletionDate As System.Windows.Forms.Label
    Friend WithEvents dtFormCompletionDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblChangedDiagnosisDate As System.Windows.Forms.Label
    Friend WithEvents dtChangedDiagnosisDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblChangedDiagnosis As System.Windows.Forms.Label
    Friend WithEvents cbChangedDiagnosis As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblRepSource As System.Windows.Forms.Label
    Friend WithEvents lblReceivedInst As System.Windows.Forms.Label
    Friend WithEvents dtStartDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lbDateEntered As System.Windows.Forms.Label
    Friend WithEvents lbDateLastSaved As System.Windows.Forms.Label
    Friend WithEvents dtEnteringDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblReportingDate As System.Windows.Forms.Label
    Friend WithEvents lblSentBy As System.Windows.Forms.Label
    Friend WithEvents lblReceivedBy As System.Windows.Forms.Label
    Friend WithEvents gpGeneralInformation As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblOtherLocation As System.Windows.Forms.Label
    Friend WithEvents txtOtherLocation As DevExpress.XtraEditors.TextEdit
    Friend WithEvents memoNote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents lblCurrentPatientLocation As System.Windows.Forms.Label
    Friend WithEvents gpClinicalInformation As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents lblDateOfDischarge As System.Windows.Forms.Label
    Friend WithEvents lblDateOfAdmissionHospitalization As System.Windows.Forms.Label
    Friend WithEvents lblDatePatientFirstSought As System.Windows.Forms.Label
    Friend WithEvents lblDateOfxposure As System.Windows.Forms.Label
    Friend WithEvents lblOutbreakID As System.Windows.Forms.Label
    Friend WithEvents lblFinalCaseClassification As System.Windows.Forms.Label
    Friend WithEvents lblBasisOfDiagnosis As System.Windows.Forms.Label
    Friend WithEvents lblSummaryComments As System.Windows.Forms.Label
    Friend WithEvents deDateOfxposure As DevExpress.XtraEditors.DateEdit
    Friend WithEvents deDatePatientFirstSought As DevExpress.XtraEditors.DateEdit
    Friend WithEvents deDateOfAdmissionHospitalization As DevExpress.XtraEditors.DateEdit
    Friend WithEvents deDateOfDischarge As DevExpress.XtraEditors.DateEdit
    Friend WithEvents meClinicalComments As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents lueFinalCaseClassification As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents meSummaryComments As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents cbFacilitySoughtCare As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lblFacilitySoughtCare As System.Windows.Forms.Label
    Friend WithEvents deDateOfDeath As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblDateOfDeath As System.Windows.Forms.Label
    Friend WithEvents lblPatient As System.Windows.Forms.Label
    Friend WithEvents lblDisease As System.Windows.Forms.Label
    Friend WithEvents txtPatient As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cbCurrentDiagnosis As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents colContactDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents dtContactDate As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents gpDemographicInformation As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblPersonSex As System.Windows.Forms.Label
    Friend WithEvents txtEmployerName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblEmployerName As System.Windows.Forms.Label
    Friend WithEvents txtPhoneNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblPhoneNumber As System.Windows.Forms.Label
    Friend WithEvents lblEmployerAddress As System.Windows.Forms.Label
    Friend WithEvents lblNationality As System.Windows.Forms.Label
    Friend WithEvents lblResidence As System.Windows.Forms.Label
    Friend WithEvents lblCaseClassification As System.Windows.Forms.Label
    Friend WithEvents cbCaseClassification As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents btnSearchHumanCase As DevExpress.XtraEditors.SimpleButton

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HumanCaseDetail))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject5 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject6 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject7 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject8 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject9 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject10 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject11 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject12 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject13 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject14 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject15 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject16 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject17 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject18 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject19 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject20 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject21 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject22 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject23 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject24 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject25 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject26 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject27 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject28 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject29 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject30 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject31 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject32 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject33 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject34 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject35 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject36 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject37 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject38 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject39 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject40 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject41 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject42 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject43 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject44 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject45 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject46 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject47 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject48 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject49 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject50 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject51 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject52 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject53 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject54 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject55 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject56 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject57 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject58 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject59 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject60 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject61 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject62 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject63 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject64 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject65 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject66 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject67 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject68 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject69 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject70 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject71 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject72 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject73 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject74 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject75 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject76 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject77 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.dtFirstAntimicrobialAdminDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.TabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.tpGeneral = New DevExpress.XtraTab.XtraTabPage()
        Me.txtLocalID = New DevExpress.XtraEditors.TextEdit()
        Me.dtFormCompletionDate = New DevExpress.XtraEditors.DateEdit()
        Me.lblDiagnosisDate = New System.Windows.Forms.Label()
        Me.dtDiagnosisDate = New DevExpress.XtraEditors.DateEdit()
        Me.lblDiagnosis = New System.Windows.Forms.Label()
        Me.cbDiagnosis = New DevExpress.XtraEditors.LookUpEdit()
        Me.btnSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.gpDemographicInformation = New DevExpress.XtraEditors.GroupControl()
        Me.dtLastVisitToEmployer = New DevExpress.XtraEditors.DateEdit()
        Me.lblLastVisitToEmployer = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.PatientInfo = New eidss.Patient_Info()
        Me.cbAgeUnits = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtAge = New DevExpress.XtraEditors.SpinEdit()
        Me.gpGeneralInformation = New DevExpress.XtraEditors.GroupControl()
        Me.cbReceivedByName = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblReceivedByName = New System.Windows.Forms.Label()
        Me.cbSentByName = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblSentByName = New System.Windows.Forms.Label()
        Me.lblSentBy = New System.Windows.Forms.Label()
        Me.lblReportingDate = New System.Windows.Forms.Label()
        Me.cbReceivedInst = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblReceivedInst = New System.Windows.Forms.Label()
        Me.cbRepSource = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblRepSource = New System.Windows.Forms.Label()
        Me.dtReportingDate = New DevExpress.XtraEditors.DateEdit()
        Me.lblReceivedBy = New System.Windows.Forms.Label()
        Me.gpClinicalInformation = New DevExpress.XtraEditors.GroupControl()
        Me.cbCurrentPatientLocation = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblChangedDiagnosis = New System.Windows.Forms.Label()
        Me.txtOtherLocation = New DevExpress.XtraEditors.TextEdit()
        Me.lblChangedDiagnosisDate = New System.Windows.Forms.Label()
        Me.dtChangedDiagnosisDate = New DevExpress.XtraEditors.DateEdit()
        Me.cbChangedDiagnosis = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbFinalState = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblHospitalizedTo = New System.Windows.Forms.Label()
        Me.cbHospitalizedTo = New DevExpress.XtraEditors.LookUpEdit()
        Me.deOnsetDate = New DevExpress.XtraEditors.DateEdit()
        Me.lblFinalState = New System.Windows.Forms.Label()
        Me.memoNote = New DevExpress.XtraEditors.MemoEdit()
        Me.lblCurrentPatientLocation = New System.Windows.Forms.Label()
        Me.lblNote = New System.Windows.Forms.Label()
        Me.lblOnsetDate = New System.Windows.Forms.Label()
        Me.lblOtherLocation = New System.Windows.Forms.Label()
        Me.lblFormCompletionDate = New System.Windows.Forms.Label()
        Me.lblLocalID = New System.Windows.Forms.Label()
        Me.tpCaseInvestigation = New DevExpress.XtraTab.XtraTabPage()
        Me.tcCaseInvestigation = New DevExpress.XtraTab.XtraTabControl()
        Me.tpDemographic = New DevExpress.XtraTab.XtraTabPage()
        Me.dtInvestigationStartDate = New DevExpress.XtraEditors.DateEdit()
        Me.lblNotifSentByDate = New System.Windows.Forms.Label()
        Me.txtNotifSentByDate = New DevExpress.XtraEditors.TextEdit()
        Me.txtNotifOrganization = New DevExpress.XtraEditors.TextEdit()
        Me.lblNotifOrganization = New System.Windows.Forms.Label()
        Me.cbInvOrganization = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtLocalIdentifier = New DevExpress.XtraEditors.TextEdit()
        Me.lblLocalIdentifier = New System.Windows.Forms.Label()
        Me.gpDemographicInfo = New DevExpress.XtraEditors.GroupControl()
        Me.txtPersonalIdType = New DevExpress.XtraEditors.TextEdit()
        Me.txtPersonalID = New DevExpress.XtraEditors.TextEdit()
        Me.lbPersonalID = New System.Windows.Forms.Label()
        Me.lbPersonalIdType = New System.Windows.Forms.Label()
        Me.chkUseSameAddress = New DevExpress.XtraEditors.CheckEdit()
        Me.chkForeignAddress = New DevExpress.XtraEditors.CheckEdit()
        Me.lblPhoneNumber = New System.Windows.Forms.Label()
        Me.txtPhoneNumber = New DevExpress.XtraEditors.TextEdit()
        Me.lblResidence = New System.Windows.Forms.Label()
        Me.txtRegistrationPhone = New DevExpress.XtraEditors.TextEdit()
        Me.txtWorkPhone = New DevExpress.XtraEditors.TextEdit()
        Me.cbOccupation = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblOccupation = New System.Windows.Forms.Label()
        Me.lblWorkPhoneNumber = New System.Windows.Forms.Label()
        Me.lblRegistrationPhoneNumber = New System.Windows.Forms.Label()
        Me.txtEmployerLastVisit = New DevExpress.XtraEditors.TextEdit()
        Me.txtDOB = New DevExpress.XtraEditors.TextEdit()
        Me.txtNationality = New DevExpress.XtraEditors.TextEdit()
        Me.txtPatientSex = New DevExpress.XtraEditors.TextEdit()
        Me.txtPatientAgeUnits = New DevExpress.XtraEditors.TextEdit()
        Me.lblPermanentAddress = New System.Windows.Forms.Label()
        Me.txtEmployerName = New DevExpress.XtraEditors.TextEdit()
        Me.lblEmployerName = New System.Windows.Forms.Label()
        Me.lblEmployerAddress = New System.Windows.Forms.Label()
        Me.lblNationality = New System.Windows.Forms.Label()
        Me.lblPersonSex = New System.Windows.Forms.Label()
        Me.lblPatronymic = New System.Windows.Forms.Label()
        Me.txtPatientAge = New DevExpress.XtraEditors.TextEdit()
        Me.txtFirstName = New DevExpress.XtraEditors.TextEdit()
        Me.lblPatientAge = New System.Windows.Forms.Label()
        Me.lblDOB = New System.Windows.Forms.Label()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.txtLastName = New DevExpress.XtraEditors.TextEdit()
        Me.txtSecondName = New DevExpress.XtraEditors.TextEdit()
        Me.lblEmployerLastVisit = New System.Windows.Forms.Label()
        Me.lblPatientName = New System.Windows.Forms.Label()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.lpCurrentResidenceAddress = New eidss.AddressLookup()
        Me.lpEmployerAddress = New eidss.AddressLookup()
        Me.lpPermanentAddress = New eidss.AddressLookup()
        Me.lblInvestigationStartDate = New System.Windows.Forms.Label()
        Me.lblInvOrganization = New System.Windows.Forms.Label()
        Me.tpClinicalInformation = New DevExpress.XtraTab.XtraTabPage()
        Me.cbGeoLocation = New eidss.LocationLookup()
        Me.cbNonNotifiableDiesease = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbHospitalization = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblAntimicrobialTherapyTable = New System.Windows.Forms.Label()
        Me.lblAntimicrobialTherapy = New System.Windows.Forms.Label()
        Me.cbAntimicrobialTherapy = New DevExpress.XtraEditors.LookUpEdit()
        Me.meClinicalComments = New DevExpress.XtraEditors.MemoEdit()
        Me.lblClinicalComments = New System.Windows.Forms.Label()
        Me.lblHospital = New System.Windows.Forms.Label()
        Me.lblDateOfxposure = New System.Windows.Forms.Label()
        Me.cbInitialCaseClassification = New DevExpress.XtraEditors.LookUpEdit()
        Me.deDateOfxposure = New DevExpress.XtraEditors.DateEdit()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.lblHospitalization = New System.Windows.Forms.Label()
        Me.txtHospital = New DevExpress.XtraEditors.TextEdit()
        Me.lblDateOfAdmissionHospitalization = New System.Windows.Forms.Label()
        Me.lblFacilitySoughtCare = New System.Windows.Forms.Label()
        Me.lblInitialClinicalDiagnosis = New System.Windows.Forms.Label()
        Me.deDateOfAdmissionHospitalization = New DevExpress.XtraEditors.DateEdit()
        Me.lblSymptomOnsetDate = New System.Windows.Forms.Label()
        Me.lblClinicalDiagnosis = New System.Windows.Forms.Label()
        Me.lblDatePatientFirstSought = New System.Windows.Forms.Label()
        Me.txtClinicalDiagnosis = New DevExpress.XtraEditors.TextEdit()
        Me.lblInitialCaseClassification = New System.Windows.Forms.Label()
        Me.deDatePatientFirstSought = New DevExpress.XtraEditors.DateEdit()
        Me.txtSymptomOnsetDate = New DevExpress.XtraEditors.TextEdit()
        Me.cbFacilitySoughtCare = New DevExpress.XtraEditors.LookUpEdit()
        Me.btnRemoveAntimicrobialTherapy = New DevExpress.XtraEditors.SimpleButton()
        Me.gcAntimicrobialTherapy = New DevExpress.XtraGrid.GridControl()
        Me.gvAntimicrobialTherapy = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gcolAntimicrobialTherapyID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolAntimicrobialTherapyName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolAntimicrobialTherapyDose = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolFirstAntimicrobialAdminDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.tpSamples = New DevExpress.XtraTab.XtraTabPage()
        Me.cbNotCollectedReason = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblNotCollectedReason = New System.Windows.Forms.Label()
        Me.cbSpecimenCollected = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblSpecimenCollected = New System.Windows.Forms.Label()
        Me.HumanCaseSamplesPanel1 = New eidss.HumanCaseSamplesPanel()
        Me.tpContactsRemarks = New DevExpress.XtraTab.XtraTabPage()
        Me.gcContactPeople = New DevExpress.XtraGrid.GridControl()
        Me.gvContactPeople = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtContactName = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.colRelationType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cbContactType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colContactDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.dtContactDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.colContactPlace = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colContactInfo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colComments = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtContactComments = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.btnAddContact = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDeleteContact = New DevExpress.XtraEditors.SimpleButton()
        Me.btnEditContact = New DevExpress.XtraEditors.SimpleButton()
        Me.tpCaseClassification = New DevExpress.XtraTab.XtraTabPage()
        Me.FFClinicalSigns = New eidss.FlexibleForms.FFPresenter()
        Me.tpEpiLinksRiskFactors = New DevExpress.XtraTab.XtraTabPage()
        Me.ffEpiInvestigations = New eidss.FlexibleForms.FFPresenter()
        Me.tpCaseSummary = New DevExpress.XtraTab.XtraTabPage()
        Me.dtFinalCaseClassificationDate = New DevExpress.XtraEditors.DateEdit()
        Me.lbFinalCaseClassificationDate = New System.Windows.Forms.Label()
        Me.cbEpidemiologistName = New DevExpress.XtraEditors.LookUpEdit()
        Me.chbEpiDiagBasis = New DevExpress.XtraEditors.CheckEdit()
        Me.chbLabDiagBasis = New DevExpress.XtraEditors.CheckEdit()
        Me.chbClinicalDiagBasis = New DevExpress.XtraEditors.CheckEdit()
        Me.deDateOfDeath = New DevExpress.XtraEditors.DateEdit()
        Me.lblFinalDiagnosisDate = New System.Windows.Forms.Label()
        Me.dtFinalDiagnosisDate = New DevExpress.XtraEditors.DateEdit()
        Me.lblDateOfDeath = New System.Windows.Forms.Label()
        Me.cbOutbreakExists = New DevExpress.XtraEditors.LookUpEdit()
        Me.lueFinalCaseClassification = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblFinalCaseClassification = New System.Windows.Forms.Label()
        Me.lblOutbreakExists = New System.Windows.Forms.Label()
        Me.cbOutcome = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblOutcome = New System.Windows.Forms.Label()
        Me.lblFinalDiagnosis = New System.Windows.Forms.Label()
        Me.txtFinalDiagnosis = New DevExpress.XtraEditors.TextEdit()
        Me.lblBasisOfDiagnosis = New System.Windows.Forms.Label()
        Me.lblEpidemiologistsName = New System.Windows.Forms.Label()
        Me.lblSummaryComments = New System.Windows.Forms.Label()
        Me.cbOutbreakID = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblOutbreakID = New System.Windows.Forms.Label()
        Me.lblDateOfDischarge = New System.Windows.Forms.Label()
        Me.lblDischargeDate = New System.Windows.Forms.Label()
        Me.meSummaryComments = New DevExpress.XtraEditors.MemoEdit()
        Me.deDateOfDischarge = New DevExpress.XtraEditors.DateEdit()
        Me.txtDischargeDate = New DevExpress.XtraEditors.TextEdit()
        Me.tpTests = New DevExpress.XtraTab.XtraTabPage()
        Me.lbTestsConducted = New DevExpress.XtraEditors.LabelControl()
        Me.cbTestsConducted = New DevExpress.XtraEditors.LookUpEdit()
        Me.CaseTestsPanel1 = New eidss.CaseTestsPanel()
        Me.RepositoryItemDateEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.redDateDiagDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.redLookupDiagType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.redLookupDiseaseName = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.redLookupBaseForDiag = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.redLookupDiagBy = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.dtStartDate = New DevExpress.XtraEditors.DateEdit()
        Me.bntPreviousCase = New DevExpress.XtraEditors.SimpleButton()
        Me.bntNextCase = New DevExpress.XtraEditors.SimpleButton()
        Me.btnLastCase = New DevExpress.XtraEditors.SimpleButton()
        Me.btnFirstCase = New DevExpress.XtraEditors.SimpleButton()
        Me.RepItem_slcResponseMeasureType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.RepItem_slcResult = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.RepItem_dtpMeasureDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.RepItem_slcResponsiblePerson = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gbCaseData = New System.Windows.Forms.Panel()
        Me.cbEnteredByOrganization = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbEnteredByName = New DevExpress.XtraEditors.LookUpEdit()
        Me.lbEnteredByOrganization = New System.Windows.Forms.Label()
        Me.lbEnteredByName = New System.Windows.Forms.Label()
        Me.cbCaseStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.lbCaseStatus = New System.Windows.Forms.Label()
        Me.cbCaseClassification = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtCaseID = New DevExpress.XtraEditors.TextEdit()
        Me.lblPatient = New System.Windows.Forms.Label()
        Me.txtPatient = New DevExpress.XtraEditors.TextEdit()
        Me.dtEnteringDate = New DevExpress.XtraEditors.DateEdit()
        Me.lbDateLastSaved = New System.Windows.Forms.Label()
        Me.lbDateEntered = New System.Windows.Forms.Label()
        Me.cbCurrentDiagnosis = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblCaseID = New System.Windows.Forms.Label()
        Me.lblCaseClassification = New System.Windows.Forms.Label()
        Me.lblDisease = New System.Windows.Forms.Label()
        Me.lbEnteredBy = New System.Windows.Forms.Label()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.Timer2 = New System.Windows.Forms.Timer()
        Me.cmMenuReports = New System.Windows.Forms.ContextMenu()
        Me.miCaseInvestigationForm = New System.Windows.Forms.MenuItem()
        Me.miNotificationForm = New System.Windows.Forms.MenuItem()
        Me.miNotificationFormDTRA = New System.Windows.Forms.MenuItem()
        Me.miNotificationFormTanzania = New System.Windows.Forms.MenuItem()
        Me.PopUpButton2 = New bv.winclient.Core.PopUpButton()
        Me.txtCaseCount = New DevExpress.XtraEditors.TextEdit()
        Me.txtCaseNumber = New DevExpress.XtraEditors.TextEdit()
        Me.btnNewCase = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNewCase1 = New DevExpress.XtraEditors.SimpleButton()
        Me.txtCaseNumber1 = New DevExpress.XtraEditors.TextEdit()
        Me.txtCaseCount1 = New DevExpress.XtraEditors.TextEdit()
        Me.btnNextCase1 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnLastCase1 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnFirstCase1 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnPrevCase1 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSearchHumanCase = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClear = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSearchInBrowseMode = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.dtFirstAntimicrobialAdminDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFirstAntimicrobialAdminDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tpGeneral.SuspendLayout()
        CType(Me.txtLocalID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFormCompletionDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFormCompletionDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDiagnosisDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDiagnosisDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDiagnosis.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gpDemographicInformation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpDemographicInformation.SuspendLayout()
        CType(Me.dtLastVisitToEmployer.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtLastVisitToEmployer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbAgeUnits.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAge.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gpGeneralInformation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpGeneralInformation.SuspendLayout()
        CType(Me.cbReceivedByName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSentByName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbReceivedInst.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbRepSource.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtReportingDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtReportingDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gpClinicalInformation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpClinicalInformation.SuspendLayout()
        CType(Me.cbCurrentPatientLocation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOtherLocation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtChangedDiagnosisDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtChangedDiagnosisDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbChangedDiagnosis.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbFinalState.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbHospitalizedTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deOnsetDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deOnsetDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.memoNote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpCaseInvestigation.SuspendLayout()
        CType(Me.tcCaseInvestigation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcCaseInvestigation.SuspendLayout()
        Me.tpDemographic.SuspendLayout()
        CType(Me.dtInvestigationStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtInvestigationStartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNotifSentByDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNotifOrganization.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbInvOrganization.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLocalIdentifier.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gpDemographicInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpDemographicInfo.SuspendLayout()
        CType(Me.txtPersonalIdType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPersonalID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkUseSameAddress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkForeignAddress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPhoneNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRegistrationPhone.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWorkPhone.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbOccupation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmployerLastVisit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDOB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNationality.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPatientSex.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPatientAgeUnits.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmployerName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPatientAge.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFirstName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLastName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSecondName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpClinicalInformation.SuspendLayout()
        CType(Me.cbNonNotifiableDiesease.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbHospitalization.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbAntimicrobialTherapy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.meClinicalComments.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbInitialCaseClassification.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDateOfxposure.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDateOfxposure.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHospital.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDateOfAdmissionHospitalization.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClinicalDiagnosis.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDatePatientFirstSought.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDatePatientFirstSought.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSymptomOnsetDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbFacilitySoughtCare.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcAntimicrobialTherapy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvAntimicrobialTherapy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpSamples.SuspendLayout()
        CType(Me.cbNotCollectedReason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSpecimenCollected.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpContactsRemarks.SuspendLayout()
        CType(Me.gcContactPeople, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvContactPeople, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContactName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbContactType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtContactDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtContactDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContactComments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpCaseClassification.SuspendLayout()
        Me.tpEpiLinksRiskFactors.SuspendLayout()
        Me.tpCaseSummary.SuspendLayout()
        CType(Me.dtFinalCaseClassificationDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFinalCaseClassificationDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbEpidemiologistName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chbEpiDiagBasis.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chbLabDiagBasis.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chbClinicalDiagBasis.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDateOfDeath.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDateOfDeath.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFinalDiagnosisDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFinalDiagnosisDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbOutbreakExists.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lueFinalCaseClassification.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbOutcome.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFinalDiagnosis.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbOutbreakID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.meSummaryComments.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDateOfDischarge.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDateOfDischarge.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDischargeDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpTests.SuspendLayout()
        CType(Me.cbTestsConducted.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.redDateDiagDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.redDateDiagDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.redLookupDiagType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.redLookupDiseaseName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.redLookupBaseForDiag, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.redLookupDiagBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtStartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepItem_slcResponseMeasureType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepItem_slcResult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepItem_dtpMeasureDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepItem_dtpMeasureDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepItem_slcResponsiblePerson, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCaseData.SuspendLayout()
        CType(Me.cbEnteredByOrganization.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbEnteredByName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCaseStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCaseClassification.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCaseID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPatient.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtEnteringDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtEnteringDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCurrentDiagnosis.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCaseCount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCaseNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCaseNumber1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCaseCount1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        bv.common.Resources.BvResourceManagerChanger.GetResourceManager(GetType(HumanCaseDetail), resources)
        'Form Is Localizable: True
        '
        'dtFirstAntimicrobialAdminDate
        '
        Me.dtFirstAntimicrobialAdminDate.Appearance.Options.UseFont = True
        Me.dtFirstAntimicrobialAdminDate.AppearanceDisabled.Options.UseFont = True
        Me.dtFirstAntimicrobialAdminDate.AppearanceDropDown.Options.UseFont = True
        Me.dtFirstAntimicrobialAdminDate.AppearanceDropDownHeader.Options.UseFont = True
        Me.dtFirstAntimicrobialAdminDate.AppearanceDropDownHeaderHighlight.Options.UseFont = True
        Me.dtFirstAntimicrobialAdminDate.AppearanceDropDownHighlight.Options.UseFont = True
        Me.dtFirstAntimicrobialAdminDate.AppearanceFocused.Options.UseFont = True
        Me.dtFirstAntimicrobialAdminDate.AppearanceReadOnly.Options.UseFont = True
        Me.dtFirstAntimicrobialAdminDate.AppearanceWeekNumber.Options.UseFont = True
        resources.ApplyResources(Me.dtFirstAntimicrobialAdminDate, "dtFirstAntimicrobialAdminDate")
        SerializableAppearanceObject1.Options.UseFont = True
        Me.dtFirstAntimicrobialAdminDate.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtFirstAntimicrobialAdminDate.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("dtFirstAntimicrobialAdminDate.Buttons1"), CType(resources.GetObject("dtFirstAntimicrobialAdminDate.Buttons2"), Integer), CType(resources.GetObject("dtFirstAntimicrobialAdminDate.Buttons3"), Boolean), CType(resources.GetObject("dtFirstAntimicrobialAdminDate.Buttons4"), Boolean), CType(resources.GetObject("dtFirstAntimicrobialAdminDate.Buttons5"), Boolean), CType(resources.GetObject("dtFirstAntimicrobialAdminDate.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("dtFirstAntimicrobialAdminDate.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, resources.GetString("dtFirstAntimicrobialAdminDate.Buttons8"), CType(resources.GetObject("dtFirstAntimicrobialAdminDate.Buttons9"), Object), CType(resources.GetObject("dtFirstAntimicrobialAdminDate.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("dtFirstAntimicrobialAdminDate.Buttons11"), Boolean))})
        Me.dtFirstAntimicrobialAdminDate.CalendarTimeProperties.Appearance.Options.UseFont = True
        Me.dtFirstAntimicrobialAdminDate.CalendarTimeProperties.AppearanceDisabled.Options.UseFont = True
        Me.dtFirstAntimicrobialAdminDate.CalendarTimeProperties.AppearanceFocused.Options.UseFont = True
        Me.dtFirstAntimicrobialAdminDate.CalendarTimeProperties.AppearanceReadOnly.Options.UseFont = True
        Me.dtFirstAntimicrobialAdminDate.CalendarTimeProperties.AutoHeight = CType(resources.GetObject("dtFirstAntimicrobialAdminDate.CalendarTimeProperties.AutoHeight"), Boolean)
        SerializableAppearanceObject2.Options.UseFont = True
        Me.dtFirstAntimicrobialAdminDate.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtFirstAntimicrobialAdminDate.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("dtFirstAntimicrobialAdminDate.CalendarTimeProperties.Buttons1"), CType(resources.GetObject("dtFirstAntimicrobialAdminDate.CalendarTimeProperties.Buttons2"), Integer), CType(resources.GetObject("dtFirstAntimicrobialAdminDate.CalendarTimeProperties.Buttons3"), Boolean), CType(resources.GetObject("dtFirstAntimicrobialAdminDate.CalendarTimeProperties.Buttons4"), Boolean), CType(resources.GetObject("dtFirstAntimicrobialAdminDate.CalendarTimeProperties.Buttons5"), Boolean), CType(resources.GetObject("dtFirstAntimicrobialAdminDate.CalendarTimeProperties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("dtFirstAntimicrobialAdminDate.CalendarTimeProperties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, resources.GetString("dtFirstAntimicrobialAdminDate.CalendarTimeProperties.Buttons8"), CType(resources.GetObject("dtFirstAntimicrobialAdminDate.CalendarTimeProperties.Buttons9"), Object), CType(resources.GetObject("dtFirstAntimicrobialAdminDate.CalendarTimeProperties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("dtFirstAntimicrobialAdminDate.CalendarTimeProperties.Buttons11"), Boolean))})
        Me.dtFirstAntimicrobialAdminDate.CalendarTimeProperties.Mask.EditMask = resources.GetString("dtFirstAntimicrobialAdminDate.CalendarTimeProperties.Mask.EditMask")
        Me.dtFirstAntimicrobialAdminDate.CalendarTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtFirstAntimicrobialAdminDate.CalendarTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtFirstAntimicrobialAdminDate.CalendarTimeProperties.Mask.MaskType = CType(resources.GetObject("dtFirstAntimicrobialAdminDate.CalendarTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtFirstAntimicrobialAdminDate.CalendarTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("dtFirstAntimicrobialAdminDate.CalendarTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.dtFirstAntimicrobialAdminDate.CalendarTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtFirstAntimicrobialAdminDate.CalendarTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtFirstAntimicrobialAdminDate.CalendarTimeProperties.NullValuePrompt = resources.GetString("dtFirstAntimicrobialAdminDate.CalendarTimeProperties.NullValuePrompt")
        Me.dtFirstAntimicrobialAdminDate.Mask.EditMask = resources.GetString("dtFirstAntimicrobialAdminDate.Mask.EditMask")
        Me.dtFirstAntimicrobialAdminDate.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtFirstAntimicrobialAdminDate.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtFirstAntimicrobialAdminDate.Mask.MaskType = CType(resources.GetObject("dtFirstAntimicrobialAdminDate.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtFirstAntimicrobialAdminDate.Mask.SaveLiteral = CType(resources.GetObject("dtFirstAntimicrobialAdminDate.Mask.SaveLiteral"), Boolean)
        Me.dtFirstAntimicrobialAdminDate.Mask.ShowPlaceHolders = CType(resources.GetObject("dtFirstAntimicrobialAdminDate.Mask.ShowPlaceHolders"), Boolean)
        Me.dtFirstAntimicrobialAdminDate.Name = "dtFirstAntimicrobialAdminDate"
        '
        'TabControl1
        '
        Me.TabControl1.Appearance.Options.UseFont = True
        Me.TabControl1.AppearancePage.Header.Options.UseFont = True
        Me.TabControl1.AppearancePage.HeaderActive.Options.UseFont = True
        Me.TabControl1.AppearancePage.HeaderDisabled.Options.UseFont = True
        Me.TabControl1.AppearancePage.HeaderHotTracked.Options.UseFont = True
        Me.TabControl1.AppearancePage.PageClient.Options.UseFont = True
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedTabPage = Me.tpGeneral
        Me.TabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tpGeneral, Me.tpCaseInvestigation, Me.tpTests})
        '
        'tpGeneral
        '
        Me.tpGeneral.Appearance.Header.Options.UseFont = True
        Me.tpGeneral.Appearance.HeaderActive.Options.UseFont = True
        Me.tpGeneral.Appearance.HeaderDisabled.Options.UseFont = True
        Me.tpGeneral.Appearance.HeaderHotTracked.Options.UseFont = True
        Me.tpGeneral.Appearance.PageClient.BackColor = CType(resources.GetObject("tpGeneral.Appearance.PageClient.BackColor"), System.Drawing.Color)
        Me.tpGeneral.Appearance.PageClient.Options.UseBackColor = True
        Me.tpGeneral.Appearance.PageClient.Options.UseFont = True
        Me.tpGeneral.Controls.Add(Me.txtLocalID)
        Me.tpGeneral.Controls.Add(Me.dtFormCompletionDate)
        Me.tpGeneral.Controls.Add(Me.lblDiagnosisDate)
        Me.tpGeneral.Controls.Add(Me.dtDiagnosisDate)
        Me.tpGeneral.Controls.Add(Me.lblDiagnosis)
        Me.tpGeneral.Controls.Add(Me.cbDiagnosis)
        Me.tpGeneral.Controls.Add(Me.btnSearch)
        Me.tpGeneral.Controls.Add(Me.gpDemographicInformation)
        Me.tpGeneral.Controls.Add(Me.gpGeneralInformation)
        Me.tpGeneral.Controls.Add(Me.gpClinicalInformation)
        Me.tpGeneral.Controls.Add(Me.lblFormCompletionDate)
        Me.tpGeneral.Controls.Add(Me.lblLocalID)
        Me.tpGeneral.Name = "tpGeneral"
        resources.ApplyResources(Me.tpGeneral, "tpGeneral")
        '
        'txtLocalID
        '
        resources.ApplyResources(Me.txtLocalID, "txtLocalID")
        Me.txtLocalID.Name = "txtLocalID"
        Me.txtLocalID.Properties.Appearance.Options.UseFont = True
        Me.txtLocalID.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtLocalID.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtLocalID.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtLocalID.Properties.AutoHeight = CType(resources.GetObject("txtLocalID.Properties.AutoHeight"), Boolean)
        Me.txtLocalID.Properties.Mask.EditMask = resources.GetString("txtLocalID.Properties.Mask.EditMask")
        Me.txtLocalID.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtLocalID.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtLocalID.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtLocalID.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtLocalID.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtLocalID.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtLocalID.Properties.MaxLength = 100
        Me.txtLocalID.Properties.NullValuePrompt = resources.GetString("txtLocalID.Properties.NullValuePrompt")
        Me.txtLocalID.Tag = ""
        '
        'dtFormCompletionDate
        '
        resources.ApplyResources(Me.dtFormCompletionDate, "dtFormCompletionDate")
        Me.dtFormCompletionDate.Name = "dtFormCompletionDate"
        Me.dtFormCompletionDate.Properties.Appearance.Options.UseFont = True
        Me.dtFormCompletionDate.Properties.AppearanceDisabled.Options.UseFont = True
        Me.dtFormCompletionDate.Properties.AppearanceDropDown.Options.UseFont = True
        Me.dtFormCompletionDate.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.dtFormCompletionDate.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = True
        Me.dtFormCompletionDate.Properties.AppearanceDropDownHighlight.Options.UseFont = True
        Me.dtFormCompletionDate.Properties.AppearanceFocused.Options.UseFont = True
        Me.dtFormCompletionDate.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.dtFormCompletionDate.Properties.AppearanceWeekNumber.Options.UseFont = True
        Me.dtFormCompletionDate.Properties.AutoHeight = CType(resources.GetObject("dtFormCompletionDate.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject3.Options.UseFont = True
        Me.dtFormCompletionDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtFormCompletionDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("dtFormCompletionDate.Properties.Buttons1"), CType(resources.GetObject("dtFormCompletionDate.Properties.Buttons2"), Integer), CType(resources.GetObject("dtFormCompletionDate.Properties.Buttons3"), Boolean), CType(resources.GetObject("dtFormCompletionDate.Properties.Buttons4"), Boolean), CType(resources.GetObject("dtFormCompletionDate.Properties.Buttons5"), Boolean), CType(resources.GetObject("dtFormCompletionDate.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("dtFormCompletionDate.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject3, resources.GetString("dtFormCompletionDate.Properties.Buttons8"), CType(resources.GetObject("dtFormCompletionDate.Properties.Buttons9"), Object), CType(resources.GetObject("dtFormCompletionDate.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("dtFormCompletionDate.Properties.Buttons11"), Boolean))})
        Me.dtFormCompletionDate.Properties.CalendarTimeProperties.Appearance.Options.UseFont = True
        Me.dtFormCompletionDate.Properties.CalendarTimeProperties.AppearanceDisabled.Options.UseFont = True
        Me.dtFormCompletionDate.Properties.CalendarTimeProperties.AppearanceFocused.Options.UseFont = True
        Me.dtFormCompletionDate.Properties.CalendarTimeProperties.AppearanceReadOnly.Options.UseFont = True
        Me.dtFormCompletionDate.Properties.CalendarTimeProperties.AutoHeight = CType(resources.GetObject("dtFormCompletionDate.Properties.CalendarTimeProperties.AutoHeight"), Boolean)
        SerializableAppearanceObject4.Options.UseFont = True
        Me.dtFormCompletionDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtFormCompletionDate.Properties.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("dtFormCompletionDate.Properties.CalendarTimeProperties.Buttons1"), CType(resources.GetObject("dtFormCompletionDate.Properties.CalendarTimeProperties.Buttons2"), Integer), CType(resources.GetObject("dtFormCompletionDate.Properties.CalendarTimeProperties.Buttons3"), Boolean), CType(resources.GetObject("dtFormCompletionDate.Properties.CalendarTimeProperties.Buttons4"), Boolean), CType(resources.GetObject("dtFormCompletionDate.Properties.CalendarTimeProperties.Buttons5"), Boolean), CType(resources.GetObject("dtFormCompletionDate.Properties.CalendarTimeProperties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("dtFormCompletionDate.Properties.CalendarTimeProperties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject4, resources.GetString("dtFormCompletionDate.Properties.CalendarTimeProperties.Buttons8"), CType(resources.GetObject("dtFormCompletionDate.Properties.CalendarTimeProperties.Buttons9"), Object), CType(resources.GetObject("dtFormCompletionDate.Properties.CalendarTimeProperties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("dtFormCompletionDate.Properties.CalendarTimeProperties.Buttons11"), Boolean))})
        Me.dtFormCompletionDate.Properties.CalendarTimeProperties.Mask.EditMask = resources.GetString("dtFormCompletionDate.Properties.CalendarTimeProperties.Mask.EditMask")
        Me.dtFormCompletionDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtFormCompletionDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtFormCompletionDate.Properties.CalendarTimeProperties.Mask.MaskType = CType(resources.GetObject("dtFormCompletionDate.Properties.CalendarTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtFormCompletionDate.Properties.CalendarTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("dtFormCompletionDate.Properties.CalendarTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.dtFormCompletionDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtFormCompletionDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtFormCompletionDate.Properties.CalendarTimeProperties.NullValuePrompt = resources.GetString("dtFormCompletionDate.Properties.CalendarTimeProperties.NullValuePrompt")
        Me.dtFormCompletionDate.Properties.Mask.BeepOnError = CType(resources.GetObject("dtFormCompletionDate.Properties.Mask.BeepOnError"), Boolean)
        Me.dtFormCompletionDate.Properties.Mask.EditMask = resources.GetString("dtFormCompletionDate.Properties.Mask.EditMask")
        Me.dtFormCompletionDate.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtFormCompletionDate.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtFormCompletionDate.Properties.Mask.MaskType = CType(resources.GetObject("dtFormCompletionDate.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtFormCompletionDate.Properties.Mask.SaveLiteral = CType(resources.GetObject("dtFormCompletionDate.Properties.Mask.SaveLiteral"), Boolean)
        Me.dtFormCompletionDate.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtFormCompletionDate.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtFormCompletionDate.Properties.NullValuePrompt = resources.GetString("dtFormCompletionDate.Properties.NullValuePrompt")
        Me.dtFormCompletionDate.Tag = ""
        '
        'lblDiagnosisDate
        '
        resources.ApplyResources(Me.lblDiagnosisDate, "lblDiagnosisDate")
        Me.lblDiagnosisDate.Name = "lblDiagnosisDate"
        '
        'dtDiagnosisDate
        '
        resources.ApplyResources(Me.dtDiagnosisDate, "dtDiagnosisDate")
        Me.dtDiagnosisDate.Name = "dtDiagnosisDate"
        Me.dtDiagnosisDate.Properties.Appearance.Options.UseFont = True
        Me.dtDiagnosisDate.Properties.AppearanceDisabled.Options.UseFont = True
        Me.dtDiagnosisDate.Properties.AppearanceDropDown.Options.UseFont = True
        Me.dtDiagnosisDate.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.dtDiagnosisDate.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = True
        Me.dtDiagnosisDate.Properties.AppearanceDropDownHighlight.Options.UseFont = True
        Me.dtDiagnosisDate.Properties.AppearanceFocused.Options.UseFont = True
        Me.dtDiagnosisDate.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.dtDiagnosisDate.Properties.AppearanceWeekNumber.Options.UseFont = True
        Me.dtDiagnosisDate.Properties.AutoHeight = CType(resources.GetObject("dtDiagnosisDate.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject5.Options.UseFont = True
        Me.dtDiagnosisDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtDiagnosisDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("dtDiagnosisDate.Properties.Buttons1"), CType(resources.GetObject("dtDiagnosisDate.Properties.Buttons2"), Integer), CType(resources.GetObject("dtDiagnosisDate.Properties.Buttons3"), Boolean), CType(resources.GetObject("dtDiagnosisDate.Properties.Buttons4"), Boolean), CType(resources.GetObject("dtDiagnosisDate.Properties.Buttons5"), Boolean), CType(resources.GetObject("dtDiagnosisDate.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("dtDiagnosisDate.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject5, resources.GetString("dtDiagnosisDate.Properties.Buttons8"), CType(resources.GetObject("dtDiagnosisDate.Properties.Buttons9"), Object), CType(resources.GetObject("dtDiagnosisDate.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("dtDiagnosisDate.Properties.Buttons11"), Boolean))})
        Me.dtDiagnosisDate.Properties.CalendarTimeProperties.Appearance.Options.UseFont = True
        Me.dtDiagnosisDate.Properties.CalendarTimeProperties.AppearanceDisabled.Options.UseFont = True
        Me.dtDiagnosisDate.Properties.CalendarTimeProperties.AppearanceFocused.Options.UseFont = True
        Me.dtDiagnosisDate.Properties.CalendarTimeProperties.AppearanceReadOnly.Options.UseFont = True
        Me.dtDiagnosisDate.Properties.CalendarTimeProperties.AutoHeight = CType(resources.GetObject("dtDiagnosisDate.Properties.CalendarTimeProperties.AutoHeight"), Boolean)
        SerializableAppearanceObject6.Options.UseFont = True
        Me.dtDiagnosisDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtDiagnosisDate.Properties.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("dtDiagnosisDate.Properties.CalendarTimeProperties.Buttons1"), CType(resources.GetObject("dtDiagnosisDate.Properties.CalendarTimeProperties.Buttons2"), Integer), CType(resources.GetObject("dtDiagnosisDate.Properties.CalendarTimeProperties.Buttons3"), Boolean), CType(resources.GetObject("dtDiagnosisDate.Properties.CalendarTimeProperties.Buttons4"), Boolean), CType(resources.GetObject("dtDiagnosisDate.Properties.CalendarTimeProperties.Buttons5"), Boolean), CType(resources.GetObject("dtDiagnosisDate.Properties.CalendarTimeProperties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("dtDiagnosisDate.Properties.CalendarTimeProperties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject6, resources.GetString("dtDiagnosisDate.Properties.CalendarTimeProperties.Buttons8"), CType(resources.GetObject("dtDiagnosisDate.Properties.CalendarTimeProperties.Buttons9"), Object), CType(resources.GetObject("dtDiagnosisDate.Properties.CalendarTimeProperties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("dtDiagnosisDate.Properties.CalendarTimeProperties.Buttons11"), Boolean))})
        Me.dtDiagnosisDate.Properties.CalendarTimeProperties.Mask.EditMask = resources.GetString("dtDiagnosisDate.Properties.CalendarTimeProperties.Mask.EditMask")
        Me.dtDiagnosisDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtDiagnosisDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtDiagnosisDate.Properties.CalendarTimeProperties.Mask.MaskType = CType(resources.GetObject("dtDiagnosisDate.Properties.CalendarTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtDiagnosisDate.Properties.CalendarTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("dtDiagnosisDate.Properties.CalendarTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.dtDiagnosisDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtDiagnosisDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtDiagnosisDate.Properties.CalendarTimeProperties.NullValuePrompt = resources.GetString("dtDiagnosisDate.Properties.CalendarTimeProperties.NullValuePrompt")
        Me.dtDiagnosisDate.Properties.Mask.BeepOnError = CType(resources.GetObject("dtDiagnosisDate.Properties.Mask.BeepOnError"), Boolean)
        Me.dtDiagnosisDate.Properties.Mask.EditMask = resources.GetString("dtDiagnosisDate.Properties.Mask.EditMask")
        Me.dtDiagnosisDate.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtDiagnosisDate.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtDiagnosisDate.Properties.Mask.MaskType = CType(resources.GetObject("dtDiagnosisDate.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtDiagnosisDate.Properties.Mask.SaveLiteral = CType(resources.GetObject("dtDiagnosisDate.Properties.Mask.SaveLiteral"), Boolean)
        Me.dtDiagnosisDate.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtDiagnosisDate.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtDiagnosisDate.Properties.NullValuePrompt = resources.GetString("dtDiagnosisDate.Properties.NullValuePrompt")
        Me.dtDiagnosisDate.Tag = ""
        '
        'lblDiagnosis
        '
        resources.ApplyResources(Me.lblDiagnosis, "lblDiagnosis")
        Me.lblDiagnosis.Name = "lblDiagnosis"
        '
        'cbDiagnosis
        '
        resources.ApplyResources(Me.cbDiagnosis, "cbDiagnosis")
        Me.cbDiagnosis.Name = "cbDiagnosis"
        Me.cbDiagnosis.Properties.Appearance.Options.UseFont = True
        Me.cbDiagnosis.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbDiagnosis.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbDiagnosis.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbDiagnosis.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbDiagnosis.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbDiagnosis.Properties.AutoHeight = CType(resources.GetObject("cbDiagnosis.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject7.Options.UseFont = True
        Me.cbDiagnosis.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbDiagnosis.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbDiagnosis.Properties.Buttons1"), CType(resources.GetObject("cbDiagnosis.Properties.Buttons2"), Integer), CType(resources.GetObject("cbDiagnosis.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbDiagnosis.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbDiagnosis.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbDiagnosis.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbDiagnosis.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject7, resources.GetString("cbDiagnosis.Properties.Buttons8"), CType(resources.GetObject("cbDiagnosis.Properties.Buttons9"), Object), CType(resources.GetObject("cbDiagnosis.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbDiagnosis.Properties.Buttons11"), Boolean))})
        Me.cbDiagnosis.Properties.NullText = resources.GetString("cbDiagnosis.Properties.NullText")
        Me.cbDiagnosis.Properties.NullValuePrompt = resources.GetString("cbDiagnosis.Properties.NullValuePrompt")
        Me.cbDiagnosis.Tag = "{M}"
        '
        'btnSearch
        '
        Me.btnSearch.Appearance.Options.UseFont = True
        Me.btnSearch.Appearance.Options.UseTextOptions = True
        Me.btnSearch.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.btnSearch.Image = Global.eidss.My.Resources.Resources.Search_for_Duplicates2
        Me.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        resources.ApplyResources(Me.btnSearch, "btnSearch")
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.TabStop = False
        '
        'gpDemographicInformation
        '
        Me.gpDemographicInformation.Appearance.Options.UseFont = True
        Me.gpDemographicInformation.AppearanceCaption.Options.UseFont = True
        Me.gpDemographicInformation.Controls.Add(Me.dtLastVisitToEmployer)
        Me.gpDemographicInformation.Controls.Add(Me.lblLastVisitToEmployer)
        Me.gpDemographicInformation.Controls.Add(Me.lblAge)
        Me.gpDemographicInformation.Controls.Add(Me.PatientInfo)
        Me.gpDemographicInformation.Controls.Add(Me.cbAgeUnits)
        Me.gpDemographicInformation.Controls.Add(Me.txtAge)
        resources.ApplyResources(Me.gpDemographicInformation, "gpDemographicInformation")
        Me.gpDemographicInformation.Name = "gpDemographicInformation"
        Me.gpDemographicInformation.TabStop = True
        '
        'dtLastVisitToEmployer
        '
        resources.ApplyResources(Me.dtLastVisitToEmployer, "dtLastVisitToEmployer")
        Me.dtLastVisitToEmployer.Name = "dtLastVisitToEmployer"
        Me.dtLastVisitToEmployer.Properties.Appearance.Options.UseFont = True
        Me.dtLastVisitToEmployer.Properties.AppearanceDisabled.Options.UseFont = True
        Me.dtLastVisitToEmployer.Properties.AppearanceDropDown.Options.UseFont = True
        Me.dtLastVisitToEmployer.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.dtLastVisitToEmployer.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = True
        Me.dtLastVisitToEmployer.Properties.AppearanceDropDownHighlight.Options.UseFont = True
        Me.dtLastVisitToEmployer.Properties.AppearanceFocused.Options.UseFont = True
        Me.dtLastVisitToEmployer.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.dtLastVisitToEmployer.Properties.AppearanceWeekNumber.Options.UseFont = True
        Me.dtLastVisitToEmployer.Properties.AutoHeight = CType(resources.GetObject("dtLastVisitToEmployer.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject8.Options.UseFont = True
        Me.dtLastVisitToEmployer.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtLastVisitToEmployer.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("dtLastVisitToEmployer.Properties.Buttons1"), CType(resources.GetObject("dtLastVisitToEmployer.Properties.Buttons2"), Integer), CType(resources.GetObject("dtLastVisitToEmployer.Properties.Buttons3"), Boolean), CType(resources.GetObject("dtLastVisitToEmployer.Properties.Buttons4"), Boolean), CType(resources.GetObject("dtLastVisitToEmployer.Properties.Buttons5"), Boolean), CType(resources.GetObject("dtLastVisitToEmployer.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("dtLastVisitToEmployer.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject8, resources.GetString("dtLastVisitToEmployer.Properties.Buttons8"), CType(resources.GetObject("dtLastVisitToEmployer.Properties.Buttons9"), Object), CType(resources.GetObject("dtLastVisitToEmployer.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("dtLastVisitToEmployer.Properties.Buttons11"), Boolean))})
        Me.dtLastVisitToEmployer.Properties.CalendarTimeProperties.Appearance.Options.UseFont = True
        Me.dtLastVisitToEmployer.Properties.CalendarTimeProperties.AppearanceDisabled.Options.UseFont = True
        Me.dtLastVisitToEmployer.Properties.CalendarTimeProperties.AppearanceFocused.Options.UseFont = True
        Me.dtLastVisitToEmployer.Properties.CalendarTimeProperties.AppearanceReadOnly.Options.UseFont = True
        Me.dtLastVisitToEmployer.Properties.CalendarTimeProperties.AutoHeight = CType(resources.GetObject("dtLastVisitToEmployer.Properties.CalendarTimeProperties.AutoHeight"), Boolean)
        SerializableAppearanceObject9.Options.UseFont = True
        Me.dtLastVisitToEmployer.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtLastVisitToEmployer.Properties.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("dtLastVisitToEmployer.Properties.CalendarTimeProperties.Buttons1"), CType(resources.GetObject("dtLastVisitToEmployer.Properties.CalendarTimeProperties.Buttons2"), Integer), CType(resources.GetObject("dtLastVisitToEmployer.Properties.CalendarTimeProperties.Buttons3"), Boolean), CType(resources.GetObject("dtLastVisitToEmployer.Properties.CalendarTimeProperties.Buttons4"), Boolean), CType(resources.GetObject("dtLastVisitToEmployer.Properties.CalendarTimeProperties.Buttons5"), Boolean), CType(resources.GetObject("dtLastVisitToEmployer.Properties.CalendarTimeProperties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("dtLastVisitToEmployer.Properties.CalendarTimeProperties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject9, resources.GetString("dtLastVisitToEmployer.Properties.CalendarTimeProperties.Buttons8"), CType(resources.GetObject("dtLastVisitToEmployer.Properties.CalendarTimeProperties.Buttons9"), Object), CType(resources.GetObject("dtLastVisitToEmployer.Properties.CalendarTimeProperties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("dtLastVisitToEmployer.Properties.CalendarTimeProperties.Buttons11"), Boolean))})
        Me.dtLastVisitToEmployer.Properties.CalendarTimeProperties.Mask.EditMask = resources.GetString("dtLastVisitToEmployer.Properties.CalendarTimeProperties.Mask.EditMask")
        Me.dtLastVisitToEmployer.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtLastVisitToEmployer.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtLastVisitToEmployer.Properties.CalendarTimeProperties.Mask.MaskType = CType(resources.GetObject("dtLastVisitToEmployer.Properties.CalendarTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtLastVisitToEmployer.Properties.CalendarTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("dtLastVisitToEmployer.Properties.CalendarTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.dtLastVisitToEmployer.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtLastVisitToEmployer.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtLastVisitToEmployer.Properties.CalendarTimeProperties.NullValuePrompt = resources.GetString("dtLastVisitToEmployer.Properties.CalendarTimeProperties.NullValuePrompt")
        Me.dtLastVisitToEmployer.Properties.Mask.BeepOnError = CType(resources.GetObject("dtLastVisitToEmployer.Properties.Mask.BeepOnError"), Boolean)
        Me.dtLastVisitToEmployer.Properties.Mask.EditMask = resources.GetString("dtLastVisitToEmployer.Properties.Mask.EditMask")
        Me.dtLastVisitToEmployer.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtLastVisitToEmployer.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtLastVisitToEmployer.Properties.Mask.MaskType = CType(resources.GetObject("dtLastVisitToEmployer.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtLastVisitToEmployer.Properties.Mask.SaveLiteral = CType(resources.GetObject("dtLastVisitToEmployer.Properties.Mask.SaveLiteral"), Boolean)
        Me.dtLastVisitToEmployer.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtLastVisitToEmployer.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtLastVisitToEmployer.Properties.NullValuePrompt = resources.GetString("dtLastVisitToEmployer.Properties.NullValuePrompt")
        Me.dtLastVisitToEmployer.Tag = ""
        '
        'lblLastVisitToEmployer
        '
        resources.ApplyResources(Me.lblLastVisitToEmployer, "lblLastVisitToEmployer")
        Me.lblLastVisitToEmployer.Name = "lblLastVisitToEmployer"
        '
        'lblAge
        '
        resources.ApplyResources(Me.lblAge, "lblAge")
        Me.lblAge.Name = "lblAge"
        '
        'PatientInfo
        '
        Me.PatientInfo.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.PatientInfo, "PatientInfo")
        Me.PatientInfo.FormID = Nothing
        Me.PatientInfo.HelpTopicID = Nothing
        Me.PatientInfo.KeyFieldName = Nothing
        Me.PatientInfo.MaxAge = 0
        Me.PatientInfo.MultiSelect = False
        Me.PatientInfo.Name = "PatientInfo"
        Me.PatientInfo.ObjectName = "Patient"
        Me.PatientInfo.TableName = "tlbHuman"
        '
        'cbAgeUnits
        '
        resources.ApplyResources(Me.cbAgeUnits, "cbAgeUnits")
        Me.cbAgeUnits.Name = "cbAgeUnits"
        Me.cbAgeUnits.Properties.Appearance.Options.UseFont = True
        Me.cbAgeUnits.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbAgeUnits.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbAgeUnits.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbAgeUnits.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbAgeUnits.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbAgeUnits.Properties.AutoHeight = CType(resources.GetObject("cbAgeUnits.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject10.Options.UseFont = True
        Me.cbAgeUnits.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbAgeUnits.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbAgeUnits.Properties.Buttons1"), CType(resources.GetObject("cbAgeUnits.Properties.Buttons2"), Integer), CType(resources.GetObject("cbAgeUnits.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbAgeUnits.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbAgeUnits.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbAgeUnits.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbAgeUnits.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject10, resources.GetString("cbAgeUnits.Properties.Buttons8"), CType(resources.GetObject("cbAgeUnits.Properties.Buttons9"), Object), CType(resources.GetObject("cbAgeUnits.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbAgeUnits.Properties.Buttons11"), Boolean))})
        Me.cbAgeUnits.Properties.NullText = resources.GetString("cbAgeUnits.Properties.NullText")
        Me.cbAgeUnits.Properties.NullValuePrompt = resources.GetString("cbAgeUnits.Properties.NullValuePrompt")
        Me.cbAgeUnits.TabStop = False
        '
        'txtAge
        '
        resources.ApplyResources(Me.txtAge, "txtAge")
        Me.txtAge.Name = "txtAge"
        Me.txtAge.Properties.AccessibleDescription = resources.GetString("txtAge.Properties.AccessibleDescription")
        Me.txtAge.Properties.Appearance.Options.UseFont = True
        Me.txtAge.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtAge.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtAge.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtAge.Properties.AutoHeight = CType(resources.GetObject("txtAge.Properties.AutoHeight"), Boolean)
        Me.txtAge.Properties.Mask.EditMask = resources.GetString("txtAge.Properties.Mask.EditMask")
        Me.txtAge.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtAge.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtAge.Properties.Mask.MaskType = CType(resources.GetObject("txtAge.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.txtAge.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtAge.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtAge.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtAge.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtAge.Properties.NullValuePrompt = resources.GetString("txtAge.Properties.NullValuePrompt")
        Me.txtAge.TabStop = False
        '
        'gpGeneralInformation
        '
        Me.gpGeneralInformation.Appearance.Options.UseFont = True
        Me.gpGeneralInformation.AppearanceCaption.Options.UseFont = True
        Me.gpGeneralInformation.Controls.Add(Me.cbReceivedByName)
        Me.gpGeneralInformation.Controls.Add(Me.lblReceivedByName)
        Me.gpGeneralInformation.Controls.Add(Me.cbSentByName)
        Me.gpGeneralInformation.Controls.Add(Me.lblSentByName)
        Me.gpGeneralInformation.Controls.Add(Me.lblSentBy)
        Me.gpGeneralInformation.Controls.Add(Me.lblReportingDate)
        Me.gpGeneralInformation.Controls.Add(Me.cbReceivedInst)
        Me.gpGeneralInformation.Controls.Add(Me.lblReceivedInst)
        Me.gpGeneralInformation.Controls.Add(Me.cbRepSource)
        Me.gpGeneralInformation.Controls.Add(Me.lblRepSource)
        Me.gpGeneralInformation.Controls.Add(Me.dtReportingDate)
        Me.gpGeneralInformation.Controls.Add(Me.lblReceivedBy)
        resources.ApplyResources(Me.gpGeneralInformation, "gpGeneralInformation")
        Me.gpGeneralInformation.Name = "gpGeneralInformation"
        Me.gpGeneralInformation.TabStop = True
        '
        'cbReceivedByName
        '
        resources.ApplyResources(Me.cbReceivedByName, "cbReceivedByName")
        Me.cbReceivedByName.Name = "cbReceivedByName"
        Me.cbReceivedByName.Properties.Appearance.Options.UseFont = True
        Me.cbReceivedByName.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbReceivedByName.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbReceivedByName.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbReceivedByName.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbReceivedByName.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbReceivedByName.Properties.AutoHeight = CType(resources.GetObject("cbReceivedByName.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject11.Options.UseFont = True
        Me.cbReceivedByName.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbReceivedByName.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbReceivedByName.Properties.Buttons1"), CType(resources.GetObject("cbReceivedByName.Properties.Buttons2"), Integer), CType(resources.GetObject("cbReceivedByName.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbReceivedByName.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbReceivedByName.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbReceivedByName.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbReceivedByName.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject11, resources.GetString("cbReceivedByName.Properties.Buttons8"), CType(resources.GetObject("cbReceivedByName.Properties.Buttons9"), Object), CType(resources.GetObject("cbReceivedByName.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbReceivedByName.Properties.Buttons11"), Boolean))})
        Me.cbReceivedByName.Properties.NullText = resources.GetString("cbReceivedByName.Properties.NullText")
        Me.cbReceivedByName.Properties.NullValuePrompt = resources.GetString("cbReceivedByName.Properties.NullValuePrompt")
        Me.cbReceivedByName.Tag = ""
        '
        'lblReceivedByName
        '
        resources.ApplyResources(Me.lblReceivedByName, "lblReceivedByName")
        Me.lblReceivedByName.Name = "lblReceivedByName"
        '
        'cbSentByName
        '
        resources.ApplyResources(Me.cbSentByName, "cbSentByName")
        Me.cbSentByName.Name = "cbSentByName"
        Me.cbSentByName.Properties.Appearance.Options.UseFont = True
        Me.cbSentByName.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbSentByName.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbSentByName.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbSentByName.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbSentByName.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbSentByName.Properties.AutoHeight = CType(resources.GetObject("cbSentByName.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject12.Options.UseFont = True
        Me.cbSentByName.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSentByName.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbSentByName.Properties.Buttons1"), CType(resources.GetObject("cbSentByName.Properties.Buttons2"), Integer), CType(resources.GetObject("cbSentByName.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbSentByName.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbSentByName.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbSentByName.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbSentByName.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject12, resources.GetString("cbSentByName.Properties.Buttons8"), CType(resources.GetObject("cbSentByName.Properties.Buttons9"), Object), CType(resources.GetObject("cbSentByName.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbSentByName.Properties.Buttons11"), Boolean))})
        Me.cbSentByName.Properties.NullText = resources.GetString("cbSentByName.Properties.NullText")
        Me.cbSentByName.Properties.NullValuePrompt = resources.GetString("cbSentByName.Properties.NullValuePrompt")
        Me.cbSentByName.Tag = ""
        '
        'lblSentByName
        '
        resources.ApplyResources(Me.lblSentByName, "lblSentByName")
        Me.lblSentByName.Name = "lblSentByName"
        '
        'lblSentBy
        '
        resources.ApplyResources(Me.lblSentBy, "lblSentBy")
        Me.lblSentBy.Name = "lblSentBy"
        '
        'lblReportingDate
        '
        resources.ApplyResources(Me.lblReportingDate, "lblReportingDate")
        Me.lblReportingDate.Name = "lblReportingDate"
        '
        'cbReceivedInst
        '
        resources.ApplyResources(Me.cbReceivedInst, "cbReceivedInst")
        Me.cbReceivedInst.Name = "cbReceivedInst"
        Me.cbReceivedInst.Properties.Appearance.Options.UseFont = True
        Me.cbReceivedInst.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbReceivedInst.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbReceivedInst.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbReceivedInst.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbReceivedInst.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbReceivedInst.Properties.AutoHeight = CType(resources.GetObject("cbReceivedInst.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject13.Options.UseFont = True
        Me.cbReceivedInst.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbReceivedInst.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbReceivedInst.Properties.Buttons1"), CType(resources.GetObject("cbReceivedInst.Properties.Buttons2"), Integer), CType(resources.GetObject("cbReceivedInst.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbReceivedInst.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbReceivedInst.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbReceivedInst.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbReceivedInst.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject13, resources.GetString("cbReceivedInst.Properties.Buttons8"), CType(resources.GetObject("cbReceivedInst.Properties.Buttons9"), Object), CType(resources.GetObject("cbReceivedInst.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbReceivedInst.Properties.Buttons11"), Boolean))})
        Me.cbReceivedInst.Properties.NullText = resources.GetString("cbReceivedInst.Properties.NullText")
        Me.cbReceivedInst.Properties.NullValuePrompt = resources.GetString("cbReceivedInst.Properties.NullValuePrompt")
        Me.cbReceivedInst.Tag = ""
        '
        'lblReceivedInst
        '
        resources.ApplyResources(Me.lblReceivedInst, "lblReceivedInst")
        Me.lblReceivedInst.Name = "lblReceivedInst"
        '
        'cbRepSource
        '
        resources.ApplyResources(Me.cbRepSource, "cbRepSource")
        Me.cbRepSource.Name = "cbRepSource"
        Me.cbRepSource.Properties.Appearance.Options.UseFont = True
        Me.cbRepSource.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbRepSource.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbRepSource.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbRepSource.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbRepSource.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbRepSource.Properties.AutoHeight = CType(resources.GetObject("cbRepSource.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject14.Options.UseFont = True
        Me.cbRepSource.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbRepSource.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbRepSource.Properties.Buttons1"), CType(resources.GetObject("cbRepSource.Properties.Buttons2"), Integer), CType(resources.GetObject("cbRepSource.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbRepSource.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbRepSource.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbRepSource.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbRepSource.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject14, resources.GetString("cbRepSource.Properties.Buttons8"), CType(resources.GetObject("cbRepSource.Properties.Buttons9"), Object), CType(resources.GetObject("cbRepSource.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbRepSource.Properties.Buttons11"), Boolean))})
        Me.cbRepSource.Properties.NullText = resources.GetString("cbRepSource.Properties.NullText")
        Me.cbRepSource.Properties.NullValuePrompt = resources.GetString("cbRepSource.Properties.NullValuePrompt")
        Me.cbRepSource.Tag = ""
        '
        'lblRepSource
        '
        resources.ApplyResources(Me.lblRepSource, "lblRepSource")
        Me.lblRepSource.Name = "lblRepSource"
        '
        'dtReportingDate
        '
        resources.ApplyResources(Me.dtReportingDate, "dtReportingDate")
        Me.dtReportingDate.Name = "dtReportingDate"
        Me.dtReportingDate.Properties.Appearance.Options.UseFont = True
        Me.dtReportingDate.Properties.AppearanceDisabled.Options.UseFont = True
        Me.dtReportingDate.Properties.AppearanceDropDown.Options.UseFont = True
        Me.dtReportingDate.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.dtReportingDate.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = True
        Me.dtReportingDate.Properties.AppearanceDropDownHighlight.Options.UseFont = True
        Me.dtReportingDate.Properties.AppearanceFocused.Options.UseFont = True
        Me.dtReportingDate.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.dtReportingDate.Properties.AppearanceWeekNumber.Options.UseFont = True
        Me.dtReportingDate.Properties.AutoHeight = CType(resources.GetObject("dtReportingDate.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject15.Options.UseFont = True
        Me.dtReportingDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtReportingDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("dtReportingDate.Properties.Buttons1"), CType(resources.GetObject("dtReportingDate.Properties.Buttons2"), Integer), CType(resources.GetObject("dtReportingDate.Properties.Buttons3"), Boolean), CType(resources.GetObject("dtReportingDate.Properties.Buttons4"), Boolean), CType(resources.GetObject("dtReportingDate.Properties.Buttons5"), Boolean), CType(resources.GetObject("dtReportingDate.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("dtReportingDate.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject15, resources.GetString("dtReportingDate.Properties.Buttons8"), CType(resources.GetObject("dtReportingDate.Properties.Buttons9"), Object), CType(resources.GetObject("dtReportingDate.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("dtReportingDate.Properties.Buttons11"), Boolean))})
        Me.dtReportingDate.Properties.CalendarTimeProperties.Appearance.Options.UseFont = True
        Me.dtReportingDate.Properties.CalendarTimeProperties.AppearanceDisabled.Options.UseFont = True
        Me.dtReportingDate.Properties.CalendarTimeProperties.AppearanceFocused.Options.UseFont = True
        Me.dtReportingDate.Properties.CalendarTimeProperties.AppearanceReadOnly.Options.UseFont = True
        Me.dtReportingDate.Properties.CalendarTimeProperties.AutoHeight = CType(resources.GetObject("dtReportingDate.Properties.CalendarTimeProperties.AutoHeight"), Boolean)
        SerializableAppearanceObject16.Options.UseFont = True
        Me.dtReportingDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtReportingDate.Properties.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("dtReportingDate.Properties.CalendarTimeProperties.Buttons1"), CType(resources.GetObject("dtReportingDate.Properties.CalendarTimeProperties.Buttons2"), Integer), CType(resources.GetObject("dtReportingDate.Properties.CalendarTimeProperties.Buttons3"), Boolean), CType(resources.GetObject("dtReportingDate.Properties.CalendarTimeProperties.Buttons4"), Boolean), CType(resources.GetObject("dtReportingDate.Properties.CalendarTimeProperties.Buttons5"), Boolean), CType(resources.GetObject("dtReportingDate.Properties.CalendarTimeProperties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("dtReportingDate.Properties.CalendarTimeProperties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject16, resources.GetString("dtReportingDate.Properties.CalendarTimeProperties.Buttons8"), CType(resources.GetObject("dtReportingDate.Properties.CalendarTimeProperties.Buttons9"), Object), CType(resources.GetObject("dtReportingDate.Properties.CalendarTimeProperties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("dtReportingDate.Properties.CalendarTimeProperties.Buttons11"), Boolean))})
        Me.dtReportingDate.Properties.CalendarTimeProperties.Mask.EditMask = resources.GetString("dtReportingDate.Properties.CalendarTimeProperties.Mask.EditMask")
        Me.dtReportingDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtReportingDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtReportingDate.Properties.CalendarTimeProperties.Mask.MaskType = CType(resources.GetObject("dtReportingDate.Properties.CalendarTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtReportingDate.Properties.CalendarTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("dtReportingDate.Properties.CalendarTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.dtReportingDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtReportingDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtReportingDate.Properties.CalendarTimeProperties.NullValuePrompt = resources.GetString("dtReportingDate.Properties.CalendarTimeProperties.NullValuePrompt")
        Me.dtReportingDate.Properties.Mask.BeepOnError = CType(resources.GetObject("dtReportingDate.Properties.Mask.BeepOnError"), Boolean)
        Me.dtReportingDate.Properties.Mask.EditMask = resources.GetString("dtReportingDate.Properties.Mask.EditMask")
        Me.dtReportingDate.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtReportingDate.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtReportingDate.Properties.Mask.MaskType = CType(resources.GetObject("dtReportingDate.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtReportingDate.Properties.Mask.SaveLiteral = CType(resources.GetObject("dtReportingDate.Properties.Mask.SaveLiteral"), Boolean)
        Me.dtReportingDate.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtReportingDate.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtReportingDate.Properties.NullValuePrompt = resources.GetString("dtReportingDate.Properties.NullValuePrompt")
        Me.dtReportingDate.Tag = ""
        '
        'lblReceivedBy
        '
        resources.ApplyResources(Me.lblReceivedBy, "lblReceivedBy")
        Me.lblReceivedBy.Name = "lblReceivedBy"
        '
        'gpClinicalInformation
        '
        Me.gpClinicalInformation.Appearance.Options.UseFont = True
        Me.gpClinicalInformation.AppearanceCaption.Options.UseFont = True
        Me.gpClinicalInformation.Controls.Add(Me.cbCurrentPatientLocation)
        Me.gpClinicalInformation.Controls.Add(Me.lblChangedDiagnosis)
        Me.gpClinicalInformation.Controls.Add(Me.txtOtherLocation)
        Me.gpClinicalInformation.Controls.Add(Me.lblChangedDiagnosisDate)
        Me.gpClinicalInformation.Controls.Add(Me.dtChangedDiagnosisDate)
        Me.gpClinicalInformation.Controls.Add(Me.cbChangedDiagnosis)
        Me.gpClinicalInformation.Controls.Add(Me.cbFinalState)
        Me.gpClinicalInformation.Controls.Add(Me.lblHospitalizedTo)
        Me.gpClinicalInformation.Controls.Add(Me.cbHospitalizedTo)
        Me.gpClinicalInformation.Controls.Add(Me.deOnsetDate)
        Me.gpClinicalInformation.Controls.Add(Me.lblFinalState)
        Me.gpClinicalInformation.Controls.Add(Me.memoNote)
        Me.gpClinicalInformation.Controls.Add(Me.lblCurrentPatientLocation)
        Me.gpClinicalInformation.Controls.Add(Me.lblNote)
        Me.gpClinicalInformation.Controls.Add(Me.lblOnsetDate)
        Me.gpClinicalInformation.Controls.Add(Me.lblOtherLocation)
        resources.ApplyResources(Me.gpClinicalInformation, "gpClinicalInformation")
        Me.gpClinicalInformation.Name = "gpClinicalInformation"
        Me.gpClinicalInformation.TabStop = True
        '
        'cbCurrentPatientLocation
        '
        resources.ApplyResources(Me.cbCurrentPatientLocation, "cbCurrentPatientLocation")
        Me.cbCurrentPatientLocation.Name = "cbCurrentPatientLocation"
        Me.cbCurrentPatientLocation.Properties.Appearance.Options.UseFont = True
        Me.cbCurrentPatientLocation.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbCurrentPatientLocation.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbCurrentPatientLocation.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbCurrentPatientLocation.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbCurrentPatientLocation.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbCurrentPatientLocation.Properties.AutoHeight = CType(resources.GetObject("cbCurrentPatientLocation.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject17.Options.UseFont = True
        Me.cbCurrentPatientLocation.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbCurrentPatientLocation.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbCurrentPatientLocation.Properties.Buttons1"), CType(resources.GetObject("cbCurrentPatientLocation.Properties.Buttons2"), Integer), CType(resources.GetObject("cbCurrentPatientLocation.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbCurrentPatientLocation.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbCurrentPatientLocation.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbCurrentPatientLocation.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbCurrentPatientLocation.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject17, resources.GetString("cbCurrentPatientLocation.Properties.Buttons8"), CType(resources.GetObject("cbCurrentPatientLocation.Properties.Buttons9"), Object), CType(resources.GetObject("cbCurrentPatientLocation.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbCurrentPatientLocation.Properties.Buttons11"), Boolean))})
        Me.cbCurrentPatientLocation.Properties.NullText = resources.GetString("cbCurrentPatientLocation.Properties.NullText")
        Me.cbCurrentPatientLocation.Properties.NullValuePrompt = resources.GetString("cbCurrentPatientLocation.Properties.NullValuePrompt")
        '
        'lblChangedDiagnosis
        '
        resources.ApplyResources(Me.lblChangedDiagnosis, "lblChangedDiagnosis")
        Me.lblChangedDiagnosis.Name = "lblChangedDiagnosis"
        '
        'txtOtherLocation
        '
        resources.ApplyResources(Me.txtOtherLocation, "txtOtherLocation")
        Me.txtOtherLocation.Name = "txtOtherLocation"
        Me.txtOtherLocation.Properties.AccessibleDescription = resources.GetString("txtOtherLocation.Properties.AccessibleDescription")
        Me.txtOtherLocation.Properties.Appearance.Options.UseFont = True
        Me.txtOtherLocation.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtOtherLocation.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtOtherLocation.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtOtherLocation.Properties.AutoHeight = CType(resources.GetObject("txtOtherLocation.Properties.AutoHeight"), Boolean)
        Me.txtOtherLocation.Properties.Mask.EditMask = resources.GetString("txtOtherLocation.Properties.Mask.EditMask")
        Me.txtOtherLocation.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtOtherLocation.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtOtherLocation.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtOtherLocation.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtOtherLocation.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtOtherLocation.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtOtherLocation.Properties.NullValuePrompt = resources.GetString("txtOtherLocation.Properties.NullValuePrompt")
        '
        'lblChangedDiagnosisDate
        '
        resources.ApplyResources(Me.lblChangedDiagnosisDate, "lblChangedDiagnosisDate")
        Me.lblChangedDiagnosisDate.Name = "lblChangedDiagnosisDate"
        '
        'dtChangedDiagnosisDate
        '
        resources.ApplyResources(Me.dtChangedDiagnosisDate, "dtChangedDiagnosisDate")
        Me.dtChangedDiagnosisDate.Name = "dtChangedDiagnosisDate"
        Me.dtChangedDiagnosisDate.Properties.Appearance.Options.UseFont = True
        Me.dtChangedDiagnosisDate.Properties.AppearanceDisabled.Options.UseFont = True
        Me.dtChangedDiagnosisDate.Properties.AppearanceDropDown.Options.UseFont = True
        Me.dtChangedDiagnosisDate.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.dtChangedDiagnosisDate.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = True
        Me.dtChangedDiagnosisDate.Properties.AppearanceDropDownHighlight.Options.UseFont = True
        Me.dtChangedDiagnosisDate.Properties.AppearanceFocused.Options.UseFont = True
        Me.dtChangedDiagnosisDate.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.dtChangedDiagnosisDate.Properties.AppearanceWeekNumber.Options.UseFont = True
        Me.dtChangedDiagnosisDate.Properties.AutoHeight = CType(resources.GetObject("dtChangedDiagnosisDate.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject18.Options.UseFont = True
        Me.dtChangedDiagnosisDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtChangedDiagnosisDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("dtChangedDiagnosisDate.Properties.Buttons1"), CType(resources.GetObject("dtChangedDiagnosisDate.Properties.Buttons2"), Integer), CType(resources.GetObject("dtChangedDiagnosisDate.Properties.Buttons3"), Boolean), CType(resources.GetObject("dtChangedDiagnosisDate.Properties.Buttons4"), Boolean), CType(resources.GetObject("dtChangedDiagnosisDate.Properties.Buttons5"), Boolean), CType(resources.GetObject("dtChangedDiagnosisDate.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("dtChangedDiagnosisDate.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject18, resources.GetString("dtChangedDiagnosisDate.Properties.Buttons8"), CType(resources.GetObject("dtChangedDiagnosisDate.Properties.Buttons9"), Object), CType(resources.GetObject("dtChangedDiagnosisDate.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("dtChangedDiagnosisDate.Properties.Buttons11"), Boolean))})
        Me.dtChangedDiagnosisDate.Properties.CalendarTimeProperties.Appearance.Options.UseFont = True
        Me.dtChangedDiagnosisDate.Properties.CalendarTimeProperties.AppearanceDisabled.Options.UseFont = True
        Me.dtChangedDiagnosisDate.Properties.CalendarTimeProperties.AppearanceFocused.Options.UseFont = True
        Me.dtChangedDiagnosisDate.Properties.CalendarTimeProperties.AppearanceReadOnly.Options.UseFont = True
        Me.dtChangedDiagnosisDate.Properties.CalendarTimeProperties.AutoHeight = CType(resources.GetObject("dtChangedDiagnosisDate.Properties.CalendarTimeProperties.AutoHeight"), Boolean)
        SerializableAppearanceObject19.Options.UseFont = True
        Me.dtChangedDiagnosisDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtChangedDiagnosisDate.Properties.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("dtChangedDiagnosisDate.Properties.CalendarTimeProperties.Buttons1"), CType(resources.GetObject("dtChangedDiagnosisDate.Properties.CalendarTimeProperties.Buttons2"), Integer), CType(resources.GetObject("dtChangedDiagnosisDate.Properties.CalendarTimeProperties.Buttons3"), Boolean), CType(resources.GetObject("dtChangedDiagnosisDate.Properties.CalendarTimeProperties.Buttons4"), Boolean), CType(resources.GetObject("dtChangedDiagnosisDate.Properties.CalendarTimeProperties.Buttons5"), Boolean), CType(resources.GetObject("dtChangedDiagnosisDate.Properties.CalendarTimeProperties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("dtChangedDiagnosisDate.Properties.CalendarTimeProperties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject19, resources.GetString("dtChangedDiagnosisDate.Properties.CalendarTimeProperties.Buttons8"), CType(resources.GetObject("dtChangedDiagnosisDate.Properties.CalendarTimeProperties.Buttons9"), Object), CType(resources.GetObject("dtChangedDiagnosisDate.Properties.CalendarTimeProperties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("dtChangedDiagnosisDate.Properties.CalendarTimeProperties.Buttons11"), Boolean))})
        Me.dtChangedDiagnosisDate.Properties.CalendarTimeProperties.Mask.EditMask = resources.GetString("dtChangedDiagnosisDate.Properties.CalendarTimeProperties.Mask.EditMask")
        Me.dtChangedDiagnosisDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtChangedDiagnosisDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtChangedDiagnosisDate.Properties.CalendarTimeProperties.Mask.MaskType = CType(resources.GetObject("dtChangedDiagnosisDate.Properties.CalendarTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtChangedDiagnosisDate.Properties.CalendarTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("dtChangedDiagnosisDate.Properties.CalendarTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.dtChangedDiagnosisDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtChangedDiagnosisDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtChangedDiagnosisDate.Properties.CalendarTimeProperties.NullValuePrompt = resources.GetString("dtChangedDiagnosisDate.Properties.CalendarTimeProperties.NullValuePrompt")
        Me.dtChangedDiagnosisDate.Properties.Mask.BeepOnError = CType(resources.GetObject("dtChangedDiagnosisDate.Properties.Mask.BeepOnError"), Boolean)
        Me.dtChangedDiagnosisDate.Properties.Mask.EditMask = resources.GetString("dtChangedDiagnosisDate.Properties.Mask.EditMask")
        Me.dtChangedDiagnosisDate.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtChangedDiagnosisDate.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtChangedDiagnosisDate.Properties.Mask.MaskType = CType(resources.GetObject("dtChangedDiagnosisDate.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtChangedDiagnosisDate.Properties.Mask.SaveLiteral = CType(resources.GetObject("dtChangedDiagnosisDate.Properties.Mask.SaveLiteral"), Boolean)
        Me.dtChangedDiagnosisDate.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtChangedDiagnosisDate.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtChangedDiagnosisDate.Properties.NullValuePrompt = resources.GetString("dtChangedDiagnosisDate.Properties.NullValuePrompt")
        Me.dtChangedDiagnosisDate.Tag = ""
        '
        'cbChangedDiagnosis
        '
        resources.ApplyResources(Me.cbChangedDiagnosis, "cbChangedDiagnosis")
        Me.cbChangedDiagnosis.Name = "cbChangedDiagnosis"
        Me.cbChangedDiagnosis.Properties.Appearance.Options.UseFont = True
        Me.cbChangedDiagnosis.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbChangedDiagnosis.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbChangedDiagnosis.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbChangedDiagnosis.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbChangedDiagnosis.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbChangedDiagnosis.Properties.AutoHeight = CType(resources.GetObject("cbChangedDiagnosis.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject20.Options.UseFont = True
        SerializableAppearanceObject21.Options.UseFont = True
        Me.cbChangedDiagnosis.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbChangedDiagnosis.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbChangedDiagnosis.Properties.Buttons1"), CType(resources.GetObject("cbChangedDiagnosis.Properties.Buttons2"), Integer), CType(resources.GetObject("cbChangedDiagnosis.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbChangedDiagnosis.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbChangedDiagnosis.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbChangedDiagnosis.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbChangedDiagnosis.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject20, resources.GetString("cbChangedDiagnosis.Properties.Buttons8"), CType(resources.GetObject("cbChangedDiagnosis.Properties.Buttons9"), Object), CType(resources.GetObject("cbChangedDiagnosis.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbChangedDiagnosis.Properties.Buttons11"), Boolean)), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbChangedDiagnosis.Properties.Buttons12"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbChangedDiagnosis.Properties.Buttons13"), CType(resources.GetObject("cbChangedDiagnosis.Properties.Buttons14"), Integer), CType(resources.GetObject("cbChangedDiagnosis.Properties.Buttons15"), Boolean), CType(resources.GetObject("cbChangedDiagnosis.Properties.Buttons16"), Boolean), CType(resources.GetObject("cbChangedDiagnosis.Properties.Buttons17"), Boolean), CType(resources.GetObject("cbChangedDiagnosis.Properties.Buttons18"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbChangedDiagnosis.Properties.Buttons19"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject21, resources.GetString("cbChangedDiagnosis.Properties.Buttons20"), resources.GetString("cbChangedDiagnosis.Properties.Buttons21"), CType(resources.GetObject("cbChangedDiagnosis.Properties.Buttons22"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbChangedDiagnosis.Properties.Buttons23"), Boolean))})
        Me.cbChangedDiagnosis.Properties.NullText = resources.GetString("cbChangedDiagnosis.Properties.NullText")
        Me.cbChangedDiagnosis.Properties.NullValuePrompt = resources.GetString("cbChangedDiagnosis.Properties.NullValuePrompt")
        Me.cbChangedDiagnosis.Tag = ""
        '
        'cbFinalState
        '
        resources.ApplyResources(Me.cbFinalState, "cbFinalState")
        Me.cbFinalState.Name = "cbFinalState"
        Me.cbFinalState.Properties.Appearance.Options.UseFont = True
        Me.cbFinalState.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbFinalState.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbFinalState.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbFinalState.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbFinalState.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbFinalState.Properties.AutoHeight = CType(resources.GetObject("cbFinalState.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject22.Options.UseFont = True
        Me.cbFinalState.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbFinalState.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbFinalState.Properties.Buttons1"), CType(resources.GetObject("cbFinalState.Properties.Buttons2"), Integer), CType(resources.GetObject("cbFinalState.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbFinalState.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbFinalState.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbFinalState.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbFinalState.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject22, resources.GetString("cbFinalState.Properties.Buttons8"), CType(resources.GetObject("cbFinalState.Properties.Buttons9"), Object), CType(resources.GetObject("cbFinalState.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbFinalState.Properties.Buttons11"), Boolean))})
        Me.cbFinalState.Properties.NullText = resources.GetString("cbFinalState.Properties.NullText")
        Me.cbFinalState.Properties.NullValuePrompt = resources.GetString("cbFinalState.Properties.NullValuePrompt")
        '
        'lblHospitalizedTo
        '
        resources.ApplyResources(Me.lblHospitalizedTo, "lblHospitalizedTo")
        Me.lblHospitalizedTo.Name = "lblHospitalizedTo"
        '
        'cbHospitalizedTo
        '
        resources.ApplyResources(Me.cbHospitalizedTo, "cbHospitalizedTo")
        Me.cbHospitalizedTo.Name = "cbHospitalizedTo"
        Me.cbHospitalizedTo.Properties.AccessibleDescription = resources.GetString("cbHospitalizedTo.Properties.AccessibleDescription")
        Me.cbHospitalizedTo.Properties.Appearance.Options.UseFont = True
        Me.cbHospitalizedTo.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbHospitalizedTo.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbHospitalizedTo.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbHospitalizedTo.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbHospitalizedTo.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbHospitalizedTo.Properties.AutoHeight = CType(resources.GetObject("cbHospitalizedTo.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject23.Options.UseFont = True
        Me.cbHospitalizedTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbHospitalizedTo.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbHospitalizedTo.Properties.Buttons1"), CType(resources.GetObject("cbHospitalizedTo.Properties.Buttons2"), Integer), CType(resources.GetObject("cbHospitalizedTo.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbHospitalizedTo.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbHospitalizedTo.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbHospitalizedTo.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbHospitalizedTo.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject23, resources.GetString("cbHospitalizedTo.Properties.Buttons8"), CType(resources.GetObject("cbHospitalizedTo.Properties.Buttons9"), Object), CType(resources.GetObject("cbHospitalizedTo.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbHospitalizedTo.Properties.Buttons11"), Boolean))})
        Me.cbHospitalizedTo.Properties.NullText = resources.GetString("cbHospitalizedTo.Properties.NullText")
        Me.cbHospitalizedTo.Properties.NullValuePrompt = resources.GetString("cbHospitalizedTo.Properties.NullValuePrompt")
        '
        'deOnsetDate
        '
        resources.ApplyResources(Me.deOnsetDate, "deOnsetDate")
        Me.deOnsetDate.Name = "deOnsetDate"
        Me.deOnsetDate.Properties.Appearance.Options.UseFont = True
        Me.deOnsetDate.Properties.AppearanceDisabled.Options.UseFont = True
        Me.deOnsetDate.Properties.AppearanceDropDown.Options.UseFont = True
        Me.deOnsetDate.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.deOnsetDate.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = True
        Me.deOnsetDate.Properties.AppearanceDropDownHighlight.Options.UseFont = True
        Me.deOnsetDate.Properties.AppearanceFocused.Options.UseFont = True
        Me.deOnsetDate.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.deOnsetDate.Properties.AppearanceWeekNumber.Options.UseFont = True
        Me.deOnsetDate.Properties.AutoHeight = CType(resources.GetObject("deOnsetDate.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject24.Options.UseFont = True
        Me.deOnsetDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("deOnsetDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("deOnsetDate.Properties.Buttons1"), CType(resources.GetObject("deOnsetDate.Properties.Buttons2"), Integer), CType(resources.GetObject("deOnsetDate.Properties.Buttons3"), Boolean), CType(resources.GetObject("deOnsetDate.Properties.Buttons4"), Boolean), CType(resources.GetObject("deOnsetDate.Properties.Buttons5"), Boolean), CType(resources.GetObject("deOnsetDate.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("deOnsetDate.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject24, resources.GetString("deOnsetDate.Properties.Buttons8"), CType(resources.GetObject("deOnsetDate.Properties.Buttons9"), Object), CType(resources.GetObject("deOnsetDate.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("deOnsetDate.Properties.Buttons11"), Boolean))})
        Me.deOnsetDate.Properties.CalendarTimeProperties.Appearance.Options.UseFont = True
        Me.deOnsetDate.Properties.CalendarTimeProperties.AppearanceDisabled.Options.UseFont = True
        Me.deOnsetDate.Properties.CalendarTimeProperties.AppearanceFocused.Options.UseFont = True
        Me.deOnsetDate.Properties.CalendarTimeProperties.AppearanceReadOnly.Options.UseFont = True
        Me.deOnsetDate.Properties.CalendarTimeProperties.AutoHeight = CType(resources.GetObject("deOnsetDate.Properties.CalendarTimeProperties.AutoHeight"), Boolean)
        SerializableAppearanceObject25.Options.UseFont = True
        Me.deOnsetDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("deOnsetDate.Properties.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("deOnsetDate.Properties.CalendarTimeProperties.Buttons1"), CType(resources.GetObject("deOnsetDate.Properties.CalendarTimeProperties.Buttons2"), Integer), CType(resources.GetObject("deOnsetDate.Properties.CalendarTimeProperties.Buttons3"), Boolean), CType(resources.GetObject("deOnsetDate.Properties.CalendarTimeProperties.Buttons4"), Boolean), CType(resources.GetObject("deOnsetDate.Properties.CalendarTimeProperties.Buttons5"), Boolean), CType(resources.GetObject("deOnsetDate.Properties.CalendarTimeProperties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("deOnsetDate.Properties.CalendarTimeProperties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject25, resources.GetString("deOnsetDate.Properties.CalendarTimeProperties.Buttons8"), CType(resources.GetObject("deOnsetDate.Properties.CalendarTimeProperties.Buttons9"), Object), CType(resources.GetObject("deOnsetDate.Properties.CalendarTimeProperties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("deOnsetDate.Properties.CalendarTimeProperties.Buttons11"), Boolean))})
        Me.deOnsetDate.Properties.CalendarTimeProperties.Mask.EditMask = resources.GetString("deOnsetDate.Properties.CalendarTimeProperties.Mask.EditMask")
        Me.deOnsetDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("deOnsetDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.deOnsetDate.Properties.CalendarTimeProperties.Mask.MaskType = CType(resources.GetObject("deOnsetDate.Properties.CalendarTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.deOnsetDate.Properties.CalendarTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("deOnsetDate.Properties.CalendarTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.deOnsetDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("deOnsetDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.deOnsetDate.Properties.CalendarTimeProperties.NullValuePrompt = resources.GetString("deOnsetDate.Properties.CalendarTimeProperties.NullValuePrompt")
        Me.deOnsetDate.Properties.Mask.BeepOnError = CType(resources.GetObject("deOnsetDate.Properties.Mask.BeepOnError"), Boolean)
        Me.deOnsetDate.Properties.Mask.EditMask = resources.GetString("deOnsetDate.Properties.Mask.EditMask")
        Me.deOnsetDate.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("deOnsetDate.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.deOnsetDate.Properties.Mask.MaskType = CType(resources.GetObject("deOnsetDate.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.deOnsetDate.Properties.Mask.SaveLiteral = CType(resources.GetObject("deOnsetDate.Properties.Mask.SaveLiteral"), Boolean)
        Me.deOnsetDate.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("deOnsetDate.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.deOnsetDate.Properties.NullValuePrompt = resources.GetString("deOnsetDate.Properties.NullValuePrompt")
        Me.deOnsetDate.Tag = ""
        '
        'lblFinalState
        '
        resources.ApplyResources(Me.lblFinalState, "lblFinalState")
        Me.lblFinalState.Name = "lblFinalState"
        '
        'memoNote
        '
        resources.ApplyResources(Me.memoNote, "memoNote")
        Me.memoNote.Name = "memoNote"
        Me.memoNote.Properties.Appearance.Options.UseFont = True
        Me.memoNote.Properties.AppearanceDisabled.Options.UseFont = True
        Me.memoNote.Properties.AppearanceFocused.Options.UseFont = True
        Me.memoNote.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.memoNote.Properties.MaxLength = 2000
        Me.memoNote.Properties.NullValuePrompt = resources.GetString("memoNote.Properties.NullValuePrompt")
        Me.memoNote.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both
        '
        'lblCurrentPatientLocation
        '
        resources.ApplyResources(Me.lblCurrentPatientLocation, "lblCurrentPatientLocation")
        Me.lblCurrentPatientLocation.Name = "lblCurrentPatientLocation"
        '
        'lblNote
        '
        resources.ApplyResources(Me.lblNote, "lblNote")
        Me.lblNote.Name = "lblNote"
        '
        'lblOnsetDate
        '
        resources.ApplyResources(Me.lblOnsetDate, "lblOnsetDate")
        Me.lblOnsetDate.Name = "lblOnsetDate"
        '
        'lblOtherLocation
        '
        resources.ApplyResources(Me.lblOtherLocation, "lblOtherLocation")
        Me.lblOtherLocation.Name = "lblOtherLocation"
        '
        'lblFormCompletionDate
        '
        resources.ApplyResources(Me.lblFormCompletionDate, "lblFormCompletionDate")
        Me.lblFormCompletionDate.Name = "lblFormCompletionDate"
        '
        'lblLocalID
        '
        resources.ApplyResources(Me.lblLocalID, "lblLocalID")
        Me.lblLocalID.Name = "lblLocalID"
        '
        'tpCaseInvestigation
        '
        Me.tpCaseInvestigation.Appearance.Header.Options.UseFont = True
        Me.tpCaseInvestigation.Appearance.HeaderActive.Options.UseFont = True
        Me.tpCaseInvestigation.Appearance.HeaderDisabled.Options.UseFont = True
        Me.tpCaseInvestigation.Appearance.HeaderHotTracked.Options.UseFont = True
        Me.tpCaseInvestigation.Appearance.PageClient.Options.UseFont = True
        Me.tpCaseInvestigation.Controls.Add(Me.tcCaseInvestigation)
        Me.tpCaseInvestigation.Name = "tpCaseInvestigation"
        resources.ApplyResources(Me.tpCaseInvestigation, "tpCaseInvestigation")
        '
        'tcCaseInvestigation
        '
        Me.tcCaseInvestigation.Appearance.Options.UseFont = True
        Me.tcCaseInvestigation.AppearancePage.Header.Options.UseFont = True
        Me.tcCaseInvestigation.AppearancePage.HeaderActive.Options.UseFont = True
        Me.tcCaseInvestigation.AppearancePage.HeaderDisabled.Options.UseFont = True
        Me.tcCaseInvestigation.AppearancePage.HeaderHotTracked.Options.UseFont = True
        Me.tcCaseInvestigation.AppearancePage.PageClient.Options.UseFont = True
        resources.ApplyResources(Me.tcCaseInvestigation, "tcCaseInvestigation")
        Me.tcCaseInvestigation.Name = "tcCaseInvestigation"
        Me.tcCaseInvestigation.SelectedTabPage = Me.tpDemographic
        Me.tcCaseInvestigation.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tpDemographic, Me.tpClinicalInformation, Me.tpSamples, Me.tpContactsRemarks, Me.tpCaseClassification, Me.tpEpiLinksRiskFactors, Me.tpCaseSummary})
        '
        'tpDemographic
        '
        Me.tpDemographic.Appearance.Header.Options.UseFont = True
        Me.tpDemographic.Appearance.HeaderActive.Options.UseFont = True
        Me.tpDemographic.Appearance.HeaderDisabled.Options.UseFont = True
        Me.tpDemographic.Appearance.HeaderHotTracked.Options.UseFont = True
        Me.tpDemographic.Appearance.PageClient.Options.UseFont = True
        Me.tpDemographic.Controls.Add(Me.dtInvestigationStartDate)
        Me.tpDemographic.Controls.Add(Me.lblNotifSentByDate)
        Me.tpDemographic.Controls.Add(Me.txtNotifSentByDate)
        Me.tpDemographic.Controls.Add(Me.txtNotifOrganization)
        Me.tpDemographic.Controls.Add(Me.lblNotifOrganization)
        Me.tpDemographic.Controls.Add(Me.cbInvOrganization)
        Me.tpDemographic.Controls.Add(Me.txtLocalIdentifier)
        Me.tpDemographic.Controls.Add(Me.lblLocalIdentifier)
        Me.tpDemographic.Controls.Add(Me.gpDemographicInfo)
        Me.tpDemographic.Controls.Add(Me.lblInvestigationStartDate)
        Me.tpDemographic.Controls.Add(Me.lblInvOrganization)
        Me.tpDemographic.Name = "tpDemographic"
        resources.ApplyResources(Me.tpDemographic, "tpDemographic")
        '
        'dtInvestigationStartDate
        '
        resources.ApplyResources(Me.dtInvestigationStartDate, "dtInvestigationStartDate")
        Me.dtInvestigationStartDate.Name = "dtInvestigationStartDate"
        Me.dtInvestigationStartDate.Properties.Appearance.Options.UseFont = True
        Me.dtInvestigationStartDate.Properties.AppearanceDisabled.Options.UseFont = True
        Me.dtInvestigationStartDate.Properties.AppearanceDropDown.Options.UseFont = True
        Me.dtInvestigationStartDate.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.dtInvestigationStartDate.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = True
        Me.dtInvestigationStartDate.Properties.AppearanceDropDownHighlight.Options.UseFont = True
        Me.dtInvestigationStartDate.Properties.AppearanceFocused.Options.UseFont = True
        Me.dtInvestigationStartDate.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.dtInvestigationStartDate.Properties.AppearanceWeekNumber.Options.UseFont = True
        Me.dtInvestigationStartDate.Properties.AutoHeight = CType(resources.GetObject("dtInvestigationStartDate.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject26.Options.UseFont = True
        Me.dtInvestigationStartDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtInvestigationStartDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("dtInvestigationStartDate.Properties.Buttons1"), CType(resources.GetObject("dtInvestigationStartDate.Properties.Buttons2"), Integer), CType(resources.GetObject("dtInvestigationStartDate.Properties.Buttons3"), Boolean), CType(resources.GetObject("dtInvestigationStartDate.Properties.Buttons4"), Boolean), CType(resources.GetObject("dtInvestigationStartDate.Properties.Buttons5"), Boolean), CType(resources.GetObject("dtInvestigationStartDate.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("dtInvestigationStartDate.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject26, resources.GetString("dtInvestigationStartDate.Properties.Buttons8"), CType(resources.GetObject("dtInvestigationStartDate.Properties.Buttons9"), Object), CType(resources.GetObject("dtInvestigationStartDate.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("dtInvestigationStartDate.Properties.Buttons11"), Boolean))})
        Me.dtInvestigationStartDate.Properties.CalendarTimeProperties.Appearance.Options.UseFont = True
        Me.dtInvestigationStartDate.Properties.CalendarTimeProperties.AppearanceDisabled.Options.UseFont = True
        Me.dtInvestigationStartDate.Properties.CalendarTimeProperties.AppearanceFocused.Options.UseFont = True
        Me.dtInvestigationStartDate.Properties.CalendarTimeProperties.AppearanceReadOnly.Options.UseFont = True
        Me.dtInvestigationStartDate.Properties.CalendarTimeProperties.AutoHeight = CType(resources.GetObject("dtInvestigationStartDate.Properties.CalendarTimeProperties.AutoHeight"), Boolean)
        SerializableAppearanceObject27.Options.UseFont = True
        Me.dtInvestigationStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtInvestigationStartDate.Properties.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("dtInvestigationStartDate.Properties.CalendarTimeProperties.Buttons1"), CType(resources.GetObject("dtInvestigationStartDate.Properties.CalendarTimeProperties.Buttons2"), Integer), CType(resources.GetObject("dtInvestigationStartDate.Properties.CalendarTimeProperties.Buttons3"), Boolean), CType(resources.GetObject("dtInvestigationStartDate.Properties.CalendarTimeProperties.Buttons4"), Boolean), CType(resources.GetObject("dtInvestigationStartDate.Properties.CalendarTimeProperties.Buttons5"), Boolean), CType(resources.GetObject("dtInvestigationStartDate.Properties.CalendarTimeProperties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("dtInvestigationStartDate.Properties.CalendarTimeProperties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject27, resources.GetString("dtInvestigationStartDate.Properties.CalendarTimeProperties.Buttons8"), CType(resources.GetObject("dtInvestigationStartDate.Properties.CalendarTimeProperties.Buttons9"), Object), CType(resources.GetObject("dtInvestigationStartDate.Properties.CalendarTimeProperties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("dtInvestigationStartDate.Properties.CalendarTimeProperties.Buttons11"), Boolean))})
        Me.dtInvestigationStartDate.Properties.CalendarTimeProperties.Mask.EditMask = resources.GetString("dtInvestigationStartDate.Properties.CalendarTimeProperties.Mask.EditMask")
        Me.dtInvestigationStartDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtInvestigationStartDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtInvestigationStartDate.Properties.CalendarTimeProperties.Mask.MaskType = CType(resources.GetObject("dtInvestigationStartDate.Properties.CalendarTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtInvestigationStartDate.Properties.CalendarTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("dtInvestigationStartDate.Properties.CalendarTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.dtInvestigationStartDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtInvestigationStartDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtInvestigationStartDate.Properties.CalendarTimeProperties.NullValuePrompt = resources.GetString("dtInvestigationStartDate.Properties.CalendarTimeProperties.NullValuePrompt")
        Me.dtInvestigationStartDate.Properties.Mask.BeepOnError = CType(resources.GetObject("dtInvestigationStartDate.Properties.Mask.BeepOnError"), Boolean)
        Me.dtInvestigationStartDate.Properties.Mask.EditMask = resources.GetString("dtInvestigationStartDate.Properties.Mask.EditMask")
        Me.dtInvestigationStartDate.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtInvestigationStartDate.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtInvestigationStartDate.Properties.Mask.MaskType = CType(resources.GetObject("dtInvestigationStartDate.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtInvestigationStartDate.Properties.Mask.SaveLiteral = CType(resources.GetObject("dtInvestigationStartDate.Properties.Mask.SaveLiteral"), Boolean)
        Me.dtInvestigationStartDate.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtInvestigationStartDate.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtInvestigationStartDate.Properties.NullValuePrompt = resources.GetString("dtInvestigationStartDate.Properties.NullValuePrompt")
        Me.dtInvestigationStartDate.Tag = ""
        '
        'lblNotifSentByDate
        '
        resources.ApplyResources(Me.lblNotifSentByDate, "lblNotifSentByDate")
        Me.lblNotifSentByDate.Name = "lblNotifSentByDate"
        '
        'txtNotifSentByDate
        '
        resources.ApplyResources(Me.txtNotifSentByDate, "txtNotifSentByDate")
        Me.txtNotifSentByDate.Name = "txtNotifSentByDate"
        Me.txtNotifSentByDate.Properties.Appearance.Options.UseFont = True
        Me.txtNotifSentByDate.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtNotifSentByDate.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtNotifSentByDate.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtNotifSentByDate.Properties.AutoHeight = CType(resources.GetObject("txtNotifSentByDate.Properties.AutoHeight"), Boolean)
        Me.txtNotifSentByDate.Properties.Mask.EditMask = resources.GetString("txtNotifSentByDate.Properties.Mask.EditMask")
        Me.txtNotifSentByDate.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtNotifSentByDate.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtNotifSentByDate.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtNotifSentByDate.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtNotifSentByDate.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtNotifSentByDate.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtNotifSentByDate.Properties.NullValuePrompt = resources.GetString("txtNotifSentByDate.Properties.NullValuePrompt")
        Me.txtNotifSentByDate.Tag = "{R}"
        '
        'txtNotifOrganization
        '
        resources.ApplyResources(Me.txtNotifOrganization, "txtNotifOrganization")
        Me.txtNotifOrganization.Name = "txtNotifOrganization"
        Me.txtNotifOrganization.Properties.AccessibleDescription = resources.GetString("txtNotifOrganization.Properties.AccessibleDescription")
        Me.txtNotifOrganization.Properties.Appearance.Options.UseFont = True
        Me.txtNotifOrganization.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtNotifOrganization.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtNotifOrganization.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtNotifOrganization.Properties.AutoHeight = CType(resources.GetObject("txtNotifOrganization.Properties.AutoHeight"), Boolean)
        Me.txtNotifOrganization.Properties.Mask.EditMask = resources.GetString("txtNotifOrganization.Properties.Mask.EditMask")
        Me.txtNotifOrganization.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtNotifOrganization.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtNotifOrganization.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtNotifOrganization.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtNotifOrganization.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtNotifOrganization.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtNotifOrganization.Properties.NullValuePrompt = resources.GetString("txtNotifOrganization.Properties.NullValuePrompt")
        Me.txtNotifOrganization.Tag = "{R}"
        '
        'lblNotifOrganization
        '
        resources.ApplyResources(Me.lblNotifOrganization, "lblNotifOrganization")
        Me.lblNotifOrganization.Name = "lblNotifOrganization"
        '
        'cbInvOrganization
        '
        resources.ApplyResources(Me.cbInvOrganization, "cbInvOrganization")
        Me.cbInvOrganization.Name = "cbInvOrganization"
        Me.cbInvOrganization.Properties.Appearance.Options.UseFont = True
        Me.cbInvOrganization.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbInvOrganization.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbInvOrganization.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbInvOrganization.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbInvOrganization.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbInvOrganization.Properties.AutoHeight = CType(resources.GetObject("cbInvOrganization.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject28.Options.UseFont = True
        Me.cbInvOrganization.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbInvOrganization.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbInvOrganization.Properties.Buttons1"), CType(resources.GetObject("cbInvOrganization.Properties.Buttons2"), Integer), CType(resources.GetObject("cbInvOrganization.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbInvOrganization.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbInvOrganization.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbInvOrganization.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbInvOrganization.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject28, resources.GetString("cbInvOrganization.Properties.Buttons8"), CType(resources.GetObject("cbInvOrganization.Properties.Buttons9"), Object), CType(resources.GetObject("cbInvOrganization.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbInvOrganization.Properties.Buttons11"), Boolean))})
        Me.cbInvOrganization.Properties.NullText = resources.GetString("cbInvOrganization.Properties.NullText")
        Me.cbInvOrganization.Properties.NullValuePrompt = resources.GetString("cbInvOrganization.Properties.NullValuePrompt")
        Me.cbInvOrganization.Tag = ""
        '
        'txtLocalIdentifier
        '
        resources.ApplyResources(Me.txtLocalIdentifier, "txtLocalIdentifier")
        Me.txtLocalIdentifier.Name = "txtLocalIdentifier"
        Me.txtLocalIdentifier.Properties.Appearance.Options.UseFont = True
        Me.txtLocalIdentifier.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtLocalIdentifier.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtLocalIdentifier.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtLocalIdentifier.Properties.AutoHeight = CType(resources.GetObject("txtLocalIdentifier.Properties.AutoHeight"), Boolean)
        Me.txtLocalIdentifier.Properties.Mask.EditMask = resources.GetString("txtLocalIdentifier.Properties.Mask.EditMask")
        Me.txtLocalIdentifier.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtLocalIdentifier.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtLocalIdentifier.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtLocalIdentifier.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtLocalIdentifier.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtLocalIdentifier.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtLocalIdentifier.Properties.NullValuePrompt = resources.GetString("txtLocalIdentifier.Properties.NullValuePrompt")
        Me.txtLocalIdentifier.Tag = "{R}"
        '
        'lblLocalIdentifier
        '
        resources.ApplyResources(Me.lblLocalIdentifier, "lblLocalIdentifier")
        Me.lblLocalIdentifier.Name = "lblLocalIdentifier"
        '
        'gpDemographicInfo
        '
        Me.gpDemographicInfo.Appearance.Options.UseFont = True
        Me.gpDemographicInfo.AppearanceCaption.Options.UseFont = True
        Me.gpDemographicInfo.Controls.Add(Me.txtPersonalIdType)
        Me.gpDemographicInfo.Controls.Add(Me.txtPersonalID)
        Me.gpDemographicInfo.Controls.Add(Me.lbPersonalID)
        Me.gpDemographicInfo.Controls.Add(Me.lbPersonalIdType)
        Me.gpDemographicInfo.Controls.Add(Me.chkUseSameAddress)
        Me.gpDemographicInfo.Controls.Add(Me.chkForeignAddress)
        Me.gpDemographicInfo.Controls.Add(Me.lblPhoneNumber)
        Me.gpDemographicInfo.Controls.Add(Me.txtPhoneNumber)
        Me.gpDemographicInfo.Controls.Add(Me.lblResidence)
        Me.gpDemographicInfo.Controls.Add(Me.txtRegistrationPhone)
        Me.gpDemographicInfo.Controls.Add(Me.txtWorkPhone)
        Me.gpDemographicInfo.Controls.Add(Me.cbOccupation)
        Me.gpDemographicInfo.Controls.Add(Me.lblOccupation)
        Me.gpDemographicInfo.Controls.Add(Me.lblWorkPhoneNumber)
        Me.gpDemographicInfo.Controls.Add(Me.lblRegistrationPhoneNumber)
        Me.gpDemographicInfo.Controls.Add(Me.txtEmployerLastVisit)
        Me.gpDemographicInfo.Controls.Add(Me.txtDOB)
        Me.gpDemographicInfo.Controls.Add(Me.txtNationality)
        Me.gpDemographicInfo.Controls.Add(Me.txtPatientSex)
        Me.gpDemographicInfo.Controls.Add(Me.txtPatientAgeUnits)
        Me.gpDemographicInfo.Controls.Add(Me.lblPermanentAddress)
        Me.gpDemographicInfo.Controls.Add(Me.txtEmployerName)
        Me.gpDemographicInfo.Controls.Add(Me.lblEmployerName)
        Me.gpDemographicInfo.Controls.Add(Me.lblEmployerAddress)
        Me.gpDemographicInfo.Controls.Add(Me.lblNationality)
        Me.gpDemographicInfo.Controls.Add(Me.lblPersonSex)
        Me.gpDemographicInfo.Controls.Add(Me.lblPatronymic)
        Me.gpDemographicInfo.Controls.Add(Me.txtPatientAge)
        Me.gpDemographicInfo.Controls.Add(Me.txtFirstName)
        Me.gpDemographicInfo.Controls.Add(Me.lblPatientAge)
        Me.gpDemographicInfo.Controls.Add(Me.lblDOB)
        Me.gpDemographicInfo.Controls.Add(Me.lblFirstName)
        Me.gpDemographicInfo.Controls.Add(Me.txtLastName)
        Me.gpDemographicInfo.Controls.Add(Me.txtSecondName)
        Me.gpDemographicInfo.Controls.Add(Me.lblEmployerLastVisit)
        Me.gpDemographicInfo.Controls.Add(Me.lblPatientName)
        Me.gpDemographicInfo.Controls.Add(Me.lblLastName)
        Me.gpDemographicInfo.Controls.Add(Me.lpCurrentResidenceAddress)
        Me.gpDemographicInfo.Controls.Add(Me.lpEmployerAddress)
        Me.gpDemographicInfo.Controls.Add(Me.lpPermanentAddress)
        resources.ApplyResources(Me.gpDemographicInfo, "gpDemographicInfo")
        Me.gpDemographicInfo.Name = "gpDemographicInfo"
        Me.gpDemographicInfo.TabStop = True
        '
        'txtPersonalIdType
        '
        resources.ApplyResources(Me.txtPersonalIdType, "txtPersonalIdType")
        Me.txtPersonalIdType.Name = "txtPersonalIdType"
        Me.txtPersonalIdType.Properties.Appearance.Options.UseFont = True
        Me.txtPersonalIdType.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtPersonalIdType.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtPersonalIdType.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtPersonalIdType.Properties.AutoHeight = CType(resources.GetObject("txtPersonalIdType.Properties.AutoHeight"), Boolean)
        Me.txtPersonalIdType.Properties.Mask.EditMask = resources.GetString("txtPersonalIdType.Properties.Mask.EditMask")
        Me.txtPersonalIdType.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtPersonalIdType.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtPersonalIdType.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtPersonalIdType.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtPersonalIdType.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtPersonalIdType.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtPersonalIdType.Properties.NullValuePrompt = resources.GetString("txtPersonalIdType.Properties.NullValuePrompt")
        Me.txtPersonalIdType.Tag = "{R}"
        '
        'txtPersonalID
        '
        resources.ApplyResources(Me.txtPersonalID, "txtPersonalID")
        Me.txtPersonalID.Name = "txtPersonalID"
        Me.txtPersonalID.Properties.Appearance.Options.UseFont = True
        Me.txtPersonalID.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtPersonalID.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtPersonalID.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtPersonalID.Properties.AutoHeight = CType(resources.GetObject("txtPersonalID.Properties.AutoHeight"), Boolean)
        Me.txtPersonalID.Properties.Mask.EditMask = resources.GetString("txtPersonalID.Properties.Mask.EditMask")
        Me.txtPersonalID.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtPersonalID.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtPersonalID.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtPersonalID.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtPersonalID.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtPersonalID.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtPersonalID.Properties.NullValuePrompt = resources.GetString("txtPersonalID.Properties.NullValuePrompt")
        Me.txtPersonalID.Tag = "{R}"
        '
        'lbPersonalID
        '
        resources.ApplyResources(Me.lbPersonalID, "lbPersonalID")
        Me.lbPersonalID.Name = "lbPersonalID"
        '
        'lbPersonalIdType
        '
        resources.ApplyResources(Me.lbPersonalIdType, "lbPersonalIdType")
        Me.lbPersonalIdType.Name = "lbPersonalIdType"
        '
        'chkUseSameAddress
        '
        resources.ApplyResources(Me.chkUseSameAddress, "chkUseSameAddress")
        Me.chkUseSameAddress.Name = "chkUseSameAddress"
        Me.chkUseSameAddress.Properties.Appearance.Options.UseFont = True
        Me.chkUseSameAddress.Properties.AppearanceDisabled.Options.UseFont = True
        Me.chkUseSameAddress.Properties.AppearanceFocused.Options.UseFont = True
        Me.chkUseSameAddress.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.chkUseSameAddress.Properties.AutoHeight = CType(resources.GetObject("chkUseSameAddress.Properties.AutoHeight"), Boolean)
        Me.chkUseSameAddress.Properties.Caption = resources.GetString("chkUseSameAddress.Properties.Caption")
        Me.chkUseSameAddress.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'chkForeignAddress
        '
        resources.ApplyResources(Me.chkForeignAddress, "chkForeignAddress")
        Me.chkForeignAddress.Name = "chkForeignAddress"
        Me.chkForeignAddress.Properties.Appearance.Options.UseFont = True
        Me.chkForeignAddress.Properties.Appearance.Options.UseTextOptions = True
        Me.chkForeignAddress.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkForeignAddress.Properties.AppearanceDisabled.Options.UseFont = True
        Me.chkForeignAddress.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.chkForeignAddress.Properties.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkForeignAddress.Properties.AppearanceFocused.Options.UseFont = True
        Me.chkForeignAddress.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.chkForeignAddress.Properties.AppearanceFocused.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkForeignAddress.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.chkForeignAddress.Properties.AppearanceReadOnly.Options.UseTextOptions = True
        Me.chkForeignAddress.Properties.AppearanceReadOnly.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.chkForeignAddress.Properties.AutoHeight = CType(resources.GetObject("chkForeignAddress.Properties.AutoHeight"), Boolean)
        Me.chkForeignAddress.Properties.Caption = resources.GetString("chkForeignAddress.Properties.Caption")
        Me.chkForeignAddress.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'lblPhoneNumber
        '
        resources.ApplyResources(Me.lblPhoneNumber, "lblPhoneNumber")
        Me.lblPhoneNumber.Name = "lblPhoneNumber"
        '
        'txtPhoneNumber
        '
        resources.ApplyResources(Me.txtPhoneNumber, "txtPhoneNumber")
        Me.txtPhoneNumber.Name = "txtPhoneNumber"
        Me.txtPhoneNumber.Properties.Appearance.Options.UseFont = True
        Me.txtPhoneNumber.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtPhoneNumber.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtPhoneNumber.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtPhoneNumber.Properties.AutoHeight = CType(resources.GetObject("txtPhoneNumber.Properties.AutoHeight"), Boolean)
        Me.txtPhoneNumber.Properties.Mask.EditMask = resources.GetString("txtPhoneNumber.Properties.Mask.EditMask")
        Me.txtPhoneNumber.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtPhoneNumber.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtPhoneNumber.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtPhoneNumber.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtPhoneNumber.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtPhoneNumber.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtPhoneNumber.Properties.NullValuePrompt = resources.GetString("txtPhoneNumber.Properties.NullValuePrompt")
        Me.txtPhoneNumber.Tag = "{R}"
        '
        'lblResidence
        '
        resources.ApplyResources(Me.lblResidence, "lblResidence")
        Me.lblResidence.Name = "lblResidence"
        '
        'txtRegistrationPhone
        '
        resources.ApplyResources(Me.txtRegistrationPhone, "txtRegistrationPhone")
        Me.txtRegistrationPhone.Name = "txtRegistrationPhone"
        Me.txtRegistrationPhone.Properties.Appearance.Options.UseFont = True
        Me.txtRegistrationPhone.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtRegistrationPhone.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtRegistrationPhone.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtRegistrationPhone.Properties.AutoHeight = CType(resources.GetObject("txtRegistrationPhone.Properties.AutoHeight"), Boolean)
        Me.txtRegistrationPhone.Properties.Mask.EditMask = resources.GetString("txtRegistrationPhone.Properties.Mask.EditMask")
        Me.txtRegistrationPhone.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtRegistrationPhone.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtRegistrationPhone.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtRegistrationPhone.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtRegistrationPhone.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtRegistrationPhone.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtRegistrationPhone.Properties.NullValuePrompt = resources.GetString("txtRegistrationPhone.Properties.NullValuePrompt")
        Me.txtRegistrationPhone.Tag = ""
        '
        'txtWorkPhone
        '
        resources.ApplyResources(Me.txtWorkPhone, "txtWorkPhone")
        Me.txtWorkPhone.Name = "txtWorkPhone"
        Me.txtWorkPhone.Properties.Appearance.Options.UseFont = True
        Me.txtWorkPhone.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtWorkPhone.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtWorkPhone.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtWorkPhone.Properties.AutoHeight = CType(resources.GetObject("txtWorkPhone.Properties.AutoHeight"), Boolean)
        Me.txtWorkPhone.Properties.Mask.EditMask = resources.GetString("txtWorkPhone.Properties.Mask.EditMask")
        Me.txtWorkPhone.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtWorkPhone.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtWorkPhone.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtWorkPhone.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtWorkPhone.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtWorkPhone.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtWorkPhone.Properties.NullValuePrompt = resources.GetString("txtWorkPhone.Properties.NullValuePrompt")
        Me.txtWorkPhone.Tag = ""
        '
        'cbOccupation
        '
        resources.ApplyResources(Me.cbOccupation, "cbOccupation")
        Me.cbOccupation.Name = "cbOccupation"
        Me.cbOccupation.Properties.Appearance.Options.UseFont = True
        Me.cbOccupation.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbOccupation.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbOccupation.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbOccupation.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbOccupation.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbOccupation.Properties.AutoHeight = CType(resources.GetObject("cbOccupation.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject29.Options.UseFont = True
        Me.cbOccupation.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbOccupation.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbOccupation.Properties.Buttons1"), CType(resources.GetObject("cbOccupation.Properties.Buttons2"), Integer), CType(resources.GetObject("cbOccupation.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbOccupation.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbOccupation.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbOccupation.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbOccupation.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject29, resources.GetString("cbOccupation.Properties.Buttons8"), CType(resources.GetObject("cbOccupation.Properties.Buttons9"), Object), CType(resources.GetObject("cbOccupation.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbOccupation.Properties.Buttons11"), Boolean))})
        Me.cbOccupation.Properties.NullText = resources.GetString("cbOccupation.Properties.NullText")
        Me.cbOccupation.Properties.NullValuePrompt = resources.GetString("cbOccupation.Properties.NullValuePrompt")
        '
        'lblOccupation
        '
        resources.ApplyResources(Me.lblOccupation, "lblOccupation")
        Me.lblOccupation.Name = "lblOccupation"
        '
        'lblWorkPhoneNumber
        '
        resources.ApplyResources(Me.lblWorkPhoneNumber, "lblWorkPhoneNumber")
        Me.lblWorkPhoneNumber.Name = "lblWorkPhoneNumber"
        '
        'lblRegistrationPhoneNumber
        '
        resources.ApplyResources(Me.lblRegistrationPhoneNumber, "lblRegistrationPhoneNumber")
        Me.lblRegistrationPhoneNumber.Name = "lblRegistrationPhoneNumber"
        '
        'txtEmployerLastVisit
        '
        resources.ApplyResources(Me.txtEmployerLastVisit, "txtEmployerLastVisit")
        Me.txtEmployerLastVisit.Name = "txtEmployerLastVisit"
        Me.txtEmployerLastVisit.Properties.Appearance.Options.UseFont = True
        Me.txtEmployerLastVisit.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtEmployerLastVisit.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtEmployerLastVisit.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtEmployerLastVisit.Properties.AutoHeight = CType(resources.GetObject("txtEmployerLastVisit.Properties.AutoHeight"), Boolean)
        Me.txtEmployerLastVisit.Properties.Mask.EditMask = resources.GetString("txtEmployerLastVisit.Properties.Mask.EditMask")
        Me.txtEmployerLastVisit.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtEmployerLastVisit.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtEmployerLastVisit.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtEmployerLastVisit.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtEmployerLastVisit.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtEmployerLastVisit.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtEmployerLastVisit.Properties.NullValuePrompt = resources.GetString("txtEmployerLastVisit.Properties.NullValuePrompt")
        Me.txtEmployerLastVisit.Tag = "{R}"
        '
        'txtDOB
        '
        resources.ApplyResources(Me.txtDOB, "txtDOB")
        Me.txtDOB.Name = "txtDOB"
        Me.txtDOB.Properties.Appearance.Options.UseFont = True
        Me.txtDOB.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtDOB.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtDOB.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtDOB.Properties.AutoHeight = CType(resources.GetObject("txtDOB.Properties.AutoHeight"), Boolean)
        Me.txtDOB.Properties.Mask.EditMask = resources.GetString("txtDOB.Properties.Mask.EditMask")
        Me.txtDOB.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtDOB.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtDOB.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtDOB.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtDOB.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtDOB.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtDOB.Properties.NullValuePrompt = resources.GetString("txtDOB.Properties.NullValuePrompt")
        Me.txtDOB.Tag = "{R}"
        '
        'txtNationality
        '
        resources.ApplyResources(Me.txtNationality, "txtNationality")
        Me.txtNationality.Name = "txtNationality"
        Me.txtNationality.Properties.Appearance.Options.UseFont = True
        Me.txtNationality.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtNationality.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtNationality.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtNationality.Properties.AutoHeight = CType(resources.GetObject("txtNationality.Properties.AutoHeight"), Boolean)
        Me.txtNationality.Properties.Mask.EditMask = resources.GetString("txtNationality.Properties.Mask.EditMask")
        Me.txtNationality.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtNationality.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtNationality.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtNationality.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtNationality.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtNationality.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtNationality.Properties.NullValuePrompt = resources.GetString("txtNationality.Properties.NullValuePrompt")
        Me.txtNationality.Tag = "{R}"
        '
        'txtPatientSex
        '
        resources.ApplyResources(Me.txtPatientSex, "txtPatientSex")
        Me.txtPatientSex.Name = "txtPatientSex"
        Me.txtPatientSex.Properties.AccessibleDescription = resources.GetString("txtPatientSex.Properties.AccessibleDescription")
        Me.txtPatientSex.Properties.Appearance.Options.UseFont = True
        Me.txtPatientSex.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtPatientSex.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtPatientSex.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtPatientSex.Properties.AutoHeight = CType(resources.GetObject("txtPatientSex.Properties.AutoHeight"), Boolean)
        Me.txtPatientSex.Properties.Mask.EditMask = resources.GetString("txtPatientSex.Properties.Mask.EditMask")
        Me.txtPatientSex.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtPatientSex.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtPatientSex.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtPatientSex.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtPatientSex.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtPatientSex.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtPatientSex.Properties.NullValuePrompt = resources.GetString("txtPatientSex.Properties.NullValuePrompt")
        Me.txtPatientSex.Tag = "{R}"
        '
        'txtPatientAgeUnits
        '
        resources.ApplyResources(Me.txtPatientAgeUnits, "txtPatientAgeUnits")
        Me.txtPatientAgeUnits.Name = "txtPatientAgeUnits"
        Me.txtPatientAgeUnits.Properties.AccessibleDescription = resources.GetString("txtPatientAgeUnits.Properties.AccessibleDescription")
        Me.txtPatientAgeUnits.Properties.Appearance.Options.UseFont = True
        Me.txtPatientAgeUnits.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtPatientAgeUnits.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtPatientAgeUnits.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtPatientAgeUnits.Properties.AutoHeight = CType(resources.GetObject("txtPatientAgeUnits.Properties.AutoHeight"), Boolean)
        Me.txtPatientAgeUnits.Properties.Mask.EditMask = resources.GetString("txtPatientAgeUnits.Properties.Mask.EditMask")
        Me.txtPatientAgeUnits.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtPatientAgeUnits.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtPatientAgeUnits.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtPatientAgeUnits.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtPatientAgeUnits.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtPatientAgeUnits.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtPatientAgeUnits.Properties.NullValuePrompt = resources.GetString("txtPatientAgeUnits.Properties.NullValuePrompt")
        Me.txtPatientAgeUnits.Tag = "{R}"
        '
        'lblPermanentAddress
        '
        resources.ApplyResources(Me.lblPermanentAddress, "lblPermanentAddress")
        Me.lblPermanentAddress.Name = "lblPermanentAddress"
        '
        'txtEmployerName
        '
        resources.ApplyResources(Me.txtEmployerName, "txtEmployerName")
        Me.txtEmployerName.Name = "txtEmployerName"
        Me.txtEmployerName.Properties.Appearance.Options.UseFont = True
        Me.txtEmployerName.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtEmployerName.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtEmployerName.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtEmployerName.Properties.AutoHeight = CType(resources.GetObject("txtEmployerName.Properties.AutoHeight"), Boolean)
        Me.txtEmployerName.Properties.Mask.EditMask = resources.GetString("txtEmployerName.Properties.Mask.EditMask")
        Me.txtEmployerName.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtEmployerName.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtEmployerName.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtEmployerName.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtEmployerName.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtEmployerName.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtEmployerName.Properties.NullValuePrompt = resources.GetString("txtEmployerName.Properties.NullValuePrompt")
        Me.txtEmployerName.Tag = "{R}"
        '
        'lblEmployerName
        '
        resources.ApplyResources(Me.lblEmployerName, "lblEmployerName")
        Me.lblEmployerName.Name = "lblEmployerName"
        '
        'lblEmployerAddress
        '
        resources.ApplyResources(Me.lblEmployerAddress, "lblEmployerAddress")
        Me.lblEmployerAddress.Name = "lblEmployerAddress"
        '
        'lblNationality
        '
        resources.ApplyResources(Me.lblNationality, "lblNationality")
        Me.lblNationality.Name = "lblNationality"
        '
        'lblPersonSex
        '
        resources.ApplyResources(Me.lblPersonSex, "lblPersonSex")
        Me.lblPersonSex.Name = "lblPersonSex"
        '
        'lblPatronymic
        '
        resources.ApplyResources(Me.lblPatronymic, "lblPatronymic")
        Me.lblPatronymic.Name = "lblPatronymic"
        '
        'txtPatientAge
        '
        resources.ApplyResources(Me.txtPatientAge, "txtPatientAge")
        Me.txtPatientAge.Name = "txtPatientAge"
        Me.txtPatientAge.Properties.AccessibleDescription = resources.GetString("txtPatientAge.Properties.AccessibleDescription")
        Me.txtPatientAge.Properties.Appearance.Options.UseFont = True
        Me.txtPatientAge.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtPatientAge.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtPatientAge.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtPatientAge.Properties.AutoHeight = CType(resources.GetObject("txtPatientAge.Properties.AutoHeight"), Boolean)
        Me.txtPatientAge.Properties.Mask.EditMask = resources.GetString("txtPatientAge.Properties.Mask.EditMask")
        Me.txtPatientAge.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtPatientAge.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtPatientAge.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtPatientAge.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtPatientAge.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtPatientAge.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtPatientAge.Properties.NullValuePrompt = resources.GetString("txtPatientAge.Properties.NullValuePrompt")
        Me.txtPatientAge.Tag = "{R}"
        '
        'txtFirstName
        '
        resources.ApplyResources(Me.txtFirstName, "txtFirstName")
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Properties.Appearance.Options.UseFont = True
        Me.txtFirstName.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtFirstName.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtFirstName.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtFirstName.Properties.AutoHeight = CType(resources.GetObject("txtFirstName.Properties.AutoHeight"), Boolean)
        Me.txtFirstName.Properties.Mask.EditMask = resources.GetString("txtFirstName.Properties.Mask.EditMask")
        Me.txtFirstName.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtFirstName.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtFirstName.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtFirstName.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtFirstName.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtFirstName.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtFirstName.Properties.NullValuePrompt = resources.GetString("txtFirstName.Properties.NullValuePrompt")
        Me.txtFirstName.Tag = "{R}"
        '
        'lblPatientAge
        '
        resources.ApplyResources(Me.lblPatientAge, "lblPatientAge")
        Me.lblPatientAge.Name = "lblPatientAge"
        '
        'lblDOB
        '
        resources.ApplyResources(Me.lblDOB, "lblDOB")
        Me.lblDOB.Name = "lblDOB"
        '
        'lblFirstName
        '
        resources.ApplyResources(Me.lblFirstName, "lblFirstName")
        Me.lblFirstName.Name = "lblFirstName"
        '
        'txtLastName
        '
        resources.ApplyResources(Me.txtLastName, "txtLastName")
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Properties.Appearance.Options.UseFont = True
        Me.txtLastName.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtLastName.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtLastName.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtLastName.Properties.AutoHeight = CType(resources.GetObject("txtLastName.Properties.AutoHeight"), Boolean)
        Me.txtLastName.Properties.Mask.EditMask = resources.GetString("txtLastName.Properties.Mask.EditMask")
        Me.txtLastName.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtLastName.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtLastName.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtLastName.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtLastName.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtLastName.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtLastName.Properties.NullValuePrompt = resources.GetString("txtLastName.Properties.NullValuePrompt")
        Me.txtLastName.Tag = "{R}"
        '
        'txtSecondName
        '
        resources.ApplyResources(Me.txtSecondName, "txtSecondName")
        Me.txtSecondName.Name = "txtSecondName"
        Me.txtSecondName.Properties.Appearance.Options.UseFont = True
        Me.txtSecondName.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtSecondName.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtSecondName.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtSecondName.Properties.AutoHeight = CType(resources.GetObject("txtSecondName.Properties.AutoHeight"), Boolean)
        Me.txtSecondName.Properties.Mask.EditMask = resources.GetString("txtSecondName.Properties.Mask.EditMask")
        Me.txtSecondName.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtSecondName.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtSecondName.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtSecondName.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtSecondName.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtSecondName.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtSecondName.Properties.NullValuePrompt = resources.GetString("txtSecondName.Properties.NullValuePrompt")
        Me.txtSecondName.Tag = "{R}"
        '
        'lblEmployerLastVisit
        '
        resources.ApplyResources(Me.lblEmployerLastVisit, "lblEmployerLastVisit")
        Me.lblEmployerLastVisit.Name = "lblEmployerLastVisit"
        '
        'lblPatientName
        '
        resources.ApplyResources(Me.lblPatientName, "lblPatientName")
        Me.lblPatientName.Name = "lblPatientName"
        '
        'lblLastName
        '
        resources.ApplyResources(Me.lblLastName, "lblLastName")
        Me.lblLastName.Name = "lblLastName"
        '
        'lpCurrentResidenceAddress
        '
        Me.lpCurrentResidenceAddress.Appearance.BackColor = CType(resources.GetObject("lpCurrentResidenceAddress.Appearance.BackColor"), System.Drawing.Color)
        Me.lpCurrentResidenceAddress.Appearance.Options.UseBackColor = True
        Me.lpCurrentResidenceAddress.Appearance.Options.UseFont = True
        Me.lpCurrentResidenceAddress.CanExpand = True
        resources.ApplyResources(Me.lpCurrentResidenceAddress, "lpCurrentResidenceAddress")
        Me.lpCurrentResidenceAddress.ColumnCount = 3
        Me.lpCurrentResidenceAddress.FormID = Nothing
        Me.lpCurrentResidenceAddress.HelpTopicID = Nothing
        Me.lpCurrentResidenceAddress.KeyFieldName = "idfGeoLocation"
        Me.lpCurrentResidenceAddress.LookupLayout = bv.common.win.LookupFormLayout.Group
        Me.lpCurrentResidenceAddress.MultiSelect = False
        Me.lpCurrentResidenceAddress.Name = "lpCurrentResidenceAddress"
        Me.lpCurrentResidenceAddress.ObjectName = "Address"
        Me.lpCurrentResidenceAddress.PopupEditHeight = 200
        Me.lpCurrentResidenceAddress.PopupEditMinWidth = 400
        Me.lpCurrentResidenceAddress.ShowContry = False
        Me.lpCurrentResidenceAddress.ShowCoordinates = True
        Me.lpCurrentResidenceAddress.Sizable = True
        Me.lpCurrentResidenceAddress.TableName = "Address"
        Me.lpCurrentResidenceAddress.UseParentBackColor = True
        '
        'lpEmployerAddress
        '
        Me.lpEmployerAddress.Appearance.BackColor = CType(resources.GetObject("lpEmployerAddress.Appearance.BackColor"), System.Drawing.Color)
        Me.lpEmployerAddress.Appearance.Options.UseBackColor = True
        Me.lpEmployerAddress.Appearance.Options.UseFont = True
        Me.lpEmployerAddress.CanExpand = True
        resources.ApplyResources(Me.lpEmployerAddress, "lpEmployerAddress")
        Me.lpEmployerAddress.ColumnCount = 3
        Me.lpEmployerAddress.FormID = Nothing
        Me.lpEmployerAddress.HelpTopicID = Nothing
        Me.lpEmployerAddress.KeyFieldName = "idfGeoLocation"
        Me.lpEmployerAddress.LookupLayout = bv.common.win.LookupFormLayout.Group
        Me.lpEmployerAddress.MultiSelect = False
        Me.lpEmployerAddress.Name = "lpEmployerAddress"
        Me.lpEmployerAddress.ObjectName = "Address"
        Me.lpEmployerAddress.PopupEditHeight = 200
        Me.lpEmployerAddress.PopupEditMinWidth = 400
        Me.lpEmployerAddress.ShowContry = False
        Me.lpEmployerAddress.Sizable = True
        Me.lpEmployerAddress.TableName = "Address"
        Me.lpEmployerAddress.Tag = "{R}"
        Me.lpEmployerAddress.UseParentBackColor = True
        '
        'lpPermanentAddress
        '
        Me.lpPermanentAddress.Appearance.BackColor = CType(resources.GetObject("lpPermanentAddress.Appearance.BackColor"), System.Drawing.Color)
        Me.lpPermanentAddress.Appearance.Options.UseBackColor = True
        Me.lpPermanentAddress.Appearance.Options.UseFont = True
        Me.lpPermanentAddress.CanExpand = True
        resources.ApplyResources(Me.lpPermanentAddress, "lpPermanentAddress")
        Me.lpPermanentAddress.ColumnCount = 3
        Me.lpPermanentAddress.FormID = Nothing
        Me.lpPermanentAddress.HelpTopicID = Nothing
        Me.lpPermanentAddress.KeyFieldName = "idfGeoLocation"
        Me.lpPermanentAddress.LookupLayout = bv.common.win.LookupFormLayout.Group
        Me.lpPermanentAddress.MultiSelect = False
        Me.lpPermanentAddress.Name = "lpPermanentAddress"
        Me.lpPermanentAddress.ObjectName = "Address"
        Me.lpPermanentAddress.PopupEditHeight = 200
        Me.lpPermanentAddress.PopupEditMinWidth = 400
        Me.lpPermanentAddress.ShowContry = False
        Me.lpPermanentAddress.ShowCoordinates = True
        Me.lpPermanentAddress.Sizable = True
        Me.lpPermanentAddress.TableName = "Address"
        Me.lpPermanentAddress.UseParentBackColor = True
        '
        'lblInvestigationStartDate
        '
        resources.ApplyResources(Me.lblInvestigationStartDate, "lblInvestigationStartDate")
        Me.lblInvestigationStartDate.Name = "lblInvestigationStartDate"
        '
        'lblInvOrganization
        '
        resources.ApplyResources(Me.lblInvOrganization, "lblInvOrganization")
        Me.lblInvOrganization.Name = "lblInvOrganization"
        '
        'tpClinicalInformation
        '
        Me.tpClinicalInformation.Appearance.Header.Options.UseFont = True
        Me.tpClinicalInformation.Appearance.HeaderActive.Options.UseFont = True
        Me.tpClinicalInformation.Appearance.HeaderDisabled.Options.UseFont = True
        Me.tpClinicalInformation.Appearance.HeaderHotTracked.Options.UseFont = True
        Me.tpClinicalInformation.Appearance.PageClient.Options.UseFont = True
        Me.tpClinicalInformation.Controls.Add(Me.cbGeoLocation)
        Me.tpClinicalInformation.Controls.Add(Me.cbNonNotifiableDiesease)
        Me.tpClinicalInformation.Controls.Add(Me.cbHospitalization)
        Me.tpClinicalInformation.Controls.Add(Me.lblAntimicrobialTherapyTable)
        Me.tpClinicalInformation.Controls.Add(Me.lblAntimicrobialTherapy)
        Me.tpClinicalInformation.Controls.Add(Me.cbAntimicrobialTherapy)
        Me.tpClinicalInformation.Controls.Add(Me.meClinicalComments)
        Me.tpClinicalInformation.Controls.Add(Me.lblClinicalComments)
        Me.tpClinicalInformation.Controls.Add(Me.lblHospital)
        Me.tpClinicalInformation.Controls.Add(Me.lblDateOfxposure)
        Me.tpClinicalInformation.Controls.Add(Me.cbInitialCaseClassification)
        Me.tpClinicalInformation.Controls.Add(Me.deDateOfxposure)
        Me.tpClinicalInformation.Controls.Add(Me.lblLocation)
        Me.tpClinicalInformation.Controls.Add(Me.lblHospitalization)
        Me.tpClinicalInformation.Controls.Add(Me.txtHospital)
        Me.tpClinicalInformation.Controls.Add(Me.lblDateOfAdmissionHospitalization)
        Me.tpClinicalInformation.Controls.Add(Me.lblFacilitySoughtCare)
        Me.tpClinicalInformation.Controls.Add(Me.lblInitialClinicalDiagnosis)
        Me.tpClinicalInformation.Controls.Add(Me.deDateOfAdmissionHospitalization)
        Me.tpClinicalInformation.Controls.Add(Me.lblSymptomOnsetDate)
        Me.tpClinicalInformation.Controls.Add(Me.lblClinicalDiagnosis)
        Me.tpClinicalInformation.Controls.Add(Me.lblDatePatientFirstSought)
        Me.tpClinicalInformation.Controls.Add(Me.txtClinicalDiagnosis)
        Me.tpClinicalInformation.Controls.Add(Me.lblInitialCaseClassification)
        Me.tpClinicalInformation.Controls.Add(Me.deDatePatientFirstSought)
        Me.tpClinicalInformation.Controls.Add(Me.txtSymptomOnsetDate)
        Me.tpClinicalInformation.Controls.Add(Me.cbFacilitySoughtCare)
        Me.tpClinicalInformation.Controls.Add(Me.btnRemoveAntimicrobialTherapy)
        Me.tpClinicalInformation.Controls.Add(Me.gcAntimicrobialTherapy)
        Me.tpClinicalInformation.Name = "tpClinicalInformation"
        resources.ApplyResources(Me.tpClinicalInformation, "tpClinicalInformation")
        '
        'cbGeoLocation
        '
        resources.ApplyResources(Me.cbGeoLocation, "cbGeoLocation")
        Me.cbGeoLocation.Appearance.BackColor = CType(resources.GetObject("cbGeoLocation.Appearance.BackColor"), System.Drawing.Color)
        Me.cbGeoLocation.Appearance.Options.UseBackColor = True
        Me.cbGeoLocation.Appearance.Options.UseFont = True
        Me.cbGeoLocation.FormID = Nothing
        Me.cbGeoLocation.HelpTopicID = Nothing
        Me.cbGeoLocation.KeyFieldName = Nothing
        Me.cbGeoLocation.MultiSelect = False
        Me.cbGeoLocation.Name = "cbGeoLocation"
        Me.cbGeoLocation.ObjectName = Nothing
        Me.cbGeoLocation.PopupEditMinWidth = 427
        Me.cbGeoLocation.TableName = Nothing
        '
        'cbNonNotifiableDiesease
        '
        resources.ApplyResources(Me.cbNonNotifiableDiesease, "cbNonNotifiableDiesease")
        Me.cbNonNotifiableDiesease.Name = "cbNonNotifiableDiesease"
        Me.cbNonNotifiableDiesease.Properties.Appearance.Options.UseFont = True
        Me.cbNonNotifiableDiesease.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbNonNotifiableDiesease.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbNonNotifiableDiesease.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbNonNotifiableDiesease.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbNonNotifiableDiesease.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbNonNotifiableDiesease.Properties.AutoHeight = CType(resources.GetObject("cbNonNotifiableDiesease.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject30.Options.UseFont = True
        Me.cbNonNotifiableDiesease.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbNonNotifiableDiesease.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbNonNotifiableDiesease.Properties.Buttons1"), CType(resources.GetObject("cbNonNotifiableDiesease.Properties.Buttons2"), Integer), CType(resources.GetObject("cbNonNotifiableDiesease.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbNonNotifiableDiesease.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbNonNotifiableDiesease.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbNonNotifiableDiesease.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbNonNotifiableDiesease.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject30, resources.GetString("cbNonNotifiableDiesease.Properties.Buttons8"), CType(resources.GetObject("cbNonNotifiableDiesease.Properties.Buttons9"), Object), CType(resources.GetObject("cbNonNotifiableDiesease.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbNonNotifiableDiesease.Properties.Buttons11"), Boolean))})
        Me.cbNonNotifiableDiesease.Properties.NullText = resources.GetString("cbNonNotifiableDiesease.Properties.NullText")
        Me.cbNonNotifiableDiesease.Properties.NullValuePrompt = resources.GetString("cbNonNotifiableDiesease.Properties.NullValuePrompt")
        '
        'cbHospitalization
        '
        resources.ApplyResources(Me.cbHospitalization, "cbHospitalization")
        Me.cbHospitalization.Name = "cbHospitalization"
        Me.cbHospitalization.Properties.Appearance.Options.UseFont = True
        Me.cbHospitalization.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbHospitalization.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbHospitalization.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbHospitalization.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbHospitalization.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbHospitalization.Properties.AutoHeight = CType(resources.GetObject("cbHospitalization.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject31.Options.UseFont = True
        Me.cbHospitalization.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbHospitalization.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbHospitalization.Properties.Buttons1"), CType(resources.GetObject("cbHospitalization.Properties.Buttons2"), Integer), CType(resources.GetObject("cbHospitalization.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbHospitalization.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbHospitalization.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbHospitalization.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbHospitalization.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject31, resources.GetString("cbHospitalization.Properties.Buttons8"), CType(resources.GetObject("cbHospitalization.Properties.Buttons9"), Object), CType(resources.GetObject("cbHospitalization.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbHospitalization.Properties.Buttons11"), Boolean))})
        Me.cbHospitalization.Properties.NullText = resources.GetString("cbHospitalization.Properties.NullText")
        Me.cbHospitalization.Properties.NullValuePrompt = resources.GetString("cbHospitalization.Properties.NullValuePrompt")
        '
        'lblAntimicrobialTherapyTable
        '
        resources.ApplyResources(Me.lblAntimicrobialTherapyTable, "lblAntimicrobialTherapyTable")
        Me.lblAntimicrobialTherapyTable.Name = "lblAntimicrobialTherapyTable"
        '
        'lblAntimicrobialTherapy
        '
        resources.ApplyResources(Me.lblAntimicrobialTherapy, "lblAntimicrobialTherapy")
        Me.lblAntimicrobialTherapy.Name = "lblAntimicrobialTherapy"
        '
        'cbAntimicrobialTherapy
        '
        resources.ApplyResources(Me.cbAntimicrobialTherapy, "cbAntimicrobialTherapy")
        Me.cbAntimicrobialTherapy.Name = "cbAntimicrobialTherapy"
        Me.cbAntimicrobialTherapy.Properties.Appearance.Options.UseFont = True
        Me.cbAntimicrobialTherapy.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbAntimicrobialTherapy.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbAntimicrobialTherapy.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbAntimicrobialTherapy.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbAntimicrobialTherapy.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbAntimicrobialTherapy.Properties.AutoHeight = CType(resources.GetObject("cbAntimicrobialTherapy.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject32.Options.UseFont = True
        Me.cbAntimicrobialTherapy.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbAntimicrobialTherapy.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbAntimicrobialTherapy.Properties.Buttons1"), CType(resources.GetObject("cbAntimicrobialTherapy.Properties.Buttons2"), Integer), CType(resources.GetObject("cbAntimicrobialTherapy.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbAntimicrobialTherapy.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbAntimicrobialTherapy.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbAntimicrobialTherapy.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbAntimicrobialTherapy.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject32, resources.GetString("cbAntimicrobialTherapy.Properties.Buttons8"), CType(resources.GetObject("cbAntimicrobialTherapy.Properties.Buttons9"), Object), CType(resources.GetObject("cbAntimicrobialTherapy.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbAntimicrobialTherapy.Properties.Buttons11"), Boolean))})
        Me.cbAntimicrobialTherapy.Properties.NullText = resources.GetString("cbAntimicrobialTherapy.Properties.NullText")
        Me.cbAntimicrobialTherapy.Properties.NullValuePrompt = resources.GetString("cbAntimicrobialTherapy.Properties.NullValuePrompt")
        '
        'meClinicalComments
        '
        resources.ApplyResources(Me.meClinicalComments, "meClinicalComments")
        Me.meClinicalComments.Name = "meClinicalComments"
        Me.meClinicalComments.Properties.Appearance.Options.UseFont = True
        Me.meClinicalComments.Properties.AppearanceDisabled.Options.UseFont = True
        Me.meClinicalComments.Properties.AppearanceFocused.Options.UseFont = True
        Me.meClinicalComments.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.meClinicalComments.Properties.MaxLength = 1000
        Me.meClinicalComments.Properties.NullValuePrompt = resources.GetString("meClinicalComments.Properties.NullValuePrompt")
        '
        'lblClinicalComments
        '
        resources.ApplyResources(Me.lblClinicalComments, "lblClinicalComments")
        Me.lblClinicalComments.Name = "lblClinicalComments"
        '
        'lblHospital
        '
        resources.ApplyResources(Me.lblHospital, "lblHospital")
        Me.lblHospital.Name = "lblHospital"
        '
        'lblDateOfxposure
        '
        resources.ApplyResources(Me.lblDateOfxposure, "lblDateOfxposure")
        Me.lblDateOfxposure.Name = "lblDateOfxposure"
        '
        'cbInitialCaseClassification
        '
        resources.ApplyResources(Me.cbInitialCaseClassification, "cbInitialCaseClassification")
        Me.cbInitialCaseClassification.Name = "cbInitialCaseClassification"
        Me.cbInitialCaseClassification.Properties.Appearance.Options.UseFont = True
        Me.cbInitialCaseClassification.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbInitialCaseClassification.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbInitialCaseClassification.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbInitialCaseClassification.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbInitialCaseClassification.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbInitialCaseClassification.Properties.AutoHeight = CType(resources.GetObject("cbInitialCaseClassification.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject33.Options.UseFont = True
        Me.cbInitialCaseClassification.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbInitialCaseClassification.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbInitialCaseClassification.Properties.Buttons1"), CType(resources.GetObject("cbInitialCaseClassification.Properties.Buttons2"), Integer), CType(resources.GetObject("cbInitialCaseClassification.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbInitialCaseClassification.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbInitialCaseClassification.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbInitialCaseClassification.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbInitialCaseClassification.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject33, resources.GetString("cbInitialCaseClassification.Properties.Buttons8"), CType(resources.GetObject("cbInitialCaseClassification.Properties.Buttons9"), Object), CType(resources.GetObject("cbInitialCaseClassification.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbInitialCaseClassification.Properties.Buttons11"), Boolean))})
        Me.cbInitialCaseClassification.Properties.NullText = resources.GetString("cbInitialCaseClassification.Properties.NullText")
        Me.cbInitialCaseClassification.Properties.NullValuePrompt = resources.GetString("cbInitialCaseClassification.Properties.NullValuePrompt")
        '
        'deDateOfxposure
        '
        resources.ApplyResources(Me.deDateOfxposure, "deDateOfxposure")
        Me.deDateOfxposure.Name = "deDateOfxposure"
        Me.deDateOfxposure.Properties.Appearance.Options.UseFont = True
        Me.deDateOfxposure.Properties.AppearanceDisabled.Options.UseFont = True
        Me.deDateOfxposure.Properties.AppearanceDropDown.Options.UseFont = True
        Me.deDateOfxposure.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.deDateOfxposure.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = True
        Me.deDateOfxposure.Properties.AppearanceDropDownHighlight.Options.UseFont = True
        Me.deDateOfxposure.Properties.AppearanceFocused.Options.UseFont = True
        Me.deDateOfxposure.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.deDateOfxposure.Properties.AppearanceWeekNumber.Options.UseFont = True
        Me.deDateOfxposure.Properties.AutoHeight = CType(resources.GetObject("deDateOfxposure.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject34.Options.UseFont = True
        Me.deDateOfxposure.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("deDateOfxposure.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("deDateOfxposure.Properties.Buttons1"), CType(resources.GetObject("deDateOfxposure.Properties.Buttons2"), Integer), CType(resources.GetObject("deDateOfxposure.Properties.Buttons3"), Boolean), CType(resources.GetObject("deDateOfxposure.Properties.Buttons4"), Boolean), CType(resources.GetObject("deDateOfxposure.Properties.Buttons5"), Boolean), CType(resources.GetObject("deDateOfxposure.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("deDateOfxposure.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject34, resources.GetString("deDateOfxposure.Properties.Buttons8"), CType(resources.GetObject("deDateOfxposure.Properties.Buttons9"), Object), CType(resources.GetObject("deDateOfxposure.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("deDateOfxposure.Properties.Buttons11"), Boolean))})
        Me.deDateOfxposure.Properties.CalendarTimeProperties.Appearance.Options.UseFont = True
        Me.deDateOfxposure.Properties.CalendarTimeProperties.AppearanceDisabled.Options.UseFont = True
        Me.deDateOfxposure.Properties.CalendarTimeProperties.AppearanceFocused.Options.UseFont = True
        Me.deDateOfxposure.Properties.CalendarTimeProperties.AppearanceReadOnly.Options.UseFont = True
        Me.deDateOfxposure.Properties.CalendarTimeProperties.AutoHeight = CType(resources.GetObject("deDateOfxposure.Properties.CalendarTimeProperties.AutoHeight"), Boolean)
        SerializableAppearanceObject35.Options.UseFont = True
        Me.deDateOfxposure.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("deDateOfxposure.Properties.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("deDateOfxposure.Properties.CalendarTimeProperties.Buttons1"), CType(resources.GetObject("deDateOfxposure.Properties.CalendarTimeProperties.Buttons2"), Integer), CType(resources.GetObject("deDateOfxposure.Properties.CalendarTimeProperties.Buttons3"), Boolean), CType(resources.GetObject("deDateOfxposure.Properties.CalendarTimeProperties.Buttons4"), Boolean), CType(resources.GetObject("deDateOfxposure.Properties.CalendarTimeProperties.Buttons5"), Boolean), CType(resources.GetObject("deDateOfxposure.Properties.CalendarTimeProperties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("deDateOfxposure.Properties.CalendarTimeProperties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject35, resources.GetString("deDateOfxposure.Properties.CalendarTimeProperties.Buttons8"), CType(resources.GetObject("deDateOfxposure.Properties.CalendarTimeProperties.Buttons9"), Object), CType(resources.GetObject("deDateOfxposure.Properties.CalendarTimeProperties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("deDateOfxposure.Properties.CalendarTimeProperties.Buttons11"), Boolean))})
        Me.deDateOfxposure.Properties.CalendarTimeProperties.Mask.EditMask = resources.GetString("deDateOfxposure.Properties.CalendarTimeProperties.Mask.EditMask")
        Me.deDateOfxposure.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("deDateOfxposure.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.deDateOfxposure.Properties.CalendarTimeProperties.Mask.MaskType = CType(resources.GetObject("deDateOfxposure.Properties.CalendarTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.deDateOfxposure.Properties.CalendarTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("deDateOfxposure.Properties.CalendarTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.deDateOfxposure.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("deDateOfxposure.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.deDateOfxposure.Properties.CalendarTimeProperties.NullValuePrompt = resources.GetString("deDateOfxposure.Properties.CalendarTimeProperties.NullValuePrompt")
        Me.deDateOfxposure.Properties.Mask.EditMask = resources.GetString("deDateOfxposure.Properties.Mask.EditMask")
        Me.deDateOfxposure.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("deDateOfxposure.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.deDateOfxposure.Properties.Mask.MaskType = CType(resources.GetObject("deDateOfxposure.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.deDateOfxposure.Properties.Mask.SaveLiteral = CType(resources.GetObject("deDateOfxposure.Properties.Mask.SaveLiteral"), Boolean)
        Me.deDateOfxposure.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("deDateOfxposure.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.deDateOfxposure.Properties.NullValuePrompt = resources.GetString("deDateOfxposure.Properties.NullValuePrompt")
        '
        'lblLocation
        '
        resources.ApplyResources(Me.lblLocation, "lblLocation")
        Me.lblLocation.Name = "lblLocation"
        '
        'lblHospitalization
        '
        resources.ApplyResources(Me.lblHospitalization, "lblHospitalization")
        Me.lblHospitalization.Name = "lblHospitalization"
        '
        'txtHospital
        '
        resources.ApplyResources(Me.txtHospital, "txtHospital")
        Me.txtHospital.Name = "txtHospital"
        Me.txtHospital.Properties.Appearance.Options.UseFont = True
        Me.txtHospital.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtHospital.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtHospital.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtHospital.Properties.AutoHeight = CType(resources.GetObject("txtHospital.Properties.AutoHeight"), Boolean)
        Me.txtHospital.Properties.Mask.EditMask = resources.GetString("txtHospital.Properties.Mask.EditMask")
        Me.txtHospital.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtHospital.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtHospital.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtHospital.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtHospital.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtHospital.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtHospital.Properties.NullValuePrompt = resources.GetString("txtHospital.Properties.NullValuePrompt")
        Me.txtHospital.Tag = ""
        '
        'lblDateOfAdmissionHospitalization
        '
        resources.ApplyResources(Me.lblDateOfAdmissionHospitalization, "lblDateOfAdmissionHospitalization")
        Me.lblDateOfAdmissionHospitalization.Name = "lblDateOfAdmissionHospitalization"
        '
        'lblFacilitySoughtCare
        '
        resources.ApplyResources(Me.lblFacilitySoughtCare, "lblFacilitySoughtCare")
        Me.lblFacilitySoughtCare.Name = "lblFacilitySoughtCare"
        '
        'lblInitialClinicalDiagnosis
        '
        resources.ApplyResources(Me.lblInitialClinicalDiagnosis, "lblInitialClinicalDiagnosis")
        Me.lblInitialClinicalDiagnosis.Name = "lblInitialClinicalDiagnosis"
        '
        'deDateOfAdmissionHospitalization
        '
        resources.ApplyResources(Me.deDateOfAdmissionHospitalization, "deDateOfAdmissionHospitalization")
        Me.deDateOfAdmissionHospitalization.Name = "deDateOfAdmissionHospitalization"
        Me.deDateOfAdmissionHospitalization.Properties.Appearance.Options.UseFont = True
        Me.deDateOfAdmissionHospitalization.Properties.AppearanceDisabled.Options.UseFont = True
        Me.deDateOfAdmissionHospitalization.Properties.AppearanceDropDown.Options.UseFont = True
        Me.deDateOfAdmissionHospitalization.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.deDateOfAdmissionHospitalization.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = True
        Me.deDateOfAdmissionHospitalization.Properties.AppearanceDropDownHighlight.Options.UseFont = True
        Me.deDateOfAdmissionHospitalization.Properties.AppearanceFocused.Options.UseFont = True
        Me.deDateOfAdmissionHospitalization.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.deDateOfAdmissionHospitalization.Properties.AppearanceWeekNumber.Options.UseFont = True
        Me.deDateOfAdmissionHospitalization.Properties.AutoHeight = CType(resources.GetObject("deDateOfAdmissionHospitalization.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject36.Options.UseFont = True
        Me.deDateOfAdmissionHospitalization.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("deDateOfAdmissionHospitalization.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("deDateOfAdmissionHospitalization.Properties.Buttons1"), CType(resources.GetObject("deDateOfAdmissionHospitalization.Properties.Buttons2"), Integer), CType(resources.GetObject("deDateOfAdmissionHospitalization.Properties.Buttons3"), Boolean), CType(resources.GetObject("deDateOfAdmissionHospitalization.Properties.Buttons4"), Boolean), CType(resources.GetObject("deDateOfAdmissionHospitalization.Properties.Buttons5"), Boolean), CType(resources.GetObject("deDateOfAdmissionHospitalization.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("deDateOfAdmissionHospitalization.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject36, resources.GetString("deDateOfAdmissionHospitalization.Properties.Buttons8"), CType(resources.GetObject("deDateOfAdmissionHospitalization.Properties.Buttons9"), Object), CType(resources.GetObject("deDateOfAdmissionHospitalization.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("deDateOfAdmissionHospitalization.Properties.Buttons11"), Boolean))})
        Me.deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties.Appearance.Options.UseFont = True
        Me.deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties.AppearanceDisabled.Options.UseFont = True
        Me.deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties.AppearanceFocused.Options.UseFont = True
        Me.deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties.AppearanceReadOnly.Options.UseFont = True
        Me.deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties.AutoHeight = CType(resources.GetObject("deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties.AutoHeight"), Boolean)
        SerializableAppearanceObject37.Options.UseFont = True
        Me.deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties.Buttons1"), CType(resources.GetObject("deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties.Buttons2"), Integer), CType(resources.GetObject("deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties.Buttons3"), Boolean), CType(resources.GetObject("deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties.Buttons4"), Boolean), CType(resources.GetObject("deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties.Buttons5"), Boolean), CType(resources.GetObject("deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject37, resources.GetString("deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties.Buttons8"), CType(resources.GetObject("deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties.Buttons9"), Object), CType(resources.GetObject("deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties.Buttons11"), Boolean))})
        Me.deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties.Mask.EditMask = resources.GetString("deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties.Mask.EditMask")
        Me.deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties.Mask.IgnoreMas" & _
        "kBlank"), Boolean)
        Me.deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties.Mask.MaskType = CType(resources.GetObject("deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties.Mask.SaveLiter" & _
        "al"), Boolean)
        Me.deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties.Mask.ShowPlace" & _
        "Holders"), Boolean)
        Me.deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties.NullValuePrompt = resources.GetString("deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties.NullValuePromp" & _
        "t")
        Me.deDateOfAdmissionHospitalization.Properties.Mask.EditMask = resources.GetString("deDateOfAdmissionHospitalization.Properties.Mask.EditMask")
        Me.deDateOfAdmissionHospitalization.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("deDateOfAdmissionHospitalization.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.deDateOfAdmissionHospitalization.Properties.Mask.MaskType = CType(resources.GetObject("deDateOfAdmissionHospitalization.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.deDateOfAdmissionHospitalization.Properties.Mask.SaveLiteral = CType(resources.GetObject("deDateOfAdmissionHospitalization.Properties.Mask.SaveLiteral"), Boolean)
        Me.deDateOfAdmissionHospitalization.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("deDateOfAdmissionHospitalization.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.deDateOfAdmissionHospitalization.Properties.NullValuePrompt = resources.GetString("deDateOfAdmissionHospitalization.Properties.NullValuePrompt")
        '
        'lblSymptomOnsetDate
        '
        resources.ApplyResources(Me.lblSymptomOnsetDate, "lblSymptomOnsetDate")
        Me.lblSymptomOnsetDate.Name = "lblSymptomOnsetDate"
        '
        'lblClinicalDiagnosis
        '
        resources.ApplyResources(Me.lblClinicalDiagnosis, "lblClinicalDiagnosis")
        Me.lblClinicalDiagnosis.Name = "lblClinicalDiagnosis"
        '
        'lblDatePatientFirstSought
        '
        resources.ApplyResources(Me.lblDatePatientFirstSought, "lblDatePatientFirstSought")
        Me.lblDatePatientFirstSought.Name = "lblDatePatientFirstSought"
        '
        'txtClinicalDiagnosis
        '
        resources.ApplyResources(Me.txtClinicalDiagnosis, "txtClinicalDiagnosis")
        Me.txtClinicalDiagnosis.Name = "txtClinicalDiagnosis"
        Me.txtClinicalDiagnosis.Properties.Appearance.Options.UseFont = True
        Me.txtClinicalDiagnosis.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtClinicalDiagnosis.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtClinicalDiagnosis.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtClinicalDiagnosis.Properties.AutoHeight = CType(resources.GetObject("txtClinicalDiagnosis.Properties.AutoHeight"), Boolean)
        Me.txtClinicalDiagnosis.Properties.Mask.EditMask = resources.GetString("txtClinicalDiagnosis.Properties.Mask.EditMask")
        Me.txtClinicalDiagnosis.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtClinicalDiagnosis.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtClinicalDiagnosis.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtClinicalDiagnosis.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtClinicalDiagnosis.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtClinicalDiagnosis.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtClinicalDiagnosis.Properties.NullValuePrompt = resources.GetString("txtClinicalDiagnosis.Properties.NullValuePrompt")
        Me.txtClinicalDiagnosis.Tag = "{R}"
        '
        'lblInitialCaseClassification
        '
        resources.ApplyResources(Me.lblInitialCaseClassification, "lblInitialCaseClassification")
        Me.lblInitialCaseClassification.Name = "lblInitialCaseClassification"
        '
        'deDatePatientFirstSought
        '
        resources.ApplyResources(Me.deDatePatientFirstSought, "deDatePatientFirstSought")
        Me.deDatePatientFirstSought.Name = "deDatePatientFirstSought"
        Me.deDatePatientFirstSought.Properties.Appearance.Options.UseFont = True
        Me.deDatePatientFirstSought.Properties.AppearanceDisabled.Options.UseFont = True
        Me.deDatePatientFirstSought.Properties.AppearanceDropDown.Options.UseFont = True
        Me.deDatePatientFirstSought.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.deDatePatientFirstSought.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = True
        Me.deDatePatientFirstSought.Properties.AppearanceDropDownHighlight.Options.UseFont = True
        Me.deDatePatientFirstSought.Properties.AppearanceFocused.Options.UseFont = True
        Me.deDatePatientFirstSought.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.deDatePatientFirstSought.Properties.AppearanceWeekNumber.Options.UseFont = True
        Me.deDatePatientFirstSought.Properties.AutoHeight = CType(resources.GetObject("deDatePatientFirstSought.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject38.Options.UseFont = True
        Me.deDatePatientFirstSought.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("deDatePatientFirstSought.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("deDatePatientFirstSought.Properties.Buttons1"), CType(resources.GetObject("deDatePatientFirstSought.Properties.Buttons2"), Integer), CType(resources.GetObject("deDatePatientFirstSought.Properties.Buttons3"), Boolean), CType(resources.GetObject("deDatePatientFirstSought.Properties.Buttons4"), Boolean), CType(resources.GetObject("deDatePatientFirstSought.Properties.Buttons5"), Boolean), CType(resources.GetObject("deDatePatientFirstSought.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("deDatePatientFirstSought.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject38, resources.GetString("deDatePatientFirstSought.Properties.Buttons8"), CType(resources.GetObject("deDatePatientFirstSought.Properties.Buttons9"), Object), CType(resources.GetObject("deDatePatientFirstSought.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("deDatePatientFirstSought.Properties.Buttons11"), Boolean))})
        Me.deDatePatientFirstSought.Properties.CalendarTimeProperties.Appearance.Options.UseFont = True
        Me.deDatePatientFirstSought.Properties.CalendarTimeProperties.AppearanceDisabled.Options.UseFont = True
        Me.deDatePatientFirstSought.Properties.CalendarTimeProperties.AppearanceFocused.Options.UseFont = True
        Me.deDatePatientFirstSought.Properties.CalendarTimeProperties.AppearanceReadOnly.Options.UseFont = True
        Me.deDatePatientFirstSought.Properties.CalendarTimeProperties.AutoHeight = CType(resources.GetObject("deDatePatientFirstSought.Properties.CalendarTimeProperties.AutoHeight"), Boolean)
        SerializableAppearanceObject39.Options.UseFont = True
        Me.deDatePatientFirstSought.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("deDatePatientFirstSought.Properties.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("deDatePatientFirstSought.Properties.CalendarTimeProperties.Buttons1"), CType(resources.GetObject("deDatePatientFirstSought.Properties.CalendarTimeProperties.Buttons2"), Integer), CType(resources.GetObject("deDatePatientFirstSought.Properties.CalendarTimeProperties.Buttons3"), Boolean), CType(resources.GetObject("deDatePatientFirstSought.Properties.CalendarTimeProperties.Buttons4"), Boolean), CType(resources.GetObject("deDatePatientFirstSought.Properties.CalendarTimeProperties.Buttons5"), Boolean), CType(resources.GetObject("deDatePatientFirstSought.Properties.CalendarTimeProperties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("deDatePatientFirstSought.Properties.CalendarTimeProperties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject39, resources.GetString("deDatePatientFirstSought.Properties.CalendarTimeProperties.Buttons8"), CType(resources.GetObject("deDatePatientFirstSought.Properties.CalendarTimeProperties.Buttons9"), Object), CType(resources.GetObject("deDatePatientFirstSought.Properties.CalendarTimeProperties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("deDatePatientFirstSought.Properties.CalendarTimeProperties.Buttons11"), Boolean))})
        Me.deDatePatientFirstSought.Properties.CalendarTimeProperties.Mask.EditMask = resources.GetString("deDatePatientFirstSought.Properties.CalendarTimeProperties.Mask.EditMask")
        Me.deDatePatientFirstSought.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("deDatePatientFirstSought.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.deDatePatientFirstSought.Properties.CalendarTimeProperties.Mask.MaskType = CType(resources.GetObject("deDatePatientFirstSought.Properties.CalendarTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.deDatePatientFirstSought.Properties.CalendarTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("deDatePatientFirstSought.Properties.CalendarTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.deDatePatientFirstSought.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("deDatePatientFirstSought.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.deDatePatientFirstSought.Properties.CalendarTimeProperties.NullValuePrompt = resources.GetString("deDatePatientFirstSought.Properties.CalendarTimeProperties.NullValuePrompt")
        Me.deDatePatientFirstSought.Properties.Mask.EditMask = resources.GetString("deDatePatientFirstSought.Properties.Mask.EditMask")
        Me.deDatePatientFirstSought.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("deDatePatientFirstSought.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.deDatePatientFirstSought.Properties.Mask.MaskType = CType(resources.GetObject("deDatePatientFirstSought.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.deDatePatientFirstSought.Properties.Mask.SaveLiteral = CType(resources.GetObject("deDatePatientFirstSought.Properties.Mask.SaveLiteral"), Boolean)
        Me.deDatePatientFirstSought.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("deDatePatientFirstSought.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.deDatePatientFirstSought.Properties.NullValuePrompt = resources.GetString("deDatePatientFirstSought.Properties.NullValuePrompt")
        '
        'txtSymptomOnsetDate
        '
        resources.ApplyResources(Me.txtSymptomOnsetDate, "txtSymptomOnsetDate")
        Me.txtSymptomOnsetDate.Name = "txtSymptomOnsetDate"
        Me.txtSymptomOnsetDate.Properties.Appearance.Options.UseFont = True
        Me.txtSymptomOnsetDate.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtSymptomOnsetDate.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtSymptomOnsetDate.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtSymptomOnsetDate.Properties.AutoHeight = CType(resources.GetObject("txtSymptomOnsetDate.Properties.AutoHeight"), Boolean)
        Me.txtSymptomOnsetDate.Properties.Mask.EditMask = resources.GetString("txtSymptomOnsetDate.Properties.Mask.EditMask")
        Me.txtSymptomOnsetDate.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtSymptomOnsetDate.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtSymptomOnsetDate.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtSymptomOnsetDate.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtSymptomOnsetDate.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtSymptomOnsetDate.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtSymptomOnsetDate.Properties.NullValuePrompt = resources.GetString("txtSymptomOnsetDate.Properties.NullValuePrompt")
        Me.txtSymptomOnsetDate.Tag = "{R}"
        '
        'cbFacilitySoughtCare
        '
        resources.ApplyResources(Me.cbFacilitySoughtCare, "cbFacilitySoughtCare")
        Me.cbFacilitySoughtCare.Name = "cbFacilitySoughtCare"
        Me.cbFacilitySoughtCare.Properties.Appearance.Options.UseFont = True
        Me.cbFacilitySoughtCare.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbFacilitySoughtCare.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbFacilitySoughtCare.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbFacilitySoughtCare.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbFacilitySoughtCare.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbFacilitySoughtCare.Properties.AutoHeight = CType(resources.GetObject("cbFacilitySoughtCare.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject40.Options.UseFont = True
        Me.cbFacilitySoughtCare.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbFacilitySoughtCare.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbFacilitySoughtCare.Properties.Buttons1"), CType(resources.GetObject("cbFacilitySoughtCare.Properties.Buttons2"), Integer), CType(resources.GetObject("cbFacilitySoughtCare.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbFacilitySoughtCare.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbFacilitySoughtCare.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbFacilitySoughtCare.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbFacilitySoughtCare.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject40, resources.GetString("cbFacilitySoughtCare.Properties.Buttons8"), CType(resources.GetObject("cbFacilitySoughtCare.Properties.Buttons9"), Object), CType(resources.GetObject("cbFacilitySoughtCare.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbFacilitySoughtCare.Properties.Buttons11"), Boolean))})
        Me.cbFacilitySoughtCare.Properties.NullText = resources.GetString("cbFacilitySoughtCare.Properties.NullText")
        Me.cbFacilitySoughtCare.Properties.NullValuePrompt = resources.GetString("cbFacilitySoughtCare.Properties.NullValuePrompt")
        '
        'btnRemoveAntimicrobialTherapy
        '
        Me.btnRemoveAntimicrobialTherapy.Appearance.Options.UseFont = True
        Me.btnRemoveAntimicrobialTherapy.Image = Global.eidss.My.Resources.Resources.Delete_Remove
        resources.ApplyResources(Me.btnRemoveAntimicrobialTherapy, "btnRemoveAntimicrobialTherapy")
        Me.btnRemoveAntimicrobialTherapy.Name = "btnRemoveAntimicrobialTherapy"
        '
        'gcAntimicrobialTherapy
        '
        Me.gcAntimicrobialTherapy.EmbeddedNavigator.AllowHtmlTextInToolTip = CType(resources.GetObject("gcAntimicrobialTherapy.EmbeddedNavigator.AllowHtmlTextInToolTip"), DevExpress.Utils.DefaultBoolean)
        Me.gcAntimicrobialTherapy.EmbeddedNavigator.Anchor = CType(resources.GetObject("gcAntimicrobialTherapy.EmbeddedNavigator.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.gcAntimicrobialTherapy.EmbeddedNavigator.Appearance.Options.UseFont = True
        Me.gcAntimicrobialTherapy.EmbeddedNavigator.BackgroundImageLayout = CType(resources.GetObject("gcAntimicrobialTherapy.EmbeddedNavigator.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.gcAntimicrobialTherapy.EmbeddedNavigator.ImeMode = CType(resources.GetObject("gcAntimicrobialTherapy.EmbeddedNavigator.ImeMode"), System.Windows.Forms.ImeMode)
        Me.gcAntimicrobialTherapy.EmbeddedNavigator.TextLocation = CType(resources.GetObject("gcAntimicrobialTherapy.EmbeddedNavigator.TextLocation"), DevExpress.XtraEditors.NavigatorButtonsTextLocation)
        Me.gcAntimicrobialTherapy.EmbeddedNavigator.ToolTipIconType = CType(resources.GetObject("gcAntimicrobialTherapy.EmbeddedNavigator.ToolTipIconType"), DevExpress.Utils.ToolTipIconType)
        resources.ApplyResources(Me.gcAntimicrobialTherapy, "gcAntimicrobialTherapy")
        Me.gcAntimicrobialTherapy.MainView = Me.gvAntimicrobialTherapy
        Me.gcAntimicrobialTherapy.Name = "gcAntimicrobialTherapy"
        Me.gcAntimicrobialTherapy.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvAntimicrobialTherapy})
        '
        'gvAntimicrobialTherapy
        '
        Me.gvAntimicrobialTherapy.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gcolAntimicrobialTherapyID, Me.gcolAntimicrobialTherapyName, Me.gcolAntimicrobialTherapyDose, Me.gcolFirstAntimicrobialAdminDate})
        Me.gvAntimicrobialTherapy.GridControl = Me.gcAntimicrobialTherapy
        resources.ApplyResources(Me.gvAntimicrobialTherapy, "gvAntimicrobialTherapy")
        Me.gvAntimicrobialTherapy.Name = "gvAntimicrobialTherapy"
        Me.gvAntimicrobialTherapy.OptionsCustomization.AllowGroup = False
        Me.gvAntimicrobialTherapy.OptionsView.ShowGroupPanel = False
        '
        'gcolAntimicrobialTherapyID
        '
        resources.ApplyResources(Me.gcolAntimicrobialTherapyID, "gcolAntimicrobialTherapyID")
        Me.gcolAntimicrobialTherapyID.FieldName = "idfAntimicrobialTherapy"
        Me.gcolAntimicrobialTherapyID.Name = "gcolAntimicrobialTherapyID"
        '
        'gcolAntimicrobialTherapyName
        '
        resources.ApplyResources(Me.gcolAntimicrobialTherapyName, "gcolAntimicrobialTherapyName")
        Me.gcolAntimicrobialTherapyName.FieldName = "strAntimicrobialTherapyName"
        Me.gcolAntimicrobialTherapyName.Name = "gcolAntimicrobialTherapyName"
        '
        'gcolAntimicrobialTherapyDose
        '
        resources.ApplyResources(Me.gcolAntimicrobialTherapyDose, "gcolAntimicrobialTherapyDose")
        Me.gcolAntimicrobialTherapyDose.FieldName = "strDosage"
        Me.gcolAntimicrobialTherapyDose.Name = "gcolAntimicrobialTherapyDose"
        '
        'gcolFirstAntimicrobialAdminDate
        '
        resources.ApplyResources(Me.gcolFirstAntimicrobialAdminDate, "gcolFirstAntimicrobialAdminDate")
        Me.gcolFirstAntimicrobialAdminDate.ColumnEdit = Me.dtFirstAntimicrobialAdminDate
        Me.gcolFirstAntimicrobialAdminDate.FieldName = "datFirstAdministeredDate"
        Me.gcolFirstAntimicrobialAdminDate.Name = "gcolFirstAntimicrobialAdminDate"
        '
        'tpSamples
        '
        Me.tpSamples.Appearance.Header.Options.UseFont = True
        Me.tpSamples.Appearance.HeaderActive.Options.UseFont = True
        Me.tpSamples.Appearance.HeaderDisabled.Options.UseFont = True
        Me.tpSamples.Appearance.HeaderHotTracked.Options.UseFont = True
        Me.tpSamples.Appearance.PageClient.Options.UseFont = True
        Me.tpSamples.Controls.Add(Me.cbNotCollectedReason)
        Me.tpSamples.Controls.Add(Me.lblNotCollectedReason)
        Me.tpSamples.Controls.Add(Me.cbSpecimenCollected)
        Me.tpSamples.Controls.Add(Me.lblSpecimenCollected)
        Me.tpSamples.Controls.Add(Me.HumanCaseSamplesPanel1)
        Me.tpSamples.Name = "tpSamples"
        resources.ApplyResources(Me.tpSamples, "tpSamples")
        '
        'cbNotCollectedReason
        '
        resources.ApplyResources(Me.cbNotCollectedReason, "cbNotCollectedReason")
        Me.cbNotCollectedReason.Name = "cbNotCollectedReason"
        Me.cbNotCollectedReason.Properties.Appearance.Options.UseFont = True
        Me.cbNotCollectedReason.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbNotCollectedReason.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbNotCollectedReason.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbNotCollectedReason.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbNotCollectedReason.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbNotCollectedReason.Properties.AutoHeight = CType(resources.GetObject("cbNotCollectedReason.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject41.Options.UseFont = True
        Me.cbNotCollectedReason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbNotCollectedReason.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbNotCollectedReason.Properties.Buttons1"), CType(resources.GetObject("cbNotCollectedReason.Properties.Buttons2"), Integer), CType(resources.GetObject("cbNotCollectedReason.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbNotCollectedReason.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbNotCollectedReason.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbNotCollectedReason.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbNotCollectedReason.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject41, resources.GetString("cbNotCollectedReason.Properties.Buttons8"), CType(resources.GetObject("cbNotCollectedReason.Properties.Buttons9"), Object), CType(resources.GetObject("cbNotCollectedReason.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbNotCollectedReason.Properties.Buttons11"), Boolean))})
        Me.cbNotCollectedReason.Properties.MaxLength = 200
        Me.cbNotCollectedReason.Properties.NullText = resources.GetString("cbNotCollectedReason.Properties.NullText")
        Me.cbNotCollectedReason.Properties.NullValuePrompt = resources.GetString("cbNotCollectedReason.Properties.NullValuePrompt")
        Me.cbNotCollectedReason.Tag = ""
        '
        'lblNotCollectedReason
        '
        Me.lblNotCollectedReason.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.lblNotCollectedReason, "lblNotCollectedReason")
        Me.lblNotCollectedReason.Name = "lblNotCollectedReason"
        '
        'cbSpecimenCollected
        '
        resources.ApplyResources(Me.cbSpecimenCollected, "cbSpecimenCollected")
        Me.cbSpecimenCollected.Name = "cbSpecimenCollected"
        Me.cbSpecimenCollected.Properties.Appearance.Options.UseFont = True
        Me.cbSpecimenCollected.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbSpecimenCollected.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbSpecimenCollected.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbSpecimenCollected.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbSpecimenCollected.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbSpecimenCollected.Properties.AutoHeight = CType(resources.GetObject("cbSpecimenCollected.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject42.Options.UseFont = True
        Me.cbSpecimenCollected.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSpecimenCollected.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbSpecimenCollected.Properties.Buttons1"), CType(resources.GetObject("cbSpecimenCollected.Properties.Buttons2"), Integer), CType(resources.GetObject("cbSpecimenCollected.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbSpecimenCollected.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbSpecimenCollected.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbSpecimenCollected.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbSpecimenCollected.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject42, resources.GetString("cbSpecimenCollected.Properties.Buttons8"), CType(resources.GetObject("cbSpecimenCollected.Properties.Buttons9"), Object), CType(resources.GetObject("cbSpecimenCollected.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbSpecimenCollected.Properties.Buttons11"), Boolean))})
        Me.cbSpecimenCollected.Properties.NullText = resources.GetString("cbSpecimenCollected.Properties.NullText")
        Me.cbSpecimenCollected.Properties.NullValuePrompt = resources.GetString("cbSpecimenCollected.Properties.NullValuePrompt")
        '
        'lblSpecimenCollected
        '
        resources.ApplyResources(Me.lblSpecimenCollected, "lblSpecimenCollected")
        Me.lblSpecimenCollected.Name = "lblSpecimenCollected"
        '
        'HumanCaseSamplesPanel1
        '
        Me.HumanCaseSamplesPanel1.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.HumanCaseSamplesPanel1, "HumanCaseSamplesPanel1")
        Me.HumanCaseSamplesPanel1.FormID = Nothing
        Me.HumanCaseSamplesPanel1.HelpTopicID = Nothing
        Me.HumanCaseSamplesPanel1.KeyFieldName = Nothing
        Me.HumanCaseSamplesPanel1.MultiSelect = False
        Me.HumanCaseSamplesPanel1.Name = "HumanCaseSamplesPanel1"
        Me.HumanCaseSamplesPanel1.ObjectName = Nothing
        Me.HumanCaseSamplesPanel1.TableName = Nothing
        Me.HumanCaseSamplesPanel1.ValidateDate = Nothing
        '
        'tpContactsRemarks
        '
        Me.tpContactsRemarks.Appearance.Header.Options.UseFont = True
        Me.tpContactsRemarks.Appearance.HeaderActive.Options.UseFont = True
        Me.tpContactsRemarks.Appearance.HeaderDisabled.Options.UseFont = True
        Me.tpContactsRemarks.Appearance.HeaderHotTracked.Options.UseFont = True
        Me.tpContactsRemarks.Appearance.PageClient.Options.UseFont = True
        Me.tpContactsRemarks.Controls.Add(Me.gcContactPeople)
        Me.tpContactsRemarks.Controls.Add(Me.btnAddContact)
        Me.tpContactsRemarks.Controls.Add(Me.btnDeleteContact)
        Me.tpContactsRemarks.Controls.Add(Me.btnEditContact)
        Me.tpContactsRemarks.Name = "tpContactsRemarks"
        resources.ApplyResources(Me.tpContactsRemarks, "tpContactsRemarks")
        '
        'gcContactPeople
        '
        resources.ApplyResources(Me.gcContactPeople, "gcContactPeople")
        Me.gcContactPeople.EmbeddedNavigator.AllowHtmlTextInToolTip = CType(resources.GetObject("gcContactPeople.EmbeddedNavigator.AllowHtmlTextInToolTip"), DevExpress.Utils.DefaultBoolean)
        Me.gcContactPeople.EmbeddedNavigator.Anchor = CType(resources.GetObject("gcContactPeople.EmbeddedNavigator.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.gcContactPeople.EmbeddedNavigator.Appearance.Options.UseFont = True
        Me.gcContactPeople.EmbeddedNavigator.BackgroundImageLayout = CType(resources.GetObject("gcContactPeople.EmbeddedNavigator.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.gcContactPeople.EmbeddedNavigator.ImeMode = CType(resources.GetObject("gcContactPeople.EmbeddedNavigator.ImeMode"), System.Windows.Forms.ImeMode)
        Me.gcContactPeople.EmbeddedNavigator.TextLocation = CType(resources.GetObject("gcContactPeople.EmbeddedNavigator.TextLocation"), DevExpress.XtraEditors.NavigatorButtonsTextLocation)
        Me.gcContactPeople.EmbeddedNavigator.ToolTipIconType = CType(resources.GetObject("gcContactPeople.EmbeddedNavigator.ToolTipIconType"), DevExpress.Utils.ToolTipIconType)
        Me.gcContactPeople.MainView = Me.gvContactPeople
        Me.gcContactPeople.Name = "gcContactPeople"
        Me.gcContactPeople.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cbContactType, Me.dtContactDate, Me.txtContactName, Me.txtContactComments})
        Me.gcContactPeople.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvContactPeople})
        '
        'gvContactPeople
        '
        Me.gvContactPeople.Appearance.ColumnFilterButton.Options.UseFont = True
        Me.gvContactPeople.Appearance.ColumnFilterButtonActive.Options.UseFont = True
        Me.gvContactPeople.Appearance.CustomizationFormHint.Options.UseFont = True
        Me.gvContactPeople.Appearance.DetailTip.Options.UseFont = True
        Me.gvContactPeople.Appearance.Empty.Options.UseFont = True
        Me.gvContactPeople.Appearance.EvenRow.Options.UseFont = True
        Me.gvContactPeople.Appearance.FilterCloseButton.Options.UseFont = True
        Me.gvContactPeople.Appearance.FilterPanel.Options.UseFont = True
        Me.gvContactPeople.Appearance.FixedLine.Options.UseFont = True
        Me.gvContactPeople.Appearance.FocusedCell.Options.UseFont = True
        Me.gvContactPeople.Appearance.FocusedRow.Options.UseFont = True
        Me.gvContactPeople.Appearance.FooterPanel.Options.UseFont = True
        Me.gvContactPeople.Appearance.GroupButton.Options.UseFont = True
        Me.gvContactPeople.Appearance.GroupFooter.Options.UseFont = True
        Me.gvContactPeople.Appearance.GroupPanel.Options.UseFont = True
        Me.gvContactPeople.Appearance.GroupRow.Options.UseFont = True
        Me.gvContactPeople.Appearance.HeaderPanel.Options.UseFont = True
        Me.gvContactPeople.Appearance.HideSelectionRow.Options.UseFont = True
        Me.gvContactPeople.Appearance.HorzLine.Options.UseFont = True
        Me.gvContactPeople.Appearance.OddRow.Options.UseFont = True
        Me.gvContactPeople.Appearance.Preview.Options.UseFont = True
        Me.gvContactPeople.Appearance.Row.Options.UseFont = True
        Me.gvContactPeople.Appearance.RowSeparator.Options.UseFont = True
        Me.gvContactPeople.Appearance.SelectedRow.Options.UseFont = True
        Me.gvContactPeople.Appearance.TopNewRow.Options.UseFont = True
        Me.gvContactPeople.Appearance.VertLine.Options.UseFont = True
        Me.gvContactPeople.Appearance.ViewCaption.Options.UseFont = True
        Me.gvContactPeople.AppearancePrint.EvenRow.Options.UseFont = True
        Me.gvContactPeople.AppearancePrint.FilterPanel.Options.UseFont = True
        Me.gvContactPeople.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.gvContactPeople.AppearancePrint.GroupFooter.Options.UseFont = True
        Me.gvContactPeople.AppearancePrint.GroupRow.Options.UseFont = True
        Me.gvContactPeople.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.gvContactPeople.AppearancePrint.Lines.Options.UseFont = True
        Me.gvContactPeople.AppearancePrint.OddRow.Options.UseFont = True
        Me.gvContactPeople.AppearancePrint.Preview.Options.UseFont = True
        Me.gvContactPeople.AppearancePrint.Row.Options.UseFont = True
        Me.gvContactPeople.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colName, Me.colRelationType, Me.colContactDate, Me.colContactPlace, Me.colContactInfo, Me.colComments})
        Me.gvContactPeople.GridControl = Me.gcContactPeople
        resources.ApplyResources(Me.gvContactPeople, "gvContactPeople")
        Me.gvContactPeople.Name = "gvContactPeople"
        Me.gvContactPeople.OptionsCustomization.AllowFilter = False
        Me.gvContactPeople.OptionsView.ShowGroupPanel = False
        '
        'colName
        '
        resources.ApplyResources(Me.colName, "colName")
        Me.colName.ColumnEdit = Me.txtContactName
        Me.colName.FieldName = "strName"
        Me.colName.Name = "colName"
        '
        'txtContactName
        '
        Me.txtContactName.Appearance.Options.UseFont = True
        Me.txtContactName.AppearanceDisabled.Options.UseFont = True
        Me.txtContactName.AppearanceFocused.Options.UseFont = True
        Me.txtContactName.AppearanceReadOnly.Options.UseFont = True
        resources.ApplyResources(Me.txtContactName, "txtContactName")
        SerializableAppearanceObject43.Options.UseFont = True
        SerializableAppearanceObject44.Options.UseFont = True
        Me.txtContactName.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtContactName.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtContactName.Buttons1"), CType(resources.GetObject("txtContactName.Buttons2"), Integer), CType(resources.GetObject("txtContactName.Buttons3"), Boolean), CType(resources.GetObject("txtContactName.Buttons4"), Boolean), CType(resources.GetObject("txtContactName.Buttons5"), Boolean), CType(resources.GetObject("txtContactName.Buttons6"), DevExpress.XtraEditors.ImageLocation), Global.eidss.My.Resources.Resources.Browse5, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject43, resources.GetString("txtContactName.Buttons7"), CType(resources.GetObject("txtContactName.Buttons8"), Object), CType(resources.GetObject("txtContactName.Buttons9"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtContactName.Buttons10"), Boolean)), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtContactName.Buttons11"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("txtContactName.Buttons12"), CType(resources.GetObject("txtContactName.Buttons13"), Integer), CType(resources.GetObject("txtContactName.Buttons14"), Boolean), CType(resources.GetObject("txtContactName.Buttons15"), Boolean), CType(resources.GetObject("txtContactName.Buttons16"), Boolean), CType(resources.GetObject("txtContactName.Buttons17"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("txtContactName.Buttons18"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject44, resources.GetString("txtContactName.Buttons19"), CType(resources.GetObject("txtContactName.Buttons20"), Object), CType(resources.GetObject("txtContactName.Buttons21"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("txtContactName.Buttons22"), Boolean))})
        Me.txtContactName.Mask.EditMask = resources.GetString("txtContactName.Mask.EditMask")
        Me.txtContactName.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtContactName.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtContactName.Mask.SaveLiteral = CType(resources.GetObject("txtContactName.Mask.SaveLiteral"), Boolean)
        Me.txtContactName.Mask.ShowPlaceHolders = CType(resources.GetObject("txtContactName.Mask.ShowPlaceHolders"), Boolean)
        Me.txtContactName.Name = "txtContactName"
        Me.txtContactName.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'colRelationType
        '
        resources.ApplyResources(Me.colRelationType, "colRelationType")
        Me.colRelationType.ColumnEdit = Me.cbContactType
        Me.colRelationType.FieldName = "idfsPersonContactType"
        Me.colRelationType.Name = "colRelationType"
        '
        'cbContactType
        '
        Me.cbContactType.Appearance.Options.UseFont = True
        Me.cbContactType.AppearanceDisabled.Options.UseFont = True
        Me.cbContactType.AppearanceDropDown.Options.UseFont = True
        Me.cbContactType.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbContactType.AppearanceFocused.Options.UseFont = True
        Me.cbContactType.AppearanceReadOnly.Options.UseFont = True
        resources.ApplyResources(Me.cbContactType, "cbContactType")
        SerializableAppearanceObject45.Options.UseFont = True
        Me.cbContactType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbContactType.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbContactType.Buttons1"), CType(resources.GetObject("cbContactType.Buttons2"), Integer), CType(resources.GetObject("cbContactType.Buttons3"), Boolean), CType(resources.GetObject("cbContactType.Buttons4"), Boolean), CType(resources.GetObject("cbContactType.Buttons5"), Boolean), CType(resources.GetObject("cbContactType.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbContactType.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject45, resources.GetString("cbContactType.Buttons8"), CType(resources.GetObject("cbContactType.Buttons9"), Object), CType(resources.GetObject("cbContactType.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbContactType.Buttons11"), Boolean))})
        Me.cbContactType.Name = "cbContactType"
        '
        'colContactDate
        '
        resources.ApplyResources(Me.colContactDate, "colContactDate")
        Me.colContactDate.ColumnEdit = Me.dtContactDate
        Me.colContactDate.FieldName = "datDateOfLastContact"
        Me.colContactDate.Name = "colContactDate"
        '
        'dtContactDate
        '
        Me.dtContactDate.Appearance.Options.UseFont = True
        Me.dtContactDate.AppearanceDisabled.Options.UseFont = True
        Me.dtContactDate.AppearanceDropDown.Options.UseFont = True
        Me.dtContactDate.AppearanceDropDownHeader.Options.UseFont = True
        Me.dtContactDate.AppearanceDropDownHeaderHighlight.Options.UseFont = True
        Me.dtContactDate.AppearanceDropDownHighlight.Options.UseFont = True
        Me.dtContactDate.AppearanceFocused.Options.UseFont = True
        Me.dtContactDate.AppearanceReadOnly.Options.UseFont = True
        Me.dtContactDate.AppearanceWeekNumber.Options.UseFont = True
        resources.ApplyResources(Me.dtContactDate, "dtContactDate")
        SerializableAppearanceObject46.Options.UseFont = True
        Me.dtContactDate.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtContactDate.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("dtContactDate.Buttons1"), CType(resources.GetObject("dtContactDate.Buttons2"), Integer), CType(resources.GetObject("dtContactDate.Buttons3"), Boolean), CType(resources.GetObject("dtContactDate.Buttons4"), Boolean), CType(resources.GetObject("dtContactDate.Buttons5"), Boolean), CType(resources.GetObject("dtContactDate.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("dtContactDate.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject46, resources.GetString("dtContactDate.Buttons8"), CType(resources.GetObject("dtContactDate.Buttons9"), Object), CType(resources.GetObject("dtContactDate.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("dtContactDate.Buttons11"), Boolean))})
        Me.dtContactDate.CalendarTimeProperties.Appearance.Options.UseFont = True
        Me.dtContactDate.CalendarTimeProperties.AppearanceDisabled.Options.UseFont = True
        Me.dtContactDate.CalendarTimeProperties.AppearanceFocused.Options.UseFont = True
        Me.dtContactDate.CalendarTimeProperties.AppearanceReadOnly.Options.UseFont = True
        Me.dtContactDate.CalendarTimeProperties.AutoHeight = CType(resources.GetObject("dtContactDate.CalendarTimeProperties.AutoHeight"), Boolean)
        SerializableAppearanceObject47.Options.UseFont = True
        Me.dtContactDate.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtContactDate.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("dtContactDate.CalendarTimeProperties.Buttons1"), CType(resources.GetObject("dtContactDate.CalendarTimeProperties.Buttons2"), Integer), CType(resources.GetObject("dtContactDate.CalendarTimeProperties.Buttons3"), Boolean), CType(resources.GetObject("dtContactDate.CalendarTimeProperties.Buttons4"), Boolean), CType(resources.GetObject("dtContactDate.CalendarTimeProperties.Buttons5"), Boolean), CType(resources.GetObject("dtContactDate.CalendarTimeProperties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("dtContactDate.CalendarTimeProperties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject47, resources.GetString("dtContactDate.CalendarTimeProperties.Buttons8"), CType(resources.GetObject("dtContactDate.CalendarTimeProperties.Buttons9"), Object), CType(resources.GetObject("dtContactDate.CalendarTimeProperties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("dtContactDate.CalendarTimeProperties.Buttons11"), Boolean))})
        Me.dtContactDate.CalendarTimeProperties.Mask.EditMask = resources.GetString("dtContactDate.CalendarTimeProperties.Mask.EditMask")
        Me.dtContactDate.CalendarTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtContactDate.CalendarTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtContactDate.CalendarTimeProperties.Mask.MaskType = CType(resources.GetObject("dtContactDate.CalendarTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtContactDate.CalendarTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("dtContactDate.CalendarTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.dtContactDate.CalendarTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtContactDate.CalendarTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtContactDate.CalendarTimeProperties.NullValuePrompt = resources.GetString("dtContactDate.CalendarTimeProperties.NullValuePrompt")
        Me.dtContactDate.Mask.EditMask = resources.GetString("dtContactDate.Mask.EditMask")
        Me.dtContactDate.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtContactDate.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtContactDate.Mask.MaskType = CType(resources.GetObject("dtContactDate.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtContactDate.Mask.SaveLiteral = CType(resources.GetObject("dtContactDate.Mask.SaveLiteral"), Boolean)
        Me.dtContactDate.Mask.ShowPlaceHolders = CType(resources.GetObject("dtContactDate.Mask.ShowPlaceHolders"), Boolean)
        Me.dtContactDate.Name = "dtContactDate"
        '
        'colContactPlace
        '
        resources.ApplyResources(Me.colContactPlace, "colContactPlace")
        Me.colContactPlace.FieldName = "strPlaceInfo"
        Me.colContactPlace.Name = "colContactPlace"
        '
        'colContactInfo
        '
        resources.ApplyResources(Me.colContactInfo, "colContactInfo")
        Me.colContactInfo.FieldName = "strPatientInformation"
        Me.colContactInfo.Name = "colContactInfo"
        Me.colContactInfo.OptionsColumn.AllowEdit = False
        '
        'colComments
        '
        resources.ApplyResources(Me.colComments, "colComments")
        Me.colComments.ColumnEdit = Me.txtContactComments
        Me.colComments.FieldName = "strComments"
        Me.colComments.Name = "colComments"
        '
        'txtContactComments
        '
        Me.txtContactComments.Appearance.Options.UseFont = True
        Me.txtContactComments.AppearanceDisabled.Options.UseFont = True
        Me.txtContactComments.AppearanceDropDown.Options.UseFont = True
        Me.txtContactComments.AppearanceFocused.Options.UseFont = True
        Me.txtContactComments.AppearanceReadOnly.Options.UseFont = True
        Me.txtContactComments.MaxLength = 500
        Me.txtContactComments.Name = "txtContactComments"
        Me.txtContactComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtContactComments.ShowIcon = False
        '
        'btnAddContact
        '
        resources.ApplyResources(Me.btnAddContact, "btnAddContact")
        Me.btnAddContact.Appearance.Options.UseFont = True
        Me.btnAddContact.Image = Global.eidss.My.Resources.Resources.add
        Me.btnAddContact.Name = "btnAddContact"
        '
        'btnDeleteContact
        '
        resources.ApplyResources(Me.btnDeleteContact, "btnDeleteContact")
        Me.btnDeleteContact.Appearance.Options.UseFont = True
        Me.btnDeleteContact.Image = Global.eidss.My.Resources.Resources.Delete_Remove
        Me.btnDeleteContact.Name = "btnDeleteContact"
        '
        'btnEditContact
        '
        resources.ApplyResources(Me.btnEditContact, "btnEditContact")
        Me.btnEditContact.Appearance.Options.UseFont = True
        Me.btnEditContact.Image = Global.eidss.My.Resources.Resources.edit
        Me.btnEditContact.Name = "btnEditContact"
        '
        'tpCaseClassification
        '
        Me.tpCaseClassification.Appearance.Header.Options.UseFont = True
        Me.tpCaseClassification.Appearance.HeaderActive.Options.UseFont = True
        Me.tpCaseClassification.Appearance.HeaderDisabled.Options.UseFont = True
        Me.tpCaseClassification.Appearance.HeaderHotTracked.Options.UseFont = True
        Me.tpCaseClassification.Appearance.PageClient.Options.UseFont = True
        Me.tpCaseClassification.Controls.Add(Me.FFClinicalSigns)
        Me.tpCaseClassification.Name = "tpCaseClassification"
        resources.ApplyResources(Me.tpCaseClassification, "tpCaseClassification")
        '
        'FFClinicalSigns
        '
        Me.FFClinicalSigns.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.FFClinicalSigns, "FFClinicalSigns")
        Me.FFClinicalSigns.DelayedLoadingNeeded = False
        Me.FFClinicalSigns.DynamicParameterEnabled = False
        Me.FFClinicalSigns.FormID = Nothing
        Me.FFClinicalSigns.HelpTopicID = Nothing
        Me.FFClinicalSigns.KeyFieldName = Nothing
        Me.FFClinicalSigns.MultiSelect = False
        Me.FFClinicalSigns.Name = "FFClinicalSigns"
        Me.FFClinicalSigns.ObjectName = Nothing
        Me.FFClinicalSigns.SectionTableCaptionsIsVisible = True
        Me.FFClinicalSigns.TableName = Nothing
        '
        'tpEpiLinksRiskFactors
        '
        Me.tpEpiLinksRiskFactors.Appearance.Header.Options.UseFont = True
        Me.tpEpiLinksRiskFactors.Appearance.HeaderActive.Options.UseFont = True
        Me.tpEpiLinksRiskFactors.Appearance.HeaderDisabled.Options.UseFont = True
        Me.tpEpiLinksRiskFactors.Appearance.HeaderHotTracked.Options.UseFont = True
        Me.tpEpiLinksRiskFactors.Appearance.PageClient.Options.UseFont = True
        Me.tpEpiLinksRiskFactors.Controls.Add(Me.ffEpiInvestigations)
        Me.tpEpiLinksRiskFactors.Name = "tpEpiLinksRiskFactors"
        resources.ApplyResources(Me.tpEpiLinksRiskFactors, "tpEpiLinksRiskFactors")
        '
        'ffEpiInvestigations
        '
        Me.ffEpiInvestigations.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.ffEpiInvestigations, "ffEpiInvestigations")
        Me.ffEpiInvestigations.DelayedLoadingNeeded = False
        Me.ffEpiInvestigations.DynamicParameterEnabled = False
        Me.ffEpiInvestigations.FormID = Nothing
        Me.ffEpiInvestigations.HelpTopicID = Nothing
        Me.ffEpiInvestigations.KeyFieldName = Nothing
        Me.ffEpiInvestigations.MultiSelect = False
        Me.ffEpiInvestigations.Name = "ffEpiInvestigations"
        Me.ffEpiInvestigations.ObjectName = Nothing
        Me.ffEpiInvestigations.SectionTableCaptionsIsVisible = True
        Me.ffEpiInvestigations.TableName = Nothing
        '
        'tpCaseSummary
        '
        Me.tpCaseSummary.Appearance.Header.Options.UseFont = True
        Me.tpCaseSummary.Appearance.HeaderActive.Options.UseFont = True
        Me.tpCaseSummary.Appearance.HeaderDisabled.Options.UseFont = True
        Me.tpCaseSummary.Appearance.HeaderHotTracked.Options.UseFont = True
        Me.tpCaseSummary.Appearance.PageClient.Options.UseFont = True
        Me.tpCaseSummary.Controls.Add(Me.dtFinalCaseClassificationDate)
        Me.tpCaseSummary.Controls.Add(Me.lbFinalCaseClassificationDate)
        Me.tpCaseSummary.Controls.Add(Me.cbEpidemiologistName)
        Me.tpCaseSummary.Controls.Add(Me.chbEpiDiagBasis)
        Me.tpCaseSummary.Controls.Add(Me.chbLabDiagBasis)
        Me.tpCaseSummary.Controls.Add(Me.chbClinicalDiagBasis)
        Me.tpCaseSummary.Controls.Add(Me.deDateOfDeath)
        Me.tpCaseSummary.Controls.Add(Me.lblFinalDiagnosisDate)
        Me.tpCaseSummary.Controls.Add(Me.dtFinalDiagnosisDate)
        Me.tpCaseSummary.Controls.Add(Me.lblDateOfDeath)
        Me.tpCaseSummary.Controls.Add(Me.cbOutbreakExists)
        Me.tpCaseSummary.Controls.Add(Me.lueFinalCaseClassification)
        Me.tpCaseSummary.Controls.Add(Me.lblFinalCaseClassification)
        Me.tpCaseSummary.Controls.Add(Me.lblOutbreakExists)
        Me.tpCaseSummary.Controls.Add(Me.cbOutcome)
        Me.tpCaseSummary.Controls.Add(Me.lblOutcome)
        Me.tpCaseSummary.Controls.Add(Me.lblFinalDiagnosis)
        Me.tpCaseSummary.Controls.Add(Me.txtFinalDiagnosis)
        Me.tpCaseSummary.Controls.Add(Me.lblBasisOfDiagnosis)
        Me.tpCaseSummary.Controls.Add(Me.lblEpidemiologistsName)
        Me.tpCaseSummary.Controls.Add(Me.lblSummaryComments)
        Me.tpCaseSummary.Controls.Add(Me.cbOutbreakID)
        Me.tpCaseSummary.Controls.Add(Me.lblOutbreakID)
        Me.tpCaseSummary.Controls.Add(Me.lblDateOfDischarge)
        Me.tpCaseSummary.Controls.Add(Me.lblDischargeDate)
        Me.tpCaseSummary.Controls.Add(Me.meSummaryComments)
        Me.tpCaseSummary.Controls.Add(Me.deDateOfDischarge)
        Me.tpCaseSummary.Controls.Add(Me.txtDischargeDate)
        Me.tpCaseSummary.Name = "tpCaseSummary"
        resources.ApplyResources(Me.tpCaseSummary, "tpCaseSummary")
        '
        'dtFinalCaseClassificationDate
        '
        resources.ApplyResources(Me.dtFinalCaseClassificationDate, "dtFinalCaseClassificationDate")
        Me.dtFinalCaseClassificationDate.Name = "dtFinalCaseClassificationDate"
        Me.dtFinalCaseClassificationDate.Properties.Appearance.Options.UseFont = True
        Me.dtFinalCaseClassificationDate.Properties.AppearanceDisabled.Options.UseFont = True
        Me.dtFinalCaseClassificationDate.Properties.AppearanceDropDown.Options.UseFont = True
        Me.dtFinalCaseClassificationDate.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.dtFinalCaseClassificationDate.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = True
        Me.dtFinalCaseClassificationDate.Properties.AppearanceDropDownHighlight.Options.UseFont = True
        Me.dtFinalCaseClassificationDate.Properties.AppearanceFocused.Options.UseFont = True
        Me.dtFinalCaseClassificationDate.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.dtFinalCaseClassificationDate.Properties.AppearanceWeekNumber.Options.UseFont = True
        Me.dtFinalCaseClassificationDate.Properties.AutoHeight = CType(resources.GetObject("dtFinalCaseClassificationDate.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject48.Options.UseFont = True
        Me.dtFinalCaseClassificationDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtFinalCaseClassificationDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("dtFinalCaseClassificationDate.Properties.Buttons1"), CType(resources.GetObject("dtFinalCaseClassificationDate.Properties.Buttons2"), Integer), CType(resources.GetObject("dtFinalCaseClassificationDate.Properties.Buttons3"), Boolean), CType(resources.GetObject("dtFinalCaseClassificationDate.Properties.Buttons4"), Boolean), CType(resources.GetObject("dtFinalCaseClassificationDate.Properties.Buttons5"), Boolean), CType(resources.GetObject("dtFinalCaseClassificationDate.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("dtFinalCaseClassificationDate.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject48, resources.GetString("dtFinalCaseClassificationDate.Properties.Buttons8"), CType(resources.GetObject("dtFinalCaseClassificationDate.Properties.Buttons9"), Object), CType(resources.GetObject("dtFinalCaseClassificationDate.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("dtFinalCaseClassificationDate.Properties.Buttons11"), Boolean))})
        Me.dtFinalCaseClassificationDate.Properties.CalendarTimeProperties.Appearance.Options.UseFont = True
        Me.dtFinalCaseClassificationDate.Properties.CalendarTimeProperties.AppearanceDisabled.Options.UseFont = True
        Me.dtFinalCaseClassificationDate.Properties.CalendarTimeProperties.AppearanceFocused.Options.UseFont = True
        Me.dtFinalCaseClassificationDate.Properties.CalendarTimeProperties.AppearanceReadOnly.Options.UseFont = True
        Me.dtFinalCaseClassificationDate.Properties.CalendarTimeProperties.AutoHeight = CType(resources.GetObject("dtFinalCaseClassificationDate.Properties.CalendarTimeProperties.AutoHeight"), Boolean)
        SerializableAppearanceObject49.Options.UseFont = True
        Me.dtFinalCaseClassificationDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtFinalCaseClassificationDate.Properties.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("dtFinalCaseClassificationDate.Properties.CalendarTimeProperties.Buttons1"), CType(resources.GetObject("dtFinalCaseClassificationDate.Properties.CalendarTimeProperties.Buttons2"), Integer), CType(resources.GetObject("dtFinalCaseClassificationDate.Properties.CalendarTimeProperties.Buttons3"), Boolean), CType(resources.GetObject("dtFinalCaseClassificationDate.Properties.CalendarTimeProperties.Buttons4"), Boolean), CType(resources.GetObject("dtFinalCaseClassificationDate.Properties.CalendarTimeProperties.Buttons5"), Boolean), CType(resources.GetObject("dtFinalCaseClassificationDate.Properties.CalendarTimeProperties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("dtFinalCaseClassificationDate.Properties.CalendarTimeProperties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject49, resources.GetString("dtFinalCaseClassificationDate.Properties.CalendarTimeProperties.Buttons8"), CType(resources.GetObject("dtFinalCaseClassificationDate.Properties.CalendarTimeProperties.Buttons9"), Object), CType(resources.GetObject("dtFinalCaseClassificationDate.Properties.CalendarTimeProperties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("dtFinalCaseClassificationDate.Properties.CalendarTimeProperties.Buttons11"), Boolean))})
        Me.dtFinalCaseClassificationDate.Properties.CalendarTimeProperties.Mask.EditMask = resources.GetString("dtFinalCaseClassificationDate.Properties.CalendarTimeProperties.Mask.EditMask")
        Me.dtFinalCaseClassificationDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtFinalCaseClassificationDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBl" & _
        "ank"), Boolean)
        Me.dtFinalCaseClassificationDate.Properties.CalendarTimeProperties.Mask.MaskType = CType(resources.GetObject("dtFinalCaseClassificationDate.Properties.CalendarTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtFinalCaseClassificationDate.Properties.CalendarTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("dtFinalCaseClassificationDate.Properties.CalendarTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.dtFinalCaseClassificationDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtFinalCaseClassificationDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHol" & _
        "ders"), Boolean)
        Me.dtFinalCaseClassificationDate.Properties.CalendarTimeProperties.NullValuePrompt = resources.GetString("dtFinalCaseClassificationDate.Properties.CalendarTimeProperties.NullValuePrompt")
        Me.dtFinalCaseClassificationDate.Properties.Mask.EditMask = resources.GetString("dtFinalCaseClassificationDate.Properties.Mask.EditMask")
        Me.dtFinalCaseClassificationDate.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtFinalCaseClassificationDate.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtFinalCaseClassificationDate.Properties.Mask.MaskType = CType(resources.GetObject("dtFinalCaseClassificationDate.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtFinalCaseClassificationDate.Properties.Mask.SaveLiteral = CType(resources.GetObject("dtFinalCaseClassificationDate.Properties.Mask.SaveLiteral"), Boolean)
        Me.dtFinalCaseClassificationDate.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtFinalCaseClassificationDate.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtFinalCaseClassificationDate.Properties.NullValuePrompt = resources.GetString("dtFinalCaseClassificationDate.Properties.NullValuePrompt")
        '
        'lbFinalCaseClassificationDate
        '
        resources.ApplyResources(Me.lbFinalCaseClassificationDate, "lbFinalCaseClassificationDate")
        Me.lbFinalCaseClassificationDate.Name = "lbFinalCaseClassificationDate"
        '
        'cbEpidemiologistName
        '
        resources.ApplyResources(Me.cbEpidemiologistName, "cbEpidemiologistName")
        Me.cbEpidemiologistName.Name = "cbEpidemiologistName"
        Me.cbEpidemiologistName.Properties.Appearance.Options.UseFont = True
        Me.cbEpidemiologistName.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbEpidemiologistName.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbEpidemiologistName.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbEpidemiologistName.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbEpidemiologistName.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbEpidemiologistName.Properties.AutoHeight = CType(resources.GetObject("cbEpidemiologistName.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject50.Options.UseFont = True
        Me.cbEpidemiologistName.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbEpidemiologistName.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbEpidemiologistName.Properties.Buttons1"), CType(resources.GetObject("cbEpidemiologistName.Properties.Buttons2"), Integer), CType(resources.GetObject("cbEpidemiologistName.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbEpidemiologistName.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbEpidemiologistName.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbEpidemiologistName.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbEpidemiologistName.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject50, resources.GetString("cbEpidemiologistName.Properties.Buttons8"), CType(resources.GetObject("cbEpidemiologistName.Properties.Buttons9"), Object), CType(resources.GetObject("cbEpidemiologistName.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbEpidemiologistName.Properties.Buttons11"), Boolean))})
        Me.cbEpidemiologistName.Properties.NullText = resources.GetString("cbEpidemiologistName.Properties.NullText")
        Me.cbEpidemiologistName.Properties.NullValuePrompt = resources.GetString("cbEpidemiologistName.Properties.NullValuePrompt")
        Me.cbEpidemiologistName.Tag = ""
        '
        'chbEpiDiagBasis
        '
        resources.ApplyResources(Me.chbEpiDiagBasis, "chbEpiDiagBasis")
        Me.chbEpiDiagBasis.Name = "chbEpiDiagBasis"
        Me.chbEpiDiagBasis.Properties.Appearance.Options.UseFont = True
        Me.chbEpiDiagBasis.Properties.AppearanceDisabled.Options.UseFont = True
        Me.chbEpiDiagBasis.Properties.AppearanceFocused.Options.UseFont = True
        Me.chbEpiDiagBasis.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.chbEpiDiagBasis.Properties.AutoHeight = CType(resources.GetObject("chbEpiDiagBasis.Properties.AutoHeight"), Boolean)
        Me.chbEpiDiagBasis.Properties.Caption = resources.GetString("chbEpiDiagBasis.Properties.Caption")
        Me.chbEpiDiagBasis.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'chbLabDiagBasis
        '
        resources.ApplyResources(Me.chbLabDiagBasis, "chbLabDiagBasis")
        Me.chbLabDiagBasis.Name = "chbLabDiagBasis"
        Me.chbLabDiagBasis.Properties.Appearance.Options.UseFont = True
        Me.chbLabDiagBasis.Properties.AppearanceDisabled.Options.UseFont = True
        Me.chbLabDiagBasis.Properties.AppearanceFocused.Options.UseFont = True
        Me.chbLabDiagBasis.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.chbLabDiagBasis.Properties.AutoHeight = CType(resources.GetObject("chbLabDiagBasis.Properties.AutoHeight"), Boolean)
        Me.chbLabDiagBasis.Properties.Caption = resources.GetString("chbLabDiagBasis.Properties.Caption")
        Me.chbLabDiagBasis.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'chbClinicalDiagBasis
        '
        resources.ApplyResources(Me.chbClinicalDiagBasis, "chbClinicalDiagBasis")
        Me.chbClinicalDiagBasis.Name = "chbClinicalDiagBasis"
        Me.chbClinicalDiagBasis.Properties.Appearance.Options.UseFont = True
        Me.chbClinicalDiagBasis.Properties.AppearanceDisabled.Options.UseFont = True
        Me.chbClinicalDiagBasis.Properties.AppearanceFocused.Options.UseFont = True
        Me.chbClinicalDiagBasis.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.chbClinicalDiagBasis.Properties.AutoHeight = CType(resources.GetObject("chbClinicalDiagBasis.Properties.AutoHeight"), Boolean)
        Me.chbClinicalDiagBasis.Properties.Caption = resources.GetString("chbClinicalDiagBasis.Properties.Caption")
        Me.chbClinicalDiagBasis.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'deDateOfDeath
        '
        resources.ApplyResources(Me.deDateOfDeath, "deDateOfDeath")
        Me.deDateOfDeath.Name = "deDateOfDeath"
        Me.deDateOfDeath.Properties.Appearance.Options.UseFont = True
        Me.deDateOfDeath.Properties.AppearanceDisabled.Options.UseFont = True
        Me.deDateOfDeath.Properties.AppearanceDropDown.Options.UseFont = True
        Me.deDateOfDeath.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.deDateOfDeath.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = True
        Me.deDateOfDeath.Properties.AppearanceDropDownHighlight.Options.UseFont = True
        Me.deDateOfDeath.Properties.AppearanceFocused.Options.UseFont = True
        Me.deDateOfDeath.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.deDateOfDeath.Properties.AppearanceWeekNumber.Options.UseFont = True
        Me.deDateOfDeath.Properties.AutoHeight = CType(resources.GetObject("deDateOfDeath.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject51.Options.UseFont = True
        Me.deDateOfDeath.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("deDateOfDeath.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("deDateOfDeath.Properties.Buttons1"), CType(resources.GetObject("deDateOfDeath.Properties.Buttons2"), Integer), CType(resources.GetObject("deDateOfDeath.Properties.Buttons3"), Boolean), CType(resources.GetObject("deDateOfDeath.Properties.Buttons4"), Boolean), CType(resources.GetObject("deDateOfDeath.Properties.Buttons5"), Boolean), CType(resources.GetObject("deDateOfDeath.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("deDateOfDeath.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject51, resources.GetString("deDateOfDeath.Properties.Buttons8"), CType(resources.GetObject("deDateOfDeath.Properties.Buttons9"), Object), CType(resources.GetObject("deDateOfDeath.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("deDateOfDeath.Properties.Buttons11"), Boolean))})
        Me.deDateOfDeath.Properties.CalendarTimeProperties.Appearance.Options.UseFont = True
        Me.deDateOfDeath.Properties.CalendarTimeProperties.AppearanceDisabled.Options.UseFont = True
        Me.deDateOfDeath.Properties.CalendarTimeProperties.AppearanceFocused.Options.UseFont = True
        Me.deDateOfDeath.Properties.CalendarTimeProperties.AppearanceReadOnly.Options.UseFont = True
        Me.deDateOfDeath.Properties.CalendarTimeProperties.AutoHeight = CType(resources.GetObject("deDateOfDeath.Properties.CalendarTimeProperties.AutoHeight"), Boolean)
        SerializableAppearanceObject52.Options.UseFont = True
        Me.deDateOfDeath.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("deDateOfDeath.Properties.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("deDateOfDeath.Properties.CalendarTimeProperties.Buttons1"), CType(resources.GetObject("deDateOfDeath.Properties.CalendarTimeProperties.Buttons2"), Integer), CType(resources.GetObject("deDateOfDeath.Properties.CalendarTimeProperties.Buttons3"), Boolean), CType(resources.GetObject("deDateOfDeath.Properties.CalendarTimeProperties.Buttons4"), Boolean), CType(resources.GetObject("deDateOfDeath.Properties.CalendarTimeProperties.Buttons5"), Boolean), CType(resources.GetObject("deDateOfDeath.Properties.CalendarTimeProperties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("deDateOfDeath.Properties.CalendarTimeProperties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject52, resources.GetString("deDateOfDeath.Properties.CalendarTimeProperties.Buttons8"), CType(resources.GetObject("deDateOfDeath.Properties.CalendarTimeProperties.Buttons9"), Object), CType(resources.GetObject("deDateOfDeath.Properties.CalendarTimeProperties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("deDateOfDeath.Properties.CalendarTimeProperties.Buttons11"), Boolean))})
        Me.deDateOfDeath.Properties.CalendarTimeProperties.Mask.EditMask = resources.GetString("deDateOfDeath.Properties.CalendarTimeProperties.Mask.EditMask")
        Me.deDateOfDeath.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("deDateOfDeath.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.deDateOfDeath.Properties.CalendarTimeProperties.Mask.MaskType = CType(resources.GetObject("deDateOfDeath.Properties.CalendarTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.deDateOfDeath.Properties.CalendarTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("deDateOfDeath.Properties.CalendarTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.deDateOfDeath.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("deDateOfDeath.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.deDateOfDeath.Properties.CalendarTimeProperties.NullValuePrompt = resources.GetString("deDateOfDeath.Properties.CalendarTimeProperties.NullValuePrompt")
        Me.deDateOfDeath.Properties.Mask.EditMask = resources.GetString("deDateOfDeath.Properties.Mask.EditMask")
        Me.deDateOfDeath.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("deDateOfDeath.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.deDateOfDeath.Properties.Mask.MaskType = CType(resources.GetObject("deDateOfDeath.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.deDateOfDeath.Properties.Mask.SaveLiteral = CType(resources.GetObject("deDateOfDeath.Properties.Mask.SaveLiteral"), Boolean)
        Me.deDateOfDeath.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("deDateOfDeath.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.deDateOfDeath.Properties.NullValuePrompt = resources.GetString("deDateOfDeath.Properties.NullValuePrompt")
        '
        'lblFinalDiagnosisDate
        '
        resources.ApplyResources(Me.lblFinalDiagnosisDate, "lblFinalDiagnosisDate")
        Me.lblFinalDiagnosisDate.Name = "lblFinalDiagnosisDate"
        '
        'dtFinalDiagnosisDate
        '
        resources.ApplyResources(Me.dtFinalDiagnosisDate, "dtFinalDiagnosisDate")
        Me.dtFinalDiagnosisDate.Name = "dtFinalDiagnosisDate"
        Me.dtFinalDiagnosisDate.Properties.Appearance.Options.UseFont = True
        Me.dtFinalDiagnosisDate.Properties.AppearanceDisabled.Options.UseFont = True
        Me.dtFinalDiagnosisDate.Properties.AppearanceFocused.Options.UseFont = True
        Me.dtFinalDiagnosisDate.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.dtFinalDiagnosisDate.Properties.AutoHeight = CType(resources.GetObject("dtFinalDiagnosisDate.Properties.AutoHeight"), Boolean)
        Me.dtFinalDiagnosisDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtFinalDiagnosisDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtFinalDiagnosisDate.Properties.CalendarTimeProperties.AutoHeight = CType(resources.GetObject("dtFinalDiagnosisDate.Properties.CalendarTimeProperties.AutoHeight"), Boolean)
        Me.dtFinalDiagnosisDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtFinalDiagnosisDate.Properties.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.dtFinalDiagnosisDate.Properties.CalendarTimeProperties.Mask.EditMask = resources.GetString("dtFinalDiagnosisDate.Properties.CalendarTimeProperties.Mask.EditMask")
        Me.dtFinalDiagnosisDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtFinalDiagnosisDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtFinalDiagnosisDate.Properties.CalendarTimeProperties.Mask.MaskType = CType(resources.GetObject("dtFinalDiagnosisDate.Properties.CalendarTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtFinalDiagnosisDate.Properties.CalendarTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("dtFinalDiagnosisDate.Properties.CalendarTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.dtFinalDiagnosisDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtFinalDiagnosisDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtFinalDiagnosisDate.Properties.CalendarTimeProperties.NullValuePrompt = resources.GetString("dtFinalDiagnosisDate.Properties.CalendarTimeProperties.NullValuePrompt")
        Me.dtFinalDiagnosisDate.Properties.Mask.EditMask = resources.GetString("dtFinalDiagnosisDate.Properties.Mask.EditMask")
        Me.dtFinalDiagnosisDate.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtFinalDiagnosisDate.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtFinalDiagnosisDate.Properties.Mask.MaskType = CType(resources.GetObject("dtFinalDiagnosisDate.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtFinalDiagnosisDate.Properties.Mask.SaveLiteral = CType(resources.GetObject("dtFinalDiagnosisDate.Properties.Mask.SaveLiteral"), Boolean)
        Me.dtFinalDiagnosisDate.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtFinalDiagnosisDate.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtFinalDiagnosisDate.Properties.NullValuePrompt = resources.GetString("dtFinalDiagnosisDate.Properties.NullValuePrompt")
        Me.dtFinalDiagnosisDate.Tag = "{R}"
        '
        'lblDateOfDeath
        '
        resources.ApplyResources(Me.lblDateOfDeath, "lblDateOfDeath")
        Me.lblDateOfDeath.Name = "lblDateOfDeath"
        '
        'cbOutbreakExists
        '
        resources.ApplyResources(Me.cbOutbreakExists, "cbOutbreakExists")
        Me.cbOutbreakExists.Name = "cbOutbreakExists"
        Me.cbOutbreakExists.Properties.Appearance.Options.UseFont = True
        Me.cbOutbreakExists.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbOutbreakExists.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbOutbreakExists.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbOutbreakExists.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbOutbreakExists.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbOutbreakExists.Properties.AutoHeight = CType(resources.GetObject("cbOutbreakExists.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject53.Options.UseFont = True
        Me.cbOutbreakExists.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbOutbreakExists.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbOutbreakExists.Properties.Buttons1"), CType(resources.GetObject("cbOutbreakExists.Properties.Buttons2"), Integer), CType(resources.GetObject("cbOutbreakExists.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbOutbreakExists.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbOutbreakExists.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbOutbreakExists.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbOutbreakExists.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject53, resources.GetString("cbOutbreakExists.Properties.Buttons8"), CType(resources.GetObject("cbOutbreakExists.Properties.Buttons9"), Object), CType(resources.GetObject("cbOutbreakExists.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbOutbreakExists.Properties.Buttons11"), Boolean))})
        Me.cbOutbreakExists.Properties.NullText = resources.GetString("cbOutbreakExists.Properties.NullText")
        Me.cbOutbreakExists.Properties.NullValuePrompt = resources.GetString("cbOutbreakExists.Properties.NullValuePrompt")
        '
        'lueFinalCaseClassification
        '
        resources.ApplyResources(Me.lueFinalCaseClassification, "lueFinalCaseClassification")
        Me.lueFinalCaseClassification.Name = "lueFinalCaseClassification"
        Me.lueFinalCaseClassification.Properties.Appearance.Options.UseFont = True
        Me.lueFinalCaseClassification.Properties.AppearanceDisabled.Options.UseFont = True
        Me.lueFinalCaseClassification.Properties.AppearanceDropDown.Options.UseFont = True
        Me.lueFinalCaseClassification.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.lueFinalCaseClassification.Properties.AppearanceFocused.Options.UseFont = True
        Me.lueFinalCaseClassification.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.lueFinalCaseClassification.Properties.AutoHeight = CType(resources.GetObject("lueFinalCaseClassification.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject54.Options.UseFont = True
        Me.lueFinalCaseClassification.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("lueFinalCaseClassification.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("lueFinalCaseClassification.Properties.Buttons1"), CType(resources.GetObject("lueFinalCaseClassification.Properties.Buttons2"), Integer), CType(resources.GetObject("lueFinalCaseClassification.Properties.Buttons3"), Boolean), CType(resources.GetObject("lueFinalCaseClassification.Properties.Buttons4"), Boolean), CType(resources.GetObject("lueFinalCaseClassification.Properties.Buttons5"), Boolean), CType(resources.GetObject("lueFinalCaseClassification.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("lueFinalCaseClassification.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject54, resources.GetString("lueFinalCaseClassification.Properties.Buttons8"), CType(resources.GetObject("lueFinalCaseClassification.Properties.Buttons9"), Object), CType(resources.GetObject("lueFinalCaseClassification.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("lueFinalCaseClassification.Properties.Buttons11"), Boolean))})
        Me.lueFinalCaseClassification.Properties.NullText = resources.GetString("lueFinalCaseClassification.Properties.NullText")
        Me.lueFinalCaseClassification.Properties.NullValuePrompt = resources.GetString("lueFinalCaseClassification.Properties.NullValuePrompt")
        '
        'lblFinalCaseClassification
        '
        resources.ApplyResources(Me.lblFinalCaseClassification, "lblFinalCaseClassification")
        Me.lblFinalCaseClassification.Name = "lblFinalCaseClassification"
        '
        'lblOutbreakExists
        '
        resources.ApplyResources(Me.lblOutbreakExists, "lblOutbreakExists")
        Me.lblOutbreakExists.Name = "lblOutbreakExists"
        '
        'cbOutcome
        '
        resources.ApplyResources(Me.cbOutcome, "cbOutcome")
        Me.cbOutcome.Name = "cbOutcome"
        Me.cbOutcome.Properties.Appearance.Options.UseFont = True
        Me.cbOutcome.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbOutcome.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbOutcome.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbOutcome.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbOutcome.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbOutcome.Properties.AutoHeight = CType(resources.GetObject("cbOutcome.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject55.Options.UseFont = True
        Me.cbOutcome.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbOutcome.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbOutcome.Properties.Buttons1"), CType(resources.GetObject("cbOutcome.Properties.Buttons2"), Integer), CType(resources.GetObject("cbOutcome.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbOutcome.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbOutcome.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbOutcome.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbOutcome.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject55, resources.GetString("cbOutcome.Properties.Buttons8"), CType(resources.GetObject("cbOutcome.Properties.Buttons9"), Object), CType(resources.GetObject("cbOutcome.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbOutcome.Properties.Buttons11"), Boolean))})
        Me.cbOutcome.Properties.NullText = resources.GetString("cbOutcome.Properties.NullText")
        Me.cbOutcome.Properties.NullValuePrompt = resources.GetString("cbOutcome.Properties.NullValuePrompt")
        '
        'lblOutcome
        '
        resources.ApplyResources(Me.lblOutcome, "lblOutcome")
        Me.lblOutcome.Name = "lblOutcome"
        '
        'lblFinalDiagnosis
        '
        resources.ApplyResources(Me.lblFinalDiagnosis, "lblFinalDiagnosis")
        Me.lblFinalDiagnosis.Name = "lblFinalDiagnosis"
        '
        'txtFinalDiagnosis
        '
        resources.ApplyResources(Me.txtFinalDiagnosis, "txtFinalDiagnosis")
        Me.txtFinalDiagnosis.Name = "txtFinalDiagnosis"
        Me.txtFinalDiagnosis.Properties.Appearance.Options.UseFont = True
        Me.txtFinalDiagnosis.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtFinalDiagnosis.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtFinalDiagnosis.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtFinalDiagnosis.Properties.AutoHeight = CType(resources.GetObject("txtFinalDiagnosis.Properties.AutoHeight"), Boolean)
        Me.txtFinalDiagnosis.Properties.Mask.EditMask = resources.GetString("txtFinalDiagnosis.Properties.Mask.EditMask")
        Me.txtFinalDiagnosis.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtFinalDiagnosis.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtFinalDiagnosis.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtFinalDiagnosis.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtFinalDiagnosis.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtFinalDiagnosis.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtFinalDiagnosis.Properties.NullValuePrompt = resources.GetString("txtFinalDiagnosis.Properties.NullValuePrompt")
        Me.txtFinalDiagnosis.Tag = "{R}"
        '
        'lblBasisOfDiagnosis
        '
        resources.ApplyResources(Me.lblBasisOfDiagnosis, "lblBasisOfDiagnosis")
        Me.lblBasisOfDiagnosis.Name = "lblBasisOfDiagnosis"
        '
        'lblEpidemiologistsName
        '
        resources.ApplyResources(Me.lblEpidemiologistsName, "lblEpidemiologistsName")
        Me.lblEpidemiologistsName.Name = "lblEpidemiologistsName"
        '
        'lblSummaryComments
        '
        resources.ApplyResources(Me.lblSummaryComments, "lblSummaryComments")
        Me.lblSummaryComments.Name = "lblSummaryComments"
        '
        'cbOutbreakID
        '
        resources.ApplyResources(Me.cbOutbreakID, "cbOutbreakID")
        Me.cbOutbreakID.Name = "cbOutbreakID"
        Me.cbOutbreakID.Properties.Appearance.Options.UseFont = True
        Me.cbOutbreakID.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbOutbreakID.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbOutbreakID.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbOutbreakID.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbOutbreakID.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbOutbreakID.Properties.AutoHeight = CType(resources.GetObject("cbOutbreakID.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject56.Options.UseFont = True
        SerializableAppearanceObject57.Options.UseFont = True
        SerializableAppearanceObject58.Options.UseFont = True
        Me.cbOutbreakID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbOutbreakID.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbOutbreakID.Properties.Buttons1"), CType(resources.GetObject("cbOutbreakID.Properties.Buttons2"), Integer), CType(resources.GetObject("cbOutbreakID.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbOutbreakID.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbOutbreakID.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbOutbreakID.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), Global.eidss.My.Resources.Resources.Browse5, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject56, resources.GetString("cbOutbreakID.Properties.Buttons7"), CType(resources.GetObject("cbOutbreakID.Properties.Buttons8"), Object), CType(resources.GetObject("cbOutbreakID.Properties.Buttons9"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbOutbreakID.Properties.Buttons10"), Boolean)), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbOutbreakID.Properties.Buttons11"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbOutbreakID.Properties.Buttons12"), CType(resources.GetObject("cbOutbreakID.Properties.Buttons13"), Integer), CType(resources.GetObject("cbOutbreakID.Properties.Buttons14"), Boolean), CType(resources.GetObject("cbOutbreakID.Properties.Buttons15"), Boolean), CType(resources.GetObject("cbOutbreakID.Properties.Buttons16"), Boolean), CType(resources.GetObject("cbOutbreakID.Properties.Buttons17"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbOutbreakID.Properties.Buttons18"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject57, resources.GetString("cbOutbreakID.Properties.Buttons19"), CType(resources.GetObject("cbOutbreakID.Properties.Buttons20"), Object), CType(resources.GetObject("cbOutbreakID.Properties.Buttons21"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbOutbreakID.Properties.Buttons22"), Boolean)), New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbOutbreakID.Properties.Buttons23"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbOutbreakID.Properties.Buttons24"), CType(resources.GetObject("cbOutbreakID.Properties.Buttons25"), Integer), CType(resources.GetObject("cbOutbreakID.Properties.Buttons26"), Boolean), CType(resources.GetObject("cbOutbreakID.Properties.Buttons27"), Boolean), CType(resources.GetObject("cbOutbreakID.Properties.Buttons28"), Boolean), CType(resources.GetObject("cbOutbreakID.Properties.Buttons29"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbOutbreakID.Properties.Buttons30"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject58, resources.GetString("cbOutbreakID.Properties.Buttons31"), CType(resources.GetObject("cbOutbreakID.Properties.Buttons32"), Object), CType(resources.GetObject("cbOutbreakID.Properties.Buttons33"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbOutbreakID.Properties.Buttons34"), Boolean))})
        Me.cbOutbreakID.Properties.NullText = resources.GetString("cbOutbreakID.Properties.NullText")
        Me.cbOutbreakID.Properties.NullValuePrompt = resources.GetString("cbOutbreakID.Properties.NullValuePrompt")
        Me.cbOutbreakID.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never
        '
        'lblOutbreakID
        '
        resources.ApplyResources(Me.lblOutbreakID, "lblOutbreakID")
        Me.lblOutbreakID.Name = "lblOutbreakID"
        '
        'lblDateOfDischarge
        '
        resources.ApplyResources(Me.lblDateOfDischarge, "lblDateOfDischarge")
        Me.lblDateOfDischarge.Name = "lblDateOfDischarge"
        '
        'lblDischargeDate
        '
        resources.ApplyResources(Me.lblDischargeDate, "lblDischargeDate")
        Me.lblDischargeDate.Name = "lblDischargeDate"
        '
        'meSummaryComments
        '
        resources.ApplyResources(Me.meSummaryComments, "meSummaryComments")
        Me.meSummaryComments.Name = "meSummaryComments"
        Me.meSummaryComments.Properties.Appearance.Options.UseFont = True
        Me.meSummaryComments.Properties.AppearanceDisabled.Options.UseFont = True
        Me.meSummaryComments.Properties.AppearanceFocused.Options.UseFont = True
        Me.meSummaryComments.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.meSummaryComments.Properties.MaxLength = 1000
        Me.meSummaryComments.Properties.NullValuePrompt = resources.GetString("meSummaryComments.Properties.NullValuePrompt")
        '
        'deDateOfDischarge
        '
        resources.ApplyResources(Me.deDateOfDischarge, "deDateOfDischarge")
        Me.deDateOfDischarge.Name = "deDateOfDischarge"
        Me.deDateOfDischarge.Properties.Appearance.Options.UseFont = True
        Me.deDateOfDischarge.Properties.AppearanceDisabled.Options.UseFont = True
        Me.deDateOfDischarge.Properties.AppearanceDropDown.Options.UseFont = True
        Me.deDateOfDischarge.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.deDateOfDischarge.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = True
        Me.deDateOfDischarge.Properties.AppearanceDropDownHighlight.Options.UseFont = True
        Me.deDateOfDischarge.Properties.AppearanceFocused.Options.UseFont = True
        Me.deDateOfDischarge.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.deDateOfDischarge.Properties.AppearanceWeekNumber.Options.UseFont = True
        Me.deDateOfDischarge.Properties.AutoHeight = CType(resources.GetObject("deDateOfDischarge.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject59.Options.UseFont = True
        Me.deDateOfDischarge.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("deDateOfDischarge.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("deDateOfDischarge.Properties.Buttons1"), CType(resources.GetObject("deDateOfDischarge.Properties.Buttons2"), Integer), CType(resources.GetObject("deDateOfDischarge.Properties.Buttons3"), Boolean), CType(resources.GetObject("deDateOfDischarge.Properties.Buttons4"), Boolean), CType(resources.GetObject("deDateOfDischarge.Properties.Buttons5"), Boolean), CType(resources.GetObject("deDateOfDischarge.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("deDateOfDischarge.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject59, resources.GetString("deDateOfDischarge.Properties.Buttons8"), CType(resources.GetObject("deDateOfDischarge.Properties.Buttons9"), Object), CType(resources.GetObject("deDateOfDischarge.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("deDateOfDischarge.Properties.Buttons11"), Boolean))})
        Me.deDateOfDischarge.Properties.CalendarTimeProperties.Appearance.Options.UseFont = True
        Me.deDateOfDischarge.Properties.CalendarTimeProperties.AppearanceDisabled.Options.UseFont = True
        Me.deDateOfDischarge.Properties.CalendarTimeProperties.AppearanceFocused.Options.UseFont = True
        Me.deDateOfDischarge.Properties.CalendarTimeProperties.AppearanceReadOnly.Options.UseFont = True
        Me.deDateOfDischarge.Properties.CalendarTimeProperties.AutoHeight = CType(resources.GetObject("deDateOfDischarge.Properties.CalendarTimeProperties.AutoHeight"), Boolean)
        SerializableAppearanceObject60.Options.UseFont = True
        Me.deDateOfDischarge.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("deDateOfDischarge.Properties.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("deDateOfDischarge.Properties.CalendarTimeProperties.Buttons1"), CType(resources.GetObject("deDateOfDischarge.Properties.CalendarTimeProperties.Buttons2"), Integer), CType(resources.GetObject("deDateOfDischarge.Properties.CalendarTimeProperties.Buttons3"), Boolean), CType(resources.GetObject("deDateOfDischarge.Properties.CalendarTimeProperties.Buttons4"), Boolean), CType(resources.GetObject("deDateOfDischarge.Properties.CalendarTimeProperties.Buttons5"), Boolean), CType(resources.GetObject("deDateOfDischarge.Properties.CalendarTimeProperties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("deDateOfDischarge.Properties.CalendarTimeProperties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject60, resources.GetString("deDateOfDischarge.Properties.CalendarTimeProperties.Buttons8"), CType(resources.GetObject("deDateOfDischarge.Properties.CalendarTimeProperties.Buttons9"), Object), CType(resources.GetObject("deDateOfDischarge.Properties.CalendarTimeProperties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("deDateOfDischarge.Properties.CalendarTimeProperties.Buttons11"), Boolean))})
        Me.deDateOfDischarge.Properties.CalendarTimeProperties.Mask.EditMask = resources.GetString("deDateOfDischarge.Properties.CalendarTimeProperties.Mask.EditMask")
        Me.deDateOfDischarge.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("deDateOfDischarge.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.deDateOfDischarge.Properties.CalendarTimeProperties.Mask.MaskType = CType(resources.GetObject("deDateOfDischarge.Properties.CalendarTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.deDateOfDischarge.Properties.CalendarTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("deDateOfDischarge.Properties.CalendarTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.deDateOfDischarge.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("deDateOfDischarge.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.deDateOfDischarge.Properties.CalendarTimeProperties.NullValuePrompt = resources.GetString("deDateOfDischarge.Properties.CalendarTimeProperties.NullValuePrompt")
        Me.deDateOfDischarge.Properties.Mask.EditMask = resources.GetString("deDateOfDischarge.Properties.Mask.EditMask")
        Me.deDateOfDischarge.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("deDateOfDischarge.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.deDateOfDischarge.Properties.Mask.MaskType = CType(resources.GetObject("deDateOfDischarge.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.deDateOfDischarge.Properties.Mask.SaveLiteral = CType(resources.GetObject("deDateOfDischarge.Properties.Mask.SaveLiteral"), Boolean)
        Me.deDateOfDischarge.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("deDateOfDischarge.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.deDateOfDischarge.Properties.NullValuePrompt = resources.GetString("deDateOfDischarge.Properties.NullValuePrompt")
        '
        'txtDischargeDate
        '
        resources.ApplyResources(Me.txtDischargeDate, "txtDischargeDate")
        Me.txtDischargeDate.Name = "txtDischargeDate"
        Me.txtDischargeDate.Properties.Appearance.Options.UseFont = True
        Me.txtDischargeDate.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtDischargeDate.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtDischargeDate.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtDischargeDate.Properties.AutoHeight = CType(resources.GetObject("txtDischargeDate.Properties.AutoHeight"), Boolean)
        Me.txtDischargeDate.Properties.Mask.EditMask = resources.GetString("txtDischargeDate.Properties.Mask.EditMask")
        Me.txtDischargeDate.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtDischargeDate.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtDischargeDate.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtDischargeDate.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtDischargeDate.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtDischargeDate.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtDischargeDate.Properties.NullValuePrompt = resources.GetString("txtDischargeDate.Properties.NullValuePrompt")
        Me.txtDischargeDate.Tag = "{R}"
        '
        'tpTests
        '
        Me.tpTests.Appearance.Header.Options.UseFont = True
        Me.tpTests.Appearance.HeaderActive.Options.UseFont = True
        Me.tpTests.Appearance.HeaderDisabled.Options.UseFont = True
        Me.tpTests.Appearance.HeaderHotTracked.Options.UseFont = True
        Me.tpTests.Appearance.PageClient.Options.UseFont = True
        Me.tpTests.Controls.Add(Me.lbTestsConducted)
        Me.tpTests.Controls.Add(Me.cbTestsConducted)
        Me.tpTests.Controls.Add(Me.CaseTestsPanel1)
        Me.tpTests.Name = "tpTests"
        resources.ApplyResources(Me.tpTests, "tpTests")
        '
        'lbTestsConducted
        '
        resources.ApplyResources(Me.lbTestsConducted, "lbTestsConducted")
        Me.lbTestsConducted.Name = "lbTestsConducted"
        '
        'cbTestsConducted
        '
        resources.ApplyResources(Me.cbTestsConducted, "cbTestsConducted")
        Me.cbTestsConducted.Name = "cbTestsConducted"
        Me.cbTestsConducted.Properties.Appearance.Options.UseFont = True
        Me.cbTestsConducted.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbTestsConducted.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbTestsConducted.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbTestsConducted.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbTestsConducted.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbTestsConducted.Properties.AutoHeight = CType(resources.GetObject("cbTestsConducted.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject61.Options.UseFont = True
        Me.cbTestsConducted.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbTestsConducted.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbTestsConducted.Properties.Buttons1"), CType(resources.GetObject("cbTestsConducted.Properties.Buttons2"), Integer), CType(resources.GetObject("cbTestsConducted.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbTestsConducted.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbTestsConducted.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbTestsConducted.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbTestsConducted.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject61, resources.GetString("cbTestsConducted.Properties.Buttons8"), CType(resources.GetObject("cbTestsConducted.Properties.Buttons9"), Object), CType(resources.GetObject("cbTestsConducted.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbTestsConducted.Properties.Buttons11"), Boolean))})
        Me.cbTestsConducted.Properties.NullValuePrompt = resources.GetString("cbTestsConducted.Properties.NullValuePrompt")
        '
        'CaseTestsPanel1
        '
        Me.CaseTestsPanel1.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.CaseTestsPanel1, "CaseTestsPanel1")
        Me.CaseTestsPanel1.DateValidator = Nothing
        Me.CaseTestsPanel1.FormID = Nothing
        Me.CaseTestsPanel1.HelpTopicID = Nothing
        Me.CaseTestsPanel1.KeyFieldName = Nothing
        Me.CaseTestsPanel1.MultiSelect = False
        Me.CaseTestsPanel1.Name = "CaseTestsPanel1"
        Me.CaseTestsPanel1.ObjectName = Nothing
        Me.CaseTestsPanel1.TableName = Nothing
        '
        'RepositoryItemDateEdit2
        '
        Me.RepositoryItemDateEdit2.Appearance.Options.UseFont = True
        Me.RepositoryItemDateEdit2.AppearanceDisabled.Options.UseFont = True
        Me.RepositoryItemDateEdit2.AppearanceDropDown.Options.UseFont = True
        Me.RepositoryItemDateEdit2.AppearanceDropDownHeader.Options.UseFont = True
        Me.RepositoryItemDateEdit2.AppearanceDropDownHeaderHighlight.Options.UseFont = True
        Me.RepositoryItemDateEdit2.AppearanceDropDownHighlight.Options.UseFont = True
        Me.RepositoryItemDateEdit2.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemDateEdit2.AppearanceReadOnly.Options.UseFont = True
        Me.RepositoryItemDateEdit2.AppearanceWeekNumber.Options.UseFont = True
        resources.ApplyResources(Me.RepositoryItemDateEdit2, "RepositoryItemDateEdit2")
        SerializableAppearanceObject62.Options.UseFont = True
        Me.RepositoryItemDateEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryItemDateEdit2.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("RepositoryItemDateEdit2.Buttons1"), CType(resources.GetObject("RepositoryItemDateEdit2.Buttons2"), Integer), CType(resources.GetObject("RepositoryItemDateEdit2.Buttons3"), Boolean), CType(resources.GetObject("RepositoryItemDateEdit2.Buttons4"), Boolean), CType(resources.GetObject("RepositoryItemDateEdit2.Buttons5"), Boolean), CType(resources.GetObject("RepositoryItemDateEdit2.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("RepositoryItemDateEdit2.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject62, resources.GetString("RepositoryItemDateEdit2.Buttons8"), CType(resources.GetObject("RepositoryItemDateEdit2.Buttons9"), Object), CType(resources.GetObject("RepositoryItemDateEdit2.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("RepositoryItemDateEdit2.Buttons11"), Boolean))})
        Me.RepositoryItemDateEdit2.CalendarTimeProperties.Appearance.Options.UseFont = True
        Me.RepositoryItemDateEdit2.CalendarTimeProperties.AppearanceDisabled.Options.UseFont = True
        Me.RepositoryItemDateEdit2.CalendarTimeProperties.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemDateEdit2.CalendarTimeProperties.AppearanceReadOnly.Options.UseFont = True
        Me.RepositoryItemDateEdit2.CalendarTimeProperties.AutoHeight = CType(resources.GetObject("RepositoryItemDateEdit2.CalendarTimeProperties.AutoHeight"), Boolean)
        SerializableAppearanceObject63.Options.UseFont = True
        Me.RepositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryItemDateEdit2.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("RepositoryItemDateEdit2.CalendarTimeProperties.Buttons1"), CType(resources.GetObject("RepositoryItemDateEdit2.CalendarTimeProperties.Buttons2"), Integer), CType(resources.GetObject("RepositoryItemDateEdit2.CalendarTimeProperties.Buttons3"), Boolean), CType(resources.GetObject("RepositoryItemDateEdit2.CalendarTimeProperties.Buttons4"), Boolean), CType(resources.GetObject("RepositoryItemDateEdit2.CalendarTimeProperties.Buttons5"), Boolean), CType(resources.GetObject("RepositoryItemDateEdit2.CalendarTimeProperties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("RepositoryItemDateEdit2.CalendarTimeProperties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject63, resources.GetString("RepositoryItemDateEdit2.CalendarTimeProperties.Buttons8"), CType(resources.GetObject("RepositoryItemDateEdit2.CalendarTimeProperties.Buttons9"), Object), CType(resources.GetObject("RepositoryItemDateEdit2.CalendarTimeProperties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("RepositoryItemDateEdit2.CalendarTimeProperties.Buttons11"), Boolean))})
        Me.RepositoryItemDateEdit2.CalendarTimeProperties.Mask.EditMask = resources.GetString("RepositoryItemDateEdit2.CalendarTimeProperties.Mask.EditMask")
        Me.RepositoryItemDateEdit2.CalendarTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("RepositoryItemDateEdit2.CalendarTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.RepositoryItemDateEdit2.CalendarTimeProperties.Mask.MaskType = CType(resources.GetObject("RepositoryItemDateEdit2.CalendarTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.RepositoryItemDateEdit2.CalendarTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("RepositoryItemDateEdit2.CalendarTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.RepositoryItemDateEdit2.CalendarTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("RepositoryItemDateEdit2.CalendarTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.RepositoryItemDateEdit2.CalendarTimeProperties.NullValuePrompt = resources.GetString("RepositoryItemDateEdit2.CalendarTimeProperties.NullValuePrompt")
        Me.RepositoryItemDateEdit2.Mask.EditMask = resources.GetString("RepositoryItemDateEdit2.Mask.EditMask")
        Me.RepositoryItemDateEdit2.Mask.IgnoreMaskBlank = CType(resources.GetObject("RepositoryItemDateEdit2.Mask.IgnoreMaskBlank"), Boolean)
        Me.RepositoryItemDateEdit2.Mask.MaskType = CType(resources.GetObject("RepositoryItemDateEdit2.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.RepositoryItemDateEdit2.Mask.SaveLiteral = CType(resources.GetObject("RepositoryItemDateEdit2.Mask.SaveLiteral"), Boolean)
        Me.RepositoryItemDateEdit2.Mask.ShowPlaceHolders = CType(resources.GetObject("RepositoryItemDateEdit2.Mask.ShowPlaceHolders"), Boolean)
        Me.RepositoryItemDateEdit2.Name = "RepositoryItemDateEdit2"
        Me.RepositoryItemDateEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'redDateDiagDate
        '
        Me.redDateDiagDate.Appearance.Options.UseFont = True
        Me.redDateDiagDate.AppearanceDisabled.Options.UseFont = True
        Me.redDateDiagDate.AppearanceDropDown.Options.UseFont = True
        Me.redDateDiagDate.AppearanceDropDownHeader.Options.UseFont = True
        Me.redDateDiagDate.AppearanceDropDownHeaderHighlight.Options.UseFont = True
        Me.redDateDiagDate.AppearanceDropDownHighlight.Options.UseFont = True
        Me.redDateDiagDate.AppearanceFocused.Options.UseFont = True
        Me.redDateDiagDate.AppearanceReadOnly.Options.UseFont = True
        Me.redDateDiagDate.AppearanceWeekNumber.Options.UseFont = True
        resources.ApplyResources(Me.redDateDiagDate, "redDateDiagDate")
        SerializableAppearanceObject64.Options.UseFont = True
        Me.redDateDiagDate.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("redDateDiagDate.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("redDateDiagDate.Buttons1"), CType(resources.GetObject("redDateDiagDate.Buttons2"), Integer), CType(resources.GetObject("redDateDiagDate.Buttons3"), Boolean), CType(resources.GetObject("redDateDiagDate.Buttons4"), Boolean), CType(resources.GetObject("redDateDiagDate.Buttons5"), Boolean), CType(resources.GetObject("redDateDiagDate.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("redDateDiagDate.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject64, resources.GetString("redDateDiagDate.Buttons8"), CType(resources.GetObject("redDateDiagDate.Buttons9"), Object), CType(resources.GetObject("redDateDiagDate.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("redDateDiagDate.Buttons11"), Boolean))})
        Me.redDateDiagDate.CalendarTimeProperties.Appearance.Options.UseFont = True
        Me.redDateDiagDate.CalendarTimeProperties.AppearanceDisabled.Options.UseFont = True
        Me.redDateDiagDate.CalendarTimeProperties.AppearanceFocused.Options.UseFont = True
        Me.redDateDiagDate.CalendarTimeProperties.AppearanceReadOnly.Options.UseFont = True
        Me.redDateDiagDate.CalendarTimeProperties.AutoHeight = CType(resources.GetObject("redDateDiagDate.CalendarTimeProperties.AutoHeight"), Boolean)
        SerializableAppearanceObject65.Options.UseFont = True
        Me.redDateDiagDate.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("redDateDiagDate.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("redDateDiagDate.CalendarTimeProperties.Buttons1"), CType(resources.GetObject("redDateDiagDate.CalendarTimeProperties.Buttons2"), Integer), CType(resources.GetObject("redDateDiagDate.CalendarTimeProperties.Buttons3"), Boolean), CType(resources.GetObject("redDateDiagDate.CalendarTimeProperties.Buttons4"), Boolean), CType(resources.GetObject("redDateDiagDate.CalendarTimeProperties.Buttons5"), Boolean), CType(resources.GetObject("redDateDiagDate.CalendarTimeProperties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("redDateDiagDate.CalendarTimeProperties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject65, resources.GetString("redDateDiagDate.CalendarTimeProperties.Buttons8"), CType(resources.GetObject("redDateDiagDate.CalendarTimeProperties.Buttons9"), Object), CType(resources.GetObject("redDateDiagDate.CalendarTimeProperties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("redDateDiagDate.CalendarTimeProperties.Buttons11"), Boolean))})
        Me.redDateDiagDate.CalendarTimeProperties.Mask.EditMask = resources.GetString("redDateDiagDate.CalendarTimeProperties.Mask.EditMask")
        Me.redDateDiagDate.CalendarTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("redDateDiagDate.CalendarTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.redDateDiagDate.CalendarTimeProperties.Mask.MaskType = CType(resources.GetObject("redDateDiagDate.CalendarTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.redDateDiagDate.CalendarTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("redDateDiagDate.CalendarTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.redDateDiagDate.CalendarTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("redDateDiagDate.CalendarTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.redDateDiagDate.CalendarTimeProperties.NullValuePrompt = resources.GetString("redDateDiagDate.CalendarTimeProperties.NullValuePrompt")
        Me.redDateDiagDate.HideSelection = False
        Me.redDateDiagDate.Mask.EditMask = resources.GetString("redDateDiagDate.Mask.EditMask")
        Me.redDateDiagDate.Mask.IgnoreMaskBlank = CType(resources.GetObject("redDateDiagDate.Mask.IgnoreMaskBlank"), Boolean)
        Me.redDateDiagDate.Mask.MaskType = CType(resources.GetObject("redDateDiagDate.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.redDateDiagDate.Mask.SaveLiteral = CType(resources.GetObject("redDateDiagDate.Mask.SaveLiteral"), Boolean)
        Me.redDateDiagDate.Mask.ShowPlaceHolders = CType(resources.GetObject("redDateDiagDate.Mask.ShowPlaceHolders"), Boolean)
        Me.redDateDiagDate.Name = "redDateDiagDate"
        '
        'redLookupDiagType
        '
        Me.redLookupDiagType.Appearance.Options.UseFont = True
        Me.redLookupDiagType.AppearanceDisabled.Options.UseFont = True
        Me.redLookupDiagType.AppearanceDropDown.Options.UseFont = True
        Me.redLookupDiagType.AppearanceDropDownHeader.Options.UseFont = True
        Me.redLookupDiagType.AppearanceFocused.Options.UseFont = True
        Me.redLookupDiagType.AppearanceReadOnly.Options.UseFont = True
        resources.ApplyResources(Me.redLookupDiagType, "redLookupDiagType")
        SerializableAppearanceObject66.Options.UseFont = True
        Me.redLookupDiagType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("redLookupDiagType.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("redLookupDiagType.Buttons1"), CType(resources.GetObject("redLookupDiagType.Buttons2"), Integer), CType(resources.GetObject("redLookupDiagType.Buttons3"), Boolean), CType(resources.GetObject("redLookupDiagType.Buttons4"), Boolean), CType(resources.GetObject("redLookupDiagType.Buttons5"), Boolean), CType(resources.GetObject("redLookupDiagType.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("redLookupDiagType.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject66, resources.GetString("redLookupDiagType.Buttons8"), CType(resources.GetObject("redLookupDiagType.Buttons9"), Object), CType(resources.GetObject("redLookupDiagType.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("redLookupDiagType.Buttons11"), Boolean))})
        Me.redLookupDiagType.Name = "redLookupDiagType"
        '
        'redLookupDiseaseName
        '
        Me.redLookupDiseaseName.Appearance.Options.UseFont = True
        Me.redLookupDiseaseName.AppearanceDisabled.Options.UseFont = True
        Me.redLookupDiseaseName.AppearanceDropDown.Options.UseFont = True
        Me.redLookupDiseaseName.AppearanceDropDownHeader.Options.UseFont = True
        Me.redLookupDiseaseName.AppearanceFocused.Options.UseFont = True
        Me.redLookupDiseaseName.AppearanceReadOnly.Options.UseFont = True
        resources.ApplyResources(Me.redLookupDiseaseName, "redLookupDiseaseName")
        SerializableAppearanceObject67.Options.UseFont = True
        Me.redLookupDiseaseName.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("redLookupDiseaseName.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("redLookupDiseaseName.Buttons1"), CType(resources.GetObject("redLookupDiseaseName.Buttons2"), Integer), CType(resources.GetObject("redLookupDiseaseName.Buttons3"), Boolean), CType(resources.GetObject("redLookupDiseaseName.Buttons4"), Boolean), CType(resources.GetObject("redLookupDiseaseName.Buttons5"), Boolean), CType(resources.GetObject("redLookupDiseaseName.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("redLookupDiseaseName.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject67, resources.GetString("redLookupDiseaseName.Buttons8"), CType(resources.GetObject("redLookupDiseaseName.Buttons9"), Object), CType(resources.GetObject("redLookupDiseaseName.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("redLookupDiseaseName.Buttons11"), Boolean))})
        Me.redLookupDiseaseName.Name = "redLookupDiseaseName"
        '
        'redLookupBaseForDiag
        '
        Me.redLookupBaseForDiag.Appearance.Options.UseFont = True
        Me.redLookupBaseForDiag.AppearanceDisabled.Options.UseFont = True
        Me.redLookupBaseForDiag.AppearanceDropDown.Options.UseFont = True
        Me.redLookupBaseForDiag.AppearanceDropDownHeader.Options.UseFont = True
        Me.redLookupBaseForDiag.AppearanceFocused.Options.UseFont = True
        Me.redLookupBaseForDiag.AppearanceReadOnly.Options.UseFont = True
        resources.ApplyResources(Me.redLookupBaseForDiag, "redLookupBaseForDiag")
        SerializableAppearanceObject68.Options.UseFont = True
        Me.redLookupBaseForDiag.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("redLookupBaseForDiag.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("redLookupBaseForDiag.Buttons1"), CType(resources.GetObject("redLookupBaseForDiag.Buttons2"), Integer), CType(resources.GetObject("redLookupBaseForDiag.Buttons3"), Boolean), CType(resources.GetObject("redLookupBaseForDiag.Buttons4"), Boolean), CType(resources.GetObject("redLookupBaseForDiag.Buttons5"), Boolean), CType(resources.GetObject("redLookupBaseForDiag.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("redLookupBaseForDiag.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject68, resources.GetString("redLookupBaseForDiag.Buttons8"), CType(resources.GetObject("redLookupBaseForDiag.Buttons9"), Object), CType(resources.GetObject("redLookupBaseForDiag.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("redLookupBaseForDiag.Buttons11"), Boolean))})
        Me.redLookupBaseForDiag.Name = "redLookupBaseForDiag"
        '
        'redLookupDiagBy
        '
        Me.redLookupDiagBy.Appearance.Options.UseFont = True
        Me.redLookupDiagBy.AppearanceDisabled.Options.UseFont = True
        Me.redLookupDiagBy.AppearanceDropDown.Options.UseFont = True
        Me.redLookupDiagBy.AppearanceDropDownHeader.Options.UseFont = True
        Me.redLookupDiagBy.AppearanceFocused.Options.UseFont = True
        Me.redLookupDiagBy.AppearanceReadOnly.Options.UseFont = True
        resources.ApplyResources(Me.redLookupDiagBy, "redLookupDiagBy")
        SerializableAppearanceObject69.Options.UseFont = True
        Me.redLookupDiagBy.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("redLookupDiagBy.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("redLookupDiagBy.Buttons1"), CType(resources.GetObject("redLookupDiagBy.Buttons2"), Integer), CType(resources.GetObject("redLookupDiagBy.Buttons3"), Boolean), CType(resources.GetObject("redLookupDiagBy.Buttons4"), Boolean), CType(resources.GetObject("redLookupDiagBy.Buttons5"), Boolean), CType(resources.GetObject("redLookupDiagBy.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("redLookupDiagBy.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject69, resources.GetString("redLookupDiagBy.Buttons8"), CType(resources.GetObject("redLookupDiagBy.Buttons9"), Object), CType(resources.GetObject("redLookupDiagBy.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("redLookupDiagBy.Buttons11"), Boolean))})
        Me.redLookupDiagBy.Name = "redLookupDiagBy"
        Me.redLookupDiagBy.PopupWidth = 300
        '
        'dtStartDate
        '
        resources.ApplyResources(Me.dtStartDate, "dtStartDate")
        Me.dtStartDate.Name = "dtStartDate"
        Me.dtStartDate.Properties.Appearance.Options.UseFont = True
        Me.dtStartDate.Properties.AppearanceDisabled.Options.UseFont = True
        Me.dtStartDate.Properties.AppearanceDropDown.Options.UseFont = True
        Me.dtStartDate.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.dtStartDate.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = True
        Me.dtStartDate.Properties.AppearanceDropDownHighlight.Options.UseFont = True
        Me.dtStartDate.Properties.AppearanceFocused.Options.UseFont = True
        Me.dtStartDate.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.dtStartDate.Properties.AppearanceWeekNumber.Options.UseFont = True
        Me.dtStartDate.Properties.AutoHeight = CType(resources.GetObject("dtStartDate.Properties.AutoHeight"), Boolean)
        Me.dtStartDate.Properties.CalendarTimeProperties.Appearance.Options.UseFont = True
        Me.dtStartDate.Properties.CalendarTimeProperties.AppearanceDisabled.Options.UseFont = True
        Me.dtStartDate.Properties.CalendarTimeProperties.AppearanceFocused.Options.UseFont = True
        Me.dtStartDate.Properties.CalendarTimeProperties.AppearanceReadOnly.Options.UseFont = True
        Me.dtStartDate.Properties.CalendarTimeProperties.AutoHeight = CType(resources.GetObject("dtStartDate.Properties.CalendarTimeProperties.AutoHeight"), Boolean)
        SerializableAppearanceObject70.Options.UseFont = True
        Me.dtStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtStartDate.Properties.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("dtStartDate.Properties.CalendarTimeProperties.Buttons1"), CType(resources.GetObject("dtStartDate.Properties.CalendarTimeProperties.Buttons2"), Integer), CType(resources.GetObject("dtStartDate.Properties.CalendarTimeProperties.Buttons3"), Boolean), CType(resources.GetObject("dtStartDate.Properties.CalendarTimeProperties.Buttons4"), Boolean), CType(resources.GetObject("dtStartDate.Properties.CalendarTimeProperties.Buttons5"), Boolean), CType(resources.GetObject("dtStartDate.Properties.CalendarTimeProperties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("dtStartDate.Properties.CalendarTimeProperties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject70, resources.GetString("dtStartDate.Properties.CalendarTimeProperties.Buttons8"), CType(resources.GetObject("dtStartDate.Properties.CalendarTimeProperties.Buttons9"), Object), CType(resources.GetObject("dtStartDate.Properties.CalendarTimeProperties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("dtStartDate.Properties.CalendarTimeProperties.Buttons11"), Boolean))})
        Me.dtStartDate.Properties.CalendarTimeProperties.Mask.EditMask = resources.GetString("dtStartDate.Properties.CalendarTimeProperties.Mask.EditMask")
        Me.dtStartDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtStartDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtStartDate.Properties.CalendarTimeProperties.Mask.MaskType = CType(resources.GetObject("dtStartDate.Properties.CalendarTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtStartDate.Properties.CalendarTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("dtStartDate.Properties.CalendarTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.dtStartDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtStartDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtStartDate.Properties.CalendarTimeProperties.NullValuePrompt = resources.GetString("dtStartDate.Properties.CalendarTimeProperties.NullValuePrompt")
        Me.dtStartDate.Properties.DisplayFormat.FormatString = "g"
        Me.dtStartDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtStartDate.Properties.EditFormat.FormatString = "g"
        Me.dtStartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtStartDate.Properties.Mask.EditMask = resources.GetString("dtStartDate.Properties.Mask.EditMask")
        Me.dtStartDate.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtStartDate.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtStartDate.Properties.Mask.MaskType = CType(resources.GetObject("dtStartDate.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtStartDate.Properties.Mask.SaveLiteral = CType(resources.GetObject("dtStartDate.Properties.Mask.SaveLiteral"), Boolean)
        Me.dtStartDate.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtStartDate.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtStartDate.Properties.NullValuePrompt = resources.GetString("dtStartDate.Properties.NullValuePrompt")
        Me.dtStartDate.Properties.ValidateOnEnterKey = True
        Me.dtStartDate.TabStop = False
        Me.dtStartDate.Tag = "{AlwaysEditable}"
        '
        'bntPreviousCase
        '
        resources.ApplyResources(Me.bntPreviousCase, "bntPreviousCase")
        Me.bntPreviousCase.Appearance.Options.UseFont = True
        Me.bntPreviousCase.Name = "bntPreviousCase"
        Me.bntPreviousCase.Tag = "{AlwaysEditable}"
        '
        'bntNextCase
        '
        resources.ApplyResources(Me.bntNextCase, "bntNextCase")
        Me.bntNextCase.Appearance.Options.UseFont = True
        Me.bntNextCase.Name = "bntNextCase"
        Me.bntNextCase.Tag = "{AlwaysEditable}"
        '
        'btnLastCase
        '
        resources.ApplyResources(Me.btnLastCase, "btnLastCase")
        Me.btnLastCase.Appearance.Options.UseFont = True
        Me.btnLastCase.Name = "btnLastCase"
        Me.btnLastCase.Tag = "{AlwaysEditable}"
        '
        'btnFirstCase
        '
        resources.ApplyResources(Me.btnFirstCase, "btnFirstCase")
        Me.btnFirstCase.Appearance.Options.UseFont = True
        Me.btnFirstCase.Name = "btnFirstCase"
        Me.btnFirstCase.Tag = "{AlwaysEditable}"
        '
        'RepItem_slcResponseMeasureType
        '
        Me.RepItem_slcResponseMeasureType.Appearance.Options.UseFont = True
        Me.RepItem_slcResponseMeasureType.AppearanceDisabled.Options.UseFont = True
        Me.RepItem_slcResponseMeasureType.AppearanceDropDown.Options.UseFont = True
        Me.RepItem_slcResponseMeasureType.AppearanceDropDownHeader.Options.UseFont = True
        Me.RepItem_slcResponseMeasureType.AppearanceFocused.Options.UseFont = True
        Me.RepItem_slcResponseMeasureType.AppearanceReadOnly.Options.UseFont = True
        resources.ApplyResources(Me.RepItem_slcResponseMeasureType, "RepItem_slcResponseMeasureType")
        SerializableAppearanceObject71.Options.UseFont = True
        Me.RepItem_slcResponseMeasureType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepItem_slcResponseMeasureType.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("RepItem_slcResponseMeasureType.Buttons1"), CType(resources.GetObject("RepItem_slcResponseMeasureType.Buttons2"), Integer), CType(resources.GetObject("RepItem_slcResponseMeasureType.Buttons3"), Boolean), CType(resources.GetObject("RepItem_slcResponseMeasureType.Buttons4"), Boolean), CType(resources.GetObject("RepItem_slcResponseMeasureType.Buttons5"), Boolean), CType(resources.GetObject("RepItem_slcResponseMeasureType.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("RepItem_slcResponseMeasureType.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject71, resources.GetString("RepItem_slcResponseMeasureType.Buttons8"), CType(resources.GetObject("RepItem_slcResponseMeasureType.Buttons9"), Object), CType(resources.GetObject("RepItem_slcResponseMeasureType.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("RepItem_slcResponseMeasureType.Buttons11"), Boolean))})
        Me.RepItem_slcResponseMeasureType.Name = "RepItem_slcResponseMeasureType"
        '
        'RepItem_slcResult
        '
        Me.RepItem_slcResult.Appearance.Options.UseFont = True
        Me.RepItem_slcResult.AppearanceDisabled.Options.UseFont = True
        Me.RepItem_slcResult.AppearanceDropDown.Options.UseFont = True
        Me.RepItem_slcResult.AppearanceDropDownHeader.Options.UseFont = True
        Me.RepItem_slcResult.AppearanceFocused.Options.UseFont = True
        Me.RepItem_slcResult.AppearanceReadOnly.Options.UseFont = True
        resources.ApplyResources(Me.RepItem_slcResult, "RepItem_slcResult")
        SerializableAppearanceObject72.Options.UseFont = True
        Me.RepItem_slcResult.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepItem_slcResult.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("RepItem_slcResult.Buttons1"), CType(resources.GetObject("RepItem_slcResult.Buttons2"), Integer), CType(resources.GetObject("RepItem_slcResult.Buttons3"), Boolean), CType(resources.GetObject("RepItem_slcResult.Buttons4"), Boolean), CType(resources.GetObject("RepItem_slcResult.Buttons5"), Boolean), CType(resources.GetObject("RepItem_slcResult.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("RepItem_slcResult.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject72, resources.GetString("RepItem_slcResult.Buttons8"), CType(resources.GetObject("RepItem_slcResult.Buttons9"), Object), CType(resources.GetObject("RepItem_slcResult.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("RepItem_slcResult.Buttons11"), Boolean))})
        Me.RepItem_slcResult.Name = "RepItem_slcResult"
        '
        'RepItem_dtpMeasureDate
        '
        Me.RepItem_dtpMeasureDate.Appearance.Options.UseFont = True
        Me.RepItem_dtpMeasureDate.AppearanceDisabled.Options.UseFont = True
        Me.RepItem_dtpMeasureDate.AppearanceDropDown.Options.UseFont = True
        Me.RepItem_dtpMeasureDate.AppearanceDropDownHeader.Options.UseFont = True
        Me.RepItem_dtpMeasureDate.AppearanceDropDownHeaderHighlight.Options.UseFont = True
        Me.RepItem_dtpMeasureDate.AppearanceDropDownHighlight.Options.UseFont = True
        Me.RepItem_dtpMeasureDate.AppearanceFocused.Options.UseFont = True
        Me.RepItem_dtpMeasureDate.AppearanceReadOnly.Options.UseFont = True
        Me.RepItem_dtpMeasureDate.AppearanceWeekNumber.Options.UseFont = True
        resources.ApplyResources(Me.RepItem_dtpMeasureDate, "RepItem_dtpMeasureDate")
        SerializableAppearanceObject73.Options.UseFont = True
        Me.RepItem_dtpMeasureDate.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepItem_dtpMeasureDate.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("RepItem_dtpMeasureDate.Buttons1"), CType(resources.GetObject("RepItem_dtpMeasureDate.Buttons2"), Integer), CType(resources.GetObject("RepItem_dtpMeasureDate.Buttons3"), Boolean), CType(resources.GetObject("RepItem_dtpMeasureDate.Buttons4"), Boolean), CType(resources.GetObject("RepItem_dtpMeasureDate.Buttons5"), Boolean), CType(resources.GetObject("RepItem_dtpMeasureDate.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("RepItem_dtpMeasureDate.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject73, resources.GetString("RepItem_dtpMeasureDate.Buttons8"), CType(resources.GetObject("RepItem_dtpMeasureDate.Buttons9"), Object), CType(resources.GetObject("RepItem_dtpMeasureDate.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("RepItem_dtpMeasureDate.Buttons11"), Boolean))})
        Me.RepItem_dtpMeasureDate.CalendarTimeProperties.Appearance.Options.UseFont = True
        Me.RepItem_dtpMeasureDate.CalendarTimeProperties.AppearanceDisabled.Options.UseFont = True
        Me.RepItem_dtpMeasureDate.CalendarTimeProperties.AppearanceFocused.Options.UseFont = True
        Me.RepItem_dtpMeasureDate.CalendarTimeProperties.AppearanceReadOnly.Options.UseFont = True
        Me.RepItem_dtpMeasureDate.CalendarTimeProperties.AutoHeight = CType(resources.GetObject("RepItem_dtpMeasureDate.CalendarTimeProperties.AutoHeight"), Boolean)
        SerializableAppearanceObject74.Options.UseFont = True
        Me.RepItem_dtpMeasureDate.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepItem_dtpMeasureDate.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("RepItem_dtpMeasureDate.CalendarTimeProperties.Buttons1"), CType(resources.GetObject("RepItem_dtpMeasureDate.CalendarTimeProperties.Buttons2"), Integer), CType(resources.GetObject("RepItem_dtpMeasureDate.CalendarTimeProperties.Buttons3"), Boolean), CType(resources.GetObject("RepItem_dtpMeasureDate.CalendarTimeProperties.Buttons4"), Boolean), CType(resources.GetObject("RepItem_dtpMeasureDate.CalendarTimeProperties.Buttons5"), Boolean), CType(resources.GetObject("RepItem_dtpMeasureDate.CalendarTimeProperties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("RepItem_dtpMeasureDate.CalendarTimeProperties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject74, resources.GetString("RepItem_dtpMeasureDate.CalendarTimeProperties.Buttons8"), CType(resources.GetObject("RepItem_dtpMeasureDate.CalendarTimeProperties.Buttons9"), Object), CType(resources.GetObject("RepItem_dtpMeasureDate.CalendarTimeProperties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("RepItem_dtpMeasureDate.CalendarTimeProperties.Buttons11"), Boolean))})
        Me.RepItem_dtpMeasureDate.CalendarTimeProperties.Mask.EditMask = resources.GetString("RepItem_dtpMeasureDate.CalendarTimeProperties.Mask.EditMask")
        Me.RepItem_dtpMeasureDate.CalendarTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("RepItem_dtpMeasureDate.CalendarTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.RepItem_dtpMeasureDate.CalendarTimeProperties.Mask.MaskType = CType(resources.GetObject("RepItem_dtpMeasureDate.CalendarTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.RepItem_dtpMeasureDate.CalendarTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("RepItem_dtpMeasureDate.CalendarTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.RepItem_dtpMeasureDate.CalendarTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("RepItem_dtpMeasureDate.CalendarTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.RepItem_dtpMeasureDate.CalendarTimeProperties.NullValuePrompt = resources.GetString("RepItem_dtpMeasureDate.CalendarTimeProperties.NullValuePrompt")
        Me.RepItem_dtpMeasureDate.Mask.EditMask = resources.GetString("RepItem_dtpMeasureDate.Mask.EditMask")
        Me.RepItem_dtpMeasureDate.Mask.IgnoreMaskBlank = CType(resources.GetObject("RepItem_dtpMeasureDate.Mask.IgnoreMaskBlank"), Boolean)
        Me.RepItem_dtpMeasureDate.Mask.MaskType = CType(resources.GetObject("RepItem_dtpMeasureDate.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.RepItem_dtpMeasureDate.Mask.SaveLiteral = CType(resources.GetObject("RepItem_dtpMeasureDate.Mask.SaveLiteral"), Boolean)
        Me.RepItem_dtpMeasureDate.Mask.ShowPlaceHolders = CType(resources.GetObject("RepItem_dtpMeasureDate.Mask.ShowPlaceHolders"), Boolean)
        Me.RepItem_dtpMeasureDate.Name = "RepItem_dtpMeasureDate"
        '
        'RepItem_slcResponsiblePerson
        '
        Me.RepItem_slcResponsiblePerson.Appearance.Options.UseFont = True
        Me.RepItem_slcResponsiblePerson.AppearanceDisabled.Options.UseFont = True
        Me.RepItem_slcResponsiblePerson.AppearanceDropDown.Options.UseFont = True
        Me.RepItem_slcResponsiblePerson.AppearanceDropDownHeader.Options.UseFont = True
        Me.RepItem_slcResponsiblePerson.AppearanceFocused.Options.UseFont = True
        Me.RepItem_slcResponsiblePerson.AppearanceReadOnly.Options.UseFont = True
        resources.ApplyResources(Me.RepItem_slcResponsiblePerson, "RepItem_slcResponsiblePerson")
        SerializableAppearanceObject75.Options.UseFont = True
        Me.RepItem_slcResponsiblePerson.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepItem_slcResponsiblePerson.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("RepItem_slcResponsiblePerson.Buttons1"), CType(resources.GetObject("RepItem_slcResponsiblePerson.Buttons2"), Integer), CType(resources.GetObject("RepItem_slcResponsiblePerson.Buttons3"), Boolean), CType(resources.GetObject("RepItem_slcResponsiblePerson.Buttons4"), Boolean), CType(resources.GetObject("RepItem_slcResponsiblePerson.Buttons5"), Boolean), CType(resources.GetObject("RepItem_slcResponsiblePerson.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("RepItem_slcResponsiblePerson.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject75, resources.GetString("RepItem_slcResponsiblePerson.Buttons8"), CType(resources.GetObject("RepItem_slcResponsiblePerson.Buttons9"), Object), CType(resources.GetObject("RepItem_slcResponsiblePerson.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("RepItem_slcResponsiblePerson.Buttons11"), Boolean))})
        Me.RepItem_slcResponsiblePerson.Name = "RepItem_slcResponsiblePerson"
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn4, Me.GridColumn5})
        resources.ApplyResources(Me.GridView3, "GridView3")
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'GridColumn4
        '
        resources.ApplyResources(Me.GridColumn4, "GridColumn4")
        Me.GridColumn4.Name = "GridColumn4"
        '
        'GridColumn5
        '
        resources.ApplyResources(Me.GridColumn5, "GridColumn5")
        Me.GridColumn5.Name = "GridColumn5"
        '
        'gbCaseData
        '
        resources.ApplyResources(Me.gbCaseData, "gbCaseData")
        Me.gbCaseData.Controls.Add(Me.cbEnteredByOrganization)
        Me.gbCaseData.Controls.Add(Me.cbEnteredByName)
        Me.gbCaseData.Controls.Add(Me.lbEnteredByOrganization)
        Me.gbCaseData.Controls.Add(Me.lbEnteredByName)
        Me.gbCaseData.Controls.Add(Me.cbCaseStatus)
        Me.gbCaseData.Controls.Add(Me.lbCaseStatus)
        Me.gbCaseData.Controls.Add(Me.cbCaseClassification)
        Me.gbCaseData.Controls.Add(Me.txtCaseID)
        Me.gbCaseData.Controls.Add(Me.lblPatient)
        Me.gbCaseData.Controls.Add(Me.txtPatient)
        Me.gbCaseData.Controls.Add(Me.dtEnteringDate)
        Me.gbCaseData.Controls.Add(Me.lbDateLastSaved)
        Me.gbCaseData.Controls.Add(Me.lbDateEntered)
        Me.gbCaseData.Controls.Add(Me.dtStartDate)
        Me.gbCaseData.Controls.Add(Me.cbCurrentDiagnosis)
        Me.gbCaseData.Controls.Add(Me.lblCaseID)
        Me.gbCaseData.Controls.Add(Me.lblCaseClassification)
        Me.gbCaseData.Controls.Add(Me.lblDisease)
        Me.gbCaseData.Controls.Add(Me.lbEnteredBy)
        Me.gbCaseData.Name = "gbCaseData"
        '
        'cbEnteredByOrganization
        '
        resources.ApplyResources(Me.cbEnteredByOrganization, "cbEnteredByOrganization")
        Me.cbEnteredByOrganization.Name = "cbEnteredByOrganization"
        Me.cbEnteredByOrganization.Properties.Appearance.Options.UseFont = True
        Me.cbEnteredByOrganization.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbEnteredByOrganization.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbEnteredByOrganization.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbEnteredByOrganization.Properties.AutoHeight = CType(resources.GetObject("cbEnteredByOrganization.Properties.AutoHeight"), Boolean)
        Me.cbEnteredByOrganization.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbEnteredByOrganization.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbEnteredByOrganization.Properties.NullText = resources.GetString("cbEnteredByOrganization.Properties.NullText")
        Me.cbEnteredByOrganization.Properties.NullValuePrompt = resources.GetString("cbEnteredByOrganization.Properties.NullValuePrompt")
        Me.cbEnteredByOrganization.TabStop = False
        Me.cbEnteredByOrganization.Tag = "{R}"
        '
        'cbEnteredByName
        '
        resources.ApplyResources(Me.cbEnteredByName, "cbEnteredByName")
        Me.cbEnteredByName.Name = "cbEnteredByName"
        Me.cbEnteredByName.Properties.Appearance.Options.UseFont = True
        Me.cbEnteredByName.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbEnteredByName.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbEnteredByName.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbEnteredByName.Properties.AutoHeight = CType(resources.GetObject("cbEnteredByName.Properties.AutoHeight"), Boolean)
        Me.cbEnteredByName.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbEnteredByName.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbEnteredByName.Properties.NullText = resources.GetString("cbEnteredByName.Properties.NullText")
        Me.cbEnteredByName.Properties.NullValuePrompt = resources.GetString("cbEnteredByName.Properties.NullValuePrompt")
        Me.cbEnteredByName.TabStop = False
        Me.cbEnteredByName.Tag = "{R}"
        '
        'lbEnteredByOrganization
        '
        resources.ApplyResources(Me.lbEnteredByOrganization, "lbEnteredByOrganization")
        Me.lbEnteredByOrganization.Name = "lbEnteredByOrganization"
        '
        'lbEnteredByName
        '
        resources.ApplyResources(Me.lbEnteredByName, "lbEnteredByName")
        Me.lbEnteredByName.Name = "lbEnteredByName"
        '
        'cbCaseStatus
        '
        resources.ApplyResources(Me.cbCaseStatus, "cbCaseStatus")
        Me.cbCaseStatus.Name = "cbCaseStatus"
        Me.cbCaseStatus.Properties.Appearance.Options.UseFont = True
        Me.cbCaseStatus.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbCaseStatus.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbCaseStatus.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.cbCaseStatus.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbCaseStatus.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbCaseStatus.Properties.AutoHeight = CType(resources.GetObject("cbCaseStatus.Properties.AutoHeight"), Boolean)
        SerializableAppearanceObject76.Options.UseFont = True
        Me.cbCaseStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbCaseStatus.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("cbCaseStatus.Properties.Buttons1"), CType(resources.GetObject("cbCaseStatus.Properties.Buttons2"), Integer), CType(resources.GetObject("cbCaseStatus.Properties.Buttons3"), Boolean), CType(resources.GetObject("cbCaseStatus.Properties.Buttons4"), Boolean), CType(resources.GetObject("cbCaseStatus.Properties.Buttons5"), Boolean), CType(resources.GetObject("cbCaseStatus.Properties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("cbCaseStatus.Properties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject76, resources.GetString("cbCaseStatus.Properties.Buttons8"), CType(resources.GetObject("cbCaseStatus.Properties.Buttons9"), Object), CType(resources.GetObject("cbCaseStatus.Properties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("cbCaseStatus.Properties.Buttons11"), Boolean))})
        Me.cbCaseStatus.Properties.NullText = resources.GetString("cbCaseStatus.Properties.NullText")
        Me.cbCaseStatus.Properties.NullValuePrompt = resources.GetString("cbCaseStatus.Properties.NullValuePrompt")
        Me.cbCaseStatus.Tag = "{Immovable}{M}{statuscontrol}"
        '
        'lbCaseStatus
        '
        resources.ApplyResources(Me.lbCaseStatus, "lbCaseStatus")
        Me.lbCaseStatus.Name = "lbCaseStatus"
        Me.lbCaseStatus.Tag = "{Immovable}"
        '
        'cbCaseClassification
        '
        resources.ApplyResources(Me.cbCaseClassification, "cbCaseClassification")
        Me.cbCaseClassification.Name = "cbCaseClassification"
        Me.cbCaseClassification.Properties.Appearance.Options.UseFont = True
        Me.cbCaseClassification.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbCaseClassification.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbCaseClassification.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbCaseClassification.Properties.AutoHeight = CType(resources.GetObject("cbCaseClassification.Properties.AutoHeight"), Boolean)
        Me.cbCaseClassification.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbCaseClassification.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbCaseClassification.Properties.NullText = resources.GetString("cbCaseClassification.Properties.NullText")
        Me.cbCaseClassification.Properties.NullValuePrompt = resources.GetString("cbCaseClassification.Properties.NullValuePrompt")
        Me.cbCaseClassification.TabStop = False
        Me.cbCaseClassification.Tag = "{R}"
        '
        'txtCaseID
        '
        resources.ApplyResources(Me.txtCaseID, "txtCaseID")
        Me.txtCaseID.Name = "txtCaseID"
        Me.txtCaseID.Properties.Appearance.Options.UseFont = True
        Me.txtCaseID.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtCaseID.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtCaseID.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtCaseID.Properties.AutoHeight = CType(resources.GetObject("txtCaseID.Properties.AutoHeight"), Boolean)
        Me.txtCaseID.Properties.Mask.EditMask = resources.GetString("txtCaseID.Properties.Mask.EditMask")
        Me.txtCaseID.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtCaseID.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtCaseID.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtCaseID.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtCaseID.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtCaseID.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtCaseID.Properties.NullValuePrompt = resources.GetString("txtCaseID.Properties.NullValuePrompt")
        Me.txtCaseID.TabStop = False
        Me.txtCaseID.Tag = "[en]{AlwaysEditable}"
        '
        'lblPatient
        '
        resources.ApplyResources(Me.lblPatient, "lblPatient")
        Me.lblPatient.Name = "lblPatient"
        '
        'txtPatient
        '
        resources.ApplyResources(Me.txtPatient, "txtPatient")
        Me.txtPatient.Name = "txtPatient"
        Me.txtPatient.Properties.Appearance.Options.UseFont = True
        Me.txtPatient.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtPatient.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtPatient.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtPatient.Properties.AutoHeight = CType(resources.GetObject("txtPatient.Properties.AutoHeight"), Boolean)
        Me.txtPatient.Properties.Mask.EditMask = resources.GetString("txtPatient.Properties.Mask.EditMask")
        Me.txtPatient.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtPatient.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtPatient.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtPatient.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtPatient.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtPatient.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtPatient.Properties.NullValuePrompt = resources.GetString("txtPatient.Properties.NullValuePrompt")
        Me.txtPatient.TabStop = False
        Me.txtPatient.Tag = "{R}"
        '
        'dtEnteringDate
        '
        resources.ApplyResources(Me.dtEnteringDate, "dtEnteringDate")
        Me.dtEnteringDate.Name = "dtEnteringDate"
        Me.dtEnteringDate.Properties.Appearance.Options.UseFont = True
        Me.dtEnteringDate.Properties.AppearanceDisabled.Options.UseFont = True
        Me.dtEnteringDate.Properties.AppearanceDropDown.Options.UseFont = True
        Me.dtEnteringDate.Properties.AppearanceDropDownHeader.Options.UseFont = True
        Me.dtEnteringDate.Properties.AppearanceDropDownHeaderHighlight.Options.UseFont = True
        Me.dtEnteringDate.Properties.AppearanceDropDownHighlight.Options.UseFont = True
        Me.dtEnteringDate.Properties.AppearanceFocused.Options.UseFont = True
        Me.dtEnteringDate.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.dtEnteringDate.Properties.AppearanceWeekNumber.Options.UseFont = True
        Me.dtEnteringDate.Properties.AutoHeight = CType(resources.GetObject("dtEnteringDate.Properties.AutoHeight"), Boolean)
        Me.dtEnteringDate.Properties.CalendarTimeProperties.Appearance.Options.UseFont = True
        Me.dtEnteringDate.Properties.CalendarTimeProperties.AppearanceDisabled.Options.UseFont = True
        Me.dtEnteringDate.Properties.CalendarTimeProperties.AppearanceFocused.Options.UseFont = True
        Me.dtEnteringDate.Properties.CalendarTimeProperties.AppearanceReadOnly.Options.UseFont = True
        Me.dtEnteringDate.Properties.CalendarTimeProperties.AutoHeight = CType(resources.GetObject("dtEnteringDate.Properties.CalendarTimeProperties.AutoHeight"), Boolean)
        SerializableAppearanceObject77.Options.UseFont = True
        Me.dtEnteringDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("dtEnteringDate.Properties.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("dtEnteringDate.Properties.CalendarTimeProperties.Buttons1"), CType(resources.GetObject("dtEnteringDate.Properties.CalendarTimeProperties.Buttons2"), Integer), CType(resources.GetObject("dtEnteringDate.Properties.CalendarTimeProperties.Buttons3"), Boolean), CType(resources.GetObject("dtEnteringDate.Properties.CalendarTimeProperties.Buttons4"), Boolean), CType(resources.GetObject("dtEnteringDate.Properties.CalendarTimeProperties.Buttons5"), Boolean), CType(resources.GetObject("dtEnteringDate.Properties.CalendarTimeProperties.Buttons6"), DevExpress.XtraEditors.ImageLocation), CType(resources.GetObject("dtEnteringDate.Properties.CalendarTimeProperties.Buttons7"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject77, resources.GetString("dtEnteringDate.Properties.CalendarTimeProperties.Buttons8"), CType(resources.GetObject("dtEnteringDate.Properties.CalendarTimeProperties.Buttons9"), Object), CType(resources.GetObject("dtEnteringDate.Properties.CalendarTimeProperties.Buttons10"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("dtEnteringDate.Properties.CalendarTimeProperties.Buttons11"), Boolean))})
        Me.dtEnteringDate.Properties.CalendarTimeProperties.Mask.EditMask = resources.GetString("dtEnteringDate.Properties.CalendarTimeProperties.Mask.EditMask")
        Me.dtEnteringDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtEnteringDate.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtEnteringDate.Properties.CalendarTimeProperties.Mask.MaskType = CType(resources.GetObject("dtEnteringDate.Properties.CalendarTimeProperties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtEnteringDate.Properties.CalendarTimeProperties.Mask.SaveLiteral = CType(resources.GetObject("dtEnteringDate.Properties.CalendarTimeProperties.Mask.SaveLiteral"), Boolean)
        Me.dtEnteringDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtEnteringDate.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtEnteringDate.Properties.CalendarTimeProperties.NullValuePrompt = resources.GetString("dtEnteringDate.Properties.CalendarTimeProperties.NullValuePrompt")
        Me.dtEnteringDate.Properties.DisplayFormat.FormatString = "g"
        Me.dtEnteringDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtEnteringDate.Properties.EditFormat.FormatString = "g"
        Me.dtEnteringDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtEnteringDate.Properties.Mask.BeepOnError = CType(resources.GetObject("dtEnteringDate.Properties.Mask.BeepOnError"), Boolean)
        Me.dtEnteringDate.Properties.Mask.EditMask = resources.GetString("dtEnteringDate.Properties.Mask.EditMask")
        Me.dtEnteringDate.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("dtEnteringDate.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.dtEnteringDate.Properties.Mask.MaskType = CType(resources.GetObject("dtEnteringDate.Properties.Mask.MaskType"), DevExpress.XtraEditors.Mask.MaskType)
        Me.dtEnteringDate.Properties.Mask.SaveLiteral = CType(resources.GetObject("dtEnteringDate.Properties.Mask.SaveLiteral"), Boolean)
        Me.dtEnteringDate.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("dtEnteringDate.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.dtEnteringDate.Properties.NullValuePrompt = resources.GetString("dtEnteringDate.Properties.NullValuePrompt")
        Me.dtEnteringDate.Properties.ValidateOnEnterKey = True
        Me.dtEnteringDate.TabStop = False
        Me.dtEnteringDate.Tag = "{AlwaysEditable}"
        '
        'lbDateLastSaved
        '
        resources.ApplyResources(Me.lbDateLastSaved, "lbDateLastSaved")
        Me.lbDateLastSaved.Name = "lbDateLastSaved"
        '
        'lbDateEntered
        '
        resources.ApplyResources(Me.lbDateEntered, "lbDateEntered")
        Me.lbDateEntered.Name = "lbDateEntered"
        '
        'cbCurrentDiagnosis
        '
        resources.ApplyResources(Me.cbCurrentDiagnosis, "cbCurrentDiagnosis")
        Me.cbCurrentDiagnosis.Name = "cbCurrentDiagnosis"
        Me.cbCurrentDiagnosis.Properties.Appearance.Options.UseFont = True
        Me.cbCurrentDiagnosis.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbCurrentDiagnosis.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbCurrentDiagnosis.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbCurrentDiagnosis.Properties.AutoHeight = CType(resources.GetObject("cbCurrentDiagnosis.Properties.AutoHeight"), Boolean)
        Me.cbCurrentDiagnosis.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbCurrentDiagnosis.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cbCurrentDiagnosis.Properties.NullText = resources.GetString("cbCurrentDiagnosis.Properties.NullText")
        Me.cbCurrentDiagnosis.Properties.NullValuePrompt = resources.GetString("cbCurrentDiagnosis.Properties.NullValuePrompt")
        Me.cbCurrentDiagnosis.TabStop = False
        Me.cbCurrentDiagnosis.Tag = "{R}"
        '
        'lblCaseID
        '
        resources.ApplyResources(Me.lblCaseID, "lblCaseID")
        Me.lblCaseID.Name = "lblCaseID"
        '
        'lblCaseClassification
        '
        resources.ApplyResources(Me.lblCaseClassification, "lblCaseClassification")
        Me.lblCaseClassification.Name = "lblCaseClassification"
        '
        'lblDisease
        '
        resources.ApplyResources(Me.lblDisease, "lblDisease")
        Me.lblDisease.Name = "lblDisease"
        '
        'lbEnteredBy
        '
        resources.ApplyResources(Me.lbEnteredBy, "lbEnteredBy")
        Me.lbEnteredBy.Name = "lbEnteredBy"
        '
        'SimpleButton2
        '
        resources.ApplyResources(Me.SimpleButton2, "SimpleButton2")
        Me.SimpleButton2.Appearance.Options.UseFont = True
        Me.SimpleButton2.Name = "SimpleButton2"
        '
        'Timer2
        '
        Me.Timer2.Interval = 500
        '
        'cmMenuReports
        '
        '        Me.cmMenuReports.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miCaseInvestigationForm, Me.miNotificationForm, Me.miNotificationFormDTRA, Me.miNotificationFormTanzania})
        '
        'miCaseInvestigationForm
        '
        Me.miCaseInvestigationForm.Index = 0
        resources.ApplyResources(Me.miCaseInvestigationForm, "miCaseInvestigationForm")
        '
        'miNotificationForm
        '
        Me.miNotificationForm.Index = 1
        resources.ApplyResources(Me.miNotificationForm, "miNotificationForm")

        Me.miNotificationFormDTRA.Index = 2
        resources.ApplyResources(Me.miNotificationFormDTRA, "miNotificationFormDTRA")

        Me.miNotificationFormTanzania.Index = 3
        resources.ApplyResources(Me.miNotificationFormTanzania, "miNotificationFormTanzania")


        '
        'PopUpButton2
        '
        resources.ApplyResources(Me.PopUpButton2, "PopUpButton2")
        Me.PopUpButton2.Appearance.Options.UseFont = True
        Me.PopUpButton2.ButtonType = bv.winclient.Core.PopUpButton.PopUpButtonStyles.Reports
        Me.PopUpButton2.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Show
        Me.PopUpButton2.ImageIndex = 0
        Me.PopUpButton2.Name = "PopUpButton2"
        Me.PopUpButton2.PopUpMenu = Me.cmMenuReports
        Me.PopUpButton2.Tag = "{Immovable}{AlwaysEditable}"
        '
        'txtCaseCount
        '
        resources.ApplyResources(Me.txtCaseCount, "txtCaseCount")
        Me.txtCaseCount.Name = "txtCaseCount"
        Me.txtCaseCount.Properties.AccessibleDescription = resources.GetString("txtCaseCount.Properties.AccessibleDescription")
        Me.txtCaseCount.Properties.Appearance.Options.UseFont = True
        Me.txtCaseCount.Properties.Appearance.Options.UseTextOptions = True
        Me.txtCaseCount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtCaseCount.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtCaseCount.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtCaseCount.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtCaseCount.Properties.AutoHeight = CType(resources.GetObject("txtCaseCount.Properties.AutoHeight"), Boolean)
        Me.txtCaseCount.Properties.Mask.EditMask = resources.GetString("txtCaseCount.Properties.Mask.EditMask")
        Me.txtCaseCount.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtCaseCount.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtCaseCount.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtCaseCount.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtCaseCount.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtCaseCount.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtCaseCount.Properties.NullValuePrompt = resources.GetString("txtCaseCount.Properties.NullValuePrompt")
        Me.txtCaseCount.Properties.ReadOnly = True
        Me.txtCaseCount.Tag = "{AlwaysEditable}"
        '
        'txtCaseNumber
        '
        resources.ApplyResources(Me.txtCaseNumber, "txtCaseNumber")
        Me.txtCaseNumber.Name = "txtCaseNumber"
        Me.txtCaseNumber.Properties.AccessibleDescription = resources.GetString("txtCaseNumber.Properties.AccessibleDescription")
        Me.txtCaseNumber.Properties.Appearance.Options.UseFont = True
        Me.txtCaseNumber.Properties.Appearance.Options.UseTextOptions = True
        Me.txtCaseNumber.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtCaseNumber.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtCaseNumber.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtCaseNumber.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtCaseNumber.Properties.AutoHeight = CType(resources.GetObject("txtCaseNumber.Properties.AutoHeight"), Boolean)
        Me.txtCaseNumber.Properties.Mask.EditMask = resources.GetString("txtCaseNumber.Properties.Mask.EditMask")
        Me.txtCaseNumber.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtCaseNumber.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtCaseNumber.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtCaseNumber.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtCaseNumber.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtCaseNumber.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtCaseNumber.Properties.NullValuePrompt = resources.GetString("txtCaseNumber.Properties.NullValuePrompt")
        Me.txtCaseNumber.Properties.ValidateOnEnterKey = True
        Me.txtCaseNumber.Tag = "{AlwaysEditable}"
        '
        'btnNewCase
        '
        resources.ApplyResources(Me.btnNewCase, "btnNewCase")
        Me.btnNewCase.Appearance.Options.UseFont = True
        Me.btnNewCase.Name = "btnNewCase"
        Me.btnNewCase.Tag = "{AlwaysEditable}"
        '
        'btnNewCase1
        '
        resources.ApplyResources(Me.btnNewCase1, "btnNewCase1")
        Me.btnNewCase1.Appearance.Options.UseFont = True
        Me.btnNewCase1.Name = "btnNewCase1"
        Me.btnNewCase1.TabStop = False
        Me.btnNewCase1.Tag = "{AlwaysEditable}"
        '
        'txtCaseNumber1
        '
        resources.ApplyResources(Me.txtCaseNumber1, "txtCaseNumber1")
        Me.txtCaseNumber1.Name = "txtCaseNumber1"
        Me.txtCaseNumber1.Properties.AccessibleDescription = resources.GetString("txtCaseNumber1.Properties.AccessibleDescription")
        Me.txtCaseNumber1.Properties.Appearance.Options.UseFont = True
        Me.txtCaseNumber1.Properties.Appearance.Options.UseTextOptions = True
        Me.txtCaseNumber1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtCaseNumber1.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtCaseNumber1.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtCaseNumber1.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtCaseNumber1.Properties.AutoHeight = CType(resources.GetObject("txtCaseNumber1.Properties.AutoHeight"), Boolean)
        Me.txtCaseNumber1.Properties.Mask.EditMask = resources.GetString("txtCaseNumber1.Properties.Mask.EditMask")
        Me.txtCaseNumber1.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtCaseNumber1.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtCaseNumber1.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtCaseNumber1.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtCaseNumber1.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtCaseNumber1.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtCaseNumber1.Properties.NullValuePrompt = resources.GetString("txtCaseNumber1.Properties.NullValuePrompt")
        Me.txtCaseNumber1.Properties.ValidateOnEnterKey = True
        Me.txtCaseNumber1.TabStop = False
        Me.txtCaseNumber1.Tag = "{AlwaysEditable}"
        '
        'txtCaseCount1
        '
        resources.ApplyResources(Me.txtCaseCount1, "txtCaseCount1")
        Me.txtCaseCount1.Name = "txtCaseCount1"
        Me.txtCaseCount1.Properties.AccessibleDescription = resources.GetString("txtCaseCount1.Properties.AccessibleDescription")
        Me.txtCaseCount1.Properties.Appearance.Options.UseFont = True
        Me.txtCaseCount1.Properties.Appearance.Options.UseTextOptions = True
        Me.txtCaseCount1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtCaseCount1.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtCaseCount1.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtCaseCount1.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtCaseCount1.Properties.AutoHeight = CType(resources.GetObject("txtCaseCount1.Properties.AutoHeight"), Boolean)
        Me.txtCaseCount1.Properties.Mask.EditMask = resources.GetString("txtCaseCount1.Properties.Mask.EditMask")
        Me.txtCaseCount1.Properties.Mask.IgnoreMaskBlank = CType(resources.GetObject("txtCaseCount1.Properties.Mask.IgnoreMaskBlank"), Boolean)
        Me.txtCaseCount1.Properties.Mask.SaveLiteral = CType(resources.GetObject("txtCaseCount1.Properties.Mask.SaveLiteral"), Boolean)
        Me.txtCaseCount1.Properties.Mask.ShowPlaceHolders = CType(resources.GetObject("txtCaseCount1.Properties.Mask.ShowPlaceHolders"), Boolean)
        Me.txtCaseCount1.Properties.NullValuePrompt = resources.GetString("txtCaseCount1.Properties.NullValuePrompt")
        Me.txtCaseCount1.Properties.ReadOnly = True
        Me.txtCaseCount1.TabStop = False
        Me.txtCaseCount1.Tag = "{AlwaysEditable}"
        '
        'btnNextCase1
        '
        resources.ApplyResources(Me.btnNextCase1, "btnNextCase1")
        Me.btnNextCase1.Appearance.Options.UseFont = True
        Me.btnNextCase1.Name = "btnNextCase1"
        Me.btnNextCase1.TabStop = False
        Me.btnNextCase1.Tag = "{AlwaysEditable}"
        '
        'btnLastCase1
        '
        resources.ApplyResources(Me.btnLastCase1, "btnLastCase1")
        Me.btnLastCase1.Appearance.Options.UseFont = True
        Me.btnLastCase1.Name = "btnLastCase1"
        Me.btnLastCase1.TabStop = False
        Me.btnLastCase1.Tag = "{AlwaysEditable}"
        '
        'btnFirstCase1
        '
        resources.ApplyResources(Me.btnFirstCase1, "btnFirstCase1")
        Me.btnFirstCase1.Appearance.Options.UseFont = True
        Me.btnFirstCase1.Name = "btnFirstCase1"
        Me.btnFirstCase1.TabStop = False
        Me.btnFirstCase1.Tag = "{AlwaysEditable}"
        '
        'btnPrevCase1
        '
        resources.ApplyResources(Me.btnPrevCase1, "btnPrevCase1")
        Me.btnPrevCase1.Appearance.Options.UseFont = True
        Me.btnPrevCase1.Name = "btnPrevCase1"
        Me.btnPrevCase1.TabStop = False
        Me.btnPrevCase1.Tag = "{AlwaysEditable}"
        '
        'btnSearchHumanCase
        '
        resources.ApplyResources(Me.btnSearchHumanCase, "btnSearchHumanCase")
        Me.btnSearchHumanCase.Appearance.Options.UseFont = True
        Me.btnSearchHumanCase.Image = Global.eidss.My.Resources.Resources.Browse5
        Me.btnSearchHumanCase.Name = "btnSearchHumanCase"
        '
        'btnClear
        '
        resources.ApplyResources(Me.btnClear, "btnClear")
        Me.btnClear.Appearance.Options.UseFont = True
        Me.btnClear.Image = Global.eidss.My.Resources.Resources.Clear_Cancel_Changes1
        Me.btnClear.Name = "btnClear"
        '
        'btnSearchInBrowseMode
        '
        resources.ApplyResources(Me.btnSearchInBrowseMode, "btnSearchInBrowseMode")
        Me.btnSearchInBrowseMode.Appearance.Options.UseFont = True
        Me.btnSearchInBrowseMode.Image = Global.eidss.My.Resources.Resources.Search
        Me.btnSearchInBrowseMode.Name = "btnSearchInBrowseMode"
        '
        'HumanCaseDetail
        '
        Me.Appearance.Options.UseFont = True
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.gbCaseData)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.PopUpButton2)
        Me.Controls.Add(Me.btnSearchHumanCase)
        Me.Controls.Add(Me.btnSearchInBrowseMode)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnNewCase1)
        Me.Controls.Add(Me.txtCaseNumber1)
        Me.Controls.Add(Me.txtCaseCount1)
        Me.Controls.Add(Me.btnNextCase1)
        Me.Controls.Add(Me.btnLastCase1)
        Me.Controls.Add(Me.btnFirstCase1)
        Me.Controls.Add(Me.btnPrevCase1)
        Me.Controls.Add(Me.btnNewCase)
        Me.Controls.Add(Me.txtCaseNumber)
        Me.Controls.Add(Me.txtCaseCount)
        Me.Controls.Add(Me.bntNextCase)
        Me.Controls.Add(Me.btnLastCase)
        Me.Controls.Add(Me.btnFirstCase)
        Me.Controls.Add(Me.bntPreviousCase)
        Me.DefaultFormState = System.Windows.Forms.FormWindowState.Normal
        Me.FormID = "H02"
        Me.HelpTopicID = "HC_H02"
        Me.KeyFieldName = "idfCase"
        Me.LeftIcon = Global.eidss.My.Resources.Resources.Human_Case__large_
        Me.Name = "HumanCaseDetail"
        Me.ObjectName = "HumanCase"
        Me.ShowNewButton = True
        Me.Status = bv.common.win.FormStatus.Draft
        Me.TableName = "tlbHumanCase"
        Me.Controls.SetChildIndex(Me.bntPreviousCase, 0)
        Me.Controls.SetChildIndex(Me.btnFirstCase, 0)
        Me.Controls.SetChildIndex(Me.btnLastCase, 0)
        Me.Controls.SetChildIndex(Me.bntNextCase, 0)
        Me.Controls.SetChildIndex(Me.txtCaseCount, 0)
        Me.Controls.SetChildIndex(Me.txtCaseNumber, 0)
        Me.Controls.SetChildIndex(Me.btnNewCase, 0)
        Me.Controls.SetChildIndex(Me.btnPrevCase1, 0)
        Me.Controls.SetChildIndex(Me.btnFirstCase1, 0)
        Me.Controls.SetChildIndex(Me.btnLastCase1, 0)
        Me.Controls.SetChildIndex(Me.btnNextCase1, 0)
        Me.Controls.SetChildIndex(Me.txtCaseCount1, 0)
        Me.Controls.SetChildIndex(Me.txtCaseNumber1, 0)
        Me.Controls.SetChildIndex(Me.btnNewCase1, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.btnSearchInBrowseMode, 0)
        Me.Controls.SetChildIndex(Me.btnSearchHumanCase, 0)
        Me.Controls.SetChildIndex(Me.PopUpButton2, 0)
        Me.Controls.SetChildIndex(Me.SimpleButton2, 0)
        Me.Controls.SetChildIndex(Me.btnClear, 0)
        Me.Controls.SetChildIndex(Me.gbCaseData, 0)
        CType(Me.dtFirstAntimicrobialAdminDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFirstAntimicrobialAdminDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tpGeneral.ResumeLayout(False)
        CType(Me.txtLocalID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFormCompletionDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFormCompletionDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtDiagnosisDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtDiagnosisDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDiagnosis.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gpDemographicInformation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpDemographicInformation.ResumeLayout(False)
        CType(Me.dtLastVisitToEmployer.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtLastVisitToEmployer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbAgeUnits.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAge.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gpGeneralInformation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpGeneralInformation.ResumeLayout(False)
        CType(Me.cbReceivedByName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSentByName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbReceivedInst.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbRepSource.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtReportingDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtReportingDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gpClinicalInformation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpClinicalInformation.ResumeLayout(False)
        CType(Me.cbCurrentPatientLocation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOtherLocation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtChangedDiagnosisDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtChangedDiagnosisDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbChangedDiagnosis.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbFinalState.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbHospitalizedTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deOnsetDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deOnsetDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.memoNote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpCaseInvestigation.ResumeLayout(False)
        CType(Me.tcCaseInvestigation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tcCaseInvestigation.ResumeLayout(False)
        Me.tpDemographic.ResumeLayout(False)
        CType(Me.dtInvestigationStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtInvestigationStartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNotifSentByDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNotifOrganization.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbInvOrganization.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLocalIdentifier.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gpDemographicInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpDemographicInfo.ResumeLayout(False)
        Me.gpDemographicInfo.PerformLayout()
        CType(Me.txtPersonalIdType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPersonalID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkUseSameAddress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkForeignAddress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPhoneNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRegistrationPhone.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWorkPhone.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbOccupation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmployerLastVisit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDOB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNationality.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPatientSex.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPatientAgeUnits.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmployerName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPatientAge.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFirstName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLastName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSecondName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpClinicalInformation.ResumeLayout(False)
        CType(Me.cbNonNotifiableDiesease.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbHospitalization.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbAntimicrobialTherapy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.meClinicalComments.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbInitialCaseClassification.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDateOfxposure.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDateOfxposure.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHospital.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDateOfAdmissionHospitalization.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDateOfAdmissionHospitalization.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClinicalDiagnosis.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDatePatientFirstSought.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDatePatientFirstSought.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSymptomOnsetDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbFacilitySoughtCare.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcAntimicrobialTherapy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvAntimicrobialTherapy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpSamples.ResumeLayout(False)
        CType(Me.cbNotCollectedReason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSpecimenCollected.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpContactsRemarks.ResumeLayout(False)
        CType(Me.gcContactPeople, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvContactPeople, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContactName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbContactType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtContactDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtContactDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContactComments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpCaseClassification.ResumeLayout(False)
        Me.tpEpiLinksRiskFactors.ResumeLayout(False)
        Me.tpCaseSummary.ResumeLayout(False)
        CType(Me.dtFinalCaseClassificationDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFinalCaseClassificationDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbEpidemiologistName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chbEpiDiagBasis.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chbLabDiagBasis.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chbClinicalDiagBasis.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDateOfDeath.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDateOfDeath.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFinalDiagnosisDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFinalDiagnosisDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbOutbreakExists.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lueFinalCaseClassification.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbOutcome.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFinalDiagnosis.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbOutbreakID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.meSummaryComments.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDateOfDischarge.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDateOfDischarge.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDischargeDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpTests.ResumeLayout(False)
        CType(Me.cbTestsConducted.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.redDateDiagDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.redDateDiagDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.redLookupDiagType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.redLookupDiseaseName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.redLookupBaseForDiag, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.redLookupDiagBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtStartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepItem_slcResponseMeasureType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepItem_slcResult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepItem_dtpMeasureDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepItem_dtpMeasureDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepItem_slcResponsiblePerson, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCaseData.ResumeLayout(False)
        CType(Me.cbEnteredByOrganization.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbEnteredByName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCaseStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCaseClassification.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCaseID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPatient.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtEnteringDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtEnteringDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCurrentDiagnosis.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCaseCount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCaseNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCaseNumber1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCaseCount1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub


#End Region
#Region "Main form interface"

    Public Shared Sub Register(ByVal ParentControl As System.Windows.Forms.Control)
        Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Create, "MenuNewHumanCase", 200)
        ma.ShowInToolbar = False
        ma.SmallIconIndex = MenuIconsSmall.HumanCase
        ma.BigIconIndex = MenuIcons.NewHumanCase
        ma.Name = "btnNewHumanCase"
        ma.Group = CInt(MenuGroup.CreateCase)
        ma.SelectPermission = PermissionHelper.InsertPermission(eidss.model.Enums.EIDSSPermissionObject.HumanCase)

        'Toolbar menu
        ma = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Journals, "ToolbarNewHumanCase", 100100)
        ma.ShowInToolbar = True
        ma.ShowInMenu = False
        ma.BigIconIndex = MenuIcons.NewHumanCase
        ma.Name = "btnNewHumanCase"
        ma.Order = 100100
        ma.Group = CInt(MenuGroup.ToolbarCreate)
        ma.SelectPermission = PermissionHelper.InsertPermission(eidss.model.Enums.EIDSSPermissionObject.HumanCase)

        ma = New MenuAction(AddressOf ShowSearchMode, MenuActionManager.Instance, MenuActionManager.Instance.Search, "MenuSearchHumanCaseInBrowseMode", 220)
        ma.ShowInToolbar = False
        ma.BigIconIndex = MenuIcons.SearchHumanCaseInBrowseMode
        ma.SmallIconIndex = MenuIconsSmall.SearchHumanCaseInBrowseMode
        ma.Order = 22
        ma.SelectPermission = PermissionHelper.SelectPermission(eidss.model.Enums.EIDSSPermissionObject.HumanCase)
    End Sub

    Public Shared Sub ShowMe()
        DebugTimer.Start("New human case creation is started")
        BaseFormManager.ShowNormal(New HumanCaseDetail, Nothing)
        DebugTimer.Stop()
    End Sub

    Public Shared Sub ShowSearchMode()
        BaseFormManager.ShowNormal(New HumanCaseDetail(True), Utils.SEARCH_MODE_ID)
    End Sub
#End Region

#Region "Flexible Form Support"

    Public Sub CheckFFVisibility()

        Dim TentativeDiag As Object = DBNull.Value
        Dim FinalDiag As Object = DBNull.Value
        If IsSearchMode() Then
            If (Not cbDiagnosis Is Nothing) AndAlso (Not Utils.IsEmpty(cbDiagnosis.EditValue)) Then
                TentativeDiag = cbDiagnosis.EditValue
            End If
        ElseIf (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) Then
            TentativeDiag = baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsTentativeDiagnosis")
        End If
        If IsSearchMode() Then
            If (Not cbChangedDiagnosis Is Nothing) AndAlso (Not Utils.IsEmpty(cbChangedDiagnosis.EditValue)) Then
                FinalDiag = cbChangedDiagnosis.EditValue
            End If
        ElseIf baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0 Then
            FinalDiag = baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsFinalDiagnosis")
        End If
        If Utils.IsEmpty(FinalDiag) AndAlso Utils.IsEmpty(TentativeDiag) Then
            FFClinicalSigns.Visible = False
            ffEpiInvestigations.Visible = False
        Else
            FFClinicalSigns.Visible = True
            ffEpiInvestigations.Visible = True
        End If
    End Sub
    Private Sub ResetFFTemplate()
        If baseDataSet.Tables.Contains(HumanCase_DB.tlbHumanCase) AndAlso _
               (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) Then
            baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsCSFormTemplate") = DBNull.Value
            baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsEPIFormTemplate") = DBNull.Value
        End If
    End Sub
    'Private Sub UpdateFFormTemplates()
    '    If baseDataSet.Tables.Contains(HumanCase_DB.tlbHumanCase) AndAlso _
    '       (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) Then

    '        If ((FFClinicalSigns Is Nothing) OrElse Utils.IsEmpty(FFClinicalSigns.TemplateID)) Then
    '            If (Not Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsCSFormTemplate"))) Then _
    '                baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsCSFormTemplate") = DBNull.Value
    '        ElseIf Utils.Str(FFClinicalSigns.TemplateID) <> _
    '               Utils.Str(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsCSFormTemplate")) Then
    '            baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsCSFormTemplate") = FFClinicalSigns.TemplateID
    '        End If

    '        If ((ffEpiInvestigations Is Nothing) OrElse Utils.IsEmpty(ffEpiInvestigations.TemplateID)) Then
    '            If (Not Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsEpiFormTemplate"))) Then _
    '                baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsEPIFormTemplate") = DBNull.Value
    '        ElseIf Utils.Str(ffEpiInvestigations.TemplateID) <> _
    '               Utils.Str(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsEPIFormTemplate")) Then
    '            baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsEPIFormTemplate") = ffEpiInvestigations.TemplateID
    '        End If
    '    End If
    'End Sub

    Private Function GetDBTemplateID(ByVal TemplateID As System.Nullable(Of Long)) As Object
        Dim DBTemplateID As Object = TemplateID
        If DBTemplateID Is Nothing Then
            DBTemplateID = DBNull.Value
        End If
        Return DBTemplateID
    End Function

    Public Sub UpdateFF()
        If IsSearchMode() Then
            FFClinicalSigns.DynamicParameterEnabled = False
            Dim Diag As Long = -1
            If (Not cbChangedDiagnosis Is Nothing) AndAlso (Not Utils.IsEmpty(cbChangedDiagnosis.EditValue)) Then
                Diag = CType(cbChangedDiagnosis.EditValue, Long)
            ElseIf (Not cbDiagnosis Is Nothing) AndAlso (Not Utils.IsEmpty(cbDiagnosis.EditValue)) Then
                Diag = CType(cbDiagnosis.EditValue, Long)
            End If
            FFClinicalSigns.ClearUserData()
            ffEpiInvestigations.ClearUserData()
            ' Force of Recalculation
            If Diag > 0 Then
                FFClinicalSigns.ShowFlexibleFormByDeterminant(Diag, CSObsInSearchMode, FFType.HumanClinicalSigns, True)
                ffEpiInvestigations.ShowFlexibleFormByDeterminant(Diag, EpiObsInSearchMode, FFType.HumanEpiInvestigations, True)
            Else
                FFClinicalSigns.ClearTemplate()
                ffEpiInvestigations.ClearTemplate()
            End If
        Else
            ' Force of Recalculation
            Dim Diag As Long = -1
            Dim CSObs As Long = -1
            Dim EpiObs As Long = -1
            If baseDataSet.Tables.Contains(HumanCase_DB.tlbHumanCase) AndAlso _
               (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) Then
                If Not Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsFinalDiagnosis")) Then
                    Diag = CType(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsFinalDiagnosis"), Long)
                ElseIf Not Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsTentativeDiagnosis")) Then
                    Diag = CType(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsTentativeDiagnosis"), Long)
                End If

                If Not Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfCSObservation")) Then
                    CSObs = CType(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfCSObservation"), Long)
                End If

                If Not Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfEpiObservation")) Then
                    EpiObs = CType(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfEpiObservation"), Long)
                End If
            End If
            If Diag > 0 Then
                Dim CSTemplateID As Long = -1
                Dim EpiTemplateID As Long = -1
                If baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsCSFormTemplate") Is DBNull.Value Then
                    If (Not m_DataLoaded) Then
                        FFClinicalSigns.ShowFlexibleFormByDeterminant(Diag, CSObs, FFType.HumanClinicalSigns, False)
                    Else
                        'If we don't show FF before diagnosis changes, we should refresh FF data to be sure that all existing FF values will go
                        'to new FF as dynamic parameters
                        If (FFClinicalSigns.DelayedLoadingNeeded AndAlso FFClinicalSigns.TemplateID.HasValue) Then
                            FFClinicalSigns.ShowFlexibleForm(FFClinicalSigns.TemplateID.Value, CSObs, FFType.HumanClinicalSigns, False, True)
                        End If
                        FFClinicalSigns.ShowFlexibleFormByDeterminant(Diag, CSObs, FFType.HumanClinicalSigns, True)
                    End If
                    baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsCSFormTemplate") = _
                        GetDBTemplateID(FFClinicalSigns.TemplateID)
                Else
                    CSTemplateID = CLng(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsCSFormTemplate"))
                    If (Not m_DataLoaded) Then
                        FFClinicalSigns.ShowFlexibleForm(CSTemplateID, CSObs, FFType.HumanClinicalSigns, False)
                    Else
                        FFClinicalSigns.ShowFlexibleForm(CSTemplateID, CSObs, FFType.HumanClinicalSigns, True)
                    End If
                End If

                If baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsEPIFormTemplate") Is DBNull.Value Then
                    If (Not m_DataLoaded) Then
                        ffEpiInvestigations.ShowFlexibleFormByDeterminant(Diag, EpiObs, FFType.HumanEpiInvestigations, False)
                    Else
                        If (ffEpiInvestigations.DelayedLoadingNeeded AndAlso ffEpiInvestigations.TemplateID.HasValue) Then
                            ffEpiInvestigations.ShowFlexibleForm(ffEpiInvestigations.TemplateID.Value, EpiObs, FFType.HumanEpiInvestigations, False, True)
                        End If
                        ffEpiInvestigations.ShowFlexibleFormByDeterminant(Diag, EpiObs, FFType.HumanEpiInvestigations, True)
                    End If
                    baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsEPIFormTemplate") = _
                        GetDBTemplateID(ffEpiInvestigations.TemplateID)
                Else
                    EpiTemplateID = CLng(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsEPIFormTemplate"))
                    If (Not m_DataLoaded) Then
                        ffEpiInvestigations.ShowFlexibleForm(EpiTemplateID, EpiObs, FFType.HumanEpiInvestigations, False)
                    Else
                        ffEpiInvestigations.ShowFlexibleForm(EpiTemplateID, EpiObs, FFType.HumanEpiInvestigations, True)
                    End If
                End If
            Else
                FFClinicalSigns.ClearTemplate()
                ffEpiInvestigations.ClearTemplate()
            End If
        End If
        CheckFFVisibility()
    End Sub

#End Region

#Region "Reports"

    'Case report
    Private Sub miCaseInvestigationForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miCaseInvestigationForm.Click
        If baseDataSet Is Nothing OrElse baseDataSet.Tables.Count = 0 Then
            Return
        End If
        If Not IsSearchMode() Then
            If Post(PostType.FinalPosting) Then
                Dim id As Long = CType(GetKey(HumanCase_DB.tlbHumanCase, "idfCase"), Long)
                Dim epiId As Long = CType(GetKey(HumanCase_DB.tlbHumanCase, "idfEpiObservation"), Long)
                Dim csId As Long = CType(GetKey(HumanCase_DB.tlbHumanCase, "idfCSObservation"), Long)
                Dim diagnosisID As Long
                Dim row As DataRow = baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)
                If Not Utils.IsEmpty(row("idfsFinalDiagnosis")) Then
                    diagnosisID = CType(row("idfsFinalDiagnosis"), Long)
                ElseIf Not Utils.IsEmpty(row("idfsTentativeDiagnosis")) Then
                    diagnosisID = CType(row("idfsTentativeDiagnosis"), Long)
                End If

                EidssSiteContext.ReportFactory.HumCaseInvestigation(id, epiId, csId, diagnosisID)
            End If
        End If
    End Sub

    '' UN 58/1
    'Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
    '    If Post(PostType.FinalPosting) Then
    '        DataVisualDoc.Show_H_U_A_GG_EmergencyNotification(bv.model.Model.Core.ModelUserContext.CurrentLanguage, Me.HumanCaseDbService.ID.ToString)
    '    End If
    'End Sub

    'UN
    Private Sub miNotificationForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNotificationForm.Click
        If baseDataSet Is Nothing OrElse baseDataSet.Tables.Count = 0 Then
            Return
        End If
        If (Not IsSearchMode()) AndAlso Post(PostType.FinalPosting) Then
            Dim key As Long = CLng(GetKey(HumanCase_DB.tlbHumanCase, "idfCase"))
            EidssSiteContext.ReportFactory.HumUrgentyNotification(key)
        End If
    End Sub


    Private Sub miNotificationFormDTRA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNotificationFormDTRA.Click
        If baseDataSet Is Nothing OrElse baseDataSet.Tables.Count = 0 Then
            Return
        End If
        If (Not IsSearchMode()) AndAlso Post(PostType.FinalPosting) Then
            Dim key As Long = CLng(GetKey(HumanCase_DB.tlbHumanCase, "idfCase"))
            EidssSiteContext.ReportFactory.HumUrgentyNotificationDTRA(key)
        End If
    End Sub


    Private Sub miNotificationFormTanzania_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNotificationFormTanzania.Click
        If baseDataSet Is Nothing OrElse baseDataSet.Tables.Count = 0 Then
            Return
        End If
        If (Not IsSearchMode()) AndAlso Post(PostType.FinalPosting) Then
            Dim key As Long = CLng(GetKey(HumanCase_DB.tlbHumanCase, "idfCase"))
            EidssSiteContext.ReportFactory.HumUrgentyNotificationTanzania(key)
        End If
    End Sub
#End Region

#Region "Business Rules"

    ' To allow clear values withot cycling calls
    Public StopBR As Boolean = False
    'Private m_LastDateError As MinMaxDate
    'Public Function MinMax_Err(ByVal minD As Date, ByVal maxD As Date, ByVal minDName As String, ByVal maxDName As String, ByVal allowBeEqual As Boolean,
    '                           ByVal showError As Boolean) As Boolean
    '    Dim res As Boolean = False
    '    If Not (minD = Nothing OrElse maxD = Nothing) Then
    '        Dim minMax As MinMaxDate = New MinMaxDate(minD, maxD, minDName, maxDName, allowBeEqual)
    '        If Not minMax.MinMaxOk Then
    '            If showError Then
    '                minMax.CheckMinMax()
    '            End If
    '            m_LastDateError = minMax
    '            res = True
    '        End If
    '    End If
    '    Return res
    'End Function

    Dim DiagEnabled As Boolean = True
    Dim ChangedDiagEnabled As Boolean = True

    Private Sub DisableDateEdits(ByVal sender As System.Object)
        If PatientInfo.dtpDOB.Enabled AndAlso dtReportingDate.Enabled AndAlso deOnsetDate.Enabled Then
            DiagEnabled = dtDiagnosisDate.Enabled
            ChangedDiagEnabled = dtChangedDiagnosisDate.Enabled
        End If
        If Not sender Is PatientInfo.dtpDOB Then PatientInfo.dtpDOB.Enabled = False
        If Not sender Is dtLastVisitToEmployer Then dtLastVisitToEmployer.Enabled = False
        If Not sender Is dtReportingDate Then dtReportingDate.Enabled = False
        If Not sender Is deOnsetDate Then deOnsetDate.Enabled = False
        If Not sender Is dtDiagnosisDate Then dtDiagnosisDate.Enabled = False
        If Not sender Is dtChangedDiagnosisDate Then dtChangedDiagnosisDate.Enabled = False
        If (TypeOf (sender) Is Control) Then
            Dim Tag As TagHelper = TagHelper.GetTagHelper(CType(sender, Control))
            If (Tag Is Nothing) OrElse (Tag.Tag Is Nothing) OrElse _
               (Not TypeOf Tag.Tag Is DevExpress.XtraEditors.Repository.RepositoryItemDateEdit) Then
                HumanCaseSamplesPanel1.CollectionDate.ReadOnly = True
                HumanCaseSamplesPanel1.SentDate.ReadOnly = True
            Else
                If (Not CType(Tag.Tag, DevExpress.XtraEditors.Repository.RepositoryItemDateEdit) Is _
                    HumanCaseSamplesPanel1.CollectionDate) Then _
                    HumanCaseSamplesPanel1.CollectionDate.ReadOnly = True
                If (Not CType(Tag.Tag, DevExpress.XtraEditors.Repository.RepositoryItemDateEdit) Is _
                    HumanCaseSamplesPanel1.SentDate) Then _
                    HumanCaseSamplesPanel1.SentDate.ReadOnly = True
            End If
        Else
            HumanCaseSamplesPanel1.CollectionDate.ReadOnly = True
            HumanCaseSamplesPanel1.SentDate.ReadOnly = True
        End If
    End Sub

    Private Sub EnableAllDateEdits()
        PatientInfo.dtpDOB.Enabled = True
        dtLastVisitToEmployer.Enabled = True
        dtReportingDate.Enabled = True
        deOnsetDate.Enabled = True
        dtDiagnosisDate.Enabled = DiagEnabled
        dtChangedDiagnosisDate.Enabled = ChangedDiagEnabled
        HumanCaseSamplesPanel1.CollectionDate.ReadOnly = False
        HumanCaseSamplesPanel1.SentDate.ReadOnly = Not IsSearchMode()
    End Sub

    Private m_CanSelectTab As Boolean = True
    Private m_ShowDateError As Boolean = True

    'Private Sub TabControl1_Selected(sender As Object, e As DevExpress.XtraTab.TabPageEventArgs) Handles TabControl1.Selected
    '    If e.Page.Equals(tpSamples) Then
    '        HumanCaseSamplesPanel1.MergeTestTable(CaseTestsPanel1.baseDataSet.Tables(CaseTestsDetail_Db.TableTests))
    '    End If

    'End Sub
    Private Sub TabControl_Selecting(ByVal sender As Object, ByVal e As DevExpress.XtraTab.TabPageCancelEventArgs) Handles TabControl1.Selecting, tcCaseInvestigation.Selecting
        If WinUtils.IsComponentInDesignMode(Me) Then
            Return
        End If
        If (Not m_CanSelectTab) Then
            m_ShowDateError = False
        Else
            m_ShowDateError = True
        End If
        'If m_CanSelectTab AndAlso (Not IsBRCheking) AndAlso _
        '   (e.Action = TabControlAction.Deselecting) AndAlso _
        '   (((e.Page.Equals(tpCaseInvestigation)) AndAlso (tcCaseInvestigation.SelectedTabPage.Equals(tpSamples))) OrElse _
        '    (e.Page.Equals(tpSamples))) Then
        '    Check_BR()
        'End If
        e.Cancel = Not m_CanSelectTab
    End Sub

    Private Sub TabControl_Deselecting(ByVal sender As Object, ByVal e As DevExpress.XtraTab.TabPageCancelEventArgs) Handles TabControl1.Deselecting, tcCaseInvestigation.Deselecting
        If WinUtils.IsComponentInDesignMode(Me) Then
            Return
        End If
        'If Not m_CanSelectTab AndAlso Not m_LastDateError Is Nothing Then
        '    m_LastDateError.CheckMinMax()
        '    Return
        'End If
        If m_CanSelectTab AndAlso (Not IsBRCheking) AndAlso _
           (((e.Page.Equals(tpCaseInvestigation)) AndAlso (tcCaseInvestigation.SelectedTabPage.Equals(tpSamples))) OrElse _
            (e.Page.Equals(tpSamples))) Then
            e.Cancel = (Not HumanCaseSamplesPanel1.ValidateSamplesData(True)) ' OrElse (Not Check_BR())
        End If
        If m_CanSelectTab AndAlso (tcCaseInvestigation.SelectedTabPage.Equals(tpContactsRemarks)) Then
            e.Cancel = (Not ContactPeopleValidate())
        End If

        'e.Cancel = Not CanSelectTab
    End Sub

    Dim IsBRCheking As Boolean = False
    'Public Function Check_BR(ByVal sender As System.Object, Optional ByVal isGlobalAction As Boolean = False, Optional showError As Boolean = True) As Boolean
    '    Return True 'lower is an old code
    '    SyncLock (Me)
    '        Dim OkToCancel As Boolean = False
    '        If Not m_DataLoaded OrElse [ReadOnly] Then
    '            Return True
    '        End If
    '        Dim IsDateFromSamplePanel As Boolean = False
    '        If (Not StopBR) AndAlso (Not IsBRCheking) AndAlso (Not isGlobalAction) Then
    '            m_LastDateError = Nothing
    '            IsBRCheking = True
    '            'DisableDateEdits(sender)
    '            Dim DOB As Date = Nothing
    '            If Not Utils.IsEmpty(PatientInfo.dtpDOB.EditValue) Then DOB = PatientInfo.dtpDOB.DateTime.Date
    '            Dim StartD As Date = Nothing
    '            If Not Utils.IsEmpty(dtStartDate.EditValue) Then StartD = dtStartDate.DateTime.Date
    '            Dim RepD As Date = Nothing
    '            If Not Utils.IsEmpty(dtReportingDate.EditValue) Then RepD = dtReportingDate.DateTime.Date
    '            Dim DisD As Date = Nothing
    '            If Not Utils.IsEmpty(deOnsetDate.EditValue) Then DisD = deOnsetDate.DateTime.Date
    '            Dim EmpD As Date = Nothing
    '            If Not Utils.IsEmpty(dtLastVisitToEmployer.EditValue) Then EmpD = dtLastVisitToEmployer.DateTime.Date
    '            Dim FormCompletionDate As Date = Nothing
    '            If Not Utils.IsEmpty(dtFormCompletionDate.EditValue) Then FormCompletionDate = dtFormCompletionDate.DateTime.Date
    '            Dim PatientFirstSoughtDate As Date = Nothing
    '            If Not Utils.IsEmpty(deDatePatientFirstSought.EditValue) Then PatientFirstSoughtDate = deDatePatientFirstSought.DateTime.Date

    '            'InitDiagD
    '            'FinalDiagD
    '            Dim CurD As Date = Date.Today
    '            Dim InitDiagD As Date = Nothing
    '            If Not Utils.IsEmpty(dtDiagnosisDate.EditValue) Then InitDiagD = dtDiagnosisDate.DateTime.Date
    '            Dim FinalDiagD As Date = Nothing
    '            If Not Utils.IsEmpty(dtChangedDiagnosisDate.EditValue) Then FinalDiagD = dtChangedDiagnosisDate.DateTime.Date

    '            'Sample Collection Date
    '            'Sample Sent Date
    '            'Sample Accession Date
    '            Dim ColD As Date = Nothing
    '            Dim SSD As Date = Nothing
    '            Dim LabD As Date = Nothing
    '            If (TypeOf (sender) Is DevExpress.XtraEditors.DateEdit) Then
    '                Dim DateCtrl As DevExpress.XtraEditors.DateEdit = CType(sender, DevExpress.XtraEditors.DateEdit)
    '                Dim Tag As TagHelper = TagHelper.GetTagHelper(DateCtrl)
    '                If (Not Tag Is Nothing) AndAlso (Not Tag.Tag Is Nothing) AndAlso _
    '                   (TypeOf Tag.Tag Is DevExpress.XtraEditors.Repository.RepositoryItemDateEdit) Then
    '                    Dim DateRepository As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit = _
    '                    CType(Tag.Tag, DevExpress.XtraEditors.Repository.RepositoryItemDateEdit)
    '                    If Not Utils.IsEmpty(DateCtrl.EditValue) Then
    '                        If DateRepository Is HumanCaseSamplesPanel1.CollectionDate Then
    '                            ColD = DateCtrl.DateTime.Date
    '                            IsDateFromSamplePanel = True
    '                        ElseIf DateRepository Is HumanCaseSamplesPanel1.SentDate Then
    '                            SSD = DateCtrl.DateTime.Date
    '                            IsDateFromSamplePanel = True
    '                        End If
    '                    End If
    '                End If
    '            Else
    '                Dim minColectionDate As DateTime?
    '                'TODO: /*Search Mode*/ Remove or change condition after sample panel is implemented in search mode
    '                If (Not IsSearchMode()) Then
    '                    minColectionDate = _
    '                     (From sample In Me.HumanCaseSamplesPanel1.baseDataSet.Tables(CaseSamples_Db.TableSamples) _
    '                            Where sample.RowState <> DataRowState.Deleted AndAlso sample.RowState <> DataRowState.Detached _
    '                            AndAlso Not (sample.Field(Of Nullable(Of DateTime))("datFieldCollectionDate") Is Nothing)
    '                        Select sample.Field(Of DateTime?)("datFieldCollectionDate")).Min
    '                Else
    '                    minColectionDate = Nothing
    '                End If

    '                If minColectionDate.HasValue Then
    '                    ColD = minColectionDate.Value
    '                End If

    '                Dim minSentDate As DateTime?
    '                'TODO: /*Search Mode*/ Remove or change condition after sample panel is implemented in search mode
    '                If (Not IsSearchMode()) Then
    '                    minSentDate = _
    '                     (From sample In Me.HumanCaseSamplesPanel1.baseDataSet.Tables(CaseSamples_Db.TableSamples) _
    '                            Where sample.RowState <> DataRowState.Deleted AndAlso sample.RowState <> DataRowState.Detached _
    '                            AndAlso Not (sample.Field(Of Nullable(Of DateTime))("datFieldSentDate") Is Nothing)
    '                        Select sample.Field(Of DateTime?)("datFieldSentDate")).Min
    '                Else
    '                    minSentDate = Nothing
    '                End If

    '                If minSentDate.HasValue Then
    '                    SSD = minSentDate.Value
    '                End If

    '            End If
    '            If m_ShowDateError = False Then
    '                showError = False
    '            End If
    '            OkToCancel = MinMax_Err(DOB, CurD, "Date of Birth", "Current date", True, showError)
    '            If Not OkToCancel Then OkToCancel = MinMax_Err(DOB, RepD, "Date of Birth", "Notification date", True, showError)
    '            If Not OkToCancel Then OkToCancel = MinMax_Err(DOB, DisD, "Date of Birth", "Date of symptoms onset", True, showError)
    '            If Not OkToCancel Then OkToCancel = MinMax_Err(DOB, InitDiagD, "Date of Birth", "Diagnosis date", True, showError)
    '            If Not OkToCancel Then OkToCancel = MinMax_Err(DOB, FinalDiagD, "Date of Birth", "Date of changed diagnosis", True, showError)
    '            If Not OkToCancel Then OkToCancel = MinMax_Err(DOB, StartD, "Date of Birth", "Date Entered", True, showError)
    '            If Not OkToCancel Then OkToCancel = MinMax_Err(DOB, ColD, "Date of Birth", "Sample Collection Date", True, showError)
    '            If Not OkToCancel Then OkToCancel = MinMax_Err(DOB, SSD, "Date of Birth", "Sample Sent Date", True, showError)
    '            If Not OkToCancel Then OkToCancel = MinMax_Err(DOB, LabD, "Date of Birth", "Sample Accession Date", True, showError)
    '            If Not OkToCancel Then OkToCancel = MinMax_Err(DOB, EmpD, "Date of Birth", "Date of last visit to employer, school, children's facility", False, showError)
    '            If Not OkToCancel Then OkToCancel = MinMax_Err(DOB, PatientFirstSoughtDate, "Date of Birth", "Date of patient first sought care", False, showError)

    '            'If Not OkToCancel Then OkToCancel = MinMax_Err(StartD, CurD, "Date Entered", "Current date", True, showError)
    '            If Not OkToCancel Then OkToCancel = MinMax_Err(RepD, StartD, "Notification date", "Date Entered", True, showError)
    '            If Not OkToCancel Then OkToCancel = MinMax_Err(DisD, StartD, "Date of symptoms onset", "Date Entered", True, showError)
    '            If Not OkToCancel Then OkToCancel = MinMax_Err(InitDiagD, StartD, "Diagnosis date", "Date Entered", True, showError)

    '            If Not OkToCancel Then OkToCancel = MinMax_Err(RepD, CurD, "Notification date", "Current date", True, showError)
    '            If Not OkToCancel Then OkToCancel = MinMax_Err(DisD, RepD, "Date of symptoms onset", "Notification date", True, showError)
    '            If Not OkToCancel Then OkToCancel = MinMax_Err(InitDiagD, RepD, "Diagnosis date", "Notification date", True, showError)
    '            If Not OkToCancel Then OkToCancel = MinMax_Err(FormCompletionDate, RepD, "Date of Completion of Paper form", "Notification date", True, showError)

    '            If Not OkToCancel Then OkToCancel = MinMax_Err(DisD, CurD, "Date of symptoms onset", "Current date", True, showError)
    '            If Not OkToCancel Then OkToCancel = MinMax_Err(DisD, InitDiagD, "Date of symptoms onset", "Diagnosis date", True, showError)
    '            If Not OkToCancel Then OkToCancel = MinMax_Err(DisD, FinalDiagD, "Date of symptoms onset", "Date of changed diagnosis", True, showError)
    '            If Not OkToCancel Then OkToCancel = MinMax_Err(DisD, ColD, "Date of symptoms onset", "Sample Collection Date", True, showError)
    '            If Not OkToCancel Then OkToCancel = MinMax_Err(DisD, SSD, "Date of symptoms onset", "Sample Sent Date", True, showError)
    '            If Not OkToCancel Then OkToCancel = MinMax_Err(DisD, LabD, "Date of symptoms onset", "Sample Accession Date", True, showError)

    '            If Not OkToCancel Then OkToCancel = MinMax_Err(InitDiagD, FinalDiagD, "Diagnosis date", "Date of changed diagnosis", True, showError)
    '            If Not OkToCancel Then OkToCancel = MinMax_Err(InitDiagD, ColD, "Diagnosis date", "Sample Collection Date", True, showError)
    '            If Not OkToCancel Then OkToCancel = MinMax_Err(InitDiagD, SSD, "Diagnosis date", "Sample Sent Date", True, showError)
    '            If Not OkToCancel Then OkToCancel = MinMax_Err(InitDiagD, LabD, "Diagnosis date", "Sample Accession Date", True, showError)
    '            If Not OkToCancel Then OkToCancel = MinMax_Err(InitDiagD, FormCompletionDate, "Diagnosis date", "Date of Completion of Paper form", True, showError)

    '            If (Not IsSearchMode()) AndAlso (Not OkToCancel) AndAlso _
    '               (Not OkToCancel) AndAlso _
    '               (Not HumanCaseSamplesPanel1 Is Nothing) AndAlso _
    '               (Not HumanCaseSamplesPanel1.SamplesList Is Nothing) AndAlso _
    '               (Not HumanCaseSamplesPanel1.SamplesList.Table Is Nothing) AndAlso _
    '               (SamplesCount(HumanCaseSamplesPanel1.SamplesList.Table) > 0) Then
    '                Dim D As Date = Nothing
    '                Dim DName As String = Nothing
    '                If (sender Is dtDiagnosisDate) Then
    '                    D = InitDiagD
    '                    DName = "Diagnosis date"
    '                ElseIf (sender Is PatientInfo.dtpDOB) Then
    '                    D = DOB
    '                    DName = "Date of Birth"
    '                ElseIf (sender Is deOnsetDate) Then
    '                    D = DisD
    '                    DName = "Date of symptoms onset"
    '                End If
    '                If Not Utils.IsEmpty(DName) OrElse (sender Is Nothing) Then
    '                    Dim i As Integer = 0
    '                    While (Not OkToCancel) AndAlso i < HumanCaseSamplesPanel1.SamplesList.Count
    '                        Dim r As DataRowView = HumanCaseSamplesPanel1.SamplesList(i)
    '                        If (r.Row.RowState <> DataRowState.Deleted) Then
    '                            If (Not Utils.IsEmpty(r("datFieldCollectionDate"))) Then
    '                                ColD = CDate(r("datFieldCollectionDate"))
    '                            Else
    '                                ColD = Nothing
    '                            End If
    '                            If (Not Utils.IsEmpty(r("datFieldSentDate"))) Then
    '                                SSD = CDate(r("datFieldSentDate"))
    '                            Else
    '                                SSD = Nothing
    '                            End If
    '                            If (Not Utils.IsEmpty(r("datAccession"))) Then
    '                                LabD = CDate(r("datAccession"))
    '                            Else
    '                                LabD = Nothing
    '                            End If
    '                            If Not Utils.IsEmpty(DName) Then
    '                                OkToCancel = MinMax_Err(D, ColD, DName, "Sample Collection Date", True, showError)
    '                                If Not OkToCancel Then OkToCancel = MinMax_Err(D, SSD, DName, "Sample Sent Date", True, showError)
    '                                If Not OkToCancel Then OkToCancel = MinMax_Err(D, LabD, DName, "Sample Accession Date", True, showError)
    '                            ElseIf (sender Is Nothing) Then
    '                                If (Not OkToCancel) AndAlso (Not Utils.IsEmpty(InitDiagD)) Then _
    '                                    OkToCancel = MinMax_Err(InitDiagD, ColD, "Diagnosis date", "Sample Collection Date", True, showError)
    '                                If (Not OkToCancel) AndAlso (Not Utils.IsEmpty(DOB)) Then _
    '                                    OkToCancel = MinMax_Err(D, SSD, "Date of Birth", "Sample Sent Date", True, showError)
    '                                If (Not OkToCancel) AndAlso (Not Utils.IsEmpty(deOnsetDate)) Then _
    '                                    OkToCancel = MinMax_Err(D, LabD, "Date of symptoms onset", "Sample Accession Date", True, showError)
    '                            End If
    '                        End If
    '                        i = i + 1
    '                    End While
    '                End If
    '            End If
    '        End If

    '        m_ShowDateError = True
    '        If OkToCancel Then
    '            IsBRCheking = True
    '            m_CanSelectTab = False
    '            If TypeOf (sender) Is DevExpress.XtraEditors.DateEdit Then
    '                If IsDateFromSamplePanel Then
    '                    HumanCaseSamplesPanel1.SamplesView.GridControl.Select()
    '                    HumanCaseSamplesPanel1.SamplesView.ShowEditor()
    '                End If
    '                CType(sender, DevExpress.XtraEditors.DateEdit).Select()
    '            End If
    '            IsBRCheking = False
    '        Else
    '            m_CanSelectTab = True
    '            'DataEventManager.Flush()
    '            UpdateDOBandAge()
    '            'EnableAllDateEdits()
    '        End If
    '        IsBRCheking = False
    '        Return (Not OkToCancel)
    '    End SyncLock
    '    Return True
    'End Function

    'Public Function Check_BR() As Boolean
    '    Dim sender As Object = Me.m_LastFocusedControl
    '    Return Check_BR(sender, False)
    'End Function

    Public Sub Check_BR(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim IsGlobalAction As Boolean = False
        If (FormCloseButtonClicked() OrElse (Me.ActiveControl Is OkButton) OrElse (Me.ActiveControl Is SaveButton) OrElse _
            (Me.ActiveControl Is CancelButton) OrElse (Me.ActiveControl Is NewButton) OrElse _
            (Me.ActiveControl Is DeleteButton) OrElse (Me.ActiveControl Is btnSearch) OrElse _
            (Me.ActiveControl Is btnSearchHumanCase) OrElse (Me.ActiveControl Is btnClear) OrElse _
            (Me.ActiveControl Is bntNextCase) OrElse (Me.ActiveControl Is bntPreviousCase) OrElse _
            (Me.ActiveControl Is btnFirstCase) OrElse (Me.ActiveControl Is btnLastCase) OrElse _
            (Me.ActiveControl Is btnNewCase) OrElse (Me.ActiveControl Is btnNextCase1) OrElse _
            (Me.ActiveControl Is btnPrevCase1) OrElse (Me.ActiveControl Is btnFirstCase1) OrElse _
            (Me.ActiveControl Is btnLastCase1) OrElse (Me.ActiveControl Is btnNewCase1)) AndAlso _
           (TypeOf (sender) Is DevExpress.XtraEditors.DateEdit) Then
            Me.m_LastFocusedControl = CType(sender, DevExpress.XtraEditors.DateEdit)
            m_LastFocusedControl.Focus()
            IsGlobalAction = True
        Else
            Me.m_LastFocusedControl = Nothing
        End If
        'Check_BR(sender, IsGlobalAction)
    End Sub

#End Region

#Region "Navigator"

    Private m_ShowNavigators As Boolean = True
    Public Property ShowNavigators() As Boolean
        Get
            Return m_ShowNavigators
        End Get
        Set(ByVal value As Boolean)
            If m_ShowNavigators <> value Then
                m_ShowNavigators = value
                InitNavigator1()
            End If
        End Set
    End Property

    Private m_NavigatorReadOnlyMode As Boolean = False
    Public Property NavigatorReadOnlyMode() As Boolean
        Get
            Return m_NavigatorReadOnlyMode
        End Get
        Set(ByVal value As Boolean)
            m_NavigatorReadOnlyMode = value
        End Set
    End Property

    Private m_ParentHumanCaseList As List(Of HumanCaseListItem) = Nothing
    <CLSCompliant(False)> _
    Public Property ParentHumanCaseList() As List(Of HumanCaseListItem)
        Get
            Return m_ParentHumanCaseList
        End Get
        Set(value As List(Of HumanCaseListItem))
            m_ParentHumanCaseList = value
        End Set
    End Property

    '-------------------------- Navigator -------------------------------------'

    Private Sub EnableNavigator()
        If m_ShowNavigators Then
            If (txtCaseNumber1.Visible) AndAlso _showNavigator1 Then
                If btnNewCase1.Visible Then
                    btnNewCase1.Tag = ""
                    ApplyStyle(btnNewCase1, True)
                    btnNewCase1.Enabled = True
                End If
                btnFirstCase1.Tag = ""
                ApplyStyle(btnFirstCase1, True)
                btnFirstCase1.Enabled = True
                btnPrevCase1.Tag = ""
                ApplyStyle(btnPrevCase1, True)
                btnPrevCase1.Enabled = True
                txtCaseNumber1.Tag = ""
                ApplyStyle(txtCaseNumber1, True)
                txtCaseNumber1.Enabled = True
                btnNextCase1.Tag = ""
                ApplyStyle(btnNextCase1, True)
                btnNextCase1.Enabled = True
                btnLastCase1.Tag = ""
                ApplyStyle(btnLastCase1, True)
                btnLastCase1.Enabled = True

                Dim caseCount As Integer = 0
                '--Version 3--If Not dtHumanCase Is Nothing Then CaseCount = dtHumanCase.Rows.Count
                If Not m_ParentHumanCaseList Is Nothing Then caseCount = m_ParentHumanCaseList.Count
                If _curCaseNumber1 <= 1 Then
                    btnFirstCase1.Enabled = False
                    btnPrevCase1.Enabled = False
                End If
                If _curCaseNumber1 >= caseCount Then
                    btnLastCase1.Enabled = False
                    btnNextCase1.Enabled = False
                End If
            Else
                If btnNewCase.Visible Then
                    btnNewCase.Tag = ""
                    ApplyStyle(btnNewCase, True)
                    btnNewCase.Enabled = True
                End If
                btnFirstCase.Tag = ""
                ApplyStyle(btnFirstCase, True)
                btnFirstCase.Enabled = True
                bntPreviousCase.Tag = ""
                ApplyStyle(bntPreviousCase, True)
                bntPreviousCase.Enabled = True
                txtCaseNumber.Tag = ""
                ApplyStyle(txtCaseNumber, True)
                txtCaseNumber.Enabled = True
                bntNextCase.Tag = ""
                ApplyStyle(bntNextCase, True)
                bntNextCase.Enabled = True
                btnLastCase.Tag = ""
                ApplyStyle(btnLastCase, True)
                btnLastCase.Enabled = True

                Dim caseCount As Integer = 0
                If Utils.IsEmpty(txtCaseCount.Text) OrElse (Not Integer.TryParse(txtCaseCount.Text.Substring(0, txtCaseCount.Text.IndexOf(" (")).Replace("/", ""), caseCount)) Then
                    caseCount = 0
                End If
                Dim curNumber As Integer = 0
                If Utils.IsEmpty(txtCaseNumber.Text) OrElse (Not Integer.TryParse(txtCaseNumber.Text, curNumber)) Then
                    curNumber = 0
                End If
                If curNumber <= 1 Then
                    btnFirstCase.Enabled = False
                    bntPreviousCase.Enabled = False
                End If
                If curNumber >= caseCount Then
                    btnLastCase.Enabled = False
                    bntNextCase.Enabled = False
                End If
            End If
        End If
    End Sub

    Private Sub InitNavigator()
        If IsSearchMode() OrElse (Not m_ShowNavigators) Then
            btnNewCase.Visible = False
            btnFirstCase.Visible = False
            bntPreviousCase.Visible = False
            txtCaseNumber.Visible = False
            txtCaseCount.Visible = False
            bntNextCase.Visible = False
            btnLastCase.Visible = False
            Return
        End If
        btnNewCase.Visible = True
        btnFirstCase.Enabled = True
        bntPreviousCase.Enabled = True
        bntNextCase.Enabled = True
        btnLastCase.Enabled = True
        If eidss.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission(eidss.model.Enums.EIDSSPermissionObject.HumanCase)) Then
            btnNewCase.Visible = True
        Else
            btnNewCase.Visible = False
            btnNewCase1.Visible = False
        End If
        If (Not eidss.model.Core.EidssSiteContext.Instance.SiteID.Equals(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsSite"))) OrElse (txtCaseNumber1.Visible) Then
            btnFirstCase.Visible = False
            bntPreviousCase.Visible = False
            txtCaseNumber.Visible = False
            txtCaseCount.Visible = False
            bntNextCase.Visible = False
            btnLastCase.Visible = False
        Else
            btnFirstCase.Visible = True
            bntPreviousCase.Visible = True
            txtCaseNumber.Visible = True
            txtCaseCount.Visible = True
            bntNextCase.Visible = True
            btnLastCase.Visible = True
            Dim caseCount As Integer = HumanCase_DB.GetHumanCaseCount(HumanCaseDbService.Connection)
            Dim caseNumber As Integer = HumanCase_DB.GetHumanCaseNumber(GetKey(HumanCase_DB.tlbHumanCase, "idfCase"))
            If caseNumber <= 1 Then
                btnFirstCase.Enabled = False
                bntPreviousCase.Enabled = False
            End If
            If caseNumber >= caseCount Then
                btnLastCase.Enabled = False
                bntNextCase.Enabled = False
            End If
            _okChangeCaseNum = False
            _curCaseNum = caseNumber
            txtCaseNumber.Text = caseNumber.ToString
            _okChangeCaseNum = True
            txtCaseCount.Text = "/ " + caseCount.ToString + " (" + EidssMessages.Get("CurSiteRecords", "current site records") + ")"
        End If
    End Sub

    Dim _curCaseNum As Integer = 0

    Private Sub txtCaseNumber_EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles txtCaseNumber.EditValueChanging
        If _okChangeCaseNum Then
            If Not Utils.IsEmpty(e.NewValue) Then
                Dim okToCancel As Boolean = False
                Dim caseCount As Integer = HumanCase_DB.GetHumanCaseCount(HumanCaseDbService.Connection)
                Dim newVal As Integer
                If (Not Integer.TryParse(Utils.Str(e.NewValue), newVal)) Then
                    okToCancel = True
                End If
                If Not okToCancel Then
                    If newVal > caseCount OrElse newVal < 0 Then okToCancel = True
                    If (newVal = 0) AndAlso _
                       (Not eidss.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission(eidss.model.Enums.EIDSSPermissionObject.HumanCase))) Then
                        okToCancel = True
                    End If
                End If
                e.Cancel = okToCancel
            End If
        End If
    End Sub

    Private Sub LoadCaseByNavigatorNumber()
        If _okChangeCaseNum AndAlso Not Utils.IsEmpty(txtCaseNumber.Text) Then
            Dim caseNumber As Integer = Convert.ToInt32(txtCaseNumber.Text)

            Dim strResult As String = ""
            Dim idResult As Object = Nothing
            If (caseNumber = 0) Then
                idResult = Nothing
            Else
                idResult = HumanCase_DB.GetHumanCaseIDByNumber(caseNumber, HumanCaseDbService.Connection)
                strResult = Utils.Str(idResult)
            End If

            If (strResult <> Utils.Str(GetKey(HumanCase_DB.tlbHumanCase, "idfCase"))) AndAlso (Post(PostType.FinalPosting)) Then
                Me.Enabled = False
                m_NavigatorReadOnlyMode = False
                If caseNumber > 0 Then
                    If (Not BaseFormManager.FindFormByID(GetType(HumanCaseDetail), idResult) Is Nothing) Then
                        m_NavigatorReadOnlyMode = True
                    End If
                    LoadData(idResult)
                ElseIf caseNumber = 0 Then
                    LoadData(Nothing)
                End If
                'DefineBinding()
                Me.ReadOnly = m_NavigatorReadOnlyMode Or IsCaseClosed
                Me.Enabled = True
            Else
                SelectLastFocusedControl()
            End If
        End If
    End Sub

    'Private Sub txtCaseNumber_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCaseNumber.KeyDown
    '    If e.KeyValue = Keys.Enter Then
    '        LoadCaseByNavigatorNumber()
    '    End If
    'End Sub

    Private _mBSkipLoadCaseNavigator As Boolean

    Private Sub txtCaseNumber_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCaseNumber.Leave
        If Not _mBSkipLoadCaseNavigator Then
            LoadCaseByNavigatorNumber()
        End If
    End Sub

    Private Sub btnNewCase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewCase.Click
        If LockHandler() Then
            Try
                Me.Enabled = False
                If Post() Then
                    If Permissions.CanInsert Then
                        OkToUpdateDOBAndAge = False
                        State = BusinessObjectState.NewObject Or BusinessObjectState.IntermediateObject
                        [ReadOnly] = False
                        LoadData(Nothing)
                        m_NavigatorReadOnlyMode = False
                        OkToUpdateDOBAndAge = True
                    End If
                Else
                    SelectLastFocusedControl()
                End If
            Catch ex As Exception
                Throw
            Finally
                Me.Enabled = True
                UnlockHandler()
            End Try
        End If

    End Sub

    Private Sub btnFirstCase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirstCase.Click
        Dim strResult As String = ""
        Dim idResult As Object = Nothing

        idResult = HumanCase_DB.GetFirstHumanCase(HumanCaseDbService.Connection)
        If Not Utils.IsEmpty(idResult) Then
            strResult = Utils.Str(idResult)
        End If

        If (strResult <> Utils.Str(GetKey(HumanCase_DB.tlbHumanCase, "idfCase"))) AndAlso (Post(PostType.FinalPosting)) Then
            Me.Enabled = False
            m_NavigatorReadOnlyMode = False
            If (Not BaseFormManager.FindFormByID(GetType(HumanCaseDetail), idResult) Is Nothing) Then
                m_NavigatorReadOnlyMode = True
            End If
            LoadData(idResult)
            'DefineBinding()
            Me.ReadOnly = m_NavigatorReadOnlyMode Or IsCaseClosed
            Me.Enabled = True
        Else
            SelectLastFocusedControl()
        End If
    End Sub

    Private Sub btnLastCase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLastCase.Click
        Dim strResult As String = ""
        Dim idResult As Object = Nothing

        idResult = HumanCase_DB.GetLastHumanCase(HumanCaseDbService.Connection)
        If Not Utils.IsEmpty(idResult) Then
            strResult = Utils.Str(idResult)
        End If

        If (strResult <> Utils.Str(GetKey(HumanCase_DB.tlbHumanCase, "idfCase"))) AndAlso (Post(bv.common.Enums.PostType.FinalPosting)) Then
            Me.Enabled = False
            m_NavigatorReadOnlyMode = False
            If (Not BaseFormManager.FindFormByID(GetType(HumanCaseDetail), idResult) Is Nothing) Then
                m_NavigatorReadOnlyMode = True
            End If
            LoadData(idResult)
            'DefineBinding()
            Me.ReadOnly = m_NavigatorReadOnlyMode Or IsCaseClosed
            Me.Enabled = True
        Else
            SelectLastFocusedControl()
        End If
    End Sub

    Private Sub bntPreviousCase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntPreviousCase.Click
        Dim strResult As String = ""
        Dim idResult As Object = Nothing

        idResult = HumanCase_DB.GetPrevHumanCaseID(GetKey(HumanCase_DB.tlbHumanCase, "idfCase"), HumanCaseDbService.Connection)
        If Not Utils.IsEmpty(idResult) Then
            strResult = Utils.Str(idResult)
        End If

        If (strResult <> Utils.Str(GetKey(HumanCase_DB.tlbHumanCase, "idfCase"))) AndAlso (Post(PostType.FinalPosting)) Then
            Me.Enabled = False
            m_NavigatorReadOnlyMode = False
            If (Not BaseFormManager.FindFormByID(GetType(HumanCaseDetail), idResult) Is Nothing) Then
                m_NavigatorReadOnlyMode = True
            End If
            LoadData(idResult)
            'DefineBinding()
            Me.ReadOnly = m_NavigatorReadOnlyMode Or IsCaseClosed
            Me.Enabled = True
        Else
            SelectLastFocusedControl()
        End If
    End Sub


    Private Sub bntNextCase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntNextCase.Click
        Dim strResult As String = ""
        Dim idResult As Object = Nothing

        If (Utils.Str(txtCaseNumber.Text) = "0") Then
            idResult = HumanCase_DB.GetFirstHumanCase(HumanCaseDbService.Connection)
        Else
            idResult = HumanCase_DB.GetNextHumanCaseID(GetKey(HumanCase_DB.tlbHumanCase, "idfCase"), HumanCaseDbService.Connection)
        End If
        If Not Utils.IsEmpty(idResult) Then
            strResult = Utils.Str(idResult)
        End If

        If (strResult <> Utils.Str(GetKey(HumanCase_DB.tlbHumanCase, "idfCase"))) AndAlso (Post(PostType.FinalPosting)) Then
            Me.Enabled = False
            m_NavigatorReadOnlyMode = False
            If (Not BaseFormManager.FindFormByID(GetType(HumanCaseDetail), idResult) Is Nothing) Then
                m_NavigatorReadOnlyMode = True
            End If
            LoadData(idResult)
            'DefineBinding()
            Me.ReadOnly = m_NavigatorReadOnlyMode Or IsCaseClosed
            Me.Enabled = True
        Else
            SelectLastFocusedControl()
        End If
    End Sub

    '-------------------------- Navigator1 -------------------------------------'

    Dim _showNavigator1 As Boolean = True
    '--Version 3--Dim dtHumanCase As DataTable
    Dim _curCaseNumber1 As Integer

    Private Sub InitNavigator1()
        If (BaseSettings.ShowNavigatorInH02Form = False) Then
            btnNewCase1.Visible = False
            btnFirstCase1.Visible = False
            btnPrevCase1.Visible = False
            txtCaseNumber1.Visible = False
            txtCaseCount1.Visible = False
            btnNextCase1.Visible = False
            btnLastCase1.Visible = False
            btnNewCase.Visible = False
            btnFirstCase.Visible = False
            bntPreviousCase.Visible = False
            txtCaseNumber.Visible = False
            txtCaseCount.Visible = False
            bntNextCase.Visible = False
            btnLastCase.Visible = False
            Return
        End If
        If Not IsSearchMode() Then
            btnFirstCase1.Enabled = True
            btnPrevCase1.Enabled = True
            btnNextCase1.Enabled = True
            btnLastCase1.Enabled = True
            If eidss.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission(eidss.model.Enums.EIDSSPermissionObject.HumanCase)) Then
                btnNewCase1.Visible = True
            Else
                btnNewCase1.Visible = False
                btnNewCase.Visible = False
            End If
        End If
        If _showNavigator1 AndAlso _
           (IsSearchMode() OrElse (Not m_ShowNavigators) OrElse _
            ((BaseSettings.ShowRecordsFromCurrentSiteForNewCase = True) AndAlso _
             (Not HumanCaseDbService Is Nothing) AndAlso HumanCaseDbService.IsNewObject)) _
        Then _showNavigator1 = False
        '--Version 3--Dim ParentListForm As BasePagedListForm = Nothing
        'If (Not Me.ParentBaseForm Is Nothing) AndAlso _
        '   (Not Me.ParentBaseForm.IsDisposed) AndAlso _
        '   (TypeOf (Me.ParentBaseForm) Is BasePagedListForm) AndAlso _
        '   (Me.ParentBaseForm.Name = "HumanCaseList") Then
        'ParentListForm = CType(Me.ParentBaseForm, BasePagedListForm)
        'ElseIf (Me.ParentBaseForm Is Nothing) AndAlso _
        '       (Not m_CurrentForm Is Nothing) AndAlso _
        '       (Not m_CurrentForm.IsDisposed) AndAlso _
        '       (TypeOf (m_CurrentForm) Is BasePagedListForm) AndAlso _
        '       (m_CurrentForm.Name = "HumanCaseList") Then
        'ParentListForm = CType(m_CurrentForm, BasePagedListForm)
        'End If
        If _showNavigator1 AndAlso (Not m_ParentHumanCaseList Is Nothing) Then
            '   ((Not ParentListForm Is Nothing) OrElse _
            '    ((Not Me.StartUpParameters Is Nothing) AndAlso _
            '     (Me.StartUpParameters.ContainsKey("FromCond")) AndAlso _
            '     (Me.StartUpParameters.ContainsKey("FilterCond")))) Then

            'Dim FilterCond As String = ""
            'Dim FromCond As String = ""
            'Dim SortCond As String = ""
            'If (Not Me.StartUpParameters Is Nothing) AndAlso _
            ' (Me.StartUpParameters.ContainsKey("FromCond")) AndAlso _
            ' (Me.StartUpParameters.ContainsKey("FilterCond")) Then
            '    FilterCond = Utils.Str(Me.StartUpParameters("FilterCond"))
            '    FromCond = Utils.Str(Me.StartUpParameters("FromCond"))
            '    SortCond = "fn_" + HumanCaseDbService.ObjectName + "_SelectList.strCaseID "
            '    dtHumanCase = HumanCaseDbService.GetList(FilterCond, FromCond, SortCond, True).Tables(0)
            'Else
            '    FilterCond = ParentListForm.PagedGrid.FilterCondition
            '    FromCond = ParentListForm.PagedGrid.FromCondition
            '    SortCond = ParentListForm.PagedGrid.SortCondition
            '    dtHumanCase = ParentListForm.DbService.GetList(FilterCond, FromCond, SortCond, True).Tables(0)
            'End If



            btnFirstCase.Visible = False
            bntPreviousCase.Visible = False
            txtCaseNumber.Visible = False
            txtCaseCount.Visible = False
            bntNextCase.Visible = False
            btnLastCase.Visible = False

            btnFirstCase1.Visible = True
            btnPrevCase1.Visible = True
            txtCaseNumber1.Visible = True
            txtCaseCount1.Visible = True
            btnNextCase1.Visible = True
            btnLastCase1.Visible = True

            Dim caseCount As Integer = m_ParentHumanCaseList.Count    '--Version 3--dtHumanCase.Rows.Count
            _curCaseNumber1 = 0
            Dim item As HumanCaseListItem = Nothing

            While _curCaseNumber1 < caseCount AndAlso _
                (Utils.Str(m_ParentHumanCaseList.Item(_curCaseNumber1).idfCase) <> Utils.Str(GetKey(HumanCase_DB.tlbHumanCase, "idfCase")))
                '--Version 3--dtHumanCase.Rows(_curCaseNumber1)(0).ToString <> Utils.Str(GetKey(HumanCase_DB.tlbHumanCase, "idfCase"))
                _curCaseNumber1 = _curCaseNumber1 + 1
            End While
            If _curCaseNumber1 < caseCount Then
                _curCaseNumber1 = _curCaseNumber1 + 1
            Else
                _curCaseNumber1 = 0
            End If

            If _curCaseNumber1 <= 1 Then
                btnFirstCase1.Enabled = False
                btnPrevCase1.Enabled = False
            End If
            If _curCaseNumber1 >= caseCount Then
                btnLastCase1.Enabled = False
                btnNextCase1.Enabled = False
            End If
            _okChangeCaseNum = False
            txtCaseNumber1.Text = _curCaseNumber1.ToString
            _okChangeCaseNum = True
            txtCaseCount1.Text = "/ " + caseCount.ToString + " (" + EidssMessages.Get("SearchResRecords", "search results") + ")"
        Else
            btnNewCase1.Visible = False
            btnFirstCase1.Visible = False
            btnPrevCase1.Visible = False
            txtCaseNumber1.Visible = False
            txtCaseCount1.Visible = False
            btnNextCase1.Visible = False
            btnLastCase1.Visible = False
            InitNavigator()
        End If
    End Sub

    Private Sub txtCaseNumber1_EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles txtCaseNumber1.EditValueChanging
        If _okChangeCaseNum Then
            If Not Utils.IsEmpty(e.NewValue) Then
                Dim okToCancel As Boolean = False
                Dim caseCount As Integer = 0 '--Version 3--dtHumanCase.Rows.Count
                If (Not m_ParentHumanCaseList Is Nothing) Then caseCount = m_ParentHumanCaseList.Count
                Dim newVal As Integer
                If (Not Integer.TryParse(Utils.Str(e.NewValue), newVal)) Then
                    okToCancel = True
                End If
                If Not okToCancel Then
                    If newVal > caseCount OrElse newVal < 0 Then okToCancel = True
                    If (newVal = 0) AndAlso _
                       (Not eidss.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission(eidss.model.Enums.EIDSSPermissionObject.HumanCase))) Then
                        okToCancel = True
                    End If
                End If
                e.Cancel = okToCancel
            End If
        End If
    End Sub

    Private Sub LoadCaseByNavigatorNumber1()
        If _okChangeCaseNum AndAlso Not Utils.IsEmpty(txtCaseNumber1.Text) Then
            Dim caseNumber As Integer = Convert.ToInt32(txtCaseNumber1.Text)
            Dim strResult As String = ""
            Dim idResult As Object

            If (caseNumber = 0) OrElse (m_ParentHumanCaseList Is Nothing) OrElse _
               (m_ParentHumanCaseList.Count < caseNumber) OrElse (m_ParentHumanCaseList.Count = 0) Then
                idResult = Nothing
            Else
                idResult = m_ParentHumanCaseList.Item(caseNumber - 1).idfCase '--Version 3--dtHumanCase.Rows(caseNumber - 1)(0)
                strResult = Utils.Str(idResult)
            End If
            If (strResult <> Utils.Str(GetKey(HumanCase_DB.tlbHumanCase, "idfCase"))) AndAlso (Post(PostType.FinalPosting)) Then
                Me.Enabled = False
                m_NavigatorReadOnlyMode = False
                If caseNumber > 0 Then
                    If (Not BaseFormManager.FindFormByID(GetType(HumanCaseDetail), idResult) Is Nothing) Then
                        m_NavigatorReadOnlyMode = True
                    End If
                    LoadData(idResult)
                ElseIf caseNumber = 0 Then
                    LoadData(Nothing)
                End If
                'DefineBinding()
                Me.ReadOnly = m_NavigatorReadOnlyMode Or IsCaseClosed
                Me.Enabled = True
            Else
                SelectLastFocusedControl()
            End If
        End If
    End Sub

    Private Sub txtCaseNumber1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCaseNumber1.KeyDown
        If e.KeyValue = Keys.Enter Then
            If Not _mBSkipLoadCaseNavigator Then
                LoadCaseByNavigatorNumber1()
            End If
        End If
    End Sub

    Private Sub txtCaseCount1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCaseCount1.Leave
        If Not _mBSkipLoadCaseNavigator Then
            LoadCaseByNavigatorNumber1()
        End If
    End Sub


    Private Sub btnFirstCase1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirstCase1.Click
        Dim strResult As String = ""
        Dim idResult As Object = Nothing
        If (Not m_ParentHumanCaseList Is Nothing) AndAlso (m_ParentHumanCaseList.Count > 0) Then
            idResult = m_ParentHumanCaseList.Item(0).idfCase '--Version 3--dtHumanCase.Rows(0)(0)
        End If
        strResult = Utils.Str(idResult)
        If (strResult <> Utils.Str(GetKey(HumanCase_DB.tlbHumanCase, "idfCase"))) AndAlso (Post(PostType.FinalPosting)) Then
            Me.Enabled = False
            m_NavigatorReadOnlyMode = False
            If (Not BaseFormManager.FindFormByID(GetType(HumanCaseDetail), idResult) Is Nothing) Then
                m_NavigatorReadOnlyMode = True
            End If
            LoadData(idResult)
            'DefineBinding()
            Me.ReadOnly = m_NavigatorReadOnlyMode Or IsCaseClosed
            Me.Enabled = True
        Else
            SelectLastFocusedControl()
        End If
    End Sub

    Private Sub btnLastCase1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLastCase1.Click
        Dim strResult As String = ""
        Dim idResult As Object = Nothing

        If (Not m_ParentHumanCaseList Is Nothing) AndAlso (m_ParentHumanCaseList.Count > 0) Then
            idResult = m_ParentHumanCaseList.Item(m_ParentHumanCaseList.Count - 1).idfCase '--Version 3--dtHumanCase.Rows(dtHumanCase.Rows.Count - 1)(0)
        End If
        strResult = Utils.Str(idResult)
        If (strResult <> Utils.Str(GetKey(HumanCase_DB.tlbHumanCase, "idfCase"))) AndAlso (Post(PostType.FinalPosting)) Then
            Me.Enabled = False
            m_NavigatorReadOnlyMode = False
            If (Not BaseFormManager.FindFormByID(GetType(HumanCaseDetail), idResult) Is Nothing) Then
                m_NavigatorReadOnlyMode = True
            End If
            LoadData(idResult)
            'DefineBinding()
            Me.ReadOnly = m_NavigatorReadOnlyMode Or IsCaseClosed
            Me.Enabled = True
        Else
            SelectLastFocusedControl()
        End If
    End Sub

    Private Sub btnPrevCase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevCase1.Click
        Dim strResult As String = ""
        Dim idResult As Object = Nothing

        If (_curCaseNumber1 > 1) AndAlso (Not m_ParentHumanCaseList Is Nothing) AndAlso (m_ParentHumanCaseList.Count > _curCaseNumber1 - 1) Then
            idResult = m_ParentHumanCaseList.Item(_curCaseNumber1 - 2).idfCase '--Version 3--dtHumanCase.Rows(_curCaseNumber1 - 2)(0)
        End If
        strResult = Utils.Str(idResult)
        If (strResult <> Utils.Str(GetKey(HumanCase_DB.tlbHumanCase, "idfCase"))) AndAlso (Post(PostType.FinalPosting)) Then
            Me.Enabled = False
            m_NavigatorReadOnlyMode = False
            If (Not BaseFormManager.FindFormByID(GetType(HumanCaseDetail), idResult) Is Nothing) Then
                m_NavigatorReadOnlyMode = True
            End If
            LoadData(idResult)
            'DefineBinding()
            Me.ReadOnly = m_NavigatorReadOnlyMode Or IsCaseClosed
            Me.Enabled = True
        Else
            SelectLastFocusedControl()
        End If
    End Sub


    Private Sub btnNextCase1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextCase1.Click
        Dim strResult As String = ""
        Dim idResult As Object = Nothing

        If (_curCaseNumber1 >= 0) AndAlso (Not m_ParentHumanCaseList Is Nothing) AndAlso (m_ParentHumanCaseList.Count > _curCaseNumber1 + 1) Then
            idResult = m_ParentHumanCaseList.Item(_curCaseNumber1).idfCase '--Version 3--dtHumanCase.Rows(_curCaseNumber1)(0)
        End If
        strResult = Utils.Str(idResult)
        If (strResult <> Utils.Str(GetKey(HumanCase_DB.tlbHumanCase, "idfCase"))) AndAlso (Post(PostType.FinalPosting)) Then
            Me.Enabled = False
            m_NavigatorReadOnlyMode = False
            If (Not BaseFormManager.FindFormByID(GetType(HumanCaseDetail), idResult) Is Nothing) Then
                m_NavigatorReadOnlyMode = True
            End If
            LoadData(idResult)
            'DefineBinding()
            Me.ReadOnly = m_NavigatorReadOnlyMode Or IsCaseClosed
            Me.Enabled = True
        Else
            SelectLastFocusedControl()
        End If
    End Sub


    Dim _okChangeCaseNum As Boolean = False

#End Region

    Public Overrides Sub Merge(ByVal ds As DataSet)

        'Merge lookup tables firstly using template below
        'baseDataSet.Merge(ds.Tables("LookupTableName"))

        'Merge child tables using temlate below

        'baseDataSet.Merge(ds.Tables("ChildTableName"))
        'Now merge the main object table
        baseDataSet.Merge(ds)
    End Sub

    'Define the visible state of each the control using its Tag property
    'Write the control state in the format {MRK}
    'Where
    'M - mandatory field, must be filled by user
    'R - ReadOnly field
    'K - key field - it is editble for new object and read-only in all other cases
    'Empty tag means usual editable field

    Private ReadOnly Property IsSearchMode() As Boolean
        Get
            Return (Not Me.HumanCaseDbService Is Nothing) AndAlso _
                   (Utils.SEARCH_MODE_ID.Equals(Me.HumanCaseDbService.ID))
        End Get
    End Property


    Public Overrides Function GetKey(Optional ByVal aTableName As String = Nothing, Optional ByVal aKeyFieldName As String = Nothing) As Object
        If IsSearchMode() Then Return Utils.SEARCH_MODE_ID
        Return MyBase.GetKey(aTableName, aKeyFieldName)
    End Function

    Public Overrides Function GetChildKey(ByVal child As IRelatedObject) As Object
        If child Is PatientInfo Then
            Return HumanCaseDbService.PatientID
        End If

        If child Is lpPermanentAddress Then
            Return GetKey(HumanCase_DB.tlbHumanCase, "idfRegistrationAddress")
        End If
        If child Is cbGeoLocation Then
            Return GetKey(HumanCase_DB.tlbHumanCase, "idfPointGeoLocation")
        End If

        If (child Is CaseTestsPanel1) AndAlso IsSearchMode() Then
            Return CaseTestsPanelIDInSearchMode
        End If

        If IsSearchMode() Then Return Utils.SEARCH_MODE_ID
        Return GetKey(HumanCase_DB.tlbHumanCase, "idfCase")
    End Function
    Private m_IsAgePersonalData As Boolean
    Protected Overrides Sub AfterLoad()
        If (Not IsSearchMode()) AndAlso (Not HumanCaseDbService Is Nothing) AndAlso _
           (HumanCaseDbService.IsNewObject) AndAlso (Utils.IsEmpty(PatientInfo.RootID)) Then
            PatientInfo.RootID = BaseDbService.NewIntID
        End If
        'If (Not IsSearchMode()) Then
        Core.LookupBinder.BindPersonalDataSpinEdit(PatientInfo.txtAge, baseDataSet, HumanCase_DB.tlbHumanCase + ".intPatientAge", PersonalDataGroup.Human_PersonAge, m_IgnorePersonalData, 0, 0, False, 1, PatientInfo.PersonalDataString)
        Core.LookupBinder.BindHumanAgeUnits(PatientInfo.cbAgeUnits, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfsHumanAgeType", PersonalDataGroup.Human_PersonAge, m_IgnorePersonalData, PatientInfo.PersonalDataString)
        m_IsAgePersonalData = (PatientInfo.txtAge.DataBindings.Count = 0)
        'RemoveHandler PatientInfo.cbAgeUnits.KeyDown, AddressOf Core.LookupBinder.KeyDown
        PatientInfo.cbAgeUnits.ToolTip = Nothing
        'End If

        UpdateFF()
    End Sub

    Public Overrides Function Post(Optional ByVal postType As bv.common.Enums.PostType = bv.common.Enums.PostType.FinalPosting) As Boolean
        Dim bRet As Boolean = False

        DataEventManager.Flush()

        If IsSearchMode() Then
            Return WinUtils.ConfirmMessage(EidssMessages.Get("msgCancelPromptInSearchMode"))
        End If
        If ((HumanCaseDbService Is Nothing) OrElse (Not HumanCaseDbService.IsNewObject)) AndAlso _
            (Not HasChanges()) Then
            SetClosedCaseReadOnly()
            Return True
        End If
        If (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) Then
            baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("datModificationDate") = DateTime.Now
        End If
        'UpdateFFormTemplates()
        Return MyBase.Post(postType)
    End Function

    Public Overrides Function ValidateData() As Boolean
        If (Not IsSearchMode()) Then

            If Not HumanCaseSamplesPanel1.ValidateSamplesData(False) Then
                TabControl1.SelectedTabPage = tpCaseInvestigation
                tcCaseInvestigation.SelectedTabPage = tpSamples
                HumanCaseSamplesPanel1.ValidateSamplesData(True)
                Return False
            End If

            For Each dr As DataRow In baseDataSet.Tables(HumanCase_DB.tlbContactedCasePerson).Rows
                If (dr.RowState = DataRowState.Added Or dr.RowState = DataRowState.Modified) Then
                    Dim ContactOk As Boolean = True
                    If (Utils.IsEmpty(dr("idfRootHuman")) = True) OrElse ((Not IsSearchMode()) AndAlso Utils.IsEmpty(dr("idfsPersonContactType"))) Then
                        MessageForm.Show(EidssMessages.Get("mbFillOrDeleteContact", "Some of the contacts for the patient are not defined. Please define or delete undefined contacts."))
                        ContactOk = False
                    ElseIf (Utils.Str(dr("idfRootHuman")) = Utils.Str(PatientInfo.RootID)) Then
                        MessageForm.Show(EidssMessages.Get("mbPatientCannotBeContactPerson", "Some contacts of the patient coincide with the patient. Please correct these records."))
                        ContactOk = False
                    Else
                        Dim drDuplicateContact As DataRow = FindDuplicateContact(dr)
                        If (Not drDuplicateContact Is Nothing) Then
                            MessageForm.Show(String.Format(EidssMessages.Get("mbContactExist", "It is not possible to create 2 records with the same contact person. The record with the contact '{0}' is already in the Contact List"), drDuplicateContact("strName")))
                            ContactOk = False
                        End If
                    End If
                    If Not ContactOk Then
                        TabControl1.SelectedTabPage = tpCaseInvestigation
                        tcCaseInvestigation.SelectedTabPage = tpContactsRemarks
                        gcContactPeople.Select()
                        Return False
                    End If
                End If
            Next
            If Not gvAntimicrobialTherapy_Validate() Then
                Return False
            End If
            If MyBase.ValidateData = False Then
                Return False
            End If
            If (BaseSettings.ShowWarningForFinalCaseClassification) Then
                If (CLng(model.Enums.CaseClassification.Suspect).Equals(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsFinalCaseStatus"))) Then
                    If Not (chbClinicalDiagBasis.CheckState = CheckState.Checked AndAlso chbEpiDiagBasis.CheckState <> CheckState.Checked AndAlso chbLabDiagBasis.CheckState <> CheckState.Checked) Then
                        MessageForm.ShowOptionalWarning(EidssMessages.Get("msgWarningForFinalCaseClassification"), SettingName.ShowWarningForFinalCaseClassification, BvMessages.Get("DoNotShowWarningNextTime"))
                        Return False
                    End If
                ElseIf (CLng(model.Enums.CaseClassification.Probabale).Equals(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsFinalCaseStatus"))) Then
                    If (chbClinicalDiagBasis.CheckState = CheckState.Checked AndAlso chbEpiDiagBasis.CheckState <> CheckState.Checked AndAlso chbLabDiagBasis.CheckState <> CheckState.Checked) Then
                        MessageForm.ShowOptionalWarning(EidssMessages.Get("msgWarningForFinalCaseClassification"), SettingName.ShowWarningForFinalCaseClassification, BvMessages.Get("DoNotShowWarningNextTime"))
                        Return False
                    End If
                End If
            End If
            If Not Utils.IsEmpty(PatientInfo.txtAge.EditValue) AndAlso (CInt(PatientInfo.txtAge.EditValue) > PatientInfo.MaxAge OrElse CInt(PatientInfo.txtAge.EditValue) < 1) Then
                ErrorForm.ShowWarning("mbAgeShallNotExceed")
                FocusOnField(PatientInfo.txtAge)
                Return False
            End If
        End If
        Return True
    End Function


    <Browsable(False), Localizable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Overrides Property [ReadOnly]() As Boolean
        Get
            Return MyBase.ReadOnly
        End Get
        Set(ByVal Value As Boolean)
            If Not IsSearchMode() Then
                MyBase.ReadOnly = Value
                Me.ShowOkButton = True
                If Value Then
                    'Me.ShowNewButton = False
                    'Me.ShowDeleteButton = False
                    Me.ShowSaveButton = False
                    Me.ShowCancelButton = False
                    btnClear.Visible = False
                    If m_ShowNavigators Then
                        btnSearchHumanCase.Visible = True
                        btnSearchHumanCase.Enabled = True
                        btnSearch.Visible = True
                        btnSearch.Enabled = True
                        If BaseSettings.ShowNavigatorInH02Form AndAlso _
                            eidss.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission( _
                                                    eidss.model.Enums.EIDSSPermissionObject.HumanCase)) Then
                            If _showNavigator1 Then
                                btnNewCase.Visible = False
                                btnNewCase1.Visible = True
                            Else
                                btnNewCase1.Visible = False
                                btnNewCase.Visible = True
                            End If
                        Else
                            btnNewCase.Visible = False
                            btnNewCase1.Visible = False
                        End If
                    End If
                    If m_NavigatorReadOnlyMode Then
                        SetControlReadOnly(cbCaseStatus, True, True)
                        'EnableNavigator()
                    Else
                        'SetControlReadOnly(cbCaseStatus, False, True)
                        'ApplyStyle(cbCaseStatus, True)
                    End If
                    chbClinicalDiagBasis.Enabled = False
                    chbEpiDiagBasis.Enabled = False
                    chbLabDiagBasis.Enabled = False
                Else
                    'SetControlReadOnly(cbCaseStatus, False, True)
                    'ApplyStyle(cbCaseStatus, True)
                    UpdateNotReadOnlyControlView()
                    SetBasisOfDiagnosisState()
                    chbClinicalDiagBasis.Properties.ReadOnly = True
                    chbEpiDiagBasis.Properties.ReadOnly = True
                    chbLabDiagBasis.Properties.ReadOnly = True

                End If
                DisableContactDataEditing()
                UpdateAntimicrobialTherapyState()
                ArrangeButtons(CancelButton.Top, "BottomButtons")
            End If

        End Set
    End Property

    Private Sub UpdateMandatoryControlStyle(ByVal State As ControlState)
        ApplyControlState(cbDiagnosis, State)
        ApplyControlState(PatientInfo.txtLastName, State)
        '    ApplyControlState(cbCaseStatus, State)
        If (State = ControlState.Mandatory) Then
            PatientInfo.CurrentResidence_AddressLookup.MandatoryFields = AddressMandatoryFieldsType.Rayon
            MandatoryFieldHelper.SetCustomAddressMandatoryField(PatientInfo.CurrentResidence_AddressLookup, CustomMandatoryField.HumanCase_Patient_CurrentResidence_Settlement, AddressMandatoryFieldsType.Settlement)
        Else
            PatientInfo.CurrentResidence_AddressLookup.MandatoryFields = AddressMandatoryFieldsType.None
        End If
    End Sub


#Region "Bindings"

    Private Sub HandlersBefore()
        AddHandler deDateOfDischarge.EditValueChanged, AddressOf NotificationInfo_Changed
        AddHandler PatientInfo.OnFieldInfoChanged, AddressOf NotificationInfo_Changed
        AddHandler txtLocalID.EditValueChanged, AddressOf NotificationInfo_Changed
        AddHandler dtLastVisitToEmployer.EditValueChanged, AddressOf NotificationInfo_Changed
        AddHandler dtReportingDate.EditValueChanged, AddressOf NotificationInfo_Changed
        AddHandler cbHospitalizedTo.EditValueChanged, AddressOf NotificationInfo_Changed
        AddHandler deOnsetDate.EditValueChanged, AddressOf NotificationInfo_Changed

        RemoveHandler cbRepSource.EditValueChanged, AddressOf NotificationInfo_Changed
        RemoveHandler dtDiagnosisDate.EditValueChanged, AddressOf NotificationInfo_Changed
        RemoveHandler dtChangedDiagnosisDate.EditValueChanged, AddressOf NotificationInfo_Changed

        RemoveHandler PatientInfo.txtFirstName.EditValueChanged, AddressOf Me.UpdatePatientName
        RemoveHandler PatientInfo.txtSecondName.EditValueChanged, AddressOf Me.UpdatePatientName
        RemoveHandler PatientInfo.txtLastName.EditValueChanged, AddressOf Me.UpdatePatientName

        RemoveHandler PatientInfo.txtLastName.Leave, AddressOf Me.txtLastPatientName_Leave

        RemoveHandler PatientInfo.dtpDOB.Leave, AddressOf Me.Check_BR
        RemoveHandler dtStartDate.Leave, AddressOf Me.Check_BR
        RemoveHandler dtReportingDate.Leave, AddressOf Me.Check_BR
        RemoveHandler dtFormCompletionDate.Leave, AddressOf Me.Check_BR
        RemoveHandler deOnsetDate.Leave, AddressOf Me.Check_BR
        RemoveHandler dtDiagnosisDate.Leave, AddressOf Me.Check_BR
        RemoveHandler dtChangedDiagnosisDate.Leave, AddressOf Me.Check_BR
        RemoveHandler dtLastVisitToEmployer.Leave, AddressOf Me.Check_BR
        'RemoveHandler HumanCaseSamplesPanel1.evDateChanged, AddressOf Me.Check_BR
        'RemoveHandler HumanCaseSamplesPanel1.evSentDateChanged, AddressOf Me.Check_BR
        'RemoveHandler HumanCaseSamplesPanel1.evReceivedByLabDateChanged, AddressOf Me.Check_BR

        eventManager.RemoveDataHandler(HumanCase_DB.tlbHumanCase + ".idfsFinalCaseStatus")
        eventManager.RemoveDataHandler(HumanCase_DB.tlbHumanCase + ".idfsInitialCaseStatus")

        eventManager.RemoveDataHandler(HumanCase_DB.tlbHumanCase + ".idfsTentativeDiagnosis")
        eventManager.RemoveDataHandler(HumanCase_DB.tlbHumanCase + ".idfsFinalDiagnosis")

        eventManager.RemoveDataHandler(HumanCase_DB.tlbHumanCase + ".idfsHospitalizationStatus")
        eventManager.RemoveDataHandler(HumanCase_DB.tlbHumanCase + ".idfsYNHospitalization")
        eventManager.RemoveDataHandler(HumanCase_DB.tlbHumanCase + ".idfsYNAntimicrobialTherapy")
        eventManager.RemoveDataHandler(HumanCase_DB.tlbHumanCase + ".idfsYNRelatedToOutbreak")
        eventManager.RemoveDataHandler(HumanCase_DB.tlbHumanCase + ".idfsYNSpecimenCollected")

        eventManager.RemoveDataHandler(HumanCase_DB.tlbHumanCase + ".idfsCaseProgressStatus")
    End Sub

    Private Sub BindHeader()
        'txtCaseID
        txtCaseID.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        txtCaseID.Properties.ReadOnly = True
        txtCaseID.Enabled = True

        txtCaseID.TabStop = False
        Core.LookupBinder.BindTextEdit(txtCaseID, baseDataSet, HumanCase_DB.tlbHumanCase + ".strCaseID")
        If baseDataSet.Tables.Contains(HumanCase_DB.tlbHumanCase) AndAlso _
           (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) AndAlso _
           (Not Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("strCaseID"))) Then
            txtCaseID.ToolTip = _
                Utils.Str(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("strCaseID"))
        Else
            txtCaseID.ToolTip = Nothing
        End If

        'dtStartDate
        dtStartDate.Properties.Buttons.Clear()
        dtStartDate.Enabled = False
        dtStartDate.TabStop = False
        Core.LookupBinder.BindDateEdit(dtStartDate, baseDataSet, HumanCase_DB.tlbHumanCase + ".datEnteredDate")

        'dtEnteringDate
        dtEnteringDate.Properties.Buttons.Clear()
        dtEnteringDate.Enabled = False
        dtEnteringDate.TabStop = False
        If baseDataSet.Tables.Contains(HumanCase_DB.tlbHumanCase) AndAlso _
           (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) Then
            dtEnteringDate.EditValue = baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("datModificationDate")
        End If

        'cbCaseStatus
        Core.LookupBinder.BindBaseLookup(cbCaseStatus, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfsCaseProgressStatus", bv.common.db.BaseReferenceType.rftCaseProgressStatus, False, False)
        Core.LookupBinder.BindPersonLookup(cbEnteredByName, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfPersonEnteredBy", HACode.Human)
        Core.LookupBinder.BindOrganizationLookup(cbEnteredByOrganization, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfOfficeEnteredBy", HACode.All)
        Core.LookupBinder.BindDiagnosisHACodeLookup(cbCurrentDiagnosis, baseDataSet, LookupTables.HumanStandardDiagnosis, Nothing, , False)
        Core.LookupBinder.BindBaseLookup(cbCaseClassification, baseDataSet, Nothing, db.BaseReferenceType.rftCaseClassification, False)
    End Sub

    Private Sub SetCaseStatusState()
        If (Not IsSearchMode()) AndAlso (Not baseDataSet Is Nothing) AndAlso _
           (baseDataSet.Tables.Contains(HumanCase_DB.tlbHumanCase)) AndAlso _
           (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) AndAlso _
           baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsCaseProgressStatus").Equals(CLng(CaseStatus.Closed)) AndAlso _
           (Not Me.ReadOnly) Then
            IsStatusReadOnly = True
            Me.ReadOnly = True
        End If
        cbCaseStatus.Enabled = EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.CanReopenClosedCase))
    End Sub
    Private Sub BindSectionAboveDemographic()
        'dtFormCompletionDate
        Core.LookupBinder.BindDateEdit(dtFormCompletionDate, baseDataSet, HumanCase_DB.tlbHumanCase + ".datCompletionPaperFormDate")

        'txtLocalID
        Core.LookupBinder.BindTextEdit(txtLocalID, baseDataSet, HumanCase_DB.tlbHumanCase + ".strLocalIdentifier")

    End Sub

    Private Sub BindDiagnosis()
        Dim TentativeDiag As Object = Nothing
        Dim FinalDiag As Object = Nothing

        If baseDataSet.Tables.Contains(HumanCase_DB.tlbHumanCase) AndAlso _
           (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) Then

            TentativeDiag = baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsTentativeDiagnosis")
            FinalDiag = baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsFinalDiagnosis")

            If Utils.Str(TentativeDiag) = Utils.Str(FinalDiag) Then
                baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0).BeginEdit()
                If Not Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsFinalDiagnosis")) Then _
                    baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsFinalDiagnosis") = DBNull.Value
                If Not Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("datFinalDiagnosisDate")) Then _
                    baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("datFinalDiagnosisDate") = DBNull.Value
                baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0).EndEdit()
            End If
        End If

        'Diagnosis
        Core.LookupBinder.BindDiagnosisHACodeLookup(cbDiagnosis, baseDataSet, LookupTables.HumanStandardDiagnosis, HumanCase_DB.tlbHumanCase + ".idfsTentativeDiagnosis", , False)

        Core.LookupBinder.BindDateEdit(dtDiagnosisDate, baseDataSet, HumanCase_DB.tlbHumanCase + ".datTentativeDiagnosisDate")
        If Utils.IsEmpty(TentativeDiag) Then
            'dtDiagnosisDate.EditValue = DBNull.Value
            If Not Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("datTentativeDiagnosisDate")) Then
                baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0).BeginEdit()
                baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("datTentativeDiagnosisDate") = DBNull.Value
                baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0).EndEdit()
            End If
            dtDiagnosisDate.Enabled = False
        Else
            dtDiagnosisDate.Enabled = True
        End If
        DxControlsHelper.ShowButtonEditButton(cbDiagnosis, ButtonPredefines.Delete)

        'Changed Diagnosis
        Core.LookupBinder.BindDiagnosisHACodeLookup(cbChangedDiagnosis, baseDataSet, LookupTables.HumanStandardDiagnosis, HumanCase_DB.tlbHumanCase + ".idfsFinalDiagnosis")
        Core.LookupBinder.BindDateEdit(dtChangedDiagnosisDate, baseDataSet, HumanCase_DB.tlbHumanCase + ".datFinalDiagnosisDate")
        If Utils.IsEmpty(FinalDiag) Then
            'dtChangedDiagnosisDate.EditValue = DBNull.Value
            If Not Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("datFinalDiagnosisDate")) Then
                baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0).BeginEdit()
                baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("datFinalDiagnosisDate") = DBNull.Value
                baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0).EndEdit()
            End If
            dtChangedDiagnosisDate.Enabled = False
        Else
            dtChangedDiagnosisDate.Enabled = True
        End If

        'BasisOfDiagnosis
        chbClinicalDiagBasis.DataBindings.Clear()
        chbClinicalDiagBasis.DataBindings.Add("EditValue", baseDataSet, HumanCase_DB.tlbHumanCase + ".blnClinicalDiagBasis")
        chbEpiDiagBasis.DataBindings.Clear()
        chbEpiDiagBasis.DataBindings.Add("EditValue", baseDataSet, HumanCase_DB.tlbHumanCase + ".blnEpiDiagBasis")
        chbLabDiagBasis.DataBindings.Clear()
        chbLabDiagBasis.DataBindings.Add("EditValue", baseDataSet, HumanCase_DB.tlbHumanCase + ".blnLabDiagBasis")
        SetBasisOfDiagnosisState()
        'We need to fetch last diagnosis code and name here
        RefreshDiagnosis()
    End Sub

    Sub SetBasisOfDiagnosisState()

        If baseDataSet.Tables.Contains(HumanCase_DB.tlbHumanCase) AndAlso _
           (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) Then

            Dim TentativeDiag As Object = baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsTentativeDiagnosis")
            Dim FinalDiag As Object = baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsFinalDiagnosis")
            If Utils.IsEmpty(FinalDiag) AndAlso Utils.IsEmpty(TentativeDiag) Then
                chbClinicalDiagBasis.Enabled = False
                chbEpiDiagBasis.Enabled = False
                chbLabDiagBasis.Enabled = False
            Else
                chbClinicalDiagBasis.Enabled = True
                chbEpiDiagBasis.Enabled = True
                chbLabDiagBasis.Enabled = True
            End If
        End If

    End Sub
    Private Sub BindAge()
        'txtAge
        txtAge.Enabled = True
        If (Not PatientInfo Is Nothing) AndAlso (Not PatientInfo.txtAge Is Nothing) Then
            OkToChangeAge = False
            PatientInfo.txtAge.Enabled = True
            eventManager.RemoveDataHandler(HumanCase_DB.tlbHumanCase + ".intPatientAge")
            Core.LookupBinder.BindPersonalDataSpinEdit(PatientInfo.txtAge, baseDataSet, HumanCase_DB.tlbHumanCase + ".intPatientAge", PersonalDataGroup.Human_PersonAge, m_IgnorePersonalData, 0, 0, False, 1, PatientInfo.PersonalDataString)
            eventManager.AttachDataHandler(HumanCase_DB.tlbHumanCase + ".intPatientAge", AddressOf PatientAgeChanged)
            'PatientInfo.txtAge.EditValue = txtAge.EditValue
            OkToChangeAge = True
        End If

        'cbAgeUnits
        cbAgeUnits.Enabled = True
        DxControlsHelper.HideButtonEditButton(cbAgeUnits, ButtonPredefines.Delete)

        If (Not PatientInfo Is Nothing) AndAlso (Not PatientInfo.cbAgeUnits Is Nothing) Then
            OkToChangeAge = False
            PatientInfo.cbAgeUnits.Enabled = True
            eventManager.RemoveDataHandler(HumanCase_DB.tlbHumanCase + ".idfsHumanAgeType")
            Core.LookupBinder.BindHumanAgeUnits(PatientInfo.cbAgeUnits, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfsHumanAgeType", PersonalDataGroup.Human_PersonAge, m_IgnorePersonalData, PatientInfo.PersonalDataString)

            'RemoveHandler PatientInfo.cbAgeUnits.KeyDown, AddressOf Core.LookupBinder.KeyDown
            PatientInfo.cbAgeUnits.ToolTip = Nothing
            'PatientInfo.cbAgeUnits.EditValue = cbAgeUnits.EditValue
            eventManager.AttachDataHandler(HumanCase_DB.tlbHumanCase + ".idfsHumanAgeType", AddressOf PatientAgeTypeChanged)
            eventManager.Cascade(HumanCase_DB.tlbHumanCase + ".idfsHumanAgeType")
            OkToChangeAge = True
        End If
    End Sub

    Private Sub SetAgeMandatory(ctl As BaseControl, isMandatory As Boolean)
        If (TypeOf (ctl.Tag) Is TagHelper) Then
            CType(ctl.Tag, TagHelper).IsMandatory = isMandatory
            'SetControlReadOnly(ctl, False, False)
        Else
            If isMandatory Then
                ctl.Tag = "{M}"
            Else
                ctl.Tag = Nothing
            End If
        End If
        If (isMandatory) Then
            SetControlMandatoryState(ctl)
        Else
            LayoutCorrector.SetStyleController(ctl, LayoutCorrector.DropDownStyleController)
        End If
    End Sub

    Private Sub PatientAgeChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        'If (Not e.Row("intPatientAge") Is DBNull.Value AndAlso e.Row("idfsHumanAgeType") Is DBNull.Value) Then
        '    e.Row("idfsHumanAgeType") = CLng(HumanAgeTypeEnum.Years)
        '    e.Row.EndEdit()
        '    eventManager.Cascade(HumanCase_DB.tlbHumanCase + ".idfsHumanAgeType")
        'End If
        'If EidssSiteContext.Instance.CountryID <> CLng(Country.Azerbaijan) Then
        If (e.Row("intPatientAge") Is DBNull.Value) Then
            SetAgeMandatory(PatientInfo.cbAgeUnits, False)
        Else
            SetAgeMandatory(PatientInfo.cbAgeUnits, True)
        End If
        'End If
    End Sub

    Private Sub PatientAgeTypeChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        'If e.Row("idfsHumanAgeType").Equals(CLng(HumanAgeTypeEnum.Years)) Then
        '    PatientInfo.txtAge.Properties.MaxValue = 200
        'ElseIf e.Row("idfsHumanAgeType").Equals(CLng(HumanAgeTypeEnum.Month)) Then
        '    PatientInfo.txtAge.Properties.MaxValue = 60
        'ElseIf e.Row("idfsHumanAgeType").Equals(CLng(HumanAgeTypeEnum.Days)) Then
        '    PatientInfo.txtAge.Properties.MaxValue = 31
        'Else
        '    PatientInfo.txtAge.Properties.MaxValue = 200
        'End If
        If e.Row("idfsHumanAgeType").Equals(CLng(HumanAgeTypeEnum.Years)) Then
            PatientInfo.MaxAge = 200
        ElseIf e.Row("idfsHumanAgeType").Equals(CLng(HumanAgeTypeEnum.Month)) Then
            PatientInfo.MaxAge = 60
        ElseIf e.Row("idfsHumanAgeType").Equals(CLng(HumanAgeTypeEnum.Days)) Then
            PatientInfo.MaxAge = 31
        Else
            PatientInfo.MaxAge = 200
        End If
    End Sub


    Private Sub BindDemographicSection()
        'Age
        BindAge()

        'dtLastVisitToEmployer
        Core.LookupBinder.BindDateEdit(dtLastVisitToEmployer, baseDataSet, HumanCase_DB.tlbHumanCase + ".datFacilityLastVisit")
        lpCurrentResidenceAddress.PersonalDataTypes = New PersonalDataGroup() {PersonalDataGroup.Human_CurrentResidence_Coordinates, PersonalDataGroup.Human_CurrentResidence_Details, PersonalDataGroup.Human_CurrentResidence_Settlement}

    End Sub

    Private Sub BindClinicalSection()
        'deOnsetDate
        Core.LookupBinder.BindDateEdit(deOnsetDate, baseDataSet, HumanCase_DB.tlbHumanCase + ".datOnSetDate")

        'cbFinalState
        Core.LookupBinder.BindBaseLookup(cbFinalState, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfsFinalState", db.BaseReferenceType.rftPatientState, False)

        'rgCurrentPatientLocation
        Core.LookupBinder.BindBaseLookup(cbCurrentPatientLocation, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfsHospitalizationStatus", db.BaseReferenceType.rftHospStatus, False)
        'CurrentLocation
        If baseDataSet.Tables.Contains(HumanCase_DB.tlbHumanCase) AndAlso _
           (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) AndAlso _
           (Not Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsHospitalizationStatus"))) Then
            SetHospitalizationStatusVisibility(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsHospitalizationStatus"))
            Dim hospStatus As HospitalizationStatus = CType(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsHospitalizationStatus"), HospitalizationStatus)
            Select Case hospStatus
                Case HospitalizationStatus.Home
                    Core.LookupBinder.ClearEditValueWithoutPrompt(cbHospitalizedTo)
                    txtOtherLocation.EditValue = DBNull.Value
                Case HospitalizationStatus.Hospital
                    Core.LookupBinder.BindOrganizationLookup(cbHospitalizedTo, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfHospital", HACode.Human)
                    txtOtherLocation.EditValue = DBNull.Value
                Case HospitalizationStatus.Other
                    Core.LookupBinder.ClearEditValueWithoutPrompt(cbHospitalizedTo)
                    Core.LookupBinder.BindTextEdit(txtOtherLocation, baseDataSet, HumanCase_DB.tlbHumanCase + ".strCurrentLocation")
            End Select
        Else
            SetHospitalizationStatusVisibility(DBNull.Value)
            Core.LookupBinder.ClearEditValueWithoutPrompt(cbHospitalizedTo)
            txtOtherLocation.EditValue = DBNull.Value
        End If

        'memoNote
        Core.LookupBinder.BindTextEdit(memoNote, baseDataSet, HumanCase_DB.tlbHumanCase + ".strNote")
    End Sub

    Private Sub HospitalizationStatusChanged(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        Throw New NotImplementedException()
    End Sub

    Private Sub BindGeneralSection()
        'dtReportingDate
        Core.LookupBinder.BindDateEdit(dtReportingDate, baseDataSet, HumanCase_DB.tlbHumanCase + ".datNotificationDate")

        'SentBy
        Core.LookupBinder.BindPersonLookup(cbSentByName, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfSentByPerson", HACode.Human, , True)
        'Core.LookupBinder.BindTextEdit(txtSentByFirstName, baseDataSet, HumanCase_DB.tlbHumanCase + ".strSentByFirstName")

        'Core.LookupBinder.BindTextEdit(txtSentByPatronymic, baseDataSet, HumanCase_DB.tlbHumanCase + ".strSentByPatronymicName")

        'Core.LookupBinder.BindTextEdit(txtSentByLastName, baseDataSet, HumanCase_DB.tlbHumanCase + ".strSentByLastName")

        'cbRepSource
        Core.LookupBinder.BindOrganizationLookup(cbRepSource, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfSentByOffice", HACode.Human)
        eventManager.AttachDataHandler(HumanCase_DB.tlbHumanCase + ".idfSentByOffice", AddressOf SentByOffice_Changed)
        eventManager.AttachDataHandler(HumanCase_DB.tlbHumanCase + ".idfSentByPerson", AddressOf SentByPerson_Changed)
        Core.LookupBinder.SetPersonFilter(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0), "idfSentByOffice", cbSentByName, True)
        'eventManager.Cascade(HumanCase_DB.tlbHumanCase + ".idfSentByOffice")
        'eventManager.Cascade(HumanCase_DB.tlbHumanCase + ".idfSentByPerson")

        'ReceivedBy
        Core.LookupBinder.BindPersonLookup(cbReceivedByName, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfReceivedByPerson", HACode.Human, , True)
        'Core.LookupBinder.BindTextEdit(txtReceivedByFirstName, baseDataSet, HumanCase_DB.tlbHumanCase + ".strReceivedByFirstName")

        'Core.LookupBinder.BindTextEdit(txtReceivedByPatronymic, baseDataSet, HumanCase_DB.tlbHumanCase + ".strReceivedByPatronymicName")

        'Core.LookupBinder.BindTextEdit(txtReceivedByLastName, baseDataSet, HumanCase_DB.tlbHumanCase + ".strReceivedByLastName")

        'cbReceivedInst
        Core.LookupBinder.BindOrganizationLookup(cbReceivedInst, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfReceivedByOffice", HACode.Human)
        eventManager.AttachDataHandler(HumanCase_DB.tlbHumanCase + ".idfReceivedByOffice", AddressOf ReceivedByOffice_Changed)
        eventManager.AttachDataHandler(HumanCase_DB.tlbHumanCase + ".idfReceivedByPerson", AddressOf ReceivedByPerson_Changed)
        Core.LookupBinder.SetPersonFilter(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0), "idfReceivedByOffice", cbReceivedByName, True)
        'eventManager.Cascade(HumanCase_DB.tlbHumanCase + ".idfReceivedByOffice")
        'eventManager.Cascade(HumanCase_DB.tlbHumanCase + ".idfReceivedByPerson")
    End Sub
    Private Sub SentByOffice_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        e.Row("idfSentByPerson") = DBNull.Value
        e.Row.EndEdit()
        Core.LookupBinder.SetPersonFilter(e.Row, "idfSentByOffice", cbSentByName, True)
    End Sub

    Private Sub ReceivedByOffice_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        e.Row("idfReceivedByPerson") = DBNull.Value
        e.Row.EndEdit()
        Core.LookupBinder.SetPersonFilter(e.Row, "idfReceivedByOffice", cbReceivedByName, True, )
    End Sub

    Private Sub InvestigatedByOffice_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        e.Row("idfInvestigatedByPerson") = DBNull.Value
        e.Row.EndEdit()
        Core.LookupBinder.SetPersonFilter(e.Row, "idfInvestigatedByOffice", cbEpidemiologistName, True, )
    End Sub

    Private Sub ResetPersonOrganization(personId As Object, row As DataRow, orgFieldName As String)
        Dim organizationId As Object = LookupCache.GetLookupValue(personId, LookupTables.Person, "idfOffice")
        If Not Utils.IsEmpty(organizationId) AndAlso Not organizationId.Equals(row(orgFieldName)) Then
            row(orgFieldName) = organizationId
            row.EndEdit()
        End If

    End Sub
    Private Sub SentByPerson_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        ResetPersonOrganization(e.Value, e.Row, "idfSentByOffice")
    End Sub

    Private Sub ReceivedByPerson_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        ResetPersonOrganization(e.Value, e.Row, "idfReceivedByOffice")
    End Sub

    Private Sub InvestigatedByPerson_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        ResetPersonOrganization(e.Value, e.Row, "idfInvestigatedByOffice")
    End Sub

    Private Sub BindNotification()
        BindSectionAboveDemographic()
        BindDiagnosis()
        BindDemographicSection()
        BindClinicalSection()
        BindGeneralSection()
    End Sub

    Private Sub BindCISectionAboveDemographic()
        'cbInvOrganization
        Core.LookupBinder.BindOrganizationLookup(cbInvOrganization, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfInvestigatedByOffice", HACode.Human)
        'dtInvestigationStartDate
        Core.LookupBinder.BindDateEdit(dtInvestigationStartDate, baseDataSet, HumanCase_DB.tlbHumanCase + ".datInvestigationStartDate")
    End Sub

    Private Sub BindCIDemographicSection()
        'RegistrationAddress
        lpPermanentAddress.DataBindings.Clear()
        lpPermanentAddress.DataBindings.Add("ID", baseDataSet, HumanCase_DB.tlbHumanCase + ".idfRegistrationAddress")
        chkUseSameAddress.DataBindings.Add("EditValue", baseDataSet, HumanCase_DB.tlbHumanCase + ".blnPermantentAddressAsCurrent", False, DataSourceUpdateMode.OnPropertyChanged)
        eventManager.AttachDataHandler(HumanCase_DB.tlbHumanCase + ".blnPermantentAddressAsCurrent", AddressOf UseSameAddress_Changed)
        eventManager.Cascade(HumanCase_DB.tlbHumanCase + ".blnPermantentAddressAsCurrent")
        AddHandler lpCurrentResidenceAddress.AddressChanged, AddressOf CurrentAddressChanged

        'txtRegistrationPhone
        Core.LookupBinder.BindPersonalDataTextEdit(txtRegistrationPhone, baseDataSet, HumanCase_DB.tlbHumanCase + ".strRegistrationPhone", New PersonalDataGroup() {PersonalDataGroup.Human_PermanentResidence_Coordinates, PersonalDataGroup.Human_PermanentResidence_Details, PersonalDataGroup.Human_PermanentResidence_Settlement}, m_IgnorePersonalData)

        'cbOccupation
        Core.LookupBinder.BindBaseLookup(cbOccupation, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfsOccupationType", db.BaseReferenceType.rftOccupationType)

        'txtWorkPhone
        Core.LookupBinder.BindPersonalDataTextEdit(txtWorkPhone, baseDataSet, HumanCase_DB.tlbHumanCase + ".strWorkPhone", New PersonalDataGroup() {PersonalDataGroup.Human_Employer_Details, PersonalDataGroup.Human_Employer_Settlement}, m_IgnorePersonalData)
    End Sub

    Private ReadOnly Property UseSameAddress As Boolean
        Get
            If baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0 Then
                Dim row As DataRow = baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)
                Return Not row("blnPermantentAddressAsCurrent") Is DBNull.Value AndAlso CType(row("blnPermantentAddressAsCurrent"), Boolean)
            End If
            Return False
        End Get
    End Property
    Private Sub UseSameAddress_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        lpPermanentAddress.ReadOnly = False
        If UseSameAddress Then
            CopyCurrentAddressToPermanent()
            m_Updating = True
            chkForeignAddress.Checked = False
            m_Updating = False
            lpPermanentAddress.ForeignAddressMode = False
        Else
            ClearPermanentAddress()
        End If
        'chkForeignAddress.Properties.ReadOnly = [ReadOnly] OrElse UseSameAddress
        lpPermanentAddress.ReadOnly = [ReadOnly] OrElse UseSameAddress
        txtRegistrationPhone.Properties.ReadOnly = [ReadOnly] OrElse UseSameAddress
    End Sub

    Private Sub ClearPermanentAddress()
        If lpPermanentAddress Is Nothing OrElse lpPermanentAddress.AddressRow Is Nothing Then
            Return
        End If
        lpPermanentAddress.Clear()
    End Sub

    Private Sub CurrentAddressChanged(ByVal sender As Object, ByVal e As EventArgs)
        If Not m_BindingDefined Then
            Return
        End If
        CopyCurrentAddressToPermanent()
    End Sub

    Private Sub CopyCurrentAddressToPermanent()
        If (Not UseSameAddress) Then
            Return
        End If
        lpPermanentAddress.CopyAddress(lpCurrentResidenceAddress)
        Dim row As DataRow = baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)
        row("strRegistrationPhone") = PatientInfo.GetPhoneNumber
    End Sub

    Private Sub BindAntimicrobialTherapy()
        'cbAntimicrobialTherapy
        cbAntimicrobialTherapy.DataBindings.Clear()
        Core.LookupBinder.BindBaseLookup(cbAntimicrobialTherapy, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfsYNAntimicrobialTherapy", bv.common.db.BaseReferenceType.rftYesNoValue)
        RemoveHandler cbAntimicrobialTherapy.EditValueChanging, AddressOf Core.LookupBinder.OnClear
        DxControlsHelper.HideButtonEditButton(cbAntimicrobialTherapy, ButtonPredefines.Plus)


        'gcAntimicrobialTherapy
        gcAntimicrobialTherapy.DataSource = baseDataSet.Tables(HumanCase_DB.tlbAntimicrobialTherapy).DefaultView
        If (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) Then
            If (Utils.Str(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsYNAntimicrobialTherapy"), "10100003") <> "10100001") Then ' default value = 10100003 = "ynvUnknown", 10100001 = "ynvYes"
                gcAntimicrobialTherapy.Enabled = False
                gvAntimicrobialTherapy.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                btnRemoveAntimicrobialTherapy.Enabled = False
            Else
                gcAntimicrobialTherapy.Enabled = True
                gvAntimicrobialTherapy.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
                btnRemoveAntimicrobialTherapy.Enabled = True
            End If
        End If
        gvAntimicrobialTherapy.OptionsNavigation.BeginUpdate()
        gvAntimicrobialTherapy.OptionsNavigation.AutoFocusNewRow = True
        gvAntimicrobialTherapy.OptionsNavigation.EndUpdate()
        gcolAntimicrobialTherapyName.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
    End Sub

    Private Sub GeoLocationNameInit()
        dtGeoLocationName = New DataTable("LocationName")
        Dim PK(1) As DataColumn

        Dim idfGeoLocation As DataColumn
        Dim GeoLocationName As DataColumn

        idfGeoLocation = New DataColumn("idfGeoLocation", System.Type.GetType("System.Int64"))
        dtGeoLocationName.Columns.Add(idfGeoLocation)

        GeoLocationName = New DataColumn("GeoLocationName", System.Type.GetType("System.String"))
        dtGeoLocationName.Columns.Add(GeoLocationName)

        PK(0) = idfGeoLocation
        dtGeoLocationName.PrimaryKey = PK
    End Sub

    Private Sub BindLocation()

        If baseDataSet.Tables.Contains(HumanCase_DB.tlbHumanCase) AndAlso _
           (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) Then
            cbGeoLocation.Bind(baseDataSet, HumanCase_DB.tlbHumanCase + ".idfPointGeoLocation")
        End If
    End Sub

    Private Sub BindCIClinicalSection()
        'cbInitialCaseClassification
        Core.LookupBinder.BindStandardLookup(cbInitialCaseClassification, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfsInitialCaseStatus", LookupTables.InitialCaseClassification, False)
        'Core.LookupBinder.SetInitialCaseClassificationFilter(cbInitialCaseClassification)
        'deDateOfxposure
        Core.LookupBinder.BindDateEdit(deDateOfxposure, baseDataSet, HumanCase_DB.tlbHumanCase + ".datExposureDate")

        'teFacilitySoughtCare
        Core.LookupBinder.BindOrganizationLookup(cbFacilitySoughtCare, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfSoughtCareFacility", HACode.Human)

        'deDatePatientFirstSought
        Core.LookupBinder.BindDateEdit(deDatePatientFirstSought, baseDataSet, HumanCase_DB.tlbHumanCase + ".datFirstSoughtCareDate")

        'cbNonNotifiableDiesease
        Core.LookupBinder.BindBaseLookup(cbNonNotifiableDiesease, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfsNonNotifiableDiagnosis", db.BaseReferenceType.rftNonNotifiableDiagnosis, True)

        'cbHospitalization
        Core.LookupBinder.BindBaseLookup(cbHospitalization, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfsYNHospitalization", bv.common.db.BaseReferenceType.rftYesNoValue, False)

        'txtHospital
        Core.LookupBinder.BindTextEdit(txtHospital, baseDataSet, HumanCase_DB.tlbHumanCase + ".strHospitalizationPlace")

        'deDateOfAdmissionHospitalization
        Core.LookupBinder.BindDateEdit(deDateOfAdmissionHospitalization, baseDataSet, HumanCase_DB.tlbHumanCase + ".datHospitalizationDate")

        If baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0 Then
            If (Utils.Str(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsYNHospitalization"), "10100003") <> "10100001") Then ' default value = 10100003 = "ynvUnknown", 10100001 = "ynvYes"
                deDateOfAdmissionHospitalization.Enabled = False
                txtHospital.Enabled = False
            Else
                deDateOfAdmissionHospitalization.Enabled = True
                txtHospital.Enabled = True
            End If
        End If

        'cbLocation
        BindLocation()

        'AntimicrobialTherapy
        BindAntimicrobialTherapy()

        'meClinicalComments
        Core.LookupBinder.BindTextEdit(meClinicalComments, baseDataSet, HumanCase_DB.tlbHumanCase + ".strClinicalNotes")
    End Sub

    Private Sub BindCISpecimenSection()
        HumanCaseSamplesPanel1.DefaultPartyID = HumanCaseDbService.PatientID
        'HumanCaseSamplesPanel1.SetSamplesView = AddressOf CaseTestsPanel1.SetSpecimeLookupView

        'cbSpecimenCollected
        Core.LookupBinder.BindBaseLookup(cbSpecimenCollected, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfsYNSpecimenCollected", bv.common.db.BaseReferenceType.rftYesNoValue, False)
    End Sub

    Private m_ConatactPersonalDataGroup As PersonalDataGroup = PersonalDataGroup.None

    Private Sub BindCIContactSection()
        Core.LookupBinder.BindBaseRepositoryLookup(cbContactType, bv.common.db.BaseReferenceType.rftContact_Type, HACode.All, False)
        cbContactType.Columns("name").Caption = EidssMessages.Get("colRelation", "Relation")

        'gcContactPeople
        If EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_Contact_Details) Then
            m_ConatactPersonalDataGroup = PersonalDataGroup.Human_Contact_Details
        ElseIf EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_Contact_Settlement) Then
            m_ConatactPersonalDataGroup = PersonalDataGroup.Human_Contact_Settlement
        End If
        If (m_ConatactPersonalDataGroup <> PersonalDataGroup.None) Then
            HideContactPersonalData()

        End If
        gcContactPeople.DataSource = baseDataSet.Tables(HumanCase_DB.tlbContactedCasePerson)
        gvContactPeople.OptionsNavigation.BeginUpdate()
        gvContactPeople.OptionsNavigation.AutoFocusNewRow = True
        gvContactPeople.OptionsNavigation.EndUpdate()

        btnEditContact.Text = EidssMessages.Get("btEditContact", "Edit Contact")
        btnEditContact.Image = My.Resources.edit
    End Sub

    Private Sub HideContactPersonalData()
        DisableContactDataEditing()
        For Each row As DataRow In baseDataSet.Tables(HumanCase_DB.tlbContactedCasePerson).Rows
            row("strName") = "*"
            row("strPatientInformation") = GetHiddenContactAddress(row)
        Next
        baseDataSet.Tables(HumanCase_DB.tlbContactedCasePerson).AcceptChanges()
    End Sub
    Private Sub DisableContactDataEditing()
        If (m_ConatactPersonalDataGroup <> PersonalDataGroup.None) Then
            btnAddContact.Enabled = False
            btnDeleteContact.Enabled = False
            btnEditContact.Enabled = False
            gvContactPeople.OptionsBehavior.ReadOnly = True
            gvContactPeople.OptionsBehavior.Editable = False
        End If
    End Sub
    Private Function GetHiddenContactAddress(row As DataRow) As String
        If m_ConatactPersonalDataGroup = PersonalDataGroup.None Then
            Return row("strPatientInformation").ToString()
        End If
        If Utils.IsEmpty(row("strPatientInformation")) Then
            Return ""
        End If
        Dim country As String = EidssSiteContext.Instance.CountryName
        Dim region As String = LookupCache.GetLookupValue(row("idfsRegion"), LookupTables.Region, "strRegionName")
        Dim rayon As String = LookupCache.GetLookupValue(row("idfsRayon"), LookupTables.Rayon, "strRayonName")
        Dim settlement As String = ""
        If m_ConatactPersonalDataGroup = PersonalDataGroup.Human_Contact_Settlement Then
            settlement = LookupCache.GetLookupValue(row("idfsSettlement"), LookupTables.Settlement, "strSettlementName")
        End If
        Return Utils.Join(",", New String() {country, region, rayon, settlement, "*"})
    End Function

    Private Sub BindCISummarySection()
        'lueFinalCaseClassification
        Core.LookupBinder.BindStandardLookup(lueFinalCaseClassification, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfsFinalCaseStatus", LookupTables.FinalCaseClassification, False)
        Core.LookupBinder.BindDateEdit(dtFinalCaseClassificationDate, baseDataSet, HumanCase_DB.tlbHumanCase + ".datFinalCaseClassificationDate")

        'cbOutcome
        Core.LookupBinder.BindBaseLookup(cbOutcome, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfsOutcome", bv.common.db.BaseReferenceType.rftOutcome)
        eventManager.AttachDataHandler(HumanCase_DB.tlbHumanCase + ".idfsOutcome", AddressOf Outcome_Changed)
        eventManager.Cascade(HumanCase_DB.tlbHumanCase + ".idfsOutcome")

        'deDateOfDischarge
        Core.LookupBinder.BindDateEdit(deDateOfDischarge, baseDataSet, HumanCase_DB.tlbHumanCase + ".datDischargeDate")

        'deDateOfDeath
        Core.LookupBinder.BindDateEdit(deDateOfDeath, baseDataSet, HumanCase_DB.tlbHumanCase + ".datDateOfDeath")

        'cbOutbreakExists
        Core.LookupBinder.BindBaseLookup(cbOutbreakExists, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfsYNRelatedToOutbreak", bv.common.db.BaseReferenceType.rftYesNoValue, False)

        'cbOutbreakID
        Core.LookupBinder.BindOutbreakLookup(cbOutbreakID, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfOutbreak")
        If (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) Then
            If (Utils.Str(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsYNRelatedToOutbreak"), "10100003") <> "10100001") Then ' default value = 10100003 = "ynvUnknown", 10100001 = "ynvYes"
                cbOutbreakID.Enabled = False
            Else
                cbOutbreakID.Enabled = True
            End If
        End If

        'meSummaryComments
        Core.LookupBinder.BindTextEdit(meSummaryComments, baseDataSet, HumanCase_DB.tlbHumanCase + ".strSummaryNotes")

        'txtEpidemiologistsName
        'Core.LookupBinder.BindTextEdit(txtEpidemiologistsName, baseDataSet, HumanCase_DB.tlbHumanCase + ".strEpidemiologistsName")
        Core.LookupBinder.BindPersonLookup(cbEpidemiologistName, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfInvestigatedByPerson", HACode.Human)
        eventManager.AttachDataHandler(HumanCase_DB.tlbHumanCase + ".idfInvestigatedByOffice", AddressOf InvestigatedByOffice_Changed)
        eventManager.AttachDataHandler(HumanCase_DB.tlbHumanCase + ".idfInvestigatedByPerson", AddressOf InvestigatedByPerson_Changed)
        Core.LookupBinder.SetPersonFilter(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0), "idfInvestigatedByOffice", cbEpidemiologistName, True)
        'eventManager.Cascade(HumanCase_DB.tlbHumanCase + ".idfInvestigatedByOffice")
        'eventManager.Cascade(HumanCase_DB.tlbHumanCase + ".idfInvestigatedByPerson")
        RefreshCaseClassification()
    End Sub
    Private Sub Outcome_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        deDateOfDischarge.Enabled = Not Utils.IsEmpty(e.Value) AndAlso e.Value.Equals(CLng(OutcomeTypeEnum.Recovered))
        deDateOfDeath.Enabled = Not Utils.IsEmpty(e.Value) AndAlso e.Value.Equals(CLng(OutcomeTypeEnum.Died))
        If Not deDateOfDischarge.Enabled Then
            e.Row("datDischargeDate") = DBNull.Value
        End If
        If Not deDateOfDeath.Enabled Then
            e.Row("datDateOfDeath") = DBNull.Value
        End If
        e.Row.EndEdit()
    End Sub

    Private Sub BindCaseInvestigation()
        BindCISectionAboveDemographic()
        BindCIDemographicSection()
        BindCIClinicalSection()
        BindCISpecimenSection()
        BindCIContactSection()
        BindCISummarySection()
    End Sub


    Private Sub HandlersAfter()
        eventManager.AttachDataHandler(HumanCase_DB.tlbHumanCase + ".idfsCaseProgressStatus", AddressOf CaseStatus_Changed)

        eventManager.AttachDataHandler(HumanCase_DB.tlbHumanCase + ".idfsTentativeDiagnosis", AddressOf Diagnosis_Changed)
        eventManager.AttachDataHandler(HumanCase_DB.tlbHumanCase + ".idfsFinalDiagnosis", AddressOf ChangedDiagnosis_Changed)

        eventManager.AttachDataHandler(HumanCase_DB.tlbHumanCase + ".idfsFinalCaseStatus", AddressOf CaseClassification_Changed)
        eventManager.AttachDataHandler(HumanCase_DB.tlbHumanCase + ".idfsInitialCaseStatus", AddressOf CaseClassification_Changed)

        eventManager.Cascade(HumanCase_DB.tlbHumanCase + ".idfsFinalCaseStatus")
        AddHandler PatientInfo.dtpDOB.Leave, AddressOf Me.Check_BR
        AddHandler dtStartDate.Leave, AddressOf Me.Check_BR
        AddHandler dtReportingDate.Leave, AddressOf Me.Check_BR
        AddHandler dtFormCompletionDate.Leave, AddressOf Me.Check_BR
        AddHandler deOnsetDate.Leave, AddressOf Me.Check_BR
        AddHandler dtDiagnosisDate.Leave, AddressOf Me.Check_BR
        AddHandler dtChangedDiagnosisDate.Leave, AddressOf Me.Check_BR
        AddHandler dtLastVisitToEmployer.Leave, AddressOf Me.Check_BR
        'AddHandler HumanCaseSamplesPanel1.evDateChanged, AddressOf Me.Check_BR

        'AddHandler HumanCaseSamplesPanel1.evSentDateChanged, AddressOf Me.Check_BR
        'AddHandler HumanCaseSamplesPanel1.evReceivedByLabDateChanged, AddressOf Me.Check_BR

        eventManager.AttachDataHandler(HumanCase_DB.tlbHumanCase + ".idfsHospitalizationStatus", AddressOf CurrentPatientLocation_Changed)
        eventManager.AttachDataHandler(HumanCase_DB.tlbHumanCase + ".idfsYNHospitalization", AddressOf Hospitalization_Changed)
        eventManager.AttachDataHandler(HumanCase_DB.tlbHumanCase + ".idfsYNAntimicrobialTherapy", AddressOf AntimicrobialTherapy_Changed)
        eventManager.AttachDataHandler(HumanCase_DB.tlbHumanCase + ".idfsYNRelatedToOutbreak", AddressOf RelatedToOutbreak_Changed)
        eventManager.AttachDataHandler(HumanCase_DB.tlbHumanCase + ".idfsYNSpecimenCollected", AddressOf SpecimenCollected_Changed)

        AddHandler cbRepSource.EditValueChanged, AddressOf NotificationInfo_Changed

        AddHandler PatientInfo.txtLastName.Leave, AddressOf txtLastPatientName_Leave

        AddHandler PatientInfo.txtFirstName.EditValueChanged, AddressOf Me.UpdatePatientName
        AddHandler PatientInfo.txtSecondName.EditValueChanged, AddressOf Me.UpdatePatientName
        AddHandler PatientInfo.txtLastName.EditValueChanged, AddressOf Me.UpdatePatientName

        AddHandler dtDiagnosisDate.EditValueChanged, AddressOf NotificationInfo_Changed
        AddHandler dtChangedDiagnosisDate.EditValueChanged, AddressOf NotificationInfo_Changed
    End Sub

    Private Sub SetClosedCaseReadOnly()
        If (Not IsSearchMode()) AndAlso (Not baseDataSet Is Nothing) AndAlso _
           (baseDataSet.Tables.Contains(HumanCase_DB.tlbHumanCase)) AndAlso _
           (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) AndAlso _
           baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsCaseProgressStatus").Equals(CLng(CaseStatus.Closed)) AndAlso _
           (Not Me.ReadOnly) Then
            Me.ReadOnly = True
        End If
    End Sub

    Private ReadOnly Property IsCaseClosed() As Boolean
        Get
            If (Not IsSearchMode()) AndAlso (Not baseDataSet Is Nothing) AndAlso _
               (baseDataSet.Tables.Contains(HumanCase_DB.tlbHumanCase)) AndAlso _
               (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) AndAlso _
               baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsCaseProgressStatus").Equals(CLng(CaseStatus.Closed)) Then
                Return True
            End If
            Return False
        End Get
    End Property

    Protected Overrides Sub DefineBinding()
        If BindHumanCaseInSearchMode() Then Return
        FFClinicalSigns.ClearTemplate()
        ffEpiInvestigations.ClearTemplate()
        m_IgnorePersonalData = baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfPersonEnteredBy").Equals(EidssUserContext.User.EmployeeID)
        PatientInfo.IgnorePersonalData = m_IgnorePersonalData
        AddHandler PatientInfo.OnClearRootLink, AddressOf ClearRootPatientLink
        lpCurrentResidenceAddress.IgnorePersonalData = m_IgnorePersonalData
        lpPermanentAddress.IgnorePersonalData = m_IgnorePersonalData
        lpEmployerAddress.IgnorePersonalData = m_IgnorePersonalData
        Me.Caption = EidssMessages.Get("frmHumanCase", "Human Case Report Form")
        Me.LeftIcon = My.Resources.Human_Case__large_
        Me.FormID = "H02"

        If BaseSettings.AutoClickDuplicateSearchButton = True Then
            ClickDuplicateSearch = True
        End If

        HandlersBefore()
        StopBR = True

        BindHeader()
        BindNotification()
        BindCaseInvestigation()
        'CaseTestsPanel1.ReadOnly = True
        'm_TestsConductedChangedInCode = True
        Core.LookupBinder.BindBaseLookup(cbTestsConducted, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfsYNTestsConducted", db.BaseReferenceType.rftYesNoValue, False)
        'm_TestsConductedChangedInCode = False
        SetControlReadOnly(cbTestsConducted, Not CBool(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("blnEnableTestsConducted")), False)
        eventManager.AttachDataHandler(HumanCase_DB.tlbHumanCase + ".idfsYNTestsConducted", AddressOf TestConducted_Changed)
        'eventManager.Cascade(HumanCase_DB.tlbHumanCase + ".idfsYNTestsConducted")
        AddHandler CaseTestsPanel1.OnTestsCollectionChanged, AddressOf OnTestsCollectionChanged

        UpdateMandatoryControlStyle(ControlState.Mandatory)

        Timer2.Start()
        DataEventManager.Flush()
        InitNavigator1()

        If ((Not HumanCaseDbService Is Nothing) AndAlso (HumanCaseDbService.IsNewObject)) Then
            m_RefreshNavigator = True
        Else
            m_RefreshNavigator = False
        End If

        SetCaseStatusState()

        bFirstInit = True
        StopBR = False

        HandlersAfter()
        _mBSkipLoadCaseNavigator = True
        If m_FocusOnFirstPage Then
            tcCaseInvestigation.SelectedTabPageIndex = 0
            TabControl1.SelectedTabPageIndex = 0
            dtFormCompletionDate.Select()
        End If
        If EidssSiteContext.Instance.IsGeorgiaCustomization Then
            lbFinalCaseClassificationDate.Visible = False
            dtFinalCaseClassificationDate.Visible = False
        End If
        If EidssSiteContext.Instance.IsIraqCustomization Then
            txtFirstName.Visible = False
            lblFirstName.Visible = False
            txtSecondName.Visible = False
            lblPatronymic.Visible = False
            dtFormCompletionDate.Visible = False
            lblFormCompletionDate.Visible = False
            lblLastName.Visible = False
        End If
        m_FocusOnFirstPage = True
        _mBSkipLoadCaseNavigator = False
        AddHandler Me.HumanCaseSamplesPanel1.OnDeleteSample, AddressOf OnSampleDelete
        m_CanSelectTab = True
        'm_LastDateError = Nothing
    End Sub


    Private Sub ClearRootPatientLink(ByVal sender As Object, ByVal e As EventArgs)
        lpPermanentAddress.Clear()
        UpdateDOBandAge()
    End Sub

    Private Sub OnTestsCollectionChanged(ByVal sender As Object, ByVal e As DataRowEventArgs)
        If e.Row.RowState = DataRowState.Added Then
            m_TestsConductedChangedInCode = True
            baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsYNTestsConducted") = YesNoUnknownValues.Yes
            baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0).EndEdit()
            m_TestsConductedChangedInCode = False
            SetControlReadOnly(cbTestsConducted, True, False)
        ElseIf e.Row.RowState = DataRowState.Deleted OrElse e.Row.RowState = DataRowState.Detached Then
            If Not CaseTestsPanel1.HasCompletedTest Then
                SetControlReadOnly(cbTestsConducted, False, False)
            End If
        End If
    End Sub
    Private Sub OnSampleDelete(ByVal sender As Object, ByVal e As DataRowEventArgs)
        Dim sampleID As Object = e.Row("idfMaterial")
        e.Cancel = Not CaseTestsPanel1.CanDeleteSample(sampleID)
    End Sub

    'Private Sub TestConducted_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
    '    If Not e.Value Is DBNull.Value AndAlso CType(e.Value, YesNoUnknownValues) = YesNoUnknownValues.No Then
    '        CaseTestsPanel1.ReadOnly = True
    '    ElseIf CaseTestsPanel1.ReadOnly <> [ReadOnly] Then
    '        CaseTestsPanel1.ReadOnly = [ReadOnly]
    '    End If
    'End Sub

#End Region

#Region "Field Value Properties"
    Private Function GetCurrentRepSourceName() As String
        If (Not IsSearchMode()) AndAlso _
           baseDataSet.Tables.Contains(HumanCase_DB.tlbHumanCase) AndAlso _
           (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) Then
            Dim keyVal As Object = baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfSentByOffice")
            If Not Utils.IsEmpty(keyVal) Then
                Return LookupCache.GetLookupValue(keyVal, LookupTables.Organization, "Name")
            End If
        End If
        Return ""
    End Function

#End Region

#Region "Update Read-Only Ctrl"
    Private Sub RefreshDiagnosis()
        Try
            Dim DiagID As Long = -1
            Dim InitDiagID As Long = -1
            Dim DiagDate As Object = Nothing

            If IsSearchMode() Then
                If Not Utils.IsEmpty(cbDiagnosis.EditValue) Then
                    InitDiagID = CType(cbDiagnosis.EditValue, Long)
                End If
                If (Not Utils.IsEmpty(cbChangedDiagnosis.EditValue)) Then
                    DiagID = CType(cbChangedDiagnosis.EditValue, Long)
                    If Not Utils.IsEmpty(dtChangedDiagnosisDate.EditValue) Then _
                        DiagDate = dtChangedDiagnosisDate.DateTime
                Else
                    If (Not Utils.IsEmpty(cbDiagnosis.EditValue)) Then
                        DiagID = CType(cbDiagnosis.EditValue, Long)
                        If Not Utils.IsEmpty(dtDiagnosisDate.EditValue) Then _
                            DiagDate = dtDiagnosisDate.DateTime
                    End If
                End If
                DxControlsHelper.SetButtonEditButtonVisibility(cbChangedDiagnosis, ButtonPredefines.Glyph, Not Utils.IsEmpty(cbChangedDiagnosis.EditValue))
            ElseIf baseDataSet.Tables.Contains(HumanCase_DB.tlbHumanCase) AndAlso _
                   (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) Then

                If Not Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsTentativeDiagnosis")) Then
                    InitDiagID = CType(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsTentativeDiagnosis"), Long)
                    DiagID = CType(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsTentativeDiagnosis"), Long)
                    DiagDate = baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("datTentativeDiagnosisDate")
                End If

                If Not Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsFinalDiagnosis")) Then
                    DiagID = CType(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsFinalDiagnosis"), Long)
                    DiagDate = baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("datFinalDiagnosisDate")
                End If

                DxControlsHelper.SetButtonEditButtonVisibility(cbChangedDiagnosis, ButtonPredefines.Glyph, Not Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsFinalDiagnosis")))
            End If

            If Not Utils.IsEmpty(InitDiagID) Then
                If (m_strInitDiagID <> InitDiagID) Then
                    Dim clinicalDiagName As String = LookupCache.GetLookupValue( _
                                    InitDiagID, LookupTables.HumanStandardDiagnosis, "Name")
                    txtClinicalDiagnosis.Properties.ReadOnly = False
                    txtClinicalDiagnosis.Text = clinicalDiagName
                    txtClinicalDiagnosis.Properties.ReadOnly = True
                    m_strInitDiagID = InitDiagID
                End If
            Else
                txtClinicalDiagnosis.Properties.ReadOnly = False
                txtClinicalDiagnosis.Text = ""
                txtClinicalDiagnosis.Properties.ReadOnly = True
            End If

            If (Not Utils.IsEmpty(DiagID)) Then
                If (m_DiagID <> DiagID) Then
                    Dim FinalDiagName As String = LookupCache.GetLookupValue( _
                                    DiagID, LookupTables.HumanStandardDiagnosis, "Name")
                    If Not IsSearchMode Then
                        cbCurrentDiagnosis.EditValue = DiagID
                    End If
                    txtFinalDiagnosis.Properties.ReadOnly = False
                    txtFinalDiagnosis.Text = FinalDiagName
                    txtFinalDiagnosis.Properties.ReadOnly = True
                    If (Not IsSearchMode) Then
                        dtFinalDiagnosisDate.Properties.ReadOnly = False
                        If (Not Utils.IsEmpty(DiagDate)) Then
                            dtFinalDiagnosisDate.EditValue = CDate(DiagDate)
                        Else
                            dtFinalDiagnosisDate.EditValue = DBNull.Value
                        End If
                        dtFinalDiagnosisDate.Properties.ReadOnly = True
                    End If

                    m_DiagID = DiagID

                    CaseTestsPanel1.DiagnosisID = DiagID
                End If
            Else
                If Not IsSearchMode Then
                    Core.LookupBinder.ClearEditValueWithoutPrompt(cbCurrentDiagnosis)
                    dtFinalDiagnosisDate.Properties.ReadOnly = False
                    dtFinalDiagnosisDate.EditValue = DBNull.Value
                    dtFinalDiagnosisDate.Properties.ReadOnly = True
                End If
                txtFinalDiagnosis.Properties.ReadOnly = False
                txtFinalDiagnosis.Text = ""
                txtFinalDiagnosis.Properties.ReadOnly = True
            End If

            'если диагнозов нет - запрещено связывать сессию с Outbreak-ом
            If Not IsSearchMode Then
                If DiagID = -1 Then
                    cbOutbreakExists.Enabled = False
                    DxControlsHelper.DisableButtonEditButton(cbOutbreakID, ButtonPredefines.Ellipsis)
                Else
                    cbOutbreakExists.Enabled = True
                    DxControlsHelper.EnableButtonEditButton(cbOutbreakID, ButtonPredefines.Ellipsis)
                End If
            End If

            Me.HumanCaseSamplesPanel1.CurrentDiagnosis = m_DiagID
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RefreshCaseClassification()
        Core.LookupBinder.ClearEditValueWithoutPrompt(cbCaseClassification)
        If Not IsSearchMode() AndAlso baseDataSet.Tables.Contains(HumanCase_DB.tlbHumanCase) AndAlso _
               (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) Then
            If Not Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsFinalCaseStatus")) Then
                cbCaseClassification.EditValue = baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsFinalCaseStatus")
            Else
                cbCaseClassification.EditValue = baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsInitialCaseStatus")
            End If
        End If
    End Sub


    Private Sub UpdatePatientName(ByVal sender As Object, ByVal e As System.EventArgs)
        NotificationInfo_Changed(sender, e)
        If Not m_IgnorePersonalData AndAlso EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_PersonName) Then
            txtPatient.Text = PatientInfo.PersonalDataString
        Else
            txtPatient.Text = Utils.Join(" ", New String() {PatientInfo.txtLastName.Text, PatientInfo.txtFirstName.Text, PatientInfo.txtSecondName.Text})
        End If
    End Sub

    Public Sub UpdateDOBandAge()
        Dim ddAge As Double = -1
        Dim datUp As Date = Nothing
        If (Not Loading) AndAlso OkToUpdateDOBAndAge Then
            If (Not PatientInfo.dtpDOB.EditValue Is Nothing) And (Not PatientInfo.dtpDOB.EditValue Is DBNull.Value) Then
                If (Not deOnsetDate.EditValue Is Nothing) And (Not deOnsetDate.EditValue Is DBNull.Value) Then
                    ddAge = -PatientInfo.dtpDOB.DateTime.Subtract(deOnsetDate.DateTime).TotalDays
                    datUp = deOnsetDate.DateTime
                ElseIf (Not dtReportingDate.EditValue Is Nothing) And (Not dtReportingDate.EditValue Is DBNull.Value) Then
                    ddAge = -PatientInfo.dtpDOB.DateTime.Subtract(dtReportingDate.DateTime).TotalDays
                    datUp = dtReportingDate.DateTime
                ElseIf (Not dtStartDate.EditValue Is Nothing) And (Not dtStartDate.EditValue Is DBNull.Value) Then
                    ddAge = -PatientInfo.dtpDOB.DateTime.Subtract(dtStartDate.DateTime).TotalDays
                    datUp = dtStartDate.DateTime
                End If
                Dim row As DataRow = baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)
                If (ddAge > -1) Then
                    Dim yyAge As Long = bv.model.Helpers.DateHelper.DateDifference(bv.model.Helpers.DateInterval.Year, PatientInfo.dtpDOB.DateTime, datUp)
                    If (yyAge > 0) Then
                        'Years
                        If Utils.IsEmpty(row("intPatientAge")) OrElse Not CInt(yyAge).Equals(CInt(row("intPatientAge"))) Then
                            If (Not IsSearchMode()) Then
                                row.BeginEdit()
                                row("intPatientAge") = CInt(yyAge)
                                row.EndEdit()
                            End If
                            'txtAge.EditValue = System.Convert.ToInt16(yyAge)
                        End If
                        If Utils.Str(row("idfsHumanAgeType")) <> "10042003" Then '"hatYears"
                            If (Not IsSearchMode()) Then
                                row.BeginEdit()
                                row("idfsHumanAgeType") = 10042003 '"hatYears"
                                row.EndEdit()
                            End If
                            cbAgeUnits.EditValue = 10042003 '"hatYears"
                        End If
                    Else
                        Dim mmAge As Long = bv.model.Helpers.DateHelper.DateDifference(bv.model.Helpers.DateInterval.Month, PatientInfo.dtpDOB.DateTime, datUp)
                        If (mmAge > 0) Then
                            'Months
                            If Utils.IsEmpty(row("intPatientAge")) OrElse (CInt(row("intPatientAge")) <> CInt(mmAge)) Then
                                If (Not IsSearchMode()) Then
                                    row.BeginEdit()
                                    row("intPatientAge") = CInt(mmAge)
                                    row.EndEdit()
                                End If
                                'txtAge.EditValue = CInt(mmAge)
                            End If
                            If Utils.Str(row("idfsHumanAgeType")) <> "10042002" Then '"hatMonth"
                                If (Not IsSearchMode()) Then
                                    row.BeginEdit()
                                    row("idfsHumanAgeType") = 10042002 '"hatMonth"
                                    row.EndEdit()
                                End If
                                'cbAgeUnits.EditValue = 10042002 '"hatMonth"
                            End If
                        Else
                            'Days
                            If Utils.IsEmpty(row("intPatientAge")) OrElse (CInt(row("intPatientAge")) <> CInt(ddAge)) Then
                                If (Not IsSearchMode()) Then
                                    row.BeginEdit()
                                    row("intPatientAge") = CInt(ddAge)
                                    row.EndEdit()
                                End If
                                'txtAge.EditValue = CInt(ddAge)
                            End If
                            If Utils.Str(row("idfsHumanAgeType")) <> "10042001" Then '"hatDays"
                                If (Not IsSearchMode()) Then
                                    row.BeginEdit()
                                    row("idfsHumanAgeType") = 10042001 '"hatDays"
                                    row.EndEdit()
                                End If
                                'cbAgeUnits.EditValue = 10042001 '"hatDays"
                            End If
                        End If
                    End If
                ElseIf IsSearchMode() Then
                    txtAge.EditValue = DBNull.Value
                    Core.LookupBinder.ClearEditValueWithoutPrompt(cbAgeUnits)
                End If
                txtAge.Enabled = False
                cbAgeUnits.Enabled = False
            Else
                txtAge.Enabled = True
                cbAgeUnits.Enabled = True
            End If
            OkToChangeAge = False
            'PatientInfo.txtAge.EditValue = txtAge.EditValue
            'PatientInfo.cbAgeUnits.EditValue = cbAgeUnits.EditValue
            If (Not m_IsAgePersonalData) Then
                PatientInfo.txtAge.Enabled = txtAge.Enabled
                PatientInfo.cbAgeUnits.Enabled = cbAgeUnits.Enabled
            End If
            OkToChangeAge = True
        End If
    End Sub


    Private Sub UpdateAllDuplicatedControlsInSearchMode()
        txtLocalIdentifier.Properties.ReadOnly = False
        txtLocalIdentifier.Text = txtLocalID.Text
        txtLocalIdentifier.Properties.ReadOnly = True

        txtLastName.Properties.ReadOnly = False
        txtLastName.Text = PatientInfo.txtLastName.Text
        txtLastName.Properties.ReadOnly = True

        txtFirstName.Properties.ReadOnly = False
        txtFirstName.Text = PatientInfo.txtFirstName.Text
        txtFirstName.Properties.ReadOnly = True

        txtSecondName.Properties.ReadOnly = False
        txtSecondName.Text = PatientInfo.txtSecondName.Text
        txtSecondName.Properties.ReadOnly = True

        txtDOB.Properties.ReadOnly = False
        If (Utils.IsEmpty(PatientInfo.dtpDOB.EditValue) = True) Then
            txtDOB.Text = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern
        Else
            txtDOB.Text = PatientInfo.dtpDOB.DateTime.ToString(PatientInfo.dtpDOB.Properties.EditFormat.FormatString)
        End If
        txtDOB.Properties.ReadOnly = True

        'txtPatientAge.Properties.ReadOnly = False
        'txtPatientAge.Text = PatientInfo.txtAge.Text
        'txtPatientAge.Properties.ReadOnly = True

        'txtPatientAgeUnits.Properties.ReadOnly = False
        'txtPatientAgeUnits.Text = PatientInfo.cbAgeUnits.Text
        'txtPatientAgeUnits.Properties.ReadOnly = True

        txtPatientSex.Properties.ReadOnly = False
        txtPatientSex.Text = PatientInfo.cbPersonSex.Text
        txtPatientSex.Properties.ReadOnly = True

        lpCurrentResidenceAddress.ReadOnly = False
        lpCurrentResidenceAddress.baseDataSet = New DataSet()
        lpCurrentResidenceAddress.baseDataSet.Merge(PatientInfo.CurrentResidence_AddressLookup.baseDataSet, False)
        lpCurrentResidenceAddress.BindAddress()
        lpCurrentResidenceAddress.ReadOnly = True

        txtPhoneNumber.Properties.ReadOnly = False
        txtPhoneNumber.Text = PatientInfo.txtPhoneNumber.Text
        txtPhoneNumber.Properties.ReadOnly = True

        txtNationality.Properties.ReadOnly = False
        txtNationality.Text = PatientInfo.cbNationality.Text
        txtNationality.Properties.ReadOnly = True

        txtEmployerName.Properties.ReadOnly = False
        txtEmployerName.Text = PatientInfo.txtEmployerName.Text
        txtEmployerName.Properties.ReadOnly = True

        lpEmployerAddress.ReadOnly = False
        lpEmployerAddress.baseDataSet = New DataSet()
        lpEmployerAddress.baseDataSet.Merge(PatientInfo.Employer_AddressLookup.baseDataSet, False)
        lpEmployerAddress.BindAddress()
        lpEmployerAddress.ReadOnly = True

        txtEmployerLastVisit.Properties.ReadOnly = False
        If (Utils.IsEmpty(dtLastVisitToEmployer.EditValue) = True) Then
            txtEmployerLastVisit.Text = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern
        Else
            txtEmployerLastVisit.Text = dtLastVisitToEmployer.DateTime.ToString(dtLastVisitToEmployer.Properties.EditFormat.FormatString)
        End If
        txtEmployerLastVisit.Properties.ReadOnly = True

        txtSymptomOnsetDate.Properties.ReadOnly = False
        If (Not Utils.IsEmpty(deOnsetDate.EditValue)) Then
            txtSymptomOnsetDate.Text = deOnsetDate.DateTime.ToString(deOnsetDate.Properties.EditFormat.FormatString)
        Else
            txtSymptomOnsetDate.Text = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern
        End If
        txtSymptomOnsetDate.Properties.ReadOnly = True


        txtDischargeDate.Properties.ReadOnly = False
        If (Utils.IsEmpty(deDateOfDischarge.EditValue) = True) Then
            txtDischargeDate.Text = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern
        Else
            txtDischargeDate.Text = deDateOfDischarge.DateTime.ToString(deDateOfDischarge.Properties.EditFormat.FormatString)
        End If
        txtDischargeDate.Properties.ReadOnly = True

        txtNotifSentByDate.Properties.ReadOnly = False
        If (Utils.IsEmpty(dtReportingDate.EditValue)) Then
            txtNotifSentByDate.Text = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern
        Else
            txtNotifSentByDate.Text = dtReportingDate.DateTime.ToString(dtReportingDate.Properties.EditFormat.FormatString)
        End If
        txtNotifSentByDate.Properties.ReadOnly = True

        txtNotifOrganization.Properties.ReadOnly = False
        txtNotifOrganization.Text = cbRepSource.Text
        txtNotifOrganization.Properties.ReadOnly = True
    End Sub

    Private Sub SetReadOnlyText(txt As BaseEdit, text As String)
        txt.Properties.ReadOnly = False
        txt.Text = text
        txt.Properties.ReadOnly = True
    End Sub
    Private Sub NotificationInfo_Changed(ByVal sender As Object, ByVal e As System.EventArgs)
        If (sender Is Me) Then
            If IsSearchMode() Then
                UpdateAllDuplicatedControlsInSearchMode()
                Return
            End If
            If (Not PatientInfo Is Nothing) AndAlso (PatientInfo.PatientInfoCreated = True) Then
                txtLastName.Properties.ReadOnly = False
                txtLastName.Text = PatientInfo.GetLastName
                txtLastName.Properties.ReadOnly = True
                txtFirstName.Properties.ReadOnly = False
                txtFirstName.Text = PatientInfo.GetFirstName
                txtFirstName.Properties.ReadOnly = True
                txtSecondName.Properties.ReadOnly = False
                txtSecondName.Text = PatientInfo.GetSecondName
                txtSecondName.Properties.ReadOnly = True
                SetReadOnlyText(txtPersonalID, PatientInfo.GetPersonID)
                SetReadOnlyText(txtPersonalIdType, PatientInfo.GetPersonIDType)
                txtDOB.Properties.ReadOnly = False
                txtDOB.Text = PatientInfo.GetDOB
                txtDOB.Properties.ReadOnly = True
                txtPatientSex.Properties.ReadOnly = False
                txtPatientSex.Text = PatientInfo.GetPersonSex
                txtPatientSex.Properties.ReadOnly = True
                lpCurrentResidenceAddress.ReadOnly = False
                lpCurrentResidenceAddress.baseDataSet = New DataSet()
                lpCurrentResidenceAddress.baseDataSet.Merge(PatientInfo.CurrentResidence_AddressLookup.baseDataSet, False)
                lpCurrentResidenceAddress.PersonalDataTypes = PatientInfo.CurrentResidence_AddressLookup.PersonalDataTypes
                lpCurrentResidenceAddress.BindAddress()
                lpCurrentResidenceAddress.ReadOnly = True
                txtPhoneNumber.Properties.ReadOnly = False
                txtPhoneNumber.Text = PatientInfo.GetPhoneNumber
                txtPhoneNumber.Properties.ReadOnly = True
                txtNationality.Properties.ReadOnly = False
                txtNationality.Text = PatientInfo.GetNationality
                txtNationality.Properties.ReadOnly = True
                txtEmployerName.Properties.ReadOnly = False
                txtEmployerName.Text = PatientInfo.GetEmployerName
                txtEmployerName.Properties.ReadOnly = True
                lpEmployerAddress.ReadOnly = False
                lpEmployerAddress.baseDataSet = New DataSet()
                lpEmployerAddress.baseDataSet.Merge(PatientInfo.Employer_AddressLookup.baseDataSet, False)
                lpEmployerAddress.BindAddress()
                lpEmployerAddress.ReadOnly = True
            End If
            txtLocalIdentifier.Properties.ReadOnly = False
            txtLocalIdentifier.Text = baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("strLocalIdentifier").ToString()
            txtLocalIdentifier.Properties.ReadOnly = True
            txtPatientAge.Properties.ReadOnly = False
            txtPatientAgeUnits.Properties.ReadOnly = False
            If (txtDOB.Text = "*") Then
                txtPatientAge.Text = "*"
                txtPatientAgeUnits.Text = "*"
            Else
                txtPatientAge.Text = baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("intPatientAge").ToString()
                txtPatientAgeUnits.Text = LookupCache.GetLookupValue(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsHumanAgeType"), bv.common.db.BaseReferenceType.rftHumanAgeType, "Name")
            End If
            txtPatientAge.Properties.ReadOnly = True
            txtPatientAgeUnits.Properties.ReadOnly = True
            txtEmployerLastVisit.Properties.ReadOnly = False
            If (Not Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("datFacilityLastVisit"))) Then
                txtEmployerLastVisit.Text = CDate(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("datFacilityLastVisit")).ToString(dtLastVisitToEmployer.Properties.EditFormat.FormatString)
            Else
                txtEmployerLastVisit.Text = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern
            End If
            txtEmployerLastVisit.Properties.ReadOnly = True
            txtSymptomOnsetDate.Properties.ReadOnly = False
            If (Not Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("datOnSetDate"))) Then
                txtSymptomOnsetDate.Text = CDate(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("datOnSetDate")).ToString(deOnsetDate.Properties.EditFormat.FormatString)
            Else
                txtSymptomOnsetDate.Text = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern
            End If
            txtSymptomOnsetDate.Properties.ReadOnly = True
            txtDischargeDate.Properties.ReadOnly = False
            If (Not Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("datDischargeDate"))) Then
                txtDischargeDate.Text = CDate(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("datDischargeDate")).ToString(deDateOfDischarge.Properties.EditFormat.FormatString)
            Else
                txtDischargeDate.Text = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern
            End If
            txtDischargeDate.Properties.ReadOnly = True
            Me.txtNotifSentByDate.Properties.ReadOnly = False
            If (Not Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("datNotificationDate"))) Then
                txtNotifSentByDate.Text = CDate(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("datNotificationDate")).ToString(dtReportingDate.Properties.EditFormat.FormatString)
            Else
                txtNotifSentByDate.Text = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern
            End If
            txtNotifSentByDate.Properties.ReadOnly = True
            txtNotifOrganization.Properties.ReadOnly = False
            txtNotifOrganization.Text = GetCurrentRepSourceName()
            txtNotifOrganization.Properties.ReadOnly = True
        ElseIf (sender Is txtLocalID) Then
            txtLocalIdentifier.Properties.ReadOnly = False
            txtLocalIdentifier.Text = txtLocalID.Text
            txtLocalIdentifier.Properties.ReadOnly = True
        ElseIf (sender Is PatientInfo.txtLastName) Then
            txtLastName.Properties.ReadOnly = False
            txtLastName.Text = PatientInfo.txtLastName.Text
            txtLastName.Properties.ReadOnly = True
        ElseIf (sender Is PatientInfo.txtFirstName) Then
            txtFirstName.Properties.ReadOnly = False
            txtFirstName.Text = PatientInfo.txtFirstName.Text
            txtFirstName.Properties.ReadOnly = True
        ElseIf (sender Is PatientInfo.txtSecondName) Then
            txtSecondName.Properties.ReadOnly = False
            txtSecondName.Text = PatientInfo.txtSecondName.Text
            txtSecondName.Properties.ReadOnly = True
        ElseIf (sender Is PatientInfo.cbPersonalIdType) Then
            SetReadOnlyText(txtPersonalIdType, PatientInfo.cbPersonalIdType.Text)
        ElseIf (sender Is PatientInfo.txtPersonalID) Then
            SetReadOnlyText(txtPersonalID, PatientInfo.txtPersonalID.Text)
        ElseIf (sender Is PatientInfo.dtpDOB) Then
            txtDOB.Properties.ReadOnly = False
            If (Utils.IsEmpty(PatientInfo.dtpDOB.EditValue) = True) Then
                txtDOB.Text = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern
            Else
                txtDOB.Text = PatientInfo.dtpDOB.DateTime.ToString(PatientInfo.dtpDOB.Properties.EditFormat.FormatString)
            End If
            txtDOB.Properties.ReadOnly = True
        ElseIf (sender Is PatientInfo.txtAge) Then
            txtPatientAge.Properties.ReadOnly = False
            txtPatientAge.Text = PatientInfo.txtAge.Text
            txtPatientAge.Properties.ReadOnly = True
        ElseIf (sender Is PatientInfo.cbAgeUnits) Then
            txtPatientAgeUnits.Properties.ReadOnly = False
            txtPatientAgeUnits.Text = PatientInfo.cbAgeUnits.Text
            txtPatientAgeUnits.Properties.ReadOnly = True
        ElseIf (sender Is PatientInfo.cbPersonSex) Then
            txtPatientSex.Properties.ReadOnly = False
            txtPatientSex.Text = PatientInfo.cbPersonSex.Text
            txtPatientSex.Properties.ReadOnly = True
        ElseIf (sender Is PatientInfo.CurrentResidence_AddressLookup) Then
            lpCurrentResidenceAddress.ReadOnly = False
            lpCurrentResidenceAddress.baseDataSet = New DataSet()
            lpCurrentResidenceAddress.baseDataSet.Merge(PatientInfo.CurrentResidence_AddressLookup.baseDataSet, False)
            lpCurrentResidenceAddress.BindAddress()
            lpCurrentResidenceAddress.ReadOnly = True
        ElseIf (sender Is PatientInfo.txtPhoneNumber) Then
            txtPhoneNumber.Properties.ReadOnly = False
            txtPhoneNumber.Text = PatientInfo.txtPhoneNumber.Text
            txtPhoneNumber.Properties.ReadOnly = True
        ElseIf (sender Is PatientInfo.cbNationality) Then
            txtNationality.Properties.ReadOnly = False
            txtNationality.Text = PatientInfo.cbNationality.Text
            txtNationality.Properties.ReadOnly = True
        ElseIf (sender Is PatientInfo.txtEmployerName) Then
            txtEmployerName.Properties.ReadOnly = False
            txtEmployerName.Text = PatientInfo.txtEmployerName.Text
            txtEmployerName.Properties.ReadOnly = True
        ElseIf (sender Is PatientInfo.Employer_AddressLookup) Then
            lpEmployerAddress.ReadOnly = False
            lpEmployerAddress.baseDataSet = New DataSet()
            lpEmployerAddress.baseDataSet.Merge(PatientInfo.Employer_AddressLookup.baseDataSet, False)
            lpEmployerAddress.BindAddress()
            lpEmployerAddress.ReadOnly = True
        ElseIf (sender Is dtLastVisitToEmployer) Then
            txtEmployerLastVisit.Properties.ReadOnly = False
            If (Utils.IsEmpty(dtLastVisitToEmployer.EditValue) = True) Then
                txtEmployerLastVisit.Text = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern
            Else
                txtEmployerLastVisit.Text = dtLastVisitToEmployer.DateTime.ToString(dtLastVisitToEmployer.Properties.EditFormat.FormatString)
            End If
            txtEmployerLastVisit.Properties.ReadOnly = True
        ElseIf (sender Is deOnsetDate) Then
            txtSymptomOnsetDate.Properties.ReadOnly = False
            If (Not Utils.IsEmpty(deOnsetDate.EditValue)) Then
                txtSymptomOnsetDate.Text = deOnsetDate.DateTime.ToString(deOnsetDate.Properties.EditFormat.FormatString)
            Else
                txtSymptomOnsetDate.Text = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern
            End If
            txtSymptomOnsetDate.Properties.ReadOnly = True
        ElseIf (sender Is dtDiagnosisDate) AndAlso _
            (((Not IsSearchMode()) AndAlso _
              ((baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count = 0) OrElse _
               (Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsFinalDiagnosis"))))) _
            ) Then
            dtFinalDiagnosisDate.EditValue = dtDiagnosisDate.EditValue
        ElseIf (sender Is dtChangedDiagnosisDate) Then
            If ((Not IsSearchMode()) AndAlso _
                ((baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count = 0) OrElse _
                 (Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsFinalDiagnosis"))))) Then
                dtFinalDiagnosisDate.EditValue = dtDiagnosisDate.EditValue
            Else
                dtFinalDiagnosisDate.EditValue = dtChangedDiagnosisDate.EditValue
            End If
        ElseIf (sender Is deDateOfDischarge) Then
            txtDischargeDate.Properties.ReadOnly = False
            If (Utils.IsEmpty(deDateOfDischarge.EditValue) = True) Then
                txtDischargeDate.Text = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern
            Else
                txtDischargeDate.Text = deDateOfDischarge.DateTime.ToString(deDateOfDischarge.Properties.EditFormat.FormatString)
            End If
            txtDischargeDate.Properties.ReadOnly = True
        ElseIf (sender Is dtReportingDate) Then
            Me.txtNotifSentByDate.Properties.ReadOnly = False
            If (Utils.IsEmpty(dtReportingDate.EditValue)) Then
                txtNotifSentByDate.Text = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern
            Else
                txtNotifSentByDate.Text = dtReportingDate.DateTime.ToString(dtReportingDate.Properties.EditFormat.FormatString)
            End If
            txtNotifSentByDate.Properties.ReadOnly = True
        ElseIf (sender Is cbRepSource) Then
            txtNotifOrganization.Properties.ReadOnly = False
            txtNotifOrganization.Text = cbRepSource.Text
            txtNotifOrganization.Properties.ReadOnly = True
        End If
    End Sub

#End Region

#Region "Service Methods"
    Private Function SamplesCount(table As DataTable) As Integer
        Return table.Select(String.Format("idfsSampleType <> {0}", CLng(SampleTypeEnum.Unknown)), Nothing, DataViewRowState.CurrentRows).Length
    End Function
    Private Function TableNotDelRowCount(ByVal Table As DataTable) As Integer
        Dim res As Integer = 0
        If Not Table Is Nothing Then
            For Each r As DataRow In Table.Rows
                If r.RowState <> DataRowState.Deleted Then
                    res = res + 1
                End If
            Next
        End If
        Return res
    End Function

    Private Function TableNotDelRowHandle(ByVal Table As DataTable) As Integer
        Dim res As Integer = 0
        If TableNotDelRowCount(Table) > 0 Then
            While res < Table.Rows.Count AndAlso Table.Rows(res).RowState = DataRowState.Deleted
                res = res + 1
            End While
            If res = Table.Rows.Count Then res = -1
        Else
            res = -1
        End If
        Return res
    End Function

    'Private Sub ChangeValues(ByRef Value1 As Integer, ByRef Value2 As Integer)
    '    Dim i As Integer = Value1
    '    Value1 = Value2
    '    Value2 = i
    'End Sub

    'Public Function DateDifference(ByVal Interval As Microsoft.VisualBasic.DateInterval, ByVal Date1 As DateTime, ByVal Date2 As DateTime) As Long
    '    If Utils.IsEmpty(Date1) OrElse Utils.IsEmpty(Date2) Then Return -1
    '    Dim dd1 As Integer = Date1.Day
    '    Dim mm1 As Integer = Date1.Month
    '    Dim yy1 As Integer = Date1.Year

    '    Dim dd2 As Integer = Date2.Day
    '    Dim mm2 As Integer = Date2.Month
    '    Dim yy2 As Integer = Date2.Year

    '    If (dd2 <= 0) OrElse (dd1 <= 0) OrElse _
    '       (mm2 <= 0) OrElse (mm1 <= 0) OrElse _
    '       (yy2 <= 0) OrElse (yy1 <= 0) Then _
    '        Return -1
    '    Dim diff As Long = -1

    '    Dim sgnY As Integer = 1
    '    Dim sgnM As Integer = 1
    '    Dim sgnD As Integer = 1
    '    If (yy2 < yy1) Then
    '        sgnY = sgnY * (-1)
    '        ChangeValues(yy2, yy1)
    '    ElseIf (yy2 = yy1) Then
    '        sgnY = 0
    '    End If
    '    If (mm2 < mm1) Then
    '        sgnM = sgnM * (-1)
    '        ChangeValues(mm2, mm1)
    '    ElseIf (mm2 = mm1) Then
    '        sgnM = 0
    '    End If
    '    If (dd2 < dd1) Then
    '        sgnD = sgnD * (-1)
    '        'ChangeValues(dd2, dd1)
    '    ElseIf (dd2 = dd1) Then
    '        sgnD = 0
    '    End If

    '    Select Case Interval
    '        Case DateInterval.Year
    '            diff = _
    '                sgnY * (yy2 - yy1 + sgnM * sgnM * (System.Convert.ToInt16((sgnM * sgnY - 1) / 2)) + _
    '                        (1 - sgnM * sgnM) * sgnD * sgnD * (System.Convert.ToInt16((sgnD * sgnY - 1) / 2)))
    '        Case DateInterval.Month
    '            Dim sgnYM As Integer = sgnY + (1 - sgnY * sgnY) * sgnM
    '            diff = _
    '                sgnY * (yy2 - yy1) * 12 + sgnM * (mm2 - mm1) + _
    '                sgnYM * sgnD * sgnD * (System.Convert.ToInt16((sgnD * sgnYM - 1) / 2))
    '        Case DateInterval.Day
    '            diff = System.Convert.ToInt64(-Date1.Subtract(Date2).TotalDays)
    '        Case DateInterval.Hour
    '            diff = System.Convert.ToInt64(-Date1.Subtract(Date2).TotalHours)
    '        Case DateInterval.Minute
    '            diff = System.Convert.ToInt64(-Date1.Subtract(Date2).TotalMinutes)
    '        Case DateInterval.Second
    '            diff = System.Convert.ToInt64(-Date1.Subtract(Date2).TotalSeconds)
    '        Case Else
    '            diff = DateDiff(DateInterval.Day, Date1, Date2)
    '    End Select
    '    Return diff
    'End Function

#End Region

    Private Sub CaseStatus_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        If e.Value.Equals(CLng(CaseStatus.InProgress)) AndAlso Me.ReadOnly Then
            Me.ReadOnly = False
        End If
    End Sub

    Private Sub txtLastPatientName_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        If BaseSettings.SearchDuplicatesAutomatically AndAlso (Not IsSearchMode()) AndAlso Utils.IsEmpty(txtCaseID.EditValue) AndAlso _
           ClickDuplicateSearch AndAlso _
           Not (Utils.IsEmpty(PatientInfo.txtLastName.EditValue) AndAlso _
                Utils.IsEmpty(PatientInfo.txtSecondName.EditValue) AndAlso _
                Utils.IsEmpty(PatientInfo.txtFirstName.EditValue)) Then
            btnSearch.PerformClick()
            ClickDuplicateSearch = False
        End If
    End Sub

    Private Sub HumanCaseDetail_AfterLoadData(sender As Object, e As System.EventArgs) Handles Me.AfterLoadData
        Me.CaseTestsPanel1.SamplesView = HumanCaseSamplesPanel1.SamplesList
        HumanCaseSamplesPanel1.DbService.IgnoreChanges = False
        If lpPermanentAddress.ForeignAddressMode Then
            m_Updating = True
            chkForeignAddress.Checked = True
            Application.DoEvents()
            m_Updating = False
        End If
        RefreshDiagnosis()
    End Sub

    Private Sub HumanCaseDetail_OnAfterPost(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.OnAfterPost
        If Not sender Is Me Then
            Return
        End If
        If (Not IsSearchMode()) AndAlso _
           baseDataSet.Tables.Contains(HumanCase_DB.tlbHumanCase) AndAlso _
           (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) Then
            dtEnteringDate.EditValue = baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("datModificationDate")
            If (Utils.Str(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("strCaseID")) <> _
                Utils.Str(txtCaseID.ToolTip)) Then
                If Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("strCaseID")) Then
                    txtCaseID.ToolTip = Nothing
                Else
                    txtCaseID.ToolTip = Utils.Str(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("strCaseID"))
                End If
            End If
        End If
        If (Not IsSearchMode()) AndAlso m_ShowNavigators AndAlso m_RefreshNavigator Then
            InitNavigator1()
            m_RefreshNavigator = False
        End If
        SetCaseStatusState()
    End Sub

    Private Sub LocationQueryPopUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        e.Cancel = True
    End Sub

    'Private Sub LocationButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
    '    If LockHandler() Then
    '        Try
    '            If IsSearchMode() AndAlso _
    '               (e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete) Then
    '                If dsLocation IsNot Nothing Then
    '                    dsLocation.Dispose()
    '                End If
    '                dsLocation = Nothing
    '                cbLocation.EditValue = DBNull.Value
    '                Return
    '            End If

    '            Dim locationSelectDlg As LocationSelectDialog = New LocationSelectDialog
    '            locationSelectDlg.ShowDeleteButton = False
    '            Dim params As New Dictionary(Of String, Object)
    '            params.Add("Country", eidss.model.Core.EidssSiteContext.Instance.CountryID)
    '            If (Not PatientInfo.CurrentResidence_AddressLookup.baseDataSet Is Nothing) AndAlso _
    '               (PatientInfo.CurrentResidence_AddressLookup.baseDataSet.Tables.Contains("Address")) AndAlso _
    '               (PatientInfo.CurrentResidence_AddressLookup.baseDataSet.Tables("Address").Rows.Count > 0) Then
    '                params.Add("Region", PatientInfo.CurrentResidence_AddressLookup.baseDataSet.Tables("Address").Rows(0)("idfsRegion"))
    '                params.Add("Rayon", PatientInfo.CurrentResidence_AddressLookup.baseDataSet.Tables("Address").Rows(0)("idfsRayon"))
    '                params.Add("Settlement", PatientInfo.CurrentResidence_AddressLookup.baseDataSet.Tables("Address").Rows(0)("idfsSettlement"))
    '            End If
    '            If (IsSearchMode()) Then
    '                If (Not dsLocation Is Nothing) Then params.Add("DataSet", dsLocation)
    '                params.Add("IsSearchMode", True)
    '                locationSelectDlg.ShowSaveButton = False
    '            End If

    '            Dim geoLocationId As Object = cbLocation.EditValue
    '            If Utils.IsEmpty(geoLocationId) Then
    '                geoLocationId = Nothing
    '                If IsSearchMode() Then geoLocationId = Utils.SEARCH_MODE_ID
    '            End If
    '            If (BaseFormManager.ShowModal(locationSelectDlg, FindForm, geoLocationId, Nothing, params) = True) Then

    '                Dim intGeoLocationId As Long = -1
    '                If Not Utils.IsEmpty(geoLocationId) Then
    '                    intGeoLocationId = CType(geoLocationId, Long)
    '                End If

    '                Dim r As DataRow = dtGeoLocationName.Rows.Find(intGeoLocationId)

    '                If (r Is Nothing) Then
    '                    r = dtGeoLocationName.NewRow()
    '                    r("idfGeoLocation") = intGeoLocationId
    '                    dtGeoLocationName.Rows.Add(r)
    '                End If

    '                If IsSearchMode() Then
    '                    r("GeoLocationName") = locationSelectDlg.LocationDisplayText()
    '                    dsLocation = New DataSet()
    '                    dsLocation.EnforceConstraints = False
    '                    dsLocation.Merge(locationSelectDlg.GetLocationDataSet())
    '                Else
    '                    r("GeoLocationName") = EIDSS_DbUtils.GetGeoLocaionString(intGeoLocationId)
    '                    If baseDataSet.Tables.Contains(HumanCase_DB.tlbHumanCase) AndAlso _
    '                       (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) Then
    '                        baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfPointGeoLocation") = intGeoLocationId
    '                        baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("GeoLocationName") = locationSelectDlg.LocationDisplayText()
    '                    End If
    '                End If
    '                cbLocation.EditValue = intGeoLocationId
    '            End If

    '        Finally
    '            UnlockHandler()
    '        End Try
    '    End If

    'End Sub

    Private Function IsContactRowIsCorrect(Optional ByVal index As Integer = -1, Optional ByVal showError As Boolean = True) As Boolean
        If index = -1 Then index = gvContactPeople.FocusedRowHandle
        If index < 0 Then Return True
        Dim msg As String = ""
        Dim r As DataRow = gvContactPeople.GetDataRow(index)
        If r Is Nothing Then Return True
        If (r.RowState <> DataRowState.Added) AndAlso (r.RowState <> DataRowState.Modified) Then Return True
        If Utils.IsEmpty(r("idfRootHuman")) Then
            If Not showError Then Return False
            msg = EidssMessages.Get("mbFillOrDeleteContact", "Some of the contacts for the patient are not defined. Please define or delete undefined contacts.")
            ErrorForm.ShowWarningDirect(msg)
            gvContactPeople.FocusedColumn = colName
            gvContactPeople.FocusedRowHandle = index
            Return False
        ElseIf (Not IsSearchMode()) AndAlso Utils.IsEmpty(r("idfsPersonContactType")) Then
            If Not showError Then Return False
            msg = EidssMessages.Get("mbFillOrDeleteContact", "Some of the contacts for the patient are not defined. Please define or delete undefined contacts.")
            ErrorForm.ShowWarningDirect(msg)
            gvContactPeople.FocusedColumn = colRelationType
            gvContactPeople.FocusedRowHandle = index
            Return False
        ElseIf (Not IsSearchMode()) AndAlso (Utils.Str(r("idfRootHuman")) = Utils.Str(PatientInfo.RootID)) Then
            If Not showError Then Return False
            msg = EidssMessages.Get("mbPatientCannotBeContactPerson", "Some contacts of the patient coincide with the patient. Please correct these records.")
            ErrorForm.ShowWarningDirect(msg)
            gvContactPeople.FocusedColumn = colName
            gvContactPeople.FocusedRowHandle = index
            Return False
        ElseIf Not IsSearchMode() Then
            Dim drDuplicateContact As DataRow = FindDuplicateContact(r)
            If (Not drDuplicateContact Is Nothing) Then
                If Not showError Then Return False
                msg = String.Format(EidssMessages.Get("mbContactExist", "It is not possible to create 2 records with the same contact person. The record with the contact '{0}' is already in the Contact List"), drDuplicateContact("strName"))
                ErrorForm.ShowWarningDirect(msg)
                gvContactPeople.FocusedColumn = colName
                gvContactPeople.FocusedRowHandle = index
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub ContactPeopleFocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gvContactPeople.FocusedRowChanged
        If (Not Created) OrElse m_Updating Then Return
        m_Updating = True
        Try
            If IsContactRowIsCorrect(e.PrevFocusedRowHandle) = False Then
                gvContactPeople.FocusedRowHandle = e.PrevFocusedRowHandle
            End If
        Finally
            m_Updating = False
        End Try
    End Sub

    Function ContactPeopleValidate() As Boolean
        If (Not gvContactPeople Is Nothing) AndAlso (gvContactPeople.RowCount > 0) Then
            Dim rowHandle As Integer = 0
            While (rowHandle < gvContactPeople.RowCount)
                Dim r As DataRow = gvContactPeople.GetDataRow(rowHandle)
                If (r.RowState = DataRowState.Added) OrElse (r.RowState = DataRowState.Modified) Then
                    If Utils.IsEmpty(r("idfRootHuman")) OrElse ((Not IsSearchMode()) AndAlso Utils.IsEmpty(r("idfsPersonContactType"))) Then
                        MessageForm.Show(EidssMessages.Get("mbFillOrDeleteContact", "Some of the contacts for the patient are not defined. Please define or delete undefined contacts."))
                        Return False
                        'ElseIf (Not IsSearchMode()) AndAlso (Utils.Str(r("idfRootHuman")) = Utils.Str(PatientInfo.RootID)) Then
                        '    MessageForm.Show(EidssMessages.Get("mbPatientCannotBeContactPerson", "Some contacts of the patient coincide with the patient. Please correct these records."))
                        '    Return False
                    ElseIf Not IsSearchMode() Then
                        Dim drDuplicateContact As DataRow = FindDuplicateContact(r)
                        If (Not drDuplicateContact Is Nothing) Then
                            MessageForm.Show(String.Format(EidssMessages.Get("mbContactExist", "It is not possible to create 2 records with the same contact person. The record with the contact '{0}' is already in the Contact List"), drDuplicateContact("strName")))
                            Return False
                        End If
                    End If
                End If
                rowHandle = rowHandle + 1
            End While
        End If
        Return True
    End Function

    Private Sub AddContactClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddContact.Click
        If (ContactPeopleValidate() = True) Then
            DataEventManager.Flush()
            With baseDataSet.Tables(HumanCase_DB.tlbContactedCasePerson)
                Dim r As DataRow
                r = .NewRow()
                r("idfContactedCasePerson") = BaseDbService.NewIntID()
                r("idfHumanCase") = GetKey(HumanCase_DB.tlbHumanCase, "idfCase")
                r("idfHuman") = BaseDbService.NewIntID()
                r("idfRootHuman") = DBNull.Value
                r("bitIsRootMain") = 1
                r("idfsPersonContactType") = 430000000 '"prtFamily"
                .Rows.Add(r)
            End With
            gcContactPeople.Select()
            gvContactPeople.ShowEditor()
        End If
    End Sub

    Private Function FindDuplicateContact(contactRow As DataRow) As DataRow
        If contactRow Is Nothing Then Return Nothing
        Dim duplicateRows As DataRow()
        Dim dob As DateTime = DateTime.Parse("01/01/1900")
        If (Not Utils.IsEmpty(contactRow("datDateOfBirth"))) Then dob = CDate(contactRow("datDateOfBirth"))
        Dim duplicateCondition As String = _
            String.Format("IsNull(strName, '') = '{0}' and " + _
                          "IsNull(idfsHumanGender, -200) = {1} and " + _
                          "IsNull(idfsCountry, -200) = {2} and " + _
                          "IsNull(idfsRegion, -200) = {3} and " + _
                          "IsNull(idfsRayon, -200) = {4} and " + _
                          "IsNull(idfsSettlement, -200) = {5} and " + _
                          "IsNull(strPostCode, '') = '{6}' and " + _
                          "IsNull(strStreetName, '') = '{7}' and " + _
                          "IsNull(strHouse, '') = '{8}' and " + _
                          "IsNull(strBuilding, '') = '{9}' and " + _
                          "IsNull(strApartment, '') = '{10}' and " + _
                          "IsNull(datDateofBirth, #01/01/1900#) = #{11}# and " +
                          "IsNull(idfContactedCasePerson, -1000) <> {12} ", _
                          Utils.Str(contactRow("strName")).Replace("'", "''"), _
                          Utils.Str(contactRow("idfsHumanGender"), "-200"), _
                          Utils.Str(contactRow("idfsCountry"), "-200"), _
                          Utils.Str(contactRow("idfsRegion"), "-200"), _
                          Utils.Str(contactRow("idfsRayon"), "-200"), _
                          Utils.Str(contactRow("idfsSettlement"), "-200"), _
                          Utils.Str(contactRow("strPostCode")).Replace("'", "''"), _
                          Utils.Str(contactRow("strStreetName")).Replace("'", "''"), _
                          Utils.Str(contactRow("strHouse")).Replace("'", "''"), _
                          Utils.Str(contactRow("strBuilding")).Replace("'", "''"), _
                          Utils.Str(contactRow("strApartment")).Replace("'", "''"), _
                          dob.ToString("d", DateTimeFormatInfo.InvariantInfo), _
                          Utils.Str(contactRow("idfContactedCasePerson"), "-1000") _
                         )
        duplicateRows = contactRow.Table.Select(duplicateCondition)
        If duplicateRows.Length > 0 Then
            Return duplicateRows(0)
        End If
        Return Nothing
    End Function

    Private Function FindDuplicateRootContact(rootContact As IObject) As DataRow
        Dim duplicateRows As DataRow()
        duplicateRows = baseDataSet.Tables(HumanCase_DB.tlbContactedCasePerson).Select(String.Format("idfRootHuman = {0}", rootContact.Key))
        If duplicateRows.Length > 0 Then
            Return duplicateRows(0)
        End If
        Return Nothing
    End Function

    Private Sub ContactNameButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtContactName.ButtonClick

        If ((Not e Is Nothing) AndAlso (e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)) Then
            'Glyph (Search) Button Shows Patient Search

            Dim patientForm As IBaseListPanel
            patientForm = CType(ClassLoader.LoadClass("PatientListPanel"), IBaseListPanel)
            Dim r As IObject = BaseFormManager.ShowForSelection(patientForm, FindForm, , 1024, 800)

            If Not r Is Nothing Then
                If (Not IsSearchMode()) AndAlso (Utils.Str(r.Key) = Utils.Str(PatientInfo.RootID)) Then
                    MessageForm.Show(EidssMessages.Get("errContactedPersonDuplicateRootHuman", "Selected contact coincides with the patient. Please select another one or delete contact."))
                ElseIf (Not IsSearchMode()) AndAlso Not FindDuplicateRootContact(r) Is Nothing Then
                    Dim duplicateContact As DataRow = FindDuplicateRootContact(r)
                    MessageForm.Show(String.Format(EidssMessages.Get("mbContactExist", "It is not possible to create 2 records with the same contact person. The record with the contact '{0}' is already in the Contact List"), duplicateContact("strName")))
                Else
                    Dim rContact As DataRow = gvContactPeople.GetDataRow(gvContactPeople.FocusedRowHandle)

                    If (Not rContact Is Nothing) Then
                        rContact("idfRootHuman") = r.Key
                        rContact("bitIsRootMain") = 1
                        PopulateContactInfo(r.Key, rContact)
                    End If
                    DataEventManager.Flush()
                    gvContactPeople.RefreshRow(gvContactPeople.FocusedRowHandle)
                    Dim duplicateContact As DataRow = FindDuplicateContact(rContact)
                    If Not duplicateContact Is Nothing Then
                        MessageForm.Show(String.Format(EidssMessages.Get("mbContactExist", "It is not possible to create 2 records with the same contact person. The record with the contact '{0}' is already in the Contact List"), duplicateContact("strName")))
                    End If
                End If
            End If

        Else
            ''Ellipsis Button Creates New Contact

            Dim dlgPatientDetail As PatientDetail = New PatientDetail
            Dim rContact As DataRow = gvContactPeople.GetDataRow(gvContactPeople.FocusedRowHandle)
            Dim pId As Object = rContact("idfHuman") 'gcContactPeople.FocusedView.ActiveEditor.EditValue
            If Not Utils.IsEmpty(rContact("bitIsRootMain")) AndAlso CInt(rContact("bitIsRootMain")) = 1 Then
                dlgPatientDetail.PatientInfo.CurrentResidence_AddressLookup.IsSharedAddress = True
                dlgPatientDetail.PatientInfo.Employer_AddressLookup.IsSharedAddress = True
                pId = rContact("idfRootHuman")
            End If
            If (pId Is DBNull.Value) OrElse (Utils.Str(pId) = "0") Then
                pId = Nothing
            End If
            Dim pIdIsEmpty As Boolean = Utils.IsEmpty(pId)

            If IsSearchMode() AndAlso pIdIsEmpty Then Return
            Dim hTable As New Dictionary(Of String, Object)(1)
            hTable.Add("ReadOnly", IsSearchMode())

            If BaseFormManager.ShowModal(dlgPatientDetail, FindForm, pId, Nothing, hTable) = True Then

                Dim patientId As Object = dlgPatientDetail.GetKey(Patient_DB.tlbHuman, "idfHuman")
                'Dim rContact As DataRow = gvContactPeople.GetDataRow(gvContactPeople.FocusedRowHandle)

                If (Not rContact Is Nothing) Then
                    If Utils.Str(rContact("bitIsRootMain")) = "1" Then
                        rContact("idfRootHuman") = patientId
                    Else
                        rContact("idfHuman") = patientId
                    End If
                    PopulateContactInfo(patientId, rContact)

                    DataEventManager.Flush()
                    gvContactPeople.RefreshRow(gvContactPeople.FocusedRowHandle)
                    Dim duplicateContact As DataRow = FindDuplicateContact(rContact)
                    If Not duplicateContact Is Nothing Then
                        MessageForm.Show(String.Format(EidssMessages.Get("mbContactExist", "It is not possible to create 2 records with the same contact person. The record with the contact '{0}' is already in the Contact List"), duplicateContact("strName")))
                    End If
                End If

            ElseIf (Not pIdIsEmpty) AndAlso (dlgPatientDetail.DbService.ID Is Nothing) Then

                'Dim rContact As DataRow = gvContactPeople.GetDataRow(gvContactPeople.FocusedRowHandle)

                If (Not rContact Is Nothing) Then

                    For Each col As DataColumn In rContact.Table.Columns
                        If col.ColumnName = "idfContactedCasePerson" OrElse col.ColumnName = "idfHumanCase" Then
                            Continue For
                        ElseIf col.ColumnName = "bitIsRootMain" Then
                            rContact("bitIsRootMain") = 1
                        ElseIf col.ColumnName = "idfHuman" Then
                            rContact("idfHuman") = BaseDbService.NewIntID()
                        ElseIf Not col.ReadOnly Then
                            rContact(col.ColumnName) = DBNull.Value
                        End If
                    Next
                    DataEventManager.Flush()
                    gvContactPeople.RefreshRow(gvContactPeople.FocusedRowHandle)
                End If

            End If
        End If
    End Sub

    Private Sub EditContactClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditContact.Click
        Dim nRow As Integer = gvContactPeople.FocusedRowHandle

        If (nRow < 0) Then
            MessageForm.Show(EidssMessages.Get("mbSelectContactToEdit", "Please select contact to edit first."))
            Return
        Else
            gvContactPeople.FocusedColumn = gvContactPeople.Columns(0)
            gvContactPeople.ShowEditor()

            ContactNameButtonClick(txtContactName, Nothing)
            gvContactPeople.RefreshEditor(True)
        End If
    End Sub

    Private Sub DeleteContactClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteContact.Click
        Dim nRow As Integer = gvContactPeople.FocusedRowHandle
        If (nRow < 0) Then
            MessageForm.Show(EidssMessages.Get("mbSelectContactToDelete", "Please select contact to delete first."))
            Return
        Else
            If (MessageForm.Show(EidssMessages.Get("mbSureToDeleteContact", "Are you sure you want to delete selected contact?"), EidssMessages.Get("mbConfirmation", "Confirmation"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes) Then
                gvContactPeople.DeleteRow(nRow)
                DataEventManager.Flush()
            End If
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If (bFirstInit) Then
            bFirstInit = False
            DataEventManager.Flush()
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        'CaseForm.ShowSearch = True
        Dim okToShowForSelection As Boolean = True
        Dim duplicatesList As List(Of IObject)
        Dim filter As FilterParams = New FilterParams()
        Dim staticFilter As FilterParams = New FilterParams()
        staticFilter.Add("idfCase", "<>", HumanCaseDbService.ID)
        Using New WaitDialog(EidssMessages.Get("msgHumanCaseDuplicatesSearch"))

            Dim initialDiagnosis As Object = cbDiagnosis.EditValue
            Dim diagnosis As Object = cbChangedDiagnosis.EditValue
            'If (Utils.IsEmpty(diagnosis)) Then
            '    diagnosis = cbDiagnosis.EditValue
            'End If
            If (Not Utils.IsEmpty(initialDiagnosis)) Then
                filter.Add("idfsTentativeDiagnosis", "=", initialDiagnosis)
            End If
            If (Not Utils.IsEmpty(diagnosis)) Then
                filter.Add("idfsDiagnosis", "=", diagnosis)
            End If
            If (Not Utils.IsEmpty(txtLocalID.EditValue)) Then
                filter.Add("strLocalIdentifier", "Like", txtLocalID.EditValue)
            End If
            If (Not Utils.IsEmpty(PatientInfo.txtFirstName.EditValue)) Then
                filter.Add("strFirstName", "Like", PatientInfo.txtFirstName.EditValue)
            End If
            If (Not Utils.IsEmpty(PatientInfo.txtLastName.EditValue)) Then
                filter.Add("strLastName", "Like", PatientInfo.txtLastName.EditValue)
            End If
            If (Not Utils.IsEmpty(PatientInfo.txtSecondName.EditValue)) Then
                filter.Add("strSecondName", "Like", PatientInfo.txtSecondName.EditValue)
            End If
            If (Not Utils.IsEmpty(PatientInfo.txtAge.EditValue)) Then
                filter.Add("intPatientAge", "=", PatientInfo.txtAge.EditValue)
                If (Not Utils.IsEmpty(PatientInfo.cbAgeUnits.EditValue)) Then
                    filter.Add("idfsHumanAgeType", "=", PatientInfo.cbAgeUnits.EditValue)
                End If
            End If
            filter.Add("idfCase", "<>", HumanCaseDbService.ID)
            Using manager As DbManagerProxy = DbManagerFactory.Factory.Create(ModelUserContext.Instance)
                Dim accessor As IObjectSelectList = ObjectAccessor.SelectListInterface(GetType(HumanCaseDeduplicationListItem))
                duplicatesList = accessor.SelectList(manager, filter)
            End Using

            If ClickDuplicateSearch AndAlso (duplicatesList.Count = 0) Then okToShowForSelection = False

        End Using
        If okToShowForSelection Then
            If duplicatesList.Count > 0 Then
                Dim caseForm As HumanCaseListPanel = CType(ClassLoader.LoadClass("HumanCaseListPanel"), HumanCaseListPanel)
                If (Filter.FiltersCount > 1) Then
                    Filter.Add("idfsRegion", "=", -1L)
                    Filter.Add("datEnteredDate", ">=", New Date(1900, 1, 1))
                    Filter.Add("datEnteredDate", "<=", Date.Today)
                End If
                caseForm.InitialSearchFilter = Filter
                caseForm.StaticFilter = staticFilter
                Dim r As IObject = BaseFormManager.ShowForSelection(caseForm, FindForm, Nothing, 1024, 800)
                If Not r Is Nothing Then
                    Dim CaseID As Object = r.Key
                    If Utils.Str(CaseID) <> Utils.Str(Me.GetKey(HumanCase_DB.tlbHumanCase, "idfCase")) Then
                        Me.Enabled = False
                        m_NavigatorReadOnlyMode = False
                        If (Not BaseFormManager.FindFormByID(GetType(HumanCaseDetail), CaseID) Is Nothing) Then
                            m_NavigatorReadOnlyMode = True
                        End If
                        LoadData(CaseID)
                        'DefineBinding()
                        Me.ReadOnly = m_NavigatorReadOnlyMode Or IsCaseClosed
                        Me.Enabled = True
                    End If
                Else
                    SelectLastFocusedControl()
                End If
            Else
                MessageForm.Show(EidssMessages.Get("msgNoRecords", "No records found."), EidssMessages.Get("captionHCSearchResults", "Human Case Search Results"))
                SelectLastFocusedControl()
            End If
        Else
            SelectLastFocusedControl()
        End If
    End Sub

    Private Sub HumanCaseDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If baseDataSet.Tables.Count > 0 Then
            CheckFFVisibility()
        End If
        If IsSearchMode Then SetButtonsInSearchMode() 'Else Me.SetLastSavedButtonState()
        If m_ShowNavigators Then
            If Not IsSearchMode() Then
                btnSearchHumanCase.Visible = True
                btnSearchHumanCase.Enabled = True
                btnSearch.Visible = True
                btnSearch.Enabled = True
                If eidss.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission( _
                                                    eidss.model.Enums.EIDSSPermissionObject.HumanCase)) Then
                    Me.ShowNewButton = True
                End If
            End If
        Else
            btnSearchHumanCase.Visible = False
            btnSearch.Visible = False
            Me.ShowNewButton = False
        End If
        ArrangeButtons(CancelButton.Top, "BottomButtons")
        'If baseDataSet.Tables.Count = 0 Then
        '    [ReadOnly] = True
        'End If
    End Sub

    Private Sub DiagnosisInSearchMode_Changed(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RefreshDiagnosis()
        UpdateFF()
    End Sub

    Private Sub Diagnosis_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        If IsSearchMode Then
            Return
        End If
        If Utils.IsEmpty(e.Value) Then
            baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0).BeginEdit()
            baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("datTentativeDiagnosisDate") = DBNull.Value
            baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0).EndEdit()
            'dtDiagnosisDate.EditValue = DBNull.Value
            dtDiagnosisDate.Enabled = False

            If Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsFinalDiagnosis")) Then
                baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0).BeginEdit()
                baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0).EndEdit()
            End If
        Else
            dtDiagnosisDate.Enabled = True
        End If
        SetBasisOfDiagnosisState()
        ResetFFTemplate()
        RefreshDiagnosis()
        UpdateFF()
        ''CheckFFVisibility()
    End Sub

    Private Sub cbDiagnosis_EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cbDiagnosis.EditValueChanging
        If Loading Then Return
        If (Not Utils.IsEmpty(e.NewValue)) AndAlso _
           (((Not IsSearchMode()) AndAlso _
             (Utils.Str(e.NewValue) = Utils.Str(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsFinalDiagnosis")))) OrElse _
            (IsSearchMode() AndAlso (Utils.Str(e.NewValue) = Utils.Str(cbChangedDiagnosis.EditValue)))) Then
            Dim initialDiagnosis As String = LookupCache.GetLookupValue(e.NewValue, LookupTables.HumanStandardDiagnosis, "name")
            Dim changedDiagnosis As String = IIf(IsSearchMode(), LookupCache.GetLookupValue(cbChangedDiagnosis.EditValue, LookupTables.HumanStandardDiagnosis, "name"), _
                                                 LookupCache.GetLookupValue(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsFinalDiagnosis"), LookupTables.HumanStandardDiagnosis, "name")).ToString()
            MessageForm.Show(String.Format(EidssMessages.Get("msgWrongDiagnosis"), changedDiagnosis, initialDiagnosis))
            e.Cancel = True
        ElseIf (Not IsSearchMode()) AndAlso (Not Utils.IsEmpty(e.NewValue)) Then
            SetBasisOfDiagnosisState()
        End If
    End Sub


    Private ReadOnly Property GetNotSavedDiagnosisChange() As DataRow
        Get
            If IsSearchMode() Then Return Nothing
            If baseDataSet Is Nothing Then Return Nothing
            If Not baseDataSet.Tables.Contains(HumanCase_DB.tlbChangeDiagnosisHistory) Then Return Nothing
            Dim dtDiagnosisChange As DataTable = _
                baseDataSet.Tables(HumanCase_DB.tlbChangeDiagnosisHistory).GetChanges(DataRowState.Added)
            If (Not dtDiagnosisChange Is Nothing) AndAlso (dtDiagnosisChange.Rows.Count > 0) Then
                Dim rDiagnosisChange As DataRow = baseDataSet.Tables(HumanCase_DB.tlbChangeDiagnosisHistory).Rows.Find(dtDiagnosisChange.Rows(0)("idfChangeDiagnosisHistory"))
                Return rDiagnosisChange
            End If
            Return Nothing
        End Get
    End Property

    Private Sub ChangedDiagnosisInSearchMode_Changed(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RefreshDiagnosis()
        UpdateFF()
    End Sub

    Private Sub ChangedDiagnosis_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        If IsSearchMode Then
            Return
        End If
        baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0).BeginEdit()
        baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("blnClinicalDiagBasis") = CBool(0)
        baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("blnLabDiagBasis") = CBool(0)
        baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("blnEpiDiagBasis") = CBool(0)
        baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0).EndEdit()

        If Utils.IsEmpty(e.Value) Then
            'dtChangedDiagnosisDate.EditValue = DBNull.Value
            baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0).BeginEdit()
            baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("datFinalDiagnosisDate") = DBNull.Value
            baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0).EndEdit()
            dtChangedDiagnosisDate.Enabled = False
            If Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsTentativeDiagnosis")) Then
                chbClinicalDiagBasis.Enabled = False
                chbEpiDiagBasis.Enabled = False
                chbLabDiagBasis.Enabled = False
            End If
        Else
            dtChangedDiagnosisDate.Enabled = True
        End If
        SetBasisOfDiagnosisState()

        Dim rDiagnosisChange As DataRow = GetNotSavedDiagnosisChange()
        If (Not rDiagnosisChange Is Nothing) Then
            rDiagnosisChange("datChangedDate") = DateTime.Now
            rDiagnosisChange("idfsCurrentDiagnosis") = baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsFinalDiagnosis")
            rDiagnosisChange("CurrentDiagnosisName") = LookupCache.GetLookupValue(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsFinalDiagnosis"), LookupTables.HumanStandardDiagnosis, "Name")
        End If
        ResetFFTemplate()
        RefreshDiagnosis()
        UpdateFF()
        ''CheckFFVisibility()
    End Sub

    Private Sub cbChangedDiagnosis_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cbChangedDiagnosis.ButtonClick
        If Loading Then Return
        'If e.Button.Kind <> DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph Then Return
        If IsSearchMode() OrElse (e.Button.Kind <> DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph) Then Return
        If baseDataSet.Tables(HumanCase_DB.tlbChangeDiagnosisHistory).Select("", "", DataViewRowState.CurrentRows).Length > 0 Then
            Dim frmHistory As HumanCaseDiagnosisHistory = New HumanCaseDiagnosisHistory()
            Dim params As New Dictionary(Of String, Object)

            Dim rDiagnosisChange As DataRow = GetNotSavedDiagnosisChange()

            If (Not rDiagnosisChange Is Nothing) Then
                params.Add("idfChangeDiagnosisHistory", rDiagnosisChange("idfChangeDiagnosisHistory"))
                params.Add("idfHumanCase", rDiagnosisChange("idfHumanCase"))
                params.Add("idfsPreviousDiagnosis", rDiagnosisChange("idfsPreviousDiagnosis"))
                params.Add("idfsCurrentDiagnosis", rDiagnosisChange("idfsCurrentDiagnosis"))
                params.Add("datChangedDate", rDiagnosisChange("datChangedDate"))
                params.Add("idfsChangeDiagnosisReason", rDiagnosisChange("idfsChangeDiagnosisReason"))
                params.Add("strReason", rDiagnosisChange("strReason"))
                params.Add("idfPerson", rDiagnosisChange("idfPerson"))
                params.Add("strPersonName", rDiagnosisChange("strPersonName"))
                params.Add("Organization", rDiagnosisChange("Organization"))
                params.Add("PreviousDiagnosisName", rDiagnosisChange("PreviousDiagnosisName"))
                params.Add("CurrentDiagnosisName", rDiagnosisChange("CurrentDiagnosisName"))
            End If

            Dim idfHumanCase As Object = GetKey(HumanCase_DB.tlbHumanCase, "idfCase")

            BaseFormManager.ShowModal(frmHistory, FindForm, idfHumanCase, Nothing, params)
        Else
            MessageForm.Show(EidssMessages.Get("mbEmptyChangeDiagnosisHistory", "History of diagnosis changes is empty."))
        End If

    End Sub

    Private Sub cbChangedDiagnosis_EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cbChangedDiagnosis.EditValueChanging
        If Loading Then Return
        If (Not Utils.IsEmpty(e.NewValue)) AndAlso _
           (((Not IsSearchMode()) AndAlso _
             (Utils.Str(e.NewValue) = Utils.Str(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsTentativeDiagnosis")))) OrElse _
            (IsSearchMode() AndAlso (Utils.Str(e.NewValue) = Utils.Str(cbDiagnosis.EditValue)))) Then
            Dim changedDiagnosis As String = LookupCache.GetLookupValue(e.NewValue, LookupTables.HumanStandardDiagnosis, "name")
            Dim initialDiagnosis As String = IIf(IsSearchMode(), LookupCache.GetLookupValue(cbDiagnosis.EditValue, LookupTables.HumanStandardDiagnosis, "name"), _
                                                 LookupCache.GetLookupValue(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsTentativeDiagnosis"), LookupTables.HumanStandardDiagnosis, "name")).ToString()
            MessageForm.Show(String.Format(EidssMessages.Get("msgWrongDiagnosis"), changedDiagnosis, initialDiagnosis))
            e.Cancel = True
        ElseIf (Not IsSearchMode()) AndAlso (Not Utils.IsEmpty(e.NewValue)) Then
            SetBasisOfDiagnosisState()
        End If
        'Ask for reason of the diagnosis changes
        If (e.Cancel = False) AndAlso (Not IsSearchMode()) Then
            Dim rDiagnosisChange As DataRow = GetNotSavedDiagnosisChange()
            If ((Utils.Str(e.NewValue) = _
                 Utils.Str(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsFinalDiagnosis")))) AndAlso _
               (Not rDiagnosisChange Is Nothing) Then
                rDiagnosisChange.Delete()
            ElseIf ((Utils.Str(e.NewValue) <> _
                     Utils.Str(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsFinalDiagnosis")))) AndAlso _
                   ((Me.State And BusinessObjectState.NewObject) = 0) AndAlso _
                   (rDiagnosisChange Is Nothing) Then
                Dim frmReason As HumanCaseDiagnosisChangeReason = New HumanCaseDiagnosisChangeReason
                Dim idfHumanCase As Object = GetKey(HumanCase_DB.tlbHumanCase, "idfCase")
                If (BaseFormManager.ShowModal(frmReason, FindForm, idfHumanCase, Nothing, Nothing) = True) Then
                    DataEventManager.Flush()
                    With baseDataSet.Tables(HumanCase_DB.tlbChangeDiagnosisHistory)
                        rDiagnosisChange = .NewRow()
                        rDiagnosisChange("idfChangeDiagnosisHistory") = BaseDbService.NewIntID()
                        rDiagnosisChange("idfHumanCase") = GetKey(HumanCase_DB.tlbHumanCase, "idfCase")
                        rDiagnosisChange("idfsPreviousDiagnosis") = e.OldValue
                        rDiagnosisChange("idfsCurrentDiagnosis") = e.NewValue
                        rDiagnosisChange("datChangedDate") = DateTime.Now
                        rDiagnosisChange("idfsChangeDiagnosisReason") = frmReason.Reason
                        rDiagnosisChange("strReason") = frmReason.ReasonText
                        rDiagnosisChange("idfPerson") = eidss.model.Core.EidssUserContext.User.EmployeeID
                        rDiagnosisChange("strPersonName") = eidss.model.Core.EidssUserContext.User.FullName
                        rDiagnosisChange("Organization") = EIDSS.model.Schema.OrganizationLookup.OrganizationNational
                        rDiagnosisChange("PreviousDiagnosisName") = LookupCache.GetLookupValue(e.OldValue, LookupTables.HumanStandardDiagnosis, "Name")
                        rDiagnosisChange("CurrentDiagnosisName") = LookupCache.GetLookupValue(e.NewValue, LookupTables.HumanStandardDiagnosis, "Name")
                        .Rows.Add(rDiagnosisChange)
                    End With
                Else
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    'Private Sub rgCurrentPatientLocation_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If IsSearchMode() Then Return
    '    If (Not Loading) AndAlso OkToChangeHospStatus AndAlso baseDataSet.Tables.Contains(HumanCase_DB.tlbHumanCase) AndAlso _
    '       baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0 Then
    '        OkToChangeHospStatus = False
    '        baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsHospitalizationStatus") = rgCurrentPatientLocation.EditValue
    '    End If
    '    OkToChangeHospStatus = True
    'End Sub

    Private Sub SetHospitalizationStatusVisibility(hospStatus As Object)
        cbHospitalizedTo.Visible = CLng(HospitalizationStatus.Hospital).Equals(hospStatus)
        lblHospitalizedTo.Visible = cbHospitalizedTo.Visible
        cbHospitalizedTo.Enabled = Not [ReadOnly]
        txtOtherLocation.Visible = CLng(HospitalizationStatus.Other).Equals(hospStatus)
        lblOtherLocation.Visible = txtOtherLocation.Visible
        txtOtherLocation.Enabled = Not [ReadOnly]
    End Sub
    Private Sub CurrentPatientLocationInSearchMode_Changed(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not IsSearchMode() Then Return
        If (Not Loading) AndAlso OkToChangeHospStatus Then
            OkToChangeHospStatus = False
            SetHospitalizationStatusVisibility(cbCurrentPatientLocation.EditValue)
            If Not Utils.IsEmpty(cbCurrentPatientLocation.EditValue) Then
                Dim hospStatus As HospitalizationStatus = CType(cbCurrentPatientLocation.EditValue, HospitalizationStatus)
                Select Case hospStatus
                    Case HospitalizationStatus.Home
                        cbHospitalizedTo.EditValue = DBNull.Value
                        txtOtherLocation.EditValue = DBNull.Value
                    Case HospitalizationStatus.Hospital
                        txtOtherLocation.EditValue = DBNull.Value
                    Case HospitalizationStatus.Other
                        cbHospitalizedTo.EditValue = DBNull.Value
                End Select
            Else
                cbHospitalizedTo.EditValue = DBNull.Value
                txtOtherLocation.EditValue = DBNull.Value
            End If
        End If
        OkToChangeHospStatus = True
    End Sub

    Private Sub CurrentPatientLocation_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        SetHospitalizationStatusVisibility(e.Value)
        If Not Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("strCurrentLocation")) Then
            baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("strCurrentLocation") = DBNull.Value
        End If
        If Not Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfHospital")) Then
            baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfHospital") = DBNull.Value
        End If
        Core.LookupBinder.ClearEditValueWithoutPrompt(cbHospitalizedTo)
        txtOtherLocation.EditValue = DBNull.Value
        cbHospitalizedTo.DataBindings.Clear()
        txtOtherLocation.DataBindings.Clear()
        If Not Utils.IsEmpty(e.Value) Then
            Dim hospStatus As HospitalizationStatus = CType(e.Value, HospitalizationStatus)
            Select Case hospStatus
                Case HospitalizationStatus.Hospital
                    If cbHospitalizedTo.DataBindings.Count = 0 Then
                        Core.LookupBinder.BindOrganizationLookup(cbHospitalizedTo, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfHospital", HACode.Human)
                    End If
                Case HospitalizationStatus.Other
                    If txtOtherLocation.DataBindings.Count = 0 Then
                        Core.LookupBinder.BindTextEdit(txtOtherLocation, baseDataSet, HumanCase_DB.tlbHumanCase + ".strCurrentLocation")
                    End If
            End Select
        End If
    End Sub


    Private Sub CaseClassification_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        If (IsSearchMode) Then
            Return
        End If
        If (Not Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsFinalCaseStatus"))) Then
            cbCaseClassification.EditValue = baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsFinalCaseStatus")
        ElseIf (Not Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsInitialCaseStatus"))) Then
            cbCaseClassification.EditValue = baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsInitialCaseStatus")
        Else
            Core.LookupBinder.ClearEditValueWithoutPrompt(cbCaseClassification)
        End If
        If (EidssSiteContext.Instance.IsGeorgiaCustomization) Then
            Return
        End If
        If e.Column.ColumnName = "idfsFinalCaseStatus" Then
            If (Utils.IsEmpty(e.OldValue) AndAlso Not Utils.IsEmpty(e.Value)) Then
                baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("datFinalCaseClassificationDate") = Date.Today
                baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0).EndEdit()
            End If
            UpdateFinalCaseClassificationDateState(e.Value)
        End If
    End Sub

    Private Sub UpdateFinalCaseClassificationDateState(ByVal value As Object)
        If (CLng(model.Enums.CaseClassification.Confirmed).Equals(value)) Then
            SetControlState(dtFinalCaseClassificationDate, ControlState.Mandatory, [ReadOnly])
        ElseIf Not Utils.IsEmpty(value) Then
            SetControlState(dtFinalCaseClassificationDate, ControlState.Normal, [ReadOnly])
        Else
            baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("datFinalCaseClassificationDate") = DBNull.Value
            baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0).EndEdit()
            SetControlState(dtFinalCaseClassificationDate, ControlState.Normal, True)
        End If
    End Sub

    Private Sub UpdateCurrentResidenceAddress()
        If (lpCurrentResidenceAddress Is Nothing) Then Return
        If (Not IsSearchMode()) Then
            lpCurrentResidenceAddress.UpdateAddress()
        Else
            lpCurrentResidenceAddress.RegionID = PatientInfo.CurrentResidence_AddressLookup.RegionID
            lpCurrentResidenceAddress.RayonID = PatientInfo.CurrentResidence_AddressLookup.RayonID
            lpCurrentResidenceAddress.SettlementID = PatientInfo.CurrentResidence_AddressLookup.SettlementID
            lpCurrentResidenceAddress.Street = PatientInfo.CurrentResidence_AddressLookup.Street
            lpCurrentResidenceAddress.PostalCode = PatientInfo.CurrentResidence_AddressLookup.PostalCode
            lpCurrentResidenceAddress.House = PatientInfo.CurrentResidence_AddressLookup.House
            lpCurrentResidenceAddress.Building = PatientInfo.CurrentResidence_AddressLookup.Building
            lpCurrentResidenceAddress.Apartment = PatientInfo.CurrentResidence_AddressLookup.Apartment
        End If
    End Sub

    Private Sub UpdateEmployerAddress()
        If (lpEmployerAddress Is Nothing) Then Return
        If (Not IsSearchMode()) Then
            lpEmployerAddress.UpdateAddress()
        Else
            lpEmployerAddress.RegionID = PatientInfo.Employer_AddressLookup.RegionID
            lpEmployerAddress.RayonID = PatientInfo.Employer_AddressLookup.RayonID
            lpEmployerAddress.SettlementID = PatientInfo.Employer_AddressLookup.SettlementID
            lpEmployerAddress.Street = PatientInfo.Employer_AddressLookup.Street
            lpEmployerAddress.PostalCode = PatientInfo.Employer_AddressLookup.PostalCode
            lpEmployerAddress.House = PatientInfo.Employer_AddressLookup.House
            lpEmployerAddress.Building = PatientInfo.Employer_AddressLookup.Building
            lpEmployerAddress.Apartment = PatientInfo.Employer_AddressLookup.Apartment
        End If
    End Sub

    Private Sub PatientInfo_AfterLoadData(ByVal sender As Object, ByVal e As System.EventArgs) Handles PatientInfo.AfterLoadData
        If IsSearchMode() Then
            lpCurrentResidenceAddress.ReadOnly = False
            lpCurrentResidenceAddress.ID = Utils.SEARCH_MODE_ID
            lpCurrentResidenceAddress.baseDataSet = New DataSet()
            lpCurrentResidenceAddress.baseDataSet.Merge(PatientInfo.CurrentResidence_AddressLookup.baseDataSet, False)
            lpCurrentResidenceAddress.BindAddress()
            lpCurrentResidenceAddress.ReadOnly = True

            lpEmployerAddress.ReadOnly = False
            lpEmployerAddress.ID = Utils.SEARCH_MODE_ID
            lpEmployerAddress.baseDataSet = New DataSet()
            lpEmployerAddress.baseDataSet.Merge(PatientInfo.Employer_AddressLookup.baseDataSet, False)
            lpEmployerAddress.BindAddress()
            lpEmployerAddress.ReadOnly = True
        End If
        NotificationInfo_Changed(Me, EventArgs.Empty)
    End Sub

    Private Sub PatientInfo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles PatientInfo.Load
        OkToChangeAge = False
        If IsSearchMode() Then
            DxControlsHelper.ShowButtonEditButton(PatientInfo.cbAgeUnits, ButtonPredefines.Delete)
        Else
            DxControlsHelper.HideButtonEditButton(PatientInfo.cbAgeUnits, ButtonPredefines.Delete)
        End If
        PatientInfo.txtAge.Visible = True
        PatientInfo.cbAgeUnits.Visible = True
        'PatientInfo.txtAge.Enabled = txtAge.Enabled
        'PatientInfo.cbAgeUnits.Enabled = cbAgeUnits.Enabled
        'If (Not IsSearchMode()) Then _
        '    PatientInfo.txtAge.EditValue = baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("intPatientAge")
        'If (Not IsSearchMode()) Then _
        '    PatientInfo.cbAgeUnits.EditValue = baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsHumanAgeType")
        AddHandler PatientInfo.txtAge.EditValueChanged, AddressOf Age_EditValueChanged
        AddHandler PatientInfo.txtAge.EditValueChanging, AddressOf Age_EditValueChanging
        AddHandler PatientInfo.cbAgeUnits.EditValueChanged, AddressOf AgeUnits_EditValueChanged
        OkToChangeAge = True
    End Sub

    Private Sub Age_EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs)
        Dim OkToCancel As Boolean = False
        If Not Utils.IsEmpty(e.NewValue) Then
            Try
                Dim NewVal As Integer = System.Convert.ToInt16(e.NewValue)
                If NewVal < 0 Then OkToCancel = True
            Catch ex As Exception
                OkToCancel = True
            End Try
        End If
        e.Cancel = OkToCancel
    End Sub

    Private Sub Age_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'If OkToChangeAge Then
        '    If Utils.IsEmpty(PatientInfo.txtAge.EditValue) Then
        '        txtAge.EditValue = DBNull.Value
        '        If (Not IsSearchMode()) Then
        '            baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0).BeginEdit()
        '            baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("intPatientAge") = txtAge.EditValue
        '            baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0).EndEdit()
        '        End If
        '        If Not Utils.IsEmpty(PatientInfo.cbAgeUnits.EditValue) Then
        '            PatientInfo.cbAgeUnits.EditValue = DBNull.Value
        '            cbAgeUnits.EditValue = DBNull.Value
        '            If (Not IsSearchMode()) Then
        '                baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0).BeginEdit()
        '                baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsHumanAgeType") = cbAgeUnits.EditValue
        '                baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0).EndEdit()
        '            End If
        '        End If
        '    Else
        '        Try
        '            txtAge.EditValue = System.Convert.ToInt16(PatientInfo.txtAge.EditValue)
        '            If (Not IsSearchMode()) Then
        '                baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0).BeginEdit()
        '                baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("intPatientAge") = txtAge.EditValue
        '                baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0).EndEdit()
        '            End If
        '            If Utils.IsEmpty(PatientInfo.cbAgeUnits.EditValue) Then
        '                PatientInfo.cbAgeUnits.EditValue = 10042003 '"hatYears"
        '                cbAgeUnits.EditValue = 10042003 '"hatYears"
        '                If (Not IsSearchMode()) Then
        '                    baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0).BeginEdit()
        '                    baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsHumanAgeType") = cbAgeUnits.EditValue
        '                    baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0).EndEdit()
        '                End If
        '            End If
        '        Catch ex As Exception
        '        End Try
        '    End If
        'End If
        NotificationInfo_Changed(sender, e)
    End Sub

    Private Sub AgeUnits_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If OkToChangeAge AndAlso Not Loading Then cbAgeUnits.EditValue = PatientInfo.cbAgeUnits.EditValue
        NotificationInfo_Changed(sender, e)
    End Sub

    Private Sub btnSearchHumanCase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchHumanCase.Click
        Dim CaseForm As IBaseListPanel
        CaseForm = CType(ClassLoader.LoadClass("HumanCaseListPanel"), IBaseListPanel)

        'CaseForm.DbService.ListFilterCondition = ""
        'CaseForm.DbService.ListFromCondition = ""
        'Dim dtDuplicateHumanCaseList As DataTable = CaseForm.DbService.GetList.Tables(0)

        'If (dtDuplicateHumanCaseList.Rows.Count > 0) Then
        Dim CaseID As Object
        Dim r As IObject = BaseFormManager.ShowForSelection(CaseForm, FindForm, , 1024, 800)
        If Not r Is Nothing Then
            CaseID = r.GetValue("idfCase")
            m_ClosingMode = ClosingMode.Cancel
            If (Utils.Str(CaseID) <> Utils.Str(Me.GetKey(HumanCase_DB.tlbHumanCase, "idfCase"))) AndAlso (Post(PostType.FinalPosting)) Then
                Me.Enabled = False
                m_NavigatorReadOnlyMode = False
                If (Not BaseFormManager.FindFormByID(GetType(HumanCaseDetail), CaseID) Is Nothing) Then
                    m_NavigatorReadOnlyMode = True
                End If
                LoadData(CaseID)
                'DefineBinding()
                Me.ReadOnly = m_NavigatorReadOnlyMode Or IsCaseClosed
                Me.Enabled = True
            End If
        Else
            SelectLastFocusedControl()
        End If
        'Else
        'win.MessageForm.Show(EidssMessages.Get("msgNoRecords", "No records found."), EidssMessages.Get("captionHCSearchResults", "Human Case Search Results"))
        'SelectLastFocusedControl()
        'End If
    End Sub

    Dim LabelColLeft As New ArrayList(3)
    Dim LabelColWidth As New ArrayList(3)
    Dim CtrlColLeft As New ArrayList(3)
    Dim CtrlColWidth As New ArrayList(3)
    Private Sub GetAddressColumnPositions()
        If (LabelColLeft.Count > 0) Then
            Exit Sub
        End If
        LabelColLeft.Add(lbPersonalIdType.Left - 1)
        LabelColLeft.Add(lbPersonalID.Left - 1)
        LabelColLeft.Add(lblPatronymic.Left - 1)

        LabelColWidth.Add(lbPersonalIdType.Width)
        LabelColWidth.Add(lbPersonalID.Width)
        LabelColWidth.Add(lblPatronymic.Width)

        CtrlColLeft.Add(txtPersonalIdType.Left - 1)
        CtrlColLeft.Add(txtPersonalID.Left - 1)
        CtrlColLeft.Add(txtSecondName.Left - 1)

        CtrlColWidth.Add(txtPersonalIdType.Width)
        CtrlColWidth.Add(txtPersonalID.Width)
        CtrlColWidth.Add(txtSecondName.Width)



    End Sub
    Private Sub lpCurrentResidenceAddress_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles lpCurrentResidenceAddress.Load
        If WinUtils.IsComponentInDesignMode(Me) Then
            Return
        End If
        GetAddressColumnPositions()
        'Dim LabelColLeft As New ArrayList(3)
        'LabelColLeft.Add(lbPersonalIdType.Left - 1)
        'LabelColLeft.Add(lbPersonalID.Left - 1)
        'LabelColLeft.Add(lblPatronymic.Left - 1)

        'Dim LabelColWidth As New ArrayList(3)
        'LabelColWidth.Add(lbPersonalIdType.Width)
        'LabelColWidth.Add(lbPersonalID.Width)
        'LabelColWidth.Add(lblPatronymic.Width)

        'Dim CtrlColLeft As New ArrayList(3)
        'CtrlColLeft.Add(txtPersonalIdType.Left - 1)
        'CtrlColLeft.Add(txtPersonalID.Left - 1)
        'CtrlColLeft.Add(txtSecondName.Left - 1)

        'CtrlColWidth.Add(txtPersonalIdType.Width)
        'CtrlColWidth.Add(txtPersonalID.Width)
        'CtrlColWidth.Add(txtSecondName.Width)

        Dim lpHeight As Integer = lpCurrentResidenceAddress.Height '56 '2 * (txtDOB.Top - txtLastName.Top) + (txtDOB.Height - txtLastName.Height) + 8
        lpCurrentResidenceAddress.UpdateView(gpDemographicInfo.Width - 6, lpHeight, LabelColLeft, LabelColWidth, CtrlColLeft, CtrlColWidth, System.Drawing.ContentAlignment.MiddleLeft)
    End Sub


    Private Sub lpPermanentAddress_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles lpPermanentAddress.Load
        If WinUtils.IsComponentInDesignMode(Me) Then
            Return
        End If
        GetAddressColumnPositions()
        'Dim LabelColLeft As New ArrayList(3)
        'LabelColLeft.Add(lblDOB.Left - 1)
        'LabelColLeft.Add(lblFirstName.Left - 1)
        'LabelColLeft.Add(lblPatronymic.Left - 1)

        'Dim LabelColWidth As New ArrayList(3)
        'LabelColWidth.Add(lblDOB.Width)
        'LabelColWidth.Add(lblFirstName.Width)
        'LabelColWidth.Add(lblPatronymic.Width)

        'Dim CtrlColLeft As New ArrayList(3)
        'CtrlColLeft.Add(txtLastName.Left - 1)
        'CtrlColLeft.Add(txtFirstName.Left - 1)
        'CtrlColLeft.Add(txtSecondName.Left - 1)

        'Dim CtrlColWidth As New ArrayList(3)
        'CtrlColWidth.Add(txtLastName.Width)
        'CtrlColWidth.Add(txtFirstName.Width)
        'CtrlColWidth.Add(txtSecondName.Width)

        Dim lpHeight As Integer = lpPermanentAddress.Height '56 '2 * (txtDOB.Top - txtLastName.Top) + (txtDOB.Height - txtLastName.Height) + 8
        lpPermanentAddress.UpdateView(gpDemographicInfo.Width - 6, lpHeight, LabelColLeft, LabelColWidth, CtrlColLeft, CtrlColWidth, System.Drawing.ContentAlignment.MiddleLeft)
    End Sub

    Private Sub lpEmployerAddress_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles lpEmployerAddress.Load
        If WinUtils.IsComponentInDesignMode(Me) Then
            Return
        End If
        GetAddressColumnPositions()

        'Dim LabelColLeft As New ArrayList(3)
        'LabelColLeft.Add(lblDOB.Left - 1)
        'LabelColLeft.Add(lblFirstName.Left - 1)
        'LabelColLeft.Add(lblPatronymic.Left - 1)

        'Dim LabelColWidth As New ArrayList(3)
        'LabelColWidth.Add(lblDOB.Width)
        'LabelColWidth.Add(lblFirstName.Width)
        'LabelColWidth.Add(lblPatronymic.Width)

        'Dim CtrlColLeft As New ArrayList(3)
        'CtrlColLeft.Add(txtLastName.Left - 1)
        'CtrlColLeft.Add(txtFirstName.Left - 1)
        'CtrlColLeft.Add(txtSecondName.Left - 1)

        'Dim CtrlColWidth As New ArrayList(3)
        'CtrlColWidth.Add(txtLastName.Width)
        'CtrlColWidth.Add(txtFirstName.Width)
        'CtrlColWidth.Add(txtSecondName.Width)

        Dim lpHeight As Integer = 56 '2 * (txtDOB.Top - txtLastName.Top) + (txtDOB.Height - txtLastName.Height) + 8
        lpEmployerAddress.UpdateView(gpDemographicInfo.Width - 6, lpHeight, LabelColLeft, LabelColWidth, CtrlColLeft, CtrlColWidth, System.Drawing.ContentAlignment.MiddleLeft)
    End Sub

    Private Sub cbOutbreakID_QueryPopUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbOutbreakID.QueryPopUp
        e.Cancel = True
    End Sub

    Private Sub cbOutbreakID_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cbOutbreakID.ButtonClick
        If (e Is Nothing) Then Return
        If LockHandler() Then
            Try
                ' save form before choosing outbreak
                If (e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph) Or (e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis) Then
                    If Not Post() Then Return
                End If

                If (e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph) Then
                    'Glyph (Search) Button Shows Outbreak Search
                    Dim OutbreakForm As IBaseListPanel
                    OutbreakForm = CType(ClassLoader.LoadClass("OutbreakListPanel"), IBaseListPanel)

                    Dim r As IObject = BaseFormManager.ShowForSelection(OutbreakForm, FindForm, , 1024, 800)
                    If Not r Is Nothing Then
                        Dim item As OutbreakListItem = CType(r, OutbreakListItem)
                        SetOutbreak(sender, r.Key, r.GetValue("strOutbreakID"), r.GetValue("idfsDiagnosisOrDiagnosisGroup"), r.GetValue("strDiagnosisOrDiagnosisGroup"), r.GetValue("idfsDiagnosisGroup"), r.GetValue("strDiagnosisGroup"))
                        DataEventManager.Flush()
                    End If

                ElseIf (e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis) Then
                    ''Ellipsis Button Creates New Outbreak

                    Dim pID As Object = cbOutbreakID.EditValue
                    Dim pIdIsEmpty As Boolean = Utils.IsEmpty(pID)

                    If pIdIsEmpty Then
                        If Not eidss.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission(eidss.model.Enums.EIDSSPermissionObject.Outbreak)) Then
                            MessageForm.Show(BvMessages.Get("msgNoInsertPermission", "You have no rights to create this object"))
                            Return
                        End If
                        pID = Nothing
                    ElseIf Not eidss.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(eidss.model.Enums.EIDSSPermissionObject.Outbreak)) Then
                        MessageForm.Show(BvMessages.Get("msgNoSelectPermission", "You have no rights to view this form"))
                        Return
                    End If

                    If IsSearchMode() AndAlso pIdIsEmpty Then Return

                    Dim dlgOutbreakDetail As OutbreakDetail = New OutbreakDetail

                    Dim hTable As New Dictionary(Of String, Object)(3)
                    hTable.Add("CanAddViewRemove", False)
                    hTable.Add("ReadOnly", IsSearchMode())
                    hTable.Add("idfHumanCase", GetListItem())


                    If BaseFormManager.ShowModal(dlgOutbreakDetail, FindForm, pID, Nothing, hTable) AndAlso Not Utils.IsEmpty(dlgOutbreakDetail.GetKey("Outbreak", "strOutbreakID")) Then
                        Dim idfsDiagnosisOrDiagnosisGroup As Object = dlgOutbreakDetail.GetKey("Outbreak", "idfsDiagnosisOrDiagnosisGroup")
                        Dim strDiagnosisOrDiagnosisGroup As String = LookupCache.GetLookupValue(idfsDiagnosisOrDiagnosisGroup, LookupTables.DiagnosesAndGroups.ToString, "Name")
                        Dim idfsDiagnosisGroup As String = LookupCache.GetLookupValue(idfsDiagnosisOrDiagnosisGroup, LookupTables.DiagnosesAndGroups.ToString, "idfsDiagnosisGroup")
                        Dim strDiagnosisGroup As String = LookupCache.GetLookupValue(idfsDiagnosisGroup, LookupTables.DiagnosesAndGroups.ToString, "Name")

                        SetOutbreak(sender, dlgOutbreakDetail.GetKey(), _
                                    dlgOutbreakDetail.GetKey("Outbreak", "strOutbreakID"), _
                                    idfsDiagnosisOrDiagnosisGroup, _
                                    strDiagnosisOrDiagnosisGroup, _
                                    idfsDiagnosisGroup, _
                                    strDiagnosisGroup, _
                                    baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0 AndAlso Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfOutbreak")))
                        DataEventManager.Flush()

                    ElseIf Not pIdIsEmpty AndAlso dlgOutbreakDetail.DbService.ID Is Nothing AndAlso _
                           (IsSearchMode() OrElse baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) Then

                        SetOutbreak(sender, DBNull.Value)

                    End If

                ElseIf (e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete) Then
                    If (Not IsSearchMode()) AndAlso (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) Then
                        If Not baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfOutbreak") Is DBNull.Value Then
                            If WinUtils.ConfirmMessage(EidssMessages.Get("msgRemoveCaseFromOutbreak", "Remove case from outbreak?"), EidssMessages.Get("msgRemoveConfirmation", "Remove confirnmation?")) Then

                                SetOutbreak(sender, DBNull.Value)

                            End If
                        End If
                    End If
                End If
            Finally
                UnlockHandler()
            End Try
        End If

    End Sub

    Function GetListItem() As IObject
        Dim filter As FilterParams = New FilterParams()
        filter.Add("idfCase", "=", baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfCase"))
        Dim humList As List(Of IObject)
        Using manager As DbManagerProxy = DbManagerFactory.Factory.Create(ModelUserContext.Instance)
            Dim accessor As IObjectSelectList = ObjectAccessor.SelectListInterface(GetType(HumanCaseListItem))
            humList = accessor.SelectList(manager, filter)
        End Using
        Return humList(0)
    End Function

    Private Sub SetOutbreak(ByVal sender As Object, ByVal idfOutbreak As Object, _
                            Optional ByVal strOutbreakID As Object = "", _
                            Optional ByVal idfsDiagnosis As Object = -1, _
                            Optional ByVal strDiagnosisOrDiagnosisGroup As Object = "", _
                            Optional ByVal idfsDiagnosisGroup As Object = -1, _
                            Optional ByVal strDiagnosisGroup As Object = "", _
                            Optional ByVal bSetTable As Boolean = True)
        ' check diagnoses connection before
        If Not idfOutbreak Is DBNull.Value Then

            Dim idfsCaseDiagnosis As Long = HumanCaseDbService.CheckOutbreakDiagnosis(idfOutbreak)
            If idfsCaseDiagnosis = 0 Then
                MessageForm.Show(
                    String.Format(EidssMessages.Get("msgOutbreakDiagnosisErrorCases", "Case/session {0} cannot be added to the outbreak {1}. Diagnosis of the case/session must be the same as the diagnosis of the outbreak or be included to the diagnoses group of the outbreak. Outbreak’s diagnosis/diagnoses group is {2}."), baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("strCaseID"), strOutbreakID, strDiagnosisOrDiagnosisGroup),
                    EidssMessages.Get("ErrErrorFormCaption"), MessageBoxButtons.OK)
                Return
            ElseIf (idfsCaseDiagnosis > 0) Then

                If Not WinUtils.ConfirmMessage(String.Format(EidssMessages.Get("msgUpOutbreakDiagnosisToGroup", "Outbreak diagnosis {0} and diagnosis of the case/session {1} {2} are not equal, but are included to the same diagnoses group {3}. Do you want to enter {3} as outbreak diagnosis?"), strDiagnosisOrDiagnosisGroup, baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("strCaseID"), txtFinalDiagnosis.Text, strDiagnosisGroup)) Then Return
                HumanCase_DB.ChangeOutbreakDiagnosis(idfOutbreak, idfsDiagnosisGroup)
            End If
        End If

        If (Not IsSearchMode AndAlso bSetTable) Then
            baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0).BeginEdit()
            baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfOutbreak") = idfOutbreak
            baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0).EndEdit()
        End If

        If TypeOf sender Is DevExpress.XtraEditors.LookUpEdit Then
            CType(sender, DevExpress.XtraEditors.LookUpEdit).EditValue = idfOutbreak
        ElseIf TypeOf sender Is DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit Then
            CType(sender, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit).OwnerEdit.EditValue = idfOutbreak
        End If
    End Sub


    Private Sub HospitalizationInSearchMode_Changed(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not Utils.IsEmpty(cbHospitalization.EditValue) Then
            Dim Hospitalization As String = Utils.Str(cbHospitalization.EditValue)
            Select Case Hospitalization
                Case "10100002" '"ynvNo"
                    deDateOfAdmissionHospitalization.EditValue = DBNull.Value
                    txtHospital.EditValue = DBNull.Value
                    deDateOfAdmissionHospitalization.Enabled = False
                    txtHospital.Enabled = False
                Case "10100003" '"ynvUnknown"
                    deDateOfAdmissionHospitalization.EditValue = DBNull.Value
                    txtHospital.EditValue = DBNull.Value
                    deDateOfAdmissionHospitalization.Enabled = False
                    txtHospital.Enabled = False
                Case Else
                    deDateOfAdmissionHospitalization.Enabled = True
                    txtHospital.Enabled = True
            End Select
        Else
            'deDateOfAdmissionHospitalization.Enabled = True
            'txtHospital.Enabled = True
            deDateOfAdmissionHospitalization.EditValue = DBNull.Value
            txtHospital.EditValue = DBNull.Value
            deDateOfAdmissionHospitalization.Enabled = False
            txtHospital.Enabled = False
        End If
    End Sub

    Private Sub Hospitalization_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        If Not Utils.IsEmpty(cbHospitalization.EditValue) Then
            Dim Hospitalization As String = Utils.Str(e.Value)
            Select Case Hospitalization
                Case "10100002" '"ynvNo"
                    baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("datHospitalizationDate") = DBNull.Value
                    baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("strHospitalizationPlace") = DBNull.Value
                    deDateOfAdmissionHospitalization.EditValue = DBNull.Value
                    txtHospital.EditValue = DBNull.Value
                    deDateOfAdmissionHospitalization.Enabled = False
                    txtHospital.Enabled = False
                Case "10100003" '"ynvUnknown"
                    baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("datHospitalizationDate") = DBNull.Value
                    baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("strHospitalizationPlace") = DBNull.Value
                    deDateOfAdmissionHospitalization.EditValue = DBNull.Value
                    txtHospital.EditValue = DBNull.Value
                    deDateOfAdmissionHospitalization.Enabled = False
                    txtHospital.Enabled = False
                Case Else
                    deDateOfAdmissionHospitalization.Enabled = True
                    txtHospital.Enabled = True
            End Select
        Else
            'deDateOfAdmissionHospitalization.Enabled = True
            'txtHospital.Enabled = True
            baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("datHospitalizationDate") = DBNull.Value
            baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("strHospitalizationPlace") = DBNull.Value
            deDateOfAdmissionHospitalization.EditValue = DBNull.Value
            txtHospital.EditValue = DBNull.Value
            deDateOfAdmissionHospitalization.Enabled = False
            txtHospital.Enabled = False
        End If
    End Sub

    Private Sub cbHospitalization_EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cbHospitalization.EditValueChanging
        If (Not CType(sender, Control).Visible) OrElse Loading Then Return
        If (Utils.Str(e.NewValue, "10100003") <> "10100001") Then ' default value = "10100003" = "ynvUnknown", "10100001" = "ynvYes"
            'If IsSearchMode() AndAlso Not (Utils.IsEmpty(deDateOfAdmissionHospitalization.EditValue) AndAlso Utils.IsEmpty(txtHospital.EditValue)) Then
            '    e.Cancel = Not (MessageForm.Show(EidssMessages.Get("mbSureToClearHosp", "There is some information on hospitalization. Are you sure you want to clear it?"), EidssMessages.Get("mbConfirmation", "Confirmation"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes)
            'End If
            If (Not IsSearchMode()) AndAlso Not (Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("datHospitalizationDate")) AndAlso _
               Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("strHospitalizationPlace"))) Then
                e.Cancel = Not (MessageForm.Show(EidssMessages.Get("mbSureToDisableHosp", "There is some information on hospitalization. Are you sure you want to delete it?"), EidssMessages.Get("mbConfirmation", "Confirmation"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes)
            End If
        End If
    End Sub

    Private Sub AntimicrobialTherapyInSearchMode_Changed(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not Utils.IsEmpty(cbAntimicrobialTherapy.EditValue) Then
            Dim AntimicrobualTherapy As String = Utils.Str(cbAntimicrobialTherapy.EditValue)
            Select Case AntimicrobualTherapy
                Case "10100002" '"ynvNo"
                    gcAntimicrobialTherapy.Enabled = False
                    gvAntimicrobialTherapy.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                    btnRemoveAntimicrobialTherapy.Enabled = False
                Case "10100003" '"ynvUnknown"
                    gcAntimicrobialTherapy.Enabled = False
                    gvAntimicrobialTherapy.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                    btnRemoveAntimicrobialTherapy.Enabled = False
                Case Else
                    gcAntimicrobialTherapy.Enabled = True
                    gvAntimicrobialTherapy.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
                    btnRemoveAntimicrobialTherapy.Enabled = True
            End Select
        Else
            gcAntimicrobialTherapy.Enabled = False
            gvAntimicrobialTherapy.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            btnRemoveAntimicrobialTherapy.Enabled = False
        End If
    End Sub

    Private Sub AntimicrobialTherapy_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        If IsSearchMode Then
            Return
        End If
        If Not Utils.IsEmpty(cbAntimicrobialTherapy.EditValue) Then
            Dim AntimicrobualTherapy As String = Utils.Str(e.Value)
            Select Case AntimicrobualTherapy
                Case "10100002" '"ynvNo"
                    gcAntimicrobialTherapy.Enabled = False
                    gvAntimicrobialTherapy.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                    btnRemoveAntimicrobialTherapy.Enabled = False
                Case "10100003" '"ynvUnknown"
                    gcAntimicrobialTherapy.Enabled = False
                    gvAntimicrobialTherapy.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                    btnRemoveAntimicrobialTherapy.Enabled = False
                Case Else
                    gcAntimicrobialTherapy.Enabled = True
                    gvAntimicrobialTherapy.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
                    btnRemoveAntimicrobialTherapy.Enabled = True
            End Select
        Else
            gcAntimicrobialTherapy.Enabled = False
            gvAntimicrobialTherapy.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            btnRemoveAntimicrobialTherapy.Enabled = False
        End If
    End Sub

    Private Sub cbAntimicrobialTherapy_EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cbAntimicrobialTherapy.EditValueChanging
        If (Not CType(sender, Control).Visible) OrElse Loading Then Return
        If IsSearchMode Then
            Return
        End If
        'If (Not IsSearchMode()) AndAlso (Utils.Str(e.NewValue, "ynvUnknown") <> "ynvYes") AndAlso _

        'default value = "10100003" = "ynvUnknown", "10100001" = "ynvYes"
        If (Utils.Str(e.NewValue, "10100003") <> "10100001") AndAlso _
           (TableNotDelRowCount(baseDataSet.Tables(HumanCase_DB.tlbAntimicrobialTherapy)) > 0) Then
            MessageForm.Show(EidssMessages.Get("mbCannotDeleteAllAntibiotics", "It is impossible to disable the table of antibiotic or antiviral therapy because it contains some records."))
            e.Cancel = True
        ElseIf e.NewValue.Equals(LookupCache.EmptyLineKey) Then
            Core.LookupBinder.OnClear(sender, e)
        End If
    End Sub

    Function gvAntimicrobialTherapy_Validate() As Boolean
        If IsSearchMode Then
            Return True
        End If
        If (Not gvAntimicrobialTherapy Is Nothing) AndAlso (gvAntimicrobialTherapy.RowCount > 0) Then
            For rowHandle As Integer = 0 To gvAntimicrobialTherapy.RowCount - 1
                If Not IsAntimicrobialTherapyRowValid(rowHandle, True) Then
                    BringUpCurrentTab(gcAntimicrobialTherapy)
                    gcAntimicrobialTherapy.Select()
                    Return False
                End If
            Next
        End If
        Return True
    End Function
    Private Sub gvAntimicrobialTherapy_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) _
        Handles gvAntimicrobialTherapy.CellValueChanged
        UpdateAntimicrobialTherapyState()
    End Sub

    Private Sub gvAntimicrobialTherapy_FocusedRowChanged(ByVal sender As Object, ByVal e As FocusedRowChangedEventArgs) _
        Handles gvAntimicrobialTherapy.FocusedRowChanged
        If Loading OrElse m_Updating Then Return
        m_Updating = True
        Try
            If e.PrevFocusedRowHandle >= 0 AndAlso IsAntimicrobialTherapyRowValid(e.PrevFocusedRowHandle) = False Then
                gvAntimicrobialTherapy.FocusedRowHandle = e.PrevFocusedRowHandle
                Return
            End If
        Finally
            UpdateAntimicrobialTherapyState()
            m_Updating = False
        End Try
    End Sub
    Private Sub gvAntimicrobialTherapy_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles gvAntimicrobialTherapy.InitNewRow
        Dim row As DataRow = gvAntimicrobialTherapy.GetDataRow(e.RowHandle)
        row("idfAntimicrobialTherapy") = BaseDbService.NewIntID()
        row("idfHumanCase") = GetKey(HumanCase_DB.tlbHumanCase, "idfCase")
    End Sub
    Public Sub UpdateAntimicrobialTherapyState()
        Dim rowSelected As Boolean = gvAntimicrobialTherapy.FocusedRowHandle <> GridControl.NewItemRowHandle AndAlso
                                     Not gvAntimicrobialTherapy.GetFocusedDataRow() Is Nothing
        btnRemoveAntimicrobialTherapy.Enabled = Not [ReadOnly] AndAlso rowSelected
        gvAntimicrobialTherapy.OptionsBehavior.Editable = Not [ReadOnly]
        EnableAntimicrobialTherapyRowAdding(Not [ReadOnly] AndAlso IsAntimicrobialTherapyRowValid(, False))
    End Sub
    Private Function IsAntimicrobialTherapyRowValid(Optional ByVal index As Integer = -1, Optional ByVal showError As Boolean = True) As Boolean
        If IsSearchMode Then
            Return True
        End If
        If index = -1 Then index = gvAntimicrobialTherapy.FocusedRowHandle
        Dim row As DataRow = gvAntimicrobialTherapy.GetDataRow(index)
        If row Is Nothing Then Return True
        If Utils.IsEmpty(row("strAntimicrobialTherapyName")) Then
            If showError Then
                WinUtils.ShowMandatoryError(gcolAntimicrobialTherapyName.Caption)
            End If
            Return False
        End If
        Return True
    End Function

    Public Sub EnableAntimicrobialTherapyRowAdding(enable As Boolean)
        If (gvAntimicrobialTherapy.FocusedRowHandle = GridControl.NewItemRowHandle) Then
            Return
        End If
        If (Not enable) Then
            gvAntimicrobialTherapy.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        Else
            gvAntimicrobialTherapy.OptionsView.NewItemRowPosition = NewItemRowPosition.Top
        End If
    End Sub

    Private Sub btnRemoveAntimicrobialTherapy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoveAntimicrobialTherapy.Click
        Dim nRow As Integer = gvAntimicrobialTherapy.FocusedRowHandle
        If (nRow < 0) Then
            'If (Not IsSearchMode()) Then MessageForm.Show(EidssMessages.Get("mbSelectTherapyToRemove", "Please select therapy to remove first."))
            MessageForm.Show(EidssMessages.Get("mbSelectAntibioticToRemove", "Please select antibiotic to remove first."))
            Return
        ElseIf (MessageForm.Show(EidssMessages.Get("mbSureToRemoveAntibiotic", "Are you sure you want to remove selected antibiotic?"), EidssMessages.Get("mbConfirmation", "Confirmation"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes) Then
            gvAntimicrobialTherapy.DeleteRow(nRow)
            DataEventManager.Flush()
        End If
    End Sub

    Private Sub RelatedToOutbreakInSearchMode_Changed(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not Utils.IsEmpty(cbOutbreakExists.EditValue) Then
            Dim RelatedToOutbreak As String = Utils.Str(cbOutbreakExists.EditValue)
            Select Case RelatedToOutbreak
                Case "10100002" '"ynvNo"
                    cbOutbreakID.EditValue = DBNull.Value
                    cbOutbreakID.Enabled = False
                Case "10100003" '"ynvUnknown"
                    cbOutbreakID.EditValue = DBNull.Value
                    cbOutbreakID.Enabled = False
                Case Else
                    cbOutbreakID.Enabled = True
            End Select
        Else
            'cbOutbreakID.Enabled = True
            cbOutbreakID.EditValue = DBNull.Value
            cbOutbreakID.Enabled = False
        End If
    End Sub

    Private Sub RelatedToOutbreak_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        If Not Utils.IsEmpty(cbOutbreakExists.EditValue) Then
            Dim RelatedToOutbreak As String = Utils.Str(e.Value)
            Select Case RelatedToOutbreak
                Case "10100002" '"ynvNo"
                    If (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) Then
                        baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfOutbreak") = DBNull.Value
                        cbOutbreakID.EditValue = DBNull.Value
                    End If
                    cbOutbreakID.Enabled = False
                Case "10100003" '"ynvUnknown"
                    If (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) Then
                        baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfOutbreak") = DBNull.Value
                        cbOutbreakID.EditValue = DBNull.Value
                    End If
                    cbOutbreakID.Enabled = False
                Case Else
                    cbOutbreakID.Enabled = True
            End Select
        Else
            'cbOutbreakID.Enabled = True
            If (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) Then
                baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfOutbreak") = DBNull.Value
                cbOutbreakID.EditValue = DBNull.Value
            End If
            cbOutbreakID.Enabled = False
        End If
    End Sub

    Private Sub cbOutbreakExists_EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cbOutbreakExists.EditValueChanging
        If (Not CType(sender, Control).Visible) OrElse Loading Then Return

        'default value = "10100003" = "ynvUnknown", "10100001" = "ynvYes"
        If (Utils.Str(e.NewValue, "10100003") <> "10100001") Then
            If IsSearchMode() AndAlso (Not Utils.IsEmpty(cbOutbreakID.EditValue)) Then
                e.Cancel = Not (MessageForm.Show(EidssMessages.Get("mbSureToClearOutbreakID", "Outbreak ID is not empty. Are you sure you want to clear it?"), EidssMessages.Get("mbConfirmation", "Confirmation"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes)
            End If
            If (Not IsSearchMode()) AndAlso (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) AndAlso _
               (Not Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfOutbreak"))) Then
                e.Cancel = Not (MessageForm.Show(EidssMessages.Get("mbSureToRemoveFromOutbreak", "This case is related to an outbreak. Are you sure you want to remove it from outbreak?"), EidssMessages.Get("mbConfirmation", "Confirmation"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes)
            End If
        End If
    End Sub

    Private Sub SetMandatory(ctl As BaseControl)
        If (TypeOf (ctl.Tag) Is TagHelper) Then
            CType(ctl.Tag, TagHelper).IsMandatory = True
            SetControlReadOnly(ctl, False, False)
        Else
            ctl.Tag = "{M}"
        End If
        SetControlMandatoryState(ctl)
    End Sub

    Private Sub UpdateNotCollectedReason(ByVal IsActivate As Boolean, Optional ByVal DoUpdateView As Boolean = False)
        If (cbNotCollectedReason.Visible = Not IsActivate) OrElse DoUpdateView Then
            cbNotCollectedReason.DataBindings.Clear()
            lblNotCollectedReason.Visible = IsActivate
            cbNotCollectedReason.Visible = IsActivate
            If IsActivate Then
                If (Not IsSearchMode()) Then
                    Core.LookupBinder.BindBaseLookup(cbNotCollectedReason, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfsNotCollectedReason", db.BaseReferenceType.rftNotCollectedReason, True)
                    If Not [ReadOnly] Then SetMandatory(cbNotCollectedReason)
                End If
                HumanCaseSamplesPanel1.UpdateHumanCaseSamplesPanel_View(cbNotCollectedReason.Top - 8)
            Else
                If (Not IsSearchMode()) AndAlso (baseDataSet.Tables.Contains(HumanCase_DB.tlbHumanCase)) AndAlso _
                   (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) AndAlso _
                   (Not Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsNotCollectedReason"))) Then _
                    baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsNotCollectedReason") = DBNull.Value
                Core.LookupBinder.ClearEditValueWithoutPrompt(cbNotCollectedReason)
                If Not [ReadOnly] Then ApplyControlState(cbNotCollectedReason, ControlState.Normal)
                HumanCaseSamplesPanel1.UpdateHumanCaseSamplesPanel_View(cbSpecimenCollected.Top - 8)
            End If
        End If
    End Sub

    Private Sub SpecimenCollectedInSearchMode_Changed(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not Utils.IsEmpty(cbSpecimenCollected.EditValue) Then
            Dim SpecimenCollected As String = Utils.Str(cbSpecimenCollected.EditValue)
            Select Case SpecimenCollected
                Case "10100002" '"ynvNo"
                    HumanCaseSamplesPanel1.ReadOnly = True
                    UpdateNotCollectedReason(True)
                Case "10100003" '"ynvUnknown"
                    UpdateNotCollectedReason(False)
                    HumanCaseSamplesPanel1.ReadOnly = True
                Case Else
                    UpdateNotCollectedReason(False)
                    'HumanCaseSamplesPanel1.IsReadOnly = True
                    HumanCaseSamplesPanel1.ReadOnly = False
            End Select
        Else
            UpdateNotCollectedReason(False)
            'HumanCaseSamplesPanel1.IsReadOnly = False
            HumanCaseSamplesPanel1.ReadOnly = True
        End If
    End Sub

    Private Sub SpecimenCollected_Changed(ByVal sender As System.Object, ByVal e As DataFieldChangeEventArgs)
        If Not Utils.IsEmpty(cbSpecimenCollected.EditValue) Then
            Dim SpecimenCollected As String = Utils.Str(e.Value)
            Select Case SpecimenCollected
                Case "10100002" '"ynvNo"
                    'If (TableNotDelRowCount(HumanCaseSamplesPanel1.baseDataSet.Tables(CaseTestsDetail_Db2.TablesEnum.Materials)) > 0) Then
                    'HumanCaseSamplesPanel1.ClearAllSamples()
                    'End If
                    HumanCaseSamplesPanel1.ReadOnly = True
                    UpdateNotCollectedReason(True)
                Case "10100003" '"ynvUnknown"
                    UpdateNotCollectedReason(False)
                    HumanCaseSamplesPanel1.ReadOnly = True
                Case Else
                    UpdateNotCollectedReason(False)
                    HumanCaseSamplesPanel1.ReadOnly = False
            End Select
        Else
            UpdateNotCollectedReason(False)
            'HumanCaseSamplesPanel1.IsReadOnly = False
            HumanCaseSamplesPanel1.ReadOnly = True
        End If
    End Sub

    Private Sub cbSpecimenCollected_EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles cbSpecimenCollected.EditValueChanging
        'If (Not IsSearchMode()) AndAlso (Utils.Str(e.NewValue, "ynvUnknown") <> "ynvYes") AndAlso _
        If (Not CType(sender, Control).Visible) OrElse Loading Then Return

        'default value = "10100003" = "ynvUnknown", "10100001" = "ynvYes"
        If (Utils.Str(e.NewValue, "10100003") <> "10100001") AndAlso _
               (HumanCaseSamplesPanel1.baseDataSet.Tables.Count > HumanCaseSamplesDetail_DB.TablesEnum.Materials) AndAlso _
               ((SamplesCount(HumanCaseSamplesPanel1.baseDataSet.Tables(HumanCaseSamplesDetail_DB.TablesEnum.Materials)) > 0)) Then
            e.Cancel = True
            MessageForm.Show(EidssMessages.Get("mbCannotDeleteAllSpecimens", "It is impossible to disable Samples table because it contains some records."))
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Dim msg As String = EidssMessages.Get("msgConfirmClearForm", "Clear the form content?")
        If (Not IsSearchMode()) AndAlso (Not HumanCaseDbService.IsNewObject) Then
            msg = EidssMessages.Get("msgConfirmCancelChangesForm", "Return the form to the last saved state?")
        End If
        If MessageForm.Show(msg, "", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
            SelectLastFocusedControl()
            Return
        End If
        Me.Enabled = False
        OkToUpdateDOBAndAge = False
        m_FocusOnFirstPage = False
        If (Not IsSearchMode()) AndAlso HumanCaseDbService.IsNewObject Then
            LoadData(Nothing)
        Else
            LoadData(HumanCaseDbService.ID)
        End If
        PatientInfo.cbAgeUnits.EditValue = cbAgeUnits.EditValue
        'DefineBinding()
        OkToUpdateDOBAndAge = True
        Me.Enabled = True
    End Sub

    Private Sub HumanCaseSamplesPanel1_AfterLoadData(ByVal sender As Object, ByVal e As System.EventArgs) Handles HumanCaseSamplesPanel1.AfterLoadData
        If Not IsSearchMode() Then
            If (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) Then
                Select Case Utils.Str(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsYNSpecimenCollected"), "10100003") '"ynvUnknown"
                    Case "10100002" '"ynvNo"
                        UpdateNotCollectedReason(True, True)
                        HumanCaseSamplesPanel1.ReadOnly = True
                    Case "10100003" '"ynvUnknown"
                        HumanCaseSamplesPanel1.ReadOnly = True
                        UpdateNotCollectedReason(False, True)
                    Case Else
                        If Not [ReadOnly] Then
                            HumanCaseSamplesPanel1.ReadOnly = False
                        End If
                        UpdateNotCollectedReason(False, True)
                End Select
            End If
        Else
            Select Case Utils.Str(cbSpecimenCollected.EditValue, "10100003") '"ynvUnknown"
                Case "10100002" '"ynvNo"
                    UpdateNotCollectedReason(True, True)
                    HumanCaseSamplesPanel1.ReadOnly = True
                Case "10100003" '"ynvUnknown"
                    HumanCaseSamplesPanel1.ReadOnly = True
                    UpdateNotCollectedReason(False, True)
                Case Else
                    HumanCaseSamplesPanel1.ReadOnly = False
                    UpdateNotCollectedReason(False, True)
            End Select
        End If
    End Sub

    Private Sub HumanCaseSamplesPanel1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles HumanCaseSamplesPanel1.Load
        '"10100002" = "ynvNo", "10100003" = "ynvUnknown"
        If ((Not IsSearchMode()) AndAlso _
            ((baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count = 0) OrElse _
             (Utils.Str(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsYNSpecimenCollected"), "10100003") <> "10100002"))) OrElse _
           (IsSearchMode() AndAlso (Utils.IsEmpty(cbSpecimenCollected.EditValue) OrElse (Utils.Str(cbSpecimenCollected.EditValue, "10100003") <> "10100002"))) Then
            HumanCaseSamplesPanel1.UpdateHumanCaseSamplesPanel_View(cbSpecimenCollected.Top - 8)
        Else
            HumanCaseSamplesPanel1.UpdateHumanCaseSamplesPanel_View(cbNotCollectedReason.Top - 8)
        End If
    End Sub

#Region "Search Mode"
    Private Sub AddRemoveHandlersBefore()
        AddHandler deDateOfDischarge.EditValueChanged, AddressOf NotificationInfo_Changed
        AddHandler PatientInfo.OnFieldInfoChanged, AddressOf NotificationInfo_Changed
        AddHandler txtLocalID.EditValueChanged, AddressOf NotificationInfo_Changed
        AddHandler dtLastVisitToEmployer.EditValueChanged, AddressOf NotificationInfo_Changed
        AddHandler dtReportingDate.EditValueChanged, AddressOf NotificationInfo_Changed
        AddHandler cbHospitalizedTo.EditValueChanged, AddressOf NotificationInfo_Changed
        AddHandler deOnsetDate.EditValueChanged, AddressOf NotificationInfo_Changed

        RemoveHandler cbRepSource.EditValueChanged, AddressOf NotificationInfo_Changed
        RemoveHandler dtDiagnosisDate.EditValueChanged, AddressOf NotificationInfo_Changed
        RemoveHandler dtChangedDiagnosisDate.EditValueChanged, AddressOf NotificationInfo_Changed
        RemoveHandler cbDiagnosis.EditValueChanged, AddressOf DiagnosisInSearchMode_Changed
        RemoveHandler cbChangedDiagnosis.EditValueChanged, AddressOf ChangedDiagnosisInSearchMode_Changed

        RemoveHandler PatientInfo.txtFirstName.EditValueChanged, AddressOf Me.UpdatePatientName
        RemoveHandler PatientInfo.txtSecondName.EditValueChanged, AddressOf Me.UpdatePatientName
        RemoveHandler PatientInfo.txtLastName.EditValueChanged, AddressOf Me.UpdatePatientName

        RemoveHandler PatientInfo.dtpDOB.Leave, AddressOf Me.Check_BR
        RemoveHandler dtStartDate.Leave, AddressOf Me.Check_BR
        RemoveHandler dtReportingDate.Leave, AddressOf Me.Check_BR
        RemoveHandler dtFormCompletionDate.Leave, AddressOf Me.Check_BR
        RemoveHandler deOnsetDate.Leave, AddressOf Me.Check_BR
        RemoveHandler dtDiagnosisDate.Leave, AddressOf Me.Check_BR
        RemoveHandler dtChangedDiagnosisDate.Leave, AddressOf Me.Check_BR
        RemoveHandler dtLastVisitToEmployer.Leave, AddressOf Me.Check_BR
        RemoveHandler cbCurrentPatientLocation.EditValueChanged, AddressOf CurrentPatientLocationInSearchMode_Changed
        'RemoveHandler cbHospitalization.EditValueChanged, AddressOf HospitalizationInSearchMode_Changed
        'RemoveHandler cbAntimicrobialTherapy.EditValueChanged, AddressOf AntimicrobialTherapyInSearchMode_Changed
        'RemoveHandler cbOutbreakExists.EditValueChanged, AddressOf RelatedToOutbreakInSearchMode_Changed
        RemoveHandler cbSpecimenCollected.EditValueChanged, AddressOf SpecimenCollectedInSearchMode_Changed
    End Sub

    Private Sub BindLocationInSearchMode()
        cbGeoLocation.UseMandatoryFields = False
        If baseDataSet.Tables.Contains(HumanCase_DB.tlbHumanCase) AndAlso _
           (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) Then
            cbGeoLocation.Bind(baseDataSet, HumanCase_DB.tlbHumanCase + ".idfPointGeoLocation")
        End If
    End Sub

    Private Sub BindHeaderInSearchMode()
        txtCaseID.DataBindings.Clear()
        ''
        txtCaseID.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default
        txtCaseID.Properties.ReadOnly = False
        txtCaseID.Enabled = True
        ''
        txtCaseID.TabStop = True
        txtCaseID.EditValue = DBNull.Value

        dtStartDate.DataBindings.Clear()
        dtStartDate.Properties.Buttons.Clear()
        dtStartDate.Properties.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo))
        dtStartDate.Enabled = True
        dtStartDate.TabStop = True
        dtStartDate.EditValue = DBNull.Value

        dtEnteringDate.DataBindings.Clear()
        dtEnteringDate.Properties.Buttons.Clear()
        dtEnteringDate.Properties.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo))
        dtEnteringDate.Enabled = True
        dtEnteringDate.TabStop = True
        dtEnteringDate.EditValue = DBNull.Value

        Core.LookupBinder.BindBaseLookup(cbCaseStatus, baseDataSet, Nothing, db.BaseReferenceType.rftCaseProgressStatus, False, True)
        Core.LookupBinder.BindDiagnosisHACodeLookup(cbCurrentDiagnosis, baseDataSet, LookupTables.HumanStandardDiagnosis, Nothing, , False)
        SetControlReadOnly(cbCurrentDiagnosis, False, False)
        ApplyControlState(cbCurrentDiagnosis, ControlState.Normal)
        Core.LookupBinder.BindBaseLookup(cbCaseClassification, baseDataSet, Nothing, db.BaseReferenceType.rftCaseClassification, HACode.Human, False)
        SetControlReadOnly(cbCaseClassification, False, False)
        ApplyControlState(cbCaseClassification, ControlState.Normal)
        Core.LookupBinder.BindOrganizationLookup(cbEnteredByOrganization, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfOfficeEnteredBy", HACode.All, False)
        SetControlReadOnly(cbEnteredByOrganization, False, False)
        ApplyControlState(cbEnteredByOrganization, ControlState.Normal)
        Core.LookupBinder.BindPersonLookup(cbEnteredByName, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfPersonEnteredBy", HACode.Human, False, False)
        SetControlReadOnly(cbEnteredByName, False, False)
        ApplyControlState(cbEnteredByName, ControlState.Normal)
        eventManager.AttachDataHandler(HumanCase_DB.tlbHumanCase + ".idfOfficeEnteredBy", AddressOf EnteredByOffice_Changed)
        eventManager.AttachDataHandler(HumanCase_DB.tlbHumanCase + ".idfPersonEnteredBy", AddressOf EnteredByPerson_Changed)
        Core.LookupBinder.SetPersonFilter(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0), "idfOfficeEnteredBy", cbEnteredByName, True)

    End Sub


    Private Sub EnteredByPerson_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        ResetPersonOrganization(e.Value, e.Row, "idfOfficeEnteredBy")
    End Sub
    Private Sub EnteredByOffice_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        e.Row("idfPersonEnteredBy") = DBNull.Value
        e.Row.EndEdit()
        Core.LookupBinder.SetPersonFilter(e.Row, "idfOfficeEnteredBy", cbEnteredByName, True, )
    End Sub

    Private Sub BindDiagnosisInSearchMode()

        Core.LookupBinder.BindDiagnosisHACodeLookup(cbDiagnosis, baseDataSet, LookupTables.HumanStandardDiagnosis, Nothing)
        dtDiagnosisDate.DataBindings.Clear()
        dtDiagnosisDate.EditValue = DBNull.Value

        DxControlsHelper.HideButtonEditButton(cbDiagnosis, ButtonPredefines.Delete)


        dtChangedDiagnosisDate.DataBindings.Clear()
        dtChangedDiagnosisDate.EditValue = DBNull.Value
        Core.LookupBinder.BindDiagnosisHACodeLookup(cbChangedDiagnosis, baseDataSet, LookupTables.HumanStandardDiagnosis, Nothing)

        DxControlsHelper.HideButtonEditButton(cbChangedDiagnosis, ButtonPredefines.Glyph)

        RefreshDiagnosis()
    End Sub

    Private Sub BindSectionAboveDemographicInSearchMode()
        dtFormCompletionDate.DataBindings.Clear()
        dtFormCompletionDate.EditValue = DBNull.Value
        txtLocalID.DataBindings.Clear()
        txtLocalID.EditValue = DBNull.Value
    End Sub

    Private Sub BindAgeInSearchMode()
        txtAge.Enabled = True
        txtAge.DataBindings.Clear()
        txtAge.EditValue = DBNull.Value

        If (Not PatientInfo Is Nothing) AndAlso (Not PatientInfo.txtAge Is Nothing) Then
            OkToChangeAge = False
            PatientInfo.txtAge.Enabled = True
            PatientInfo.txtAge.EditValue = txtAge.EditValue
            OkToChangeAge = True
        End If

        cbAgeUnits.Enabled = True
        Core.LookupBinder.BindHumanAgeUnits(cbAgeUnits, baseDataSet, Nothing, PersonalDataGroup.None, True)
        DxControlsHelper.HideButtonEditButton(cbAgeUnits, ButtonPredefines.Delete)
        cbAgeUnits.Visible = False
        If (Not PatientInfo Is Nothing) AndAlso (Not PatientInfo.cbAgeUnits Is Nothing) Then
            OkToChangeAge = False
            If (Not m_IsAgePersonalData) Then
                PatientInfo.cbAgeUnits.Enabled = True
                Core.LookupBinder.BindHumanAgeUnits(PatientInfo.cbAgeUnits, baseDataSet, Nothing, PersonalDataGroup.None, True)
            End If
            OkToChangeAge = True
        End If
    End Sub

    Private Sub BindDemographicSectionInSearchMode()
        BindAgeInSearchMode()
        dtLastVisitToEmployer.DataBindings.Clear()
        dtLastVisitToEmployer.EditValue = DBNull.Value
    End Sub

    Private Sub BindClinicalSectionInSearchMode()
        deOnsetDate.DataBindings.Clear()
        deOnsetDate.EditValue = DBNull.Value

        Core.LookupBinder.BindBaseLookup(cbFinalState, baseDataSet, Nothing, db.BaseReferenceType.rftPatientState, False)

        Core.LookupBinder.BindBaseLookup(cbCurrentPatientLocation, baseDataSet, Nothing, db.BaseReferenceType.rftHospStatus, False)

        cbHospitalizedTo.DataBindings.Clear()
        txtOtherLocation.DataBindings.Clear()

        memoNote.DataBindings.Clear()
        memoNote.EditValue = DBNull.Value
    End Sub

    Private Sub BindGeneralSectionInSearchMode()
        dtReportingDate.DataBindings.Clear()
        dtReportingDate.EditValue = DBNull.Value
        Core.LookupBinder.BindPersonLookup(cbSentByName, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfSentByPerson", HACode.Human, False, False)
        Core.LookupBinder.BindOrganizationLookup(cbRepSource, baseDataSet, Nothing, HACode.All, False)
        Core.LookupBinder.BindPersonLookup(cbReceivedByName, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfReceivedByPerson", HACode.Human, False, False)
        Core.LookupBinder.BindOrganizationLookup(cbReceivedInst, baseDataSet, Nothing, HACode.All, False)
    End Sub

    Private Sub BindNotificationInSearchMode()
        BindSectionAboveDemographicInSearchMode()
        BindDiagnosisInSearchMode()
        BindDemographicSectionInSearchMode()
        BindClinicalSectionInSearchMode()
        BindGeneralSectionInSearchMode()
    End Sub

    Private Sub BindCISectionAboveDemographicInSearchMode()
        'cbInvOrganization.DataBindings.Clear()
        Core.LookupBinder.BindOrganizationLookup(cbInvOrganization, baseDataSet, Nothing, HACode.Human, False)

        dtInvestigationStartDate.DataBindings.Clear()
        dtInvestigationStartDate.EditValue = DBNull.Value
    End Sub

    Private Sub BindCIDemographicSectionInSearchMode()
        ''TODO: lpCurrentResidenceAddress.DataBindings.Clear() ???

        lpPermanentAddress.DataBindings.Clear()

        txtRegistrationPhone.DataBindings.Clear()
        txtRegistrationPhone.EditValue = DBNull.Value
        Core.LookupBinder.BindBaseLookup(cbOccupation, baseDataSet, Nothing, bv.common.db.BaseReferenceType.rftOccupationType, False)
        chkUseSameAddress.Visible = False
        txtWorkPhone.DataBindings.Clear()
        txtWorkPhone.EditValue = DBNull.Value
    End Sub

    Private Sub BindAntimicrobialTherapyInSearchMode()
        Core.LookupBinder.BindBaseLookup(cbAntimicrobialTherapy, baseDataSet, Nothing, bv.common.db.BaseReferenceType.rftYesNoValue, False)
        RemoveHandler cbAntimicrobialTherapy.EditValueChanging, AddressOf Core.LookupBinder.OnClear
        'gcAntimicrobialTherapy
        gcAntimicrobialTherapy.DataSource = baseDataSet.Tables(HumanCase_DB.tlbAntimicrobialTherapy).DefaultView
        'If (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) Then
        '    If (Utils.Str(cbAntimicrobialTherapy.EditValue, "10100003") <> "10100001") Then ' default value = 10100003 = "ynvUnknown", 10100001 = "ynvYes"
        '        gcAntimicrobialTherapy.Enabled = False
        '        btnAddAntimicrobialTherapy.Enabled = False
        '        btnRemoveAntimicrobialTherapy.Enabled = False
        '    Else
        gcAntimicrobialTherapy.Enabled = True
        gvAntimicrobialTherapy.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        btnRemoveAntimicrobialTherapy.Enabled = True
        '    End If
        'End If
        gvAntimicrobialTherapy.OptionsNavigation.BeginUpdate()
        gvAntimicrobialTherapy.OptionsNavigation.AutoFocusNewRow = True
        gvAntimicrobialTherapy.OptionsNavigation.EndUpdate()
        gcolAntimicrobialTherapyName.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

    End Sub

    Private Sub BindCIClinicalSectionInSearchMode()
        Core.LookupBinder.BindStandardLookup(cbInitialCaseClassification, baseDataSet, Nothing, LookupTables.InitialCaseClassification, False)
        deDateOfxposure.DataBindings.Clear()
        deDateOfxposure.EditValue = DBNull.Value
        cbFacilitySoughtCare.DataBindings.Clear()
        Core.LookupBinder.ClearEditValueWithoutPrompt(cbFacilitySoughtCare)
        deDatePatientFirstSought.DataBindings.Clear()
        deDatePatientFirstSought.EditValue = DBNull.Value

        'cbNonNotifiableDiesease
        Core.LookupBinder.BindBaseLookup(cbNonNotifiableDiesease, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfsNonNotifiableDiagnosis", db.BaseReferenceType.rftNonNotifiableDiagnosis, True)

        Core.LookupBinder.BindBaseLookup(cbHospitalization, baseDataSet, Nothing, bv.common.db.BaseReferenceType.rftYesNoValue, False)

        txtHospital.DataBindings.Clear()
        txtHospital.EditValue = DBNull.Value
        deDateOfAdmissionHospitalization.DataBindings.Clear()
        deDateOfAdmissionHospitalization.EditValue = DBNull.Value
        'If (Utils.Str(cbHospitalization.EditValue, "ynvUnknown") <> "ynvYes") Then
        '    deDateOfAdmissionHospitalization.Enabled = False
        '    txtHospital.Enabled = False
        'Else
        '    deDateOfAdmissionHospitalization.Enabled = True
        '    txtHospital.Enabled = True
        'End If

        BindLocationInSearchMode()

        BindAntimicrobialTherapyInSearchMode()

        meClinicalComments.DataBindings.Clear()
        meClinicalComments.EditValue = DBNull.Value
    End Sub

    Private Sub BindCISpecimenSectionInSearchMode()
        'TODO: Add Samples In Search Mode'HumanCaseSamplesPanel1.DefaultPartyID = HumanCaseDbService.PatientID
        'TODO: Add Samples In Search Mode'HumanCaseSamplesPanel1.SetSamplesView = AddressOf CaseTestsPanel1.SetSpecimeLookupView
        'TODO: Add Samples In Search Mode' 'HumanCaseSamplesPanel1.IsReadOnly = True

        Core.LookupBinder.BindBaseLookup(cbSpecimenCollected, baseDataSet, Nothing, bv.common.db.BaseReferenceType.rftYesNoValue, False)

    End Sub

    Private Sub BindCIContactSectionInSearchMode()
        If EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_Contact_Details) Then
            m_ConatactPersonalDataGroup = PersonalDataGroup.Human_Contact_Details
        ElseIf EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_Contact_Settlement) Then
            m_ConatactPersonalDataGroup = PersonalDataGroup.Human_Contact_Settlement
        End If
        If (m_ConatactPersonalDataGroup <> PersonalDataGroup.None) Then
            DisableContactDataEditing()
            Return
        End If

        'Core.LookupBinder.BindPatientRepositoryLookup(cbPatient)

        'Core.LookupBinder.BindPatientAdditionalInfoRepositoryLookup(cbPatientAddress)

        Core.LookupBinder.BindBaseRepositoryLookup(cbContactType, bv.common.db.BaseReferenceType.rftContact_Type, HACode.All, False)
        cbContactType.Columns("name").Caption = EidssMessages.Get("colRelation", "Relation")

        'gcContactPeople.DataSource = Nothing
        'gcContactPeople.Enabled = False
        'btnAddContact.Enabled = False
        'btnEditContact.Enabled = False
        'btnDeleteContact.Enabled = False

        'gvContactPeople.OptionsNavigation.BeginUpdate()
        'gvContactPeople.OptionsNavigation.AutoFocusNewRow = True
        'gvContactPeople.OptionsNavigation.EndUpdate()

        'gcContactPeople
        gcContactPeople.DataSource = baseDataSet.Tables(HumanCase_DB.tlbContactedCasePerson)
        gvContactPeople.OptionsNavigation.BeginUpdate()
        gvContactPeople.OptionsNavigation.AutoFocusNewRow = True
        gvContactPeople.OptionsNavigation.EndUpdate()
        ''TODO: Remove: colName.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

        btnEditContact.Text = EidssMessages.Get("mbViewContactDetails", "View Contact Details")
        btnEditContact.Image = My.Resources.View1
    End Sub

    Private Sub BindCISummarySectionInSearchMode()
        Core.LookupBinder.BindBaseLookup(lueFinalCaseClassification, baseDataSet, Nothing, bv.common.db.BaseReferenceType.rftCaseClassification, HACode.Human, False)
        dtFinalCaseClassificationDate.DataBindings.Clear()
        dtFinalCaseClassificationDate.EditValue = DBNull.Value

        Core.LookupBinder.BindBaseLookup(cbOutcome, baseDataSet, Nothing, bv.common.db.BaseReferenceType.rftOutcome, False)

        deDateOfDischarge.DataBindings.Clear()
        deDateOfDischarge.EditValue = DBNull.Value
        deDateOfDeath.DataBindings.Clear()
        deDateOfDeath.EditValue = DBNull.Value
        dtFinalDiagnosisDate.DataBindings.Clear()
        dtFinalDiagnosisDate.EditValue = DBNull.Value
        SetControlReadOnly(dtFinalDiagnosisDate, False, False)
        ApplyControlState(dtFinalDiagnosisDate, ControlState.Normal)


        Core.LookupBinder.BindBaseLookup(cbOutbreakExists, baseDataSet, Nothing, bv.common.db.BaseReferenceType.rftYesNoValue, False)

        Core.LookupBinder.BindOutbreakLookup(cbOutbreakID, baseDataSet, Nothing)
        cbOutbreakID.EditValue = DBNull.Value
        DxControlsHelper.HideButtonEditButton(cbOutbreakID, ButtonPredefines.Ellipsis)

        meSummaryComments.DataBindings.Clear()
        meSummaryComments.EditValue = DBNull.Value
        'txtEpidemiologistsName.DataBindings.Clear()
        'txtEpidemiologistsName.EditValue = DBNull.Value
        Core.LookupBinder.BindPersonLookup(cbEpidemiologistName, baseDataSet, HumanCase_DB.tlbHumanCase + ".idfInvestigatedByPerson", HACode.Human, False, False)

        RefreshCaseClassification()
    End Sub

    Private Sub BindCaseInvestigationInSearchMode()
        BindCISectionAboveDemographicInSearchMode()
        BindCIDemographicSectionInSearchMode()
        BindCIClinicalSectionInSearchMode()
        BindCISpecimenSectionInSearchMode()
        BindCIContactSectionInSearchMode()
        BindCISummarySectionInSearchMode()
    End Sub

    Private m_LastShowDeleteButton As Boolean = True
    Private m_LastShowOkButton As Boolean = True
    Private m_LastShowCancelButton As Boolean = True
    Private m_LastShowSaveButton As Boolean = True
    Private m_LastShowNewButton As Boolean = True
    Private m_LastShowClearButton As Boolean = True
    Private m_LastShowSearchInHumanCaseListButton As Boolean = True
    Private m_LastShowSearchDuplicateButton As Boolean = True
    Private m_LastShowReportButton As Boolean = True
    Private m_LastShowSearchInBrowseModeButton As Boolean = False
    Private m_LastShowTestTabPage As Boolean = True
    'TODO: /*Search Mode*/ Remove after sample panel is implemented for search in browse mode
    Private m_LastShowSampleTabPage As Boolean = True

    Private Sub SaveButtonState()
        m_LastShowDeleteButton = Me.ShowDeleteButton
        m_LastShowOkButton = Me.ShowOkButton
        m_LastShowCancelButton = Me.ShowCancelButton
        m_LastShowSaveButton = Me.ShowSaveButton
        m_LastShowNewButton = Me.ShowNewButton
        m_LastShowClearButton = btnClear.Visible
        m_LastShowSearchInHumanCaseListButton = btnSearchHumanCase.Visible
        m_LastShowSearchDuplicateButton = btnSearch.Visible
        m_LastShowReportButton = PopUpButton2.Visible
        m_LastShowSearchInBrowseModeButton = btnSearchInBrowseMode.Visible
        m_LastShowTestTabPage = TabControl1.TabPages.Contains(tpTests)
        'TODO: /*Search Mode*/ Remove after sample panel is implemented for search in browse mode
        m_LastShowSampleTabPage = tcCaseInvestigation.TabPages.Contains(tpSamples)
    End Sub

    Private Sub SetLastSavedButtonState()
        Me.ShowDeleteButton = m_LastShowDeleteButton
        Me.ShowOkButton = m_LastShowOkButton
        Me.ShowCancelButton = m_LastShowCancelButton
        Me.ShowSaveButton = m_LastShowSaveButton
        Me.ShowNewButton = m_LastShowNewButton
        btnClear.Visible = m_LastShowClearButton
        btnSearchHumanCase.Visible = m_LastShowSearchInHumanCaseListButton
        btnSearch.Visible = m_LastShowSearchDuplicateButton
        PopUpButton2.Visible = m_LastShowReportButton
        btnSearchInBrowseMode.Visible = m_LastShowSearchInBrowseModeButton
        If m_LastShowTestTabPage Then
            If Not TabControl1.TabPages.Contains(tpTests) Then
                TabControl1.TabPages.Add(tpTests)
            End If
        ElseIf TabControl1.TabPages.Contains(tpTests) Then
            TabControl1.TabPages.Remove(tpTests)
        End If
        'TODO: /*Search Mode*/ Remove after sample panel is implemented for search in browse mode
        If m_LastShowSampleTabPage Then
            If Not tcCaseInvestigation.TabPages.Contains(tpSamples) Then
                tcCaseInvestigation.TabPages.Add(tpSamples)
            End If
        ElseIf tcCaseInvestigation.TabPages.Contains(tpSamples) Then
            tcCaseInvestigation.TabPages.Remove(tpSamples)
        End If
    End Sub

    Private Sub SetButtonsInSearchMode()
        SaveButtonState()
        Me.ShowDeleteButton = False
        Me.ShowOkButton = False
        Me.ShowCancelButton = True
        Me.ShowSaveButton = False
        Me.ShowNewButton = False
        btnClear.Visible = True
        btnSearchHumanCase.Visible = False
        btnSearch.Visible = False
        PopUpButton2.Visible = False
        btnSearchInBrowseMode.Visible = True
        If TabControl1.TabPages.Contains(tpTests) Then
            TabControl1.TabPages.Remove(tpTests)
        End If
        'TODO: /*Search Mode*/ Remove after sample panel is implemented for search in browse mode
        If tcCaseInvestigation.TabPages.Contains(tpSamples) Then
            tcCaseInvestigation.TabPages.Remove(tpSamples)
        End If
    End Sub

    Private Sub AddRemoveHandlersAfter()
        AddHandler cbDiagnosis.EditValueChanged, AddressOf DiagnosisInSearchMode_Changed
        AddHandler cbChangedDiagnosis.EditValueChanged, AddressOf ChangedDiagnosisInSearchMode_Changed

        AddHandler PatientInfo.dtpDOB.Leave, AddressOf Me.Check_BR
        AddHandler dtStartDate.Leave, AddressOf Me.Check_BR
        AddHandler dtReportingDate.Leave, AddressOf Me.Check_BR
        AddHandler dtFormCompletionDate.Leave, AddressOf Me.Check_BR
        AddHandler deOnsetDate.Leave, AddressOf Me.Check_BR
        AddHandler dtDiagnosisDate.Leave, AddressOf Me.Check_BR
        AddHandler dtChangedDiagnosisDate.Leave, AddressOf Me.Check_BR
        AddHandler dtLastVisitToEmployer.Leave, AddressOf Me.Check_BR
        'AddHandler HumanCaseSamplesPanel1.evDateChanged, AddressOf Me.Check_BR
        'AddHandler HumanCaseSamplesPanel1.evSentDateChanged, AddressOf Me.Check_BR
        'AddHandler HumanCaseSamplesPanel1.evReceivedByLabDateChanged, AddressOf Me.Check_BR

        AddHandler cbCurrentPatientLocation.EditValueChanged, AddressOf CurrentPatientLocationInSearchMode_Changed

        'AddHandler cbHospitalization.EditValueChanged, AddressOf HospitalizationInSearchMode_Changed
        ' AddHandler cbAntimicrobialTherapy.EditValueChanged, AddressOf AntimicrobialTherapyInSearchMode_Changed
        'AddHandler cbOutbreakExists.EditValueChanged, AddressOf RelatedToOutbreakInSearchMode_Changed
        AddHandler cbSpecimenCollected.EditValueChanged, AddressOf SpecimenCollectedInSearchMode_Changed

        AddHandler PatientInfo.txtFirstName.EditValueChanged, AddressOf Me.UpdatePatientName
        AddHandler PatientInfo.txtSecondName.EditValueChanged, AddressOf Me.UpdatePatientName
        AddHandler PatientInfo.txtLastName.EditValueChanged, AddressOf Me.UpdatePatientName

        AddHandler dtDiagnosisDate.EditValueChanged, AddressOf NotificationInfo_Changed
        AddHandler dtChangedDiagnosisDate.EditValueChanged, AddressOf NotificationInfo_Changed
    End Sub

    Private Function BindHumanCaseInSearchMode() As Boolean
        If IsSearchMode() Then
            Me.Caption = EidssMessages.Get("frmHumanCaseInSearchMode", "Human Case Search Form")
            Me.LeftIcon = My.Resources.Search_Human_Case_in_Browse_Mode__large_
            Me.FormID = "H09"

            AddRemoveHandlersBefore()
            StopBR = True

            BindHeaderInSearchMode()
            BindNotificationInSearchMode()
            BindCaseInvestigationInSearchMode()
            'CaseTestsPanel1.ReadOnly = True
            UpdateMandatoryControlStyle(ControlState.Normal)
            ApplyControlState(cbCaseStatus, ControlState.Normal)
            Timer2.Start()
            DataEventManager.Flush()
            InitNavigator1()
            bFirstInit = True
            StopBR = False
            AddRemoveHandlersAfter()
            dtFormCompletionDate.Select()
            Return True
        End If
        Return False
    End Function

    Private HCSearch As HumanCaseSearch = Nothing


    Private Function GetFullName(ByVal firstT As HumanCaseSearch.HCTable, ByVal secondT As HumanCaseSearch.HCTable, ByVal fieldName As String) As String
        If (Not HCSearch Is Nothing) AndAlso (Not Utils.IsEmpty(fieldName)) Then Return HCSearch.GetDoublePrefix(firstT, secondT) + "." + fieldName
        Return ""
    End Function

    'Private Sub Set_tlbCase_FieldValues()
    '    If HCSearch Is Nothing Then Return
    '    Dim f As FieldValue = HCSearch.SearchField("strCaseID")
    '    If Not f Is Nothing Then f.FValue = txtCaseID.EditValue
    '    f = HCSearch.SearchField("datEnteredDate")
    '    If (Not f Is Nothing) Then _
    '        If (Not Utils.IsEmpty(dtStartDate.EditValue)) Then f.FValue = dtStartDate.DateTime Else f.FValue = Nothing
    '    f = HCSearch.SearchField("idfsCaseProgressStatus")
    '    If Not f Is Nothing Then f.FValue = cbCaseStatus.EditValue
    'End Sub

    Private Sub Set_tlbHumanCase_FieldValues()
        If HCSearch Is Nothing Then Return
        Dim f As FieldValue = HCSearch.SearchField("strCaseID")
        If Not f Is Nothing Then f.FValue = txtCaseID.EditValue
        f = HCSearch.SearchField("datEnteredDate")
        If (Not f Is Nothing) Then _
            If (Not Utils.IsEmpty(dtStartDate.EditValue)) Then f.FValue = dtStartDate.DateTime Else f.FValue = Nothing
        f = HCSearch.SearchField("idfsCaseProgressStatus")
        If Not f Is Nothing Then f.FValue = cbCaseStatus.EditValue
        f = HCSearch.SearchField("datModificationDate")
        If (Not f Is Nothing) Then _
            If (Not Utils.IsEmpty(dtEnteringDate.EditValue)) Then f.FValue = dtEnteringDate.DateTime Else f.FValue = Nothing
        f = HCSearch.SearchField("datCompletionPaperFormDate")
        If (Not f Is Nothing) Then _
            If (Not Utils.IsEmpty(dtFormCompletionDate.EditValue)) Then f.FValue = dtFormCompletionDate.DateTime Else f.FValue = Nothing
        f = HCSearch.SearchField("idfsFinalState")
        If Not f Is Nothing Then f.FValue = cbFinalState.EditValue
        f = HCSearch.SearchField("strNote")
        If Not f Is Nothing Then f.FValue = memoNote.EditValue
        f = HCSearch.SearchField("datNotificationDate")
        If (Not f Is Nothing) Then _
            If (Not Utils.IsEmpty(dtReportingDate.EditValue)) Then f.FValue = dtReportingDate.DateTime Else f.FValue = Nothing
        f = HCSearch.SearchField("idfsFinalCaseStatus")
        If Not f Is Nothing Then f.FValue = lueFinalCaseClassification.EditValue
        f = HCSearch.SearchField("idfsInitialCaseStatus")
        If Not f Is Nothing Then f.FValue = cbInitialCaseClassification.EditValue
        f = HCSearch.SearchField("idfsYNAntimicrobialTherapy")
        If Not f Is Nothing Then f.FValue = cbAntimicrobialTherapy.EditValue
        f = HCSearch.SearchField("idfsYNRelatedToOutbreak")
        If Not f Is Nothing Then f.FValue = cbOutbreakExists.EditValue
        f = HCSearch.SearchField("idfsYNSpecimenCollected")
        If Not f Is Nothing Then f.FValue = cbSpecimenCollected.EditValue
        f = HCSearch.SearchField("datOnsetDate")
        If (Not f Is Nothing) Then _
            If (Not Utils.IsEmpty(deOnsetDate.EditValue)) Then f.FValue = deOnsetDate.DateTime Else f.FValue = Nothing
        f = HCSearch.SearchField("idfSentByPerson")
        If Not f Is Nothing Then f.FValue = cbSentByName.EditValue
        'f = HCSearch.SearchField("strSentByFirstName")
        'If Not f Is Nothing Then f.FValue = txtSentByFirstName.EditValue
        'f = HCSearch.SearchField("strSentByPatronymicName")
        'If Not f Is Nothing Then f.FValue = txtSentByPatronymic.EditValue
        'f = HCSearch.SearchField("strSentByLastName")
        'If Not f Is Nothing Then f.FValue = txtSentByLastName.EditValue
        f = HCSearch.SearchField("idfReceivedByPerson")
        If Not f Is Nothing Then f.FValue = cbReceivedByName.EditValue
        'f = HCSearch.SearchField("strReceivedByFirstName")
        'If Not f Is Nothing Then f.FValue = txtReceivedByFirstName.EditValue
        'f = HCSearch.SearchField("strReceivedByPatronymicName")
        'If Not f Is Nothing Then f.FValue = txtReceivedByPatronymic.EditValue
        'f = HCSearch.SearchField("strReceivedByLastName")
        'If Not f Is Nothing Then f.FValue = txtReceivedByLastName.EditValue
        f = HCSearch.SearchField("datInvestigationStartDate")
        If (Not f Is Nothing) Then _
            If (Not Utils.IsEmpty(dtInvestigationStartDate.EditValue)) Then f.FValue = dtInvestigationStartDate.DateTime Else f.FValue = Nothing
        f = HCSearch.SearchField("strClinicalNotes")
        If Not f Is Nothing Then f.FValue = meClinicalComments.EditValue
        f = HCSearch.SearchField("idfsOutcome")
        If Not f Is Nothing Then f.FValue = cbOutcome.EditValue
        'f = HCSearch.SearchField("strEpidemiologistsName")
        'If Not f Is Nothing Then f.FValue = txtEpidemiologistsName.EditValue
        f = HCSearch.SearchField("strSummaryNotes")
        If Not f Is Nothing Then f.FValue = meSummaryComments.EditValue
        f = HCSearch.SearchField("idfsNotCollectedReason")
        If Not f Is Nothing Then f.FValue = cbNotCollectedReason.EditValue
        f = HCSearch.SearchField("intPatientAge")
        If Not f Is Nothing Then f.FValue = PatientInfo.txtAge.EditValue
        f = HCSearch.SearchField("idfsHumanAgeType")
        If Not f Is Nothing Then f.FValue = PatientInfo.cbAgeUnits.EditValue
        f = HCSearch.SearchField("datFacilityLastVisit")
        If (Not f Is Nothing) Then _
            If (Not Utils.IsEmpty(dtLastVisitToEmployer.EditValue)) Then f.FValue = dtLastVisitToEmployer.DateTime Else f.FValue = Nothing
        f = HCSearch.SearchField("strLocalIdentifier")
        If Not f Is Nothing Then f.FValue = txtLocalID.EditValue
        f = HCSearch.SearchField("idfsHospitalizationStatus")
        If Not f Is Nothing Then f.FValue = cbCurrentPatientLocation.EditValue
        f = HCSearch.SearchField("strCurrentLocation")
        If Not f Is Nothing Then
            If CLng(HospitalizationStatus.Other).Equals(cbCurrentPatientLocation.EditValue) Then
                f.FValue = txtOtherLocation.EditValue
            Else
                f.FValue = Nothing
            End If
        End If
        f = HCSearch.SearchField("idfHospital")
        If Not f Is Nothing Then
            If CLng(HospitalizationStatus.Hospital).Equals(cbCurrentPatientLocation.EditValue) Then
                f.FValue = cbHospitalizedTo.EditValue
            Else
                f.FValue = Nothing
            End If
        End If

        f = HCSearch.SearchField("datFirstSoughtCareDate")
        If (Not f Is Nothing) Then _
            If (Not Utils.IsEmpty(deDatePatientFirstSought.EditValue)) Then f.FValue = deDatePatientFirstSought.DateTime Else f.FValue = Nothing
        f = HCSearch.SearchField("datHospitalizationDate")
        If (Not f Is Nothing) Then _
            If (Not Utils.IsEmpty(deDateOfAdmissionHospitalization.EditValue)) Then f.FValue = deDateOfAdmissionHospitalization.DateTime Else f.FValue = Nothing
        f = HCSearch.SearchField("idfsFinalState")
        If Not f Is Nothing Then f.FValue = cbFinalState.EditValue
        f = HCSearch.SearchField("datExposureDate")
        If (Not f Is Nothing) Then _
            If (Not Utils.IsEmpty(deDateOfxposure.EditValue)) Then f.FValue = deDateOfxposure.DateTime Else f.FValue = Nothing
        f = HCSearch.SearchField("datDischargeDate")
        If (Not f Is Nothing) Then _
            If (Not Utils.IsEmpty(deDateOfDischarge.EditValue)) Then f.FValue = deDateOfDischarge.DateTime Else f.FValue = Nothing
        f = HCSearch.SearchField("idfsSoughtCareFacility")
        If Not f Is Nothing Then f.FValue = cbFacilitySoughtCare.EditValue
        f = HCSearch.SearchField("idfsYNHospitalization")
        If Not f Is Nothing Then f.FValue = cbHospitalization.EditValue
        f = HCSearch.SearchField("strHospitalizationPlace")
        If Not f Is Nothing Then f.FValue = txtHospital.EditValue
        f = HCSearch.SearchField("idfsTentativeDiagnosis")
        If Not f Is Nothing Then f.FValue = cbDiagnosis.EditValue
        f = HCSearch.SearchField("datTentativeDiagnosisDate")
        If (Not f Is Nothing) Then _
            If (Not Utils.IsEmpty(dtDiagnosisDate.EditValue)) Then f.FValue = dtDiagnosisDate.DateTime Else f.FValue = Nothing
        f = HCSearch.SearchField("idfsFinalDiagnosis")
        If Not f Is Nothing Then f.FValue = cbChangedDiagnosis.EditValue
        f = HCSearch.SearchField("datFinalDiagnosisDate")
        If (Not f Is Nothing) Then _
            If (Not Utils.IsEmpty(dtChangedDiagnosisDate.EditValue)) Then f.FValue = dtChangedDiagnosisDate.DateTime Else f.FValue = Nothing
        f = HCSearch.SearchField("idfsNonNotifiableDiagnosis")
        If Not f Is Nothing Then f.FValue = cbNonNotifiableDiesease.EditValue
        f = HCSearch.SearchField("blnClinicalDiagBasis")
        If Not f Is Nothing Then _
            If chbClinicalDiagBasis.Checked Then f.FValue = chbClinicalDiagBasis.EditValue Else f.FValue = Nothing
        f = HCSearch.SearchField("blnLabDiagBasis")
        If Not f Is Nothing Then _
            If chbLabDiagBasis.Checked Then f.FValue = chbLabDiagBasis.EditValue Else f.FValue = Nothing
        f = HCSearch.SearchField("blnEpiDiagBasis")
        If Not f Is Nothing Then _
            If chbEpiDiagBasis.Checked Then f.FValue = Me.chbEpiDiagBasis.EditValue Else f.FValue = Nothing
        f = HCSearch.SearchField("datFinalCaseClassificationDate")
        If Not f Is Nothing Then f.FValue = dtFinalCaseClassificationDate.EditValue
        f = HCSearch.SearchField("idfsDiagnosis")
        If Not f Is Nothing Then f.FValue = cbCurrentDiagnosis.EditValue
        f = HCSearch.SearchField("idfsCaseClassification")
        If Not f Is Nothing Then f.FValue = cbCaseClassification.EditValue
        f = HCSearch.SearchField("idfPersonEnteredBy")
        If Not f Is Nothing Then f.FValue = cbEnteredByName.EditValue
        f = HCSearch.SearchField("idfOfficeEnteredBy")
        If Not f Is Nothing Then f.FValue = LookupCache.GetLookupValue(cbEnteredByOrganization.EditValue, LookupTables.Organization, "idfsSite")
        f = HCSearch.SearchField("datDiagnosisDate")
        If Not f Is Nothing Then f.FValue = dtFinalDiagnosisDate.EditValue

    End Sub

    Private Sub Set_tlbHuman_FieldValues()
        If HCSearch Is Nothing Then Return
        Dim f As FieldValue = HCSearch.SearchField("strRegistrationPhone")
        If Not f Is Nothing Then f.FValue = txtRegistrationPhone.EditValue
        f = HCSearch.SearchField("idfsOccupationType")
        If Not f Is Nothing Then f.FValue = cbOccupation.EditValue
        f = HCSearch.SearchField("strWorkPhone")
        If Not f Is Nothing Then f.FValue = txtWorkPhone.EditValue
        f = HCSearch.SearchField("datDateOfDeath")
        If (Not f Is Nothing) Then _
            If (Not Utils.IsEmpty(deDateOfDeath.EditValue)) Then f.FValue = deDateOfDeath.DateTime Else f.FValue = Nothing
        f = HCSearch.SearchField("strFirstName")
        If Not f Is Nothing Then f.FValue = PatientInfo.txtFirstName.EditValue
        f = HCSearch.SearchField("strLastName")
        If Not f Is Nothing Then f.FValue = PatientInfo.txtLastName.EditValue
        f = HCSearch.SearchField("strSecondName")
        If Not f Is Nothing Then f.FValue = PatientInfo.txtSecondName.EditValue
        f = HCSearch.SearchField("strEmployerName")
        If Not f Is Nothing Then f.FValue = PatientInfo.txtEmployerName.EditValue
        f = HCSearch.SearchField("strHomePhone")
        If Not f Is Nothing Then f.FValue = PatientInfo.txtPhoneNumber.EditValue
        f = HCSearch.SearchField("datDateOfBirth")
        If (Not f Is Nothing) Then _
            If (Not Utils.IsEmpty(PatientInfo.dtpDOB.EditValue)) Then f.FValue = PatientInfo.dtpDOB.DateTime Else f.FValue = Nothing
        f = HCSearch.SearchField("idfsHumanGender")
        If Not f Is Nothing Then f.FValue = PatientInfo.cbPersonSex.EditValue
        f = HCSearch.SearchField("idfsNationality")
        If Not f Is Nothing Then f.FValue = PatientInfo.cbNationality.EditValue
        f = HCSearch.SearchField("idfsPersonIDType")
        If Not f Is Nothing Then f.FValue = PatientInfo.cbPersonalIdType.EditValue
        f = HCSearch.SearchField("strPersonID")
        If Not f Is Nothing Then f.FValue = PatientInfo.txtPersonalID.EditValue
    End Sub

    Private Sub Set_tlbGeoLocation_home_FieldValues()
        If HCSearch Is Nothing Then Return
        Dim f As FieldValue = HCSearch.SearchField("home.idfsRegion")
        If Not f Is Nothing Then f.FValue = PatientInfo.CurrentResidence_AddressLookup.RegionID
        f = HCSearch.SearchField("home.idfsRayon")
        If Not f Is Nothing Then f.FValue = PatientInfo.CurrentResidence_AddressLookup.RayonID
        f = HCSearch.SearchField("home.idfsSettlement")
        If Not f Is Nothing Then f.FValue = PatientInfo.CurrentResidence_AddressLookup.SettlementID
        f = HCSearch.SearchField("home.strStreetName")
        If Not f Is Nothing Then f.FValue = PatientInfo.CurrentResidence_AddressLookup.Street
        f = HCSearch.SearchField("home.strPostCode")
        If Not f Is Nothing Then f.FValue = PatientInfo.CurrentResidence_AddressLookup.PostalCode
        f = HCSearch.SearchField("home.strHouse")
        If Not f Is Nothing Then f.FValue = PatientInfo.CurrentResidence_AddressLookup.House
        f = HCSearch.SearchField("home.strBuilding")
        If Not f Is Nothing Then f.FValue = PatientInfo.CurrentResidence_AddressLookup.Building
        f = HCSearch.SearchField("home.strApartment")
        If Not f Is Nothing Then f.FValue = PatientInfo.CurrentResidence_AddressLookup.Apartment
        f = HCSearch.SearchField("home.dblLongitude")
        If Not f Is Nothing Then f.FValue = PatientInfo.CurrentResidence_AddressLookup.Longitude
        f = HCSearch.SearchField("home.dblLatitude")
        If Not f Is Nothing Then f.FValue = PatientInfo.CurrentResidence_AddressLookup.Latitude
    End Sub

    Private Sub Set_tlbGeoLocation_emp_FieldValues()
        If HCSearch Is Nothing Then Return
        Dim f As FieldValue = HCSearch.SearchField("emp.idfsCountry")
        If Not f Is Nothing Then f.FValue = PatientInfo.Employer_AddressLookup.CountryID()
        f = HCSearch.SearchField("emp.idfsRegion")
        If Not f Is Nothing Then f.FValue = PatientInfo.Employer_AddressLookup.RegionID
        f = HCSearch.SearchField("emp.idfsRayon")
        If Not f Is Nothing Then f.FValue = PatientInfo.Employer_AddressLookup.RayonID
        f = HCSearch.SearchField("emp.idfsSettlement")
        If Not f Is Nothing Then f.FValue = PatientInfo.Employer_AddressLookup.SettlementID
        f = HCSearch.SearchField("emp.strStreetName")
        If Not f Is Nothing Then f.FValue = PatientInfo.Employer_AddressLookup.Street
        f = HCSearch.SearchField("emp.strPostCode")
        If Not f Is Nothing Then f.FValue = PatientInfo.Employer_AddressLookup.PostalCode
        f = HCSearch.SearchField("emp.strHouse")
        If Not f Is Nothing Then f.FValue = PatientInfo.Employer_AddressLookup.House
        f = HCSearch.SearchField("emp.strBuilding")
        If Not f Is Nothing Then f.FValue = PatientInfo.Employer_AddressLookup.Building
        f = HCSearch.SearchField("emp.strApartment")
        If Not f Is Nothing Then f.FValue = PatientInfo.Employer_AddressLookup.Apartment
    End Sub

    Private Sub Set_tlbGeoLocation_reg_FieldValues()
        If HCSearch Is Nothing Then Return
        Dim f As FieldValue
        If (chkForeignAddress.Checked) Then
            f = HCSearch.SearchField("reg.blnForeignAddress")
            If Not f Is Nothing Then f.FValue = True
            f = HCSearch.SearchField("reg.idfsCountry")
            If Not f Is Nothing Then f.FValue = lpPermanentAddress.CountryID
            f = HCSearch.SearchField("reg.strForeignAddress")
            If Not f Is Nothing Then f.FValue = lpPermanentAddress.ForeignAddress
        Else
            f = HCSearch.SearchField("reg.blnForeignAddress")
            If Not f Is Nothing Then f.FValue = DBNull.Value
            f = HCSearch.SearchField("reg.idfsRegion")
            If Not f Is Nothing Then f.FValue = lpPermanentAddress.RegionID
            f = HCSearch.SearchField("reg.idfsRayon")
            If Not f Is Nothing Then f.FValue = lpPermanentAddress.RayonID
            f = HCSearch.SearchField("reg.idfsSettlement")
            If Not f Is Nothing Then f.FValue = lpPermanentAddress.SettlementID
            f = HCSearch.SearchField("reg.strStreetName")
            If Not f Is Nothing Then f.FValue = lpPermanentAddress.Street
            f = HCSearch.SearchField("reg.strPostCode")
            If Not f Is Nothing Then f.FValue = lpPermanentAddress.PostalCode
            f = HCSearch.SearchField("reg.strHouse")
            If Not f Is Nothing Then f.FValue = lpPermanentAddress.House
            f = HCSearch.SearchField("reg.strBuilding")
            If Not f Is Nothing Then f.FValue = lpPermanentAddress.Building
            f = HCSearch.SearchField("reg.strApartment")
            If Not f Is Nothing Then f.FValue = lpPermanentAddress.Apartment
            f = HCSearch.SearchField("reg.dblLongitude")
            If Not f Is Nothing Then f.FValue = lpPermanentAddress.Longitude
            f = HCSearch.SearchField("reg.dblLatitude")
            If Not f Is Nothing Then f.FValue = lpPermanentAddress.Latitude
        End If
    End Sub

    Private Sub Set_tlbOffice_FieldValues()
        If HCSearch Is Nothing Then Return
        Dim f As FieldValue = HCSearch.SearchField("sent.idfOffice")
        If Not f Is Nothing Then f.FValue = cbRepSource.EditValue
        f = HCSearch.SearchField("receive.idfOffice")
        If Not f Is Nothing Then f.FValue = cbReceivedInst.EditValue
        f = HCSearch.SearchField("inv.idfOffice")
        If Not f Is Nothing Then f.FValue = cbInvOrganization.EditValue
    End Sub

    Private Sub Set_tlbGeoLocation_case_FieldValues()
        If HCSearch Is Nothing Then Return
        Dim f As FieldValue = Nothing
        dsLocation = cbGeoLocation.baseDataSet
        If dsLocation Is Nothing OrElse Not dsLocation.Tables.Contains("GeoLocation") OrElse dsLocation.Tables("GeoLocation").Rows.Count = 0 Then Return
        Dim locationRow As DataRow = dsLocation.Tables("GeoLocation").Rows(0)
        If locationRow("idfsGeoLocationType").Equals(CLng(GeoLocationType.ExactPoint)) Then
            'f = HCSearch.SearchField("loc.idfsGeoLocationType")
            'If Not f Is Nothing Then f.FValue = locationRow("idfsGeoLocationType")
            f = HCSearch.SearchField("loc.idfsCountry")
            If Not f Is Nothing Then f.FValue = locationRow("idfsCountry")
            f = HCSearch.SearchField("loc.idfsRegion")
            If Not f Is Nothing Then f.FValue = locationRow("idfsRegion")
            f = HCSearch.SearchField("loc.idfsRayon")
            If Not f Is Nothing Then f.FValue = locationRow("idfsRayon")
            f = HCSearch.SearchField("loc.strDescription")
            If Not f Is Nothing Then f.FValue = locationRow("strDescription")
            f = HCSearch.SearchField("loc.dblLongitude")
            If Not f Is Nothing Then f.FValue = locationRow("dblLongitude")
            f = HCSearch.SearchField("loc.dblLatitude")
            If Not f Is Nothing Then f.FValue = locationRow("dblLatitude")
            f = HCSearch.SearchField("loc.dblAccuracy")
            If Not f Is Nothing Then f.FValue = locationRow("dblAccuracy")

            f = HCSearch.SearchField("loc.idfsSettlement")
            If Not f Is Nothing Then f.FValue = Nothing
            f = HCSearch.SearchField("loc.dblAlignment")
            If Not f Is Nothing Then f.FValue = Nothing
            f = HCSearch.SearchField("loc.dblDistance")
            If Not f Is Nothing Then f.FValue = Nothing
            f = HCSearch.SearchField("loc.idfsGroundType")
            If Not f Is Nothing Then f.FValue = Nothing
            f = HCSearch.SearchField("loc.strForeignAddress")
            If Not f Is Nothing Then f.FValue = Nothing

        ElseIf locationRow("idfsGeoLocationType").Equals(CLng(GeoLocationType.RelativePoint)) Then

            'f = HCSearch.SearchField("loc.idfsGeoLocationType")
            'If Not f Is Nothing Then f.FValue = locationRow("idfsGeoLocationType")
            f = HCSearch.SearchField("loc.idfsCountry")
            If Not f Is Nothing Then f.FValue = locationRow("idfsCountry")
            f = HCSearch.SearchField("loc.idfsRegion")
            If Not f Is Nothing Then f.FValue = locationRow("idfsRegion")
            f = HCSearch.SearchField("loc.idfsRayon")
            If Not f Is Nothing Then f.FValue = locationRow("idfsRayon")
            f = HCSearch.SearchField("loc.idfsSettlement")
            If Not f Is Nothing Then f.FValue = locationRow("idfsSettlement")
            f = HCSearch.SearchField("loc.strDescription")
            If Not f Is Nothing Then f.FValue = locationRow("strDescription")
            f = HCSearch.SearchField("loc.dblAlignment")
            If Not f Is Nothing Then f.FValue = locationRow("dblAlignment")
            f = HCSearch.SearchField("loc.dblDistance")
            If Not f Is Nothing Then f.FValue = locationRow("dblDistance")
            f = HCSearch.SearchField("loc.dblAccuracy")
            If Not f Is Nothing Then f.FValue = locationRow("dblAccuracy")
            f = HCSearch.SearchField("loc.idfsGroundType")
            If Not f Is Nothing Then f.FValue = locationRow("idfsGroundType")

            f = HCSearch.SearchField("loc.dblLongitude")
            If Not f Is Nothing Then f.FValue = Nothing
            f = HCSearch.SearchField("loc.dblLatitude")
            If Not f Is Nothing Then f.FValue = Nothing
            f = HCSearch.SearchField("loc.strForeignAddress")
            If Not f Is Nothing Then f.FValue = Nothing
        Else
            f = HCSearch.SearchField("loc.idfsCountry")
            If Not f Is Nothing Then f.FValue = locationRow("idfsCountry")
            f = HCSearch.SearchField("loc.strForeignAddress")
            If Not f Is Nothing Then f.FValue = locationRow("strForeignAddress")

            'f = HCSearch.SearchField("loc.idfsGeoLocationType")
            'If Not f Is Nothing Then f.FValue = Nothing
            f = HCSearch.SearchField("loc.idfsRegion")
            If Not f Is Nothing Then f.FValue = Nothing
            f = HCSearch.SearchField("loc.idfsRayon")
            If Not f Is Nothing Then f.FValue = Nothing
            f = HCSearch.SearchField("loc.idfsSettlement")
            If Not f Is Nothing Then f.FValue = Nothing
            f = HCSearch.SearchField("loc.strDescription")
            If Not f Is Nothing Then f.FValue = Nothing
            f = HCSearch.SearchField("loc.dblAlignment")
            If Not f Is Nothing Then f.FValue = Nothing
            f = HCSearch.SearchField("loc.dblDistance")
            If Not f Is Nothing Then f.FValue = Nothing
            f = HCSearch.SearchField("loc.dblAccuracy")
            If Not f Is Nothing Then f.FValue = Nothing
            f = HCSearch.SearchField("loc.idfsGroundType")
            If Not f Is Nothing Then f.FValue = Nothing
            f = HCSearch.SearchField("loc.dblLongitude")
            If Not f Is Nothing Then f.FValue = Nothing
            f = HCSearch.SearchField("loc.dblLatitude")
            If Not f Is Nothing Then f.FValue = Nothing
        End If
    End Sub

    Private Sub Set_tlbOutbreak_FieldValues()
        If HCSearch Is Nothing Then Return
        Dim f As FieldValue = HCSearch.SearchField("idfOutbreak")
        If Not f Is Nothing Then f.FValue = cbOutbreakID.EditValue
    End Sub

    Private Sub SetFieldValues()
        If HCSearch Is Nothing Then Return
        'Set_tlbCase_FieldValues()
        Set_tlbHumanCase_FieldValues()
        Set_tlbHuman_FieldValues()
        Set_tlbGeoLocation_home_FieldValues()
        Set_tlbGeoLocation_emp_FieldValues()
        Set_tlbGeoLocation_reg_FieldValues()
        Set_tlbOffice_FieldValues()
        Set_tlbGeoLocation_case_FieldValues()
        Set_tlbOutbreak_FieldValues()
    End Sub

    Private Sub AddFF_csCondition(ByRef strFrom As String)
        If (HCSearch Is Nothing) OrElse (FFClinicalSigns Is Nothing) OrElse _
           (FFClinicalSigns.MainDbService Is Nothing) OrElse _
           (FFClinicalSigns.MainDbService.MainDataSet Is Nothing) OrElse _
           (FFClinicalSigns.MainDbService.MainDataSet.Parameters Is Nothing) OrElse _
           (FFClinicalSigns.MainDbService.MainDataSet.Parameters.Rows.Count = 0) OrElse _
           (FFClinicalSigns.MainDbService.MainDataSet.ActivityParameters Is Nothing) OrElse _
           (FFClinicalSigns.MainDbService.MainDataSet.ActivityParameters.Rows.Count = 0) Then Return

        Dim ind As Integer = 0
        For Each r As DataRow In FFClinicalSigns.MainDbService.MainDataSet.ActivityParameters.Rows
            If (r.RowState <> DataRowState.Deleted) AndAlso _
               (Not Utils.IsEmpty(r("idfsParameter"))) AndAlso _
               (Not Utils.IsEmpty(r("varValue"))) Then
                ind = ind + 1
                If (ind = 1) Then strFrom = strFrom + HCSearch.Get_tlbObservation_cs_From()
                strFrom = strFrom + HCSearch.Get_tlbActivityParameters_cs_From(ind, CLng(r("idfsParameter")), r("varValue"))
            End If
        Next
    End Sub

    Private Sub AddFF_epiCondition(ByRef strFrom As String)
        If (HCSearch Is Nothing) OrElse (ffEpiInvestigations Is Nothing) OrElse _
           (ffEpiInvestigations.MainDbService Is Nothing) OrElse _
           (ffEpiInvestigations.MainDbService.MainDataSet Is Nothing) OrElse _
           (ffEpiInvestigations.MainDbService.MainDataSet.Parameters Is Nothing) OrElse _
           (ffEpiInvestigations.MainDbService.MainDataSet.Parameters.Rows.Count = 0) OrElse _
           (ffEpiInvestigations.MainDbService.MainDataSet.ActivityParameters Is Nothing) OrElse _
           (ffEpiInvestigations.MainDbService.MainDataSet.ActivityParameters.Rows.Count = 0) Then Return

        Dim ind As Integer = 0
        For Each r As DataRow In ffEpiInvestigations.MainDbService.MainDataSet.ActivityParameters.Rows
            If (r.RowState <> DataRowState.Deleted) AndAlso _
               (Not Utils.IsEmpty(r("idfsParameter"))) AndAlso _
               (Not Utils.IsEmpty(r("varValue"))) Then
                ind = ind + 1
                If (ind = 1) Then strFrom = strFrom + HCSearch.Get_tlbObservation_epi_From()
                strFrom = strFrom + HCSearch.Get_tlbActivityParameters_epi_From(ind, CLng(r("idfsParameter")), r("varValue"))
            End If
        Next
    End Sub

    Private Function GetWhere(ByVal f_arr As ArrayList) As String
        If (f_arr Is Nothing) OrElse (f_arr.Count = 0) Then Return ""
        Dim Where As String = ""
        Dim f As FieldValue = Nothing
        For i As Integer = 0 To f_arr.Count - 1
            If TypeOf (f_arr.Item(i)) Is FieldValue Then
                f = CType(f_arr.Item(i), FieldValue)
                If Where.Trim().EndsWith(")") AndAlso (Not Utils.IsEmpty(f.DefaultCondition)) Then _
                    Where = Where + "and "
                Where = Where + Utils.Str(f.DefaultCondition)
            End If
        Next
        Return Where
    End Function

    Private Sub Add_tlbContactedCasePerson_Condition(ByRef strFrom As String, ByRef strWhere As String)
        If (HCSearch Is Nothing) OrElse (baseDataSet Is Nothing) OrElse _
           (Not baseDataSet.Tables.Contains("tlbContactedCasePerson")) OrElse _
           (baseDataSet.Tables("tlbContactedCasePerson").Rows.Count = 0) Then Return

        Dim ind As Integer = 0
        Dim f_arr As ArrayList = Nothing
        Dim f As FieldValue = Nothing
        Dim rFrom As String = ""
        Dim rWhere As String = ""
        Dim rUniqueFrom As String = ""
        Dim rUniqueWhere As String = ""

        For Each r As DataRow In baseDataSet.Tables("tlbContactedCasePerson").Rows
            If (r.RowState <> DataRowState.Deleted) Then
                f_arr = New ArrayList()
                f = New FieldValue("idfHumanActual", Nothing, GetType(Int64), HCSearch.GetDoublePrefix(HumanCaseSearch.HCTable.tlbHuman, HumanCaseSearch.HCTable.tlbContactedCasePerson, ind + 1), True)
                If Not Utils.IsEmpty(r("idfRootHuman")) Then f.FValue = r("idfRootHuman")
                f_arr.Add(f)
                f = New FieldValue("idfsPersonContactType", Nothing, GetType(Int64), HCSearch.GetPrefix(HumanCaseSearch.HCTable.tlbContactedCasePerson, ind + 1), True)
                If Not Utils.IsEmpty(r("idfsPersonContactType")) Then f.FValue = r("idfsPersonContactType")
                f_arr.Add(f)
                f = New FieldValue("datDateOfLastContact", Nothing, GetType(DateTime), HCSearch.GetPrefix(HumanCaseSearch.HCTable.tlbContactedCasePerson, ind + 1), False)
                If Not Utils.IsEmpty(r("datDateOfLastContact")) Then f.FValue = r("datDateOfLastContact")
                f_arr.Add(f)
                f = New FieldValue("strPlaceInfo", Nothing, GetType(String), HCSearch.GetPrefix(HumanCaseSearch.HCTable.tlbContactedCasePerson, ind + 1), False)
                If Not Utils.IsEmpty(r("strPlaceInfo")) Then f.FValue = r("strPlaceInfo")
                f_arr.Add(f)
                rWhere = GetWhere(f_arr)
                If Not Utils.IsEmpty(rWhere) Then
                    rFrom = HCSearch.Get_tlbContactedCasePerson_From(ind + 1)
                    If Not Utils.IsEmpty(rFrom) Then
                        ind = ind + 1

                        strFrom = strFrom + rFrom
                        If (Not Utils.IsEmpty(strWhere)) Then rWhere = "and " + rWhere
                        strWhere = strWhere + rWhere

                        rUniqueFrom = HCSearch.Get_tlbContactedCasePerson_UniqueFrom(ind, rWhere)
                        If Not Utils.IsEmpty(rUniqueFrom) Then
                            rUniqueWhere = HCSearch.Get_tlbContactedCasePerson_UniqueWhere(ind, rWhere)
                            If (Not Utils.IsEmpty(rUniqueWhere)) Then
                                strFrom = strFrom + rUniqueFrom
                                strWhere = strWhere + "and " + rUniqueWhere
                            End If
                        End If
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub Add_tlbMaterial_Condition(ByRef strFrom As String, ByRef strWhere As String)
        If (HCSearch Is Nothing) OrElse (HumanCaseSamplesPanel1 Is Nothing) OrElse _
           (HumanCaseSamplesPanel1.baseDataSet Is Nothing) OrElse _
           (HumanCaseSamplesPanel1.baseDataSet.Tables.Count <= HumanCaseSamplesDetail_DB.TablesEnum.Materials) OrElse _
           (HumanCaseSamplesPanel1.baseDataSet.Tables(HumanCaseSamplesDetail_DB.TablesEnum.Materials).Rows.Count = 0) Then Return

        Dim ind As Integer = 0
        Dim f_arr As ArrayList = Nothing
        Dim f As FieldValue = Nothing
        Dim rFrom As String = ""
        Dim rWhere_tlbMaterial As String = ""
        Dim rWhere_tlbTesting As String = ""
        Dim rWhere As String = ""
        Dim rUniqueFrom As String = ""
        Dim rUniqueWhere As String = ""

        For Each r As DataRow In HumanCaseSamplesPanel1.baseDataSet.Tables(HumanCaseSamplesDetail_DB.TablesEnum.Materials).Rows
            If (r.RowState <> DataRowState.Deleted) Then
                f_arr = New ArrayList()
                f = New FieldValue("strFieldBarcode", Nothing, GetType(String), HCSearch.GetPrefix(HumanCaseSearch.HCTable.tlbMaterial, ind + 1), False)
                If Not Utils.IsEmpty(r("strFieldBarcode")) Then f.FValue = r("strFieldBarcode")
                f_arr.Add(f)
                f = New FieldValue("datFieldCollectionDate", Nothing, GetType(DateTime), HCSearch.GetPrefix(HumanCaseSearch.HCTable.tlbMaterial, ind + 1), False)
                If Not Utils.IsEmpty(r("datFieldCollectionDate")) Then f.FValue = r("datFieldCollectionDate")
                f_arr.Add(f)
                f = New FieldValue("datFieldSentDate", Nothing, GetType(DateTime), HCSearch.GetPrefix(HumanCaseSearch.HCTable.tlbMaterial, ind + 1), False)
                If Not Utils.IsEmpty(r("datFieldSentDate")) Then f.FValue = r("datFieldSentDate")
                f_arr.Add(f)
                f_arr = New ArrayList()
                f = New FieldValue("idfsSampleType", Nothing, GetType(Int64), HCSearch.GetPrefix(HumanCaseSearch.HCTable.tlbMaterial, ind + 1), True)
                If Not Utils.IsEmpty(r("idfsSampleType")) Then f.FValue = r("idfsSampleType")
                f_arr.Add(f)
                rWhere_tlbMaterial = GetWhere(f_arr)

                f_arr = New ArrayList()
                f = New FieldValue("datAccession", Nothing, GetType(DateTime), HCSearch.GetDoublePrefix(HumanCaseSearch.HCTable.tlbMaterial, HumanCaseSearch.HCTable.tlbMaterial, ind + 1), False)
                If Not Utils.IsEmpty(r("datAccession")) Then f.FValue = r("datAccession")
                f_arr.Add(f)
                f_arr = New ArrayList()
                If HumanCaseSamplesPanel1.baseDataSet.Tables(HumanCaseSamplesDetail_DB.TablesEnum.Materials).Columns.Contains("idfsTest_Type") Then
                    f = New FieldValue("idfsTestName", Nothing, GetType(Int64), HCSearch.GetDoublePrefix(HumanCaseSearch.HCTable.tlbTesting, HumanCaseSearch.HCTable.tlbMaterial, ind + 1), True)
                    If Not Utils.IsEmpty(r("idfsTestName")) Then f.FValue = r("idfsTestName")
                    f_arr.Add(f)
                End If
                If HumanCaseSamplesPanel1.baseDataSet.Tables(HumanCaseSamplesDetail_DB.TablesEnum.Materials).Columns.Contains("idfsTestResult") Then
                    f = New FieldValue("idfsTestResult", Nothing, GetType(Int64), HCSearch.GetDoublePrefix(HumanCaseSearch.HCTable.tlbTesting, HumanCaseSearch.HCTable.tlbMaterial, ind + 1), True)
                    If Not Utils.IsEmpty(r("idfsTestResult")) Then f.FValue = r("idfsTestResult")
                    f_arr.Add(f)
                End If
                f = New FieldValue("datPerformedDate", Nothing, GetType(DateTime), HCSearch.GetDoublePrefix(HumanCaseSearch.HCTable.tlbBatchTest, HumanCaseSearch.HCTable.tlbMaterial, ind + 1), False)
                If Not Utils.IsEmpty(r("datPerformedDate")) Then f.FValue = r("datPerformedDate")
                f_arr.Add(f)
                rWhere_tlbTesting = GetWhere(f_arr)

                rWhere = rWhere_tlbMaterial
                If (Not Utils.IsEmpty(rWhere)) AndAlso (Not Utils.IsEmpty(rWhere_tlbTesting)) Then _
                    rWhere = rWhere + "and "
                rWhere = rWhere + rWhere_tlbTesting

                If (Not Utils.IsEmpty(rWhere)) Then
                    rFrom = HCSearch.Get_tlbMaterial_From(ind + 1, False)
                    If Not Utils.IsEmpty(rFrom) Then
                        ind = ind + 1
                        If (ind = 1) AndAlso _
                           (Not HumanCaseSearch.S1_Contains_S2( _
                                    strFrom, HCSearch.GetFrom(HumanCaseSearch.HCTable.tlbHuman))) Then _
                            strFrom = strFrom + HCSearch.GetFrom(HumanCaseSearch.HCTable.tlbHuman)

                        strFrom = strFrom + rFrom
                        If (Not Utils.IsEmpty(strWhere)) Then rWhere = "and " + rWhere
                        strWhere = strWhere + rWhere

                        rUniqueFrom = HCSearch.Get_tlbMaterial_UniqueFrom(ind, rWhere_tlbMaterial, rWhere_tlbTesting)
                        If Not Utils.IsEmpty(rUniqueFrom) Then
                            rUniqueWhere = HCSearch.Get_tlbMaterial_UniqueWhere(ind, rWhere_tlbMaterial, rWhere_tlbTesting)
                            If (Not Utils.IsEmpty(rUniqueWhere)) Then
                                strFrom = strFrom + rUniqueFrom
                                strWhere = strWhere + "and " + rUniqueWhere
                            End If
                        End If
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub Add_tlbAntimicrobialTherapy_Condition(ByRef strFrom As String, ByRef strWhere As String)
        If (HCSearch Is Nothing) OrElse (baseDataSet Is Nothing) OrElse _
           (Not baseDataSet.Tables.Contains("tlbAntimicrobialTherapy")) OrElse _
           (baseDataSet.Tables("tlbAntimicrobialTherapy").Rows.Count = 0) Then Return

        Dim ind As Integer = 0
        Dim f_arr As ArrayList = Nothing
        Dim f As FieldValue = Nothing
        Dim rFrom As String = ""
        Dim rWhere As String = ""
        Dim rUniqueFrom As String = ""
        Dim rUniqueWhere As String = ""

        For Each r As DataRow In baseDataSet.Tables("tlbAntimicrobialTherapy").Rows
            If (r.RowState <> DataRowState.Deleted) Then
                f_arr = New ArrayList()
                f = New FieldValue("strAntimicrobialTherapyName", Nothing, GetType(String), HCSearch.GetPrefix(HumanCaseSearch.HCTable.tlbAntimicrobialTherapy, ind + 1), False)
                If Not Utils.IsEmpty(r("strAntimicrobialTherapyName")) Then f.FValue = r("strAntimicrobialTherapyName")
                f_arr.Add(f)
                f = New FieldValue("datFirstAdministeredDate", Nothing, GetType(DateTime), HCSearch.GetPrefix(HumanCaseSearch.HCTable.tlbAntimicrobialTherapy, ind + 1), False)
                If Not Utils.IsEmpty(r("datFirstAdministeredDate")) Then f.FValue = r("datFirstAdministeredDate")
                f_arr.Add(f)
                f = New FieldValue("strDosage", Nothing, GetType(String), HCSearch.GetPrefix(HumanCaseSearch.HCTable.tlbAntimicrobialTherapy, ind + 1), False)
                If Not Utils.IsEmpty(r("strDosage")) Then f.FValue = r("strDosage")
                f_arr.Add(f)
                rWhere = GetWhere(f_arr)
                If Not Utils.IsEmpty(rWhere) Then
                    rFrom = HCSearch.Get_tlbAntimicrobialTherapy_From(ind + 1)
                    If Not Utils.IsEmpty(rFrom) Then
                        ind = ind + 1

                        strFrom = strFrom + rFrom
                        If (Not Utils.IsEmpty(strWhere)) Then rWhere = "and " + rWhere
                        strWhere = strWhere + rWhere

                        rUniqueFrom = HCSearch.Get_tlbAntimicrobialTherapy_UniqueFrom(ind, rWhere)
                        If Not Utils.IsEmpty(rUniqueFrom) Then
                            rUniqueWhere = HCSearch.Get_tlbAntimicrobialTherapy_UniqueWhere(ind, rWhere)
                            If (Not Utils.IsEmpty(rUniqueWhere)) Then
                                strFrom = strFrom + rUniqueFrom
                                strWhere = strWhere + "and " + rUniqueWhere
                            End If
                        End If
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub btnSearchInBrowseMode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchInBrowseMode.Click
        If Not ValidateData() Then Return
        If (Not FindForm() Is Nothing) AndAlso (m_Loading = 0) Then
            Cursor.Current = Cursors.WaitCursor
        End If
        If HCSearch Is Nothing Then HCSearch = New HumanCaseSearch()
        SetFieldValues()
        Dim strFrom As String = HCSearch.FromCondition(True)
        Dim strWhere As String = HCSearch.WhereCondition(True)
        AddFF_csCondition(strFrom)
        AddFF_epiCondition(strFrom)
        Add_tlbContactedCasePerson_Condition(strFrom, strWhere)
        Add_tlbMaterial_Condition(strFrom, strWhere)
        Add_tlbAntimicrobialTherapy_Condition(strFrom, strWhere)
        If Utils.IsEmpty(strFrom) AndAlso Utils.IsEmpty(strWhere) Then
            If Not FindForm() Is Nothing AndAlso m_Loading = 0 Then
                Cursor.Current = Cursors.Default
            End If
            MessageForm.Show(EidssMessages.Get("mbNoCaseSearchCriteria", "Set the criteria of search."), EidssMessages.Get("mbHumanCaseSearchInfo", "Human Case Search Info"))
        Else
            Dim humanDbService As New HumanCase_DB
            humanDbService.ListFilterCondition = strWhere
            humanDbService.ListFromCondition = strFrom
            Dim dtHumanCaseList As DataTable = humanDbService.GetList.Tables(0)
            If Not FindForm() Is Nothing AndAlso m_Loading = 0 Then
                Cursor.Current = Cursors.Default
            End If

            If (dtHumanCaseList.Rows.Count = 0) Then
                MessageForm.Show(EidssMessages.Get("mbNoCaseSearchResults", "On the set criteria of search no case was found. Change some information and try find again."), EidssMessages.Get("mbHumanCaseSearchInfo", "Human Case Search Info"))
            ElseIf (dtHumanCaseList.Rows.Count = 1) Then
                Dim caseID As Object = dtHumanCaseList.Rows(0)("idfCase")
                If Utils.IsEmpty(caseID) Then
                    MessageForm.Show(EidssMessages.Get("mbNoCaseSearchResults", "On the set criteria of search no case was found. Change some information and try find again."), EidssMessages.Get("mbHumanCaseSearchInfo", "Human Case Search Info"))
                Else
                    Dim drLoadCase As DialogResult = _
                            MessageForm.Show(EidssMessages.Get("mbOneCaseSearchResult", "On the set criteria of search one case was found. Do you want to open it for editing?"), EidssMessages.Get("mbHumanCaseSearchInfo", "Human Case Search Info"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If drLoadCase = DialogResult.Yes Then
                        Dim humanCaseForm As New HumanCaseDetail
                        Dim params As New Dictionary(Of String, Object)
                        params.Add("FromCond", strFrom)
                        params.Add("FilterCond", strWhere)
                        humanCaseForm.StartUpParameters = params
                        BaseFormManager.ShowNormal(humanCaseForm, caseID)
                    End If
                End If
            Else
                Dim drLoadCaseList As DialogResult = DialogResult.None
                If (dtHumanCaseList.Rows.Count > 2000) Then
                    drLoadCaseList = MessageForm.Show(EidssMessages.Get("mbTooManyCaseSearchResults", "On the set criteria of search a more then 2000 cases were found. Only 2000 cases can be displayed in the list. Do you want to choose a case from a list?"), EidssMessages.Get("mbHumanCaseSearchInfo", "Human Case Search Info"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                Else
                    drLoadCaseList = MessageForm.Show(EidssMessages.Get("mbManyCaseSearchResults", "On the set criteria of search a few cases were found. Do you want to choose a case from a list?"), EidssMessages.Get("mbHumanCaseSearchInfo", "Human Case Search Info"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                End If
                If drLoadCaseList = DialogResult.Yes Then
                    Dim humanListForm As New HumanCaseListPanel()
                    Dim filter As New FilterParams
                    Dim i As Integer = 1
                    For Each row As DataRow In dtHumanCaseList.Rows
                        If (i > 2000) Then
                            Exit For
                        End If
                        filter.Add("idfCase", "=", row("idfCase"), True)
                        i += 1
                    Next
                    humanListForm.StaticFilter = filter
                    humanListForm.SearchPanelVisible = False
                    Dim r As IObject = BaseFormManager.ShowForSelection(humanListForm, FindForm, , 1024, 800)
                    If Not r Is Nothing Then
                        Dim caseID As Object = r.Key
                        Dim humanCaseForm As New HumanCaseDetail
                        Dim params As New Dictionary(Of String, Object)
                        params.Add("FromCond", strFrom)
                        params.Add("FilterCond", strWhere)
                        humanCaseForm.StartUpParameters = params
                        BaseFormManager.ShowNormal(humanCaseForm, caseID)
                    End If
                End If
            End If
        End If
        If (Not FindForm() Is Nothing) AndAlso (m_Loading = 0) AndAlso (Cursor.Current <> Cursors.Default) Then
            Cursor.Current = Cursors.Default
        End If
    End Sub

#End Region

    Public Sub UpdateNotReadOnlyControlView()
        If Not IsSearchMode() Then
            txtCaseCount.Properties.ReadOnly = True
            txtCaseCount1.Properties.ReadOnly = True

            DxControlsHelper.HideButtonEditButton(cbAgeUnits, ButtonPredefines.Delete)
            DxControlsHelper.HideButtonEditButton(cbDiagnosis, ButtonPredefines.Delete)
            DxControlsHelper.HideButtonEditButton(cbHospitalization, ButtonPredefines.Plus)
            DxControlsHelper.HideButtonEditButton(cbAntimicrobialTherapy, ButtonPredefines.Plus)
            DxControlsHelper.HideButtonEditButton(cbOutbreakExists, ButtonPredefines.Plus)
            DxControlsHelper.HideButtonEditButton(cbSpecimenCollected, ButtonPredefines.Plus)

            ''
            txtCaseID.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
            txtCaseID.Properties.ReadOnly = True
            txtCaseID.Enabled = True
            'txtCaseID.Enabled = False
            ''
            dtStartDate.Enabled = False
            dtEnteringDate.Enabled = False

            Dim TentativeDiag As Object = Nothing
            If baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0 Then
                TentativeDiag = baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsTentativeDiagnosis")
            End If
            Dim FinalDiag As Object = Nothing
            If baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0 Then
                FinalDiag = baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsFinalDiagnosis")
            End If
            SetBasisOfDiagnosisState()
            If Utils.IsEmpty(TentativeDiag) Then
                dtDiagnosisDate.Enabled = False
            End If
            If Utils.IsEmpty(FinalDiag) Then
                dtChangedDiagnosisDate.Enabled = False
            End If

            If (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) AndAlso _
               (Not Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsHospitalizationStatus"))) Then
                SetHospitalizationStatusVisibility(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsHospitalizationStatus"))
            Else
                SetHospitalizationStatusVisibility(DBNull.Value)
            End If
            '"10100001" = "ynvYes", "10100002" = "ynvNo", "10100003" = "ynvUnknown"
            If (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) AndAlso _
               (Utils.Str(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsYNHospitalization"), "10100003") <> _
                "10100001") Then
                deDateOfAdmissionHospitalization.Enabled = False
                txtHospital.Enabled = False
            End If
            If (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) AndAlso _
               (Utils.Str(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsYNAntimicrobialTherapy"), "10100003") <> _
                "10100001") Then
                gcAntimicrobialTherapy.Enabled = False
                gvAntimicrobialTherapy.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                btnRemoveAntimicrobialTherapy.Enabled = False
            End If
            If (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) AndAlso _
               (Utils.Str(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("idfsYNRelatedToOutbreak"), "10100003") <> _
                "10100001") Then
                cbOutbreakID.Enabled = False
            End If
            If (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0) AndAlso _
               (Not Utils.IsEmpty(baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("intPatientAge"))) Then
                txtAge.Enabled = False
                cbAgeUnits.Enabled = False
                PatientInfo.txtAge.Enabled = txtAge.Enabled
                PatientInfo.cbAgeUnits.Enabled = cbAgeUnits.Enabled
            End If
            'cbPatientAddress.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never
            PatientInfo.UpdateNotReadOnlyControlView()
            HumanCaseSamplesPanel1.UpdateNotReadOnlyControlView()
            'CaseTestsPanel1.ReadOnly = True

            btnSearchHumanCase.Visible = True
            btnSearchHumanCase.Enabled = True
            btnSearch.Visible = True
            btnSearch.Enabled = True
            btnClear.Visible = True
            btnClear.Enabled = True
            If EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.InsertPermission( _
                                                EIDSS.model.Enums.EIDSSPermissionObject.HumanCase)) Then
                Me.ShowNewButton = True
            End If
            If EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.DeletePermission( _
                                                EIDSS.model.Enums.EIDSSPermissionObject.HumanCase)) Then
                Me.ShowDeleteButton = True
            End If
            Me.ShowSaveButton = True
            Me.ShowOkButton = True
            Me.ShowCancelButton = True
            UpdateMandatoryControlStyle(ControlState.Mandatory)
        End If
    End Sub

    Private Sub PopulateContactInfo(patientId As Object, rContact As DataRow)
        Dim row As DataRow = HumanCase_DB.PopulateContactInfo(patientId)
        If Not row Is Nothing Then
            rContact("strName") = row("PatientName")
            rContact("strPatientInformation") = row("PatientInformation")
            rContact("datDateOfBirth") = row("datDateOfBirth")
            rContact("idfsHumanGender") = row("idfsHumanGender")
            rContact("idfsCountry") = row("idfsCountry")
            rContact("idfsRegion") = row("idfsRegion")
            rContact("idfsRayon") = row("idfsRayon")
            rContact("idfsSettlement") = row("idfsSettlement")
            rContact("strPostCode") = row("strPostCode")
            rContact("strStreetName") = row("strStreetName")
            rContact("strHouse") = row("strHouse")
            rContact("strBuilding") = row("strBuilding")
            rContact("strApartment") = row("strApartment")
            rContact("strPatientAddressString") = row("strPatientAddressString")
        End If
    End Sub

    'Private Sub SamplesGridView_CustomRowCellEditForEditing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles HumanCaseSamplesPanel1.evGridViewCustomRowCellEditForEditing




    '    '   Me.cbSampleTypeEditor.DataSource = Me..DataSource
    '    ' e.RepositoryItem.
    '    '  If Not (e.Column Is Me.cbSampleTypeEditor) Then Exit Sub

    '    If Me.chkFilterSamples.Checked = False OrElse e.Column.FieldName <> "idfsSampleType" Then
    '        '  mainDataView.RowFilter = ""
    '        Exit Sub
    '    End If

    '    If Me.chkFilterSamples.Checked = True Then

    '        Dim dataSource As DataView = CType(CType(e.Column.ColumnEdit, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit).DataSource, DataView)
    '        Dim filteredDataTable As DataTable = Me.HumanCaseDbService.GetFilteredCase()

    '        Dim mainDataView As DataView = CType(dataSource, DataView).Table.Copy().DefaultView() '.Table.Rows(0)("idfsReference")

    '        Dim Filter As String = ""

    '        If filteredDataTable.Rows.Count = 0 Then
    '            mainDataView.Table.Clear()
    '        End If

    '        For Each diag As DataRow In filteredDataTable.Rows
    '            If Filter.Length > 0 Then Filter = Filter + " OR "
    '            Filter = Filter + "idfsReference=" + diag(0).ToString()
    '        Next

    '        mainDataView.RowFilter = Filter
    '        mainDataView.Sort = "idfsReference"


    '        Me.cbSampleTypeEditor.NullText = ""

    '        Me.cbSampleTypeEditor.DataSource = mainDataView
    '        Me.cbSampleTypeEditor.DisplayMember = "name"

    '        Me.cbSampleTypeEditor.ValueMember = "idfsReference"
    '        Dim column As LookUpColumnInfo = Me.cbSampleTypeEditor.Columns.CreateColumn()
    '        column.FieldName = "name"
    '        column.Caption = "name"

    '        Me.cbSampleTypeEditor.Columns.Clear()
    '        Me.cbSampleTypeEditor.Columns.Add(column)

    '        e.RepositoryItem = Me.cbSampleTypeEditor

    '        '     CType(e.Column.ColumnEdit, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit).DataSource = cbSampleTypeEditor


    '    End If
    'End Sub
    Private m_Updating As Boolean
    Private Sub chkForeignAddress_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkForeignAddress.CheckedChanged
        If m_Updating Then
            Return
        End If
        m_Updating = True
        If (baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows.Count > 0 AndAlso True.Equals(UseSameAddress)) Then
            baseDataSet.Tables(HumanCase_DB.tlbHumanCase).Rows(0)("blnPermantentAddressAsCurrent") = False
            DataEventManager.Flush()
        End If
        lpPermanentAddress.ForeignAddressMode = chkForeignAddress.Checked
        lpPermanentAddress_Load(Nothing, EventArgs.Empty)
        m_Updating = False
    End Sub

    Private Sub HumanCaseSamplesPanel1_VisibleChanged(sender As Object, e As System.EventArgs) Handles HumanCaseSamplesPanel1.VisibleChanged
        If (HumanCaseSamplesPanel1.Visible) Then
            HumanCaseSamplesPanel1.MergeTestTable(CaseTestsPanel1.baseDataSet.Tables(CaseTestsDetail_Db.TableTests))
        End If

    End Sub
    Private Sub InitCustomMandatoryFields()
        'Notification tab
        If (IsSearchMode()) Then
            Return
        End If
        MandatoryFieldHelper.SetCustomMandatoryField(dtDiagnosisDate, CustomMandatoryField.HumanCase_DiagnosisDate)
        MandatoryFieldHelper.SetCustomMandatoryField(PatientInfo.txtFirstName, CustomMandatoryField.HumanCase_Patient_FirstName)
        MandatoryFieldHelper.SetCustomMandatoryField(PatientInfo.dtpDOB, CustomMandatoryField.HumanCase_Patient_DateOfBirth)
        MandatoryFieldHelper.SetCustomMandatoryField(PatientInfo.txtAge, CustomMandatoryField.HumanCase_Patient_Age)
        MandatoryFieldHelper.SetCustomMandatoryField(PatientInfo.cbAgeUnits, CustomMandatoryField.HumanCase_Patient_AgeType)
        MandatoryFieldHelper.SetCustomMandatoryField(PatientInfo.cbPersonSex, CustomMandatoryField.HumanCase_Patient_Gender)
        MandatoryFieldHelper.SetCustomMandatoryField(PatientInfo.cbPersonalIdType, CustomMandatoryField.HumanCase_Patient_PersonIdType)
        MandatoryFieldHelper.SetCustomAddressMandatoryField(PatientInfo.CurrentResidence_AddressLookup, CustomMandatoryField.HumanCase_Patient_CurrentResidence_Settlement, AddressMandatoryFieldsType.Settlement)
        MandatoryFieldHelper.SetCustomMandatoryField(PatientInfo.cbNationality, CustomMandatoryField.HumanCase_Citizenship)
        MandatoryFieldHelper.SetCustomAddressMandatoryField(lpPermanentAddress, CustomMandatoryField.HumanCase_Patient_RegistrationAddress_Region, AddressMandatoryFieldsType.Region)
        MandatoryFieldHelper.SetCustomAddressMandatoryField(lpPermanentAddress, CustomMandatoryField.HumanCase_Patient_RegistrationAddress_Rayon, AddressMandatoryFieldsType.Rayon)
        MandatoryFieldHelper.SetCustomAddressMandatoryField(lpPermanentAddress, CustomMandatoryField.HumanCase_Patient_RegistrationAddress_Settlement, AddressMandatoryFieldsType.Settlement)
        MandatoryFieldHelper.SetCustomMandatoryField(deOnsetDate, CustomMandatoryField.HumanCase_DateOfSymptomsOnSet)
        MandatoryFieldHelper.SetCustomMandatoryField(dtFormCompletionDate, CustomMandatoryField.HumanCase_CompletionPaperFormDate)
        MandatoryFieldHelper.SetCustomMandatoryField(cbSentByName, CustomMandatoryField.HumanCase_SentByPerson)
        MandatoryFieldHelper.SetCustomMandatoryField(cbRepSource, CustomMandatoryField.HumanCase_SentByPerson)
        MandatoryFieldHelper.SetCustomMandatoryField(cbRepSource, CustomMandatoryField.HumanCase_SentByOffice)
        MandatoryFieldHelper.SetCustomMandatoryField(dtReportingDate, CustomMandatoryField.HumanCase_NotificationDate)
        MandatoryFieldHelper.SetCustomMandatoryField(cbReceivedInst, CustomMandatoryField.HumanCase_NotificationReceivedByFacility)
        MandatoryFieldHelper.SetCustomMandatoryField(cbReceivedByName, CustomMandatoryField.HumanCase_NotificationReceivedByName)
        'Case Investigation tab 
        MandatoryFieldHelper.SetCustomMandatoryField(deDateOfxposure, CustomMandatoryField.HumanCase_ExposureDate)
        MandatoryFieldHelper.SetCustomMandatoryField(cbInitialCaseClassification, CustomMandatoryField.HumanCase_InitialCaseStatus)
        MandatoryFieldHelper.SetCustomMandatoryField(cbGeoLocation, CustomMandatoryField.HumanCase_PointGeoLocation)
        MandatoryFieldHelper.SetCustomMandatoryField(cbHospitalization, CustomMandatoryField.HumanCase_Hospitalization)
        'Final Case Classification tab
        MandatoryFieldHelper.SetCustomMandatoryField(lueFinalCaseClassification, CustomMandatoryField.HumanCase_FinalCaseStatus)
    End Sub
    Private m_IgnorePersonalData As Boolean
    Protected Overrides Function CheckColumnForModification(tableName As String, columnName As String) As Boolean
        If (tableName = HumanCase_DB.tlbHumanCase AndAlso columnName = "datModificationDate") Then
            Return False
        End If
        Return True
    End Function

    'The order of the conditions: not active (by default)-> checked -> unchecked.
    'Private Sub chbCheck_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles chbClinicalDiagBasis.MouseDown, chbEpiDiagBasis.MouseDown, chbLabDiagBasis.MouseDown
    '    If [ReadOnly] Then
    '        Return
    '    End If
    '    If LockHandler() Then
    '        Try
    '            Dim rb As DevExpress.XtraEditors.CheckEdit = CType(sender, DevExpress.XtraEditors.CheckEdit)
    '            If rb.CheckState = CheckState.Checked Then
    '                rb.CheckState = CheckState.Unchecked
    '            ElseIf rb.CheckState = CheckState.Indeterminate Then
    '                rb.CheckState = CheckState.Checked
    '            ElseIf rb.CheckState = CheckState.Unchecked Then
    '                rb.CheckState = CheckState.Indeterminate
    '            End If
    '        Finally
    '            UnlockHandler()
    '        End Try
    '    End If
    'End Sub
    Protected Overrides Sub RegisterValidators()
        MyBase.RegisterValidators()
        If Not IsSearchMode Then
            Dim RootDate As New DateChainValidator(PatientInfo, PatientInfo.dtpDOB, Patient_DB.tlbHuman, "datDateofBirth", PatientInfo.lblDOB.Text)
            RootDate.AddChild(New DateChainValidator(Me, dtLastVisitToEmployer, HumanCase_DB.tlbHumanCase, "datFacilityLastVisit", lblLastVisitToEmployer.Text, , , , True))
            RootDate.AddChild(New DateChainValidator(Me, deDateOfAdmissionHospitalization, HumanCase_DB.tlbHumanCase, "datHospitalizationDate", lblDateOfAdmissionHospitalization.Text, , , , True))
            RootDate.AddChild(New DateChainValidator(Me, gcContactPeople, HumanCase_DB.tlbContactedCasePerson, "datDateOfLastContact", colContactDate.Caption, , , , True))
            RootDate.AddChild(New DateChainValidator(Me, deDatePatientFirstSought, HumanCase_DB.tlbHumanCase, "datFirstSoughtCareDate", lblDatePatientFirstSought.Text, , , , True))
            RootDate.AddChild(New DateChainValidator(Me, deDateOfDeath, HumanCase_DB.tlbHumanCase, "datDateOfDeath", lblDateOfDeath.Text, , , , True))

            Dim item As ChainValidator(Of DateTime) = RootDate.AddChild(New DateChainValidator(Me, deDateOfxposure, HumanCase_DB.tlbHumanCase, "datExposureDate", lblDateOfxposure.Text))
            item = item.AddChild(New DateChainValidator(Me, deOnsetDate, HumanCase_DB.tlbHumanCase, "datOnSetDate", lblOnsetDate.Text))
            Dim diagnosisDateItem As ChainValidator(Of DateTime) = item.AddChild(New DateChainValidator(Me, dtDiagnosisDate, HumanCase_DB.tlbHumanCase, "datTentativeDiagnosisDate", lblDiagnosisDate.Text))
            Dim samplesFilter As String = String.Format("idfsSampleType<>{0} and Used<>1", CLng(SampleTypeEnum.Unknown))
            item = RootDate.AddChild(New DateChainValidator(HumanCaseSamplesPanel1, HumanCaseSamplesPanel1.Grid, CaseSamples_Db.TableSamples, "datFieldCollectionDate", HumanCaseSamplesPanel1.CollectionDateCaption, samplesFilter, , , True, , AddressOf HumanCaseSamplesPanel1.UpdateButtons))
            item = item.AddChild(New DateChainValidator(HumanCaseSamplesPanel1, HumanCaseSamplesPanel1.Grid, CaseSamples_Db.TableSamples, "datFieldSentDate", HumanCaseSamplesPanel1.SentDateCaption, samplesFilter, , , True, , AddressOf HumanCaseSamplesPanel1.UpdateButtons))
            item.AddChild(CaseTestsPanel1.DateValidator)
            item = diagnosisDateItem.AddChild(New DateChainValidator(Me, dtChangedDiagnosisDate, HumanCase_DB.tlbHumanCase, "datFinalDiagnosisDate", lblChangedDiagnosisDate.Text, , , , True))
            If Not EidssSiteContext.Instance.IsGeorgiaCustomization Then
                item.AddChild(New DateChainValidator(Me, dtFinalCaseClassificationDate, HumanCase_DB.tlbHumanCase, "datFinalCaseClassificationDate", lbFinalCaseClassificationDate.Text, , , , True))
            End If
            'item = diagnosisDateItem.AddChild(New DateChainValidator(Me, dtFormCompletionDate, HumanCase_DB.tlbHumanCase, "datCompletionPaperFormDate", lblFormCompletionDate.Text))
            item = diagnosisDateItem.AddChild(New DateChainValidator(Me, dtReportingDate, HumanCase_DB.tlbHumanCase, "datNotificationDate", lblReportingDate.Text))
            item.AddChild(New DateChainValidator(Me, dtEnteringDate, HumanCase_DB.tlbHumanCase, "datEnteredDate", lbDateEntered.Text))
            RootDate.RegisterValidator(Me, True)
            item = New DateChainValidator(Me, gcAntimicrobialTherapy, HumanCase_DB.tlbAntimicrobialTherapy, "datFirstAdministeredDate", gcolFirstAntimicrobialAdminDate.Caption, , , , True)
            item.RegisterValidator(Me, True)
            item = New DateChainValidator(Me, dtFormCompletionDate, HumanCase_DB.tlbHumanCase, "datCompletionPaperFormDate", lblFormCompletionDate.Text)
            item.AddChild(New DateChainValidator(Me, dtEnteringDate, HumanCase_DB.tlbHumanCase, "datEnteredDate", lbDateEntered.Text))
            item.RegisterValidator(Me, True)
        End If

    End Sub
    Public Overrides Sub ShowHelp()
        If IsSearchMode Then
            ShowHelp("HC_H09")
        Else
            MyBase.ShowHelp()
        End If
    End Sub
    Public Overrides Sub ControlBoundChange(sender As Object, args As EventArgs)
        Dim designer As ControlDesigner = CType(sender, ControlDesigner)
        If (Not designer Is Nothing AndAlso Not designer.ProcessedControl Is Nothing) Then
            If designer.ProcessedControl Is lblDOB OrElse _
                designer.ProcessedControl Is lblFirstName OrElse _
                designer.ProcessedControl Is lblPatronymic OrElse _
                designer.ProcessedControl Is txtLastName OrElse _
                designer.ProcessedControl Is txtFirstName OrElse _
                designer.ProcessedControl Is txtSecondName Then
                lpCurrentResidenceAddress_Load(lpCurrentResidenceAddress, EventArgs.Empty)
                lpPermanentAddress_Load(lpPermanentAddress, EventArgs.Empty)
                lpEmployerAddress_Load(lpEmployerAddress, EventArgs.Empty)
            Else
                PatientInfo.ControlBoundChange(sender, args)
            End If
        End If
    End Sub
    Public Overrides Sub Addbuttons()
        MyBase.AddButtons()
        m_TranslationButton.Top = 9
        m_TranslationButton.Left = Width - m_TranslationButton.Width - 50
        m_TranslationButton.Parent = Me
        m_TranslationButton.BringToFront()

    End Sub

    Private ReadOnly Property IsSimplifiedMode As Boolean
        Get
            Return EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.UseSimplifiedHumanCaseReportForm))
        End Get
    End Property

    Private Sub SetSimplifiedMode()
        If (IsSimplifiedMode) Then
            TabControl1.TabPages.Remove(tpCaseInvestigation)
            TabControl1.TabPages.Remove(tpTests)
            miCaseInvestigationForm.Visible = False
        End If

    End Sub
    Protected Overrides Sub SaveGridLayouts()
        gvAntimicrobialTherapy.SaveGridLayout("AntimicrobialTherapy")
        gvContactPeople.SaveGridLayout("Contacts")
    End Sub
    Protected Overrides Sub LoadGridLayouts()
        gvAntimicrobialTherapy.InitXtraGridCustomization(New String() {"strAntimicrobialTherapyName"})
        gvContactPeople.InitXtraGridCustomization(New String() {"idfHuman", "idfsPersonContactType"})
        gvAntimicrobialTherapy.LoadGridLayout("AntimicrobialTherapy")
        gvContactPeople.LoadGridLayout("Contacts")
    End Sub

    Private m_TestsConductedChangedInCode As Boolean
    'Private Sub cbTestsConducted_EditValueChanged(sender As Object, e As System.EventArgs) Handles cbTestsConducted.EditValueChanged
    '    If Not m_TestsConductedChangedInCode AndAlso cbTestsConducted.EditValue.Equals(CLng(YesNoUnknownValuesEnum.Yes)) AndAlso Not HumanCaseSamplesPanel1.HasSamples() Then
    '        MessageForm.Show(EidssMessages.Get("msgSampleWasNotEnteredForHuman"))
    '    End If
    'End Sub
    Private Sub TestConducted_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        If Not m_TestsConductedChangedInCode AndAlso e.Value.Equals(CLng(YesNoUnknownValuesEnum.Yes)) AndAlso Not HumanCaseSamplesPanel1.HasSamples() Then
            MessageForm.Show(EidssMessages.Get("msgSampleWasNotEnteredForHuman"))
        End If
    End Sub


End Class




