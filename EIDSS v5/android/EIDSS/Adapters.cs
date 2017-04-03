using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using eidssdroid.Model;
using eidssdroid.model.Database;

namespace EIDSS
{
    public class HumanCaseListAdapter : BaseAdapter<HumanCase>
    {
        List<HumanCase> items;
        Activity context;
        public HumanCaseListAdapter(Activity context, List<HumanCase> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override HumanCase this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            var view = convertView ?? // no view to re-use, create new
                context.LayoutInflater.Inflate(Resource.Layout.HumanCaseItemLayout, null);
            var fm = view.FindViewById<TextView>(Resource.Id.FamilyName);
            var d = view.FindViewById<TextView>(Resource.Id.Diagnosis);
            var cs = view.FindViewById<TextView>(Resource.Id.CaseID);
            var st = view.FindViewById<TextView>(Resource.Id.Status);
            var br = view.FindViewById<TextView>(Resource.Id.DateofBirth);
            var cr = view.FindViewById<TextView>(Resource.Id.CreatedDate);
            var er = view.FindViewById<TextView>(Resource.Id.LastSynError);
            fm.Text = item.strFamilyName + " " + item.strFirstName;
            cs.Text = item.strCaseID;
            if (item.datDateofBirth > DateTime.MinValue)
                br.Text = item.datDateofBirth.ToString("d");
            cr.Text = item.datCreateDate.ToString("G");
            er.Text = item.strLastSynError;
            if (string.IsNullOrEmpty(er.Text))
                er.SetHeight(0);
            else
                er.SetHeight(54);
            using (var db = new EidssDatabase(this.context))
            {
                d.Text = item.TentativeDiagnosis(db);
            }
            st.SetText(item.intStatus == (int)HumanCaseStatus.NEW ? Resource.String.CaseStatusNew : (item.intStatus == (int)HumanCaseStatus.SYNCHRONIZED ? Resource.String.CaseStatusSynchronized : Resource.String.CaseStatusChanged));

            return view;
        }
    }

    public class BaseReferenceAdapter : BaseAdapter<BaseReference>
    {
        public List<BaseReference> items;
        Activity context;
        public BaseReferenceAdapter(Activity context, List<BaseReference> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override BaseReference this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            var view = convertView ?? // no view to re-use, create new
                context.LayoutInflater.Inflate(Resource.Layout.LookupLayout, null);
            var tv = view.FindViewById<TextView>(Resource.Id.LookupText);
            tv.Text = item.name;
            return view;
        }
    }


    public class GisBaseReferenceAdapter : BaseAdapter<GisBaseReference>
    {
        List<GisBaseReference> items;
        Activity context;
        public GisBaseReferenceAdapter(Activity context, List<GisBaseReference> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override GisBaseReference this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            var view = convertView ?? // no view to re-use, create new
                context.LayoutInflater.Inflate(Resource.Layout.LookupLayout, null);
            var tv = view.FindViewById<TextView>(Resource.Id.LookupText);
            tv.Text = item.name;
            return view;
        }
    }
}