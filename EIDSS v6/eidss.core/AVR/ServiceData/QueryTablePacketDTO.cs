using System;

namespace eidss.model.AVR.ServiceData
{
    [Serializable]
    public class QueryTablePacketDTO : BaseTablePacketDTO
    {
        public QueryTablePacketDTO()
        {
        }

        public QueryTablePacketDTO(int rowCount, int bodyLength) : base(rowCount, bodyLength)
        {
        }
        public bool IsArchive { get; set; }

        public static QueryTablePacketDTO FromBaseTablePacketDTO(BaseTablePacketDTO basePacket, bool isArchive)
        {
            var packet = new QueryTablePacketDTO
            {
                RowCount = basePacket.RowCount,
                BinaryBody = basePacket.BinaryBody,
                IsArchive = isArchive,
            };
            return packet;
        }
    }
}