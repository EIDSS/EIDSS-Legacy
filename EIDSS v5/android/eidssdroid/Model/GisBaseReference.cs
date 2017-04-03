using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace eidssdroid.Model
{
    public class GisBaseReference
    {
        public Int64 idfsBaseReference { get; set; }
        public String name { get; set; }

        public override string ToString()
        {
            return name;
        }

        #region FromCursor
        public static GisBaseReference FromCursor(ICursor cursor)
        {
            return new GisBaseReference()
            {
                idfsBaseReference = cursor.GetLong(cursor.GetColumnIndex("idfsBaseReference")),
                name = cursor.GetString(cursor.GetColumnIndex("name")),
            };
        }
        #endregion

        #region ContentValues
        public ContentValues ContentValues()
        {
            var ret = new ContentValues();
            ret.Put("idfsBaseReference", idfsBaseReference);
            ret.Put("name", name);
            return ret;
        }
        #endregion

    }
}