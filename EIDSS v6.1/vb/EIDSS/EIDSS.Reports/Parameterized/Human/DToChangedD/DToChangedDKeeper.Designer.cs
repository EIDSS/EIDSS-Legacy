using EIDSS.Reports.BaseControls.Filters;

namespace EIDSS.Reports.Parameterized.Human.DToChangedD
{
    partial class DToChangedDKeeper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DToChangedDKeeper));
            this.settlementFilter = new EIDSS.Reports.BaseControls.Filters.SettlementFilter();
            this.regionFilter = new EIDSS.Reports.BaseControls.Filters.RegionFilter();
            this.rayonFilter = new EIDSS.Reports.BaseControls.Filters.RayonFilter();
            this.ConcordanceSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.ConcordanceLabel = new System.Windows.Forms.Label();
            this.InitialDiagnosisLabel = new System.Windows.Forms.Label();
            this.initialDiagnosisFilter = new EIDSS.Reports.BaseControls.Filters.HumStandardDiagnosisMultiFilter();
            this.finalDiagnosisFilter = new EIDSS.Reports.BaseControls.Filters.HumStandardDiagnosisMultiFilter();
            this.FinalDiagnosisLabel = new System.Windows.Forms.Label();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConcordanceSpinEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.FinalDiagnosisLabel);
            this.pnlSettings.Controls.Add(this.InitialDiagnosisLabel);
            this.pnlSettings.Controls.Add(this.finalDiagnosisFilter);
            this.pnlSettings.Controls.Add(this.initialDiagnosisFilter);
            this.pnlSettings.Controls.Add(this.ConcordanceSpinEdit);
            this.pnlSettings.Controls.Add(this.ConcordanceLabel);
            this.pnlSettings.Controls.Add(this.settlementFilter);
            this.pnlSettings.Controls.Add(this.regionFilter);
            this.pnlSettings.Controls.Add(this.rayonFilter);
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.rayonFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.regionFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.settlementFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ConcordanceLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ConcordanceSpinEdit, 0);
            this.pnlSettings.Controls.SetChildIndex(this.initialDiagnosisFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.finalDiagnosisFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.GenerateReportButton, 0);
            this.pnlSettings.Controls.SetChildIndex(this.InitialDiagnosisLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.FinalDiagnosisLabel, 0);
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
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(DToChangedDKeeper), out resources);
            // Form Is Localizable: True
            // 
            // settlementFilter
            // 
            resources.ApplyResources(this.settlementFilter, "settlementFilter");
            this.settlementFilter.Name = "settlementFilter";
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
            // ConcordanceSpinEdit
            // 
            resources.ApplyResources(this.ConcordanceSpinEdit, "ConcordanceSpinEdit");
            this.ConcordanceSpinEdit.Name = "ConcordanceSpinEdit";
            this.ConcordanceSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("ConcordanceSpinEdit.Properties.Buttons"))))});
            this.ConcordanceSpinEdit.Properties.IsFloatValue = false;
            this.ConcordanceSpinEdit.Properties.Mask.EditMask = resources.GetString("ConcordanceSpinEdit.Properties.Mask.EditMask");
            this.ConcordanceSpinEdit.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // ConcordanceLabel
            // 
            resources.ApplyResources(this.ConcordanceLabel, "ConcordanceLabel");
            this.ConcordanceLabel.Name = "ConcordanceLabel";
            // 
            // InitialDiagnosisLabel
            // 
            resources.ApplyResources(this.InitialDiagnosisLabel, "InitialDiagnosisLabel");
            this.InitialDiagnosisLabel.Name = "InitialDiagnosisLabel";
            // 
            // initialDiagnosisFilter
            // 
            this.initialDiagnosisFilter.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("initialDiagnosisFilter.Appearance.Font")));
            this.initialDiagnosisFilter.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.initialDiagnosisFilter, "initialDiagnosisFilter");
            this.initialDiagnosisFilter.Name = "initialDiagnosisFilter";
            this.initialDiagnosisFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.MultiFilterEventArgs>(this.initialDiagnosisFilter_ValueChanged);
            // 
            // finalDiagnosisFilter
            // 
            this.finalDiagnosisFilter.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("finalDiagnosisFilter.Appearance.Font")));
            this.finalDiagnosisFilter.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.finalDiagnosisFilter, "finalDiagnosisFilter");
            this.finalDiagnosisFilter.Name = "finalDiagnosisFilter";
            this.finalDiagnosisFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.MultiFilterEventArgs>(this.finalDiagnosisFilter_ValueChanged);
            // 
            // FinalDiagnosisLabel
            // 
            resources.ApplyResources(this.FinalDiagnosisLabel, "FinalDiagnosisLabel");
            this.FinalDiagnosisLabel.Name = "FinalDiagnosisLabel";
            // 
            // DToChangedDKeeper
            // 
            this.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("DToChangedDKeeper.Appearance.Font")));
            this.Appearance.Options.UseFont = true;
            resources.ApplyResources(this, "$this");
            this.HeaderHeight = 220;
            this.Name = "DToChangedDKeeper";
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConcordanceSpinEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected BaseControls.Filters.SettlementFilter settlementFilter;
        protected BaseControls.Filters.RegionFilter regionFilter;
        protected BaseControls.Filters.RayonFilter rayonFilter;
        private DevExpress.XtraEditors.SpinEdit ConcordanceSpinEdit;
        private System.Windows.Forms.Label ConcordanceLabel;
        private System.Windows.Forms.Label InitialDiagnosisLabel;
        private HumStandardDiagnosisMultiFilter initialDiagnosisFilter;
        private HumStandardDiagnosisMultiFilter finalDiagnosisFilter;
        private System.Windows.Forms.Label FinalDiagnosisLabel;
    }
}
