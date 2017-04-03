(function () {
    $.ajaxSetup({
        cache: false,
        error: function (e, xhr, ajaxSettings, exception) {
//            if (e.status == 500) {
//                ShowEidssErrorNotification(EIDSS.BvMessages['errInternetConnection']);
//            }
            if (e.status == 500 || e.status == 403) {
                window.location = "/index.htm";
            } 
            else {
                ShowEidssErrorNotification(EIDSS.BvMessages['errAjaxRequestException']);
            }
        }
    });

    $().keypress(function (e) {
        e = window.event || e;
        if (e.keyCode == 13) {
            return false;
        }
    });
})();

function GetSiteLanguage() {
    var expr = new RegExp('(http(s?)\://)', 'ig');
    var currentLang = document.URL.replace(expr, '', '$1');
    currentLang = currentLang.substring(currentLang.indexOf("/") + 1, currentLang.length);
    currentLang = currentLang.substring(0, currentLang.indexOf("/"));
    return currentLang;
}

function GetUrlPrefixLanguage() {
    return '/' + GetSiteLanguage() + '/';
}

function FillComboBox(comboBox, data) {
    comboBox.empty();
    $.each(data, function (index, item) {
        comboBox.append($('<option/>', {
            value: item.Value,
            text: item.Text
        }));
    });
}

// call this function id control id has '.' of ':'
function jq(myid) {
    return '#' + myid.replace(/(:|\.)/g, '\\$1');
}

function IsSessionExpired(ajaxResult) {
    if (ajaxResult == "_SessionExpired_") {
        var postUrl = "/index.htm";
        location.href = postUrl;
        return true;
    }
    return false;
}

function OpenMainMenu() {
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/Account/MainMenu";
    document.location.href = url;
}

function LogOut() {
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/Account/Logout";
    document.location.href = url;
}

function InitAccordion() {
    $("#accordion").accordion();
    var theOffset;
    $('#accordion').bind('accordionchange', function (event, ui) {
        var headerOffset = ui.newHeader[0].offsetTop;
        var scrollPosition = headerOffset < theOffset ? headerOffset : theOffset;
        $(window).scrollTop(scrollPosition);
    });
    $('#accordion').bind('click', function (event, ui) {
        theOffset = $(window).scrollTop();
    });
}