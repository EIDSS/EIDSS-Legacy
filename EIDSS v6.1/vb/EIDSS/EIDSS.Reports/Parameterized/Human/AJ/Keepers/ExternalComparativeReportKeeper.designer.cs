using EIDSS.Reports.BaseControls.Filters;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    partial class ExternalComparativeReportKeeper
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExternalComparativeReportKeeper));
            this.StartYearLabel = new System.Windows.Forms.Label();
            this.Year1SpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.Year2SpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.EndYearLabel = new System.Windows.Forms.Label();
            this.region1Filter = new EIDSS.Reports.BaseControls.Filters.RegionAZFilter();
            this.rayon1Filter = new EIDSS.Reports.BaseControls.Filters.RayonFilter();
            this.EndMonthLookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.StartMonthLabel = new System.Windows.Forms.Label();
            this.EndMonthLabel = new System.Windows.Forms.Label();
            this.StartMonthValue = new System.Windows.Forms.Label();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Year1SpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Year2SpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndMonthLookUp.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.StartMonthValue);
            this.pnlSettings.Controls.Add(this.EndMonthLookUp);
            this.pnlSettings.Controls.Add(this.StartMonthLabel);
            this.pnlSettings.Controls.Add(this.EndMonthLabel);
            this.pnlSettings.Controls.Add(this.Year1SpinEdit);
            this.pnlSettings.Controls.Add(this.Year2SpinEdit);
            this.pnlSettings.Controls.Add(this.region1Filter);
            this.pnlSettings.Controls.Add(this.rayon1Filter);
            this.pnlSettings.Controls.Add(this.EndYearLabel);
            this.pnlSettings.Controls.Add(this.StartYearLabel);
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Controls.SetChildIndex(this.GenerateReportButton, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.StartYearLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.EndYearLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.rayon1Filter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.region1Filter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.Year2SpinEdit, 0);
            this.pnlSettings.Controls.SetChildIndex(this.Year1SpinEdit, 0);
            this.pnlSettings.Controls.SetChildIndex(this.EndMonthLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.StartMonthLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.EndMonthLookUp, 0);
            this.pnlSettings.Controls.SetChildIndex(this.StartMonthValue, 0);
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
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(ExternalComparativeReportKeeper), out resources);
            // Form Is Localizable: True
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
            // region1Filter
            // 
            this.region1Filter.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("region1Filter.Appearance.Font")));
            this.region1Filter.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.region1Filter, "region1Filter");
            this.region1Filter.Name = "region1Filter";
            this.region1Filter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.SingleFilterEventArgs>(this.Region_ValueChanged);
            // 
            // rayon1Filter
            // 
            this.rayon1Filter.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.rayon1Filter, "rayon1Filter");
            this.rayon1Filter.Name = "rayon1Filter";
            this.rayon1Filter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.SingleFilterEventArgs>(this.Rayon_ValueChanged);
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
            this.EndMonthLookUp.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.MonthLookUp_ButtonClick);
            this.EndMonthLookUp.EditValueChanged += new System.EventHandler(this.EndMonthLookUp_EditValueChanged);
            // 
            // StartMonthLabel
            // 
            resources.ApplyResources(this.StartMonthLabel, "StartMonthLabel");
            this.StartMonthLabel.ForeColor = System.Drawing.Color.Black;
            this.StartMonthLabel.Name = "StartMonthLabel";
            // 
            // EndMonthLabel
            // 
            resources.ApplyResources(this.EndMonthLabel, "EndMonthLabel");
            this.EndMonthLabel.ForeColor = System.Drawing.Color.Black;
            this.EndMonthLabel.Name = "EndMonthLabel";
            // 
            // StartMonthValue
            // 
            this.StartMonthValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.StartMonthValue, "StartMonthValue");
            this.StartMonthValue.ForeColor = System.Drawing.Color.Black;
            this.StartMonthValue.Name = "StartMonthValue";
            // 
            // ExternalComparativeReportKeeper
            // 
            this.HeaderHeight = 130;
            this.Name = "ExternalComparativeReportKeeper";
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Year1SpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Year2SpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndMonthLookUp.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label StartYearLabel;
        private DevExpress.XtraEditors.SpinEdit Year1SpinEdit;
        private DevExpress.XtraEditors.SpinEdit Year2SpinEdit;
        private System.Windows.Forms.Label EndYearLabel;
        private RegionAZFilter region1Filter;
        private RayonFilter rayon1Filter;
        protected DevExpress.XtraEditors.LookUpEdit EndMonthLookUp;
        protected System.Windows.Forms.Label StartMonthLabel;
        protected System.Windows.Forms.Label EndMonthLabel;
        protected System.Windows.Forms.Label StartMonthValue;
    }
}