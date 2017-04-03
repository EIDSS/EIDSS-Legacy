var dialog;
var dialogOkCancel;
var dialogError;
var button1clicked;
var buttonOkClicked;
var buttonCancelClicked;

var msgConfimation = EIDSS.BvMessages['msgConfimation'];
var strOK_Id = EIDSS.BvMessages['strOK_Id'];
var strCancel_Id = EIDSS.BvMessages['strCancel_Id'];
var strError_Id = EIDSS.BvMessages['Error'];
var strYes_Id = EIDSS.BvMessages['strYes_Id'];
var strNo_Id = EIDSS.BvMessages['strNo_Id'];
var strWarning = EIDSS.BvMessages['Warning'];

function ShowEidssDialog(title, text, button1Text, button1callback, button2Text) {
    button1clicked = false;    
    var text = "<br/>" + "<div align='center'>" + text + "</div><br/><br/>" +
            "<div align='center'>" +
            "<button onclick='button1clicked = true;dialog.close();'>" + button1Text + "</button>" +
            "    " +
            "<button onclick='dialog.close();'>" + button2Text +"</button></div>";
    if (dialog) {
        dialog.destroy();
        dialog = null;
    }

    dialog = $.telerik.window.create({
        title: title,
        html: text,
        modal: true,
        resizable: false,
        draggable: false,
        visible: false,
        actions: {},
        width: 200,
        height: 100,
        onClose: function () {
            if (button1clicked) {
                button1callback();
            }
        }
    }).data('tWindow');

    var overlay = $('.t-overlay');
    overlay.css("z-index", 10000);    
    dialog.center().open();
}

function ShowEidssOkCancelDialog(title, text, buttonOkCallBack, buttonCancelCallBack) {
    buttonOkClicked = false;
    buttonCancelClicked = false;
    var text = "<br/>" + "<div align='center'>" + text + "</div><br/><br/>" +
        "<div align='center'>" +
            "<button onclick='buttonOkClicked = true; dialogOkCancel.close();'>" + strOK_Id + "</button>" +
                "    " +
                    "<button onclick='buttonCancelClicked = true; dialogOkCancel.close();'>" + strCancel_Id + "</button></div>";
    
    dialogOkCancel = $.telerik.window.create({
        title: title,
        html: text,
        modal: true,
        resizable: false,
        draggable: false,
        visible: false,
        actions: { },
        width: 200,
        height: 100,
        onClose: function() {
            if (buttonOkClicked) {
                buttonOkCallBack();
            }
            if (buttonCancelClicked) {
                buttonCancelCallBack();
            }
        }
    }).data('tWindow');
    
    var overlay = $('.t-overlay');
    overlay.css("z-index", 10000);
    dialogOkCancel.center().open();
}

function ShowEidssYesNoDialog(title, text, buttonOkCallBack, buttonCancelCallBack) {
    buttonOkClicked = false;
    buttonCancelClicked = false;
    text = "<br/>" + "<div align='center'>" + text + "</div><br/><br/>" +
        "<div align='center'>" +
            "<button onclick='buttonOkClicked = true; dialogOkCancel.close();'>" + strYes_Id + "</button>" +
                "    " +
                    "<button onclick='buttonCancelClicked = true; dialogOkCancel.close();'>" + strNo_Id + "</button></div>";
    dialogOkCancel = $.telerik.window.create({
        title: title,
        html: text,
        modal: true,
        resizable: false,
        draggable: false,
        visible: false,
        actions: { },
        width: 300,
        height: 160,
        onClose: function() {
            if (buttonOkClicked) {
                buttonOkCallBack();
            }
            if (buttonCancelClicked && buttonCancelCallBack) {
                buttonCancelCallBack();
            }
        }
    })
        .data('tWindow');
    dialogOkCancel.center().open();
}

function ShowEidssSuccessNotification(text, title) {    
    var text = "<br/>" + "<div align='center'>" + text + "</div><br/><br/>" +
            "<div align='center'>" +
            "<button onclick='dialog.close();'>" + strOK_Id + "</button></div>";   
    if (!dialog) {
        dialog = $.telerik.window.create({
            title: title,
            html: text,
            modal: true,
            resizable: false,
            draggable: false,
            visible: false,
            width: 400,
            height: 100,
            onClose: function () {               
            }
        })
      .data('tWindow');
    }
    else {
        dialog.content(text);
        dialog.onClose(function () {            
        });
    }    
    dialog.center().open();
}

function ShowEidssErrorNotification(text, buttonCallback) {
    if (text == EIDSS.BvMessages['ErrAuthentication']) {
        buttonCallback = CloseFocusPopUpWindow;
//        if (window.opener) {
//            window.opener.document.location = '/' + GetSiteLanguage() + '/Account/Login';
//            window.close();
//        }
//        else {
//            window.location = '/' + GetSiteLanguage() + '/Account/Login';
//        }
    }
    var overlay = $('.t-overlay');
    var overlayZIndex = overlay.css('z-index');
    var increment = 20;
    overlay.css("z-index", overlayZIndex + increment);
    var text = "<br/>" + "<div align='center' valign='center'>" + text + "</div><br/><br/>" +
            "<div align='center'>" +
            "<button onclick='dialogError.close();'>" + strOK_Id + "</button></div>";
    if (!dialogError) {
        dialogError = $.telerik.window.create({
            title: strWarning,
            html: text,
            modal: true,
            resizable: false,
            draggable: false,
            visible: false,
            //actions: {},
            width: 400,
            height: 120,
            onClose: function () {
                if (buttonCallback) {
                    buttonCallback();
                }
                var zIndex = overlay.css('z-index');
                overlay.css("z-index", zIndex - increment);
            }
        })
        .css("z-index", overlayZIndex + 100)
        .data('tWindow');
    }
    else {
        dialogError.content(text);
    }
    var overlay = $('.t-overlay');
    overlay.css("z-index", 10000);  
    dialogError.center().open();
}


///please use callback function as a string variable for all cases and apply () where needed
function ShowEidssDialogSavePrompt(button1callback) {
    ShowEidssDialog(msgConfimation, EIDSS.BvMessages['msgSavePrompt'], strYes_Id, button1callback, strNo_Id);
}

function ShowEidssDialogCancelPrompt(button1callback) {
    ShowEidssDialog(msgConfimation, EIDSS.BvMessages['msgCancelPrompt'], strYes_Id, button1callback, strNo_Id);
}

function ShowEidssDialogOKPrompt(button1callback) {
    ShowEidssDialog(msgConfimation, EIDSS.BvMessages['msgOKPrompt'], strYes_Id, button1callback, strNo_Id);
}

function ShowEidssDialogDeletePrompt(button1callback) {
    ShowEidssDialog(msgConfimation, EIDSS.BvMessages['msgDeletePrompt'], strOK_Id, button1callback, strCancel_Id);
}

function ShowInternalModalWindow(windowName, ajaxRequestUrl, windowWidth, windowHeigth, title, allowClose) {
    var overlay = $('.t-overlay');
    var overlayZIndex = overlay.css('z-index');    
    overlay.css("z-index", overlayZIndex + 10);
    var windowElement = $.telerik.window.create({
        title: title,
        modal: true,
        resizable: false,        
        onClose: function (e) {
            e.preventDefault();
            OnCloseWindow(windowName);
            windowElement.data('tWindow').destroy();            
            overlay.css("z-index", overlayZIndex);
        }
    });
    windowElement[0].id = windowName;    
    var content = $('#' + windowName + ' .t-window-content.t-content');
    content.css("cssText", "");
    content.css({ width: windowWidth - 10, height: windowHeigth - 40 });
    $('#' + windowName + ' a.t-window-action.t-link').css("display", "none");
    if (allowClose) {
        $('#' + windowName + ' a.t-window-action.t-link').css("display", "inline-block");
    }
    else {
        $('#' + windowName + ' a.t-window-action.t-link').css("display", "none");
    }
    windowElement.data('tWindow').ajaxRequest(ajaxRequestUrl);
    windowElement.css("z-index", overlayZIndex + 11);
    windowElement.css({
        width: windowWidth,
        height: windowHeigth        
    }).data('tWindow').center().open();
}

function ShowMessageWindow(ajaxRequestUrl, windowWidth, windowHeight, title, allowClose) {
    if (allowClose) {
        $('#Message a.t-window-action.t-link').css("display", "inline-block");
    }
    else {
        $('#Message a.t-window-action.t-link').css("display", "none");
    }
    var content = $('#Message .t-window-content.t-content');
    content.css("cssText", "");
    content.css({ width: windowWidth - 10, height: windowHeight - 40 });
    var windowElement = $('#Message');
    windowElement.data('tWindow').title(title);
    windowElement.data('tWindow').ajaxRequest(ajaxRequestUrl);
    windowElement.css({        
        width: windowWidth,
        height: windowHeight
    }).data('tWindow').center().open();
}

function ChangeMessageWindowHeigth() {
    var window = $("#Message.t-widget.t-window");
    var content = $('#Message' + ' .t-window-content.t-content');
    var contentHeight = content.outerHeight();
    var popupContentHeight = $('#Message .t-window-content.t-content .popupContent').outerHeight();
    if (popupContentHeight > contentHeight) {
        var oldHeight = window.height();
        var newWindowHeight = popupContentHeight + 50;
        var top = window.position().top - (newWindowHeight - oldHeight) / 2;
        window.css({ height: newWindowHeight, top: (top > 0 ? top : 0) });
        content.css({ height: newWindowHeight - 40 });
    }
}

function CloseMessageWindow() {
    CloseWindow("Message"); 
}

function OnCloseMessageWindow() {
    OnCloseWindow("Message");
}

function CloseWindow(windowId) {
    var window = $("#" + windowId).data("tWindow");
    if (window) {
        window.close();
    }
}

function OnCloseWindow(windowId) {
    var windowContent = $("#" + windowId + " div.t-window-content.t-content > div");
    if (windowContent.length != 0) {
        windowContent[0].innerHTML = "";
    }
    var content = $("#" + windowId + " .t-window-content.t-content");
    content.css("width", "");
    content.css("height", "");
    content.css("cssText", "");
    var window = $("#" + windowId).data("tWindow");
    window.content("<div></div>");
    window.refresh();
    window.restore();
}

function NotImplemented() {
    alert("It's not implemented yet");
}

function GetSiteLanguage() {
    var expr = new RegExp('(http(s?)\://)', 'ig');
    var currentLang = document.URL.replace(expr, '', '$1');
    currentLang = currentLang.substring(currentLang.indexOf("/") + 1, currentLang.length);
    currentLang = currentLang.substring(0, currentLang.indexOf("/"));
//    var adj = document.URL.replace('http://' + document.domain, "");
//    adj = adj.substring(adj.indexOf('/') + 1);
//    var currentLang = adj.substring(0, adj.indexOf('/'));
   return currentLang;
}

function GetUrlPrefixLanguage() {
    return '/' + GetSiteLanguage() + '/';
}
