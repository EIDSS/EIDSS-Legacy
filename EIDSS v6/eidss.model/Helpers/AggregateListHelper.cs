using System;
using System.Data;
using System.Linq;
using eidss.model.Core;

namespace eidss.model.Helpers
{
    public static class AggregateListHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTable CreatePeriodTable()
        {
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("PeriodNumber", typeof(int)));
            dt.Columns.Add(new DataColumn("StartDay", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("FinishDay", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("PeriodName", typeof(string)));
            dt.Columns.Add(new DataColumn("PeriodID", typeof(string)));
            dt.PrimaryKey = new[] { dt.Columns["PeriodNumber"] };
            return dt;
        }

        /// <summary>
        /// Выводит список недель. Для текущего года отсекаются те недели, которые ещё не наступили.
        /// </summary>
        /// <returns></returns>
        public static DataTable CreateWeeksTable(int year)
        {
            var weeksTable = CreatePeriodTable();

            foreach (var wp in DatePeriodHelper.GetWeeksList(year, true))
            {
                var weekRow = weeksTable.NewRow();
                weekRow["PeriodNumber"] = wp.WeekNumber;
                weekRow["StartDay"] = wp.WeekStartDate;
                weekRow["PeriodID"] = String.Format("{0}_{1}", year, wp.WeekNumber);
                weekRow["FinishDay"] = wp.WeekStartDate.AddDays(6);
                weekRow["PeriodName"] = String.Format("{0:d} - {1:d}", weekRow["StartDay"], weekRow["FinishDay"]);
                weeksTable.Rows.Add(weekRow);
            }

            return weeksTable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="week"></param>
        /// <returns></returns>
        public static string GetWeekCaption(int year, int week)
        {
            return GetFieldValue(year, week, "PeriodName").ToString();
        }

        public static DateTime GetStartDate(int year, int week)
        {
            return Convert.ToDateTime(GetFieldValue(year, week, "StartDay"));
        }

        public static DateTime GetFinishDate(int year, int week)
        {
            return Convert.ToDateTime(GetFieldValue(year, week, "FinishDay"));
        }

        private static object GetFieldValue(int year, int week, string fieldName)
        {
            object result = null;
            var weeksTable = CreateWeeksTable(year);
            var rows = weeksTable.Select(String.Format("[PeriodNumber] = {0}", week));
            if (rows.Length == 1) result = rows[0][fieldName];
            return result;
        }
    }
}
