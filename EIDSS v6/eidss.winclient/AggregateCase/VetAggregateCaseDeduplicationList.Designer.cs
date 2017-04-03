namespace eidss.winclient.AggregateCase
{
    partial class VetAggregateCaseDeduplicationList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VetAggregateCaseDeduplicationList));
            this.SuspendLayout();
            // 
            // m_ListGridControl
            // 
            resources.ApplyResources(this.m_ListGridControl, "m_ListGridControl");
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(VetAggregateCaseDeduplicationList), out resources);
            // Form Is Localizable: True
            // 
            // VetAggregateCaseDeduplicationList
            // 
            resources.ApplyResources(this, "$this");
            this.Icon = global::eidss.winclient.Properties.Resources.vet_aggregate_action_deduplication_32x32;
            this.Name = "VetAggregateCaseDeduplicationList";
            this.ResumeLayout(false);

        }

        #endregion
    }
}
