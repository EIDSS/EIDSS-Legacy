namespace eidss.avr.ChartForm
{
    partial class LegendSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LegendSettings));
            this.ceLegendVisibility = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ceLegendVisibility.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ceLegendVisibility
            // 
            resources.ApplyResources(this.ceLegendVisibility, "ceLegendVisibility");
            this.ceLegendVisibility.Name = "ceLegendVisibility";
            this.ceLegendVisibility.Properties.Caption = resources.GetString("ceLegendVisibility.Properties.Caption");
            this.ceLegendVisibility.CheckedChanged += new System.EventHandler(this.ceLegendVisibility_CheckedChanged);
            // 
            // LegendSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ceLegendVisibility);
            this.Name = "LegendSettings";
            ((System.ComponentModel.ISupportInitialize)(this.ceLegendVisibility.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit ceLegendVisibility;

    }
}
