
namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    partial class AssignmentLabDiagnosticReportKeeper
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssignmentLabDiagnosticReportKeeper));
            this.CaseId = new DevExpress.XtraEditors.TextEdit();
            this.lblCaseID = new DevExpress.XtraEditors.LabelControl();
            this.ValidateButton = new DevExpress.XtraEditors.SimpleButton();
            this.SentTo = new EIDSS.Reports.BaseControls.Filters.SentToAZLookupFilter();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CaseId.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.SentTo);
            this.pnlSettings.Controls.Add(this.ValidateButton);
            this.pnlSettings.Controls.Add(this.lblCaseID);
            this.pnlSettings.Controls.Add(this.CaseId);
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Controls.SetChildIndex(this.CaseId, 0);
            this.pnlSettings.Controls.SetChildIndex(this.lblCaseID, 0);
            this.pnlSettings.Controls.SetChildIndex(this.GenerateReportButton, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ValidateButton, 0);
            this.pnlSettings.Controls.SetChildIndex(this.SentTo, 0);
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
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(AssignmentLabDiagnosticReportKeeper), out resources);
            // Form Is Localizable: True
            // 
            // CaseId
            // 
            resources.ApplyResources(this.CaseId, "CaseId");
            this.CaseId.Name = "CaseId";
            this.CaseId.EditValueChanged += new System.EventHandler(this.CaseId_EditValueChanged);
            // 
            // lblCaseID
            // 
            resources.ApplyResources(this.lblCaseID, "lblCaseID");
            this.lblCaseID.Name = "lblCaseID";
            // 
            // ValidateButton
            // 
            resources.ApplyResources(this.ValidateButton, "ValidateButton");
            this.ValidateButton.Name = "ValidateButton";
            this.ValidateButton.Click += new System.EventHandler(this.ValidateButton_Click);
            // 
            // SentTo
            // 
            resources.ApplyResources(this.SentTo, "SentTo");
            this.SentTo.Name = "SentTo";
            // 
            // AssignmentLabDiagnosticReportKeeper
            // 
            this.HeaderHeight = 130;
            this.Name = "AssignmentLabDiagnosticReportKeeper";
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CaseId.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit CaseId;
        private DevExpress.XtraEditors.LabelControl lblCaseID;
        private DevExpress.XtraEditors.SimpleButton ValidateButton;
        private BaseControls.Filters.SentToAZLookupFilter SentTo;

    }
}