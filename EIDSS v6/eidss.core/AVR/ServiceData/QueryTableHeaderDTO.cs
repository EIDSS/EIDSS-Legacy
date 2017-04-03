using System;

namespace eidss.model.AVR.ServiceData
{
    [Serializable]
    public class QueryTableHeaderDTO
    {
        public QueryTableHeaderDTO()
        {
            BinaryHeader = new QueryTablePacketDTO();
        }

        public QueryTableHeaderDTO(QueryTablePacketDTO binaryHeader, long queryCacheId, int packetCount)
        {
            BinaryHeader = binaryHeader;
            PacketCount = packetCount;
            QueryCacheId = queryCacheId;
        }

        public QueryTablePacketDTO BinaryHeader { get; set; }
        public int PacketCount { get; set; }
        public long QueryCacheId { get; set; }
    }
}