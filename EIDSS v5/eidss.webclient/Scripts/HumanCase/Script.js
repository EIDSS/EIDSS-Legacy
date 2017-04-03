var duplicateVariables = {
    'strLocalIdentifier': 'strLocalIdentifier',
    'strLastName': 'strLastName',
    'strFirstName': 'strFirstName',
    'strSecondName': 'strSecondName',
    'intPatientAge': 'intPatientAge',
    'HumanAgeType': 'idfsHumanAgeType',   
    'TentativeDiagnosis': 'idfsTentativeDiagnosis',
    'FinalDiagnosis' :'idfsFinalDiagnosis'
};

function CreateWindow(url, title) {    
    $.get(
                url,              
                function (data) {
                    $("#adjavantcontent").html(data);                 
                }
    );
    $("#dialog").dialog("option", "title", title);
    $("#dialog").dialog("open");
    $("#dialog").dialog("option", "buttons", null);
    //ShowEidssDialogSavePrompt(function () { alert('ok'); });
}

function GetDuplicates() {
    //get all parameters for search
    var val = null;
    var result = '?';
    for (key in duplicateVariables) {
        val = $("input[name$='" + key + "']");
        if (val && val.val()) {
            result += duplicateVariables[key] + '=' + escape(val.val()) + '&';
        }
    }
    var queryString = "";
    if (result.length > 1) {
        queryString = result.substring(0, result.length - 1);
    }
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/HumanCase/Duplicates" + queryString;
    var title = EIDSS.BvMessages['titleDuplicates'];
    ShowMessageWindow(url, 630, 600, title, false);
}

function ViewCase() {
    var id = GetSelectedItemId();
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/HumanCase/Details/" + id;
    window.location = url;
}   

function ShowHumanCasePicker() {
    ShowSearchPicker("../HumanCase/HumanCasePicker", EIDSS.BvMessages['titleHumanCaseList'] + ' (H01)');
}

function onHumanCasePickerSearchAndOrder() {
    SearchItemsAndUpdateGrid("../HumanCase/HumanCasePicker", "Message");
}

function onHumanCasePickerSelect() {
    var id = GetSelectedItemId();
    CloseMessageWindow();
    $("#idforselect").val(id);
    document.forms[0].submit();
}

function onHumanCaseTabSelect(e, itemId, tabStripName) {
    var activeTabContent = "#TabStrip1 .t-content.t-state-active ";
    if ($(activeTabContent + "#CaseClassificationFlexForm").length == 1 || $(activeTabContent + "#EpiLinksFlexForm").length == 1) {
        var contentData = $("form").serialize(true);
        var lang = GetSiteLanguage();
        var postUrl = "/" + lang + "/humanCase/StoreCase";
        $.ajax({
            url: postUrl,
            cache: false,
            dataType: "json",
            type: "POST",
            data: contentData,
            success: function (data) {
                ReloadTabContent(tabStripName, $(e.item), itemId);                
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(jqXHR.status);
            }
        });
    }
    else {
        ReloadTabContent(tabStripName, $(e.item), itemId);  
    }   
}

function ReloadTabContent(tabStripName, tab, itemId) {
    if (tabStripName != "TabStrip1") {
        return;
    }
    var tabIndex = tab.index();
    if (tabIndex == 3) {        
        showLoading();
        ReloadCCFlexForm('CaseClassificationFlexForm', itemId);
    }
    if (tabIndex == 4) {        
        showLoading();
        ReloadEpiFlexForm('EpiLinksFlexForm', itemId);
    }
}

function ReloadCCFlexForm(fname, itemId) {
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/HumanCase/GetCCFlexForm";
    reloadPartialDiv(url, fname, itemId);
}

function ReloadEpiFlexForm(fname, itemId) {
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/HumanCase/GetEpiFlexForm";
    reloadPartialDiv(url, fname, itemId);
}

function onTentativeDiagnosisChange(e) {
    var cbTentativeId = e.currentTarget.id;
    var cbFinalId = cbTentativeId.substring(0, cbTentativeId.lastIndexOf('_')) + "_FinalDiagnosis";
    var cbFinal = $("#" + cbFinalId).data("tComboBox");
    if (e.value != 0 && e.value == cbFinal.value()) {
        var cbTentative = $("#" + cbTentativeId).data("tComboBox");
        var previousValue = cbTentative.previousValue;
        cbTentative.dataBind(cbTentative.data, true);
        cbTentative.value(previousValue);
        ShowEidssErrorNotification(EIDSS.BvMessages['msgWrongDiagnosis'], function () { });    
    }
    else {
        ModelFieldChangedCombobox(e);
    }
}

function onFinalDiagnosisChange(e, idfCase) {    
    var cbFinalId = e.currentTarget.id;
    var cbTentativeId = cbFinalId.substring(0, cbFinalId.lastIndexOf('_')) + "_TentativeDiagnosis";
    var cbTentative = $("#" + cbTentativeId).data("tComboBox");
    var cbFinal = $("#" + cbFinalId).data("tComboBox");
    var previousValue = cbFinal.previousValue;
    if ((!previousValue || cbTentative.value() == "0") && e.value == "0") {
        return;
    }

    if (e.value != 0 && e.value == cbTentative.value()) {
        ShowEidssErrorNotification(EIDSS.BvMessages['msgWrongDiagnosis'], function () { });
        $("#DiagnosisChangedForPrevious").val("true");
        cbFinal.value(previousValue);             
    }
    else {
        var changedForPrevious = $("#DiagnosisChangedForPrevious");
        if (changedForPrevious && changedForPrevious.val() == "true") {            
            changedForPrevious.val("");
            return;
        }
        var isNewCaseHidden = $("#IsNewCase");
        var hasReason = $("#HasChangeDiagnosisReason");
        if (isNewCaseHidden && isNewCaseHidden.val() == "true" || hasReason && hasReason.val().toLowerCase() == "true") {
            ModelFieldChangedCombobox(e);            
            return;
        }
        var lang = GetSiteLanguage();
        var url = "/" + lang + "/HumanCase/DiagnosisChange?root=" + idfCase + "&cbFinalId=" + cbFinalId + "&previousDiagnosis=" + previousValue + "&newValue=" + e.value;
        var title = EIDSS.BvMessages['titleDiagnosisChange'];
        ShowMessageWindow(url, 300, 150, title, false); 
    }
}

function CancelChangeDiagnosis(cbFinalId, previousDiagnosis) {
    CloseMessageWindow();    
    var cbFinal = $("#" + cbFinalId).data("tComboBox");
    cbFinal.value(previousDiagnosis);
}

function onChangeDiagnosisReasonChange(idfCase, newDiagnosis) {
    var cbReason = $("#ChangeDiagnosisReason").data("tComboBox");
    var changeDiagnosisReason = cbReason.value();
    if (!changeDiagnosisReason) {
        ShowEidssErrorNotification(EIDSS.BvMessages['strChangeDiagnosisReason_msgId'], function () { });
        return;   
    }
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/HumanCase/SetNewDiagnosis";
    $.ajax({
        url: url,
        cache: false,
        type: "POST",
        data: {
            root: idfCase,
            newDiagnosis: newDiagnosis,
            changeDiagnosisReason: changeDiagnosisReason
        },
        datatype: "json",
        success: function (result) {
            ApplyChanges(result);
            CloseMessageWindow();
            $("#HasChangeDiagnosisReason").val("true");
        },
        error: function (data) {
        }
    });
}


function ReportHandler(ReportViewer) {
    AjaxFormSubmit(function (data) {
        ApplyChanges(data);

        if (!data.Values["ErrorMessage"]) {
            ReportViewer();
        }
    });
}


function HumanInvestigationReportClick() {
    checkChanges(
        function () {
            ApplyContainer.onAjaxSuccess = ShowCIHumanCaseReport;
            ShowEidssDialogSavePrompt(function () { ReportHandler(ShowCIHumanCaseReport); }); 
        },
        ShowCIHumanCaseReport
    );

}

function EmergencyNotificationReportClick() {
    checkChanges(
        function () {
            ApplyContainer.onAjaxSuccess = ShowENHumanCaseReport;
            ShowEidssDialogSavePrompt(function () { ReportHandler(ShowENHumanCaseReport); });
        },
        ShowENHumanCaseReport
    );

}

function onSaveClick() {
    checkChanges(
        function () {
            ShowEidssDialogSavePrompt(function () {
                AjaxFormSubmit(function (data) {
                    ApplyChanges(data);
                    $("#IsNewCase").val("0");
                });
            });
        },
       DoNothing
    );
}