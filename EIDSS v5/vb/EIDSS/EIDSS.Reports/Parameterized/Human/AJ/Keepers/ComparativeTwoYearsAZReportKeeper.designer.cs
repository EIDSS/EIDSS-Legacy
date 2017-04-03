
using EIDSS.Reports.Parameterized.Human.AJ.Filters;

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
            this.StartYearLabel = new System.Windows.Forms.Label();
            this.Year1SpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.Year2SpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.EndYearLabel = new System.Windows.Forms.Label();
            this.CounterLookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.CounterLabel = new System.Windows.Forms.Label();
            this.OrganizationFilter = new EIDSS.Reports.Parameterized.Human.AJ.Filters.HumOrganizationFilter();
            this.regionFilter = new EIDSS.Reports.Parameterized.Filters.RegionFilter();
            this.rayonFilter = new EIDSS.Reports.Parameterized.Filters.RayonFilter();
            this.diagnosisFilter = new EIDSS.Reports.Parameterized.Human.AJ.Filters.SingleDiagnosisFilter();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Year1SpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Year2SpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CounterLookUp.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.diagnosisFilter);
            this.pnlSettings.Controls.Add(this.OrganizationFilter);
            this.pnlSettings.Controls.Add(this.regionFilter);
            this.pnlSettings.Controls.Add(this.rayonFilter);
            this.pnlSettings.Controls.Add(this.CounterLookUp);
            this.pnlSettings.Controls.Add(this.CounterLabel);
            this.pnlSettings.Controls.Add(this.Year2SpinEdit);
            this.pnlSettings.Controls.Add(this.Year1SpinEdit);
            this.pnlSettings.Controls.Add(this.EndYearLabel);
            this.pnlSettings.Controls.Add(this.StartYearLabel);
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Controls.SetChildIndex(this.StartYearLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.EndYearLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.Year1SpinEdit, 0);
            this.pnlSettings.Controls.SetChildIndex(this.Year2SpinEdit, 0);
            this.pnlSettings.Controls.SetChildIndex(this.CounterLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.CounterLookUp, 0);
            this.pnlSettings.Controls.SetChildIndex(this.rayonFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.regionFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.OrganizationFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.diagnosisFilter, 0);
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
            // StartYearLabel
            // 
            resources.ApplyResources(this.StartYearLabel, "StartYearLabel");
            this.StartYearLabel.ForeColor = System.Drawing.Color.Black;
            this.StartYearLabel.Name = "StartYearLabel";
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
            2000,
            0,
            0,
            0});
            this.Year2SpinEdit.EditValueChanged += new System.EventHandler(this.seYear2_EditValueChanged);
            // 
            // EndYearLabel
            // 
            resources.ApplyResources(this.EndYearLabel, "EndYearLabel");
            this.EndYearLabel.ForeColor = System.Drawing.Color.Black;
            this.EndYearLabel.Name = "EndYearLabel";
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
            this.CounterLookUp.EditValueChanged += new System.EventHandler(this.CounterLookUp_EditValueChanged);
            // 
            // CounterLabel
            // 
            resources.ApplyResources(this.CounterLabel, "CounterLabel");
            this.CounterLabel.ForeColor = System.Drawing.Color.Black;
            this.CounterLabel.Name = "CounterLabel";
            // 
            // OrganizationFilter
            // 
            this.OrganizationFilter.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.OrganizationFilter, "OrganizationFilter");
            this.OrganizationFilter.Name = "OrganizationFilter";
            this.OrganizationFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.SingleFilterEventArgs>(this.OrganizationFilter_ValueChanged);
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
            this.diagnosisFilter.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.diagnosisFilter, "diagnosisFilter");
            this.diagnosisFilter.Name = "diagnosisFilter";
            this.diagnosisFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.SingleFilterEventArgs>(this.diagnosisFilter_ValueChanged);
            // 
            // ComparativeTwoYearsAZReportKeeper
            // 
            resources.ApplyResources(this, "$this");
            this.HeaderHeight = 130;
            this.Name = "ComparativeTwoYearsAZReportKeeper";
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Year1SpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Year2SpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CounterLookUp.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label StartYearLabel;
        private DevExpress.XtraEditors.SpinEdit Year1SpinEdit;
        private DevExpress.XtraEditors.SpinEdit Year2SpinEdit;
        private System.Windows.Forms.Label EndYearLabel;
        private DevExpress.XtraEditors.LookUpEdit CounterLookUp;
        private System.Windows.Forms.Label CounterLabel;
        private Filters.HumOrganizationFilter OrganizationFilter;
        private Parameterized.Filters.RegionFilter regionFilter;
        private Parameterized.Filters.RayonFilter rayonFilter;
        private SingleDiagnosisFilter diagnosisFilter;
    }
}