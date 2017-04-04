namespace EIDSS.Reports.BaseControls.Filters
{
    partial class CounterMultiFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CounterMultiFilter));
            this.SuspendLayout();
            // 
            // lblcheckedComboBoxName
            // 
            resources.ApplyResources(this.lblcheckedComboBoxName, "lblcheckedComboBoxName");
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(CounterMultiFilter), out resources);
            // Form Is Localizable: True
            // 
            // CounterMultiFilter
            // 
            resources.ApplyResources(this, "$this");
            this.Appearance.FontSizeDelta = ((int)(resources.GetObject("CounterMultiFilter.Appearance.FontSizeDelta")));
            this.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("CounterMultiFilter.Appearance.FontStyleDelta")));
            this.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("CounterMultiFilter.Appearance.GradientMode")));
            this.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("CounterMultiFilter.Appearance.Image")));
            this.Appearance.Options.UseFont = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.Name = "CounterMultiFilter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
