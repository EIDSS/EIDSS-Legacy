using EIDSS.Reports.BaseControls.Filters;
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
            this.regionFilter1 = new EIDSS.Reports.BaseControls.Filters.RegionFilter();
            this.measureTypeFilter1 = new EIDSS.Reports.Parameterized.Veterinary.KZ.Filters.MeasureTypeFilter();
            this.DiagnosisMatrixFilter1 = new EIDSS.Reports.Parameterized.Veterinary.KZ.Filters.DiagnosisMatrixFilter();
            this.speciesFilter1 = new EIDSS.Reports.Parameterized.Veterinary.KZ.Filters.SpeciesFilter();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).BeginInit();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dtStart
            // 
            resources.ApplyResources(this.dtStart, "dtStart");
            // 
            // dtEnd
            // 
            resources.ApplyResources(this.dtEnd, "dtEnd");
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.speciesFilter1);
            this.pnlSettings.Controls.Add(this.DiagnosisMatrixFilter1);
            this.pnlSettings.Controls.Add(this.measureTypeFilter1);
            this.pnlSettings.Controls.Add(this.regionFilter1);
            this.pnlSettings.Controls.SetChildIndex(this.GenerateReportButton, 0);
            this.pnlSettings.Controls.SetChildIndex(this.lblStart, 0);
            this.pnlSettings.Controls.SetChildIndex(this.lblEnd, 0);
            this.pnlSettings.Controls.SetChildIndex(this.dtStart, 0);
            this.pnlSettings.Controls.SetChildIndex(this.dtEnd, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.regionFilter1, 0);
            this.pnlSettings.Controls.SetChildIndex(this.measureTypeFilter1, 0);
            this.pnlSettings.Controls.SetChildIndex(this.DiagnosisMatrixFilter1, 0);
            this.pnlSettings.Controls.SetChildIndex(this.speciesFilter1, 0);
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
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(VetPrevMeasuresKeeper), out resources);
            // Form Is Localizable: True
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
            // DiagnosisMatrixFilter1
            // 
            this.DiagnosisMatrixFilter1.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("DiagnosisMatrixFilter1.Appearance.Font")));
            this.DiagnosisMatrixFilter1.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.DiagnosisMatrixFilter1, "DiagnosisMatrixFilter1");
            this.DiagnosisMatrixFilter1.Matrix = EIDSS.Reports.BaseControls.Filters.MatrixType.Prophylactic;
            this.DiagnosisMatrixFilter1.Name = "DiagnosisMatrixFilter1";
            this.DiagnosisMatrixFilter1.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.MultiFilterEventArgs>(this.DiagnosisMatrixFilter1_ValueChanged);
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
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).EndInit();
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RegionFilter regionFilter1;
        private MeasureTypeFilter measureTypeFilter1;
        private DiagnosisMatrixFilter DiagnosisMatrixFilter1;
        private SpeciesFilter speciesFilter1;
    }
}