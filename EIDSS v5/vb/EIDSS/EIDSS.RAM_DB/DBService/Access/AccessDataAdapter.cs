using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using ADOX;
using bv.common;
using bv.common.Core;
using eidss.model.Resources;

namespace EIDSS.RAM_DB.DBService.Access
{
    public class AccessDataAdapter
    {
        private readonly string m_DBFileName;
        private readonly string m_ConnectionString;

        public AccessDataAdapter(string dbFileName)
        {
            Trace.WriteLine(Trace.Kind.Info, "AccessDataAdapter(): Creating DataAdapter for MS Access.");
            Utils.CheckNotNullOrEmpty(dbFileName, "dbFileName");
            m_DBFileName = dbFileName;
            m_ConnectionString = ComposeConnectionString(dbFileName);

            if (!File.Exists(dbFileName))
            {
                try
                {
                    CreateDataBase(m_ConnectionString);

//                    string tempFileName = string.Format(@"{0}{1}.mdb", Path.GetTempPath(), Guid.NewGuid());
//                    string tempConnectionString = ComposeConnectionString(tempFileName);
//                    CreateDataBase(tempConnectionString);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex);
                    throw new RamDbException(
                        string.Format(EidssMessages.Get("msgCannotCreateAccessDatabase"), dbFileName), ex);
                }
            }

            try
            {
                using (var connection = new OleDbConnection(m_ConnectionString))
                {
                    Trace.WriteLine(Trace.Kind.Undefine,
                                    "AccessDataAdapter(): Testing MS Access connection with connectionstring.",
                                    m_ConnectionString);
                    connection.Open();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                throw new RamDbException(
                    string.Format(EidssMessages.Get("msgCannotConnectToAccess"), m_DBFileName), ex);
            }
        }

        public string ComposeConnectionString(string dbFileName)
        {
            return string.Format("Data Source={0}; Provider=Microsoft.JET.OLEDB.4.0", dbFileName);
        }

        public string DbFileName
        {
            get { return m_DBFileName; }
        }

        public bool IsTableExistInAccess(string tableName)
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

        public void ExportTableToAccess(DataTable table)
        {
            Utils.CheckNotNull(table, "table");
            Utils.CheckNotNullOrEmpty(table.TableName, "table.TableName");
            if (table.Columns.Count == 0)
            {
                throw new RamDbException("Eporting table has no columns");
            }

            Trace.WriteLine(Trace.Kind.Info,
                            "AccessDataAdapter().ExportTableToAccess: Expotring table '{0}' to MS Access Database '{1}'.",
                            table.TableName, m_DBFileName);

            DataTable dataTable = ConvertTable(table);

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
                    throw new RamDbException(EidssMessages.Get("msgCannotExportToAccess"), ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        internal static DataTable ConvertTable(DataTable table)
        {
            DataTable dataTable = table.Copy();
            dataTable.TableName = AccessTypeConverter.CovertName(dataTable.TableName);
            var captions = new Dictionary<string, int>();
            foreach (DataColumn column in dataTable.Columns)
            {
                string caption = AccessTypeConverter.CovertName(column.Caption);
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

        internal static void CreateDataBase(string connectionString)
        {
            Trace.WriteLine(Trace.Kind.Info,
                            "AccessDataAdapter().CreateDataBase: Creating MS Access Database with connectionstring '{0}'.",
                            connectionString);

            var catalog = new CatalogClass();
            catalog.Create(connectionString);

            Marshal.ReleaseComObject(catalog);
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
                OleDbCommand command = connection.CreateCommand();
                command.Transaction = transaction;
                command.CommandText = string.Format("DROP TABLE {0}", tableName);
                command.ExecuteNonQuery();
            }
        }

        internal static void CreateTable(OleDbConnection connection, OleDbTransaction transaction, DataTable table)
        {
            Utils.CheckNotNull(connection, "connection");
            Utils.CheckNotNull(table, "table");
            Trace.WriteLine(Trace.Kind.Info, "AccessDataAdapter.CreateTable: Creating table '{0}'.", table.TableName);

            OleDbCommand command = connection.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = CreateTableCommandText(table);
            command.ExecuteNonQuery();
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

                sbCreate.AppendFormat("[{0}] {1}", column.ColumnName, dataTypeName);
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