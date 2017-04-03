using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using bv.common.Core;

namespace eidss.avr.Tools
{
    public class DistinctCounter : IDisposable
    {
        private DataTable m_SourceTable;
        private bool m_Disposed;

        public DistinctCounter()
        {
            m_SourceTable = new DataTable(@"Empty Table");
        }

        public DistinctCounter(DataTable sourceTable)
        {
           Utils.CheckNotNull(sourceTable, "sourceTable");
            m_SourceTable = sourceTable;
        }
        public int DistinctCount(IList<string> columnList, string filter)
        {
            if (m_Disposed)
                return 0;

            Utils.CheckNotNull(m_SourceTable, "sourceTable");
            Utils.CheckNotNull(columnList, "columnList");
            if (columnList.Count == 0)
            {
                return 0;
            }

            DataRow lastValue = m_SourceTable.NewRow();
            int result = 0;

            string fixedFilter = Regex.Replace(filter, "(\\[field)", "[");
            if (fixedFilter == "()")
            {
                fixedFilter = string.Empty;
            }
            string sort = GetSortExpression(m_SourceTable, columnList);

            DataRow[] selecterdRows = m_SourceTable.Select(fixedFilter, sort);
            foreach (DataRow row in selecterdRows)
            {
                bool areRowsEqual = RowsEqual(lastValue, row, columnList);
                if (areRowsEqual)
                {
                    continue;
                }

                lastValue = row;
                result++;
            }
            return result;
        }

        private static string GetSortExpression(DataTable sourceTable, IList<string> columnList)
        {
            var sorter = new StringBuilder();

            foreach (string column in columnList)
            {
                Utils.CheckNotNullOrEmpty(column, "columnName");
                if (!sourceTable.Columns.Contains(column))
                {
                    throw new ArgumentException("Table does not contain column " + column);
                }
            }

            int index = 0;
            foreach (string column in columnList)
            {
                if (index == columnList.Count - 1)
                {
                    sorter.Append(column);
                }
                else
                {
                    sorter.AppendFormat("{0}, ", column);
                }

                index++;
            }
            return sorter.ToString();
        }

        private static bool RowsEqual(DataRow a, DataRow b, IEnumerable<string> columnList)
        {
            bool areRowsEqual = true;
            foreach (string columnName in columnList)
            {
                if (!(CellsEqual(a[columnName], b[columnName])))
                {
                    areRowsEqual = false;
                    break;
                }
            }
            return areRowsEqual;
        }

        private static bool CellsEqual(object cellA, object cellB)
        {
            if (cellA == null && cellB == null) //  both are null
            {
                return true;
            }
            if (cellA == null || cellB == null) //  only one is null
            {
                return false;
            }

            if (cellA == DBNull.Value && cellB == DBNull.Value) //  both are DBNull.Value
            {
                return true;
            }
            if (cellA == DBNull.Value || cellB == DBNull.Value) //  only one is DBNull.Value
            {
                return false;
            }

            return (cellA.Equals(cellB)); // value type standard comparison
        }

       
        public void Dispose()
        {
            if (!m_Disposed)
            {
                m_SourceTable = null;
            }
            m_Disposed = true;

        }
    }
}