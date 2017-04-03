function onRegionChanged(e) {   
    if (e.previousValue != e.value) {        
        ModelFieldChangedCombobox(e);
        var ObjectIdent = e.target.id.substring(0, e.target.id.lastIndexOf("_") + 1);        
        var Rayon = $('#' + ObjectIdent + 'Rayon').data('tComboBox');
        var Settlement = $("#" + ObjectIdent + "Settlement").data("tComboBox");
        var Street = $("#" + ObjectIdent + "Street").data("tComboBox");
        var PostCode = $("#" + ObjectIdent + "PostCode").data("tComboBox");        
        Rayon.value(null);
        Settlement.value(null);
        Street.value(null);
        PostCode.value(null);
        Rayon.reload();
        Settlement.reload();
        Street.reload();
        PostCode.reload();        
    }
}
function onRayonChanged(e) {
    if (e.previousValue != e.value) {      
        ModelFieldChangedCombobox(e);
        var ObjectIdent = e.target.id.substring(0, e.target.id.lastIndexOf("_") + 1);
        var Settlement = $("#" + ObjectIdent + "Settlement").data("tComboBox");
        var Street = $("#" + ObjectIdent + "Street").data("tComboBox");
        var PostCode = $("#" + ObjectIdent + "PostCode").data("tComboBox");
        Settlement.value(null);
        Street.value(null);
        PostCode.value(null);
        Settlement.reload();
        Street.reload();
        PostCode.reload();
    }
}
function onSettlementChanged(e) {
    if (e.previousValue != e.value) {
        ModelFieldChangedCombobox(e);
        var ObjectIdent = e.target.id.substring(0, e.target.id.lastIndexOf("_") + 1);
        var Street = $("#" + ObjectIdent + "Street").data("tComboBox");
        var PostCode = $("#" + ObjectIdent + "PostCode").data("tComboBox");
        Street.value(null);
        PostCode.value(null);
        Street.reload();
        PostCode.reload();
    }
}