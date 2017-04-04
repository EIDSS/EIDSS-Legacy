using EIDSS.Reports.BaseControls.Filters;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    partial class ComparativeTwoYearsAZReportKeeper
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComparativeTwoYearsAZReportKeeper));
            this.Year1SpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.Year2SpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.regionFilter = new EIDSS.Reports.BaseControls.Filters.RegionAZFilter();
            this.rayonFilter = new EIDSS.Reports.BaseControls.Filters.RayonFilter();
            this.diagnosisFilter = new EIDSS.Reports.BaseControls.Filters.HumSingleDiagnosisFilter();
            this.FromLabel = new System.Windows.Forms.Label();
            this.ToLabel = new System.Windows.Forms.Label();
            this.CounterFilter = new EIDSS.Reports.BaseControls.Filters.CounterMultiFilter();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Year1SpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Year2SpinEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.CounterFilter);
            this.pnlSettings.Controls.Add(this.diagnosisFilter);
            this.pnlSettings.Controls.Add(this.regionFilter);
            this.pnlSettings.Controls.Add(this.rayonFilter);
            this.pnlSettings.Controls.Add(this.Year2SpinEdit);
            this.pnlSettings.Controls.Add(this.Year1SpinEdit);
            this.pnlSettings.Controls.Add(this.ToLabel);
            this.pnlSettings.Controls.Add(this.FromLabel);
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Controls.SetChildIndex(this.FromLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ToLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.Year1SpinEdit, 0);
            this.pnlSettings.Controls.SetChildIndex(this.Year2SpinEdit, 0);
            this.pnlSettings.Controls.SetChildIndex(this.rayonFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.regionFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.diagnosisFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.CounterFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.GenerateReportButton, 0);
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
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(ComparativeTwoYearsAZReportKeeper), out resources);
            // Form Is Localizable: True
            // 
            // Year1SpinEdit
            // 
            resources.ApplyResources(this.Year1SpinEdit, "Year1SpinEdit");
            this.Year1SpinEdit.Name = "Year1SpinEdit";
            this.Year1SpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Year1SpinEdit.Properties.Mask.EditMask = resources.GetString("Year1SpinEdit.Properties.Mask.EditMask");
            this.Year1SpinEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("Year1SpinEdit.Properties.Mask.MaskType")));
            this.Year1SpinEdit.Properties.MaxValue = new decimal(new int[] {
            2030,
            0,
            0,
            0});
            this.Year1SpinEdit.Properties.MinValue = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.Year1SpinEdit.EditValueChanged += new System.EventHandler(this.seYear1_EditValueChanged);
            // 
            // Year2SpinEdit
            // 
            resources.ApplyResources(this.Year2SpinEdit, "Year2SpinEdit");
            this.Year2SpinEdit.Name = "Year2SpinEdit";
            this.Year2SpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Year2SpinEdit.Properties.Mask.EditMask = resources.GetString("Year2SpinEdit.Properties.Mask.EditMask");
            this.Year2SpinEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("Year2SpinEdit.Properties.Mask.MaskType")));
            this.Year2SpinEdit.Properties.MaxValue = new decimal(new int[] {
            2030,
            0,
            0,
            0});
            this.Year2SpinEdit.Properties.MinValue = new decimal(new int[] {
            2001,
            0,
            0,
            0});
            this.Year2SpinEdit.EditValueChanged += new System.EventHandler(this.seYear2_EditValueChanged);
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
            // diagnosisFilter
            // 
            this.diagnosisFilter.AdditionalFilter = null;
            this.diagnosisFilter.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.diagnosisFilter, "diagnosisFilter");
            this.diagnosisFilter.Name = "diagnosisFilter";
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
            // CounterFilter
            // 
            this.CounterFilter.Appearance.Options.UseFont = true;
            this.CounterFilter.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            resources.ApplyResources(this.CounterFilter, "CounterFilter");
            this.CounterFilter.Name = "CounterFilter";
            this.CounterFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.MultiFilterEventArgs>(this.CounterFilter_ValueChanged);
            this.CounterFilter.ItemCheck += new System.EventHandler<DevExpress.XtraEditors.Controls.ItemCheckEventArgs>(this.CounterFilter_ItemCheck);
            // 
            // ComparativeTwoYearsAZReportKeeper
            // 
            this.HeaderHeight = 130;
            this.Name = "ComparativeTwoYearsAZReportKeeper";
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Year1SpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Year2SpinEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SpinEdit Year1SpinEdit;
        private DevExpress.XtraEditors.SpinEdit Year2SpinEdit;
        private RegionAZFilter regionFilter;
        private RayonFilter rayonFilter;
        private HumSingleDiagnosisFilter diagnosisFilter;
        private System.Windows.Forms.Label ToLabel;
        private System.Windows.Forms.Label FromLabel;
        private CounterMultiFilter CounterFilter;
    }
}