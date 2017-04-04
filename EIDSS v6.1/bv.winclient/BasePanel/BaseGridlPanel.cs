using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using BLToolkit.EditableObjects;
using BLToolkit.Reflection;
using bv.common.Core;
using bv.common.Enums;
using bv.common.Resources;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel.ListPanelComponents;
using bv.winclient.Core;
using bv.winclient.Layout;
using bv.winclient.Localization;
using bv.winclient.SearchPanel;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace bv.winclient.BasePanel
{
    public partial class BaseGridPanel<T> : BasePanel<T>, IBaseListPanel
        where T : EditableObject<T>, IObject
    {
        public event EventHandler<FocusedItemChangedEventArgs<IObject>> FocusedItemChanged;
        public event EventHandler<SelectedItemsChangedEventArgs<IObject>> SelectedItemsChanged;
        public event EventHandler<ActionButtonEventArgs<IObject>> ActionButtonStateChanged;

        public void RaiseActionButtonStateChangedEvent(Control button, IObject focusedItem, IList<IObject> selectedItems)
        {
            EventHandler<ActionButtonEventArgs<IObject>> handler = ActionButtonStateChanged;
            if (handler != null)
            {
                handler(this, new ActionButtonEventArgs<IObject>(button, focusedItem, selectedItems));
            }
        }

        private IList<T> m_SelectedItems = new List<T>();
        protected ISearchPanel m_SearchPanel;

        public BaseGridPanel()
        {
            InitializeComponent();
            if (WinUtils.IsComponentInDesignMode(this))
                return;
            BusinessObject = TypeAccessor.CreateInstanceEx<T>();
            if (Permissions != null)
            {
                m_ReadOnly = Permissions.IsReadOnlyForEdit;
            }
            Init();
        }
        public override void Cleanup()
        {
            Grid.GridControl.DataSource = null;
        }

        public virtual IObject GetItem(object key)
        {
            return null;
        }

        [Browsable(true), DefaultValue(0)]
        public int SearchPanelLabelWidth { get; set; }

        /*
        protected virtual ISearchPanel CreateSearchPanel()
        {
            //return new BaseSearchPanel();
            return new BaseSearchPanel(typeof(T), false, null, null, SearchPanelLabelWidth);
        }
        */

        public virtual ISearchPanel CreateSearchPanel
            (ActionPanel.ActionPanel panel, Func<SearchPanelMetaItem, SearchPanelMetaItem> item, Func<IObject, IObject> adjustObject)
        {
            if (m_SearchPanel == null)
            {
                m_SearchPanel = new BaseSearchPanel(typeof (T), false, null, panel, SearchPanelLabelWidth, item, adjustObject);
                m_SearchPanel.Search += SearchPanel_Search;
            }
            return m_SearchPanel;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ISearchPanel SearchPanel
        {
            get
            {
                if (m_SearchPanel == null)
                {
                    m_SearchPanel = CreateSearchPanel(null, null, null);
                }
                return m_SearchPanel;
            }
        }

        protected void SearchPanel_Search(object sender, EventArgs e)
        {
            Refresh();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IList<IObject> SelectedItems
        {
            get { return m_SelectedItems.Cast<IObject>().ToList(); }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IObject FocusedItem
        {
            get { return GetItemByRowHandle(Grid.GridView.FocusedRowHandle); }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override object Key
        {
            get
            {
                if (FocusedItem != null)
                {
                    return FocusedItem.Key;
                }
                return null;
            }
        }

        public virtual IApplicationForm Edit(object key, List<object> parameters, ActionTypes actionType, bool readOnly)
        {
            return null;
        }

        public virtual void InitDetailForm(object detailForm)
        {
        }

        public virtual string GetDetailFormName(IObject o)
        {
            if (BusinessObject.GetType().Name.Contains("ListItem"))
            {
                return BusinessObject.GetType().Name.Substring(0, BusinessObject.GetType().Name.Length - 8
                    /*length of ListItem*/) + "Detail";
            }
            return BusinessObject.GetType().Name + "Detail";
        }

        public virtual void LoadData()
        {
        }

        public new virtual void Refresh()
        {
        }

        private InlineMode m_InlineMode = InlineMode.None;

        /// <summary>
        ///     Требуется ли редактирование значений в строке таблицы. Если нет, то открывается отдельное окно.
        /// </summary>
        [Browsable(true), DefaultValue(InlineMode.None), Localizable(false)]
        public InlineMode InlineMode
        {
            get { return m_InlineMode; }
            set
            {
                m_InlineMode = value;
                try
                {
                    Grid.GridView.BeginUpdate();

                    Grid.GridView.OptionsBehavior.Editable = (m_InlineMode != InlineMode.None);
                    Grid.GridView.OptionsBehavior.ReadOnly = (m_InlineMode == InlineMode.None);
                    Grid.GridView.OptionsView.NewItemRowPosition = (value == InlineMode.UseNewRow)
                        ? NewItemRowPosition.Top
                        : NewItemRowPosition.None;
                    //TODO вставить событие на окончание редактирования строки и привязать к нему событие BaseActionPanel.AfterAction
                    //Grid.GridView.InitNewRow += InitNewRow;
                }
                finally
                {
                    Grid.GridView.EndUpdate();
                }
            }
        }

        private void GridViewOnShownEditor(object sender, EventArgs cancelEventArgs)
        {
            var view = sender as GridView;
            if (view != null && view.IsNewItemRow(view.FocusedRowHandle) && view.ActiveEditor != null)
            {
                view.ActiveEditor.IsModified = true;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="sortable"></param>
        private void SetColumnSortable(string columnName, bool sortable)
        {
            GridColumn column = m_ListGridControl.GridView.Columns.ColumnByName(columnName);
            if (column != null)
            {
                column.OptionsColumn.AllowSort = sortable ? DefaultBoolean.True : DefaultBoolean.False;
            }
        }

        /// <summary>
        ///     Настройка таблицы
        /// </summary>
        protected void Init()
        {
            Grid.GridView.FocusedRowChanged += GridView_FocusedRowChanged;
            Grid.GridView.SelectionChanged += GridView_SelectionChanged;
            Grid.GridView.DoubleClick += GridView_DoubleClick;
            Grid.GridView.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            Grid.GridView.ShownEditor += GridViewOnShownEditor;
            Grid.GridView.PopupMenuShowing += GridViewOnPopupMenuShowing;
            Sizable = true;

            if (BusinessObject != null)
            {
                var meta = (IObjectMeta) BusinessObject.GetAccessor();
                Grid.GridMeta = meta.GridMeta;


                List<GridMetaItem> sortableFields = meta.GridMeta.Where(c => c.Sortable).ToList();
                List<GridMetaItem> nonSortableFields = meta.GridMeta.Where(c => !c.Sortable).ToList();
                foreach (GridMetaItem sortableField in sortableFields)
                {
                    SetColumnSortable(sortableField.Name, true);
                }
                foreach (GridMetaItem nonSortableField in nonSortableFields)
                {
                    SetColumnSortable(nonSortableField.Name, false);
                }

                if (ReflectionHelper.HasProperty(meta, "SqlSortOrder"))
                {
                    var sortOrder = ReflectionHelper.GetProperty(meta, "SqlSortOrder");
                    if (!Utils.IsEmpty(sortOrder))
                    {
                        foreach (GridColumn col in Grid.GridView.Columns)
                        {
                                col.SortOrder = ColumnSortOrder.None;
                        }
                    }
                }
            }
        }

        private void GridViewOnPopupMenuShowing(object sender, PopupMenuShowingEventArgs popupMenuShowingEventArgs)
        {
            if (popupMenuShowingEventArgs.MenuType == GridMenuType.Row && SelectedItems.Count > 0)
            {
                //var meta = SelectedItems[0].GetAccessor() as IObjectMeta;
                IObject o = SelectedItems[0];
                IObjectPermissions p = SelectedItems[0].GetPermissions();
                List<ActionMetaItem> actions = ParentLayout.Actions;
                if (actions.Any(c => c.PanelType == ActionsPanelType.ContextMenu && (c.AppType == ActionsAppType.Win || c.AppType == ActionsAppType.All) && c.IsVisible(SelectedItems, p)))
                {
                    //SetCustomActions(meta.Actions);
                    var menu = new PopupMenu {Manager = BaseFormManager.MainBarManager};
                    menu.CloseUp += (s, args) => menu.Dispose();

                    /*
                    bool bBeginGroup = false;
                    actions.Where(
                        c => c.PanelType == ActionsPanelType.ContextMenu && c.IsVisible(SelectedItems, p))
                        .ToList().ForEach(c =>
                        {
                            BarItem item = null;
                            if (c.Children(SelectedItems).Any(i => i.IsVisible(SelectedItems, p)))
                            {
                                item = new BarSubItem(menu.Manager, BvMessages.Get(c.CaptionId(o, p))) {Tag = c};
                                (item as BarSubItem).AddItems(c.Children(SelectedItems).Where(i => i.IsVisible(SelectedItems, p))
                                    .Select(i =>
                                    {
                                        var item2 = new BarButtonItem(menu.Manager, BvMessages.Get(i.CaptionId(o, p))) {Tag = i};
                                        item2.ItemClick += ItemOnItemClick;
                                        return item2;
                                    }).Cast<BarItem>().ToArray()
                                    );
                            }
                            else if (c.Children(SelectedItems).Any())
                            {
                            }
                            else if (c.CaptionId(o, p) != "-")
                            {
                                item = new BarButtonItem(menu.Manager, BvMessages.Get(c.CaptionId(o, p))) {Tag = c};
                                item.ItemClick += ItemOnItemClick;
                            }
                            else
                            {
                                bBeginGroup = true;
                            }

                            if (item != null)
                            {
                                menu.AddItem(item).BeginGroup = bBeginGroup;
                                bBeginGroup = false;
                            }
                        }
                        );
                    */

                    bool bBeginGroup = false;
                    actions.Where(
                        c => c.PanelType == ActionsPanelType.ContextMenu && (c.AppType == ActionsAppType.Win || c.AppType == ActionsAppType.All))
                        .ToList().ForEach(c =>
                        {
                            BarItem item = null;
                            if (c.Children(SelectedItems).Any())
                            {
                                item = new BarSubItem(menu.Manager, BvMessages.Get(c.CaptionId(o, p))) { Tag = c, Enabled = c.IsVisible(SelectedItems, p) };
                                c.Children(SelectedItems).ToList().ForEach(cc =>
                                    {
                                        BarItem item2 = null;
                                        if (cc.Children(SelectedItems).Any())
                                        {
                                            item2 = new BarSubItem(menu.Manager, BvMessages.Get(cc.CaptionId(o, p))) { Tag = cc, Enabled = cc.IsVisible(SelectedItems, p) };
                                            (item2 as BarSubItem).AddItems(cc.Children(SelectedItems)
                                                .Select(i =>
                                                {
                                                    if (cc.IsFirstUI)
                                                    {
                                                        i.AddFirstUIFunc(cc.FirstUIFunc, cc.Parameters);
                                                    }
                                                    var item3 = new BarButtonItem(menu.Manager, BvMessages.Get(i.CaptionId(o, p))) { Tag = i, Enabled = i.IsVisible(SelectedItems, p) };
                                                    item3.ItemClick += ItemOnItemClick;
                                                    return item3;
                                                }).Cast<BarItem>().ToArray()
                                                );
                                        }
                                        else if (cc.CaptionId(o, p) != "-")
                                        {
                                            if (c.IsFirstUI)
                                            {
                                                cc.AddFirstUIFunc(c.FirstUIFunc, c.Parameters);
                                            }
                                            item2 = new BarButtonItem(menu.Manager, BvMessages.Get(cc.CaptionId(o, p))) { Tag = cc, Enabled = cc.IsVisible(SelectedItems, p) };
                                            item2.ItemClick += ItemOnItemClick;
                                        }
                                        if (item2 != null)
                                        {
                                            (item as BarSubItem).AddItem(item2);
                                        }
                                    });

                                /*
                                item = new BarSubItem(menu.Manager, BvMessages.Get(c.CaptionId(o, p))) { Tag = c, Enabled = c.IsVisible(SelectedItems, p) };
                                (item as BarSubItem).AddItems(c.Children(SelectedItems)
                                    .Select(i =>
                                    {
                                        var item2 = new BarButtonItem(menu.Manager, BvMessages.Get(i.CaptionId(o, p))) { Tag = i, Enabled = i.IsVisible(SelectedItems, p) };
                                        item2.ItemClick += ItemOnItemClick;
                                        return item2;
                                    }).Cast<BarItem>().ToArray()
                                    );
                                 */
                            }
                            else if (c.CaptionId(o, p) != "-")
                            {
                                item = new BarButtonItem(menu.Manager, BvMessages.Get(c.CaptionId(o, p))) { Tag = c, Enabled = c.IsVisible(SelectedItems, p) };
                                item.ItemClick += ItemOnItemClick;
                            }
                            else
                            {
                                bBeginGroup = true;
                            }

                            if (item != null)
                            {
                                menu.AddItem(item).BeginGroup = bBeginGroup;
                                bBeginGroup = false;
                            }
                        }
                        );

                    menu.ShowPopup(menu.Manager, Grid.PointToScreen(popupMenuShowingEventArgs.Point));
                    popupMenuShowingEventArgs.Allow = false;
                }
            }
        }

        protected virtual void OnMenuSelected(object sender, ItemClickEventArgs itemClickEventArgs)
        {
            
        }

        private void ItemOnItemClick(object sender, ItemClickEventArgs itemClickEventArgs)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create())
            {
                var actionMetaItem = itemClickEventArgs.Item.Tag as ActionMetaItem;
                if (actionMetaItem != null)
                {
                    actionMetaItem.RunAction(manager, SelectedItems.ToList());
                    OnMenuSelected(sender, itemClickEventArgs);
                }
                //SelectedItems.ToList().ForEach(i =>
                //    (itemClickEventArgs.Item.Tag as ActionMetaItem).RunAction(manager, i)
                //    );
            }
        }

        private bool m_LayoutLoaded;
        protected virtual void LoadGridLayout()
        {
            if (((BvGridControl)Grid.GridControl).AllowCustomization && !m_LayoutLoaded && !String.IsNullOrEmpty(GetGridLayoutName()))
            {
                Grid.GridView.InitXtraGridCustomization(BusinessObject);
                Grid.GridView.LoadGridLayout(GetGridLayoutName());
                m_LayoutLoaded = true;
            }
        }
        protected string m_GridLayoutName;
        protected virtual string GetGridLayoutName()
        {
            if (string.IsNullOrEmpty(m_GridLayoutName))
            {
                m_GridLayoutName = BusinessObject != null ? BusinessObject.ObjectName : null;
            }

            return m_GridLayoutName;
        }

        public override void SaveGridLayout()
        {
            if (((BvGridControl)Grid.GridControl).AllowCustomization && !String.IsNullOrEmpty(GetGridLayoutName()))
                Grid.GridView.SaveGridLayout(GetGridLayoutName());
        }

        protected void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int[] selectedRows = m_ListGridControl.GridView.GetSelectedRows();
            IEnumerable<T> dirtySelectedItems = selectedRows.Select(GetItemByRowHandle);
            m_SelectedItems = dirtySelectedItems.Where(item => item != null).ToList();

            EventHandler<SelectedItemsChangedEventArgs<IObject>> handler = SelectedItemsChanged;
            if (handler != null)
            {
                handler(sender,
                    new SelectedItemsChangedEventArgs<IObject>(GetItemByRowHandle(m_ListGridControl.GridView.FocusedRowHandle),
                        m_SelectedItems.Cast<IObject>().ToList()));
            }
        }

        /// <summary>
        /// </summary>
        public void RefreshFocusedItem()
        {
            int handle = m_ListGridControl.GridView.FocusedRowHandle;
            GridView_FocusedRowChanged(this, new FocusedRowChangedEventArgs(handle, handle));
        }

        protected virtual void GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            EventHandler<FocusedItemChangedEventArgs<IObject>> handler = FocusedItemChanged;
            if (handler != null)
            {
                IObject prevItem = GetItemByRowHandle(e.PrevFocusedRowHandle);
                handler(sender, new FocusedItemChangedEventArgs<IObject>(FocusedItem == null && prevItem == null ? BusinessObject : FocusedItem, prevItem));
            }
        }

        protected virtual void GridView_DoubleClick(object sender, EventArgs e)
        {
        }

        protected virtual T GetItemByRowHandle(int rowHandle)
        {
            return null;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BaseListGridControl Grid
        {
            get { return m_ListGridControl; }
        }

        private SelectMode m_SelectMode = SelectMode.None;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SelectMode SelectMode
        {
            get { return m_SelectMode; }
            set
            {
                m_SelectMode = value;
                m_ListGridControl.GridView.OptionsSelection.MultiSelect = (value == SelectMode.MultiSelect);
            }
        }

        /// <summary>
        ///     Initial search filter initialize search panel with filters described by this property after list form load
        ///     Only Key/Value pair is used for initialization, operation is ignored
        ///     During initialization search panel assigns value to each search item with Name = Key.
        ///     If values array is passed to filter parameter, value is assigne to each search control with corresponded index.
        ///     Combo boxes fields of search panel isn not initialize in current impelmentation
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(false)]
        public FilterParams InitialSearchFilter { get; set; }


        public void SelectAll()
        {
            m_ListGridControl.GridView.SelectAll();
        }

        public override bool Delete(object key)
        {
            var bo = m_ListGridControl.GridView.GetFocusedRow() as IObject;
            if (bo != null && bo.Key.Equals(key))
            {
                m_ListGridControl.GridView.DeleteRow(m_ListGridControl.GridView.FocusedRowHandle);
            }
            return true;
        }

        [Browsable(true), DefaultValue(false), Localizable(false)]
        public bool EnableMultiEdit { get; set; }

        public void HideCustomization()
        {
            if (Grid != null && Grid.GridView != null)
            {
                Grid.GridView.HideCustomization();
            }
        }

        protected bool m_SearchPanelVisible = true;

        [Browsable(true), DefaultValue(true), Localizable(false)]
        public bool SearchPanelVisible
        {
            get
            {
                if (!IsLayoutCreated)
                {
                    return m_SearchPanelVisible;
                }
                ILayout layout = GetLayout();
                if (layout != null)
                {
                    object result = ReflectionHelper.GetProperty(layout, "SearchPanelVisible");
                    if (result != null)
                    {
                        return (bool) result;
                    }
                }
                return false;
            }
            set
            {
                m_SearchPanelVisible = value;
                if (!IsLayoutCreated) //if layout is not created yet, we will set this property for layout when will create layout
                {
                    return;
                }

                ILayout layout = GetLayout();
                if (layout != null)
                {
                    ReflectionHelper.SetProperty(layout, "SearchPanelVisible", value);
                }
                else
                {
                    m_SearchPanelVisible = false;
                }
            }
        }

        //public override void ApplyResources(string cultureCode)
        //{
        //    ResourcesList.Clear();
        //    foreach (GridColumn col in Grid.GridView.Columns)
        //    {
        //        string captionId = GetKeyForComponentText(col);
        //        string caption = CommonResourcesCache.GetText("EidssFields", cultureCode, captionId);
        //        if(!string.IsNullOrEmpty(caption))
        //            col.Caption = caption;
        //    }
        //}
        //public override bool SaveChanges(Dictionary<object, DesignElement> changes, string cultureCode)
        //{
        //    bool res = TranslationToolHelperWinClient.SaveViewChanges(this, "EidssFields", changes, cultureCode, false);
        //    return res;
        //}
        //public override string GetKeyForComponentText(Component component)
        //{
        //    var col = component as GridColumn;
        //    if (col != null)
        //    {
        //        var metaItem = Grid.GridMeta.Find(i => i.Name == col.FieldName);
        //        if (metaItem != null)
        //            return metaItem.LabelId ?? metaItem.Name;
        //        return col.FieldName;
        //    }
        //    return string.Empty;
        //}
        //public override string GetResourceNameForComponentText(Component component)
        //{
        //    return "EidssFields";
        //}
    }
}