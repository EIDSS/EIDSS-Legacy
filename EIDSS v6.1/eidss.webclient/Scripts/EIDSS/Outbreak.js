var outbreak = (function () {

    var lastI = -1;
    
    return {
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

        isInlinePicker: function (objectId, idfsOutbreakPropertyName) {
            var mainPickerId = "divOutbreakSearchPicker_" + objectId + "_" + idfsOutbreakPropertyName;
            if ($("#" + mainPickerId).length) {
                return true;
            }
            return false;
        },

        enableInlinePicker: function (objectId, idfsOutbreakPropertyName, selectedId) {
            if (!outbreak.isInlinePicker(objectId, idfsOutbreakPropertyName)) {
                return;
            }
            var btnSelect = $("#btnOutbreakSearchPicker_" + objectId + "_" + idfsOutbreakPropertyName);
            var btnClian = $("#btnOutbreakClian_" + objectId + "_" + idfsOutbreakPropertyName);
            var btnView = $("#btnOutbreakViewPicker_" + objectId + "_" + idfsOutbreakPropertyName);
            btnSelect.removeAttr('disabled');
            if (selectedId > 0) {
                btnView.removeAttr('disabled');
                btnClian.data("disabled", "false");
            } else {
                btnClian.data("disabled", "true");
            }
        },

        disableInlinePicker: function (objectId, idfsOutbreakPropertyName) {
            if (!outbreak.isInlinePicker(objectId, idfsOutbreakPropertyName)) {
                return;
            }
            var btnSelect = $("#btnOutbreakSearchPicker_" + objectId + "_" + idfsOutbreakPropertyName);
            var btnClian = $("#btnOutbreakClian_" + objectId + "_" + idfsOutbreakPropertyName);
            var btnView = $("#btnOutbreakViewPicker_" + objectId + "_" + idfsOutbreakPropertyName);
            btnSelect.attr('disabled', 'disabled');
            btnView.attr('disabled', 'disabled');
            btnClian.data("disabled", "true");
        },

        showSearchPicker: function (objectId, idfsOutbreakPropertyName, strOutbreakPropertyName, showInInternalWindow) {
            var pickerUrl = bvUrls.getOutbreakPickerUrl({
                objectId: objectId,
                idfsOutbreakPropertyName: idfsOutbreakPropertyName,
                strOutbreakPropertyName: strOutbreakPropertyName,
                showInInternalWindow: showInInternalWindow
            });
            var title = EIDSS.BvMessages['titleOutbreakList'];
            if (showInInternalWindow.toLowerCase() != "true") {
                searchPicker.show(pickerUrl, title, "C10");
            } else {
                searchPicker.showInternal(pickerUrl, title);
            }
        },
        
        onSearchPickerSelect: function (objectId, idfsOutbreakPropertyName, strOutbreakPropertyName, showInInternalWindow) {
            var selectedItemId = searchPicker.getSelectedIds();
            if (selectedItemId) {
                outbreak.onPickerValueChanged(objectId, idfsOutbreakPropertyName, strOutbreakPropertyName, selectedItemId, showInInternalWindow);
            } else {
                searchPicker.closePicker(showInInternalWindow);
            }
        },


        onPickerValueChanged: function (objectId, idfsOutbreakPropertyName, strOutbreakPropertyName, selectedItemId, showInInternalWindow) {
            if(!selectedItemId){
                var btnClian = $("#btnOutbreakClian_" + objectId + "_" + idfsOutbreakPropertyName);
                if (btnClian.data("disabled") === "true") {
                    return;
                }

                bvDialog.showYesNo(msgConfimation,
                    EIDSS.BvMessages['msgRemoveCaseFromOutbreak'],
                    function () {
                        outbreak.doPickerValueChanged(objectId, idfsOutbreakPropertyName, strOutbreakPropertyName, selectedItemId, showInInternalWindow);
                    },
                    function () {
                    });
                return;
            }
            
            outbreak.doPickerValueChanged(objectId, idfsOutbreakPropertyName, strOutbreakPropertyName, selectedItemId, showInInternalWindow);
        },

        doPickerValueChanged: function (objectId, idfsOutbreakPropertyName, strOutbreakPropertyName, selectedItemId, showInInternalWindow) {
            var btnView = $("#btnOutbreakViewPicker_" + objectId + "_" + idfsOutbreakPropertyName);
            if (selectedItemId.toString() == '') {
                btnView.attr('disabled', 'disabled');
            } else {
                btnView.removeAttr('disabled');
            }

            var url = bvUrls.getSetOutbreakUrl();
            $.ajax({
                url: url,
                type: "POST",
                data: {
                    objectId: objectId,
                    idfsOutbreakPropertyName: idfsOutbreakPropertyName,
                    strOutbreakPropertyName: strOutbreakPropertyName,
                    selectedItemId: selectedItemId,
                    showInInternalWindow: showInInternalWindow
                },
                datatype: "json",
                success: function (result) {
                    formRefresher.updateControls(result);
                    if (selectedItemId) {
                        searchPicker.closePicker(showInInternalWindow);
                    }
                }
            });
        },


        setPrimaryCase: function (objectId, caseId) {
            //var btnView = $("#btnPrimaryCasePickerView_" + objectId + "_strPrimaryCase");
            //btnView.attr('disabled', 'disabled');

            /*$.bvPost(bvUrls.getOutbreakSetPrimaryCaseUrl(),
                { objectId: objectId, caseId: caseId },
                function (result) {
                    formRefresher.updateControls(result);
                }
            );*/
            var url = bvUrls.getOutbreakSetPrimaryCaseUrl();
            $.ajax({
                url: url,
                type: "POST",
                data: {
                    objectId: objectId,
                    caseId: caseId
                },
                datatype: "json",
                success: function (result) {
                    formRefresher.updateControls(result);
                }
            });
        },

        viewPrimaryCase: function (objectId, idfsCaseType) {
            if (objectId && objectId != 0 && objectId != "") {
                if (idfsCaseType == 10012001) {
                    ActionEditHumanCase(objectId);
                } else if (idfsCaseType == 10012006) {
                    ActionEditVectorSession(objectId);
                } else {
                    ActionEditVetCase(objectId);
                }
            }
        },


        showHumanCaseSearchPicker: function (objectId, functionName, isMultiSelection, showInInternalWindow) {
            var pickerUrl = bvUrls.getHumanCasePickerForOutbreakUrl({
                objectId: objectId,
                functionName: functionName,
                isMultiSelection: isMultiSelection,
                showInInternalWindow: showInInternalWindow
            });
            var title = EIDSS.BvMessages['titleHumanCaseList'];
            if (showInInternalWindow.toLowerCase() != "true") {
                searchPicker.show(pickerUrl, title, "H01");
            } else {
                searchPicker.showInternal(pickerUrl, title);
            }
        },

        showVetCaseSearchPicker: function (objectId, functionName, isMultiSelection, showInInternalWindow) {
            var pickerUrl = bvUrls.getVetCasePickerForOutbreakUrl({
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

        showVsSessionSearchPicker: function (objectId, functionName, isMultiSelection, showInInternalWindow) {
            var pickerUrl = bvUrls.getVsSessionPickerForOutbreakUrl({
                objectId: objectId,
                functionName: functionName,
                isMultiSelection: isMultiSelection,
                showInInternalWindow: showInInternalWindow
            });
            var title = EIDSS.BvMessages['titleVsSessionList'];
            if (showInInternalWindow.toLowerCase() != "true") {
                searchPicker.show(pickerUrl, title, "W01");
            } else {
                searchPicker.showInternal(pickerUrl, title);
            }
        },

        showHumanCasePicker: function (outbreakId) {
            outbreak.showHumanCaseSearchPicker(outbreakId, "outbreak.onCasePickerSelect", "true", "false");
        },

        showVetCasePicker: function (outbreakId) {
            outbreak.showVetCaseSearchPicker(outbreakId, "outbreak.onCasePickerSelect", "true", "false");
        },

        showVSSessionPicker: function (outbreakId) {
            outbreak.showVsSessionSearchPicker(outbreakId, "outbreak.onCasePickerSelect", "true", "false");
        },

        onCasePickerSelect: function (outbreakId, showInInternalWindow) {
            var selectedItemIds = searchPicker.getSelectedIds();
            if (selectedItemIds) {
                var ids = selectedItemIds.split(",");
                lastI = -1;
                outbreak.onPickerCaseChanged(outbreakId, showInInternalWindow, ids, 0);
                searchPicker.closePicker(showInInternalWindow);
                var gridId = $("#OutbreakCaseGridName").val();
                bvGrid.reloadById(gridId);
            } else {
                searchPicker.closePicker(showInInternalWindow);
            }
        },

        onPickerCaseChanged: function (outbreakId, showInInternalWindow, ids, i) {
            if (i < ids.length && lastI != i) {
                var url = bvUrls.getAddCaseToOutbreakUrl();
                var selectedItemId = ids[i];
                $.ajax({
                    url: url,
                    type: "POST",
                    async: false,
                    data: {
                        outbreakId: outbreakId,
                        caseId: selectedItemId
                    },
                    datatype: "json",
                    success: function(result) {
                        var onClose = function() {
                            outbreak.onPickerCaseChanged(outbreakId, showInInternalWindow, ids, i + 1);
                        };
                        lastI = i;
                        formRefresher.updateControls(result, onClose);
                        if (!formRefresher.hasMessage(result)) {
                            onClose();
                        }
                    }
                });
            }
        },

        showOutbreakCase: function (id, listKey, gridName) {
            var url = bvUrls.getSystemDetailsUrl({id: id});
            bvWindow.show(url, " ");
        },

        showOutbreakNote: function (id, listKey, gridName) {
            var url = bvUrls.getOutbreakNotePickerUrl({key: listKey, name: gridName, id: id});
            bvGrid.showEditWindow(url, 730, 220, EIDSS.BvMessages['titleOutbreakNote'], "C16");
        },

        saveAndCloseOutbreakNoteGridEditWindow: function (gridName) {
            var ident = gridName.substring(0, gridName.lastIndexOf("_") + 1);
            var gridId = ident + 'Notes';
            bvGrid.saveAndCloseEditWindow(gridId, bvUrls.getSetOutbreakNoteUrl());
        },

        onOutbreakReportClick: function () {
            detailPage.onShowReportClick(outbreak.showOutbreakReport);
        },

        showOutbreakReport: function () {
            var outbreakId = $("#idfOutbreak").val();
            var url = bvUrls.getOutbreakReportUrl({id: outbreakId});
            detailPage.openReport(url);
        },

        deleteCase: function (id, listKey, gridName, type) {
            bvDialog.showDeletePrompt(function () {
                outbreak.doDeleteRow(id, listKey, gridName, type);
            });
        },

        doDeleteRow: function (id, listKey, gridName, type) {
            var url = bvUrls.getDeleteCaseToOutbreakUrl();
            $.ajax({
                url: url,
                dataType: "json",
                type: "POST",
                data: {
                    outbreakId: listKey,
                    caseId: id
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

    };
})();