function load(results) {
    for (res in results) {
        if (res.indexOf('idfSpecies') == -1)
            $("#" + res).val(results[res]);
        else {
            var cbox = $("#" + res).data('tComboBox');
            cbox.dataBind(results[res]);
        }
    }
    var idFarm = $("input[type='hidden'][name$='idfFarm']");
    ModelFieldChanged(idFarm.attr('name'), idFarm.val());
    hideLoading();
}

function onSpeciesChange(e) {
    if (e.previousValue == e.value) { return; }
    ApplyContainer.argument = e;
    //ApplyContainer.onAjaxSuccess = enableSelections;        
    $('#Samples').enable(true);
    ModelFieldChangedCombobox(e);
}

function enableDiagnosis(e) {
    if (e.newValue > 0)
        $('#Diagnosis').enable(true);
    else
        $('#Diagnosis').enable(false);
}

function diagnosisSelected(data) {
    $('#strDiagnosis').html(data);    
    $('#Message').data('tWindow').close();
}
function cancelSelection() {
    $('#Message').data('tWindow').close();
}

function FarmIdSelected(id,real) {
    if (id.length > 0) {
        var idFarmActual = $("input[type='hidden'][name$='idfFarmActual']");
        var idFarm = $("input[type='hidden'][name$='idfFarm']");
        idFarmActual.val(id);
        if (real) idFarm.val(real);
        $('#Message').data('tWindow').close();
        //  alert(id);
        showLoading();
        GetSpeciesList(id, idFarm.val());
    }
}

function RootFarmRefreshed(root,real) {
    var idFarmActual = $("input[type='hidden'][name$='idfFarmActual']");
  //  if (actual)
    idFarmActual.val(root);
    var idFarm = $("input[type='hidden'][name$='idfFarm']");
    idFarm.val(real);
    FarmIdSelected(idFarmActual.val(),real);
}