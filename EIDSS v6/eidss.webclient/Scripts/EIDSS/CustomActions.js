function EmergencyNotificationReport() {
    humanCase.onENReportClick();
}

function HumanInvestigationReport() {
    humanCase.onHIReportClick();
}

function VetInvestigationReport() {
    vetCase.onVIReportClick();
}

function HumanAggregateCaseReport() {
    aggregateCase.onHumanAggrCaseReportClick();
}

function VetAggregateCaseReport() {
    aggregateCase.onVetAggrCaseReportClick();
}

function VetAggregateActionReport() {
    aggregateCase.onVetAggrActionReportClick();
}

function OutbreakReport() {
    outbreak.onOutbreakReportClick();
}

function AsSampleCollectedListReport() {
    asSession.onReportAsSampleCollectedListClick();
}

function AsSessionTestsReport() {
    asSession.onReportAsSessionTestsClick();
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
    var index = lang.indexOf('-');
    var language = lang.substring(0, index).toLowerCase();
    var url1 = "/Content/PaperForms/" + language + "/" + fileName;
    return url1;
}

function DeleteTest(url) {
    var selecteditem = listForm.getSelectedItemId();
    if ((selecteditem == null) || (selecteditem.length == 0)) return;
    bvDialog.showDeletePrompt(function () {
        selecteditem = listForm.getSelectedItemId();
        var url1 = url + "?id=" + selecteditem;
        actions.doDelete(url1);
    });
}

function SelectTest(url) {
    var selecteditem = listForm.getSelectedItemId();
    if ((selecteditem == null) || (selecteditem.length == 0)) return;
    url += "?id=" + selecteditem;
    OpenPopup(url, " ", 840, 670);
}

function EditTest(url) {
    var selecteditem = listForm.getSelectedItemId();
    if ((selecteditem == null) || (selecteditem.length == 0)) return;
    url += "?id=" + selecteditem;
    OpenPopup(url, " ", 840, 670);
}

function EditSample(url) {
    var selecteditem = listForm.getSelectedItemId();
    if ((selecteditem == null) || (selecteditem.length == 0)) return;
    url += "?id=" + selecteditem;
    OpenPopup(url, " ", 840, 550);
}

/*
function ActionPreferencesExecution(url) {
    $.ajax({
        url: url,
        dataType: "json",
        type: "GET",
        success: function (data) {
            //alert('complete');                  
        }
    });
}

function AddToPreferences(url) {
    var selecteditem = listForm.getSelectedItemId();
    if ((selecteditem == null) || (selecteditem.length == 0)) return;
    bvDialog.showDialog(msgConfimation, EIDSS.BvMessages['msgAddToPreferencesPrompt'], EIDSS.BvMessages['strAdd_Id'],
        function () {
            selecteditem = listForm.getSelectedItemId();
            var url1 = url + "?id=" + selecteditem;
            ActionPreferencesExecution(url1);
        }, bvDialog.buttonText.cancel, null, null);
}

function RemoveFromPreferences(url) {
    var selecteditem = listForm.getSelectedItemId();
    if ((selecteditem == null) || (selecteditem.length == 0)) return;
    bvDialog.showDialog(msgConfimation, EIDSS.BvMessages['msgRemoveFromPreferencesPrompt'], EIDSS.BvMessages['strRemove_Id'],
        function () {
            selecteditem = listForm.getSelectedItemId();
            var url1 = url + "?id=" + selecteditem;
            ActionPreferencesExecution(url1);
        }, bvDialog.buttonText.cancel, null, null);
}
*/
/*
function HumanAccessionIn(url) {
    detailPage.open(url, true, true);
}
function VetAccessionIn(url) {
    detailPage.open(url, true, true);
}
function AsAccessionIn(url) {
    detailPage.open(url, true, true);
}
function VsAccessionIn(url) {
    detailPage.open(url, true, true);
}
*/
function VsSessionReport() {
    vssession.onVsSessionReportClick();
}