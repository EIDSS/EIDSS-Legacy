function StoreFarmAndOpenFarmsList(idfCase, farmId) {
    var lang = GetSiteLanguage();
    var onSuccessPath = "/" + lang + "/Farm/FarmsList?rootKey=" + idfCase + "&farmId=" + farmId;
    StoreCase(onSuccessPath);
}

function StoreFarmAndOpenEpi(idfCase) {
    var lang = GetSiteLanguage();
    var onSuccessPath = "/" + lang + "/Farm/EpidemiologicalInformation?root=" + idfCase;
    StoreCase(onSuccessPath);
}

function onSaveAndCloseEpi(idfCase) {
    var lang = GetSiteLanguage();
    var onSuccessPath = "/" + lang + "/VetCase/FarmDetails" + "?id=" + idfCase;
    StoreCase(onSuccessPath);
}

function StoreCase(onSuccessPath) {
    var contentData = $("form").serialize(true);
    contentData = EscapeHtmlGtLtOnly(contentData);
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/VetCase/StoreCase";
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
                var path = onSuccessPath;
                document.location.href = path;
            }
        }
    });
}

function CloseEpi(idfCase) {
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/VetCase/FarmDetails" + "?id=" + idfCase;
    document.location.href = url;
}

function onFarmSelected(idfCase, farmId) {
    SetSelectedFarm(idfCase, farmId);
}

function onClearFarm(idfCase) {
    SetSelectedFarm(idfCase, 0);
}

function SetSelectedFarm(idfCase, farmId) {
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/Farm/SetSelectedFarm";
    $.ajax({
        url: postUrl,
        cache: false,
        dataType: "json",
        type: "POST",
        data: {
            root: idfCase,
            selectedId: farmId
        },
        success: function (data) {
            if (IsSessionExpired(data)) {
                return;
            }
            ApplyChanges(data);
            postUrl = "/" + lang + "/VetCase/FarmDetails?id=" + idfCase;
            document.location.href = postUrl;
        }
    });
}