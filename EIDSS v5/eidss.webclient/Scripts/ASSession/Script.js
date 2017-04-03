
function ShowASSessionPicker() {
    ShowSearchPicker("../ASSession/ASSessionPicker", EIDSS.BvMessages['titleASSessionList'] + ' (V17)');
}

function onASSessionPickerSearchAndOrder() {
    SearchItemsAndUpdateGrid("../ASSession/ASSessionPicker", "Message");
}

function onASSessionPickerSelect() {
    var id = GetSelectedItemId();
    CloseMessageWindow();
    $("#idforselect").val(id);
    document.forms[0].submit();
}


function AjaxFormSubmit(SuccessHandler) {
    var formString = $('form').formSerialize();
    var action = $('form').attr('action');
    showLoading();

    $.ajax({
        url: action,
        type: "POST",
        data: formString,
        success: function (data) {
            SuccessHandler(data);
            hideLoading();
        }
    });

}

function SaveClick() {
    checkChanges(
        function () {
            ShowEidssDialogSavePrompt(SaveHandler);
        },
       DoNothing
    );
}

function SaveHandler()
{
    AjaxFormSubmit(function (data) {
        ApplyChanges(data);


        if (data.Values['CasesCreated']) {
            if (data.Values['CasesCreated'].value == -1) {
                var tabstrip = $("#FullDetails").data("tTabStrip");
                var item = $("li", tabstrip.element)[3];
                tabstrip.select(item);
            }

            if (data.Values['CasesCreated'].value > 0) {
                var expr = new RegExp('(http(s?)\://)', 'ig');
                var currentLang = document.URL.replace(expr, '', '$1');
                currentLang = currentLang.substring(currentLang.indexOf("/") + 1, currentLang.length);
                currentLang = currentLang.substring(0, currentLang.indexOf("/"));

                var vetUrl = '/' + currentLang + '/VetCase/Details/' + data.Values['CasesCreated'].value;
                OpenPopup(vetUrl, 'VetCaseDetails', 1000, 800, true);
            }
        }

        $('input[type="hidden"][id$="_idfFarmForCaseCreation"]').val("");

        var samplesDiv = $('div[id$="CaseTests"][id^="AsSession"]');
        var prefix = samplesDiv.attr('id').substring(0, samplesDiv.attr('id').lastIndexOf('_') + 1);

        var grids = new Array(prefix + 'ASSamples', prefix + 'Actions', prefix + 'CaseTests', prefix + 'Cases', prefix + 'SummaryItems');
        //update all grids
        for (var i = 0; i < grids.length; i++) {
            if ($("#" + grids[i]).data("tGrid")) {
                gridItemAdded(grids[i]);
            }
        }

        //  window.opener.gridItemAdded("Sessions");

    });
}

function CreateCaseClick() {
    var tab = $('#FullDetails').data('tTabStrip');
    var farms = $('div[id$="ASSamples"]');
    if ($('#' + farms[0].id).data('tGrid')) {
        var idfFarm = $('#' + farms[0].id + ' tr.t-state-selected').find("[name='idfFarm']").attr("value");
        if (!idfFarm) {
            alert('Farm is not selected');
            return;
        }
        else {
            $('input[type="hidden"][id$="_idfFarmForCaseCreation"]').val(idfFarm);
            ShowEidssDialogSavePrompt(SaveHandler);
        }
    }
}



function OKHandler() {
    AjaxFormSubmit(function (data) {
        if (data.Values["ErrorMessage"]) {
            ApplyChanges(data);
        }
        else {
            var sessionlist = window.opener.$('div[id$="Sessions"]');
            if (sessionlist[0]) {
                if ($('#' + sessionlist[0].id).data('tGrid')) {
                    window.opener.gridItemAdded(sessionlist[0].id);
                }
            }

            CloseFocusPopUpWindow();
        }
    });
}

function OKClick() {
    checkChanges(
        function () { ShowEidssDialogOKPrompt(OKHandler); },
        CloseFocusPopUpWindow
    );
}


function ReportAsSessionTestsHandler() {
    AjaxFormSubmit(function (data) {
        ApplyChanges(data);

        if (!data.Values["ErrorMessage"]) {
            ShowCIReportAsSessionTests();
        }
    });
}

function ReportAsSessionTestsClick() {
    checkChanges(
        function () { ShowEidssDialogSavePrompt(ReportAsSessionTestsHandler); },
        ShowCIReportAsSessionTests
    );

}


function ReportAsSampleCollectedListHandler() {
    AjaxFormSubmit(function (data) {
        ApplyChanges(data);

        if (!data.Values["ErrorMessage"]) {
            ShowCIReportAsSampleCollectedList();
        }
    });
}

function ReportAsSampleCollectedListClick() {
    checkChanges(
        function () { ShowEidssDialogSavePrompt(ReportAsSampleCollectedListHandler); },
        ShowCIReportAsSampleCollectedList
    );

}

