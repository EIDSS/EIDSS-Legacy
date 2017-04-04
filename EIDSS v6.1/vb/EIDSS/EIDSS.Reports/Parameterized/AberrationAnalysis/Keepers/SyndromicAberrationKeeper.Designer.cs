using EIDSS.Reports.BaseControls.Filters;
namespace EIDSS.Reports.Parameterized.AberrationAnalysis.Keepers
{
    partial class SyndromicAberrationKeeper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SyndromicAberrationKeeper));
            this.siteLookupFilter = new EIDSS.Reports.BaseControls.Filters.SiteLookupFilter();
            this.ageTo = new DevExpress.XtraEditors.SpinEdit();
            this.ageFrom = new DevExpress.XtraEditors.SpinEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.humGenderLookupFilter = new EIDSS.Reports.BaseControls.Filters.HumGenderLookupFilter();
            this.syndromicTypeLookupFilter = new EIDSS.Reports.BaseControls.Filters.SyndromicTypeLookupFilter();
            this.syndrOrganizationFilter = new EIDSS.Reports.BaseControls.Filters.SyndrOrganizationFilter();
            ((System.ComponentModel.ISupportInitialize)(this.TimeUnitsLookUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).BeginInit();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ageTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ageFrom.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // TimeUnitsLookUp
            // 
            // 
            // DateFieldsLookUp
            // 
            this.DateFieldsLookUp.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("DateFieldsLookUp.Appearance.Font")));
            this.DateFieldsLookUp.Appearance.Options.UseFont = true;
            // 
            // regionFilter
            // 
            this.regionFilter.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("regionFilter.Appearance.Font")));
            this.regionFilter.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.regionFilter, "regionFilter");
            // 
            // rayonFilter
            // 
            this.rayonFilter.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.rayonFilter, "rayonFilter");
            // 
            // settlementFilter
            // 
            resources.ApplyResources(this.settlementFilter, "settlementFilter");
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
            this.pnlSettings.Controls.Add(this.syndrOrganizationFilter);
            this.pnlSettings.Controls.Add(this.syndromicTypeLookupFilter);
            this.pnlSettings.Controls.Add(this.ageTo);
            this.pnlSettings.Controls.Add(this.ageFrom);
            this.pnlSettings.Controls.Add(this.label7);
            this.pnlSettings.Controls.Add(this.label6);
            this.pnlSettings.Controls.Add(this.label8);
            this.pnlSettings.Controls.Add(this.label3);
            this.pnlSettings.Controls.Add(this.humGenderLookupFilter);
            this.pnlSettings.Controls.Add(this.siteLookupFilter);
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Controls.SetChildIndex(this.GenerateReportButton, 0);
            this.pnlSettings.Controls.SetChildIndex(this.TimeUnitsLookUp, 0);
            this.pnlSettings.Controls.SetChildIndex(this.DateFieldsLookUp, 0);
            this.pnlSettings.Controls.SetChildIndex(this.lblStart, 0);
            this.pnlSettings.Controls.SetChildIndex(this.lblEnd, 0);
            this.pnlSettings.Controls.SetChildIndex(this.dtStart, 0);
            this.pnlSettings.Controls.SetChildIndex(this.dtEnd, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.rayonFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.regionFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.settlementFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.siteLookupFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.humGenderLookupFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.label3, 0);
            this.pnlSettings.Controls.SetChildIndex(this.label8, 0);
            this.pnlSettings.Controls.SetChildIndex(this.label6, 0);
            this.pnlSettings.Controls.SetChildIndex(this.label7, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ageFrom, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ageTo, 0);
            this.pnlSettings.Controls.SetChildIndex(this.syndromicTypeLookupFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.syndrOrganizationFilter, 0);
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
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(SyndromicAberrationKeeper), out resources);
            // Form Is Localizable: True
            // 
            // siteLookupFilter
            // 
            resources.ApplyResources(this.siteLookupFilter, "siteLookupFilter");
            this.siteLookupFilter.Name = "siteLookupFilter";
            
            // 
            // ageTo
            // 
            resources.ApplyResources(this.ageTo, "ageTo");
            this.ageTo.Name = "ageTo";
            this.ageTo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.ageTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("ageTo.Properties.Buttons"))))});
            this.ageTo.Properties.IsFloatValue = false;
            this.ageTo.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("ageTo.Properties.Mask.MaskType")));
            this.ageTo.Properties.MaxValue = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.ageTo.Properties.NullValuePrompt = resources.GetString("ageTo.Properties.NullValuePrompt");
            this.ageTo.EditValueChanged += new System.EventHandler(this.ageTo_EditValueChanged);
            this.ageTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.age_KeyDown);
            this.ageTo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.age_KeyUp);
            // 
            // ageFrom
            // 
            resources.ApplyResources(this.ageFrom, "ageFrom");
            this.ageFrom.Name = "ageFrom";
            this.ageFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.ageFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("ageFrom.Properties.Buttons"))))});
            this.ageFrom.Properties.IsFloatValue = false;
            this.ageFrom.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("ageFrom.Properties.Mask.MaskType")));
            this.ageFrom.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ageFrom.Properties.NullValuePrompt = resources.GetString("ageFrom.Properties.NullValuePrompt");
            this.ageFrom.EditValueChanged += new System.EventHandler(this.ageFrom_EditValueChanged);
            this.ageFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.age_KeyDown);
            this.ageFrom.KeyUp += new System.Windows.Forms.KeyEventHandler(this.age_KeyUp);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // humGenderLookupFilter
            // 
            resources.ApplyResources(this.humGenderLookupFilter, "humGenderLookupFilter");
            this.humGenderLookupFilter.Name = "humGenderLookupFilter";
            
            // 
            // syndromicTypeLookupFilter
            // 
            resources.ApplyResources(this.syndromicTypeLookupFilter, "syndromicTypeLookupFilter");
            this.syndromicTypeLookupFilter.Name = "syndromicTypeLookupFilter";
            
            // 
            // syndrOrganizationFilter
            // 
            resources.ApplyResources(this.syndrOrganizationFilter, "syndrOrganizationFilter");
            this.syndrOrganizationFilter.Name = "syndrOrganizationFilter";
            
            // 
            // SyndromicAberrationKeeper
            // 
            this.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("SyndromicAberrationKeeper.Appearance.Font")));
            this.Appearance.Options.UseFont = true;
            resources.ApplyResources(this, "$this");
            this.HeaderHeight = 230;
            this.Name = "SyndromicAberrationKeeper";
            ((System.ComponentModel.ISupportInitialize)(this.TimeUnitsLookUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).EndInit();
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ageTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ageFrom.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SiteLookupFilter siteLookupFilter;
        private SyndromicTypeLookupFilter syndromicTypeLookupFilter;
        private DevExpress.XtraEditors.SpinEdit ageTo;
        private DevExpress.XtraEditors.SpinEdit ageFrom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private HumGenderLookupFilter humGenderLookupFilter;
        private SyndrOrganizationFilter syndrOrganizationFilter;
    }
}
