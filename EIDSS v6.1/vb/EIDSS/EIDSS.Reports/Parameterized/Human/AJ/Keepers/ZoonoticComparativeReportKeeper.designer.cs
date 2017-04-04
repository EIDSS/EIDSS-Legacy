using EIDSS.Reports.BaseControls.Filters;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    partial class ZoonoticComparativeReportKeeper
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZoonoticComparativeReportKeeper));
            this.RegionFilter = new EIDSS.Reports.BaseControls.Filters.RegionFilter();
            this.RayonFilter = new EIDSS.Reports.BaseControls.Filters.RayonFilter();
            this.diagnosisFilter = new EIDSS.Reports.BaseControls.Filters.HumZoonoticGroupsDiagnosesMultiFilter();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.diagnosisFilter);
            this.pnlSettings.Controls.Add(this.RegionFilter);
            this.pnlSettings.Controls.Add(this.RayonFilter);
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Controls.SetChildIndex(this.GenerateReportButton, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.RayonFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.RegionFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.diagnosisFilter, 0);
            // 
            // ceUseArchiveData
            // 
            resources.ApplyResources(this.ceUseArchiveData, "ceUseArchiveData");
            this.ceUseArchiveData.Properties.Appearance.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceDisabled.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceFocused.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.ceUseArchiveData.Properties.Caption = resources.GetString("ceUseArchiveData.Properties.Caption");
            // 
            // GenerateReportButton
            // 
            resources.ApplyResources(this.GenerateReportButton, "GenerateReportButton");
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(ZoonoticComparativeReportKeeper), out resources);
            // Form Is Localizable: True
            // 
            // RegionFilter
            // 
            this.RegionFilter.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.RegionFilter, "RegionFilter");
            this.RegionFilter.Name = "RegionFilter";
            this.RegionFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.SingleFilterEventArgs>(this.region1Filter_ValueChanged);
            // 
            // RayonFilter
            // 
            this.RayonFilter.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.RayonFilter, "RayonFilter");
            this.RayonFilter.Name = "RayonFilter";
            this.RayonFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.SingleFilterEventArgs>(this.rayon1Filter_ValueChanged);
            // 
            // diagnosisFilter
            // 
            
            this.diagnosisFilter.Appearance.Options.UseFont = true;
            this.diagnosisFilter.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            resources.ApplyResources(this.diagnosisFilter, "diagnosisFilter");
            this.diagnosisFilter.Name = "diagnosisFilter";
            this.diagnosisFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.MultiFilterEventArgs>(this.Diagnosis_ValueChanged);
            // 
            // ZoonoticComparativeReportKeeper
            // 
            resources.ApplyResources(this, "$this");
            this.HeaderHeight = 130;
            this.Name = "ZoonoticComparativeReportKeeper";
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        

        #endregion

        
        
        protected RegionFilter RegionFilter;
        protected RayonFilter RayonFilter;
        private HumZoonoticGroupsDiagnosesMultiFilter diagnosisFilter;
    }
}