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
            var lang = GetSiteLanguage();
            var url = "/" + lang + "/HumanAggregateCase/HumanAggregateCasePicker" + "?reportAreaType=" + areaType + "&reportPeriodType=" + periodType;
            var title = EIDSS.BvMessages['titleHumanAggregateCasesList'];
            var formNumber = "H15";
            searchPicker.show(url, title, formNumber);
        }
    },

    selectVetAggrCase: function () {
        var objectIdent = $("#ObjectIdent").val();
        var areaType = comboBoxFacade.getValueById(objectIdent + 'StatisticAreaType');
        var periodType = comboBoxFacade.getValueById(objectIdent + 'StatisticPeriodType');
        if (areaType != '' && periodType != '') {
            var lang = GetSiteLanguage();
            var url = "/" + lang + "/VetAggregateCase/VetAggregateCasePicker" + "?reportAreaType=" + areaType + "&reportPeriodType=" + periodType;
            var title = EIDSS.BvMessages['titleVetAggregateCasesList'];
            var formNumber = "V09";
            searchPicker.show(url, title, formNumber);
        }
    },

    selectVetAggrAction: function () {
        var objectIdent = $("#ObjectIdent").val();
        var areaType = comboBoxFacade.getValueById(objectIdent + 'StatisticAreaType');
        var periodType = comboBoxFacade.getValueById(objectIdent + 'StatisticPeriodType');
        if (areaType != '' && periodType != '') {
            var lang = GetSiteLanguage();
            var url = "/" + lang + "/VetAggregateAction/VetAggregateActionPicker" + "?reportAreaType=" + areaType + "&reportPeriodType=" + periodType;
            var title = EIDSS.BvMessages['titleVetAggregateActionsList'];
            var formNumber = "V13";
            searchPicker.show(url, title, formNumber);
        }
    },

    onAggrCaseItemPickerSelect: function () {
        var objectIdent = $("#ObjectIdent").val();
        var idfAggrCase = $("#idfAggrCase").val();
        var areaType = $('#hdnReportAreaType').val();
        var periodType = $('#hdnReportPeriodType').val();
        var selectedItems = bvGrid.getSelectedItemId("Grid");
        if (selectedItems != "") {
            var lang = GetSiteLanguage();
            var postUrl = "/" + lang + "/AggregateSummary/AddSelectedAggregateCaseItems?selectedItems=" + selectedItems +
                "&reportAreaType=" + areaType + "&reportPeriodType=" + periodType + "&idfAggrCase=" + idfAggrCase;

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
        var lang = GetSiteLanguage();
        var url = "/" + lang + "/AggregateSummary/RemoveAllAggregateCaseItems?idfAggrCase=" + idfAggrCase;
        $.getJSON(url, null, function (data) {
            bvGrid.reloadById(objectIdent + "AggregateCaseListItems");
        });
    },

    showSummaryInfoAggrCase: function () {
        showLoading();
        var idfAggrCase = $("#idfAggrCase").val();
        var lang = GetSiteLanguage();
        var postUrl = "/" + lang + "/AggregateSummary/SummaryFlexibleForm?idfAggrCase=" + idfAggrCase;
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
        var lang = GetSiteLanguage();
        var url = "/" + lang + "/AggregateSummary/AggregateReport?reportAreaType=" + areaType + "&reportPeriodType=" + periodType + "&idfAggrCase=" + idfAggrCase;
        detailPage.openReport(url);
    },
 
    
}