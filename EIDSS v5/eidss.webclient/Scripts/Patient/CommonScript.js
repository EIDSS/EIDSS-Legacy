function ShowPatientPicker(onPatientPickerSelectFunction, gridName, rootKey) {
    if (!onPatientPickerSelectFunction) {
        onPatientPickerSelectFunction = "CloseMessageWindow()";
    }
    else {
        onPatientPickerSelectFunction = onPatientPickerSelectFunction + '("' + gridName + '", "' + rootKey + '")';
    }
    var title = EIDSS.BvMessages['titlePersonsList'];
    ShowSearchPicker("../System/PatientPicker?onPatientPickerSelect=" + onPatientPickerSelectFunction, title);
}

function onPatientPickerSearchAndOrder() {
    SearchItemsAndUpdateGrid("../System/ReloadPatientPicker", "Message");
}

function onHumanContactedCasePersonPickerChanged(generatedGridName) {
    var gridId = GetContactedCasePersonGridId(generatedGridName);
    CloseEditWindowAndUpdateGrid(gridId, "../HumanCase/SetHumanContactedCasePerson");
}

function CloseHumanContactedCasePersonPicker(generatedGridName) {
    var gridId = GetContactedCasePersonGridId(generatedGridName);
    CloseMessageWindow();
    $('#' + gridId).data('tGrid').ajaxRequest();
    SelectFirstGridRow(gridId);    
}

function onContactedPersonPatientPickerSelect(generatedGridName, rootKey) {
    var selectedItemId = GetSelectedItemId();
    var gridId = GetContactedCasePersonGridId(generatedGridName);
    CloseEditWindowAndUpdateGrid(gridId, "../HumanCase/SetSelectedPatient?root=" + rootKey + "&selectedId=" + selectedItemId);
}

function GetContactedCasePersonGridId(generatedGridName) {
    var objectIdent = generatedGridName.substring(0, generatedGridName.lastIndexOf("_") + 1);
    var gridId = objectIdent + 'ContactedPerson';
    return gridId;
}