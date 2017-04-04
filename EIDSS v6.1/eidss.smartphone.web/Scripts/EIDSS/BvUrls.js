var bvUrls = (function () {
    var regExp = /(http(s?):\/\/)/ig;
    var currentLang = null;

    // examples of path: '/Controller/Action' (begins from slash, ends without slash)
    var paths = {
        about: "/Account/About",
        home: "/Home/Index",
        timeout: "/Account/Timeout",
        heartbeat: "/Account/Heartbeat",
        help: "/HelpRouter.htm",
        uploadFile: "/Home/UploadFile",

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
            return '/' + bvUrls.getLanguage() + path;
        },
        
        getHeartbeatUrl: function () {
            return bvUrls.getByPath(paths.heartbeat);
        },


        getHomeUrl: function () {
            return bvUrls.getByPath(paths.home);
        },

        getTimeoutUrl: function () {
            return bvUrls.getByPath(paths.timeout);
        },

        getAboutUrl: function () {
            return bvUrls.getByPath(paths.about);
        },
        
        getHelpUrl: function () {
            //return bvUrls.getByPath(paths.help);
            return paths.help;
        },

        getUploadFileUrl: function () {
            return bvUrls.getByPath(paths.uploadFile);
        },

    };
})();