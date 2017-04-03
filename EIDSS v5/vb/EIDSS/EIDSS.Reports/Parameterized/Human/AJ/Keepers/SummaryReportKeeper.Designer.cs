using EIDSS.Reports.Parameterized.Human.AJ.Filters;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    partial class SummaryReportKeeper
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any m_Resources being used.
        /// </summary>
        /// <param name="disposing">true if managed m_Resources should be disposed; otherwise, false.</param>
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
            this.diagnosisFilter1 = new EIDSS.Reports.Parameterized.Human.AJ.Filters.DiagnosisFilter();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.diagnosisFilter1);
            this.pnlSettings.Size = new System.Drawing.Size(1012, 107);
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.diagnosisFilter1, 0);
            // 
            // ceUseArchiveData
            // 
            this.ceUseArchiveData.Location = new System.Drawing.Point(528, 27);
            this.ceUseArchiveData.Properties.Appearance.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceDisabled.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceFocused.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceReadOnly.Options.UseFont = true;
            // 
            // diagnosisFilter1
            // 
            this.diagnosisFilter1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.diagnosisFilter1.Appearance.Options.UseFont = true;
            this.diagnosisFilter1.Location = new System.Drawing.Point(31, 51);
            this.diagnosisFilter1.Matrix = EIDSS.Reports.BaseControls.Filters.MatrixType.None;
            this.diagnosisFilter1.Name = "diagnosisFilter1";
            this.diagnosisFilter1.Size = new System.Drawing.Size(452, 39);
            this.diagnosisFilter1.TabIndex = 183;
            this.diagnosisFilter1.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.MultiFilterEventArgs>(this.diagnosisFilter1_ValueChanged);
            // 
            // SummaryReportKeeper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.HeaderHeight = 130;
            this.Name = "SummaryReportKeeper";
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DiagnosisFilter diagnosisFilter1;
    }
}
