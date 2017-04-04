using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.db.Core;
using EIDSS;
using eidss.model.Avr.View;
using DevExpress.XtraGrid.Views.Grid;

namespace eidss.avr.db.Common
{
    public static class AvrViewHelper
    {
        private static readonly Regex m_HascRegex = new Regex(@"\([^\(\)]+\)", RegexOptions.RightToLeft);

        #region Save Settings in Model

        public static void FillColumnsBooleans(AvrView view, object value, string booleanName)
        {
            string[] selCols = GetCheckedComboSelValues(value);
            view.FillColumnsBooleans(selCols, booleanName);
        }

        public static void SaveColumnsDefs(AvrView view, string col, string defName)
        {
            view.SaveColumnsDefs(col, defName);
        }

        #endregion

        #region Prepare Data for Map/Chart

        public static bool TryGetCheckedComboSelValue(object value, out string columnName)
        {
            string[] selCols = GetCheckedComboSelValues(value);
            bool cantGetValue = selCols.Length != 1;
            columnName = cantGetValue ? string.Empty : selCols[0];
            return !cantGetValue;
        }

        public static bool hasDuplicates<T>(List<T> list)
        {
            var hs = new HashSet<T>();

            return list.Any(t => !hs.Add(t));
        }

        public static void AddIDColumn(ref DataTable data)
        {
            if (!data.Columns.Contains("ID"))
            {
                data.Columns.Add("ID", typeof (long));
                int i = 1;
                foreach (DataRow row in data.Rows)
                {
                    row["ID"] = i++;
                }
            }
        }

        public static void RemoveHASCadditions(AvrView view, ref DataTable data)
        {
            List<AvrViewColumn> visibleColumns = view.GetVisibleRowAdminColumns(true, true, false);
            List<AvrViewColumn> hascColumns = visibleColumns.FindAll(x => x.GisReferenceTypeId != null);

            foreach (AvrViewColumn col in hascColumns)
            {
                string colUniqHasc = col.UniquePath + "hasc";
                if (!data.Columns.Contains(colUniqHasc))
                {
                    data.Columns.Add(colUniqHasc);
                }
                foreach (DataRow row in data.Rows)
                {
                    row[colUniqHasc] = row[col.UniquePath];
                    row[col.UniquePath] = RemoveHasc(row[colUniqHasc]);
                }
            }
        }

        public static void ConvertMapDataForGis(ref DataTable dataTable)
        {
            DataView gisView = LookupCache.Get(LookupTables.AVRGIS);
            gisView.Sort = "ExtendedName";

            var rowsToRemove = new List<DataRow>();
            foreach (DataRow item in dataTable.Rows)
            {
                DataRowView[] foundRows = gisView.FindRows(item["UniquePath"]);

                if (foundRows.Length > 0)
                {
                    item["id"] = foundRows[0]["idfsReference"];
                    item["y"] = foundRows[0]["dblLongitude"];
                    item["x"] = foundRows[0]["dblLatitude"];
                }
                else
                {
                    Match match = Regex.Match((string) item["UniquePath"], @"\((?<Latitude>-?\d+.\d+)\D+(?<Longitude>-?\d+.\d+)\)");
                    Group latitudeGroup = match.Groups["Latitude"];
                    Group longitudeGroup = match.Groups["Longitude"];
                    if (latitudeGroup.Captures.Count > 0 && longitudeGroup.Captures.Count > 0)
                    {
                        float latitude;
                        float longitude;
                        if (
                            Single.TryParse(latitudeGroup.Captures[0].Value, NumberStyles.Float,
                                CultureInfo.InvariantCulture, out latitude) &&
                            Single.TryParse(longitudeGroup.Captures[0].Value, NumberStyles.Float,
                                CultureInfo.InvariantCulture, out longitude))
                        {
                            item["y"] = longitude;
                            item["x"] = latitude;
                        }
                    }
                }

                if (Utils.IsEmpty(item["id"]) && Utils.IsEmpty(item["x"]) && Utils.IsEmpty(item["y"]))
                {
                    rowsToRemove.Add(item);
                }
            }
            foreach (DataRow item in rowsToRemove)
            {
                dataTable.Rows.Remove(item);
            }
        }

        public static int GCD(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            return GCD(b, a % b);
        }

        public static object GetRatio(double dRef, double dDen, int? precision)
        {
            int d = GD(dRef, dDen, precision);
            int iRef = (int)Math.Round(dRef * d);
            int iDen = (int)Math.Round(dDen * d);
            return GetRatio(iRef, iDen);
        }

        private static object GetRatio(int iRef, int iDen)
        {
            int gcd = (iRef != 0 && iDen != 0)
                ? AvrViewHelper.GCD(iRef, iDen)
                : 1;
            return gcd > 1
                ? String.Format("{0} : {1}", iRef / gcd, iDen / gcd)
                : String.Format("{0} : {1}", iRef, iDen);
        }

        private static int GD(double a, double b, int? precision)
        {
            double prec = Math.Pow(0.1, precision.HasValue ? (precision.Value < 0 ? 2 : precision.Value) : 2);
            for (int i = 1; i < Int32.MaxValue; i++)
            {
                double aa = a*i;
                double bb = b*i;
                if (Math.Abs(Math.Round(aa) - aa) < prec &&
                    Math.Abs(Math.Round(bb) - bb) < prec)
                    return i;
            }
            return Int32.MaxValue;
        }

        // remember selected in combos columns
        public static List<AvrViewColumn> FillSeriesFromCombos(AvrView view, string chb, string cb)
        {
            var comboColumns = new List<AvrViewColumn>();

            if (!string.IsNullOrEmpty(chb))
            {
                string[] selCols = GetCheckedComboSelValues(chb);
                comboColumns.AddRange(selCols.Select(view.GetColumnByOriginalName));
            }

            if (!string.IsNullOrEmpty(cb))
            {
                string[] selCols = GetCheckedComboSelValues(cb);
                if (selCols.Length == 1)
                {
                    AvrViewColumn col = view.GetColumnByOriginalName(selCols[0]);
                    if (!comboColumns.Contains(col))
                    {
                        comboColumns.Add(col);
                    }
                }
            }

            return comboColumns.OrderBy(c => c.Order_ForUse).ToList();
        }

        // remember selected in combos columns
        public static List<AvrViewColumn> FillSeriesFromCombosWeb(AvrView view, string chb, string cb)
        {
            var comboColumns = new List<AvrViewColumn>();

            if (!string.IsNullOrEmpty(chb))
            {
                comboColumns.AddRange(view.GetColumnsByOriginalName(chb));
            }

            if (!string.IsNullOrEmpty(cb))
            {
                string[] selCols = GetCheckedComboSelValues(cb);
                if (selCols.Length == 1)
                {
                    AvrViewColumn col = view.GetColumnByOriginalName(selCols[0]);
                    if (!comboColumns.Contains(col))
                    {
                        comboColumns.Add(col);
                    }
                }
            }

            return comboColumns.OrderBy(c => c.Order_ForUse).ToList();
        }

        // remember data of all rows of selected in combo column
        public static Dictionary<int, DataRow> FillXAxisData
            (Dictionary<int, DataRow> xAxisData, string xName, string grandTotalSuffix, string totalSuffix)
        {
            //remove empty and "grand total" strings
            //List<KeyValuePair<int, DataRow>> l = XAxisData.ToList().Where(d => d.Value[xName] == null || d.Value[xName] == DBNull.Value).ToList();
            xAxisData.ToList()
                .FindAll(d => d.Value[xName] == null || d.Value[xName] == DBNull.Value)
                .ForEach(d => d.Value[xName] = BaseSettings.ShowAvrAsterisk ? "*" : "");
            xAxisData.ToList()
                .FindAll(d => ((string) d.Value[xName]).Length == 0 || ((string) d.Value[xName]).EndsWith(grandTotalSuffix))
                .ForEach(d => xAxisData.Remove(d.Key));

            // have we a string with "Total"? - remove nonTotal strings
            bool hasTotal = xAxisData.Values.Any(ax => ((string) ax[xName]).EndsWith(totalSuffix));

            //remove nonTotal strings
            if (hasTotal)
            {
                //List<KeyValuePair<int, DataRow>> l = XAxisData.ToList().Where(d => !((string)d.Value[xName]).EndsWith(View.TotalSuffix)).ToList();
                xAxisData.ToList()
                    .Where(d => !((string) d.Value[xName]).EndsWith(totalSuffix))
                    .ToList()
                    .ForEach(d => xAxisData.Remove(d.Key));
            }

            return xAxisData;
        }

        public static DataSet PrepareChartTable(string name, List<AvrViewColumn> columns, AvrViewColumn rowColAvr)
        {
            var ds = new DataSet(name);
            DataTable dt = ds.Tables.Add("Data");

            // fill columns with types
            DataColumn dtCol = dt.Columns.Add(rowColAvr.UniquePath, typeof (string));
            dtCol.Caption = rowColAvr.FullPath;

            foreach (AvrViewColumn col in columns)
            {
                dtCol = dt.Columns.Add(col.UniquePath, col.FieldType);
                dtCol.Caption = col.FullPath;

                if (col.IsAggregate &&
                    (col.AggregateFunction == (long)ViewAggregateFunction.CumulativePercent ||
                     col.AggregateFunction == (long)ViewAggregateFunction.PercentOfColumn ||
                     col.AggregateFunction == (long)ViewAggregateFunction.PercentOfRow))
                {
                    dtCol.ExtendedProperties.Add("TextPattern", "p" + col.Precision_);
                }
            }

            return ds;
        }

        public static DataSet PrepareMapTable(string name, List<AvrViewColumn> columns, bool useDefaults = true)
        {
            var ds = new DataSet(name);
            DataTable dtData = ds.Tables.Add("Data");
            DataTable dtDict = ds.Tables.Add("DictionaryDataColumns");

            //       DictionaryDataColumns
            dtDict.Columns.Add("ColumnName", typeof (string));
            dtDict.Columns.Add("ColumnDescription", typeof (string));
            dtDict.Columns.Add("blnIsGradient", typeof (bool));
            dtDict.Columns.Add("blnIsChart", typeof (bool));

            dtDict.BeginLoadData();
            foreach (AvrViewColumn col in columns)
            {
                DataRow nRow = dtDict.NewRow();
                nRow["ColumnName"] = col.UniquePath;
                nRow["ColumnDescription"] = col.FullPath;
                if (useDefaults)
                {
                    nRow["blnIsGradient"] = col.IsMapGradientSeries;
                    nRow["blnIsChart"] = col.IsMapDiagramSeries;
                }
                else
                {
                    if (columns.Count == 1)
                    {
                        nRow["blnIsGradient"] = true;
                        nRow["blnIsChart"] = false;
                    }
                    else
                    {
                        nRow["blnIsGradient"] = false;
                        nRow["blnIsChart"] = true;
                    }
                }
                dtDict.Rows.Add(nRow);
            }
            dtDict.EndLoadData();
            dtDict.AcceptChanges();

            //       Data
            // fill columns with types
            dtData.Columns.Add("id", typeof (long));
            dtData.Columns.Add("x", typeof (float));
            dtData.Columns.Add("y", typeof (float));
            foreach (AvrViewColumn col in columns)
            {
                dtData.Columns.Add(col.UniquePath, col.FieldType);
            }

            return ds;
        }

        #endregion

        public static string[] GetCheckedComboSelValues(object value)
        {
            var selCols = new string[0];
            if (value != null)
            {
                selCols = value.ToString().Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries);
            }
            return selCols;
        }

        public static object RoundVal(object val, int precision)
        {
            if (val is double)
            {
                val = Math.Round((double) val, precision);
            }
            if (val is float)
            {
                val = (float) Math.Round((float) val, precision);
            }
            if (val is decimal)
            {
                val = Math.Round((decimal) val, precision);
            }
            return val;
        }

        public static void RemoveHascFromDisplayText(this AvrView view)
        {
            RemoveHascFromDisplayTextInternal(view);
        }

        private static void RemoveHascFromDisplayTextInternal(BaseBand owner)
        {
            foreach (AvrViewBand band in owner.Bands)
            {
                if (band.IsAdministrativeUnit)
                {
                    band.DisplayText = RemoveHasc(band.DisplayText);
                }
                RemoveHascFromDisplayTextInternal(band);
            }
            foreach (AvrViewColumn column in owner.Columns)
            {
                if (column.IsAdministrativeUnit)
                {
                    column.DisplayText = RemoveHasc(column.DisplayText);
                }
            }
        }

        public static string RemoveHasc(object value)
        {
            return m_HascRegex.Replace(value.ToString(), "", 1).TrimEnd();
        }

        #region get Sum of Column
        // get Sum of Column
        // all rows
        public static double GetColumnSum(DataTable data, int rowColsCount, string GrandTotalSuffix, string TotalSuffix, string refColumn, ref Dictionary<int, object> dict)
        {
            if (!dict.ContainsKey(-1))
            {
                dict.Add(-1, GetColumnSum(data, rowColsCount, GrandTotalSuffix, TotalSuffix, refColumn));
            }
            return (double)dict[-1];
        }
        public static double GetColumnSum(DataTable data, int rowColsCount, string GrandTotalSuffix, string TotalSuffix, string refColumn)
        {
            double sumFull = 0;
            foreach (DataRow row in data.Rows)
            {
                if (!GetRowTotalStatus(row, rowColsCount, GrandTotalSuffix, TotalSuffix))
                {
                    object cur = row[refColumn];
                    double dCur;
                    if (!bv.common.Core.Utils.IsEmpty(cur) && double.TryParse(cur.ToString(), out dCur))
                    {
                        sumFull += dCur;
                    }
                }
            }
            return sumFull;
        }

        // only visible rows
        public static double GetColumnSum(GridView view, int rowColsCount, string GrandTotalSuffix, string TotalSuffix, string refColumn, ref Dictionary<int, object> dict)
        {
            if (!dict.ContainsKey(-1))
            {
                dict.Add(-1, GetColumnSum(view, rowColsCount, GrandTotalSuffix, TotalSuffix, refColumn));
            }
            return (double)dict[-1];
        }
        public static double GetColumnSum(GridView view, int rowColsCount, string GrandTotalSuffix, string TotalSuffix, string refColumn)
        {
            double sumFull = 0;
            int dataRowCount = view.DataRowCount;
            for (int i = 0; i < dataRowCount; i++)
            {
                if (!GetRowTotalStatus(view.GetDataRow(i), rowColsCount, GrandTotalSuffix, TotalSuffix))
                {
                    object cur = view.GetRowCellValue(i, refColumn);
                    double dCur;
                    if (!bv.common.Core.Utils.IsEmpty(cur) && double.TryParse(cur.ToString(), out dCur))
                    {
                        sumFull += dCur;
                    }
                }
            }
            return sumFull;
        }

        // return true if total, false if regular
        public static bool GetRowTotalStatus(DataRow row, int rowColsCount, string GrandTotalSuffix, string TotalSuffix)
        {
            //var rowCols = View.GetVisibleRowAdminColumns(true, null, false);
            for (int i = 0; i < rowColsCount; i++)
            {
                object cur = row[i];
                if (Utils.IsEmpty(cur))
                {
                    continue;
                }
                string val = (string)row[i];
                if (val.EndsWith(GrandTotalSuffix))
                    return true;
                if (val.EndsWith(TotalSuffix))
                    return true;
            }
            return false;
        }
        #endregion
    }
}