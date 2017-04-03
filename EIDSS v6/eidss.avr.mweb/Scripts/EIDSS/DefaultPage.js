(function () {
    $.ajaxSetup({
        cache: false,
        error: function (jqXhr, textStatus, errorThrown) {
            window.location = avrUrls.getAccountLogin();
        }
    });
})();


var defaultPage = {
    changePasswordPath: "/Account/ChangePassword",
    regExp: /(http(s?):\/\/)/ig,

    regDocumentEvents: function () {
        $(document.body).click(defaultPage.hideLanguagePanel);
    },

    timeoutPageOnLoad: function () {
    },

    loginPageOnLoad: function () {
        defaultPage.autocompleteOff();
        defaultPage.changeFont();
        defaultPage.regDocumentEvents();
        defaultPage.initLanguagePanel();
        defaultPage.hideLanguagePanel();
        defaultPage.showError();
        defaultPage.initCleanButtons();
    },

    autocompleteOff: function () {
        $('form').attr('autocomplete', 'off');
    },

    checkTimeoutError: function (message) {
        var url = avrUrls.getAccountLogin();
        if (message.indexOf(url)>=0)
            document.location = url;
    },

    changeFont: function () {
        var curLang = $("#LanguagePreference").val();
        if (curLang === "hy-AM" || curLang === "ka-GE") {
            $("body").addClass("amGe");
        }
    },

    showError: function () {
        var errorMessageSpan = $("#errorMessageSpan");
        var errorMessageText = errorMessageSpan[0].innerHTML;
        if (errorMessageText) {
            errorMessageSpan.show();
        }
    },

    changePasswordPageOnLoad: function () {
        defaultPage.autocompleteOff();
        defaultPage.changeFont();
        defaultPage.showChangePasswordErrorOrSuccess();
        defaultPage.initCleanButtons();
    },

    showChangePasswordErrorOrSuccess: function () {
        var errorMessageSpan = $("#errorMessageSpan")[0];
        var errorMessageText = errorMessageSpan.innerHTML;
        if (errorMessageText === 'success') {
            defaultPage.hideChangePasswordPanel();
            defaultPage.showChangePasswordSuccess();
        }
        else {
            defaultPage.showError();
            defaultPage.hideChangePasswordSuccess();
        }
    },

    showChangePasswordSuccess: function () {
        $("#pnSuccessMessage").show();
    },

    hideChangePasswordSuccess: function () {
        $("#pnSuccessMessage").hide();
    },

    hideChangePasswordPanel: function () {
        $("#pnChangePassword").hide();
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

    initLanguagePanel: function () {
        $("#curLanguage").click(defaultPage.showLanguagePanel);
        $(".langItem").click(defaultPage.onLanguageSelect);
    },

    showLanguagePanel: function (e) {
        $("#languagePanel").show();
        e.stopPropagation();
    },

    hideLanguagePanel: function () {
        $("#languagePanel").hide();
    },

    onLanguageSelect: function () {
        var selectedItem = $(this);
        var selectedLangKey = selectedItem.data("key");
        var curLang = $("#LanguagePreference").val();
        var newUrl = document.URL.replace(curLang, selectedLangKey);
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

    goToChangePassword: function () {
        var org = $("#Organization").val();
        var userName = $("#UserName").val();
        var curLang = $("#LanguagePreference").val();
        var url = "/" + curLang + defaultPage.changePasswordPath + "?organization=" + org + "&userName=" + userName;
        document.location = url;
    },

    closeChangePassword: function () {
        document.location = avrUrls.getAccountLogin();
    },

    validateChangePasswordPage: function () {
        var org = $("#Organization").val();
        var log = $("#UserName").val();
        var opwd = $("#OldPassword").val();
        var npwd = $("#NewPassword").val();
        var cpwd = $("#ConfirmPassword").val();
        if (org && log && opwd && npwd && cpwd) {
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