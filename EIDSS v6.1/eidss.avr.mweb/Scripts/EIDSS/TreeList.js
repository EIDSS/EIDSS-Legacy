var queryTreeList = (function () {
    var queryList;

    return {
        initTreeList: function (CanInsert) {
            queryList = $('#treeList');
            if (CanInsert == 'True') {
                $('#btnAddFolder')[0].style.visibility = 'visible';
                $('#btnAddLayout')[0].style.visibility = 'visible';
                $('#btnCopy')[0].style.visibility = 'visible';
            }
            else {
                $('#btnAddFolder')[0].style.visibility = 'hidden';
                $('#btnAddLayout')[0].style.visibility = 'hidden';
                $('#btnCopy')[0].style.visibility = 'hidden';
            }
        },
        showEditNodes: function (s, e) {
            $('tr[nodeType=\'queryNode\']').children('td.dxtlCommandCell_Office2010Blue').each(function () {
                $(this).find('img').css('visibility', 'hidden');
            });
            var selId = queryTreeList.getSelectedKey();
            queryTreeList.setSelection(selId);
        },

        focusedNodeChanged: function (s, e) {
            treeList.cpSelectedNode = s.selectionStartKey;
        },

        saveSelectedKey: function (id) {
            $('#hSelectedNodeId')[0].value = id;
        },
        getSelectedKey: function () {
            if ($('#hSelectedNodeId')[0].value != "") {
                return $('#hSelectedNodeId')[0].value;
            }
            return "";
        },
        openLayout: function(layoutId) {
            window.open(avrUrls.getLayoutUrl() + '?layoutId=' + layoutId + '&clearcache=1', '_blank');
        },
        openView: function (layoutId) {
            window.open(avrUrls.getViewUrl() + '?layoutId=' + layoutId + '&clearcache=1', '_blank');
        },
        showLayoutView: function (layoutId, forceViewShowing, forceLayoutShowing) {
            if (layoutId == '' || layoutId == '') {
                var key = queryTreeList.getSelectedKey();
                if (key == null || key == "")
                    return "";
                var treeNode = $('#treeList_R-' + key);
                if (treeNode.attr('nodeType') == 'layoutNode') {
                    layoutId = key;
                }
            }
            if (layoutId != '' & layoutId != '') {
                    $.ajax({
                        url: 'CheckLayout',
                        dataType: 'json',
                        type: 'GET',
                        data: {
                            layoutId: layoutId,
                            forceViewShowing: forceViewShowing,
                            forceLayoutShowing: forceLayoutShowing
                        },
                        success: function (data) {
                            if (data.err !== '') {
                                document.location.href = "AvrServError?error=AVR service error: "+data.err;
                            } else {
                                if (data.isQueryExists === 'No') {
                                    okCancelForm.OnHyperLinkClick(data.Message, data.okFunction);
                                } else {
                                    queryTreeList.showLayoutViewInternal(layoutId, data.isNewLayout === 'No', forceViewShowing, forceLayoutShowing, data.Message);
                                }
                            }
                        }
                    });
            }
            return "";
        },
        showLayoutViewInternal: function (layoutId, isNewLayout, forceViewShowing, forceLayoutShowing, warningForAbsentView) {
            if (forceLayoutShowing)
                queryTreeList.openLayout(layoutId);
            else {
                if (isNewLayout === true) {
                    queryTreeList.openView(layoutId);
                } else {
                    if (!forceViewShowing)
                        queryTreeList.openLayout(layoutId);
                    else {
                        warnForm.OnHyperLinkClick(warningForAbsentView);
                    }
                }
            }
        },
        setSelection: function (id) {
            var treeNode = $('#treeList_R-' + id);
            var treeNodeD = $('#treeList_R-' + id + '_D');
            var nodeType = treeNode.attr('nodeType');
            var queryid = nodeType == 'queryNode' ? id : treeNode.attr('queryid');
            $.cookie('queryId', queryid);
            treeNodeD.removeClass('dxWeb_edtCheckBoxUnchecked_Office2010Blue').addClass('dxWeb_edtCheckBoxChecked_Office2010Blue');
            treeNode.removeClass('treeClass hideEdit').addClass('dxtlSelectedNode_Office2010Blue').addClass('selectedNode');
            queryTreeList.setButtonStates(nodeType);
        },
        setButtonStates: function (nodeType) {
            if (nodeType == 'layoutNode') {
                $('#btnCopy').removeAttr('disabled');
                $('#mnuExportToMdb').removeAttr('disabled');
                $('#btnOpenPivot').removeAttr('disabled');
                $('#btnOpenView').removeAttr('disabled');
                $('#btnAddLayout').attr('disabled', 'disabled');
                $('#btnAddFolder').attr('disabled', 'disabled');
                $('#btnRefreshData').removeAttr('disabled');
            } else if (nodeType == 'folderNode') {
                $('#btnOpenView').attr('disabled', 'disabled');
                $('#btnOpenPivot').attr('disabled', 'disabled');
                $('#btnAddFolder').removeAttr('disabled');
                $('#btnAddLayout').removeAttr('disabled');
                $('#btnCopy').attr('disabled', 'disabled');
                $('#mnuExportToMdb').attr('disabled', 'disabled');
                $('#btnRefreshData').attr('disabled', 'disabled');
            }
            else if (nodeType == 'queryNode') {
                $('#btnAddFolder').removeAttr('disabled');
                $('#btnAddLayout').removeAttr('disabled');
                $('#btnOpenView').attr('disabled', 'disabled');
                $('#btnOpenPivot').attr('disabled', 'disabled');
                $('#btnCopy').attr('disabled', 'disabled');
                $('#mnuExportToMdb').attr('disabled', 'disabled');
                $('#btnRefreshData').removeAttr('disabled');
            } else {
                $('#btnAddFolder').attr('disabled', 'disabled');
                $('#btnAddLayout').attr('disabled', 'disabled');
                $('#btnOpenView').attr('disabled', 'disabled');
                $('#btnOpenPivot').attr('disabled', 'disabled');
                $('#btnCopy').attr('disabled', 'disabled');
                $('#mnuExportToMdb').attr('disabled', 'disabled');
                $('#btnRefreshData').attr('disabled', 'disabled');
            }
        },
        checkedChanged: function (s, e) {
            //clear all checked
            var selRow = queryList.find('tr.dxtlSelectedNode_Office2010Blue');
            selRow.find('td.dxtlSelectionCell_Office2010Blue').find('span').removeClass('dxWeb_edtCheckBoxChecked_Office2010Blue').addClass('dxWeb_edtCheckBoxUnchecked_Office2010Blue');
            queryList.find('tr').removeClass('dxtlSelectedNode_Office2010Blue').removeClass('selectedNode');
            selRow.addClass(function (index, currentClass) {
                var addedClass;
                if (this.rowIndex % 2 == 1)
                    addedClass = "dxtlNode_Office2010Blue treeClass hideEdit";
                else
                    addedClass = "dxtlAltNode_Office2010Blue treeClass hideEdit";
                return addedClass;
            });


            //add check again
            queryTreeList.setSelection(s.selectionStartKey);
            queryTreeList.saveSelectedKey(s.selectionStartKey);
        },
        addFolder: function () {
            var selKey = queryTreeList.getSelectedKey();
            if (selKey != "") {
                $.cookie('newElementType', 'folder');
                treeList.StartEditNewNode(selKey);
            }
        },
        addLayout: function () {
            var selKey = queryTreeList.getSelectedKey();
            if (selKey != "") {
                $.cookie('newElementType', 'layout');
                treeList.StartEditNewNode(selKey);
            }
        },
        getCalledEvent: function (s, e) {
            if (s.selectionStartKey == null) return;
            var contentData = $("form").serialize(true);
            if (e.command == "DeleteNode") {
                /*
                $.ajax({
                    url: avrUrls.getDeleteTreeNodeUrl(),
                    type: 'POST',
                    data: contentData,
                    success: function (data) {
                        if (data.result == 'ask') {
                            confForm.OnHyperLinkClick(data.messageText, data.yesFunction, data.noFunction);
                        }
                        //else
                        //    treeList.UpdateEdit();
                        //    document.location.href = data.function;
                    },
                    error: function(x, y, z) {
                    }
                });
                */
            }
        },

        callbackErrorHandle: function (s, e) {
            e.handled = true;
            defaultPage.checkTimeoutError(e.message);
            s.HideLoadingPanel();
            s.HideLoadingDiv();
        },
        showPivot: function (layoutId, forceLayoutShowing) {
            queryTreeList.showLayoutView(layoutId, false, forceLayoutShowing);
        },
        showView: function (layoutId) {
            queryTreeList.showLayoutView(layoutId, true, false);
        },
        EditNode: function (s, e) {
            var contentData = $("form").serialize(true);
            $.ajax({
                url: avrUrls.getEditTreeNodeUrl(),
                dataType: 'json',
                type: 'POST',
                data: contentData,
                success: function (data) {
                    if (data.result == 'ASK') {
                        confForm.OnHyperLinkClick(data.messageText, data.yesFunction, data.noFunction, 'false');
                    }
                    else// if (data.result == 'EXISTS') 
                    {
                        warnForm.OnHyperLinkClick(data.errorString);
                    }
                }
            });
        },

        copy: function () {
            var skey = queryTreeList.getSelectedKey();
            if (skey == null) return;
            var urlcopy = avrUrls.getCopyTreeNodeUrl() + "?id=" + skey;
            $.ajax({
                url: urlcopy,
                dataType: 'json',
                type: 'POST',
                success: function (data) {
                    if (data.result == 'OK') {
                        document.location.href = data.url;
                    } else {
                        warnForm.OnHyperLinkClick(data.errorString);
                    }
                }
            });
        },

        customButtonClick: function (s, e) {
            if (e.buttonID == 'btnDelete') {
                e.processOnServer = false;
                queryTreeList.canDeleteNodeRoutines(e.nodeKey);
            }
        },

        canDeleteNodeRoutines: function (id) {
            var url1 = avrUrls.getCanDeleteTreeNodeUrl() + "?id=" + id;
            $.ajax({
                url: url1,
                dataType: 'json',
                type: 'POST',
                success: function (data) {
                    if (data.result == 'OK') {
                        confForm.OnHyperLinkClick(EIDSS.BvMessages['msgDeletePrompt'], 'queryTreeList.deleteNodeRoutines(' + id + ');', '', 'false');
                    } else {
                        warnForm.OnHyperLinkClick(data.errorString);
                    }
                }
            });
        },

        deleteNodeRoutines: function (id) {
            treeList.DeleteNode(id);
            /*
            var url1 = avrUrls.getDeleteTreeNodeUrl() + "?id=" + id;
            $.ajax({
                url: url1,
                dataType: 'json',
                type: 'POST',
                success: function (data) {
                    if (data.result == 'OK') {
                        treeList.DeleteNode(id);
                        //treeList.refresh();
                    } else {
                        warnForm.OnHyperLinkClick(data.errorString);
                    }
                }
            });
            */
        },
        refreshData: function () {
            showLoading();
            $('#btnRefreshData')[0].disabled = true;
            var selId = queryTreeList.getSelectedKey();
            var treeNode = $('#treeList_R-' + selId);
            var nodeType = treeNode.attr('nodeType');
            var queryid = nodeType == 'queryNode' ? selId : treeNode.attr('queryid');

            $.ajax({
                url: 'OnRefreshData',
                dataType: 'json',
                type: 'POST',
                data: 'queryId=' + queryid,
                success: function (data) {
                    hideLoading();
                    $('#btnRefreshData')[0].disabled = false;
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    hideLoading();
                    $('#btnRefreshData')[0].disabled = false;
                }
            });
        },
        onExport: function (s, e) {
            var queryIdvalue = $.cookie('queryId');
            if (queryIdvalue == null || queryIdvalue == '') return;
            var exportTypeValue = -1;

            if (e.item.name == "mnuExportToXlsx") {
                exportTypeValue = 0;
            } else if (e.item.name == "mnuExportToXls") {
                exportTypeValue = 1;
            }else if (e.item.name == "mnuExportToMdb") {
                exportTypeValue = 2;
            }
            if (exportTypeValue == -1) return;
        
            var url = avrUrls.getExportQueryUrl();
            $.ajax({
                url: url,
                dataType: 'json',
                type: 'GET',
                data: {
                    queryId: queryIdvalue,
                    exportType: exportTypeValue
                },
                success: function (data) {
                    window.location = data.url;
                }
            });
        } 

    };
})();