namespace eidss.avr.ChartForm
{
    partial class PieChartSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PieChartSettings));
            this.gcSettings = new DevExpress.XtraEditors.GroupControl();
            this.ceShowArguments = new DevExpress.XtraEditors.CheckEdit();
            this.lblShowArguments = new DevExpress.XtraEditors.LabelControl();
            this.lblFormat = new DevExpress.XtraEditors.LabelControl();
            this.cbFormat = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSettings)).BeginInit();
            this.gcSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceShowArguments.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFormat.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcSettings
            // 
            resources.ApplyResources(this.gcSettings, "gcSettings");
            this.gcSettings.Controls.Add(this.ceShowArguments);
            this.gcSettings.Controls.Add(this.lblShowArguments);
            this.gcSettings.Controls.Add(this.lblFormat);
            this.gcSettings.Controls.Add(this.cbFormat);
            this.gcSettings.Name = "gcSettings";
            // 
            // ceShowArguments
            // 
            resources.ApplyResources(this.ceShowArguments, "ceShowArguments");
            this.ceShowArguments.Name = "ceShowArguments";
            this.ceShowArguments.Properties.Caption = resources.GetString("ceShowArguments.Properties.Caption");
            this.ceShowArguments.CheckedChanged += new System.EventHandler(this.ceShowArguments_CheckedChanged);
            // 
            // lblShowArguments
            // 
            resources.ApplyResources(this.lblShowArguments, "lblShowArguments");
            this.lblShowArguments.Name = "lblShowArguments";
            // 
            // lblFormat
            // 
            resources.ApplyResources(this.lblFormat, "lblFormat");
            this.lblFormat.Name = "lblFormat";
            // 
            // cbFormat
            // 
            resources.ApplyResources(this.cbFormat, "cbFormat");
            this.cbFormat.Name = "cbFormat";
            this.cbFormat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbFormat.Properties.Buttons"))))});
            this.cbFormat.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbFormat.SelectedIndexChanged += new System.EventHandler(this.cbFormat_SelectedIndexChanged);
            // 
            // PieChartSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcSettings);
            this.Name = "PieChartSettings";
            this.Controls.SetChildIndex(this.gcSettings, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gcSettings)).EndInit();
            this.gcSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ceShowArguments.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFormat.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gcSettings;
        private DevExpress.XtraEditors.LabelControl lblFormat;
        private DevExpress.XtraEditors.ComboBoxEdit cbFormat;
        private DevExpress.XtraEditors.LabelControl lblShowArguments;
        private DevExpress.XtraEditors.CheckEdit ceShowArguments;
    }
}
