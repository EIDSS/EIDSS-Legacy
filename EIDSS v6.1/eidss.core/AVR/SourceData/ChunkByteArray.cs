using System;
using System.IO;

namespace eidss.model.AVR.SourceData
{
    [Serializable]
    public class ChunkByteArray : ChunkArray<byte>
    {
        public ChunkByteArray(int length) : base(length)
        {
        }

        public ChunkByteArray(byte[] sourceArray) : base(sourceArray)
        {
        }

        public int ReadFromStream(Stream stream, ChunkByteArray buffer, int offset, int count)
        {
            int readed = 0;
            int index = 0;
            while (count > 0)
            {
                var readCount = count < ChunkSize
                    ? count
                    : ChunkSize;

                readed += stream.Read(m_Chunks[index], 0, readCount);

                count -= ChunkSize;
                index++;
            }
            return readed;
        }

        public void WriteToStream(Stream stream, ChunkByteArray buffer, int offset, int count)
        {
            int index = 0;
            while (count > 0)
            {
                var writeCount = count < ChunkSize
                    ? count
                    : ChunkSize;

                stream.Write(m_Chunks[index], 0, writeCount);

                count -= ChunkSize;
                index++;
            }
        }
    }
}