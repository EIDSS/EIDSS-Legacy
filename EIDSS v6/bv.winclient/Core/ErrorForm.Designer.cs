namespace bv.winclient.Core
{
    partial class ErrorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorForm));
            this.cmdSend = new System.Windows.Forms.Button();
            this.pnDetails = new System.Windows.Forms.Panel();
            this.txtFullErrorText = new DevExpress.XtraEditors.MemoEdit();
            this.lbErrorDetail = new System.Windows.Forms.Label();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbErrorText = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.btnYes = new System.Windows.Forms.Button();
            this.cmdDetail = new System.Windows.Forms.Button();
            this.cmdOk = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.pnDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullErrorText.Properties)).BeginInit();
            this.Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdSend
            // 
            resources.ApplyResources(this.cmdSend, "cmdSend");
            this.cmdSend.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdSend.Name = "cmdSend";
            // 
            // pnDetails
            // 
            this.pnDetails.Controls.Add(this.txtFullErrorText);
            this.pnDetails.Controls.Add(this.lbErrorDetail);
            resources.ApplyResources(this.pnDetails, "pnDetails");
            this.pnDetails.Name = "pnDetails";
            // 
            // txtFullErrorText
            // 
            resources.ApplyResources(this.txtFullErrorText, "txtFullErrorText");
            this.txtFullErrorText.Name = "txtFullErrorText";
            this.txtFullErrorText.UseOptimizedRendering = true;
            // 
            // lbErrorDetail
            // 
            resources.ApplyResources(this.lbErrorDetail, "lbErrorDetail");
            this.lbErrorDetail.Name = "lbErrorDetail";
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.PictureBox1);
            this.Panel3.Controls.Add(this.lbErrorText);
            resources.ApplyResources(this.Panel3, "Panel3");
            this.Panel3.Name = "Panel3";
            // 
            // PictureBox1
            // 
            resources.ApplyResources(this.PictureBox1, "PictureBox1");
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.TabStop = false;
            // 
            // lbErrorText
            // 
            resources.ApplyResources(this.lbErrorText, "lbErrorText");
            this.lbErrorText.Name = "lbErrorText";
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.btnYes);
            this.Panel1.Controls.Add(this.cmdSend);
            this.Panel1.Controls.Add(this.cmdDetail);
            this.Panel1.Controls.Add(this.cmdOk);
            this.Panel1.Controls.Add(this.btnNo);
            resources.ApplyResources(this.Panel1, "Panel1");
            this.Panel1.Name = "Panel1";
            // 
            // btnYes
            // 
            resources.ApplyResources(this.btnYes, "btnYes");
            this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnYes.Name = "btnYes";
            // 
            // cmdDetail
            // 
            resources.ApplyResources(this.cmdDetail, "cmdDetail");
            this.cmdDetail.Name = "cmdDetail";
            // 
            // cmdOk
            // 
            resources.ApplyResources(this.cmdOk, "cmdOk");
            this.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOk.Name = "cmdOk";
            // 
            // btnNo
            // 
            resources.ApplyResources(this.btnNo, "btnNo");
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNo.Name = "btnNo";
            // 
            // ErrorForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnDetails);
            this.Controls.Add(this.Panel3);
            this.Controls.Add(this.Panel1);
            this.Name = "ErrorForm";
            this.pnDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFullErrorText.Properties)).EndInit();
            this.Panel3.ResumeLayout(false);
            this.Panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button cmdSend;
        internal System.Windows.Forms.Panel pnDetails;
        internal DevExpress.XtraEditors.MemoEdit txtFullErrorText;
        internal System.Windows.Forms.Label lbErrorDetail;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.Label lbErrorText;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Button cmdDetail;
        internal System.Windows.Forms.Button cmdOk;
        internal System.Windows.Forms.Button btnYes;
        internal System.Windows.Forms.Button btnNo;
    }
}