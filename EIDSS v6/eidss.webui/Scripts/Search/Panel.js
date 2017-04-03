$(document).ready(function () {
    form = $('#form');
    $("#Grid tbody>tr").click(function () {
        var id = $(this).find("[name='id']").attr('value');
        $("#grid_selecteditem").val(id);
    });
});


function ClearSelection(e) {
    $("#grid_selecteditem").val("");
}

var options = {};

function Show(prefix) {
    $("#" + prefix + "SearchPanel").show('slide');
}

function Hide(prefix) {
    $("#" + prefix + "SearchPanel").hide('slide');
}

function OnComboboxMasterChange(e) {
    var slave = $('#' + e.target.id + "SlaveName").val();
    var params = $('#' + e.target.id + "ParameterString").val().replace("*value*", e.value);
    var ddl = $('#' + slave).data('tComboBox');
    if (ddl.ajax) {
        start = '?';
        if (ddl.backupAjax.selectUrl.indexOf('?') != -1) {
            start = '&';
        }
        ddl.ajax.selectUrl = ddl.backupAjax.selectUrl + start + params;
        ddl.reload();
    }
}

function OnComboboxSlaveLoad(e) {
    var ddl = $('#' + e.target.id).data('tComboBox');
    if (ddl && ddl.ajax) {
        ddl.backupAjax = new Object;
        ddl.backupAjax.selectUrl = ddl.ajax.selectUrl;
    }
}


function GetAllObjectProps(obj) {
    var str = "";
    for(p in obj)
    {
        str += p + ': ' + obj[p] + '\r\n';
    }
    return str;
}

function FillStandardRange(range, idfrom, idto) {
    var date = new Date();
    var datefrom;    
    if (range == "month") {
         datefrom = new Date(date.getFullYear(), date.getMonth(), 1);        
    }
    else {
        if (range == "quarter") {
               datefrom = new Date(date.getFullYear(), 3*(date.getMonth() / 3), 1);                              
        }
        else {
            if (range == "year") {
                 datefrom = new Date(date.getFullYear(), 0, 1);                    
            }
        }
    }    
    var pickerFrom = $("#" + idfrom).data("tDatePicker");
    var pickerTo = $("#" + idto).data("tDatePicker");
    if (pickerFrom && pickerTo) {
        pickerFrom.value(datefrom);
        pickerTo.value(new Date(date.getFullYear(),date.getMonth(),date.getDate())); //always to current date
    }
}

function ClearSearch() {
    //$("input[type='text']").val("");
    $("input[class='t-input']").val("");
    $("input[type='text']").val("");
}