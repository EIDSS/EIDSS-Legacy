namespace EIDSS.Reports.Parameterized.Human.AJ.Filters
{
    partial class VetOrganizationFilter
    {
       

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VetOrganizationFilter));
            this.lblLabName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblLookupName
            // 
            resources.ApplyResources(this.lblLookupName, "lblLookupName");
            // 
            // lblLabName
            // 
            resources.ApplyResources(this.lblLabName, "lblLabName");
            this.lblLabName.Name = "lblLabName";
            // 
            // VetOrganizationFilter
            // 
            resources.ApplyResources(this, "$this");
            this.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("VetOrganizationFilter.Appearance.Font")));
            this.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("VetOrganizationFilter.Appearance.GradientMode")));
            this.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("VetOrganizationFilter.Appearance.Image")));
            this.Appearance.Options.UseFont = true;
            this.Controls.Add(this.lblLabName);
            this.Name = "VetOrganizationFilter";
            this.Controls.SetChildIndex(this.lblLookupName, 0);
            this.Controls.SetChildIndex(this.lblLabName, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLabName;

    }
}