namespace EIDSS.RAM.Layout
{
    partial class MapForm
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
            nbContainerSettings = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapForm));
            this.grcMapMain = new DevExpress.XtraEditors.GroupControl();
            this.grcMapSettings = new DevExpress.XtraEditors.GroupControl();
            this.tbMapName = new DevExpress.XtraEditors.TextEdit();
            this.memFilter = new DevExpress.XtraEditors.MemoEdit();
            this.lblFilter = new System.Windows.Forms.Label();
            this.lblMapName = new System.Windows.Forms.Label();
            this.cbAdministrativeUnit = new DevExpress.XtraEditors.LookUpEdit();
            this.lblMapField = new System.Windows.Forms.Label();
            this.grcMain = new DevExpress.XtraEditors.GroupControl();
            this.grcMap = new DevExpress.XtraEditors.GroupControl();
            this.nbControlMaps = new DevExpress.XtraNavBar.NavBarControl();
            this.nbGroupSettings = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbContainerSettings = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.printingSystem = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.timerLoadMap = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grcMapMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcMapSettings)).BeginInit();
            this.grcMapSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMapName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAdministrativeUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcMain)).BeginInit();
            this.grcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcMap)).BeginInit();
            this.grcMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbControlMaps)).BeginInit();
            this.nbControlMaps.SuspendLayout();
            this.nbContainerSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).BeginInit();
            this.SuspendLayout();
            // 
            // grcMapMain
            // 
            resources.ApplyResources(this.grcMapMain, "grcMapMain");
            this.grcMapMain.Name = "grcMapMain";
            // 
            // grcMapSettings
            // 
            this.grcMapSettings.Controls.Add(this.tbMapName);
            this.grcMapSettings.Controls.Add(this.memFilter);
            this.grcMapSettings.Controls.Add(this.lblFilter);
            this.grcMapSettings.Controls.Add(this.lblMapName);
            this.grcMapSettings.Controls.Add(this.cbAdministrativeUnit);
            this.grcMapSettings.Controls.Add(this.lblMapField);
            resources.ApplyResources(this.grcMapSettings, "grcMapSettings");
            this.grcMapSettings.Name = "grcMapSettings";
            this.grcMapSettings.ShowCaption = false;
            // 
            // tbMapName
            // 
            resources.ApplyResources(this.tbMapName, "tbMapName");
            this.tbMapName.Name = "tbMapName";
            this.tbMapName.Properties.Appearance.Options.UseFont = true;
            this.tbMapName.Properties.AppearanceDisabled.Options.UseFont = true;
            this.tbMapName.Properties.AppearanceFocused.Options.UseFont = true;
            this.tbMapName.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.tbMapName.Tag = "{alwayseditable}";
            // 
            // memFilter
            // 
            resources.ApplyResources(this.memFilter, "memFilter");
            this.memFilter.Name = "memFilter";
            this.memFilter.Properties.Appearance.Options.UseFont = true;
            this.memFilter.Properties.AppearanceDisabled.Options.UseFont = true;
            this.memFilter.Properties.AppearanceFocused.Options.UseFont = true;
            this.memFilter.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.memFilter.Tag = "{alwayseditable}";
            // 
            // lblFilter
            // 
            resources.ApplyResources(this.lblFilter, "lblFilter");
            this.lblFilter.Name = "lblFilter";
            // 
            // lblMapName
            // 
            resources.ApplyResources(this.lblMapName, "lblMapName");
            this.lblMapName.Name = "lblMapName";
            // 
            // cbAdministrativeUnit
            // 
            resources.ApplyResources(this.cbAdministrativeUnit, "cbAdministrativeUnit");
            this.cbAdministrativeUnit.Name = "cbAdministrativeUnit";
            this.cbAdministrativeUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbAdministrativeUnit.Properties.Buttons"))))});
            this.cbAdministrativeUnit.Properties.NullText = resources.GetString("cbAdministrativeUnit.Properties.NullText");
            this.cbAdministrativeUnit.Tag = "{alwayseditable}";
            this.cbAdministrativeUnit.EditValueChanged += new System.EventHandler(this.cbMapField_EditValueChanged);
            this.cbAdministrativeUnit.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.cbAdministrativeUnit_EditValueChanging);
            // 
            // lblMapField
            // 
            resources.ApplyResources(this.lblMapField, "lblMapField");
            this.lblMapField.Name = "lblMapField";
            // 
            // grcMain
            // 
            this.grcMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grcMain.Controls.Add(this.grcMap);
            resources.ApplyResources(this.grcMain, "grcMain");
            this.grcMain.Name = "grcMain";
            this.grcMain.ShowCaption = false;
            // 
            // grcMap
            // 
            this.grcMap.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grcMap.Controls.Add(this.grcMapMain);
            this.grcMap.Controls.Add(this.nbControlMaps);
            resources.ApplyResources(this.grcMap, "grcMap");
            this.grcMap.MinimumSize = new System.Drawing.Size(400, 300);
            this.grcMap.Name = "grcMap";
            this.grcMap.ShowCaption = false;
            // 
            // nbControlMaps
            // 
            this.nbControlMaps.ActiveGroup = this.nbGroupSettings;
            this.nbControlMaps.ContentButtonHint = null;
            this.nbControlMaps.Controls.Add(this.nbContainerSettings);
            resources.ApplyResources(this.nbControlMaps, "nbControlMaps");
            this.nbControlMaps.ExplorerBarGroupInterval = 1;
            this.nbControlMaps.ExplorerBarGroupOuterIndent = 0;
            this.nbControlMaps.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nbGroupSettings});
            this.nbControlMaps.LookAndFeel.SkinName = "Black";
            this.nbControlMaps.LookAndFeel.UseDefaultLookAndFeel = false;
            this.nbControlMaps.Name = "nbControlMaps";
            this.nbControlMaps.OptionsNavPane.ExpandedWidth = ((int)(resources.GetObject("resource.ExpandedWidth")));
            this.nbControlMaps.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinExplorerBarViewInfoRegistrator("Blue");
            this.nbControlMaps.GroupExpanded += new DevExpress.XtraNavBar.NavBarGroupEventHandler(this.nbControlMaps_GroupExpanded);
            this.nbControlMaps.GroupCollapsed += new DevExpress.XtraNavBar.NavBarGroupEventHandler(this.nbControlMaps_GroupCollapsed);
            // 
            // nbGroupSettings
            // 
            resources.ApplyResources(this.nbGroupSettings, "nbGroupSettings");
            this.nbGroupSettings.ControlContainer = this.nbContainerSettings;
            this.nbGroupSettings.Expanded = true;
            this.nbGroupSettings.GroupClientHeight = 66;
            this.nbGroupSettings.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.nbGroupSettings.Name = "nbGroupSettings";
            // 
            // nbContainerSettings
            // 
            this.nbContainerSettings.Controls.Add(this.grcMapSettings);
            this.nbContainerSettings.Name = "nbContainerSettings";
            resources.ApplyResources(this.nbContainerSettings, "nbContainerSettings");
            // 
            // timerLoadMap
            // 
            this.timerLoadMap.Interval = 200;
            this.timerLoadMap.Tick += new System.EventHandler(this.timerLoadMap_Tick);
            // 
            // MapForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grcMain);
            this.HelpTopicID = "AVR_in_Maps";
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "MapForm";
            ((System.ComponentModel.ISupportInitialize)(this.grcMapMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcMapSettings)).EndInit();
            this.grcMapSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbMapName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAdministrativeUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcMain)).EndInit();
            this.grcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcMap)).EndInit();
            this.grcMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nbControlMaps)).EndInit();
            this.nbControlMaps.ResumeLayout(false);
            this.nbContainerSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grcMain;
        private DevExpress.XtraEditors.GroupControl grcMap;
        private DevExpress.XtraEditors.GroupControl grcMapMain;
        private DevExpress.XtraEditors.GroupControl grcMapSettings;
        private System.Windows.Forms.Label lblMapField;
        private DevExpress.XtraEditors.LookUpEdit cbAdministrativeUnit;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem;
        private DevExpress.XtraNavBar.NavBarControl nbControlMaps;
        private DevExpress.XtraNavBar.NavBarGroup nbGroupSettings;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer nbContainerSettings;
        private System.Windows.Forms.Timer timerLoadMap;
        private DevExpress.XtraEditors.TextEdit tbMapName;
        private DevExpress.XtraEditors.MemoEdit memFilter;
        private System.Windows.Forms.Label lblMapName;
        private System.Windows.Forms.Label lblFilter;
        
    }
}