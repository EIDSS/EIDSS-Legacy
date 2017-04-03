namespace bv.winclient.Layout
{
    partial class LayoutSimple
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
            this.panelCaption = new DevExpress.XtraEditors.PanelControl();
            this.CaptionLabel = new DevExpress.XtraEditors.LabelControl();
            this.FormIcon = new DevExpress.XtraEditors.PictureEdit();
            this.FormIDLabel = new DevExpress.XtraEditors.LabelControl();
            this.panelMain = new DevExpress.XtraEditors.PanelControl();
            this.panelBottom = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelCaption)).BeginInit();
            this.panelCaption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FormIcon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCaption
            // 
            this.panelCaption.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(117)))), ((int)(((byte)(181)))));
            this.panelCaption.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(200)))), ((int)(((byte)(237)))));
            this.panelCaption.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.panelCaption.Appearance.ForeColor = System.Drawing.Color.White;
            this.panelCaption.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panelCaption.Appearance.Options.UseBackColor = true;
            this.panelCaption.Appearance.Options.UseFont = true;
            this.panelCaption.Appearance.Options.UseForeColor = true;
            this.panelCaption.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelCaption.Controls.Add(this.CaptionLabel);
            this.panelCaption.Controls.Add(this.FormIcon);
            this.panelCaption.Controls.Add(this.FormIDLabel);
            this.panelCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption.Location = new System.Drawing.Point(0, 0);
            this.panelCaption.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.panelCaption.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelCaption.Name = "panelCaption";
            this.panelCaption.Size = new System.Drawing.Size(892, 40);
            this.panelCaption.TabIndex = 0;
            // 
            // CaptionLabel
            // 
            this.CaptionLabel.AllowHtmlString = true;
            this.CaptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CaptionLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CaptionLabel.Appearance.ForeColor = System.Drawing.Color.White;
            this.CaptionLabel.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.CaptionLabel.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.CaptionLabel.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.CaptionLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.CaptionLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CaptionLabel.LineColor = System.Drawing.Color.Transparent;
            this.CaptionLabel.Location = new System.Drawing.Point(46, 0);
            this.CaptionLabel.Name = "CaptionLabel";
            this.CaptionLabel.Size = new System.Drawing.Size(775, 40);
            this.CaptionLabel.TabIndex = 2;
            this.CaptionLabel.Tag = "FixFontSize";
            this.CaptionLabel.Text = "TEXT";
            // 
            // FormIcon
            // 
            this.FormIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.FormIcon.Location = new System.Drawing.Point(0, 0);
            this.FormIcon.Name = "FormIcon";
            this.FormIcon.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.FormIcon.Properties.Appearance.Options.UseBackColor = true;
            this.FormIcon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.FormIcon.Properties.NullText = " ";
            this.FormIcon.Size = new System.Drawing.Size(40, 40);
            this.FormIcon.TabIndex = 1;
            // 
            // FormIDLabel
            // 
            this.FormIDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FormIDLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.FormIDLabel.Appearance.ForeColor = System.Drawing.Color.White;
            this.FormIDLabel.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.FormIDLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.FormIDLabel.Location = new System.Drawing.Point(837, 4);
            this.FormIDLabel.Name = "FormIDLabel";
            this.FormIDLabel.Size = new System.Drawing.Size(55, 33);
            this.FormIDLabel.TabIndex = 0;
            this.FormIDLabel.Text = "F0X";
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 40);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(892, 465);
            this.panelMain.TabIndex = 1;
            // 
            // panelBottom
            // 
            this.panelBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 505);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(892, 42);
            this.panelBottom.TabIndex = 2;
            // 
            // LayoutSimple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelCaption);
            this.Name = "LayoutSimple";
            this.Size = new System.Drawing.Size(892, 547);
            ((System.ComponentModel.ISupportInitialize)(this.panelCaption)).EndInit();
            this.panelCaption.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FormIcon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelCaption;
        private DevExpress.XtraEditors.LabelControl FormIDLabel;
        private DevExpress.XtraEditors.PictureEdit FormIcon;
        internal DevExpress.XtraEditors.LabelControl CaptionLabel;
        protected DevExpress.XtraEditors.PanelControl panelMain;
        protected DevExpress.XtraEditors.PanelControl panelBottom;

    }
}
