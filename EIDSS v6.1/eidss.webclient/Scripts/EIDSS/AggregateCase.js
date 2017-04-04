
// TODO: удалить неиспользуемые функции, перевести на kendo

var aggregateCase = {
    onHumanAggrCaseReportClick: function() {
        detailPage.onShowReportClick(aggregateCase.showHumanAggrCaseReport);
    },

    showHumanAggrCaseReport: function() {
        var caseId = $("#idfAggrCase").val();
        var url = bvUrls.getHumanAggregateCaseReportUrl({ id: caseId });
        detailPage.openReport(url);
    },

    onVetAggrCaseReportClick: function() {
        detailPage.onShowReportClick(aggregateCase.showVetAggrCaseReport);
    },

    showVetAggrCaseReport: function() {
        var caseId = $("#idfAggrCase").val();
        var url = bvUrls.getVetAggregateCaseReportUrl({ id: caseId });
        detailPage.openReport(url);
    },

    onVetAggrActionReportClick: function() {
        detailPage.onShowReportClick(aggregateCase.showVetAggrActionReport);
    },

    showVetAggrActionReport: function() {
        var caseId = $("#idfAggrCase").val();
        var url = bvUrls.getVetAggregateActionReportUrl({ id: caseId });
        detailPage.openReport(url);
    },

    initialDateMinMax: function () {
        var caseId = $("#idfAggrCase").val();
        var id = "Header_" + caseId + "_YearAggr";
        var today = new Date();
        var value = today.getFullYear();
        var data = {
            senderId: id,
            selectedValue: value
        };
        datePickerFacade.setMinMaxArgs(data, 'DayForAggr', 'y');
    },

    onYearChangedSuccess: function(e, data) {
        /*comboBoxFacade.reloadReferenceComboBox(e, 'QuarterAggr');
        comboBoxFacade.reloadReferenceComboBox(e, 'MonthAggr');
        comboBoxFacade.reloadReferenceComboBox(e, 'WeekAggr');*/
        var args = comboBoxFacade.getOnChangedEventArgs(e, this);
        var valYear = data.Values[args.senderId].value;
        var valMonth = data.Values[args.senderId.replace("Year", "Month")].value;
        datePickerFacade.setMinMax(e, 'DayForAggr', 'y', valYear);
        datePickerFacade.setMinMax(e, 'DayForAggr', 'm', valMonth);
    },

    onYearChanged: function(e) {
        formRefresher.setOnChangedSuccess(aggregateCase.onYearChangedSuccess, e);
        bvComboBox.onChanged.call(this, e);
    },

    onMonthChangedSuccess: function (args) {
        datePickerFacade.setMinMaxArgs(args, 'DayForAggr', 'm');
    },

    onMonthChanged: function(e) {
        var args = datePickerFacade.getOnChangedEventArgs(e);
        formRefresher.setOnChangedSuccess(aggregateCase.onMonthChangedSuccess, args);
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

}