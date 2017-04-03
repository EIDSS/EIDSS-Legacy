var confForm = (function () {
    var currentMessageText;
    var currentYesFunction;
    var currentNoFunction;

    return {
        OnHyperLinkClick: function (messageText, yesFunction, noFunction) {
            currentMessageText = messageText;
            currentYesFunction = yesFunction;
            currentNoFunction = noFunction;
            pcSaveData.PerformCallback();
            pcSaveData.Show();
        },

        OnPopupBeginCallback: function (s, e) {
            e.customArgs["messageText"] = currentMessageText;
            e.customArgs["yesFunction"] = currentYesFunction;
            e.customArgs["noFunction"] = currentNoFunction;
        }
    }})();