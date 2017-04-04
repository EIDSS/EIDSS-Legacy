namespace eidss.winclient.BasicSyndromicSurveillance
{
    partial class BasicSyndromicSurveillanceListPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasicSyndromicSurveillanceListPanel));
            this.SuspendLayout();
            // 
            // m_ListGridControl
            // 
            this.m_ListGridControl.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.m_ListGridControl, "m_ListGridControl");
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(BasicSyndromicSurveillanceListPanel), out resources);
            // Form Is Localizable: True
            // 
            // BasicSyndromicSurveillanceListPanel
            // 
            this.Appearance.Options.UseFont = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Icon = global::eidss.winclient.Properties.Resources.bss_list_32x321;
            this.Name = "BasicSyndromicSurveillanceListPanel";
            this.ResumeLayout(false);

        }

        #endregion
    }
}
