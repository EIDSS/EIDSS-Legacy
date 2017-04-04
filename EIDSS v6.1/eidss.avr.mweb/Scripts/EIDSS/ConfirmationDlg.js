var confForm = (function () {
    var currentMessageText;
    var currentYesFunction;
    var currentNoFunction;
    var currentShowCancel;
    return {
        OnHyperLinkClick: function (messageText, yesFunction, noFunction, showCancel) {
            currentMessageText = messageText;
            currentYesFunction = yesFunction;
            currentNoFunction = noFunction;
            currentShowCancel = showCancel;
            pcSaveData.PerformCallback();
            pcSaveData.Show();
        },

        OnPopupBeginCallback: function (s, e) {
            e.customArgs["messageText"] = currentMessageText;
            e.customArgs["yesFunction"] = currentYesFunction;
            e.customArgs["noFunction"] = currentNoFunction;
            e.customArgs["showCancel"] = currentShowCancel;
        }
    }})();