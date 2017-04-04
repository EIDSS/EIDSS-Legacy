using System;
using System.Collections.Generic;
using System.Linq;
using bv.common.Core;
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
            ColumnTypes = deserializedHeader.Select(c => c.FinalType).ToArray();
        }

        internal QueryTableHeaderModel(QueryTableHeaderModel original)
        {
            Utils.CheckNotNull(original, "original");

            QueryCacheId = original.QueryCacheId;
            PacketCount = original.PacketCount;

            ColumnTypeByName = new List<BaseColumnModel>();
            foreach (BaseColumnModel originalColumn in original.ColumnTypeByName)
            {
                ColumnTypeByName.Add(originalColumn.Clone());
            }
            ColumnTypes = ColumnTypeByName.Select(c => c.FinalType).ToArray();
        }

        public long QueryCacheId { get; private set; }
        public int PacketCount { get; private set; }

        public List<BaseColumnModel> ColumnTypeByName { get; private set; }
        public Type[] ColumnTypes { get; private set; }

        public int ColumnCount
        {
            get { return ColumnTypes.Length; }
        }

        public QueryTableHeaderModel Clone()
        {
            return new QueryTableHeaderModel(this);
        }
    }
}