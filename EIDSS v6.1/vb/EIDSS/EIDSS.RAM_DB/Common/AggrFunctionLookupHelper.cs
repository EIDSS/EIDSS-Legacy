using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using bv.common.db.Core;
using EIDSS;
using eidss.model.Avr.Pivot;

namespace eidss.avr.db.Common
{
    public class AggrFunctionLookupHelper
    {
        public const string ColumnId = "idfAggregateFunction";
        public const string ColumnName = "AggregateFunctionName";
        public const string ColumnPrecision = "intDefaultPrecision";

        public static DataView GetLookupTable(AggregateFunctionTarget target)
        {
            DataView dataView = LookupCache.Get(LookupTables.AggregateFunction.ToString());

            var filters = new List<string>();
            if ((target & AggregateFunctionTarget.Pivot) == AggregateFunctionTarget.Pivot)
            {
                filters.Add("blnPivotGridFunction=1");
            }
            if ((target & AggregateFunctionTarget.View) == AggregateFunctionTarget.View)
            {
                filters.Add("blnViewFunction=1");
            }
            if ((target & AggregateFunctionTarget.Basic) == AggregateFunctionTarget.Basic)
            {
                filters.Add(string.Format("idfAggregateFunction={0} OR idfAggregateFunction={1}",
                    (long) CustomSummaryType.DistinctCount, (long) CustomSummaryType.Count));
            }
            if (filters.Count == 0)
            {
                dataView.RowFilter = string.Empty;
            }
            else
            {
                var sb = new StringBuilder();
                string and = string.Empty;
                foreach (string filter in filters)
                {
                    sb.AppendFormat("{0}({1})", and, filter);
                    and = "AND";
                }
                dataView.RowFilter = sb.ToString();
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
            DataView dataView = GetLookupTable(AggregateFunctionTarget.View);

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