using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using bv.common.Core;
using bv.common.db.Core;
using DevExpress.XtraPivotGrid;
using eidss.model.Avr.Chart;
using eidss.model.Enums;

namespace eidss.avr.db.Common
{
    public class GroupIntervalHelper
    {
        public static PivotGroupInterval GetGroupInterval(object interval)
        {
            try
            {
                string strInterval = ((DBGroupInterval) interval).ToString().Substring(3);
                return (PivotGroupInterval) Enum.Parse(typeof (PivotGroupInterval), strInterval);
            }
            catch (Exception)
            {
                return PivotGroupInterval.DateYear;
            }
        }

        public static DBGroupInterval GetDBGroupInterval(PivotGroupInterval interval)
        {
            try
            {
                string strInterval = "git" + interval;
                return (DBGroupInterval)Enum.Parse(typeof(DBGroupInterval), strInterval);
            }
            catch (Exception)
            {
                return DBGroupInterval.gitDateYear;
            }
        }

        public static Dictionary<long, string> GetGroupIntervalLookup()
        {
            DataView view = LookupCache.Get(BaseReferenceType.rftGroupInterval.ToString());
            view.RowFilter = "idfsReference > 0";

            return view.Cast<DataRowView>().ToDictionary(r => (long) r["idfsReference"], rowView => Utils.Str(rowView["name"]));
        }
    }
}