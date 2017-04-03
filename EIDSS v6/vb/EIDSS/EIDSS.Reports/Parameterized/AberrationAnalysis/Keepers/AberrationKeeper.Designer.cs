using DevExpress.XtraEditors;
using EIDSS.Reports.BaseControls.Filters;
namespace EIDSS.Reports.Parameterized.AberrationAnalysis.Keepers
{
    partial class AberrationKeeper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AberrationKeeper));
            this.lblAberrationParameters = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TimeUnitsLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TimeUnitsLookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.LagUnits = new System.Windows.Forms.Label();
            this.BaselineUnits = new System.Windows.Forms.Label();
            this.threshold = new DevExpress.XtraEditors.SpinEdit();
            this.baseline = new DevExpress.XtraEditors.SpinEdit();
            this.lag = new DevExpress.XtraEditors.SpinEdit();
            this.DateFieldsLookUp = new EIDSS.Reports.BaseControls.Filters.SourceDateMultiFilter();
            this.AnalysisMethodLabel = new System.Windows.Forms.Label();
            this.AnalysisMethodLookUp = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).BeginInit();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeUnitsLookUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threshold.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseline.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnalysisMethodLookUp.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // regionFilter
            // 
            this.regionFilter.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("regionFilter.Appearance.Font")));
            this.regionFilter.Appearance.Options.UseFont = true;
            // 
            // rayonFilter
            // 
            this.rayonFilter.Appearance.Options.UseFont = true;
            // 
            // settlementFilter
            // 
            resources.ApplyResources(this.settlementFilter, "settlementFilter");
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
            this.pnlSettings.Controls.Add(this.DateFieldsLookUp);
            this.pnlSettings.Controls.Add(this.lag);
            this.pnlSettings.Controls.Add(this.baseline);
            this.pnlSettings.Controls.Add(this.threshold);
            this.pnlSettings.Controls.Add(this.BaselineUnits);
            this.pnlSettings.Controls.Add(this.LagUnits);
            this.pnlSettings.Controls.Add(this.AnalysisMethodLookUp);
            this.pnlSettings.Controls.Add(this.TimeUnitsLookUp);
            this.pnlSettings.Controls.Add(this.label5);
            this.pnlSettings.Controls.Add(this.AnalysisMethodLabel);
            this.pnlSettings.Controls.Add(this.label4);
            this.pnlSettings.Controls.Add(this.TimeUnitsLabel);
            this.pnlSettings.Controls.Add(this.label2);
            this.pnlSettings.Controls.Add(this.label1);
            this.pnlSettings.Controls.Add(this.lblAberrationParameters);
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Controls.SetChildIndex(this.GenerateReportButton, 0);
            this.pnlSettings.Controls.SetChildIndex(this.lblStart, 0);
            this.pnlSettings.Controls.SetChildIndex(this.lblEnd, 0);
            this.pnlSettings.Controls.SetChildIndex(this.dtStart, 0);
            this.pnlSettings.Controls.SetChildIndex(this.dtEnd, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.rayonFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.regionFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.settlementFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.lblAberrationParameters, 0);
            this.pnlSettings.Controls.SetChildIndex(this.label1, 0);
            this.pnlSettings.Controls.SetChildIndex(this.label2, 0);
            this.pnlSettings.Controls.SetChildIndex(this.TimeUnitsLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.label4, 0);
            this.pnlSettings.Controls.SetChildIndex(this.AnalysisMethodLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.label5, 0);
            this.pnlSettings.Controls.SetChildIndex(this.TimeUnitsLookUp, 0);
            this.pnlSettings.Controls.SetChildIndex(this.AnalysisMethodLookUp, 0);
            this.pnlSettings.Controls.SetChildIndex(this.LagUnits, 0);
            this.pnlSettings.Controls.SetChildIndex(this.BaselineUnits, 0);
            this.pnlSettings.Controls.SetChildIndex(this.threshold, 0);
            this.pnlSettings.Controls.SetChildIndex(this.baseline, 0);
            this.pnlSettings.Controls.SetChildIndex(this.lag, 0);
            this.pnlSettings.Controls.SetChildIndex(this.DateFieldsLookUp, 0);
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
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(AberrationKeeper), out resources);
            // Form Is Localizable: True
            // 
            // lblAberrationParameters
            // 
            resources.ApplyResources(this.lblAberrationParameters, "lblAberrationParameters");
            this.lblAberrationParameters.Name = "lblAberrationParameters";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // TimeUnitsLabel
            // 
            resources.ApplyResources(this.TimeUnitsLabel, "TimeUnitsLabel");
            this.TimeUnitsLabel.Name = "TimeUnitsLabel";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // TimeUnitsLookUp
            // 
            resources.ApplyResources(this.TimeUnitsLookUp, "TimeUnitsLookUp");
            this.TimeUnitsLookUp.Name = "TimeUnitsLookUp";
            this.TimeUnitsLookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("TimeUnitsLookUp.Properties.Buttons"))))});
            this.TimeUnitsLookUp.Properties.DropDownRows = 12;
            this.TimeUnitsLookUp.Properties.NullText = resources.GetString("TimeUnitsLookUp.Properties.NullText");
            this.TimeUnitsLookUp.EditValueChanged += new System.EventHandler(this.TimeUnitsLookUp_EditValueChanged);
            // 
            // LagUnits
            // 
            resources.ApplyResources(this.LagUnits, "LagUnits");
            this.LagUnits.Name = "LagUnits";
            // 
            // BaselineUnits
            // 
            resources.ApplyResources(this.BaselineUnits, "BaselineUnits");
            this.BaselineUnits.Name = "BaselineUnits";
            // 
            // threshold
            // 
            resources.ApplyResources(this.threshold, "threshold");
            this.threshold.Name = "threshold";
            this.threshold.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("threshold.Properties.Buttons"))))});
            this.threshold.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.threshold.Properties.MaxValue = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.threshold.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // baseline
            // 
            resources.ApplyResources(this.baseline, "baseline");
            this.baseline.Name = "baseline";
            this.baseline.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("baseline.Properties.Buttons"))))});
            this.baseline.Properties.IsFloatValue = false;
            this.baseline.Properties.Mask.EditMask = resources.GetString("baseline.Properties.Mask.EditMask");
            this.baseline.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.baseline.Properties.MinValue = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lag
            // 
            resources.ApplyResources(this.lag, "lag");
            this.lag.Name = "lag";
            this.lag.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("lag.Properties.Buttons"))))});
            this.lag.Properties.IsFloatValue = false;
            this.lag.Properties.Mask.EditMask = resources.GetString("lag.Properties.Mask.EditMask");
            this.lag.Properties.MaxValue = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.lag.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // DateFieldsLookUp
            // 
            this.DateFieldsLookUp.Appearance.Options.UseFont = true;
            this.DateFieldsLookUp.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            resources.ApplyResources(this.DateFieldsLookUp, "DateFieldsLookUp");
            this.DateFieldsLookUp.Name = "DateFieldsLookUp";
            this.DateFieldsLookUp.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.MultiFilterEventArgs>(this.DateFieldsLookUp_EditValueChanged);
            // 
            // AnalysisMethodLabel
            // 
            resources.ApplyResources(this.AnalysisMethodLabel, "AnalysisMethodLabel");
            this.AnalysisMethodLabel.Name = "AnalysisMethodLabel";
            // 
            // AnalysisMethodLookUp
            // 
            resources.ApplyResources(this.AnalysisMethodLookUp, "AnalysisMethodLookUp");
            this.AnalysisMethodLookUp.Name = "AnalysisMethodLookUp";
            this.AnalysisMethodLookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("AnalysisMethodLookUp.Properties.Buttons"))))});
            this.AnalysisMethodLookUp.Properties.DropDownRows = 12;
            this.AnalysisMethodLookUp.Properties.NullText = resources.GetString("AnalysisMethodLookUp.Properties.NullText");
            this.AnalysisMethodLookUp.EditValueChanged += new System.EventHandler(this.TimeUnitsLookUp_EditValueChanged);
            // 
            // AberrationKeeper
            // 
            this.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("AberrationKeeper.Appearance.Font")));
            this.Appearance.Options.UseFont = true;
            resources.ApplyResources(this, "$this");
            this.HeaderHeight = 220;
            this.Name = "AberrationKeeper";
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).EndInit();
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeUnitsLookUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threshold.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseline.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnalysisMethodLookUp.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblAberrationParameters;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label TimeUnitsLabel;
        private System.Windows.Forms.Label label5;
        protected DevExpress.XtraEditors.LookUpEdit TimeUnitsLookUp;
        private System.Windows.Forms.Label BaselineUnits;
        private System.Windows.Forms.Label LagUnits;
        private SpinEdit baseline;
        private SpinEdit threshold;
        private SpinEdit lag;
        protected EIDSS.Reports.BaseControls.Filters.SourceDateMultiFilter DateFieldsLookUp;
        private LookUpEdit AnalysisMethodLookUp;
        private System.Windows.Forms.Label AnalysisMethodLabel;
    }
}
