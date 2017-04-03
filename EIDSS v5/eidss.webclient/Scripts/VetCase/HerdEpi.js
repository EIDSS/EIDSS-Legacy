function ReloadHerdFlockGridToolbar(gridId) {

    var btDelete = $("#" + gridId + " .t-grid-toolbar #btDelete");
    var btEdit = $("#" + gridId + " .t-grid-toolbar #btEdit");
    var btNewSpecies = $("#" + gridId + " .t-grid-toolbar #btNewSpecies");
    var btClinicalSigns = $("#" + gridId + " .t-grid-toolbar #btClinicalSigns");

    DisableGridButton(btDelete);
    DisableGridButton(btEdit);
    DisableGridButton(btNewSpecies);
    DisableGridButton(btClinicalSigns);

    var selectedRow = $("#" + gridId + " tr.t-state-selected");
    if (selectedRow.length == 0) {
        return;
    }

    var type = selectedRow.find("[name='PartyType']").attr('value');

    if (type == "10072004") { // species
        EnableGridButton(gridId, btDelete);
        EnableGridButton(gridId, btEdit);
        EnableGridButton(gridId, btClinicalSigns);
    }

    if (type == "10072003") { // herd or flock
        EnableGridButton(gridId, btDelete);
        EnableGridButton(gridId, btNewSpecies);
    }
}

function onHerdFlockGridRowSelect(e) {
    var gridId = e.target.id;
    ReloadHerdFlockGridToolbar(gridId);
}

function onHerdFlockGridDataBound(e) {
    bvGridOnDataBound(e, 'false');
    ReloadHerdFlockGridToolbar(e.target.id);
}

function itemIsSpecies(gridId) {
    var key = $("#" + gridId + " tr.t-state-selected").find("[name='PartyType']").attr("value");
    return (key == 10072004);
}
