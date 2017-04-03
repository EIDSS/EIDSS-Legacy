using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.db.Core;
using eidss.model.Avr.View;
using EIDSS;

namespace eidss.avr.db.Common
{
    public class AvrViewHelper
    {
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
                data.Columns.Add("ID", typeof(long));
                int i = 1;
                foreach (DataRow row in data.Rows)
                {
                    row["ID"] = i++;
                }
            }
        }

        public static void RemoveHASCadditions(AvrView view, ref DataTable data)
        {
            List<AvrViewColumn> hascColumns = view.GetVisibleRowAdminColumns(true, true, false).FindAll(x => x.GisReferenceTypeId != null);
            Regex rgx = new Regex("\\([^\\(\\)]+\\)", RegexOptions.RightToLeft);
            foreach (var col in hascColumns)
            {
                var colUniqHasc = col.UniquePath + "hasc";
                if (!data.Columns.Contains(colUniqHasc))
                    data.Columns.Add(colUniqHasc);
                foreach (DataRow row in data.Rows)
                {
                    row[colUniqHasc] = row[col.UniquePath];
                    row[col.UniquePath] = rgx.Replace(row[colUniqHasc].ToString(), "", 1).TrimEnd();
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
                    Match match = Regex.Match((string)item["UniquePath"], @"\((?<Latitude>-?\d+.\d+)\D+(?<Longitude>-?\d+.\d+)\)");
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
            foreach (var item in rowsToRemove)
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

        // remember selected in combos columns
        public static List<AvrViewColumn> FillSeriesFromCombos(AvrView view, string chb, string cb)
        {
            var comboColumns = new List<AvrViewColumn>();

            if (chb != null && chb.Length > 0)
            {
                string[] selCols = GetCheckedComboSelValues(chb);
                comboColumns.AddRange(selCols.Select(c => view.GetColumnByOriginalName(c)));
            }

            if (cb != null && cb.Length > 0)
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

            return comboColumns;
        }

        // remember selected in combos columns
        public static List<AvrViewColumn> FillSeriesFromCombosWeb(AvrView view, string chb, string cb)
        {
            var comboColumns = new List<AvrViewColumn>();

            if (chb != null && chb.Length > 0)
            {
                comboColumns.AddRange(view.GetColumnsByOriginalName(chb));
            }

            if (cb != null && cb.Length > 0)
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

            return comboColumns;
        }

        // remember data of all rows of selected in combo column
        public static Dictionary<int, DataRow> FillXAxisData(Dictionary<int, DataRow> xAxisData, string xName, string grandTotalSuffix, string totalSuffix)
        {
            //remove empty and "grand total" strings
            //List<KeyValuePair<int, DataRow>> l = XAxisData.ToList().Where(d => d.Value[xName] == null || d.Value[xName] == DBNull.Value).ToList();
            xAxisData.ToList()
                .FindAll(d => d.Value[xName] == null || d.Value[xName] == DBNull.Value)
                .ForEach(d => d.Value[xName] = BaseSettings.ShowAvrAsterisk ? "*" : "");
            xAxisData.ToList()
                .FindAll(d => ((string)d.Value[xName]).Length == 0 || ((string)d.Value[xName]).EndsWith(grandTotalSuffix))
                .ForEach(d => xAxisData.Remove(d.Key));

            // have we a string with "Total"? - remove nonTotal strings
            bool hasTotal = xAxisData.Values.Any(ax => ((string)ax[xName]).EndsWith(totalSuffix));

            //remove nonTotal strings
            if (hasTotal)
            {
                //List<KeyValuePair<int, DataRow>> l = XAxisData.ToList().Where(d => !((string)d.Value[xName]).EndsWith(View.TotalSuffix)).ToList();
                xAxisData.ToList()
                    .Where(d => !((string)d.Value[xName]).EndsWith(totalSuffix))
                    .ToList()
                    .ForEach(d => xAxisData.Remove(d.Key));
            }

            return xAxisData;
        }

        public static DataSet PrepareChartTable(string name, List<AvrViewColumn> columns, AvrViewColumn rowColAvr)
        {
            var ds = new DataSet(name);
            var dt = ds.Tables.Add("Data");

            // fill columns with types
            var dtCol = dt.Columns.Add(rowColAvr.UniquePath, typeof(string));
            dtCol.Caption = rowColAvr.FullPath;

            foreach (AvrViewColumn col in columns)
            {
                dtCol = dt.Columns.Add(col.UniquePath, col.FieldType);
                dtCol.Caption = col.FullPath;
            }

            return ds;
        }

        public static DataSet PrepareMapTable(string name, List<AvrViewColumn> columns, bool useDefaults=true)
        {
            var ds = new DataSet(name);
            var dtData = ds.Tables.Add("Data");
            var dtDict = ds.Tables.Add("DictionaryDataColumns");

            //       DictionaryDataColumns
            dtDict.Columns.Add("ColumnName", typeof(string));
            dtDict.Columns.Add("ColumnDescription", typeof(string));
            dtDict.Columns.Add("blnIsGradient", typeof(bool));
            dtDict.Columns.Add("blnIsChart", typeof(bool));

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
            dtData.Columns.Add("id", typeof(long));
            dtData.Columns.Add("x", typeof(float));
            dtData.Columns.Add("y", typeof(float));
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
                selCols = value.ToString().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            }
            return selCols;
        }

        public static object RoundVal(object val, int precision)
        {
            if (val is double)
            {
                val = Math.Round((double)val, precision);
            }
            if (val is float)
            {
                val = (float)Math.Round((float)val, precision);
            }
            if (val is decimal)
            {
                val = Math.Round((decimal)val, precision);
            }
            return val;
        }
    }
}
