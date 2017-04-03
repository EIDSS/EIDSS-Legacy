var patient = {
    formNumber: "H03",

    showSearchPicker: function (onPatientSelectFunction, gridName, rootKey, strLastName) {
        if (!onPatientSelectFunction) {
            onPatientSelectFunction = "searchPicker.closePicker()";
        } else {
            onPatientSelectFunction = onPatientSelectFunction + '("' + gridName + '", "' + rootKey + '")';
        }
        var title = EIDSS.BvMessages['titlePersonsList'];
        var encodedLastName = encodeURIComponent(strLastName);
        searchPicker.show(bvUrls.getPatientPickerUrl() + "?onPatientPickerSelect=" + onPatientSelectFunction + "&strLastName=" + encodedLastName, title, patient.formNumber);
    },

    onPickerSelect: function (gridName, rootKey) {
        var selectedItemId = searchPicker.getSelectedIds();
        if (selectedItemId) {
            var url = bvUrls.getSetSelectedPatientUrl() + "?root=" + rootKey + "&selectedId=" + selectedItemId;
            bvGrid.saveAndCloseEditWindow(gridName, url);
        }else {
            searchPicker.closePicker();
        }
    },

    showContactedPersonGridEditWindow: function (id, listKey, gridName) {
        var url = bvUrls.getHumanContactedCasePersonPickerUrl() + "?key=" + listKey + "&name=" + gridName + "&id=" + id;
        var title = EIDSS.BvMessages['titleContactInformation'];
        bvGrid.showEditWindow(url, 830, 470, title);
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
        patient.showSearchPicker('patient.setPickerSelectedPatientAsRoot', "", elementForUpdateId, strLastName);
    },

    deleteLinkToRootHuman: function () {
        if ($(".inlinePatientPicker .requiredField").hasClass("readonlyField") == true) {
            return;
        }
        var elementForUpdateId = $("#hdnIdentField").val();
        var url = bvUrls.getDeleteLinkToRootHumanUrl();
        $.ajax({
            url: url,
            type: "POST",
            data: {
                root: elementForUpdateId
            },
            datatype: "json",
            success: function (result) {
                formRefresher.updateControls(result);
            }
        });
    },

    setPickerSelectedPatientAsRoot: function (gridName, elementForUpdateId) {
        // gridName is empty because there is not Grid for update in DetailsForm
        var selectedItemId = searchPicker.getSelectedIds();
        if (selectedItemId) {
            var url = bvUrls.getSetSelectedPatientAsRootUrl();
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
                    formRefresher.updateControls(result);
                    searchPicker.closePicker();
                }
            });
        } else {
            searchPicker.closePicker();
        }
    },
}