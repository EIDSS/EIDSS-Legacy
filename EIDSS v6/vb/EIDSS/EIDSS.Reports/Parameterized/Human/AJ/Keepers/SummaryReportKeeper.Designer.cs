using EIDSS.Reports.BaseControls.Filters;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    partial class SummaryReportKeeper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SummaryReportKeeper));
            this.HumDiagnosisFilter = new EIDSS.Reports.BaseControls.Filters.HumDiagnosisMultiFilter();
            this.VetDiagnosisFilter = new EIDSS.Reports.BaseControls.Filters.VetDiagnosisMultiFilter();
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
            this.pnlSettings.Controls.Add(this.VetDiagnosisFilter);
            this.pnlSettings.Controls.Add(this.HumDiagnosisFilter);
            this.pnlSettings.Controls.SetChildIndex(this.GenerateReportButton, 0);
            this.pnlSettings.Controls.SetChildIndex(this.lblStart, 0);
            this.pnlSettings.Controls.SetChildIndex(this.lblEnd, 0);
            this.pnlSettings.Controls.SetChildIndex(this.dtStart, 0);
            this.pnlSettings.Controls.SetChildIndex(this.dtEnd, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.HumDiagnosisFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.VetDiagnosisFilter, 0);
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
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(SummaryReportKeeper), out resources);
            // Form Is Localizable: True
            // 
            // HumDiagnosisFilter
            // 
            this.HumDiagnosisFilter.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("HumDiagnosisFilter.Appearance.Font")));
            this.HumDiagnosisFilter.Appearance.Options.UseFont = true;
            this.HumDiagnosisFilter.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            resources.ApplyResources(this.HumDiagnosisFilter, "HumDiagnosisFilter");
            this.HumDiagnosisFilter.Name = "HumDiagnosisFilter";
            this.HumDiagnosisFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.MultiFilterEventArgs>(this.DiagnosisFilter_ValueChanged);
            // 
            // VetDiagnosisFilter
            // 
            this.VetDiagnosisFilter.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("VetDiagnosisFilter.Appearance.Font")));
            this.VetDiagnosisFilter.Appearance.Options.UseFont = true;
            this.VetDiagnosisFilter.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            resources.ApplyResources(this.VetDiagnosisFilter, "VetDiagnosisFilter");
            this.VetDiagnosisFilter.Name = "VetDiagnosisFilter";
            this.VetDiagnosisFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.MultiFilterEventArgs>(this.DiagnosisFilter_ValueChanged);
            // 
            // SummaryReportKeeper
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "SummaryReportKeeper";
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

        private HumDiagnosisMultiFilter HumDiagnosisFilter;
        private VetDiagnosisMultiFilter VetDiagnosisFilter;
    }
}
