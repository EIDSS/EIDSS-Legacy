namespace eidss.winclient.FlexForms.Controls
{
    partial class Parameter
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
            this.m_LabelControl = new DevExpress.XtraEditors.LabelControl();
            this.m_Splitter = new DevExpress.XtraEditors.SplitterControl();
            this.m_TextMark = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // Form Is Localizable: False
            // 
            // m_LabelControl
            // 
            this.m_LabelControl.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.m_LabelControl.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.m_LabelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.m_LabelControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.m_LabelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_LabelControl.Location = new System.Drawing.Point(84, 0);
            this.m_LabelControl.Name = "m_LabelControl";
            this.m_LabelControl.Size = new System.Drawing.Size(104, 61);
            this.m_LabelControl.TabIndex = 7;
            // 
            // m_Splitter
            // 
            this.m_Splitter.Location = new System.Drawing.Point(79, 0);
            this.m_Splitter.Name = "m_Splitter";
            this.m_Splitter.Size = new System.Drawing.Size(5, 61);
            this.m_Splitter.TabIndex = 5;
            this.m_Splitter.TabStop = false;
            // 
            // m_TextMark
            // 
            this.m_TextMark.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.m_TextMark.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.m_TextMark.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.m_TextMark.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.m_TextMark.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_TextMark.Location = new System.Drawing.Point(0, 0);
            this.m_TextMark.Name = "m_TextMark";
            this.m_TextMark.Size = new System.Drawing.Size(79, 61);
            this.m_TextMark.TabIndex = 6;
            this.m_TextMark.Text = "labelControl1";
            // 
            // Parameter
            // 
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_LabelControl);
            this.Controls.Add(this.m_Splitter);
            this.Controls.Add(this.m_TextMark);
            this.Name = "Parameter";
            this.Size = new System.Drawing.Size(188, 61);
            this.ResumeLayout(false);

        }

        #endregion

        internal DevExpress.XtraEditors.LabelControl m_LabelControl;
        internal DevExpress.XtraEditors.SplitterControl m_Splitter;
        internal DevExpress.XtraEditors.LabelControl m_TextMark;
    }
}
