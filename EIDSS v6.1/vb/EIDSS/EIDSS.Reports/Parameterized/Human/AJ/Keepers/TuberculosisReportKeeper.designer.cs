using EIDSS.Reports.BaseControls.Filters;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    partial class TuberculosisComparativeReportKeeper
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TuberculosisComparativeReportKeeper));
            this.StartMonthLookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.EndMonthLookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.EndMonthLabel = new System.Windows.Forms.Label();
            this.StartMonthLabel = new System.Windows.Forms.Label();
            this.DiagnosisFilter = new EIDSS.Reports.BaseControls.Filters.HumSingleTubDiagnosisFilter();
            this.YearFilter = new EIDSS.Reports.BaseControls.Filters.YearMultiFilter();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartMonthLookUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndMonthLookUp.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.YearFilter);
            this.pnlSettings.Controls.Add(this.DiagnosisFilter);
            this.pnlSettings.Controls.Add(this.EndMonthLookUp);
            this.pnlSettings.Controls.Add(this.StartMonthLookUp);
            this.pnlSettings.Controls.Add(this.StartMonthLabel);
            this.pnlSettings.Controls.Add(this.EndMonthLabel);
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Controls.SetChildIndex(this.GenerateReportButton, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.EndMonthLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.StartMonthLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.StartMonthLookUp, 0);
            this.pnlSettings.Controls.SetChildIndex(this.EndMonthLookUp, 0);
            this.pnlSettings.Controls.SetChildIndex(this.DiagnosisFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.YearFilter, 0);
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
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(TuberculosisComparativeReportKeeper), out resources);
            // Form Is Localizable: True
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
            // DiagnosisFilter
            // 
            this.DiagnosisFilter.AdditionalFilter = null;
            this.DiagnosisFilter.Appearance.Options.UseFont = true;
            this.DiagnosisFilter.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            resources.ApplyResources(this.DiagnosisFilter, "DiagnosisFilter");
            this.DiagnosisFilter.Name = "DiagnosisFilter";
            // 
            // YearFilter
            // 
            this.YearFilter.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("YearFilter.Appearance.Font")));
            this.YearFilter.Appearance.Options.UseFont = true;
            this.YearFilter.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            resources.ApplyResources(this.YearFilter, "YearFilter");
            this.YearFilter.Name = "YearFilter";

            this.YearFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.MultiFilterEventArgs>(this.Year_EditValueChanged);

            // 
            // TuberculosisComparativeReportKeeper
            // 
            resources.ApplyResources(this, "$this");
            this.HeaderHeight = 130;
            this.Name = "TuberculosisComparativeReportKeeper";
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartMonthLookUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndMonthLookUp.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraEditors.LookUpEdit StartMonthLookUp;
        protected DevExpress.XtraEditors.LookUpEdit EndMonthLookUp;
        protected System.Windows.Forms.Label EndMonthLabel;
        protected System.Windows.Forms.Label StartMonthLabel;
        private HumSingleTubDiagnosisFilter DiagnosisFilter;
        private YearMultiFilter YearFilter;
    }
}