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

function ShowEidssDialog(title, text, buttonCallback, callbackParams) {
    jConfirm(text, title, function (r) {
        if (r) { buttonCallback(callbackParams); }
    });    
}

function ShowEidssSuccessNotification(text, title) {
    jAlert(text, title);    
}

function ShowEidssErrorNotification(text, buttonCallback) {
    jAlert(text, '');
}


///please use callback function as a string variable for all cases and apply () where needed
function ShowEidssDialogSavePrompt(buttonCallback, callbackParams) {
    ShowEidssDialog(msgConfimation, EIDSS.BvMessages['msgSavePrompt'], buttonCallback, callbackParams);
}

function ShowEidssDialogCancelPrompt(buttonCallback, callbackParams) {
    ShowEidssDialog(msgConfimation, EIDSS.BvMessages['msgCancelPrompt'], buttonCallback, callbackParams);
}

function ShowEidssDialogOKPrompt(buttonCallback, callbackParams) {
    ShowEidssDialog(msgConfimation, EIDSS.BvMessages['msgOKPrompt'], buttonCallback, callbackParams);
}

function ShowEidssDialogDeletePrompt(buttonCallback, callbackParams) {
    ShowEidssDialog(msgConfimation, EIDSS.BvMessages['msgDeletePrompt'], buttonCallback, callbackParams);
}

function ShowEidssDialogClosePrompt(buttonCallback, callbackParams) {
    ShowEidssDialog(msgConfimation, EIDSS.BvMessages['msgClosePrompt'], buttonCallback, callbackParams);
}

function ShowEidssDialogCancelPromptWithActionCancelExecution(okButtonCallBack, callbackParams) {
    ShowEidssDialogCancelPrompt(okButtonCallBack, callbackParams);
}

function ShowEidssDialogOKPromptWithActionSaveExecutionAndCloseWindow(okButtonCallBack, callbackParams) {
    ShowEidssDialogOKPrompt(okButtonCallBack, callbackParams);
}

function ShowEidssDialogSavePromptWithActionSaveExecution(okButtonCallBack, callbackParams) {
    ShowEidssDialogSavePrompt(okButtonCallBack, callbackParams);
}

function ShowEidssDialogClosePromptWithActionCloseExecution(okButtonCallBack, callbackParams) {
    ShowEidssDialogClosePrompt(okButtonCallBack, callbackParams);
}