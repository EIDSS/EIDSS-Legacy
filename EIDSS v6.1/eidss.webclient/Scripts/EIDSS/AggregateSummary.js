var aggregateSummary = {
    resizeTable: function () {
        var browserWindow = $(window);
        var width = browserWindow.width() - 20;
        for (var i = 0; i < $(".ffSummaryInfo").length; i++) {
            $(".ffSummaryInfo")[i].style.width = width.toString() + "px";
        }
        $(".ffSummaryInfo").css({ "min-width": width.toString() + "px" });
        $(".ffSummaryInfo").css({ "max-width": width.toString() + "px" });
    },


    onStatisticChanged: function (e) {
        var args = comboBoxFacade.getOnChangedEventArgs(e, this);
        var cbId = args.senderId;
        formRefresher.setOnChangedSuccess(aggregateSummary.onStatisticChangedSuccess, e);
        formRefresher.onFieldChanged(cbId, args.selectedValue);
    },

    onStatisticChangedSuccess: function () {
        var objectIdent = $("#ObjectIdent").val();
        var areaType = comboBoxFacade.getValueById(objectIdent + 'StatisticAreaType');
        var periodType = comboBoxFacade.getValueById(objectIdent + 'StatisticPeriodType');
        if (areaType != '' && periodType != '' && areaType != '0' && periodType != '0') {
            $("#bTopPanel_Select").enable(true);
            $("#bTopPanel_Select").removeAttr('disabled');
            $("#bTopPanel_Select").removeClass("k-state-disabled");
        } else {
            $("#bTopPanel_Select").enable(false);
            $("#bTopPanel_Select").attr('disabled', 'disabled');
            $("#bTopPanel_Select").addClass("k-state-disabled");
        }
    },

    selectHumanAggrCase: function () {
        var objectIdent = $("#ObjectIdent").val();
        var areaType = comboBoxFacade.getValueById(objectIdent + 'StatisticAreaType');
        var periodType = comboBoxFacade.getValueById(objectIdent + 'StatisticPeriodType');
        if (areaType != '' && periodType != '' && areaType != '0' && periodType != '0') {
            var url = bvUrls.getHumanAggregateCasePickerUrl({ reportAreaType: areaType, reportPeriodType: periodType });
            var title = EIDSS.BvMessages['titleHumanAggregateCasesList'];
            searchPicker.show(url, title, "H15");
        }
    },

    selectVetAggrCase: function () {
        var objectIdent = $("#ObjectIdent").val();
        var areaType = comboBoxFacade.getValueById(objectIdent + 'StatisticAreaType');
        var periodType = comboBoxFacade.getValueById(objectIdent + 'StatisticPeriodType');
        if (areaType != '' && periodType != '') {
            var url = bvUrls.getVetAggregateCasePickerUrl({ reportAreaType: areaType, reportPeriodType: periodType });
            var title = EIDSS.BvMessages['titleVetAggregateCasesList'];
            searchPicker.show(url, title, "V09");
        }
    },

    selectVetAggrAction: function () {
        var objectIdent = $("#ObjectIdent").val();
        var areaType = comboBoxFacade.getValueById(objectIdent + 'StatisticAreaType');
        var periodType = comboBoxFacade.getValueById(objectIdent + 'StatisticPeriodType');
        if (areaType != '' && periodType != '') {
            var url = bvUrls.getVetAggregateActionPickerUrl({ reportAreaType: areaType, reportPeriodType: periodType });
            var title = EIDSS.BvMessages['titleVetAggregateActionsList'];
            searchPicker.show(url, title, "V13");
        }
    },

    onAggrCaseItemPickerSelectAll: function() {
        var objectIdent = $("#ObjectIdent").val();
        var idfAggrCase = $("#idfAggrCase").val();
        var areaType = $('#hdnReportAreaType').val();
        var periodType = $('#hdnReportPeriodType').val();
        var selectedItems = bvGrid.getAllItemId("Grid");
        if (selectedItems != "") {
            var postUrl = bvUrls.getAggrSummAddSelectedAggregateCaseItems();
            showLoading();
            $.ajax({
                url: postUrl,
                type: "POST",
                async: true,
                data: {
                    selectedItems: selectedItems,
                    reportAreaType: areaType,
                    reportPeriodType: periodType,
                    idfAggrCase: idfAggrCase,
                },
                success: function (data) {
                    hideLoading();
                    bvPopup.closeDefaultPopup();
                    var hasError = formRefresher.hasError(data);
                    if (hasError) {
                        formRefresher.updateControls(data);
                    } else {
                        //aggregateCase.updateButtonsState();
                        bvGrid.reloadById(objectIdent + "AggregateCaseListItems");
                    }
                },
                error: function () {
                    hideLoading();
                }
            });

        }
    },

    onAggrCaseItemPickerSelect: function () {
        var objectIdent = $("#ObjectIdent").val();
        var idfAggrCase = $("#idfAggrCase").val();
        var areaType = $('#hdnReportAreaType').val();
        var periodType = $('#hdnReportPeriodType').val();
        var selectedItems = bvGrid.getSelectedItemId("Grid");
        if (selectedItems != "") {
            var postUrl = bvUrls.getAggrSummAddSelectedAggregateCaseItems({ selectedItems: selectedItems, reportAreaType: areaType, reportPeriodType: periodType, idfAggrCase: idfAggrCase });

            $.getJSON(postUrl, null, function(data) {
                bvPopup.closeDefaultPopup();
                var hasError = formRefresher.hasError(data);
                if (hasError) {
                    formRefresher.updateControls(data);
                } else {
                    //aggregateCase.updateButtonsState();
                    bvGrid.reloadById(objectIdent + "AggregateCaseListItems");
                }
            });
        }
    },

    removeAllFromAggrCase: function () {
        var objectIdent = $("#ObjectIdent").val();
        var idfAggrCase = $("#idfAggrCase").val();
        var url = bvUrls.getAggrSummRemoveAllAggregateCaseItems({ idfAggrCase: idfAggrCase });
        $.post(url, null, function (data) {
            bvGrid.reloadById(objectIdent + "AggregateCaseListItems");
        });
    },

    showSummaryInfoAggrCase: function () {
        showLoading();
        var idfAggrCase = $("#idfAggrCase").val();
        var postUrl = bvUrls.getAggrSummSummaryFlexibleForm({ idfAggrCase: idfAggrCase });
        $.getJSON(postUrl, null, function (result) {
            for (var i = 0; i < result.data.length; i++) {
                var div = $("#" + result.data[i].divId);
                div.html(result.data[i].divContent);
            }
            hideLoading();
        });
    },

    printAggrCase: function() {
        var objectIdent = $("#ObjectIdent").val();
        if (bvGrid.isGridEmpty(objectIdent + "AggregateCaseListItems")) {
            return;
        }
        if ($("tr[role='row']").length < 2) {
            return;
        }
        
        var idfAggrCase = $("#idfAggrCase").val();
        var areaType = comboBoxFacade.getValueById(objectIdent + 'StatisticAreaType');
        var periodType = comboBoxFacade.getValueById(objectIdent + 'StatisticPeriodType');
        var url = bvUrls.getAggrSummAggregateReport({reportAreaType: areaType, reportPeriodType: periodType, idfAggrCase: idfAggrCase});
        detailPage.openReport(url);
    },
 
    
}