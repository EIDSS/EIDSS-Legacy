namespace eidss.avr.ChartForm
{
    partial class ChartDetailPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartDetailPanel));
            this.ChartGroup = new DevExpress.XtraEditors.GroupControl();
            this.ChartPlaceHolder = new eidss.avr.ChartForm.ChartPlaceHolder();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.leSeries = new DevExpress.XtraEditors.LookUpEdit();
            this.labelSeries = new DevExpress.XtraEditors.LabelControl();
            this.ce3D = new DevExpress.XtraEditors.CheckEdit();
            this.ceLegendVisibility = new DevExpress.XtraEditors.CheckEdit();
            this.MainGroup = new DevExpress.XtraEditors.GroupControl();
            this.splitter = new DevExpress.XtraEditors.SplitterControl();
            this.SettingsNavBar = new DevExpress.XtraNavBar.NavBarControl();
            this.CustomizationNavBarGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.SettingsContainer = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.SettingsGroup = new DevExpress.XtraEditors.GroupControl();
            this.scrollableMain = new DevExpress.XtraEditors.XtraScrollableControl();
            this.printingSystem = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.toolTipController = new DevExpress.Utils.ToolTipController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ChartGroup)).BeginInit();
            this.ChartGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leSeries.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ce3D.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceLegendVisibility.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainGroup)).BeginInit();
            this.MainGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsNavBar)).BeginInit();
            this.SettingsNavBar.SuspendLayout();
            this.SettingsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsGroup)).BeginInit();
            this.SettingsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(ChartDetailPanel), out resources);
            // Form Is Localizable: True
            // 
            // ChartGroup
            // 
            this.ChartGroup.Controls.Add(this.ChartPlaceHolder);
            this.ChartGroup.Controls.Add(this.panelControl1);
            resources.ApplyResources(this.ChartGroup, "ChartGroup");
            this.ChartGroup.Name = "ChartGroup";
            // 
            // ChartPlaceHolder
            // 
            this.ChartPlaceHolder.AxisXTitle = "";
            this.ChartPlaceHolder.AxisYTitle = "";
            this.ChartPlaceHolder.ChartName = "Chart Title";
            resources.ApplyResources(this.ChartPlaceHolder, "ChartPlaceHolder");
            this.ChartPlaceHolder.Name = "ChartPlaceHolder";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.leSeries);
            this.panelControl1.Controls.Add(this.labelSeries);
            this.panelControl1.Controls.Add(this.ce3D);
            this.panelControl1.Controls.Add(this.ceLegendVisibility);
            resources.ApplyResources(this.panelControl1, "panelControl1");
            this.panelControl1.Name = "panelControl1";
            // 
            // leSeries
            // 
            resources.ApplyResources(this.leSeries, "leSeries");
            this.leSeries.Name = "leSeries";
            this.leSeries.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leSeries.Properties.Buttons"))))});
            this.leSeries.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("leSeries.Properties.Columns"), resources.GetString("leSeries.Properties.Columns1"))});
            this.leSeries.Properties.DisplayMember = "Text";
            this.leSeries.Properties.NullText = resources.GetString("leSeries.Properties.NullText");
            this.leSeries.Properties.ValueMember = "Index";
            this.leSeries.EditValueChanged += new System.EventHandler(this.leSeries_EditValueChanged);
            // 
            // labelSeries
            // 
            resources.ApplyResources(this.labelSeries, "labelSeries");
            this.labelSeries.Name = "labelSeries";
            // 
            // ce3D
            // 
            resources.ApplyResources(this.ce3D, "ce3D");
            this.ce3D.Name = "ce3D";
            this.ce3D.Properties.Caption = resources.GetString("ce3D.Properties.Caption");
            this.ce3D.CheckedChanged += new System.EventHandler(this.ce3D_CheckedChanged);
            // 
            // ceLegendVisibility
            // 
            resources.ApplyResources(this.ceLegendVisibility, "ceLegendVisibility");
            this.ceLegendVisibility.Name = "ceLegendVisibility";
            this.ceLegendVisibility.Properties.Caption = resources.GetString("ceLegendVisibility.Properties.Caption");
            this.ceLegendVisibility.CheckedChanged += new System.EventHandler(this.ceLegendVisibility_CheckedChanged);
            // 
            // MainGroup
            // 
            this.MainGroup.Appearance.Options.UseFont = true;
            this.MainGroup.AppearanceCaption.Options.UseFont = true;
            this.MainGroup.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.MainGroup.Controls.Add(this.ChartGroup);
            this.MainGroup.Controls.Add(this.splitter);
            this.MainGroup.Controls.Add(this.SettingsNavBar);
            resources.ApplyResources(this.MainGroup, "MainGroup");
            this.MainGroup.Name = "MainGroup";
            this.MainGroup.ShowCaption = false;
            // 
            // splitter
            // 
            this.splitter.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.splitter, "splitter");
            this.splitter.Name = "splitter";
            this.splitter.TabStop = false;
            // 
            // SettingsNavBar
            // 
            this.SettingsNavBar.ActiveGroup = this.CustomizationNavBarGroup;
            this.SettingsNavBar.Appearance.Background.Options.UseFont = true;
            this.SettingsNavBar.Appearance.Button.Options.UseFont = true;
            this.SettingsNavBar.Appearance.ButtonDisabled.Options.UseFont = true;
            this.SettingsNavBar.Appearance.ButtonHotTracked.Options.UseFont = true;
            this.SettingsNavBar.Appearance.ButtonPressed.Options.UseFont = true;
            this.SettingsNavBar.Appearance.GroupBackground.Options.UseFont = true;
            this.SettingsNavBar.Appearance.GroupHeader.Options.UseFont = true;
            this.SettingsNavBar.Appearance.GroupHeaderActive.Options.UseFont = true;
            this.SettingsNavBar.Appearance.GroupHeaderHotTracked.Options.UseFont = true;
            this.SettingsNavBar.Appearance.GroupHeaderPressed.Options.UseFont = true;
            this.SettingsNavBar.Appearance.Hint.Options.UseFont = true;
            this.SettingsNavBar.Appearance.Item.Options.UseFont = true;
            this.SettingsNavBar.Appearance.ItemActive.Options.UseFont = true;
            this.SettingsNavBar.Appearance.ItemDisabled.Options.UseFont = true;
            this.SettingsNavBar.Appearance.ItemHotTracked.Options.UseFont = true;
            this.SettingsNavBar.Appearance.ItemPressed.Options.UseFont = true;
            this.SettingsNavBar.Appearance.LinkDropTarget.Options.UseFont = true;
            this.SettingsNavBar.Appearance.NavigationPaneHeader.Options.UseFont = true;
            this.SettingsNavBar.Appearance.NavPaneContentButton.Options.UseFont = true;
            this.SettingsNavBar.Appearance.NavPaneContentButtonHotTracked.Options.UseFont = true;
            this.SettingsNavBar.Appearance.NavPaneContentButtonPressed.Options.UseFont = true;
            this.SettingsNavBar.Appearance.NavPaneContentButtonReleased.Options.UseFont = true;
            this.SettingsNavBar.ContentButtonHint = null;
            this.SettingsNavBar.Controls.Add(this.SettingsContainer);
            resources.ApplyResources(this.SettingsNavBar, "SettingsNavBar");
            this.SettingsNavBar.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.CustomizationNavBarGroup});
            this.SettingsNavBar.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.SettingsNavBar.Name = "SettingsNavBar";
            this.SettingsNavBar.NavigationPaneMaxVisibleGroups = 0;
            this.SettingsNavBar.NavigationPaneOverflowPanelUseSmallImages = false;
            this.SettingsNavBar.OptionsNavPane.ExpandedWidth = ((int)(resources.GetObject("resource.ExpandedWidth")));
            this.SettingsNavBar.OptionsNavPane.ShowOverflowPanel = false;
            this.SettingsNavBar.OptionsNavPane.ShowSplitter = false;
            this.SettingsNavBar.View = new DevExpress.XtraNavBar.ViewInfo.SkinNavigationPaneViewInfoRegistrator();
            // 
            // CustomizationNavBarGroup
            // 
            resources.ApplyResources(this.CustomizationNavBarGroup, "CustomizationNavBarGroup");
            this.CustomizationNavBarGroup.ControlContainer = this.SettingsContainer;
            this.CustomizationNavBarGroup.Expanded = true;
            this.CustomizationNavBarGroup.GroupClientHeight = 702;
            this.CustomizationNavBarGroup.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.CustomizationNavBarGroup.Name = "CustomizationNavBarGroup";
            // 
            // SettingsContainer
            // 
            this.SettingsContainer.Controls.Add(this.SettingsGroup);
            this.SettingsContainer.Name = "SettingsContainer";
            resources.ApplyResources(this.SettingsContainer, "SettingsContainer");
            // 
            // SettingsGroup
            // 
            this.SettingsGroup.Appearance.Options.UseFont = true;
            this.SettingsGroup.AppearanceCaption.Options.UseFont = true;
            this.SettingsGroup.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.SettingsGroup.Controls.Add(this.scrollableMain);
            resources.ApplyResources(this.SettingsGroup, "SettingsGroup");
            this.SettingsGroup.Name = "SettingsGroup";
            this.SettingsGroup.ShowCaption = false;
            // 
            // scrollableMain
            // 
            resources.ApplyResources(this.scrollableMain, "scrollableMain");
            this.scrollableMain.Name = "scrollableMain";
            // 
            // fontDialog
            // 
            this.fontDialog.ShowColor = true;
            // 
            // ChartDetailPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainGroup);
            this.DefaultFormState = System.Windows.Forms.FormWindowState.Normal;
            this.HelpTopicID = "AVR_Chart_Management";
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "ChartDetailPanel";
            this.Sizable = true;
            this.Status = bv.common.win.FormStatus.Draft;
            ((System.ComponentModel.ISupportInitialize)(this.ChartGroup)).EndInit();
            this.ChartGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.leSeries.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ce3D.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceLegendVisibility.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainGroup)).EndInit();
            this.MainGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SettingsNavBar)).EndInit();
            this.SettingsNavBar.ResumeLayout(false);
            this.SettingsContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SettingsGroup)).EndInit();
            this.SettingsGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl ChartGroup;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem;
        private DevExpress.XtraEditors.GroupControl MainGroup;
        private DevExpress.XtraEditors.SplitterControl splitter;
        private DevExpress.XtraNavBar.NavBarControl SettingsNavBar;
        private DevExpress.XtraNavBar.NavBarGroup CustomizationNavBarGroup;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer SettingsContainer;
        private DevExpress.XtraEditors.GroupControl SettingsGroup;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.XtraScrollableControl scrollableMain;
        internal ChartPlaceHolder ChartPlaceHolder;
        internal System.Windows.Forms.FontDialog fontDialog;
        private DevExpress.Utils.ToolTipController toolTipController;
        private DevExpress.XtraEditors.CheckEdit ceLegendVisibility;
        private DevExpress.XtraEditors.CheckEdit ce3D;
        private DevExpress.XtraEditors.LookUpEdit leSeries;
        private DevExpress.XtraEditors.LabelControl labelSeries;
        
    }
}