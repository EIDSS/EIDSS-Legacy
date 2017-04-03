namespace eidss.avr.ChartForm
{
    partial class AreaChartSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AreaChartSettings));
            this.gcSettings = new DevExpress.XtraEditors.GroupControl();
            this.ceColor = new DevExpress.XtraEditors.ColorEdit();
            this.lblColor = new DevExpress.XtraEditors.LabelControl();
            this.lblFillMode = new DevExpress.XtraEditors.LabelControl();
            this.cbFillMode = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSettings)).BeginInit();
            this.gcSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFillMode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcSettings
            // 
            resources.ApplyResources(this.gcSettings, "gcSettings");
            this.gcSettings.Controls.Add(this.ceColor);
            this.gcSettings.Controls.Add(this.lblColor);
            this.gcSettings.Controls.Add(this.lblFillMode);
            this.gcSettings.Controls.Add(this.cbFillMode);
            this.gcSettings.Name = "gcSettings";
            // 
            // ceColor
            // 
            resources.ApplyResources(this.ceColor, "ceColor");
            this.ceColor.Name = "ceColor";
            this.ceColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("ceColor.Properties.Buttons"))))});
            this.ceColor.EditValueChanged += new System.EventHandler(this.ceColor_EditValueChanged);
            // 
            // lblColor
            // 
            resources.ApplyResources(this.lblColor, "lblColor");
            this.lblColor.Name = "lblColor";
            // 
            // lblFillMode
            // 
            resources.ApplyResources(this.lblFillMode, "lblFillMode");
            this.lblFillMode.Name = "lblFillMode";
            // 
            // cbFillMode
            // 
            resources.ApplyResources(this.cbFillMode, "cbFillMode");
            this.cbFillMode.Name = "cbFillMode";
            this.cbFillMode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbFillMode.Properties.Buttons"))))});
            this.cbFillMode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbFillMode.EditValueChanged += new System.EventHandler(this.cbFillMode_EditValueChanged);
            // 
            // AreaChartSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcSettings);
            this.Name = "AreaChartSettings";
            this.Controls.SetChildIndex(this.gcSettings, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gcSettings)).EndInit();
            this.gcSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ceColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFillMode.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gcSettings;
        private DevExpress.XtraEditors.LabelControl lblFillMode;
        private DevExpress.XtraEditors.ComboBoxEdit cbFillMode;
        private DevExpress.XtraEditors.ColorEdit ceColor;
        private DevExpress.XtraEditors.LabelControl lblColor;
    }
}
