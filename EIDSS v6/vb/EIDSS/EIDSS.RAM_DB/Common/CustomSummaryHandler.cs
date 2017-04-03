using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using bv.common;
using bv.common.Core;
using bv.common.db.Core;
using DevExpress.Data.PivotGrid;
using DevExpress.XtraPivotGrid;
using EIDSS;
using eidss.avr.db.AvrEventArgs.DevExpressEventArgsWrappers;
using eidss.avr.db.Interfaces;
using eidss.model.Avr.Pivot;
using eidss.model.Core;
using eidss.model.Resources;

namespace eidss.avr.db.Common
{
    public class CustomSummaryHandler
    {
        private readonly string m_Unsupported;
        private readonly IAvrPivotGridView m_AvrPivotGrid;
        private bool m_IsLookupException;

        public CustomSummaryHandler(IAvrPivotGridView avrPivotGrid)
        {
            Utils.CheckNotNull(avrPivotGrid, "ramPivotGrid");

            m_AvrPivotGrid = avrPivotGrid;

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

                if (ProcessMinSummary(e, ds, summaryType))
                {
                    return;
                }

                if (ProcessMaxSummary(e, ds, summaryType))
                {
                    return;
                }

                if (ProcessDistinctCountSummary(e, ds, summaryType))
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
            (BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds, CustomSummaryType summaryType)
        {
            if (summaryType != CustomSummaryType.Sum)
            {
                return false;
            }

            e.CustomValue = GetCountOrSum(e, ds);
            return true;
        }

        private static bool ProcessMinSummary
            (BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds, CustomSummaryType summaryType)
        {
            if (summaryType != CustomSummaryType.Min)
            {
                return false;
            }
            if (e.IsWeb || e.SummaryValue.Max is PivotErrorValue)
            {
                //this is because  e.SummaryValue is empty in web
                IEnumerable<IComparable> values = GetComparableValues(e, ds);
                e.CustomValue = values.Min();
            }
            else
            {
                e.CustomValue = e.SummaryValue.Min;
            }

            return true;
        }

        private static bool ProcessMaxSummary
            (BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds, CustomSummaryType summaryType)
        {
            if (summaryType != CustomSummaryType.Max)
            {
                return false;
            }

            if (e.IsWeb || e.SummaryValue.Max is PivotErrorValue)
            {
                //this is because  e.SummaryValue is empty in web
                IEnumerable<IComparable> values = GetComparableValues(e, ds);
                e.CustomValue = values.Max();
            }
            else
            {
                e.CustomValue = e.SummaryValue.Max;
            }

            return true;
        }

        private static bool ProcessDistinctCountSummary
            (BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds, CustomSummaryType summaryType)
        {
            if (summaryType != CustomSummaryType.DistinctCount)
            {
                return false;
            }

            int result = 0;
            if (ds.RowCount != 0)
            {
                // firstValue exists because we check ds.RowCount !=0 beefore

                object firstValue = null;
                for (int i = 0; i < ds.RowCount; i++)
                {
                    firstValue = ds[i][e.DataField];
                    if (firstValue != null)
                    {
                        break;
                    }
                }

                if (firstValue is string)
                {
                    result = GetDistinctCount<string>(e, ds);
                }
                else if (firstValue is int)
                {
                    result = GetDistinctCount<int>(e, ds);
                }
                else if (firstValue is long)
                {
                    result = GetDistinctCount<long>(e, ds);
                }
                else if (firstValue is decimal)
                {
                    result = GetDistinctCount<decimal>(e, ds);
                }
                else if (firstValue is float)
                {
                    result = GetDistinctCount<float>(e, ds);
                }
                else if (firstValue is double)
                {
                    result = GetDistinctCount<double>(e, ds);
                }
                else if (firstValue is IComparable)
                {
                    result = GetDistinctCount<IComparable>(e, ds);
                }
            }
            e.CustomValue = result;

            return true;
        }

        #region Process Statistics Summary

        private bool ProcessStatSummary
            (BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds, CustomSummaryType summaryType)
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
            (BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds, CustomSummaryType summaryType)
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
            int rowCount = m_AvrPivotGrid.RowAreaFields.Count;
            if (rowCount == 0)
            {
                values = GetStatCountValues(ds, e.DataField);
            }
            else
            {
                if (e.RowField == null)
                {
                    values = GetStatCountValues(ds, e.DataField, -1);
                }
                else
                {
                    // if current row is not total row, return count value
                    if (e.RowField.AreaIndex == rowCount - 1)
                    {
                        e.CustomValue = GetStatCountValues(ds, e.DataField).Sum();
                        return true;
                    }
                    // if current row is total, collection  should contains values as result of count aggregate function
                    values = GetStatCountValues(ds, e.DataField, e.RowField.AreaIndex);
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
            (BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds, CustomSummaryType summaryType)
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

            if (ds.RowCount == 0)
            {
                e.CustomValue = 0;
            }

            if (e.IsWeb || e.SummaryValue.Average is PivotErrorValue)
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

        private static ICollection<int> GetStatCountValues(PivotDrillDownDataSource ds, PivotGridFieldBase dataField)
        {
            var values = new List<int>();
            for (int i = 0; i < ds.RowCount; i++)
            {
                PivotDrillDownDataRow row = ds[i];
                int value = (row[dataField] == null) ? 0 : 1;
                values.Add(value);
            }
            return values;
        }

        private ICollection<int> GetStatCountValues(PivotDrillDownDataSource ds, PivotGridFieldBase dataField, int rowAreaIndex)
        {
            int index = m_AvrPivotGrid.RowAreaFields[rowAreaIndex + 1].Index;

            var valuesDictionary = new Dictionary<string, int>();

            for (int i = 0; i < ds.RowCount; i++)
            {
                PivotDrillDownDataRow row = ds[i];
                string key = (row[index] == null) ? string.Empty : row[index].ToString();
                if (!valuesDictionary.ContainsKey(key))
                {
                    valuesDictionary.Add(key, 0);
                }
                int value = (row[dataField] == null) ? 0 : 1;
                valuesDictionary[key] += value;
            }
            return valuesDictionary.Values;
        }

        private static double CalculateStatCustomValue(ICollection<double> values, CustomSummaryType summaryType)
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

        #endregion

        #region Process population statistics summary

        private bool ProcessPopulationSummary
            (BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds, CustomSummaryType summaryType)
        {
            if ((summaryType != CustomSummaryType.Pop10000) &&
                (summaryType != CustomSummaryType.Pop100000))
            {
                return false;
            }

            if (ds.RowCount == 0)
            {
                e.CustomValue = null;
                return true;
            }

            //Getting related Statistics Field
            var avrField = e.DataField as IAvrPivotGridField;
            if (avrField == null)
            {
                e.CustomValue = "Error: Data field should implement IAvrPivotGridField";
                return true;
            }
            string dateFieldName = avrField.GetSelectedDateFieldAlias();
            string unitFieldName = avrField.GetSelectedAdmFieldAlias();

            //  UnitField unitField = m_AvrPivotGrid.GetIdUnitFieldName(e.DataField.FieldName);

            //we take case date and gender from first row because in all rows case date has the same year and case gender is the same
            DateTime? datDateId = null;
            if (!string.IsNullOrEmpty(dateFieldName))

            {
                object dateObject = ds[0][dateFieldName];
                datDateId = (dateObject is DateTime) ? (DateTime?) dateObject : null;
            }

            uint statSum = 0;
            uint valSum = 0;

            var admUnitList = new List<string>();
            for (int i = 0; i < ds.RowCount; i++)
            {
                PivotDrillDownDataRow row = ds[i];
                if (!Utils.IsEmpty(row[e.DataField]))
                {
                    valSum++;
                }

                string strAdmUnitId = unitFieldName != null
                    ? Utils.Str(row[unitFieldName])
                    : string.Empty;
                if (string.IsNullOrEmpty(unitFieldName) || string.IsNullOrEmpty(strAdmUnitId))
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
                        e.CustomValue = null;
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
            (BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds, CustomSummaryType summaryType)
        {
            if (summaryType != CustomSummaryType.PopGender100000)
            {
                return false;
            }
            if (ds.RowCount == 0 || m_AvrPivotGrid.GenderField == null)
            {
                e.CustomValue = null;
                return true;
            }

            return ProcessPopulationGenderAndAgeGroupGenderSummary(e, ds, summaryType);
        }

        private bool ProcessPopulationAgeGroupGenderSummary
            (BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds, CustomSummaryType summaryType)
        {
            if (summaryType != CustomSummaryType.PopAgeGroupGender10000 &&
                summaryType != CustomSummaryType.PopAgeGroupGender100000)
            {
                return false;
            }
            if (ds.RowCount == 0 || m_AvrPivotGrid.AgeGroupField == null)
            {
                e.CustomValue = null;
                return true;
            }
            return ProcessPopulationGenderAndAgeGroupGenderSummary(e, ds, summaryType);
        }

        private bool ProcessPopulationGenderAndAgeGroupGenderSummary
            (BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds, CustomSummaryType summaryType)
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
                if (!Utils.IsEmpty(row[e.DataField]))
                {
                    valSum++;
                }
            }

            //Getting related Statistics Field
            //UnitField unitField = m_AvrPivotGrid.GetIdUnitFieldName(e.DataField.FieldName);
            var avrField = e.DataField as IAvrPivotGridField;
            if (avrField == null)
            {
                e.CustomValue = "Error: Data field should implement IAvrPivotGridField";
                return true;
            }
            string dateFieldName = avrField.GetSelectedDateFieldAlias();

            //we take case date and gender from first row because in all rows case date has the same year and case gender is the same
            DateTime? datDateId = null;
            if (!string.IsNullOrEmpty(dateFieldName))
            {
                object dateObject = ds[0][dateFieldName];
                datDateId = (dateObject is DateTime) ? (DateTime?) dateObject : null;
            }

            // get statistical information for first row  only (for other rows it is the same)
            string strGender = (m_AvrPivotGrid.GenderField != null)
                ? Utils.Str(ds[0][m_AvrPivotGrid.GenderField.FieldName])
                : string.Empty;
            uint statSum;
            if (summaryType == CustomSummaryType.PopGender100000)
            {
                statSum = GetPopulation(LookupTables.PopulationGenderStatistics, strGender, datDateId);
            }
            else
            {
                string strAgeGroup = (m_AvrPivotGrid.AgeGroupField != null)
                    ? Utils.Str(ds[0][m_AvrPivotGrid.AgeGroupField.FieldName])
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

        private void SetStatisticsResultIntoCustomValue(BasePivotGridCustomSummaryEventArgs e, double valueSum, uint statSum)
        {
            e.CustomValue = statSum == 0
                ? (object) null
                : valueSum / statSum;
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

        private bool TryGetSummaryType(BasePivotGridCustomSummaryEventArgs e, out CustomSummaryType summaryType)
        {
            var field = e.DataField as IAvrPivotGridField;
            if (field == null)
            {
                string message = EidssMessages.Get("msgPivotFieldTypeMistmatch", "Pivot Field should implement IAvrPivotGridField");
                e.CustomValue = string.Format(message, e.DataField.FieldName);
                summaryType = CustomSummaryType.DistinctCount;
                return false;
            }
            summaryType = field.CustomSummaryType;
            return true;
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

        private static IEnumerable<IComparable> GetComparableValues
            (BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds)
        {
            var values = new List<IComparable>();

            for (int i = 0; i < ds.RowCount; i++)
            {
                PivotDrillDownDataRow row = ds[i];
                if (row[e.DataField] != null)
                {
                    object value = row[e.DataField];
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
            (BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds)
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

        private static int GetDistinctCount<T>
            (BasePivotGridCustomSummaryEventArgs e, PivotDrillDownDataSource ds)
        {
            var values = new HashSet<T>();

            for (int i = 0; i < ds.RowCount; i++)
            {
                PivotDrillDownDataRow row = ds[i];
                if (row[e.DataField] != null)
                {
                    var item = (T) row[e.DataField];
                    if (!values.Contains(item))
                    {
                        values.Add(item);
                    }
                }
            }
            return values.Count;
        }

        #endregion
    }
}