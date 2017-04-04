function SelectCurrentItem(e) {

}

function OnComboboxMasterChange(ddlName, sessionKey) {
    CascadeUpdateSearchCombobox(ddlName, sessionKey);
}

function CascadeUpdateSearchCombobox(ddlName, sessionKey) {
    var slave = $(jq(ddlName + "SlaveName")).val();
    var ddlId = ddlName.replace(".", "_");
    var initValue = $("#" + ddlId).val();
    var params = $(jq(ddlName + "ParameterString")).val().replace("*value*", initValue);
    var ddlForUpdate = $('#' + slave);
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/Search/GetLookupSource?" + params;
    $.ajax({
        url: postUrl,
        cache: false,
        type: "POST",
        data: {
            sessionKey: sessionKey
        },
        datatype: "json",
        success: function (result) {
            if (IsSessionExpired(result)) {
                return;
            }
            ddlForUpdate.empty();
            FillComboBox(ddlForUpdate, result);
            slave = slave.replace("_", ".");
            if ($(jq(slave + "SlaveName")).length == 1) {
                CascadeUpdateSearchCombobox(slave, sessionKey);
            }
        }
    });
}

function FillStandardRange(range, idfrom, idto) {
    var date = new Date();
    var datefrom;    
    if (range == "month") {
         datefrom = new Date(date.getFullYear(), date.getMonth(), 1);        
    }
    else {
        if (range == "quarter") {
               datefrom = new Date(date.getFullYear(), 3*(date.getMonth() / 3), 1);                              
        }
        else {
            if (range == "year") {
                 datefrom = new Date(date.getFullYear(), 0, 1);                    
            }
        }
    }    
    var pickerFrom = $("#" + idfrom).data("tDatePicker");
    var pickerTo = $("#" + idto).data("tDatePicker");
    if (pickerFrom && pickerTo) {
        pickerFrom.value(datefrom);
        pickerTo.value(new Date(date.getFullYear(),date.getMonth(),date.getDate())); //always to current date
    }
}

function GoToSearchResults(actionName, controllerName) {    
    var data = $('form').serialize(true); 
    data = EscapeHtmlGtLtOnly(data);
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/" + controllerName + "/" + actionName + "?" + data;
    document.location.href = postUrl;
}