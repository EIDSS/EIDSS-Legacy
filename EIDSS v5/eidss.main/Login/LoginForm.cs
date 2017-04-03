using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using BLToolkit.Data;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.Diagnostics;
using bv.common.Resources;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.winclient.Localization;
using eidss.model.Core;
using eidss.model.Core.Security;
using eidss.model.Enums;
using eidss.model.Resources;
using bv.common.db.Core;
using bv.common.Enums;

namespace eidss.main.Login
{
    public partial class LoginForm : BvForm
    {
        public enum LoginType
        {
            Simple,
            Complex
        }

        private LoginType m_LoginType = LoginType.Simple;
        private EidssSecurityManager m_Manager;
        private ConnectionCredentials m_ConnectionCredentials;
        private ConnectionCredentials m_ArchiveConnectionCredentials;
        public LoginForm()
        {
            InitializeComponent();
            Init(LoginType.Simple);
        }

        public LoginForm(LoginType loginType)
        {
            InitializeComponent();
            Init(loginType);
        }
        private readonly List<string> m_SupportedLanguages = new List<string>();
        private void Init(LoginType type)
        {
            HelpTopicId = "logon";
            if (BaseSettings.UseDefaultLogin)
            {
                txtOrganization.Text = BaseSettings.DefaultOrganization;
                txtUserName.Text = BaseSettings.DefaultUser;
                txtPassword.Text = BaseSettings.DefaultPassword;
            }
            else
                txtOrganization.Text = Config.GetSetting("Organization", "");
            Application.Idle += UpdateLangIndicators;
            ActiveControl = txtUserName;
            m_LoginType = type;
            m_ConnectionCredentials = new ConnectionCredentials();
            m_ArchiveConnectionCredentials = new ConnectionCredentials(null, "Archive");
            m_ConnectionCredentials.CredentialChange += CredentialChanged;
            m_Manager = new EidssSecurityManager();
            m_Manager.LogOut();
            m_SupportedLanguages.Clear();
            foreach (string key in Localizer.SupportedLanguages.Keys)
            {
                m_SupportedLanguages.Add(key);
            }

        }

        public static bool Login(LoginType type)
        {
            var f = new LoginForm(type);
            return BaseFormManager.ShowModal(f, null);
        }

        public static bool DefaultLogin()
        {
#if !DEBUG
			return Login();
#else
            if (BaseSettings.UseDefaultLogin)
            {
                int errorCode = -1;
                try
                {
                    var manager = new EidssSecurityManager();
                    if (DoLogin(manager, BaseSettings.DefaultOrganization, BaseSettings.DefaultUser, BaseSettings.DefaultPassword, ref errorCode))
                        return true;
                }
                catch (Exception ex)
                {
                    Dbg.Debug("auto login error: {0}", ex.ToString());
                }
                return Login(LoginType.Simple);

            }
            return Login(LoginType.Simple);
#endif
        }

        private static bool DoLogin(EidssSecurityManager manager, string organization, string userName, string password,
                           ref int resultCode)
        {
            resultCode = manager.LogIn(organization, userName, password);
            if (resultCode == 0)
            {
                return true;
            }
            return false;
        }
        private void InitConnection()
        {
            if (TabControlMain.TabPages.IndexOf(TabPageSQL) > 0)
            {
                m_ConnectionCredentials.SetCredentials(BaseSettings.ConnectionString, txtSQLServer.Text, txtSQLDatabase.Text, txtSQLUser.Text, txtSQLPassword.Text);
                ConnectionManager.DefaultInstance.SetCredentials(BaseSettings.ConnectionString, txtSQLServer.Text, txtSQLDatabase.Text, txtSQLUser.Text, txtSQLPassword.Text);
                DbManagerFactory.SetSqlFactory(m_ConnectionCredentials.ConnectionString);
                if (m_ConnectionCredentials.IsCorrect)
                {
                    using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        if (manager.TestConnection())
                            m_ConnectionCredentials.Save();
                    }
                }
            }

        }

        private static void CredentialChanged(string keyName, string oldValue, string newValue)
        {
            switch (keyName)
            {
                case "SQLUser":
                    SecurityLog.WriteToEventLogDB(null, SecurityAuditEvent.ProtecteDataUpdate, true, "EIDSS SQL login was changed", null, "SQL login was changed", SecurityAuditProcessType.Eidss);
                    break;
                case "SQLPassword":
                    SecurityLog.WriteToEventLogDB(null, SecurityAuditEvent.ProtecteDataUpdate, true, "EIDSS SQL login was changed", null, "SQL password was changed", SecurityAuditProcessType.Eidss);
                    break;
            }
        }
        private void btnOk_Click(Object sender, EventArgs e)
        {
            string errorMessage = null;
            int errorCode = -1;
            bool bSuccessLogin = false;
            try
            {
                if (!ValidateArchiveConnection())
                {
                    return;
                }
                InitConnection();
                bSuccessLogin = DoLogin(m_Manager, txtOrganization.Text, txtUserName.Text, txtPassword.Text, ref errorCode);
                switch (errorCode)
                {
                    case 6:
                        errorMessage = SecurityMessages.GetLoginErrorMessage(errorCode, txtOrganization.Text, txtUserName.Text);
                        break;
                    default:
                        errorMessage = SecurityMessages.GetLoginErrorMessage(errorCode);
                        break;
                }
            }
            catch (Exception ex)
            {
                if (SqlExceptionHandler.Handle(ex))
                {
                    m_LoginType = LoginType.Complex;
                    UpdateTabsVisibility();
                    return;
                }
                errorMessage = SqlExceptionMessage.Get(ex);
                if (errorMessage == null)
                {
                    Dbg.Debug("unprocessed error during login: {0}", ex);
                    errorMessage = StandardErrorHelper.Error(StandardError.UnprocessedError);
                }
                else
                    errorMessage = BvMessages.Get(errorMessage);
            }

            if (bSuccessLogin)
            {
                SuccessLogin();
            }
            else
            {
                FailedLogin(errorMessage, errorCode);
            }
        }

        private bool ValidateArchiveConnection()
        {
            if (TabControlMain.TabPages.IndexOf(TabPageArchive) < 0)
                return true;
            if (!chkAllowArchiveConnection.Checked)
            {
                if (!string.IsNullOrEmpty(m_ArchiveConnectionCredentials.SQLDatabase) ||
                    !string.IsNullOrEmpty(m_ArchiveConnectionCredentials.SQLServer) ||
                    !string.IsNullOrEmpty(m_ArchiveConnectionCredentials.SQLUser) ||
                    !string.IsNullOrEmpty(m_ArchiveConnectionCredentials.SQLPassword))
                {
                    m_ArchiveConnectionCredentials.Clear();
                }
                return true;
            }
            m_ArchiveConnectionCredentials.SetCredentials(BaseSettings.ConnectionString, txtArchiveServer.Text, txtArchiveDatabase.Text, txtArchiveUser.Text, txtArchivePassword.Text, "Archive");
            if (m_ArchiveConnectionCredentials.IsCorrect)
            {
                DbManagerFactory.SetSqlFactory(m_ArchiveConnectionCredentials.ConnectionString);
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    if (manager.TestConnection())
                    {
                        m_ArchiveConnectionCredentials.Save();
                        return true;
                    }
                    else
                    {
                        ErrorForm.ShowError("errArchiveConnectionError");
                        return false;
                    }
                }
            }
            ErrorForm.ShowError("errArchiveConnectionError");
            return false;
        }

        private void SuccessLogin()
        {
            Splash.ShowSplash();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void FailedLogin(string err, int errorCode)
        {
            if (errorCode < 0)
                m_LoginType = LoginType.Complex;
            UpdateTabsVisibility();
            if (errorCode < 0)
                ErrorForm.ShowErrorDirect(err);
            else
                ErrorForm.ShowWarningDirect(err);
            if (errorCode == 9)
            {
                cmdChangePassword_Click(null, null);
            }
        }
        private void LoginForm_VisibleChanged(object sender, EventArgs e)
        {

            lForgetPass.Visible = false;
            if (Visible)
            {
                Splash.HideSplash();
            }
            ShowInTaskbar = true;
        }
        private void cmdChangePassword_Click(Object sender, EventArgs e)
        {

            InitConnection();

            var form = new ChangePasswordForm
                           {
                               txtOrganization = { Text = txtOrganization.Text },
                               txtUserName = { Text = txtUserName.Text }
                           };

            BaseFormManager.ShowModal(form, this);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            btnOk.Text = BvMessages.Get("strOK_Id");
            btnCancel.Text = BvMessages.Get("strCancel_Id");
            TabPageMain.Text = EidssMessages.Get("EIDSS_Short_Caption");
            UpdateTabsVisibility();
        }
        protected void UpdateTabsVisibility()
        {
            Dbg.Debug("Shift state = " + WindowsAPI.GetKeyState((int)Keys.ShiftKey).ToString(CultureInfo.InvariantCulture));
            if ((WindowsAPI.GetKeyState((int)Keys.ShiftKey) & 0xF000) != 0 || !m_ConnectionCredentials.IsCorrect)
            {
                m_LoginType = LoginType.Complex;
            }
            if (m_LoginType == LoginType.Simple)
            {
                TabControlMain.TabPages.Remove(TabPageSQL);
                TabControlMain.TabPages.Remove(TabPageArchive);
            }
            else
            {
                if (TabControlMain.TabPages.IndexOf(TabPageSQL) < 0)
                {
                    TabControlMain.TabPages.Add(TabPageSQL);
                }
                if (TabControlMain.TabPages.IndexOf(TabPageArchive) < 0)
                {
                    TabControlMain.TabPages.Add(TabPageArchive);
                }
                txtSQLServer.Text = m_ConnectionCredentials.SQLServer;
                txtSQLDatabase.Text = m_ConnectionCredentials.SQLDatabase;
                txtSQLUser.Text = m_ConnectionCredentials.SQLUser;
                txtSQLPassword.Text = m_ConnectionCredentials.SQLPassword;
                txtArchiveServer.Text = m_ArchiveConnectionCredentials.SQLServer;
                txtArchiveDatabase.Text = m_ArchiveConnectionCredentials.SQLDatabase;
                txtArchiveUser.Text = m_ArchiveConnectionCredentials.SQLUser;
                txtArchivePassword.Text = m_ArchiveConnectionCredentials.SQLPassword;
                chkAllowArchiveConnection.Checked = !string.IsNullOrEmpty(m_ArchiveConnectionCredentials.SQLDatabase) &&
                                            !string.IsNullOrEmpty(m_ArchiveConnectionCredentials.SQLServer) &&
                                            !string.IsNullOrEmpty(m_ArchiveConnectionCredentials.SQLUser) &&
                                            !string.IsNullOrEmpty(m_ArchiveConnectionCredentials.SQLPassword);
                EnableArchive(chkAllowArchiveConnection.Checked);

            }
        }
        #region Language switching
        int m_CurrentLanguageIndex = -1;
        public string GetNextLanguage()
        {
            int cnt = m_SupportedLanguages.Count;
            if (m_CurrentLanguageIndex == -1)
            {
                for (int i = 0; i < cnt; i++)
                {
                    if (m_SupportedLanguages[i] == ModelUserContext.CurrentLanguage)
                    {
                        m_CurrentLanguageIndex = i;
                        break;
                    }
                }
            }
            if (m_CurrentLanguageIndex < cnt - 1)
            {
                m_CurrentLanguageIndex++;
            }
            else
            {
                m_CurrentLanguageIndex = 0;
            }
            return m_SupportedLanguages[m_CurrentLanguageIndex];
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 & e.Shift)
            {
                ResetLanguage(GetNextLanguage());
            }
            if (e.Shift && e.Control)
            {
                if (e.KeyCode == Keys.E)
                {
                    ResetLanguage(Localizer.lngEn);
                }
                else if (e.KeyCode == Keys.R)
                {
                    ResetLanguage(Localizer.lngRu);
                }
                else if (e.KeyCode == Keys.G)
                {
                    ResetLanguage(Localizer.lngGe);
                }
                else if (e.KeyCode == Keys.K)
                {
                    ResetLanguage(Localizer.lngKz);
                }
                else if (e.KeyCode == Keys.U)
                {
                    ResetLanguage(Localizer.SupportedLanguages.ContainsKey(Localizer.lngUk)
                                      ? Localizer.lngUk
                                      : Localizer.lngUzCyr);
                }
                else if (e.KeyCode == Keys.A)
                {
                    ResetLanguage(Localizer.SupportedLanguages.ContainsKey(Localizer.lngAzLat)
                                      ? Localizer.lngAzLat
                                      : Localizer.lngAr);
                }
                else if (e.KeyCode == Keys.I)
                {
                    ResetLanguage(Localizer.lngIraq);
                }
                else if (e.KeyCode == Keys.L)
                {
                    ResetLanguage(Localizer.lngLaos);
                }
                else if (e.KeyCode == Keys.V)
                {
                    ResetLanguage(Localizer.lngVietnam);
                }
            }


        }




        public void ResetLanguage(string langID)
        {
            if (Localizer.SupportedLanguages.ContainsKey(langID) == false)
            {
                return;
            }
            if (ModelUserContext.CurrentLanguage == langID)
            {
                return;
            }
            ModelUserContext.CurrentLanguage = langID;
            langID = Localizer.SupportedLanguages[langID];
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(langID);
            string organization = txtOrganization.Text;
            string activeControlName = "";
            if (ActiveControl != null)
            {
                activeControlName = ActiveControl.Name;
                if (activeControlName == "" && ActiveControl.Parent != null)
                {
                    activeControlName = ActiveControl.Parent.Name;
                }
            }
            SuspendLayout();
            Visible = false;
            while (Controls.Count > 0)
                Controls[0].Dispose();
            InitializeComponent();
            Visible = true;
            ResumeLayout();
            txtOrganization.Text = organization;
            btnOk.Text = BvMessages.Get("strOK_Id");
            btnCancel.Text = BvMessages.Get("strCancel_Id");
            TabPageMain.Text = EidssMessages.Get("EIDSS_Short_Caption");
            if (m_LoginType == LoginType.Simple)
            {
                TabControlMain.TabPages.Remove(TabPageSQL);
                TabControlMain.TabPages.Remove(TabPageArchive);
            }

            foreach (Control ctl in Controls)
            {
                if (ctl.Name == activeControlName)
                {
                    ctl.Select();
                    break;
                }
            }
            return;
        }

        string m_LastInputLanguage;
        private void Control_Enter(object sender, EventArgs e)
        {
            WinUtils.SetControlLanguage(((Control)sender), ref m_LastInputLanguage);
            ((DevExpress.XtraEditors.TextEdit)sender).SelectAll();
        }

        private void Control_Leave(object sender, EventArgs e)
        {
            SystemLanguages.SwitchInputLanguage(m_LastInputLanguage);
        }
        private void UpdateLangIndicators(object sender, EventArgs e)
        {
            Control ctl = ActiveControl;
            if (ctl != null && (ctl) is DevExpress.XtraEditors.TextBoxMaskBox)
            {
                ctl = ctl.Parent;
            }
            if (ctl != null)
            {
                WinUtils.SetControlLanguage(ctl, ref m_LastInputLanguage);
            }
            lbUserLang.Text = InputLanguage.CurrentInputLanguage.Culture.TwoLetterISOLanguageName.ToUpperInvariant();// WinUtils.GetControlLanguage(txtUserName).ToUpperInvariant();
            lbPasswordLang.Text = InputLanguage.CurrentInputLanguage.Culture.TwoLetterISOLanguageName.ToUpperInvariant(); //WinUtils.GetControlLanguage(txtPassword).ToUpperInvariant();
        }
        #endregion

        private void chkAllowArchiveConnection_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllowArchiveConnection.Checked)
            {
                if (string.IsNullOrEmpty(txtArchiveServer.Text))
                    txtArchiveServer.Text = txtSQLServer.Text;

                if (string.IsNullOrEmpty(txtArchiveDatabase.Text))
                    txtArchiveDatabase.Text = txtSQLDatabase.Text + "_Archive";
                if (string.IsNullOrEmpty(txtArchiveUser.Text))
                    txtArchiveUser.Text = txtSQLUser.Text;
                if (string.IsNullOrEmpty(txtArchivePassword.Text))
                    txtArchivePassword.Text = txtSQLPassword.Text;
            }
            else
            {
                txtArchiveServer.Text = "";
                txtArchiveDatabase.Text = "";
                txtArchiveUser.Text = "";
                txtArchivePassword.Text = "";
            }
            EnableArchive(chkAllowArchiveConnection.Checked);
        }
        private void EnableArchive(bool enable)
        {
            txtArchiveServer.Enabled = enable;
            txtArchiveDatabase.Enabled = enable;
            txtArchiveUser.Enabled = enable;
            txtArchivePassword.Enabled = enable;

        }

    }
}
