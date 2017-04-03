using System.Collections;
using System.Collections.Generic;
using System.Data;
using bv.common.db.Core;
using EIDSS;

namespace eidss.avr.db.Common
{
    public class AggrFunctionLookupHelper
    {
        public const string ColumnId = "idfAggregateFunction";
        public const string ColumnName = "AggregateFunctionName";
        public const string ColumnPrecision = "intDefaultPrecision";

        public static DataView GetLookupTable(bool? forPivot, bool? forView)
        {
            DataView dataView = LookupCache.Get(LookupTables.AggregateFunction.ToString());

            if (forPivot.HasValue && forView.HasValue)
            {
                dataView.RowFilter = string.Format("blnPivotGridFunction={0} AND blnViewFunction={1}", 
                    forPivot.Value ? "1" : "0",forView.Value ? "1" : "0");
            }
            else if (forPivot.HasValue)
            {
                dataView.RowFilter = string.Format("blnPivotGridFunction={0}", forPivot.Value ? "1" : "0");
            }
            else if (forView.HasValue)
            {
                dataView.RowFilter = string.Format("blnViewFunction={0}", forView.Value ? "1" : "0");
            }
            else
            {
                dataView.RowFilter = "";
            }

            return dataView;
        }

        public class AggrFunction
        {
            public long ID { get; set; }
            public string Name { get; set; }
            public int Precision { get; set; }
        }

        public static IEnumerable<AggrFunction> GetViewFunctions()
        {
            DataView dataView = GetLookupTable(null, true);

            var list = new List<AggrFunction>();
            IEnumerator num = dataView.GetEnumerator();
            while (num.MoveNext())
            {
                var row = num.Current as DataRowView;
                if (row != null)
                {
                    list.Add(new AggrFunction
                    {
                        ID = (long) row[ColumnId],
                        Name = (string) row[ColumnName],
                        Precision = (int) row[ColumnPrecision]
                    });
                }
            }
            return list;
        }
    }
}