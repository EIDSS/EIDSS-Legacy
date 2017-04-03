function SelectAll() {
    bvGrid.selectAllRowsInDefaultGrid();
}

function ActionLaboratoryDetails() {
    var url = bvUrls.getLaboratoryDetailsUrl();
    detailPage.checkChanges(true,
        function () {
            bvDialog.showSearchSavePrompt(
                function () {
                    detailPage.submit(searchPanel.onSaveSuccess, true);
                },
                function () {
                    actions.redirect(url);
                }
            );
        },
        function () {
            actions.redirect(url);
        }
    );
}

function ActionLaboratoryDetailsMyPref() {
    var url = bvUrls.getLaboratoryDetailsMyPrefUrl();
    detailPage.checkChanges(true,
        function () {
            bvDialog.showSearchSavePrompt(
                function () {
                    detailPage.submit(searchPanel.onSaveSuccess, true);
                },
                function () {
                    actions.redirect(url);
                }
            );
        },
        function () {
            actions.redirect(url);
        }
    );
}

function ActionEditHumanCase(caseId) {
    var url = bvUrls.getHumanCaseDetailsUrl() + "?id=" + caseId;
    bvWindow.show(url, " ");
}

function ActionEditOutbreak(outbreakId) {
    var url = bvUrls.getOutbreakDetailsUrl() + "?id=" + outbreakId;
    bvWindow.show(url, " ");
}

function ActionEditVectorSession(caseId) {
    var url = bvUrls.getVsSessionDetailsUrl() + "?id=" + caseId;
    bvWindow.show(url, " ");
}

function ActionEditFarm(farmId) {
    var url = bvUrls.getFarmDetailsUrl() + "?id=" + farmId;
    bvWindow.show(url, " ");
}

function ActionEditVetCase(caseId) {
    var url = bvUrls.getVetCaseDetailsUrl() + "?id=" + caseId;
    bvWindow.show(url, " ");
}


function ActionEditAsCampaign(campaignId) {
    var url = bvUrls.getAsCampaignDetailsUrl() + "?id=" + campaignId;
    bvWindow.show(url, " ");
}

function ActionEditAsCampaignRedirect(campaignId) {
    var url = bvUrls.getAsCampaignDetailsUrl() + "?id=" + campaignId;
    actions.redirect(url);
}

function ActionEditAsSession(sessionId) {
    var url = bvUrls.getAsSessionDetailsUrl() + "?id=" + sessionId + "&isret=0";
    OpenPopup(url, " ");
}

function ActionEditAsSessionRedirect(idSession) {
    var url = bvUrls.getAsSessionDetailsUrl() + "?id=" + idSession + "&isret=1";
    actions.redirect(url);
}

function ActionEditAsSessionReopen(idSession, iSetPagable) {
    var url = bvUrls.getAsSessionDetailsUrl() + "?id=" + idSession + "&isret=1&iSetPagable=" + iSetPagable;
    actions.redirect(url);
}

function ActionViewAsSessionFromCampaign(idSession) {
    var url = bvUrls.getAsSessionDetailsUrl() + "?id=" + idSession + "&readOnly=true";
    actions.redirectToUrl(url, bvUrls.getAsCampaignStoreInSessionUrl());
}

function ActionEditHumanAggregateCase(caseId) {
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/HumanAggregateCase/Details" + "?id=" + caseId;
    OpenPopup(url, " ");
}

function ActionEditVetAggregateCase(caseId) {
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/VetAggregateCase/Details" + "?id=" + caseId;
    OpenPopup(url, " ");
}

function ActionEditVetAggregateActionCase(caseId) {
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/VetAggregateAction/Details" + "?id=" + caseId;
    OpenPopup(url, " ");
}

function ActionEditLabSample(sampleId) {
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/LabSample/EditSample" + "?id=" + sampleId;
    OpenPopup(url, " ", 840, 550);
}

function ActionEditTest(sampleId) {
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/LabSample/EditTest" + "?id=" + sampleId;
    OpenPopup(url, " ", 840, 670);
}

function ActionEditPerson(personId) {
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/Person/Details" + "?id=" + personId;
    OpenPopup(url, " ");
}

function ActionSaveExecution() {
    var workingForm = document.forms[0];
    if (document.forms.length > 1) {
        var i = 0;
        for (i; i < document.forms.length; i++) {            
            if (document.forms[i].action == document.URL) {
                workingForm = document.forms[i];                
            }
        }
    }
    if (workingForm) {
        showLoading();
        workingForm.submit();
    }    
}

function ActionEditVsSession(idSession) {
    var url = bvUrls.redirectToVsSessionUrl() + "?id=" + idSession + "&isret=0";
    OpenPopup(url, " ");
}

function ActionEditVsSessionRedirect(idSession) {
    var url = bvUrls.redirectToVsSessionUrl() + "?id=" + idSession + "&isret=1";
    actions.redirect(url);
}

function ActionEditVector(idVector,name) {    
    vssession.redirectToVector(idVector, name);
}