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
        changeFont();
        detailPage.disableDeleteButtonForNewCase();
        UnbindEnterClick();
    },
    
    setInvalidObject: function (isInvalid) {
        if (isInvalid) {
            $("#invalidObject").removeClass("invisible");
        } else {
            $("#invalidObject").addClass("invisible");
        }
    },

    setInvalidObjectPopup: function (isInvalid) {
        if (isInvalid) {
            $("#invalidObjectPopup").removeClass("invisible");
        } else {
            $("#invalidObjectPopup").addClass("invisible");
        }
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
    
    dragNothing: function (event) {
        event.preventDefault();
        return false;
    },


    checkChanges: function (async, onHasChanges, onHasNotChanges) {
        var identField = $("#hdnIdentField").val();
        var contentData = $("form").serialize(true);
        contentData = EscapeHtmlGtLtOnly(contentData);
        var checkUrl = bvUrls.getSystemCheckChangesUrl();
        showLoading();
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
                hideLoading();
                if (data) {
                    onHasChanges();
                }
                else {
                    onHasNotChanges();
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                hideLoading();
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

    onSuccessSpecific: function (action, data) {
        if (!String.prototype.endsWith) {
            String.prototype.endsWith = function (searchString, position) {
                var subjectString = this.toString();
                if (position === undefined || position > subjectString.length) {
                    position = subjectString.length;
                }
                position -= searchString.length;
                var lastIndex = subjectString.indexOf(searchString, position);
                return lastIndex !== -1 && lastIndex === position;
            };
        }
        
        if (action.endsWith('HumanCase/Details')) {
            humanCase.onSuccessSpecific(data);
        }
    },

    doSubmit: function (formData, action, onSuccess, async) {
        formData = EscapeHtmlGtLtOnly(formData);
        showLoading();
        $.ajax({
            url: action,
            type: "POST",
            async: async,
            data: formData,
            success: function (data) {
                hideLoading();
                var ret = onSuccess(data);
                if (ret)
                    detailPage.onSuccessSpecific(action, data);
            },
            error: function () {
                hideLoading();
            }
        });
    },

    onShowReportClick: function (showReportFunc, customUpdateFunc) {
        detailPage.checkChanges(true,
            function () {
                bvDialog.showOkCancel(msgConfimation, bvDialog.messageText.savePrompt, function () {
                    detailPage.saveAndShowReport(showReportFunc, customUpdateFunc);
                }, showReportFunc);
            },
            showReportFunc
        );
    },

    saveAndShowReport: function (showReportFunc, customUpdateFunc) {
        detailPage.submit(function (data) {
            //if (data.Values["ErrorMessage"]) {
            formRefresher.updateControls(data);
            if (customUpdateFunc != undefined) {
                customUpdateFunc();
            }
            //}
            if (!data.Values["ErrorMessage"]) {
                showReportFunc();
            }
        }, true);
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
    },

    showSystemPreferences: function () {
        var url = bvUrls.getSystemPreferencesUrl();
        var title = EIDSS.BvMessages['titleSystemPreferences'];
        bvPopup.showDefault(url, title, "C09", 300, 150);
    },

    setSystemPreferences: function () {
        var postUrl = bvUrls.getSystemPreferencesSaveUrl();
        var contentData = bvPopup.getDefaultWindowData();
        $.ajax({
            url: postUrl,
            dataType: "json",
            type: "POST",
            data: contentData,
            success: function (data) {
                var hasError = formRefresher.hasMessage(data);
                formRefresher.updateControls(data);
                if (!hasError) {
                    bvPopup.closeDefaultPopup();
                }
            },
            error: function () {
                bvPopup.closeDefaultPopup();
            }
        });
    },

    setSystemPreferencesDefault: function () {
        var postUrl = bvUrls.getSystemPreferencesDefaultUrl();
        var contentData = bvPopup.getDefaultWindowData();
        bvDialog.showYesNo(msgConfimation,
            EIDSS.BvMessages['msgAskRestoreToDefault'],
            function () {
                $.ajax({
                    url: postUrl,
                    dataType: "json",
                    type: "POST",
                    data: contentData,
                    success: function (data) {
                        formRefresher.updateControls(data);
                    },
                    error: function () {
                    }
                });
            },
            function () {
            });
    },

}
