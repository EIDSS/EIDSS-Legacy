using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using bv.common.Core;
using bv.tests.AVR.Helpers;
using eidss.avr.db.DBService.Access;
using eidss.model.AVR.SourceData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.AVR.IntegrationTests
{
    [TestClass]
    public class AccessTests
    {
        private const string TableName = @"tasLayout";

        private static string m_DbFilePath;

        private static string m_AccessConnectionString;

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            m_DbFilePath = GetAccessDbFilePath();
            m_AccessConnectionString = string.Format(@"Data Source={0}; Provider=Microsoft.JET.OLEDB.4.0", m_DbFilePath);
        }

        [TestMethod]
        public void ConnectionTest()
        {
            Assert.IsTrue(File.Exists(m_DbFilePath), string.Format("File {0} doesn't exists", m_DbFilePath));
            using (var connection = new OleDbConnection(m_AccessConnectionString))
            {
                connection.Open();
                Console.WriteLine(connection.DataSource);
                Assert.AreEqual(connection.State, ConnectionState.Open);
            }
        }

        [TestMethod]
        public void CreateScriptsTest()
        {
            AvrDataTable avrTable = new AvrDataTable(DataHelper.GenerateTestTable()) {TableName = TableName};
            RemoveCopyColumns(avrTable);

            string tableCommandText = AccessDataAdapter.CreateTableCommandText(avrTable);
            Console.WriteLine(tableCommandText);
            Assert.AreEqual(
                @"CREATE TABLE [tasLayout](
[sflHC_PatientAge] DOUBLE,
[sflHC_PatientDOB] DATETIME,
[sflHC_CaseID] VARCHAR
)",
                tableCommandText);

            string selectCommandText = AccessDataAdapter.SelectCommandText(avrTable);
            Console.WriteLine(selectCommandText);
            Assert.AreEqual(@"SELECT 
[sflHC_PatientAge],
[sflHC_PatientDOB],
[sflHC_CaseID]
FROM [tasLayout]", selectCommandText);

            string insertCommandText = AccessDataAdapter.InsertCommandText(avrTable);
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
            using (var connection = new OleDbConnection(m_AccessConnectionString))
            {
                AvrDataTable avrTable = new AvrDataTable(DataHelper.GenerateTestTable()) {TableName = TableName};
                RemoveCopyColumns(avrTable);
                connection.Open();
                OleDbTransaction transaction = connection.BeginTransaction();
                try
                {
                    AccessDataAdapter.DropTableIfExists(connection, transaction, TableName);

                    DataTable schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                        new object[] {null, null, null, "TABLE"});
                    Assert.IsNotNull(schemaTable);
                    int oldCount = schemaTable.Rows.Count;

                    AccessDataAdapter.CreateTable(connection, transaction, avrTable);

                    schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                        new object[] {null, null, null, "TABLE"});
                    Assert.IsNotNull(schemaTable);
                    Assert.AreEqual(oldCount + 1, schemaTable.Rows.Count);
                    Assert.AreEqual(TableName, schemaTable.Rows[oldCount]["TABLE_NAME"]);

                    AccessDataAdapter.InsertData(connection, transaction, avrTable);

                    var dataSet = new DataSet();

                    using (var adapter = new OleDbDataAdapter())
                    {
                        adapter.SelectCommand = new OleDbCommand(AccessDataAdapter.SelectCommandText(avrTable), connection)
                        {
                            Transaction = transaction
                        };
                        adapter.Fill(dataSet);
                        Assert.AreEqual(1, dataSet.Tables.Count);
                        Assert.AreEqual(10, dataSet.Tables[0].Rows.Count);
                    }

                    AccessDataAdapter.DropTableIfExists(connection, transaction, TableName);

                    schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                        new object[] {null, null, null, "TABLE"});
                    Assert.IsNotNull(schemaTable);
                    Assert.AreEqual(oldCount, schemaTable.Rows.Count);
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

            var avrTable = new AvrDataTable(table);
            RemoveCopyColumns(avrTable);
            avrTable = AccessDataAdapter.ConvertTable(avrTable, true);

            Assert.AreEqual(8, avrTable.Columns.Count);
            Assert.AreEqual("sflHC_CaseID_Caption", avrTable.Columns[2].ColumnName);
            Assert.AreEqual("column3_Caption1", avrTable.Columns[3].ColumnName);
            Assert.AreEqual("column3_Caption2", avrTable.Columns[4].ColumnName);
            Assert.AreEqual("column4_Caption", avrTable.Columns[5].ColumnName);
            Assert.AreEqual("column3_Caption3", avrTable.Columns[6].ColumnName);
            Assert.AreEqual("column3_Caption4", avrTable.Columns[7].ColumnName);
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
            var avrTable = new AvrDataTable(table);
            RemoveCopyColumns(avrTable);

            adapter.ExportTableToAccess(avrTable, true);

            Assert.AreEqual(true, adapter.IsTableExistInAccess(TableName));

            using (var connection = new OleDbConnection(m_AccessConnectionString))
            {
                connection.Open();
                AccessDataAdapter.DropTableIfExists(connection, null, TableName);
            }
            Assert.AreEqual(false, adapter.IsTableExistInAccess(TableName));
        }

        internal static string GetAccessDbFilePath()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string location = Path.GetDirectoryName(Utils.ConvertFileName(asm.Location)) + @"\AVR";

            if (!Directory.Exists(location))
            {
                int index = location.IndexOf("DevelopersBranch_v6", StringComparison.OrdinalIgnoreCase);
                if (index > 0)
                {
                    Directory.CreateDirectory(location);
                    string realPath = location.Substring(0, index) + @"DevelopersBranch_v6\eidss.main\bin\Debug\AVR\db_test.mdb";
                    File.Copy(realPath, location + @"\db_test.mdb");
                }
            }
            string path = Utils.GetFilePathNearAssembly(asm, @"AVR\db_test.mdb");
            return path;
        }

        public static void RemoveCopyColumns(AvrDataTable avrTable)
        {
            List<AvrDataColumn> columnsToRemove = avrTable.Columns.Where(c => c.ColumnName.Contains("_Copy")).ToList();
            foreach (AvrDataColumn column in columnsToRemove)
            {
                avrTable.Columns.Remove(column);
            }
        }
    }
}