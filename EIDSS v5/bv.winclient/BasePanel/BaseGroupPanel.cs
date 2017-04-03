using System;
using System.Text;
using BLToolkit.EditableObjects;
using DevExpress.XtraGrid.Views.Base;
using bv.common.Enums;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.Layout;
using bv.common.Core;
using bv.common.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;
using bv.winclient.Core;
using System.ComponentModel;
using System.Windows.Forms;
using bv.model.Helpers;
using bv.winclient.Localization;

namespace bv.winclient.BasePanel
{
    public partial class BaseGroupPanel<T> : BaseGridPanel<T>, IChildListPanel
        where T : EditableObject<T>, IObject
    {
        /// <summary>
        /// 
        /// </summary>
        public BaseGroupPanel()
        {
            InitializeComponent();
            Grid.GridView.OptionsView.ShowGroupPanel = false;
            Grid.GridView.ShowingEditor += OnGridViewShowingEditor;
            Grid.GridView.ValidateRow += OnGridViewValidateRow;
            Grid.GridView.OptionsCustomization.AllowQuickHideColumns = false;
            Grid.GridView.OptionsCustomization.AllowColumnMoving = false;
            Grid.GridView.OptionsFilter.AllowFilterEditor = false;
            Grid.GridView.OptionsFind.AllowFindPanel = true;

            for(int i = 0; i < Grid.GridView.Columns.Count; i++)
            {
                var column = Grid.GridView.Columns[i];
                Dictionary<string, string> tags = BusinessObject.GetFieldTags(column.Name);
                if (tags != null && tags.ContainsKey("en"))
                    SystemLanguages.SetEnglishTextEditor(column);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnGridViewValidateRow(object sender, ValidateRowEventArgs e)
        {
            var obj = Grid.GridView.GetFocusedRow() as IObject;
            if (obj == null) return;
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                obj.ValidationEnd -= ObjOnValidationEnd;
                obj.ValidationEnd += ObjOnValidationEnd;
                var validator = obj.GetAccessor() as IObjectValidator;
                if (validator == null) return;
                ErrorMessage = String.Empty;
                var valid = validator.Validate(manager, obj, true, true, true);

                if (!valid && (ErrorMessage.Length > 0))
                {
                    if (!ErrorMessage.Substring(ErrorMessage.Length - 1, 1).Equals(".")) ErrorMessage += ".";
                    e.ErrorText = ErrorMessage;
                    e.Valid = false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ObjOnValidationEnd(object sender, ValidationEventArgs args)
        {
            var message = ErrorForm.GetMessage(args.MessageId) ?? String.Empty;

            ErrorMessage =
                ((args.Pars != null) && (args.Pars.Length > 0))
                    ? String.Format(message, args.Pars)
                    : message;
        }

        private string ErrorMessage { get; set; }

        private bool m_LayoutDisplaying;

        public void DisplayLayout()
        {
            if (!m_LayoutDisplaying && !WinUtils.IsComponentInDesignMode(this) && Parent != null)
            {
                m_LayoutDisplaying = true;
                try
                {

                    //if (control.Parent == panelMain)
                    {
                        var anchor = Anchor;
                        var dock = Dock;
                        var size = Size;
                        var location = Location;
                        var parentCtl = Parent;
                        var layoutGroup = (LayoutGroup)GetLayout();
                        var layout = (Control)layoutGroup;
                        parentCtl.Controls.Add(layout);
                        layout.Location = location;
                        layout.Size = size;
                        layout.Anchor = anchor;
                        layout.Dock = dock;
                    }
                }
                finally
                {
                    m_LayoutDisplaying = false;
                }
            }
        }

        private IObject m_DataSourceParent;
        private EditableList<T> m_DataSource;

        /// <summary>
        /// Набор данных, с которым работает панель (этот набор передаётся извне; с БД не работает)
        /// </summary>
        public EditableList<T> DataSource
        {
            get { return m_DataSource; }
        }
        public void SetDataSource(IObject parent, EditableList<T> list)
        {
            m_DataSourceParent = parent;
            m_DataSource = list;
            Refresh(m_DataSource, String.Empty);
            DxControlsHelper.SetGridConstraints(Grid.GridControl, ObjectAccessor.MetaInterface(BusinessObject.GetType()));

            if (m_DataSource != null)
                m_DataSource.Creator = CreateNewItem;
            VisualizePermissions();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowHandle"></param>
        /// <returns></returns>
        protected override T GetItemByRowHandle(int rowHandle)
        {
            var focusedRowHandle = rowHandle < 0 ? 0 : rowHandle;
            var focusedIndex = Grid.GridView.GetDataSourceRowIndex(focusedRowHandle);
            return (focusedIndex >= 0) && (focusedIndex < DataSource.Count)
                       ? DataSource[focusedIndex]
                       : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ILayout GetLayout()
        {
            if (ParentLayout == null)
            {
                ParentLayout = this.CreateLayoutGroup(BusinessObject);
                if (ParentLayout != null && ParentLayout.SearchPanelVisible != m_SearchPanelVisible)
                    ParentLayout.SearchPanelVisible = m_SearchPanelVisible;
                OnAfterLayoutCreated();
            }
            return ParentLayout;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override IObject GetItem(object key)
        {
            return DataSource.FirstOrDefault(item => item.Key.Equals(key));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameters"></param>
        /// <param name="actionType"></param>
        /// <param name="readOnly"></param>
        public override IApplicationForm Edit(object key, List<object> parameters, ActionTypes actionType, bool readOnly)
        {
            //TODO переписать метод более понятным
            IObject processedBusinessObject = null;
            var meta = ObjectAccessor.MetaInterface(BusinessObject.GetType());
            if (key == null)
            {
                var createAction =
                    meta.Actions.Find(
                        item => item.ActionType == ActionTypes.Create && item.PanelType == ActionsPanelType.Group);
                if (createAction == null) return this;
                using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    var ret = createAction.RunAction(manager, m_DataSourceParent, parameters);
                    if (ret.result)
                        processedBusinessObject = ret.obj;
                }
                if (processedBusinessObject != null)
                {
                    if (InlineMode == InlineMode.UseCreateButton)
                    {
                        DataSource.Add(processedBusinessObject);
                        for (var i = Grid.GridView.RowCount - 1; i >= 0; i--)
                        {
                            var row = Grid.GridView.GetRow(i);
                            if (row.Equals(processedBusinessObject))
                            {
                                Grid.GridView.FocusedRowHandle = i;
                            }
                        }
                    }
                }
            }
            else
            {
                if (InlineMode == InlineMode.None)
                {
                    var editAction =
                        meta.Actions.Find(
                            item => item.ActionType == actionType && item.PanelType == ActionsPanelType.Group);
                    if (editAction == null)
                        return this;
                    using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        processedBusinessObject = editAction.IsCreate
                                ? editAction.RunAction(manager, null, new List<object> { key }).obj
                                : FocusedItem;
                    }
                }
            }

            if ((InlineMode == InlineMode.None) && (processedBusinessObject != null))
            {
                using (var manager = CreateDbManagerProxy())
                {
                    var clone = processedBusinessObject.CloneWithSetup(manager);

                    #region В отдельном окне

                    //для нового элемента FocusedItem == null
                    var detailPanelName = GetDetailFormName(FocusedItem ?? BusinessObject);
                    if (Utils.IsEmpty(detailPanelName))
                    {
                        ErrorForm.ShowMessage("msgNoDetails", "msgNoDetails");
                        return this;
                    }
                    var detailPanel = ClassLoader.LoadClass(detailPanelName);
                    Dbg.Assert(detailPanel != null, "class {0} can't be loaded", detailPanelName);
                    Dbg.Assert(detailPanel is IApplicationForm,
                               "detail form  {0} doesn't implement IApplicationFrom interface",
                               detailPanelName);
                    if (detailPanel is IBasePanel)
                    {
                        var appForm = detailPanel as IApplicationForm;
                        if (readOnly)
                        {
                            clone.ReadOnly = true;
                            (detailPanel as IBasePanel).ReadOnly = true;
                        }

                        BaseFormManager.ShowModal(appForm, clone);
                        //определяем действие, по которому закрылась форма
                        if (appForm != null)
                        {
                            //если Ok, то заменяем клоном исходный объект
                            var lastAction = appForm.GetLastExecutedAction();
                            if (lastAction != null)
                            {
                                if (lastAction.ActionType.Equals(ActionTypes.Ok)
                                    || lastAction.ActionType.Equals(ActionTypes.Close)
                                    || (lastAction.ActionType.Equals(ActionTypes.Action) && lastAction.IsNeedClose)
                                    )
                                {
                                    var index = DataSource.IndexOf(processedBusinessObject);
                                    if (index < 0)
                                    {
                                        clone.DeepSetChange();
                                        DataSource.Add(clone);
                                    }
                                    else
                                    {
                                        DataSource.ReplaceAndSetChange(processedBusinessObject as T, clone as T);
                                        //DataSource.Remove(o);
                                        //DataSource.Insert(index, clone);
                                    }
                                    SetObjects(clone);

                                    Refresh();
                                }
                                else
                                {
                                    //видимо, происходит отмена. Надо дать возможность удалить временные объекты.
                                    DeleteTempObjects(processedBusinessObject);
                                }
                            }
                            else
                            {
                                //видимо, происходит отмена. Надо дать возможность удалить временные объекты.
                                DeleteTempObjects(processedBusinessObject);
                            }
                        }
                    }

                    #endregion
                }
            }
            return this;
        }

        /// <summary>
        /// Удаление временных объектов, созданных в процессе редактирования
        /// </summary>
        public virtual void DeleteTempObjects(IObject o)
        {

        }

        /// <summary>
        /// Подтверждение объектов созданных в процессе редактирования, если это необходимо
        /// </summary>
        public virtual void SetObjects(IObject o)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hAcode"></param>
        public override void LoadData(ref object id, int? hAcode = null)
        {
            if (WinUtils.IsComponentInDesignMode(this)) return;
            using (var manager = CreateDbManagerProxy())
            {
                var accessor = ObjectAccessor.SelectDetailListInterface(typeof(T));
                if (accessor != null)
                {
                    LifeTimeState = LifeTimeState.DataLoading;
                    SetDataSource(null, new EditableList<T>());
                    DataSource.AddRange(accessor.SelectDetailList(manager, id, hAcode));
                    Grid.GridControl.DataSource = DataSource;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Refresh()
        {
            Refresh(DataSource, GetFilter());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="needQuotes"> </param>
        /// <returns></returns>
        private static object ConvertToRealDataType(object value, out bool needQuotes)
        {
            var valStr = value.ToString();
            needQuotes = true;
            if (valStr.Length > 0)
            {
                Int64 resultInt64;
                Int32 resultInt32;
                Double resultDouble;
                DateTime resultDateTime;

                if (Int64.TryParse(valStr, out resultInt64))
                {
                    needQuotes = false;
                    return resultInt64;
                }
                if (Int32.TryParse(valStr, out resultInt32))
                {
                    needQuotes = false;
                    return resultInt32;
                }
                if (Double.TryParse(valStr, out resultDouble))
                {
                    needQuotes = false;
                    return resultDouble;
                }
                if (DateTime.TryParse(valStr, out resultDateTime))
                {
                    return resultDateTime;
                }
            }
            return value;
        }

        /// <summary>
        /// Фильтр для обновления данных
        /// </summary>
        /// <returns></returns>
        protected virtual string GetFilter()
        {
            var sb = new StringBuilder();
            var pars = SearchPanel.Parameters;
            if (pars.FiltersCount > 0)
            {
                foreach (var fp in pars.Content)
                {
                    var paramName = fp.Key;
                    var filterParam = fp.Value;
                    foreach (var t in filterParam)
                    {
                        sb.Append(AddFilterValue(paramName, t, sb.Length > 0));
                        //sb.AppendFormat("({0})", AddFilterValue(paramName, t, sb.Length > 0));
                    }
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramName"> </param>
        /// <param name="filterParam"></param>
        /// <param name="notFirst"></param>
        /// <returns></returns>
        private string AddFilterValue(string paramName, FilterParams.FilterParam filterParam, bool notFirst)
        {
            var sb = new StringBuilder();

            var needQuotes = !((filterParam.value is Int32) || (filterParam.value is Int64));
            var realvalue = filterParam.value.ToString();
            if (notFirst) sb.Append(" AND ");
            if (filterParam.operation.ToLowerInvariant().Contains("like"))
            {
                realvalue = realvalue.Replace("*", "%");
                if (!realvalue.Contains("%")) realvalue = realvalue + "%";
            }
            if (needQuotes) realvalue = String.Format("'{0}'", realvalue);
            sb.AppendFormat("[{0}] {1} {2}", paramName, filterParam.operation, realvalue);

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="filterString"></param>
        public virtual void Refresh(EditableList<T> dataSource, string filterString)
        {
            var oldRowHandle = m_ListGridControl.GridView.FocusedRowHandle;
            Grid.GridControl.DataSource = dataSource;
            var gridView = (GridView)Grid.GridControl.MainView;
            if (!String.IsNullOrEmpty(filterString))
            {
                filterString = String.Format("!IsMarkedToDelete and ({0})", filterString);
                gridView.ActiveFilter.NonColumnFilter = filterString;
            }
            else
            {
                gridView.ActiveFilter.NonColumnFilter = "!IsMarkedToDelete";
            }
            var newRowHandle = m_ListGridControl.GridView.FocusedRowHandle;
            if (oldRowHandle == newRowHandle) RefreshFocusedItem();
        }

        protected override void VisualizePermissions()
        {
            if (Permissions != null)
            {

                m_ListGridControl.GridView.OptionsView.NewItemRowPosition = Permissions.CanUpdate &&
                                                                            Permissions.CanInsert && InlineMode.Equals(InlineMode.UseNewRow)
                                                                                ? NewItemRowPosition.Top
                                                                                : NewItemRowPosition.None;
                m_ReadOnly = Permissions.IsReadOnlyForEdit;
                m_ListGridControl.GridView.OptionsBehavior.Editable = !ReadOnly && !InlineMode.Equals(InlineMode.None);
                m_ListGridControl.GridView.OptionsBehavior.ReadOnly = ReadOnly || InlineMode.Equals(InlineMode.None);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void GridView_DoubleClick(object sender, EventArgs e)
        {
            if ((FocusedItem == null) || (!EditByDoubleClick)) return;
            Edit(FocusedItem.Key, GetParamsAction(), ReadOnly ? ActionTypes.View : ActionTypes.Edit, ReadOnly);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private object CreateNewItem()
        {
            var meta = ObjectAccessor.MetaInterface(BusinessObject.GetType());
            var createAction = meta.Actions.Find(item => item.ActionType == ActionTypes.Create && item.PanelType == ActionsPanelType.Group);
            if (createAction == null) return null;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return createAction.RunAction(manager, null, GetParamsAction()).obj;
            }
        }

        private bool m_TopPanelVisible;

        /// <summary>
        /// Видимость верхней панели с кнопками управления
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(false), DefaultValue(false)]
        public bool TopPanelVisible
        {
            get { return m_TopPanelVisible; }
            set
            {
                m_TopPanelVisible = value;
                var layout = (GetLayout() as LayoutGroup);
                if (layout != null) layout.TopPanelVisible = m_TopPanelVisible;
            }
        }

        /// <summary>
        /// Можно ли редактировать по двойному клику
        /// </summary>
        public bool EditByDoubleClick { get; set; }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnGridViewShowingEditor(object sender, CancelEventArgs e)
        {
            var gv = sender as GridView;
            if (gv == null) return;
            //RefreshFocusedItem(); ???
            var currentBo = FocusedItem;
            if (currentBo == null) return;
            e.Cancel = currentBo.IsReadOnly(gv.FocusedColumn.FieldName);
            if (!e.Cancel)
            {
                Dictionary<string, string> tags = currentBo.GetFieldTags(gv.FocusedColumn.FieldName);
                if (tags != null)
                {
                    if (tags.ContainsKey("en"))
                    {
                        SystemLanguages.SwitchInputLanguage("en");
                    }
                    else if (tags.ContainsKey("def"))
                    {
                        SystemLanguages.SwitchInputLanguage("def");
                    }
                }

            }
        }
    }

}
