function SelectCurrentItem(e) {

}

var options = {};

function Show(prefix) {
    $("#" + prefix + "SearchPanel").show('slide');
}

function Hide(prefix) {
    $("#" + prefix + "SearchPanel").hide('slide');
}

function CheckValue(e) {
    if (e.value) {
        var id = e.target.id;

        var cbox = $('#' + id).data('tComboBox');
        var text = $('#' + id + '-input');

        if (cbox && cbox.value() == text.val()) {
            if ($('#' + id).attr('class').indexOf('requiredField') > -1)
                cbox.select(0);
            else
                cbox.value('');
        }
    }
}
function ReloadSlaves() {
    var allslaves = $('input[id$="SlaveName"]');
    for (var i = 0; i < allslaves.length; i++) {
        var slaveid = $('#' + allslaves[i].id);
        var rslave = $('#' + slaveid.val()).data('tComboBox');
        var master = $('#' + allslaves[i].id.replace('SlaveName', '')).data('tComboBox');
        if (master.value().length > 0) {
            ReloadSlaveBox(allslaves[i].id.replace('SlaveName', ''), master.value(), rslave, rslave.value());
        }
    }
}

function CleanSlavesValues(masterName) {
    var slaveNameContainer = "#" + masterName + "SlaveName";

    while ($(slaveNameContainer).val()) {

        var slaveName = "#" + $(slaveNameContainer).val();
        var slaveBox = $(slaveName).data('tComboBox');
        slaveNameContainer = slaveName + "SlaveName";
        if (slaveBox) {
            slaveBox.value('');           
        }
    }
}


function ReloadSlaveBox(masterName, masterValue, slave, slaveValue) {
    var params = $('#' + masterName + "ParameterString").val().replace("*value*", masterValue);
    if (slave.ajax) {
        var start = '?';
        if (slave.backupAjax.selectUrl.indexOf('?') != -1) {
            start = '&';
        }
        slave.ajax.selectUrl = slave.backupAjax.selectUrl + start + params;
        slave.reload();
        var slaveinput = $('#' + slave.id + '-input');
        slaveinput.val('');
        // alert(slaveinput.val());
    }
}

function OnComboboxMasterChange(e) {
    CheckValue(e);
    var slave = $('#' + e.target.id + "SlaveName").val();
    var params = $('#' + e.target.id + "ParameterString").val().replace("*value*", e.value);
    var ddl = $('#' + slave).data('tComboBox');
    if (ddl) {
        CleanSlavesValues(e.target.id);
        if (ddl.ajax) {
            start = '?';
            if (ddl.backupAjax.selectUrl.indexOf('?') != -1) {
                start = '&';
            }
            ddl.ajax.selectUrl = ddl.backupAjax.selectUrl + start + params;
            ddl.reload();
            ddl.value('');
        }
    }
}

function OnComboboxSlaveLoad(e) {
    var ddl = $('#' + e.target.id).data('tComboBox');
    if (ddl && ddl.ajax) {
        ddl.backupAjax = new Object;
        ddl.backupAjax.selectUrl = ddl.ajax.selectUrl;
    }
    var helper = $('#LoadingHelper');
    var slavesCount = $('input[id$="SlaveName"]').length;
    if (helper.val() == slavesCount) {
        helper.val(slavesCount + 1);
        ReloadSlaves();
    }
    else {
        helper.val(parseInt(helper.val()) + 1);
    }

}

function ValidateSearchPanel() {
    var mandatory = $("div[class*='requiredField']");
    var flag = true;

    for (var i = 0; i < mandatory.length; i++) {
        if ($("#" + mandatory[i].id + "-input").val().length == 0) {
            flag = false;
            break;
        }
    }
    if (!flag)
        ShowEidssErrorNotification("Please fill all mandatory fields of Search Panel", function () { });
    return flag;
}


function GetAllObjectProps(obj) {
    var str = "";
    for (p in obj) {
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
            var a = date.getMonth();
            a = a - a % 3;
            datefrom = new Date(date.getFullYear(), (a / 3) * 3, 1);
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
        pickerTo.value(new Date(date.getFullYear(), date.getMonth(), date.getDate())); //always to current date
    }
}

function RestoreDefaults() {
    var mandatory = $("div[class*='requiredField']");
    for (var i = 0; i < mandatory.length; i++) {
        var val = $("#Default" + mandatory[i].id);

        if (mandatory[i].id.indexOf('Date') > -1) //date
            $("#" + mandatory[i].id).data("tDatePicker").value(val.val());
        else
            if (mandatory[i].id.indexOf('Int') > -1) //numeric
                $("#" + mandatory[i].id).data("tTextBox").value(val.val());
            else
                if (mandatory[i].id.indexOf('Lookup') > -1) //numeric
                    $("#" + mandatory[i].id).data("tComboBox").value(val.val());
                else
                    $("#" + mandatory[i].id).val(val.val());
    }
}

function ClearSearch(noredirect) {
    $("div#searchpanel input[type='text']:not('.readonlyField')").val("");
    $("div#searchpanel input[class='t-input']").val("");
    $("div#searchpanel input[type='checkbox']").removeAttr("checked");

    var def = "";

    var lookups = $("div#searchpanel div[id^='Lookup']");
    for (i = 0; i < lookups.length; i++) {
        $("#" + lookups[i].id).data('tComboBox').value(null);
    }

    var req = $("div[class*='requiredField']");

    for (i = 0; i < req.length; i++) {
        def = $("#Default" + req[i].id).val();
        if (req[i].id.indexOf("Lookup") > -1)
            $("#" + req[i].id).data('tComboBox').value(def);
        else
            if (req[i].id.indexOf('Date') > -1)
                $("#" + req[i].id).data('tDatePicker').value(def);
    }


}

function onHideListFormSearchPanel() {
    $("#btHideListFormSearch").hide();
    $("#btShowListFormSearch").show();
    $("#searchpanel").hide();
}

function onShowListFormSearchPanel() {
    $("#btHideListFormSearch").show();
    $("#btShowListFormSearch").hide();
    $("#searchpanel").show();
}

function GridUpdateAfterSearch(result, keepPage) {

    if (!result.data) {
        window.location = '/' + GetSiteLanguage() + '/Account/Logout';
        return;
    }

    var grid = $("#Grid").tGrid('tGrid').data('tGrid'); ;
    var pg = grid.currentPage;

    var selindex = $("#Grid tr.t-state-selected").index();

    grid.total = result.total;
    grid.dataBind(result.data);

    if (!keepPage) {
        pg = 1;
    }
    if (!keepPage || selindex == -1) {
        selindex = 0;
        $("#NeedsFirstRowSelection").val("0");
    }
    else {
        $("#NeedsFirstRowSelection").val(selindex);
    }

    grid.pageTo(pg);


}

function SearchOnOkSuccessHandler(result) {          
    GridUpdateAfterSearch(result, true);
}

function SearchSuccessHandler(result) { 
        GridUpdateAfterSearch(result, false);    
}

function AjaxSearch(SuccessHandler) {
    if (!ValidateSearchPanel())
        return;

    var formString = $('form').formSerialize();
    var action = $('form').attr('action');
    $.ajax({
        url: action,
        type: "POST",
        data: formString,
        success: function (result) {
            if (SuccessHandler)
                SuccessHandler(result);
            else
                SearchSuccessHandler(result);
        }
    });
}


function onSearchPickerResultGridLoad(e) {
    if (!$("#Grid")) { return; }
    $("#Grid tbody>tr").click(function () {
        var idTd = $(this).find(".gridId");
        if (idTd.length == 1) {
            var id = idTd[0].innerHTML;
            if ($("#grid_selecteditem")) {
                $("#grid_selecteditem").val(id);
            }
        }
    });
}
