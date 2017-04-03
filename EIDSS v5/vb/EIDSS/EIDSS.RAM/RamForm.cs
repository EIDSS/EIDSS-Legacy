using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraNavBar;
using EIDSS.RAM.Components;
using EIDSS.RAM.Layout;
using EIDSS.RAM.Presenters;
using EIDSS.RAM.Presenters.Base;
using EIDSS.RAM.Presenters.RamForm;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands;
using EIDSS.RAM_DB.Common.CommandProcessing.Commands.Layout;
using EIDSS.RAM_DB.Common.EventHandlers;
using EIDSS.RAM_DB.DBService;
using EIDSS.RAM_DB.DBService.Models;
using EIDSS.RAM_DB.Views;
using EIDSS.Reports.OperationContext;
using bv.common;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Diagnostics;
using bv.common.db.Core;
using bv.common.win;
using bv.common.win.BaseForms;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.winclient.Layout;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Resources;
using ErrorForm = bv.common.win.ErrorForm;

namespace EIDSS.RAM
{
    public partial class RamForm : BaseReportForm, IRamFormView
    {
        private readonly string m_PathPrefix;
        private readonly BaseRamDbService m_RamDbService;
        public event EventHandler<CommandEventArgs> SendCommand;

        private readonly RamFormPresenter m_RamPresenter;
        private readonly SharedPresenter m_SharedPresenter;

        public RamForm()
        {
            try
            {
                Trace.WriteLine(Trace.Kind.Info, "RamReportControl(): RamReportControl creating...");

                // Note: [Ivan] init model factory for each copy of RamForm.
                // when next copy of RamForm created, 
                //previous copy already inited so they does not need ModelFactory
                PresenterFactory.Init(this);

                m_SharedPresenter = PresenterFactory.SharedPresenter;
                m_RamPresenter = (RamFormPresenter) m_SharedPresenter[this];

                InitializeComponent();
                if (IsDesignMode())
                {
                    return;
                }

                m_PathPrefix = nbGroupQueryLayout.Caption;
                m_SharedPresenter.SharedModel.ShowAllItems = true;
                m_RamDbService = new BaseRamDbService();
                DbService = m_RamDbService;

                RegisterChildObject(queryInfo, RelatedPostOrder.PostLast);
                RegisterChildObject(layoutInfo, RelatedPostOrder.PostLast);
                RegisterChildObject(layoutDetail, RelatedPostOrder.PostLast);

                nbControlQueryLayout_GroupExpanded(this, new NavBarGroupEventArgs(nbGroupQueryLayout));

                layoutDetail.LayoutTabChanged += LayoutDetailLayoutTabChanged;

                queryInfo.QuerySelected += QueryInfoQuerySelected;
                queryInfo.QuerySelecting += QueryInfoQuerySelecting;

                layoutInfo.PathChanged += LayoutInfoPathChanged;

                layoutDetail.LayoutInfoChanged += layoutInfo.LayoutDetailLayoutInfoChanged;
                layoutDetail.CopyLayoutCreating += layoutInfo.LayoutDetailCopyLayoutCreating;
                layoutDetail.PivotFieldMouseRightClick += layoutDetail_PivotFieldMouseRightClick;

                queryInfo.BackColor = layoutInfo.BackColor;
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

        protected void RaiseSendCommand(Command command)
        {
            if (!IsDesignMode())
            {
                SendCommand.SafeRaise(this, new CommandEventArgs(command));
            }
        }

        public DataSet BaseDataSet
        {
            get { return baseDataSet; }
        }

        #region Init

        protected override void AfterLoad()
        {
            using (m_SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.AfterLoad))
            {
                biExport.Enabled = EidssUserContext.User.HasPermission(
                    PermissionHelper.ExecutePermission(EIDSSPermissionObject.CanImportExportData));

                if (StartUpParameters != null)
                {
                    if (StartUpParameters.ContainsKey(SharedProperty.StandardReports.ToString()))
                    {
                        m_SharedPresenter.SharedModel.StandardReports =
                            (bool) StartUpParameters[SharedProperty.StandardReports.ToString()];
                        nbControlQueryLayout.Visible = !m_SharedPresenter.SharedModel.StandardReports;
                        biShowAll.Enabled = false;
                        bbShowAll.Enabled = false;
                        QueryInfoQuerySelected(this, new QueryEventArgs(queryInfo.SelectedQueryID));
                    }
                    if (StartUpParameters.ContainsKey("ShowAll"))
                    {
                        biShowAll.Checked = (bool) StartUpParameters["ShowAll"];
                    }
                    if (StartUpParameters.ContainsKey("ReportView"))
                    {
                        biReportView.Checked = (bool) StartUpParameters["ReportView"];
                        StartUpParameters.Remove("ReportView");
                    }
                }
            }
        }

        private void AVRReportControl_Load(object sender, EventArgs e)
        {
            Trace.WriteLine(Trace.Kind.Info, "RamReportControl.AVRReportControl_Load(): Loading main control...");

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
            if (child is LayoutDetail)
            {
                return ((LayoutDetail) child).GetKey(null, null);
            }
            return null;
        }

        public override object GetKey(string tableName, string keyFieldName)
        {
            return layoutDetail.GetKey(tableName, keyFieldName);
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

                    RamMenuRegistrator.RegisterWinStaticReports(ShowStandardReport);
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

        private static void ShowStandardReport(MenuAction action)
        {
            try
            {
                // using (PresenterFactory.ModelFactory.ContextKeeper.CreateNewContext(ContextValue.ShowNormal))
                using (CreateWaitDialog())
                {
                    var startupParams = new Dictionary<string, object>
                                            {
                                                {"ReportView", true},
                                                {"StandardReports", true}
                                            };
                    //startupParams.Add("ShowAll", false);
                    long layoutId;
                    long.TryParse(action.Name.Substring("btnStandardReport".Length), out layoutId);
                    startupParams.Add("LayoutId", layoutId);

                    DataView dvLayout = LookupCache.Get(LookupTables.Layout.ToString());
                    dvLayout.RowFilter = string.Format("idflLayout = {0}", layoutId);
                    if (dvLayout.Count == 1)
                    {
                        object queryId = dvLayout[0]["idflQuery"];
                        startupParams.Add("QueryId", queryId);
                    }
                    object id = layoutId;
                    BaseFormManager.ShowNormal(new RamForm(), ref id, startupParams);
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
                    var found = (RamForm) BaseFormManager.FindForm(typeof (RamForm), null, CompareForm);
                    //foreach (BaseForm form in FormsList)
                    //{
                    //    if (!(form is RamForm))
                    //        continue;
                    //    if (form.StartUpParameters != null &&
                    //        form.StartUpParameters.ContainsKey(SharedProperty.StandardReports.ToString()))
                    //        continue;

                    //    found = (RamForm)form;
                    //}
                    if (found == null)
                    {
                        object key = -1;
                        BaseFormManager.ShowNormal(new RamForm(), ref key);
                    }
                    //else
                    //{
                    //    Form parentForm = found.FindForm();
                    //    if (parentForm != null)
                    //    {
                    //        parentForm.BringToFront();
                    //    }
                    //    SetCurrentForm(found);
                    //}
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

        #region Query handlers

        private void QueryInfoQuerySelecting(object sender, ChangingEventArgs e)
        {
            try
            {
                Trace.WriteLine(Trace.Kind.Info,
                                "RamReportControl.QueryInfoQuerySelecting(): Selecting query with id {0} from list",
                                Utils.Str(e.NewValue));

                e.Cancel = e.Cancel || !Post(PostType.FinalPosting);
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

        private void QueryInfoQuerySelected(object sender, QueryEventArgs e)
        {
            try
            {
                string queryName = LookupCache.GetLookupValue(e.QueryId, LookupTables.Query, "QueryName");
                Trace.WriteLine(Trace.Kind.Info,
                                "RamReportControl.QueryInfoQuerySelected(): Selected query item {0} with id {1} from list",
                                queryName, Utils.Str(e.QueryId));

                m_RamPresenter.ExecQuery(e.QueryId, m_SharedPresenter.SharedModel.UseArchiveData);
                m_SharedPresenter.SharedModel.SelectedQueryId = e.QueryId;
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

        #region Layout handlers

        private void LayoutInfoPathChanged(object sender, PathChangedEventArgs e)
        {
            nbGroupQueryLayout.Caption = string.IsNullOrEmpty(e.FullPath)
                                             ? m_PathPrefix
                                             : string.Format("{0} - {1}", m_PathPrefix, e.FullPath);
            m_RamPresenter.SharedPresenter.SharedModel.SelectedFolderId = e.FolderId;
        }

        private void LayoutDetailLayoutTabChanged(object sender, TabSelectionEventArgs e)
        {
            queryInfo.Enabled = e.QueryInfoEnabled;
            layoutInfo.Enabled = e.LayoutInfoEnabled;

            biNewLayout.Enabled = e.NewEnabled && RamPermissions.InsertPermission;
            bbNewLayout.Enabled = e.NewEnabled && RamPermissions.InsertPermission;
            biNewQuery.Enabled = e.NewQueryEnabled && RamPermissions.InsertPermission;
            bbNewQuery.Enabled = e.NewQueryEnabled && RamPermissions.InsertPermission;

            biCopyLayout.Enabled = e.CopyEnabled && RamPermissions.InsertPermission;
            bbCopyLayout.Enabled = e.CopyEnabled && RamPermissions.InsertPermission;
            biEditQuery.Enabled = e.NewEnabled && RamPermissions.UpdatePermission;
            bbEditQuery.Enabled = e.NewEnabled && RamPermissions.UpdatePermission;

            biDeleteLayout.Enabled = e.LayoutDeleteEnabled && RamPermissions.DeletePermission;
            bbDeleteLayout.Enabled = e.LayoutDeleteEnabled && RamPermissions.DeletePermission;
            biDeleteQuery.Enabled = e.QueryDeleteEnabled && RamPermissions.DeletePermission;
            bbDeleteQuery.Enabled = e.QueryDeleteEnabled && RamPermissions.DeletePermission;

            biPublishLayout.Enabled =
                e.LayoutDeleteEnabled &&
                EidssUserContext.User.HasPermission(
                    PermissionHelper.ExecutePermission(EIDSSPermissionObject.CanPublishLayout));

            biQuery.Enabled = e.LayoutInfoEnabled && biNewQuery.Enabled || biDeleteQuery.Enabled || biEditQuery.Enabled;

            biCancelChanges.Enabled = e.CancelEnabled && RamPermissions.UpdatePermission;
            bbCancelChanges.Enabled = e.CancelEnabled && RamPermissions.UpdatePermission;

            biSaveLayout.Enabled = e.SaveEnabled && RamPermissions.UpdatePermission;
            bbSaveLayout.Enabled = e.SaveEnabled && RamPermissions.UpdatePermission;

            biLayout.Enabled = biNewLayout.Enabled || biCopyLayout.Enabled || biDeleteLayout.Enabled ||
                               bbSaveLayout.Enabled || biCancelChanges.Enabled;

            bbShowAll.Enabled = e.StandardReportsEnabled;
            biShowAll.Enabled = e.StandardReportsEnabled;
        }

        public void OnPivotFieldVisibleChanged(LayoutFieldVisibleChanged e)
        {
            biExportDataToAccess.Enabled = e.Visible;
        }

        public void OnPivotSelected(PivotSelectionEventArgs e)
        {
            biPrintChart.Enabled = e.ChartEnabled;
            biExportChart.Enabled = e.ChartEnabled;
            biPrintMap.Enabled = e.MapEnabled;
            biExportMapToImage.Enabled = e.MapEnabled;
        }

        private void layoutDetail_PivotFieldMouseRightClick(object sender, PivotFieldPopupMenuEventArgs e)
        {
            PivotPopupMenu.ShowPopup(e.Location);
            bbEditCaption.Tag = e.FieldName;
        }

        private void bbEditCaption_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Utils.IsEmpty(bbEditCaption.Tag))
            {
                RaiseSendCommand(new ChangeFieldCaptionCommand(sender, Utils.Str(bbEditCaption.Tag)));
            }
        }
        #endregion

        #region  Menu handlers

        #region Export

        private void biExportMapToImage_ItemClick(object sender, ItemClickEventArgs e)
        {
            layoutDetail.ExportMapSettingsFromMapToLayout();
            
            RaiseSendCommand(new ExportCommand(this, ExportObject.Map, ExportType.Image));
        }

       

        private void biExportDataToAccess_ItemClick(object sender, ItemClickEventArgs e)
        {
            RaiseSendCommand(new ExportCommand(this, ExportObject.Access, ExportType.XLS));
        }

        private void biExportChartToExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            RaiseSendCommand(new ExportCommand(this, ExportObject.Chart, ExportType.XLS));
        }

        private void biExportChartToPdf_ItemClick(object sender, ItemClickEventArgs e)
        {
            RaiseSendCommand(new ExportCommand(this, ExportObject.Chart, ExportType.PDF));
        }

        private void biExportChartToImage_ItemClick(object sender, ItemClickEventArgs e)
        {
            RaiseSendCommand(new ExportCommand(this, ExportObject.Chart, ExportType.Image));
        }

        private void biExportChartToHtml_ItemClick(object sender, ItemClickEventArgs e)
        {
            RaiseSendCommand(new ExportCommand(this, ExportObject.Chart, ExportType.Html));
        }

        private void biExportReportToExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            RaiseSendCommand(new ExportCommand(this, ExportObject.Report, ExportType.XLS));
        }

        private void biExportReportToRtf_ItemClick(object sender, ItemClickEventArgs e)
        {
            RaiseSendCommand(new ExportCommand(this, ExportObject.Report, ExportType.RTF));
        }

        private void biExportReportToHtml_ItemClick(object sender, ItemClickEventArgs e)
        {
            RaiseSendCommand(new ExportCommand(this, ExportObject.Report, ExportType.Html));
        }

        private void biExportReportToPdf_ItemClick(object sender, ItemClickEventArgs e)
        {
            RaiseSendCommand(new ExportCommand(this, ExportObject.Report, ExportType.PDF));
        }

        private void biExportReportToImage_ItemClick(object sender, ItemClickEventArgs e)
        {
            RaiseSendCommand(new ExportCommand(this, ExportObject.Report, ExportType.Image));
        }

        #endregion

        #region  View

        private void biReportView_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            BarItemVisibility visibility = BarItemVisibility.Never;
            if (biReportView.Checked)
            {
                RaiseSendCommand(new ReportViewCommand(this, grcMain, 41));
            }
            else
            {
                if (
                    EidssUserContext.User.HasPermission(
                        PermissionHelper.UpdatePermission(EIDSSPermissionObject.AVRReport)))
                {
                    RaiseSendCommand(new ReportViewCommand(this));
                    visibility = BarItemVisibility.Always;
                }
                else
                {
                    biReportView.Checked = true;
                    return;
                }
            }
            biQuery.Visibility = visibility;
            biLayout.Visibility = visibility;
            biPrint.Visibility = visibility;
            biShowAll.Visibility = visibility;
            biShowToolBar.Visibility = visibility;
            biExportChart.Visibility = visibility;
            biExportMapToImage.Visibility = visibility;
            barTools.Visible = !biReportView.Checked && biShowToolBar.Checked;
        }

        private void biPredefined_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            using (m_SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.biPredefined_CheckedChanged))
            {
                if (m_SharedPresenter.ContextKeeper.ContainsContext(ContextValue.bbPredefined_DownChanged))
                {
                    return;
                }

                if (biShowAll.Checked != bbShowAll.Down)
                {
                    if ((biShowAll.Checked) || ((!biShowAll.Checked) && Post(PostType.FinalPosting)))
                    {
                        bbShowAll.Down = biShowAll.Checked;
                        m_DoPost = false;
                        ShowAllChanged();
                    }
                    biShowAll.Checked = bbShowAll.Down;
                }
            }
        }

        private void biShowToolBar_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            barTools.Visible = biShowToolBar.Checked;
        }

        #endregion

        #region  Help

        private void biInternalHelp_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m_SharedPresenter.ContextKeeper.ContainsContext(ContextValue.ToolbarClicked))
            {
                return;
            }
            using (m_SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.ToolbarClicked))
            {
                ShowHelp();
            }
        }

        #endregion

        #region  Print

        private void biPrintPivot_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m_SharedPresenter.ContextKeeper.ContainsContext(ContextValue.ToolbarClicked))
            {
                return;
            }
            using (m_SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.ToolbarClicked))
            {
                RaiseSendCommand(new PrintCommand(this, PrintType.Grid));
            }
        }

        private void biPrintChart_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m_SharedPresenter.ContextKeeper.ContainsContext(ContextValue.ToolbarClicked))
            {
                return;
            }
            using (m_SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.ToolbarClicked))
            {
                RaiseSendCommand(new PrintCommand(this, PrintType.Chart));
            }
        }

        private void biPrintMap_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m_SharedPresenter.ContextKeeper.ContainsContext(ContextValue.ToolbarClicked))
            {
                return;
            }
            using (m_SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.ToolbarClicked))
            {
                RaiseSendCommand(new PrintCommand(this, PrintType.Map));
            }
        }

        #endregion

        #region Query

        private void biNewQuery_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m_SharedPresenter.ContextKeeper.ContainsContext(ContextValue.ToolbarClicked))
            {
                return;
            }
            using (m_SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.ToolbarClicked))
            {
                if (Post(PostType.FinalPosting))
                {
                    RaiseSendCommand(new QueryCommand(this, QueryOperation.New));
                }
            }
        }

        private void biEditQuery_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m_SharedPresenter.ContextKeeper.ContainsContext(ContextValue.ToolbarClicked))
            {
                return;
            }
            using (m_SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.ToolbarClicked))
            {
                if (Post(PostType.FinalPosting))
                {
                    RaiseSendCommand(new QueryCommand(this, QueryOperation.Edit));
                }
            }
        }

        private void biDeleteQuery_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m_SharedPresenter.ContextKeeper.ContainsContext(ContextValue.ToolbarClicked))
            {
                return;
            }
            using (m_SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.ToolbarClicked))
            {
                RaiseSendCommand(new QueryCommand(this, QueryOperation.Delete));
            }
        }

        #endregion

        #region Layout

        private void biPublishLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m_SharedPresenter.ContextKeeper.ContainsContext(ContextValue.ToolbarClicked))
            {
                return;
            }
            using (m_SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.ToolbarClicked))
            {
                RaiseSendCommand(new LayoutCommand(this, LayoutOperation.Publish));
            }
        }

        private void biCancelChanges_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m_SharedPresenter.ContextKeeper.ContainsContext(ContextValue.ToolbarClicked))
            {
                return;
            }
            using (m_SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.ToolbarClicked))
            {
                RaiseSendCommand(new LayoutCommand(this, LayoutOperation.Cancel));
            }
        }

        private void biSaveLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m_SharedPresenter.ContextKeeper.ContainsContext(ContextValue.ToolbarClicked))
            {
                return;
            }
            using (m_SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.ToolbarClicked))
            {
                RaiseSendCommand(new LayoutCommand(this, LayoutOperation.Save));
            }
        }

        private void biCopyLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m_SharedPresenter.ContextKeeper.ContainsContext(ContextValue.ToolbarClicked))
            {
                return;
            }
            using (m_SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.ToolbarClicked))
            {
                RaiseSendCommand(new LayoutCommand(this, LayoutOperation.Copy));
            }
        }

        private void biNewLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m_SharedPresenter.ContextKeeper.ContainsContext(ContextValue.ToolbarClicked))
            {
                return;
            }
            using (m_SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.ToolbarClicked))
            {
                RaiseSendCommand(new LayoutCommand(this, LayoutOperation.New));
            }
        }

        private void biDeleteLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m_SharedPresenter.ContextKeeper.ContainsContext(ContextValue.ToolbarClicked))
            {
                return;
            }
            using (m_SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.ToolbarClicked))
            {
                RaiseSendCommand(new LayoutCommand(this, LayoutOperation.Delete));
            }
        }

        #endregion

        private void biClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            cmdClose_Click();
        }

        #endregion

        #region Toolar handlers

        private void bbNewQuery_ItemClick(object sender, ItemClickEventArgs e)
        {
            biNewQuery_ItemClick(sender, e);
        }

        private void bbEditQuery_ItemClick(object sender, ItemClickEventArgs e)
        {
            biEditQuery_ItemClick(sender, e);
        }

        private void bbDeleteQuery_ItemClick(object sender, ItemClickEventArgs e)
        {
            biDeleteQuery_ItemClick(sender, e);
        }

        private void bbCancelChanges_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m_SharedPresenter.ContextKeeper.ContainsContext(ContextValue.ToolbarClicked))
            {
                return;
            }
            using (m_SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.ToolbarClicked))
            {
                RaiseSendCommand(new LayoutCommand(this, LayoutOperation.Cancel));
            }
        }

        private void bbCopyLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            biCopyLayout_ItemClick(sender, e);
        }

        private void bbNewLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            biNewLayout_ItemClick(sender, e);
        }

        private void bbDeleteLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            biDeleteLayout_ItemClick(sender, e);
        }

        private void bbSaveLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            biSaveLayout_ItemClick(sender, e);
        }

        private void bbPredefined_DownChanged(object sender, ItemClickEventArgs e)
        {
            using (m_SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.bbPredefined_DownChanged))
            {
                if (m_SharedPresenter.ContextKeeper.ContainsContext(ContextValue.biPredefined_CheckedChanged))
                {
                    return;
                }
                if (bbShowAll.Down != biShowAll.Checked)
                {
                    if ((bbShowAll.Down) || ((!bbShowAll.Down) && Post(PostType.FinalPosting)))
                    {
                        biShowAll.Checked = bbShowAll.Down;
                        m_DoPost = false;
                        ShowAllChanged();
                    }
                    bbShowAll.Down = biShowAll.Checked;
                }
            }
        }

        private bool m_DoPost = true;

        private void ShowAllChanged()
        {
            m_SharedPresenter.SharedModel.ShowAllItems = biShowAll.Checked;
            long newQueryId;
            if (queryInfo.PredefinedChanged(out newQueryId))
            {
                queryInfo.SetDefaultQuery();
            }
            else
            {
                m_SharedPresenter.SharedModel.SelectedQueryId = newQueryId;
            }
            m_DoPost = true;
        }

        private void bbPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            RaiseSendCommand(new PrintCommand(this, PrintType.Context));
        }

        private void bbHelp_ItemClick(object sender, ItemClickEventArgs e)
        {
            biInternalHelp_ItemClick(sender, e);
        }

        #endregion

        #region Nav Bar Layout

        private void nbControlQueryLayout_GroupCollapsed(object sender, NavBarGroupEventArgs e)
        {
            if (e.Group == nbGroupQueryLayout)
            {
                nbControlQueryLayout.Height = BaseRamPresenter.NavBarGroupHeaderHeight;
            }
        }

        private void nbControlQueryLayout_GroupExpanded(object sender, NavBarGroupEventArgs e)
        {
            if (e.Group == nbGroupQueryLayout)
            {
                nbControlQueryLayout.Height = nbGroupQueryLayout.ControlContainer.Height +
                                              BaseRamPresenter.NavBarGroupHeaderHeight;
            }
        }

        #endregion

        #region HelpTopic Methods

        public override void ShowHelp()
        {
            switch (layoutDetail.SelectedTabPageName)
            {
                case "tabPageGrid":
                    switch (layoutDetail.SelectedPivotTabPageName)
                    {
                        case "pageLayoutDetails":
                            ShowHelp("AVR_Getting_Started");
                            break;
                        case "pageAdditionalSettings":
                            ShowHelp("AVR_Pivot_Table");
                            break;
                        default:
                            base.ShowHelp();
                            break;
                    }
                    break;
                case "tabPageReport":
                    ShowHelp("AVR_Reports_Management");
                    break;
                case "tabPageChart":
                    ShowHelp("AVR_Chart_Management");
                    break;
                case "tabPageMap":
                    ShowHelp("AVR_in_Maps");
                    break;
                default:
                    base.ShowHelp();
                    break;
            }
        }

        #endregion

        #region Overrides

        public override Dictionary<string, object> StartUpParameters
        {
            get { return base.StartUpParameters; }
            set
            {
                base.StartUpParameters = value;
                m_SharedPresenter.SharedModel.StartUpParameters = value;
            }
        }

        public override bool ReadOnly
        {
            get { return false; }
            set
            {
                base.ReadOnly = false;
                queryInfo.ReadOnly = false;
                layoutInfo.ReadOnly = false;
            }
        }

        public override bool HasChanges()
        {
            if (m_DoPost)
            {
                return base.HasChanges();
            }
            return m_DoPost;
        }

        protected override BaseRamDetailPanel GetChildForPost()
        {
            return layoutDetail;
        }

        public override bool Post(PostType postType)
        {
            // if we delete query, no need to save layout
            if (m_SharedPresenter.ContextKeeper.ContainsContext(ContextValue.DeleteQuery))
            {
                return true;
            }
            // if user hasn't update permission, no need to save
            if (!RamPermissions.UpdatePermission)
            {
                return true;
            }

            bool isPost;
            using (m_SharedPresenter.ContextKeeper.CreateNewContext(ContextValue.Post))
            {
                if (Utils.IsCalledFromUnitTest())
                {
                    m_ClosingMode = BaseDetailForm.ClosingMode.Ok;
                }
                // No need to Post if PivotAccessible is false or call this code from unit-tests
                try
                {
                    isPost = !(m_SharedPresenter.SharedModel.PivotAccessible || Utils.IsCalledFromUnitTest()) || base.Post(postType);    
                }
                catch(Exception)
                {
                    throw;
                }

                
            }
            return isPost;
        }

        /// <summary>
        ///   Call base post without any check. this method should be uses for debug purposes only
        /// </summary>
        /// <returns> </returns>
        internal bool ForcePost()
        {
            return base.Post();
        }

        /// <summary>
        ///   Clean up any resources being used.
        /// </summary>
        /// <param name="disposing"> true if managed resources should be disposed; otherwise, false. </param>
        protected override void Dispose(bool disposing)
        {
            LayoutCorrector.Reset();

            m_SharedPresenter.UnregisterView(this);

            if (layoutDetail != null)
            {
                UnRegisterChildObject(layoutDetail);
            }
            if (queryInfo != null)
            {
                UnRegisterChildObject(queryInfo);
                queryInfo.QuerySelected -= QueryInfoQuerySelected;
                queryInfo.QuerySelecting -= QueryInfoQuerySelecting;
            }
            if (layoutInfo != null)
            {
                UnRegisterChildObject(layoutInfo);
                layoutInfo.PathChanged -= LayoutInfoPathChanged;
                if (layoutDetail != null)
                {
                    layoutDetail.LayoutInfoChanged -= layoutInfo.LayoutDetailLayoutInfoChanged;
                    layoutDetail.CopyLayoutCreating -= layoutInfo.LayoutDetailCopyLayoutCreating;
                }
            }

            nbControlQueryLayout.GroupExpanded -= nbControlQueryLayout_GroupExpanded;
            nbControlQueryLayout.GroupCollapsed -= nbControlQueryLayout_GroupCollapsed;

            eventManager.ClearAllReferences();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);

            nbContainerQueryLayout = null;
            queryInfo = null;
            layoutInfo = null;
            layoutDetail = null;
            PresenterFactory.RemovePresenterLink(m_SharedPresenter);

            m_SharedPresenter.Dispose();

            LayoutCorrector.Reset();
        }

        #endregion

       
    }
}
