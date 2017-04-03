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
    [Activity(Label = "EIDSS", MainLauncher = true, Icon = "@drawable/icon")]
    public class StartActivity : Activity
    {
        private const int REFLOAD_DIALOG_ID = 0;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            string pwd;
            using(var db = new EidssDatabase(this))
            {
                pwd = db.Options().strLocalPassword;
            }

            if (string.IsNullOrEmpty(pwd))
            {
                var i = new Intent(ApplicationContext, typeof(SetLocalPasswordActivity));
                StartActivityForResult(i, 2);
            }
            else
            {
                var i = new Intent(ApplicationContext, typeof(LocalLoginActivity));
                StartActivityForResult(i, 1);
            }
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == 1)
            {
                if (resultCode == Result.Ok)
                {
                    var i = new Intent(ApplicationContext, typeof(MainActivity));
                    StartActivityForResult(i, 3);
                }
                else
                {
                    Finish();
                }
            }
            if (requestCode == 2)
            {
                if (resultCode == Result.Ok)
                {
                    ShowDialog(REFLOAD_DIALOG_ID);
                }
                else
                {
                    Finish();
                }
            }
            if (requestCode == 3)
            {
                Finish();
            }
            if (requestCode == 4)
            {
                var i = new Intent(ApplicationContext, typeof(MainActivity));
                StartActivityForResult(i, 3);
            }
            base.OnActivityResult(requestCode, resultCode, data);
        }

        protected override Dialog OnCreateDialog(int id)
        {
            switch (id)
            {
                case REFLOAD_DIALOG_ID:
                    return EidssAndroidHelpers.QuestionDialog(this,
                        Resources.GetString(Resource.String.LoadRefOnStart),
                        (sender, args) =>
                        {
                            var i = new Intent(ApplicationContext, typeof(LoadReferencesActivity));
                            StartActivityForResult(i, 4);
                        },
                        (sender, args) =>
                        {
                            var i = new Intent(ApplicationContext, typeof(MainActivity));
                            StartActivityForResult(i, 3);
                        });
            }
            return null;
        }

    }
}