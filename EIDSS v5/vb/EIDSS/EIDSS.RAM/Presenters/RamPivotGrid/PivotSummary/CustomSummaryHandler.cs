using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using DevExpress.XtraPivotGrid;
using EIDSS.RAM_DB.Components;
using EIDSS.RAM_DB.Views;
using bv.common;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.db.Core;
using eidss.model.Core;
using eidss.model.Resources;

namespace EIDSS.RAM.Presenters.RamPivotGrid.PivotSummary
{
    public class CustomSummaryHandler
    {
        public static readonly string m_NumberFormat;
        private readonly string m_NoStatInfo;
        private readonly string m_Unsupported;
        private readonly IRamPivotGridView m_RamPivotGrid;
        private bool m_IsLookupException;

        static CustomSummaryHandler()
        {
            string separator = NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator;
            string format = Config.GetSetting("AvrNumericFormat");
            m_NumberFormat = string.Format(string.IsNullOrEmpty(format) ? "0{0}00" : format, separator);
        }

        public CustomSummaryHandler(IRamPivotGridView ramPivotGrid)
        {
            Utils.CheckNotNull(ramPivotGrid, "ramPivotGrid");

            m_RamPivotGrid = ramPivotGrid;
            m_NoStatInfo = EidssMessages.Get("strNoStatsCustomAggregate", "No information");
            m_Unsupported = EidssMessages.Get("strUnsupportedCustomAggregate", "Unsupported Aggregate Function");

            NameSummaryTypeDictionary = new Dictionary<string, CustomSummaryType>();
        }

        #region properties

        public Dictionary<string, CustomSummaryType> NameSummaryTypeDictionary { get; set; }

        public static string NumberFormat
        {
            get { return m_NumberFormat; }
        }

        #endregion

        #region Process Summary

        public void OnCustomSummary(object sender, PivotGridCustomSummaryEventArgsWrapper e)
        {
            try
            {
                if (m_RamPivotGrid.LayoutRestoring)
                {
                    return;
                }

                CustomSummaryType summaryType;
                if (!TryGetSummaryType(e, out summaryType))
                {
                    return;
                }

                PivotDrillDownDataSource ds = e.CreateDrillDownDataSource();

                if (ProcessSumSummary(e, ds, summaryType))
                {
                    return;
                }

                if (ProcessPercentSummary(e, ds, summaryType))
                {
                    return;
                }

                if (ProcessProportionSummary(e, ds, summaryType))
                {
                    return;
                }

                if (ProcessMinSummary(e, ds, summaryType))
                {
                    return;
                }

                if (ProcessMaxSummary(e, ds, summaryType))
                {
                    return;
                }

                if (ProcessStatSummary(e, ds, summaryType))
                {
                    return;
                }

                if (ProcessPopulationSummary(e, ds, summaryType))
                {
                    return;
                }

                if (ProcessPopulationGenderSummary(e, ds, summaryType))
                {
                    return;
                }

                if (ProcessPopulationAgeGroupGenderSummary(e, ds, summaryType))
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
            (PivotGridCustomSummaryEventArgsWrapper e, PivotDrillDownDataSource ds, CustomSummaryType summaryType)
        {
            if (summaryType != CustomSummaryType.Sum)
            {
                return false;
            }

            e.CustomValue = GetCountOrSum(e, ds);
            return true;
        }

        private static bool ProcessPercentSummary
            (PivotGridCustomSummaryEventArgsWrapper e, PivotDrillDownDataSource ds, CustomSummaryType summaryType)
        {
            if ((summaryType != CustomSummaryType.PercentOfColumn) &&
                (summaryType != CustomSummaryType.PercentOfRow))
            {
                return false;
            }

            e.CustomValue = GetCountOrSum(e, ds);
            return true;
        }

        private static bool ProcessProportionSummary
            (PivotGridCustomSummaryEventArgsWrapper e, PivotDrillDownDataSource ds, CustomSummaryType summaryType)
        {
            if ((summaryType != CustomSummaryType.Proportion))
            {
                return false;
            }

            e.CustomValue = GetCountOrSum(e, ds);
            return true;
        }

        private static bool ProcessMinSummary
            (PivotGridCustomSummaryEventArgsWrapper e, PivotDrillDownDataSource ds, CustomSummaryType summaryType)
        {
            if (summaryType != CustomSummaryType.Min)
            {
                return false;
            }
            if (e.IsWeb)
            {
                //this is because  e.SummaryValue is empty in web
                IEnumerable<IComparable> values = GetComparableValues(e, ds);
                e.CustomValue = FormatCustomValue(e, values.Min());
            }
            else
            {
                e.CustomValue = FormatCustomValue(e, e.SummaryValue.Min);
            }

            return true;
        }

        private static bool ProcessMaxSummary
            (PivotGridCustomSummaryEventArgsWrapper e, PivotDrillDownDataSource ds, CustomSummaryType summaryType)
        {
            if (summaryType != CustomSummaryType.Max)
            {
                return false;
            }

            if (e.IsWeb)
            {
                //this is because  e.SummaryValue is empty in web
                IEnumerable<IComparable> values = GetComparableValues(e, ds);
                e.CustomValue = FormatCustomValue(e, values.Max());
            }
            else
            {
                e.CustomValue = FormatCustomValue(e, e.SummaryValue.Max);
            }

            return true;
        }

        #region Process Statistics Summary

        private bool ProcessStatSummary
            (PivotGridCustomSummaryEventArgsWrapper e, PivotDrillDownDataSource ds, CustomSummaryType summaryType)
        {
            if ((summaryType != CustomSummaryType.Average) &&
                (summaryType != CustomSummaryType.StdDev) &&
                (summaryType != CustomSummaryType.Variance))
            {
                return false;
            }

            if (ProcessNumericStatSummary(e, ds, summaryType))
            {
                return true;
            }

            if (ProcessDefaultStatSummary(e, ds, summaryType))
            {
                return true;
            }

            return false;
        }

        private bool ProcessDefaultStatSummary
            (PivotGridCustomSummaryEventArgsWrapper e, PivotDrillDownDataSource ds, CustomSummaryType summaryType)
        {
            if ((summaryType != CustomSummaryType.Average) &&
                (summaryType != CustomSummaryType.StdDev) &&
                (summaryType != CustomSummaryType.Variance))
            {
                return false;
            }

            if (e.IsDataFieldNumeric)
            {
                return false;
            }

            ICollection<int> values;

            // if no row fields found, collection should contains values as result of count aggregate function
            int rowCount = m_RamPivotGrid.RowAreaFields.Count;
            if (rowCount == 0)
            {
                values = GetStatCountValues(ds, e.DataField.Index);
            }
            else
            {
                if (e.RowField == null)
                {
                    values = GetStatCountValues(ds, e.DataField.Index, -1);
                }
                else
                {
                    // if current row is not total row, return count value
                    if (e.RowField.AreaIndex == rowCount - 1)
                    {
                        e.CustomValue = GetStatCountValues(ds, e.DataField.Index).Sum().ToString(NumberFormat);
                        return true;
                    }
                    // if current row is total, collection  should contains values as result of count aggregate function
                    values = GetStatCountValues(ds, e.DataField.Index, e.RowField.AreaIndex);
                }
            }
            //note: LINQ may be too slow, so these calculations should not be converted into LINQ expression
            // ReSharper disable LoopCanBeConvertedToQuery
            var doubles = new List<double>();
            foreach (int value in values)
            {
                doubles.Add(value);
            }
            // ReSharper restore LoopCanBeConvertedToQuery
            e.CustomValue = CalculateStatCustomValue(doubles, summaryType);

            return true;
        }

        private static bool ProcessNumericStatSummary
            (PivotGridCustomSummaryEventArgsWrapper e, PivotDrillDownDataSource ds, CustomSummaryType summaryType)
        {
            if (!e.IsDataFieldNumeric)
            {
                return false;
            }

            if ((summaryType != CustomSummaryType.Average) &&
                (summaryType != CustomSummaryType.StdDev) &&
                (summaryType != CustomSummaryType.Variance))
            {
                return false;
            }

            if (e.IsWeb)
            {
                //this is because  e.SummaryValue is empty in web
                List<object> objects = GetValues(e, ds);
                List<double> values = ConvertValuesToDouble(objects);
                e.CustomValue = CalculateStatCustomValue(values, summaryType);
                return true;
            }
            switch (summaryType)
            {
                case CustomSummaryType.Average:
                    e.CustomValue = ValueToString(e.SummaryValue.Average);
                    return true;
                case CustomSummaryType.StdDev:
                    e.CustomValue = ValueToString(e.SummaryValue.StdDev ?? 0);
                    return true;
                case CustomSummaryType.Variance:
                    double deviation = DisplayTextHandler.GetValueFrom(e.SummaryValue.StdDev);
                    e.CustomValue = ValueToString(deviation * deviation);
                    return true;
            }
            return true;
        }

        private static ICollection<int> GetStatCountValues(PivotDrillDownDataSource ds, int dataFieldIndex)
        {
            var values = new List<int>();
            for (int i = 0; i < ds.RowCount; i++)
            {
                PivotDrillDownDataRow row = ds[i];
                int value = (row[dataFieldIndex] == null) ? 0 : 1;
                values.Add(value);
            }
            return values;
        }

        private ICollection<int> GetStatCountValues(PivotDrillDownDataSource ds, int dataFieldIndex, int rowAreaIndex)
        {
            int index = m_RamPivotGrid.RowAreaFields[rowAreaIndex + 1].Index;

            var valuesDictionary = new Dictionary<string, int>();

            for (int i = 0; i < ds.RowCount; i++)
            {
                PivotDrillDownDataRow row = ds[i];
                string key = (row[index] == null) ? string.Empty : row[index].ToString();
                if (!valuesDictionary.ContainsKey(key))
                {
                    valuesDictionary.Add(key, 0);
                }
                int value = (row[dataFieldIndex] == null) ? 0 : 1;
                valuesDictionary[key] += value;
            }
            return valuesDictionary.Values;
        }

        private static string CalculateStatCustomValue(ICollection<double> values, CustomSummaryType summaryType)
        {
            double sum = values.Sum();

            double average = (values.Count == 0) ? 0 : sum / values.Count;
            double displayValue = 0;
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
            return displayValue.ToString(NumberFormat);
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
            if (values[0] is int)
            {
                foreach (object value in values)

                {
                    result.Add((int) value);
                }
            }
            else if (values[0] is long)
            {
                foreach (object value in values)
                {
                    result.Add((long) value);
                }
            }
            else if (values[0] is decimal)
            {
                foreach (object value in values)
                {
                    result.Add((double) (decimal) value);
                }
            }
            else if (values[0] is float)
            {
                foreach (object value in values)
                {
                    result.Add((float) value);
                }
            }
            else if (values[0] is double)
            {
                foreach (object value in values)
                {
                    result.Add((double) value);
                }
            }
            // ReSharper restore LoopCanBeConvertedToQuery
            return result;
        }

        private static string ValueToString(object value)
        {
            if ((value is double) || (value is float))
            {
                return ((double) value).ToString(NumberFormat);
            }
            if (value is decimal)
            {
                return ((decimal) value).ToString(NumberFormat);
            }
            if (value is int)
            {
                return ((int) value).ToString(NumberFormat);
            }
            return (value == null) ? string.Empty : value.ToString();
        }

        #endregion

        #region Process population statistics summary

        private bool ProcessPopulationSummary
            (PivotGridCustomSummaryEventArgsWrapper e, PivotDrillDownDataSource ds, CustomSummaryType summaryType)
        {
            if ((summaryType != CustomSummaryType.Pop10000) &&
                (summaryType != CustomSummaryType.Pop100000))
            {
                return false;
            }

            if (ds.RowCount == 0)
            {
                e.CustomValue = m_NoStatInfo;
                return true;
            }

            //Getting related Statistics Field
            UnitField unitField = m_RamPivotGrid.GetIdUnitFieldName(e.DataField.FieldName);

            //we take case date and gender from first row because in all rows case date has the same year and case gender is the same
            DateTime? datDateId = null;

            if (unitField.DateFieldName != null)
            {
                object dateObject = ds[0][unitField.DateFieldName];
                datDateId = (dateObject is DateTime) ? (DateTime?) dateObject : null;
            }

            uint statSum = 0;
            uint valSum = 0;

            var admUnitList = new List<string>();
            for (int i = 0; i < ds.RowCount; i++)
            {
                PivotDrillDownDataRow row = ds[i];
                if (!Utils.IsEmpty(row[e.DataField.Index]))
                {
                    valSum++;
                }

                string strAdmUnitId = unitField.UnitFieldName != null
                                          ? Utils.Str(row[unitField.UnitFieldName])
                                          : string.Empty;
                if (unitField.UnitFieldName == null || string.IsNullOrEmpty(strAdmUnitId))
                {
                    // take whole statistic for the country if no adm unit selected
                    // it shouldn't be done each iteration of the cycle, firs one will be enought
                    if (statSum == 0)
                    {
                        string countryId = string.Format("{0} ({1})", EidssSiteContext.Instance.CountryName,
                                                         EidssSiteContext.Instance.CountryHascCode);
                        statSum = GetPopulation(LookupTables.PopulationStatistics, countryId, datDateId);
                    }
                }
                else if (!admUnitList.Contains(strAdmUnitId))
                {
                    //We have name of the field containing Rayon or whatever the hellID we have chosen as a demoninator (stridUnitFieldName)
                    //All that's left is to figure out where the hell do we get Population related to this ID
                    admUnitList.Add(strAdmUnitId);
                    uint nCurrentPopulation = GetPopulation(LookupTables.PopulationStatistics, strAdmUnitId, datDateId);

                    //Make sense to proceed only if Statistical information for the Administrative unit is present
                    //"No information" otherwise
                    if (nCurrentPopulation != 0)
                    {
                        statSum += nCurrentPopulation;
                    }
                    else
                    {
                        e.CustomValue = m_NoStatInfo;
                        return true;
                    }
                }
            }
            int denominator = (summaryType == CustomSummaryType.Pop10000)
                                  ? 10000
                                  : 100000;
            SetStatisticsResultIntoCustomValue(e, denominator * valSum, statSum);
            return true;
        }

        private bool ProcessPopulationGenderSummary
            (PivotGridCustomSummaryEventArgsWrapper e, PivotDrillDownDataSource ds, CustomSummaryType summaryType)
        {
            if (summaryType != CustomSummaryType.PopGender100000)
            {
                return false;
            }
            if (ds.RowCount == 0 || m_RamPivotGrid.GenderField == null)
            {
                e.CustomValue = m_NoStatInfo;
                return true;
            }

            return ProcessPopulationGenderAndAgeGroupGenderSummary(e, ds, summaryType);
        }

        private bool ProcessPopulationAgeGroupGenderSummary
            (PivotGridCustomSummaryEventArgsWrapper e, PivotDrillDownDataSource ds, CustomSummaryType summaryType)
        {
            if (summaryType != CustomSummaryType.PopAgeGroupGender10000 &&
                summaryType != CustomSummaryType.PopAgeGroupGender100000)
            {
                return false;
            }
            if (ds.RowCount == 0 || m_RamPivotGrid.AgeGroupField == null)
            {
                e.CustomValue = m_NoStatInfo;
                return true;
            }
            return ProcessPopulationGenderAndAgeGroupGenderSummary(e, ds, summaryType);
        }

        private bool ProcessPopulationGenderAndAgeGroupGenderSummary
            (PivotGridCustomSummaryEventArgsWrapper e, PivotDrillDownDataSource ds, CustomSummaryType summaryType)
        {
            if (summaryType != CustomSummaryType.PopGender100000 &&
                summaryType != CustomSummaryType.PopAgeGroupGender10000 &&
                summaryType != CustomSummaryType.PopAgeGroupGender100000)
            {
                return false;
            }

            // no Administrative unit should be, because statistics by gender calculating by country
            // calculating count of rows with not null values
            uint valSum = 0;
            for (int i = 0; i < ds.RowCount; i++)
            {
                PivotDrillDownDataRow row = ds[i];
                if (!Utils.IsEmpty(row[e.DataField.Index]))
                {
                    valSum++;
                }
            }

            //Getting related Statistics Field
            UnitField unitField = m_RamPivotGrid.GetIdUnitFieldName(e.DataField.FieldName);

            //we take case date and gender from first row because in all rows case date has the same year and case gender is the same
            DateTime? datDateId = null;

            if (unitField.DateFieldName != null)
            {
                object dateObject = ds[0][unitField.DateFieldName];
                datDateId = (dateObject is DateTime) ? (DateTime?) dateObject : null;
            }

            // get statistical information for first row  only (for other rows it is the same)
            string strGender = (m_RamPivotGrid.GenderField != null)
                                   ? Utils.Str(ds[0][m_RamPivotGrid.GenderField])
                                   : string.Empty;
            uint statSum;
            if (summaryType == CustomSummaryType.PopGender100000)
            {
                statSum = GetPopulation(LookupTables.PopulationGenderStatistics, strGender, datDateId);
            }
            else
            {
                string strAgeGroup = (m_RamPivotGrid.AgeGroupField != null)
                                         ? Utils.Str(ds[0][m_RamPivotGrid.AgeGroupField])
                                         : string.Empty;
                if (string.IsNullOrEmpty(strGender))
                {
                    DataView genderView = LookupCache.Get(LookupTables.Sex);
                    statSum = 0;
                    foreach (DataRowView row in genderView)
                    {
                        strGender = row["name"].ToString();
                        string key = string.Format("{0}_{1}", strAgeGroup, strGender);
                        statSum += GetPopulation(LookupTables.PopulationAgeGroupGenderStatistics, key, datDateId);
                    }
                }
                else
                {
                    string key = string.Format("{0}_{1}", strAgeGroup, strGender);
                    statSum = GetPopulation(LookupTables.PopulationAgeGroupGenderStatistics, key, datDateId);
                }
            }
            int denominator = (summaryType == CustomSummaryType.PopAgeGroupGender10000)
                                  ? 10000
                                  : 100000;
            SetStatisticsResultIntoCustomValue(e, denominator * valSum, statSum);

            return true;
        }

        private void SetStatisticsResultIntoCustomValue(PivotGridCustomSummaryEventArgsWrapper e, double valueSum, uint statSum)
        {
            double fResult = 0;
            if (statSum == 0)
            {
                e.CustomValue = m_NoStatInfo;
                return;
            }

            fResult += valueSum / statSum;
            string result = Utils.Str(fResult);

            e.CustomValue = FormatCustomValue(e, result);
        }

        private uint GetPopulation(LookupTables tableId, string strAdmUnitId, DateTime? datDateId)
        {
            if (m_IsLookupException)
            {
                return 0;
            }

            try
            {
                string strPopulation = null;
                if (datDateId.HasValue)
                {
                    string key = string.Format("{0}__{1:yyyy}", strAdmUnitId, datDateId);
                    strPopulation = LookupCache.GetLookupValue(key, tableId, "intValue");
                }
                if (Utils.IsEmpty(strPopulation))
                {
                    strPopulation = LookupCache.GetLookupValue(strAdmUnitId, tableId, "intValue");
                }
                return (Utils.IsEmpty(strPopulation))
                           ? 0
                           : Convert.ToUInt32(strPopulation);
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

        private bool TryGetSummaryType(PivotGridCustomSummaryEventArgsWrapper e, out CustomSummaryType summaryType)
        {
            bool result = true;
            if (!NameSummaryTypeDictionary.TryGetValue(e.DataField.FieldName, out summaryType))
            {
                string message = EidssMessages.Get("msgCannotFindSummaryType",
                                                   "Cannot find summaryType type for column {0}");
                e.CustomValue = string.Format(message, e.DataField.FieldName);
                result = false;
            }
            return result;
        }

        private static object GetCountOrSum(PivotGridCustomSummaryEventArgsWrapper e, PivotDrillDownDataSource ds)
        {
            if (e.IsWeb)
            {
                //this is because  e.SummaryValue is empty in web
                List<object> values = GetValues(e, ds);

                if (!e.IsDataFieldNumeric)
                {
                    return values.Count;
                }

                if (values.Count == 0)
                {
                    return 0;
                }

                //note: LINQ may be too slow, so these calculations should not be converted into LINQ expression
                // ReSharper disable LoopCanBeConvertedToQuery
                if (values[0] is int)
                {
                    int sum = 0;

                    foreach (object value in values)

                    {
                        sum += (int) value;
                    }
                    return sum;
                }
                if (values[0] is long)
                {
                    long sum = 0;
                    foreach (object value in values)
                    {
                        sum += (long) value;
                    }
                    return sum;
                }
                if (values[0] is decimal)
                {
                    decimal sum = 0;
                    foreach (object value in values)
                    {
                        sum += (decimal) value;
                    }
                    return sum;
                }
                if (values[0] is float)
                {
                    float sum = 0;
                    foreach (object value in values)
                    {
                        sum += (float) value;
                    }
                    return sum;
                }
                if (values[0] is double)
                {
                    double sum = 0;
                    foreach (object value in values)
                    {
                        sum += (double) value;
                    }
                    return sum;
                }
                return 0;
                // ReSharper restore LoopCanBeConvertedToQuery
            }

            return e.IsDataFieldNumeric
                       ? e.SummaryValue.Summary
                       : e.SummaryValue.Count;
        }

        private static IEnumerable<IComparable> GetComparableValues
            (PivotGridCustomSummaryEventArgsWrapper e, PivotDrillDownDataSource ds)
        {
            var values = new List<IComparable>();
            int fieldIndex = e.DataField.Index;
            for (int i = 0; i < ds.RowCount; i++)
            {
                PivotDrillDownDataRow row = ds[i];
                if (row[fieldIndex] != null)
                {
                    object value = row[fieldIndex];
                    var comparable = value as IComparable;
                    if (comparable != null)
                    {
                        values.Add(comparable);
                    }
                }
            }
            return values;
        }

        private static List<object> GetValues
            (PivotGridCustomSummaryEventArgsWrapper e, PivotDrillDownDataSource ds)
        {
            var values = new List<object>();
            int fieldIndex = e.DataField.Index;
            for (int i = 0; i < ds.RowCount; i++)
            {
                PivotDrillDownDataRow row = ds[i];
                if (row[fieldIndex] != null)
                {
                    values.Add(row[fieldIndex]);
                }
            }
            return values;
        }

        private static object FormatCustomValue(PivotGridCustomSummaryEventArgsWrapper e, object result)
        {
            return (result != null) && (result is DateTime)
                       ? ((DateTime) result).ToString(e.DataField.GroupInterval)
                       : result;
        }

        #endregion
    }
}