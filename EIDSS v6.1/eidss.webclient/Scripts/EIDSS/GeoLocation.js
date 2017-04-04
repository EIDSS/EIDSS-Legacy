var geoLocation = {
    formNumber : "C14",

    initInlinePicker: function(isReadOnly) {
        var btGeoLocationPicker = $("#buttonGeoLocationPicker");
        if (isReadOnly.toString().toLowerCase() == 'true') {
            btGeoLocationPicker.attr('disabled', 'disabled');
        }    
    },
    
    showPicker: function (idfGeoLocation) {
        var url = bvUrls.getGeoLocationPickerUrl({idfGeoLocation: idfGeoLocation});
        var title = EIDSS.BvMessages['titleGeoLocation'];
        bvPopup.showDefault(url, title, geoLocation.formNumber, 700, 290, false);
    },

    onPickerChanged: function (idfGeoLocation) {
        var contentData = bvPopup.getDefaultWindowData();
        $.ajax({
            url: bvUrls.getSetGeoLocationUrl(),
            dataType: "json",
            type: "POST",
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
    
    /*onCoordinateChangedSuccess: function (id) {
        comboBoxFacade.reloadReferenceComboBox2WithoutClearValue(id, 'Region');
        comboBoxFacade.reloadReferenceComboBox2WithoutClearValue(id, 'Rayon');
        comboBoxFacade.reloadReferenceComboBox2WithoutClearValue(id, 'Settlement');
    },*/

    onCoordinateChanged: function (e) {
        //var id = comboBoxFacade.getIdByE(e);
        //formRefresher.setOnChangedSuccess(geoLocation.onCoordinateChangedSuccess, id);
        formRefresher.onNumericChanged(e);
    },

    onCoordinateByMapChanged: function (objectIdent, lat, lon) {
        var idfGeoLocation = objectIdent.substring(objectIdent.indexOf('_') + 1, objectIdent.lastIndexOf('_'));
        showLoading();
        $.ajax({
            url: bvUrls.getSetGeoLocationFromMapUrl(),
            dataType: "json",
            type: "POST",
            data: {
                idfGeoLocation: idfGeoLocation,
                strLatitude: lat.toString(),
                strLongitude: lon.toString()
            },
            success: function (data) {
                hideLoading();
                formRefresher.updateControls(data);
                //geoLocation.onCoordinateChangedSuccess(objectIdent);
            },
            error: function () {
                hideLoading();
            }
        });
    },

}
