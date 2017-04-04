var comboBoxFacade = (function () {
    function getData(control, isDropDown) {
        if (isDropDown) {
            return control.data("kendoDropDownList");
        }
        return control.data("kendoComboBox");
    }
    
    function getDataById(id, isDropDown) {
        var control = $("#" + id);
        var comboBox = getData(control, isDropDown);
        return comboBox;
    }
    
    return {
        itemCheckBoxClassName: "check-item",

        getValueById: function (id, isDropDown) {
            var comboBox = getDataById(id, isDropDown);
            return comboBox.value();
        },

        getControlData: function (id, isDropDown) {
            var comboBox = getDataById(id, isDropDown);
            return comboBox;
        },

        getReferenceControlDataByOriginalId: function(id, name, isDropDown) {
            var newId = id.substring(0, id.lastIndexOf("_") + 1) + name;
            var comboBox = getDataById(newId, isDropDown);
            return comboBox;
        },

        getIdByE: function(e) {
            var id = e.sender.element[0].id;
            return id;
        },

        getOnChangedEventArgs: function (e, $this, isDropDown) {
            var element = e.sender.element[0];
            var previousValue = element.value ? element.value : "0";
            var item = e.item;
            var senderId = element.id;
            var selectedIndex;
            var selectedValue;
            var selectedText;
            if (item) {
                selectedIndex = item.index();
            }
            if ($this && item) {
                var dataItem = $this.dataItem(item.index());
                selectedValue = dataItem.Value;
                selectedText = dataItem.Text;
            } else {
                selectedValue = comboBoxFacade.getValueById(senderId, isDropDown);
            }
            var data = {
                senderId: senderId,
                previousValue: previousValue,
                selectedIndex: selectedIndex,
                selectedValue: selectedValue,
                selectedText: selectedText,
                preventDefaultFunc: e.preventDefault
            };
            return data;
        },

        getOnBoundEventArgs: function(e) {
            var element = e.sender.element[0];
            var data = {
                senderId: element.id,
                selectedValue: element.value,
                selectedText: element.innerHTML
            };
            return data;
        },

        getValueByControlData: function(comboBox) {
            return comboBox.value();
        },

        setValueById: function(id, val, isDropDown) {
            var comboBox = getDataById(id, isDropDown);
            if (comboBox) {
                comboBox.value(val);
            }
        },

        setTextById: function(id, text, isDropDown) {
            var comboBox = getDataById(id, isDropDown);
            if (comboBox != null) comboBox.text(text);
        },

        reloadReferenceComboBox: function(e, name) {
            var comboBox = comboBoxFacade.getReferenceControlDataByOriginalId(comboBoxFacade.getIdByE(e), name);
            if (comboBox) {
                comboBox.value(null);
                comboBox.dataSource.read();
            }
        },

        reloadReferenceComboBoxWithoutClearValue: function (e, name) {
            var comboBox = comboBoxFacade.getReferenceControlDataByOriginalId(comboBoxFacade.getIdByE(e), name);
            if (comboBox) {
                comboBox.dataSource.read();
            }
        },

        reloadReferenceDropDown: function (e, name) {
            var comboBox = comboBoxFacade.getReferenceControlDataByOriginalId(comboBoxFacade.getIdByE(e), name, true);
            if (comboBox) {
                comboBox.value(null);
                comboBox.dataSource.read();
            }
        },

        reloadReferenceComboBox2: function (id, name) {
            var comboBox = comboBoxFacade.getReferenceControlDataByOriginalId(id, name);
            if (comboBox) {
                comboBox.value(null);
                comboBox.dataSource.read();
            }
        },

        reloadReferenceComboBox2WithoutClearValue: function (id, name) {
            var comboBox = comboBoxFacade.getReferenceControlDataByOriginalId(id, name);
            if (comboBox) {
                comboBox.dataSource.read();
            }
        },

        reloadReferenceDropDown2WithoutClearValue: function (id, name) {
            var comboBox = comboBoxFacade.getReferenceControlDataByOriginalId(id, name, true);
            if (comboBox) {
                comboBox.dataSource.read();
            }
        },

        reloadComboBox: function (name) {
            var comboBox = comboBoxFacade.getControlData(name);
            comboBox.dataSource.read();
        },

        cancelCloseOnClick: function(e) {
            e.stopImmediatePropagation();
        },


        getCheckedCheckBoxes: function(id) {
            var itemsListId = id + "-list";
            var items = $("#" + itemsListId + " ." + comboBoxFacade.itemCheckBoxClassName + ":checked");
            return items;
        },

        getCheckedItems: function(id) {
            var texts = [];
            var values = [];
            var items = comboBoxFacade.getCheckedCheckBoxes(id);
            items.each(function () {
                if ($(this).val() != 0) {
                    if (!$(this).parent().hasClass('clsGroup')) {
                        texts.push($(this).next().text());
                        values.push($(this).val());
                    }
                }
            });
            return { texts: texts, values: values };
        },

        cancelSelection: function (id, previousValue) {
            setTimeout(function() {
                comboBoxFacade.setValueById(id, previousValue);
            }, 500);
        },
        
        hide: function (comboBoxData) {
            comboBoxData.wrapper.hide();
        },

        show: function (comboBoxData) {
            comboBoxData.wrapper.show();
        },
        
        addClass: function (comboBoxData, className) {
            comboBoxData.wrapper.addClass(className);
            comboBoxData.wrapper.find(".k-input").addClass(className);
        },
        
        removeClass: function (comboBoxData, className) {
            comboBoxData.wrapper.removeClass(className);
            comboBoxData.wrapper.find(".k-input").removeClass(className);
        }
    };
})();