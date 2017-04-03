function SelectGridRow(gridName, rowNum) {
    var firstRow = $("#" + gridName + " tr:eq(" + rowNum + ")");
    if (firstRow && firstRow.find('input').length > 0) {
        firstRow.addClass("selected");
        firstRow.find('input:radio').attr("checked", "checked");
    }
}

function SelectGridRowByRadioButton(gridName, radioButton) {
    var selectedRow = $("#" + gridName + " tr.selected");
    selectedRow.removeClass("selected");
    selectedRow.find('input:radio').removeAttr("checked");
    $(radioButton).attr("checked", "checked");
    $(radioButton).parent().parent().addClass("selected");
}

function GetSelectGridItemId(gridName) {
    var rb = GetCheckedGridRadioButton(gridName);
    var selectedRow = rb.parent().parent();    
    var id = selectedRow.find('input:hidden').val();
    return id;
}

function SelectGridRadioButtonByRowNum(gridName, rowNum) {
    var firstRow = $("#" + gridName + " tr:eq(" + rowNum + ")");
    if (firstRow && firstRow.find('input').length > 0) {
        firstRow.find('input:radio').attr("checked", "checked");
    }
}

function SelectGridRadioButton(gridName, radioButton) {
    var rb = GetCheckedGridRadioButton(gridName);
    rb.removeAttr("checked");           
    $(radioButton).attr("checked", "checked");    
}

function GetCheckedGridRadioButton(gridName) {
    var rb = $("#" + gridName + " tr input:radio").filter(":checked");
    return rb;
}