namespace eidss.gis.Tools.ToolForms
{
    partial class BufZonesLayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BufZonesLayer));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textName = new DevExpress.XtraEditors.TextEdit();
            this.textDescription = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.comboPivot = new DevExpress.XtraEditors.ComboBoxEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboPivot.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.Name = "labelControl1";
            // 
            // textName
            // 
            resources.ApplyResources(this.textName, "textName");
            this.textName.Name = "textName";
            this.textName.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("textName.Properties.Appearance.BackColor")));
            this.textName.Properties.Appearance.BorderColor = ((System.Drawing.Color)(resources.GetObject("textName.Properties.Appearance.BorderColor")));
            this.textName.Properties.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("textName.Properties.Appearance.ForeColor")));
            this.textName.Properties.Appearance.Options.UseBackColor = true;
            this.textName.Properties.Appearance.Options.UseBorderColor = true;
            this.textName.Properties.Appearance.Options.UseForeColor = true;
            this.textName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            // 
            // textDescription
            // 
            resources.ApplyResources(this.textDescription, "textDescription");
            this.textDescription.Name = "textDescription";
            // 
            // labelControl2
            // 
            resources.ApplyResources(this.labelControl2, "labelControl2");
            this.labelControl2.Name = "labelControl2";
            // 
            // labelControl3
            // 
            resources.ApplyResources(this.labelControl3, "labelControl3");
            this.labelControl3.Name = "labelControl3";
            // 
            // comboPivot
            // 
            resources.ApplyResources(this.comboPivot, "comboPivot");
            this.comboPivot.Name = "comboPivot";
            this.comboPivot.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("comboPivot.Properties.Buttons"))))});
            this.comboPivot.Properties.Items.AddRange(new object[] {
            resources.GetString("comboPivot.Properties.Items"),
            resources.GetString("comboPivot.Properties.Items1"),
            resources.GetString("comboPivot.Properties.Items2"),
            resources.GetString("comboPivot.Properties.Items3"),
            resources.GetString("comboPivot.Properties.Items4")});
            // 
            // simpleButton1
            // 
            this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.simpleButton1, "simpleButton1");
            this.simpleButton1.Name = "simpleButton1";
            // 
            // simpleButton2
            // 
            this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.simpleButton2, "simpleButton2");
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // BufZonesLayer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.comboPivot);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.textDescription);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "BufZonesLayer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BufZonesLayer_FormClosing);
            this.Load += new System.EventHandler(this.BufZonesLayer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboPivot.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textName;
        private DevExpress.XtraEditors.TextEdit textDescription;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit comboPivot;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}