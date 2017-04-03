using System;
using System.Collections.Generic;
using System.Linq;
using eidss.model.WindowsService.Serialization;

namespace eidss.model.AVR.ServiceData
{
    public class QueryTableHeaderModel
    {
        public QueryTableHeaderModel(QueryTableHeaderDTO headerDTO)
        {
            QueryCacheId = headerDTO.QueryCacheId;
            PacketCount = headerDTO.PacketCount;

            QueryTablePacketDTO unzipedHeader = BinaryCompressor.Unzip(headerDTO.BinaryHeader);
            List<BaseColumnModel> deserializedHeader = BinarySerializer.DeserializeHeader(unzipedHeader);
            ColumnTypeByName = deserializedHeader;
            ColumnTypes = deserializedHeader.Select(c => c.Type).ToArray();
        }

        public long QueryCacheId { get; private set; }
        public int PacketCount { get; private set; }

        public List<BaseColumnModel> ColumnTypeByName { get; private set; }
        public Type[] ColumnTypes { get; private set; }

        public int ColumnCount
        {
            get { return ColumnTypes.Length; }
        }
    }
}