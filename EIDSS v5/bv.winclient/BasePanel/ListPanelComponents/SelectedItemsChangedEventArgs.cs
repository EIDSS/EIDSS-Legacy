using System;
using System.Collections.Generic;

namespace bv.winclient.BasePanel.ListPanelComponents
{
    public class SelectedItemsChangedEventArgs<T> : EventArgs where T : class
    {
        private readonly IList<T> m_SelectedItems;
        private readonly T m_FocusedItem;

        public SelectedItemsChangedEventArgs(T focusedItem, IList<T> selectedItems)
        {
            m_SelectedItems = selectedItems;
            m_FocusedItem = focusedItem;
        }

        public IList<T> SelectedItems
        {
            get { return m_SelectedItems; }
        }
        public T FocusedItem
        {
            get { return m_FocusedItem; }
        }
    }
}