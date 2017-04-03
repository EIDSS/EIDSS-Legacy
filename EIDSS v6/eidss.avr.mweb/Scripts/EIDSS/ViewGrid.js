var lastColumnOrder1PostedBack = "";
var lastColumnOrder2PostedBack = "";
var lastColumnOrder3PostedBack = "";
var viewGridForm = (function () {
    return {
        InitForm: function () {
        },

        OnMapDefDataChartSelectionChanged: function (s, args) {
            checkComboBox.UpdateText(cbMapDefDataChart, s);
            $.ajax({
                url: avrUrls.getMapDefDataChartUrl(),
                dataType: 'json',
                type: 'POST',
                data: s.GetSelectedItems()
            });
        },

        SynchronizeMapDefDataChartValues: function (dropDown, args) {
            checkComboBox.Synchronize(dropDown, chlMapDefDataChart);
        },

        OnChartDefXaxisSelectionChanged: function (s, args) {
            $.ajax({
                url: avrUrls.getChartDefXaxisUrl(),
                dataType: 'json',
                type: 'POST',
                data: "text=" + s.GetValue()
            });
        },

        OnChartDefSeriesSelectionChanged: function (s, args) {
            checkComboBox.UpdateText(cbChartDefSeries, s);
            $.ajax({
                url: avrUrls.getChartDefSeriesUrl(),
                dataType: 'json',
                type: 'POST',
                data: s.GetSelectedItems()
            });
        },

        SynchronizeChartDefSeriesValues: function (dropDown, args) {
            checkComboBox.Synchronize(dropDown, chlChartDefSeries);
        },

        OnMapDefDataGradientSelectionChanged: function (s, args) {
            $.ajax({
                url: avrUrls.getMapDefDataGradientUrl(),
                dataType: 'json',
                type: 'POST',
                data: "text=" + s.GetValue()
            });
        },

        OnMapDefAdminUnitSelectionChanged: function (s, args) {
            $.ajax({
                url: avrUrls.getMapDefAdminUnitUrl(),
                dataType: 'json',
                type: 'POST',
                data: "text=" + s.GetValue()
            });
        },

        OnColBandSelectionChanged: function (s, args) {
            var selField = s.GetValue();
            /*var enabled = selField != null && selField != "";
            var control = $("#btnEditColCaption");
            if (enabled)
                control.removeAttr('disabled');
            else
                control.attr('disabled', 'disabled');
            */
            $.ajax({
                url: avrUrls.getColBandChangedUrl(),
                dataType: 'json',
                type: 'POST',
                data: {
                    //layoutId: document.forms[0].LayoutId.value,
                    uniquePath: selField
                },
                success: function (data) {
                    pcAggregateColumn.PerformCallback(args);
                }
            });
        },

        //grid customization window
        grid_CustomizationWindowCloseUp: function (s, e) {
            viewGridForm.UpdateButtonText();
        },
        UpdateCustomizationWindowVisibility: function () {
            if (layoutViewGrid.IsCustomizationWindowVisible())
                layoutViewGrid.HideCustomizationWindow();
            else
                layoutViewGrid.ShowCustomizationWindow();
            viewGridForm.UpdateButtonText();
        },
        UpdateButtonText: function () {
            var text = layoutViewGrid.IsCustomizationWindowVisible() ? EIDSS.BvMessages['btHideCustomizationWindow'] : EIDSS.BvMessages['btShowCustomizationWindow'];
            $("#btShowCustomizationWindow").val(text);
        },

        grid_ColumnMoving: function (s, e) {
            if (e.destinationColumn != null) {
                var selField = e.sourceColumn.id;
                var dstField = e.destinationColumn.id;
                var colCnt = layoutViewGrid.GetColumnsCount();
                /*var names = new Array();
                for (var i = 0; i < colCnt; i++) {
                    var col = layoutViewGrid.GetColumn(i);
                    names[col.index] = col.name;
                }
                var columnOrder = names.join();*/
                if (selField != lastColumnOrder1PostedBack || dstField != lastColumnOrder2PostedBack || e.isDropBefore != lastColumnOrder3PostedBack) {
                    lastColumnOrder1PostedBack = selField;
                    lastColumnOrder2PostedBack = dstField;
                    lastColumnOrder3PostedBack = e.isDropBefore;
                    $.ajax({
                        url: avrUrls.getColumnMovingUrl(),
                        dataType: 'json',
                        type: 'POST',
                        data: {
                            //layoutId: document.forms[0].LayoutId.value,
                            source: selField,
                            destination: dstField,
                            isDropBefore: e.isDropBefore
                        }
                    });
                }
            }
        },

        grid_ColumnResized: function(s, e) {
            s.PerformCallback();
        },

        grid_CallbackError: function (s, e) {
            e.handled = true;
            defaultPage.checkTimeoutError(e.message);
        },

        grid_SelectionChanged: function (s, e) {
            if (e.isSelected) {
                var key = s.GetRowKey(e.visibleIndex);
                alert(key);
            }
        },

        grid_OnContextMenu: function (s, e) {
            if (e.objectType == "header") {
                var menuItemSelected = e.menu.GetItemByName("GroupByColumn");
                if (menuItemSelected != null)
                    menuItemSelected.SetVisible(false);
                menuItemSelected = e.menu.GetItemByName("ShowFilterRow");
                if (menuItemSelected != null)
                    menuItemSelected.SetVisible(false);
                menuItemSelected = e.menu.GetItemByName("ShowFooter");
                if (menuItemSelected != null)
                    menuItemSelected.SetVisible(false);
                menuItemSelected = e.menu.GetItemByName("ShowGroupPanel");
                if (menuItemSelected != null)
                    menuItemSelected.SetVisible(false);
            }
        },

        GetSelectedFieldValuesCallback: function (values) {
            SelectedRows.BeginUpdate();
            try {
                SelectedRows.ClearItems();
                for (var i = 0; i < values.length; i++) {
                    SelectedRows.AddItem(values[i]);
                }
            } finally {
                SelectedRows.EndUpdate();
            }

        },

        OnSave: function () {
            var data = $("form").serialize(true);
            $.ajax({
                url: avrUrls.getIsChangedUrl(),
                dataType: 'json',
                type: 'POST',
                success: function (data) {
                    if (data.result == 'ask') {
                        confForm.OnHyperLinkClick(data.messageText, data.yesFunction, data.noFunction);
                    }
                }
            });
        },

        OnRefreshData: function () {
            $.ajax({
                url: avrUrls.getViewRefreshUrl(),
                dataType: 'json',
                type: 'POST',
                success: function (data) {
                    if (data.result == 'ask') {
                        confForm.OnHyperLinkClick(data.messageText, data.yesFunction, data.noFunction);
                    }
                    else
                        document.location.href = data.function;
                }
            });
        },

        OnResetView: function () {
            $.ajax({
                url: avrUrls.getResetUrl(),
                dataType: 'json',
                type: 'GET',
                success: function (data) {
                    confForm.OnHyperLinkClick(data.messageText, data.yesFunction, data.noFunction);
                }
            });
        },

        OnCancelChanges: function () {
            $.ajax({
                url: avrUrls.getCancelChangesUrl(),
                dataType: 'json',
                type: 'GET',
                success: function (data) {
                    if (data.result == 'ask') {
                        confForm.OnHyperLinkClick(data.messageText, data.yesFunction, data.noFunction);
                    }
                }
            });
        },

        OnClose: function () {
            $.ajax({
                url: avrUrls.getCloseUrl(),
                type: 'GET',
                success: function () {
                    window.close();
                }
            })
        },

        OnExport: function (s, e) {
            if (e.item.name != "") {
                document.forms[0].typeName.value = e.item.name;
                document.forms[0].submit();
            }
        },

        OnOpenChart: function (layoutId, val) {
            var width = $(window).width() - 40;
            var height = $(window).height() - 160;
            /*$.ajax({
                url: avrUrls.getViewChartOpenUrl() + '?layoutId=' + document.forms[0].LayoutId.value,
                dataType: 'json',
                type: 'GET',
                success: function (data) {
                    window.open(avrUrls.getChartOpenUrl() + '?layoutId=' + document.forms[0].LayoutId.value + "&width=" + width + "&height=" + height);
                }
            });*/
            //var value = ChartXAxisViewColumn.GetValue();
            if (val != undefined && val != "" && chlChartDefSeries.listTable.innerText != "")
                window.open(avrUrls.getChartOpenUrl() + '?layoutId=' + layoutId + "&width=" + width + "&height=" + height);
        },

        OnOpenMap: function (layoutId) {
            if (cbMapDefAdminUnit.lastSuccessText != undefined && cbMapDefAdminUnit.lastSuccessText != "" && chlMapDefDataChart.listTable.innerText != "")
                window.open(avrUrls.getMapOpenUrl() + '?layoutId=' + layoutId);
        }

    };
})();
