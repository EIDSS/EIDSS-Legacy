namespace eidss.avr.QueryLayoutTree
{
    partial class RenameFolderDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RenameFolderDialog));
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.EnglishLabel = new DevExpress.XtraEditors.LabelControl();
            this.NationalLabel = new DevExpress.XtraEditors.LabelControl();
            this.EnglishText = new DevExpress.XtraEditors.TextEdit();
            this.NationalText = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.EnglishText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NationalText.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Name = "btnOK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // EnglishLabel
            // 
            this.EnglishLabel.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.EnglishLabel, "EnglishLabel");
            this.EnglishLabel.Name = "EnglishLabel";
            // 
            // NationalLabel
            // 
            this.NationalLabel.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.NationalLabel, "NationalLabel");
            this.NationalLabel.Name = "NationalLabel";
            // 
            // EnglishText
            // 
            resources.ApplyResources(this.EnglishText, "EnglishText");
            this.EnglishText.Name = "EnglishText";
            this.EnglishText.EditValueChanged += new System.EventHandler(this.EnglishText_EditValueChanged);
            this.EnglishText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EnglishText_KeyPress);
            // 
            // NationalText
            // 
            resources.ApplyResources(this.NationalText, "NationalText");
            this.NationalText.Name = "NationalText";
            // 
            // RenameFolderDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NationalText);
            this.Controls.Add(this.EnglishText);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.NationalLabel);
            this.Controls.Add(this.EnglishLabel);
            this.Controls.Add(this.btnOK);
            this.Name = "RenameFolderDialog";
            ((System.ComponentModel.ISupportInitialize)(this.EnglishText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NationalText.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraEditors.SimpleButton btnOK;
        protected DevExpress.XtraEditors.SimpleButton btnCancel;
        protected DevExpress.XtraEditors.LabelControl EnglishLabel;
        protected DevExpress.XtraEditors.LabelControl NationalLabel;
        protected DevExpress.XtraEditors.TextEdit EnglishText;
        protected DevExpress.XtraEditors.TextEdit NationalText;

    }
}