namespace eidss.avr.ChartForm
{
    partial class BaseSeriesSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseSeriesSettings));
            this.cbCurrentAxis = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lAxis = new DevExpress.XtraEditors.LabelControl();
            this.ceSeriesLabelsVisibility = new DevExpress.XtraEditors.CheckEdit();
            this.leChart = new DevExpress.XtraEditors.LookUpEdit();
            this.labelChartType = new DevExpress.XtraEditors.LabelControl();
            this.bApplyAllSeries = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cbCurrentAxis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceSeriesLabelsVisibility.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leChart.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCurrentAxis
            // 
            resources.ApplyResources(this.cbCurrentAxis, "cbCurrentAxis");
            this.cbCurrentAxis.Name = "cbCurrentAxis";
            this.cbCurrentAxis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbCurrentAxis.Properties.Buttons"))))});
            this.cbCurrentAxis.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbCurrentAxis.SelectedIndexChanged += new System.EventHandler(this.cbCurrentAxis_SelectedIndexChanged);
            // 
            // lAxis
            // 
            resources.ApplyResources(this.lAxis, "lAxis");
            this.lAxis.Name = "lAxis";
            // 
            // ceSeriesLabelsVisibility
            // 
            resources.ApplyResources(this.ceSeriesLabelsVisibility, "ceSeriesLabelsVisibility");
            this.ceSeriesLabelsVisibility.Name = "ceSeriesLabelsVisibility";
            this.ceSeriesLabelsVisibility.Properties.Caption = resources.GetString("ceSeriesLabelsVisibility.Properties.Caption");
            this.ceSeriesLabelsVisibility.CheckedChanged += new System.EventHandler(this.ceSeriesLabelsVisibility_CheckedChanged);
            // 
            // leChart
            // 
            resources.ApplyResources(this.leChart, "leChart");
            this.leChart.Name = "leChart";
            this.leChart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leChart.Properties.Buttons"))))});
            this.leChart.Properties.NullText = resources.GetString("leChart.Properties.NullText");
            this.leChart.EditValueChanged += new System.EventHandler(this.leChart_EditValueChanged);
            // 
            // labelChartType
            // 
            resources.ApplyResources(this.labelChartType, "labelChartType");
            this.labelChartType.Name = "labelChartType";
            // 
            // bApplyAllSeries
            // 
            resources.ApplyResources(this.bApplyAllSeries, "bApplyAllSeries");
            this.bApplyAllSeries.Name = "bApplyAllSeries";
            this.bApplyAllSeries.Click += new System.EventHandler(this.bApplyAllSeries_Click);
            // 
            // BaseSeriesSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bApplyAllSeries);
            this.Controls.Add(this.leChart);
            this.Controls.Add(this.labelChartType);
            this.Controls.Add(this.ceSeriesLabelsVisibility);
            this.Controls.Add(this.lAxis);
            this.Controls.Add(this.cbCurrentAxis);
            this.Name = "BaseSeriesSettings";
            ((System.ComponentModel.ISupportInitialize)(this.cbCurrentAxis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceSeriesLabelsVisibility.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leChart.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lAxis;
        internal DevExpress.XtraEditors.ComboBoxEdit cbCurrentAxis;
        private DevExpress.XtraEditors.CheckEdit ceSeriesLabelsVisibility;
        private DevExpress.XtraEditors.LookUpEdit leChart;
        private DevExpress.XtraEditors.LabelControl labelChartType;
        private DevExpress.XtraEditors.SimpleButton bApplyAllSeries;

    }
}
