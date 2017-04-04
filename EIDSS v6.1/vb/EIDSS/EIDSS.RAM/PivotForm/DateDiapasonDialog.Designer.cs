namespace eidss.avr.PivotForm
{
    partial class DateDiapasonDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DateDiapasonDialog));
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.DateFromLabel = new System.Windows.Forms.Label();
            this.DateToLabel = new System.Windows.Forms.Label();
            this.DateFromEdit = new DevExpress.XtraEditors.DateEdit();
            this.DateToEdit = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.DateFromEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateFromEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateToEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateToEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Name = "btnOK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // DateFromLabel
            // 
            resources.ApplyResources(this.DateFromLabel, "DateFromLabel");
            this.DateFromLabel.ForeColor = System.Drawing.Color.Black;
            this.DateFromLabel.Name = "DateFromLabel";
            // 
            // DateToLabel
            // 
            resources.ApplyResources(this.DateToLabel, "DateToLabel");
            this.DateToLabel.ForeColor = System.Drawing.Color.Black;
            this.DateToLabel.Name = "DateToLabel";
            // 
            // DateFromEdit
            // 
            resources.ApplyResources(this.DateFromEdit, "DateFromEdit");
            this.DateFromEdit.Name = "DateFromEdit";
            this.DateFromEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("DateFromEdit.Properties.Buttons"))))});
            this.DateFromEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("DateFromEdit.Properties.CalendarTimeProperties.Buttons"))))});
            this.DateFromEdit.EditValueChanged += new System.EventHandler(this.DateFromTo_EditValueChanged);
            // 
            // DateToEdit
            // 
            resources.ApplyResources(this.DateToEdit, "DateToEdit");
            this.DateToEdit.Name = "DateToEdit";
            this.DateToEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("DateToEdit.Properties.Buttons"))))});
            this.DateToEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("DateToEdit.Properties.CalendarTimeProperties.Buttons"))))});
            this.DateToEdit.EditValueChanged += new System.EventHandler(this.DateFromTo_EditValueChanged);
            // 
            // DateDiapasonDialog
            // 
            this.AcceptButton = this.btnOK;
            this.Appearance.Options.UseFont = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.DateToEdit);
            this.Controls.Add(this.DateFromEdit);
            this.Controls.Add(this.DateToLabel);
            this.Controls.Add(this.DateFromLabel);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "DateDiapasonDialog";
            ((System.ComponentModel.ISupportInitialize)(this.DateFromEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateFromEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateToEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateToEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.Label DateFromLabel;
        private System.Windows.Forms.Label DateToLabel;
        private DevExpress.XtraEditors.DateEdit DateFromEdit;
        private DevExpress.XtraEditors.DateEdit DateToEdit;
    }
}