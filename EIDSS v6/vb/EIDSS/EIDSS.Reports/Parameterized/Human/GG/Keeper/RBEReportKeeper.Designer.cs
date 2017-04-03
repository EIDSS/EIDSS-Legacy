namespace EIDSS.Reports.Parameterized.Human.GG.Keeper
{
    partial class RBEReportKeeper
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any m_Resources being used.
        /// </summary>
        /// <param name="disposing">true if managed m_Resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RBEReportKeeper));
            this.RegionFilter = new EIDSS.Reports.BaseControls.Filters.RegionMultiFilter();
            this.RayonFilter = new EIDSS.Reports.BaseControls.Filters.RayonMultiFilter();
            this.ceAddSignature = new DevExpress.XtraEditors.CheckEdit();
            this.QuarterFilter = new EIDSS.Reports.BaseControls.Filters.QuarterMultiFilter();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceAddSignature.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.QuarterFilter);
            this.pnlSettings.Controls.Add(this.ceAddSignature);
            this.pnlSettings.Controls.Add(this.RegionFilter);
            this.pnlSettings.Controls.Add(this.RayonFilter);
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.RayonFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.RegionFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ceAddSignature, 0);
            this.pnlSettings.Controls.SetChildIndex(this.QuarterFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.GenerateReportButton, 0);
            // 
            // ceUseArchiveData
            // 
            resources.ApplyResources(this.ceUseArchiveData, "ceUseArchiveData");
            this.ceUseArchiveData.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("ceUseArchiveData.Properties.Appearance.Font")));
            this.ceUseArchiveData.Properties.Appearance.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceDisabled.Font = ((System.Drawing.Font)(resources.GetObject("ceUseArchiveData.Properties.AppearanceDisabled.Font")));
            this.ceUseArchiveData.Properties.AppearanceDisabled.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceFocused.Font = ((System.Drawing.Font)(resources.GetObject("ceUseArchiveData.Properties.AppearanceFocused.Font")));
            this.ceUseArchiveData.Properties.AppearanceFocused.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceReadOnly.Font = ((System.Drawing.Font)(resources.GetObject("ceUseArchiveData.Properties.AppearanceReadOnly.Font")));
            this.ceUseArchiveData.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.ceUseArchiveData.Properties.Caption = resources.GetString("ceUseArchiveData.Properties.Caption");
            // 
            // GenerateReportButton
            // 
            resources.ApplyResources(this.GenerateReportButton, "GenerateReportButton");
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(RBEReportKeeper), out resources);
            // Form Is Localizable: True
            // 
            // RegionFilter
            // 
            this.RegionFilter.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("RegionFilter.Appearance.Font")));
            this.RegionFilter.Appearance.Options.UseFont = true;
            this.RegionFilter.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            resources.ApplyResources(this.RegionFilter, "RegionFilter");
            this.RegionFilter.Name = "RegionFilter";
            this.RegionFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.MultiFilterEventArgs>(this.RegionFilter_ValueChanged);
            // 
            // RayonFilter
            // 
            this.RayonFilter.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("RayonFilter.Appearance.Font")));
            this.RayonFilter.Appearance.Options.UseFont = true;
            this.RayonFilter.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            resources.ApplyResources(this.RayonFilter, "RayonFilter");
            this.RayonFilter.Name = "RayonFilter";
            this.RayonFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.MultiFilterEventArgs>(this.RayonFilter_ValueChanged);
            // 
            // ceAddSignature
            // 
            resources.ApplyResources(this.ceAddSignature, "ceAddSignature");
            this.ceAddSignature.Name = "ceAddSignature";
            this.ceAddSignature.Properties.Caption = resources.GetString("ceAddSignature.Properties.Caption");
            // 
            // QuarterFilter
            // 
            this.QuarterFilter.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("QuarterFilter.Appearance.Font")));
            this.QuarterFilter.Appearance.Options.UseFont = true;
            this.QuarterFilter.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            resources.ApplyResources(this.QuarterFilter, "QuarterFilter");
            this.QuarterFilter.Name = "QuarterFilter";
            this.QuarterFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.MultiFilterEventArgs>(this.QuarterFilter_ValueChanged);
            // 
            // RBEReportKeeper
            // 
            resources.ApplyResources(this, "$this");
            this.HeaderHeight = 130;
            this.Name = "RBEReportKeeper";
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceAddSignature.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BaseControls.Filters.RegionMultiFilter RegionFilter;
        private BaseControls.Filters.RayonMultiFilter RayonFilter;
        private DevExpress.XtraEditors.CheckEdit ceAddSignature;
        private BaseControls.Filters.QuarterMultiFilter QuarterFilter;

    }
}
