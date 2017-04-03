var bvCheckedComboBox = (function () {

    function hideEmptyItemInCheckedComboBox() {
        $("." + comboBoxFacade.itemCheckBoxClassName + "[checkedname='']").hide();
    }

    function onCheckedComboBoxClick(e, controlId) {
        comboBoxFacade.canselCloseOnClick(e);
        var checkedItems = comboBoxFacade.getCheckedItems(controlId);
        var combobox = $("#" + controlId);
        if ((combobox != null) 
            && (combobox.length == 1) 
            ) {
            for (var i = 0; i < combobox[0].attributes.length; i++) {
                if (combobox[0].attributes[i].name == 'maxcheckedcount') {
                    var maxcheckedcount = combobox[0].attributes.getNamedItem('maxcheckedcount').value;
                    if (maxcheckedcount == null) maxcheckedcount = 0;
                    if ((maxcheckedcount > 0) && (checkedItems.values.length > maxcheckedcount)) {
                        var mess = EIDSS.BvMessages.msgTooManyDiagnosis;
                        if (mess != null) {
                            mess = mess.replace('0', maxcheckedcount);
                            bvDialog.showError(mess);
                        }
                    }
                    break;
                }
            }
        }
        var text = checkedItems.texts.toString();
        comboBoxFacade.setTextById(controlId, text, true);
        $("#" + controlId).val(checkedItems.values.toString());
        formRefresher.onFieldChanged(controlId, checkedItems.values.toString());
    }

    function clearCheckedComboBox(controlId) {
        var checked = comboBoxFacade.getCheckedCheckBoxes(controlId);
        checked.removeAttr("checked");
        comboBoxFacade.setTextById(controlId, "", true);
        $("#" + controlId).val("");
        //formRefresher.onFieldChanged(controlId, "");
    }

    return {
        onComboBoxOpen: function (e, width, isDropDown) {
            if (width > 0) {
                var element = e.sender.element[0];
                var id = element.id;
                var combobox = comboBoxFacade.getControlData(id, isDropDown);
                if (combobox.list.width() < width)
                    combobox.list.width(width);
            }
        },
        onCheckedComboBoxChanged: function (e) {
            var args = comboBoxFacade.getOnChangedEventArgs(e, this);
            var controlId = args.senderId;
            if (args.selectedIndex != 0) {
                e.preventDefault();
            } else {
                clearCheckedComboBox(controlId);
            }
        },

        bindCheckedComboBoxClickEvent: function (controlId, selectedIndexes) {
            hideEmptyItemInCheckedComboBox();
            clearCheckedComboBox(controlId);
            $("." + comboBoxFacade.itemCheckBoxClassName).bind("click", { controlId: controlId }, function (event) {
                var e = arguments[0];
                onCheckedComboBoxClick(e, event.data.controlId);
            });

            bvCheckedComboBox.setCheckedCheckBox(controlId, selectedIndexes);
        },
        
        setCheckedCheckBox: function (id, indexes) {
            var arr = indexes.split(',');
            for (var i = 0; i < arr.length; i++) {
                if (arr[i].length > 0) {
                    var items = $("#chb" + arr[i]);
                    if (items.length > 0) {
                        var item = items[0];
                        item.checked = true;
                    }
                }
            }

            var checkedItems = comboBoxFacade.getCheckedItems(id);
            var text = checkedItems.texts.toString();
            comboBoxFacade.setTextById(id, text, true);
            $("#" + id).val(checkedItems.values.toString());
        },

    };
})();