namespace eidss.gis.Tools.ToolForms
{
    partial class AdminUnitMaskForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminUnitMaskForm));
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.checkUseMask = new DevExpress.XtraEditors.CheckEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lookUpEdit_Ryn = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEdit_Cnt = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEdit_Reg = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.checkUseMask.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Ryn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Cnt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Reg.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            resources.ApplyResources(this.simpleButton1, "simpleButton1");
            this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButton1.Name = "simpleButton1";
            // 
            // simpleButton2
            // 
            resources.ApplyResources(this.simpleButton2, "simpleButton2");
            this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.simpleButton2.Name = "simpleButton2";
            // 
            // checkUseMask
            // 
            resources.ApplyResources(this.checkUseMask, "checkUseMask");
            this.checkUseMask.Name = "checkUseMask";
            this.checkUseMask.Properties.AccessibleDescription = resources.GetString("checkUseMask.Properties.AccessibleDescription");
            this.checkUseMask.Properties.AccessibleName = resources.GetString("checkUseMask.Properties.AccessibleName");
            this.checkUseMask.Properties.AutoHeight = ((bool)(resources.GetObject("checkUseMask.Properties.AutoHeight")));
            this.checkUseMask.Properties.Caption = resources.GetString("checkUseMask.Properties.Caption");
            this.checkUseMask.Properties.DisplayValueChecked = resources.GetString("checkUseMask.Properties.DisplayValueChecked");
            this.checkUseMask.Properties.DisplayValueGrayed = resources.GetString("checkUseMask.Properties.DisplayValueGrayed");
            this.checkUseMask.Properties.DisplayValueUnchecked = resources.GetString("checkUseMask.Properties.DisplayValueUnchecked");
            this.checkUseMask.CheckStateChanged += new System.EventHandler(this.checkEdit1_CheckStateChanged);
            // 
            // groupControl1
            // 
            resources.ApplyResources(this.groupControl1, "groupControl1");
            this.groupControl1.Controls.Add(this.lookUpEdit_Ryn);
            this.groupControl1.Controls.Add(this.lookUpEdit_Cnt);
            this.groupControl1.Controls.Add(this.lookUpEdit_Reg);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Name = "groupControl1";
            // 
            // lookUpEdit_Ryn
            // 
            resources.ApplyResources(this.lookUpEdit_Ryn, "lookUpEdit_Ryn");
            this.lookUpEdit_Ryn.Name = "lookUpEdit_Ryn";
            this.lookUpEdit_Ryn.Properties.AccessibleDescription = resources.GetString("lookUpEdit_Ryn.Properties.AccessibleDescription");
            this.lookUpEdit_Ryn.Properties.AccessibleName = resources.GetString("lookUpEdit_Ryn.Properties.AccessibleName");
            this.lookUpEdit_Ryn.Properties.AutoHeight = ((bool)(resources.GetObject("lookUpEdit_Ryn.Properties.AutoHeight")));
            this.lookUpEdit_Ryn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("lookUpEdit_Ryn.Properties.Buttons"))))});
            this.lookUpEdit_Ryn.Properties.NullText = resources.GetString("lookUpEdit_Ryn.Properties.NullText");
            this.lookUpEdit_Ryn.Properties.NullValuePrompt = resources.GetString("lookUpEdit_Ryn.Properties.NullValuePrompt");
            this.lookUpEdit_Ryn.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("lookUpEdit_Ryn.Properties.NullValuePromptShowForEmptyValue")));
            this.lookUpEdit_Ryn.Properties.ShowFooter = false;
            this.lookUpEdit_Ryn.Properties.ShowHeader = false;
            // 
            // lookUpEdit_Cnt
            // 
            resources.ApplyResources(this.lookUpEdit_Cnt, "lookUpEdit_Cnt");
            this.lookUpEdit_Cnt.Name = "lookUpEdit_Cnt";
            this.lookUpEdit_Cnt.Properties.AccessibleDescription = resources.GetString("lookUpEdit_Cnt.Properties.AccessibleDescription");
            this.lookUpEdit_Cnt.Properties.AccessibleName = resources.GetString("lookUpEdit_Cnt.Properties.AccessibleName");
            this.lookUpEdit_Cnt.Properties.AutoHeight = ((bool)(resources.GetObject("lookUpEdit_Cnt.Properties.AutoHeight")));
            this.lookUpEdit_Cnt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("lookUpEdit_Cnt.Properties.Buttons"))))});
            this.lookUpEdit_Cnt.Properties.NullText = resources.GetString("lookUpEdit_Cnt.Properties.NullText");
            this.lookUpEdit_Cnt.Properties.NullValuePrompt = resources.GetString("lookUpEdit_Cnt.Properties.NullValuePrompt");
            this.lookUpEdit_Cnt.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("lookUpEdit_Cnt.Properties.NullValuePromptShowForEmptyValue")));
            this.lookUpEdit_Cnt.Properties.ShowFooter = false;
            this.lookUpEdit_Cnt.Properties.ShowHeader = false;
            this.lookUpEdit_Cnt.EditValueChanged += new System.EventHandler(this.lookUpEdit_Cnt_EditValueChanged);
            // 
            // lookUpEdit_Reg
            // 
            resources.ApplyResources(this.lookUpEdit_Reg, "lookUpEdit_Reg");
            this.lookUpEdit_Reg.Name = "lookUpEdit_Reg";
            this.lookUpEdit_Reg.Properties.AccessibleDescription = resources.GetString("lookUpEdit_Reg.Properties.AccessibleDescription");
            this.lookUpEdit_Reg.Properties.AccessibleName = resources.GetString("lookUpEdit_Reg.Properties.AccessibleName");
            this.lookUpEdit_Reg.Properties.AutoHeight = ((bool)(resources.GetObject("lookUpEdit_Reg.Properties.AutoHeight")));
            this.lookUpEdit_Reg.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("lookUpEdit_Reg.Properties.Buttons"))))});
            this.lookUpEdit_Reg.Properties.NullText = resources.GetString("lookUpEdit_Reg.Properties.NullText");
            this.lookUpEdit_Reg.Properties.NullValuePrompt = resources.GetString("lookUpEdit_Reg.Properties.NullValuePrompt");
            this.lookUpEdit_Reg.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("lookUpEdit_Reg.Properties.NullValuePromptShowForEmptyValue")));
            this.lookUpEdit_Reg.Properties.ShowFooter = false;
            this.lookUpEdit_Reg.Properties.ShowHeader = false;
            this.lookUpEdit_Reg.EditValueChanged += new System.EventHandler(this.lookUpEdit_Reg_EditValueChanged);
            // 
            // labelControl3
            // 
            resources.ApplyResources(this.labelControl3, "labelControl3");
            this.labelControl3.Name = "labelControl3";
            // 
            // labelControl2
            // 
            resources.ApplyResources(this.labelControl2, "labelControl2");
            this.labelControl2.Name = "labelControl2";
            // 
            // labelControl1
            // 
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.Name = "labelControl1";
            // 
            // AdminUnitMaskForm
            // 
            resources.ApplyResources(this, "$this");
            this.Appearance.FontSizeDelta = ((int)(resources.GetObject("AdminUnitMaskForm.Appearance.FontSizeDelta")));
            this.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("AdminUnitMaskForm.Appearance.FontStyleDelta")));
            this.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("AdminUnitMaskForm.Appearance.GradientMode")));
            this.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("AdminUnitMaskForm.Appearance.Image")));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.checkUseMask);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AdminUnitMaskForm";
            this.Load += new System.EventHandler(this.AdminUnitMaskForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.checkUseMask.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Ryn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Cnt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Reg.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.CheckEdit checkUseMask;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_Reg;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_Ryn;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_Cnt;
    }
}