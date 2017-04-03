function onEmployeePickerSearchAndOrder(objectId, idfsOrganizationPropertyName, showInInternalWindow) {
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/System/EmployeePicker?objectId=" + objectId + "&idfsOrganizationPropertyName=" + idfsOrganizationPropertyName;
    if (showInInternalWindow.toLowerCase() == "true") {
        SearchItemsAndUpdateGrid(url, "SearchPickerWindow");
    }
    else {
        SearchItemsAndUpdateGrid(url, "Message");
    }
}

function onEmployeeSearchPickerSelect(objectId, idfsEmployeePropertyName, strEmployeePropertyName, idfsOrganizationPropertyName, showInInternalWindow) {
    var selectedItemId = GetSelectedItemId();
    onEmployeePickerValueChanged(objectId, idfsEmployeePropertyName, strEmployeePropertyName, selectedItemId, showInInternalWindow);
}

function ShowEmployeeSearchPicker(pickerUrl, showInInternalWindow) {
    var title = EIDSS.BvMessages['titleEmployeeList'] + ' (A08)';
    if (showInInternalWindow.toLowerCase() != "true") {
        ShowSearchPicker(pickerUrl, title);        
    }
    else {
        ShowInternalSearchPicker(pickerUrl, title);
    }    
}

function onEmployeePickerValueChanged(objectId, idfsEmployeePropertyName, strEmployeePropertyName, selectedItemId, showInInternalWindow) {
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/System/SetSelectedEmployee";
    $.ajax({
        url: url,
        cache: false,
        type: "POST",
        data: {
            objectId: objectId,
            idfsEmployeePropertyName: idfsEmployeePropertyName,
            strEmployeePropertyName: strEmployeePropertyName,
            selectedItemId: selectedItemId
        },
        datatype: "json",
        success: function (result) {
            ApplyChanges(result);
            CloseEmployeePicker(showInInternalWindow);
        },
        error: function (data) {
        }
    });
}

function CloseEmployeePicker(showInInternalWindow) {
    if (showInInternalWindow.toLowerCase() != "true") {
        CloseMessageWindow();
    }
    else {
        CloseWindow("SearchPickerWindow");
    }
}

function ShowEmployeeCreator(url, showInInternalWindow) {
    var title = EIDSS.BvMessages['titleEmployeeDetails'] + ' (A09)';
    if (showInInternalWindow.toLowerCase() != "true") {
        ShowMessageWindow(url, 450, 280, title, false);  
    }
    else {
        ShowInternalModalWindow("EmployeeCreator", url, 450, 280, title, false);         
    }
}

function CloseEmployeeCreator(showInInternalWindow) {
    if (showInInternalWindow.toLowerCase() != "true") {
        CloseMessageWindow();
    }
    else {
        CloseWindow("EmployeeCreator");
    }
}


function onEmployeeCreatorOkClick(newEmployeeId, objectId, idfsEmployeePropertyName, strEmployeePropertyName, idfsOrganizationPropertyName, showInInternalWindow) {
    var windowName;
    if (showInInternalWindow.toLowerCase() != "true") {
        windowName = "Message";
    }
    else {
        windowName = "EmployeeCreator";
    }
    var contentData = $("#" + windowName + " .t-window-content form").serialize(true);
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/Employee/AddNewEmployee";
    $.ajax({
        url: postUrl,
        cache: false,
        dataType: "json",        
        type: "POST",
        data: contentData,
        success: function (data) {
            var err = false;
            if (data && data.Values) {
                for (att in data.Values) {
                    if (data.Values[att].typeName == "ErrorMessage") {
                        err = true;
                    }
                }
            }
            if (err) {
                ApplyChanges(data);
            }
            else {
                var url = "/" + lang + "/System/SetSelectedEmployee";
                $.ajax({
                    url: url,
                    cache: false,
                    type: "POST",
                    data: {
                        objectId: objectId,
                        idfsEmployeePropertyName: idfsEmployeePropertyName,
                        strEmployeePropertyName: strEmployeePropertyName,
                        selectedItemId: newEmployeeId
                    },
                    datatype: "json",
                    success: function (result) {
                        ApplyChanges(result);
                        CloseWindow(windowName);
                    },
                    error: function (data) {
                        CloseWindow(windowName);    
                    }
                });
            }
        },
        error: function () {
            CloseWindow(windowName);            
        }
    });
}
