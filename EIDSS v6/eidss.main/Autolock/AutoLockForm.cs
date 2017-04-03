using System;
using System.Collections;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.Utils.Win;
using DevExpress.XtraBars.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using bv.common.Core;
using bv.common.Resources;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using bv.winclient.Layout;
using bv.winclient.Localization;
using eidss.gis.Tools.ToolForms;
using eidss.model.Core;
using eidss.model.Core.Security;
using eidss.model.Resources;

namespace eidss.main.Autolock
{
    public partial class AutoLockForm
    {
        private bool m_AllowToClose;

        public void btOk_Click(Object sender, EventArgs e)
        {
            int res;
            //If (Me.tbConfPass.Text.Trim() <> EIDSSUser.Current.Password) Then
            try
            {
                var sm = new EidssSecurityManager();
                var user = EidssUserContext.User;
                res = sm.LogIn(user.Organization, user.LoginName, tbConfPass.Text);
            }
            catch (Exception ex)
            {
                string errMessage;
                if (SqlExceptionHandler.Handle(ex))
                    return;
                if (ex is SqlException)
                {
                    errMessage = SecurityMessages.GetDBErrorMessage(((SqlException)ex).Number, null, null);
                }
                else
                {
                    errMessage = SecurityMessages.GetDBErrorMessage(0, null, null);
                }
                ErrorForm.ShowErrorDirect(errMessage, ex);

                return;
            }

            if (res != 0 && res != 9)
            {
                ShowError(res);
            }
            else
            {
                UnlockProgram();
            }
        }

        public void AutoLockForm_Load(Object sender, EventArgs e)
        {
            PlaceCenterWindow();
            ShowWindows(false);
            Application.Idle += UpdateLangIndicators;
            tbConfPass.Enter += Control_Enter;
            tbConfPass.Leave += Control_Leave;
            SystemLanguages.SwitchInputLanguage(m_LastInputLang);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateLangIndicators(object sender, EventArgs e)
        {
            lbPassLng.Text = Localizer.GetLanguageID(InputLanguage.CurrentInputLanguage.Culture).ToUpperInvariant();
        }

        private static string m_LastInputLang = "en";
        private void Control_Enter(object sender, EventArgs e)
        {
            SystemLanguages.SwitchInputLanguage(m_LastInputLang);
            ((TextEdit)sender).SelectAll();
        }

        private void Control_Leave(object sender, EventArgs e)
        {
            m_LastInputLang = Localizer.GetLanguageID(InputLanguage.CurrentInputLanguage.Culture);
        }
        public void ShowError(int res)
        {
            var err = SecurityMessages.GetLoginErrorMessage(res);
            MessageForm.Show(err, BvMessages.Get("Warning"), MessageBoxButtons.OK);
            tbConfPass.Text = String.Empty;
            tbConfPass.Focus();
        }

        public void UnlockProgram()
        {
            ShowWindows(true);

            DialogResult = DialogResult.OK;

            m_AllowToClose = true;
            Close();
        }

        public void sbLogout_Click(Object sender, EventArgs e)
        {
            CloseAllWindows();
            DialogResult = DialogResult.Cancel;
            m_AllowToClose = true;
            Close();
        }

        public void ShowWindows(bool bShow)
        {
            var formList = new ArrayList(Application.OpenForms);

            foreach (Form frm in formList)
            {
                if (frm is PopupBaseForm
                    || frm is GalleryItemImagePopupForm
                    || frm is SuperToolTipWindow
                    || frm is ToolTipControllerWindow
                    || frm is AppMenuForm
                    || frm is SubMenuControlForm
                    || frm is KeyTipForm
                    // commented because of bugN 5600 
                    //  || frm is DevExpress.XtraPivotGrid.Customization.CustomizationForm
                    || frm is InfoForm)
                {
                    if (frm.Visible)
                    {
                        frm.Hide();
                    }
                    continue;
                }

                frm.Visible = bShow;
            }
        }

        public void PlaceCenterWindow()
        {
            Left = (Screen.PrimaryScreen.Bounds.Width - Width) / 2;
            Top = (Screen.PrimaryScreen.Bounds.Height - Height) / 2;
        }

        public void CloseAllWindows()
        {
            //   Close all Detail forms first

            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                Form frm = Application.OpenForms[i];
                if (frm == null)
                {
                    continue;
                }

                if (frm.Controls.Count == 0)
                {
                    continue;
                }

                IApplicationForm ctrl = BaseFormManager.FindChildIApplicationForm(frm);

                if (ctrl != null)
                {
                    BaseFormManager.Close(ctrl);
                }
            }
            Application.DoEvents();
            BaseFormManager.CloseAll(false);
            Application.DoEvents();
        }

        public void AutoLockForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            e.Cancel = Convert.ToBoolean(!m_AllowToClose);
        }

        public AutoLockForm()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            Icon = BaseFormManager.MainForm.Icon;
            LayoutCorrector.ApplySystemFont(this);
            lLockMessage.Text = String.Format(EidssMessages.Get("lLockMessage"), EidssUserContext.User.Name);
        }
    }
}