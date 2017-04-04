var windowFacade = (function () {
    var defaultSize = { width: 300, height: 160 };

    function initModal(id, content, title, width, heigth, onClose) {
        $("#" + id).remove();
        $("<div id='" + id + "'></div>").insertAfter('.page');
        $("<div id='" + id + "'></div>").insertAfter('.pageDefault');
        var modalWindow = $("#" + id).kendoWindow({
            width: width,
            height: heigth,
            title: title,
            visible: false,
            modal: true,
            resizable: false,
            actions: ["Close"],
            animation: false,
            content: content,
            open: onOpen,
            close: onClose
        });
        return modalWindow;
    }

    function initModalWithUrl(id, url, title, width, heigth) {
        var modalWindow = initModal(id, url, title, width, heigth);
        return modalWindow;
    }

    function initModalWithHtml(id, htmlContent, title, width, heigth, onClose) {
        $("#" + id).remove();
        $("<div id='" + id + "'></div>").insertAfter('.page');
        $("<div id='" + id + "'></div>").insertAfter('.detailsPage');
        var control = $("#" + id);
        control.html(htmlContent);
        var modalWindow = control.kendoWindow({
            width: width,
            height: heigth,
            title: title,
            visible: false,
            modal: true,
            resizable: false,
            actions: ["Close"],
            animation: false,
            open: onOpen,
            close: onClose
        });
        return modalWindow;
    }
    
    function getData(control) {
        return control.data("kendoWindow");
    }

    function getModal(id, url, title, width, heigth) {
        var modalWindow = getData($("#" + id));
        width = !width ? defaultSize.width : width;
        heigth = !heigth ? defaultSize.heigth : heigth;

        if (!modalWindow) {
            modalWindow = initModalWithUrl(id, url, title, width, heigth);
            modalWindow = getData(modalWindow);
        }
        else {
            modalWindow.setOptions({
                width: width,
                height: heigth,
            });
            modalWindow.title(title);
            modalWindow.refresh(url);
        }
        return modalWindow;
    }
    
    function onOpen(e) {
        var id = e.sender.element[0].id;
        centerWindowFix(id);
    }
    
    function centerWindowFix(id) {
        var popupWindow = $("#" + id).closest(".k-window");
        if (popupWindow.length == 0)
            popupWindow = $("#" + id);
        if (popupWindow.length > 0) {
            var browserWindow = $(window);
            var browserWindowHeight = browserWindow.height();
            var browserWindowScrollPosition = browserWindow.scrollTop();
            var popupWindowHeight = popupWindow[0].style.pixelHeight;
            var newPopupTop = (browserWindowHeight - popupWindowHeight) / 2 + browserWindowScrollPosition;
            newPopupTop = newPopupTop < 0 ? 0 : newPopupTop;
            popupWindow.css({ top: newPopupTop });
            $("#" + id).closest(".k-window").css({
                top: newPopupTop
            });
        }
    }

    return {
        initModal: function(id, htmlContent, title, width, heigth, onClose) {
            var modalWindow = initModalWithHtml(id, htmlContent, title, width, heigth, onClose);
            return modalWindow;
        },

        initAndShowModal: function (id, url, title, width, heigth) {
            var modalWindow = getModal(id, url, title, width, heigth);
            modalWindow.center().open();
        },

        openWindowInCenter: function (windowData) {
            windowData.center().open();
        },

        getWindowData: function(control) {
            return getData(control);
        },

        closeById: function (id) {
            var modalWindow = getData($("#" + id));
            if (modalWindow) {
                modalWindow.close();
                modalWindow.destroy();
            }
        },
        
        cleanById: function (id) {
            $("#" + id).data("kendoWindow").restore();
        },

        addFormNumber: function (id, formNumber) {
            $("#" + id).parent().find(".k-window-title").after("<span class='windowNumber'>" + formNumber + "</span>");
        }
    };
})();