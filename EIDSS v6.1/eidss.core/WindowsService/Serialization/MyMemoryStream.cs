using System.IO;

namespace eidss.model.WindowsService.Serialization
{
    public class MyMemoryStream:MemoryStream
    {
        public MyMemoryStream(int capacity) : base(capacity)
        {
        }

        public MyMemoryStream(byte[] buffer) : base(buffer)
        {
        }
    }
}