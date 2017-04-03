function ShowSearchPicker(pickerUrl, title) {
    ShowMessageWindow(pickerUrl, 950, 650, title, false);
}

function ShowInternalSearchPicker(pickerUrl, title) {    
    ShowInternalModalWindow("SearchPickerWindow", pickerUrl, 950, 650, title, false);    
}

function onSearchPickerResultGridLoad(e) {   
    if (!$("#Grid")) { return; }
    $("#Grid tbody>tr").click(function () {        
        var idTd = $(this).find(".gridId");
        if (idTd.length == 1) {
            var id = idTd[0].innerHTML;
            if ($("#grid_selecteditem")) {
                $("#grid_selecteditem").val(id);
            }
        }
    });   
    SelectFirsSearchPickerResultGridRow();
}

function SelectFirsSearchPickerResultGridRow() {
    var grid = $('#Grid').data('tGrid');
    var row = grid.$rows()[0];
    if (row.cells.length > 1) {
        row.className = 't-state-selected';
        var id = $("#Grid tr.t-state-selected").find("[name='id']").attr('value');
        if (!id) {
            var idTd = $("#Grid tr.t-state-selected td.gridId");
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

function onHideSearchPanel() {
    $(".popupContent div.mainSearchContent").removeClass("searchLeftIndent");
    $("#btHideSearch").hide();
    $("#btShowSearch").removeClass("invisible");
    $("#btShowSearch").show();
    $(".popupContent div.collapsePanel").removeClass("collapsePanelRight");
    $(".popupContent div.collapsePanel").addClass("collapsePanelRightCollapsed");
}

function onShowSearchPanel() {
    $(".popupContent div.mainSearchContent").addClass("searchLeftIndent");
    $("#btHideSearch").show();
    $("#btShowSearch").hide();
    $(".popupContent div.collapsePanel").removeClass("collapsePanelRightCollapsed");
    $(".popupContent div.collapsePanel").addClass("collapsePanelRight");
}

function onSearchPickerSelect(objectId, propertyName, setSelectedItemPostUrl) {
    var selectedItemId = GetSelectedItemId();
    onInlineItemPickerValueChanged(objectId, propertyName, setSelectedItemPostUrl, selectedItemId)
}

function onInlineItemPickerValueChanged(objectId, idfsPropertyName, strPropertyName, setSelectedItemPostUrl, selectedItemId) {
    $.ajax({
        url: setSelectedItemPostUrl,
        cache: false,
        type: "POST",
        data: {
            objectId: objectId,
            idfsPropertyName: idfsPropertyName,
            strPropertyName: strPropertyName,
            selectedItemId: selectedItemId            
        },
        datatype: "json",
        success: function (result) {
            ApplyChanges(result);
            CloseMessageWindow();            
        },
        error: function (data) {
        }
    });
}

function SearchItemsAndUpdateGrid(pickerUrl, windowId) {    
    var grid = $("#" + windowId + " .t-window-content .popupContent #Grid").tGrid('tGrid').data('tGrid');
    var contentData = $("#" + windowId + " .t-window-content form").serialize(true);   
    $.ajax({
        url: pickerUrl,
        cache: false,
        type: "POST",
        data: {
            formData: contentData            
        },
        datatype: "json",
        success: function (result) {
            grid.total = result.total;            
            grid.dataBind(result.data);
            var firstRow = grid.$rows()[0];
            if (firstRow.cells.length > 1) {
                firstRow.className = 't-state-selected';
                var id = $("#" + windowId + " .t-window-content .popupContent #Grid tr.t-state-selected").find("[name='id']").attr('value');
                if (!id) {
                    var idTd = $("#" + windowId + " .t-window-content .popupContent #Grid tr.t-state-selected td.gridId");
                    if (idTd.length == 1) {
                        id = idTd[0].innerHTML;
                    }
                    else {
                        id = '';
                    }
                }
                if ($("#grid_selecteditem")) {
                    $("#grid_selecteditem").val(id);
                }
            }
            else {
                firstRow.className = '';
                if ($("#grid_selecteditem")) {
                    $("#grid_selecteditem").val("");
                }
            }
            onSearchPickerResultGridLoad(null);
        },
        error: function (data) {
        }
    });
}

function GetSelectedItemId() {
    var id = GetBvGridSelectedItemId("Grid");    
    return id;
}

function onSearchPickerCheckBoxChange(checkBox, gridId) {
    $("#" + gridId + " tr.t-state-selected").removeClass("t-state-selected");
    var row = checkBox.parentElement.parentElement;
    row.className = 't-state-selected';
}

function onSearchPickerRowSelect(e) {    
    var checkBox = e.row.cells[0].getElementsByTagName('input');
    if (checkBox.length == 1 && checkBox[0].className == 'gridChB') {
        var checked = !checkBox[0].checked;
        checkBox[0].checked = checked;        
    }
}

function GetCheckedItemIds() {
    var checkedItems = $("#Grid input.gridChB:checked");
    if (checkedItems.length == 0) {
        return "";
    }
    var result = '';
    for (var i = 0; i < checkedItems.length; i++) {
        result += checkedItems[i].value + ';';
    }    
    if (result.length > 1) {
        result = result.substring(0, result.length - 1);
    }
    return result;
}

function GetAllFilteredItemIds() {   
    var grid = $("#Grid").data('tGrid');
    var rows = grid.$rows();
    var result = '';
    for (var i = 0; i < rows.length; i++) {
        var cellsCount = rows[i].cells.length;
        if (cellsCount > 1 && rows[i].cells[cellsCount - 1].className == 'gridId') {
            result += rows[i].cells[cellsCount - 1].innerHTML + ';';
        }
    }
    if (result.length > 1) {
        result = result.substring(0, result.length - 1);
    }
    return result;
}
