using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using bv.common;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.db;
using bv.common.db.Core;
using bv.common.Diagnostics;
using bv.common.Enums;
using bv.common.win;
using bv.common.win.BaseForms;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.winclient.Core.TranslationTool;
using bv.winclient.Layout;
using DevExpress.XtraBars;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Localization;
using DevExpress.XtraTab;
using eidss.avr.BaseComponents;
using eidss.avr.db.AvrEventArgs.AvrEventArgs;
using eidss.avr.db.Common;
using eidss.avr.db.Common.CommandProcessing.Commands.Export;
using eidss.avr.db.DBService;
using eidss.avr.db.Interfaces;
using eidss.avr.Handlers.AvrEventArgs;
using eidss.avr.LayoutForm;
using eidss.avr.PivotComponents;
using eidss.avr.QueryBuilder;
using eidss.model.Avr.Commands;
using eidss.model.Avr.Commands.Export;
using eidss.model.Avr.Commands.Layout;
using eidss.model.Avr.Commands.Models;
using eidss.model.Avr.Commands.Print;
using eidss.model.Avr.Commands.Refresh;
using eidss.model.AVR.Db;
using eidss.model.Avr.Tree;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Reports.OperationContext;
using eidss.model.Resources;
using eidss.model.Schema;
using eidss.winclient;

namespace eidss.avr.MainForm
{
    public partial class AvrMainForm : BaseAvrForm, IAvrMainFormView
    {
        private const int PublishQueryIndex = 74;
        private const int PublishLayoutIndex = 73;
        private const int PublishFolderIndex = 72;

        private const int UnpublishQueryIndex = 78;
        private const int UnpublishLayoutIndex = 77;
        private const int UnpublishFolderIndex = 76;

        private static readonly object m_SyncRoot = new object();
        private bool m_QueryWasUpdated;

        private readonly BaseAvrDbService m_AvrDbService;
        public event EventHandler<CommandEventArgs> SendCommand;

        private AvrMainFormPresenter m_AvrMainFormPresenter;
        private SharedPresenter m_SharedPresenter;

        private readonly Dictionary<BarCheckItem, PivotGroupInterval> m_MenuGroupIntervals =
            new Dictionary<BarCheckItem, PivotGroupInterval>();

        private TranslationButton m_TranslationButton;

        #region Construction & Dispose

        public AvrMainForm()
        {
            try
            {
                Trace.WriteLine(Trace.Kind.Info, "AvrMainForm(): AvrMainForm creating...");

                // Note: [Ivan] init model factory for each copy of AvrMainForm.
                // when next copy of AvrMainForm created, 
                //previous copy already inited so they does not need ModelFactory
                lock (m_SyncRoot)
                {
                    PresenterFactory.Init(this);
                    m_SharedPresenter = PresenterFactory.SharedPresenter;
                }
                m_AvrMainFormPresenter = (AvrMainFormPresenter) m_SharedPresenter[this];

                InitializeComponent();
                if (IsDesignMode())
                {
                    return;
                }
                if (BaseSettings.TranslationMode)
                {
                    m_TranslationButton = new TranslationButton();
                    m_TranslationButton.Top = Height - m_TranslationButton.Height;
                    m_TranslationButton.Left = Width - m_TranslationButton.Width - 4;
                    m_TranslationButton.Parent = this;
                    m_TranslationButton.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
                    m_TranslationButton.BringToFront();
                }

                m_AvrDbService = new BaseAvrDbService();
                DbService = m_AvrDbService;

                RegisterChildObject(QueryLayoutTree, RelatedPostOrder.PostLast);

                QueryLayoutTree.OnElementSelect += QueryLayoutTree_OnElementSelect;
                QueryLayoutTree.OnElementEdit += QueryLayoutTree_OnElementEdit;
                QueryLayoutTree.OnElementPopup += QueryLayoutTree_OnElementPopup;

                biSettings.Visibility = AvrPermissions.AccessToAVRAdministrationPermission
                    ? BarItemVisibility.Always
                    : BarItemVisibility.Never;
                PivotGridFieldBase.DefaultTotalFormat.FormatString = PivotGridLocalizer.GetString(PivotGridStringId.TotalFormat);
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
                LayoutCorrector.Reset();

                DisposeLayoutDetails();
                DisposeQueryDetails();

                eventManager.ClearAllReferences();

                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                if (m_AvrMainFormPresenter != null)
                {
                    m_AvrMainFormPresenter.Dispose();
                    m_AvrMainFormPresenter = null;
                }

                if (m_SharedPresenter != null)
                {
                    lock (m_SyncRoot)
                    {
                        PresenterFactory.RemovePresenterLink(m_SharedPresenter);
                    }
                    m_SharedPresenter.UnregisterView(this);
                    m_SharedPresenter.Dispose();
                    m_SharedPresenter = null;
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        #endregion

        #region Properties

        [Browsable(false)]
        public DataSet BaseDataSet
        {
            get { return baseDataSet; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private bool TreeOpened
        {
            get { return TabControl.SelectedTabPage == TabPageTree; }
            set
            {
                TabControl.SelectedTabPage = value
                    ? TabPageTree
                    : TabPageEditor;
            }
        }

        [Browsable(false)]
        private bool IsQueryOpened
        {
            get { return queryDetail != null; }
        }

        [Browsable(false)]
        private bool IsLayoutOpened
        {
            get { return layoutDetail != null; }
        }

        [Browsable(false)]
        private bool IsViewPageSelected
        {
            get { return (IsLayoutOpened && layoutDetail.IsViewPageSelected); }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Dictionary<string, object> StartUpParameters
        {
            get { return base.StartUpParameters; }
            set
            {
                base.StartUpParameters = value;
                m_SharedPresenter.SharedModel.StartUpParameters = value;
            }
        }

        #endregion

        #region Init

        internal void InitLayoutDetail(bool isNewObject)
        {
            TabPageEditor.Text = EidssMessages.Get("msgPivotAndView", "Pivot and View");

            if (layoutDetail != null)
            {
                return;
            }

            layoutDetail = new LayoutDetailPanel
            {
                Location = new Point(0, 0),
                Size = new Size(EditorPanel.Width, EditorPanel.Height),
                Dock = DockStyle.Fill,
                IgnoreAudit = true
            };

            if (isNewObject)
            {
                layoutDetail.SelectInfoTabWithoutRefresh();
            }

            layoutDetail.Appearance.Options.UseFont = true;

            EditorPanel.Controls.Add(layoutDetail);

            RegisterChildObject(layoutDetail, RelatedPostOrder.PostLast);

            layoutDetail.LayoutTabChanged += LayoutDetailLayoutTabChanged;
            layoutDetail.PivotFieldMouseRightClick += layoutDetail_PivotFieldMouseRightClick;
        }

        private void InitQueryDetail()
        {
            TabPageEditor.Text = EidssMessages.Get("msgQuery", "Query");
            if (queryDetail != null)
            {
                return;
            }
            queryDetail = new QueryDetailPanel
            {
                Location = new Point(0, 0),
                Size = new Size(EditorPanel.Width, EditorPanel.Height),
                Dock = DockStyle.Fill,
                Visible = true,
            };

            EditorPanel.Controls.Add(queryDetail);

            RegisterChildObject(queryDetail, RelatedPostOrder.PostLast);
        }

        private void DisposeLayoutDetails()
        {
            if (layoutDetail != null)
            {
                layoutDetail.Hide();
                UnRegisterChildObject(layoutDetail);
                m_SharedPresenter.UnregisterView(layoutDetail);
                AvrPivotGridData oldDataSource = layoutDetail.PivotDetailView.DataSource;
                if (oldDataSource != null)
                {
                    oldDataSource.Dispose();
                }

                layoutDetail.Dispose();
                layoutDetail = null;

                m_SharedPresenter.SharedModel.SelectedLayoutId = -1;

                ChangeFormCaption(new AvrTreeSelectedElementEventArgs());
            }
        }

        private void DisposeQueryDetails()
        {
            if (queryDetail != null)
            {
                queryDetail.Hide();
                UnRegisterChildObject(queryDetail);
                m_SharedPresenter.UnregisterView(queryDetail);
                queryDetail.Dispose();
                queryDetail = null;
                m_SharedPresenter.SharedModel.SelectedQueryId = -1;

                ChangeFormCaption(new AvrTreeSelectedElementEventArgs());
            }
        }

        protected override void AfterLoad()
        {
            try
            {
                if (BaseAvrPresenter.WinCheckAvrServiceAccessability())
                {
                    using (m_SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.AfterLoad))
                    {
                        biExport.Enabled =
                            EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.CanImportExportData));
                        InitPopupMenu();
                        OpenStandardreportIfNeeded();
                    }
                }
                else
                {
                    CloseTimer.Start();
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

        private void CloseTimer_Tick(object sender, EventArgs e)
        {
            CloseTimer.Stop();
            DoClose();
        }

        private void InitPopupMenu()
        {
            int i = 1;
            foreach (KeyValuePair<long, string> pair in GroupIntervalHelper.GetGroupIntervalLookup())
            {
                var groupDate = new BarCheckItem();

                barManager.Items.Add(groupDate);
                bsGroupDate.LinksPersistInfo.Add(new LinkPersistInfo(groupDate));
                groupDate.Caption = pair.Value;
                groupDate.Visibility = BarItemVisibility.Always;
                groupDate.Name = "bcGroupDate_" + i;
                i++;

                groupDate.CheckedChanged += bcGroupDate_CheckedChanged;

                PivotGroupInterval interval = GroupIntervalHelper.GetGroupInterval(pair.Key);

                m_MenuGroupIntervals.Add(groupDate, interval);
            }
        }

        private void OpenStandardreportIfNeeded()
        {
            if (StartUpParameters != null && StartUpParameters.ContainsKey(SharedProperty.StandardReports.ToString()))
            {
                m_SharedPresenter.SharedModel.StandardReports = true;
                TreeOpened = false;

                object layoutObjId;
                long layoutId;
                if (m_SharedPresenter.TryGetStartUpParameter("LayoutId", out layoutObjId) &&
                    long.TryParse(Utils.Str(layoutObjId), out layoutId))
                {
                    AvrLayoutLookup foundLayout = AvrLayoutLookup.GetAvrLayoutLookupById(layoutId);
                    if (foundLayout != null)
                    {
                        var args = new AvrTreeSelectedElementEventArgs(foundLayout.idflQuery,
                            foundLayout.idflLayout,
                            foundLayout.idflFolder ?? foundLayout.idflQuery,
                            foundLayout.idflFolder ?? -1,
                            AvrTreeElementType.Layout,
                            string.Empty);
                        OpenLayoutEditor(args);

                        //   layoutDetail.SelectViewTabWithoutRefresh();
                    }
                }
            }
        }

        private void AVRReportControl_Load(object sender, EventArgs e)
        {
            UpdateFont(barMenu.LinksPersistInfo, WinClientContext.CurrentFont);

            if (Parent != null)
            {
                Parent.MinimumSize = new Size(600, 600);
            }
        }

        private static void UpdateFont(LinksInfo linksInfo, Font font)
        {
            foreach (LinkPersistInfo link in linksInfo)
            {
                link.Item.Appearance.Font = font;
                var container = link.Item as BarLinkContainerItem;
                if (container != null)
                {
                    UpdateFont(container.LinksPersistInfo, font);
                }
            }
        }

        public override object GetChildKey(IRelatedObject child)
        {
            if (child is LayoutDetailPanel)
            {
                return ((LayoutDetailPanel) child).GetKey();
            }

            if (child is QueryDetailPanel)
            {
                return ((QueryDetailPanel) child).GetKey();
            }

            return null;
        }

        public override object GetKey(string tableName = null, string keyFieldName = null)
        {
            if (IsLayoutOpened)
            {
                return layoutDetail.GetKey(tableName, keyFieldName);
            }
            if (IsQueryOpened)
            {
                return queryDetail.GetKey(tableName, keyFieldName);
            }
            return null;
        }

        public static void Register(Control parentControl)
        {
            Utils.CheckNotNull(parentControl, "parentControl");

            try
            {
                if (!BaseFormManager.ArchiveMode)
                {
                    new MenuAction(ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.AVR,
                        "MenuLaunchRAM", 1000, false, (int) MenuIconsSmall.LaunchAVR)
                    {
                        Name = "btnRAM",
                        SelectPermission = PermissionHelper.SelectPermission(EIDSSPermissionObject.AVRReport)
                    };

                    WinMenuReportRegistrator.RegisterAllAvrReports(MenuActionManager.Instance, ShowStandardReport);
                }
            }
            catch (Exception ex)
            {
                Dbg.Debug("error during loading registering RAM menu, {0}", ex);
                if (BaseSettings.ThrowExceptionOnError)
                {
                    throw;
                }
                ErrorForm.ShowError(ex);
            }
        }

        private static void ShowStandardReport(IMenuAction action)
        {
            try
            {
                using (CreateWaitDialog())
                {
                    var startupParams = new Dictionary<string, object>
                    {
                        {"StandardReports", true}
                    };
                    //startupParams.Add("ShowAll", false);

                    Match match = Regex.Match(action.Name, @"btnStandardReport_(?<QueryId>\d+)_(?<LayoutId>\d+)_");

                    Group queryGroup = match.Groups["QueryId"];
                    long queryId;
                    if (queryGroup.Success && queryGroup.Captures.Count == 1 &&
                        Int64.TryParse(queryGroup.Captures[0].Value, out queryId))
                    {
                        startupParams.Add("QueryId", queryId);
                    }

                    Group layoutGroup = match.Groups["LayoutId"];
                    long layoutId;
                    object id = null;
                    if (layoutGroup.Success && layoutGroup.Captures.Count == 1 &&
                        Int64.TryParse(layoutGroup.Captures[0].Value, out layoutId))
                    {
                        startupParams.Add("LayoutId", layoutId);
                        id = layoutId;
                    }

                    var avrForm = new AvrMainForm();
                    BaseFormManager.ShowNormal(avrForm, ref id, startupParams);
                    if (avrForm.ParentForm != null)
                    {
                        avrForm.ParentForm.MinimumSize = avrForm.MinimumSize;
                    }
                }
            }
            catch (Exception ex)
            {
                Dbg.Debug("error during showing RAM control for layout {0}: {1}", action.Caption, ex);
                if (BaseSettings.ThrowExceptionOnError)
                {
                    throw;
                }
                ErrorForm.ShowError(ex);
            }
        }

        private static int CompareForm(IApplicationForm form, object x)
        {
            if (form.StartUpParameters == null || !form.StartUpParameters.ContainsKey(SharedProperty.StandardReports.ToString()))
            {
                return 0;
            }
            return -1;
        }

        private static void ShowMe()
        {
            try
            {
                using (CreateWaitDialog())
                {
                    var found = BaseFormManager.FindForm(typeof (AvrMainForm), null, CompareForm) as AvrMainForm;
                    if (found == null)
                    {
                        object key = -1;
                        var avrForm = new AvrMainForm();
                        BaseFormManager.ShowNormal(avrForm, ref key);
                        if (avrForm.ParentForm != null)
                        {
                            avrForm.ParentForm.MinimumSize = avrForm.MinimumSize;
                        }
                    }
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

        private static WaitDialog CreateWaitDialog()
        {
            string title = EidssMessages.Get("msgPleaseWait");
            string caption = EidssMessages.Get("msgAvrInitializing");
            return new WaitDialog(caption, title);
        }

        #endregion

        #region Post

        protected override BaseAvrDetailPanel GetChildForPost()
        {
            if (IsLayoutOpened)
            {
                return layoutDetail;
            }
            if (IsQueryOpened)
            {
                return queryDetail;
            }

            return null;
        }

        public override bool Post(PostType postType = PostType.FinalPosting)
        {
            // if user hasn't update permission -  no need to save
            if (!AvrPermissions.UpdatePermission)
            {
                return true;
            }
            try
            {
                bool isPost;
                using (m_SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.Post))
                {
                    if (Utils.IsCalledFromUnitTest())
                    {
                        m_ClosingMode = BaseDetailForm.ClosingMode.Ok;
                    }
                    // No need to Post if call this code from unit-tests
                    isPost = Utils.IsCalledFromUnitTest() || base.Post(postType);

                    object key = GetKey();
                    if (isPost && key is long)
                    {
                        AvrTreeElementType type = IsLayoutOpened
                            ? AvrTreeElementType.Layout
                            : AvrTreeElementType.Query;

                        QueryLayoutTree.ReloadQueryLayoutFolder((long) key, type);
                    }
                }
                return isPost;
            }
            catch (Exception ex)
            {
                if (BaseSettings.ThrowExceptionOnError)
                {
                    throw;
                }
                ErrorForm.ShowError(ex);
                Trace.WriteLine(ex);
                return false;
            }
        }

        /// <summary>
        ///     Call base post without any check. this method should be uses for debug purposes only
        /// </summary>
        /// <returns> </returns>
        internal bool ForcePost()
        {
            return base.Post();
        }

        #endregion

        #region Delete query layout folder

        private void DeleteQueryLayoutFolder()
        {
            AvrTreeSelectedElementEventArgs args = QueryLayoutTree.GetTreeSelectedElementEventArgs();
            switch (args.Type)
            {
                case AvrTreeElementType.Query:
                    if (args.QueryId < 0)
                    {
                        throw new AvrException("Couldn't delete query because it's not selected");
                    }
                    DeleteQueryLayout(args.QueryId, AvrTreeElementType.Query, true);
                    break;
                case AvrTreeElementType.Layout:
                    if (!args.ElementId.HasValue)
                    {
                        throw new AvrException("Couldn't delete layout because it's not selected");
                    }
                    DeleteQueryLayout(args.ElementId.Value, AvrTreeElementType.Layout, true);
                    //RaiseSendCommand(new LayoutCommand(this, LayoutOperation.Delete));
                    break;
                case AvrTreeElementType.Folder:

                    QueryLayoutTree.DeleteFolder();
                    break;
            }
        }

        public void CloseQueryLayoutStart()
        {
            CloseQueryLayoutTimer.Start();
        }

        private void CloseQueryLayoutTimer_Tick(object sender, EventArgs e)
        {
            CloseQueryLayoutTimer.Stop();

            TreeOpened = true;
            DisposeLayoutDetails();
            DisposeQueryDetails();
        }

        public void DeleteQueryLayoutStart(QueryLayoutDeleteCommand deleteCommand)
        {
            DeleteQueryLayoutTimer.Tag = new QueryLayoutDeleteCommand(this, deleteCommand.ObjectId, deleteCommand.ObjectType);
            DeleteQueryLayoutTimer.Start();
        }

        private void DeleteQueryLayoutTimer_Tick(object sender, EventArgs e)
        {
            DeleteQueryLayoutTimer.Stop();
            var deleteCommand = DeleteQueryLayoutTimer.Tag as QueryLayoutDeleteCommand;
            if (deleteCommand != null && DeletePromptDialog() == DialogResult.Yes)
            {
                TreeOpened = true;
                DeleteQueryLayout(deleteCommand.ObjectId, deleteCommand.ObjectType);
            }
        }

        private void DeleteQueryLayout(long id, AvrTreeElementType objectType, bool needConfirmation = false)
        {
            try
            {
                if (needConfirmation && DeletePromptDialog() != DialogResult.Yes)
                {
                    return;
                }

                string objectName = objectType == AvrTreeElementType.Query
                    ? "Query"
                    : "AsLayout";

                if (m_AvrDbService.CanDelete(id, objectName))
                {
                    DisposeLayoutDetails();
                    DisposeQueryDetails();

                    if (!m_AvrDbService.Delete(id, objectName))
                    {
                        ErrorMessage err = m_AvrDbService.LastError;
                        throw new AvrException(err.Text + err.Exception);
                    }

                    if (objectType == AvrTreeElementType.Query)
                    {
                        LookupCache.NotifyDelete("Query", null, id);
                        LookupCache.NotifyChange("Layout");
                    }
                    else
                    {
                        LookupCache.NotifyDelete("Layout", null, id);
                    }
                    LookupCache.NotifyChange("LayoutFolder");

                    QueryLayoutTree.DeleteNodeWithId(id);
                }
                else
                {
                    ErrorMessage err = m_AvrDbService.LastError;
                    if (err != null)
                    {
                        throw new AvrException(err.Text + err.Exception);
                    }
                    ErrorForm.ShowMessage("msgCantDeleteRecord", "The record can't be deleted");
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

        #endregion

        #region Tree Handlers

        private void TabControl_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            QueryLayoutTree_OnElementSelect(sender, QueryLayoutTree.GetTreeSelectedElementEventArgs());
        }

        private void QueryLayoutTree_OnElementSelect(object sender, AvrTreeSelectedElementEventArgs e)
        {
            try
            {
                bool insertPermission = AvrPermissions.InsertPermission;

                biNewQuery.Enabled = bbNewQuery.Enabled = bbPopupNewQuery.Enabled = insertPermission;
                biNewLayout.Enabled = bbNewLayout.Enabled = bbPopupNewLayout.Enabled = insertPermission && (TreeOpened || IsLayoutOpened);
                biNewFolder.Enabled = bbNewFolder.Enabled = bbPopupNewFolder.Enabled = insertPermission && TreeOpened;
                biCopyQueryLayout.Enabled = bbCopyQueryLayout.Enabled = bbPopupCopyQueryLayout.Enabled =
                    insertPermission && (e.Type != AvrTreeElementType.Folder);

                biExportQuery.Enabled = true;

                biExportReport.Enabled = IsLayoutOpened;
                biPrintReport.Enabled = IsLayoutOpened;

                biEditQueryLayout.Enabled = bbEditQueryLayoutFolder.Enabled = bbPopupEditQueryLayoutFolder.Enabled =
                    AvrPermissions.UpdatePermission && TreeOpened && !QueryLayoutTree.IsFocusedNodeReadOnly;

                biDeleteQueryLayoutFolder.Enabled = bbDeleteQueryLayoutFolder.Enabled = bbPopupDeleteQueryLayoutFolder.Enabled =
                    AvrPermissions.DeletePermission && !QueryLayoutTree.IsFocusedNodeReadOnly;

                biPublishQueryLayoutFolder.Enabled = AvrPermissions.AccessToAVRAdministrationPermission &&
                                                     !QueryLayoutTree.IsFocusedNodeReadOnly;

                biUnpublishQueryLayoutFolder.Enabled = AvrPermissions.AccessToAVRAdministrationPermission &&
                                                       QueryLayoutTree.IsFocusedNodeReadOnly;

                switch (e.Type)
                {
                    case AvrTreeElementType.Query:
                        biPublishQueryLayoutFolder.ImageIndex = PublishQueryIndex;
                        biUnpublishQueryLayoutFolder.ImageIndex = UnpublishQueryIndex;
                        break;
                    case AvrTreeElementType.Folder:
                        biPublishQueryLayoutFolder.ImageIndex = PublishFolderIndex;
                        biUnpublishQueryLayoutFolder.ImageIndex = UnpublishFolderIndex;
                        break;
                    case AvrTreeElementType.Layout:
                        biPublishQueryLayoutFolder.ImageIndex = PublishLayoutIndex;
                        biUnpublishQueryLayoutFolder.ImageIndex = UnpublishLayoutIndex;
                        break;
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

        private void QueryLayoutTree_OnElementPopup(object sender, AvrTreeSelectedElementEventArgs e)
        {
            TreePopupMenu.ShowPopup(MousePosition);
        }

        private void QueryLayoutTree_OnElementEdit(object sender, AvrTreeSelectedElementEventArgs e)
        {
            OpenEditor(e);
        }

        internal void OpenEditor(AvrTreeSelectedElementEventArgs e, bool isNewObject = false)
        {
            try
            {
                if (!Loading && Post())
                {
                    using (m_SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.OpenEditor))
                    {
                        m_AvrMainFormPresenter.SharedPresenter.SharedModel.SelectedFolderId = e.FolderId;

                        if (e.Type == AvrTreeElementType.Folder)
                        {
                            QueryLayoutTree.EditFolder(e, isNewObject);
                        }
                        else
                        {
                            using (BaseAvrPresenter.CreateLoadingDialog())
                            {
                                TreeOpened = false;
                                if (e.Type == AvrTreeElementType.Query)
                                {
                                    OpenQueryEditor(e, isNewObject);
                                }
                                else if (e.Type == AvrTreeElementType.Layout)
                                {
                                    OpenLayoutEditor(e, isNewObject);
                                }
                            }
                        }

                        ChangeFormCaption(e);
                    }
                    if (BaseSettings.TranslationMode)
                    {
                        DesignControlManager.Create(this);
                    }
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

        private void ChangeFormCaption(AvrTreeSelectedElementEventArgs e)
        {
            Form parentForm = FindForm();
            if (parentForm != null)
            {
                var resources = new ComponentResourceManager(typeof (AvrMainForm));
                string baseCaption = resources.GetString("$this.Caption");
                parentForm.Text = string.IsNullOrEmpty(e.TreeElementPath)
                    ? baseCaption
                    : string.Format("{0} - {1}", baseCaption, e.TreeElementPath);
            }
        }

        private void OpenQueryEditor(AvrTreeSelectedElementEventArgs e, bool isNewObject = false)
        {
            DisposeQueryDetails();
            InitQueryDetail();

            queryDetail.OnAfterPost += queryDetail_OnAfterPost;
            object id = isNewObject ? null : (object) e.QueryId;
            queryDetail.LoadData(ref id);

            DisposeLayoutDetails();
            m_SharedPresenter.SharedModel.SelectedLayoutId = -1;
        }

        private void queryDetail_OnAfterPost(object sender, EventArgs e)
        {
            queryDetail.OnAfterPost -= queryDetail_OnAfterPost;
            if (queryDetail.DbService != null && queryDetail.DbService.ID is long)
            {
                AvrMainFormPresenter.InvalidateQuery((long) queryDetail.DbService.ID);
            }
            m_QueryWasUpdated = true;
        }

        private void OpenLayoutEditor(AvrTreeSelectedElementEventArgs e, bool isNewObject = false)
        {
            bool newUseArchive = GetUseArchiveForOpeningLayout(e.ElementId, isNewObject);
            bool queryWasChanged = m_SharedPresenter.SharedModel.SelectedQueryId != e.QueryId;
            bool useArchiveChanged = newUseArchive != m_SharedPresenter.SharedModel.UseArchiveData;
            m_SharedPresenter.SharedModel.UseArchiveData = newUseArchive;

            DisposeLayoutDetails();
            InitLayoutDetail(isNewObject);
            DisposeQueryDetails();
            if ((m_QueryWasUpdated || queryWasChanged || useArchiveChanged) && e.QueryId > 0)
            {
                CheckAndTraceQuery(e);
                m_AvrMainFormPresenter.ExecQuery(e.QueryId);
            }
            m_QueryWasUpdated = false;
            m_SharedPresenter.SharedModel.SelectedQueryId = e.QueryId;

            if (isNewObject)
            {
                RaiseSendCommand(new QueryLayoutCommand(this, QueryLayoutOperation.NewLayout));
            }
            else if (e.ElementId.HasValue)
            {
                m_SharedPresenter.SharedModel.SelectedLayoutId = e.ElementId.Value;
            }
            if (!isNewObject)
            {
                layoutDetail.SelectViewTabWithoutRefresh();
            }
        }

        private static void CheckAndTraceQuery(AvrTreeSelectedElementEventArgs e)
        {
            AvrQueryLookup query = AvrQueryLookup.GetAvrQueryLookupById(e.QueryId);
            if (query == null)
            {
                throw new AvrDataException(string.Format("Could not find query with ID '{0}'", e.QueryId));
            }
            Trace.WriteLine(Trace.Kind.Info, "Selected query item {0} with id {1} from list",
                query.QueryName, e.QueryId.ToString());
        }

        private static bool GetUseArchiveForOpeningLayout(long? layoutId, bool isNewObject)
        {
            bool useArchive = false;
            if (!isNewObject && layoutId.HasValue)
            {
                AvrLayoutLookup foundLayout = AvrLayoutLookup.GetAvrLayoutLookupById(layoutId.Value);
                if (foundLayout != null)
                {
                    useArchive = foundLayout.blnUseArchivedData;
                }
            }
            return useArchive;
        }

        #endregion

        #region Layout handlers

        private void LayoutDetailLayoutTabChanged(object sender, TabSelectionEventArgs e)
        {
            biNewQuery.Enabled = e.NewQueryEnabled && AvrPermissions.InsertPermission;
            bbNewQuery.Enabled = e.NewQueryEnabled && AvrPermissions.InsertPermission;

            /*
            biNewLayout.Enabled = e.NewEnabled && AvrPermissions.InsertPermission;
            bbNewLayout.Enabled = e.NewEnabled && AvrPermissions.InsertPermission;


            biCopyQueryLayout.Enabled = e.CopyEnabled && AvrPermissions.InsertPermission;
            bbCopyQueryLayout.Enabled = e.CopyEnabled && AvrPermissions.InsertPermission;
            biEditQueryLayout.Enabled = e.NewEnabled && AvrPermissions.UpdatePermission;
            bbEditQueryLayout.Enabled = e.NewEnabled && AvrPermissions.UpdatePermission;

            biDeleteQueryLayoutFolder.Enabled = e.LayoutDeleteEnabled && AvrPermissions.DeletePermission;

            biDeleteQuery.Enabled = e.QueryDeleteEnabled && AvrPermissions.DeletePermission;
            bbDeleteQueryLayoutFolder.Enabled = e.QueryDeleteEnabled && AvrPermissions.DeletePermission;

            biPublishQueryLayoutFolder.Enabled =
                e.LayoutDeleteEnabled &&
                EidssUserContext.User.HasPermission(
                    PermissionHelper.ExecutePermission(EIDSSPermissionObject.CanPublishLayout));
            */
        }

        private void layoutDetail_PivotFieldMouseRightClick(object sender, PivotFieldPopupMenuEventArgs e)
        {
            using (m_SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.PopupMenuRefreshing))
            {
                IAvrPivotGridField field = e.Field;
                bbEditCaption.Tag = field;
                bbCopyField.Tag = field;
                bbDeleteCopyField.Tag = field;
                bbAddMissedValues.Tag = field;
                bbDeleteMissedValues.Tag = field;

                if (e.EnableGroupDate)
                {
                    bcGroupDate_0.Checked = true;
                    bcGroupDate_0.Tag = field;
                    foreach (KeyValuePair<BarCheckItem, PivotGroupInterval> pair in m_MenuGroupIntervals)
                    {
                        BarCheckItem item = pair.Key;
                        PivotGroupInterval interval = pair.Value;

                        item.Tag = field;
                        item.Checked = field.PrivateGroupInterval == interval;
                        if (item.Checked)
                        {
                            bcGroupDate_0.Checked = false;
                        }
                    }
                }

                bool allowMissedValues = (e.EnableGroupDate || field.AllowMissedReferenceValues);
                bbAddMissedValues.Enabled = !field.AddMissedValues && allowMissedValues;
                bbDeleteMissedValues.Enabled = field.AddMissedValues && allowMissedValues;

                bbDeleteCopyField.Enabled = e.EnableDelete;
                bsGroupDate.Enabled = e.EnableGroupDate;

                PivotPopupMenu.ShowPopup(e.Location);
            }
        }

        #endregion

        #region  Menu handlers

        private void biNewQuery_ItemClick(object sender, ItemClickEventArgs e)
        {
            MenuHandlerWrapper(() =>
            {
                var args = new AvrTreeSelectedElementEventArgs(-1, -1, null, -1, AvrTreeElementType.Query, string.Empty);
                OpenEditor(args, true);
            });
        }

        private void biNewLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            MenuHandlerWrapper(() =>
            {
                AvrTreeSelectedElementEventArgs args = QueryLayoutTree.GetTreeSelectedElementEventArgs();
                args.Type = AvrTreeElementType.Layout;
                args.ElementId = null;

                OpenEditor(args, true);
            });
        }

        private void biNewFolder_ItemClick(object sender, ItemClickEventArgs e)
        {
            MenuHandlerWrapper(() =>
            {
                AvrTreeSelectedElementEventArgs args = QueryLayoutTree.GetTreeSelectedElementEventArgs();
                args.Type = AvrTreeElementType.Folder;
                OpenEditor(args, true);
            });
        }

        private void biEditQueryLayoutFolder_ItemClick(object sender, ItemClickEventArgs e)
        {
            MenuHandlerWrapper(() => OpenEditor(QueryLayoutTree.GetTreeSelectedElementEventArgs()));
        }

        private void biDeleteQueryLayoutFolder_ItemClick(object sender, ItemClickEventArgs e)
        {
            MenuHandlerWrapper(DeleteQueryLayoutFolder);
        }

        private void biCopyQueryLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            MenuHandlerWrapper(() =>
            {
                OpenEditor(QueryLayoutTree.GetTreeSelectedElementEventArgs());
                RaiseSendCommand(new QueryLayoutCommand(sender, QueryLayoutOperation.CopyQueryLayout));
            });
        }

        private void biPublishQueryLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            PublishUnpublish(sender, true);
        }

        private void biUnpublishQueryLayoutFolder_ItemClick(object sender, ItemClickEventArgs e)
        {
            PublishUnpublish(sender, false);
        }

        private void PublishUnpublish(object sender, bool isPublish)
        {
            MenuHandlerWrapper(() =>
            {
                if (TreeOpened)
                {
                    if (Post())
                    {
                        DisposeLayoutDetails();
                        DisposeQueryDetails();

                        AvrTreeSelectedElementEventArgs args = QueryLayoutTree.GetTreeSelectedElementEventArgs();
                        if (!args.ElementId.HasValue)
                        {
                            ErrorForm.ShowMessage("msgElementNotSelected", "Tree element is not selected");
                        }
                        else if (BaseAvrDetailPresenterPanel.UserConfirmPublishUnpublish(args.Type, isPublish))
                        {
                            long id = args.ElementId.Value;
                            m_AvrDbService.PublishUnpublish(id, args.Type, isPublish);
                            QueryLayoutTree.ReloadQueryLayoutFolder(id, args.Type);
                        }
                    }
                }
                else if (IsLayoutOpened || IsQueryOpened)
                {
                    QueryLayoutOperation operation = isPublish
                        ? QueryLayoutOperation.Publish
                        : QueryLayoutOperation.Unpublish;

                    AvrTreeElementType type = IsLayoutOpened ? AvrTreeElementType.Layout : AvrTreeElementType.Query;

                    RaiseSendCommand(new QueryLayoutCommand(sender, operation));
                    QueryLayoutTree.ReloadQueryLayoutFolder((long) GetKey(), type);
                }
            });
        }

        private void biExportReportToXls_ItemClick(object sender, ItemClickEventArgs e)
        {
            MenuHandlerWrapper(() =>
            {
                if (!IsViewPageSelected)
                {
                    RaiseSendCommand(new RefreshPivotCommand(sender));
                }
                RaiseSendCommand(new ExportCommand(sender, ExportObject.View, ExportType.Xls));
            });
        }

        private void biExportReportToXlsx_ItemClick(object sender, ItemClickEventArgs e)
        {
            MenuHandlerWrapper(() =>
            {
                if (!IsViewPageSelected)
                {
                    RaiseSendCommand(new RefreshPivotCommand(sender));
                }
                RaiseSendCommand(new ExportCommand(sender, ExportObject.View, ExportType.Xlsx));
            });
        }

        private void biExportReportToRtf_ItemClick(object sender, ItemClickEventArgs e)
        {
            MenuHandlerWrapper(() =>
            {
                if (!IsViewPageSelected)
                {
                    RaiseSendCommand(new RefreshPivotCommand(sender));
                }
                RaiseSendCommand(new ExportCommand(sender, ExportObject.View, ExportType.Rtf));
            });
        }

        private void biExportReportToPdf_ItemClick(object sender, ItemClickEventArgs e)
        {
            MenuHandlerWrapper(() =>
            {
                if (!IsViewPageSelected)
                {
                    RaiseSendCommand(new RefreshPivotCommand(sender));
                }
                RaiseSendCommand(new ExportCommand(sender, ExportObject.View, ExportType.Pdf));
            });
        }

        private void biExportReportToImage_ItemClick(object sender, ItemClickEventArgs e)
        {
            MenuHandlerWrapper(() =>
            {
                if (!IsViewPageSelected)
                {
                    RaiseSendCommand(new RefreshPivotCommand(sender));
                }
                RaiseSendCommand(new ExportCommand(sender, ExportObject.View, ExportType.Image));
            });
        }

        private void biExportQueryLineListToXls_ItemClick(object sender, ItemClickEventArgs e)
        {
            ExportQueryLineListToExcelOrAccess(ExportType.Xls);
        }

        private void biExportQueryLineListToXlsx_ItemClick(object sender, ItemClickEventArgs e)
        {
            ExportQueryLineListToExcelOrAccess(ExportType.Xlsx);
        }

        private void biExportQueryLineListToMdb_ItemClick(object sender, ItemClickEventArgs e)
        {
            ExportQueryLineListToExcelOrAccess(ExportType.Mdb);
        }

        private void ExportQueryLineListToExcelOrAccess(ExportType type)
        {
            MenuHandlerWrapper(() =>
            {
                if (!Loading && Post())
                {
                    AvrTreeSelectedElementEventArgs args = QueryLayoutTree.GetTreeSelectedElementEventArgs();
                    m_AvrMainFormPresenter.ExportQueryLineListToExcelOrAccess(args.QueryId, type);
                }
            });
        }

        private void biPrintReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            MenuHandlerWrapper(() =>
            {
                if (!IsViewPageSelected)
                {
                    RaiseSendCommand(new RefreshPivotCommand(sender));
                }
                RaiseSendCommand(new PrintCommand(sender, PrintType.View));
            });
        }

        private void biShowToolBar_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            barTools.Visible = biShowToolBar.Checked;
        }

        private void biSettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            MenuHandlerWrapper(() =>
            {
                var form = new AvrSettingsForm();
                BaseFormManager.ShowModal(form, ParentForm);
            });
        }

        private void biInternalHelp_ItemClick(object sender, ItemClickEventArgs e)
        {
            MenuHandlerWrapper(ShowHelp);
        }

        private void biExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            cmdClose_Click();
        }

        private void MenuHandlerWrapper(Action action)
        {
            Utils.CheckNotNull(action, "action");

            try
            {
                if (m_SharedPresenter.ContextKeeper.ContainsContext(ContextValue.ToolbarMenuClicked))
                {
                    return;
                }
                using (m_SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.ToolbarMenuClicked))
                {
                    action();

                    QueryLayoutTree.FocusedNodeReload();
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

        #endregion

        #region Toolar handlers

        private void bbNewQuery_ItemClick(object sender, ItemClickEventArgs e)
        {
            biNewQuery_ItemClick(sender, e);
        }

        private void bbNewLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            biNewLayout_ItemClick(sender, e);
        }

        private void bbNewFolder_ItemClick(object sender, ItemClickEventArgs e)
        {
            biNewFolder_ItemClick(sender, e);
        }

        private void bbEditQueryLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            biEditQueryLayoutFolder_ItemClick(sender, e);
        }

        private void bbDeleteQueryLayoutFolder_ItemClick(object sender, ItemClickEventArgs e)
        {
            biDeleteQueryLayoutFolder_ItemClick(sender, e);
        }

        private void bbCopyQueryLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            biCopyQueryLayout_ItemClick(sender, e);
        }

        private void bbHelp_ItemClick(object sender, ItemClickEventArgs e)
        {
            biInternalHelp_ItemClick(sender, e);
        }

        #endregion

        #region Tree Popup Menu handlers

        private void bbPopupNewQuery_ItemClick(object sender, ItemClickEventArgs e)
        {
            biNewQuery_ItemClick(sender, e);
        }

        private void bbPopupNewLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            biNewLayout_ItemClick(sender, e);
        }

        private void bbPopupNewFolder_ItemClick(object sender, ItemClickEventArgs e)
        {
            biNewFolder_ItemClick(sender, e);
        }

        private void bbPopupEditQueryLayoutFolder_ItemClick(object sender, ItemClickEventArgs e)
        {
            biEditQueryLayoutFolder_ItemClick(sender, e);
        }

        private void bbPopupDeleteQueryLayoutFolder_ItemClick(object sender, ItemClickEventArgs e)
        {
            biDeleteQueryLayoutFolder_ItemClick(sender, e);
        }

        private void bbPopupCopyQueryLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            biCopyQueryLayout_ItemClick(sender, e);
        }

        #endregion

        #region Pivot Popup Menu handlers

        private void bbEditCaption_ItemClick(object sender, ItemClickEventArgs e)
        {
            PopupClickHandler(sender, e, PivotFieldOperation.Rename);
        }

        private void bcGroupDate_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (m_SharedPresenter.ContextKeeper.ContainsContext(ContextValue.PopupMenuRefreshing))
            {
                return;
            }
            IAvrPivotGridField field = FieldFromArgsSingleOrDefault(e);
            if (field != null && e.Item is BarCheckItem)
            {
                var item = (BarCheckItem) e.Item;
                PivotGroupInterval? groupInterval = null;
                bool containsCheckedItem = m_MenuGroupIntervals.ContainsKey(item);
                if (containsCheckedItem)
                {
                    groupInterval = m_MenuGroupIntervals[item];
                }
                if (item == bcGroupDate_0 || containsCheckedItem)
                {
                    RaiseSendCommand(new PivotFieldGroupIntervalCommand(sender, field, groupInterval));
                }
            }
        }

        private void bbCopyField_ItemClick(object sender, ItemClickEventArgs e)
        {
            PopupClickHandler(sender, e, PivotFieldOperation.Copy);
        }

        private void bbDeleteCopyField_ItemClick(object sender, ItemClickEventArgs e)
        {
            PopupClickHandler(sender, e, PivotFieldOperation.DeleteCopy);
        }

        private void bbAddMissedValues_ItemClick(object sender, ItemClickEventArgs e)
        {
            PopupClickHandler(sender, e, PivotFieldOperation.AddMissedValues);
        }

        private void bbDeleteMissedValues_ItemClick(object sender, ItemClickEventArgs e)
        {
            PopupClickHandler(sender, e, PivotFieldOperation.DeleteMissedValues);
        }

        private void PopupClickHandler(object sender, ItemClickEventArgs e, PivotFieldOperation operation)
        {
            if (m_SharedPresenter.ContextKeeper.ContainsContext(ContextValue.PopupMenuRefreshing))
            {
                return;
            }

            IAvrPivotGridField field = FieldFromArgsSingleOrDefault(e);
            if (field != null)
            {
                RaiseSendCommand(new PivotFieldCommand(sender, field, operation));
            }
        }

        private static IAvrPivotGridField FieldFromArgsSingleOrDefault(ItemClickEventArgs e)
        {
            return e.Item != null && !Utils.IsEmpty(e.Item.Tag) && (e.Item.Tag is IAvrPivotGridField)
                ? (IAvrPivotGridField) e.Item.Tag
                : null;
        }

        #endregion

        #region Command

        protected void RaiseSendCommand(Command command)
        {
            if (!IsDesignMode())
            {
                SendCommand.SafeRaise(this, new CommandEventArgs(command));
            }
        }

        #endregion

        #region HelpTopic Methods

        public override void ShowHelp()
        {
            //if (IsLayoutOpened)
            //{
            if (TabControl.SelectedTabPage == TabPageTree)
            {
                ShowHelp("AVR_Getting_Started");
            }
            else if (TabControl.SelectedTabPage == TabPageEditor)
            {
                switch (layoutDetail.SelectedTabPageName)
                {
                    case "tabPagePivotInfo":
                        ShowHelp("info_tab");
                        break;
                    case "tabPagePivotGrid":
                        ShowHelp("Pivot_Grid_Tab");
                        break;
                    case "tabPageView":
                        ShowHelp("view_tab");
                        break;
                        //case "tabPageReport":
                        //    ShowHelp("AVR_Reports_Management");
                        //    break;
                        //case "tabPageChart":
                        //    ShowHelp("AVR_Chart_Management");
                        //    break;
                        //case "tabPageMap":
                        //    ShowHelp("AVR_in_Maps");
                        //    break;
                    default:
                        base.ShowHelp();
                        break;
                }
            }
            //}
            //else if (IsQueryOpened)
            //{
            //    ShowHelp("AVR_Getting_Started");
            //}
            //else
            //{
            //    ShowHelp("AVR_Getting_Started");
            //}
        }

        #endregion

        #region ITranslationView

        #endregion
    }
}