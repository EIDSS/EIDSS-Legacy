var menu = (function () {
    
    return {
        menuItemClick: function (s, e) {
            alert(e.item.name);
            if (e.item.name == "MenuNewLayout") {
                //treeList.StartEdit();
            }

        },
    }
});