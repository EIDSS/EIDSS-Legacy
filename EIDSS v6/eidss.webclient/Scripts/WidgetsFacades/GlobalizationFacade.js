var globalizationFacade = (function () {
    return {
        toFormatString: function (format, data) {
            if (data) {
                return kendo.format(format, data);
            }
            return "";
        },
        
        toString: function (format, data) {
            if (data) {
                var ret = kendo.toString(data, format);
                return ret;
            }
            return "";
        }

    };
})();