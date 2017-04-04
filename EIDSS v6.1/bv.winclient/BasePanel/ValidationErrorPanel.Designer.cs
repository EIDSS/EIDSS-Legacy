namespace bv.winclient.BasePanel
{
    partial class ValidationErrorPanel
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
            this.lbErrorText = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // Form Is Localizable: False
            // 
            // lbErrorText
            // 
            this.lbErrorText.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lbErrorText.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lbErrorText.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbErrorText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbErrorText.Location = new System.Drawing.Point(0, 0);
            this.lbErrorText.Name = "lbErrorText";
            this.lbErrorText.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lbErrorText.Size = new System.Drawing.Size(718, 29);
            this.lbErrorText.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = global::bv.winclient.Properties.Resources.Close;
            this.pictureBox1.Location = new System.Drawing.Point(718, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ValidationErrorPanel
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbErrorText);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ValidationErrorPanel";
            this.Size = new System.Drawing.Size(739, 29);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbErrorText;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
