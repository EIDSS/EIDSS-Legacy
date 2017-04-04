var sample = {
    onTestsConductedChanged: function (e) {
        var args = comboBoxFacade.getOnChangedEventArgs(e, this);
        //if (args.previousValue == args.selectedValue) {
        //    return;
        //}
        var cbId = args.senderId;
        formRefresher.setOnChangedSuccess(sample.updateNewCaseTestValidationButton, e);
        formRefresher.onFieldChanged(cbId, args.selectedValue);
    },
    
    updateNewCaseTestValidationButton: function () {
        var caseTestsGridName = $("#hdnCaseTestsGridName").val();
        var isTestsGridEnabled = gridFacade.isEnabled(caseTestsGridName);
        if (!isTestsGridEnabled) {
            // если табл с тестами задисейблена, то кнопка btnNewCaseTestValidation неактивна
            gridFacade.disableButtons($("#btnNewCaseTestValidation"));
            return;
        }
        var isTestsGridHasRows = gridFacade.hasRows(caseTestsGridName);
        if (isTestsGridHasRows) {
            // если в табл с тестами выд строка, у кот idfsTestStatus==Completed(10001001)||idfsTestStatus==Amended(10001006), то кнопка btnNewCaseTestValidation активна
            var selectedRow = gridFacade.getSelectedRows(caseTestsGridName);
            if (selectedRow.length > 0) {
                sample.onCaseTestGridRowSelect(caseTestsGridName, selectedRow);
                gridFacade.disableButtons($("#btnCreateCase"));
            } else {
                gridFacade.disableButtons($("#btnNewCaseTestValidation"));
                gridFacade.disableButtons($("#btnCreateCase"));
            }
            return;
        } else {
            gridFacade.disableButtons($("#btnNewCaseTestValidation"));
            gridFacade.disableButtons($("#btnCreateCase"));
            return;
        }
        
        // если в табл с тестами выд строка, у кот idfsTestStatus==Completed(10001001)||idfsTestStatus==Amended(10001006), то кнопка btnNewCaseTestValidation активна,
        // в противном случае она неактивна
        //$("#btnNewCaseTestValidation").attr('disabled', 'disabled');
        //var testsGridId = cbId.substring(0, cbId.lastIndexOf('_')) + '_CaseTests';

        //HumanCase_49564710000000_CaseTests
    },

    showCaseTestValidationGridEditWindow: function (id, listKey, gridName) {
        var testsGridId = gridName.substring(0, gridName.lastIndexOf('_')) + '_CaseTests';
        var testId = gridFacade.getSelectedItemIds(testsGridId);
        if (!testId) {
            if (id == 0) {
                //alert('Test is not selected');
                return;
            } else {
                testId = 0;
            }
        }
        var path = bvUrls.getCaseTestValidationItemPickerUrl({key: listKey, name: gridName, id_test: testId, id: id });
        bvGrid.showEditWindow(path, 730, 320, EIDSS.BvMessages['titleResultSummary'], "L42");
    },
    
    saveAndCloseCaseTestValidationGridEditWindow: function (gridName) {
        var ident = gridName.substring(0, gridName.lastIndexOf("_") + 1);
        var gridId = ident + 'CaseTestValidations';
        bvGrid.saveAndCloseEditWindow(gridId, bvUrls.getCaseTestValidationItemPickerUrl(), sample.updateNewCaseTestValidationButton, bvPopup.getDefaultWindowDataWithoutChanging);
    },

    onValidateStatusClick: function (checkBoxName) {
        formRefresher.onCheckBoxChanged(checkBoxName, true, true);
    },

    /*onFilterByDiagnosisClick: function (checkBoxName) {
        formRefresher.onCheckBoxChanged(checkBoxName, false);
        var fieldForFilterByDiagnosis = $("#fieldForFilterByDiagnosis").val();
        var combo = comboBoxFacade.getReferenceControlDataByOriginalId(checkBoxName, fieldForFilterByDiagnosis);
        if (combo) {
            //combo.value(null);
            combo.dataSource.read();
        }
        //var ident = checkBoxName.substring(0, checkBoxName.lastIndexOf("_") + 1);
        //var fieldForFilterByDiagnosis = $("#fieldForFilterByDiagnosis").val();
        //var filteredCbId = ident + fieldForFilterByDiagnosis;
        //comboBoxFacade.reloadComboBox(filteredCbId);
    },*/

    onSampleTypeChangeSuccess: function (e) {
        hideLoading();
    },

    onSampleTypeChange: function (e) {
        showLoading();
        formRefresher.setOnChangedSuccess(sample.onSampleTypeChangeSuccess, e);
        bvComboBox.onChanged.call(this, e);
    },

    showHumanCaseSampleGridEditWindow: function (id, listKey, gridName) {
        var url = bvUrls.getHumanCaseSamplePickerUrl({ key: listKey, name: gridName, id: id });
        bvGrid.showEditWindow(url, 730, 320, EIDSS.BvMessages.titleSampleDetails, "H19");
    },

    saveAndCloseHumanCaseSampleGridEditWindow: function (gridName) {
        var ident = gridName.substring(0, gridName.lastIndexOf("_") + 1);
        var gridId = ident + 'Samples';
        bvGrid.saveAndCloseEditWindow(gridId, bvUrls.getSetHumanSampleUrl());
    },

    showVetCaseSampleGridEditWindow: function (id, listKey, gridName) {
        var url = bvUrls.getVetCaseSamplePickerUrl({key: listKey, name: gridName, id: id});
        bvGrid.showEditWindow(url, 730, 420, EIDSS.BvMessages['titleSampleDetails'], "V28");
    },

    saveAndCloseVetCaseSampleGridEditWindow: function (gridName) {
        var ident = gridName.substring(0, gridName.lastIndexOf("_") + 1);
        var gridId = ident + 'Samples';
        bvGrid.saveAndCloseEditWindow(gridId, bvUrls.getSetVetSampleUrl());
    },
    
    onCaseTestGridLoad: function (needShowSearch, gridName) {
        if (needShowSearch.toLowerCase() != "true") {
            bvGrid.toolBar.hideSearchPanel(gridName);
        }
    },

    showCaseTestGridEditWindow: function (id, listKey, gridName) {
        var path = bvUrls.getCaseTestItemPickerUrl({key: listKey, name: gridName, id: id});
        bvGrid.showEditWindow(path, 730, 460, EIDSS.BvMessages['titleTestResultDetails'], "L40");
    },

    onCaseTestGridRowSelect: function (gridName, slectedRow) {
        var statusId = slectedRow.find("td.gridHidden input[name='idfsTestStatus']").val();
        if (slectedRow.parent().parent().parent().parent()[0].hasAttribute("disabled")) {
            gridFacade.disableButtons($("#btnNewCaseTestValidation"));
            gridFacade.disableButtons($("#buttonTestDetails"));
        } else {
            if (statusId == "10001001" || statusId == "10001006") { // completed or amended
                gridFacade.enableButtons($("#btnNewCaseTestValidation"));
            }
            else {
                gridFacade.disableButtons($("#btnNewCaseTestValidation"));
            }
        }
        /*var isNonLabTest = slectedRow.find("td.gridHidden input[name='blnNonLaboratoryTest']").val();
        if (isNonLabTest == "true") {
            gridFacade.enableButtons($("#btnNewCaseTestValidation"));
        }
        else {
            gridFacade.disableButtons($("#btnNewCaseTestValidation"));
        }*/
    },

    onCaseTestValidationGridRowSelect: function (gridName, slectedRow) {
        var blnCaseCreated = slectedRow.find("td.gridHidden input[name='blnCaseCreated']").val();
        var blnValidateStatus = slectedRow.find("td.gridHidden input[name='blnValidateStatus2']").val();
        var idfsInterpretedStatus = slectedRow.find("td.gridHidden input[name='idfsInterpretedStatus']").val();
        if (idfsInterpretedStatus == "10104001" && blnValidateStatus == "true" && blnCaseCreated != "true") {
            gridFacade.enableButtons($("#btnCreateCase"));
        }
        else {
            gridFacade.disableButtons($("#btnCreateCase"));
        }
    },


    showCaseTestGridRowTestDetails: function (gridName, root) {
        var key = bvGrid.getSelectedItemId(gridName);
        var url = bvUrls.getShowTestDetailFlexibleFormUrl({root: root, key: key, name: gridName});
        bvGrid.showEditWindow(url, 730, 460, EIDSS.BvMessages['titleTestDetails'], "L41");
    },

    saveAndCloseCaseTestGridEditWindow: function (gridName) {
        var ident = gridName.substring(0, gridName.lastIndexOf("_") + 1);
        var gridId = ident + 'CaseTests';
        bvGrid.saveAndCloseEditWindow(gridId, bvUrls.getCaseTestItemPickerUrl());
    },
    
    /*onTestTypeChanged: function (e) {
        formRefresher.setOnChangedSuccess(sample.onTestTypeChangedSuccess, e);
        bvComboBox.onChanged.call(this, e);
    },

    onTestTypeChangedSuccess: function (e) {
        comboBoxFacade.reloadReferenceComboBox(e, 'TestResultRef');
    },*/

    onAnimalSpeciesChanged: function (e) {
        formRefresher.setOnChangedSuccess(sample.onAnimalSpeciesChangedSuccess, e);
        bvComboBox.onChanged.call(this, e);
    },

    onAnimalSpeciesChangedSuccess: function (e) {
        comboBoxFacade.reloadReferenceComboBox(e, 'AnimalAge');
    },

    showPensideTestGridEditWindow: function (id, listKey, gridName) {
        var path = bvUrls.getPensideTestPickerUrl({key: listKey, name: gridName, id: id});
        bvGrid.showEditWindow(path, 730, 280, EIDSS.BvMessages['titlePensideTest'], "V27");
    },
    
    saveAndClosePensideTestGridEditWindow: function (gridName) {
        var ident = gridName.substring(0, gridName.lastIndexOf("_") + 1);
        var gridId = ident + 'PensideTests';
        bvGrid.saveAndCloseEditWindow(gridId, bvUrls.getPensideTestPickerUrl());
    }
}