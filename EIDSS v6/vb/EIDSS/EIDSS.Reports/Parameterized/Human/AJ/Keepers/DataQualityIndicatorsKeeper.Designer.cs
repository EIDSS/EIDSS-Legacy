using EIDSS.Reports.BaseControls.Filters;
namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    partial class DataQualityIndicatorsKeeper
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataQualityIndicatorsKeeper));
            this.diagnosisFilter1 = new EIDSS.Reports.BaseControls.Filters.HumStandardDiagnosisAzSortMultiFilter();
            this.regionFilter = new EIDSS.Reports.BaseControls.Filters.RegionFilter();
            this.rayonFilter = new EIDSS.Reports.BaseControls.Filters.RayonFilter();
            this.ceArrangeRayons = new DevExpress.XtraEditors.CheckEdit();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceArrangeRayons.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.ceArrangeRayons);
            this.pnlSettings.Controls.Add(this.regionFilter);
            this.pnlSettings.Controls.Add(this.rayonFilter);
            this.pnlSettings.Controls.Add(this.diagnosisFilter1);
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Controls.SetChildIndex(this.GenerateReportButton, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.diagnosisFilter1, 0);
            this.pnlSettings.Controls.SetChildIndex(this.rayonFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.regionFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ceArrangeRayons, 0);
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
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(DataQualityIndicatorsKeeper), out resources);
            // Form Is Localizable: True
            // 
            // diagnosisFilter1
            // 
            this.diagnosisFilter1.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("diagnosisFilter1.Appearance.Font")));
            this.diagnosisFilter1.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.diagnosisFilter1, "diagnosisFilter1");
            this.diagnosisFilter1.Name = "diagnosisFilter1";
            this.diagnosisFilter1.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.MultiFilterEventArgs>(this.diagnosisFilter1_ValueChanged);
            // 
            // regionFilter
            // 
            this.regionFilter.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("regionFilter.Appearance.Font")));
            this.regionFilter.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.regionFilter, "regionFilter");
            this.regionFilter.Name = "regionFilter";
            this.regionFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.SingleFilterEventArgs>(this.regionFilter_ValueChanged);
            // 
            // rayonFilter
            // 
            this.rayonFilter.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.rayonFilter, "rayonFilter");
            this.rayonFilter.Name = "rayonFilter";
            this.rayonFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.SingleFilterEventArgs>(this.rayonFilter_ValueChanged);
            // 
            // ceArrangeRayons
            // 
            resources.ApplyResources(this.ceArrangeRayons, "ceArrangeRayons");
            this.ceArrangeRayons.Name = "ceArrangeRayons";
            this.ceArrangeRayons.Properties.Appearance.Options.UseFont = true;
            this.ceArrangeRayons.Properties.AppearanceDisabled.Options.UseFont = true;
            this.ceArrangeRayons.Properties.AppearanceFocused.Options.UseFont = true;
            this.ceArrangeRayons.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.ceArrangeRayons.Properties.Caption = resources.GetString("ceArrangeRayons.Properties.Caption");
            this.ceArrangeRayons.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.ceArrangeRayons.Tag = "{alwayseditable}";
            // 
            // DataQualityIndicatorsKeeper
            // 
            resources.ApplyResources(this, "$this");
            this.HeaderHeight = 160;
            this.IsMonthRange = true;
            this.Name = "DataQualityIndicatorsKeeper";
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceArrangeRayons.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private HumStandardDiagnosisAzSortMultiFilter diagnosisFilter1;
        private RegionFilter regionFilter;
        private RayonFilter rayonFilter;
        protected DevExpress.XtraEditors.CheckEdit ceArrangeRayons;

    
    }
}
