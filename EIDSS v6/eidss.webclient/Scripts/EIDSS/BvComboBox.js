var bvComboBox = (function () {
    var freeInputIdPart = ['street', 'postcode'];

    function isFreeInput(cbId) {
        for (var i = 0; i < freeInputIdPart.length; i++) {
            if (cbId.toLowerCase().indexOf(freeInputIdPart[i]) != -1) {
                return true;
            }
        }
        return false;
    }

    function getById(cbId) {
        return $('#' + cbId).data('kendoComboBox');
    }

    function getTextValueById(cbId) {
        return $("[name='" + cbId + "_input']").val();
    }

    function isTextValueExists(comboBox, text) {
        var data = comboBox.dataSource.options.data;
        if (!data || text === undefined) {
            return false;
        }

        //return true; // TODO 
        var count = data.length;
        for (var j = 0; j < count; j++) {
            var item = data[j].Text;
            if (item == text) {
                return true;
            }
        }
        return false;
    }

    function getValueById(cbId) {
        return $('#' + cbId).data('kendoComboBox').value();
    }

    var bSkip = false;

    return {
        onDataBoundAnimalAge: function (e) {
            if (!bSkip) {
                bSkip = true;
                var idfsSpeciesType = $("#AnimalAge").parent().parent().parent().find("input[name='idfsSpeciesType']").val();
                var d = e.sender.dataSource.data();
                for (var i = d.length - 1; i > 0; i--) {
                    if (d[i].idfsSpeciesType != idfsSpeciesType) {
                        d.splice(i, 1);
                    }
                }
                e.sender.dataSource.data(d);
                bSkip = false;
            }
        },

        onDataBound: function (e) {
            var list = $(e.sender.list).find("li");
            for (var i = 0; i < e.sender.dataSource._view.length; i++) {
                var val = e.sender.dataSource._view[i].Value;
                if (val == undefined)
                    val = e.sender.dataSource._view[i].id;
                $(list[i]).attr("bvid", val);
            }

        },


        onOpen: function (e, width) {
            if (width > 0) {
                var args = comboBoxFacade.getOnChangedEventArgs(e, this);
                var id = args.senderId;
                var combobox = comboBoxFacade.getControlData(id);
                if (combobox.list.width() < width)
                    combobox.list.width(width);
            }
        },

        onChanged: function (e) {
            var args = comboBoxFacade.getOnChangedEventArgs(e, this);
            var id = args.senderId;
            if (args.selectedValue) {
                bvComboBox.cleanTextIfValueNotExists(id);
            }
            var val = args.selectedValue ? args.selectedValue : comboBoxFacade.getValueById(id);
            formRefresher.onFieldChanged(id, val);
        },

        onTextChanged: function (e) {
            var args = comboBoxFacade.getOnChangedEventArgs(e, this);
            var id = args.senderId;
            if (args.selectedValue) {
                bvComboBox.cleanTextIfValueNotExists(id);
            }
            var val = args.selectedValue ? args.selectedValue : comboBoxFacade.getValueById(id);
            formRefresher.onFieldChanged(id, val);
        },

        applyChanges: function (e) {
            formRefresher.onFieldChanged(e.target.id, e.value);
        },

        getValueById: function (id) {
            return getValueById(id);
        },

        cleanTextIfValueNotExists: function (id) {
            if (isFreeInput(id)) {
                return;
            }
            var cbox = getById(id);
            if (cbox.value() == '') {
                return;
            }

            var text = getTextValueById(id);
            var isTextExists = isTextValueExists(cbox, text);
            if (!isTextExists) {
                cbox.value("");
            }
        },

        onLoad: function (e) {
            // TODO use comboBoxFacade
            var combo = getById(e.target.id);
            combo.reload();
        },

        onFFChanged: function (e) {
            // TODO use comboBoxFacade
            if (e.value) {
                bvComboBox.cleanTextIfValueNotExists(e.target.id);
            }
        },

        setValue: function (id, val) {
            // TODO use comboBoxFacade
            var cbox = getById(id);
            cbox.value(val);
        }
    };
})();