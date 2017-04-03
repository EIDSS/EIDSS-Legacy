using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using eidssdroid.model.Database;

namespace EIDSS
{
    [Activity]
    public class ChangeLocalPasswordActivity : Activity
    {
        private const int PASSWORD_NOT_SET_DIALOG_ID = 1;
        private const int PASSWORD_NOT_SAME_DIALOG_ID = 2;
        private const int PASSWORD_OLD_DIALOG_ID = 3;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetTitle(Resource.String.TitleChangeLocalPassword);
            SetContentView(Resource.Layout.ChangeLocalPasswordLayout);
            Button buttonOk = FindViewById<Button>(Resource.Id.OkButton);
            Button buttonCancel = FindViewById<Button>(Resource.Id.CancelButton);
            EditText pwdold = FindViewById<EditText>(Resource.Id.OldPassword);
            EditText pwd = FindViewById<EditText>(Resource.Id.LoginPassword);
            EditText pwd2 = FindViewById<EditText>(Resource.Id.LoginPassword2);

            buttonOk.Click += delegate
            {
                string oldpwd = "";
                using (EidssDatabase db = new EidssDatabase(this))
                {
                    var opt = db.Options();
                    oldpwd = opt.strLocalPassword;
                }
                if (oldpwd != pwdold.Text)
                {
                    ShowDialog(PASSWORD_OLD_DIALOG_ID);
                    return;
                }
                if (pwd.Text != pwd2.Text)
                {
                    ShowDialog(PASSWORD_NOT_SAME_DIALOG_ID);
                    return;
                }
                if (pwd.Text.Length < 6)
                {
                    ShowDialog(PASSWORD_NOT_SET_DIALOG_ID);
                    return;
                }
                using (EidssDatabase db = new EidssDatabase(this))
                {
                    var opt = db.Options();
                    opt.strLocalPassword = pwd.Text;
                    db.OptionsUpdate(opt);
                }
                SetResult(Result.Ok);
                this.Finish();
            };

            buttonCancel.Click += delegate
            {
                SetResult(Result.Canceled);
                this.Finish();
            };
        }

        protected override Dialog OnCreateDialog(int id)
        {
            switch (id)
            {
                case PASSWORD_NOT_SET_DIALOG_ID:
                    return EidssAndroidHelpers.ErrorDialog(this, Resources.GetString(Resource.String.PasswordNotSet));
                case PASSWORD_NOT_SAME_DIALOG_ID:
                    return EidssAndroidHelpers.ErrorDialog(this, Resources.GetString(Resource.String.PasswordNotSame));
                case PASSWORD_OLD_DIALOG_ID:
                    return EidssAndroidHelpers.ErrorDialog(this, Resources.GetString(Resource.String.PasswordOldInvalid));
            }
            return null;
        }

    }
}