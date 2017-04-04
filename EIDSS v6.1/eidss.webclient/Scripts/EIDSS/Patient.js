var patient = {
    formNumber: "H03",

    showSearchPicker: function (onPatientSelectFunction, gridName, rootKey, strLastName, PersonIDType, strPersonID) {
        if (!onPatientSelectFunction) {
            onPatientSelectFunction = "searchPicker.closePicker()";
        } else {
            onPatientSelectFunction = onPatientSelectFunction + '("' + gridName + '", "' + rootKey + '")';
        }
        var title = EIDSS.BvMessages['titlePersonsList'];
        var url = bvUrls.getPatientPickerUrl({onPatientPickerSelect: onPatientSelectFunction});
        if (strLastName != undefined && strLastName != "") {
            var encodedLastName = encodeURIComponent(strLastName);
            url = url + "&strLastName=" + encodedLastName;
        }
        if (PersonIDType != undefined && PersonIDType != "" && strPersonID != undefined && strPersonID != "") {
            url = url + "&PersonIDType=" + PersonIDType;
        }
        if (strPersonID != undefined && strPersonID != "") {
            url = url + "&strPersonID=" + strPersonID;
        }
        searchPicker.show(url, title, patient.formNumber);
    },

    onPickerSelect: function (gridName, rootKey) {
        var selectedItemId = searchPicker.getSelectedIds();
        if (selectedItemId) {
            var url = bvUrls.getSetSelectedPatientUrl({root: rootKey, selectedId: selectedItemId});
            bvGrid.saveAndCloseEditWindow(gridName, url);
        }else {
            searchPicker.closePicker();
        }
    },

    showContactedPersonGridEditWindow: function (id, listKey, gridName) {
        var url = bvUrls.getHumanContactedCasePersonPickerUrl({key: listKey, name: gridName, id: id});
        var title = EIDSS.BvMessages['titleContactInformation'];
        bvGrid.showEditWindow(url, 830, 470, title, "H04");
    },

    saveAndCloseContactedPersonGridEditWindow: function (caseObjectIdent) {
        var ident = caseObjectIdent.substring(0, caseObjectIdent.lastIndexOf("_") + 1);
        var gridId = ident + 'ContactedPerson';
        bvGrid.saveAndCloseEditWindow(gridId, bvUrls.getSetHumanContactedCasePersonUrl());
    },

    showRootHumanSearchPicker: function () {
        if ($(".inlinePatientPicker .requiredField").hasClass("readonlyField") == true) {
            return;
        }
        var elementForUpdateId = $("#hdnIdentField").val();
        var strLastName = $(".inlinePatientPicker .requiredField").val();
        var PersonIDType = $("input[id*='PersonIDType']").val();
        var strPersonID = $("input[id*='strPersonID']").val();
        patient.showSearchPicker('patient.setPickerSelectedPatientAsRoot', "", elementForUpdateId, strLastName, PersonIDType, strPersonID);
    },

    deleteLinkToRootHuman: function () {
        if ($(".inlinePatientPicker .requiredField").hasClass("readonlyField") == true) {
            return;
        }
        var elementForUpdateId = $("#hdnIdentField").val();

        /*$.bvPostWithShowLoading(bvUrls.getDeleteLinkToRootHumanUrl(), 
            { root: elementForUpdateId },
            function (result) {
                formRefresher.updateControls(result);
            });*/
        
        var url = bvUrls.getDeleteLinkToRootHumanUrl();
        showLoading();
        $.ajax({
            url: url,
            type: "POST",
            data: {
                root: elementForUpdateId
            },
            datatype: "json",
            success: function (result) {
                hideLoading();
                formRefresher.updateControls(result);
                patient.setRegistrationAddressFieldsVisible(result);
            },
            error: function () {
                hideLoading();
            }
        });
    },

    setPickerSelectedPatientAsRoot: function (gridName, elementForUpdateId) {
        // gridName is empty because there is not Grid for update in DetailsForm
        var selectedItemId = searchPicker.getSelectedIds();
        if (selectedItemId) {
            var url = bvUrls.getSetSelectedPatientAsRootUrl();
            showLoading();
            $.ajax({
                url: url,
                type: "POST",
                //async: false,
                data: {
                    root: elementForUpdateId,
                    selectedId: selectedItemId
                },
                datatype: "json",
                success: function (result) {
                    hideLoading();
                    formRefresher.updateControls(result);
                    patient.setRegistrationAddressFieldsVisible(result);
                    searchPicker.closePicker();
                },
                error: function () {
                    hideLoading();
                }
            });
        } else {
            searchPicker.closePicker();
        }
    },

    setRegistrationAddressFieldsVisible: function (data) {
        for (var item in data.Values) {
            if (item.startsWith("RegistrationAddress_") && item.endsWith("_Country")) {
                address.onForeignCountryChanged(item, data);
                break;
            }
        }
    },

    onFindInPersonIdentityServiceClick: function () {
        var idfCase = $("#idfCase").val();
        var idfHuman = $("#idfHuman").val();
        var idfContactedCasePerson = $("#idfContactedCasePerson").val();
        if (idfCase === undefined) idfCase = 0;
        if (idfHuman === undefined) idfHuman = 0;
        if (idfContactedCasePerson === undefined) idfContactedCasePerson = 0;
        var url = bvUrls.getPatientFindInPersonIdentityServiceUrl({ idfCase: idfCase, idfHuman: idfHuman, idfContactedCasePerson: idfContactedCasePerson });

        showLoading();
        $.ajax({
            url: url,
            //dataType: "json",
            type: "GET",
            success: function (data) {
                hideLoading();
                var hasError = formRefresher.hasError(data);
                if (!hasError) {
                    var title = EIDSS.BvMessages['btTitleFindInPersonIdentityServiceGG'];
                    bvPopup.showDefaultContent(data, title, "H21", 300, 150, "PopupWindow2");
                } else {
                    formRefresher.updateControls(data);
                }
            },
            error: function () {
                hideLoading();
            }
        });

    },

    onFindInPersonIdentityServiceSearchClick: function () {
        var url = bvUrls.getPatientFindInPersonIdentityServiceUrl();
        var contentData = bvPopup.getWindowDataByName("PopupWindow2");
        contentData = EscapeHtmlGtLtOnly(contentData);

        showLoading();
        $.ajax({
            url: url,
            dataType: "json",
            type: "POST",
            data: contentData,
            success: function (data) {
                hideLoading();
                var hasError = formRefresher.hasError(data);
                if (!hasError) {
                    bvPopup.closeById('PopupWindow2');
                }
                formRefresher.updateControls(data);
            },
            error: function () {
                hideLoading();
            }
        });

    },

}


