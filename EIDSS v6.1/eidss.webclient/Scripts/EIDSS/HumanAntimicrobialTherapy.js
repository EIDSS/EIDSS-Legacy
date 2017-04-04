var humanAntimicrobialTherapy = {
    showGridEditWindow: function (id, listKey, gridName) {
        var url = bvUrls.getHumanAntimicrobialTherapyPickerUrl({key: listKey, name: gridName, id: id});
        bvGrid.showEditWindow(url, 680, 350, EIDSS.BvMessages['titleAntibiotic'], "H17");
    },
    
    saveAndCloseGridEditWindow: function (caseObjectIdent) {
        var ident = caseObjectIdent.substring(0, caseObjectIdent.lastIndexOf("_") + 1);
        var gridId = ident + 'AntimicrobialTherapy';
        bvGrid.saveAndCloseEditWindow(gridId, bvUrls.getSetHumanAntimicrobialTherapyUrl());
    }
}