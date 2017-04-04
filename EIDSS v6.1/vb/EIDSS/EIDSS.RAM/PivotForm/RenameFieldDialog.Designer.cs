namespace eidss.avr.PivotForm
{
    partial class RenameFieldDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RenameFieldDialog));
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.OriginalEnglishLabel = new DevExpress.XtraEditors.LabelControl();
            this.OriginalNationalLabel = new DevExpress.XtraEditors.LabelControl();
            this.NewEnglishLabel = new DevExpress.XtraEditors.LabelControl();
            this.NewNationalLabel = new DevExpress.XtraEditors.LabelControl();
            this.OriginalEnglishText = new DevExpress.XtraEditors.TextEdit();
            this.OriginalNationalText = new DevExpress.XtraEditors.TextEdit();
            this.NewEnglishText = new DevExpress.XtraEditors.TextEdit();
            this.NewNationalText = new DevExpress.XtraEditors.TextEdit();
            this.OriginalGroup = new DevExpress.XtraEditors.GroupControl();
            this.NewGroup = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalEnglishText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalNationalText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewEnglishText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewNationalText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalGroup)).BeginInit();
            this.OriginalGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NewGroup)).BeginInit();
            this.NewGroup.SuspendLayout();
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
            // OriginalEnglishLabel
            // 
            this.OriginalEnglishLabel.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.OriginalEnglishLabel, "OriginalEnglishLabel");
            this.OriginalEnglishLabel.Name = "OriginalEnglishLabel";
            // 
            // OriginalNationalLabel
            // 
            this.OriginalNationalLabel.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.OriginalNationalLabel, "OriginalNationalLabel");
            this.OriginalNationalLabel.Name = "OriginalNationalLabel";
            // 
            // NewEnglishLabel
            // 
            this.NewEnglishLabel.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.NewEnglishLabel, "NewEnglishLabel");
            this.NewEnglishLabel.Name = "NewEnglishLabel";
            // 
            // NewNationalLabel
            // 
            this.NewNationalLabel.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.NewNationalLabel, "NewNationalLabel");
            this.NewNationalLabel.Name = "NewNationalLabel";
            // 
            // OriginalEnglishText
            // 
            resources.ApplyResources(this.OriginalEnglishText, "OriginalEnglishText");
            this.OriginalEnglishText.Name = "OriginalEnglishText";
            this.OriginalEnglishText.Properties.ReadOnly = true;
            this.OriginalEnglishText.TabStop = false;
            // 
            // OriginalNationalText
            // 
            resources.ApplyResources(this.OriginalNationalText, "OriginalNationalText");
            this.OriginalNationalText.Name = "OriginalNationalText";
            this.OriginalNationalText.Properties.ReadOnly = true;
            this.OriginalNationalText.TabStop = false;
            // 
            // NewEnglishText
            // 
            resources.ApplyResources(this.NewEnglishText, "NewEnglishText");
            this.NewEnglishText.Name = "NewEnglishText";
            // 
            // NewNationalText
            // 
            resources.ApplyResources(this.NewNationalText, "NewNationalText");
            this.NewNationalText.Name = "NewNationalText";
            // 
            // OriginalGroup
            // 
            resources.ApplyResources(this.OriginalGroup, "OriginalGroup");
            this.OriginalGroup.Controls.Add(this.OriginalNationalText);
            this.OriginalGroup.Controls.Add(this.OriginalEnglishText);
            this.OriginalGroup.Controls.Add(this.OriginalEnglishLabel);
            this.OriginalGroup.Controls.Add(this.OriginalNationalLabel);
            this.OriginalGroup.Name = "OriginalGroup";
            // 
            // NewGroup
            // 
            resources.ApplyResources(this.NewGroup, "NewGroup");
            this.NewGroup.Controls.Add(this.NewNationalText);
            this.NewGroup.Controls.Add(this.NewEnglishText);
            this.NewGroup.Controls.Add(this.NewEnglishLabel);
            this.NewGroup.Controls.Add(this.NewNationalLabel);
            this.NewGroup.Name = "NewGroup";
            // 
            // RenameFieldDialog
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.NewGroup);
            this.Controls.Add(this.OriginalGroup);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "RenameFieldDialog";
            ((System.ComponentModel.ISupportInitialize)(this.OriginalEnglishText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalNationalText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewEnglishText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewNationalText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalGroup)).EndInit();
            this.OriginalGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NewGroup)).EndInit();
            this.NewGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl OriginalEnglishLabel;
        private DevExpress.XtraEditors.LabelControl OriginalNationalLabel;
        private DevExpress.XtraEditors.LabelControl NewEnglishLabel;
        private DevExpress.XtraEditors.LabelControl NewNationalLabel;
        private DevExpress.XtraEditors.TextEdit OriginalEnglishText;
        private DevExpress.XtraEditors.TextEdit OriginalNationalText;
        private DevExpress.XtraEditors.TextEdit NewEnglishText;
        private DevExpress.XtraEditors.TextEdit NewNationalText;
        private DevExpress.XtraEditors.GroupControl OriginalGroup;
        private DevExpress.XtraEditors.GroupControl NewGroup;
    }
}