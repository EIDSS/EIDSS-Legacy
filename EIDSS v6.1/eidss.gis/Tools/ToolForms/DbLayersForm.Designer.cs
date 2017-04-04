namespace eidss.gis.Forms
{
    partial class DbLayersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DbLayersForm));
            this.LayersTabControl = new DevExpress.XtraTab.XtraTabControl();
            this.systemTab = new DevExpress.XtraTab.XtraTabPage();
            this.systemLayersList = new DevExpress.XtraEditors.ListBoxControl();
            this.additionalTab = new DevExpress.XtraTab.XtraTabPage();
            this.extSysLayersList = new DevExpress.XtraEditors.ListBoxControl();
            this.bufZoneTab = new DevExpress.XtraTab.XtraTabPage();
            this.bufZoneLayersGrid = new DevExpress.XtraGrid.GridControl();
            this.bufLayersGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.avrTab = new DevExpress.XtraTab.XtraTabPage();
            this.importedTab = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.PropertiesButton = new DevExpress.XtraEditors.SimpleButton();
            this.RemoveButton = new DevExpress.XtraEditors.SimpleButton();
            this.AddButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.LayersTabControl)).BeginInit();
            this.LayersTabControl.SuspendLayout();
            this.systemTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.systemLayersList)).BeginInit();
            this.additionalTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.extSysLayersList)).BeginInit();
            this.bufZoneTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bufZoneLayersGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bufLayersGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayersTabControl
            // 
            resources.ApplyResources(this.LayersTabControl, "LayersTabControl");
            this.LayersTabControl.Name = "LayersTabControl";
            this.LayersTabControl.SelectedTabPage = this.systemTab;
            this.LayersTabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.systemTab,
            this.additionalTab,
            this.bufZoneTab,
            this.avrTab,
            this.importedTab});
            this.LayersTabControl.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.LayersTabControl_SelectedPageChanged);
            // 
            // systemTab
            // 
            resources.ApplyResources(this.systemTab, "systemTab");
            this.systemTab.Controls.Add(this.systemLayersList);
            this.systemTab.Name = "systemTab";
            // 
            // systemLayersList
            // 
            resources.ApplyResources(this.systemLayersList, "systemLayersList");
            this.systemLayersList.Name = "systemLayersList";
            this.systemLayersList.SelectedIndexChanged += new System.EventHandler(this.CheckAddButtonEnable);
            // 
            // additionalTab
            // 
            resources.ApplyResources(this.additionalTab, "additionalTab");
            this.additionalTab.Controls.Add(this.extSysLayersList);
            this.additionalTab.Name = "additionalTab";
            // 
            // extSysLayersList
            // 
            resources.ApplyResources(this.extSysLayersList, "extSysLayersList");
            this.extSysLayersList.Name = "extSysLayersList";
            this.extSysLayersList.SelectedIndexChanged += new System.EventHandler(this.CheckAddButtonEnable);
            // 
            // bufZoneTab
            // 
            resources.ApplyResources(this.bufZoneTab, "bufZoneTab");
            this.bufZoneTab.Controls.Add(this.bufZoneLayersGrid);
            this.bufZoneTab.Name = "bufZoneTab";
            // 
            // bufZoneLayersGrid
            // 
            resources.ApplyResources(this.bufZoneLayersGrid, "bufZoneLayersGrid");
            this.bufZoneLayersGrid.EmbeddedNavigator.AccessibleDescription = resources.GetString("bufZoneLayersGrid.EmbeddedNavigator.AccessibleDescription");
            this.bufZoneLayersGrid.EmbeddedNavigator.AccessibleName = resources.GetString("bufZoneLayersGrid.EmbeddedNavigator.AccessibleName");
            this.bufZoneLayersGrid.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("bufZoneLayersGrid.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.bufZoneLayersGrid.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("bufZoneLayersGrid.EmbeddedNavigator.Anchor")));
            this.bufZoneLayersGrid.EmbeddedNavigator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bufZoneLayersGrid.EmbeddedNavigator.BackgroundImage")));
            this.bufZoneLayersGrid.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("bufZoneLayersGrid.EmbeddedNavigator.BackgroundImageLayout")));
            this.bufZoneLayersGrid.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("bufZoneLayersGrid.EmbeddedNavigator.ImeMode")));
            this.bufZoneLayersGrid.EmbeddedNavigator.MaximumSize = ((System.Drawing.Size)(resources.GetObject("bufZoneLayersGrid.EmbeddedNavigator.MaximumSize")));
            this.bufZoneLayersGrid.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("bufZoneLayersGrid.EmbeddedNavigator.TextLocation")));
            this.bufZoneLayersGrid.EmbeddedNavigator.ToolTip = resources.GetString("bufZoneLayersGrid.EmbeddedNavigator.ToolTip");
            this.bufZoneLayersGrid.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("bufZoneLayersGrid.EmbeddedNavigator.ToolTipIconType")));
            this.bufZoneLayersGrid.EmbeddedNavigator.ToolTipTitle = resources.GetString("bufZoneLayersGrid.EmbeddedNavigator.ToolTipTitle");
            this.bufZoneLayersGrid.MainView = this.bufLayersGridView;
            this.bufZoneLayersGrid.Name = "bufZoneLayersGrid";
            this.bufZoneLayersGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bufLayersGridView});
            // 
            // bufLayersGridView
            // 
            resources.ApplyResources(this.bufLayersGridView, "bufLayersGridView");
            this.bufLayersGridView.GridControl = this.bufZoneLayersGrid;
            this.bufLayersGridView.Name = "bufLayersGridView";
            this.bufLayersGridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.bufLayersGridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.bufLayersGridView.OptionsBehavior.Editable = false;
            this.bufLayersGridView.OptionsBehavior.ReadOnly = true;
            this.bufLayersGridView.OptionsCustomization.AllowColumnMoving = false;
            this.bufLayersGridView.OptionsCustomization.AllowGroup = false;
            this.bufLayersGridView.OptionsCustomization.AllowQuickHideColumns = false;
            this.bufLayersGridView.OptionsMenu.EnableColumnMenu = false;
            this.bufLayersGridView.OptionsMenu.EnableFooterMenu = false;
            this.bufLayersGridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.bufLayersGridView.OptionsSelection.UseIndicatorForSelection = false;
            this.bufLayersGridView.OptionsView.ShowDetailButtons = false;
            this.bufLayersGridView.OptionsView.ShowGroupPanel = false;
            this.bufLayersGridView.OptionsView.ShowIndicator = false;
            // 
            // avrTab
            // 
            resources.ApplyResources(this.avrTab, "avrTab");
            this.avrTab.Name = "avrTab";
            this.avrTab.PageVisible = false;
            // 
            // importedTab
            // 
            resources.ApplyResources(this.importedTab, "importedTab");
            this.importedTab.Name = "importedTab";
            this.importedTab.PageVisible = false;
            // 
            // panelControl1
            // 
            resources.ApplyResources(this.panelControl1, "panelControl1");
            this.panelControl1.Controls.Add(this.PropertiesButton);
            this.panelControl1.Controls.Add(this.RemoveButton);
            this.panelControl1.Controls.Add(this.AddButton);
            this.panelControl1.Name = "panelControl1";
            // 
            // PropertiesButton
            // 
            resources.ApplyResources(this.PropertiesButton, "PropertiesButton");
            this.PropertiesButton.Name = "PropertiesButton";
            this.PropertiesButton.Click += new System.EventHandler(this.PropertiesButton_Click);
            // 
            // RemoveButton
            // 
            resources.ApplyResources(this.RemoveButton, "RemoveButton");
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // AddButton
            // 
            resources.ApplyResources(this.AddButton, "AddButton");
            this.AddButton.Name = "AddButton";
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DbLayersForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LayersTabControl);
            this.Controls.Add(this.panelControl1);
            this.HelpTopicId = "Maps_Configuration";
            this.Name = "DbLayersForm";
            this.VisibleChanged += new System.EventHandler(this.DbLayersForm_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.LayersTabControl)).EndInit();
            this.LayersTabControl.ResumeLayout(false);
            this.systemTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.systemLayersList)).EndInit();
            this.additionalTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.extSysLayersList)).EndInit();
            this.bufZoneTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bufZoneLayersGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bufLayersGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl LayersTabControl;
        private DevExpress.XtraTab.XtraTabPage additionalTab;
        private DevExpress.XtraTab.XtraTabPage systemTab;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton AddButton;
        private DevExpress.XtraEditors.SimpleButton RemoveButton;
        private DevExpress.XtraTab.XtraTabPage bufZoneTab;
        private DevExpress.XtraTab.XtraTabPage avrTab;
        private DevExpress.XtraTab.XtraTabPage importedTab;
        private DevExpress.XtraEditors.ListBoxControl systemLayersList;
        private DevExpress.XtraEditors.ListBoxControl extSysLayersList;
        private DevExpress.XtraGrid.GridControl bufZoneLayersGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView bufLayersGridView;
        private DevExpress.XtraEditors.SimpleButton PropertiesButton;
    }
}