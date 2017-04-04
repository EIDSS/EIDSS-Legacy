var gridFacade = (function () {
    var selectedRowClassName = "k-state-selected";
    var selectedItems = new Array();

    function getOnRowButtons(gridId) {
        var buttons = $("#" + gridId + " .k-grid-toolbar input[data-role='grid-on-row-button']");
        return buttons;
    }
    
    return {
        gridClassName: "k-grid",
        addButtonClassName: "k-grid-add",
        contentClassName: "k-grid-content",
        headerClassName: "k-grid-header",
        pagerClassName: "k-grid-pager",

        getOnDataBoundEventArgs: function (e) {
            var element = e.sender.element[0];
            var disabled = false;
            for (var i = 0; i < element.attributes.length; i++) {
                if (element.attributes[i].name == "disabled" && element.attributes[i].value == "disabled") {
                    disabled = true;
                    break;
                }
            }
            var data = {
                senderId: element.id,
                disabled: disabled //element.disabled // bug in Crome
            };
            
            return data;
           
        },

        reload: function (id) {
            var control = $("#" + id);
            if (!control.length) {
                return;
            }
            var grid = control.data("kendoGrid");
            if (grid) {
                grid.dataSource.read();
            }
        },
        
        reloadWithPage: function (id, number) {
            var control = $("#" + id);
            if (!control.length) {
                return;
            }
            var grid = control.data("kendoGrid");
            if (grid) {
                //var optionalData = { page: number };
                //grid.dataSource.read(optionalData);
                
                grid.dataSource.read();
                //grid.dataSource.page(number);
            }
        },

        getToolbarButtons: function (gridId) {
            var buttons = $("#" + gridId + " .k-grid-toolbar input.button");
            return buttons;
        },
        
        disableToolbarButtons: function (gridId) {
            var buttons = gridFacade.getToolbarButtons(gridId);
            gridFacade.disableButtons(buttons);
        },

        enableToolbarButtons: function (gridId) {
            var buttons = gridFacade.getToolbarButtons(gridId);
            var buttonsCount = buttons.length;
            for (var i = 0; i < buttonsCount; i++) {
                var button = $(buttons[i]);
                var role = button.data("role");
                if (role == "grid-on-row-button") {
                    var gridName = button.data("grid-name");
                    var selectedId = bvGrid.getSelectedItemId(gridName);
                    if (selectedId) {
                        gridFacade.enableButtons(button);
                    } else {
                        gridFacade.disableButtons(button);
                    }
                } else {
                    gridFacade.enableButtons(button);
                }
            }
        },
        
        disableButtons: function(buttons) {
            if (buttons) {
                buttons.attr('disabled', 'disabled');
                buttons.addClass("k-state-disabled");
            }
        },
        
        enableButtons: function (buttons) {
            if (buttons) {
                buttons.removeAttr('disabled');
                buttons.removeClass("k-state-disabled");
            }
        },
        
        unSelectAllRows: function (gridId) {
            gridFacade.clearSelectedItems();
            $("#" + gridId + " ." + gridFacade.contentClassName + " input[type='checkbox']").each(function () {
                this.value = "false";
                this.checked = false;
            });
            $("#" + gridId + " ." + gridFacade.contentClassName + " tr").removeClass(selectedRowClassName);
        },
        
        selectAllRows: function (gridId) {
            gridFacade.clearSelectedItems();
            $("#" + gridId + " ." + gridFacade.contentClassName + " input[type='checkbox']").each(function () {
                var id = $(this).data("item-id");
                selectedItems.push(id);
                this.value = "true";
                this.checked = true;
                bvGrid.onCheckboxClick(null, gridId, this, null);
            });
        },

        selectRows: function (gridId) {
            $("#" + gridId + " ." + gridFacade.contentClassName + " input[type='checkbox']").each(function () {
                var id = $(this).data("item-id");
                for (var i = 0; i < selectedItems.length; i++) {
                    if (selectedItems[i] == id) {
                        this.value = "true";
                        this.checked = true;
                        bvGrid.onCheckboxClick(null, gridId, this, null);
                    }
                }
            });
        },

        selectRow: function (row) {
            var id = row.find("input[data-item-id!='']").data("item-id");
            row.addClass(selectedRowClassName);
            for (var i = 0; i < selectedItems.length; i++) {
                if (selectedItems[i] == id) {
                    return;
                }
            }
            selectedItems.push(id);
        },

        unSelectRow: function (row) {
            var id = row.find("input[data-item-id!='']").data("item-id");
            for (var i = 0; i < selectedItems.length; i++) {
                if (selectedItems[i] == id) {
                    selectedItems.splice(i, 1);
                    break;
                }
            }
            row.removeClass(selectedRowClassName);
        },
        
        clearSelectedItems: function() {
            selectedItems = new Array();
        },
        
        isRowSelected: function (row) {
            return row.hasClass(selectedRowClassName);
        },
        
        enableOnRowButtons: function (gridId) {
            var buttons = getOnRowButtons(gridId);
            gridFacade.enableButtons(buttons);
        },
        
        disableOnRowButtons: function (gridId) {
            var buttons = getOnRowButtons(gridId);
            gridFacade.disableButtons(buttons);
        },

        getAllItemIds: function (gridId) {
            var grid = $("#" + gridId).data("kendoGrid");
            var items = grid.dataSource.data();
            var count = items.length;
            var ids = "";
            for (var i = 0; i < count; i++) {
                var id = items[i].id;
                if (id) {
                    if (ids.length > 0)
                        ids += ",";
                    ids += id;
                }
            }
            return ids;
        },
        
        getSelectedItemIds: function (gridId) {
            //var items = $("#" + gridId + " tr ." + selectedRowClassName + " input[data-item-id!='']");

            if ($("#useSelectedItems").length == 0) {
                var items = $("#" + gridId + " tr." + selectedRowClassName + " input[data-item-id!='']");
                var count = items.length;
                var ids = "";
                for (var i = 0; i < count; i++) {
                    var id = $(items[i]).data("item-id");
                    if (id) {
                        if (ids.length > 0)
                            ids += ",";
                        ids += id;
                    }
                }
                return ids;
            } else {
                var count1 = selectedItems.length;
                var ids1 = "";
                for (var i1 = 0; i1 < count1; i1++) {
                    if (ids1.length > 0)
                        ids1 += ",";
                    ids1 += selectedItems[i1];
                }
                return ids1;
            }
        },
        
        getSelectedRows: function (gridId) {
            var rows = $("#" + gridId + " .k-grid-content ." + selectedRowClassName);
            return rows;
        },
        
        hasRows: function (gridId) {
            return $("#" + gridId + " .k-grid-content tr").length > 0;
        },
        
        isEnabled: function (gridId) {
            return !$("#" + gridId).is(':disabled');
        }
    };
})();