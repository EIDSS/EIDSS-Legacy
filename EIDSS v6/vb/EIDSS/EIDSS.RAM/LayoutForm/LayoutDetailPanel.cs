using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using bv.common;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Enums;
using bv.common.win;
using bv.winclient.Core;
using DevExpress.XtraTab;
using eidss.avr.BaseComponents;
using eidss.avr.BaseComponents.Views;
using eidss.avr.db.AvrEventArgs.AvrEventArgs;
using eidss.avr.db.Common;
using eidss.avr.db.DBService;
using eidss.avr.db.DBService.DataSource;
using eidss.avr.Handlers.AvrEventArgs;
using eidss.model.Avr.Commands;
using eidss.model.Avr.Commands.Layout;
using eidss.model.Avr.Commands.Refresh;
using eidss.model.AVR.Db;
using eidss.model.Avr.Tree;
using eidss.model.Core;
using eidss.model.Reports.OperationContext;
using eidss.model.Resources;
using LayoutEventArgs = eidss.avr.db.AvrEventArgs.AvrEventArgs.LayoutEventArgs;

namespace eidss.avr.LayoutForm
{
    public partial class LayoutDetailPanel : BaseAvrDetailPresenterPanel, ILayoutDetailView
    {
        private readonly List<XtraTabPage> m_TabPageViewHistory = new List<XtraTabPage>();
        private readonly List<XtraTabPage> m_TabPageMapHistory = new List<XtraTabPage>();
        private LayoutDetailPresenter m_LayoutDetailPresenter;

        public event EventHandler<TabSelectionEventArgs> LayoutTabChanged;

        public event EventHandler<CopyLayoutEventArgs> CopyLayoutCreating;
        public event EventHandler<PivotFieldPopupMenuEventArgs> PivotFieldMouseRightClick;

        public LayoutDetailPanel()
        {
            try
            {
                m_LayoutDetailPresenter = (LayoutDetailPresenter) BaseAvrPresenter;

                InitializeComponent();

                if (IsDesignMode() || bv.common.Configuration.BaseSettings.ScanFormsMode)
                {
                    return;
                }

                pivotForm.UseParentDataset = true;
                RegisterChildObject(pivotForm, RelatedPostOrder.SkipPost);
                pivotForm.PivotGrid.PivotFieldMouseRightClick += OnPivotGridOnPivotFieldMouseRightClick;

                viewForm.UseParentDataset = false;
                RegisterChildObject(viewForm, RelatedPostOrder.PostLast);

                pivotInfo.UseParentDataset = true;
                RegisterChildObject(pivotInfo, RelatedPostOrder.SkipPost);

                LayoutTabChanged += LayoutDetail_LayoutTabChanged;

                LookupTableNames = new[] {"Layout"};
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
        ///     Clean up any resources being used.
        /// </summary>
        /// <param name="disposing"> true if managed resources should be disposed; otherwise, false. </param>
        protected override void Dispose(bool disposing)
        {
            try
            {
                m_TabPageViewHistory.Clear();
                m_TabPageMapHistory.Clear();
                LayoutTabChanged -= LayoutDetail_LayoutTabChanged;

                if (pivotForm != null)
                {
                    if (pivotForm.PivotGrid != null)
                    {
                        pivotForm.PivotGrid.PivotFieldMouseRightClick -= OnPivotGridOnPivotFieldMouseRightClick;
                    }

                    UnRegisterChildObject(pivotForm);

                    pivotForm = null;
                }
                if (pivotInfo != null)
                {
                    UnRegisterChildObject(pivotInfo);
                    pivotInfo = null;
                }
                if (viewForm != null)
                {
                    UnRegisterChildObject(viewForm);
                    viewForm = null;
                }
                if (m_LayoutDetailPresenter != null)
                {
                    m_LayoutDetailPresenter.SharedPresenter.UnregisterView(this);
                    m_LayoutDetailPresenter.Dispose();
                    m_LayoutDetailPresenter = null;
                }

                if (disposing && (components != null))
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
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
                if (!IsViewPageSelected)
                {
                    var args = new TabPageChangingEventArgs(tabControl.SelectedTabPage, tabControl.SelectedTabPage);
                    tabControl_SelectedPageChanging(this, args);
                }

                cmdCancelChanges.Visible = GetButtonVisibility(DefaultButtonType.Save);
                cmdSave.Visible = GetButtonVisibility(DefaultButtonType.Save);

                cmdDelete.Visible = GetButtonVisibility("ShowDeleteButtonOnDetailForm", DefaultButtonType.Delete);
                cmdNew.Visible = GetButtonVisibility("ShowNewButtonOnDetailForm", DefaultButtonType.New);

                ArrangeButtons(cmdSave.Top, "BottomButtons", cmdSave.Height, Height - cmdSave.Height - 8);
            }
        }

        [Browsable(false)]
        public IPivotDetailView PivotDetailView
        {
            get { return pivotForm; }
        }

        [Browsable(false)]
        internal string SelectedTabPageName
        {
            get { return (tabControl.SelectedTabPage != null) ? tabControl.SelectedTabPage.Name : string.Empty; }
        }

        [Browsable(false)]
        private Layout_DB LayoutDbService
        {
            get { return m_LayoutDetailPresenter.LayoutDbService; }
        }

        [Browsable(false)]
        internal bool IsViewPageSelected
        {
            get { return tabControl.SelectedTabPage == tabPageView; }
        }

        #endregion

        #region Base Methods

        public override object GetKey(string tableName = null, string keyFieldName = null)
        {
            return pivotForm == null
                ? null
                : (object) pivotForm.LayoutId;
        }

        public bool LayoutPost(PostType postType = PostType.FinalPosting)
        {
            return m_LayoutDetailPresenter.SharedPresenter.SharedModel.ParentForm.Post(postType);
        }

        /// <summary>
        ///     Don't Call this method directly!!! It should be called when parent form performs post. Use LayoutPost() instead.
        /// </summary>
        /// <param name="postType"></param>
        /// <returns></returns>
        public override bool Post(PostType postType = PostType.FinalPosting)
        {
            m_LayoutDetailPresenter.PrepareDbService();
            m_LayoutDetailPresenter.PrepareLayoutSearchFieldsBeforePost(pivotForm.PivotGrid.AvrFields.ToList());
            return base.Post(postType);
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
                throw new AvrDbException(string.Format("dataset must be of type {0}", typeof (LayoutDetailDataSet)));
            }
            base.Merge(ds);
        }

        protected override void DefineBinding()
        {
            if (!SharedPresenter.ContextKeeper.ContainsContext(ContextValue.NewLayoutClicking))
            {
                m_LayoutDetailPresenter.NewClicked = false;
            }

            m_TabPageViewHistory.Add(tabPagePivotGrid);
            m_TabPageMapHistory.Add(tabPagePivotGrid);
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

        private void OnPivotGridOnPivotFieldMouseRightClick(object sender, PivotFieldPopupMenuEventArgs args)
        {
            PivotFieldMouseRightClick.SafeRaise(sender, args);
        }

        public void OnLayoutSelected(LayoutEventArgs e)
        {
            try
            {
                object id = e.LayoutId;
                LoadData(ref id);

                pivotForm.UpdateCustomizationFormEnabling();

                pivotForm.CustomizationFormEnabled &= ((e.LayoutId > 0) || (m_LayoutDetailPresenter.NewClicked));

                if ((e.LayoutId > 0 && m_LayoutDetailPresenter.SharedPresenter.SharedModel.StandardReports) ||
                    tabControl.SelectedTabPage == tabPageView)
                {
                    pivotForm.RaisePivotGridDataLoadedCommand();
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

//        public void ProcessAfterPost(object sender, PostHandler handler)
//        {
//            try
//            {
//                if (m_LayoutDetailPresenter.IsNewObject)
//                {
//                    pivotForm.SetChanged(true);
//                }
//                if (m_LayoutDetailPresenter.ParentHasChanges())
//                {
//                    m_LayoutDetailPresenter.LayoutDbService.OnAfterPost += handler;
//                    cmdSave_Click(sender, EventArgs.Empty);
//                }
//                else
//                {
//                    handler(sender, new PostEventArgs((int) PostType.FinalPosting, false));
//                }
//            }
//            finally
//            {
//                m_LayoutDetailPresenter.LayoutDbService.OnAfterPost -= handler;
//            }
//        }

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

        private void cmdSave_Click(object sender, EventArgs e)
        {
            ProcessAfterPost(null);
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            if (LockHandler())
            {
                try
                {
                    using (SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.NewLayoutClicking))
                    {
                        bool isPost = e is AvrPostNeededEventArgs && !((AvrPostNeededEventArgs) e).PostNeeded
                            ? Permissions.CanInsert
                            : Permissions.CanInsert && LayoutPost();

                        if (isPost)
                        {
                            m_LayoutDetailPresenter.NewClicked = true;

                            State = BusinessObjectState.NewObject | BusinessObjectState.IntermediateObject;
                            tabControl.SelectedTabPage = tabPagePivotInfo;

                            m_LayoutDetailPresenter.SharedPresenter.SharedModel.SelectedLayoutId = -1;
                            object id = null;
                            LoadData(ref id);

                            DefineBinding();
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
            object key = GetKey("Layout", "idflLayout");
            if (!(key is long))
            {
                throw new AvrException(string.Format("LayoutDetail key {0} is not long", key));
            }

            RaiseSendCommand(new QueryLayoutDeleteCommand(sender, (long) key, AvrTreeElementType.Layout));
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
                    if (tabControl.SelectedTabPage == tabPageView)
                    {
                        pivotForm.RaisePivotGridDataLoadedCommand();
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
                    if (LayoutPost() && Permissions.CanInsert)
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

                            pivotForm.ClearCacheDataRowColumnAreaFields();

                            pivotForm.SetInnerFilterCriteria();
                            pivotForm.InitFilterControl(pivotForm.FilterCriteria);

                            if (!pivotForm.ApplyFilter)
                            {
                                pivotForm.PivotGrid.Criteria = null;
                            }
                        }
                        pivotForm.RefreshPivotData();

                        RaiseSendCommand(new QueryLayoutCommand(this, QueryLayoutOperation.AddCopyPrefixForLayoutNames));
                    }
                }
                finally
                {
                    UnlockHandler();
                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            ProcessAfterPost(() =>
            {
                Hide();
                RaiseSendCommand(new QueryLayoutCloseCommand(sender));
            });
        }

        private void RefreshQueryAfterPost()
        {
            // before refreshing query dispose old pivot datasource 
            AvrPivotGridData oldDataSource = pivotForm.DataSource;
            if (oldDataSource != null)
            {
                pivotForm.DataSource = new AvrPivotGridData(oldDataSource.ClonedPivotData);
                oldDataSource.Dispose();
            }
            RaiseSendCommand(new ExecQueryCommand(this));

            object id = m_LayoutDetailPresenter.LayoutDbService.ID;
            LoadData(ref id);
            if (IsViewPageSelected)
            {
                pivotForm.RaisePivotGridDataLoadedCommand();
            }
        }

        private void PublishUnpublishAfterPost(bool isPublish)
        {
            if (UserConfirmPublishUnpublish(AvrTreeElementType.Layout, isPublish))
            {
                object id = m_LayoutDetailPresenter.LayoutDbService.ID;

                m_LayoutDetailPresenter.LayoutDbService.PublishUnpublish((long) id, AvrTreeElementType.Layout, isPublish);
                LoadData(ref id);
            }
        }

        private void ProcessAfterPost(Action handler)
        {
            if (LockHandler())
            {
                try
                {
                    bool isNewObject = m_LayoutDetailPresenter.IsNewObject;
                    if (isNewObject)
                    {
                        pivotForm.SetChanged();
                    }
                    if (LayoutPost())
                    {
                        if (handler != null)
                        {
                            handler();
                        }
                    }
                    else
                    {
                        SelectLastFocusedControl();
                    }
                }
                finally
                {
                    UnlockHandler();
                }
            }
        }

        #endregion

        #region  Command handlers

        public void ProcessQueryLayoutCommand(QueryLayoutCommand queryLayoutCommand)
        {
            queryLayoutCommand.State = CommandState.Pending;
            switch (queryLayoutCommand.Operation)
            {
                case QueryLayoutOperation.CopyQueryLayout:
                    cmdCopy_Click(this, EventArgs.Empty);
                    break;
                case QueryLayoutOperation.NewLayout:
                    cmdNew_Click(this, new AvrPostNeededEventArgs(false));
                    break;
                case QueryLayoutOperation.Publish:
                    ProcessAfterPost(() => PublishUnpublishAfterPost(true));
                    break;
                case QueryLayoutOperation.Unpublish:
                    ProcessAfterPost(() => PublishUnpublishAfterPost(false));
                    break;
                case QueryLayoutOperation.RefreshQuery:
                    ProcessAfterPost(RefreshQueryAfterPost);
                    break;

//                case LayoutOperation.UseArchiveChanged:
//                    cmdUseArchive_Changed(this, EventArgs.Empty);
//                    break;

                default:

                    queryLayoutCommand.State = CommandState.Unprocessed;
                    break;
            }
            if (queryLayoutCommand.State == CommandState.Pending)
            {
                queryLayoutCommand.State = CommandState.Processed;
            }
        }

        #endregion

        #region TabControl Handlers

        public void SelectInfoTabWithoutRefresh()
        {
            m_TabPageViewHistory.Clear();
            tabControl.SelectedTabPage = tabPagePivotInfo;
        }

        public void SelectViewTabWithoutRefresh()
        {
            m_TabPageViewHistory.Clear();
            tabControl.SelectedTabPage = tabPageView;
        }

        private void LayoutDetail_LayoutTabChanged(object sender, TabSelectionEventArgs e)
        {
            cmdNew.Enabled = e.NewEnabled && AvrPermissions.InsertPermission;
            cmdCopy.Enabled = e.CopyEnabled && AvrPermissions.InsertPermission;
            cmdDelete.Enabled = e.LayoutDeleteEnabled && AvrPermissions.DeletePermission;
            cmdSave.Enabled = e.SaveEnabled && AvrPermissions.UpdatePermission;
            cmdCancelChanges.Enabled = e.CancelEnabled && AvrPermissions.UpdatePermission;
            cmdClose.Enabled = true;
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

            if (e.Page == tabPagePivotGrid)
            {
                pivotForm.Visible = (m_LayoutDetailPresenter.SharedPresenter.SharedModel.SelectedQueryId > 0);
                if (pivotForm.Visible)
                {
                    pivotForm.PivotGrid.Select();
                }
            }
            if (e.Page == tabPagePivotInfo)
            {
                pivotInfo.Visible = true;
            }
            if (e.Page == tabPageView)
            {
                viewForm.Visible = true;

                if (m_TabPageViewHistory.Contains(tabPagePivotGrid))
                {
                    m_TabPageViewHistory.Clear();
                    pivotForm.RaisePivotGridDataLoadedCommand();
                }
            }
            m_TabPageViewHistory.Add(e.Page);
            m_TabPageMapHistory.Add(e.Page);
        }

        private void PrepareEventLayoutTabChange(TabPageChangingEventArgs e)
        {
            if (!e.Cancel)
            {
                TabSelectionEventArgs args = TabSelectionEventArgs.GridArgs;
                if (e.Page == tabPageView)
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

                if (m_LayoutDetailPresenter.SharedPresenter.SharedModel.SelectedQueryId < 0)
                {
                    args &= TabSelectionEventArgs.EmptyQueryArgs;
                }

                LayoutTabChanged.SafeRaise(this, args);
            }
        }

        #endregion
    }
}