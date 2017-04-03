function onCaseSummaryLoad() {
    UpdateAggregateCaseButtonsState();
}

function CloseCaseSummary() {
    var lang = GetSiteLanguage();
    ActionClose('/' + lang + '/Account/Home');
}

function onAreaTypeChange(e) {
    var cbAreaTypeId = e.currentTarget.id;
    var cbAreaType = $("#" + cbAreaTypeId).data("tComboBox");
    var previousValue = cbAreaType.previousValue;
    if (previousValue == e.value) {
        return;
    }
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/CommonAggregate/AreaType_OnChange?previousValue=" + previousValue + "&newValue=" + e.value;
    $.getJSON(postUrl, null, function (result) {
        if (result.cansel) {
            cbAreaType.dataBind(cbAreaType.data, true);
            cbAreaType.value(previousValue);
        }
    });  
    UpdateAggregateCaseButtonsState();
}

function onPeriodTypeChange(e) {
    var cbPeriodTypeId = e.currentTarget.id;
    var cbPeriodType = $("#" + cbPeriodTypeId).data("tComboBox");
    var previousValue = cbPeriodType.previousValue;
    if (previousValue == e.value) {
        return;
    }
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/CommonAggregate/PeriodType_OnChange?previousValue=" + previousValue + "&newValue=" + e.value;
    $.getJSON(postUrl, null, function (result) {
        if (result.cansel) {
            cbPeriodType.dataBind(cbPeriodType.data, true);
            cbPeriodType.value(previousValue);
        }
    });  
    UpdateAggregateCaseButtonsState();
}

function UpdateAggregateCaseButtonsState(curWindow) {
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
    }
    else {
        curWindow.$('#btEdit').attr('disabled', 'disabled');
        curWindow.$('#btRemove').attr('disabled', 'disabled');
        curWindow.$('#btRemoveAll').attr('disabled', 'disabled');
    }
    var areaType = curWindow.$('#cbAreaType').data('tComboBox').selectedIndex;
    var periodType = curWindow.$('#cbPeriodType').data('tComboBox').selectedIndex;
    if (areaType >= 0 && periodType >= 0) {
        curWindow.$('#btSelect').removeAttr('disabled');
        curWindow.$('#btnShowSummaryInfo').removeAttr('disabled');        
    }
    else {
        curWindow.$('#btSelect').attr('disabled', 'disabled');
        curWindow.$('#btnShowSummaryInfo').attr('disabled', 'disabled');
    }
    curWindow.$('#btnShowReport').attr('disabled', 'disabled');
}

function ShowAggregateCaseItemEditor(path, isNew, title) {
    var itemId = 0;
    if (!isNew) {
        itemId = GetBvGridSelectedItemId("AggregateCaseGrid");
    }
    var url = path + "?id=" + itemId;
    OpenPopup(url, title);
}

function SaveAggregateCase(controllerName, idfAggrCase, isNewCase) {
    var contentData = $("#Message .t-window-content form").serialize(true);
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/" + controllerName + "/SaveAggregateCase";
    $.ajax({
        url: postUrl,
        cache: false,
        dataType: "json",
        type: "POST",
        data: contentData,
        success: function (result) {
            if (!result) {
                CloseMessageWindow();
                if (isNewCase.toString().toLowerCase() == 'false') {
                    UpdateAggregateCaseInGrid(idfAggrCase);
                }
            }
            else {
                ShowEidssErrorNotification(result, function () { });
            }
        },
        error: function (error) {
            CloseMessageWindow();
        }
    });
}

function UpdateAggregateCaseInGrid(idfAggrCase, curWindow) {
    var areaType = curWindow.$('#cbAreaType').data('tComboBox').value();
    var periodType = curWindow.$('#cbPeriodType').data('tComboBox').value();
    if (!areaType || !periodType) {
        return;
    }
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/CommonAggregate/UpdateSelectedAggregateCaseItem?selectedItem=" + idfAggrCase +
        "&reportAreaType=" + areaType + "&reportPeriodType=" + periodType;
    $.ajax({
        url: postUrl,
        cache: false,
        dataType: "json",
        type: "POST",
        async: false,
        success: function (result) {
            ChangeAggregateCaseGridData(result.data, result.total, curWindow);
            UpdateAggregateCaseButtonsState(curWindow);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(jqXHR.status);
        }
    });
}

function IsNewAggrCase(idfAggrCase, curWindow) {
    if (!curWindow) {
        curWindow = window;
    }
    var tdArr = curWindow.$("#AggregateCaseGrid .t-grid-content table tr td.gridId");
    var found = false;
    tdArr.each(function (index, td) {
        var cellText = $(td).text();
        if (cellText == idfAggrCase) {
            found = true;
            return false;
        }
    });
    return !found; 
}

function ShowAggregateCaseItemPicker(path, title) {
    var areaType = $('#cbAreaType').data('tComboBox').value();
    var periodType = $('#cbPeriodType').data('tComboBox').value();
    if (areaType >= 0 && periodType >= 0) {
        var url = path + "?reportAreaType=" + areaType + "&reportPeriodType=" + periodType;
        ShowSearchPicker(url, title);        
    }
}

function onAggregateCasePickerSearchAndOrder(url) {
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + url;
    SearchItemsAndUpdateGrid(postUrl, "Message");
    SelectFirsSearchPickerResultGridRow();
}

function onAggregateCaseItemPickerSelect(selectAll) {
    var areaType = $('#hdnReportAreaType').val();
    var periodType = $('#hdnReportPeriodType').val();    
    var selectedItems;       
    if (selectAll) {
        selectedItems = GetAllFilteredItemIds();
    }
    else {
        selectedItems = GetCheckedItemIds();
    }
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/CommonAggregate/AddSelectedAggregateCaseItems?selectedItems=" + selectedItems +
        "&reportAreaType=" + areaType + "&reportPeriodType=" + periodType;
    $.getJSON(postUrl, null, function (result) {
        if (result.isValid) {
            ChangeAggregateCaseGridData(result.data, result.total);
            UpdateAggregateCaseButtonsState();
            CloseMessageWindow();
        }
        else {
            ShowEidssErrorNotification(result.error, function () { });
        }
    });
}

function onRemoveAggrCaseButtonClick() {
    var selectedId = GetBvGridSelectedItemId("AggregateCaseGrid");
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/CommonAggregate/RemoveAggregateCaseItem?selectedId=" + selectedId;
    $.getJSON(postUrl, null, function (result) {
        ChangeAggregateCaseGridData(result.data, result.total);      
        UpdateAggregateCaseButtonsState();        
    });
}

function onRemoveAllAggrCasesButtonClick() {
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/CommonAggregate/RemoveAllAggregateCaseItems";
    $.getJSON(postUrl, null, function (result) {
        ChangeAggregateCaseGridData(result.data, result.total);
        UpdateAggregateCaseButtonsState();        
    });
}

function ChangeAggregateCaseGridData(data, total, curWindow) {
    if (!curWindow) {
        curWindow = window;
    }
    var grid = curWindow.$("#AggregateCaseGrid").data('tGrid');
    grid.total = total;
    grid.dataBind(data);
}

function onShowAggregateCaseSummaryReport() {
    var areaType = $('#cbAreaType').data('tComboBox').value();
    var periodType = $('#cbPeriodType').data('tComboBox').value();
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/CommonAggregate/AggregateReport?reportAreaType=" + areaType + "&reportPeriodType=" + periodType;
    window.location = url;
}

function onShowSummaryInfo() {
    var gridId = "AggregateCaseGrid";
    var grid = $("#" + gridId).data('tGrid');
    var row = grid.$rows()[0];
    var isReportButtonEnabled = false;
    if (row.cells.length > 1) {
        isReportButtonEnabled = true;
    }
    ShowSummaryInfo(isReportButtonEnabled);
}

function ShowSummaryInfo(isReportButtonEnabled) {
    showLoading();
    $('#btnShowReport').attr('disabled', 'disabled');
    var lang = GetSiteLanguage();
    var postUrl = "/" + lang + "/CommonAggregate/SummaryFlexibleForm";
    $.getJSON(postUrl, null, function (result) {
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
