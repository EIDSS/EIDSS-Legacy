var listForm = {
    pageOnLoad: function() {
        listForm.changeFont();
        listForm.setGridHeight(".lfGrid");
    },

    changeFont: function() {
        var curLang = bvUrls.getLanguage();
        if (curLang === "hy-AM" || curLang === "ka-GE") {
            $("body").addClass("amGe");
        }
    },

    getSelectedItemId: function() {
        var gridId = $(".lfGrid").attr("id");
        return bvGrid.getSelectedItemId(gridId);
    },

    hideIconMenu: function() {
        $("#IconMenu .navigationMenu").hide();
        $("#ShowMenuArrow").show();
    },
    
    showIconMenu: function() {
        $("#IconMenu .navigationMenu").show();
        $("#ShowMenuArrow").hide();
    },

    showInfoWindow: function () {
        bvPopup.initAndShowModal("PopupWindow", bvUrls.getAboutUrl(), EIDSS.BvMessages.strInfo, 580, 240);
    },
    
    closeWindow: function () {
        windowFacade.closeById("PopupWindow");
    },
    
    openHelp: function (context) {
        if (context)
            bvWindow.show(bvUrls.getHelpUrl() + "?" + context + ".htm", "");
        else
            bvWindow.show(bvUrls.getHelpUrl(), "");
    },
    
    setGridHeight: function (gridSelector) {
        var gridElement = $(gridSelector);
        if (gridElement.length == 0) {
            return;
        }
        var gridheight = gridElement.height();
        var contentClassName = gridFacade.contentClassName;
        var gridContent = gridElement.find("." + contentClassName);
        var otherGridElements = gridElement.children().not("." + contentClassName);
        var contentHeight = gridheight - 2;
        var count = otherGridElements.length;
        for (var i = count - 1; i--;) {
            contentHeight -= otherGridElements[i].offsetHeight;
        }
        gridContent.css("min-height", contentHeight + "px");
    }
}