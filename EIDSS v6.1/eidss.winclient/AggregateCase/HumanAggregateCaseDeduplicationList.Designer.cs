namespace eidss.winclient.AggregateCase
{
    partial class HumanAggregateCaseDeduplicationList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HumanAggregateCaseDeduplicationList));
            this.SuspendLayout();
            // 
            // m_ListGridControl
            // 
            resources.ApplyResources(this.m_ListGridControl, "m_ListGridControl");
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(HumanAggregateCaseDeduplicationList), out resources);
            // Form Is Localizable: True
            // 
            // HumanAggregateCaseDeduplicationList
            // 
            resources.ApplyResources(this, "$this");
            this.Icon = global::eidss.winclient.Properties.Resources.human_aggregate_deduplication_32x32;
            this.InlineMode = bv.winclient.BasePanel.InlineMode.None;
            this.Name = "HumanAggregateCaseDeduplicationList";
            this.ResumeLayout(false);

        }

        #endregion
    }
}
