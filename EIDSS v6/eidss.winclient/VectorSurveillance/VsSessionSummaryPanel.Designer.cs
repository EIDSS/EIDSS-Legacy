namespace eidss.winclient.VectorSurveillance
{
    partial class VsSessionSummaryPanel
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
            this.DiagnosesContainer = new DevExpress.XtraEditors.PopupContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.DiagnosesContainer)).BeginInit();
            this.SuspendLayout();
            // 
            // m_ListGridControl
            // 
            this.m_ListGridControl.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.m_ListGridControl.Appearance.Options.UseFont = true;
            this.m_ListGridControl.Size = new System.Drawing.Size(1040, 489);
            // Form Is Localizable: False
            // 
            // DiagnosesContainer
            // 
            this.DiagnosesContainer.Location = new System.Drawing.Point(351, 66);
            this.DiagnosesContainer.Name = "DiagnosesContainer";
            this.DiagnosesContainer.Size = new System.Drawing.Size(339, 357);
            this.DiagnosesContainer.TabIndex = 32;
            // 
            // VsSessionSummaryPanel
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DiagnosesContainer);
            this.Name = "VsSessionSummaryPanel";
            this.Size = new System.Drawing.Size(1040, 489);
            this.Controls.SetChildIndex(this.m_ListGridControl, 0);
            this.Controls.SetChildIndex(this.DiagnosesContainer, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DiagnosesContainer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal DevExpress.XtraEditors.PopupContainerControl DiagnosesContainer;
    }
}
