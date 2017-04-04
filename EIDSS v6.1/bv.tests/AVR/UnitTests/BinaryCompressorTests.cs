using System;
using System.Collections.Generic;
using eidss.model.AVR.ServiceData;
using eidss.model.AVR.SourceData;
using eidss.model.WindowsService.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.tests.AVR.UnitTests
{
    [TestClass]
    public class BinaryCompressorTests
    {
        [TestMethod]
        public void SimpleCompressTest()
        {
            byte[] zip = BinaryCompressor.Zip(new byte[] {1});
            byte[] result = BinaryCompressor.Unzip(zip);
            Assert.AreEqual(1, result[0]);
        }

        [TestMethod]
        public void SimpleChunkCompressTest()
        {
            ChunkByteArray zip = BinaryCompressor.Zip(new ChunkByteArray(new byte[] {1}));
            ChunkByteArray result = BinaryCompressor.Unzip(zip);
            Assert.AreEqual(1, result[0]);
        }

        [TestMethod]
        public void ZeroCompressTest()
        {
            byte[] zip = BinaryCompressor.Zip(new byte[0]);
            byte[] result = BinaryCompressor.Unzip(zip);
            Assert.AreEqual(0, result.Length);
        }

        [TestMethod]
        public void ZeroChunkCompressTest()
        {
            ChunkByteArray zip = BinaryCompressor.Zip(new ChunkByteArray(new byte[0]));
            ChunkByteArray result = BinaryCompressor.Unzip(zip);
            Assert.AreEqual(0, result.Length);
        }

        [TestMethod]
        public void ComplexCompressTest()
        {
            const int length = 1000000;
            var source = new byte[length];
            new Random().NextBytes(source);
            byte[] zip = BinaryCompressor.Zip(source);
            byte[] result = BinaryCompressor.Unzip(zip);
            Assert.AreEqual(source.Length, result.Length);
            for (int i = 0; i < length; i++)
            {
                Assert.AreEqual(source[i], result[i]);
            }
        }

        [TestMethod]
        public void ComplexChunkCompressTest()
        {
            const int length = 1000000;
            var array = new byte[length];
            new Random().NextBytes(array);

            var source = new ChunkByteArray(array);
            var zip = BinaryCompressor.Zip(source);
            var result = BinaryCompressor.Unzip(zip);
            Assert.AreEqual(source.Length, result.Length);
            for (int i = 0; i < length; i++)
            {
                Assert.AreEqual(source[i], result[i]);
            }
        }

        [TestMethod]
        public void StringCompressTest()
        {
            const string source = "sdfwsf234349785423\\'dfg;5;425n\\фффыыыы```";
            byte[] zip = BinaryCompressor.ZipString(source);
            string result = BinaryCompressor.UnzipString(zip);
            Assert.AreEqual(source, result);
        }

        [TestMethod]
        public void PacketCompressTest()
        {
            var source = new QueryTablePacketDTO
            {
                RowCount = 1,
                BinaryBody = new ChunkByteArray(new byte[] {1, 2, 3}),
                IsArchive = true
            };
            QueryTablePacketDTO zip = BinaryCompressor.Zip(source);
            QueryTablePacketDTO result = BinaryCompressor.Unzip(zip);
            Assert.AreEqual(source.RowCount, result.RowCount);
            Assert.AreEqual(source.BinaryBody.Length, result.BinaryBody.Length);
            Assert.AreEqual(source.IsArchive, result.IsArchive);
            for (int i = 0; i < source.BinaryBody.Length; i++)
            {
                Assert.AreEqual(source.BinaryBody[i], result.BinaryBody[i]);
            }
        }

        [TestMethod]
        public void TableCompressTest()
        {
            var source = new QueryTableModel(123, "en")
            {
                Header = new QueryTablePacketDTO
                {
                    RowCount = 1,
                    BinaryBody = new ChunkByteArray(new byte[] {1, 2, 3}),
                    IsArchive = true
                },
                BodyPackets = new List<QueryTablePacketDTO>
                {
                    new QueryTablePacketDTO
                    {
                        RowCount = 2,
                        BinaryBody = new ChunkByteArray(new byte[] {4, 5, 6, 7, 8, 9}),
                        IsArchive = false
                    },
                    new QueryTablePacketDTO
                    {
                        RowCount = 3,
                        BinaryBody = new ChunkByteArray(new byte[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 10}),
                        IsArchive = true
                    },
                }
            };

            QueryTableModel zip = BinaryCompressor.Zip(source);
            QueryTableModel result = BinaryCompressor.Unzip(zip);
            Assert.AreEqual(source.Header.RowCount, result.Header.RowCount);
            Assert.AreEqual(source.Language, result.Language);
            Assert.AreEqual(source.QueryId, result.QueryId);
            Assert.AreEqual(source.Header.BinaryBody.Length, result.Header.BinaryBody.Length);
            for (int i = 0; i < source.Header.BinaryBody.Length; i++)
            {
                Assert.AreEqual(source.Header.BinaryBody[i], result.Header.BinaryBody[i]);
            }

            Assert.AreEqual(source.BodyPackets.Count, result.BodyPackets.Count);

            for (int i = 0; i < source.BodyPackets.Count; i++)
            {
                var sourcePacket = source.BodyPackets[i];
                var resultPacket = result.BodyPackets[i];
                Assert.AreEqual(sourcePacket.BinaryBody.Length, resultPacket.BinaryBody.Length);
                for (int j = 0; j < sourcePacket.BinaryBody.Length; j++)
                {
                    Assert.AreEqual(sourcePacket.BinaryBody[j], resultPacket.BinaryBody[j]);
                }
            }
        }

        [TestMethod]
        public void TableEmptyCompressTest()
        {
            var source = new QueryTableModel(123, "en");

            QueryTableModel zip = BinaryCompressor.Zip(source);
            QueryTableModel result = BinaryCompressor.Unzip(zip);
            Assert.AreEqual(0, result.Header.RowCount);
            Assert.AreEqual(source.Header.RowCount, result.Header.RowCount);
            Assert.AreEqual(source.Language, result.Language);
            Assert.AreEqual(source.QueryId, result.QueryId);
            Assert.AreEqual(source.UseArchivedData, result.UseArchivedData);
            Assert.AreEqual(source.Header.BinaryBody.Length, result.Header.BinaryBody.Length);
            Assert.AreEqual(0, result.Header.BinaryBody.Length);
        }
    }
}