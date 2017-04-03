namespace eidss.winclient.AggregateCase
{
    partial class VetAggregateActionList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VetAggregateActionList));
            this.diagnosticText = new System.Windows.Forms.Label();
            this.prophylacticText = new System.Windows.Forms.Label();
            this.sanitaryText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_ListGridControl
            // 
            resources.ApplyResources(this.m_ListGridControl, "m_ListGridControl");
            // 
            // diagnosticText
            // 
            resources.ApplyResources(this.diagnosticText, "diagnosticText");
            this.diagnosticText.Name = "diagnosticText";
            // 
            // prophylacticText
            // 
            resources.ApplyResources(this.prophylacticText, "prophylacticText");
            this.prophylacticText.Name = "prophylacticText";
            // 
            // sanitaryText
            // 
            resources.ApplyResources(this.sanitaryText, "sanitaryText");
            this.sanitaryText.Name = "sanitaryText";
            // 
            // VetAggregateActionList
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sanitaryText);
            this.Controls.Add(this.prophylacticText);
            this.Controls.Add(this.diagnosticText);
            this.Icon = global::eidss.winclient.Properties.Resources.View_Vet_Aggregate_Action_Summary__large_;
            this.Name = "VetAggregateActionList";
            this.Controls.SetChildIndex(this.m_ListGridControl, 0);
            this.Controls.SetChildIndex(this.diagnosticText, 0);
            this.Controls.SetChildIndex(this.prophylacticText, 0);
            this.Controls.SetChildIndex(this.sanitaryText, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label diagnosticText;
        private System.Windows.Forms.Label prophylacticText;
        private System.Windows.Forms.Label sanitaryText;
    }
}
