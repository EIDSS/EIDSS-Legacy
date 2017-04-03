namespace eidss.gis.Forms
{
    partial class SaveMapForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveMapForm));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.mapEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.mapsListBox = new DevExpress.XtraEditors.ListBoxControl();
            this.cancelButton = new DevExpress.XtraEditors.SimpleButton();
            this.okButton = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.mapEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapsListBox)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.Name = "labelControl1";
            // 
            // mapEdit
            // 
            resources.ApplyResources(this.mapEdit, "mapEdit");
            this.mapEdit.Name = "mapEdit";
            this.mapEdit.TextChanged += new System.EventHandler(this.mapEdit_TextChanged);
            // 
            // labelControl2
            // 
            resources.ApplyResources(this.labelControl2, "labelControl2");
            this.labelControl2.Name = "labelControl2";
            // 
            // mapsListBox
            // 
            resources.ApplyResources(this.mapsListBox, "mapsListBox");
            this.mapsListBox.Name = "mapsListBox";
            this.mapsListBox.SelectedIndexChanged += new System.EventHandler(this.mapsListBox_SelectedIndexChanged);
            this.mapsListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mapsListBox_MouseDown);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.No;
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.Name = "okButton";
            // 
            // simpleButton1
            // 
            this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.Yes;
            resources.ApplyResources(this.simpleButton1, "simpleButton1");
            this.simpleButton1.Name = "simpleButton1";
            // 
            // SaveMapForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.mapsListBox);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.mapEdit);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpTopicId = "Maps_Configuration";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveMapForm";
            ((System.ComponentModel.ISupportInitialize)(this.mapEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapsListBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit mapEdit;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ListBoxControl mapsListBox;
        private DevExpress.XtraEditors.SimpleButton cancelButton;
        private DevExpress.XtraEditors.SimpleButton okButton;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}