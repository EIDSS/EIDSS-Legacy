var geoLocation = {
    formNumber : "C14",

    initInlinePicker: function(isReadOnly) {
        var btGeoLocationPicker = $("#buttonGeoLocationPicker");
        if (isReadOnly.toString().toLowerCase() == 'true') {
            btGeoLocationPicker.attr('disabled', 'disabled');
        }    
    },
    
    showPicker: function (idfGeoLocation) {
        var url = bvUrls.getGeoLocationPickerUrl() + '?idfGeoLocation=' + idfGeoLocation;
        var title = EIDSS.BvMessages['titleGeoLocation'];
        bvPopup.showDefault(url, title, 700, 290, false);
        windowFacade.addFormNumber(bvPopup.defaultName, geoLocation.formNumber);
    },

    showFullPicker: function (idfGeoLocation) {
        var url = bvUrls.getGeoLocationFullPickerUrl() + '?idfGeoLocation=' + idfGeoLocation;
        var title = EIDSS.BvMessages['titleGeoLocation'];
        bvPopup.showDefault(url, title, 700, 290, false);
        windowFacade.addFormNumber(bvPopup.defaultName, geoLocation.formNumber);
    },

    onPickerChanged: function (idfGeoLocation) {
        var contentData = bvPopup.getDefaultWindowData();
        $.ajax({
            url: bvUrls.getSetGeoLocationUrl(),
            dataType: "json",
            type: "GET",
            data: {
                idfGeoLocation: idfGeoLocation,
                formData: contentData
            },
            success: function (data) {
                var hasError = formRefresher.hasError(data);
                formRefresher.updateControls(data);
                if (!hasError) {
                    bvPopup.closeDefaultPopup();
                    }
            },
            error: function () {
                bvPopup.closeDefaultPopup();
            }
        });
    },
    
    onCoordinateChangedSuccess: function (id) {
        comboBoxFacade.reloadReferenceComboBoxWithoutClearValue(id, 'Region');
        comboBoxFacade.reloadReferenceComboBoxWithoutClearValue(id, 'Rayon');
        comboBoxFacade.reloadReferenceComboBoxWithoutClearValue(id, 'Settlement');
    },

    onCoordinateChanged: function (e) {
        var id = comboBoxFacade.getIdByE(e);
        formRefresher.setOnChangedSuccess(geoLocation.onCoordinateChangedSuccess, id);
        formRefresher.onNumericChanged(e);
    },

    onCoordinateByMapChanged: function (objectIdent, lat, lon) {
        var idfGeoLocation = objectIdent.substring(objectIdent.indexOf('_') + 1, objectIdent.lastIndexOf('_'));
        $.ajax({
            url: bvUrls.getSetGeoLocationFromMapUrl(),
            dataType: "json",
            type: "GET",
            data: {
                idfGeoLocation: idfGeoLocation,
                dblLatitude: lat,
                dblLongitude: lon
            },
            success: function (data) {
                formRefresher.updateControls(data);
                geoLocation.onCoordinateChangedSuccess(objectIdent);
            },
            error: function () {
            }
        });
    },

}
