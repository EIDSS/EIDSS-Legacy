namespace eidss.avr.ChartForm
{
    partial class PointChartSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PointChartSettings));
            this.gcSettings = new DevExpress.XtraEditors.GroupControl();
            this.ceColor = new DevExpress.XtraEditors.ColorEdit();
            this.lblColor = new DevExpress.XtraEditors.LabelControl();
            this.lblPointMarker = new DevExpress.XtraEditors.LabelControl();
            this.cbPointMarker = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSettings)).BeginInit();
            this.gcSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPointMarker.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcSettings
            // 
            resources.ApplyResources(this.gcSettings, "gcSettings");
            this.gcSettings.Controls.Add(this.ceColor);
            this.gcSettings.Controls.Add(this.lblColor);
            this.gcSettings.Controls.Add(this.lblPointMarker);
            this.gcSettings.Controls.Add(this.cbPointMarker);
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
            // lblPointMarker
            // 
            resources.ApplyResources(this.lblPointMarker, "lblPointMarker");
            this.lblPointMarker.Name = "lblPointMarker";
            // 
            // cbPointMarker
            // 
            resources.ApplyResources(this.cbPointMarker, "cbPointMarker");
            this.cbPointMarker.Name = "cbPointMarker";
            this.cbPointMarker.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbPointMarker.Properties.Buttons"))))});
            this.cbPointMarker.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbPointMarker.EditValueChanged += new System.EventHandler(this.cbPointMarker_EditValueChanged);
            // 
            // PointChartSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcSettings);
            this.Name = "PointChartSettings";
            this.Controls.SetChildIndex(this.gcSettings, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gcSettings)).EndInit();
            this.gcSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ceColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPointMarker.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gcSettings;
        private DevExpress.XtraEditors.LabelControl lblPointMarker;
        private DevExpress.XtraEditors.ComboBoxEdit cbPointMarker;
        private DevExpress.XtraEditors.ColorEdit ceColor;
        private DevExpress.XtraEditors.LabelControl lblColor;
    }
}
