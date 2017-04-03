using EIDSS.Reports.Parameterized.Filters;
using EIDSS.Reports.Parameterized.Veterinary.KZ.Filters;

namespace EIDSS.Reports.Parameterized.Veterinary.KZ.Keepers
{
    partial class VetProphMeasuresKeeper
    {
       

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VetProphMeasuresKeeper));
            this.regionFilter1 = new EIDSS.Reports.Parameterized.Filters.RegionFilter();
            this.measureTypeFilter1 = new EIDSS.Reports.Parameterized.Veterinary.KZ.Filters.MeasureTypeFilter();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.measureTypeFilter1);
            this.pnlSettings.Controls.Add(this.regionFilter1);
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.regionFilter1, 0);
            this.pnlSettings.Controls.SetChildIndex(this.measureTypeFilter1, 0);
            // 
            // ceUseArchiveData
            // 
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
            this.regionFilter1.RegionId = ((long)(-1));
            this.regionFilter1.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.SingleFilterEventArgs>(this.regionFilter1_ValueChanged);
            // 
            // measureTypeFilter1
            // 
            this.measureTypeFilter1.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("measureTypeFilter1.Appearance.Font")));
            this.measureTypeFilter1.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.measureTypeFilter1, "measureTypeFilter1");
            this.measureTypeFilter1.Matrix = EIDSS.Reports.BaseControls.Filters.MatrixType.Sanitary;
            this.measureTypeFilter1.Name = "measureTypeFilter1";
            this.measureTypeFilter1.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.MultiFilterEventArgs>(this.measureTypeFilter1_ValueChanged);
            // 
            // VetProphMeasuresKeeper
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "VetProphMeasuresKeeper";
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RegionFilter regionFilter1;
        private MeasureTypeFilter measureTypeFilter1;
    }
}