namespace EIDSS.FlexibleForms.Components
{
    partial class Label
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
            this.mainLabel = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // mainLabel
            // 
            this.mainLabel.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.mainLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.mainLabel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.mainLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLabel.Location = new System.Drawing.Point(3, 3);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(144, 27);
            this.mainLabel.TabIndex = 0;
            this.mainLabel.Text = "labelControl1";
            // 
            // Label
            // 
            this.Controls.Add(this.mainLabel);
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "Label";
            this.ResumeLayout(false);

        }

        #endregion

        internal DevExpress.XtraEditors.LabelControl mainLabel;

    }
}
