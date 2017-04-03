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
    public class HumanCaseListActivity : Activity
    {
        private ListView m_listView;
        private List<HumanCase> m_cases;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetTitle(Resource.String.TitleHumanCaseList);
            SetContentView(Resource.Layout.HumanCaseListLayout);
            Button buttonOk = FindViewById<Button>(Resource.Id.OkButton);
            Button buttonNewHumanCase = FindViewById<Button>(Resource.Id.NewHumanCaseButton);
            Button buttonSynchronizeHumanCase = FindViewById<Button>(Resource.Id.SynchronizeHumanCaseButton);
            Spinner spinnerCaseStatusFilter = FindViewById<Spinner>(Resource.Id.CaseStatusFilterLookup);
            
            var adapter = ArrayAdapter.CreateFromResource (this, Resource.Array.CaseStatusFilterItems, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerCaseStatusFilter.Adapter = adapter;

            spinnerCaseStatusFilter.ItemSelected += CaseStatusFilter_spinner_ItemSelected;
            
            m_listView = FindViewById<ListView>(Resource.Id.List); 

            using (var mDb = new EidssDatabase(this))
            {
                m_cases = mDb.HumanCaseSelect();
                m_listView.Adapter = new HumanCaseListAdapter(this, m_cases);
            }

            m_listView.ItemLongClick += (sender, args) =>
            {
                var t = m_cases[args.Position];
                var i = new Intent(ApplicationContext, typeof(HumanCaseActivity));
                i = i.PutExtra("hc", t);
                StartActivityForResult(i, 333);
            };

            buttonNewHumanCase.Click += delegate
            {
                var i = new Intent(ApplicationContext, typeof(HumanCaseActivity));
                var mCase = HumanCase.CreateNew();
                i = i.PutExtra("hc", mCase);
                StartActivityForResult(i, 333);
            };

            buttonSynchronizeHumanCase.Click += delegate
            {
                var i = new Intent(ApplicationContext, typeof(SynchronizeHumanCaseActivity));
                StartActivityForResult(i, 444);
            };

            buttonOk.Click += delegate
            {
                this.Finish();
            };

        }

        void CaseStatusFilter_spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            using (var mDb = new EidssDatabase(this))
            {
                List<HumanCase> cases = mDb.HumanCaseSelect();

                switch (e.Position)
                {
                    case 0:
                        m_cases = cases;
                        break;
                    case 1:
                        m_cases = cases.Where(c => c.intStatus == (int)HumanCaseStatus.NEW).ToList();
                        break;
                    case 2:
                        m_cases = cases.Where(c => c.intStatus == (int)HumanCaseStatus.CHANGED).ToList();
                        break;
                    case 3:
                        m_cases = cases.Where(c => c.intStatus == (int)HumanCaseStatus.SYNCHRONIZED).ToList();
                        break;
                }

                m_listView.Adapter = new HumanCaseListAdapter(this, m_cases);
            }
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == 333)
            {
                if (resultCode == Result.FirstUser) // delete
                {
                    var mCase = (HumanCase)data.GetParcelableExtra("hc");
                    using (var db = new EidssDatabase(this))
                    {
                        db.HumanCaseDelete(mCase);
                    }
                    this.Recreate();
                }
                if (resultCode == Result.Ok)
                {
                    var mCase = (HumanCase)data.GetParcelableExtra("hc");
                    using (var db = new EidssDatabase(this))
                    {
                        if (mCase.id == 0)
                        {
                            db.HumanCaseInsert(mCase);
                        }
                        else
                        {
                            if (mCase.idfCase != 0)
                                mCase.intStatus = (int)HumanCaseStatus.CHANGED;
                            db.HumanCaseUpdate(mCase);
                        }
                    }
                    this.Recreate();
                }
            }
            if (requestCode == 444)
            {
                if (resultCode == Result.Ok)
                {
                    this.Recreate();
                }
            }
            base.OnActivityResult(requestCode, resultCode, data);
        }
    }
}