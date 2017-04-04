namespace eidss.winclient.Lab
{
    partial class LaboratorySectionStartTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaboratorySectionStartTest));
            this.dtStartedDate = new DevExpress.XtraEditors.DateEdit();
            this.lblDateStarted = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartedDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartedDate.Properties)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(LaboratorySectionStartTest), out resources);
            // Form Is Localizable: True
            // 
            // dtStartedDate
            // 
            resources.ApplyResources(this.dtStartedDate, "dtStartedDate");
            this.dtStartedDate.Name = "dtStartedDate";
            this.dtStartedDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("dtStartedDate.Properties.Buttons"))))});
            this.dtStartedDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // lblDateStarted
            // 
            this.lblDateStarted.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblDateStarted.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblDateStarted, "lblDateStarted");
            this.lblDateStarted.Name = "lblDateStarted";
            // 
            // LaboratorySectionStartTest
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtStartedDate);
            this.Controls.Add(this.lblDateStarted);
            this.FormID = "L43";
            this.HelpTopicID = "LabS_access_sample_linked";
            this.Icon = global::eidss.winclient.Properties.Resources.Sample_Accession__large_;
            this.Name = "LaboratorySectionStartTest";
            ((System.ComponentModel.ISupportInitialize)(this.dtStartedDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartedDate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dtStartedDate;
        private DevExpress.XtraEditors.LabelControl lblDateStarted;

    }
}
