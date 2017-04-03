function onOrganizationPickerSearchAndOrder(showInInternalWindow) {
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/System/OrganizationPicker";
    if (showInInternalWindow.toLowerCase() == "true") {
        SearchItemsAndUpdateGrid(url, "SearchPickerWindow");
    }
    else {
        SearchItemsAndUpdateGrid(url, "Message");
    }
}

function onOrganizationSearchPickerSelect(objectId, idfsOrganizationPropertyName, strOrganizationPropertyName,
    idfsEmployeePropertyName, strEmployeePropertyName, showInInternalWindow) {
    var selectedItemId = GetSelectedItemId();
    onOrganizationPickerValueChanged(objectId, idfsOrganizationPropertyName, strOrganizationPropertyName,
        idfsEmployeePropertyName, strEmployeePropertyName, selectedItemId, showInInternalWindow);
}

function ShowOrganizationSearchPicker(pickerUrl, showInInternalWindow) {
    var title = EIDSS.BvMessages['titleOrganizationList'] + ' (A06)';
    if (showInInternalWindow.toLowerCase() != "true") {
        ShowSearchPicker(pickerUrl, title);        
    }
    else {
        ShowInternalSearchPicker(pickerUrl, title);
    }    
}

function onOrganizationPickerValueChanged(objectId, idfsOrganizationPropertyName, strOrganizationPropertyName,
    idfsEmployeePropertyName, strEmployeePropertyName, selectedItemId, showInInternalWindow) {
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/System/SetSelectedOrganization";
    $.ajax({
        url: url,
        cache: false,
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
            ApplyChanges(result);
            CloseOrganizationPicker(showInInternalWindow);
            var btnSelectEmployee = $("#btnEmpSearchPicker_" + objectId + "_" + idfsEmployeePropertyName);
            var btnClianEmployee = $("#btnEmpClian_" + objectId + "_" + idfsEmployeePropertyName);
            var btnAddEmployee = $("#btnEmpAddNew_" + objectId + "_" + idfsEmployeePropertyName);
            if (btnSelectEmployee.length == 1 && btnClianEmployee.length == 1 && btnAddEmployee.length == 1) {
                if (selectedItemId == "") {
                    btnSelectEmployee.attr('disabled', 'disabled');
                    btnClianEmployee.attr('disabled', 'disabled');
                    btnAddEmployee.attr('disabled', 'disabled');
                }
                else {
                    btnSelectEmployee.removeAttr('disabled');
                    btnClianEmployee.attr('disabled', 'disabled');
                    btnAddEmployee.removeAttr('disabled');
                }
            }
        },
        error: function (data) {
        }
    });
}

function CloseOrganizationPicker(showInInternalWindow) {
    if (showInInternalWindow.toLowerCase() != "true") {
        CloseMessageWindow();
    }
    else {
        CloseWindow("SearchPickerWindow");
    }
}

