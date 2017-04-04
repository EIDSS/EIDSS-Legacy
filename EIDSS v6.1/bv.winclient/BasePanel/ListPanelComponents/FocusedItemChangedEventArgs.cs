using System;

namespace bv.winclient.BasePanel.ListPanelComponents
{
    public class FocusedItemChangedEventArgs<T> : EventArgs where T : class
    {
        private readonly T m_FocusedItem;
        private readonly T m_PrevFocusedItem;

        public FocusedItemChangedEventArgs(T focusedItem, T prevFocusedItem)
        {
            m_FocusedItem = focusedItem;
            m_PrevFocusedItem = prevFocusedItem;
        }

        /// <summary>
        /// Curent focused Item. It can be null!
        /// </summary>
        public T FocusedItem
        {
            get { return m_FocusedItem; }
        }

        /// <summary>
        /// Previous focused item
        /// </summary>
        public T PrevFocusedItem
        {
            get { return m_PrevFocusedItem; }
        }
    }
}