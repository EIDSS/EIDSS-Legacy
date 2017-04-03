using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BLToolkit.EditableObjects;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Diagnostics;
using bv.common.Enums;
using bv.common.Resources;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.Core;
using bv.winclient.Layout;
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
            DataSource = new List<T>();
            Grid.GridView.OptionsMenu.EnableColumnMenu = true;
            Grid.GridView.OptionsMenu.EnableGroupPanelMenu = false;
            Grid.GridView.OptionsMenu.EnableFooterMenu = false;
            Grid.GridView.OptionsMenu.ShowAutoFilterRowItem = false;
            Grid.GridView.PopupMenuShowing += OnGridViewPopupMenuShowing;
            Grid.GridView.ShowCustomizationForm += OnShowCustomizationForm;
            Grid.GridView.DragObjectOver += OnDragObjectOver;
        }


        public override IObject GetItem(object key)
        {
            //TODO сделать для DataSource общего предка и вынести в BaseGridPanel
            return DataSource.FirstOrDefault(item => item.Key == key);
        }

        /// <summary>
        /// Возвращает имя файла Layout для этого объекта
        /// </summary>
        /// <returns></returns>
        private string GetGridLayoutFilename()
        {
            var di = Directory.GetParent(Application.LocalUserAppDataPath);
            var dir = Path.Combine(di.FullName, "Grids");
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            var filename = Path.Combine(dir, Path.ChangeExtension(BusinessObject.ObjectName, "xml"));
            return filename;
        }

        /// <summary>
        /// Восстановление визуального представления таблицы
        /// </summary>
        protected override void LoadGridLayout()
        {
            base.LoadGridLayout();

            //определяем имя файла, где может храниться Layout
            if ((BusinessObject != null) && (!String.IsNullOrEmpty(BusinessObject.ObjectName)))
            {
                var filename = GetGridLayoutFilename();
                if ((filename.Length > 0) && (File.Exists(filename)))
                {
                    try
                    {
                        Grid.GridView.RestoreLayoutFromXml(filename);
                    }
                    catch
                    {
                        //если файл битый, то удаляем его
                        File.Delete(filename);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="closeMode"></param>
        /// <returns></returns>
        public override bool Close(FormClosingMode closeMode)
        {
            //сохраняем layout грида
            //определяем имя файла, где может храниться Layout
            if ((BusinessObject != null) && (!String.IsNullOrEmpty(BusinessObject.ObjectName)))
            {
                var filename = GetGridLayoutFilename();
                if (filename.Length > 0)
                {
                    Grid.GridView.SaveLayoutToXml(filename);
                }
            }
            return base.Close(closeMode);
        }

        private void OnDragObjectOver(object sender, DragObjectOverEventArgs e)
        {

            var column = e.DragObject as GridColumn;

            if (column != null && column.View.VisibleColumns.Count == 1 && column.View.VisibleColumns[0] == column && e.DropInfo.Index < 0)
            {
                e.DropInfo.Valid = false;
            }
        }

        private void OnShowCustomizationForm(object sender, EventArgs e)
        {
            Grid.GridView.CustomizationForm.Text = XtraStrings.Get("GridStringId.MenuColumnColumnCustomization", "Column Chooser");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnGridViewPopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.Menu == null) return;
            if (e.Menu.MenuType != GridMenuType.Column) return;

            for (var i = e.Menu.Items.Count - 1; i >= 0; i--)
            {
                var it = e.Menu.Items[i];
                if (!it.Tag.ToString().Equals("MenuColumnRemoveColumn") && !it.Tag.ToString().Equals("MenuColumnColumnCustomization"))
                    e.Menu.Items.Remove(it);
                else if (Grid.GridView.VisibleColumns.Count == 1 && it.Tag.ToString().Equals("MenuColumnRemoveColumn"))
                    e.Menu.Items.Remove(it);
            }
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

        /// <summary>
        /// Набор данных, с которым работает панель (получается из БД)
        /// </summary>
        public List<T> DataSource { get; set; }

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
                        var fo = selectedList.FirstOrDefault(m => (long)m.Key == (long)oldObj.Key);
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
                if (FindAction("Edit"))
                    PerformAction("Edit");
                else
                    PerformAction("View");

                //Edit(FocusedItem.Key, GetParamsAction(), ReadOnly ? ActionTypes.View : ActionTypes.Edit, ReadOnly);
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

        public override ISearchPanel CreateSearchPanel(bv.winclient.ActionPanel.ActionPanel panel, Func<SearchPanelMetaItem, SearchPanelMetaItem> item, Func<IObject, IObject> AdjustObject)
        {
            //return new BaseSearchPanel();
            if (m_SearchPanel == null)
            {
                m_SearchPanel = new BaseSearchPanel(typeof(T), true, InitialSearchFilter, panel, SearchPanelLabelWidth, item, AdjustObject);
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
