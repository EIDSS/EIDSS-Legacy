var listForm = {
    pageOnLoad: function (timeZoneOffset) {
        bvGrid.timeOffsetInHours = timeZoneOffset;
        changeFont();
        listForm.setGridHeight(".lfGrid");
    },

    resizeTable: function () {
        if ($(".header").length == 1) {
            var width = $(window).width();
            if (width < 1024) {
                width = 1024;
            }
            if ($(".content").length == 1) {
                var w1 = width - 16;
                $(".content")[0].style.width = w1.toString() + "px";
                $(".content").css({ "min-width": w1.toString() + "px" });
                $(".content").css({ "max-width": w1.toString() + "px" });
            }
            if ($("#Grid").length == 1) {
                var w2 = width - 48;
                $("#Grid")[0].style.width = w2.toString() + "px";
                $("#Grid").css({ "min-width": w2.toString() + "px" });
                $("#Grid").css({ "max-width": w2.toString() + "px" });
            }
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
        bvPopup.initAndShowModal("PopupWindow", bvUrls.getAboutUrl(), EIDSS.BvMessages.strInfo, "", 580, 240);
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
    
    openCbt: function () {
        bvWindow.show(bvUrls.getCbtUrl(), "");
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