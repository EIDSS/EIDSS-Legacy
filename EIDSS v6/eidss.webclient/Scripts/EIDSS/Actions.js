var actions = {
    refresh: function () {
        actions.redirect(window.location.href);
    },

    redirect: function (url) {
        if (top.frames.length > 0) {
            top.location = url;
        } else {
            window.location.href = url;
        }
    },

    create: function (url) {
        bvDialog.showSavePrompt(function () { detailPage.open(url, true, false); });
    },

    createFromList: function (url) {
        detailPage.open(url, true, true);
    },

    edit: function (url) {
        var path = bvUrls.getByPath(url);
        bvWindow.show(path, " ");
    },

    refreshParentWindow: function () {
        detailPage.onClose();
    },

    emptyFunction: function (e) {
    },

    close: function () {
        detailPage.close();
    },

    save: function () {
        detailPage.checkChanges(true, 
            function () {
                bvDialog.showSavePrompt(function () {
                    detailPage.submit(actions.onSaveSuccess, true);
                });
            },
            actions.emptyFunction
        );
    },

    onSaveSuccess: function (data) {
        var hasError = formRefresher.hasError(data);
        if (!hasError) {
            detailPage.enableDeleteButton();
            var isNewCaseHidden = $("#IsNewCase");
            if (isNewCaseHidden) {
                isNewCaseHidden.val("");
            }
        }
        formRefresher.updateControls(data);
        detailPage.reloadGrids(); //в этом нет необходимости
    },

    ok: function () {
        detailPage.checkChanges(true,
            function () {
                bvDialog.showOkPrompt(function () {
                    detailPage.submit(actions.onOkSuccess, true);
                });
            },
            detailPage.close
        );
    },

    onOkSuccess: function (data) {
        if (data.Values == undefined) {
            bvDialog.showError(EIDSS.BvMessages['errUnknownError']);
        } else {
            if (data.Values["ErrorMessage"]) {
                if (data.Values["ErrorMessage"].typeName == "AskPostMessage") {
                    formRefresher.setOnChangedSuccess(detailPage.close);
                    //ApplyContainer.onAjaxSuccess = detailPage.close;
                }
                formRefresher.updateControls(data);
            } else {
                detailPage.close();
            }
        }
    },

    saveAndClose: function () {
        actions.save();
    },

    deleteItem: function (url) {
        bvDialog.showDeletePrompt(function () {
            actions.doDelete(url);
        });
    },

    deleteItemFromList: function (itemId, accessorFullName) {
        var url = bvUrls.getDeleteListObjectUrl() + "?accessor=" + accessorFullName + "&id=" + itemId;
        bvDialog.showDeletePrompt(function () {
            actions.doDelete(url);
        });
    },

    doDelete: function (url) {
        $.ajax({
            url: url,
            dataType: "json",
            type: "GET",
            success: function (data) {
                if (data) {
                    if ($('.detailsViewContainer').length == 1) {
                        detailPage.close();
                    }
                    else {
                        gridFacade.reload(searchPanel.defaultGridName);
                    }
                }
                else {
                    bvDialog.showError(EIDSS.BvMessages['ErrObjectCantBeDeleted']);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                bvDialog.showAuthenticationError(jqXHR, textStatus, errorThrown);
            }
        });
    },

    cancel: function () {
        detailPage.checkChanges(true,
            function () {
                bvDialog.showCancelPrompt(actions.close);
            },
            detailPage.close
        );
    },

    redirectToUrl: function (url, urlStore) {
        var contentData = $("form").serialize(true);
        $.ajax({
            url: urlStore,
            dataType: 'json',
            type: 'POST',
            data: contentData,
            success: function () {
                actions.redirect(url);
            },
            error: function (data) {
                bvDialog.showError(EIDSS.BvMessages['ErrWebTemporarilyUnavailableFunction']);
            }
        });
    }
}
