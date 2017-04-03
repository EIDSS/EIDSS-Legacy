var organization = (function () {
    var formNumber = "A06";
    
    return {
        initInlinePicker: function (btnShowPickerId, btnClianId, isSearchButtonReadOnly, isClianButtonReadOnly, pickerWrapId) {
            var btnShowPicker = $("#" + btnShowPickerId);
            var btnClian = $("#" + btnClianId);
            if (isSearchButtonReadOnly.toString().toLowerCase() == 'true') {
                btnShowPicker.attr('disabled', 'disabled');
            } else {
                btnShowPicker.removeAttr('disabled');
            }
            if (isClianButtonReadOnly.toString().toLowerCase() == 'true') {
                btnClian.data("disabled", "true");
            } else {
                btnClian.data("disabled", "false");
            }
            
            $("#" + pickerWrapId + ":has(.requiredField)").find(".pickerWrap").addClass('requiredField');
        },
        
        isInlinePicker: function (objectId, idfsOrganizationPropertyName) {
            var mainPickerId = "divOrgSearchPicker_" + objectId + "_" + idfsOrganizationPropertyName;
            if ($("#" + mainPickerId).length) {
                return true;
            }
            return false;
        },

        enableInlinePicker: function (objectId, idfsOrganizationPropertyName, selectedId) {
            if (!organization.isInlinePicker(objectId, idfsOrganizationPropertyName)) {
                return;
            }
            var btnSelect = $("#btnOrgSearchPicker_" + objectId + "_" + idfsOrganizationPropertyName);
            var btnClian = $("#btnOrgClian_" + objectId + "_" + idfsOrganizationPropertyName);
            btnSelect.removeAttr('disabled');
            if (selectedId > 0) {
                btnClian.data("disabled", "false");
            } else {
                btnClian.data("disabled", "true");
            }
        },

        disableInlinePicker: function (objectId, idfsOrganizationPropertyName) {
            if (!organization.isInlinePicker(objectId, idfsOrganizationPropertyName)) {
                return;
            }
            var btnSelect = $("#btnOrgSearchPicker_" + objectId + "_" + idfsOrganizationPropertyName);
            var btnClian = $("#btnOrgClian_" + objectId + "_" + idfsOrganizationPropertyName);
            btnSelect.attr('disabled', 'disabled');
            btnClian.data("disabled", "true");
        },
        
        showInlinePicker: function (objectId, idfsOrganizationPropertyName) {
            if (!organization.isInlinePicker(objectId, idfsOrganizationPropertyName)) {
                return;
            }
            var mainPickerId = "divOrgSearchPicker_" + objectId + "_" + idfsOrganizationPropertyName;
            var label = $("label[for=" + idfsOrganizationPropertyName + "]");
            $("#" + mainPickerId).removeClass("invisible");
            label.removeClass("invisible");
        },

        hideInlinePicker: function (objectId, idfsOrganizationPropertyName) {
            if (!organization.isInlinePicker(objectId, idfsOrganizationPropertyName)) {
                return;
            }
            var mainPickerId = "divOrgSearchPicker_" + objectId + "_" + idfsOrganizationPropertyName;
            var label = $("label[for=" + idfsOrganizationPropertyName + "]");
            $("#" + mainPickerId).addClass("invisible");
            label.addClass("invisible");
        },

        showSearchPicker: function (objectId, idfsOrganizationPropertyName, strOrganizationPropertyName,
            idfsEmployeePropertyName, strEmployeePropertyName, showInInternalWindow, HACode) {
            var pickerUrl = bvUrls.getOrganizationPickerUrl() + "?objectId=" + objectId + "&idfsOrganizationPropertyName=" + idfsOrganizationPropertyName +
            "&strOrganizationPropertyName=" + strOrganizationPropertyName + "&idfsEmployeePropertyName=" + idfsEmployeePropertyName +
                "&strEmployeePropertyName=" + strEmployeePropertyName + "&showInInternalWindow=" + showInInternalWindow +
                "&HACode=" + HACode;
            var title = EIDSS.BvMessages['titleOrganizationList'];
            if (showInInternalWindow.toLowerCase() != "true") {
                searchPicker.show(pickerUrl, title, formNumber);
            } else {
                searchPicker.showInternal(pickerUrl, idfsOrganizationPropertyName);
            }
        },
        
        onSearchPickerSelect: function (objectId, idfsOrganizationPropertyName, strOrganizationPropertyName,
        idfsEmployeePropertyName, strEmployeePropertyName, showInInternalWindow) {
            var selectedItemId = searchPicker.getSelectedIds();
            if (selectedItemId) {
                organization.onPickerValueChanged(objectId, idfsOrganizationPropertyName, strOrganizationPropertyName,
                    idfsEmployeePropertyName, strEmployeePropertyName, selectedItemId, showInInternalWindow);
            } else {
                searchPicker.closePicker(showInInternalWindow);
            }
        },

        onPickerValueChanged: function (objectId, idfsOrganizationPropertyName, strOrganizationPropertyName,
        idfsEmployeePropertyName, strEmployeePropertyName, selectedItemId, showInInternalWindow) {
            if(!selectedItemId){
                var btnClian = $("#btnOrgClian_" + objectId + "_" + idfsOrganizationPropertyName);
                if (btnClian.data("disabled") === "true") {
                    return;
                }
            }
            var url = bvUrls.getSetOrganizationUrl();
            $.ajax({
                url: url,
                type: "POST",
                data: {
                    objectId: objectId,
                    idfsOrganizationPropertyName: idfsOrganizationPropertyName,
                    strOrganizationPropertyName: strOrganizationPropertyName,
                    idfsEmployeePropertyName: idfsEmployeePropertyName,
                    strEmployeePropertyName: strEmployeePropertyName,
                    selectedItemId: selectedItemId,
                    showInInternalWindow: showInInternalWindow
                },
                datatype: "json",
                success: function (result) {
                    formRefresher.updateControls(result);
                    if (selectedItemId) {
                        searchPicker.closePicker(showInInternalWindow, idfsOrganizationPropertyName);
                    }
                    organization.updateEmployeeButtons(objectId, idfsEmployeePropertyName, selectedItemId);
                }
            });
        },

        updateEmployeeButtons: function (objectId, idfsEmployeePropertyName, selectedOrganizationId) {
            var btnSelectEmployee = $("#btnEmpSearchPicker_" + objectId + "_" + idfsEmployeePropertyName);
            var btnClianEmployee = $("#btnEmpClian_" + objectId + "_" + idfsEmployeePropertyName);
            var btnAddEmployee = $("#btnEmpAddNew_" + objectId + "_" + idfsEmployeePropertyName);
            if (btnSelectEmployee.length == 1 && btnClianEmployee.length == 1 && btnAddEmployee.length == 1) {
                if (selectedOrganizationId == "") {
                    btnSelectEmployee.attr('disabled', 'disabled');
                    btnClianEmployee.data("disabled", "true");
                    btnAddEmployee.attr('disabled', 'disabled');
                } else {
                    btnSelectEmployee.removeAttr('disabled');
                    btnClianEmployee.data("disabled", "true");
                    btnAddEmployee.removeAttr('disabled');
                }
            }
        }
    };
})();