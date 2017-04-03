using System;

namespace eidss.model.AVR.ServiceData
{
    [Serializable]
    public class BaseTablePacketDTO
    {
        public BaseTablePacketDTO()
        {
            BinaryBody = new byte[0];
        }

        public BaseTablePacketDTO(int rowCount, int bodyLength)
        {
            RowCount = rowCount;
            BinaryBody = new byte[bodyLength];
        }

        public int RowCount { get; set; }
        public byte[] BinaryBody { get; set; }
    }
}