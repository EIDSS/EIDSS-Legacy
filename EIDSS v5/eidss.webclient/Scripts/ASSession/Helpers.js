
function CreateCase(url) {
    var tab = $('#FullDetails').data('tTabStrip');
    var idfFarm = $('div[id$="_ASSamples"] tr.t-state-selected').find("[name='idfFarm']").attr("value");
    if (!idfFarm) {
        alert('Farm is not selected');
        return;
    }
    else {
        $('input[type="hidden"][id$="_idfFarmForCaseCreation"]').val(idfFarm);
        checkChanges(ASSessionSaveAndCreateCase, ActionSaveExecution);
        //ShowEidssDialogSavePrompt(ActionSaveExecution);
    }
}

function ASSessionSaveAndCreateCase() {
    if ($("#SaveAndExitClick").length > 0) {
        $("#SaveAndExitClick")[0].value = '0';
    }    
    ShowEidssOkCancelDialog(
        msgConfimation,
        EIDSS.BvMessages['msgSavePrompt'],
        ActionSaveExecution,
        function () {
            $('input[type="hidden"][id$="_idfFarmForCaseCreation"]').val(''); 
        });    
}
function enableCaseCreation(e) {
    var item = $(e.item);
    $('#bMainPanel_CreateCase').enable((item.index() == 0));

}

function confirmCampaignAssignment() {
    var pusher = $("input[type='hidden'][name$='blnForceCampaignAssignment']");    
    ApplyContainer.argument = "Diseases";
    ApplyContainer.onAjaxSuccess = gridItemAdded;
    ModelFieldChanged(pusher.attr('name'), true);
}

function cancelCampaignAssignment() {
    var idCampaign = $("input[type='hidden'][name$='idfCampaign']");
    idCampaign.val('');
}

function getCampaignAssignmentConfirmation(message) {
    //TODO find out a better way to check the kind of the message
    var sep = message.indexOf(':');
    var msgtype =  message.substring(0, sep);
    message = message.substring(sep+1, message.length);
    
    if (msgtype == 'Confirmation')
        ShowEidssYesNoDialog('Warning', message, confirmCampaignAssignment, cancelCampaignAssignment);
    else
        ShowEidssErrorNotification(message, cancelCampaignAssignment);
}