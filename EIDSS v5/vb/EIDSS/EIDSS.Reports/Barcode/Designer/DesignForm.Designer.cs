using System.ComponentModel;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UserDesigner;

namespace EIDSS.Reports.Barcode.Designer
{
    public partial class DesignForm : XtraForm
    {
        private DevExpress.XtraReports.UserDesigner.XRDesignBarManager xrDesignBarManager1;
        private Bar bar2;
        private BarSubItem barSubItem1;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem biGetOriginal;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem commandBarItem39;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem biSave;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem commandBarItem40;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem commandBarItem41;
        private BarSubItem barSubItem2;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem biUndo;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem biRedo;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem commandBarItem42;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem commandBarItem43;
        private BarSubItem barSubItem3;
        private DevExpress.XtraReports.UserDesigner.BarReportTabButtonsListItem barReportTabButtonsListItem1;
        private BarSubItem barSubItem4;
        private DevExpress.XtraReports.UserDesigner.XRBarToolbarsListItem xrBarToolbarsListItem1;
        private BarSubItem barSubItem5;
        private DevExpress.XtraReports.UserDesigner.BarDockPanelsListItem barDockPanelsListItem1;
        private BarSubItem barSubItem6;
        private BarSubItem barSubItem7;
        private BarSubItem barSubItem8;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem biJustifyLeft;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem biJustifyCenter;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem biJustifyRight;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem biJustifyJustify;
        private BarSubItem barSubItem9;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem commandBarItem9;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem commandBarItem10;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem commandBarItem11;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem commandBarItem12;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem commandBarItem13;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem commandBarItem14;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem commandBarItem8;
        private BarSubItem barSubItem10;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem commandBarItem15;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem commandBarItem16;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem commandBarItem17;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem commandBarItem18;
        private BarSubItem barSubItem11;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem commandBarItem19;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem commandBarItem20;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem commandBarItem21;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem commandBarItem22;
        private BarSubItem barSubItem12;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem commandBarItem23;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem commandBarItem24;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem commandBarItem25;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem commandBarItem26;
        private BarSubItem barSubItem13;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem commandBarItem27;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem commandBarItem28;
        private BarSubItem barSubItem14;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem commandBarItem29;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem commandBarItem30;
        private BarSubItem barSubItem15;
        private DevExpress.XtraReports.UserDesigner.CommandBarCheckItem commandBarCheckItem1;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem commandBarItem44;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem commandBarItem45;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem commandBarItem46;
        private BarMdiChildrenListItem barMdiChildrenListItem1;
        private BarSubItem bsiLookAndFeel;
        private DevExpress.XtraReports.UserDesigner.DesignBar designBar2;
        private DevExpress.XtraReports.UserDesigner.DesignBar designBar3;
        private BarEditItem biFontName;
        private DevExpress.XtraReports.UserDesigner.RecentlyUsedItemsComboBox recentlyUsedItemsComboBox1;
        private BarEditItem biFontSize;
        private DevExpress.XtraReports.UserDesigner.DesignRepositoryItemComboBox designRepositoryItemComboBox1;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem biZoomOut;
        private DevExpress.XtraReports.UserDesigner.XRZoomBarEditItem biZoom;
        private DevExpress.XtraReports.UserDesigner.DesignRepositoryItemComboBox designRepositoryItemComboBox2;
        private DevExpress.XtraReports.UserDesigner.CommandBarItem biZoomIn;
        private DevExpress.XtraReports.UserDesigner.XRDesignDockManager xrDesignDockManager1;
        private DevExpress.XtraReports.UserDesigner.XRDesignMdiController xrDesignMdiController1;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private CommandBarItem commandBarItem49;
        private DevExpress.XtraBars.Docking.DockPanel panelContainer3;
        private GroupAndSortDockPanel groupAndSortDockPanel1;
        private DesignControlContainer groupAndSortDockPanel1_Container;
        private ErrorListDockPanel errorListDockPanel1;
        private DesignControlContainer errorListDockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel panelContainer1;
        private DevExpress.XtraBars.Docking.DockPanel panelContainer2;
        private ReportExplorerDockPanel reportExplorerDockPanel1;
        private DesignControlContainer reportExplorerDockPanel1_Container;
        private FieldListDockPanel fieldListDockPanel1;
        private DesignControlContainer fieldListDockPanel1_Container;
        private PropertyGridDockPanel propertyGridDockPanel1;
        private DesignControlContainer propertyGridDockPanel1_Container;
        private IContainer components;

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DesignForm));
            DevExpress.XtraReports.UserDesigner.BarInfo barInfo1 = new DevExpress.XtraReports.UserDesigner.BarInfo();
            DevExpress.XtraReports.UserDesigner.XRDesignPanelListener xrDesignPanelListener1 = new DevExpress.XtraReports.UserDesigner.XRDesignPanelListener();
            DevExpress.XtraReports.UserDesigner.XRDesignPanelListener xrDesignPanelListener2 = new DevExpress.XtraReports.UserDesigner.XRDesignPanelListener();
            DevExpress.XtraReports.UserDesigner.XRDesignPanelListener xrDesignPanelListener3 = new DevExpress.XtraReports.UserDesigner.XRDesignPanelListener();
            DevExpress.XtraReports.UserDesigner.XRDesignPanelListener xrDesignPanelListener4 = new DevExpress.XtraReports.UserDesigner.XRDesignPanelListener();
            DevExpress.XtraReports.UserDesigner.XRDesignPanelListener xrDesignPanelListener5 = new DevExpress.XtraReports.UserDesigner.XRDesignPanelListener();
            DevExpress.XtraReports.UserDesigner.XRDesignPanelListener xrDesignPanelListener6 = new DevExpress.XtraReports.UserDesigner.XRDesignPanelListener();
            DevExpress.XtraReports.UserDesigner.XRDesignPanelListener xrDesignPanelListener7 = new DevExpress.XtraReports.UserDesigner.XRDesignPanelListener();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.xrDesignBarManager1 = new DevExpress.XtraReports.UserDesigner.XRDesignBarManager();
            this.designBar2 = new DevExpress.XtraReports.UserDesigner.DesignBar();
            this.biGetOriginal = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.biSave = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.biUndo = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.biRedo = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.biZoomOut = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.biZoom = new DevExpress.XtraReports.UserDesigner.XRZoomBarEditItem();
            this.designRepositoryItemComboBox2 = new DevExpress.XtraReports.UserDesigner.DesignRepositoryItemComboBox();
            this.biZoomIn = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.designBar3 = new DevExpress.XtraReports.UserDesigner.DesignBar();
            this.biFontName = new DevExpress.XtraBars.BarEditItem();
            this.recentlyUsedItemsComboBox1 = new DevExpress.XtraReports.UserDesigner.RecentlyUsedItemsComboBox();
            this.biFontSize = new DevExpress.XtraBars.BarEditItem();
            this.designRepositoryItemComboBox1 = new DevExpress.XtraReports.UserDesigner.DesignRepositoryItemComboBox();
            this.biJustifyLeft = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.biJustifyCenter = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.biJustifyRight = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.biJustifyJustify = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.xrDesignDockManager1 = new DevExpress.XtraReports.UserDesigner.XRDesignDockManager();
            this.panelContainer3 = new DevExpress.XtraBars.Docking.DockPanel();
            this.groupAndSortDockPanel1 = new DevExpress.XtraReports.UserDesigner.GroupAndSortDockPanel();
            this.groupAndSortDockPanel1_Container = new DevExpress.XtraReports.UserDesigner.DesignControlContainer();
            this.errorListDockPanel1 = new DevExpress.XtraReports.UserDesigner.ErrorListDockPanel();
            this.errorListDockPanel1_Container = new DevExpress.XtraReports.UserDesigner.DesignControlContainer();
            this.panelContainer1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.panelContainer2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.reportExplorerDockPanel1 = new DevExpress.XtraReports.UserDesigner.ReportExplorerDockPanel();
            this.reportExplorerDockPanel1_Container = new DevExpress.XtraReports.UserDesigner.DesignControlContainer();
            this.fieldListDockPanel1 = new DevExpress.XtraReports.UserDesigner.FieldListDockPanel();
            this.fieldListDockPanel1_Container = new DevExpress.XtraReports.UserDesigner.DesignControlContainer();
            this.propertyGridDockPanel1 = new DevExpress.XtraReports.UserDesigner.PropertyGridDockPanel();
            this.propertyGridDockPanel1_Container = new DevExpress.XtraReports.UserDesigner.DesignControlContainer();
            this.commandBarItem8 = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.commandBarItem9 = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.commandBarItem10 = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.commandBarItem11 = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.commandBarItem12 = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.commandBarItem13 = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.commandBarItem14 = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.commandBarItem15 = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.commandBarItem16 = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.commandBarItem17 = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.commandBarItem18 = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.commandBarItem19 = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.commandBarItem20 = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.commandBarItem21 = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.commandBarItem22 = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.commandBarItem23 = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.commandBarItem24 = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.commandBarItem25 = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.commandBarItem26 = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.commandBarItem27 = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.commandBarItem28 = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.commandBarItem29 = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.commandBarItem30 = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.commandBarItem39 = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.commandBarItem40 = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.commandBarItem49 = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.commandBarItem41 = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.commandBarItem42 = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.commandBarItem43 = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.barReportTabButtonsListItem1 = new DevExpress.XtraReports.UserDesigner.BarReportTabButtonsListItem();
            this.barSubItem4 = new DevExpress.XtraBars.BarSubItem();
            this.xrBarToolbarsListItem1 = new DevExpress.XtraReports.UserDesigner.XRBarToolbarsListItem();
            this.barSubItem5 = new DevExpress.XtraBars.BarSubItem();
            this.barDockPanelsListItem1 = new DevExpress.XtraReports.UserDesigner.BarDockPanelsListItem();
            this.barSubItem6 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem7 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem8 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem9 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem10 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem11 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem12 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem13 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem14 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem15 = new DevExpress.XtraBars.BarSubItem();
            this.commandBarCheckItem1 = new DevExpress.XtraReports.UserDesigner.CommandBarCheckItem();
            this.commandBarItem44 = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.commandBarItem45 = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.commandBarItem46 = new DevExpress.XtraReports.UserDesigner.CommandBarItem();
            this.barMdiChildrenListItem1 = new DevExpress.XtraBars.BarMdiChildrenListItem();
            this.bsiLookAndFeel = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.xrDesignMdiController1 = new DevExpress.XtraReports.UserDesigner.XRDesignMdiController();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.HidePopupTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.xrDesignBarManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.designRepositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentlyUsedItemsComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.designRepositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrDesignDockManager1)).BeginInit();
            this.panelContainer3.SuspendLayout();
            this.groupAndSortDockPanel1.SuspendLayout();
            this.errorListDockPanel1.SuspendLayout();
            this.panelContainer1.SuspendLayout();
            this.panelContainer2.SuspendLayout();
            this.reportExplorerDockPanel1.SuspendLayout();
            this.fieldListDockPanel1.SuspendLayout();
            this.propertyGridDockPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // bar2
            // 
            this.bar2.BarName = "Toolbox";
            this.bar2.DockCol = 1;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.FloatLocation = new System.Drawing.Point(202, 248);
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DisableClose = true;
            this.bar2.OptionsBar.DisableCustomization = true;
            this.bar2.OptionsBar.DrawDragBorder = false;
            resources.ApplyResources(this.bar2, "bar2");
            // 
            // xrDesignBarManager1
            // 
            this.xrDesignBarManager1.AllowCustomization = false;
            this.xrDesignBarManager1.AllowMoveBarOnToolbar = false;
            this.xrDesignBarManager1.AllowQuickCustomization = false;
            barInfo1.Bar = this.bar2;
            barInfo1.ToolboxType = DevExpress.XtraReports.UserDesigner.ToolboxType.Custom;
            this.xrDesignBarManager1.BarInfos.AddRange(new DevExpress.XtraReports.UserDesigner.BarInfo[] {
            barInfo1});
            this.xrDesignBarManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.designBar2,
            this.designBar3,
            this.bar2});
            this.xrDesignBarManager1.DockControls.Add(this.barDockControlTop);
            this.xrDesignBarManager1.DockControls.Add(this.barDockControlBottom);
            this.xrDesignBarManager1.DockControls.Add(this.barDockControlLeft);
            this.xrDesignBarManager1.DockControls.Add(this.barDockControlRight);
            this.xrDesignBarManager1.DockManager = this.xrDesignDockManager1;
            this.xrDesignBarManager1.FontNameBox = this.recentlyUsedItemsComboBox1;
            this.xrDesignBarManager1.FontNameEdit = this.biFontName;
            this.xrDesignBarManager1.FontSizeBox = this.designRepositoryItemComboBox1;
            this.xrDesignBarManager1.FontSizeEdit = this.biFontSize;
            this.xrDesignBarManager1.Form = this;
            this.xrDesignBarManager1.FormattingToolbar = this.designBar3;
            this.xrDesignBarManager1.HintStaticItem = null;
            this.xrDesignBarManager1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("xrDesignBarManager1.ImageStream")));
            this.xrDesignBarManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.biFontName,
            this.biFontSize,
            this.biJustifyLeft,
            this.biJustifyCenter,
            this.biJustifyRight,
            this.biJustifyJustify,
            this.commandBarItem8,
            this.commandBarItem9,
            this.commandBarItem10,
            this.commandBarItem11,
            this.commandBarItem12,
            this.commandBarItem13,
            this.commandBarItem14,
            this.commandBarItem15,
            this.commandBarItem16,
            this.commandBarItem17,
            this.commandBarItem18,
            this.commandBarItem19,
            this.commandBarItem20,
            this.commandBarItem21,
            this.commandBarItem22,
            this.commandBarItem23,
            this.commandBarItem24,
            this.commandBarItem25,
            this.commandBarItem26,
            this.commandBarItem27,
            this.commandBarItem28,
            this.commandBarItem29,
            this.commandBarItem30,
            this.biGetOriginal,
            this.biSave,
            this.biUndo,
            this.biRedo,
            this.barSubItem1,
            this.barSubItem2,
            this.barSubItem3,
            this.barReportTabButtonsListItem1,
            this.barSubItem4,
            this.xrBarToolbarsListItem1,
            this.barSubItem5,
            this.barDockPanelsListItem1,
            this.barSubItem6,
            this.barSubItem7,
            this.barSubItem8,
            this.barSubItem9,
            this.barSubItem10,
            this.barSubItem11,
            this.barSubItem12,
            this.barSubItem13,
            this.barSubItem14,
            this.commandBarItem39,
            this.commandBarItem40,
            this.commandBarItem41,
            this.commandBarItem42,
            this.commandBarItem43,
            this.barSubItem15,
            this.commandBarCheckItem1,
            this.commandBarItem44,
            this.commandBarItem45,
            this.commandBarItem46,
            this.barMdiChildrenListItem1,
            this.biZoomOut,
            this.biZoom,
            this.biZoomIn,
            this.bsiLookAndFeel,
            this.commandBarItem49,
            this.barButtonItem1});
            this.xrDesignBarManager1.LayoutToolbar = null;
            this.xrDesignBarManager1.MaxItemId = 80;
            this.xrDesignBarManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.recentlyUsedItemsComboBox1,
            this.designRepositoryItemComboBox1,
            this.designRepositoryItemComboBox2});
            this.xrDesignBarManager1.Toolbar = this.designBar2;
            this.xrDesignBarManager1.Updates.AddRange(new string[] {
            "Toolbox"});
            this.xrDesignBarManager1.ZoomItem = this.biZoom;
            // 
            // designBar2
            // 
            this.designBar2.BarName = "Toolbar";
            this.designBar2.DockCol = 0;
            this.designBar2.DockRow = 0;
            this.designBar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.designBar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biGetOriginal),
            new DevExpress.XtraBars.LinkPersistInfo(this.biSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.biUndo, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.biRedo),
            new DevExpress.XtraBars.LinkPersistInfo(this.biZoomOut, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.biZoom),
            new DevExpress.XtraBars.LinkPersistInfo(this.biZoomIn)});
            this.designBar2.OptionsBar.AllowQuickCustomization = false;
            this.designBar2.OptionsBar.DisableClose = true;
            this.designBar2.OptionsBar.DisableCustomization = true;
            this.designBar2.OptionsBar.DrawDragBorder = false;
            resources.ApplyResources(this.designBar2, "designBar2");
            // 
            // biGetOriginal
            // 
            resources.ApplyResources(this.biGetOriginal, "biGetOriginal");
            this.biGetOriginal.Enabled = false;
            this.biGetOriginal.Glyph = global::EIDSS.Reports.Properties.Resources.restore;
            this.biGetOriginal.Id = 34;
            this.biGetOriginal.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R));
            this.biGetOriginal.Name = "biGetOriginal";
            this.biGetOriginal.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biRestoreDefault_ItemClick);
            // 
            // biSave
            // 
            resources.ApplyResources(this.biSave, "biSave");
            this.biSave.Enabled = false;
            this.biSave.Id = 36;
            this.biSave.ImageIndex = 11;
            this.biSave.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.biSave.Name = "biSave";
            this.biSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biSave_ItemClick);
            // 
            // biUndo
            // 
            resources.ApplyResources(this.biUndo, "biUndo");
            this.biUndo.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.Undo;
            this.biUndo.Enabled = false;
            this.biUndo.Id = 40;
            this.biUndo.ImageIndex = 15;
            this.biUndo.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z));
            this.biUndo.Name = "biUndo";
            // 
            // biRedo
            // 
            resources.ApplyResources(this.biRedo, "biRedo");
            this.biRedo.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.Redo;
            this.biRedo.Enabled = false;
            this.biRedo.Id = 41;
            this.biRedo.ImageIndex = 16;
            this.biRedo.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y));
            this.biRedo.Name = "biRedo";
            // 
            // biZoomOut
            // 
            resources.ApplyResources(this.biZoomOut, "biZoomOut");
            this.biZoomOut.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.ZoomOut;
            this.biZoomOut.Enabled = false;
            this.biZoomOut.Id = 71;
            this.biZoomOut.ImageIndex = 43;
            this.biZoomOut.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Subtract));
            this.biZoomOut.Name = "biZoomOut";
            // 
            // biZoom
            // 
            resources.ApplyResources(this.biZoom, "biZoom");
            this.biZoom.Edit = this.designRepositoryItemComboBox2;
            this.biZoom.Enabled = false;
            this.biZoom.Id = 72;
            this.biZoom.Name = "biZoom";
            // 
            // designRepositoryItemComboBox2
            // 
            this.designRepositoryItemComboBox2.AutoComplete = false;
            this.designRepositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("designRepositoryItemComboBox2.Buttons"))))});
            this.designRepositoryItemComboBox2.Name = "designRepositoryItemComboBox2";
            // 
            // biZoomIn
            // 
            resources.ApplyResources(this.biZoomIn, "biZoomIn");
            this.biZoomIn.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.ZoomIn;
            this.biZoomIn.Enabled = false;
            this.biZoomIn.Id = 73;
            this.biZoomIn.ImageIndex = 44;
            this.biZoomIn.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Add));
            this.biZoomIn.Name = "biZoomIn";
            // 
            // designBar3
            // 
            this.designBar3.BarName = "Formatting Toolbar";
            this.designBar3.DockCol = 2;
            this.designBar3.DockRow = 0;
            this.designBar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.designBar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.None, false, this.biFontName, false),
            new DevExpress.XtraBars.LinkPersistInfo(this.biFontSize),
            new DevExpress.XtraBars.LinkPersistInfo(this.biJustifyLeft, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.biJustifyCenter),
            new DevExpress.XtraBars.LinkPersistInfo(this.biJustifyRight),
            new DevExpress.XtraBars.LinkPersistInfo(this.biJustifyJustify)});
            this.designBar3.OptionsBar.DisableClose = true;
            this.designBar3.OptionsBar.DisableCustomization = true;
            this.designBar3.OptionsBar.DrawDragBorder = false;
            resources.ApplyResources(this.designBar3, "designBar3");
            // 
            // biFontName
            // 
            resources.ApplyResources(this.biFontName, "biFontName");
            this.biFontName.Edit = this.recentlyUsedItemsComboBox1;
            this.biFontName.Id = 0;
            this.biFontName.Name = "biFontName";
            // 
            // recentlyUsedItemsComboBox1
            // 
            resources.ApplyResources(this.recentlyUsedItemsComboBox1, "recentlyUsedItemsComboBox1");
            this.recentlyUsedItemsComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("recentlyUsedItemsComboBox1.Buttons"))))});
            this.recentlyUsedItemsComboBox1.DropDownRows = 12;
            this.recentlyUsedItemsComboBox1.Name = "recentlyUsedItemsComboBox1";
            // 
            // biFontSize
            // 
            resources.ApplyResources(this.biFontSize, "biFontSize");
            this.biFontSize.Edit = this.designRepositoryItemComboBox1;
            this.biFontSize.Id = 1;
            this.biFontSize.Name = "biFontSize";
            // 
            // designRepositoryItemComboBox1
            // 
            resources.ApplyResources(this.designRepositoryItemComboBox1, "designRepositoryItemComboBox1");
            this.designRepositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("designRepositoryItemComboBox1.Buttons"))))});
            this.designRepositoryItemComboBox1.Name = "designRepositoryItemComboBox1";
            // 
            // biJustifyLeft
            // 
            resources.ApplyResources(this.biJustifyLeft, "biJustifyLeft");
            this.biJustifyLeft.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.JustifyLeft;
            this.biJustifyLeft.Enabled = false;
            this.biJustifyLeft.Id = 7;
            this.biJustifyLeft.ImageIndex = 5;
            this.biJustifyLeft.Name = "biJustifyLeft";
            // 
            // biJustifyCenter
            // 
            resources.ApplyResources(this.biJustifyCenter, "biJustifyCenter");
            this.biJustifyCenter.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.JustifyCenter;
            this.biJustifyCenter.Enabled = false;
            this.biJustifyCenter.Id = 8;
            this.biJustifyCenter.ImageIndex = 6;
            this.biJustifyCenter.Name = "biJustifyCenter";
            // 
            // biJustifyRight
            // 
            resources.ApplyResources(this.biJustifyRight, "biJustifyRight");
            this.biJustifyRight.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.JustifyRight;
            this.biJustifyRight.Enabled = false;
            this.biJustifyRight.Id = 9;
            this.biJustifyRight.ImageIndex = 7;
            this.biJustifyRight.Name = "biJustifyRight";
            // 
            // biJustifyJustify
            // 
            resources.ApplyResources(this.biJustifyJustify, "biJustifyJustify");
            this.biJustifyJustify.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.JustifyJustify;
            this.biJustifyJustify.Enabled = false;
            this.biJustifyJustify.Id = 10;
            this.biJustifyJustify.ImageIndex = 8;
            this.biJustifyJustify.Name = "biJustifyJustify";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            resources.ApplyResources(this.barDockControlTop, "barDockControlTop");
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            resources.ApplyResources(this.barDockControlBottom, "barDockControlBottom");
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            resources.ApplyResources(this.barDockControlLeft, "barDockControlLeft");
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            resources.ApplyResources(this.barDockControlRight, "barDockControlRight");
            // 
            // xrDesignDockManager1
            // 
            this.xrDesignDockManager1.Form = this;
            this.xrDesignDockManager1.HiddenPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.panelContainer3,
            this.panelContainer1});
            this.xrDesignDockManager1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("xrDesignDockManager1.ImageStream")));
            this.xrDesignDockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // panelContainer3
            // 
            this.panelContainer3.ActiveChild = this.groupAndSortDockPanel1;
            this.panelContainer3.Controls.Add(this.groupAndSortDockPanel1);
            this.panelContainer3.Controls.Add(this.errorListDockPanel1);
            this.panelContainer3.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.panelContainer3.ID = new System.Guid("6027d502-d4b1-488d-b50b-ac2fbbd40bf8");
            this.panelContainer3.ImageIndex = 1;
            resources.ApplyResources(this.panelContainer3, "panelContainer3");
            this.panelContainer3.Name = "panelContainer3";
            this.panelContainer3.OriginalSize = new System.Drawing.Size(200, 160);
            this.panelContainer3.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.panelContainer3.SavedIndex = 1;
            this.panelContainer3.Tabbed = true;
            this.panelContainer3.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // groupAndSortDockPanel1
            // 
            this.groupAndSortDockPanel1.Controls.Add(this.groupAndSortDockPanel1_Container);
            this.groupAndSortDockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.groupAndSortDockPanel1.ID = new System.Guid("4bab159e-c495-4d67-87dc-f4e895da443e");
            this.groupAndSortDockPanel1.ImageIndex = 1;
            resources.ApplyResources(this.groupAndSortDockPanel1, "groupAndSortDockPanel1");
            this.groupAndSortDockPanel1.Name = "groupAndSortDockPanel1";
            this.groupAndSortDockPanel1.OriginalSize = new System.Drawing.Size(620, 106);
            this.groupAndSortDockPanel1.XRDesignPanel = null;
            // 
            // groupAndSortDockPanel1_Container
            // 
            resources.ApplyResources(this.groupAndSortDockPanel1_Container, "groupAndSortDockPanel1_Container");
            this.groupAndSortDockPanel1_Container.Name = "groupAndSortDockPanel1_Container";
            // 
            // errorListDockPanel1
            // 
            this.errorListDockPanel1.Controls.Add(this.errorListDockPanel1_Container);
            this.errorListDockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.errorListDockPanel1.ID = new System.Guid("5a9a01fd-6e95-4e81-a8c4-ac63153d7488");
            this.errorListDockPanel1.ImageIndex = 5;
            resources.ApplyResources(this.errorListDockPanel1, "errorListDockPanel1");
            this.errorListDockPanel1.Name = "errorListDockPanel1";
            this.errorListDockPanel1.OriginalSize = new System.Drawing.Size(620, 106);
            this.errorListDockPanel1.XRDesignPanel = null;
            // 
            // errorListDockPanel1_Container
            // 
            resources.ApplyResources(this.errorListDockPanel1_Container, "errorListDockPanel1_Container");
            this.errorListDockPanel1_Container.Name = "errorListDockPanel1_Container";
            // 
            // panelContainer1
            // 
            this.panelContainer1.Controls.Add(this.panelContainer2);
            this.panelContainer1.Controls.Add(this.propertyGridDockPanel1);
            this.panelContainer1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.panelContainer1.ID = new System.Guid("73163da5-9eeb-4b18-8992-c9a9a9f93986");
            resources.ApplyResources(this.panelContainer1, "panelContainer1");
            this.panelContainer1.Name = "panelContainer1";
            this.panelContainer1.OriginalSize = new System.Drawing.Size(250, 200);
            this.panelContainer1.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.panelContainer1.SavedIndex = 0;
            this.panelContainer1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // panelContainer2
            // 
            this.panelContainer2.ActiveChild = this.reportExplorerDockPanel1;
            this.panelContainer2.Controls.Add(this.reportExplorerDockPanel1);
            this.panelContainer2.Controls.Add(this.fieldListDockPanel1);
            this.panelContainer2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.panelContainer2.ID = new System.Guid("ec598d35-f04f-46c8-8b97-6b28f6c4dc4f");
            this.panelContainer2.ImageIndex = 3;
            resources.ApplyResources(this.panelContainer2, "panelContainer2");
            this.panelContainer2.Name = "panelContainer2";
            this.panelContainer2.OriginalSize = new System.Drawing.Size(250, 187);
            this.panelContainer2.Tabbed = true;
            // 
            // reportExplorerDockPanel1
            // 
            this.reportExplorerDockPanel1.Controls.Add(this.reportExplorerDockPanel1_Container);
            this.reportExplorerDockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.reportExplorerDockPanel1.ID = new System.Guid("fb3ec6cc-3b9b-4b9c-91cf-cff78c1edbf1");
            this.reportExplorerDockPanel1.ImageIndex = 3;
            resources.ApplyResources(this.reportExplorerDockPanel1, "reportExplorerDockPanel1");
            this.reportExplorerDockPanel1.Name = "reportExplorerDockPanel1";
            this.reportExplorerDockPanel1.OriginalSize = new System.Drawing.Size(244, 133);
            this.reportExplorerDockPanel1.XRDesignPanel = null;
            // 
            // reportExplorerDockPanel1_Container
            // 
            resources.ApplyResources(this.reportExplorerDockPanel1_Container, "reportExplorerDockPanel1_Container");
            this.reportExplorerDockPanel1_Container.Name = "reportExplorerDockPanel1_Container";
            // 
            // fieldListDockPanel1
            // 
            this.fieldListDockPanel1.Controls.Add(this.fieldListDockPanel1_Container);
            this.fieldListDockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.fieldListDockPanel1.ID = new System.Guid("faf69838-a93f-4114-83e8-d0d09cc5ce95");
            this.fieldListDockPanel1.ImageIndex = 0;
            resources.ApplyResources(this.fieldListDockPanel1, "fieldListDockPanel1");
            this.fieldListDockPanel1.Name = "fieldListDockPanel1";
            this.fieldListDockPanel1.OriginalSize = new System.Drawing.Size(244, 133);
            this.fieldListDockPanel1.XRDesignPanel = null;
            // 
            // fieldListDockPanel1_Container
            // 
            resources.ApplyResources(this.fieldListDockPanel1_Container, "fieldListDockPanel1_Container");
            this.fieldListDockPanel1_Container.Name = "fieldListDockPanel1_Container";
            // 
            // propertyGridDockPanel1
            // 
            this.propertyGridDockPanel1.Controls.Add(this.propertyGridDockPanel1_Container);
            this.propertyGridDockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.propertyGridDockPanel1.ID = new System.Guid("b38d12c3-cd06-4dec-b93d-63a0088e495a");
            this.propertyGridDockPanel1.ImageIndex = 2;
            resources.ApplyResources(this.propertyGridDockPanel1, "propertyGridDockPanel1");
            this.propertyGridDockPanel1.Name = "propertyGridDockPanel1";
            this.propertyGridDockPanel1.OriginalSize = new System.Drawing.Size(250, 187);
            this.propertyGridDockPanel1.XRDesignPanel = null;
            // 
            // propertyGridDockPanel1_Container
            // 
            resources.ApplyResources(this.propertyGridDockPanel1_Container, "propertyGridDockPanel1_Container");
            this.propertyGridDockPanel1_Container.Name = "propertyGridDockPanel1_Container";
            // 
            // commandBarItem8
            // 
            resources.ApplyResources(this.commandBarItem8, "commandBarItem8");
            this.commandBarItem8.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.AlignToGrid;
            this.commandBarItem8.Enabled = false;
            this.commandBarItem8.Id = 11;
            this.commandBarItem8.ImageIndex = 17;
            this.commandBarItem8.Name = "commandBarItem8";
            // 
            // commandBarItem9
            // 
            resources.ApplyResources(this.commandBarItem9, "commandBarItem9");
            this.commandBarItem9.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.AlignLeft;
            this.commandBarItem9.Enabled = false;
            this.commandBarItem9.Id = 12;
            this.commandBarItem9.ImageIndex = 18;
            this.commandBarItem9.Name = "commandBarItem9";
            // 
            // commandBarItem10
            // 
            resources.ApplyResources(this.commandBarItem10, "commandBarItem10");
            this.commandBarItem10.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.AlignVerticalCenters;
            this.commandBarItem10.Enabled = false;
            this.commandBarItem10.Id = 13;
            this.commandBarItem10.ImageIndex = 19;
            this.commandBarItem10.Name = "commandBarItem10";
            // 
            // commandBarItem11
            // 
            resources.ApplyResources(this.commandBarItem11, "commandBarItem11");
            this.commandBarItem11.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.AlignRight;
            this.commandBarItem11.Enabled = false;
            this.commandBarItem11.Id = 14;
            this.commandBarItem11.ImageIndex = 20;
            this.commandBarItem11.Name = "commandBarItem11";
            // 
            // commandBarItem12
            // 
            resources.ApplyResources(this.commandBarItem12, "commandBarItem12");
            this.commandBarItem12.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.AlignTop;
            this.commandBarItem12.Enabled = false;
            this.commandBarItem12.Id = 15;
            this.commandBarItem12.ImageIndex = 21;
            this.commandBarItem12.Name = "commandBarItem12";
            // 
            // commandBarItem13
            // 
            resources.ApplyResources(this.commandBarItem13, "commandBarItem13");
            this.commandBarItem13.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.AlignHorizontalCenters;
            this.commandBarItem13.Enabled = false;
            this.commandBarItem13.Id = 16;
            this.commandBarItem13.ImageIndex = 22;
            this.commandBarItem13.Name = "commandBarItem13";
            // 
            // commandBarItem14
            // 
            resources.ApplyResources(this.commandBarItem14, "commandBarItem14");
            this.commandBarItem14.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.AlignBottom;
            this.commandBarItem14.Enabled = false;
            this.commandBarItem14.Id = 17;
            this.commandBarItem14.ImageIndex = 23;
            this.commandBarItem14.Name = "commandBarItem14";
            // 
            // commandBarItem15
            // 
            resources.ApplyResources(this.commandBarItem15, "commandBarItem15");
            this.commandBarItem15.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.SizeToControlWidth;
            this.commandBarItem15.Enabled = false;
            this.commandBarItem15.Id = 18;
            this.commandBarItem15.ImageIndex = 24;
            this.commandBarItem15.Name = "commandBarItem15";
            // 
            // commandBarItem16
            // 
            resources.ApplyResources(this.commandBarItem16, "commandBarItem16");
            this.commandBarItem16.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.SizeToGrid;
            this.commandBarItem16.Enabled = false;
            this.commandBarItem16.Id = 19;
            this.commandBarItem16.ImageIndex = 25;
            this.commandBarItem16.Name = "commandBarItem16";
            // 
            // commandBarItem17
            // 
            resources.ApplyResources(this.commandBarItem17, "commandBarItem17");
            this.commandBarItem17.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.SizeToControlHeight;
            this.commandBarItem17.Enabled = false;
            this.commandBarItem17.Id = 20;
            this.commandBarItem17.ImageIndex = 26;
            this.commandBarItem17.Name = "commandBarItem17";
            // 
            // commandBarItem18
            // 
            resources.ApplyResources(this.commandBarItem18, "commandBarItem18");
            this.commandBarItem18.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.SizeToControl;
            this.commandBarItem18.Enabled = false;
            this.commandBarItem18.Id = 21;
            this.commandBarItem18.ImageIndex = 27;
            this.commandBarItem18.Name = "commandBarItem18";
            // 
            // commandBarItem19
            // 
            resources.ApplyResources(this.commandBarItem19, "commandBarItem19");
            this.commandBarItem19.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.HorizSpaceMakeEqual;
            this.commandBarItem19.Enabled = false;
            this.commandBarItem19.Id = 22;
            this.commandBarItem19.ImageIndex = 28;
            this.commandBarItem19.Name = "commandBarItem19";
            // 
            // commandBarItem20
            // 
            resources.ApplyResources(this.commandBarItem20, "commandBarItem20");
            this.commandBarItem20.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.HorizSpaceIncrease;
            this.commandBarItem20.Enabled = false;
            this.commandBarItem20.Id = 23;
            this.commandBarItem20.ImageIndex = 29;
            this.commandBarItem20.Name = "commandBarItem20";
            // 
            // commandBarItem21
            // 
            resources.ApplyResources(this.commandBarItem21, "commandBarItem21");
            this.commandBarItem21.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.HorizSpaceDecrease;
            this.commandBarItem21.Enabled = false;
            this.commandBarItem21.Id = 24;
            this.commandBarItem21.ImageIndex = 30;
            this.commandBarItem21.Name = "commandBarItem21";
            // 
            // commandBarItem22
            // 
            resources.ApplyResources(this.commandBarItem22, "commandBarItem22");
            this.commandBarItem22.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.HorizSpaceConcatenate;
            this.commandBarItem22.Enabled = false;
            this.commandBarItem22.Id = 25;
            this.commandBarItem22.ImageIndex = 31;
            this.commandBarItem22.Name = "commandBarItem22";
            // 
            // commandBarItem23
            // 
            resources.ApplyResources(this.commandBarItem23, "commandBarItem23");
            this.commandBarItem23.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.VertSpaceMakeEqual;
            this.commandBarItem23.Enabled = false;
            this.commandBarItem23.Id = 26;
            this.commandBarItem23.ImageIndex = 32;
            this.commandBarItem23.Name = "commandBarItem23";
            // 
            // commandBarItem24
            // 
            resources.ApplyResources(this.commandBarItem24, "commandBarItem24");
            this.commandBarItem24.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.VertSpaceIncrease;
            this.commandBarItem24.Enabled = false;
            this.commandBarItem24.Id = 27;
            this.commandBarItem24.ImageIndex = 33;
            this.commandBarItem24.Name = "commandBarItem24";
            // 
            // commandBarItem25
            // 
            resources.ApplyResources(this.commandBarItem25, "commandBarItem25");
            this.commandBarItem25.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.VertSpaceDecrease;
            this.commandBarItem25.Enabled = false;
            this.commandBarItem25.Id = 28;
            this.commandBarItem25.ImageIndex = 34;
            this.commandBarItem25.Name = "commandBarItem25";
            // 
            // commandBarItem26
            // 
            resources.ApplyResources(this.commandBarItem26, "commandBarItem26");
            this.commandBarItem26.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.VertSpaceConcatenate;
            this.commandBarItem26.Enabled = false;
            this.commandBarItem26.Id = 29;
            this.commandBarItem26.ImageIndex = 35;
            this.commandBarItem26.Name = "commandBarItem26";
            // 
            // commandBarItem27
            // 
            resources.ApplyResources(this.commandBarItem27, "commandBarItem27");
            this.commandBarItem27.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.CenterHorizontally;
            this.commandBarItem27.Enabled = false;
            this.commandBarItem27.Id = 30;
            this.commandBarItem27.ImageIndex = 36;
            this.commandBarItem27.Name = "commandBarItem27";
            // 
            // commandBarItem28
            // 
            resources.ApplyResources(this.commandBarItem28, "commandBarItem28");
            this.commandBarItem28.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.CenterVertically;
            this.commandBarItem28.Enabled = false;
            this.commandBarItem28.Id = 31;
            this.commandBarItem28.ImageIndex = 37;
            this.commandBarItem28.Name = "commandBarItem28";
            // 
            // commandBarItem29
            // 
            resources.ApplyResources(this.commandBarItem29, "commandBarItem29");
            this.commandBarItem29.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.BringToFront;
            this.commandBarItem29.Enabled = false;
            this.commandBarItem29.Id = 32;
            this.commandBarItem29.ImageIndex = 38;
            this.commandBarItem29.Name = "commandBarItem29";
            // 
            // commandBarItem30
            // 
            resources.ApplyResources(this.commandBarItem30, "commandBarItem30");
            this.commandBarItem30.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.SendToBack;
            this.commandBarItem30.Enabled = false;
            this.commandBarItem30.Id = 33;
            this.commandBarItem30.ImageIndex = 39;
            this.commandBarItem30.Name = "commandBarItem30";
            // 
            // barSubItem1
            // 
            resources.ApplyResources(this.barSubItem1, "barSubItem1");
            this.barSubItem1.Id = 43;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biGetOriginal),
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarItem39),
            new DevExpress.XtraBars.LinkPersistInfo(this.biSave, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarItem40),
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarItem49),
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarItem41, true)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // commandBarItem39
            // 
            resources.ApplyResources(this.commandBarItem39, "commandBarItem39");
            this.commandBarItem39.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.NewReportWizard;
            this.commandBarItem39.Enabled = false;
            this.commandBarItem39.Id = 60;
            this.commandBarItem39.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W));
            this.commandBarItem39.Name = "commandBarItem39";
            // 
            // commandBarItem40
            // 
            resources.ApplyResources(this.commandBarItem40, "commandBarItem40");
            this.commandBarItem40.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.SaveFileAs;
            this.commandBarItem40.Enabled = false;
            this.commandBarItem40.Id = 61;
            this.commandBarItem40.Name = "commandBarItem40";
            // 
            // commandBarItem49
            // 
            resources.ApplyResources(this.commandBarItem49, "commandBarItem49");
            this.commandBarItem49.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.Close;
            this.commandBarItem49.Enabled = false;
            this.commandBarItem49.Id = 78;
            this.commandBarItem49.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4));
            this.commandBarItem49.Name = "commandBarItem49";
            // 
            // commandBarItem41
            // 
            resources.ApplyResources(this.commandBarItem41, "commandBarItem41");
            this.commandBarItem41.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.Exit;
            this.commandBarItem41.Enabled = false;
            this.commandBarItem41.Id = 62;
            this.commandBarItem41.Name = "commandBarItem41";
            // 
            // barSubItem2
            // 
            resources.ApplyResources(this.barSubItem2, "barSubItem2");
            this.barSubItem2.Id = 44;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biUndo, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.biRedo),
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarItem42),
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarItem43, true)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // commandBarItem42
            // 
            resources.ApplyResources(this.commandBarItem42, "commandBarItem42");
            this.commandBarItem42.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.Delete;
            this.commandBarItem42.Enabled = false;
            this.commandBarItem42.Id = 63;
            this.commandBarItem42.Name = "commandBarItem42";
            // 
            // commandBarItem43
            // 
            resources.ApplyResources(this.commandBarItem43, "commandBarItem43");
            this.commandBarItem43.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.SelectAll;
            this.commandBarItem43.Enabled = false;
            this.commandBarItem43.Id = 64;
            this.commandBarItem43.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A));
            this.commandBarItem43.Name = "commandBarItem43";
            // 
            // barSubItem3
            // 
            resources.ApplyResources(this.barSubItem3, "barSubItem3");
            this.barSubItem3.Id = 45;
            this.barSubItem3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barReportTabButtonsListItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem4, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem5, true)});
            this.barSubItem3.Name = "barSubItem3";
            // 
            // barReportTabButtonsListItem1
            // 
            resources.ApplyResources(this.barReportTabButtonsListItem1, "barReportTabButtonsListItem1");
            this.barReportTabButtonsListItem1.Id = 46;
            this.barReportTabButtonsListItem1.Name = "barReportTabButtonsListItem1";
            // 
            // barSubItem4
            // 
            resources.ApplyResources(this.barSubItem4, "barSubItem4");
            this.barSubItem4.Id = 47;
            this.barSubItem4.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.xrBarToolbarsListItem1)});
            this.barSubItem4.Name = "barSubItem4";
            // 
            // xrBarToolbarsListItem1
            // 
            resources.ApplyResources(this.xrBarToolbarsListItem1, "xrBarToolbarsListItem1");
            this.xrBarToolbarsListItem1.Id = 48;
            this.xrBarToolbarsListItem1.Name = "xrBarToolbarsListItem1";
            // 
            // barSubItem5
            // 
            resources.ApplyResources(this.barSubItem5, "barSubItem5");
            this.barSubItem5.Id = 49;
            this.barSubItem5.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barDockPanelsListItem1)});
            this.barSubItem5.Name = "barSubItem5";
            // 
            // barDockPanelsListItem1
            // 
            resources.ApplyResources(this.barDockPanelsListItem1, "barDockPanelsListItem1");
            this.barDockPanelsListItem1.Id = 50;
            this.barDockPanelsListItem1.Name = "barDockPanelsListItem1";
            this.barDockPanelsListItem1.ShowCustomizationItem = false;
            this.barDockPanelsListItem1.ShowDockPanels = true;
            this.barDockPanelsListItem1.ShowToolbars = false;
            // 
            // barSubItem6
            // 
            resources.ApplyResources(this.barSubItem6, "barSubItem6");
            this.barSubItem6.Id = 51;
            this.barSubItem6.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem7, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem8),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem9, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem10),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem11, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem12),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem13, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem14, true)});
            this.barSubItem6.Name = "barSubItem6";
            // 
            // barSubItem7
            // 
            resources.ApplyResources(this.barSubItem7, "barSubItem7");
            this.barSubItem7.Id = 52;
            this.barSubItem7.Name = "barSubItem7";
            // 
            // barSubItem8
            // 
            resources.ApplyResources(this.barSubItem8, "barSubItem8");
            this.barSubItem8.Id = 53;
            this.barSubItem8.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biJustifyLeft, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.biJustifyCenter),
            new DevExpress.XtraBars.LinkPersistInfo(this.biJustifyRight),
            new DevExpress.XtraBars.LinkPersistInfo(this.biJustifyJustify)});
            this.barSubItem8.Name = "barSubItem8";
            // 
            // barSubItem9
            // 
            resources.ApplyResources(this.barSubItem9, "barSubItem9");
            this.barSubItem9.Id = 54;
            this.barSubItem9.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarItem9, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarItem10),
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarItem11),
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarItem12, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarItem13),
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarItem14),
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarItem8, true)});
            this.barSubItem9.Name = "barSubItem9";
            // 
            // barSubItem10
            // 
            resources.ApplyResources(this.barSubItem10, "barSubItem10");
            this.barSubItem10.Id = 55;
            this.barSubItem10.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarItem15, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarItem16),
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarItem17),
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarItem18)});
            this.barSubItem10.Name = "barSubItem10";
            // 
            // barSubItem11
            // 
            resources.ApplyResources(this.barSubItem11, "barSubItem11");
            this.barSubItem11.Id = 56;
            this.barSubItem11.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarItem19, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarItem20),
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarItem21),
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarItem22)});
            this.barSubItem11.Name = "barSubItem11";
            // 
            // barSubItem12
            // 
            resources.ApplyResources(this.barSubItem12, "barSubItem12");
            this.barSubItem12.Id = 57;
            this.barSubItem12.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarItem23, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarItem24),
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarItem25),
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarItem26)});
            this.barSubItem12.Name = "barSubItem12";
            // 
            // barSubItem13
            // 
            resources.ApplyResources(this.barSubItem13, "barSubItem13");
            this.barSubItem13.Id = 58;
            this.barSubItem13.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarItem27, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarItem28)});
            this.barSubItem13.Name = "barSubItem13";
            // 
            // barSubItem14
            // 
            resources.ApplyResources(this.barSubItem14, "barSubItem14");
            this.barSubItem14.Id = 59;
            this.barSubItem14.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarItem29, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarItem30)});
            this.barSubItem14.Name = "barSubItem14";
            // 
            // barSubItem15
            // 
            resources.ApplyResources(this.barSubItem15, "barSubItem15");
            this.barSubItem15.Id = 65;
            this.barSubItem15.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarCheckItem1, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarItem44),
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarItem45),
            new DevExpress.XtraBars.LinkPersistInfo(this.commandBarItem46),
            new DevExpress.XtraBars.LinkPersistInfo(this.barMdiChildrenListItem1, true)});
            this.barSubItem15.Name = "barSubItem15";
            // 
            // commandBarCheckItem1
            // 
            resources.ApplyResources(this.commandBarCheckItem1, "commandBarCheckItem1");
            this.commandBarCheckItem1.Checked = true;
            this.commandBarCheckItem1.CheckedCommand = DevExpress.XtraReports.UserDesigner.ReportCommand.ShowTabbedInterface;
            this.commandBarCheckItem1.Enabled = false;
            this.commandBarCheckItem1.Id = 66;
            this.commandBarCheckItem1.Name = "commandBarCheckItem1";
            this.commandBarCheckItem1.UncheckedCommand = DevExpress.XtraReports.UserDesigner.ReportCommand.ShowWindowInterface;
            // 
            // commandBarItem44
            // 
            resources.ApplyResources(this.commandBarItem44, "commandBarItem44");
            this.commandBarItem44.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.MdiCascade;
            this.commandBarItem44.Enabled = false;
            this.commandBarItem44.Id = 67;
            this.commandBarItem44.ImageIndex = 40;
            this.commandBarItem44.Name = "commandBarItem44";
            // 
            // commandBarItem45
            // 
            resources.ApplyResources(this.commandBarItem45, "commandBarItem45");
            this.commandBarItem45.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.MdiTileHorizontal;
            this.commandBarItem45.Enabled = false;
            this.commandBarItem45.Id = 68;
            this.commandBarItem45.ImageIndex = 41;
            this.commandBarItem45.Name = "commandBarItem45";
            // 
            // commandBarItem46
            // 
            resources.ApplyResources(this.commandBarItem46, "commandBarItem46");
            this.commandBarItem46.Command = DevExpress.XtraReports.UserDesigner.ReportCommand.MdiTileVertical;
            this.commandBarItem46.Enabled = false;
            this.commandBarItem46.Id = 69;
            this.commandBarItem46.ImageIndex = 42;
            this.commandBarItem46.Name = "commandBarItem46";
            // 
            // barMdiChildrenListItem1
            // 
            resources.ApplyResources(this.barMdiChildrenListItem1, "barMdiChildrenListItem1");
            this.barMdiChildrenListItem1.Id = 70;
            this.barMdiChildrenListItem1.Name = "barMdiChildrenListItem1";
            // 
            // bsiLookAndFeel
            // 
            resources.ApplyResources(this.bsiLookAndFeel, "bsiLookAndFeel");
            this.bsiLookAndFeel.Id = 74;
            this.bsiLookAndFeel.Name = "bsiLookAndFeel";
            // 
            // barButtonItem1
            // 
            resources.ApplyResources(this.barButtonItem1, "barButtonItem1");
            this.barButtonItem1.Id = 79;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // xrDesignMdiController1
            // 
            xrDesignPanelListener1.DesignControl = this.xrDesignBarManager1;
            xrDesignPanelListener2.DesignControl = this.xrDesignDockManager1;
            xrDesignPanelListener3.DesignControl = this.fieldListDockPanel1;
            xrDesignPanelListener4.DesignControl = this.propertyGridDockPanel1;
            xrDesignPanelListener5.DesignControl = this.reportExplorerDockPanel1;
            xrDesignPanelListener6.DesignControl = this.groupAndSortDockPanel1;
            xrDesignPanelListener7.DesignControl = this.errorListDockPanel1;
            this.xrDesignMdiController1.DesignPanelListeners.AddRange(new DevExpress.XtraReports.UserDesigner.XRDesignPanelListener[] {
            xrDesignPanelListener1,
            xrDesignPanelListener2,
            xrDesignPanelListener3,
            xrDesignPanelListener4,
            xrDesignPanelListener5,
            xrDesignPanelListener6,
            xrDesignPanelListener7});
            this.xrDesignMdiController1.Form = this;
            this.xrDesignMdiController1.XtraTabbedMdiManager = this.xtraTabbedMdiManager1;
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.AllowDragDrop = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeader;
            this.xtraTabbedMdiManager1.CloseTabOnMiddleClick = DevExpress.XtraTabbedMdi.CloseTabOnMiddleClick.Never;
            this.xtraTabbedMdiManager1.MdiParent = this;
            this.xtraTabbedMdiManager1.ShowFloatingDropHint = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTabbedMdiManager1.UseDocumentSelector = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTabbedMdiManager1.UseFormIconAsPageImage = DevExpress.Utils.DefaultBoolean.False;
            // 
            // HidePopupTimer
            // 
            this.HidePopupTimer.Tick += new System.EventHandler(this.HidePopupTimer_Tick);
            // 
            // DesignForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IsMdiContainer = true;
            this.Name = "DesignForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xrDesignBarManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.designRepositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recentlyUsedItemsComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.designRepositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrDesignDockManager1)).EndInit();
            this.panelContainer3.ResumeLayout(false);
            this.groupAndSortDockPanel1.ResumeLayout(false);
            this.errorListDockPanel1.ResumeLayout(false);
            this.panelContainer1.ResumeLayout(false);
            this.panelContainer2.ResumeLayout(false);
            this.reportExplorerDockPanel1.ResumeLayout(false);
            this.fieldListDockPanel1.ResumeLayout(false);
            this.propertyGridDockPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private BarButtonItem barButtonItem1;
        private BarDockControl barDockControlTop;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private System.Windows.Forms.Timer HidePopupTimer;

    }
}
