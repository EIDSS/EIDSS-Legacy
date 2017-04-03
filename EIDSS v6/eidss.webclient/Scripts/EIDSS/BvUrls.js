var bvUrls = (function () {
    var regExp = /(http(s?):\/\/)/ig;
    var currentLang = null;

    // examples of path: '/Controller/Action' (begins from slash, ends without slash)
    var paths = {
        about: "/Account/About",
        home: "/Account/Home",
        requestReplication: "/Account/RequestReplication",
        getReplicationStatus: "/Account/GetReplicationStatus",
        timeout: "/Account/Timeout",
        heartbeat: "/Account/Heartbeat",
        help: "/HelpRouter.htm",
        systemSetValue: "/System/SetValue",
        vetCaseDetails: "/VetCase/Details",
        vetCasePicker: "/VetCase/VetCasePicker",
        vetCasePickerForOutbreak: "/VetCase/VetCasePickerForOutbreak",
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
        geoLocationFullPicker: "/System/GeoLocationFullPicker",
        setGeoLocation: "/System/SetGeoLocation",
        setGeoLocationFromMap: "/GeoLocation/SetFromMap",
        deleteListObject: "/System/DeleteListObject",
        tryDeleteFromDetailsGrid: "/System/_GridDelete",
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
        humanInvestigationReport: "/HumanCase/HumanInvestigationReport",
        testsReport: "/LaboratoryReport/TestsReport",
        humanCaseDuplicates: "/HumanCase/Duplicates",
        humanCaseDetails: "/HumanCase/Details",
        storeHumanCase: "/HumanCase/StoreCase",
        storeVetCase: "/VetCase/StoreCase",
        setNewHumanCaseDiagnosis: "/HumanCase/SetNewDiagnosis",
        humanCaseDiagnosisChange: "/HumanCase/DiagnosisChange",
        humanCaseIsDiagnosisChanged: "/HumanCase/IsDiagnosisChanged",
        humanCaseDiagnosisHistory: "/HumanCase/DiagnosisHistory",
        humanCasePicker: "/HumanCase/HumanCasePicker",
        humanCasePickerForOutbreak: "/HumanCase/HumanCasePickerForOutbreak",
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

        aggrCaseFlexFormCase: "/CommonAggregate/GetFlexFormCase",
        aggrCaseFlexFormDiagnostic: "/CommonAggregate/GetFlexFormDiagnostic",
        aggrCaseFlexFormProphylactic: "/CommonAggregate/GetFlexFormProphylactic",
        aggrCaseFlexFormSanitary: "/CommonAggregate/GetFlexFormSanitary",

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
        
        getEditFlexibleFormTableRowUrl: function () {
            return bvUrls.getByPath(paths.editFlexibleFormTableRow);
        },

        getCopyFlexibleFormTableRowUrl: function () {
            return bvUrls.getByPath(paths.copyFlexibleFormTableRow);
        },

        getDeleteFlexibleFormTableRowUrl: function () {
            return bvUrls.getByPath(paths.deleteFlexibleFormTableRow);
        },

        getAnimalClinicalSignsUrl: function () {
            return bvUrls.getByPath(paths.animalClinicalSigns);
        },

        getShowFlexibleFormUrl: function () {
            return bvUrls.getByPath(paths.showFlexibleForm);
        },
        
        getPasteFFUrl: function () {
            return bvUrls.getByPath(paths.pasteFF);
        },
        
        getCopyFFUrl: function () {
            return bvUrls.getByPath(paths.copyFF);
        },

        getClearFFUrl: function () {
            return bvUrls.getByPath(paths.clearFF);
        },

        getSpeciesClinicalSignsUrl: function () {
            return bvUrls.getByPath(paths.speciesClinicalSigns);
        },

        getEditSpeciesDetailUrl: function () {
            return bvUrls.getByPath(paths.editSpeciesDetail);
        },

        getCreateHerdOrFlockUrl: function () {
            return bvUrls.getByPath(paths.createHerdOrFlock);
        },
        
        getHumanCaseCCFlexFormUrl: function () {
            return bvUrls.getByPath(paths.humanCaseCCFlexForm);
        },
        
        getHumanCaseEpiFlexFormUrl: function () {
            return bvUrls.getByPath(paths.humanCaseEpiFlexForm);
        },

        getVetCaseCMFlexFormUrl: function () {
            return bvUrls.getByPath(paths.vetCaseCMFlexForm);
        },

        getVetCaseEpiFlexFormUrl: function () {
            return bvUrls.getByPath(paths.vetCaseEpiFlexForm);
        },
        
        getHomeUrl: function () {
            return bvUrls.getByPath(paths.home);
        },

        getTimeoutUrl: function () {
            return bvUrls.getByPath(paths.timeout);
        },

        getHeartbeatUrl: function () {
            return bvUrls.getByPath(paths.heartbeat);
        },

        getAboutUrl: function () {
            return bvUrls.getByPath(paths.about);
        },
        
        getRequestReplicationUrl: function () {
            return bvUrls.getByPath(paths.requestReplication);
        },

        getGetReplicationStatusUrl: function () {
            return bvUrls.getByPath(paths.getReplicationStatus);
        },

        getHelpUrl: function () {
            //return bvUrls.getByPath(paths.help);
            return paths.help;
        },

        getSystemSetValueUrl: function() {
            return bvUrls.getByPath(paths.systemSetValue);
        },

        getVetCaseDetailsUrl: function() {
            return bvUrls.getByPath(paths.vetCaseDetails);
        },

        getVetCasePickerUrl: function () {
            return bvUrls.getByPath(paths.vetCasePicker);
        },

        getVetCasePickerForOutbreakUrl: function () {
            return bvUrls.getByPath(paths.vetCasePickerForOutbreak);
        },


        getVsSessionPickerUrl: function () {
            return bvUrls.getByPath(paths.vsSessionPicker);
        },

        getVsSessionPickerForOutbreakUrl: function () {
            return bvUrls.getByPath(paths.vsSessionPickerForOutbreak);
        },

        getOrganizationPickerUrl: function () {
            return bvUrls.getByPath(paths.organizationPicker);
        },

        getSetOrganizationUrl: function() {
            return bvUrls.getByPath(paths.setOrganization);
        },

        getEmployeePickerUrl: function() {
            return bvUrls.getByPath(paths.employeePicker);
        },

        getSetEmployeeUrl: function() {
            return bvUrls.getByPath(paths.setEmployee);
        },

        getEmployeeEditorUrl: function () {
            return bvUrls.getByPath(paths.employeeEditor);
        },

        getSaveEmployeeUrl: function () {
            return bvUrls.getByPath(paths.saveEmployee);
        },

        getHumanAntimicrobialTherapyPickerUrl: function () {
            return bvUrls.getByPath(paths.humanAntimicrobialTherapyPicker);
        },

        getSetHumanAntimicrobialTherapyUrl: function () {
            return bvUrls.getByPath(paths.setHumanAntimicrobialTherapy);
        },

        getPatientPickerUrl: function () {
            return bvUrls.getByPath(paths.patientPicker);
        },

        getPersonPickerUrl: function () {
            return bvUrls.getByPath(paths.personPicker);
        },

        getSetPersonUrl: function () {
            return bvUrls.getByPath(paths.setPerson);
        },

        getReloadPatientPickerUrl: function () {
            return bvUrls.getByPath(paths.reloadPatientPicker);
        },

        getSetSelectedPatientUrl: function () {
            return bvUrls.getByPath(paths.setSelectedPatient);
        },
        
        getSetSelectedPatientAsRootUrl: function () {
            return bvUrls.getByPath(paths.setSelectedPatientAsRoot);
        },
        
        getDeleteLinkToRootHumanUrl: function () {
            return bvUrls.getByPath(paths.setDeleteLinkToRootHuman);
        },

        getHumanContactedCasePersonPickerUrl: function () {
            return bvUrls.getByPath(paths.humanContactedCasePersonPicker);
        },

        getSetHumanContactedCasePersonUrl: function () {
            return bvUrls.getByPath(paths.setHumanContactedCasePerson);
        },

        getCaseTestValidationItemPickerUrl: function () {
            return bvUrls.getByPath(paths.caseTestValidationItemPicker);
        },

        getHumanCaseSamplePickerUrl: function () {
            return bvUrls.getByPath(paths.humanCaseSamplePicker);
        },

        getOutbreakNotePickerUrl: function () {
            return bvUrls.getByPath(paths.outbreakNotePicker);
        },

        getSetHumanSampleUrl: function () {
            return bvUrls.getByPath(paths.setHumanSample);
        },

        getSetOutbreakNoteUrl: function () {
            return bvUrls.getByPath(paths.setOutbreakNote);
        },

        getVetCaseSamplePickerUrl: function () {
            return bvUrls.getByPath(paths.vetCaseSamplePicker);
        },

        getSetVetSampleUrl: function () {
            return bvUrls.getByPath(paths.setVetSample);
        },

        getCaseTestItemPickerUrl: function () {
            return bvUrls.getByPath(paths.caseTestItemPicker);
        },

        getPensideTestPickerUrl: function () {
            return bvUrls.getByPath(paths.pensideTestPicker);
        },

        getVetCaseLogPickerUrl: function () {
            return bvUrls.getByPath(paths.vetCaseLogPicker);
        },

        getVaccinationPickerUrl: function () {
            return bvUrls.getByPath(paths.vaccinationPicker);
        },

        getAnimalPickerUrl: function () {
            return bvUrls.getByPath(paths.animalPicker);
        },
        
        getGeoLocationPickerUrl: function () {
            return bvUrls.getByPath(paths.geoLocationPicker);
        },
        
        getGeoLocationFullPickerUrl: function () {
            return bvUrls.getByPath(paths.geoLocationFullPicker);
        },

        getSetGeoLocationUrl: function () {
            return bvUrls.getByPath(paths.setGeoLocation);
        },
        
        getSetGeoLocationFromMapUrl: function () {
            return bvUrls.getByPath(paths.setGeoLocationFromMap);
        },

        getDeleteListObjectUrl: function () {
            return bvUrls.getByPath(paths.deleteListObject);
        },
        
        getTryDeleteFromDetailsGridUrl: function () {
            return bvUrls.getByPath(paths.tryDeleteFromDetailsGrid);
        },
        
        getVsStoreInSessionUrl: function () {
            return bvUrls.getByPath(paths.vsStoreInSession);
        },
        
        redirectToVectorUrl: function () {
            return bvUrls.getByPath(paths.vsVectorDetails); 
        },
        
        redirectToVsSessionUrl: function () {
            return bvUrls.getByPath(paths.vsSessionDetails);
        },
        
        redirectToVsSessionSummaryUrl: function () {
            return bvUrls.getByPath(paths.vsSummaryDetails);
        },
        
        getHumanCaseEmergencyNotificationReportUrl: function() {
            return bvUrls.getByPath(paths.humanCaseEmergencyNotificationReport);
        },
        
        getHumanInvestigationReportUrl: function () {
            return bvUrls.getByPath(paths.humanInvestigationReport);
        },
        
        getTestsReportUrl: function () {
            return bvUrls.getByPath(paths.testsReport);
        }, 
        
        getHumanCaseDuplicatesUrl: function () {
            return bvUrls.getByPath(paths.humanCaseDuplicates);
        }, 
        
        getHumanCaseDetailsUrl: function () {
            return bvUrls.getByPath(paths.humanCaseDetails);
        },
        
        getSystemDetailsUrl: function () {
            return bvUrls.getByPath(paths.systemDetails);
        },

        getOutbreakPickerUrl: function () {
            return bvUrls.getByPath(paths.outbreakPicker);
        },

        getASCampaignPickerUrl: function () {
            return bvUrls.getByPath(paths.asCampaignPicker);
        },

        getOutbreakDetailsUrl: function () {
            return bvUrls.getByPath(paths.outbreakDetails);
        },

        getOutbreakReportUrl: function () {
            return bvUrls.getByPath(paths.outbreakReport);
        },

        getVsSessionReportUrl: function () {
            return bvUrls.getByPath(paths.vsSessionReport);
        },

        getFarmDetailsUrl: function () {
            return bvUrls.getByPath(paths.farmDetails);
        },

        getHumanCasePickerUrl: function () {
            return bvUrls.getByPath(paths.humanCasePicker);
        },

        getHumanCasePickerForOutbreakUrl: function () {
            return bvUrls.getByPath(paths.humanCasePickerForOutbreak);
        },

        getSetOutbreakUrl: function () {
            return bvUrls.getByPath(paths.setOutbreak);
        },
        
        getSetASCampaignUrl: function () {
            return bvUrls.getByPath(paths.setASCampaign);
        },

        getAddCaseToOutbreakUrl: function () {
            return bvUrls.getByPath(paths.addCaseToOutbreak);
        },

        getDeleteCaseToOutbreakUrl: function () {
            return bvUrls.getByPath(paths.deleteCaseToOutbreak);
        },

        getOutbreakSetPrimaryCaseUrl: function () {
            return bvUrls.getByPath(paths.outbreakSetPrimaryCase);
        },

        getStoreHumanCaseUrl: function () {
            return bvUrls.getByPath(paths.storeHumanCase);
        },
          
        getStoreVetCaseUrl: function () {
            return bvUrls.getByPath(paths.storeVetCase);
        },
          
        getSetNewHumanCaseDiagnosisUrl: function () {
            return bvUrls.getByPath(paths.setNewHumanCaseDiagnosis);
        },
        
        getHumanCaseDiagnosisChangeUrl: function () {
            return bvUrls.getByPath(paths.humanCaseDiagnosisChange);
        },
        
        getHumanCaseIsDiagnosisChangedUrl: function () {
            return bvUrls.getByPath(paths.humanCaseIsDiagnosisChanged);
        },

        getHumanCaseDiagnosisHistoryUrl: function () {
            return bvUrls.getByPath(paths.humanCaseDiagnosisHistory);
        },

        getTryDeleteFromGridAndCompareUrl: function () {
            return bvUrls.getByPath(paths.tryDeleteFromGridAndCompare);
        },
        
        getLaboratoryDetailsUrl: function () {
            return bvUrls.getByPath(paths.laboratoryDetails);
        },

        getLaboratoryDetailsMyPrefUrl: function () {
            return bvUrls.getByPath(paths.laboratoryDetailsMyPref);
        },

        getLaboratoryCreateAliquotPickerUrl: function () {
            return bvUrls.getByPath(paths.laboratoryCreateAliquotPicker);
        },

        getSetLaboratoryCreateAliquotUrl: function () {
            return bvUrls.getByPath(paths.laboratorySetCreateAliquot);
        },

        getLaboratoryCreateDerivativePickerUrl: function () {
            return bvUrls.getByPath(paths.laboratoryCreateDerivativePicker);
        },

        getSetLaboratoryCreateDerivativeUrl: function () {
            return bvUrls.getByPath(paths.laboratorySetCreateDerivative);
        },

        getLaboratoryTransferOutSamplePickerUrl: function () {
            return bvUrls.getByPath(paths.laboratoryTransferOutSamplePicker);
        },

        getSetLaboratoryTransferOutSampleUrl: function () {
            return bvUrls.getByPath(paths.laboratorySetTransferOutSample);
        },

        getLaboratoryAccessionInPoorConditionPickerUrl: function () {
            return bvUrls.getByPath(paths.laboratoryAccessionInPoorConditionPicker);
        },

        getSetLaboratoryAccessionInPoorConditionUrl: function () {
            return bvUrls.getByPath(paths.laboratorySetAccessionInPoorCondition);
        },

        getLaboratoryAccessionInRejectedPickerUrl: function () {
            return bvUrls.getByPath(paths.laboratoryAccessionInRejectedPicker);
        },

        getSetLaboratoryAccessionInRejectedUrl: function () {
            return bvUrls.getByPath(paths.laboratorySetAccessionInRejected);
        },

        getLaboratoryAmendTestResultPickerUrl: function () {
            return bvUrls.getByPath(paths.laboratoryAmendTestResultPicker);
        },

        getSetLaboratoryAmendTestResultUrl: function () {
            return bvUrls.getByPath(paths.laboratorySetAmendTestResult);
        },

        getLaboratoryAssignTestPickerUrl: function () {
            return bvUrls.getByPath(paths.laboratoryAssignTestPicker);
        },

        getSetLaboratoryAssignTestUrl: function () {
            return bvUrls.getByPath(paths.laboratorySetAssignTest);
        },

        getLaboratoryCreateSamplePickerUrl: function () {
            return bvUrls.getByPath(paths.laboratoryCreateSamplePicker);
        },

        getSetLaboratoryCreateSampleUrl: function () {
            return bvUrls.getByPath(paths.laboratorySetCreateSample);
        },

        getLaboratoryGroupAccessionInPickerUrl: function () {
            return bvUrls.getByPath(paths.laboratoryGroupAccessionInPicker);
        },

        getSetLaboratoryGroupAccessionInUrl: function () {
            return bvUrls.getByPath(paths.laboratorySetGroupAccessionIn);
        },

        getLaboratoryDetailsPickerUrl: function () {
            return bvUrls.getByPath(paths.laboratoryDetailsPicker);
        },

        getLaboratoryGetFlexFormUrl: function () {
            return bvUrls.getByPath(paths.laboratoryGetFlexForm);
        },

        getSetLaboratoryDetailsUrl: function () {
            return bvUrls.getByPath(paths.laboratorySetDetails);
        },

        getLaboratoryDeleteUrl: function () {
            return bvUrls.getByPath(paths.laboratoryDelete);
        },

        getLaboratorySampleDeleteUrl: function () {
            return bvUrls.getByPath(paths.laboratorySampleDelete);
        },

        getLaboratorySampleReportUrl: function () {
            return bvUrls.getByPath(paths.laboratorySampleReport);
        },

        getLaboratoryTestResultReportUrl: function () {
            return bvUrls.getByPath(paths.laboratoryTestResultReport);
        },

        getLaboratorySampleDestructionReportUrl: function () {
            return bvUrls.getByPath(paths.laboratorySampleDestructionReport);
        },

        getLaboratoryPrintBarcodeUrl: function () {
            return bvUrls.getByPath(paths.laboratoryPrintBarcode);
        },



        getShowTestDetailFlexibleFormUrl: function () {
            return bvUrls.getByPath(paths.showTestDetailFlexibleForm);
        },
        
        getVsVectorOkUrl: function () {
            return bvUrls.getByPath(paths.vsVectorOk);
        },
        
        getVsVectorCancelUrl: function () {
            return bvUrls.getByPath(paths.vsVectorCancel);
        },
        
        getVsSessionDetailsUrl: function () {
            return bvUrls.getByPath(paths.vsSessionDetails);
        },
        
        getVectorSamplePickerUrl: function () {
            return bvUrls.getByPath(paths.VsVectorSamplePicker);
        },
        
        getSetVectorSampleUrl: function () {
            return bvUrls.getByPath(paths.setVectorSample);
        },
        
        getVectorFieldTestPickerUrl: function () {
            return bvUrls.getByPath(paths.VsVectorFieldTestPicker);
        },
        
        getVectorLabTestPickerUrl: function () {
            return bvUrls.getByPath(paths.VsVectorLabTestPicker);
        },
        
        getVectorCopyPickerUrl: function () {
            return bvUrls.getByPath(paths.VsVectorCopyPicker);
        },
        
        getSetVectorCopyUrl: function () {
            return bvUrls.getByPath(paths.VsSetVectorCopy);
        },
        
        getSetVectorFieldTestUrl: function () {
            return bvUrls.getByPath(paths.setVectorFieldTest);
        },
        
        getVsSummaryDiagnosisPickerUrl: function () {
            return bvUrls.getByPath(paths.vsSummaryDiagnosisPicker);
        },

        getSetSummaryDiagnosisUrl: function () {
            return bvUrls.getByPath(paths.setSummaryDiagnosis);
        },
        
        getFarmPickerUrl: function () {
            return bvUrls.getByPath(paths.farmPicker);
        },
        
        getVectorFFUrl: function () {
            return bvUrls.getByPath(paths.vectorFF);
        },
        
        getStoreVectorUrl: function () {
            return bvUrls.getByPath(paths.storeVector);
        },
        
        getVectorIsPoolUrl: function () {
            return bvUrls.getByPath(paths.vectorIsPool);
        },
        
        getSetVsVectorUrl: function () {
            return bvUrls.getByPath(paths.setVsVector);
        },        
            
        getVsSummaryStoreUrl: function () {
            return bvUrls.getByPath(paths.vsSummaryStore);
        },

        getAsCampaignDetailsUrl: function () {
            return bvUrls.getByPath(paths.asCampaignDetails);
        },

        getAsCampaignDiseasesPickerUrl: function () {
            return bvUrls.getByPath(paths.asCampaignDiseasesPicker);
        },

        getSetAsCampaignDiseasesUrl: function () {
            return bvUrls.getByPath(paths.setAsCampaignDiseases);
        },

        getAsCampaignDiseasesMoveItemUrl: function () {
            return bvUrls.getByPath(paths.asCampaignDiseasesMoveItem);
        },

        getAsSessionPickerUrl: function () {
            return bvUrls.getByPath(paths.asSessionPicker);
        },

        getAsSessionDetailsUrl: function () {
            return bvUrls.getByPath(paths.asSessionDetails);
        },

        getSetSelectedAsSessionUrl: function () {
            return bvUrls.getByPath(paths.setSelectedAsSession);
        },

        getAsCampaignStoreInSessionUrl: function () {
            return bvUrls.getByPath(paths.asCampaignStoreInSession);
        },

        getAsSessionDiseaseUrl: function () {
            return bvUrls.getByPath(paths.asSessionDisease);
        },

        getSetAsSessionDiseasesUrl: function () {
            return bvUrls.getByPath(paths.setAsSessionDisease);
        },

        getSetAsSessionCasesUrl: function () {
            return bvUrls.getByPath(paths.setAsSessionCase);
        },

        getAsSessionDiseasesMoveItemUrl: function () {
            return bvUrls.getByPath(paths.asSessionDiseasesMoveItem);
        },

        getAsSessionActionUrl: function () {
            return bvUrls.getByPath(paths.asSessionAction);
        },

        getSetAsSessionActionUrl: function () {
            return bvUrls.getByPath(paths.setAsSessionAction);
        },

        getAsStoreInSessionUrl: function () {
            return bvUrls.getByPath(paths.asStoreInSession);
        },

        getAsSessionFarmUrl: function () {
            return bvUrls.getByPath(paths.asSessionFarmDetails);
        },

        getAsSessionCopyFarmUrl: function () {
            return bvUrls.getByPath(paths.asSessionFarmCopy);
        },

        getAsSessionCreateHerdOrFlockUrl: function () {
            return bvUrls.getByPath(paths.asSessioncreateHerdOrFlock);
        },

        getAsSessionSpeciesDetailUrl: function () {
            return bvUrls.getByPath(paths.asSessionSpeciesDetail);
        },

        getAsSessionAnimalSampleDetailUrl: function () {
            return bvUrls.getByPath(paths.asSessionAnimalSampleDetail);
        },
        
        getAsSessionSummaryDetailUrl: function () {
            return bvUrls.getByPath(paths.asSessionSummaryDetail);
        },

        getAsSessionDeleteFarmUrl: function () {
            return bvUrls.getByPath(paths.asSessionDeleteFarm);
        },

        getAsSessionDeleteAnimalSampleUrl: function () {
            return bvUrls.getByPath(paths.asSessionDeleteAnimalSample);
        },


        getAggrCaseFlexFormCase: function () {
            return bvUrls.getByPath(paths.aggrCaseFlexFormCase);
        },

        getAggrCaseFlexFormDiagnostic: function () {
            return bvUrls.getByPath(paths.aggrCaseFlexFormDiagnostic);
        },

        getAggrCaseFlexFormProphylactic: function () {
            return bvUrls.getByPath(paths.aggrCaseFlexFormProphylactic);
        },

        getAggrCaseFlexFormSanitary: function () {
            return bvUrls.getByPath(paths.aggrCaseFlexFormSanitary);
        },

        getShowAddFFParameter: function () {
            return bvUrls.getByPath(paths.showAddFFParameter);
        },
        
        getDeleteFFParameters: function () {
            return bvUrls.getByPath(paths.DeleteFFParameters);
        },
        
        getAddFFParameter: function () {
            return bvUrls.getByPath(paths.AddFFParameter);
        },
    };
})();