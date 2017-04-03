(function ($) {
    $.fn.hasScrollBar = function () {
        return this.get(0).scrollHeight > this.height();
    };
})(jQuery);

function OpenPopup(link, title, windowWidth, windowHeigth, notGeneratedTitle) {
    var winTitle = title.replace(" ", "") + Math.round((Math.random() * 1000)).toString();

    if (notGeneratedTitle) {
        winTitle = title;
    }

    if (!windowWidth) {
        windowWidth = 1024;
    }

    if (!windowHeigth) {
        windowHeigth = 700;
    }

    var win = window.open(link, winTitle, "width=" + windowWidth + ",height=" + windowHeigth + ",menubar=no,status=yes,location=no,resizable=no");
    if (win) {
        if (win.location == 'about:blank') {
            win.location = link;
        }
        win.focus();
    }
    return false;
}

function OpenModal(link, title) {    
    var windowElement = $.telerik.window.create({
        title: title,        
        contentUrl: link,
        modal: true,
        resizable: true,
        draggable: true,        
        onClose: function () { }
    });

    windowElement.css({
        left: 300,
        top: 150,
        width: 600,
        height: 380        
    }).data('tWindow').open();
}
