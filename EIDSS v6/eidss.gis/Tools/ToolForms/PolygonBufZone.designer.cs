namespace eidss.gis.Tools.ToolForms
{
    partial class PolygonBufZone
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PolygonBufZone));
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textDescription = new DevExpress.XtraEditors.TextEdit();
            this.textName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            resources.ApplyResources(this.labelControl2, "labelControl2");
            this.labelControl2.Name = "labelControl2";
            // 
            // textDescription
            // 
            resources.ApplyResources(this.textDescription, "textDescription");
            this.textDescription.Name = "textDescription";
            // 
            // textName
            // 
            resources.ApplyResources(this.textName, "textName");
            this.textName.Name = "textName";
            this.textName.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("textName.Properties.Appearance.BackColor")));
            this.textName.Properties.Appearance.BorderColor = ((System.Drawing.Color)(resources.GetObject("textName.Properties.Appearance.BorderColor")));
            this.textName.Properties.Appearance.Options.UseBackColor = true;
            this.textName.Properties.Appearance.Options.UseBorderColor = true;
            this.textName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            // 
            // labelControl1
            // 
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.Name = "labelControl1";
            // 
            // simpleButton2
            // 
            this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.simpleButton2, "simpleButton2");
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.simpleButton1, "simpleButton1");
            this.simpleButton1.Name = "simpleButton1";
            // 
            // PolygonBufZone
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.textDescription);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpTopicId = "AVR_in_Maps";
            this.Name = "PolygonBufZone";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PolygonBufZone_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.textDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit textDescription;
        private DevExpress.XtraEditors.TextEdit textName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}