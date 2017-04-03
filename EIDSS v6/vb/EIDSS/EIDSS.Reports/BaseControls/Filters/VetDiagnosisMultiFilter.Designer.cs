namespace EIDSS.Reports.BaseControls.Filters
{
    partial class VetDiagnosisMultiFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VetDiagnosisMultiFilter));
            this.SuspendLayout();
            // 
            // lblcheckedComboBoxName
            // 
            resources.ApplyResources(this.lblcheckedComboBoxName, "lblcheckedComboBoxName");
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(VetDiagnosisMultiFilter), out resources);
            // Form Is Localizable: True
            // 
            // VetDiagnosisMultiFilter
            // 
            this.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("VetDiagnosisMultiFilter.Appearance.Font")));
            this.Appearance.Options.UseFont = true;
            resources.ApplyResources(this, "$this");
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.Name = "VetDiagnosisMultiFilter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
