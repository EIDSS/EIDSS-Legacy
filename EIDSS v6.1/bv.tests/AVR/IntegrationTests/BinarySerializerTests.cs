using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using bv.common.Configuration;
using bv.tests.Core;
using BLToolkit.Data;
using BLToolkit.Data.DataProvider;
using eidss.avr.db.CacheReceiver;
using eidss.model.Avr.View;
using eidss.model.AVR.ServiceData;
using eidss.model.AVR.SourceData;
using eidss.model.Trace;
using eidss.model.WindowsService.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.AVR.IntegrationTests
{
    [TestClass]
    public class BinarySerializerTests
    {
        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            string scriptPath = PathToTestFolder.Get(TestFolders.Db) + "Data\\CreateTestTables.sql";
            ScriptLoader.RunScript(scriptPath);
        }

        [TestMethod]
        public void SerializeHeaderTest()
        {
            List<BaseColumnModel> columnModels;
            QueryTablePacketDTO header;

            using (var manager = new DbManager(new SqlDataProvider(), Config.GetSetting("TestConnectionString")))
            {
                using (IDbCommand command = manager.Connection.CreateCommand())
                {
                    command.CommandText = @"select  * from dbo.AVR_HumanCaseReport";
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        columnModels = BinarySerializer.GetSchemaColumnModels(reader.GetSchemaTable());
                        BinarySerializer.SerializeBodyPacket(reader, columnModels, false, 10);
                        header = BinarySerializer.SerializeHeader(columnModels, false);
                    }
                }
            }

            Assert.AreEqual(54, columnModels.Count);
            Assert.AreEqual(typeof (DateTime), columnModels[0].InitilalType);
            Assert.AreEqual(typeof (DateTime), columnModels[0].FinalType);
            Assert.AreEqual(typeof (long), columnModels[5].InitilalType);
            Assert.AreEqual(typeof (long), columnModels[5].FinalType);
            Assert.AreEqual(typeof (string), columnModels[49].InitilalType);
            Assert.AreEqual(typeof (string), columnModels[49].FinalType);
            Assert.AreEqual(typeof (object), columnModels[50].InitilalType);
            Assert.AreEqual(typeof (DateTime), columnModels[50].FinalType);

            Assert.IsNotNull(header);
            Assert.AreEqual(54, header.RowCount);

            using (Stream stream = new MemoryStream())
            {
                stream.Write(header.BinaryBody, 0, header.BinaryBody.Length);
                stream.Flush();
                stream.Seek(0, SeekOrigin.Begin);
                using (var reader = new BinaryReader(stream))
                {
                    for (int i = 0; i < header.RowCount; i++)
                    {
                        string name = reader.ReadString();
                        // it's caption
                        reader.ReadString();
                        Type type = Type.GetType(reader.ReadString());
                        switch (i)
                        {
                            case 0:
                                Assert.AreEqual("sflHC_PatientDOB", name);
                                Assert.AreEqual(typeof (DateTime), type);
                                break;
                            case 5:
                                Assert.AreEqual("sflHC_PatientSex_ID", name);
                                Assert.AreEqual(typeof (long), type);
                                break;
                            case 49:
                                Assert.AreEqual("sflHC_LabDiagBasis", name);
                                Assert.AreEqual(typeof (string), type);
                                break;
                            case 50:
                                Assert.AreEqual("sflHC_CS__10034010__9253110000000", name);
                                Assert.AreEqual(typeof (DateTime), type);
                                break;
                            case 51:
                                Assert.AreEqual("sflHC_CS__10034010__9253150000000", name);
                                Assert.AreEqual(typeof (int), type);
                                break;
                            case 52:
                                Assert.AreEqual("sflHC_CS__10034010__9254270000000_ID", name);
                                Assert.AreEqual(typeof (decimal), type);
                                break;
                            case 53:
                                Assert.AreEqual("sflHC_CS__10034010__9254270000000", name);
                                Assert.AreEqual(typeof (string), type);
                                break;
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void SerializeBodyTest()
        {
            List<BaseColumnModel> columnModels;
            IList<QueryTablePacketDTO> bodyPackets = new List<QueryTablePacketDTO>();
            using (var manager = new DbManager(new SqlDataProvider(), Config.GetSetting("TestConnectionString")))
            {
                using (IDbCommand command = manager.Connection.CreateCommand())
                {
                    command.CommandText = @"select  * from dbo.AVR_HumanCaseReport";
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        columnModels = BinarySerializer.GetSchemaColumnModels(reader.GetSchemaTable());
                        BinarySerializer.SerializeHeader(columnModels, false);
                        QueryTablePacketDTO packet = BinarySerializer.SerializeBodyPacket(reader, columnModels, false, 10);
                        while (packet.RowCount != 0)
                        {
                            bodyPackets.Add(packet);
                            packet = BinarySerializer.SerializeBodyPacket(reader, columnModels, false, 10);
                        }
                    }
                }
            }

            Assert.AreEqual(4, bodyPackets.Count);
            Assert.AreEqual(10, bodyPackets[0].RowCount);
            Assert.AreEqual(10, bodyPackets[1].RowCount);
            Assert.AreEqual(10, bodyPackets[2].RowCount);
            Assert.AreEqual(1, bodyPackets[3].RowCount);

            var processed = new object[columnModels.Count];
            using (Stream stream = new MemoryStream())
            {
                stream.Write(bodyPackets[3].BinaryBody, 0, bodyPackets[3].BinaryBody.Length);
                stream.Flush();
                stream.Seek(0, SeekOrigin.Begin);
                using (var reader = new BinaryReader(stream))
                {
                    for (int j = 0; j < columnModels.Count; j++)
                    {
                        bool hasValue = reader.ReadBoolean();
                        if (hasValue)
                        {
                            Type type = columnModels[j].FinalType;
                            if (type == typeof (String))
                            {
                                processed[j] = reader.ReadString();
                            }
                            else if (type == typeof (Int64))
                            {
                                processed[j] = reader.ReadInt64();
                            }
                            else if (type == typeof (Int32))
                            {
                                processed[j] = reader.ReadInt32();
                            }
                            else if (type == typeof (Int16))
                            {
                                processed[j] = reader.ReadInt16();
                            }
                            else if (type == typeof (DateTime))
                            {
                                processed[j] = new DateTime(reader.ReadInt64());
                            }
                            else if (type == typeof (Double))
                            {
                                processed[j] = reader.ReadDouble();
                            }
                            else if (type == typeof (Decimal))
                            {
                                processed[j] = reader.ReadDecimal();
                            }
                            else if (type == typeof (Single))
                            {
                                processed[j] = reader.ReadSingle();
                            }
                            else if (type == typeof (Boolean))
                            {
                                processed[j] = reader.ReadBoolean();
                            }
                            else if (type == typeof (Byte))
                            {
                                processed[j] = reader.ReadByte();
                            }
                        }
                        else
                        {
                            processed[j] = DBNull.Value;
                        }
                    }
                }
                stream.Close();
            }

            Assert.AreEqual(new DateTime(1990, 02, 01), processed[0]);
            Assert.AreEqual(23, processed[1]);
            Assert.AreEqual(DBNull.Value, processed[3]);
            Assert.AreEqual("xxx", processed[4]);
            Assert.AreEqual("Male", processed[6]);
            Assert.AreEqual(DBNull.Value, processed[7]);
            Assert.AreEqual(DateTime.Now.Year, ((DateTime) processed[50]).Year);
            Assert.AreEqual(DateTime.Now.Year, processed[51]);
            Assert.AreEqual(25460000000m, processed[52]);
            Assert.AreEqual("Yes", processed[53]);
        }

        [TestMethod]
        public void DeserializeHeaderTest()
        {
            List<BaseColumnModel> resultHeader;
            using (var manager = new DbManager(new SqlDataProvider(), Config.GetSetting("TestConnectionString")))
            {
                using (IDbCommand command = manager.Connection.CreateCommand())
                {
                    command.CommandText = @"select  * from dbo.AVR_HumanCaseReport";
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        List<BaseColumnModel> columnModels = BinarySerializer.GetSchemaColumnModels(reader.GetSchemaTable());
                        BinarySerializer.SerializeBodyPacket(reader, columnModels, false);
                        QueryTablePacketDTO header = BinarySerializer.SerializeHeader(columnModels, false);
                        resultHeader = BinarySerializer.DeserializeHeader(header);
                    }
                }
            }

            Assert.IsTrue(resultHeader.Exists(c => c.Name == "sflHC_PatientDOB"));
            Assert.IsTrue(resultHeader.Exists(c => c.Name == "sflHC_PatientSex_ID"));
            Assert.IsTrue(resultHeader.Exists(c => c.Name == "sflHC_LabDiagBasis"));
            Assert.IsTrue(resultHeader.Exists(c => c.Name == "sflHC_CS__10034010__9253110000000"));
            Assert.AreEqual(typeof (DateTime), resultHeader.Find(c => c.Name == "sflHC_PatientDOB").FinalType);
            Assert.AreEqual(typeof (long), resultHeader.Find(c => c.Name == "sflHC_PatientSex_ID").FinalType);
            Assert.AreEqual(typeof (string), resultHeader.Find(c => c.Name == "sflHC_LabDiagBasis").FinalType);
            Assert.AreEqual(typeof (DateTime), resultHeader.Find(c => c.Name == "sflHC_CS__10034010__9253110000000").FinalType);
        }

        [TestMethod]
        public void DeserializeBodyTest()
        {
            List<BaseColumnModel> columnModels;
            IList<QueryTablePacketDTO> bodyPackets = new List<QueryTablePacketDTO>();
            using (var manager = new DbManager(new SqlDataProvider(), Config.GetSetting("TestConnectionString")))
            {
                using (IDbCommand command = manager.Connection.CreateCommand())
                {
                    command.CommandText = @"select  * from dbo.AVR_HumanCaseReport";
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        columnModels = BinarySerializer.GetSchemaColumnModels(reader.GetSchemaTable());
                        BinarySerializer.SerializeHeader(columnModels, false);
                        QueryTablePacketDTO packet = BinarySerializer.SerializeBodyPacket(reader, columnModels, false, 10);
                        while (packet.RowCount != 0)
                        {
                            bodyPackets.Add(packet);
                            packet = BinarySerializer.SerializeBodyPacket(reader, columnModels, false, 10);
                        }
                    }
                }
            }
            Assert.AreEqual(4, bodyPackets.Count);
            Type[] types = columnModels.Select(c => c.FinalType).ToArray();

            AvrDataTable array = new AvrDataTable(new DataTable());

            for (int i = 0; i < 4; i++)
            {
                BinarySerializer.DeserializeBodyPacket(bodyPackets[i], types, array);
            }
            array.AcceptChanges();
            Assert.AreEqual(31, array.Count);
            Assert.AreEqual(54, array[0].Count);

            AvrDataRowEx row3 = (AvrDataRowEx) array[3];
            Assert.AreEqual(typeof (string), row3[53].GetType());
            Assert.AreEqual("2", row3[53].ToString());

            AvrDataRowEx row5 = (AvrDataRowEx) array[5];
            Assert.AreEqual(typeof (DateTime), row5[50].GetType());
            Assert.AreEqual(2010, ((DateTime) row5[50]).Year);

            AvrDataRowEx row8 = (AvrDataRowEx) array[8];

            Assert.AreEqual(typeof (decimal), row8[52].GetType());
            Assert.AreEqual(0m, row8[52]);

            AvrDataRowEx row = (AvrDataRowEx) array[30];

            Assert.AreEqual(new DateTime(1990, 02, 01), row[0]);
            Assert.AreEqual(23, row[1]);
            Assert.AreEqual(DBNull.Value, row[3]);
            Assert.AreEqual("xxx", row[4]);
            Assert.AreEqual("Male", row[6]);
            Assert.AreEqual(DBNull.Value, row[7]);
            Assert.AreEqual(DateTime.Now.Year, ((DateTime) row[50]).Year);
            Assert.AreEqual(DateTime.Now.Year, row[51]);
            Assert.AreEqual(25460000000m, row[52]);
            Assert.AreEqual("Yes", row[53]);
        }

        [TestMethod]
        public void SerializeIntegrationTest()
        {
            QueryTableModel tableModel;
            using (var manager = new DbManager(new SqlDataProvider(), Config.GetSetting("TestConnectionString")))
            {
                using (DbManager command = manager.SetCommand(@"select  * from dbo.AVR_HumanCaseReport"))
                {
                    tableModel = BinarySerializer.SerializeFromCommand(command, 123, "en", false, 10);
                }
            }

            Assert.AreEqual(54, tableModel.Header.RowCount);
            Assert.AreEqual(false, tableModel.UseArchivedData);
            Assert.AreEqual(false, tableModel.Header.IsArchive);

            QueryTablePacketDTO zippedHeader = BinaryCompressor.Zip(tableModel.Header);
            Assert.AreEqual(false, zippedHeader.IsArchive);
            List<QueryTablePacketDTO> zippedBody = tableModel.BodyPackets.Select(BinaryCompressor.Zip).ToList();
            Assert.IsFalse(zippedBody.Any(p => p.IsArchive));

            QueryTablePacketDTO unzipedHeader = BinaryCompressor.Unzip(zippedHeader);
            Assert.AreEqual(false, unzipedHeader.IsArchive);
            List<QueryTablePacketDTO> unzippedBody = zippedBody.Select(BinaryCompressor.Unzip).ToList();
            Assert.IsFalse(unzippedBody.Any(p => p.IsArchive));

            List<BaseColumnModel> resultHeader = BinarySerializer.DeserializeHeader(unzipedHeader);

            Assert.IsTrue(resultHeader.Exists(c => c.Name == "sflHC_PatientDOB"));
            Assert.IsTrue(resultHeader.Exists(c => c.Name == "sflHC_PatientSex_ID"));
            Assert.IsTrue(resultHeader.Exists(c => c.Name == "sflHC_LabDiagBasis"));
            Assert.AreEqual(typeof (DateTime), resultHeader.Find(c => c.Name == "sflHC_PatientDOB").FinalType);
            Assert.AreEqual(typeof (long), resultHeader.Find(c => c.Name == "sflHC_PatientSex_ID").FinalType);
            Assert.AreEqual(typeof (string), resultHeader.Find(c => c.Name == "sflHC_LabDiagBasis").FinalType);

            Type[] types = resultHeader.Select(c => c.FinalType).ToArray();

            AvrDataTable resultBody = new AvrDataTable(new DataTable());

            foreach (var packetDTO in unzippedBody)
            {
                BinarySerializer.DeserializeBodyPacket(packetDTO, types, resultBody);
            }

            Assert.AreEqual(31, resultBody.Count);
            Assert.AreEqual(54, resultBody[0].Count);

            AvrDataRowEx row = (AvrDataRowEx) resultBody[30];

            Assert.AreEqual(new DateTime(1990, 02, 01), row[0]);
            Assert.AreEqual(23, row[1]);
            Assert.AreEqual(DBNull.Value, row[3]);
            Assert.AreEqual("xxx", row[4]);
            Assert.AreEqual("Male", row[6]);
            Assert.AreEqual(DBNull.Value, row[7]);
            Assert.AreEqual(DateTime.Now.Year, ((DateTime) row[50]).Year);
            Assert.AreEqual(DateTime.Now.Year, row[51]);
            Assert.AreEqual(25460000000m, row[52]);
            Assert.AreEqual("Yes", row[53]);
        }

        [TestMethod]
        public void SerializeIntegrationArchiveTest()
        {
            QueryTableModel tableModel;
            using (var manager = new DbManager(new SqlDataProvider(), Config.GetSetting("TestConnectionString")))
            {
                using (DbManager command = manager.SetCommand(@"select  * from dbo.AVR_HumanCaseReport"))
                {
                    tableModel = BinarySerializer.SerializeFromCommand(command, 123, "en", true, 10);
                }
            }

            Assert.AreEqual(54, tableModel.Header.RowCount);
            Assert.AreEqual(true, tableModel.UseArchivedData);
            Assert.AreEqual(true, tableModel.Header.IsArchive);

            QueryTablePacketDTO zippedHeader = BinaryCompressor.Zip(tableModel.Header);
            Assert.AreEqual(true, zippedHeader.IsArchive);
            List<QueryTablePacketDTO> zippedBody = tableModel.BodyPackets.Select(BinaryCompressor.Zip).ToList();
            Assert.IsFalse(zippedBody.Any(p => !p.IsArchive));

            QueryTablePacketDTO unzipedHeader = BinaryCompressor.Unzip(zippedHeader);
            Assert.AreEqual(true, unzipedHeader.IsArchive);
            List<QueryTablePacketDTO> unzippedBody = zippedBody.Select(BinaryCompressor.Unzip).ToList();
            Assert.IsFalse(unzippedBody.Any(p => !p.IsArchive));
        }

        [TestMethod]
        public void SerializeZipHumanTableTest()
        {
            DataTable sourceData;

            using (new StopwathTransaction("+++ Select from DB +++"))
            {
                using (var manager = new DbManager(new SqlDataProvider(), Config.GetSetting("EidssConnectionString")))
                {
                    using (DbManager command = manager.SetCommand(@"select * from fn_AVR_HumanCaseReport('en')"))
                    {
                        command.Command.CommandTimeout = 120;
                        sourceData = command.ExecuteDataTable();
                    }
                }
            }

            BaseTableDTO serializedDTO;
            using (new StopwathTransaction("+++ SerializeFromTable +++"))
            {
                serializedDTO = BinarySerializer.SerializeFromTable(sourceData, 10000);
            }
            BaseTableDTO zippedDTO;
            using (new StopwathTransaction("+++ ZipFromTable +++"))
            {
                zippedDTO = BinaryCompressor.Zip(serializedDTO);
            }
            BaseTableDTO unzippedDTO;
            using (new StopwathTransaction("+++ UnzipFromTable +++"))
            {
                unzippedDTO = BinaryCompressor.Unzip(zippedDTO);
            }

            DataTable resultData;
            using (new StopwathTransaction("+++ DeserializeToTable +++"))
            {
                resultData = BinarySerializer.DeserializeToTable(unzippedDTO);
            }

            AssertTablesAreEqual(sourceData, resultData);
        }

        [TestMethod]
        public void SerializeZipViewTableTest()
        {
            DataTable sourceData = DataTableSerializer.Deserialize(SerializedViewStub.DataXml);

            BaseTableDTO serializedDTO = BinarySerializer.SerializeFromTable(sourceData, 10000);
            BaseTableDTO zippedDTO = BinaryCompressor.Zip(serializedDTO);
            BaseTableDTO unzippedDTO = BinaryCompressor.Unzip(zippedDTO);
            DataTable resultData = BinarySerializer.DeserializeToTable(unzippedDTO);

            AssertTablesAreEqual(sourceData, resultData);
        }

        [TestMethod]
        public void SerializeZipViewStrictureTest()
        {
            byte[] serializedView = BinarySerializer.SerializeFromString(SerializedViewStub.ViewXml);
            byte[] zippedView = BinaryCompressor.Zip(serializedView);
            byte[] unzippedView = BinaryCompressor.Unzip(zippedView);

            Assert.AreEqual(serializedView.Length, unzippedView.Length);
            for (int i = 0; i < serializedView.Length; i++)
            {
                Assert.AreEqual(serializedView[i], unzippedView[i]);
            }

            string viewXml = BinarySerializer.DeserializeToString(unzippedView);
            Assert.AreEqual(SerializedViewStub.ViewXml, viewXml);
        }

        [TestMethod]
        public void SerializeMD5Test()
        {
            using (new StopwathTransaction("+++MD5FromString(Test)+++"))
            {
                string md5Test = BinarySerializer.MD5FromString("Test");
                Assert.AreEqual("8E06915D5F5D4F8754F51892D884C477", md5Test);
            }
            using (new StopwathTransaction("+++MD5FromString(null)+++"))
            {
                string md5Null = BinarySerializer.MD5FromString(null);
                Assert.AreEqual("B5AD6B0BF0A02267A16F6E8BF93F8B31", md5Null);
            }
            using (new StopwathTransaction("+++MD5FromString()+++"))
            {
                string md5Empty = BinarySerializer.MD5FromString(string.Empty);
                Assert.AreEqual("B5AD6B0BF0A02267A16F6E8BF93F8B31", md5Empty);
            }
            using (new StopwathTransaction("+++MD5FromString()+++"))
            {
                string md5Empty = BinarySerializer.MD5FromString("*");
                Assert.AreEqual("B5AD6B0BF0A02267A16F6E8BF93F8B31", md5Empty);
            }
            using (new StopwathTransaction("+++MD5)+++"))
            {
                MD5 md5 = MD5.Create();
                md5.Dispose();
            }
        }

        public static void AssertTablesAreEqual(DataTable sourceData, DataTable resultData)
        {
            Assert.AreEqual(sourceData.TableName, resultData.TableName);
            Assert.AreEqual(sourceData.Columns.Count, resultData.Columns.Count);
            Assert.AreEqual(sourceData.Rows.Count, resultData.Rows.Count);

            for (int i = 0; i < sourceData.Columns.Count; i++)
            {
                DataColumn sourceColumn = sourceData.Columns[i];
                DataColumn resultColumn = resultData.Columns[i];
                Assert.AreEqual(sourceColumn.DataType, resultColumn.DataType);
                Assert.AreEqual(sourceColumn.ColumnName, resultColumn.ColumnName);
                Assert.AreEqual(sourceColumn.Caption, resultColumn.Caption);
            }
            for (int i = 0; i < sourceData.Rows.Count; i++)
            {
                DataRow sourceRow = sourceData.Rows[i];
                DataRow resultRow = resultData.Rows[i];
                for (int j = 0; j < sourceData.Columns.Count; j++)
                {
                    Assert.AreEqual(sourceRow[j], resultRow[j]);
                }
            }
        }
    }
}