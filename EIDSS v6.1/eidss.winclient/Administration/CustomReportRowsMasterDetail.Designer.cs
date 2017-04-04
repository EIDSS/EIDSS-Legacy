using eidss.model.Schema;

namespace eidss.winclient.Administration
{
    partial class CustomReportRowsMasterDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomReportRowsMasterDetail));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.leCustomReportType = new DevExpress.XtraEditors.LookUpEdit();
            this.lbl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.matrixDetail = new eidss.winclient.Administration.CustomReportRowsDetail();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leCustomReportType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(CustomReportRowsMasterDetail), out resources);
            // Form Is Localizable: True
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.leCustomReportType);
            this.panelControl1.Controls.Add(this.lbl1);
            resources.ApplyResources(this.panelControl1, "panelControl1");
            this.panelControl1.Name = "panelControl1";
            // 
            // leCustomReportType
            // 
            resources.ApplyResources(this.leCustomReportType, "leCustomReportType");
            this.leCustomReportType.Name = "leCustomReportType";
            this.leCustomReportType.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("leCustomReportType.Properties.Appearance.Font")));
            this.leCustomReportType.Properties.Appearance.Options.UseFont = true;
            this.leCustomReportType.Properties.AppearanceDisabled.Font = ((System.Drawing.Font)(resources.GetObject("leCustomReportType.Properties.AppearanceDisabled.Font")));
            this.leCustomReportType.Properties.AppearanceDisabled.Options.UseFont = true;
            this.leCustomReportType.Properties.AppearanceDropDown.Font = ((System.Drawing.Font)(resources.GetObject("leCustomReportType.Properties.AppearanceDropDown.Font")));
            this.leCustomReportType.Properties.AppearanceDropDown.Options.UseFont = true;
            this.leCustomReportType.Properties.AppearanceDropDownHeader.Font = ((System.Drawing.Font)(resources.GetObject("leCustomReportType.Properties.AppearanceDropDownHeader.Font")));
            this.leCustomReportType.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.leCustomReportType.Properties.AppearanceFocused.Font = ((System.Drawing.Font)(resources.GetObject("leCustomReportType.Properties.AppearanceFocused.Font")));
            this.leCustomReportType.Properties.AppearanceFocused.Options.UseFont = true;
            this.leCustomReportType.Properties.AppearanceReadOnly.Font = ((System.Drawing.Font)(resources.GetObject("leCustomReportType.Properties.AppearanceReadOnly.Font")));
            this.leCustomReportType.Properties.AppearanceReadOnly.Options.UseFont = true;
            serializableAppearanceObject1.Options.UseFont = true;
            this.leCustomReportType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("leCustomReportType.Properties.Buttons"))), resources.GetString("leCustomReportType.Properties.Buttons1"), ((int)(resources.GetObject("leCustomReportType.Properties.Buttons2"))), ((bool)(resources.GetObject("leCustomReportType.Properties.Buttons3"))), ((bool)(resources.GetObject("leCustomReportType.Properties.Buttons4"))), ((bool)(resources.GetObject("leCustomReportType.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("leCustomReportType.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("leCustomReportType.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, resources.GetString("leCustomReportType.Properties.Buttons8"), ((object)(resources.GetObject("leCustomReportType.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("leCustomReportType.Properties.Buttons10"))), ((bool)(resources.GetObject("leCustomReportType.Properties.Buttons11"))))});
            this.leCustomReportType.Properties.NullText = resources.GetString("leCustomReportType.Properties.NullText");
            // 
            // lbl1
            // 
            this.lbl1.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lbl1.Appearance.Font")));
            this.lbl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbl1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbl1, "lbl1");
            this.lbl1.Name = "lbl1";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.matrixDetail);
            resources.ApplyResources(this.panelControl2, "panelControl2");
            this.panelControl2.Name = "panelControl2";
            // 
            // matrixDetail
            // 
            resources.ApplyResources(this.matrixDetail, "matrixDetail");
            this.matrixDetail.FormID = "";
            this.matrixDetail.HelpTopicID = "";
            this.matrixDetail.Icon = null;
            this.matrixDetail.InlineMode = bv.winclient.BasePanel.InlineMode.UseNewRow;
            this.matrixDetail.Name = "matrixDetail";
            this.matrixDetail.Sizable = true;
            // 
            // CustomReportRowsMasterDetail
            // 
            this.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("CustomReportRowsMasterDetail.Appearance.Font")));
            this.Appearance.Options.UseFont = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Icon = global::eidss.winclient.Properties.Resources.Reference_Book__large__41_;
            this.Name = "CustomReportRowsMasterDetail";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.leCustomReportType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lbl1;
        private DevExpress.XtraEditors.LookUpEdit leCustomReportType;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private CustomReportRowsDetail matrixDetail;
    }
}
