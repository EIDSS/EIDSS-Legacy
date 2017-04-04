using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using bv.common.Core;
using eidss.avr.db.Common;
using eidss.model.Avr.View;
using eidss.web.common.Utils;

namespace eidss.avr.mweb.Utils
{
    public static class AggregateCasheWeb
    {
        private const string storagePrefix = "COLUMNSCASHE";
        private static Dictionary<object, object> ColumnsCache(string sessionID, long layoutId)
        {
            //var columnsCashe = ModelStorage.Get(sessionID, layoutId, storagePrefix, false) as Dictionary<object, object>;
            return ObjectStorage.Using<Dictionary<object, object>, Dictionary<object, object>>(columnsCashe =>
                {
                    if (columnsCashe == null)
                    {
                        columnsCashe = new Dictionary<object, object>();
                        ObjectStorage.Put(sessionID, layoutId, layoutId, storagePrefix, columnsCashe);
                    }

                    return columnsCashe;
                }, sessionID, layoutId, storagePrefix, false);
        }

        public static void AddColumn(string sessionID, long layoutId, string keyFieldName)
        {
            var valuesCache = new Dictionary<int, object>();
            var columnsCache = ColumnsCache(sessionID, layoutId);
            if (columnsCache.ContainsKey(keyFieldName))
            {
                ClearColumn(sessionID, layoutId, keyFieldName);
                columnsCache.Remove(keyFieldName);
            }
            columnsCache.Add(keyFieldName, valuesCache);
        }

        public static void ClearColumn(string sessionID, long layoutId, string keyFieldName)
        {
            var columnsCache = ColumnsCache(sessionID, layoutId);
            if (columnsCache.ContainsKey(keyFieldName))
            {
                ((Dictionary<int, object>)columnsCache[keyFieldName]).Clear();
            }
        }

        public static object GetValue(string sessionID, long layoutId, string keyFieldName, int rowIndex, DataTable data, AvrViewColumn col)
        {
            object result;

            var columnsCache = ColumnsCache(sessionID, layoutId);
            if (!columnsCache.ContainsKey(keyFieldName))
                AddColumn(sessionID, layoutId, keyFieldName);

            var colCashe = (Dictionary<int, object>)columnsCache[keyFieldName];

            if (colCashe.TryGetValue(rowIndex, out result))
            {
                return result;
            }

            object val = FillAggregateColumn(data, rowIndex, col, ref colCashe);

            colCashe.Add(rowIndex, val);
            return val;
        }

        public static void SetValue(string sessionID, long layoutId, string keyFieldName, int rowIndex, object value)
        {
            var columnsCache = ColumnsCache(sessionID, layoutId);
            ((Dictionary<object, object>)columnsCache[keyFieldName])[rowIndex] = value;
        }

        #region Aggregate Functions


        // fill aggregate values into data column
        public static void FillAggregateColumn(DataTable data, AvrViewColumn aggrCol, string sort)
        {
            if (data.Columns.Contains(aggrCol.UniquePath))
                data.Columns.Remove(aggrCol.UniquePath);

            aggrCol.setAggrColumnTypeWeb();
            data.Columns.Add(aggrCol.UniquePath, aggrCol.FieldType);

            switch (aggrCol.AggregateFunction)
            {
                case (long)ViewAggregateFunction.CumulativePercent:
                    FillGridAggrFCumProcent(data, aggrCol, sort);
                    break;
                case (long)ViewAggregateFunction.PercentOfColumn:
                    FillGridAggrFColProcent(data, aggrCol);
                    break;
                case (long)ViewAggregateFunction.PercentOfRow:
                    FillGridAggrFRowProcent(data, aggrCol);
                    break;
                case (long)ViewAggregateFunction.Proportion:
                    FillGridAggrFProportion(data, aggrCol);
                    break;
                case (long)ViewAggregateFunction.Ratio:
                    FillGridAggrFRatio(data, aggrCol);
                    break;
                case (long)ViewAggregateFunction.MaxOfRow:
                    FillGridAggrFMinMax(data, true, aggrCol);
                    break;
                case (long)ViewAggregateFunction.MinOfRow:
                    FillGridAggrFMinMax(data, false, aggrCol);
                    break;
            }
        }
        // returns one aggregate value
        public static object FillAggregateColumn(DataTable data, int rowIndex, AvrViewColumn col, ref Dictionary<int, object> dict)
        {
            switch (col.AggregateFunction)
            {
                case (long)ViewAggregateFunction.CumulativePercent:
                    return FillGridAggrFCumProcent(data, rowIndex, col, ref dict);
                case (long)ViewAggregateFunction.PercentOfColumn:
                    return FillGridAggrFColProcent(data, rowIndex, col, ref dict);
                case (long)ViewAggregateFunction.PercentOfRow:
                    return FillGridAggrFRowProcent(data.Rows[rowIndex], col);
                case (long)ViewAggregateFunction.Proportion:
                    return FillGridAggrFProportion(data.Rows[rowIndex], col.SourceViewColumn, col.DenominatorViewColumn);
                case (long)ViewAggregateFunction.Ratio:
                    return FillGridAggrFRatio(data.Rows[rowIndex], col);
                case (long)ViewAggregateFunction.MaxOfRow:
                    return FillGridAggrFMinMax(data.Rows[rowIndex], true, col);
                case (long)ViewAggregateFunction.MinOfRow:
                    return FillGridAggrFMinMax(data.Rows[rowIndex], false, col);
            }
            return DBNull.Value;
        }

        // fill aggregate values into data column
        private static void FillGridAggrFCumProcent(DataTable data, AvrViewColumn aggrColumn, string sort)
        {
            if (!bv.common.Core.Utils.IsEmpty(aggrColumn.SourceViewColumn) && data.Columns.Contains(aggrColumn.SourceViewColumn))
            {
                var view = aggrColumn.GetView();
                var rowCols = view.GetVisibleRowAdminColumns(true, null, false);
                // get Sum of refColumn
                double sumFull = AvrViewHelper.GetColumnSum(data, rowCols.Count, view.GrandTotalSuffix, view.TotalSuffix, aggrColumn.SourceViewColumn);
                if (sumFull != 0)
                {

                    double sum = 0;

                    DataView dv = new DataView(data);
                    dv.Sort = sort;
                    foreach (DataRowView row in dv)
                    {
                        if (!AvrViewHelper.GetRowTotalStatus(row.Row, rowCols.Count, view.GrandTotalSuffix, view.TotalSuffix))  //if regular value (not total)
                        {
                            object cur = row[aggrColumn.SourceViewColumn];
                            if (bv.common.Core.Utils.IsEmpty(cur))
                            {
                                continue;
                            }
                            double dCur;
                            if (double.TryParse(cur.ToString(), out dCur))
                            {
                                sum += dCur;
                                row[aggrColumn.UniquePath] = sum / sumFull;
                            }
                        }
                    }
                }
            }
        }
        // returns one aggregate value
        private static object FillGridAggrFCumProcent(DataTable data, int rowIndex, AvrViewColumn aggrColumn, ref Dictionary<int, object> dict)
        {
            object ret = DBNull.Value;

            if (!bv.common.Core.Utils.IsEmpty(aggrColumn.SourceViewColumn) && data.Columns.Contains(aggrColumn.SourceViewColumn))
            {
                var view = aggrColumn.GetView();
                var rowCols = view.GetVisibleRowAdminColumns(true, null, false);
                double sum = 0;

                for (int i = 0; i <= rowIndex; i++)
                {
                    if (!AvrViewHelper.GetRowTotalStatus(data.Rows[i], rowCols.Count, view.GrandTotalSuffix, view.TotalSuffix))  //if regular value (not total)
                    {
                        object cur = data.Rows[i][aggrColumn.SourceViewColumn];
                        if (bv.common.Core.Utils.IsEmpty(cur))
                        {
                            continue;
                        }
                        double dCur;
                        if (double.TryParse(cur.ToString(), out dCur))
                        {
                            sum += dCur;
                        }
                    }
                }

                // get Sum of refColumn
                double sumFull = AvrViewHelper.GetColumnSum(data, rowCols.Count, view.GrandTotalSuffix, view.TotalSuffix, aggrColumn.SourceViewColumn, ref dict);

                if (sumFull != 0)
                {
                    ret = sum / sumFull;
                }
            }

            return ret;
        }

        // fill aggregate values into data column
        private static void FillGridAggrFColProcent(DataTable data, AvrViewColumn aggrColumn)
        {
            if (!bv.common.Core.Utils.IsEmpty(aggrColumn.SourceViewColumn) && data.Columns.Contains(aggrColumn.SourceViewColumn))
            {
                var view = aggrColumn.GetView();
                var rowCols = view.GetVisibleRowAdminColumns(true, null, false);
                // get Sum of refColumn
                double sumFull = AvrViewHelper.GetColumnSum(data, rowCols.Count, view.GrandTotalSuffix, view.TotalSuffix, aggrColumn.SourceViewColumn);
                if (sumFull != 0)
                {
                    double dCur;
                    foreach (DataRow row in data.Rows)
                    {
                        object cur = row[aggrColumn.SourceViewColumn];
                        if (!bv.common.Core.Utils.IsEmpty(cur) && double.TryParse(cur.ToString(), out dCur))
                        {
                            row[aggrColumn.UniquePath] = dCur / sumFull;
                        }
                    }
                }
            }
        }
        // returns one aggregate value
        private static object FillGridAggrFColProcent(DataTable data, int rowIndex, AvrViewColumn aggrColumn, ref Dictionary<int, object> dict)
        {
            object ret = DBNull.Value;

            if (!bv.common.Core.Utils.IsEmpty(aggrColumn.SourceViewColumn) && data.Columns.Contains(aggrColumn.SourceViewColumn))
            {
                double dCur;

                object cur = data.Rows[rowIndex][aggrColumn.SourceViewColumn];
                if (!bv.common.Core.Utils.IsEmpty(cur) && double.TryParse(cur.ToString(), out dCur))
                {
                    var view = aggrColumn.GetView();
                    var rowCols = view.GetVisibleRowAdminColumns(true, null, false);
                    // get Sum of refColumn
                    double sumFull = AvrViewHelper.GetColumnSum(data, rowCols.Count, view.GrandTotalSuffix, view.TotalSuffix, aggrColumn.SourceViewColumn, ref dict);

                    if (sumFull != 0)
                    {
                        ret = dCur / sumFull;
                    }
                }
            }

            return ret;
        }


        // fill aggregate values into data column
        private static void FillGridAggrFRowProcent(DataTable data, AvrViewColumn aggrColumn)
        {
            if (!bv.common.Core.Utils.IsEmpty(aggrColumn.SourceViewColumn) && data.Columns.Contains(aggrColumn.SourceViewColumn))
            {
                foreach (DataRow row in data.Rows)
                {
                    row[aggrColumn.UniquePath] = FillGridAggrFRowProcent(row, aggrColumn);
                }
            }
        }
        // returns one aggregate value
        private static object FillGridAggrFRowProcent(DataRow row, AvrViewColumn aggrColumn)
        {
            object ret = DBNull.Value;

            if (!bv.common.Core.Utils.IsEmpty(aggrColumn.SourceViewColumn) && row.Table.Columns.Contains(aggrColumn.SourceViewColumn))
            {

                double sum = 0;
                double dCol;

                var view = aggrColumn.GetView();
                object cur = row[aggrColumn.SourceViewColumn];
                if (!bv.common.Core.Utils.IsEmpty(cur) && double.TryParse(cur.ToString(), out dCol))
                {
                    // get Sum of rowIndex row inside parent band
                    aggrColumn.Owner.GetAllColumns().ToList().FindAll(col => !col.IsToDelete && !col.IsAggregate && col.IsVisible && col.FieldType.IsNumeric() &&
                                            !col.OriginalName.EndsWith(view.GrandTotalSuffix) && !col.OriginalName.EndsWith(view.TotalSuffix)).ForEach(c =>
                    {
                        double dCur;
                        cur = row[c.UniquePath];
                        if (!bv.common.Core.Utils.IsEmpty(cur) && double.TryParse(cur.ToString(), out dCur))
                            sum += dCur;
                    });
                    if (sum != 0)
                        ret = dCol / sum;
                }
            }

            return ret;
        }

        // fill aggregate values into data column
        private static void FillGridAggrFProportion(DataTable data, AvrViewColumn aggrColumn)
        {
            foreach (DataRow row in data.Rows)
            {
                row[aggrColumn.UniquePath] = FillGridAggrFProportion(row, aggrColumn.SourceViewColumn, aggrColumn.DenominatorViewColumn);
            }
        }
        // returns one aggregate value
        private static object FillGridAggrFProportion(DataRow row, string refColumn, string denominator)
        {
            object ret = DBNull.Value;

            if (!bv.common.Core.Utils.IsEmpty(refColumn) && !bv.common.Core.Utils.IsEmpty(denominator) && row.Table.Columns.Contains(refColumn) && row.Table.Columns.Contains(denominator))
            {
                double dRef;

                object cur = row[refColumn];
                if (!bv.common.Core.Utils.IsEmpty(cur) && double.TryParse(cur.ToString(), out dRef))
                {
                    cur = row[denominator];
                    double dDen;
                    if (!bv.common.Core.Utils.IsEmpty(cur) && double.TryParse(cur.ToString(), out dDen) && dDen != 0)
                    {
                        ret = dRef / dDen;
                    }
                }
            }

            return ret;
        }

        // fill aggregate values into data column
        private static void FillGridAggrFRatio(DataTable data, AvrViewColumn aggrColumn)
        {
            foreach (DataRow row in data.Rows)
            {
                row[aggrColumn.UniquePath] = FillGridAggrFRatio(row, aggrColumn);
            }
        }
        // returns one aggregate value
        private static object FillGridAggrFRatio(DataRow row, AvrViewColumn col)
        {
            object ret = DBNull.Value;

            if (!bv.common.Core.Utils.IsEmpty(col.SourceViewColumn) && !bv.common.Core.Utils.IsEmpty(col.DenominatorViewColumn) && row.Table.Columns.Contains(col.SourceViewColumn) && row.Table.Columns.Contains(col.DenominatorViewColumn))
            {
                double dRef;

                object cur = row[col.SourceViewColumn];
                if (!bv.common.Core.Utils.IsEmpty(cur) && double.TryParse(cur.ToString(), out dRef))
                {
                    cur = row[col.DenominatorViewColumn];
                    double dDen;
                    if (!bv.common.Core.Utils.IsEmpty(cur) && double.TryParse(cur.ToString(), out dDen))
                    {
                        ret = AvrViewHelper.GetRatio(dRef, dDen, col.Precision);
                    }
                }
            }

            return ret;
        }

        // fill aggregate values into data column
        private static void FillGridAggrFMinMax(DataTable data, bool max, AvrViewColumn aggrColumn)
        {
            foreach (DataRow row in data.Rows)
            {
                row[aggrColumn.UniquePath] = FillGridAggrFMinMax(row, max, aggrColumn);
            }
        }
        // returns one aggregate value
        private static object FillGridAggrFMinMax(DataRow row, bool max, AvrViewColumn aggrColumn)
        {
            object ret = DBNull.Value;
            var view = aggrColumn.GetView();

            DateTime? mmDt = null;
            double? mmN = null;
            foreach (var col in aggrColumn.Owner.GetAllColumns())
            {
                if (col.IsToDelete || col.IsAggregate || !col.IsVisible || !col.FieldType.IsNumeric() || col.OriginalName.EndsWith(view.GrandTotalSuffix) || col.OriginalName.EndsWith(view.TotalSuffix))
                    continue;

                object cur = row[col.UniquePath];
                if (bv.common.Core.Utils.IsEmpty(cur))
                {
                    continue;
                }

                double c;
                DateTime cd;
                if (double.TryParse(cur.ToString(), out c))
                {
                    if (mmN == null || (max && mmN < c) || (!max && mmN > c))
                    {
                        mmN = c;
                    }
                }
                else if (DateTime.TryParse(cur.ToString(), out cd))
                {
                    if (mmDt == null || (max && mmDt < cd) || (!max && mmDt > cd))
                    {
                        mmDt = cd;
                    }
                }
                else
                {
                }
            }
            if (mmDt != null && mmN == null)
            {
                ret = mmDt;
            }
            else if (mmN != null && mmDt == null)
            {
                ret = mmN;
            }

            return ret;
        }

        #endregion
    }
}