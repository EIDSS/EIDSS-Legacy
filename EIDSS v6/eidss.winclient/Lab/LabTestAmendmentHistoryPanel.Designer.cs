namespace eidss.winclient.Lab
{
    partial class LabTestAmendmentHistoryPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabTestAmendmentHistoryPanel));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtOldResult = new DevExpress.XtraEditors.TextEdit();
            this.lbOriginalResult = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldResult.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // m_ListGridControl
            // 
            resources.ApplyResources(this.m_ListGridControl, "m_ListGridControl");
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(LabTestAmendmentHistoryPanel), out resources);
            // Form Is Localizable: True
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtOldResult);
            this.panelControl1.Controls.Add(this.lbOriginalResult);
            resources.ApplyResources(this.panelControl1, "panelControl1");
            this.panelControl1.Name = "panelControl1";
            // 
            // txtOldResult
            // 
            resources.ApplyResources(this.txtOldResult, "txtOldResult");
            this.txtOldResult.Name = "txtOldResult";
            // 
            // lbOriginalResult
            // 
            resources.ApplyResources(this.lbOriginalResult, "lbOriginalResult");
            this.lbOriginalResult.Name = "lbOriginalResult";
            // 
            // LabTestAmendmentHistoryPanel
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.panelControl1);
            this.FormID = "L24";
            this.Icon = global::eidss.winclient.Properties.Resources.Test_amend_32x32;
            this.Name = "LabTestAmendmentHistoryPanel";
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.m_ListGridControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtOldResult.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lbOriginalResult;
        private DevExpress.XtraEditors.TextEdit txtOldResult;
    }
}
