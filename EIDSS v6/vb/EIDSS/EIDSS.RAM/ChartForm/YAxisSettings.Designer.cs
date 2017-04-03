namespace eidss.avr.ChartForm
{
    partial class YAxisSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YAxisSettings));
            this.lblPosition = new DevExpress.XtraEditors.LabelControl();
            this.cbPosition = new DevExpress.XtraEditors.ComboBoxEdit();
            this.generalAxisSettings = new eidss.avr.ChartForm.AxisSettings();
            this.seRangeMin = new DevExpress.XtraEditors.SpinEdit();
            this.lblRangeMin = new DevExpress.XtraEditors.LabelControl();
            this.seRangeMax = new DevExpress.XtraEditors.SpinEdit();
            this.lblRangeMax = new DevExpress.XtraEditors.LabelControl();
            this.cbAutoRange = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPosition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seRangeMin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seRangeMax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAutoRange.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPosition
            // 
            resources.ApplyResources(this.lblPosition, "lblPosition");
            this.lblPosition.Name = "lblPosition";
            // 
            // cbPosition
            // 
            resources.ApplyResources(this.cbPosition, "cbPosition");
            this.cbPosition.Name = "cbPosition";
            this.cbPosition.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbPosition.Properties.Buttons"))))});
            this.cbPosition.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbPosition.SelectedIndexChanged += new System.EventHandler(this.cbPosition_SelectedIndexChanged);
            // 
            // generalAxisSettings
            // 
            this.generalAxisSettings.ChartDetailPanel = null;
            this.generalAxisSettings.CurrentAxis = null;
            resources.ApplyResources(this.generalAxisSettings, "generalAxisSettings");
            this.generalAxisSettings.Index = 0;
            this.generalAxisSettings.Name = "generalAxisSettings";
            this.generalAxisSettings.PropertiesType = null;
            // 
            // seRangeMin
            // 
            resources.ApplyResources(this.seRangeMin, "seRangeMin");
            this.seRangeMin.Name = "seRangeMin";
            this.seRangeMin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("seRangeMin.Properties.Buttons"))))});
            this.seRangeMin.EditValueChanged += new System.EventHandler(this.seRangeMin_EditValueChanged);
            // 
            // lblRangeMin
            // 
            resources.ApplyResources(this.lblRangeMin, "lblRangeMin");
            this.lblRangeMin.Name = "lblRangeMin";
            // 
            // seRangeMax
            // 
            resources.ApplyResources(this.seRangeMax, "seRangeMax");
            this.seRangeMax.Name = "seRangeMax";
            this.seRangeMax.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("seRangeMax.Properties.Buttons"))))});
            this.seRangeMax.EditValueChanged += new System.EventHandler(this.seRangeMax_EditValueChanged);
            // 
            // lblRangeMax
            // 
            resources.ApplyResources(this.lblRangeMax, "lblRangeMax");
            this.lblRangeMax.Name = "lblRangeMax";
            // 
            // cbAutoRange
            // 
            resources.ApplyResources(this.cbAutoRange, "cbAutoRange");
            this.cbAutoRange.Name = "cbAutoRange";
            this.cbAutoRange.Properties.Caption = resources.GetString("cbAutoRange.Properties.Caption");
            this.cbAutoRange.CheckedChanged += new System.EventHandler(this.cbAutoRange_CheckedChanged);
            // 
            // YAxisSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbAutoRange);
            this.Controls.Add(this.seRangeMin);
            this.Controls.Add(this.lblRangeMin);
            this.Controls.Add(this.seRangeMax);
            this.Controls.Add(this.lblRangeMax);
            this.Controls.Add(this.cbPosition);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.generalAxisSettings);
            this.Name = "YAxisSettings";
            ((System.ComponentModel.ISupportInitialize)(this.cbPosition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seRangeMin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seRangeMax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAutoRange.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxisSettings generalAxisSettings;
        private DevExpress.XtraEditors.LabelControl lblPosition;
        private DevExpress.XtraEditors.ComboBoxEdit cbPosition;
        private DevExpress.XtraEditors.SpinEdit seRangeMin;
        private DevExpress.XtraEditors.LabelControl lblRangeMin;
        private DevExpress.XtraEditors.SpinEdit seRangeMax;
        private DevExpress.XtraEditors.LabelControl lblRangeMax;
        private DevExpress.XtraEditors.CheckEdit cbAutoRange;
    }
}
