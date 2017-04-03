using System;
using System.Collections.Generic;
using System.Windows.Forms;
using bv.common.Enums;
using bv.model.Model.Core;
using bv.winclient.BasePanel.ListPanelComponents;

namespace bv.winclient.BasePanel
{
    public interface IBaseListPanel : IBasePanel
    {
        IList<IObject> SelectedItems { get; }
        IObject FocusedItem { get; }
        /// <summary>
        /// Gets or sets whether multiple rows (cards) can be selected.
        /// </summary>
        SelectMode SelectMode { get; set; }
        ISearchPanel SearchPanel { get; }
        BaseListGridControl Grid { get; }
        InlineMode InlineMode { get; set; }
        event EventHandler<FocusedItemChangedEventArgs<IObject>> FocusedItemChanged;
        event EventHandler<SelectedItemsChangedEventArgs<IObject>> SelectedItemsChanged;
        void RaiseActionButtonStateChangedEvent(Control button, IObject focusedItem, IList<IObject> selectedItems);
        void Refresh();
        void RefreshFocusedItem();
        void LoadData();
        IApplicationForm Edit(object key, List<object> parameters, ActionTypes actionType, bool readOnly);
        IObject GetItem(object key);
        void SelectAll();
        bool EnableMultiEdit { get; set; }
        void HideCustomization();
    }
}
