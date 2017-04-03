namespace EIDSS.Reports.BaseControls.Filters
{
    partial class BaseLookupFilter
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any m_Resources being used.
        /// </summary>
        /// <param name="disposing">true if managed m_Resources should be disposed; otherwise, false.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseLookupFilter));
            this.LookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.lblLookupName = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.LookUp.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // LookUp
            // 
            resources.ApplyResources(this.LookUp, "LookUp");
            this.LookUp.Name = "LookUp";
            this.LookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("LookUp.Properties.Buttons")))),
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("LookUp.Properties.Buttons1"))))});
            this.LookUp.Properties.NullText = resources.GetString("LookUp.Properties.NullText");
            this.LookUp.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.LookUp_ButtonClick);
            this.LookUp.EditValueChanged += new System.EventHandler(this.LookupEditValueChanged);
            // 
            // lblLookupName
            // 
            resources.ApplyResources(this.lblLookupName, "lblLookupName");
            this.lblLookupName.Name = "lblLookupName";
            // 
            // BaseLookupFilter
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblLookupName);
            this.Controls.Add(this.LookUp);
            this.Name = "BaseLookupFilter";
            ((System.ComponentModel.ISupportInitialize)(this.LookUp.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit LookUp;
        protected DevExpress.XtraEditors.LabelControl lblLookupName;
    }
}