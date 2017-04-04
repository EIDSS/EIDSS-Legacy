using EIDSS.Reports.BaseControls.Filters;

namespace EIDSS.Reports.Parameterized.Human.TH.Keepers
{
    partial class NumberOfCasesDeathsMonthTHReportKeeper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NumberOfCasesDeathsMonthTHReportKeeper));
            this.DiagnosesFilter = new EIDSS.Reports.BaseControls.Filters.HumDiagnosisMultiFilter();
            this.RegionFilter = new EIDSS.Reports.BaseControls.Filters.ThaiRegionMultiFilter();
            this.ThaiZonesFilter = new EIDSS.Reports.BaseControls.Filters.ThaiZonesMultiFilter();
            this.CaseClassificationFilter = new EIDSS.Reports.BaseControls.Filters.ThaiCaseClassificationFilter();
            this.ProvinceFilter = new EIDSS.Reports.BaseControls.Filters.ThaiProvinceMultiFilter();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.ProvinceFilter);
            this.pnlSettings.Controls.Add(this.CaseClassificationFilter);
            this.pnlSettings.Controls.Add(this.ThaiZonesFilter);
            this.pnlSettings.Controls.Add(this.RegionFilter);
            this.pnlSettings.Controls.Add(this.DiagnosesFilter);
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Controls.SetChildIndex(this.GenerateReportButton, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.DiagnosesFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.RegionFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ThaiZonesFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.CaseClassificationFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ProvinceFilter, 0);
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
            // 
            // GenerateReportButton
            // 
            resources.ApplyResources(this.GenerateReportButton, "GenerateReportButton");
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(NumberOfCasesDeathsMonthTHReportKeeper), out resources);
            // Form Is Localizable: True
            // 
            // DiagnosesFilter
            // 
            this.DiagnosesFilter.Appearance.Options.UseFont = true;
            this.DiagnosesFilter.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            resources.ApplyResources(this.DiagnosesFilter, "DiagnosesFilter");
            this.DiagnosesFilter.Name = "DiagnosesFilter";
            this.DiagnosesFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.MultiFilterEventArgs>(this.DiagnosisFilter_ValueChanged);
            // 
            // RegionFilter
            // 
            this.RegionFilter.Appearance.Options.UseFont = true;
            this.RegionFilter.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            resources.ApplyResources(this.RegionFilter, "RegionFilter");
            this.RegionFilter.Name = "RegionFilter";
            this.RegionFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.MultiFilterEventArgs>(this.RegionFilter_ValueChanged);
            // 
            // ThaiZonesFilter
            // 
            this.ThaiZonesFilter.Appearance.Options.UseFont = true;
            this.ThaiZonesFilter.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            resources.ApplyResources(this.ThaiZonesFilter, "ThaiZonesFilter");
            this.ThaiZonesFilter.Name = "ThaiZonesFilter";
            this.ThaiZonesFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.MultiFilterEventArgs>(this.ZonesFilter_ValueChanged);
            // 
            // CaseClassificationFilter
            // 
            this.CaseClassificationFilter.Appearance.Options.UseFont = true;
            this.CaseClassificationFilter.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            resources.ApplyResources(this.CaseClassificationFilter, "CaseClassificationFilter");
            this.CaseClassificationFilter.Name = "CaseClassificationFilter";
            // 
            // ProvinceFilter
            // 
            this.ProvinceFilter.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("ProvinceFilter.Appearance.Font")));
            this.ProvinceFilter.Appearance.Options.UseFont = true;
            this.ProvinceFilter.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            resources.ApplyResources(this.ProvinceFilter, "ProvinceFilter");
            this.ProvinceFilter.Name = "ProvinceFilter";
            this.ProvinceFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.MultiFilterEventArgs>(this.ProvinceFilter_ValueChanged);
            // 
            // NumberOfCasesDeathsMonthTHReportKeeper
            // 
            resources.ApplyResources(this, "$this");
            this.HeaderHeight = 170;
            this.Name = "NumberOfCasesDeathsMonthTHReportKeeper";
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private HumDiagnosisMultiFilter DiagnosesFilter;
        private ThaiZonesMultiFilter ThaiZonesFilter;
        private ThaiRegionMultiFilter RegionFilter;
        private ThaiCaseClassificationFilter CaseClassificationFilter;
        private ThaiProvinceMultiFilter ProvinceFilter;
    }
}
