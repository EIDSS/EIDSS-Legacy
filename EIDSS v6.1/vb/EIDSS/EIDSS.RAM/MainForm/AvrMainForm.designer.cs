
using eidss.avr.LayoutForm;
using eidss.avr.QueryLayoutTree;

namespace eidss.avr.MainForm
{
    partial class AvrMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AvrMainForm));
            this.QueryLayoutTree = new eidss.avr.QueryLayoutTree.QueryLayoutTreePanel();
            this.barManager = new DevExpress.XtraBars.BarManager();
            this.barTools = new DevExpress.XtraBars.Bar();
            this.bbNewQuery = new DevExpress.XtraBars.BarButtonItem();
            this.bbNewLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbNewFolder = new DevExpress.XtraBars.BarButtonItem();
            this.bbEditQueryLayoutFolder = new DevExpress.XtraBars.BarButtonItem();
            this.bbViewQueryLayoutFolder = new DevExpress.XtraBars.BarButtonItem();
            this.bbDeleteQueryLayoutFolder = new DevExpress.XtraBars.BarButtonItem();
            this.bbCopyQueryLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbHelp = new DevExpress.XtraBars.BarButtonItem();
            this.barMenu = new DevExpress.XtraBars.Bar();
            this.biFile = new DevExpress.XtraBars.BarSubItem();
            this.biNewQuery = new DevExpress.XtraBars.BarButtonItem();
            this.biNewLayout = new DevExpress.XtraBars.BarButtonItem();
            this.biNewFolder = new DevExpress.XtraBars.BarButtonItem();
            this.biEditQueryLayoutFolder = new DevExpress.XtraBars.BarButtonItem();
            this.biViewQueryLayoutFolder = new DevExpress.XtraBars.BarButtonItem();
            this.biDeleteQueryLayoutFolder = new DevExpress.XtraBars.BarButtonItem();
            this.biCopyQueryLayout = new DevExpress.XtraBars.BarButtonItem();
            this.biPublishQueryLayoutFolder = new DevExpress.XtraBars.BarButtonItem();
            this.biUnpublishQueryLayoutFolder = new DevExpress.XtraBars.BarButtonItem();
            this.biExit = new DevExpress.XtraBars.BarButtonItem();
            this.biExport = new DevExpress.XtraBars.BarSubItem();
            this.biExportReport = new DevExpress.XtraBars.BarSubItem();
            this.biExportReportToXls = new DevExpress.XtraBars.BarButtonItem();
            this.biExportReportToXlsx = new DevExpress.XtraBars.BarButtonItem();
            this.biExportReportToRtf = new DevExpress.XtraBars.BarButtonItem();
            this.biExportReportToPdf = new DevExpress.XtraBars.BarButtonItem();
            this.biExportReportToImage = new DevExpress.XtraBars.BarButtonItem();
            this.biExportQuery = new DevExpress.XtraBars.BarSubItem();
            this.biExportQueryLineListToXls = new DevExpress.XtraBars.BarButtonItem();
            this.biExportQueryLineListToXlsx = new DevExpress.XtraBars.BarButtonItem();
            this.biExportQueryLineListToMdb = new DevExpress.XtraBars.BarButtonItem();
            this.biPrint = new DevExpress.XtraBars.BarSubItem();
            this.biPrintReport = new DevExpress.XtraBars.BarButtonItem();
            this.biOptions = new DevExpress.XtraBars.BarSubItem();
            this.biShowToolBar = new DevExpress.XtraBars.BarCheckItem();
            this.biSettings = new DevExpress.XtraBars.BarButtonItem();
            this.biHelp = new DevExpress.XtraBars.BarSubItem();
            this.biInternalHelp = new DevExpress.XtraBars.BarButtonItem();
            this.barStatus = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageCollectionToolBar = new DevExpress.Utils.ImageCollection();
            this.bbEditCaption = new DevExpress.XtraBars.BarButtonItem();
            this.bbCopyField = new DevExpress.XtraBars.BarButtonItem();
            this.bbDeleteCopyField = new DevExpress.XtraBars.BarButtonItem();
            this.bbAddMissedValues = new DevExpress.XtraBars.BarButtonItem();
            this.bbDeleteMissedValues = new DevExpress.XtraBars.BarButtonItem();
            this.bsGroupDate = new DevExpress.XtraBars.BarSubItem();
            this.bcGroupDate_0 = new DevExpress.XtraBars.BarCheckItem();
            this.bbPopupNewQuery = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.bbPopupNewLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbPopupNewFolder = new DevExpress.XtraBars.BarButtonItem();
            this.bbPopupEditQueryLayoutFolder = new DevExpress.XtraBars.BarButtonItem();
            this.bbPopupDeleteQueryLayoutFolder = new DevExpress.XtraBars.BarButtonItem();
            this.bbPopupCopyQueryLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbEditMissedValues = new DevExpress.XtraBars.BarButtonItem();
            this.bbPopupViewQueryLayoutFolder = new DevExpress.XtraBars.BarButtonItem();
            this.PivotPopupMenu = new DevExpress.XtraBars.PopupMenu();
            this.DeleteQueryLayoutTimer = new System.Windows.Forms.Timer();
            this.CloseQueryLayoutTimer = new System.Windows.Forms.Timer();
            this.CopyLayoutTimer = new System.Windows.Forms.Timer();
            this.NewLayoutTimer = new System.Windows.Forms.Timer();
            this.CloseTimer = new System.Windows.Forms.Timer();
            this.TabControl = new DevExpress.XtraTab.XtraTabControl();
            this.TabPageTree = new DevExpress.XtraTab.XtraTabPage();
            this.TabPageEditor = new DevExpress.XtraTab.XtraTabPage();
            this.EditorPanel = new DevExpress.XtraEditors.PanelControl();
            this.TreePopupMenu = new DevExpress.XtraBars.PopupMenu();
            this.bbRefreshData = new DevExpress.XtraBars.BarButtonItem();
            this.biRefreshData = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionToolBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PivotPopupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabControl)).BeginInit();
            this.TabControl.SuspendLayout();
            this.TabPageTree.SuspendLayout();
            this.TabPageEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EditorPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TreePopupMenu)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(AvrMainForm), out resources);
            // Form Is Localizable: True
            // 
            // QueryLayoutTree
            // 
            resources.ApplyResources(this.QueryLayoutTree, "QueryLayoutTree");
            this.QueryLayoutTree.FormID = null;
            this.QueryLayoutTree.HelpTopicID = null;
            this.QueryLayoutTree.KeyFieldName = null;
            this.QueryLayoutTree.MultiSelect = false;
            this.QueryLayoutTree.Name = "QueryLayoutTree";
            this.QueryLayoutTree.ObjectName = null;
            this.QueryLayoutTree.TableName = null;
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
            this.biNewQuery,
            this.biEditQueryLayoutFolder,
            this.biCopyQueryLayout,
            this.biNewLayout,
            this.biDeleteQueryLayoutFolder,
            this.biHelp,
            this.biInternalHelp,
            this.biExportReport,
            this.biExportReportToXls,
            this.biExportReportToRtf,
            this.biExportReportToPdf,
            this.bbNewQuery,
            this.bbEditQueryLayoutFolder,
            this.bbDeleteQueryLayoutFolder,
            this.bbNewLayout,
            this.bbCopyQueryLayout,
            this.bbHelp,
            this.biShowToolBar,
            this.biPublishQueryLayoutFolder,
            this.biExportReportToImage,
            this.bbEditCaption,
            this.biNewFolder,
            this.biUnpublishQueryLayoutFolder,
            this.biOptions,
            this.biExport,
            this.biPrint,
            this.biSettings,
            this.bbNewFolder,
            this.bbCopyField,
            this.bbDeleteCopyField,
            this.bbAddMissedValues,
            this.bbDeleteMissedValues,
            this.bsGroupDate,
            this.bcGroupDate_0,
            this.biExportQueryLineListToXls,
            this.biPrintReport,
            this.biExportReportToXlsx,
            this.biExportQuery,
            this.biExportQueryLineListToXlsx,
            this.biExportQueryLineListToMdb,
            this.biExit,
            this.bbPopupNewQuery,
            this.barButtonItem1,
            this.bbPopupNewLayout,
            this.bbPopupNewFolder,
            this.bbPopupEditQueryLayoutFolder,
            this.bbPopupDeleteQueryLayoutFolder,
            this.bbPopupCopyQueryLayout,
            this.bbEditMissedValues,
            this.biViewQueryLayoutFolder,
            this.bbPopupViewQueryLayoutFolder,
            this.bbViewQueryLayoutFolder,
            this.bbRefreshData,
            this.biRefreshData});
            this.barManager.MainMenu = this.barMenu;
            this.barManager.MaxItemId = 99;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.bbNewLayout),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbNewFolder),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbEditQueryLayoutFolder, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbViewQueryLayoutFolder, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbDeleteQueryLayoutFolder),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbCopyQueryLayout),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbHelp, true)});
            this.barTools.OptionsBar.AllowQuickCustomization = false;
            this.barTools.OptionsBar.DisableClose = true;
            this.barTools.OptionsBar.DisableCustomization = true;
            this.barTools.OptionsBar.DrawDragBorder = false;
            resources.ApplyResources(this.barTools, "barTools");
            // 
            // bbNewQuery
            // 
            resources.ApplyResources(this.bbNewQuery, "bbNewQuery");
            this.bbNewQuery.Id = 44;
            this.bbNewQuery.ImageIndex = 32;
            this.bbNewQuery.ItemAppearance.Disabled.Options.UseFont = true;
            this.bbNewQuery.ItemAppearance.Normal.Options.UseFont = true;
            this.bbNewQuery.Name = "bbNewQuery";
            this.bbNewQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbNewQuery_ItemClick);
            // 
            // bbNewLayout
            // 
            resources.ApplyResources(this.bbNewLayout, "bbNewLayout");
            this.bbNewLayout.Enabled = false;
            this.bbNewLayout.Id = 47;
            this.bbNewLayout.ImageIndex = 70;
            this.bbNewLayout.ItemAppearance.Disabled.Options.UseFont = true;
            this.bbNewLayout.ItemAppearance.Normal.Options.UseFont = true;
            this.bbNewLayout.Name = "bbNewLayout";
            this.bbNewLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbNewLayout_ItemClick);
            // 
            // bbNewFolder
            // 
            resources.ApplyResources(this.bbNewFolder, "bbNewFolder");
            this.bbNewFolder.Enabled = false;
            this.bbNewFolder.Id = 71;
            this.bbNewFolder.ImageIndex = 71;
            this.bbNewFolder.Name = "bbNewFolder";
            this.bbNewFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbNewFolder_ItemClick);
            // 
            // bbEditQueryLayoutFolder
            // 
            resources.ApplyResources(this.bbEditQueryLayoutFolder, "bbEditQueryLayoutFolder");
            this.bbEditQueryLayoutFolder.Id = 45;
            this.bbEditQueryLayoutFolder.ImageIndex = 59;
            this.bbEditQueryLayoutFolder.ItemAppearance.Disabled.Options.UseFont = true;
            this.bbEditQueryLayoutFolder.ItemAppearance.Normal.Options.UseFont = true;
            this.bbEditQueryLayoutFolder.Name = "bbEditQueryLayoutFolder";
            this.bbEditQueryLayoutFolder.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbEditQueryLayoutFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbEditQueryLayoutFolder_ItemClick);
            // 
            // bbViewQueryLayoutFolder
            // 
            resources.ApplyResources(this.bbViewQueryLayoutFolder, "bbViewQueryLayoutFolder");
            this.bbViewQueryLayoutFolder.Id = 96;
            this.bbViewQueryLayoutFolder.ImageIndex = 42;
            this.bbViewQueryLayoutFolder.Name = "bbViewQueryLayoutFolder";
            this.bbViewQueryLayoutFolder.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbViewQueryLayoutFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbViewQueryLayoutFolder_ItemClick);
            // 
            // bbDeleteQueryLayoutFolder
            // 
            resources.ApplyResources(this.bbDeleteQueryLayoutFolder, "bbDeleteQueryLayoutFolder");
            this.bbDeleteQueryLayoutFolder.Enabled = false;
            this.bbDeleteQueryLayoutFolder.Id = 46;
            this.bbDeleteQueryLayoutFolder.ImageIndex = 60;
            this.bbDeleteQueryLayoutFolder.ItemAppearance.Disabled.Options.UseFont = true;
            this.bbDeleteQueryLayoutFolder.ItemAppearance.Normal.Options.UseFont = true;
            this.bbDeleteQueryLayoutFolder.Name = "bbDeleteQueryLayoutFolder";
            this.bbDeleteQueryLayoutFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbDeleteQueryLayoutFolder_ItemClick);
            // 
            // bbCopyQueryLayout
            // 
            resources.ApplyResources(this.bbCopyQueryLayout, "bbCopyQueryLayout");
            this.bbCopyQueryLayout.Enabled = false;
            this.bbCopyQueryLayout.Id = 48;
            this.bbCopyQueryLayout.ImageIndex = 65;
            this.bbCopyQueryLayout.ItemAppearance.Disabled.Options.UseFont = true;
            this.bbCopyQueryLayout.ItemAppearance.Normal.Options.UseFont = true;
            this.bbCopyQueryLayout.Name = "bbCopyQueryLayout";
            this.bbCopyQueryLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbCopyQueryLayout_ItemClick);
            // 
            // bbHelp
            // 
            resources.ApplyResources(this.bbHelp, "bbHelp");
            this.bbHelp.Id = 54;
            this.bbHelp.ImageIndex = 58;
            this.bbHelp.ItemAppearance.Disabled.Options.UseFont = true;
            this.bbHelp.ItemAppearance.Normal.Options.UseFont = true;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.biExport),
            new DevExpress.XtraBars.LinkPersistInfo(this.biPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.biOptions),
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
            resources.ApplyResources(this.biFile, "biFile");
            this.biFile.Id = 0;
            this.biFile.ItemAppearance.Disabled.Options.UseFont = true;
            this.biFile.ItemAppearance.Normal.Options.UseFont = true;
            this.biFile.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biNewQuery),
            new DevExpress.XtraBars.LinkPersistInfo(this.biNewLayout),
            new DevExpress.XtraBars.LinkPersistInfo(this.biNewFolder),
            new DevExpress.XtraBars.LinkPersistInfo(this.biEditQueryLayoutFolder, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.biViewQueryLayoutFolder),
            new DevExpress.XtraBars.LinkPersistInfo(this.biDeleteQueryLayoutFolder),
            new DevExpress.XtraBars.LinkPersistInfo(this.biCopyQueryLayout),
            new DevExpress.XtraBars.LinkPersistInfo(this.biRefreshData, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.biPublishQueryLayoutFolder, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.biUnpublishQueryLayoutFolder),
            new DevExpress.XtraBars.LinkPersistInfo(this.biExit, true)});
            this.biFile.Name = "biFile";
            this.biFile.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption;
            // 
            // biNewQuery
            // 
            resources.ApplyResources(this.biNewQuery, "biNewQuery");
            this.biNewQuery.Id = 16;
            this.biNewQuery.ImageIndex = 32;
            this.biNewQuery.ItemAppearance.Disabled.Options.UseFont = true;
            this.biNewQuery.ItemAppearance.Normal.Options.UseFont = true;
            this.biNewQuery.Name = "biNewQuery";
            this.biNewQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biNewQuery_ItemClick);
            // 
            // biNewLayout
            // 
            resources.ApplyResources(this.biNewLayout, "biNewLayout");
            this.biNewLayout.Enabled = false;
            this.biNewLayout.Id = 22;
            this.biNewLayout.ImageIndex = 70;
            this.biNewLayout.ItemAppearance.Disabled.Options.UseFont = true;
            this.biNewLayout.ItemAppearance.Normal.Options.UseFont = true;
            this.biNewLayout.Name = "biNewLayout";
            this.biNewLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biNewLayout_ItemClick);
            // 
            // biNewFolder
            // 
            resources.ApplyResources(this.biNewFolder, "biNewFolder");
            this.biNewFolder.Enabled = false;
            this.biNewFolder.Id = 62;
            this.biNewFolder.ImageIndex = 71;
            this.biNewFolder.Name = "biNewFolder";
            this.biNewFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biNewFolder_ItemClick);
            // 
            // biEditQueryLayoutFolder
            // 
            resources.ApplyResources(this.biEditQueryLayoutFolder, "biEditQueryLayoutFolder");
            this.biEditQueryLayoutFolder.Id = 17;
            this.biEditQueryLayoutFolder.ImageIndex = 59;
            this.biEditQueryLayoutFolder.ItemAppearance.Disabled.Options.UseFont = true;
            this.biEditQueryLayoutFolder.ItemAppearance.Normal.Options.UseFont = true;
            this.biEditQueryLayoutFolder.Name = "biEditQueryLayoutFolder";
            this.biEditQueryLayoutFolder.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.biEditQueryLayoutFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biEditQueryLayoutFolder_ItemClick);
            // 
            // biViewQueryLayoutFolder
            // 
            resources.ApplyResources(this.biViewQueryLayoutFolder, "biViewQueryLayoutFolder");
            this.biViewQueryLayoutFolder.Id = 94;
            this.biViewQueryLayoutFolder.ImageIndex = 42;
            this.biViewQueryLayoutFolder.Name = "biViewQueryLayoutFolder";
            this.biViewQueryLayoutFolder.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.biViewQueryLayoutFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biViewQueryLayoutFolder_ItemClick);
            // 
            // biDeleteQueryLayoutFolder
            // 
            resources.ApplyResources(this.biDeleteQueryLayoutFolder, "biDeleteQueryLayoutFolder");
            this.biDeleteQueryLayoutFolder.Enabled = false;
            this.biDeleteQueryLayoutFolder.Id = 23;
            this.biDeleteQueryLayoutFolder.ImageIndex = 60;
            this.biDeleteQueryLayoutFolder.ItemAppearance.Disabled.Options.UseFont = true;
            this.biDeleteQueryLayoutFolder.ItemAppearance.Normal.Options.UseFont = true;
            this.biDeleteQueryLayoutFolder.Name = "biDeleteQueryLayoutFolder";
            this.biDeleteQueryLayoutFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biDeleteQueryLayoutFolder_ItemClick);
            // 
            // biCopyQueryLayout
            // 
            resources.ApplyResources(this.biCopyQueryLayout, "biCopyQueryLayout");
            this.biCopyQueryLayout.Enabled = false;
            this.biCopyQueryLayout.Id = 21;
            this.biCopyQueryLayout.ImageIndex = 65;
            this.biCopyQueryLayout.ItemAppearance.Disabled.Options.UseFont = true;
            this.biCopyQueryLayout.ItemAppearance.Normal.Options.UseFont = true;
            this.biCopyQueryLayout.Name = "biCopyQueryLayout";
            this.biCopyQueryLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biCopyQueryLayout_ItemClick);
            // 
            // biPublishQueryLayoutFolder
            // 
            resources.ApplyResources(this.biPublishQueryLayoutFolder, "biPublishQueryLayoutFolder");
            this.biPublishQueryLayoutFolder.Enabled = false;
            this.biPublishQueryLayoutFolder.Id = 59;
            this.biPublishQueryLayoutFolder.ImageIndex = 57;
            this.biPublishQueryLayoutFolder.ItemAppearance.Disabled.Options.UseFont = true;
            this.biPublishQueryLayoutFolder.ItemAppearance.Normal.Options.UseFont = true;
            this.biPublishQueryLayoutFolder.Name = "biPublishQueryLayoutFolder";
            this.biPublishQueryLayoutFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biPublishQueryLayout_ItemClick);
            // 
            // biUnpublishQueryLayoutFolder
            // 
            resources.ApplyResources(this.biUnpublishQueryLayoutFolder, "biUnpublishQueryLayoutFolder");
            this.biUnpublishQueryLayoutFolder.Enabled = false;
            this.biUnpublishQueryLayoutFolder.Id = 63;
            this.biUnpublishQueryLayoutFolder.ImageIndex = 66;
            this.biUnpublishQueryLayoutFolder.Name = "biUnpublishQueryLayoutFolder";
            this.biUnpublishQueryLayoutFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biUnpublishQueryLayoutFolder_ItemClick);
            // 
            // biExit
            // 
            resources.ApplyResources(this.biExit, "biExit");
            this.biExit.Id = 86;
            this.biExit.ImageIndex = 84;
            this.biExit.Name = "biExit";
            this.biExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biExit_ItemClick);
            // 
            // biExport
            // 
            resources.ApplyResources(this.biExport, "biExport");
            this.biExport.Id = 65;
            this.biExport.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biExportReport),
            new DevExpress.XtraBars.LinkPersistInfo(this.biExportQuery)});
            this.biExport.Name = "biExport";
            // 
            // biExportReport
            // 
            resources.ApplyResources(this.biExportReport, "biExportReport");
            this.biExportReport.Id = 32;
            this.biExportReport.ImageIndex = 81;
            this.biExportReport.ItemAppearance.Disabled.Options.UseFont = true;
            this.biExportReport.ItemAppearance.Normal.Options.UseFont = true;
            this.biExportReport.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biExportReportToXls),
            new DevExpress.XtraBars.LinkPersistInfo(this.biExportReportToXlsx),
            new DevExpress.XtraBars.LinkPersistInfo(this.biExportReportToRtf),
            new DevExpress.XtraBars.LinkPersistInfo(this.biExportReportToPdf),
            new DevExpress.XtraBars.LinkPersistInfo(this.biExportReportToImage)});
            this.biExportReport.Name = "biExportReport";
            // 
            // biExportReportToXls
            // 
            resources.ApplyResources(this.biExportReportToXls, "biExportReportToXls");
            this.biExportReportToXls.Id = 39;
            this.biExportReportToXls.ImageIndex = 68;
            this.biExportReportToXls.ItemAppearance.Disabled.Options.UseFont = true;
            this.biExportReportToXls.ItemAppearance.Normal.Options.UseFont = true;
            this.biExportReportToXls.Name = "biExportReportToXls";
            this.biExportReportToXls.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biExportReportToXls_ItemClick);
            // 
            // biExportReportToXlsx
            // 
            resources.ApplyResources(this.biExportReportToXlsx, "biExportReportToXlsx");
            this.biExportReportToXlsx.Id = 82;
            this.biExportReportToXlsx.ImageIndex = 69;
            this.biExportReportToXlsx.Name = "biExportReportToXlsx";
            this.biExportReportToXlsx.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biExportReportToXlsx_ItemClick);
            // 
            // biExportReportToRtf
            // 
            resources.ApplyResources(this.biExportReportToRtf, "biExportReportToRtf");
            this.biExportReportToRtf.Id = 40;
            this.biExportReportToRtf.ImageIndex = 47;
            this.biExportReportToRtf.ItemAppearance.Disabled.Options.UseFont = true;
            this.biExportReportToRtf.ItemAppearance.Normal.Options.UseFont = true;
            this.biExportReportToRtf.Name = "biExportReportToRtf";
            this.biExportReportToRtf.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biExportReportToRtf_ItemClick);
            // 
            // biExportReportToPdf
            // 
            resources.ApplyResources(this.biExportReportToPdf, "biExportReportToPdf");
            this.biExportReportToPdf.Id = 41;
            this.biExportReportToPdf.ImageIndex = 48;
            this.biExportReportToPdf.ItemAppearance.Disabled.Options.UseFont = true;
            this.biExportReportToPdf.ItemAppearance.Normal.Options.UseFont = true;
            this.biExportReportToPdf.Name = "biExportReportToPdf";
            this.biExportReportToPdf.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biExportReportToPdf_ItemClick);
            // 
            // biExportReportToImage
            // 
            resources.ApplyResources(this.biExportReportToImage, "biExportReportToImage");
            this.biExportReportToImage.Id = 60;
            this.biExportReportToImage.ImageIndex = 50;
            this.biExportReportToImage.Name = "biExportReportToImage";
            this.biExportReportToImage.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.biExportReportToImage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biExportReportToImage_ItemClick);
            // 
            // biExportQuery
            // 
            resources.ApplyResources(this.biExportQuery, "biExportQuery");
            this.biExportQuery.Id = 83;
            this.biExportQuery.ImageIndex = 82;
            this.biExportQuery.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biExportQueryLineListToXls),
            new DevExpress.XtraBars.LinkPersistInfo(this.biExportQueryLineListToXlsx),
            new DevExpress.XtraBars.LinkPersistInfo(this.biExportQueryLineListToMdb)});
            this.biExportQuery.Name = "biExportQuery";
            // 
            // biExportQueryLineListToXls
            // 
            resources.ApplyResources(this.biExportQueryLineListToXls, "biExportQueryLineListToXls");
            this.biExportQueryLineListToXls.Id = 80;
            this.biExportQueryLineListToXls.ImageIndex = 68;
            this.biExportQueryLineListToXls.Name = "biExportQueryLineListToXls";
            this.biExportQueryLineListToXls.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biExportQueryLineListToXls_ItemClick);
            // 
            // biExportQueryLineListToXlsx
            // 
            resources.ApplyResources(this.biExportQueryLineListToXlsx, "biExportQueryLineListToXlsx");
            this.biExportQueryLineListToXlsx.Id = 84;
            this.biExportQueryLineListToXlsx.ImageIndex = 69;
            this.biExportQueryLineListToXlsx.Name = "biExportQueryLineListToXlsx";
            this.biExportQueryLineListToXlsx.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biExportQueryLineListToXlsx_ItemClick);
            // 
            // biExportQueryLineListToMdb
            // 
            resources.ApplyResources(this.biExportQueryLineListToMdb, "biExportQueryLineListToMdb");
            this.biExportQueryLineListToMdb.Id = 85;
            this.biExportQueryLineListToMdb.ImageIndex = 52;
            this.biExportQueryLineListToMdb.Name = "biExportQueryLineListToMdb";
            this.biExportQueryLineListToMdb.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biExportQueryLineListToMdb_ItemClick);
            // 
            // biPrint
            // 
            resources.ApplyResources(this.biPrint, "biPrint");
            this.biPrint.Id = 66;
            this.biPrint.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biPrintReport)});
            this.biPrint.Name = "biPrint";
            // 
            // biPrintReport
            // 
            resources.ApplyResources(this.biPrintReport, "biPrintReport");
            this.biPrintReport.Id = 81;
            this.biPrintReport.ImageIndex = 80;
            this.biPrintReport.Name = "biPrintReport";
            this.biPrintReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biPrintReport_ItemClick);
            // 
            // biOptions
            // 
            resources.ApplyResources(this.biOptions, "biOptions");
            this.biOptions.Id = 64;
            this.biOptions.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biShowToolBar),
            new DevExpress.XtraBars.LinkPersistInfo(this.biSettings)});
            this.biOptions.Name = "biOptions";
            // 
            // biShowToolBar
            // 
            this.biShowToolBar.BindableChecked = true;
            resources.ApplyResources(this.biShowToolBar, "biShowToolBar");
            this.biShowToolBar.Checked = true;
            this.biShowToolBar.Id = 55;
            this.biShowToolBar.ItemAppearance.Disabled.Options.UseFont = true;
            this.biShowToolBar.ItemAppearance.Normal.Options.UseFont = true;
            this.biShowToolBar.Name = "biShowToolBar";
            this.biShowToolBar.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.biShowToolBar_CheckedChanged);
            // 
            // biSettings
            // 
            resources.ApplyResources(this.biSettings, "biSettings");
            this.biSettings.Id = 69;
            this.biSettings.ImageIndex = 83;
            this.biSettings.Name = "biSettings";
            this.biSettings.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biSettings_ItemClick);
            // 
            // biHelp
            // 
            resources.ApplyResources(this.biHelp, "biHelp");
            this.biHelp.Id = 27;
            this.biHelp.ItemAppearance.Disabled.Options.UseFont = true;
            this.biHelp.ItemAppearance.Normal.Options.UseFont = true;
            this.biHelp.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biInternalHelp)});
            this.biHelp.Name = "biHelp";
            // 
            // biInternalHelp
            // 
            resources.ApplyResources(this.biInternalHelp, "biInternalHelp");
            this.biInternalHelp.Id = 28;
            this.biInternalHelp.ImageIndex = 58;
            this.biInternalHelp.ItemAppearance.Disabled.Options.UseFont = true;
            this.biInternalHelp.ItemAppearance.Normal.Options.UseFont = true;
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
            this.imageCollectionToolBar.Images.SetKeyName(59, "pencil-16_3.png");
            this.imageCollectionToolBar.Images.SetKeyName(60, "deleted.gif");
            this.imageCollectionToolBar.Images.SetKeyName(61, "New_Folder.png");
            this.imageCollectionToolBar.Images.SetKeyName(62, "new_folder_2.png");
            this.imageCollectionToolBar.Images.SetKeyName(63, "copy1.ico");
            this.imageCollectionToolBar.Images.SetKeyName(64, "copy2.png");
            this.imageCollectionToolBar.Images.SetKeyName(65, "copy3.gif");
            this.imageCollectionToolBar.Images.SetKeyName(66, "Unpublish.png");
            this.imageCollectionToolBar.Images.SetKeyName(67, "query_common.ico");
            this.imageCollectionToolBar.Images.SetKeyName(68, "excel_2003.gif");
            this.imageCollectionToolBar.Images.SetKeyName(69, "excel2007.png");
            this.imageCollectionToolBar.Images.SetKeyName(70, "layout_create_16x16.png");
            this.imageCollectionToolBar.Images.SetKeyName(71, "folder_create_16x16.png");
            this.imageCollectionToolBar.Images.SetKeyName(72, "publish_folder_16x16.png");
            this.imageCollectionToolBar.Images.SetKeyName(73, "publish_layout_16x16.png");
            this.imageCollectionToolBar.Images.SetKeyName(74, "publish_query_16x16.png");
            this.imageCollectionToolBar.Images.SetKeyName(75, "publish_report_16x16.png");
            this.imageCollectionToolBar.Images.SetKeyName(76, "unpublish_folder_16x16.png");
            this.imageCollectionToolBar.Images.SetKeyName(77, "unpublish_layout_16x16.png");
            this.imageCollectionToolBar.Images.SetKeyName(78, "unpublish_query_16x16.png");
            this.imageCollectionToolBar.Images.SetKeyName(79, "view_16_x16.png");
            this.imageCollectionToolBar.Images.SetKeyName(80, "print_report_16x16.png");
            this.imageCollectionToolBar.Images.SetKeyName(81, "export_report_16x16.png");
            this.imageCollectionToolBar.Images.SetKeyName(82, "export_query_16x16.png");
            this.imageCollectionToolBar.Images.SetKeyName(83, "avr_settings_16x16.png");
            this.imageCollectionToolBar.Images.SetKeyName(84, "Exit(16).png");
            this.imageCollectionToolBar.Images.SetKeyName(85, "refresh_data_16x16.png");
            // 
            // bbEditCaption
            // 
            resources.ApplyResources(this.bbEditCaption, "bbEditCaption");
            this.bbEditCaption.Id = 61;
            this.bbEditCaption.Name = "bbEditCaption";
            this.bbEditCaption.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbEditCaption_ItemClick);
            // 
            // bbCopyField
            // 
            resources.ApplyResources(this.bbCopyField, "bbCopyField");
            this.bbCopyField.Id = 73;
            this.bbCopyField.Name = "bbCopyField";
            this.bbCopyField.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbCopyField_ItemClick);
            // 
            // bbDeleteCopyField
            // 
            resources.ApplyResources(this.bbDeleteCopyField, "bbDeleteCopyField");
            this.bbDeleteCopyField.Id = 74;
            this.bbDeleteCopyField.Name = "bbDeleteCopyField";
            this.bbDeleteCopyField.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbDeleteCopyField_ItemClick);
            // 
            // bbAddMissedValues
            // 
            resources.ApplyResources(this.bbAddMissedValues, "bbAddMissedValues");
            this.bbAddMissedValues.Id = 75;
            this.bbAddMissedValues.Name = "bbAddMissedValues";
            this.bbAddMissedValues.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbAddMissedValues_ItemClick);
            // 
            // bbDeleteMissedValues
            // 
            resources.ApplyResources(this.bbDeleteMissedValues, "bbDeleteMissedValues");
            this.bbDeleteMissedValues.Id = 76;
            this.bbDeleteMissedValues.Name = "bbDeleteMissedValues";
            this.bbDeleteMissedValues.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbDeleteMissedValues_ItemClick);
            // 
            // bsGroupDate
            // 
            resources.ApplyResources(this.bsGroupDate, "bsGroupDate");
            this.bsGroupDate.Id = 78;
            this.bsGroupDate.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bcGroupDate_0)});
            this.bsGroupDate.Name = "bsGroupDate";
            // 
            // bcGroupDate_0
            // 
            resources.ApplyResources(this.bcGroupDate_0, "bcGroupDate_0");
            this.bcGroupDate_0.Id = 79;
            this.bcGroupDate_0.Name = "bcGroupDate_0";
            this.bcGroupDate_0.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.bcGroupDate_CheckedChanged);
            // 
            // bbPopupNewQuery
            // 
            resources.ApplyResources(this.bbPopupNewQuery, "bbPopupNewQuery");
            this.bbPopupNewQuery.Id = 87;
            this.bbPopupNewQuery.ImageIndex = 32;
            this.bbPopupNewQuery.Name = "bbPopupNewQuery";
            this.bbPopupNewQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbPopupNewQuery_ItemClick);
            // 
            // barButtonItem1
            // 
            resources.ApplyResources(this.barButtonItem1, "barButtonItem1");
            this.barButtonItem1.Id = 39;
            this.barButtonItem1.ImageIndex = 46;
            this.barButtonItem1.ItemAppearance.Disabled.Options.UseFont = true;
            this.barButtonItem1.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // bbPopupNewLayout
            // 
            resources.ApplyResources(this.bbPopupNewLayout, "bbPopupNewLayout");
            this.bbPopupNewLayout.Id = 88;
            this.bbPopupNewLayout.ImageIndex = 70;
            this.bbPopupNewLayout.Name = "bbPopupNewLayout";
            this.bbPopupNewLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbPopupNewLayout_ItemClick);
            // 
            // bbPopupNewFolder
            // 
            resources.ApplyResources(this.bbPopupNewFolder, "bbPopupNewFolder");
            this.bbPopupNewFolder.Id = 89;
            this.bbPopupNewFolder.ImageIndex = 71;
            this.bbPopupNewFolder.Name = "bbPopupNewFolder";
            this.bbPopupNewFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbPopupNewFolder_ItemClick);
            // 
            // bbPopupEditQueryLayoutFolder
            // 
            resources.ApplyResources(this.bbPopupEditQueryLayoutFolder, "bbPopupEditQueryLayoutFolder");
            this.bbPopupEditQueryLayoutFolder.Id = 90;
            this.bbPopupEditQueryLayoutFolder.ImageIndex = 59;
            this.bbPopupEditQueryLayoutFolder.Name = "bbPopupEditQueryLayoutFolder";
            this.bbPopupEditQueryLayoutFolder.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbPopupEditQueryLayoutFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbPopupEditQueryLayoutFolder_ItemClick);
            // 
            // bbPopupDeleteQueryLayoutFolder
            // 
            resources.ApplyResources(this.bbPopupDeleteQueryLayoutFolder, "bbPopupDeleteQueryLayoutFolder");
            this.bbPopupDeleteQueryLayoutFolder.Id = 91;
            this.bbPopupDeleteQueryLayoutFolder.ImageIndex = 60;
            this.bbPopupDeleteQueryLayoutFolder.Name = "bbPopupDeleteQueryLayoutFolder";
            this.bbPopupDeleteQueryLayoutFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbPopupDeleteQueryLayoutFolder_ItemClick);
            // 
            // bbPopupCopyQueryLayout
            // 
            resources.ApplyResources(this.bbPopupCopyQueryLayout, "bbPopupCopyQueryLayout");
            this.bbPopupCopyQueryLayout.Id = 92;
            this.bbPopupCopyQueryLayout.ImageIndex = 65;
            this.bbPopupCopyQueryLayout.Name = "bbPopupCopyQueryLayout";
            this.bbPopupCopyQueryLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbPopupCopyQueryLayout_ItemClick);
            // 
            // bbEditMissedValues
            // 
            resources.ApplyResources(this.bbEditMissedValues, "bbEditMissedValues");
            this.bbEditMissedValues.Id = 93;
            this.bbEditMissedValues.Name = "bbEditMissedValues";
            this.bbEditMissedValues.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbEditMissedValues_ItemClick);
            // 
            // bbPopupViewQueryLayoutFolder
            // 
            resources.ApplyResources(this.bbPopupViewQueryLayoutFolder, "bbPopupViewQueryLayoutFolder");
            this.bbPopupViewQueryLayoutFolder.Id = 95;
            this.bbPopupViewQueryLayoutFolder.ImageIndex = 42;
            this.bbPopupViewQueryLayoutFolder.Name = "bbPopupViewQueryLayoutFolder";
            this.bbPopupViewQueryLayoutFolder.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbPopupViewQueryLayoutFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbPopupViewQueryLayoutFolder_ItemClick);
            // 
            // PivotPopupMenu
            // 
            this.PivotPopupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbEditCaption),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsGroupDate),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbCopyField, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbDeleteCopyField),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbAddMissedValues, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbEditMissedValues),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbDeleteMissedValues)});
            this.PivotPopupMenu.Manager = this.barManager;
            this.PivotPopupMenu.Name = "PivotPopupMenu";
            // 
            // DeleteQueryLayoutTimer
            // 
            this.DeleteQueryLayoutTimer.Tick += new System.EventHandler(this.DeleteQueryLayoutTimer_Tick);
            // 
            // CloseQueryLayoutTimer
            // 
            this.CloseQueryLayoutTimer.Tick += new System.EventHandler(this.CloseQueryLayoutTimer_Tick);
            // 
            // CopyLayoutTimer
            // 
            this.CopyLayoutTimer.Tick += new System.EventHandler(this.CopyLayoutTimer_Tick);
            // 
            // NewLayoutTimer
            // 
            this.NewLayoutTimer.Tick += new System.EventHandler(this.NewLayoutTimer_Tick);
            // 
            // CloseTimer
            // 
            this.CloseTimer.Tick += new System.EventHandler(this.CloseTimer_Tick);
            // 
            // TabControl
            // 
            resources.ApplyResources(this.TabControl, "TabControl");
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedTabPage = this.TabPageTree;
            this.TabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.TabPageTree,
            this.TabPageEditor});
            this.TabControl.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.TabControl_SelectedPageChanged);
            // 
            // TabPageTree
            // 
            this.TabPageTree.Controls.Add(this.QueryLayoutTree);
            this.TabPageTree.Name = "TabPageTree";
            resources.ApplyResources(this.TabPageTree, "TabPageTree");
            // 
            // TabPageEditor
            // 
            this.TabPageEditor.Controls.Add(this.EditorPanel);
            this.TabPageEditor.Name = "TabPageEditor";
            resources.ApplyResources(this.TabPageEditor, "TabPageEditor");
            // 
            // EditorPanel
            // 
            this.EditorPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            resources.ApplyResources(this.EditorPanel, "EditorPanel");
            this.EditorPanel.Name = "EditorPanel";
            // 
            // TreePopupMenu
            // 
            this.TreePopupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbPopupNewQuery),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbPopupNewLayout),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbPopupNewFolder),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbPopupEditQueryLayoutFolder, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbPopupViewQueryLayoutFolder),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbPopupDeleteQueryLayoutFolder),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbPopupCopyQueryLayout),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbRefreshData, true)});
            this.TreePopupMenu.Manager = this.barManager;
            this.TreePopupMenu.Name = "TreePopupMenu";
            // 
            // bbRefreshData
            // 
            resources.ApplyResources(this.bbRefreshData, "bbRefreshData");
            this.bbRefreshData.Id = 97;
            this.bbRefreshData.ImageIndex = 85;
            this.bbRefreshData.Name = "bbRefreshData";
            this.bbRefreshData.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbRefreshData_ItemClick);
            // 
            // biRefreshData
            // 
            resources.ApplyResources(this.biRefreshData, "biRefreshData");
            this.biRefreshData.Id = 98;
            this.biRefreshData.ImageIndex = 85;
            this.biRefreshData.Name = "biRefreshData";
            this.biRefreshData.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biRefreshData_ItemClick);
            // 
            // AvrMainForm
            // 
            this.Appearance.Options.UseFont = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.DefaultFormState = System.Windows.Forms.FormWindowState.Normal;
            this.FormID = "R01";
            this.HelpTopicID = "AVR_Main_Window";
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "AvrMainForm";
            this.Sizable = true;
            this.Status = bv.common.win.FormStatus.Draft;
            this.Load += new System.EventHandler(this.AVRReportControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionToolBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PivotPopupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabControl)).EndInit();
            this.TabControl.ResumeLayout(false);
            this.TabPageTree.ResumeLayout(false);
            this.TabPageEditor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EditorPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TreePopupMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LayoutDetailPanel layoutDetail;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barTools;
        private DevExpress.XtraBars.Bar barMenu;
        private DevExpress.XtraBars.BarSubItem biFile;
        private DevExpress.XtraBars.Bar barStatus;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        
        private DevExpress.XtraBars.BarButtonItem biNewQuery;
        private DevExpress.XtraBars.BarButtonItem biEditQueryLayoutFolder;
        
        private DevExpress.XtraBars.BarButtonItem biCopyQueryLayout;
        private DevExpress.XtraBars.BarButtonItem biNewLayout;
        private DevExpress.XtraBars.BarButtonItem biDeleteQueryLayoutFolder;
        private DevExpress.XtraBars.BarSubItem biHelp;
        private DevExpress.XtraBars.BarButtonItem biInternalHelp;
        private DevExpress.XtraBars.BarSubItem biExportReport;
        private DevExpress.XtraBars.BarButtonItem biExportReportToXls;
        private DevExpress.XtraBars.BarButtonItem biExportReportToRtf;
        private DevExpress.XtraBars.BarButtonItem biExportReportToPdf;
        private DevExpress.XtraBars.BarButtonItem bbNewQuery;
        private DevExpress.XtraBars.BarButtonItem bbEditQueryLayoutFolder;
        private DevExpress.XtraBars.BarButtonItem bbDeleteQueryLayoutFolder;
        private DevExpress.XtraBars.BarButtonItem bbCopyQueryLayout;
        private DevExpress.XtraBars.BarButtonItem bbNewLayout;
        
        private DevExpress.XtraBars.BarButtonItem bbHelp;
        private DevExpress.Utils.ImageCollection imageCollectionToolBar;
        private DevExpress.XtraBars.BarCheckItem biShowToolBar;
        
        
        
        private DevExpress.XtraBars.BarButtonItem biPublishQueryLayoutFolder;
        private DevExpress.XtraBars.BarButtonItem biExportReportToImage;
        private DevExpress.XtraBars.PopupMenu PivotPopupMenu;
        private DevExpress.XtraBars.BarButtonItem bbEditCaption;
        private DevExpress.XtraBars.BarButtonItem biNewFolder;
        private DevExpress.XtraBars.BarButtonItem biUnpublishQueryLayoutFolder;
        private DevExpress.XtraBars.BarSubItem biExport;
        private DevExpress.XtraBars.BarSubItem biPrint;
        private DevExpress.XtraBars.BarSubItem biOptions;
        private DevExpress.XtraBars.BarButtonItem biSettings;

        private DevExpress.XtraBars.BarButtonItem bbNewFolder;
        
        private QueryBuilder.QueryDetailPanel queryDetail;

        private QueryLayoutTreePanel QueryLayoutTree;
        
        
        private DevExpress.XtraBars.BarButtonItem bbCopyField;
        private DevExpress.XtraBars.BarButtonItem bbDeleteCopyField;
        private DevExpress.XtraBars.BarButtonItem bbAddMissedValues;
        private DevExpress.XtraBars.BarButtonItem bbDeleteMissedValues;
        
        private DevExpress.XtraBars.BarSubItem bsGroupDate;
        private DevExpress.XtraBars.BarCheckItem bcGroupDate_0;
        private DevExpress.XtraBars.BarButtonItem biExportQueryLineListToXls;
        private DevExpress.XtraBars.BarButtonItem biPrintReport;
        private System.Windows.Forms.Timer DeleteQueryLayoutTimer;
        private DevExpress.XtraBars.BarButtonItem biExportReportToXlsx;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarSubItem biExportQuery;
        private DevExpress.XtraBars.BarButtonItem biExportQueryLineListToXlsx;
        private System.Windows.Forms.Timer CloseQueryLayoutTimer;
        private System.Windows.Forms.Timer CopyLayoutTimer;
        private System.Windows.Forms.Timer NewLayoutTimer;
        private System.Windows.Forms.Timer CloseTimer;
        private DevExpress.XtraTab.XtraTabControl TabControl;
        private DevExpress.XtraTab.XtraTabPage TabPageTree;
        private DevExpress.XtraTab.XtraTabPage TabPageEditor;
        private DevExpress.XtraEditors.PanelControl EditorPanel;
        private DevExpress.XtraBars.BarButtonItem biExportQueryLineListToMdb;
        private DevExpress.XtraBars.BarButtonItem biExit;
        private DevExpress.XtraBars.BarButtonItem bbPopupNewQuery;
        private DevExpress.XtraBars.PopupMenu TreePopupMenu;
        private DevExpress.XtraBars.BarButtonItem bbPopupNewLayout;
        private DevExpress.XtraBars.BarButtonItem bbPopupNewFolder;
        private DevExpress.XtraBars.BarButtonItem bbPopupEditQueryLayoutFolder;
        private DevExpress.XtraBars.BarButtonItem bbPopupDeleteQueryLayoutFolder;
        private DevExpress.XtraBars.BarButtonItem bbPopupCopyQueryLayout;
        private DevExpress.XtraBars.BarButtonItem bbEditMissedValues;
        private DevExpress.XtraBars.BarButtonItem biViewQueryLayoutFolder;
        private DevExpress.XtraBars.BarButtonItem bbPopupViewQueryLayoutFolder;
        private DevExpress.XtraBars.BarButtonItem bbViewQueryLayoutFolder;
        private DevExpress.XtraBars.BarButtonItem bbRefreshData;
        private DevExpress.XtraBars.BarButtonItem biRefreshData;
        


    }
}
