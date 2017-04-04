using System;
using System.IO;
using eidss.model.AVR.SourceData;
using eidss.model.WindowsService.Serialization;

namespace eidss.model.AVR.ServiceData
{
    [Serializable]
    public class BaseTablePacketDTO
    {
        public BaseTablePacketDTO()
        {
            BinaryBody = new ChunkByteArray(0);
        }

        public BaseTablePacketDTO(int rowCount, int bodyLength)
        {
            RowCount = rowCount;
            BinaryBody = new ChunkByteArray(bodyLength);
        }

        public int RowCount { get; set; }
        public ChunkByteArray BinaryBody { get; set; }

        public Stream StreamCreator()
        {
            Stream stream = new MemoryStream(BinaryBody.Length);

            stream.Write(BinaryBody, 0, BinaryBody.Length);
            stream.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }
    }
}