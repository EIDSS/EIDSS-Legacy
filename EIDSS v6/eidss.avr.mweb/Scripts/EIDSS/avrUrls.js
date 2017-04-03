var avrUrls = (function () {
    var regExp = /(http(s?):\/\/)/ig;
    var currentLang = null;

    var paths = {
        accountLogin:"/Account/LoginLang",
        timeout: "/Account/Timeout",
        heartbeat: "/Account/Heartbeat",
        queryLayoutTree: "/QueryLayoutTree/QueryLayoutTree",
        editTreeNode: "/QueryLayoutTree/EditTreeNode",
        deleteTreeNode: "/QueryLayoutTree/QueryLayoutTreeDeletePartial",
        canDeleteTreeNode: "/QueryLayoutTree/CanDeleteTreeNode",
        copyTreeNode: "/QueryLayoutTree/CopyNode",
        layout: "/Layout/Layout",
        view:"/ViewLayout/ViewLayout",
        viewRefresh: "/ViewLayout/OnRefreshData",
        //viewChartOpen: "/ViewLayout/ChartOpen",
        viewIsChanged: "/ViewLayout/IsChanged",
        viewReset: "/ViewLayout/OnResetView",
        viewCancelChanges: "/ViewLayout/OnCancelChanges",
        viewClose: "/ViewLayout/OnClose",
        viewAddAggregate: "/ViewLayout/AddAggregate",
        viewIfAggregate: "/ViewLayout/IsAggregate",
        viewDeleteAggregate: "/ViewLayout/DeleteAggregate",
        viewMapDefDataChart: "/ViewLayout/OnMapDefDataChart",
        viewChartDefXaxis: "/ViewLayout/OnChartDefXaxis",
        viewChartDefSeries: "/ViewLayout/OnChartDefSeries",
        viewMapDefDataGradient: "/ViewLayout/OnMapDefDataGradient",
        viewMapDefAdminUnit: "/ViewLayout/OnMapDefAdminUnit",
        viewColBandChanged: "/ViewLayout/ColBandChanged",
        viewColumnMoving: "/ViewLayout/ColumnMoving",
        exportQuery: "/QueryLayoutTree/ExportQuery",
        chartOpen: "/Chart/Index",
        chartTypeChanged: "/Chart/ChartTypeChanged",
        mapOpen: "/Map/Index",
    };

    function setLanguage() {
        var lang = document.URL.replace(regExp, "", "$1");
        lang = lang.substring(lang.indexOf("/") + 1, lang.length);
        currentLang = lang.substring(0, lang.indexOf("/"));
    }

    return {
        getLanguage: function() {
            if (!currentLang) {
                setLanguage();
            }
            return currentLang;
        },

        // examples of path: '/System/SetValue', bvUrls.paths.systemSetValue
        getByPath: function(path) {
            return '/' + avrUrls.getLanguage() + path;
        },
        
        getAccountLogin: function () {
            return avrUrls.getByPath(paths.accountLogin);
        },

        getTimeoutUrl: function () {
            return avrUrls.getByPath(paths.timeout);
        },

        getHeartbeatUrl: function () {
            return avrUrls.getByPath(paths.heartbeat);
        },

        getQueryLayoutTreeUrl: function () {
            return avrUrls.getByPath(paths.queryLayoutTree);
        },
        
        getEditTreeNodeUrl: function () {
            return avrUrls.getByPath(paths.editTreeNode);
        },
        
        getDeleteTreeNodeUrl: function () {
            return avrUrls.getByPath(paths.deleteTreeNode);
        },
        
        getCopyTreeNodeUrl: function () {
            return avrUrls.getByPath(paths.copyTreeNode);
        },

        getLayoutUrl: function() {
            return avrUrls.getByPath(paths.layout);
        },
        getViewUrl: function () {
            return avrUrls.getByPath(paths.view);
        },

        getViewRefreshUrl: function () {
            return avrUrls.getByPath(paths.viewRefresh);
        },

        //getViewChartOpenUrl: function () {
        //    return avrUrls.getByPath(paths.viewChartOpen);
        //},

        getIsChangedUrl: function () {
            return avrUrls.getByPath(paths.viewIsChanged);
        },

        getResetUrl: function () {
            return avrUrls.getByPath(paths.viewReset);
        },

        getCancelChangesUrl: function () {
            return avrUrls.getByPath(paths.viewCancelChanges);
        },

        getCloseUrl: function () {
            return avrUrls.getByPath(paths.viewClose);
        },

        getAddAggregateUrl: function () {
            return avrUrls.getByPath(paths.viewAddAggregate);
        },

        getIfAggregateUrl: function () {
            return avrUrls.getByPath(paths.viewIfAggregate);
        },

        getDeleteAggregateUrl: function () {
            return avrUrls.getByPath(paths.viewDeleteAggregate);
        },

        getMapDefDataChartUrl: function () {
            return avrUrls.getByPath(paths.viewMapDefDataChart);
        },

        getChartDefXaxisUrl: function () {
            return avrUrls.getByPath(paths.viewChartDefXaxis);
        },

        getChartDefSeriesUrl: function () {
            return avrUrls.getByPath(paths.viewChartDefSeries);
        },

        getMapDefDataGradientUrl: function () {
            return avrUrls.getByPath(paths.viewMapDefDataGradient);
        },

        getMapDefAdminUnitUrl: function () {
            return avrUrls.getByPath(paths.viewMapDefAdminUnit);
        },

        getColBandChangedUrl: function () {
            return avrUrls.getByPath(paths.viewColBandChanged);
        },

        getColumnMovingUrl: function () {
            return avrUrls.getByPath(paths.viewColumnMoving);
        },


        getExportQueryUrl: function () {
            return avrUrls.getByPath(paths.exportQuery);
        },
        
        getCanDeleteTreeNodeUrl: function () {
            return avrUrls.getByPath(paths.canDeleteTreeNode);
        },
        
        getChartOpenUrl: function () {
            return avrUrls.getByPath(paths.chartOpen);
        },

        getChartTypeChangedUrl: function () {
            return avrUrls.getByPath(paths.chartTypeChanged);
        },

        getMapOpenUrl: function () {
            return avrUrls.getByPath(paths.mapOpen);
        },

        
    };
})();