using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Threading;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using eidssdroid.Model;
using eidssdroid.model.Database;


// http://laslow.net/2012/05/10/android-adb-on-windows-x64/

namespace EIDSS
{
    [Activity]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetTitle(Resource.String.TitleMainMenu);
            SetContentView(Resource.Layout.MainLayout);

            Button buttonExit = FindViewById<Button>(Resource.Id.ExitButton);
            Button buttonOptions = FindViewById<Button>(Resource.Id.OptionsButton);
            Button buttonHumanCaseList = FindViewById<Button>(Resource.Id.HumanCaseListButton);
            Button buttonNewHumanCase = FindViewById<Button>(Resource.Id.NewHumanCaseButton);

            buttonExit.Click += delegate
            {
                Finish();
            };

            buttonOptions.Click += delegate
            {
                StartActivity(typeof(OptionsActivity));
            };

            buttonHumanCaseList.Click += delegate
            {
                StartActivity(typeof(HumanCaseListActivity));
            };

            buttonNewHumanCase.Click += delegate
            {
                var i = new Intent(ApplicationContext, typeof(HumanCaseActivity));
                var mCase = HumanCase.CreateNew();
                i = i.PutExtra("hc", mCase);
                StartActivityForResult(i, 333);
            };

        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == 333)
            {
                if (resultCode == Result.Ok)
                {
                    var mCase = (HumanCase)data.GetParcelableExtra("hc");
                    using (var db = new EidssDatabase(this))
                    {
                        db.HumanCaseInsert(mCase);
                    }
                }
            }
            base.OnActivityResult(requestCode, resultCode, data);
        }

    }
}

