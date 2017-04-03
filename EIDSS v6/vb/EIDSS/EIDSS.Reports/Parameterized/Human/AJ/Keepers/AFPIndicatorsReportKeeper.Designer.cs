namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    partial class AFPIndicatorsReportKeeper
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any m_Resources being used.
        /// </summary>
        /// <param name="disposing">true if managed m_Resources should be disposed; otherwise, false.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AFPIndicatorsReportKeeper));
            this.PeriodTypeLookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.PeriodTypeLabel = new System.Windows.Forms.Label();
            this.MonthLookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.PeriodLabel = new System.Windows.Forms.Label();
            this.HalfYearLookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.QuarterLookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PeriodTypeLookUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthLookUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HalfYearLookUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuarterLookUp.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.MonthLookUp);
            this.pnlSettings.Controls.Add(this.QuarterLookUp);
            this.pnlSettings.Controls.Add(this.HalfYearLookUp);
            this.pnlSettings.Controls.Add(this.PeriodTypeLookUp);
            this.pnlSettings.Controls.Add(this.PeriodLabel);
            this.pnlSettings.Controls.Add(this.PeriodTypeLabel);
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Controls.SetChildIndex(this.GenerateReportButton, 0);
            this.pnlSettings.Controls.SetChildIndex(this.PeriodTypeLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.PeriodLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.PeriodTypeLookUp, 0);
            this.pnlSettings.Controls.SetChildIndex(this.HalfYearLookUp, 0);
            this.pnlSettings.Controls.SetChildIndex(this.QuarterLookUp, 0);
            this.pnlSettings.Controls.SetChildIndex(this.MonthLookUp, 0);
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
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(AFPIndicatorsReportKeeper), out resources);
            // Form Is Localizable: True
            // 
            // PeriodTypeLookUp
            // 
            resources.ApplyResources(this.PeriodTypeLookUp, "PeriodTypeLookUp");
            this.PeriodTypeLookUp.Name = "PeriodTypeLookUp";
            this.PeriodTypeLookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("PeriodTypeLookUp.Properties.Buttons")))),
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("PeriodTypeLookUp.Properties.Buttons1"))))});
            this.PeriodTypeLookUp.Properties.DropDownRows = 12;
            this.PeriodTypeLookUp.Properties.NullText = resources.GetString("PeriodTypeLookUp.Properties.NullText");
            this.PeriodTypeLookUp.EditValueChanged += new System.EventHandler(this.PeriodTypeLookUp_EditValueChanged);
            // 
            // PeriodTypeLabel
            // 
            resources.ApplyResources(this.PeriodTypeLabel, "PeriodTypeLabel");
            this.PeriodTypeLabel.ForeColor = System.Drawing.Color.Black;
            this.PeriodTypeLabel.Name = "PeriodTypeLabel";
            // 
            // MonthLookUp
            // 
            resources.ApplyResources(this.MonthLookUp, "MonthLookUp");
            this.MonthLookUp.Name = "MonthLookUp";
            this.MonthLookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("MonthLookUp.Properties.Buttons")))),
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("MonthLookUp.Properties.Buttons1"))))});
            this.MonthLookUp.Properties.DropDownRows = 12;
            this.MonthLookUp.Properties.NullText = resources.GetString("MonthLookUp.Properties.NullText");
            
            // 
            // PeriodLabel
            // 
            resources.ApplyResources(this.PeriodLabel, "PeriodLabel");
            this.PeriodLabel.ForeColor = System.Drawing.Color.Black;
            this.PeriodLabel.Name = "PeriodLabel";
            // 
            // HalfYearLookUp
            // 
            resources.ApplyResources(this.HalfYearLookUp, "HalfYearLookUp");
            this.HalfYearLookUp.Name = "HalfYearLookUp";
            this.HalfYearLookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("HalfYearLookUp.Properties.Buttons")))),
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("HalfYearLookUp.Properties.Buttons1"))))});
            this.HalfYearLookUp.Properties.DropDownRows = 12;
            this.HalfYearLookUp.Properties.NullText = resources.GetString("HalfYearLookUp.Properties.NullText");
            
            // 
            // QuarterLookUp
            // 
            resources.ApplyResources(this.QuarterLookUp, "QuarterLookUp");
            this.QuarterLookUp.Name = "QuarterLookUp";
            this.QuarterLookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("QuarterLookUp.Properties.Buttons")))),
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("QuarterLookUp.Properties.Buttons1"))))});
            this.QuarterLookUp.Properties.DropDownRows = 12;
            this.QuarterLookUp.Properties.NullText = resources.GetString("QuarterLookUp.Properties.NullText");
            
            // 
            // AFPIndicatorsReportKeeper
            // 
            resources.ApplyResources(this, "$this");
            this.HeaderHeight = 130;
            this.Name = "AFPIndicatorsReportKeeper";
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PeriodTypeLookUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthLookUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HalfYearLookUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuarterLookUp.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit PeriodTypeLookUp;
        private System.Windows.Forms.Label PeriodTypeLabel;
        private DevExpress.XtraEditors.LookUpEdit MonthLookUp;
        private System.Windows.Forms.Label PeriodLabel;
        private DevExpress.XtraEditors.LookUpEdit QuarterLookUp;
        private DevExpress.XtraEditors.LookUpEdit HalfYearLookUp;

    }
}
