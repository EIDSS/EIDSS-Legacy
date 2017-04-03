var warnForm = (function () {
    var currentMessageText;

    return {
        OnHyperLinkClick: function (messageText) {
            currentMessageText = messageText;
            pcWarning.PerformCallback();
            pcWarning.Show();
        },

        OnPopupBeginCallback: function (s, e) {
            e.customArgs["messageText"] = currentMessageText;
        }
    }})();