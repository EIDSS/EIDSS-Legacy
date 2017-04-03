function ShowFreezerPicker(idfContainer) {
    var ajaxRequestUrl = '../System/FreezerPicker?idfContainer=' + idfContainer;
    ShowMessageWindow(ajaxRequestUrl, 630, 380, "", false);    
}


function onPickerFreezerChanged() {
    var container = $('#idfContainer')[0].value;
    var selected = $('#idfSubdivision')[0].value;
    $.ajax({
        url: "../System/SetFreezer",
        cache: false,
        dataType: "json",
        type: "GET",
        data: {
            idfContainer: container,
            idfSubdivision: selected
        },
        success: function (data) {            
            ApplyChanges(data);
            CloseMessageWindow();
        },
        error: function () {
            CloseMessageWindow();
        }
    });
}

function expand(tree, node, selected) {
    var items = $("> ul > li", node);
    var i = 0;
    for (i = 0; i < items.length; i++) {
        var item = items[i];
        if (tree.getItemValue(item) == selected) {
            //debugger;
            //tree.nodeClick(item);
            //tree.element.click();
            tree.nodeSelect(null, $(".t-in", item.all[0]));
            //tree.nodeToggle(null, item, true);
            //tree.toggle(null, item);
        }
        tree.expand(item);
        expand(tree, item, selected);
    }
}

function onFreezerLoad(e) {
    //debugger;
    var tree = $('#TreeView').data('tTreeView');
    var selected = $('#idfSubdivision')[0].value;
    expand(tree, tree.element, selected);
}

function onFreezerSelect(e) {
    //debugger;
    var tree = $('#TreeView').data('tTreeView');
    var selected = tree.getItemValue(e.item);
    $('#idfSubdivision')[0].value = selected;
}
