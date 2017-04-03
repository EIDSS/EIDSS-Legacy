
function ShowVetCasePicker() {
    ShowSearchPicker("../VetCase/VetCasePicker", EIDSS.BvMessages['titleVeterinaryCaseList'] + ' (V01)');
}

function onVetCasePickerSearchAndOrder() {
    SearchItemsAndUpdateGrid("../VetCase/VetCasePicker", "Message");
}

function onVetCasePickerSelect() {
    var id = GetSelectedItemId();
    CloseMessageWindow();
    $("#idforselect").val(id);
    document.forms[0].submit();
}

function onPensideTestPickerChanged(o) {
    var ObjectIdent = o.substring(0, o.lastIndexOf("_") + 1);
    var gridId = ObjectIdent + 'PensideTests';
    CloseEditWindowAndUpdateGrid(gridId, GetUrlPrefixLanguage() + "LabSample/PensideTestPicker");
}


function SaveClick() {
    checkChanges(
        function () {
            ShowEidssDialogSavePrompt(function () {
                AjaxFormSubmit(function (data) {
                    ApplyChanges(data);

                    var samplesDiv = $('div[id$="Samples"][id^="VetCase"]');
                    var prefix = samplesDiv.attr('id').substring(0, samplesDiv.attr('id').lastIndexOf('_') + 1);

                    var grids = new Array(prefix + 'FarmTree', prefix + 'AnimalList',prefix + 'Vaccination', prefix + 'Samples', prefix + 'PensideTests', prefix + 'CaseTests', prefix + 'CaseTestValidations');
                    //update all grids
                    for (var i = 0; i < grids.length; i++) {
                        if ($("#" + grids[i]).data("tGrid")) {
                            gridItemAdded(grids[i]);
                        }                        
                    }

                });
            });
        },
       DoNothing
    );
}

    function OKHandler() {
        AjaxFormSubmit(function (data) {
            if (data.Values["ErrorMessage"]) {
                ApplyChanges(data);
            }
            else {
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


function ReportHandler(ReportViewer) {
    AjaxFormSubmit(function (data) {
        ApplyChanges(data);

        if (!data.Values["ErrorMessage"]) {
            if (ReportViewer) {
                ReportViewer();
                return;
            }
            var lang = GetSiteLanguage();
            var url = "/" + lang + "/VetCase/VetInvestigationReport";
            ShowCIVetCaseReport(url);
        }
    });
}

function ReportClick() {
    checkChanges(
        function () { ShowEidssDialogSavePrompt(ReportHandler); },
        ShowCIVetCaseReport
    );    

}

function ReloadVaccinationGridToolbar(gridId) {
    var btEdit = $("#" + gridId + " .t-grid-toolbar #btEdit");
    var selectedRow = $("#" + gridId + " tr.t-state-selected");
    if (selectedRow.length == 0 || selectedRow[0].cells.length <= 1) {
        DisableGridButton(btEdit);
    }
    else {
        EnableGridButton(gridId, btEdit);
    }
}

function onVaccinationGridRowSelect(e) {
    var gridId = e.target.id;
    ReloadVaccinationGridToolbar(gridId);
}

function onVaccinationGridDataBound(e) {
    bvGridOnDataBound(e, 'false');
    ReloadVaccinationGridToolbar(e.target.id);
}
