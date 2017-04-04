/*var testModule = (function () {
  var counter = 0;
  return {
    incrementCounter: function () {
      return counter++;
    },

    resetCounter: function () {
      console.log( "counter value prior to reset: " + counter );
      counter = 0;
    }
  };
})();*/


var formRefresher = (function () {
    var paths = {
        setValue: "/System/SetValue",
        setValueWithIgnore: "/System/SetValueWithIgnore"
    };

    var onChangeSuccessParams = "";

    var onChangedSuccess = function () {
    };

    var doChangedSuccessAfterUpdate = false;

    function showAskMessage(itemData, buttonCallback, yesFunction) {
        var messageText = itemData.value;
        var oldKey = itemData.propertyName;
        var oldVal = itemData.controlName;
        bvDialog.showYesNo(bvDialog.title.warning, messageText, function () {
            if (yesFunction) {
                yesFunction();
            } else {
                var url = bvUrls.getByPath(paths.setValueWithIgnore);
                $.ajax({
                    url: url,
                    cache: false,
                    async: false,
                    dataType: "json",
                    type: "POST",
                    data: {
                        key: oldKey,
                        value: oldVal,
                        ignoreErr: 1
                    },
                    success: function (data) {
                        formRefresher.updateControls(data, buttonCallback);
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        bvDialog.showAuthenticationError(jqXHR, textStatus, errorThrown);
                    }
                });
            }
        });
    }

    function showWarningMessage(itemData, buttonCallback) {
        var messageText = itemData.value;
        var oldKey = itemData.propertyName;
        var oldVal = itemData.controlName;
        bvDialog.showWarning(messageText, function () {
            var url = bvUrls.getByPath(paths.setValueWithIgnore);
            $.ajax({
                url: url,
                cache: false,
                async: false,
                dataType: "json",
                type: "POST",
                data: {
                    key: oldKey,
                    value: oldVal,
                    ignoreErr: 1
                },
                success: function (data) {
                    formRefresher.updateControls(data, buttonCallback);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    bvDialog.showAuthenticationError(jqXHR, textStatus, errorThrown);
                }
            });
        });
    }


    function showAskUrlMessage(itemData, buttonCallback) {
        var messageText = itemData.value;
        var urlData = itemData.controlName;
        bvDialog.showYesNo(bvDialog.title.warning, messageText, function () {
            var url = bvUrls.getByPath(urlData);
            $.ajax({
                url: url,
                cache: false,
                async: false,
                dataType: "json",
                type: "POST",
                success: function (data) {
                    formRefresher.updateControls(data, buttonCallback);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    bvDialog.showAuthenticationError(jqXHR, textStatus, errorThrown);
                }
            });
        });
    }

    function showWarningUrlMessage(itemData, buttonCallback) {
        var messageText = itemData.value;
        var urlData = itemData.controlName;
        bvDialog.showWarning(messageText, function () {
            var url = bvUrls.getByPath(urlData);
            $.ajax({
                url: url,
                cache: false,
                async: false,
                dataType: "json",
                type: "POST",
                success: function (data) {
                    formRefresher.updateControls(data, buttonCallback);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    bvDialog.showAuthenticationError(jqXHR, textStatus, errorThrown);
                }
            });
        });
    }


    function showPostAskMessage(text) {
        bvDialog.showYesNo(bvDialog.title.warning, text, function () {
            detailPage.submitWithoutValidation(function (data) {
                formRefresher.updateControls(data);
                formRefresher.doOnChangedSuccess(data);
            });
        }, function () {
        });
    }

    function showPostWarningMessage(text) {
        bvDialog.showWarning(text, function () {
            detailPage.submitWithoutValidation(function (data) {
                formRefresher.updateControls(data);
                formRefresher.doOnChangedSuccess(data);
            });
        }, function () {
        });
    }

    function updatePanel(itemData) {
        var panel = $("#" + itemData.propertyName);
        if (panel.length == 0) {
            return;
        }

        if (itemData.invisible) {
            panel.addClass("invisible");
        } else {
            panel.removeClass("invisible");
        }
    }

    function updateButton(itemData) {
        var button = $("#" + itemData.propertyName);
        if (itemData.readOnly) {
            button.attr('disabled', 'disabled');
            button.addClass("k-state-disabled");
        } else {
            var role = button.data("role");
            if (role == "grid-on-row-button") {
                var gridName = button.data("grid-name");
                var selectedId = bvGrid.getSelectedItemId(gridName);
                if (selectedId) {
                    button.removeAttr("disabled");
                    button.removeClass("k-state-disabled");
                } else {
                    button.attr('disabled', 'disabled');
                    button.addClass("k-state-disabled");
                }
            } else {
                button.removeAttr("disabled");
                button.removeClass("k-state-disabled");
            }
        }
    }

    function updateEditBox(itemData) {
        var editBox = $("#" + itemData.controlName);
        if (editBox.length == 0) {
            return;
        }

        editBox.val(itemData.value);
        if (itemData.readOnly) {
            editBox.attr("readonly", "readonly");
            editBox.addClass("readonlyField");
        } else {
            editBox.removeAttr("readonly");
            editBox.removeClass("readonlyField");
        }
        if (itemData.mandatory) {
            editBox.addClass("requiredField");
            if (editBox.parent("span.tdContainer").parent("span.pickerWrap").length > 0) {
                editBox.parent("span.tdContainer").parent("span.pickerWrap").addClass("requiredField");
            }
        } else {
            editBox.removeClass("requiredField");
            if (editBox.parent("span.tdContainer").parent("span.pickerWrap").length > 0) {
                editBox.parent("span.tdContainer").parent("span.pickerWrap").removeClass("requiredField");
            }
        }
        var controlName = itemData.controlName;
        var objectIdent = controlName; //controlName.substring(controlName.lastIndexOf("_") + 1);
        var label = $("label[for=" + objectIdent + "]");
        if (itemData.invisible) {
            editBox.addClass("invisible");
            label.addClass("invisible");
        } else {
            editBox.removeClass("invisible");
            label.removeClass("invisible");
        }
    }

    function updateDatePicker(itemData) {
        var datePicker = $("#" + itemData.controlName);
        if (datePicker.length == 0) {
            return;
        }

        var datePickerData = datePickerFacade.getControlData(itemData.controlName);
        if (!datePickerData) {
            updateEditBox(itemData);
            return;
        }

        datePickerFacade.setRequired(itemData.controlName, itemData.mandatory);
        datePickerFacade.setEnabled(datePickerData, !itemData.readOnly);
        datePickerFacade.setVisible(itemData.controlName, itemData.invisible);
        
        var controlName = itemData.controlName;
        var objectIdent = controlName; //controlName.substring(controlName.lastIndexOf("_") + 1);
        var label = $("label[for=" + objectIdent + "]");
        if (itemData.invisible) {
            label.addClass("invisible");
        } else {
            label.removeClass("invisible");
        }
        datePickerFacade.setValue(datePickerData, itemData.value);
    }

    function updateNumeric(itemData) {
        var control = $("#" + itemData.controlName);
        if (control.length == 0) {
            return;
        }

        var controlName = itemData.controlName;
        var objectIdent = controlName; //controlName.substring(controlName.lastIndexOf("_") + 1);
        var label = $("label[for=" + objectIdent + "]");
        var numericData = numericTextBoxFacade.getControlData(controlName);
        if (itemData.invisible) {
            label.addClass("invisible");
            if (numericData) {
                numericTextBoxFacade.hide(numericData);
            } else {
                control.addClass("invisible");
            }
        } else {
            label.removeClass("invisible");
            if (numericData) {
                numericTextBoxFacade.show(numericData);
            } else {
                control.removeClass("invisible");
            }
        }
        if (itemData.mandatory) {
            control.addClass("requiredField");
        } else {
            control.removeClass("requiredField");
        }
        if (numericData) {
            numericTextBoxFacade.setEnabled(numericData, !itemData.readOnly);
            numericTextBoxFacade.setValue(numericData, itemData.value);
            
            var buttonIdent = controlName.substring(0, controlName.lastIndexOf("_") + 1);
            var button = $("#" + buttonIdent);
            if (button.length > 0) {
                itemData.propertyName = buttonIdent;
                updateButton(itemData);
            }

        } else {
            control.val(itemData.value);
        }
    }

    function updateComboBox(comboBoxData, itemData) {
        if (!comboBoxData) {
            return;
        }

        var controlName = itemData.controlName;
        var control = $("#" + controlName);

        if (itemData.mandatory) {
            control.addClass("requiredField");
            comboBoxFacade.addClass(comboBoxData, "requiredField");
        } else {
            control.removeClass("requiredField");
            comboBoxFacade.removeClass(comboBoxData, "requiredField");
        }

        comboBoxData.enable(!itemData.readOnly);

        var val = itemData.value;
        if (val == "0") {
            val = "";
        }

        var objectId = controlName; //controlName.substring(controlName.lastIndexOf("_") + 1);
        var label = $("label[for=" + objectId + "]");
        if (itemData.invisible) {
            label.addClass("invisible");
            control.addClass("invisible");
            control.parent().addClass("invisible");
            comboBoxFacade.hide(comboBoxData);
        } else {
            label.removeClass("invisible");
            control.removeClass("invisible");
            control.parent().removeClass("invisible");
            comboBoxFacade.show(comboBoxData);
        }
        
        if (itemData.items) {
            comboBoxData.dataSource.data(itemData.items);
            //var comboBox = comboBoxFacade.getControlData(controlName);
            //if (comboBox) {
            //    comboBox.value(null);
            //    comboBox.dataSource.data(itemData.items);
            //}
        }

        comboBoxData.value(val);
    }

    function updateRadioButtons(itemData) {
        var buttons = $("[name=" + itemData.controlName + "]");
        if (buttons.length > 0) {
            buttons.filter("[value=" + itemData.value + "]").attr("checked", true);
            $.each(buttons, function (x, y) {
                $(y).attr('disabled', itemData.readOnly);
            });
        }
    }

    function updateLookup(itemData) {
        var comboBoxData = comboBoxFacade.getControlData(itemData.controlName);
        if (comboBoxData) {
            updateComboBox(comboBoxData, itemData);
        } else {
            updateRadioButtons(itemData);
        }
    }

    function updateDropdown(itemData) {
        var dropDownData = comboBoxFacade.getControlData(itemData.controlName, true);
        if (dropDownData) {
            updateComboBox(dropDownData, itemData);
        } 
    }

    function updateCheckBox(itemData) {
        var control = $("#" + itemData.controlName);
        if (control.length == 0) {
            return;
        }

        if (itemData.readOnly) {
            control.attr("disabled", "disabled");
        } else {
            control.removeAttr("disabled");
        }

        if (control[0].type == "hidden") {
            if (itemData.value.toLowerCase() == "true") {
                control[0].value = "true";
            } else {
                control[0].value = "false";
            }
        } else {
            if (itemData.value.toLowerCase() == "true") {
                control[0].value = "true";
                control[0].checked = true;
            } else {
                control[0].value = "false";
                control[0].checked = false;
            }
        }
    }

    function scrollToRow(itemData) {
        bvGrid.scrollToRowByID("Grid", itemData.value);
    }

    function updateString(itemData) {
        if (itemData.controlName.indexOf("button") >= 0) {
            updateButton(itemData);
            return;
        }
        if (itemData.controlName.indexOf("panel") >= 0) {
            updatePanel(itemData);
            return;
        }
        updateEditBox(itemData);
    }

    function updateNumber(itemData, typeName) {
        updateNumeric(itemData);
        if (typeName == "Int64?" || typeName == "Int64") {
            updateInlineItemPickers(itemData);
        }
    }

    function updateInlineItemPickers(itemData) {
        var arr = itemData.controlName.split('_');
        var objectId = arr[1];
        if (itemData.readOnly) {
            disableInlineItemPickers(objectId, itemData.propertyName);
        } else {
            enableInlineItemPickers(objectId, itemData.propertyName, itemData.value);
        }
        if (itemData.invisible) {
            hideInlineItemPickers(objectId, itemData.propertyName, itemData.controlName);
        } else {
            showInlineItemPickers(objectId, itemData.propertyName, itemData.controlName);
        }
    }

    function disableInlineItemPickers(objectId, propertyName) {
        if (typeof organization != "undefined" && organization) {
            organization.disableInlinePicker(objectId, propertyName);
        }
        if (typeof employee != "undefined" && employee) {
            employee.disableInlinePicker(objectId, propertyName);
        }
        if (typeof outbreak != "undefined" && outbreak) {
            outbreak.disableInlinePicker(objectId, propertyName);
        }
        if (typeof asCampaign != "undefined" && asCampaign) {
            asCampaign.disableInlinePicker(objectId, propertyName);
        }
    }

    function enableInlineItemPickers(objectId, propertyName, value) {
        if (typeof organization != "undefined" && organization) {
            organization.enableInlinePicker(objectId, propertyName, value);
        }
        if (typeof employee != "undefined" && employee) {
            employee.enableInlinePicker(objectId, propertyName, value);
        }
        if (typeof outbreak != "undefined" && outbreak) {
            outbreak.enableInlinePicker(objectId, propertyName, value);
        }
        if (typeof asCampaign != "undefined" && asCampaign) {
            asCampaign.enableInlinePicker(objectId, propertyName, value);
        }
    }
    
    function showInlineItemPickers(objectId, propertyName, controlName) {
        if (typeof organization != "undefined" && organization) {
            organization.showInlinePicker(objectId, propertyName, controlName);
        }
        if (typeof employee != "undefined" && employee) {
            employee.showInlinePicker(objectId, propertyName, controlName);
        }
    }

    function hideInlineItemPickers(objectId, propertyName, controlName) {
        if (typeof organization != "undefined" && organization) {
            organization.hideInlinePicker(objectId, propertyName, controlName);
        }
        if (typeof employee != "undefined" && employee) {
            employee.hideInlinePicker(objectId, propertyName, controlName);
        }
    }

    function updateGrid(itemData) {
        //controlName	"AsSession_52013120000000_ASFarmsAll"	String
        var arr = itemData.controlName.split('_');
        if (arr[0] == "AsSession" && arr[2] == "ASFarmsAll") {
            var name1 = arr[0] + "_" + arr[1] + "_" + "ASFarmsDetails";
            var name2 = arr[0] + "_" + arr[1] + "_" + "ASFarmsSummary";
            itemData.controlName = name1;
            updateGrid(itemData);
            itemData.controlName = name2;
            updateGrid(itemData);
            return;
        }
        if (arr[0] == "Farm" && arr[2] == "FarmTree") {
            var list = $("[id*='SpeciesList_']");
            for (var i = 0; i < list.length; i++) {
                itemData.controlName = list[i].id;
                updateGrid(itemData);
            }
            itemData.propertyName = "btnAddHerd";
            updateButton(itemData);
            return;
        }


        if (itemData.readOnly) {
            bvGrid.disable(itemData.controlName);
        } else {
            bvGrid.enable(itemData.controlName);
        }
        bvGrid.reloadById(itemData.controlName); 
    }

    function emptyFunction() {
    }

    function showErrorMessage(text, buttonCallback) {
        bvDialog.showError(text, buttonCallback);
    }

    return {
        setOnChangedSuccess: function (onChangedSuccessFunc, onChangeSuccessFuncParams) {
            onChangedSuccess = onChangedSuccessFunc;
            onChangeSuccessParams = onChangeSuccessFuncParams;
            doChangedSuccessAfterUpdate = false;
        },

        setOnChangedSuccessAfterUpdate: function (onChangedSuccessFunc, onChangeSuccessFuncParams) {
            onChangedSuccess = onChangedSuccessFunc;
            onChangeSuccessParams = onChangeSuccessFuncParams;
            doChangedSuccessAfterUpdate = true;
        },

        doOnChangedSuccess: function (data) {
            onChangedSuccess(onChangeSuccessParams, data);
            formRefresher.setOnChangedSuccess(function () {
            }, "");
        },

        updateControls: function (dataForReload, buttonCallback, yesFunction) {
            for (var item in dataForReload.Values) {
                var itemData = dataForReload.Values[item];
                var typeName = itemData.typeName;

                switch (typeName) {
                    case "string":
                    case "String":
                        updateString(itemData);
                        break;
                    case "DateTime":
                    case "DateTime?":
                        updateDatePicker(itemData);
                        break;
                    case "int":
                    case "int?":
                    case "Int32":
                    case "Int32?":
                    case "Int64":
                    case "Int64?":
                    case "long":
                    case "long?":
                    case "double":
                    case "double?":
                    case "Double":
                    case "Double?":
                        updateNumber(itemData, typeName);
                        break;
                    case "Lookup":
                        updateLookup(itemData);
                        break;
                    case "Child":
                        updateDropdown(itemData);
                        updateGrid(itemData);
                        break;
                    case "Boolean?":
                    case "Boolean":
                    case "bool?":
                    case "bool":
                        updateCheckBox(itemData);
                        break;
                    case "ErrorMessage":
                        showErrorMessage(itemData.value, buttonCallback);
                        break;
                    case "WarningMessage":
                        showWarningMessage(itemData, buttonCallback);
                        break;
                    case "WarningUrlMessage":
                        showWarningUrlMessage(itemData, buttonCallback);
                        break;
                    case "WarningPostMessage":
                        showPostWarningMessage(itemData.value);
                        break;
                    case "AskMessage":
                        showAskMessage(itemData, buttonCallback, yesFunction);
                        break;
                    case "AskUrlMessage":
                        showAskUrlMessage(itemData, buttonCallback);
                        break;
                    case "AskPostMessage":
                        showPostAskMessage(itemData.value);
                        break;
                    case "ScrollToRow":
                        scrollToRow(itemData);
                        break;
                }
            }
        },

        hasError: function (data) {
            var result = false;
            if (data && data.Values) {
                $.each(data.Values, function (x, y) {
                    if (y.typeName == "ErrorMessage") {
                        result = true;
                        return;
                    }
                });
            }
            return result;
        },

        hasMessage: function (data) {
            var result = false;
            if (data && data.Values) {
                $.each(data.Values, function (x, y) {
                    if (y.typeName == "ErrorMessage" ||
                        y.typeName == "AskMessage" || y.typeName == "AskUrlMessage" || y.typeName == "AskPostMessage" ||
                        y.typeName == "WarningMessage" || y.typeName == "WarningUrlMessage" || y.typeName == "WarningPostMessage"
                        ) {
                        result = true;
                        return;
                    }
                });
            }
            return result;
        },

        onFieldChanged: function (key, value, async, showWait) {
            if (async == undefined) {
                async = true;
            }
            if (showWait == undefined) {
                showWait = false;
            }

            value = EscapeHtml(value);
            if (showWait) {
                showLoading();
            }

            $.ajax({
                url: bvUrls.getSystemSetValueUrl(),
                dataType: "json",
                type: "POST",
                async: async,
                data: {
                    key: key,
                    value: value
                },
                success: function (data) {
                    if (showWait) {
                        hideLoading();
                    }
                    if (!doChangedSuccessAfterUpdate)
                        formRefresher.doOnChangedSuccess(data);
                    formRefresher.updateControls(data);
                    if (doChangedSuccessAfterUpdate)
                        formRefresher.doOnChangedSuccess(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    if (showWait) {
                        hideLoading();
                    }
                    bvDialog.showAuthenticationError(jqXHR, textStatus, errorThrown);
                }
            });
        },

        onDateChanged: function (e) {
            var args = datePickerFacade.getOnChangedEventArgs(e);
            var dateStr = globalizationFacade.toFormatString("{0:dd-MM-yyyy}", /*e.sender._value*/ args.selectedValue);
            formRefresher.onFieldChanged(args.senderId, dateStr);
        },

        onDateTimeChanged: function (e) {
            var args = datePickerFacade.getOnChangedEventArgs(e);
            var dateStr = globalizationFacade.toFormatString("{0:dd-MM-yyyyTHH:mm:ss}", args.selectedValue);
            formRefresher.onFieldChanged(args.senderId, dateStr);
        },

        onNumericChanged: function (e) {
            var args = numericTextBoxFacade.getOnChangedEventArgs(e);
            formRefresher.onFieldChanged(args.senderId, args.selectedValue);
        },

        onTextBoxChanged: function (textBoxName) {
            var textBoxValue = $("#" + textBoxName).val();
            formRefresher.onFieldChanged(textBoxName, textBoxValue);
        },
        
        /*onComboBoxChanged: function (e) {
            var args = comboBoxFacade.getOnChangedEventArgs(e);
            formRefresher.onFieldChanged(args.senderId, args.selectedValue);
        },*/

        onCheckBoxChanged: function (checkBoxName, async, showWait) {
            var checkBoxValue = "false";
            var checkBox = $("#" + checkBoxName)[0];
            if (checkBox.checked) {
                checkBox.value = "true";
                checkBoxValue = "true";
            } else {
                checkBox.value = "false";
            }
            formRefresher.onFieldChanged(checkBoxName, checkBoxValue, async, showWait);
        }
    };
})();