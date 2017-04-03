namespace eidss.winclient.Lab
{
    partial class SampleLogBookTabPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SampleLogBookTabPanel));
            this.tcLabBook = new DevExpress.XtraTab.XtraTabControl();
            this.tpSampleLogBook = new DevExpress.XtraTab.XtraTabPage();
            this.tpMyPreferences = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.tcLabBook)).BeginInit();
            this.tcLabBook.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcLabBook
            // 
            resources.ApplyResources(this.tcLabBook, "tcLabBook");
            this.tcLabBook.Name = "tcLabBook";
            this.tcLabBook.SelectedTabPage = this.tpSampleLogBook;
            this.tcLabBook.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpSampleLogBook,
            this.tpMyPreferences});
            this.tcLabBook.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControl1_SelectedPageChanged);
            // 
            // tpSampleLogBook
            // 
            resources.ApplyResources(this.tpSampleLogBook, "tpSampleLogBook");
            this.tpSampleLogBook.Name = "tpSampleLogBook";
            // 
            // tpMyPreferences
            // 
            resources.ApplyResources(this.tpMyPreferences, "tpMyPreferences");
            this.tpMyPreferences.Name = "tpMyPreferences";
            // 
            // SampleLogBookTabPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.tcLabBook);
            this.Name = "SampleLogBookTabPanel";
            ((System.ComponentModel.ISupportInitialize)(this.tcLabBook)).EndInit();
            this.tcLabBook.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tcLabBook;
        private DevExpress.XtraTab.XtraTabPage tpSampleLogBook;
        private DevExpress.XtraTab.XtraTabPage tpMyPreferences;
    }
}
