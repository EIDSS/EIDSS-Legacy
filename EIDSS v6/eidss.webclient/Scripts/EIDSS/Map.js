var MapOpenerId;
var MapOpenerCallback;

function ShowMap(objectIdent, callback) {
    //showLoading();
    var lang = GetSiteLanguage();
    var link = "/" + lang + "/Map/Get";
    var lat = numericTextBoxFacade.getValue(objectIdent + "dblLatitude");
    var lon = numericTextBoxFacade.getValue(objectIdent + "dblLongitude");

    var args = '';
    if (lat != null && lon != null)
        args += '?lat=' + lat + '&lon=' + lon;

    if (args == '') {
        var regc = comboBoxFacade.getControlData(objectIdent + "Region");
        var rayc = comboBoxFacade.getControlData(objectIdent + "Rayon");
        var settlec = comboBoxFacade.getControlData(objectIdent + "Settlement");

        if (regc && rayc && settlec) {
            var reg = comboBoxFacade.getValueByControlData(regc);
            var ray =comboBoxFacade.getValueByControlData(rayc);
            var settle =comboBoxFacade.getValueByControlData(settlec);
            if (reg != null && ray != null && settle != null) {
                args += '?region=' + reg + '&rayon=' + ray + '&settlement=' + settle;
            }
        }
    }

    //$("#MapOpenerId").val(objectIdent);
    MapOpenerId = objectIdent;
    MapOpenerCallback = callback;
    bvPopup.initAndShowModal("MapWindow", link + args, EIDSS.BvMessages['strMap'], 630, 240);
    //child.opener = self;
}

function SetNewCoordinates(lat, lon) {
    //var objectIdent = $("#MapOpenerId").val();
    objectIdent = MapOpenerId;
    //numericTextBoxFacade.setValueById(objectIdent + "dblLatitude", lat);
    //numericTextBoxFacade.setValueById(objectIdent + "dblLongitude", lon);
    formRefresher.onFieldChanged(objectIdent + "dblLatitude", lat);
    formRefresher.onFieldChanged(objectIdent + "dblLongitude", lon);
    if (MapOpenerCallback != undefined)
        MapOpenerCallback(objectIdent, lat, lon);
}