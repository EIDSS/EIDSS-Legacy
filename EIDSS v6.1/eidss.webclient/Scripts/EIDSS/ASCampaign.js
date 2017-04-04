var asCampaign = {
    refreshSessions: function () {
        var sessionlist = window.opener.$('div[id$="Sessions"]');
        if (sessionlist[0]) {
            bvGrid.reloadById(sessionlist[0].id);
        }
    },

    /*onDiagnosisChangedSuccess: function (e) {
        comboBoxFacade.reloadReferenceComboBox(e, 'SampleType');
    },*/

    /*onDiagnosisChanged: function (e) {
        formRefresher.setOnChangedSuccess(asCampaign.onDiagnosisChangedSuccess, e);
        bvComboBox.onChanged.call(this, e);
    },*/

    onCampaignStatusChange: function(e) {
        bvComboBox.onChanged.call(this, e);

        var args = comboBoxFacade.getOnChangedEventArgs(e, this);
        if (args.previousValue == args.selectedValue) {
            return;
        }
        var sessionlist = $('div[id$="Sessions"]');
        var gridId = sessionlist[0].id;
        var btNewSession = $("#" + gridId + " #btNew");
        var btSelect = $("#" + gridId + " #btSelect");

        if (args.selectedValue == 10140001) {
            gridFacade.enableButtons(btNewSession);
            gridFacade.enableButtons(btSelect);
        }
        else {
            gridFacade.disableButtons(btNewSession);
            gridFacade.disableButtons(btSelect);
        }
    },

    showDiseasesGridEditWindow: function (id, listKey, gridName) {
        var url = bvUrls.getAsCampaignDiseasesPickerUrl({key: listKey, name: gridName, id: id});
        bvGrid.showEditWindow(url, 680, 350, EIDSS.BvMessages['titleAddDisease'], "V31");
    },
    

    saveAndCloseDiseasesGridEditWindow: function (gridName) {
        var ident = gridName.substring(0, gridName.lastIndexOf("_") + 1);
        var gridId = ident + 'Diseases';
        bvGrid.saveAndCloseEditWindow(gridId, bvUrls.getSetAsCampaignDiseasesUrl());
    },

    onDiseaseMove: function (key, name, shift) {
        var id = gridFacade.getSelectedItemIds(name);
        var path = bvUrls.getAsCampaignDiseasesMoveItemUrl({key: key, name: name, idfAsDisease: id, moveDirection: shift});
        $.ajax({
            url: path,
            dataType: "json",
            type: "POST",
            success: function (data) {
                bvGrid.reloadById(name);
            }
        });
    },

    deleteSession: function (id, listKey, gridName, type) {
        bvDialog.showPrompt(EIDSS.BvMessages['AsCampaign_GetSessionRemovalConfirmation'], function () {
            bvGrid.doDeleteRow(id, listKey, gridName, type);
        });
    },

    viewSession: function (id, listKey, gridName) {
        asCampaign.RedirectToForm(bvUrls.getAsSessionDetailsUrl({ id: id, idfCampaign: listKey, readOnly: "true" }));
    },

    RedirectToSession: function (id, listKey) {
        asCampaign.onShowReportClick(function () {
            asCampaign.RedirectToForm(bvUrls.getAsSessionDetailsUrl({ id: id, idfCampaign: listKey, fromCampaign: "true" }));
        });
    },

    RedirectToForm: function (url) {
        actions.redirectToUrl(url, bvUrls.getAsCampaignStoreInSessionUrl());
    },

    formSessionDetailOk: function () {
        asCampaign.formDetailOk(bvUrls.getAsSessionDetailsUrl());
    },

    formDetailOk: function (url) {
        var idCampaign = $("#idfCampaign").val();
        var formData = $('form').formSerialize();
        $.ajax({
            url: url,
            type: "POST",
            data: formData,
            success: function (result) {
                if (formRefresher.hasMessage(result)) {
                    formRefresher.setOnChangedSuccess(ActionEditAsCampaignRedirect, idCampaign);
                    formRefresher.updateControls(result);
                } else {
                    ActionEditAsCampaignRedirect(idCampaign);
                }
            }
        }
        );
    },

    formDetailCancel: function () {
        var idCampaign = $("#idfCampaign").val();
        ActionEditAsCampaignRedirect(idCampaign);
    },

    onSessionPickerSelect: function (gridName, rootKey) {
        var selectedItemId = searchPicker.getSelectedIds();
        if (selectedItemId) {
            var url = bvUrls.getSetSelectedAsSessionUrl({root: rootKey, selectedId: selectedItemId});
            bvGrid.saveAndCloseEditWindow(gridName, url);
        } else {
            searchPicker.closePicker();
        }
    },
    
    initInlinePicker: function (btnShowPickerId, btnClianId, btnViewId, isSearchButtonReadOnly, isClianButtonReadOnly, isViewButtonReadOnly, pickerWrapId) {
        var btnShowPicker = $("#" + btnShowPickerId);
        var btnClian = $("#" + btnClianId);
        var btnView = $("#" + btnViewId);
        if (isSearchButtonReadOnly.toString().toLowerCase() == 'true') {
            btnShowPicker.attr('disabled', 'disabled');
        } else {
            btnShowPicker.removeAttr('disabled');
        }
        if (isViewButtonReadOnly.toString().toLowerCase() == 'true') {
            btnView.attr('disabled', 'disabled');
        } else {
            btnView.removeAttr('disabled');
        }
        if (isClianButtonReadOnly.toString().toLowerCase() == 'true') {
            btnClian.data("disabled", "true");
        } else {
            btnClian.data("disabled", "false");
        }

        $("#" + pickerWrapId + ":has(.requiredField)").find(".pickerWrap").addClass('requiredField');
    },
    
    isInlinePicker: function (objectId, idfsASCampaignPropertyName) {
        var mainPickerId = "divASCampaignSearchPicker_" + objectId + "_" + idfsASCampaignPropertyName;
        if ($("#" + mainPickerId).length) {
            return true;
        }
        return false;
    },
    
    showASCampaignSearchPicker: function (objectId, idfsASCampaignPropertyName, strASCampaignPropertyName, strASCampaignIdPropertyName, showInInternalWindow) {
        var pickerUrl = bvUrls.getASCampaignPickerUrl({
            objectId: objectId,
            idfsASCampaignPropertyName: idfsASCampaignPropertyName,
            strASCampaignPropertyName: strASCampaignPropertyName,
            strASCampaignIdPropertyName: strASCampaignIdPropertyName,
            showInInternalWindow: showInInternalWindow
        });
        var title = EIDSS.BvMessages['titleSelectCampaign'];
        if (showInInternalWindow.toLowerCase() != "true") {
            searchPicker.show(pickerUrl, title, "V15");
        } else {
            searchPicker.showInternal(pickerUrl, title);
        }
    },

    onASCampaignSearchPickerSelect: function (objectId, idfsASCampaignPropertyName, strASCampaignPropertyName, strASCampaignIdPropertyName, showInInternalWindow) {
        var selectedItemId = searchPicker.getSelectedIds();
        if (selectedItemId) {
            asCampaign.onASCampaignPickerValueChanged(objectId, idfsASCampaignPropertyName, strASCampaignPropertyName, strASCampaignIdPropertyName, selectedItemId, showInInternalWindow);
        } else {
            searchPicker.closePicker(showInInternalWindow);
        }
    },

    onASCampaignPickerValueChanged: function (objectId, idfsASCampaignPropertyName, strASCampaignPropertyName,
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
                    formRefresher.updateControls(data, null, function () {
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
    
    enableInlinePicker: function (objectId, idfsASCampaignPropertyName, selectedId) {
        if (!asCampaign.isInlinePicker(objectId, idfsASCampaignPropertyName)) {
            return;
        }
        var btnSelect = $("#btnASCampaignSearchPicker_" + objectId + "_" + idfsASCampaignPropertyName);
        var btnClian = $("#btnASCampaignClian_" + objectId + "_" + idfsASCampaignPropertyName);
        var btnView = $("#btnASCampaignViewPicker_" + objectId + "_" + idfsASCampaignPropertyName);
        btnSelect.removeAttr('disabled');
        if (selectedId > 0) {
            btnView.removeAttr('disabled');
            btnClian.data("disabled", "false");
        } else {
            btnClian.data("disabled", "true");
        }
    },

    disableInlinePicker: function (objectId, idfsASCampaignPropertyName) {
        if (!asCampaign.isInlinePicker(objectId, idfsASCampaignPropertyName)) {
            return;
        }
        var btnSelect = $("#btnASCampaignSearchPicker_" + objectId + "_" + idfsASCampaignPropertyName);
        var btnClian = $("#btnASCampaignClian_" + objectId + "_" + idfsASCampaignPropertyName);
        var btnView = $("#btnASCampaignViewPicker_" + objectId + "_" + idfsASCampaignPropertyName);
        btnSelect.attr('disabled', 'disabled');
        btnView.attr('disabled', 'disabled');
        btnClian.data("disabled", "true");
    },

    onShowReportClick: function (showReportFunc) {
        detailPage.checkChanges(true,
            function () {
                bvDialog.showOkCancel(msgConfimation, bvDialog.messageText.savePrompt, function () {
                    detailPage.saveAndShowReport(showReportFunc);
                }, actions.emptyFunction);
            },
            showReportFunc
        );
    }
}