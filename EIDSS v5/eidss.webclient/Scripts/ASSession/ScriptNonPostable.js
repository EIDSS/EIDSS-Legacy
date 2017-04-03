function OKHandler() {
    AjaxFormSubmit(function (data) {
        if (data.Values["ErrorMessage"]) {
            ApplyChanges(data);
        }
        else {
            var sessionlist = window.opener.$('div[id$="Sessions"]');
            window.opener.gridItemAdded(sessionlist[0].id);
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


function SaveHandler() {
    AjaxFormSubmit(function (data) {
        if (data.Values["ErrorMessage"]) {
            ApplyChanges(data);
        }
        else {
            var sessionlist = window.opener.$('div[id$="Sessions"]');
            window.opener.gridItemAdded(sessionlist[0].id);
        }
    });
}

function SaveClick() {
    checkChanges(
        function () { ShowEidssDialogSavePrompt(SaveHandler); },
        DoNothing
    );
}
