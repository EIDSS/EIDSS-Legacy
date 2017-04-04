namespace eidss.winclient.Lab
{
    partial class LaboratorySectionAmendTestResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaboratorySectionAmendTestResult));
            this.txtComment = new DevExpress.XtraEditors.TextEdit();
            this.lbReason = new DevExpress.XtraEditors.LabelControl();
            this.lbNewResult = new DevExpress.XtraEditors.LabelControl();
            this.leTestResult = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leTestResult.Properties)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(LaboratorySectionAmendTestResult), out resources);
            // Form Is Localizable: True
            // 
            // txtComment
            // 
            resources.ApplyResources(this.txtComment, "txtComment");
            this.txtComment.Name = "txtComment";
            // 
            // lbReason
            // 
            this.lbReason.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lbReason.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbReason, "lbReason");
            this.lbReason.Name = "lbReason";
            // 
            // lbNewResult
            // 
            this.lbNewResult.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lbNewResult.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbNewResult, "lbNewResult");
            this.lbNewResult.Name = "lbNewResult";
            // 
            // leTestResult
            // 
            resources.ApplyResources(this.leTestResult, "leTestResult");
            this.leTestResult.Name = "leTestResult";
            this.leTestResult.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leTestResult.Properties.Buttons"))))});
            this.leTestResult.Properties.NullText = resources.GetString("leTestResult.Properties.NullText");
            // 
            // LaboratorySectionAmendTestResult
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.leTestResult);
            this.Controls.Add(this.lbNewResult);
            this.Controls.Add(this.lbReason);
            this.Controls.Add(this.txtComment);
            this.FormID = "L23";
            this.Icon = global::eidss.winclient.Properties.Resources.Test_amend_32x32;
            this.Name = "LaboratorySectionAmendTestResult";
            ((System.ComponentModel.ISupportInitialize)(this.txtComment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leTestResult.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtComment;
        private DevExpress.XtraEditors.LabelControl lbReason;
        private DevExpress.XtraEditors.LabelControl lbNewResult;
        private DevExpress.XtraEditors.LookUpEdit leTestResult;
    }
}
