function onFFGridLoad(gridId) {
    if ($("#" + gridId + " input:radio").length == 0) {
        $("#pnButtons_" + gridId + " button").hide();
        $("#btAdd_" + gridId).show();
    }
    else {
        SelectGridRow(gridId, 1);
    }
}

function onEditFFGridRowClick(gridId, isNew) {
    var idfRow = "-1";
    if (isNew === 'false') {
        idfRow = GetSelectGridItemId(gridId);
    }
    if (!idfRow) {
        idfRow = "-1";
    }
    var index = gridId.indexOf("_");
    var idfsSection = gridId.substring(index + 1, gridId.length);
    var ffKey = $("#hdnFFKey").val();
    var ffpresenterId = $("#hdnFFpresenterId").val();
    var lang = GetSiteLanguage();
    var postUrl = "/FFPresenter/EditTableRow?idfsSection=" + idfsSection + "&isNew=" + isNew + "&idfRow=" + idfRow + "&key=" + ffKey +
        "&ffpresenterId=" + ffpresenterId;
    var url = "/" + lang + postUrl;
    StoreFF(url);
}

function onCopyFFGridRowClick(gridId) {
    var idfRow = GetSelectGridItemId(gridId);
    var index = gridId.indexOf("_");
    var idfsSection = gridId.substring(index + 1, gridId.length);
    var ffKey = $("#hdnFFKey").val();
    var ffpresenterId = $("#hdnFFpresenterId").val();
    var lang = GetSiteLanguage();
    var postUrl = "/FFPresenter/CopyTableRow?idfsSection=" + idfsSection + "&idfRow=" + idfRow + "&key=" + ffKey + "&ffpresenterId=" + ffpresenterId;
    var url = "/" + lang + postUrl;
    $.ajax({
        type: 'GET',
        url: url,
        success: function () {
            ReloadFFGridData(gridId, idfsSection, ffKey, ffpresenterId);
        }
    });
}

function onRemoveFFGridRowClick(gridId) {
    var idfRow = GetSelectGridItemId(gridId);
    var index = gridId.indexOf("_");
    var idfsSection = gridId.substring(index + 1, gridId.length);
    var ffKey = $("#hdnFFKey").val();
    var ffpresenterId = $("#hdnFFpresenterId").val();
    var lang = GetSiteLanguage();
    var postUrl = "/FFPresenter/RemoveTableRow?idfsSection=" + idfsSection + "&idfRow=" + idfRow + "&key=" + ffKey + "&ffpresenterId=" + ffpresenterId;
    var url = "/" + lang + postUrl;
    $.ajax({
        type: 'GET',
        url: url,
        success: function () {
            ReloadFFGridData(gridId, idfsSection, ffKey, ffpresenterId);
        }
    });
}

function ReloadFFGridData(gridId, idfsSection, ffKey, ffpresenterId) {
    var postUrl = "/FlexForms/SectionTemplateTableNodeRender?idfsSection=" + idfsSection + "&key=" + ffKey + "&ffpresenterId=" + ffpresenterId;
    var lang = GetSiteLanguage();
    url = "/" + lang + postUrl;
    $.ajax({
        type: 'GET',
        url: url,
        success: function (result) {
            $("#pn_idfsSection_" + idfsSection).html($(result)[2].innerHTML);
            $.each($(result), function (index, value) {
                if (value.innerHTML && value.innerHTML.indexOf('id="pnButtons_idfsSection_' + idfsSection + '"') > 0) {
                    $("#pn_idfsSection_" + idfsSection).html(value.innerHTML);
                }
            });
            onFFGridLoad(gridId);
        }
    });
}

function onSaveAndCloseFFGridDetails(urlForReturn) {
    var contentData = $("form").serialize(true);
    var lang = GetSiteLanguage();
    var ffKey = $("#hdnFFKey").val();
    var ffpresenterId = $("#hdnFFpresenterId").val();
    var postUrl = "/" + lang + "/FFPresenter/EditTableRow?" + "key=" + ffKey + "&ffpresenterId=" + ffpresenterId;
    $.ajax({
        url: postUrl,
        cache: false,
        dataType: "json",
        type: "POST",
        data: contentData,
        success: function (data) {
            if (data) {
                ShowEidssErrorNotification(data);
            }
            else {
                document.location.href = urlForReturn;
            }
        }
    });
}

function onCancelFFGridDetailsEdit(urlForReturn) {
    if ($("#hdnIsNew").val() == '0') {
        document.location.href = urlForReturn;
        return;
    }
    var idfRow = $("#hdnIdfRow").val(); 
    var idfsSection = $("#hdnIdfsSection").val();
    var ffKey = $("#hdnFFKey").val();
    var ffpresenterId = $("#hdnFFpresenterId").val();
    var lang = GetSiteLanguage();
    var postUrl = "/FFPresenter/RemoveTableRow?idfsSection=" + idfsSection + "&idfRow=" + idfRow + "&key=" + ffKey + "&ffpresenterId=" + ffpresenterId;
    var url = "/" + lang + postUrl;
    $.ajax({
        type: 'GET',
        url: url,
        success: function () {
            document.location.href = urlForReturn;
        }
    });
}

function StoreFF(onSuccessPath) {
    var contentData = $("form").serialize(true);
    var lang = GetSiteLanguage();
    var controller = $("#hdnControllerName").val();
    var postUrl = "/" + lang + "/" + controller + "/StoreCase";
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