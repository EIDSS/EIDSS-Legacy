
// custom actions

function DeleteTest(url) {
    var selecteditem = GetSelectedItemFromGrid();
    if ((selecteditem == null) || (selecteditem.length == 0)) return;
    ShowEidssDialogDeletePrompt(function () {
        selecteditem = GetSelectedItemFromGrid();
        var url1 = url + "?id=" + selecteditem;
        ActionDeleteExecution(url1); 
    });
}

function SelectTest(url) {
    var selecteditem = GetSelectedItemFromGrid();
    if ((selecteditem == null) || (selecteditem.length == 0)) return;
    url += "?id=" + selecteditem;
    OpenPopup(url, " ", 840, 670);
}

function EditTest(url) {
    var selecteditem = GetSelectedItemFromGrid();
    if ((selecteditem == null) || (selecteditem.length == 0)) return;
    url += "?id=" + selecteditem;
    OpenPopup(url, " ", 840, 670);
}

function EditSample(url) {
    var selecteditem = GetSelectedItemFromGrid();
    if ((selecteditem == null) || (selecteditem.length == 0)) return;
    url += "?id=" + selecteditem;
    OpenPopup(url, " ", 840, 550);
}


function ActionPreferencesExecution(url) {
    $.ajax({
        url: url,
        cache: false,
        dataType: "json",
        type: "GET",
        success: function (data) {
            //alert('complete');                  
        }
    });
}

function AddToPreferences(url) {
    var selecteditem = GetSelectedItemFromGrid();
    if ((selecteditem == null) || (selecteditem.length == 0)) return;
    ShowEidssDialog(msgConfimation, EIDSS.BvMessages['msgAddToPreferencesPrompt'], EIDSS.BvMessages['strAdd_Id'], 
    function () {
        selecteditem = GetSelectedItemFromGrid();
        var url1 = url + "?id=" + selecteditem;
        ActionPreferencesExecution(url1); 
    }, strCancel_Id);
}

function RemoveFromPreferences(url) {
    var selecteditem = GetSelectedItemFromGrid();
    if ((selecteditem == null) || (selecteditem.length == 0)) return;
    ShowEidssDialog(msgConfimation, EIDSS.BvMessages['msgRemoveFromPreferencesPrompt'], EIDSS.BvMessages['strRemove_Id'],
    function () {
        selecteditem = GetSelectedItemFromGrid();
        var url1 = url + "?id=" + selecteditem;
        ActionPreferencesExecution(url1);
    }, strCancel_Id);
}

function PaperForms(url) {
    NotImplemented();
}

function AmendTest(url) {
    ShowLabTestAmendmentHistoryPicker($("#idfTesting").val());
}

function EmergencyNotificationReport(url) {
    EmergencyNotificationReportClick(); // checkChanges(ShowHumanEmergencyNotificationOkCancelDialog, ShowENHumanCaseReport);        
}

function HumanAggregateCaseReport(url) {
    checkChanges(ShowHumanAggregateCaseOkCancelDialog, ShowHumanAggregateCaseReport);
}

function VetAggregateCaseReport(url) {
    checkChanges(ShowVetAggregateCaseOkCancelDialog, ShowVetAggregateCaseReport);
}

function VetAggregateActionReport(url) {
    checkChanges(ShowVetAggregateActionOkCancelDialog, ShowVetAggregateActionReport);
}

function ShowHumanEmergencyNotificationOkCancelDialog() {
    ShowEidssYesNoDialog(msgConfimation, EIDSS.BvMessages['msgSavePrompt'],
        function () { $("#ShowENHumanCaseReportClick").val('1'); ActionSaveExecution(); }, null);
}

function ShowHumanAggregateCaseOkCancelDialog() {
    ShowEidssYesNoDialog(msgConfimation, EIDSS.BvMessages['msgSavePrompt'],
        function () { $("#ShowHumanAggregateCaseReportClick").val('1'); ActionSaveExecution(); }, null);
}

function ShowVetAggregateCaseOkCancelDialog() {
    ShowEidssYesNoDialog(msgConfimation, EIDSS.BvMessages['msgSavePrompt'],
        function () { $("#ShowVetAggregateCaseReportClick").val('1'); ActionSaveExecution(); }, null);
}

function ShowVetAggregateActionOkCancelDialog() {
    ShowEidssYesNoDialog(msgConfimation, EIDSS.BvMessages['msgSavePrompt'],
        function () { $("#ShowVetAggregateActionReportClick").val('1'); ActionSaveExecution(); }, null);
}

function ShowENHumanCaseReport() {    
    $("#ShowENHumanCaseReportClick").val('');
    var caseId = $("#idfCase").val();
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/HumanCase/EmergencyNotificationReport" + "?id=" + caseId;
    OpenPopup(url, "");
}

function ShowHumanAggregateCaseReport() {
    $("#ShowHumanAggregateCaseReportClick").val('');
    var caseId = $("#idfAggrCase").val();
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/HumanAggregateCase/HumanAggregateCaseReport" + "?id=" + caseId;
    OpenPopup(url, "");
}

function ShowVetAggregateCaseReport() {
    $("#ShowVetAggregateCaseReportClick").val('');
    var caseId = $("#idfAggrCase").val();
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/VetAggregateCase/VetAggregateCaseReport" + "?id=" + caseId;
    OpenPopup(url, "");
}

function ShowVetAggregateActionReport() {
    $("#ShowVetAggregateActionReportClick").val('');
    var caseId = $("#idfAggrCase").val();
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/VetAggregateAction/VetAggregateActionReport" + "?id=" + caseId;
    OpenPopup(url, "");
}

function HumanInvestigationReport(url) {
    HumanInvestigationReportClick();
    //checkChanges(ShowHumanInvestigationReportOkCancelDialog, ShowCIHumanCaseReport);    
}

function ShowHumanInvestigationReportOkCancelDialog() {
    ShowEidssYesNoDialog(msgConfimation, EIDSS.BvMessages['msgSavePrompt'],
        function () { $("#ShowCIHumanCaseReportClick").val('1'); ActionSaveExecution(); }, null);
}

function ShowCIHumanCaseReport() {
    $("#ShowCIHumanCaseReportClick").val('');
    var caseId = $("#idfCase").val();
    var epiId = $("#EpiId").val();
    var csId = $("#CsId").val();
    var diagnosisId = $("#HumanCase_" + caseId + "_idfsDiagnosis").val();
    if (!diagnosisId) {
        diagnosisId = 0;
    }
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/HumanCase/HumanInvestigationReport" + "?caseId=" + caseId + "&epiId=" + epiId + "&csId=" + csId + "&diagnosisId=" + diagnosisId;
    OpenPopup(url, "");
}

function VetInvestigationReport(url) {
    checkChanges(ShowVetInvestigationReportOkCancelDialog, ShowCIVetCaseReport);    
}

function ShowVetInvestigationReportOkCancelDialog() {
    ShowEidssYesNoDialog(msgConfimation, EIDSS.BvMessages['msgSavePrompt'],
        function () { $("#ShowCIVetCaseReportClick").val('1'); ActionSaveExecution(); }, null);
}

function ShowCIVetCaseReport() {
    $("#ShowCIVetCaseReportClick").val('');
    var caseId = $("#idfCase").val();
    var diagnosisId = $("#VetCase_" + caseId + "_strIdfsDiagnosis").val();
    if (!diagnosisId) {
        diagnosisId = 0;
    }
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/VetCase/VetInvestigationReport" + "?caseId=" + caseId + "&diagnosisId=" + diagnosisId;
    OpenPopup(url, "");
}


function TestResultReport(url) {
    checkChanges(ShowTestResultReportOkCancelDialog, ShowTestResultReport);
}

function ShowTestResultReportOkCancelDialog() {
    ShowEidssYesNoDialog(msgConfimation, EIDSS.BvMessages['msgSavePrompt'],
        function () { $("#ShowTestResultReportClick").val('1'); ActionSaveExecution(); }, null);
}

function ShowTestResultReport() {
    $("#ShowTestResultReportClick").val('');
    var ObjID = $("#idfTesting").val();
    var CSObjID = $("#idfObservation").val();
    var TypeID = $("#idfsTestType").val();
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/LabSample/TestResultReport" + "?ObjID=" + ObjID + "&CSObjID=" + CSObjID + "&TypeID=" + TypeID;
    OpenPopup(url, "");
}


function AccessionInReport(url) {
    checkChanges(ShowAccessionInReportOkCancelDialog, ShowAccessionInReport);
}

function ShowAccessionInReportOkCancelDialog() {
    ShowEidssYesNoDialog(msgConfimation, EIDSS.BvMessages['msgSavePrompt'],
        function () { $("#ShowAccessionInReportClick").val('1'); ActionSaveExecution(); }, null);
}

function ShowAccessionInReport() {
    $("#ShowAccessionInReportClick").val('');
    var ObjID = $("#idfCase").val();
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/LabSample/AccessionInReport" + "?ObjID=" + ObjID;
    OpenPopup(url, "");
}


function onShowTestsReport(isHuman) {
    if (isHuman) {
        checkChanges(
            function () {
                ApplyContainer.onAjaxSuccess = ShowHumanTestsReport;
                ShowEidssDialogSavePrompt(function () { ReportHandler(ShowHumanTestsReport); });
            },
            ShowHumanTestsReport
        );
        //checkChanges(ShowHumanTestsReportOkCancelDialog, ShowHumanTestsReport);
    }
    else {
        checkChanges(
            function () {
                ApplyContainer.onAjaxSuccess = ShowVetTestsReport;
                ShowEidssDialogSavePrompt(function () { ReportHandler(ShowVetTestsReport); });
            },
            ShowVetTestsReport
        );
        
       // checkChanges(ShowVetTestsReportOkCancelDialog, ShowVetTestsReport);
    }
}

function ShowHumanTestsReportOkCancelDialog() {
    ShowEidssYesNoDialog(msgConfimation, EIDSS.BvMessages['msgSavePrompt'],
        function () { $("#ShowTestsReportClick").val('1'); ActionSaveExecution(); }, null);
}

function ShowVetTestsReportOkCancelDialog() {
    ShowEidssYesNoDialog(msgConfimation, EIDSS.BvMessages['msgSavePrompt'],
        function () { $("#ShowTestsReportClick").val('1'); ActionSaveExecution(); }, null);
}

function ShowHumanTestsReport() {
    ShowTestsReport(true);
}

function ShowVetTestsReport() {
    ShowTestsReport(false);
}

function ShowTestsReport(isHuman) {
    $("#ShowTestsReportClick").val('');
    var caseId = $("#idfCase").val();
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/System/TestsReport?id=" + caseId + "&isHuman=" + isHuman;
    OpenPopup(url, "");
}

function ReportAsSampleCollectedList() {
    checkChanges(ShowReportAsSampleCollectedListOkCancelDialog, ShowCIReportAsSampleCollectedList);
}

function ShowReportAsSampleCollectedListOkCancelDialog() {
    ShowEidssYesNoDialog(msgConfimation, EIDSS.BvMessages['msgSavePrompt'],
        function () { $("#ReportAsSampleCollectedListClick").val('1'); ActionSaveExecution(); }, null);
}

function ShowCIReportAsSampleCollectedList() {
    $("#ReportAsSampleCollectedListClick").val('');
    var id = $("#idfMonitoringSession").val();
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/ASSession/ReportAsSampleCollectedList" + "?id=" + id;
    OpenPopup(url, "");
}



function ReportAsSessionTests(url) {
    checkChanges(ShowReportAsSessionTestsOkCancelDialog, ShowCIReportAsSessionTests);
}

function ShowReportAsSessionTestsOkCancelDialog() {
    ShowEidssYesNoDialog(msgConfimation, EIDSS.BvMessages['msgSavePrompt'],
        function () { $("#ReportAsSessionTestsClick").val('1'); ActionSaveExecution(); }, null);
}

function ShowCIReportAsSessionTests() {
    $("#ReportAsSessionTestsClick").val('');
    var id = $("#idfMonitoringSession").val();
    var lang = GetSiteLanguage();
    var url1 = "/" + lang + "/ASSession/ReportAsSessionTests" + "?id=" + id;
    window.location = url1;
}


function HumanAccessionIn(url) {
    OpenDetailPage(url, true, true);
}
function VetAccessionIn(url) {
    OpenDetailPage(url, true, true);
}
function AsAccessionIn(url) {
    OpenDetailPage(url, true, true);
}
function VsAccessionIn(url) {
    OpenDetailPage(url, true, true);
}

function ShowGeneralCaseInvestigationForm() {
    var url = GetReportFilePath("General Case Investigation Form.pdf");
    OpenPopup(url, " ");
}

function ShowAvianDiseaseOutbreaksForm() {
    var url = GetReportFilePath("Investigation Form For Avian Disease Outbreaks.pdf");
    OpenPopup(url, " ");
}

function ShowLivestockDiseaseOutbreaksForm() {
    var url = GetReportFilePath("Investigation Form For Livestock Disease Outbreaks.pdf");
    OpenPopup(url, " ");
}

function GetReportFilePath(fileName) {
    var lang = GetSiteLanguage();
    var index = lang.lastIndexOf('-');
    var language = lang.substring(0, index).toLowerCase();
    var url = "/Content/PaperForms/" + language + "/" + fileName;
    return url;
}
