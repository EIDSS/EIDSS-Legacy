namespace eidss.winclient.Lab
{
    partial class LaboratorySectionSetTestResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaboratorySectionSetTestResult));
            this.dtResultDate = new DevExpress.XtraEditors.DateEdit();
            this.lblDateResult = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dtResultDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtResultDate.Properties)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(LaboratorySectionSetTestResult), out resources);
            // Form Is Localizable: True
            // 
            // dtResultDate
            // 
            resources.ApplyResources(this.dtResultDate, "dtResultDate");
            this.dtResultDate.Name = "dtResultDate";
            this.dtResultDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("dtStartedDate.Properties.Buttons"))))});
            this.dtResultDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // lblDateResult
            // 
            this.lblDateResult.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblDateResult.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblDateResult, "lblDateResult");
            this.lblDateResult.Name = "lblDateResult";
            // 
            // LaboratorySectionSetTestResult
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtResultDate);
            this.Controls.Add(this.lblDateResult);
            this.FormID = "L44";
            this.HelpTopicID = "LabS_access_sample_linked";
            this.Icon = global::eidss.winclient.Properties.Resources.Sample_Accession__large_;
            this.Name = "LaboratorySectionSetTestResult";
            ((System.ComponentModel.ISupportInitialize)(this.dtResultDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtResultDate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dtResultDate;
        private DevExpress.XtraEditors.LabelControl lblDateResult;

    }
}
