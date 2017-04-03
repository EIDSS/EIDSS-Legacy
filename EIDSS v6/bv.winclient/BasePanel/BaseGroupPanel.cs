using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLToolkit.EditableObjects;
using bv.common.Core;
using bv.common.Diagnostics;
using bv.common.Enums;
using bv.model.BLToolkit;
using bv.model.Helpers;
using bv.model.Model.Core;
using bv.winclient.Core;
using bv.winclient.Layout;
using bv.winclient.Localization;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace bv.winclient.BasePanel
{
    public partial class BaseGroupPanel<T> : BaseGridPanel<T>, IChildListPanel
        where T : EditableObject<T>, IObject
    {
        private object m_Key;
        private bool m_LayoutDisplaying;
        private IObject m_DataSourceParent;
        private EditableList<T> m_DataSource;
        private bool m_TopPanelVisible;

        /// <summary>
        /// </summary>
        public BaseGroupPanel()
        {
            InitializeComponent();
            try
            {
                Grid.GridView.BeginUpdate();
                Grid.GridView.OptionsView.ShowGroupPanel = false;
                Grid.GridView.ShowingEditor += OnGridViewShowingEditor;
                Grid.GridView.FocusedRowChanged += OnFocusedRowChanged;
                Grid.GridView.ValidateRow += OnGridViewValidateRow;
                Grid.GridView.RowUpdated += GridView_RowUpdated;
                Grid.GridView.OptionsCustomization.AllowQuickHideColumns = false;
                Grid.GridView.OptionsCustomization.AllowColumnMoving = false;
                Grid.GridView.OptionsFilter.AllowFilterEditor = false;
                Grid.GridView.OptionsFind.AllowFindPanel = true;
                Grid.GridView.OptionsBehavior.AutoPopulateColumns = false;

                for (int i = 0; i < Grid.GridView.Columns.Count; i++)
                {
                    GridColumn column = Grid.GridView.Columns[i];
                    Dictionary<string, string> tags = BusinessObject.GetFieldTags(column.Name);
                    if (tags != null && tags.ContainsKey("en"))
                    {
                        SystemLanguages.SetEnglishTextEditor(column);
                    }
                }
                Grid.GridView.InitNewRow += InitNewRow;

            }
            finally
            {
                Grid.GridView.EndUpdate();
            }
        }

        void GridView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            AfterChangeRow(e);
        }

        public override object Key
        {
            get { return m_Key; }
        }

        /// <summary>
        ///     Набор данных, с которым работает панель (этот набор передаётся извне; с БД не работает)
        /// </summary>
        public EditableList<T> DataSource
        {
            get { return m_DataSource; }
        }

        /// <summary>
        ///     Видимость верхней панели с кнопками управления
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(false), DefaultValue(false)]
        public bool TopPanelVisible
        {
            get { return m_TopPanelVisible; }
            set
            {
                m_TopPanelVisible = value;
                var layout = (GetLayout() as LayoutGroup);
                if (layout != null)
                {
                    layout.TopPanelVisible = m_TopPanelVisible;
                }
            }
        }

        /// <summary>
        ///     Можно ли редактировать по двойному клику
        /// </summary>
        public bool EditByDoubleClick { get; set; }

        private string ErrorMessage { get; set; }

        private void OnFocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            var obj = Grid.GridView.GetFocusedRow() as IObject;
            if (obj != null) m_Key = obj.Key;
        }

        protected bool m_ValidatingRow;
        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnGridViewValidateRow(object sender, ValidateRowEventArgs e)
        {
            var obj = Grid.GridView.GetFocusedRow() as IObject;
            if (obj == null) return;
            m_ValidatingRow = true;
            try
            {
                using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    obj.ValidationEnd -= ObjOnValidationEnd;
                    obj.ValidationEnd += ObjOnValidationEnd;

                    var validator = obj.GetAccessor() as IObjectValidator;
                    if (validator == null)
                    {
                        return;
                    }
                    ErrorMessage = String.Empty;
                    bool valid = validator.Validate(manager, obj, true, true, true);

                    if (!valid && (ErrorMessage.Length > 0))
                    {
                        if (!ErrorMessage.Substring(ErrorMessage.Length - 1, 1).Equals("."))
                        {
                            ErrorMessage += ".";
                        }
                        e.ErrorText = ErrorMessage;
                        e.Valid = false;
                    }
                }
            }
            finally
            {
                m_ValidatingRow = false;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ObjOnValidationEnd(object sender, ValidationEventArgs args)
        {
            string message = ErrorForm.GetMessage(args.MessageId) ?? String.Empty;

            ErrorMessage =
                ((args.Pars != null) && (args.Pars.Length > 0))
                    ? String.Format(message, args.Pars)
                    : message;
        }
        private void InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var obj = Grid.GridView.GetRow(e.RowHandle) as IObject;
            if (obj != null)
            {
                obj.ValidationEnd += ObjOnValidationEnd;
                obj.Validation += ShowError;
            }
        }

        private void ShowError(object sender, ValidationEventArgs args)
        {
            if (!m_ValidatingRow)
                ErrorForm.ShowWarningFormat(args.MessageId, null, args.Pars);
        }

        public void DisplayLayout()
        {
            if (!m_LayoutDisplaying && !WinUtils.IsComponentInDesignMode(this) && Parent != null)
            {
                m_LayoutDisplaying = true;
                try
                {
                    //if (control.Parent == panelMain)
                    {
                        AnchorStyles anchor = Anchor;
                        DockStyle dock = Dock;
                        Size size = Size;
                        Point location = Location;
                        Control parentCtl = Parent;
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

        public void SetDataSource(IObject parent, EditableList<T> list, int? haCode = null)
        {
            m_DataSourceParent = parent;
            m_DataSource = list;
            m_DataSource.ForEach(SetEnvironment);
            Refresh(m_DataSource, String.Empty);
            DxControlsHelper.SetGridConstraints(Grid.GridControl, ObjectAccessor.MetaInterface(BusinessObject.GetType()));

            if (m_DataSource != null)
            {
                m_DataSource.Creator = CreateNewItem;
            }

            VisualizePermissions();
            var acc = BusinessObject.GetAccessor() as IObjectCreator;
            if (acc != null)
            {
                using (DbManagerProxy manager = CreateDbManagerProxy())
                {
                    BusinessObject = acc.CreateFake(manager, parent, haCode);
                    //BusinessObject.SetValue(BusinessObject.KeyName, (PredefinedObjectId.FakeListObject).ToString(CultureInfo.InvariantCulture));
                    var layout = GetLayout();
                    if (layout != null)
                        layout.RefreshActionButtons();
                    InitGridBehavior(BusinessObject);
                }
            }
        }

        public virtual void InitGridBehavior(IObject dummyObjectWithLookups)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="rowHandle"></param>
        /// <returns></returns>
        protected override T GetItemByRowHandle(int rowHandle)
        {
            //int focusedRowHandle = rowHandle < 0 ? 0 : rowHandle;
            int focusedIndex = Grid.GridView.GetDataSourceRowIndex(rowHandle);
            return (focusedIndex >= 0) && (focusedIndex < DataSource.Count)
                       ? DataSource[focusedIndex]
                       : null;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override ILayout GetLayout()
        {
            if (ParentLayout == null)
            {
                bool savedReadonlyStateUpdated = m_ReadonlyStateUpdated;
                m_ReadonlyStateUpdated = true;
                ParentLayout = this.CreateLayoutGroup(BusinessObject);
                m_ReadonlyStateUpdated = savedReadonlyStateUpdated;
                if (ParentLayout != null && ParentLayout.SearchPanelVisible != m_SearchPanelVisible)
                {
                    ParentLayout.SearchPanelVisible = m_SearchPanelVisible;
                }
                OnAfterLayoutCreated();
            }
            return ParentLayout;
        }

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override IObject GetItem(object key)
        {
            return DataSource.FirstOrDefault(item => item.Key.Equals(key));
        }

        /// <summary>
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
                ActionMetaItem createAction = meta.Actions.Find(item => item.ActionType == ActionTypes.Create && item.PanelType == ActionsPanelType.Group);
                if (createAction == null) return this;

                using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    var ret = createAction.RunAction(manager, m_DataSourceParent, parameters);
                    if (ret.result)
                    {
                        processedBusinessObject = ret.obj;
                    }
                }
                if (processedBusinessObject != null)
                {
                    SetEnvironment(processedBusinessObject);
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
                    ActionMetaItem editAction = meta.Actions.Find(
                        item => item.ActionType == actionType && item.PanelType == ActionsPanelType.Group);
                    if (editAction == null) return this;

                    using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        processedBusinessObject = editAction.IsCreate
                            ? editAction.RunAction(manager, null as IObject, new List<object> { key }).obj
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
                        /*
                        var layout = GetLayout() as LayoutEmpty;
                        if (layout != null)
                        {
                            var cancel = false;
                            layout.OnBeforeActionExecutingRaised(this, createAction ?? editAction, clone, ref cancel);
                            if (cancel) return this;
                        }
                        */
                        BaseFormManager.ShowModal(appForm, clone);
                        SetEnvironment(clone);
                        //определяем действие, по которому закрылась форма
                        if (appForm != null)
                        {
                            //если Ok, то заменяем клоном исходный объект
                            LastExecutedActionInternal = appForm.GetLastExecutedAction();
                            if (LastExecutedActionInternal != null)
                            {
                                if (LastExecutedActionInternal.ActionType.Equals(ActionTypes.Ok)
                                    || LastExecutedActionInternal.ActionType.Equals(ActionTypes.Close)
                                    || (LastExecutedActionInternal.ActionType.Equals(ActionTypes.Action) && LastExecutedActionInternal.IsNeedClose)
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
        ///     Удаление временных объектов, созданных в процессе редактирования
        /// </summary>
        public virtual void DeleteTempObjects(IObject o)
        {
        }

        /// <summary>
        ///     Подтверждение объектов созданных в процессе редактирования, если это необходимо
        /// </summary>
        public virtual void SetObjects(IObject o)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hAcode"></param>
        public override void LoadData(ref object id, int? hAcode = null)
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return;
            }
            using (DbManagerProxy manager = CreateDbManagerProxy())
            {
                IObjectSelectDetailList accessor = ObjectAccessor.SelectDetailListInterface(typeof(T));
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
        /// </summary>
        public override void Refresh()
        {
            Refresh(DataSource, GetFilter());
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="needQuotes"> </param>
        /// <returns></returns>
        private static object ConvertToRealDataType(object value, out bool needQuotes)
        {
            string valStr = value.ToString();
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
        ///     Фильтр для обновления данных
        /// </summary>
        /// <returns></returns>
        protected virtual string GetFilter()
        {
            var sb = new StringBuilder();
            FilterParams pars = SearchPanel.Parameters;
            if (pars.FiltersCount > 0)
            {
                foreach (KeyValuePair<string, List<FilterParams.FilterParam>> fp in pars.Content)
                {
                    string paramName = fp.Key;
                    List<FilterParams.FilterParam> filterParam = fp.Value;
                    foreach (FilterParams.FilterParam t in filterParam)
                    {
                        sb.Append(AddFilterValue(paramName, t, sb.Length > 0));
                        //sb.AppendFormat("({0})", AddFilterValue(paramName, t, sb.Length > 0));
                    }
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// </summary>
        /// <param name="paramName"> </param>
        /// <param name="filterParam"></param>
        /// <param name="notFirst"></param>
        /// <returns></returns>
        private string AddFilterValue(string paramName, FilterParams.FilterParam filterParam, bool notFirst)
        {
            var sb = new StringBuilder();

            bool needQuotes = !((filterParam.value is Int32) || (filterParam.value is Int64));
            string realvalue = filterParam.value.ToString();
            if (notFirst)
            {
                sb.Append(" AND ");
            }
            if (filterParam.operation.ToLowerInvariant().Contains("like"))
            {
                realvalue = realvalue.Replace("*", "%");
                if (!realvalue.Contains("%"))
                {
                    realvalue = realvalue + "%";
                }
            }
            if (needQuotes)
            {
                realvalue = String.Format("'{0}'", realvalue);
            }
            sb.AppendFormat("[{0}] {1} {2}", paramName, filterParam.operation, realvalue);

            return sb.ToString();
        }

        /// <summary>
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="filterString"></param>
        public virtual void Refresh(EditableList<T> dataSource, string filterString)
        {
            var oldRowHandle = m_ListGridControl.GridView.FocusedRowHandle;
            try
            {
                //Grid.GridControl.BeginInit();
                //Grid.GridControl.BeginUpdate();
                //Grid.GridView.BeginInit();
                //Grid.GridView.BeginUpdate();
                //Grid.GridView.BeginDataUpdate();
                Grid.GridControl.DataSource = dataSource;
                if (dataSource == null)
                    return;
                foreach (IObject obj in dataSource)
                {
                    obj.ValidationEnd += ObjOnValidationEnd;
                    obj.Validation += ShowError;
                }
                var gridView = (GridView)Grid.GridControl.MainView;
                if (!String.IsNullOrEmpty(filterString))
                {
                    filterString = String.Format("!IsMarkedToDelete and ({0})", filterString);
                    Grid.GridView.ActiveFilter.NonColumnFilter = filterString;
                }
                else
                {
                    Grid.GridView.ActiveFilter.NonColumnFilter = "!IsMarkedToDelete";
                }

                int newRowHandle = Grid.GridView.FocusedRowHandle;
                if (oldRowHandle == newRowHandle)
                {
                    RefreshFocusedItem();
                }
            }
            finally
            {
                //Grid.GridView.EndDataUpdate();
                //Grid.GridView.EndUpdate();
                //Grid.GridView.EndInit();
                //Grid.GridControl.EndUpdate();
                //Grid.GridControl.EndInit();
            }
        }

        protected override void VisualizePermissions()
        {
            if (Permissions != null)
            {
                Grid.GridView.OptionsView.NewItemRowPosition = Permissions.CanUpdate &&
                                                                            Permissions.CanInsert && InlineMode.Equals(InlineMode.UseNewRow)
                                                                                ? NewItemRowPosition.Top
                                                                                : NewItemRowPosition.None;
                m_ReadOnly = Permissions.IsReadOnlyForEdit;
                Grid.GridView.OptionsBehavior.Editable = !ReadOnly && !InlineMode.Equals(InlineMode.None);
                Grid.GridView.OptionsBehavior.ReadOnly = ReadOnly || InlineMode.Equals(InlineMode.None);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void GridView_DoubleClick(object sender, EventArgs e)
        {
            if ((FocusedItem == null) || (!EditByDoubleClick)) return;
            PerformAction(ReadOnly ? "View" : "Edit");
            //Edit(FocusedItem.Key, GetParamsAction(), ReadOnly ? ActionTypes.View : ActionTypes.Edit, ReadOnly);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        private object CreateNewItem()
        {
            var meta = ObjectAccessor.MetaInterface(BusinessObject.GetType());
            var createAction =
                meta.Actions.Find(item => item.ActionType == ActionTypes.Create && item.PanelType == ActionsPanelType.Group);
            if (createAction == null) return null;

            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var actionResult = createAction.RunAction(manager, BusinessObject.Parent, GetParamsAction()).obj;
                if (actionResult != null)
                {
                    RootPanel.UpdateControlsState();
                    /*
                    var layout = GetLayout() as LayoutGroup;
                    if ((layout != null) && (layout.TopGroupActionPanel != null))
                    {
                        layout.TopGroupActionPanel.RaiseAfterActionExecuted(createAction, BusinessObject);
                    }
                    */
                }
                return actionResult;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnGridViewShowingEditor(object sender, CancelEventArgs e)
        {
            var gv = sender as GridView;
            if (gv == null)
            {
                return;
            }
            //RefreshFocusedItem(); ???
            IObject currentBo = FocusedItem;
            if (currentBo == null)
            {
                return;
            }
            e.Cancel = currentBo.IsReadOnly(gv.FocusedColumn.FieldName);
            if (e.Cancel)
            {
                return;
            }
            Dictionary<string, string> tags = currentBo.GetFieldTags(gv.FocusedColumn.FieldName);
            if (tags == null)
            {
                return;
            }
            if (tags.ContainsKey("en"))
            {
                SystemLanguages.SwitchInputLanguage("en");
            }
            else if (tags.ContainsKey("def"))
            {
                SystemLanguages.SwitchInputLanguage("def");
            }
        }

        protected virtual void AfterChangeRow(RowObjectEventArgs e)
        {

        }

        /// <summary>
        /// Если в ходе выполнения действия вызывалось другое действие, то оно будет в этом свойстве
        /// </summary>
        public ActionMetaItem LastExecutedActionInternal { get; private set; }

    }
}
