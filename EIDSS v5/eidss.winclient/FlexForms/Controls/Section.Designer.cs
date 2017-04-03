namespace eidss.winclient.FlexForms.Controls
{
    partial class Section
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
            this.LabelControlCaption = new DevExpress.XtraEditors.LabelControl();
            this.LabelControl = new DevExpress.XtraEditors.LabelControl();
            this.Splitter = new DevExpress.XtraEditors.SplitterControl();
            this.SuspendLayout();
            // 
            // LabelControlCaption
            // 
            this.LabelControlCaption.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(193)))), ((int)(((byte)(236)))));
            this.LabelControlCaption.Appearance.BorderColor = System.Drawing.Color.Gray;
            this.LabelControlCaption.Appearance.Options.UseBackColor = true;
            this.LabelControlCaption.Appearance.Options.UseBorderColor = true;
            this.LabelControlCaption.Appearance.Options.UseTextOptions = true;
            this.LabelControlCaption.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.LabelControlCaption.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.LabelControlCaption.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.LabelControlCaption.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.LabelControlCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelControlCaption.Location = new System.Drawing.Point(3, 3);
            this.LabelControlCaption.Name = "LabelControlCaption";
            this.LabelControlCaption.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelControlCaption.Size = new System.Drawing.Size(194, 23);
            this.LabelControlCaption.TabIndex = 6;
            // 
            // LabelControl
            // 
            this.LabelControl.Appearance.BorderColor = System.Drawing.Color.Gray;
            this.LabelControl.Appearance.Options.UseBorderColor = true;
            this.LabelControl.Appearance.Options.UseTextOptions = true;
            this.LabelControl.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.LabelControl.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.LabelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.LabelControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.LabelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelControl.Location = new System.Drawing.Point(3, 32);
            this.LabelControl.Name = "LabelControl";
            this.LabelControl.Size = new System.Drawing.Size(194, 165);
            this.LabelControl.TabIndex = 7;
            // 
            // splitter
            // 
            this.Splitter.Dock = System.Windows.Forms.DockStyle.Top;
            this.Splitter.Location = new System.Drawing.Point(3, 26);
            this.Splitter.Name = "Splitter";
            this.Splitter.Size = new System.Drawing.Size(194, 6);
            this.Splitter.TabIndex = 8;
            this.Splitter.TabStop = false;
            // 
            // Section
            // 
            this.Controls.Add(this.LabelControl);
            this.Controls.Add(this.Splitter);
            this.Controls.Add(this.LabelControlCaption);
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "Section";
            this.Size = new System.Drawing.Size(200, 200);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
