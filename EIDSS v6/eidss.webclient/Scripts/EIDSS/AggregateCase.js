
// TODO: удалить неиспользуемые функции, перевести на kendo

var aggregateCase = {
    onHumanAggrCaseReportClick: function() {
        detailPage.onShowReportClick(aggregateCase.showHumanAggrCaseReport);
    },

    showHumanAggrCaseReport: function() {
        var caseId = $("#idfAggrCase").val();
        var lang = GetSiteLanguage();
        var url = "/" + lang + "/HumanAggregateCase/HumanAggregateCaseReport" + "?id=" + caseId;
        detailPage.openReport(url);
    },

    onVetAggrCaseReportClick: function() {
        detailPage.onShowReportClick(aggregateCase.showVetAggrCaseReport);
    },

    showVetAggrCaseReport: function() {
        var caseId = $("#idfAggrCase").val();
        var lang = GetSiteLanguage();
        var url = "/" + lang + "/VetAggregateCase/VetAggregateCaseReport" + "?id=" + caseId;
        detailPage.openReport(url);
    },

    onVetAggrActionReportClick: function() {
        detailPage.onShowReportClick(aggregateCase.showVetAggrActionReport);
    },

    showVetAggrActionReport: function() {
        var caseId = $("#idfAggrCase").val();
        var lang = GetSiteLanguage();
        var url = "/" + lang + "/VetAggregateAction/VetAggregateActionReport" + "?id=" + caseId;
        detailPage.openReport(url);
    },

    onYearChangedSuccess: function(e) {
        comboBoxFacade.reloadReferenceComboBox(e, 'QuarterAggr');
        comboBoxFacade.reloadReferenceComboBox(e, 'MonthAggr');
        comboBoxFacade.reloadReferenceComboBox(e, 'WeekAggr');
        datePickerFacade.setMinMax(e, 'DayForAggr', 'y');
    },

    onYearChanged: function(e) {
        formRefresher.setOnChangedSuccess(aggregateCase.onYearChangedSuccess, e);
        bvComboBox.onChanged.call(this, e);
    },

    onMonthChangedSuccess: function(e) {
        datePickerFacade.setMinMax(e, 'DayForAggr', 'm');
    },

    onMonthChanged: function(e) {
        formRefresher.setOnChangedSuccess(aggregateCase.onMonthChangedSuccess, e);
        bvComboBox.onChanged.call(this, e);
    },


    reloadFlexForm: function (fname, itemId, url) {
        flexForms.reloadFf(url, fname, itemId);
    },

    toFlexFormCaseReloadE: function (e) {
        formRefresher.setOnChangedSuccess(aggregateCase.toFlexFormCaseReload);
        bvComboBox.onChanged.call(this, e);
    },

    toFlexFormCaseReload: function () {
        showLoading();
        var caseId = $("#idfAggrCase").val();
        var url = bvUrls.getAggrCaseFlexFormCase();
        aggregateCase.reloadFlexForm('FlexFormCase', caseId, url);
    },

    toFlexFormDiagnosticReload: function () {
        showLoading();
        var caseId = $("#idfAggrCase").val();
        var url = bvUrls.getAggrCaseFlexFormDiagnostic();
        aggregateCase.reloadFlexForm('FlexFormDiagnostic', caseId, url);
    },

    toFlexFormProphylacticReload: function () {
        showLoading();
        var caseId = $("#idfAggrCase").val();
        var url = bvUrls.getAggrCaseFlexFormProphylactic();
        aggregateCase.reloadFlexForm('FlexFormProphylactic', caseId, url);
    },

    toFlexFormSanitaryReload: function () {
        showLoading();
        var caseId = $("#idfAggrCase").val();
        var url = bvUrls.getAggrCaseFlexFormSanitary();
        aggregateCase.reloadFlexForm('FlexFormSanitary', caseId, url);
    },


    /*
    onCaseSummaryLoad: function() {
        aggregateCase.updateButtonsState();
    },

    updateButtonsState: function(curWindow) {
        if (!curWindow) {
            curWindow = window;
        }
        var gridId = "AggregateCaseGrid";
        var grid = curWindow.$("#" + gridId).data('tGrid');
        var row = grid.$rows()[0];
        if (row.cells.length > 1) {
            curWindow.$('#btEdit').removeAttr('disabled');
            curWindow.$('#btRemove').removeAttr('disabled');
            curWindow.$('#btRemoveAll').removeAttr('disabled');
        } else {
            curWindow.$('#btEdit').attr('disabled', 'disabled');
            curWindow.$('#btRemove').attr('disabled', 'disabled');
            curWindow.$('#btRemoveAll').attr('disabled', 'disabled');
        }
        var areaType = curWindow.$('#cbAreaType').data('tComboBox').selectedIndex;
        var periodType = curWindow.$('#cbPeriodType').data('tComboBox').selectedIndex;
        if (areaType >= 0 && periodType >= 0) {
            curWindow.$('#btSelect').removeAttr('disabled');
            curWindow.$('#btnShowSummaryInfo').removeAttr('disabled');
        } else {
            curWindow.$('#btSelect').attr('disabled', 'disabled');
            curWindow.$('#btnShowSummaryInfo').attr('disabled', 'disabled');
        }
        curWindow.$('#btnShowReport').attr('disabled', 'disabled');
    },

    closeCaseSummary: function() {
        actions.redirect(bvUrls.getHomeUrl());
    },

    onAreaTypeChange: function(e) {
        var args = comboBoxFacade.getOnChangedEventArgs(e, this);
        if (args.previousValue == args.selectedValue) {
            return;
        }
        var previousValue = args.previousValue;
        var postUrl = bvUrls.getByPath("/CommonAggregate/AreaType_OnChange") + "?previousValue=" + previousValue + "&newValue=" + args.selectedValue;
        $.getJSON(postUrl, null, function(result) {
            if (result.cansel) {
                comboBoxFacade.cancelSelection(args.senderId, previousValue);
            }
        });
        aggregateCase.updateButtonsState();
    },

    onPeriodTypeChange: function(e) {
        var args = comboBoxFacade.getOnChangedEventArgs(e, this);
        if (args.previousValue == args.selectedValue) {
            return;
        }
        var previousValue = args.previousValue;
        var postUrl = bvUrls.getByPath("/CommonAggregate/PeriodType_OnChange") + "?previousValue=" + previousValue + "&newValue=" + args.selectedValue;

        $.getJSON(postUrl, null, function(result) {
            if (result.cansel) {
                comboBoxFacade.cancelSelection(args.senderId, previousValue);
            }
        });
        aggregateCase.updateButtonsState();
    },

    showAggregateCaseItemEditor: function(path, isNew, title) {
        var itemId = 0;
        if (!isNew) {
            itemId = bvGrid.getSelectedItemId("AggregateCaseGrid");
        }
        var url = path + "?id=" + itemId;
        OpenPopup(url, title);
    },

    saveAggregateCase: function(controllerName, idfAggrCase, isNewCase) {
        var contentData = bvPopup.getDefaultWindowData();
        var lang = GetSiteLanguage();
        var postUrl = "/" + lang + "/" + controllerName + "/SaveAggregateCase";
        $.ajax({
            url: postUrl,
            dataType: "json",
            type: "POST",
            data: contentData,
            success: function(result) {
                if (!result) {
                    bvPopup.closeDefaultPopup();
                    if (isNewCase.toString().toLowerCase() == 'false') {
                        UpdateAggregateCaseInGrid(idfAggrCase);
                    }
                } else {
                    bvDialog.showError(result);
                }
            },
            error: function(error) {
                bvPopup.closeDefaultPopup();
            }
        });
    },

    updateAggregateCaseInGrid: function(idfAggrCase, curWindow) {
        var areaType = comboBoxFacade.getValueById('cbAreaType');
        var periodType = comboBoxFacade.getValueById('cbPeriodType');
        if (!areaType || !periodType) {
            return;
        }
        var lang = GetSiteLanguage();
        var postUrl = "/" + lang + "/CommonAggregate/UpdateSelectedAggregateCaseItem?selectedItem=" + idfAggrCase +
            "&reportAreaType=" + areaType + "&reportPeriodType=" + periodType;
        $.ajax({
            url: postUrl,
            dataType: "json",
            type: "POST",
            async: false,
            success: function(result) {
                aggregateCase.changeAggregateCaseGridData(result.data, result.total, curWindow);
                aggregateCase.updateButtonsState(curWindow);
            }
        });
    },

    isNewAggrCase: function(idfAggrCase, curWindow) {
        if (!curWindow) {
            curWindow = window;
        }
        var tdArr = curWindow.$("#AggregateCaseGrid .t-grid-content table tr td.gridId");
        var found = false;
        tdArr.each(function(index, td) {
            var cellText = $(td).text();
            if (cellText == idfAggrCase) {
                found = true;
                return false;
            }
        });
        return !found;
    },

    showAggregateCaseItemPicker: function(path, title) {
        var areaType = comboBoxFacade.getValueById('cbAreaType');
        var periodType = comboBoxFacade.getValueById('cbPeriodType');
        if (areaType >= 0 && periodType >= 0) {
            var url = "/" + lang + "/HumanAggregateCase/HumanAggregateCasePicker" + "?reportAreaType=" + areaType + "&reportPeriodType=" + periodType;
            searchPicker.show(url, title);
        }
    },

    onAggregateCasePickerSearchAndOrder: function(url) {
        var lang = GetSiteLanguage();
        var postUrl = "/" + lang + url;
        searchPicker.search(postUrl, "Message");
        searchPicker.selectFirsGridRow();
    },

    onAggregateCaseItemPickerSelect: function() {
        var areaType = $('#hdnReportAreaType').val();
        var periodType = $('#hdnReportPeriodType').val();
        var selectedItems = bvGrid.getSelectedItemId("Grid"); //selectAll ? searchPicker.getAllFilteredIds() : searchPicker.getCheckedIds();
        var lang = GetSiteLanguage();
        var postUrl = "/" + lang + "/CommonAggregate/AddSelectedAggregateCaseItems?selectedItems=" + selectedItems +
            "&reportAreaType=" + areaType + "&reportPeriodType=" + periodType;
        $.getJSON(postUrl, null, function(result) {
            if (result.isValid) {
                aggregateCase.changeAggregateCaseGridData(result.data, result.total);
                aggregateCase.updateButtonsState();
                bvPopup.closeDefaultPopup();
            } else {
                bvDialog.showError(result.error);
            }
        });
    },

    onRemoveAggrCaseButtonClick: function() {
        var selectedId = bvGrid.getSelectedItemId("AggregateCaseGrid");
        var lang = GetSiteLanguage();
        var postUrl = "/" + lang + "/CommonAggregate/RemoveAggregateCaseItem?selectedId=" + selectedId;
        $.getJSON(postUrl, null, function(result) {
            aggregateCase.changeAggregateCaseGridData(result.data, result.total);
            aggregateCase.updateButtonsState();
        });
    },

    onRemoveAllAggrCasesButtonClick: function() {
        var lang = GetSiteLanguage();
        var postUrl = "/" + lang + "/CommonAggregate/RemoveAllAggregateCaseItems";
        $.getJSON(postUrl, null, function(result) {
            aggregateCase.changeAggregateCaseGridData(result.data, result.total);
            aggregateCase.updateButtonsState(curWindow);
        });
    },

    changeAggregateCaseGridData: function(data, total, curWindow) {
        if (!curWindow) {
            curWindow = window;
        }
        var grid = curWindow.$("#AggregateCaseGrid").data('tGrid');
        grid.total = total;
        grid.dataBind(data);
    },

    onShowAggregateCaseSummaryReport: function() {
        var areaType = comboBoxFacade.getValueById('cbAreaType');
        var periodType = comboBoxFacade.getValueById('cbPeriodType');
        var lang = GetSiteLanguage();
        var url = "/" + lang + "/CommonAggregate/AggregateReport?reportAreaType=" + areaType + "&reportPeriodType=" + periodType;
        detailPage.openReport(url);
    },

    onShowSummaryInfo: function() {
        var gridId = "AggregateCaseGrid";
        var grid = $("#" + gridId).data('tGrid');
        var row = grid.$rows()[0];
        var isReportButtonEnabled = false;
        if (row.cells.length > 1) {
            isReportButtonEnabled = true;
        }
        aggregateCase.showSummaryInfo(isReportButtonEnabled);
    },
    
    showSummaryInfo: function(isReportButtonEnabled) {
        showLoading();
        $('#btnShowReport').attr('disabled', 'disabled');
        var lang = GetSiteLanguage();
        var postUrl = "/" + lang + "/CommonAggregate/SummaryFlexibleForm";
        $.getJSON(postUrl, null, function(result) {
            for (var i = 0; i < result.data.length; i++) {
                var div = $("#" + result.data[i].divId);
                div.html(result.data[i].divContent);
                if (isReportButtonEnabled) {
                    $('#btnShowReport').removeAttr('disabled');
                }
            }
            hideLoading();
        });
    }
    */
}