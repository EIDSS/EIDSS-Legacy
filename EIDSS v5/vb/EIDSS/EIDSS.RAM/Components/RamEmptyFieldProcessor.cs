using System;
using System.Collections.Generic;
using DevExpress.XtraPivotGrid;
using EIDSS.RAM_DB.Components;
using bv.common.Core;

namespace EIDSS.RAM.Components
{
    public class RamEmptyFieldProcessor
    {
        private readonly Dictionary<int, Dictionary<string, object>> m_ColumnValues = new Dictionary<int, Dictionary<string, object>>();
        private readonly Dictionary<int, Dictionary<string, object>> m_RowValues = new Dictionary<int, Dictionary<string, object>>();

        private readonly int m_Year = DateTime.Now.Year;

        private readonly Dictionary<DayOfWeek, DateTime> m_DayOfWeek;
        private readonly DateTime[] m_WeekOfMonth;

        public RamEmptyFieldProcessor()
        {
            m_DayOfWeek = new Dictionary<DayOfWeek, DateTime>
                              {
                                  {DayOfWeek.Sunday, new DateTime(2012, 01, 01)},
                                  {DayOfWeek.Monday, new DateTime(2012, 01, 02)},
                                  {DayOfWeek.Tuesday, new DateTime(2012, 01, 03)},
                                  {DayOfWeek.Wednesday, new DateTime(2012, 01, 04)},
                                  {DayOfWeek.Thursday, new DateTime(2012, 01, 05)},
                                  {DayOfWeek.Friday, new DateTime(2012, 01, 06)},
                                  {DayOfWeek.Saturday, new DateTime(2012, 01, 07)}
                              };
            m_WeekOfMonth = new[]
                                {
                                    new DateTime(2012, 01, 01),
                                    new DateTime(2012, 01, 08),
                                    new DateTime(2012, 01, 15),
                                    new DateTime(2012, 01, 22),
                                    new DateTime(2012, 01, 29),
                                    new DateTime(2012, 01, 31)
                                };
        }

        public Dictionary<string, object> GetFieldValuesDictionary(PivotCellEventArgs cellInfo, int columnIndex, int rowIndex)
        {
            var fieldValues = new Dictionary<string, object>();

            AppendFieldValuesDictionary(cellInfo, fieldValues, columnIndex, true);

            AppendFieldValuesDictionary(cellInfo, fieldValues, rowIndex, false);

            return fieldValues;
        }

        private void AppendFieldValuesDictionary
            (PivotCellEventArgs cellInfo, Dictionary<string, object> fieldValues, int index, bool isColumn)
        {
            PivotGridField[] columnFields = isColumn
                                                ? cellInfo.GetColumnFields()
                                                : cellInfo.GetRowFields();
            Dictionary<int, Dictionary<string, object>> values = isColumn
                                                                     ? m_ColumnValues
                                                                     : m_RowValues;
            if (values.ContainsKey(index))
            {
                foreach (KeyValuePair<string, object> pair in values[index])
                {
                    fieldValues.Add(pair.Key, pair.Value);
                }
            }
            else
            {
                var newValues = new Dictionary<string, object>();
                foreach (PivotGridField field in columnFields)
                {
                    var winField = field as WinPivotGridField;
                    if (winField != null)
                    {
                        object value = cellInfo.GetFieldValue(winField) ?? DBNull.Value;
                        object result = winField.FieldDataType != typeof (DateTime) || Utils.IsEmpty(value) || value is DateTime
                                            ? value
                                            : ConvertDateIntervalToDateTime(value, winField.GroupInterval);

                        newValues.Add(winField.FieldName, result);
                        fieldValues.Add(winField.FieldName, result);
                    }
                }
                values.Add(index, newValues);
            }
        }

        private object ConvertDateIntervalToDateTime(object value, PivotGroupInterval interval)
        {
            switch (interval)
            {
                case PivotGroupInterval.DateDay:
                    if (value is int)
                    {
                        return new DateTime(m_Year, 01, (int) value);
                    }
                    break;
                case PivotGroupInterval.DateDayOfWeek:
                    if (value is DayOfWeek)
                    {
                        return m_DayOfWeek[(DayOfWeek) value];
                    }
                    break;
                case PivotGroupInterval.DateDayOfYear:
                    if (value is int)
                    {
                        return new DateTime(m_Year, 01, 01).AddDays((int) value - 1);
                    }
                    break;
                case PivotGroupInterval.DateMonth:
                    if (value is int)
                    {
                        return new DateTime(m_Year, (int) value, 01);
                    }
                    break;
                case PivotGroupInterval.DateQuarter:
                    if (value is int)
                    {
                        return new DateTime(m_Year, 01, 01).AddMonths(3 * (int) value - 3);
                    }
                    break;
                case PivotGroupInterval.DateWeekOfYear:
                    if (value is int)
                    {
                        //2009 year has 53 weeks, so let's use it
                        return new DateTime(2009, 01, 01).AddDays(7 * (int) value - 7);
                    }
                    break;
                case PivotGroupInterval.DateWeekOfMonth:
                    if (value is int)
                    {
                        return m_WeekOfMonth[(int) value - 1];
                    }
                    break;
                case PivotGroupInterval.DateYear:
                    if (value is int)
                    {
                        return new DateTime((int) value, 01, 01);
                    }
                    break;
            }
            return DBNull.Value;
        }
    }
}