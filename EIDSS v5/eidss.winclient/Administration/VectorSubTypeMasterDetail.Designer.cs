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
            this.cbVectorType = new DevExpress.XtraEditors.LookUpEdit();
            this.lbVectorType = new DevExpress.XtraEditors.LabelControl();
            this.pnVectorSubTypes = new DevExpress.XtraEditors.GroupControl();
            this.vectorSubTypeDetail1 = new eidss.winclient.Administration.VectorSubTypeDetail();
            ((System.ComponentModel.ISupportInitialize)(this.cbVectorType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnVectorSubTypes)).BeginInit();
            this.pnVectorSubTypes.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbVectorType
            // 
            resources.ApplyResources(this.cbVectorType, "cbVectorType");
            this.cbVectorType.Name = "cbVectorType";
            this.cbVectorType.Properties.AccessibleDescription = resources.GetString("cbVectorType.Properties.AccessibleDescription");
            this.cbVectorType.Properties.AccessibleName = resources.GetString("cbVectorType.Properties.AccessibleName");
            this.cbVectorType.Properties.AutoHeight = ((bool)(resources.GetObject("cbVectorType.Properties.AutoHeight")));
            this.cbVectorType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbVectorType.Properties.Buttons"))))});
            this.cbVectorType.Properties.NullValuePrompt = resources.GetString("cbVectorType.Properties.NullValuePrompt");
            this.cbVectorType.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cbVectorType.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // lbVectorType
            // 
            resources.ApplyResources(this.lbVectorType, "lbVectorType");
            this.lbVectorType.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lbVectorType.Appearance.DisabledImage")));
            this.lbVectorType.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lbVectorType.Appearance.GradientMode")));
            this.lbVectorType.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lbVectorType.Appearance.HoverImage")));
            this.lbVectorType.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lbVectorType.Appearance.Image")));
            this.lbVectorType.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lbVectorType.Appearance.PressedImage")));
            this.lbVectorType.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbVectorType.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lbVectorType.Name = "lbVectorType";
            // 
            // pnVectorSubTypes
            // 
            resources.ApplyResources(this.pnVectorSubTypes, "pnVectorSubTypes");
            this.pnVectorSubTypes.Controls.Add(this.vectorSubTypeDetail1);
            this.pnVectorSubTypes.Name = "pnVectorSubTypes";
            // 
            // vectorSubTypeDetail1
            // 
            resources.ApplyResources(this.vectorSubTypeDetail1, "vectorSubTypeDetail1");
            this.vectorSubTypeDetail1.EditByDoubleClick = false;
            this.vectorSubTypeDetail1.FormID = "";
            this.vectorSubTypeDetail1.HelpTopicID = null;
            this.vectorSubTypeDetail1.Icon = null;
            this.vectorSubTypeDetail1.idfsVectorType = null;
            this.vectorSubTypeDetail1.InlineMode = bv.winclient.BasePanel.InlineMode.UseNewRow;
            this.vectorSubTypeDetail1.Name = "vectorSubTypeDetail1";
            this.vectorSubTypeDetail1.ReadOnly = false;
            this.vectorSubTypeDetail1.Sizable = true;
            // 
            // VectorSubTypeMasterDetail
            // 
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
