
namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    partial class LabTestingTesultsReportKeeper
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabTestingTesultsReportKeeper));
            this.SampleId = new DevExpress.XtraEditors.TextEdit();
            this.SearchButton = new DevExpress.XtraEditors.SimpleButton();
            this.Department = new EIDSS.Reports.BaseControls.Filters.DepartmentAZLookupFilter();
            this.lblSampleID = new DevExpress.XtraEditors.LabelControl();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SampleId.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.lblSampleID);
            this.pnlSettings.Controls.Add(this.Department);
            this.pnlSettings.Controls.Add(this.SearchButton);
            this.pnlSettings.Controls.Add(this.SampleId);
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Controls.SetChildIndex(this.SampleId, 0);
            this.pnlSettings.Controls.SetChildIndex(this.GenerateReportButton, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.SearchButton, 0);
            this.pnlSettings.Controls.SetChildIndex(this.Department, 0);
            this.pnlSettings.Controls.SetChildIndex(this.lblSampleID, 0);
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
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(LabTestingTesultsReportKeeper), out resources);
            // Form Is Localizable: True
            // 
            // SampleId
            // 
            resources.ApplyResources(this.SampleId, "SampleId");
            this.SampleId.Name = "SampleId";
            this.SampleId.EditValueChanged += new System.EventHandler(this.SampleId_EditValueChanged);
            // 
            // SearchButton
            // 
            resources.ApplyResources(this.SearchButton, "SearchButton");
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // Department
            // 
            resources.ApplyResources(this.Department, "Department");
            this.Department.Name = "Department";
            // 
            // lblSampleID
            // 
            resources.ApplyResources(this.lblSampleID, "lblSampleID");
            this.lblSampleID.Name = "lblSampleID";
            // 
            // LabTestingTesultsReportKeeper
            // 
            this.HeaderHeight = 130;
            this.Name = "LabTestingTesultsReportKeeper";
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SampleId.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit SampleId;
        private DevExpress.XtraEditors.SimpleButton SearchButton;
        private BaseControls.Filters.DepartmentAZLookupFilter Department;
        private DevExpress.XtraEditors.LabelControl lblSampleID;

    }
}