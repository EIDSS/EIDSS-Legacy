    function AjaxFormSubmit(SuccessHandler) {
        var formString = $('form').formSerialize();
        var action = $('form').attr('action');
        formString += "&actualsave=1";
        showLoading();

        $.ajax({
            url: action,
            type: "POST",
            data: formString,
            success: function (data) {
                SuccessHandler(data);
                hideLoading();
            }
        });

    }

    function SaveClick() {
        checkChanges(
        function () {
            ShowEidssDialogSavePrompt(SaveHandler);
        },
       DoNothing
    );
    }

    function SaveHandler() {
        AjaxFormSubmit(function (data) {
            ApplyChanges(data);

            var grids = new Array('Sessions', 'Diseases');
            //update all grids
            for (var i = 0; i < grids.length; i++) {
                if ($("#" + grids[i]).data("tGrid")) {
                    gridItemAdded(grids[i]);
                }
            }

        });
    }


    function OKHandler() {
        AjaxFormSubmit(function (data) {
            if (data.Values["ErrorMessage"]) {
                ApplyChanges(data);
            }
            else {
                CloseFocusPopUpWindow();
            }
        });
    }

    function OKClick() {
        checkChanges(
        function () { ShowEidssDialogOKPrompt(OKHandler); },
        CloseFocusPopUpWindow
    );
    }


    function CreateNewSession(url,name) {
        AjaxRefreshCampaign(function () { addNewItemInNewWindow(url, name); });
    }

    var as_session_selection_url = "../../ASSession/ASSessionPicker";
    
    function ShowASSessionPicker(url) {
        if (url) {
            as_session_selection_url = url;
        }
        AjaxRefreshCampaign(function () { ShowSearchPicker(as_session_selection_url, EIDSS.BvMessages['titleASSessionList']) });
    }

    function onASSessionPickerSearchAndOrder() {
        SearchItemsAndUpdateGrid(as_session_selection_url, "Message");
    }



    function AjaxRefreshCampaign(SuccessHandler) {
        var formString = $('form').formSerialize();
        var action = $('form').attr('action');
        showLoading();

        $.ajax({
            url: action,
            type: "POST",
            data: formString,
            success: function (data) {
                SuccessHandler(data);
                hideLoading();
            },
            error: function (data) {
                ShowEidssErrorNotification(EIDSS.BvMessages['ErrWebTemporarilyUnavailableFunction'], DoNothing);
                hideLoading();
            }
        });

    }


    function TryRemoveSession(url, gridName) {
        url = getFullUrlByGridName(url, gridName);

        ShowEidssYesNoDialog(
            EIDSS.BvMessages['msgConfimation'],
            EIDSS.BvMessages['AsCampaign_GetSessionRemovalConfirmation'],
            function () { RemoveSession(url, gridName); }, 
            DoNothing);
    }

    function RemoveSession(url, gridName) {
        showLoading();

        $.ajax({
            url: url,
            type: "GET",            
            success: function (data) {
                if (data == 'ok') {
                    gridItemAdded(gridName);                    
                }
                else {
                    ShowEidssErrorNotification(data);
                }
                hideLoading();
            },
            error: function (data) {
                ShowEidssErrorNotification(EIDSS.BvMessages['ErrWebTemporarilyUnavailableFunction'], DoNothing);
                hideLoading();
            }
        });
    }

    
    function ReloadSessionsGridToolbar(gridId) {
        var btDelete = $("#" + gridId + " .t-grid-toolbar #btRemove");
        var btEdit = $("#" + gridId + " .t-grid-toolbar #btViewDetails");
        
        DisableGridButton(btDelete);
        DisableGridButton(btEdit);

        var btNewSession = $("#" + gridId + " .t-grid-toolbar #btNew");
        var btSelect = $("#" + gridId + " .t-grid-toolbar #btSelect");

        var stateDiv = $("div[id$='CampaignStatus']")[0];
        var state = $("#" + stateDiv.id).data('tComboBox');

        if (state.value() == 10140001) {
            EnableGridButton(gridId, btNewSession);
            EnableGridButton(gridId, btSelect);
        }
        else {
            DisableGridButton(btNewSession);
            DisableGridButton(btSelect);
        }

        var selectedRow = $("#" + gridId + " tr.t-state-selected");
        if (selectedRow.length == 0) {
            return;
        }
        
        EnableGridButton(gridId, btDelete);
        EnableGridButton(gridId, btEdit);

    }

    function onCampaignStatusChange(e) {
        ModelFieldChangedCombobox(e);
        if (e.previousValue == e.value) { return; }
        var sessionlist = $('div[id$="Sessions"]');
        var gridId = sessionlist[0].id;
        var btNewSession = $("#" + gridId + " .t-grid-toolbar #btNew");
        var btSelect = $("#" + gridId + " .t-grid-toolbar #btSelect");

        if (e.value == 10140001) {
            EnableGridButton(gridId, btNewSession);
            EnableGridButton(gridId, btSelect);
        }
        else {
            DisableGridButton(btNewSession);
            DisableGridButton(btSelect);
        }
    }

    function onSessionsGridRowSelect(e) {
        var gridId = e.target.id;
        ReloadSessionsGridToolbar(gridId);
    }

    function onSessionsGridDataBound(e) {
        bvGridOnDataBound(e, 'false');
        ReloadSessionsGridToolbar(e.target.id);
    }