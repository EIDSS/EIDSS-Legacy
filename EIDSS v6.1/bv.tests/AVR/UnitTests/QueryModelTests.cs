using System;
using System.Collections.Generic;
using bv.common.Configuration;
using bv.model.BLToolkit;
using bv.tests.AVR.Helpers;
using eidss.avr.db.Common;
using eidss.model.AVR.ServiceData;
using eidss.model.AVR.SourceData;
using EIDSS.AVR.Service.WcfFacade;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class QueryModelTests
    {
        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
            DataHelper.GetQueryFieldsCount(49539640000000);
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            DbManagerFactory.SetSqlFactory(new ConnectionCredentials(null, "AvrService").ConnectionString, DatabaseType.Avr);
            DbManagerFactory.SetSqlFactory(new ConnectionCredentials(null, "Archive").ConnectionString, DatabaseType.Archive);
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
        }

        [TestMethod]
        public void QueryTableHeaderModelCloneTest()
        {
            QueryTableHeaderModel original = GetQueryTableHeaderModel();

            QueryTableHeaderModel clone = original.Clone();

            Assert.IsNotNull(clone);
            Assert.AreNotSame(clone, original);
            Assert.AreEqual(original.ColumnCount, clone.ColumnCount);
            Assert.AreEqual(original.PacketCount, clone.PacketCount);
            Assert.AreEqual(original.QueryCacheId, clone.QueryCacheId);

            Assert.AreNotSame(original.ColumnTypeByName, clone.ColumnTypeByName);
            Assert.AreEqual(original.ColumnTypeByName.Count, clone.ColumnTypeByName.Count);
            for (int i = 0; i < original.ColumnTypeByName.Count; i++)
            {
                BaseColumnModel originalColumn = original.ColumnTypeByName[i];
                BaseColumnModel cloneColumn = clone.ColumnTypeByName[i];

                Assert.AreNotSame(originalColumn, cloneColumn);
                Assert.AreEqual(originalColumn.Caption, cloneColumn.Caption);
                Assert.AreEqual(originalColumn.FinalType, cloneColumn.FinalType);
                Assert.AreEqual(originalColumn.InitilalType, cloneColumn.InitilalType);
                Assert.AreEqual(originalColumn.Name, cloneColumn.Name);
            }

            Assert.AreNotSame(original.ColumnTypes, clone.ColumnTypes);
            Assert.AreEqual(original.ColumnTypes.Length, clone.ColumnTypes.Length);
            for (int i = 0; i < original.ColumnTypes.Length; i++)
            {
                Type originalType = original.ColumnTypes[i];
                Type cloneType = clone.ColumnTypes[i];

                Assert.AreEqual(originalType.Name, cloneType.Name);
            }
        }

        [TestMethod]
        public void AvrDataTableCloneTest()
        {
            QueryTableHeaderModel model = GetQueryTableHeaderModel();

            var original = new AvrDataTable(model, 1024);
            original.Rows.Add(original.NewRow(new object[original.Columns.DistinctCount]));
            original.Rows.Add(original.NewRow(new object[original.Columns.DistinctCount]));
            Assert.AreEqual(2, original.Rows.Count);

            AvrDataTable clone = original.Clone();
            Assert.IsNotNull(clone);
            Assert.AreNotSame(clone, original);
            Assert.AreEqual(0, clone.Rows.Count);
            Assert.AreEqual(original.TableName, clone.TableName);
            Assert.AreEqual(clone.Columns.Count, original.Columns.Count);
            Assert.AreEqual(clone.Columns.DistinctCount, original.Columns.DistinctCount);
            Assert.AreEqual(clone.Columns.Properties.Count, original.Columns.Properties.Count);

            foreach (var column in original.Columns)
            {
                Assert.IsTrue(clone.Columns.Contains(column.ColumnName));
                Assert.IsFalse(clone.Columns.Contains(column));
            }
        }

        [TestMethod]
        public void AvrDataTableCopyTest()
        {
            QueryTableHeaderModel model = GetQueryTableHeaderModel();

            var original = new AvrDataTable(model, 1024);
            original.Rows.Add(original.NewRow(new object[original.Columns.DistinctCount]));
            Assert.AreEqual(1, original.Rows.Count);

            AvrDataTable copy = original.Copy();
            Assert.IsNotNull(copy);
            Assert.AreEqual(original.TableName, copy.TableName);
            Assert.AreNotSame(copy, original);
            Assert.IsTrue(copy.Rows.Count > 0);

            for (int i = 0; i < original.Count; i++)
            {
                var row = (AvrDataRow) original[i];
                var copyRow = (AvrDataRow) copy[i];
                Assert.AreNotSame(row, copyRow);
                Assert.IsNotNull(row.Array);
                Assert.IsNotNull(copyRow.Array);
                Assert.AreNotSame(row.Array, copyRow.Array);
                Assert.AreEqual(row.Count, copyRow.Count);
                for (int j = 0; j < row.Count; j++)
                {
                    Assert.AreEqual(row[j], copyRow[j]);
                }
            }
        }

        [TestMethod]
        public void AvrDataRowCopyTest()
        {
            var originalTable = new AvrDataTable();
            var array = new[] {1, 2, (object) "xx", true, new DateTime(2000, 1, 1)};
            AvrDataRow original = originalTable.NewRow(array);

            AvrDataRow copy = (AvrDataRow) original.Clone();
            Assert.IsNotNull(copy);
            Assert.AreNotSame(copy, original);

            Assert.AreEqual(original.Count, copy.Count);
            Assert.AreNotSame(original.Array, copy.Array);
            for (int i = 0; i < original.Count; i++)
            {
                Assert.AreEqual(original[i], copy[i]);
            }
        }

        [TestMethod]
        public void AvrDataRowExCopyTest()
        {
            var originalTable = new AvrDataTable();
            var rowDTO = new AvrDataRowDTO(1, 2, 2);
            rowDTO.SetInt(0, 1);
            rowDTO.SetInt(1, 2);
            rowDTO.SetObject(2, "xx");
            rowDTO.SetObject(3, true);
            rowDTO.SetDateTime(4, new DateTime(2000, 1, 1));

            AvrDataRowEx original = originalTable.NewRow(rowDTO);
            Assert.AreEqual(1, original[0]);
            Assert.AreEqual(2, original[1]);
            Assert.AreEqual("xx", original[2]);
            Assert.AreEqual(true, original[3]);
            Assert.AreEqual(new DateTime(2000, 1, 1), original[4]);

            AvrDataRowEx copy = (AvrDataRowEx) original.Clone();
            Assert.IsNotNull(copy);
            Assert.AreNotSame(copy, original);

            Assert.AreEqual(original.Count, copy.Count);

            for (int i = 0; i < original.Count; i++)
            {
                Assert.AreEqual(original[i], copy[i]);
            }
        }

        [TestMethod]
        public void AvrDataTableRejectChangesTest()
        {
            QueryTableHeaderModel model = GetQueryTableHeaderModel();

            var table = new AvrDataTable(model, 1024);
            table.Rows.Add(table.NewRow(new object[table.Columns.DistinctCount]));
            table.Rows.Add(table.NewRow(new object[table.Columns.DistinctCount]));
            Assert.AreEqual(2, table.Rows.Count);

            table.RejectChanges();
            Assert.AreEqual(0, table.Rows.Count);

            table.Rows.Add(table.NewRow(new object[table.Columns.DistinctCount]));
            table.Rows.Add(table.NewRow(new object[table.Columns.DistinctCount]));
            Assert.AreEqual(2, table.Rows.Count);
            table.AcceptChanges();
            table.RejectChanges();
            Assert.AreEqual(2, table.Rows.Count);

            table.Rows.Add(table.NewRow(new object[table.Columns.DistinctCount]));
            Assert.AreEqual(3, table.Rows.Count);
            table.RejectChanges();
            Assert.AreEqual(2, table.Rows.Count);

            table.Rows.Add(table.NewRow(new object[table.Columns.DistinctCount]));
            Assert.AreEqual(3, table.Rows.Count);
            table.AcceptChanges();
            table.RejectChanges();
            Assert.AreEqual(3, table.Rows.Count);
        }

        [TestMethod]
        public void AvrEmptyIntersectionFinderTest()
        {
            var data = GetTestData();
            
            AvrColumnRowIntersectionFinder finder = new AvrColumnRowIntersectionFinder(data);

            var colValues = new AvrFieldValueCollectionWithRowsWrapper(new AvrFieldValueCollection(), new AvrDataRowBase[0], new int[0]);
            var rowValues = new AvrFieldValueCollectionWithRowsWrapper(new AvrFieldValueCollection(), new AvrDataRowBase[0], new int[0]);

            finder.Enqueue(new AvrColumnRowIntersectionPair(new List<AvrFieldValueCollectionWithRowsWrapper>{ colValues }, rowValues));
            
            finder.WaitAll();
            finder.KillAll();
            finder.WaitAll();
            finder.KillAll();
        }

   


        private static AvrPivotGridData GetTestData()
        {
            var table = new AvrDataTable();
            for (int i = 0; i < 10; i++)
            {
                var rowDTO = new AvrDataRowDTO(1, 2, 2);
                rowDTO.SetInt(0, i);
                rowDTO.SetInt(1, 2*i);
                rowDTO.SetObject(2, "xx_" +i);
                rowDTO.SetObject(3, true);
                rowDTO.SetDateTime(4, new DateTime(2000, 1, i+1));

                AvrDataRowEx row = table.NewRow(rowDTO);
                table.ThreadSafeAdd(row);
            }

            table.AcceptChanges();
            return new AvrPivotGridData(table);
        }

        #region Helper Methods

        private static QueryTableHeaderModel GetQueryTableHeaderModel()
        {
            QueryTableModel tableModel = AvrDbHelper.GetQueryResult(49539640000000, "en", false);
            var zippedHeader = new QueryTableHeaderDTO(tableModel.Header, 1, tableModel.BodyPackets.Count);
            var original = new QueryTableHeaderModel(zippedHeader);
            return original;
        }

        #endregion
    }
}