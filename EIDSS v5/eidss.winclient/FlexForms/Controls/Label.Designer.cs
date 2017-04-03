namespace eidss.winclient.FlexForms.Controls
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

        #region Component Designer generated code

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
            this.mainLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.mainLabel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.mainLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLabel.Location = new System.Drawing.Point(0, 0);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(151, 29);
            this.mainLabel.TabIndex = 1;
            this.mainLabel.Text = "mainLabel";
            // 
            // Label
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainLabel);
            this.Name = "Label";
            this.Size = new System.Drawing.Size(151, 29);
            this.ResumeLayout(false);

        }

        #endregion

        internal DevExpress.XtraEditors.LabelControl mainLabel;

    }
}
