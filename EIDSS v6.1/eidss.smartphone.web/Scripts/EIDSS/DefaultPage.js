var defaultPage = {
    loginPath: "/Account/Login",
    regExp: /(http(s?):\/\/)/ig,

    timeoutPageOnLoad: function () {
    },


    loginPageOnLoad: function () {
        defaultPage.autocompleteOff();
        defaultPage.changeFont();
        defaultPage.showError();
        defaultPage.initCleanButtons();
        twinkleTextBox.init();
    },

    autocompleteOff: function () {
        $('form').attr('autocomplete', 'off');
    },

    changeFont: function () {
        var curLang = $("#LanguagePreference").val();
        if (curLang === "hy-AM") {
            $("body").addClass("fntAm");
        } else if (curLang === "ka-GE") {
            $("body").addClass("fntGe");
        } else if (curLang === "th-TH") {
            $("body").addClass("fntTh");
        }
    },

    showError: function () {
        var errorMessageSpan = $("#errorMessageSpan");
        var errorMessageText = errorMessageSpan[0].innerHTML;
        if (errorMessageText) {
            errorMessageSpan.show();
        }
    },

    initCleanButtons: function () {
        if ($(".k-ie9").length > 0 || $(".k-webkit").length > 0) {
            $("span.k-textbox").addClass("k-space-right");
            $(".k-i-close").click(defaultPage.onCleanButtonClick);
        } else {
            $(".k-i-close").remove();
        }
    },

    onCleanButtonClick: function () {
        $(this).closest('span').children('input').val('').focus();
        return false;
    },


    onLanguageSelectNew: function (lang) {
        var curLang = $("#LanguagePreference").val();
        var newUrl = document.URL.replace(curLang, lang);
        document.location = newUrl;
    },

    validateLoginPage: function () {
        var org = $("#Organization").val();
        var log = $("#UserName").val();
        var pwd = $("#Password").val();
        if (org && log && pwd) {
            return true;
        }
        $("#errorMessageSpan")[0].innerHTML = EIDSS.BvMessages['errLoginMandatoryFields'];
        defaultPage.showError();
        return false;
    },

    getLanguage: function () {
        var lang = document.URL.replace(defaultPage.regExp, "", "$1");
        lang = lang.substring(lang.indexOf("/") + 1, lang.length);
        lang = lang.substring(0, lang.indexOf("/"));
        return lang;
    }
}