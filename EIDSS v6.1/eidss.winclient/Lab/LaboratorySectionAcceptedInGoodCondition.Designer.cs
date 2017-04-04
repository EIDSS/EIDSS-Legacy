namespace eidss.winclient.Lab
{
    partial class LaboratorySectionAcceptedInGoodCondition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaboratorySectionAcceptedInGoodCondition));
            this.dtAccessionDate = new DevExpress.XtraEditors.DateEdit();
            this.lblDateAccession = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dtAccessionDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtAccessionDate.Properties)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(LaboratorySectionAcceptedInGoodCondition), out resources);
            // Form Is Localizable: True
            // 
            // dtAccessionDate
            // 
            resources.ApplyResources(this.dtAccessionDate, "dtAccessionDate");
            this.dtAccessionDate.Name = "dtAccessionDate";
            this.dtAccessionDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("dtAccessionDate.Properties.Buttons"))))});
            this.dtAccessionDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // lblDateAccession
            // 
            this.lblDateAccession.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblDateAccession.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblDateAccession, "lblDateAccession");
            this.lblDateAccession.Name = "lblDateAccession";
            // 
            // LaboratorySectionAcceptedInGoodCondition
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtAccessionDate);
            this.Controls.Add(this.lblDateAccession);
            this.HelpTopicID = "LabS_access_sample_linked";
            this.Icon = global::eidss.winclient.Properties.Resources.Sample_Accession__large_;
            this.Name = "LaboratorySectionAcceptedInGoodCondition";
            ((System.ComponentModel.ISupportInitialize)(this.dtAccessionDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtAccessionDate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dtAccessionDate;
        private DevExpress.XtraEditors.LabelControl lblDateAccession;

    }
}
