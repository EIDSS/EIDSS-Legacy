namespace eidss.winclient.Lab
{
    partial class LaboratorySectionTransferOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaboratorySectionTransferOut));
            this.leSendToOffice = new DevExpress.XtraEditors.LookUpEdit();
            this.lbSentTo = new DevExpress.XtraEditors.LabelControl();
            this.lblDateSent = new DevExpress.XtraEditors.LabelControl();
            this.dtSentDate = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.leSendToOffice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSentDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSentDate.Properties)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(LaboratorySectionTransferOut), out resources);
            // Form Is Localizable: True
            // 
            // leSendToOffice
            // 
            resources.ApplyResources(this.leSendToOffice, "leSendToOffice");
            this.leSendToOffice.Name = "leSendToOffice";
            this.leSendToOffice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leSendToOffice.Properties.Buttons"))))});
            this.leSendToOffice.Properties.NullText = resources.GetString("leSendToOffice.Properties.NullText");
            // 
            // lbSentTo
            // 
            this.lbSentTo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lbSentTo.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbSentTo, "lbSentTo");
            this.lbSentTo.Name = "lbSentTo";
            // 
            // lblDateSent
            // 
            this.lblDateSent.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblDateSent.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblDateSent, "lblDateSent");
            this.lblDateSent.Name = "lblDateSent";
            // 
            // dtSentDate
            // 
            resources.ApplyResources(this.dtSentDate, "dtSentDate");
            this.dtSentDate.Name = "dtSentDate";
            this.dtSentDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("dtSentDate.Properties.Buttons"))))});
            this.dtSentDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // LaboratorySectionTransferOut
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtSentDate);
            this.Controls.Add(this.lblDateSent);
            this.Controls.Add(this.leSendToOffice);
            this.Controls.Add(this.lbSentTo);
            this.FormID = "L37";
            this.HelpTopicID = "lab_sample_out";
            this.Icon = global::eidss.winclient.Properties.Resources.Sample_Transfer_Journal__large_1;
            this.Name = "LaboratorySectionTransferOut";
            ((System.ComponentModel.ISupportInitialize)(this.leSendToOffice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSentDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSentDate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit leSendToOffice;
        private DevExpress.XtraEditors.LabelControl lbSentTo;
        private DevExpress.XtraEditors.LabelControl lblDateSent;
        private DevExpress.XtraEditors.DateEdit dtSentDate;
    }
}
