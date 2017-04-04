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
using bv.common.Resources;
using bv.common.win;
using bv.common.win.BaseForms;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.winclient.Core.TranslationTool;
using bv.winclient.Layout;
using DevExpress.XtraBars;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Localization;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList.Nodes;
using eidss.avr.BaseComponents;
using eidss.avr.db.AvrEventArgs.AvrEventArgs;
using eidss.avr.db.Common;
using eidss.avr.db.Common.CommandProcessing.Commands.Export;
using eidss.avr.db.DBService;
using eidss.avr.db.DBService.QueryBuilder;
using eidss.avr.db.Interfaces;
using eidss.avr.Handlers.AvrEventArgs;
using eidss.avr.LayoutForm;
using eidss.avr.PivotComponents;
using eidss.avr.QueryBuilder;
using eidss.avr.QueryLayoutTree;
using eidss.model.Avr.Commands;
using eidss.model.Avr.Commands.Export;
using eidss.model.Avr.Commands.Layout;
using eidss.model.Avr.Commands.Models;
using eidss.model.Avr.Commands.Print;
using eidss.model.Avr.Commands.Refresh;
using eidss.model.Avr.Tree;
using eidss.model.AVR.DataBase;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Reports.OperationContext;
using eidss.model.Resources;
using eidss.model.Schema;
using eidss.model.Trace;
using eidss.winclient;
using Container = StructureMap.Container;

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

        private long? m_QueryOrLayoutParentId;

        private readonly Query_DB m_QueryDbService;
        private readonly Layout_DB m_LayoutDbService;
        private readonly Folder_DB m_FolderDbService;
        public event EventHandler<CommandEventArgs> SendCommand;

        private AvrMainFormPresenter m_AvrMainFormPresenter;
        private SharedPresenter m_SharedPresenter;

        private readonly Dictionary<BarCheckItem, PivotGroupInterval> m_MenuGroupIntervals =
            new Dictionary<BarCheckItem, PivotGroupInterval>();

        private readonly StructureMap.IContainer m_Container;
        #region Construction & Dispose

        public AvrMainForm()
        {
            try
            {
                Trace.WriteLine(Trace.Kind.Info, "AvrMainForm(): AvrMainForm creating...");
                
                m_Container = StructureMapContainerInit();
                using (PresenterFactory.BeginSharedPresenterTransaction(m_Container, this))
                {
                    m_SharedPresenter = PresenterFactory.SharedPresenter;
                    m_AvrMainFormPresenter = (AvrMainFormPresenter) m_SharedPresenter[this];

                    InitializeComponent();
                }

                if (IsDesignMode())
                {
                    return;
                }
                if (BaseSettings.TranslationMode)
                {
                    var translationButton = new TranslationButton();
                    translationButton.Top = Height - translationButton.Height;
                    translationButton.Left = Width - translationButton.Width - 4;
                    translationButton.Parent = this;
                    translationButton.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
                    translationButton.BringToFront();
                }

                m_QueryDbService = new Query_DB();
                m_LayoutDbService = new WinLayout_DB(m_SharedPresenter.SharedModel);
                m_FolderDbService = new Folder_DB();
                DbService = new BaseAvrDbService();

                RegisterChildObject(QueryLayoutTree, RelatedPostOrder.PostLast);

                QueryLayoutTree.OnElementSelect += QueryLayoutTree_OnElementSelect;
                QueryLayoutTree.OnElementEdit += QueryLayoutTree_OnElementEdit;
                QueryLayoutTree.OnElementPopup += QueryLayoutTree_OnElementPopup;

                biSettings.Visibility = AvrPermissions.AccessToAVRAdministrationPermission
                    ? BarItemVisibility.Always
                    : BarItemVisibility.Never;
                PivotGridFieldBase.DefaultTotalFormat.FormatString = PivotGridLocalizer.GetString(PivotGridStringId.TotalFormat);

                //     System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Saturday;
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
        // todo [ivan] implement
        private static Container StructureMapContainerInit()
        {
            Container c = new Container();
            c.Configure(r => { r.For<ITraceStrategy>().Use<EidssTraceStrategy>(); }); 
            return c;
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
                    m_SharedPresenter.UnregisterView(this);
                    m_SharedPresenter.Dispose();
                    m_SharedPresenter = null;
                }
                BaseFormManager.UnRegister(this);
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
            using (PresenterFactory.BeginSharedPresenterTransaction(m_SharedPresenter))
            {
                layoutDetail = new LayoutDetailPanel
                {
                    Location = new Point(0, 0),
                    Size = new Size(EditorPanel.Width, EditorPanel.Height),
                    Dock = DockStyle.Fill,
                    IgnoreAudit = true
                };
            }

            if (isNewObject)
            {
                layoutDetail.SelectInfoTabWithoutRefresh();
            }

            layoutDetail.Appearance.Options.UseFont = true;

            EditorPanel.Controls.Add(layoutDetail);

            RegisterChildObject(layoutDetail, RelatedPostOrder.PostLast);

            layoutDetail.LayoutTabChanged += LayoutDetailLayoutTabChanged;
            layoutDetail.PivotFieldMouseRightClick += layoutDetail_PivotFieldMouseRightClick;

            layoutDetail.OnAfterPost += layoutDetail_OnAfterPost;
        }

        private void InitQueryDetail()
        {
            TabPageEditor.Text = EidssMessages.Get("msgQuery", "Query");
            if (queryDetail != null)
            {
                return;
            }
            using (PresenterFactory.BeginSharedPresenterTransaction(m_SharedPresenter))
            {
                queryDetail = new QueryDetailPanel
                {
                    Location = new Point(0, 0),
                    Size = new Size(EditorPanel.Width, EditorPanel.Height),
                    Dock = DockStyle.Fill,
                    Visible = true,
                };
            }

            EditorPanel.Controls.Add(queryDetail);

            RegisterChildObject(queryDetail, RelatedPostOrder.PostLast);

            queryDetail.OnAfterPost += queryDetail_OnAfterPost;
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

                layoutDetail.LayoutTabChanged -= LayoutDetailLayoutTabChanged;
                layoutDetail.PivotFieldMouseRightClick -= layoutDetail_PivotFieldMouseRightClick;
                layoutDetail.OnAfterPost -= layoutDetail_OnAfterPost;

                layoutDetail.Dispose();
                layoutDetail = null;

                m_SharedPresenter.SharedModel.SelectedLayoutId = -1;
                m_QueryOrLayoutParentId = null;
                ChangeFormCaption();

                
            }
        }

        private void DisposeQueryDetails()
        {
            if (queryDetail != null)
            {
                queryDetail.Hide();
                UnRegisterChildObject(queryDetail);
                m_SharedPresenter.UnregisterView(queryDetail);
                queryDetail.OnAfterPost -= queryDetail_OnAfterPost;
                queryDetail.Dispose();
                queryDetail = null;
                m_SharedPresenter.SharedModel.SelectedQueryId = -1;
                m_QueryOrLayoutParentId = null;
                ChangeFormCaption();
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
                            AvrTreeElementType.Layout);
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
            var detailPanel = child as LayoutDetailPanel;
            if (detailPanel != null)
            {
                return detailPanel.GetKey();
            }

            var childPanel = child as QueryDetailPanel;
            if (childPanel != null)
            {
                return childPanel.GetKey();
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
            try
            {
                // if user hasn't update permission -  no need to save
                if (!AvrPermissions.UpdatePermission)
                {
                    return true;
                }
                // if dispose already called - no need to save
                if (m_SharedPresenter == null || m_SharedPresenter.ContextKeeper == null)
                {
                    return true;
                }
                if (!Utils.IsCalledFromUnitTest() && FindForm() == null)
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
                            m_ClosingMode = ClosingMode.Ok;
                        }
                        // No need to Post if call this code from unit-tests
                        isPost = Utils.IsCalledFromUnitTest() || base.Post(postType);

                        object key = GetKey();
                        if (isPost && key is long)
                        {
                            var id = (long) key;
                            AvrTreeElementType type = IsLayoutOpened
                                ? AvrTreeElementType.Layout
                                : AvrTreeElementType.Query;

                            QueryLayoutTree.ReloadQueryLayoutFolder(id, type);
                            QueryLayoutTree.SetTreeFocusedNodeByElementId(id);
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
            finally
            {
                m_ClosingMode = ClosingMode.None;
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
                    break;
                case AvrTreeElementType.Folder:
                    if (!args.ElementId.HasValue)
                    {
                        throw new AvrException("Couldn't delete folder because it's not selected");
                    }
                    DeleteQueryLayout(args.ElementId.Value, AvrTreeElementType.Folder, true);
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

        public void LayoutCopyStart()
        {
            CopyLayoutTimer.Start();
        }

        private void CopyLayoutTimer_Tick(object sender, EventArgs e)
        {
            CopyLayoutTimer.Stop();

            TreeOpened = true;
            DisposeLayoutDetails();
            DisposeQueryDetails();

            AvrTreeSelectedElementEventArgs args = QueryLayoutTree.GetTreeSelectedElementEventArgs();
            CopyLayoutInternal(args);
        }

        public void LayoutNewStart()
        {
            NewLayoutTimer.Start();
        }

        private void NewLayoutTimer_Tick(object sender, EventArgs e)
        {
            NewLayoutTimer.Stop();

            TreeOpened = true;
            DisposeLayoutDetails();
            DisposeQueryDetails();

            NewLayoutInternal();
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

                BaseAvrDbService dbService;
                switch (objectType)
                {
                    case AvrTreeElementType.Query:
                        dbService = m_QueryDbService;
                        break;
                    case AvrTreeElementType.Layout:
                        dbService = m_LayoutDbService;
                        break;
                    case AvrTreeElementType.Folder:
                        dbService = m_FolderDbService;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("objectType", string.Format("Unsupported object type '{0}'", objectType));
                }

                if (dbService.CanDelete(id))
                {
                    if (objectType != AvrTreeElementType.Folder)
                    {
                        DisposeLayoutDetails();
                        DisposeQueryDetails();
                    }
                    if (!dbService.Delete(id))
                    {
                        ErrorMessage err = dbService.LastError;
                        throw new AvrException(err.Text + err.Exception);
                    }

                    //QueryLayoutTree.DeleteFolder();

                    switch (objectType)
                    {
                        case AvrTreeElementType.Query:
                            LookupCache.NotifyDelete("Query", null, id);
                            LookupCache.NotifyChange("LayoutFolder");
                            LookupCache.NotifyChange("Layout");
                            break;
                        case AvrTreeElementType.Folder:
                            LookupCache.NotifyChange("LayoutFolder");
                            LookupCache.NotifyChange("Layout");
                            break;

                        case AvrTreeElementType.Layout:
                            LookupCache.NotifyDelete("Layout", null, id);
                            break;
                    }

                    QueryLayoutTree.DeleteNodeWithId(id);
                }
                else
                {
                    ErrorMessage err = dbService.LastError;
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
            if (layoutDetail != null)
            {
                QueryLayoutTree.SetTreeFocusedNodeByElementId((long) layoutDetail.GetKey());
            }
            else if (queryDetail != null)
            {
                QueryLayoutTree.SetTreeFocusedNodeByElementId((long) queryDetail.GetKey());
            }

            QueryLayoutTree_OnElementSelect(sender, QueryLayoutTree.GetTreeSelectedElementEventArgs());

            GC.Collect();
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

                biEditQueryLayoutFolder.Visibility = bbEditQueryLayoutFolder.Visibility = bbPopupEditQueryLayoutFolder.Visibility =
                    AvrPermissions.UpdatePermission && TreeOpened && !QueryLayoutTree.IsFocusedNodeReadOnly
                        ? BarItemVisibility.Always
                        : BarItemVisibility.Never;

                biViewQueryLayoutFolder.Visibility = bbViewQueryLayoutFolder.Visibility = bbPopupViewQueryLayoutFolder.Visibility =
                    AvrPermissions.UpdatePermission && TreeOpened && QueryLayoutTree.IsFocusedNodeReadOnly
                        ? BarItemVisibility.Always
                        : BarItemVisibility.Never;

                biDeleteQueryLayoutFolder.Enabled = bbDeleteQueryLayoutFolder.Enabled = bbPopupDeleteQueryLayoutFolder.Enabled =
                    AvrPermissions.DeletePermission && !QueryLayoutTree.IsFocusedNodeReadOnly;


                biRefreshData.Enabled = bbRefreshData.Enabled = (e.Type != AvrTreeElementType.Folder);

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
                if (!Loading && (e.Type == AvrTreeElementType.Folder || Post()))
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
                                m_QueryOrLayoutParentId = e.ParentId;
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
                    }
                    DesignControlManager.Create(this);
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

        public void ChangeFormCaption(RefreshCaptionCommand refreshCommand)
        {
            TreeListNode node = QueryLayoutTree.GetNodeByElementId(m_QueryOrLayoutParentId ?? -1);
            string newCaption = refreshCommand.Caption;
            if (node != null)
            {
                newCaption = string.IsNullOrEmpty(refreshCommand.Caption)
                    ? node.GetPath()
                    : string.Format("{0}\\ {1}", node.GetPath(), refreshCommand.Caption);
            }
            ChangeFormCaption(newCaption);
        }

        private void ChangeFormCaption(string newCaption = null)
        {
            Form parentForm = FindForm();
            if (parentForm != null)
            {
                var resources = new ComponentResourceManager(typeof (AvrMainForm));
                string baseCaption = resources.GetString("$this.Caption");
                parentForm.Text = string.IsNullOrEmpty(newCaption)
                    ? baseCaption
                    : string.Format("{0} - {1}", baseCaption, newCaption);
            }
        }

        private void OpenQueryEditor(AvrTreeSelectedElementEventArgs e, bool isNewObject = false)
        {
            DisposeQueryDetails();
            InitQueryDetail();

           
            object id = isNewObject ? null : (object) e.QueryId;
            queryDetail.LoadData(ref id);

            DisposeLayoutDetails();
            m_SharedPresenter.SharedModel.SelectedLayoutId = -1;
        }

        private void queryDetail_OnAfterPost(object sender, EventArgs e)
        {
            
            if (queryDetail.DbService != null && queryDetail.DbService.ID is long)
            {
                AvrMainFormPresenter.InvalidateQuery((long) queryDetail.DbService.ID);
            }
        }

        private void OpenLayoutEditor(AvrTreeSelectedElementEventArgs e, bool isNewObject = false)
        {
            m_SharedPresenter.SharedModel.UseArchiveData = GetUseArchiveForOpeningLayout(e.ElementId, isNewObject);

            DisposeLayoutDetails();

            bool shouldLoad = true;
            if (!m_AvrMainFormPresenter.DoesCachedQueryExists(e.QueryId))
            {
                var defaultMsg = "Opening the Layout can take a long time due to Query execution. Click [Ok] to continue loading layout data, otherwise click [Cancel]";
                string message = EidssMessages.Get("msgShouldOpenLayout", defaultMsg, ModelUserContext.CurrentLanguage);
                string caption = BvMessages.Get("Confirmation", "Confirmation", ModelUserContext.CurrentLanguage);

                if (MessageForm.Show(message, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                {
                    shouldLoad = false;
                }
            }
            if (shouldLoad)
            {
                InitLayoutDetail(isNewObject);
                
            }
            else
            {
                TreeOpened = true;
            }

            DisposeQueryDetails();
            

            if (shouldLoad)
            {
                CheckAndTraceQuery(e);
                var layoutId = !isNewObject && e.ElementId.HasValue
                    ? e.ElementId.Value
                    : -1;

                m_AvrMainFormPresenter.ExecQuery(e.QueryId, layoutId);

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
        }

        private void layoutDetail_OnAfterPost(object sender, EventArgs e)
        {
           
            if (layoutDetail.DbService != null && layoutDetail.DbService.ID is long)
            {
                AvrMainFormPresenter.InvalidateView((long)layoutDetail.DbService.ID);
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

            biCopyQueryLayout.Enabled = e.CopyEnabled && AvrPermissions.InsertPermission;
            bbCopyQueryLayout.Enabled = e.CopyEnabled && AvrPermissions.InsertPermission;

            biNewLayout.Enabled = e.NewEnabled && AvrPermissions.InsertPermission;
            bbNewLayout.Enabled = e.NewEnabled && AvrPermissions.InsertPermission;
        }

        private void layoutDetail_PivotFieldMouseRightClick(object sender, PivotFieldPopupMenuEventArgs e)
        {
            using (m_SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.PopupMenuRefreshing))
            {
                var formSender = sender as BaseForm;
                bool readOnly = formSender != null && formSender.ReadOnly;

                IAvrPivotGridField field = e.Field;
                bbEditCaption.Tag = field;
                bbCopyField.Tag = field;
                bbDeleteCopyField.Tag = field;
                bbAddMissedValues.Tag = field;
                bbDeleteMissedValues.Tag = field;
                bbEditMissedValues.Tag = field;

                bool enableGroupDate = !readOnly && field != null && field.IsDateTimeField && field.Visible;
                if (enableGroupDate)
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

                bool allowMissedValues = (field != null &&
                                          field.Visible &&
                                          (field.Area == PivotArea.ColumnArea || field.Area == PivotArea.RowArea) &&
                                          (field.IsDateTimeField || field.AllowMissedReferenceValues));
                bbAddMissedValues.Enabled = allowMissedValues && !field.AddMissedValues;
                bbEditMissedValues.Enabled = allowMissedValues && field.AddMissedValues && field.IsDateTimeField;
                bbDeleteMissedValues.Enabled = allowMissedValues && field.AddMissedValues;

                bbEditCaption.Enabled = !readOnly;
                bbCopyField.Enabled = !readOnly;
                bbDeleteCopyField.Enabled = !readOnly && field != null && AvrPivotGridHelper.EnableDeleteField(field, field.AllPivotFields);
                bsGroupDate.Enabled = enableGroupDate;

                PivotPopupMenu.ShowPopup(e.Location);
            }
        }

        #endregion

        #region  Menu handlers

        private void biNewQuery_ItemClick(object sender, ItemClickEventArgs e)
        {
            MenuHandlerWrapper(() =>
            {
                var args = new AvrTreeSelectedElementEventArgs(-1, -1, null, -1, AvrTreeElementType.Query);
                OpenEditor(args, true);
            });
        }

        private void biNewLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            MenuHandlerWrapper(NewLayoutInternal);
        }

        private void NewLayoutInternal()
        {
            AvrTreeSelectedElementEventArgs args = QueryLayoutTree.GetTreeSelectedElementEventArgs();
            args.Type = AvrTreeElementType.Layout;
            args.ElementId = null;

            OpenEditor(args, true);
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

        private void biViewQueryLayoutFolder_ItemClick(object sender, ItemClickEventArgs e)
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
                AvrTreeSelectedElementEventArgs args = QueryLayoutTree.GetTreeSelectedElementEventArgs();

                switch (args.Type)
                {
                    case AvrTreeElementType.Query:
                        CopyQueryInternal(sender, args);
                        break;
                    case AvrTreeElementType.Layout:
                        CopyLayoutInternal(args);
                        break;

                    default:
                        throw new AvrException("Wrong object type to copy: " + args.Type);
                }
            });
        }

        private void CopyQueryInternal(object sender, AvrTreeSelectedElementEventArgs args)
        {
            OpenEditor(args);
            RaiseSendCommand(new QueryLayoutCommand(sender, QueryLayoutOperation.CopyQuery));
        }

        private void CopyLayoutInternal(AvrTreeSelectedElementEventArgs args)
        {
            if (!args.ElementId.HasValue)
            {
                return;
            }

            long idCopy = VirtualLayoutCopier.CreateLayoutCopy(args.ElementId.Value, m_Container);
            QueryLayoutTree.ReloadQueryLayoutFolder(idCopy, AvrTreeElementType.Layout);
            QueryLayoutTree.SetTreeFocusedNodeByElementId(idCopy);
            args = QueryLayoutTree.GetTreeSelectedElementEventArgs();
            OpenEditor(args);
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
                            switch (args.Type)
                            {
                                case AvrTreeElementType.Query:
                                    m_QueryDbService.PublishUnpublish(id, isPublish);
                                    break;
                                case AvrTreeElementType.Layout:
                                    m_LayoutDbService.PublishUnpublish(id, isPublish);
                                    break;
                                case AvrTreeElementType.Folder:
                                    m_FolderDbService.PublishUnpublish(id, isPublish);
                                    break;
                                default:
                                    throw new AvrException("Unsupported AvrTreeElementType " + args.Type);
                            }

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

        private void biRefreshData_ItemClick(object sender, ItemClickEventArgs e)
        {
            MenuHandlerWrapper(() =>
            {
                if (!Loading && Post())
                {
                    DisposeQueryDetails();
                    DisposeLayoutDetails();

                    var args = QueryLayoutTree.GetTreeSelectedElementEventArgs();

                    m_AvrMainFormPresenter.RefreshQuery(args.QueryId);
                }
            });
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

        private void bbEditQueryLayoutFolder_ItemClick(object sender, ItemClickEventArgs e)
        {
            biEditQueryLayoutFolder_ItemClick(sender, e);
        }

        private void bbViewQueryLayoutFolder_ItemClick(object sender, ItemClickEventArgs e)
        {
            biViewQueryLayoutFolder_ItemClick(sender, e);
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

        private void bbPopupViewQueryLayoutFolder_ItemClick(object sender, ItemClickEventArgs e)
        {
            biViewQueryLayoutFolder_ItemClick(sender, e);
        }

        private void bbPopupDeleteQueryLayoutFolder_ItemClick(object sender, ItemClickEventArgs e)
        {
            biDeleteQueryLayoutFolder_ItemClick(sender, e);
        }

        private void bbPopupCopyQueryLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            biCopyQueryLayout_ItemClick(sender, e);
        }

        private void bbRefreshData_ItemClick(object sender, ItemClickEventArgs e)
        {
            biRefreshData_ItemClick(sender, e);
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

        private void bbEditMissedValues_ItemClick(object sender, ItemClickEventArgs e)
        {
            PopupClickHandler(sender, e, PivotFieldOperation.EditMissedValues);
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
                    default:
                        base.ShowHelp();
                        break;
                }
            }
        }

        #endregion

      
        
        #region ITranslationView

        #endregion
    }
}