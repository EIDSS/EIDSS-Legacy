using System;
using eidss.model.Schema;
using eidss.winclient.Core;
using eidss.winclient.Schema;

namespace eidss.winclient.Administration
{
    public partial class LoginInfoDetail : BaseDetailPanel_LoginInfo
    {
        public LoginInfoDetail()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void DefineBinding()
        {
            var loginInfo = BusinessObject as LoginInfo;
            if (loginInfo == null) return;

            LookupBinder.BindSiteLookup(leSites, loginInfo, "Site", loginInfo.SiteLookup, false);
            LookupBinder.BindTextEdit(txtUserLogin, loginInfo, "strAccountName");
            txtPassword.Properties.NullText = new String(txtPassword.Properties.PasswordChar, 10);
            txtConfirmPassword.Properties.NullText = new String(txtPassword.Properties.PasswordChar, 10);
            LookupBinder.BindTextEdit(txtPassword, loginInfo, "strPasswordDecrypted");
            LookupBinder.BindTextEdit(txtConfirmPassword, loginInfo, "strConfirmPassword");
        }


    }
}
