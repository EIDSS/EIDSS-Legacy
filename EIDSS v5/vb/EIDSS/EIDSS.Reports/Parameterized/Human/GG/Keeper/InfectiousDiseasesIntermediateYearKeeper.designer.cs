using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.Parameterized.Filters;

namespace EIDSS.Reports.Parameterized.Human.GG.Keeper
{
    partial class InfectiousDiseasesIntermediateYearKeeper
    {

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfectiousDiseasesIntermediateYearKeeper));
            this.regionFilter = new EIDSS.Reports.Parameterized.Filters.RegionFilter();
            this.rayonFilter = new EIDSS.Reports.Parameterized.Filters.RayonFilter();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.regionFilter);
            this.pnlSettings.Controls.Add(this.rayonFilter);
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.rayonFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.regionFilter, 0);
            // 
            // ceUseArchiveData
            // 
            this.ceUseArchiveData.Properties.Appearance.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceDisabled.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceFocused.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceReadOnly.Options.UseFont = true;
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
            this.rayonFilter.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("rayonFilter.Appearance.Font")));
            this.rayonFilter.Appearance.Options.UseFont = true;
            
            resources.ApplyResources(this.rayonFilter, "rayonFilter");
            this.rayonFilter.Name = "rayonFilter";
            
            this.rayonFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.SingleFilterEventArgs>(this.rayonFilter_ValueChanged);
            // 
            // InfectiousDiseasesIntermediateYearKeeper
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "InfectiousDiseasesIntermediateYearKeeper";
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RegionFilter regionFilter;
        private RayonFilter rayonFilter;

    }
}
