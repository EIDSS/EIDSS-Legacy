var popupMenu = (function () {

    return {

        pageOnLoad: function(action, root) {
            $('body').click(popupMenu.hidePopupMenu);

            $('.k-grid-content').contextmenu(function(event) {
                 popupMenu.icontext(action, root, event);
            });
        },

        icontext: function(action, root, event) {
            var sel = bvGrid.getSelectedItemId("Grid");
            if (sel != "") {
                var selected = $(event.target.parentElement).hasClass("k-state-selected");
                if (selected) {
                    popupMenu.showPopupMenu(action, sel, root, event.pageX, event.pageY);
                }
            }

            if (event.preventDefault)
                event.preventDefault();
            else
                event.returnValue = false;
            return false;
        },

        hidePopupMenu: function() {
            $("#menuDiv")[0].style.visibility = "hidden";
        },

        hidePopupMenuAndUnbind: function() {
            $("#menuDiv")[0].style.visibility = "hidden";
            $('body').off("click", popupMenu.hidePopupMenuAndUnbind);
        },


        hidePopupMenuClear: function () {
        },

        showPopupMenu: function (action, idents, root, x, y) {
            var url = bvUrls.getByPath("/PopupMenu/" + action);
            $.ajax({
                url: url,
                cache: false,
                async: false,
                dataType: "json",
                type: "GET",
                data: {
                    root: root,
                    idents: idents
                },
                success: function (data) {
                    var menu = $("#menuPopup").data("kendoMenu");
                    var len = menu.element.children("li").length;
                    menu.append(data, "#menuPopup");
                    for (var i = 0; i < len; i++)
                        menu.remove(menu.element.children("li").eq(0));

                    var menuHeihgt = $("#menuDiv").height();
                    var browserWindow = $(window);
                    var browserWindowHeight = browserWindow.height();
                    var browserWindowScrollPosition = browserWindow.scrollTop();
                    if (y + menuHeihgt > browserWindowHeight + browserWindowScrollPosition) {
                        y = browserWindowHeight + browserWindowScrollPosition - menuHeihgt;
                    }

                    $("#menuDiv")[0].style.visibility = "visible";
                    $("#menuDiv")[0].style.left = x.toString() + "px";
                    $("#menuDiv")[0].style.top = y.toString() + "px";
                    $("#menuDiv")[0].style.width = "200px";
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    bvDialog.showAuthenticationError(jqXHR, textStatus, errorThrown);
                }
            });
        },

        executeFunctionByName: function (functionName, context /*, args */) {
            var args = Array.prototype.slice.call(arguments).splice(2);
            var namespaces = functionName.split(".");
            var func = namespaces.pop();
            for(var i = 0; i < namespaces.length; i++) {
                context = context[namespaces[i]];
            }
            return context[func].apply(this, args);
        },

        select: function (e, selector) {
            var root = $(e.item).children(".k-link").children("span").attr("root");
            var idents = $(e.item).children(".k-link").children("span").attr("idents");
            var name = $(e.item).children(".k-link").children("span").attr("action");
            var method = $(e.item).children(".k-link").children("span").attr("method");

            if (root && idents && method) {
                popupMenu.executeFunctionByName(method, window, root, idents, name);
            }
            else if (root && method) {
                popupMenu.hidePopupMenu();
                popupMenu.executeFunctionByName(method, window, root, idents, name);
            }
            else if (root && idents && name) {
                var url = bvUrls.getByPath("/PopupMenu/" + selector);
                showLoading();
                $.ajax({
                    url: url,
                    cache: false,
                    async: true,
                    dataType: "json",
                    type: "GET",
                    data: {
                        root: root,
                        idents: idents,
                        name: name
                    },
                    success: function (data) {
                        hideLoading();
                        var hasError = formRefresher.hasError(data);
                        if (hasError) {
                            formRefresher.updateControls(data);
                        } else {
                            bvGrid.reloadById("Grid");
                        }
                    },
                    error: function(jqXHR, textStatus, errorThrown) {
                        hideLoading();
                        bvDialog.showAuthenticationError(jqXHR, textStatus, errorThrown);
                    }
                });
            }
        },
    };

})();
