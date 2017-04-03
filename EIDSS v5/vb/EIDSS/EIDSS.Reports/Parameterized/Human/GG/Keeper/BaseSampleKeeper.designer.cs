
namespace EIDSS.Reports.Parameterized.Human.GG.Keeper
{
    partial class BaseSampleKeeper
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseSampleKeeper));
            this.lblSampleID = new DevExpress.XtraEditors.LabelControl();
            this.lblLastName = new DevExpress.XtraEditors.LabelControl();
            this.lblFirstName = new DevExpress.XtraEditors.LabelControl();
            this.tbSampleId = new DevExpress.XtraEditors.TextEdit();
            this.tbLastName = new DevExpress.XtraEditors.TextEdit();
            this.tbFirstName = new DevExpress.XtraEditors.TextEdit();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSampleId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLastName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFirstName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.tbSampleId);
            this.pnlSettings.Controls.Add(this.tbFirstName);
            this.pnlSettings.Controls.Add(this.lblFirstName);
            this.pnlSettings.Controls.Add(this.lblLastName);
            this.pnlSettings.Controls.Add(this.tbLastName);
            this.pnlSettings.Controls.Add(this.lblSampleID);
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.lblSampleID, 0);
            this.pnlSettings.Controls.SetChildIndex(this.tbLastName, 0);
            this.pnlSettings.Controls.SetChildIndex(this.lblLastName, 0);
            this.pnlSettings.Controls.SetChildIndex(this.lblFirstName, 0);
            this.pnlSettings.Controls.SetChildIndex(this.tbFirstName, 0);
            this.pnlSettings.Controls.SetChildIndex(this.tbSampleId, 0);
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
            // lblSampleID
            // 
            resources.ApplyResources(this.lblSampleID, "lblSampleID");
            this.lblSampleID.Name = "lblSampleID";
            // 
            // lblLastName
            // 
            resources.ApplyResources(this.lblLastName, "lblLastName");
            this.lblLastName.Name = "lblLastName";
            // 
            // lblFirstName
            // 
            resources.ApplyResources(this.lblFirstName, "lblFirstName");
            this.lblFirstName.Name = "lblFirstName";
            // 
            // tbSampleId
            // 
            resources.ApplyResources(this.tbSampleId, "tbSampleId");
            this.tbSampleId.Name = "tbSampleId";
            
            this.tbSampleId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Filter_KeyDown);
            this.tbSampleId.Validated += new System.EventHandler(this.Filter_Validated);
            // 
            // tbLastName
            // 
            resources.ApplyResources(this.tbLastName, "tbLastName");
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Filter_KeyDown);
            this.tbLastName.Validated += new System.EventHandler(this.Filter_Validated);
            // 
            // tbFirstName
            // 
            resources.ApplyResources(this.tbFirstName, "tbFirstName");
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Filter_KeyDown);
            this.tbFirstName.Validated += new System.EventHandler(this.Filter_Validated);
            // 
            // BaseSampleKeeper
            // 
            resources.ApplyResources(this, "$this");
            this.HeaderHeight = 130;
            this.Name = "BaseSampleKeeper";
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSampleId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLastName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFirstName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit tbSampleId;
        private DevExpress.XtraEditors.TextEdit tbFirstName;
        private DevExpress.XtraEditors.LabelControl lblFirstName;
        private DevExpress.XtraEditors.LabelControl lblLastName;
        private DevExpress.XtraEditors.TextEdit tbLastName;
        private DevExpress.XtraEditors.LabelControl lblSampleID;

    }
}