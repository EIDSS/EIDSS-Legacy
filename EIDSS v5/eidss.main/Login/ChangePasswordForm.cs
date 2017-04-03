using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using BLToolkit.Data;
using bv.common.Resources;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.winclient.Layout;
using eidss.model.Core;
using eidss.model.Core.Security;
using eidss.model.Resources;
using eidss.model.Enums;




namespace eidss.main.Login
{
    public partial class ChangePasswordForm : BvForm
    {


        public ChangePasswordForm()
        {


            InitializeComponent();
            HelpTopicId = "change_password";

            txtOrganization.Text = EidssUserContext.User.Organization;
            txtUserName.Text = EidssUserContext.User.LoginName;
            ActiveControl = txtPassword;


            btnOk.Text = BvMessages.Get("strOK_Id");
            btnCancel.Text = BvMessages.Get("strCancel_Id");

            char ch = txtPassword.Properties.PasswordChar;
            var field = new string(ch, 8);
            txtPassword.Properties.NullText = field;
            txtPassword.EditValue = null;
            txtNewPassword1.Properties.NullText = field;
            txtNewPassword1.EditValue = null;
            txtNewPassword2.Properties.NullText = field;
            txtNewPassword2.EditValue = null;
            LayoutCorrector.ApplySystemFont(this);
            LayoutCorrector.SetStyleController(txtOrganization, LayoutCorrector.MandatoryStyleController);
            LayoutCorrector.SetStyleController(txtNewPassword1, LayoutCorrector.MandatoryStyleController);
            LayoutCorrector.SetStyleController(txtNewPassword2, LayoutCorrector.MandatoryStyleController);
            LayoutCorrector.SetStyleController(txtPassword, LayoutCorrector.MandatoryStyleController);
            LayoutCorrector.SetStyleController(txtUserName, LayoutCorrector.MandatoryStyleController);
        }

        private static bool ChangePassword(EidssSecurityManager manager, string organization, string user, string currentPassword, string newPassword)
        {
            string errMessage;
            try
            {
                long resultCode = manager.ChangePassword(organization, user, currentPassword, newPassword);
                if (resultCode == 0)
                {
                    ErrorForm.ShowMessage("msgPasswordChanged", "Your password has been successfully changed");
                    return true;
                }
                errMessage = SecurityMessages.GetLoginErrorMessage(resultCode);
                ErrorForm.ShowWarning(errMessage, null);
            }
            catch (Exception ex)
            {
                if (SqlExceptionHandler.Handle(ex))
                    return false;
                if (ex is SqlException)
                    errMessage = SecurityMessages.GetDBErrorMessage((ex as SqlException).Number, null, null);
                else
                    errMessage = SecurityMessages.GetDBErrorMessage(0, null, null);
                ErrorForm.ShowErrorDirect(errMessage, ex);
            }
            return false;
        }

        private bool ValidateData()
        {
            if (!WinUtils.CheckMandatoryField(lbOrganization.Text, txtOrganization.Text))
                return false;
            if (!WinUtils.CheckMandatoryField(lbUserName.Text, txtUserName.Text))
                return false;
            if (!WinUtils.CheckMandatoryField(lbPassword.Text, txtPassword.EditValue))
                return false;
            if (!WinUtils.CheckMandatoryField(lbPassword1.Text, txtNewPassword1.EditValue))
                return false;
            if (!WinUtils.CheckMandatoryField(lbPassword2.Text, txtNewPassword2.EditValue))
                return false;
            return true;
        }

        public void btnOk_Click(Object sender, EventArgs e)
        {
            if (!ValidateData())
            {
                return;
            }

            if (txtNewPassword1.Text != txtNewPassword2.Text)
            {
                ErrorForm.ShowMessage("msgPasswordNotTheSame", "Confirm password is incorrect.");
                return;
            }

            var manager = new EidssSecurityManager();
            int minimumLength = manager.GetIntPolicyValue("intPasswordMinimalLength", 5);
            if (txtNewPassword1.Text.Length < minimumLength)
            {
                ErrorForm.ShowWarningFormat("msgPasswordTooShort", "Password should contain at least {0} characters", minimumLength);
                return;
            }

            if (!manager.ValidatePassword(txtNewPassword1.Text))
            {
                ErrorForm.ShowWarning(SecurityMessages.GetLoginErrorMessage(8));
                return;
            }

            if (ChangePassword(manager, txtOrganization.Text, txtUserName.Text, txtPassword.Text, txtNewPassword1.Text))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }


        public static void Register(Control parentControl)
        {
            if (BaseFormManager.ArchiveMode)
                return;
            MenuActionManager manager = MenuActionManager.Instance;
            new MenuAction(ShowMe, manager, manager.Security, "MenuChangePassword", 1000, false, (int)MenuIconsSmall.ChangePassword, -1) { Name = "btnChangePassword" };
        }

        public static void ShowMe()
        {
            var form = new ChangePasswordForm();
            BaseFormManager.ShowModal(form, null);
        }

    }
}
