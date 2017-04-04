var flexForms = {
    reloadFf: function(query, divname, rootvalue, additionalvalue) {
        $.ajax({
            url: query,
            type: "GET",
            data: {
                root: rootvalue,
                additional: additionalvalue
            },
            success: function(data) {
                $("#" + divname).html(data);
                hideLoading();
            },
            error: function(error) {
                hideLoading();
            }
        });
    },

    onLoadInPopUp: function(parentGridName) {
        $('form').ajaxForm(function(data) {
            if (data == 'ok') {
                bvPopup.closeById('Message');
                if (parentGridName.length > 0) {
                    bvGrid.reloadById(parentGridName);
                }
            } else {
                bvDialog.showError(data);
            }
        });
    },

    saveAndClosePopUp: function (parentGridName) {
        var contentData = bvPopup.getDefaultWindowData();
        var postUrl = bvPopup.getFormActionUrl(bvPopup.defaultName);
        $.ajax({
            url: postUrl,
            dataType: "json",
            type: "POST",
            data: contentData,
            success: function(data) {
                if (data == 'ok') {
                    bvPopup.closeDefaultPopup();
                    if (parentGridName.length > 0) {
                        bvGrid.reloadById(parentGridName);
                    }
                } else {
                    bvDialog.showError(data);
                }
            },
            error: function (a, b, c) {
                bvDialog.showError("Error");
            }
        });
    },

    onClearClick: function(rootItemId, currentObservationId) {
        var url = bvUrls.getClearFFUrl({root: rootItemId, idfObservation: currentObservationId});
        flexForms.changeFF(url, rootItemId, currentObservationId, true);
    },

    onCopyClick: function (rootItemId, currentObservationId) {
        var url = bvUrls.getCopyFFUrl({ root: rootItemId, idfObservation: currentObservationId });
        flexForms.changeFF(url, rootItemId, currentObservationId, false);
    },

    onPasteClick: function (rootItemId, currentObservationId) {
        var url = bvUrls.getPasteFFUrl({ root: rootItemId, idfObservation: currentObservationId });
        flexForms.changeFF(url, rootItemId, currentObservationId, true);
    },

    changeFF: function (url, rootItemId, currentObservationId, needRefreshFormAfterUpdate, containerName) {
        if (containerName == undefined) {
            containerName = 'FFContainer';
        }
        $.ajax({
            url: url,
            dataType: "json",
            type: "POST",
            success: function(data) {
                if (needRefreshFormAfterUpdate) {
                    var refreshUrl = bvUrls.getShowFlexibleFormUrl({root: rootItemId, key: rootItemId, ffpresenterId: currentObservationId});
                    flexForms.reloadFf(refreshUrl, containerName, rootItemId);
                }
            }
        });
    },
    
    /*добавление динамических параметров*/
    AddParameterEditWindow: function (idObservation) {
        var key = $("#FFKey").val();
        var url = bvUrls.getShowAddFFParameter({ key: key, ffpresenterId: idObservation });
        bvPopup.showDefault(url, EIDSS.BvMessages['AddParameter'], "C19", 800, 700);
    },
    
    checkedNodeIds: function(nodes, checkedNodes) {
        for (var i = 0; i < nodes.length; i++) {
            if (nodes[i].checked) {
                checkedNodes.push(nodes[i].id);
            }

            if (nodes[i].hasChildren) {
                flexForms.checkedNodeIds(nodes[i].children.view(), checkedNodes);
            }
        }
    },

    ParameterSelected: function () {
        var idRoot = $("#FFRootId").val();
        var idbservation = $("#FFObservationId").val();
        var divId = $("input[value='" + idbservation + "'][id='FFpresenterId']").parent().attr('id');
        var treeview = $("#treeParameters").data("kendoTreeView");
        var checkedNodes = new Array();
        
        flexForms.checkedNodeIds(treeview.dataSource.view(), checkedNodes);
            
        for (var i = 0; i < checkedNodes.length; i++) {
            var idParameter = checkedNodes[i];
            if (idParameter != null && idParameter != "" && !isNaN(parseInt(idParameter))) {
                var url = bvUrls.getAddFFParameter({root: idRoot, idfObservation: idbservation, idfsParameter: idParameter});
                flexForms.changeFF(url, idRoot, idbservation, true, divId);
            }
        }
        bvPopup.closeDefaultPopup();

        /*
        var node = treeview.dataItem(treeview.select());
        if (node != null) {
            //TODO почему не работает? var idParameter = node.Id;
            var idParameter = node.id;
            if (idParameter != null && idParameter != "" && !isNaN(parseInt(idParameter))) {
                var url = bvUrls.getAddFFParameter() + "?root=" + idRoot + "&idfObservation=" + idbservation + "&idfsParameter=" + idParameter;
                flexForms.changeFF(url, idRoot, idbservation, true, divId);
                bvPopup.closeDefaultPopup();
            }
        }
        */
    },
    
    /*удаление всех динамических параметров*/
    removeParameters: function () {
        var idRoot = $("#FFRootId").val();
        var idbservation = $("#FFObservationId").val();
        var divId = $("input[value='" + idbservation + "'][id='FFpresenterId']").parent().attr('id');
        var url = bvUrls.getDeleteFFParameters({root: idRoot, idfObservation: idbservation});
        flexForms.changeFF(url, idRoot, idbservation, true, divId);
    },
}