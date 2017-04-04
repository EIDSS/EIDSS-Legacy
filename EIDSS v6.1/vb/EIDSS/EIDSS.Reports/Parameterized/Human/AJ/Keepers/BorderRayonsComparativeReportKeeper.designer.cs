using EIDSS.Reports.BaseControls.Filters;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    partial class BorderRayonsComparativeReportKeeper
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BorderRayonsComparativeReportKeeper));
            this.StartYearLabel = new System.Windows.Forms.Label();
            this.YearSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.StartMonthLookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.EndMonthLookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.EndMonthLabel = new System.Windows.Forms.Label();
            this.StartMonthLabel = new System.Windows.Forms.Label();
            this.RegionFilter = new EIDSS.Reports.BaseControls.Filters.RegionFilter();
            this.RayonFilter = new EIDSS.Reports.BaseControls.Filters.RayonFilter();
            this.diagnosisFilter = new EIDSS.Reports.BaseControls.Filters.HumDiagnosisGroupsDiagnosesMultiFilter();
            this.CounterFilter = new EIDSS.Reports.BaseControls.Filters.CounterMultiFilter();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YearSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartMonthLookUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndMonthLookUp.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.CounterFilter);
            this.pnlSettings.Controls.Add(this.diagnosisFilter);
            this.pnlSettings.Controls.Add(this.RegionFilter);
            this.pnlSettings.Controls.Add(this.RayonFilter);
            this.pnlSettings.Controls.Add(this.EndMonthLookUp);
            this.pnlSettings.Controls.Add(this.StartMonthLookUp);
            this.pnlSettings.Controls.Add(this.StartMonthLabel);
            this.pnlSettings.Controls.Add(this.EndMonthLabel);
            this.pnlSettings.Controls.Add(this.YearSpinEdit);
            this.pnlSettings.Controls.Add(this.StartYearLabel);
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Controls.SetChildIndex(this.GenerateReportButton, 0);
            this.pnlSettings.Controls.SetChildIndex(this.StartYearLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.YearSpinEdit, 0);
            this.pnlSettings.Controls.SetChildIndex(this.EndMonthLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.StartMonthLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.StartMonthLookUp, 0);
            this.pnlSettings.Controls.SetChildIndex(this.EndMonthLookUp, 0);
            this.pnlSettings.Controls.SetChildIndex(this.RayonFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.RegionFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.diagnosisFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.CounterFilter, 0);
            // 
            // ceUseArchiveData
            // 
            resources.ApplyResources(this.ceUseArchiveData, "ceUseArchiveData");
            this.ceUseArchiveData.Properties.Appearance.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceDisabled.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceFocused.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.ceUseArchiveData.Properties.Caption = resources.GetString("ceUseArchiveData.Properties.Caption");
            // 
            // GenerateReportButton
            // 
            resources.ApplyResources(this.GenerateReportButton, "GenerateReportButton");
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(BorderRayonsComparativeReportKeeper), out resources);
            // Form Is Localizable: True
            // 
            // StartYearLabel
            // 
            resources.ApplyResources(this.StartYearLabel, "StartYearLabel");
            this.StartYearLabel.ForeColor = System.Drawing.Color.Black;
            this.StartYearLabel.Name = "StartYearLabel";
            // 
            // YearSpinEdit
            // 
            resources.ApplyResources(this.YearSpinEdit, "YearSpinEdit");
            this.YearSpinEdit.Name = "YearSpinEdit";
            this.YearSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.YearSpinEdit.Properties.Mask.EditMask = resources.GetString("YearSpinEdit.Properties.Mask.EditMask");
            this.YearSpinEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("YearSpinEdit.Properties.Mask.MaskType")));
            this.YearSpinEdit.Properties.MaxValue = new decimal(new int[] {
            2030,
            0,
            0,
            0});
            this.YearSpinEdit.Properties.MinValue = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // StartMonthLookUp
            // 
            resources.ApplyResources(this.StartMonthLookUp, "StartMonthLookUp");
            this.StartMonthLookUp.Name = "StartMonthLookUp";
            this.StartMonthLookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("StartMonthLookUp.Properties.Buttons")))),
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("StartMonthLookUp.Properties.Buttons1"))))});
            this.StartMonthLookUp.Properties.DropDownRows = 12;
            this.StartMonthLookUp.Properties.NullText = resources.GetString("StartMonthLookUp.Properties.NullText");
            this.StartMonthLookUp.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.Month_ButtonClick);
            this.StartMonthLookUp.EditValueChanged += new System.EventHandler(this.StartMonth_EditValueChanged);
            // 
            // EndMonthLookUp
            // 
            resources.ApplyResources(this.EndMonthLookUp, "EndMonthLookUp");
            this.EndMonthLookUp.Name = "EndMonthLookUp";
            this.EndMonthLookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("EndMonthLookUp.Properties.Buttons")))),
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("EndMonthLookUp.Properties.Buttons1"))))});
            this.EndMonthLookUp.Properties.DropDownRows = 12;
            this.EndMonthLookUp.Properties.NullText = resources.GetString("EndMonthLookUp.Properties.NullText");
            this.EndMonthLookUp.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.Month_ButtonClick);
            this.EndMonthLookUp.EditValueChanged += new System.EventHandler(this.EndMonth_EditValueChanged);
            // 
            // EndMonthLabel
            // 
            resources.ApplyResources(this.EndMonthLabel, "EndMonthLabel");
            this.EndMonthLabel.ForeColor = System.Drawing.Color.Black;
            this.EndMonthLabel.Name = "EndMonthLabel";
            // 
            // StartMonthLabel
            // 
            resources.ApplyResources(this.StartMonthLabel, "StartMonthLabel");
            this.StartMonthLabel.ForeColor = System.Drawing.Color.Black;
            this.StartMonthLabel.Name = "StartMonthLabel";
            // 
            // RegionFilter
            // 
            this.RegionFilter.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.RegionFilter, "RegionFilter");
            this.RegionFilter.Name = "RegionFilter";
            this.RegionFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.SingleFilterEventArgs>(this.Region_ValueChanged);
            // 
            // RayonFilter
            // 
            this.RayonFilter.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.RayonFilter, "RayonFilter");
            this.RayonFilter.Name = "RayonFilter";
            this.RayonFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.SingleFilterEventArgs>(this.Rayon_ValueChanged);
            // 
            // diagnosisFilter
            // 
            this.diagnosisFilter.Appearance.Options.UseFont = true;
            this.diagnosisFilter.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            resources.ApplyResources(this.diagnosisFilter, "diagnosisFilter");
            this.diagnosisFilter.Name = "diagnosisFilter";
            this.diagnosisFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.MultiFilterEventArgs>(this.Diagnosis_ValueChanged);
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
            // BorderRayonsComparativeReportKeeper
            // 
            this.HeaderHeight = 170;
            this.Name = "BorderRayonsComparativeReportKeeper";
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YearSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartMonthLookUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndMonthLookUp.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label StartYearLabel;
        protected DevExpress.XtraEditors.SpinEdit YearSpinEdit;
        protected DevExpress.XtraEditors.LookUpEdit StartMonthLookUp;
        protected DevExpress.XtraEditors.LookUpEdit EndMonthLookUp;
        protected System.Windows.Forms.Label EndMonthLabel;
        protected System.Windows.Forms.Label StartMonthLabel;
        protected RegionFilter RegionFilter;
        protected RayonFilter RayonFilter;
        private HumDiagnosisGroupsDiagnosesMultiFilter diagnosisFilter;
        private CounterMultiFilter CounterFilter;
    }
}