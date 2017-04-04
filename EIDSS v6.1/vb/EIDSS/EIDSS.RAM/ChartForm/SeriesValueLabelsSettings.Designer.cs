namespace eidss.avr.ChartForm
{
    partial class SeriesValueLabelsSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeriesValueLabelsSettings));
            this.ceSeriesValueLabelsVisible = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ceSeriesValueLabelsVisible.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ceSeriesValueLabelsVisible
            // 
            resources.ApplyResources(this.ceSeriesValueLabelsVisible, "ceSeriesValueLabelsVisible");
            this.ceSeriesValueLabelsVisible.Name = "ceSeriesValueLabelsVisible";
            this.ceSeriesValueLabelsVisible.Properties.Caption = resources.GetString("ceSeriesValueLabelsVisible.Properties.Caption");
            this.ceSeriesValueLabelsVisible.CheckedChanged += new System.EventHandler(this.ceSeriesValueLabelsVisible_CheckedChanged);
            // 
            // SeriesValueLabelsSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ceSeriesValueLabelsVisible);
            this.Name = "SeriesValueLabelsSettings";
            ((System.ComponentModel.ISupportInitialize)(this.ceSeriesValueLabelsVisible.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit ceSeriesValueLabelsVisible;
    }
}
