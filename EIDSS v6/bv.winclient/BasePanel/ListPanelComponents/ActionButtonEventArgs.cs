using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace bv.winclient.BasePanel.ListPanelComponents
{
    public class ActionButtonEventArgs<T> : EventArgs where T : class
    {
        private readonly IList<T> m_SelectedItems;
        private readonly Control m_Button;
        private readonly T m_FocusedItem;
        public ActionButtonEventArgs(Control button, T focusedItem, IList<T> selectedItems)
        {
            m_SelectedItems = selectedItems;
            m_Button = button;
            m_FocusedItem = focusedItem;
        }

        public IList<T> SelectedItems
        {
            get { return m_SelectedItems; }
        }
        public Control Button
        {
            get { return m_Button; }
        }

        public T FocusedItem
        {
            get { return m_FocusedItem; }
        }
    }
}
