namespace eidss.winclient.Administration
{
    partial class VectorSubTypeMasterDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VectorSubTypeMasterDetail));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.cbVectorType = new DevExpress.XtraEditors.LookUpEdit();
            this.lbVectorType = new DevExpress.XtraEditors.LabelControl();
            this.pnVectorSubTypes = new DevExpress.XtraEditors.GroupControl();
            this.vectorSubTypeDetail1 = new eidss.winclient.Administration.VectorSubTypeDetail();
            ((System.ComponentModel.ISupportInitialize)(this.cbVectorType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnVectorSubTypes)).BeginInit();
            this.pnVectorSubTypes.SuspendLayout();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(VectorSubTypeMasterDetail), out resources);
            // Form Is Localizable: True
            // 
            // cbVectorType
            // 
            resources.ApplyResources(this.cbVectorType, "cbVectorType");
            this.cbVectorType.Name = "cbVectorType";
            this.cbVectorType.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("cbVectorType.Properties.Appearance.Font")));
            this.cbVectorType.Properties.AppearanceDisabled.Font = ((System.Drawing.Font)(resources.GetObject("cbVectorType.Properties.AppearanceDisabled.Font")));
            this.cbVectorType.Properties.AppearanceDropDown.Font = ((System.Drawing.Font)(resources.GetObject("cbVectorType.Properties.AppearanceDropDown.Font")));
            this.cbVectorType.Properties.AppearanceDropDownHeader.Font = ((System.Drawing.Font)(resources.GetObject("cbVectorType.Properties.AppearanceDropDownHeader.Font")));
            this.cbVectorType.Properties.AppearanceFocused.Font = ((System.Drawing.Font)(resources.GetObject("cbVectorType.Properties.AppearanceFocused.Font")));
            this.cbVectorType.Properties.AppearanceReadOnly.Font = ((System.Drawing.Font)(resources.GetObject("cbVectorType.Properties.AppearanceReadOnly.Font")));
            resources.ApplyResources(serializableAppearanceObject1, "serializableAppearanceObject1");
            this.cbVectorType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbVectorType.Properties.Buttons"))), resources.GetString("cbVectorType.Properties.Buttons1"), ((int)(resources.GetObject("cbVectorType.Properties.Buttons2"))), ((bool)(resources.GetObject("cbVectorType.Properties.Buttons3"))), ((bool)(resources.GetObject("cbVectorType.Properties.Buttons4"))), ((bool)(resources.GetObject("cbVectorType.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("cbVectorType.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("cbVectorType.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, resources.GetString("cbVectorType.Properties.Buttons8"), ((object)(resources.GetObject("cbVectorType.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("cbVectorType.Properties.Buttons10"))), ((bool)(resources.GetObject("cbVectorType.Properties.Buttons11"))))});
            // 
            // lbVectorType
            // 
            this.lbVectorType.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lbVectorType.Appearance.Font")));
            this.lbVectorType.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbVectorType.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbVectorType, "lbVectorType");
            this.lbVectorType.Name = "lbVectorType";
            // 
            // pnVectorSubTypes
            // 
            resources.ApplyResources(this.pnVectorSubTypes, "pnVectorSubTypes");
            this.pnVectorSubTypes.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("pnVectorSubTypes.Appearance.Font")));
            this.pnVectorSubTypes.AppearanceCaption.Font = ((System.Drawing.Font)(resources.GetObject("pnVectorSubTypes.AppearanceCaption.Font")));
            this.pnVectorSubTypes.Controls.Add(this.vectorSubTypeDetail1);
            this.pnVectorSubTypes.Name = "pnVectorSubTypes";
            // 
            // vectorSubTypeDetail1
            // 
            resources.ApplyResources(this.vectorSubTypeDetail1, "vectorSubTypeDetail1");
            this.vectorSubTypeDetail1.FormID = "";
            this.vectorSubTypeDetail1.HelpTopicID = "";
            this.vectorSubTypeDetail1.Icon = null;
            this.vectorSubTypeDetail1.idfsVectorType = null;
            this.vectorSubTypeDetail1.InlineMode = bv.winclient.BasePanel.InlineMode.UseNewRow;
            this.vectorSubTypeDetail1.Name = "vectorSubTypeDetail1";
            this.vectorSubTypeDetail1.Sizable = true;
            // 
            // VectorSubTypeMasterDetail
            // 
            this.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("VectorSubTypeMasterDetail.Appearance.Font")));
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnVectorSubTypes);
            this.Controls.Add(this.lbVectorType);
            this.Controls.Add(this.cbVectorType);
            this.Icon = global::eidss.winclient.Properties.Resources.Reference_Book__large__41_;
            this.Name = "VectorSubTypeMasterDetail";
            ((System.ComponentModel.ISupportInitialize)(this.cbVectorType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnVectorSubTypes)).EndInit();
            this.pnVectorSubTypes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit cbVectorType;
        private DevExpress.XtraEditors.LabelControl lbVectorType;
        private VectorSubTypeDetail vectorSubTypeDetail1;
        private DevExpress.XtraEditors.GroupControl pnVectorSubTypes;
    }
}
