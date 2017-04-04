using System.IO;
using eidss.model.AVR.SourceData;

namespace eidss.model.WindowsService.Serialization
{
    public static class StreamExtender
    {
        public static int Read(this Stream stream, ChunkByteArray buffer, int offset, int count)
        {
            return buffer.ReadFromStream(stream, buffer, offset, count);
        }

        public static void Write(this Stream stream, ChunkByteArray buffer, int offset, int count)
        {
            buffer.WriteToStream(stream, buffer, offset, count);
        }
    }
}