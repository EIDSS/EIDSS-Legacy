var columnPopup = (function() {
    return {
        onDeleteCopy: function() {
            $.ajax({
                url: "OnDeleteFieldCopy",
                dataType: 'json',
                type: 'POST',
                success: function(data) {
                    if (data.result == 'ask') {
                        confForm.OnHyperLinkClick(data.messageText, data.yesFunction, data.noFunction, 'false');
                    } else {
                        pcColumn.Hide();
                    }
                }
            });
        },
        deleteCopy: function() {
            $.ajax({
                url: "DeleteFieldCopy",
                dataType: 'json',
                type: 'POST',
                success: function(data) {
                    cbFieldsList.PerformCallback();
                    pivotGrid.PerformCallback();
                    pcColumn.PerformCallback();
                    pcColumn.Hide();
                }
            });
        },
        onCancelChanges: function() {
            $.ajax({
                url: "OnCancelFieldChanges",
                dataType: 'json',
                type: 'POST',
                success: function(data) {
                    pcColumn.PerformCallback();
                    pcColumn.Hide();
                    if (data != "") {
                        document.location.href = data.function;
                    }
                }
            });
        },
        adjustDate: function(value){
            /*if (value.getFullYear() > 2500) {
                value.setFullYear(value.getFullYear() - 543);
            }*/
            return value;
        },
        onSaveChanges: function() {
            $.ajax({
                url: "OnSaveFieldChanges",
                dataType: 'json',
                type: 'POST',
                data: {
                    caption: (typeof txtColumnName == "undefined") ? "" : txtColumnName.GetValue(),
                    captionEn: (typeof txtNewColumnNameEn == "undefined") ? "" : txtNewColumnNameEn.GetValue(),
                    aggregateFunctionId: cbAggregateFunction.GetValue() != null? cbAggregateFunction.GetValue() : null,
                    precision: txtPrecision.GetValue(),
                    basicCountFunctionId: cbBasicCountFunction.GetValue() != null ? cbBasicCountFunction.GetValue() : null,
                    adminUnitField: cbAdministrativeUnitField.GetValue(),
                    dateField: cbGroupDateField.GetValue(),
                    groupInterval: (typeof cbPrivateGroupDate == "undefined" || cbPrivateGroupDate.GetValue == null) ? null : cbPrivateGroupDate.GetValue(),
                    addMissedValue: (chkAddMissedValue.GetValue != null) ? chkAddMissedValue.GetValue() : false,
                    startDate: (typeof dtDiapasonStartDate != "undefined" && dtDiapasonStartDate.GetValue() != null) ? columnPopup.adjustDate(dtDiapasonStartDate.GetValue()).toJSON() : '',
                    endDate: (typeof dtDiapasonEndDate != "undefined" && dtDiapasonEndDate.GetValue() != null) ? columnPopup.adjustDate(dtDiapasonEndDate.GetValue()).toJSON() : '',
                },
                success: function(data) {
                    if (data.result == 'error') {
                        $('#idError').attr('style', 'display:block');
                        $('#idErrorText').html(data.error);
                    } else {
                        $('#idError').attr('style', 'display:none');
                        $('#idErrorText').text('');
                        pcColumn.Hide();
                        cbFieldsList.PerformCallback();
                        pivotGrid.PerformCallback();
                        if (data.result == 'refresh') {
                            document.location.href = data.function;
                        }
                    }
                }
            });
        },
        onSettingsClick: function(selectedItem) {
            $(selectedItem).parent().parent().find(".openArrow settingsFields,.closeArrow settingsFields,.settingsFields").toggle();
        },
        onParametersClick: function(selectedItem) {
            $(selectedItem).parent().parent().find(".openArrow parametersFields,.closeArrow parametersFields,.parametersFields").toggle();
        },
        onGroupDateClick: function(selectedItem) {
            $(selectedItem).parent().parent().find(".openArrow groupDateFields,.closeArrow groupDateFields,.groupDateFields").toggle();
        },
        onMissedValuesClick: function(selectedItem) {
            $(selectedItem).parent().parent().find(".openArrow missedValues,.closeArrow missedValues,.missedValues").toggle();
        },
        onPopupEndCallback: function(s, e) {
            if (s.cpHeaderText) {
                $('#pcColumn_PWH-1T').html(s.cpHeaderText);
                delete s.cpHeaderText;
            }
        },
        onAggregateFunctionIdChanged: function(s, e) {
            var val = s.GetValue();
            var enabled = val == '10004006' || val == '10004012' ;
            cbAdministrativeUnitField.SetEnabled(enabled);
            if (enabled)
                //cbAdministrativeUnitField.SetValue(-1);
                cbAdministrativeUnitField.SetSelectedIndex(0);
            else
                cbAdministrativeUnitField.SetValue(null);
            enabled = enabled || val == '10004013'||val == '10004014' ||val == '10004015';
            cbGroupDateField.SetEnabled(enabled);
            if (enabled && cbGroupDateField.listBox.itemsValue.length > 0)
                cbGroupDateField.SetSelectedIndex(0);
            else
                cbGroupDateField.SetValue(null);
            var enableBasicCountFunction = $('#enableBasicCount')[0].value == 'True';

            enableBasicCountFunction  = enableBasicCountFunction && !(val == '10004020'/*distinct count*/ || val == '10004002'/*count*/ || val == '10004003'/*max*/ || val == '10004004'/*min*/);
            cbBasicCountFunction.SetEnabled(enableBasicCountFunction);
            $.ajax({
                url: "AggregateFunctionChanged",
                dataType: 'json',
                type: 'POST',
                data: { aggregateFunctionId: val },
                success: function(data) {
                    txtPrecision.SetNumber(data.precision);
                }
            });
        },
        onAddMissedValueChanged: function(s, e) {
            var enabled = s.GetValue();
            if (typeof dtDiapasonStartDate != "undefined") {
                dtDiapasonStartDate.SetEnabled(enabled);
                if (!enabled) {
                    dtDiapasonStartDate.SetValue(null);
                }
            }
            if (typeof dtDiapasonEndDate != "undefined") {
                dtDiapasonEndDate.SetEnabled(enabled);
                if (!enabled)
                    dtDiapasonEndDate.SetValue(null);
            }
        },
        onValidateMissedValuesDate: function(s, e) {
            var endDate = dtDiapasonEndDate.GetValue();
            var startDate = dtDiapasonStartDate.GetValue();
            e.isValid = startDate != null && endDate != null && endDate > startDate;
            e.errorText = "aaa";
        },
        onEditColumn: function(s, e) {
            if (columnPopup.devxHasText(cbFieldsList)) {
                pcColumn.PerformCallback(e);
                pcColumn.Show();
            }
        },
        onCopyColumn: function(s, e) {
            if (columnPopup.devxHasText(cbFieldsList)) {
                var val = cbFieldsList.GetValue();
                $.ajax({
                    url: "OnCopyField",
                    dataType: 'json',
                    type: 'POST',
                    data: { fieldId: val },
                    success: function (data) {
                        pcColumn.Show();
                    }
                });
            }
        },
        devxHasValue:function (obj) {
            return obj != "undefined" && obj.GetValue != null && obj.GetValue() != null;
        },
        devxHasText: function (obj) {
           return obj != "undefined" && obj.GetText != null && obj.GetText() != "";
        },

        
    };
})();
    