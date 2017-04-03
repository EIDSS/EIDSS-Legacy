var humanCase = {
    fieldsForDuplicateSearch: {
        'strCaseID': 'String_strCaseID',
        'strLocalIdentifier': 'String_strLocalIdentifier',
        'strLastName': 'String_strLastName',
        'strFirstName': 'String_strFirstName',
        'strSecondName': 'String_strSecondName',
        'intPatientAge': 'Int_intPatientAge',
        'HumanAgeType': 'Lookup_idfsHumanAgeType',
        'TentativeDiagnosis': 'Lookup_idfsTentativeDiagnosis',
        'FinalDiagnosis': 'Lookup_idfsFinalDiagnosis'
    },

    isFinalDiagnosisRevert: false,
    hasChangeDiagnosisReason: false,
    intWidth: 1024,

    onENReportClick: function () {
        detailPage.onShowReportClick(humanCase.showENReport);
    },

    showENReport: function () {
        var caseId = $("#idfCase").val();
        var url = bvUrls.getHumanCaseEmergencyNotificationReportUrl() + "?id=" + caseId;
        detailPage.openReport(url);
    },

    onHIReportClick: function () {
        detailPage.onShowReportClick(humanCase.showHIReport);
    },

    showHIReport: function () {
        var caseId = $("#idfCase").val();
        var epiId = $("#EpiId").val();
        var csId = $("#CsId").val();
        var diagnosisId = $("#HumanCase_" + caseId + "_idfsDiagnosis").val();
        if (!diagnosisId) {
            diagnosisId = 0;
        }
        var url = bvUrls.getHumanInvestigationReportUrl() + "?caseId=" + caseId + "&epiId=" + epiId + "&csId=" + csId + "&diagnosisId=" + diagnosisId;
        detailPage.openReport(url);
    },

    onTestsReportClick: function () {
        detailPage.onShowReportClick(humanCase.showTestsReport);
    },

    showTestsReport: function () {
        var caseId = $("#idfCase").val();
        var url = bvUrls.getTestsReportUrl() + "?id=" + caseId + "&isHuman=true";
        detailPage.openReport(url);
    },
    
    getDuplicatesFilter: function () {
        var result = {};
        var fieldsForSearch = humanCase.fieldsForDuplicateSearch;
        for (key in fieldsForSearch) {
            var val = $("input[name$='" + key + "']");
            if (val && val.val()) {
                result[fieldsForSearch[key]] = escape(val.val());
            }
        }
        return result;
    },

    onSearchForDuplicatesClick: function () {
        var url = bvUrls.getHumanCaseDuplicatesUrl();
        var title = EIDSS.BvMessages['titleDuplicates'];
        bvPopup.showDefault(url, title, 690, 600, false);
    },

    viewFromDuplicates: function () {
        var id = bvGrid.getSelectedItemId("Grid");
        if (id) {
            bvPopup.closeDefaultPopup();
            var url = bvUrls.getHumanCaseDetailsUrl() + '?id=' + id;
            OpenPopup(url, ' ');
        }
    },

    onTabSelect: function (e, itemId, tabStripName) {
        var activeTabContentSelector = tabStripFacade.getActiveTabContentSelector(tabStripName);
        var eventArgs = tabStripFacade.getOnSelectEventArgs(e);
        var slectedTabIndex = eventArgs.slectedTabIndex;

        // this is fix of the bug # 10148
        if (tabStripName == "InvestigationTabStrip") {
            setTimeout(function () {
                $(".k-ie9 .page").css("display", "none");
                $(".k-ie9 .page").css("display", "block");
                
                /*if (humanCase.intWidth == 1024) {
                    humanCase.intWidth = 1025;
                } else {
                    humanCase.intWidth = 1024;
                }
                $(".k-ie9 .page").css("max-width", humanCase.intWidth.toString() + "px");
                $(".k-ie9 .page").css("width", humanCase.intWidth.toString() + "px");*/

                /*$(".k-ie9 .page").css("max-width", "1025px");
                $(".k-ie9 .page").css("width", "1025px");
                setTimeout(function () {
                    $(".k-ie9 .page").css("max-width", "1024px");
                    $(".k-ie9 .page").css("width", "1024px");
                }, 1);*/
            }, 1);
        }

        if ($(activeTabContentSelector + " #CaseClassificationFlexForm").length == 1 || $(activeTabContentSelector + " #EpiLinksFlexForm").length == 1) {
            var contentData = $("form").serialize(true);
            var postUrl = bvUrls.getStoreHumanCaseUrl();
            var selectedTabIndexNew = slectedTabIndex;
            if (tabStripName != "InvestigationTabStrip" && $("#InvestigationTabStrip-4").hasClass("k-state-active")) {
                selectedTabIndexNew = 3;
            }
            if (tabStripName != "InvestigationTabStrip" && $("#InvestigationTabStrip-5").hasClass("k-state-active")) {
                selectedTabIndexNew = 4;
            }

            var tabStripNameNew = "InvestigationTabStrip";
            $.ajax({
                url: postUrl,
                dataType: "json",
                type: "POST",
                data: contentData,
                success: function (data) {
                    humanCase.reloadFFTab(tabStripNameNew, selectedTabIndexNew, itemId);
                }
            });
        } else {
            humanCase.reloadFFTab(tabStripName, slectedTabIndex, itemId);
        }
    },

    reloadFFTab: function (tabStripName, tabIndex, itemId) {
        if (tabStripName != "InvestigationTabStrip") {
            return;
        }
        if (tabIndex == 3) {
            showLoading();
            humanCase.reloadCCFlexForm('CaseClassificationFlexForm', itemId);
        }
        if (tabIndex == 4) {
            showLoading();
            humanCase.reloadEpiFlexForm('EpiLinksFlexForm', itemId);
        }
    },

    reloadCCFlexForm: function (fname, itemId) {
        var url = bvUrls.getHumanCaseCCFlexFormUrl();
        flexForms.reloadFf(url, fname, itemId);
    },

    reloadEpiFlexForm: function (fname, itemId) {
        var url = bvUrls.getHumanCaseEpiFlexFormUrl();
        flexForms.reloadFf(url, fname, itemId);
    },

    onDiagnosisChanged: function (itemId) {
        humanCase.reloadCCFlexForm('CaseClassificationFlexForm', itemId);
        humanCase.reloadEpiFlexForm('EpiLinksFlexForm', itemId);
    },

    onTentativeDiagnosisChange: function (e) {
        var args = comboBoxFacade.getOnChangedEventArgs(e, this);
        //if (args.previousValue == args.selectedValue) {
        //    return;
        //}
        var cbTentativeId = args.senderId;
        var cbFinalId = cbTentativeId.substring(0, cbTentativeId.lastIndexOf('_')) + "_FinalDiagnosis";
        var itemId = cbTentativeId.substring(cbTentativeId.indexOf('_') + 1, cbTentativeId.lastIndexOf('_'));
        var cbFinalValue = comboBoxFacade.getValueById(cbFinalId);
        if (args.selectedValue == cbFinalValue) {
            humanCase.revertTentativeDiagnosis(cbTentativeId, args.previousValue);
        }
        else {
            formRefresher.setOnChangedSuccess(humanCase.onDiagnosisChanged, itemId);
            bvComboBox.onChanged.call(this, e);
        }
    },

    revertTentativeDiagnosis: function (cbTentativeId, previousValue) {
        comboBoxFacade.cancelSelection(cbTentativeId, previousValue);
        bvDialog.showError(EIDSS.BvMessages['msgWrongDiagnosis']);
    },

    onFinalDiagnosisChange: function (e) {
        var args = comboBoxFacade.getOnChangedEventArgs(e, this);
        if (args.previousValue == args.selectedValue) {
            return;
        }
        var cbFinalId = args.senderId;
        var cbTentativeId = cbFinalId.substring(0, cbFinalId.lastIndexOf('_')) + "_TentativeDiagnosis";
        var cbTentativeValue = comboBoxFacade.getValueById(cbTentativeId);
        if (args.selectedValue == cbTentativeValue) {
            humanCase.revertFinalDiagnosis(cbFinalId, args.previousValue);
            return;
        }
        else {
            if (humanCase.isFinalDiagnosisRevert) {
                humanCase.isFinalDiagnosisRevert = false;
                return;
            }
            var isNewCaseHidden = $("#IsNewCase");
            if (isNewCaseHidden && isNewCaseHidden.val() == "true" || humanCase.hasChangeDiagnosisReason) {
                formRefresher.onFieldChanged(cbFinalId, args.selectedValue);
                return;
            }
            var idfCase = $("#idfCase").val();
            humanCase.showChangeDiagnosisReason(idfCase, cbFinalId, args);
        }
    },

    revertFinalDiagnosis: function (cbFinalId, previousValue) {
        comboBoxFacade.cancelSelection(cbFinalId, previousValue);
        humanCase.isFinalDiagnosisRevert = true;
        bvDialog.showError(EIDSS.BvMessages['msgWrongDiagnosis']);
    },

    showDiagnosisHistory: function () {
        var idfCase = $("#idfCase").val();
        var url = bvUrls.getHumanCaseIsDiagnosisChangedUrl();
        var url1 = bvUrls.getHumanCaseDiagnosisHistoryUrl() + "?root=" + idfCase;
        var title = EIDSS.BvMessages['titleDiagnosisHistory'];
        $.ajax({
            url: url,
            type: "POST",
            data: {
                root: idfCase,
            },
            datatype: "json",
            success: function (result) {
                if (formRefresher.hasError(result)) {
                    formRefresher.updateControls(result);
                } else {
                    bvPopup.showDefault(url1, title, 300, 150);
                }
            }
        });

    },

    showChangeDiagnosisReason: function (idfCase, cbFinalId, args) {
        var previousValue = args.previousValue;
        var selectedValue = args.selectedValue;
        if (!previousValue && selectedValue == "0" || !selectedValue && previousValue == "0") {
            return;
        }
        var url = bvUrls.getHumanCaseDiagnosisChangeUrl() + "?root=" + idfCase + "&cbFinalId=" + cbFinalId + "&previousDiagnosis=" + previousValue + "&newValue=" + selectedValue;
        var title = EIDSS.BvMessages['titleDiagnosisChange'];
        bvPopup.showDefault(url, title, 300, 150);
    },

    closeChangeDiagnosisReason: function (cbFinalId, previousDiagnosis) {
        bvPopup.closeDefaultPopup();
        comboBoxFacade.setValueById(cbFinalId, previousDiagnosis);
    },

    setChangeDiagnosisReason: function (idfCase, newDiagnosis) { 
        var changeDiagnosisReason = comboBoxFacade.getValueById("ChangeDiagnosisReason");
        if (!changeDiagnosisReason || changeDiagnosisReason === "0") {
            bvDialog.showError(EIDSS.BvMessages['strChangeDiagnosisReason_msgId']);
            return;
        }
        
        bvPopup.closeDefaultPopup();
        showLoading();
        var url = bvUrls.getSetNewHumanCaseDiagnosisUrl();
        $.ajax({
            url: url,
            type: "POST",
            data: {
                root: idfCase,
                newDiagnosis: newDiagnosis,
                changeDiagnosisReason: changeDiagnosisReason
            },
            datatype: "json",
            success: function (result) {
                hideLoading();
                formRefresher.updateControls(result);
                //bvPopup.closeDefaultPopup();
                humanCase.hasChangeDiagnosisReason = true;
            },
            error: function (data) {
                hideLoading();
                bvDialog.showError(EIDSS.BvMessages['ErrWebTemporarilyUnavailableFunction']);
            }
        });
    },
    

    showSearchPicker: function (objectId, functionName, isMultiSelection, showInInternalWindow) {
        var pickerUrl = bvUrls.getHumanCasePickerUrl() + "?objectId=" + objectId + "&functionName=" + functionName + "&isMultiSelection=" + isMultiSelection + "&showInInternalWindow=" + showInInternalWindow;
        var title = EIDSS.BvMessages['titleHumanCaseList'];
        if (showInInternalWindow.toLowerCase() != "true") {
            searchPicker.show(pickerUrl, title);
        } else {
            searchPicker.showInternal(pickerUrl, title);
        }
    },

    onPermantentAddressAsCurrentClickSuccess: function (checkBoxName) {
        var idRegAddr = $("#RegistrationAddress").val();
        var idfCase = $('#idfCase').val();

        var id = "RegistrationAddress_" + idRegAddr + "_*";
        var combo = comboBoxFacade.getReferenceControlDataByOriginalId(id, "Region");
        if (combo) {
            combo.dataSource.read();
        }
        combo = comboBoxFacade.getReferenceControlDataByOriginalId(id, "Rayon");
        if (combo) {
            combo.dataSource.read();
        }
        combo = comboBoxFacade.getReferenceControlDataByOriginalId(id, "Settlement");
        if (combo) {
            combo.dataSource.read();
        }

        var foreignAddress = "RegistrationAddress_" + idRegAddr + "_strForeignAddress";
        if ($("#" + foreignAddress).length > 0) {
            if ($("#" + foreignAddress)[0].classList.contains("invisible")) {
                $(".foreignAddressFieldInvisible").removeClass("invisible");
            } else {
                $(".foreignAddressFieldInvisible").addClass("invisible");
            }
        }

        var editBox = $('#HumanCase_' + idfCase + '_strRegistrationPhone');
        var btnShowMap = $('#RegistrationAddress_' + idRegAddr + '_');
        if ($('#' + checkBoxName).val() == "true") {
            editBox.attr("readonly", "readonly");
            editBox.addClass("readonlyField");
            btnShowMap.attr("disabled", "disabled");
        } else {
            editBox.removeAttr("readonly");
            editBox.removeClass("readonlyField");
            btnShowMap.removeAttr("disabled");
        }
        

    },

    onPermantentAddressAsCurrentClick: function (checkBoxName) {
        formRefresher.setOnChangedSuccess(humanCase.onPermantentAddressAsCurrentClickSuccess, checkBoxName);
        formRefresher.onCheckBoxChanged(checkBoxName);
    },

}
