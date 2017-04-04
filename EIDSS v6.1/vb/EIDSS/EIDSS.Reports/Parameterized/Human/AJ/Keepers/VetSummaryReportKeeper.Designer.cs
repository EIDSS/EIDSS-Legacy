using EIDSS.Reports.BaseControls.Filters;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    partial class VetSummaryReportKeeper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VetSummaryReportKeeper));
            this.VetDiagnosisFilter = new EIDSS.Reports.BaseControls.Filters.VetSingleDiagnosisAZFilter();
            this.SurveillanceTypeGroup = new DevExpress.XtraEditors.RadioGroup();
            this.SurveillanceTypeLabel = new DevExpress.XtraEditors.LabelControl();
            this.NameOfInvestigationOrMeasure = new EIDSS.Reports.BaseControls.Filters.NameOfInvestigationOrMeasureAZFilter();
            this.SpeciesTypeFilter = new EIDSS.Reports.BaseControls.Filters.SpeciesTypeAZMultiFilter();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).BeginInit();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SurveillanceTypeGroup.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStart
            // 
            resources.ApplyResources(this.lblStart, "lblStart");
            // 
            // lblEnd
            // 
            resources.ApplyResources(this.lblEnd, "lblEnd");
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
            this.pnlSettings.Controls.Add(this.SpeciesTypeFilter);
            this.pnlSettings.Controls.Add(this.NameOfInvestigationOrMeasure);
            this.pnlSettings.Controls.Add(this.SurveillanceTypeLabel);
            this.pnlSettings.Controls.Add(this.SurveillanceTypeGroup);
            this.pnlSettings.Controls.Add(this.VetDiagnosisFilter);
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Controls.SetChildIndex(this.GenerateReportButton, 0);
            this.pnlSettings.Controls.SetChildIndex(this.lblStart, 0);
            this.pnlSettings.Controls.SetChildIndex(this.lblEnd, 0);
            this.pnlSettings.Controls.SetChildIndex(this.dtStart, 0);
            this.pnlSettings.Controls.SetChildIndex(this.dtEnd, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.VetDiagnosisFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.SurveillanceTypeGroup, 0);
            this.pnlSettings.Controls.SetChildIndex(this.SurveillanceTypeLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.NameOfInvestigationOrMeasure, 0);
            this.pnlSettings.Controls.SetChildIndex(this.SpeciesTypeFilter, 0);
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
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(VetSummaryReportKeeper), out resources);
            // Form Is Localizable: True
            // 
            // VetDiagnosisFilter
            // 
            resources.ApplyResources(this.VetDiagnosisFilter, "VetDiagnosisFilter");
            this.VetDiagnosisFilter.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("VetDiagnosisFilter.Appearance.Font")));
            this.VetDiagnosisFilter.Appearance.Options.UseFont = true;
            this.VetDiagnosisFilter.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.VetDiagnosisFilter.Name = "VetDiagnosisFilter";
            this.VetDiagnosisFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.SingleFilterEventArgs>(this.VetDiagnosisFilter_ValueChanged);
            // 
            // SurveillanceTypeGroup
            // 
            resources.ApplyResources(this.SurveillanceTypeGroup, "SurveillanceTypeGroup");
            this.SurveillanceTypeGroup.Name = "SurveillanceTypeGroup";
            this.SurveillanceTypeGroup.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("SurveillanceTypeGroup.Properties.Appearance.BackColor")));
            this.SurveillanceTypeGroup.Properties.Appearance.Options.UseBackColor = true;
            this.SurveillanceTypeGroup.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((object)(resources.GetObject("SurveillanceTypeGroup.Properties.Items"))), resources.GetString("SurveillanceTypeGroup.Properties.Items1")),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((object)(resources.GetObject("SurveillanceTypeGroup.Properties.Items2"))), resources.GetString("SurveillanceTypeGroup.Properties.Items3")),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((object)(resources.GetObject("SurveillanceTypeGroup.Properties.Items4"))), resources.GetString("SurveillanceTypeGroup.Properties.Items5"))});
            this.SurveillanceTypeGroup.SelectedIndexChanged += new System.EventHandler(this.SurveillanceTypeGroup_SelectedIndexChanged);
            // 
            // SurveillanceTypeLabel
            // 
            resources.ApplyResources(this.SurveillanceTypeLabel, "SurveillanceTypeLabel");
            this.SurveillanceTypeLabel.Name = "SurveillanceTypeLabel";
            // 
            // NameOfInvestigationOrMeasure
            // 
            this.NameOfInvestigationOrMeasure.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.NameOfInvestigationOrMeasure, "NameOfInvestigationOrMeasure");
            this.NameOfInvestigationOrMeasure.Name = "NameOfInvestigationOrMeasure";
            // 
            // SpeciesTypeFilter
            // 
            this.SpeciesTypeFilter.Appearance.Options.UseFont = true;
            this.SpeciesTypeFilter.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            resources.ApplyResources(this.SpeciesTypeFilter, "SpeciesTypeFilter");
            this.SpeciesTypeFilter.Name = "SpeciesTypeFilter";
            this.SpeciesTypeFilter.ValueChanging += new System.EventHandler<DevExpress.XtraEditors.Controls.ChangingEventArgs>(this.SpeciesFilter_ValueChanging);
            this.SpeciesTypeFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.MultiFilterEventArgs>(this.SpeciesFilter_ValueChanged);
            // 
            // VetSummaryReportKeeper
            // 
            this.HeaderHeight = 220;
            this.Name = "VetSummaryReportKeeper";
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).EndInit();
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SurveillanceTypeGroup.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private VetSingleDiagnosisAZFilter VetDiagnosisFilter;
        private DevExpress.XtraEditors.RadioGroup SurveillanceTypeGroup;
        private DevExpress.XtraEditors.LabelControl SurveillanceTypeLabel;
        private NameOfInvestigationOrMeasureAZFilter NameOfInvestigationOrMeasure;
        private SpeciesTypeAZMultiFilter SpeciesTypeFilter;
    }
}
