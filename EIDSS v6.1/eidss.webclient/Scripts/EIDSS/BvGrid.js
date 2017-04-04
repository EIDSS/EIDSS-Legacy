var bvGrid = (function () {
    var defaultId = "Grid";
    var minEditWindowWidth = 745;

    function highlightRowByIndex(gridId, rowIndex) {
        if (!gridId) {
            gridId = defaultId;
        }
        var selection = $("#" + gridId + " tr.t-state-selected");
        selection.removeClass("t-state-selected");
        var grid = $("#" + gridId).data('tGrid');
        var row = grid.$rows()[rowIndex];
        if (row.cells.length > 1) {
            row.className = 't-state-selected';
        } else {
            row.className = '';
        }
    }

    function scrollToRow(gridId, rowIndex) {
        var grid = $("#" + gridId).tGrid('tGrid').data('tGrid');
        if (!grid) {
            return;
        }
        if (!rowIndex || grid.$rows().length <= rowIndex) {
            return;
        }
        var row = grid.$rows()[rowIndex];
        if (row.cells.length > 1) {
            highlightRowByIndex(gridId, rowIndex);
            var table = $("#" + gridId + " .t-grid-content table");
            var selectedRow = table.find('tr').eq(+rowIndex);
            var scrollableContent = $("#" + gridId + " .t-grid-content");
            scrollableContent.scrollTop(selectedRow.offset().top - (scrollableContent.height()));
        }
    }

    function isExists(gridId) {
        var grid = $("#" + gridId);
        return gridId && grid.length > 0;
    }

    function addEmptyRow(e) {
        if (e.sender.dataSource.view().length == 0) {
            var colspan = e.sender.content.find("table col").length;
            e.sender.content.find("table").append("<tr class='t-no-data'><td colspan=" + colspan + "></td></tr>");
        }
    }

    return {
        timeOffsetInHours: 0,
        firstShiftSelectRow: null,

        emptyFunction: function (e) {
        },

        fixDateTime: function (date, format) {
            if (date) {
                var utcDate = new Date(date.getUTCFullYear(), date.getUTCMonth(), date.getUTCDate(), date.getUTCHours(), date.getUTCMinutes(), date.getUTCSeconds(), date.getUTCMilliseconds());
                var serverOffset = bvGrid.timeOffsetInHours * 60 * 60 * 1000;
                var serverTime = new Date(utcDate.getTime() + serverOffset);
                return globalizationFacade.toString(format, serverTime);
            } else {
                date = "";
            }
            return date;
        },

        fixDate: function (date, format) {
            if (date) {
                return globalizationFacade.toString(format, date);
            } else {
                date = "";
            }
            return date;
        },

        fixDate2: function (date, format) {
            if (date) {
                date = new Date(date.getTime() + date.getTimezoneOffset() * 60000);
                return globalizationFacade.toString("d", date);
            } else {
                date = "";
            }
            return date;
        },

        onRowDataBound: function (e) {
            if (e.dataItem.ErrorMessage != null) {
                bvDialog.showError(e.dataItem.ErrorMessage);
                e.dataItem.ErrorMessage = null;
            }
        },

        onEdit: function (e) {
            if (e.model) {
                var readOnly = e.model[e.sender.columns[e.container.context.cellIndex].field + "Readonly"];
                if (readOnly == undefined || readOnly) {
                    //var grid = $('#Grid').data('kendoGrid');
                    var grid = e.sender;
                    grid.closeCell();
                }
            }
        },


        //onChange: function (e) {
        //},
        //onPush: function (e) {
        //},

        onRequestEnd: function (e) {
            if (e.type == "update") {
                e.sender.read();
            }
            if (e.response != null && e.response.indexOf != null && e.response.indexOf("div class=\"errorButtonPanel\"") > -1) {
                $("#idGetDataError").removeClass("invisible");
            } else {
                $("#idGetDataError").addClass("invisible");
            }
        },

        onError: function (e, status) {
            $("#idGetDataError").removeClass("invisible");
        },

        //onRequestStart: function (e) {
        //},
        //onSync: function (e) {
        //},


        /*onLoadSearchResult: function (e, gridId) {
            if ($("#NeedsFirstRowSelection").val() == "0") {
                bvGrid.selectFirstRow(gridId);
            } else {
                scrollToRow(gridId, $("#NeedsFirstRowSelection").val());
                $("#NeedsFirstRowSelection").val("0");
            }
        },*/
        
        deleteRow: function (id, listKey, gridName, type) {
            var grid = $("#" + gridName);
            if (grid.attr('disabled') == 'disabled') {
                return;
            }
            bvDialog.showDeletePrompt(function () {
                bvGrid.doDeleteRow(id, listKey, gridName, type);
            });
        },


        doDeleteRow: function (id, listKey, gridName, type) {
            var url = bvUrls.getTryDeleteFromDetailsGridUrl();
            $.ajax({
                url: url,
                dataType: "json",
                type: "POST",
                data: {
                    key: listKey,
                    name: gridName,
                    type: type,
                    id: id
                },
                success: function (data) {
                    var hasError = formRefresher.hasError(data);
                    if (!hasError) {
                        gridFacade.reload(gridName);
                    }
                    formRefresher.updateControls(data);
                    /*if (data) {
                        gridFacade.reload(gridName);
                    }
                    else {
                        bvDialog.showError(EIDSS.BvMessages['ErrObjectCantBeDeleted']);
                    }*/
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    bvDialog.showAuthenticationError(jqXHR, textStatus, errorThrown);
                }
            });
        },
        /*
        deleteAndApplyChanges: function (id, listKey, gridName, type) {
            var url = bvUrls.getTryDeleteFromGridAndCompareUrl();
            bvDialog.showYesNo(msgConfimation,
                EIDSS.BvMessages['msgDeleteRecordPrompt'],
                function () {
                    $.ajax({
                        url: url,
                        dataType: "json",
                        type: "POST",
                        async: false,
                        data: {
                            key: listKey,
                            name: gridName,
                            id: id
                        },
                        success: function (data) {
                            var hasError = formRefresher.hasError(data);
                            if (!hasError) {
                                gridFacade.reload(gridName);
                            }
                            formRefresher.updateControls(data);
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            bvDialog.showAuthenticationError(jqXHR, textStatus, errorThrown);
                        }
                    });
                },
                bvGrid.emptyFunction);
            //e.preventDefault();
        },
        */
        editRow: function (id, listKey, gridName, showEditWindowFunc) {
            var grid = $("#" + gridName);
            if (grid.attr('disabled') == 'disabled') {
                return;
            }
            showEditWindowFunc(id, listKey, gridName);
        },
        
        addRow: function (listKey, gridName, showEditWindowFunc) {
            var id = 0;
            showEditWindowFunc(id, listKey, gridName);
        },

        onDataBound: function (e, isAutoDisabledBtns) {
            bvGrid.selectFirstRow(e.target.id, isAutoDisabledBtns.toLowerCase() == "true");
        },
        
        onDetailsPopupGridDataBound: function (e) {
            addEmptyRow(e);
            var args = gridFacade.getOnDataBoundEventArgs(e);
            gridFacade.selectRows(args.senderId);
        },

        onDetailsPopupGridDataBinding: function (e) {
            var args = gridFacade.getOnDataBoundEventArgs(e);
            var selItems = gridFacade.getSelectedItemIds(args.senderId);
        },

        onDetailsFormGridDataBound: function (e, onDataBoundFunc) {
            addEmptyRow(e);

            var args = gridFacade.getOnDataBoundEventArgs(e);
            if (args.disabled) {
                bvGrid.disable(args.senderId);
            } else {
                bvGrid.enable(args.senderId);
            }
            if (onDataBoundFunc) {
                onDataBoundFunc();
                //sample.updateNewCaseTestValidationButton();
            }
        },

        enableCheckbox: function() {
            this.element.find(".k-columns-item :checkbox").prop("disabled", false);
        },

        onMenuInit: function (e, name, isSaveConfirmation) {
            var menu = e.container.find(".k-menu").data("kendoMenu");
            var handler = $.proxy(bvGrid.enableCheckbox, menu);
            menu.bind("open", handler).bind("select", handler);

            var field = e.field;
            var text = EIDSS.BvMessages['msgRestoreToDefault']
            menu.append({
                text: text
            });

            // add an event handler
            menu.bind("select", function (e) {
                var menuText = $(e.item).text();
                if (menuText == text) {
                    showLoading();
                    $.ajax({
                        url: bvUrls.getSystemGridColumnsRestoreUrl({ name: name }),
                        type: "POST",
                        success: function () {
                            hideLoading();
                            if (isSaveConfirmation) {
                                detailPage.checkChanges(true,
                                    function () {
                                        bvDialog.showOkPrompt(function () {
                                            detailPage.submit(bvGrid.onOkSuccess, true);
                                        });
                                    },
                                    actions.refresh
                                );
                            } else {
                                actions.refresh();
                            }
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            hideLoading();
                        }
                    });
                }
            });
        },
        onOkSuccess: function (data) {
            if (data.Values == undefined) {
                bvDialog.showError(EIDSS.BvMessages['errUnknownError']);
            } else {
                if (data.Values["ErrorMessage"]) {
                    if (data.Values["ErrorMessage"].typeName == "AskPostMessage" || data.Values["ErrorMessage"].typeName == "WarningPostMessage") {
                        formRefresher.setOnChangedSuccess(actions.refresh);
                    }
                    formRefresher.updateControls(data);
                } else {
                    actions.refresh();
                }
            }
        },

        onColumnHide: function (e, name) {
            e.sender.thead.find('#idSomeFieldsAreHidden').show();
            $.ajax({
                url: bvUrls.getSystemGridColumnHideUrl({name: name, column: e.column.field}),
                type: "POST"
            });
        },
        onColumnShow: function (e, name) {
            var bAllColumnsVisible = true;
            var i = 0;
            for (i; i < e.sender.columns.length; i++) {
                if (e.sender.columns[i].hidden && (e.sender.columns[i].menu === true || e.sender.columns[i].menu === undefined)) {
                    bAllColumnsVisible = false;
                    break;
                }
            }
            if (bAllColumnsVisible)
                e.sender.thead.find('#idSomeFieldsAreHidden').hide();

            $.ajax({
                url: bvUrls.getSystemGridColumnShowUrl({ name: name, column: e.column.field }),
                type: "POST"
            });
        },
        onColumnReorder: function (e, name) {
            if (e.sender.columns[e.newIndex].field == "ItemKey" || e.sender.columns[e.oldIndex].field == "ItemKey") {
                setTimeout(function () {
                    e.sender.reorderColumn(e.oldIndex, e.sender.columns[e.newIndex]);
                }, 0);
            } else {
                $.ajax({
                    url: bvUrls.getSystemGridColumnReorderUrl({ name: name, column: e.column.field, oldOrder: e.oldIndex, newOrder: e.newIndex }),
                    type: "POST"
                });
            }
        },
        onColumnResize: function (e, name) {
            $.ajax({
                url: bvUrls.getSystemGridColumnResizeUrl({ name: name, column: e.column.field, size: e.newWidth }),
                type: "POST"
            });
        },


        showEditWindow: function (path, windowWidth, windowHeigth, title, formNumber) {
            if (windowWidth < minEditWindowWidth) {
                windowWidth = minEditWindowWidth; // У окон для редактирования эл-тов грида есть минимальная ширина. Она же и максимальная (кроме окна редактирования пациента)
            }
            bvPopup.showDefault(path, title, formNumber, windowWidth, windowHeigth);
        },
        showEditWindowAnyWidth: function (path, windowWidth, windowHeigth, title, formNumber) {
            bvPopup.showDefaultAnyWidth(path, title, formNumber, windowWidth, windowHeigth);
        },

        saveAndCloseEditWindow: function (gridId, postUrl, successFunc, contentFunc) {
            if (contentFunc == undefined) {
                contentFunc = bvPopup.getDefaultWindowData;
            }

            var contentData = contentFunc();
            contentData = EscapeHtmlGtLtOnly(contentData);

            showLoading();
            $.ajax({
                url: postUrl,
                dataType: "json",
                type: "POST",
                data: contentData,
                success: function (data) {
                    hideLoading();
                    var hasError = formRefresher.hasError(data);
                    formRefresher.updateControls(data);
                    if (!hasError) {
                        bvPopup.closeDefaultPopup();
                        bvGrid.reloadById(gridId);
                        if (successFunc != undefined) successFunc(data);
                    }
                },
                error: function () {
                    hideLoading();
                    bvPopup.closeDefaultPopup();
                    bvGrid.reloadById(gridId);
                }
            });
        },

        saveWithoutCloseEditWindow: function (gridId, postUrl, successFunc) {
            var contentData = bvPopup.getDefaultWindowData();
            showLoading();
            $.ajax({
                url: postUrl,
                dataType: "json",
                type: "POST",
                data: contentData,
                success: function (data) {
                    hideLoading();
                    var hasError = formRefresher.hasError(data);
                    formRefresher.updateControls(data);
                    if (!hasError) {
                        if (successFunc != undefined)
                            successFunc(data);
                    }
                },
                error: function () {
                    hideLoading();
                    bvGrid.reloadById(gridId);
                }
            });
        },

        reloadById: function (gridId) {
            gridFacade.reload(gridId);
        },

        selectAllRowsInDefaultGrid: function () {
            gridFacade.selectAllRows(defaultId);
        },

        selectUnselectAllRowsInDefaultGrid: function () {
            if ($("#idSelectUnselectAll")[0].checked) {
                gridFacade.selectAllRows(defaultId);
            } else {
                gridFacade.unSelectAllRows(defaultId);
            }
        },

        onRowRadioButtonClick: function (gridName, radioButton, onClickFunc) {
            gridFacade.unSelectAllRows(gridName);
            var radioButtonData = $(radioButton);
            var selectedRow = radioButtonData.closest("tr");
            if (gridFacade.isRowSelected(selectedRow)) {
                return;
            }
            gridFacade.selectRow(selectedRow);
            gridFacade.enableOnRowButtons(gridName);
            if (onClickFunc) {
                //var itemId = radioButtonData.data("item-id");
                onClickFunc(gridName, selectedRow);
            }
        },
        
        onCheckboxClick: function (event, gridName, checkbox, onClickFunc) {
            var checkboxData = $(checkbox);
            var row = checkboxData.closest("tr");
            if (checkboxData.is(':checked')) {
                gridFacade.selectRow(row);
                if (event != null && event.shiftKey && bvGrid.firstShiftSelectRow != null) {
                    var list = row.parent().children();
                    var start = false;
                    for (var i = 0; i < list.length; i++) {
                        var item = $(list[i]);
                        if (start && (item.attr('data-uid') == row.attr('data-uid') || item.attr('data-uid') == bvGrid.firstShiftSelectRow.attr('data-uid'))) {
                            break;
                        }
                        if (start) {
                            gridFacade.selectRow(item);
                            var chkBox = item.find("input[type='checkbox']")[0];
                            chkBox.value = "true";
                            chkBox.checked = true;
                        }
                        if (!start && (item.attr('data-uid') == row.attr('data-uid') || item.attr('data-uid') == bvGrid.firstShiftSelectRow.attr('data-uid'))) {
                            start = true;
                        }
                    }
                }
                bvGrid.firstShiftSelectRow = row;
            } else {
                bvGrid.firstShiftSelectRow = null;
                gridFacade.unSelectRow(row);
                if ($("#idSelectUnselectAll").length > 0) {
                    $("#idSelectUnselectAll")[0].checked = false;
                }
            }
            /*if (onClickFunc) {
                var itemId = checkboxData.data("item-id");
                //onClickFunc(gridName, itemId);
            }*/
        },

        getSelectedItemId: function (gridId) {
            return gridFacade.getSelectedItemIds(gridId);
        },
        
        getAllItemId: function (gridId) {
            return gridFacade.getAllItemIds(gridId);
        },

        
        disable: function (gridId) {
            if (!isExists(gridId)) {
                return;
            }
            var grid = $("#" + gridId);
            grid.attr('disabled', 'disabled');
            gridFacade.disableToolbarButtons(gridId);
        },

        enable: function (gridId) {
            if (!isExists(gridId)) {
                return;
            }
            var grid = $("#" + gridId);
            grid.removeAttr('disabled');
            gridFacade.enableToolbarButtons(gridId);
        },

        isGridEmpty: function (gridId) {
            var grid = $("#" + gridId).data("kendoGrid");
            if (!grid) {
                return true;
            }

            var firstRow = grid.tbody.find('tr');

            if (firstRow.length > 0) {
                return false;
            }
            
            return true;
        },

        selectFirstRow: function (gridId, isAutoDisabledBtns) {
            var grid = $("#" + gridId).data("kendoGrid");
            if (!grid) {
                return;
            }
            var isGridEnable = !$("#" + gridId)[0].disabled;
            
            var firstRow = grid.tbody.find('tbody tr:first');
            
            if (firstRow.length > 0) {
                firstRow.className = 'k-state-selected'; //grid.select(firstRow);
                if (isGridEnable && !isAutoDisabledBtns) {
                    gridFacade.enableToolbarButtons(gridId);
                }
            } else {
                firstRow.className = '';
                gridFacade.enableToolbarButtons(gridId);
            }
        },

        findAndScrollToRow: function (gridId, columnNumber, searchTextBoxId, notFoundMessageKey) { // columnNumber starting with 1    
            var searchText = $("#" + searchTextBoxId).val();
            var tdArr = $("#" + gridId + " .t-grid-content table tr td:nth-child(" + columnNumber + ')');
            var found = false;
            tdArr.each(function (index, td) {
                var cellText = $(td).text();
                if (cellText == searchText) {
                    scrollToRow(gridId, rowIndex);
                    found = true;
                    return false;
                }
            });
            if (!found) {
                bvDialog.showError(EIDSS.BvMessages[notFoundMessageKey]);
            }
        },

        scrollToRowByID: function (gridId, id) {
            gridFacade.unSelectAllRows(gridId);

            var chkWrap = $("tr td input[data-item-id='" + id + "']");
            if (chkWrap.length > 0) {
                var chk = chkWrap[0];
                var selectedRow = chkWrap.parent().parent();
                var scrollableContent = $("#" + gridId + " .k-grid-content");
                scrollableContent.scrollTop(selectedRow.offset().top - (scrollableContent.height()));
                chk.value = "true";
                chk.checked = true;
                bvGrid.onCheckboxClick(null, gridId, chk, null);
            } else {
                var control = $("#" + gridId);
                var theGrid = control.data("kendoGrid");
                var ds = theGrid.dataSource;

                var view = kendo.data.Query.process(ds.data(), {
                    filter: ds.filter(),
                    sort: ds.sort()
                }).data;

                var index = -1;
                // find the index of the matching dataItem
                for (var x = 0; x < view.length; x++) {
                    if (view[x].id == id) {
                        index = x;
                        break;
                    }
                }

                if (index === -1) {
                    return;
                }

                var page = Math.floor(index / theGrid.dataSource.pageSize());
                var targetIndex = index - (page * theGrid.dataSource.pageSize()) + 1;
                //page is 1-based index    
                theGrid.dataSource.page(++page);
                //grid wants a html element. tr:eq(x) by itself searches in the first grid!    
                //var row = $("#grid2").find("tr:eq(" + targetIndex + ")");
                //theGrid.select(row);
                
                chkWrap = $("tr td input[data-item-id='" + id + "']");
                if (chkWrap.length > 0) {
                    chk = chkWrap[0];
                    selectedRow = chkWrap.parent().parent();
                    scrollableContent = $("#" + gridId + " .k-grid-content");
                    scrollableContent.scrollTop(selectedRow.offset().top - (scrollableContent.height()));
                    chk.value = "true";
                    chk.checked = true;
                    bvGrid.onCheckboxClick(null, gridId, chk, null);
                } 
            }
            
        },

        toolBar: {
            hideSearchPanel: function (gridId) {
                $("#" + gridId + " .tToolBarSearchPanel").hide();
            }
        }
    };
})();
