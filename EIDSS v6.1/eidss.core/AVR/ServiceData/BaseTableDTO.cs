using System;
using System.Collections.Generic;

namespace eidss.model.AVR.ServiceData
{
    [Serializable]
    public class BaseTableDTO
    {
        public BaseTableDTO()
        {
            Header = new BaseTablePacketDTO();
            BodyPackets = new List<BaseTablePacketDTO>();
        }

        public string TableName { get; set; }
        public BaseTablePacketDTO Header { get; set; }
        public IList<BaseTablePacketDTO> BodyPackets { get; set; }

        public override string ToString()
        {
            return string.Format("Table '{0}' with '{1}' columns and '{2}' zipped packets",
                TableName,
                Header != null ? Header.RowCount.ToString() : "No header",
                BodyPackets != null ? BodyPackets.Count.ToString() : "No packets");
        }
    }
}