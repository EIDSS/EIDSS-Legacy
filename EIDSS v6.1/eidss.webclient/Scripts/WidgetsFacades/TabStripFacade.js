var tabStripFacade = (function () {
    return {
        getActiveTabContentSelector: function (tabStripId) {
            var selector = "#" + tabStripId + " .k-content.k-state-active ";
            return selector;
        },
        
        getOnSelectEventArgs: function (e) {
            var element = $(e.item);
            var data = {
                slectedTabIndex: element.index()
            };
            return data;
        },
    };
})();