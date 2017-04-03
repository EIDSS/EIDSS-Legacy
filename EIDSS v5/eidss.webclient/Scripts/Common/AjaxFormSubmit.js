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

function AjaxFormSubmitWithIgnore(SuccessHandler) {
    var formString = $('form').formSerialize() + '&ignore_rule=1';
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


function SaveClick(grids) {
    checkChanges(
        function () {
            ShowEidssDialogSavePrompt(function () {
                AjaxFormSubmit(function (data) {
                    ApplyChanges(data);

                    if (grids) {
                        //update all grids
                        for (var i = 0; i < grids.length; i++) {
                            if ($("#" + grids[i]).data("tGrid")) {
                                gridItemAdded(grids[i]);
                            }
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
            if (data.Values["ErrorMessage"].typeName == "AskPostMessage") {
                ApplyContainer.onAjaxSuccess = CloseFocusPopUpWindow;
            }
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