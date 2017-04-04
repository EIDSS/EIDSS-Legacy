namespace eidss.main
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                RemotingServer.DeInit();
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.tbToolbar = new DevExpress.XtraBars.Bar();
            this.tbMenu = new DevExpress.XtraBars.Bar();
            this.tbStatusbar = new DevExpress.XtraBars.Bar();
            this.sbiUserLabel = new DevExpress.XtraBars.BarStaticItem();
            this.sbiUser = new DevExpress.XtraBars.BarStaticItem();
            this.sbiOrganizationLable = new DevExpress.XtraBars.BarStaticItem();
            this.sbiOrganization = new DevExpress.XtraBars.BarStaticItem();
            this.sbiSiteLable = new DevExpress.XtraBars.BarStaticItem();
            this.sbiSite = new DevExpress.XtraBars.BarStaticItem();
            this.sbiCountryLabel = new DevExpress.XtraBars.BarStaticItem();
            this.sbiCountry = new DevExpress.XtraBars.BarStaticItem();
            this.sbiDate = new DevExpress.XtraBars.BarStaticItem();
            this.sbiTime = new DevExpress.XtraBars.BarStaticItem();
            this.DefaultBarAndDockingController1 = new DevExpress.XtraBars.DefaultBarAndDockingController(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.SmallImages = new System.Windows.Forms.ImageList(this.components);
            this.BigImages = new System.Windows.Forms.ImageList(this.components);
            this.Timer1 = new System.Timers.Timer();
            this.DefaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.ToolTipController = new DevExpress.Utils.DefaultToolTipController(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultBarAndDockingController1.Controller)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Timer1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.AllowMoveBarOnToolbar = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.tbToolbar,
            this.tbMenu,
            this.tbStatusbar});
            this.barManager1.Controller = this.DefaultBarAndDockingController1.Controller;
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Images = this.SmallImages;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.sbiUserLabel,
            this.sbiUser,
            this.sbiOrganizationLable,
            this.sbiOrganization,
            this.sbiSiteLable,
            this.sbiSite,
            this.sbiCountryLabel,
            this.sbiCountry,
            this.sbiDate,
            this.sbiTime});
            this.barManager1.LargeImages = this.BigImages;
            this.barManager1.MainMenu = this.tbMenu;
            this.barManager1.MaxItemId = 0;
            this.barManager1.ShowFullMenus = true;
            this.barManager1.StatusBar = this.tbStatusbar;
            // 
            // tbToolbar
            // 
            this.tbToolbar.BarName = "Tools";
            this.tbToolbar.DockCol = 0;
            this.tbToolbar.DockRow = 1;
            this.tbToolbar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.tbToolbar.OptionsBar.AllowQuickCustomization = false;
            this.tbToolbar.OptionsBar.DisableClose = true;
            this.tbToolbar.OptionsBar.DrawDragBorder = false;
            this.tbToolbar.OptionsBar.DrawSizeGrip = true;
            this.tbToolbar.OptionsBar.MultiLine = true;
            this.tbToolbar.OptionsBar.UseWholeRow = true;
            resources.ApplyResources(this.tbToolbar, "tbToolbar");
            // 
            // tbMenu
            // 
            this.tbMenu.BarName = "Main menu";
            this.tbMenu.DockCol = 0;
            this.tbMenu.DockRow = 0;
            this.tbMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.tbMenu.OptionsBar.DisableClose = true;
            this.tbMenu.OptionsBar.DisableCustomization = true;
            this.tbMenu.OptionsBar.DrawDragBorder = false;
            this.tbMenu.OptionsBar.MultiLine = true;
            this.tbMenu.OptionsBar.UseWholeRow = true;
            resources.ApplyResources(this.tbMenu, "tbMenu");
            // 
            // tbStatusbar
            // 
            this.tbStatusbar.BarName = "Status bar";
            this.tbStatusbar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.tbStatusbar.DockCol = 0;
            this.tbStatusbar.DockRow = 0;
            this.tbStatusbar.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.tbStatusbar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.sbiUserLabel, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.sbiUser),
            new DevExpress.XtraBars.LinkPersistInfo(this.sbiOrganizationLable),
            new DevExpress.XtraBars.LinkPersistInfo(this.sbiOrganization),
            new DevExpress.XtraBars.LinkPersistInfo(this.sbiSiteLable),
            new DevExpress.XtraBars.LinkPersistInfo(this.sbiSite),
            new DevExpress.XtraBars.LinkPersistInfo(this.sbiCountryLabel),
            new DevExpress.XtraBars.LinkPersistInfo(this.sbiCountry),
            new DevExpress.XtraBars.LinkPersistInfo(this.sbiDate),
            new DevExpress.XtraBars.LinkPersistInfo(this.sbiTime)});
            this.tbStatusbar.OptionsBar.AllowQuickCustomization = false;
            this.tbStatusbar.OptionsBar.DisableClose = true;
            this.tbStatusbar.OptionsBar.DisableCustomization = true;
            this.tbStatusbar.OptionsBar.DrawDragBorder = false;
            this.tbStatusbar.OptionsBar.DrawSizeGrip = true;
            this.tbStatusbar.OptionsBar.UseWholeRow = true;
            resources.ApplyResources(this.tbStatusbar, "tbStatusbar");
            // 
            // sbiUserLabel
            // 
            resources.ApplyResources(this.sbiUserLabel, "sbiUserLabel");
            this.sbiUserLabel.Id = 13;
            this.sbiUserLabel.LeftIndent = 1;
            this.sbiUserLabel.Name = "sbiUserLabel";
            this.sbiUserLabel.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // sbiUser
            // 
            this.sbiUser.Id = 16;
            this.sbiUser.LeftIndent = 1;
            this.sbiUser.Name = "sbiUser";
            this.sbiUser.RightIndent = 5;
            this.sbiUser.TextAlignment = System.Drawing.StringAlignment.Near;
            resources.ApplyResources(this.sbiUser, "sbiUser");
            // 
            // sbiOrganizationLable
            // 
            resources.ApplyResources(this.sbiOrganizationLable, "sbiOrganizationLable");
            this.sbiOrganizationLable.Id = 17;
            this.sbiOrganizationLable.Name = "sbiOrganizationLable";
            this.sbiOrganizationLable.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // sbiOrganization
            // 
            this.sbiOrganization.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring;
            this.sbiOrganization.Id = 18;
            this.sbiOrganization.LeftIndent = 1;
            this.sbiOrganization.Name = "sbiOrganization";
            this.sbiOrganization.RightIndent = 5;
            this.sbiOrganization.TextAlignment = System.Drawing.StringAlignment.Near;
            resources.ApplyResources(this.sbiOrganization, "sbiOrganization");
            // 
            // sbiSiteLable
            // 
            resources.ApplyResources(this.sbiSiteLable, "sbiSiteLable");
            this.sbiSiteLable.Id = 19;
            this.sbiSiteLable.Name = "sbiSiteLable";
            this.sbiSiteLable.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // sbiSite
            // 
            this.sbiSite.Id = 20;
            this.sbiSite.LeftIndent = 1;
            this.sbiSite.Name = "sbiSite";
            this.sbiSite.RightIndent = 5;
            this.sbiSite.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // sbiCountryLabel
            // 
            resources.ApplyResources(this.sbiCountryLabel, "sbiCountryLabel");
            this.sbiCountryLabel.Id = 21;
            this.sbiCountryLabel.Name = "sbiCountryLabel";
            this.sbiCountryLabel.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // sbiCountry
            // 
            this.sbiCountry.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring;
            this.sbiCountry.Id = 22;
            this.sbiCountry.LeftIndent = 1;
            this.sbiCountry.Name = "sbiCountry";
            this.sbiCountry.RightIndent = 5;
            this.sbiCountry.TextAlignment = System.Drawing.StringAlignment.Near;
            resources.ApplyResources(this.sbiCountry, "sbiCountry");
            // 
            // sbiDate
            // 
            this.sbiDate.Id = 23;
            this.sbiDate.LeftIndent = 1;
            this.sbiDate.Name = "sbiDate";
            this.sbiDate.RightIndent = 1;
            this.sbiDate.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // sbiTime
            // 
            this.sbiTime.Id = 24;
            this.sbiTime.Name = "sbiTime";
            this.sbiTime.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // DefaultBarAndDockingController1
            // 
            this.DefaultBarAndDockingController1.Controller.AppearancesBackstageView.Button.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesBackstageView.ButtonDisabled.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesBackstageView.ButtonHover.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesBackstageView.ButtonPressed.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesBackstageView.Tab.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesBackstageView.TabDisabled.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesBackstageView.TabHover.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesBackstageView.TabSelected.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesBar.BarAppearance.Normal.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesBar.Dock.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesBar.MainMenuAppearance.Normal.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesBar.StatusBarAppearance.Normal.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesBar.SubMenu.AppearanceMenu.Normal.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesBar.SubMenu.MenuBar.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesBar.SubMenu.MenuCaption.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesBar.SubMenu.SideStrip.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesBar.SubMenu.SideStripNonRecent.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesDocking.ActiveTab.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesDocking.FloatFormCaption.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesDocking.FloatFormCaptionActive.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesDocking.HideContainer.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesDocking.HidePanelButton.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesDocking.HidePanelButtonActive.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesDocking.Panel.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesDocking.PanelCaption.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesDocking.PanelCaptionActive.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesDocking.Tabs.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesDocumentManager.View.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesRibbon.FormCaption.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesRibbon.Gallery.FilterPanelCaption.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesRibbon.Gallery.GroupCaption.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesRibbon.Gallery.ItemCaptionAppearance.Normal.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesRibbon.Gallery.ItemDescriptionAppearance.Normal.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesRibbon.Item.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesRibbon.ItemDescription.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesRibbon.ItemDescriptionDisabled.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesRibbon.ItemDisabled.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesRibbon.PageCategory.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesRibbon.PageGroupCaption.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.AppearancesRibbon.PageHeader.Options.UseFont = true;
            this.DefaultBarAndDockingController1.Controller.LookAndFeel.SkinName = "Blue";
            this.DefaultBarAndDockingController1.Controller.PaintStyleName = "Skin";
            this.DefaultBarAndDockingController1.Controller.PropertiesBar.DefaultGlyphSize = new System.Drawing.Size(16, 16);
            this.DefaultBarAndDockingController1.Controller.PropertiesBar.DefaultLargeGlyphSize = new System.Drawing.Size(32, 32);
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
            // SmallImages
            // 
            this.SmallImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SmallImages.ImageStream")));
            this.SmallImages.TransparentColor = System.Drawing.Color.Transparent;
            this.SmallImages.Images.SetKeyName(0, "Active-Surviellance-Campaign-Journal-(small).png");
            this.SmallImages.Images.SetKeyName(1, "Active-Surviellance-Session-Journal-(small).png");
            this.SmallImages.Images.SetKeyName(2, "Aliquots_Derivatives-(small).png");
            this.SmallImages.Images.SetKeyName(3, "Avian Case (small).png");
            this.SmallImages.Images.SetKeyName(4, "Batch-(small).png");
            this.SmallImages.Images.SetKeyName(5, "Batch-Journal-(small).png");
            this.SmallImages.Images.SetKeyName(6, "Farm-Journal-(small).png");
            this.SmallImages.Images.SetKeyName(7, "Freezer-Journal-(small).png");
            this.SmallImages.Images.SetKeyName(8, "help-small.png");
            this.SmallImages.Images.SetKeyName(9, "Human-Aggregate-Entry-(small).png");
            this.SmallImages.Images.SetKeyName(10, "Human-Case-(small)1.png");
            this.SmallImages.Images.SetKeyName(11, "Human-Case-De-duplication-(small).png");
            this.SmallImages.Images.SetKeyName(12, "Livestock Case (small).png");
            this.SmallImages.Images.SetKeyName(13, "Outbreak-(small).png");
            this.SmallImages.Images.SetKeyName(14, "Outbreak-Journal-(small).png");
            this.SmallImages.Images.SetKeyName(15, "Sample-Accession-(small).png");
            this.SmallImages.Images.SetKeyName(16, "Sample-Disposition-(small).png");
            this.SmallImages.Images.SetKeyName(17, "Sample-Disposition-Journal-(small).png");
            this.SmallImages.Images.SetKeyName(18, "Sample-Journal-(small).png");
            this.SmallImages.Images.SetKeyName(19, "Sample-Transfer-in-(small).png");
            this.SmallImages.Images.SetKeyName(20, "Sample-Transfer-Journal-(small).png");
            this.SmallImages.Images.SetKeyName(21, "Sample-Transfer-Out-(small).png");
            this.SmallImages.Images.SetKeyName(22, "Search-Human-Case-(small).png");
            this.SmallImages.Images.SetKeyName(23, "Search-Human-Case-in-Browse-Mode-(small)1.png");
            this.SmallImages.Images.SetKeyName(24, "Search-Human-Cases-for-de-duplication-(small).png");
            this.SmallImages.Images.SetKeyName(25, "Search-Vet-Case-(small)2.png");
            this.SmallImages.Images.SetKeyName(26, "Select-Tests-(small).png");
            this.SmallImages.Images.SetKeyName(27, "Test-Journal-(small).png");
            this.SmallImages.Images.SetKeyName(28, "Vet-Aggregate-Actions-Entry-(small).png");
            this.SmallImages.Images.SetKeyName(29, "Vet-Aggregate-Entry-(small)1.png");
            this.SmallImages.Images.SetKeyName(30, "Human Aggregate Cases Summary (small)(11).png");
            this.SmallImages.Images.SetKeyName(31, "Vet Aggregate Actions Summary (small)(07).png");
            this.SmallImages.Images.SetKeyName(32, "Vet Aggregate Cases Summary (small)(09).png");
            this.SmallImages.Images.SetKeyName(33, "usa-flag-icon.png");
            this.SmallImages.Images.SetKeyName(34, "armenia-flag.png");
            this.SmallImages.Images.SetKeyName(35, "azerbaijan-flag.png");
            this.SmallImages.Images.SetKeyName(36, "georgia_flag.png");
            this.SmallImages.Images.SetKeyName(37, "kazakhstan-flag.png");
            this.SmallImages.Images.SetKeyName(38, "russia-flag.png");
            this.SmallImages.Images.SetKeyName(39, "ukraine-flag.png");
            this.SmallImages.Images.SetKeyName(40, "Active-Surveillance-Campaign-small.png");
            this.SmallImages.Images.SetKeyName(41, "Active-Surveillance-Session-small.png");
            this.SmallImages.Images.SetKeyName(42, "Organizations List (small)(59.7).png");
            this.SmallImages.Images.SetKeyName(43, "Administration(56).png");
            this.SmallImages.Images.SetKeyName(44, "Unique Numbering Schema List (small)51.png");
            this.SmallImages.Images.SetKeyName(45, "Aggregate Settings (small)(53).png");
            this.SmallImages.Images.SetKeyName(46, "Employees List (small)(57).png");
            this.SmallImages.Images.SetKeyName(47, "FlexibleFormsDesigner (small)(49).png");
            this.SmallImages.Images.SetKeyName(48, "Map Customization (small)(55).png");
            this.SmallImages.Images.SetKeyName(49, "ParameterTypesEditor (small)(47).png");
            this.SmallImages.Images.SetKeyName(50, "Permissions (small)(67).png");
            this.SmallImages.Images.SetKeyName(51, "Settlements List (small)(61).png");
            this.SmallImages.Images.SetKeyName(52, "Statistical Data List (small)(63).png");
            this.SmallImages.Images.SetKeyName(53, "Configuration(42).png");
            this.SmallImages.Images.SetKeyName(54, "Aggregate Matrix (small)(43).png");
            this.SmallImages.Images.SetKeyName(55, "Change password (small)(21).png");
            this.SmallImages.Images.SetKeyName(56, "Data Access Types (small)(29).png");
            this.SmallImages.Images.SetKeyName(57, "Data Audit Transactions List (small)(37).png");
            this.SmallImages.Images.SetKeyName(58, "EIDSS Sites List (small)(31).png");
            this.SmallImages.Images.SetKeyName(59, "Event Log (small)(35).png");
            this.SmallImages.Images.SetKeyName(60, "Exit(16).png");
            this.SmallImages.Images.SetKeyName(61, "Lab Sample Log Book (small)(13).png");
            this.SmallImages.Images.SetKeyName(62, "Launch AVR(39).png");
            this.SmallImages.Images.SetKeyName(63, "Options (small)(17).png");
            this.SmallImages.Images.SetKeyName(64, "Reference Book (small)(40).png");
            this.SmallImages.Images.SetKeyName(65, "Reference Matrix (small)(45).png");
            this.SmallImages.Images.SetKeyName(66, "Security Policy (small)(23).png");
            this.SmallImages.Images.SetKeyName(67, "Segurity Event Log (small)(33).png");
            this.SmallImages.Images.SetKeyName(68, "Site Alerts Subscriptions (small)(19).png");
            this.SmallImages.Images.SetKeyName(69, "Switch User(15).png");
            this.SmallImages.Images.SetKeyName(70, "System Functions (small)(27).png");
            this.SmallImages.Images.SetKeyName(71, "User Group List (small)(25).png");
            this.SmallImages.Images.SetKeyName(72, "Vector Surveillance Session (small)(02).png");
            this.SmallImages.Images.SetKeyName(73, "Vector Surveillance Sessions List (small)(04).png");
            this.SmallImages.Images.SetKeyName(74, "Human-Aggregate-Case-List-(small).png");
            this.SmallImages.Images.SetKeyName(75, "Vet-Aggregate-Action-List(small).png");
            this.SmallImages.Images.SetKeyName(76, "Vet-Aggregate-Case-List(small).png");
            this.SmallImages.Images.SetKeyName(77, "Print-Barcodes.png");
            this.SmallImages.Images.SetKeyName(78, "DataArchiveSettings_Small.png");
            this.SmallImages.Images.SetKeyName(79, "Persons-List-small.png");
            this.SmallImages.Images.SetKeyName(80, "iraq-flag.png");
            this.SmallImages.Images.SetKeyName(81, "reportIcon.ico");
            this.SmallImages.Images.SetKeyName(82, "pdf.ico");
            this.SmallImages.Images.SetKeyName(83, "bss_detail_16x16.png");
            this.SmallImages.Images.SetKeyName(84, "bss_list_16x16.png");
            this.SmallImages.Images.SetKeyName(85, "bss_aggregate_detail_16x16.png");
            this.SmallImages.Images.SetKeyName(86, "bss_aggregate_list_16x16.png");
            this.SmallImages.Images.SetKeyName(87, "bss_aberration_report_16x16.png");
            this.SmallImages.Images.SetKeyName(88, "admin_report_16x16.png");
            this.SmallImages.Images.SetKeyName(89, "human_aberration_report_16x16.png");
            this.SmallImages.Images.SetKeyName(90, "human_report_16x16.png");
            this.SmallImages.Images.SetKeyName(91, "lab_report_16x16.png");
            this.SmallImages.Images.SetKeyName(92, "vet_report_16x16.png");
            this.SmallImages.Images.SetKeyName(93, "epi_info_16x16.png");
            this.SmallImages.Images.SetKeyName(94, "human_aggregate_deduplication_16x16.png");
            this.SmallImages.Images.SetKeyName(95, "vet_aggregate_action_deduplication_16x16.png");
            this.SmallImages.Images.SetKeyName(96, "vet_aggregate_deduplication_16x16.png");
            this.SmallImages.Images.SetKeyName(97, "vet_aberration_report_16x16.png");
            this.SmallImages.Images.SetKeyName(98, "replicate_data_16x16.png");
            this.SmallImages.Images.SetKeyName(99, "aberration_report_16x16.png");
            this.SmallImages.Images.SetKeyName(100, "thailand_flag_16.png");
            // 
            // BigImages
            // 
            this.BigImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("BigImages.ImageStream")));
            this.BigImages.TransparentColor = System.Drawing.Color.Transparent;
            this.BigImages.Images.SetKeyName(0, "Sample-Accession-(large).png");
            this.BigImages.Images.SetKeyName(1, "Active-Surviellance-Campaign-(large).png");
            this.BigImages.Images.SetKeyName(2, "Active-Surviellance-Session-(large).png");
            this.BigImages.Images.SetKeyName(3, "Search-Human-Case-(large).png");
            this.BigImages.Images.SetKeyName(4, "Search-Vet-Case-(large).png");
            this.BigImages.Images.SetKeyName(5, "Avian-Case-(large).png");
            this.BigImages.Images.SetKeyName(6, "Livestock Case (large).png");
            this.BigImages.Images.SetKeyName(7, "Human-Case-(large).png");
            this.BigImages.Images.SetKeyName(8, "Outbreak-(large).png");
            this.BigImages.Images.SetKeyName(9, "Farm-Journal-(large).png");
            this.BigImages.Images.SetKeyName(10, "Human-Aggregate-Entry-(large).png");
            this.BigImages.Images.SetKeyName(11, "Vet-Aggregate-Entry-(large).png");
            this.BigImages.Images.SetKeyName(12, "Vet-Aggregate-Actions-Entry-(large).png");
            this.BigImages.Images.SetKeyName(13, "Sample-Journal-(large).png");
            this.BigImages.Images.SetKeyName(14, "Sample-Transfer-Journal-(small).png");
            this.BigImages.Images.SetKeyName(15, "Test Journal (large).png");
            this.BigImages.Images.SetKeyName(16, "Batch-Journal-(large).png");
            this.BigImages.Images.SetKeyName(17, "View-Human-Aggregate-Case-Summary-(large).png");
            this.BigImages.Images.SetKeyName(18, "View-Vet-Aggregate-Case-Summary-(large).png");
            this.BigImages.Images.SetKeyName(19, "View-Vet-Aggregate-Action-Summary-(large).png");
            this.BigImages.Images.SetKeyName(20, "Human-Case-De-duplication-(large).png");
            this.BigImages.Images.SetKeyName(21, "help.png");
            this.BigImages.Images.SetKeyName(22, "united-states-flag.png");
            this.BigImages.Images.SetKeyName(23, "armenia-flag(2).png");
            this.BigImages.Images.SetKeyName(24, "azerbaijan-flag(2).png");
            this.BigImages.Images.SetKeyName(25, "georgia-flag(2).png");
            this.BigImages.Images.SetKeyName(26, "kazakhstan-flag(2).png");
            this.BigImages.Images.SetKeyName(27, "russianfederation.png");
            this.BigImages.Images.SetKeyName(28, "ukraine-flag(2).png");
            this.BigImages.Images.SetKeyName(29, "Search-Human-Case-in-Browse-Mode-(large).png");
            this.BigImages.Images.SetKeyName(30, "Organizations List (large)(60).png");
            this.BigImages.Images.SetKeyName(31, "Vector Surveillance Session (large)(01).png");
            this.BigImages.Images.SetKeyName(32, "Vector Surveillance Sessions List (large)(03).png");
            this.BigImages.Images.SetKeyName(33, "Lab Sample Log Book (large)(12).png");
            this.BigImages.Images.SetKeyName(34, "iraq-flag(2).png");
            this.BigImages.Images.SetKeyName(35, "bss_detail_32x32.png");
            this.BigImages.Images.SetKeyName(36, "bss_list_32x32.png");
            this.BigImages.Images.SetKeyName(37, "bss_aggregate_detail_32x32.png");
            this.BigImages.Images.SetKeyName(38, "bss_aggregate_list_32x32.png");
            this.BigImages.Images.SetKeyName(39, "AsSessionList_32x32.png");
            this.BigImages.Images.SetKeyName(40, "thailand_flag_32.png");
            // 
            // Timer1
            // 
            this.Timer1.Enabled = true;
            this.Timer1.Interval = 10000D;
            this.Timer1.SynchronizingObject = this;
            this.Timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.Timer1_Elapsed);
            // 
            // DefaultLookAndFeel1
            // 
            this.DefaultLookAndFeel1.LookAndFeel.SkinName = "iMaginary";
            // 
            // ToolTipController
            // 
            // 
            // 
            // 
            this.ToolTipController.DefaultController.Appearance.Options.UseFont = true;
            this.ToolTipController.DefaultController.AppearanceTitle.Options.UseFont = true;
            this.ToolTipController.DefaultController.AutoPopDelay = 10000;
            // 
            // panel1
            // 
            this.ToolTipController.SetAllowHtmlText(this.panel1, ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("panel1.AllowHtmlText"))));
            this.panel1.BackgroundImage = global::eidss.main.Properties.Resources.EIdss_background;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // MainForm
            // 
            this.ToolTipController.SetAllowHtmlText(this, ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("$this.AllowHtmlText"))));
            this.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("MainForm.Appearance.BackColor")));
            this.Appearance.Options.UseBackColor = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Center;
            this.BackgroundImageStore = global::eidss.main.Properties.Resources.EIdss_background;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.VisibleChanged += new System.EventHandler(this.MainForm_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultBarAndDockingController1.Controller)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Timer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar tbToolbar;
        private DevExpress.XtraBars.Bar tbMenu;
        private DevExpress.XtraBars.Bar tbStatusbar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        internal DevExpress.Utils.DefaultToolTipController ToolTipController;
        internal System.Timers.Timer Timer1;
        internal System.Windows.Forms.ImageList SmallImages;
        internal DevExpress.XtraBars.DefaultBarAndDockingController DefaultBarAndDockingController1;
        internal System.Windows.Forms.ImageList BigImages;
        internal DevExpress.LookAndFeel.DefaultLookAndFeel DefaultLookAndFeel1;
        internal DevExpress.XtraBars.BarStaticItem sbiUserLabel;
        internal DevExpress.XtraBars.BarStaticItem sbiUser;
        internal DevExpress.XtraBars.BarStaticItem sbiOrganizationLable;
        internal DevExpress.XtraBars.BarStaticItem sbiOrganization;
        internal DevExpress.XtraBars.BarStaticItem sbiSiteLable;
        internal DevExpress.XtraBars.BarStaticItem sbiSite;
        internal DevExpress.XtraBars.BarStaticItem sbiCountryLabel;
        internal DevExpress.XtraBars.BarStaticItem sbiCountry;
        internal DevExpress.XtraBars.BarStaticItem sbiDate;
        internal DevExpress.XtraBars.BarStaticItem sbiTime;
        private System.Windows.Forms.Panel panel1;
    }
}
