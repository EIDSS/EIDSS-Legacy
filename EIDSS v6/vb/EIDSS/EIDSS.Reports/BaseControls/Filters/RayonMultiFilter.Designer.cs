namespace EIDSS.Reports.BaseControls.Filters
{
    partial class RayonMultiFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RayonMultiFilter));
            this.SuspendLayout();
            // 
            // lblcheckedComboBoxName
            // 
            resources.ApplyResources(this.lblcheckedComboBoxName, "lblcheckedComboBoxName");
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(RayonMultiFilter), out resources);
            // Form Is Localizable: True
            // 
            // RayonMultiFilter
            // 
            resources.ApplyResources(this, "$this");
            this.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("RayonMultiFilter.Appearance.Font")));
            this.Appearance.FontSizeDelta = ((int)(resources.GetObject("RayonMultiFilter.Appearance.FontSizeDelta")));
            this.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("RayonMultiFilter.Appearance.FontStyleDelta")));
            this.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("RayonMultiFilter.Appearance.GradientMode")));
            this.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("RayonMultiFilter.Appearance.Image")));
            this.Appearance.Options.UseFont = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.Name = "RayonMultiFilter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
