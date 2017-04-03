function onCancelLocationOfExposureEdit(idfCase) {
    CloseLocationOfExposure(idfCase);
}

function onSaveAndCloseLocationOfExposure(idfCase) {
    var contentData = $("form").serialize(true);
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/HumanCase/SaveLocationOfExposure";
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
                CloseLocationOfExposure(idfCase);                
            }
        }
    });
}

function CloseLocationOfExposure(idfCase) {
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/HumanCase/Investigation?id=" + idfCase;
    document.location.href = url;
}