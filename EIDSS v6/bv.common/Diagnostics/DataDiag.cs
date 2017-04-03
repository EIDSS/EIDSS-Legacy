
using System.Data;
using System;
using System.Collections.Generic;
using System.Threading;
using bv.common.Core;


namespace bv.common.Diagnostics
{
    public class DataDiag
    {

        private DataDiag()
        {
            // NOOP
        }

        public static void DumpDataRowView(DataRowView rowView)
        {
            List<string> @out = new List<string>();
            foreach (DataColumn col in rowView.Row.Table.Columns)
            {
                @out.Add(string.Format("{0}:<{1}>", col.ColumnName, Dbg.FormatValue(rowView[col.ColumnName])));
            }
            Dbg.Debug("{0}", Utils.Join(", ", @out));
        }

        public static void DumpDataRow(DataRow row, DataRowVersion version)
        {
            List<string> @out = new List<string>();
            foreach (DataColumn col in row.Table.Columns)
            {
                @out.Add(string.Format("{0}:<{1}>", col.ColumnName, Dbg.FormatValue(row[col, version])));
            }
            Dbg.Debug("{0}: {1}", version, Utils.Join(", ", @out));
        }

        public static void DumpDataRow(DataRow row)
        {
            if (row.RowState != DataRowState.Deleted)
            {
                DumpDataRow(row, DataRowVersion.Current);
            }
            if (row.RowState == DataRowState.Modified || row.RowState == DataRowState.Deleted)
            {
                DumpDataRow(row, DataRowVersion.Original);
            }
        }

        public static void DumpDataTable(string name, DataTable table)
        {
            Dbg.Debug("dumping {0}", name);
            foreach (DataRow row in table.Rows)
            {
                Dbg.Debug("*** dumping row with state {0}", row.RowState);
                DumpDataRow(row);
            }
        }

        public static void DumpDataSet(string name, DataSet dataSet)
        {
            Dbg.Debug("dumping {0}", name);
            foreach (DataTable table in dataSet.Tables)
            {
                DumpDataTable(table.TableName, table);
            }
        }
        public static void PrintDataSetConstraintDiagnostics(DataSet dataSet)
        {
            Dbg.Debug("!!! got ConstraintException !!!");
            try
            {
                lock(dataSet)
                {
                    foreach (DataTable table in dataSet.Tables)
                    {
                        if (table.HasErrors)
                        {
                            Dbg.Debug("table with errors: {0}", table.TableName);
                            foreach (DataRow row in table.GetErrors())
                            {
                                Dbg.Debug("row: {0}", row);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Dbg.Debug("error during printing constraint diagnostic: {0}", ex.ToString());
            }
        }


    }
}
