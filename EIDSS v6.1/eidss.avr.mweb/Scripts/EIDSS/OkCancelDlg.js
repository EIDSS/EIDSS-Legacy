var okCancelForm = (function () {
    var currentMessageText;
    var currentOkFunction;

    return {
        OnHyperLinkClick: function (messageText, okFunction) {
            currentMessageText = messageText;
            currentOkFunction = okFunction;
            pcOkCancel.PerformCallback();
            pcOkCancel.Show();
        },

        OnPopupBeginCallback: function (s, e) {
            e.customArgs["messageText"] = currentMessageText;
            e.customArgs["okFunction"] = currentOkFunction;
        }
    }
})();