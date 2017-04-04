var vetCase = {
    
    CreateLivestock: function (url) {
        bvWindow.show(url, " ");
    },

    CreateAvian: function (url) {
        bvWindow.show(url, " ");
    },

    onVIReportClick: function () {
        detailPage.onShowReportClick(vetCase.showVIReport);
    },

    showVIReport: function() {
        var caseId = $("#idfCase").val();
        var diagnosisId = $("#VetCase_" + caseId + "_strIdfsDiagnosis").val();
        if (!diagnosisId) {
            diagnosisId = 0;
        }
        var url = bvUrls.getVetInvestigationReportUrl({ caseId: caseId, diagnosisId: diagnosisId });
        detailPage.openReport(url);
    },

    onTestsReportClick: function() {
        var action = "ReportsAdditional";
        var caseId = $("#idfCase").val();
        var btn = $("#btnPrintTests");
        var x = btn.position().left;
        var y = btn.position().top + btn.height() + 1;
        popupMenu.showPopupMenu(action, "", caseId, x, y);
        setTimeout(
            function () {
                $('body').on("click", popupMenu.hidePopupMenuAndUnbind);
            }, 200);
    },

    TestsReportRun: function () {
        detailPage.onShowReportClick(vetCase.showTestsReport);
    },

    showTestsReport: function() {
        var caseId = $("#idfCase").val();
        var url = bvUrls.getTestsReportUrl({id: caseId, isHuman: "false"});
        detailPage.openReport(url);
    },

    saveAndCloseVaccinationGridEditWindow: function(gridName) {
        var ident = gridName.substring(0, gridName.lastIndexOf("_") + 1);
        var gridId = ident + 'Vaccination';
        bvGrid.saveAndCloseEditWindow(gridId, bvUrls.getVaccinationPickerUrl());
    },

    setIdfSpeciesValue: function(e, val) {
        var onLoadArgs = comboBoxFacade.getOnBoundEventArgs(e);
        comboBoxFacade.setValueById(onLoadArgs.senderId, val);
    },

    showVaccinationGridEditWindow: function(id, listKey, gridName) {
        var url = bvUrls.getVaccinationPickerUrl({key: listKey, name: gridName, id: id});
        bvGrid.showEditWindow(url, 730, 320, EIDSS.BvMessages['titleVaccination'], "V21");
    },

    showAnimalsGridEditWindow: function(id, listKey, gridName) {
        var url = bvUrls.getAnimalPickerUrl({key: listKey, name: gridName, id: id});
        bvGrid.showEditWindow(url, 730, 320, EIDSS.BvMessages['titleAnimals'], "V22");
    },

    saveAndCloseAnimalsGridEditWindow: function(gridName) {
        var ident = gridName.substring(0, gridName.lastIndexOf("_") + 1);
        var gridId = ident + 'AnimalList';
        bvGrid.saveAndCloseEditWindow(gridId, bvUrls.getAnimalPickerUrl());
    },

    showAnimalsGridRowTestDetails: function (gridName) {
        var idfCase = $("#idfCase").val();
        var idfAnimal = bvGrid.getSelectedItemId(gridName);
        var path = bvUrls.getAnimalClinicalSignsUrl({idfCase: idfCase, idfAnimal: idfAnimal});
        bvGrid.showEditWindowAnyWidth(path, 380, 320, EIDSS.BvMessages['titleClinicalSigns'], "V23");
    },

    showSearchPicker: function(objectId, functionName, isMultiSelection, showInInternalWindow) {
        var pickerUrl = bvUrls.getVetCasePickerUrl({
            objectId: objectId,
            functionName: functionName,
            isMultiSelection: isMultiSelection,
            showInInternalWindow: showInInternalWindow
        });
        var title = EIDSS.BvMessages['titleVeterinaryCaseList'];
        if (showInInternalWindow.toLowerCase() != "true") {
            searchPicker.show(pickerUrl, title, "V01");
        } else {
            searchPicker.showInternal(pickerUrl, title);
        }
    },

    onTabSelect: function(e, itemId, tabStripName) {
        var activeTabContentSelector = tabStripFacade.getActiveTabContentSelector(tabStripName);
        var eventArgs = tabStripFacade.getOnSelectEventArgs(e);
        var slectedTabIndex = eventArgs.slectedTabIndex;
        if ($(activeTabContentSelector + " #EpiFlexForm").length == 1 || $(activeTabContentSelector + " #CMFlexForm").length == 1) {
            var contentData = $("form").serialize(true);
            contentData = EscapeHtmlGtLtOnly(contentData);
            var postUrl = bvUrls.getStoreVetCaseUrl();
            $.ajax({
                url: postUrl,
                dataType: "json",
                type: "POST",
                data: contentData,
                success: function(data) {
                    vetCase.reloadFFTab(tabStripName, slectedTabIndex, itemId);
                }
            });
        } else {
            vetCase.reloadFFTab(tabStripName, slectedTabIndex, itemId);
        }
    },

    reloadFFTab: function(tabStripName, tabIndex, itemId) {
        if (tabStripName != "EpiSectionTabStrip") {
            return;
        }
        if (tabIndex == 1) {
            showLoading();
            vetCase.reloadEpiFlexForm('EpiFlexForm', itemId);
        }
        if (tabIndex == 2) {
            showLoading();
            vetCase.reloadCMFlexForm('CMFlexForm', itemId);
        }
    },

    reloadCMFlexForm: function(fname, itemId) {
        var url = bvUrls.getVetCaseCMFlexFormUrl();
        flexForms.reloadFf(url, fname, itemId);
    },

    reloadEpiFlexForm: function(fname, itemId) {
        var url = bvUrls.getVetCaseEpiFlexFormUrl();
        flexForms.reloadFf(url, fname, itemId);
    },
    
    onHerdsFlocksLoad: function (isReadOnly) {
        if (isReadOnly.toLowerCase() == 'true') {
            $("#btnAddHerd").attr('disabled', 'disabled');
            $("#btnAddHerd").addClass("k-state-disabled");
        }
        var herdList = $("#herdList");
        if (herdList.find(".sectionTitle").length) {
            herdList.find(".tabContentSeparator").hide();
        }
        
        var f = $(".herdFlockItem .sectionTitle");
        if (f.length > 0) {
            f[0].click();
        }
    },

    addNewHerdOrFlock: function (rootId, herdsListName, isFlock) {
        var postUrl = bvUrls.getCreateHerdOrFlockUrl();
        $.ajax({
            url: postUrl,
            type: "POST",
            cache: false,
            data: {
                key: rootId,
                listName: herdsListName,
                isFlock: isFlock
    },
            success: function(data) {
                if (data.ErrorMessage) {
                    bvDialog.showError(data.ErrorMessage);
                    return;
                }
                var herdList = $("#herdList");
                herdList.find(".tabContentSeparator").hide(); // hide line under "new herd" button
                $("#herdList").append(data); // add new herd html at the end of the list
                herdList.find(".sectionTitle").last().click(); // open added herd
            }
        });
    },

    onHerdOrFlockClick: function (selectedItem) {
        $(selectedItem).parent().find(".openArrow,.closeArrow,.speciesList").toggle();
    },

    showSpeciesGridEditWindow: function(id, listKey, gridName) {
        var idfHerdParty = gridName.substring(gridName.lastIndexOf('_') + 1);
        var idfCase = $("#idfCase").val();
        var path = bvUrls.getEditSpeciesDetailUrl({listKey: idfCase, gridName: gridName, idfSpecies: id, idfHerdParty: idfHerdParty, idfCase: idfCase});
        bvGrid.showEditWindow(path, 730, 460, EIDSS.BvMessages['Species'], "V24");
    },

    saveAndCloseSpeciesGridEditWindow: function(gridName) {
        var gridId = "SpeciesList_" + gridName;
        var idfSpecies = $(".popupContent #idfParty").val();
        var idfCase = $(".popupContent #IdfCaseVetCase").val();
        var url = bvUrls.getEditSpeciesDetailUrl({idfCase: idfCase, idfSpecies: idfSpecies, gridName: gridId});
        bvGrid.saveAndCloseEditWindow(gridId, url);
    },
    
    showSpeciesClinicalInvestigation: function (gridName) {
        var idfCase = $("#idfCase").val();
        var idfSpecies = bvGrid.getSelectedItemId(gridName);
        var path = bvUrls.getSpeciesClinicalSignsUrl({idfCase: idfCase, idfSpecies: idfSpecies});
        bvGrid.showEditWindow(path, 730, 460, EIDSS.BvMessages['titleClinicalInvestigation'], "V25");
    },
    
    onDeleteHerdOrFlockClick: function (idfHerdOrFlock, listName) {
        var caseId = $("#idfCase").val();
        var postUrl = bvUrls.getTryDeleteFromGridAndCompareUrl();
        bvDialog.showYesNo(msgConfimation,
            EIDSS.BvMessages['msgDeleteRecordPrompt'],
            function () {
                showLoading();
                $.ajax({
                    url: postUrl,
                    type: "POST",
                    cache: false,
                    data: {
                        key: caseId,
                        name: listName,
                        id: idfHerdOrFlock
                    },
                    success: function (data) {
                        hideLoading();
                        var hasError = formRefresher.hasError(data);
                        if (hasError) {
                            formRefresher.updateControls(data);
                            return;
                        }

                        $("#Herd_" + idfHerdOrFlock).remove();
                        var herdList = $("#herdList");
                        if (!herdList.find(".sectionTitle").length) {
                            herdList.find(".tabContentSeparator").show();
                        }
                    },
                    error: function (error) {
                        hideLoading();
                    }
                });
            },
            bvGrid.emptyFunction);
    },
    
    showVetCaseLogGridEditWindow: function (id, listKey, gridName) {
        var path = bvUrls.getVetCaseLogPickerUrl({key: listKey, name: gridName, id: id});
        bvGrid.showEditWindow(path, 730, 280, EIDSS.BvMessages['titleVetCaseLog'], "V26");
    },

    saveAndCloseVetCaseLogGridEditWindow: function (gridName) {
        var ident = gridName.substring(0, gridName.lastIndexOf("_") + 1);
        var gridId = ident + 'Logs';
        bvGrid.saveAndCloseEditWindow(gridId, bvUrls.getVetCaseLogPickerUrl());
    }

}