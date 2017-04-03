$(function () {
    //dialog init
    $('#dialog').dialog({
        autoOpen: false,
        modal: false,
        width: 600,
        buttons: {
            "Ok": function () {
                $(this).dialog("close");
            }
        }
    });
    return false;
}
);

function test1() {
    alert('test1');
}

//dialog with two buttons
function ShowEidssDialog(title, text, button1Text, button1callback, button2Text) {    
    $("#dialog").dialog("option", "title", title);
    //$("#dialog").text(text);
    $("#dialog").html(text);
    $("#dialog").dialog("option", "buttons", [
    {
        text: button1Text
        ,click: function () {            
            button1callback();
            $(this).dialog("close");
        }
    }
    ,
    {
        text: button2Text
        ,click: function () {            
            $(this).dialog("close");
        }
    }
    ]);
    $('#dialog').dialog('open');
    return false;
}

var msgConfimation = EIDSS.BvMessages['msgConfimation'];
var strOK_Id = EIDSS.BvMessages['strOK_Id'];
var strCancel_Id = EIDSS.BvMessages['strCancel_Id'];


function ShowEidssDialogSavePrompt(button1callback) {
    ShowEidssDialog(msgConfimation, EIDSS.BvMessages['msgSavePrompt'], strOK_Id, button1callback, strCancel_Id);
}

function ShowEidssDialogCancelPrompt(button1callback) {    
    ShowEidssDialog(msgConfimation, EIDSS.BvMessages['msgCancelPrompt'], strOK_Id, button1callback, strCancel_Id);
}

function ShowEidssDialogOKPrompt(button1callback) {
    ShowEidssDialog(msgConfimation, EIDSS.BvMessages['msgOKPrompt'], strOK_Id, button1callback, strCancel_Id);
}

function ShowEidssDialogDeletePrompt(button1callback) {
    ShowEidssDialog(msgConfimation, EIDSS.BvMessages['msgDeletePrompt'], strOK_Id, button1callback, strCancel_Id);
}



