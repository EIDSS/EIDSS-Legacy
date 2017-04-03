function RootFarmRefreshed(idroot,id) {
    var idFarmActual = $("input[type='hidden'][name$='idfFarmActual']");
    if (idroot)
        idFarmActual.val(idroot);
    var idFarm = $("input[type='hidden'][name$='idfFarm']");
    idFarm.val(id);
    FarmIdSelected(idroot, id);
}

function FarmIdSelected(idroot, id) {
    if (idroot.length > 0) {
        var idFarmActual = $("input[type='hidden'][name$='idfFarmActual']");
        var idFarm = $("input[type='hidden'][name$='idfFarm']");

        idFarmActual.val(idroot);
        idFarm.val(id);
        $('#Message').data('tWindow').close();        
        
        GetSpeciesList(idroot , id);
    }
}

function GetUpdate(url, idvalue, onsuccess, idsession) {
    showLoading();
    $.ajax({
        url: url,
        cache: false,
        dataType: "json",
        type: "GET",
        data: {
            idfMonitoringSession: idsession,
            idValue: idvalue
        },
        success: function (data) {
            if (data.toString().indexOf('Error') == -1)
                onsuccess(data);
            else
                alert(data);
            hideLoading();
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(jqXHR.status);
        }
    });

}

function load(results, cboxname) {
    for (res in results) {
        if (res.indexOf(cboxname) == -1)
            $("#" + res).val(results[res]);
        else {
            var cbox = $("#" + res).data('tComboBox');
            cbox.dataBind(results[res]);
        }
    }
    var idFarm = $("input[type='hidden'][name$='idfFarm']");
    ModelFieldChanged(idFarm.attr('name'), idFarm.val());
}

function loadWithKey(results) {
    var cbox = $("#" + results.Key).data('tComboBox');
    cbox.dataBind(results.Value);
}

function onSpeciesChange(e) {
    if (e.previousValue == e.value) { return; }
    CBoxValueIsValid(e.target.id);
    ApplyContainer.argument = $('#' + e.target.id).data('tComboBox').value();
    ApplyContainer.onAjaxSuccess = GetAnimalsList;
    ModelFieldChangedCombobox(e);
}