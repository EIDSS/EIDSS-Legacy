function onEditHumanCaseClick() {
    var selectedId = GetSelectGridItemId("HumanCasesList");
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/HumanCase/Notification?id=" + selectedId + "&getFromSession=false";
    document.location.href=postUrl;
}

function onOpenHumanReportClick() {
    var selectedId = GetSelectGridItemId("HumanCasesList");
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/HumanCase/HumanInvestigationReport?id=" + selectedId;    
    document.location.href = postUrl;
}

function onEditVetCaseClick() {
    var selectedId = GetSelectGridItemId("VetCasesList");
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/VetCase/General?id=" + selectedId + "&getFromSession=false";
    document.location.href = postUrl;
}

function onOpenVetReportClick() {
    var selectedId = GetSelectGridItemId("VetCasesList");
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/VetCase/VetInvestigationReport?id=" + selectedId;
    document.location.href = postUrl;
}