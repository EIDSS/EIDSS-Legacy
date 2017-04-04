function SelectTabs(list) {
    var curTab = $("#tabs .ui-state-default.ui-tabs-selected");
    curTab.removeClass('ui-tabs-selected');
    curTab.removeClass('ui-state-active');
    var tabs = $("#tabs .ui-state-default");
    for (var i = 0; i < list.length; i++) {
        var className = tabs[list[i]].className + " ui-tabs-selected ui-state-active";
        tabs[list[i]].className = className;
    }
}

function OpenTab(actionName, controllerName, idfCase) {
    var contentData = $("#tabs-1 form").serialize(true);
    contentData = EscapeHtmlGtLtOnly(contentData);
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/" + controllerName + "/StoreCase";
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
                var path = "/" + lang + "/" + controllerName + "/" + actionName + "?id=" + idfCase;
                document.location.href = path;
            }
        }
    });
}