using System;
using System.Collections.Generic;
using System.Linq;
using BLToolkit.EditableObjects;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Diagnostics;
using bv.common.Enums;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel.ListPanelComponents;
using bv.winclient.Core;
using bv.winclient.Layout;
using bv.winclient.Localization;
using bv.winclient.SearchPanel;
using DevExpress.XtraGrid.Views.Base;
using System.ComponentModel;

namespace bv.winclient.BasePanel
{
    public partial class BaseListPanel<T> : BaseGridPanel<T>
        where T : EditableObject<T>, IObject
    {
        public BaseListPanel()
        {
            InitializeComponent();
            if (WinUtils.IsComponentInDesignMode(this))
                return;
            DataSource = new List<T>();
            Grid.GridView.OptionsMenu.EnableColumnMenu = true;
            Grid.GridView.OptionsMenu.EnableGroupPanelMenu = false;
            Grid.GridView.OptionsMenu.EnableFooterMenu = false;
            Grid.GridView.OptionsMenu.ShowAutoFilterRowItem = false;
            var bvGridControl = Grid.GridControl as BvGridControl;
            if (bvGridControl != null)
            {
                bvGridControl.AllowCustomization = true;
            }
            ParentChanged+=BaseListPanel_ParentChanged;
            //LoadGridLayout();
            //Grid.GridView.PopupMenuShowing += OnGridViewPopupMenuShowing;
            //Grid.GridView.ShowCustomizationForm += OnShowCustomizationForm;
            //Grid.GridView.DragObjectOver += OnDragObjectOver;
        }

        private void BaseListPanel_ParentChanged(object sender, EventArgs e)
        {
            LoadGridLayout();
        }

        public override IObject GetItem(object key)
        {
            //TODO сделать для DataSource общего предка и вынести в BaseGridPanel
            return DataSource.FirstOrDefault(item => item.Key == key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameters">
        /// The predefined order of parameters:
        /// 0 - key of onject to edit
        /// 1- instance of IObject to edit
        /// 2 - instance of IBaseListPanel
        /// 3 - startup parameters
        /// </param>
        /// <param name="actionType"></param>
        /// <param name="readOnly"></param>
        public override IApplicationForm Edit(object key, List<object> parameters, ActionTypes actionType, bool readOnly)
        {
            IObject bo = null;
            if ((parameters != null) && (parameters.Count > 1) && (parameters[1] is IObject))
            {
                bo = (IObject)parameters[1];
            }
            Dictionary<string, object> startupParams = null;
            if ((parameters != null) && (parameters.Count > 3) && (parameters[3] is Dictionary<string, object>))
                startupParams = parameters[3] as Dictionary<string, object>;
            var detailPanelName = GetDetailFormName(bo);

            if (Utils.IsEmpty(detailPanelName))
            {
                ErrorForm.ShowMessage("msgNoDetails", "msgNoDetails");
                return null;
            }
            object detailPanel;
            using (new WaitDialog())
            {
                detailPanel = ClassLoader.LoadClass(detailPanelName);
                Dbg.Assert(detailPanel != null, "class {0} can't be loaded", detailPanelName);
                Dbg.Assert(detailPanel is IApplicationForm,
                           "detail form  {0} doesn't implement IApplicationFrom interface",
                           detailPanelName);
                InitDetailForm(detailPanel);
                if (detailPanel is IBasePanel)
                {
                    //((IBasePanel)detailPanel).ReadOnly = readOnly;

                    var meta = ObjectAccessor.MetaInterface(BusinessObject.GetType());
                    var foundAction =
                        meta.Actions.Find(
                            item =>
                            ((item.ActionType == ActionTypes.View) || (item.ActionType == ActionTypes.Edit)) &&
                            (item.PanelType == ActionsPanelType.Top));
                    if (foundAction != null)
                    {
                        using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                        {
                            var childObject = foundAction.RunAction(manager, null as IObject, new List<object> {key});
                            if (childObject.result)
                            {
                                if (readOnly)
                                    BaseFormManager.ShowNormal_ReadOnly(detailPanel as IApplicationForm, childObject.obj, startupParams);
                                else
                                    BaseFormManager.ShowNormal(detailPanel as IApplicationForm, childObject.obj, startupParams);
                            }
                        }
                    }
                }
                else
                {

                    if (Utils.IsEmpty(key)) key = null;
                    if (readOnly)
                        BaseFormManager.ShowNormal_ReadOnly(detailPanel as IApplicationForm, ref key, startupParams);
                    else
                        BaseFormManager.ShowNormal(detailPanel as IApplicationForm, ref key, startupParams);
                }
            }
            return detailPanel as IApplicationForm;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hAcode"></param>
        public override void LoadData(ref object id, int? hAcode = null)
        {
            LoadData();
        }

        public delegate void RefreshListDelegate();

        /// <summary>
        /// 
        /// </summary>
        public override void LoadData()
        {
            if (IsHandleCreated)
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new RefreshListDelegate(LoadData));
                }
                else
                {
                    Refresh();
                }
            }
        }

        private List<T> m_DataSource;
        /// <summary>
        /// Набор данных, с которым работает панель (получается из БД)
        /// </summary>
        public List<T> DataSource
        {
            get { return m_DataSource; } 
            set 
            { 
                m_DataSource = value; 
            }
        }

        protected override T GetItemByRowHandle(int rowHandle)
        {
            int focusedRowHandle = rowHandle < 0 ? 0 : rowHandle;
            int focusedIndex = Grid.GridView.GetDataSourceRowIndex(focusedRowHandle);
            return (focusedIndex >= 0) && (focusedIndex < DataSource.Count())
                       ? DataSource[focusedIndex]
                       : null;
        }

        public override void Refresh()
        {
            if (WinUtils.IsComponentInDesignMode(this)) return;

            try
            {
                using (new WaitDialog(WaitDialogType.FormLoading))
                {
                    using (var manager = CreateDbManagerProxy())
                    {
                        var accessor = ObjectAccessor.SelectListInterface(typeof (T));
                        FilterParams filter;
                        if (SearchPanel == null || !SearchPanelVisible)
                            filter = StaticFilter;
                        else
                        {
                            var pars = SearchPanel.Parameters;
                            filter = pars == null
                                         ? StaticFilter
                                         : pars.Merge(StaticFilter);
                        }

                        var selectedList = accessor.SelectList(manager, filter);
                        DataSource = selectedList.Cast<T>().ToList();
                        HidePersonalData(DataSource);

                        var oldObj = m_ListGridControl.GridView.GetFocusedRow() as IObject;
                        var oldRowHandle = m_ListGridControl.GridView.FocusedRowHandle;

                        m_ListGridControl.GridView.BeginSelection();

                        Grid.GridControl.DataSource = DataSource;
                        //var bs = new BindingSource();
                        //bs.DataSource = DataSource;
                        //Grid.GridControl.DataSource = bs;

                        var newRowHandle = m_ListGridControl.GridView.FocusedRowHandle;

                        if ((oldObj != null) && (oldRowHandle >= 0))
                        {
                            var fo = selectedList.FirstOrDefault(m => (long) m.Key == (long) oldObj.Key);
                            var index = selectedList.IndexOf(fo);
                            if (index >= 0)
                            {
                                var oh = m_ListGridControl.GridView.GetRowHandle(index);
                                m_ListGridControl.GridView.FocusedRowHandle = oh;
                                m_ListGridControl.GridView.ClearSelection();
                                m_ListGridControl.GridView.SelectRow(oh);
                            }
                        }

                        m_ListGridControl.GridView.EndSelection();

                        if (oldRowHandle == newRowHandle)
                        {
                            // call handler manually because FocusedRowChanged not fired when when oldRowHandle == newRowHandle
                            GridView_FocusedRowChanged(this, new FocusedRowChangedEventArgs(oldRowHandle, newRowHandle));
                        }
                        if ((!BaseSettings.IgnoreTopMaxCount) && (DataSource.Count == BaseSettings.SelectTopMaxCount))
                        {
                            ErrorForm.ShowWarning("msgTooBigRecordsCount",
                                                  "Number of returned records is too big. Not all records are shown on the form. Please change search criteria and try again");
                        }
                        // NOTE: uncommented in 5-th version because of new requirenemt
                        //"https://repos.btrp.net/BTRP/Project_Documents/10x-Business Analysis/01 Human module/01.006 The Number of Records on Human Cases and Vet Cases List forms.doc"
                        long? totalCount = accessor.SelectCount(manager);
                        m_ListGridControl.ShowTotal(DataSource.Count, totalCount);
                    }
                }
            }
            catch (DbModelTimeoutException)
            {
                ErrorForm.ShowWarning("msgTimeoutList",
                                      "Cannot retrieve records from database because of the timeout. Please change search criteria and try again");
            }
            catch (DbModelException ex1)
            {
                if (string.IsNullOrEmpty(ex1.MessageId))
                    ErrorForm.ShowError(ex1.Message, ex1);
                else
                    ErrorForm.ShowError(ex1.MessageId, ex1.Message, ex1);
            }
            catch (Exception ex)
            {
                ErrorForm.ShowError(ex.Message, ex);
            }

        }

        protected virtual void HidePersonalData(List<T> list)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void GridView_DoubleClick(object sender, EventArgs e)
        {
            if (FocusedItem == null) return;
            if (SelectMode != SelectMode.None)
            {
                PerformAction("Select");
                //BaseFormManager.Close(this, DialogResult.OK);
                return;
            }

            var pt = Grid.GridControl.PointToClient(MousePosition);
            var info = Grid.GridView.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                PerformAction(FindAction("Edit") ? "Edit" : "View");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ILayout GetLayout()
        {
            if (ParentLayout == null)
            {
                ParentLayout = this.CreateLayoutAdvanced(BusinessObject, Caption, FormID, Icon);
                if (ParentLayout != null && ParentLayout.SearchPanelVisible != m_SearchPanelVisible)
                    ParentLayout.SearchPanelVisible = m_SearchPanelVisible;
                OnAfterLayoutCreated();
            }
            return ParentLayout;
        }

        public override ISearchPanel CreateSearchPanel(ActionPanel.ActionPanel panel, Func<SearchPanelMetaItem, SearchPanelMetaItem> item, Func<IObject, IObject> adjustObject)
        {
            //return new BaseSearchPanel();
            if (m_SearchPanel == null)
            {
                m_SearchPanel = new BaseSearchPanel(typeof(T), true, InitialSearchFilter, panel, SearchPanelLabelWidth, item, adjustObject);
                m_SearchPanel.Search += SearchPanel_Search;
            }
            return m_SearchPanel;
        }

        public override bool Delete(object key)
        {
            var gridDataSource = ((List<T>)Grid.GridControl.DataSource);
            var item = gridDataSource.First(c => c.Key.Equals(key));
            if (item == null)
            {
                return false;
            }

            gridDataSource.Remove(item);
            DataSource.Remove(item);

            Grid.GridControl.RefreshDataSource();

            return true;
        }


        /// <summary>
        /// Static filter ia always applied to the search criteria of the opened form and doesn't diaplay in the search panel
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(false)]
        public FilterParams StaticFilter { get; set; }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Localizable(false)]
        public override bool IsSingleTone
        {
            get { return true; }
        }

    }
}
