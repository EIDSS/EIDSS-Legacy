
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
            this.txtNewPassword2.Properties.AccessibleDescription = resources.GetString("txtNewPassword2.Properties.AccessibleDescription");
            this.txtNewPassword2.Properties.AccessibleName = resources.GetString("txtNewPassword2.Properties.AccessibleName");
            this.txtNewPassword2.Properties.AutoHeight = ((bool)(resources.GetObject("txtNewPassword2.Properties.AutoHeight")));
            this.txtNewPassword2.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtNewPassword2.Properties.Mask.AutoComplete")));
            this.txtNewPassword2.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtNewPassword2.Properties.Mask.BeepOnError")));
            this.txtNewPassword2.Properties.Mask.EditMask = resources.GetString("txtNewPassword2.Properties.Mask.EditMask");
            this.txtNewPassword2.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtNewPassword2.Properties.Mask.IgnoreMaskBlank")));
            this.txtNewPassword2.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtNewPassword2.Properties.Mask.MaskType")));
            this.txtNewPassword2.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtNewPassword2.Properties.Mask.PlaceHolder")));
            this.txtNewPassword2.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtNewPassword2.Properties.Mask.SaveLiteral")));
            this.txtNewPassword2.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtNewPassword2.Properties.Mask.ShowPlaceHolders")));
            this.txtNewPassword2.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtNewPassword2.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtNewPassword2.Properties.NullValuePrompt = resources.GetString("txtNewPassword2.Properties.NullValuePrompt");
            this.txtNewPassword2.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtNewPassword2.Properties.NullValuePromptShowForEmptyValue")));
            this.txtNewPassword2.Properties.PasswordChar = '*';
            this.txtNewPassword2.Tag = "{M}";
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
            this.txtNewPassword1.Properties.AccessibleDescription = resources.GetString("txtNewPassword1.Properties.AccessibleDescription");
            this.txtNewPassword1.Properties.AccessibleName = resources.GetString("txtNewPassword1.Properties.AccessibleName");
            this.txtNewPassword1.Properties.AutoHeight = ((bool)(resources.GetObject("txtNewPassword1.Properties.AutoHeight")));
            this.txtNewPassword1.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtNewPassword1.Properties.Mask.AutoComplete")));
            this.txtNewPassword1.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtNewPassword1.Properties.Mask.BeepOnError")));
            this.txtNewPassword1.Properties.Mask.EditMask = resources.GetString("txtNewPassword1.Properties.Mask.EditMask");
            this.txtNewPassword1.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtNewPassword1.Properties.Mask.IgnoreMaskBlank")));
            this.txtNewPassword1.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtNewPassword1.Properties.Mask.MaskType")));
            this.txtNewPassword1.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtNewPassword1.Properties.Mask.PlaceHolder")));
            this.txtNewPassword1.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtNewPassword1.Properties.Mask.SaveLiteral")));
            this.txtNewPassword1.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtNewPassword1.Properties.Mask.ShowPlaceHolders")));
            this.txtNewPassword1.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtNewPassword1.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtNewPassword1.Properties.NullValuePrompt = resources.GetString("txtNewPassword1.Properties.NullValuePrompt");
            this.txtNewPassword1.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtNewPassword1.Properties.NullValuePromptShowForEmptyValue")));
            this.txtNewPassword1.Properties.PasswordChar = '*';
            this.txtNewPassword1.Tag = "{M}";
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
            this.txtOrganization.Properties.AccessibleDescription = resources.GetString("txtOrganization.Properties.AccessibleDescription");
            this.txtOrganization.Properties.AccessibleName = resources.GetString("txtOrganization.Properties.AccessibleName");
            this.txtOrganization.Properties.AutoHeight = ((bool)(resources.GetObject("txtOrganization.Properties.AutoHeight")));
            this.txtOrganization.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtOrganization.Properties.Mask.AutoComplete")));
            this.txtOrganization.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtOrganization.Properties.Mask.BeepOnError")));
            this.txtOrganization.Properties.Mask.EditMask = resources.GetString("txtOrganization.Properties.Mask.EditMask");
            this.txtOrganization.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtOrganization.Properties.Mask.IgnoreMaskBlank")));
            this.txtOrganization.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtOrganization.Properties.Mask.MaskType")));
            this.txtOrganization.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtOrganization.Properties.Mask.PlaceHolder")));
            this.txtOrganization.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtOrganization.Properties.Mask.SaveLiteral")));
            this.txtOrganization.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtOrganization.Properties.Mask.ShowPlaceHolders")));
            this.txtOrganization.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtOrganization.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtOrganization.Properties.NullValuePrompt = resources.GetString("txtOrganization.Properties.NullValuePrompt");
            this.txtOrganization.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtOrganization.Properties.NullValuePromptShowForEmptyValue")));
            this.txtOrganization.Tag = "{M}";
            // 
            // txtUserName
            // 
            resources.ApplyResources(this.txtUserName, "txtUserName");
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.AccessibleDescription = resources.GetString("txtUserName.Properties.AccessibleDescription");
            this.txtUserName.Properties.AccessibleName = resources.GetString("txtUserName.Properties.AccessibleName");
            this.txtUserName.Properties.AutoHeight = ((bool)(resources.GetObject("txtUserName.Properties.AutoHeight")));
            this.txtUserName.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtUserName.Properties.Mask.AutoComplete")));
            this.txtUserName.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtUserName.Properties.Mask.BeepOnError")));
            this.txtUserName.Properties.Mask.EditMask = resources.GetString("txtUserName.Properties.Mask.EditMask");
            this.txtUserName.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtUserName.Properties.Mask.IgnoreMaskBlank")));
            this.txtUserName.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtUserName.Properties.Mask.MaskType")));
            this.txtUserName.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtUserName.Properties.Mask.PlaceHolder")));
            this.txtUserName.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtUserName.Properties.Mask.SaveLiteral")));
            this.txtUserName.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtUserName.Properties.Mask.ShowPlaceHolders")));
            this.txtUserName.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtUserName.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtUserName.Properties.NullValuePrompt = resources.GetString("txtUserName.Properties.NullValuePrompt");
            this.txtUserName.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtUserName.Properties.NullValuePromptShowForEmptyValue")));
            this.txtUserName.Tag = "{M}";
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
            this.txtPassword.Properties.AccessibleDescription = resources.GetString("txtPassword.Properties.AccessibleDescription");
            this.txtPassword.Properties.AccessibleName = resources.GetString("txtPassword.Properties.AccessibleName");
            this.txtPassword.Properties.AutoHeight = ((bool)(resources.GetObject("txtPassword.Properties.AutoHeight")));
            this.txtPassword.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtPassword.Properties.Mask.AutoComplete")));
            this.txtPassword.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtPassword.Properties.Mask.BeepOnError")));
            this.txtPassword.Properties.Mask.EditMask = resources.GetString("txtPassword.Properties.Mask.EditMask");
            this.txtPassword.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtPassword.Properties.Mask.IgnoreMaskBlank")));
            this.txtPassword.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtPassword.Properties.Mask.MaskType")));
            this.txtPassword.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtPassword.Properties.Mask.PlaceHolder")));
            this.txtPassword.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtPassword.Properties.Mask.SaveLiteral")));
            this.txtPassword.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtPassword.Properties.Mask.ShowPlaceHolders")));
            this.txtPassword.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtPassword.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtPassword.Properties.NullValuePrompt = resources.GetString("txtPassword.Properties.NullValuePrompt");
            this.txtPassword.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtPassword.Properties.NullValuePromptShowForEmptyValue")));
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Tag = "{M}";
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            // 
            // ChangePasswordForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
	}
	
}
