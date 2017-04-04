var bvUrls = (function () {
    var regExp = /(http(s?):\/\/)/ig;
    var currentLang = null;

    // examples of path: '/Controller/Action' (begins from slash, ends without slash)
    var paths = {
        help: "/HelpRouter.htm",
        cbt: "/CBTRouter.htm",
        about: "/Account/About",
        home: "/Account/Home",
        systemPreferences: "/System/Preferences",
        systemPreferencesSave: "/System/PreferencesSave",
        systemPreferencesDefault: "/System/PreferencesDefault",
        systemPreferencesDoNotShowAgain: "/System/PreferencesDoNotShowAgain",
        requestReplication: "/Account/RequestReplication",
        getReplicationStatus: "/Account/GetReplicationStatus",
        getTranslation: "/Account/Translation",
        getResourceUsage: "/Account/ResourceUsage",
        getCheckTranslation: "/Account/CheckTranslation",
        timeout: "/Account/Timeout",
        incomliance: "/Account/Incomliance",
        heartbeat: "/Account/Heartbeat",
        systemCheckChanges: "/System/CheckChanges",
        systemSetValue: "/System/SetValue",
        vetCaseDetails: "/VetCase/Details",
        vetCasePicker: "/VetCase/VetCasePicker",
        vetCasePickerForOutbreak: "/VetCase/VetCasePickerForOutbreak",
        vetInvestigationReport: "/VetCase/VetInvestigationReport",
        organizationPicker: "/System/OrganizationPicker",
        setOrganization: "/System/SetSelectedOrganization",
        employeePicker: "/System/EmployeePicker",
        setEmployee: "/System/SetSelectedEmployee",
        employeeEditor: "/Employee/EmployeeEditor",
        saveEmployee: "/Employee/SaveEmployee",
        humanAntimicrobialTherapyPicker: "/HumanCase/HumanAntimicrobialTherapyPicker",
        setHumanAntimicrobialTherapy: "/HumanCase/SetHumanAntimicrobialTherapy",
        patientPicker: "/System/PatientPicker",
        reloadPatientPicker: "/System/ReloadPatientPicker",
        setSelectedPatient: "/HumanCase/SetSelectedPatient",
        setSelectedPatientAsRoot: "/HumanCase/SetSelectedPatientAsRoot",
        setDeleteLinkToRootHuman: "/HumanCase/DeleteLinkToRootHuman",
        humanContactedCasePersonPicker: "/HumanCase/HumanContactedCasePersonPicker",
        setHumanContactedCasePerson: "/HumanCase/SetHumanContactedCasePerson",
        humanCaseSamplePicker: "/LabSample/HumanCaseSamplePicker",
        setHumanSample: "/LabSample/SetHumanSample",
        vetCaseSamplePicker: "/LabSample/VetCaseSamplePicker",
        setVetSample: "/LabSample/SetVetSample",
        caseTestItemPicker: "/LabSample/CaseTestItemPicker",
        caseTestValidationItemPicker: "/LabSample/CaseTestValidationItemPicker",
        pensideTestPicker: "/Pickers/PensideTestPicker",
        vetCaseLogPicker: "/Pickers/VetCaseLogPicker",
        vaccinationPicker: "/Pickers/VaccinationPicker",
        animalPicker: "/Pickers/AnimalPicker",
        geoLocationPicker: "/System/GeoLocationPicker",
        setGeoLocation: "/System/SetGeoLocation",
        setGeoLocationFromMap: "/GeoLocation/SetFromMap",
        deleteListObject: "/System/DeleteListObject",
        tryDeleteFromDetailsGrid: "/System/_GridDelete",
        systemGridColumnsRestore: "/System/_GridColumnsRestore",
        systemGridColumnHide: "/System/_GridColumnHide",
        systemGridColumnShow: "/System/_GridColumnShow",
        systemGridColumnReorder: "/System/_GridColumnReorder",
        systemGridColumnResize: "/System/_GridColumnResize",
        systemDetails: "/System/DetailsObject",
        vsStoreInSession: "/VsSession/StoreInSession",
        vsSessionDetails: "/VsSession/Details",
        vsVectorDetails: "/Vector/Details",
        vsVectorOk: "/Vector/VectorOk",
        vsVectorCancel: "/Vector/VectorCancel",
        vsSessionPicker: "/VsSession/VsSessionPicker",
        vsSessionPickerForOutbreak: "/VsSession/VsSessionPickerForOutbreak",
        VsVectorSamplePicker: "/Vector/VectorSamplePicker",
        setVectorSample: "/Vector/SetVectorSample",
        VsVectorFieldTestPicker: "/Vector/VectorFieldTestPicker",
        VsVectorLabTestPicker: "/Vector/VectorLabTestPicker",
        VsVectorCopyPicker: "/Vector/CopyVectorPicker",
        VsSetVectorCopy: "/Vector/SetCopyVector",
        setVectorFieldTest: "/Vector/SetVectorFieldTest",
        vsSummaryDetails: "/VsSessionSummary/Details",
        vsSummaryDiagnosisPicker: "/VsSessionSummary/DiagnosisPicker",
        setSummaryDiagnosis: "/VsSessionSummary/SetDiagnosis",
        vsSummaryStore: "/VsSessionSummary/StoreInSession",
        vectorFF: "/Vector/GetFlexForm",
        storeVector: "/Vector/StoreInSession",
        vectorIsPool: "/Vector/GetIsPoolVectorType",
        humanCaseEmergencyNotificationReport: "/HumanCase/EmergencyNotificationReport",
        humanCaseEmergencyNotificationDTRAReport: "/HumanCase/EmergencyNotificationDTRAReport",
        humanCaseEmergencyNotificationTanzaniaReport: "/HumanCase/EmergencyNotificationTanzaniaReport",
        humanInvestigationReport: "/HumanCase/HumanInvestigationReport",
        testsReport: "/LaboratoryReport/TestsReport",
        humanCaseDuplicates: "/HumanCase/Duplicates",
        humanCaseDetails: "/HumanCase/Details",
        storeHumanCase: "/HumanCase/StoreCase",
        humanAggregateCaseDetails: "/HumanAggregateCase/Details",
        vetAggregateCaseDetails: "/VetAggregateCase/Details",
        vetAggregateActionDetails: "/VetAggregateAction/Details",
        humanAggregateCasePicker: "/HumanAggregateCase/HumanAggregateCasePicker",
        vetAggregateCasePicker: "/VetAggregateCase/VetAggregateCasePicker",
        vetAggregateActionPicker: "/VetAggregateAction/VetAggregateActionPicker",
        humanAggregateCaseReport: "/HumanAggregateCase/HumanAggregateCaseReport",
        vetAggregateCaseReport: "/VetAggregateCase/VetAggregateCaseReport",
        vetAggregateActionReport: "/VetAggregateAction/VetAggregateActionReport",
        storeVetCase: "/VetCase/StoreCase",
        setNewHumanCaseDiagnosis: "/HumanCase/SetNewDiagnosis",
        humanCaseDiagnosisChange: "/HumanCase/DiagnosisChange",
        humanCaseIsDiagnosisChanged: "/HumanCase/IsDiagnosisChanged",
        humanCaseDiagnosisHistory: "/HumanCase/DiagnosisHistory",
        humanCasePicker: "/HumanCase/HumanCasePicker",
        humanCasePickerForOutbreak: "/HumanCase/HumanCasePickerForOutbreak",
        humanCaseFindInPersonIdentityService: "/HumanCase/FindInPersonIdentityService",
        patientFindInPersonIdentityService: "/Person/FindInPersonIdentityService",
        outbreakDetails: "/Outbreak/Details",
        outbreakPicker: "/Outbreak/OutbreakPicker",
        setOutbreak: "/Outbreak/SetSelectedOutbreak",
        outbreakSetPrimaryCase: "/Outbreak/SetPrimaryCase",
        addCaseToOutbreak: "/Outbreak/AddCase",        
        deleteCaseToOutbreak: "/Outbreak/DeleteCase",
        outbreakNotePicker: "/Outbreak/OutbreakNotePicker",
        setOutbreakNote: "/Outbreak/SetOutbreakNote",
        outbreakReport: "/Outbreak/OutbreakReport",
        farmDetails: "/Farm/Details",
        personDetails: "/Person/Details",
        personPicker: "/Person/PersonPicker",
        setPerson: "/Person/SetSelectedPerson",
        tryDeleteFromGridAndCompare: "/System/TryDeleteFromGridAndCompare",
        laboratoryDetails: "/Laboratory/Details",
        laboratoryDetailsMyPref: "/Laboratory/DetailsMyPref",
        laboratoryCreateAliquotPicker: "/Laboratory/CreateAliquotPicker",
        laboratorySetCreateAliquot: "/Laboratory/SetCreateAliquot",
        laboratoryCreateDerivativePicker: "/Laboratory/CreateDerivativePicker",
        laboratorySetCreateDerivative: "/Laboratory/SetCreateDerivative",
        laboratoryTransferOutSamplePicker: "/Laboratory/TransferOutSamplePicker",
        laboratorySetTransferOutSample: "/Laboratory/SetTransferOutSample",
        laboratoryStartTestPicker: "/Laboratory/StartTestPicker",
        laboratorySetStartTest: "/Laboratory/SetStartTest",
        laboratorySetTestResultPicker: "/Laboratory/SetTestResultPicker",
        laboratorySetSetTestResult: "/Laboratory/SetSetTestResult",
        laboratoryValidateTestResultPicker: "/Laboratory/ValidateTestResultPicker",
        laboratorySetValidateTestResult: "/Laboratory/SetValidateTestResult",
        laboratoryAccessionInGoodConditionPicker: "/Laboratory/AccessionInGoodConditionPicker",
        laboratorySetAccessionInGoodCondition: "/Laboratory/SetAccessionInGoodCondition",
        laboratoryAccessionInPoorConditionPicker: "/Laboratory/AccessionInPoorConditionPicker",
        laboratorySetAccessionInPoorCondition: "/Laboratory/SetAccessionInPoorCondition",
        laboratoryAccessionInRejectedPicker: "/Laboratory/AccessionInRejectedPicker",
        laboratorySetAccessionInRejected: "/Laboratory/SetAccessionInRejected",
        laboratoryAmendTestResultPicker: "/Laboratory/AmendTestResultPicker",
        laboratorySetAmendTestResult: "/Laboratory/SetAmendTestResult",
        laboratoryAssignTestPicker: "/Laboratory/AssignTestPicker",
        laboratorySetAssignTest: "/Laboratory/SetAssignTest",
        laboratoryCreateSamplePicker: "/Laboratory/CreateSamplePicker",
        laboratorySetCreateSample: "/Laboratory/SetCreateSample",
        laboratoryGroupAccessionInPicker: "/Laboratory/GroupAccessionInPicker",
        laboratorySetGroupAccessionIn: "/Laboratory/SetGroupAccessionIn",
        laboratorySampleGroupAccessionInGridPicker: "/Laboratory/SampleGroupAccessionInGridPicker",
        laboratorySetGroupAccessionInGrid: "/Laboratory/SetGroupAccessionInGrid",
        laboratoryDetailsPicker: "/Laboratory/DetailsPicker",
        laboratoryGetFlexForm: "/Laboratory/GetFlexForm",
        laboratorySetDetails: "/Laboratory/SetDetails",
        laboratoryDelete: "/Laboratory/Delete",
        laboratorySampleDelete: "/Laboratory/SampleDelete",
        laboratorySampleReport: "/LaboratoryReport/SampleReport",
        laboratoryTestResultReport: "/LaboratoryReport/TestResultReport",
        laboratorySampleDestructionReport: "/LaboratoryReport/SampleDestructionReport",
        laboratoryPrintBarcode: "/LaboratoryReport/PrintBarcode",
        showTestDetailFlexibleForm: "/FlexibleForm/ShowTestDetailFlexibleForm",
        showAddFFParameter: "/FlexibleForm/ShowAddFFParameterForm",
        DeleteFFParameters: "/FlexibleForm/DeleteFFParameters",
        AddFFParameter: "/FlexibleForm/AddFFParameter",
        farmPicker: "/Farm/FarmPicker",
        humanCaseCCFlexForm: "/HumanCase/GetCCFlexForm",
        humanCaseEpiFlexForm: "/HumanCase/GetEpiFlexForm",
        vetCaseCMFlexForm: "/VetCase/GetCMFlexForm",
        vetCaseEpiFlexForm: "/VetCase/GetEpiFlexForm",
        createHerdOrFlock: "/VetCase/CreateHerdOrFlock",
        editSpeciesDetail: "/VetCase/SpeciesDetail",
        speciesClinicalSigns: "/FlexibleForm/SpeciesClinicalSigns",
        clearFF: "/FlexibleForm/ClearFFPresenter",
        copyFF: "/FlexibleForm/CopyFFPresenter",
        pasteFF: "/FlexibleForm/PasteFFPresenter",
        showFlexibleForm: "/FlexibleForm/ShowFlexibleForm",
        animalClinicalSigns: "/FlexibleForm/AnimalClinicalSigns",
        editFlexibleFormTableRow: "/FlexibleForm/EditTableRow",
        copyFlexibleFormTableRow: "/FlexibleForm/CopyTableRow",
        deleteFlexibleFormTableRow: "/FlexibleForm/DeleteTableRow",
        asCampaignDetails: "/ASCampaign/Details",
        asCampaignPicker: "/ASCampaign/ASCampaignPicker",
        setASCampaign: "/ASCampaign/SetSelectedASCampaign",
        asCampaignDiseasesPicker: "/ASCampaign/ASCampaignDiseasesPicker",
        setAsCampaignDiseases: "/ASCampaign/SetASCampaignDiseases",
        asCampaignDiseasesMoveItem: "/ASCampaign/MoveItem",
        setSelectedAsSession: "/ASCampaign/SetSelectedASSession",
        asCampaignStoreInSession: "/ASCampaign/StoreInSession",
        asSessionPicker: "/ASSession/ASSessionPicker",
        asSessionDetails: "/ASSession/Details",
        asSessionDisease: "/ASSession/ASSessionDisease",
        setAsSessionDisease: "/ASSession/SetASSessionDiseases",
        setAsSessionCase: "/ASSession/SetASSessionCases",
        asSessionDiseasesMoveItem: "/ASSession/MoveItem",
        asSessionAction: "/ASSession/ASSessionAction",
        setAsSessionAction: "/ASSession/SetASSessionAction",
        asStoreInSession: "/ASSession/StoreInSession",
        asSessionFarmDetails: "/ASSessionFarm/Details",
        asSessionFarmCopy: "/ASSessionFarm/NumberOfCopies",
        vsSessionReport: "/VsSession/VsSessionReport",
        asSessioncreateHerdOrFlock: "/ASSessionFarm/CreateHerdOrFlock",
        asSessionSpeciesDetail: "/ASSessionFarm/SpeciesDetail",
        asSessionAnimalSampleDetail: "/ASSessionFarm/AnimalSampleDetail",
        asSessionDeleteFarm: "/ASSessionFarm/DeleteFarm",
        asSessionSummaryDetail: "/ASSessionSummary/SummaryDetail",
        asSessionDeleteAnimalSample: "/ASSession/DeleteAnimalSample",
        asSessionEndEditAnimalSample: "/ASSession/EndEditAnimalSample",
        asSessionReportAsSessionTests: "/ASSession/ReportAsSessionTests",
        asSessionReportAsSampleCollectedList: "/ASSession/ReportAsSampleCollectedList",
        aggrCaseFlexFormCase: "/CommonAggregate/GetFlexFormCase",
        aggrCaseFlexFormDiagnostic: "/CommonAggregate/GetFlexFormDiagnostic",
        aggrCaseFlexFormProphylactic: "/CommonAggregate/GetFlexFormProphylactic",
        aggrCaseFlexFormSanitary: "/CommonAggregate/GetFlexFormSanitary",
        aggrSummAddSelectedAggregateCaseItems: "/AggregateSummary/AddSelectedAggregateCaseItems",
        aggrSummRemoveAllAggregateCaseItems: "/AggregateSummary/RemoveAllAggregateCaseItems",
        aggrSummSummaryFlexibleForm: "/AggregateSummary/SummaryFlexibleForm",
        aggrSummAggregateReport: "/AggregateSummary/AggregateReport",

    };

    function setLanguage() {
        var lang = document.URL.replace(regExp, "", "$1");
        lang = lang.substring(lang.indexOf("/") + 1, lang.length);
        currentLang = lang.substring(0, lang.indexOf("/"));
    }

    return {
        getLanguage: function() {
            if (!currentLang) {
                setLanguage();
            }
            return currentLang;
        },

        // examples of path: '/System/SetValue', bvUrls.paths.systemSetValue
        getByPath: function(path) {
            return '/' + bvUrls.getLanguage() + path;
        },

        buildUrl: function (url, params) {
            var ret = url;
            var bFirst = true;
            for (key in params) {
                ret = ret + (bFirst ? "?" : "&");
                ret = ret + key + "=" + params[key];
                bFirst = false;
            }
            return ret;
        },


        getHelpUrl: function (params) {
            return paths.help;
        },

        getCbtUrl: function (params) {
            return paths.cbt;
        },

        getSystemPreferencesUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.systemPreferences), params);
        },

        getSystemPreferencesSaveUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.systemPreferencesSave), params);
        },

        getSystemPreferencesDoNotShowAgainUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.systemPreferencesDoNotShowAgain), params);
        },

        getSystemPreferencesDefaultUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.systemPreferencesDefault), params);
        },

        getEditFlexibleFormTableRowUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.editFlexibleFormTableRow), params);
        },

        getCopyFlexibleFormTableRowUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.copyFlexibleFormTableRow), params);
        },

        getDeleteFlexibleFormTableRowUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.deleteFlexibleFormTableRow), params);
        },

        getAnimalClinicalSignsUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.animalClinicalSigns), params);
        },

        getShowFlexibleFormUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.showFlexibleForm), params);
        },
        
        getPasteFFUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.pasteFF), params);
        },
        
        getCopyFFUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.copyFF), params);
        },

        getClearFFUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.clearFF), params);
        },

        getSpeciesClinicalSignsUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.speciesClinicalSigns), params);
        },

        getEditSpeciesDetailUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.editSpeciesDetail), params);
        },

        getCreateHerdOrFlockUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.createHerdOrFlock), params);
        },
        
        getHumanCaseCCFlexFormUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.humanCaseCCFlexForm), params);
        },
        
        getHumanCaseEpiFlexFormUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.humanCaseEpiFlexForm), params);
        },

        getVetCaseCMFlexFormUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.vetCaseCMFlexForm), params);
        },

        getVetCaseEpiFlexFormUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.vetCaseEpiFlexForm), params);
        },
        
        getHomeUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.home), params);
        },

        getTimeoutUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.timeout), params);
        },

        getIncomlianceUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.incomliance), params);
        },

        getHeartbeatUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.heartbeat), params);
        },

        getAboutUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.about), params);
        },
        
        getRequestReplicationUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.requestReplication), params);
        },

        getGetReplicationStatusUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.getReplicationStatus), params);
        },

        getTranslationUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.getTranslation), params);
        },

        getResourceUsageUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.getResourceUsage), params);
        },

        getCheckTranslationUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.getCheckTranslation), params);
        },

        getSystemCheckChangesUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.systemCheckChanges), params);
        },

        getSystemSetValueUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.systemSetValue), params);
        },

        getVetCaseDetailsUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.vetCaseDetails), params);
        },

        getVetCasePickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.vetCasePicker), params);
        },

        getVetCasePickerForOutbreakUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.vetCasePickerForOutbreak), params);
        },

        getVetInvestigationReportUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.vetInvestigationReport), params);
        },

        getVsSessionPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.vsSessionPicker), params);
        },

        getVsSessionPickerForOutbreakUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.vsSessionPickerForOutbreak), params);
        },

        getOrganizationPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.organizationPicker), params);
        },

        getSetOrganizationUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.setOrganization), params);
        },

        getEmployeePickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.employeePicker), params);
        },

        getSetEmployeeUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.setEmployee), params);
        },

        getEmployeeEditorUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.employeeEditor), params);
        },

        getSaveEmployeeUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.saveEmployee), params);
        },

        getHumanAntimicrobialTherapyPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.humanAntimicrobialTherapyPicker), params);
        },

        getSetHumanAntimicrobialTherapyUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.setHumanAntimicrobialTherapy), params);
        },

        getPatientPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.patientPicker), params);
        },

        getPersonPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.personPicker), params);
        },

        getSetPersonUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.setPerson), params);
        },

        getReloadPatientPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.reloadPatientPicker), params);
        },

        getSetSelectedPatientUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.setSelectedPatient), params);
        },
        
        getSetSelectedPatientAsRootUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.setSelectedPatientAsRoot), params);
        },
        
        getDeleteLinkToRootHumanUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.setDeleteLinkToRootHuman), params);
        },

        getHumanContactedCasePersonPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.humanContactedCasePersonPicker), params);
        },

        getSetHumanContactedCasePersonUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.setHumanContactedCasePerson), params);
        },

        getCaseTestValidationItemPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.caseTestValidationItemPicker), params);
        },

        getHumanCaseSamplePickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.humanCaseSamplePicker), params);
        },

        getOutbreakNotePickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.outbreakNotePicker), params);
        },

        getSetHumanSampleUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.setHumanSample), params);
        },

        getSetOutbreakNoteUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.setOutbreakNote), params);
        },

        getVetCaseSamplePickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.vetCaseSamplePicker), params);
        },

        getSetVetSampleUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.setVetSample), params);
        },

        getCaseTestItemPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.caseTestItemPicker), params);
        },

        getPensideTestPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.pensideTestPicker), params);
        },

        getVetCaseLogPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.vetCaseLogPicker), params);
        },

        getVaccinationPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.vaccinationPicker), params);
        },

        getAnimalPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.animalPicker), params);
        },
        
        getGeoLocationPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.geoLocationPicker), params);
        },
        
        getSetGeoLocationUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.setGeoLocation), params);
        },
        
        getSetGeoLocationFromMapUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.setGeoLocationFromMap), params);
        },

        getDeleteListObjectUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.deleteListObject), params);
        },
        
        getTryDeleteFromDetailsGridUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.tryDeleteFromDetailsGrid), params);
        },

        getSystemGridColumnsRestoreUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.systemGridColumnsRestore), params);
        },

        getSystemGridColumnHideUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.systemGridColumnHide), params);
        },

        getSystemGridColumnShowUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.systemGridColumnShow), params);
        },

        getSystemGridColumnReorderUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.systemGridColumnReorder), params);
        },

        getSystemGridColumnResizeUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.systemGridColumnResize), params);
        },

        getVsStoreInSessionUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.vsStoreInSession), params);
        },
        
        redirectToVectorUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.vsVectorDetails), params); 
        },
        
        redirectToVsSessionUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.vsSessionDetails), params);
        },
        
        redirectToVsSessionSummaryUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.vsSummaryDetails), params);
        },
        
        getHumanCaseEmergencyNotificationReportUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.humanCaseEmergencyNotificationReport), params);
        },
        getHumanCaseEmergencyNotificationDTRAReportUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.humanCaseEmergencyNotificationDTRAReport), params);
        },
        getHumanCaseEmergencyNotificationTanzaniaReportUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.humanCaseEmergencyNotificationTanzaniaReport), params);
        },
        
        getHumanInvestigationReportUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.humanInvestigationReport), params);
        },
        
        getTestsReportUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.testsReport), params);
        }, 
        
        getHumanCaseDuplicatesUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.humanCaseDuplicates), params);
        }, 
        
        getHumanCaseDetailsUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.humanCaseDetails), params);
        },

        getHumanAggregateCaseDetailsUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.humanAggregateCaseDetails), params);
        },

        getVetAggregateCaseDetailsUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.vetAggregateCaseDetails), params);
        },

        getVetAggregateActionDetailsUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.vetAggregateActionDetails), params);
        },
        
        getHumanAggregateCasePickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.humanAggregateCasePicker), params);
        },

        getVetAggregateCasePickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.vetAggregateCasePicker), params);
        },

        getVetAggregateActionPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.vetAggregateActionPicker), params);
        },

        getHumanAggregateCaseReportUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.humanAggregateCaseReport), params);
        },

        getVetAggregateCaseReportUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.vetAggregateCaseReport), params);
        },

        getVetAggregateActionReportUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.vetAggregateActionReport), params);
        },

        getSystemDetailsUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.systemDetails), params);
        },

        getOutbreakPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.outbreakPicker), params);
        },

        getASCampaignPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.asCampaignPicker), params);
        },

        getOutbreakDetailsUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.outbreakDetails), params);
        },

        getOutbreakReportUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.outbreakReport), params);
        },

        getVsSessionReportUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.vsSessionReport), params);
        },

        getFarmDetailsUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.farmDetails), params);
        },

        getPersonDetailsUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.personDetails), params);
        },

        getHumanCasePickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.humanCasePicker), params);
        },

        getHumanCasePickerForOutbreakUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.humanCasePickerForOutbreak), params);
        },

        getSetOutbreakUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.setOutbreak), params);
        },
        
        getSetASCampaignUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.setASCampaign), params);
        },

        getAddCaseToOutbreakUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.addCaseToOutbreak), params);
        },

        getDeleteCaseToOutbreakUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.deleteCaseToOutbreak), params);
        },

        getOutbreakSetPrimaryCaseUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.outbreakSetPrimaryCase), params);
        },

        getStoreHumanCaseUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.storeHumanCase), params);
        },
          
        getStoreVetCaseUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.storeVetCase), params);
        },
          
        getSetNewHumanCaseDiagnosisUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.setNewHumanCaseDiagnosis), params);
        },
        
        getHumanCaseDiagnosisChangeUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.humanCaseDiagnosisChange), params);
        },
        
        getHumanCaseIsDiagnosisChangedUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.humanCaseIsDiagnosisChanged), params);
        },

        getHumanCaseDiagnosisHistoryUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.humanCaseDiagnosisHistory), params);
        },

        getHumanCaseFindInPersonIdentityServiceUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.humanCaseFindInPersonIdentityService), params);
        },

        getPatientFindInPersonIdentityServiceUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.patientFindInPersonIdentityService), params);
        },

        getTryDeleteFromGridAndCompareUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.tryDeleteFromGridAndCompare), params);
        },
        
        getLaboratoryDetailsUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratoryDetails), params);
        },

        getLaboratoryDetailsMyPrefUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratoryDetailsMyPref), params);
        },

        getLaboratoryCreateAliquotPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratoryCreateAliquotPicker), params);
        },

        getSetLaboratoryCreateAliquotUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratorySetCreateAliquot), params);
        },

        getLaboratoryCreateDerivativePickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratoryCreateDerivativePicker), params);
        },

        getSetLaboratoryCreateDerivativeUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratorySetCreateDerivative), params);
        },

        getLaboratoryTransferOutSamplePickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratoryTransferOutSamplePicker), params);
        },

        getSetLaboratoryTransferOutSampleUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratorySetTransferOutSample), params);
        },

        getLaboratoryStartTestPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratoryStartTestPicker), params);
        },

        getSetLaboratoryStartTestUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratorySetStartTest), params);
        },

        getLaboratorySetTestResultPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratorySetTestResultPicker), params);
        },

        getSetLaboratorySetTestResultUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratorySetSetTestResult), params);
        },

        getLaboratoryValidateTestResultPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratoryValidateTestResultPicker), params);
        },

        getSetLaboratoryValidateTestResultUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratorySetValidateTestResult), params);
        },

        getLaboratoryAccessionInGoodConditionPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratoryAccessionInGoodConditionPicker), params);
        },

        getSetLaboratoryAccessionInGoodConditionUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratorySetAccessionInGoodCondition), params);
        },

        getLaboratoryAccessionInPoorConditionPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratoryAccessionInPoorConditionPicker), params);
        },

        getSetLaboratoryAccessionInPoorConditionUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratorySetAccessionInPoorCondition), params);
        },

        getLaboratoryAccessionInRejectedPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratoryAccessionInRejectedPicker), params);
        },

        getSetLaboratoryAccessionInRejectedUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratorySetAccessionInRejected), params);
        },

        getLaboratoryAmendTestResultPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratoryAmendTestResultPicker), params);
        },

        getSetLaboratoryAmendTestResultUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratorySetAmendTestResult), params);
        },

        getLaboratoryAssignTestPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratoryAssignTestPicker), params);
        },

        getSetLaboratoryAssignTestUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratorySetAssignTest), params);
        },

        getLaboratoryCreateSamplePickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratoryCreateSamplePicker), params);
        },

        getSetLaboratoryCreateSampleUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratorySetCreateSample), params);
        },

        getLaboratoryGroupAccessionInPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratoryGroupAccessionInPicker), params);
        },

        getSetLaboratoryGroupAccessionInUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratorySetGroupAccessionIn), params);
        },

        getSampleGroupAccessionInGridPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratorySampleGroupAccessionInGridPicker), params);
        },

        getSetGroupAccessionInGridUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratorySetGroupAccessionInGrid), params);
        },

        getLaboratoryDetailsPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratoryDetailsPicker), params);
        },

        getLaboratoryGetFlexFormUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratoryGetFlexForm), params);
        },

        getSetLaboratoryDetailsUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratorySetDetails), params);
        },

        getLaboratoryDeleteUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratoryDelete), params);
        },

        getLaboratorySampleDeleteUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratorySampleDelete), params);
        },

        getLaboratorySampleReportUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratorySampleReport), params);
        },

        getLaboratoryTestResultReportUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratoryTestResultReport), params);
        },

        getLaboratorySampleDestructionReportUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratorySampleDestructionReport), params);
        },

        getLaboratoryPrintBarcodeUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.laboratoryPrintBarcode), params);
        },



        getShowTestDetailFlexibleFormUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.showTestDetailFlexibleForm), params);
        },
        
        getVsVectorOkUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.vsVectorOk), params);
        },
        
        getVsVectorCancelUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.vsVectorCancel), params);
        },
        
        getVsSessionDetailsUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.vsSessionDetails), params);
        },
        
        getVectorSamplePickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.VsVectorSamplePicker), params);
        },
        
        getSetVectorSampleUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.setVectorSample), params);
        },
        
        getVectorFieldTestPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.VsVectorFieldTestPicker), params);
        },
        
        getVectorLabTestPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.VsVectorLabTestPicker), params);
        },
        
        getVectorCopyPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.VsVectorCopyPicker), params);
        },
        
        getSetVectorCopyUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.VsSetVectorCopy), params);
        },
        
        getSetVectorFieldTestUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.setVectorFieldTest), params);
        },
        
        getVsSummaryDiagnosisPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.vsSummaryDiagnosisPicker), params);
        },

        getSetSummaryDiagnosisUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.setSummaryDiagnosis), params);
        },
        
        getFarmPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.farmPicker), params);
        },
        
        getVectorFFUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.vectorFF), params);
        },
        
        getStoreVectorUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.storeVector), params);
        },
        
        getVectorIsPoolUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.vectorIsPool), params);
        },
        
        getSetVsVectorUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.setVsVector), params);
        },        
            
        getVsSummaryStoreUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.vsSummaryStore), params);
        },

        getAsCampaignDetailsUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.asCampaignDetails), params);
        },

        getAsCampaignDiseasesPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.asCampaignDiseasesPicker), params);
        },

        getSetAsCampaignDiseasesUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.setAsCampaignDiseases), params);
        },

        getAsCampaignDiseasesMoveItemUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.asCampaignDiseasesMoveItem), params);
        },

        getAsSessionPickerUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.asSessionPicker), params);
        },

        getAsSessionDetailsUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.asSessionDetails), params);
        },

        getSetSelectedAsSessionUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.setSelectedAsSession), params);
        },

        getAsCampaignStoreInSessionUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.asCampaignStoreInSession), params);
        },

        getAsSessionDiseaseUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.asSessionDisease), params);
        },

        getSetAsSessionDiseasesUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.setAsSessionDisease), params);
        },

        getSetAsSessionCasesUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.setAsSessionCase), params);
        },

        getAsSessionDiseasesMoveItemUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.asSessionDiseasesMoveItem), params);
        },

        getAsSessionActionUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.asSessionAction), params);
        },

        getSetAsSessionActionUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.setAsSessionAction), params);
        },

        getAsStoreInSessionUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.asStoreInSession), params);
        },

        getAsSessionFarmUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.asSessionFarmDetails), params);
        },

        getAsSessionCopyFarmUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.asSessionFarmCopy), params);
        },

        getAsSessionCreateHerdOrFlockUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.asSessioncreateHerdOrFlock), params);
        },

        getAsSessionSpeciesDetailUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.asSessionSpeciesDetail), params);
        },

        getAsSessionAnimalSampleDetailUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.asSessionAnimalSampleDetail), params);
        },
        
        getAsSessionSummaryDetailUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.asSessionSummaryDetail), params);
        },

        getAsSessionDeleteFarmUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.asSessionDeleteFarm), params);
        },

        getAsSessionDeleteAnimalSampleUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.asSessionDeleteAnimalSample), params);
        },

        getAsSessionEndEditAnimalSampleUrl: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.asSessionEndEditAnimalSample), params);
        },

        getAsSessionReportAsSessionTests: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.asSessionReportAsSessionTests), params);
        },

        getAsSessionReportAsSampleCollectedList: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.asSessionReportAsSampleCollectedList), params);
        },
        


        getAggrCaseFlexFormCase: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.aggrCaseFlexFormCase), params);
        },

        getAggrCaseFlexFormDiagnostic: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.aggrCaseFlexFormDiagnostic), params);
        },

        getAggrCaseFlexFormProphylactic: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.aggrCaseFlexFormProphylactic), params);
        },

        getAggrCaseFlexFormSanitary: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.aggrCaseFlexFormSanitary), params);
        },

        getAggrSummAddSelectedAggregateCaseItems: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.aggrSummAddSelectedAggregateCaseItems), params);
        },

        getAggrSummRemoveAllAggregateCaseItems: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.aggrSummRemoveAllAggregateCaseItems), params);
        },

        getAggrSummSummaryFlexibleForm: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.aggrSummSummaryFlexibleForm), params);
        },

        getAggrSummAggregateReport: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.aggrSummAggregateReport), params);
        },

        getShowAddFFParameter: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.showAddFFParameter), params);
        },
        
        getDeleteFFParameters: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.DeleteFFParameters), params);
        },
        
        getAddFFParameter: function (params) {
            return bvUrls.buildUrl(bvUrls.getByPath(paths.AddFFParameter), params);
        },
    };
})();