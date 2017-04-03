

namespace EIDSS.Reports.BaseControls.Keeper
{
    partial class BaseReportKeeper
    {

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DisposeMessageRendering();
            }
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseReportKeeper));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.ceUseArchiveData = new DevExpress.XtraEditors.CheckEdit();
            this.cbLanguage = new DevExpress.XtraEditors.LookUpEdit();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.grcTop = new DevExpress.XtraEditors.GroupControl();
            this.ShowReportTimer = new System.Windows.Forms.Timer(this.components);
            this.reportView1 = new EIDSS.Reports.BaseControls.ReportView();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLanguage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcTop)).BeginInit();
            this.grcTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.ceUseArchiveData);
            this.pnlSettings.Controls.Add(this.cbLanguage);
            this.pnlSettings.Controls.Add(this.lblLanguage);
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Name = "pnlSettings";
            // 
            // ceUseArchiveData
            // 
            resources.ApplyResources(this.ceUseArchiveData, "ceUseArchiveData");
            this.ceUseArchiveData.Name = "ceUseArchiveData";
            this.ceUseArchiveData.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("ceUseArchiveData.Properties.Appearance.Font")));
            this.ceUseArchiveData.Properties.Appearance.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceDisabled.Font = ((System.Drawing.Font)(resources.GetObject("ceUseArchiveData.Properties.AppearanceDisabled.Font")));
            this.ceUseArchiveData.Properties.AppearanceDisabled.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceFocused.Font = ((System.Drawing.Font)(resources.GetObject("ceUseArchiveData.Properties.AppearanceFocused.Font")));
            this.ceUseArchiveData.Properties.AppearanceFocused.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceReadOnly.Font = ((System.Drawing.Font)(resources.GetObject("ceUseArchiveData.Properties.AppearanceReadOnly.Font")));
            this.ceUseArchiveData.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.ceUseArchiveData.Properties.Caption = resources.GetString("ceUseArchiveData.Properties.Caption");
            this.ceUseArchiveData.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.ceUseArchiveData.Tag = "{alwayseditable}";
            this.ceUseArchiveData.CheckedChanged += new System.EventHandler(this.ceUseArchiveData_CheckedChanged);
            // 
            // cbLanguage
            // 
            resources.ApplyResources(this.cbLanguage, "cbLanguage");
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("cbLanguage.Properties.Appearance.Font")));
            this.cbLanguage.Properties.AppearanceDisabled.Font = ((System.Drawing.Font)(resources.GetObject("cbLanguage.Properties.AppearanceDisabled.Font")));
            this.cbLanguage.Properties.AppearanceDropDown.Font = ((System.Drawing.Font)(resources.GetObject("cbLanguage.Properties.AppearanceDropDown.Font")));
            this.cbLanguage.Properties.AppearanceDropDownHeader.Font = ((System.Drawing.Font)(resources.GetObject("cbLanguage.Properties.AppearanceDropDownHeader.Font")));
            this.cbLanguage.Properties.AppearanceFocused.Font = ((System.Drawing.Font)(resources.GetObject("cbLanguage.Properties.AppearanceFocused.Font")));
            this.cbLanguage.Properties.AppearanceReadOnly.Font = ((System.Drawing.Font)(resources.GetObject("cbLanguage.Properties.AppearanceReadOnly.Font")));
            resources.ApplyResources(serializableAppearanceObject2, "serializableAppearanceObject2");
            this.cbLanguage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbLanguage.Properties.Buttons"))), resources.GetString("cbLanguage.Properties.Buttons1"), ((int)(resources.GetObject("cbLanguage.Properties.Buttons2"))), ((bool)(resources.GetObject("cbLanguage.Properties.Buttons3"))), ((bool)(resources.GetObject("cbLanguage.Properties.Buttons4"))), ((bool)(resources.GetObject("cbLanguage.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("cbLanguage.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("cbLanguage.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, resources.GetString("cbLanguage.Properties.Buttons8"), ((object)(resources.GetObject("cbLanguage.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("cbLanguage.Properties.Buttons10"))), ((bool)(resources.GetObject("cbLanguage.Properties.Buttons11"))))});
            this.cbLanguage.Properties.NullText = resources.GetString("cbLanguage.Properties.NullText");
            this.cbLanguage.EditValueChanged += new System.EventHandler(this.cbLanguage_SelectedIndexChanged);
            this.cbLanguage.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.cbLanguage_EditValueChanging);
            // 
            // lblLanguage
            // 
            resources.ApplyResources(this.lblLanguage, "lblLanguage");
            this.lblLanguage.ForeColor = System.Drawing.Color.Black;
            this.lblLanguage.Name = "lblLanguage";
            // 
            // grcTop
            // 
            this.grcTop.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("grcTop.Appearance.Font")));
            this.grcTop.AppearanceCaption.Font = ((System.Drawing.Font)(resources.GetObject("grcTop.AppearanceCaption.Font")));
            this.grcTop.Controls.Add(this.pnlSettings);
            resources.ApplyResources(this.grcTop, "grcTop");
            this.grcTop.Name = "grcTop";
            // 
            // ShowReportTimer
            // 
            this.ShowReportTimer.Interval = 1000;
            this.ShowReportTimer.Tick += new System.EventHandler(this.ShowReportTimer_Tick);
            // 
            // reportView1
            // 
            resources.ApplyResources(this.reportView1, "reportView1");
            this.reportView1.Name = "reportView1";
            // 
            // BaseReportKeeper
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportView1);
            this.Controls.Add(this.grcTop);
            this.DoubleBuffered = true;
            this.Name = "BaseReportKeeper";
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLanguage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcTop)).EndInit();
            this.grcTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel pnlSettings;
        private ReportView reportView1;
        private System.Windows.Forms.Label lblLanguage;
        private DevExpress.XtraEditors.GroupControl grcTop;
        private DevExpress.XtraEditors.LookUpEdit cbLanguage;
        private System.Windows.Forms.Timer ShowReportTimer;
        private System.ComponentModel.IContainer components;
        protected DevExpress.XtraEditors.CheckEdit ceUseArchiveData;
    }
}