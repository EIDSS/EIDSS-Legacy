#region Using

using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using EIDSS.RAM_DB.DBService.Access;
using EIDSS.Tests.RAM.Helpers;
using NUnit.Framework;

#endregion

namespace EIDSS.Tests.RAM.UnitTests
{
    [TestFixture]
    public class AccessTests
    {
        private const string DbFileName = @"RAM\\db_test.mdb";
        private const string TableName = @"tasLayout";

        private readonly string m_ConnectionString = string.Format("Data Source={0}; Provider=Microsoft.JET.OLEDB.4.0",
                                                                   DbFileName);


        [TearDown]
        public void TearDown()
        {
            GC.Collect();
        }
        [Test]
        public void ConnectionTest()
        {
            using (OleDbConnection connection = new OleDbConnection(m_ConnectionString))
            {
                connection.Open();
                Console.WriteLine(connection.DataSource);
                Assert.AreEqual(DbFileName, connection.DataSource);
                Assert.AreEqual(connection.State, ConnectionState.Open);
            }
        }

        [Test]
        public void CreateScriptsTest()
        {
            DataTable table = DataHelper.GenerateTestTable();
            table.TableName = TableName;
            string tableCommandText = AccessDataAdapter.CreateTableCommandText(table);
            Console.WriteLine(tableCommandText);
            Assert.AreEqual(@"CREATE TABLE [tasLayout](
[column1] LONG,
[column2] DATETIME,
[column3] VARCHAR
)", tableCommandText);

            string selectCommandText = AccessDataAdapter.SelectCommandText(table);
            Console.WriteLine(selectCommandText);
            Assert.AreEqual(@"SELECT 
[column1],
[column2],
[column3]
FROM [tasLayout]", selectCommandText);

            string insertCommandText = AccessDataAdapter.InsertCommandText(table);
            Console.WriteLine(insertCommandText);
            Assert.AreEqual(@"INSERT INTO [tasLayout] (
[column1], 
[column2], 
[column3])
Values(
?, ?, ?)", insertCommandText);
        }

        [Test]
        public void ImportTableToAccessInternalTest()
        {
            using (OleDbConnection connection = new OleDbConnection(m_ConnectionString))
            {
                DataTable table = DataHelper.GenerateTestTable();
                table.TableName = TableName;

                connection.Open();
                OleDbTransaction transaction = connection.BeginTransaction();
                try
                {
                    AccessDataAdapter.DropTableIfExists(connection, transaction, TableName);

                    DataTable schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                                                                           new object[] {null, null, null, "TABLE"});
                    Assert.AreEqual(0, schemaTable.Rows.Count);

                    AccessDataAdapter.CreateTable(connection, transaction, table);

                    schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                                                                 new object[] {null, null, null, "TABLE"});
                    Assert.AreEqual(1, schemaTable.Rows.Count);
                    Assert.AreEqual(TableName, schemaTable.Rows[0]["TABLE_NAME"]);

                    AccessDataAdapter.InsertData(connection, transaction, table);

                    DataSet dataSet = new DataSet();

                    using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                    {
                        adapter.SelectCommand = new OleDbCommand(AccessDataAdapter.SelectCommandText(table), connection);
                        adapter.SelectCommand.Transaction = transaction;
                        adapter.Fill(dataSet);
                        Assert.AreEqual(1, dataSet.Tables.Count);
                        Assert.AreEqual(10, dataSet.Tables[0].Rows.Count);
                    }

                    AccessDataAdapter.DropTableIfExists(connection, transaction, TableName);

                    schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                                                                 new object[] {null, null, null, "TABLE"});
                    Assert.AreEqual(0, schemaTable.Rows.Count);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        [Test]
        public void ConvertTableToAccessTest()
        {
            DataTable table = DataHelper.GenerateTestTable();
            table.TableName = TableName;

            AddTestColumn(table, "column4", "column3_Caption");
            AddTestColumn(table, "column5", "column3_Caption");

            AddTestColumn(table, "column6", "column4_Caption");

            AddTestColumn(table, "column7", "column3_Caption");
            AddTestColumn(table, "column8", "column3_Caption");

            DataTable dataTable = AccessDataAdapter.ConvertTable(table);
            Assert.AreEqual(8, dataTable.Columns.Count);
            Assert.AreEqual("column3_Caption1", dataTable.Columns[2].ColumnName);
            Assert.AreEqual("column3_Caption2", dataTable.Columns[3].ColumnName);
            Assert.AreEqual("column3_Caption3", dataTable.Columns[4].ColumnName);
            Assert.AreEqual("column4_Caption", dataTable.Columns[5].ColumnName);
            Assert.AreEqual("column3_Caption4", dataTable.Columns[6].ColumnName);
            Assert.AreEqual("column3_Caption5", dataTable.Columns[7].ColumnName);
        }

        private static void AddTestColumn(DataTable table, string name, string caption)
        {
            DataColumn column = new DataColumn(name);
            column.Caption = caption;
            column.DataType = typeof (string);
            table.Columns.Add(column);
        }
        [Test]
        public void ConstructorAccessDataAdapterTest()
        {
            AccessDataAdapter adapter = new AccessDataAdapter(DbFileName);
            Assert.AreEqual(DbFileName, adapter.DbFileName);
        }

      

        [Test]
        public void ImportTableToAccessTest()
        {
            AccessDataAdapter adapter = new AccessDataAdapter(DbFileName);
            Assert.AreEqual(false, adapter.IsTableExistInAccess(TableName));

            DataTable table = DataHelper.GenerateTestTable();
            table.TableName = TableName;
            adapter.ExportTableToAccess(table);

            Assert.AreEqual(true, adapter.IsTableExistInAccess(TableName));

            using (OleDbConnection connection = new OleDbConnection(m_ConnectionString))
            {
                connection.Open();
                AccessDataAdapter.DropTableIfExists(connection, null, TableName);
            }
            Assert.AreEqual(false, adapter.IsTableExistInAccess(TableName));
        }

        [Test]
        public void CreateDbTest()
        {
            //string newName = string.Format(@"tmp{0}.mdb", Guid.NewGuid());
            const string newName = "tmp_unit_test.mdb";
            if (File.Exists(newName))
            {
                File.Delete(newName);
            }
            AccessDataAdapter.CreateDataBase(string.Format("Data Source={0}; Provider=Microsoft.JET.OLEDB.4.0", newName));

            Assert.AreEqual(true, File.Exists(newName));
            Console.WriteLine(@"Database Created Successfully");

            AccessDataAdapter adapter = new AccessDataAdapter(newName);
            DataTable table = DataHelper.GenerateTestTable();
            table.TableName = TableName;
            adapter.ExportTableToAccess(table);
            Assert.AreEqual(true, adapter.IsTableExistInAccess(TableName));
        }
    }
}