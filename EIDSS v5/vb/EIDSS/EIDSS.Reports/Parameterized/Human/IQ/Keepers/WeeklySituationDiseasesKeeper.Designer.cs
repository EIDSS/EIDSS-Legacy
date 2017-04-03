﻿using EIDSS.Reports.Parameterized.Human.IQ.Filters;

namespace EIDSS.Reports.Parameterized.Human.IQ.Keepers
{
    partial class WeeklySituationDiseasesKeeper
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
            this.regionFilter = new EIDSS.Reports.Parameterized.Filters.RegionFilter();
            this.weekFilter = new EIDSS.Reports.Parameterized.Human.IQ.Filters.WeeklyFilter();
            this.rayonFilter = new EIDSS.Reports.Parameterized.Filters.RayonFilter();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.weekFilter);
            this.pnlSettings.Controls.Add(this.regionFilter);
            this.pnlSettings.Controls.Add(this.rayonFilter);
            this.pnlSettings.Controls.SetChildIndex(this.rayonFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.regionFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.weekFilter, 0);
            // 
            // ceUseArchiveData
            // 
            this.ceUseArchiveData.Location = new System.Drawing.Point(742, 27);
            this.ceUseArchiveData.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ceUseArchiveData.Properties.Appearance.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ceUseArchiveData.Properties.AppearanceDisabled.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ceUseArchiveData.Properties.AppearanceFocused.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ceUseArchiveData.Properties.AppearanceReadOnly.Options.UseFont = true;
            // 
            // regionFilter
            // 
            this.regionFilter.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.regionFilter.Appearance.Options.UseFont = true;
            this.regionFilter.Location = new System.Drawing.Point(555, 10);
            this.regionFilter.Name = "regionFilter";
            this.regionFilter.Size = new System.Drawing.Size(166, 39);
            this.regionFilter.TabIndex = 191;
            this.regionFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.SingleFilterEventArgs>(this.regionFilter_ValueChanged);
            // 
            // weekFilter
            // 
            this.weekFilter.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.weekFilter.Appearance.Options.UseFont = true;
            this.weekFilter.Location = new System.Drawing.Point(360, 10);
            this.weekFilter.Name = "weekFilter";
            this.weekFilter.Size = new System.Drawing.Size(166, 39);
            this.weekFilter.TabIndex = 192;
            this.weekFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.SingleFilterEventArgs>(this.weekFilter_ValueChanged);
            // 
            // rayonFilter
            // 
            this.rayonFilter.Appearance.Options.UseFont = true;
            this.rayonFilter.Location = new System.Drawing.Point(555, 0);
            this.rayonFilter.Name = "rayonFilter";
            this.rayonFilter.Size = new System.Drawing.Size(166, 39);
            this.rayonFilter.TabIndex = 193;
            this.rayonFilter.Visible = false;
            // 
            // WeeklySituationDiseasesKeeper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "WeeklySituationDiseasesKeeper";
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Parameterized.Filters.RegionFilter regionFilter;
        private WeeklyFilter weekFilter;
        private Parameterized.Filters.RayonFilter rayonFilter;
        
    }
}
