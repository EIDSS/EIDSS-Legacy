var datePickerFacade = (function () {
    function getData(control) {
        var ret = control.data("kendoDatePicker");
        if (ret != null)
            return ret;
        else
            return control.data("kendoDateTimePicker");
    }

    function getDataById(id) {
        var control = $("#" + id);
        var controlData = getData(control);
        return controlData;
    }

    return {
        getValue: function (id) {
            var control = $("#" + id);
            var datePicker = getData(control);
            return datePicker.value();
        },
        
        getControlData: function (id) {
            var datePicker = getDataById(id);
            return datePicker;
        },
        
        setEnabled: function (datePickerData, enabled) {
            datePickerData.enable(enabled);
        },

        setValueById: function (id, val) {
            var datePicker = getDataById(id);
            if (datePicker) {
                datePicker.value(val);
            }
        },
        
        setValue: function (datePickerData, val) {
            if (datePickerData) {
                datePickerData.value(val);
            }
        },
        
        getOnChangedEventArgs: function (e) {
            var element = e.sender.element[0];
            var data = {
                senderId: element.id,
                selectedValue: element.value
            };
            return data;
        },
        
        setRequired: function (id, isRequired) {
            var wrapper = $("#" + id).closest(".k-datepicker");
            if (isRequired) {
                wrapper.addClass("requiredField");
            } else {
                wrapper.removeClass("requiredField");
            }
        },
        
        setVisible: function (id, isVisible) {
            var control = $("#" + id);
            var wrapper = control.closest(".k-datepicker");
            if (isVisible) {
                control.addClass("invisible");
                wrapper.addClass("invisible");
            } else {
                control.removeClass("invisible");
                wrapper.removeClass("invisible");
            }
        },

        getReferenceControlDataByOriginalId: function(id, name) {
            var newId = id.substring(0, id.lastIndexOf("_") + 1) + name;
            var control = getDataById(newId);
            return control;
        },

        setMinMax: function (e, name, val, sel) {
            var args = datePickerFacade.getOnChangedEventArgs(e);
            datePickerFacade.setMinMaxArgs(args, name, val, sel);
        },

        setMinMaxArgs: function (args, name, val, sel) {
            var id = args.senderId;
            if (sel == undefined) {
                sel = args.selectedValue;
            }
            var datePickerData = datePickerFacade.getReferenceControlDataByOriginalId(id, name);
            if (datePickerData) {
                datePickerData.element[0].value = ""; //null;
                var today = new Date();

                var min;
                var max;
                if (val == 'm' && sel == 0) {
                    val = 'y';
                    sel = datePickerData.options.min.getFullYear();
                }
                if (val == 'y') {
                    if (sel == today.getFullYear()) {
                        min = new Date(sel, today.getMonth(), 1);
                        max = new Date(sel, today.getMonth(), today.getDate());
                    }
                    else {
                        min = new Date(sel, 0, 1);
                        max = new Date(sel, 11, 31);
                    }
                }
                else if (val == 'm') {
                    var curr = datePickerData.options.min;
                    min = new Date(curr.getFullYear(), sel - 1, 1);

                    curr = datePickerData.options.max;
                    if (curr.getFullYear() == today.getFullYear() && sel-1 == today.getMonth())
                        max = new Date(curr.getFullYear(), sel - 1, today.getDate());
                    else {
                        max = new Date(curr.getFullYear(), sel, 1);
                        max.setTime(max.getTime() - 1);
                    }
                }

                datePickerData.min(min);
                datePickerData.max(max);
            }
        }
    };

})();

