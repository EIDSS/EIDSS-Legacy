namespace EIDSS.Reports.BaseControls.Keeper
{
    partial class BaseIntervalKeeper
    {
       

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseIntervalKeeper));
            this.lblStart = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.dtStart = new DevExpress.XtraEditors.DateEdit();
            this.dtEnd = new DevExpress.XtraEditors.DateEdit();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.dtEnd);
            this.pnlSettings.Controls.Add(this.dtStart);
            this.pnlSettings.Controls.Add(this.lblEnd);
            this.pnlSettings.Controls.Add(this.lblStart);
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Controls.SetChildIndex(this.GenerateReportButton, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.lblStart, 0);
            this.pnlSettings.Controls.SetChildIndex(this.lblEnd, 0);
            this.pnlSettings.Controls.SetChildIndex(this.dtStart, 0);
            this.pnlSettings.Controls.SetChildIndex(this.dtEnd, 0);
            // 
            // ceUseArchiveData
            // 
            resources.ApplyResources(this.ceUseArchiveData, "ceUseArchiveData");
            this.ceUseArchiveData.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("ceUseArchiveData.Properties.Appearance.Font")));
            this.ceUseArchiveData.Properties.Appearance.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceDisabled.Font = ((System.Drawing.Font)(resources.GetObject("ceUseArchiveData.Properties.AppearanceDisabled.Font")));
            this.ceUseArchiveData.Properties.AppearanceDisabled.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceFocused.Font = ((System.Drawing.Font)(resources.GetObject("ceUseArchiveData.Properties.AppearanceFocused.Font")));
            this.ceUseArchiveData.Properties.AppearanceFocused.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceReadOnly.Font = ((System.Drawing.Font)(resources.GetObject("ceUseArchiveData.Properties.AppearanceReadOnly.Font")));
            this.ceUseArchiveData.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.ceUseArchiveData.Properties.Caption = resources.GetString("ceUseArchiveData.Properties.Caption");
            // 
            // GenerateReportButton
            // 
            resources.ApplyResources(this.GenerateReportButton, "GenerateReportButton");
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(BaseIntervalKeeper), out resources);
            // Form Is Localizable: True
            // 
            // lblStart
            // 
            resources.ApplyResources(this.lblStart, "lblStart");
            this.lblStart.Name = "lblStart";
            // 
            // lblEnd
            // 
            resources.ApplyResources(this.lblEnd, "lblEnd");
            this.lblEnd.Name = "lblEnd";
            // 
            // dtStart
            // 
            resources.ApplyResources(this.dtStart, "dtStart");
            this.dtStart.Name = "dtStart";
            this.dtStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("dtStart.Properties.Buttons"))))});
            this.dtStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtStart.EditValueChanged += new System.EventHandler(this.dtStart_ValueChanged);
            // 
            // dtEnd
            // 
            resources.ApplyResources(this.dtEnd, "dtEnd");
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("dtEnd.Properties.Buttons"))))});
            this.dtEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtEnd.EditValueChanged += new System.EventHandler(this.dtEnd_ValueChanged);
            // 
            // BaseIntervalKeeper
            // 
            resources.ApplyResources(this, "$this");
            this.HeaderHeight = 130;
            this.Name = "BaseIntervalKeeper";
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label lblStart;
        protected System.Windows.Forms.Label lblEnd;
        protected DevExpress.XtraEditors.DateEdit dtStart;
        protected DevExpress.XtraEditors.DateEdit dtEnd;

    }
}