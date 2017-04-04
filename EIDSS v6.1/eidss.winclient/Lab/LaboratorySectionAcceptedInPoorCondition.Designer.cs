namespace eidss.winclient.Lab
{
    partial class LaboratorySectionAcceptedInPoorCondition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaboratorySectionAcceptedInPoorCondition));
            this.lbComment = new DevExpress.XtraEditors.LabelControl();
            this.txtComment = new DevExpress.XtraEditors.TextEdit();
            this.lbWarn = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment.Properties)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(LaboratorySectionAcceptedInPoorCondition), out resources);
            // Form Is Localizable: True
            // 
            // lbComment
            // 
            this.lbComment.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lbComment.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbComment, "lbComment");
            this.lbComment.Name = "lbComment";
            // 
            // txtComment
            // 
            resources.ApplyResources(this.txtComment, "txtComment");
            this.txtComment.Name = "txtComment";
            // 
            // lbWarn
            // 
            this.lbWarn.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lbWarn.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbWarn, "lbWarn");
            this.lbWarn.Name = "lbWarn";
            // 
            // LaboratorySectionAcceptedInPoorCondition
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbWarn);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.lbComment);
            this.FormID = "L29";
            this.HelpTopicID = "LabS_access_sample_linked";
            this.Icon = global::eidss.winclient.Properties.Resources.Sample_Accession__large_;
            this.Name = "LaboratorySectionAcceptedInPoorCondition";
            ((System.ComponentModel.ISupportInitialize)(this.txtComment.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbComment;
        private DevExpress.XtraEditors.TextEdit txtComment;
        private DevExpress.XtraEditors.LabelControl lbWarn;
    }
}
