namespace eidss.winclient.Administration
{
    partial class VectorType2SampleTypeMasterDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VectorType2SampleTypeMasterDetail));
            this.cbVectorType = new DevExpress.XtraEditors.LookUpEdit();
            this.lbVectorType = new DevExpress.XtraEditors.LabelControl();
            this.matrixDetail = new eidss.winclient.Administration.VectorType2SampleTypeDetail();
            ((System.ComponentModel.ISupportInitialize)(this.cbVectorType.Properties)).BeginInit();
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
            // matrixDetail
            // 
            resources.ApplyResources(this.matrixDetail, "matrixDetail");
            this.matrixDetail.EditByDoubleClick = false;
            this.matrixDetail.FormID = "";
            this.matrixDetail.HelpTopicID = null;
            this.matrixDetail.Icon = null;
            this.matrixDetail.idfsVectorType = null;
            this.matrixDetail.InlineMode = bv.winclient.BasePanel.InlineMode.UseNewRow;
            this.matrixDetail.Name = "matrixDetail";
            this.matrixDetail.ReadOnly = false;
            this.matrixDetail.Sizable = true;
            // 
            // VectorType2SampleTypeMasterDetail
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.matrixDetail);
            this.Controls.Add(this.lbVectorType);
            this.Controls.Add(this.cbVectorType);
            this.Icon = global::eidss.winclient.Properties.Resources.Reference_Matrix__large__46_;
            this.Name = "VectorType2SampleTypeMasterDetail";
            ((System.ComponentModel.ISupportInitialize)(this.cbVectorType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit cbVectorType;
        private DevExpress.XtraEditors.LabelControl lbVectorType;
        private VectorType2SampleTypeDetail matrixDetail;
    }
}
