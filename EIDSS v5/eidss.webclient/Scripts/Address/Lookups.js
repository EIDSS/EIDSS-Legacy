function onCountryChanged(e) {
    if (e.previousValue == e.value) { return; }    
    ApplyContainer.argument = e;
    ApplyContainer.onAjaxSuccess = updateAfterCountryChanged;
    ModelFieldChangedCombobox(e);
}

function updateAfterCountryChanged(e) {
    var ObjectIdent = e.target.id.substring(0, e.target.id.lastIndexOf("_") + 1);    
    var Region = $("#" + ObjectIdent + "Region").data("tComboBox");
    var Rayon = $('#' + ObjectIdent + 'Rayon').data('tComboBox');
    var Settlement = $("#" + ObjectIdent + "Settlement").data("tComboBox");
    var Street = $("#" + ObjectIdent + "Street").data("tComboBox");
    var PostCode = $("#" + ObjectIdent + "PostCode").data("tComboBox");
    Region.value(null);
    Rayon.value(null);
    Settlement.value(null);
    if (Street) { Street.value(''); }
    if (PostCode) { PostCode.value(''); }
    Region.reload();
    Rayon.reload();
    Settlement.reload();
    if (Street) { Street.reload(); }
    if (PostCode) { PostCode.reload(); }
}

function onRegionChanged(e) {
    if (e.previousValue == e.value) { return; }
    ApplyContainer.argument = e;
    ApplyContainer.onAjaxSuccess = updateAfterRegionChanged;
    ModelFieldChangedCombobox(e);     
}

function updateAfterRegionChanged(e) {
    var ObjectIdent = e.target.id.substring(0, e.target.id.lastIndexOf("_") + 1);
    var Rayon = $('#' + ObjectIdent + 'Rayon').data('tComboBox');
    var Settlement = $("#" + ObjectIdent + "Settlement").data("tComboBox");
    var Street = $("#" + ObjectIdent + "Street").data("tComboBox");
    var PostCode = $("#" + ObjectIdent + "PostCode").data("tComboBox");
    Rayon.value(null);
    if (Settlement) { Settlement.value(null); }    
    if (Street) { Street.value(null); }
    if (PostCode) { PostCode.value(null); }
    Rayon.reload();
    if (Settlement) { Settlement.reload(); }
    if (Street) { Street.reload(); }
    if (PostCode) { PostCode.reload(); }
}

function onRayonChanged(e) {
    if (e.previousValue == e.value) { return; }
    ApplyContainer.argument = e;
    ApplyContainer.onAjaxSuccess = updateAfterRayonChanged;
    ModelFieldChangedCombobox(e);    
}

function updateAfterRayonChanged(e) {
    var ObjectIdent = e.target.id.substring(0, e.target.id.lastIndexOf("_") + 1);
    var Settlement = $("#" + ObjectIdent + "Settlement").data("tComboBox");
    var Street = $("#" + ObjectIdent + "Street").data("tComboBox");
    var PostCode = $("#" + ObjectIdent + "PostCode").data("tComboBox");
    if (Settlement) { Settlement.value(null); }    
    if (Street) { Street.value(null); }
    if (PostCode) { PostCode.value(null); }
    if (Settlement) { Settlement.reload(); }
    if (Street) { Street.reload(); }
    if (PostCode) { PostCode.reload(); }
}

function onSettlementChanged(e) {
    if (e.previousValue == e.value) { return; }
    ApplyContainer.argument = e;
    ApplyContainer.onAjaxSuccess = updateAfterSettlementChanged;
    ModelFieldChangedCombobox(e);    
}

function updateAfterSettlementChanged(e) {
    var ObjectIdent = e.target.id.substring(0, e.target.id.lastIndexOf("_") + 1);
    var Street = $("#" + ObjectIdent + "Street").data("tComboBox");
    var PostCode = $("#" + ObjectIdent + "PostCode").data("tComboBox");
    if (Street) { Street.value(null); }
    if (PostCode) { PostCode.value(null); }
    if (Street) { Street.reload(); }
    if (PostCode) { PostCode.reload(); }
    SetStreetAndPostCode(ObjectIdent);
}

function SetStreetAndPostCode(ObjectIdent) {    
    var needSetStreetAndPostCode = $("#needSetStreetAndPostCode");
    if (needSetStreetAndPostCode == null || needSetStreetAndPostCode.val() == null || needSetStreetAndPostCode.val().toLowerCase() != "true") { return; }
    var strStreetName = $("#strStreetName");
    if (strStreetName != null && strStreetName.val() != "") {
        $("#" + ObjectIdent + "Street").data("tComboBox").$input[0].value = strStreetName.val();
    }
    var strPostCode = $("#strPostCode");
    if (strPostCode != null && strPostCode.val() != "") {
        $("#" + ObjectIdent + "PostCode").data("tComboBox").$input[0].value = strPostCode.val();
    }
//    needSetStreetAndPostCode[0].value = false;
}
