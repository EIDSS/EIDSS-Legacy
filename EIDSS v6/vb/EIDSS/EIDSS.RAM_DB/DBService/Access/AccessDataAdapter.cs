using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using bv.common.Core;
using eidss.model.AVR.Db;
using eidss.model.Resources;
using Trace = bv.common.Trace;

namespace eidss.avr.db.DBService.Access
{
    public class AccessDataAdapter
    {
        private readonly string m_DBFileName;
        private readonly string m_ConnectionString;
        //Important!!
        //As I found OleDbCommand and OleDbDataReader  don't release resources after it's using.
        //Each OleDbCommand must be disposed exlicitly
        //Each OleDbDataReader must be closed and disposed exlicitly

        public AccessDataAdapter(string dbFileName)
        {
            WindowsLogHelper.WriteToEventLogWindows("Creating DataAdapter for MS Access", EventLogEntryType.Information);
            //Trace.WriteLine(Trace.Kind.Info, "AccessDataAdapter(): Creating DataAdapter for MS Access.");
            //Utils.CheckNotNullOrEmpty(dbFileName, "dbFileName");
            m_DBFileName = dbFileName;
            m_ConnectionString = ComposeConnectionString(dbFileName);
            WindowsLogHelper.WriteToEventLogWindows(String.Format("Connection String = {0}", m_ConnectionString),
                EventLogEntryType.Information);
            if (!File.Exists(dbFileName))
            {
                throw new ArgumentException(string.Format("File '{0}' not found.", dbFileName));
            }

            try
            {
                using (var connection = new OleDbConnection(m_ConnectionString))
                {
                    WindowsLogHelper.WriteToEventLogWindows("Testing MS Access connection with connectionstring",
                        EventLogEntryType.Information);

                    Trace.WriteLine(Trace.Kind.Undefine,
                        "AccessDataAdapter(): Testing MS Access connection with connectionstring.",
                        m_ConnectionString);
                    connection.Open();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                string errStr = String.Format(EidssMessages.Get("msgCannotConnectToAccess"), m_DBFileName);
                WindowsLogHelper.WriteToEventLogWindows(errStr, EventLogEntryType.Error);
                Trace.WriteLine(ex);
                throw new AvrDbException(errStr, ex);
            }
        }

        public static void QueryLineListToAccess(string fileName, DataTable originalTable, bool shouldModifyOriginalTable = true)
        {
            var adapter = new AccessDataAdapter(fileName);
            adapter.ExportTableToAccess(originalTable, shouldModifyOriginalTable);
        }

        internal string ComposeConnectionString(string dbFileName)
        {
            return string.Format("Data Source={0}; Provider=Microsoft.ACE.OLEDB.12.0;", dbFileName);
        }

        internal string DbFileName
        {
            get { return m_DBFileName; }
        }

        internal bool IsTableExistInAccess(string tableName)
        {
            Utils.CheckNotNullOrEmpty(tableName, "tableName");
            Trace.WriteLine(Trace.Kind.Undefine,
                "AccessDataAdapter.IsTableExistInAccess(): Checking is table '{0}' exists.", tableName);
            using (var connection = new OleDbConnection(m_ConnectionString))
            {
                connection.Open();
                bool isTableExist = IsTableExist(connection, null, tableName);
                connection.Close();
                return isTableExist;
            }
        }

        internal void ExportTableToAccess(DataTable originalTable, bool shouldModifyOriginalTable)
        {
            WindowsLogHelper.WriteToEventLogWindows("Start ExportTableToAccess", EventLogEntryType.Information);

            Utils.CheckNotNull(originalTable, "originalTable");

            string mess = String.Format("AccessDataAdapter().ExportTableToAccess: Exporting table '{0}' to MS Access Database '{1}'.",
                originalTable.TableName, m_DBFileName);
            WindowsLogHelper.WriteToEventLogWindows(mess, EventLogEntryType.Information);

            Trace.WriteLine(Trace.Kind.Info,
                "AccessDataAdapter().ExportTableToAccess: Exporting table '{0}' to MS Access Database '{1}'.",
                originalTable.TableName, m_DBFileName);

            DataTable dataTable = ConvertTable(originalTable, shouldModifyOriginalTable);

            using (var connection = new OleDbConnection(m_ConnectionString))
            {
                connection.Open();
                OleDbTransaction transaction = connection.BeginTransaction();
                try
                {
                    DropTableIfExists(connection, transaction, dataTable.TableName);
                    CreateTable(connection, transaction, dataTable);
                    InsertData(connection, transaction, dataTable);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex);
                    transaction.Rollback();
                    throw new AvrDbException(EidssMessages.Get("msgCannotExportToAccess"), ex);
                }
                finally
                {
                    connection.Close();
                    //Important!!
                    //Release connection pool here. In other case IIS may lock mdb file for downloading
                    //I didn't find how to do this better
                    Thread.Sleep(500);
                    OleDbConnection.ReleaseObjectPool();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                }
            }
        }

        internal static DataTable ConvertTable(DataTable originalTable, bool shouldModifyOriginalTable)
        {
            Utils.CheckNotNull(originalTable, "originalTable");
            if (originalTable.Columns.Count == 0)
            {
                throw new AvrDbException("Eporting table has no columns");
            }

            DataTable dataTable = shouldModifyOriginalTable
                ? originalTable
                : originalTable.Copy();

            if (string.IsNullOrEmpty(dataTable.TableName))
            {
                dataTable.TableName = "NO_NAME";
            }

            dataTable.TableName = AccessTypeConverter.ConvertName(dataTable.TableName);
            var captions = new Dictionary<string, int>();
            foreach (DataColumn column in dataTable.Columns)
            {
                string caption = AccessTypeConverter.ConvertName(column.Caption);
                column.Caption = caption;
                if (captions.ContainsKey(caption))
                {
                    captions[caption] ++;
                }
                else
                {
                    captions.Add(caption, 1);
                }
            }
            foreach (DataColumn column in dataTable.Columns)
            {
                string newName = column.Caption;
                if (captions[newName] > 1)
                {
                    int matches = 1;
                    for (int index = 0; index < column.Ordinal; index++)
                    {
                        if (dataTable.Columns[index].Caption == newName)
                        {
                            matches++;
                        }
                    }
                    newName += matches.ToString();
                }
                column.ColumnName = newName;
            }
            return dataTable;
        }

        internal static bool IsTableExist(OleDbConnection connection, OleDbTransaction transaction, string tableName)
        {
            Utils.CheckNotNull(connection, "connection");
            Utils.CheckNotNullOrEmpty(tableName, "tableName");

            DataTable schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                new object[] {null, null, null, "TABLE"});
            var dataView = new DataView(schemaTable)
            {
                RowFilter = string.Format("TABLE_NAME = '{0}'", tableName)
            };
            return dataView.Count > 0;
        }

        internal static void DropTableIfExists
            (OleDbConnection connection, OleDbTransaction transaction,
                string tableName)
        {
            Utils.CheckNotNull(connection, "connection");
            Utils.CheckNotNullOrEmpty(tableName, "tableName");

            bool isTableExists = IsTableExist(connection, transaction, tableName);
            if (isTableExists)
            {
                Trace.WriteLine(Trace.Kind.Info, "AccessDataAdapter.DropTableIfExists: Dropping table '{0}'.", tableName);
                using (OleDbCommand command = connection.CreateCommand())
                {
                    command.Transaction = transaction;
                    command.CommandText = string.Format("DROP TABLE {0}", tableName);
                    command.ExecuteNonQuery();
                }
            }
        }

        internal static void CreateTable(OleDbConnection connection, OleDbTransaction transaction, DataTable table)
        {
            Utils.CheckNotNull(connection, "connection");
            Utils.CheckNotNull(table, "table");
            Trace.WriteLine(Trace.Kind.Info, "AccessDataAdapter.CreateTable: Creating table '{0}'.", table.TableName);

            using (OleDbCommand command = connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandText = CreateTableCommandText(table);
                command.ExecuteNonQuery();
            }
        }

        internal static void InsertData(OleDbConnection connection, OleDbTransaction transaction, DataTable table)
        {
            Utils.CheckNotNull(connection, "connection");
            Utils.CheckNotNull(table, "table");

            Trace.WriteLine(Trace.Kind.Info, "AccessDataAdapter.InsertData: Inserting data into table '{0}'.",
                table.TableName);

            bool isTableExists = IsTableExist(connection, transaction, table.TableName);
            if (!isTableExists)
            {
                throw new ApplicationException(string.Format("Table {0} doesn't exist", table.TableName));
            }

            using (var adapter = new OleDbDataAdapter())
            {
                adapter.SelectCommand = new OleDbCommand(SelectCommandText(table), connection)
                {Transaction = transaction};
                adapter.InsertCommand = new OleDbCommand(InsertCommandText(table), connection)
                {Transaction = transaction};

                foreach (DataColumn column in table.Columns)
                {
                    OleDbType dbType = AccessTypeConverter.ConverTypeToDb(column);
                    OleDbParameter dbParameter = adapter.InsertCommand.Parameters.Add("@" + column.ColumnName, dbType);
                    dbParameter.SourceColumn = column.ColumnName;
                }

                var rowList = new List<DataRow>();
                foreach (DataRow row in table.Rows)
                {
                    if (row.RowState == DataRowState.Unchanged)
                    {
                        row.SetAdded();
                    }
                    rowList.Add(row);
                }
                adapter.Update(rowList.ToArray());
                adapter.SelectCommand.Dispose();
                adapter.InsertCommand.Dispose();
            }
        }

        #region command text 

        internal static string CreateTableCommandText(DataTable table)
        {
            Utils.CheckNotNull(table, "table");
            Utils.CheckNotNullOrEmpty(table.TableName, "table.TableName");

            var sbCreate = new StringBuilder(@"CREATE TABLE [");
            sbCreate.Append(table.TableName);
            sbCreate.AppendLine("](");
            bool isFirstColumn = true;
            foreach (DataColumn column in table.Columns)
            {
                if (!isFirstColumn)
                {
                    sbCreate.AppendLine(",");
                }
                isFirstColumn = false;
                string dataTypeName = AccessTypeConverter.ConvertTypeToDbName(column);

                string columnName = column.ColumnName;
//                if (columnName.Length > 64)
//                {
//                    columnName = columnName.Substring(0, 60) + Guid.NewGuid().ToString().Substring(0, 4);
//                }
                sbCreate.AppendFormat("[{0}] {1}", columnName, dataTypeName);
            }
            sbCreate.AppendLine();
            sbCreate.Append(")");
            return sbCreate.ToString();
        }

        internal static string SelectCommandText(DataTable table)
        {
            Utils.CheckNotNull(table, "table");
            Utils.CheckNotNullOrEmpty(table.TableName, "table.TableName");

            var sbCreate = new StringBuilder(@"SELECT ");
            sbCreate.AppendLine();
            bool isFirstColumn = true;
            foreach (DataColumn column in table.Columns)
            {
                if (!isFirstColumn)
                {
                    sbCreate.AppendLine(",");
                }
                isFirstColumn = false;
                sbCreate.AppendFormat("[{0}]", column.ColumnName);
            }
            sbCreate.AppendLine();
            sbCreate.AppendFormat("FROM [{0}]", table.TableName);
            return sbCreate.ToString();
        }

        internal static string InsertCommandText(DataTable table)
        {
            Utils.CheckNotNull(table, "table");
            Utils.CheckNotNullOrEmpty(table.TableName, "table.TableName");

            var sbCreate = new StringBuilder(string.Format(@"INSERT INTO [{0}] ", table.TableName));
            sbCreate.AppendLine("(");
            bool isFirstColumn = true;
            foreach (DataColumn column in table.Columns)
            {
                if (!isFirstColumn)
                {
                    sbCreate.AppendLine(", ");
                }
                isFirstColumn = false;
                sbCreate.AppendFormat("[{0}]", column.ColumnName);
            }
            sbCreate.AppendLine(")");
            sbCreate.AppendLine("Values(");
            for (int i = 0; i < table.Columns.Count; i++)
            {
                if (i > 0)
                {
                    sbCreate.Append(", ");
                }
                sbCreate.Append("?");
            }
            sbCreate.Append(")");

            return sbCreate.ToString();
        }

        #endregion
    }
}