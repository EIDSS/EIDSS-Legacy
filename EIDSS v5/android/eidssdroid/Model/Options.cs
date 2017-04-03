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
    public class Options
    {
        public Int64 id { get; set; }
        public String strServerUrl { get; set; }
        public String strLocalPassword { get; set; }
        public String strLoginOrganization { get; set; }
        public String strLoginUsername { get; set; }


        #region FromCursor
        public static Options FromCursor(ICursor cursor)
        {
            return new Options()
            {
                id = cursor.GetLong(cursor.GetColumnIndex("id")),
                strServerUrl = cursor.GetString(cursor.GetColumnIndex("strServerUrl")),
                strLocalPassword = cursor.GetString(cursor.GetColumnIndex("strLocalPassword")),
                strLoginOrganization = cursor.GetString(cursor.GetColumnIndex("strLoginOrganization")),
                strLoginUsername = cursor.GetString(cursor.GetColumnIndex("strLoginUsername"))
            };
        }
        #endregion

        #region ContentValues
        public ContentValues ContentValues()
        {
            var ret = new ContentValues();
            ret.Put("id", id);
            ret.Put("strServerUrl", strServerUrl);
            ret.Put("strLocalPassword", strLocalPassword);
            ret.Put("strLoginOrganization", strLoginOrganization);
            ret.Put("strLoginUsername", strLoginUsername);
            return ret;
        }
        #endregion

    }
}