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
            this.LayersTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayersTabControl.Location = new System.Drawing.Point(0, 0);
            this.LayersTabControl.Name = "LayersTabControl";
            this.LayersTabControl.SelectedTabPage = this.systemTab;
            this.LayersTabControl.Size = new System.Drawing.Size(546, 406);
            this.LayersTabControl.TabIndex = 0;
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
            this.systemTab.Controls.Add(this.systemLayersList);
            this.systemTab.Name = "systemTab";
            this.systemTab.Size = new System.Drawing.Size(540, 380);
            this.systemTab.Text = "EIDSS DB layers";
            // 
            // systemLayersList
            // 
            this.systemLayersList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.systemLayersList.Location = new System.Drawing.Point(0, 0);
            this.systemLayersList.Name = "systemLayersList";
            this.systemLayersList.Size = new System.Drawing.Size(540, 380);
            this.systemLayersList.TabIndex = 0;
            this.systemLayersList.SelectedIndexChanged += new System.EventHandler(this.CheckAddButtonEnable);
            // 
            // additionalTab
            // 
            this.additionalTab.Controls.Add(this.extSysLayersList);
            this.additionalTab.Name = "additionalTab";
            this.additionalTab.Size = new System.Drawing.Size(540, 380);
            this.additionalTab.Text = "Additional EIDSS DB layers";
            // 
            // extSysLayersList
            // 
            this.extSysLayersList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extSysLayersList.Location = new System.Drawing.Point(0, 0);
            this.extSysLayersList.Name = "extSysLayersList";
            this.extSysLayersList.Size = new System.Drawing.Size(540, 380);
            this.extSysLayersList.TabIndex = 0;
            this.extSysLayersList.SelectedIndexChanged += new System.EventHandler(this.CheckAddButtonEnable);
            // 
            // bufZoneTab
            // 
            this.bufZoneTab.Controls.Add(this.bufZoneLayersGrid);
            this.bufZoneTab.Name = "bufZoneTab";
            this.bufZoneTab.Size = new System.Drawing.Size(540, 380);
            this.bufZoneTab.Text = "Buffer zone layers";
            // 
            // bufZoneLayersGrid
            // 
            this.bufZoneLayersGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bufZoneLayersGrid.Location = new System.Drawing.Point(0, 0);
            this.bufZoneLayersGrid.MainView = this.bufLayersGridView;
            this.bufZoneLayersGrid.Name = "bufZoneLayersGrid";
            this.bufZoneLayersGrid.Size = new System.Drawing.Size(540, 380);
            this.bufZoneLayersGrid.TabIndex = 1;
            this.bufZoneLayersGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bufLayersGridView});
            // 
            // bufLayersGridView
            // 
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
            this.avrTab.Name = "avrTab";
            this.avrTab.PageVisible = false;
            this.avrTab.Size = new System.Drawing.Size(540, 380);
            this.avrTab.Text = "AVR saved layers";
            // 
            // importedTab
            // 
            this.importedTab.Name = "importedTab";
            this.importedTab.PageVisible = false;
            this.importedTab.Size = new System.Drawing.Size(540, 380);
            this.importedTab.Text = "Imported layers";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.PropertiesButton);
            this.panelControl1.Controls.Add(this.RemoveButton);
            this.panelControl1.Controls.Add(this.AddButton);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 406);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(546, 34);
            this.panelControl1.TabIndex = 1;
            // 
            // PropertiesButton
            // 
            this.PropertiesButton.Location = new System.Drawing.Point(124, 5);
            this.PropertiesButton.Name = "PropertiesButton";
            this.PropertiesButton.Size = new System.Drawing.Size(103, 23);
            this.PropertiesButton.TabIndex = 2;
            this.PropertiesButton.Text = "Properties";
            this.PropertiesButton.Visible = false;
            this.PropertiesButton.Click += new System.EventHandler(this.PropertiesButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Enabled = false;
            this.RemoveButton.Location = new System.Drawing.Point(5, 5);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(113, 23);
            this.RemoveButton.TabIndex = 1;
            this.RemoveButton.Text = "Remove from DB";
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Location = new System.Drawing.Point(428, 5);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(113, 23);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Add to map";
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DbLayersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 440);
            this.Controls.Add(this.LayersTabControl);
            this.Controls.Add(this.panelControl1);
            this.MinimumSize = new System.Drawing.Size(300, 250);
            this.Name = "DbLayersForm";
            this.Text = "DB Layers";
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