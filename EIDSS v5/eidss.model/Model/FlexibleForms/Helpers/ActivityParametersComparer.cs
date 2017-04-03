using System;
using System.Collections.Generic;
using System.Data;
using eidss.model.Schema;

namespace eidss.model.Model.FlexibleForms.Helpers
{
    public class ActivityParametersComparer : IComparer<ActivityParameter>
    {
        public int Compare(ActivityParameter x, ActivityParameter y)
        {
            if (x.intNumRow.HasValue && y.intNumRow.HasValue)
            {
                return x.intNumRow.Value - y.intNumRow.Value;
            }
            return 0;
        }
    }

    public class ActivityParametersRowsComparer : IComparer<DataRow>
    {
        public int Compare(DataRow x, DataRow y)
        {
            var xNum = Convert.ToInt64(x["idfRow"]);
            var yNum = Convert.ToInt64(y["idfRow"]);
            return xNum - yNum < 0 ? -1 : 1;
        }
    }
}
