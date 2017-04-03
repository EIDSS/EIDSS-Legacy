using eidss.avr.PivotComponents;

namespace eidss.avr.PivotForm
{
    partial class PivotInfoDetailPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PivotInfoDetailPanel));
            this.grcMain = new DevExpress.XtraEditors.GroupControl();
            this.MainGroupControl = new DevExpress.XtraEditors.GroupControl();
            this.PublishValueLabel = new DevExpress.XtraEditors.LabelControl();
            this.PublishingStatusNameLabel = new DevExpress.XtraEditors.LabelControl();
            this.LayoutSettingsPanel = new DevExpress.XtraEditors.PanelControl();
            this.UseArchiveDataCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.ShareLayoutCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.QueryNamePanel = new DevExpress.XtraEditors.PanelControl();
            this.DataRefreshTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.DataRefreshLabel = new System.Windows.Forms.Label();
            this.NationalQueryNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.QueryNationalNameLabel = new System.Windows.Forms.Label();
            this.QueryDescriptionMemo = new DevExpress.XtraEditors.MemoEdit();
            this.QueryDescriptionLabel = new System.Windows.Forms.Label();
            this.LayoutNamesPanel = new DevExpress.XtraEditors.PanelControl();
            this.DefLayoutNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.LayoutDescriptionMemo = new DevExpress.XtraEditors.MemoEdit();
            this.LayoutDescriptionLabel = new System.Windows.Forms.Label();
            this.LayoutDefaultNameLabel = new System.Windows.Forms.Label();
            this.NationalLayoutNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.LayoutNationalNameLabel = new System.Windows.Forms.Label();
            this.UnpublishValueLabel = new DevExpress.XtraEditors.LabelControl();
            
            ((System.ComponentModel.ISupportInitialize)(this.grcMain)).BeginInit();
            this.grcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainGroupControl)).BeginInit();
            this.MainGroupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutSettingsPanel)).BeginInit();
            this.LayoutSettingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UseArchiveDataCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShareLayoutCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QueryNamePanel)).BeginInit();
            this.QueryNamePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataRefreshTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NationalQueryNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QueryDescriptionMemo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutNamesPanel)).BeginInit();
            this.LayoutNamesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DefLayoutNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutDescriptionMemo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NationalLayoutNameTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(PivotInfoDetailPanel), out resources);
            // Form Is Localizable: True
            // 
            // grcMain
            // 
            this.grcMain.Appearance.Options.UseFont = true;
            this.grcMain.AppearanceCaption.Options.UseFont = true;
            this.grcMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grcMain.Controls.Add(this.MainGroupControl);
            resources.ApplyResources(this.grcMain, "grcMain");
            this.grcMain.Name = "grcMain";
            this.grcMain.ShowCaption = false;
            // 
            // MainGroupControl
            // 
            this.MainGroupControl.Appearance.Options.UseFont = true;
            this.MainGroupControl.AppearanceCaption.Options.UseFont = true;
            this.MainGroupControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.MainGroupControl.Controls.Add(this.PublishValueLabel);
            this.MainGroupControl.Controls.Add(this.PublishingStatusNameLabel);
            this.MainGroupControl.Controls.Add(this.LayoutSettingsPanel);
            this.MainGroupControl.Controls.Add(this.QueryNamePanel);
            this.MainGroupControl.Controls.Add(this.LayoutNamesPanel);
            this.MainGroupControl.Controls.Add(this.UnpublishValueLabel);
            resources.ApplyResources(this.MainGroupControl, "MainGroupControl");
            this.MainGroupControl.Name = "MainGroupControl";
            this.MainGroupControl.ShowCaption = false;
            // 
            // PublishValueLabel
            // 
            resources.ApplyResources(this.PublishValueLabel, "PublishValueLabel");
            this.PublishValueLabel.Name = "PublishValueLabel";
            // 
            // PublishingStatusNameLabel
            // 
            resources.ApplyResources(this.PublishingStatusNameLabel, "PublishingStatusNameLabel");
            this.PublishingStatusNameLabel.Name = "PublishingStatusNameLabel";
            // 
            // LayoutSettingsPanel
            // 
            resources.ApplyResources(this.LayoutSettingsPanel, "LayoutSettingsPanel");
            this.LayoutSettingsPanel.Controls.Add(this.UseArchiveDataCheckEdit);
            this.LayoutSettingsPanel.Controls.Add(this.ShareLayoutCheckEdit);
            this.LayoutSettingsPanel.Name = "LayoutSettingsPanel";
            // 
            // UseArchiveDataCheckEdit
            // 
            resources.ApplyResources(this.UseArchiveDataCheckEdit, "UseArchiveDataCheckEdit");
            this.UseArchiveDataCheckEdit.Name = "UseArchiveDataCheckEdit";
            this.UseArchiveDataCheckEdit.Properties.Appearance.Options.UseFont = true;
            this.UseArchiveDataCheckEdit.Properties.AppearanceDisabled.Options.UseFont = true;
            this.UseArchiveDataCheckEdit.Properties.AppearanceFocused.Options.UseFont = true;
            this.UseArchiveDataCheckEdit.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.UseArchiveDataCheckEdit.Properties.Caption = resources.GetString("UseArchiveDataCheckEdit.Properties.Caption");
            this.UseArchiveDataCheckEdit.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.UseArchiveDataCheckEdit.Tag = "{alwayseditable}";
            this.UseArchiveDataCheckEdit.CheckedChanged += new System.EventHandler(this.UseArchiveDataCheckEdit_CheckedChanged);
            // 
            // ShareLayoutCheckEdit
            // 
            resources.ApplyResources(this.ShareLayoutCheckEdit, "ShareLayoutCheckEdit");
            this.ShareLayoutCheckEdit.Name = "ShareLayoutCheckEdit";
            this.ShareLayoutCheckEdit.Properties.Appearance.Options.UseFont = true;
            this.ShareLayoutCheckEdit.Properties.AppearanceDisabled.Options.UseFont = true;
            this.ShareLayoutCheckEdit.Properties.AppearanceFocused.Options.UseFont = true;
            this.ShareLayoutCheckEdit.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.ShareLayoutCheckEdit.Properties.Caption = resources.GetString("ShareLayoutCheckEdit.Properties.Caption");
            this.ShareLayoutCheckEdit.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.ShareLayoutCheckEdit.CheckedChanged += new System.EventHandler(this.ShareLayoutCheckEdit_CheckedChanged);
            // 
            // QueryNamePanel
            // 
            resources.ApplyResources(this.QueryNamePanel, "QueryNamePanel");
            this.QueryNamePanel.Controls.Add(this.DataRefreshTextEdit);
            this.QueryNamePanel.Controls.Add(this.DataRefreshLabel);
            this.QueryNamePanel.Controls.Add(this.NationalQueryNameTextEdit);
            this.QueryNamePanel.Controls.Add(this.QueryNationalNameLabel);
            this.QueryNamePanel.Controls.Add(this.QueryDescriptionMemo);
            this.QueryNamePanel.Controls.Add(this.QueryDescriptionLabel);
            this.QueryNamePanel.Name = "QueryNamePanel";
            // 
            // DataRefreshTextEdit
            // 
            resources.ApplyResources(this.DataRefreshTextEdit, "DataRefreshTextEdit");
            this.DataRefreshTextEdit.Name = "DataRefreshTextEdit";
            this.DataRefreshTextEdit.Properties.Appearance.Options.UseFont = true;
            this.DataRefreshTextEdit.Properties.AppearanceDisabled.Options.UseFont = true;
            this.DataRefreshTextEdit.Properties.AppearanceFocused.Options.UseFont = true;
            this.DataRefreshTextEdit.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.DataRefreshTextEdit.Tag = "";
            // 
            // DataRefreshLabel
            // 
            resources.ApplyResources(this.DataRefreshLabel, "DataRefreshLabel");
            this.DataRefreshLabel.Name = "DataRefreshLabel";
            // 
            // NationalQueryNameTextEdit
            // 
            resources.ApplyResources(this.NationalQueryNameTextEdit, "NationalQueryNameTextEdit");
            this.NationalQueryNameTextEdit.Name = "NationalQueryNameTextEdit";
            this.NationalQueryNameTextEdit.Properties.Appearance.Options.UseFont = true;
            this.NationalQueryNameTextEdit.Properties.AppearanceDisabled.Options.UseFont = true;
            this.NationalQueryNameTextEdit.Properties.AppearanceFocused.Options.UseFont = true;
            this.NationalQueryNameTextEdit.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.NationalQueryNameTextEdit.Tag = "";
            // 
            // QueryNationalNameLabel
            // 
            resources.ApplyResources(this.QueryNationalNameLabel, "QueryNationalNameLabel");
            this.QueryNationalNameLabel.Name = "QueryNationalNameLabel";
            // 
            // QueryDescriptionMemo
            // 
            resources.ApplyResources(this.QueryDescriptionMemo, "QueryDescriptionMemo");
            this.QueryDescriptionMemo.Name = "QueryDescriptionMemo";
            this.QueryDescriptionMemo.Properties.Appearance.Options.UseFont = true;
            this.QueryDescriptionMemo.Properties.AppearanceDisabled.Options.UseFont = true;
            this.QueryDescriptionMemo.Properties.AppearanceFocused.Options.UseFont = true;
            this.QueryDescriptionMemo.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.QueryDescriptionMemo.UseOptimizedRendering = true;
            // 
            // QueryDescriptionLabel
            // 
            resources.ApplyResources(this.QueryDescriptionLabel, "QueryDescriptionLabel");
            this.QueryDescriptionLabel.Name = "QueryDescriptionLabel";
            // 
            // LayoutNamesPanel
            // 
            resources.ApplyResources(this.LayoutNamesPanel, "LayoutNamesPanel");
            this.LayoutNamesPanel.Controls.Add(this.DefLayoutNameTextEdit);
            this.LayoutNamesPanel.Controls.Add(this.LayoutDescriptionMemo);
            this.LayoutNamesPanel.Controls.Add(this.LayoutDescriptionLabel);
            this.LayoutNamesPanel.Controls.Add(this.LayoutDefaultNameLabel);
            this.LayoutNamesPanel.Controls.Add(this.NationalLayoutNameTextEdit);
            this.LayoutNamesPanel.Controls.Add(this.LayoutNationalNameLabel);
            this.LayoutNamesPanel.Name = "LayoutNamesPanel";
            // 
            // DefLayoutNameTextEdit
            // 
            resources.ApplyResources(this.DefLayoutNameTextEdit, "DefLayoutNameTextEdit");
            this.DefLayoutNameTextEdit.Name = "DefLayoutNameTextEdit";
            this.DefLayoutNameTextEdit.Properties.Appearance.Options.UseFont = true;
            this.DefLayoutNameTextEdit.Properties.AppearanceDisabled.Options.UseFont = true;
            this.DefLayoutNameTextEdit.Properties.AppearanceFocused.Options.UseFont = true;
            this.DefLayoutNameTextEdit.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.DefLayoutNameTextEdit.Properties.MaxLength = 2000;
            this.DefLayoutNameTextEdit.Tag = "[en]{M}";
            // 
            // LayoutDescriptionMemo
            // 
            resources.ApplyResources(this.LayoutDescriptionMemo, "LayoutDescriptionMemo");
            this.LayoutDescriptionMemo.Name = "LayoutDescriptionMemo";
            this.LayoutDescriptionMemo.Properties.Appearance.Options.UseFont = true;
            this.LayoutDescriptionMemo.Properties.AppearanceDisabled.Options.UseFont = true;
            this.LayoutDescriptionMemo.Properties.AppearanceFocused.Options.UseFont = true;
            this.LayoutDescriptionMemo.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.LayoutDescriptionMemo.UseOptimizedRendering = true;
            // 
            // LayoutDescriptionLabel
            // 
            resources.ApplyResources(this.LayoutDescriptionLabel, "LayoutDescriptionLabel");
            this.LayoutDescriptionLabel.Name = "LayoutDescriptionLabel";
            // 
            // LayoutDefaultNameLabel
            // 
            resources.ApplyResources(this.LayoutDefaultNameLabel, "LayoutDefaultNameLabel");
            this.LayoutDefaultNameLabel.Name = "LayoutDefaultNameLabel";
            // 
            // NationalLayoutNameTextEdit
            // 
            resources.ApplyResources(this.NationalLayoutNameTextEdit, "NationalLayoutNameTextEdit");
            this.NationalLayoutNameTextEdit.Name = "NationalLayoutNameTextEdit";
            this.NationalLayoutNameTextEdit.Properties.Appearance.Options.UseFont = true;
            this.NationalLayoutNameTextEdit.Properties.AppearanceDisabled.Options.UseFont = true;
            this.NationalLayoutNameTextEdit.Properties.AppearanceFocused.Options.UseFont = true;
            this.NationalLayoutNameTextEdit.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.NationalLayoutNameTextEdit.Tag = "{M}";
            this.NationalLayoutNameTextEdit.EditValueChanged += new System.EventHandler(this.NationalLayoutNameTextEdit_EditValueChanged);
            // 
            // LayoutNationalNameLabel
            // 
            resources.ApplyResources(this.LayoutNationalNameLabel, "LayoutNationalNameLabel");
            this.LayoutNationalNameLabel.Name = "LayoutNationalNameLabel";
            // 
            // UnpublishValueLabel
            // 
            resources.ApplyResources(this.UnpublishValueLabel, "UnpublishValueLabel");
            this.UnpublishValueLabel.Name = "UnpublishValueLabel";
            // 
            // timerFixLayoutName
            // 
            
            // 
            // PivotInfoDetailPanel
            // 
            this.Appearance.Options.UseFont = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grcMain);
            this.DefaultFormState = System.Windows.Forms.FormWindowState.Normal;
            this.HelpTopicID = "AVR_Pivot_Table";
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "PivotInfoDetailPanel";
            this.Status = bv.common.win.FormStatus.Draft;
            ((System.ComponentModel.ISupportInitialize)(this.grcMain)).EndInit();
            this.grcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainGroupControl)).EndInit();
            this.MainGroupControl.ResumeLayout(false);
            this.MainGroupControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutSettingsPanel)).EndInit();
            this.LayoutSettingsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UseArchiveDataCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShareLayoutCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QueryNamePanel)).EndInit();
            this.QueryNamePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataRefreshTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NationalQueryNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QueryDescriptionMemo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutNamesPanel)).EndInit();
            this.LayoutNamesPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DefLayoutNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutDescriptionMemo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NationalLayoutNameTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grcMain;
        private DevExpress.XtraEditors.GroupControl MainGroupControl;
        private System.Windows.Forms.Label LayoutDefaultNameLabel;
        private DevExpress.XtraEditors.CheckEdit ShareLayoutCheckEdit;
        private DevExpress.XtraEditors.MemoEdit LayoutDescriptionMemo;
        private System.Windows.Forms.Label LayoutDescriptionLabel;
        private DevExpress.XtraEditors.TextEdit NationalLayoutNameTextEdit;
        private System.Windows.Forms.Label LayoutNationalNameLabel;
        
        private DevExpress.XtraEditors.CheckEdit UseArchiveDataCheckEdit;
        private DevExpress.XtraEditors.PanelControl LayoutNamesPanel;
        private DevExpress.XtraEditors.PanelControl LayoutSettingsPanel;
        private DevExpress.XtraEditors.PanelControl QueryNamePanel;
        private DevExpress.XtraEditors.MemoEdit QueryDescriptionMemo;
        private System.Windows.Forms.Label QueryDescriptionLabel;
        private DevExpress.XtraEditors.LabelControl PublishValueLabel;
        private DevExpress.XtraEditors.LabelControl PublishingStatusNameLabel;
        private DevExpress.XtraEditors.TextEdit NationalQueryNameTextEdit;
        private System.Windows.Forms.Label QueryNationalNameLabel;
        private DevExpress.XtraEditors.TextEdit DataRefreshTextEdit;
        private System.Windows.Forms.Label DataRefreshLabel;
        private DevExpress.XtraEditors.LabelControl UnpublishValueLabel;
        private DevExpress.XtraEditors.TextEdit DefLayoutNameTextEdit;
        
    }
}