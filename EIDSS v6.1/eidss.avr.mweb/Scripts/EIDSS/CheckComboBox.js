var checkComboBox = (function () {
    var textSeparator = ", ";
    return {
        Synchronize: function (dropDown, listBox) {
            listBox.UnselectAll();
            var texts = dropDown.GetText().split(',');
            var values = checkComboBox.GetValuesByTexts(listBox, texts);
            listBox.SelectValues(values);
            checkComboBox.UpdateSelectAllItemState(listBox);
            checkComboBox.UpdateText(dropDown, listBox); // for remove non-existing texts
        },

        UpdateText: function (dropDown, listBox) {
            var selectedItems = listBox.GetSelectedItems();
            dropDown.SetText(checkComboBox.GetSelectedItemsText(selectedItems));
        },

        UpdateSelectAllItemState: function (listBox) {
            checkComboBox.IsAllSelected(listBox) ? listBox.SelectIndices([0]) : listBox.UnselectIndices([0]);
        },

        IsAllSelected: function (listBox) {
            for (var i = 1; i < listBox.GetItemCount() ; i++)
                if (!listBox.GetItem(i).selected)
                    return false;
            return true;
        },

        GetSelectedItemsText: function (items) {
            var texts = [];
            for (var i = 0; i < items.length; i++)
                if (items[i].index != 0)
                    texts.push(items[i].text);
            return texts.join(textSeparator);
        },

        GetValuesByTexts: function (listBox, texts) {
            var actualValues = [];
            var item;
            for (var i = 0; i < texts.length; i++) {
                item = listBox.FindItemByText(texts[i].trim());
                if (item != null)
                    actualValues.push(item.value);
            }
            return actualValues;
        }
};
})();