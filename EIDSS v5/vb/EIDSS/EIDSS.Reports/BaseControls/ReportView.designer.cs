namespace EIDSS.Reports.BaseControls
{
    partial class ReportView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportView));
            this.printingSystemReports = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.printControlReport = new EIDSS.Reports.BaseControls.ReportPrintControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.printBarManager = new DevExpress.XtraPrinting.Preview.PrintBarManager();
            this.previewBar1 = new DevExpress.XtraPrinting.Preview.PreviewBar();
            this.biLoadDefault = new DevExpress.XtraBars.BarButtonItem();
            this.biEdit = new DevExpress.XtraBars.BarButtonItem();
            this.biFind = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.biPrint = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.biPrintDirect = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.biPageSetup = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.biScale = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.biHandTool = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.biMagnifier = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.biZoomOut = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.biZoom = new DevExpress.XtraPrinting.Preview.ZoomBarEditItem();
            this.printPreviewRepositoryItemComboBox1 = new DevExpress.XtraPrinting.Preview.PrintPreviewRepositoryItemComboBox();
            this.ZoomIn = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.biShowFirstPage = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.biShowPrevPage = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.biShowNextPage = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.biShowLastPage = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.biMultiplePages = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.biFillBackground = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.biExportFile = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.barStatus = new DevExpress.XtraPrinting.Preview.PreviewBar();
            this.biPage = new DevExpress.XtraPrinting.Preview.PrintPreviewStaticItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.biProgressBar = new DevExpress.XtraPrinting.Preview.ProgressBarEditItem();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.biStatusStatus = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.biStatusZoom = new DevExpress.XtraPrinting.Preview.PrintPreviewStaticItem();
            this.barMainMenu = new DevExpress.XtraPrinting.Preview.PreviewBar();
            this.printPreviewSubItem4 = new DevExpress.XtraPrinting.Preview.PrintPreviewSubItem();
            this.printPreviewBarItem27 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.printPreviewBarItem28 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.barToolbarsListItem1 = new DevExpress.XtraBars.BarToolbarsListItem();
            this.biExportPdf = new DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem();
            this.biExportHtm = new DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem();
            this.biExportMht = new DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem();
            this.biExportRtf = new DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem();
            this.biExportXls = new DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem();
            this.biExportCsv = new DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem();
            this.biExportTxt = new DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem();
            this.biExportGraphic = new DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem();
            this.printPreviewBarItem2 = new DevExpress.XtraPrinting.Preview.PrintPreviewBarItem();
            this.timerScroll = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.printingSystemReports)).BeginInit();
            this.printControlReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.printBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printPreviewRepositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // printControlReport
            // 
            this.printControlReport.AccessibleDescription = null;
            this.printControlReport.AccessibleName = null;
            resources.ApplyResources(this.printControlReport, "printControlReport");
            this.printControlReport.BackgroundImage = null;
            this.printControlReport.Controls.Add(this.barDockControlLeft);
            this.printControlReport.Controls.Add(this.barDockControlRight);
            this.printControlReport.Controls.Add(this.barDockControlBottom);
            this.printControlReport.Controls.Add(this.barDockControlTop);
            this.printControlReport.Font = null;
            this.printControlReport.LookAndFeel.SkinName = "Blue";
            this.printControlReport.Name = "printControlReport";
            this.printControlReport.PrintingSystem = this.printingSystemReports;
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.AccessibleDescription = null;
            this.barDockControlLeft.AccessibleName = null;
            resources.ApplyResources(this.barDockControlLeft, "barDockControlLeft");
            this.barDockControlLeft.Font = null;
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.AccessibleDescription = null;
            this.barDockControlRight.AccessibleName = null;
            resources.ApplyResources(this.barDockControlRight, "barDockControlRight");
            this.barDockControlRight.Font = null;
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.AccessibleDescription = null;
            this.barDockControlBottom.AccessibleName = null;
            resources.ApplyResources(this.barDockControlBottom, "barDockControlBottom");
            this.barDockControlBottom.Font = null;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.AccessibleDescription = null;
            this.barDockControlTop.AccessibleName = null;
            resources.ApplyResources(this.barDockControlTop, "barDockControlTop");
            this.barDockControlTop.Font = null;
            // 
            // printBarManager
            // 
            this.printBarManager.AllowCustomization = false;
            this.printBarManager.AllowQuickCustomization = false;
            this.printBarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.previewBar1,
            this.barStatus,
            this.barMainMenu});
            this.printBarManager.DockControls.Add(this.barDockControlTop);
            this.printBarManager.DockControls.Add(this.barDockControlBottom);
            this.printBarManager.DockControls.Add(this.barDockControlLeft);
            this.printBarManager.DockControls.Add(this.barDockControlRight);
            this.printBarManager.Form = this.printControlReport;
            this.printBarManager.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("printBarManager.ImageStream")));
            this.printBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.biPage,
            this.barStaticItem1,
            this.biProgressBar,
            this.biStatusStatus,
            this.barButtonItem1,
            this.biStatusZoom,
            this.biFind,
            this.biPrint,
            this.biPrintDirect,
            this.biPageSetup,
            this.biScale,
            this.biHandTool,
            this.biMagnifier,
            this.biZoomOut,
            this.biZoom,
            this.ZoomIn,
            this.biShowFirstPage,
            this.biShowPrevPage,
            this.biShowNextPage,
            this.biShowLastPage,
            this.biMultiplePages,
            this.biFillBackground,
            this.biExportFile,
            this.printPreviewSubItem4,
            this.printPreviewBarItem27,
            this.printPreviewBarItem28,
            this.barToolbarsListItem1,
            this.biExportPdf,
            this.biExportHtm,
            this.biExportMht,
            this.biExportRtf,
            this.biExportXls,
            this.biExportCsv,
            this.biExportTxt,
            this.biExportGraphic,
            this.biEdit,
            this.biLoadDefault});
            this.printBarManager.MainMenu = this.barMainMenu;
            this.printBarManager.MaxItemId = 60;
            this.printBarManager.PreviewBar = this.previewBar1;
            this.printBarManager.PrintControl = this.printControlReport;
            this.printBarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemProgressBar1,
            this.printPreviewRepositoryItemComboBox1});
            this.printBarManager.StatusBar = this.barStatus;
            // 
            // previewBar1
            // 
            this.previewBar1.BarName = "Toolbar";
            this.previewBar1.DockCol = 0;
            this.previewBar1.DockRow = 1;
            this.previewBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.previewBar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biLoadDefault, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.biEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.biFind, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.biPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.biPrintDirect),
            new DevExpress.XtraBars.LinkPersistInfo(this.biPageSetup),
            new DevExpress.XtraBars.LinkPersistInfo(this.biScale),
            new DevExpress.XtraBars.LinkPersistInfo(this.biHandTool, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.biMagnifier),
            new DevExpress.XtraBars.LinkPersistInfo(this.biZoomOut, true),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.biZoom, "", false, true, true, 70),
            new DevExpress.XtraBars.LinkPersistInfo(this.ZoomIn),
            new DevExpress.XtraBars.LinkPersistInfo(this.biShowFirstPage, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.biShowPrevPage),
            new DevExpress.XtraBars.LinkPersistInfo(this.biShowNextPage),
            new DevExpress.XtraBars.LinkPersistInfo(this.biShowLastPage),
            new DevExpress.XtraBars.LinkPersistInfo(this.biMultiplePages, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.biFillBackground),
            new DevExpress.XtraBars.LinkPersistInfo(this.biExportFile, true)});
            this.previewBar1.OptionsBar.AllowQuickCustomization = false;
            this.previewBar1.OptionsBar.DisableClose = true;
            this.previewBar1.OptionsBar.DisableCustomization = true;
            this.previewBar1.OptionsBar.DrawDragBorder = false;
            resources.ApplyResources(this.previewBar1, "previewBar1");
            // 
            // biLoadDefault
            // 
            this.biLoadDefault.AccessibleDescription = null;
            this.biLoadDefault.AccessibleName = null;
            resources.ApplyResources(this.biLoadDefault, "biLoadDefault");
            this.biLoadDefault.Enabled = false;
            this.biLoadDefault.Glyph = global::EIDSS.Reports.Properties.Resources.restore;
            this.biLoadDefault.Id = 59;
            this.biLoadDefault.Name = "biLoadDefault";
            this.biLoadDefault.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.biLoadDefault.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biLoadDefault_ItemClick);
            // 
            // biEdit
            // 
            this.biEdit.AccessibleDescription = null;
            this.biEdit.AccessibleName = null;
            resources.ApplyResources(this.biEdit, "biEdit");
            this.biEdit.Enabled = false;
            this.biEdit.Glyph = global::EIDSS.Reports.Properties.Resources.msg_edit;
            this.biEdit.Id = 58;
            this.biEdit.Name = "biEdit";
            this.biEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.biEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biEdit_ItemClick);
            // 
            // biFind
            // 
            this.biFind.AccessibleDescription = null;
            this.biFind.AccessibleName = null;
            resources.ApplyResources(this.biFind, "biFind");
            this.biFind.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Find;
            this.biFind.Enabled = false;
            this.biFind.Id = 8;
            this.biFind.ImageIndex = 20;
            this.biFind.Name = "biFind";
            // 
            // biPrint
            // 
            this.biPrint.AccessibleDescription = null;
            this.biPrint.AccessibleName = null;
            this.biPrint.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            resources.ApplyResources(this.biPrint, "biPrint");
            this.biPrint.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Print;
            this.biPrint.Enabled = false;
            this.biPrint.Id = 12;
            this.biPrint.ImageIndex = 0;
            this.biPrint.Name = "biPrint";
            // 
            // biPrintDirect
            // 
            this.biPrintDirect.AccessibleDescription = null;
            this.biPrintDirect.AccessibleName = null;
            resources.ApplyResources(this.biPrintDirect, "biPrintDirect");
            this.biPrintDirect.Command = DevExpress.XtraPrinting.PrintingSystemCommand.PrintDirect;
            this.biPrintDirect.Enabled = false;
            this.biPrintDirect.Id = 13;
            this.biPrintDirect.ImageIndex = 1;
            this.biPrintDirect.Name = "biPrintDirect";
            // 
            // biPageSetup
            // 
            this.biPageSetup.AccessibleDescription = null;
            this.biPageSetup.AccessibleName = null;
            this.biPageSetup.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            resources.ApplyResources(this.biPageSetup, "biPageSetup");
            this.biPageSetup.Command = DevExpress.XtraPrinting.PrintingSystemCommand.PageSetup;
            this.biPageSetup.Enabled = false;
            this.biPageSetup.Id = 14;
            this.biPageSetup.ImageIndex = 2;
            this.biPageSetup.Name = "biPageSetup";
            // 
            // biScale
            // 
            this.biScale.AccessibleDescription = null;
            this.biScale.AccessibleName = null;
            this.biScale.ActAsDropDown = true;
            this.biScale.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            resources.ApplyResources(this.biScale, "biScale");
            this.biScale.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Scale;
            this.biScale.Enabled = false;
            this.biScale.Id = 16;
            this.biScale.ImageIndex = 25;
            this.biScale.Name = "biScale";
            // 
            // biHandTool
            // 
            this.biHandTool.AccessibleDescription = null;
            this.biHandTool.AccessibleName = null;
            this.biHandTool.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            resources.ApplyResources(this.biHandTool, "biHandTool");
            this.biHandTool.Command = DevExpress.XtraPrinting.PrintingSystemCommand.HandTool;
            this.biHandTool.Enabled = false;
            this.biHandTool.Id = 17;
            this.biHandTool.ImageIndex = 16;
            this.biHandTool.Name = "biHandTool";
            // 
            // biMagnifier
            // 
            this.biMagnifier.AccessibleDescription = null;
            this.biMagnifier.AccessibleName = null;
            this.biMagnifier.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            resources.ApplyResources(this.biMagnifier, "biMagnifier");
            this.biMagnifier.Command = DevExpress.XtraPrinting.PrintingSystemCommand.Magnifier;
            this.biMagnifier.Enabled = false;
            this.biMagnifier.Id = 18;
            this.biMagnifier.ImageIndex = 3;
            this.biMagnifier.Name = "biMagnifier";
            // 
            // biZoomOut
            // 
            this.biZoomOut.AccessibleDescription = null;
            this.biZoomOut.AccessibleName = null;
            resources.ApplyResources(this.biZoomOut, "biZoomOut");
            this.biZoomOut.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ZoomOut;
            this.biZoomOut.Enabled = false;
            this.biZoomOut.Id = 19;
            this.biZoomOut.ImageIndex = 5;
            this.biZoomOut.Name = "biZoomOut";
            // 
            // biZoom
            // 
            this.biZoom.AccessibleDescription = null;
            this.biZoom.AccessibleName = null;
            resources.ApplyResources(this.biZoom, "biZoom");
            this.biZoom.Edit = this.printPreviewRepositoryItemComboBox1;
            this.biZoom.EditValue = "100%";
            this.biZoom.Enabled = false;
            this.biZoom.Id = 20;
            this.biZoom.Name = "biZoom";
            // 
            // printPreviewRepositoryItemComboBox1
            // 
            this.printPreviewRepositoryItemComboBox1.AccessibleDescription = null;
            this.printPreviewRepositoryItemComboBox1.AccessibleName = null;
            this.printPreviewRepositoryItemComboBox1.AutoComplete = false;
            resources.ApplyResources(this.printPreviewRepositoryItemComboBox1, "printPreviewRepositoryItemComboBox1");
            this.printPreviewRepositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("printPreviewRepositoryItemComboBox1.Buttons"))))});
            this.printPreviewRepositoryItemComboBox1.DropDownRows = 11;
            this.printPreviewRepositoryItemComboBox1.Name = "printPreviewRepositoryItemComboBox1";
            // 
            // ZoomIn
            // 
            this.ZoomIn.AccessibleDescription = null;
            this.ZoomIn.AccessibleName = null;
            resources.ApplyResources(this.ZoomIn, "ZoomIn");
            this.ZoomIn.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ZoomIn;
            this.ZoomIn.Enabled = false;
            this.ZoomIn.Id = 21;
            this.ZoomIn.ImageIndex = 4;
            this.ZoomIn.Name = "ZoomIn";
            // 
            // biShowFirstPage
            // 
            this.biShowFirstPage.AccessibleDescription = null;
            this.biShowFirstPage.AccessibleName = null;
            resources.ApplyResources(this.biShowFirstPage, "biShowFirstPage");
            this.biShowFirstPage.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ShowFirstPage;
            this.biShowFirstPage.Enabled = false;
            this.biShowFirstPage.Id = 22;
            this.biShowFirstPage.ImageIndex = 7;
            this.biShowFirstPage.Name = "biShowFirstPage";
            // 
            // biShowPrevPage
            // 
            this.biShowPrevPage.AccessibleDescription = null;
            this.biShowPrevPage.AccessibleName = null;
            resources.ApplyResources(this.biShowPrevPage, "biShowPrevPage");
            this.biShowPrevPage.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ShowPrevPage;
            this.biShowPrevPage.Enabled = false;
            this.biShowPrevPage.Id = 23;
            this.biShowPrevPage.ImageIndex = 8;
            this.biShowPrevPage.Name = "biShowPrevPage";
            // 
            // biShowNextPage
            // 
            this.biShowNextPage.AccessibleDescription = null;
            this.biShowNextPage.AccessibleName = null;
            resources.ApplyResources(this.biShowNextPage, "biShowNextPage");
            this.biShowNextPage.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ShowNextPage;
            this.biShowNextPage.Enabled = false;
            this.biShowNextPage.Id = 24;
            this.biShowNextPage.ImageIndex = 9;
            this.biShowNextPage.Name = "biShowNextPage";
            // 
            // biShowLastPage
            // 
            this.biShowLastPage.AccessibleDescription = null;
            this.biShowLastPage.AccessibleName = null;
            resources.ApplyResources(this.biShowLastPage, "biShowLastPage");
            this.biShowLastPage.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ShowLastPage;
            this.biShowLastPage.Enabled = false;
            this.biShowLastPage.Id = 25;
            this.biShowLastPage.ImageIndex = 10;
            this.biShowLastPage.Name = "biShowLastPage";
            // 
            // biMultiplePages
            // 
            this.biMultiplePages.AccessibleDescription = null;
            this.biMultiplePages.AccessibleName = null;
            this.biMultiplePages.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            resources.ApplyResources(this.biMultiplePages, "biMultiplePages");
            this.biMultiplePages.Command = DevExpress.XtraPrinting.PrintingSystemCommand.MultiplePages;
            this.biMultiplePages.Enabled = false;
            this.biMultiplePages.Id = 26;
            this.biMultiplePages.ImageIndex = 11;
            this.biMultiplePages.Name = "biMultiplePages";
            // 
            // biFillBackground
            // 
            this.biFillBackground.AccessibleDescription = null;
            this.biFillBackground.AccessibleName = null;
            this.biFillBackground.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            resources.ApplyResources(this.biFillBackground, "biFillBackground");
            this.biFillBackground.Command = DevExpress.XtraPrinting.PrintingSystemCommand.FillBackground;
            this.biFillBackground.Enabled = false;
            this.biFillBackground.Id = 27;
            this.biFillBackground.ImageIndex = 12;
            this.biFillBackground.Name = "biFillBackground";
            // 
            // biExportFile
            // 
            this.biExportFile.AccessibleDescription = null;
            this.biExportFile.AccessibleName = null;
            this.biExportFile.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            resources.ApplyResources(this.biExportFile, "biExportFile");
            this.biExportFile.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportFile;
            this.biExportFile.Enabled = false;
            this.biExportFile.Id = 29;
            this.biExportFile.ImageIndex = 18;
            this.biExportFile.Name = "biExportFile";
            // 
            // barStatus
            // 
            this.barStatus.BarName = "Status Bar";
            this.barStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.barStatus.DockCol = 0;
            this.barStatus.DockRow = 0;
            this.barStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biPage),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.biProgressBar),
            new DevExpress.XtraBars.LinkPersistInfo(this.biStatusStatus),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.biStatusZoom, true)});
            this.barStatus.OptionsBar.AllowQuickCustomization = false;
            this.barStatus.OptionsBar.DrawDragBorder = false;
            this.barStatus.OptionsBar.UseWholeRow = true;
            resources.ApplyResources(this.barStatus, "barStatus");
            // 
            // biPage
            // 
            this.biPage.AccessibleDescription = null;
            this.biPage.AccessibleName = null;
            this.biPage.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            resources.ApplyResources(this.biPage, "biPage");
            this.biPage.Id = 0;
            this.biPage.LeftIndent = 1;
            this.biPage.Name = "biPage";
            this.biPage.RightIndent = 1;
            this.biPage.TextAlignment = System.Drawing.StringAlignment.Near;
            this.biPage.Type = "PageOfPages";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.AccessibleDescription = null;
            this.barStaticItem1.AccessibleName = null;
            this.barStaticItem1.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            resources.ApplyResources(this.barStaticItem1, "barStaticItem1");
            this.barStaticItem1.Id = 1;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // biProgressBar
            // 
            this.biProgressBar.AccessibleDescription = null;
            this.biProgressBar.AccessibleName = null;
            this.biProgressBar.Edit = this.repositoryItemProgressBar1;
            this.biProgressBar.EditHeight = 12;
            resources.ApplyResources(this.biProgressBar, "biProgressBar");
            this.biProgressBar.Id = 2;
            this.biProgressBar.Name = "biProgressBar";
            this.biProgressBar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.AccessibleDescription = null;
            this.repositoryItemProgressBar1.AccessibleName = null;
            resources.ApplyResources(this.repositoryItemProgressBar1, "repositoryItemProgressBar1");
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            // 
            // biStatusStatus
            // 
            this.biStatusStatus.AccessibleDescription = null;
            this.biStatusStatus.AccessibleName = null;
            resources.ApplyResources(this.biStatusStatus, "biStatusStatus");
            this.biStatusStatus.Command = DevExpress.XtraPrinting.PrintingSystemCommand.StopPageBuilding;
            this.biStatusStatus.Enabled = false;
            this.biStatusStatus.Id = 3;
            this.biStatusStatus.Name = "biStatusStatus";
            this.biStatusStatus.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.AccessibleDescription = null;
            this.barButtonItem1.AccessibleName = null;
            this.barButtonItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.barButtonItem1.Enabled = false;
            resources.ApplyResources(this.barButtonItem1, "barButtonItem1");
            this.barButtonItem1.Id = 4;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // biStatusZoom
            // 
            this.biStatusZoom.AccessibleDescription = null;
            this.biStatusZoom.AccessibleName = null;
            this.biStatusZoom.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.biStatusZoom.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            resources.ApplyResources(this.biStatusZoom, "biStatusZoom");
            this.biStatusZoom.Id = 5;
            this.biStatusZoom.Name = "biStatusZoom";
            this.biStatusZoom.TextAlignment = System.Drawing.StringAlignment.Near;
            this.biStatusZoom.Type = "ZoomFactor";
            // 
            // barMainMenu
            // 
            this.barMainMenu.BarName = "Main Menu";
            this.barMainMenu.DockCol = 0;
            this.barMainMenu.DockRow = 0;
            this.barMainMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMainMenu.OptionsBar.MultiLine = true;
            this.barMainMenu.OptionsBar.UseWholeRow = true;
            resources.ApplyResources(this.barMainMenu, "barMainMenu");
            this.barMainMenu.Visible = false;
            // 
            // printPreviewSubItem4
            // 
            this.printPreviewSubItem4.AccessibleDescription = null;
            this.printPreviewSubItem4.AccessibleName = null;
            resources.ApplyResources(this.printPreviewSubItem4, "printPreviewSubItem4");
            this.printPreviewSubItem4.Command = DevExpress.XtraPrinting.PrintingSystemCommand.PageLayout;
            this.printPreviewSubItem4.Id = 35;
            this.printPreviewSubItem4.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem27),
            new DevExpress.XtraBars.LinkPersistInfo(this.printPreviewBarItem28)});
            this.printPreviewSubItem4.Name = "printPreviewSubItem4";
            // 
            // printPreviewBarItem27
            // 
            this.printPreviewBarItem27.AccessibleDescription = null;
            this.printPreviewBarItem27.AccessibleName = null;
            this.printPreviewBarItem27.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            resources.ApplyResources(this.printPreviewBarItem27, "printPreviewBarItem27");
            this.printPreviewBarItem27.Command = DevExpress.XtraPrinting.PrintingSystemCommand.PageLayoutFacing;
            this.printPreviewBarItem27.Enabled = false;
            this.printPreviewBarItem27.GroupIndex = 100;
            this.printPreviewBarItem27.Id = 36;
            this.printPreviewBarItem27.Name = "printPreviewBarItem27";
            // 
            // printPreviewBarItem28
            // 
            this.printPreviewBarItem28.AccessibleDescription = null;
            this.printPreviewBarItem28.AccessibleName = null;
            this.printPreviewBarItem28.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            resources.ApplyResources(this.printPreviewBarItem28, "printPreviewBarItem28");
            this.printPreviewBarItem28.Command = DevExpress.XtraPrinting.PrintingSystemCommand.PageLayoutContinuous;
            this.printPreviewBarItem28.Enabled = false;
            this.printPreviewBarItem28.GroupIndex = 100;
            this.printPreviewBarItem28.Id = 37;
            this.printPreviewBarItem28.Name = "printPreviewBarItem28";
            // 
            // barToolbarsListItem1
            // 
            this.barToolbarsListItem1.AccessibleDescription = null;
            this.barToolbarsListItem1.AccessibleName = null;
            resources.ApplyResources(this.barToolbarsListItem1, "barToolbarsListItem1");
            this.barToolbarsListItem1.Id = 38;
            this.barToolbarsListItem1.Name = "barToolbarsListItem1";
            // 
            // biExportPdf
            // 
            this.biExportPdf.AccessibleDescription = null;
            this.biExportPdf.AccessibleName = null;
            resources.ApplyResources(this.biExportPdf, "biExportPdf");
            this.biExportPdf.Checked = true;
            this.biExportPdf.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportPdf;
            this.biExportPdf.Enabled = false;
            this.biExportPdf.GroupIndex = 1;
            this.biExportPdf.Id = 39;
            this.biExportPdf.Name = "biExportPdf";
            // 
            // biExportHtm
            // 
            this.biExportHtm.AccessibleDescription = null;
            this.biExportHtm.AccessibleName = null;
            resources.ApplyResources(this.biExportHtm, "biExportHtm");
            this.biExportHtm.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm;
            this.biExportHtm.Enabled = false;
            this.biExportHtm.GroupIndex = 1;
            this.biExportHtm.Id = 40;
            this.biExportHtm.Name = "biExportHtm";
            // 
            // biExportMht
            // 
            this.biExportMht.AccessibleDescription = null;
            this.biExportMht.AccessibleName = null;
            resources.ApplyResources(this.biExportMht, "biExportMht");
            this.biExportMht.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportMht;
            this.biExportMht.Enabled = false;
            this.biExportMht.GroupIndex = 1;
            this.biExportMht.Id = 41;
            this.biExportMht.Name = "biExportMht";
            // 
            // biExportRtf
            // 
            this.biExportRtf.AccessibleDescription = null;
            this.biExportRtf.AccessibleName = null;
            resources.ApplyResources(this.biExportRtf, "biExportRtf");
            this.biExportRtf.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportRtf;
            this.biExportRtf.Enabled = false;
            this.biExportRtf.GroupIndex = 1;
            this.biExportRtf.Id = 42;
            this.biExportRtf.Name = "biExportRtf";
            // 
            // biExportXls
            // 
            this.biExportXls.AccessibleDescription = null;
            this.biExportXls.AccessibleName = null;
            resources.ApplyResources(this.biExportXls, "biExportXls");
            this.biExportXls.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportXls;
            this.biExportXls.Enabled = false;
            this.biExportXls.GroupIndex = 1;
            this.biExportXls.Id = 43;
            this.biExportXls.Name = "biExportXls";
            // 
            // biExportCsv
            // 
            this.biExportCsv.AccessibleDescription = null;
            this.biExportCsv.AccessibleName = null;
            resources.ApplyResources(this.biExportCsv, "biExportCsv");
            this.biExportCsv.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportCsv;
            this.biExportCsv.Enabled = false;
            this.biExportCsv.GroupIndex = 1;
            this.biExportCsv.Id = 44;
            this.biExportCsv.Name = "biExportCsv";
            // 
            // biExportTxt
            // 
            this.biExportTxt.AccessibleDescription = null;
            this.biExportTxt.AccessibleName = null;
            resources.ApplyResources(this.biExportTxt, "biExportTxt");
            this.biExportTxt.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportTxt;
            this.biExportTxt.Enabled = false;
            this.biExportTxt.GroupIndex = 1;
            this.biExportTxt.Id = 45;
            this.biExportTxt.Name = "biExportTxt";
            // 
            // biExportGraphic
            // 
            this.biExportGraphic.AccessibleDescription = null;
            this.biExportGraphic.AccessibleName = null;
            resources.ApplyResources(this.biExportGraphic, "biExportGraphic");
            this.biExportGraphic.Command = DevExpress.XtraPrinting.PrintingSystemCommand.ExportGraphic;
            this.biExportGraphic.Enabled = false;
            this.biExportGraphic.GroupIndex = 1;
            this.biExportGraphic.Id = 46;
            this.biExportGraphic.Name = "biExportGraphic";
            // 
            // printPreviewBarItem2
            // 
            this.printPreviewBarItem2.AccessibleDescription = null;
            this.printPreviewBarItem2.AccessibleName = null;
            this.printPreviewBarItem2.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            resources.ApplyResources(this.printPreviewBarItem2, "printPreviewBarItem2");
            this.printPreviewBarItem2.Command = DevExpress.XtraPrinting.PrintingSystemCommand.PageSetup;
            this.printPreviewBarItem2.Enabled = false;
            this.printPreviewBarItem2.Id = 14;
            this.printPreviewBarItem2.ImageIndex = 2;
            this.printPreviewBarItem2.Name = "printPreviewBarItem2";
            // 
            // timerScroll
            // 
            this.timerScroll.Interval = 300;
            this.timerScroll.Tick += new System.EventHandler(this.timerScroll_Tick);
            // 
            // ReportView
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.printControlReport);
            this.DoubleBuffered = true;
            this.Font = null;
            this.Name = "ReportView";
            ((System.ComponentModel.ISupportInitialize)(this.printingSystemReports)).EndInit();
            this.printControlReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.printBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printPreviewRepositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraPrinting.PrintingSystem printingSystemReports;
        private ReportPrintControl printControlReport;
        private DevExpress.XtraPrinting.Preview.PrintBarManager printBarManager;
        private DevExpress.XtraPrinting.Preview.PreviewBar previewBar1;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem biFind;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem biPrint;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem biPrintDirect;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem biPageSetup;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem biScale;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem biHandTool;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem biMagnifier;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem biZoomOut;
        private DevExpress.XtraPrinting.Preview.ZoomBarEditItem biZoom;
        private DevExpress.XtraPrinting.Preview.PrintPreviewRepositoryItemComboBox printPreviewRepositoryItemComboBox1;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem ZoomIn;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem biShowFirstPage;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem biShowPrevPage;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem biShowNextPage;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem biShowLastPage;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem biMultiplePages;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem biFillBackground;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem biExportFile;
        private DevExpress.XtraPrinting.Preview.PreviewBar barStatus;
        private DevExpress.XtraPrinting.Preview.PrintPreviewStaticItem biPage;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraPrinting.Preview.ProgressBarEditItem biProgressBar;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem biStatusStatus;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraPrinting.Preview.PrintPreviewStaticItem biStatusZoom;
        private DevExpress.XtraPrinting.Preview.PreviewBar barMainMenu;
        private DevExpress.XtraPrinting.Preview.PrintPreviewSubItem printPreviewSubItem4;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem printPreviewBarItem27;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem printPreviewBarItem28;
        private DevExpress.XtraBars.BarToolbarsListItem barToolbarsListItem1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem biExportPdf;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem biExportHtm;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem biExportMht;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem biExportRtf;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem biExportXls;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem biExportCsv;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem biExportTxt;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarCheckItem biExportGraphic;
        private DevExpress.XtraPrinting.Preview.PrintPreviewBarItem printPreviewBarItem2;
        private DevExpress.XtraBars.BarButtonItem biEdit;
        private DevExpress.XtraBars.BarButtonItem biLoadDefault;
        private System.Windows.Forms.Timer timerScroll;
        
    }
}