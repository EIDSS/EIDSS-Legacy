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
    public class LocalLoginActivity : Activity
    {
        private const int PASSWORD_INVALID_DIALOG_ID = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetTitle(Resource.String.TitleLocalLogin);
            SetContentView(Resource.Layout.LocalLoginLayout);
            Button buttonOk = FindViewById<Button>(Resource.Id.OkButton);
            Button buttonCancel = FindViewById<Button>(Resource.Id.CancelButton);
            EditText pwd = FindViewById<EditText>(Resource.Id.LoginPassword);

            buttonOk.Click += delegate
            {
                using (EidssDatabase db = new EidssDatabase(this))
                {
                    string password = db.Options().strLocalPassword;
                    if (pwd.Text != password)
                    {
                        ShowDialog(PASSWORD_INVALID_DIALOG_ID);
                    }
                    else
                    {
                        SetResult(Result.Ok);
                        this.Finish();
                    }
                }
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
                case PASSWORD_INVALID_DIALOG_ID:
                    return EidssAndroidHelpers.ErrorDialog(this, Resources.GetString(Resource.String.PasswordInvalid));
            }
            return null;
        }

    }
}