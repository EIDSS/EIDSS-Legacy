namespace eidss.winclient.VectorSurveillance
{
    partial class CopyDialogWindow
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CopyDialogWindow));
            this.cbGeneralData = new DevExpress.XtraEditors.CheckEdit();
            this.lblPoolVectorID = new DevExpress.XtraEditors.LabelControl();
            this.cbSpecificData = new DevExpress.XtraEditors.CheckEdit();
            this.cbSamples = new DevExpress.XtraEditors.CheckEdit();
            this.cbFieldTests = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGeneralData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSpecificData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSamples.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFieldTests.Properties)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(CopyDialogWindow), out resources);
            // Form Is Localizable: True
            // 
            // cbGeneralData
            // 
            resources.ApplyResources(this.cbGeneralData, "cbGeneralData");
            this.cbGeneralData.Name = "cbGeneralData";
            this.cbGeneralData.Properties.Caption = resources.GetString("cbGeneralData.Properties.Caption");
            // 
            // lblPoolVectorID
            // 
            this.lblPoolVectorID.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblPoolVectorID.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblPoolVectorID, "lblPoolVectorID");
            this.lblPoolVectorID.Name = "lblPoolVectorID";
            // 
            // cbSpecificData
            // 
            resources.ApplyResources(this.cbSpecificData, "cbSpecificData");
            this.cbSpecificData.Name = "cbSpecificData";
            this.cbSpecificData.Properties.Caption = resources.GetString("cbSpecificData.Properties.Caption");
            // 
            // cbSamples
            // 
            resources.ApplyResources(this.cbSamples, "cbSamples");
            this.cbSamples.Name = "cbSamples";
            this.cbSamples.Properties.Caption = resources.GetString("cbSamples.Properties.Caption");
            this.cbSamples.CheckedChanged += new System.EventHandler(this.cbSamples_CheckedChanged);
            // 
            // cbFieldTests
            // 
            resources.ApplyResources(this.cbFieldTests, "cbFieldTests");
            this.cbFieldTests.Name = "cbFieldTests";
            this.cbFieldTests.Properties.Caption = resources.GetString("cbFieldTests.Properties.Caption");
            this.cbFieldTests.CheckedChanged += new System.EventHandler(this.cbFieldTests_CheckedChanged);
            // 
            // CopyDialogWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbFieldTests);
            this.Controls.Add(this.cbSamples);
            this.Controls.Add(this.cbSpecificData);
            this.Controls.Add(this.lblPoolVectorID);
            this.Controls.Add(this.cbGeneralData);
            this.Name = "CopyDialogWindow";
            ((System.ComponentModel.ISupportInitialize)(this.cbGeneralData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSpecificData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSamples.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFieldTests.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit cbGeneralData;
        private DevExpress.XtraEditors.LabelControl lblPoolVectorID;
        private DevExpress.XtraEditors.CheckEdit cbSpecificData;
        private DevExpress.XtraEditors.CheckEdit cbSamples;
        private DevExpress.XtraEditors.CheckEdit cbFieldTests;
    }
}
