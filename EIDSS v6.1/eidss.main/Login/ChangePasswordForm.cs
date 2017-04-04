using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using bv.common.Core;
using bv.common.Resources;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.winclient.Layout;
using bv.winclient.Localization;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Schema;

namespace eidss.main.Login
{
    public partial class ChangePasswordForm : BvForm
    {
        public ChangePasswordForm()
        {
            InitializeComponent();

            ControlsLastLanguage = new Dictionary<Control, string>
                {
                    { txtUserName, "en" }
                    , { txtPassword, "en" }
                    , { txtNewPassword1, "en" }
                    , { txtNewPassword2, "en" }
                };

            HelpTopicId = "change_password";

            txtOrganization.Text = OrganizationLookup.OrganizationNational; 
            txtUserName.Text = EidssUserContext.User.LoginName;
            ActiveControl = txtPassword;

            btnOk.Text = BvMessages.Get("strOK_Id");
            btnCancel.Text = BvMessages.Get("strCancel_Id");

            var ch = txtPassword.Properties.PasswordChar;
            var field = new string(ch, 8);
            txtPassword.Properties.NullText = field;
            txtPassword.EditValue = null;
            txtNewPassword1.Properties.NullText = field;
            txtNewPassword1.EditValue = null;
            txtNewPassword2.Properties.NullText = field;
            txtNewPassword2.EditValue = null;
            LayoutCorrector.ApplySystemFont(this);
            LayoutCorrector.SetStyleController(txtOrganization, LayoutCorrector.ReadOnlyStyleController);
            txtOrganization.ReadOnly = true;
            LayoutCorrector.SetStyleController(txtNewPassword1, LayoutCorrector.MandatoryStyleController);
            LayoutCorrector.SetStyleController(txtNewPassword2, LayoutCorrector.MandatoryStyleController);
            LayoutCorrector.SetStyleController(txtPassword, LayoutCorrector.MandatoryStyleController);
            LayoutCorrector.SetStyleController(txtUserName, LayoutCorrector.ReadOnlyStyleController);
            txtUserName.ReadOnly = true;
            
            Application.Idle += UpdateLangIndicators;
        }

        private bool ValidateData()
        {
            //if (!WinUtils.CheckMandatoryField(lbOrganization.Text, txtOrganization.Text))
            //    return false;
            //if (!WinUtils.CheckMandatoryField(lbUserName.Text, txtUserName.Text))
            //    return false;
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
            try
            {
                var errMessage = PasswordValidatorHelper.ChangePassword(txtOrganization.Text, txtUserName.Text, txtPassword.Text, txtNewPassword1.Text,
                                                                     txtNewPassword2.Text);
                if (errMessage != null)
                {
                    ErrorForm.ShowMessageDirect(errMessage);
                    return;
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                if (SqlExceptionHandler.Handle(ex))
                    return;
                string errMessage;
                if (ex is SqlException)
                    errMessage = SecurityMessages.GetDBErrorMessage((ex as SqlException).Number, null, null);
                else
                    errMessage = SecurityMessages.GetDBErrorMessage(0, null, null);
                ErrorForm.ShowErrorDirect(errMessage, ex);
            }
        }

        public static void Register(Control parentControl)
        {
            if (BaseFormManager.ArchiveMode)
                return;
            var manager = MenuActionManager.Instance;
            new MenuAction(ShowMe, manager, manager.Security, "MenuChangePassword", 1000, false, (int)MenuIconsSmall.ChangePassword, -1) { Name = "btnChangePassword" };
        }

        public static void ShowMe()
        {
            var form = new ChangePasswordForm();
            BaseFormManager.ShowModal(form, null);
        }

        private Control CurrentControl { get; set; }
        private Dictionary<Control, string> ControlsLastLanguage { get; set; } 

        private void Control_Enter(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            if (ControlsLastLanguage.Keys.Any(c => c.Name == ctrl.Name))
            {
                CurrentControl = ctrl;
                SystemLanguages.SwitchInputLanguage(ControlsLastLanguage[ctrl]);
            }
            ((TextEdit)sender).SelectAll();
        }

        private void Control_Leave(object sender, EventArgs e)
        {
            var ctrl = (Control)sender;
            if (ControlsLastLanguage.Keys.Any(c => c.Name == ctrl.Name))
            {
                ControlsLastLanguage[ctrl] = Localizer.GetLanguageID(InputLanguage.CurrentInputLanguage.Culture);
                CurrentControl = null;
            }
        }

        private void CheckControlLang(Control ctrl)
        {
            if (CurrentControl == ctrl)
            {
                 ControlsLastLanguage[ctrl] = Localizer.GetLanguageID(InputLanguage.CurrentInputLanguage.Culture);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateLangIndicators(object sender, EventArgs e)
        {
            if (CurrentControl != null)
            {
                //если во время ввода сменился язык (переключили раскладку клавиатуры)
                CheckControlLang(txtUserName);
                CheckControlLang(txtPassword);
                CheckControlLang(txtNewPassword1);
                CheckControlLang(txtNewPassword2);
            }

            lbLoginLng.Text = ControlsLastLanguage[txtUserName].ToUpperInvariant();
            lbCurrPassLng.Text = ControlsLastLanguage[txtPassword].ToUpperInvariant();
            lbNewPassLng.Text = ControlsLastLanguage[txtNewPassword1].ToUpperInvariant();
            lbConfNewPassLng.Text = ControlsLastLanguage[txtNewPassword2].ToUpperInvariant();
        }
    }
}
