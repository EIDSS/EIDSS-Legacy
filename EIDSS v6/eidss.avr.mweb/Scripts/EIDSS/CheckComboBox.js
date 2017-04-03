var checkComboBox = (function () {
    var textSeparator = ", ";
    return {
        Synchronize: function (dropDown, listBox) {
            listBox.UnselectAll();
            var texts = dropDown.GetText().split(textSeparator);
            var values = checkComboBox.GetValuesByTexts(listBox, texts);
            listBox.SelectValues(values);
            checkComboBox.UpdateText(dropDown, listBox); // for remove non-existing texts
        },

        UpdateText: function (dropDown, listBox) {
            var selectedItems = listBox.GetSelectedItems();
            dropDown.SetText(checkComboBox.GetSelectedItemsText(selectedItems));
        },

        GetSelectedItemsText: function (items) {
            var texts = [];
            for (var i = 0; i < items.length; i++)
                texts.push(items[i].text);
            return texts.join(textSeparator);
        },

        GetValuesByTexts: function (listBox, texts) {
            var actualValues = [];
            var item;
            for (var i = 0; i < texts.length; i++) {
                item = listBox.FindItemByText(texts[i]);
                if (item != null)
                    actualValues.push(item.value);
            }
            return actualValues;
        }
};
})();