namespace EIDSS.Reports.BaseControls.Filters
{
    partial class QuarterMultiFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuarterMultiFilter));
            this.SuspendLayout();
            // 
            // lblcheckedComboBoxName
            // 
            resources.ApplyResources(this.lblcheckedComboBoxName, "lblcheckedComboBoxName");
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(QuarterMultiFilter), out resources);
            // Form Is Localizable: True
            // 
            // QuarterMultiFilter
            // 
            resources.ApplyResources(this, "$this");
            this.Appearance.FontSizeDelta = ((int)(resources.GetObject("QuarterMultiFilter.Appearance.FontSizeDelta")));
            this.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("QuarterMultiFilter.Appearance.FontStyleDelta")));
            this.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("QuarterMultiFilter.Appearance.GradientMode")));
            this.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("QuarterMultiFilter.Appearance.Image")));
            this.Appearance.Options.UseFont = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.Name = "QuarterMultiFilter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
