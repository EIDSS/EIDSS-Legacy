var vssession=
{
    redirectToVector: function (idfVector, name, deleteWhenCancel) {
        //deleteWhenCancel -- если 1, то открытый вектор будет удалён при нажатии Cancel детальной формы
        //так нужно при первом его открытии сразу после копирования
        var url = bvUrls.getVsStoreInSessionUrl();
        var contentData = $("form").serialize(true);
        $.ajax({
            url: url,
            dataType: 'json',
            type: 'POST',
            data: contentData,
            success: function (data) {
                var idSession = $("#idfVectorSurveillanceSession").val();
                //window.location = bvUrls.redirectToVectorUrl() + "?idfVectorSurveillanceSession=" + id + "&idfVector=" + idfVector;
                window.location = bvUrls.redirectToVectorUrl() + "?key=" + idSession + "&name=" + name + "&id=" + idfVector + "&deleteWhenCancel=" + deleteWhenCancel;
            }
        });
    },
    
    /*
    OnStatusChanged: function (idfsVectorSurveillanceStatus) {
        bvComboBox.onChanged(e);
    },
    */
    
    showSearchPicker: function (objectId, functionName, isMultiSelection, showInInternalWindow) {
        var pickerUrl = bvUrls.getVsSessionPickerUrl() + "?objectId=" + objectId + "&functionName=" + functionName + "&isMultiSelection=" + isMultiSelection + "&showInInternalWindow=" + showInInternalWindow;
        var title = EIDSS.BvMessages['titleVsSessionList'];
        if (showInInternalWindow.toLowerCase() != "true") {
            searchPicker.show(pickerUrl, title);
        } else {
            searchPicker.showInternal(pickerUrl, title);
        }
    },
    
    onVsSessionReportClick: function () {
        detailPage.onShowReportClick(vssession.showVsSessionReport);
    },

    showVsSessionReport: function () {
        var sessionId = $("#idfVectorSurveillanceSession").val();
        var url = bvUrls.getVsSessionReportUrl() + "?id=" + sessionId;
        detailPage.openReport(url);
    },

};

var vector =
{
    showVectorsGridEditWindow: function (id, listKey, gridName) {
        var url = bvUrls.redirectToVectorUrl() + "?key=" + listKey + "&name=" + gridName + "&id=" + id;
        var urlStore = bvUrls.getVsStoreInSessionUrl();
        var contentData = $("form").serialize(true);
        $.ajax({
            url: urlStore,
            dataType: 'json',
            type: 'POST',
            data: contentData,
            success: function () {
                actions.redirect(url);
            }
        });
    },
    
    vectorDetailOk: function () {
        var idSession = $("#idfVectorSurveillanceSession").val();
        var url = bvUrls.redirectToVectorUrl();
        var formData = $('form').formSerialize();
        $.ajax({
            url: url,
            type: "POST",
            data: formData,
            success: function (result) {
                if (formRefresher.hasError(result)) {
                    formRefresher.updateControls(result);
                } else {
                    ActionEditVsSessionRedirect(idSession);
                }
            }
            }
        );
    },
    
    vectorDetailCancel: function () {
        var idSession = $("#idfVectorSurveillanceSession").val();
        var deleteWhenCancel = $("#deleteWhenCancel").val();
        var id = $("#id").val();
        var listkey = $("#listkey").val();
        var name = $("#name").val();
        var type = "eidss.model.Schema.Vector VectorGridModelList";
        ActionEditVsSessionRedirect(idSession);
        if ((deleteWhenCancel != null) && (deleteWhenCancel == 1)) {
            bvGrid.doDeleteRow(id, listkey, name, type);
        }
    },
    
    onVectorTypeChangedSuccess: function (e) {
        comboBoxFacade.reloadReferenceComboBox(e, 'VectorSubType');
        comboBoxFacade.reloadReferenceComboBox(e, 'CollectionMethod');
        //vector.onTabSelect(null); // зачем это? есть договоренность, что ff-перезагружается только при переходе по вкладками. если нужно перезагружать ff при смене значения контрола, то нужно это делать по-другому
        var idSessionValue = $("#idfVectorSurveillanceSession").val();
        var idVectorValue = $("#idfVector").val();
        vector.reloadFFTab("MainTabStrip", 1, idSessionValue, idVectorValue);
        var url = bvUrls.getVectorIsPoolUrl();
        $.ajax({
            url: url,
            dataType: "json",
            type: "GET",
            data: {
                idVector: idVectorValue
            },
            success: function (data) {
                var label = $("#idfHostVector");
                if (label != null && label.length > 0) label.style.visibility = "hidden";
                var combo = $("#Vectors_" + idVectorValue + "_idfHostVector_input");
                if (combo != null && combo.length > 0) combo.style.visibility = "hidden";
            },
            error: function (a, b, c) {

            }
        });

    },

    onVectorTypeChanged: function (e) {
        formRefresher.setOnChangedSuccess(vector.onVectorTypeChangedSuccess, e);
        bvComboBox.onChanged.call(this, e);
    },
    
    onTabSelect: function (e, itemId, tabStripName) {
        var activeTabContentSelector = tabStripFacade.getActiveTabContentSelector(tabStripName);
        var eventArgs = tabStripFacade.getOnSelectEventArgs(e);
        var slectedTabIndex = eventArgs.slectedTabIndex;
        if ($(activeTabContentSelector + " #FlexForm").length == 1) {
            var contentData = $("form").serialize(true);
            var postUrl = bvUrls.getStoreVectorUrl();
            $.ajax({
                url: postUrl,
                dataType: "json",
                type: "POST",
                data: contentData,
                success: function (data) {
                    //vector.reloadFFTab(tabStripName, slectedTabIndex, idSession, idVector);
                }
            });
        } else {
            var idSession = $("#idfVectorSurveillanceSession").val();
            var idVector = itemId;
            vector.reloadFFTab(tabStripName, slectedTabIndex, idSession, idVector);
        }
    },
    
    reloadFFTab: function (tabStripName, tabIndex, idSession, idVector) {
        if (tabStripName != "MainTabStrip") return;
        if (tabIndex == 1) {
            showLoading();
            var url = bvUrls.getVectorFFUrl();
            flexForms.reloadFf(url, "FlexForm", idSession, idVector);
        }
    },
    
    copyVectorEditWindow: function (id, listKey, gridName) {
        if (id == 0) return;
        var url = bvUrls.getVectorCopyPickerUrl() + "?key=" + listKey + "&name=" + gridName + "&id=" + id;
        bvGrid.showEditWindow(url, 730, 320, EIDSS.BvMessages['titleCopyVector']);
        
    },
    
    saveAndCloseCopyVectorEditWindow: function (gridName) {
        
        var ident = gridName.substring(0, gridName.lastIndexOf("_") + 1);
        var gridId = ident + 'Vectors';
        bvGrid.saveAndCloseEditWindow(
            gridId
            , bvUrls.getSetVectorCopyUrl()
            , function (data) {
                for (var item in data.Values) {
                    var itemData = data.Values[item];
                    if (itemData.propertyName == "idVectorNew") {
                        vssession.redirectToVector(itemData.value, gridId, 1);
                        break;
                    }
                }
            }
        );
    }
    
};

var vectorsample =
{
    showVectorSampleGridEditWindow: function(id, listKey, gridName) {
        var url = bvUrls.getVectorSamplePickerUrl() + "?key=" + listKey + "&name=" + gridName + "&id=" + id;
        //TODO уточнить заголовок
        bvGrid.showEditWindow(url, 730, 320, EIDSS.BvMessages['titleSampleDetails']);
    },
    
    saveAndCloseVectorSampleGridEditWindow: function (gridName) {
        var ident = gridName.substring(0, gridName.lastIndexOf("_") + 1);
        var gridId = ident + 'Samples';
        bvGrid.saveAndCloseEditWindow(gridId, bvUrls.getSetVectorSampleUrl());
    }
};

var vectorlabtest =
{
    showAmendmentHistoryWindow: function (id, listKey, gridName) {
        var url = bvUrls.getVectorLabTestPickerUrl() + "?key=" + listKey + "&name=" + gridName + "&id=" + id;
        bvGrid.showEditWindow(url, 730, 320, EIDSS.BvMessages['titleAmendmentHistory']);
    },
};

var vectorfieldtest =
{
    showVectorFieldTestGridEditWindow: function (id, listKey, gridName) {
        var url = bvUrls.getVectorFieldTestPickerUrl() + "?key=" + listKey + "&name=" + gridName + "&id=" + id;
        bvGrid.showEditWindow(url, 730, 320, EIDSS.BvMessages['titleFieldTestDetails']);
    },

    saveAndCloseVectorFieldTestGridEditWindow: function (gridName) {
        var ident = gridName.substring(0, gridName.lastIndexOf("_") + 1);
        var gridId = ident + 'FieldTests';
        bvGrid.saveAndCloseEditWindow(gridId, bvUrls.getSetVectorFieldTestUrl());
    },
    
    onTestTypeChangedSuccess: function(e) {
        comboBoxFacade.reloadReferenceComboBox(e, 'TestResultFiltered');
        comboBoxFacade.reloadReferenceComboBox(e, 'DiagnosisFiltered');
    },

    onTestTypeChanged: function (e) {
        formRefresher.setOnChangedSuccess(vectorfieldtest.onTestTypeChangedSuccess, e);
        bvComboBox.onChanged.call(this, e);
    },
};

var vssessionsummary =
{
    showSummaryDiagnosisGridEditWindow: function (id, listKey, gridName) {
        var url = bvUrls.getVsSummaryDiagnosisPickerUrl() + "?key=" + listKey + "&name=" + gridName + "&id=" + id;

        /*
        // зачем сохранять данные в сессию, если нет перезагрузки окна? если это сделано для сохранения поля "Number of Pools/Vectors Collected", то это нужно делать по-другому (сохранение этого поля добавлено)

        var urlStore = bvUrls.getVsSummaryStoreUrl();
        var contentData = $("form").serialize(true);

        $.ajax({
            url: urlStore,
            dataType: 'json',
            type: 'POST',
            data: contentData
            //,success: function() {
            //actions.redirect(url);
            //}
        });
        
        */

        bvGrid.showEditWindow(url, 730, 320, EIDSS.BvMessages['titleDetectedDisease']);
    },
    
    saveAndCloseSummaryDiagnosisGridEditWindow: function (gridName) {
        var ident = gridName.substring(0, gridName.lastIndexOf("_") + 1);
        var gridId = ident + 'DiagnosisList';
        bvGrid.saveAndCloseEditWindow(gridId, bvUrls.getSetSummaryDiagnosisUrl());
    },
    
    RedirectToSummary: function (id, listKey, gridName) {
        var url = bvUrls.redirectToVsSessionSummaryUrl() + "?key=" + listKey + "&name=" + gridName + "&id=" + id;
        var urlStore = bvUrls.getVsStoreInSessionUrl();
        var contentData = $("form").serialize(true);
        $.ajax({
            url: urlStore,
            dataType: 'json',
            type: 'POST',
            data: contentData,
            success: function () {
                actions.redirect(url);
            }
        });
    },
    
    formDetailOk: function () {
        var idSession = $("#idfVectorSurveillanceSession").val();
        var url = bvUrls.redirectToVsSessionSummaryUrl();
        var formData = $('form').formSerialize();
        $.ajax({
            url: url,
            type: "POST",
            data: formData,
            success: function (result) {
                if (formRefresher.hasError(result)) {
                    formRefresher.updateControls(result);
                } else {
                    ActionEditVsSessionRedirect(idSession);
                }
            }
        }
        );
    },

    formDetailCancel: function () {
        var idSession = $("#idfVectorSurveillanceSession").val();
        ActionEditVsSessionRedirect(idSession);
    },
    
    onVectorTypeChangedSuccess: function (e) {
        comboBoxFacade.reloadReferenceComboBox(e, 'VectorSubType');
    },

    onVectorTypeChanged: function (e) {
        formRefresher.setOnChangedSuccess(vssessionsummary.onVectorTypeChangedSuccess, e);
        bvComboBox.onChanged.call(this, e);
    },
};
