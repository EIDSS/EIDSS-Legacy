using EIDSS.Reports.BaseControls.Filters;

namespace EIDSS.Reports.Parameterized.Human.TH.Keepers
{
    partial class ComparativeSeveralYearsTHReportKeeper
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComparativeSeveralYearsTHReportKeeper));
            this.YearFromSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.YearToSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.ProvinceFilter = new EIDSS.Reports.BaseControls.Filters.RegionFilter();
            this.DistrictFilter = new EIDSS.Reports.BaseControls.Filters.DistrictFilter();
            this.DiagnosesFilter = new EIDSS.Reports.BaseControls.Filters.HumStandardDiagnosisMultiFilter();
            this.FromLabel = new System.Windows.Forms.Label();
            this.ToLabel = new System.Windows.Forms.Label();
            this.ProvinceLabel = new System.Windows.Forms.Label();
            this.CounterLookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.CounterLabel = new System.Windows.Forms.Label();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YearFromSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YearToSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CounterLookUp.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.CounterLookUp);
            this.pnlSettings.Controls.Add(this.CounterLabel);
            this.pnlSettings.Controls.Add(this.ProvinceLabel);
            this.pnlSettings.Controls.Add(this.ToLabel);
            this.pnlSettings.Controls.Add(this.FromLabel);
            this.pnlSettings.Controls.Add(this.DiagnosesFilter);
            this.pnlSettings.Controls.Add(this.ProvinceFilter);
            this.pnlSettings.Controls.Add(this.DistrictFilter);
            this.pnlSettings.Controls.Add(this.YearToSpinEdit);
            this.pnlSettings.Controls.Add(this.YearFromSpinEdit);
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Controls.SetChildIndex(this.GenerateReportButton, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.YearFromSpinEdit, 0);
            this.pnlSettings.Controls.SetChildIndex(this.YearToSpinEdit, 0);
            this.pnlSettings.Controls.SetChildIndex(this.DistrictFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ProvinceFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.DiagnosesFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.FromLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ToLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ProvinceLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.CounterLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.CounterLookUp, 0);
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
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(ComparativeSeveralYearsTHReportKeeper), out resources);
            // Form Is Localizable: True
            // 
            // YearFromSpinEdit
            // 
            resources.ApplyResources(this.YearFromSpinEdit, "YearFromSpinEdit");
            this.YearFromSpinEdit.Name = "YearFromSpinEdit";
            this.YearFromSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.YearFromSpinEdit.Properties.Mask.EditMask = resources.GetString("YearFromSpinEdit.Properties.Mask.EditMask");
            this.YearFromSpinEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("YearFromSpinEdit.Properties.Mask.MaskType")));
            this.YearFromSpinEdit.Properties.MaxValue = new decimal(new int[] {
            2030,
            0,
            0,
            0});
            this.YearFromSpinEdit.Properties.MinValue = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.YearFromSpinEdit.EditValueChanged += new System.EventHandler(this.seYear1_EditValueChanged);
            // 
            // YearToSpinEdit
            // 
            resources.ApplyResources(this.YearToSpinEdit, "YearToSpinEdit");
            this.YearToSpinEdit.Name = "YearToSpinEdit";
            this.YearToSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.YearToSpinEdit.Properties.Mask.EditMask = resources.GetString("YearToSpinEdit.Properties.Mask.EditMask");
            this.YearToSpinEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("YearToSpinEdit.Properties.Mask.MaskType")));
            this.YearToSpinEdit.Properties.MaxValue = new decimal(new int[] {
            2030,
            0,
            0,
            0});
            this.YearToSpinEdit.Properties.MinValue = new decimal(new int[] {
            2001,
            0,
            0,
            0});
            this.YearToSpinEdit.EditValueChanged += new System.EventHandler(this.seYear2_EditValueChanged);
            // 
            // ProvinceFilter
            // 
            this.ProvinceFilter.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.ProvinceFilter, "ProvinceFilter");
            this.ProvinceFilter.Name = "ProvinceFilter";
            this.ProvinceFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.SingleFilterEventArgs>(this.regionFilter_ValueChanged);
            // 
            // DistrictFilter
            // 
            this.DistrictFilter.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.DistrictFilter, "DistrictFilter");
            this.DistrictFilter.Name = "DistrictFilter";
            this.DistrictFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.SingleFilterEventArgs>(this.rayonFilter_ValueChanged);
            // 
            // DiagnosesFilter
            // 
            this.DiagnosesFilter.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.DiagnosesFilter, "DiagnosesFilter");
            this.DiagnosesFilter.Name = "DiagnosesFilter";
            this.DiagnosesFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.MultiFilterEventArgs>(this.diagnosisFilter_ValueChanged);
            // 
            // FromLabel
            // 
            resources.ApplyResources(this.FromLabel, "FromLabel");
            this.FromLabel.ForeColor = System.Drawing.Color.Black;
            this.FromLabel.Name = "FromLabel";
            // 
            // ToLabel
            // 
            resources.ApplyResources(this.ToLabel, "ToLabel");
            this.ToLabel.ForeColor = System.Drawing.Color.Black;
            this.ToLabel.Name = "ToLabel";
            // 
            // ProvinceLabel
            // 
            resources.ApplyResources(this.ProvinceLabel, "ProvinceLabel");
            this.ProvinceLabel.Name = "ProvinceLabel";
            // 
            // CounterLookUp
            // 
            resources.ApplyResources(this.CounterLookUp, "CounterLookUp");
            this.CounterLookUp.Name = "CounterLookUp";
            this.CounterLookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("CounterLookUp.Properties.Buttons")))),
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("CounterLookUp.Properties.Buttons1"))))});
            this.CounterLookUp.Properties.DropDownRows = 12;
            this.CounterLookUp.Properties.NullText = resources.GetString("CounterLookUp.Properties.NullText");
            // 
            // CounterLabel
            // 
            resources.ApplyResources(this.CounterLabel, "CounterLabel");
            this.CounterLabel.ForeColor = System.Drawing.Color.Black;
            this.CounterLabel.Name = "CounterLabel";
            // 
            // ComparativeSeveralYearsTHReportKeeper
            // 
            resources.ApplyResources(this, "$this");
            this.HeaderHeight = 130;
            this.Name = "ComparativeSeveralYearsTHReportKeeper";
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YearFromSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YearToSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CounterLookUp.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SpinEdit YearFromSpinEdit;
        private DevExpress.XtraEditors.SpinEdit YearToSpinEdit;
        private RegionFilter ProvinceFilter;
        private DistrictFilter DistrictFilter;
        private HumStandardDiagnosisMultiFilter DiagnosesFilter;
        private System.Windows.Forms.Label ToLabel;
        private System.Windows.Forms.Label FromLabel;
        private System.Windows.Forms.Label ProvinceLabel;
        private DevExpress.XtraEditors.LookUpEdit CounterLookUp;
        private System.Windows.Forms.Label CounterLabel;
    }
}