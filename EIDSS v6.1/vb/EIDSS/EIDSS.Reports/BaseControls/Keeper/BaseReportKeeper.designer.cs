

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using bv.common.Resources;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using eidss.model.Reports.Common;
using eidss.model.Reports.OperationContext;

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
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.GenerateReportButton = new DevExpress.XtraEditors.SimpleButton();
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
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(BaseReportKeeper), out resources);
            // Form Is Localizable: True
            // 
            // pnlSettings
            // 
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Controls.Add(this.GenerateReportButton);
            this.pnlSettings.Controls.Add(this.ceUseArchiveData);
            this.pnlSettings.Controls.Add(this.cbLanguage);
            this.pnlSettings.Controls.Add(this.lblLanguage);
            this.pnlSettings.Name = "pnlSettings";
            // 
            // GenerateReportButton
            // 
            resources.ApplyResources(this.GenerateReportButton, "GenerateReportButton");
            this.GenerateReportButton.Name = "GenerateReportButton";
            this.GenerateReportButton.Click += new System.EventHandler(this.GenerateReportButton_Click);
            // 
            // ceUseArchiveData
            // 
            resources.ApplyResources(this.ceUseArchiveData, "ceUseArchiveData");
            this.ceUseArchiveData.Name = "ceUseArchiveData";
            this.ceUseArchiveData.Properties.AccessibleDescription = resources.GetString("ceUseArchiveData.Properties.AccessibleDescription");
            this.ceUseArchiveData.Properties.AccessibleName = resources.GetString("ceUseArchiveData.Properties.AccessibleName");
            this.ceUseArchiveData.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("ceUseArchiveData.Properties.Appearance.FontSizeDelta")));
            this.ceUseArchiveData.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("ceUseArchiveData.Properties.Appearance.FontStyleDelta")));
            this.ceUseArchiveData.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("ceUseArchiveData.Properties.Appearance.GradientMode")));
            this.ceUseArchiveData.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("ceUseArchiveData.Properties.Appearance.Image")));
            this.ceUseArchiveData.Properties.Appearance.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("ceUseArchiveData.Properties.AppearanceDisabled.FontSizeDelta")));
            this.ceUseArchiveData.Properties.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("ceUseArchiveData.Properties.AppearanceDisabled.FontStyleDelta")));
            this.ceUseArchiveData.Properties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("ceUseArchiveData.Properties.AppearanceDisabled.GradientMode")));
            this.ceUseArchiveData.Properties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("ceUseArchiveData.Properties.AppearanceDisabled.Image")));
            this.ceUseArchiveData.Properties.AppearanceDisabled.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceFocused.FontSizeDelta = ((int)(resources.GetObject("ceUseArchiveData.Properties.AppearanceFocused.FontSizeDelta")));
            this.ceUseArchiveData.Properties.AppearanceFocused.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("ceUseArchiveData.Properties.AppearanceFocused.FontStyleDelta")));
            this.ceUseArchiveData.Properties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("ceUseArchiveData.Properties.AppearanceFocused.GradientMode")));
            this.ceUseArchiveData.Properties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("ceUseArchiveData.Properties.AppearanceFocused.Image")));
            this.ceUseArchiveData.Properties.AppearanceFocused.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceReadOnly.FontSizeDelta = ((int)(resources.GetObject("ceUseArchiveData.Properties.AppearanceReadOnly.FontSizeDelta")));
            this.ceUseArchiveData.Properties.AppearanceReadOnly.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("ceUseArchiveData.Properties.AppearanceReadOnly.FontStyleDelta")));
            this.ceUseArchiveData.Properties.AppearanceReadOnly.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("ceUseArchiveData.Properties.AppearanceReadOnly.GradientMode")));
            this.ceUseArchiveData.Properties.AppearanceReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("ceUseArchiveData.Properties.AppearanceReadOnly.Image")));
            this.ceUseArchiveData.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AutoHeight = ((bool)(resources.GetObject("ceUseArchiveData.Properties.AutoHeight")));
            this.ceUseArchiveData.Properties.Caption = resources.GetString("ceUseArchiveData.Properties.Caption");
            this.ceUseArchiveData.Properties.DisplayValueChecked = resources.GetString("ceUseArchiveData.Properties.DisplayValueChecked");
            this.ceUseArchiveData.Properties.DisplayValueGrayed = resources.GetString("ceUseArchiveData.Properties.DisplayValueGrayed");
            this.ceUseArchiveData.Properties.DisplayValueUnchecked = resources.GetString("ceUseArchiveData.Properties.DisplayValueUnchecked");
            this.ceUseArchiveData.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.ceUseArchiveData.Tag = "{alwayseditable}";
            // 
            // cbLanguage
            // 
            resources.ApplyResources(this.cbLanguage, "cbLanguage");
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Properties.AccessibleDescription = resources.GetString("cbLanguage.Properties.AccessibleDescription");
            this.cbLanguage.Properties.AccessibleName = resources.GetString("cbLanguage.Properties.AccessibleName");
            this.cbLanguage.Properties.AutoHeight = ((bool)(resources.GetObject("cbLanguage.Properties.AutoHeight")));
            this.cbLanguage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbLanguage.Properties.Buttons"))))});
            this.cbLanguage.Properties.NullText = resources.GetString("cbLanguage.Properties.NullText");
            this.cbLanguage.Properties.NullValuePrompt = resources.GetString("cbLanguage.Properties.NullValuePrompt");
            this.cbLanguage.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cbLanguage.Properties.NullValuePromptShowForEmptyValue")));
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
            resources.ApplyResources(this.grcTop, "grcTop");
            this.grcTop.Controls.Add(this.pnlSettings);
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

        protected Panel pnlSettings;
        private ReportView reportView1;
        private Label lblLanguage;
        private GroupControl grcTop;
        private LookUpEdit cbLanguage;
        private Timer ShowReportTimer;
        private IContainer components;
        protected CheckEdit ceUseArchiveData;
        protected SimpleButton GenerateReportButton;
    }
}