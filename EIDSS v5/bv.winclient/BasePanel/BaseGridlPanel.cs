using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BLToolkit.EditableObjects;
using BLToolkit.Reflection;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using bv.common.Enums;
using bv.model.Model.Core;
using bv.winclient.BasePanel.ListPanelComponents;
using bv.winclient.SearchPanel;
using DevExpress.Data;
using DevExpress.XtraGrid.Views.Base;
using System.ComponentModel;
using DevExpress.XtraGrid.Views.Grid;
using bv.common.Core;
using bv.winclient.Layout;

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
            if (handler!=null)
                handler(this, new ActionButtonEventArgs<IObject>(button, focusedItem, selectedItems));
        }
        private IList<T> m_SelectedItems = new List<T>();
        private ISearchPanel m_SearchPanel;

        public BaseGridPanel()
        {
            InitializeComponent();
            BusinessObject = TypeAccessor.CreateInstanceEx<T>();
            if (Permissions != null)
                m_ReadOnly = Permissions.IsReadOnlyForEdit;
            Init();
        }

        public virtual IObject GetItem(object key)
        {
            return null;
        }
        [Browsable(true),DefaultValue(0)]
        public int SearchPanelLabelWidth { get; set; }
        protected virtual ISearchPanel CreateSearchPanel()
        {
            //return new BaseSearchPanel();
            return new BaseSearchPanel(typeof(T), false, null, SearchPanelLabelWidth);
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ISearchPanel SearchPanel
        {
            get
            {
                if (m_SearchPanel == null)
                {
                    m_SearchPanel = CreateSearchPanel();
                    m_SearchPanel.Search += SearchPanel_Search;

                }
                return m_SearchPanel;
            }
        }

        private void SearchPanel_Search(object sender, EventArgs e)
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
                return BusinessObject.GetType().Name.Substring(0, BusinessObject.GetType().Name.Length - 8
                    /*length of ListItem*/) + "Detail";
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
        /// Требуется ли редактирование значений в строке таблицы. Если нет, то открывается отдельное окно.
        /// </summary>
        [Browsable(true), DefaultValue(InlineMode.None), Localizable(false)]
        public InlineMode InlineMode
        {
            get { return m_InlineMode; }
            set
            {
                m_InlineMode = value;
                Grid.GridView.OptionsBehavior.Editable = (m_InlineMode != InlineMode.None);
                Grid.GridView.OptionsBehavior.ReadOnly = (m_InlineMode == InlineMode.None);
                Grid.GridView.OptionsView.NewItemRowPosition = (value == InlineMode.UseNewRow) ? NewItemRowPosition.Top : NewItemRowPosition.None;
                //TODO вставить событие на окончание редактирования строки и привязать к нему событие BaseActionPanel.AfterAction
                //Grid.GridView.InitNewRow += InitNewRow;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="sortable"></param>
        private void SetColumnSortable(string columnName, bool sortable)
        {
            var column = m_ListGridControl.GridView.Columns.ColumnByName(columnName);
            if (column != null)
            {
                column.OptionsColumn.AllowSort = sortable ? DefaultBoolean.True : DefaultBoolean.False;
            }
        }

        /// <summary>
        /// Настройка таблицы
        /// </summary>
        protected void Init()
        {
            Grid.GridView.FocusedRowChanged += GridView_FocusedRowChanged;
            Grid.GridView.SelectionChanged += GridView_SelectionChanged;
            Grid.GridView.DoubleClick += GridView_DoubleClick;
            Grid.GridView.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            Sizable = true;

            if (BusinessObject != null)
            {
                var meta = (IObjectMeta)BusinessObject.GetAccessor();
                Grid.GridMeta = meta.GridMeta;

                var sortableFields = meta.GridMeta.Where(c => c.Sortable).ToList();
                var nonSortableFields = meta.GridMeta.Where(c => !c.Sortable).ToList();
                foreach (var sortableField in sortableFields)
                {
                    SetColumnSortable(sortableField.Name, true);
                }
                foreach (var nonSortableField in nonSortableFields)
                {
                    SetColumnSortable(nonSortableField.Name, false);
                }

                LoadGridLayout();
            }
        }

        protected virtual void LoadGridLayout()
        {

        }

        protected void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int[] selectedRows = m_ListGridControl.GridView.GetSelectedRows();
            IEnumerable<T> dirtySelectedItems = selectedRows.Select(GetItemByRowHandle);
            m_SelectedItems = dirtySelectedItems.Where(item => item != null).ToList();

            EventHandler<SelectedItemsChangedEventArgs<IObject>> handler = SelectedItemsChanged;
            if (handler != null)
            {
                handler(sender, new SelectedItemsChangedEventArgs<IObject>(GetItemByRowHandle(m_ListGridControl.GridView.FocusedRowHandle), m_SelectedItems.Cast<IObject>().ToList()));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void RefreshFocusedItem()
        {
            var handle = m_ListGridControl.GridView.FocusedRowHandle;
            GridView_FocusedRowChanged(this, new FocusedRowChangedEventArgs(handle, handle));
        }

        protected void GridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {

            EventHandler<FocusedItemChangedEventArgs<IObject>> handler = FocusedItemChanged;
            if (handler != null)
            {
                IObject prevItem = GetItemByRowHandle(e.PrevFocusedRowHandle);
                handler(sender, new FocusedItemChangedEventArgs<IObject>(FocusedItem, prevItem));
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

        public void SelectAll()
        {
            m_ListGridControl.GridView.SelectAll();
        }

        public override bool Delete(object key)
        {
            var bo = m_ListGridControl.GridView.GetFocusedRow() as IObject;
            if (bo != null && bo.Key.Equals(key))
                m_ListGridControl.GridView.DeleteRow(m_ListGridControl.GridView.FocusedRowHandle);
            return true;
        }
        [Browsable(true), DefaultValue(false), Localizable(false)]
        public bool EnableMultiEdit { get; set; }

        public void HideCustomization()
        {
            if (Grid != null && Grid.GridView != null)
                Grid.GridView.HideCustomization();
        }

        protected bool m_SearchPanelVisible = true;
        [Browsable(true), DefaultValue(true), Localizable(false)]
        public bool SearchPanelVisible
        {
            get
            {
                if (!IsLayoutCreated)
                    return m_SearchPanelVisible;
                ILayout layout = GetLayout();
                if (layout != null)
                {
                    object result = ReflectionHelper.GetProperty(layout, "SearchPanelVisible");
                    if (result != null)
                        return (bool)result;
                }
                return false;
            }
            set
            {
                m_SearchPanelVisible = value;
                if (!IsLayoutCreated) //if layout is not created yet, we will set this property for layout when will create layout
                    return;

                ILayout layout = GetLayout();
                if (layout != null)
                    ReflectionHelper.SetProperty(layout, "SearchPanelVisible", value);
                else
                    m_SearchPanelVisible = false;
            }
        }
    }
}
