namespace eidss.avr.MapForm
{
    partial class MapDetailPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapDetailPanel));
            this.grcMapMain = new DevExpress.XtraEditors.GroupControl();
            this.grcMapSettings = new DevExpress.XtraEditors.GroupControl();
            this.cbAdministrativeUnit = new DevExpress.XtraEditors.LookUpEdit();
            this.lblMapField = new System.Windows.Forms.Label();
            this.grcMain = new DevExpress.XtraEditors.GroupControl();
            this.printingSystem = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            
            ((System.ComponentModel.ISupportInitialize)(this.grcMapMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcMapSettings)).BeginInit();
            this.grcMapSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbAdministrativeUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcMain)).BeginInit();
            this.grcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(MapDetailPanel), out resources);
            // Form Is Localizable: True
            // 
            // grcMapMain
            // 
            resources.ApplyResources(this.grcMapMain, "grcMapMain");
            this.grcMapMain.Name = "grcMapMain";
            this.grcMapMain.ShowCaption = false;
            // 
            // grcMapSettings
            // 
            this.grcMapSettings.Controls.Add(this.cbAdministrativeUnit);
            this.grcMapSettings.Controls.Add(this.lblMapField);
            resources.ApplyResources(this.grcMapSettings, "grcMapSettings");
            this.grcMapSettings.Name = "grcMapSettings";
            this.grcMapSettings.ShowCaption = false;
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
            this.grcMain.Controls.Add(this.grcMapMain);
            this.grcMain.Controls.Add(this.grcMapSettings);
            resources.ApplyResources(this.grcMain, "grcMain");
            this.grcMain.Name = "grcMain";
            this.grcMain.ShowCaption = false;
            // 
            // timerLoadMap
            // 
            // 
            // MapDetailPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grcMain);
            this.DefaultFormState = System.Windows.Forms.FormWindowState.Normal;
            this.HelpTopicID = "AVR_in_Maps";
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "MapDetailPanel";
            this.Status = bv.common.win.FormStatus.Draft;
            ((System.ComponentModel.ISupportInitialize)(this.grcMapMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcMapSettings)).EndInit();
            this.grcMapSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbAdministrativeUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcMain)).EndInit();
            this.grcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grcMain;
        private DevExpress.XtraEditors.GroupControl grcMapMain;
        private DevExpress.XtraEditors.GroupControl grcMapSettings;
        private System.Windows.Forms.Label lblMapField;
        private DevExpress.XtraEditors.LookUpEdit cbAdministrativeUnit;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem;
        
        
    }
}