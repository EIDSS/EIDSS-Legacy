using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Helpers;
using eidss.model.Schema;

namespace eidss.winclient.Reports
{
    public delegate double NumAggregateHandler(double sum, double val);

    public delegate string StrAggregateHanler(string columnName, DataRow actualRow, IEnumerable<DataRow> archiveRows);

    public class ArchiveDataHelper
    {
        private static int? m_RelevanceInterval;

        public static bool ShowUseArchiveDataCheckbox
        {
            get
            {
                bool hasPermission =
                    EidssUserContext.User.HasPermission(PermissionHelper.ExecutePermission(EIDSSPermissionObject.CanReadArchivedData));

                return !BaseFormManager.ArchiveMode && hasPermission && ArchiveSqlHelper.IsCredentialsCorrect();
            }
        }

        public static void MergeWithArchive
            (DataTable dataSource, DataTable archiveData, string[] keyName, string[] ignoreName,
                Dictionary<string, NumAggregateHandler> numFunctions,
                Dictionary<string, StrAggregateHanler> strFunctions)
        {
            if (keyName == null || keyName.Length == 0)
            {
                PlainMergeWithArchive(dataSource, archiveData);
            }
            else
            {
                SummaryMergeWithArchive(dataSource, archiveData, keyName, ignoreName, numFunctions, strFunctions);
            }
        }

        private static void PlainMergeWithArchive(DataTable dataSource, DataTable archiveData)
        {
            foreach (DataRow row in archiveData.Rows)
            {
                dataSource.ImportRow(row);
            }
        }

        private static void SummaryMergeWithArchive
            (DataTable dataSource, DataTable archiveData, string[] keyNames, string[] ignoreNames,
                Dictionary<string, NumAggregateHandler> numFunctions,
                Dictionary<string, StrAggregateHanler> strFunctions)
        {
            var isColumnsNumeric = new Dictionary<string, bool>();

            Utils.CheckNotNull(keyNames, "keyNames");

            if (ignoreNames == null)
            {
                ignoreNames = new string[0];
            }

            foreach (string keyName in keyNames)
            {
                if (!dataSource.Columns.Contains(keyName))
                {
                    throw new ArgumentException("Table doesn't contain column " + keyName);
                }
                if (!isColumnsNumeric.ContainsKey(keyName))
                {
                    DataColumn column = dataSource.Columns[keyName];
                    bool isInt = (column.DataType == typeof (int) ||
                                  column.DataType == typeof (uint) ||
                                  column.DataType == typeof (long) ||
                                  column.DataType == typeof (ulong) ||
                                  column.DataType == typeof (double) ||
                                  column.DataType == typeof (float) ||
                                  column.DataType == typeof (decimal));
                    isColumnsNumeric.Add(keyName, isInt);
                }
            }

            foreach (DataRow row in dataSource.Rows)
            {
                DataRow[] archiveRows = SelectRowsByKey(archiveData, row, isColumnsNumeric);

                foreach (DataColumn column in dataSource.Columns)
                {
                    column.ReadOnly = false;
                    string columnName = column.ColumnName;
                    if (IsAllNull(columnName, row, archiveRows) || keyNames.Contains(columnName) || ignoreNames.Contains(columnName))
                    {
                        continue;
                    }

                    NumAggregateHandler summaryFunction = numFunctions.ContainsKey(columnName)
                        ? numFunctions[columnName]
                        : ((s, item) => s + item);

                    StrAggregateHanler strFunction = strFunctions.ContainsKey(columnName)
                        ? strFunctions[columnName]
                        : ((name, r, aRow) => Utils.Str(r[name]));

                    if (column.DataType == typeof (string))
                    {
                        row[column] = strFunction(columnName, row, archiveRows);
                    }
                    if (column.DataType == typeof (int))
                    {
                        row[column] = (int) GetSummaryCellValues(columnName, row, archiveRows, summaryFunction);
                    }
                    else if (column.DataType == typeof (uint))
                    {
                        row[column] = (uint) GetSummaryCellValues(columnName, row, archiveRows, summaryFunction);
                    }
                    else if (column.DataType == typeof (long))
                    {
                        row[column] = (long) GetSummaryCellValues(columnName, row, archiveRows, summaryFunction);
                    }
                    else if (column.DataType == typeof (ulong))
                    {
                        row[column] = (ulong) GetSummaryCellValues(columnName, row, archiveRows, summaryFunction);
                    }
                    else if (column.DataType == typeof (double))
                    {
                        row[column] = GetSummaryCellValues(columnName, row, archiveRows, summaryFunction);
                    }
                    else if (column.DataType == typeof (float))
                    {
                        row[column] = (float) GetSummaryCellValues(columnName, row, archiveRows, summaryFunction);
                    }
                    else if (column.DataType == typeof (decimal))
                    {
                        row[column] = (decimal) GetSummaryCellValues(columnName, row, archiveRows, summaryFunction);
                    }
                }
            }

            foreach (DataRow archiveRow in archiveData.Rows)
            {
                DataRow[] sourceRows = SelectRowsByKey(dataSource, archiveRow, isColumnsNumeric);
                if (sourceRows.Length == 0)
                {
                    dataSource.ImportRow(archiveRow);
                }
            }
        }

        private static DataRow[] SelectRowsByKey
            (DataTable searchData, DataRow sourceRow, IEnumerable<KeyValuePair<string, bool>> isColumnNumeric)
        {
            var expressionBuilder = new StringBuilder();
            bool notFirst = false;
            foreach (KeyValuePair<string, bool> pair in isColumnNumeric)
            {
                if (notFirst)
                {
                    expressionBuilder.Append(" AND ");
                }
                notFirst = true;

                string columnName = pair.Key;
                object value = sourceRow[columnName];

                if ((value == null || value is DBNull))
                {
                    expressionBuilder.AppendFormat("{0} is NULL", columnName);
                }
                else
                {
                    // if column has numeric type
                    if (pair.Value)
                    {
                        expressionBuilder.AppendFormat("{0}={1}", columnName, value);
                    }
                    else
                    {
                        expressionBuilder.AppendFormat("{0}='{1}'", columnName, value.ToString().Replace("'", "''"));
                    }
                }
            }

            DataRow[] selectedRows = searchData.Select(expressionBuilder.ToString());
            return selectedRows;
        }

        private static double GetSummaryCellValues
            (string columnName, DataRow row, IEnumerable<DataRow> archiveRows, NumAggregateHandler summaryFunc)
        {
            if (!(row[columnName] is IConvertible))
            {
                throw new ArgumentException(@"Parameter row[column] should implement IConvertible");
            }

            if (summaryFunc == null)
            {
                throw new ArgumentNullException("summaryFunc");
            }

            IConvertible sourceCellValue = row[columnName] == DBNull.Value ? 0 : (IConvertible) row[columnName];
            var summaryList = new List<IConvertible> {sourceCellValue};

            foreach (DataRow archiveRow in archiveRows)
            {
                object value = archiveRow[columnName];
                if (value != DBNull.Value)
                {
                    summaryList.Add((IConvertible) value);
                }
            }

            double summary = 0;
            foreach (IConvertible value in summaryList)
            {
                summary = summaryFunc(summary, Convert.ToDouble(value));
            }
            return summary;
        }

        private static bool IsAllNull(string columnName, DataRow row, IEnumerable<DataRow> archiveRows)
        {
            if (row[columnName] != DBNull.Value)
            {
                return false;
            }

            return archiveRows.All(archiveRow => archiveRow[columnName] == DBNull.Value);
        }

        public static void ShowWarningIfDataInArchive(DbManagerProxy manager, DateTime startDate)
        {
            int interval = GetRelevanceInterval(manager);
            if (DateTime.Now.AddYears(-interval) > startDate)
            {
                if (!BaseFormManager.IsReportsServiceRunning && !BaseFormManager.IsAvrServiceRunning && !Utils.IsCalledFromUnitTest())
                {
                    ErrorForm.ShowWarning("msgDataInArchive",
                        "It is possible that some of the report data has been transferred to the archive. Such data are not included in the report.");
                }
            }
        }

        private static int GetRelevanceInterval(DbManagerProxy manager)
        {
            if (!m_RelevanceInterval.HasValue)
            {
                // if no interval set, let it be 1000 years ago
                m_RelevanceInterval = 1000;
                IObjectSelectDetail accessor = ObjectAccessor.SelectDetailInterface(typeof (DataArchiveSettings));
                if (accessor != null)
                {
                    var settings = (DataArchiveSettings) accessor.SelectDetail(manager, 0);
                    double interval;
                    if (Double.TryParse(settings.strDataRelevanceInterval, out interval))
                    {
                        m_RelevanceInterval = (int) interval;
                    }
                }
            }
            return m_RelevanceInterval.Value;
        }
    }
}