using EIDSS.Reports.BaseControls.Filters;
namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    partial class ComparativeAZReportKeeper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComparativeAZReportKeeper));
            this.OrganizationFilter = new EIDSS.Reports.BaseControls.Filters.HumOrganizationFilter();
            ((System.ComponentModel.ISupportInitialize)(this.Year1SpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartMonthLookUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndMonthLookUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Year2SpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CounterLookUp.Properties)).BeginInit();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Year1SpinEdit
            // 
            resources.ApplyResources(this.Year1SpinEdit, "Year1SpinEdit");
            this.Year1SpinEdit.Properties.Mask.EditMask = resources.GetString("Year1SpinEdit.Properties.Mask.EditMask");
            this.Year1SpinEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("Year1SpinEdit.Properties.Mask.MaskType")));
            // 
            // StartMonthLookUp
            // 
            resources.ApplyResources(this.StartMonthLookUp, "StartMonthLookUp");
            // 
            // EndMonthLookUp
            // 
            resources.ApplyResources(this.EndMonthLookUp, "EndMonthLookUp");
            // 
            // EndMonthLabel
            // 
            resources.ApplyResources(this.EndMonthLabel, "EndMonthLabel");
            // 
            // Year2SpinEdit
            // 
            resources.ApplyResources(this.Year2SpinEdit, "Year2SpinEdit");
            this.Year2SpinEdit.Properties.Mask.EditMask = resources.GetString("Year2SpinEdit.Properties.Mask.EditMask");
            this.Year2SpinEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("Year2SpinEdit.Properties.Mask.MaskType")));
            // 
            // region1Filter
            // 
            this.region1Filter.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("region1Filter.Appearance.Font")));
            this.region1Filter.Appearance.Options.UseFont = true;
            this.region1Filter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.SingleFilterEventArgs>(this.RegionRayonFilter_ValueChanged);
            // 
            // rayon1Filter
            // 
            this.rayon1Filter.Appearance.Options.UseFont = true;
            this.rayon1Filter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.SingleFilterEventArgs>(this.RegionRayonFilter_ValueChanged);
            // 
            // region2Filter
            // 
            this.region2Filter.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("region2Filter.Appearance.Font")));
            this.region2Filter.Appearance.Options.UseFont = true;
            this.region2Filter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.SingleFilterEventArgs>(this.RegionRayonFilter_ValueChanged);
            // 
            // rayon2Filter
            // 
            this.rayon2Filter.Appearance.Options.UseFont = true;
            this.rayon2Filter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.SingleFilterEventArgs>(this.RegionRayonFilter_ValueChanged);
            // 
            // CounterLookUp
            // 
            resources.ApplyResources(this.CounterLookUp, "CounterLookUp");
            // 
            // DistrictLabel
            // 
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.OrganizationFilter);
            this.pnlSettings.Controls.SetChildIndex(this.GenerateReportButton, 0);
            this.pnlSettings.Controls.SetChildIndex(this.StartYearLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.EndYearLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.Year1SpinEdit, 0);
            this.pnlSettings.Controls.SetChildIndex(this.EndMonthLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.StartMonthLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.Year2SpinEdit, 0);
            this.pnlSettings.Controls.SetChildIndex(this.StartMonthLookUp, 0);
            this.pnlSettings.Controls.SetChildIndex(this.EndMonthLookUp, 0);
            this.pnlSettings.Controls.SetChildIndex(this.rayon1Filter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.region1Filter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.rayon2Filter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.region2Filter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.CounterLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.CounterLookUp, 0);
            this.pnlSettings.Controls.SetChildIndex(this.OrganizationFilter, 0);
            // 
            // ceUseArchiveData
            // 
            this.ceUseArchiveData.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("ceUseArchiveData.Properties.Appearance.Font")));
            this.ceUseArchiveData.Properties.Appearance.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceDisabled.Font = ((System.Drawing.Font)(resources.GetObject("ceUseArchiveData.Properties.AppearanceDisabled.Font")));
            this.ceUseArchiveData.Properties.AppearanceDisabled.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceFocused.Font = ((System.Drawing.Font)(resources.GetObject("ceUseArchiveData.Properties.AppearanceFocused.Font")));
            this.ceUseArchiveData.Properties.AppearanceFocused.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceReadOnly.Font = ((System.Drawing.Font)(resources.GetObject("ceUseArchiveData.Properties.AppearanceReadOnly.Font")));
            this.ceUseArchiveData.Properties.AppearanceReadOnly.Options.UseFont = true;
            resources.ApplyResources(this.ceUseArchiveData, "ceUseArchiveData");
            // 
            // GenerateReportButton
            // 
            resources.ApplyResources(this.GenerateReportButton, "GenerateReportButton");
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(ComparativeAZReportKeeper), out resources);
            // Form Is Localizable: True
            // 
            // OrganizationFilter
            // 
            this.OrganizationFilter.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.OrganizationFilter, "OrganizationFilter");
            this.OrganizationFilter.Name = "OrganizationFilter";
            this.OrganizationFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.SingleFilterEventArgs>(this.OrganizationFilter_ValueChanged);
            // 
            // ComparativeAZReportKeeper
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "ComparativeAZReportKeeper";
            ((System.ComponentModel.ISupportInitialize)(this.Year1SpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartMonthLookUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndMonthLookUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Year2SpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CounterLookUp.Properties)).EndInit();
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected HumOrganizationFilter OrganizationFilter;
    }
}
