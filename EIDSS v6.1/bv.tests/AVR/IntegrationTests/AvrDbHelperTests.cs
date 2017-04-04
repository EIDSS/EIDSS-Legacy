using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using bv.common.Configuration;
using bv.model.BLToolkit;
using bv.tests.AVR.Helpers;
using BLToolkit.Data;
using eidss.avr.db.CacheReceiver;
using eidss.model.Avr.View;
using eidss.model.AVR.DataBase;
using eidss.model.AVR.ServiceData;
using eidss.model.AVR.SourceData;
using eidss.model.WindowsService.Serialization;
using EIDSS.AVR.Service.WcfFacade;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.AVR.IntegrationTests
{
    [TestClass]
    public class AvrDbHelperTests
    {
        private static int m_FieldCount;

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
            m_FieldCount = DataHelper.GetQueryFieldsCount(49539640000000);
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            DbManagerFactory.SetSqlFactory(new ConnectionCredentials(null, "AvrService").ConnectionString, DatabaseType.Avr);
            DbManagerFactory.SetSqlFactory(new ConnectionCredentials(null, "Archive").ConnectionString, DatabaseType.Archive);
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
        }

        [TestMethod]
        public void TestDatabaseVersion()
        {
            DatabaseNames databaseNames = AvrDbHelper.GetDatabaseNames();
            Assert.IsNotNull(databaseNames);

            Assert.IsNotNull(databaseNames.EidssActualDbName);
            Assert.IsNotNull(databaseNames.EidssArchiveDbName);
            Assert.IsNotNull(databaseNames.AvrDbName);
        }

        [TestMethod]
        public void TestGetNonExistingTable()
        {
            Assert.IsNull(AvrDbHelper.GetQueryCacheId(1234, "en", false));
            Assert.IsNull(AvrDbHelper.GetQueryCacheId(new QueryCacheKey(1234, "en", false)));
            QueryTableHeaderDTO header = AvrDbHelper.GetQueryCacheHeader(1234, false, false);
            QueryTablePacketDTO packet = AvrDbHelper.GetQueryCachePacket(2310, 0);
            Assert.IsNotNull(header);
            Assert.IsNotNull(header.BinaryHeader);

            Assert.AreEqual(0, header.PacketCount);
            Assert.AreEqual(1234, header.QueryCacheId);
            Assert.AreEqual(0, header.BinaryHeader.RowCount);
            Assert.AreEqual(0, header.BinaryHeader.BinaryBody.Length);
            Assert.AreEqual(0, packet.RowCount);
            Assert.AreEqual(0, packet.BinaryBody.Length);
        }

        [TestMethod]
        public void GetQueryIdListTest()
        {
            List<long> list = AvrDbHelper.GetQueryIdList();
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count > 0);
            Assert.IsTrue(list.Contains(49539640000000));
        }

        [TestMethod]
        public void TestExistingTable()
        {
            using (var avrTran = new AvrDbTransaction())
            {
                DbManagerProxy manager = avrTran.Manager;
                DbManager command = manager.SetCommand(
                    @"      DELETE FROM [dbo].[QueryCachePacket] 
                            where [idfQueryCache] = @idflQueryCache
                            and ([idfQueryCachePacket] = @idflQueryCachePacket1 or [idfQueryCachePacket] = @idflQueryCachePacket2)

                            DELETE FROM [dbo].[QueryCache]
                            where [idfQueryCache] = @idflQueryCache
                            and [strLanguage] = @strLanguage",
                    manager.Parameter("idflQueryCache", 1),
                    manager.Parameter("strLanguage", "en"),
                    manager.Parameter("idflQueryCachePacket1", 1),
                    manager.Parameter("idflQueryCachePacket2", 2)
                    );

                command.ExecuteNonQuery();
                avrTran.CommitTransaction();
            }

            Assert.IsNull(AvrDbHelper.GetQueryCacheId(2, "en", false));
            Assert.AreEqual(0, AvrDbHelper.GetQueryCacheHeader(1, false, false).BinaryHeader.BinaryBody.Length);
            Assert.AreEqual(0, AvrDbHelper.GetQueryCachePacket(1, 0).BinaryBody.Length);

            var header = new byte[10000];
            for (int i = 0; i < header.Length; i++)
            {
                header[i] = (byte) i;
            }
            var packet = new byte[20000];
            for (int i = 0; i < packet.Length; i++)
            {
                packet[i] = (byte) (i + 10);
            }

            using (var avrTran = new AvrDbTransaction())
            {
                DbManagerProxy manager = avrTran.Manager;
                DbManager command = manager.SetCommand(
                    @"
                            SET IDENTITY_INSERT [dbo].[QueryCachePacket]  OFF
                            SET IDENTITY_INSERT [dbo].[QueryCache]  ON
                            INSERT INTO [dbo].[QueryCache]
                            ([idfQueryCache],[idfQuery],[strLanguage],[blbQuerySchema],[intQueryColumnCount],[datQueryRefresh],[datQueryCacheRequest],[blnUseArchivedData],[blnActualQueryCache]) 
                            VALUES (@idflQueryCache, @idflQuery, @strLanguage, @binHeaderCache, @intHeaderRowCount, GETDATE(), GETDATE(), 1, 0) 
                            SET IDENTITY_INSERT [dbo].[QueryCache]  OFF
                            SET IDENTITY_INSERT [dbo].[QueryCachePacket]  ON
                            INSERT INTO [dbo].[QueryCachePacket] 
                            ([idfQueryCachePacket],[idfQueryCache],[intQueryCachePacketNumber],[blbQueryCachePacket], [intTableRowCount],[blnArchivedData])
                            VALUES(@idflQueryCachePacket1, @idflQueryCache, 0, @binPacketCache, @intPacketRowCount, 0)
                            INSERT INTO [dbo].[QueryCachePacket] 
                            ([idfQueryCachePacket],[idfQueryCache],[intQueryCachePacketNumber],[blbQueryCachePacket], [intTableRowCount],[blnArchivedData])
                            VALUES(@idflQueryCachePacket2, @idflQueryCache, 1, @binPacketCache, @intPacketRowCount, 0)
                            SET IDENTITY_INSERT [dbo].[QueryCachePacket]  OFF",
                    manager.Parameter("idflQueryCache", 1),
                    manager.Parameter("idflQuery", 2),
                    manager.Parameter("strLanguage", "en"),
                    manager.Parameter("idflQueryCachePacket1", 1),
                    manager.Parameter("idflQueryCachePacket2", 2),
                    manager.Parameter("binHeaderCache", header),
                    manager.Parameter("binPacketCache", packet),
                    manager.Parameter("intHeaderRowCount", 10),
                    manager.Parameter("intPacketRowCount", 100)
                    );

                command.ExecuteNonQuery();
                avrTran.CommitTransaction();
            }
            Assert.AreEqual(1, AvrDbHelper.GetQueryCacheId(2, "en", false, 7, true));
            Assert.AreEqual(1, AvrDbHelper.GetQueryCacheId(new QueryCacheKey(2, "en", true), 7, true));
            QueryTableHeaderDTO resultHeader = AvrDbHelper.GetQueryCacheHeader(1, false, false);
            Assert.AreEqual(10, resultHeader.BinaryHeader.RowCount);
            Assert.AreEqual(2, resultHeader.PacketCount);
            Assert.AreEqual(1, resultHeader.QueryCacheId);

            AssertAreArrayEqual(new ChunkByteArray(header), resultHeader.BinaryHeader.BinaryBody);

            Assert.AreEqual(20000, AvrDbHelper.GetQueryCachePacket(1, 0).BinaryBody.Length);
            Assert.AreEqual(20000, AvrDbHelper.GetQueryCachePacket(1, 1).BinaryBody.Length);
            Assert.AreEqual(0, AvrDbHelper.GetQueryCachePacket(1, 2).BinaryBody.Length);

            QueryTablePacketDTO resultPacket = AvrDbHelper.GetQueryCachePacket(1, 0);
            Assert.AreEqual(100, resultPacket.RowCount);

            AssertAreArrayEqual(new ChunkByteArray(packet), resultPacket.BinaryBody);

            DateTime dateTime = AvrDbHelper.GetQueryRefreshDateTime(1, "en");
            Assert.IsTrue(DateTime.Now.Subtract(dateTime).Seconds < 2);

            AvrDbHelper.InvalidateQueryCache(2, "en");
            Assert.IsNull(AvrDbHelper.GetQueryCacheId(2, "en", false));
            Assert.IsNotNull(AvrDbHelper.GetQueryCacheId(2, "en", false, 7, true));

            Assert.AreNotEqual(0, AvrDbHelper.GetQueryCacheHeader(1, false, false).BinaryHeader.BinaryBody.Length);
            Assert.AreNotEqual(0, AvrDbHelper.GetQueryCachePacket(1, 0).BinaryBody.Length);

            AvrDbHelper.DeleteQueryCache(2, "en", true);
            Assert.IsNull(AvrDbHelper.GetQueryCacheId(2, "en", false));
            Assert.IsNotNull(AvrDbHelper.GetQueryCacheId(2, "en", false, 7, true));
        }

        [TestMethod]
        public void TestArchiveExistingTable()
        {
            using (var avrTran = new AvrDbTransaction())
            {
                DbManagerProxy manager = avrTran.Manager;
                DbManager command = manager.SetCommand(
                    @"      DELETE FROM [dbo].[QueryCachePacket] 
                            where [idfQueryCache] = @idflQueryCache
                            and ([idfQueryCachePacket] = @idflQueryCachePacket1 or [idfQueryCachePacket] = @idflQueryCachePacket2)

                            DELETE FROM [dbo].[QueryCache]
                            where [idfQueryCache] = @idflQueryCache
                            and [strLanguage] = @strLanguage",
                    manager.Parameter("idflQueryCache", 1),
                    manager.Parameter("strLanguage", "en"),
                    manager.Parameter("idflQueryCachePacket1", 1),
                    manager.Parameter("idflQueryCachePacket2", 2)
                    );

                command.ExecuteNonQuery();
                avrTran.CommitTransaction();
            }

            Assert.IsNull(AvrDbHelper.GetQueryCacheId(2, "en", false));
            Assert.AreEqual(0, AvrDbHelper.GetQueryCacheHeader(1, false, false).BinaryHeader.BinaryBody.Length);
            Assert.AreEqual(0, AvrDbHelper.GetQueryCachePacket(1, 0).BinaryBody.Length);

            var header = new byte[10000];
            var packet = new byte[20000];

            using (var avrTran = new AvrDbTransaction())
            {
                DbManagerProxy manager = avrTran.Manager;
                DbManager command = manager.SetCommand(
                    @"
                            SET IDENTITY_INSERT [dbo].[QueryCachePacket]  OFF
                            SET IDENTITY_INSERT [dbo].[QueryCache]  ON
                            INSERT INTO [dbo].[QueryCache]
                            ([idfQueryCache],[idfQuery],[strLanguage],[blbQuerySchema],[intQueryColumnCount],[datQueryRefresh],[datQueryCacheRequest],[blnUseArchivedData],[blnActualQueryCache]) 
                            VALUES (@idflQueryCache, @idflQuery, @strLanguage, @binHeaderCache, @intHeaderRowCount, GETDATE(), GETDATE(), 1, 1) 
                            SET IDENTITY_INSERT [dbo].[QueryCache]  OFF
                            SET IDENTITY_INSERT [dbo].[QueryCachePacket]  ON
                            INSERT INTO [dbo].[QueryCachePacket] 
                            ([idfQueryCachePacket],[idfQueryCache],[intQueryCachePacketNumber],[blbQueryCachePacket], [intTableRowCount],[blnArchivedData])
                            VALUES(@idflQueryCachePacket1, @idflQueryCache, 0, @binPacketCache, @intPacketRowCount, 0)
                            INSERT INTO [dbo].[QueryCachePacket] 
                            ([idfQueryCachePacket],[idfQueryCache],[intQueryCachePacketNumber],[blbQueryCachePacket], [intTableRowCount],[blnArchivedData])
                            VALUES(@idflQueryCachePacket2, @idflQueryCache, 1, @binPacketCache, @intPacketRowCount, 1)
                            SET IDENTITY_INSERT [dbo].[QueryCachePacket]  OFF",
                    manager.Parameter("idflQueryCache", 1),
                    manager.Parameter("idflQuery", 2),
                    manager.Parameter("strLanguage", "en"),
                    manager.Parameter("idflQueryCachePacket1", 1),
                    manager.Parameter("idflQueryCachePacket2", 2),
                    manager.Parameter("binHeaderCache", header),
                    manager.Parameter("binPacketCache", packet),
                    manager.Parameter("intHeaderRowCount", 10),
                    manager.Parameter("intPacketRowCount", 100)
                    );

                command.ExecuteNonQuery();
                avrTran.CommitTransaction();
            }
            Assert.AreEqual(1, AvrDbHelper.GetQueryCacheId(2, "en", false));
            QueryTableHeaderDTO resultHeader = AvrDbHelper.GetQueryCacheHeader(1, false, false);
            Assert.AreEqual(10, resultHeader.BinaryHeader.RowCount);
            Assert.AreEqual(1, resultHeader.PacketCount);
            Assert.AreEqual(1, resultHeader.QueryCacheId);
            Assert.AreEqual(false, resultHeader.BinaryHeader.IsArchive);

            Assert.AreEqual(1, AvrDbHelper.GetQueryCacheId(2, "en", true));
            resultHeader = AvrDbHelper.GetQueryCacheHeader(1, false, true);
            Assert.AreEqual(10, resultHeader.BinaryHeader.RowCount);
            Assert.AreEqual(2, resultHeader.PacketCount);
            Assert.AreEqual(1, resultHeader.QueryCacheId);
            Assert.AreEqual(true, resultHeader.BinaryHeader.IsArchive);

            QueryTablePacketDTO resultPacket1 = AvrDbHelper.GetQueryCachePacket(1, 0);
            Assert.AreEqual(20000, resultPacket1.BinaryBody.Length);
            Assert.AreEqual(false, resultPacket1.IsArchive);

            QueryTablePacketDTO resultPacket2 = AvrDbHelper.GetQueryCachePacket(1, 1);
            Assert.AreEqual(20000, resultPacket2.BinaryBody.Length);
            Assert.AreEqual(true, resultPacket2.IsArchive);
        }

        [TestMethod]
        public void TestExecuteQuery()
        {
            QueryTableModel tableModel = AvrDbHelper.GetQueryResult(49539640000000, "en", false);
            Assert.IsNotNull(tableModel);
            IList<QueryTablePacketDTO> packets = tableModel.BodyPackets;
            Assert.IsNotNull(packets);
            Assert.IsNotNull(tableModel.Header);
            Assert.AreEqual("en", tableModel.Language);
            Assert.AreEqual(49539640000000, tableModel.QueryId);
            Assert.IsTrue(packets.Count >= 1);
            Assert.IsFalse(packets.Any(p => p.IsArchive));
            Assert.IsTrue(packets.Any(p => !p.IsArchive));

            var zippedHeader = new QueryTableHeaderDTO(tableModel.Header, 1, packets.Count);

            var headerModel = new QueryTableHeaderModel(zippedHeader);
            Assert.AreEqual(m_FieldCount, headerModel.ColumnCount);
        }

        [TestMethod]
        public void TestExecuteArchiveQuery()
        {
            QueryTableModel tableModel = AvrDbHelper.GetQueryResult(49539640000000, "en", true);
            Assert.IsNotNull(tableModel);
            IList<QueryTablePacketDTO> packets = tableModel.BodyPackets;
            Assert.IsNotNull(packets);
            Assert.IsNotNull(tableModel.Header);
            Assert.AreEqual("en", tableModel.Language);
            Assert.AreEqual(49539640000000, tableModel.QueryId);
            Assert.IsTrue(packets.Count >= 1 * 2);
            Assert.IsTrue(packets.Any(p => p.IsArchive));
            Assert.IsTrue(packets.Any(p => !p.IsArchive));

            var zippedHeader = new QueryTableHeaderDTO(tableModel.Header, 1, packets.Count);
            var headerModel = new QueryTableHeaderModel(zippedHeader);
            Assert.AreEqual(m_FieldCount, headerModel.ColumnCount);
        }

        [TestMethod]
        public void TestSaveFullTable()
        {
            QueryTableModel source = GetTestTableModel();
            TestInternalSaveTable(source);
        }

        [TestMethod]
        public void TestSaveDeleteFullTable()
        {
            QueryTableModel source = GetTestTableModel();
            TestInternalSaveDeleteTable(source);
        }

        [TestMethod]
        public void TestSaveEmptyTable()
        {
            TestInternalSaveTable(new QueryTableModel(123, "en"));
        }

        [TestMethod]
        public void TestSaveDeleteFullArchiveTable()
        {
            QueryTableModel actualTable = GetTestTableModel();
            AvrDbHelper.InvalidateQueryCache(actualTable.QueryId, "en");
            Assert.IsFalse(AvrDbHelper.GetQueryCacheId(actualTable.QueryId, "en", false).HasValue);
            AvrDbHelper.SaveQueryCache(actualTable);

            Assert.IsNotNull(AvrDbHelper.GetQueryCacheId(actualTable.QueryId, "en", false));
            Assert.IsNull(AvrDbHelper.GetQueryCacheId(actualTable.QueryId, "en", true));

            QueryTableModel archiveTable = GetTestTableModel(true);
            AvrDbHelper.SaveQueryCache(archiveTable);
            long? actualId = AvrDbHelper.GetQueryCacheId(archiveTable.QueryId, "en", false);
            long? archiveId = AvrDbHelper.GetQueryCacheId(archiveTable.QueryId, "en", false);
            Assert.IsTrue(actualId.HasValue);
            Assert.IsTrue(archiveId.HasValue);

            QueryTableHeaderDTO archiveHeader = AvrDbHelper.GetQueryCacheHeader(archiveId.Value, false, true);
            QueryTableHeaderDTO actualHeader = AvrDbHelper.GetQueryCacheHeader(actualId.Value, false, false);

            Assert.AreEqual(archiveHeader.BinaryHeader.BinaryBody.Length, actualHeader.BinaryHeader.BinaryBody.Length);
            Assert.AreEqual(1, actualHeader.PacketCount);
            Assert.AreEqual(2, archiveHeader.PacketCount);
            Assert.IsFalse(AvrDbHelper.GetQueryCachePacket(archiveId.Value, 0).IsArchive);
            Assert.IsTrue(AvrDbHelper.GetQueryCachePacket(archiveId.Value, 1).IsArchive);

            AvrDbHelper.InvalidateQueryCache(actualTable.QueryId, "en");
            Assert.IsNull(AvrDbHelper.GetQueryCacheId(actualTable.QueryId, "en", false));
            Assert.IsNull(AvrDbHelper.GetQueryCacheId(actualTable.QueryId, "en", true));
            Assert.IsNotNull(AvrDbHelper.GetQueryCacheId(actualTable.QueryId, "en", false, 7, true));
            Assert.IsNotNull(AvrDbHelper.GetQueryCacheId(actualTable.QueryId, "en", true, 7, true));
            Assert.AreNotEqual(0, AvrDbHelper.GetQueryCacheHeader(archiveId.Value, false, false).BinaryHeader.BinaryBody.Length);
            Assert.AreNotEqual(0, AvrDbHelper.GetQueryCacheHeader(archiveId.Value, false, true).BinaryHeader.BinaryBody.Length);
            Assert.AreNotEqual(0, AvrDbHelper.GetQueryCachePacket(archiveId.Value, 0).BinaryBody.Length);
        }

        [TestMethod]
        public void TestRefreshedCacheOnUserCallAfterDaysTable()
        {
            QueryTableModel actualTable = GetTestTableModel();
            AvrDbHelper.InvalidateQueryCache(actualTable.QueryId, "en");
            Assert.IsFalse(AvrDbHelper.GetQueryCacheId(actualTable.QueryId, "en", false).HasValue);
            AvrDbHelper.SaveQueryCache(actualTable);

            long? id = AvrDbHelper.GetQueryCacheId(actualTable.QueryId, "en", false);
            Assert.IsTrue(id.HasValue);

            id = AvrDbHelper.GetQueryCacheId(actualTable.QueryId, "en", false, 0, true);
            Assert.IsTrue(id.HasValue);
            id = AvrDbHelper.GetQueryCacheId(actualTable.QueryId, "en", false, 0);
            Assert.IsFalse(id.HasValue);
            id = AvrDbHelper.GetQueryCacheId(actualTable.QueryId, "en", false, 1);
            Assert.IsTrue(id.HasValue);

            UpdateQueryRefreshDate(id, -6);
            id = AvrDbHelper.GetQueryCacheId(actualTable.QueryId, "en", false);
            Assert.IsTrue(id.HasValue);

            UpdateQueryRefreshDate(id, -8);
            id = AvrDbHelper.GetQueryCacheId(actualTable.QueryId, "en", false);
            Assert.IsFalse(id.HasValue);
        }

        [TestMethod]
        public void TestViewCache()
        {
            QueryTableModel actualTable = GetTestTableModel();
            AvrDbHelper.InvalidateQueryCache(actualTable.QueryId, "en");
            Assert.IsFalse(AvrDbHelper.GetQueryCacheId(actualTable.QueryId, "en", false).HasValue);
            AvrDbHelper.SaveQueryCache(actualTable);

            long? queryCacheId = AvrDbHelper.GetQueryCacheId(actualTable.QueryId, "en", false);
            Assert.IsTrue(queryCacheId.HasValue);

            ViewDTO sourceView = GetCachedView();
            var viewCacheId = AvrDbHelper.SaveViewCache(queryCacheId.Value, 1,sourceView);

            long? loadedViewCasheId = AvrDbHelper.GetViewCacheId(queryCacheId.Value, 11);
            Assert.IsFalse(loadedViewCasheId.HasValue);

            loadedViewCasheId = AvrDbHelper.GetViewCacheId(queryCacheId.Value, 1);
            Assert.IsTrue(loadedViewCasheId.HasValue);
            Assert.AreEqual(viewCacheId, loadedViewCasheId);

            var loadedView = AvrDbHelper.GetViewCache(viewCacheId, false);
            Assert.IsNotNull(loadedView);

            AvrDbHelper.InvalidateQueryCache(actualTable.QueryId);
            Assert.IsFalse(AvrDbHelper.GetQueryCacheId(actualTable.QueryId, "en", false).HasValue);

            loadedViewCasheId = AvrDbHelper.GetViewCacheId(queryCacheId.Value, 1);
            Assert.IsFalse(loadedViewCasheId.HasValue);

            loadedView = AvrDbHelper.GetViewCache(viewCacheId, false);
            Assert.IsNotNull(loadedView);

            AssertAreArrayEqual(sourceView.BinaryViewHeader, loadedView.BinaryViewHeader);
            AssertAreArrayEqual(sourceView.Header.BinaryBody, loadedView.Header.BinaryBody);
            Assert.AreEqual(sourceView.BodyPackets.Count, loadedView.BodyPackets.Count);
            for (int i = 0; i < loadedView.BodyPackets.Count; i++)
            {
                AssertAreArrayEqual(sourceView.BodyPackets[i].BinaryBody, loadedView.BodyPackets[i].BinaryBody);
            }

            AvrDbHelper.SaveViewCache(queryCacheId.Value, 1, sourceView);
            loadedViewCasheId = AvrDbHelper.GetViewCacheId(queryCacheId.Value, 1);
            Assert.IsTrue(loadedViewCasheId.HasValue);
            AvrDbHelper.InvalidateViewCache(1);
            loadedViewCasheId = AvrDbHelper.GetViewCacheId(queryCacheId.Value, 1);
            Assert.IsFalse(loadedViewCasheId.HasValue);
        }

        private static ViewDTO GetCachedView()
        {
            byte[] viewBytes = BinarySerializer.SerializeFromString(SerializedViewStub.ViewXml);
            byte[] viewZippedBytes = BinaryCompressor.Zip(viewBytes);

            DataTable sourceData = DataTableSerializer.Deserialize(SerializedViewStub.DataXml);

            BaseTableDTO serializedDTO = BinarySerializer.SerializeFromTable(sourceData);
            BaseTableDTO zippedDTO = BinaryCompressor.Zip(serializedDTO);

            var result = new ViewDTO(zippedDTO, viewZippedBytes);

            return result;
        }

        [TestMethod]
        public void TestGetQueryHeader()
        {
            QueryTableModel actualTable = GetTestTableModel();
            AvrDbHelper.InvalidateQueryCache(actualTable.QueryId, "en");
            Assert.IsFalse(AvrDbHelper.GetQueryCacheId(actualTable.QueryId, "en", false).HasValue);
            AvrDbHelper.SaveQueryCache(actualTable);

            long? id = AvrDbHelper.GetQueryCacheId(actualTable.QueryId, "en", false);
            Assert.IsTrue(id.HasValue);

            AvrDbHelper.GetQueryCacheHeader(id.Value, true, false);
            var requestDate = GetDateUserQueryCacheRequest(id);
            Assert.AreEqual(DBNull.Value, requestDate);

            AvrDbHelper.GetQueryCacheHeader(id.Value, false, false);
            requestDate = GetDateUserQueryCacheRequest(id);
            Assert.AreNotEqual(DBNull.Value, requestDate);
        }

        [TestMethod]
        public void TestGetUserQueryRefershDateHeader()
        {
            QueryTableModel table = GetTestTableModel();
            AvrDbHelper.SaveQueryCache(table);
            var queryId = table.QueryId;
            long? id = AvrDbHelper.GetQueryCacheId(queryId, "en", false);
            Assert.IsTrue(id.HasValue);

            using (var avrTran = new AvrDbTransaction())
            {
                DbManagerProxy manager = avrTran.Manager;
                DbManager command = manager.SetCommand(
                    @"      update QueryCache
                            set datUserQueryCacheRequest = NULL
                            where [idfQuery] = @idflQuery",
                    manager.Parameter("idflQuery", queryId)
                    );

                command.ExecuteNonQuery();
                avrTran.CommitTransaction();
            }

            var date = AvrDbHelper.GetsQueryCacheUserRequestDate(queryId);
            Assert.IsFalse(date.HasValue);

            AvrDbHelper.GetQueryCacheHeader(id.Value, true, false);
            date = AvrDbHelper.GetsQueryCacheUserRequestDate(queryId);
            Assert.IsFalse(date.HasValue);

            AvrDbHelper.GetQueryCacheHeader(id.Value, false, false);
            date = AvrDbHelper.GetsQueryCacheUserRequestDate(queryId);
            Assert.IsTrue(date.HasValue);
        }

        private static object GetDateUserQueryCacheRequest(long? id)
        {
            object datUserQueryCacheRequest;
            using (var avrTran = new AvrDbTransaction())
            {
                DbManagerProxy manager = avrTran.Manager;
                DbManager command = manager.SetCommand(
                    @"      select datUserQueryCacheRequest from QueryCache
                            where [idfQueryCache] = @idflQueryCache",
                    manager.Parameter("idflQueryCache", id)
                    );

                datUserQueryCacheRequest = command.ExecuteScalar();
            }
            return datUserQueryCacheRequest;
        }

        private static void UpdateQueryRefreshDate(long? id, int days)
        {
            using (var avrTran = new AvrDbTransaction())
            {
                DbManagerProxy manager = avrTran.Manager;
                DbManager command = manager.SetCommand(
                    @"      update QueryCache
                            set datQueryRefresh = DATEADD(day, @intDays, GETDATE())
                            where [idfQueryCache] = @idflQueryCache",
                    manager.Parameter("idflQueryCache", id),
                    manager.Parameter("intDays", days)
                    );

                command.ExecuteNonQuery();
                avrTran.CommitTransaction();
            }
        }

        private static void TestInternalSaveTable(QueryTableModel source)
        {
            QueryTableModel actualTable = GetTestTableModel();
            AvrDbHelper.InvalidateQueryCache(actualTable.QueryId, "en");
            Assert.IsFalse(AvrDbHelper.GetQueryCacheId(source.QueryId, "en", false).HasValue);
            AvrDbHelper.SaveQueryCache(source);

            //  manager.CommitTransaction();
            long? id = AvrDbHelper.GetQueryCacheId(source.QueryId, "en", false);
            Assert.IsTrue(id.HasValue);

            QueryTableHeaderDTO resultHeader = AvrDbHelper.GetQueryCacheHeader(id.Value, false, false);
            Assert.IsNotNull(resultHeader);
            Assert.IsNotNull(resultHeader.BinaryHeader);
            Assert.AreEqual(id.Value, resultHeader.QueryCacheId);
            Assert.AreEqual(source.BodyPackets.Count, resultHeader.PacketCount);
            Assert.AreEqual(source.Header.RowCount, resultHeader.BinaryHeader.RowCount);
            AssertAreArrayEqual(source.Header.BinaryBody, resultHeader.BinaryHeader.BinaryBody);

            for (int i = 0; i < resultHeader.PacketCount; i++)
            {
                QueryTablePacketDTO resultPacket = AvrDbHelper.GetQueryCachePacket(id.Value, i);
                Assert.IsNotNull(resultPacket);
                Assert.IsNotNull(resultPacket.BinaryBody);

                QueryTablePacketDTO sourcePacket = source.BodyPackets[i];
                Assert.IsNotNull(sourcePacket);
                Assert.IsNotNull(sourcePacket.BinaryBody);
                Assert.AreEqual(sourcePacket.RowCount, resultPacket.RowCount);
                AssertAreArrayEqual(sourcePacket.BinaryBody, resultPacket.BinaryBody);
            }
        }

        private static void TestInternalSaveDeleteTable(QueryTableModel source)
        {
            AvrDbHelper.InvalidateQueryCache(source.QueryId, "en");
            Assert.IsFalse(AvrDbHelper.GetQueryCacheId(source.QueryId, "en", false).HasValue);
            AvrDbHelper.SaveQueryCache(source);

            //  manager.CommitTransaction();
            long? id = AvrDbHelper.GetQueryCacheId(source.QueryId, "en", false);
            Assert.IsTrue(id.HasValue);
            long queryCacheId = id.Value;
            Assert.AreNotEqual(0, AvrDbHelper.GetQueryCacheHeader(queryCacheId, false, false).BinaryHeader.BinaryBody.Length);
            Assert.AreNotEqual(0, AvrDbHelper.GetQueryCachePacket(queryCacheId, 0).BinaryBody.Length);

            AvrDbHelper.InvalidateQueryCache(source.QueryId, "en");
            Assert.IsNull(AvrDbHelper.GetQueryCacheId(source.QueryId, "en", false));
            Assert.IsNotNull(AvrDbHelper.GetQueryCacheId(source.QueryId, "en", false, 7, true));
            Assert.AreNotEqual(0, AvrDbHelper.GetQueryCacheHeader(queryCacheId, false, false).BinaryHeader.BinaryBody.Length);
            Assert.AreNotEqual(0, AvrDbHelper.GetQueryCachePacket(queryCacheId, 0).BinaryBody.Length);

            AvrDbHelper.DeleteQueryCache(source.QueryId, "en", true);
            Assert.IsNull(AvrDbHelper.GetQueryCacheId(source.QueryId, "en", false));
            Assert.IsNotNull(AvrDbHelper.GetQueryCacheId(source.QueryId, "en", false, 7, true));
            Assert.AreNotEqual(0, AvrDbHelper.GetQueryCacheHeader(queryCacheId, false, false).BinaryHeader.BinaryBody.Length);
            Assert.AreNotEqual(0, AvrDbHelper.GetQueryCachePacket(queryCacheId, 0).BinaryBody.Length);

            AvrDbHelper.SaveQueryCache(source);
            AvrDbHelper.InvalidateQueryCache(source.QueryId, "en");
            AvrDbHelper.DeleteQueryCache(source.QueryId, "en", true);

            Assert.AreNotEqual(0, AvrDbHelper.GetQueryCacheHeader(queryCacheId, false, false).BinaryHeader.BinaryBody.Length);
            Assert.AreNotEqual(0, AvrDbHelper.GetQueryCachePacket(queryCacheId, 0).BinaryBody.Length);

            Assert.IsNull(AvrDbHelper.GetQueryCacheId(source.QueryId, "en", false));
            long? id2 = AvrDbHelper.GetQueryCacheId(source.QueryId, "en", false, 7, true);
            Assert.IsTrue(id2.HasValue);
            long queryCacheId2 = id2.Value;

            UpdateDateCacheRequest(source.QueryId);

            AvrDbHelper.DeleteQueryCache(source.QueryId, "en", true);
            Assert.AreEqual(0, AvrDbHelper.GetQueryCacheHeader(queryCacheId, false, false).BinaryHeader.BinaryBody.Length);
            Assert.AreEqual(0, AvrDbHelper.GetQueryCachePacket(queryCacheId, 0).BinaryBody.Length);

            Assert.AreNotEqual(0, AvrDbHelper.GetQueryCacheHeader(queryCacheId2, false, false).BinaryHeader.BinaryBody.Length);
            Assert.AreNotEqual(0, AvrDbHelper.GetQueryCachePacket(queryCacheId2, 0).BinaryBody.Length);

            UpdateDateCacheRequest(source.QueryId);
            AvrDbHelper.DeleteQueryCache(source.QueryId, "en", false);
            Assert.IsNull(AvrDbHelper.GetQueryCacheId(source.QueryId, "en", false, 7, true));
            Assert.AreEqual(0, AvrDbHelper.GetQueryCacheHeader(queryCacheId2, false, false).BinaryHeader.BinaryBody.Length);
            Assert.AreEqual(0, AvrDbHelper.GetQueryCachePacket(queryCacheId2, 0).BinaryBody.Length);
        }

        private static void UpdateDateCacheRequest(long query)
        {
            using (var avrTran = new AvrDbTransaction())
            {
                DbManagerProxy manager = avrTran.Manager;
                DbManager command = manager.SetCommand(
                    @"update dbo.QueryCache set datQueryCacheRequest = '2010-01-01' where idfQuery = @idflQuery",
                    manager.Parameter("idflQuery", query)
                    );

                command.ExecuteNonQuery();
                avrTran.CommitTransaction();
            }
        }

        private static QueryTableModel GetTestTableModel(bool isArchive = false)
        {
            var source = new QueryTableModel(123, "en")
            {
                UseArchivedData = isArchive,
                Header = new QueryTablePacketDTO
                {
                    RowCount = 1,
                    BinaryBody = new ChunkByteArray(new byte[] {1, 2, 3}),
                    IsArchive = isArchive,
                },
                BodyPackets = new List<QueryTablePacketDTO>
                {
                    new QueryTablePacketDTO
                    {
                        RowCount = 2,
                        BinaryBody = new ChunkByteArray(new byte[] {4, 5, 6, 7, 8, 9})
                    },
                    new QueryTablePacketDTO
                    {
                        RowCount = 3,
                        BinaryBody = new ChunkByteArray(new byte[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 10}),
                        IsArchive = isArchive
                    },
                },
            };
            return source;
        }

        private static void AssertAreArrayEqual(byte[] source, byte[] dest)
        {
            Assert.AreEqual(source.Length, dest.Length);
            for (int i = 0; i < source.Length; i++)
            {
                Assert.AreEqual(source[i], dest[i]);
            }
        }

        private static void AssertAreArrayEqual(ChunkByteArray source, ChunkByteArray dest)
        {
            Assert.AreEqual(source.Length, dest.Length);
            for (int i = 0; i < source.Length; i++)
            {
                Assert.AreEqual(source[i], dest[i]);
            }
        }
    }
}