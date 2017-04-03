function ActionRefresh() {
   RedirectToPage(window.location.href);
}

function DisplaySearchPanel() {
    onShowListFormSearchPanel();
}

function ActionClose(url) {
    RedirectToPage(url);
}

function RedirectToPage(url) {
    if (top.frames.length > 0)
        top.location = url;
    else
        window.location.href = url;
}

function ActionCreate(url) {
    ShowEidssDialogSavePrompt(function () { OpenDetailPage(url, true, false); });         
}

function ActionCreateListForm(url) {    
    OpenDetailPage(url, true, true);    
}


function ActionEdit(url) {
    OpenDetailPage(url, false, true);
}

function GetSelectedItemFromGrid() {
    //получаем id сущности, для которой нужно открыть форму    
    return $("#grid_selecteditem").val();
}

function ActionEditHumanCase(caseId) {
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/HumanCase/Details" + "?id=" + caseId;
    OpenPopup(url, " ");
}

function ActionEditVetCase(caseId) {
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/VetCase/Details" + "?id=" + caseId;
    OpenPopup(url, " ");
}


function ActionEditAsCampaign(campaignId) {
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/ASCampaign/Details" + "?id=" + campaignId;
    OpenPopup(url, " ");
}

function ActionEditAsSession(sessionId) {
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/ASSession/Details" + "?id=" + sessionId;
    OpenPopup(url, " ");
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

function OpenDetailPage(url, isnew, inmodal) {    
    //получаем id сущности, для которой нужно открыть форму
    var selecteditem;
    if (isnew) {
        selecteditem = 0;
    }
    else {
        selecteditem = GetSelectedItemFromGrid();
    }

    if (url.indexOf('Create') != -1) selecteditem = 0;

    if ((selecteditem == null) || (selecteditem.length == 0)) return;
    
    //alert('go');
    //alert(selecteditem);
    //selecteditem = 0;
    url += "?id=" + selecteditem;
    //alert(url);
    //redirecttopage(url);
    
    if (inmodal)
        OpenPopup(url, " ");
    else
        RedirectToPage(url);
}


function RefreshParentWindow() {
    if (window.opener && !window.opener.closed) {

        if (window.opener.document.getElementById('AltSearch')) {
            window.opener.AjaxSearch(window.opener.SearchOnOkSuccessHandler);            
        }
        else {            
            var form = window.opener.$("div#searchpanel form");

            if (form) {
                form.submit();
            }
        }
    }
}
function CloseFocusPopUpWindow() {
    if (window.opener && !window.opener.closed) {
        window.close();

        if (window.opener.document.getElementById('AltSearch')) {
            window.opener.AjaxSearch(window.opener.SearchOnOkSuccessHandler);            
            return;
        }

        var aggr = window.opener.$("div#AggregateCaseGrid");
        if (aggr) {
            var id = $("#idfAggrCase").val();
            var isNew = IsNewAggrCase(id, window.opener);
            if (isNew) {
                return;
            }
            UpdateAggregateCaseInGrid(id, window.opener);
            return;
        }

        var form = window.opener.$("div#searchpanel form");
        if (form) {
            form.submit();
            return;
        }
    }
}

function DoNothing() {
}

function ActionCancelExecution() {
    CloseFocusPopUpWindow();
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

function ActionSaveExecutionAndCloseWindow() {
    ActionSaveExecution();
}

function ShowEidssDialogCancelPromptWithActionCancelExecution() {
    ShowEidssDialogCancelPrompt(ActionCancelExecution);
}

function ShowEidssDialogOKPromptWithActionSaveExecutionAndCloseWindow() {
    if ($("#SaveAndExitClick").length > 0) {
        $("#SaveAndExitClick")[0].value = '1';
    }
    ShowEidssDialogOKPrompt(ActionSaveExecutionAndCloseWindow);
}

function ShowEidssDialogSavePromptWithActionSaveExecution() {
    if ($("#SaveAndExitClick").length > 0) {
        $("#SaveAndExitClick")[0].value = '0';
    }
    ShowEidssDialogSavePrompt(ActionSaveExecution);
}

function ActionCancel(str) {
    checkChanges(ShowEidssDialogCancelPromptWithActionCancelExecution, CloseFocusPopUpWindow);
}

function ActionCancelWithoutQuestion(str) {
    CloseFocusPopUpWindow();
}

function ActionOK(str) {
    checkChanges(ShowEidssDialogOKPromptWithActionSaveExecutionAndCloseWindow, CloseFocusPopUpWindow);
}

function ActionSave(str) {
    checkChanges(ShowEidssDialogSavePromptWithActionSaveExecution, DoNothing);
}

function ActionDeleteExecution(url) {
    //alert('delete started');
    $.ajax({
        url: url,
        cache: false,
        dataType: "json",
        type: "GET",
        success: function (data) {
            if (data) {
                if ($('.detailsViewContainer').length == 1) {
                    CloseFocusPopUpWindow();
                }
                else {
                    AjaxSearch(SearchOnOkSuccessHandler);   
                }
            }
            else {
                ShowEidssErrorNotification(EIDSS.BvMessages['ErrObjectCantBeDeleted'], function () { });
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            if (textStatus == 'parsererror') {
                ShowEidssErrorNotification(EIDSS.BvMessages['ErrAuthentication'], function () { });
            }
        }
    });        
}

function ActionDeleteList(url) {
    var selecteditem = GetSelectedItemFromGrid();  
    if ((selecteditem == null) || (selecteditem.length == 0))  return;
    url += "&id=" + selecteditem;
    ShowEidssDialogDeletePrompt(function(){ ActionDeleteExecution(url);});    
}

function ActionDeleteObject(url) {
    ShowEidssDialogDeletePrompt(function () { ActionDeleteExecution(url); });
}

function CheckChangesById(ifChanged, ifNotChanged, id) {
    var contentData = $("form").serialize(true);
    var lang = GetSiteLanguage();
    var checkUrl = "/" + lang + "/System/CheckChanges";
    $.ajax({
        url: checkUrl,
        cache: false,
        dataType: 'json',
        type: 'POST',
        data: {
            id: id,
            formData: contentData
        },
        success: function (data) {
            if (data) {
                ifChanged();
            }
            else {
                ifNotChanged();
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            if (textStatus == 'parsererror') {
                ShowEidssErrorNotification(EIDSS.BvMessages['ErrAuthentication'], function () { });
            }
        }
    });
}
