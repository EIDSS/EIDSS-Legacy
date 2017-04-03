namespace eidss.winclient.VectorSurveillance
{
    partial class SessionToVectorTypeDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SessionToVectorTypeDetail));
            this.cbVectorTypes = new DevExpress.XtraEditors.CheckedListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.cbVectorTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // cbVectorTypes
            // 
            resources.ApplyResources(this.cbVectorTypes, "cbVectorTypes");
            this.cbVectorTypes.CheckOnClick = true;
            this.cbVectorTypes.Name = "cbVectorTypes";
            this.cbVectorTypes.ItemChecking += new DevExpress.XtraEditors.Controls.ItemCheckingEventHandler(this.OnVectorTypesItemChecking);
            // 
            // SessionToVectorTypeDetail
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbVectorTypes);
            this.Name = "SessionToVectorTypeDetail";
            ((System.ComponentModel.ISupportInitialize)(this.cbVectorTypes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckedListBoxControl cbVectorTypes;
    }
}
