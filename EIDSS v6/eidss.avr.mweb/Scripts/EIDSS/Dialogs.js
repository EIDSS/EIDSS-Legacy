var bvDialog = {
    title: {
        confimation: EIDSS.BvMessages['msgConfimation'],
        error: EIDSS.BvMessages['Error'],
        warning: EIDSS.BvMessages['Warning']
    },

    messageText: {
        authenticationError: EIDSS.BvMessages['ErrAuthentication'],
        savePrompt: EIDSS.BvMessages['msgSavePrompt'],
        cancelPrompt: EIDSS.BvMessages['msgCancelPrompt'],
        okPrompt: EIDSS.BvMessages['msgOKPrompt'],
        deletePrompt: EIDSS.BvMessages['msgDeletePrompt']
    },

    buttonText: {
        ok: EIDSS.BvMessages['strOK_Id'],
        cancel: EIDSS.BvMessages['strCancel_Id'],
        yes: EIDSS.BvMessages['strYes_Id'],
        no: EIDSS.BvMessages['strNo_Id']
    },
    
    defaultDialogId: "DialogWindow",

    smallSize: { width: 200, height: 110 },
    mediumSize: { width: 300, height: 160 },
    largeSize: { width: 400, height: 120 },

    isButton1Clicked: false,
    isButton2Clicked: false,
    window: null,

    showOkCancel: function (dialogTitle, dialogText, buttonOkCallBack, buttonCancelCallBack) {
        bvDialog.showDialog(dialogTitle, dialogText, bvDialog.buttonText.ok, buttonOkCallBack, bvDialog.buttonText.cancel, buttonCancelCallBack, bvDialog.smallSize);
    },

    showYesNo: function (dialogTitle, dialogText, buttonYesCallBack, buttonNoCallBack) {
        bvDialog.showDialog(dialogTitle, dialogText, bvDialog.buttonText.yes, buttonYesCallBack, bvDialog.buttonText.no, buttonNoCallBack, bvDialog.mediumSize);
    },

    showDialog: function (dialogTitle, dialogText, button1Text, button1Callback, button2Text, button2Callback, size) {
        bvDialog.isButton1Clicked = false;
        bvDialog.isButton2Clicked = false;
        var dialogContent =
            "<div>" +
                "<div class='confirmationText'>" + dialogText +
                "</div>" +
                "<div class='windowButtonsPn'>" +
                    "<button onclick='bvDialog.isButton1Clicked = true; bvDialog.window.close();' class='windowButton'>" + button1Text + "</button>" +
                    "<button onclick='bvDialog.isButton2Clicked = true; bvDialog.window.close();' class='windowButton'>" + button2Text + "</button>" +
                "</div>" +
            "</div>";
        bvDialog.window = bvDialog.getDialogWindowData(dialogTitle, dialogContent, size, function () {
            bvDialog.onCloseDialog(button1Callback, button2Callback);
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
            window.location = avrUrls.getAccountLogin();
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
        bvDialog.showAuthenticationError(jqXHR, textStatus, errorThrown);
    },

    showNotification: function (title, text, buttonCallback) {
        var dialogContent = bvDialog.getNotificationContent(text);
        bvDialog.window = bvDialog.getDialogWindowData(title, dialogContent, bvDialog.largeSize, buttonCallback);
        bvDialog.window.center().open();
    },

    showSavePrompt: function (buttonOkCallBack) {
        bvDialog.showPrompt(bvDialog.messageText.savePrompt, buttonOkCallBack);
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

    showPrompt: function (dialogText, buttonOkCallBack) {
        bvDialog.showDialog(bvDialog.title.confimation, dialogText, bvDialog.buttonText.ok, buttonOkCallBack, bvDialog.buttonText.cancel);
    },

    getNotificationContent: function (text) {
        var dialogContent = "<div class='warningText'>" + text + "</div>" +
            "<div class='windowButtonsPn'>" +
                "<button onclick='bvDialog.window.close();' class='windowButton'>" + bvDialog.buttonText.ok + "</button>" +
            "</div>";
        return dialogContent;
    },

    onCloseDialog: function (button1Callback, button2Callback) {
        if (bvDialog.isButton1Clicked && button1Callback) {
            button1Callback();
            return;
        }
        if (bvDialog.isButton2Clicked && button2Callback) {
            button2Callback();
            return;
        }
    },

    destroyWindow: function () {
        if (bvDialog.window) {
            //$("#" + bvDialog.defaultDialogId).html("");
            windowFacade.closeById(bvDialog.defaultDialogId);
            //bvDialog.window.destroy();
            //bvDialog.window = null;
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

var bvPopup = {
    defaultName: "PopupWindow",

    showDefault: function (url, title, width, heigth) {
        windowFacade.initAndShowModal(bvPopup.defaultName, url, title, width, heigth);
    },

    showInternal: function (url, collapseEditPanelId) {
        $(".collapseEditWindowPanel:visible").html("").hide();
        var picker = $("#" + collapseEditPanelId);
        if (!picker.length) {
            return;
        }
        picker.load(url).show();
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

    getWindowDataByName: function (windowName) {
        var data = $("#" + windowName + " .popupContent form").serialize(true);
        return data;
    }
};

var bvWindow = {
    defaultSize: { width: 1024, height: 700 },

    show: function (url, title, notGeneratedTitle) {
        var winTitle = notGeneratedTitle ? title : bvWindow.generateTitle(title);
        var win = window.open(url, winTitle);
        if (win) {
            if (win.location == 'about:blank') {
                win.location = link;
            }
            win.focus();
        }
    },

    generateTitle: function (title) {
        return title.replace(" ", "") + Math.round((Math.random() * 1000)).toString();
    }
};

var msgConfimation = EIDSS.BvMessages['msgConfimation'];

function CloseMessageWindow() {
    bvPopup.closeDefaultPopup();
}

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

