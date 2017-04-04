var ffGrid = {
    selectedRowClassName: "state-selected",
    disabledButtonClassName: "k-state-disabled",

    showEditDialog: function (gridId, isNewRow, title, idObservation, idfRow) {
        if (isNewRow) {
            idfRow = -1;
        }
        var index = gridId.indexOf("_");
        var idfsSection = gridId.substring(index + 1, gridId.length);
        var ffKey = $("#FFKey").val();
        var url = bvUrls.getEditFlexibleFormTableRowUrl({idfsSection: idfsSection, isNew: isNewRow, idfRow: idfRow, key: ffKey, ffpresenterId: idObservation});
        bvGrid.showEditWindow(url, 730, 460, title, "C20");
    },

    saveAndClosePopUp: function (parentGridName) {
        var contentData = bvPopup.getDefaultWindowData();
        var postUrl = bvPopup.getFormActionUrl(bvPopup.defaultName);
        $.ajax({
            url: postUrl,
            type: "POST",
            data: contentData,
            success: function (data) {
                if (parentGridName.length) {
                    bvPopup.closeDefaultPopup();
                    ffGrid.reload(parentGridName, data);
                    return;
                    /*
                    if (data.indexOf("</div>") < 0)
                        bvDialog.showError(data);
                    else {
                        bvPopup.closeDefaultPopup();
                        ffGrid.reload(parentGridName, data);
                        return;
                    }
                    */
                }
                if (data == 'ok') {
                    bvPopup.closeDefaultPopup();
                } else {
                    bvDialog.showError(data);
                }
            },
            error: function (a, b, c) {
                bvDialog.showError("Error");
            }
        });
    },

    deleteRow: function (gridId, idObservation, idfRow) {
        if ($("#btDelete_" + gridId).hasClass(ffGrid.disabledButtonClassName)) {
            return;
        }
        var index = gridId.indexOf("_");
        var idfsSection = gridId.substring(index + 1, gridId.length);
        var ffKey = $("#FFKey").val();
        var url = bvUrls.getDeleteFlexibleFormTableRowUrl({ idfsSection: idfsSection, idfRow: idfRow, key: ffKey, ffpresenterId: idObservation});
        $.ajax({
            type: 'POST',
            url: url,
            success: function (data) {
                ffGrid.reload(gridId, data);
            }
        });
    },

    reload: function (gridId, data) {
        var idfRow = $("#" + gridId + " ." + ffGrid.selectedRowClassName).attr('idfrow');
        // заменить html на результат запроса
        //$("#" + gridId).html(data);
        $("#placeholder_" + gridId).html(data);

        if (idfRow === undefined) {
            ffGrid.disableOnRowButtons(gridId);
            return;
        }
        var selectedRow = $("#" + gridId + " tr[idfRow=" + idfRow + "]");
        if(selectedRow.size() === 0){
            ffGrid.disableOnRowButtons(gridId);
            return;
        }
        $("#" + gridId + " tr[idfRow=" + idfRow + "] input[type='radio']").prop('checked', true);
        ffGrid.selectRow(selectedRow);
    },

    copyRow: function (gridId, idObservation) {
        var idfRow = $("#" + gridId + " ." + ffGrid.selectedRowClassName).attr('idfrow');
        if (idfRow === undefined) {
            return;
        }
        var index = gridId.indexOf("_");
        var idfsSection = gridId.substring(index + 1, gridId.length);
        var ffKey = $("#FFKey").val();
        var url = bvUrls.getCopyFlexibleFormTableRowUrl({ idfsSection: idfsSection, idfRow: idfRow, key: ffKey, ffpresenterId: idObservation });
        $.ajax({
            type: 'POST',
            url: url,
            success: function (data) {
                ffGrid.reload(gridId, data);
            }
        });
    },

    unSelectAllRows: function (gridId) {
        $("#" + gridId + " tr").removeClass(ffGrid.selectedRowClassName);
    },

    selectRow: function (row) {
        row.addClass(ffGrid.selectedRowClassName);
    },

    isRowSelected: function (row) {
        return row.hasClass(ffGrid.selectedRowClassName);
    },

    enableOnRowButtons: function (gridId) {
        var buttons = ffGrid.getOnRowButtons(gridId);
        ffGrid.enableButtons(buttons);
    },

    enableButtons: function (buttons) {
        if (buttons) {
            buttons.removeAttr('disabled');            
            buttons.removeClass(ffGrid.disabledButtonClassName);
        }
    },

    disableOnRowButtons: function (gridId) {
        var buttons = ffGrid.getOnRowButtons(gridId);
        ffGrid.disableButtons(buttons);
    },

    disableButtons: function (buttons) {
        if (buttons) {
            buttons.attr('disabled', 'disabled');
            buttons.addClass(ffGrid.disabledButtonClassName);
        }
    },

    getOnRowButtons:function(gridId) {
        var buttons = $("#placeholder_" + gridId).parent().find("button[data-role='grid-on-row-button']");
        return buttons;
    },

    onRowRadioButtonClick: function (gridName, button) {
        var buttonData = $(button);
        var selectedRow = buttonData.closest("tr");
        if (ffGrid.isRowSelected(selectedRow)) {
            return;
        }
        ffGrid.unSelectAllRows(gridName);
        ffGrid.selectRow(selectedRow);
        ffGrid.enableOnRowButtons(gridName);        
    }
};
