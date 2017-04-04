
namespace eidss.main.Login
{
	public partial class ChangePasswordForm
		{
			
		//Inherits System.Windows.Forms.Form
		
		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
			{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
                base.Dispose(disposing); 
			}
		}
		
		//Required by the Windows Form Designer
		private System.ComponentModel.Container components = null;
		
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		//<System.Diagnostics.DebuggerStepThrough()> _
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePasswordForm));
            this.lbPassword2 = new System.Windows.Forms.Label();
            this.txtNewPassword2 = new DevExpress.XtraEditors.TextEdit();
            this.lbPassword1 = new System.Windows.Forms.Label();
            this.txtNewPassword1 = new DevExpress.XtraEditors.TextEdit();
            this.lbOrganization = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.txtOrganization = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.lbPassword = new System.Windows.Forms.Label();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lbCurrPassLng = new DevExpress.XtraEditors.LabelControl();
            this.lbLoginLng = new DevExpress.XtraEditors.LabelControl();
            this.lbConfNewPassLng = new DevExpress.XtraEditors.LabelControl();
            this.lbNewPassLng = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrganization.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbPassword2
            // 
            resources.ApplyResources(this.lbPassword2, "lbPassword2");
            this.lbPassword2.Name = "lbPassword2";
            // 
            // txtNewPassword2
            // 
            resources.ApplyResources(this.txtNewPassword2, "txtNewPassword2");
            this.txtNewPassword2.Name = "txtNewPassword2";
            this.txtNewPassword2.Properties.PasswordChar = '*';
            this.txtNewPassword2.Tag = "{M}";
            this.txtNewPassword2.Enter += new System.EventHandler(this.Control_Enter);
            this.txtNewPassword2.Leave += new System.EventHandler(this.Control_Leave);
            // 
            // lbPassword1
            // 
            resources.ApplyResources(this.lbPassword1, "lbPassword1");
            this.lbPassword1.Name = "lbPassword1";
            // 
            // txtNewPassword1
            // 
            resources.ApplyResources(this.txtNewPassword1, "txtNewPassword1");
            this.txtNewPassword1.Name = "txtNewPassword1";
            this.txtNewPassword1.Properties.PasswordChar = '*';
            this.txtNewPassword1.Tag = "{M}";
            this.txtNewPassword1.Enter += new System.EventHandler(this.Control_Enter);
            this.txtNewPassword1.Leave += new System.EventHandler(this.Control_Leave);
            // 
            // lbOrganization
            // 
            resources.ApplyResources(this.lbOrganization, "lbOrganization");
            this.lbOrganization.Name = "lbOrganization";
            // 
            // lbUserName
            // 
            resources.ApplyResources(this.lbUserName, "lbUserName");
            this.lbUserName.Name = "lbUserName";
            // 
            // txtOrganization
            // 
            resources.ApplyResources(this.txtOrganization, "txtOrganization");
            this.txtOrganization.Name = "txtOrganization";
            this.txtOrganization.Tag = "{R}";
            // 
            // txtUserName
            // 
            resources.ApplyResources(this.txtUserName, "txtUserName");
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Tag = "{M}";
            this.txtUserName.Enter += new System.EventHandler(this.Control_Enter);
            this.txtUserName.Leave += new System.EventHandler(this.Control_Leave);
            // 
            // lbPassword
            // 
            resources.ApplyResources(this.lbPassword, "lbPassword");
            this.lbPassword.Name = "lbPassword";
            // 
            // txtPassword
            // 
            resources.ApplyResources(this.txtPassword, "txtPassword");
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Tag = "{M}";
            this.txtPassword.Enter += new System.EventHandler(this.Control_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.Control_Leave);
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            // 
            // lbCurrPassLng
            // 
            this.lbCurrPassLng.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("lbCurrPassLng.Appearance.BackColor")));
            this.lbCurrPassLng.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lbCurrPassLng.Appearance.ForeColor")));
            this.lbCurrPassLng.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.lbCurrPassLng, "lbCurrPassLng");
            this.lbCurrPassLng.Name = "lbCurrPassLng";
            // 
            // lbLoginLng
            // 
            this.lbLoginLng.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("lbLoginLng.Appearance.BackColor")));
            this.lbLoginLng.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lbLoginLng.Appearance.ForeColor")));
            this.lbLoginLng.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.lbLoginLng, "lbLoginLng");
            this.lbLoginLng.Name = "lbLoginLng";
            // 
            // lbConfNewPassLng
            // 
            this.lbConfNewPassLng.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("lbConfNewPassLng.Appearance.BackColor")));
            this.lbConfNewPassLng.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lbConfNewPassLng.Appearance.ForeColor")));
            this.lbConfNewPassLng.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.lbConfNewPassLng, "lbConfNewPassLng");
            this.lbConfNewPassLng.Name = "lbConfNewPassLng";
            // 
            // lbNewPassLng
            // 
            this.lbNewPassLng.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("lbNewPassLng.Appearance.BackColor")));
            this.lbNewPassLng.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lbNewPassLng.Appearance.ForeColor")));
            this.lbNewPassLng.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.lbNewPassLng, "lbNewPassLng");
            this.lbNewPassLng.Name = "lbNewPassLng";
            // 
            // ChangePasswordForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbConfNewPassLng);
            this.Controls.Add(this.lbNewPassLng);
            this.Controls.Add(this.lbCurrPassLng);
            this.Controls.Add(this.lbLoginLng);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lbPassword1);
            this.Controls.Add(this.lbOrganization);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.txtOrganization);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtNewPassword1);
            this.Controls.Add(this.txtNewPassword2);
            this.Controls.Add(this.lbPassword2);
            this.Controls.Add(this.lbPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpTopicId = "Changing_Password";
            this.MaximizeBox = false;
            this.Name = "ChangePasswordForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrganization.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            this.ResumeLayout(false);

		}
		internal System.Windows.Forms.Label lbPassword2;
		internal DevExpress.XtraEditors.TextEdit txtNewPassword2;
		internal System.Windows.Forms.Label lbPassword1;
		internal DevExpress.XtraEditors.TextEdit txtNewPassword1;
		internal System.Windows.Forms.Label lbOrganization;
		internal System.Windows.Forms.Label lbUserName;
		protected internal DevExpress.XtraEditors.TextEdit txtOrganization;
		protected internal DevExpress.XtraEditors.TextEdit txtUserName;
		internal System.Windows.Forms.Label lbPassword;
		internal DevExpress.XtraEditors.TextEdit txtPassword;
		internal DevExpress.XtraEditors.SimpleButton btnOk;
		internal DevExpress.XtraEditors.SimpleButton btnCancel;
        internal DevExpress.XtraEditors.LabelControl lbCurrPassLng;
        internal DevExpress.XtraEditors.LabelControl lbLoginLng;
        internal DevExpress.XtraEditors.LabelControl lbConfNewPassLng;
        internal DevExpress.XtraEditors.LabelControl lbNewPassLng;
	}
	
}
