function onHumanAntimicrobialTherapyPickerChanged(o) {
    var ObjectIdent = o.substring(0, o.lastIndexOf("_") + 1);
    var gridId = ObjectIdent + 'AntimicrobialTherapy';
    CloseEditWindowAndUpdateGrid(gridId, "../HumanCase/SetHumanAntimicrobialTherapy");    
}