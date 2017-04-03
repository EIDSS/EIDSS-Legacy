
function ShowLabTestAmendmentHistoryPicker(id) {
    var request = GetUrlPrefixLanguage() + "LabSample/AmendTest?id=" + id;
    ShowMessageWindow(request, 630, 240, EIDSS.BvMessages['titleTestResultChange'], false);
}

function onLabTestAmendmentHistoryPickerChanged(o) {
    var ObjectIdent = o.substring(0, o.lastIndexOf("_") + 1);
    var contentData = $("#Message .t-window-content form").serialize(true);
    var url = GetUrlPrefixLanguage() + "LabSample/AmendTest";
    $.ajax({
        url: url,
        cache: false,
        dataType: "json",
        //contentType: "application/json; charset=utf-8",
        type: "POST",
        data: contentData,
        success: function (data) {
            var err = false;
            for (att in data.Values) {
                if (data.Values[att].typeName == "ErrorMessage") {
                    err = true;
                }
            }
            if (err) {
                ApplyChanges(data);
            }
            else {
                CloseMessageWindow();
                //window.location.reload();
                ApplyChanges(data);
                $('#' + ObjectIdent + 'AmendmentHistory').data('tGrid').ajaxRequest();
            }
        },
        error: function () {
            CloseMessageWindow();
        }
    });
}

function onSamplePickerChanged(o) {
    var ObjectIdent = o.substring(0, o.lastIndexOf("_") + 1);
    var gridId = ObjectIdent + 'Samples';
    CloseEditWindowAndUpdateGrid(gridId, GetUrlPrefixLanguage() + "LabSample/SetSample");
    //if ($("#OnlyReload").length > 0)
    //    ($("#OnlyReload")[0].value = 'true')
    //document.forms[1].submit();
}

function onCaseTestValidationsPickerChanged(o) {
    var ObjectIdent = o.substring(0, o.lastIndexOf("_") + 1);
    //alert(ObjectIdent);
    var contentData = $("#Message .t-window-content form").serialize(true);
    var url = GetUrlPrefixLanguage() + "LabSample/CaseTestValidationItemPicker";
    $.ajax({
        url: url,
        cache: false,
        dataType: "json",
        //contentType: "application/json; charset=utf-8",
        type: "POST",
        data: contentData,
        success: function (data) {
            var err = false;
            for (att in data.Values) {
                if (data.Values[att].typeName == "ErrorMessage") {
                    err = true;
                }
            }
            if (err) {
                ApplyChanges(data);
            }
            else {
                CloseMessageWindow();
                $('#' + ObjectIdent + 'CaseTestValidations').data('tGrid').ajaxRequest();
            }
        },
        error: function () {
            CloseMessageWindow();
            $('#' + ObjectIdent + 'CaseTestValidations').data('tGrid').ajaxRequest();
        }
    });
}

function onHumanSamplePickerChanged(o) {
    var ObjectIdent = o.substring(0, o.lastIndexOf("_") + 1);
    var gridId = ObjectIdent + 'Samples';
    CloseEditWindowAndUpdateGrid(gridId, GetUrlPrefixLanguage() + "LabSample/SetHumanSample");
}

function onVetSamplePickerChanged(o) {
    var ObjectIdent = o.substring(0, o.lastIndexOf("_") + 1);
    var gridId = ObjectIdent + 'Samples';
    CloseEditWindowAndUpdateGrid(gridId, GetUrlPrefixLanguage() + "LabSample/SetVetSample");
}

function onCaseTestPickerChanged(o) {
    var ObjectIdent = o.substring(0, o.lastIndexOf("_") + 1);
    var gridId = ObjectIdent + 'CaseTests';
    CloseEditWindowAndUpdateGridAndApplyChanges(gridId, GetUrlPrefixLanguage() + "LabSample/CaseTestItemPicker");
}

function onOfficeChanged(e) {
    //alert(e.value);
    if (e.previousValue == e.value) { return; }
    ModelFieldChangedCombobox(e);
    var ObjectIdent = e.target.id.substring(0, e.target.id.lastIndexOf("_") + 1);
    var FieldCollectedByPerson = $("#" + ObjectIdent + "FieldCollectedByPerson").data("tComboBox");
    FieldCollectedByPerson.value(null);
    FieldCollectedByPerson.reload();
}

function SearchSampleAndAddTest(sessionId, searchTextBoxId, notFoundMessageKey, newTestPath) {
    var url = GetUrlPrefixLanguage() + "LabSample/FindSampleByFieldId";
    var searchText = $("#" + searchTextBoxId).val();
    $.ajax({
        url: url,
        cache: false,
        dataType: "json",
        type: "GET",
        data: {
            idfSession: sessionId,
            fieldId: searchText
        },
        success: function (data) {
            if (data) {
                newTestPath = newTestPath + "&idfMaterial=" + data;
                ShowMessageWindow(newTestPath, 630, 340, EIDSS.BvMessages['titleTestResultDetails'], false);
            } else {
                ShowEidssErrorNotification(EIDSS.BvMessages[notFoundMessageKey], function () { });
            }
        }
    });
}

function onTestTypeChanged(e) {
    if (e.previousValue == e.value) { return; }
    ApplyContainer.argument = e;
    ApplyContainer.onAjaxSuccess = updateAfterTestTypeChanged;
    ModelFieldChangedCombobox(e);
}

function updateAfterTestTypeChanged(e) {
    var ObjectIdent = e.target.id.substring(0, e.target.id.lastIndexOf("_") + 1);
    var TestResultRef = $('#' + ObjectIdent + 'TestResultRef').data('tComboBox');
    TestResultRef.value(null);
    TestResultRef.reload();
}

function onAnimalSpeciesChanged(e) {
    if (e.previousValue == e.value) { return; }
    ApplyContainer.argument = e;
    ApplyContainer.onAjaxSuccess = updateAfterAnimalSpeciesChanged;
    ModelFieldChangedCombobox(e);
}

function updateAfterAnimalSpeciesChanged(e) {
    var ObjectIdent = e.target.id.substring(0, e.target.id.lastIndexOf("_") + 1);
    var animalAge = $('#' + ObjectIdent + 'AnimalAge').data('tComboBox');
    animalAge.value(null);
    animalAge.reload();
}