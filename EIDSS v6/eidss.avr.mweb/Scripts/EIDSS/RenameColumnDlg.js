var renameForm = (function() {
    var currentLayoutId;
    var currentUniquePath;

    return {
        OnRename: function (layoutId) {
            currentLayoutId = layoutId;
            var sel = cbColumn.GetSelectedItem();
            if(cbColumn.GetSelectedItem() !== undefined)
            {
                currentUniquePath = cbColumn.GetValue();
                pcRenameColumn.PerformCallback();
                pcRenameColumn.Show();
            }
        },

        OnPopupBeginCallback: function (s, e) {
            e.customArgs["layoutId"] = currentLayoutId;
            e.customArgs["uniquePath"] = currentUniquePath;
        }
    };
})();