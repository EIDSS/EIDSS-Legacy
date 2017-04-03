
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(BaseDateKeeper));
            this.label2 = new Label();
            this.label1 = new Label();
            this.spinEdit = new SpinEdit();
            this.cbMonth = new LookUpEdit();
            this.cbMonthEnd = new LookUpEdit();
            this.EndMonthLabel = new Label();
            this.StartMonthLabel = new Label();
            this.pnlSettings.SuspendLayout();
            ((ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            ((ISupportInitialize)(this.spinEdit.Properties)).BeginInit();
            ((ISupportInitialize)(this.cbMonth.Properties)).BeginInit();
            ((ISupportInitialize)(this.cbMonthEnd.Properties)).BeginInit();
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
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = Color.Black;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = Color.Black;
            this.label1.Name = "label1";
            // 
            // spinEdit
            // 
            resources.ApplyResources(this.spinEdit, "spinEdit");
            this.spinEdit.Name = "spinEdit";
            this.spinEdit.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton()});
            this.spinEdit.Properties.Mask.EditMask = resources.GetString("spinEdit.Properties.Mask.EditMask");
            this.spinEdit.Properties.Mask.MaskType = ((MaskType)(resources.GetObject("spinEdit.Properties.Mask.MaskType")));
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
            this.spinEdit.EditValueChanged += new EventHandler(this.spinEdit_EditValueChanged);
            // 
            // cbMonth
            // 
            resources.ApplyResources(this.cbMonth, "cbMonth");
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(((ButtonPredefines)(resources.GetObject("cbMonth.Properties.Buttons")))),
            new EditorButton(((ButtonPredefines)(resources.GetObject("cbMonth.Properties.Buttons1"))))});
            this.cbMonth.Properties.DropDownRows = 12;
            this.cbMonth.Properties.NullText = resources.GetString("cbMonth.Properties.NullText");
            this.cbMonth.ButtonClick += new ButtonPressedEventHandler(this.cbMonth_ButtonClick);
            this.cbMonth.EditValueChanged += new EventHandler(this.cbMonth_EditValueChanged);
            // 
            // cbMonthEnd
            // 
            resources.ApplyResources(this.cbMonthEnd, "cbMonthEnd");
            this.cbMonthEnd.Name = "cbMonthEnd";
            this.cbMonthEnd.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(((ButtonPredefines)(resources.GetObject("cbMonthEnd.Properties.Buttons")))),
            new EditorButton(((ButtonPredefines)(resources.GetObject("cbMonthEnd.Properties.Buttons1"))))});
            this.cbMonthEnd.Properties.DropDownRows = 12;
            this.cbMonthEnd.Properties.NullText = resources.GetString("cbMonthEnd.Properties.NullText");
            this.cbMonthEnd.ButtonClick += new ButtonPressedEventHandler(this.cbMonth_ButtonClick);
            this.cbMonthEnd.EditValueChanged += new EventHandler(this.cbMonthEnd_EditValueChanged);
            // 
            // EndMonthLabel
            // 
            resources.ApplyResources(this.EndMonthLabel, "EndMonthLabel");
            this.EndMonthLabel.ForeColor = Color.Black;
            this.EndMonthLabel.Name = "EndMonthLabel";
            // 
            // StartMonthLabel
            // 
            resources.ApplyResources(this.StartMonthLabel, "StartMonthLabel");
            this.StartMonthLabel.ForeColor = Color.Black;
            this.StartMonthLabel.Name = "StartMonthLabel";
            // 
            // BaseDateKeeper
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "BaseDateKeeper";
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            ((ISupportInitialize)(this.spinEdit.Properties)).EndInit();
            ((ISupportInitialize)(this.cbMonth.Properties)).EndInit();
            ((ISupportInitialize)(this.cbMonthEnd.Properties)).EndInit();
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