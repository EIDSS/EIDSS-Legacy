var duplicateVariables = {
    'strLastName': '',
    'strFirstName': '',
    'datDateofBirth': '',
    'strSecondName': '',
    'strLocalIdentifier': '',
    'TentativeDiagnosis': '',
    'FinalDiagnosis' :''
    };



function CreateWindow(url, title) {    
    $.get(
                url,              
                function (data) {
                    $("#adjavantcontent").html(data);                 
                }
    );
    $("#dialog").dialog("option", "title", title);
    $("#dialog").dialog("open");
    $("#dialog").dialog("option", "buttons", null);
    //ShowEidssDialogSavePrompt(function () { alert('ok'); });
}
function GetDuplicates() {
    //get all parameters for search
    var val = null;    
    var result = '?';
    for(key in duplicateVariables) {
        val = $("input[name$='" + key + "']");
        if (val && val.val())
            result += key + '=' + escape(val.val()) + '&';
    }
    if (result.length == 1)
        return;
    result = '/HumanCase/Duplicates' + result.substring(0, result.length - 1);
    var windowElement = $('#Message');
    windowElement.data('tWindow').ajaxRequest(result);
    windowElement.css({
        left: 300,
        top: 150,
        width: 630,
        height: 380
    }).data('tWindow').open();


    //    var windowElement = $('#Message');
    //    windowElement.data('tWindow').ajaxRequest(result);
    //    windowElement.css({
    //        left: 300,
    //        top: 150,
    //        width: 600,
    //        height: 380
    //    }).data('tWindow').open();
    //    alert(windowElement);
    //    windowElement.title('Duplicates search');
    //    windowElement.data('tWindow').open();
    // OpenModal(result, 'Duplicates search');

    //    var windowElement = $.telerik.window.create({
    //        title: 'Duplicates search',
    //        contentUrl: result,
    //        modal: true,
    //        resizable: true,
    //        draggable: true,
    //        scrollable: true,
    //        onClose: function (e) {
    //            e.preventDefault();
    //            windowElement.data('tWindow').destroy();
    //        }
    //    });

    //    windowElement.css({
    //        width: 600,
    //        height: 380
    //    }).data('tWindow').center().open();
}