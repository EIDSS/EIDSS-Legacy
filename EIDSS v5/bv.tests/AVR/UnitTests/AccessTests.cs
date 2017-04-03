using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Reflection;
using EIDSS.RAM_DB.DBService.Access;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.common.Core;
using bv.tests.AVR.Helpers;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class AccessTests
    {
        private const string TableName = @"tasLayout";

        private static string m_DbFilePath;
        

        private static string m_ConnectionString;

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string location = Path.GetDirectoryName(Utils.ConvertFileNane(asm.Location)) + @"\AVR";

            if (!Directory.Exists(location))
            {
                int index = location.IndexOf("DevelopersBranch", StringComparison.OrdinalIgnoreCase);
                if (index > 0)
                {
                    Directory.CreateDirectory(location);
                    string realPath = location.Substring(0, index) + @"DevelopersBranch\eidss.main\bin\Debug\AVR\db_test.mdb";
                    File.Copy(realPath, location + @"\db_test.mdb");
                }
            }
            m_DbFilePath = Utils.GetFilePathNearAssembly(asm, @"AVR\db_test.mdb");

            m_ConnectionString = string.Format(@"Data Source={0}; Provider=Microsoft.JET.OLEDB.4.0", m_DbFilePath);
        }

   

        [TestMethod]
        public void ConnectionTest()
        {
            Assert.IsTrue(File.Exists(m_DbFilePath), string.Format("File {0} doesn't exists", m_DbFilePath));
            using (var connection = new OleDbConnection(m_ConnectionString))
            {
                connection.Open();
                Console.WriteLine(connection.DataSource);
                Assert.AreEqual(connection.State, ConnectionState.Open);
            }
        }

        [TestMethod]
        public void CreateScriptsTest()
        {
            DataTable table = DataHelper.GenerateTestTable();
            table.TableName = TableName;
            string tableCommandText = AccessDataAdapter.CreateTableCommandText(table);
            Console.WriteLine(tableCommandText);
            Assert.AreEqual(
                @"CREATE TABLE [tasLayout](
[sflHC_PatientAge] DOUBLE,
[sflHC_PatientDOB] DATETIME,
[sflHC_CaseID] VARCHAR
)",
                tableCommandText);

            string selectCommandText = AccessDataAdapter.SelectCommandText(table);
            Console.WriteLine(selectCommandText);
            Assert.AreEqual(@"SELECT 
[sflHC_PatientAge],
[sflHC_PatientDOB],
[sflHC_CaseID]
FROM [tasLayout]", selectCommandText);

            string insertCommandText = AccessDataAdapter.InsertCommandText(table);
            Console.WriteLine(insertCommandText);
            Assert.AreEqual(@"INSERT INTO [tasLayout] (
[sflHC_PatientAge], 
[sflHC_PatientDOB], 
[sflHC_CaseID])
Values(
?, ?, ?)",
                            insertCommandText);
        }

        [TestMethod]
        public void ImportTableToAccessInternalTest()
        {
            using (var connection = new OleDbConnection(m_ConnectionString))
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
                    Assert.IsNotNull(schemaTable);
                    Assert.AreEqual(0, schemaTable.Rows.Count);

                    AccessDataAdapter.CreateTable(connection, transaction, table);

                    schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                                                                 new object[] {null, null, null, "TABLE"});
                    Assert.IsNotNull(schemaTable);
                    Assert.AreEqual(1, schemaTable.Rows.Count);
                    Assert.AreEqual(TableName, schemaTable.Rows[0]["TABLE_NAME"]);

                    AccessDataAdapter.InsertData(connection, transaction, table);

                    var dataSet = new DataSet();

                    using (var adapter = new OleDbDataAdapter())
                    {
                        adapter.SelectCommand = new OleDbCommand(AccessDataAdapter.SelectCommandText(table), connection)
                                                    {Transaction = transaction};
                        adapter.Fill(dataSet);
                        Assert.AreEqual(1, dataSet.Tables.Count);
                        Assert.AreEqual(10, dataSet.Tables[0].Rows.Count);
                    }

                    AccessDataAdapter.DropTableIfExists(connection, transaction, TableName);

                    schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                                                                 new object[] {null, null, null, "TABLE"});
                    Assert.IsNotNull(schemaTable);
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

        [TestMethod]
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
            Assert.AreEqual("sflHC_CaseID_Caption", dataTable.Columns[2].ColumnName);
            Assert.AreEqual("column3_Caption1", dataTable.Columns[3].ColumnName);
            Assert.AreEqual("column3_Caption2", dataTable.Columns[4].ColumnName);
            Assert.AreEqual("column4_Caption", dataTable.Columns[5].ColumnName);
            Assert.AreEqual("column3_Caption3", dataTable.Columns[6].ColumnName);
            Assert.AreEqual("column3_Caption4", dataTable.Columns[7].ColumnName);
        }

        private static void AddTestColumn(DataTable table, string name, string caption)
        {
            var column = new DataColumn(name) {Caption = caption, DataType = typeof (string)};
            table.Columns.Add(column);
        }

        [TestMethod]
        public void ConstructorAccessDataAdapterTest()
        {
            var adapter = new AccessDataAdapter(m_DbFilePath);
            Assert.AreEqual(m_DbFilePath, adapter.DbFileName);
        }

        [TestMethod]
        public void ImportTableToAccessTest()
        {
            var adapter = new AccessDataAdapter(m_DbFilePath);
            Assert.AreEqual(false, adapter.IsTableExistInAccess(TableName));

            DataTable table = DataHelper.GenerateTestTable();
            table.TableName = TableName;
            adapter.ExportTableToAccess(table);

            Assert.AreEqual(true, adapter.IsTableExistInAccess(TableName));

            using (var connection = new OleDbConnection(m_ConnectionString))
            {
                connection.Open();
                AccessDataAdapter.DropTableIfExists(connection, null, TableName);
            }
            Assert.AreEqual(false, adapter.IsTableExistInAccess(TableName));
        }

        [TestMethod]
        public void CreateDbTest()
        {
            string tempDbFilePath = m_DbFilePath.Replace(@"db_test.mdb", @"tmp_unit_test.mdb");
            if (File.Exists(tempDbFilePath))
            {
                File.Delete(tempDbFilePath);
            }
            AccessDataAdapter.CreateDataBase(string.Format(@"Data Source={0}; Provider=Microsoft.JET.OLEDB.4.0", tempDbFilePath));

            Assert.AreEqual(true, File.Exists(tempDbFilePath));
            Console.WriteLine(@"Database Created Successfully");

            var adapter = new AccessDataAdapter(tempDbFilePath);
            DataTable table = DataHelper.GenerateTestTable();
            table.TableName = TableName;
            adapter.ExportTableToAccess(table);
            Assert.AreEqual(true, adapter.IsTableExistInAccess(TableName));
        }
    }
}