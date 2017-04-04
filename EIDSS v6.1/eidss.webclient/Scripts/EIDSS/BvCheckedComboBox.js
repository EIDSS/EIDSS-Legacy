var bvCheckedComboBox = (function () {

    function hideEmptyItemInCheckedComboBox() {
        $("." + comboBoxFacade.itemCheckBoxClassName + "[checkedname='']").hide();
    }



    function clearCheckedComboBox(controlId) {
        var checked = comboBoxFacade.getCheckedCheckBoxes(controlId);
        checked.removeAttr("checked");
        comboBoxFacade.setTextById(controlId, "", true);
        $("#" + controlId).val("");
        //formRefresher.onFieldChanged(controlId, "");
    }

    return {
        onClearCheckedComboBox: function (controlId) {
            clearCheckedComboBox(controlId);
        },
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
            if (args.selectedIndex != 0/* || args.selectedValue == -1*/) {
                e.preventDefault();
            } else {
                //clearCheckedComboBox(controlId); //#13179
                e.preventDefault();
            }
        },
        onCheckedComboBoxClick: function (e, controlId, currentCheckBoxId) {
            comboBoxFacade.cancelCloseOnClick(e);
            var combobox = $("#" + controlId);
            var maxcheckedcount = 0;
            if ((combobox != null)
                    && (combobox.length == 1)
            ) {
                var maxCheckCountAttr = combobox[0].getAttribute("maxcheckedcount");
                if (maxCheckCountAttr != null && maxCheckCountAttr !== '')
                    maxcheckedcount = parseInt(maxCheckCountAttr, 0);
            }

            var chk = $("#" + controlId + "_listbox").find("." + comboBoxFacade.itemCheckBoxClassName + "[id='" + currentCheckBoxId + "']")[0].checked;
            if (currentCheckBoxId == "chb0") { // select all
                var items = $("#" + controlId + "_listbox").find("." + comboBoxFacade.itemCheckBoxClassName + "[id!='" + currentCheckBoxId + "']");
                var count = items.length;
                if (chk==true && maxcheckedcount > 0 && maxcheckedcount < items.length)
                    count = maxcheckedcount;
                for (var i = 0; i < count; i++) {
                    items[i].checked = chk;
                }
                for (var i = count; i < items.length; i++) {
                    items[i].checked = false;
                }

            } else {
                var groupItems = $("#" + controlId + "_listbox").find("." + comboBoxFacade.itemCheckBoxClassName + "[group='" + currentCheckBoxId.substr(3) + "']");
                if (groupItems.length > 0) {
                    for (var i = 0; i < groupItems.length; i++) {
                        groupItems[i].checked = chk;
                    }
                } else {
                    var group = $("#" + controlId + "_listbox").find("." + comboBoxFacade.itemCheckBoxClassName + "[id='" + currentCheckBoxId + "']")[0].getAttribute("group");
                    if (group && !chk) {
                        var groupItem = $("#" + controlId + "_listbox").find("." + comboBoxFacade.itemCheckBoxClassName + "[id='chb" + group + "']");
                        if (groupItem.length == 1) {
                            groupItem[0].checked = false;
                        }
                    }

                    var selAll = $("#" + controlId + "_listbox").find("." + comboBoxFacade.itemCheckBoxClassName + "[id='chb0']");
                    if (selAll && selAll.length == 1 && !chk) {
                        selAll[0].checked = false;
                    }
                }
            }

            var checkedItems = comboBoxFacade.getCheckedItems(controlId);
            if ((maxcheckedcount > 0) && (checkedItems.values.length > maxcheckedcount)) {
                var mess = EIDSS.BvMessages.msgTooCheckedItems;
                var messageId = combobox[0].getAttribute("validationMessage");
                if (messageId != undefined && messageId != '') {
                    mess = eval('EIDSS.BvMessages.' + messageId);
                }
                if (mess != null) {
                    mess = mess.replace('{0}', maxcheckedcount);
                    //clearCheckedComboBox(controlId);
                    if (currentCheckBoxId != null && currentCheckBoxId != "chb0") {
                        var items = $("#" + currentCheckBoxId);
                        if (items.length > 0) {
                            items[0].checked = false;
                        }
                    }
                    bvDialog.showError(mess);
                }
            }
            checkedItems = comboBoxFacade.getCheckedItems(controlId);
            var text = checkedItems.texts.toString();
            comboBoxFacade.setTextById(controlId, text, true);
            $("#" + controlId).val(checkedItems.values.toString());
            formRefresher.onFieldChanged(controlId, checkedItems.values.toString());
        },

        bindCheckedComboBoxClickEvent: function (controlId, selectedIndexes) {
            bvCheckedComboBox.bindCheckedComboBoxClickEventInternal(controlId, selectedIndexes, bvCheckedComboBox.onCheckedComboBoxClick);
        },

        bindCheckedComboBoxClickEventInternal: function (controlId, selectedIndexes, onCheckClickFunction) {
            hideEmptyItemInCheckedComboBox();
            clearCheckedComboBox(controlId);
            $("." + comboBoxFacade.itemCheckBoxClassName).bind("click", { controlId: controlId }, function (event) {
                var e = arguments[0];
                var currentCheckBoxId = null;
                if (e.currentTarget != null) currentCheckBoxId = e.currentTarget.id;
                onCheckClickFunction(e, event.data.controlId, currentCheckBoxId);
            });

            // prevent keyboard actions
            //$("span.k-dropdown")
            $("#" + controlId).parent()
                .off("keydown")
                .on("keydown", function (e) {
                    var keyCode = e.keyCode;
                    //if (keyCode !== kendo.keys.LEFT && keyCode !== kendo.keys.RIGHT) {
                    //    $(this).find('select').data('kendoDropDownList')._keydown(e);
                    //}
                });

            var data = comboBoxFacade.getControlData(controlId, true).dataSource.data();
            var isCheckedDataSource = false;
            if (data.length > 0 && data[0].IsChecked !== undefined) {
                isCheckedDataSource = true;
            }

            if (isCheckedDataSource) {
                selectedIndexes = "";
                for (var i = 0; i < data.length; i++) {
                    if (data[i].IsChecked) {
                        if (selectedIndexes.length > 0) {
                            selectedIndexes = selectedIndexes + ",";
                        }
                        selectedIndexes = selectedIndexes + data[i].Value;
                    }
                }
            }
            bvCheckedComboBox.setCheckedCheckBox(controlId, selectedIndexes);
        },

        setCheckedCheckBox: function (id, indexes, checked) {
            var arr = indexes.split(',');
            for (var i = 0; i < arr.length; i++) {
                if (arr[i].length > 0) {
                    var items = $("#chb" + arr[i]);
                    if (items.length > 0) {
                        var item = items[0];
                        if (checked != null)
                            item.checked = checked;
                        else
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