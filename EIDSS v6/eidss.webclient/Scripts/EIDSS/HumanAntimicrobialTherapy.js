var humanAntimicrobialTherapy = {
    showGridEditWindow: function (id, listKey, gridName) {
        var url = bvUrls.getHumanAntimicrobialTherapyPickerUrl() + "?key=" + listKey + "&name=" + gridName + "&id=" + id;
        bvGrid.showEditWindow(url, 680, 350, EIDSS.BvMessages['titleAntibiotic']);
    },
    
    /*showGridAddWindow: function (listKey, atName) {
        var url = bvUrls.getHumanAntimicrobialTherapyPickerUrl() + "?key=" + listKey + "&name=" + atName + "&id=0";
        bvPopup.showDefault(url, EIDSS.BvMessages['titleAntibiotic'], 680, 350, false);
    },*/

    saveAndCloseGridEditWindow: function (caseObjectIdent) {
        var ident = caseObjectIdent.substring(0, caseObjectIdent.lastIndexOf("_") + 1);
        var gridId = ident + 'AntimicrobialTherapy';
        bvGrid.saveAndCloseEditWindow(gridId, bvUrls.getSetHumanAntimicrobialTherapyUrl());
    }
}