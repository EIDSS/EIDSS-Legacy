namespace eidss.winclient.Lab
{
    partial class LaboratorySectionGroupAccessionIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaboratorySectionGroupAccessionIn));
            this.lbCase = new DevExpress.XtraEditors.LabelControl();
            this.txtFieldBarcode = new DevExpress.XtraEditors.TextEdit();
            this.lblAddNote = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtFieldBarcode.Properties)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(LaboratorySectionGroupAccessionIn), out resources);
            // Form Is Localizable: True
            // 
            // lbCase
            // 
            this.lbCase.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lbCase.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbCase, "lbCase");
            this.lbCase.Name = "lbCase";
            // 
            // txtFieldBarcode
            // 
            resources.ApplyResources(this.txtFieldBarcode, "txtFieldBarcode");
            this.txtFieldBarcode.Name = "txtFieldBarcode";
            // 
            // lblAddNote
            // 
            this.lblAddNote.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblAddNote.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lblAddNote, "lblAddNote");
            this.lblAddNote.Name = "lblAddNote";
            // 
            // LaboratorySectionGroupAccessionIn
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblAddNote);
            this.Controls.Add(this.txtFieldBarcode);
            this.Controls.Add(this.lbCase);
            this.FormID = "L36";
            this.HelpTopicID = "labs_access_group";
            this.Icon = global::eidss.winclient.Properties.Resources.Sample_Accession__large_;
            this.Name = "LaboratorySectionGroupAccessionIn";
            ((System.ComponentModel.ISupportInitialize)(this.txtFieldBarcode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbCase;
        internal DevExpress.XtraEditors.TextEdit txtFieldBarcode;
        private DevExpress.XtraEditors.LabelControl lblAddNote;
    }
}
