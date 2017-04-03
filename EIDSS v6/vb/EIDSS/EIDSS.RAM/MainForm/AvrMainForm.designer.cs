
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AvrMainForm));
            this.QueryLayoutTree = new eidss.avr.QueryLayoutTree.QueryLayoutTreePanel();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTools = new DevExpress.XtraBars.Bar();
            this.bbNewQuery = new DevExpress.XtraBars.BarButtonItem();
            this.bbNewLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbNewFolder = new DevExpress.XtraBars.BarButtonItem();
            this.bbEditQueryLayoutFolder = new DevExpress.XtraBars.BarButtonItem();
            this.bbDeleteQueryLayoutFolder = new DevExpress.XtraBars.BarButtonItem();
            this.bbCopyQueryLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbHelp = new DevExpress.XtraBars.BarButtonItem();
            this.barMenu = new DevExpress.XtraBars.Bar();
            this.biFile = new DevExpress.XtraBars.BarSubItem();
            this.biNewQuery = new DevExpress.XtraBars.BarButtonItem();
            this.biNewLayout = new DevExpress.XtraBars.BarButtonItem();
            this.biNewFolder = new DevExpress.XtraBars.BarButtonItem();
            this.biEditQueryLayout = new DevExpress.XtraBars.BarButtonItem();
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
            this.imageCollectionToolBar = new DevExpress.Utils.ImageCollection(this.components);
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
            this.PivotPopupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.DeleteQueryLayoutTimer = new System.Windows.Forms.Timer(this.components);
            this.CloseQueryLayoutTimer = new System.Windows.Forms.Timer(this.components);
            this.CloseTimer = new System.Windows.Forms.Timer(this.components);
            this.TabControl = new DevExpress.XtraTab.XtraTabControl();
            this.TabPageTree = new DevExpress.XtraTab.XtraTabPage();
            this.TabPageEditor = new DevExpress.XtraTab.XtraTabPage();
            this.EditorPanel = new DevExpress.XtraEditors.PanelControl();
            this.TreePopupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
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
            this.biEditQueryLayout,
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
            this.bbPopupCopyQueryLayout});
            this.barManager.MainMenu = this.barMenu;
            this.barManager.MaxItemId = 93;
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
            this.bbNewQuery.Enabled = false;
            this.bbNewQuery.Id = 44;
            this.bbNewQuery.ImageIndex = 32;
            this.bbNewQuery.ItemAppearance.Disabled.FontSizeDelta = ((int)(resources.GetObject("bbNewQuery.ItemAppearance.Disabled.FontSizeDelta")));
            this.bbNewQuery.ItemAppearance.Disabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("bbNewQuery.ItemAppearance.Disabled.FontStyleDelta")));
            this.bbNewQuery.ItemAppearance.Disabled.Options.UseFont = true;
            this.bbNewQuery.ItemAppearance.Normal.FontSizeDelta = ((int)(resources.GetObject("bbNewQuery.ItemAppearance.Normal.FontSizeDelta")));
            this.bbNewQuery.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("bbNewQuery.ItemAppearance.Normal.FontStyleDelta")));
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
            this.bbNewLayout.ItemAppearance.Disabled.FontSizeDelta = ((int)(resources.GetObject("bbNewLayout.ItemAppearance.Disabled.FontSizeDelta")));
            this.bbNewLayout.ItemAppearance.Disabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("bbNewLayout.ItemAppearance.Disabled.FontStyleDelta")));
            this.bbNewLayout.ItemAppearance.Disabled.Options.UseFont = true;
            this.bbNewLayout.ItemAppearance.Normal.FontSizeDelta = ((int)(resources.GetObject("bbNewLayout.ItemAppearance.Normal.FontSizeDelta")));
            this.bbNewLayout.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("bbNewLayout.ItemAppearance.Normal.FontStyleDelta")));
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
            this.bbEditQueryLayoutFolder.Enabled = false;
            this.bbEditQueryLayoutFolder.Id = 45;
            this.bbEditQueryLayoutFolder.ImageIndex = 59;
            this.bbEditQueryLayoutFolder.ItemAppearance.Disabled.FontSizeDelta = ((int)(resources.GetObject("bbEditQueryLayoutFolder.ItemAppearance.Disabled.FontSizeDelta")));
            this.bbEditQueryLayoutFolder.ItemAppearance.Disabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("bbEditQueryLayoutFolder.ItemAppearance.Disabled.FontStyleDelta")));
            this.bbEditQueryLayoutFolder.ItemAppearance.Disabled.Options.UseFont = true;
            this.bbEditQueryLayoutFolder.ItemAppearance.Normal.FontSizeDelta = ((int)(resources.GetObject("bbEditQueryLayoutFolder.ItemAppearance.Normal.FontSizeDelta")));
            this.bbEditQueryLayoutFolder.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("bbEditQueryLayoutFolder.ItemAppearance.Normal.FontStyleDelta")));
            this.bbEditQueryLayoutFolder.ItemAppearance.Normal.Options.UseFont = true;
            this.bbEditQueryLayoutFolder.Name = "bbEditQueryLayoutFolder";
            this.bbEditQueryLayoutFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbEditQueryLayout_ItemClick);
            // 
            // bbDeleteQueryLayoutFolder
            // 
            resources.ApplyResources(this.bbDeleteQueryLayoutFolder, "bbDeleteQueryLayoutFolder");
            this.bbDeleteQueryLayoutFolder.Enabled = false;
            this.bbDeleteQueryLayoutFolder.Id = 46;
            this.bbDeleteQueryLayoutFolder.ImageIndex = 60;
            this.bbDeleteQueryLayoutFolder.ItemAppearance.Disabled.FontSizeDelta = ((int)(resources.GetObject("bbDeleteQueryLayoutFolder.ItemAppearance.Disabled.FontSizeDelta")));
            this.bbDeleteQueryLayoutFolder.ItemAppearance.Disabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("bbDeleteQueryLayoutFolder.ItemAppearance.Disabled.FontStyleDelta")));
            this.bbDeleteQueryLayoutFolder.ItemAppearance.Disabled.Options.UseFont = true;
            this.bbDeleteQueryLayoutFolder.ItemAppearance.Normal.FontSizeDelta = ((int)(resources.GetObject("bbDeleteQueryLayoutFolder.ItemAppearance.Normal.FontSizeDelta")));
            this.bbDeleteQueryLayoutFolder.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("bbDeleteQueryLayoutFolder.ItemAppearance.Normal.FontStyleDelta")));
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
            this.bbCopyQueryLayout.ItemAppearance.Disabled.FontSizeDelta = ((int)(resources.GetObject("bbCopyQueryLayout.ItemAppearance.Disabled.FontSizeDelta")));
            this.bbCopyQueryLayout.ItemAppearance.Disabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("bbCopyQueryLayout.ItemAppearance.Disabled.FontStyleDelta")));
            this.bbCopyQueryLayout.ItemAppearance.Disabled.Options.UseFont = true;
            this.bbCopyQueryLayout.ItemAppearance.Normal.FontSizeDelta = ((int)(resources.GetObject("bbCopyQueryLayout.ItemAppearance.Normal.FontSizeDelta")));
            this.bbCopyQueryLayout.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("bbCopyQueryLayout.ItemAppearance.Normal.FontStyleDelta")));
            this.bbCopyQueryLayout.ItemAppearance.Normal.Options.UseFont = true;
            this.bbCopyQueryLayout.Name = "bbCopyQueryLayout";
            this.bbCopyQueryLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbCopyQueryLayout_ItemClick);
            // 
            // bbHelp
            // 
            resources.ApplyResources(this.bbHelp, "bbHelp");
            this.bbHelp.Id = 54;
            this.bbHelp.ImageIndex = 58;
            this.bbHelp.ItemAppearance.Disabled.FontSizeDelta = ((int)(resources.GetObject("bbHelp.ItemAppearance.Disabled.FontSizeDelta")));
            this.bbHelp.ItemAppearance.Disabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("bbHelp.ItemAppearance.Disabled.FontStyleDelta")));
            this.bbHelp.ItemAppearance.Disabled.Options.UseFont = true;
            this.bbHelp.ItemAppearance.Normal.FontSizeDelta = ((int)(resources.GetObject("bbHelp.ItemAppearance.Normal.FontSizeDelta")));
            this.bbHelp.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("bbHelp.ItemAppearance.Normal.FontStyleDelta")));
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
            this.biFile.ItemAppearance.Disabled.FontSizeDelta = ((int)(resources.GetObject("biFile.ItemAppearance.Disabled.FontSizeDelta")));
            this.biFile.ItemAppearance.Disabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biFile.ItemAppearance.Disabled.FontStyleDelta")));
            this.biFile.ItemAppearance.Disabled.Options.UseFont = true;
            this.biFile.ItemAppearance.Normal.FontSizeDelta = ((int)(resources.GetObject("biFile.ItemAppearance.Normal.FontSizeDelta")));
            this.biFile.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biFile.ItemAppearance.Normal.FontStyleDelta")));
            this.biFile.ItemAppearance.Normal.Options.UseFont = true;
            this.biFile.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biNewQuery),
            new DevExpress.XtraBars.LinkPersistInfo(this.biNewLayout),
            new DevExpress.XtraBars.LinkPersistInfo(this.biNewFolder),
            new DevExpress.XtraBars.LinkPersistInfo(this.biEditQueryLayout, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.biDeleteQueryLayoutFolder),
            new DevExpress.XtraBars.LinkPersistInfo(this.biCopyQueryLayout),
            new DevExpress.XtraBars.LinkPersistInfo(this.biPublishQueryLayoutFolder, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.biUnpublishQueryLayoutFolder),
            new DevExpress.XtraBars.LinkPersistInfo(this.biExit, true)});
            this.biFile.MenuAppearance.HeaderItemAppearance.FontSizeDelta = ((int)(resources.GetObject("biFile.MenuAppearance.HeaderItemAppearance.FontSizeDelta")));
            this.biFile.MenuAppearance.HeaderItemAppearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biFile.MenuAppearance.HeaderItemAppearance.FontStyleDelta")));
            this.biFile.MenuAppearance.HeaderItemAppearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("biFile.MenuAppearance.HeaderItemAppearance.GradientMode")));
            this.biFile.MenuAppearance.HeaderItemAppearance.Image = ((System.Drawing.Image)(resources.GetObject("biFile.MenuAppearance.HeaderItemAppearance.Image")));
            this.biFile.Name = "biFile";
            this.biFile.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption;
            // 
            // biNewQuery
            // 
            resources.ApplyResources(this.biNewQuery, "biNewQuery");
            this.biNewQuery.Enabled = false;
            this.biNewQuery.Id = 16;
            this.biNewQuery.ImageIndex = 32;
            this.biNewQuery.ItemAppearance.Disabled.FontSizeDelta = ((int)(resources.GetObject("biNewQuery.ItemAppearance.Disabled.FontSizeDelta")));
            this.biNewQuery.ItemAppearance.Disabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biNewQuery.ItemAppearance.Disabled.FontStyleDelta")));
            this.biNewQuery.ItemAppearance.Disabled.Options.UseFont = true;
            this.biNewQuery.ItemAppearance.Normal.FontSizeDelta = ((int)(resources.GetObject("biNewQuery.ItemAppearance.Normal.FontSizeDelta")));
            this.biNewQuery.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biNewQuery.ItemAppearance.Normal.FontStyleDelta")));
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
            this.biNewLayout.ItemAppearance.Disabled.FontSizeDelta = ((int)(resources.GetObject("biNewLayout.ItemAppearance.Disabled.FontSizeDelta")));
            this.biNewLayout.ItemAppearance.Disabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biNewLayout.ItemAppearance.Disabled.FontStyleDelta")));
            this.biNewLayout.ItemAppearance.Disabled.Options.UseFont = true;
            this.biNewLayout.ItemAppearance.Normal.FontSizeDelta = ((int)(resources.GetObject("biNewLayout.ItemAppearance.Normal.FontSizeDelta")));
            this.biNewLayout.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biNewLayout.ItemAppearance.Normal.FontStyleDelta")));
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
            // biEditQueryLayout
            // 
            resources.ApplyResources(this.biEditQueryLayout, "biEditQueryLayout");
            this.biEditQueryLayout.Enabled = false;
            this.biEditQueryLayout.Id = 17;
            this.biEditQueryLayout.ImageIndex = 59;
            this.biEditQueryLayout.ItemAppearance.Disabled.FontSizeDelta = ((int)(resources.GetObject("biEditQueryLayout.ItemAppearance.Disabled.FontSizeDelta")));
            this.biEditQueryLayout.ItemAppearance.Disabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biEditQueryLayout.ItemAppearance.Disabled.FontStyleDelta")));
            this.biEditQueryLayout.ItemAppearance.Disabled.Options.UseFont = true;
            this.biEditQueryLayout.ItemAppearance.Normal.FontSizeDelta = ((int)(resources.GetObject("biEditQueryLayout.ItemAppearance.Normal.FontSizeDelta")));
            this.biEditQueryLayout.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biEditQueryLayout.ItemAppearance.Normal.FontStyleDelta")));
            this.biEditQueryLayout.ItemAppearance.Normal.Options.UseFont = true;
            this.biEditQueryLayout.Name = "biEditQueryLayout";
            this.biEditQueryLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biEditQueryLayoutFolder_ItemClick);
            // 
            // biDeleteQueryLayoutFolder
            // 
            resources.ApplyResources(this.biDeleteQueryLayoutFolder, "biDeleteQueryLayoutFolder");
            this.biDeleteQueryLayoutFolder.Enabled = false;
            this.biDeleteQueryLayoutFolder.Id = 23;
            this.biDeleteQueryLayoutFolder.ImageIndex = 60;
            this.biDeleteQueryLayoutFolder.ItemAppearance.Disabled.FontSizeDelta = ((int)(resources.GetObject("biDeleteQueryLayoutFolder.ItemAppearance.Disabled.FontSizeDelta")));
            this.biDeleteQueryLayoutFolder.ItemAppearance.Disabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biDeleteQueryLayoutFolder.ItemAppearance.Disabled.FontStyleDelta")));
            this.biDeleteQueryLayoutFolder.ItemAppearance.Disabled.Options.UseFont = true;
            this.biDeleteQueryLayoutFolder.ItemAppearance.Normal.FontSizeDelta = ((int)(resources.GetObject("biDeleteQueryLayoutFolder.ItemAppearance.Normal.FontSizeDelta")));
            this.biDeleteQueryLayoutFolder.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biDeleteQueryLayoutFolder.ItemAppearance.Normal.FontStyleDelta")));
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
            this.biCopyQueryLayout.ItemAppearance.Disabled.FontSizeDelta = ((int)(resources.GetObject("biCopyQueryLayout.ItemAppearance.Disabled.FontSizeDelta")));
            this.biCopyQueryLayout.ItemAppearance.Disabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biCopyQueryLayout.ItemAppearance.Disabled.FontStyleDelta")));
            this.biCopyQueryLayout.ItemAppearance.Disabled.Options.UseFont = true;
            this.biCopyQueryLayout.ItemAppearance.Normal.FontSizeDelta = ((int)(resources.GetObject("biCopyQueryLayout.ItemAppearance.Normal.FontSizeDelta")));
            this.biCopyQueryLayout.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biCopyQueryLayout.ItemAppearance.Normal.FontStyleDelta")));
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
            this.biPublishQueryLayoutFolder.ItemAppearance.Disabled.FontSizeDelta = ((int)(resources.GetObject("biPublishQueryLayoutFolder.ItemAppearance.Disabled.FontSizeDelta")));
            this.biPublishQueryLayoutFolder.ItemAppearance.Disabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biPublishQueryLayoutFolder.ItemAppearance.Disabled.FontStyleDelta")));
            this.biPublishQueryLayoutFolder.ItemAppearance.Disabled.Options.UseFont = true;
            this.biPublishQueryLayoutFolder.ItemAppearance.Normal.FontSizeDelta = ((int)(resources.GetObject("biPublishQueryLayoutFolder.ItemAppearance.Normal.FontSizeDelta")));
            this.biPublishQueryLayoutFolder.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biPublishQueryLayoutFolder.ItemAppearance.Normal.FontStyleDelta")));
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
            this.biExport.MenuAppearance.HeaderItemAppearance.FontSizeDelta = ((int)(resources.GetObject("biExport.MenuAppearance.HeaderItemAppearance.FontSizeDelta")));
            this.biExport.MenuAppearance.HeaderItemAppearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biExport.MenuAppearance.HeaderItemAppearance.FontStyleDelta")));
            this.biExport.MenuAppearance.HeaderItemAppearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("biExport.MenuAppearance.HeaderItemAppearance.GradientMode")));
            this.biExport.MenuAppearance.HeaderItemAppearance.Image = ((System.Drawing.Image)(resources.GetObject("biExport.MenuAppearance.HeaderItemAppearance.Image")));
            this.biExport.Name = "biExport";
            // 
            // biExportReport
            // 
            resources.ApplyResources(this.biExportReport, "biExportReport");
            this.biExportReport.Id = 32;
            this.biExportReport.ImageIndex = 81;
            this.biExportReport.ItemAppearance.Disabled.FontSizeDelta = ((int)(resources.GetObject("biExportReport.ItemAppearance.Disabled.FontSizeDelta")));
            this.biExportReport.ItemAppearance.Disabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biExportReport.ItemAppearance.Disabled.FontStyleDelta")));
            this.biExportReport.ItemAppearance.Disabled.Options.UseFont = true;
            this.biExportReport.ItemAppearance.Normal.FontSizeDelta = ((int)(resources.GetObject("biExportReport.ItemAppearance.Normal.FontSizeDelta")));
            this.biExportReport.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biExportReport.ItemAppearance.Normal.FontStyleDelta")));
            this.biExportReport.ItemAppearance.Normal.Options.UseFont = true;
            this.biExportReport.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biExportReportToXls),
            new DevExpress.XtraBars.LinkPersistInfo(this.biExportReportToXlsx),
            new DevExpress.XtraBars.LinkPersistInfo(this.biExportReportToRtf),
            new DevExpress.XtraBars.LinkPersistInfo(this.biExportReportToPdf),
            new DevExpress.XtraBars.LinkPersistInfo(this.biExportReportToImage)});
            this.biExportReport.MenuAppearance.HeaderItemAppearance.FontSizeDelta = ((int)(resources.GetObject("biExportReport.MenuAppearance.HeaderItemAppearance.FontSizeDelta")));
            this.biExportReport.MenuAppearance.HeaderItemAppearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biExportReport.MenuAppearance.HeaderItemAppearance.FontStyleDelta")));
            this.biExportReport.MenuAppearance.HeaderItemAppearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("biExportReport.MenuAppearance.HeaderItemAppearance.GradientMode")));
            this.biExportReport.MenuAppearance.HeaderItemAppearance.Image = ((System.Drawing.Image)(resources.GetObject("biExportReport.MenuAppearance.HeaderItemAppearance.Image")));
            this.biExportReport.Name = "biExportReport";
            // 
            // biExportReportToXls
            // 
            resources.ApplyResources(this.biExportReportToXls, "biExportReportToXls");
            this.biExportReportToXls.Id = 39;
            this.biExportReportToXls.ImageIndex = 68;
            this.biExportReportToXls.ItemAppearance.Disabled.FontSizeDelta = ((int)(resources.GetObject("biExportReportToXls.ItemAppearance.Disabled.FontSizeDelta")));
            this.biExportReportToXls.ItemAppearance.Disabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biExportReportToXls.ItemAppearance.Disabled.FontStyleDelta")));
            this.biExportReportToXls.ItemAppearance.Disabled.Options.UseFont = true;
            this.biExportReportToXls.ItemAppearance.Normal.FontSizeDelta = ((int)(resources.GetObject("biExportReportToXls.ItemAppearance.Normal.FontSizeDelta")));
            this.biExportReportToXls.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biExportReportToXls.ItemAppearance.Normal.FontStyleDelta")));
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
            this.biExportReportToRtf.ItemAppearance.Disabled.FontSizeDelta = ((int)(resources.GetObject("biExportReportToRtf.ItemAppearance.Disabled.FontSizeDelta")));
            this.biExportReportToRtf.ItemAppearance.Disabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biExportReportToRtf.ItemAppearance.Disabled.FontStyleDelta")));
            this.biExportReportToRtf.ItemAppearance.Disabled.Options.UseFont = true;
            this.biExportReportToRtf.ItemAppearance.Normal.FontSizeDelta = ((int)(resources.GetObject("biExportReportToRtf.ItemAppearance.Normal.FontSizeDelta")));
            this.biExportReportToRtf.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biExportReportToRtf.ItemAppearance.Normal.FontStyleDelta")));
            this.biExportReportToRtf.ItemAppearance.Normal.Options.UseFont = true;
            this.biExportReportToRtf.Name = "biExportReportToRtf";
            this.biExportReportToRtf.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biExportReportToRtf_ItemClick);
            // 
            // biExportReportToPdf
            // 
            resources.ApplyResources(this.biExportReportToPdf, "biExportReportToPdf");
            this.biExportReportToPdf.Id = 41;
            this.biExportReportToPdf.ImageIndex = 48;
            this.biExportReportToPdf.ItemAppearance.Disabled.FontSizeDelta = ((int)(resources.GetObject("biExportReportToPdf.ItemAppearance.Disabled.FontSizeDelta")));
            this.biExportReportToPdf.ItemAppearance.Disabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biExportReportToPdf.ItemAppearance.Disabled.FontStyleDelta")));
            this.biExportReportToPdf.ItemAppearance.Disabled.Options.UseFont = true;
            this.biExportReportToPdf.ItemAppearance.Normal.FontSizeDelta = ((int)(resources.GetObject("biExportReportToPdf.ItemAppearance.Normal.FontSizeDelta")));
            this.biExportReportToPdf.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biExportReportToPdf.ItemAppearance.Normal.FontStyleDelta")));
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
            this.biExportQuery.MenuAppearance.HeaderItemAppearance.FontSizeDelta = ((int)(resources.GetObject("biExportQuery.MenuAppearance.HeaderItemAppearance.FontSizeDelta")));
            this.biExportQuery.MenuAppearance.HeaderItemAppearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biExportQuery.MenuAppearance.HeaderItemAppearance.FontStyleDelta")));
            this.biExportQuery.MenuAppearance.HeaderItemAppearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("biExportQuery.MenuAppearance.HeaderItemAppearance.GradientMode")));
            this.biExportQuery.MenuAppearance.HeaderItemAppearance.Image = ((System.Drawing.Image)(resources.GetObject("biExportQuery.MenuAppearance.HeaderItemAppearance.Image")));
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
            this.biPrint.MenuAppearance.HeaderItemAppearance.FontSizeDelta = ((int)(resources.GetObject("biPrint.MenuAppearance.HeaderItemAppearance.FontSizeDelta")));
            this.biPrint.MenuAppearance.HeaderItemAppearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biPrint.MenuAppearance.HeaderItemAppearance.FontStyleDelta")));
            this.biPrint.MenuAppearance.HeaderItemAppearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("biPrint.MenuAppearance.HeaderItemAppearance.GradientMode")));
            this.biPrint.MenuAppearance.HeaderItemAppearance.Image = ((System.Drawing.Image)(resources.GetObject("biPrint.MenuAppearance.HeaderItemAppearance.Image")));
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
            this.biOptions.MenuAppearance.HeaderItemAppearance.FontSizeDelta = ((int)(resources.GetObject("biOptions.MenuAppearance.HeaderItemAppearance.FontSizeDelta")));
            this.biOptions.MenuAppearance.HeaderItemAppearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biOptions.MenuAppearance.HeaderItemAppearance.FontStyleDelta")));
            this.biOptions.MenuAppearance.HeaderItemAppearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("biOptions.MenuAppearance.HeaderItemAppearance.GradientMode")));
            this.biOptions.MenuAppearance.HeaderItemAppearance.Image = ((System.Drawing.Image)(resources.GetObject("biOptions.MenuAppearance.HeaderItemAppearance.Image")));
            this.biOptions.Name = "biOptions";
            // 
            // biShowToolBar
            // 
            resources.ApplyResources(this.biShowToolBar, "biShowToolBar");
            this.biShowToolBar.Checked = true;
            this.biShowToolBar.Id = 55;
            this.biShowToolBar.ItemAppearance.Disabled.FontSizeDelta = ((int)(resources.GetObject("biShowToolBar.ItemAppearance.Disabled.FontSizeDelta")));
            this.biShowToolBar.ItemAppearance.Disabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biShowToolBar.ItemAppearance.Disabled.FontStyleDelta")));
            this.biShowToolBar.ItemAppearance.Disabled.Options.UseFont = true;
            this.biShowToolBar.ItemAppearance.Normal.FontSizeDelta = ((int)(resources.GetObject("biShowToolBar.ItemAppearance.Normal.FontSizeDelta")));
            this.biShowToolBar.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biShowToolBar.ItemAppearance.Normal.FontStyleDelta")));
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
            this.biHelp.ItemAppearance.Disabled.FontSizeDelta = ((int)(resources.GetObject("biHelp.ItemAppearance.Disabled.FontSizeDelta")));
            this.biHelp.ItemAppearance.Disabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biHelp.ItemAppearance.Disabled.FontStyleDelta")));
            this.biHelp.ItemAppearance.Disabled.Options.UseFont = true;
            this.biHelp.ItemAppearance.Normal.FontSizeDelta = ((int)(resources.GetObject("biHelp.ItemAppearance.Normal.FontSizeDelta")));
            this.biHelp.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biHelp.ItemAppearance.Normal.FontStyleDelta")));
            this.biHelp.ItemAppearance.Normal.Options.UseFont = true;
            this.biHelp.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biInternalHelp)});
            this.biHelp.MenuAppearance.HeaderItemAppearance.FontSizeDelta = ((int)(resources.GetObject("biHelp.MenuAppearance.HeaderItemAppearance.FontSizeDelta")));
            this.biHelp.MenuAppearance.HeaderItemAppearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biHelp.MenuAppearance.HeaderItemAppearance.FontStyleDelta")));
            this.biHelp.MenuAppearance.HeaderItemAppearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("biHelp.MenuAppearance.HeaderItemAppearance.GradientMode")));
            this.biHelp.MenuAppearance.HeaderItemAppearance.Image = ((System.Drawing.Image)(resources.GetObject("biHelp.MenuAppearance.HeaderItemAppearance.Image")));
            this.biHelp.Name = "biHelp";
            // 
            // biInternalHelp
            // 
            resources.ApplyResources(this.biInternalHelp, "biInternalHelp");
            this.biInternalHelp.Id = 28;
            this.biInternalHelp.ImageIndex = 58;
            this.biInternalHelp.ItemAppearance.Disabled.FontSizeDelta = ((int)(resources.GetObject("biInternalHelp.ItemAppearance.Disabled.FontSizeDelta")));
            this.biInternalHelp.ItemAppearance.Disabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biInternalHelp.ItemAppearance.Disabled.FontStyleDelta")));
            this.biInternalHelp.ItemAppearance.Disabled.Options.UseFont = true;
            this.biInternalHelp.ItemAppearance.Normal.FontSizeDelta = ((int)(resources.GetObject("biInternalHelp.ItemAppearance.Normal.FontSizeDelta")));
            this.biInternalHelp.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("biInternalHelp.ItemAppearance.Normal.FontStyleDelta")));
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
            resources.ApplyResources(this.barDockControlTop, "barDockControlTop");
            this.barDockControlTop.Appearance.FontSizeDelta = ((int)(resources.GetObject("barDockControlTop.Appearance.FontSizeDelta")));
            this.barDockControlTop.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("barDockControlTop.Appearance.FontStyleDelta")));
            this.barDockControlTop.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("barDockControlTop.Appearance.GradientMode")));
            this.barDockControlTop.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("barDockControlTop.Appearance.Image")));
            this.barDockControlTop.Appearance.Options.UseFont = true;
            this.barDockControlTop.CausesValidation = false;
            // 
            // barDockControlBottom
            // 
            resources.ApplyResources(this.barDockControlBottom, "barDockControlBottom");
            this.barDockControlBottom.Appearance.FontSizeDelta = ((int)(resources.GetObject("barDockControlBottom.Appearance.FontSizeDelta")));
            this.barDockControlBottom.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("barDockControlBottom.Appearance.FontStyleDelta")));
            this.barDockControlBottom.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("barDockControlBottom.Appearance.GradientMode")));
            this.barDockControlBottom.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("barDockControlBottom.Appearance.Image")));
            this.barDockControlBottom.Appearance.Options.UseFont = true;
            this.barDockControlBottom.CausesValidation = false;
            // 
            // barDockControlLeft
            // 
            resources.ApplyResources(this.barDockControlLeft, "barDockControlLeft");
            this.barDockControlLeft.Appearance.FontSizeDelta = ((int)(resources.GetObject("barDockControlLeft.Appearance.FontSizeDelta")));
            this.barDockControlLeft.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("barDockControlLeft.Appearance.FontStyleDelta")));
            this.barDockControlLeft.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("barDockControlLeft.Appearance.GradientMode")));
            this.barDockControlLeft.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("barDockControlLeft.Appearance.Image")));
            this.barDockControlLeft.Appearance.Options.UseFont = true;
            this.barDockControlLeft.CausesValidation = false;
            // 
            // barDockControlRight
            // 
            resources.ApplyResources(this.barDockControlRight, "barDockControlRight");
            this.barDockControlRight.Appearance.FontSizeDelta = ((int)(resources.GetObject("barDockControlRight.Appearance.FontSizeDelta")));
            this.barDockControlRight.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("barDockControlRight.Appearance.FontStyleDelta")));
            this.barDockControlRight.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("barDockControlRight.Appearance.GradientMode")));
            this.barDockControlRight.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("barDockControlRight.Appearance.Image")));
            this.barDockControlRight.Appearance.Options.UseFont = true;
            this.barDockControlRight.CausesValidation = false;
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
            this.bsGroupDate.MenuAppearance.HeaderItemAppearance.FontSizeDelta = ((int)(resources.GetObject("bsGroupDate.MenuAppearance.HeaderItemAppearance.FontSizeDelta")));
            this.bsGroupDate.MenuAppearance.HeaderItemAppearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("bsGroupDate.MenuAppearance.HeaderItemAppearance.FontStyleDelta")));
            this.bsGroupDate.MenuAppearance.HeaderItemAppearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("bsGroupDate.MenuAppearance.HeaderItemAppearance.GradientMode")));
            this.bsGroupDate.MenuAppearance.HeaderItemAppearance.Image = ((System.Drawing.Image)(resources.GetObject("bsGroupDate.MenuAppearance.HeaderItemAppearance.Image")));
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
            this.barButtonItem1.ItemAppearance.Disabled.FontSizeDelta = ((int)(resources.GetObject("barButtonItem1.ItemAppearance.Disabled.FontSizeDelta")));
            this.barButtonItem1.ItemAppearance.Disabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("barButtonItem1.ItemAppearance.Disabled.FontStyleDelta")));
            this.barButtonItem1.ItemAppearance.Disabled.Options.UseFont = true;
            this.barButtonItem1.ItemAppearance.Normal.FontSizeDelta = ((int)(resources.GetObject("barButtonItem1.ItemAppearance.Normal.FontSizeDelta")));
            this.barButtonItem1.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("barButtonItem1.ItemAppearance.Normal.FontStyleDelta")));
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
            // PivotPopupMenu
            // 
            this.PivotPopupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbEditCaption),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsGroupDate),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbCopyField, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbDeleteCopyField),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbAddMissedValues, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbDeleteMissedValues)});
            this.PivotPopupMenu.Manager = this.barManager;
            this.PivotPopupMenu.MenuAppearance.HeaderItemAppearance.FontSizeDelta = ((int)(resources.GetObject("PivotPopupMenu.MenuAppearance.HeaderItemAppearance.FontSizeDelta")));
            this.PivotPopupMenu.MenuAppearance.HeaderItemAppearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("PivotPopupMenu.MenuAppearance.HeaderItemAppearance.FontStyleDelta")));
            this.PivotPopupMenu.MenuAppearance.HeaderItemAppearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("PivotPopupMenu.MenuAppearance.HeaderItemAppearance.GradientMode")));
            this.PivotPopupMenu.MenuAppearance.HeaderItemAppearance.Image = ((System.Drawing.Image)(resources.GetObject("PivotPopupMenu.MenuAppearance.HeaderItemAppearance.Image")));
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
            resources.ApplyResources(this.TabPageTree, "TabPageTree");
            this.TabPageTree.Controls.Add(this.QueryLayoutTree);
            this.TabPageTree.Name = "TabPageTree";
            // 
            // TabPageEditor
            // 
            resources.ApplyResources(this.TabPageEditor, "TabPageEditor");
            this.TabPageEditor.Controls.Add(this.EditorPanel);
            this.TabPageEditor.Name = "TabPageEditor";
            // 
            // EditorPanel
            // 
            resources.ApplyResources(this.EditorPanel, "EditorPanel");
            this.EditorPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.EditorPanel.Name = "EditorPanel";
            // 
            // TreePopupMenu
            // 
            this.TreePopupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbPopupNewQuery),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbPopupNewLayout),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbPopupNewFolder),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbPopupEditQueryLayoutFolder, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbPopupDeleteQueryLayoutFolder),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbPopupCopyQueryLayout)});
            this.TreePopupMenu.Manager = this.barManager;
            this.TreePopupMenu.MenuAppearance.HeaderItemAppearance.FontSizeDelta = ((int)(resources.GetObject("TreePopupMenu.MenuAppearance.HeaderItemAppearance.FontSizeDelta")));
            this.TreePopupMenu.MenuAppearance.HeaderItemAppearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("TreePopupMenu.MenuAppearance.HeaderItemAppearance.FontStyleDelta")));
            this.TreePopupMenu.MenuAppearance.HeaderItemAppearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("TreePopupMenu.MenuAppearance.HeaderItemAppearance.GradientMode")));
            this.TreePopupMenu.MenuAppearance.HeaderItemAppearance.Image = ((System.Drawing.Image)(resources.GetObject("TreePopupMenu.MenuAppearance.HeaderItemAppearance.Image")));
            this.TreePopupMenu.Name = "TreePopupMenu";
            // 
            // AvrMainForm
            // 
            resources.ApplyResources(this, "$this");
            this.Appearance.FontSizeDelta = ((int)(resources.GetObject("AvrMainForm.Appearance.FontSizeDelta")));
            this.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("AvrMainForm.Appearance.FontStyleDelta")));
            this.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("AvrMainForm.Appearance.GradientMode")));
            this.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("AvrMainForm.Appearance.Image")));
            this.Appearance.Options.UseFont = true;
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
        private DevExpress.XtraBars.BarButtonItem biEditQueryLayout;
        
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
        


    }
}
