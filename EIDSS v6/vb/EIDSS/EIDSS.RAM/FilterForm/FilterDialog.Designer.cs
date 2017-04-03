namespace eidss.avr.FilterForm
{
    partial class FilterDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterDialog));
            this.filterControl = new eidss.avr.FilterForm.PivotFilterControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.ValidateButton = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // filterControl
            // 
            resources.ApplyResources(this.filterControl, "filterControl");
            this.filterControl.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.filterControl.HasChanges = false;
            this.filterControl.Name = "filterControl";
            this.filterControl.ObjectHACode = EIDSS.HACode.None;
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Name = "btnOK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            // 
            // ValidateButton
            // 
            resources.ApplyResources(this.ValidateButton, "ValidateButton");
            this.ValidateButton.Image = global::eidss.avr.Properties.Resources.validate2;
            this.ValidateButton.Name = "ValidateButton";
            this.ValidateButton.Click += new System.EventHandler(this.ValidateButton_Click);
            // 
            // FilterDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ValidateButton);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.filterControl);
            this.HelpTopicId = "Apply_filters";
            this.Name = "FilterDialog";
            this.ResumeLayout(false);

        }

        #endregion

        internal PivotFilterControl filterControl;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton ValidateButton;

    }
}