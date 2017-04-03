using EIDSS.Reports.BaseControls.Filters;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    partial class VetKeeper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VetKeeper));
            this.FromYearSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.FromYearLabel = new System.Windows.Forms.Label();
            this.FromMonthLookup = new DevExpress.XtraEditors.LookUpEdit();
            this.FromMonthLabel = new System.Windows.Forms.Label();
            this.ToMonthLabel = new System.Windows.Forms.Label();
            this.ToMonthLookup = new DevExpress.XtraEditors.LookUpEdit();
            this.ToYearLabel = new System.Windows.Forms.Label();
            this.ToYearSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.regionFilter = new EIDSS.Reports.BaseControls.Filters.RegionFilter();
            this.rayonFilter = new EIDSS.Reports.BaseControls.Filters.RayonFilter();
            this.organizationFilter = new EIDSS.Reports.BaseControls.Filters.VetOrganizationFilter();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromYearSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromMonthLookup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToMonthLookup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToYearSpinEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.organizationFilter);
            this.pnlSettings.Controls.Add(this.ToMonthLookup);
            this.pnlSettings.Controls.Add(this.ToYearSpinEdit);
            this.pnlSettings.Controls.Add(this.FromMonthLookup);
            this.pnlSettings.Controls.Add(this.FromYearSpinEdit);
            this.pnlSettings.Controls.Add(this.regionFilter);
            this.pnlSettings.Controls.Add(this.rayonFilter);
            this.pnlSettings.Controls.Add(this.ToMonthLabel);
            this.pnlSettings.Controls.Add(this.ToYearLabel);
            this.pnlSettings.Controls.Add(this.FromMonthLabel);
            this.pnlSettings.Controls.Add(this.FromYearLabel);
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Controls.SetChildIndex(this.GenerateReportButton, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.FromYearLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.FromMonthLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ToYearLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ToMonthLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.rayonFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.regionFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.FromYearSpinEdit, 0);
            this.pnlSettings.Controls.SetChildIndex(this.FromMonthLookup, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ToYearSpinEdit, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ToMonthLookup, 0);
            this.pnlSettings.Controls.SetChildIndex(this.organizationFilter, 0);
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
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(VetKeeper), out resources);
            // Form Is Localizable: True
            // 
            // FromYearSpinEdit
            // 
            resources.ApplyResources(this.FromYearSpinEdit, "FromYearSpinEdit");
            this.FromYearSpinEdit.Name = "FromYearSpinEdit";
            this.FromYearSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.FromYearSpinEdit.Properties.Mask.EditMask = resources.GetString("FromYearSpinEdit.Properties.Mask.EditMask");
            this.FromYearSpinEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("FromYearSpinEdit.Properties.Mask.MaskType")));
            this.FromYearSpinEdit.Properties.MaxValue = new decimal(new int[] {
            2040,
            0,
            0,
            0});
            this.FromYearSpinEdit.Properties.MinValue = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.FromYearSpinEdit.EditValueChanged += new System.EventHandler(this.YearSpinEdit_EditValueChanged);
            // 
            // FromYearLabel
            // 
            resources.ApplyResources(this.FromYearLabel, "FromYearLabel");
            this.FromYearLabel.ForeColor = System.Drawing.Color.Black;
            this.FromYearLabel.Name = "FromYearLabel";
            // 
            // FromMonthLookup
            // 
            resources.ApplyResources(this.FromMonthLookup, "FromMonthLookup");
            this.FromMonthLookup.Name = "FromMonthLookup";
            this.FromMonthLookup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("FromMonthLookup.Properties.Buttons")))),
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("FromMonthLookup.Properties.Buttons1"))))});
            this.FromMonthLookup.Properties.DropDownRows = 12;
            this.FromMonthLookup.Properties.NullText = resources.GetString("FromMonthLookup.Properties.NullText");
            this.FromMonthLookup.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.MonthLookup_ButtonClick);
            this.FromMonthLookup.EditValueChanged += new System.EventHandler(this.MonthLookup_EditValueChanged);
            // 
            // FromMonthLabel
            // 
            resources.ApplyResources(this.FromMonthLabel, "FromMonthLabel");
            this.FromMonthLabel.ForeColor = System.Drawing.Color.Black;
            this.FromMonthLabel.Name = "FromMonthLabel";
            // 
            // ToMonthLabel
            // 
            resources.ApplyResources(this.ToMonthLabel, "ToMonthLabel");
            this.ToMonthLabel.ForeColor = System.Drawing.Color.Black;
            this.ToMonthLabel.Name = "ToMonthLabel";
            // 
            // ToMonthLookup
            // 
            resources.ApplyResources(this.ToMonthLookup, "ToMonthLookup");
            this.ToMonthLookup.Name = "ToMonthLookup";
            this.ToMonthLookup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("ToMonthLookup.Properties.Buttons")))),
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("ToMonthLookup.Properties.Buttons1"))))});
            this.ToMonthLookup.Properties.DropDownRows = 12;
            this.ToMonthLookup.Properties.NullText = resources.GetString("ToMonthLookup.Properties.NullText");
            this.ToMonthLookup.EditValueChanged += new System.EventHandler(this.MonthLookup_EditValueChanged);
            // 
            // ToYearLabel
            // 
            resources.ApplyResources(this.ToYearLabel, "ToYearLabel");
            this.ToYearLabel.ForeColor = System.Drawing.Color.Black;
            this.ToYearLabel.Name = "ToYearLabel";
            // 
            // ToYearSpinEdit
            // 
            resources.ApplyResources(this.ToYearSpinEdit, "ToYearSpinEdit");
            this.ToYearSpinEdit.Name = "ToYearSpinEdit";
            this.ToYearSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ToYearSpinEdit.Properties.Mask.EditMask = resources.GetString("ToYearSpinEdit.Properties.Mask.EditMask");
            this.ToYearSpinEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("ToYearSpinEdit.Properties.Mask.MaskType")));
            this.ToYearSpinEdit.Properties.MaxValue = new decimal(new int[] {
            2040,
            0,
            0,
            0});
            this.ToYearSpinEdit.Properties.MinValue = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.ToYearSpinEdit.EditValueChanged += new System.EventHandler(this.YearSpinEdit_EditValueChanged);
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
            // organizationFilter
            // 
            this.organizationFilter.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.organizationFilter, "organizationFilter");
            this.organizationFilter.Name = "organizationFilter";
            // 
            // VetKeeper
            // 
            resources.ApplyResources(this, "$this");
            this.HeaderHeight = 170;
            this.Name = "VetKeeper";
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromYearSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromMonthLookup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToMonthLookup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToYearSpinEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SpinEdit FromYearSpinEdit;
        private System.Windows.Forms.Label FromYearLabel;
        private DevExpress.XtraEditors.LookUpEdit FromMonthLookup;
        private System.Windows.Forms.Label FromMonthLabel;
        private System.Windows.Forms.Label ToMonthLabel;
        private DevExpress.XtraEditors.LookUpEdit ToMonthLookup;
        private System.Windows.Forms.Label ToYearLabel;
        private DevExpress.XtraEditors.SpinEdit ToYearSpinEdit;
        private RegionFilter regionFilter;
        private RayonFilter rayonFilter;
        private VetOrganizationFilter organizationFilter;
    }
}
