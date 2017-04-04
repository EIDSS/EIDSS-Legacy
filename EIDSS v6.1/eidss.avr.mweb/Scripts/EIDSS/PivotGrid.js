var layoutPivotGrid = (function () {
    //var pivotGrid;
    var totalHeight;
    var divPanelHeight;
    var divPivotHeight;
    var screenHeight;
    var preventClick = false;
    return {
        initPivotGrid: function () {
            divPanelHeight = $('.dxpgCustFieldsDiv_Office2010Blue table').outerHeight();
            divPivotHeight = $('table#pivotGrid').outerHeight();
            if (divPanelHeight == null)
                divPanelHeight = divPivotHeight;
            totalHeight = divPanelHeight > divPivotHeight ? divPanelHeight : divPivotHeight;
            screenHeight = screen.height - layoutPivotGrid.getTop($('#pivotContainer')[0]) - 180;
            totalHeight = divPivotHeight > screenHeight ? divPivotHeight : screenHeight;

            //if (divPanelHeight > totalHeight)
                divPanelHeight = totalHeight;
            //if (divPivotHeight > totalHeight)
                divPivotHeight = totalHeight;

            pcColumn.PerformCallback();

            //recursive resize side panel
            $('#roundPanel_0 div.dxpgFLListDiv_Office2010Blue').css('height', divPanelHeight + 'px');
            $('#roundPanel_0 div.dxpgCustFieldsDiv_Office2010Blue').css('height', (divPanelHeight + 10) + 'px');//offset created by control
            $('#roundPanel_0 #roundPanel_0_CC').css('height', (divPanelHeight + 30) + 'px'); //offset created by control
            $('#roundPanel_0').css('height', totalHeight + 'px');

            //recursive resize pivot table
            $('#roundPanel_1 #roundPanel_1_CC').css('height', totalHeight + 'px');
            $('#roundPanel_1').css('height', totalHeight + 'px');


            $('#roundPanel').css('height', (totalHeight + 2) + 'px');//control offset

            $('#btnTree').on('click', function (s, e) {
                document.location.href = document.location.href.substring(0, document.location.href.indexOf('?')).replace('Layout/Layout', 'QueryLayoutTree/QueryLayoutTree');
            });
            $('#btnView').on('click', function (s, e) {
                showLoading();
                $.ajax({
                    url: 'OnSwitchToView',
                    dataType: 'json',
                    type: 'POST',
                    success: function (data) {
                        if (data.result == 'ask') {
                            confForm.OnHyperLinkClick(data.messageText, 'showLoading();' + data.yesFunction, data.noFunction, 'true');
                            hideLoading();
                        }
                        else if (data.result == 'noask')
                            document.location.href = data.function;
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        hideLoading();
                    }
                });
            });
            $(window).on('resize', function () {
                //recursive resize side panel
                $('#roundPanel_0 div.dxpgFLListDiv_Office2010Blue').css('height', divPanelHeight + 'px');
                $('#roundPanel_0 div.dxpgCustFieldsDiv_Office2010Blue').css('height', (divPanelHeight + 10) + 'px');//offset created by control
                $('#roundPanel_0 #roundPanel_0_CC').css('height', (divPanelHeight + 30) + 'px'); //offset created by control
                $('#roundPanel_0').css('height', totalHeight + 'px');

                //recursive resize pivot table
                $('#roundPanel_1 #roundPanel_1_CC').css('height', totalHeight + 'px');
                $('#roundPanel_1').css('height', totalHeight + 'px');

                $('#roundPanel').css('height', (totalHeight + 2) + 'px');//control offset
            });
            $(window).on('unload', function () {
                //if (!window.closed)
                //    return;
                $.ajax({
                    url: 'OnClose',
                    type: 'GET',
                });
            });

            $('#roundPanel').on('resize', function () {
                //$('#roundPanel').width(windowSize);
            });
            $('#PivotSettings_ShowMissedValues').on('click', function (s, e) {
                $.ajax({
                    url: 'ShowMissedValues',
                    dataType: 'json',
                    type: 'POST',
                    data: { value: s.target.checked },
                    success: function (data) {
                        if (s.target.checked)
                            $('#PivotSettings_ShowDataInPivot')[0].checked = true;
                        pivotGrid.PerformCallback(e);
                    }
                });
            }
            );
            $('#PivotSettings_ShowDataInPivot').on('click', function (s, e) {
                $.ajax({
                    url: 'ShowData',
                    dataType: 'json',
                    type: 'POST',
                    data: { value: s.target.checked },
                    success: function (data) {
                        $('#PivotSettings_ShowMissedValues')[0].checked = data.showMissedValues;
                        pivotGrid.PerformCallback(e);
                    }
                });
            }
            );
            $('#PivotSettings_CompactLayout').on('click', function (s, e) {
                $.ajax({
                    url: 'CompactLayout',
                    dataType: 'json',
                    type: 'POST',
                    data: { isCompactLayout: s.target.checked },
                    success: function (data) {
                        totalsComboBox.SetEnabled(!s.target.checked);
                        //$('#totalsComboBox')[0].disabled = s.target.checked;
                        pivotGrid.PerformCallback(e);
                    }
                });
            }
           );
            $('#PivotSettings_FreezeRowHeaders').on('click', function (s, e) {
                $.ajax({
                    url: 'FreezeRowHeaders',
                    dataType: 'json',
                    type: 'POST',
                    data: { value: s.target.checked },
                    success: function (data) {
                        pivotGrid.PerformCallback(e);
                    }
                });
            }
           );
            $('#PivotSettings_ApplyFilter').on('click', function (s, e) {
                $.ajax({
                    url: 'ApplyFilter',
                    dataType: 'json',
                    type: 'POST',
                    data: { value: s.target.checked },
                    success: function (data) {
                        pivotGrid.PerformCallback(e);
                    }
                });
            }
           );
            $('#PivotSettings_UseArchiveData').on('click', function (s, e) {
                $.ajax({
                    url: 'UseArchiveData',
                    dataType: 'json',
                    type: 'POST',
                    data: { value: s.target.checked },
                    success: function (data) {
                        pivotGrid.PerformCallback(e);
                    }
                });
            }
            

           );
        },
        OnRefreshData: function () {
            showLoading();
            $.ajax({
                url: 'OnRefreshData',
                dataType: 'json',
                type: 'POST',
                success: function (data) {
                    if (data.result == 'ask') {
                        confForm.OnHyperLinkClick(data.messageText, 'showLoading();' + data.yesFunction, data.noFunction, 'true');
                        hideLoading();
                    }
                    else
                        document.location.href = data.function;
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    hideLoading();
                }
            });
        },
        onSave: function () {
            $.ajax({
                url: 'HasChanges',
                dataType: 'json',
                type: 'POST',
                success: function (data) {
                    if (data.result == 'ask') {
                        confForm.OnHyperLinkClick(data.messageText, data.yesFunction, data.noFunction, 'false');
                    }
                }
            });
        },
        OnSplitterPaneResized: function (s, e) {
            //recursive resize side panel
            $('#roundPanel_0 div.dxpgFLListDiv_Office2010Blue').css('height', divPanelHeight + 'px');
            $('#roundPanel_0 div.dxpgCustFieldsDiv_Office2010Blue').css('height', (divPanelHeight + 10) + 'px');//offset created by control
            $('#roundPanel_0 #roundPanel_0_CC').css('height', (divPanelHeight + 30) + 'px'); //offset created by control
            $('#roundPanel_0').css('height', totalHeight + 'px');

            //recursive resize pivot table
            $('#roundPanel_1 #roundPanel_1_CC').css('height', totalHeight + 'px');
            $('#roundPanel_1').css('height', totalHeight + 'px');

            $('#roundPanel').css('height', (totalHeight + 2) + 'px');//control offset
        },
        onCancelChanges: function () {
            showLoading();
            $.ajax({
                url: 'OnCancelChanges',
                dataType: 'json',
                type: 'GET',
                success: function (data) {
                    if (data.result == 'ask') {
                        confForm.OnHyperLinkClick(data.messageText, 'showLoading();' + data.yesFunction, data.noFunction, 'false');
                    }
                    hideLoading();
                }
            });

        },
        onClose: function () {
            $.ajax({
                url: 'HasChanges',
                dataType: 'json',
                type: 'POST',
                success: function (data) {
                    if (data.result == 'ask') {
                        data.yesFunction = data.yesFunction + ';window.close();';
                        data.noFunction = data.noFunction + ';window.close();';
                        confForm.OnHyperLinkClick(data.messageText, data.yesFunction, data.noFunction, 'true');
                    } else
                        window.close();
                }
            });
        },

        onCallbackError: function (s, e) {
            e.handled = true;
            defaultPage.checkTimeoutError(e.message);
        },

        onEndCallback: function (s, e) {
            if (pivotGrid.cpNeedCallback != null && pivotGrid.cpNeedCallback == true) {
                pivotGrid.cpNeedCallback = false;
                if (pivotGrid.cpApplyFilter) {
                    pivotGrid.cpApplyFilter = false;
                    $('#PivotSettings_ApplyFilter')[0].checked = true;
                }
                pivotGrid.PerformCallback(e);
            }
        },
        totalsSelectionChanged: function (s, e) {
            if (e.index == 0)
                e.isSelected ? s.SelectAll() : s.UnselectAll();

            checkComboBox.UpdateSelectAllItemState(s);
            checkComboBox.UpdateText(totalsComboBox, s);
            //$.ajax({
            //    url: "TotalsChanged",
            //    dataType: 'json',
            //    type: 'POST',
            //    data: s.GetSelectedItems(),
            //    success: function (data) {
            //        pivotGrid.PerformCallback(e);
            //    }
            //
            //});
        },
        totalsSelectionLostFocus: function (s, e) {
            //checkComboBox.UpdateText(totalsComboBox, s);
            $.ajax({
                url: "TotalsChanged",
                dataType: 'json',
                type: 'POST',
                data: s.GetSelectedItems(),
                success: function (data) {
                    pivotGrid.PerformCallback(e);
                }
            });

        },

        synchronizeTotalsValues: function (dropDown, args) {
            checkComboBox.Synchronize(dropDown, totalsCheckListBox);
        },

        onDefaultGroupDateChanged: function (s, e) {
            $.ajax({
                url: "DefaultGroupDateChanged",
                dataType: 'json',
                type: 'POST',
                data: { value: s.GetValue() },
                success: function (data) {
                    pivotGrid.PerformCallback(e);
                }

            });
        },
        onFieldListChanged: function (s, e) {
            var selField = s.GetValue();
            //var enabled = selField != null && selField != "";
            //$('#idEditColumn')[0].disabled = !enabled;
            //$('#idCopyColumn')[0].disabled = !enabled;
            $.ajax({
                url: "FieldListChanged",
                dataType: 'json',
                type: 'POST',
                data: "text=" + selField,
                success: function (data) {
                    pcColumn.PerformCallback(e);
                    //pivotGrid.PerformCallback(e);
                    //cbFieldsList.PerformCallback(e);
                }

            });
        },
        getTop: function (obj) {
            var top = 0;
            if (obj.offsetParent) {
                do {
                    top += obj.offsetTop;
                } while (obj = obj.offsetParent);
            }
            return top;
        },
        showPrefilter: function (CanUpdate) {
            if (CanUpdate == 'True') {
            $.ajax({
                url: "ShowPrefilter",
                dataType: 'json',
                type: 'POST',
                success: function (data) {
                    pivotGrid.PerformCallback();
                }

            });
            }
            else {
                $(this)
                    .css('cursor', 'default')
                    .css('text-decoration', 'none');

                if (!preventClick) {
                    $(this).html($(this).html() + ' lalala');
                }

                preventClick = true;

                //return false;
            }
        },

    };

})();