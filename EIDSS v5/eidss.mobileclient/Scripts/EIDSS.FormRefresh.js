var currentLang = GetSiteLanguage();
var systemUrl = '/' + currentLang + '/System/SetValue';

var ApplyContainer = {
    argument: null,
    onAjaxSuccess: function() {
    }
};

function ApplyChanges(result) {
    for (var att in result.Values) {        
        if (result.Values[att].typeName == "ErrorMessage") {
            ShowEidssErrorNotification(result.Values[att].value, function () { });
        }        
//        if (result.Values[att].typeName == "Lookup" && (!result.Values[att].value || result.Values[att].value=="" )) {
//            var lookup = $("#" + result.Values[att].controlName);
//            lookup.empty();
//        }
        if ((result.Values[att].typeName == "DateTime" || result.Values[att].typeName == "DateTime?") && $("#" + result.Values[att].controlName + "_Day").length == 1) {
            // for android datepicker
            var cbDays = $("#" + result.Values[att].controlName + "_Day");
            var cbMonthes = $("#" + result.Values[att].controlName + "_Month");
            var cbYears = $("#" + result.Values[att].controlName + "_Year");
            if (cbDays && cbMonthes && cbYears) {
                if (result.Values[att].readOnly) {                    
                    DisableControl(cbDays);
                    DisableControl(cbMonthes);
                    DisableControl(cbYears);                    
                }
                else {
                    EnableControl(cbDays);
                    EnableControl(cbMonthes);
                    EnableControl(cbYears);
                }
                if (result.Values[att].mandatory) {
                    cbDays.addClass("requiredField");
                    cbMonthes.addClass("requiredField");
                    cbYears.addClass("requiredField");
                }
                else {
                    cbDays.removeClass("requiredField");
                    cbMonthes.removeClass("requiredField");
                    cbYears.removeClass("requiredField");
                }
                var controlName = result.Values[att].controlName;
                var objectIdent = controlName.substring(controlName.lastIndexOf("_") + 1);
                var label = $("label[for=" + objectIdent + "]");
                if (result.Values[att].invisible) {
                    cbDays.addClass("invisible");
                    cbMonthes.addClass("invisible");
                    cbYears.addClass("invisible");
                    label.addClass("invisible");
                }
                else {
                    cbDays.removeClass("invisible");
                    cbMonthes.removeClass("invisible");
                    cbYears.removeClass("invisible");
                    label.removeClass("invisible");
                }
            }
        }
        else {
            var editBox = $("#" + result.Values[att].controlName);
            if (editBox) {
                editBox.val(result.Values[att].value);
                if (result.Values[att].readOnly) {
                    DisableControl(editBox);
                }
                else {
                    EnableControl(editBox);
                }
                if (result.Values[att].mandatory) {
                    editBox.addClass("requiredField");
                }
                else {
                    editBox.removeClass("requiredField");
                }
                var controlName = result.Values[att].controlName;
                var objectIdent = controlName.substring(controlName.lastIndexOf("_") + 1);
                var label = $("label[for=" + objectIdent + "]");
                if (result.Values[att].invisible) {
                    editBox.addClass("invisible");
                    label.addClass("invisible");
                }
                else {
                    editBox.removeClass("invisible");
                    label.removeClass("invisible");
                }
            }
        }       
    }
}

function EnableControl(control) {
    control.removeAttr("readonly");
    control.removeAttr("disabled");
    control.removeClass("readonlyField");
}

function DisableControl(control) {
    control.attr("readonly", "readonly");
    control.attr("disabled", "disabled");
    control.addClass("readonlyField");
}

function ModelFieldChangedCombobox(cbId) {
    var cb = $("#" + cbId);
    $.ajax({
        url: systemUrl,
        cache: false,
        dataType: "json",
        type: "GET",
        data: {
            key: cbId,
            value: cb.val()
        },
        success: function (data) {
            if (IsSessionExpired(data)) {
                return;
            }
            ApplyChanges(data);
            ApplyContainer.onAjaxSuccess(ApplyContainer.argument);
            ApplyContainer.argument = '';
            ApplyContainer.onAjaxSuccess = function () { };
        }
    });
}

function ModelFieldChangedNumeric(textBoxName) {
    var textBoxValue = $("#" + textBoxName).val();
    var parseValue = parseInt(textBoxValue);
    if (!parseValue) {        
        $("#" + textBoxName).val("");
        return;
    }    
    textBoxValue = parseValue;
    $("#" + textBoxName).val(textBoxValue);    
    $.ajax({
        url: systemUrl,
        cache: false,
        dataType: "json",
        type: "GET",
        data: {
            key: textBoxName,
            value: textBoxValue
        },
        success: function (data) {
            if (IsSessionExpired(data)) {
                return;
            }
            ApplyChanges(data);
        }
    });
}

function bvNothing(e) {
}

function OnDateboxChanged(controlId) {
    var dateBox = $("#" + controlId + "_Date");
    var timeBox = $("#" + controlId + "_Time");
    if (dateBox.val()) {
        EnableControl(timeBox);
    }
    else {
        timeBox.val('');
        DisableControl(timeBox);
    }
}