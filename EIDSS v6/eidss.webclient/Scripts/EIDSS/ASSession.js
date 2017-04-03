var asSession = {

    onReportAsSessionTestsClick: function () {
        detailPage.onShowReportClick(asSession.showReportAsSessionTests);
    },

    showReportAsSessionTests: function () {
        var caseId = $("#idfMonitoringSession").val();
        var lang = GetSiteLanguage();
        var url = "/" + lang + "/ASSession/ReportAsSessionTests" + "?id=" + caseId;
        detailPage.openReport(url);
    },

    onReportAsSampleCollectedListClick: function () {
        detailPage.onShowReportClick(asSession.showReportAsSampleCollectedList);
    },

    showReportAsSampleCollectedList: function () {
        var caseId = $("#idfMonitoringSession").val();
        var lang = GetSiteLanguage();
        var url = "/" + lang + "/ASSession/ReportAsSampleCollectedList" + "?id=" + caseId;
        detailPage.openReport(url);
    },


    ShowASSessionPicker: function (functionName, gridName, objectId) {
        if (!functionName) {
            functionName = "searchPicker.closePicker()";
        } else {
            functionName = functionName + '("' + gridName + '", "' + objectId + '")';
        }
        var pickerUrl = bvUrls.getAsSessionPickerUrl() + "?functionName=" + functionName;
        var title = EIDSS.BvMessages['titleASSessionList'];
        searchPicker.show(pickerUrl, title, 'V17');
    },

    onSearchSessionPickerSelect: function () {
        var selectedItemId = searchPicker.getSelectedIds();
        if (selectedItemId) {
            asSession.onASSessionPickerValueChanged(objectId, idfsASCampaignPropertyName, strASCampaignPropertyName, strASCampaignIdPropertyName, selectedItemId, showInInternalWindow);
        } else {
            searchPicker.closePicker('false');
        }
    },

    onASSessionPickerValueChanged: function (objectId, idfsASCampaignPropertyName, strASCampaignPropertyName,
        strASCampaignIdPropertyName, selectedItemId, showInInternalWindow) {
        if (!selectedItemId) {
            var btnClian = $("#btnASCampaignClian_" + objectId + "_" + idfsASCampaignPropertyName);
            if (btnClian.data("disabled") === "true") {
                return;
            }
        }

        var btnView = $("#btnASCampaignViewPicker_" + objectId + "_" + idfsASCampaignPropertyName);
        if (selectedItemId.toString() == '') {
            btnView.attr('disabled', 'disabled');
        } else {
            btnView.removeAttr('disabled');
        }

        var url = bvUrls.getSetASCampaignUrl();
        $.ajax({
            url: url,
            type: "POST",
            data: {
                objectId: objectId,
                idfsASCampaignPropertyName: idfsASCampaignPropertyName,
                strASCampaignPropertyName: strASCampaignPropertyName,
                strASCampaignIdPropertyName: strASCampaignIdPropertyName,
                selectedItemId: selectedItemId,
                showInInternalWindow: showInInternalWindow,
                ignoreErr: 0
            },
            datatype: "json",
            success: function (data) {
                if (formRefresher.hasMessage(data)) {
                    formRefresher.updateControls(data, null, function() {
                        $.ajax({
                            url: url,
                            type: "POST",
                            data: {
                                objectId: objectId,
                                idfsASCampaignPropertyName: idfsASCampaignPropertyName,
                                strASCampaignPropertyName: strASCampaignPropertyName,
                                strASCampaignIdPropertyName: strASCampaignIdPropertyName,
                                selectedItemId: selectedItemId,
                                showInInternalWindow: showInInternalWindow,
                                ignoreErr: 1
                            },
                            datatype: "json",
                            success: function (data1) {
                                if (formRefresher.hasMessage(data1)) {
                                    formRefresher.updateControls(data1);
                                } else {
                                    var objectIdent1 = $("#ObjectIdent").val();
                                    var gridForReload1 = objectIdent1 + "Diseases";
                                    formRefresher.setOnChangedSuccess(bvGrid.reloadById, gridForReload1);
                                    formRefresher.updateControls(data1);
                                    formRefresher.doOnChangedSuccess();
                                    if (selectedItemId) {
                                        searchPicker.closePicker(showInInternalWindow);
                                    }
                                }
                            }
                        });
                    });
                } else {
                    var objectIdent = $("#ObjectIdent").val();
                    var gridForReload = objectIdent + "Diseases";
                    formRefresher.setOnChangedSuccess(bvGrid.reloadById, gridForReload);
                    formRefresher.updateControls(data);
                    formRefresher.doOnChangedSuccess();
                    if (selectedItemId) {
                        searchPicker.closePicker(showInInternalWindow);
                    }
                }
            }
        });
    },

    showDiseasesGridEditWindow: function (id, listKey, gridName) {
        var url = bvUrls.getAsSessionDiseaseUrl() + "?key=" + listKey + "&name=" + gridName + "&id=" + id;
        bvGrid.showEditWindow(url, 680, 350, EIDSS.BvMessages['titleAddDisease']);
    },

    saveAndCloseDiseasesGridEditWindow: function (gridName) {
        var ident = gridName.substring(0, gridName.lastIndexOf("_") + 1);
        var gridId = ident + 'Diseases';
        bvGrid.saveAndCloseEditWindow(gridId, bvUrls.getSetAsSessionDiseasesUrl());
    },

    onDiseaseMove: function (key, name, shift) {
        var id = gridFacade.getSelectedItemIds(name);
        var path = bvUrls.getAsSessionDiseasesMoveItemUrl() + "?key=" + key + "&name=" + name + "&idfAsDisease=" + id + "&moveDirection=" + shift;
        $.ajax({
            url: path,
            dataType: "json",
            type: "GET",
            success: function (data) {
                bvGrid.reloadById(name);
            }
        });
    },

    saveAndCloseCasesGridEditWindow: function (id) {
        var key = $("#idfMonitoringSession").val();

        var url = bvUrls.getSetAsSessionCasesUrl();
        var tab = $('#FullDetails').data().kendoTabStrip;
        var ident = "AsSession" + "_" + key + "_";

        $.ajax({
            url: url,
            dataType: 'json',
            type: 'POST',
            data: {
                key: key,
                item: id
            },
            success: function (data) {
                hideLoading();
                var hasError = formRefresher.hasMessage(data);
                formRefresher.updateControls(data);
                if (!hasError) {
                    var tabIndx = -1;
                    var tabA = $("#tabTitleCases");
                    if (tabA != null) {
                        tabIndx = tabA.index();
                    }
                    tab.select(tabIndx);
                    bvGrid.reloadById(ident + "Cases");
                }
            }
        });
    },

    CreateCaseClick: function (gridName) {
        var id = gridFacade.getSelectedItemIds(gridName);
        if (!id) {
            alert('Test Interpretation is not selected');
            return;
        }

        showLoading();
        detailPage.onShowReportClick(function () { asSession.saveAndCloseCasesGridEditWindow(id); });
    },

    RedirectToFarmDetails: function (id, listKey, gridName) {
        asSession.RedirectToForm(bvUrls.getAsSessionFarmUrl() + "?key=" + listKey + "&name=" + gridName + "&item=" + id + "&details=true&summary=false");
    },

    RedirectToFarmSummary: function (id, listKey, gridName) {
        asSession.RedirectToForm(bvUrls.getAsSessionFarmUrl() + "?key=" + listKey + "&name=" + gridName + "&item=" + id + "&details=false&summary=true");
    },

    RedirectToForm: function (url) {
        actions.redirectToUrl(url, bvUrls.getAsStoreInSessionUrl());
    },

    deleteFarmDetails: function (id, listKey, gridName, type) {
        bvDialog.showDeletePrompt(function () {
            asSession.doDeleteRow(id, listKey, gridName, true);
        });
    },

    deleteFarmSummary: function (id, listKey, gridName, type) {
        bvDialog.showDeletePrompt(function () {
            asSession.doDeleteRow(id, listKey, gridName, false);
        });
    },

    doDeleteRow: function (id, listKey, gridName, bDeleteDetails) {
        var url = bvUrls.getAsSessionDeleteFarmUrl();
        $.ajax({
            url: url,
            dataType: "json",
            type: "GET",
            data: {
                asSessionId: listKey,
                farmId: id,
                bDeleteDetails: bDeleteDetails
            },
            success: function (result) {
                formRefresher.updateControls(result);
                gridFacade.reload(gridName);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                bvDialog.showAuthenticationError(jqXHR, textStatus, errorThrown);
            }
        });
    },

    deleteAnimalSample: function (id, listKey, gridName, type) {
        bvDialog.showDeletePrompt(function () {
            asSession.doDeleteAnimalSampleRow(id, listKey, gridName);
        });
    },

    doDeleteAnimalSampleRow: function (id, listKey, gridName) {
        var url = bvUrls.getAsSessionDeleteAnimalSampleUrl();
        $.ajax({
            url: url,
            dataType: "json",
            type: "GET",
            data: {
                asSessionId: listKey,
                animalSampleId: id
            },
            success: function (data) {
                var hasError = formRefresher.hasError(data);
                formRefresher.updateControls(data);
                if (!hasError) {
                    gridFacade.reload(gridName);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                bvDialog.showAuthenticationError(jqXHR, textStatus, errorThrown);
            }
        });
    },



    formFarmDetailOk: function () {
        asSession.formDetailOk(bvUrls.getAsSessionFarmUrl());
    },

    formDetailOk: function (url) {
        var idSession = $("#idfMonitoringSession").val();
        var formData = $('form').formSerialize();
        $.ajax({
            url: url,
            type: "POST",
            data: formData,
            success: function (result) {
                if (formRefresher.hasMessage(result)) {
                    formRefresher.setOnChangedSuccess(ActionEditAsSessionRedirect, idSession);
                    formRefresher.updateControls(result);
                } else {
                    ActionEditAsSessionRedirect(idSession);
                }
            }
        }
        );
    },

    formDetailCancel: function () {
        var idSession = $("#idfMonitoringSession").val();
        ActionEditAsSessionRedirect(idSession);
    },

    clickPageable : function () {
        var idSession = $("#idfMonitoringSession").val();
        var pageable = $("#chkAsSessionAnimalSamplePageable")[0].checked;
        ActionEditAsSessionReopen(idSession, pageable == true ? 1 : 2);
    },

    addNewHerdOrFlock: function (rootId, herdsListName) {
        asSession.addHerdOrFlock(rootId, herdsListName, bvUrls.getAsSessionCreateHerdOrFlockUrl());
    },

    addHerdOrFlock: function (rootId, herdsListName, postUrl) {
            $.ajax({
            url: postUrl,
            cache: false,
            data: {
                key: rootId,
                listName: herdsListName
            },
            success: function (data) {
                if (formRefresher.hasMessage(data)) {
                    formRefresher.updateControls(data);
                    return;
                }
                var herdList = $("#herdList");
                herdList.find(".tabContentSeparator").hide(); // hide line under "new herd" button
                $("#herdList").append(data); // add new herd html at the end of the list
                herdList.find(".sectionTitle").last().click(); // open added herd
            }
        });
    },

    onFilterByDiagnosisClick: function (checkBoxName) {
        formRefresher.onCheckBoxChanged(checkBoxName);
        var combo = comboBoxFacade.reloadReferenceComboBox2(checkBoxName, "SampleTypeForDiagnosis");
    },

    onSpeciesChangeSuccess: function (e) {
        comboBoxFacade.reloadReferenceComboBox(e, "AnimalAge");
    },

    onSpeciesChange: function (e) {
        formRefresher.setOnChangedSuccess(asSession.onSpeciesChangeSuccess, e);
        bvComboBox.onChanged.call(this, e);
    },

    showSpeciesGridEditWindow: function (id, listKey, gridName) {
        asSession.showSpecGridEditWindow(id, listKey, gridName, bvUrls.getAsSessionSpeciesDetailUrl());
    },

    showSpecGridEditWindow: function (id, listKey, gridName, url) {
        var idfHerdParty = gridName.substring(gridName.lastIndexOf('_') + 1);
        var idfMonitoringSession = $("#idfMonitoringSession").val();
        var idfRoot = $("#IdfRoot").val();
        var path = url
            + "?idfMonitoringSession=" + idfMonitoringSession + "&idfRoot=" + idfRoot + "&gridName=" + gridName
            + "&idfSpecies=" + id + "&idfHerdParty=" + idfHerdParty;
        bvGrid.showEditWindow(path, 730, 460, EIDSS.BvMessages['Species']);
    },

    saveAndCloseSpeciesGridEditWindow: function (gridName) {
        asSession.saveAndCloseSpecGridEditWindow(gridName, bvUrls.getAsSessionSpeciesDetailUrl());
    },

    saveAndCloseSpecGridEditWindow: function (gridName, url) {
        var gridId = "SpeciesList_" + gridName;
        var idfSpecies = $(".popupContent #idfParty").val();
        var idfMonitoringSession = $(".popupContent #IdfMonitoringSession").val();
        var idfRoot = $(".popupContent #IdfRoot").val();
        var postUrl = url + "?idfMonitoringSession=" + idfMonitoringSession + "&idfRoot" + idfRoot + "&idfSpecies=" + idfSpecies + "&gridName=" + gridId;

        var contentData = bvPopup.getDefaultWindowData();
        $.ajax({
            url: postUrl,
            dataType: "json",
            type: "POST",
            data: contentData,
            success: function (data) {
                var hasError = formRefresher.hasMessage(data);
                formRefresher.updateControls(data);
                if (!hasError) {
                    bvPopup.closeDefaultPopup();
                    bvGrid.reloadById(gridId);
                    //var comboId = comboName + "Species";//Lookup
                    //var control = $("[id$=Species]");
                    //control.data("kendoComboBox").dataSource.read();
                }
            },
            error: function () {
                bvPopup.closeDefaultPopup();
                bvGrid.reloadById(gridId);
            }
        });
    },




    showAnimalSampleGridEditWindow: function (id, listKey, gridName) {
        var url = bvUrls.getAsSessionAnimalSampleDetailUrl();
        var idfMonitoringSession = $("#idfMonitoringSession").val();
        var path = url
            + "?idfMonitoringSession=" + idfMonitoringSession + "&gridName=" + gridName
            + "&idfAnimalSample=" + id;
        bvGrid.showEditWindow(path, 730, 460, EIDSS.BvMessages['titleAnimalSampleInfo']);
    },

    saveAndCloseAnimalSampleGridEditWindow: function (idfMonitoringSession) {
        var url = bvUrls.getAsSessionAnimalSampleDetailUrl();
        var gridId = "AsSession_" + idfMonitoringSession + "_ASAnimalsSamples";
        var idfAnimalSample = $(".popupContent #id").val();
        var postUrl = url + "?idfMonitoringSession=" + idfMonitoringSession + "&idfAnimalSample=" + idfAnimalSample + "&gridName=" + gridId;

        var contentData = bvPopup.getDefaultWindowData();
        $.ajax({
            url: postUrl,
            dataType: "json",
            type: "POST",
            data: contentData,
            success: function (data) {
                var hasError = formRefresher.hasMessage(data);
                formRefresher.updateControls(data);
                if (!hasError) {
                    bvPopup.closeDefaultPopup();
                    bvGrid.reloadById(gridId);
                }
            },
            error: function () {
                bvPopup.closeDefaultPopup();
                bvGrid.reloadById(gridId);
            }
        });
    },



    showSummaryGridEditWindow: function (id, listKey, gridName) {
        var url = bvUrls.getAsSessionSummaryDetailUrl();
        var idfMonitoringSession = $("#idfMonitoringSession").val();
        var path = url
            + "?idfMonitoringSession=" + idfMonitoringSession + "&gridName=" + gridName
            + "&idfSummary=" + id;
        bvGrid.showEditWindow(path, 730, 460, EIDSS.BvMessages['titleAnimalsSamplesInfo']);
    },

    saveAndCloseSummaryGridEditWindow: function (idfMonitoringSession) {
        var url = bvUrls.getAsSessionSummaryDetailUrl();
        var gridId = "AsSession_" + idfMonitoringSession + "_SummaryItems";
        var idfMonitoringSessionSummary = $(".popupContent #idfMonitoringSessionSummary").val();
        var postUrl = url + "?idfMonitoringSession=" + idfMonitoringSession + "&idfSummary=" + idfMonitoringSessionSummary + "&gridName=" + gridId;

        var contentData = bvPopup.getDefaultWindowData();
        $.ajax({
            url: postUrl,
            dataType: "json",
            type: "POST",
            data: contentData,
            success: function (data) {
                var hasError = formRefresher.hasMessage(data);
                formRefresher.updateControls(data);
                if (!hasError) {
                    bvPopup.closeDefaultPopup();
                    bvGrid.reloadById(gridId);
                }
            },
            error: function () {
                bvPopup.closeDefaultPopup();
                bvGrid.reloadById(gridId);
            }
        });
    },





    showActionsGridEditWindow: function (id, listKey, gridName) {
        var url = bvUrls.getAsSessionActionUrl() + "?key=" + listKey + "&name=" + gridName + "&id=" + id;
        bvGrid.showEditWindow(url, 680, 350, EIDSS.BvMessages['titleAction']);
    },

    saveAndCloseActionGridEditWindow: function (gridName) {
        var ident = gridName.substring(0, gridName.lastIndexOf("_") + 1);
        var gridId = ident + 'Actions';
        bvGrid.saveAndCloseEditWindow(gridId, bvUrls.getSetAsSessionActionUrl());
    },
    
    showCase: function (id, listKey, gridName) {
        var url = bvUrls.getVetCaseDetailsUrl() + "?id=" + id;
        bvWindow.show(url, " ");
    },

    onSampleCopy: function (listKey, gridName) {
        var id = gridFacade.getSelectedItemIds(gridName);
        if (!id) {
            alert('Farm is not selected');
            return;
        }
        var url = bvUrls.getAsSessionCopyFarmUrl() + "?root=" + listKey + "&gridName=" + gridName + "&idfSample=" + id;
        bvGrid.showEditWindow(url, 680, 350, EIDSS.BvMessages['titleCopySample']);
    },

    saveAndCloseNumberOfCopiesWindow: function (listKey, gridName, id, num) {
        bvGrid.saveAndCloseEditWindow(gridName, bvUrls.getAsSessionCopyFarmUrl());
    },
    

    deleteSpecies: function (id, listKey, gridName, type) {
        bvDialog.showDeletePrompt(function () {
            asSession.doDeleteSpecies(id, listKey, gridName, type);
        });
    },


    doDeleteSpecies: function (id, listKey, gridName, type) {
        var url = bvUrls.getTryDeleteFromDetailsGridUrl();
        $.ajax({
            url: url,
            dataType: "json",
            type: "GET",
            data: {
                key: listKey,
                name: gridName,
                type: type,
                id: id
            },
            success: function (data) {
                var hasError = formRefresher.hasError(data);
                if (!hasError) {
                    gridFacade.reload(gridName);
                }
                formRefresher.updateControls(data);
                /*if (data) {
                    gridFacade.reload(gridName);
                }
                else {
                    bvDialog.showError(EIDSS.BvMessages['ErrObjectCantBeDeleted']);
                }*/
            },
            error: function (jqXHR, textStatus, errorThrown) {
                bvDialog.showAuthenticationError(jqXHR, textStatus, errorThrown);
            }
        });
    },

    deleteHerd: function (idfHerdOrFlock, listName) {
        var caseId = $("#idfFarm").val();
        var postUrl = bvUrls.getTryDeleteFromGridAndCompareUrl();
        bvDialog.showYesNo(msgConfimation,
            EIDSS.BvMessages['msgDeleteRecordPrompt'],
            function () {
                showLoading();
                $.ajax({
                    url: postUrl,
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

    onFarmChanged: function (e) {
        formRefresher.setOnChangedSuccess(asSession.onFarmChangedSuccess, e);
        bvComboBox.onChanged.call(this, e);
    },

    onFarmChangedSuccess: function (e) {
        comboBoxFacade.reloadReferenceComboBox(e, 'Species');
        comboBoxFacade.reloadReferenceComboBox(e, 'Animals');
        comboBoxFacade.reloadReferenceComboBox(e, 'AnimalAge');
        comboBoxFacade.reloadReferenceDropDown(e, 'DiagnosisList');
    },

    onSpeciesChanged: function (e) {
        formRefresher.setOnChangedSuccess(asSession.onSpeciesChangedSuccess, e);
        bvComboBox.onChanged.call(this, e);
    },

    onSpeciesChangedSuccess: function (e) {
        comboBoxFacade.reloadReferenceComboBox(e, 'Animals');
        comboBoxFacade.reloadReferenceComboBox(e, 'AnimalAge');
        comboBoxFacade.reloadReferenceDropDown(e, 'DiagnosisList');
    },

    onAnimalsChanged: function (e) {
        var args = comboBoxFacade.getOnChangedEventArgs(e, this);
        var data = {
            e: e,
            senderId: args.senderId,
            selectedValue: args.selectedValue
        };
        formRefresher.setOnChangedSuccess(asSession.onAnimalsChangedSuccess, data);
        bvComboBox.onChanged.call(this, e);
    },

    onAnimalsChangedSuccess: function (args) {
        comboBoxFacade.reloadReferenceComboBox(args.e, 'Animals');
        if (args.selectedValue) {
            comboBoxFacade.setValueById(args.senderId, args.selectedValue);
        }
    },

}

