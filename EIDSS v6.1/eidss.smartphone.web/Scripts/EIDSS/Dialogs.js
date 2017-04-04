var bvDialog = {
    title: {
        confimation: EIDSS.BvMessages['msgConfimation'],
        error: EIDSS.BvMessages['Error'],
        warning: EIDSS.BvMessages['Warning']
    },

    messageText: {
        authenticationError: EIDSS.BvMessages['ErrAuthentication'],
        savePrompt: EIDSS.BvMessages['msgSavePrompt'],
        saveSearchPrompt: EIDSS.BvMessages['msgUnsavedRecordsPrompt'],
        cancelPrompt: EIDSS.BvMessages['msgCancelPrompt'],
        okPrompt: EIDSS.BvMessages['msgOKPrompt'],
        deletePrompt: EIDSS.BvMessages['msgDeletePrompt'],
        deleteRecordPrompt: EIDSS.BvMessages['msgDeleteRecordPrompt']
},

    buttonText: {
        ok: EIDSS.BvMessages['strOK_Id'],
        cancel: EIDSS.BvMessages['strCancel_Id'],
        yes: EIDSS.BvMessages['strYes_Id'],
        no: EIDSS.BvMessages['strNo_Id']
    },
    
    defaultDialogId: "DialogWindow",

    smallSize: { width: 200, height: 350 },
    mediumSize: { width: 300, height: 350 },
    largeSize: { width: 400, height: 350 },

    isButton1Clicked: false,
    isButton2Clicked: false,
    isButton3Clicked: false,
    window: null,

    showOkCancel: function (dialogTitle, dialogText, buttonOkCallBack, buttonCancelCallBack) {
        bvDialog.showDialog(dialogTitle, dialogText, bvDialog.buttonText.ok, buttonOkCallBack, bvDialog.buttonText.cancel, buttonCancelCallBack, null, null, bvDialog.smallSize);
    },

    showYesNo: function (dialogTitle, dialogText, buttonYesCallBack, buttonNoCallBack) {
        bvDialog.showDialog(dialogTitle, dialogText, bvDialog.buttonText.yes, buttonYesCallBack, bvDialog.buttonText.no, buttonNoCallBack, null, null, bvDialog.mediumSize);
    },

    showDialog: function (dialogTitle, dialogText, button1Text, button1Callback, button2Text, button2Callback, button3Text, button3Callback, size) {
        bvDialog.isButton1Clicked = false;
        bvDialog.isButton2Clicked = false;
        bvDialog.isButton3Clicked = false;
        var dialogContent =
            "<div>" +
                "<div class='confirmationText'>" + dialogText +
                "</div>" +
                "<div class='windowButtonsPn'>" +
                    "<button onclick='bvDialog.isButton1Clicked = true; bvDialog.window.close();' class='windowButton'>" + button1Text + "</button>" +
                    "<button onclick='bvDialog.isButton2Clicked = true; bvDialog.window.close();' class='windowButton'>" + button2Text + "</button>";
        if (button3Text != null) {
            dialogContent = dialogContent +
                    "<button onclick='bvDialog.isButton3Clicked = true; bvDialog.window.close();' class='windowButton'>" + button3Text + "</button>";
        }
        dialogContent = dialogContent +
                "</div>" +
            "</div>";
        bvDialog.window = bvDialog.getDialogWindowData(dialogTitle, dialogContent, size, function () {
            bvDialog.onCloseDialog(button1Callback, button2Callback, button3Callback);
        });
        bvDialog.setOverlayZindex(10000);
        windowFacade.openWindowInCenter(bvDialog.window, bvDialog.defaultDialogId);
        /*bvDialog.window.center().open();*/
    },

    showSuccess: function (title, text) {
        bvDialog.showNotification(title, text, function () {
        });
    },

    showError: function (text, buttonCallback) {
        if (text == bvDialog.messageText.authenticationError) {
            window.location = '/' + GetSiteLanguage() + '/Account/Login';
        }

        var overlay = $('.t-overlay');
        var overlayZindex = overlay.css('z-index');
        var overlayIncrement = 20;
        overlay.css("z-index", overlayZindex + overlayIncrement);

        var dialogContent = bvDialog.getNotificationContent(text);
        var onClose = function () {
            if (buttonCallback) {
                buttonCallback();
            }
            var zIndex = overlay.css('z-index');
            overlay.css("z-index", zIndex - overlayIncrement);
        };
        var dialogWindow = bvDialog.createDialogWindow(bvDialog.title.warning, dialogContent, bvDialog.largeSize, onClose);
        dialogWindow.parent().css('z-index', overlayZindex + 100);
        bvDialog.window = windowFacade.getWindowData(dialogWindow);
        overlay.css("z-index", 10000);
        windowFacade.openWindowInCenter(bvDialog.window, bvDialog.defaultDialogId);
    },

    showAuthenticationError: function (jqXHR, textStatus, errorThrown) {
        actions.redirect(bvUrls.getHomeUrl());
        //bvDialog.showAuthenticationError(jqXHR, textStatus, errorThrown);
    },

    showNotification: function (title, text, buttonCallback) {
        var dialogContent = bvDialog.getNotificationContent(text);
        bvDialog.window = bvDialog.getDialogWindowData(title, dialogContent, bvDialog.largeSize, buttonCallback);
        bvDialog.window.center().open();
    },
    
    showWarning: function (text, buttonCallback) {
        bvDialog.showNotification(bvDialog.title.warning, text, buttonCallback);
    },

    showSavePrompt: function (buttonOkCallBack) {
        bvDialog.showPrompt(bvDialog.messageText.savePrompt, buttonOkCallBack);
    },

    showSearchSavePrompt: function (buttonYesCallBack, buttonNoCallBack) {
        bvDialog.showDialog(bvDialog.title.confimation, bvDialog.messageText.saveSearchPrompt, bvDialog.buttonText.yes, buttonYesCallBack, bvDialog.buttonText.no, buttonNoCallBack, bvDialog.buttonText.cancel);
    },

    showCancelPrompt: function (buttonOkCallBack) {
        bvDialog.showPrompt(bvDialog.messageText.cancelPrompt, buttonOkCallBack);
    },

    showOkPrompt: function (buttonOkCallBack) {
        bvDialog.showPrompt(bvDialog.messageText.okPrompt, buttonOkCallBack);
    },

    showDeletePrompt: function (buttonOkCallBack) {
        bvDialog.showPrompt(bvDialog.messageText.deletePrompt, buttonOkCallBack);
    },

    showDeleteRecordPrompt: function (buttonOkCallBack) {
        bvDialog.showPrompt(bvDialog.messageText.deleteRecordPrompt, buttonOkCallBack);
    },

    showPrompt: function (dialogText, buttonOkCallBack) {
        bvDialog.showDialog(bvDialog.title.confimation, dialogText, bvDialog.buttonText.ok, buttonOkCallBack, bvDialog.buttonText.cancel, null, null);
    },

    getNotificationContent: function (text) {
        var dialogContent = "<div class='warningText'>" + text + "</div>" +
            "<div class='windowButtonsPn'>" +
                "<button onclick='bvDialog.window.close();' class='windowButton'>" + bvDialog.buttonText.ok + "</button>" +
            "</div>";
        return dialogContent;
    },

    onCloseDialog: function (button1Callback, button2Callback, button3Callback) {
        if (bvDialog.isButton1Clicked && button1Callback) {
            bvDialog.isButton1Clicked = false;
            button1Callback();
            return;
        }
        if (bvDialog.isButton2Clicked && button2Callback) {
            bvDialog.isButton2Clicked = false;
            button2Callback();
            return;
        }
        if (bvDialog.isButton3Clicked && button3Callback) {
            bvDialog.isButton3Clicked = false;
            button3Callback();
            return;
        }
    },

    destroyWindow: function () {
        if (bvDialog.window) {
            //$("#" + bvDialog.defaultDialogId).html("");
            windowFacade.closeById(bvDialog.defaultDialogId);
            //bvDialog.window.destroy();
            bvDialog.window = null;
        }
    },

    createDialogWindow: function (dialogTitle, dialogContent, size, onClose) {
        bvDialog.destroyWindow();
        if (!size) {
            size = bvDialog.smallSize;
        }
        var dialogWindow = windowFacade.initModal(bvDialog.defaultDialogId, dialogContent, dialogTitle, size.width, size.height, onClose);
        return dialogWindow;
    },

    getDialogWindowData: function (dialogTitle, dialogContent, size, onClose) {
        var dialogWindow = bvDialog.createDialogWindow(dialogTitle, dialogContent, size, onClose);
        var windowData = windowFacade.getWindowData(dialogWindow);
        return windowData;
    },

    setOverlayZindex: function (zindex) {
        var overlay = $('.t-overlay');
        overlay.css("z-index", zindex);
    }
};


var bvCheckSession = {
    check: function (successCallback) {
        var urlCheck = bvUrls.getHeartbeatUrl();
        $.ajax({
            url: urlCheck,
            cache: false,
            async: false,
            dataType: "json",
            type: "GET",
            data: {
                id: 0
            },
            success: function (result) {
                successCallback();
            },
            error: function (jqXHR, textStatus, errorThrown) {
                actions.redirect(bvUrls.getHomeUrl());
            }
        });
    }
};

var bvPopup = {
    defaultName: "PopupWindow",
    minHeight: 350,
    minWidth: 730,

    showDefault: function (url, title, formNumber, width, heigth) {
        bvCheckSession.check(function() {
            if (width < bvPopup.minWidth) {
                width = bvPopup.minWidth;
            }
            if (heigth < bvPopup.minHeight) {
                heigth = bvPopup.minHeight;
            }
            windowFacade.initAndShowModal(bvPopup.defaultName, url, title, formNumber, width, heigth);
        });
    },

    showDefaultAnyWidth: function (url, title, formNumber, width, heigth) {
        bvCheckSession.check(function () {
            if (heigth < bvPopup.minHeight) {
                heigth = bvPopup.minHeight;
            }
            windowFacade.initAndShowModal(bvPopup.defaultName, url, title, formNumber, width, heigth);
        });
    },

    initAndShowModal: function (id, url, title, formNumber, width, heigth) {
        bvCheckSession.check(function () {
            windowFacade.initAndShowModal(id, url, title, formNumber, width, heigth);
        });
    },

    showInternal: function (url, collapseEditPanelId) {
        bvCheckSession.check(function () {
            $(".collapseEditWindowPanel:visible").html("").hide();
            var picker = $("#" + collapseEditPanelId);
            if (!picker.length) {
                return;
            }
            picker.load(url).show();
        });
    },
    
    getInternalData: function (collapseEditPanelId) {
        var contentData = $("#" + collapseEditPanelId + " .popupContent form").serialize(true);
        return contentData;
    },
    
    closeInternal: function (collapseEditPanelId) {
        $("#" + collapseEditPanelId).html("").hide();
    },

    closeById: function (id) {
        windowFacade.closeById(id);
    },
    
    closeDefaultPopup: function () {
        bvPopup.closeById(bvPopup.defaultName);
    },

    cleanById: function (id) {
        windowFacade.cleanById(id);
    },

    cleanDefault: function () {
        windowFacade.cleanById(bvPopup.defaultName);
    },
    
    getDefaultWindowData: function () {
        var data = bvPopup.getWindowDataByName(bvPopup.defaultName);
        return data;
    },

    getDefaultWindowDataWithoutChanging: function () {
        var data = $("#" + bvPopup.defaultName + " .popupContent form").serialize(true);
        return data;
    },

    getWindowDataByName: function (windowName) {
        var checkboxes = $("#" + windowName + " .popupContent form").find('input[type="checkbox"]');
        checkboxes.removeAttr("disabled");
        $.each(checkboxes, function (key, value) {
            $(value).attr('type', 'hidden');
            if (value.checked === false) {
                value.value = "false";
                value.text = "false";
            } else {
                value.value = "true";
                value.text = "true";
            }
        });

        var disabledControls = $("#" + windowName + " .popupContent form").find('input[disabled="disabled"]');
        disabledControls.removeAttr("disabled");

        var data = $("#" + windowName + " .popupContent form").serialize(true);

        $.each(checkboxes, function (key, value) {
            $(value).attr('type', 'checkbox');
        });

        return data;
    },
    
    getFormActionUrl: function (windowName) {
        var url = $("#" + windowName + " .popupContent form").attr("action");
        return url;
    }
};

var bvWindow = {
    defaultSize: { width: 1024, height: 700 },

    show: function (url, title, notGeneratedTitle) {
        bvCheckSession.check(function () {
            var winTitle = notGeneratedTitle ? title : bvWindow.generateTitle(title);
            var win = window.open(url, winTitle);
            if (win) {
                if (win.location == 'about:blank') {
                    win.location = url;
                }
                win.focus();
            }
        });
    },

    generateTitle: function (title) {
        return title.replace(" ", "") + Math.round((Math.random() * 1000)).toString();
    }
};

var msgConfimation = EIDSS.BvMessages['msgConfimation'];

/*function CloseMessageWindow() {
    bvPopup.closeDefaultPopup();
}*/

function OpenPopup(url, title, notGeneratedTitle) {
    bvWindow.show(url, title, notGeneratedTitle);
    return false;
}

function OpenModal(link, title) {
    var windowElement = $.telerik.window.create({
        title: title,
        contentUrl: link,
        modal: true,
        resizable: true,
        draggable: true,
        onClose: function () { }
    });

    windowElement.css({
        left: 300,
        top: 150,
        width: 600,
        height: 380
    }).data('tWindow').open();
}

var bvTranslation = (function () {
    function internalOpenTranslationWindow(iClassName) {
        var lang = GetSiteLanguage();
        var url = "/" + lang + "/Account/Translation?aspclassname=" + iClassName;
        windowFacade.initAndShowModal("TranslationWindow", url, "Translations", "C17", 1024, 580);
    }

    function openSplitWindow(id) {
        var lang = GetSiteLanguage();
        var url = "/" + lang + "/Account/ResourceUsage?id=" + id;
        windowFacade.initAndShowModal("SplitWindow", url, "Resource Usage", "C18", 1024, 580);
    }

    function onTranslationSave(e) {
        var lang = GetSiteLanguage();
        var checkUrl = '/' + lang + '/Account/CheckTranslation';
        $.ajax({
            url: checkUrl,
            async: false,
            dataType: 'json',
            type: 'POST',
            data: {
                id: e.model.id,
                split: e.model.Split
            },
            success: function (data) {
                if (data) {
                }
                else {
                    openSplitWindow(e.model.id);
                    e.preventDefault();
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                bvDialog.showAuthenticationError(jqXHR, textStatus, errorThrown);
            }
        });
    }

    return {
        model: null,
        
        OpenTranslationWindow: function () {
            var iClass = $("input[type='hidden'][id='aspclassname']");
            var iClassName = iClass.val();
            internalOpenTranslationWindow(iClassName);
        },

        OpenTranslationWindowForPopup: function() {
            var iClass = $("input[type='hidden'][id='aspclassnamePopup']");
            var iClassName = iClass.val();
            internalOpenTranslationWindow(iClassName);
        },

        SplitDoSplit: function () {
            bvPopup.closeById('SplitWindow');
            var grid = $('#TranslationGrid').data('kendoGrid');
            model.Split = "true";
            grid.saveChanges();
        },
        
        SplitDoAccept: function () {
            bvPopup.closeById('SplitWindow');
            var grid = $('#TranslationGrid').data('kendoGrid');
            grid.saveChanges();
        },
        
        SplitDoCancel: function () {
            bvPopup.closeById('SplitWindow');
            var grid = $('#TranslationGrid').data('kendoGrid');
            grid.cancelChanges();
        },

        onSaveTranslation: function (e) {
            if (e.model.dirty) {
                model = e.model;
                onTranslationSave(e);
            }
        },

    };
})();


