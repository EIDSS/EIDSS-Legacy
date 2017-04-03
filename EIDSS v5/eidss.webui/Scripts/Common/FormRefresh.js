
function ApplyChanges(result) {
    var errMes = $("#ErrorMessage");
    //errMes.text("");
    for (att in result.Values) {
        /*
        if (result.Values[att].typeName == "ErrorMessage")
        {
        errMes.text(result.Values[att].value);
        $('#ErrorWindow').data('tWindow').center().open();
        }*/
        if (result.Values[att].typeName == "string" || result.Values[att].typeName == "String") {
            var editBox = $("#" + result.Values[att].controlName);
            if (editBox) {
                editBox.val(result.Values[att].value);
                if (result.Values[att].readOnly) {
                    editBox.attr("readonly", "readonly");
                    editBox.addClass("readonly-text");
                }
                else {
                    editBox.removeAttr("readonly");
                    editBox.removeClass("readonly-text");
                }
            }
        }
        if (result.Values[att].typeName == "DateTime" || result.Values[att].typeName == "DateTime?") {
            var datePicker_cnt = $("#" + result.Values[att].controlName);
            if (datePicker_cnt) {
                var datePicker = datePicker_cnt.data("tDatePicker");
                if (datePicker) {
                    if (result.Values[att].readOnly)
                        datePicker.disable();
                    else
                        datePicker.enable();
                    datePicker.value(result.Values[att].value);
                }
            }
        }
        if (result.Values[att].typeName == "Lookup") {
            var combobox_cnt = $("#" + result.Values[att].controlName);
            if (combobox_cnt) {
                var combobox = combobox_cnt.data("tComboBox");
                if (!combobox)
                    combobox = combobox_cnt.data("tDropDownList");
                if (combobox) {
                    if (result.Values[att].readOnly)
                        combobox.disable();
                    else
                        combobox.enable();
                    combobox.value(result.Values[att].value);
                }
            }
        }
    }
}

function ModelFieldLoadCombobox(e) {
    var combo = $("#" + e.target.id).data("tComboBox");
    combo.reload();
}

function ModelFieldChangedCombobox(e) {
    $.ajax({
        url: "/System/SetValue",
        cache: false,
        dataType: "json",
        type: "GET",
        data: {
            key: e.target.id,
            value: e.value
        },
        success: function (data) {
            ApplyChanges(data);
        }
    });
}

function ModelFieldChangedDropdownList(e) {
    $.ajax({
        url: "/System/SetValue",
        cache: false,
        dataType: "json",
        type: "GET",
        data: {
            key: e.target.id,
            value: e.value
        },
        success: function (data) {
            ApplyChanges(data);
        }
    });
}

function ModelFieldChangedDate(e) {
    $.ajax({
        url: "/System/SetValue",
        cache: false,
        dataType: "json",
        type: "GET",
        data: {
            key: e.target.id,
            value: $.telerik.formatString("{0:dd-MM-yyyy}", e.value)
        },
        success: function (data) {
            ApplyChanges(data);
        }
    });
}

function ModelFieldChangedDatetime(e) {
    $.ajax({
        url: "/System/SetValue",
        cache: false,
        dataType: "json",
        type: "GET",
        data: {
            key: e.target.id,
            value: $.telerik.formatString("{0:dd-MM-yyyyThh:mm:tt}", e.value)
        },
        success: function (data) {
            ApplyChanges(data);
        }
    });
}