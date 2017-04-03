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
using eidssdroid.Model;
using eidssdroid.model.Database;

namespace EIDSS
{
    [Activity]
    public class OptionsActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetTitle(Resource.String.TitleSettings);
            SetContentView(Resource.Layout.OptionsLayout);
            Button buttonOk = FindViewById<Button>(Resource.Id.OkButton);
            Button buttonCancel = FindViewById<Button>(Resource.Id.CancelButton);
            Button buttonLoadRef = FindViewById<Button>(Resource.Id.LoadReferencesButton);
            Button buttonSetPwd = FindViewById<Button>(Resource.Id.SetPasswordButton);
            EditText url = FindViewById<EditText>(Resource.Id.ServerUrl);

            using (EidssDatabase db = new EidssDatabase(this))
            {
                url.Text = db.Options().strServerUrl;
            }

            buttonLoadRef.Click += delegate
            {
                StartActivity(typeof(LoadReferencesActivity));
            };

            buttonSetPwd.Click += delegate
            {
                StartActivity(typeof(ChangeLocalPasswordActivity));
            };

            buttonOk.Click += delegate
            {
                using (EidssDatabase db = new EidssDatabase(this))
                {
                    Options o = db.Options();
                    o.strServerUrl = url.Text;
                    db.OptionsUpdate(o);
                }
                this.Finish();
            };

            buttonCancel.Click += delegate
            {
                this.Finish();
            };
        }


    }
}