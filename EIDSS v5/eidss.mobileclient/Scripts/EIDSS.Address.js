function onCountryChanged(objectId, idfGeoLocation, controllerName) {
    // controllerName: 'Address' or 'GeoLocation'
    if (!controllerName) controllerName = 'Address';
    ApplyContainer.argument = [objectId, idfGeoLocation, controllerName];
    ApplyContainer.onAjaxSuccess = updateAfterCountryChanged;
    ModelFieldChangedCombobox(objectId + "Country");     
}

function updateAfterCountryChanged(e) {
    var objectId = e[0];
    var idfGeoLocation = e[1];
    var controllerName = e[2];
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/" + controllerName + "/SelectRegion";
    var cbCountry = $("#" + objectId + "Country");
    $.ajax({
        url: postUrl,
        type: "POST",
        data: {
            idfGeoLocation: idfGeoLocation,
            idfsCountry: cbCountry.val()
        },
        datatype: "json",
        success: function (result) {
            if (IsSessionExpired(result)) {
                return;
            }
            var cbRegion = $("#" + objectId + "Region");
            FillComboBox(cbRegion, result);
            var cbRayon = $("#" + objectId + "Rayon");
            cbRayon.empty();
            var cbSettlement = $("#" + objectId + "Settlement");
            cbSettlement.empty();
        }
    });
}

function onRegionChanged(objectId, idfGeoLocation, controllerName) {
    // controllerName: 'Address' or 'GeoLocation'
    if (!controllerName) controllerName = 'Address';
    ApplyContainer.argument = [objectId, idfGeoLocation, controllerName];
    ApplyContainer.onAjaxSuccess = updateAfterRegionChanged;
    ModelFieldChangedCombobox(objectId + "Region");     
}

function updateAfterRegionChanged(e) {    
    var objectId = e[0];
    var idfGeoLocation = e[1];
    var controllerName = e[2];
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/" + controllerName + "/SelectRayon";
    var cbRegion = $("#" + objectId + "Region");
    $.ajax({
        url: postUrl,
        type: "POST",
        data: {
            idfGeoLocation: idfGeoLocation,
            idfsRegion: cbRegion.val()
        },
        datatype: "json",
        success: function (result) {
            if (IsSessionExpired(result)) {
                return;
            }
            var cbRayon = $("#" + objectId + "Rayon");
            FillComboBox(cbRayon, result);
            var cbSettlement = $("#" + objectId + "Settlement");
            cbSettlement.empty();
        }
    });
}

function onRayonChanged(objectId, idfGeoLocation, controllerName) {
    // controllerName: 'Address' or 'GeoLocation'
    if (!controllerName) controllerName = 'Address';
    ApplyContainer.argument = [objectId, idfGeoLocation, controllerName];
    ApplyContainer.onAjaxSuccess = updateAfterRayonChanged;
    ModelFieldChangedCombobox(objectId + "Rayon");    
}

function updateAfterRayonChanged(e) {
    var objectId = e[0];
    var idfGeoLocation = e[1];
    var controllerName = e[2];
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/" + controllerName + "/SelectSettlement";
    var cbRayon = $("#" + objectId + "Rayon");
    $.ajax({
        url: postUrl,
        type: "POST",
        data: {
            idfGeoLocation: idfGeoLocation,
            idfsRayon: cbRayon.val()
        },
        datatype: "json",
        success: function (result) {
            if (IsSessionExpired(result)) {
                return;
            }
            var cbSettlement = $("#" + objectId + "Settlement");
            FillComboBox(cbSettlement, result);
        }
    });  
}