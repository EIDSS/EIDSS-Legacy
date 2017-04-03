var aggregateForm = (function() {
    var currentUniquePath;
    var currentLayoutId;

    return {
        OnAggregate: function (layoutId) {
            currentLayoutId = layoutId;
            if (cbColumn.GetValue() === null)
                currentUniquePath = undefined;
            else
                currentUniquePath = cbColumn.GetValue();
            $.ajax({
                url: avrUrls.getAddAggregateUrl(),
                dataType: 'json',
                type: 'POST',
                data: { layoutId: layoutId,
                        uniquePath: currentUniquePath
                      },
                success: function (data) {
                    if (data.result == 'ok') {
                        currentUniquePath = data.colSelected;
                        cbColumn.PerformCallback();
                        cbColumn.SetValue(currentUniquePath);
                        pcAggregateColumn.PerformCallback();
                        layoutViewGrid.PerformCallback();
                    }
                }
            });
        },

        cbColumn_OnEndCallback: function (s, e) {
            //s.SetValue(currentUniquePath);
        },

        OnEditColumn: function (layoutId) {
            currentLayoutId = layoutId;
            if (cbColumn.GetText() != null && cbColumn.GetText() != "")
                pcAggregateColumn.Show();
        },

        OnDeleteColumn: function (layoutId) {
            if (cbColumn.GetValue() !== null) {
                currentUniquePath = cbColumn.GetValue();
                $.ajax({
                    url: avrUrls.getIfAggregateUrl(),
                    dataType: 'json',
                    type: 'POST',
                    data: {
                        layoutId: layoutId,
                        uniquePath: currentUniquePath
                    },
                    success: function (data) {
                        if (data.result == 'ask') {
                            confForm.OnHyperLinkClick(data.messageText, data.yesFunction, data.noFunction);
                        }
                    }
                });
            }
            //confForm.OnHyperLinkClick(EIDSS.BvMessages['msgDeleteAggregateColumn'], 'aggregateForm.DeleteColumn(' + layoutId + ');', '');
        },

        DeleteColumn: function (layoutId, uniquePath) {
            if (uniquePath !== null) {
                    $.ajax({
                        url: avrUrls.getDeleteAggregateUrl(),
                        dataType: 'json',
                        type: 'POST',
                        data: {
                            layoutId: layoutId,
                            uniquePath: uniquePath
                        },
                        success: function (data) {
                            currentUniquePath = undefined;
                            layoutViewGrid.PerformCallback();
                            cbColumn.PerformCallback();
                        }
                    });
                }
        },

        OnPopupBeginCallback: function (s, e) {
            e.customArgs["layoutId"] = currentLayoutId;
        },

        OnPopupEndCallback: function (s, e) {
            if (s.cpHeaderText) {
                $('#pcAggregateColumn_PWH-1T').html(s.cpHeaderText);
                delete s.cpHeaderText;
            }
            aggregateForm.Visibility(s.cpAggrFunction);
            if (s.cpAggrFunction) {
                delete s.cpAggrFunction;
            }
        },

        OnSettingsClick: function (selectedItem) {
            $(selectedItem).parent().parent().find(".openArrow settingsFields,.closeArrow settingsFields,.settingsFields").toggle();
        },

        OnParametersClick: function (selectedItem) {
            $(selectedItem).parent().parent().find(".openArrow parametersFields,.closeArrow parametersFields,.parametersFields").toggle();

            var sel = cbAggregate.GetSelectedItem();
            var val = 0;
            if (cbAggregate.GetSelectedItem() !== undefined)
                val = cbAggregate.GetValue();
            aggregateForm.Visibility(val);
        },

        OnAggregateFunctionSelectionChanged: function (s, args) {
            var val = s.GetValue();
            aggregateForm.Visibility(val);
        },

        Visibility: function (argf) {
            var enabled = argf == '10004011' || argf == '10004019';
            //cbDenominator.SetEnabled(enabled);

            if (enabled) {
                $("#lblSourceColumn").hide();
                $("#lblNumeratorColumn").show();
                $("#lblDenominator").show();
                $("#cbDenominator").show();
            } else {
                $("#lblSourceColumn").show();
                $("#lblNumeratorColumn").hide();
                $("#lblDenominator").hide();
                $("#cbDenominator").hide();
            }

            enabled = enabled || argf == '10004016' || argf == '10004007' || argf == '10004010';
            //cbSourceColumn.SetEnabled(enabled);

            if (enabled) {
                $("#cbSourceColumn").show();
            } else {
                $("#lblSourceColumn").hide();
                $("#cbSourceColumn").hide();
            }
        }
    };
})();