
namespace EIDSS.Tests.Reports
{
    partial class TestKeeper
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestKeeper));
            this.button1 = new System.Windows.Forms.Button();
            this.pnlSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.button1);
            this.pnlSettings.Controls.SetChildIndex(this.button1, 0);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TestKeeper
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "TestKeeper";
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;

    }
}