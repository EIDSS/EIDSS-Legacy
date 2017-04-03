var expr = new RegExp('(http(s?)\://)', 'ig');
var currentLang = document.URL.replace(expr, '', '$1');
currentLang = currentLang.substring(currentLang.indexOf("/") + 1, currentLang.length);
currentLang = currentLang.substring(0, currentLang.indexOf("/"));

var systemUrl = '/'+ currentLang + '/System/SetValue';
var systemUrlWithIgnore = '/' + currentLang + '/System/SetValueWithIgnore';
var cbFreeInputExceptions = ['street', 'postcode'];
var ApplyContainer = {
    argument: null,
    onAjaxSuccess: function () { },
    onEidssError: function (msg) { ShowEidssErrorNotification(msg, function () { }); }
}

//var heartbeatUrl = '/' + currentLang + '/System/Heartbeat';

function ApplyChanges(result) {
    for (att in result.Values) {
        if (result.Values[att].typeName == "ErrorMessage") {               
                var msg = result.Values[att].value;
                ApplyContainer.onEidssError(msg);
                ApplyContainer.onEidssError = function (msg) { ShowEidssErrorNotification(msg, function () { }); };
                continue;
        }
            if (result.Values[att].typeName == "AskMessage") {
                var msg = result.Values[att].value;
                var oldKey = result.Values[att].propertyName;
                var oldVal = result.Values[att].controlName;
                ApplyContainer.onEidssError = function (msg) {
                    ShowEidssYesNoDialog('Warning', msg, function () {
                        $.ajax({
                            url: systemUrlWithIgnore,
                            cache: false,
                            dataType: "json",
                            type: "GET",
                            async: false,
                            data: {
                                key: oldKey,
                                value: oldVal,
                                ignoreErr: 1
                            },
                            success: function (data) {
                                ApplyChanges(data);
                            },
                            error: function (jqXHR, textStatus, errorThrown) {
                                if (textStatus == 'parsererror') {
                                    ShowEidssErrorNotification(EIDSS.BvMessages['ErrAuthentication'], function () { });
                                }
                            }
                        });
                    },
                    function () { });
                };
                ApplyContainer.onEidssError(msg);
                ApplyContainer.onEidssError = function (msg) { ShowEidssErrorNotification(msg, function () { }); };
                continue;
            }
            if (result.Values[att].typeName == "AskPostMessage") {
                var msg = result.Values[att].value;
                ApplyContainer.onEidssError = function (msg) {
                    ShowEidssYesNoDialog('Warning', msg, function () {
                        AjaxFormSubmitWithIgnore(ApplyContainer.onAjaxSuccess);
                        ApplyContainer.onAjaxSuccess = function () { };
                    },
                    function () { });
                };
                ApplyContainer.onEidssError(msg);
                ApplyContainer.onEidssError = function (msg) { ShowEidssErrorNotification(msg, function () { }); };
                continue;
            }
            if (result.Values[att].typeName == "string" || result.Values[att].typeName == "String") {
                if (result.Values[att].controlName.indexOf("button") >= 0) {
                    var button = $("#" + result.Values[att].propertyName);
                    if (result.Values[att].readOnly) {
                        button.attr('disabled', 'disabled');
                    }
                    else {
                        button.removeAttr("disabled");
                    }
                }
                var editBox = $("#" + result.Values[att].controlName);
            if (editBox) {
                editBox.val(result.Values[att].value);
                if (result.Values[att].readOnly) {
                    editBox.attr("readonly", "readonly");
                    editBox.addClass("readonlyField");
                }
                else {
                    editBox.removeAttr("readonly");
                    editBox.removeClass("readonlyField");
                }
                if (result.Values[att].mandatory) {
                    editBox.addClass("requiredField");
                }
                else {
                    editBox.removeClass("requiredField");
                }
                controlName = result.Values[att].controlName;
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
            continue;
        }
        if (result.Values[att].typeName == "DateTime" || result.Values[att].typeName == "DateTime?") {
            var datePicker_cnt = $("#" + result.Values[att].controlName);
            if (datePicker_cnt) {
                var datePicker = datePicker_cnt.data("tDatePicker");
                if (datePicker) {
                    if (result.Values[att].mandatory) {
                        datePicker_cnt.addClass("requiredField");
                    }
                    else {
                        datePicker_cnt.removeClass("requiredField");
                    }
                    if (result.Values[att].readOnly) {
                        datePicker.disable();
                    }
                    else {
                        datePicker.enable();
                    }
                    controlName = result.Values[att].controlName;
                    var objectIdent = controlName.substring(controlName.lastIndexOf("_") + 1);
                    var label = $("label[for=" + objectIdent + "]");
                    if (result.Values[att].invisible) {
                        label.addClass("invisible");
                        datePicker_cnt.addClass("invisible");
                    }
                    else {
                        label.removeClass("invisible");
                        datePicker_cnt.removeClass("invisible");
                    }
                    datePicker.value(result.Values[att].value);
                }
            }
            continue;
        }
        if (result.Values[att].typeName == "Int32" || result.Values[att].typeName == "Int32?"
            || result.Values[att].typeName == "int" || result.Values[att].typeName == "int?"
            || result.Values[att].typeName == "Double" || result.Values[att].typeName == "Double?"
            || result.Values[att].typeName == "double" || result.Values[att].typeName == "double?"
            || result.Values[att].typeName == "Int64" || result.Values[att].typeName == "Int64?"
            || result.Values[att].typeName == "long" || result.Values[att].typeName == "long?"
            ) {
            var numeric_cnt = $("#" + result.Values[att].controlName);
            if (numeric_cnt) {
                var numeric = numeric_cnt.data("tTextBox");
                if (numeric) {
                    if (result.Values[att].mandatory) {
                        numeric_cnt.addClass("requiredField");
                    }
                    else {
                        numeric_cnt.removeClass("requiredField");
                    }
                    if (result.Values[att].readOnly)
                        numeric.disable();
                    else
                        numeric.enable();
                    numeric.value(result.Values[att].value);
                }
                else {
                    var hidden_id = $("#" + result.Values[att].controlName);
                    if (hidden_id) {
                        hidden_id.val(result.Values[att].value);
                    }
                }
            }
            if (result.Values[att].typeName == "Int64?" || result.Values[att].typeName == "Int64") {
                if (result.Values[att].readOnly) {
                    DisableInlineItemPicker(result.Values[att].controlName, result.Values[att].propertyName);
                }
                else {
                    EnableInlineItemPicker(result.Values[att].controlName, result.Values[att].propertyName, result.Values[att].value);
                }
                continue;
            }
            continue;
        }
        if (result.Values[att].typeName == "Lookup") {
            var combobox_cnt = $("#" + result.Values[att].controlName);
            if (combobox_cnt) {
                var combobox = combobox_cnt.data("tComboBox");
                if (!combobox)
                    combobox = combobox_cnt.data("tDropDownList");
                if (combobox) {
                    var val = result.Values[att].value;
                    if (val == "0")
                        val = "";

                    combobox.value(val); // we should set this value before async reloading and then after
                    combobox.index = combobox.selectedIndex; // fixing telerik error, it changes selectedIndex and doesn'n change index field

                    //combobox.reload();
                    
                    if (result.Values[att].mandatory) {
                        combobox_cnt.addClass("requiredField");
                    }
                    else {
                        combobox_cnt.removeClass("requiredField");
                    }
                    if (result.Values[att].readOnly)
                        combobox.disable();
                    else
                        combobox.enable();

                    var controlName = result.Values[att].controlName;
                    var objectIdent = controlName.substring(controlName.lastIndexOf("_") + 1);
                    var label = $("label[for=" + objectIdent + "]");
                    if (result.Values[att].invisible) {
                        label.addClass("invisible");
                        combobox_cnt.addClass("invisible");
                    }
                    else {
                        label.removeClass("invisible");
                        combobox_cnt.removeClass("invisible");
                    }
                    combobox.value(val);

                    if (att.indexOf("Address") == 0 && att.indexOf("Region") > 0) {
                        var ObjectIdent = att.substring(0, att.lastIndexOf("_") + 1);
                        var Rayon = $('#' + ObjectIdent + 'Rayon').data('tComboBox');
                        Rayon.value(null);
                        Rayon.reload();
                    }
                }
                else {
                    //maybe radio buttons?
                    var radio = $("[name=" + result.Values[att].controlName + "]");
                    if (radio.length > 0) {
                        radio.filter("[value=" + result.Values[att].value + "]").attr("checked", true);

                        if (result.Values[att].readOnly) {
                            for (i = 0; i < radio.length;i++ ) {
                                $(radio[i]).attr('disabled', true);
                            }
                        }
                        else {
                            for (i = 0; i < radio.length; i++) {
                                $(radio[i]).attr('disabled', false);
                            }
                        }
                    }
                }
            }
            continue;         
        }
        if (result.Values[att].typeName == "Child") {
            if (result.Values[att].readOnly) {
                DisableGrid(result.Values[att].controlName);
            }
            else {
                EnableGrid(result.Values[att].controlName);
            }
            continue;
        }
        if (result.Values[att].typeName == "Boolean?") {
            var checkbox_cnt = $("#" + result.Values[att].controlName);
            if (checkbox_cnt) {
                if (result.Values[att].readOnly) {
                    checkbox_cnt.attr("disabled", "disabled");
                }
                else {
                    checkbox_cnt.removeAttr("disabled");
                }

                if (checkbox_cnt[0]) {
                    if (result.Values[att].value == "True" || result.Values[att].value == "true") {
                        checkbox_cnt[0].value = "true";
                        checkbox_cnt[0].checked = true;
                    }
                    else {
                        checkbox_cnt[0].value = "false";
                        checkbox_cnt[0].checked = false;
                    }
                }
            }
            continue;
        }
    }
}

function ModelFieldLoadCombobox(e) {
    var combo = $("#" + e.target.id).data("tComboBox");
    combo.reload();
}


function CBoxValueIsValid(id) {
    var isException = false;
    for (var i = 0; i < cbFreeInputExceptions.length; i++) {
        if (id.toLowerCase().indexOf(cbFreeInputExceptions[i]) != -1) {
            isException = true;
            break;
        }
    }
    var cbox = $('#' + id).data('tComboBox');    
    if (cbox.value() == '')
        return;

    var text = $('#' + id + '-input');

    if (!isException && cbox.dropDown.$items) {
        var bFound = false;
        var val = text.val();
        if (cbox.dropDown != null && cbox.dropDown.$items != null) {
            for (var i = 0; i < cbox.dropDown.$items.length; i++) {
                var item = cbox.dropDown.$items[i].innerText;
                if (item == val) {
                    bFound = true;
                    break;
                }
            }
        }
        if (!bFound) {
            cbox.value("");
            return;
        }
    }

    /*
    if (!isException && cbox.dropDown.$items.length == 0 && text.val() != '') {
        cbox.value("");
    }

    if (!isException && cbox.value() == text.val() && isNaN(text.val())) {
        if (cbox.dropDown.$items.length == 0) {
            cbox.value("");
        }
        else {
            cbox.select(0);
        }
    }
    */
}

function FFModelFieldChangedCombobox(e) {
    if (e.value) {
        CBoxValueIsValid(e.target.id);
    }
}

function ModelFieldChangedCombobox(e) {
    if (e.value) {
        CBoxValueIsValid(e.target.id);
    }
    var val = $('#' + e.target.id).data('tComboBox').value();    
    $.ajax({
        url: systemUrl,
        cache: false,
        dataType: "json",
        type: "GET",
        data: {
            key: e.target.id,
            value: val
        },
        success: function (data) {
            ApplyChanges(data);            
            ApplyContainer.onAjaxSuccess(ApplyContainer.argument);
            ApplyContainer.argument = '';
            ApplyContainer.onAjaxSuccess = function () { };
        },
        error: function (jqXHR, textStatus, errorThrown) {
            if (textStatus == 'parsererror') {
                ShowEidssErrorNotification(EIDSS.BvMessages['ErrAuthentication'], function () { });
            }
        }
    });
}

function ModelFieldChangedDropdownList(e) {
    $.ajax({
        url: systemUrl,
        cache: false,
        dataType: "json",
        type: "GET",
        data: {
            key: e.target.id,
            value: e.value
        },
        success: function (data) {
            ApplyChanges(data);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            if (textStatus == 'parsererror') {
                ShowEidssErrorNotification(EIDSS.BvMessages['ErrAuthentication'], function () { });
            }
        }
    });
}

function NullableFormatString(format, value) {
    if (value == null) return null;
    return $.telerik.formatString("{0:dd-MM-yyyy}", value);
}

function ModelFieldChangedDate(e) {
    $.ajax({
        url: systemUrl,
        cache: false,
        dataType: "json",
        type: "GET",
        data: {
            key: e.target.id,
            value: NullableFormatString("{0:dd-MM-yyyy}", e.value)
        },
        success: function (data) {
            ApplyChanges(data);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            if (textStatus == 'parsererror') {
                ShowEidssErrorNotification(EIDSS.BvMessages['ErrAuthentication'], function () { });
            }
        }
    });
}

function ModelFieldChangedDatetime(e) {
    $.ajax({
        url: systemUrl,
        cache: false,
        dataType: "json",
        type: "GET",
        data: {
            key: e.target.id,
            value: NullableFormatString("{0:dd-MM-yyyyTHH:mm:ss}", e.value)
        },
        success: function (data) {
            ApplyChanges(data);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            if (textStatus == 'parsererror') {
                ShowEidssErrorNotification(EIDSS.BvMessages['ErrAuthentication'], function () { });
            }
        }
    });
}

function ModelFieldChangedNumeric(e) {
    $.ajax({
        url: systemUrl,
        cache: false,
        dataType: "json",
        type: "GET",
        data: {
            key: e.target.id,
            value: e.newValue
        },
        success: function (data) {
            ApplyChanges(data);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            if (textStatus == 'parsererror') {
                ShowEidssErrorNotification(EIDSS.BvMessages['ErrAuthentication'], function () { });
            }
        }
    });
}

function ModelFieldChangedEditbox(textBoxName) {
    var textBoxValue = $("#" + textBoxName).val();
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
            ApplyChanges(data);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            if (textStatus == 'parsererror') {
                ShowEidssErrorNotification(EIDSS.BvMessages['ErrAuthentication'], function () { });
            }
        }
    });
}

function ModelFieldChangedCheckbox(checkBoxName) {
    var checkBoxValue = "false";
    var checkBox = $("#" + checkBoxName)[0];
    if (checkBox.checked) {
        checkBox.value = "true";
        checkBoxValue = "true";
    }
    else {
        checkBox.value = "false";
    }
    $.ajax({
        url: systemUrl,
        cache: false,
        dataType: "json",
        async: false,
        type: "GET",
        data: {
            key: checkBoxName,
            value: checkBoxValue
        },
        success: function (data) {
            ApplyChanges(data);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            if (textStatus == 'parsererror') {
                ShowEidssErrorNotification(EIDSS.BvMessages['ErrAuthentication'], function () { });
            }
        }
    });
}

function ModelFieldChanged(fieldName, value) {
    $.ajax({
        url: systemUrl,
        cache: false,
        dataType: "json",
        type: "GET",
        data: {
            key: fieldName,
            value: value
        },
        success: function (data) {
            ApplyChanges(data);
            ApplyContainer.onAjaxSuccess(ApplyContainer.argument);
            ApplyContainer.argument = '';
            ApplyContainer.onAjaxSuccess = function () { };
        },
        error: function (jqXHR, textStatus, errorThrown) {
            if (textStatus == 'parsererror') {
                ShowEidssErrorNotification(EIDSS.BvMessages['ErrAuthentication'], function () { });
            }
        }
    });
}

function dump(obj) {
    obj = obj || {};
    var result = [];
    $.each(obj, function (key, value) {
        result.push('"' + key + '":"' + value + '"');
    });
    return '{' + result.join(',') + '}';
}

function bvNothing(e) {
}

function LimitTextArea(textAreaId) {
    var textArea = $("#" + textAreaId);
    var maxlength = textArea.attr('maxlength');
    var val = textArea.val();
    if (val.length > maxlength) {
        textArea.val(val.slice(0, maxlength));
    }
}

function reloadPartialDiv(query, divname, rootvalue) {
    $.ajax({
        url: query,
        cache: false,
        type: "GET",
        data: {
            root: rootvalue
        },
        success: function (data) {
            $("#" + divname).html(data);
            hideLoading();
        },
        error: function (error) {
            hideLoading();
        }
    });
}

function IsAllMandatoryFieldsFilled() {
    var val = $("input[name$='TentativeDiagnosis']");
    if (!val || !val.val()) {
        return false;
    }
    val = $("input[name$='strLastName']");
    if (!val || !val.val()) {
        return false;
    }
    var idfCurrentResidence = $('#IdfCurrentResidence')[0].value;
    val = $("#CurrentResidenceAddress_" + idfCurrentResidence + "_Region").data("tComboBox").$input[0];
    if (!val || !val.value) {
        return false;
    }
    val = $("#CurrentResidenceAddress_" + idfCurrentResidence + "_Rayon").data("tComboBox").$input[0];
    if (!val || !val.value) {
        return false;
    }
    return true;
}

function EnableInlineItemPicker(controlName, propertyName, value) {
    var arr = controlName.split('_');
    var objId = arr[1];
    EnableOrganizationPicker(objId, propertyName, value);
    EnableEmployeePicker(objId, propertyName, value);
}

function EnableOrganizationPicker(objectId, idfsOrganizationPropertyName, selectedId) {
    var btnSelectOrganization = $("#btnOrgSearchPicker_" + objectId + "_" + idfsOrganizationPropertyName);
    var btnClianOrganization = $("#btnOrgClian_" + objectId + "_" + idfsOrganizationPropertyName);
    if (!btnSelectOrganization || !btnClianOrganization) {
        return;
    }
    btnSelectOrganization.removeAttr('disabled');
    if (selectedId > 0) {
        btnClianOrganization.removeAttr('disabled');
    }
    else {
        btnClianOrganization.attr('disabled', 'disabled');
    }
}

function EnableEmployeePicker(objectId, idfsEmployeePropertyName, selectedId) {
    var btnSelectEmployee = $("#btnEmpSearchPicker_" + objectId + "_" + idfsEmployeePropertyName);
    var btnClianEmployee = $("#btnEmpClian_" + objectId + "_" + idfsEmployeePropertyName);
    if (!btnSelectEmployee || !btnClianEmployee) {
        return;
    }
    btnSelectEmployee.removeAttr('disabled');
    if (selectedId > 0) {
        btnClianEmployee.removeAttr('disabled');
    }
    else {
        btnClianEmployee.attr('disabled', 'disabled');
    }
}

function DisableInlineItemPicker(controlName, propertyName) {
    var arr = controlName.split('_');
    var objId = arr[1];
    DisableOrganizationPicker(objId, propertyName);
    DisableEmployeePicker(objId, propertyName);
}

function DisableOrganizationPicker(objectId, idfsOrganizationPropertyName) {
    var btnSelectOrganization = $("#btnOrgSearchPicker_" + objectId + "_" + idfsOrganizationPropertyName);
    var btnClianOrganization = $("#btnOrgClian_" + objectId + "_" + idfsOrganizationPropertyName);
    if (!btnSelectOrganization || !btnClianOrganization) {
        return;
    }
    btnSelectOrganization.attr('disabled', 'disabled');
    btnClianOrganization.attr('disabled', 'disabled');
}

function DisableEmployeePicker(objectId, idfsEmployeePropertyName) {
    var btnSelectEmployee = $("#btnEmpSearchPicker_" + objectId + "_" + idfsEmployeePropertyName);
    var btnClianEmployee = $("#btnEmpClian_" + objectId + "_" + idfsEmployeePropertyName);
    if (!btnSelectEmployee || !btnClianEmployee) {
        return;
    }
    btnSelectEmployee.attr('disabled', 'disabled');
    btnClianEmployee.attr('disabled', 'disabled');
}

(function ($) {
    $.fn.extend({
        center: function (options) {
            var options = $.extend({ // Default values
                inside: window, // element, center into window
                transition: 0, // millisecond, transition time
                minX: 0, // pixel, minimum left element value
                minY: 0, // pixel, minimum top element value
                vertical: true, // booleen, center vertical
                withScrolling: true, // booleen, take care of element inside scrollTop when minX < 0 and window is small or when window is big 
                horizontal: true // booleen, center horizontal
            }, options);
            return this.each(function () {
                var props = { position: 'absolute' };
                if (options.vertical) {
                    var top = ($(options.inside).height() - $(this).outerHeight()) / 2;
                    if (options.withScrolling) top += $(options.inside).scrollTop() || 0;
                    top = (top > options.minY ? top : options.minY);
                    $.extend(props, { top: top + 'px' });
                }
                if (options.horizontal) {
                    var left = ($(options.inside).width() - $(this).outerWidth()) / 2;
                    if (options.withScrolling) left += $(options.inside).scrollLeft() || 0;
                    left = (left > options.minX ? left : options.minX);
                    $.extend(props, { left: left + 'px' });
                }
                if (options.transition > 0) $(this).animate(props, options.transition);
                else $(this).css(props);
                return $(this);
            });
        }
    });
})(jQuery);

function showLoading() {
    if ($("#loading").length == 1) {
        var imgSrc = $("#loadingImg")[0].src;
        $("#loading")[0].innerHTML = '<img id="loadingImg" src="' + imgSrc + '" />';
        $("#loadingImg").center();
        $("#loading").show();
    }
}

function hideLoading() {
    if($("#loading").length == 1){
        $("#loading").hide();
    }
}
