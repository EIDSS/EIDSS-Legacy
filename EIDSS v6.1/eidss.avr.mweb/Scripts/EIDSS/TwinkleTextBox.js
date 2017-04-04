var twinkleTextBox = (function () {
    function onLabelClick() {
        var $this = $(this);
        var item = $this.closest(".twinkleInput").find("input:visible");
        item.focus();
    }

    function onClick() {
        var $this = $(this);
        var item = $this.closest(".twinkleInput").find("input:visible");
        if (item.is(':disabled')) {
            return;
        }
        $($this).focus();
    }
    
    function onFocus() {
        unFocusAll();
        var fields = getVisibleFields();
        setPopulated(fields);
        $(this).closest(".twinkleInput").addClass("focused");
    }

    function onKeypress() {
        $(this).closest(".twinkleInput").addClass("populated");
    }
    
    function onChange() {
        var $this = $(this);
        if (!$this.is(":visible")) {
            return;
        }
        var parent = $this.closest(".twinkleInput");
        if ($this.val()) {
            parent.addClass("populated");
        } else {
            parent.removeClass("populated");
        }
    }
    
    function onFocusout() {
        showLabelsIfNeed();
    }

    function unFocusAll() {
        $(".twinkleInput").removeClass("populated").removeClass("focused");
    }

    function showLabelsIfNeed() {
        unFocusAll();
        var fields = getVisibleFields();
        setPopulated(fields);
    }

    function getAllFields() {
        var fields = $(".twinkleInput input:not([tabindex=-1])");
        var ddls = $(".twinkleInput span." + commonWidgetsFacade.inputClassName);
        var result = $.merge(fields, ddls);
        return result;
    }

    function getVisibleFields() {
        var fields = $(".twinkleInput input:visible");
        var ddls = $(".twinkleInput span." + commonWidgetsFacade.inputClassName);
        var result = $.merge(fields, ddls);
        return result;
    }

    function setPopulated(fields) {
        var count = fields.length;
        for (var i = count; i--;) {
            var f = $(fields[i]);
            if ((f.is("span") && f.text()) || (f.val() && f[0].style.display !== "none")) {
                f.closest(".twinkleInput").addClass("populated");
            }
        }
    }
    
    function setTooltips(selector) {
        var items = $(selector);
        var count = items.length;
        for (var i = count; i--;) {
            var f = $(items[i]);
            var label = f.closest(".twinkleInput").find("label");
            if (label.length > 0) {
                var labelText = label[0].innerText;
                f.attr("title", labelText);
            }
        }
    }

    function showLabelByFieldId(id) {
        $("#" + id).closest(".twinkleInput").removeClass("populated").removeClass("focused");
    }
    
    function hideLabelByFieldId(id) {
        $("#" + id).closest(".twinkleInput").addClass("populated");
    }

    return {
        init: function () {
            var fields = getAllFields();
            setPopulated(fields);
            fields.click(onClick);
            fields.focus(onFocus);
            fields.keypress(onKeypress);
            fields.change(onChange);
            fields.keyup(onChange);
            fields.focusout(onFocusout);

            var labels = $(".twinkleInput label");
            labels.click(onLabelClick);
        },

        addTooltip: function (selector) {
            setTooltips(selector);
        },
        
        showLabels: function() {
            showLabelsIfNeed();
        },
        
        updateDdlLabels: function (id, text) {
            if (!text) {
                showLabelByFieldId(id);
            } else {
                hideLabelByFieldId(id);
            }
        }
    };
})();