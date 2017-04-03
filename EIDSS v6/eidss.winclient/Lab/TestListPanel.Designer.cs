namespace eidss.winclient.Lab
{
    partial class TestListPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestListPanel));
            this.SuspendLayout();
            // 
            // m_ListGridControl
            // 
            resources.ApplyResources(this.m_ListGridControl, "m_ListGridControl");
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(TestListPanel), out resources);
            // Form Is Localizable: True
            // 
            // TestListPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Icon = global::eidss.winclient.Properties.Resources.Test_Journal__large_;
            this.Name = "TestListPanel";
            this.ResumeLayout(false);

        }

        #endregion
    }
}
