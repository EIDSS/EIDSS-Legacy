using EIDSS.Reports.BaseControls.Filters;

namespace EIDSS.Reports.Parameterized.Human.GG.Keeper
{
    partial class InfectiousDiseasesMonthKeeper
    {

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfectiousDiseasesMonthKeeper));
            this.rayonFilter = new EIDSS.Reports.BaseControls.Filters.RayonFilter();
            this.ceAddSignature = new DevExpress.XtraEditors.CheckEdit();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceAddSignature.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.ceAddSignature);
            this.pnlSettings.Controls.Add(this.rayonFilter);
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.rayonFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ceAddSignature, 0);
            this.pnlSettings.Controls.SetChildIndex(this.GenerateReportButton, 0);
            // 
            // ceUseArchiveData
            // 
            resources.ApplyResources(this.ceUseArchiveData, "ceUseArchiveData");
            this.ceUseArchiveData.Properties.Appearance.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceDisabled.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceFocused.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceReadOnly.Options.UseFont = true;
            // 
            // GenerateReportButton
            // 
            resources.ApplyResources(this.GenerateReportButton, "GenerateReportButton");
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(InfectiousDiseasesMonthKeeper), out resources);
            // Form Is Localizable: True
            // 
            // rayonFilter
            // 
            this.rayonFilter.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("rayonFilter.Appearance.Font")));
            this.rayonFilter.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.rayonFilter, "rayonFilter");
            this.rayonFilter.Name = "rayonFilter";
            // 
            // ceAddSignature
            // 
            resources.ApplyResources(this.ceAddSignature, "ceAddSignature");
            this.ceAddSignature.Name = "ceAddSignature";
            this.ceAddSignature.Properties.Caption = resources.GetString("ceAddSignature.Properties.Caption");
            // 
            // InfectiousDiseasesMonthKeeper
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "InfectiousDiseasesMonthKeeper";
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceAddSignature.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RayonFilter rayonFilter;
        private DevExpress.XtraEditors.CheckEdit ceAddSignature;

    }
}
