function onCancelVetCaseEdit() {
    CloseVetCase();
}

function onSaveVetCase() {
    SaveVetCase(false);
}

function onSaveAndCloseVetCase() {
    SaveVetCase(true);
}

function SaveVetCase(closeCaseAfterSave) {
    var contentData = $("#tabs-1 form").serialize(true);
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/VetCase/Details";
    $.ajax({
        url: postUrl,
        cache: false,
        dataType: "json",
        type: "POST",
        data: contentData,
        success: function (data) {
            if (IsSessionExpired(data)) {
                return;
            }
            var err = false;
            for (var att in data.Values) {
                if (data.Values[att].typeName == "ErrorMessage") {
                    err = true;
                }
            }
            if (err) {
                ApplyChanges(data);
            }
            else {
                if (closeCaseAfterSave) {
                    CloseVetCase();
                }
                else {
                    var href = $("#scontent ul.ui-tabs-nav li.ui-state-active a").attr("href");
                    location.href = href;
                }
            }
        }
    });
}

function CloseVetCase() {
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/VetCase/VetModule";
    document.location.href = url;
}

function onCancelFFEdit(params) {
    CloseFF(params);
}

function onSaveAndCloseFF(params) {
    var contentData = $("form").serialize(true);
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/FFPresenter/ShowFlexibleFormWindow";
    $.ajax({
        url: postUrl,
        cache: false,
        dataType: "json",
        type: "POST",
        data: contentData,
        success: function (result) {
            if (IsSessionExpired(result)) {
                return;
            }
            if (result) {
                ShowEidssErrorNotification(result, function () { });
            }
            else {
                CloseFF(params);
            }
        }
    });
}

function CloseFF(params) {
    var idfCase = params[0];
    var returnMethodName = params[1];
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/VetCase/" + returnMethodName + "?id=" + idfCase;
    document.location.href = url;
}