using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.Parameterized.Filters;
using EIDSS.Reports.Parameterized.Veterinary.KZ.Filters;

namespace EIDSS.Reports.Parameterized.Veterinary.KZ.Keepers
{
    partial class VetPrevMeasuresKeeper
    {
        

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VetPrevMeasuresKeeper));
            this.regionFilter1 = new EIDSS.Reports.Parameterized.Filters.RegionFilter();
            this.measureTypeFilter1 = new EIDSS.Reports.Parameterized.Veterinary.KZ.Filters.MeasureTypeFilter();
            this.diagnosisFilter1 = new EIDSS.Reports.Parameterized.Veterinary.KZ.Filters.DiagnosisFilter();
            this.speciesFilter1 = new EIDSS.Reports.Parameterized.Veterinary.KZ.Filters.SpeciesFilter();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.speciesFilter1);
            this.pnlSettings.Controls.Add(this.diagnosisFilter1);
            this.pnlSettings.Controls.Add(this.measureTypeFilter1);
            this.pnlSettings.Controls.Add(this.regionFilter1);
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.regionFilter1, 0);
            this.pnlSettings.Controls.SetChildIndex(this.measureTypeFilter1, 0);
            this.pnlSettings.Controls.SetChildIndex(this.diagnosisFilter1, 0);
            this.pnlSettings.Controls.SetChildIndex(this.speciesFilter1, 0);
            // 
            // ceUseArchiveData
            // 
            resources.ApplyResources(this.ceUseArchiveData, "ceUseArchiveData");
            this.ceUseArchiveData.Properties.Appearance.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceDisabled.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceFocused.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceReadOnly.Options.UseFont = true;
            // 
            // regionFilter1
            // 
            this.regionFilter1.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("regionFilter1.Appearance.Font")));
            this.regionFilter1.Appearance.Options.UseFont = true;
            
            resources.ApplyResources(this.regionFilter1, "regionFilter1");
            this.regionFilter1.Name = "regionFilter1";
            
            this.regionFilter1.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.SingleFilterEventArgs>(this.regionFilter1_ValueChanged);
            // 
            // measureTypeFilter1
            // 
            this.measureTypeFilter1.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("measureTypeFilter1.Appearance.Font")));
            this.measureTypeFilter1.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.measureTypeFilter1, "measureTypeFilter1");
            this.measureTypeFilter1.Matrix = EIDSS.Reports.BaseControls.Filters.MatrixType.Prophylactic;
            this.measureTypeFilter1.Name = "measureTypeFilter1";
            this.measureTypeFilter1.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.MultiFilterEventArgs>(this.measureTypeFilter1_ValueChanged);
            // 
            // diagnosisFilter1
            // 
            this.diagnosisFilter1.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("diagnosisFilter1.Appearance.Font")));
            this.diagnosisFilter1.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.diagnosisFilter1, "diagnosisFilter1");
            this.diagnosisFilter1.Matrix = EIDSS.Reports.BaseControls.Filters.MatrixType.Prophylactic;
            this.diagnosisFilter1.Name = "diagnosisFilter1";
            this.diagnosisFilter1.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.MultiFilterEventArgs>(this.diagnosisFilter1_ValueChanged);
            // 
            // speciesFilter1
            // 
            this.speciesFilter1.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("speciesFilter1.Appearance.Font")));
            this.speciesFilter1.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.speciesFilter1, "speciesFilter1");
            this.speciesFilter1.Matrix = EIDSS.Reports.BaseControls.Filters.MatrixType.Prophylactic;
            this.speciesFilter1.Name = "speciesFilter1";
            this.speciesFilter1.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.MultiFilterEventArgs>(this.speciesFilter1_ValueChanged);
            // 
            // VetPrevMeasuresKeeper
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "VetPrevMeasuresKeeper";
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RegionFilter regionFilter1;
        private MeasureTypeFilter measureTypeFilter1;
        private DiagnosisFilter diagnosisFilter1;
        private SpeciesFilter speciesFilter1;
    }
}