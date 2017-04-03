namespace eidss.winclient.Administration
{
    partial class VectorTypeReferenceMasterDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VectorTypeReferenceMasterDetail));
            this.vectorTypeReferenceDetail1 = new eidss.winclient.Administration.VectorTypeReferenceDetail();
            this.SuspendLayout();
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(VectorTypeReferenceMasterDetail), out resources);
            // Form Is Localizable: True
            // 
            // vectorTypeReferenceDetail1
            // 
            resources.ApplyResources(this.vectorTypeReferenceDetail1, "vectorTypeReferenceDetail1");
            this.vectorTypeReferenceDetail1.DCManager = null;
            this.vectorTypeReferenceDetail1.EditByDoubleClick = false;
            this.vectorTypeReferenceDetail1.FormID = "";
            this.vectorTypeReferenceDetail1.HelpTopicID = "";
            this.vectorTypeReferenceDetail1.Icon = null;
            this.vectorTypeReferenceDetail1.InlineMode = bv.winclient.BasePanel.InlineMode.UseNewRow;
            this.vectorTypeReferenceDetail1.Name = "vectorTypeReferenceDetail1";
            this.vectorTypeReferenceDetail1.Sizable = true;
            // 
            // VectorTypeReferenceMasterDetail
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.vectorTypeReferenceDetail1);
            this.Icon = global::eidss.winclient.Properties.Resources.Reference_Book__large__41_;
            this.Name = "VectorTypeReferenceMasterDetail";
            this.Sizable = true;
            this.ResumeLayout(false);

        }

        #endregion

        private VectorTypeReferenceDetail vectorTypeReferenceDetail1;
    }
}
