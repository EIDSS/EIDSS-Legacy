function ShowGeoLocationPicker(idfGeoLocation) {
    var url = '../System/GeoLocationPicker?idfGeoLocation=' + idfGeoLocation;
    var title = EIDSS.BvMessages['titleGeoLocation'];
    ShowMessageWindow(url, 450, 310, title, false);        
}

function onGeoLocationChanged(idfGeoLocation, ObjectIdent, needCloseWindow) {
    var contentData = $("#Message .t-window-content form").serialize(true);
    $.ajax({
        url: "../System/SetGeoLocation",
        cache: false,
        dataType: "json",
        type: "GET",
        data: {
            idfGeoLocation: idfGeoLocation,
            formData: contentData,
            needCloseWindow: needCloseWindow
        },
        success: function (data) {
            var err = false;
            for (att in data.Values) {
                if (data.Values[att].typeName == "ErrorMessage") {
                    err = true;
                }
            }
            ApplyChanges(data);
            if (!err) {
                if (needCloseWindow) {
                    CloseMessageWindow();
                }
                else {
                    ShowEidssSuccessNotification('Saved', 'Success');
                }
            }
        },
        error: function () {
            CloseMessageWindow();
        }
    });
}

