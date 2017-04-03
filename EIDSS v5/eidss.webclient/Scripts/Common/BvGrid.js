var serverTimeOffsetInHours = 0;

function bvGridNothing(e) {
}

function toServerTime(date) {
    if (date) {
        var utcDate = new Date(date.getUTCFullYear(), date.getUTCMonth(), date.getUTCDate(), date.getUTCHours(), date.getUTCMinutes(), date.getUTCSeconds(), date.getUTCMilliseconds());
        var serverOffset = serverTimeOffsetInHours * 60 * 60 * 1000;
        //alert('server offset: ' + serverTimeOffsetInHours);
        //alert('local offset: ' + (new Date()).getTimezoneOffset());
        var serverTime = new Date(utcDate.getTime() + serverOffset);
        return $.telerik.formatString("{0:d}", serverTime);
    }
}

function bvGridOnRowDataBound(e) {

    if (e.dataItem.ErrorMessage != null) {
        ShowEidssErrorNotification(e.dataItem.ErrorMessage, function () { });
        e.dataItem.ErrorMessage = null;
    }

}

function bvGridOnLoad(e, isReadOnly, isToolBarBtnsDisable) {    
    if (isReadOnly.toLowerCase() == "true") {
        DisableGrid(e.target.id);
    }
    else if (isToolBarBtnsDisable.toLowerCase() == "true") {
        DisableToolBarButtons(e.target.id);
    }
}

function bvGridOnDelete(e, key, name, isAutoDisabledBtns) {
    var url = '/' + currentLang + '/System/TryDeleteFromGrid';
    var bPreventDefault = false;
    var id = -1;
   
    if (e.dataItem) {
        id = e.dataItem.ItemKey;
    }
    else {
        var ii = GetBvGridSelectedItemId(e.currentTarget.id);
        if (!parseInt(ii))
            id = $(ii).val();        
    }

    $.ajax({
        url: url,
        cache: false,
        dataType: "json",
        type: "GET",
        async: false,
        data: {
            key: key,
            name: name,
            id: id
        },
        success: function (data) {
            var err = false;
            if (data && data.Values) {
                for (att in data.Values) {
                    if (data.Values[att].typeName == "ErrorMessage") {
                        err = true;
                    }
                }
            }
            if (err) {
                ApplyChanges(data);
                bPreventDefault = true;
                //$('#' + e.currentTarget.id).data('tGrid').editing.confirmDelete = false;
            }
            else {
                //SelectFirstGridRow(e.target.id, isAutoDisabledBtns.toLowerCase() == "true");
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            if (textStatus == 'parsererror') {
                ShowEidssErrorNotification(EIDSS.BvMessages['ErrAuthentication'], function () { });
            }
        }
    });

    if (bPreventDefault)
        e.preventDefault();
}

function bvGridOnDeleteAndApplyChanges(e, key, name, isAutoDisabledBtns) {
    var url = '/' + currentLang + '/System/TryDeleteFromGridAndCompare';

    ShowEidssYesNoDialog(
            EIDSS.BvMessages['msgConfimation'],
            EIDSS.BvMessages['msgDeleteRecordPrompt'],
            function () {
                $.ajax({
                    url: url,
                    cache: false,
                    dataType: "json",
                    type: "GET",
                    async: false,
                    data: {
                        key: key,
                        name: name,
                        id: e.dataItem.ItemKey
                    },
                    success: function (data) {
                        ApplyChanges(data);
                        $('#' + e.target.id).data('tGrid').ajaxRequest();
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        if (textStatus == 'parsererror') {
                            ShowEidssErrorNotification(EIDSS.BvMessages['ErrAuthentication'], function () { });
                        }
                    }
                });
            },
            DoNothing);


    e.preventDefault();
}

function bvGridOnDataBound(e, isAutoDisabledBtns) {
    SelectFirstGridRow(e.target.id, isAutoDisabledBtns.toLowerCase() == "true");
}

function OpenGridEditWindow(e, path, windowWidth, windowHeigth, title) {
    var request = path;
    if (e.dataItem == null) {
        request = request + '0';
    }
    else {
        request = request + e.dataItem.ItemKey;
    }
    ShowMessageWindow(request, windowWidth, windowHeigth, title, false);
}

function CloseEditWindowAndUpdateGrid(gridId, postUrl) {
    var contentData = $("#Message .t-window-content form").serialize(true);
    $.ajax({
        url: postUrl,
        cache: false,
        dataType: "json",
        //contentType: "application/json; charset=utf-8",
        type: "POST",
        data: contentData,
        success: function (data) {
            var err = false;
            if (data && data.Values) {
                for (att in data.Values) {
                    if (data.Values[att].typeName == "ErrorMessage") {
                        err = true;
                    }
                } 
            }
            if (err) {
                ApplyChanges(data);
            }
            else {
                CloseMessageWindow();
                $('#' + gridId).data('tGrid').ajaxRequest();
            }
        },
        error: function () {
            CloseMessageWindow();
            $('#' + gridId).data('tGrid').ajaxRequest();
        }
    });
}

function CloseEditWindowAndUpdateGridAndApplyChanges(gridId, postUrl) {
    var contentData = $("#Message .t-window-content form").serialize(true);
    $.ajax({
        url: postUrl,
        cache: false,
        dataType: "json",
        //contentType: "application/json; charset=utf-8",
        type: "POST",
        data: contentData,
        success: function (data) {
            var err = false;
            if (data && data.Values) {
                for (att in data.Values) {
                    if (data.Values[att].typeName == "ErrorMessage") {
                        err = true;
                    }
                }
            }
            ApplyChanges(data);
            if (!err) {
                CloseMessageWindow();
                $('#' + gridId).data('tGrid').ajaxRequest();
            }
        },
        error: function () {
            CloseMessageWindow();
            $('#' + gridId).data('tGrid').ajaxRequest();
        }
    });
}

function ClearSelection(e, gridId) {
    if ($("#grid_selecteditem")) {
        $("#grid_selecteditem").val("");
    }
    onSearchResultGridLoad(null, gridId);
}

function onSearchResultGridLoad(e, gridId) {
    if (!gridId) {
        gridId = "Grid";
    }
    if (!$("#" + gridId)) { return; }
    $("#Grid tbody>tr").click(function () {
        var idTd = $(this).find(".gridId");
        if (idTd.length == 1) {
            var id = idTd[0].innerHTML;
            if ($("#grid_selecteditem")) {
                $("#grid_selecteditem").val(id);
            }
        }
    });
    if ($("#NeedsFirstRowSelection").val() == "0") {
        SelectFirstSearchResultGridRow(gridId);
    }
    else {
        SelectGridRowByIndex("Grid", $("#NeedsFirstRowSelection").val());
        $("#NeedsFirstRowSelection").val("0");
    }
}

function SelectGridRow(gridId, rowIndex) {
    if (!gridId) {
        gridId = "Grid";
    }
    var grid = $("#" + gridId).data('tGrid');
    var row = grid.$rows()[rowIndex];
    if (row.cells.length > 1) {
        row.className = 't-state-selected';
        var id = $("#" + gridId + " tr.t-state-selected").find("[name='id']").attr('value');
        if (!id) {
            var idTd = $("#" + gridId + " tr.t-state-selected td.gridId");
            if (idTd.length == 1) {
                id = idTd[0].innerHTML;
            }
        }
        if ($("#grid_selecteditem")) {
            $("#grid_selecteditem").val(id);
        }
    }
    else {
        row.className = '';
        if ($("#grid_selecteditem")) {
            $("#grid_selecteditem").val("");
        }
    }
}

function SelectFirstSearchResultGridRow(gridId) {
    SelectGridRow(gridId, 0);
}

function GetBvGridSelectedItemId(gridId) {
    if (!gridId) {
        gridId = "Grid";
    }
    if ($("#" + gridId + " tr.t-state-selected").length == 0) {
        return "";
    }
    var id = $("#" + gridId + " tr.t-state-selected").find("[name='id']").attr('value');
    if (!id) {
        var idTd = $("#" + gridId + " tr.t-state-selected td.gridId");
        if (idTd.length == 1) {
            id = idTd[0].innerHTML;
        }
    }
    return id;
}

function DisableGrid(gridId) {
    var grid = $("#" + gridId);
    if (!grid) { return; }
    grid.attr('disabled', 'disabled');
    DisableToolBarButtons(gridId);
}

function EnableGrid(gridId) {
    var grid = $("#" + gridId);
    if (!grid || grid.length == 0) { return; }
    grid.removeAttr('disabled');
    var selection = $("#" + gridId + " tr.t-state-selected");
    if (selection.length == 0 || selection[0].cells.length <= 1) {
        DisableToolBarButtons(gridId);
        EnableToolBarAddButton(gridId);
        EnableToolBarAllwaysEnabledButtons(gridId);
    }
    else {
        EnableToolBarButtons(gridId);
    }
}

function SelectFirstGridRow(gridId, isAutoDisabledBtns) {
    var grid = $("#" + gridId).tGrid('tGrid').data('tGrid');
    if (!grid) { return; }
    var isGridEnable = !$("#" + gridId)[0].disabled;
    var firstRow = grid.$rows()[0];    
    if (firstRow.cells.length > 1) {
        firstRow.className = 't-state-selected';
        if (isGridEnable && !isAutoDisabledBtns) {
            EnableToolBarButtons(gridId);
        }    
    }
    else {
        firstRow.className = '';
        if (isGridEnable && isAutoDisabledBtns) {
            DisableToolBarButtons(gridId);
        }
        if (isGridEnable && !isAutoDisabledBtns) {
            DisableToolBarEditButton(gridId);
            DisableToolBarDeleteButton(gridId);
        }
    }
}

function SelectGridRowByIndex(gridId, rowIndex) {
    var grid = $("#" + gridId).tGrid('tGrid').data('tGrid');
    if (!grid) { return; }
    if (grid.$rows().length <= rowIndex) { return; }
    var selection = $("#" + gridId + " tr.t-state-selected");
    selection.removeClass("t-state-selected");
    var row = grid.$rows()[rowIndex];
    if (row.cells.length > 1) {
        row.className = 't-state-selected';
        var table = $("#" + gridId + " .t-grid-content table");
        var selectedRow = table.find('tr').eq(+rowIndex);
        var scrollableContent = $("#" + gridId + " .t-grid-content");
        scrollableContent.scrollTop(selectedRow.offset().top - (scrollableContent.height()));
        SelectGridRow(gridId, rowIndex);
    }    
}

function DisableToolBarButtons(gridId) {
    var toolbarButtons = $("#" + gridId + " a.t-button");
    DisableGridButton(toolbarButtons);
}

function EnableToolBarAllwaysEnabledButtons(gridId) {
    var toolbarButtons = $("#" + gridId + " a.t-button.t-state-enabled");
    EnableGridButton(gridId, toolbarButtons);
}

function EnableToolBarButtons(gridId) {
    var toolbarButtons = $("#" + gridId + " a.t-button");
    EnableGridButton(gridId, toolbarButtons);
}

function EnableToolBarAddButton(gridId) {
    var addButton = $("#" + gridId + " a.t-grid-add");
    EnableGridButton(gridId, addButton);
}

function DisableToolBarAddButton(gridId) {
    var addButton = $("#" + gridId + " a.t-grid-add");
    DisableGridButton(addButton);
}

function EnableToolBarEditButton(gridId) {
    var editButton = $("#" + gridId + " a.t-grid-edit");
    EnableGridButton(gridId, editButton);
    editButton = $("#" + gridId + " a.t-grid-bv-edit");
    EnableGridButton(gridId, editButton);
}

function DisableToolBarEditButton(gridId) {
    var editButton = $("#" + gridId + " a.t-grid-edit");
    DisableGridButton(editButton);
    editButton = $("#" + gridId + " a.t-grid-bv-edit");
    DisableGridButton(editButton);
}

function EnableToolBarDeleteButton(gridId) {
    var deleteButton = $("#" + gridId + " a.t-grid-delete");
    EnableGridButton(gridId, deleteButton);
}

function DisableToolBarDeleteButton(gridId) {
    var deleteButton = $("#" + gridId + " a.t-grid-delete");
    DisableGridButton(deleteButton);
}

function DisableGridButton(button) {
    if (button) {
        button.attr('disabled', 'disabled');
        button.addClass('t-state-disabled');
    }
}

function EnableGridButton(gridId, button) {
    if (button) {
        if (!($("#" + gridId).attr("disabled"))) {
            button.removeAttr('disabled');
            button.removeClass('t-state-disabled');
        }
    }
}

function SearchLineInGrid(gridId, columnNumber, searchTextBoxId, notFoundMessageKey) { // columnNumber starting with 1    
    var searchText = $("#" + searchTextBoxId).val();
    var tdArr = $("#" + gridId + " .t-grid-content table tr td:nth-child(" + columnNumber + ')');
    var found = false;
    tdArr.each(function (index, td) {
        var cellText = $(td).text();
        if (cellText == searchText) {
            SelectGridRowByIndex(gridId, index);
            found = true;
            return false;
        }
    });
    if (!found) {
        ShowEidssErrorNotification(EIDSS.BvMessages[notFoundMessageKey], function () { });
    }
}

function onFFGridRowSelected(e) {
    var gridId = e.target.id;
    $("#" + gridId + " tr").removeClass("t-state-selected");
    if (e.row.cells.length > 1) {
        $(e.row).parent().parent().parent().parent().addClass("t-state-selected");
        EnableGridButton(gridId, $("#btEdit_" + gridId));
        EnableGridButton(gridId, $("#btCopy_" + gridId));
        EnableGridButton(gridId, $("#btDelete_" + gridId));
    }
}

function EditFFGridRow(gridId, isNew, title) {
    var idfRow;
    if (isNew === 'false') {
        if ($("#btEdit_" + gridId).hasClass('t-state-disabled')) {
            return;
        }
        idfRow = $("#" + gridId + " tr.t-state-selected table").attr('idfrow');
    }
    if (!idfRow) {
        idfRow = "-1";
    }
    var index = gridId.indexOf("_");
    var idfsSection = gridId.substring(index + 1, gridId.length);
    var ffKey = $("#FFKey").val();
    var ffpresenterId = $("#FFpresenterId").val();
    var lang = GetSiteLanguage();
    var postUrl = "/FlexForms/FFPresenter/EditTableRow?idfsSection=" + idfsSection + "&isNew=" + 
        isNew + "&idfRow=" + idfRow + "&key=" + ffKey + "&ffpresenterId=" + ffpresenterId;
    var url = "/" + lang + postUrl;
    ShowMessageWindow(url, 950, 650, title);   
}

function onEditFFGridRowComplete(idfsSection, ffKey, ffpresenterId) {
    $('.popupContent form').ajaxSubmit(function (data) {
        if (data == 'ok') {
            $('#Message').data('tWindow').close();
            var gridId = 'idfsSection_' + idfsSection;
            ReloadFFGridData(gridId, idfsSection, ffKey, ffpresenterId);
        }
        else
            ShowEidssErrorNotification(data, function () { });
    });
}

function DeleteFFGridRow(gridId) {
    if ($("#btDelete_" + gridId).hasClass('t-state-disabled')) {
        return;
    }
    var idfRow = $("#" + gridId + " tr.t-state-selected table").attr('idfrow');
    var index = gridId.indexOf("_");
    var idfsSection = gridId.substring(index + 1, gridId.length);
    var ffKey = $("#FFKey").val();
    var ffpresenterId = $("#FFpresenterId").val();
    var lang = GetSiteLanguage();
    var postUrl = "/FlexForms/FFPresenter/RemoveTableRow?idfsSection=" + idfsSection + "&idfRow=" + idfRow + "&key=" + ffKey + "&ffpresenterId=" + ffpresenterId;
    var url = "/" + lang + postUrl;
    $.ajax({
        type: 'GET',
        url: url,
        success: function () {
            ReloadFFGridData(gridId, idfsSection, ffKey, ffpresenterId);
        }
    });
}

function onCancelEditFFTableRow(isNew, idfsSection, idfRow, ffKey, ffpresenterId) {
    if (isNew == '0') {
        $('#Message').data('tWindow').close();
        return;
    }
    $('#Message').data('tWindow').close();
    var lang = GetSiteLanguage();
    var url = "/" + lang + "/FlexForms/FFPresenter/RemoveTableRow?idfsSection=" + idfsSection + "&idfRow=" + idfRow + "&key=" + ffKey + "&ffpresenterId=" + ffpresenterId;
    $.ajax({
        type: 'GET',
        url: url
    });
}

function CopyFFGridRow(gridId) {
    if ($("#btCopy_" + gridId).hasClass('t-state-disabled')) {
        return;
    }
    var idfRow = $("#" + gridId + " tr.t-state-selected table").attr('idfrow');
    var index = gridId.indexOf("_");
    var idfsSection = gridId.substring(index + 1, gridId.length);
    var ffKey = $("#FFKey").val();
    var ffpresenterId = $("#FFpresenterId").val();
    var lang = GetSiteLanguage();
    var postUrl = "/FlexForms/FFPresenter/CopyTableRow?idfsSection=" + idfsSection + "&idfRow=" + idfRow + "&key=" + ffKey + "&ffpresenterId=" + ffpresenterId;
    var url = "/" + lang + postUrl;
    $.ajax({
        type: 'GET',
        url: url,
        success: function () {
            ReloadFFGridData(gridId, idfsSection, ffKey, ffpresenterId);
        }
    });
}

function ReloadFFGridData(gridId, idfsSection, ffKey, ffpresenterId) {
    var postUrl = "/FlexForms/SectionTemplate/SectionTemplateTableNodeRender?idfsSection=" + idfsSection +
                "&key=" + ffKey + "&ffpresenterId=" + ffpresenterId;
    var lang = GetSiteLanguage();
    url = "/" + lang + postUrl;
    $.ajax({
        type: 'GET',
        url: url,
        success: function (result) {
            $("#idfsSection_" + idfsSection + " .t-grid-content > table > tbody").html($(result).find(".t-grid-content > table > tbody")[0].innerHTML);
            SelectFirstFFGridRow(gridId);
        }
    });
}

function SelectFirstFFGridRow(gridId) {
    var grid = $("#" + gridId).tGrid('tGrid').data('tGrid');
    if (!grid) { return; }
    var firstRow = grid.$rows()[0];
    if ($(firstRow).find("table").length > 0) {
        firstRow.className = 't-state-selected';
        EnableGridButton(gridId, $("#btEdit_" + gridId));
        EnableGridButton(gridId, $("#btCopy_" + gridId));
        EnableGridButton(gridId, $("#btDelete_" + gridId));
    }
    else {
        firstRow.className = '';
        DisableGridButton($("#btEdit_" + gridId));
        DisableGridButton($("#btCopy_" + gridId));
        DisableGridButton($("#btDelete_" + gridId));
    }
}
