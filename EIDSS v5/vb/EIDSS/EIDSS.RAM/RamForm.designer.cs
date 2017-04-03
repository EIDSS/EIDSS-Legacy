
using System.Data;
using EIDSS.RAM.Layout;
using EIDSS.RAM_DB.Common.EventHandlers;

namespace EIDSS.RAM
{
    partial class RamForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RamForm));
            this.grcMain = new DevExpress.XtraEditors.GroupControl();
            this.grcBottom = new DevExpress.XtraEditors.GroupControl();
            this.layoutDetail = new EIDSS.RAM.Layout.LayoutDetail();
            this.nbControlQueryLayout = new DevExpress.XtraNavBar.NavBarControl();
            this.nbGroupQueryLayout = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbContainerQueryLayout = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.grcTop = new DevExpress.XtraEditors.GroupControl();
            this.grcLayout = new DevExpress.XtraEditors.GroupControl();
            this.layoutInfo = new EIDSS.RAM.Layout.LayoutInfo();
            this.splitterControl2 = new DevExpress.XtraEditors.SplitterControl();
            this.grcQueryBuilder = new DevExpress.XtraEditors.GroupControl();
            this.queryInfo = new EIDSS.RAM.QueryBuilder.QueryInfo();
            this.barManager = new DevExpress.XtraBars.BarManager();
            this.barTools = new DevExpress.XtraBars.Bar();
            this.bbNewQuery = new DevExpress.XtraBars.BarButtonItem();
            this.bbEditQuery = new DevExpress.XtraBars.BarButtonItem();
            this.bbDeleteQuery = new DevExpress.XtraBars.BarButtonItem();
            this.bbCancelChanges = new DevExpress.XtraBars.BarButtonItem();
            this.bbCopyLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbNewLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbDeleteLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbShowAll = new DevExpress.XtraBars.BarButtonItem();
            this.bbPrint = new DevExpress.XtraBars.BarButtonItem();
            this.bbHelp = new DevExpress.XtraBars.BarButtonItem();
            this.barMenu = new DevExpress.XtraBars.Bar();
            this.biFile = new DevExpress.XtraBars.BarSubItem();
            this.biPrint = new DevExpress.XtraBars.BarSubItem();
            this.biPrintPivot = new DevExpress.XtraBars.BarButtonItem();
            this.biPrintChart = new DevExpress.XtraBars.BarButtonItem();
            this.biPrintMap = new DevExpress.XtraBars.BarButtonItem();
            this.biExport = new DevExpress.XtraBars.BarSubItem();
            this.biExportReport = new DevExpress.XtraBars.BarSubItem();
            this.biExportReportToExcel = new DevExpress.XtraBars.BarButtonItem();
            this.biExportReportToRtf = new DevExpress.XtraBars.BarButtonItem();
            this.biExportReportToPdf = new DevExpress.XtraBars.BarButtonItem();
            this.biExportReportToHtml = new DevExpress.XtraBars.BarButtonItem();
            this.biExportReportToImage = new DevExpress.XtraBars.BarButtonItem();
            this.biExportChart = new DevExpress.XtraBars.BarSubItem();
            this.biExportChartToExcel = new DevExpress.XtraBars.BarButtonItem();
            this.biExportChartToImage = new DevExpress.XtraBars.BarButtonItem();
            this.biExportChartToPdf = new DevExpress.XtraBars.BarButtonItem();
            this.biExportChartToHtml = new DevExpress.XtraBars.BarButtonItem();
            this.biExportMapToImage = new DevExpress.XtraBars.BarButtonItem();
            this.biExportDataToAccess = new DevExpress.XtraBars.BarButtonItem();
            this.biExit = new DevExpress.XtraBars.BarButtonItem();
            this.biView = new DevExpress.XtraBars.BarSubItem();
            this.biReportView = new DevExpress.XtraBars.BarCheckItem();
            this.biShowAll = new DevExpress.XtraBars.BarCheckItem();
            this.biShowToolBar = new DevExpress.XtraBars.BarCheckItem();
            this.biQuery = new DevExpress.XtraBars.BarSubItem();
            this.biNewQuery = new DevExpress.XtraBars.BarButtonItem();
            this.biEditQuery = new DevExpress.XtraBars.BarButtonItem();
            this.biDeleteQuery = new DevExpress.XtraBars.BarButtonItem();
            this.biLayout = new DevExpress.XtraBars.BarSubItem();
            this.biCancelChanges = new DevExpress.XtraBars.BarButtonItem();
            this.biCopyLayout = new DevExpress.XtraBars.BarButtonItem();
            this.biNewLayout = new DevExpress.XtraBars.BarButtonItem();
            this.biDeleteLayout = new DevExpress.XtraBars.BarButtonItem();
            this.biSaveLayout = new DevExpress.XtraBars.BarButtonItem();
            this.biPublishLayout = new DevExpress.XtraBars.BarButtonItem();
            this.biHelp = new DevExpress.XtraBars.BarSubItem();
            this.biInternalHelp = new DevExpress.XtraBars.BarButtonItem();
            this.barStatus = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageCollectionToolBar = new DevExpress.Utils.ImageCollection();
            this.bbSaveLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbEditCaption = new DevExpress.XtraBars.BarButtonItem();
            this.PivotPopupMenu = new DevExpress.XtraBars.PopupMenu();
            ((System.ComponentModel.ISupportInitialize)(this.grcMain)).BeginInit();
            this.grcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcBottom)).BeginInit();
            this.grcBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbControlQueryLayout)).BeginInit();
            this.nbControlQueryLayout.SuspendLayout();
            this.nbContainerQueryLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcTop)).BeginInit();
            this.grcTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcLayout)).BeginInit();
            this.grcLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcQueryBuilder)).BeginInit();
            this.grcQueryBuilder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionToolBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PivotPopupMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // grcMain
            // 
            this.grcMain.Appearance.Options.UseFont = true;
            this.grcMain.AppearanceCaption.Options.UseFont = true;
            this.grcMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grcMain.Controls.Add(this.grcBottom);
            this.grcMain.Controls.Add(this.nbControlQueryLayout);
            resources.ApplyResources(this.grcMain, "grcMain");
            this.grcMain.LookAndFeel.SkinName = "Black";
            this.grcMain.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grcMain.LookAndFeel.UseWindowsXPTheme = true;
            this.grcMain.Name = "grcMain";
            this.grcMain.ShowCaption = false;
            // 
            // grcBottom
            // 
            this.grcBottom.Appearance.Options.UseFont = true;
            this.grcBottom.AppearanceCaption.Options.UseFont = true;
            this.grcBottom.Controls.Add(this.layoutDetail);
            resources.ApplyResources(this.grcBottom, "grcBottom");
            this.grcBottom.MinimumSize = new System.Drawing.Size(400, 300);
            this.grcBottom.Name = "grcBottom";
            this.grcBottom.ShowCaption = false;
            // 
            // layoutDetail
            // 
            resources.ApplyResources(this.layoutDetail, "layoutDetail");
            this.layoutDetail.Appearance.Options.UseFont = true;
            this.layoutDetail.DefaultFormState = System.Windows.Forms.FormWindowState.Normal;
            this.layoutDetail.FormID = null;
            this.layoutDetail.HelpTopicID = null;
            this.layoutDetail.IgnoreAudit = true;
            this.layoutDetail.IsStatusReadOnly = false;
            this.layoutDetail.KeyFieldName = null;
            this.layoutDetail.MultiSelect = false;
            this.layoutDetail.Name = "layoutDetail";
            this.layoutDetail.ObjectName = null;
            this.layoutDetail.Status = bv.common.win.FormStatus.Draft;
            this.layoutDetail.TableName = null;
            // 
            // nbControlQueryLayout
            // 
            this.nbControlQueryLayout.ActiveGroup = this.nbGroupQueryLayout;
            this.nbControlQueryLayout.Appearance.Background.Options.UseFont = true;
            this.nbControlQueryLayout.Appearance.Button.Options.UseFont = true;
            this.nbControlQueryLayout.Appearance.ButtonDisabled.Options.UseFont = true;
            this.nbControlQueryLayout.Appearance.ButtonHotTracked.Options.UseFont = true;
            this.nbControlQueryLayout.Appearance.ButtonPressed.Options.UseFont = true;
            this.nbControlQueryLayout.Appearance.GroupBackground.Options.UseFont = true;
            this.nbControlQueryLayout.Appearance.GroupHeader.Options.UseFont = true;
            this.nbControlQueryLayout.Appearance.GroupHeaderActive.Options.UseFont = true;
            this.nbControlQueryLayout.Appearance.GroupHeaderHotTracked.Options.UseFont = true;
            this.nbControlQueryLayout.Appearance.GroupHeaderPressed.Options.UseFont = true;
            this.nbControlQueryLayout.Appearance.Hint.Options.UseFont = true;
            this.nbControlQueryLayout.Appearance.Item.Options.UseFont = true;
            this.nbControlQueryLayout.Appearance.ItemActive.Options.UseFont = true;
            this.nbControlQueryLayout.Appearance.ItemDisabled.Options.UseFont = true;
            this.nbControlQueryLayout.Appearance.ItemHotTracked.Options.UseFont = true;
            this.nbControlQueryLayout.Appearance.ItemPressed.Options.UseFont = true;
            this.nbControlQueryLayout.Appearance.LinkDropTarget.Options.UseFont = true;
            this.nbControlQueryLayout.Appearance.NavigationPaneHeader.Options.UseFont = true;
            this.nbControlQueryLayout.Appearance.NavPaneContentButton.Options.UseFont = true;
            this.nbControlQueryLayout.Appearance.NavPaneContentButtonHotTracked.Options.UseFont = true;
            this.nbControlQueryLayout.Appearance.NavPaneContentButtonPressed.Options.UseFont = true;
            this.nbControlQueryLayout.Appearance.NavPaneContentButtonReleased.Options.UseFont = true;
            this.nbControlQueryLayout.ContentButtonHint = null;
            this.nbControlQueryLayout.Controls.Add(this.nbContainerQueryLayout);
            resources.ApplyResources(this.nbControlQueryLayout, "nbControlQueryLayout");
            this.nbControlQueryLayout.ExplorerBarGroupInterval = 1;
            this.nbControlQueryLayout.ExplorerBarGroupOuterIndent = 0;
            this.nbControlQueryLayout.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nbGroupQueryLayout});
            this.nbControlQueryLayout.LookAndFeel.SkinName = "Black";
            this.nbControlQueryLayout.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.nbControlQueryLayout.LookAndFeel.UseDefaultLookAndFeel = false;
            this.nbControlQueryLayout.Name = "nbControlQueryLayout";
            this.nbControlQueryLayout.OptionsNavPane.ExpandedWidth = ((int)(resources.GetObject("resource.ExpandedWidth")));
            this.nbControlQueryLayout.SkinExplorerBarViewScrollStyle = DevExpress.XtraNavBar.SkinExplorerBarViewScrollStyle.ScrollBar;
            this.nbControlQueryLayout.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinExplorerBarViewInfoRegistrator("Blue");
            this.nbControlQueryLayout.GroupExpanded += new DevExpress.XtraNavBar.NavBarGroupEventHandler(this.nbControlQueryLayout_GroupExpanded);
            this.nbControlQueryLayout.GroupCollapsed += new DevExpress.XtraNavBar.NavBarGroupEventHandler(this.nbControlQueryLayout_GroupCollapsed);
            // 
            // nbGroupQueryLayout
            // 
            resources.ApplyResources(this.nbGroupQueryLayout, "nbGroupQueryLayout");
            this.nbGroupQueryLayout.ControlContainer = this.nbContainerQueryLayout;
            this.nbGroupQueryLayout.Expanded = true;
            this.nbGroupQueryLayout.GroupClientHeight = 119;
            this.nbGroupQueryLayout.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.nbGroupQueryLayout.Name = "nbGroupQueryLayout";
            // 
            // nbContainerQueryLayout
            // 
            this.nbContainerQueryLayout.Controls.Add(this.grcTop);
            this.nbContainerQueryLayout.Name = "nbContainerQueryLayout";
            resources.ApplyResources(this.nbContainerQueryLayout, "nbContainerQueryLayout");
            // 
            // grcTop
            // 
            this.grcTop.Appearance.Options.UseFont = true;
            this.grcTop.AppearanceCaption.Options.UseFont = true;
            this.grcTop.Controls.Add(this.grcLayout);
            this.grcTop.Controls.Add(this.splitterControl2);
            this.grcTop.Controls.Add(this.grcQueryBuilder);
            resources.ApplyResources(this.grcTop, "grcTop");
            this.grcTop.MinimumSize = new System.Drawing.Size(500, 100);
            this.grcTop.Name = "grcTop";
            this.grcTop.ShowCaption = false;
            // 
            // grcLayout
            // 
            this.grcLayout.Appearance.Options.UseFont = true;
            this.grcLayout.AppearanceCaption.Options.UseFont = true;
            this.grcLayout.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grcLayout.Controls.Add(this.layoutInfo);
            resources.ApplyResources(this.grcLayout, "grcLayout");
            this.grcLayout.Name = "grcLayout";
            this.grcLayout.ShowCaption = false;
            // 
            // layoutInfo
            // 
            this.layoutInfo.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("layoutInfo.Appearance.BackColor")));
            this.layoutInfo.Appearance.Options.UseBackColor = true;
            this.layoutInfo.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.layoutInfo, "layoutInfo");
            this.layoutInfo.DefaultFormState = System.Windows.Forms.FormWindowState.Normal;
            this.layoutInfo.FormID = null;
            this.layoutInfo.HelpTopicID = null;
            this.layoutInfo.IsStatusReadOnly = false;
            this.layoutInfo.KeyFieldName = null;
            this.layoutInfo.MinimumSize = new System.Drawing.Size(200, 80);
            this.layoutInfo.MultiSelect = false;
            this.layoutInfo.Name = "layoutInfo";
            this.layoutInfo.ObjectName = null;
            this.layoutInfo.Status = bv.common.win.FormStatus.Draft;
            this.layoutInfo.TableName = null;
            // 
            // splitterControl2
            // 
            this.splitterControl2.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.splitterControl2, "splitterControl2");
            this.splitterControl2.Name = "splitterControl2";
            this.splitterControl2.TabStop = false;
            // 
            // grcQueryBuilder
            // 
            this.grcQueryBuilder.Appearance.Options.UseFont = true;
            this.grcQueryBuilder.AppearanceCaption.Options.UseFont = true;
            this.grcQueryBuilder.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grcQueryBuilder.Controls.Add(this.queryInfo);
            resources.ApplyResources(this.grcQueryBuilder, "grcQueryBuilder");
            this.grcQueryBuilder.MinimumSize = new System.Drawing.Size(200, 100);
            this.grcQueryBuilder.Name = "grcQueryBuilder";
            this.grcQueryBuilder.ShowCaption = false;
            // 
            // queryInfo
            // 
            this.queryInfo.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("queryInfo.Appearance.BackColor")));
            this.queryInfo.Appearance.Options.UseBackColor = true;
            this.queryInfo.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.queryInfo, "queryInfo");
            this.queryInfo.DefaultFormState = System.Windows.Forms.FormWindowState.Normal;
            this.queryInfo.FormID = null;
            this.queryInfo.HelpTopicID = null;
            this.queryInfo.IsStatusReadOnly = false;
            this.queryInfo.KeyFieldName = null;
            this.queryInfo.MinimumSize = new System.Drawing.Size(200, 80);
            this.queryInfo.MultiSelect = false;
            this.queryInfo.Name = "queryInfo";
            this.queryInfo.ObjectName = null;
            this.queryInfo.Sizable = true;
            this.queryInfo.Status = bv.common.win.FormStatus.Draft;
            this.queryInfo.TableName = null;
            this.queryInfo.UseParentBackColor = true;
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barTools,
            this.barMenu,
            this.barStatus});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Images = this.imageCollectionToolBar;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.biFile,
            this.biView,
            this.biPrint,
            this.biQuery,
            this.biLayout,
            this.biExit,
            this.biPrintPivot,
            this.biPrintChart,
            this.biPrintMap,
            this.biNewQuery,
            this.biEditQuery,
            this.biDeleteQuery,
            this.biCopyLayout,
            this.biNewLayout,
            this.biDeleteLayout,
            this.biReportView,
            this.biShowAll,
            this.biHelp,
            this.biInternalHelp,
            this.biExport,
            this.biExportDataToAccess,
            this.biExportReport,
            this.biExportChart,
            this.biExportChartToExcel,
            this.biExportChartToImage,
            this.biExportChartToHtml,
            this.biExportChartToPdf,
            this.biExportReportToExcel,
            this.biExportReportToRtf,
            this.biExportReportToPdf,
            this.biExportReportToHtml,
            this.bbNewQuery,
            this.bbEditQuery,
            this.bbDeleteQuery,
            this.bbNewLayout,
            this.bbCopyLayout,
            this.bbDeleteLayout,
            this.bbCancelChanges,
            this.bbSaveLayout,
            this.bbShowAll,
            this.bbPrint,
            this.bbHelp,
            this.biShowToolBar,
            this.biCancelChanges,
            this.biSaveLayout,
            this.biExportMapToImage,
            this.biPublishLayout,
            this.biExportReportToImage,
            this.bbEditCaption});
            this.barManager.MainMenu = this.barMenu;
            this.barManager.MaxItemId = 62;
            this.barManager.StatusBar = this.barStatus;
            // 
            // barTools
            // 
            this.barTools.BarName = "Tools";
            this.barTools.DockCol = 0;
            this.barTools.DockRow = 1;
            this.barTools.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbNewQuery),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbEditQuery),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbDeleteQuery),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbCancelChanges, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbCopyLayout),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbNewLayout),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbDeleteLayout),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbShowAll, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbPrint, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbHelp, true)});
            this.barTools.OptionsBar.AllowQuickCustomization = false;
            this.barTools.OptionsBar.DisableClose = true;
            this.barTools.OptionsBar.DisableCustomization = true;
            this.barTools.OptionsBar.DrawDragBorder = false;
            resources.ApplyResources(this.barTools, "barTools");
            // 
            // bbNewQuery
            // 
            this.bbNewQuery.Appearance.Options.UseFont = true;
            this.bbNewQuery.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.bbNewQuery, "bbNewQuery");
            this.bbNewQuery.Id = 44;
            this.bbNewQuery.ImageIndex = 32;
            this.bbNewQuery.Name = "bbNewQuery";
            this.bbNewQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbNewQuery_ItemClick);
            // 
            // bbEditQuery
            // 
            this.bbEditQuery.Appearance.Options.UseFont = true;
            this.bbEditQuery.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.bbEditQuery, "bbEditQuery");
            this.bbEditQuery.Id = 45;
            this.bbEditQuery.ImageIndex = 31;
            this.bbEditQuery.Name = "bbEditQuery";
            this.bbEditQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbEditQuery_ItemClick);
            // 
            // bbDeleteQuery
            // 
            this.bbDeleteQuery.Appearance.Options.UseFont = true;
            this.bbDeleteQuery.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.bbDeleteQuery, "bbDeleteQuery");
            this.bbDeleteQuery.Id = 46;
            this.bbDeleteQuery.ImageIndex = 30;
            this.bbDeleteQuery.Name = "bbDeleteQuery";
            this.bbDeleteQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbDeleteQuery_ItemClick);
            // 
            // bbCancelChanges
            // 
            this.bbCancelChanges.Appearance.Options.UseFont = true;
            this.bbCancelChanges.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.bbCancelChanges, "bbCancelChanges");
            this.bbCancelChanges.Id = 50;
            this.bbCancelChanges.ImageIndex = 36;
            this.bbCancelChanges.Name = "bbCancelChanges";
            this.bbCancelChanges.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbCancelChanges_ItemClick);
            // 
            // bbCopyLayout
            // 
            this.bbCopyLayout.Appearance.Options.UseFont = true;
            this.bbCopyLayout.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.bbCopyLayout, "bbCopyLayout");
            this.bbCopyLayout.Id = 48;
            this.bbCopyLayout.ImageIndex = 35;
            this.bbCopyLayout.Name = "bbCopyLayout";
            this.bbCopyLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbCopyLayout_ItemClick);
            // 
            // bbNewLayout
            // 
            this.bbNewLayout.Appearance.Options.UseFont = true;
            this.bbNewLayout.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.bbNewLayout, "bbNewLayout");
            this.bbNewLayout.Id = 47;
            this.bbNewLayout.ImageIndex = 26;
            this.bbNewLayout.Name = "bbNewLayout";
            this.bbNewLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbNewLayout_ItemClick);
            // 
            // bbDeleteLayout
            // 
            this.bbDeleteLayout.Appearance.Options.UseFont = true;
            this.bbDeleteLayout.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.bbDeleteLayout, "bbDeleteLayout");
            this.bbDeleteLayout.Id = 49;
            this.bbDeleteLayout.ImageIndex = 27;
            this.bbDeleteLayout.Name = "bbDeleteLayout";
            this.bbDeleteLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbDeleteLayout_ItemClick);
            // 
            // bbShowAll
            // 
            this.bbShowAll.Appearance.Options.UseFont = true;
            this.bbShowAll.AppearanceDisabled.Options.UseFont = true;
            this.bbShowAll.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            resources.ApplyResources(this.bbShowAll, "bbShowAll");
            this.bbShowAll.Down = true;
            this.bbShowAll.Id = 52;
            this.bbShowAll.ImageIndex = 56;
            this.bbShowAll.Name = "bbShowAll";
            this.bbShowAll.DownChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.bbPredefined_DownChanged);
            // 
            // bbPrint
            // 
            this.bbPrint.Appearance.Options.UseFont = true;
            this.bbPrint.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.bbPrint, "bbPrint");
            this.bbPrint.Id = 53;
            this.bbPrint.ImageIndex = 33;
            this.bbPrint.Name = "bbPrint";
            this.bbPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbPrint_ItemClick);
            // 
            // bbHelp
            // 
            this.bbHelp.Appearance.Options.UseFont = true;
            this.bbHelp.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.bbHelp, "bbHelp");
            this.bbHelp.Id = 54;
            this.bbHelp.ImageIndex = 58;
            this.bbHelp.Name = "bbHelp";
            this.bbHelp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbHelp_ItemClick);
            // 
            // barMenu
            // 
            this.barMenu.BarName = "Main menu";
            this.barMenu.DockCol = 0;
            this.barMenu.DockRow = 0;
            this.barMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biFile),
            new DevExpress.XtraBars.LinkPersistInfo(this.biView),
            new DevExpress.XtraBars.LinkPersistInfo(this.biQuery),
            new DevExpress.XtraBars.LinkPersistInfo(this.biLayout),
            new DevExpress.XtraBars.LinkPersistInfo(this.biHelp)});
            this.barMenu.OptionsBar.AllowQuickCustomization = false;
            this.barMenu.OptionsBar.DisableClose = true;
            this.barMenu.OptionsBar.DisableCustomization = true;
            this.barMenu.OptionsBar.DrawDragBorder = false;
            this.barMenu.OptionsBar.MultiLine = true;
            this.barMenu.OptionsBar.UseWholeRow = true;
            resources.ApplyResources(this.barMenu, "barMenu");
            // 
            // biFile
            // 
            this.biFile.Appearance.Options.UseFont = true;
            this.biFile.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biFile, "biFile");
            this.biFile.Id = 0;
            this.biFile.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.biExport),
            new DevExpress.XtraBars.LinkPersistInfo(this.biExit)});
            this.biFile.Name = "biFile";
            this.biFile.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption;
            // 
            // biPrint
            // 
            this.biPrint.Appearance.Options.UseFont = true;
            this.biPrint.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biPrint, "biPrint");
            this.biPrint.Id = 2;
            this.biPrint.ImageIndex = 33;
            this.biPrint.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biPrintPivot),
            new DevExpress.XtraBars.LinkPersistInfo(this.biPrintChart),
            new DevExpress.XtraBars.LinkPersistInfo(this.biPrintMap)});
            this.biPrint.Name = "biPrint";
            // 
            // biPrintPivot
            // 
            this.biPrintPivot.Appearance.Options.UseFont = true;
            this.biPrintPivot.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biPrintPivot, "biPrintPivot");
            this.biPrintPivot.Id = 13;
            this.biPrintPivot.ImageIndex = 25;
            this.biPrintPivot.Name = "biPrintPivot";
            this.biPrintPivot.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biPrintPivot_ItemClick);
            // 
            // biPrintChart
            // 
            this.biPrintChart.Appearance.Options.UseFont = true;
            this.biPrintChart.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biPrintChart, "biPrintChart");
            this.biPrintChart.Glyph = ((System.Drawing.Image)(resources.GetObject("biPrintChart.Glyph")));
            this.biPrintChart.Id = 14;
            this.biPrintChart.ImageIndex = 41;
            this.biPrintChart.Name = "biPrintChart";
            this.biPrintChart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biPrintChart_ItemClick);
            // 
            // biPrintMap
            // 
            this.biPrintMap.Appearance.Options.UseFont = true;
            this.biPrintMap.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biPrintMap, "biPrintMap");
            this.biPrintMap.Id = 15;
            this.biPrintMap.ImageIndex = 40;
            this.biPrintMap.Name = "biPrintMap";
            this.biPrintMap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biPrintMap_ItemClick);
            // 
            // biExport
            // 
            this.biExport.Appearance.Options.UseFont = true;
            this.biExport.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biExport, "biExport");
            this.biExport.Id = 30;
            this.biExport.ImageIndex = 39;
            this.biExport.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biExportReport),
            new DevExpress.XtraBars.LinkPersistInfo(this.biExportChart),
            new DevExpress.XtraBars.LinkPersistInfo(this.biExportMapToImage),
            new DevExpress.XtraBars.LinkPersistInfo(this.biExportDataToAccess)});
            this.biExport.Name = "biExport";
            // 
            // biExportReport
            // 
            this.biExportReport.Appearance.Options.UseFont = true;
            this.biExportReport.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biExportReport, "biExportReport");
            this.biExportReport.Id = 32;
            this.biExportReport.ImageIndex = 25;
            this.biExportReport.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biExportReportToExcel),
            new DevExpress.XtraBars.LinkPersistInfo(this.biExportReportToRtf),
            new DevExpress.XtraBars.LinkPersistInfo(this.biExportReportToPdf),
            new DevExpress.XtraBars.LinkPersistInfo(this.biExportReportToHtml),
            new DevExpress.XtraBars.LinkPersistInfo(this.biExportReportToImage)});
            this.biExportReport.Name = "biExportReport";
            // 
            // biExportReportToExcel
            // 
            this.biExportReportToExcel.Appearance.Options.UseFont = true;
            this.biExportReportToExcel.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biExportReportToExcel, "biExportReportToExcel");
            this.biExportReportToExcel.Id = 39;
            this.biExportReportToExcel.ImageIndex = 46;
            this.biExportReportToExcel.Name = "biExportReportToExcel";
            this.biExportReportToExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biExportReportToExcel_ItemClick);
            // 
            // biExportReportToRtf
            // 
            this.biExportReportToRtf.Appearance.Options.UseFont = true;
            this.biExportReportToRtf.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biExportReportToRtf, "biExportReportToRtf");
            this.biExportReportToRtf.Id = 40;
            this.biExportReportToRtf.ImageIndex = 47;
            this.biExportReportToRtf.Name = "biExportReportToRtf";
            this.biExportReportToRtf.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biExportReportToRtf_ItemClick);
            // 
            // biExportReportToPdf
            // 
            this.biExportReportToPdf.Appearance.Options.UseFont = true;
            this.biExportReportToPdf.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biExportReportToPdf, "biExportReportToPdf");
            this.biExportReportToPdf.Id = 41;
            this.biExportReportToPdf.ImageIndex = 48;
            this.biExportReportToPdf.Name = "biExportReportToPdf";
            this.biExportReportToPdf.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biExportReportToPdf_ItemClick);
            // 
            // biExportReportToHtml
            // 
            this.biExportReportToHtml.Appearance.Options.UseFont = true;
            this.biExportReportToHtml.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biExportReportToHtml, "biExportReportToHtml");
            this.biExportReportToHtml.Id = 42;
            this.biExportReportToHtml.ImageIndex = 49;
            this.biExportReportToHtml.Name = "biExportReportToHtml";
            this.biExportReportToHtml.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.biExportReportToHtml.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biExportReportToHtml_ItemClick);
            // 
            // biExportReportToImage
            // 
            resources.ApplyResources(this.biExportReportToImage, "biExportReportToImage");
            this.biExportReportToImage.Id = 60;
            this.biExportReportToImage.ImageIndex = 50;
            this.biExportReportToImage.Name = "biExportReportToImage";
            this.biExportReportToImage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biExportReportToImage_ItemClick);
            // 
            // biExportChart
            // 
            this.biExportChart.Appearance.Options.UseFont = true;
            this.biExportChart.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biExportChart, "biExportChart");
            this.biExportChart.Id = 33;
            this.biExportChart.ImageIndex = 41;
            this.biExportChart.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biExportChartToExcel),
            new DevExpress.XtraBars.LinkPersistInfo(this.biExportChartToImage),
            new DevExpress.XtraBars.LinkPersistInfo(this.biExportChartToPdf),
            new DevExpress.XtraBars.LinkPersistInfo(this.biExportChartToHtml)});
            this.biExportChart.Name = "biExportChart";
            // 
            // biExportChartToExcel
            // 
            this.biExportChartToExcel.Appearance.Options.UseFont = true;
            this.biExportChartToExcel.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biExportChartToExcel, "biExportChartToExcel");
            this.biExportChartToExcel.Id = 34;
            this.biExportChartToExcel.ImageIndex = 46;
            this.biExportChartToExcel.Name = "biExportChartToExcel";
            this.biExportChartToExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biExportChartToExcel_ItemClick);
            // 
            // biExportChartToImage
            // 
            this.biExportChartToImage.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.biExportChartToImage, "biExportChartToImage");
            this.biExportChartToImage.Id = 36;
            this.biExportChartToImage.ImageIndex = 50;
            this.biExportChartToImage.Name = "biExportChartToImage";
            this.biExportChartToImage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biExportChartToImage_ItemClick);
            // 
            // biExportChartToPdf
            // 
            this.biExportChartToPdf.Appearance.Options.UseFont = true;
            this.biExportChartToPdf.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biExportChartToPdf, "biExportChartToPdf");
            this.biExportChartToPdf.Id = 38;
            this.biExportChartToPdf.ImageIndex = 48;
            this.biExportChartToPdf.Name = "biExportChartToPdf";
            this.biExportChartToPdf.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biExportChartToPdf_ItemClick);
            // 
            // biExportChartToHtml
            // 
            this.biExportChartToHtml.Appearance.Options.UseFont = true;
            this.biExportChartToHtml.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biExportChartToHtml, "biExportChartToHtml");
            this.biExportChartToHtml.Id = 37;
            this.biExportChartToHtml.ImageIndex = 49;
            this.biExportChartToHtml.Name = "biExportChartToHtml";
            this.biExportChartToHtml.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.biExportChartToHtml.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biExportChartToHtml_ItemClick);
            // 
            // biExportMapToImage
            // 
            this.biExportMapToImage.Appearance.Options.UseFont = true;
            this.biExportMapToImage.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biExportMapToImage, "biExportMapToImage");
            this.biExportMapToImage.Id = 58;
            this.biExportMapToImage.ImageIndex = 40;
            this.biExportMapToImage.Name = "biExportMapToImage";
            this.biExportMapToImage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biExportMapToImage_ItemClick);
            // 
            // biExportDataToAccess
            // 
            this.biExportDataToAccess.Appearance.Options.UseFont = true;
            this.biExportDataToAccess.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biExportDataToAccess, "biExportDataToAccess");
            this.biExportDataToAccess.Enabled = false;
            this.biExportDataToAccess.Id = 31;
            this.biExportDataToAccess.ImageIndex = 52;
            this.biExportDataToAccess.Name = "biExportDataToAccess";
            this.biExportDataToAccess.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biExportDataToAccess_ItemClick);
            // 
            // biExit
            // 
            this.biExit.Appearance.Options.UseFont = true;
            this.biExit.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biExit, "biExit");
            this.biExit.Id = 12;
            this.biExit.ImageIndex = 53;
            this.biExit.Name = "biExit";
            this.biExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biClose_ItemClick);
            // 
            // biView
            // 
            this.biView.Appearance.Options.UseFont = true;
            this.biView.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biView, "biView");
            this.biView.Id = 1;
            this.biView.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biReportView),
            new DevExpress.XtraBars.LinkPersistInfo(this.biShowAll),
            new DevExpress.XtraBars.LinkPersistInfo(this.biShowToolBar)});
            this.biView.Name = "biView";
            // 
            // biReportView
            // 
            this.biReportView.Appearance.Options.UseFont = true;
            this.biReportView.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biReportView, "biReportView");
            this.biReportView.Id = 25;
            this.biReportView.Name = "biReportView";
            this.biReportView.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.biReportView_CheckedChanged);
            // 
            // biShowAll
            // 
            this.biShowAll.Appearance.Options.UseFont = true;
            this.biShowAll.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biShowAll, "biShowAll");
            this.biShowAll.Checked = true;
            this.biShowAll.Id = 26;
            this.biShowAll.Name = "biShowAll";
            this.biShowAll.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.biPredefined_CheckedChanged);
            // 
            // biShowToolBar
            // 
            this.biShowToolBar.Appearance.Options.UseFont = true;
            this.biShowToolBar.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biShowToolBar, "biShowToolBar");
            this.biShowToolBar.Checked = true;
            this.biShowToolBar.Id = 55;
            this.biShowToolBar.Name = "biShowToolBar";
            this.biShowToolBar.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.biShowToolBar_CheckedChanged);
            // 
            // biQuery
            // 
            this.biQuery.Appearance.Options.UseFont = true;
            this.biQuery.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biQuery, "biQuery");
            this.biQuery.Id = 9;
            this.biQuery.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biNewQuery),
            new DevExpress.XtraBars.LinkPersistInfo(this.biEditQuery),
            new DevExpress.XtraBars.LinkPersistInfo(this.biDeleteQuery)});
            this.biQuery.Name = "biQuery";
            // 
            // biNewQuery
            // 
            this.biNewQuery.Appearance.Options.UseFont = true;
            this.biNewQuery.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biNewQuery, "biNewQuery");
            this.biNewQuery.Id = 16;
            this.biNewQuery.ImageIndex = 32;
            this.biNewQuery.Name = "biNewQuery";
            this.biNewQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biNewQuery_ItemClick);
            // 
            // biEditQuery
            // 
            this.biEditQuery.Appearance.Options.UseFont = true;
            this.biEditQuery.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biEditQuery, "biEditQuery");
            this.biEditQuery.Id = 17;
            this.biEditQuery.ImageIndex = 31;
            this.biEditQuery.Name = "biEditQuery";
            this.biEditQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biEditQuery_ItemClick);
            // 
            // biDeleteQuery
            // 
            this.biDeleteQuery.Appearance.Options.UseFont = true;
            this.biDeleteQuery.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biDeleteQuery, "biDeleteQuery");
            this.biDeleteQuery.Id = 18;
            this.biDeleteQuery.ImageIndex = 30;
            this.biDeleteQuery.Name = "biDeleteQuery";
            this.biDeleteQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biDeleteQuery_ItemClick);
            // 
            // biLayout
            // 
            this.biLayout.Appearance.Options.UseFont = true;
            this.biLayout.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biLayout, "biLayout");
            this.biLayout.Id = 10;
            this.biLayout.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biCancelChanges),
            new DevExpress.XtraBars.LinkPersistInfo(this.biCopyLayout),
            new DevExpress.XtraBars.LinkPersistInfo(this.biNewLayout),
            new DevExpress.XtraBars.LinkPersistInfo(this.biDeleteLayout),
            new DevExpress.XtraBars.LinkPersistInfo(this.biSaveLayout),
            new DevExpress.XtraBars.LinkPersistInfo(this.biPublishLayout)});
            this.biLayout.Name = "biLayout";
            // 
            // biCancelChanges
            // 
            this.biCancelChanges.Appearance.Options.UseFont = true;
            this.biCancelChanges.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biCancelChanges, "biCancelChanges");
            this.biCancelChanges.Id = 56;
            this.biCancelChanges.ImageIndex = 36;
            this.biCancelChanges.Name = "biCancelChanges";
            this.biCancelChanges.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biCancelChanges_ItemClick);
            // 
            // biCopyLayout
            // 
            this.biCopyLayout.Appearance.Options.UseFont = true;
            this.biCopyLayout.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biCopyLayout, "biCopyLayout");
            this.biCopyLayout.Id = 21;
            this.biCopyLayout.ImageIndex = 35;
            this.biCopyLayout.Name = "biCopyLayout";
            this.biCopyLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biCopyLayout_ItemClick);
            // 
            // biNewLayout
            // 
            this.biNewLayout.Appearance.Options.UseFont = true;
            this.biNewLayout.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biNewLayout, "biNewLayout");
            this.biNewLayout.Id = 22;
            this.biNewLayout.ImageIndex = 26;
            this.biNewLayout.Name = "biNewLayout";
            this.biNewLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biNewLayout_ItemClick);
            // 
            // biDeleteLayout
            // 
            this.biDeleteLayout.Appearance.Options.UseFont = true;
            this.biDeleteLayout.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biDeleteLayout, "biDeleteLayout");
            this.biDeleteLayout.Id = 23;
            this.biDeleteLayout.ImageIndex = 27;
            this.biDeleteLayout.Name = "biDeleteLayout";
            this.biDeleteLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biDeleteLayout_ItemClick);
            // 
            // biSaveLayout
            // 
            this.biSaveLayout.Appearance.Options.UseFont = true;
            this.biSaveLayout.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biSaveLayout, "biSaveLayout");
            this.biSaveLayout.Id = 57;
            this.biSaveLayout.ImageIndex = 29;
            this.biSaveLayout.Name = "biSaveLayout";
            this.biSaveLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biSaveLayout_ItemClick);
            // 
            // biPublishLayout
            // 
            this.biPublishLayout.Appearance.Options.UseFont = true;
            this.biPublishLayout.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biPublishLayout, "biPublishLayout");
            this.biPublishLayout.Id = 59;
            this.biPublishLayout.ImageIndex = 57;
            this.biPublishLayout.Name = "biPublishLayout";
            this.biPublishLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biPublishLayout_ItemClick);
            // 
            // biHelp
            // 
            this.biHelp.Appearance.Options.UseFont = true;
            this.biHelp.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biHelp, "biHelp");
            this.biHelp.Id = 27;
            this.biHelp.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biInternalHelp)});
            this.biHelp.Name = "biHelp";
            // 
            // biInternalHelp
            // 
            this.biInternalHelp.Appearance.Options.UseFont = true;
            this.biInternalHelp.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.biInternalHelp, "biInternalHelp");
            this.biInternalHelp.Id = 28;
            this.biInternalHelp.ImageIndex = 58;
            this.biInternalHelp.Name = "biInternalHelp";
            this.biInternalHelp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biInternalHelp_ItemClick);
            // 
            // barStatus
            // 
            this.barStatus.BarName = "Status bar";
            this.barStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.barStatus.DockCol = 0;
            this.barStatus.DockRow = 0;
            this.barStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barStatus.OptionsBar.AllowQuickCustomization = false;
            this.barStatus.OptionsBar.DrawDragBorder = false;
            this.barStatus.OptionsBar.UseWholeRow = true;
            resources.ApplyResources(this.barStatus, "barStatus");
            this.barStatus.Visible = false;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Appearance.Options.UseFont = true;
            this.barDockControlTop.CausesValidation = false;
            resources.ApplyResources(this.barDockControlTop, "barDockControlTop");
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Appearance.Options.UseFont = true;
            this.barDockControlBottom.CausesValidation = false;
            resources.ApplyResources(this.barDockControlBottom, "barDockControlBottom");
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Appearance.Options.UseFont = true;
            this.barDockControlLeft.CausesValidation = false;
            resources.ApplyResources(this.barDockControlLeft, "barDockControlLeft");
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Appearance.Options.UseFont = true;
            this.barDockControlRight.CausesValidation = false;
            resources.ApplyResources(this.barDockControlRight, "barDockControlRight");
            // 
            // imageCollectionToolBar
            // 
            this.imageCollectionToolBar.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollectionToolBar.ImageStream")));
            this.imageCollectionToolBar.Images.SetKeyName(0, "deleted.gif");
            this.imageCollectionToolBar.Images.SetKeyName(1, "gvDragAndDropHideColumn.gif");
            this.imageCollectionToolBar.Images.SetKeyName(2, "smokeandglass_help.gif");
            this.imageCollectionToolBar.Images.SetKeyName(3, "printers.gif");
            this.imageCollectionToolBar.Images.SetKeyName(4, "sql.gif");
            this.imageCollectionToolBar.Images.SetKeyName(5, "Table.gif");
            this.imageCollectionToolBar.Images.SetKeyName(6, "undo1.png");
            this.imageCollectionToolBar.Images.SetKeyName(7, "undo.gif");
            this.imageCollectionToolBar.Images.SetKeyName(8, "save.png");
            this.imageCollectionToolBar.Images.SetKeyName(9, "Copy Icon.jpg");
            this.imageCollectionToolBar.Images.SetKeyName(10, "48px-Edit-copy_purple-wikis.svg.png");
            this.imageCollectionToolBar.Images.SetKeyName(11, "icon_copy.gif");
            this.imageCollectionToolBar.Images.SetKeyName(12, "Help-Icon-16-3.gif");
            this.imageCollectionToolBar.Images.SetKeyName(13, "help_icon.png");
            this.imageCollectionToolBar.Images.SetKeyName(14, "am-table.gif");
            this.imageCollectionToolBar.Images.SetKeyName(15, "checkBoxIcon.gif");
            this.imageCollectionToolBar.Images.SetKeyName(16, "sql_sql_icon.gif");
            this.imageCollectionToolBar.Images.SetKeyName(17, "query_icon2.gif");
            this.imageCollectionToolBar.Images.SetKeyName(18, "MySQL-Query-Analyzer.icon.gif");
            this.imageCollectionToolBar.Images.SetKeyName(19, "DTM-Query-Reporter.icon.gif");
            this.imageCollectionToolBar.Images.SetKeyName(20, "createquery_icon.gif");
            this.imageCollectionToolBar.Images.SetKeyName(21, "LargeEdit.icon.gif");
            this.imageCollectionToolBar.Images.SetKeyName(22, "sql11.jpg");
            this.imageCollectionToolBar.Images.SetKeyName(23, "tbl_table_32.png");
            this.imageCollectionToolBar.Images.SetKeyName(24, "insert-table.png");
            this.imageCollectionToolBar.Images.SetKeyName(25, "am-table_small.GIF");
            this.imageCollectionToolBar.Images.SetKeyName(26, "am-table_small.bmp");
            this.imageCollectionToolBar.Images.SetKeyName(27, "layout_deleted.bmp");
            this.imageCollectionToolBar.Images.SetKeyName(28, "layout_save.bmp");
            this.imageCollectionToolBar.Images.SetKeyName(29, "layout_save_1.bmp");
            this.imageCollectionToolBar.Images.SetKeyName(30, "query_deleted.ico");
            this.imageCollectionToolBar.Images.SetKeyName(31, "query_edit.ico");
            this.imageCollectionToolBar.Images.SetKeyName(32, "query_new.ico");
            this.imageCollectionToolBar.Images.SetKeyName(33, "print.ico");
            this.imageCollectionToolBar.Images.SetKeyName(34, "layout_undo2.ico");
            this.imageCollectionToolBar.Images.SetKeyName(35, "query_copy.ico");
            this.imageCollectionToolBar.Images.SetKeyName(36, "layout_undo3.ico");
            this.imageCollectionToolBar.Images.SetKeyName(37, "chart_1.ico");
            this.imageCollectionToolBar.Images.SetKeyName(38, "chart_2.ico");
            this.imageCollectionToolBar.Images.SetKeyName(39, "export.ico");
            this.imageCollectionToolBar.Images.SetKeyName(40, "earth.ico");
            this.imageCollectionToolBar.Images.SetKeyName(41, "chart_3.ico");
            this.imageCollectionToolBar.Images.SetKeyName(42, "icon_eye3.ico");
            this.imageCollectionToolBar.Images.SetKeyName(43, "icon-eye.gif");
            this.imageCollectionToolBar.Images.SetKeyName(44, "icon-eye.ico");
            this.imageCollectionToolBar.Images.SetKeyName(45, "help.ico");
            this.imageCollectionToolBar.Images.SetKeyName(46, "excel.ico");
            this.imageCollectionToolBar.Images.SetKeyName(47, "rtf.ico");
            this.imageCollectionToolBar.Images.SetKeyName(48, "pdf.ico");
            this.imageCollectionToolBar.Images.SetKeyName(49, "html.ico");
            this.imageCollectionToolBar.Images.SetKeyName(50, "jpeg.ico");
            this.imageCollectionToolBar.Images.SetKeyName(51, "access.ico");
            this.imageCollectionToolBar.Images.SetKeyName(52, "AccessIcon.ico");
            this.imageCollectionToolBar.Images.SetKeyName(53, "close.ico");
            this.imageCollectionToolBar.Images.SetKeyName(54, "check_icon3.ico");
            this.imageCollectionToolBar.Images.SetKeyName(55, "check_icon5.ico");
            this.imageCollectionToolBar.Images.SetKeyName(56, "check_icon4.ico");
            this.imageCollectionToolBar.Images.SetKeyName(57, "edit_publish.png");
            // 
            // bbSaveLayout
            // 
            this.bbSaveLayout.Appearance.Options.UseFont = true;
            this.bbSaveLayout.AppearanceDisabled.Options.UseFont = true;
            resources.ApplyResources(this.bbSaveLayout, "bbSaveLayout");
            this.bbSaveLayout.Id = 51;
            this.bbSaveLayout.ImageIndex = 29;
            this.bbSaveLayout.Name = "bbSaveLayout";
            this.bbSaveLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbSaveLayout_ItemClick);
            // 
            // bbEditCaption
            // 
            resources.ApplyResources(this.bbEditCaption, "bbEditCaption");
            this.bbEditCaption.Id = 61;
            this.bbEditCaption.Name = "bbEditCaption";
            this.bbEditCaption.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbEditCaption_ItemClick);
            // 
            // PivotPopupMenu
            // 
            this.PivotPopupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbEditCaption)});
            this.PivotPopupMenu.Manager = this.barManager;
            this.PivotPopupMenu.Name = "PivotPopupMenu";
            // 
            // RamForm
            // 
            this.Appearance.Options.UseFont = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grcMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormID = "R01";
            this.HelpTopicID = "AVR_Getting_Started";
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "RamForm";
            this.Sizable = true;
            this.Load += new System.EventHandler(this.AVRReportControl_Load);
            this.Controls.SetChildIndex(this.barDockControlTop, 0);
            this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            this.Controls.SetChildIndex(this.barDockControlRight, 0);
            this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.grcMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grcMain)).EndInit();
            this.grcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcBottom)).EndInit();
            this.grcBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nbControlQueryLayout)).EndInit();
            this.nbControlQueryLayout.ResumeLayout(false);
            this.nbContainerQueryLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcTop)).EndInit();
            this.grcTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcLayout)).EndInit();
            this.grcLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcQueryBuilder)).EndInit();
            this.grcQueryBuilder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionToolBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PivotPopupMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grcMain;
        private DevExpress.XtraEditors.GroupControl grcBottom;
        private DevExpress.XtraEditors.GroupControl grcTop;
        private DevExpress.XtraEditors.GroupControl grcQueryBuilder;
        private EIDSS.RAM.QueryBuilder.QueryInfo queryInfo;
        private DevExpress.XtraEditors.SplitterControl splitterControl2;
        private LayoutInfo layoutInfo;
        private DevExpress.XtraEditors.GroupControl grcLayout;
        private LayoutDetail layoutDetail;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barTools;
        private DevExpress.XtraBars.Bar barMenu;
        private DevExpress.XtraBars.BarSubItem biFile;
        private DevExpress.XtraBars.BarSubItem biView;
        private DevExpress.XtraBars.Bar barStatus;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarSubItem biPrint;
        private DevExpress.XtraBars.BarSubItem biQuery;
        private DevExpress.XtraBars.BarSubItem biLayout;
        private DevExpress.XtraBars.BarButtonItem biExit;
        private DevExpress.XtraBars.BarButtonItem biPrintPivot;
        private DevExpress.XtraBars.BarButtonItem biPrintChart;
        private DevExpress.XtraBars.BarButtonItem biPrintMap;
        private DevExpress.XtraBars.BarButtonItem biNewQuery;
        private DevExpress.XtraBars.BarButtonItem biEditQuery;
        private DevExpress.XtraBars.BarButtonItem biDeleteQuery;
        private DevExpress.XtraBars.BarButtonItem biCopyLayout;
        private DevExpress.XtraBars.BarButtonItem biNewLayout;
        private DevExpress.XtraBars.BarButtonItem biDeleteLayout;
        private DevExpress.XtraBars.BarCheckItem biReportView;
        private DevExpress.XtraBars.BarCheckItem biShowAll;
        private DevExpress.XtraBars.BarSubItem biHelp;
        private DevExpress.XtraBars.BarButtonItem biInternalHelp;
        private DevExpress.XtraNavBar.NavBarControl nbControlQueryLayout;
        private DevExpress.XtraNavBar.NavBarGroup nbGroupQueryLayout;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer nbContainerQueryLayout;
        private DevExpress.XtraBars.BarSubItem biExport;
        private DevExpress.XtraBars.BarButtonItem biExportDataToAccess;
        private DevExpress.XtraBars.BarSubItem biExportReport;
        private DevExpress.XtraBars.BarSubItem biExportChart;
        private DevExpress.XtraBars.BarButtonItem biExportChartToExcel;
        private DevExpress.XtraBars.BarButtonItem biExportChartToImage;
        private DevExpress.XtraBars.BarButtonItem biExportChartToHtml;
        private DevExpress.XtraBars.BarButtonItem biExportChartToPdf;
        private DevExpress.XtraBars.BarButtonItem biExportReportToExcel;
        private DevExpress.XtraBars.BarButtonItem biExportReportToRtf;
        private DevExpress.XtraBars.BarButtonItem biExportReportToPdf;
        private DevExpress.XtraBars.BarButtonItem biExportReportToHtml;
        private DevExpress.XtraBars.BarButtonItem bbNewQuery;
        private DevExpress.XtraBars.BarButtonItem bbEditQuery;
        private DevExpress.XtraBars.BarButtonItem bbDeleteQuery;
        private DevExpress.XtraBars.BarButtonItem bbCancelChanges;
        private DevExpress.XtraBars.BarButtonItem bbCopyLayout;
        private DevExpress.XtraBars.BarButtonItem bbNewLayout;
        private DevExpress.XtraBars.BarButtonItem bbDeleteLayout;
        private DevExpress.XtraBars.BarButtonItem bbSaveLayout;
        private DevExpress.XtraBars.BarButtonItem bbShowAll;
        private DevExpress.XtraBars.BarButtonItem bbPrint;
        private DevExpress.XtraBars.BarButtonItem bbHelp;
        private DevExpress.Utils.ImageCollection imageCollectionToolBar;
        private DevExpress.XtraBars.BarCheckItem biShowToolBar;
        private DevExpress.XtraBars.BarButtonItem biCancelChanges;
        private DevExpress.XtraBars.BarButtonItem biSaveLayout;
        private DevExpress.XtraBars.BarButtonItem biExportMapToImage;
        private DevExpress.XtraBars.BarButtonItem biPublishLayout;
        private DevExpress.XtraBars.BarButtonItem biExportReportToImage;
        private DevExpress.XtraBars.PopupMenu PivotPopupMenu;
        private DevExpress.XtraBars.BarButtonItem bbEditCaption;


    }
}
