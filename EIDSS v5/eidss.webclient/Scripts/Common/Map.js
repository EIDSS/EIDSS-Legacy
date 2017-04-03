function ShowMap(objectIdent) {
    var lang = GetSiteLanguage();
    var link = "/" + lang + "/Map/Get";
    var lat = $("#" + objectIdent + "dblLatitude").data('tTextBox').value();
    var lon = $("#" + objectIdent + "dblLongitude").data('tTextBox').value(); ;

    var args = '';
    if (lat != null && lon != null)
        args += '?lat=' + lat + '&lon=' + lon;

    if (args == '') {
        var regc = $("#" + objectIdent + "Region").data('tComboBox');
        var rayc = $("#" + objectIdent + "Rayon").data('tComboBox');
        var settlec = $("#" + objectIdent + "Settlement").data('tComboBox');

        if (regc && rayc && settlec) {
            var reg = regc.value();
            var ray = rayc.value();
            var settle = settlec.value();
            if (reg != null && ray != null && settle != null) {
                args += '?region=' + reg + '&rayon=' + ray + '&settlement=' + settle;
            }
        }
    }

    $("#MapOpenerId").val(objectIdent);

    var child = window.open(link + args, "Map", '');
    child.opener = self;
}

function SetNewCoordinates(lat, lon) {
    var objectIdent = $("#MapOpenerId").val();
    $("#" + objectIdent + "dblLatitude").data('tTextBox').value(lat);
    $("#" + objectIdent + "dblLongitude").data('tTextBox').value(lon);
}