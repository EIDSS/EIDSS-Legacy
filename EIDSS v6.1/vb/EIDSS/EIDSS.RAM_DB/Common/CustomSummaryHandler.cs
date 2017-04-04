using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using bv.common;
using bv.common.Core;
using bv.common.db.Core;
using DevExpress.Data.PivotGrid;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Data;
using eidss.avr.db.AvrEventArgs.DevExpressEventArgsWrappers;
using eidss.avr.db.Interfaces;
using eidss.model.Avr.Pivot;
using eidss.model.AVR.SourceData;
using eidss.model.Core;
using eidss.model.Resources;
using EIDSS;

namespace eidss.avr.db.Common
{
    public class CustomSummaryHandler
    {
        private delegate bool ParserDelegate<T>(string s, out T result);

        private readonly string m_Unsupported;
        private readonly IAvrBasePivotGridView m_AvrPivotGrid;
        private readonly bool m_HasPopulationStatistics;
        private bool m_IsLookupException;

        public CustomSummaryHandler(IAvrBasePivotGridView avrPivotGrid)
        {
            Utils.CheckNotNull(avrPivotGrid, "avrPivotGrid");

            m_AvrPivotGrid = avrPivotGrid;

            DataView view = LookupCache.Get(LookupTables.PopulationStatistics);
            m_HasPopulationStatistics = view != null && view.Count > 0;

            m_Unsupported = EidssMessages.Get("strUnsupportedCustomAggregate", "Unsupported Aggregate Function");
        }

        #region Process Summary

        public void OnCustomSummary(object sender, BasePivotGridCustomSummaryEventArgs e)
        {
            try
            {
                if (m_AvrPivotGrid.LayoutRestoring)
                {
                    return;
                }

                if (!CheckDataIsAvrField(e))
                {
                    return;
                }

                PivotDrillDownDataSource ds = e.CreateDrillDownDataSource();

                if (ProcessSumSummary(e, ds))
                {
                    return;
                }

                if (ProcessMinSummary(e, ds))
                {
                    return;
                }

                if (ProcessMaxSummary(e, ds))
                {
                    return;
                }

                if (ProcessDistinctCountSummary(e, ds))
                {
                    return;
                }

                if (ProcessStatSummary(e, ds))
                {
                    return;
                }

                if (ProcessPopulationSummary(e, ds))
                {
                    return;
                }

                if (ProcessPopulationGenderSummary(e, ds))
                {
                    return;
                }

                if (ProcessPopulationAgeGroupGenderSummary(e, ds))
                {
                    return;
                }

                e.CustomValue = m_Unsupported;
            }
            catch (Exception ex)
            {
                e.CustomValue = ex;
                Trace.WriteLine(ex);
            }
        }

        private static bool ProcessSumSummary
            (BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds)
        {
            if (e.AggregateFunction != CustomSummaryType.Sum)
            {
                return false;
            }

            e.CustomValue = GetCountOrSum(e, ds);
            return true;
        }

        private static bool ProcessMinSummary
            (BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds)
        {
            if (e.AggregateFunction != CustomSummaryType.Min)
            {
                return false;
            }
            if (e.IsWeb || e.SummaryValue.Min is PivotErrorValue)
            {
                if (ds.RowCount != 0)
                {
                    object firstValue = GetFirstValue(e, ds);
                    IEnumerable<IComparable> values = GetComparableValues(e, ds, firstValue);
                    e.CustomValue = values.Min();
                }
            }
            else
            {
                e.CustomValue = e.SummaryValue.Min;
            }

            return true;
        }

        private static bool ProcessMaxSummary
            (BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds)
        {
            if (e.AggregateFunction != CustomSummaryType.Max)
            {
                return false;
            }

            if (e.IsWeb || e.SummaryValue.Max is PivotErrorValue)
            {
                //this is because  e.SummaryValue is empty in web
                if (ds.RowCount != 0)
                {
                    object firstValue = GetFirstValue(e, ds);
                    IEnumerable<IComparable> values = GetComparableValues(e, ds, firstValue);
                    e.CustomValue = values.Max();
                }
            }
            else
            {
                e.CustomValue = e.SummaryValue.Max;
            }

            return true;
        }

        private static IEnumerable<IComparable> GetComparableValues
            (BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds, object firstValue)
        {
            IEnumerable<IComparable> result = new BaseCollection<IComparable>();
            if (firstValue is String)
            {
                result = GetComparableValues<String>(e, ds);
            }
            else if (firstValue is Int64)
            {
                result = GetComparableValues(e, ds, (string s, out Int64 r) => Int64.TryParse(s, out r));
            }
            else if (firstValue is Int32)
            {
                result = GetComparableValues(e, ds, (string s, out Int32 r) => Int32.TryParse(s, out r));
            }
            else if (firstValue is Int16)
            {
                result = GetComparableValues(e, ds, (string s, out Int16 r) => Int16.TryParse(s, out r));
            }
            else if (firstValue is DateTime)
            {
                result = GetComparableValues(e, ds, (string s, out DateTime r) => DateTime.TryParse(s, out r));
            }
            else if (firstValue is Decimal)
            {
                result = GetComparableValues(e, ds, (string s, out Decimal r) => Decimal.TryParse(s, out r));
            }
            else if (firstValue is Double)
            {
                result = GetComparableValues(e, ds, (string s, out Double r) => Double.TryParse(s, out r));
            }
            else if (firstValue is Single)
            {
                result = GetComparableValues(e, ds, (string s, out Single r) => Single.TryParse(s, out r));
            }
            else if (firstValue is DayOfWeek)
            {
                result = GetComparableValues(e, ds, (string s, out DayOfWeek r) => Enum.TryParse(s, out r));
            }
            else if (firstValue is Boolean)
            {
                result = GetComparableValues(e, ds, (string s, out Boolean r) => Boolean.TryParse(s, out r));
            }
            else if (firstValue is UInt64)
            {
                result = GetComparableValues(e, ds, (string s, out UInt64 r) => UInt64.TryParse(s, out r));
            }
            else if (firstValue is UInt32)
            {
                result = GetComparableValues(e, ds, (string s, out UInt32 r) => UInt32.TryParse(s, out r));
            }
            else if (firstValue is UInt16)
            {
                result = GetComparableValues(e, ds, (string s, out UInt16 r) => UInt16.TryParse(s, out r));
            }
            else if (firstValue is Byte)
            {
                result = GetComparableValues(e, ds, (string s, out Byte r) => Byte.TryParse(s, out r));
            }
            else if (firstValue is SByte)
            {
                result = GetComparableValues(e, ds, (string s, out SByte r) => SByte.TryParse(s, out r));
            }
            else if (firstValue is IComparable)
            {
                result = GetComparableValues<IComparable>(e, ds);
            }
            return result;
        }

        private static IEnumerable<IComparable> GetComparableValues<T>
            (BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds, ParserDelegate<T> parser = null)
        {
            var values = new List<IComparable>();

            for (int i = 0; i < ds.RowCount; i++)
            {
                object data = ds[i][e.DataField];
                if (data != null)
                {
                    if (data.GetType() == typeof (T))
                    {
                        values.Add((IComparable) (T) data);
                    }
                    else if (parser != null)
                    {
                        T value;
                        if (parser(Utils.Str(data), out value))
                        {
                            values.Add((IComparable) value);
                        }
                    }
                }
            }
            return values;
        }

        private  bool ProcessDistinctCountSummary
            (BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds)
        {
            if (e.AggregateFunction != CustomSummaryType.DistinctCount)
            {
                return false;
            }

            long result = 0;
            if (ds.RowCount != 0)
            {
                if (m_AvrPivotGrid.SingleSearchObject)
                {
                    result = GetCount(e, ds);
                }
                else
                {
                    object firstValue = GetFirstValue(e, ds);
                    result = GetDistinctCount(e, ds, firstValue);
                }
            }
            e.CustomValue = result;

            return true;
        }

        private static long GetDistinctCount(BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds, object firstValue)
        {
            long result = 0;
            if (firstValue is String)
            {
                result = GetDistinctCount<String>(e, ds);
            }
            else if (firstValue is Int64)
            {
                result = GetDistinctCount(e, ds, (string s, out Int64 r) => Int64.TryParse(s, out r));
            }
            else if (firstValue is Int32)
            {
                result = GetDistinctCount(e, ds, (string s, out Int32 r) => Int32.TryParse(s, out r));
            }
            else if (firstValue is Int16)
            {
                result = GetDistinctCount(e, ds, (string s, out Int16 r) => Int16.TryParse(s, out r));
            }
            else if (firstValue is DateTime)
            {
                result = GetDistinctCount(e, ds, (string s, out DateTime r) => DateTime.TryParse(s, out r));
            }
            else if (firstValue is Decimal)
            {
                result = GetDistinctCount(e, ds, (string s, out Decimal r) => Decimal.TryParse(s, out r));
            }
            else if (firstValue is Double)
            {
                result = GetDistinctCount(e, ds, (string s, out Double r) => Double.TryParse(s, out r));
            }
            else if (firstValue is Single)
            {
                result = GetDistinctCount(e, ds, (string s, out Single r) => Single.TryParse(s, out r));
            }
           
            else if (firstValue is DayOfWeek)
            {
                result = GetDistinctCount(e, ds, (string s, out DayOfWeek r) => Enum.TryParse(s, out r));
            }
            else if (firstValue is Boolean)
            {
                result = GetDistinctCount(e, ds, (string s, out Boolean r) => Boolean.TryParse(s, out r));
            }
            else if (firstValue is UInt64)
            {
                result = GetDistinctCount(e, ds, (string s, out UInt64 r) => UInt64.TryParse(s, out r));
            }
            else if (firstValue is UInt32)
            {
                result = GetDistinctCount(e, ds, (string s, out UInt32 r) => UInt32.TryParse(s, out r));
            }
            else if (firstValue is UInt16)
            {
                result = GetDistinctCount(e, ds, (string s, out UInt16 r) => UInt16.TryParse(s, out r));
            }
            else if (firstValue is Byte)
            {
                result = GetDistinctCount(e, ds, (string s, out Byte r) => Byte.TryParse(s, out r));
            }
            else if (firstValue is SByte)
            {
                result = GetDistinctCount(e, ds, (string s, out SByte r) => SByte.TryParse(s, out r));
            }
            else if (firstValue is IComparable)
            {
                result = GetDistinctCount<IComparable>(e, ds);
            }
            return result;
        }

        private static long GetDistinctCount<T>
            (BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds, ParserDelegate<T> parser = null)
        {
            var values = new HashSet<T>();

            for (int i = 0; i < ds.RowCount; i++)
            {
                object data = ds[i][e.DataField];
                if (data != null)
                {
                    if (data.GetType() == typeof (T))
                    {
                        AddValueIfNotContains(values, (T) data);
                    }
                    else if (parser != null)
                    {
                        T value;
                        if (parser(Utils.Str(data), out value))
                        {
                            AddValueIfNotContains(values, value);
                        }
                    }
                }
            }
            return values.Count;
        }

        private static long GetCount(BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds)
        {
            int count = 0;
            if (!e.IsWeb)
            {
                count = e.SummaryValue.Count;
            }
            else
            {
                for (int i = 0; i < ds.RowCount; i++)
                {
                    PivotDrillDownDataRow row = ds[i];
                    if (!Utils.IsEmpty(row[e.DataField]))
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private static void AddValueIfNotContains<T>(HashSet<T> values, T value)
        {
            if (!values.Contains(value))
            {
                values.Add(value);
            }
        }

        #region Process Statistics Summary

        private bool ProcessStatSummary
            (BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds)
        {
            if ((e.AggregateFunction != CustomSummaryType.Average) &&
                (e.AggregateFunction != CustomSummaryType.StdDev) &&
                (e.AggregateFunction != CustomSummaryType.Variance))
            {
                return false;
            }

            if (ProcessNumericStatSummary(e, ds))
            {
                return true;
            }

            if (ProcessDefaultStatSummary(e, ds))
            {
                return true;
            }

            return false;
        }

        private static bool ProcessNumericStatSummary
            (BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds)
        {
            if (!e.IsDataFieldNumeric)
            {
                return false;
            }

            if ((e.AggregateFunction != CustomSummaryType.Average) &&
                (e.AggregateFunction != CustomSummaryType.StdDev) &&
                (e.AggregateFunction != CustomSummaryType.Variance))
            {
                return false;
            }

            if (ds.RowCount == 0)
            {
                e.CustomValue = 0;
            }

            if (e.IsWeb || e.SummaryValue.Average is PivotErrorValue)
            {
                //this is because  e.SummaryValue is empty in web
                List<object> objects = GetValues(e, ds);
                List<double> values = ConvertValuesToDouble(objects);
                e.CustomValue = CalculateStatCustomValue(values, e.AggregateFunction);
                return true;
            }
            switch (e.AggregateFunction)
            {
                case CustomSummaryType.Average:
                    e.CustomValue = e.SummaryValue.Average;
                    return true;
                case CustomSummaryType.StdDev:
                    e.CustomValue = e.SummaryValue.StdDev ?? 0;
                    return true;
                case CustomSummaryType.Variance:
                    double deviation = ValueConverter.GetValueFrom(e.SummaryValue.StdDev);
                    e.CustomValue = deviation * deviation;
                    return true;
            }
            return true;
        }

        private bool ProcessDefaultStatSummary
            (BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds)
        {
            if ((e.AggregateFunction != CustomSummaryType.Average) &&
                (e.AggregateFunction != CustomSummaryType.StdDev) &&
                (e.AggregateFunction != CustomSummaryType.Variance))
            {
                return false;
            }
            if (e.IsDataFieldNumeric)
            {
                return false;
            }

            var keyFields = new List<IAvrPivotGridField>();
            //index == 0  for grand total
            int colIndex = e.ColumnField == null ? 0 : e.ColumnField.AreaIndex + 1;
            for (int i = colIndex; i < m_AvrPivotGrid.ColumnAreaFields.Count; i++)
            {
                keyFields.Add(m_AvrPivotGrid.ColumnAreaFields[i]);
            }
            int rowIndex = e.RowField == null ? 0 : e.RowField.AreaIndex + 1;
            for (int i = rowIndex; i < m_AvrPivotGrid.RowAreaFields.Count; i++)
            {
                keyFields.Add(m_AvrPivotGrid.RowAreaFields[i]);
            }

            IEnumerable<long> values = GetStatCountOrDistinctCountValues(e, keyFields, ds);

            //note: LINQ may be too slow, so these calculations should not be converted into LINQ expression
            // ReSharper disable LoopCanBeConvertedToQuery
            var doubles = new List<double>();
            foreach (long value in values)
            {
                doubles.Add(value);
            }
            // ReSharper restore LoopCanBeConvertedToQuery
            e.CustomValue = CalculateStatCustomValue(doubles, e.AggregateFunction);

            return true;
        }

        private IEnumerable<long> GetStatCountOrDistinctCountValues
            (BasePivotGridCustomSummaryEventArgs e, List<IAvrPivotGridField> keyFields, PivotDrillDownDataSource ds)
        {
            Utils.CheckNotNull(e, "e");
            if (e.DataField == null)
            {
                throw new ArgumentException("e.DataField should not be NULL");
            }
            Utils.CheckNotNull(keyFields, "keyFields");
            Utils.CheckNotNull(ds, "ds");

            if (keyFields.Count == 0)
            {
                return new[] {GetCountOrDistinctCount(e, ds)};
            }

            return e.BasicCountFunctions == CustomSummaryType.DistinctCount
                ? GetStatDistinctCountValues(e.DataField, keyFields, ds)
                : GetStatCountValues(e.DataField, keyFields, ds);
        }

        private static IEnumerable<long> GetStatCountValues
            (PivotGridFieldBase dataField, List<IAvrPivotGridField> keyFields, PivotDrillDownDataSource ds)
        {
            var valuesDictionary = new Dictionary<string, long>();
            foreach (PivotDrillDownDataRow row in ds)
            {
                string key = GetKeyFromFields(keyFields, row);

                if (!valuesDictionary.ContainsKey(key))
                {
                    valuesDictionary.Add(key, 0);
                }
                int value = (row[dataField] == null) ? 0 : 1;
                valuesDictionary[key] += value;
            }
            return valuesDictionary.Values;
        }

        private static IEnumerable<long> GetStatDistinctCountValues
            (PivotGridFieldBase dataField, List<IAvrPivotGridField> keyFields, PivotDrillDownDataSource ds)
        {
            var valuesDictionary = new Dictionary<string, HashSet<string>>();
            foreach (PivotDrillDownDataRow row in ds)
            {
                string key = GetKeyFromFields(keyFields, row);
                if (!valuesDictionary.ContainsKey(key))
                {
                    valuesDictionary.Add(key, new HashSet<string>());
                }
                HashSet<string> valuesSet = valuesDictionary[key];
                string dataFieldValue = Utils.Str(row[dataField]);
                if (!string.IsNullOrEmpty(dataFieldValue) && !valuesSet.Contains(dataFieldValue))
                {
                    valuesSet.Add(dataFieldValue);
                }
            }
            return valuesDictionary.Values.Select(valuesSet => (long)valuesSet.Count);
        }

        private static string GetKeyFromFields(IList<IAvrPivotGridField> keyFields, PivotDrillDownDataRow row)
        {
            switch (keyFields.Count())
            {
                case 1:
                    return GetKeyFromField(keyFields[0],row);

                case 2:
                    return string.Format("{0}-{1}", GetKeyFromField(keyFields[0], row), GetKeyFromField(keyFields[1], row));

                case 3:
                    return string.Format("{0}-{1}-{2}",
                        GetKeyFromField(keyFields[0], row), GetKeyFromField(keyFields[1], row), GetKeyFromField(keyFields[2], row));

                default:
                    var keyBuilder = new StringBuilder();
                    foreach (IAvrPivotGridField keyField in keyFields)
                    {
                        keyBuilder.AppendFormat("{0}-", GetKeyFromField(keyField, row));
                    }
                    return keyBuilder.ToString();
            }
        }

        private static string GetKeyFromField(IAvrPivotGridField field, PivotDrillDownDataRow row)
        {
            object fieldValue = row[field.FieldName];
            if (field.IsDateTimeField && fieldValue is DateTime)
            {
                var date = ((DateTime)fieldValue);
                switch (field.GroupInterval)
                {
                    case PivotGroupInterval.DateYear:
                        fieldValue = date.Year;
                        break;
                    case PivotGroupInterval.DateMonth:
                        fieldValue =date.Month;
                        break;
                    case PivotGroupInterval.DateQuarter:
                        fieldValue = date.ToQuarter();
                        break;
                        // it doesn't matter which first day of week is set
                    case PivotGroupInterval.DateDayOfWeek:
                        fieldValue = date.DayOfWeek;
                        break;
                    case PivotGroupInterval.DateDayOfYear:
                        fieldValue = date.DayOfYear;
                        break;
                    case PivotGroupInterval.DateDay:
                        fieldValue = date.Day;
                        break;
                    case PivotGroupInterval.DateWeekOfYear:
                        fieldValue = DatePeriodHelper.GetWeekOfYear(date);
                        break;
                    case PivotGroupInterval.DateWeekOfMonth:
                        fieldValue = DatePeriodHelper.GetWeekOfMonth(date);
                        break;
                    default:
                        fieldValue = date;
                        break;
                }
            }
            return Utils.Str(fieldValue);
        }

        private static double CalculateStatCustomValue(ICollection<double> values, CustomSummaryType summaryType)
        {
            double sum = values.Sum();

            double average = (values.Count == 0) ? 0 : sum / values.Count;
            double displayValue = 0;
            //note: LINQ may be too slow, so these calculations should not be converted into LINQ expression
            // ReSharper disable LoopCanBeConvertedToQuery
            switch (summaryType)
            {
                case CustomSummaryType.Average:
                    displayValue = average;
                    break;

                case CustomSummaryType.StdDev:
                case CustomSummaryType.Variance:
                    double sumVariance = 0;
                    foreach (double value in values)
                    {
                        double delta = (value - average);
                        sumVariance += delta * delta;
                    }
                    double variance = (values.Count <= 1) ? 0 : sumVariance / (values.Count - 1);
                    displayValue = (summaryType == CustomSummaryType.StdDev) ? Math.Sqrt(variance) : variance;
                    break;
            }
            // ReSharper restore LoopCanBeConvertedToQuery
            return displayValue;
        }

        private static List<double> ConvertValuesToDouble(List<object> values)
        {
            var result = new List<double>();
            if (values.Count == 0)
            {
                return result;
            }

            //note: LINQ may be too slow, so these calculations should not be converted into LINQ expression
            // ReSharper disable LoopCanBeConvertedToQuery
            if (values[0] is Int16)
            {
                foreach (object value in values)
                {
                    result.Add((Int16) value);
                }
            }
            else if (values[0] is Int32)
            {
                foreach (object value in values)
                {
                    result.Add((Int32) value);
                }
            }
            else if (values[0] is Int64)
            {
                foreach (object value in values)
                {
                    result.Add((Int64) value);
                }
            }
            else if (values[0] is Decimal)
            {
                foreach (object value in values)
                {
                    result.Add((Double) (Decimal) value);
                }
            }
            else if (values[0] is Single)
            {
                foreach (object value in values)
                {
                    result.Add((Single) value);
                }
            }
            else if (values[0] is Double)
            {
                foreach (object value in values)
                {
                    result.Add((Double) value);
                }
            }

            else if (values[0] is UInt16)
            {
                foreach (object value in values)
                {
                    result.Add((UInt16) value);
                }
            }
            else if (values[0] is UInt32)
            {
                foreach (object value in values)
                {
                    result.Add((UInt32) value);
                }
            }
            else if (values[0] is UInt64)
            {
                foreach (object value in values)
                {
                    result.Add((UInt64) value);
                }
            }

            // ReSharper restore LoopCanBeConvertedToQuery
            return result;
        }

        #endregion

        #region Process population statistics summary

        private bool ProcessPopulationSummary(BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds)
        {
            if (!e.AggregateFunction.IsAdmUnit())
            {
                return false;
            }
            if (ds.RowCount == 0 || !m_HasPopulationStatistics)
            {
                e.CustomValue = null;
                return true;
            }

            long count = GetCountOrDistinctCount(e, ds);
            var avrField = (IAvrPivotGridField) e.DataField;

            DateTime? dateId = GetLastDate(avrField, ds);
            long statSum = 0;
            var admUnitList = new List<string>();
            string unitFieldName = avrField.GetSelectedAdmFieldAlias();

            // take whole statistic for the country if no adm unit selected
            if (string.IsNullOrEmpty(unitFieldName) || unitFieldName == AvrPivotGridFieldHelper.VirtualCountryFieldName)
            {
                string countryId = string.Format("{0} ({1})", EidssSiteContext.Instance.CountryName,
                    EidssSiteContext.Instance.CountryHascCode);
                statSum = GetPopulation(LookupTables.PopulationStatistics, countryId, dateId);
            }
            else
            {
                foreach (PivotDrillDownDataRow row in ds)
                {
                    string admUnitId = Utils.Str(row[unitFieldName]);
                    if (!admUnitList.Contains(admUnitId))
                    {
                        admUnitList.Add(admUnitId);
                    }
                }
                // if adm unit selected, but some data has no adm unit, then return null which will be displayed as "N/A"
                if (admUnitList.Contains(string.Empty))
                {
                    e.CustomValue = null;
                    return true;
                }
                foreach (string admUnitId in admUnitList)
                {
                    long nCurrentPopulation = GetPopulation(LookupTables.PopulationStatistics, admUnitId, dateId);
                    //Make sense to proceed only if Statistical information for the Administrative unit is present "N/A" otherwise
                    if (nCurrentPopulation != 0)
                    {
                        statSum += nCurrentPopulation;
                    }
                    else
                    {
                        e.CustomValue = null;
                        return true;
                    }
                }
            }

            int denominator = (e.AggregateFunction == CustomSummaryType.Pop10000)
                ? 10000
                : 100000;
            SetStatisticsResultIntoCustomValue(e, denominator * count, statSum);
            return true;
        }

        private bool ProcessPopulationGenderSummary(BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds)
        {
            if (e.AggregateFunction != CustomSummaryType.PopGender100000)
            {
                return false;
            }
            IAvrPivotGridField genderField = m_AvrPivotGrid.GenderField;
            if (ds.RowCount == 0 || genderField == null)
            {
                e.CustomValue = null;
                return true;
            }
            // in case gender field outside - get statistical information for first row  only (for other rows it is the same)
            string gender = IsKeyFieldOutside(e, genderField)
                ? "*"
                : Utils.Str(ds[0][genderField.FieldName]);

            DateTime? dateId = GetLastDate((IAvrPivotGridField) e.DataField, ds);
            long statSum = GetPopulation(LookupTables.PopulationGenderStatistics, gender, dateId);
            long count = GetCountOrDistinctCount(e, ds);
            SetStatisticsResultIntoCustomValue(e, 100000 * count, statSum);
            return true;
        }

        private bool ProcessPopulationAgeGroupGenderSummary
            (BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds)
        {
            if (e.AggregateFunction != CustomSummaryType.PopAgeGroupGender10000 &&
                e.AggregateFunction != CustomSummaryType.PopAgeGroupGender100000)
            {
                return false;
            }
            IAvrPivotGridField genderField = m_AvrPivotGrid.GenderField;
            IAvrPivotGridField ageGroupField = m_AvrPivotGrid.AgeGroupField;
            if (ds.RowCount == 0 || genderField == null || ageGroupField == null)
            {
                e.CustomValue = null;
                return true;
            }
            // in case gender field outside - get statistical information for first row  only (for other rows it is the same)
            string gender = IsKeyFieldOutside(e, genderField)
                ? "*"
                : Utils.Str(ds[0][genderField.FieldName]);
            string ageGroup = IsKeyFieldOutside(e, ageGroupField)
                ? "*"
                : Utils.Str(ds[0][ageGroupField.FieldName]);
            string key = string.Format("{0}_{1}", ageGroup, gender);

            DateTime? dateId = GetLastDate((IAvrPivotGridField) e.DataField, ds);
            long statSum = GetPopulation(LookupTables.PopulationAgeGroupGenderStatistics, key, dateId);

            long count = GetCountOrDistinctCount(e, ds);
            int denominator = (e.AggregateFunction == CustomSummaryType.PopAgeGroupGender10000)
                ? 10000
                : 100000;
            SetStatisticsResultIntoCustomValue(e, denominator * count, statSum);
            return true;
        }

        private static DateTime? GetLastDate(IAvrPivotGridField avrField, PivotDrillDownDataSource ds)
        {
            DateTime? result = null;
            string dateFieldName = avrField.GetSelectedDateFieldAlias();
            if (!string.IsNullOrEmpty(dateFieldName))
            {
                for (int i = 0; i < ds.RowCount; i++)
                {
                    object dateObject = ds[i][dateFieldName];
                    if (dateObject is DateTime)
                    {
                        var date = (DateTime) dateObject;
                        if (!result.HasValue || result.Value < date)
                        {
                            result = date;
                        }
                    }
                }
            }
            return result;
        }

        private  long GetCountOrDistinctCount(BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds)
        {
            long count;
            if (e.BasicCountFunctions == CustomSummaryType.DistinctCount && !m_AvrPivotGrid.SingleSearchObject)
            {
                object firstValue = GetFirstValue(e, ds);
                count = GetDistinctCount(e, ds, firstValue);
            }
            else
            {
                count = GetCount(e, ds);
            }
            return count;
        }

        private static bool IsKeyFieldOutside(BasePivotGridCustomSummaryEventArgs e, IAvrPivotGridField keyField)
        {
            switch (keyField.Area)
            {
                case PivotArea.RowArea:
                    return e.RowField == null || e.RowField.AreaIndex < keyField.AreaIndex;
                case PivotArea.ColumnArea:
                    return e.ColumnField == null || e.ColumnField.AreaIndex < keyField.AreaIndex;
                default:
                    return false;
            }
        }

        private static void SetStatisticsResultIntoCustomValue(BasePivotGridCustomSummaryEventArgs e, double valueSum, long statSum)
        {
            e.CustomValue = statSum == 0
                ? (object) null
                : valueSum / statSum;
        }

        private long GetPopulation(LookupTables tableId, string statKey, DateTime? statDate)
        {
            if (m_IsLookupException)
            {
                return 0;
            }

            try
            {
                string strPopulation = null;
                if (statDate.HasValue)
                {
                    string key = string.Format("{0}__{1:yyyy}", statKey, statDate);
                    strPopulation = LookupCache.GetLookupValue(key, tableId, "intValue");
                }
                // if no date defined or if no statistics found for given year
                if (Utils.IsEmpty(strPopulation))
                {
                    string key = string.Format("{0}__*", statKey);
                    strPopulation = LookupCache.GetLookupValue(key, tableId, "intValue");
                }
                return (Utils.IsEmpty(strPopulation))
                    ? 0
                    : Convert.ToInt64(strPopulation);
            }
            catch (Exception)
            {
                m_IsLookupException = true;
                throw;
            }
        }

        #endregion

        #endregion

        #region Helper methods

        private static bool CheckDataIsAvrField(BasePivotGridCustomSummaryEventArgs e)
        {
            if (e.DataField is IAvrPivotGridField)
            {
                return true;
            }

            string message = EidssMessages.Get("msgPivotFieldTypeMistmatch", "Pivot Field {0} should implement IAvrPivotGridField");
            e.CustomValue = string.Format(message, e.DataField.FieldName);
            return false;
        }

        private static object GetCountOrSum(BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds)
        {
            if (ds.RowCount == 0)
            {
                return 0;
            }
            if (!e.IsWeb)
            {
                if (!e.IsDataFieldNumeric)
                {
                    return e.SummaryValue.Count;
                }
                if (e.IsDataFieldNumeric && !(e.SummaryValue.Summary is PivotErrorValue))
                {
                    return e.SummaryValue.Summary;
                }
            }

            //this is because  e.SummaryValue is empty in web

            List<object> values = GetValues(e, ds);

            if (values.Count == 0)
            {
                return 0;
            }

            if (!e.IsDataFieldNumeric)
            {
                return values.Count;
            }

            //note: LINQ may be too slow, so these calculations should not be converted into LINQ expression
            // ReSharper disable LoopCanBeConvertedToQuery

            if (values[0] is Int16)
            {
                Int32 sum = 0;

                foreach (object value in values)
                {
                    sum += (Int16) value;
                }
                return sum;
            }
            if (values[0] is Int32)
            {
                Int64 sum = 0;

                foreach (object value in values)
                {
                    sum += (Int32) value;
                }
                return sum;
            }
            if (values[0] is Int64)
            {
                Int64 sum = 0;

                foreach (object value in values)
                {
                    sum += (Int64) value;
                }
                return sum;
            }

            if (values[0] is Decimal)
            {
                Decimal sum = 0;
                foreach (object value in values)
                {
                    sum += (Decimal) value;
                }
                return sum;
            }
            if (values[0] is Single)
            {
                Single sum = 0;
                foreach (object value in values)
                {
                    sum += (Single) value;
                }
                return sum;
            }
            if (values[0] is Double)
            {
                Double sum = 0;
                foreach (object value in values)
                {
                    sum += (Double) value;
                }
                return sum;
            }
            if (values[0] is UInt16)
            {
                UInt32 sum = 0;

                foreach (object value in values)
                {
                    sum += (UInt16) value;
                }
                return sum;
            }
            if (values[0] is UInt32)
            {
                UInt64 sum = 0;

                foreach (object value in values)
                {
                    sum += (UInt32) value;
                }
                return sum;
            }
            if (values[0] is UInt64)
            {
                UInt64 sum = 0;

                foreach (object value in values)
                {
                    sum += (UInt64) value;
                }
                return sum;
            }
            if (values[0] is Byte)
            {
                Int32 sum = 0;

                foreach (object value in values)
                {
                    sum += (Byte) value;
                }
                return sum;
            }
            if (values[0] is SByte)
            {
                Int32 sum = 0;

                foreach (object value in values)
                {
                    sum += (SByte) value;
                }
                return sum;
            }
            return 0;
            // ReSharper restore LoopCanBeConvertedToQuery
        }

        private static List<object> GetValues(BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds)
        {
            var values = new List<object>();

            for (int i = 0; i < ds.RowCount; i++)
            {
                PivotDrillDownDataRow row = ds[i];
                if (row[e.DataField] != null)
                {
                    values.Add(row[e.DataField]);
                }
            }
            return values;
        }

        private static object GetFirstValue(BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds)
        {
            object firstValue = null;
            for (int i = 0; i < ds.RowCount; i++)
            {
                firstValue = ds[i][e.DataField];
                if (firstValue != null)
                {
                    break;
                }
            }
            return firstValue;
        }

        #endregion
    }
}