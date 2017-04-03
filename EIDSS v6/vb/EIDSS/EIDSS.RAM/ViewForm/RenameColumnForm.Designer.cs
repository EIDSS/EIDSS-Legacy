
namespace eidss.avr.ViewForm
{
    public partial class RenameColumnForm : DevExpress.XtraEditors.XtraForm
    {

        //Form overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        //Required by the Windows Form Designer
        private System.ComponentModel.Container components = null;

        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.lbInput = new DevExpress.XtraEditors.LabelControl();
            this.txtInput = new DevExpress.XtraEditors.TextEdit();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lbReference = new DevExpress.XtraEditors.LabelControl();
            this.txtReference = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInput.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReference.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbInput
            // 
            this.lbInput.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lbInput.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lbInput.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lbInput.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbInput.Location = new System.Drawing.Point(6, 48);
            this.lbInput.Name = "lbInput";
            this.lbInput.Size = new System.Drawing.Size(161, 17);
            this.lbInput.TabIndex = 0;
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Location = new System.Drawing.Point(169, 47);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(238, 20);
            this.txtInput.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(250, 73);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(332, 73);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            // 
            // lbReference
            // 
            this.lbReference.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lbReference.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lbReference.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lbReference.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbReference.Location = new System.Drawing.Point(6, 13);
            this.lbReference.Name = "lbReference";
            this.lbReference.Size = new System.Drawing.Size(161, 17);
            this.lbReference.TabIndex = 0;
            // 
            // txtReference
            // 
            this.txtReference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReference.Enabled = false;
            this.txtReference.Location = new System.Drawing.Point(169, 12);
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(238, 20);
            this.txtReference.TabIndex = 1;
            // 
            // RenameColumnForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(419, 105);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtReference);
            this.Controls.Add(this.lbReference);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lbInput);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "RenameColumnForm";
            ((System.ComponentModel.ISupportInitialize)(this.txtInput.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReference.Properties)).EndInit();
            this.ResumeLayout(false);

        }
        internal DevExpress.XtraEditors.LabelControl lbInput;
        internal DevExpress.XtraEditors.TextEdit txtInput;
        internal DevExpress.XtraEditors.SimpleButton btnOk;
        internal DevExpress.XtraEditors.SimpleButton btnCancel;
        internal DevExpress.XtraEditors.LabelControl lbReference;
        internal DevExpress.XtraEditors.TextEdit txtReference;
    }

}
