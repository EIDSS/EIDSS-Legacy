using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using bv.common.Core;
using eidss.model.AVR.ServiceData;
using eidss.model.AVR.SourceData;
using Ionic.Zip;
using Ionic.Zlib;

namespace eidss.model.WindowsService.Serialization
{
    public static class BinaryCompressor
    {
        private const string EntryName = "EntryName";

        public static ChunkByteArray Zip(ChunkByteArray sourceChunkBuffer)
        {
            Utils.CheckNotNull(sourceChunkBuffer, "sourceBuffer");
            using (Stream stream = new MemoryStream())
            {
                using (var zip = new ZipFile())
                {
                    zip.CompressionLevel = CompressionLevel.Default;

                    zip.AddEntry(EntryName, sourceChunkBuffer.ToArray());
                    zip.Save(stream);
                }
                stream.Flush();
                stream.Seek(0, SeekOrigin.Begin);
                var compressedChunkBuffer = new ChunkByteArray((int) stream.Length);
                int readed = stream.Read(compressedChunkBuffer, 0, (int) stream.Length);
                Debug.Assert(stream.Length == readed, "not all bytes readed");
                return compressedChunkBuffer;
            }
        }

        public static byte[] Zip(byte[] sourceBuffer)
        {
            Utils.CheckNotNull(sourceBuffer, "sourceBuffer");
            using (Stream stream = new MemoryStream())
            {
                using (var zip = new ZipFile())
                {
                    zip.CompressionLevel = CompressionLevel.Default;

                    zip.AddEntry(EntryName, sourceBuffer);
                    zip.Save(stream);
                }
                stream.Flush();
                stream.Seek(0, SeekOrigin.Begin);
                var compressedBuffer = new byte[stream.Length];
                int readed = stream.Read(compressedBuffer, 0, (int) stream.Length);
                Debug.Assert(stream.Length == readed, "not all bytes readed");
                return compressedBuffer;
            }
        }

        public static byte[] ZipString(string source)
        {
            byte[] serializedSource = BinarySerializer.SerializeFromString(source);
            var result = Zip(serializedSource);
            return result;
        }

        public static QueryTablePacketDTO Zip(QueryTablePacketDTO sourcePacket)
        {
            var result = new QueryTablePacketDTO
            {
                RowCount = sourcePacket.RowCount,
                BinaryBody = Zip(sourcePacket.BinaryBody),
                IsArchive = sourcePacket.IsArchive
            };
            return result;
        }

        public static BaseTablePacketDTO Zip(BaseTablePacketDTO sourcePacket)
        {
            var result = new BaseTablePacketDTO
            {
                RowCount = sourcePacket.RowCount,
                BinaryBody = Zip(sourcePacket.BinaryBody),
            };
            return result;
        }

        public static BaseTableDTO Zip(BaseTableDTO sourceTable)
        {
            var result = new BaseTableDTO
            {
                TableName = sourceTable.TableName,
                Header = Zip(sourceTable.Header),
                BodyPackets = sourceTable.BodyPackets.Select(Zip).ToList(),
            };
            return result;
        }

        public static QueryTableModel Zip(QueryTableModel sourceTable)
        {
            var result = new QueryTableModel(sourceTable.QueryId, sourceTable.Language)
            {
                Header = Zip(sourceTable.Header),
                BodyPackets = sourceTable.BodyPackets.Select(Zip).ToList(),
                UseArchivedData = sourceTable.UseArchivedData,
            };
            return result;
        }

        public static byte[] Unzip(byte[] sourceBuffer)
        {
            Utils.CheckNotNull(sourceBuffer, "sourceBuffer");
            using (Stream stream = new MemoryStream(sourceBuffer))
            {
                using (ZipFile zip = ZipFile.Read(stream))
                {
                    ZipEntry e = zip[EntryName];
                    using (Stream outputStream = new MemoryStream())
                    {
                        e.Extract(outputStream);
                        outputStream.Flush();
                        outputStream.Seek(0, SeekOrigin.Begin);
                        var uncompressedBuffer = new byte[outputStream.Length];
                        int readed = outputStream.Read(uncompressedBuffer, 0, (int) outputStream.Length);
                        Debug.Assert(outputStream.Length == readed, "not all bytes readed");
                        return uncompressedBuffer;
                    }
                }
            }
        }

        public static ChunkByteArray Unzip(ChunkByteArray sourceChunkBuffer)
        {
            using (Stream outputStream = UnzipStream(sourceChunkBuffer))
            {
                var uncompressedChunkBuffer = new ChunkByteArray((int) outputStream.Length);
                int readed = outputStream.Read(uncompressedChunkBuffer, 0, (int) outputStream.Length);
                Debug.Assert(outputStream.Length == readed, "not all bytes readed");
                return uncompressedChunkBuffer;
            }
        }

        public static Stream UnzipStream(ChunkByteArray sourceChunkBuffer, byte[] inputBuffer = null, byte[] outputBuffer = null)
        {
            Utils.CheckNotNull(sourceChunkBuffer, "sourceBuffer");
            MyMemoryStream stream = inputBuffer == null
                ? new MyMemoryStream(sourceChunkBuffer.Length)
                : new MyMemoryStream(inputBuffer);

            stream.Write(sourceChunkBuffer, 0, sourceChunkBuffer.Length);

            stream.Flush();
            stream.Seek(0, SeekOrigin.Begin);

            using (ZipFile zip = ZipFile.Read(stream))
            {
                ZipEntry e = zip[EntryName];

                if (outputBuffer != null && outputBuffer.Length < e.UncompressedSize)
                {
                    throw new AvrException("Could not uzip to provided buffer because it's too small");
                }

                Stream outputStream = outputBuffer == null
                    ? new MemoryStream((int) e.UncompressedSize)
                    : new MemoryStream(outputBuffer);

                e.Extract(outputStream);
                outputStream.Flush();
                outputStream.Seek(0, SeekOrigin.Begin);
                return outputStream;
            }
        }

        public static long GetUncompressedSize(ChunkByteArray sourceChunkBuffer)
        {
            Utils.CheckNotNull(sourceChunkBuffer, "sourceBuffer");
            using (Stream stream = new MemoryStream(sourceChunkBuffer.Length))
            {
                stream.Write(sourceChunkBuffer, 0, sourceChunkBuffer.Length);

                stream.Flush();
                stream.Seek(0, SeekOrigin.Begin);

                using (ZipFile zip = ZipFile.Read(stream))
                {
                    ZipEntry e = zip[EntryName];
                    return e.UncompressedSize;
                }
            }
        }

        public static string UnzipString(byte[] sourceBuffer)
        {
            string result = string.Empty;
            try
            {
                byte[] unzip = Unzip(sourceBuffer);
                result = BinarySerializer.DeserializeToString(unzip);
            }
            catch (Exception)
            {
                bool isBadVersion5Format = false;
                try
                {
                    result = UnzipStringVersion5(sourceBuffer);
                }
                catch (Exception)
                {
                    isBadVersion5Format = true;
                }
                if (isBadVersion5Format)
                {
                    throw;
                }
            }
            return result;
        }

        private static string UnzipStringVersion5(byte[] compressed)
        {
            //  throw new ApplicationException("test");
            if (compressed == null || compressed.Length == 0)
            {
                return string.Empty;
            }

            string uncompressed = ZlibStream.UncompressString(compressed);
            // if it contains old format value (xml)
            if (uncompressed.Length == 0 || uncompressed[0] == '<')
            {
                return uncompressed;
            }
            // if it contains new format value (base64 string)
            byte[] encodedDataAsBytes = Convert.FromBase64String(uncompressed);
            return Encoding.Unicode.GetString(encodedDataAsBytes);
        }

        public static BaseTablePacketDTO Unzip(BaseTablePacketDTO sourcePacket)
        {
            var result = new BaseTablePacketDTO
            {
                RowCount = sourcePacket.RowCount,
                BinaryBody = Unzip(sourcePacket.BinaryBody),
            };
            return result;
        }

        public static QueryTablePacketDTO Unzip(QueryTablePacketDTO sourcePacket)
        {
            var result = new QueryTablePacketDTO
            {
                RowCount = sourcePacket.RowCount,
                BinaryBody = Unzip(sourcePacket.BinaryBody),
                IsArchive = sourcePacket.IsArchive,
            };
            return result;
        }

        public static StreamTablePacketDTO UnzipStream
            (QueryTablePacketDTO sourcePacket, byte[] inputBuffer = null, byte[] outputBuffer = null)
        {
            var result = new StreamTablePacketDTO
            {
                RowCount = sourcePacket.RowCount,
                Stream = UnzipStream(sourcePacket.BinaryBody, inputBuffer, outputBuffer),
                InputBuffer = inputBuffer,
                OutputBuffer = outputBuffer,
                IsArchive = sourcePacket.IsArchive
            };
            return result;
        }

        public static QueryTableModel Unzip(QueryTableModel sourceTable)
        {
            var result = new QueryTableModel(sourceTable.QueryId, sourceTable.Language)
            {
                Header = Unzip(sourceTable.Header),
                BodyPackets = sourceTable.BodyPackets.Select(Unzip).ToList(),
                UseArchivedData = sourceTable.UseArchivedData
            };
            return result;
        }

        public static BaseTableDTO Unzip(BaseTableDTO sourceTable)
        {
            var result = new BaseTableDTO
            {
                TableName = sourceTable.TableName,
                Header = Unzip(sourceTable.Header),
                BodyPackets = sourceTable.BodyPackets.Select(Unzip).ToList(),
            };
            return result;
        }
    }
}