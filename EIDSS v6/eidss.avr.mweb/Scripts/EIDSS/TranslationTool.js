var avrTranslation = (function () {
    var currentClassName;
    var currentAccept;

    return {
        OpenTranslationWindow: function () {
            var iClass = $("input[type='hidden'][id='aspclassname']");
            currentClassName = iClass.val();
            pcTranslationTool.Show();
        },

        OpenTranslationWindowForPopup: function () {
            var iClass = $("input[type='hidden'][id='aspclassnamePopup']");
            currentClassName = iClass.val();
            pcTranslationTool.Show();
        },

        OnPopupBeginCallback: function (s, e) {
            e.customArgs["curClassName"] = currentClassName;
            e.customArgs["curAccept"] = currentAccept;
        },

        OnGridBeginCallback: function (s, e) {
            e.customArgs["curClassName"] = currentClassName;
            e.customArgs["curAccept"] = currentAccept;
        },

        TranslationTool_BeforeResizing: function (s, e) {
            //grdTranslations.SetWidth(0);
            grdTranslations.SetHeight(0);
        },
        TranslationTool_AfterResizing: function (s, e) {
            grdTranslations.SetWidth(s.GetContentWidth());
            grdTranslations.SetHeight(s.GetContentHeight());
        },

        SplitDoSplit: function () {
            currentAccept = 'split';
            grdTranslations.UpdateEdit();
            currentAccept = '';
        },

        SplitDoAccept: function () {
            currentAccept = 'accept';
            grdTranslations.UpdateEdit();
            currentAccept = '';
        },

    };
})();
