var person = {
    initInlinePicker: function (btnShowPickerId, btnClianId, btnViewId, isSearchButtonReadOnly, isClianButtonReadOnly, isViewButtonReadOnly) {
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
    },

    enableInlinePicker: function (objectId, idfsPatientPropertyName, selectedId) {
        var btnSelect = $("#btnPatientSearchPicker_" + objectId + "_" + idfsPatientPropertyName);
        var btnClian = $("#btnPatientClian_" + objectId + "_" + idfsPatientPropertyName);
        var btnView = $("#btnPatientViewPicker_" + objectId + "_" + idfsPatientPropertyName);
        if (btnSelect.length === 0 || btnClian.length === 0) {
            return;
        }
        btnSelect.removeAttr('disabled');
        if (selectedId > 0) {
            btnClian.data("disabled", "false");
        } else {
            btnClian.data("disabled", "true");
        }
    },

    disableInlinePicker: function (objectId, idfsPatientPropertyName) {
        var btnSelect = $("#btnPatientSearchPicker_" + objectId + "_" + idfsPatientPropertyName);
        var btnClian = $("#btnPatientClian_" + objectId + "_" + idfsPatientPropertyName);
        var btnView = $("#btnPatientViewPicker_" + objectId + "_" + idfsPatientPropertyName);
        if (btnSelect.length === 0 || btnClian.length === 0) {
            return;
        }
        btnSelect.attr('disabled', 'disabled');
        btnClian.data("disabled", "true");
    },

    showSearchPicker: function (objectId, idfsPatientPropertyName, strPatientPropertyName, showInInternalWindow) {
        var pickerUrl = bvUrls.getPersonPickerUrl() + "?objectId=" + objectId + "&idfsPatientPropertyName=" + idfsPatientPropertyName +
            "&strPatientPropertyName=" + strPatientPropertyName + "&showInInternalWindow=" + showInInternalWindow;
        var title = EIDSS.BvMessages['titlePersonsList'];
        if (showInInternalWindow.toLowerCase() != "true") {
            searchPicker.show(pickerUrl, title);
        } else {
            searchPicker.showInternal(pickerUrl, title);
        }
    },

    onSearchPickerSelect: function (objectId, idfsPatientPropertyName, strPatientPropertyName, showInInternalWindow) {
        var selectedItemId = searchPicker.getSelectedIds();
        if (selectedItemId) {
            person.onPickerValueChanged(objectId, idfsPatientPropertyName, strPatientPropertyName, selectedItemId, showInInternalWindow);
        } else {
            searchPicker.closePicker(showInInternalWindow);
        }
    },

    onPickerValueChanged: function (objectId, idfsPatientPropertyName, strPatientPropertyName, selectedItemId, showInInternalWindow) {
        if (!selectedItemId) {
            var btnClian = $("#btnPatientClian_" + objectId + "_" + idfsPatientPropertyName);
            if (btnClian.data("disabled") === "true") {
                return;
            }
        }

        var btnView = $("#btnPatientViewPicker_" + objectId + "_" + idfsPatientPropertyName);
        if (selectedItemId.toString() == '') {
            btnView.attr('disabled', 'disabled');
        } else {
            btnView.removeAttr('disabled');
        }

        var url = bvUrls.getSetPersonUrl();
        $.ajax({
            url: url,
            type: "POST",
            data: {
                objectId: objectId,
                idfsPatientPropertyName: idfsPatientPropertyName,
                strPatientPropertyName: strPatientPropertyName,
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

}
