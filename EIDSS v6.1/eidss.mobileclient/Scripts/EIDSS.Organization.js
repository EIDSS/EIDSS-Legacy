function OpenFacilityPage(currentControllerName, facilityPath) {
    var contentData = $("#tabs-1 form").serialize(true);
    contentData = EscapeHtmlGtLtOnly(contentData);
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/" + currentControllerName + "/StoreCase";
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
                document.location.href = facilityPath;
            }
        }
    });
}

function onClianOrganization(btnClianId, objectId, idfsOrganizationPropertyName, strOrganizationPropertyName) {
    var btnClian = $("#" + btnClianId);
    btnClian.attr('disabled', 'disabled');
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/Organization/ClianOrganizationPicker";
    $.ajax({
        url: postUrl,
        cache: false,
        dataType: "json",
        type: "GET",
        data: {
            objectId: objectId,
            idfsOrganizationPropertyName: idfsOrganizationPropertyName,
            strOrganizationPropertyName: strOrganizationPropertyName
        },
        success: function (data) {
            if (IsSessionExpired(data)) {
                return;
            }
            ApplyChanges(data);
        }
    });
}