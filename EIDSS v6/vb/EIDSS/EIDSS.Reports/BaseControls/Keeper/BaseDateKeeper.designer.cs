
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;

namespace EIDSS.Reports.BaseControls.Keeper
{
    partial class BaseDateKeeper
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseDateKeeper));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.spinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.cbMonth = new DevExpress.XtraEditors.LookUpEdit();
            this.cbMonthEnd = new DevExpress.XtraEditors.LookUpEdit();
            this.EndMonthLabel = new System.Windows.Forms.Label();
            this.StartMonthLabel = new System.Windows.Forms.Label();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMonthEnd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.StartMonthLabel);
            this.pnlSettings.Controls.Add(this.cbMonthEnd);
            this.pnlSettings.Controls.Add(this.EndMonthLabel);
            this.pnlSettings.Controls.Add(this.cbMonth);
            this.pnlSettings.Controls.Add(this.spinEdit);
            this.pnlSettings.Controls.Add(this.label2);
            this.pnlSettings.Controls.Add(this.label1);
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Controls.SetChildIndex(this.GenerateReportButton, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.label1, 0);
            this.pnlSettings.Controls.SetChildIndex(this.label2, 0);
            this.pnlSettings.Controls.SetChildIndex(this.spinEdit, 0);
            this.pnlSettings.Controls.SetChildIndex(this.cbMonth, 0);
            this.pnlSettings.Controls.SetChildIndex(this.EndMonthLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.cbMonthEnd, 0);
            this.pnlSettings.Controls.SetChildIndex(this.StartMonthLabel, 0);
            // 
            // ceUseArchiveData
            // 
            resources.ApplyResources(this.ceUseArchiveData, "ceUseArchiveData");
            this.ceUseArchiveData.Properties.Appearance.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceDisabled.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceFocused.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceReadOnly.Options.UseFont = true;
            // 
            // GenerateReportButton
            // 
            resources.ApplyResources(this.GenerateReportButton, "GenerateReportButton");
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(BaseDateKeeper), out resources);
            // Form Is Localizable: True
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Name = "label1";
            // 
            // spinEdit
            // 
            resources.ApplyResources(this.spinEdit, "spinEdit");
            this.spinEdit.Name = "spinEdit";
            this.spinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit.Properties.Mask.EditMask = resources.GetString("spinEdit.Properties.Mask.EditMask");
            this.spinEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("spinEdit.Properties.Mask.MaskType")));
            this.spinEdit.Properties.MaxValue = new decimal(new int[] {
            2030,
            0,
            0,
            0});
            this.spinEdit.Properties.MinValue = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // cbMonth
            // 
            resources.ApplyResources(this.cbMonth, "cbMonth");
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbMonth.Properties.Buttons")))),
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbMonth.Properties.Buttons1"))))});
            this.cbMonth.Properties.DropDownRows = 12;
            this.cbMonth.Properties.NullText = resources.GetString("cbMonth.Properties.NullText");
            this.cbMonth.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.cbMonth_ButtonClick);
            this.cbMonth.EditValueChanged += new System.EventHandler(this.cbMonth_EditValueChanged);
            this.cbMonth.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.cbMonth_EditValueChanging);
            // 
            // cbMonthEnd
            // 
            resources.ApplyResources(this.cbMonthEnd, "cbMonthEnd");
            this.cbMonthEnd.Name = "cbMonthEnd";
            this.cbMonthEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbMonthEnd.Properties.Buttons")))),
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbMonthEnd.Properties.Buttons1"))))});
            this.cbMonthEnd.Properties.DropDownRows = 12;
            this.cbMonthEnd.Properties.NullText = resources.GetString("cbMonthEnd.Properties.NullText");
            this.cbMonthEnd.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.cbMonth_ButtonClick);
            this.cbMonthEnd.EditValueChanged += new System.EventHandler(this.cbMonthEnd_EditValueChanged);
            // 
            // EndMonthLabel
            // 
            resources.ApplyResources(this.EndMonthLabel, "EndMonthLabel");
            this.EndMonthLabel.ForeColor = System.Drawing.Color.Black;
            this.EndMonthLabel.Name = "EndMonthLabel";
            // 
            // StartMonthLabel
            // 
            resources.ApplyResources(this.StartMonthLabel, "StartMonthLabel");
            this.StartMonthLabel.ForeColor = System.Drawing.Color.Black;
            this.StartMonthLabel.Name = "StartMonthLabel";
            // 
            // BaseDateKeeper
            // 
            resources.ApplyResources(this, "$this");
            this.HeaderHeight = 130;
            this.Name = "BaseDateKeeper";
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMonthEnd.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label2;
        private Label label1;
        private SpinEdit spinEdit;
        private LookUpEdit cbMonth;
        private LookUpEdit cbMonthEnd;
        private Label EndMonthLabel;
        private Label StartMonthLabel;
    }
}