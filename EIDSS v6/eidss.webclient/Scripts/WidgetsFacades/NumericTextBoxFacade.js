var numericTextBoxFacade = (function () {
    
    function getData(control) {
        return control.data("kendoNumericTextBox"); 
    }
    
    function getDataById(id) {
        var control = $("#" + id);
        var numericTextBox = getData(control);
        return numericTextBox;
    }

    return {
        getValue: function (id) {
            var control = $("#" + id);
            var numerictextbox = getData(control);
            return numerictextbox.value();
        },
        
        getControlData: function (id) {
            var numericTextBox = getDataById(id);
            return numericTextBox;
        },
        
        setEnabled: function (numericTextBoxData, enabled) {
            numericTextBoxData.enable(enabled);
        },
        
        hide: function (numericTextBoxData) {
            numericTextBoxData.wrapper.hide();
        },
        
        show: function (numericTextBoxData) {
            numericTextBoxData.wrapper.show();
        },
        
        setValue: function (numericTextBoxData, val) {
            if (numericTextBoxData) {
                numericTextBoxData.value(val);
            }
        },
        
        setValueById: function (id, val) {
            var numericTextBoxData = getDataById(id);
            if (numericTextBoxData) {
                numericTextBoxData.value(val);
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
    };

})();