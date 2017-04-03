var laboratory = (function () {

    function onTestNameChangedSuccess(e) {
        comboBoxFacade.reloadReferenceComboBox(e, 'TestResultRef');
    }

    function onTestNameChangedOnDetailSuccess(e) {
        comboBoxFacade.reloadReferenceComboBox(e, 'TestResultRef');
        
        var id = e.sender.element[0].id;
        var newId = id.substring(0, id.lastIndexOf("_") + 1) + "TestStatusShort";
        if (comboBoxFacade.getValueById(newId) == "") { // final
            return;
        }
        //var newId = id.substring(0, id.lastIndexOf("_") + 1) + "strTestStatus";
        //if ($("#" + newId).length == 1 && $("#" + newId)[0].value != "") {
        //    return;
        //}

        if ($("#FFpresenterId").length == 0) {
            laboratory.reloadFlexForm();
        }

        $(".readonlyField.invisible").parent().remove();
        $(".k-widget.k-combobox.k-header.invisible").removeAttr("style");
        $(".k-widget.k-combobox.k-header.invisible").removeClass("invisible");
    }

    function onTestStatusChangedOnDetailSuccess(e) {
        $(".k-widget.k-combobox.k-header").removeAttr("style");
    }

    function onFieldCollectedByOfficeChangedSuccess(e) {
        comboBoxFacade.reloadReferenceComboBox(e, 'CollectedByPerson');
    }

    function onCaseChangedSuccess(id) {
        comboBoxFacade.reloadReferenceComboBox2(id, 'SampleTypeFiltered');
    }

    return {
        onGridDataBound: function (e) {
            var grid = $("#Grid").data("kendoGrid");
            $("#Grid tbody tr").each(function () {
                var currentRowData = grid.dataItem(this);
                if (currentRowData.isChanges) {
                    //$(this).css("font-weight", "bold");
                    $(this).addClass("grid-changed-item");
                }
            });
        },
        

        onFilterByDiagnosisClick: function (checkBoxName) {
            formRefresher.onCheckBoxChanged(checkBoxName);
            var combo = comboBoxFacade.getReferenceControlDataByOriginalId(checkBoxName, "TestNameRef");
            if (combo) {
                combo.value(null);
                combo.dataSource.read();
            }
        },

        onTestNameChanged: function (e) {
            formRefresher.setOnChangedSuccess(onTestNameChangedSuccess, e);
            bvComboBox.onChanged.call(this, e);
        },

        onTestNameChangedOnDetail: function (e) {
            formRefresher.setOnChangedSuccess(onTestNameChangedOnDetailSuccess, e);
            bvComboBox.onChanged.call(this, e);
        },

        onTestStatusChangedOnDetail: function (e) {
            formRefresher.setOnChangedSuccess(onTestStatusChangedOnDetailSuccess, e);
            bvComboBox.onChanged.call(this, e);
        },

        onFieldCollectedByOfficeChanged: function (e) {
            formRefresher.setOnChangedSuccess(onFieldCollectedByOfficeChangedSuccess, e);
            bvComboBox.onChanged.call(this, e);
        },

        onCaseChanged: function (textBoxName) {
            formRefresher.setOnChangedSuccess(onCaseChangedSuccess, textBoxName);
            var textBoxValue = $("#" + textBoxName).val();
            formRefresher.onFieldChanged(textBoxName, textBoxValue);
        },

        onBlnExternalTestChangedSuccess: function (checkBoxName) {
            var combo = comboBoxFacade.getReferenceControlDataByOriginalId(checkBoxName, "TestedByPerson");
            if (combo) {
                combo.dataSource.read();
            }
            combo = comboBoxFacade.getReferenceControlDataByOriginalId(checkBoxName, "PerformedByOffice");
            if (combo) {
                combo.dataSource.read();
            }

            laboratory.reloadFlexForm();
        },

        onBlnExternalTestChanged: function (checkBoxName) {
            formRefresher.setOnChangedSuccess(laboratory.onBlnExternalTestChangedSuccess, checkBoxName);
            formRefresher.onCheckBoxChanged(checkBoxName);
        },

        reloadFlexForm: function () {
            var root = $("#Root").val();
            var itemId = $("#IDItem").val();
            var url = bvUrls.getLaboratoryGetFlexFormUrl();
            flexForms.reloadFf(url, "FlexForm", itemId);
        },




        CreateAliquot: function (root, idents) {
            var url = bvUrls.getLaboratoryCreateAliquotPickerUrl() + "?root=" + root + "&ids=" + idents;
            bvGrid.showEditWindow(url, 680, 150, EIDSS.BvMessages['titleCreateAliquot'], "L33");
        },
        
        saveCreateAliquot: function () {
            bvGrid.saveAndCloseEditWindow('Grid', bvUrls.getSetLaboratoryCreateAliquotUrl());
        },

        CreateDerivative: function (root, idents) {
            var url = bvUrls.getLaboratoryCreateDerivativePickerUrl() + "?root=" + root + "&ids=" + idents;
            bvGrid.showEditWindow(url, 680, 150, EIDSS.BvMessages['titleCreateDerivative'], "L34");
        },

        saveCreateDerivative: function () {
            bvGrid.saveAndCloseEditWindow('Grid', bvUrls.getSetLaboratoryCreateDerivativeUrl());
        },

        TransferOutSample: function (root, idents) {
            var url = bvUrls.getLaboratoryTransferOutSamplePickerUrl() + "?root=" + root + "&ids=" + idents;
            bvGrid.showEditWindow(url, 680, 150, EIDSS.BvMessages['titleTransferOutSample'], "L37");
        },

        saveTransferOutSample: function () {
            bvGrid.saveAndCloseEditWindow('Grid', bvUrls.getSetLaboratoryTransferOutSampleUrl());
        },

        AccessionInPoorCondition: function (root, idents) {
            var url = bvUrls.getLaboratoryAccessionInPoorConditionPickerUrl() + "?root=" + root + "&ids=" + idents;
            bvGrid.showEditWindow(url, 680, 150, EIDSS.BvMessages['titleAccessionInComment'], "L29");
        },

        saveAccessionInPoorCondition: function () {
            bvGrid.saveAndCloseEditWindow('Grid', bvUrls.getSetLaboratoryAccessionInPoorConditionUrl());
        },

        AccessionInRejected: function (root, idents) {
            var url = bvUrls.getLaboratoryAccessionInRejectedPickerUrl() + "?root=" + root + "&ids=" + idents;
            bvGrid.showEditWindow(url, 680, 150, EIDSS.BvMessages['titleAccessionInComment'], "L30");
        },

        saveAccessionInRejected: function () {
            bvGrid.saveAndCloseEditWindow('Grid', bvUrls.getSetLaboratoryAccessionInRejectedUrl());
        },

        AmendTestResult: function (root, idents) {
            var url = bvUrls.getLaboratoryAmendTestResultPickerUrl() + "?root=" + root + "&ids=" + idents;
            bvGrid.showEditWindow(url, 680, 150, EIDSS.BvMessages['titleTestResultChange'], "L23");
        },

        saveAmendTestResult: function () {
            bvGrid.saveAndCloseEditWindow('Grid', bvUrls.getSetLaboratoryAmendTestResultUrl());
        },

        AssignTest: function (root, idents) {
            var url = bvUrls.getLaboratoryAssignTestPickerUrl() + "?root=" + root + "&ids=" + idents;
            bvGrid.showEditWindow(url, 680, 150, EIDSS.BvMessages['menuAssignTest'], "L32");
        },

        saveAssignTest: function () {
            bvGrid.saveWithoutCloseEditWindow('Grid', bvUrls.getSetLaboratoryAssignTestUrl(), function() {
                var label = $("#lblAddMessage");
                label.removeClass("invisible");
            });
        },

        CreateSample: function (url1) {
            var root = $("#ID").val();
            var url = bvUrls.getLaboratoryCreateSamplePickerUrl() + "?root=" + root;
            bvGrid.showEditWindow(url, 680, 150, EIDSS.BvMessages['titleCreateSample'], "L35");
        },

        saveCreateSample: function () {
            bvGrid.saveWithoutCloseEditWindow('Grid', bvUrls.getSetLaboratoryCreateSampleUrl(), function() {
                var label = $("#lblAddMessage");
                label.removeClass("invisible");
            });
        },

        GroupAccessionIn: function (url1) {
            var root = $("#ID").val();
            var url = bvUrls.getLaboratoryGroupAccessionInPickerUrl() + "?root=" + root;
            bvGrid.showEditWindow(url, 680, 150, EIDSS.BvMessages['titleGroupAccessionIn'], "L36");
        },

        saveGroupAccessionIn: function () {
            bvGrid.saveWithoutCloseEditWindow('Grid', bvUrls.getSetLaboratoryGroupAccessionInUrl(), function() {
                var label = $("#lblAddMessage");
                label.removeClass("invisible");
            });
        },

        Details: function (id) {
            var root = $("#ID").val();
            var url = bvUrls.getLaboratoryDetailsPickerUrl() + "?root=" + root + "&id=" + id;
            bvGrid.showEditWindow(url, 680, 150, EIDSS.BvMessages['tabTitleSampleTest']);
        },

        saveDetails: function () {
            bvGrid.saveAndCloseEditWindow('Grid', bvUrls.getSetLaboratoryDetailsUrl());
        },

        Delete: function (id) {
            var root = $("#ID").val();
            var url = bvUrls.getLaboratoryDeleteUrl() + "?root=" + root + "&id=" + id;
            $.ajax({
                url: url,
                dataType: "json",
                type: "POST",
                data: {
                    root: root,
                    id: id
                },
                success: function (data) {
                    bvGrid.reloadById('Grid');
                },
                error: function () {
                }
            });
        },

        DeleteSample: function (root, idents) {
            bvDialog.showDeleteRecordPrompt(function () {
                laboratory.doSampleDelete(root, idents);
            });
        },

        doSampleDelete: function (root, idents) {
            var url = bvUrls.getLaboratorySampleDeleteUrl();
            $.ajax({
                url: url,
                dataType: "json",
                type: "POST",
                data: {
                    root: root,
                    ids: idents
                },
                success: function (data) {
                    bvGrid.reloadById('Grid');
                },
                error: function () {
                }
            });
        },


        resizeTable: function () {
            var width = $(".listForm").width() - 34;
            $("#Grid")[0].style.width = width.toString() + "px";
            $("#Grid").css({ "min-width": width.toString() + "px" });
            $("#Grid").css({ "max-width": width.toString() + "px" });
        },


        onDetailsClick: function (selectedItem) {
            $(selectedItem).parent().find(".openArrow,.closeArrow,.laboratoryDetailsContent").toggle();
        },


        SampleReport: function (root, idents) {
            detailPage.onShowReportClick(function() {
                var url = bvUrls.getLaboratorySampleReportUrl() + "?id=" + idents;
                detailPage.openReport(url);
            });
        },

        TestResultReport: function (root, idents) {
            detailPage.onShowReportClick(function () {
                var url = bvUrls.getLaboratoryTestResultReportUrl() + "?root=" + root + "&ids=" + idents;
                detailPage.openReport(url);
            });
        },

        SampleDestructionReport: function (root, idents) {
            detailPage.onShowReportClick(function () {
                var url = bvUrls.getLaboratorySampleDestructionReportUrl() + "?id=" + idents;
                detailPage.openReport(url);
            });
        },

        PrintBarcode: function (root, idents) {
            var url = bvUrls.getLaboratoryPrintBarcodeUrl() + "?root=" + root + "&ids=" + idents;
            detailPage.openReport(url);
        },


        ViewCaseOrSession: function (idfHumanCase, idfVetCase, idfMonitoringSession, idfVectorSurveillanceSession) {
            var url = "";
            if (idfHumanCase > 0)
                url = bvUrls.getHumanCaseDetailsUrl() + "?id=" + idfHumanCase;
            else if (idfVetCase > 0)
                url = bvUrls.getVetCaseDetailsUrl() + "?id=" + idfVetCase;
            else if (idfMonitoringSession > 0)
                url = bvUrls.getAsSessionDetailsUrl() + "?id=" + idfMonitoringSession + "&isret=0";
            else if (idfVectorSurveillanceSession > 0)
                url = bvUrls.getVsSessionDetailsUrl() + "?id=" + idfVectorSurveillanceSession;

            bvWindow.show(url, " ");
        },

        ViewCaseOrSessionByCode: function () {
            var id = $("input[id='LaboratorySectionItem']").val();
            var idfCaseOrSession = $("input[id='LaboratorySectionItem_" + id + "_idfCaseOrSession']").val();
            var idfsCaseType = $("input[id='LaboratorySectionItem_" + id + "_idfsCaseType'" + "]").val();
            var idfMonitoringSession = $("input[id='LaboratorySectionItem_" + id + "_idfMonitoringSession'" + "]").val();
            var url = "";
            if (idfsCaseType == 10012001) { // human
                url = bvUrls.getHumanCaseDetailsUrl() + "?id=" + idfCaseOrSession;
            }
            if (idfsCaseType == 10012006) { // vector
                url = bvUrls.getVsSessionDetailsUrl() + "?id=" + idfCaseOrSession;
            }
            if (idfsCaseType == 10012004) { // avian
                url = bvUrls.getVetCaseDetailsUrl() + "?id=" + idfCaseOrSession;
            }
            if (idfsCaseType == 10012003) { // livestock or assession
                if (idfMonitoringSession != "") { // assession
                    url = bvUrls.getAsSessionDetailsUrl() + "?id=" + idfMonitoringSession + "&isret=0";
                } else { // livestock
                    url = bvUrls.getVetCaseDetailsUrl() + "?id=" + idfCaseOrSession;
                }
            }
            if (url != "") {
                bvWindow.show(url, " ");
            }
        },

    };
    
})();
