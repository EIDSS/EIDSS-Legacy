using System;
using bv.model.BLToolkit;
using bv.model.Model.Core;
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

            LookupBinder.BindTextEdit(txtUserLogin, loginInfo, "strAccountName");
            txtPassword.Properties.NullText = new String(txtPassword.Properties.PasswordChar, 10);
            txtConfirmPassword.Properties.NullText = new String(txtPassword.Properties.PasswordChar, 10);
            LookupBinder.BindTextEdit(txtPassword, loginInfo, "strPasswordDecrypted");
            LookupBinder.BindTextEdit(txtConfirmPassword, loginInfo, "strConfirmPassword");
        }
        public override void SetCustomActions(System.Collections.Generic.List<ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);
            var obj = BusinessObject as LoginInfo;
            using (DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                SetActionFunction(actions, "LoginInfoOk", (proxy, o, pars) => Submit(o), null, obj);
            }
        }

        static ActResult Submit(IObject bo )
        {
            return new ActResult(true, bo);
        }


    }
}
