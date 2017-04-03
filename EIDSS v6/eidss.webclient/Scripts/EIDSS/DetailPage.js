var detailPage = {

    open: function (url, isnew, inmodal) {
        var selecteditem;
        if (isnew) {
            selecteditem = 0;
        }
        else {
            selecteditem = listForm.getSelectedItemId();
        }

        if (url.indexOf('Create') != -1) {
            selecteditem = 0;
        }

        if ((selecteditem == null) || (selecteditem.length == 0)) {
            return;
        }
        url += "?id=" + selecteditem;

        if (inmodal) {
            OpenPopup(url, " ");
        } else {
            actions.redirect(url);
        }
    },
    
    onLoad: function (timeZoneOffset) {
        bvGrid.timeOffsetInHours = timeZoneOffset;
        detailPage.disableDeleteButtonForNewCase();
        UnbindEnterClick();
    },
    
    disableDeleteButtonForNewCase: function () {
        var isNewCaseControl = $("#IsNewCase");
        if (isNewCaseControl.length && isNewCaseControl.val().toLowerCase() === "true") {
            $("#bMainPanel_Delete").attr('disabled', 'disabled');
        }
    },
    
    enableDeleteButton: function () {
        $("#bMainPanel_Delete").removeAttr("disabled");
    },

    close: function () {
        //if (window.opener && !window.opener.closed) {
            window.close();
            //detailPage.refreshOpener(); в соответствии с ТЗ не нужно рефрешить гриды после закрытия детальной формы
        //}
    },
    
    checkChanges: function (async, onHasChanges, onHasNotChanges) {
        var identField = $("#hdnIdentField").val();
        var contentData = $("form").serialize(true);
        var lang = GetSiteLanguage();
        var checkUrl = "/" + lang + "/System/CheckChanges";
        $.ajax({
            url: checkUrl,
            dataType: 'json',
            type: 'POST',
            async: async,
            data: {
                id: identField,
                formData: contentData
            },
            success: function (data) {
                if (data) {
                    onHasChanges();
                }
                else {
                    onHasNotChanges();
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                bvDialog.showAuthenticationError(jqXHR, textStatus, errorThrown);
            }
        });
    },

    reloadGrids: function () {
        var grids = $("." + gridFacade.gridClassName);
        for (var i = 0; i < grids.length; i++) {
            bvGrid.reloadById(grids[i].id);
        }
    },

    submit: function (onSuccess, async) {
        var formData = $('form').formSerialize();
        var action = $('form').attr('action');
        if (action.indexOf('?') > 0) {
            action = action.split('?')[0];
        }
        detailPage.doSubmit(formData, action, onSuccess, async);
    },

    submitWithoutValidation: function (onSuccess) {
        var formData = $('form').formSerialize() + '&ignore_rule=1';
        var action = $('form').attr('action');
        detailPage.doSubmit(formData, action, onSuccess, true);
    },

    doSubmit: function (formData, action, onSuccess, async) {
        showLoading();
        $.ajax({
            url: action,
            type: "POST",
            async: async,
            data: formData,
            success: function (data) {
                onSuccess(data);
                hideLoading();
            }
        });
    },

    onShowReportClick: function (showReportFunc) {
        detailPage.checkChanges(true,
            function () {
                bvDialog.showOkCancel(msgConfimation, bvDialog.messageText.savePrompt, function () {
                    detailPage.saveAndShowReport(showReportFunc);
                }, showReportFunc);
            },
            showReportFunc
        );
    },

    saveAndShowReport: function (showReportFunc) {
        detailPage.submit(function (data) {
            //if (data.Values["ErrorMessage"]) {
                formRefresher.updateControls(data);
            //}
            if (!data.Values["ErrorMessage"]) {
                showReportFunc();
            }
        }, false);
    },
    
    openReport: function (url) {
        OpenPopup(url, " ");
        //bvWindow.show(url, " ");
        //window.open("about:blank", "_blank");
        /*var win = window.open(url, winTitle);
        if (win) {
            if (win.location == 'about:blank') {
                win.location = url;
            }
            win.focus();
        }*/
    }
}
