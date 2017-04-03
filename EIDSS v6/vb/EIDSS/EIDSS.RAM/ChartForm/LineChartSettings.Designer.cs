namespace eidss.avr.ChartForm
{
    partial class LineChartSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LineChartSettings));
            this.gcSettings = new DevExpress.XtraEditors.GroupControl();
            this.cbShadowVisible = new DevExpress.XtraEditors.CheckEdit();
            this.seLineStyleWidth = new DevExpress.XtraEditors.SpinEdit();
            this.lblLineStyleWidth = new DevExpress.XtraEditors.LabelControl();
            this.ceColor = new DevExpress.XtraEditors.ColorEdit();
            this.lblColor = new DevExpress.XtraEditors.LabelControl();
            this.lblLineStyle = new DevExpress.XtraEditors.LabelControl();
            this.cbLineStyle = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSettings)).BeginInit();
            this.gcSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbShadowVisible.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seLineStyleWidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLineStyle.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcSettings
            // 
            resources.ApplyResources(this.gcSettings, "gcSettings");
            this.gcSettings.Controls.Add(this.cbShadowVisible);
            this.gcSettings.Controls.Add(this.seLineStyleWidth);
            this.gcSettings.Controls.Add(this.lblLineStyleWidth);
            this.gcSettings.Controls.Add(this.ceColor);
            this.gcSettings.Controls.Add(this.lblColor);
            this.gcSettings.Controls.Add(this.lblLineStyle);
            this.gcSettings.Controls.Add(this.cbLineStyle);
            this.gcSettings.Name = "gcSettings";
            // 
            // cbShadowVisible
            // 
            resources.ApplyResources(this.cbShadowVisible, "cbShadowVisible");
            this.cbShadowVisible.Name = "cbShadowVisible";
            this.cbShadowVisible.Properties.Caption = resources.GetString("cbShadowVisible.Properties.Caption");
            this.cbShadowVisible.EditValueChanged += new System.EventHandler(this.cbShadowVisible_EditValueChanged);
            // 
            // seLineStyleWidth
            // 
            resources.ApplyResources(this.seLineStyleWidth, "seLineStyleWidth");
            this.seLineStyleWidth.Name = "seLineStyleWidth";
            this.seLineStyleWidth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("seLineStyleWidth.Properties.Buttons"))))});
            this.seLineStyleWidth.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.seLineStyleWidth.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seLineStyleWidth.EditValueChanged += new System.EventHandler(this.seLineStyleWidth_EditValueChanged);
            // 
            // lblLineStyleWidth
            // 
            resources.ApplyResources(this.lblLineStyleWidth, "lblLineStyleWidth");
            this.lblLineStyleWidth.Name = "lblLineStyleWidth";
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
            // lblLineStyle
            // 
            resources.ApplyResources(this.lblLineStyle, "lblLineStyle");
            this.lblLineStyle.Name = "lblLineStyle";
            // 
            // cbLineStyle
            // 
            resources.ApplyResources(this.cbLineStyle, "cbLineStyle");
            this.cbLineStyle.Name = "cbLineStyle";
            this.cbLineStyle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbLineStyle.Properties.Buttons"))))});
            this.cbLineStyle.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbLineStyle.EditValueChanged += new System.EventHandler(this.cbLineStyle_EditValueChanged);
            // 
            // LineChartSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcSettings);
            this.Name = "LineChartSettings";
            this.Controls.SetChildIndex(this.gcSettings, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gcSettings)).EndInit();
            this.gcSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbShadowVisible.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seLineStyleWidth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLineStyle.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gcSettings;
        private DevExpress.XtraEditors.LabelControl lblLineStyle;
        private DevExpress.XtraEditors.ComboBoxEdit cbLineStyle;
        private DevExpress.XtraEditors.ColorEdit ceColor;
        private DevExpress.XtraEditors.LabelControl lblColor;
        private DevExpress.XtraEditors.SpinEdit seLineStyleWidth;
        private DevExpress.XtraEditors.LabelControl lblLineStyleWidth;
        private DevExpress.XtraEditors.CheckEdit cbShadowVisible;
    }
}
