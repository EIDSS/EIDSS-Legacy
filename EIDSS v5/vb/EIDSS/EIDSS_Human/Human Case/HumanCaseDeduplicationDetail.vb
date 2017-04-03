Imports bv.winclient.BasePanel
Imports bv.common.db
Imports EIDSS.model.Resources
Imports bv.common.Resources

Public Class HumanCaseDeduplicationDetail

    Inherits BaseDetailForm

    Dim HumanCaseDeduplicationDbService As HumanCaseDeduplication_DB

#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        HumanCaseDeduplicationDbService = New HumanCaseDeduplication_DB

        DbService = HumanCaseDeduplicationDbService
        AuditObject = New Core.EIDSSAuditObject(EIDSSAuditObject.daoHumanCaseDeduplication, AuditTable.tlbCase)
        'Me.PermissionObject = eidss.model.Enums.EIDSSPermissionObject.HumanCaseDeduplication
        Me.m_RelatedLists = New String() {"HumanCaseDeduplicationListItem", "HumanCaseListItem"}

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
    Friend WithEvents pnHCDeduplication As DevExpress.XtraEditors.PanelControl
    Friend WithEvents tcSuperseded As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tpNotificationSuperseded As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tcSurvivor As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tpNotificationSurvivor As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents gbSurvivor As DevExpress.XtraEditors.PanelControl
    Friend WithEvents gbSuperseded As DevExpress.XtraEditors.PanelControl
    Friend WithEvents cbSuperseded As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cbSurvivor As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents tbCaseIDSurvivor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbCaseIDSuperseded As DevExpress.XtraEditors.TextEdit
    Friend WithEvents rbCaseIDSuperseded As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents pnDemographicSurvivor As DevExpress.XtraEditors.GroupControl
    Friend WithEvents pnDemographicSuperseded As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblPatientNameSurvivor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents rbLastNameSurvivor As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents tbLastNameSurvivor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbFirstNameSurvivor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents rbFirstNameSurvivor As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents tbSecondNameSurvivor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents rbSecondNameSurvivor As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblPatientNameSuperseded As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbSecondNameSuperseded As DevExpress.XtraEditors.TextEdit
    Friend WithEvents rbLastNameSuperseded As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents rbSecondNameSuperseded As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents tbLastNameSuperseded As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbFirstNameSuperseded As DevExpress.XtraEditors.TextEdit
    Friend WithEvents rbFirstNameSuperseded As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents tbSexSurvivor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents rbDOBSurvivor As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents rbSexSurvivor As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents rbAgeSurvivor As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents tbDOBSurvivor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbAgeSurvivor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbAgeUnitsSurvivor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbAgeUnitsSuperseded As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbSexSuperseded As DevExpress.XtraEditors.TextEdit
    Friend WithEvents rbDOBSuperseded As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents rbSexSuperseded As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents rbAgeSuperseded As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents tbDOBSuperseded As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbAgeSuperseded As DevExpress.XtraEditors.TextEdit
    Friend WithEvents gbPatientInfoSurvivor As DevExpress.XtraEditors.GroupControl
    Friend WithEvents rbGeoLocationHomeIDSurvivor As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents tbRegionHomeSurvivor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblRegionHomeSurvivor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblRayonHomeSurvivor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbRayonHomeSurvivor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblStreetHomeSurvivor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbStreetHomeSurvivor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblSettlementHomeSurvivor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbSettlementHomeSurvivor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblPostalCodeHomeSurvivor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbPostalCodeHomeSurvivor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblHBAHomeSurvivor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbHouseHomeSurvivor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbAptmHomeSurvivor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbBuildingHomeSurvivor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents gbPatientInfoSuperseded As DevExpress.XtraEditors.GroupControl
    Friend WithEvents tbAptmHomeSuperseded As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbBuildingHomeSuperseded As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblHBAHomeSuperseded As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbHouseHomeSuperseded As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblPostalCodeHomeSuperseded As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbPostalCodeHomeSuperseded As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblStreetHomeSuperseded As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbStreetHomeSuperseded As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblSettlementHomeSuperseded As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbSettlementHomeSuperseded As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblRayonHomeSuperseded As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbRayonHomeSuperseded As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblRegionHomeSuperseded As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbRegionHomeSuperseded As DevExpress.XtraEditors.TextEdit
    Friend WithEvents rbGeoLocationHomeIDSuperseded As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents tbEmployerNameSurvivor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents rbPhoneNumberSurvivor As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents rbEmployerNameSurvivor As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents rbNationalitySurvivor As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents tbPhoneNumberSurvivor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbNationalitySurvivor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbGeoLocationEmployerSurvivor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents rbGeoLocationEmployerSurvivor As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents tbGeoLocationEmployerSuperseded As DevExpress.XtraEditors.TextEdit
    Friend WithEvents rbGeoLocationEmployerSuperseded As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents tbEmployerNameSuperseded As DevExpress.XtraEditors.TextEdit
    Friend WithEvents rbPhoneNumberSuperseded As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents rbEmployerNameSuperseded As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents rbNationalitySuperseded As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents tbPhoneNumberSuperseded As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbNationalitySuperseded As DevExpress.XtraEditors.TextEdit
    Friend WithEvents pnClinicalSurvivor As DevExpress.XtraEditors.GroupControl
    Friend WithEvents pnCaseIDSurvivor As DevExpress.XtraEditors.PanelControl
    Friend WithEvents rbCaseIDSurvivor As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents pnCaseIDSuperseded As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnSecondNameSurvivor As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnDOBSurvivor As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnLastNameSuperseded As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnFirstNameSurvivor As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnLastNameSurvivor As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnAgeSurvivor As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnSexSurvivor As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnFirstNameSuperseded As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnSecondNameSuperseded As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnDOBSuperseded As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnAgeSuperseded As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnSexSuperseded As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnEmployerNameSuperseded As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnGeoLocationEmployerSuperseded As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnGeoLocationHomeIDSuperseded As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnPhoneNumberSuperseded As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnNationalitySuperseded As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnGeoLocationHomeIDSurvivor As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnPhoneNumberSurvivor As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnNationalitySurvivor As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnEmployerNameSurvivor As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnGeoLocationEmployerSurvivor As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblLastNameSurvivor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblFirstNameSurvivor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblSecondNameSurvivor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblDOBSurvivor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblAgeSurvivor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblSexSurvivor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPhoneNumberSurvivor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblNationalitySurvivor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblEmployerNameSurvivor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblGeoLocationEmployerSurvivor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblLastNameSuperseded As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblFirstNameSuperseded As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCaseIDSuperseded As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCaseIDSurvivor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblSecondNameSuperseded As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblDOBSuperseded As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblAgeSuperseded As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblSexSuperseded As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPhoneNumberSuperseded As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblNationalitySuperseded As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblEmployerNameSuperseded As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblGeoLocationEmployerSuperseded As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblGeoLocationHomeIDSurvivor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblGeoLocationHomeIDSuperseded As DevExpress.XtraEditors.LabelControl
    Friend WithEvents pnDiagnosisSurvivor As DevExpress.XtraEditors.PanelControl
    Friend WithEvents rbDiagnosisSurvivor As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblDiagnosisSurvivor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbDiagnosisSurvivor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbDiagnosisDateSurvivor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents pnDiagnosisDateSurvivor As DevExpress.XtraEditors.PanelControl
    Friend WithEvents rbDiagnosisDateSurvivor As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblDiagnosisDateSurvivor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbDiagnosisSuperseded As DevExpress.XtraEditors.TextEdit
    Friend WithEvents pnDiagnosisSuperseded As DevExpress.XtraEditors.PanelControl
    Friend WithEvents rbDiagnosisSuperseded As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblDiagnosisSuperseded As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbDiagnosisDateSuperseded As DevExpress.XtraEditors.TextEdit
    Friend WithEvents pnDiagnosisDateSuperseded As DevExpress.XtraEditors.PanelControl
    Friend WithEvents rbDiagnosisDateSuperseded As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblDiagnosisDateSuperseded As DevExpress.XtraEditors.LabelControl
    Friend WithEvents pnOnsetDateSurvivor As DevExpress.XtraEditors.PanelControl
    Friend WithEvents rbOnsetDateSurvivor As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblOnsetDateSurvivor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbOnsetDateSurvivor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbFinalStateSurvivor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents pnFinalStateSurvivor As DevExpress.XtraEditors.PanelControl
    Friend WithEvents rbFinalStateSurvivor As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblFinalStateSurvivor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbChangedDiagnosisSurvivor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents pnChangedDiagnosisSurvivor As DevExpress.XtraEditors.PanelControl
    Friend WithEvents rbChangedDiagnosisSurvivor As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblChangedDiagnosisSurvivor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbChangedDiagnosisDateSurvivor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents pnChangedDiagnosisDateSurvivor As DevExpress.XtraEditors.PanelControl
    Friend WithEvents rbChangedDiagnosisDateSurvivor As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblChangedDiagnosisDateSurvivor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPatientLocationSurvivor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbPatientLocationStatusSurvivor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents pnPatientLocationStatusSurvivor As DevExpress.XtraEditors.PanelControl
    Friend WithEvents rbPatientLocationStatusSurvivor As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblPatientLocationStatusSurvivor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbPatientLocationNameSurvivor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents pnPatientLocationNameSurvivor As DevExpress.XtraEditors.PanelControl
    Friend WithEvents rbPatientLocationNameSurvivor As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblPatientLocationNameSurvivor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbAddCaseInfoSurvivor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents pnAddCaseInfoSurvivor As DevExpress.XtraEditors.PanelControl
    Friend WithEvents rbAddCaseInfoSurvivor As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblAddCaseInfoSurvivor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents pnClinicalSuperseded As DevExpress.XtraEditors.GroupControl
    Friend WithEvents tbAddCaseInfoSuperseded As DevExpress.XtraEditors.TextEdit
    Friend WithEvents pnAddCaseInfoSuperseded As DevExpress.XtraEditors.PanelControl
    Friend WithEvents rbAddCaseInfoSuperseded As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblAddCaseInfoSuperseded As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbPatientLocationNameSuperseded As DevExpress.XtraEditors.TextEdit
    Friend WithEvents pnPatientLocationNameSuperseded As DevExpress.XtraEditors.PanelControl
    Friend WithEvents rbPatientLocationNameSuperseded As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblPatientLocationNameSuperseded As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbPatientLocationStatusSuperseded As DevExpress.XtraEditors.TextEdit
    Friend WithEvents pnPatientLocationStatusSuperseded As DevExpress.XtraEditors.PanelControl
    Friend WithEvents rbPatientLocationStatusSuperseded As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblPatientLocationStatusSuperseded As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPatientLocationSuperseded As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbChangedDiagnosisDateSuperseded As DevExpress.XtraEditors.TextEdit
    Friend WithEvents pnChangedDiagnosisDateSuperseded As DevExpress.XtraEditors.PanelControl
    Friend WithEvents rbChangedDiagnosisDateSuperseded As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblChangedDiagnosisDateSuperseded As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbChangedDiagnosisSuperseded As DevExpress.XtraEditors.TextEdit
    Friend WithEvents pnChangedDiagnosisSuperseded As DevExpress.XtraEditors.PanelControl
    Friend WithEvents rbChangedDiagnosisSuperseded As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblChangedDiagnosisSuperseded As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbFinalStateSuperseded As DevExpress.XtraEditors.TextEdit
    Friend WithEvents pnFinalStateSuperseded As DevExpress.XtraEditors.PanelControl
    Friend WithEvents rbFinalStateSuperseded As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblFinalStateSuperseded As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbOnsetDateSuperseded As DevExpress.XtraEditors.TextEdit
    Friend WithEvents pnOnsetDateSuperseded As DevExpress.XtraEditors.PanelControl
    Friend WithEvents rbOnsetDateSuperseded As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblOnsetDateSuperseded As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnAllSurvivor As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAllSuperseded As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tbLocalIDSurvivor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents pnLocalIDSurvivor As DevExpress.XtraEditors.PanelControl
    Friend WithEvents rbLocalIDSurvivor As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblLocalIDSurvivor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbLocalIDSuperseded As DevExpress.XtraEditors.TextEdit
    Friend WithEvents pnLocalIDSuperseded As DevExpress.XtraEditors.PanelControl
    Friend WithEvents rbLocalIDSuperseded As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblLocalIDSuperseded As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tpSamplesSuperseded As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tpSamplesSurvivor As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents gcSamplesSurvivor As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvSamplesSurvivor As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gcolMaterialIDSurvivor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolRowTypeSurvivor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolSampleIDSurvivor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolCheckedSurvivor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents chAddToCaseSurvivor As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents gcolSampleTypeSurvivor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolCollectionDateSurvivor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcSamplesSuperseded As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvSamplesSuperseded As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gcolMaterialIDSuperseded As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolRowTypeSuperseded As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolCheckedSuperseded As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents chAddToCaseSuperseded As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents gcolSampleIDSuperseded As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolSampleTypeSuperseded As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolCollectionDateSuperseded As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolTestQuantitySuperseded As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolTestQuantitySurvivor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolCanUncheckSurvivor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolCanUncheckSuperseded As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.GroupControl


    'Required by the Windows Form Designer

    Private components As System.ComponentModel.IContainer


    'NOTE: The following procedure is required by the Windows Form Designer

    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HumanCaseDeduplicationDetail))
        Me.pnHCDeduplication = New DevExpress.XtraEditors.PanelControl
        Me.gbSurvivor = New DevExpress.XtraEditors.PanelControl
        Me.btnAllSurvivor = New DevExpress.XtraEditors.SimpleButton
        Me.cbSurvivor = New DevExpress.XtraEditors.ComboBoxEdit
        Me.gbSuperseded = New DevExpress.XtraEditors.PanelControl
        Me.btnAllSuperseded = New DevExpress.XtraEditors.SimpleButton
        Me.cbSuperseded = New DevExpress.XtraEditors.ComboBoxEdit
        Me.tcSuperseded = New DevExpress.XtraTab.XtraTabControl
        Me.tpNotificationSuperseded = New DevExpress.XtraTab.XtraTabPage
        Me.tbLocalIDSuperseded = New DevExpress.XtraEditors.TextEdit
        Me.pnLocalIDSuperseded = New DevExpress.XtraEditors.PanelControl
        Me.rbLocalIDSuperseded = New DevExpress.XtraEditors.CheckEdit
        Me.lblLocalIDSuperseded = New DevExpress.XtraEditors.LabelControl
        Me.pnClinicalSuperseded = New DevExpress.XtraEditors.GroupControl
        Me.LabelControl6 = New DevExpress.XtraEditors.GroupControl
        Me.LabelControl5 = New DevExpress.XtraEditors.GroupControl
        Me.tbAddCaseInfoSuperseded = New DevExpress.XtraEditors.TextEdit
        Me.pnAddCaseInfoSuperseded = New DevExpress.XtraEditors.PanelControl
        Me.rbAddCaseInfoSuperseded = New DevExpress.XtraEditors.CheckEdit
        Me.lblAddCaseInfoSuperseded = New DevExpress.XtraEditors.LabelControl
        Me.tbPatientLocationNameSuperseded = New DevExpress.XtraEditors.TextEdit
        Me.pnPatientLocationNameSuperseded = New DevExpress.XtraEditors.PanelControl
        Me.rbPatientLocationNameSuperseded = New DevExpress.XtraEditors.CheckEdit
        Me.lblPatientLocationNameSuperseded = New DevExpress.XtraEditors.LabelControl
        Me.tbPatientLocationStatusSuperseded = New DevExpress.XtraEditors.TextEdit
        Me.pnPatientLocationStatusSuperseded = New DevExpress.XtraEditors.PanelControl
        Me.rbPatientLocationStatusSuperseded = New DevExpress.XtraEditors.CheckEdit
        Me.lblPatientLocationStatusSuperseded = New DevExpress.XtraEditors.LabelControl
        Me.lblPatientLocationSuperseded = New DevExpress.XtraEditors.LabelControl
        Me.tbChangedDiagnosisDateSuperseded = New DevExpress.XtraEditors.TextEdit
        Me.pnChangedDiagnosisDateSuperseded = New DevExpress.XtraEditors.PanelControl
        Me.rbChangedDiagnosisDateSuperseded = New DevExpress.XtraEditors.CheckEdit
        Me.lblChangedDiagnosisDateSuperseded = New DevExpress.XtraEditors.LabelControl
        Me.tbChangedDiagnosisSuperseded = New DevExpress.XtraEditors.TextEdit
        Me.pnChangedDiagnosisSuperseded = New DevExpress.XtraEditors.PanelControl
        Me.rbChangedDiagnosisSuperseded = New DevExpress.XtraEditors.CheckEdit
        Me.lblChangedDiagnosisSuperseded = New DevExpress.XtraEditors.LabelControl
        Me.tbFinalStateSuperseded = New DevExpress.XtraEditors.TextEdit
        Me.pnFinalStateSuperseded = New DevExpress.XtraEditors.PanelControl
        Me.rbFinalStateSuperseded = New DevExpress.XtraEditors.CheckEdit
        Me.lblFinalStateSuperseded = New DevExpress.XtraEditors.LabelControl
        Me.tbOnsetDateSuperseded = New DevExpress.XtraEditors.TextEdit
        Me.pnOnsetDateSuperseded = New DevExpress.XtraEditors.PanelControl
        Me.rbOnsetDateSuperseded = New DevExpress.XtraEditors.CheckEdit
        Me.lblOnsetDateSuperseded = New DevExpress.XtraEditors.LabelControl
        Me.tbDiagnosisDateSuperseded = New DevExpress.XtraEditors.TextEdit
        Me.pnDiagnosisDateSuperseded = New DevExpress.XtraEditors.PanelControl
        Me.rbDiagnosisDateSuperseded = New DevExpress.XtraEditors.CheckEdit
        Me.lblDiagnosisDateSuperseded = New DevExpress.XtraEditors.LabelControl
        Me.tbDiagnosisSuperseded = New DevExpress.XtraEditors.TextEdit
        Me.pnDiagnosisSuperseded = New DevExpress.XtraEditors.PanelControl
        Me.rbDiagnosisSuperseded = New DevExpress.XtraEditors.CheckEdit
        Me.lblDiagnosisSuperseded = New DevExpress.XtraEditors.LabelControl
        Me.pnDemographicSuperseded = New DevExpress.XtraEditors.GroupControl
        Me.LabelControl4 = New DevExpress.XtraEditors.GroupControl
        Me.LabelControl1 = New DevExpress.XtraEditors.GroupControl
        Me.tbGeoLocationEmployerSuperseded = New DevExpress.XtraEditors.TextEdit
        Me.tbEmployerNameSuperseded = New DevExpress.XtraEditors.TextEdit
        Me.tbPhoneNumberSuperseded = New DevExpress.XtraEditors.TextEdit
        Me.tbNationalitySuperseded = New DevExpress.XtraEditors.TextEdit
        Me.gbPatientInfoSuperseded = New DevExpress.XtraEditors.GroupControl
        Me.tbAptmHomeSuperseded = New DevExpress.XtraEditors.TextEdit
        Me.tbBuildingHomeSuperseded = New DevExpress.XtraEditors.TextEdit
        Me.lblHBAHomeSuperseded = New DevExpress.XtraEditors.LabelControl
        Me.tbHouseHomeSuperseded = New DevExpress.XtraEditors.TextEdit
        Me.lblPostalCodeHomeSuperseded = New DevExpress.XtraEditors.LabelControl
        Me.tbPostalCodeHomeSuperseded = New DevExpress.XtraEditors.TextEdit
        Me.lblStreetHomeSuperseded = New DevExpress.XtraEditors.LabelControl
        Me.tbStreetHomeSuperseded = New DevExpress.XtraEditors.TextEdit
        Me.lblSettlementHomeSuperseded = New DevExpress.XtraEditors.LabelControl
        Me.tbSettlementHomeSuperseded = New DevExpress.XtraEditors.TextEdit
        Me.lblRayonHomeSuperseded = New DevExpress.XtraEditors.LabelControl
        Me.tbRayonHomeSuperseded = New DevExpress.XtraEditors.TextEdit
        Me.lblRegionHomeSuperseded = New DevExpress.XtraEditors.LabelControl
        Me.tbRegionHomeSuperseded = New DevExpress.XtraEditors.TextEdit
        Me.tbAgeUnitsSuperseded = New DevExpress.XtraEditors.TextEdit
        Me.tbSexSuperseded = New DevExpress.XtraEditors.TextEdit
        Me.tbDOBSuperseded = New DevExpress.XtraEditors.TextEdit
        Me.tbAgeSuperseded = New DevExpress.XtraEditors.TextEdit
        Me.lblPatientNameSuperseded = New DevExpress.XtraEditors.LabelControl
        Me.tbSecondNameSuperseded = New DevExpress.XtraEditors.TextEdit
        Me.tbLastNameSuperseded = New DevExpress.XtraEditors.TextEdit
        Me.tbFirstNameSuperseded = New DevExpress.XtraEditors.TextEdit
        Me.pnLastNameSuperseded = New DevExpress.XtraEditors.PanelControl
        Me.rbLastNameSuperseded = New DevExpress.XtraEditors.CheckEdit
        Me.lblLastNameSuperseded = New DevExpress.XtraEditors.LabelControl
        Me.pnFirstNameSuperseded = New DevExpress.XtraEditors.PanelControl
        Me.rbFirstNameSuperseded = New DevExpress.XtraEditors.CheckEdit
        Me.lblFirstNameSuperseded = New DevExpress.XtraEditors.LabelControl
        Me.pnSecondNameSuperseded = New DevExpress.XtraEditors.PanelControl
        Me.rbSecondNameSuperseded = New DevExpress.XtraEditors.CheckEdit
        Me.lblSecondNameSuperseded = New DevExpress.XtraEditors.LabelControl
        Me.pnDOBSuperseded = New DevExpress.XtraEditors.PanelControl
        Me.rbDOBSuperseded = New DevExpress.XtraEditors.CheckEdit
        Me.lblDOBSuperseded = New DevExpress.XtraEditors.LabelControl
        Me.pnAgeSuperseded = New DevExpress.XtraEditors.PanelControl
        Me.rbAgeSuperseded = New DevExpress.XtraEditors.CheckEdit
        Me.lblAgeSuperseded = New DevExpress.XtraEditors.LabelControl
        Me.pnSexSuperseded = New DevExpress.XtraEditors.PanelControl
        Me.rbSexSuperseded = New DevExpress.XtraEditors.CheckEdit
        Me.lblSexSuperseded = New DevExpress.XtraEditors.LabelControl
        Me.pnGeoLocationHomeIDSuperseded = New DevExpress.XtraEditors.PanelControl
        Me.rbGeoLocationHomeIDSuperseded = New DevExpress.XtraEditors.CheckEdit
        Me.lblGeoLocationHomeIDSuperseded = New DevExpress.XtraEditors.LabelControl
        Me.pnPhoneNumberSuperseded = New DevExpress.XtraEditors.PanelControl
        Me.rbPhoneNumberSuperseded = New DevExpress.XtraEditors.CheckEdit
        Me.lblPhoneNumberSuperseded = New DevExpress.XtraEditors.LabelControl
        Me.pnNationalitySuperseded = New DevExpress.XtraEditors.PanelControl
        Me.rbNationalitySuperseded = New DevExpress.XtraEditors.CheckEdit
        Me.lblNationalitySuperseded = New DevExpress.XtraEditors.LabelControl
        Me.pnEmployerNameSuperseded = New DevExpress.XtraEditors.PanelControl
        Me.lblEmployerNameSuperseded = New DevExpress.XtraEditors.LabelControl
        Me.rbEmployerNameSuperseded = New DevExpress.XtraEditors.CheckEdit
        Me.pnGeoLocationEmployerSuperseded = New DevExpress.XtraEditors.PanelControl
        Me.lblGeoLocationEmployerSuperseded = New DevExpress.XtraEditors.LabelControl
        Me.rbGeoLocationEmployerSuperseded = New DevExpress.XtraEditors.CheckEdit
        Me.tbCaseIDSuperseded = New DevExpress.XtraEditors.TextEdit
        Me.pnCaseIDSuperseded = New DevExpress.XtraEditors.PanelControl
        Me.rbCaseIDSuperseded = New DevExpress.XtraEditors.CheckEdit
        Me.lblCaseIDSuperseded = New DevExpress.XtraEditors.LabelControl
        Me.tpSamplesSuperseded = New DevExpress.XtraTab.XtraTabPage
        Me.gcSamplesSuperseded = New DevExpress.XtraGrid.GridControl
        Me.gvSamplesSuperseded = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.gcolMaterialIDSuperseded = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gcolRowTypeSuperseded = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gcolCheckedSuperseded = New DevExpress.XtraGrid.Columns.GridColumn
        Me.chAddToCaseSuperseded = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.gcolSampleIDSuperseded = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gcolSampleTypeSuperseded = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gcolCollectionDateSuperseded = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gcolTestQuantitySuperseded = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gcolCanUncheckSuperseded = New DevExpress.XtraGrid.Columns.GridColumn
        Me.tcSurvivor = New DevExpress.XtraTab.XtraTabControl
        Me.tpNotificationSurvivor = New DevExpress.XtraTab.XtraTabPage
        Me.tbLocalIDSurvivor = New DevExpress.XtraEditors.TextEdit
        Me.pnLocalIDSurvivor = New DevExpress.XtraEditors.PanelControl
        Me.rbLocalIDSurvivor = New DevExpress.XtraEditors.CheckEdit
        Me.lblLocalIDSurvivor = New DevExpress.XtraEditors.LabelControl
        Me.pnClinicalSurvivor = New DevExpress.XtraEditors.GroupControl
        Me.LabelControl8 = New DevExpress.XtraEditors.GroupControl
        Me.LabelControl7 = New DevExpress.XtraEditors.GroupControl
        Me.tbAddCaseInfoSurvivor = New DevExpress.XtraEditors.TextEdit
        Me.pnAddCaseInfoSurvivor = New DevExpress.XtraEditors.PanelControl
        Me.rbAddCaseInfoSurvivor = New DevExpress.XtraEditors.CheckEdit
        Me.lblAddCaseInfoSurvivor = New DevExpress.XtraEditors.LabelControl
        Me.tbPatientLocationNameSurvivor = New DevExpress.XtraEditors.TextEdit
        Me.pnPatientLocationNameSurvivor = New DevExpress.XtraEditors.PanelControl
        Me.rbPatientLocationNameSurvivor = New DevExpress.XtraEditors.CheckEdit
        Me.lblPatientLocationNameSurvivor = New DevExpress.XtraEditors.LabelControl
        Me.tbPatientLocationStatusSurvivor = New DevExpress.XtraEditors.TextEdit
        Me.pnPatientLocationStatusSurvivor = New DevExpress.XtraEditors.PanelControl
        Me.rbPatientLocationStatusSurvivor = New DevExpress.XtraEditors.CheckEdit
        Me.lblPatientLocationStatusSurvivor = New DevExpress.XtraEditors.LabelControl
        Me.lblPatientLocationSurvivor = New DevExpress.XtraEditors.LabelControl
        Me.tbChangedDiagnosisDateSurvivor = New DevExpress.XtraEditors.TextEdit
        Me.pnChangedDiagnosisDateSurvivor = New DevExpress.XtraEditors.PanelControl
        Me.rbChangedDiagnosisDateSurvivor = New DevExpress.XtraEditors.CheckEdit
        Me.lblChangedDiagnosisDateSurvivor = New DevExpress.XtraEditors.LabelControl
        Me.tbChangedDiagnosisSurvivor = New DevExpress.XtraEditors.TextEdit
        Me.pnChangedDiagnosisSurvivor = New DevExpress.XtraEditors.PanelControl
        Me.rbChangedDiagnosisSurvivor = New DevExpress.XtraEditors.CheckEdit
        Me.lblChangedDiagnosisSurvivor = New DevExpress.XtraEditors.LabelControl
        Me.tbFinalStateSurvivor = New DevExpress.XtraEditors.TextEdit
        Me.pnFinalStateSurvivor = New DevExpress.XtraEditors.PanelControl
        Me.rbFinalStateSurvivor = New DevExpress.XtraEditors.CheckEdit
        Me.lblFinalStateSurvivor = New DevExpress.XtraEditors.LabelControl
        Me.tbOnsetDateSurvivor = New DevExpress.XtraEditors.TextEdit
        Me.pnOnsetDateSurvivor = New DevExpress.XtraEditors.PanelControl
        Me.rbOnsetDateSurvivor = New DevExpress.XtraEditors.CheckEdit
        Me.lblOnsetDateSurvivor = New DevExpress.XtraEditors.LabelControl
        Me.tbDiagnosisDateSurvivor = New DevExpress.XtraEditors.TextEdit
        Me.pnDiagnosisDateSurvivor = New DevExpress.XtraEditors.PanelControl
        Me.rbDiagnosisDateSurvivor = New DevExpress.XtraEditors.CheckEdit
        Me.lblDiagnosisDateSurvivor = New DevExpress.XtraEditors.LabelControl
        Me.tbDiagnosisSurvivor = New DevExpress.XtraEditors.TextEdit
        Me.pnDiagnosisSurvivor = New DevExpress.XtraEditors.PanelControl
        Me.rbDiagnosisSurvivor = New DevExpress.XtraEditors.CheckEdit
        Me.lblDiagnosisSurvivor = New DevExpress.XtraEditors.LabelControl
        Me.pnDemographicSurvivor = New DevExpress.XtraEditors.GroupControl
        Me.LabelControl3 = New DevExpress.XtraEditors.GroupControl
        Me.LabelControl2 = New DevExpress.XtraEditors.GroupControl
        Me.tbGeoLocationEmployerSurvivor = New DevExpress.XtraEditors.TextEdit
        Me.tbEmployerNameSurvivor = New DevExpress.XtraEditors.TextEdit
        Me.tbPhoneNumberSurvivor = New DevExpress.XtraEditors.TextEdit
        Me.tbNationalitySurvivor = New DevExpress.XtraEditors.TextEdit
        Me.tbAptmHomeSurvivor = New DevExpress.XtraEditors.TextEdit
        Me.tbBuildingHomeSurvivor = New DevExpress.XtraEditors.TextEdit
        Me.lblHBAHomeSurvivor = New DevExpress.XtraEditors.LabelControl
        Me.tbHouseHomeSurvivor = New DevExpress.XtraEditors.TextEdit
        Me.lblPostalCodeHomeSurvivor = New DevExpress.XtraEditors.LabelControl
        Me.tbPostalCodeHomeSurvivor = New DevExpress.XtraEditors.TextEdit
        Me.lblStreetHomeSurvivor = New DevExpress.XtraEditors.LabelControl
        Me.tbStreetHomeSurvivor = New DevExpress.XtraEditors.TextEdit
        Me.lblSettlementHomeSurvivor = New DevExpress.XtraEditors.LabelControl
        Me.tbSettlementHomeSurvivor = New DevExpress.XtraEditors.TextEdit
        Me.lblRayonHomeSurvivor = New DevExpress.XtraEditors.LabelControl
        Me.tbRayonHomeSurvivor = New DevExpress.XtraEditors.TextEdit
        Me.lblRegionHomeSurvivor = New DevExpress.XtraEditors.LabelControl
        Me.tbRegionHomeSurvivor = New DevExpress.XtraEditors.TextEdit
        Me.gbPatientInfoSurvivor = New DevExpress.XtraEditors.GroupControl
        Me.tbAgeUnitsSurvivor = New DevExpress.XtraEditors.TextEdit
        Me.tbSexSurvivor = New DevExpress.XtraEditors.TextEdit
        Me.tbDOBSurvivor = New DevExpress.XtraEditors.TextEdit
        Me.tbAgeSurvivor = New DevExpress.XtraEditors.TextEdit
        Me.lblPatientNameSurvivor = New DevExpress.XtraEditors.LabelControl
        Me.tbSecondNameSurvivor = New DevExpress.XtraEditors.TextEdit
        Me.tbLastNameSurvivor = New DevExpress.XtraEditors.TextEdit
        Me.tbFirstNameSurvivor = New DevExpress.XtraEditors.TextEdit
        Me.pnLastNameSurvivor = New DevExpress.XtraEditors.PanelControl
        Me.rbLastNameSurvivor = New DevExpress.XtraEditors.CheckEdit
        Me.lblLastNameSurvivor = New DevExpress.XtraEditors.LabelControl
        Me.pnFirstNameSurvivor = New DevExpress.XtraEditors.PanelControl
        Me.rbFirstNameSurvivor = New DevExpress.XtraEditors.CheckEdit
        Me.lblFirstNameSurvivor = New DevExpress.XtraEditors.LabelControl
        Me.pnSecondNameSurvivor = New DevExpress.XtraEditors.PanelControl
        Me.rbSecondNameSurvivor = New DevExpress.XtraEditors.CheckEdit
        Me.lblSecondNameSurvivor = New DevExpress.XtraEditors.LabelControl
        Me.pnDOBSurvivor = New DevExpress.XtraEditors.PanelControl
        Me.rbDOBSurvivor = New DevExpress.XtraEditors.CheckEdit
        Me.lblDOBSurvivor = New DevExpress.XtraEditors.LabelControl
        Me.pnAgeSurvivor = New DevExpress.XtraEditors.PanelControl
        Me.rbAgeSurvivor = New DevExpress.XtraEditors.CheckEdit
        Me.lblAgeSurvivor = New DevExpress.XtraEditors.LabelControl
        Me.pnSexSurvivor = New DevExpress.XtraEditors.PanelControl
        Me.rbSexSurvivor = New DevExpress.XtraEditors.CheckEdit
        Me.lblSexSurvivor = New DevExpress.XtraEditors.LabelControl
        Me.pnPhoneNumberSurvivor = New DevExpress.XtraEditors.PanelControl
        Me.rbPhoneNumberSurvivor = New DevExpress.XtraEditors.CheckEdit
        Me.lblPhoneNumberSurvivor = New DevExpress.XtraEditors.LabelControl
        Me.pnNationalitySurvivor = New DevExpress.XtraEditors.PanelControl
        Me.rbNationalitySurvivor = New DevExpress.XtraEditors.CheckEdit
        Me.lblNationalitySurvivor = New DevExpress.XtraEditors.LabelControl
        Me.pnEmployerNameSurvivor = New DevExpress.XtraEditors.PanelControl
        Me.lblEmployerNameSurvivor = New DevExpress.XtraEditors.LabelControl
        Me.rbEmployerNameSurvivor = New DevExpress.XtraEditors.CheckEdit
        Me.pnGeoLocationEmployerSurvivor = New DevExpress.XtraEditors.PanelControl
        Me.lblGeoLocationEmployerSurvivor = New DevExpress.XtraEditors.LabelControl
        Me.rbGeoLocationEmployerSurvivor = New DevExpress.XtraEditors.CheckEdit
        Me.pnGeoLocationHomeIDSurvivor = New DevExpress.XtraEditors.PanelControl
        Me.rbGeoLocationHomeIDSurvivor = New DevExpress.XtraEditors.CheckEdit
        Me.lblGeoLocationHomeIDSurvivor = New DevExpress.XtraEditors.LabelControl
        Me.tbCaseIDSurvivor = New DevExpress.XtraEditors.TextEdit
        Me.pnCaseIDSurvivor = New DevExpress.XtraEditors.PanelControl
        Me.rbCaseIDSurvivor = New DevExpress.XtraEditors.CheckEdit
        Me.lblCaseIDSurvivor = New DevExpress.XtraEditors.LabelControl
        Me.tpSamplesSurvivor = New DevExpress.XtraTab.XtraTabPage
        Me.gcSamplesSurvivor = New DevExpress.XtraGrid.GridControl
        Me.gvSamplesSurvivor = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.gcolMaterialIDSurvivor = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gcolRowTypeSurvivor = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gcolCheckedSurvivor = New DevExpress.XtraGrid.Columns.GridColumn
        Me.chAddToCaseSurvivor = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Me.gcolSampleIDSurvivor = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gcolSampleTypeSurvivor = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gcolCollectionDateSurvivor = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gcolTestQuantitySurvivor = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gcolCanUncheckSurvivor = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.pnHCDeduplication, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnHCDeduplication.SuspendLayout()
        CType(Me.gbSurvivor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSurvivor.SuspendLayout()
        CType(Me.cbSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbSuperseded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSuperseded.SuspendLayout()
        CType(Me.cbSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tcSuperseded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcSuperseded.SuspendLayout()
        Me.tpNotificationSuperseded.SuspendLayout()
        CType(Me.tbLocalIDSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnLocalIDSuperseded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLocalIDSuperseded.SuspendLayout()
        CType(Me.rbLocalIDSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnClinicalSuperseded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnClinicalSuperseded.SuspendLayout()
        CType(Me.LabelControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAddCaseInfoSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnAddCaseInfoSuperseded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnAddCaseInfoSuperseded.SuspendLayout()
        CType(Me.rbAddCaseInfoSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPatientLocationNameSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnPatientLocationNameSuperseded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnPatientLocationNameSuperseded.SuspendLayout()
        CType(Me.rbPatientLocationNameSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPatientLocationStatusSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnPatientLocationStatusSuperseded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnPatientLocationStatusSuperseded.SuspendLayout()
        CType(Me.rbPatientLocationStatusSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbChangedDiagnosisDateSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnChangedDiagnosisDateSuperseded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnChangedDiagnosisDateSuperseded.SuspendLayout()
        CType(Me.rbChangedDiagnosisDateSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbChangedDiagnosisSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnChangedDiagnosisSuperseded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnChangedDiagnosisSuperseded.SuspendLayout()
        CType(Me.rbChangedDiagnosisSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbFinalStateSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnFinalStateSuperseded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnFinalStateSuperseded.SuspendLayout()
        CType(Me.rbFinalStateSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbOnsetDateSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnOnsetDateSuperseded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnOnsetDateSuperseded.SuspendLayout()
        CType(Me.rbOnsetDateSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDiagnosisDateSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnDiagnosisDateSuperseded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnDiagnosisDateSuperseded.SuspendLayout()
        CType(Me.rbDiagnosisDateSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDiagnosisSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnDiagnosisSuperseded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnDiagnosisSuperseded.SuspendLayout()
        CType(Me.rbDiagnosisSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnDemographicSuperseded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnDemographicSuperseded.SuspendLayout()
        CType(Me.LabelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbGeoLocationEmployerSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbEmployerNameSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPhoneNumberSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbNationalitySuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbPatientInfoSuperseded, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAptmHomeSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbBuildingHomeSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbHouseHomeSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPostalCodeHomeSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbStreetHomeSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSettlementHomeSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbRayonHomeSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbRegionHomeSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAgeUnitsSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSexSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDOBSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAgeSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSecondNameSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbLastNameSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbFirstNameSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnLastNameSuperseded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLastNameSuperseded.SuspendLayout()
        CType(Me.rbLastNameSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnFirstNameSuperseded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnFirstNameSuperseded.SuspendLayout()
        CType(Me.rbFirstNameSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnSecondNameSuperseded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnSecondNameSuperseded.SuspendLayout()
        CType(Me.rbSecondNameSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnDOBSuperseded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnDOBSuperseded.SuspendLayout()
        CType(Me.rbDOBSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnAgeSuperseded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnAgeSuperseded.SuspendLayout()
        CType(Me.rbAgeSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnSexSuperseded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnSexSuperseded.SuspendLayout()
        CType(Me.rbSexSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnGeoLocationHomeIDSuperseded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnGeoLocationHomeIDSuperseded.SuspendLayout()
        CType(Me.rbGeoLocationHomeIDSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnPhoneNumberSuperseded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnPhoneNumberSuperseded.SuspendLayout()
        CType(Me.rbPhoneNumberSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnNationalitySuperseded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnNationalitySuperseded.SuspendLayout()
        CType(Me.rbNationalitySuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnEmployerNameSuperseded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnEmployerNameSuperseded.SuspendLayout()
        CType(Me.rbEmployerNameSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnGeoLocationEmployerSuperseded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnGeoLocationEmployerSuperseded.SuspendLayout()
        CType(Me.rbGeoLocationEmployerSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbCaseIDSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnCaseIDSuperseded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnCaseIDSuperseded.SuspendLayout()
        CType(Me.rbCaseIDSuperseded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpSamplesSuperseded.SuspendLayout()
        CType(Me.gcSamplesSuperseded, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvSamplesSuperseded, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chAddToCaseSuperseded, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tcSurvivor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcSurvivor.SuspendLayout()
        Me.tpNotificationSurvivor.SuspendLayout()
        CType(Me.tbLocalIDSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnLocalIDSurvivor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLocalIDSurvivor.SuspendLayout()
        CType(Me.rbLocalIDSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnClinicalSurvivor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnClinicalSurvivor.SuspendLayout()
        CType(Me.LabelControl8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelControl7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAddCaseInfoSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnAddCaseInfoSurvivor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnAddCaseInfoSurvivor.SuspendLayout()
        CType(Me.rbAddCaseInfoSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPatientLocationNameSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnPatientLocationNameSurvivor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnPatientLocationNameSurvivor.SuspendLayout()
        CType(Me.rbPatientLocationNameSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPatientLocationStatusSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnPatientLocationStatusSurvivor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnPatientLocationStatusSurvivor.SuspendLayout()
        CType(Me.rbPatientLocationStatusSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbChangedDiagnosisDateSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnChangedDiagnosisDateSurvivor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnChangedDiagnosisDateSurvivor.SuspendLayout()
        CType(Me.rbChangedDiagnosisDateSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbChangedDiagnosisSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnChangedDiagnosisSurvivor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnChangedDiagnosisSurvivor.SuspendLayout()
        CType(Me.rbChangedDiagnosisSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbFinalStateSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnFinalStateSurvivor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnFinalStateSurvivor.SuspendLayout()
        CType(Me.rbFinalStateSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbOnsetDateSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnOnsetDateSurvivor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnOnsetDateSurvivor.SuspendLayout()
        CType(Me.rbOnsetDateSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDiagnosisDateSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnDiagnosisDateSurvivor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnDiagnosisDateSurvivor.SuspendLayout()
        CType(Me.rbDiagnosisDateSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDiagnosisSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnDiagnosisSurvivor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnDiagnosisSurvivor.SuspendLayout()
        CType(Me.rbDiagnosisSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnDemographicSurvivor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnDemographicSurvivor.SuspendLayout()
        CType(Me.LabelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbGeoLocationEmployerSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbEmployerNameSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPhoneNumberSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbNationalitySurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAptmHomeSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbBuildingHomeSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbHouseHomeSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPostalCodeHomeSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbStreetHomeSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSettlementHomeSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbRayonHomeSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbRegionHomeSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbPatientInfoSurvivor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAgeUnitsSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSexSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDOBSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbAgeSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSecondNameSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbLastNameSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbFirstNameSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnLastNameSurvivor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnLastNameSurvivor.SuspendLayout()
        CType(Me.rbLastNameSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnFirstNameSurvivor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnFirstNameSurvivor.SuspendLayout()
        CType(Me.rbFirstNameSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnSecondNameSurvivor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnSecondNameSurvivor.SuspendLayout()
        CType(Me.rbSecondNameSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnDOBSurvivor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnDOBSurvivor.SuspendLayout()
        CType(Me.rbDOBSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnAgeSurvivor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnAgeSurvivor.SuspendLayout()
        CType(Me.rbAgeSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnSexSurvivor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnSexSurvivor.SuspendLayout()
        CType(Me.rbSexSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnPhoneNumberSurvivor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnPhoneNumberSurvivor.SuspendLayout()
        CType(Me.rbPhoneNumberSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnNationalitySurvivor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnNationalitySurvivor.SuspendLayout()
        CType(Me.rbNationalitySurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnEmployerNameSurvivor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnEmployerNameSurvivor.SuspendLayout()
        CType(Me.rbEmployerNameSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnGeoLocationEmployerSurvivor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnGeoLocationEmployerSurvivor.SuspendLayout()
        CType(Me.rbGeoLocationEmployerSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnGeoLocationHomeIDSurvivor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnGeoLocationHomeIDSurvivor.SuspendLayout()
        CType(Me.rbGeoLocationHomeIDSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbCaseIDSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnCaseIDSurvivor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnCaseIDSurvivor.SuspendLayout()
        CType(Me.rbCaseIDSurvivor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpSamplesSurvivor.SuspendLayout()
        CType(Me.gcSamplesSurvivor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvSamplesSurvivor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chAddToCaseSurvivor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnHCDeduplication
        '
        resources.ApplyResources(Me.pnHCDeduplication, "pnHCDeduplication")
        Me.pnHCDeduplication.Controls.Add(Me.gbSurvivor)
        Me.pnHCDeduplication.Controls.Add(Me.gbSuperseded)
        Me.pnHCDeduplication.Controls.Add(Me.tcSuperseded)
        Me.pnHCDeduplication.Controls.Add(Me.tcSurvivor)
        Me.pnHCDeduplication.Name = "pnHCDeduplication"
        Me.pnHCDeduplication.TabStop = True
        '
        'gbSurvivor
        '
        Me.gbSurvivor.Controls.Add(Me.btnAllSurvivor)
        Me.gbSurvivor.Controls.Add(Me.cbSurvivor)
        resources.ApplyResources(Me.gbSurvivor, "gbSurvivor")
        Me.gbSurvivor.Name = "gbSurvivor"
        '
        'btnAllSurvivor
        '
        resources.ApplyResources(Me.btnAllSurvivor, "btnAllSurvivor")
        Me.btnAllSurvivor.Name = "btnAllSurvivor"
        '
        'cbSurvivor
        '
        resources.ApplyResources(Me.cbSurvivor, "cbSurvivor")
        Me.cbSurvivor.Name = "cbSurvivor"
        Me.cbSurvivor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSurvivor.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        '
        'gbSuperseded
        '
        Me.gbSuperseded.Controls.Add(Me.btnAllSuperseded)
        Me.gbSuperseded.Controls.Add(Me.cbSuperseded)
        resources.ApplyResources(Me.gbSuperseded, "gbSuperseded")
        Me.gbSuperseded.Name = "gbSuperseded"
        '
        'btnAllSuperseded
        '
        resources.ApplyResources(Me.btnAllSuperseded, "btnAllSuperseded")
        Me.btnAllSuperseded.Name = "btnAllSuperseded"
        '
        'cbSuperseded
        '
        resources.ApplyResources(Me.cbSuperseded, "cbSuperseded")
        Me.cbSuperseded.Name = "cbSuperseded"
        Me.cbSuperseded.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cbSuperseded.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        '
        'tcSuperseded
        '
        resources.ApplyResources(Me.tcSuperseded, "tcSuperseded")
        Me.tcSuperseded.Name = "tcSuperseded"
        Me.tcSuperseded.SelectedTabPage = Me.tpNotificationSuperseded
        Me.tcSuperseded.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tpNotificationSuperseded, Me.tpSamplesSuperseded})
        '
        'tpNotificationSuperseded
        '
        Me.tpNotificationSuperseded.Appearance.PageClient.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tpNotificationSuperseded.Appearance.PageClient.Options.UseBackColor = True
        resources.ApplyResources(Me.tpNotificationSuperseded, "tpNotificationSuperseded")
        Me.tpNotificationSuperseded.Controls.Add(Me.tbLocalIDSuperseded)
        Me.tpNotificationSuperseded.Controls.Add(Me.pnLocalIDSuperseded)
        Me.tpNotificationSuperseded.Controls.Add(Me.pnClinicalSuperseded)
        Me.tpNotificationSuperseded.Controls.Add(Me.tbDiagnosisDateSuperseded)
        Me.tpNotificationSuperseded.Controls.Add(Me.pnDiagnosisDateSuperseded)
        Me.tpNotificationSuperseded.Controls.Add(Me.tbDiagnosisSuperseded)
        Me.tpNotificationSuperseded.Controls.Add(Me.pnDiagnosisSuperseded)
        Me.tpNotificationSuperseded.Controls.Add(Me.pnDemographicSuperseded)
        Me.tpNotificationSuperseded.Controls.Add(Me.tbCaseIDSuperseded)
        Me.tpNotificationSuperseded.Controls.Add(Me.pnCaseIDSuperseded)
        Me.tpNotificationSuperseded.Name = "tpNotificationSuperseded"
        '
        'tbLocalIDSuperseded
        '
        resources.ApplyResources(Me.tbLocalIDSuperseded, "tbLocalIDSuperseded")
        Me.tbLocalIDSuperseded.Name = "tbLocalIDSuperseded"
        '
        'pnLocalIDSuperseded
        '
        Me.pnLocalIDSuperseded.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnLocalIDSuperseded.Controls.Add(Me.rbLocalIDSuperseded)
        Me.pnLocalIDSuperseded.Controls.Add(Me.lblLocalIDSuperseded)
        resources.ApplyResources(Me.pnLocalIDSuperseded, "pnLocalIDSuperseded")
        Me.pnLocalIDSuperseded.Name = "pnLocalIDSuperseded"
        Me.pnLocalIDSuperseded.TabStop = True
        '
        'rbLocalIDSuperseded
        '
        resources.ApplyResources(Me.rbLocalIDSuperseded, "rbLocalIDSuperseded")
        Me.rbLocalIDSuperseded.Name = "rbLocalIDSuperseded"
        Me.rbLocalIDSuperseded.Properties.Caption = resources.GetString("rbLocalIDSuperseded.Properties.Caption")
        Me.rbLocalIDSuperseded.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblLocalIDSuperseded
        '
        resources.ApplyResources(Me.lblLocalIDSuperseded, "lblLocalIDSuperseded")
        Me.lblLocalIDSuperseded.Name = "lblLocalIDSuperseded"
        '
        'pnClinicalSuperseded
        '
        Me.pnClinicalSuperseded.Controls.Add(Me.LabelControl6)
        Me.pnClinicalSuperseded.Controls.Add(Me.LabelControl5)
        Me.pnClinicalSuperseded.Controls.Add(Me.tbAddCaseInfoSuperseded)
        Me.pnClinicalSuperseded.Controls.Add(Me.pnAddCaseInfoSuperseded)
        Me.pnClinicalSuperseded.Controls.Add(Me.tbPatientLocationNameSuperseded)
        Me.pnClinicalSuperseded.Controls.Add(Me.pnPatientLocationNameSuperseded)
        Me.pnClinicalSuperseded.Controls.Add(Me.tbPatientLocationStatusSuperseded)
        Me.pnClinicalSuperseded.Controls.Add(Me.pnPatientLocationStatusSuperseded)
        Me.pnClinicalSuperseded.Controls.Add(Me.lblPatientLocationSuperseded)
        Me.pnClinicalSuperseded.Controls.Add(Me.tbChangedDiagnosisDateSuperseded)
        Me.pnClinicalSuperseded.Controls.Add(Me.pnChangedDiagnosisDateSuperseded)
        Me.pnClinicalSuperseded.Controls.Add(Me.tbChangedDiagnosisSuperseded)
        Me.pnClinicalSuperseded.Controls.Add(Me.pnChangedDiagnosisSuperseded)
        Me.pnClinicalSuperseded.Controls.Add(Me.tbFinalStateSuperseded)
        Me.pnClinicalSuperseded.Controls.Add(Me.pnFinalStateSuperseded)
        Me.pnClinicalSuperseded.Controls.Add(Me.tbOnsetDateSuperseded)
        Me.pnClinicalSuperseded.Controls.Add(Me.pnOnsetDateSuperseded)
        resources.ApplyResources(Me.pnClinicalSuperseded, "pnClinicalSuperseded")
        Me.pnClinicalSuperseded.Name = "pnClinicalSuperseded"
        Me.pnClinicalSuperseded.TabStop = True
        '
        'LabelControl6
        '
        resources.ApplyResources(Me.LabelControl6, "LabelControl6")
        Me.LabelControl6.Name = "LabelControl6"
        '
        'LabelControl5
        '
        resources.ApplyResources(Me.LabelControl5, "LabelControl5")
        Me.LabelControl5.Name = "LabelControl5"
        '
        'tbAddCaseInfoSuperseded
        '
        resources.ApplyResources(Me.tbAddCaseInfoSuperseded, "tbAddCaseInfoSuperseded")
        Me.tbAddCaseInfoSuperseded.Name = "tbAddCaseInfoSuperseded"
        Me.tbAddCaseInfoSuperseded.Properties.AutoHeight = CType(resources.GetObject("tbAddCaseInfoSuperseded.Properties.AutoHeight"), Boolean)
        '
        'pnAddCaseInfoSuperseded
        '
        Me.pnAddCaseInfoSuperseded.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnAddCaseInfoSuperseded.Controls.Add(Me.rbAddCaseInfoSuperseded)
        Me.pnAddCaseInfoSuperseded.Controls.Add(Me.lblAddCaseInfoSuperseded)
        resources.ApplyResources(Me.pnAddCaseInfoSuperseded, "pnAddCaseInfoSuperseded")
        Me.pnAddCaseInfoSuperseded.Name = "pnAddCaseInfoSuperseded"
        Me.pnAddCaseInfoSuperseded.TabStop = True
        '
        'rbAddCaseInfoSuperseded
        '
        resources.ApplyResources(Me.rbAddCaseInfoSuperseded, "rbAddCaseInfoSuperseded")
        Me.rbAddCaseInfoSuperseded.Name = "rbAddCaseInfoSuperseded"
        Me.rbAddCaseInfoSuperseded.Properties.Caption = resources.GetString("rbAddCaseInfoSuperseded.Properties.Caption")
        Me.rbAddCaseInfoSuperseded.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblAddCaseInfoSuperseded
        '
        resources.ApplyResources(Me.lblAddCaseInfoSuperseded, "lblAddCaseInfoSuperseded")
        Me.lblAddCaseInfoSuperseded.Name = "lblAddCaseInfoSuperseded"
        '
        'tbPatientLocationNameSuperseded
        '
        resources.ApplyResources(Me.tbPatientLocationNameSuperseded, "tbPatientLocationNameSuperseded")
        Me.tbPatientLocationNameSuperseded.Name = "tbPatientLocationNameSuperseded"
        '
        'pnPatientLocationNameSuperseded
        '
        Me.pnPatientLocationNameSuperseded.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnPatientLocationNameSuperseded.Controls.Add(Me.lblPatientLocationNameSuperseded)
        Me.pnPatientLocationNameSuperseded.Controls.Add(Me.rbPatientLocationNameSuperseded)
        resources.ApplyResources(Me.pnPatientLocationNameSuperseded, "pnPatientLocationNameSuperseded")
        Me.pnPatientLocationNameSuperseded.Name = "pnPatientLocationNameSuperseded"
        Me.pnPatientLocationNameSuperseded.TabStop = True
        '
        'rbPatientLocationNameSuperseded
        '
        resources.ApplyResources(Me.rbPatientLocationNameSuperseded, "rbPatientLocationNameSuperseded")
        Me.rbPatientLocationNameSuperseded.Name = "rbPatientLocationNameSuperseded"
        Me.rbPatientLocationNameSuperseded.Properties.Caption = resources.GetString("rbPatientLocationNameSuperseded.Properties.Caption")
        Me.rbPatientLocationNameSuperseded.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblPatientLocationNameSuperseded
        '
        Me.lblPatientLocationNameSuperseded.Appearance.Options.UseTextOptions = True
        Me.lblPatientLocationNameSuperseded.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        resources.ApplyResources(Me.lblPatientLocationNameSuperseded, "lblPatientLocationNameSuperseded")
        Me.lblPatientLocationNameSuperseded.Name = "lblPatientLocationNameSuperseded"
        '
        'tbPatientLocationStatusSuperseded
        '
        resources.ApplyResources(Me.tbPatientLocationStatusSuperseded, "tbPatientLocationStatusSuperseded")
        Me.tbPatientLocationStatusSuperseded.Name = "tbPatientLocationStatusSuperseded"
        '
        'pnPatientLocationStatusSuperseded
        '
        Me.pnPatientLocationStatusSuperseded.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnPatientLocationStatusSuperseded.Controls.Add(Me.rbPatientLocationStatusSuperseded)
        Me.pnPatientLocationStatusSuperseded.Controls.Add(Me.lblPatientLocationStatusSuperseded)
        resources.ApplyResources(Me.pnPatientLocationStatusSuperseded, "pnPatientLocationStatusSuperseded")
        Me.pnPatientLocationStatusSuperseded.Name = "pnPatientLocationStatusSuperseded"
        Me.pnPatientLocationStatusSuperseded.TabStop = True
        '
        'rbPatientLocationStatusSuperseded
        '
        resources.ApplyResources(Me.rbPatientLocationStatusSuperseded, "rbPatientLocationStatusSuperseded")
        Me.rbPatientLocationStatusSuperseded.Name = "rbPatientLocationStatusSuperseded"
        Me.rbPatientLocationStatusSuperseded.Properties.Caption = resources.GetString("rbPatientLocationStatusSuperseded.Properties.Caption")
        Me.rbPatientLocationStatusSuperseded.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblPatientLocationStatusSuperseded
        '
        resources.ApplyResources(Me.lblPatientLocationStatusSuperseded, "lblPatientLocationStatusSuperseded")
        Me.lblPatientLocationStatusSuperseded.Name = "lblPatientLocationStatusSuperseded"
        '
        'lblPatientLocationSuperseded
        '
        Me.lblPatientLocationSuperseded.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblPatientLocationSuperseded.Appearance.Options.UseFont = True
        Me.lblPatientLocationSuperseded.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        resources.ApplyResources(Me.lblPatientLocationSuperseded, "lblPatientLocationSuperseded")
        Me.lblPatientLocationSuperseded.Name = "lblPatientLocationSuperseded"
        '
        'tbChangedDiagnosisDateSuperseded
        '
        resources.ApplyResources(Me.tbChangedDiagnosisDateSuperseded, "tbChangedDiagnosisDateSuperseded")
        Me.tbChangedDiagnosisDateSuperseded.Name = "tbChangedDiagnosisDateSuperseded"
        '
        'pnChangedDiagnosisDateSuperseded
        '
        Me.pnChangedDiagnosisDateSuperseded.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnChangedDiagnosisDateSuperseded.Controls.Add(Me.rbChangedDiagnosisDateSuperseded)
        Me.pnChangedDiagnosisDateSuperseded.Controls.Add(Me.lblChangedDiagnosisDateSuperseded)
        resources.ApplyResources(Me.pnChangedDiagnosisDateSuperseded, "pnChangedDiagnosisDateSuperseded")
        Me.pnChangedDiagnosisDateSuperseded.Name = "pnChangedDiagnosisDateSuperseded"
        Me.pnChangedDiagnosisDateSuperseded.TabStop = True
        '
        'rbChangedDiagnosisDateSuperseded
        '
        resources.ApplyResources(Me.rbChangedDiagnosisDateSuperseded, "rbChangedDiagnosisDateSuperseded")
        Me.rbChangedDiagnosisDateSuperseded.Name = "rbChangedDiagnosisDateSuperseded"
        Me.rbChangedDiagnosisDateSuperseded.Properties.Caption = resources.GetString("rbChangedDiagnosisDateSuperseded.Properties.Caption")
        Me.rbChangedDiagnosisDateSuperseded.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblChangedDiagnosisDateSuperseded
        '
        resources.ApplyResources(Me.lblChangedDiagnosisDateSuperseded, "lblChangedDiagnosisDateSuperseded")
        Me.lblChangedDiagnosisDateSuperseded.Name = "lblChangedDiagnosisDateSuperseded"
        '
        'tbChangedDiagnosisSuperseded
        '
        resources.ApplyResources(Me.tbChangedDiagnosisSuperseded, "tbChangedDiagnosisSuperseded")
        Me.tbChangedDiagnosisSuperseded.Name = "tbChangedDiagnosisSuperseded"
        '
        'pnChangedDiagnosisSuperseded
        '
        Me.pnChangedDiagnosisSuperseded.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnChangedDiagnosisSuperseded.Controls.Add(Me.rbChangedDiagnosisSuperseded)
        Me.pnChangedDiagnosisSuperseded.Controls.Add(Me.lblChangedDiagnosisSuperseded)
        resources.ApplyResources(Me.pnChangedDiagnosisSuperseded, "pnChangedDiagnosisSuperseded")
        Me.pnChangedDiagnosisSuperseded.Name = "pnChangedDiagnosisSuperseded"
        Me.pnChangedDiagnosisSuperseded.TabStop = True
        '
        'rbChangedDiagnosisSuperseded
        '
        resources.ApplyResources(Me.rbChangedDiagnosisSuperseded, "rbChangedDiagnosisSuperseded")
        Me.rbChangedDiagnosisSuperseded.Name = "rbChangedDiagnosisSuperseded"
        Me.rbChangedDiagnosisSuperseded.Properties.Caption = resources.GetString("rbChangedDiagnosisSuperseded.Properties.Caption")
        Me.rbChangedDiagnosisSuperseded.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblChangedDiagnosisSuperseded
        '
        resources.ApplyResources(Me.lblChangedDiagnosisSuperseded, "lblChangedDiagnosisSuperseded")
        Me.lblChangedDiagnosisSuperseded.Name = "lblChangedDiagnosisSuperseded"
        '
        'tbFinalStateSuperseded
        '
        resources.ApplyResources(Me.tbFinalStateSuperseded, "tbFinalStateSuperseded")
        Me.tbFinalStateSuperseded.Name = "tbFinalStateSuperseded"
        '
        'pnFinalStateSuperseded
        '
        Me.pnFinalStateSuperseded.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnFinalStateSuperseded.Controls.Add(Me.rbFinalStateSuperseded)
        Me.pnFinalStateSuperseded.Controls.Add(Me.lblFinalStateSuperseded)
        resources.ApplyResources(Me.pnFinalStateSuperseded, "pnFinalStateSuperseded")
        Me.pnFinalStateSuperseded.Name = "pnFinalStateSuperseded"
        Me.pnFinalStateSuperseded.TabStop = True
        '
        'rbFinalStateSuperseded
        '
        resources.ApplyResources(Me.rbFinalStateSuperseded, "rbFinalStateSuperseded")
        Me.rbFinalStateSuperseded.Name = "rbFinalStateSuperseded"
        Me.rbFinalStateSuperseded.Properties.Caption = resources.GetString("rbFinalStateSuperseded.Properties.Caption")
        Me.rbFinalStateSuperseded.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblFinalStateSuperseded
        '
        resources.ApplyResources(Me.lblFinalStateSuperseded, "lblFinalStateSuperseded")
        Me.lblFinalStateSuperseded.Name = "lblFinalStateSuperseded"
        '
        'tbOnsetDateSuperseded
        '
        resources.ApplyResources(Me.tbOnsetDateSuperseded, "tbOnsetDateSuperseded")
        Me.tbOnsetDateSuperseded.Name = "tbOnsetDateSuperseded"
        '
        'pnOnsetDateSuperseded
        '
        Me.pnOnsetDateSuperseded.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnOnsetDateSuperseded.Controls.Add(Me.rbOnsetDateSuperseded)
        Me.pnOnsetDateSuperseded.Controls.Add(Me.lblOnsetDateSuperseded)
        resources.ApplyResources(Me.pnOnsetDateSuperseded, "pnOnsetDateSuperseded")
        Me.pnOnsetDateSuperseded.Name = "pnOnsetDateSuperseded"
        Me.pnOnsetDateSuperseded.TabStop = True
        '
        'rbOnsetDateSuperseded
        '
        resources.ApplyResources(Me.rbOnsetDateSuperseded, "rbOnsetDateSuperseded")
        Me.rbOnsetDateSuperseded.Name = "rbOnsetDateSuperseded"
        Me.rbOnsetDateSuperseded.Properties.Caption = resources.GetString("rbOnsetDateSuperseded.Properties.Caption")
        Me.rbOnsetDateSuperseded.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblOnsetDateSuperseded
        '
        resources.ApplyResources(Me.lblOnsetDateSuperseded, "lblOnsetDateSuperseded")
        Me.lblOnsetDateSuperseded.Name = "lblOnsetDateSuperseded"
        '
        'tbDiagnosisDateSuperseded
        '
        resources.ApplyResources(Me.tbDiagnosisDateSuperseded, "tbDiagnosisDateSuperseded")
        Me.tbDiagnosisDateSuperseded.Name = "tbDiagnosisDateSuperseded"
        '
        'pnDiagnosisDateSuperseded
        '
        Me.pnDiagnosisDateSuperseded.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnDiagnosisDateSuperseded.Controls.Add(Me.rbDiagnosisDateSuperseded)
        Me.pnDiagnosisDateSuperseded.Controls.Add(Me.lblDiagnosisDateSuperseded)
        resources.ApplyResources(Me.pnDiagnosisDateSuperseded, "pnDiagnosisDateSuperseded")
        Me.pnDiagnosisDateSuperseded.Name = "pnDiagnosisDateSuperseded"
        Me.pnDiagnosisDateSuperseded.TabStop = True
        '
        'rbDiagnosisDateSuperseded
        '
        resources.ApplyResources(Me.rbDiagnosisDateSuperseded, "rbDiagnosisDateSuperseded")
        Me.rbDiagnosisDateSuperseded.Name = "rbDiagnosisDateSuperseded"
        Me.rbDiagnosisDateSuperseded.Properties.Caption = resources.GetString("rbDiagnosisDateSuperseded.Properties.Caption")
        Me.rbDiagnosisDateSuperseded.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblDiagnosisDateSuperseded
        '
        resources.ApplyResources(Me.lblDiagnosisDateSuperseded, "lblDiagnosisDateSuperseded")
        Me.lblDiagnosisDateSuperseded.Name = "lblDiagnosisDateSuperseded"
        '
        'tbDiagnosisSuperseded
        '
        resources.ApplyResources(Me.tbDiagnosisSuperseded, "tbDiagnosisSuperseded")
        Me.tbDiagnosisSuperseded.Name = "tbDiagnosisSuperseded"
        '
        'pnDiagnosisSuperseded
        '
        Me.pnDiagnosisSuperseded.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnDiagnosisSuperseded.Controls.Add(Me.rbDiagnosisSuperseded)
        Me.pnDiagnosisSuperseded.Controls.Add(Me.lblDiagnosisSuperseded)
        resources.ApplyResources(Me.pnDiagnosisSuperseded, "pnDiagnosisSuperseded")
        Me.pnDiagnosisSuperseded.Name = "pnDiagnosisSuperseded"
        Me.pnDiagnosisSuperseded.TabStop = True
        '
        'rbDiagnosisSuperseded
        '
        resources.ApplyResources(Me.rbDiagnosisSuperseded, "rbDiagnosisSuperseded")
        Me.rbDiagnosisSuperseded.Name = "rbDiagnosisSuperseded"
        Me.rbDiagnosisSuperseded.Properties.Caption = resources.GetString("rbDiagnosisSuperseded.Properties.Caption")
        Me.rbDiagnosisSuperseded.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblDiagnosisSuperseded
        '
        resources.ApplyResources(Me.lblDiagnosisSuperseded, "lblDiagnosisSuperseded")
        Me.lblDiagnosisSuperseded.Name = "lblDiagnosisSuperseded"
        '
        'pnDemographicSuperseded
        '
        Me.pnDemographicSuperseded.Controls.Add(Me.LabelControl4)
        Me.pnDemographicSuperseded.Controls.Add(Me.LabelControl1)
        Me.pnDemographicSuperseded.Controls.Add(Me.tbGeoLocationEmployerSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.tbEmployerNameSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.tbPhoneNumberSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.tbNationalitySuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.gbPatientInfoSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.tbAptmHomeSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.tbBuildingHomeSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.lblHBAHomeSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.tbHouseHomeSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.lblPostalCodeHomeSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.tbPostalCodeHomeSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.lblStreetHomeSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.tbStreetHomeSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.lblSettlementHomeSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.tbSettlementHomeSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.lblRayonHomeSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.tbRayonHomeSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.lblRegionHomeSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.tbRegionHomeSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.tbAgeUnitsSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.tbSexSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.tbDOBSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.tbAgeSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.lblPatientNameSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.tbSecondNameSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.tbLastNameSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.tbFirstNameSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.pnLastNameSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.pnFirstNameSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.pnSecondNameSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.pnDOBSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.pnAgeSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.pnSexSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.pnGeoLocationHomeIDSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.pnPhoneNumberSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.pnNationalitySuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.pnEmployerNameSuperseded)
        Me.pnDemographicSuperseded.Controls.Add(Me.pnGeoLocationEmployerSuperseded)
        resources.ApplyResources(Me.pnDemographicSuperseded, "pnDemographicSuperseded")
        Me.pnDemographicSuperseded.Name = "pnDemographicSuperseded"
        Me.pnDemographicSuperseded.TabStop = True
        '
        'LabelControl4
        '
        resources.ApplyResources(Me.LabelControl4, "LabelControl4")
        Me.LabelControl4.Name = "LabelControl4"
        '
        'LabelControl1
        '
        resources.ApplyResources(Me.LabelControl1, "LabelControl1")
        Me.LabelControl1.Name = "LabelControl1"
        '
        'tbGeoLocationEmployerSuperseded
        '
        resources.ApplyResources(Me.tbGeoLocationEmployerSuperseded, "tbGeoLocationEmployerSuperseded")
        Me.tbGeoLocationEmployerSuperseded.Name = "tbGeoLocationEmployerSuperseded"
        '
        'tbEmployerNameSuperseded
        '
        resources.ApplyResources(Me.tbEmployerNameSuperseded, "tbEmployerNameSuperseded")
        Me.tbEmployerNameSuperseded.Name = "tbEmployerNameSuperseded"
        '
        'tbPhoneNumberSuperseded
        '
        resources.ApplyResources(Me.tbPhoneNumberSuperseded, "tbPhoneNumberSuperseded")
        Me.tbPhoneNumberSuperseded.Name = "tbPhoneNumberSuperseded"
        '
        'tbNationalitySuperseded
        '
        resources.ApplyResources(Me.tbNationalitySuperseded, "tbNationalitySuperseded")
        Me.tbNationalitySuperseded.Name = "tbNationalitySuperseded"
        '
        'gbPatientInfoSuperseded
        '
        resources.ApplyResources(Me.gbPatientInfoSuperseded, "gbPatientInfoSuperseded")
        Me.gbPatientInfoSuperseded.Name = "gbPatientInfoSuperseded"
        '
        'tbAptmHomeSuperseded
        '
        resources.ApplyResources(Me.tbAptmHomeSuperseded, "tbAptmHomeSuperseded")
        Me.tbAptmHomeSuperseded.Name = "tbAptmHomeSuperseded"
        '
        'tbBuildingHomeSuperseded
        '
        resources.ApplyResources(Me.tbBuildingHomeSuperseded, "tbBuildingHomeSuperseded")
        Me.tbBuildingHomeSuperseded.Name = "tbBuildingHomeSuperseded"
        '
        'lblHBAHomeSuperseded
        '
        resources.ApplyResources(Me.lblHBAHomeSuperseded, "lblHBAHomeSuperseded")
        Me.lblHBAHomeSuperseded.Name = "lblHBAHomeSuperseded"
        '
        'tbHouseHomeSuperseded
        '
        resources.ApplyResources(Me.tbHouseHomeSuperseded, "tbHouseHomeSuperseded")
        Me.tbHouseHomeSuperseded.Name = "tbHouseHomeSuperseded"
        '
        'lblPostalCodeHomeSuperseded
        '
        resources.ApplyResources(Me.lblPostalCodeHomeSuperseded, "lblPostalCodeHomeSuperseded")
        Me.lblPostalCodeHomeSuperseded.Name = "lblPostalCodeHomeSuperseded"
        '
        'tbPostalCodeHomeSuperseded
        '
        resources.ApplyResources(Me.tbPostalCodeHomeSuperseded, "tbPostalCodeHomeSuperseded")
        Me.tbPostalCodeHomeSuperseded.Name = "tbPostalCodeHomeSuperseded"
        '
        'lblStreetHomeSuperseded
        '
        resources.ApplyResources(Me.lblStreetHomeSuperseded, "lblStreetHomeSuperseded")
        Me.lblStreetHomeSuperseded.Name = "lblStreetHomeSuperseded"
        '
        'tbStreetHomeSuperseded
        '
        resources.ApplyResources(Me.tbStreetHomeSuperseded, "tbStreetHomeSuperseded")
        Me.tbStreetHomeSuperseded.Name = "tbStreetHomeSuperseded"
        '
        'lblSettlementHomeSuperseded
        '
        resources.ApplyResources(Me.lblSettlementHomeSuperseded, "lblSettlementHomeSuperseded")
        Me.lblSettlementHomeSuperseded.Name = "lblSettlementHomeSuperseded"
        '
        'tbSettlementHomeSuperseded
        '
        resources.ApplyResources(Me.tbSettlementHomeSuperseded, "tbSettlementHomeSuperseded")
        Me.tbSettlementHomeSuperseded.Name = "tbSettlementHomeSuperseded"
        '
        'lblRayonHomeSuperseded
        '
        resources.ApplyResources(Me.lblRayonHomeSuperseded, "lblRayonHomeSuperseded")
        Me.lblRayonHomeSuperseded.Name = "lblRayonHomeSuperseded"
        '
        'tbRayonHomeSuperseded
        '
        resources.ApplyResources(Me.tbRayonHomeSuperseded, "tbRayonHomeSuperseded")
        Me.tbRayonHomeSuperseded.Name = "tbRayonHomeSuperseded"
        '
        'lblRegionHomeSuperseded
        '
        resources.ApplyResources(Me.lblRegionHomeSuperseded, "lblRegionHomeSuperseded")
        Me.lblRegionHomeSuperseded.Name = "lblRegionHomeSuperseded"
        '
        'tbRegionHomeSuperseded
        '
        resources.ApplyResources(Me.tbRegionHomeSuperseded, "tbRegionHomeSuperseded")
        Me.tbRegionHomeSuperseded.Name = "tbRegionHomeSuperseded"
        '
        'tbAgeUnitsSuperseded
        '
        resources.ApplyResources(Me.tbAgeUnitsSuperseded, "tbAgeUnitsSuperseded")
        Me.tbAgeUnitsSuperseded.Name = "tbAgeUnitsSuperseded"
        Me.tbAgeUnitsSuperseded.Properties.AutoHeight = CType(resources.GetObject("tbAgeUnitsSuperseded.Properties.AutoHeight"), Boolean)
        '
        'tbSexSuperseded
        '
        resources.ApplyResources(Me.tbSexSuperseded, "tbSexSuperseded")
        Me.tbSexSuperseded.Name = "tbSexSuperseded"
        '
        'tbDOBSuperseded
        '
        resources.ApplyResources(Me.tbDOBSuperseded, "tbDOBSuperseded")
        Me.tbDOBSuperseded.Name = "tbDOBSuperseded"
        '
        'tbAgeSuperseded
        '
        resources.ApplyResources(Me.tbAgeSuperseded, "tbAgeSuperseded")
        Me.tbAgeSuperseded.Name = "tbAgeSuperseded"
        Me.tbAgeSuperseded.Properties.AutoHeight = CType(resources.GetObject("tbAgeSuperseded.Properties.AutoHeight"), Boolean)
        '
        'lblPatientNameSuperseded
        '
        Me.lblPatientNameSuperseded.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblPatientNameSuperseded.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPatientNameSuperseded, "lblPatientNameSuperseded")
        Me.lblPatientNameSuperseded.Name = "lblPatientNameSuperseded"
        '
        'tbSecondNameSuperseded
        '
        resources.ApplyResources(Me.tbSecondNameSuperseded, "tbSecondNameSuperseded")
        Me.tbSecondNameSuperseded.Name = "tbSecondNameSuperseded"
        '
        'tbLastNameSuperseded
        '
        resources.ApplyResources(Me.tbLastNameSuperseded, "tbLastNameSuperseded")
        Me.tbLastNameSuperseded.Name = "tbLastNameSuperseded"
        '
        'tbFirstNameSuperseded
        '
        resources.ApplyResources(Me.tbFirstNameSuperseded, "tbFirstNameSuperseded")
        Me.tbFirstNameSuperseded.Name = "tbFirstNameSuperseded"
        '
        'pnLastNameSuperseded
        '
        Me.pnLastNameSuperseded.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnLastNameSuperseded.Controls.Add(Me.rbLastNameSuperseded)
        Me.pnLastNameSuperseded.Controls.Add(Me.lblLastNameSuperseded)
        resources.ApplyResources(Me.pnLastNameSuperseded, "pnLastNameSuperseded")
        Me.pnLastNameSuperseded.Name = "pnLastNameSuperseded"
        Me.pnLastNameSuperseded.TabStop = True
        '
        'rbLastNameSuperseded
        '
        resources.ApplyResources(Me.rbLastNameSuperseded, "rbLastNameSuperseded")
        Me.rbLastNameSuperseded.Name = "rbLastNameSuperseded"
        Me.rbLastNameSuperseded.Properties.Caption = resources.GetString("rbLastNameSuperseded.Properties.Caption")
        Me.rbLastNameSuperseded.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblLastNameSuperseded
        '
        resources.ApplyResources(Me.lblLastNameSuperseded, "lblLastNameSuperseded")
        Me.lblLastNameSuperseded.Name = "lblLastNameSuperseded"
        '
        'pnFirstNameSuperseded
        '
        Me.pnFirstNameSuperseded.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnFirstNameSuperseded.Controls.Add(Me.rbFirstNameSuperseded)
        Me.pnFirstNameSuperseded.Controls.Add(Me.lblFirstNameSuperseded)
        resources.ApplyResources(Me.pnFirstNameSuperseded, "pnFirstNameSuperseded")
        Me.pnFirstNameSuperseded.Name = "pnFirstNameSuperseded"
        Me.pnFirstNameSuperseded.TabStop = True
        '
        'rbFirstNameSuperseded
        '
        resources.ApplyResources(Me.rbFirstNameSuperseded, "rbFirstNameSuperseded")
        Me.rbFirstNameSuperseded.Name = "rbFirstNameSuperseded"
        Me.rbFirstNameSuperseded.Properties.Caption = resources.GetString("rbFirstNameSuperseded.Properties.Caption")
        Me.rbFirstNameSuperseded.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblFirstNameSuperseded
        '
        resources.ApplyResources(Me.lblFirstNameSuperseded, "lblFirstNameSuperseded")
        Me.lblFirstNameSuperseded.Name = "lblFirstNameSuperseded"
        '
        'pnSecondNameSuperseded
        '
        Me.pnSecondNameSuperseded.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnSecondNameSuperseded.Controls.Add(Me.rbSecondNameSuperseded)
        Me.pnSecondNameSuperseded.Controls.Add(Me.lblSecondNameSuperseded)
        resources.ApplyResources(Me.pnSecondNameSuperseded, "pnSecondNameSuperseded")
        Me.pnSecondNameSuperseded.Name = "pnSecondNameSuperseded"
        Me.pnSecondNameSuperseded.TabStop = True
        '
        'rbSecondNameSuperseded
        '
        resources.ApplyResources(Me.rbSecondNameSuperseded, "rbSecondNameSuperseded")
        Me.rbSecondNameSuperseded.Name = "rbSecondNameSuperseded"
        Me.rbSecondNameSuperseded.Properties.Caption = resources.GetString("rbSecondNameSuperseded.Properties.Caption")
        Me.rbSecondNameSuperseded.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblSecondNameSuperseded
        '
        resources.ApplyResources(Me.lblSecondNameSuperseded, "lblSecondNameSuperseded")
        Me.lblSecondNameSuperseded.Name = "lblSecondNameSuperseded"
        '
        'pnDOBSuperseded
        '
        Me.pnDOBSuperseded.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnDOBSuperseded.Controls.Add(Me.rbDOBSuperseded)
        Me.pnDOBSuperseded.Controls.Add(Me.lblDOBSuperseded)
        resources.ApplyResources(Me.pnDOBSuperseded, "pnDOBSuperseded")
        Me.pnDOBSuperseded.Name = "pnDOBSuperseded"
        Me.pnDOBSuperseded.TabStop = True
        '
        'rbDOBSuperseded
        '
        resources.ApplyResources(Me.rbDOBSuperseded, "rbDOBSuperseded")
        Me.rbDOBSuperseded.Name = "rbDOBSuperseded"
        Me.rbDOBSuperseded.Properties.Caption = resources.GetString("rbDOBSuperseded.Properties.Caption")
        Me.rbDOBSuperseded.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblDOBSuperseded
        '
        resources.ApplyResources(Me.lblDOBSuperseded, "lblDOBSuperseded")
        Me.lblDOBSuperseded.Name = "lblDOBSuperseded"
        '
        'pnAgeSuperseded
        '
        Me.pnAgeSuperseded.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnAgeSuperseded.Controls.Add(Me.rbAgeSuperseded)
        Me.pnAgeSuperseded.Controls.Add(Me.lblAgeSuperseded)
        resources.ApplyResources(Me.pnAgeSuperseded, "pnAgeSuperseded")
        Me.pnAgeSuperseded.Name = "pnAgeSuperseded"
        Me.pnAgeSuperseded.TabStop = True
        '
        'rbAgeSuperseded
        '
        resources.ApplyResources(Me.rbAgeSuperseded, "rbAgeSuperseded")
        Me.rbAgeSuperseded.Name = "rbAgeSuperseded"
        Me.rbAgeSuperseded.Properties.Caption = resources.GetString("rbAgeSuperseded.Properties.Caption")
        Me.rbAgeSuperseded.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblAgeSuperseded
        '
        resources.ApplyResources(Me.lblAgeSuperseded, "lblAgeSuperseded")
        Me.lblAgeSuperseded.Name = "lblAgeSuperseded"
        '
        'pnSexSuperseded
        '
        Me.pnSexSuperseded.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnSexSuperseded.Controls.Add(Me.rbSexSuperseded)
        Me.pnSexSuperseded.Controls.Add(Me.lblSexSuperseded)
        resources.ApplyResources(Me.pnSexSuperseded, "pnSexSuperseded")
        Me.pnSexSuperseded.Name = "pnSexSuperseded"
        Me.pnSexSuperseded.TabStop = True
        '
        'rbSexSuperseded
        '
        resources.ApplyResources(Me.rbSexSuperseded, "rbSexSuperseded")
        Me.rbSexSuperseded.Name = "rbSexSuperseded"
        Me.rbSexSuperseded.Properties.Caption = resources.GetString("rbSexSuperseded.Properties.Caption")
        Me.rbSexSuperseded.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblSexSuperseded
        '
        resources.ApplyResources(Me.lblSexSuperseded, "lblSexSuperseded")
        Me.lblSexSuperseded.Name = "lblSexSuperseded"
        '
        'pnGeoLocationHomeIDSuperseded
        '
        resources.ApplyResources(Me.pnGeoLocationHomeIDSuperseded, "pnGeoLocationHomeIDSuperseded")
        Me.pnGeoLocationHomeIDSuperseded.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnGeoLocationHomeIDSuperseded.Controls.Add(Me.rbGeoLocationHomeIDSuperseded)
        Me.pnGeoLocationHomeIDSuperseded.Controls.Add(Me.lblGeoLocationHomeIDSuperseded)
        Me.pnGeoLocationHomeIDSuperseded.Name = "pnGeoLocationHomeIDSuperseded"
        Me.pnGeoLocationHomeIDSuperseded.TabStop = True
        '
        'rbGeoLocationHomeIDSuperseded
        '
        resources.ApplyResources(Me.rbGeoLocationHomeIDSuperseded, "rbGeoLocationHomeIDSuperseded")
        Me.rbGeoLocationHomeIDSuperseded.Name = "rbGeoLocationHomeIDSuperseded"
        Me.rbGeoLocationHomeIDSuperseded.Properties.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.rbGeoLocationHomeIDSuperseded.Properties.Appearance.Options.UseFont = True
        Me.rbGeoLocationHomeIDSuperseded.Properties.Caption = resources.GetString("rbGeoLocationHomeIDSuperseded.Properties.Caption")
        Me.rbGeoLocationHomeIDSuperseded.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblGeoLocationHomeIDSuperseded
        '
        resources.ApplyResources(Me.lblGeoLocationHomeIDSuperseded, "lblGeoLocationHomeIDSuperseded")
        Me.lblGeoLocationHomeIDSuperseded.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblGeoLocationHomeIDSuperseded.Appearance.Options.UseFont = True
        Me.lblGeoLocationHomeIDSuperseded.Name = "lblGeoLocationHomeIDSuperseded"
        '
        'pnPhoneNumberSuperseded
        '
        Me.pnPhoneNumberSuperseded.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnPhoneNumberSuperseded.Controls.Add(Me.rbPhoneNumberSuperseded)
        Me.pnPhoneNumberSuperseded.Controls.Add(Me.lblPhoneNumberSuperseded)
        resources.ApplyResources(Me.pnPhoneNumberSuperseded, "pnPhoneNumberSuperseded")
        Me.pnPhoneNumberSuperseded.Name = "pnPhoneNumberSuperseded"
        Me.pnPhoneNumberSuperseded.TabStop = True
        '
        'rbPhoneNumberSuperseded
        '
        resources.ApplyResources(Me.rbPhoneNumberSuperseded, "rbPhoneNumberSuperseded")
        Me.rbPhoneNumberSuperseded.Name = "rbPhoneNumberSuperseded"
        Me.rbPhoneNumberSuperseded.Properties.Caption = resources.GetString("rbPhoneNumberSuperseded.Properties.Caption")
        Me.rbPhoneNumberSuperseded.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblPhoneNumberSuperseded
        '
        resources.ApplyResources(Me.lblPhoneNumberSuperseded, "lblPhoneNumberSuperseded")
        Me.lblPhoneNumberSuperseded.Name = "lblPhoneNumberSuperseded"
        '
        'pnNationalitySuperseded
        '
        Me.pnNationalitySuperseded.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnNationalitySuperseded.Controls.Add(Me.rbNationalitySuperseded)
        Me.pnNationalitySuperseded.Controls.Add(Me.lblNationalitySuperseded)
        resources.ApplyResources(Me.pnNationalitySuperseded, "pnNationalitySuperseded")
        Me.pnNationalitySuperseded.Name = "pnNationalitySuperseded"
        Me.pnNationalitySuperseded.TabStop = True
        '
        'rbNationalitySuperseded
        '
        resources.ApplyResources(Me.rbNationalitySuperseded, "rbNationalitySuperseded")
        Me.rbNationalitySuperseded.Name = "rbNationalitySuperseded"
        Me.rbNationalitySuperseded.Properties.Caption = resources.GetString("rbNationalitySuperseded.Properties.Caption")
        Me.rbNationalitySuperseded.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblNationalitySuperseded
        '
        resources.ApplyResources(Me.lblNationalitySuperseded, "lblNationalitySuperseded")
        Me.lblNationalitySuperseded.Name = "lblNationalitySuperseded"
        '
        'pnEmployerNameSuperseded
        '
        Me.pnEmployerNameSuperseded.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnEmployerNameSuperseded.Controls.Add(Me.lblEmployerNameSuperseded)
        Me.pnEmployerNameSuperseded.Controls.Add(Me.rbEmployerNameSuperseded)
        resources.ApplyResources(Me.pnEmployerNameSuperseded, "pnEmployerNameSuperseded")
        Me.pnEmployerNameSuperseded.Name = "pnEmployerNameSuperseded"
        Me.pnEmployerNameSuperseded.TabStop = True
        '
        'lblEmployerNameSuperseded
        '
        Me.lblEmployerNameSuperseded.Appearance.Options.UseTextOptions = True
        Me.lblEmployerNameSuperseded.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        resources.ApplyResources(Me.lblEmployerNameSuperseded, "lblEmployerNameSuperseded")
        Me.lblEmployerNameSuperseded.Name = "lblEmployerNameSuperseded"
        '
        'rbEmployerNameSuperseded
        '
        resources.ApplyResources(Me.rbEmployerNameSuperseded, "rbEmployerNameSuperseded")
        Me.rbEmployerNameSuperseded.Name = "rbEmployerNameSuperseded"
        Me.rbEmployerNameSuperseded.Properties.Caption = resources.GetString("rbEmployerNameSuperseded.Properties.Caption")
        Me.rbEmployerNameSuperseded.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'pnGeoLocationEmployerSuperseded
        '
        Me.pnGeoLocationEmployerSuperseded.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnGeoLocationEmployerSuperseded.Controls.Add(Me.lblGeoLocationEmployerSuperseded)
        Me.pnGeoLocationEmployerSuperseded.Controls.Add(Me.rbGeoLocationEmployerSuperseded)
        resources.ApplyResources(Me.pnGeoLocationEmployerSuperseded, "pnGeoLocationEmployerSuperseded")
        Me.pnGeoLocationEmployerSuperseded.Name = "pnGeoLocationEmployerSuperseded"
        Me.pnGeoLocationEmployerSuperseded.TabStop = True
        '
        'lblGeoLocationEmployerSuperseded
        '
        Me.lblGeoLocationEmployerSuperseded.Appearance.Options.UseTextOptions = True
        Me.lblGeoLocationEmployerSuperseded.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        resources.ApplyResources(Me.lblGeoLocationEmployerSuperseded, "lblGeoLocationEmployerSuperseded")
        Me.lblGeoLocationEmployerSuperseded.Name = "lblGeoLocationEmployerSuperseded"
        '
        'rbGeoLocationEmployerSuperseded
        '
        resources.ApplyResources(Me.rbGeoLocationEmployerSuperseded, "rbGeoLocationEmployerSuperseded")
        Me.rbGeoLocationEmployerSuperseded.Name = "rbGeoLocationEmployerSuperseded"
        Me.rbGeoLocationEmployerSuperseded.Properties.Caption = resources.GetString("rbGeoLocationEmployerSuperseded.Properties.Caption")
        Me.rbGeoLocationEmployerSuperseded.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'tbCaseIDSuperseded
        '
        resources.ApplyResources(Me.tbCaseIDSuperseded, "tbCaseIDSuperseded")
        Me.tbCaseIDSuperseded.Name = "tbCaseIDSuperseded"
        '
        'pnCaseIDSuperseded
        '
        Me.pnCaseIDSuperseded.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnCaseIDSuperseded.Controls.Add(Me.rbCaseIDSuperseded)
        Me.pnCaseIDSuperseded.Controls.Add(Me.lblCaseIDSuperseded)
        resources.ApplyResources(Me.pnCaseIDSuperseded, "pnCaseIDSuperseded")
        Me.pnCaseIDSuperseded.Name = "pnCaseIDSuperseded"
        Me.pnCaseIDSuperseded.TabStop = True
        '
        'rbCaseIDSuperseded
        '
        resources.ApplyResources(Me.rbCaseIDSuperseded, "rbCaseIDSuperseded")
        Me.rbCaseIDSuperseded.Name = "rbCaseIDSuperseded"
        Me.rbCaseIDSuperseded.Properties.Caption = resources.GetString("rbCaseIDSuperseded.Properties.Caption")
        Me.rbCaseIDSuperseded.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblCaseIDSuperseded
        '
        resources.ApplyResources(Me.lblCaseIDSuperseded, "lblCaseIDSuperseded")
        Me.lblCaseIDSuperseded.Name = "lblCaseIDSuperseded"
        '
        'tpSamplesSuperseded
        '
        Me.tpSamplesSuperseded.Controls.Add(Me.gcSamplesSuperseded)
        Me.tpSamplesSuperseded.Name = "tpSamplesSuperseded"
        resources.ApplyResources(Me.tpSamplesSuperseded, "tpSamplesSuperseded")
        '
        'gcSamplesSuperseded
        '
        resources.ApplyResources(Me.gcSamplesSuperseded, "gcSamplesSuperseded")
        Me.gcSamplesSuperseded.MainView = Me.gvSamplesSuperseded
        Me.gcSamplesSuperseded.Name = "gcSamplesSuperseded"
        Me.gcSamplesSuperseded.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.chAddToCaseSuperseded})
        Me.gcSamplesSuperseded.Tag = "{alwayseditable}"
        Me.gcSamplesSuperseded.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvSamplesSuperseded})
        '
        'gvSamplesSuperseded
        '
        Me.gvSamplesSuperseded.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gcolMaterialIDSuperseded, Me.gcolRowTypeSuperseded, Me.gcolCheckedSuperseded, Me.gcolSampleIDSuperseded, Me.gcolSampleTypeSuperseded, Me.gcolCollectionDateSuperseded, Me.gcolTestQuantitySuperseded, Me.gcolCanUncheckSuperseded})
        Me.gvSamplesSuperseded.GridControl = Me.gcSamplesSuperseded
        Me.gvSamplesSuperseded.Name = "gvSamplesSuperseded"
        Me.gvSamplesSuperseded.OptionsCustomization.AllowFilter = False
        Me.gvSamplesSuperseded.OptionsLayout.Columns.AddNewColumns = False
        Me.gvSamplesSuperseded.OptionsLayout.Columns.RemoveOldColumns = False
        Me.gvSamplesSuperseded.OptionsView.ShowGroupPanel = False
        Me.gvSamplesSuperseded.OptionsView.ShowIndicator = False
        '
        'gcolMaterialIDSuperseded
        '
        resources.ApplyResources(Me.gcolMaterialIDSuperseded, "gcolMaterialIDSuperseded")
        Me.gcolMaterialIDSuperseded.FieldName = "idfMaterial"
        Me.gcolMaterialIDSuperseded.Name = "gcolMaterialIDSuperseded"
        '
        'gcolRowTypeSuperseded
        '
        resources.ApplyResources(Me.gcolRowTypeSuperseded, "gcolRowTypeSuperseded")
        Me.gcolRowTypeSuperseded.FieldName = "rowType"
        Me.gcolRowTypeSuperseded.Name = "gcolRowTypeSuperseded"
        '
        'gcolCheckedSuperseded
        '
        resources.ApplyResources(Me.gcolCheckedSuperseded, "gcolCheckedSuperseded")
        Me.gcolCheckedSuperseded.ColumnEdit = Me.chAddToCaseSuperseded
        Me.gcolCheckedSuperseded.FieldName = "AddToSurvivorCase"
        Me.gcolCheckedSuperseded.Name = "gcolCheckedSuperseded"
        Me.gcolCheckedSuperseded.OptionsColumn.ShowCaption = False
        '
        'chAddToCaseSuperseded
        '
        resources.ApplyResources(Me.chAddToCaseSuperseded, "chAddToCaseSuperseded")
        Me.chAddToCaseSuperseded.Name = "chAddToCaseSuperseded"
        '
        'gcolSampleIDSuperseded
        '
        resources.ApplyResources(Me.gcolSampleIDSuperseded, "gcolSampleIDSuperseded")
        Me.gcolSampleIDSuperseded.FieldName = "strFieldBarcode"
        Me.gcolSampleIDSuperseded.Name = "gcolSampleIDSuperseded"
        Me.gcolSampleIDSuperseded.OptionsColumn.AllowEdit = False
        '
        'gcolSampleTypeSuperseded
        '
        resources.ApplyResources(Me.gcolSampleTypeSuperseded, "gcolSampleTypeSuperseded")
        Me.gcolSampleTypeSuperseded.FieldName = "SampleType_Name"
        Me.gcolSampleTypeSuperseded.Name = "gcolSampleTypeSuperseded"
        Me.gcolSampleTypeSuperseded.OptionsColumn.AllowEdit = False
        '
        'gcolCollectionDateSuperseded
        '
        resources.ApplyResources(Me.gcolCollectionDateSuperseded, "gcolCollectionDateSuperseded")
        Me.gcolCollectionDateSuperseded.FieldName = "datFieldCollectionDate"
        Me.gcolCollectionDateSuperseded.Name = "gcolCollectionDateSuperseded"
        Me.gcolCollectionDateSuperseded.OptionsColumn.AllowEdit = False
        '
        'gcolTestQuantitySuperseded
        '
        resources.ApplyResources(Me.gcolTestQuantitySuperseded, "gcolTestQuantitySuperseded")
        Me.gcolTestQuantitySuperseded.FieldName = "TestQuantity"
        Me.gcolTestQuantitySuperseded.Name = "gcolTestQuantitySuperseded"
        Me.gcolTestQuantitySuperseded.OptionsColumn.AllowEdit = False
        '
        'gcolCanUncheckSuperseded
        '
        Me.gcolCanUncheckSuperseded.FieldName = "CanRemoveFromSurvivorCase"
        Me.gcolCanUncheckSuperseded.Name = "gcolCanUncheckSuperseded"
        '
        'tcSurvivor
        '
        resources.ApplyResources(Me.tcSurvivor, "tcSurvivor")
        Me.tcSurvivor.Name = "tcSurvivor"
        Me.tcSurvivor.SelectedTabPage = Me.tpNotificationSurvivor
        Me.tcSurvivor.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tpNotificationSurvivor, Me.tpSamplesSurvivor})
        '
        'tpNotificationSurvivor
        '
        Me.tpNotificationSurvivor.Appearance.PageClient.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tpNotificationSurvivor.Appearance.PageClient.Options.UseBackColor = True
        resources.ApplyResources(Me.tpNotificationSurvivor, "tpNotificationSurvivor")
        Me.tpNotificationSurvivor.Controls.Add(Me.tbLocalIDSurvivor)
        Me.tpNotificationSurvivor.Controls.Add(Me.pnLocalIDSurvivor)
        Me.tpNotificationSurvivor.Controls.Add(Me.pnClinicalSurvivor)
        Me.tpNotificationSurvivor.Controls.Add(Me.tbDiagnosisDateSurvivor)
        Me.tpNotificationSurvivor.Controls.Add(Me.pnDiagnosisDateSurvivor)
        Me.tpNotificationSurvivor.Controls.Add(Me.tbDiagnosisSurvivor)
        Me.tpNotificationSurvivor.Controls.Add(Me.pnDiagnosisSurvivor)
        Me.tpNotificationSurvivor.Controls.Add(Me.pnDemographicSurvivor)
        Me.tpNotificationSurvivor.Controls.Add(Me.tbCaseIDSurvivor)
        Me.tpNotificationSurvivor.Controls.Add(Me.pnCaseIDSurvivor)
        Me.tpNotificationSurvivor.Name = "tpNotificationSurvivor"
        '
        'tbLocalIDSurvivor
        '
        resources.ApplyResources(Me.tbLocalIDSurvivor, "tbLocalIDSurvivor")
        Me.tbLocalIDSurvivor.Name = "tbLocalIDSurvivor"
        '
        'pnLocalIDSurvivor
        '
        Me.pnLocalIDSurvivor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnLocalIDSurvivor.Controls.Add(Me.rbLocalIDSurvivor)
        Me.pnLocalIDSurvivor.Controls.Add(Me.lblLocalIDSurvivor)
        resources.ApplyResources(Me.pnLocalIDSurvivor, "pnLocalIDSurvivor")
        Me.pnLocalIDSurvivor.Name = "pnLocalIDSurvivor"
        Me.pnLocalIDSurvivor.TabStop = True
        '
        'rbLocalIDSurvivor
        '
        resources.ApplyResources(Me.rbLocalIDSurvivor, "rbLocalIDSurvivor")
        Me.rbLocalIDSurvivor.Name = "rbLocalIDSurvivor"
        Me.rbLocalIDSurvivor.Properties.Caption = resources.GetString("rbLocalIDSurvivor.Properties.Caption")
        Me.rbLocalIDSurvivor.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblLocalIDSurvivor
        '
        resources.ApplyResources(Me.lblLocalIDSurvivor, "lblLocalIDSurvivor")
        Me.lblLocalIDSurvivor.Name = "lblLocalIDSurvivor"
        '
        'pnClinicalSurvivor
        '
        Me.pnClinicalSurvivor.Controls.Add(Me.LabelControl8)
        Me.pnClinicalSurvivor.Controls.Add(Me.LabelControl7)
        Me.pnClinicalSurvivor.Controls.Add(Me.tbAddCaseInfoSurvivor)
        Me.pnClinicalSurvivor.Controls.Add(Me.pnAddCaseInfoSurvivor)
        Me.pnClinicalSurvivor.Controls.Add(Me.tbPatientLocationNameSurvivor)
        Me.pnClinicalSurvivor.Controls.Add(Me.pnPatientLocationNameSurvivor)
        Me.pnClinicalSurvivor.Controls.Add(Me.tbPatientLocationStatusSurvivor)
        Me.pnClinicalSurvivor.Controls.Add(Me.pnPatientLocationStatusSurvivor)
        Me.pnClinicalSurvivor.Controls.Add(Me.lblPatientLocationSurvivor)
        Me.pnClinicalSurvivor.Controls.Add(Me.tbChangedDiagnosisDateSurvivor)
        Me.pnClinicalSurvivor.Controls.Add(Me.pnChangedDiagnosisDateSurvivor)
        Me.pnClinicalSurvivor.Controls.Add(Me.tbChangedDiagnosisSurvivor)
        Me.pnClinicalSurvivor.Controls.Add(Me.pnChangedDiagnosisSurvivor)
        Me.pnClinicalSurvivor.Controls.Add(Me.tbFinalStateSurvivor)
        Me.pnClinicalSurvivor.Controls.Add(Me.pnFinalStateSurvivor)
        Me.pnClinicalSurvivor.Controls.Add(Me.tbOnsetDateSurvivor)
        Me.pnClinicalSurvivor.Controls.Add(Me.pnOnsetDateSurvivor)
        resources.ApplyResources(Me.pnClinicalSurvivor, "pnClinicalSurvivor")
        Me.pnClinicalSurvivor.Name = "pnClinicalSurvivor"
        Me.pnClinicalSurvivor.TabStop = True
        '
        'LabelControl8
        '
        Me.LabelControl8.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        resources.ApplyResources(Me.LabelControl8, "LabelControl8")
        Me.LabelControl8.Name = "LabelControl8"
        '
        'LabelControl7
        '
        resources.ApplyResources(Me.LabelControl7, "LabelControl7")
        Me.LabelControl7.Name = "LabelControl7"
        '
        'tbAddCaseInfoSurvivor
        '
        resources.ApplyResources(Me.tbAddCaseInfoSurvivor, "tbAddCaseInfoSurvivor")
        Me.tbAddCaseInfoSurvivor.Name = "tbAddCaseInfoSurvivor"
        Me.tbAddCaseInfoSurvivor.Properties.AutoHeight = CType(resources.GetObject("tbAddCaseInfoSurvivor.Properties.AutoHeight"), Boolean)
        '
        'pnAddCaseInfoSurvivor
        '
        Me.pnAddCaseInfoSurvivor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnAddCaseInfoSurvivor.Controls.Add(Me.rbAddCaseInfoSurvivor)
        Me.pnAddCaseInfoSurvivor.Controls.Add(Me.lblAddCaseInfoSurvivor)
        resources.ApplyResources(Me.pnAddCaseInfoSurvivor, "pnAddCaseInfoSurvivor")
        Me.pnAddCaseInfoSurvivor.Name = "pnAddCaseInfoSurvivor"
        Me.pnAddCaseInfoSurvivor.TabStop = True
        '
        'rbAddCaseInfoSurvivor
        '
        resources.ApplyResources(Me.rbAddCaseInfoSurvivor, "rbAddCaseInfoSurvivor")
        Me.rbAddCaseInfoSurvivor.Name = "rbAddCaseInfoSurvivor"
        Me.rbAddCaseInfoSurvivor.Properties.Caption = resources.GetString("rbAddCaseInfoSurvivor.Properties.Caption")
        Me.rbAddCaseInfoSurvivor.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblAddCaseInfoSurvivor
        '
        resources.ApplyResources(Me.lblAddCaseInfoSurvivor, "lblAddCaseInfoSurvivor")
        Me.lblAddCaseInfoSurvivor.Name = "lblAddCaseInfoSurvivor"
        '
        'tbPatientLocationNameSurvivor
        '
        resources.ApplyResources(Me.tbPatientLocationNameSurvivor, "tbPatientLocationNameSurvivor")
        Me.tbPatientLocationNameSurvivor.Name = "tbPatientLocationNameSurvivor"
        '
        'pnPatientLocationNameSurvivor
        '
        Me.pnPatientLocationNameSurvivor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnPatientLocationNameSurvivor.Controls.Add(Me.lblPatientLocationNameSurvivor)
        Me.pnPatientLocationNameSurvivor.Controls.Add(Me.rbPatientLocationNameSurvivor)
        resources.ApplyResources(Me.pnPatientLocationNameSurvivor, "pnPatientLocationNameSurvivor")
        Me.pnPatientLocationNameSurvivor.Name = "pnPatientLocationNameSurvivor"
        Me.pnPatientLocationNameSurvivor.TabStop = True
        '
        'rbPatientLocationNameSurvivor
        '
        resources.ApplyResources(Me.rbPatientLocationNameSurvivor, "rbPatientLocationNameSurvivor")
        Me.rbPatientLocationNameSurvivor.Name = "rbPatientLocationNameSurvivor"
        Me.rbPatientLocationNameSurvivor.Properties.Caption = resources.GetString("rbPatientLocationNameSurvivor.Properties.Caption")
        Me.rbPatientLocationNameSurvivor.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblPatientLocationNameSurvivor
        '
        Me.lblPatientLocationNameSurvivor.Appearance.Options.UseTextOptions = True
        Me.lblPatientLocationNameSurvivor.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        resources.ApplyResources(Me.lblPatientLocationNameSurvivor, "lblPatientLocationNameSurvivor")
        Me.lblPatientLocationNameSurvivor.Name = "lblPatientLocationNameSurvivor"
        '
        'tbPatientLocationStatusSurvivor
        '
        resources.ApplyResources(Me.tbPatientLocationStatusSurvivor, "tbPatientLocationStatusSurvivor")
        Me.tbPatientLocationStatusSurvivor.Name = "tbPatientLocationStatusSurvivor"
        '
        'pnPatientLocationStatusSurvivor
        '
        Me.pnPatientLocationStatusSurvivor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnPatientLocationStatusSurvivor.Controls.Add(Me.rbPatientLocationStatusSurvivor)
        Me.pnPatientLocationStatusSurvivor.Controls.Add(Me.lblPatientLocationStatusSurvivor)
        resources.ApplyResources(Me.pnPatientLocationStatusSurvivor, "pnPatientLocationStatusSurvivor")
        Me.pnPatientLocationStatusSurvivor.Name = "pnPatientLocationStatusSurvivor"
        Me.pnPatientLocationStatusSurvivor.TabStop = True
        '
        'rbPatientLocationStatusSurvivor
        '
        resources.ApplyResources(Me.rbPatientLocationStatusSurvivor, "rbPatientLocationStatusSurvivor")
        Me.rbPatientLocationStatusSurvivor.Name = "rbPatientLocationStatusSurvivor"
        Me.rbPatientLocationStatusSurvivor.Properties.Caption = resources.GetString("rbPatientLocationStatusSurvivor.Properties.Caption")
        Me.rbPatientLocationStatusSurvivor.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblPatientLocationStatusSurvivor
        '
        resources.ApplyResources(Me.lblPatientLocationStatusSurvivor, "lblPatientLocationStatusSurvivor")
        Me.lblPatientLocationStatusSurvivor.Name = "lblPatientLocationStatusSurvivor"
        '
        'lblPatientLocationSurvivor
        '
        Me.lblPatientLocationSurvivor.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblPatientLocationSurvivor.Appearance.Options.UseFont = True
        Me.lblPatientLocationSurvivor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        resources.ApplyResources(Me.lblPatientLocationSurvivor, "lblPatientLocationSurvivor")
        Me.lblPatientLocationSurvivor.Name = "lblPatientLocationSurvivor"
        '
        'tbChangedDiagnosisDateSurvivor
        '
        resources.ApplyResources(Me.tbChangedDiagnosisDateSurvivor, "tbChangedDiagnosisDateSurvivor")
        Me.tbChangedDiagnosisDateSurvivor.Name = "tbChangedDiagnosisDateSurvivor"
        '
        'pnChangedDiagnosisDateSurvivor
        '
        Me.pnChangedDiagnosisDateSurvivor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnChangedDiagnosisDateSurvivor.Controls.Add(Me.rbChangedDiagnosisDateSurvivor)
        Me.pnChangedDiagnosisDateSurvivor.Controls.Add(Me.lblChangedDiagnosisDateSurvivor)
        resources.ApplyResources(Me.pnChangedDiagnosisDateSurvivor, "pnChangedDiagnosisDateSurvivor")
        Me.pnChangedDiagnosisDateSurvivor.Name = "pnChangedDiagnosisDateSurvivor"
        Me.pnChangedDiagnosisDateSurvivor.TabStop = True
        '
        'rbChangedDiagnosisDateSurvivor
        '
        resources.ApplyResources(Me.rbChangedDiagnosisDateSurvivor, "rbChangedDiagnosisDateSurvivor")
        Me.rbChangedDiagnosisDateSurvivor.Name = "rbChangedDiagnosisDateSurvivor"
        Me.rbChangedDiagnosisDateSurvivor.Properties.Caption = resources.GetString("rbChangedDiagnosisDateSurvivor.Properties.Caption")
        Me.rbChangedDiagnosisDateSurvivor.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblChangedDiagnosisDateSurvivor
        '
        resources.ApplyResources(Me.lblChangedDiagnosisDateSurvivor, "lblChangedDiagnosisDateSurvivor")
        Me.lblChangedDiagnosisDateSurvivor.Name = "lblChangedDiagnosisDateSurvivor"
        '
        'tbChangedDiagnosisSurvivor
        '
        resources.ApplyResources(Me.tbChangedDiagnosisSurvivor, "tbChangedDiagnosisSurvivor")
        Me.tbChangedDiagnosisSurvivor.Name = "tbChangedDiagnosisSurvivor"
        '
        'pnChangedDiagnosisSurvivor
        '
        Me.pnChangedDiagnosisSurvivor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnChangedDiagnosisSurvivor.Controls.Add(Me.rbChangedDiagnosisSurvivor)
        Me.pnChangedDiagnosisSurvivor.Controls.Add(Me.lblChangedDiagnosisSurvivor)
        resources.ApplyResources(Me.pnChangedDiagnosisSurvivor, "pnChangedDiagnosisSurvivor")
        Me.pnChangedDiagnosisSurvivor.Name = "pnChangedDiagnosisSurvivor"
        Me.pnChangedDiagnosisSurvivor.TabStop = True
        '
        'rbChangedDiagnosisSurvivor
        '
        resources.ApplyResources(Me.rbChangedDiagnosisSurvivor, "rbChangedDiagnosisSurvivor")
        Me.rbChangedDiagnosisSurvivor.Name = "rbChangedDiagnosisSurvivor"
        Me.rbChangedDiagnosisSurvivor.Properties.Caption = resources.GetString("rbChangedDiagnosisSurvivor.Properties.Caption")
        Me.rbChangedDiagnosisSurvivor.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblChangedDiagnosisSurvivor
        '
        resources.ApplyResources(Me.lblChangedDiagnosisSurvivor, "lblChangedDiagnosisSurvivor")
        Me.lblChangedDiagnosisSurvivor.Name = "lblChangedDiagnosisSurvivor"
        '
        'tbFinalStateSurvivor
        '
        resources.ApplyResources(Me.tbFinalStateSurvivor, "tbFinalStateSurvivor")
        Me.tbFinalStateSurvivor.Name = "tbFinalStateSurvivor"
        '
        'pnFinalStateSurvivor
        '
        Me.pnFinalStateSurvivor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnFinalStateSurvivor.Controls.Add(Me.rbFinalStateSurvivor)
        Me.pnFinalStateSurvivor.Controls.Add(Me.lblFinalStateSurvivor)
        resources.ApplyResources(Me.pnFinalStateSurvivor, "pnFinalStateSurvivor")
        Me.pnFinalStateSurvivor.Name = "pnFinalStateSurvivor"
        Me.pnFinalStateSurvivor.TabStop = True
        '
        'rbFinalStateSurvivor
        '
        resources.ApplyResources(Me.rbFinalStateSurvivor, "rbFinalStateSurvivor")
        Me.rbFinalStateSurvivor.Name = "rbFinalStateSurvivor"
        Me.rbFinalStateSurvivor.Properties.Caption = resources.GetString("rbFinalStateSurvivor.Properties.Caption")
        Me.rbFinalStateSurvivor.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblFinalStateSurvivor
        '
        resources.ApplyResources(Me.lblFinalStateSurvivor, "lblFinalStateSurvivor")
        Me.lblFinalStateSurvivor.Name = "lblFinalStateSurvivor"
        '
        'tbOnsetDateSurvivor
        '
        resources.ApplyResources(Me.tbOnsetDateSurvivor, "tbOnsetDateSurvivor")
        Me.tbOnsetDateSurvivor.Name = "tbOnsetDateSurvivor"
        '
        'pnOnsetDateSurvivor
        '
        Me.pnOnsetDateSurvivor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnOnsetDateSurvivor.Controls.Add(Me.rbOnsetDateSurvivor)
        Me.pnOnsetDateSurvivor.Controls.Add(Me.lblOnsetDateSurvivor)
        resources.ApplyResources(Me.pnOnsetDateSurvivor, "pnOnsetDateSurvivor")
        Me.pnOnsetDateSurvivor.Name = "pnOnsetDateSurvivor"
        Me.pnOnsetDateSurvivor.TabStop = True
        '
        'rbOnsetDateSurvivor
        '
        resources.ApplyResources(Me.rbOnsetDateSurvivor, "rbOnsetDateSurvivor")
        Me.rbOnsetDateSurvivor.Name = "rbOnsetDateSurvivor"
        Me.rbOnsetDateSurvivor.Properties.Caption = resources.GetString("rbOnsetDateSurvivor.Properties.Caption")
        Me.rbOnsetDateSurvivor.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblOnsetDateSurvivor
        '
        resources.ApplyResources(Me.lblOnsetDateSurvivor, "lblOnsetDateSurvivor")
        Me.lblOnsetDateSurvivor.Name = "lblOnsetDateSurvivor"
        '
        'tbDiagnosisDateSurvivor
        '
        resources.ApplyResources(Me.tbDiagnosisDateSurvivor, "tbDiagnosisDateSurvivor")
        Me.tbDiagnosisDateSurvivor.Name = "tbDiagnosisDateSurvivor"
        '
        'pnDiagnosisDateSurvivor
        '
        Me.pnDiagnosisDateSurvivor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnDiagnosisDateSurvivor.Controls.Add(Me.rbDiagnosisDateSurvivor)
        Me.pnDiagnosisDateSurvivor.Controls.Add(Me.lblDiagnosisDateSurvivor)
        resources.ApplyResources(Me.pnDiagnosisDateSurvivor, "pnDiagnosisDateSurvivor")
        Me.pnDiagnosisDateSurvivor.Name = "pnDiagnosisDateSurvivor"
        Me.pnDiagnosisDateSurvivor.TabStop = True
        '
        'rbDiagnosisDateSurvivor
        '
        resources.ApplyResources(Me.rbDiagnosisDateSurvivor, "rbDiagnosisDateSurvivor")
        Me.rbDiagnosisDateSurvivor.Name = "rbDiagnosisDateSurvivor"
        Me.rbDiagnosisDateSurvivor.Properties.Caption = resources.GetString("rbDiagnosisDateSurvivor.Properties.Caption")
        Me.rbDiagnosisDateSurvivor.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblDiagnosisDateSurvivor
        '
        resources.ApplyResources(Me.lblDiagnosisDateSurvivor, "lblDiagnosisDateSurvivor")
        Me.lblDiagnosisDateSurvivor.Name = "lblDiagnosisDateSurvivor"
        '
        'tbDiagnosisSurvivor
        '
        resources.ApplyResources(Me.tbDiagnosisSurvivor, "tbDiagnosisSurvivor")
        Me.tbDiagnosisSurvivor.Name = "tbDiagnosisSurvivor"
        '
        'pnDiagnosisSurvivor
        '
        Me.pnDiagnosisSurvivor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnDiagnosisSurvivor.Controls.Add(Me.rbDiagnosisSurvivor)
        Me.pnDiagnosisSurvivor.Controls.Add(Me.lblDiagnosisSurvivor)
        resources.ApplyResources(Me.pnDiagnosisSurvivor, "pnDiagnosisSurvivor")
        Me.pnDiagnosisSurvivor.Name = "pnDiagnosisSurvivor"
        Me.pnDiagnosisSurvivor.TabStop = True
        '
        'rbDiagnosisSurvivor
        '
        resources.ApplyResources(Me.rbDiagnosisSurvivor, "rbDiagnosisSurvivor")
        Me.rbDiagnosisSurvivor.Name = "rbDiagnosisSurvivor"
        Me.rbDiagnosisSurvivor.Properties.Caption = resources.GetString("rbDiagnosisSurvivor.Properties.Caption")
        Me.rbDiagnosisSurvivor.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblDiagnosisSurvivor
        '
        resources.ApplyResources(Me.lblDiagnosisSurvivor, "lblDiagnosisSurvivor")
        Me.lblDiagnosisSurvivor.Name = "lblDiagnosisSurvivor"
        '
        'pnDemographicSurvivor
        '
        Me.pnDemographicSurvivor.Controls.Add(Me.LabelControl3)
        Me.pnDemographicSurvivor.Controls.Add(Me.LabelControl2)
        Me.pnDemographicSurvivor.Controls.Add(Me.tbGeoLocationEmployerSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.tbEmployerNameSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.tbPhoneNumberSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.tbNationalitySurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.tbAptmHomeSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.tbBuildingHomeSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.lblHBAHomeSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.tbHouseHomeSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.lblPostalCodeHomeSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.tbPostalCodeHomeSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.lblStreetHomeSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.tbStreetHomeSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.lblSettlementHomeSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.tbSettlementHomeSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.lblRayonHomeSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.tbRayonHomeSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.lblRegionHomeSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.tbRegionHomeSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.gbPatientInfoSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.tbAgeUnitsSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.tbSexSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.tbDOBSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.tbAgeSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.lblPatientNameSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.tbSecondNameSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.tbLastNameSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.tbFirstNameSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.pnLastNameSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.pnFirstNameSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.pnSecondNameSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.pnDOBSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.pnAgeSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.pnSexSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.pnPhoneNumberSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.pnNationalitySurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.pnEmployerNameSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.pnGeoLocationEmployerSurvivor)
        Me.pnDemographicSurvivor.Controls.Add(Me.pnGeoLocationHomeIDSurvivor)
        resources.ApplyResources(Me.pnDemographicSurvivor, "pnDemographicSurvivor")
        Me.pnDemographicSurvivor.Name = "pnDemographicSurvivor"
        Me.pnDemographicSurvivor.TabStop = True
        '
        'LabelControl3
        '
        resources.ApplyResources(Me.LabelControl3, "LabelControl3")
        Me.LabelControl3.Name = "LabelControl3"
        '
        'LabelControl2
        '
        resources.ApplyResources(Me.LabelControl2, "LabelControl2")
        Me.LabelControl2.Name = "LabelControl2"
        '
        'tbGeoLocationEmployerSurvivor
        '
        resources.ApplyResources(Me.tbGeoLocationEmployerSurvivor, "tbGeoLocationEmployerSurvivor")
        Me.tbGeoLocationEmployerSurvivor.Name = "tbGeoLocationEmployerSurvivor"
        '
        'tbEmployerNameSurvivor
        '
        resources.ApplyResources(Me.tbEmployerNameSurvivor, "tbEmployerNameSurvivor")
        Me.tbEmployerNameSurvivor.Name = "tbEmployerNameSurvivor"
        '
        'tbPhoneNumberSurvivor
        '
        resources.ApplyResources(Me.tbPhoneNumberSurvivor, "tbPhoneNumberSurvivor")
        Me.tbPhoneNumberSurvivor.Name = "tbPhoneNumberSurvivor"
        '
        'tbNationalitySurvivor
        '
        resources.ApplyResources(Me.tbNationalitySurvivor, "tbNationalitySurvivor")
        Me.tbNationalitySurvivor.Name = "tbNationalitySurvivor"
        '
        'tbAptmHomeSurvivor
        '
        resources.ApplyResources(Me.tbAptmHomeSurvivor, "tbAptmHomeSurvivor")
        Me.tbAptmHomeSurvivor.Name = "tbAptmHomeSurvivor"
        '
        'tbBuildingHomeSurvivor
        '
        resources.ApplyResources(Me.tbBuildingHomeSurvivor, "tbBuildingHomeSurvivor")
        Me.tbBuildingHomeSurvivor.Name = "tbBuildingHomeSurvivor"
        '
        'lblHBAHomeSurvivor
        '
        resources.ApplyResources(Me.lblHBAHomeSurvivor, "lblHBAHomeSurvivor")
        Me.lblHBAHomeSurvivor.Name = "lblHBAHomeSurvivor"
        '
        'tbHouseHomeSurvivor
        '
        resources.ApplyResources(Me.tbHouseHomeSurvivor, "tbHouseHomeSurvivor")
        Me.tbHouseHomeSurvivor.Name = "tbHouseHomeSurvivor"
        '
        'lblPostalCodeHomeSurvivor
        '
        resources.ApplyResources(Me.lblPostalCodeHomeSurvivor, "lblPostalCodeHomeSurvivor")
        Me.lblPostalCodeHomeSurvivor.Name = "lblPostalCodeHomeSurvivor"
        '
        'tbPostalCodeHomeSurvivor
        '
        resources.ApplyResources(Me.tbPostalCodeHomeSurvivor, "tbPostalCodeHomeSurvivor")
        Me.tbPostalCodeHomeSurvivor.Name = "tbPostalCodeHomeSurvivor"
        '
        'lblStreetHomeSurvivor
        '
        resources.ApplyResources(Me.lblStreetHomeSurvivor, "lblStreetHomeSurvivor")
        Me.lblStreetHomeSurvivor.Name = "lblStreetHomeSurvivor"
        '
        'tbStreetHomeSurvivor
        '
        resources.ApplyResources(Me.tbStreetHomeSurvivor, "tbStreetHomeSurvivor")
        Me.tbStreetHomeSurvivor.Name = "tbStreetHomeSurvivor"
        '
        'lblSettlementHomeSurvivor
        '
        resources.ApplyResources(Me.lblSettlementHomeSurvivor, "lblSettlementHomeSurvivor")
        Me.lblSettlementHomeSurvivor.Name = "lblSettlementHomeSurvivor"
        '
        'tbSettlementHomeSurvivor
        '
        resources.ApplyResources(Me.tbSettlementHomeSurvivor, "tbSettlementHomeSurvivor")
        Me.tbSettlementHomeSurvivor.Name = "tbSettlementHomeSurvivor"
        '
        'lblRayonHomeSurvivor
        '
        resources.ApplyResources(Me.lblRayonHomeSurvivor, "lblRayonHomeSurvivor")
        Me.lblRayonHomeSurvivor.Name = "lblRayonHomeSurvivor"
        '
        'tbRayonHomeSurvivor
        '
        resources.ApplyResources(Me.tbRayonHomeSurvivor, "tbRayonHomeSurvivor")
        Me.tbRayonHomeSurvivor.Name = "tbRayonHomeSurvivor"
        '
        'lblRegionHomeSurvivor
        '
        resources.ApplyResources(Me.lblRegionHomeSurvivor, "lblRegionHomeSurvivor")
        Me.lblRegionHomeSurvivor.Name = "lblRegionHomeSurvivor"
        '
        'tbRegionHomeSurvivor
        '
        resources.ApplyResources(Me.tbRegionHomeSurvivor, "tbRegionHomeSurvivor")
        Me.tbRegionHomeSurvivor.Name = "tbRegionHomeSurvivor"
        '
        'gbPatientInfoSurvivor
        '
        resources.ApplyResources(Me.gbPatientInfoSurvivor, "gbPatientInfoSurvivor")
        Me.gbPatientInfoSurvivor.Name = "gbPatientInfoSurvivor"
        '
        'tbAgeUnitsSurvivor
        '
        resources.ApplyResources(Me.tbAgeUnitsSurvivor, "tbAgeUnitsSurvivor")
        Me.tbAgeUnitsSurvivor.Name = "tbAgeUnitsSurvivor"
        Me.tbAgeUnitsSurvivor.Properties.AutoHeight = CType(resources.GetObject("tbAgeUnitsSurvivor.Properties.AutoHeight"), Boolean)
        '
        'tbSexSurvivor
        '
        resources.ApplyResources(Me.tbSexSurvivor, "tbSexSurvivor")
        Me.tbSexSurvivor.Name = "tbSexSurvivor"
        '
        'tbDOBSurvivor
        '
        resources.ApplyResources(Me.tbDOBSurvivor, "tbDOBSurvivor")
        Me.tbDOBSurvivor.Name = "tbDOBSurvivor"
        '
        'tbAgeSurvivor
        '
        resources.ApplyResources(Me.tbAgeSurvivor, "tbAgeSurvivor")
        Me.tbAgeSurvivor.Name = "tbAgeSurvivor"
        Me.tbAgeSurvivor.Properties.AutoHeight = CType(resources.GetObject("tbAgeSurvivor.Properties.AutoHeight"), Boolean)
        '
        'lblPatientNameSurvivor
        '
        Me.lblPatientNameSurvivor.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblPatientNameSurvivor.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPatientNameSurvivor, "lblPatientNameSurvivor")
        Me.lblPatientNameSurvivor.Name = "lblPatientNameSurvivor"
        '
        'tbSecondNameSurvivor
        '
        resources.ApplyResources(Me.tbSecondNameSurvivor, "tbSecondNameSurvivor")
        Me.tbSecondNameSurvivor.Name = "tbSecondNameSurvivor"
        '
        'tbLastNameSurvivor
        '
        resources.ApplyResources(Me.tbLastNameSurvivor, "tbLastNameSurvivor")
        Me.tbLastNameSurvivor.Name = "tbLastNameSurvivor"
        '
        'tbFirstNameSurvivor
        '
        resources.ApplyResources(Me.tbFirstNameSurvivor, "tbFirstNameSurvivor")
        Me.tbFirstNameSurvivor.Name = "tbFirstNameSurvivor"
        '
        'pnLastNameSurvivor
        '
        Me.pnLastNameSurvivor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnLastNameSurvivor.Controls.Add(Me.rbLastNameSurvivor)
        Me.pnLastNameSurvivor.Controls.Add(Me.lblLastNameSurvivor)
        resources.ApplyResources(Me.pnLastNameSurvivor, "pnLastNameSurvivor")
        Me.pnLastNameSurvivor.Name = "pnLastNameSurvivor"
        Me.pnLastNameSurvivor.TabStop = True
        '
        'rbLastNameSurvivor
        '
        resources.ApplyResources(Me.rbLastNameSurvivor, "rbLastNameSurvivor")
        Me.rbLastNameSurvivor.Name = "rbLastNameSurvivor"
        Me.rbLastNameSurvivor.Properties.Caption = resources.GetString("rbLastNameSurvivor.Properties.Caption")
        Me.rbLastNameSurvivor.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblLastNameSurvivor
        '
        resources.ApplyResources(Me.lblLastNameSurvivor, "lblLastNameSurvivor")
        Me.lblLastNameSurvivor.Name = "lblLastNameSurvivor"
        '
        'pnFirstNameSurvivor
        '
        Me.pnFirstNameSurvivor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnFirstNameSurvivor.Controls.Add(Me.rbFirstNameSurvivor)
        Me.pnFirstNameSurvivor.Controls.Add(Me.lblFirstNameSurvivor)
        resources.ApplyResources(Me.pnFirstNameSurvivor, "pnFirstNameSurvivor")
        Me.pnFirstNameSurvivor.Name = "pnFirstNameSurvivor"
        Me.pnFirstNameSurvivor.TabStop = True
        '
        'rbFirstNameSurvivor
        '
        resources.ApplyResources(Me.rbFirstNameSurvivor, "rbFirstNameSurvivor")
        Me.rbFirstNameSurvivor.Name = "rbFirstNameSurvivor"
        Me.rbFirstNameSurvivor.Properties.Caption = resources.GetString("rbFirstNameSurvivor.Properties.Caption")
        Me.rbFirstNameSurvivor.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblFirstNameSurvivor
        '
        resources.ApplyResources(Me.lblFirstNameSurvivor, "lblFirstNameSurvivor")
        Me.lblFirstNameSurvivor.Name = "lblFirstNameSurvivor"
        '
        'pnSecondNameSurvivor
        '
        Me.pnSecondNameSurvivor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnSecondNameSurvivor.Controls.Add(Me.rbSecondNameSurvivor)
        Me.pnSecondNameSurvivor.Controls.Add(Me.lblSecondNameSurvivor)
        resources.ApplyResources(Me.pnSecondNameSurvivor, "pnSecondNameSurvivor")
        Me.pnSecondNameSurvivor.Name = "pnSecondNameSurvivor"
        Me.pnSecondNameSurvivor.TabStop = True
        '
        'rbSecondNameSurvivor
        '
        resources.ApplyResources(Me.rbSecondNameSurvivor, "rbSecondNameSurvivor")
        Me.rbSecondNameSurvivor.Name = "rbSecondNameSurvivor"
        Me.rbSecondNameSurvivor.Properties.Caption = resources.GetString("rbSecondNameSurvivor.Properties.Caption")
        Me.rbSecondNameSurvivor.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblSecondNameSurvivor
        '
        resources.ApplyResources(Me.lblSecondNameSurvivor, "lblSecondNameSurvivor")
        Me.lblSecondNameSurvivor.Name = "lblSecondNameSurvivor"
        '
        'pnDOBSurvivor
        '
        Me.pnDOBSurvivor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnDOBSurvivor.Controls.Add(Me.rbDOBSurvivor)
        Me.pnDOBSurvivor.Controls.Add(Me.lblDOBSurvivor)
        resources.ApplyResources(Me.pnDOBSurvivor, "pnDOBSurvivor")
        Me.pnDOBSurvivor.Name = "pnDOBSurvivor"
        Me.pnDOBSurvivor.TabStop = True
        '
        'rbDOBSurvivor
        '
        resources.ApplyResources(Me.rbDOBSurvivor, "rbDOBSurvivor")
        Me.rbDOBSurvivor.Name = "rbDOBSurvivor"
        Me.rbDOBSurvivor.Properties.Caption = resources.GetString("rbDOBSurvivor.Properties.Caption")
        Me.rbDOBSurvivor.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblDOBSurvivor
        '
        resources.ApplyResources(Me.lblDOBSurvivor, "lblDOBSurvivor")
        Me.lblDOBSurvivor.Name = "lblDOBSurvivor"
        '
        'pnAgeSurvivor
        '
        Me.pnAgeSurvivor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnAgeSurvivor.Controls.Add(Me.rbAgeSurvivor)
        Me.pnAgeSurvivor.Controls.Add(Me.lblAgeSurvivor)
        resources.ApplyResources(Me.pnAgeSurvivor, "pnAgeSurvivor")
        Me.pnAgeSurvivor.Name = "pnAgeSurvivor"
        Me.pnAgeSurvivor.TabStop = True
        '
        'rbAgeSurvivor
        '
        resources.ApplyResources(Me.rbAgeSurvivor, "rbAgeSurvivor")
        Me.rbAgeSurvivor.Name = "rbAgeSurvivor"
        Me.rbAgeSurvivor.Properties.Caption = resources.GetString("rbAgeSurvivor.Properties.Caption")
        Me.rbAgeSurvivor.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblAgeSurvivor
        '
        resources.ApplyResources(Me.lblAgeSurvivor, "lblAgeSurvivor")
        Me.lblAgeSurvivor.Name = "lblAgeSurvivor"
        '
        'pnSexSurvivor
        '
        Me.pnSexSurvivor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnSexSurvivor.Controls.Add(Me.rbSexSurvivor)
        Me.pnSexSurvivor.Controls.Add(Me.lblSexSurvivor)
        resources.ApplyResources(Me.pnSexSurvivor, "pnSexSurvivor")
        Me.pnSexSurvivor.Name = "pnSexSurvivor"
        Me.pnSexSurvivor.TabStop = True
        '
        'rbSexSurvivor
        '
        resources.ApplyResources(Me.rbSexSurvivor, "rbSexSurvivor")
        Me.rbSexSurvivor.Name = "rbSexSurvivor"
        Me.rbSexSurvivor.Properties.Caption = resources.GetString("rbSexSurvivor.Properties.Caption")
        Me.rbSexSurvivor.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblSexSurvivor
        '
        resources.ApplyResources(Me.lblSexSurvivor, "lblSexSurvivor")
        Me.lblSexSurvivor.Name = "lblSexSurvivor"
        '
        'pnPhoneNumberSurvivor
        '
        Me.pnPhoneNumberSurvivor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnPhoneNumberSurvivor.Controls.Add(Me.rbPhoneNumberSurvivor)
        Me.pnPhoneNumberSurvivor.Controls.Add(Me.lblPhoneNumberSurvivor)
        resources.ApplyResources(Me.pnPhoneNumberSurvivor, "pnPhoneNumberSurvivor")
        Me.pnPhoneNumberSurvivor.Name = "pnPhoneNumberSurvivor"
        Me.pnPhoneNumberSurvivor.TabStop = True
        '
        'rbPhoneNumberSurvivor
        '
        resources.ApplyResources(Me.rbPhoneNumberSurvivor, "rbPhoneNumberSurvivor")
        Me.rbPhoneNumberSurvivor.Name = "rbPhoneNumberSurvivor"
        Me.rbPhoneNumberSurvivor.Properties.Caption = resources.GetString("rbPhoneNumberSurvivor.Properties.Caption")
        Me.rbPhoneNumberSurvivor.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblPhoneNumberSurvivor
        '
        resources.ApplyResources(Me.lblPhoneNumberSurvivor, "lblPhoneNumberSurvivor")
        Me.lblPhoneNumberSurvivor.Name = "lblPhoneNumberSurvivor"
        '
        'pnNationalitySurvivor
        '
        Me.pnNationalitySurvivor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnNationalitySurvivor.Controls.Add(Me.rbNationalitySurvivor)
        Me.pnNationalitySurvivor.Controls.Add(Me.lblNationalitySurvivor)
        resources.ApplyResources(Me.pnNationalitySurvivor, "pnNationalitySurvivor")
        Me.pnNationalitySurvivor.Name = "pnNationalitySurvivor"
        Me.pnNationalitySurvivor.TabStop = True
        '
        'rbNationalitySurvivor
        '
        resources.ApplyResources(Me.rbNationalitySurvivor, "rbNationalitySurvivor")
        Me.rbNationalitySurvivor.Name = "rbNationalitySurvivor"
        Me.rbNationalitySurvivor.Properties.Caption = resources.GetString("rbNationalitySurvivor.Properties.Caption")
        Me.rbNationalitySurvivor.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblNationalitySurvivor
        '
        resources.ApplyResources(Me.lblNationalitySurvivor, "lblNationalitySurvivor")
        Me.lblNationalitySurvivor.Name = "lblNationalitySurvivor"
        '
        'pnEmployerNameSurvivor
        '
        Me.pnEmployerNameSurvivor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnEmployerNameSurvivor.Controls.Add(Me.lblEmployerNameSurvivor)
        Me.pnEmployerNameSurvivor.Controls.Add(Me.rbEmployerNameSurvivor)
        resources.ApplyResources(Me.pnEmployerNameSurvivor, "pnEmployerNameSurvivor")
        Me.pnEmployerNameSurvivor.Name = "pnEmployerNameSurvivor"
        Me.pnEmployerNameSurvivor.TabStop = True
        '
        'lblEmployerNameSurvivor
        '
        Me.lblEmployerNameSurvivor.Appearance.Options.UseTextOptions = True
        Me.lblEmployerNameSurvivor.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        resources.ApplyResources(Me.lblEmployerNameSurvivor, "lblEmployerNameSurvivor")
        Me.lblEmployerNameSurvivor.Name = "lblEmployerNameSurvivor"
        '
        'rbEmployerNameSurvivor
        '
        resources.ApplyResources(Me.rbEmployerNameSurvivor, "rbEmployerNameSurvivor")
        Me.rbEmployerNameSurvivor.Name = "rbEmployerNameSurvivor"
        Me.rbEmployerNameSurvivor.Properties.Caption = resources.GetString("rbEmployerNameSurvivor.Properties.Caption")
        Me.rbEmployerNameSurvivor.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'pnGeoLocationEmployerSurvivor
        '
        Me.pnGeoLocationEmployerSurvivor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnGeoLocationEmployerSurvivor.Controls.Add(Me.lblGeoLocationEmployerSurvivor)
        Me.pnGeoLocationEmployerSurvivor.Controls.Add(Me.rbGeoLocationEmployerSurvivor)
        resources.ApplyResources(Me.pnGeoLocationEmployerSurvivor, "pnGeoLocationEmployerSurvivor")
        Me.pnGeoLocationEmployerSurvivor.Name = "pnGeoLocationEmployerSurvivor"
        Me.pnGeoLocationEmployerSurvivor.TabStop = True
        '
        'lblGeoLocationEmployerSurvivor
        '
        Me.lblGeoLocationEmployerSurvivor.Appearance.Options.UseTextOptions = True
        Me.lblGeoLocationEmployerSurvivor.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        resources.ApplyResources(Me.lblGeoLocationEmployerSurvivor, "lblGeoLocationEmployerSurvivor")
        Me.lblGeoLocationEmployerSurvivor.Name = "lblGeoLocationEmployerSurvivor"
        '
        'rbGeoLocationEmployerSurvivor
        '
        resources.ApplyResources(Me.rbGeoLocationEmployerSurvivor, "rbGeoLocationEmployerSurvivor")
        Me.rbGeoLocationEmployerSurvivor.Name = "rbGeoLocationEmployerSurvivor"
        Me.rbGeoLocationEmployerSurvivor.Properties.Caption = resources.GetString("rbGeoLocationEmployerSurvivor.Properties.Caption")
        Me.rbGeoLocationEmployerSurvivor.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'pnGeoLocationHomeIDSurvivor
        '
        resources.ApplyResources(Me.pnGeoLocationHomeIDSurvivor, "pnGeoLocationHomeIDSurvivor")
        Me.pnGeoLocationHomeIDSurvivor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnGeoLocationHomeIDSurvivor.Controls.Add(Me.rbGeoLocationHomeIDSurvivor)
        Me.pnGeoLocationHomeIDSurvivor.Controls.Add(Me.lblGeoLocationHomeIDSurvivor)
        Me.pnGeoLocationHomeIDSurvivor.Name = "pnGeoLocationHomeIDSurvivor"
        Me.pnGeoLocationHomeIDSurvivor.TabStop = True
        '
        'rbGeoLocationHomeIDSurvivor
        '
        resources.ApplyResources(Me.rbGeoLocationHomeIDSurvivor, "rbGeoLocationHomeIDSurvivor")
        Me.rbGeoLocationHomeIDSurvivor.Name = "rbGeoLocationHomeIDSurvivor"
        Me.rbGeoLocationHomeIDSurvivor.Properties.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.rbGeoLocationHomeIDSurvivor.Properties.Appearance.Options.UseFont = True
        Me.rbGeoLocationHomeIDSurvivor.Properties.Caption = resources.GetString("rbGeoLocationHomeIDSurvivor.Properties.Caption")
        Me.rbGeoLocationHomeIDSurvivor.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblGeoLocationHomeIDSurvivor
        '
        resources.ApplyResources(Me.lblGeoLocationHomeIDSurvivor, "lblGeoLocationHomeIDSurvivor")
        Me.lblGeoLocationHomeIDSurvivor.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblGeoLocationHomeIDSurvivor.Appearance.Options.UseFont = True
        Me.lblGeoLocationHomeIDSurvivor.Name = "lblGeoLocationHomeIDSurvivor"
        '
        'tbCaseIDSurvivor
        '
        resources.ApplyResources(Me.tbCaseIDSurvivor, "tbCaseIDSurvivor")
        Me.tbCaseIDSurvivor.Name = "tbCaseIDSurvivor"
        '
        'pnCaseIDSurvivor
        '
        Me.pnCaseIDSurvivor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnCaseIDSurvivor.Controls.Add(Me.rbCaseIDSurvivor)
        Me.pnCaseIDSurvivor.Controls.Add(Me.lblCaseIDSurvivor)
        resources.ApplyResources(Me.pnCaseIDSurvivor, "pnCaseIDSurvivor")
        Me.pnCaseIDSurvivor.Name = "pnCaseIDSurvivor"
        Me.pnCaseIDSurvivor.TabStop = True
        '
        'rbCaseIDSurvivor
        '
        resources.ApplyResources(Me.rbCaseIDSurvivor, "rbCaseIDSurvivor")
        Me.rbCaseIDSurvivor.Name = "rbCaseIDSurvivor"
        Me.rbCaseIDSurvivor.Properties.Caption = resources.GetString("rbCaseIDSurvivor.Properties.Caption")
        Me.rbCaseIDSurvivor.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        '
        'lblCaseIDSurvivor
        '
        resources.ApplyResources(Me.lblCaseIDSurvivor, "lblCaseIDSurvivor")
        Me.lblCaseIDSurvivor.Name = "lblCaseIDSurvivor"
        '
        'tpSamplesSurvivor
        '
        Me.tpSamplesSurvivor.Controls.Add(Me.gcSamplesSurvivor)
        Me.tpSamplesSurvivor.Name = "tpSamplesSurvivor"
        resources.ApplyResources(Me.tpSamplesSurvivor, "tpSamplesSurvivor")
        '
        'gcSamplesSurvivor
        '
        resources.ApplyResources(Me.gcSamplesSurvivor, "gcSamplesSurvivor")
        Me.gcSamplesSurvivor.MainView = Me.gvSamplesSurvivor
        Me.gcSamplesSurvivor.Name = "gcSamplesSurvivor"
        Me.gcSamplesSurvivor.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.chAddToCaseSurvivor})
        Me.gcSamplesSurvivor.Tag = "{alwayseditable}"
        Me.gcSamplesSurvivor.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvSamplesSurvivor})
        '
        'gvSamplesSurvivor
        '
        Me.gvSamplesSurvivor.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gcolMaterialIDSurvivor, Me.gcolRowTypeSurvivor, Me.gcolCheckedSurvivor, Me.gcolSampleIDSurvivor, Me.gcolSampleTypeSurvivor, Me.gcolCollectionDateSurvivor, Me.gcolTestQuantitySurvivor, Me.gcolCanUncheckSurvivor})
        Me.gvSamplesSurvivor.GridControl = Me.gcSamplesSurvivor
        Me.gvSamplesSurvivor.Name = "gvSamplesSurvivor"
        Me.gvSamplesSurvivor.OptionsCustomization.AllowFilter = False
        Me.gvSamplesSurvivor.OptionsLayout.Columns.AddNewColumns = False
        Me.gvSamplesSurvivor.OptionsLayout.Columns.RemoveOldColumns = False
        Me.gvSamplesSurvivor.OptionsView.ShowGroupPanel = False
        Me.gvSamplesSurvivor.OptionsView.ShowIndicator = False
        '
        'gcolMaterialIDSurvivor
        '
        resources.ApplyResources(Me.gcolMaterialIDSurvivor, "gcolMaterialIDSurvivor")
        Me.gcolMaterialIDSurvivor.FieldName = "idfMaterial"
        Me.gcolMaterialIDSurvivor.Name = "gcolMaterialIDSurvivor"
        '
        'gcolRowTypeSurvivor
        '
        resources.ApplyResources(Me.gcolRowTypeSurvivor, "gcolRowTypeSurvivor")
        Me.gcolRowTypeSurvivor.FieldName = "rowType"
        Me.gcolRowTypeSurvivor.Name = "gcolRowTypeSurvivor"
        '
        'gcolCheckedSurvivor
        '
        resources.ApplyResources(Me.gcolCheckedSurvivor, "gcolCheckedSurvivor")
        Me.gcolCheckedSurvivor.ColumnEdit = Me.chAddToCaseSurvivor
        Me.gcolCheckedSurvivor.FieldName = "AddToSurvivorCase"
        Me.gcolCheckedSurvivor.Name = "gcolCheckedSurvivor"
        Me.gcolCheckedSurvivor.OptionsColumn.ShowCaption = False
        '
        'chAddToCaseSurvivor
        '
        resources.ApplyResources(Me.chAddToCaseSurvivor, "chAddToCaseSurvivor")
        Me.chAddToCaseSurvivor.Name = "chAddToCaseSurvivor"
        '
        'gcolSampleIDSurvivor
        '
        resources.ApplyResources(Me.gcolSampleIDSurvivor, "gcolSampleIDSurvivor")
        Me.gcolSampleIDSurvivor.FieldName = "strFieldBarcode"
        Me.gcolSampleIDSurvivor.Name = "gcolSampleIDSurvivor"
        Me.gcolSampleIDSurvivor.OptionsColumn.AllowEdit = False
        '
        'gcolSampleTypeSurvivor
        '
        resources.ApplyResources(Me.gcolSampleTypeSurvivor, "gcolSampleTypeSurvivor")
        Me.gcolSampleTypeSurvivor.FieldName = "SampleType_Name"
        Me.gcolSampleTypeSurvivor.Name = "gcolSampleTypeSurvivor"
        Me.gcolSampleTypeSurvivor.OptionsColumn.AllowEdit = False
        '
        'gcolCollectionDateSurvivor
        '
        resources.ApplyResources(Me.gcolCollectionDateSurvivor, "gcolCollectionDateSurvivor")
        Me.gcolCollectionDateSurvivor.FieldName = "datFieldCollectionDate"
        Me.gcolCollectionDateSurvivor.Name = "gcolCollectionDateSurvivor"
        Me.gcolCollectionDateSurvivor.OptionsColumn.AllowEdit = False
        '
        'gcolTestQuantitySurvivor
        '
        resources.ApplyResources(Me.gcolTestQuantitySurvivor, "gcolTestQuantitySurvivor")
        Me.gcolTestQuantitySurvivor.FieldName = "TestQuantity"
        Me.gcolTestQuantitySurvivor.Name = "gcolTestQuantitySurvivor"
        Me.gcolTestQuantitySurvivor.OptionsColumn.AllowEdit = False
        '
        'gcolCanUncheckSurvivor
        '
        Me.gcolCanUncheckSurvivor.FieldName = "CanRemoveFromSurvivorCase"
        Me.gcolCanUncheckSurvivor.Name = "gcolCanUncheckSurvivor"
        '
        'HumanCaseDeduplicationDetail
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.pnHCDeduplication)
        Me.FormID = "H11"
        Me.HelpTopicID = "HumanDeduplicationForm"
        Me.LeftIcon = Global.EIDSS.My.Resources.Resources.Human_Case_De_duplication__large_
        Me.Name = "HumanCaseDeduplicationDetail"
        Me.ShowDeleteButton = False
        Me.ShowSaveButton = False
        Me.Controls.SetChildIndex(Me.pnHCDeduplication, 0)
        CType(Me.pnHCDeduplication, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnHCDeduplication.ResumeLayout(False)
        CType(Me.gbSurvivor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSurvivor.ResumeLayout(False)
        CType(Me.cbSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbSuperseded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSuperseded.ResumeLayout(False)
        CType(Me.cbSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tcSuperseded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tcSuperseded.ResumeLayout(False)
        Me.tpNotificationSuperseded.ResumeLayout(False)
        CType(Me.tbLocalIDSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnLocalIDSuperseded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnLocalIDSuperseded.ResumeLayout(False)
        Me.pnLocalIDSuperseded.PerformLayout()
        CType(Me.rbLocalIDSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnClinicalSuperseded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnClinicalSuperseded.ResumeLayout(False)
        Me.pnClinicalSuperseded.PerformLayout()
        CType(Me.LabelControl6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelControl5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAddCaseInfoSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnAddCaseInfoSuperseded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnAddCaseInfoSuperseded.ResumeLayout(False)
        Me.pnAddCaseInfoSuperseded.PerformLayout()
        CType(Me.rbAddCaseInfoSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPatientLocationNameSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnPatientLocationNameSuperseded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnPatientLocationNameSuperseded.ResumeLayout(False)
        CType(Me.rbPatientLocationNameSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPatientLocationStatusSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnPatientLocationStatusSuperseded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnPatientLocationStatusSuperseded.ResumeLayout(False)
        Me.pnPatientLocationStatusSuperseded.PerformLayout()
        CType(Me.rbPatientLocationStatusSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbChangedDiagnosisDateSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnChangedDiagnosisDateSuperseded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnChangedDiagnosisDateSuperseded.ResumeLayout(False)
        Me.pnChangedDiagnosisDateSuperseded.PerformLayout()
        CType(Me.rbChangedDiagnosisDateSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbChangedDiagnosisSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnChangedDiagnosisSuperseded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnChangedDiagnosisSuperseded.ResumeLayout(False)
        Me.pnChangedDiagnosisSuperseded.PerformLayout()
        CType(Me.rbChangedDiagnosisSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbFinalStateSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnFinalStateSuperseded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnFinalStateSuperseded.ResumeLayout(False)
        Me.pnFinalStateSuperseded.PerformLayout()
        CType(Me.rbFinalStateSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbOnsetDateSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnOnsetDateSuperseded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnOnsetDateSuperseded.ResumeLayout(False)
        Me.pnOnsetDateSuperseded.PerformLayout()
        CType(Me.rbOnsetDateSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDiagnosisDateSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnDiagnosisDateSuperseded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnDiagnosisDateSuperseded.ResumeLayout(False)
        Me.pnDiagnosisDateSuperseded.PerformLayout()
        CType(Me.rbDiagnosisDateSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDiagnosisSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnDiagnosisSuperseded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnDiagnosisSuperseded.ResumeLayout(False)
        Me.pnDiagnosisSuperseded.PerformLayout()
        CType(Me.rbDiagnosisSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnDemographicSuperseded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnDemographicSuperseded.ResumeLayout(False)
        Me.pnDemographicSuperseded.PerformLayout()
        CType(Me.LabelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbGeoLocationEmployerSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbEmployerNameSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPhoneNumberSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbNationalitySuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbPatientInfoSuperseded, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAptmHomeSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbBuildingHomeSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbHouseHomeSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPostalCodeHomeSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbStreetHomeSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSettlementHomeSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbRayonHomeSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbRegionHomeSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAgeUnitsSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSexSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDOBSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAgeSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSecondNameSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbLastNameSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbFirstNameSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnLastNameSuperseded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnLastNameSuperseded.ResumeLayout(False)
        Me.pnLastNameSuperseded.PerformLayout()
        CType(Me.rbLastNameSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnFirstNameSuperseded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnFirstNameSuperseded.ResumeLayout(False)
        Me.pnFirstNameSuperseded.PerformLayout()
        CType(Me.rbFirstNameSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnSecondNameSuperseded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnSecondNameSuperseded.ResumeLayout(False)
        Me.pnSecondNameSuperseded.PerformLayout()
        CType(Me.rbSecondNameSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnDOBSuperseded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnDOBSuperseded.ResumeLayout(False)
        Me.pnDOBSuperseded.PerformLayout()
        CType(Me.rbDOBSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnAgeSuperseded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnAgeSuperseded.ResumeLayout(False)
        Me.pnAgeSuperseded.PerformLayout()
        CType(Me.rbAgeSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnSexSuperseded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnSexSuperseded.ResumeLayout(False)
        Me.pnSexSuperseded.PerformLayout()
        CType(Me.rbSexSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnGeoLocationHomeIDSuperseded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnGeoLocationHomeIDSuperseded.ResumeLayout(False)
        Me.pnGeoLocationHomeIDSuperseded.PerformLayout()
        CType(Me.rbGeoLocationHomeIDSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnPhoneNumberSuperseded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnPhoneNumberSuperseded.ResumeLayout(False)
        Me.pnPhoneNumberSuperseded.PerformLayout()
        CType(Me.rbPhoneNumberSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnNationalitySuperseded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnNationalitySuperseded.ResumeLayout(False)
        Me.pnNationalitySuperseded.PerformLayout()
        CType(Me.rbNationalitySuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnEmployerNameSuperseded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnEmployerNameSuperseded.ResumeLayout(False)
        CType(Me.rbEmployerNameSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnGeoLocationEmployerSuperseded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnGeoLocationEmployerSuperseded.ResumeLayout(False)
        CType(Me.rbGeoLocationEmployerSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbCaseIDSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnCaseIDSuperseded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnCaseIDSuperseded.ResumeLayout(False)
        Me.pnCaseIDSuperseded.PerformLayout()
        CType(Me.rbCaseIDSuperseded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpSamplesSuperseded.ResumeLayout(False)
        CType(Me.gcSamplesSuperseded, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvSamplesSuperseded, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chAddToCaseSuperseded, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tcSurvivor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tcSurvivor.ResumeLayout(False)
        Me.tpNotificationSurvivor.ResumeLayout(False)
        CType(Me.tbLocalIDSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnLocalIDSurvivor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnLocalIDSurvivor.ResumeLayout(False)
        Me.pnLocalIDSurvivor.PerformLayout()
        CType(Me.rbLocalIDSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnClinicalSurvivor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnClinicalSurvivor.ResumeLayout(False)
        Me.pnClinicalSurvivor.PerformLayout()
        CType(Me.LabelControl8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelControl7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAddCaseInfoSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnAddCaseInfoSurvivor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnAddCaseInfoSurvivor.ResumeLayout(False)
        Me.pnAddCaseInfoSurvivor.PerformLayout()
        CType(Me.rbAddCaseInfoSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPatientLocationNameSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnPatientLocationNameSurvivor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnPatientLocationNameSurvivor.ResumeLayout(False)
        CType(Me.rbPatientLocationNameSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPatientLocationStatusSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnPatientLocationStatusSurvivor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnPatientLocationStatusSurvivor.ResumeLayout(False)
        Me.pnPatientLocationStatusSurvivor.PerformLayout()
        CType(Me.rbPatientLocationStatusSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbChangedDiagnosisDateSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnChangedDiagnosisDateSurvivor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnChangedDiagnosisDateSurvivor.ResumeLayout(False)
        Me.pnChangedDiagnosisDateSurvivor.PerformLayout()
        CType(Me.rbChangedDiagnosisDateSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbChangedDiagnosisSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnChangedDiagnosisSurvivor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnChangedDiagnosisSurvivor.ResumeLayout(False)
        Me.pnChangedDiagnosisSurvivor.PerformLayout()
        CType(Me.rbChangedDiagnosisSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbFinalStateSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnFinalStateSurvivor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnFinalStateSurvivor.ResumeLayout(False)
        Me.pnFinalStateSurvivor.PerformLayout()
        CType(Me.rbFinalStateSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbOnsetDateSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnOnsetDateSurvivor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnOnsetDateSurvivor.ResumeLayout(False)
        Me.pnOnsetDateSurvivor.PerformLayout()
        CType(Me.rbOnsetDateSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDiagnosisDateSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnDiagnosisDateSurvivor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnDiagnosisDateSurvivor.ResumeLayout(False)
        Me.pnDiagnosisDateSurvivor.PerformLayout()
        CType(Me.rbDiagnosisDateSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDiagnosisSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnDiagnosisSurvivor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnDiagnosisSurvivor.ResumeLayout(False)
        Me.pnDiagnosisSurvivor.PerformLayout()
        CType(Me.rbDiagnosisSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnDemographicSurvivor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnDemographicSurvivor.ResumeLayout(False)
        Me.pnDemographicSurvivor.PerformLayout()
        CType(Me.LabelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbGeoLocationEmployerSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbEmployerNameSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPhoneNumberSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbNationalitySurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAptmHomeSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbBuildingHomeSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbHouseHomeSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPostalCodeHomeSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbStreetHomeSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSettlementHomeSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbRayonHomeSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbRegionHomeSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbPatientInfoSurvivor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAgeUnitsSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSexSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDOBSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbAgeSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSecondNameSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbLastNameSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbFirstNameSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnLastNameSurvivor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnLastNameSurvivor.ResumeLayout(False)
        Me.pnLastNameSurvivor.PerformLayout()
        CType(Me.rbLastNameSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnFirstNameSurvivor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnFirstNameSurvivor.ResumeLayout(False)
        Me.pnFirstNameSurvivor.PerformLayout()
        CType(Me.rbFirstNameSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnSecondNameSurvivor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnSecondNameSurvivor.ResumeLayout(False)
        Me.pnSecondNameSurvivor.PerformLayout()
        CType(Me.rbSecondNameSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnDOBSurvivor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnDOBSurvivor.ResumeLayout(False)
        Me.pnDOBSurvivor.PerformLayout()
        CType(Me.rbDOBSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnAgeSurvivor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnAgeSurvivor.ResumeLayout(False)
        Me.pnAgeSurvivor.PerformLayout()
        CType(Me.rbAgeSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnSexSurvivor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnSexSurvivor.ResumeLayout(False)
        Me.pnSexSurvivor.PerformLayout()
        CType(Me.rbSexSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnPhoneNumberSurvivor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnPhoneNumberSurvivor.ResumeLayout(False)
        Me.pnPhoneNumberSurvivor.PerformLayout()
        CType(Me.rbPhoneNumberSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnNationalitySurvivor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnNationalitySurvivor.ResumeLayout(False)
        Me.pnNationalitySurvivor.PerformLayout()
        CType(Me.rbNationalitySurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnEmployerNameSurvivor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnEmployerNameSurvivor.ResumeLayout(False)
        CType(Me.rbEmployerNameSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnGeoLocationEmployerSurvivor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnGeoLocationEmployerSurvivor.ResumeLayout(False)
        CType(Me.rbGeoLocationEmployerSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnGeoLocationHomeIDSurvivor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnGeoLocationHomeIDSurvivor.ResumeLayout(False)
        Me.pnGeoLocationHomeIDSurvivor.PerformLayout()
        CType(Me.rbGeoLocationHomeIDSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbCaseIDSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnCaseIDSurvivor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnCaseIDSurvivor.ResumeLayout(False)
        Me.pnCaseIDSurvivor.PerformLayout()
        CType(Me.rbCaseIDSurvivor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpSamplesSurvivor.ResumeLayout(False)
        CType(Me.gcSamplesSurvivor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvSamplesSurvivor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chAddToCaseSurvivor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub


#End Region

#Region "Main form interface"
    Public Shared Sub ShowMe()
        BaseFormManager.ShowNormal(New HumanCaseDeduplicationDetail, Nothing)
        'BaseForm.ShowModal(New HumanCaseDeduplicationDetail)
    End Sub
#End Region

#Region "Control Movement"

    Dim OkToChangeTabPage As Boolean = True

    Private Sub tcSurvivor_SelectedIndexChanged(ByVal sender As Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles tcSurvivor.SelectedPageChanged
        If (OkToChangeTabPage = True) Then
            OkToChangeTabPage = False
            tcSuperseded.SelectedTabPageIndex = tcSurvivor.SelectedTabPageIndex
            tcSurvivor.Select()
            OkToChangeTabPage = True
        End If
    End Sub

    Private Sub tcSuperseded_SelectedIndexChanged(ByVal sender As Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles tcSuperseded.SelectedPageChanged
        If (OkToChangeTabPage = True) Then
            OkToChangeTabPage = False
            tcSurvivor.SelectedTabPageIndex = tcSuperseded.SelectedTabPageIndex
            tcSuperseded.Select()
            OkToChangeTabPage = True
        End If

    End Sub

    Dim OkToScrollTabPage As Boolean = True

    Private m_NotificationScrollValue As Integer = 0

    Private Sub tpNotificationSurvivor_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tpNotificationSurvivor.MouseWheel
        If (OkToScrollTabPage = True) Then
            OkToScrollTabPage = False
            m_NotificationScrollValue = tpNotificationSurvivor.VerticalScroll.Value
            tpNotificationSuperseded_MouseWheel(tpNotificationSuperseded, e)
            OkToScrollTabPage = True
        Else
            tpNotificationSurvivor.VerticalScroll.Value = m_NotificationScrollValue
            tpNotificationSurvivor.VerticalScroll.Value = m_NotificationScrollValue
            tpNotificationSurvivor.Update()
        End If
    End Sub

    Private Sub tpNotificationSurvivor_Scroll(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.XtraScrollEventArgs) Handles tpNotificationSurvivor.Scroll
        If (OkToScrollTabPage = True) Then
            OkToScrollTabPage = False
            m_NotificationScrollValue = e.NewValue
            tpNotificationSurvivor.VerticalScroll.Value = m_NotificationScrollValue
            tpNotificationSuperseded_Scroll(tpNotificationSuperseded, e)
            OkToScrollTabPage = True
        Else
            tpNotificationSurvivor.VerticalScroll.Value = m_NotificationScrollValue
            tpNotificationSurvivor.VerticalScroll.Value = m_NotificationScrollValue
            tpNotificationSurvivor.Update()
        End If
    End Sub

    Private Sub tpNotificationSuperseded_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tpNotificationSuperseded.MouseWheel
        If (OkToScrollTabPage = True) Then
            OkToScrollTabPage = False
            m_NotificationScrollValue = tpNotificationSuperseded.VerticalScroll.Value
            tpNotificationSurvivor_MouseWheel(tpNotificationSurvivor, e)
            OkToScrollTabPage = True
        Else
            tpNotificationSuperseded.VerticalScroll.Value = m_NotificationScrollValue
            tpNotificationSuperseded.VerticalScroll.Value = m_NotificationScrollValue
            tpNotificationSuperseded.Update()
        End If
    End Sub

    Private Sub tpNotificationSuperseded_Scroll(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.XtraScrollEventArgs) Handles tpNotificationSuperseded.Scroll
        If (OkToScrollTabPage = True) Then
            OkToScrollTabPage = False
            m_NotificationScrollValue = e.NewValue
            tpNotificationSuperseded.VerticalScroll.Value = m_NotificationScrollValue
            tpNotificationSurvivor_Scroll(tpNotificationSurvivor, e)
            OkToScrollTabPage = True
        Else
            tpNotificationSuperseded.VerticalScroll.Value = m_NotificationScrollValue
            tpNotificationSuperseded.VerticalScroll.Value = m_NotificationScrollValue
            tpNotificationSuperseded.Update()
        End If
    End Sub

    Private m_SampleScrollValue As Integer = 0

    Private Sub tpSamplesSurvivor_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tpSamplesSurvivor.MouseWheel
        If (OkToScrollTabPage = True) Then
            OkToScrollTabPage = False
            m_SampleScrollValue = tpSamplesSurvivor.VerticalScroll.Value
            tpSamplesSuperseded_MouseWheel(tpSamplesSuperseded, e)
            OkToScrollTabPage = True
        Else
            tpSamplesSurvivor.VerticalScroll.Value = m_SampleScrollValue
            tpSamplesSurvivor.VerticalScroll.Value = m_SampleScrollValue
            tpSamplesSurvivor.Update()
        End If
    End Sub

    Private Sub tpSamplesSurvivor_Scroll(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.XtraScrollEventArgs) Handles tpSamplesSurvivor.Scroll
        If (OkToScrollTabPage = True) Then
            OkToScrollTabPage = False
            m_SampleScrollValue = e.NewValue
            tpSamplesSurvivor.VerticalScroll.Value = m_SampleScrollValue
            tpSamplesSuperseded_Scroll(tpSamplesSuperseded, e)
            OkToScrollTabPage = True
        Else
            tpSamplesSurvivor.VerticalScroll.Value = m_SampleScrollValue
            tpSamplesSurvivor.VerticalScroll.Value = m_SampleScrollValue
            tpSamplesSurvivor.Update()
        End If
    End Sub

    Private Sub tpSamplesSuperseded_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tpSamplesSuperseded.MouseWheel
        If (OkToScrollTabPage = True) Then
            OkToScrollTabPage = False
            m_SampleScrollValue = tpSamplesSuperseded.VerticalScroll.Value
            tpSamplesSurvivor_MouseWheel(tpSamplesSurvivor, e)
            OkToScrollTabPage = True
        Else
            tpSamplesSuperseded.VerticalScroll.Value = m_SampleScrollValue
            tpSamplesSuperseded.VerticalScroll.Value = m_SampleScrollValue
            tpSamplesSuperseded.Update()
        End If
    End Sub

    Private Sub tpSamplesSuperseded_Scroll(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.XtraScrollEventArgs) Handles tpSamplesSuperseded.Scroll
        If (OkToScrollTabPage = True) Then
            OkToScrollTabPage = False
            m_SampleScrollValue = e.NewValue
            tpSamplesSuperseded.VerticalScroll.Value = m_SampleScrollValue
            tpSamplesSurvivor_Scroll(tpSamplesSurvivor, e)
            OkToScrollTabPage = True
        Else
            tpSamplesSuperseded.VerticalScroll.Value = m_SampleScrollValue
            tpSamplesSuperseded.VerticalScroll.Value = m_SampleScrollValue
            tpSamplesSuperseded.Update()
        End If
    End Sub


#End Region

#Region "ReadOnly View"
    Public Overrides Property [ReadOnly]() As Boolean
        Get
            Return MyBase.ReadOnly
        End Get
        Set(ByVal Value As Boolean)
            MyBase.ReadOnly = Value
            If Value Then
                Me.ShowCancelButton = True
                ArrangeButtons(CancelButton.Top, "BottomButtons")
            End If
        End Set
    End Property
#End Region

#Region "Bindings"
    Private Sub InitData(ByVal parent As Control)
        For Each ctrl As Control In parent.Controls
            If (TypeOf (ctrl) Is DevExpress.XtraEditors.TextEdit) Then
                CType(ctrl, DevExpress.XtraEditors.TextEdit).TabStop = True
                Dim cpName As String = ""
                If (ctrl.Name.StartsWith("tb") = True) AndAlso _
                   ((ctrl.Name.EndsWith("Survivor") = True) OrElse (ctrl.Name.EndsWith("Superseded") = True)) AndAlso _
                   (ctrl.Name.Replace("Survivor", "").Replace("Superseded", "").Length > 2) Then
                    cpName = ctrl.Name.Substring(2, ctrl.Name.Length - 2).Replace("Survivor", "").Replace("Superseded", "")
                End If
                Dim cp As CaseProperty = Nothing
                cp = HumanCaseDeduplicationDbService.FindProperty(cpName)
                If (Not cp Is Nothing) Then
                    If (Utils.Str(cp.SurvivorValueText, "") <> Utils.Str(cp.SupersededValueText, "")) Then
                        Dim f As System.Drawing.Font = New System.Drawing.Font(CType(ctrl, DevExpress.XtraEditors.TextEdit).Font, Drawing.FontStyle.Bold)
                        CType(ctrl, DevExpress.XtraEditors.TextEdit).Font = f
                        CType(ctrl, DevExpress.XtraEditors.TextEdit).ForeColor = Drawing.Color.Red
                    Else
                        Dim f As System.Drawing.Font = New System.Drawing.Font(CType(ctrl, DevExpress.XtraEditors.TextEdit).Font, Drawing.FontStyle.Regular)
                        CType(ctrl, DevExpress.XtraEditors.TextEdit).Font = f
                        CType(ctrl, DevExpress.XtraEditors.TextEdit).ForeColor = Drawing.Color.Black
                    End If
                    If ((m_SelectedIndex = 0) AndAlso ctrl.Name.EndsWith("Survivor")) OrElse _
                       ((m_SelectedIndex = 1) AndAlso ctrl.Name.EndsWith("Superseded")) Then
                        CType(ctrl, DevExpress.XtraEditors.TextEdit).Properties.ReadOnly = False
                        If (TypeOf (cp.SurvivorValueText) Is DateTime) Then
                            CType(ctrl, DevExpress.XtraEditors.TextEdit).Text = CDate(cp.SurvivorValueText).ToString("d")
                        Else
                            CType(ctrl, DevExpress.XtraEditors.TextEdit).Text = Utils.Str(cp.SurvivorValueText, "")
                        End If
                        CType(ctrl, DevExpress.XtraEditors.TextEdit).Properties.ReadOnly = True
                        CType(ctrl, DevExpress.XtraEditors.TextEdit).BackColor = Drawing.Color.White
                    End If
                    If ((m_SelectedIndex = 1) AndAlso ctrl.Name.EndsWith("Survivor")) OrElse _
                       ((m_SelectedIndex = 0) AndAlso ctrl.Name.EndsWith("Superseded")) Then
                        CType(ctrl, DevExpress.XtraEditors.TextEdit).Properties.ReadOnly = False
                        If (TypeOf (cp.SupersededValueText) Is DateTime) Then
                            CType(ctrl, DevExpress.XtraEditors.TextEdit).Text = CDate(cp.SupersededValueText).ToString("d")
                        Else
                            CType(ctrl, DevExpress.XtraEditors.TextEdit).Text = Utils.Str(cp.SupersededValueText, "")
                        End If
                        CType(ctrl, DevExpress.XtraEditors.TextEdit).Properties.ReadOnly = True
                        CType(ctrl, DevExpress.XtraEditors.TextEdit).BackColor = Drawing.Color.White
                    End If
                End If
            End If

            '(only for non-simple version of de-duplication)
            'If (TypeOf (ctrl) Is DevExpress.XtraEditors.CheckEdit) Then
            '    CType(ctrl, DevExpress.XtraEditors.CheckEdit).TabStop = True
            '    Dim cpName As String = ""
            '    If (ctrl.Name.StartsWith("rb") = True) AndAlso _
            '       ((ctrl.Name.EndsWith("Survivor") = True) OrElse (ctrl.Name.EndsWith("Superseded") = True)) AndAlso _
            '       (ctrl.Name.Replace("Survivor", "").Replace("Superseded", "").Length > 2) Then
            '        cpName = ctrl.Name.Substring(2, ctrl.Name.Length - 2).Replace("Survivor", "").Replace("Superseded", "")
            '    End If
            '    Dim cp As CaseProperty = Nothing
            '    cp = HumanCaseDeduplicationDbService.FindProperty(cpName)
            '    If (Not cp Is Nothing) Then
            '        If (Utils.Str(cp.SurvivorValueText, "") <> Utils.Str(cp.SupersededValueText, "")) Then
            '            CType(ctrl, DevExpress.XtraEditors.CheckEdit).ForeColor = Drawing.Color.Red
            '            CType(ctrl, DevExpress.XtraEditors.CheckEdit).Visible = True
            '            If (ctrl.Name.EndsWith("Survivor") = True) Then
            '                OkToChangeObjectRole = False
            '                CType(ctrl, DevExpress.XtraEditors.CheckEdit).Checked = _
            '                    ((m_SelectedIndex = 0) AndAlso cp.IsSurvivorValuePrimary) OrElse _
            '                    ((m_SelectedIndex = 1) AndAlso Not cp.IsSurvivorValuePrimary)
            '                OkToChangeObjectRole = True
            '            End If
            '            If (ctrl.Name.EndsWith("Superseded") = True) Then
            '                OkToChangeObjectRole = False
            '                CType(ctrl, DevExpress.XtraEditors.CheckEdit).Checked = _
            '                    ((m_SelectedIndex = 0) AndAlso Not cp.IsSurvivorValuePrimary) OrElse _
            '                    ((m_SelectedIndex = 1) AndAlso cp.IsSurvivorValuePrimary)
            '                OkToChangeObjectRole = True
            '            End If
            '        Else
            '            CType(ctrl, DevExpress.XtraEditors.CheckEdit).ForeColor = Drawing.Color.Black
            '            CType(ctrl, DevExpress.XtraEditors.CheckEdit).Visible = False
            '        End If
            '    End If
            'End If

            If (TypeOf (ctrl) Is DevExpress.XtraEditors.LabelControl) Then
                Dim cpName As String = ""
                If (ctrl.Name.StartsWith("lbl") = True) AndAlso _
                   ((ctrl.Name.EndsWith("Survivor") = True) OrElse (ctrl.Name.EndsWith("Superseded") = True)) AndAlso _
                   (ctrl.Name.Replace("Survivor", "").Replace("Superseded", "").Length > 3) Then
                    cpName = ctrl.Name.Substring(3, ctrl.Name.Length - 3).Replace("Survivor", "").Replace("Superseded", "")
                End If
                Dim cp As CaseProperty = Nothing
                cp = HumanCaseDeduplicationDbService.FindProperty(cpName)
                If (Not cp Is Nothing) Then
                    If (Utils.Str(cp.SurvivorValueText, "") <> Utils.Str(cp.SupersededValueText, "")) Then
                        CType(ctrl, DevExpress.XtraEditors.LabelControl).ForeColor = Drawing.Color.Red
                    Else
                        CType(ctrl, DevExpress.XtraEditors.LabelControl).ForeColor = Drawing.Color.Black
                    End If
                End If
            End If
            If (ctrl.Controls.Count > 0) Then
                InitData(ctrl)
            End If
        Next
    End Sub

    Private Sub AddHandlers(ByVal parent As Control)
        If (TypeOf (parent) Is Panel) OrElse (TypeOf (parent) Is DevExpress.XtraEditors.PanelControl) OrElse _
           (TypeOf (parent) Is GroupBox) OrElse (TypeOf (parent) Is DevExpress.XtraEditors.GroupControl) OrElse _
           (TypeOf (parent) Is Label) OrElse (TypeOf (parent) Is DevExpress.XtraEditors.LabelControl) OrElse _
           (TypeOf (parent) Is RadioButton) OrElse (TypeOf (parent) Is DevExpress.XtraEditors.CheckEdit) OrElse _
           (TypeOf (parent) Is TextBox) OrElse (TypeOf (parent) Is DevExpress.XtraEditors.TextEdit) Then
            AddHandler parent.GotFocus, AddressOf Me.Control_GotFocus
        End If
        If (TypeOf (parent) Is DevExpress.XtraEditors.CheckEdit) Then
            Dim rb As DevExpress.XtraEditors.CheckEdit = CType(parent, DevExpress.XtraEditors.CheckEdit)
            AddHandler rb.CheckedChanged, AddressOf Me.rb_CheckedChanged
        End If
        For Each ctrl As Control In parent.Controls
            AddHandlers(ctrl)
        Next
    End Sub

    Private Sub RemoveHandlers(ByVal parent As Control)
        If (TypeOf (parent) Is Panel) OrElse (TypeOf (parent) Is DevExpress.XtraEditors.PanelControl) OrElse _
           (TypeOf (parent) Is GroupBox) OrElse (TypeOf (parent) Is DevExpress.XtraEditors.GroupControl) OrElse _
           (TypeOf (parent) Is Label) OrElse (TypeOf (parent) Is DevExpress.XtraEditors.LabelControl) OrElse _
           (TypeOf (parent) Is RadioButton) OrElse (TypeOf (parent) Is DevExpress.XtraEditors.CheckEdit) OrElse _
           (TypeOf (parent) Is TextBox) OrElse (TypeOf (parent) Is DevExpress.XtraEditors.TextEdit) Then
            RemoveHandler parent.GotFocus, AddressOf Me.Control_GotFocus
        End If
        If (TypeOf (parent) Is DevExpress.XtraEditors.CheckEdit) Then
            Dim rb As DevExpress.XtraEditors.CheckEdit = CType(parent, DevExpress.XtraEditors.CheckEdit)
            RemoveHandler rb.CheckedChanged, AddressOf Me.rb_CheckedChanged
        End If
        For Each ctrl As Control In parent.Controls
            RemoveHandlers(ctrl)
        Next
    End Sub

    Protected Overrides Sub DefineBinding()
        RemoveHandlers(Me)
        Dim dvSamplesSurvivor As DataView = New DataView( _
                baseDataSet.Tables(HumanCaseDeduplication_DB.tlbMaterial), _
                "rowType = 'Survivor'", _
                "strFieldBarcode", _
                DataViewRowState.CurrentRows)
        gcSamplesSurvivor.DataSource = dvSamplesSurvivor
        Dim dvSamplesSuperseded As DataView = New DataView( _
                baseDataSet.Tables(HumanCaseDeduplication_DB.tlbMaterial), _
                "rowType = 'Superseded'", _
                "strFieldBarcode", _
                DataViewRowState.CurrentRows)
        gcSamplesSuperseded.DataSource = dvSamplesSuperseded
        InitData(Me)
        AddHandlers(Me)
    End Sub
#End Region

#Region "Post Methods"
    Public Overrides Function ValidateData() As Boolean
        Return True
    End Function

    Private Function PromptDialog(ByVal Question As String, Optional ByVal DefaultResult As DialogResult = DialogResult.Yes) As DialogResult
        If bv.common.Configuration.BaseSettings.ShowSaveDataPrompt Then
            Return bv.winclient.Core.MessageForm.Show(Question, BvMessages.Get("Confirmation"), MessageBoxButtons.YesNoCancel)
        End If
        Return DefaultResult
    End Function

    Public Overrides Function Post(Optional ByVal postType As PostType = PostType.FinalPosting) As Boolean
        If UseFormStatus = True AndAlso Status = FormStatus.Demo Then
            Return True
        End If
        If HumanCaseDeduplicationDbService Is Nothing Then Return True
        If (PostType And PostType.IntermediatePosting) = 0 Then
            Dim DefaultResult As DialogResult = DialogResult.Yes
            If m_ClosingMode <> ClosingMode.Ok Then
                DefaultResult = DialogResult.No
            End If
            m_PromptResult = PromptDialog(EidssMessages.Get("msgDeduplicateQuestion", "De-duplicate cases?"), DefaultResult)
            If m_PromptResult = DialogResult.Cancel Then
                Return False
            End If
            If m_PromptResult = DialogResult.No Then Return True
            RaiseBeforeValidatingEvent()
            If ValidateData() = False Then
                m_PromptResult = DialogResult.Cancel
                Return False
            Else
                m_PromptResult = DialogResult.Yes
            End If
        End If

        If HumanCaseDeduplicationDbService Is Nothing Then
            Throw New Exception("Detail form DB service is not defined")
            Return False
        End If
        RaiseBeforePostEvent(Me)
#If DEBUG Then
        Dbg.Assert(IgnoreAudit = True OrElse Not AuditObject Is Nothing, "Audit object for baseform {0} is not defined", Me.GetType().Name)
#End If
        HumanCaseDeduplicationDbService.ClearEvents()
        If Not AuditObject Is Nothing Then
            Dim cp As CaseProperty = Nothing
            cp = HumanCaseDeduplicationDbService.FindProperty("idfCase")
            If (Not cp Is Nothing) Then
                AuditObject.Key = cp.SurvivorValueID
            Else
                AuditObject.Key = Nothing
            End If
            Dbg.DbgAssert(Not Utils.IsEmpty(AuditObject.Key), "object key is not defined for object {0}", AuditObject.Name)
            AuditObject.EventType = AuditEventType.daeEdit
            AddHandler HumanCaseDeduplicationDbService.OnTransactionStarted, AddressOf CreateAuditEvent
            AddHandler HumanCaseDeduplicationDbService.OnTransactionFinished, AddressOf SaveEventLog
            AddHandler HumanCaseDeduplicationDbService.OnTransactionFinished, AddressOf ProcessFiltration
        End If
        If (m_DisableFormDuringPost = True) Then ' Special hint for the form designer
            Enabled = False
        End If
        Try
            If HumanCaseDeduplicationDbService.Post(baseDataSet, PostType) = False Then
                ErrorForm.ShowError(DbService.LastError)
                Me.Enabled = True
                Return False
            End If
            Me.Enabled = True
            If (PostType And PostType.IntermediatePosting) <> 0 Then
                m_State = BusinessObjectState.EditObject Or (m_State And BusinessObjectState.IntermediateObject)
                m_WasSaved = True
            End If
            If (PostType And PostType.FinalPosting) <> 0 Then
                m_State = BusinessObjectState.EditObject
                SaveInitialChanges()
                m_WasSaved = False
                m_WasPosted = True
            End If
            RaiseAfterPostEvent(Me)
            m_RefereshParentForm = True
            RefreshRelatedForms()
            Return True
        Catch ex As Exception
            Throw
        Finally
            If Not AuditObject Is Nothing Then
                RemoveHandler HumanCaseDeduplicationDbService.OnTransactionStarted, AddressOf CreateAuditEvent
                RemoveHandler HumanCaseDeduplicationDbService.OnTransactionFinished, AddressOf SaveEventLog
                RemoveHandler HumanCaseDeduplicationDbService.OnTransactionFinished, AddressOf ProcessFiltration
            End If
            If Not m_ParentBaseForm Is Nothing AndAlso Not m_ParentBaseForm.IsDisposed AndAlso TypeOf Me.m_ParentBaseForm Is BaseListForm Then
                m_ParentBaseForm.LoadData(Nothing)
                CType(m_ParentBaseForm, BaseListForm).LocateRow(GetKey)
                m_RefereshParentForm = False
            End If
            Enabled = True
        End Try
    End Function
#End Region

#Region "Control Events"
    Dim OkToChangeRoles As Boolean = True

    Private Sub HumanCaseDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OkToChangeRoles = False
        cbSurvivor.Properties.Items.Clear()
        cbSurvivor.Properties.Items.Add(EidssMessages.Get("Survivor", "Survivor"))
        cbSurvivor.Properties.Items.Add(EidssMessages.Get("Superseded", "Superseded"))
        cbSurvivor.SelectedIndex = 0

        cbSuperseded.Properties.Items.Clear()
        cbSuperseded.Properties.Items.Add(EidssMessages.Get("Survivor", "Survivor"))
        cbSuperseded.Properties.Items.Add(EidssMessages.Get("Superseded", "Superseded"))
        cbSuperseded.SelectedIndex = 1
        OkToChangeRoles = True

        tpNotificationSurvivor.VerticalScroll.SmallChange = 1
        tpNotificationSurvivor.VerticalScroll.LargeChange = 10
        tpNotificationSuperseded.VerticalScroll.SmallChange = 1
        tpNotificationSuperseded.VerticalScroll.LargeChange = 10

        tpSamplesSurvivor.VerticalScroll.SmallChange = 1
        tpSamplesSurvivor.VerticalScroll.LargeChange = 10
        tpSamplesSuperseded.VerticalScroll.SmallChange = 1
        tpSamplesSuperseded.VerticalScroll.LargeChange = 10
    End Sub

    Dim m_SelectedIndex As Integer = 0

    Private Sub cbSurvivor_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSurvivor.SelectedValueChanged
        If (OkToChangeRoles = True) Then
            OkToChangeRoles = False
            cbSuperseded.SelectedIndex = 1 - cbSurvivor.SelectedIndex
            If (cbSurvivor.SelectedIndex <> m_SelectedIndex) Then
                m_SelectedIndex = cbSurvivor.SelectedIndex
                HumanCaseDeduplicationDbService.ChangeRoles()
            End If
            InitData(Me)
            OkToChangeRoles = True
        End If
    End Sub

    Private Sub cbSuperseded_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSuperseded.SelectedValueChanged
        If (OkToChangeRoles = True) Then
            OkToChangeRoles = False
            cbSurvivor.SelectedIndex = 1 - cbSuperseded.SelectedIndex
            If (cbSuperseded.SelectedIndex <> 1 - m_SelectedIndex) Then
                m_SelectedIndex = 1 - cbSuperseded.SelectedIndex
                HumanCaseDeduplicationDbService.ChangeRoles()
            End If
            InitData(Me)
            OkToChangeRoles = True
        End If
    End Sub

    Private Function GetParentTabPageName(ByVal ctrl As Control) As String
        If (Not ctrl Is Nothing) AndAlso (Not TypeOf (ctrl) Is DevExpress.XtraTab.XtraTabPage) AndAlso (Not ctrl.Parent Is Nothing) Then
            Dim p As Control = ctrl.Parent
            While (Not p Is Nothing) AndAlso (Not TypeOf (p) Is DevExpress.XtraTab.XtraTabPage)
                p = p.Parent
            End While
            If (Not p Is Nothing) Then
                Return CType(p, DevExpress.XtraTab.XtraTabPage).Name
            End If
        End If
        Return Nothing
    End Function

    Private Sub Control_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If (TypeOf (sender) Is Control) Then
            Dim ctrl As Control = CType(sender, Control)
            Dim tpName As String = GetParentTabPageName(ctrl)
            If ((ctrl.Name.EndsWith("Survivor") = True) OrElse (ctrl.Name.EndsWith("Superseded") = True)) AndAlso _
               (ctrl.Name.Replace("Survivor", "").Replace("Superseded", "").Length > 2) AndAlso _
               (Not Utils.IsEmpty(tpName)) AndAlso _
               ((tpName.EndsWith("Survivor") = True) OrElse (tpName.EndsWith("Superseded") = True)) AndAlso _
               (tpName.Replace("Survivor", "").Replace("Superseded", "").Length > 2) Then

                Dim ctrlMainName As String = ctrl.Name.Replace("Survivor", "").Replace("Superseded", "")
                Dim tpMainName As String = tpName.Replace("Survivor", "").Replace("Superseded", "")
                Dim DiffSuffix As String = tpName.Replace(tpMainName, "")

                If (DiffSuffix = "Survivor") Then
                    DiffSuffix = "Superseded"
                ElseIf (DiffSuffix = "Superseded") Then
                    DiffSuffix = "Survivor"
                End If
                Dim DiffTP() As Control = Me.Controls.Find(tpMainName + DiffSuffix, True)
                Dim DiffCtrl() As Control = Me.Controls.Find(ctrlMainName + DiffSuffix, True)
                If (DiffTP.Length > 0) AndAlso (TypeOf (DiffTP(0)) Is DevExpress.XtraTab.XtraTabPage) AndAlso (DiffCtrl.Length > 0) Then
                    CType(DiffTP(0), DevExpress.XtraTab.XtraTabPage).ScrollControlIntoView(DiffCtrl(0))
                End If
            End If
        End If
    End Sub

    Dim OkToChangeObjectRole As Boolean = True

    Private Sub rb_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If (OkToChangeObjectRole = True) Then
            OkToChangeObjectRole = False
            If (TypeOf (sender) Is DevExpress.XtraEditors.CheckEdit) Then
                Dim rb As DevExpress.XtraEditors.CheckEdit = CType(sender, DevExpress.XtraEditors.CheckEdit)
                Dim cpName As String = ""
                Dim cpSuffix As String = ""
                If (rb.Name.StartsWith("rb") = True) AndAlso _
                   ((rb.Name.EndsWith("Survivor") = True) OrElse (rb.Name.EndsWith("Superseded") = True)) AndAlso _
                   (rb.Name.Replace("Survivor", "").Replace("Superseded", "").Length > 2) Then
                    cpName = rb.Name.Substring(2, rb.Name.Length - 2).Replace("Survivor", "").Replace("Superseded", "")
                    cpSuffix = rb.Name.Substring(2, rb.Name.Length - 2).Replace(cpName, "")
                    If (cpSuffix = "Survivor") Then
                        cpSuffix = "Superseded"
                    ElseIf (cpSuffix = "Superseded") Then
                        cpSuffix = "Survivor"
                    End If
                End If
                Dim cp As CaseProperty = Nothing
                cp = HumanCaseDeduplicationDbService.FindProperty(cpName)
                If (Not cp Is Nothing) Then
                    cp.IsSurvivorValuePrimary() = Not cp.IsSurvivorValuePrimary()
                    If (cpName = CaseProperty.CasePropertyKind.Age.ToString()) Then
                        cp = HumanCaseDeduplicationDbService.FindProperty(CaseProperty.CasePropertyKind.AgeUnits.ToString())
                        If (Not cp Is Nothing) Then
                            cp.IsSurvivorValuePrimary() = Not cp.IsSurvivorValuePrimary()
                        End If
                    End If
                    If (cpName = CaseProperty.CasePropertyKind.LastName.ToString()) Then
                        cp = HumanCaseDeduplicationDbService.FindProperty(CaseProperty.CasePropertyKind.idfHuman.ToString())
                        If (Not cp Is Nothing) Then
                            cp.IsSurvivorValuePrimary() = Not cp.IsSurvivorValuePrimary()
                        End If
                    End If
                End If
                Dim ctrl() As Control = Me.Controls.Find("rb" + cpName + cpSuffix, True)
                If (ctrl.Length > 0) AndAlso (TypeOf (ctrl(0)) Is DevExpress.XtraEditors.CheckEdit) Then
                    CType(ctrl(0), DevExpress.XtraEditors.CheckEdit).Checked = Not rb.Checked
                End If
            End If
        Else
            OkToChangeObjectRole = True
        End If
    End Sub

    Private Sub CheckAll(ByVal parent As Control, ByVal Suffix As String)
        Dim altSuffix As String = ""
        If Suffix = "Survivor" Then
            altSuffix = "Superseded"
        End If
        If Suffix = "Superseded" Then
            altSuffix = "Survivor"
        End If
        For Each ctrl As Control In parent.Controls
            If (TypeOf (ctrl) Is DevExpress.XtraEditors.CheckEdit) AndAlso (ctrl.Name.StartsWith("rb") = True) Then
                If (ctrl.Name.EndsWith(Suffix) = True) AndAlso (ctrl.Name.Length > 2 + Suffix.Length) Then
                    CType(ctrl, DevExpress.XtraEditors.CheckEdit).Checked = True
                End If
                If (Not Utils.IsEmpty(altSuffix)) AndAlso (ctrl.Name.EndsWith(altSuffix) = True) AndAlso _
                   (ctrl.Name.Length > 2 + altSuffix.Length) Then
                    CType(ctrl, DevExpress.XtraEditors.CheckEdit).Checked = False
                End If
            End If
            If (ctrl.Controls.Count > 0) Then
                CheckAll(ctrl, Suffix)
            End If
        Next
        OkToChangeObjectRole = True
    End Sub

    Private Sub btnAllSurvivor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAllSurvivor.Click
        CheckAll(Me, "Survivor")
    End Sub

    Private Sub btnAllSuperseded_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAllSuperseded.Click
        CheckAll(Me, "Superseded")
    End Sub

    Private Sub gvSamplesSurvivor_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles gvSamplesSurvivor.ShowingEditor
        If Closing Then Return
        If (Not gvSamplesSurvivor Is Nothing) AndAlso (gvSamplesSurvivor.FocusedRowHandle >= 0) AndAlso _
           (gvSamplesSurvivor.FocusedColumn Is gcolCheckedSurvivor) Then
            Dim r As DataRow = gvSamplesSurvivor.GetDataRow(gvSamplesSurvivor.FocusedRowHandle)
            Dim CanEdit As Boolean = _
                (r Is Nothing) OrElse _
                Utils.IsEmpty(r("CanRemoveFromSurvivorCase")) OrElse (CBool(r("CanRemoveFromSurvivorCase")) = True) OrElse _
                Utils.IsEmpty(r("AddToSurvivorCase")) OrElse (CBool(r("AddToSurvivorCase")) = False)
            e.Cancel = Not CanEdit
        End If
    End Sub

    Private Sub gvSamplesSuperseded_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles gvSamplesSuperseded.ShowingEditor
        If (Not gvSamplesSuperseded Is Nothing) AndAlso (gvSamplesSuperseded.FocusedRowHandle >= 0) AndAlso _
           (gvSamplesSuperseded.FocusedColumn Is gcolCheckedSuperseded) Then
            Dim r As DataRow = gvSamplesSuperseded.GetDataRow(gvSamplesSuperseded.FocusedRowHandle)
            Dim CanEdit As Boolean = _
                (r Is Nothing) OrElse _
                Utils.IsEmpty(r("CanRemoveFromSurvivorCase")) OrElse (CBool(r("CanRemoveFromSurvivorCase")) = True) OrElse _
                Utils.IsEmpty(r("AddToSurvivorCase")) OrElse (CBool(r("AddToSurvivorCase")) = False)
            e.Cancel = Not CanEdit
        End If
    End Sub
#End Region

End Class

