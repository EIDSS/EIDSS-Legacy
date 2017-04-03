using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraTab;
using EIDSS.RAM.Components;
using EIDSS.RAM.Presenters;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands.Layout;
using EIDSS.RAM_DB.Common.EventHandlers;
using EIDSS.RAM_DB.DBService;
using EIDSS.RAM_DB.DBService.DataSource;
using EIDSS.RAM_DB.Views;
using EIDSS.Reports.OperationContext;
using bv.common;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.win;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Resources;
using ErrorForm = bv.common.win.ErrorForm;
using LayoutEventArgs = EIDSS.RAM_DB.Common.EventHandlers.LayoutEventArgs;

namespace EIDSS.RAM.Layout
{
    public partial class LayoutDetail : BaseLayoutForm, ILayoutDetailView
    {
        private object m_ChartDataSource;

        private readonly List<XtraTabPage> m_TabPageReportHistory = new List<XtraTabPage>();
        private readonly List<XtraTabPage> m_TabPageMapHistory = new List<XtraTabPage>();
        private readonly LayoutDetailPresenter m_LayoutDetailPresenter;
        private bool m_ReportView;
        public event EventHandler<TabSelectionEventArgs> LayoutTabChanged;
        public event EventHandler<LayoutInfoChangedEventArgs> LayoutInfoChanged;
        public event EventHandler<CopyLayoutEventArgs> CopyLayoutCreating;
        public event EventHandler<PivotFieldPopupMenuEventArgs> PivotFieldMouseRightClick;

        public LayoutDetail()
        {
            try
            {
                Trace.WriteLine(Trace.Kind.Info, "LayoutDetail creating...");
                m_LayoutDetailPresenter = (LayoutDetailPresenter) BaseRamPresenter;

                InitializeComponent();

                if (IsDesignMode())
                {
                    return;
                }

                pivotForm.UseParentDataset = true;
                chartForm.UseParentDataset = true;
                mapForm.UseParentDataset = true;
                pivotReportForm.UseParentDataset = true;

                RegisterChildObject(pivotForm, RelatedPostOrder.SkipPost);
                RegisterChildObject(chartForm, RelatedPostOrder.SkipPost);
                RegisterChildObject(mapForm, RelatedPostOrder.SkipPost);
                RegisterChildObject(pivotReportForm, RelatedPostOrder.SkipPost);

                pivotForm.PivotSelected += pivotForm_CellSelectionChanged;
                pivotForm.PivotGrid.PivotFieldMouseRightClick += (sender, args) => PivotFieldMouseRightClick.SafeRaise(sender, args);
                LayoutTabChanged += LayoutDetail_LayoutTabChanged;

                LookupTableNames = new[] {"Layout"};

                tabPageMap.PageVisible =
                    EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSSPermissionObject.GIS));
            }
            catch (Exception ex)
            {
                if (BaseSettings.ThrowExceptionOnError)
                {
                    throw;
                }
                ErrorForm.ShowError(ex);
            }
        }

        /// <summary>
        ///   Clean up any resources being used.
        /// </summary>
        /// <param name="disposing"> true if managed resources should be disposed; otherwise, false. </param>
        protected override void Dispose(bool disposing)
        {
            m_TabPageReportHistory.Clear();
            m_TabPageMapHistory.Clear();

            UnRegisterChildObject(pivotForm);
            UnRegisterChildObject(chartForm);
            UnRegisterChildObject(mapForm);
            UnRegisterChildObject(pivotReportForm);

            pivotForm.PivotSelected -= pivotForm_CellSelectionChanged;
            LayoutTabChanged -= LayoutDetail_LayoutTabChanged;

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            pivotForm = null;
            chartForm = null;
            mapForm = null;
            pivotReportForm = null;
        }

        public void ExportMapSettingsFromMapToLayout()
        {
            RaiseSendCommand(new RefreshCommand(this, RefreshType.MapSettings));
        }

        #region Properties

        [Browsable(true), DefaultValue(false)]
        public override bool ReadOnly
        {
            get { return base.ReadOnly; }
            set
            {
                if (IsDesignMode())
                {
                    return;
                }
                base.ReadOnly = value;
                var args = new TabPageChangingEventArgs(tabControl.SelectedTabPage,
                                                        tabControl.SelectedTabPage);
                tabControl_SelectedPageChanging(this, args);

                cmdCancelChanges.Visible = GetButtonVisibility(DefaultButtonType.Save);
                cmdSave.Visible = GetButtonVisibility(DefaultButtonType.Save);

                cmdDelete.Visible = GetButtonVisibility("ShowDeleteButtonOnDetailForm", DefaultButtonType.Delete);
                cmdNew.Visible = GetButtonVisibility("ShowNewButtonOnDetailForm", DefaultButtonType.New);

                ArrangeButtons(cmdSave.Top, "BottomButtons", cmdSave.Height, Height - cmdSave.Height - 8);
            }
        }

        internal string SelectedTabPageName
        {
            get { return (tabControl.SelectedTabPage != null) ? tabControl.SelectedTabPage.Name : string.Empty; }
        }

        internal string SelectedPivotTabPageName
        {
            get { return pivotForm.SelectedTabPageName; }
        }

        private Layout_DB LayoutDbService
        {
            get { return m_LayoutDetailPresenter.LayoutDbService; }
        }

        #endregion

        #region Base Methods

        public override object GetKey(string tableName, string keyFieldName)
        {
            return pivotForm.LayoutId;
        }

        public override bool Post(PostType postType)
        {
            Trace.WriteLine(Trace.Kind.Info, "LayoutDetail.Post()");
            if (m_LayoutDetailPresenter.SharedPresenter.ContextKeeper.ContainsContext(ContextValue.Post))
            {
                return base.Post(postType);
            }

            m_LayoutDetailPresenter.PrepareAggregateList(pivotForm.PivotGrid.RamFields.ToList());

            return m_LayoutDetailPresenter.Post(postType);
        }

        public override void Merge(DataSet ds)
        {
            if (!(ds is LayoutDetailDataSet))
            {
                throw new ArgumentException(string.Format("dataset must be of type {0}", typeof (LayoutDetailDataSet)));
            }

            if (baseDataSet.Tables.Count == 0)
            {
                baseDataSet = new LayoutDetailDataSet();
            }
            if (!(baseDataSet is LayoutDetailDataSet))
            {
                throw new RamDbException(string.Format("dataset must be of type {0}", typeof (LayoutDetailDataSet)));
            }
            base.Merge(ds);
        }

        protected override void DefineBinding()
        {
            if (!SharedPresenter.ContextKeeper.ContainsContext(ContextValue.NewLayoutClicking))
            {
                m_LayoutDetailPresenter.NewClicked = false;
            }
            bool layoutAccessible = m_LayoutDetailPresenter.LayoutAccessible;
            tabPageReport.PageEnabled = layoutAccessible;
            pivotForm.PivotAccessible = layoutAccessible;
            m_LayoutDetailPresenter.SetPivotAccessible(layoutAccessible);

            m_TabPageReportHistory.Add(tabPageGrid);
            m_TabPageMapHistory.Add(tabPageGrid);
        }

        #endregion

        #region Raise Events

        private string RaiseCopyLayoutCreating(string disabledCriteria)
        {
            if (CopyLayoutCreating == null)
            {
                return string.Empty;
            }
            var args = new CopyLayoutEventArgs(pivotForm.PivotGrid, disabledCriteria);
            CopyLayoutCreating.SafeRaise(this, args);
            return args.DisabledCriteria;
        }

        #endregion

        #region Event Handlers

        public void OnLayoutSelected(LayoutEventArgs e)
        {
            try
            {
                object id = e.LayoutId;
                LoadData(ref id);

                pivotForm.UpdateCustomizationFormEnabling();

                pivotForm.CustomizationFormEnabled &= ((e.LayoutId > 0) || (m_LayoutDetailPresenter.NewClicked));

                if ((e.LayoutId > 0 && m_LayoutDetailPresenter.SharedPresenter.SharedModel.StandardReports) ||
                    tabControl.SelectedTabPage == tabPageReport)
                {
                    pivotForm.RaiseDataLoadedEvent();
                }
            }
            catch (Exception ex)
            {
                if (BaseSettings.ThrowExceptionOnError)
                {
                    throw;
                }
                ErrorForm.ShowError(ex);
            }
        }

        public void OnChangeOrientation(ChartChangeOrientationEventArgs e)
        {
            try
            {
                if (SharedPresenter.ContextKeeper.ContainsContext(ContextValue.DefineBinding))
                {
                    return;
                }
                Trace.WriteLine(Trace.Kind.Undefine, "LayoutDetail.LayoutDetail_ChangeOrientation()");

                timerUpdateChart.Start();
            }
            catch (Exception ex)
            {
                if (BaseSettings.ThrowExceptionOnError)
                {
                    throw;
                }
                ErrorForm.ShowError(ex);
            }
        }

        public void ProcessAfterPost(object sender, PostHandler handler)
        {
            try
            {
                if (m_LayoutDetailPresenter.IsNewObject)
                {
                    pivotForm.SetChanged(true);
                }
                if (m_LayoutDetailPresenter.ParentHasChanges())
                {
                    m_LayoutDetailPresenter.LayoutDbService.OnAfterPost += handler;
                    cmdSave_Click(sender, EventArgs.Empty);
                }
                else
                {
                    handler(sender, new PostEventArgs((int)PostType.FinalPosting, false));
                }
            }
            finally
            {
                m_LayoutDetailPresenter.LayoutDbService.OnAfterPost -= handler;
            }
        }

        #endregion

        #region Button Methods

        private bool GetButtonVisibility(DefaultButtonType buttonType)
        {
            return Permissions.GetButtonVisibility(buttonType);
        }

        private bool GetButtonVisibility(string configAttributeName, DefaultButtonType buttonType)
        {
            return Config.GetBoolSetting(configAttributeName) &&
                   Permissions.GetButtonVisibility(buttonType);
        }

        private void cmdPublish_Click(object sender, EventArgs e)
        {
            ProcessAfterPost(sender, LayoutDbService_OnAfterPost);
        }

//        private void cmdUseArchive_Changed(object sender, EventArgs e)
//        {
//            ProcessAfterPost(sender, pivotForm.RefreshDataSourceOnUseArchiveDataChanged);
//        }

        private void LayoutDbService_OnAfterPost(object sender, PostEventArgs e)
        {
            string msg = EidssMessages.Get("msgPublishLayout",
                                           "Are you sure you want to publish Layout? Operation cannot be undone.");
            if (MessageForm.Show(msg, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                m_LayoutDetailPresenter.LayoutDbService.Publish();
                object id = m_LayoutDetailPresenter.LayoutDbService.ID;
                LoadData(ref id);
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            #region Save changes in buffer zones if we are in edit mode

            bool cancelChanges = mapForm.CancelMapChanges();
            if (cancelChanges)
            {
                return;
            }

            #endregion

            if (LockHandler())
            {
                try
                {
                    using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.SaveLayoutClicking))
                    {
                        bool isNewObject = m_LayoutDetailPresenter.IsNewObject;
                        if (isNewObject)
                        {
                            pivotForm.SetChanged(true);
                        }
                        ExportMapSettingsFromMapToLayout();
                        if (!Post(PostType.FinalPosting))
                        {
                            SelectLastFocusedControl();
                        }
                        else
                        {
                            LayoutInfoChanged.SafeRaise(this,
                                                        new LayoutInfoChangedEventArgs((long) LayoutDbService.ID, DataRowState.Modified));
                        }
                    }
                }
                finally
                {
                    UnlockHandler();
                }
            }
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            if (LockHandler())
            {
                try
                {
                    using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.NewLayoutClicking))
                    {
                        bool isPost = Permissions.CanInsert && Post(PostType.FinalPosting);
                        if (isPost)
                        {
                            m_LayoutDetailPresenter.NewClicked = true;

                            State = BusinessObjectState.NewObject | BusinessObjectState.IntermediateObject;
                            bool layoutNotSaved =
                                (m_LayoutDetailPresenter.SharedPresenter.SharedModel.SelectedLayoutId == -1);

                            LayoutInfoChanged.SafeRaise(this, new LayoutInfoChangedEventArgs(-1, DataRowState.Added));

                            if (layoutNotSaved)
                            {
                                object id = null;
                                LoadData(ref id);
                            }
                            DefineBinding();

                            mapForm.ReInitMapIfExists();
                            
                        }

                        else
                        {
                            SelectLastFocusedControl();
                        }
                    }
                }
                finally
                {
                    UnlockHandler();
                }
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (LockHandler())
            {
                try
                {
                    DialogResult res = DeletePromptDialog();
                    if (res == DialogResult.No)
                    {
                        SelectLastFocusedControl();
                        return;
                    }
                    try
                    {
                        object key = GetKey("Layout", "idflLayout");
                        if (LayoutDbService.CanDelete(key, LayoutDbService.ObjectName))
                        {
                            if (!Delete(key))
                            {
                                throw new RamException(LayoutDbService.LastError.Text);
                            }

                            if (m_LayoutDetailPresenter.NewClicked)
                            {
                                m_LayoutDetailPresenter.NewClicked = false;
                                DefineBinding();
                                //this is hack to update buttons visibility
                                ReadOnly = ReadOnly;
                                SharedPresenter.SharedModel.SelectedLayoutId = -1;
                            }
                            LayoutInfoChanged.SafeRaise(this, new LayoutInfoChangedEventArgs(-1, DataRowState.Deleted));

                            pivotForm.CustomizationFormEnabled = false;
                        }
                        else
                        {
                            ShowCannotDeleteErrorMessage();
                        }
                    }
                    catch (Exception ex)
                    {
                        if (BaseSettings.ThrowExceptionOnError)
                        {
                            throw;
                        }
                        ErrorForm.ShowError(ex);
                    }
                }
                finally
                {
                    UnlockHandler();
                }
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            if (LockHandler())
            {
                try
                {
                    DataEventManager.Flush();
                    if (HasChanges() == false)
                    {
                        return;
                    }
                    string msg = m_LayoutDetailPresenter.IsNewObject
                                     ? EidssMessages.Get("msgConfirmClearForm", "Clear the form content?")
                                     : EidssMessages.Get("msgConfirmCancelChangesForm",
                                                         "Return the form to the last saved state?");

                    if (MessageForm.Show(msg, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    {
                        SelectLastFocusedControl();
                        return;
                    }
                    object idToLoad = (m_LayoutDetailPresenter.IsNewObject)
                                          ? null
                                          : LayoutDbService.ID;
                    LoadData(ref idToLoad);
                    DefineBinding();
                    if (m_ReportView || tabControl.SelectedTabPage == tabPageReport)
                    {
                        pivotForm.RaiseDataLoadedEvent();
                    }
                }
                finally
                {
                    UnlockHandler();
                }
            }
        }

        private void cmdCopy_Click(object sender, EventArgs e)
        {
            if (LockHandler())
            {
                try
                {
                    if (Post(PostType.FinalPosting) && Permissions.CanInsert)
                    {
                        m_LayoutDetailPresenter.NewClicked = true;
                        if (ReadOnly)
                        {
                            ReadOnly = false;
                        }
                        using (pivotForm.PivotGrid.BeginTransaction())
                        {
                            string oldCriteria = !ReferenceEquals(pivotForm.FilterCriteria, null)
                                                     ? pivotForm.FilterCriteria.ToString()
                                                     : string.Empty;
                            string newCriteria = RaiseCopyLayoutCreating(oldCriteria);
                            if (!pivotForm.ApplyFilter)
                            {
                                pivotForm.PivotGrid.CriteriaString = newCriteria;
                            }
                            pivotForm.UpdateNameSummaryTypeDictionary();
                            pivotForm.UpdateDenominatorIndexes();

                            pivotForm.SetInnerFilterCriteria();
                            pivotForm.InitFilterControlHelper(pivotForm.FilterCriteria);

                            if (!pivotForm.ApplyFilter)
                            {
                                pivotForm.PivotGrid.Criteria = null;
                            }
                        }
                        pivotForm.AddCopyPrefixForLayoutNames();
                        pivotForm.RefreshData();
                    }
                }
                finally
                {
                    UnlockHandler();
                }
            }
        }

        private void ShowCannotDeleteErrorMessage()
        {
            ErrorMessage err = LayoutDbService.LastError;
            string msg = (err == null) ? "The record can't be deleted" : err.Text;
            if (BaseSettings.ThrowExceptionOnError)
            {
                throw new RamException(msg);
            }

            if (err == null)
            {
                ErrorForm.ShowMessage("msgCantDeleteRecord", msg);
            }
            else
            {
                ErrorForm.ShowError(err);
            }
        }

        #endregion

        #region  Command handlers

        public void ProcessLayoutCommand(LayoutCommand layoutCommand)
        {
            Trace.WriteLine(Trace.Kind.Undefine,
                            "LayoutDetails.Process(): executing LayoutCommand for operation {0}.",
                            layoutCommand.Operation.ToString());

            layoutCommand.State = CommandState.Pending;
            switch (layoutCommand.Operation)
            {
                case LayoutOperation.Cancel:
                    cmdCancel_Click(this, EventArgs.Empty);
                    break;
                case LayoutOperation.Copy:
                    cmdCopy_Click(this, EventArgs.Empty);
                    break;
                case LayoutOperation.Delete:
                    cmdDelete_Click(this, EventArgs.Empty);
                    break;
                case LayoutOperation.New:
                    cmdNew_Click(this, EventArgs.Empty);
                    break;
                case LayoutOperation.Save:
                    cmdSave_Click(this, EventArgs.Empty);
                    break;
                case LayoutOperation.Publish:
                    cmdPublish_Click(this, EventArgs.Empty);
                    break;
//                case LayoutOperation.UseArchiveChanged:
//                    cmdUseArchive_Changed(this, EventArgs.Empty);
//                    break;

                default:

                    layoutCommand.State = CommandState.Unprecessed;
                    break;
            }
            if (layoutCommand.State == CommandState.Pending)
            {
                layoutCommand.State = CommandState.Processed;
            }
        }

        public void ProcessReportViewCommand(ReportViewCommand viewCommand)
        {
            Trace.WriteLine(Trace.Kind.Undefine, "LayoutDetails.Process(): executing ReportViewCommand");
            viewCommand.State = CommandState.Pending;

            if (viewCommand.NewParent == null)
            {
                m_ReportView = false;
                pivotReportForm.Parent = grcReport;
                pivotReportForm.Dock = DockStyle.Fill;
            }
            else
            {
                m_ReportView = true;
                pivotReportForm.Parent = viewCommand.NewParent;
                pivotReportForm.Dock = DockStyle.None;
                pivotReportForm.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                pivotReportForm.Top = 0;
                pivotReportForm.Left = 0;
                pivotReportForm.Height = viewCommand.NewParent.Height - viewCommand.BottonAnchor;
                pivotReportForm.Width = viewCommand.NewParent.Width;
                pivotReportForm.BringToFront();
            }
            viewCommand.State = CommandState.Processed;
        }

        public void ProcessPrintCommand(PrintCommand printCommand)
        {
            if (printCommand.PrintType != PrintType.Context)
            {
                return;
            }

            Trace.WriteLine(Trace.Kind.Undefine, "LayoutDetails.Process(): executing PrintCommand");
            XtraTabPage currentPage = tabControl.SelectedTabPage;
            if ((currentPage == tabPageGrid) || (currentPage == tabPageReport))
            {
                RaiseSendCommand(new PrintCommand(this, PrintType.Grid));
            }
            else if (currentPage == tabPageMap)
            {
                ExportMapSettingsFromMapToLayout();
                RaiseSendCommand(new PrintCommand(this, PrintType.Map));
            }
            else if (currentPage == tabPageChart)
            {
                RaiseSendCommand(new PrintCommand(this, PrintType.Chart));
            }
        }

        public void ProcessRefreshCommand(RefreshCommand refreshCommand)
        {
            refreshCommand.State = CommandState.Pending;

            switch (refreshCommand.RefreshType)
            {
                case RefreshType.Map:
                    mapForm.RaiseInitAdmUnitComboBox();
                    mapForm.RaiseImportSettingsIntoMapAndRefreshMap();
                    refreshCommand.State = CommandState.Processed;
                    break;
                case RefreshType.Grid:
                    pivotForm.RaiseDataLoadedEvent();
                    refreshCommand.State = CommandState.Processed;
                    //tabControl_SelectedPageChanging(this, new TabPageChangingEventArgs(tabPageGrid, tabPageReport));
                    //tabControl.SelectedTabPage = tabPageReport;
                    break;
                case RefreshType.Chart:
                    Rectangle selection = pivotForm.PivotGrid.Cells.Selection;
                    if (selection.Width * selection.Height > RamPivotGrid.MaxChartItemCount)
                    {
                        string msg = EidssMessages.Get("msgTooBigSelection",
                                                       "Selection should contains at most {0} items to show on chart.");
                        MessageForm.Show(string.Format(msg, RamPivotGrid.MaxChartItemCount));
                    }
                    else
                    {
                        m_ChartDataSource = pivotForm.PivotGrid;
                        chartForm.DataSource = pivotForm.PivotGrid;
                        chartForm.SetChartTitles(pivotForm.PivotGrid.ChartTitle);
                    }
                    refreshCommand.State = CommandState.Processed;
                    break;
            }
        }

        #endregion

        #region TabControl Handlers

        private void LayoutDetail_LayoutTabChanged(object sender, TabSelectionEventArgs e)
        {
            cmdNew.Enabled = e.NewEnabled && RamPermissions.InsertPermission;
            cmdCopy.Enabled = e.CopyEnabled && RamPermissions.InsertPermission;
            cmdDelete.Enabled = e.LayoutDeleteEnabled && RamPermissions.DeletePermission;
            cmdSave.Enabled = e.SaveEnabled && RamPermissions.UpdatePermission;
            cmdCancelChanges.Enabled = e.CancelEnabled && RamPermissions.UpdatePermission;
        }

        private void pivotForm_CellSelectionChanged(object sender, PivotSelectionEventArgs e)
        {
            tabPageChart.PageEnabled = e.ChartEnabled;
            tabPageMap.PageEnabled = e.MapEnabled;

            if (m_ChartDataSource != null)
            {
                m_ChartDataSource = null;
                timerUpdateChart.Start();
            }
        }

        private void tabControl_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            try
            {
                if (IsDesignMode())
                {
                    return;
                }

                TabPageChanging(e);

                PrepareEventLayoutTabChange(e);
            }
            catch (Exception ex)
            {
                if (BaseSettings.ThrowExceptionOnError)
                {
                    throw;
                }
                ErrorForm.ShowError(ex);
            }
        }

        private void TabPageChanging(TabPageChangingEventArgs e)
        {
            if (IsDesignMode())
            {
                return;
            }
            if (e.PrevPage == tabPageMap)
            {
                #region Save changes in buffer zones if we are in edit mode

                e.Cancel = mapForm.CancelMapChanges();
                if (e.Cancel)
                {
                    return;
                }

                #endregion

                ExportMapSettingsFromMapToLayout();
            }

            if (e.Page == tabPageGrid)
            {
                pivotForm.Visible = (m_LayoutDetailPresenter.SharedPresenter.SharedModel.SelectedQueryId > 0);// && (m_LayoutDetailPresenter.SharedPresenter.SharedModel.SelectedLayoutId>0 || m_LayoutDetailPresenter.NewClicked));
                //pivotForm.PivotAccessible = (m_LayoutDetailPresenter.SharedPresenter.SharedModel.SelectedQueryId > 0 && (m_LayoutDetailPresenter.SharedPresenter.SharedModel.SelectedLayoutId > 0 || m_LayoutDetailPresenter.NewClicked));
                if (pivotForm.Visible)
                {
                    pivotForm.PivotGrid.Select();
                }
            }
            if (e.Page == tabPageMap)
            {
                mapForm.Visible = true;
                if (m_TabPageMapHistory.Contains(tabPageGrid))
                {
                    m_TabPageMapHistory.Clear();
                    mapForm.RaiseInitAdmUnitComboBox();
//                    if (m_NeedMapRefresh)
//                    {
//                        m_NeedMapRefresh = false;
//                        mapForm.ReInitMapIfExists();
//                    }
                    mapForm.RaiseImportSettingsIntoMapAndRefreshMap();
                }
            }
            if (e.Page == tabPageChart)
            {
                Rectangle selection = pivotForm.PivotGrid.Cells.Selection;

                if (selection.Width * selection.Height > RamPivotGrid.MaxChartItemCount)
                {
                    e.Cancel = true;
                    string msg = EidssMessages.Get("msgTooBigSelection",
                                                   "Selection should contains at most {0} items to show on chart.");
                    MessageForm.Show(string.Format(msg, RamPivotGrid.MaxChartItemCount));
                }
                else
                {
                    chartForm.Visible = true;
                    if (m_ChartDataSource == null)
                    {
                        m_ChartDataSource = pivotForm.PivotGrid;
                        timerUpdateChart.Start();
                    }
                    else
                    {
                        chartForm.SetChartTitles(pivotForm.PivotGrid.ChartTitle);
                    }
                }
            }
            if (e.Page == tabPageReport)
            {
                pivotReportForm.Visible = true;

                if (m_TabPageReportHistory.Contains(tabPageGrid))
                {
                    m_TabPageReportHistory.Clear();
                    pivotForm.RaiseDataLoadedEvent();
                }
            }
            m_TabPageReportHistory.Add(e.Page);
            m_TabPageMapHistory.Add(e.Page);
        }

        private void PrepareEventLayoutTabChange(TabPageChangingEventArgs e)
        {
            if (!e.Cancel)
            {
                TabSelectionEventArgs args = TabSelectionEventArgs.GridArgs;
                if ((e.Page == tabPageMap) || (e.Page == tabPageChart))
                {
                    args &= TabSelectionEventArgs.ChartMapArgs;
                }
                if (e.Page == tabPageReport)
                {
                    args &= TabSelectionEventArgs.ReportArgs;
                }

                if (m_LayoutDetailPresenter.StandardReports)
                {
                    args &= TabSelectionEventArgs.ReportArgs;
                }
                if (ReadOnly)
                {
                    args &= TabSelectionEventArgs.ReadOnlyGridArgs;
                }
                if (!m_LayoutDetailPresenter.LayoutAccessible)
                {
                    args &= TabSelectionEventArgs.EmptyGridArgs;
                }
                if (m_LayoutDetailPresenter.SharedPresenter.SharedModel.SelectedQueryId < 0)
                {
                    args &= TabSelectionEventArgs.EmptyQueryArgs;
                }

                LayoutTabChanged.SafeRaise(this, args);
            }
        }

        /// <summary>
        ///   Updates The Chart diagram once.
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"> </param>
        private void timerUpdateChart_Tick(object sender, EventArgs e)
        {
            timerUpdateChart.Stop();

            chartForm.DataSource = m_ChartDataSource;
            chartForm.SetChartTitles(pivotForm.PivotGrid.ChartTitle);
        }

        #endregion
    }
}