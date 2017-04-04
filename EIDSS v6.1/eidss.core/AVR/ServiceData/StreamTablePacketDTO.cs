using System.IO;

namespace eidss.model.AVR.ServiceData
{
    public class StreamTablePacketDTO
    {
        public StreamTablePacketDTO()
        {
            Stream = new MemoryStream();
        }

        public StreamTablePacketDTO(int rowCount, int bodyLength)
        {
            RowCount = rowCount;
            Stream = new MemoryStream(bodyLength);
        }

        public int RowCount { get; set; }
        public bool IsArchive { get; set; }
        public Stream Stream { get; set; }
        public byte[] InputBuffer { get; set; }
        public byte[] OutputBuffer { get; set; }

        public Stream StreamCreator()
        {
            return Stream;
        }
    }
}