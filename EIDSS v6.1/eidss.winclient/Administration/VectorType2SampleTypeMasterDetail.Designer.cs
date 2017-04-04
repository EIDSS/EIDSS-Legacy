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
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(VectorType2SampleTypeMasterDetail), out resources);
            // Form Is Localizable: True
            // 
            // cbVectorType
            // 
            resources.ApplyResources(this.cbVectorType, "cbVectorType");
            this.cbVectorType.Name = "cbVectorType";
            this.cbVectorType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbVectorType.Properties.Buttons"))))});
            // 
            // lbVectorType
            // 
            this.lbVectorType.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbVectorType.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.lbVectorType, "lbVectorType");
            this.lbVectorType.Name = "lbVectorType";
            // 
            // matrixDetail
            // 
            resources.ApplyResources(this.matrixDetail, "matrixDetail");
            this.matrixDetail.FormID = "";
            this.matrixDetail.HelpTopicID = "";
            this.matrixDetail.Icon = null;
            this.matrixDetail.idfsVectorType = null;
            this.matrixDetail.InlineMode = bv.winclient.BasePanel.InlineMode.UseNewRow;
            this.matrixDetail.Name = "matrixDetail";
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
